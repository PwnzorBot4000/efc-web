using System;

namespace EFC
{
	public class Logger
	{
		private static Logger instance;

		private Logger() {}

		private static Logger Instance
		{
			get
			{
				if (instance == null)
					instance = new Logger();
				return instance;
			}
		}

		public delegate void LoggingFunction(string message);
		private LoggingFunction logging_func;

		public static void setLoggingFunction(LoggingFunction logging_func)
		{
			Instance.logging_func = logging_func;
		}

		public static void log(string message)
		{
			Instance.call_logging_func(message);
		}

        private void call_logging_func(string message)
        {
            if (logging_func != null)
                logging_func(message);
        }
	}
}
