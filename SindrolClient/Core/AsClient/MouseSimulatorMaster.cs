using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Sindrol.Model.Message;
using Sindrol.Model.Enums;
using System.Drawing;
using Sindrol.Model.Utils;
using System.Windows.Forms;
using Cocon90.Lib.Util.Window.Input.InputSimulator;
using Sindrol.Model.Data;

namespace SindrolClient.Core.AsClient
{
    /// <summary>
    /// 鼠标模拟器，用于处理服务器发来的鼠标指令相关消息
    /// </summary>
    public class MouseSimulatorMaster
    {
        private InputSimulator inputSimulator;
        private Form mainForm;
        public MouseSimulatorMaster(Form mainForm, InputSimulator inputSimulator)
        {
            this.mainForm = mainForm;
            this.inputSimulator = inputSimulator;
        }

        public void Simulator(MessageEntry msg)
        {
            if (msg.MessageType != MessageTypes.ToClient_DoMouseAction) return;
            var mouseData = msg.MessageData as MouseActionData;
            if (mouseData == null) return;
            SimulatorOne(mouseData);
        }


        private void SimulatorOne(MouseActionData mouseData)
        {
            if (mouseData == null) return;
            //获取当前的屏幕大小。因为屏幕分辩率可能会发生调整。所以写在这里。
            //var size = Sindrol.Model.Utils.ScreenCapture.getScreenSize();
            if (mouseData.Action == MouseAction.MouseMove)
            {
                var x = (int)Math.Round(ushort.MaxValue * mouseData.LeftRate);
                var y = (int)Math.Round(ushort.MaxValue * mouseData.TopRate);
                this.inputSimulator.Mouse.MoveMouseTo(x, y);
                return;
            }
            if (mouseData.Action == MouseAction.MouseLeftDown)
            {
                this.inputSimulator.Mouse.LeftButtonDown();
                return;
            }
            if (mouseData.Action == MouseAction.MouseLeftUp)
            {
                this.inputSimulator.Mouse.LeftButtonUp();
                return;
            }
            if (mouseData.Action == MouseAction.MouseRightDown)
            {
                this.inputSimulator.Mouse.RightButtonDown();
                return;
            }
            if (mouseData.Action == MouseAction.MouseRightUp)
            {
                this.inputSimulator.Mouse.RightButtonUp();
                return;
            }
            if (mouseData.Action == MouseAction.MouseWheel)
            {
                this.inputSimulator.Mouse.VerticalScroll((mouseData.Delta / SystemInformation.MouseWheelScrollDelta) * SystemInformation.MouseWheelScrollLines);
                return;
            }

        }
    }
}
