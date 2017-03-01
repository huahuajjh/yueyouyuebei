using System;
using System.Data;
using System.Text;
using TravelAgent.Tool;

namespace TravelAgent.Web
{
    public partial class M_Default : TravelAgent.Web.UI.mBasePage
    {
        public string bannerstring;
        private static readonly TravelAgent.BLL.Adbanner bannerBll = new TravelAgent.BLL.Adbanner();
        //public TravelAgent.Model.WebInfo webinfo;
        private static readonly TravelAgent.BLL.Line LineBll = new TravelAgent.BLL.Line();
        private static readonly TravelAgent.BLL.Category CateBll = new TravelAgent.BLL.Category();
        private TravelAgent.BLL.WebNav NavBll = new TravelAgent.BLL.WebNav();
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

        public string BindWebNav()
        {
            StringBuilder strNav = new StringBuilder();
            DataSet dsNav = NavBll.GetNavListByParentId(0, null);
            foreach (DataRow row in dsNav.Tables[0].Rows)
            {
                if (row["navName"].ToString().Contains("签证"))
                {
                    strNav.Append(string.Format("<li class=\"wx-menu-qianzheng\"><a href = \"{0}\">{1}</a></li>", "mTravel/VisaModel.aspx", row["navName"]));
                }

                else if (row["navName"].ToString().Contains("常规"))
                {
                    strNav.Append(string.Format("<li class=\"wx-menu-changgui\"><a href = \"{0}\">{1}</a></li>", "mTravel/LineList.aspx?d=1", row["navName"]));
                }

                else if (row["navName"].ToString().Contains("主题"))
                {
                    strNav.Append(string.Format("<li class=\"wx-menu-zhuti\"><a href = \"{0}\">{1}</a></li>", "mTravel/LineTheme.aspx", row["navName"]));
                }

                else if (row["navName"].ToString().Contains("首页"))
                {
                    continue;
                }

                else if (row["navName"].ToString().Contains("纯玩"))
                {
                    strNav.Append(string.Format("<li class=\"wx-menu-zhoubian\"><a href = \"{0}\">{1}</a></li>", "mTravel/LineList.aspx?d=3", row["navName"]));
                }

                else if (row["navName"].ToString().Contains("出游"))
                {
                    strNav.Append(string.Format("<li class=\"wx-menu-huwai\"><a href = \"{0}\">{1}</a></li>", "mTravel/LineList.aspx?d=2", row["navName"]));
                }

                else if (row["navName"].ToString().Contains("分销"))
                {
                    strNav.Append(string.Format("<li class=\"wx-menu-tejia\"><a href = \"{0}\">{1}</a></li>", "http://distributor.yueyouyuebei.com:8888/Default.aspx", row["navName"]));
                }
                else { }
            }
            return strNav.ToString();
        }
    }
}
