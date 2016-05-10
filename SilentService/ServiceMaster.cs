using Cocon90.Lib.Util.Ini;
using Cocon90.Lib.Util.Window.Service;
using SilentService.Service;
using SilentService.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

namespace SilentService
{
    public class ServiceMaster
    {
        static SlientMainService mianService = null;
        public static string ServiceName { get { return Tools.SettingHelper.ReadServiceName(); } }
        public static string ServiceDiscription { get { return Tools.SettingHelper.ReadServiceDiscription(); } }
        public static string ServiceExecutePath { get { return Assembly.GetExecutingAssembly().Location; } }
        /// <summary>
        /// 启动服务时发生
        /// </summary>
        public static void RunService()
        {
            if (mianService == null) mianService = new SlientMainService();
            mianService.Start();
        }
        /// <summary>
        /// 停止服务时发生
        /// </summary>
        public static void StopService()
        {
            mianService.Stop();
        }
        /// <summary>
        /// 执行安装并启动服务
        /// </summary>
        /// <returns></returns>
        public static bool InstallService()
        {
            ServiceControl sc = new ServiceControl(ServiceName, ServiceExecutePath, ServiceDiscription);
            return sc.Start();
        }
        /// <summary>
        /// 执行卸载服务
        /// </summary>
        /// <returns></returns>
        public static bool UninstallService()
        {
            ServiceControl sc = new ServiceControl(ServiceName, ServiceExecutePath, ServiceDiscription);
            return sc.Stop();
        }
    }
}
