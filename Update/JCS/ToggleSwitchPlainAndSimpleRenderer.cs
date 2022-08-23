using System.Drawing;
using System.Drawing.Drawing2D;

namespace BirdBrainmofo.JCS
{
    public class ToggleSwitchPlainAndSimpleRenderer : ToggleSwitchRendererBase
    {
        public Color BorderColorChecked { get; set; }

        public Color BorderColorUnchecked { get; set; }

        public int BorderWidth { get; set; }

        public int ButtonMargin { get; set; }

        public Color InnerBackgroundColor { get; set; }

        public Color ButtonColor { get; set; }

        public ToggleSwitchPlainAndSimpleRenderer()
        {
            this.BorderColorChecked = Color.Black;
            this.BorderColorUnchecked = Color.Black;
            this.BorderWidth = 2;
            this.ButtonMargin = 1;
            this.InnerBackgroundColor = Color.White;
            this.ButtonColor = Color.Black;
        }

        public override void RenderBorder(Graphics graphics_0, Rectangle borderRectangle)
        {
        }

        public override void RenderLeftToggleField(Graphics graphics_0, Rectangle leftRectangle, int totalToggleFieldWidth)
        {
            graphics_0.SmoothingMode = SmoothingMode.HighQuality;
            graphics_0.PixelOffsetMode = PixelOffsetMode.HighQuality;
            this.GetButtonWidth();
            GraphicsPath innerBorderClipPath = this.GetInnerBorderClipPath(new Rectangle(0, 0, base.ToggleSwitch.Width, base.ToggleSwitch.Height));
            graphics_0.SetClip(innerBorderClipPath);
            graphics_0.IntersectClip(leftRectangle);
            using (Brush brush = new SolidBrush(this.InnerBackgroundColor))
            {
                graphics_0.FillPath(brush, innerBorderClipPath);
            }
            graphics_0.ResetClip();
        }

        public override void RenderRightToggleField(Graphics graphics_0, Rectangle rightRectangle, int totalToggleFieldWidth)
        {
            graphics_0.SmoothingMode = SmoothingMode.HighQuality;
            graphics_0.PixelOffsetMode = PixelOffsetMode.HighQuality;
            this.GetButtonWidth();
            GraphicsPath innerBorderClipPath = this.GetInnerBorderClipPath(new Rectangle(0, 0, base.ToggleSwitch.Width, base.ToggleSwitch.Height));
            graphics_0.SetClip(innerBorderClipPath);
            graphics_0.IntersectClip(rightRectangle);
            using (Brush brush = new SolidBrush(this.InnerBackgroundColor))
            {
                graphics_0.FillPath(brush, innerBorderClipPath);
            }
            graphics_0.ResetClip();
        }

        public override void RenderButton(Graphics graphics_0, Rectangle buttonRectangle)
        {
            graphics_0.SmoothingMode = SmoothingMode.HighQuality;
            graphics_0.PixelOffsetMode = PixelOffsetMode.HighQuality;
            GraphicsPath buttonClipPath = this.GetButtonClipPath();
            Rectangle rectangle = new Rectangle(0, 0, base.ToggleSwitch.Width, base.ToggleSwitch.Height);
            GraphicsPath controlClipPath = this.GetControlClipPath(rectangle);
            GraphicsPath innerBorderClipPath = this.GetInnerBorderClipPath(rectangle);
            graphics_0.SetClip(innerBorderClipPath);
            graphics_0.IntersectClip(buttonRectangle);
            using (Brush brush = new SolidBrush(this.InnerBackgroundColor))
            {
                graphics_0.FillRectangle(brush, buttonRectangle);
            }
            graphics_0.ResetClip();
            graphics_0.SetClip(this.GetButtonClipPath());
            graphics_0.IntersectClip(rectangle);
            using (Brush brush2 = new SolidBrush(this.ButtonColor))
            {
                graphics_0.FillPath(brush2, buttonClipPath);
            }
            graphics_0.ResetClip();
            graphics_0.SetClip(controlClipPath);
            graphics_0.ExcludeClip(new Region(innerBorderClipPath));
            using (Brush brush3 = new SolidBrush(base.ToggleSwitch.Checked ? this.BorderColorChecked : this.BorderColorUnchecked))
            {
                graphics_0.FillPath(brush3, controlClipPath);
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

        public GraphicsPath GetInnerBorderClipPath(Rectangle controlRectangle)
        {
            Rectangle rectangle = new Rectangle(controlRectangle.X + this.BorderWidth, controlRectangle.Y + this.BorderWidth, controlRectangle.Width - 2 * this.BorderWidth, controlRectangle.Height - 2 * this.BorderWidth);
            GraphicsPath graphicsPath = new GraphicsPath();
            graphicsPath.AddArc(rectangle.X, rectangle.Y, rectangle.Height, rectangle.Height, 90f, 180f);
            graphicsPath.AddArc(rectangle.X + rectangle.Width - rectangle.Height, rectangle.Y, rectangle.Height, rectangle.Height, 270f, 180f);
            graphicsPath.CloseFigure();
            return graphicsPath;
        }

        public GraphicsPath GetButtonClipPath()
        {
            Rectangle buttonRectangle = this.GetButtonRectangle();
            GraphicsPath graphicsPath = new GraphicsPath();
            graphicsPath.AddArc(buttonRectangle.X + this.ButtonMargin, buttonRectangle.Y + this.ButtonMargin, buttonRectangle.Height - 2 * this.ButtonMargin, buttonRectangle.Height - 2 * this.ButtonMargin, 0f, 360f);
            return graphicsPath;
        }

        public override int GetButtonWidth()
        {
            int num = base.ToggleSwitch.Height - 2 * this.BorderWidth;
            if (num <= 0)
            {
                return 0;
            }
            return num;
        }

        public override Rectangle GetButtonRectangle()
        {
            return this.GetButtonRectangle(this.GetButtonWidth());
        }

        public override Rectangle GetButtonRectangle(int buttonWidth)
        {
            if (buttonWidth <= 0)
            {
                return Rectangle.Empty;
            }
            Rectangle result = new Rectangle(base.ToggleSwitch.ButtonValue, this.BorderWidth, buttonWidth, buttonWidth);
            if (result.X < this.BorderWidth + this.ButtonMargin - 1)
            {
                result.X = this.BorderWidth + this.ButtonMargin - 1;
            }
            if (result.X + result.Width > base.ToggleSwitch.Width - this.BorderWidth - this.ButtonMargin + 1)
            {
                result.X = base.ToggleSwitch.Width - result.Width - this.BorderWidth - this.ButtonMargin + 1;
            }
            return result;
        }
    }
}
