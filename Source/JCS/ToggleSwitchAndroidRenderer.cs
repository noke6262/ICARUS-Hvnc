using System;
using System.Drawing;
using ICARUS.ToggleSwitch;

namespace ICARUS.JCS
{
    public class ToggleSwitchAndroidRenderer : ToggleSwitchRendererBase
    {
        public Color BorderColor { get; set; }

        public Color BackColor { get; set; }

        public Color LeftSideColor { get; set; }

        public Color RightSideColor { get; set; }

        public Color OffButtonColor { get; set; }

        public Color OnButtonColor { get; set; }

        public Color OffButtonBorderColor { get; set; }

        public Color OnButtonBorderColor { get; set; }

        public int SlantAngle { get; set; }

        public ToggleSwitchAndroidRenderer()
        {
            this.BorderColor = Color.FromArgb(255, 166, 166, 166);
            this.BackColor = Color.FromArgb(255, 32, 32, 32);
            this.LeftSideColor = Color.FromArgb(255, 32, 32, 32);
            this.RightSideColor = Color.FromArgb(255, 32, 32, 32);
            this.OffButtonColor = Color.FromArgb(255, 70, 70, 70);
            this.OnButtonColor = Color.FromArgb(255, 27, 161, 226);
            this.OffButtonBorderColor = Color.FromArgb(255, 70, 70, 70);
            this.OnButtonBorderColor = Color.FromArgb(255, 27, 161, 226);
            this.SlantAngle = 8;
        }

        public override void RenderBorder(Graphics graphics_0, Rectangle borderRectangle)
        {
            Color color = ((base.ToggleSwitch.Enabled || !base.ToggleSwitch.GrayWhenDisabled) ? this.BorderColor : this.BorderColor.ToGrayScale());
            graphics_0.SetClip(borderRectangle);
            using Pen pen = new Pen(color);
            graphics_0.DrawRectangle(pen, borderRectangle.X, borderRectangle.Y, borderRectangle.Width - 1, borderRectangle.Height - 1);
        }

        public override void RenderLeftToggleField(Graphics graphics_0, Rectangle leftRectangle, int totalToggleFieldWidth)
        {
            Color color = this.LeftSideColor;
            if (!base.ToggleSwitch.Enabled && base.ToggleSwitch.GrayWhenDisabled)
            {
                color = color.ToGrayScale();
            }
            graphics_0.SetClip(this.GetInnerControlRectangle());
            int halfCathetusLengthBasedOnAngle = this.GetHalfCathetusLengthBasedOnAngle();
            Rectangle rect = new Rectangle(leftRectangle.X, leftRectangle.Y, leftRectangle.Width + halfCathetusLengthBasedOnAngle, leftRectangle.Height);
            graphics_0.IntersectClip(rect);
            using (Brush brush = new SolidBrush(color))
            {
                graphics_0.FillRectangle(brush, rect);
            }
            graphics_0.ResetClip();
        }

        public override void RenderRightToggleField(Graphics graphics_0, Rectangle rightRectangle, int totalToggleFieldWidth)
        {
            Color color = this.RightSideColor;
            if (!base.ToggleSwitch.Enabled && base.ToggleSwitch.GrayWhenDisabled)
            {
                color = color.ToGrayScale();
            }
            graphics_0.SetClip(this.GetInnerControlRectangle());
            int halfCathetusLengthBasedOnAngle = this.GetHalfCathetusLengthBasedOnAngle();
            Rectangle rect = new Rectangle(rightRectangle.X - halfCathetusLengthBasedOnAngle, rightRectangle.Y, rightRectangle.Width + halfCathetusLengthBasedOnAngle, rightRectangle.Height);
            graphics_0.IntersectClip(rect);
            using (Brush brush = new SolidBrush(color))
            {
                graphics_0.FillRectangle(brush, rect);
            }
            graphics_0.ResetClip();
        }

        public override void RenderButton(Graphics graphics_0, Rectangle buttonRectangle)
        {
            Rectangle innerControlRectangle = this.GetInnerControlRectangle();
            graphics_0.SetClip(innerControlRectangle);
            int cathetusLengthBasedOnAngle = this.GetCathetusLengthBasedOnAngle();
            int num = 2 * cathetusLengthBasedOnAngle;
            Point[] array = new Point[4];
            Rectangle rect = new Rectangle(buttonRectangle.X - cathetusLengthBasedOnAngle, innerControlRectangle.Y, buttonRectangle.Width + num, innerControlRectangle.Height);
            if (this.SlantAngle > 0)
            {
                array[0] = new Point(rect.X + cathetusLengthBasedOnAngle, rect.Y);
                array[1] = new Point(rect.X + rect.Width - 1, rect.Y);
                array[2] = new Point(rect.X + rect.Width - cathetusLengthBasedOnAngle - 1, rect.Y + rect.Height - 1);
                array[3] = new Point(rect.X, rect.Y + rect.Height - 1);
            }
            else
            {
                array[0] = new Point(rect.X, rect.Y);
                array[1] = new Point(rect.X + rect.Width - cathetusLengthBasedOnAngle - 1, rect.Y);
                array[2] = new Point(rect.X + rect.Width - 1, rect.Y + rect.Height - 1);
                array[3] = new Point(rect.X + cathetusLengthBasedOnAngle, rect.Y + rect.Height - 1);
            }
            graphics_0.IntersectClip(rect);
            Color color = (base.ToggleSwitch.Checked ? this.OnButtonColor : this.OffButtonColor);
            Color color2 = (base.ToggleSwitch.Checked ? this.OnButtonBorderColor : this.OffButtonBorderColor);
            if (!base.ToggleSwitch.Enabled && base.ToggleSwitch.GrayWhenDisabled)
            {
                color = color.ToGrayScale();
                color2 = color2.ToGrayScale();
            }
            using (Pen pen = new Pen(color2))
            {
                graphics_0.DrawPolygon(pen, array);
            }
            using (Brush brush = new SolidBrush(color))
            {
                graphics_0.FillPolygon(brush, array);
            }
            Image image = base.ToggleSwitch.ButtonImage ?? (base.ToggleSwitch.Checked ? base.ToggleSwitch.OnButtonImage : base.ToggleSwitch.OffButtonImage);
            string text = (base.ToggleSwitch.Checked ? base.ToggleSwitch.OnText : base.ToggleSwitch.OffText);
            if (image != null || !string.IsNullOrEmpty(text))
            {
                ToggleSwitch.ToggleSwitchButtonAlignment toggleSwitchButtonAlignment = ((base.ToggleSwitch.ButtonImage != null) ? base.ToggleSwitch.ButtonAlignment : (base.ToggleSwitch.Checked ? base.ToggleSwitch.OnButtonAlignment : base.ToggleSwitch.OffButtonAlignment));
                if (image != null)
                {
                    Size size = image.Size;
                    int x = rect.X;
                    if ((base.ToggleSwitch.ButtonImage != null) ? base.ToggleSwitch.ButtonScaleImageToFit : (base.ToggleSwitch.Checked ? base.ToggleSwitch.OnButtonScaleImageToFit : base.ToggleSwitch.OffButtonScaleImageToFit))
                    {
                        Size size3 = ImageHelper.RescaleImageToFit(canvasSize: rect.Size, imageSize: size);
                        switch (toggleSwitchButtonAlignment)
                        {
                            case ToggleSwitch.ToggleSwitchButtonAlignment.Center:
                                x = (int)((float)rect.X + ((float)rect.Width - (float)size3.Width) / 2f);
                                break;
                            case ToggleSwitch.ToggleSwitchButtonAlignment.Right:
                                x = (int)((float)rect.X + (float)rect.Width - (float)size3.Width);
                                break;
                        }
                        Rectangle rectangle = new Rectangle(x, (int)((float)rect.Y + ((float)rect.Height - (float)size3.Height) / 2f), size3.Width, size3.Height);
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
                                x = (int)((float)rect.X + ((float)rect.Width - (float)size.Width) / 2f);
                                break;
                            case ToggleSwitch.ToggleSwitchButtonAlignment.Right:
                                x = (int)((float)rect.X + (float)rect.Width - (float)size.Width);
                                break;
                        }
                        Rectangle rectangle = new Rectangle(x, (int)((float)rect.Y + ((float)rect.Height - (float)size.Height) / 2f), size.Width, size.Height);
                        if (!base.ToggleSwitch.Enabled && base.ToggleSwitch.GrayWhenDisabled)
                        {
                            graphics_0.DrawImage(image, rectangle, 0, 0, image.Width, image.Height, GraphicsUnit.Pixel, ImageHelper.GetGrayscaleAttributes());
                        }
                        else
                        {
                            graphics_0.DrawImageUnscaled(image, rectangle);
                        }
                    }
                }
                else if (!string.IsNullOrEmpty(text))
                {
                    Font font = (base.ToggleSwitch.Checked ? base.ToggleSwitch.OnFont : base.ToggleSwitch.OffFont);
                    Color color3 = (base.ToggleSwitch.Checked ? base.ToggleSwitch.OnForeColor : base.ToggleSwitch.OffForeColor);
                    if (!base.ToggleSwitch.Enabled && base.ToggleSwitch.GrayWhenDisabled)
                    {
                        color3 = color3.ToGrayScale();
                    }
                    SizeF sizeF = graphics_0.MeasureString(text, font);
                    float x2 = rect.X;
                    switch (toggleSwitchButtonAlignment)
                    {
                        case ToggleSwitch.ToggleSwitchButtonAlignment.Center:
                            x2 = (float)rect.X + ((float)rect.Width - sizeF.Width) / 2f;
                            break;
                        case ToggleSwitch.ToggleSwitchButtonAlignment.Right:
                            x2 = (float)rect.X + (float)rect.Width - sizeF.Width;
                            break;
                    }
                    RectangleF layoutRectangle = new RectangleF(x2, (float)rect.Y + ((float)rect.Height - sizeF.Height) / 2f, sizeF.Width, sizeF.Height);
                    using Brush brush2 = new SolidBrush(color3);
                    graphics_0.DrawString(text, font, brush2, layoutRectangle);
                }
            }
            graphics_0.ResetClip();
        }

        public Rectangle GetInnerControlRectangle()
        {
            return new Rectangle(1, 1, base.ToggleSwitch.Width - 2, base.ToggleSwitch.Height - 2);
        }

        public int GetCathetusLengthBasedOnAngle()
        {
            if (this.SlantAngle == 0)
            {
                return 0;
            }
            return (int)(Math.Tan((double)Math.Abs(this.SlantAngle) * (Math.PI / 180.0)) * (double)base.ToggleSwitch.Height);
        }

        public int GetHalfCathetusLengthBasedOnAngle()
        {
            if (this.SlantAngle == 0)
            {
                return 0;
            }
            return (int)(Math.Tan((double)Math.Abs(this.SlantAngle) * (Math.PI / 180.0)) * (double)base.ToggleSwitch.Height / 2.0);
        }

        public override int GetButtonWidth()
        {
            return (int)((double)base.ToggleSwitch.Width / 2.0);
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
