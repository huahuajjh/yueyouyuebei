using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using TravelAgent.IService;
using TravelAgent.Model;
using TravelAgent.Tool;

namespace TravelAgent.WebAPI.Controllers
{
    public class AreaController : ControllerBase
    {
        public HttpResponseMessage Get(int pid)
        {
            IList<Area> list = GetService<IAreaService>("AreaService").GetByParent(pid);
            return ToJson(list);
        }

        public HttpResponseMessage GetByPage(string page)
        {
           return null;
        }
    }
}
