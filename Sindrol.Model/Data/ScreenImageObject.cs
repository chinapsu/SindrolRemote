using Sindrol.Model.Utils;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Sindrol.Model.Data
{
    /// <summary>
    /// 表示一个屏幕图像对像
    /// </summary>
    [Serializable]
    public class ScreenImageObject
    {

        /// <summary>
        /// 显示的图片
        /// </summary>
        public static Bitmap DisplayImage { get; set; }
        private int widthCount;
        private int heightCount;
        Rectangle tarRect = new Rectangle();
        Rectangle srcRect = new Rectangle(0, 0, 0, 0);
        public ScreenImageObject(int widthCount, int heightCount)
        {
            this.widthCount = widthCount;
            this.heightCount = heightCount;
        }
        static ScreenImageObject()
        {
            var size = ScreenCapture.getScreenSize();
            DisplayImage = new Bitmap(size.Width, size.Height);//虚拟屏大小。
        }
        /// <summary>
        /// 置空图像数组。
        /// </summary>
        public void InitImages()
        {
            images = new ImageObject[widthCount, heightCount];
        }
        public ImageObject[,] Images { get { return images; } set { images = value; } }
        ImageObject[,] images = null;

        /// <summary>
        /// 将当前图片展示到Bitmap。
        /// </summary>
        /// <param name="displayControl"></param>
        public void DisplayToControl(Control control)
        {
            var g = System.Drawing.Graphics.FromImage(DisplayImage);
            for (int w = 0; w < widthCount; w++)
            {
                for (int h = 0; h < heightCount; h++)
                {
                    var imgObj = this.Images[w, h];
                    if (imgObj == null) continue;
                    var imgBys = new System.IO.MemoryStream(imgObj.Data);
                    var img = Image.FromStream(imgBys);
                    var newWidth = (DisplayImage.Width * 1.00f) / widthCount;
                    var newHeight = (DisplayImage.Height * 1.00f) / heightCount;
                    var newX = w * newWidth;
                    var newY = h * newHeight;
                    tarRect.X = (int)Math.Round(newX);
                    tarRect.Y = (int)Math.Round(newY);
                    tarRect.Width = (int)Math.Round(newWidth);
                    tarRect.Height = (int)Math.Round(newHeight);
                    srcRect.Width = img.Width;
                    srcRect.Height = img.Height;
                    g.DrawImage(img, tarRect, srcRect, GraphicsUnit.Pixel);
                    imgBys.Close();
                    imgBys.Dispose();
                }
            }
            g.Save();
            g.Dispose();
            //刷新控件
            control.Invoke(new Action(() =>
            {
                if (control.BackgroundImage != DisplayImage) control.BackgroundImage = DisplayImage;
                control.Refresh();
            }));
        }
    }

    [Serializable]
    public class ImageObject
    {
        public float X { get; set; }
        public float Y { get; set; }
        public float Width { get; set; }
        public float Height { get; set; }
        public byte[] Data { get; set; }
        public static bool IsSame(ImageObject img1, ImageObject img2)
        {
            if (img1 == null && img2 != null) return false;
            if (img1 != null && img2 == null) return false;
            if (img1.X == img2.X && img1.Y == img2.Y && img1.Width == img2.Width && img1.Height == img2.Height)
            {
                if (img1.Data == null && img2.Data == null) return true;
                if (img1.Data != null && img2.Data == null) return false;
                if (img1.Data == null && img2.Data != null) return false;
                if (img1.Data.Length > img2.Data.Length) return false;
                for (int i = 0; i < img1.Data.Length; i++)
                {
                    if (img1.Data[i] != img2.Data[i]) return false;
                }
                return true;
            }
            return false;
        }

    }
}
