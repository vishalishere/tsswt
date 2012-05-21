function hideAllOptions() {
    $("#rowOptions").hide();
    $("#columnNumberOptions").hide();
    $("#columnClusterOptions").hide();
    $("#columnStartDateOptions").hide();
    $("#columnDeliveryDateOptions").hide();
    $("#columnDonePercentageOptions").hide();
    $("#columnEstimatedHoursOptions").hide();
}

function showColumnOptions(img, col) {
    hideAllOptions();
    $("#column" + col + "Options").show();
}

function rowOptionsClick(img, ticket) {
    if ($("#rowOptions").css('display') != 'none' && $("#rowOptions").html().indexOf(ticket) >= 0) {
        hideAllOptions();
    } else {
        showRowOptions(img, ticket);
    }
}

function showRowOptions(img, ticket) {
    hideAllOptions();
    var cell = $(img).closest("td");
    var cellPos = cell.position();
    var cellWidth = cell.outerWidth();
    var cellHeight = cell.outerHeight();
    $("#rowOptions").html($("#rowOptionsTemplate").html().replace(/TICKETNUMBER/g, ticket));
    $("#rowOptions").css({
        top: (cellPos.top + cellHeight + 2) + "px",
        left: (cellPos.left + cellWidth + 2 - $("#rowOptions").outerWidth()) + "px"
    }).show();
}

function showColumnMenuImage(cell) {
    $(cell).find("table").css("background-color", "LightGray");
    $(cell).find("table").css("color", "White");
    $(cell).find("td").css("border", "solid 1px LightGray");
    $(cell).find('img').css('visibility', '');
}

function hideColumnMenuImage(cell) {
    $(cell).find("table").css("background-color", "");
    $(cell).find("table").css("color", "");
    $(cell).find("td").css("border", "");
    $(cell).find('img').css('visibility', 'hidden');
}

function showRowMenuImage(cell) {
    $(cell).find("table").css("border", "solid 1px Gray");
    $(cell).find('img').css('visibility', '');
}

function hideRowMenuImage(cell) {
    $(cell).find("table").css("border", "none 0px White");
    $(cell).find('img').css('visibility', 'hidden');
}

function previous_page() { 
}

function next_page() {
}
