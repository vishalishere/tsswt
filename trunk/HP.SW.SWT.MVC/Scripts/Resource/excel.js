var tbExcel;
var imgDeleteTemplate;
var imgDateTemplate;
var imgTimeTemplate;
var lastSavedRows;

function backupSavedRows() {
    lastSavedRows = new Array();

    for (var i = 1; i < tbExcel.rows.length; i++) {
        lastSavedRows[i] = getExcelRow(tbExcel.rows[i]);
    }
}

function newTask() {

    if (!closeTask(false)) {
        return false;
    }

    var now = new Date();
    var row = tbExcel.insertRow(1);
    row.style = "vertical-align:top";
    row.onclick = function () { editRow(row); };

    for (var i = 0; i < 13; i++) {
        row.insertCell(i);
    }

    row.cells[0].innerHTML = getDayString(now);
    row.cells[1].innerHTML = getHourString(now);
    row.cells[7].innerHTML = 'No'
    row.cells[11].style.display = 'none';    
    row.cells[12].innerHTML = "<img src='" + imgDeleteTemplate + "' onclick='deleteRow(this);' style='cursor:pointer' alt='borrar' />";
    
    addRow(row);

    return true;
}

function closeTask(checkErrors) {
    if (tbExcel.rows.length > 1) {
        var closingRow = tbExcel.rows[1];
        uneditRow(closingRow);

        var now = new Date();
        if (closingRow.cells[1].innerHTML == getHourString(now)) {
            alert('Todavía no pasó un minuto. Cambie los datos en la tarea actual.');
            return false;
        }

        if (closingRow.cells[2].innerHTML == '') {
            closingRow.cells[2].innerHTML = getHourString(now);
        } else {  //no está vacío: tiene control input
            if (checkErrors) {
                alert('La tarea ya está cerrada.');
            }
            else if($(closingRow.cells[2]).find("input").length > 0 && $(closingRow.cells[2]).find("input").val() == ''){
                $(closingRow.cells[2]).find("input").val(getHourString(now));
            }
        }

        if (!calcHours('', closingRow.cells[2]) && checkErrors) {
            return false;
        }
    } else {
        if (checkErrors) {
            alert('No hay tarea para cerrar.');
        }
    }

    return true;
}

function editRow(row) {

    if ($(row.cells[0]).find('input').length == 0) {
        row.cells[0].innerHTML = '<input type="text" style="width:70px; text-align: center" value="' + row.cells[0].innerHTML + '" />';
        row.cells[1].innerHTML = '<input type="text" style="width:40px; text-align: center" value="' + row.cells[1].innerHTML + '" readonly="readonly" /><img id="btn_tmp_1_' + row.rowIndex + '" src="' + imgTimeTemplate + '" style="cursor:pointer" alt="Hora desde" />';
        row.cells[2].innerHTML = '<input type="text" style="width:40px; text-align: center" value="' + row.cells[2].innerHTML + '" readonly="readonly" /><img id="btn_tmp_2_' + row.rowIndex + '" src="' + imgTimeTemplate + '" style="cursor:pointer" alt="Hora hasta" />';
        row.cells[4].innerHTML = '<input type="text" style="width:100px" value="' + row.cells[4].innerHTML + '"></input>';
        row.cells[5].innerHTML = '<textarea rows="2" style="width:200px">' + row.cells[5].innerHTML + '</textarea>';
        row.cells[6].innerHTML = '<input type="text" style="width:50px" value="' + row.cells[6].innerHTML + '"></input>';
        row.cells[7].innerHTML = '<input type="radio" name="HourCharged" value="1"' + (row.cells[7].innerHTML == 'Si' ? 'checked' : '') + '>Si&nbsp;'
        + '<input type="radio" name="HourCharged" value="0"' + (row.cells[7].innerHTML == 'No' ? 'checked' : '') + '>No';
        row.cells[8].innerHTML = '<input type="text" style="width:40px; text-align: right" value="' + row.cells[8].innerHTML + '"></input>';
        row.cells[9].innerHTML = '<input type="text" style="width:100px" value="' + row.cells[9].innerHTML + '"></input>';
        row.cells[10].innerHTML = '<input type="text" style="width:100px" value="' + row.cells[10].innerHTML + '"></input>';

        $(row.cells[0]).find('input').datepicker({
            buttonImage: imgDateTemplate,
            buttonImageOnly: true,
            dateFormat: 'dd/mm',
            showOn: 'button'
        });
        $(row.cells[1]).find('input').timepicker({
            button: '#btn_tmp_1_' + row.rowIndex,
            hourText: 'Hora',
            minuteText: 'Minuto', 
            minutes: { starts: 0, ends: 59, interval: 1 },
            onSelect: calcHours,
            rows: 12,
            showOn: 'button',
            showPeriodLabels: false
        });
        $(row.cells[2]).find('input').timepicker({
            button: '#btn_tmp_2_' + row.rowIndex,
            hourText: 'Hora',
            minuteText: 'Minuto',
            minutes: { starts: 0, ends: 59, interval: 1 },
            onSelect: calcHours,
            rows: 12,
            showOn: 'button',
            showPeriodLabels: false
        });
    }
}

function uneditRow(row) {
    if ($(row.cells[0]).find('input').length > 0) {
        row.cells[0].innerHTML = $(row.cells[0]).find("input").val();
        row.cells[1].innerHTML = $(row.cells[1]).find("input").val();
        row.cells[2].innerHTML = $(row.cells[2]).find("input").val();
        row.cells[4].innerHTML = $(row.cells[4]).find("input").val();
        row.cells[5].innerHTML = $(row.cells[5]).find("textarea").val();
        row.cells[6].innerHTML = $(row.cells[6]).find("input").val();
        row.cells[7].innerHTML = $(row.cells[7]).find('input:checked').val() == "1" ? 'Si' : 'No';
        row.cells[8].innerHTML = $(row.cells[8]).find("input").val();
        row.cells[9].innerHTML = $(row.cells[9]).find("input").val();
        row.cells[10].innerHTML = $(row.cells[10]).find("input").val();
    }
}

function getExcelRow(row) {
    uneditRow(row);

    $('#rowIndex').val(row.rowIndex);
    $('#Id').val(row.cells[11].innerHTML);
    $('#Date').val(row.cells[0].innerHTML + '/' + new Date().getFullYear());
    $('#StartHour').val(row.cells[1].innerHTML);
    $('#EndHour').val(row.cells[2].innerHTML);
    $('#Ticket').val(row.cells[4].innerHTML);
    $('#Description').val(row.cells[5].innerHTML);
    $('#SCPCharged').val(row.cells[7].innerHTML == "Si" ? 1 : 0);
    $('#SCPHours').val(row.cells[8].innerHTML);
//    $('#SCPTicket').val(row.cells[9].innerHTML);
    $('#SCPT').val(row.cells[10].innerHTML);

    return $('#form1').serialize();
}

function onSaveOK(res) {
    if (res.result == "Ok") {
        for (var i = 0; i < res.data.length; i++) {
            tbExcel.rows[res.data[i].rowIndex].cells[11].innerHTML = res.data[i].id;
        }
        backupSavedRows();
        stopWaiting();        
    } else {
        stopWaiting();
        alert(res.message);
    }
}

function save(rows) {
    startWaiting();
    var serialization = '';
    var currentRow;
    var j = 0;
    for (var i = 1; i < rows.length; i++) {
        if (rows[i].nodeName == 'IMG') {
            rows[i] = $(rows[i]).closest('tr')[0];
        }

        currentRow = getExcelRow(rows[i]);
        if (currentRow != lastSavedRows[i]) {
            serialization = serialization + '[' + j + '].' + currentRow.replace(/&/g, '&[' + j + '].') + '&';
            j++;
        }
    }

    if (serialization != '') {
        $.post(root('/Resource/UpdateExcelRows'),
            serialization,
            onSaveOK,
            'json');
    }
}

function btnSaveClientClick() {
    save(tbExcel.rows);
}

function onAddRowOK(res) {
    if (res.result == "Ok") {
        tbExcel.rows[res.data.rowIndex].cells[11].innerHTML = res.data.id;
        backupSavedRows();
        stopWaiting();
    } else {
        stopWaiting();
        alert(res.message);
    }
}

function addRow(row) {
    startWaiting();
    $.post(root('/Resource/AddExcelRow'),
        getExcelRow(row),
        onAddRowOK,
        'json');    
}

function onDeleteRowOK(res) {
    if (res.result == "Ok") {
        tbExcel.deleteRow(res.data.rowIndex);
        stopWaiting();
    } else {
        stopWaiting();
        alert(res.message);
    }
}

function deleteRow(src) {
    startWaiting();
    var row = src;
    if (row.nodeName == 'IMG') {
        row = $(row).closest('tr')[0];
    }

    $.post(root('/Resource/DeleteExcelRow'),
        getExcelRow(row),
        onDeleteRowOK,
        'json');   
}

function calcHours(value, timePkr) {
    var input = timePkr.input || timePkr;
    var row = $(input).closest('tr')[0];   
    var initHour;
    var endHour;
    if ($(row.cells[1]).find("input").length > 0) {
        initHour = $(row.cells[1]).find("input")[0].value;
    }
    else {
        initHour = row.cells[1].innerHTML;
    }
    if ($(row.cells[2]).find("input").length > 0) {
        endHour = $(row.cells[2]).find("input")[0].value;
    }
    else { 
        endHour = row.cells[2].innerHTML;
    }

    if (initHour == '' || endHour == '') {
        row.cells[3].innerHTML = '';
    } else {
        initHour = initHour.split(':');
        endHour = endHour.split(':');

        initHour = initHour[0] * 60 + Number(initHour[1]);
        endHour = endHour[0] * 60 + Number(endHour[1]);

        if (initHour >= endHour) {
            $(input).val(timePkr.lastVal || '');
            calcHours('', timePkr);
            
            alert('La hora de fin debe ser superior a la hora de inicio.');
            return false;
        }

        row.cells[3].innerHTML = getHourString(new Date((endHour - initHour + 3 *60 /*El +3 compensa el -3 de la hora de Argentina*/) * 60 * 1000));
    }
    return true;
}

$(function () {
    tbExcel = document.getElementById('tbExcel');
    imgDeleteTemplate = document.getElementById('imgDeleteTemplate').src;
    imgDateTemplate = document.getElementById('imgDateTemplate').src;
    imgTimeTemplate = document.getElementById('imgTimeTemplate').src;
    backupSavedRows();
});