using Cocon90.Lib.Util.Parse;
using Cocon90.Lib.Util.Time;
using Sindrol.Model.Enums;
using Sindrol.Model.Message;
using Sindrol.Model.Utils;
using Sindrol.Service;
using SindrolControler.Core;
using SindrolControler.Service;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace SindrolControler
{
    public partial class Main : Form
    {
        public Main()
        {
            InitializeComponent();
            this.FormClosing += (ss, ee) => { master.Shutdown(); };
            this.master = new ControlerMaster(picture, Info);
            this.btnFullScreen.Click += (ss, ee) => { IsFullScreen = !IsFullScreen; };
            this.picture.MouseDown += (ss, ee) => { if (ee.Button == MouseButtons.Middle) { IsFullScreen = !IsFullScreen; } };
            this.Activated += (ss, ee) => { this.master.FormGotFocus(); };
            this.Deactivate += (ss, ee) => { this.master.FormLostFocus(); };
        }

        ControlerMaster master { get; set; }
        private void btnStart_Click(object sender, EventArgs e)
        {
            if (Notify.notifyClient == null) return;
            this.master.Start((long)parseHelper.toLong(numClientSn.Text), () =>
            {
                Info("正在连接到客户机 ...");
                groupControl.Enabled = false;
            }, (isok) =>
            {
                if (!isok) { Info("连接到客户机超时！"); }
                groupControl.Enabled = true;
                btnStartControl.Enabled = !isok; btnStopControl.Enabled = isok;
            });
        }
        private void btnStopControl_Click(object sender, EventArgs e)
        {
            btnStopControl.Enabled = false;
            this.master.Stop(() =>
            {
                Info("正在通知客户机停止受控 ...");
            }, (isok) =>
            {
                if (!isok) Info("通知客户端超时！");
                btnStartControl.Enabled = true; btnStopControl.Enabled = !true;
                picture.Refresh();
            });
        }
        private void NotifyClient_OnMessageRecived(Sindrol.Service.NotifyLib.INotifyClient client, object message)
        {
            var msg = message as MessageEntry;
            if (msg == null) return;
            master.MessageHandler(msg);
            if (msg.MessageType == MessageTypes.StopControl)
            {
                btnStartControl.Enabled = true; btnStopControl.Enabled = false;
                picture.Refresh();
            }
        }

        private void btnConn_Click(object sender, EventArgs e)
        {
            bgWorker.runAsync(run =>
            {
                try
                {
                    Notify.Connection(textIP.Text, (int)textPort.Value, MidGenerater.NewMid64Bit());
                    run.BoolResult = true;
                }
                catch { }
            }, fin =>
            {
                btnDisconn.Enabled = fin.BoolResult;
                btnConn.Enabled = !fin.BoolResult;
                groupControl.Enabled = fin.BoolResult;
                if (fin.BoolResult)
                {
                    Notify.notifyClient.OnMessageRecived += NotifyClient_OnMessageRecived;
                    this.Info("连接服务器成功！本端编号：" + Notify.notifyClient.ClientSn);
                }
                else { this.Info("连接服务器失败！"); }
            });

        }

        private void btnDisconn_Click(object sender, EventArgs e)
        {
            bgWorker.runAsync(run =>
            {
                try
                {
                    Notify.DisConnection();
                    run.BoolResult = true;
                }
                catch { }
            }, fin =>
            {
                btnDisconn.Enabled = !fin.BoolResult;
                btnConn.Enabled = fin.BoolResult;
                groupControl.Enabled = !fin.BoolResult;
                if (fin.BoolResult)
                {
                    Notify.notifyClient.OnMessageRecived -= NotifyClient_OnMessageRecived;
                    this.Info("断开服务器成功！");
                }
                else { this.Info("连接服务器失败！本端编号：" + Notify.notifyClient.ClientSn); }
            });
        }

        public void Info(string text)
        {
            if (this.InvokeRequired)
            { this.Invoke(new Action(() => { lbStatus.Text = text; })); }
            else { lbStatus.Text = text; }
        }

        #region 全屏代码
        public event Action<bool> FullScreenChanged;
        class FullScreenOldStaus
        {
            public static AnchorStyles oldAnchor;
            public static FormWindowState oldWindowState;
            public static int oldWidth;
            public static int oldHeight;
        }
        public bool IsFullScreen
        {
            get
            {
                return this.picture.Dock == DockStyle.Fill;
            }
            set
            {

                if (value)
                {
                    FullScreenOldStaus.oldWidth = this.picture.Width;
                    FullScreenOldStaus.oldHeight = this.picture.Height;
                    FullScreenOldStaus.oldAnchor = this.picture.Anchor;
                    FullScreenOldStaus.oldWindowState = this.WindowState;
                    this.FormBorderStyle = FormBorderStyle.None;
                    this.WindowState = FormWindowState.Maximized;
                    this.picture.Dock = DockStyle.Fill;
                    this.statusStrip.Visible = false;
                    picture.BorderStyle = BorderStyle.None;
                }
                else
                {
                    this.FormBorderStyle = FormBorderStyle.Sizable;
                    this.picture.Anchor = FullScreenOldStaus.oldAnchor;
                    this.picture.Dock = DockStyle.None;
                    this.WindowState = FullScreenOldStaus.oldWindowState;
                    this.picture.Width = FullScreenOldStaus.oldWidth;
                    this.picture.Height = FullScreenOldStaus.oldHeight;
                    this.statusStrip.Visible = true;
                    picture.BorderStyle = BorderStyle.FixedSingle;
                }
                System.Threading.Thread th = new System.Threading.Thread(() =>
                {
                    Rectangle rectOld = new Rectangle();
                    TaskBarHelper.SetFullScreen(value, ref rectOld);
                });
                th.Start();
                if (FullScreenChanged != null) FullScreenChanged(value);
            }
        }
        #endregion
    }
}
