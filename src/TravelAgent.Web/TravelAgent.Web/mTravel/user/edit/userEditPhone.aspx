<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="userEditPhone.aspx.cs" Inherits="TravelAgent.Web.mTravel.user.edit.userEditPhone" %>

<!DOCTYPE html>
<html lang="en">
<head>
    <meta charset="UTF-8">
    <meta content="width=device-width, initial-scale=1.0, maximum-scale=1.0, user-scalable=0;" name="viewport" />
    <title>更改手机</title>
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
            手机号修改
        </div>
    </div>
    <ul class="wx-user-edit-inputs">
        <li>
            <input type="text" placeholder="请输入新的手机号码" id="phone">
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
            $("#phone").val(data.Phone);
        }
        $("#editBtn").click(function () {
            if (!$("#phone").val()) {
                alert("手机不能为空");
                return;
            }
            if (!/^1\d{10}$/.test($("#phone").val())) {
                alert("手机格式不正确");
                return;
            }
            var userInfo = $.evalJSON($.cookie("msg"));
            $.ajax({
                dataType: "jsonp",//数据类型为jsonp  
                jsonp: "callback",//服务端用于接收callback调用的function名的参数
                type: "get",
                url: apiURL.ChangeTel,
                async: false,
                data: {
                    userId: userInfo.Id,
                    tel: $("#phone").val()
                },
                success: function (data) {
                    if (data.Code == -1) {
                        $.removeCookie("msg", { path: "/" });
                        location.href = "../login.aspx";
                        return;
                    }
                    if (data.Code == 1) {
                        userInfo.Phone = $("#phone").val();
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