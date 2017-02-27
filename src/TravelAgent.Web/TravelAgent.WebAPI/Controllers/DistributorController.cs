using System.Net.Http;
using TravelAgent.Model;
using TravelAgent.Tool;
using System.Web.Http;

namespace TravelAgent.WebAPI.Controllers
{
    public class DistributorController : ControllerBase
    {
        [HttpGet]
        public HttpResponseMessage SetContent(string content)
        {
            DistributorContent o = SerializationUtil.ToObj<DistributorContent>(content);
            if(null == o)
            {
                return ToJsonp(null,0,"参数错误");
            }
            FileRepository.FileRepository.GetInstance().Write<DistributorContent>(o,"DistributorContent.json");
            return ToJsonp(null,1,"修改成功",0);
        }

        [HttpGet]
        public HttpResponseMessage GetContent()
        {
            return ToJsonp(FileRepository.FileRepository.GetInstance().Read("DistributorContent.json")
                ,1,"success",0);
        }
    }
}
