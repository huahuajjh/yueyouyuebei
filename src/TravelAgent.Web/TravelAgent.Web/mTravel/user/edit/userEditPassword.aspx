<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="userEditPassword.aspx.cs" Inherits="TravelAgent.Web.mTravel.user.edit.userEditPassword" %>

<!DOCTYPE html>
<html lang="en">
<head>
    <meta charset="UTF-8">
    <meta content="width=device-width, initial-scale=1.0, maximum-scale=1.0, user-scalable=0;" name="viewport" />
    <title>更改密码</title>
    <link rel="stylesheet" href="../../new/css/style.css">
    <script src="../../../js/jquery-1.10.2.js"></script>
    <script src="../../../js/url.js"></script>
    <script src="../../../js/jquery.json.js"></script>
    <script src="../../../js/jquery.cookie.js"></script>
</head>
<body>
    <div class="wx-user-header">
        <div class="wx-user-header-left-btn">
            <a href="../userInfo.aspx" class="wx-back-btn"></a>
        </div>
        <div class="wx-user-header-title">
            密码修改
        </div>
    </div>
    <ul class="wx-user-edit-inputs">
        <li>
            <input type="password" placeholder="请输入旧的密码" id="oldPwd">
        </li>
        <li>
            <input type="password" placeholder="请输入新的密码" id="newPwd">
        </li>
        <li>
            <input type="password" placeholder="确认密码" id="newPwdTwo">
        </li>
    </ul>
    <div style="margin: 20px 15px;">
        <input type="button" class="wx-btn-y-sub" value="确定修改" id="editBtn">
    </div>
    <!--#include file="../../new/temp/bottom.html"-->
    <script type="text/javascript">
        if (!$.cookie("msg")) {
            location.href = "../login.aspx";
        }
        $("#editBtn").click(function () {
            if (!$("#oldPwd").val() || !$("#newPwd").val()) {
                alert("密码不能为空");
                return;
            }
            if ($("#newPwd").val() != $("#newPwdTwo").val()) {
                alert("两次输入的密码不正确");
                return;
            }
            var data = $.evalJSON($.cookie("msg"));
            $.ajax({
                dataType: "jsonp",//数据类型为jsonp  
                jsonp: "callback",//服务端用于接收callback调用的function名的参数
                type: "get",
                url: apiURL.ChangePwd,
                async: false,
                data: {
                    userId: data.Id,
                    oldPwd: $("#oldPwd").val(),
                    newPwd: $("#newPwd").val()
                },
                success: function (data) {
                    if (data.Code == -1) {
                        $.removeCookie("msg", {path: "/"});
                        location.href = "../login.aspx";
                        return;
                    }
                    if (data.Code == 1) {
                        location.href = "../userInfo.aspx";
                    } else {
                        alert(data.Msg);
                    }
                }
            });
        });
    </script>
</body>
</html>