<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="userEditGender.aspx.cs" Inherits="TravelAgent.Web.mTravel.user.edit.userEditGender" %>

<!DOCTYPE html>
<html lang="en">
<head>
    <meta charset="UTF-8">
    <meta content="width=device-width, initial-scale=1.0, maximum-scale=1.0, user-scalable=0;" name="viewport" />
    <title>更改性别</title>
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
            性别修改
        </div>
    </div>
    <ul class="wx-user-edit-inputs">
        <li>
            <div class="wx-user-edit-input-check" id="man">
                男
            </div>
        </li>
        <li>
            <div class="wx-user-edit-input-check" id="woman">
                女
            </div>
        </li>
    </ul>
    <div style="margin: 20px 15px;">
        <input type="button" class="wx-btn-y-sub" value="确定修改" id="editBtn">
    </div>
    <!--#include file="../../new/temp/bottom.html"-->
    <script type="text/javascript">
        $("#man").click(function () {
            $("#man").addClass("check");
            $("#woman").removeClass("check");
        });
        $("#woman").click(function () {
            $("#woman").addClass("check");
            $("#man").removeClass("check");
        });
        if (!$.cookie("msg")) {
            location.href = "../login.aspx";
        } else {
            var data = $.evalJSON($.cookie("msg"));
            if (data.Gender == '女') {
                $("#woman").addClass("check");
            } else {
                $("#man").addClass("check");
            }
        }
        $("#editBtn").click(function () {
            var userInfo = $.evalJSON($.cookie("msg"));
            var gender = $("#man").hasClass("check") ? "男" : "女";
            $.ajax({
                dataType: "jsonp",//数据类型为jsonp  
                jsonp: "callback",//服务端用于接收callback调用的function名的参数
                type: "get",
                url: apiURL.ChangeGender,
                async: false,
                data: {
                    userId: userInfo.Id,
                    gender: gender
                },
                success: function (data) {
                    if (data.Code == -1) {
                        $.removeCookie("msg", { path: "/" });
                        location.href = "../login.aspx";
                        return;
                    }
                    if (data.Code == 1) {
                        userInfo.Gender = gender;
                        $.cookie("msg", $.toJSON(userInfo), { path: "/" });
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