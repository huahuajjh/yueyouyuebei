using System.Net.Http;
using System.Web.Http;
using TravelAgent.BLL;
using TravelAgent.WebAPI.Areas.Filters;

namespace TravelAgent.WebAPI.Areas.mobile.Controllers
{
    [AuthFilter]    
    public class UserController : ControllerBase
    {
        public Club Service
        {
            get
            {
                return new Club();
            }
        }
        
        [HttpGet]
        public HttpResponseMessage ChangePwd(string userId,string oldPwd,string newPwd)
        {
            TravelAgent.Model.Club o = Service.GetModel(int.Parse(userId));
            if(null == o)
            {
                return ToJsonp(null,msg:"修改失败，不存在的用户id",status_code:0);
            }

            if (!(o.clubPwd.Equals(oldPwd)))
            {
                return ToJsonp(null,msg:"修改失败，旧密码错误", status_code: 0);
            }

            o.clubPwd = newPwd;

            Service.Update(o);

            return ToJsonp(msg:"修改成功");
        }

        [HttpGet]
        public HttpResponseMessage ChangeName(string userId,string name)
        {
            TravelAgent.Model.Club o = Service.GetModel(int.Parse(userId));
            if (null == o)
            {
                return ToJsonp(null,msg:"修改失败，不存在的用户id", status_code: 0);
            }

            o.trueName = name;

            Service.Update(o);

            return ToJsonp(msg:"修改成功");
        }

        [HttpGet]
        public HttpResponseMessage ChangeTel(string userId, string tel)
        {
            TravelAgent.Model.Club o = Service.GetModel(int.Parse(userId));
            if (null == o)
            {
                return ToJsonp(null, msg: "修改失败，不存在的用户id", status_code: 0);
            }

            o.clubMobile = tel;

            Service.Update(o);

            return ToJsonp(msg:"修改成功");
        }

        [HttpGet]
        public HttpResponseMessage ChangeEmail(string userId, string email)
        {
            TravelAgent.Model.Club o = Service.GetModel(int.Parse(userId));
            if (null == o)
            {
                return ToJsonp(null, msg: "修改失败，不存在的用户id", status_code: 0);
            }

            o.clubEmail = email;

            Service.Update(o);
            
            return ToJsonp(msg:"修改成功");
        }

        [HttpGet]
        public HttpResponseMessage ChangeGender(string userId, string gender)
        {
            TravelAgent.Model.Club o = Service.GetModel(int.Parse(userId));
            if (null == o)
            {
                return ToJsonp(null, msg: "修改失败，不存在的用户id", status_code: 0);
            }

            o.clubSex = gender;

            Service.Update(o);

            return ToJsonp(msg:"修改成功");
        }
    }
}