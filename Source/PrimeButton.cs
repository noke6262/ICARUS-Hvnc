using System.Drawing;
using System.Windows.Forms;

namespace ICARUS
{

    public class PrimeButton : ThemeControl152
    {
        private Color C1;

        private Color C2;

        private Color C3;

        private Color C4;

        private Color C5;

        private Color C6;

        private SolidBrush B1;

        private SolidBrush B2;

        private SolidBrush B3;

        private Pen P1;

        private Pen P2;

        public PrimeButton()
        {
            base.SetColor("DownGradient1", 215, 215, 215);
            base.SetColor("DownGradient2", 235, 235, 235);
            base.SetColor("NoneGradient1", 235, 235, 235);
            base.SetColor("NoneGradient2", 215, 215, 215);
            base.SetColor("NoneGradient3", 252, 252, 252);
            base.SetColor("NoneGradient4", 242, 242, 242);
            base.SetColor("Glow", 50, Color.White);
            base.SetColor("TextShade", Color.White);
            base.SetColor("Text", 80, 80, 80);
            base.SetColor("Border1", Color.White);
            base.SetColor("Border2", 180, 180, 180);
        }

        protected override void ColorHook()
        {
            this.C1 = base.GetColor("DownGradient1");
            this.C2 = base.GetColor("DownGradient2");
            this.C3 = base.GetColor("NoneGradient1");
            this.C4 = base.GetColor("NoneGradient2");
            this.C5 = base.GetColor("NoneGradient3");
            this.C6 = base.GetColor("NoneGradient4");
            this.B1 = new SolidBrush(base.GetColor("Glow"));
            this.B2 = new SolidBrush(base.GetColor("TextShade"));
            this.B3 = new SolidBrush(base.GetColor("Text"));
            this.P1 = new Pen(base.GetColor("Border1"));
            this.P2 = new Pen(base.GetColor("Border2"));
        }

        protected override void PaintHook()
        {
            if (base.State == MouseState.Down)
            {
                base.DrawGradient(this.C1, this.C2, base.ClientRectangle, 90f);
            }
            else
            {
                base.DrawGradient(this.C3, this.C4, base.ClientRectangle, 90f);
                base.DrawGradient(this.C5, this.C6, 0, 0, base.Width, base.Height / 2, 90f);
            }
            if (base.State == MouseState.Over)
            {
                base.graphics_0.FillRectangle(this.B1, base.ClientRectangle);
            }
            if (base.State == MouseState.Down)
            {
                base.DrawText(this.B2, HorizontalAlignment.Center, 2, 2);
                base.DrawText(this.B3, HorizontalAlignment.Center, 1, 1);
            }
            else
            {
                base.DrawText(this.B2, HorizontalAlignment.Center, 1, 1);
                base.DrawText(this.B3, HorizontalAlignment.Center, 0, 0);
            }
            base.DrawBorders(this.P1, 1);
            base.DrawBorders(this.P2);
            base.DrawCorners(this.BackColor);
        }
    }
}