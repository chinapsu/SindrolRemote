using SilentService.Service.AsClient;
using Sindrol.Model.Message;
using Sindrol.Service;
using Sindrol.Service.NotifyLib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SilentService.Service
{
    internal class SlientMainService
    {
        ClientMessageHandler handler = null;
        public SlientMainService()
        {
            handler = new ClientMessageHandler();
        }
        internal void Start()
        {
            CommonMessage.ConnectionAsync(Utils.SettingHelper.IPAddress, Utils.SettingHelper.Port, Utils.SettingHelper.ClientSn, (isok) =>
            {
                if (isok) Notify.notifyClient.OnMessageRecived += NotifyClient_OnMessageRecived;
            });
        }

        internal void Stop()
        {
            CommonMessage.DisconnectionAsync((isok) =>
            {
                if (isok) Notify.notifyClient.OnMessageRecived -= NotifyClient_OnMessageRecived;
            });
        }
        private void NotifyClient_OnMessageRecived(INotifyClient client, object message)
        {
            var msg = message as MessageEntry;
            if (msg == null) return;
            this.handler.MessageHandler(msg);
        }
    }
}
