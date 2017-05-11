using System.Web.Http;

namespace efc_web.Controllers
{
    public class MotorController : ApiController
    {
        [HttpGet]
        [Route("api/motor/status")]
        public IHttpActionResult Status()
        {
            return Ok(42);
        }
    }
}
