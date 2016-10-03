using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.Linq;
using System.Text;

namespace WebCamMonitor
{
    public static class ImageExtensions
    {
        public static void SaveJPG(this Image img, string filename, long quality)
        {
            EncoderParameters encoderParameters = new EncoderParameters(1);
            encoderParameters.Param[0] = new EncoderParameter(System.Drawing.Imaging.Encoder.Quality, quality);
            img.Save(filename, GetEncoder(ImageFormat.Jpeg), encoderParameters);
        }

        public static void SaveJPG100(this Image img, string filename)
        {
            SaveJPG(img, filename, 100);
        }

        /// <summary>
        /// Draw text over an image
        /// </summary>
        /// <param name="bmp"></param>
        /// <param name="s"></param>
        public static void DrawText(this Image img, string s)
        {
            using (Graphics g = Graphics.FromImage(img))
            {
                g.DrawString(s, new Font("Tahoma", 14), Brushes.White, new PointF(0, 0));
            }
        }

        public static ImageCodecInfo GetEncoder(ImageFormat format)
        {
            ImageCodecInfo[] codecs = ImageCodecInfo.GetImageDecoders();

            foreach (ImageCodecInfo codec in codecs)
            {
                if (codec.FormatID == format.Guid)
                    return codec;
            }
            return null;
        }

        public static Image ResizeImage(this Image imgToResize, Size size)
        {
            int sourceWidth = imgToResize.Width;
            int sourceHeight = imgToResize.Height;

            float nPercent = 0;
            float nPercentW = 0;
            float nPercentH = 0;

            nPercentW = ((float)size.Width / (float)sourceWidth);
            nPercentH = ((float)size.Height / (float)sourceHeight);

            if (nPercentH < nPercentW)
                nPercent = nPercentH;
            else
                nPercent = nPercentW;

            int destWidth = (int)(sourceWidth * nPercent);
            int destHeight = (int)(sourceHeight * nPercent);

            Bitmap b = new Bitmap(destWidth, destHeight);
            using (Graphics g = Graphics.FromImage((Image)b))
            {
                g.InterpolationMode = InterpolationMode.HighQualityBicubic;
                g.DrawImage(imgToResize, 0, 0, destWidth, destHeight);
            }

            return (Image)b;
        }

        public static Image EmptyCameraWindowImage(int w, int h)
        {
            var newBitMap = new Bitmap(w, h);
            using (Graphics gfx = Graphics.FromImage(newBitMap))
            {
                gfx.FillRectangle(new SolidBrush(Color.Black), 0, 0, newBitMap.Width, newBitMap.Height);
            }
            return newBitMap;
        }

    }
}
