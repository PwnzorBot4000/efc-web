using System.ComponentModel;

namespace efc_web
{
    public class EngineManager
    {
        static EngineManager instance;
        BackgroundWorker manager_process;

        float last_rpm = 0;

        public static void initialize()
        {
            if (instance == null)
                instance = new EngineManager();
        }

        public static float getRpmReading()
        {
            return instance.last_rpm;
        }

        EngineManager()
        {
            manager_process = new BackgroundWorker();
            manager_process.DoWork += manager_process_main;
            manager_process.RunWorkerAsync();
        }

        void manager_process_main(object sender, DoWorkEventArgs e)
        {
            last_rpm = -1;
        }
    }
}
