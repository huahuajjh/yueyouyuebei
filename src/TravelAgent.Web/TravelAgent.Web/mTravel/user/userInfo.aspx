<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="userInfo.aspx.cs" Inherits="TravelAgent.Web.mTravel.user.userInfo" %>

<!DOCTYPE html>
<html lang="en">
<head>
    <meta charset="UTF-8">
    <meta content="width=device-width, initial-scale=1.0, maximum-scale=1.0, user-scalable=0;" name="viewport" />
    <title>个人资料</title>
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
        <div class="wx-user-header-title">
            个人资料
        </div>
    </div>
    <ul class="wx-user-menu">
        <li>
            <a href="edit/userEditName.aspx">真实姓名 <p class="wx-user-menu-go"><span id="name"></span></p></a>
        </li>
        <li>
            <a href="edit/userEditGender.aspx">性别 <p class="wx-user-menu-go"><span id="gender"></span></p></a>
        </li>
        <li>
            <a href="edit/userEditPhone.aspx">手机号 <p class="wx-user-menu-go"><span id="phone"></span></p></a>
        </li>
        <li>
            <a href="edit/userEditMail.aspx">邮箱 <p class="wx-user-menu-go"><span id="email"></span></p></a>
        </li>
        <li>
            <a href="edit/userEditPassword.aspx">密码修改 <p class="wx-user-menu-go"></p></a>
        </li>
    </ul>
    <div style="margin: 20px 15px;">
        <input type="button" class="wx-btn-y-sub" value="退出登录">
    </div>
    <script type="text/javascript">
        if (!$.cookie("msg")) {
            location.href = "login.aspx";
        } else {
            var userInfo = $.evalJSON($.cookie("msg"));
            $("#name").html(userInfo.Name);
            $("#gender").html(userInfo.Gender);
            $("#phone").html(userInfo.Phone);
            $("#email").html(userInfo.Email);
        }
    </script>
</body>
</html>