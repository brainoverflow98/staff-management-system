$(document).ready(function() {		
	
	//$(function () {
	//  $('[data-toggle="tooltip"]').tooltip()
	//});	
	
	$('#sidebarCollapse').on('click', function () {
		$('#sidebar').toggleClass('active');
		$(this).toggleClass('active');
	});
	
}); 




//<Change Page begin>
function loadPageInfo()
{
	var page_info = $(".page-info");
	for(let info of page_info)
	{
		var table_no = $(info).attr("table-no");
		var span = $(info).find("span");
		var table = TABLES[table_no];
		$(span[0]).text(1);
		table.pageNo = 1;
		var total_row = 0;
		for(var i=0;i<table.rows.length;i++)
		{
			if(!table.rows[i].hidden)
				total_row++;
		}
		var overflow = total_row % table.perPage == 0 ? 0 : 1;
		var total_page_no = Math.floor(total_row / table.perPage) + overflow;
		$(span[1]).text(total_page_no);
	}
}

$(".prev-page").on( "click", function(e) {	
	
	var table_no = parseInt($(this).attr("table-no"));
	var page_info = $(".page-info[table-no='"+table_no+"'] span");
	var current_page = parseInt(page_info[0].textContent);
	if(current_page>1)
	{
		TABLES[table_no].pageNo--;	
		loadTable(table_no);
		page_info[0].textContent = --current_page;
	}	
});

$(".next-page").on( "click", function(e) {	
	
	var table_no = parseInt($(this).attr("table-no"));
	var page_info = $(".page-info[table-no='"+table_no+"'] span");
	var current_page = parseInt(page_info[0].textContent);
	var total_page = parseInt(page_info[1].textContent);
	if(total_page>current_page)
	{
		TABLES[table_no].pageNo++;	
		loadTable(table_no);
		page_info[0].textContent = ++current_page;
	}	
});
//<Change Page end>


//<Table link begin>
$("table").on( "click", "th[href], tr[href]", function(e) {	
	var href = this.getAttribute("href");
	var a = document.createElement('a');
	a.href = href;
	//a.target = "_blank";	
	a.dispatchEvent(new MouseEvent(`click`, {bubbles: true, cancelable: true, view: window}));	
});
//<Table link end>


//<Save begin>
$(".save").on( "click", function(e) {
	var tableNo = this.getAttribute("table-no");
	var changes = getChangesJSON(tableNo);
	
	console.log(changes);
	
	$.ajax({
	  method: "POST",
	  url: `/Puantaj/Kaydet`,
	  contentType: "application/json",
	  dataType: 'json',
	  data: JSON.stringify(changes)	 	  
	})
	  .done(function( ) {
		   	$("table[table-no='"+tableNo+"']").find("td.changed").each(function(i,e){
				$(e).removeClass("changed");
			});	
			alert("Değişiklikler kaydedildi !");
	  });
	
}); 
//<Save end>

//<Refresh begin>
$(".refresh").on( "click", function(e) {
	var tableNo = this.getAttribute("table-no");	
	refreshTable(tableNo);		
}); 
//<Refresh end>

//<Download begin>
function s2ab(s) {
	var buf = new ArrayBuffer(s.length);
	var view = new Uint8Array(buf);
	for (var i=0; i<s.length; i++) view[i] = s.charCodeAt(i) & 0xFF;
	return buf;
}
$(".wb-download").on( "click", function(e) {
	var wb_id = $(this).attr("wb-id");
	var wb = XLSX.utils.book_new();	
	wb.Props = {
			Title: wb_id,	
			Subject: "",
			Author: "Personel Puantaj Sistemi",
			CreatedDate: new Date()			
	};
			
	
	$("table[wb-id='"+wb_id+"']").each(function(i,t){
		var ws_id = $(t).attr("ws-id");
		wb.SheetNames.push(ws_id);
		var ws_data = [];
		var tableNo = t.getAttribute("table-no");
		var TableObj = TABLES[tableNo]

		for(var r=0; r<TableObj.headers.length; r++)
		{
			var row_data = [];
			var RowObj = TableObj.headers[r];
			for(var c=0; c<RowObj.columns.length; c++)
			{
				var ColObj = RowObj.columns[c];
				var value = cellValue(ColObj, tableNo);
				if(value instanceof Date){
					value = value.getDate()+"/"+(value.getMonth()+1)+"/"+value.getFullYear()
				}
				row_data.push(value);
				
			}
			ws_data.push(row_data);
		}
		for(var r=0; r<TableObj.rows.length; r++)
		{
			var row_data = [];
			var RowObj = TableObj.rows[r];
			for(var c=0; c<RowObj.columns.length; c++)
			{
				var ColObj = RowObj.columns[c];
				var value = cellValue(ColObj, tableNo);				
				row_data.push(value);				
			}
			ws_data.push(row_data);
		}		
		var ws = XLSX.utils.aoa_to_sheet(ws_data,{dateNF: "DD/MM/YY"});
		wb.Sheets[ws_id] = ws;
	});	
	
	var wbout = XLSX.write(wb, {bookType:'xlsx', bookSST:true, type: 'binary'});
	saveAs(new Blob([s2ab(wbout)],{type:"application/octet-stream"}), wb_id+'.xlsx');
});

function cellValue(cell, tableNo)
{			
	var value;	
	var type = cell.type;	
	switch(type)
	{
		case "txt":		
		value = cell.value;
		break;
		
		case "num":		
		value = parseInt(cell.value);
		if(!value) value = 0;
		break;
		
		case "date":		
		var date_arr = cell.value.split(".");
		var yyyy = date_arr[2];
		var mm = date_arr[1];
		var dd = date_arr[0];
		value = new Date(yyyy+"-"+mm+"-"+dd);
		break;
		
		case "poll":	
		var optionID = cell.value;
		value = TABLES[tableNo].optionGroups[0][optionID].text;				
		break;
		
		
		default:
		value = cell.value;
	}
	return value;
} 
//<Download end>




//<Sort begin>
$(".sort-by").on( "change", function(e) {	
	e.preventDefault();
	var table_no = parseInt($(this).attr("table-no"));
	var sort_column_uid = $(this).val();	
	var asc = parseInt($(".sort-order[table-no='"+table_no+"']").val());
	if(sort_column_uid != "0")
	sort(table_no, sort_column_uid, asc);
	
});

$(".sort-order").on( "change", function(e) {		
	e.preventDefault();
	var table_no = parseInt($(this).attr("table-no"));
	var sort_column_uid = $(".sort-by[table-no='"+table_no+"']").val();	
	var asc = parseInt($(this).val());	
	if(sort_column_uid != "0")
	sort(table_no, sort_column_uid, asc);		
});

function sort(table_no, sort_column_uid, asc)
{
    var rows = TABLES[table_no].rows;  
	var sort_column_no = getColNo(table_no, sort_column_uid);
	var type = rows[0].columns[sort_column_no].type;	
	
	switch(type)
	{
		case "num":
			rows.sort(function(a, b){				
				
				if(asc)
				{
                    var first = parseInt(a.columns[sort_column_no].value) || 0;
                    var second = parseInt(b.columns[sort_column_no].value) || 0;
                    return first - second;
				}			
				else 
				{
                    var first = parseInt(a.columns[sort_column_no].value) || 0;
                    var second = parseInt(b.columns[sort_column_no].value) || 0;
                    return second - first;
				}			
			});
		break;
		case "txt":
			rows.sort(function(a, b){ 							
				if(asc)
				{				
					return a.columns[sort_column_no].value.toString().localeCompare(b.columns[sort_column_no].value.toString()) 
				}			  
				else 
				{
					return - a.columns[sort_column_no].value.toString().localeCompare(b.columns[sort_column_no].value.toString()) 
				}			
			});
		break;
	}  
	loadPageInfo();
	loadTable(table_no);
}
//<Sort end>



//<Aler begin>

	/*if(yillik_izin>6){
		$('#alert-field div.container').append(
			'<div class="alert alert-danger alert-dismissible fade show" role="alert">'+
				'<strong>TD.010</strong> Sicil No\'lu <strong>Hakan Çuhadar</strong> için yıllık izin hakkı aşıldı.'+ 
					'<button type="button" class="close" data-dismiss="alert" aria-label="Close">'+
						'<span aria-hidden="true">&times;</span>'+
					'</button>'+
			'</div>'
		);
	}*/
	
	/*<div id="alert-field">
		<div class="container">
			<div class="alert alert-danger alert-dismissible fade show" role="alert">
			  <strong>TD.010</strong> Sicil No'lu <strong>Hakan Çuhadar</strong> için yıllık izin hakkı aşıldı. 
			  <button type="button" class="close" data-dismiss="alert" aria-label="Close">
				<span aria-hidden="true">&times;</span>
			  </button>
			</div>
			<div class="alert alert-warning alert-dismissible fade show" role="alert">
			  <strong>TD.006</strong> Sicil No'lu <strong>Yasin Yurt</strong> için aylık çalışma saati <strong>30</strong>'un üzerine çıktı.
			  <button type="button" class="close" data-dismiss="alert" aria-label="Close">
				<span aria-hidden="true">&times;</span>
			  </button>
			</div>
		</div>		
	</div>*/	
	
//<Alert end>


//<Search begin> 
$('.search-box').on('input', function() {
	var table_no = parseInt($(this).attr("table-no"));
	var search_text = $(this).val().toLocaleLowerCase('tr');	
	var search_column_uid = $(".search-by[table-no='"+table_no+"']").val();	
	if(search_column_uid != "0")
	search(search_text, table_no, search_column_uid);
});

$('.search-by').on('change', function() {
	var table_no = parseInt($(this).attr("table-no"));
	var search_text = $(".search-box[table-no='"+table_no+"']").val().toLocaleLowerCase('tr');
	var search_column_uid = $(this).val();	
	if(search_column_uid != "0")
	search(search_text, table_no, search_column_uid);
});

function search(search_text, table_no, search_column_uid)
{	
	if( /\S/.test(search_text) && search_text.length > 1)
	{		
		var rows = TABLES[table_no].rows;  
		var search_column_no = getColNo(table_no, search_column_uid);
		
		$(rows).each(function(i,r){
			
			var c = r.columns[search_column_no];
			
			if(c.value.toString().toLocaleLowerCase('tr').indexOf(search_text) < 0)
			{
				r.hidden = true;
			}
			else 
			{
				r.hidden = false;
			}
		});
	} 
	else
	{
		var rows = TABLES[table_no].rows; 
		$(rows).each(function(i,r){					
			r.hidden = false;			
		});
	}
	loadPageInfo();
	loadTable(table_no);
}
//<Search end>  


//<Popup Context Menu Start>
var opened = false;
var over = false;
$('.contex-menu').on('mousedown', function(e) {
	
	if(opened && !over)
	{
		opened = false;
		$(this).find(".popup-menu").removeClass("show").hide();
		e.preventDefault();
	}
	else
	{		
		if(e.which == 2)
		{
			opened = true;
			var top = e.pageY - 10;
			var left = e.pageX - 90;
			$(this).find(".popup-menu").css({
				display: "block",
				top: top,
				left: left
			}).addClass("show");
			
			e.preventDefault();
		}		
	}
	
});

$(".popup-menu button").on("click", function() {	
	var table_no = parseInt(this.parentElement.getAttribute("table-no"));
	var day_of_week = parseInt(this.getAttribute("value"));
	var table = $("table[table-no='"+table_no+"']");
	var selected_cells = table.find("td.selected");
	for(let cell of selected_cells)	
	{
		var id  = cell.id.split("-");
		var row_no = id[3];
		var col_no = id[5];
		
		var TableObj = TABLES[table_no];
		var CellObj = TableObj.rows[row_no].columns[col_no];
		var uid = CellObj.uid;
		if(uid && !CellObj.disabled)
		{
			var date = uid.split(".");
			var dd = date[0];
			var mm = date[1];
			var yyyy = date[2];
			var DateObj = new Date(yyyy+"-"+mm+"-"+dd);
			if(DateObj.getDay() != day_of_week)
			{
				cell.classList.remove("selected");
			}
		}
		else
		{
			cell.classList.remove("selected");
		}
	}
	$(this).parent().hide();
	opened = false;
	over = false;
});

$(".popup-menu").on( "mouseenter", function(e) {
	over = true;	
}).on( "mouseleave", function(e) {
	over = false;	
});
//<Popup Context Menu End>


//<Right select begin>    
var select_state = false;

var last_selected_row=-1;
var last_selected_col=-1;
var last_group_selected_row=-1;
var last_group_selected_col=-1;
var group_select_target_row=-1;
var group_select_target_col=-1;

function selectCell(e, td)
{
	var id = td.id.split("-");
	var target_table = parseInt(id[1]);
	var t = target_table;
	var target_row = parseInt(id[3]);
	var target_col = parseInt(id[5]);
	
		
	if(e.ctrlKey && !e.shiftKey)
	{        				
		if(!td.classList.contains("disabled"))
		{
			document.querySelector(".last-selected").classList.remove("last-selected");
			td.classList.add("selected");
			td.classList.add("last-selected");
			last_selected_row = target_row;
			last_selected_col = target_col;
			
			var highlighted_row_headers = document.querySelectorAll("th.highlighted");
			for(let header of highlighted_row_headers)
			{
				header.classList.remove("highlighted");
			}		
			var row_headers = td.parentElement.getElementsByTagName("th");
			for(let header of row_headers)
			{
				header.classList.add("highlighted");
			}
		}		
	}   
	else if((!e.ctrlKey && e.shiftKey) || select_state)
	{
		if(last_selected_row != -1 && last_selected_row != -1)
		{                   
			
			var col_start, col_end;    
			var row_start, row_end;   
			
			if
			(
				last_selected_row == last_group_selected_row && last_selected_col == last_group_selected_col &&
				(((group_select_target_col-last_group_selected_col > 0 || group_select_target_row-last_group_selected_row > 0) && 
				(group_select_target_col > target_col || group_select_target_row > target_row)) ||
				((group_select_target_col-last_group_selected_col < 0 || group_select_target_row-last_group_selected_row < 0) && 
				(group_select_target_col < target_col || group_select_target_row < target_row)))				
			)
			{
				if(last_group_selected_col > group_select_target_col)
				{
				  col_end = last_group_selected_col;
				  col_start = group_select_target_col;
				} 
				else
				{
				  col_end = group_select_target_col;
				  col_start = last_group_selected_col;
				} 

				if(last_group_selected_row > group_select_target_row)
				{
				  row_end = last_group_selected_row;
				  row_start = group_select_target_row;
				} 
				else
				{
				  row_end = group_select_target_row;
				  row_start = last_group_selected_row;
				}   
				
				for(var c=col_start; c < col_end+1; c++)
				{      
				  for(var r=row_start; r < row_end+1; r++)
				  {					
					document.getElementById("t-"+t+"-r-"+r+"-c-"+c).classList.remove("selected");
				  }                            
				} 					
			}
			
			
			if(target_col > last_selected_col)
			{
			  col_end = target_col;
			  col_start = last_selected_col;
			} 
			else
			{
			  col_end = last_selected_col;
			  col_start = target_col;
			} 

			if(target_row > last_selected_row)
			{
			  row_end = target_row;
			  row_start = last_selected_row;
			} 
			else
			{
			  row_end = last_selected_row;
			  row_start = target_row;
			}   
			
			for(var c=col_start; c < col_end+1; c++)
			{      
			  for(var r=row_start; r < row_end+1; r++)
			  {				
				var cell = document.getElementById("t-"+t+"-r-"+r+"-c-"+c);
				if(!cell.parentElement.hasAttribute("hidden") && !cell.classList.contains("disabled"))
				{
					cell.classList.add("selected");
				}
			  }                            
			}     			
			
			last_group_selected_row = last_selected_row;
			last_group_selected_col = last_selected_col;
			group_select_target_row = target_row;
			group_select_target_col = target_col;
			
		}                
	} 
	else 
	{
		if(!td.classList.contains("disabled"))
		{
			document.querySelectorAll("td.selected").forEach(function(e){
				e.classList.remove("selected");
			});
			var last = document.querySelector(".last-selected");
			last ? last.classList.remove("last-selected") : null;
			td.classList.add("selected");
			td.classList.add("last-selected");
			last_selected_row = target_row,
			last_selected_col = target_col;
			
			var highlighted_row_headers = document.querySelectorAll("th.highlighted");
			for(let header of highlighted_row_headers)
			{
				header.classList.remove("highlighted");
			}		
			var row_headers = td.parentElement.getElementsByTagName("th");
			for(let header of row_headers)
			{
				header.classList.add("highlighted");
			}
		}
		
		/*
		var sel = td.querySelector("select");
		var last_modified = sel.getAttribute("last-modified");
		var modified_by = sel.getAttribute("modified-by");
		var prev_val = sel.getAttribute("prev-val");
		document.getElementById("last-change-info").value = "Son değiştirme: "+last_modified+" Değiştiren: "+modified_by+" Önceki değer: "+prev_val;
		*/
	}
}


$("table.selectable-table").on( "mousedown", "td", function(e) {
	if(e.which == 3)
	{
		var td = this;
		selectCell(e, td);
		select_state = true;		
	}  			
}); 
$("table.selectable-table").on( "mouseenter", "td", function(e) {
	if(select_state)
	{		
		var td = this;
		selectCell(e, td);
	}  			
});   

/* var tid = 0;
function autoScroll(pageX, pageY)
{
	if(select_state)
	{
		var table = $(".selectable-table");
		var scrollV = table.scrollTop(); 
		var scrollH = table.scrollLeft();
		var offset = table.offset();
		var tableX = table.width() + offset.left - 35;
		var tableY = table.height() + offset.top - 25;		
		
		var call_again = false;
		if(pageY > tableY)
		{
			table.scrollTop(scrollV+10);
			call_again = true;
		}
		if(pageX > tableX)
		{
			table.scrollLeft(scrollH+10);
			call_again = true;
		}
		if(pageY < offset.top + 105)
		{
			table.scrollTop(scrollV-10);
			call_again = true;
		}
		if(pageX < offset.left + 130)
		{
			table.scrollLeft(scrollH-10);
			call_again = true;
		}
		if(call_again)
		{
			tid = setTimeout(autoScroll, 50, pageX, pageY);			
		}		
	}
}
	
$("table.selectable-table").on( "mousemove", function(e) {
	e.preventDefault();
	if(tid != 0)
	clearTimeout(tid);
	tid = 0;
	if(select_state)
	autoScroll(e.pageX, e.pageY);
	return false;
}); */
	
$(document).on( "mouseup", function(e) {
	e.preventDefault();
	switch (e.which) {
	
	case 3://Right button
		select_state = false;
		break;        
	}
	return false;
});

$("body").on("contextmenu",function(e){
	e.preventDefault();
	return false;
});    

$("table.selectable-table").bind('selectstart dragstart', "td", function(e) {
  e.preventDefault();
  return false;
}); 
	
//<Right select end>


//<Sticky headers begin>
 $(".sticky-headers").on("scroll", function(e) {	
	e.preventDefault();
	updateStickyHeaders(this);
	return false;
});

var StickyHeaders = {};
function loadStickyHeaders()
{		
	var scroll_window = document.getElementsByClassName("sticky-headers");
	for(var i=0;i<scroll_window.length;i++)
	{
		var id = scroll_window[i].id;		
		StickyHeaders[id] = scroll_window[i].querySelectorAll("thead th");
	}		
}

var last_scrollV=-1;
function updateStickyHeaders(scroll_window)
{
	var scrollV = scroll_window.scrollTop; 
		
	if(last_scrollV != scrollV)
	{		
		last_scrollV = scrollV;
		var headers = StickyHeaders[scroll_window.id];
		for(var i=0; i<headers.length; i++)
		{
			headers[i].style.top = scrollV+"px";
		}
	}	
}
//<Sticky headers end>


//<Change value begin>
var changed_rows = [];
var first_prev_value=0;

$("table.selectable-table tbody").on( "focus", "td select", function(e) {
	first_prev_value = parseInt($(this).val());		
})
.on( "change", "td select", function(e) {	
	changeValue(this);
});
function changeValue(changed_select)
{
	var table_no = changed_select.parentElement.id.split("-")[1];
	var table = document.querySelector("table[table-no='"+table_no+"']");
	if(changed_select.parentElement.matches(".selected"))
	{
		var value = parseInt($(changed_select).val());		
		$(changed_select).val(first_prev_value);		
		
		
		var selected_cells = $(table).find("td.selected");		
		for(let cell of selected_cells)
		{		
			if(!$(cell).is(".disabled"))
				analyseChange(cell, value);			
		}			
	}
	else
	{			
		var cell = changed_select.parentElement;				
		var value = parseInt($(changed_select).val());		
		$(changed_select).val(first_prev_value);		
		
		if(!$(cell).is(".disabled"))
			analyseChange(cell, value);			
	}	
	
	$(changed_select).trigger( "focusout" );
	$(changed_select).trigger( "blur" );	
}
//<Change value end>



