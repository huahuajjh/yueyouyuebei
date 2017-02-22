using System.Net;
using System.Web.Http.Controllers;
using System.Web.Http.Filters;
using System.Net.Http;
using System.Web;
using TravelAgent.WebAPI.Models;
using TravelAgent.Tool;
using System.Text;

namespace TravelAgent.WebAPI.Areas.Filters
{
    public class AuthFilterAttribute : ActionFilterAttribute
    {
        public override void OnActionExecuting(HttpActionContext actionContext)
        {
            object clientToken = HttpContext.Current.Request.Cookies.Get("token");
            object serverToken = HttpContext.Current.Session["token"];

            if(null == clientToken || null == serverToken || !((serverToken.ToString().Equals(((HttpCookie)clientToken).Value))))
            {
                actionContext.Response = ToJsonp(null,-1, "请登录");
                return;
            }

        }

        protected HttpResponseMessage ToJsonp(object o, int status_code = 1, string msg = "success", int total = 0)
        {
            string callback = HttpContext.Current.Request.QueryString["callback"];

            if (!string.IsNullOrEmpty(callback))
            {
                JsonFormat jf = new JsonFormat() { Code = status_code, Data = o, Msg = msg, TotalCount = total };
                string json = JsonUtil.ToJson(jf);
                string script = callback + "(" + json + ")";
                HttpResponseMessage res = new HttpResponseMessage { Content = new StringContent(script, Encoding.GetEncoding("UTF-8"), "application/json") };
                return res;
            }
            else
            {
                return new HttpResponseMessage { Content = new StringContent("not jsonp", Encoding.GetEncoding("UTF-8"), "application/json") }; ;
            }
        }
    }
}