<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="M_Default.aspx.cs" Inherits="TravelAgent.Web.M_Default" %>
<!DOCTYPE html>
<html>
    <head>
    <meta charset="utf-8" />
	<title><%=webinfo.WebName %>-<%=webinfo.SEOTitle %></title>
	<meta name="keywords" content="<%=webinfo.SEOKeywords%>" />
	<meta name="description" content="<%=webinfo.SEODescription%>" />
	<meta name="viewport" id="viewport" content="width=device-width, initial-scale=1.0, minimum-scale=1.0, maximum-scale=1.0, user-scalable=no" />
    <link rel="stylesheet" href="mTravel/new/css/style.css">
	<script src="mTravel/scripts/jquery.min.js"></script>
</head>
<body>
    <!--#include file="mTravel/new/temp/top.html"--> 
    <div class="wx-body">
        <ul class="wx-menu">
            <li class="wx-menu-tejia">
                <a href="mTravel/LineList.aspx">特价产品</a>
            </li>
            <li class="wx-menu-huwai">
                <a href="mTravel/LineList.aspx?d=2">户外撒野</a>
            </li>
            <li class="wx-menu-zhoubian">
                <a href="mTravel/LineList.aspx?d=3">周边旅行</a>
            </li>
            <li class="wx-menu-zhuti">
                <a href="mTravel/LineTheme.aspx">主题旅游</a>
            </li>
            <li class="wx-menu-changgui">
                <a href="mTravel/LineList.aspx?d=1">常规旅游</a>
            </li>
            <li class="wx-menu-qianzheng">
                <a href="mTravel/VisaModel.aspx">签证服务</a>
            </li>
        </ul>
        <div class="wx-tuijian-title"><span>推荐产品</span></div>
        <ul class="wx-tuijian-list">
            <%=BindLine(5,Convert.ToInt32(TravelAgent.Tool.EnumSummary.State.推荐))%>
        </ul>
        <div class="wx-scroll-bottom">
            <p>已到最底部！</p>
            <p>产品将持续为你更新！</p>
            <a href="" class="wx-btn-go-top"></a>
        </div>
        <div class="wx-footer-info">
            <a href="mTravel/Article.aspx?id=19">关于我们</a>
            <span></span>
            <a href="mTravel/Article.aspx?id=21">联系我们</a>
            <span></span>
            <a href="mTravel/Article.aspx?id=27">报名地址</a>
            <p>Copyright © 2015-2017 技术支持：约游约呗</p>
        </div>
     </div>
    <!--#include file="mTravel/new/temp/bottom.html"-->
</body>
</html>
