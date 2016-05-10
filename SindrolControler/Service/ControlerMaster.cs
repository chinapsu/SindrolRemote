using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Sindrol.Model.Message;
using Sindrol.Service.NotifyLib;
using Sindrol.Model.Enums;
using System.Windows.Forms;
using Cocon90.Lib.Util.Time;
using Sindrol.Service;
using SindrolControler.Core;
using Sindrol.Model.Utils;
using System.Drawing;

namespace SindrolControler.Service
{
    public class ControlerMaster
    {
        private System.Windows.Forms.PictureBox DisplayControl;//当前显示的控件
        private Action<string> infoAction;//消息提醒
        System.Threading.AutoResetEvent autoResetEvent = new System.Threading.AutoResetEvent(true);//握手等待
        MouseController mouseController = null;//当前的鼠标控制器
        KeyboardController keyboardController = null;//当前的键盘控制器
        public long ToSn { get; set; }
        public Status CurrentStatus { get; set; }
        public ControlerMaster(System.Windows.Forms.PictureBox displayControl, Action<string> infoAction)
        {
            var size = ScreenCapture.getScreenSize();
            displayControl.BackgroundImage = new Bitmap(size.Width, size.Height);//虚拟屏大小。
            displayControl.BackgroundImageLayout = ImageLayout.Stretch;
            this.DisplayControl = displayControl;
            this.infoAction = infoAction;
            mouseController = new MouseController(this.DisplayControl);
            keyboardController = new KeyboardController(this.DisplayControl);
        }
        /// <summary>
        /// 控制端主窗体失去焦点时触发。
        /// </summary>
        public void FormLostFocus()
        {
            mouseController.Stop();
            keyboardController.Stop();
        }
        /// <summary>
        /// 控制端主窗体获取焦点时触发。
        /// </summary>
        public void FormGotFocus()
        {
            if (CurrentStatus == Status.Remoting && this.ToSn > 0)
            {
                mouseController.Start(this.ToSn);
                keyboardController.Start(this.ToSn);
            }
        }

        public void Stop(Action beginAction, Action<bool> finishAction)
        {
            if (beginAction != null) beginAction();
            bgWorker.runAsync(run =>
            {
                CommonMessage.SendMessage(this.ToSn, MessageTypes.StopControl);
                run.BoolResult = autoResetEvent.WaitOne(5 * 1000);//等待握手成功！
            }, fin =>
            {
                CurrentStatus = Status.None;
                mouseController.Stop();
                keyboardController.Stop();
                finishAction(fin.BoolResult);
            });
        }


        /// <summary>
        /// 开始控制，传入被控端Sn
        /// </summary>
        /// <param name="clientSn"></param>
        public void Start(long clientSn, Action beginAction, Action<bool> finishAction)
        {
            this.ToSn = clientSn;
            //点了开始执行控制，发送握手信息。
            autoResetEvent.Reset();
            if (beginAction != null) beginAction();
            bgWorker.runAsync(run =>
            {
                CommonMessage.SendMessage(this.ToSn, MessageTypes.ConnectCheck);
                run.BoolResult = autoResetEvent.WaitOne(5 * 1000);//等待握手成功！
            }, fin =>
            {
                finishAction(fin.BoolResult);
                if (fin.BoolResult) { BeginRemote(); }//开始远程！
            });
        }

        private void BeginRemote()
        {
            //首先去发送指令给客户机，让其开始返回桌面。
            CommonMessage.SendMessage(this.ToSn, MessageTypes.StartReturnScreen);
            CurrentStatus = Status.Remoting;
            mouseController.Start(this.ToSn);
            keyboardController.Start(this.ToSn);
        }
        /// <summary>
        /// 控制端执行关闭时发生，用于停止所有服务。
        /// </summary>
        public void Shutdown()
        {
            this.DisplayControl.Refresh();
            CurrentStatus = Status.None;
            mouseController.Stop();
            keyboardController.Stop();
            Notify.DisConnection();
        }

        public void MessageHandler(MessageEntry msg)
        {
            if (msg == null || msg.ToSn != Notify.notifyClient.ClientSn || msg.FromSn != this.ToSn) return;
            if (msg.MessageType == MessageTypes.ConnectCheck)
            {
                infoAction("成功连接到客户机【" + this.ToSn + "】！");
                autoResetEvent.Set();//通知握手成功！
                return;
            }
            if (msg.MessageType == MessageTypes.StopControl)
            {
                infoAction("成功停止与客户机【" + this.ToSn + "】的连接！");
                autoResetEvent.Set();//通知停止控制成功！
                this.DisplayControl.Refresh();//刷新预览
                return;
            }
            if (msg.MessageType == MessageTypes.ScreenImageObject)
            {
                var img = msg.MessageData as Sindrol.Model.Data.ScreenImageObject;
                var backImg = this.DisplayControl.BackgroundImage;
                img.DisplayToControl(ref backImg);
                this.DisplayControl.Refresh();
                return;
            }
        }


    }
}
