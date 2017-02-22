using System.Collections.Generic;
using TravelAgent.Model;

namespace TravelAgent.IService
{
    public interface IVOrderService
    {
        List<VOrder> SelectList(string where, string order = "Id");
        VOrder SelectOne(int id);
    }
}
