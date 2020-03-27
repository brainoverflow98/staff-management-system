var TABLES = {};



function loadAllTables()
{
	for(let tableNo of Object.keys(TABLES))
	{		
		loadTable(tableNo, true);		
	}
	loadStickyHeaders();	
}

function loadTable(tableNo, loadHeaders=false)
{
	var TableObj = TABLES[tableNo];	
	var table = document.querySelector("table[table-no='"+tableNo+"']");
	// HEADER DATA
	if(loadHeaders)
	{
		for(var h=0; h<TableObj.headers.length; h++)
		{
			var row = document.createElement('tr');
			row.id = "t-"+tableNo+"-h-"+h;
			row.className = TableObj.headers[h].classes || "";
			for(var c=0; c<TableObj.headers[h].columns.length; c++)
			{
				var ColObj = TableObj.headers[h].columns[c];
				var col = document.createElement('th');
				col.id = "t-"+tableNo+"-h-c-"+c;
				col.className = ColObj.classes || "";
				var vertical = ColObj.vertical || false;
				if(vertical)
				{
					var span = document.createElement('span');
					span.className = "vertical";
					span.textContent = ColObj.value;
					col.appendChild(span);
				}
				else
				{
					col.textContent = ColObj.value;
				}		
				row.appendChild(col);
			}
			$(table).find("thead").html(row);
		}
	}
	// ROW DATA
	var tableBody = document.createDocumentFragment();
	var pageNo = TableObj.pageNo || 1;
	var perPage = TableObj.perPage || 25;
	var start = (pageNo-1) * perPage;
	var end = pageNo*perPage;
	if(end<=start)
		TableObj.pageNo = pageNo-1;
	for(var r=start; r<end; r++)
	{
		if(r >= TableObj.rows.length)
			break;
		
		var RowObj = TableObj.rows[r];
			
		if(RowObj.hidden)
		{
			end++;
			continue;
		}			
		var row = document.createElement('tr');
		row.id = "t-"+tableNo+"-r-"+r;
		row.className = RowObj.classes || "";
		if(RowObj.href)
			row.setAttribute("href",RowObj.href);
		for(var c=0; c<RowObj.columns.length; c++)
		{
			var ColObj = RowObj.columns[c];	
			var elem = "td";						
			if(ColObj.th)
			{
				elem = "th";
			}
			var col = document.createElement(elem);
			col.id = "t-"+tableNo+"-r-"+r+"-c-"+c;
			col.className = ColObj.classes || "";	
			if(ColObj.href)
				col.setAttribute("href",ColObj.href);
			
			if(ColObj.disabled)
			{
				col.classList.add("disabled");
			}
			if(ColObj.changed)
			{
				col.classList.add("changed");
			}
			if(ColObj.type.indexOf("poll") > -1)
			{
				var select = document.createElement('select');
				if(ColObj.disabled)
				{
					select.setAttribute("disabled","");
				}
				var options = TABLES[tableNo].optionGroups[0];
				
				for(let value of Object.keys(options))
				{
					
					var option = document.createElement('option');
					option.textContent = options[value].text;
					option.value = value;
					select.appendChild(option);
					if(value == ColObj.value)
					{
						col.style.backgroundColor = options[value].color;
						$(select).val(value);
					}
				}
				
				col.appendChild(select);
			}
			else
			{
				col.textContent = ColObj.value;
			}		
			row.appendChild(col);
		}
		tableBody.appendChild(row);	
	}
	$(table).find("tbody").html(tableBody);
}

// <Table Getters And Setters begin>
function cellAddValue(table_no, row_no, col_no, amount, count_limit, added_ammount)
{
    if (added_ammount == null)
        added_ammount = amount;
    table_no = parseInt(table_no);
	row_no = parseInt(row_no);
    col_no = parseInt(col_no);	
    var cellObj = TABLES[table_no].rows[row_no].columns[col_no];
	var cell = document.getElementById("t-"+table_no+"-r-"+row_no+"-c-"+col_no);	
    var value = parseInt(cellObj.value) || 0;
    var total = value + added_ammount;
    if (total > count_limit && count_limit > 0) {
        if(amount > 0)
            added_ammount = amount - (total - count_limit)
        else
            added_ammount = amount + (total - count_limit)
        total = count_limit;
    }        

    cell.textContent = total;
	
    cellObj.value = value + amount;

    return added_ammount;
}

function cellSetValue(table_no, row_no, col_no, value)
{
	table_no = parseInt(table_no);
	row_no = parseInt(row_no);
	col_no = parseInt(col_no);
	var cell = document.getElementById("t-"+table_no+"-r-"+row_no+"-c-"+col_no);	
	cell.textContent = (value).toString();
	
	TABLES[table_no].rows[row_no].columns[col_no].value = value;
}

function cellGetValue(table_no, row_no, col_no)
{
	table_no = parseInt(table_no);
	row_no = parseInt(row_no);
	col_no = parseInt(col_no);
	return TABLES[table_no].rows[row_no].columns[col_no].value;		
}

function cellGetUid(table_no, row_no, col_no)
{
	table_no = parseInt(table_no);
	row_no = parseInt(row_no);
	col_no = parseInt(col_no);
	return TABLES[table_no].rows[row_no].columns[col_no].uid;		
}

function getRowNo(table_no, uid)
{	
	var rows = TABLES[table_no].rows;
	for(var r=0; r<rows.length; r++)
	{			
		if(rows[r].uid == uid)
			return r;
	}
}

function getColNo(table_no, uid)
{
	var headers = TABLES[table_no].headers;	
	//console.log(header);
	for(var h=0; h<headers.length; h++)
	{
		for(var c=0; c<headers[h].columns.length; c++)
		{		
			if(headers[h].columns[c].uid == uid)
				return c;
		}	

	}
}
// <Table Getters And Setters end>