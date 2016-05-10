using Cocon90.Lib.Util.Log;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sindrol.Model.Utils
{
    public class LoggerHelper
    {
        static Logger log = new Logger(AppDomain.CurrentDomain.BaseDirectory.TrimEnd('\\') + "\\log\\");
        public static Logger Logger
        {
            get { return log; }
        }
    }
}
