﻿using TravelAgent.IService;
using System.Collections.Generic;
using TravelAgent.Model;
using System.IO;
using TravelAgent.IDAL;

namespace TravelAgent.BLL
{
    public class SchoolService:ServiceBase<ISchoolDao>,ISchoolService
    {
        public ISchoolDao Dao { 
            get
            {
                return GetDao("SchoolDao");
            } 

            set
            {
            } 
        }
        public IList<School> GetByAreaId(int area_id)
        {
            return Dao.Get("AreaId="+area_id);
        }

        public IList<School> GetByPage(int page_index, int page_count, out int total_page)
        {
            return Dao.Get("",page_index,page_count,out total_page);
        }

        public void Add(School s)
        {
            Dao.Add(s);
        }

        public void Add(IList<School> list)
        {
            Dao.AddRange(list);
        }

        public void Update(School s)
        {
            Dao.Update(s);
        }

        public void UploadExcelFile(Stream file)
        {
            
        }
    }
}