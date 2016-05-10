using Cocon90.Lib.Util.Parse;
using Cocon90.Lib.Util.Time;
using Sindrol.Model.Message;
using Sindrol.Model.Utils;
using Sindrol.Service;
using Sindrol.Service.NotifyLib;
using SindrolClient.Core;
using SindrolClient.Core.AsClient;
using SindrolClient.Core.AsServer;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace SindrolClient
{
    public partial class Main : Form
    {
        ClientMaster clientMaster { get; set; }
        ControlerMaster controlerMaster { get; set; }
        public Main()
        {
            InitializeComponent();
            //客户端实例
            this.FormClosing += (ss, ee) => { clientMaster.StopTask(true); Notify.DisConnection(); };
            this.clientMaster = new ClientMaster(Info, this);
            this.controlerMaster = new ControlerMaster(this, new Views.ControlerView());
            this.FormClosed += (ss, ee) => { System.Diagnostics.Process.GetCurrentProcess().Kill(); };
        }
        private void lkLabel_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Clipboard.SetText(lkLabel.Text);
        }

        private void NotifyClient_OnMessageRecived(INotifyClient client, object message)
        {
            var msg = message as MessageEntry;
            if (msg == null) return;
            //基数
            if ((int)msg.MessageType % 2 == 1) { this.clientMaster.MessageHandler(msg); }
            else { this.controlerMaster.MessageHandler(msg); }
        }

        private void btnConn_Click(object sender, EventArgs e)
        {
            var currentSn = MidGenerater.NewMid(16);
            CommonMessage.ConnectionAsync(textIP.Text, (int)textPort.Value, currentSn, (isok) =>
            {
                btnDisconn.Enabled = isok;
                btnConn.Enabled = !isok;
                groupControl.Enabled = isok;
                controlGroup.Enabled = isok;
                if (isok)
                {
                    Notify.notifyClient.OnMessageRecived += NotifyClient_OnMessageRecived;
                    lkLabel.Text = currentSn.ToString();
                    this.Info("连接到服务器成功！");
                }
                else { this.Info("连接到服务器失败！请重试！"); }
            });
        }


        private void btnDisconn_Click(object sender, EventArgs e)
        {
            clientMaster.StopTask(true);//停止当前正在执行地任务
            CommonMessage.DisconnectionAsync((isok) =>
            {
                btnDisconn.Enabled = !isok;
                btnConn.Enabled = isok;
                groupControl.Enabled = !isok;
                if (isok)
                {
                    Notify.notifyClient.OnMessageRecived -= NotifyClient_OnMessageRecived;
                    this.Info("断开到服务器成功！");
                }
                else { this.Info("断开服务器失败！请重试！"); }
            });
        }
        public void Info(string text)
        {
            if (this.InvokeRequired)
            { this.Invoke(new Action(() => { lbStatus.Text = text; })); }
            else { lbStatus.Text = text; }
        }


        private void btnStartControl_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(numClientSn.Text)) { Info("请输入对方机器码再连接！"); return; }
            if (numClientSn.Text == lkLabel.Text) { Info("不能自己连接自己！"); return; }
            controlerMaster.StartView(parseHelper.toLong(numClientSn.Text), () =>
            {
                btnStartControl.Text = "正在连接...";
                btnStartControl.Enabled = false;
                Info("正在连接【" + numClientSn.Text + "】...");
            }, (isok) =>
            {
                btnStartControl.Text = "开始连接";
                btnStartControl.Enabled = true;
                if (!isok)
                { Info("连接到【" + numClientSn.Text + "】失败！"); }
                else
                { Info("正在与【" + numClientSn.Text + "】远程中！"); }
            });
        }
    }
}
