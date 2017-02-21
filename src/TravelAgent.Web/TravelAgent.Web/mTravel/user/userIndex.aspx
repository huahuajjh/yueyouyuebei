<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="userIndex.aspx.cs" Inherits="TravelAgent.Web.mTravel.user.userIndex" %>

<!DOCTYPE html>
<html lang="en">
<head>
    <meta charset="UTF-8">
    <meta content="width=device-width, initial-scale=1.0, maximum-scale=1.0, user-scalable=0;" name="viewport" />
    <title>个人中心</title>
    <link rel="stylesheet" href="../new/css/style.css">
    <script src="../../js/jquery-1.10.2.js"></script>
    <script src="../../js/url.js"></script>
    <script src="../../js/jquery.json.js"></script>
    <script src="../../js/jquery.cookie.js"></script>
</head>
<body>
    <div class="wx-user-header">
        <div class="wx-user-header-left-btn">
            <a href="/M_Default.aspx" class="wx-home-btn"></a>
        </div>
        <div class="wx-user-header-title">
            个人中心
        </div>
    </div>
    <div class="wx-user-info">
        <img src="../new/images/2logo.png" alt="">
        <h2><span id="userName"></span><span class="" id="gender"></span></h2>
        <br>
        <a href="userInfo.aspx"><span>个人资料</span><span></span></a>
    </div>
    <ul class="wx-user-menu">
        <li>
            <a href="orderAll.aspx" class="wx-all-order">全部订单</a>
        </li>
        <li>
            <a href="orderAll.aspx?state=1" class="wx-nopay-order">待支付订单</a>
        </li>
    </ul>
    <script type="text/javascript">
        if (!$.cookie("msg")) {
            location.href = "login.aspx";
        } else {
            var data = $.evalJSON($.cookie("msg"));
            $("#userName").html(data.Name || "约游约呗");
            if (data.Gender == "女") {
                $("#gender").addClass("woman");
            } else {
                $("#gender").addClass("man");
            }
        }
    </script>
</body>
</html>