$(function () {
    $('#dashboardReport').dialog({ autoOpen: false });
    $('#excelView').dialog({ autoOpen: false });
});

function onShowExcelViewOK(content) {
    $('#excelView').html(content);
    $('#excelView').dialog('open');
}

function showExcelView(title, link) {
    $('#excelView').dialog('option', 'title', title);
    $("#excelView").dialog('option', 'width', $(window).width() * 0.9);
    $("#excelView").dialog('option', 'height', $(window).height() * 0.5);

    $.post(link, onShowExcelViewOK);
}

function onShowDashboardReportOK(content) {
    $('#dashboardReport').html(content);
    $('#dashboardReport').dialog('open');
}

function showDashboardReport(title, link) {
    $('#dashboardReport').dialog('option', 'title', title);

    $.post(link, onShowDashboardReportOK);
}
