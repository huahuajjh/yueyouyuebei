using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.Http;
using TravelAgent.IService;

namespace TravelAgent.WebAPI.Controllers
{
    public class ReferencesSchoolController:ControllerBase
    {
        public IReferencesSchoolService Service
        {
            get
            {
                return GetService<IReferencesSchoolService>("ReferencesSchoolService");
            }
            set
            { }
        }

        [HttpGet]
        public HttpResponseMessage GetByFuzzy()
        { 
            string fuzzy = HttpContext.Current.Request.QueryString["fuzzy"];
            return  ToJsonp(Service.GetByFuzzyName(fuzzy));
        }

        [HttpGet]
        public HttpResponseMessage GetBySchId(int sid)
        { 
            return ToJsonp(Service.GetBySchoolId(sid));
        }

        [HttpGet]
        public HttpResponseMessage GetByPage(int sid,int index,int count)
        { 
            int total = 0;
            return ToJsonp(Service.GetBySchoolId(sid, index, count, out total),total:total);
        }
    }
}