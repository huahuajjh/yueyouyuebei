<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="orderAll.aspx.cs" Inherits="TravelAgent.Web.mTravel.user.orderAll" %>

<!DOCTYPE html>
<html lang="en">
<head>
    <meta charset="UTF-8">
    <meta content="width=device-width, initial-scale=1.0, maximum-scale=1.0, user-scalable=0;" name="viewport" />
    <title>全部订单</title>
    <link rel="stylesheet" href="../new/css/style.css">
    <script src="../../js/jquery-1.10.2.js"></script>
    <script src="../../js/url.js"></script>
    <script src="../../js/jquery.json.js"></script>
    <script src="../../js/jquery.cookie.js"></script>
</head>
<body>
    <div class="wx-user-header">
        <div class="wx-user-header-left-btn">
            <a href="userIndex.aspx" class="wx-back-btn"></a>
        </div>
        <div class="wx-user-header-title" id="stateTitle">
            全部订单
        </div>
    </div>
    <ul class="wx-user-orders" id="dataList">
    </ul>
    <div class="wx-notorder-title" id="noOrderInfo">
        <p>当前没有订单</p>
        <p><span>去</span><a href="/M_Default.aspx">首页</a><span>看看</span></p>
    </div>
    <img src="../new/images/bk3.png" alt="" style="position: fixed; width: 100%; bottom: 0; left: 0;" id="noOrderInfoImg">
    <script type="text/template" id="temp">
        <li>
            <div showid="{Id}">
                <img src="{Url}" alt="">
                <h2>{ProductName}</h2>
                <span>{Status}</span>
                <p>￥<span>{OrderAmount}</span></p>
            </div>
        </li>
    </script>
        <script type="text/template" id="tempPay">
        <li>
            <div showid="{Id}">
                <img src="{Url}" alt="">
                <h2>{ProductName}</h2>
                <span>{Status}</span>
                <a href="/mTravel/weipay/confirmPay.aspx?o={OrderNo}">点击支付</a>
                <p>￥<span>{OrderAmount}</span></p>
            </div>
        </li>
    </script>
    <script type="text/javascript">
        if (!$.cookie("msg")) {
            location.href = "login.aspx";
        }
        var data = $.evalJSON($.cookie("msg"));
        if (getQueryString("state")) {
            $("#stateTitle").html("待支付订单");
        }
        $.ajax({
            dataType: "jsonp",//数据类型为jsonp  
            jsonp: "callback",//服务端用于接收callback调用的function名的参数
            type: "get",
            url: getQueryString("state") ? apiURL.GetNotPayOrder : apiURL.GetOrdersByUser,
            async: false,
            data: {
                 userId: data.Id
            },
            success: function (res) {
                if (res.Code == -1) {
                    $.removeCookie("msg", { path: "/" });
                    location.href = "login.aspx";
                    return;
                }
                if (!res.Data || res.Data.length <= 0) {
                    $("#dataList").css("display", "none");
                    $("#noOrderInfo").css("display", "block");
                    $("#noOrderInfoImg").css("display", "block");
                } else {
                    $("#dataList").css("display", "block");
                    $("#noOrderInfo").css("display", "none");
                    $("#noOrderInfoImg").css("display", "none");
                    for (var i = 0, d; d = res.Data[i++];) {
                        showDataDom(d);
                    }
                }
            }
        });
        function showDataDom(data) {
            var dom = $(nano($("#tempPay").html(), data));
            if (data.StatusNo == 4) {
                dom = $(nano($("#tempPay").html(), data));
            } else {
                dom = $(nano($("#temp").html(), data));
            }
            dom.find("div").click(function (e) {
                if (e.toElement == $(this).find("a")[0]) {
                } else {
                    location.href = "orderInfo.aspx?id=" + $(this).attr("showid");
                }
            });
            $("#dataList").append(dom);
        }
        function getQueryString(name) {
            var reg = new RegExp("(^|&)" + name + "=([^&]*)(&|$)", "i");
            var r = window.location.search.substr(1).match(reg);
            if (r != null) return unescape(r[2]); return null;
        }

        function nano(template, data) {
            return template.replace(/\{([\w\.]*)\}/g, function (str, key) {
                var keys = key.split("."), v = data[keys.shift()];
                for (var i = 0, l = keys.length; i < l; i++) v = v[keys[i]];
                return (typeof v !== "undefined" && v !== null) ? v : "";
            });
        }
        function showInfo(id, e) {
            location.href = "orderInfo.aspx?id=" + id;
        }
    </script>
</body>
</html>
