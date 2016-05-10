using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sindrol.Service.NotifyLib
{
    public interface INotifyClient
    {
        long ClientSn { get; set; }

        event MessageRecived OnMessageRecived;
        void SendMessage(object message);
        void Start(long clientSn);
        void Stop();
    }
}
