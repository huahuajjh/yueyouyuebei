using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TravelAgent.IDAL;
using TravelAgent.IService;
using TravelAgent.Model;

namespace TravelAgent.BLL
{
    public class AreaService:ServiceBase,IAreaService
    {
        public IList<Area> GetByParent(int pid)
        {
            IAreaDao dao = GetDao<IAreaDao>("AreaDao");
            return dao.Get("Pid="+pid);
        }
    }
}
