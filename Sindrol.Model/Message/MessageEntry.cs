using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sindrol.Model.Message
{
    [Serializable]
    public class MessageEntry
    {
        public long FromSn { get; set; }
        public long ToSn { get; set; }
        /// <summary>
        /// 消息类型，奇数表示控制端发往客户端的，偶数表示客户端发往控制端的
        /// </summary>
        public Enums.MessageTypes MessageType { get; set; }
        public object MessageData { get; set; }
    }
}
