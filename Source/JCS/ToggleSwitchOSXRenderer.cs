using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using ICARUS.ToggleSwitch;

namespace ICARUS.JCS
{
    public class ToggleSwitchOSXRenderer : ToggleSwitchRendererBase, IDisposable
    {
        private GraphicsPath _innerControlPath;

        public Color OuterBorderColor { get; set; }

        public Color InnerBorderColor1 { get; set; }

        public Color InnerBorderColor2 { get; set; }

        public Color BackColor1 { get; set; }

        public Color BackColor2 { get; set; }

        public Color ButtonNormalBorderColor1 { get; set; }

        public Color ButtonNormalBorderColor2 { get; set; }

        public Color ButtonNormalSurfaceColor1 { get; set; }

        public Color ButtonNormalSurfaceColor2 { get; set; }

        public Color ButtonHoverBorderColor1 { get; set; }

        public Color ButtonHoverBorderColor2 { get; set; }

        public Color ButtonHoverSurfaceColor1 { get; set; }

        public Color ButtonHoverSurfaceColor2 { get; set; }

        public Color ButtonPressedBorderColor1 { get; set; }

        public Color ButtonPressedBorderColor2 { get; set; }

        public Color ButtonPressedSurfaceColor1 { get; set; }

        public Color ButtonPressedSurfaceColor2 { get; set; }

        public Color ButtonShadowColor1 { get; set; }

        public Color ButtonShadowColor2 { get; set; }

        public int ButtonShadowWidth { get; set; }

        public int CornerRadius { get; set; }

        public ToggleSwitchOSXRenderer()
        {
            this.OuterBorderColor = Color.FromArgb(255, 108, 108, 108);
            this.InnerBorderColor1 = Color.FromArgb(255, 137, 138, 139);
            this.InnerBorderColor2 = Color.FromArgb(255, 167, 168, 169);
            this.BackColor1 = Color.FromArgb(255, 108, 108, 108);
            this.BackColor2 = Color.FromArgb(255, 163, 163, 163);
            this.ButtonNormalBorderColor1 = Color.FromArgb(255, 147, 147, 148);
            this.ButtonNormalBorderColor2 = Color.FromArgb(255, 167, 168, 169);
            this.ButtonNormalSurfaceColor1 = Color.FromArgb(255, 250, 250, 250);
            this.ButtonNormalSurfaceColor2 = Color.FromArgb(255, 224, 224, 224);
            this.ButtonHoverBorderColor1 = Color.FromArgb(255, 145, 146, 147);
            this.ButtonHoverBorderColor2 = Color.FromArgb(255, 164, 165, 166);
            this.ButtonHoverSurfaceColor1 = Color.FromArgb(255, 238, 238, 238);
            this.ButtonHoverSurfaceColor2 = Color.FromArgb(255, 213, 213, 213);
            this.ButtonPressedBorderColor1 = Color.FromArgb(255, 138, 138, 140);
            this.ButtonPressedBorderColor2 = Color.FromArgb(255, 158, 158, 160);
            this.ButtonPressedSurfaceColor1 = Color.FromArgb(255, 187, 187, 187);
            this.ButtonPressedSurfaceColor2 = Color.FromArgb(255, 168, 168, 168);
            this.ButtonShadowColor1 = Color.FromArgb(50, 0, 0, 0);
            this.ButtonShadowColor2 = Color.FromArgb(0, 0, 0, 0);
            this.ButtonShadowWidth = 7;
            this.CornerRadius = 4;
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
            graphics_0.SetClip(this._innerControlPath);
            using (Brush brush3 = new LinearGradientBrush(color1: (base.ToggleSwitch.Enabled || !base.ToggleSwitch.GrayWhenDisabled) ? this.BackColor1 : this.BackColor1.ToGrayScale(), color2: (base.ToggleSwitch.Enabled || !base.ToggleSwitch.GrayWhenDisabled) ? this.BackColor2 : this.BackColor2.ToGrayScale(), rect: borderRectangle, linearGradientMode: LinearGradientMode.Vertical))
            {
                graphics_0.FillPath(brush3, this._innerControlPath);
            }
            graphics_0.ResetClip();
        }

        public override void RenderLeftToggleField(Graphics graphics_0, Rectangle leftRectangle, int totalToggleFieldWidth)
        {
            graphics_0.SmoothingMode = SmoothingMode.HighQuality;
            graphics_0.PixelOffsetMode = PixelOffsetMode.HighQuality;
            graphics_0.InterpolationMode = InterpolationMode.HighQualityBilinear;
            Rectangle rectangle = default(Rectangle);
            rectangle.X = leftRectangle.X + leftRectangle.Width - this.ButtonShadowWidth;
            rectangle.Y = leftRectangle.Y;
            rectangle.Width = this.ButtonShadowWidth + this.CornerRadius;
            rectangle.Height = leftRectangle.Height;
            if (this._innerControlPath != null)
            {
                graphics_0.SetClip(this._innerControlPath);
                graphics_0.IntersectClip(rectangle);
            }
            else
            {
                graphics_0.SetClip(rectangle);
            }
            using (Brush brush = new LinearGradientBrush(rectangle, this.ButtonShadowColor2, this.ButtonShadowColor1, LinearGradientMode.Horizontal))
            {
                graphics_0.FillRectangle(brush, rectangle);
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
                    Rectangle rectangle2 = new Rectangle(x, (int)(rectangleF.Y + (rectangleF.Height - (float)size2.Height) / 2f), size2.Width, size2.Height);
                    if (!base.ToggleSwitch.Enabled && base.ToggleSwitch.GrayWhenDisabled)
                    {
                        graphics_0.DrawImage(base.ToggleSwitch.OnSideImage, rectangle2, 0, 0, base.ToggleSwitch.OnSideImage.Width, base.ToggleSwitch.OnSideImage.Height, GraphicsUnit.Pixel, ImageHelper.GetGrayscaleAttributes());
                    }
                    else
                    {
                        graphics_0.DrawImage(base.ToggleSwitch.OnSideImage, rectangle2);
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
                    Rectangle rectangle2 = new Rectangle(x, (int)(rectangleF.Y + (rectangleF.Height - (float)size.Height) / 2f), size.Width, size.Height);
                    if (!base.ToggleSwitch.Enabled && base.ToggleSwitch.GrayWhenDisabled)
                    {
                        graphics_0.DrawImage(base.ToggleSwitch.OnSideImage, rectangle2, 0, 0, base.ToggleSwitch.OnSideImage.Width, base.ToggleSwitch.OnSideImage.Height, GraphicsUnit.Pixel, ImageHelper.GetGrayscaleAttributes());
                    }
                    else
                    {
                        graphics_0.DrawImageUnscaled(base.ToggleSwitch.OnSideImage, rectangle2);
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
                Color color = base.ToggleSwitch.OnForeColor;
                if (!base.ToggleSwitch.Enabled && base.ToggleSwitch.GrayWhenDisabled)
                {
                    color = color.ToGrayScale();
                }
                using Brush brush2 = new SolidBrush(color);
                graphics_0.DrawString(base.ToggleSwitch.OnText, base.ToggleSwitch.OnFont, brush2, layoutRectangle);
            }
            graphics_0.ResetClip();
        }

        public override void RenderRightToggleField(Graphics graphics_0, Rectangle rightRectangle, int totalToggleFieldWidth)
        {
            graphics_0.SmoothingMode = SmoothingMode.HighQuality;
            graphics_0.PixelOffsetMode = PixelOffsetMode.HighQuality;
            graphics_0.InterpolationMode = InterpolationMode.HighQualityBilinear;
            Rectangle rectangle = default(Rectangle);
            rectangle.X = rightRectangle.X - this.CornerRadius;
            rectangle.Y = rightRectangle.Y;
            rectangle.Width = this.ButtonShadowWidth + this.CornerRadius;
            rectangle.Height = rightRectangle.Height;
            if (this._innerControlPath != null)
            {
                graphics_0.SetClip(this._innerControlPath);
                graphics_0.IntersectClip(rectangle);
            }
            else
            {
                graphics_0.SetClip(rectangle);
            }
            using (Brush brush = new LinearGradientBrush(rectangle, this.ButtonShadowColor1, this.ButtonShadowColor2, LinearGradientMode.Horizontal))
            {
                graphics_0.FillRectangle(brush, rectangle);
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
                    Rectangle rectangle2 = new Rectangle(x, (int)(rectangleF.Y + (rectangleF.Height - (float)size2.Height) / 2f), size2.Width, size2.Height);
                    if (!base.ToggleSwitch.Enabled && base.ToggleSwitch.GrayWhenDisabled)
                    {
                        graphics_0.DrawImage(base.ToggleSwitch.OnSideImage, rectangle2, 0, 0, base.ToggleSwitch.OnSideImage.Width, base.ToggleSwitch.OnSideImage.Height, GraphicsUnit.Pixel, ImageHelper.GetGrayscaleAttributes());
                    }
                    else
                    {
                        graphics_0.DrawImage(base.ToggleSwitch.OnSideImage, rectangle2);
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
                    Rectangle rectangle2 = new Rectangle(x, (int)(rectangleF.Y + (rectangleF.Height - (float)size.Height) / 2f), size.Width, size.Height);
                    if (!base.ToggleSwitch.Enabled && base.ToggleSwitch.GrayWhenDisabled)
                    {
                        graphics_0.DrawImage(base.ToggleSwitch.OnSideImage, rectangle2, 0, 0, base.ToggleSwitch.OnSideImage.Width, base.ToggleSwitch.OnSideImage.Height, GraphicsUnit.Pixel, ImageHelper.GetGrayscaleAttributes());
                    }
                    else
                    {
                        graphics_0.DrawImageUnscaled(base.ToggleSwitch.OffSideImage, rectangle2);
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
                Color color = base.ToggleSwitch.OffForeColor;
                if (!base.ToggleSwitch.Enabled && base.ToggleSwitch.GrayWhenDisabled)
                {
                    color = color.ToGrayScale();
                }
                using Brush brush2 = new SolidBrush(color);
                graphics_0.DrawString(base.ToggleSwitch.OffText, base.ToggleSwitch.OffFont, brush2, layoutRectangle);
            }
            graphics_0.ResetClip();
        }

        public override void RenderButton(Graphics graphics_0, Rectangle buttonRectangle)
        {
            graphics_0.SmoothingMode = SmoothingMode.HighQuality;
            graphics_0.PixelOffsetMode = PixelOffsetMode.HighQuality;
            graphics_0.InterpolationMode = InterpolationMode.HighQualityBilinear;
            buttonRectangle.Inflate(-1, -1);
            using GraphicsPath graphicsPath = this.GetRoundedRectanglePath(buttonRectangle, this.CornerRadius);
            graphics_0.SetClip(graphicsPath);
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
                graphics_0.FillPath(brush, graphicsPath);
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
            using (Brush brush2 = new LinearGradientBrush(buttonRectangle, color3, color4, LinearGradientMode.Vertical))
            {
                using Pen pen = new Pen(brush2);
                graphics_0.DrawPath(pen, graphicsPath);
            }
            graphics_0.ResetClip();
            Image image = base.ToggleSwitch.ButtonImage ?? (base.ToggleSwitch.Checked ? base.ToggleSwitch.OnButtonImage : base.ToggleSwitch.OffButtonImage);
            if (image == null)
            {
                return;
            }
            graphics_0.SetClip(graphicsPath);
            ToggleSwitch.ToggleSwitchButtonAlignment toggleSwitchButtonAlignment = ((base.ToggleSwitch.ButtonImage != null) ? base.ToggleSwitch.ButtonAlignment : (base.ToggleSwitch.Checked ? base.ToggleSwitch.OnButtonAlignment : base.ToggleSwitch.OffButtonAlignment));
            Size size = image.Size;
            int x = buttonRectangle.X;
            if ((base.ToggleSwitch.ButtonImage != null) ? base.ToggleSwitch.ButtonScaleImageToFit : (base.ToggleSwitch.Checked ? base.ToggleSwitch.OnButtonScaleImageToFit : base.ToggleSwitch.OffButtonScaleImageToFit))
            {
                Size size3 = ImageHelper.RescaleImageToFit(canvasSize: buttonRectangle.Size, imageSize: size);
                switch (toggleSwitchButtonAlignment)
                {
                    case ToggleSwitch.ToggleSwitchButtonAlignment.Center:
                        x = (int)((float)buttonRectangle.X + ((float)buttonRectangle.Width - (float)size3.Width) / 2f);
                        break;
                    case ToggleSwitch.ToggleSwitchButtonAlignment.Right:
                        x = (int)((float)buttonRectangle.X + (float)buttonRectangle.Width - (float)size3.Width);
                        break;
                }
                Rectangle rectangle = new Rectangle(x, (int)((float)buttonRectangle.Y + ((float)buttonRectangle.Height - (float)size3.Height) / 2f), size3.Width, size3.Height);
                if (!base.ToggleSwitch.Enabled && base.ToggleSwitch.GrayWhenDisabled)
                {
                    graphics_0.DrawImage(image, rectangle, 0, 0, image.Width, image.Height, GraphicsUnit.Pixel, ImageHelper.GetGrayscaleAttributes());
                }
                else
                {
                    graphics_0.DrawImage(image, rectangle);
                }
            }
            else
            {
                switch (toggleSwitchButtonAlignment)
                {
                    case ToggleSwitch.ToggleSwitchButtonAlignment.Center:
                        x = (int)((float)buttonRectangle.X + ((float)buttonRectangle.Width - (float)size.Width) / 2f);
                        break;
                    case ToggleSwitch.ToggleSwitchButtonAlignment.Right:
                        x = (int)((float)buttonRectangle.X + (float)buttonRectangle.Width - (float)size.Width);
                        break;
                }
                Rectangle rectangle = new Rectangle(x, (int)((float)buttonRectangle.Y + ((float)buttonRectangle.Height - (float)size.Height) / 2f), size.Width, size.Height);
                if (!base.ToggleSwitch.Enabled && base.ToggleSwitch.GrayWhenDisabled)
                {
                    graphics_0.DrawImage(image, rectangle, 0, 0, image.Width, image.Height, GraphicsUnit.Pixel, ImageHelper.GetGrayscaleAttributes());
                }
                else
                {
                    graphics_0.DrawImageUnscaled(image, rectangle);
                }
            }
            graphics_0.ResetClip();
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

        public override int GetButtonWidth()
        {
            return (int)(1.53f * (float)(base.ToggleSwitch.Height - 2));
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
