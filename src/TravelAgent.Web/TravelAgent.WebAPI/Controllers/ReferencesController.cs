
using eh.impls;
using eh.impls.errs;
using eh.interfaces;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http;
using TravelAgent.IService;
using TravelAgent.Model;
using TravelAgent.Tool;
using TravelAgent.WebAPI.Models;
namespace TravelAgent.WebAPI.Controllers
{
    public class ReferencesController : ControllerBase
    {
        public IReferencesService Service 
        { 
            get
            { 
                return GetService<IReferencesService>("ReferencesService");
            }
            set
            { }
        }
    
        [HttpPost]
        public HttpResponseMessage Add(string references)
        { 
            References r = JsonUtil.ToObj<References>(references);
            try
            {
                Service.Add(r);
                return ToJson("success");
            }
            catch (System.Exception ex)
            {
                return ToJson(ex.Message, status_code: 0, msg: ex.Message);
            }
        }

        [HttpPost]
        public HttpResponseMessage Update(string references)
        { 
            References r = JsonUtil.ToObj<References>(references);
            try
            {
                Service.Update(r);
                return ToJson("success");
            }
            catch (System.Exception ex)
            {
                return ToJson(ex.Message, status_code: 0, msg: ex.Message);
            }
        }

        [HttpPost]
        public HttpResponseMessage Upload()
        {
            HttpPostedFile file = HttpContext.Current.Request.Files["references"];
            ErrMsg msg = new ErrMsg();
            IImport import = ExcelFactory.Instance().GetExcelImporter(new eh.impls.configurations.ExcelConfiguration(1,0,0),msg);
            IList<References> list = ReferencesDto.ToList(import.Import<ReferencesDto>(file.InputStream));

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

        public HttpResponseMessage Get(int school_id)
        {
            return ToJson(Service.GetBySchoolId(school_id));
        }

        public HttpResponseMessage GetByPage(int index, int count)
        {
            int total = 0;
            IList<References> list = Service.GetByPage(index, count, out total);
            return ToJson(list, total: total);
        }

        public HttpResponseMessage GetBySchoolName(string sch_name)
        {
            IQueryReferencesService service = GetService<IQueryReferencesService>("QueryReferencesService");
            IList<References> refs =  service.GetRefsBySchoolName(sch_name);
            return ToJson(refs);            
        }

        public HttpResponseMessage GetById(int id)
        {
            return ToJson(Service.GetById(id));
        }
    }
}
