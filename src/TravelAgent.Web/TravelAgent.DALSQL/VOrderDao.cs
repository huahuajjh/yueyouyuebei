using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using TravelAgent.IDAL;
using TravelAgent.Model;
using TravelAgent.Tool;

namespace TravelAgent.DALSQL
{
    public class VOrderDao : IVOrderDao
    {
        public List<VOrder> SelectList(string where, string order = "Id")
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("SELECT * FROM v_order WHERE 0=0 AND").
                Append(" ").
                Append(where).
                Append(" ").
                Append("ORDER BY").
                Append(" ").
                Append(order);

            DataSet ds = DbHelperSQL.Query(sb.ToString());

            if(null == ds || ds.Tables.Count <= 0)
            {
                return null;
            }

            IList<VOrder> list = DbHelperSQL.DT2List<VOrder>(ds.Tables[0]);

            return (List<VOrder>)list;
        }

        public VOrder SelectOne(int id)
        {
            string sql = "SELECT * FROM v_order WHERE id="+id;

            DataSet ds = DbHelperSQL.Query(sql);

            if (null == ds || ds.Tables.Count <= 0)
            {
                return null;
            }

            IList<VOrder> list = DbHelperSQL.DT2List<VOrder>(ds.Tables[0]);

            return list == null || list.Count <= 0 ? null : list[0];
        }
    }
}
