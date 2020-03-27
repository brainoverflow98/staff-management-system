function preparePage()
{
	refreshTable(1);	
	refreshTable(2);
}



function updateConstants()
{
	 MonthlyTallyTableGorevCol = getColNo(MonthlyTallyTableNo, "gorev");
	 MonthlyTallyTableCalismaGunuCol = getColNo(MonthlyTallyTableNo, "calismagunu");
	 MonthlyTallyTableHaftaTatiliCol = getColNo(MonthlyTallyTableNo, "haftatatili");
	 MonthlyTallyTableResmiTatilCol = getColNo(MonthlyTallyTableNo, "resmitatil");
	 MonthlyTallyTableYillikIzinCol = getColNo(MonthlyTallyTableNo, "yillikizin");
	 MonthlyTallyTableOdenecekRaporCol = getColNo(MonthlyTallyTableNo, "odenecekrapor");
	 MonthlyTallyTableDogumIzniCol = getColNo(MonthlyTallyTableNo, "dogumizni");
	 MonthlyTallyTableOlumIzniCol = getColNo(MonthlyTallyTableNo, "olumizni");
	 MonthlyTallyTableEvlilikIzniCol = getColNo(MonthlyTallyTableNo, "evlilikizni");
	 MonthlyTallyTableOdenmeyecekRaporCol = getColNo(MonthlyTallyTableNo, "odenmeyecekrapor");
	 MonthlyTallyTableUcretsizIzinCol = getColNo(MonthlyTallyTableNo, "ucretsizizin");
	 MonthlyTallyTableDevamsizlikCol = getColNo(MonthlyTallyTableNo, "devamsizlik");
	 MonthlyTallyTableSigortaGunCol = getColNo(MonthlyTallyTableNo, "sigortagun");
	 MonthlyTallyTableYemekGunCol = getColNo(MonthlyTallyTableNo, "yemekgun");
	 MonthlyTallyTableYolGunCol = getColNo(MonthlyTallyTableNo, "yolgun");
	 MonthlyTallyTableSorumlulukGunCol = getColNo(MonthlyTallyTableNo, "sorumlulukgun");
	 MonthlyTallyTableGeceCalismaCol = getColNo(MonthlyTallyTableNo, "gececalisma");
	 MonthlyTallyTableSaatMesaiCol = getColNo(MonthlyTallyTableNo, "saatmesai");
	
	 MonthSummaryTableSigortaGunCol = getColNo(MonthSummaryTableNo, "sigortagun");
	 MonthSummaryTableUBGTCol = getColNo(MonthSummaryTableNo, "ubgt");
	 MonthSummaryTableMesaiSaatiCol = getColNo(MonthSummaryTableNo, "mesaisaati");
	 MonthSummaryTableGeceVardiyasiCol = getColNo(MonthSummaryTableNo, "gecediyasi");
	 MonthSummaryTableYemekGunCol = getColNo(MonthSummaryTableNo, "yemekgun");
	 MonthSummaryTableYolGunCol = getColNo(MonthSummaryTableNo, "yolgun");
	 MonthSummaryTableSorumlulukGunCol = getColNo(MonthSummaryTableNo, "sorumlulukgun");	
	
	
	 MonthSummaryTableAmirRow = getRowNo(MonthSummaryTableNo, Amir);
	 MonthSummaryTableSefRow = getRowNo(MonthSummaryTableNo, Sef);
	 MonthSummaryTableHIGrvRow = getRowNo(MonthSummaryTableNo, HIGrv);
	 MonthSummaryTableOperatorRow = getRowNo(MonthSummaryTableNo, Operator);
	 MonthSummaryTableVasifliRow = getRowNo(MonthSummaryTableNo, Vasifli);
	 MonthSummaryTableSoforRow = getRowNo(MonthSummaryTableNo, Sofor);
	 MonthSummaryTableCavusRow = getRowNo(MonthSummaryTableNo, Cavus);
	 MonthSummaryTableYukleyiciRow = getRowNo(MonthSummaryTableNo, Yukleyici);
	 MonthSummaryTableCamiTmzRow = getRowNo(MonthSummaryTableNo, CamiTmz);
	 MonthSummaryTableGAIsciRow = getRowNo(MonthSummaryTableNo, GAIsci);
	 MonthSummaryTableToplamRow = getRowNo(MonthSummaryTableNo, Toplam);
}


// Cell Value Functions Begin
var MonthlyTallyTableNo = "1";

var MonthlyTallyTableGorevCol = "2";
var MonthlyTallyTableCalismaGunuCol = "37";
var MonthlyTallyTableHaftaTatiliCol = "38";
var MonthlyTallyTableResmiTatilCol = "39";
var MonthlyTallyTableYillikIzinCol = "40";
var MonthlyTallyTableOdenecekRaporCol = "41";
var MonthlyTallyTableDogumIzniCol = "42";
var MonthlyTallyTableOlumIzniCol = "43";
var MonthlyTallyTableEvlilikIzniCol = "44";
var MonthlyTallyTableOdenmeyecekRaporCol = "45";
var MonthlyTallyTableUcretsizIzinCol = "46";
var MonthlyTallyTableDevamsizlikCol = "47";
var MonthlyTallyTableSigortaGunCol = "48";
var MonthlyTallyTableYemekGunCol = "49";
var MonthlyTallyTableYolGunCol = "50";
var MonthlyTallyTableSorumlulukGunCol = "51";
var MonthlyTallyTableGeceCalismaCol = "52";
var MonthlyTallyTableSaatMesaiCol = "53";


var MonthSummaryTableNo = "2";

var MonthSummaryTableSigortaGunCol = "2";
var MonthSummaryTableUBGTCol = "3";
var MonthSummaryTableMesaiSaatiCol = "4";
var MonthSummaryTableGeceVardiyasiCol = "5";
var MonthSummaryTableYemekGunCol = "6";
var MonthSummaryTableYolGunCol = "7";
var MonthSummaryTableSorumlulukGunCol = "8";

var MonthSummaryTableAmirRow = "2";
var MonthSummaryTableSefRow = "3";
var MonthSummaryTableHIGrvRow = "4";
var MonthSummaryTableOperatorRow = "5";
var MonthSummaryTableVasifliRow = "6";
var MonthSummaryTableSoforRow = "7";
var MonthSummaryTableCavusRow = "8";
var MonthSummaryTableYukleyiciRow = "9";
var MonthSummaryTableCamiTmzRow = "10";
var MonthSummaryTableGAIsciRow = "11";
var MonthSummaryTableToplamRow = "12";

function getMonthSummaryTableDutyRow(duty)
{		
	switch(duty)
	{
		case Amir:
			return MonthSummaryTableAmirRow;
		break;
		case Sef:
			return MonthSummaryTableSefRow;
		break;
		case HIGrv:			
			return MonthSummaryTableHIGrvRow;
		break;
		case Operator:
			return MonthSummaryTableOperatorRow;
		break;
		case Vasifli:
			return MonthSummaryTableVasifliRow;
		break;
		case Sofor:
			return MonthSummaryTableSoforRow;
		break;
		case Cavus:
			return MonthSummaryTableCavusRow;
		break;
		case Yukleyici:
			return MonthSummaryTableYukleyiciRow;
		break;
		case CamiTmz:
			return MonthSummaryTableCamiTmzRow;
		break;
		case GAIsci:
			return MonthSummaryTableGAIsciRow;
		break;
	}	
}
// Cell Value Functions End


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
		  var tableNo = TableObj.tableNo;
		  TABLES[tableNo] = TableObj; 
		  loadTable(tableNo, true);
		  updateConstants();
		  loadPageInfo();
	  });
	  
	  $.ajax({
	  method: "POST",
	  url: `/Puantaj/MonthSummary/${year}/${month}`,
	  contentType: "application/json",
	  dataType: 'json',
	  data: JSON.stringify({ "SortBy": "", "isSortAscending": false, "Page": 1, "PageSize": 1000, "filter": "" })
	})
	  .done(function( TableObj ) {		  
		  var tableNo = TableObj.tableNo;
		  TABLES[tableNo] = TableObj; 
		  loadTable(tableNo, true);
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

function analyseChange(cell, value)
{
	var select = cell.children[0];	
	var prev_value = parseInt($(select).val());
		
	if(value == prev_value)
		return;
	
	var row_no = cell.id.split("-")[3];
	var col_no = cell.id.split("-")[5];
	var duty = cellGetUid(MonthlyTallyTableNo, row_no, MonthlyTallyTableGorevCol);			
		
	var table_no = MonthlyTallyTableNo;
	var sum_table_no = MonthSummaryTableNo;
	var duty_row = getMonthSummaryTableDutyRow(duty);
	var pv = prev_value;
	var v = value;		
		
	$(select).val(value);
	var RowObj = TABLES[table_no].rows[row_no];
	var ColObj = RowObj.columns[col_no];
	ColObj.value = value;
	ColObj.changed = true;
	RowObj.changed = true;
		
	var optionGroup = ColObj.optionGroup;
	var option = TABLES[table_no].optionGroups[optionGroup][value];
	var color = option.color; 	
	cell.style.backgroundColor = color;	
	cell.classList.add("changed");

	
	if(v==1 || v==2 || v==3 || v==4 || v==5)
	{
		if(pv!=1 && pv!=2 && pv!=3 && pv!=4 && pv!=5)
		{
			cellAddValue(table_no, row_no, MonthlyTallyTableCalismaGunuCol, 1);
			cellAddValue(table_no, row_no, MonthlyTallyTableYemekGunCol, 1);
			cellAddValue(sum_table_no, duty_row, MonthSummaryTableYemekGunCol, 1);
			cellAddValue(sum_table_no, MonthSummaryTableToplamRow, MonthSummaryTableYemekGunCol, 1);
			cellAddValue(table_no, row_no, MonthlyTallyTableYolGunCol, 1);
			cellAddValue(sum_table_no, duty_row, MonthSummaryTableYolGunCol, 1);
			cellAddValue(sum_table_no, MonthSummaryTableToplamRow, MonthSummaryTableYolGunCol, 1);
			if(duty== Sofor || duty== Operator)
			{
				cellAddValue(table_no, row_no, MonthlyTallyTableSorumlulukGunCol, 1);
				cellAddValue(sum_table_no, duty_row, MonthSummaryTableSorumlulukGunCol, 1);
				cellAddValue(sum_table_no, MonthSummaryTableToplamRow, MonthSummaryTableSorumlulukGunCol, 1);
			}
		}
	}
	else
	{
		if(pv==1 || pv==2 || pv==3 || pv==4 || pv==5)
		{
			cellAddValue(table_no, row_no, MonthlyTallyTableCalismaGunuCol, -1);
			cellAddValue(table_no, row_no, MonthlyTallyTableYemekGunCol, -1);
			cellAddValue(sum_table_no, duty_row, MonthSummaryTableYemekGunCol, -1);
			cellAddValue(sum_table_no, MonthSummaryTableToplamRow, MonthSummaryTableYemekGunCol, -1);
			cellAddValue(table_no, row_no, MonthlyTallyTableYolGunCol, -1);
			cellAddValue(sum_table_no, duty_row, MonthSummaryTableYolGunCol, -1);
			cellAddValue(sum_table_no, MonthSummaryTableToplamRow, MonthSummaryTableYolGunCol, -1);
			if(duty== Sofor || duty== Operator)
			{
				cellAddValue(table_no, row_no, MonthlyTallyTableSorumlulukGunCol, -1);
				cellAddValue(sum_table_no, duty_row, MonthSummaryTableSorumlulukGunCol, -1);
				cellAddValue(sum_table_no, MonthSummaryTableToplamRow, MonthSummaryTableSorumlulukGunCol, -1);
			}
		}
	}
	if(v==1 || v==2 || v==3 || v==4 || v==5 || v==6 || v==8 || v==9 
	|| v==11 || v==13 || v==14 || v==15 || v==16 || v==17)
	{
		if(pv!=1 && pv!=2 && pv!=3 && pv!=4 && pv!=5 && pv!=6 && pv!=8 && pv!=9 
		&& pv!=11 && pv!=13 && pv!=14 && pv!=15 && pv!=16 && pv!=17)
		{
			cellAddValue(table_no, row_no, MonthlyTallyTableSigortaGunCol, 1);
			cellAddValue(sum_table_no, duty_row, MonthSummaryTableSigortaGunCol, 1);
			cellAddValue(sum_table_no, MonthSummaryTableToplamRow, MonthSummaryTableSigortaGunCol, 1);
		}
	}
	else
	{
		if(pv==1 || pv==2 || pv==3 || pv==4 || pv==5 || pv==6 || pv==8 || pv==9 
		|| pv==11 || pv==13 || pv==14 || pv==15 || pv==16 || pv==17)
		{
			cellAddValue(table_no, row_no, MonthlyTallyTableSigortaGunCol, -1);
			cellAddValue(sum_table_no, duty_row, MonthSummaryTableSigortaGunCol, -1);
			cellAddValue(sum_table_no, MonthSummaryTableToplamRow, MonthSummaryTableSigortaGunCol, -1);
		}
	}
	
	if(v==6)
	{
		if(pv!=6)
		{
			cellAddValue(table_no, row_no, MonthlyTallyTableHaftaTatiliCol, 1);
		}
	}
	else
	{
		if(pv==6)
		{
			cellAddValue(table_no, row_no, MonthlyTallyTableHaftaTatiliCol, -1);
		}
	}
	
	if(v==14)
	{
		if(pv!=14)
		{
			cellAddValue(table_no, row_no, MonthlyTallyTableResmiTatilCol, 1);
			cellAddValue(sum_table_no, duty_row, MonthSummaryTableUBGTCol, 1);
			cellAddValue(sum_table_no, MonthSummaryTableToplamRow, MonthSummaryTableUBGTCol, 1);
		}
	}
	else
	{
		if(pv==14)
		{
			cellAddValue(table_no, row_no, MonthlyTallyTableResmiTatilCol, -1);
			cellAddValue(sum_table_no, duty_row, MonthSummaryTableUBGTCol, -1);
			cellAddValue(sum_table_no, MonthSummaryTableToplamRow, MonthSummaryTableUBGTCol, -1);
		}
	}
	
	if(v==8)
	{
		if(pv!=8)
		{
			cellAddValue(table_no, row_no, MonthlyTallyTableYillikIzinCol, 1);
		}
	}
	else
	{
		if(pv==8)
		{
			cellAddValue(table_no, row_no, MonthlyTallyTableYillikIzinCol, -1);
		}
	}
	
	
	if(v==11)
	{
		if(pv!=11)
		{
			cellAddValue(table_no, row_no, MonthlyTallyTableOdenecekRaporCol, 1);
		}
	}
	else
	{
		if(pv==11)
		{
			cellAddValue(table_no, row_no, MonthlyTallyTableOdenecekRaporCol, -1);
		}
	}
	
	
	if(v==15)
	{
		if(pv!=15)
		{
			cellAddValue(table_no, row_no, MonthlyTallyTableDogumIzniCol, 1);
		}
	}
	else
	{
		if(pv==15)
		{
			cellAddValue(table_no, row_no, MonthlyTallyTableDogumIzniCol, -1);
		}
	}
	
	
	if(v==17)
	{
		if(pv!=17)
		{
			cellAddValue(table_no, row_no, MonthlyTallyTableOlumIzniCol, 1);
		}
	}
	else
	{
		if(pv==17)
		{
			cellAddValue(table_no, row_no, MonthlyTallyTableOlumIzniCol, -1);
		}
	}
	
	if(v==16)
	{
		if(pv!=16)
		{
			cellAddValue(table_no, row_no, MonthlyTallyTableEvlilikIzniCol, 1);
		}
	}
	else
	{
		if(pv==16)
		{
			cellAddValue(table_no, row_no, MonthlyTallyTableEvlilikIzniCol, -1);
		}
	}
	
	
	if(v==12)
	{
		if(pv!=12)
		{
			cellAddValue(table_no, row_no, MonthlyTallyTableOdenmeyecekRaporCol, 1);
		}
	}
	else
	{
		if(pv==12)
		{
			cellAddValue(table_no, row_no, MonthlyTallyTableOdenmeyecekRaporCol, -1);
		}
	}	
	
	
	if(v==10)
	{
		if(pv!=10)
		{
			cellAddValue(table_no, row_no, MonthlyTallyTableUcretsizIzinCol, 1);
		}
	}
	else
	{
		if(pv==10)
		{
			cellAddValue(table_no, row_no, MonthlyTallyTableUcretsizIzinCol, -1);
		}
	}
	
	
	if(v==7)
	{
		if(pv!=7)
		{
			cellAddValue(table_no, row_no, MonthlyTallyTableDevamsizlikCol, 1);
		}
	}
	else
	{
		if(pv==7)
		{
			cellAddValue(table_no, row_no, MonthlyTallyTableDevamsizlikCol, -1);
		}
	}
	
	
	if(v==5)
	{
		if(pv!=5)
		{
			cellAddValue(table_no, row_no, MonthlyTallyTableGeceCalismaCol, 1);
		cellAddValue(sum_table_no, duty_row, MonthSummaryTableGeceVardiyasiCol, 1);
		cellAddValue(sum_table_no, MonthSummaryTableToplamRow, MonthSummaryTableGeceVardiyasiCol, 1);
		}
	}
	else
	{
		if(pv==5)
		{
			cellAddValue(table_no, row_no, MonthlyTallyTableGeceCalismaCol, -1);
			cellAddValue(sum_table_no, duty_row, MonthSummaryTableGeceVardiyasiCol, -1);
			cellAddValue(sum_table_no, MonthSummaryTableToplamRow, MonthSummaryTableGeceVardiyasiCol, -1);
		}
	}
	
	if(v==2)
	{
		if(pv!=2)
		{
			cellAddValue(table_no, row_no, MonthlyTallyTableSaatMesaiCol, 1);
			cellAddValue(sum_table_no, duty_row, MonthSummaryTableMesaiSaatiCol, 1);
			cellAddValue(sum_table_no, MonthSummaryTableToplamRow, MonthSummaryTableMesaiSaatiCol, 1);
		}
	}
	else
	{
		if(pv==2)
		{
			cellAddValue(table_no, row_no, MonthlyTallyTableSaatMesaiCol, -1);
			cellAddValue(sum_table_no, duty_row, MonthSummaryTableMesaiSaatiCol, -1);
			cellAddValue(sum_table_no, MonthSummaryTableToplamRow, MonthSummaryTableMesaiSaatiCol, -1);
		}
	}
	
	
	if(v==3)
	{
		if(pv!=3)
		{
			cellAddValue(table_no, row_no, MonthlyTallyTableSaatMesaiCol, 2);
			cellAddValue(sum_table_no, duty_row, MonthSummaryTableMesaiSaatiCol, 2);
			cellAddValue(sum_table_no, MonthSummaryTableToplamRow, MonthSummaryTableMesaiSaatiCol, 2);
		}
	}
	else
	{
		if(pv==3)
		{
			cellAddValue(table_no, row_no, MonthlyTallyTableSaatMesaiCol, -2);
			cellAddValue(sum_table_no, duty_row, MonthSummaryTableMesaiSaatiCol, -2);
			cellAddValue(sum_table_no, MonthSummaryTableToplamRow, MonthSummaryTableMesaiSaatiCol, -2);
		}
	}
	
	
	if(v==4)
	{
		if(pv!=4)
		{
			cellAddValue(table_no, row_no, MonthlyTallyTableSaatMesaiCol, 3);
			cellAddValue(sum_table_no, duty_row, MonthSummaryTableMesaiSaatiCol, 3);
			cellAddValue(sum_table_no, MonthSummaryTableToplamRow, MonthSummaryTableMesaiSaatiCol, 3);
		}
	}
	else
	{
		if(pv==4)
		{
			cellAddValue(table_no, row_no, MonthlyTallyTableSaatMesaiCol, -3);
			cellAddValue(sum_table_no, duty_row, MonthSummaryTableMesaiSaatiCol, -3);
			cellAddValue(sum_table_no, MonthSummaryTableToplamRow, MonthSummaryTableMesaiSaatiCol, -3);
		}
	}
} 

