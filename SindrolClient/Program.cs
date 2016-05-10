using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Windows.Forms;

namespace SindrolClient
{
    static class Program
    {
        /// <summary>
        /// 应用程序的主入口点。
        /// </summary>
        [STAThread]
        static void Main(string[] args)
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            //243 客户端
            //365 带控制
            if (args != null && args.Length > 0)
            { Application.Run(new Main() { Height = 365 }); }
            else { Application.Run(new Main()); }
        }
    }

}
