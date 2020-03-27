$(document).ready(function () {

    preparePage();

}); 

function preparePage()
{
	refreshTable(EmployeeListTableNo);			
}


//<Refresh begin>
function refreshTable(tableNo)
{
	var filter = $("#filter").val();
	
	refreshAjax(filter);
		
	//console.log(TABLES);	
}

function refreshAjax(filter)
{
	
	$.ajax({
	  method: "POST",
	  url: `/Personel/EmployeeList/${filter}`,
	  contentType: "application/json",
	  dataType: 'json',
	  data: JSON.stringify({ "SortBy": "", "isSortAscending": false, "Page": 1, "PageSize": 1000, "filter": "" })
	})
	  .done(function( TableObj ) {
		  TABLES[EmployeeListTableNo] = TableObj; 
		  loadTable(EmployeeListTableNo, true);		  
		  loadPageInfo();
		  loadStickyHeaders();
	  });
	  
	  $.ajax({
	  method: "POST",
	  url: `/Personel/EmployeeListSummary/${filter}`,
	  contentType: "application/json",
	  dataType: 'json'
	})
	  .done(function( TableObj ) {
			console.log("özet",TableObj)			  
		  TABLES[EmployeeListSummaryTableNo] = TableObj; 
		  loadTable(EmployeeListSummaryTableNo, true);			  		  
	  });  
	  
}
//<Refresh end>