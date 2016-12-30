using System.Web.Http;

namespace OWINWebAPI.Controllers
{
    public class HomeController : ApiController
    {
        [HttpGet]
        [Route("")]
        public string Index()
        {
            return "Web API Started successfully";
        }
    }
}