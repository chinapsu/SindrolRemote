using Sindrol.Service.NotifyLib;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


namespace Sindrol.Service
{
    public class Notify
    {
  
        public static INotifyClient notifyClient { get; set; }
        public static void Connection(string ip, int port, long clientSn)
        {
            if (notifyClient != null) { notifyClient.Stop(); notifyClient = null; }
            DuplexClient client = new DuplexClient(string.Format("tcp://{0}:{1}", ip, port));
            client.Start(clientSn);
            client.ClientSn = clientSn;
            notifyClient = client;
        }
        public static void DisConnection()
        {
            if (notifyClient != null) { notifyClient.Stop(); }
        }
    }
}
