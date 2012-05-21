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

function showMenuImage(row) {
    $(row).find('img').css('visibility', '');
}

function hideMenuImage(row) {
    $(row).find('img').css('visibility', 'hidden');
}
