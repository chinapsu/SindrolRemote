using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sindrol.Model.Enums
{
    /// <summary>
    /// 鼠标动作
    /// </summary>
    public enum MouseAction : byte
    {
        None = 0,
        MouseLeftDown = 1,
        MouseLeftUp = 2,
        MouseRightDown = 3,
        MouseRightUp = 4,
        MouseMiddleDown = 5,
        MouseMiddleUp = 6,
        MouseMove = 7,
        MouseWheel = 8
    }
}
