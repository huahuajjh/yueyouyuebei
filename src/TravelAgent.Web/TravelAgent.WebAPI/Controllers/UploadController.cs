using eh.impls;
using eh.impls.errs;
using eh.interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TravelAgent.IService;
using TravelAgent.Model;
using TravelAgent.WebAPI.Models;

namespace TravelAgent.WebAPI.Controllers
{
    public class UploadController : Controller
    {

        public UploadController()
        {
                
        }
        
        private ISchoolService Service
        {
            get
            {
                return DALFactory.DALBuild.GetObj<ISchoolService>("SchoolService");
            }
            set
            {

            }
        }

        [HttpPost]
        public string UploadSchool(HttpPostedFileBase file)
        {
            ErrMsg msg = new ErrMsg();
            IImport import = ExcelFactory.Instance().GetExcelImporter(new eh.impls.configurations.ExcelConfiguration(1, 0, 0), msg);
            IList<School> list = SchoolDto.ToList(import.Import<SchoolDto>(file.InputStream));

            if (msg.Count != 0)
            {
                return "fail";
            }
            else
            {
                Service.Add(list);
                return "success";
            }
        }

        [HttpPost]
        public string UploadRefs(HttpPostedFileBase file)
        {
            ErrMsg msg = new ErrMsg();
            IImport import = ExcelFactory.Instance().GetExcelImporter(new eh.impls.configurations.ExcelConfiguration(1, 0, 0), msg);
            IReferencesService s = DALFactory.DALBuild.GetObj<IReferencesService>("ReferencesService");
            IList<References> list = ReferencesDto.ToList(import.Import<ReferencesDto>(file.InputStream));

            if (msg.Count != 0)
            {
                return "fail";
            }
            else
            {
                s.Add(list);
                return "success";
            }
        }
    }
}
