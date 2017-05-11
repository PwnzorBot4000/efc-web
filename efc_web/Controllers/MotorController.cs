using System.Web.Http;
using EFC;

using VegaDrive = EFC.Engines.VegaDrive_15P0087B5;

namespace efc_web.Controllers
{
    public class MotorController : ApiController
    {
        private IEngine engine;

        public MotorController()
        {
            engine = new VegaDrive("/dev/ttyUSB0", 1);
        }

        [HttpGet]
        [Route("api/motor/status")]
        public IHttpActionResult Status()
        {
            try
            {
                EngineStatus s = engine.Status();
                return Ok(s.ToString());
            }
            catch (EngineMessageException)
            {
                return Ok("offline");
            }
        }
    }
}
