$(function () {
    $('#divDetails').dialog({ autoOpen: false });
});

function onShowDetailsOK(content) {
    $('#divDetails').html(content);
    stopWaiting();
    $('#divDetails').dialog('open');
}

function showDetails(title, link) {
    startWaiting();
    $('#divDetails').dialog('option', 'title', title);
    $('#divDetails').dialog('option', 'width', '600px');

    $.post(link, onShowDetailsOK);
}
