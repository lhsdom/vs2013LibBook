/// <reference path="../Views/GetBookMsg/Table1.cshtml" />
/// <reference path="../Views/GetBookMsg/Table1.cshtml" />
/*
*1.当浏览器加载完毕，点击左侧功能导航的li添加active类属性（选中样式）
* 2.更改iframe的src属性，使显示页面转换
*/
$(document).ready(function () {
    var l=null;
    $('ul.nav > li').click(function () {
        $('ul.nav > li').removeClass('active');
        $(this).addClass('active');
        l=$(this).attr('id');
        if (l=='li2'){
            $('iframe').attr('src', '/GetBookMsg/Msg');

        }else if (l=='li1'){
            $('iframe').attr('src', '/GetBookMsg/Msg');
        }else if(l=='li4'){
            toastr.options = {
                closeButton: false,
                debug: false,
                progressBar: true,
                positionClass: "toast-top-center",
                onclick: null,
                showDuration: "300",
                hideDuration: "1000",
                timeOut: "2000",
                extendedTimeOut: "1000",
                showEasing: "swing",
                hideEasing: "linear",
                showMethod: "fadeIn",
                hideMethod: "fadeOut"
            };
            toastr.info("退出!");
        }else{
            ;
        }
    });
});