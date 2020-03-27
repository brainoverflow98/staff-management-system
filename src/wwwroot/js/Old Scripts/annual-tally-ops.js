function preparePage()
{
	refreshTable(3);		
}



function updateConstants()
{
	 AnnualTallyTableGorevCol = getColNo(AnnualTallyTableNo, "gorev");
	 AnnualTallyTableCalismaGunuCol = getColNo(AnnualTallyTableNo, "calismagunu");
	 AnnualTallyTableHaftaTatiliCol = getColNo(AnnualTallyTableNo, "haftatatili");
	 AnnualTallyTableResmiTatilCol = getColNo(AnnualTallyTableNo, "resmitatil");
	 AnnualTallyTableYillikIzinCol = getColNo(AnnualTallyTableNo, "yillikizin");
	 AnnualTallyTableOdenecekRaporCol = getColNo(AnnualTallyTableNo, "odenecekrapor");
	 AnnualTallyTableDogumIzniCol = getColNo(AnnualTallyTableNo, "dogumizni");
	 AnnualTallyTableOlumIzniCol = getColNo(AnnualTallyTableNo, "olumizni");
	 AnnualTallyTableEvlilikIzniCol = getColNo(AnnualTallyTableNo, "evlilikizni");
	 AnnualTallyTableOdenmeyecekRaporCol = getColNo(AnnualTallyTableNo, "odenmeyecekrapor");
	 AnnualTallyTableUcretsizIzinCol = getColNo(AnnualTallyTableNo, "ucretsizizin");
	 AnnualTallyTableDevamsizlikCol = getColNo(AnnualTallyTableNo, "devamsizlik");
	 AnnualTallyTableSigortaGunCol = getColNo(AnnualTallyTableNo, "sigortagun");
	 AnnualTallyTableYemekGunCol = getColNo(AnnualTallyTableNo, "yemekgun");
	 AnnualTallyTableYolGunCol = getColNo(AnnualTallyTableNo, "yolgun");
	 AnnualTallyTableSorumlulukGunCol = getColNo(AnnualTallyTableNo, "sorumlulukgun");
	 AnnualTallyTableGeceCalismaCol = getColNo(AnnualTallyTableNo, "gececalisma");
	 AnnualTallyTableSaatMesaiCol = getColNo(AnnualTallyTableNo, "saatmesai");	 
}


// Cell Value Functions Begin
var AnnualTallyTableNo = "3";

var AnnualTallyTableGorevCol = "2";
var AnnualTallyTableCalismaGunuCol = "37";
var AnnualTallyTableHaftaTatiliCol = "38";
var AnnualTallyTableResmiTatilCol = "39";
var AnnualTallyTableYillikIzinCol = "40";
var AnnualTallyTableOdenecekRaporCol = "41";
var AnnualTallyTableDogumIzniCol = "42";
var AnnualTallyTableOlumIzniCol = "43";
var AnnualTallyTableEvlilikIzniCol = "44";
var AnnualTallyTableOdenmeyecekRaporCol = "45";
var AnnualTallyTableUcretsizIzinCol = "46";
var AnnualTallyTableDevamsizlikCol = "47";
var AnnualTallyTableSigortaGunCol = "48";
var AnnualTallyTableYemekGunCol = "49";
var AnnualTallyTableYolGunCol = "50";
var AnnualTallyTableSorumlulukGunCol = "51";
var AnnualTallyTableGeceCalismaCol = "52";
var AnnualTallyTableSaatMesaiCol = "53";


//<Save employee changes begin>
$("button[function='submit']").click(function (e) {
    e.preventDefault();
    var me = $(this);

    // Ask for the user confirmation with the given confirmation message.
    var message = "Değişiklikler kaydedilecek !";
    if (!confirm(message)) {
        return
    }
    if (me.data('requestRunning')) {
        return;
    }
    me.data('requestRunning', true);

    var formId = me.attr("form-id");

    var dataObject = new FormData();

    $(":input[form-id='" + formId + "'][data-for*='submit']").each(function (i, formInput) {
        if ($(formInput).attr("type") == "file") {
            var files = formInput.files;
            for (var i = 0; i < files.length; i++) {
                dataObject.append($(formInput).prop("name"), files[i]);
            }
        }
        else if ($(formInput).attr("type") == "checkbox" || $(formInput).attr("type") == "radio") {
            dataObject.append($(formInput).prop("name"), $(formInput).prop("checked"));
        }
        else {
            dataObject.append($(formInput).prop("name"), $(formInput).prop("value"));
        }
    });

    var method = me.attr("method");
    var action = me.attr("action");
    var redirectUrl = me.attr("redirect-url");

    $.ajax({
        type: method,
        url: action,
        contentType: false,
        processData: false,
        data: dataObject,
        dataType: "json"        
    })
	.done(function(  ) {		  
		 alert("Değişiklikler Kaydedildi");
	  })
    .fail(function(  ) {		  
	     alert("Bir hata oluştu !");
    })
	.always(function(  ) {		  
	     me.data('requestRunning', false);
    });
});
//<Save employee changes end>


//<Refresh begin>
function refreshTable(tableNo)
{
	var year = $(".year[table-no='"+tableNo+"']").val();	
	var personelId = window.location.href.split("/").pop();
	
	refreshAjax(personelId, year);
		
		
}

function refreshAjax(personelId, year)
{
	
	$.ajax({
	  method: "POST",
	  url: `/Puantaj/Annual/${personelId}/${year}`,
	  contentType: "application/json",
	  dataType: 'json'
	})
	  .done(function( TableObj ) {
		  console.log(TableObj);
		  
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
	var changes = []
	var TableObj = TABLES[tableNo];
	var personelId = TableObj.uid.split("-")[0];
	var change = { uid: personelId, cells:[] };
	for(var r=0; r<TableObj.rows.length; r++)
	{
		var RowObj = TableObj.rows[r];
		if(!RowObj.changed)
			continue;
		
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
		RowObj.changed = false;
	}
	changes.push(change);
	return changes;
	
}
//<Get changes JSON end>



// Cell Value Functions End

function analyseChange(cell, value)
{
	var select = cell.children[0];	
	var prev_value = parseInt($(select).val());
		
	if(value == prev_value)
		return;
	
	var row_no = cell.id.split("-")[3];
	var col_no = cell.id.split("-")[5];
		
	$(select).val(value);	
	var table_no = AnnualTallyTableNo;	
	var duty = document.getElementById("Gorevi").value;
	var pv = prev_value;
	var v = value;	

	
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
			cellAddValue(table_no, row_no, AnnualTallyTableCalismaGunuCol, 1);
			cellAddValue(table_no, row_no, AnnualTallyTableYemekGunCol, 1);			
			cellAddValue(table_no, row_no, AnnualTallyTableYolGunCol, 1);			
			if(duty== Sofor || duty== Operator)
			{
				cellAddValue(table_no, row_no, AnnualTallyTableSorumlulukGunCol, 1);				
			}
		}
	}
	else
	{
		if(pv==1 || pv==2 || pv==3 || pv==4 || pv==5)
		{
			cellAddValue(table_no, row_no, AnnualTallyTableCalismaGunuCol, -1);
			cellAddValue(table_no, row_no, AnnualTallyTableYemekGunCol, -1);			
			cellAddValue(table_no, row_no, AnnualTallyTableYolGunCol, -1);
			if(duty=="şoför" || duty=="operatör")
			{
				cellAddValue(table_no, row_no, AnnualTallyTableSorumlulukGunCol, -1);
			}
		}
	}
	if(v==1 || v==2 || v==3 || v==4 || v==5 || v==6 || v==8 || v==9 
	|| v==11 || v==13 || v==14 || v==15 || v==16 || v==17)
	{
		if(pv!=1 && pv!=2 && pv!=3 && pv!=4 && pv!=5 && pv!=6 && pv!=8 && pv!=9 
		&& pv!=11 && pv!=13 && pv!=14 && pv!=15 && pv!=16 && pv!=17)
		{
			cellAddValue(table_no, row_no, AnnualTallyTableSigortaGunCol, 1);
		}
	}
	else
	{
		if(pv==1 || pv==2 || pv==3 || pv==4 || pv==5 || pv==6 || pv==8 || pv==9 
		|| pv==11 || pv==13 || pv==14 || pv==15 || pv==16 || pv==17)
		{
			cellAddValue(table_no, row_no, AnnualTallyTableSigortaGunCol, -1);
		}
	}
	
	if(v==6)
	{
		if(pv!=6)
		{
			cellAddValue(table_no, row_no, AnnualTallyTableHaftaTatiliCol, 1);
		}
	}
	else
	{
		if(pv==6)
		{
			cellAddValue(table_no, row_no, AnnualTallyTableHaftaTatiliCol, -1);
		}
	}
	
	if(v==14)
	{
		if(pv!=14)
		{
			cellAddValue(table_no, row_no, AnnualTallyTableResmiTatilCol, 1);
		}
	}
	else
	{
		if(pv==14)
		{
			cellAddValue(table_no, row_no, AnnualTallyTableResmiTatilCol, -1);
		}
	}
	
	if(v==8)
	{
		if(pv!=8)
		{
			cellAddValue(table_no, row_no, AnnualTallyTableYillikIzinCol, 1);
		}
	}
	else
	{
		if(pv==8)
		{
			cellAddValue(table_no, row_no, AnnualTallyTableYillikIzinCol, -1);
		}
	}
	
	
	if(v==11)
	{
		if(pv!=11)
		{
			cellAddValue(table_no, row_no, AnnualTallyTableOdenecekRaporCol, 1);
		}
	}
	else
	{
		if(pv==11)
		{
			cellAddValue(table_no, row_no, AnnualTallyTableOdenecekRaporCol, -1);
		}
	}
	
	
	if(v==15)
	{
		if(pv!=15)
		{
			cellAddValue(table_no, row_no, AnnualTallyTableDogumIzniCol, 1);
		}
	}
	else
	{
		if(pv==15)
		{
			cellAddValue(table_no, row_no, AnnualTallyTableDogumIzniCol, -1);
		}
	}
	
	
	if(v==17)
	{
		if(pv!=17)
		{
			cellAddValue(table_no, row_no, AnnualTallyTableOlumIzniCol, 1);
		}
	}
	else
	{
		if(pv==17)
		{
			cellAddValue(table_no, row_no, AnnualTallyTableOlumIzniCol, -1);
		}
	}
	
	if(v==16)
	{
		if(pv!=16)
		{
			cellAddValue(table_no, row_no, AnnualTallyTableEvlilikIzniCol, 1);
		}
	}
	else
	{
		if(pv==16)
		{
			cellAddValue(table_no, row_no, AnnualTallyTableEvlilikIzniCol, -1);
		}
	}
	
	
	if(v==12)
	{
		if(pv!=12)
		{
			cellAddValue(table_no, row_no, AnnualTallyTableOdenmeyecekRaporCol, 1);
		}
	}
	else
	{
		if(pv==12)
		{
			cellAddValue(table_no, row_no, AnnualTallyTableOdenmeyecekRaporCol, -1);
		}
	}	
	
	
	if(v==10)
	{
		if(pv!=10)
		{
			cellAddValue(table_no, row_no, AnnualTallyTableUcretsizIzinCol, 1);
		}
	}
	else
	{
		if(pv==10)
		{
			cellAddValue(table_no, row_no, AnnualTallyTableUcretsizIzinCol, -1);
		}
	}
	
	
	if(v==7)
	{
		if(pv!=7)
		{
			cellAddValue(table_no, row_no, AnnualTallyTableDevamsizlikCol, 1);
		}
	}
	else
	{
		if(pv==7)
		{
			cellAddValue(table_no, row_no, AnnualTallyTableDevamsizlikCol, -1);
		}
	}
	
	
	if(v==5)
	{
		if(pv!=5)
		{
			cellAddValue(table_no, row_no, AnnualTallyTableGeceCalismaCol, 1);
		}
	}
	else
	{
		if(pv==5)
		{
			cellAddValue(table_no, row_no, AnnualTallyTableGeceCalismaCol, -1);
		}
	}
	
	if(v==2)
	{
		if(pv!=2)
		{
			cellAddValue(table_no, row_no, AnnualTallyTableSaatMesaiCol, 1);
		}
	}
	else
	{
		if(pv==2)
		{
			cellAddValue(table_no, row_no, AnnualTallyTableSaatMesaiCol, -1);
		}
	}
	
	
	if(v==3)
	{
		if(pv!=3)
		{
			cellAddValue(table_no, row_no, AnnualTallyTableSaatMesaiCol, 2);
		}
	}
	else
	{
		if(pv==3)
		{
			cellAddValue(table_no, row_no, AnnualTallyTableSaatMesaiCol, -2);
		}
	}
	
	
	if(v==4)
	{
		if(pv!=4)
		{
			cellAddValue(table_no, row_no, AnnualTallyTableSaatMesaiCol, 3);
		}
	}
	else
	{
		if(pv==4)
		{
			cellAddValue(table_no, row_no, AnnualTallyTableSaatMesaiCol, -3);
		}
	}
} 

