using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Drawing;
using System.Drawing.Imaging;
using System.Drawing.Drawing2D;
using System.Text;

namespace WebImage.Functions
{
    public class ImageMethods
    {
        public System.Drawing.Image resizeImage(System.Drawing.Image imgToResize, Size size)
        {
            //store original sizes
            int sourceWidth = imgToResize.Width;
            int sourceHeight = imgToResize.Height;

            //find percent to scale by
            float percent = 0;
            float percentW = 0;
            float percentH = 0;

            percentW = ((float)size.Width / (float)sourceWidth);
            percentH = ((float)size.Height / (float)sourceHeight);

            if (percentH < percentW)
            {
                percent = percentH;
            }
            else
            {
                percent = percentW;
            }

            //get target sizes
            int destWidth = (int)(sourceWidth * percent);
            int destHeight = (int)(sourceHeight * percent);

            //create a bitmap with new size
            Bitmap b = new Bitmap(destWidth, destHeight);
            Graphics g = Graphics.FromImage((System.Drawing.Image)b);
            g.InterpolationMode = InterpolationMode.HighQualityBicubic;

            //draw original image on bitmap
            g.DrawImage(imgToResize, 0, 0, destWidth, destHeight);
            g.Dispose();

            //return new image
            return (System.Drawing.Image)b;
        }

        public System.Drawing.Image textImage(System.Drawing.Image img, string text)
        {
            Bitmap bmpImage = new Bitmap(img);
            PointF poinf = new PointF(100, 20);

            int x = 20;
            int y = 10;
            var brush = Brushes.Black;
            var props = img.PropertyItems;

            using (Graphics g = Graphics.FromImage((System.Drawing.Image)bmpImage))
            {
                if (!string.IsNullOrEmpty(text))
                {
                    g.DrawString(text, new Font("Arial", 20), brush, poinf);
                }
                else
                {
                    foreach (var p in props)
                    {
                        g.DrawString("Id: " + p.Id.ToString() + " type: " + p.Type.ToString() + " value: " + Encoding.UTF8.GetString(p.Value, 0, p.Value.Length), new Font("Arial", 10), brush, x, y);
                        y += 10;
                    }
                }
                
            }

            return (System.Drawing.Image)bmpImage;
        }

        public System.Drawing.Image transformImage(System.Drawing.Image img)
        {
            img.RotateFlip(RotateFlipType.Rotate90FlipNone);

            Bitmap bmpImage = new Bitmap(img);

            using (Graphics g = Graphics.FromImage(img))
            {
                var pen = new Pen(Brushes.LightGray, 1);
                g.DrawEllipse(pen, 30, 30, 160, 160);
            }

            return (System.Drawing.Image)bmpImage;
        }
    }
}