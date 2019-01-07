using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.IO;

namespace Seldino.CrossCutting.Web.Helpers
{

    public static class ImageProcessing
    {
        public static void CreateThumbnail(string filename, string path, int width, int height)
        {
            if (string.IsNullOrEmpty(filename))
                throw new NullReferenceException("parameter Image cannot be null or empty");

            var filePath = filename;

            if (!File.Exists(filePath))
                throw new FileNotFoundException("Image does not exist at " + filePath);

            var bitmap = new Bitmap(filePath);

            try
            {
                if (bitmap.Width < width && bitmap.Height < height)
                {
                    string finalPath = path + "" + Path.GetFileName(filename);

                    bitmap.Save(finalPath, ImageFormat.Jpeg);
                    return;
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
            finally
            {
                bitmap.Dispose();
            }

            Bitmap finalBitmap = null;

            try
            {
                bitmap = new Bitmap(filePath);
                int bitmapNewWidth;
                decimal Ratio;
                int bitmapNewHeight;

                if (bitmap.Width > bitmap.Height)
                {
                    Ratio = (decimal)width / bitmap.Height;
                    bitmapNewWidth = width;

                    decimal temp = bitmap.Height * Ratio;
                    bitmapNewHeight = (int)temp;
                }
                else
                {
                    Ratio = (decimal)height / bitmap.Height;
                    bitmapNewHeight = height;
                    decimal temp = bitmap.Width * Ratio;
                    bitmapNewWidth = (int)temp;
                }

                finalBitmap = new Bitmap(bitmapNewWidth, bitmapNewHeight);
                Graphics graphics = Graphics.FromImage(finalBitmap);
                graphics.InterpolationMode = InterpolationMode.HighQualityBicubic;
                graphics.FillRectangle(Brushes.White, 0, 0, bitmapNewWidth, bitmapNewHeight);
                graphics.DrawImage(bitmap, 0, 0, bitmapNewWidth, bitmapNewHeight);
                string finalPath = path + "" + Path.GetFileName(filename);
                finalBitmap.Save(finalPath, ImageFormat.Jpeg);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
            finally
            {
                if (finalBitmap != null) finalBitmap.Dispose();
            }
        }
    }
}
