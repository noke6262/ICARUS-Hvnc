using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using ICARUS.ToggleSwitch;

namespace ICARUS.JCS
{
    public class ToggleSwitchIOS5Renderer : ToggleSwitchRendererBase
    {
        public Color BorderColor { get; set; }

        public Color LeftSideUpperColor1 { get; set; }

        public Color LeftSideUpperColor2 { get; set; }

        public Color LeftSideLowerColor1 { get; set; }

        public Color LeftSideLowerColor2 { get; set; }

        public Color LeftSideUpperBorderColor { get; set; }

        public Color LeftSideLowerBorderColor { get; set; }

        public Color RightSideUpperColor1 { get; set; }

        public Color RightSideUpperColor2 { get; set; }

        public Color RightSideLowerColor1 { get; set; }

        public Color RightSideLowerColor2 { get; set; }

        public Color RightSideUpperBorderColor { get; set; }

        public Color RightSideLowerBorderColor { get; set; }

        public Color ButtonShadowColor { get; set; }

        public Color ButtonNormalOuterBorderColor { get; set; }

        public Color ButtonNormalInnerBorderColor { get; set; }

        public Color ButtonNormalSurfaceColor1 { get; set; }

        public Color ButtonNormalSurfaceColor2 { get; set; }

        public Color ButtonHoverOuterBorderColor { get; set; }

        public Color ButtonHoverInnerBorderColor { get; set; }

        public Color ButtonHoverSurfaceColor1 { get; set; }

        public Color ButtonHoverSurfaceColor2 { get; set; }

        public Color ButtonPressedOuterBorderColor { get; set; }

        public Color ButtonPressedInnerBorderColor { get; set; }

        public Color ButtonPressedSurfaceColor1 { get; set; }

        public Color ButtonPressedSurfaceColor2 { get; set; }

        public ToggleSwitchIOS5Renderer()
        {
            this.BorderColor = Color.FromArgb(255, 202, 202, 202);
            this.LeftSideUpperColor1 = Color.FromArgb(255, 48, 115, 189);
            this.LeftSideUpperColor2 = Color.FromArgb(255, 17, 123, 220);
            this.LeftSideLowerColor1 = Color.FromArgb(255, 65, 143, 218);
            this.LeftSideLowerColor2 = Color.FromArgb(255, 130, 190, 243);
            this.LeftSideUpperBorderColor = Color.FromArgb(150, 123, 157, 196);
            this.LeftSideLowerBorderColor = Color.FromArgb(150, 174, 208, 241);
            this.RightSideUpperColor1 = Color.FromArgb(255, 191, 191, 191);
            this.RightSideUpperColor2 = Color.FromArgb(255, 229, 229, 229);
            this.RightSideLowerColor1 = Color.FromArgb(255, 232, 232, 232);
            this.RightSideLowerColor2 = Color.FromArgb(255, 251, 251, 251);
            this.RightSideUpperBorderColor = Color.FromArgb(150, 175, 175, 175);
            this.RightSideLowerBorderColor = Color.FromArgb(150, 229, 230, 233);
            this.ButtonShadowColor = Color.Transparent;
            this.ButtonNormalOuterBorderColor = Color.FromArgb(255, 149, 172, 194);
            this.ButtonNormalInnerBorderColor = Color.FromArgb(255, 235, 235, 235);
            this.ButtonNormalSurfaceColor1 = Color.FromArgb(255, 216, 215, 216);
            this.ButtonNormalSurfaceColor2 = Color.FromArgb(255, 251, 250, 251);
            this.ButtonHoverOuterBorderColor = Color.FromArgb(255, 141, 163, 184);
            this.ButtonHoverInnerBorderColor = Color.FromArgb(255, 223, 223, 223);
            this.ButtonHoverSurfaceColor1 = Color.FromArgb(255, 205, 204, 205);
            this.ButtonHoverSurfaceColor2 = Color.FromArgb(255, 239, 238, 239);
            this.ButtonPressedOuterBorderColor = Color.FromArgb(255, 111, 128, 145);
            this.ButtonPressedInnerBorderColor = Color.FromArgb(255, 176, 176, 176);
            this.ButtonPressedSurfaceColor1 = Color.FromArgb(255, 162, 161, 162);
            this.ButtonPressedSurfaceColor2 = Color.FromArgb(255, 187, 187, 187);
        }

        public override void RenderBorder(Graphics graphics_0, Rectangle borderRectangle)
        {
        }

        public override void RenderLeftToggleField(Graphics graphics_0, Rectangle leftRectangle, int totalToggleFieldWidth)
        {
            graphics_0.SmoothingMode = SmoothingMode.HighQuality;
            graphics_0.PixelOffsetMode = PixelOffsetMode.HighQuality;
            int buttonWidth = this.GetButtonWidth();
            int width = leftRectangle.Width + buttonWidth / 2;
            int num = (int)(0.8 * (double)(leftRectangle.Height - 2));
            GraphicsPath controlClipPath = this.GetControlClipPath(new Rectangle(0, 0, base.ToggleSwitch.Width, base.ToggleSwitch.Height));
            Rectangle rect = new Rectangle(leftRectangle.X, leftRectangle.Y + 1, width, num - 1);
            graphics_0.SetClip(controlClipPath);
            graphics_0.IntersectClip(rect);
            using (GraphicsPath graphicsPath = new GraphicsPath())
            {
                graphicsPath.AddArc(rect.X, rect.Y, base.ToggleSwitch.Height, base.ToggleSwitch.Height, 135f, 135f);
                graphicsPath.AddLine(rect.X, rect.Y, rect.X + rect.Width, rect.Y);
                graphicsPath.AddLine(rect.X + rect.Width, rect.Y, rect.X + rect.Width, rect.Y + rect.Height);
                graphicsPath.AddLine(rect.X, rect.Y + rect.Height, rect.X + rect.Width, rect.Y + rect.Height);
                using Brush brush = new LinearGradientBrush(color1: (base.ToggleSwitch.Enabled || !base.ToggleSwitch.GrayWhenDisabled) ? this.LeftSideUpperColor1 : this.LeftSideUpperColor1.ToGrayScale(), color2: (base.ToggleSwitch.Enabled || !base.ToggleSwitch.GrayWhenDisabled) ? this.LeftSideUpperColor2 : this.LeftSideUpperColor2.ToGrayScale(), rect: rect, linearGradientMode: LinearGradientMode.Vertical);
                graphics_0.FillPath(brush, graphicsPath);
            }
            graphics_0.ResetClip();
            Rectangle rect2 = new Rectangle(height: (int)Math.Ceiling(0.5 * (double)(leftRectangle.Height - 2)), x: leftRectangle.X, y: leftRectangle.Y + leftRectangle.Height / 2, width: width);
            graphics_0.SetClip(controlClipPath);
            graphics_0.IntersectClip(rect2);
            using (GraphicsPath graphicsPath2 = new GraphicsPath())
            {
                graphicsPath2.AddArc(1, rect2.Y, (int)(0.75 * (double)(base.ToggleSwitch.Height - 1)), base.ToggleSwitch.Height - 1, 215f, 45f);
                graphicsPath2.AddLine(rect2.X + buttonWidth / 2, rect2.Y, rect2.X + rect2.Width, rect2.Y);
                graphicsPath2.AddLine(rect2.X + rect2.Width, rect2.Y, rect2.X + rect2.Width, rect2.Y + rect2.Height);
                graphicsPath2.AddLine(rect2.X + buttonWidth / 4, rect2.Y + rect2.Height, rect2.X + rect2.Width, rect2.Y + rect2.Height);
                graphicsPath2.AddArc(1, 1, base.ToggleSwitch.Height - 1, base.ToggleSwitch.Height - 1, 90f, 70f);
                using Brush brush2 = new LinearGradientBrush(color1: (base.ToggleSwitch.Enabled || !base.ToggleSwitch.GrayWhenDisabled) ? this.LeftSideLowerColor1 : this.LeftSideLowerColor1.ToGrayScale(), color2: (base.ToggleSwitch.Enabled || !base.ToggleSwitch.GrayWhenDisabled) ? this.LeftSideLowerColor2 : this.LeftSideLowerColor2.ToGrayScale(), rect: rect2, linearGradientMode: LinearGradientMode.Vertical);
                graphics_0.FillPath(brush2, graphicsPath2);
            }
            graphics_0.ResetClip();
            graphics_0.SetClip(this.GetControlClipPath(new Rectangle(0, 0, base.ToggleSwitch.Width, base.ToggleSwitch.Height)));
            Color color5 = this.LeftSideUpperBorderColor;
            if (!base.ToggleSwitch.Enabled && base.ToggleSwitch.GrayWhenDisabled)
            {
                color5 = color5.ToGrayScale();
            }
            using (Pen pen = new Pen(color5))
            {
                graphics_0.DrawLine(pen, leftRectangle.X, leftRectangle.Y + 1, leftRectangle.X + leftRectangle.Width + buttonWidth / 2, leftRectangle.Y + 1);
            }
            Color color6 = this.LeftSideLowerBorderColor;
            if (!base.ToggleSwitch.Enabled && base.ToggleSwitch.GrayWhenDisabled)
            {
                color6 = color6.ToGrayScale();
            }
            using (Pen pen2 = new Pen(color6))
            {
                graphics_0.DrawLine(pen2, leftRectangle.X, leftRectangle.Y + leftRectangle.Height - 1, leftRectangle.X + leftRectangle.Width + buttonWidth / 2, leftRectangle.Y + leftRectangle.Height - 1);
            }
            if (base.ToggleSwitch.OnSideImage != null || !string.IsNullOrEmpty(base.ToggleSwitch.OnText))
            {
                RectangleF rect3 = new RectangleF(leftRectangle.X + 2 - (totalToggleFieldWidth - leftRectangle.Width), 2f, totalToggleFieldWidth - 2, base.ToggleSwitch.Height - 4);
                graphics_0.IntersectClip(rect3);
                if (base.ToggleSwitch.OnSideImage != null)
                {
                    Size size = base.ToggleSwitch.OnSideImage.Size;
                    int x = (int)rect3.X;
                    if (base.ToggleSwitch.OnSideScaleImageToFit)
                    {
                        Size size2 = ImageHelper.RescaleImageToFit(canvasSize: new Size((int)rect3.Width, (int)rect3.Height), imageSize: size);
                        if (base.ToggleSwitch.OnSideAlignment == ToggleSwitch.ToggleSwitchAlignment.Center)
                        {
                            x = (int)(rect3.X + (rect3.Width - (float)size2.Width) / 2f);
                        }
                        else if (base.ToggleSwitch.OnSideAlignment == ToggleSwitch.ToggleSwitchAlignment.Near)
                        {
                            x = (int)(rect3.X + rect3.Width - (float)size2.Width);
                        }
                        Rectangle rectangle = new Rectangle(x, (int)(rect3.Y + (rect3.Height - (float)size2.Height) / 2f), size2.Width, size2.Height);
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
                            x = (int)(rect3.X + (rect3.Width - (float)size.Width) / 2f);
                        }
                        else if (base.ToggleSwitch.OnSideAlignment == ToggleSwitch.ToggleSwitchAlignment.Near)
                        {
                            x = (int)(rect3.X + rect3.Width - (float)size.Width);
                        }
                        Rectangle rectangle = new Rectangle(x, (int)(rect3.Y + (rect3.Height - (float)size.Height) / 2f), size.Width, size.Height);
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
                    float x2 = rect3.X;
                    if (base.ToggleSwitch.OnSideAlignment == ToggleSwitch.ToggleSwitchAlignment.Center)
                    {
                        x2 = rect3.X + (rect3.Width - sizeF.Width) / 2f;
                    }
                    else if (base.ToggleSwitch.OnSideAlignment == ToggleSwitch.ToggleSwitchAlignment.Near)
                    {
                        x2 = rect3.X + rect3.Width - sizeF.Width;
                    }
                    RectangleF layoutRectangle = new RectangleF(x2, rect3.Y + (rect3.Height - sizeF.Height) / 2f, sizeF.Width, sizeF.Height);
                    Color color7 = base.ToggleSwitch.OnForeColor;
                    if (!base.ToggleSwitch.Enabled && base.ToggleSwitch.GrayWhenDisabled)
                    {
                        color7 = color7.ToGrayScale();
                    }
                    using Brush brush3 = new SolidBrush(color7);
                    graphics_0.DrawString(base.ToggleSwitch.OnText, base.ToggleSwitch.OnFont, brush3, layoutRectangle);
                }
            }
            graphics_0.ResetClip();
        }

        public override void RenderRightToggleField(Graphics graphics_0, Rectangle rightRectangle, int totalToggleFieldWidth)
        {
            graphics_0.SmoothingMode = SmoothingMode.HighQuality;
            graphics_0.PixelOffsetMode = PixelOffsetMode.HighQuality;
            Rectangle buttonRectangle = this.GetButtonRectangle();
            GraphicsPath controlClipPath = this.GetControlClipPath(new Rectangle(0, 0, base.ToggleSwitch.Width, base.ToggleSwitch.Height));
            int num = rightRectangle.Width + buttonRectangle.Width / 2;
            Rectangle rect = new Rectangle(height: (int)(0.8 * (double)(rightRectangle.Height - 2)) - 1, x: rightRectangle.X - buttonRectangle.Width / 2, y: rightRectangle.Y + 1, width: num - 1);
            graphics_0.SetClip(controlClipPath);
            graphics_0.IntersectClip(rect);
            using (GraphicsPath graphicsPath = new GraphicsPath())
            {
                graphicsPath.AddLine(rect.X, rect.Y, rect.X + rect.Width, rect.Y);
                graphicsPath.AddArc(rect.X + rect.Width - base.ToggleSwitch.Height + 1, rect.Y - 1, base.ToggleSwitch.Height, base.ToggleSwitch.Height, 270f, 115f);
                graphicsPath.AddLine(rect.X + rect.Width, rect.Y + rect.Height, rect.X, rect.Y + rect.Height);
                graphicsPath.AddLine(rect.X, rect.Y + rect.Height, rect.X, rect.Y);
                using Brush brush = new LinearGradientBrush(color1: (base.ToggleSwitch.Enabled || !base.ToggleSwitch.GrayWhenDisabled) ? this.RightSideUpperColor1 : this.RightSideUpperColor1.ToGrayScale(), color2: (base.ToggleSwitch.Enabled || !base.ToggleSwitch.GrayWhenDisabled) ? this.RightSideUpperColor2 : this.RightSideUpperColor2.ToGrayScale(), rect: rect, linearGradientMode: LinearGradientMode.Vertical);
                graphics_0.FillPath(brush, graphicsPath);
            }
            graphics_0.ResetClip();
            Rectangle rect2 = new Rectangle(height: (int)Math.Ceiling(0.5 * (double)(rightRectangle.Height - 2)), x: rightRectangle.X - buttonRectangle.Width / 2, y: rightRectangle.Y + rightRectangle.Height / 2, width: num - 1);
            graphics_0.SetClip(controlClipPath);
            graphics_0.IntersectClip(rect2);
            using (GraphicsPath graphicsPath2 = new GraphicsPath())
            {
                graphicsPath2.AddLine(rect2.X, rect2.Y, rect2.X + rect2.Width, rect2.Y);
                graphicsPath2.AddArc(rect2.X + rect2.Width - (int)(0.75 * (double)(base.ToggleSwitch.Height - 1)), rect2.Y, (int)(0.75 * (double)(base.ToggleSwitch.Height - 1)), base.ToggleSwitch.Height - 1, 270f, 45f);
                graphicsPath2.AddArc(base.ToggleSwitch.Width - base.ToggleSwitch.Height, 0, base.ToggleSwitch.Height, base.ToggleSwitch.Height, 20f, 70f);
                graphicsPath2.AddLine(rect2.X + rect2.Width, rect2.Y + rect2.Height, rect2.X, rect2.Y + rect2.Height);
                graphicsPath2.AddLine(rect2.X, rect2.Y + rect2.Height, rect2.X, rect2.Y);
                using Brush brush2 = new LinearGradientBrush(color1: (base.ToggleSwitch.Enabled || !base.ToggleSwitch.GrayWhenDisabled) ? this.RightSideLowerColor1 : this.RightSideLowerColor1.ToGrayScale(), color2: (base.ToggleSwitch.Enabled || !base.ToggleSwitch.GrayWhenDisabled) ? this.RightSideLowerColor2 : this.RightSideLowerColor2.ToGrayScale(), rect: rect2, linearGradientMode: LinearGradientMode.Vertical);
                graphics_0.FillPath(brush2, graphicsPath2);
            }
            graphics_0.ResetClip();
            graphics_0.SetClip(this.GetControlClipPath(new Rectangle(0, 0, base.ToggleSwitch.Width, base.ToggleSwitch.Height)));
            Color color5 = this.RightSideUpperBorderColor;
            if (!base.ToggleSwitch.Enabled && base.ToggleSwitch.GrayWhenDisabled)
            {
                color5 = color5.ToGrayScale();
            }
            using (Pen pen = new Pen(color5))
            {
                graphics_0.DrawLine(pen, rightRectangle.X - buttonRectangle.Width / 2, rightRectangle.Y + 1, rightRectangle.X + rightRectangle.Width, rightRectangle.Y + 1);
            }
            Color color6 = this.RightSideLowerBorderColor;
            if (!base.ToggleSwitch.Enabled && base.ToggleSwitch.GrayWhenDisabled)
            {
                color6 = color6.ToGrayScale();
            }
            using (Pen pen2 = new Pen(color6))
            {
                graphics_0.DrawLine(pen2, rightRectangle.X - buttonRectangle.Width / 2, rightRectangle.Y + rightRectangle.Height - 1, rightRectangle.X + rightRectangle.Width, rightRectangle.Y + rightRectangle.Height - 1);
            }
            if (base.ToggleSwitch.OffSideImage != null || !string.IsNullOrEmpty(base.ToggleSwitch.OffText))
            {
                RectangleF rect3 = new RectangleF(rightRectangle.X, 2f, totalToggleFieldWidth - 2, base.ToggleSwitch.Height - 4);
                graphics_0.IntersectClip(rect3);
                if (base.ToggleSwitch.OffSideImage != null)
                {
                    Size size = base.ToggleSwitch.OffSideImage.Size;
                    int x = (int)rect3.X;
                    if (base.ToggleSwitch.OffSideScaleImageToFit)
                    {
                        Size size2 = ImageHelper.RescaleImageToFit(canvasSize: new Size((int)rect3.Width, (int)rect3.Height), imageSize: size);
                        if (base.ToggleSwitch.OffSideAlignment == ToggleSwitch.ToggleSwitchAlignment.Center)
                        {
                            x = (int)(rect3.X + (rect3.Width - (float)size2.Width) / 2f);
                        }
                        else if (base.ToggleSwitch.OffSideAlignment == ToggleSwitch.ToggleSwitchAlignment.Far)
                        {
                            x = (int)(rect3.X + rect3.Width - (float)size2.Width);
                        }
                        Rectangle rectangle = new Rectangle(x, (int)(rect3.Y + (rect3.Height - (float)size2.Height) / 2f), size2.Width, size2.Height);
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
                            x = (int)(rect3.X + (rect3.Width - (float)size.Width) / 2f);
                        }
                        else if (base.ToggleSwitch.OffSideAlignment == ToggleSwitch.ToggleSwitchAlignment.Far)
                        {
                            x = (int)(rect3.X + rect3.Width - (float)size.Width);
                        }
                        Rectangle rectangle = new Rectangle(x, (int)(rect3.Y + (rect3.Height - (float)size.Height) / 2f), size.Width, size.Height);
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
                    float x2 = rect3.X;
                    if (base.ToggleSwitch.OffSideAlignment == ToggleSwitch.ToggleSwitchAlignment.Center)
                    {
                        x2 = rect3.X + (rect3.Width - sizeF.Width) / 2f;
                    }
                    else if (base.ToggleSwitch.OffSideAlignment == ToggleSwitch.ToggleSwitchAlignment.Far)
                    {
                        x2 = rect3.X + rect3.Width - sizeF.Width;
                    }
                    RectangleF layoutRectangle = new RectangleF(x2, rect3.Y + (rect3.Height - sizeF.Height) / 2f, sizeF.Width, sizeF.Height);
                    Color color7 = base.ToggleSwitch.OffForeColor;
                    if (!base.ToggleSwitch.Enabled && base.ToggleSwitch.GrayWhenDisabled)
                    {
                        color7 = color7.ToGrayScale();
                    }
                    using Brush brush3 = new SolidBrush(color7);
                    graphics_0.DrawString(base.ToggleSwitch.OffText, base.ToggleSwitch.OffFont, brush3, layoutRectangle);
                }
            }
            graphics_0.ResetClip();
        }

        public override void RenderButton(Graphics graphics_0, Rectangle buttonRectangle)
        {
            if (base.ToggleSwitch.IsButtonOnLeftSide)
            {
                buttonRectangle.X++;
            }
            else if (base.ToggleSwitch.IsButtonOnRightSide)
            {
                buttonRectangle.X--;
            }
            graphics_0.SmoothingMode = SmoothingMode.HighQuality;
            graphics_0.PixelOffsetMode = PixelOffsetMode.HighQuality;
            buttonRectangle.Inflate(1, 1);
            Rectangle clip = new Rectangle(buttonRectangle.Location, buttonRectangle.Size);
            clip.Inflate(0, -1);
            if (base.ToggleSwitch.IsButtonOnLeftSide)
            {
                clip.X += clip.Width / 2;
                clip.Width /= 2;
            }
            else if (base.ToggleSwitch.IsButtonOnRightSide)
            {
                clip.Width /= 2;
            }
            graphics_0.SetClip(clip);
            using (Pen pen = new Pen((base.ToggleSwitch.Enabled || !base.ToggleSwitch.GrayWhenDisabled) ? this.ButtonShadowColor : this.ButtonShadowColor.ToGrayScale()))
            {
                graphics_0.DrawEllipse(pen, buttonRectangle);
            }
            graphics_0.ResetClip();
            buttonRectangle.Inflate(-1, -1);
            Color color = this.ButtonNormalOuterBorderColor;
            if (base.ToggleSwitch.IsButtonPressed)
            {
                color = this.ButtonPressedOuterBorderColor;
            }
            else if (base.ToggleSwitch.IsButtonHovered)
            {
                color = this.ButtonHoverOuterBorderColor;
            }
            if (!base.ToggleSwitch.Enabled && base.ToggleSwitch.GrayWhenDisabled)
            {
                color = color.ToGrayScale();
            }
            using (Brush brush = new SolidBrush(color))
            {
                graphics_0.FillEllipse(brush, buttonRectangle);
            }
            buttonRectangle.Inflate(-1, -1);
            Color color2 = this.ButtonNormalInnerBorderColor;
            if (base.ToggleSwitch.IsButtonPressed)
            {
                color2 = this.ButtonPressedInnerBorderColor;
            }
            else if (base.ToggleSwitch.IsButtonHovered)
            {
                color2 = this.ButtonHoverInnerBorderColor;
            }
            if (!base.ToggleSwitch.Enabled && base.ToggleSwitch.GrayWhenDisabled)
            {
                color2 = color2.ToGrayScale();
            }
            using (Brush brush2 = new SolidBrush(color2))
            {
                graphics_0.FillEllipse(brush2, buttonRectangle);
            }
            buttonRectangle.Inflate(-1, -1);
            Color color3 = this.ButtonNormalSurfaceColor1;
            if (base.ToggleSwitch.IsButtonPressed)
            {
                color3 = this.ButtonPressedSurfaceColor1;
            }
            else if (base.ToggleSwitch.IsButtonHovered)
            {
                color3 = this.ButtonHoverSurfaceColor1;
            }
            if (!base.ToggleSwitch.Enabled && base.ToggleSwitch.GrayWhenDisabled)
            {
                color3 = color3.ToGrayScale();
            }
            Color color4 = this.ButtonNormalSurfaceColor2;
            if (base.ToggleSwitch.IsButtonPressed)
            {
                color4 = this.ButtonPressedSurfaceColor2;
            }
            else if (base.ToggleSwitch.IsButtonHovered)
            {
                color4 = this.ButtonHoverSurfaceColor2;
            }
            if (!base.ToggleSwitch.Enabled && base.ToggleSwitch.GrayWhenDisabled)
            {
                color4 = color4.ToGrayScale();
            }
            using (Brush brush3 = new LinearGradientBrush(buttonRectangle, color3, color4, LinearGradientMode.Vertical))
            {
                graphics_0.FillEllipse(brush3, buttonRectangle);
            }
            graphics_0.CompositingMode = CompositingMode.SourceOver;
            graphics_0.CompositingQuality = CompositingQuality.HighQuality;
            using (GraphicsPath path = this.GetControlClipPath(new Rectangle(0, 0, base.ToggleSwitch.Width, base.ToggleSwitch.Height)))
            {
                using Pen pen2 = new Pen((base.ToggleSwitch.Enabled || !base.ToggleSwitch.GrayWhenDisabled) ? this.BorderColor : this.BorderColor.ToGrayScale());
                graphics_0.DrawPath(pen2, path);
            }
            graphics_0.ResetClip();
            Image image = base.ToggleSwitch.ButtonImage ?? (base.ToggleSwitch.Checked ? base.ToggleSwitch.OnButtonImage : base.ToggleSwitch.OffButtonImage);
            if (image == null)
            {
                return;
            }
            graphics_0.SetClip(this.GetButtonClipPath());
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

        public GraphicsPath GetControlClipPath(Rectangle controlRectangle)
        {
            GraphicsPath graphicsPath = new GraphicsPath();
            graphicsPath.AddArc(controlRectangle.X, controlRectangle.Y, controlRectangle.Height, controlRectangle.Height, 90f, 180f);
            graphicsPath.AddArc(controlRectangle.X + controlRectangle.Width - controlRectangle.Height, controlRectangle.Y, controlRectangle.Height, controlRectangle.Height, 270f, 180f);
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
    }
}
