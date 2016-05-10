using Sindrol.Model.Data;
using Sindrol.Model.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SindrolClient.Core.AsClient
{
    public class ScreenSender
    {
        private int widthCount;
        private int heightCount;
        public ScreenImageObject LastImageObject { get; set; }//压缩过的上次发送的Bitmap图像集，用于发送用
        public ScreenImageObject LastImageObject_Full { get; set; }//表示全屏幕块
        public ScreenSender(int widthCount, int heightCount)
        {
            this.widthCount = widthCount;
            this.heightCount = heightCount;
            this.LastImageObject = new ScreenImageObject(widthCount, heightCount);
            this.LastImageObject_Full = new ScreenImageObject(widthCount, heightCount);//表示全屏幕块
        }
        /// <summary>
        /// 置空全屏块
        /// </summary>
        public void ResetRemoteScreenCache()
        {
            this.LastImageObject_Full.InitImages();
        }
        
        /// <summary>
        /// 返回本次应该发送的变化过的截屏，传出是否需要发送。如果返回NULL，则表示不需要发送返回。
        /// </summary>
        /// <returns></returns>
        public ScreenImageObject GetScreenNeedSend()
        {

            //var dt = DateTime.Now;
            ImageObject[,] needAddObject = new ImageObject[widthCount, heightCount];
            var allScreen = ScreenCapture.captureScreen();
            System.IO.MemoryStream ms = new System.IO.MemoryStream();
            allScreen.Save(ms, System.Drawing.Imaging.ImageFormat.Jpeg);
            System.IO.MemoryStream msOut = new System.IO.MemoryStream();
            ImageEncode.GetPicThumbnail(ms, out msOut, (int)Math.Round(allScreen.Height * ScreenHelper.ImageThumbnail * 0.01), (int)Math.Round(allScreen.Width * ScreenHelper.ImageThumbnail * 0.01), 100);
            ms.Close();
            ms.Dispose();
            allScreen.Dispose();
            allScreen = (System.Drawing.Bitmap)System.Drawing.Bitmap.FromStream(msOut);
            msOut.Close();
            msOut.Dispose();
            var allCount = widthCount * heightCount;
            var count = 0;
            for (int w = 0; w < widthCount; w++)
            {
                for (int h = 0; h < heightCount; h++)
                {
                    var img_Old = this.LastImageObject_Full.Images[w, h];//取得上一次发送的图像。
                    var img_Now = ScreenHelper.GetScreenImageObject(allScreen, w, h, widthCount, heightCount);//将屏幕分为widthCount和heightCount后，取得第x方向w索引的块和y方向h索引的图像块。
                    if (ImageObject.IsSame(img_Old, img_Now)) continue;//如果图片没发生变化，则返回
                    needAddObject[w, h] = img_Now;//如果发生了变化，则存下来，发给对方。
                    LastImageObject_Full.Images[w, h] = img_Now;//每次的变化，最终都存下来。
                    count++;
                }
            }
            allScreen.Dispose();
            this.LastImageObject.Images = needAddObject;
            if (count != 0)
            {
                //var time = DateTime.Now - dt;
                //LoggerHelper.Logger.addToLog("共" + widthCount * heightCount + "变化：" + count + "  共用时：" + time.TotalMilliseconds);
                return this.LastImageObject;
            }
            else return null;
        }
    }
}
