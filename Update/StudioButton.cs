using System.Drawing;
using System.Windows.Forms;

namespace BirdBrainmofo
{
    internal class StudioButton : ThemeControl152
    {
        private Color C1;

        private Color C2;

        private Color C3;

        private Color C4;

        private Color C5;

        private Color C6;

        private Color C7;

        private Pen P1;

        private Pen P2;

        private Pen P3;

        private SolidBrush B1;

        private SolidBrush B2;

        private SolidBrush B3;

        public StudioButton()
        {
            base.Transparent = true;
            this.BackColor = Color.Transparent;
            base.SetColor("DownGradient1", 45, 65, 95);
            base.SetColor("DownGradient2", 65, 85, 115);
            base.SetColor("NoneGradient1", 65, 85, 115);
            base.SetColor("NoneGradient2", 45, 65, 95);
            base.SetColor("Shine1", 30, Color.White);
            base.SetColor("Shine2A", 30, Color.White);
            base.SetColor("Shine2B", Color.Transparent);
            base.SetColor("Shine3", 20, Color.White);
            base.SetColor("TextShade", 50, Color.Black);
            base.SetColor("Text", Color.White);
            base.SetColor("Glow", 10, Color.White);
            base.SetColor("Border", 20, 40, 70);
            base.SetColor("Corners", 20, 40, 70);
        }

        protected override void ColorHook()
        {
            this.C1 = base.GetColor("DownGradient1");
            this.C2 = base.GetColor("DownGradient2");
            this.C3 = base.GetColor("NoneGradient1");
            this.C4 = base.GetColor("NoneGradient2");
            this.C5 = base.GetColor("Shine2A");
            this.C6 = base.GetColor("Shine2B");
            this.C7 = base.GetColor("Corners");
            this.P1 = new Pen(base.GetColor("Shine1"));
            this.P2 = new Pen(base.GetColor("Shine3"));
            this.P3 = new Pen(base.GetColor("Border"));
            this.B1 = new SolidBrush(base.GetColor("TextShade"));
            this.B2 = new SolidBrush(base.GetColor("Text"));
            this.B3 = new SolidBrush(base.GetColor("Glow"));
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
            }
            base.DrawGradient(this.C5, this.C6, 1, 1, 1, base.Height);
            base.DrawGradient(this.C5, this.C6, base.Width - 2, 1, 1, base.Height);
            if (base.State == MouseState.Down)
            {
                base.DrawText(this.B1, HorizontalAlignment.Center, 2, 2);
                base.DrawText(this.B2, HorizontalAlignment.Center, 1, 1);
            }
            else
            {
                base.DrawText(this.B1, HorizontalAlignment.Center, 1, 1);
                base.DrawText(this.B2, HorizontalAlignment.Center, 0, 0);
            }
            _ = base.State;
            _ = 1;
            base.DrawBorders(this.P3);
            base.DrawCorners(this.C7, 1, 1, base.Width - 2, base.Height - 2);
            base.DrawCorners(this.BackColor);
        }
    }
}
