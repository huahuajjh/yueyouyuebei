using System.Net.Http;
using System.Web;
using System.Web.Http;
using TravelAgent.BLL;
using TravelAgent.Tool;
using TravelAgent.WebAPI.Areas.Models;

namespace TravelAgent.WebAPI.Areas.mobile.Controllers
{
    public class LoginController : ControllerBase
    {
        [HttpGet]
        public HttpResponseMessage Login(string _loginInput)
        {
            LoginInput loginInput = JsonUtil.ToObj<LoginInput>(_loginInput);

            if (null == loginInput)
            {
                return ToJsonp(null, 0, "参数错误");
            }

            Club clubService = new Club();
            TravelAgent.Model.Club club =  clubService.GetModel(loginInput.Account,loginInput.Pwd);
            if(null == club)
            {
                return ToJsonp(null,0,"用户名或者密码错误");
            }

            SetToken(club.id);

            return ToJsonp(new LoginOutput()
            {
                Account = club.clubName,
                Email = club.clubEmail,
                Gender = club.clubSex,
                Id = club.id,
                Name = club.trueName,
                Phone = club.clubMobile
            });

        }

        private void SetToken(int v)
        {
            HttpCookie cookie = new HttpCookie("token");
            cookie.Value = v.ToString();
            HttpContext.Current.Response.SetCookie(cookie);
            HttpContext.Current.Session.Add("token",v.ToString());
        }
    }
}
