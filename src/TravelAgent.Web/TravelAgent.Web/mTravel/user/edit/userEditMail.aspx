<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="userEditMail.aspx.cs" Inherits="TravelAgent.Web.mTravel.user.edit.userEditMail" %>

<!DOCTYPE html>
<html lang="en">
<head>
    <meta charset="UTF-8">
    <meta content="width=device-width, initial-scale=1.0, maximum-scale=1.0, user-scalable=0;" name="viewport" />
    <title>更改邮箱</title>
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
            邮箱修改
        </div>
    </div>
    <ul class="wx-user-edit-inputs">
        <li>
            <input type="text" placeholder="请输入新的邮箱" id="email">
        </li>
    </ul>
    <div style="margin: 20px 15px;">
        <input type="button" class="wx-btn-y-sub" value="确定修改" id="editBtn">
    </div>
    <script type="text/javascript">
        if (!$.cookie("msg")) {
            location.href = "../login.aspx";
        } else {
            var data = $.evalJSON($.cookie("msg"));
            $("#email").val(data.Email);
        }
        $("#editBtn").click(function () {
            if (!$("#email").val()) {
                alert("邮箱不能为空");
                return;
            }
            if (!/^(.+)@(.+)$/.test($("#email").val())) {
                alert("邮箱格式不正确");
                return;
            }
            var userInfo = $.evalJSON($.cookie("msg"));
            $.ajax({
                dataType: "jsonp",//数据类型为jsonp  
                jsonp: "callback",//服务端用于接收callback调用的function名的参数
                type: "get",
                url: apiURL.ChangeEmail,
                async: false,
                data: {
                    userId: userInfo.Id,
                    email: $("#email").val()
                },
                success: function (data) {
                    if (data.Code == -1) {
                        $.removeCookie("msg", { path: "/" });
                        location.href = "../login.aspx";
                        return;
                    }
                    if (data.Code == 1) {
                        userInfo.Email = $("#email").val();
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