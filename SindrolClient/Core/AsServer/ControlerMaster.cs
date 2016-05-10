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
using Sindrol.Model.Utils;
using System.Drawing;
using Sindrol.Model.Data;
using System.Threading;

namespace SindrolClient.Core.AsServer
{
    public class ControlerMaster
    {
        private Views.ControlerView displayWindow;//当前显示的控件
        System.Threading.AutoResetEvent autoResetEvent = new System.Threading.AutoResetEvent(true);//握手等待
        public long ToSn { get; set; }
        public Main mainWindow { get; set; }
        public Size ClientScreenSize { get; set; }//客户端屏幕大小。只有发送命令后，才会赋予值。
        public ControlerMaster(Main main, Views.ControlerView displayWindow)
        {
            this.mainWindow = main;
            this.displayWindow = displayWindow;
            this.displayWindow.Master = this;
            this.displayWindow.DisplayControl.BackgroundImage = ScreenImageObject.DisplayImage;
            this.displayWindow.DisplayControl.BackgroundImageLayout = ImageLayout.Stretch;
            this.displayWindow.FormClosed += (ss, ee) => { mainWindow.Info("已断开与【" + ToSn + "】的连接！"); };
        }


        /// <summary>
        /// 开始控制，传入被控端Sn
        /// </summary>
        /// <param name="clientSn"></param>
        private void Start(long clientSn, Action beginAction, Action<bool> finishAction)
        {
            this.ToSn = clientSn;
            //点了开始执行控制，发送握手信息。
            autoResetEvent.Reset();
            if (beginAction != null) beginAction();
            bgWorker.runAsync(run =>
            {
                CommonMessage.SendMessage(this.ToSn, MessageTypes.ToClient_ConnectCheck);
                run.BoolResult = autoResetEvent.WaitOne(5 * 1000);//等待握手成功！
            }, fin =>
            {
                if (fin.BoolResult)
                {
                    //开始远程！
                    //首先去发送指令给客户机，让其开始返回桌面。
                    CommonMessage.SendMessage(this.ToSn, MessageTypes.ToClient_StartReturnScreen);
                }
                finishAction(fin.BoolResult);
            });
        }

        /// <summary>
        /// 显示预览窗口，并开始远程。
        /// </summary>
        public void StartView(long numClientSn, Action beginAction, Action<bool> finishAction)
        {
            if (Notify.notifyClient == null) return;
            this.ToSn = numClientSn;
            this.Start(numClientSn, beginAction, (isok) =>
            {
                if (finishAction != null) { finishAction(isok); }
                if (isok)
                {
                    this.mainWindow.Hide();
                    if (!this.displayWindow.IsDisposed) this.displayWindow.ShowDialog();
                    this.mainWindow.Show();
                }
            });

        }


        public void MessageHandler(MessageEntry msg)
        {
            if (msg == null || msg.ToSn != Notify.notifyClient.ClientSn || msg.FromSn != this.ToSn) return;
            if (msg.MessageType == MessageTypes.ToServer_ConnectCheck)
            {
                autoResetEvent.Set();//通知握手成功！
                return;
            }
            if (msg.MessageType == MessageTypes.ToServer_StopControl)
            {
                this.displayWindow.Close();
                this.mainWindow.Info("【" + ToSn + "】已关闭与本端的连接！");
                return;
            }
            if (msg.MessageType == MessageTypes.ToServer_ScreenImageObject)
            {
                var img = msg.MessageData as ScreenImageObject;
                img.DisplayToControl(this.displayWindow.DisplayControl);
                return;
            }
            if (msg.MessageType == MessageTypes.ToServer_GetClientScreenSize)
            {
                this.ClientScreenSize = (Size)msg.MessageData;
                autoResetEvent.Set();
                return;
            }
        }
        /// <summary>
        /// 设置远程时的图片质量。范围1-100。
        /// </summary>
        /// <param name="flag"></param>
        public void SetScreenQuality(int flag)
        {
            if (Notify.notifyClient == null || this.ToSn == 0) return;
            CommonMessage.SendMessage(this.ToSn, MessageTypes.ToClient_SetImageQualityNumber, flag);
        }

        /// <summary>
        /// 获取远程屏幕大小。
        /// </summary>
        public bool GetRemoteWindSize()
        {
            CommonMessage.SendMessage(this.ToSn, MessageTypes.ToClient_GetClientScreenSize);
            return autoResetEvent.WaitOne(3000);
        }
    }
}
