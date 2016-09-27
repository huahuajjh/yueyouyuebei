using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TravelAgent.Model;

namespace TravelAgent.IDAL
{
    public interface ISchool
    {
        void Add(School s);
        void AddRange(IList<School> ss);
        int Update(School s);
        int Del(int id);
        School Get(int id);
        IList<School> Get(string where, params string[] parameters);
        IList<School> Get(string where, int page_index, int page_count, out int total_page, params string[] parameters);
    }
}
