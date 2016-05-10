
using Eneter.Messaging.MessagingSystems.MessagingSystemBase;
using Eneter.Messaging.MessagingSystems.TcpMessagingSystem;
using Eneter.Messaging.Nodes.Broker;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SindrolRemote.Service
{
    public class NotifyServer
    {
        private IDuplexBroker myBroker;
        /// <summary>
        /// Gets or sets the channel URL.
        /// </summary>
        /// <value>
        /// The channel URL.
        /// </value>
        public string ChannelUrl { get; set; }
        /// <summary>
        /// 定义一个服务端。输入起动的地址，如：tcp://127.0.0.1:8284/。
        /// </summary>
        /// <param name="channelUrl">The channel URL .</param>
        public NotifyServer(string channelUrl)
        {
            this.ChannelUrl = channelUrl;
            IDuplexBrokerFactory aBrokerFactory = new DuplexBrokerFactory(new Eneter.Messaging.DataProcessing.Serializing.GZipSerializer(new Eneter.Messaging.DataProcessing.Serializing.BinarySerializer()));
            myBroker = aBrokerFactory.CreateBroker();
        }
        /// <summary>
        /// Starts this instance.
        /// </summary>
        public void Start()
        {
            IMessagingSystemFactory aMessaging = new TcpMessagingSystemFactory();
            myBroker.AttachDuplexInputChannel(aMessaging.CreateDuplexInputChannel(this.ChannelUrl));
            myBroker.Subscribe("ToServer");
            myBroker.BrokerMessageReceived += myBroker_BrokerMessageReceived;
        }

        void myBroker_BrokerMessageReceived(object sender, BrokerMessageReceivedEventArgs e)
        {
            var msg = e.Message as Sindrol.Model.Message.MessageEntry;
            if (msg == null) return;
            //Console.WriteLine("收到消息：FromSn:{0}  ToSn:{1}  Type:{2}", msg.FromSn, msg.ToSn, msg.MessageType.ToString());
            myBroker.SendMessage(msg.ToSn.ToString(), e.Message);//将信息发给特定用户
        }
        /// <summary>
        /// Stops this instance.
        /// </summary>
        public void Stop()
        {
            myBroker.BrokerMessageReceived -= myBroker_BrokerMessageReceived;
            myBroker.Unsubscribe("ToServer");
            myBroker.DetachDuplexInputChannel();
        }

    }
}
