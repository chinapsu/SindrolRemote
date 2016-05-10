using Cocon90.Lib.Util.Parse;
using Cocon90.Lib.Util.Time;
using Sindrol.Model.Enums;
using Sindrol.Model.Message;
using Sindrol.Model.Utils;
using Sindrol.Service;
using SindrolClient.Core.AsServer;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace SindrolClient.Views
{
    public partial class ControlerView : Form
    {
        public Control DisplayControl { get { return picture; } }
        public ControlerMaster Master { get; set; }
        MouseController mouseController = null;//当前的鼠标控制器
        KeyboardController keyboardController = null;//当前的键盘控制器
        public ControlerView()
        {
            InitializeComponent();

            mouseController = new MouseController(picture);
            keyboardController = new KeyboardController(picture);

            this.FormClosing += (ss, ee) => { StopController(true); };
            this.btnFullScreen.Click += (ss, ee) => { IsFullScreen = !IsFullScreen; };
            this.picture.MouseDown += (ss, ee) => { if (ee.Button == MouseButtons.Middle) { IsFullScreen = !IsFullScreen; } };
            this.Activated += (ss, ee) => { this.StartController(); };
            this.Deactivate += (ss, ee) => { this.StopController(); };
            trackBar.KeyDown += (ss, ee) => { ee.Handled = true; };
        }
        public void StartController()
        {
            if (Master != null)
            {
                mouseController.Start(this.Master.ToSn);
                keyboardController.Start(this.Master.ToSn);
            }
        }
        public void StopController(bool isNotifyClient = false)
        {
            if (isNotifyClient)
            {
                CommonMessage.SendMessage(this.Master.ToSn, MessageTypes.ToClient_StopControl);
            }
            mouseController.Stop();
            keyboardController.Stop();
            if (this.IsFullScreen) { this.IsFullScreen = false; }
        }
        private void trackBar_Scroll(object sender, EventArgs e)
        {
            if (Master != null)
            {
                Master.SetScreenQuality(trackBar.Value);
            }
        }

        #region 全屏代码
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
                return this.FormBorderStyle == FormBorderStyle.None;
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
                    this.statusStrip.Visible = false;
                    picture.BorderStyle = BorderStyle.None;
                    trackBar.Visible = false;
                }
                else
                {
                    this.FormBorderStyle = FormBorderStyle.Sizable;
                    this.picture.Anchor = FullScreenOldStaus.oldAnchor;
                    this.WindowState = FullScreenOldStaus.oldWindowState;
                    this.picture.Width = FullScreenOldStaus.oldWidth;
                    this.picture.Height = FullScreenOldStaus.oldHeight;
                    this.statusStrip.Visible = true;
                    picture.BorderStyle = BorderStyle.FixedSingle;
                    trackBar.Visible = true;
                }
                System.Threading.Thread th = new System.Threading.Thread(() =>
                {
                    Rectangle rectOld = new Rectangle();
                    TaskBarHelper.SetFullScreen(value, ref rectOld);
                });
                th.Start();
            }
        }


        #endregion


    }
}
