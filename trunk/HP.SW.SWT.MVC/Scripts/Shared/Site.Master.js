function startWaiting() {
    $('#divWaiting').dialog('open');
}

function stopWaiting() {
    $('#divWaiting').dialog('close');
}

$(function () {
    $('#divWaiting').dialog({ autoOpen: false, title: 'Por favor espere...' });
});

function resize() {
    $("#mainBody").css("height", ($(window).height() - parseInt($("#mainHeader").css("height"))) + "px");
}

$(window).resize(function () {
    resize();
});

$(resize);
$("#mainHeader").ready(resize);
$("#mainHeaderLogo").ready(resize);

function toggleMenu(img) {
    var jMenu = $("#mainHeaderMenu");
    if (jMenu.css("display") == "none") {

        var jImg = $(img);
        var jImgPos = jImg.position();
        var jImgHeight = jImg.outerHeight();

        jMenu.css({
            top: (jImgPos.top + jImgHeight + 3) + "px",
            left: jImgPos.left + "px"
        }).show();
    } else {
        jMenu.hide();
    }
}
