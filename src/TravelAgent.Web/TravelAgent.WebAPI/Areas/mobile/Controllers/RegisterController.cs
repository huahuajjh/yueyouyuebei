using System.Net.Http;
using TravelAgent.WebAPI.Areas.Models;
using TravelAgent.Tool;
using TravelAgent.Model;
using System.Web.Http;
using TravelAgent.WebAPI.Areas.Filters;

namespace TravelAgent.WebAPI.Areas.mobile.Controllers
{
    public class RegisterController : ControllerBase
    {
        [HttpGet]
        public HttpResponseMessage Register(string registerInput)
        {
            RegisterInput input = JsonUtil.ToObj<RegisterInput>(registerInput);

            if(null == input)
            {
                return ToJsonp("参数错误");
            }

            Club club = Club.Register(input.Phone,input.Email,input.Pwd);
            TravelAgent.BLL.Club service = new BLL.Club();
            int r = service.Add(club);
            if(r == -1)
            {
                return ToJsonp("账户已存在");
            }

            return ToJsonp("恭喜你，注册成功");
        }
    }
}
