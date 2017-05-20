using System.ComponentModel;
using EFC;

namespace efc_web
{
    public class EngineManager
    {
        static EngineManager instance;
        BackgroundWorker manager_process;
        IEngine engine;

        float last_rpm = 0;

        public static void initialize()
        {
            if (instance == null)
                instance = new EngineManager();
        }

        public static IEngine getEngine()
        {
            return instance.engine;
        }

        public static float getRpmReading()
        {
            return instance.last_rpm;
        }

        public static void setRpmReading(float rpm)
        {
            instance.last_rpm = rpm;
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
    }
}
