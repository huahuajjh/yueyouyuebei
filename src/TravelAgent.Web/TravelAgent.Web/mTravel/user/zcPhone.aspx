<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="zcPhone.aspx.cs" Inherits="TravelAgent.Web.mTravel.user.zcPhone" %>

<!DOCTYPE html>
<html lang="cn">
<head>
    <meta charset="UTF-8">
    <meta content="width=device-width, initial-scale=1.0, maximum-scale=1.0, user-scalable=0;" name="viewport" />
    <title>注册账号</title>
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
            <input type="text" placeholder="请输入您的注册手机号码" id="phone">
        </li>
        <li>
            <input type="password" placeholder="设置密码" id="pwd">
        </li>
        <li>
            <input type="password" placeholder="确认密码" id="newPwd">
        </li>
    </ul>
    <div style="margin: 36px 45px;">
        <input type="button" class="wx-btn-y-sub" value="注册" id="regBtn">
        <a href="zcEmail.aspx" class="wx-y-link">使用邮箱注册</a>
    </div>
    <!--#include file="../new/temp/bottom.html"-->
    <script type="text/javascript">
        $("#regBtn").click(function () {
            if (!$("#phone").val()) {
                alert("手机号码不能为空");
                return;
            }
            if (!$("#pwd").val()) {
                alert("密码不能为空");
                return;
            }
            if (!/^1\d{10}$/.test($("#phone").val())) {
                alert("手机号码格式不正确");
                return;
            }
            if ($("#pwd").val() != $("#newPwd").val()) {
                alert("两次输入的密码不正确");
                return;
            }
            $.ajax({
                dataType: "jsonp",//数据类型为jsonp  
                jsonp: "callback",//服务端用于接收callback调用的function名的参数
                type: "get",
                url: apiURL.Register,
                async: false,
                data: {
                    registerInput: $.toJSON({
                        Phone: $("#phone").val(),
                        Pwd: $("#pwd").val()
                    })
                },
                success: function (data) {
                    if (data.Code == 1) {
                        alert("注册成功");
                        location.href = "login.aspx";
                    } else {
                        alert(data.Msg);
                    }
                }
            });
        });
    </script>
</body>
</html>