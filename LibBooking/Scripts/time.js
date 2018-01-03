//显示当前时间
setInterval(function() {
    var now = (new Date()).toLocaleString();
    $('#current-time').text(now);
}, 20);