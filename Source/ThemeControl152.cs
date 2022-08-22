using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.IO;
using System.Windows.Forms;
using ICARUS.HVNC;

namespace ICARUS
{
    public abstract class ThemeControl152 : Control
    {
        protected Graphics graphics_0;

        protected Bitmap bitmap_0;

        private bool InPosition;

        protected MouseState State;

        private bool _BackColorU;

        private bool _NoRounding;

        private Image _Image;

        private Size _ImageSize;

        private int _LockWidth;

        private int _LockHeight;

        private bool _Transparent;

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

        [Category("Misc")]
        public override Color BackColor
        {
            get
            {
                return base.BackColor;
            }
            set
            {
                if (!base.IsHandleCreated && value == Color.Transparent)
                {
                    this._BackColorU = true;
                    return;
                }
                base.BackColor = value;
                if (base.Parent != null)
                {
                    this.ColorHook();
                }
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
        [EditorBrowsable(EditorBrowsableState.Never)]
        [Browsable(false)]
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

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        [Browsable(false)]
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

        public bool Transparent
        {
            get
            {
                return this._Transparent;
            }
            set
            {
                this._Transparent = value;
                if (base.IsHandleCreated)
                {
                    if (!value && this.BackColor.A != byte.MaxValue)
                    {
                        throw new Exception("Unable to change value to false while a transparent BackColor is in use.");
                    }
                    base.SetStyle(ControlStyles.Opaque, !value);
                    base.SetStyle(ControlStyles.SupportsTransparentBackColor, value);
                    if (value)
                    {
                        this.InvalidateBitmap();
                    }
                    else
                    {
                        this.bitmap_0 = null;
                    }
                    base.Invalidate();
                }
            }
        }

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
        public Bloom[] Colors
        {
            get
            {
                List<Bloom> list = new List<Bloom>();
                Dictionary<string, Color>.Enumerator enumerator = this.Items.GetEnumerator();
                while (enumerator.MoveNext())
                {
                    list.Add(new Bloom(enumerator.Current.Key, enumerator.Current.Value));
                }
                return list.ToArray();
            }
            set
            {
                foreach (Bloom bloom in value)
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
                Bloom[] colors = this.Colors;
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

        public ThemeControl152()
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
            if (this._Transparent && base.Width != 0 && base.Height != 0)
            {
                this.bitmap_0 = new Bitmap(base.Width, base.Height);
                this.graphics_0 = Graphics.FromImage(this.bitmap_0);
            }
            base.Invalidate();
            base.OnSizeChanged(eventArgs_0);
        }

        protected sealed override void OnPaint(PaintEventArgs pevent)
        {
            if (base.Width != 0 && base.Height != 0)
            {
                if (this._Transparent)
                {
                    this.PaintHook();
                    pevent.Graphics.DrawImage(this.bitmap_0, 0, 0);
                }
                else
                {
                    this.graphics_0 = pevent.Graphics;
                    this.PaintHook();
                }
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
            this.Transparent = this._Transparent;
            if (this._BackColorU && this._Transparent)
            {
                this.BackColor = Color.Transparent;
            }
            base.OnHandleCreated(eventArgs_0);
        }

        protected sealed override void OnParentChanged(EventArgs eventArgs_0)
        {
            if (base.Parent != null)
            {
                this.OnCreation();
            }
            base.OnParentChanged(eventArgs_0);
        }

        protected virtual void OnCreation()
        {
        }

        protected override void OnMouseEnter(EventArgs eventargs)
        {
            this.InPosition = true;
            this.SetState(MouseState.Over);
            base.OnMouseEnter(eventargs);
        }

        protected override void OnMouseUp(MouseEventArgs mevent)
        {
            if (this.InPosition)
            {
                this.SetState(MouseState.Over);
            }
            base.OnMouseUp(mevent);
        }

        protected override void OnMouseDown(MouseEventArgs mevent)
        {
            if (mevent.Button == MouseButtons.Left)
            {
                this.SetState(MouseState.Down);
            }
            base.OnMouseDown(mevent);
        }

        protected override void OnMouseLeave(EventArgs eventargs)
        {
            this.InPosition = false;
            this.SetState(MouseState.None);
            base.OnMouseLeave(eventargs);
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

        private void SetState(MouseState current)
        {
            this.State = current;
            base.Invalidate();
        }

        private void InvalidateBitmap()
        {
            if (base.Width != 0 && base.Height != 0)
            {
                this.bitmap_0 = new Bitmap(base.Width, base.Height);
                this.graphics_0 = Graphics.FromImage(this.bitmap_0);
            }
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
            Bloom[] colors = this.Colors;
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
            return this.MeasureGraphics.MeasureString(this.Text, this.Font, base.Width).ToSize();
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
                if (this._Transparent)
                {
                    this.bitmap_0.SetPixel(int_0, int_1, c1);
                    this.bitmap_0.SetPixel(int_0 + (width - 1), int_1, c1);
                    this.bitmap_0.SetPixel(int_0, int_1 + (height - 1), c1);
                    this.bitmap_0.SetPixel(int_0 + (width - 1), int_1 + (height - 1), c1);
                }
                else
                {
                    this.DrawCornersBrush = new SolidBrush(c1);
                    this.graphics_0.FillRectangle(this.DrawCornersBrush, int_0, int_1, 1, 1);
                    this.graphics_0.FillRectangle(this.DrawCornersBrush, int_0 + (width - 1), int_1, 1, 1);
                    this.graphics_0.FillRectangle(this.DrawCornersBrush, int_0, int_1 + (height - 1), 1, 1);
                    this.graphics_0.FillRectangle(this.DrawCornersBrush, int_0 + (width - 1), int_1 + (height - 1), 1, 1);
                }
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
                this.DrawTextPoint = this.Center(this.DrawTextSize);
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
                this.DrawImagePoint = this.Center(image.Size);
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