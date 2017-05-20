using System;
using System.Web.Http;
using EFC;

namespace efc_web.Controllers
{
    public class MotorController : ApiController
    {
        EngineManager engine_manager;
        IEngine engine;

        public MotorController()
        {
            engine_manager = EngineManager.main;
            engine = engine_manager.getEngine();
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
                return Ok(engine.GetFrequency());
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
                engine_manager.setFrequency(frequency);
                return Ok();
            }
            catch (EngineMessageException ex)
            {
                return Ok(ex.toMotorErrorMessage());
            }
        }

        [HttpGet]
        [Route("api/motor/getrpmreading")]
        public IHttpActionResult GetRpmReading()
        {
            return Ok(engine_manager.getRpmReading());
        }

        [HttpPost]
        [Route("api/motor/setrpmreading")]
        public IHttpActionResult SetRpmReading(float rpm)
        {
            engine_manager.setRpmReading(rpm);
            return Ok();
        }

        [HttpGet]
        [Route("api/motor/getrpmtarget")]
        public IHttpActionResult GetRpmTarget()
        {
            try
            {
                return Ok(engine_manager.getRpmTarget());
            }
            catch (Exception ex)
            {
                return Ok((new MotorError("invalid", ex.Message)).jsonSerialize());
            }
        }

        [HttpPost]
        [Route("api/motor/setrpmtarget")]
        public IHttpActionResult SetRpmTarget(float rpm)
        {
            engine_manager.setRpmTarget(rpm);
            return Ok();
        }
    }
}
