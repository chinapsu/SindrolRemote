using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Windows.Forms;

namespace SindrolClient.Core.AsServer
{
    public class TaskBarHelper
    {

        /// <summary>
        /// 设置全屏或这取消全屏
        /// </summary>
        /// <param name="fullscreen">true:全屏 false:恢复</param>
        /// <param name="rectOld">设置的时候，此参数返回原始尺寸，恢复时用此参数设置恢复</param>
        /// <returns>设置结果</returns>
        public static bool SetFullScreen(bool fullscreen, ref Rectangle rectOld)
        {
            try
            {
                int Hwnd = 0;
                Hwnd = FindWindow("Shell_TrayWnd", null);
                if (Hwnd == 0) return false;
                if (fullscreen)
                {
                    ShowWindow(Hwnd, SW_HIDE);
                    Rectangle rectFull = Screen.PrimaryScreen.Bounds;
                    SystemParametersInfo(SPI_GETWORKAREA, 0, ref rectOld, SPIF_UPDATEINIFILE);//get
                    SystemParametersInfo(SPI_SETWORKAREA, 0, ref rectFull, SPIF_UPDATEINIFILE);//set
                }
                else
                {
                    ShowWindow(Hwnd, SW_SHOW);
                    SystemParametersInfo(SPI_SETWORKAREA, 0, ref rectOld, SPIF_UPDATEINIFILE);
                }
                return true;
            }
            catch { return false; }
        }

        [DllImport("user32.dll", EntryPoint = "ShowWindow")]
        public static extern int ShowWindow(int hwnd, int nCmdShow);
        public const int SW_SHOW = 5; public const int SW_HIDE = 0;

        [DllImport("user32.dll", EntryPoint = "SystemParametersInfo")]
        private static extern int SystemParametersInfo(int uAction, int uParam, ref Rectangle lpvParam, int fuWinIni);
        public const int SPIF_UPDATEINIFILE = 0x1;
        public const int SPI_SETWORKAREA = 47;
        public const int SPI_GETWORKAREA = 48;

        [DllImport("user32.dll", EntryPoint = "FindWindow")]
        private static extern int FindWindow(string lpClassName, string lpWindowName);

    }
}
