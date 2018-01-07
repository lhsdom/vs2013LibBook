$(document).ready(function () {
//显示日期下拉选框
    for(var i=0;i<3;i++){
        $(".cTimeDay>option:eq("+i+")").html(GetDateStr(i));
        $(".cTimeDay>option:eq("+i+")").attr("value",GetDateStr(i));//该语句为了便于下拉选中的数据的值
    }
//这个是上述的对应函数
//以下为日期下拉选择框自动调整
    function GetDateStr(i)
    {
        var day = new Date();
        day.setDate(day.getDate()+i);//获取当天后一天的日期
        var m = day.getMonth()+1;
        var d = day.getDate();
        var r=null;//返回的日期字符串
        if (i==0){r="今天"+m+"月"+d+"日";}
        else if (i==1){r="明天"+m+"月"+d+"日";}
        else{r="后天"+m+"月"+d+"日";}
        return r;
    }
    var l=null;
    //页面跳转点击事件
    $('ul.nav > li').click(function () {
        $('ul.nav > li').removeClass('active');
        $(this).addClass('active');
        l=$(this).attr('id');
        if (l=='li1'){
           $("#htm1").show();
            $("#htm2").hide();
        }else if (l=='li2'){
            $("#htm2").show();
            $("#htm1").hide();
        }else if(l=='li3'){
            //弹框：提示是否退出
        }else{
            ;
        }
    });
});