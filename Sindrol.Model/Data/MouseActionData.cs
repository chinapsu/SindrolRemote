using Sindrol.Model.Enums;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;

namespace Sindrol.Model.Data
{
    /// <summary>
    ///鼠标动作数据
    /// </summary>
    [Serializable]
    public class MouseActionData
    {
        /// <summary>
        /// 动作
        /// </summary>
        public MouseAction Action { get; set; }
        /// <summary>
        /// 滚动鼠标轮时的数量
        /// </summary>
        public int Delta { get; set; }

        /// <summary>
        /// 相对宽度的1分之几
        /// </summary>
        public float LeftRate { get; set; }
        /// <summary>
        /// 相对高度的1分之几
        /// </summary>
        public float TopRate { get; set; }
    }
}
