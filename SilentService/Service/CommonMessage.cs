using Cocon90.Lib.Util.Time;
using Sindrol.Model.Enums;
using Sindrol.Model.Message;
using Sindrol.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SilentService
{
    public class CommonMessage
    {
        /// <summary>
        /// 发送消息给服务器
        /// </summary>
        /// <param name="toSn"></param>
        /// <param name="messageType"></param>
        /// <param name="messageData"></param>
        public static void SendMessage(long toSn, MessageTypes messageType, object messageData = null)
        {
            if (Notify.notifyClient == null) return;
            MessageEntry msg = new MessageEntry() { FromSn = Notify.notifyClient.ClientSn, ToSn = toSn, MessageType = messageType, MessageData = messageData };
            Notify.notifyClient.SendMessage(msg);
        }
        /// <summary>
        /// 连接
        /// </summary>
        public static void ConnectionAsync(string serviceIP, int servicePort, long currentSn, Action<bool> actionFinish)
        {
            bgWorker.runAsync(run =>
            {
                try
                {
                    Notify.Connection(serviceIP, servicePort, currentSn);
                    run.BoolResult = true;
                }
                catch { }
            }, fin =>
            {
                if (actionFinish != null) actionFinish(fin.BoolResult);
            });
        }
        /// <summary>
        /// 断开连接
        /// </summary>
        /// <param name="actionFinish"></param>
        public static void DisconnectionAsync(Action<bool> actionFinish)
        {
            bgWorker.runAsync(run =>
            {
                try
                {
                    Notify.DisConnection();
                    run.BoolResult = true;
                }
                catch { }
            }, fin =>
            {
                if (actionFinish != null) actionFinish(fin.BoolResult);
            });
        }
    }
}
