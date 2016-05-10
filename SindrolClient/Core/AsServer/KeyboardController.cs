using Cocon90.Lib.Util.Window.Hook.RamGecTools;
using Cocon90.Lib.Util.Window.Input.InputSimulator;
using Sindrol.Model.Data;
using Sindrol.Model.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace SindrolClient.Core.AsServer
{
    public class KeyboardController
    {
        public System.Windows.Forms.Control DisplayControl { get; set; }
        public long ToSn { get; set; }
        public bool IsNeedRecord { get; set; }
        private KeyboardHook keyboardHook = null;
        public KeyboardController(System.Windows.Forms.Control displayControl)
        {
            this.DisplayControl = displayControl;
            var form = displayControl.FindForm();
            form.KeyDown += (ss, ee) =>
            {
                if (IsNeedRecord || this.DisplayControl.Dock == DockStyle.Fill || ((Cursor.Position.X > form.Left + this.DisplayControl.Left) && (Cursor.Position.X < form.Left + this.DisplayControl.Left + this.DisplayControl.Width) && (Cursor.Position.Y > form.Top + this.DisplayControl.Top) && (Cursor.Position.Y < form.Top + this.DisplayControl.Top + this.DisplayControl.Height)))
                { ee.Handled = true; }
            };
            keyboardHook = new KeyboardHook();
            keyboardHook.KeyDown += (key) => { HandleKey(KeyboardAction.KeyDown, (Keys)key); };
            keyboardHook.KeyUp += (key) => { HandleKey(KeyboardAction.KeyUp, (Keys)key); };
        }


        public void HandleKey(KeyboardAction action, Keys key)
        {
            if (this.IsNeedRecord)
            {
                CommonMessage.SendMessage(this.ToSn, MessageTypes.ToClient_DoKeyBoardAction, new KeyboardActionData() { Action = action, Key = key });
            }
        }

        public void Start(long toSn)
        {
            this.ToSn = toSn;
            this.IsNeedRecord = true;
            keyboardHook.Install();
        }

        public void Stop()
        {
            keyboardHook.Uninstall();
            this.IsNeedRecord = false;
        }
    }
}
