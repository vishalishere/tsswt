var imgCanvasInfo = null;
function drawCluster(ctx, x, y, ticket) {
	if (imgCanvasInfo == null) {
		imgCanvasInfo = document.getElementById('imgCanvasInfo');
    }
    var left = 0;
    if (ticket.Cluster == 'HR') {
        left = 0;
    } else if (ticket.Cluster == 'MC') {
        left = 1;
    } else if (ticket.Cluster == 'MI') {
        left = 2;
    } else if (ticket.Cluster == 'QST') {
        left = 3;
    } else if (ticket.Cluster == 'TMC') {
        left = 4;
	}
    ctx.drawImage(imgCanvasInfo, 71 * left, 0, 71, 71, x, y, 71, 71);
}

function drawConsumedHours(ctx, x, y, ticket) {
    var fcst = ticket.ConsumedHoursForecast / ticket.EstimatedHours;

    ctx.fillStyle = "green";
    ctx.strokeStyle = "green";
    drawEllipse(ctx, x + 35, y + 35, 26, 34, Math.PI * (-0.5), Math.PI * (fcst * 2 - 0.5));

    if (fcst > 1) {
        ctx.fillStyle = "yellow";
        ctx.strokeStyle = "yellow";
        drawEllipse(ctx, x + 35, y + 35, 26, 34, Math.PI * (-0.5), Math.PI * ((fcst - 1) * 2 - 0.5));
    }

    if (fcst > 1.2) {
        ctx.fillStyle = "red";
        ctx.strokeStyle = "red";
        drawEllipse(ctx, x + 35, y + 35, 26, 34, Math.PI * (-0.1), Math.PI * ((fcst - 1) * 2 - 0.5));
    }
}

function drawTicketNumber(ctx, x, y, ticket) {
	ctx.font = "8pt Calibri";
	ctx.fillStyle = "black";  
	ctx.strokeStyle = "black";
	ctx.fillText(ticket.Number, x, y + 50); 
}

function drawDonePercentage(ctx, x, y, ticket) {
    ctx.fillStyle = "black";
    ctx.strokeStyle = "black";
    ctx.strokeRect(x + 77, y, 10, 70);
    ctx.fillRect(x + 77, y + 70 - (70 * ticket.DonePercentage / 100), 10, (70 * ticket.DonePercentage / 100));
}

function getDeliveryColor(date, delivDate, dly2days) {
    if (date.getMonth() * 100 + date.getDate() <= delivDate.getMonth() * 100 + delivDate.getDate()) {
        return "green";
    } else if (date.getMonth() * 100 + date.getDate() <= dly2days.getMonth() * 100 + dly2days.getDate()) {
        return "yellow";
    } else {
        return "red";
    }
}

function drawDeliveryDay(ctx, x, y, d, startDate, delivDate, dly2days, delivDateFcst) {

    // Comparo MMDD >= MMDD para saber si ya tengo que empezar a dibujar.
    if (d.getMonth() * 100 + d.getDate() < startDate.getMonth() * 100 + startDate.getDate()) {
        ctx.fillStyle = "black";
        ctx.strokeStyle = "black";
        ctx.strokeRect(x, y, 80, 0);
        ctx.strokeRect(x, y + 20, 80, 0);
    } else {
        ctx.fillStyle = getDeliveryColor(d, delivDate, dly2days);
        ctx.strokeStyle = getDeliveryColor(d, delivDate, dly2days);

        var from, to;
        // Se hace para obtener el slot si es el día de inicio.
        if (d.getMonth() * 100 + d.getDate() == startDate.getMonth() * 100 + startDate.getDate()) {
            from = getDaySlot(startDate);
        } else {
            from = 0;
        }

        if (d.getMonth() * 100 + d.getDate() < delivDateFcst.getMonth() * 100 + delivDateFcst.getDate()) {
            to = 16;
        } else if (d.getMonth() * 100 + d.getDate() == delivDateFcst.getMonth() * 100 + delivDateFcst.getDate()) {
            to = getDaySlot(delivDateFcst);
        } else {
            to = 0;
        }

        // Si no se dibuja consumo dentro, no dibujo los cuadros.
        if (to == 0 && from == 0) {
            ctx.strokeRect(x, y, 80, 0);
            ctx.strokeRect(x, y + 20, 80, 0);
        } else {
            for (var j = 0; j < 8; j++) {
                ctx.strokeRect(x + j * 10, y, 10, 20);
            }
        }

        for (var i = from; i < to; i++) {
            if (i % 2 == 0) {
                ctx.fillRect(x + i * 5 + 1, y + 1, 4, 18);
            } else {
                ctx.fillRect(x + i * 5, y + 1, 4, 18);
            }
        }
    }
}

function drawDeliveryDate(ctx, x, y, ticket) {

    //    StartDate
    //    DeliveryDate,
    //    DeliveryDateForecast

    var d = $("#dashboardDate").datepicker('getDate');
    var startDate = new Date(parseInt(ticket.StartDate.substr(6)));
    var delivDate = ticket.DeliveryDate == null ? new Date(parseInt(ticket.DeliveryDateForecast.substr(6))) : new Date(parseInt(ticket.DeliveryDate.substr(6)));
    var delivDateFcst = ticket.DeliveryDateForecast == null ? new Date(parseInt(ticket.DeliveryDate.substr(6))) : new Date(parseInt(ticket.DeliveryDateForecast.substr(6)));

    var dly2days = delivDate;
    
    var i = 0;
    while (i < 3) {
        dly2days = daysForward(dly2days, 1);

        if (isWorkingDay(dly2days)) {
            i++;
        }
    }

    if (delivDateFcst.getMonth() * 100 + delivDateFcst.getDate() < d.getMonth() * 100 + d.getDate()) {
        ctx.font = "10pt Calibri";
        ctx.strokeStyle = "black";
        ctx.fillStyle = "black";

        ctx.fillText(getDayString(delivDateFcst), 105, y + 40);

        ctx.fillStyle = getDeliveryColor(delivDateFcst, delivDate, dly2days);

        ctx.beginPath();
        ctx.lineWidth = 2;
        ctx.arc(145, y + 36, 4, 0, Math.PI * 2, true);
        ctx.closePath();
        ctx.stroke();
        ctx.fill();
        ctx.lineWidth = 1;
    }

	var left = 100;
	while (left < 900) {
	    if (isWorkingDay(d)) {

	        drawDeliveryDay(ctx, left, y + 25, d, startDate, delivDate, dly2days, delivDateFcst)

	        left += 80;
	    }

	    d = daysForward(d, 1);
	}

    if (d.getMonth() * 100 + d.getDate() < delivDateFcst.getMonth() * 100 + delivDateFcst.getDate()) {
        ctx.font = "10pt Calibri";
        ctx.strokeStyle = "black";
        ctx.fillStyle = "black";

        ctx.fillText(getDayString(delivDateFcst), 855, y + 40);

        ctx.fillStyle = getDeliveryColor(delivDateFcst, delivDate, dly2days);

        ctx.beginPath();
        ctx.lineWidth = 2; 
        ctx.arc(894, y + 36, 4, 0, Math.PI * 2, true);
        ctx.closePath();
        ctx.stroke();
        ctx.fill();
        ctx.lineWidth = 1;
    }
}

function drawTicket(ctx, ticket, index) {

    var x = 7;
    var y  = 15 + index * 75;

	drawCluster(ctx, x, y, ticket);
	drawConsumedHours(ctx, x, y, ticket);
	drawTicketNumber(ctx, x, y, ticket);
	drawDonePercentage(ctx, x, y, ticket);
	drawDeliveryDate(ctx, x, y, ticket);
}

function drawHeader(ctx) {

	ctx.font = "12pt Calibri";
	ctx.fillStyle = "black";  
	ctx.strokeStyle = "black";

	var d = $("#dashboardDate").datepicker('getDate');
	var now = (new Date()).getMonth() * 100 + (new Date()).getDate();

	var left = 100;
	while (left < 900) {
	    if (isWorkingDay(d)) {
	        ctx.beginPath();

	        ctx.fillStyle = "black";
	        ctx.strokeStyle = "black";

	        ctx.moveTo(left, 0);
	        ctx.lineTo(left, cnvHeight);
	        ctx.stroke();
	        ctx.closePath();

	        if (now == d.getMonth() * 100 + d.getDate()) {

	            ctx.beginPath();
	            ctx.fillStyle = "blue";
	            ctx.strokeStyle = "blue";
	            ctx.lineWidth = 2;

	            ctx.strokeRect(left + 16, 6, 46, 18);

	            ctx.moveTo(left + 39, 25);
	            ctx.lineTo(left + 39, cnvHeight);
	            ctx.stroke();
	            ctx.closePath();
	        }

	        ctx.fillText(getDayString(d), left + 20, 20);

	        left += 80;
	    } else {
	        if (now == d.getMonth() * 100 + d.getDate()) {

	            ctx.beginPath();
	            ctx.fillStyle = "blue";
	            ctx.strokeStyle = "blue";
	            ctx.lineWidth = 2;

	            ctx.strokeRect(left + 16, 6, 46, 18);

	            ctx.moveTo(left + 39, 25);
	            ctx.lineTo(left + 39, cnvHeight);
	            ctx.stroke();
	            ctx.closePath();
	        }
	    }

        d = daysForward(d, 1);
	}
}

var cnvHeight = 730;
function drawCanvas(tickets) {

    cnvHeight = Math.max(15 + tickets.length * 75, 730);
    canvas.setAttribute('height', cnvHeight + 'px');

    ctx = canvas.getContext("2d");
    ctx.clearRect(0, 0, 900, cnvHeight);
    for (var i = 0; i < tickets.length; i++) {
        drawTicket(ctx, tickets[i], i);
    }

    drawHeader(ctx);
}

var canvas;
var ctx;
function reloadDashboard() {
    canvas = document.getElementById('cnvTrackingTool');
    ctx = canvas.getContext('2d');

    ctx.clearRect(0, 0, 1000, cnvHeight);
    ctx.font = "12pt Calibri";
    ctx.fillStyle = "black";
    ctx.strokeStyle = "black";
    ctx.fillText('Loading... please wait...', 20, 20);
    ctx.stroke();

    $.post(root('/Home/GetDashboardTickets'), { order: $('#dashboardOrder').val(), cluster: $('#dashboardCluster').val() }, drawCanvas, 'json');
}

var tbAssigHtml = '<thead><tr style="border-bottom: solid 2px black"><th>Recurso</th><th>Ticket</th></tr></thead><tbody></tbody>';
function postReloadAssignments(as) {

    $('#resourceAssignment').html(tbAssigHtml);

    $.each(as, function (i, a) {
        $('#resourceAssignment > tbody:last').after('<tr><td style="text-align: left;">' + a.Resource + '</td><td>' + a.Ticket + '</td></tr>');
    });
}

function reloadAssignments() {

    $('#resourceAssignment').html(tbAssigHtml);
    $('#resourceAssignment > tbody:last').after('<tr style="text-align: center;"><td colspan="2">Loading... please wait...</td></tr>');

    //function( url, data, callback, type ) {
    $.post(root('/Resource/GetCurrentAssignments'), postReloadAssignments, 'json');
}

$(function () {
    $.datepicker.setDefaults(
        $.extend(
            { 'dateFormat': 'dd/mm/yy' },
            $.datepicker.regional['es'])
    );

    $("#dashboardDate").datepicker({ onClose: reloadDashboard });
    $("#dashboardDate").datepicker('setDate', daysForward(new Date(), -2));

    reloadAssignments();
});