using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Text;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace TravelAgent.Web
{
    public partial class M_Default : TravelAgent.Web.UI.mBasePage
    {
        public string bannerstring;
        private static readonly TravelAgent.BLL.Adbanner bannerBll = new TravelAgent.BLL.Adbanner();
        //public TravelAgent.Model.WebInfo webinfo;
        private static readonly TravelAgent.BLL.Line LineBll = new TravelAgent.BLL.Line();
        private static readonly TravelAgent.BLL.Category CateBll = new TravelAgent.BLL.Category();
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        /// <summary>
        /// 绑定
        /// </summary>
        /// <returns></returns>
        public string BindBanner(int aid)
        {
            StringBuilder sbBanner = new StringBuilder();
            DataSet dsBanner = bannerBll.GetList(0, "IsLock=0 and Aid=" + aid, "AddTime desc");
            DataRow row = null;
            for (int i = 0; i < dsBanner.Tables[0].Rows.Count; i++)
            {
                row = dsBanner.Tables[0].Rows[i];
                //bannerstring += "<a href=\"javascript:;\">" + (i + 1) + "</a>";
                bannerstring += "<a href=\"javascript:;\"></a>";
                sbBanner.Append("<li><a href=\"javascript:void(0);" + Server.UrlEncode(row["Title"].ToString()) + "\"><img id=\"main_img_" + (i + 1) + "\" src=\"" + row["AdUrl"] + "\" alt=\"" + row["Title"] + "\" /></a></li>");
            }
            return sbBanner.ToString();
        }
        /// <summary>
        /// 绑定推荐产品
        /// </summary>
        /// <returns></returns>
        public string BindLine(int top, int state)
        {
            StringBuilder sbLine = new StringBuilder();
            //Access
            //DataSet dsLine = LineBll.GetList(top, "InStr(State,'," + state + ",')>0 and isLock=0", "Sort asc,adddate desc");
            //SQL
            DataSet dsLine = LineBll.GetList(top, "CHARINDEX('," + state + ",',State)>0 and isLock=0", "Sort asc,adddate desc");
            foreach (DataRow row in dsLine.Tables[0].Rows)
            {
                sbLine.Append("<li>");
                sbLine.Append("<a href=\"mTravel/LineDetail.aspx?id=" + row["Id"] + "\">");
                sbLine.Append("<img src=\"" + row["linePic"] + "\">");
                sbLine.Append("<div class=\"wx-tuijian-data-money\"><p>￥<span>" + row["priceCommon"]+ "</span>起</p></div>");
                sbLine.Append("<div class=\"wx-tuijian-data-info\">");
                sbLine.Append("<div class=\"wx-tuijian-data-title\"><div class=\"wx-tuijian-data-title-val\">" + row["lineName"] + "<span class=\"wx-tuijian-data-hot\"></span></div></div>");
                sbLine.Append("<span class=\"wx-tuijian-data-span\">" + row["dayNumber"] + "日游</span>");
                sbLine.Append("</div>");
                sbLine.Append("</a>");
                sbLine.Append("</li>");
            }
            return sbLine.ToString();
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
                sbBottomNav.Append("<a href=\"mTravel/Article.aspx?id=" + dsNav.Tables[0].Rows[i]["Id"] + "\">" + dsNav.Tables[0].Rows[i]["Title"] + "</a>|");
            }
            return sbBottomNav.ToString().Remove(sbBottomNav.Length - 1);
        }
    }
}
