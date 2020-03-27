$(document).ready(function () {

    preparePage();

}); 

function preparePage()
{
	refreshTable(MonthlyTallyTableNo);	
}
 

$('#load-from-excel').on('click', function (e) {
    e.preventDefault();
    $('#excel-file').trigger("click");
});

$('#excel-file').on('change', function () {
    var fileExtension = ['xlsx'];
    var filename = $(this).val();
    if (filename.length == 0) {
        alert("Lütfen bir dosya seçin.");
        return false;
    }
    else {
        var extension = filename.replace(/^.*\./, '');
        if ($.inArray(extension, fileExtension) == -1) {
            alert("L�tfen '.xlsx' uzant�l� bir dosya se�in.");
            return false;
        }
    }
    var year = $(".year[table-no='" + MonthlyTallyTableNo + "']").val();
    var month = $(".month[table-no='" + MonthlyTallyTableNo + "']").val();
    $("#excel-year").val(year);
    $("#excel-month").val(month);
    $('#excel-form').submit();
});


//<Refresh begin>
function refreshTable(tableNo)
{
	var year = $(".year[table-no='"+tableNo+"']").val();
	var month = $(".month[table-no='"+tableNo+"']").val();
	
	refreshAjax(year, month);
		
	//console.log(TABLES);	
}

function refreshAjax(year, month)
{
	
	$.ajax({
	  method: "POST",
	  url: `/Puantaj/Monthly/${year}/${month}`,
	  contentType: "application/json",
	  dataType: 'json',
	  data: JSON.stringify({ "SortBy": "", "isSortAscending": false, "Page": 1, "PageSize": 1000, "filter": "" })
	})
	  .done(function( TableObj ) {		  
		  TABLES[MonthlyTallyTableNo] = TableObj; 
		  loadTable(MonthlyTallyTableNo, true);
		  if(TABLES[MonthSummaryTableNo])
		  updateConstants();
		  loadPageInfo();
		  loadStickyHeaders();
	  });
	  
	$.ajax({
	  method: "POST",
	  url: `/Puantaj/MonthSummary/${year}/${month}`,
	  contentType: "application/json",
	  dataType: 'json',
	  data: JSON.stringify({ "SortBy": "", "isSortAscending": false, "Page": 1, "PageSize": 1000, "filter": "" })
	})
        .done(function( TableObj ) {
          console.log(TableObj)
		  TABLES[MonthSummaryTableNo] = TableObj; 
		  loadTable(MonthSummaryTableNo, true);
		  if(TABLES[MonthlyTallyTableNo])
		  updateConstants();		  
	  });  
	  
}
//<Refresh end>


//<Get changes JSON begin>
function getChangesJSON(tableNo)
{
	var changes = [];
	var TableObj = TABLES[tableNo];
	for(var r=0; r<TableObj.rows.length; r++)
	{
		var RowObj = TableObj.rows[r];
		if(!RowObj.changed)
			continue;
		var change = { uid: RowObj.uid, cells:[] };
		for(var c=0; c<RowObj.columns.length; c++)
		{
			var ColObj = RowObj.columns[c];
			if(!ColObj.changed)
				continue;
			var cell = {};
			cell.date = ColObj.uid;
			cell.value = ColObj.value;
			change.cells.push(cell);
			ColObj.changed = false;
		}
		changes.push(change);
		RowObj.changed = false;
	}
	return changes;
	
}
//<Get changes JSON end>


//<AYLIK ÖZET İndir>



