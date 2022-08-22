using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace ICARUS.JCS
{
    public abstract class ToggleSwitchRendererBase
    {
        private ToggleSwitch _toggleSwitch;

        internal ToggleSwitch ToggleSwitch => this._toggleSwitch;

        internal void SetToggleSwitch(ToggleSwitch toggleSwitch)
        {
            this._toggleSwitch = toggleSwitch;
        }

        public void RenderBackground(PaintEventArgs paintEventArgs_0)
        {
            if (this._toggleSwitch != null)
            {
                paintEventArgs_0.Graphics.SmoothingMode = SmoothingMode.AntiAlias;
                Rectangle rectangle = new Rectangle(0, 0, this._toggleSwitch.Width, this._toggleSwitch.Height);
                this.FillBackground(paintEventArgs_0.Graphics, rectangle);
                this.RenderBorder(paintEventArgs_0.Graphics, rectangle);
            }
        }

        public void RenderControl(PaintEventArgs paintEventArgs_0)
        {
            if (this._toggleSwitch == null)
            {
                return;
            }
            paintEventArgs_0.Graphics.SmoothingMode = SmoothingMode.AntiAlias;
            Rectangle buttonRectangle = this.GetButtonRectangle();
            int totalToggleFieldWidth = this.ToggleSwitch.Width - buttonRectangle.Width;
            if (buttonRectangle.X > 0)
            {
                Rectangle leftRectangle = new Rectangle(0, 0, buttonRectangle.X, this.ToggleSwitch.Height);
                if (leftRectangle.Width > 0)
                {
                    this.RenderLeftToggleField(paintEventArgs_0.Graphics, leftRectangle, totalToggleFieldWidth);
                }
            }
            if (buttonRectangle.X + buttonRectangle.Width < paintEventArgs_0.ClipRectangle.Width)
            {
                Rectangle rightRectangle = new Rectangle(buttonRectangle.X + buttonRectangle.Width, 0, this.ToggleSwitch.Width - buttonRectangle.X - buttonRectangle.Width, this.ToggleSwitch.Height);
                if (rightRectangle.Width > 0)
                {
                    this.RenderRightToggleField(paintEventArgs_0.Graphics, rightRectangle, totalToggleFieldWidth);
                }
            }
            this.RenderButton(paintEventArgs_0.Graphics, buttonRectangle);
        }

        public void FillBackground(Graphics graphics_0, Rectangle controlRectangle)
        {
            using Brush brush = new SolidBrush((this.ToggleSwitch.Enabled || !this.ToggleSwitch.GrayWhenDisabled) ? this.ToggleSwitch.BackColor : this.ToggleSwitch.BackColor.ToGrayScale());
            graphics_0.FillRectangle(brush, controlRectangle);
        }

        public abstract void RenderBorder(Graphics graphics_0, Rectangle borderRectangle);

        public abstract void RenderLeftToggleField(Graphics graphics_0, Rectangle leftRectangle, int totalToggleFieldWidth);

        public abstract void RenderRightToggleField(Graphics graphics_0, Rectangle rightRectangle, int totalToggleFieldWidth);

        public abstract void RenderButton(Graphics graphics_0, Rectangle buttonRectangle);

        public abstract int GetButtonWidth();

        public abstract Rectangle GetButtonRectangle();

        public abstract Rectangle GetButtonRectangle(int buttonWidth);
    }
}
