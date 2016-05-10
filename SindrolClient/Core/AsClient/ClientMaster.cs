using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Sindrol.Model.Message;
using Sindrol.Service.NotifyLib;
using Sindrol.Model.Enums;
using Sindrol.Model.Utils;
using Cocon90.Lib.Util.GZip;
using System.Windows.Forms;
using Sindrol.Service;

namespace SindrolClient.Core.AsClient
{
    public class ClientMaster
    {
        private Action<string> infoAction;
        public long TargetSn { get; set; }
        private Form mainForm { get; set; }
        private ScreenSendRepeater screenSendRepeater = null;//截屏线程。
        private MouseSimulatorMaster mouseSimulatorMaster = null;//鼠标模拟器
        private KeyboardSimulatorMaster keyboardSimulatorMaster = null;//键盘模拟器
        Cocon90.Lib.Util.Window.Input.InputSimulator.InputSimulator inputSimulator = null;
        public ClientMaster(Action<string> infoAction, Form mainForm)
        {
            this.infoAction = infoAction;
            this.mainForm = mainForm;
            inputSimulator = new Cocon90.Lib.Util.Window.Input.InputSimulator.InputSimulator();
            this.screenSendRepeater = new ScreenSendRepeater(200, 10, 6, 50);//启动后将每隔指定毫秒发送图像
            this.mouseSimulatorMaster = new MouseSimulatorMaster(mainForm, inputSimulator);
            this.keyboardSimulatorMaster = new KeyboardSimulatorMaster(mainForm, inputSimulator);
        }

        public void MessageHandler(MessageEntry msg)
        {
            if (msg == null || msg.ToSn != Notify.notifyClient.ClientSn) return;
            this.TargetSn = msg.FromSn;
            this.screenSendRepeater.TargetSn = msg.FromSn;
            if (msg.MessageType == MessageTypes.ToClient_DoMouseAction)
            {//收到主机命令：开始变动鼠标位置和操作
                mouseSimulatorMaster.Simulator(msg);
                return;
            }
            if (msg.MessageType == MessageTypes.ToClient_DoKeyBoardAction)
            {//收到主机命令：清空远程桌面图像缓冲，并返回图片。
                this.keyboardSimulatorMaster.Simulator(msg);
                return;
            }
            if (msg.MessageType == MessageTypes.ToClient_ClearRemoteScreenCache)
            {//收到主机命令：清空远程桌面图像缓冲，并返回图片。
                this.screenSendRepeater.ResetRemoteScreenCache();
                this.screenSendRepeater.DoWorkOnce();
                return;
            }
            if (msg.MessageType == MessageTypes.ToClient_ConnectCheck)
            {//收到主机命令：要求与服务器握手
                CommonMessage.SendMessage(this.TargetSn, MessageTypes.ToServer_ConnectCheck);
                this.infoAction("本机已受控制端【" + this.TargetSn + "】所控制！");
                return;
            }
            if (msg.MessageType == MessageTypes.ToClient_StopControl)
            {//收到主机命令：主机已停止当前控制任务。
                this.infoAction("控制端【" + this.TargetSn + "】已停止对本机的控制！");
                this.StopTask(false);
                return;
            }
            if (msg.MessageType == MessageTypes.ToClient_StartReturnScreen)
            {//收到主机命令：开始返回屏幕画面
                this.screenSendRepeater.ResetRemoteScreenCache();
                screenSendRepeater.Start();
                return;
            }
            if (msg.MessageType == MessageTypes.ToClient_SetImageQualityNumber)
            {//收到主机命令：设置屏幕发送质量
                ScreenHelper.ImageThumbnail = (int)msg.MessageData;
                return;
            }
            if (msg.MessageType == MessageTypes.ToClient_GetClientScreenSize)
            {//收到主机命令：返回屏幕大小
                CommonMessage.SendMessage(this.TargetSn, MessageTypes.ToServer_GetClientScreenSize, ScreenCapture.getScreenSize());
                return;
            }

        }
        public void StopTask(bool isTellServer)
        {
            if (isTellServer) CommonMessage.SendMessage(this.TargetSn, MessageTypes.ToServer_StopControl);
            if (screenSendRepeater != null) { screenSendRepeater.Stop(); }
        }
    }
}
