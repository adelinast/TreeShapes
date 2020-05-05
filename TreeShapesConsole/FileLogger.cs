using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Configuration;
namespace Tree
{
    public class FileLogger : Logger
    {
        public FileLogger(LogLevel mask)
            : base(mask)
        { }

        protected override void WriteMessage(string msg)
        {
            string logfilename = ConfigurationManager.AppSettings["LogFilename"];

            if (!File.Exists(logfilename))
            {
                using (StreamWriter sw = File.CreateText(logfilename))
                {
                    sw.WriteLine(msg);
                }
                return;
            }

            using (StreamWriter sw = File.AppendText(logfilename))
            {
                sw.WriteLine(msg);

            }
        }
    }
}