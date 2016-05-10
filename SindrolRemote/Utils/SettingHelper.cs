using Cocon90.Lib.Util.Ini;
using Cocon90.Lib.Util.Parse;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

namespace SyncService.Utils
{
    public class SettingHelper
    {
        IniHelper ini = null;
        public SettingHelper()
        {
            ini = new IniHelper(AppDomain.CurrentDomain.BaseDirectory.TrimEnd('\\') + "\\setting.cfg");
            if (string.IsNullOrWhiteSpace(ReadServiceName()))
            {
                ini.Write("Service", "Name", Assembly.GetExecutingAssembly().GetName().Name);
            }
            if (string.IsNullOrWhiteSpace(ReadServiceDiscription()))
            {
                ini.Write("Service", "Discription", "SindrolRemote 消息发送机制！");
            }
            if (string.IsNullOrWhiteSpace(ini.Read("Setting", "Channel")))
            {
                ini.Write("Setting", "Channel", "tcp://123.56.121.148:1991");
            }

        }
        public string ReadServiceChannel()
        {
            return ini.Read("Setting", "Channel");
        }

        public string ReadServiceDiscription()
        {
            return ini.Read("Service", "Discription");
        }

        public string ReadServiceName()
        {
            return ini.Read("Service", "Name");
        }


    }
}
