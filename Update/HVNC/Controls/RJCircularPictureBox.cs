using System;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace BirdBrainmofo.HVNC.Controls
{
    public class RJCircularPictureBox : PictureBox
    {
        private int borderSize = 2;

        private Color borderColor = Color.RoyalBlue;

        private Color borderColor2 = Color.HotPink;

        private DashStyle borderLineStyle;

        private DashCap borderCapStyle;

        private float gradientAngle = 50f;

        [Category("RJ Code Advance")]
        public int BorderSize
        {
            get
            {
                return this.borderSize;
            }
            set
            {
                this.borderSize = value;
                base.Invalidate();
            }
        }

        [Category("RJ Code Advance")]
        public Color BorderColor
        {
            get
            {
                return this.borderColor;
            }
            set
            {
                this.borderColor = value;
                base.Invalidate();
            }
        }

        [Category("RJ Code Advance")]
        public Color BorderColor2
        {
            get
            {
                return this.borderColor2;
            }
            set
            {
                this.borderColor2 = value;
                base.Invalidate();
            }
        }

        [Category("RJ Code Advance")]
        public DashStyle BorderLineStyle
        {
            get
            {
                return this.borderLineStyle;
            }
            set
            {
                this.borderLineStyle = value;
                base.Invalidate();
            }
        }

        [Category("RJ Code Advance")]
        public DashCap BorderCapStyle
        {
            get
            {
                return this.borderCapStyle;
            }
            set
            {
                this.borderCapStyle = value;
                base.Invalidate();
            }
        }

        [Category("RJ Code Advance")]
        public float GradientAngle
        {
            get
            {
                return this.gradientAngle;
            }
            set
            {
                this.gradientAngle = value;
                base.Invalidate();
            }
        }

        public RJCircularPictureBox()
        {
            base.Size = new Size(100, 100);
            base.SizeMode = PictureBoxSizeMode.StretchImage;
        }

        protected override void OnResize(EventArgs eventArgs_0)
        {
            base.OnResize(eventArgs_0);
            base.Size = new Size(base.Width, base.Width);
        }

        protected override void OnPaint(PaintEventArgs pevent)
        {
            base.OnPaint(pevent);
            Graphics graphics = pevent.Graphics;
            Rectangle rect = Rectangle.Inflate(base.ClientRectangle, -1, -1);
            Rectangle rect2 = Rectangle.Inflate(rect, -this.borderSize, -this.borderSize);
            int num = ((this.borderSize <= 0) ? 1 : (this.borderSize * 3));
            using LinearGradientBrush brush = new LinearGradientBrush(rect2, this.borderColor, this.borderColor2, this.gradientAngle);
            using GraphicsPath graphicsPath = new GraphicsPath();
            using Pen pen2 = new Pen(base.Parent.BackColor, num);
            using Pen pen = new Pen(brush, this.borderSize);
            graphics.SmoothingMode = SmoothingMode.AntiAlias;
            pen.DashStyle = this.borderLineStyle;
            pen.DashCap = this.borderCapStyle;
            graphicsPath.AddEllipse(rect);
            base.Region = new Region(graphicsPath);
            graphics.DrawEllipse(pen2, rect);
            if (this.borderSize > 0)
            {
                graphics.DrawEllipse(pen, rect2);
            }
        }
    }
}
