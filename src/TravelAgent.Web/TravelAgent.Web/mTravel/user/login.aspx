<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="login.aspx.cs" Inherits="TravelAgent.Web.mTravel.user.login" %>

<!DOCTYPE html>
<html lang="cn">
<head>
    <meta charset="UTF-8">
    <meta content="width=device-width, initial-scale=1.0, maximum-scale=1.0, user-scalable=0;" name="viewport" />
    <title>登录</title>
    <link rel="stylesheet" href="../new/css/style.css">
    <style type="text/css">
        html {
            background-image: url("../new/images/bg.jpg");
            background-size: 100%;
            background-repeat: round;
        }
    </style>
    <script src="../../js/jquery-1.10.2.js"></script>
    <script src="../../js/url.js"></script>
    <script src="../../js/jquery.json.js"></script>
    <script src="../../js/jquery.cookie.js"></script>
</head>
<body>
    <img src="../new/images/2logo.png" alt="" style="display: block; margin: 60px auto 0 auto;">
    <ul class="wx-ul-inputs">
        <li>
            <input type="text" placeholder="账号" id="userName">
        </li>
        <li>
            <input type="password" placeholder="密码" id="password">
        </li>
    </ul>
    <div style="margin: 36px 45px;">
        <input type="button" class="wx-btn-y-sub" value="登录" id="zcBtn">
        <a href="zcEmail.aspx" class="wx-y-link">点击注册</a>
    </div>    
    <!--#include file="../new/temp/bottom.html"-->
    <script type="text/javascript">
        $("#zcBtn").click(function () {
            $.ajax({
                dataType: "jsonp",//数据类型为jsonp  
                jsonp: "callback",//服务端用于接收callback调用的function名的参数
                type: "get",
                url: apiURL.Login,
                async: false,
                data: {
                    _loginInput: $.toJSON({
                        Account: $("#userName").val(),
                        Pwd: $("#password").val()
                    })
                },
                success: function (data) {
                    if (data.Code == 1) {
                        $.cookie("msg", $.toJSON(data.Data), {
                        path: "/"});
                        location.href = "userIndex.aspx";
                    } else {
                        alert(data.Msg);
                    }
                }
            });
        });
    </script>
</body>
</html>
