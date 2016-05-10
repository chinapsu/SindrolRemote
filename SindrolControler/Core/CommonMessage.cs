using Sindrol.Model.Enums;
using Sindrol.Model.Message;
using Sindrol.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SindrolControler
{
    public class CommonMessage
    {
        public static void SendMessage(long toSn, MessageTypes messageType, object messageData = null)
        {
            MessageEntry msg = new MessageEntry() { FromSn = Notify.notifyClient.ClientSn, ToSn = toSn, MessageType = messageType, MessageData = messageData };
            Notify.notifyClient.SendMessage(msg);
        }
    }
}
