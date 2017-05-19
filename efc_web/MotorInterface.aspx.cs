using System;
using EFC;

using VegaDrive = EFC.Engines.VegaDrive_15P0087B5;

namespace efc_web
{
    public partial class MotorInterface : System.Web.UI.Page
    {
        IEngine engine;

        public MotorInterface()
        {
            Logger.setLoggingFunction(writeLine);
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            engine = EngineManager.getEngine();
        }

        protected void StartEngine(object sender, EventArgs e)
        {
            engine.Start();
        }

        protected void StopEngine(object sender, EventArgs e)
        {
            engine.Stop();
        }

        protected void ReverseEngine(object sender, EventArgs e)
        {
            engine.Reverse();
        }

        protected void ResetEngine(object sender, EventArgs e)
        {
            engine.Reset();
        }

        protected void EmergencyStopEngine(object sender, EventArgs e)
        {
            engine.EmergencyStop();
        }

        protected void GetEngineStatus(object sender, EventArgs e)
        {
            writeLine(get_status_msg());
        }

        protected void setFreq_click(object sender, EventArgs e)
        {
            string input = freqsetbox.Text;
            float hertz = Convert.ToSingle(input);
            engine.SetFrequency(hertz);
        }

        protected void getFreq_click(object sender, EventArgs e)
        {
            freqgetbox.Text = get_freq_msg();
        }

        /// Debug function for directly accessing vega drive's registers. 
        protected void send_click(object sender, EventArgs e)
        {
            string input = inputbox.Text;
            string[] values = input.Split(' ');
            ushort addr = Convert.ToUInt16(values[0]);
            VegaDrive vegaeng = (VegaDrive)engine;  // may throw
            try
            {
                if (values.Length > 1)
                {
                    vegaeng.WriteRegister(addr, Convert.ToInt16(values[1]));
                    writeLine("Successfully wrote " + values[1] + " to address " + values[0]);
                }
                else
                {
                    short val = vegaeng.ReadRegister(addr);
                    writeLine("Read from " + values[0] + ": 0x" + val.ToString("x"));
                }
            }
            catch (EFC.EngineMessageException exc)
            {
                writeLine(exc.Message);
            }
        }

        protected String get_status_msg()
        {
            try
            {
                EngineStatus s = engine.Status();
                return "Engine Status: " + s.ToString();
            }
            catch (EngineMessageException)
            {
                return "Engine is offline";
            }
        }

        protected String get_freq_msg()
        {
            try
            {
                return engine.GetFrequency().ToString() + " Hz";
            }
            catch (EngineMessageException)
            {
                return "";
            }
        }

        void write(string s)
        {
            outputbox.Text += s;
        }

        void writeLine(string s)
        {
            outputbox.Text += s + "<br />";
        }
    }
}
