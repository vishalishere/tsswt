function isWorkingDay(d) {
    if (d.getDay() == 0 || d.getDay() == 6) {
        return false;
    } else {
        var mt = d.getMonth() + 1;
        var dt = d.getDate();

        var ds = '' + d.getFullYear() + (mt < 10 ? '0' + mt : mt) + (dt < 10 ? '0' + dt : dt);

        return $.inArray(ds, holidays) == -1;
    }
}

function daysForward(d, days) {
    return new Date(d.getTime() + days * 24 * 60 * 60 * 1000);
}

function getDaySlot(d) {
    return (d.getHours() - (d.getHours() > 13 ? 10 : 9)) * 2 + Math.round(d.getMinutes() / 30, 0);
}

function getHourString(d) {
    var ht = d.getHours();
    var mt = d.getMinutes();
    return (ht < 10 ? '0' + ht : ht) + ':' + (mt < 10 ? '0' + mt : mt);
}

function getDayString(d) {
    var dt = d.getDate();
    var mt = d.getMonth() + 1; //months are zero based
    return (dt < 10 ? '0' + dt : dt) + '/' + (mt < 10 ? '0' + mt : mt);
}