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
            catch (EngineMessageException ex)
            {
                if (ex.keyword == "offline")
                    return Ok("offline");
                else
                    return Ok(ex.toMotorErrorMessage());
            }
        }

        [HttpPost]
        [Route("api/motor/start")]
        public IHttpActionResult Start()
        {
            try
            {
                engine.Start();
                return Ok();
            }
            catch (EngineMessageException ex)
            {
                return Ok(ex.toMotorErrorMessage());
            }
        }

        [HttpPost]
        [Route("api/motor/stop")]
        public IHttpActionResult Stop()
        {
            try
            {
                engine.Stop();
                return Ok();
            }
            catch (EngineMessageException ex)
            {
                return Ok(ex.toMotorErrorMessage());
            }
        }

        [HttpPost]
        [Route("api/motor/reverse")]
        public IHttpActionResult Reverse()
        {
            try
            {
                engine.Reverse();
                return Ok();
            }
            catch (EngineMessageException ex)
            {
                return Ok(ex.toMotorErrorMessage());
            }
        }

        [HttpPost]
        [Route("api/motor/reset")]
        public IHttpActionResult Reset()
        {
            try
            {
                engine.Reset();
                return Ok();
            }
            catch (EngineMessageException ex)
            {
                return Ok(ex.toMotorErrorMessage());
            }
        }

        [HttpPost]
        [Route("api/motor/emergencystop")]
        public IHttpActionResult EmergencyStop()
        {
            try
            {
                engine.EmergencyStop();
                return Ok();
            }
            catch (EngineMessageException ex)
            {
                return Ok(ex.toMotorErrorMessage());
            }
        }

        [HttpGet]
        [Route("api/motor/getfrequency")]
        public IHttpActionResult GetFrequency()
        {
            try
            {
                engine.GetFrequency();
                return Ok();
            }
            catch (EngineMessageException ex)
            {
                return Ok(ex.toMotorErrorMessage());
            }
        }

        [HttpPost]
        [Route("api/motor/setfrequency")]
        public IHttpActionResult SetFrequency(float frequency)
        {
            try
            {
                engine.SetFrequency(frequency);
                return Ok();
            }
            catch (EngineMessageException ex)
            {
                return Ok(ex.toMotorErrorMessage());
            }
        }
    }
}
