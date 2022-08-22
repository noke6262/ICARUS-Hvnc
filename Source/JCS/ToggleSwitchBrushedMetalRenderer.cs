using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using ICARUS.ToggleSwitch;

namespace ICARUS.JCS
{
    public class ToggleSwitchBrushedMetalRenderer : ToggleSwitchRendererBase
    {
        public Color BorderColor1 { get; set; }

        public Color BorderColor2 { get; set; }

        public Color BackColor1 { get; set; }

        public Color BackColor2 { get; set; }

        public Color UpperShadowColor1 { get; set; }

        public Color UpperShadowColor2 { get; set; }

        public Color ButtonNormalBorderColor { get; set; }

        public Color ButtonNormalSurfaceColor { get; set; }

        public Color ButtonHoverBorderColor { get; set; }

        public Color ButtonHoverSurfaceColor { get; set; }

        public Color ButtonPressedBorderColor { get; set; }

        public Color ButtonPressedSurfaceColor { get; set; }

        public int UpperShadowHeight { get; set; }

        public ToggleSwitchBrushedMetalRenderer()
        {
            this.BorderColor1 = Color.FromArgb(255, 145, 146, 149);
            this.BorderColor2 = Color.FromArgb(255, 227, 229, 232);
            this.BackColor1 = Color.FromArgb(255, 125, 126, 128);
            this.BackColor2 = Color.FromArgb(255, 224, 226, 228);
            this.UpperShadowColor1 = Color.FromArgb(150, 0, 0, 0);
            this.UpperShadowColor2 = Color.FromArgb(5, 0, 0, 0);
            this.ButtonNormalBorderColor = Color.FromArgb(255, 144, 144, 145);
            this.ButtonNormalSurfaceColor = Color.FromArgb(255, 251, 251, 251);
            this.ButtonHoverBorderColor = Color.FromArgb(255, 166, 167, 168);
            this.ButtonHoverSurfaceColor = Color.FromArgb(255, 238, 238, 238);
            this.ButtonPressedBorderColor = Color.FromArgb(255, 123, 123, 123);
            this.ButtonPressedSurfaceColor = Color.FromArgb(255, 184, 184, 184);
            this.UpperShadowHeight = 8;
        }

        public override void RenderBorder(Graphics graphics_0, Rectangle borderRectangle)
        {
            graphics_0.SmoothingMode = SmoothingMode.HighQuality;
            graphics_0.PixelOffsetMode = PixelOffsetMode.HighQuality;
            graphics_0.InterpolationMode = InterpolationMode.HighQualityBilinear;
            using (GraphicsPath graphicsPath = this.GetRectangleClipPath(borderRectangle))
            {
                graphics_0.SetClip(graphicsPath);
                using (Brush brush = new LinearGradientBrush(color1: (base.ToggleSwitch.Enabled || !base.ToggleSwitch.GrayWhenDisabled) ? this.BorderColor1 : this.BorderColor1.ToGrayScale(), color2: (base.ToggleSwitch.Enabled || !base.ToggleSwitch.GrayWhenDisabled) ? this.BorderColor2 : this.BorderColor2.ToGrayScale(), rect: borderRectangle, linearGradientMode: LinearGradientMode.Vertical))
                {
                    graphics_0.FillPath(brush, graphicsPath);
                }
                graphics_0.ResetClip();
            }
            Rectangle rect = new Rectangle(borderRectangle.X + 1, borderRectangle.Y + 1, borderRectangle.Width - 1, borderRectangle.Height - 2);
            using GraphicsPath graphicsPath2 = this.GetRectangleClipPath(rect);
            graphics_0.SetClip(graphicsPath2);
            using (Brush brush2 = new LinearGradientBrush(color1: (base.ToggleSwitch.Enabled || !base.ToggleSwitch.GrayWhenDisabled) ? this.BackColor1 : this.BackColor1.ToGrayScale(), color2: (base.ToggleSwitch.Enabled || !base.ToggleSwitch.GrayWhenDisabled) ? this.BackColor2 : this.BackColor2.ToGrayScale(), rect: borderRectangle, linearGradientMode: LinearGradientMode.Horizontal))
            {
                graphics_0.FillPath(brush2, graphicsPath2);
            }
            Rectangle rect2 = new Rectangle(rect.X, rect.Y, rect.Width, this.UpperShadowHeight);
            graphics_0.IntersectClip(rect2);
            using (Brush brush3 = new LinearGradientBrush(rect2, this.UpperShadowColor1, this.UpperShadowColor2, LinearGradientMode.Vertical))
            {
                graphics_0.FillRectangle(brush3, rect2);
            }
            graphics_0.ResetClip();
        }

        public override void RenderLeftToggleField(Graphics graphics_0, Rectangle leftRectangle, int totalToggleFieldWidth)
        {
            graphics_0.SmoothingMode = SmoothingMode.HighQuality;
            graphics_0.PixelOffsetMode = PixelOffsetMode.HighQuality;
            graphics_0.InterpolationMode = InterpolationMode.HighQualityBilinear;
            using GraphicsPath clip = this.GetRectangleClipPath(new Rectangle(1, 1, base.ToggleSwitch.Width - 1, base.ToggleSwitch.Height - 2));
            graphics_0.SetClip(clip);
            if (base.ToggleSwitch.OnSideImage != null || !string.IsNullOrEmpty(base.ToggleSwitch.OnText))
            {
                RectangleF rect = new RectangleF(leftRectangle.X + 2 - (totalToggleFieldWidth - leftRectangle.Width), 2f, totalToggleFieldWidth - 2, base.ToggleSwitch.Height - 4);
                graphics_0.IntersectClip(rect);
                if (base.ToggleSwitch.OnSideImage != null)
                {
                    Size size = base.ToggleSwitch.OnSideImage.Size;
                    int x = (int)rect.X;
                    if (base.ToggleSwitch.OnSideScaleImageToFit)
                    {
                        Size size2 = ImageHelper.RescaleImageToFit(canvasSize: new Size((int)rect.Width, (int)rect.Height), imageSize: size);
                        if (base.ToggleSwitch.OnSideAlignment == ToggleSwitch.ToggleSwitchAlignment.Center)
                        {
                            x = (int)(rect.X + (rect.Width - (float)size2.Width) / 2f);
                        }
                        else if (base.ToggleSwitch.OnSideAlignment == ToggleSwitch.ToggleSwitchAlignment.Near)
                        {
                            x = (int)(rect.X + rect.Width - (float)size2.Width);
                        }
                        Rectangle rectangle = new Rectangle(x, (int)(rect.Y + (rect.Height - (float)size2.Height) / 2f), size2.Width, size2.Height);
                        if (!base.ToggleSwitch.Enabled && base.ToggleSwitch.GrayWhenDisabled)
                        {
                            graphics_0.DrawImage(base.ToggleSwitch.OnSideImage, rectangle, 0, 0, base.ToggleSwitch.OnSideImage.Width, base.ToggleSwitch.OnSideImage.Height, GraphicsUnit.Pixel, ImageHelper.GetGrayscaleAttributes());
                        }
                        else
                        {
                            graphics_0.DrawImage(base.ToggleSwitch.OnSideImage, rectangle);
                        }
                    }
                    else
                    {
                        if (base.ToggleSwitch.OnSideAlignment == ToggleSwitch.ToggleSwitchAlignment.Center)
                        {
                            x = (int)(rect.X + (rect.Width - (float)size.Width) / 2f);
                        }
                        else if (base.ToggleSwitch.OnSideAlignment == ToggleSwitch.ToggleSwitchAlignment.Near)
                        {
                            x = (int)(rect.X + rect.Width - (float)size.Width);
                        }
                        Rectangle rectangle = new Rectangle(x, (int)(rect.Y + (rect.Height - (float)size.Height) / 2f), size.Width, size.Height);
                        if (!base.ToggleSwitch.Enabled && base.ToggleSwitch.GrayWhenDisabled)
                        {
                            graphics_0.DrawImage(base.ToggleSwitch.OnSideImage, rectangle, 0, 0, base.ToggleSwitch.OnSideImage.Width, base.ToggleSwitch.OnSideImage.Height, GraphicsUnit.Pixel, ImageHelper.GetGrayscaleAttributes());
                        }
                        else
                        {
                            graphics_0.DrawImageUnscaled(base.ToggleSwitch.OnSideImage, rectangle);
                        }
                    }
                }
                else if (!string.IsNullOrEmpty(base.ToggleSwitch.OnText))
                {
                    SizeF sizeF = graphics_0.MeasureString(base.ToggleSwitch.OnText, base.ToggleSwitch.OnFont);
                    float x2 = rect.X;
                    if (base.ToggleSwitch.OnSideAlignment == ToggleSwitch.ToggleSwitchAlignment.Center)
                    {
                        x2 = rect.X + (rect.Width - sizeF.Width) / 2f;
                    }
                    else if (base.ToggleSwitch.OnSideAlignment == ToggleSwitch.ToggleSwitchAlignment.Near)
                    {
                        x2 = rect.X + rect.Width - sizeF.Width;
                    }
                    RectangleF layoutRectangle = new RectangleF(x2, rect.Y + (rect.Height - sizeF.Height) / 2f, sizeF.Width, sizeF.Height);
                    Color color = base.ToggleSwitch.OnForeColor;
                    if (!base.ToggleSwitch.Enabled && base.ToggleSwitch.GrayWhenDisabled)
                    {
                        color = color.ToGrayScale();
                    }
                    using Brush brush = new SolidBrush(color);
                    graphics_0.DrawString(base.ToggleSwitch.OnText, base.ToggleSwitch.OnFont, brush, layoutRectangle);
                }
            }
            graphics_0.ResetClip();
        }

        public override void RenderRightToggleField(Graphics graphics_0, Rectangle rightRectangle, int totalToggleFieldWidth)
        {
            graphics_0.SmoothingMode = SmoothingMode.HighQuality;
            graphics_0.PixelOffsetMode = PixelOffsetMode.HighQuality;
            graphics_0.InterpolationMode = InterpolationMode.HighQualityBilinear;
            using GraphicsPath clip = this.GetRectangleClipPath(new Rectangle(1, 1, base.ToggleSwitch.Width - 1, base.ToggleSwitch.Height - 2));
            graphics_0.SetClip(clip);
            if (base.ToggleSwitch.OffSideImage != null || !string.IsNullOrEmpty(base.ToggleSwitch.OffText))
            {
                RectangleF rect = new RectangleF(rightRectangle.X, 2f, totalToggleFieldWidth - 2, base.ToggleSwitch.Height - 4);
                graphics_0.IntersectClip(rect);
                if (base.ToggleSwitch.OffSideImage != null)
                {
                    Size size = base.ToggleSwitch.OffSideImage.Size;
                    int x = (int)rect.X;
                    if (base.ToggleSwitch.OffSideScaleImageToFit)
                    {
                        Size size2 = ImageHelper.RescaleImageToFit(canvasSize: new Size((int)rect.Width, (int)rect.Height), imageSize: size);
                        if (base.ToggleSwitch.OffSideAlignment == ToggleSwitch.ToggleSwitchAlignment.Center)
                        {
                            x = (int)(rect.X + (rect.Width - (float)size2.Width) / 2f);
                        }
                        else if (base.ToggleSwitch.OffSideAlignment == ToggleSwitch.ToggleSwitchAlignment.Far)
                        {
                            x = (int)(rect.X + rect.Width - (float)size2.Width);
                        }
                        Rectangle rectangle = new Rectangle(x, (int)(rect.Y + (rect.Height - (float)size2.Height) / 2f), size2.Width, size2.Height);
                        if (!base.ToggleSwitch.Enabled && base.ToggleSwitch.GrayWhenDisabled)
                        {
                            graphics_0.DrawImage(base.ToggleSwitch.OnSideImage, rectangle, 0, 0, base.ToggleSwitch.OnSideImage.Width, base.ToggleSwitch.OnSideImage.Height, GraphicsUnit.Pixel, ImageHelper.GetGrayscaleAttributes());
                        }
                        else
                        {
                            graphics_0.DrawImage(base.ToggleSwitch.OnSideImage, rectangle);
                        }
                    }
                    else
                    {
                        if (base.ToggleSwitch.OffSideAlignment == ToggleSwitch.ToggleSwitchAlignment.Center)
                        {
                            x = (int)(rect.X + (rect.Width - (float)size.Width) / 2f);
                        }
                        else if (base.ToggleSwitch.OffSideAlignment == ToggleSwitch.ToggleSwitchAlignment.Far)
                        {
                            x = (int)(rect.X + rect.Width - (float)size.Width);
                        }
                        Rectangle rectangle = new Rectangle(x, (int)(rect.Y + (rect.Height - (float)size.Height) / 2f), size.Width, size.Height);
                        if (!base.ToggleSwitch.Enabled && base.ToggleSwitch.GrayWhenDisabled)
                        {
                            graphics_0.DrawImage(base.ToggleSwitch.OnSideImage, rectangle, 0, 0, base.ToggleSwitch.OnSideImage.Width, base.ToggleSwitch.OnSideImage.Height, GraphicsUnit.Pixel, ImageHelper.GetGrayscaleAttributes());
                        }
                        else
                        {
                            graphics_0.DrawImageUnscaled(base.ToggleSwitch.OffSideImage, rectangle);
                        }
                    }
                }
                else if (!string.IsNullOrEmpty(base.ToggleSwitch.OffText))
                {
                    SizeF sizeF = graphics_0.MeasureString(base.ToggleSwitch.OffText, base.ToggleSwitch.OffFont);
                    float x2 = rect.X;
                    if (base.ToggleSwitch.OffSideAlignment == ToggleSwitch.ToggleSwitchAlignment.Center)
                    {
                        x2 = rect.X + (rect.Width - sizeF.Width) / 2f;
                    }
                    else if (base.ToggleSwitch.OffSideAlignment == ToggleSwitch.ToggleSwitchAlignment.Far)
                    {
                        x2 = rect.X + rect.Width - sizeF.Width;
                    }
                    RectangleF layoutRectangle = new RectangleF(x2, rect.Y + (rect.Height - sizeF.Height) / 2f, sizeF.Width, sizeF.Height);
                    Color color = base.ToggleSwitch.OffForeColor;
                    if (!base.ToggleSwitch.Enabled && base.ToggleSwitch.GrayWhenDisabled)
                    {
                        color = color.ToGrayScale();
                    }
                    using Brush brush = new SolidBrush(color);
                    graphics_0.DrawString(base.ToggleSwitch.OffText, base.ToggleSwitch.OffFont, brush, layoutRectangle);
                }
            }
            graphics_0.ResetClip();
        }

        public override void RenderButton(Graphics graphics_0, Rectangle buttonRectangle)
        {
            graphics_0.SmoothingMode = SmoothingMode.HighQuality;
            graphics_0.PixelOffsetMode = PixelOffsetMode.HighQuality;
            graphics_0.InterpolationMode = InterpolationMode.HighQualityBilinear;
            graphics_0.SetClip(buttonRectangle);
            Color color = this.ButtonNormalSurfaceColor;
            if (base.ToggleSwitch.IsButtonPressed)
            {
                color = this.ButtonPressedSurfaceColor;
            }
            else if (base.ToggleSwitch.IsButtonHovered)
            {
                color = this.ButtonHoverSurfaceColor;
            }
            if (!base.ToggleSwitch.Enabled && base.ToggleSwitch.GrayWhenDisabled)
            {
                color = color.ToGrayScale();
            }
            using (Brush brush = new SolidBrush(color))
            {
                graphics_0.FillEllipse(brush, buttonRectangle);
            }
            using (PathGradientBrush brush2 = this.GetBrush(centerPoint: new PointF((float)buttonRectangle.X + (float)buttonRectangle.Width / 2f, (float)buttonRectangle.Y + 1.2f * ((float)buttonRectangle.Height / 2f)), Colors: new Color[13]
                   {
                       Color.Transparent,
                       Color.Transparent,
                       Color.Transparent,
                       Color.Transparent,
                       Color.Transparent,
                       Color.Transparent,
                       Color.Transparent,
                       Color.Transparent,
                       Color.Transparent,
                       Color.FromArgb(255, 110, 110, 110),
                       Color.Transparent,
                       Color.Transparent,
                       Color.Transparent
                   }, rectangleF_0: buttonRectangle))
            {
                graphics_0.FillEllipse(brush2, buttonRectangle);
            }
            using (PathGradientBrush brush3 = this.GetBrush(centerPoint: new PointF((float)buttonRectangle.X + 0.8f * ((float)buttonRectangle.Width / 2f), (float)buttonRectangle.Y + (float)buttonRectangle.Height / 2f), Colors: new Color[9]
                   {
                       Color.FromArgb(255, 110, 110, 110),
                       Color.Transparent,
                       Color.Transparent,
                       Color.Transparent,
                       Color.Transparent,
                       Color.Transparent,
                       Color.Transparent,
                       Color.Transparent,
                       Color.FromArgb(255, 110, 110, 110)
                   }, rectangleF_0: buttonRectangle))
            {
                graphics_0.FillEllipse(brush3, buttonRectangle);
            }
            using (PathGradientBrush brush4 = this.GetBrush(centerPoint: new PointF((float)buttonRectangle.X + 1.2f * ((float)buttonRectangle.Width / 2f), (float)buttonRectangle.Y + (float)buttonRectangle.Height / 2f), Colors: new Color[9]
                   {
                       Color.Transparent,
                       Color.Transparent,
                       Color.Transparent,
                       Color.Transparent,
                       Color.FromArgb(255, 98, 98, 98),
                       Color.Transparent,
                       Color.Transparent,
                       Color.Transparent,
                       Color.Transparent
                   }, rectangleF_0: buttonRectangle))
            {
                graphics_0.FillEllipse(brush4, buttonRectangle);
            }
            using (PathGradientBrush brush5 = this.GetBrush(centerPoint: new PointF((float)buttonRectangle.X + 0.9f * ((float)buttonRectangle.Width / 2f), (float)buttonRectangle.Y + 0.9f * ((float)buttonRectangle.Height / 2f)), Colors: new Color[13]
                   {
                       Color.Transparent,
                       Color.FromArgb(255, 188, 188, 188),
                       Color.FromArgb(255, 110, 110, 110),
                       Color.Transparent,
                       Color.Transparent,
                       Color.Transparent,
                       Color.Transparent,
                       Color.Transparent,
                       Color.Transparent,
                       Color.Transparent,
                       Color.Transparent,
                       Color.Transparent,
                       Color.Transparent
                   }, rectangleF_0: buttonRectangle))
            {
                graphics_0.FillEllipse(brush5, buttonRectangle);
            }
            Color color2 = this.ButtonNormalBorderColor;
            if (base.ToggleSwitch.IsButtonPressed)
            {
                color2 = this.ButtonPressedBorderColor;
            }
            else if (base.ToggleSwitch.IsButtonHovered)
            {
                color2 = this.ButtonHoverBorderColor;
            }
            if (!base.ToggleSwitch.Enabled && base.ToggleSwitch.GrayWhenDisabled)
            {
                color2 = color2.ToGrayScale();
            }
            using (Pen pen = new Pen(color2))
            {
                graphics_0.DrawEllipse(pen, buttonRectangle);
            }
            graphics_0.ResetClip();
        }

        public GraphicsPath GetRectangleClipPath(Rectangle rect)
        {
            GraphicsPath graphicsPath = new GraphicsPath();
            graphicsPath.AddArc(rect.X, rect.Y, rect.Height, rect.Height, 90f, 180f);
            graphicsPath.AddArc(rect.Width - rect.Height, rect.Y, rect.Height, rect.Height, 270f, 180f);
            graphicsPath.CloseFigure();
            return graphicsPath;
        }

        public GraphicsPath GetButtonClipPath()
        {
            Rectangle buttonRectangle = this.GetButtonRectangle();
            GraphicsPath graphicsPath = new GraphicsPath();
            graphicsPath.AddArc(buttonRectangle.X, buttonRectangle.Y, buttonRectangle.Height, buttonRectangle.Height, 0f, 360f);
            return graphicsPath;
        }

        public override int GetButtonWidth()
        {
            return base.ToggleSwitch.Height - 2;
        }

        public override Rectangle GetButtonRectangle()
        {
            return this.GetButtonRectangle(this.GetButtonWidth());
        }

        public override Rectangle GetButtonRectangle(int buttonWidth)
        {
            return new Rectangle(base.ToggleSwitch.ButtonValue, 1, buttonWidth, buttonWidth);
        }

        private PathGradientBrush GetBrush(Color[] Colors, RectangleF rectangleF_0, PointF centerPoint)
        {
            int num = Colors.Length - 1;
            PointF[] array = new PointF[num + 1];
            float num2 = 0f;
            int num3 = 0;
            float num4 = rectangleF_0.Width / 2f;
            float num5 = rectangleF_0.Height / 2f;
            double num6 = 1.0 / Math.Sin((double)(int)Math.Floor(180.0 * ((double)num - 2.0) / (double)num / 2.0) * Math.PI / 180.0);
            float num7 = (float)((double)num4 * num6);
            float num8 = (float)((double)num5 * num6);
            for (; (double)num2 <= Math.PI * 2.0; num2 += (float)(Math.PI * 2.0 / (double)num))
            {
                array[num3] = new PointF((float)((double)num4 + Math.Cos(num2) * (double)num7) + rectangleF_0.Left, (float)((double)num5 + Math.Sin(num2) * (double)num8) + rectangleF_0.Top);
                num3++;
            }
            array[num] = array[0];
            GraphicsPath graphicsPath = new GraphicsPath();
            graphicsPath.AddLines(array);
            PathGradientBrush pathGradientBrush = new PathGradientBrush(graphicsPath);
            pathGradientBrush.CenterPoint = centerPoint;
            pathGradientBrush.CenterColor = Color.Transparent;
            pathGradientBrush.SurroundColors = new Color[1] { Color.White };
            try
            {
                pathGradientBrush.SurroundColors = Colors;
                return pathGradientBrush;
            }
            catch (Exception innerException)
            {
                throw new Exception("Too may colors!", innerException);
            }
        }
    }
}
