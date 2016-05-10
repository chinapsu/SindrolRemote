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
using Cocon90.Lib.Util.Window.Input.InputSimulator.Native;

namespace SindrolClient.Core.AsClient
{
    /// <summary>
    /// 鼠标模拟器，用于处理服务器发来的鼠标指令相关消息
    /// </summary>
    public class KeyboardSimulatorMaster
    {
        private InputSimulator inputSimulator;
        private Form mainForm;
        public KeyboardSimulatorMaster(Form mainForm, InputSimulator inputSimulator)
        {
            this.mainForm = mainForm;
            this.inputSimulator = inputSimulator;
        }

        public void Simulator(MessageEntry msg)
        {
            if (msg.MessageType != MessageTypes.ToClient_DoKeyBoardAction) return;
            var mouseData = msg.MessageData as KeyboardActionData;
            if (mouseData == null) return;
            SimulatorOne(mouseData);
        }


        private void SimulatorOne(KeyboardActionData keyData)
        {
            if (keyData == null) return;
            if (keyData.Action == KeyboardAction.KeyDown)
            {
                this.inputSimulator.Keyboard.KeyDown((VirtualKeyCode)((int)keyData.Key));
                return;
            }
            if (keyData.Action == KeyboardAction.KeyUp)
            {
                this.inputSimulator.Keyboard.KeyUp((VirtualKeyCode)((int)keyData.Key));
                return;
            }


        }
    }
}
