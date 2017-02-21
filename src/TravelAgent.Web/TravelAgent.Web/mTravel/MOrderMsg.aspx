<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="MOrderMsg.aspx.cs" Inherits="TravelAgent.Web.mTravel.MOrderMsg" %>

<!doctype html>
<html>
<head>
<meta charset="utf-8" />
<title>订单提交_<%=webinfo.WebName %></title>
<meta name="viewport" content="width=device-width, initial-scale=1.0, user-scalable=0, minimum-scale=1.0, maximum-scale=1.0">
<link type="text/css" rel="stylesheet" href="css/style.css" />
<link type="text/css" rel="stylesheet" href="css/yuding.css" />
    <link rel="stylesheet" href="new/css/style.css" />
<script src="scripts/jquery.min.js"></script>
</head>
                    <body style="padding-top: 43.5px;">
            <div class="wx-header-back">
                <a href="javascript:window.history.go(-1);" class="wx-header-back-btn"></a>
                <h1>提交结果</h1>
                <div class="wx-header-back-input">
                    <form method="get" name="form1" action="/mTravel/SearchResult.aspx">
                        <input type="text" name="keyword">
                        <button type="submit"></button>
                    </form>
                </div>
            </div>
<div class = "page_first">
<div id="page_1">
  <div class="m-main">
      <section class="main" id="order-next-m">
        <div class="plr10"><div class="order_header">
        <p>订单号：<%=strNo %></p>
        <p>金&nbsp;&nbsp;&nbsp;&nbsp;额：<%=strMsg %></p>
       <h3 class="<%=strClass%>"><%=strMsg %>！</h3>  
       <p>您可以咨询网站客服查询相关订单问题。</p>   </div></div>

      </section>
        <div class="plr10">
<div class="form_btn">                      
 <a class="pay" href="tel:<%=webinfo. WebTel%>">电话联系</a>
 </div>
        </div>
  </div>
</div>

<!--foot-->
<footer class="copyright">
	<p>
		<%=BindBottonNav(3,3)%>
	</p>
	<p>Copyright &copy; 2015-<%=DateTime.Now.Year %></p>
	<p>技术支持：约游约呗</p>
</footer>
    <!--#include file="new/temp/bottom.html"-->
<script type="text/javascript" src="scripts/script1.js"></script>
<div class="zhedang"></div>
<div class="roboxs">
<div class="roboxs_tit"> 
<a href="../M_Default.aspx" class="homebtn"></a>
<a href="javascript:;" class="closebtn">×</a>
  <h3>产品分类</h3>
</div>
<div class="theme-popbod-one">
  <div class="m_more_des">				
				<span><a href="LineList.aspx">特价产品</a></span>
				<span><a href="LineList.aspx?d=1">出境旅游</a></span>
				<span><a href="LineList.aspx?d=2">国内旅游</a></span>
				<span><a href="LineList.aspx?d=3">周边旅游</a></span>
			</div>
</div>
</div>
</body>
</html>

