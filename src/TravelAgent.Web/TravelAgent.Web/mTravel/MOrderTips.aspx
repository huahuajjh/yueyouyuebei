<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="MOrderTips.aspx.cs" Inherits="TravelAgent.Web.mTravel.MOrderTips" %>

<!doctype html>
<html>
<head>
<meta charset="utf-8" />
<title>订单提交成功_<%=webinfo.WebName %></title>
<meta name="viewport" content="width=device-width, initial-scale=1.0, user-scalable=0, minimum-scale=1.0, maximum-scale=1.0">
<link type="text/css" rel="stylesheet" href="css/style.css" />
<link type="text/css" rel="stylesheet" href="css/yuding.css" />
    <link rel="stylesheet" href="new/css/style.css" />
<script src="scripts/jquery.min.js"></script>
<script type="text/javascript">
    function isWeiXin() {
        var ua = window.navigator.userAgent.toLowerCase();
        if (ua.match(/MicroMessenger/i) == 'micromessenger') {
            return true;
        } else {
            return false;
        }
    }
    $(function() {
        if (isWeiXin()) {
            $(".cancel").show();
        }
        else {
            $(".cancel").hide();
        }
    })
</script>
</head>
                        <body style="padding-top: 43.5px;">
            <div class="wx-header-back">
                <a href="javascript:window.history.go(-1);" class="wx-header-back-btn"></a>
                <h1>预订成功</h1>
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
       <h3 class="sucess">恭喜您，订单提交成功！</h3>       <p style="color:#0e9ee8"><%=Request["deal_type"].ToString().Equals(Convert.ToInt32(TravelAgent.Tool.EnumSummary.DealType.人工处理).ToString()) ? "该产品需要审核确认" : "该产品无需确认，可以直接付款"%></p>
       <p>稍后客服电话联系您，请保持电话畅通。</p>   
       
       </div></div>
        <div class="plr10">
          <div class="order-m">
            <ul>
              <li> 
                <label  style="line-height:36px;">线路名称</label>
                <span class="long_name"><span><%=Request["linename"] %></span></span></li>
							<li> 
							        <label>游玩日期</label>
							        <span class="t1" id="start_date"><%=Request["shijian1"]%></span>
                                    
							</li>
              <li>
                <label>预订数量</label>
 <span class="t1"><%=Request["renshu1"]%>成人/<%=Request["renshu2"]%>儿童</span>
                 </li>
             
              <li> 
                <label>订单总额</label>
                <span class="price t1" style="width:auto;right:16px;top:5px;color:#f60;">￥ <span  style="font-weight:bold;font-size:22px;color:#f60;"><%=Request["totalprice"]%></span> </span>（<%=Request["renshu3"].Equals("0") ? "不含保险" : "已含保险"%>） </li>
            </ul>
          </div>
        </div>

        
      </section>

     <%-- <section class="main" id="order-con">
        <div class="plr10">
          <p class="order-tit-x mb10px">联系人信息</p>
          <div class="order-m">
            <ul>
              <li> 
                <label class = "label_hd">联&nbsp;系&nbsp;人</label>
                <span class="t2">
                <%=Request["xingming"]%>                </span>  </li>
              <li> 
                <label class = "label_hd">手机号码</label>
                <span class="t2"><%=Request["dianhua"]%></span>  </li>
            </ul>
          </div>
        </div>
      </section>--%>
        <div class="plr10">
<div class="form_btn"> 
<%--<%=Request["deal_type"].ToString().Equals(Convert.ToInt32(TravelAgent.Tool.EnumSummary.DealType.人工处理).ToString()) ? "" : "<a class=\"pay\"  href=\"../WapPayApi/Alipay/alipay_default.aspx?id="+Request["lineid"]+"&o=" + ordercode + "&subject=" + Request["linename"] + "【出发日期：" + Request["shijian1"] + "】&total_fee=" + Request["totalprice"] + "\" target=\"_blank\">支付宝支付</a>&nbsp; "%>   
                         
 <a class="cancel" href="weipay/confirmPay.aspx?o=<%=ordercode %>">微信支付</a>--%>
  <%=ShowPay() %>
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
