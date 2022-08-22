using System.ComponentModel;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace ICARUS.HVNC.Controls
{
    public class RJToggleButton : CheckBox
    {
        private Color onBackColor = Color.MediumSlateBlue;

        private Color onToggleColor = Color.WhiteSmoke;

        private Color offBackColor = Color.Gray;

        private Color offToggleColor = Color.Gainsboro;

        private bool solidStyle = true;

        [Category("RJ Code Advance")]
        public Color OnBackColor
        {
            get
            {
                return this.onBackColor;
            }
            set
            {
                this.onBackColor = value;
                base.Invalidate();
            }
        }

        [Category("RJ Code Advance")]
        public Color OnToggleColor
        {
            get
            {
                return this.onToggleColor;
            }
            set
            {
                this.onToggleColor = value;
                base.Invalidate();
            }
        }

        [Category("RJ Code Advance")]
        public Color OffBackColor
        {
            get
            {
                return this.offBackColor;
            }
            set
            {
                this.offBackColor = value;
                base.Invalidate();
            }
        }

        [Category("RJ Code Advance")]
        public Color OffToggleColor
        {
            get
            {
                return this.offToggleColor;
            }
            set
            {
                this.offToggleColor = value;
                base.Invalidate();
            }
        }

        [Browsable(false)]
        public override string Text
        {
            get
            {
                return base.Text;
            }
            set
            {
            }
        }

        [DefaultValue(true)]
        [Category("RJ Code Advance")]
        public bool SolidStyle
        {
            get
            {
                return this.solidStyle;
            }
            set
            {
                this.solidStyle = value;
                base.Invalidate();
            }
        }

        public RJToggleButton()
        {
            this.MinimumSize = new Size(45, 22);
        }

        private GraphicsPath GetFigurePath()
        {
            int num = base.Height - 1;
            Rectangle rect = new Rectangle(0, 0, num, num);
            Rectangle rect2 = new Rectangle(base.Width - num - 2, 0, num, num);
            GraphicsPath graphicsPath = new GraphicsPath();
            graphicsPath.StartFigure();
            graphicsPath.AddArc(rect, 90f, 180f);
            graphicsPath.AddArc(rect2, 270f, 180f);
            graphicsPath.CloseFigure();
            return graphicsPath;
        }

        protected override void OnPaint(PaintEventArgs pevent)
        {
            int num = base.Height - 5;
            pevent.Graphics.SmoothingMode = SmoothingMode.AntiAlias;
            pevent.Graphics.Clear(base.Parent.BackColor);
            if (base.Checked)
            {
                if (this.solidStyle)
                {
                    pevent.Graphics.FillPath(new SolidBrush(this.onBackColor), this.GetFigurePath());
                }
                else
                {
                    pevent.Graphics.DrawPath(new Pen(this.onBackColor, 2f), this.GetFigurePath());
                }
                pevent.Graphics.FillEllipse(new SolidBrush(this.onToggleColor), new Rectangle(base.Width - base.Height + 1, 2, num, num));
            }
            else
            {
                if (this.solidStyle)
                {
                    pevent.Graphics.FillPath(new SolidBrush(this.offBackColor), this.GetFigurePath());
                }
                else
                {
                    pevent.Graphics.DrawPath(new Pen(this.offBackColor, 2f), this.GetFigurePath());
                }
                pevent.Graphics.FillEllipse(new SolidBrush(this.offToggleColor), new Rectangle(2, 2, num, num));
            }
        }
    }
}
