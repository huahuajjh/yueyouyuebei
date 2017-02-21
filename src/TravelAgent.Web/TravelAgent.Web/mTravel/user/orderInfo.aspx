<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="orderInfo.aspx.cs" Inherits="TravelAgent.Web.mTravel.user.orderInfo" %>

<!DOCTYPE html>
<html lang="en">
<head>
    <meta charset="UTF-8">
    <meta content="width=device-width, initial-scale=1.0, maximum-scale=1.0, user-scalable=0;" name="viewport" />
    <title>订单信息</title>
    <link rel="stylesheet" href="../new/css/style.css">
    <script src="../../js/jquery-1.10.2.js"></script>
    <script src="../../js/url.js"></script>
    <script src="../../js/jquery.json.js"></script>
    <script src="../../js/jquery.cookie.js"></script>
    <style type="text/css">
        .order-info {
            padding: 20px 0;
        }
        .order-info-title {
            padding-bottom: 3px;
            font-size: 14px;
        }
        .order-info-title span:first-child {
            display: inline-block;
            width: 90px;
            text-align: right;
            padding-right: 5px;
            padding-left: 8px;
        }
        .order-info-list {
            list-style: none;
            padding: 0;
            margin: 15px 0;
        }
            .order-info-list li {
                border-top: 1px solid #E9E9E9;
                border-bottom: 1px solid #E9E9E9;
                position: relative;
                height: 110px;
                box-sizing: border-box;
                padding: 20px 70px 0 130px;
            }
                .order-info-list li img {
                    position: absolute;
                    width: 100px;
                    height: 78px;
                    left: 15px;
                    top: 15px;
                }
                .order-info-list li h2 {
                    margin: 0;
                    font-size: 15px;
                }
                .order-info-list li p {
                    margin: 0;
                    position: absolute;
                    right: 20px;
                    top: 15px;
                    font-size: 15px;
                }
                    .order-info-list li p span {
                        font-size: 17px;
                    }
                .order-info-list li div {
                    position: absolute;
                    right: 20px;
                    bottom: 10px;
                }
        .order-info-money {
            border-bottom: 1px solid #E9E9E9;
            font-size: 15px;
            text-align: right;
            box-sizing: border-box;
            padding-right: 15px;
            padding-bottom: 15px;
        }
            .order-info-money p {
                margin: 0;
                display: inline-block;
                color: #FFAF53;
                font-size: 13px;
            }
            .order-info-money p span {
                font-size: 15px;
            }
        .order-info-state {
            margin: 0;
            padding: 15px 10px;
            font-size: 14px;
        }
            .order-info-state span {
                padding-left: 10px;
                padding-right: 60px;
            }
            .order-info-state a {
                text-decoration: none;
                color: #fff;
                background-color: #FF9A42;
                display: inline-block;
                padding: 5px;
            }
    </style>
    <script src="../../js/jquery-1.10.2.js"></script>
    <script src="../../js/url.js"></script>
    <script src="../../js/jquery.json.js"></script>
    <script src="../../js/jquery.cookie.js"></script>
</head>
<body>
    <div class="wx-user-header">
        <div class="wx-user-header-left-btn">
            <a href="javascript:window.history.go(-1);" class="wx-back-btn"></a>
        </div>
        <div class="wx-user-header-title">
            订单详细
        </div>
    </div>
    <div class="order-info">
        <div class="order-info-title"><span>订单编号：</span><span id="dingdanhao"></span></div>
        <div class="order-info-title"><span>下单时间：</span><span id="orderTime"></span></div>
        <ul class="order-info-list">
            <li>
                <img src="" alt="" id="img">
                <h2 id="title"></h2>
                <p>￥<span id="money"></span></p>
            </li>
        </ul>
        <div class="order-info-money">
            总计：<p>￥<span id="zongNum">88</span></p>
        </div>
        <p class="order-info-state">
            订单状态：<span id="stateMsg">未支付</span> <a href="" id="payBtn" style="display:none;">点击支付</a>
        </p>
    </div>
    <script type="text/javascript">
        if (!$.cookie("msg")) {
            location.href = "login.aspx";
        }
        if (!getQueryString("id")) {
            location.href = "orderAll.aspx";
        }
        var data = $.evalJSON($.cookie("msg"));
        if (getQueryString("state")) {
            $("#stateTitle").html("待支付订单");
        }
        $.ajax({
            dataType: "jsonp",//数据类型为jsonp  
            jsonp: "callback",//服务端用于接收callback调用的function名的参数
            type: "get",
            url: apiURL.GetOrderDetails,
            async: false,
            data: {
                id: getQueryString("id")
            },
            success: function (res) {
                if (res.Code == -1) {
                    $.removeCookie("msg", { path: "/" });
                    location.href = "login.aspx";
                    return;
                }
                var data = res.Data;
                $("#dingdanhao").html(data.OrderNo);
                $("#orderTime").html(data.OrderTime);
                $("#img").prop("src", data.Url);
                $("#title").html(data.ProductName);
                $("#money").html(data.OrderAmount);
                $("#zongNum").html(data.OrderAmount);
                $("#stateMsg").html(data.Status);
                if (data.StatusNo == 4) {
                    $("#payBtn").css("display", "inline-block");
                    $("#payBtn").prop("href", "/mTravel/weipay/confirmPay.aspx?o=" + data.OrderNo);
                }
            }
        });
        function getQueryString(name) {
            var reg = new RegExp("(^|&)" + name + "=([^&]*)(&|$)", "i");
            var r = window.location.search.substr(1).match(reg);
            if (r != null) return unescape(r[2]); return null;
        }
    </script>
</body>
</html>
