using Sindrol.Model.Data;
using Sindrol.Model.Enums;
using Sindrol.Model.Message;
using Sindrol.Model.Utils;
using Sindrol.Service;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace SindrolClient.Core.AsServer
{
    class MouseController
    {
        public System.Windows.Forms.Control DisplayControl { get; set; }
        public long ToSn { get; set; }
        public bool IsNeedRecord { get; set; }

        public int MouseMoveLen = 4;//用于鼠标是精度
        public MouseController(System.Windows.Forms.Control displayControl)
        {
            this.DisplayControl = displayControl;
            this.DisplayControl.MouseMove += (ss, ee) => { Handler(MouseAction.MouseMove, ee.Location); };
            this.DisplayControl.MouseDown += (ss, ee) =>
            {
                if (ee.Button == MouseButtons.Left) Handler(MouseAction.MouseLeftDown, ee.Location);
                if (ee.Button == MouseButtons.Middle) Handler(MouseAction.MouseMiddleDown, ee.Location);
                if (ee.Button == MouseButtons.Right) Handler(MouseAction.MouseRightDown, ee.Location);
            };
            this.DisplayControl.MouseUp += (ss, ee) =>
            {
                if (ee.Button == MouseButtons.Left) Handler(MouseAction.MouseLeftUp, ee.Location);
                if (ee.Button == MouseButtons.Middle) Handler(MouseAction.MouseMiddleUp, ee.Location);
                if (ee.Button == MouseButtons.Right) Handler(MouseAction.MouseRightUp, ee.Location);
            };
            this.DisplayControl.FindForm().MouseWheel += (ss, ee) =>
            {
                if (ee.X > this.DisplayControl.Left && ee.Y > this.DisplayControl.Top && ee.X < this.DisplayControl.Left + this.DisplayControl.Width && ee.Y < this.DisplayControl.Top + this.DisplayControl.Height)
                {
                    Handler(MouseAction.MouseWheel, ee.Location, ee.Delta);
                }
            };
        }
        Point lastMovePoint;
        private void Handler(MouseAction action, Point point, int delta = 0)
        {
            //注意，这里的Point为相对于DisplayControl的位置，左上角为（0,0）坐标。
            if (IsNeedRecord && Notify.notifyClient != null)
            {
                if (action == MouseAction.MouseMove)
                {//移动的时候，看距离变动是否大，小的话，就忽略了。
                    if (Math.Abs(lastMovePoint.X - point.X) < MouseMoveLen || Math.Abs(lastMovePoint.X - point.X) < MouseMoveLen) return;
                }
                lastMovePoint = point;//记录本次的位置。
                MouseActionData data = new MouseActionData();
                data.Action = action;
                data.LeftRate = (point.X * 1.0f) / (DisplayControl.Width * 1.0f);
                data.TopRate = (point.Y * 1.0f) / (DisplayControl.Height * 1.0f);
                data.Delta = delta;
                CommonMessage.SendMessage(this.ToSn, MessageTypes.ToClient_DoMouseAction, data);
            }

             
        }
        public void Start(long toSn)
        {
            this.ToSn = toSn;
            this.IsNeedRecord = true;
        }

        public void Stop()
        {
            this.IsNeedRecord = false;
        }
    }
}
