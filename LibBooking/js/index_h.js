/*
*1.当浏览器加载完毕，点击左侧功能导航的li添加active类属性（选中样式）
* 2.更改加载得URL，使显示页面转换
*/
$(document).ready(function () {
    $("#table").load("/GetBookMsg/Msg");
    var l=null;
    $('ul.nav > li').click(function () {
        $('ul.nav > li').removeClass('active');
        $(this).addClass('active');
        l=$(this).attr('id');
        if (l=='li2'){
            $("#table").load("/GetBookMsg/Msg");
        }else if (l=='li1'){
            $("#table").load("/GetBookMsg/Msg");
        }else if(l=='li4'){
            toastr.options = {
                "closeButton": true,
                "debug": false,
                "progressBar": true,
                "positionClass": "toast-top-center",
                "onclick": null,
                "showDuration": "300",
                "hideDuration": "1000",
                "timeOut": "5000",
                "extendedTimeOut": "1000",
                "showEasing": "swing",
                "hideEasing": "linear",
                "showMethod": "fadeIn",
                "hideMethod": "fadeOut"
            }
            toastr["success"]("退出", "操作提示");
        }else if(l=='li3'){
            toastr.options = {
                "closeButton": true,
                "debug": false,
                "progressBar": true,
                "positionClass": "toast-top-center",
                "onclick": null,
                "showDuration": "300",
                "hideDuration": "1000",
                "timeOut": "5000",
                "extendedTimeOut": "1000",
                "showEasing": "swing",
                "hideEasing": "linear",
                "showMethod": "fadeIn",
                "hideMethod": "fadeOut"
            }
            toastr["success"]("正在导出", "操作提示");
        }else{
            ;
        }
    });
    var l=null;
});