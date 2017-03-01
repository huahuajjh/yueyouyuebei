<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="userEditNc.aspx.cs" Inherits="TravelAgent.Web.mTravel.user.edit.userEditNc" %>

<!DOCTYPE html>
<html lang="en">
<head>
    <meta charset="UTF-8">
    <meta content="width=device-width, initial-scale=1.0, maximum-scale=1.0, user-scalable=0;" name="viewport" />
    <title>Document</title>
    <link rel="stylesheet" href="../../new/css/style.css">
</head>
<body>
    <div class="wx-user-header">
        <div class="wx-user-header-left-btn">
            <a href="../userInfo.aspx" class="wx-back-btn"></a>
        </div>
        <div class="wx-user-header-title">
            昵称修改
        </div>
    </div>
    <ul class="wx-user-edit-inputs">
        <li>
            <input type="text" placeholder="更改的昵称">
        </li>
    </ul>
    <div style="margin: 20px 15px;">
        <input type="button" class="wx-btn-y-sub" value="确定修改">
    </div>
    <!--#include file="../../new/temp/bottom.html"-->
</body>
</html>