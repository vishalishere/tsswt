var tbExcel;
var imgOkTemplate;
var imgCancelTemplate;
var imgDeleteTemplate;
var isRowUnderEdition;
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

    row.cells[0].innerHTML = '<label>' + getDayString(now) + '</label><input type="hidden" value="-1" />';
    
    row.cells[1].innerHTML = getHourString(now);
    row.cells[7].innerHTML = 'No'
    row.cells[11].style.display = 'none';    
    row.cells[12].innerHTML = "<img src='" + imgOkTemplate + "' onclick='okRow(this);' style='cursor:pointer' alt='grabar' />&nbsp;&nbsp;"
		        + "<img src='" + imgCancelTemplate + "' onclick='cancelRow(this);' style='cursor:pointer' alt='cancelar' />&nbsp;&nbsp;"
		        + "<img src='" + imgDeleteTemplate + "' onclick='deleteRow(this);' style='cursor:pointer' alt='borrar' />";

    row.cells[12].style.display = 'none';
    
    addRow(row);

    return true;
}

function closeTask(checkErrors) {
    if (tbExcel.rows.length > 1) {
        var closingRow = tbExcel.rows[1];

        var now = new Date();
        if (closingRow.cells[1].innerHTML == getHourString(now)) {
            alert('Todavía no pasó un minuto. Cambie los datos en la tarea actual.');
            return false;
        }

        if (closingRow.cells[2].innerHTML == '') {
            closingRow.cells[2].innerHTML = getHourString(now);

            okRow(closingRow);
        } else {  //no está vacío: tiene control input
            if (checkErrors) {
                alert('La tarea ya está cerrada.');
            }
            else if($(closingRow.cells[2]).find("input").length > 0 && $(closingRow.cells[2]).find("input").val() == ''){
                $(closingRow.cells[2]).find("input").val(getHourString(now));
            }
        }

        if (!calcHours(closingRow.cells[2]) && checkErrors) {
            return false;
        }
    } else {
        if (checkErrors) {
            alert('No hay tarea para cerrar.');
        }
    }
    if (isRowUnderEdition) {
        uneditRow(closingRow);
        isRowUnderEdition = false;
    }
    return true;
}

var editingRow;
function editRow(row) {
    if (editingRow != null) {
        uneditRow(editingRow);
    }
    isRowUnderEdition = true;
    editingRow = row;
    editingRow.onclick = null;
    var rowHTML = row.innerHTML;

    row.cells[1].innerHTML = '<input type="text" style="width:40px; text-align: right" value="' + row.cells[1].innerHTML + '" onblur="return calcHours(this);"></input>';
    row.cells[2].innerHTML = '<input type="text" style="width:40px; text-align: right" value="' + row.cells[2].innerHTML + '" onblur="return calcHours(this);"></input>';
    row.cells[4].innerHTML = '<input type="text" style="width:100px" value="' + row.cells[4].innerHTML + '"></input>';
    row.cells[5].innerHTML = '<textarea rows="2" style="width:200px" value="' + row.cells[5].innerHTML + '"></textarea>';
    row.cells[6].innerHTML = '<input type="text" style="width:50px" value="' + row.cells[6].innerHTML + '"></input>';
    row.cells[7].innerHTML = '<input type="radio" name="HourCharged" value="1"' + (row.cells[7].innerHTML == 'Si' ? 'checked' : '') + '>Si&nbsp;'
        + '<input type="radio" name="HourCharged" value="0"' + (row.cells[7].innerHTML == 'No' ? 'checked' : '') + '>No';
    row.cells[8].innerHTML = '<input type="text" style="width:40px; text-align: right" value="' + row.cells[8].innerHTML + '"></input>';
    row.cells[9].innerHTML = '<input type="text" style="width:100px" value="' + row.cells[9].innerHTML + '"></input>';
    row.cells[10].innerHTML = '<input type="text" style="width:100px" value="' + row.cells[10].innerHTML + '"></input>';

    row.cells[11].innerHTML = '<input type="hidden"></input>';
    $(row.cells[11]).find("input").val(rowHTML);

    row.cells[12].style.display = '';
}

function uneditRow(row) {
    //var rowHTML = row.cells[11].innerHTML;

    row.cells[1].innerHTML = $(row.cells[1]).find("input").val();
    row.cells[2].innerHTML = $(row.cells[2]).find("input").val();
    row.cells[4].innerHTML = ($(row.cells[4]).find("input").val() == undefined ? '' : $(row.cells[4]).find("input").val());  //$(row.cells[4]).find("input").val();
    row.cells[5].innerHTML = ($(row.cells[5]).find("input").val() == undefined ? '' : $(row.cells[5]).find("input").val());  //$(row.cells[5]).find("input").val();
    row.cells[6].innerHTML = ($(row.cells[6]).find("input").val() == undefined ? '' : $(row.cells[6]).find("input").val());  //$(row.cells[6]).find("input").val();
    row.cells[7].innerHTML = ($(row.cells[7]).find('input:checked').val() == "1" ? 'Si' : 'No');
    row.cells[8].innerHTML = ($(row.cells[8]).find("input").val() == undefined ? '' : $(row.cells[8]).find("input").val());  //$(row.cells[8]).find("input").val();
    row.cells[9].innerHTML = ($(row.cells[9]).find("input").val() == undefined ? '' : $(row.cells[9]).find("input").val());  //$(row.cells[9]).find("input").val();
    row.cells[10].innerHTML = ($(row.cells[10]).find("input").val() == undefined ? '' : $(row.cells[10]).find("input").val());  //$(row.cells[10]).find("input").val();
    row.cells[11].innerHTML = '';
    //row.cells[12].style.display = rowHTML == row.innerHTML ? 'none' : '';
    row.cells[12].style.display = 'none';

    row.onclick = function () { editRow(row); };

    editingRow = null;
    isRowUnderEdition = false;
}

function getExcelRow(row) {
    $('#rowIndex').val(row.rowIndex);
    $('#Id').val($(row.cells[0]).find("input").val());
    $('#Date').val($(row.cells[0]).find("label").text() + '/' + new Date().getFullYear());
    $('#StartHour').val($(row.cells[1]).find("input").length == 0 ? row.cells[1].innerHTML : $(row.cells[1]).find("input").val());
    $('#EndHour').val($(row.cells[2]).find("input").length == 0 ? row.cells[2].innerHTML : $(row.cells[2]).find("input").val());
    $('#Ticket').val($(row.cells[4]).find("input").length == 0 ? row.cells[4].innerHTML : $(row.cells[4]).find("input").val());
    $('#Description').val($(row.cells[5]).find("textarea").length == 0 ? row.cells[5].innerHTML : $(row.cells[5]).find("textarea").val());
    $('#SCPCharged').val($(row.cells[6]).find("input").length == 0 ? row.cells[6].innerHTML : $(row.cells[6]).find("input").val());
    $('#SCPHours').val($(row.cells[7]).find("input").length == 0 ? row.cells[7].innerHTML : $(row.cells[7]).find("input").val());
    $('#SCPTicket').val($(row.cells[8]).find("input").length == 0 ? row.cells[8].innerHTML : $(row.cells[8]).find("input").val());
    $('#SCPT').val($(row.cells[9]).find("input").length == 0 ? row.cells[9].innerHTML : $(row.cells[9]).find("input").val());

    return $('#form1').serialize();
}

function onOkRow(res) {
    if (res.result == "Ok") {
        $(tbExcel.rows[res.data.rowIndex].cells[0]).find("input").val(res.data.id);
        stopWaiting();
    } else {
        stopWaiting();
        alert(res.message);
    }
}

function okRow(src) {
    startWaiting();
    var row = src;
    if (row.nodeName == 'IMG') {
        row = $(row).closest('tr')[0];
    }

    $.post(root('/Resource/UpdateExcelRow'),
        getExcelRow(row),
        onOkRow,
        'json');
}

function onAddRow(res) {
    if (res.result == "Ok") {
        $(tbExcel.rows[res.data.rowIndex].cells[0]).find("input").val(res.data.id);
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
        onAddRow,
            'json');    
}

function cancelRow(src) {
    var row = src;
    if (row.nodeName == 'IMG') {
        row = $(row).closest('tr')[0];
    }
    var rowHTML = $(row.cells[11]).find('input').val();

    $(row).find("td").each(function (index, el) {
        row.cells[index].innerHTML = el.innerHTML;
    });
    row.style = "vertical-align:top";
    row.onclick = function () { editRow(row); };
}

function onDeleteRow(res) {
    if (res.result == "Ok") {
        tbExcel.deleteRow(res.data.rowIndex);
        stopWaiting();
    } else {
        stopWaiting();
        alert(res.message);
    }
}

function deleteRow(src) {
    var row = src;
    if (row.nodeName == 'IMG') {
        row = $(row).closest('tr')[0];
    }

    $.post(root('/Resource/DeleteExcelRow'),
            getExcelRow(row),
        onDeleteRow,
        'json');   
}

function isValidHour(h) {
    var hs = h.split(':');

    if (hs.length != 2) {
        return false;
    }

    if (isNaN(hs[0]) || isNaN(hs[1])) {
        return false;
    }
    var hour = Number(hs[0]);
    var minute = Number(hs[1]);

    if (hour < 0 || hour > 23) {
        return false;
    }

    if (minute < 0 || minute > 59) {
        return false;
    }

    return true;
}

function calcHours(input) {
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
        if (isValidHour(initHour) && isValidHour(endHour)) {
            initHour = initHour.split(':');
            endHour = endHour.split(':');

            initHour = initHour[0] * 60 + Number(initHour[1]);
            endHour = endHour[0] * 60 + Number(endHour[1]);

            if (initHour >= endHour) {
                alert('La hora de fin debe ser superior a la hora de inicio.');
                return false;
            }

            row.cells[3].innerHTML = getHourString(new Date((endHour - initHour + 3 *60 /*El +3 compensa el -3 de la hora de Argentina*/) * 60 * 1000));
        } else {
            alert('Una de las horas es inválida. Corrija el valor.');
            return false;
        }
    }
    return true;
}

function convertStringToBoolean(stringValue) {
    var result;

    if (stringValue == "1") {
        result = true;
    }
    else {
        result = false;
    }
    return result;
}


$(function () {
    tbExcel = document.getElementById('tbExcel');
    imgOkTemplate = document.getElementById('imgOkTemplate').src;
    imgCancelTemplate = document.getElementById('imgCancelTemplate').src;
    imgDeleteTemplate = document.getElementById('imgDeleteTemplate').src;
});