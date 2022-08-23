using System.Drawing;
using System.Windows.Forms;

namespace BirdBrainmofo
{
    internal class PrimeTheme : ThemeContainer152
    {
        private Color C1;

        private Color C2;

        private Color C3;

        private SolidBrush B1;

        private SolidBrush B2;

        private SolidBrush B3;

        private Pen P1;

        private Pen P2;

        private Pen P3;

        private Pen P4;

        private Rectangle RT1;

        public PrimeTheme()
        {
            base.MoveHeight = 32;
            this.BackColor = Color.White;
            base.TransparencyKey = Color.Fuchsia;
            base.SetColor("Sides", 232, 232, 232);
            base.SetColor("Gradient1", 252, 252, 252);
            base.SetColor("Gradient2", 242, 242, 242);
            base.SetColor("TextShade", Color.White);
            base.SetColor("Text", 80, 80, 80);
            base.SetColor("Back", Color.White);
            base.SetColor("Border1", 180, 180, 180);
            base.SetColor("Border2", Color.White);
            base.SetColor("Border3", Color.White);
            base.SetColor("Border4", 150, 150, 150);
        }

        protected override void ColorHook()
        {
            this.C1 = base.GetColor("Sides");
            this.C2 = base.GetColor("Gradient1");
            this.C3 = base.GetColor("Gradient2");
            this.B1 = new SolidBrush(base.GetColor("TextShade"));
            this.B2 = new SolidBrush(base.GetColor("Text"));
            this.B3 = new SolidBrush(base.GetColor("Back"));
            this.P1 = new Pen(base.GetColor("Border1"));
            this.P2 = new Pen(base.GetColor("Border2"));
            this.P3 = new Pen(base.GetColor("Border3"));
            this.P4 = new Pen(base.GetColor("Border4"));
            this.BackColor = this.B3.Color;
        }

        protected override void PaintHook()
        {
            base.DrawGradient(this.C2, this.C3, 0, 0, base.Width, 15);
            base.DrawText(this.B1, HorizontalAlignment.Left, 13, 1);
            base.DrawText(this.B2, HorizontalAlignment.Left, 12, 0);
            this.RT1 = new Rectangle(12, 30, base.Width - 24, base.Height - 42);
            base.DrawBorders(this.P1, this.RT1, 1);
            base.DrawBorders(this.P2, this.RT1);
            base.DrawBorders(this.P3, 1);
            base.DrawBorders(this.P4);
            base.DrawCorners(base.TransparencyKey);
        }
    }
}
