using System.Collections.Generic;
using TravelAgent.IDAL;
using TravelAgent.IService;
using TravelAgent.Model;

namespace TravelAgent.BLL
{
    public class VOrderService : ServiceBase<IVOrderDao>, IVOrderService
    {

        public IVOrderDao Dao
        {
            get
            {
                return GetDao("VOrderDao");
            }
        }

        public List<VOrder> SelectList(string where, string order = "Id")
        {
           return Dao.SelectList(where,order);
        }

        public VOrder SelectOne(int id)
        {
            return Dao.SelectOne(id);
        }
    }
}
