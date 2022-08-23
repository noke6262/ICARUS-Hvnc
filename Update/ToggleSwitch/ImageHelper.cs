using System;
using System.Drawing;
using System.Drawing.Imaging;

namespace BirdBrainmofo.ToggleSwitch
{
    public static class ImageHelper
    {
        private static float[][] _colorMatrixElements;

        private static ColorMatrix _grayscaleColorMatrix;

        public static ImageAttributes GetGrayscaleAttributes()
        {
            ImageAttributes imageAttributes = new ImageAttributes();
            imageAttributes.SetColorMatrix(ImageHelper._grayscaleColorMatrix, ColorMatrixFlag.Default, ColorAdjustType.Bitmap);
            return imageAttributes;
        }

        public static Size RescaleImageToFit(Size imageSize, Size canvasSize)
        {
            double num = Math.Min((double)canvasSize.Width / (double)imageSize.Width, (double)canvasSize.Height / (double)imageSize.Height);
            Size result = new Size(height: Convert.ToInt32((double)imageSize.Height * num), width: Convert.ToInt32((double)imageSize.Width * num));
            if (result.Width > canvasSize.Width || result.Height > canvasSize.Height)
            {
                throw new Exception("ImageHelper.RescaleImageToFit - Resize failed!");
            }
            return result;
        }

        static ImageHelper()
        {
            ImageHelper._colorMatrixElements = new float[5][]
            {
                new float[5] { 0.299f, 0.299f, 0.299f, 0f, 0f },
                new float[5] { 0.587f, 0.587f, 0.587f, 0f, 0f },
                new float[5] { 0.114f, 0.114f, 0.114f, 0f, 0f },
                new float[5] { 0f, 0f, 0f, 1f, 0f },
                new float[5] { 0f, 0f, 0f, 0f, 1f }
            };
            ImageHelper._grayscaleColorMatrix = new ColorMatrix(ImageHelper._colorMatrixElements);
        }
    }
}