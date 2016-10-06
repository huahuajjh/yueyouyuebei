
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
    
        [HttpGet]
        public HttpResponseMessage Add()
        { 
            string references = HttpContext.Current.Request.QueryString["references"];
            try
            {
                References r = JsonUtil.ToObj<References>(references);
                Service.Add(r);
                return ToJsonp("success");
            }
            catch (System.Exception ex)
            {
                return ToJsonp(ex.Message, status_code: 0, msg: ex.Message);
            }
        }

        [HttpGet]
        public HttpResponseMessage Update()
        {
            string references = HttpContext.Current.Request.QueryString["references"];            
            try
            {
                References r = JsonUtil.ToObj<References>(references);
                Service.Update(r);
                return ToJsonp("success");
            }
            catch (System.Exception ex)
            {
                return ToJsonp(ex.Message, status_code: 0, msg: ex.Message);
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
        
        [HttpGet]
        public HttpResponseMessage Get(int school_id)
        {
            return ToJsonp(Service.GetBySchoolId(school_id));
        }

        [HttpGet]
        public HttpResponseMessage GetByPage(int index, int count)
        {
            int total = 0;
            IList<References> list = Service.GetByPage(index, count, out total);
            return ToJsonp(list, total: total);
        }

        [HttpGet]
        public HttpResponseMessage GetBySchoolName(string sch_name)
        {
            IQueryReferencesService service = GetService<IQueryReferencesService>("QueryReferencesService");
            IList<References> refs =  service.GetRefsBySchoolName(sch_name);
            return ToJsonp(refs);            
        }

        [HttpGet]
        public HttpResponseMessage GetById(int id)
        {
            return ToJsonp(Service.GetById(id));
        }
    }
}
