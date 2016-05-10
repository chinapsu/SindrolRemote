using Eneter.Messaging.MessagingSystems.MessagingSystemBase;
using Eneter.Messaging.MessagingSystems.TcpMessagingSystem;
using Eneter.Messaging.Nodes.Broker;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sindrol.Service.NotifyLib
{
    /// <summary>
    /// 推送消息客户端
    /// </summary>
    public class DuplexClient : INotifyClient
    {
        public long ClientSn { get; set; }
        private IDuplexBrokerClient myBrokerclient;
        /// <summary>
        /// Gets or sets the channel URL.
        /// </summary>
        /// <value>
        /// The channel URL.
        /// </value>
        public string ChannelUrl { get; set; }
        /// <summary>
        /// Initializes a new instance of the <see cref="DuplexClient"/> class.
        /// </summary>
        /// <param name="channelUrl">The channel URL. tcp://127.0.0.1:8284/</param>
        public DuplexClient(string channelUrl)
        {
            this.ChannelUrl = channelUrl;
            IDuplexBrokerFactory aBrokerFactory = new DuplexBrokerFactory(new Eneter.Messaging.DataProcessing.Serializing.GZipSerializer(new Eneter.Messaging.DataProcessing.Serializing.BinarySerializer()));
            myBrokerclient = aBrokerFactory.CreateBrokerClient();
        }
        /// <summary>
        /// Starts this instance.
        /// </summary>
        public void Start(long clientSn)
        {
            this.ClientSn = clientSn;
            IMessagingSystemFactory aMessaging = new TcpMessagingSystemFactory();
            myBrokerclient.AttachDuplexOutputChannel(aMessaging.CreateDuplexOutputChannel(this.ChannelUrl));
            myBrokerclient.Subscribe(clientSn.ToString());
            myBrokerclient.BrokerMessageReceived += myBroker_BrokerMessageReceived;
        }

        void myBroker_BrokerMessageReceived(object sender, BrokerMessageReceivedEventArgs e)
        {
            if (OnMessageRecived != null) { OnMessageRecived(this, e.Message); }
        }
        /// <summary>
        /// Stops this instance.
        /// </summary>
        public void Stop()
        {
            myBrokerclient.BrokerMessageReceived -= myBroker_BrokerMessageReceived;
            try
            {
                myBrokerclient.Unsubscribe(this.ClientSn.ToString());
            }
            catch { }
            myBrokerclient.DetachDuplexOutputChannel();

        }
        /// <summary>
        /// Sends the message.
        /// </summary>
        /// <param name="message">The message.</param>
        public void SendMessage(object message)
        {
            try
            {
                myBrokerclient.SendMessage("ToServer", message);
            }
            catch
            {
                if (myBrokerclient.AttachedDuplexOutputChannel != null)
                {
                    if (!myBrokerclient.AttachedDuplexOutputChannel.IsConnected)
                    {
                        myBrokerclient.AttachedDuplexOutputChannel.CloseConnection();
                        myBrokerclient.AttachedDuplexOutputChannel.OpenConnection();
                    }
                }
                this.Stop();
                this.Start(this.ClientSn);
                myBrokerclient.SendMessage("ToServer", message);
            }
        }
        /// <summary>
        /// Occurs when [on message recived].
        /// </summary> 
        public event MessageRecived OnMessageRecived;

    }
}
