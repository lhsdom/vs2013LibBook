//显示当前时间(格式：2018/1/4 下午6:30:30)
setInterval(function() {
    var now = new Date();
    var nowString=now.toLocaleString();
    $('#current-time').text(nowString);
}, 59);