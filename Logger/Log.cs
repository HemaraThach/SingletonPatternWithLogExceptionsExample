using System;
using System.IO;
using System.Text;

namespace Logger
{
    public sealed class Log : ILog
    {
        private Log()
        {
        }

        public static Log Instance = new Log();

        public static Log GetInstance => Instance;


        public void LogException(string message)
        {
            string fileName = string.Format("{0}_{1}", "Exception", DateTime.Now.ToShortDateString());
            string filePath = string.Format(@"{0}\{1}", AppDomain.CurrentDomain.BaseDirectory, fileName);
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("-----------------------------");
            sb.AppendLine(DateTime.Now.ToString());
            sb.AppendLine(message);
            using (StreamWriter writer = new StreamWriter(filePath))
            {
                writer.Write(sb.ToString());
                writer.Flush();
            }
        }
    }
}