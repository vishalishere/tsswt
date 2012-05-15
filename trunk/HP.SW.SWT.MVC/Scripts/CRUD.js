$(function () {
    $('#CRUDDialog').dialog({ autoOpen: false });
});

function onShowCRUDDialogOK(content) {
    $('#CRUDDialog').html(content);
    $('#CRUDDialog').dialog('open');
}

function showCRUDDialog(title, link) {
    $('#CRUDDialog').dialog('option', 'title', title);
    $.post(link, onShowCRUDDialogOK);
}
