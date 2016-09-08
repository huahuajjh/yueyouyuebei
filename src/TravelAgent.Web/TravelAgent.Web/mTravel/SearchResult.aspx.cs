﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Text;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace TravelAgent.Web.mTravel
{
    public partial class SearchResult : TravelAgent.Web.UI.mBasePage
    {
        public int d;
        public int fd;
        public int td;
        public string key="";
        private static readonly TravelAgent.BLL.Line LineBll = new TravelAgent.BLL.Line();
        private static readonly TravelAgent.BLL.Destination DestBll = new TravelAgent.BLL.Destination();
        private static readonly TravelAgent.BLL.Category CateBll = new TravelAgent.BLL.Category();
        private static readonly TravelAgent.BLL.DepartureCity CityBll = new TravelAgent.BLL.DepartureCity();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request["keyword"] != null)
            {
                key = Request["keyword"];
            }
            if (Request.QueryString["fd"] != null)
            {
                fd = Convert.ToInt32(Request.QueryString["fd"]);
            }
            if (Request.QueryString["td"] != null)
            {
                td = Convert.ToInt32(Request.QueryString["td"]);
            }
            if (Request["d"] != null)
            {
                d = Convert.ToInt32(Request["d"]);
            }
        }
        /// <summary>
        /// 绑定搜索结果
        /// </summary>
        /// <returns></returns>
        public string BindSearchLine()
        {
            StringBuilder sbLine = new StringBuilder();
            string strwhere = "";
            if (key != "")
            { 
                strwhere = "lineName like '%" + key + "%' and isLock=0";
            }
            if (fd > 0)
            {
                DataSet dsDest = DestBll.GetDestListByParentId(fd, null);
                foreach (DataRow row in dsDest.Tables[0].Rows)
                {
                    strwhere += "CHARINDEX('," + row["Id"] + ",',dest)>0 and ";
                }
                if (strwhere != "")
                { 
                    strwhere += " isLock=0";
                }
            }
            if (td > 0)
            {
                strwhere = "CHARINDEX('," + td + ",',dest)>0 and isLock=0";
            }
            if (strwhere != "")
            {
                DataSet dsLine = LineBll.GetList(0, strwhere, "Sort asc,adddate desc");
                foreach (DataRow row in dsLine.Tables[0].Rows)
                {
                    sbLine.Append("<div class=\"show_line_box\">");
                    sbLine.Append("<a href=\"LineDetail.aspx?id=" + row["Id"] + "\" class=\"show_line_con\">");
                    sbLine.Append("<img src=\"" + row["linePic"] + "\" />");
                    if (row["priceCommon"].ToString().Equals("0") || row["priceCommon"].ToString().Equals(""))
                    {
                        sbLine.Append("<span class=\"show_line_jia\">电询</span>");
                    }
                    else
                    {
                        sbLine.Append("<span class=\"show_line_jia\">¥&nbsp;" + row["priceCommon"] + "</span>");
                    }

                    sbLine.Append("</a>");
                    sbLine.Append("<a href=\"LineDetail.aspx?id=" + row["Id"] + "\" class=\"show_line_tit\">");
                    sbLine.Append("<strong>" + row["lineName"] + "</strong>");
                    sbLine.Append("<p>");
                    sbLine.Append("<span>" + CityBll.GetModel(Convert.ToInt32(row["cityId"])).CityName + "出发</span>|");
                    sbLine.Append("<span>" + row["dayNumber"] + "日游</span>|");
                    sbLine.Append("<span>关注：" + row["gzd"] + "</span>");
                    sbLine.Append("</p>");
                    sbLine.Append("</a>");
                    sbLine.Append("</div>");
                }
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
                sbBottomNav.Append("<a href=\"Article.aspx?id=" + dsNav.Tables[0].Rows[i]["Id"] + "\">" + dsNav.Tables[0].Rows[i]["Title"] + "</a>|");
            }
            return sbBottomNav.ToString().Remove(sbBottomNav.Length - 1);
        }
        /// <summary>
        /// 绑定分类导航
        /// </summary>
        /// <returns></returns>
        public string BindNav()
        {
            StringBuilder sbDest = new StringBuilder();
            DataTable dtDest = DestBll.GetList(d, 0);
            DataRow[] FristRows = dtDest.Select("navLayer=2", "navSort asc");
            DataRow row = null;
            for (int i = 0; i < FristRows.Length; i++)
            {
                row = FristRows[i];
                sbDest.Append("<li>");
                sbDest.Append("<em>");
                sbDest.Append("<a href=\"LineDest.aspx?d=" + d + "&fd=" + row["Id"] + "&name=" + row["navName"] + "\">" + row["navName"] + "</a>");
                sbDest.Append("<span class=\"robtn\"></span>");
                sbDest.Append("</em>");
                sbDest.Append("<div class=\"rocon\">");
                DataRow[] destRows = dtDest.Select("isLock=0 and navParentId=" + row["Id"], "navSort asc");
                foreach (DataRow r in destRows)
                {
                    sbDest.Append("<a href=\"LineDest.aspx?td=" + r["Id"] + "&name=" + r["navName"] + "\">" + r["navName"] + "</a>");
                }
                sbDest.Append("</div>");
                sbDest.Append("</li>");
            }
            return sbDest.ToString();
        }
    }
}