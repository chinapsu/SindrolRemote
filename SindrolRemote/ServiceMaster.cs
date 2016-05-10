using Cocon90.Lib.Util.Ini;
using Cocon90.Lib.Util.Window.Service;
using SindrolRemote.Service;
using SyncService.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

namespace SyncService
{
    public class ServiceMaster
    {
        public static string ServiceName { get { return Tools.SettingHelper.ReadServiceName(); } }
        public static string ServiceDiscription { get { return Tools.SettingHelper.ReadServiceDiscription(); } }
        public static string ServiceExecutePath { get { return Assembly.GetExecutingAssembly().Location; } }

        static NotifyServer dbSyncService = null;
        /// <summary>
        /// 启动服务时发生
        /// </summary>
        public static void RunService()
        {
            if (dbSyncService == null) { dbSyncService = new NotifyServer(Tools.SettingHelper.ReadServiceChannel()); }
            dbSyncService.Start();
        }
        /// <summary>
        /// 停止服务时发生
        /// </summary>
        public static void StopService()
        {
            if (dbSyncService == null) { dbSyncService = new NotifyServer(Tools.SettingHelper.ReadServiceChannel()); }
            dbSyncService.Stop();
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
