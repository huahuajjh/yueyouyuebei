using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Text;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace TravelAgent.Web.mTravel
{
    public partial class MOrderTips : TravelAgent.Web.UI.mBasePage
    {
        public string ordercode = "";
        private static readonly TravelAgent.BLL.Category CateBll = new TravelAgent.BLL.Category();
        private static readonly TravelAgent.BLL.Order OrderBll = new TravelAgent.BLL.Order();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!this.IsPostBack)
            {
                if (Request["lineid"] != null)
                {
                    TravelAgent.Model.Order order = new TravelAgent.Model.Order();
                    order.lineId = Convert.ToInt32(Request["lineid"]);
                    ordercode = "O" + DateTime.Now.ToString("yyyyMMddHHmmssfff");
                    order.ordercode = ordercode;
                    order.peopleNumber = Convert.ToInt32(Request["renshu1"])+Convert.ToInt32(Request["renshu2"]);
                    order.adultNumber = Convert.ToInt32(Request["renshu1"]);
                    order.childNumber = Convert.ToInt32(Request["renshu2"]);
                    order.orderDate = DateTime.Now;
                    order.TravelDate = Request["shijian1"];
                    order.orderPrice = Convert.ToInt32(Request["adult_price"]) * Convert.ToInt32(Request["renshu1"]) + Convert.ToInt32(Request["child_price"]) * Convert.ToInt32(Request["renshu2"]);
                    order.attachPrice = Convert.ToInt32(Request["bx_price"]) * Convert.ToInt32(Request["renshu3"]);
                    order.usePoints = 0;
                    order.donatePoints = 0;
                    order.contactName = Request["xingming"];
                    order.contactMobile = Request["dianhua"];
                    order.contactEmail = "";
                    order.contactTelephone = "";
                    order.orderRemark = "";
                    order.operRemark = "";
                    order.orderState = Convert.ToInt32(TravelAgent.Tool.EnumSummary.OrderState.处理中);
                    order.clubid = 0;
                    order.adultPrice = 0;
                    order.childPrice = 0;
                    order.payType = 0;
                    order.subPrice = 0;

                    order.orderType = Convert.ToInt32(Request["order_type"]);
                    order.contactSex = "";
                    order.sourceType = Convert.ToInt32(TravelAgent.Tool.EnumSummary.SourceType.移动WAP);
                    try
                    {
                        int orderid = OrderBll.Add(order);

                        if (orderid < 0)
                        {
                            Response.Redirect("MOrderMsg.aspx?msg=订单提交失败&class=error", false);
                        }
                        
                    }
                    catch (Exception ex)
                    {
                        Response.Redirect("MOrderMsg.aspx?msg=订单提交失败&class=error", false);
                    }
                }
            }
        }
        /// <summary>
        /// 绑定底部导航
        /// </summary>
        /// <param name="top"></param>
        /// <returns></returns>
        public string BindBottonNav(int top, int parentid)
        {
            StringBuilder sbBottomNav = new StringBuilder();
            DataSet dsNav = CateBll.GetChannelListByParentId(parentid, top);
            for (int i = 0; i < dsNav.Tables[0].Rows.Count; i++)
            {
                sbBottomNav.Append("<a href=\"Article.aspx?id=" + dsNav.Tables[0].Rows[i]["Id"] + "\">" + dsNav.Tables[0].Rows[i]["Title"] + "</a>|");
            }
            return sbBottomNav.ToString().Remove(sbBottomNav.Length - 1);
        }
        /// <summary>
        /// 显示支付方式
        /// </summary>
        /// <returns></returns>
        public string ShowPay()
        {
            StringBuilder sbpay = new StringBuilder();
            if (Convert.ToInt32(Request["deal_type"]).Equals(Convert.ToInt32(TravelAgent.Tool.EnumSummary.DealType.自动处理)) && webinfo.AlipayIslock == 1)
            {
                sbpay.Append("<a class=\"pay\"  href=\"../WapPayApi/Alipay/alipay_default.aspx?id=" + Request["lineid"] + "&o=" + ordercode + "&subject=" + Request["linename"] + "【出发日期：" + Request["shijian1"] + "】&total_fee=" + Request["totalprice"] + "\" target=\"_blank\">支付宝支付</a>&nbsp; ");
            }
            if (Convert.ToInt32(Request["deal_type"]).Equals(Convert.ToInt32(TravelAgent.Tool.EnumSummary.DealType.自动处理)) && webinfo.WxpayIsLock == 1)
            {
                sbpay.Append("<a class=\"cancel\" href=\"weipay/confirmPay.aspx?o=" + ordercode + "\">微信支付</a>");
            }
            return sbpay.ToString();
        }
    }
}
