using Sindrol.Model.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.Drawing.Imaging;

namespace Sindrol.Model.Utils
{
    public class ScreenHelper
    {

        /// <summary>
        /// 图像质量
        /// </summary>
        public static int ImageThumbnail { get { return imageThumbnail; } set { imageThumbnail = value; } }
        static int imageThumbnail = 100;

        /// <summary>
        /// 取得指定屏幕划分后，指定块的图像。
        /// </summary>
        public static ImageObject GetScreenImageObject(Bitmap allScreen, int wIndex, int hIndex, int wCount, int hCount)
        {
            ImageObject img = new ImageObject();
            var size = allScreen.Size;
            img.Width = (size.Width * 1.0f) / (wCount * 1.0f);
            img.Height = (size.Height * 1.0f) / (hCount * 1.0f);
            img.X = wIndex * (img.Width);
            img.Y = hIndex * (img.Height);
            //向构建好的对像中添加值。
            var bmp = new Bitmap((int)Math.Round(img.Width), (int)Math.Round(img.Height), PixelFormat.Format16bppRgb555);
            var g = Graphics.FromImage(bmp);
            g.DrawImage(allScreen, new Rectangle(0, 0, bmp.Width, bmp.Height), new Rectangle((int)img.X, (int)img.Y, bmp.Width, bmp.Height), GraphicsUnit.Pixel);
            System.IO.MemoryStream ms = new System.IO.MemoryStream();
            bmp.Save(ms, System.Drawing.Imaging.ImageFormat.Jpeg);
            bmp.Dispose();
            //截图后进行压缩
            //System.IO.MemoryStream msOut = new System.IO.MemoryStream();
            //ImageEncode.GetPicThumbnail(ms, out msOut, (int)img.Height, (int)img.Width, ImageThumbnail);
            //ms.Close();
            //ms.Dispose();
            //img.Data = msOut.ToArray();
            //msOut.Close();
            //msOut.Dispose();

            img.Data = ms.ToArray();
            ms.Close();
            ms.Dispose();
            //返回
            return img;
        }

    }
}
