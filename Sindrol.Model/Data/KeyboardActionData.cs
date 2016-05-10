using Sindrol.Model.Enums;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Sindrol.Model.Data
{
    /// <summary>
    ///键盘动作数据
    /// </summary>
    [Serializable]
    public class KeyboardActionData
    {
        /// <summary>
        /// 动作
        /// </summary>
        public KeyboardAction Action { get; set; }
        /// <summary>
        /// 相对高度的1分之几
        /// </summary>
        public Keys Key { get; set; }
    }
}
