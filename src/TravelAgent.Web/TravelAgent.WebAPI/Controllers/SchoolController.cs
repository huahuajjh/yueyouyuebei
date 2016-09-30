using eh.impls; 
using eh.impls.errs;
using eh.interfaces;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Net.Http;
using System.Web;
using System.Web.Http;
using TravelAgent.IService;
using TravelAgent.Model;
using TravelAgent.Tool;
using TravelAgent.WebAPI.Models;

namespace TravelAgent.WebAPI.Controllers
{
    public class SchoolController : ControllerBase
    {
        private ISchoolService Service 
        {
            get 
            {
                return GetService<ISchoolService>("SchoolService");
            }
            set 
            {
                
             }
        }
        public HttpResponseMessage Get(int area_id)
        { 
            return ToJson(Service.GetByAreaId(area_id));
        }

        public HttpResponseMessage GetByPage(int index,int count)
        { 
            int total = 0;
            IList<School> list = Service.GetByPage(index,count,out total);
            return ToJson(list,total:total);
        }

        [HttpPost]
        public HttpResponseMessage Add(string school)
        {
            School s = JsonUtil.ToObj<School>(school);
            try
            {
                Service.Add(s);
                return ToJson("success");
            }
            catch (System.Exception ex)
            {
                return ToJson(ex.Message, status_code: 0, msg: ex.Message);
            }
        }

        [HttpPost]
        public HttpResponseMessage Upload(HttpPostedFile file)
        { 
            //Service.UploadExcelFile(file.InputStream);
            ErrMsg msg = new ErrMsg();
            IImport import = ExcelFactory.Instance().GetExcelImporter(new eh.impls.configurations.ExcelConfiguration(1, 0, 0), msg);
            IList<School> list = SchoolDto.ToList(import.Import<SchoolDto>(file.InputStream));

            if(msg.Count!=0)
            { 
                return ToJson(msg.GetErrors(),status_code:0,msg:"fail");
            }
            else
            {
                Service.Add(list);
                return ToJson("success");
            }
        }

        [HttpPost]
        public HttpResponseMessage Update(string school)
        {
            School s = JsonUtil.ToObj<School>(school);
            try
            {
                Service.Update(s);
                return ToJson("success");
            }
            catch (System.Exception ex)
            {
                return ToJson(ex.Message, status_code: 0, msg: ex.Message);
            }
        }

    }
}
