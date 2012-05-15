function drawEllipse(ctx, x, y, minRadius, maxRadius, radianInit, radianEnd) {
    for (var i = minRadius; i < maxRadius + 1; i++) {
        ctx.beginPath();
        ctx.arc(x, y, i, radianInit, radianEnd, false);
        ctx.stroke();
    }
}

