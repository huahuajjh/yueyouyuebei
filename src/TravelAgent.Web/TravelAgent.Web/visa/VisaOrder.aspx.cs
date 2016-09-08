using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace TravelAgent.Web.visa
{
    public partial class VisaOrder : System.Web.UI.Page
    {
        public TravelAgent.Model.VisaList visa;
        public TravelAgent.Model.Club club;
        private static readonly TravelAgent.BLL.VisaList VisaListBll = new TravelAgent.BLL.VisaList();
        //private static readonly TravelAgent.BLL.VisaOrder VisaOrderBll = new TravelAgent.BLL.VisaOrder();
        private static readonly TravelAgent.BLL.Club ClubBll = new TravelAgent.BLL.Club();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!this.IsPostBack)
            {
                if (Request.QueryString["id"] != null)
                {
                    visa = VisaListBll.GetModel(Convert.ToInt32(Request.QueryString["id"]));
                    this.Title = visa.visaName + "-" + Master.webinfo.WebName;
                }
                if (!string.IsNullOrEmpty(TravelAgent.Tool.CookieHelper.GetCookieValue("uid")))
                {
                    int uid = Convert.ToInt32(TravelAgent.Tool.CookieHelper.GetCookieValue("uid"));
                    club = ClubBll.GetModel(uid);
                }
            }
        }
        /// <summary>
        /// 显示性别
        /// </summary>
        /// <returns></returns>
        public string ShowOptionSex()
        {
            string stroption = "<option selected=\"selected\" value=\"1\">男</option><option value=\"0\">女</option>";
            if (club != null)
            {
                if (club.clubSex.Equals(""))
                {
                    if (club.clubSex.Equals("0"))
                    {
                        stroption = "<option value=\"1\">男</option><option selected=\"selected\" value=\"0\">女</option>";
                    }
                }
            }
            return stroption;
        }
    }
}
