using System;
using System.ComponentModel;
using EFC;

namespace efc_web
{
    public class EngineManager
    {
        public enum FeedbackMode
        {
            FixedFrequency,
            FixedRPM
        }

        static EngineManager instance;
        BackgroundWorker manager_process;
        IEngine engine;

        float last_rpm = 0;
        FeedbackMode _feedback_mode = FeedbackMode.FixedFrequency;
        float rpm_target;

        public static void initialize()
        {
            if (instance == null)
                instance = new EngineManager();
        }

        public static EngineManager main
        {
            get
            {
                return instance;
            }
        }

        EngineManager()
        {
            engine = new EFC.Engines.VegaDrive_15P0087B5("/dev/ttyUSB0", 1);

            manager_process = new BackgroundWorker();
            manager_process.DoWork += manager_process_main;
            manager_process.RunWorkerAsync();
        }

        void manager_process_main(object sender, DoWorkEventArgs e)
        {
        }

        public IEngine getEngine()
        {
            return engine;
        }

        public FeedbackMode feedback_mode
        {
            get
            {
                return _feedback_mode;
            }
        }

        public void setFrequency(float frequency)
        {
            var prev_feedback_mode = feedback_mode;
            _feedback_mode = FeedbackMode.FixedFrequency;
            try
            {
                engine.SetFrequency(frequency);
            }
            catch (EngineMessageException)
            {
                _feedback_mode = prev_feedback_mode;
                throw;
            }
        }

        public float getRpmReading()
        {
            return last_rpm;
        }

        public void setRpmReading(float rpm)
        {
            last_rpm = rpm;

            // Control
            if (engine.Status () == EngineStatus.Running &&
                rpm > 10) {
                if (rpm < rpm_target - 15)
                    engine.SetFrequency (engine.GetFrequency () + 0.1);
                else if (rpm > rpm_target + 15)
                    engine.SetFrequency (engine.GetFrequency () - 0.1);
            }
        }

        public float getRpmTarget()
        {
            if (feedback_mode != FeedbackMode.FixedRPM)
                throw new Exception("Not on fixed RPM mode");
            return rpm_target;
        }

        public void setRpmTarget(float rpm)
        {
            _feedback_mode = FeedbackMode.FixedRPM;
            rpm_target = rpm;
        }
    }
}
