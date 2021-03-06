﻿<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WebPoints.aspx.cs" Inherits="TravelAgent.Web.admin.basicset.WebPoints" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head>
<meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
<title>无标题文档</title>
<link href="../css/style.css" rel="stylesheet" type="text/css" />
<script type="text/javascript" src="/js/jquery-1.3.2.min.js"></script>
<script type="text/javascript" src="/js/jquery.validate.min.js"></script>
<script type="text/javascript" src="/js/validate.js"></script>
<script type="text/javascript" src="/js/jquery.form.js"></script>
<script type="text/javascript" src="../js/singleupload.js"></script>
<script type="text/javascript">
    $(function() {
        //表单验证JS
        $("#form1").validate({
            //出错时添加的标签
            errorElement: "span",
            success: function(label) {
                //正确时的样式
                label.text(" ").addClass("success");
            }
        });
    });
</script>
</head>

<body>
        <div id="divMsg"></div>
	<div class="place">
    <span>位置：</span>
    <ul class="placeul">
    <li><a href="#">系统设置</a></li>
    <li><a href="#">网站基础设置</a></li>
    <li><a href="#">网站基本信息</a></li>
    </ul>
    </div>
    
    <div class="formbody">
    <div class="itab">
  	<ul> 
    <li><a href="WebBasicInfo.aspx">网站基本信息</a></li> 
    <li><a href="WebContactInfo.aspx">网站联系信息</a></li>
    <li><a href="WebServices.aspx">网站客服信息</a></li>
    <li><a href="WebSEO.aspx">网站SEO设置</a></li>
    <li><a href="WebAgreement.aspx">网站合同协议</a></li>
    <li><a href="#" class="selected">网站积分设置</a></li>
  	</ul>
    </div> 
    <%--<div class="formtitle"><span>网站基本信息</span></div>--%>
    <div style="padding-top:5px;">
    <form id="form1" runat="server">
    <table border="0" cellpadding="0" cellspacing="0" style="line-height:50px; width:100%;" class="formtable">
            
            <tr>
                <td style="text-align:right; color:#056dae;background: #F5F5F5;width:150px;">注册赠送 <span class="red">*</span>：</td><td><asp:TextBox ID="txtRegPoints" runat="server" CssClass="dfinput required digits" Width="50px" onkeyup="this.value=this.value.replace(/\D/g,&#39;&#39;);" Text="0"></asp:TextBox>
                分</td>
            </tr>
            <tr>
                <td style="text-align:right; color:#056dae;background: #F5F5F5;">手机验证赠送 <span class="red">*</span>：</td><td><asp:TextBox ID="txtMobilePoints" runat="server" CssClass="dfinput required digits" Width="50px" onkeyup="this.value=this.value.replace(/\D/g,&#39;&#39;);" Text="0"></asp:TextBox>
                分</td>
            </tr>
            <tr>
                <td style="text-align:right; color:#056dae;background: #F5F5F5;">邮箱验证赠送 <span class="red">*</span>：</td><td><asp:TextBox ID="txtEmailPoints" runat="server" CssClass="dfinput required digits" Width="50px" onkeyup="this.value=this.value.replace(/\D/g,&#39;&#39;);" Text="0"></asp:TextBox>
                分</td>
            </tr>
            <tr>
                <td style="text-align:right; color:#056dae;background: #F5F5F5;">其他积分设置 <span class="red">*</span>：</td><td>详情请详见各个产品的设置</td>
            </tr>
            <tr>
                <td style="text-align:right; color:#056dae;background: #F5F5F5; height:60px;"></td>
                <td>
                    <asp:Button ID="btnSave" runat="server" Text="确定保存" CssClass="btn" 
                        onclick="btnSave_Click" />
                </td>
            </tr>
     </table>
     </form>
    </div>
    </div>


</body>

</html>
