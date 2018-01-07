/*预定义变量+start*/
var firstSeat = 401-1; //第一个座位编号
var map1=[];//默认座位图401教
var isChoose=null;//座位是否被选的标识
var i=0;//用户选择的座位数
/*预定义变量-over*/
$(document).ready(function() {
    var $cart = $('#selected-seats');//座位区
    var sc = $('#seat-map').seatCharts({
        map: [  //座位图
            'aaaaaaaaaa',
            'aaaaaaaaaa',
            'aaaaaaaaaa',
            'aaaaaaaaaa',
            '__________',
            'aaaaaaaaaa',
            'aaaaaaaaaa',
            'aaaaaaaaaa',
            'aaaaaaaaaa',
            'aaaaaaaaaa'
        ],
        legend : { //定义图例
            node : $('#legend'),
            items : [
                [ 'a', 'available',   '可选座' ],
                [ 'a', 'unavailable', '已被占']
            ]
        },
        click: function () { //点击事件
            function jy(){
                if (i>=1)sc.find('available').status('unavailable');//如果选择一个全部禁用
                else sc.find('unavailable').status('available');//如果选择一个全部禁用
            }
            if (this.status() == 'available') { //可选座
                $('<li>'+(this.settings.row+1)+'排'+this.settings.label+'座</li>')
                    .attr('id', 'cart-item-'+this.settings.id)
                    .data('seatId', this.settings.id)
                    .appendTo($cart);
                i++;
                jy();
                return 'selected';
            } else if (this.status() == 'selected') { //已选中
                //删除已预订座位
                $('#cart-item-'+this.settings.id).remove();
                i--;
                jy();
                //可选座
                return 'available';
            } else if (this.status() == 'unavailable') { //已被选
                return 'unavailable';
            } else {
                return this.style();
            }
        }
    });
    //已售出的座位
    // sc.get(['1_2']).status('unavailable');
});