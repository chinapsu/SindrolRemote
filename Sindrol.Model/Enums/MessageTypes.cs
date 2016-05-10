using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sindrol.Model.Enums
{
    /// <summary>
    /// 消息类型，奇数表示控制端发往客户端的，偶数表示客户端发往控制端的。
    /// </summary>
    [Serializable]
    public enum MessageTypes : byte
    {
        /// <summary>
        /// 向客户端检查对方连接是否可用
        /// </summary>
        ToClient_ConnectCheck = 1,
        /// <summary>
        /// 返回给控制端自己可用
        /// </summary>
        ToServer_ConnectCheck = 2,
        /// <summary>
        /// 通知客户端停止远控
        /// </summary>
        ToClient_StopControl = 3,
        /// <summary>
        /// 通知服务端停止远控
        /// </summary>
        ToServer_StopControl = 4,
        /// <summary>
        /// 令对方定期返回截图
        /// </summary>
        ToClient_StartReturnScreen = 5,
        /// <summary>
        /// 告知对方，此消息为图像对像
        /// </summary>
        ToServer_ScreenImageObject = 6,
        /// <summary>
        /// 通知对方，执行鼠标动作。
        /// </summary>
        ToClient_DoMouseAction = 7,
        /// <summary>
        /// 通知客户端，清空屏幕缓冲
        /// </summary>
        ToClient_ClearRemoteScreenCache = 9,
        /// <summary>
        /// 通知对方执行控件命令
        /// </summary>
        ToClient_DoKeyBoardAction = 11,
        /// <summary>
        /// 通知客户端，修改屏幕发送的质量。
        /// </summary>
        ToClient_SetImageQualityNumber = 13,
        /// <summary>
        /// 通知客户端，返回屏幕大小
        /// </summary>
        ToClient_GetClientScreenSize = 15,
        /// <summary>
        /// 汇报服务端，客户端屏幕大小 。
        /// </summary>
        ToServer_GetClientScreenSize = 16
    }
}
