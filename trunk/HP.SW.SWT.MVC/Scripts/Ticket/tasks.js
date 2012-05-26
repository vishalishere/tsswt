function optionsClick(img, task, first, last) {
    if ($("#rowOptions").css('display') != 'none' && $("#rowOptions").html().indexOf("DetailsTask/" + task) >= 0) {
        $("#rowOptions").hide();
    } else {
        showOptions(img, task, first, last);
    }
}

function showOptions(img, task, first, last) {
    $("#rowOptions").hide();
    var cell = $(img).closest("td");
    var cellPos = cell.position();
    var cellWidth = cell.outerWidth();
    var cellHeight = cell.outerHeight();
    $("#rowOptions").html($("#rowOptionsTemplate").html().replace(/TASKID/g, task));

    if (first) {
        $("#optionUp").hide();
    } else {
        $("#optionUp").show();
    }

    if (last) {
        $("#optionDown").hide();
    } else {
        $("#optionDown").show();
    }

    $("#rowOptions").css({
        top: (cellPos.top + cellHeight + 2) + "px",
        left: (cellPos.left + cellWidth + 2 - $("#rowOptions").outerWidth()) + "px"
    }).show();
}

function showMenuImage(cell) {
    $(cell).find("table").css("border", "solid 1px Gray");
    $(cell).find('img').css('visibility', '');
}

function hideMenuImage(cell) {
    $(cell).find("table").css("border", "none 0px White");
    $(cell).find('img').css('visibility', 'hidden');
}
