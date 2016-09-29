using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Web;
using System.Web.Http;
using TravelAgent.DALFactory;
using TravelAgent.Tool;
using TravelAgent.WebAPI.Models;

namespace TravelAgent.WebAPI.Controllers
{
    public abstract class ControllerBase : ApiController
    {
        protected T GetService<T>(string class_name)
        {
            return DALBuild.GetObj<T>("BLL",class_name);
        }

        protected HttpResponseMessage ToJson(object o,int status_code=1,string msg="success",int total=0)
        {               
            JsonFormat jf = new JsonFormat(){ Code=status_code, Data=o, Msg=msg, TotalCount=total};
            string json = JsonUtil.ToJson(jf);
            HttpResponseMessage res = new HttpResponseMessage{ Content=new StringContent(json,Encoding.GetEncoding("UTF-8"),"application/json")};
            return res;
        }
    }
}