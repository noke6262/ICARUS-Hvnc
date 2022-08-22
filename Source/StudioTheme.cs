using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace ICARUS
{
    public class StudioTheme : ThemeContainer152
    {
        private GraphicsPath Path;

        private Color C1;

        private Color C2;

        private Color C3;

        private Color C4;

        private Color C5;

        private Pen P1;

        private Pen P2;

        private Pen P3;

        private Pen P4;

        private Pen P5;

        private HatchBrush B1;

        private SolidBrush B2;

        private Rectangle RT1;

        public StudioTheme()
        {
            base.MoveHeight = 30;
            this.BackColor = Color.FromArgb(20, 40, 70);
            base.TransparencyKey = Color.Fuchsia;
            base.SetColor("Sides", 50, 70, 100);
            base.SetColor("Gradient1", 65, 85, 115);
            base.SetColor("Gradient2", 50, 70, 100);
            base.SetColor("Hatch1", 20, 40, 70);
            base.SetColor("Hatch2", 40, 60, 90);
            base.SetColor("Shade1", 15, Color.Black);
            base.SetColor("Shade2", Color.Transparent);
            base.SetColor("Border1", 12, 32, 62);
            base.SetColor("Border2", 20, Color.Black);
            base.SetColor("Border3", 30, Color.White);
            base.SetColor("Border4", Color.Black);
            base.SetColor("Text", Color.White);
            this.Path = new GraphicsPath();
        }

        protected override void ColorHook()
        {
            this.P1 = new Pen(base.TransparencyKey, 3f);
            this.P2 = new Pen(base.GetColor("Border1"));
            this.P3 = new Pen(base.GetColor("Border2"), 2f);
            this.P4 = new Pen(base.GetColor("Border3"));
            this.P5 = new Pen(base.GetColor("Border4"));
            this.C1 = base.GetColor("Sides");
            this.C2 = base.GetColor("Gradient1");
            this.C3 = base.GetColor("Gradient2");
            this.C4 = base.GetColor("Shade1");
            this.C5 = base.GetColor("Shade2");
            this.B1 = new HatchBrush(HatchStyle.LightDownwardDiagonal, base.GetColor("Hatch1"), base.GetColor("Hatch2"));
            this.B2 = new SolidBrush(base.GetColor("Text"));
            this.BackColor = base.GetColor("Hatch2");
        }

        protected override void PaintHook()
        {
            base.graphics_0.DrawRectangle(this.P1, base.ClientRectangle);
            base.graphics_0.SetClip(this.Path);
            base.graphics_0.Clear(this.C1);
            base.DrawGradient(this.C2, this.C3, 0, 0, base.Width, 30);
            this.RT1 = new Rectangle(12, 30, base.Width - 24, base.Height - 12 - 30);
            base.graphics_0.FillRectangle(this.B1, this.RT1);
            base.DrawGradient(this.C4, this.C5, 12, 30, base.Width - 24, 30);
            base.DrawBorders(this.P2, this.RT1);
            base.DrawBorders(this.P3, 14, 32, base.Width - 26, base.Height - 12 - 32);
            base.DrawText(this.B2, HorizontalAlignment.Left, 12, 0);
            base.DrawBorders(this.P4, 1);
            base.graphics_0.ResetClip();
            base.graphics_0.DrawPath(this.P5, this.Path);
        }

        protected override void OnResize(EventArgs eventArgs_0)
        {
            this.Path.Reset();
            this.Path.AddLines(new Point[9]
            {
                new Point(2, 0),
                new Point(base.Width - 3, 0),
                new Point(base.Width - 1, 2),
                new Point(base.Width - 1, base.Height - 3),
                new Point(base.Width - 3, base.Height - 1),
                new Point(2, base.Height - 1),
                new Point(0, base.Height - 3),
                new Point(0, 2),
                new Point(2, 0)
            });
            base.OnResize(eventArgs_0);
        }
    }
}