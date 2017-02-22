using System.Collections.Generic;
using System.Net.Http;
using System.Web.Http;
using TravelAgent.BLL;
using TravelAgent.IService;
using TravelAgent.Model;
using TravelAgent.WebAPI.Areas.Filters;

namespace TravelAgent.WebAPI.Areas.mobile.Controllers
{
    [AuthFilter]
    public class OrderController : ControllerBase
    {
        public IVOrderService Service{
            get {
                return GetService<IVOrderService>("VOrderService");
            }
        }

        [HttpGet]
        public HttpResponseMessage GetOrdersByUser(string userId)
        {
            List<VOrder> list = Service.SelectList("UserId="+userId, "StatusNo");
            return ToJsonp(list);
        }

        [HttpGet]
        public HttpResponseMessage GetNotPayOrder(string userId)
        {
            List<VOrder> list = Service.SelectList("StatusNo=4 AND UserId=" + userId);
            return ToJsonp(list);
        }

        [HttpGet]
        public HttpResponseMessage GetOrderDetails(string id)
        {
            VOrder o = Service.SelectOne(int.Parse(id));
            return ToJsonp(o);
        }
    }
}