using Cocon90.Lib.Util.Server;
using Sindrol.Model.Enums;
using Sindrol.Model.Message;
using Sindrol.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SilentService.Service.AsClient
{
    public class ScreenSendRepeater : BaseIntervalServer
    {
        public long TargetSn { get; set; }
        private ScreenSender screenSender { get; set; }
        /// <summary>
        /// 间隔多久发送图片一次，算法中，将屏幕分隔成横多少块，纵多少块
        /// </summary>
        public ScreenSendRepeater(long intervalSeconds, int screenWidthCount, int screenHeightCount, int perSleepMisconds) : base(intervalSeconds, perSleepMisconds)
        {
            this.screenSender = new ScreenSender(screenWidthCount, screenHeightCount);//将屏幕分隔成横多少块，纵多少块
        }
        public override void DoSomeThing(DateTime? startTime, long count)
        {
            try
            {
                this.DoWorkOnce();
            }
            catch (Exception ex)
            {
                Sindrol.Model.Utils.LoggerHelper.Logger.addToLog(ex);
            }
        }
        /// <summary>
        /// 客户端缓冲的远程屏幕信息
        /// </summary>
        public void ResetRemoteScreenCache()
        {
            if (this.screenSender != null) this.screenSender.ResetRemoteScreenCache();
        }
        /// <summary>
        /// 干一次该事件
        /// </summary>
        public void DoWorkOnce()
        {
            //发送屏幕的方法
            if (this.TargetSn <= 0) return;
            var img = screenSender.GetScreenNeedSend();//获取需要发送的屏幕模块
            if (img == null) return;
            CommonMessage.SendMessage(this.TargetSn, MessageTypes.ToServer_ScreenImageObject, img);
        }
    }
}
