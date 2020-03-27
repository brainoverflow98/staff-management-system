$(document).ready(function () {

    preparePage();   

});
$('.btnYazdir').on('click', function (e) {
    var aciklamaTable = document.getElementById('glossary-scroll-window')
    aciklamaTable.className='collapse'
    var height =  document.getElementById('Adres').style.height;
    document.getElementById('Adres').style.height='100px';

    window.print()
    document.getElementById('Adres').style.height = height;
});

function preparePage()
{
	refreshTable(AnnualTallyTableNo);		
}
function printDiv(divName) {

    var printContents = document.getElementById(divName).innerHTML;
    w = window.open();

    w.document.write(printContents);
    w.document.write('<scr' + 'ipt type="text/javascript">' + 'window.onload = function() { window.print(); window.close(); };' + '</sc' + 'ript>');

    w.document.close(); // necessary for IE >= 10
    w.focus(); // necessary for IE >= 10

    return true;
}

$('#delete-button').on('click', function (e) {
    e.preventDefault();
    var message = "Personel kalıcı olarak silinecek !";
    if (confirm(message)) {
        $('#delete-form').submit();
    }
});

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
            alert("Lütfen '.xlsx' uzantılı bir dosya seçin.");
            return false;
        }
    }
    $('#excel-form').submit();
});


$('#upload-photo').on('click', function (e) {
    e.preventDefault();
    $('#file-input').trigger("click");
});

$('#file-input').on('change', function () {
    var input = this;
    if (input.files && input.files[0]) {
        var reader = new FileReader();
        reader.onload = function (e) {
            $('#employee-photo')
                .attr('src', e.target.result);
        };
        reader.readAsDataURL(input.files[0]);
    }
});


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
    $('#btnGuncelle').prop('disabled',true)
    $('#btnGuncelle').text('Kaydediliyor...');
    $.ajax({
        type: method,
        url: action,
        contentType: false,
        processData: false,
        data: dataObject,
        dataType: "json"        
    })
	.done(function( res ) {
         console.log(res)
         alert(res.sonuc)	    
         $('#btnGuncelle').prop('disabled',false)
         $('#btnGuncelle').text('Kaydet');
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
		  TABLES[AnnualTallyTableNo] = TableObj; 
          loadTable(AnnualTallyTableNo, true);
          var firstCell = document.getElementById("t-3-h-c-0")
          firstCell.innerHTML = year
          console.log(firstCell)
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

$('#file-input').change(function(e){
    console.log(e)
})