using System.Collections.Generic;
using TravelAgent.Model;

namespace TravelAgent.IDAL
{
    public interface IVOrderDao
    {
        List<VOrder> SelectList(string where,string order="Id");
        VOrder SelectOne(int id);
    }
}
