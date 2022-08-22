using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using ICARUS.ToggleSwitch;

namespace ICARUS.JCS
{
    public class ToggleSwitchModernRenderer : ToggleSwitchRendererBase, IDisposable
    {
        private GraphicsPath _innerControlPath;

        public Color OuterBorderColor { get; set; }

        public Color InnerBorderColor1 { get; set; }

        public Color InnerBorderColor2 { get; set; }

        public Color LeftSideBackColor1 { get; set; }

        public Color LeftSideBackColor2 { get; set; }

        public Color RightSideBackColor1 { get; set; }

        public Color RightSideBackColor2 { get; set; }

        public Color ButtonNormalBorderColor1 { get; set; }

        public Color ButtonNormalBorderColor2 { get; set; }

        public Color ButtonNormalSurfaceColor1 { get; set; }

        public Color ButtonNormalSurfaceColor2 { get; set; }

        public Color ArrowNormalColor { get; set; }

        public Color ButtonHoverBorderColor1 { get; set; }

        public Color ButtonHoverBorderColor2 { get; set; }

        public Color ButtonHoverSurfaceColor1 { get; set; }

        public Color ButtonHoverSurfaceColor2 { get; set; }

        public Color ArrowHoverColor { get; set; }

        public Color ButtonPressedBorderColor1 { get; set; }

        public Color ButtonPressedBorderColor2 { get; set; }

        public Color ButtonPressedSurfaceColor1 { get; set; }

        public Color ButtonPressedSurfaceColor2 { get; set; }

        public Color ArrowPressedColor { get; set; }

        public Color ButtonShadowColor1 { get; set; }

        public Color ButtonShadowColor2 { get; set; }

        public int ButtonShadowWidth { get; set; }

        public int CornerRadius { get; set; }

        public int ButtonCornerRadius { get; set; }

        public ToggleSwitchModernRenderer()
        {
            this.OuterBorderColor = Color.FromArgb(255, 31, 31, 31);
            this.InnerBorderColor1 = Color.FromArgb(255, 80, 80, 82);
            this.InnerBorderColor2 = Color.FromArgb(255, 109, 110, 112);
            this.LeftSideBackColor1 = Color.FromArgb(255, 57, 166, 222);
            this.LeftSideBackColor2 = Color.FromArgb(255, 53, 155, 229);
            this.RightSideBackColor1 = Color.FromArgb(255, 48, 49, 45);
            this.RightSideBackColor2 = Color.FromArgb(255, 51, 52, 48);
            this.ButtonNormalBorderColor1 = Color.FromArgb(255, 31, 31, 31);
            this.ButtonNormalBorderColor2 = Color.FromArgb(255, 31, 31, 31);
            this.ButtonNormalSurfaceColor1 = Color.FromArgb(255, 51, 52, 48);
            this.ButtonNormalSurfaceColor2 = Color.FromArgb(255, 51, 52, 48);
            this.ArrowNormalColor = Color.FromArgb(255, 53, 156, 230);
            this.ButtonHoverBorderColor1 = Color.FromArgb(255, 29, 29, 29);
            this.ButtonHoverBorderColor2 = Color.FromArgb(255, 29, 29, 29);
            this.ButtonHoverSurfaceColor1 = Color.FromArgb(255, 48, 49, 45);
            this.ButtonHoverSurfaceColor2 = Color.FromArgb(255, 48, 49, 45);
            this.ArrowHoverColor = Color.FromArgb(255, 50, 148, 219);
            this.ButtonPressedBorderColor1 = Color.FromArgb(255, 23, 23, 23);
            this.ButtonPressedBorderColor2 = Color.FromArgb(255, 23, 23, 23);
            this.ButtonPressedSurfaceColor1 = Color.FromArgb(255, 38, 39, 36);
            this.ButtonPressedSurfaceColor2 = Color.FromArgb(255, 38, 39, 36);
            this.ArrowPressedColor = Color.FromArgb(255, 39, 117, 172);
            this.ButtonShadowColor1 = Color.FromArgb(50, 0, 0, 0);
            this.ButtonShadowColor2 = Color.FromArgb(0, 0, 0, 0);
            this.ButtonShadowWidth = 7;
            this.CornerRadius = 6;
            this.ButtonCornerRadius = 6;
        }

        public void Dispose()
        {
            if (this._innerControlPath != null)
            {
                this._innerControlPath.Dispose();
            }
        }

        public override void RenderBorder(Graphics graphics_0, Rectangle borderRectangle)
        {
            graphics_0.SmoothingMode = SmoothingMode.HighQuality;
            graphics_0.PixelOffsetMode = PixelOffsetMode.HighQuality;
            graphics_0.InterpolationMode = InterpolationMode.HighQualityBilinear;
            using (GraphicsPath graphicsPath = this.GetRoundedRectanglePath(borderRectangle, this.CornerRadius))
            {
                graphics_0.SetClip(graphicsPath);
                using (Brush brush = new SolidBrush((base.ToggleSwitch.Enabled || !base.ToggleSwitch.GrayWhenDisabled) ? this.OuterBorderColor : this.OuterBorderColor.ToGrayScale()))
                {
                    graphics_0.FillPath(brush, graphicsPath);
                }
                graphics_0.ResetClip();
            }
            using (GraphicsPath graphicsPath2 = this.GetRoundedRectanglePath(new Rectangle(borderRectangle.X + 1, borderRectangle.Y + 1, borderRectangle.Width - 2, borderRectangle.Height - 2), this.CornerRadius))
            {
                graphics_0.SetClip(graphicsPath2);
                using (Brush brush2 = new LinearGradientBrush(color1: (base.ToggleSwitch.Enabled || !base.ToggleSwitch.GrayWhenDisabled) ? this.InnerBorderColor1 : this.InnerBorderColor1.ToGrayScale(), color2: (base.ToggleSwitch.Enabled || !base.ToggleSwitch.GrayWhenDisabled) ? this.InnerBorderColor2 : this.InnerBorderColor2.ToGrayScale(), rect: borderRectangle, linearGradientMode: LinearGradientMode.Vertical))
                {
                    graphics_0.FillPath(brush2, graphicsPath2);
                }
                graphics_0.ResetClip();
            }
            this._innerControlPath = this.GetRoundedRectanglePath(new Rectangle(borderRectangle.X + 2, borderRectangle.Y + 2, borderRectangle.Width - 4, borderRectangle.Height - 4), this.CornerRadius);
        }

        public override void RenderLeftToggleField(Graphics graphics_0, Rectangle leftRectangle, int totalToggleFieldWidth)
        {
            graphics_0.SmoothingMode = SmoothingMode.HighQuality;
            graphics_0.PixelOffsetMode = PixelOffsetMode.HighQuality;
            graphics_0.InterpolationMode = InterpolationMode.HighQualityBilinear;
            int buttonWidth = this.GetButtonWidth();
            Rectangle rectangle = new Rectangle(width: leftRectangle.Width + buttonWidth / 2, x: leftRectangle.X, y: leftRectangle.Y, height: leftRectangle.Height);
            Color color = ((base.ToggleSwitch.Enabled || !base.ToggleSwitch.GrayWhenDisabled) ? this.LeftSideBackColor1 : this.LeftSideBackColor1.ToGrayScale());
            Color color2 = ((base.ToggleSwitch.Enabled || !base.ToggleSwitch.GrayWhenDisabled) ? this.LeftSideBackColor2 : this.LeftSideBackColor2.ToGrayScale());
            if (this._innerControlPath != null)
            {
                graphics_0.SetClip(this._innerControlPath);
                graphics_0.IntersectClip(rectangle);
            }
            else
            {
                graphics_0.SetClip(rectangle);
            }
            using (Brush brush = new LinearGradientBrush(rectangle, color, color2, LinearGradientMode.Vertical))
            {
                graphics_0.FillRectangle(brush, rectangle);
            }
            graphics_0.ResetClip();
            Rectangle rectangle2 = default(Rectangle);
            rectangle2.X = leftRectangle.X + leftRectangle.Width - this.ButtonShadowWidth;
            rectangle2.Y = leftRectangle.Y;
            rectangle2.Width = this.ButtonShadowWidth + this.CornerRadius;
            rectangle2.Height = leftRectangle.Height;
            if (this._innerControlPath != null)
            {
                graphics_0.SetClip(this._innerControlPath);
                graphics_0.IntersectClip(rectangle2);
            }
            else
            {
                graphics_0.SetClip(rectangle2);
            }
            using (Brush brush2 = new LinearGradientBrush(rectangle2, this.ButtonShadowColor2, this.ButtonShadowColor1, LinearGradientMode.Horizontal))
            {
                graphics_0.FillRectangle(brush2, rectangle2);
            }
            graphics_0.ResetClip();
            if (base.ToggleSwitch.OnSideImage == null && string.IsNullOrEmpty(base.ToggleSwitch.OnText))
            {
                return;
            }
            RectangleF rectangleF = new RectangleF(leftRectangle.X + 1 - (totalToggleFieldWidth - leftRectangle.Width), 1f, totalToggleFieldWidth - 1, base.ToggleSwitch.Height - 2);
            if (this._innerControlPath != null)
            {
                graphics_0.SetClip(this._innerControlPath);
                graphics_0.IntersectClip(rectangleF);
            }
            else
            {
                graphics_0.SetClip(rectangleF);
            }
            if (base.ToggleSwitch.OnSideImage != null)
            {
                Size size = base.ToggleSwitch.OnSideImage.Size;
                int x = (int)rectangleF.X;
                if (base.ToggleSwitch.OnSideScaleImageToFit)
                {
                    Size size2 = ImageHelper.RescaleImageToFit(canvasSize: new Size((int)rectangleF.Width, (int)rectangleF.Height), imageSize: size);
                    if (base.ToggleSwitch.OnSideAlignment == ToggleSwitch.ToggleSwitchAlignment.Center)
                    {
                        x = (int)(rectangleF.X + (rectangleF.Width - (float)size2.Width) / 2f);
                    }
                    else if (base.ToggleSwitch.OnSideAlignment == ToggleSwitch.ToggleSwitchAlignment.Near)
                    {
                        x = (int)(rectangleF.X + rectangleF.Width - (float)size2.Width);
                    }
                    Rectangle rectangle3 = new Rectangle(x, (int)(rectangleF.Y + (rectangleF.Height - (float)size2.Height) / 2f), size2.Width, size2.Height);
                    if (!base.ToggleSwitch.Enabled && base.ToggleSwitch.GrayWhenDisabled)
                    {
                        graphics_0.DrawImage(base.ToggleSwitch.OnSideImage, rectangle3, 0, 0, base.ToggleSwitch.OnSideImage.Width, base.ToggleSwitch.OnSideImage.Height, GraphicsUnit.Pixel, ImageHelper.GetGrayscaleAttributes());
                    }
                    else
                    {
                        graphics_0.DrawImage(base.ToggleSwitch.OnSideImage, rectangle3);
                    }
                }
                else
                {
                    if (base.ToggleSwitch.OnSideAlignment == ToggleSwitch.ToggleSwitchAlignment.Center)
                    {
                        x = (int)(rectangleF.X + (rectangleF.Width - (float)size.Width) / 2f);
                    }
                    else if (base.ToggleSwitch.OnSideAlignment == ToggleSwitch.ToggleSwitchAlignment.Near)
                    {
                        x = (int)(rectangleF.X + rectangleF.Width - (float)size.Width);
                    }
                    Rectangle rectangle3 = new Rectangle(x, (int)(rectangleF.Y + (rectangleF.Height - (float)size.Height) / 2f), size.Width, size.Height);
                    if (!base.ToggleSwitch.Enabled && base.ToggleSwitch.GrayWhenDisabled)
                    {
                        graphics_0.DrawImage(base.ToggleSwitch.OnSideImage, rectangle3, 0, 0, base.ToggleSwitch.OnSideImage.Width, base.ToggleSwitch.OnSideImage.Height, GraphicsUnit.Pixel, ImageHelper.GetGrayscaleAttributes());
                    }
                    else
                    {
                        graphics_0.DrawImageUnscaled(base.ToggleSwitch.OnSideImage, rectangle3);
                    }
                }
            }
            else if (!string.IsNullOrEmpty(base.ToggleSwitch.OnText))
            {
                SizeF sizeF = graphics_0.MeasureString(base.ToggleSwitch.OnText, base.ToggleSwitch.OnFont);
                float x2 = rectangleF.X;
                if (base.ToggleSwitch.OnSideAlignment == ToggleSwitch.ToggleSwitchAlignment.Center)
                {
                    x2 = rectangleF.X + (rectangleF.Width - sizeF.Width) / 2f;
                }
                else if (base.ToggleSwitch.OnSideAlignment == ToggleSwitch.ToggleSwitchAlignment.Near)
                {
                    x2 = rectangleF.X + rectangleF.Width - sizeF.Width;
                }
                RectangleF layoutRectangle = new RectangleF(x2, rectangleF.Y + (rectangleF.Height - sizeF.Height) / 2f, sizeF.Width, sizeF.Height);
                Color color3 = base.ToggleSwitch.OnForeColor;
                if (!base.ToggleSwitch.Enabled && base.ToggleSwitch.GrayWhenDisabled)
                {
                    color3 = color3.ToGrayScale();
                }
                using Brush brush3 = new SolidBrush(color3);
                graphics_0.DrawString(base.ToggleSwitch.OnText, base.ToggleSwitch.OnFont, brush3, layoutRectangle);
            }
            graphics_0.ResetClip();
        }

        public override void RenderRightToggleField(Graphics graphics_0, Rectangle rightRectangle, int totalToggleFieldWidth)
        {
            graphics_0.SmoothingMode = SmoothingMode.HighQuality;
            graphics_0.PixelOffsetMode = PixelOffsetMode.HighQuality;
            graphics_0.InterpolationMode = InterpolationMode.HighQualityBilinear;
            int buttonWidth = this.GetButtonWidth();
            Rectangle rectangle = new Rectangle(width: rightRectangle.Width + buttonWidth / 2, x: rightRectangle.X - buttonWidth / 2, y: rightRectangle.Y, height: rightRectangle.Height);
            Color color = ((base.ToggleSwitch.Enabled || !base.ToggleSwitch.GrayWhenDisabled) ? this.RightSideBackColor1 : this.RightSideBackColor1.ToGrayScale());
            Color color2 = ((base.ToggleSwitch.Enabled || !base.ToggleSwitch.GrayWhenDisabled) ? this.RightSideBackColor2 : this.RightSideBackColor2.ToGrayScale());
            if (this._innerControlPath != null)
            {
                graphics_0.SetClip(this._innerControlPath);
                graphics_0.IntersectClip(rectangle);
            }
            else
            {
                graphics_0.SetClip(rectangle);
            }
            using (Brush brush = new LinearGradientBrush(rectangle, color, color2, LinearGradientMode.Vertical))
            {
                graphics_0.FillRectangle(brush, rectangle);
            }
            graphics_0.ResetClip();
            Rectangle rectangle2 = default(Rectangle);
            rectangle2.X = rightRectangle.X - this.CornerRadius;
            rectangle2.Y = rightRectangle.Y;
            rectangle2.Width = this.ButtonShadowWidth + this.CornerRadius;
            rectangle2.Height = rightRectangle.Height;
            if (this._innerControlPath != null)
            {
                graphics_0.SetClip(this._innerControlPath);
                graphics_0.IntersectClip(rectangle2);
            }
            else
            {
                graphics_0.SetClip(rectangle2);
            }
            using (Brush brush2 = new LinearGradientBrush(rectangle2, this.ButtonShadowColor1, this.ButtonShadowColor2, LinearGradientMode.Horizontal))
            {
                graphics_0.FillRectangle(brush2, rectangle2);
            }
            graphics_0.ResetClip();
            if (base.ToggleSwitch.OffSideImage == null && string.IsNullOrEmpty(base.ToggleSwitch.OffText))
            {
                return;
            }
            RectangleF rectangleF = new RectangleF(rightRectangle.X, 1f, totalToggleFieldWidth - 1, base.ToggleSwitch.Height - 2);
            if (this._innerControlPath != null)
            {
                graphics_0.SetClip(this._innerControlPath);
                graphics_0.IntersectClip(rectangleF);
            }
            else
            {
                graphics_0.SetClip(rectangleF);
            }
            if (base.ToggleSwitch.OffSideImage != null)
            {
                Size size = base.ToggleSwitch.OffSideImage.Size;
                int x = (int)rectangleF.X;
                if (base.ToggleSwitch.OffSideScaleImageToFit)
                {
                    Size size2 = ImageHelper.RescaleImageToFit(canvasSize: new Size((int)rectangleF.Width, (int)rectangleF.Height), imageSize: size);
                    if (base.ToggleSwitch.OffSideAlignment == ToggleSwitch.ToggleSwitchAlignment.Center)
                    {
                        x = (int)(rectangleF.X + (rectangleF.Width - (float)size2.Width) / 2f);
                    }
                    else if (base.ToggleSwitch.OffSideAlignment == ToggleSwitch.ToggleSwitchAlignment.Far)
                    {
                        x = (int)(rectangleF.X + rectangleF.Width - (float)size2.Width);
                    }
                    Rectangle rectangle3 = new Rectangle(x, (int)(rectangleF.Y + (rectangleF.Height - (float)size2.Height) / 2f), size2.Width, size2.Height);
                    if (!base.ToggleSwitch.Enabled && base.ToggleSwitch.GrayWhenDisabled)
                    {
                        graphics_0.DrawImage(base.ToggleSwitch.OnSideImage, rectangle3, 0, 0, base.ToggleSwitch.OnSideImage.Width, base.ToggleSwitch.OnSideImage.Height, GraphicsUnit.Pixel, ImageHelper.GetGrayscaleAttributes());
                    }
                    else
                    {
                        graphics_0.DrawImage(base.ToggleSwitch.OnSideImage, rectangle3);
                    }
                }
                else
                {
                    if (base.ToggleSwitch.OffSideAlignment == ToggleSwitch.ToggleSwitchAlignment.Center)
                    {
                        x = (int)(rectangleF.X + (rectangleF.Width - (float)size.Width) / 2f);
                    }
                    else if (base.ToggleSwitch.OffSideAlignment == ToggleSwitch.ToggleSwitchAlignment.Far)
                    {
                        x = (int)(rectangleF.X + rectangleF.Width - (float)size.Width);
                    }
                    Rectangle rectangle3 = new Rectangle(x, (int)(rectangleF.Y + (rectangleF.Height - (float)size.Height) / 2f), size.Width, size.Height);
                    if (!base.ToggleSwitch.Enabled && base.ToggleSwitch.GrayWhenDisabled)
                    {
                        graphics_0.DrawImage(base.ToggleSwitch.OnSideImage, rectangle3, 0, 0, base.ToggleSwitch.OnSideImage.Width, base.ToggleSwitch.OnSideImage.Height, GraphicsUnit.Pixel, ImageHelper.GetGrayscaleAttributes());
                    }
                    else
                    {
                        graphics_0.DrawImageUnscaled(base.ToggleSwitch.OffSideImage, rectangle3);
                    }
                }
            }
            else if (!string.IsNullOrEmpty(base.ToggleSwitch.OffText))
            {
                SizeF sizeF = graphics_0.MeasureString(base.ToggleSwitch.OffText, base.ToggleSwitch.OffFont);
                float x2 = rectangleF.X;
                if (base.ToggleSwitch.OffSideAlignment == ToggleSwitch.ToggleSwitchAlignment.Center)
                {
                    x2 = rectangleF.X + (rectangleF.Width - sizeF.Width) / 2f;
                }
                else if (base.ToggleSwitch.OffSideAlignment == ToggleSwitch.ToggleSwitchAlignment.Far)
                {
                    x2 = rectangleF.X + rectangleF.Width - sizeF.Width;
                }
                RectangleF layoutRectangle = new RectangleF(x2, rectangleF.Y + (rectangleF.Height - sizeF.Height) / 2f, sizeF.Width, sizeF.Height);
                Color color3 = base.ToggleSwitch.OffForeColor;
                if (!base.ToggleSwitch.Enabled && base.ToggleSwitch.GrayWhenDisabled)
                {
                    color3 = color3.ToGrayScale();
                }
                using Brush brush3 = new SolidBrush(color3);
                graphics_0.DrawString(base.ToggleSwitch.OffText, base.ToggleSwitch.OffFont, brush3, layoutRectangle);
            }
            graphics_0.ResetClip();
        }

        public override void RenderButton(Graphics graphics_0, Rectangle buttonRectangle)
        {
            graphics_0.SmoothingMode = SmoothingMode.HighQuality;
            graphics_0.PixelOffsetMode = PixelOffsetMode.HighQuality;
            graphics_0.InterpolationMode = InterpolationMode.HighQualityBilinear;
            if (this._innerControlPath != null)
            {
                graphics_0.SetClip(this._innerControlPath);
                graphics_0.IntersectClip(buttonRectangle);
            }
            else
            {
                graphics_0.SetClip(buttonRectangle);
            }
            using (GraphicsPath path = this.GetRoundedRectanglePath(buttonRectangle, this.ButtonCornerRadius))
            {
                Color color = this.ButtonNormalSurfaceColor1;
                Color color2 = this.ButtonNormalSurfaceColor2;
                if (base.ToggleSwitch.IsButtonPressed)
                {
                    color = this.ButtonPressedSurfaceColor1;
                    color2 = this.ButtonPressedSurfaceColor2;
                }
                else if (base.ToggleSwitch.IsButtonHovered)
                {
                    color = this.ButtonHoverSurfaceColor1;
                    color2 = this.ButtonHoverSurfaceColor2;
                }
                if (!base.ToggleSwitch.Enabled && base.ToggleSwitch.GrayWhenDisabled)
                {
                    color = color.ToGrayScale();
                    color2 = color2.ToGrayScale();
                }
                using (Brush brush = new LinearGradientBrush(buttonRectangle, color, color2, LinearGradientMode.Vertical))
                {
                    graphics_0.FillPath(brush, path);
                }
                Color color3 = this.ButtonNormalBorderColor1;
                Color color4 = this.ButtonNormalBorderColor2;
                if (base.ToggleSwitch.IsButtonPressed)
                {
                    color3 = this.ButtonPressedBorderColor1;
                    color4 = this.ButtonPressedBorderColor2;
                }
                else if (base.ToggleSwitch.IsButtonHovered)
                {
                    color3 = this.ButtonHoverBorderColor1;
                    color4 = this.ButtonHoverBorderColor2;
                }
                if (!base.ToggleSwitch.Enabled && base.ToggleSwitch.GrayWhenDisabled)
                {
                    color3 = color3.ToGrayScale();
                    color4 = color4.ToGrayScale();
                }
                using Brush brush2 = new LinearGradientBrush(buttonRectangle, color3, color4, LinearGradientMode.Vertical);
                using Pen pen = new Pen(brush2);
                graphics_0.DrawPath(pen, path);
            }
            graphics_0.ResetClip();
            Color color5 = this.ArrowNormalColor;
            if (base.ToggleSwitch.IsButtonPressed)
            {
                color5 = this.ArrowPressedColor;
            }
            else if (base.ToggleSwitch.IsButtonHovered)
            {
                color5 = this.ArrowHoverColor;
            }
            if (!base.ToggleSwitch.Enabled && base.ToggleSwitch.GrayWhenDisabled)
            {
                color5 = color5.ToGrayScale();
            }
            Rectangle arrowRectangle = default(Rectangle);
            arrowRectangle.Height = 9;
            arrowRectangle.Width = 22;
            arrowRectangle.X = buttonRectangle.X + (int)(((double)buttonRectangle.Width - (double)arrowRectangle.Width) / 2.0);
            arrowRectangle.Y = buttonRectangle.Y + (int)(((double)buttonRectangle.Height - (double)arrowRectangle.Height) / 2.0);
            using Brush brush3 = new SolidBrush(color5);
            using (GraphicsPath path2 = this.GetArrowLeftPath(arrowRectangle))
            {
                graphics_0.FillPath(brush3, path2);
            }
            using GraphicsPath path3 = this.GetArrowRightPath(arrowRectangle);
            graphics_0.FillPath(brush3, path3);
        }

        public GraphicsPath GetRoundedRectanglePath(Rectangle rectangle, int radius)
        {
            GraphicsPath graphicsPath = new GraphicsPath();
            int num = 2 * radius;
            if (num > base.ToggleSwitch.Height)
            {
                num = base.ToggleSwitch.Height;
            }
            if (num > base.ToggleSwitch.Width)
            {
                num = base.ToggleSwitch.Width;
            }
            graphicsPath.AddArc(rectangle.X, rectangle.Y, num, num, 180f, 90f);
            graphicsPath.AddArc(rectangle.X + rectangle.Width - num, rectangle.Y, num, num, 270f, 90f);
            graphicsPath.AddArc(rectangle.X + rectangle.Width - num, rectangle.Y + rectangle.Height - num, num, num, 0f, 90f);
            graphicsPath.AddArc(rectangle.X, rectangle.Y + rectangle.Height - num, num, num, 90f, 90f);
            graphicsPath.CloseFigure();
            return graphicsPath;
        }

        public GraphicsPath GetArrowLeftPath(Rectangle arrowRectangle)
        {
            GraphicsPath graphicsPath = new GraphicsPath();
            Point point = new Point(arrowRectangle.X + 8, arrowRectangle.Y);
            Point point2 = new Point(arrowRectangle.X + 8, arrowRectangle.Y + arrowRectangle.Height);
            Point point3 = new Point(arrowRectangle.X, arrowRectangle.Y + arrowRectangle.Height / 2);
            graphicsPath.AddLine(point, point2);
            graphicsPath.AddLine(point2, point3);
            graphicsPath.AddLine(point3, point);
            return graphicsPath;
        }

        public GraphicsPath GetArrowRightPath(Rectangle arrowRectangle)
        {
            GraphicsPath graphicsPath = new GraphicsPath();
            Point point = new Point(arrowRectangle.X + 14, arrowRectangle.Y);
            Point point2 = new Point(arrowRectangle.X + 14, arrowRectangle.Y + arrowRectangle.Height);
            Point point3 = new Point(arrowRectangle.X + arrowRectangle.Width, arrowRectangle.Y + arrowRectangle.Height / 2);
            graphicsPath.AddLine(point, point2);
            graphicsPath.AddLine(point2, point3);
            graphicsPath.AddLine(point3, point);
            return graphicsPath;
        }

        public override int GetButtonWidth()
        {
            return (int)(1.41f * (float)base.ToggleSwitch.Height);
        }

        public override Rectangle GetButtonRectangle()
        {
            return this.GetButtonRectangle(this.GetButtonWidth());
        }

        public override Rectangle GetButtonRectangle(int buttonWidth)
        {
            return new Rectangle(base.ToggleSwitch.ButtonValue, 0, buttonWidth, base.ToggleSwitch.Height);
        }
    }
}
