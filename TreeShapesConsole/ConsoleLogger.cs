using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Tree
{
    public class ConsoleLogger : Logger
    {
        public ConsoleLogger(LogLevel mask)
        : base(mask)
        {}

        protected override void WriteMessage(string msg)
        {
            Console.WriteLine(msg);
        }
    }
}