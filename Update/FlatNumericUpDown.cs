using System;
using System.ComponentModel;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace BirdBrainmofo
{
    internal class FlatNumericUpDown : NumericUpDown
    {
        private class UpDownButtonRenderer : NativeWindow
        {
            public struct PAINTSTRUCT
            {
                public IntPtr hdc;

                public bool fErase;

                public int rcPaint_left;

                public int rcPaint_top;

                public int rcPaint_right;

                public int rcPaint_bottom;

                public bool fRestore;

                public bool fIncUpdate;

                public int reserved1;

                public int reserved2;

                public int reserved3;

                public int reserved4;

                public int reserved5;

                public int reserved6;

                public int reserved7;

                public int reserved8;
            }

            private Control updown;

            [DllImport("user32.dll", CharSet = CharSet.Auto, ExactSpelling = true)]
            private static extern IntPtr BeginPaint(IntPtr hWnd, [In][Out] ref PAINTSTRUCT lpPaint);

            [DllImport("user32.dll", CharSet = CharSet.Auto, ExactSpelling = true)]
            private static extern bool EndPaint(IntPtr hWnd, ref PAINTSTRUCT lpPaint);

            public UpDownButtonRenderer(Control control_0)
            {
                this.updown = control_0;
                if (this.updown.IsHandleCreated)
                {
                    base.AssignHandle(this.updown.Handle);
                    return;
                }
                this.updown.HandleCreated += delegate
                {
                    base.AssignHandle(this.updown.Handle);
                };
            }

            private Point[] GetDownArrow(Rectangle rectangle_0)
            {
                Point point = new Point(rectangle_0.Left + rectangle_0.Width / 2, rectangle_0.Top + rectangle_0.Height / 2);
                return new Point[3]
                {
                    new Point(point.X - 3, point.Y - 2),
                    new Point(point.X + 4, point.Y - 2),
                    new Point(point.X, point.Y + 2)
                };
            }

            private Point[] GetUpArrow(Rectangle rectangle_0)
            {
                Point point = new Point(rectangle_0.Left + rectangle_0.Width / 2, rectangle_0.Top + rectangle_0.Height / 2);
                return new Point[3]
                {
                    new Point(point.X - 4, point.Y + 2),
                    new Point(point.X + 4, point.Y + 2),
                    new Point(point.X, point.Y - 3)
                };
            }

            protected override void WndProc(ref Message message_0)
            {
                if (message_0.Msg == 15 && ((FlatNumericUpDown)this.updown.Parent).BorderStyle == BorderStyle.FixedSingle)
                {
                    PAINTSTRUCT lpPaint = default(PAINTSTRUCT);
                    UpDownButtonRenderer.BeginPaint(this.updown.Handle, ref lpPaint);
                    using (Graphics graphics = Graphics.FromHdc(lpPaint.hdc))
                    {
                        bool enabled;
                        using (SolidBrush brush = new SolidBrush((enabled = this.updown.Enabled) ? ((FlatNumericUpDown)this.updown.Parent).BackColor : SystemColors.Control))
                        {
                            graphics.FillRectangle(brush, this.updown.ClientRectangle);
                        }
                        Rectangle rectangle = new Rectangle(0, 0, this.updown.Width, this.updown.Height / 2);
                        Rectangle rectangle2 = new Rectangle(0, this.updown.Height / 2, this.updown.Width, this.updown.Height / 2 + 1);
                        Point pt = this.updown.PointToClient(Control.MousePosition);
                        if (enabled && this.updown.ClientRectangle.Contains(pt))
                        {
                            using (SolidBrush brush2 = new SolidBrush(((FlatNumericUpDown)this.updown.Parent).ButtonHighlightColor))
                            {
                                if (rectangle.Contains(pt))
                                {
                                    graphics.FillRectangle(brush2, rectangle);
                                }
                                else
                                {
                                    graphics.FillRectangle(brush2, rectangle2);
                                }
                            }
                            using Pen pen = new Pen(((FlatNumericUpDown)this.updown.Parent).BorderColor);
                            graphics.DrawLines(pen, new Point[4]
                            {
                                new Point(0, 0),
                                new Point(0, this.updown.Height),
                                new Point(0, this.updown.Height / 2),
                                new Point(this.updown.Width, this.updown.Height / 2)
                            });
                        }
                        graphics.FillPolygon(Brushes.Black, this.GetUpArrow(rectangle));
                        graphics.FillPolygon(Brushes.Black, this.GetDownArrow(rectangle2));
                    }
                    message_0.Result = (IntPtr)1;
                    base.WndProc(ref message_0);
                    UpDownButtonRenderer.EndPaint(this.updown.Handle, ref lpPaint);
                }
                else if (message_0.Msg == 20)
                {
                    using (Graphics graphics2 = Graphics.FromHdcInternal(message_0.WParam))
                    {
                        graphics2.FillRectangle(Brushes.White, this.updown.ClientRectangle);
                    }
                    message_0.Result = (IntPtr)1;
                }
                else
                {
                    base.WndProc(ref message_0);
                }
            }
        }

        private Color borderColor = Color.Gray;

        private Color buttonHighlightColor = Color.LightGray;

        [DefaultValue(typeof(Color), "Gray")]
        public Color BorderColor
        {
            get
            {
                return this.borderColor;
            }
            set
            {
                if (this.borderColor != value)
                {
                    this.borderColor = value;
                    base.Invalidate();
                }
            }
        }

        [DefaultValue(typeof(Color), "LightGray")]
        public Color ButtonHighlightColor
        {
            get
            {
                return this.buttonHighlightColor;
            }
            set
            {
                if (this.buttonHighlightColor != value)
                {
                    this.buttonHighlightColor = value;
                    base.Invalidate();
                }
            }
        }

        protected override CreateParams CreateParams
        {
            get
            {
                CreateParams obj = base.CreateParams;
                obj.ExStyle |= 33554432;
                return obj;
            }
        }

        public FlatNumericUpDown()
        {
            new UpDownButtonRenderer(base.Controls[0]);
        }

        protected override void OnPaint(PaintEventArgs pevent)
        {
            base.OnPaint(pevent);
            if (base.BorderStyle == BorderStyle.FixedSingle)
            {
                using (Pen pen = new Pen(this.BorderColor, 1f))
                {
                    pevent.Graphics.DrawRectangle(pen, base.ClientRectangle.Left, base.ClientRectangle.Top, base.ClientRectangle.Width - 1, base.ClientRectangle.Height - 1);
                }
            }
        }
    }
}
