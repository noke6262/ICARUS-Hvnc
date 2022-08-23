using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using BirdBrainmofo.ToggleSwitch;

namespace BirdBrainmofo.JCS
{
    [DefaultValue("Checked")]
    [ToolboxBitmap(typeof(CheckBox))]
    [DefaultEvent("CheckedChanged")]
    public class ToggleSwitch : Control
    {
        public delegate void CheckedChangedDelegate(object sender, EventArgs e);

        public delegate void BeforeRenderingDelegate(object sender, BeforeRenderingEventArgs e);

        public enum ToggleSwitchStyle
        {
            Metro = 0,
            Android = 1,
            IOS5 = 2,
            BrushedMetal = 3,
            OSX = 4,
            Carbon = 5,
            Iphone = 6,
            Fancy = 7,
            Modern = 8,
            PlainAndSimpel = 9
        }

        public enum ToggleSwitchAlignment
        {
            Near = 0,
            Center = 1,
            Far = 2
        }

        public enum ToggleSwitchButtonAlignment
        {
            Left = 0,
            Center = 1,
            Right = 2
        }

        private readonly Timer _animationTimer = new Timer();

        private ToggleSwitchRendererBase _renderer;

        private ToggleSwitchStyle _style;

        private bool _checked;

        private bool _moving;

        private bool _animating;

        private bool _animationResult;

        private int _animationTarget;

        private bool _useAnimation = true;

        private int _animationInterval = 1;

        private int _animationStep = 10;

        private bool _allowUserChange = true;

        private bool _isLeftFieldHovered;

        private bool _isButtonHovered;

        private bool _isRightFieldHovered;

        private bool _isLeftFieldPressed;

        private bool _isButtonPressed;

        private bool _isRightFieldPressed;

        private int _buttonValue;

        private int _savedButtonValue;

        private int _xOffset;

        private int _xValue;

        private int _thresholdPercentage = 50;

        private bool _grayWhenDisabled = true;

        private bool _toggleOnButtonClick = true;

        private bool _toggleOnSideClick = true;

        private MouseEventArgs _lastMouseEventArgs;

        private bool _buttonScaleImage;

        private ToggleSwitchButtonAlignment _buttonAlignment = ToggleSwitchButtonAlignment.Center;

        private Image _buttonImage;

        private string _offText = "";

        private Color _offForeColor = Color.Black;

        private Font _offFont;

        private Image _offSideImage;

        private bool _offSideScaleImage;

        private ToggleSwitchAlignment _offSideAlignment = ToggleSwitchAlignment.Center;

        private Image _offButtonImage;

        private bool _offButtonScaleImage;

        private ToggleSwitchButtonAlignment _offButtonAlignment = ToggleSwitchButtonAlignment.Center;

        private string _onText = "";

        private Color _onForeColor = Color.Black;

        private Font _onFont;

        private Image _onSideImage;

        private bool _onSideScaleImage;

        private ToggleSwitchAlignment _onSideAlignment = ToggleSwitchAlignment.Center;

        private Image _onButtonImage;

        private bool _onButtonScaleImage;

        private ToggleSwitchButtonAlignment _onButtonAlignment = ToggleSwitchButtonAlignment.Center;

        [Description("Gets or sets the style of the ToggleSwitch")]
        [Bindable(false)]
        [Category("Appearance")]
        [DefaultValue(typeof(ToggleSwitchStyle), "Metro")]
        public ToggleSwitchStyle Style
        {
            get
            {
                return this._style;
            }
            set
            {
                if (value != this._style)
                {
                    this._style = value;
                    switch (this._style)
                    {
                        case ToggleSwitchStyle.Metro:
                            this.SetRenderer(new ToggleSwitchMetroRenderer());
                            break;
                        case ToggleSwitchStyle.Android:
                            this.SetRenderer(new ToggleSwitchAndroidRenderer());
                            break;
                        case ToggleSwitchStyle.IOS5:
                            this.SetRenderer(new ToggleSwitchIOS5Renderer());
                            break;
                        case ToggleSwitchStyle.BrushedMetal:
                            this.SetRenderer(new ToggleSwitchBrushedMetalRenderer());
                            break;
                        case ToggleSwitchStyle.OSX:
                            this.SetRenderer(new ToggleSwitchOSXRenderer());
                            break;
                        case ToggleSwitchStyle.Carbon:
                            this.SetRenderer(new ToggleSwitchCarbonRenderer());
                            break;
                        case ToggleSwitchStyle.Iphone:
                            this.SetRenderer(new ToggleSwitchIphoneRenderer());
                            break;
                        case ToggleSwitchStyle.Fancy:
                            this.SetRenderer(new ToggleSwitchFancyRenderer());
                            break;
                        case ToggleSwitchStyle.Modern:
                            this.SetRenderer(new ToggleSwitchModernRenderer());
                            break;
                        case ToggleSwitchStyle.PlainAndSimpel:
                            this.SetRenderer(new ToggleSwitchPlainAndSimpleRenderer());
                            break;
                    }
                }
                this.Refresh();
            }
        }

        [Category("Data")]
        [Bindable(true)]
        [Description("Gets or sets the Checked value of the ToggleSwitch")]
        [DefaultValue(false)]
        public bool Checked
        {
            get
            {
                return this._checked;
            }
            set
            {
                if (value != this._checked)
                {
                    while (this._animating)
                    {
                        Application.DoEvents();
                    }
                    if (value)
                    {
                        int buttonWidth = this._renderer.GetButtonWidth();
                        this._animationTarget = base.Width - buttonWidth;
                        this.BeginAnimation(checkedValue: true);
                    }
                    else
                    {
                        this._animationTarget = 0;
                        this.BeginAnimation(checkedValue: false);
                    }
                }
            }
        }

        [Description("Gets or sets whether the user can change the value of the button or not")]
        [DefaultValue(true)]
        [Category("Behavior")]
        [Bindable(true)]
        public bool AllowUserChange
        {
            get
            {
                return this._allowUserChange;
            }
            set
            {
                this._allowUserChange = value;
            }
        }

        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public string CheckedString
        {
            get
            {
                if (!this.Checked)
                {
                    if (!string.IsNullOrEmpty(this.OffText))
                    {
                        return this.OffText;
                    }
                    return "OFF";
                }
                if (!string.IsNullOrEmpty(this.OnText))
                {
                    return this.OnText;
                }
                return "ON";
            }
        }

        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public Rectangle ButtonRectangle => this._renderer.GetButtonRectangle();

        [DefaultValue(true)]
        [Category("Appearance")]
        [Bindable(false)]
        [Description("Gets or sets if the ToggleSwitch should be grayed out when disabled")]
        public bool GrayWhenDisabled
        {
            get
            {
                return this._grayWhenDisabled;
            }
            set
            {
                if (value != this._grayWhenDisabled)
                {
                    this._grayWhenDisabled = value;
                    if (!base.Enabled)
                    {
                        this.Refresh();
                    }
                }
            }
        }

        [DefaultValue(true)]
        [Bindable(false)]
        [Category("Behavior")]
        [Description("Gets or sets if the ToggleSwitch should toggle when the button is clicked")]
        public bool ToggleOnButtonClick
        {
            get
            {
                return this._toggleOnButtonClick;
            }
            set
            {
                this._toggleOnButtonClick = value;
            }
        }

        [Description("Gets or sets if the ToggleSwitch should toggle when the track besides the button is clicked")]
        [Bindable(false)]
        [DefaultValue(true)]
        [Category("Behavior")]
        public bool ToggleOnSideClick
        {
            get
            {
                return this._toggleOnSideClick;
            }
            set
            {
                this._toggleOnSideClick = value;
            }
        }

        [Bindable(false)]
        [Category("Behavior")]
        [Description("Gets or sets how much the button need to be on the other side (in peercept) before it snaps")]
        [DefaultValue(50)]
        public int ThresholdPercentage
        {
            get
            {
                return this._thresholdPercentage;
            }
            set
            {
                this._thresholdPercentage = value;
            }
        }

        [Bindable(false)]
        [Description("Gets or sets the forecolor of the text when Checked=false")]
        [Category("Appearance")]
        [DefaultValue(typeof(Color), "Black")]
        public Color OffForeColor
        {
            get
            {
                return this._offForeColor;
            }
            set
            {
                if (value != this._offForeColor)
                {
                    this._offForeColor = value;
                    this.Refresh();
                }
            }
        }

        [DefaultValue(typeof(Font), "Microsoft Sans Serif, 8.25pt")]
        [Bindable(false)]
        [Category("Appearance")]
        [Description("Gets or sets the font of the text when Checked=false")]
        public Font OffFont
        {
            get
            {
                return this._offFont;
            }
            set
            {
                if (!value.Equals(this._offFont))
                {
                    this._offFont = value;
                    this.Refresh();
                }
            }
        }

        [Bindable(false)]
        [Category("Appearance")]
        [DefaultValue("")]
        [Description("Gets or sets the text when Checked=true")]
        public string OffText
        {
            get
            {
                return this._offText;
            }
            set
            {
                if (value != this._offText)
                {
                    this._offText = value;
                    this.Refresh();
                }
            }
        }

        [Description("Gets or sets the side image when Checked=false - Note: Settings the OffSideImage overrules the OffText property. Only the image will be shown")]
        [Bindable(false)]
        [Category("Appearance")]
        [DefaultValue(null)]
        public Image OffSideImage
        {
            get
            {
                return this._offSideImage;
            }
            set
            {
                if (value != this._offSideImage)
                {
                    this._offSideImage = value;
                    this.Refresh();
                }
            }
        }

        [Bindable(false)]
        [Category("Behavior")]
        [DefaultValue(false)]
        [Description("Gets or sets whether the side image visible when Checked=false should be scaled to fit")]
        public bool OffSideScaleImageToFit
        {
            get
            {
                return this._offSideScaleImage;
            }
            set
            {
                if (value != this._offSideScaleImage)
                {
                    this._offSideScaleImage = value;
                    this.Refresh();
                }
            }
        }

        [Category("Appearance")]
        [Bindable(false)]
        [DefaultValue(typeof(ToggleSwitchAlignment), "Center")]
        [Description("Gets or sets how the text or side image visible when Checked=false should be aligned")]
        public ToggleSwitchAlignment OffSideAlignment
        {
            get
            {
                return this._offSideAlignment;
            }
            set
            {
                if (value != this._offSideAlignment)
                {
                    this._offSideAlignment = value;
                    this.Refresh();
                }
            }
        }

        [Category("Appearance")]
        [Description("Gets or sets the button image when Checked=false and ButtonImage is not set")]
        [DefaultValue(null)]
        [Bindable(false)]
        public Image OffButtonImage
        {
            get
            {
                return this._offButtonImage;
            }
            set
            {
                if (value != this._offButtonImage)
                {
                    this._offButtonImage = value;
                    this.Refresh();
                }
            }
        }

        [Category("Behavior")]
        [Bindable(false)]
        [Description("Gets or sets whether the button image visible when Checked=false should be scaled to fit")]
        [DefaultValue(false)]
        public bool OffButtonScaleImageToFit
        {
            get
            {
                return this._offButtonScaleImage;
            }
            set
            {
                if (value != this._offButtonScaleImage)
                {
                    this._offButtonScaleImage = value;
                    this.Refresh();
                }
            }
        }

        [Bindable(false)]
        [Category("Appearance")]
        [DefaultValue(typeof(ToggleSwitchButtonAlignment), "Center")]
        [Description("Gets or sets how the button image visible when Checked=false should be aligned")]
        public ToggleSwitchButtonAlignment OffButtonAlignment
        {
            get
            {
                return this._offButtonAlignment;
            }
            set
            {
                if (value != this._offButtonAlignment)
                {
                    this._offButtonAlignment = value;
                    this.Refresh();
                }
            }
        }

        [Description("Gets or sets the forecolor of the text when Checked=true")]
        [DefaultValue(typeof(Color), "Black")]
        [Bindable(false)]
        [Category("Appearance")]
        public Color OnForeColor
        {
            get
            {
                return this._onForeColor;
            }
            set
            {
                if (value != this._onForeColor)
                {
                    this._onForeColor = value;
                    this.Refresh();
                }
            }
        }

        [Category("Appearance")]
        [Description("Gets or sets the font of the text when Checked=true")]
        [DefaultValue(typeof(Font), "Microsoft Sans Serif, 8,25pt")]
        [Bindable(false)]
        public Font OnFont
        {
            get
            {
                return this._onFont;
            }
            set
            {
                if (!value.Equals(this._onFont))
                {
                    this._onFont = value;
                    this.Refresh();
                }
            }
        }

        [Bindable(false)]
        [Category("Appearance")]
        [DefaultValue("")]
        [Description("Gets or sets the text when Checked=true")]
        public string OnText
        {
            get
            {
                return this._onText;
            }
            set
            {
                if (value != this._onText)
                {
                    this._onText = value;
                    this.Refresh();
                }
            }
        }

        [Category("Appearance")]
        [DefaultValue(null)]
        [Bindable(false)]
        [Description("Gets or sets the side image visible when Checked=true - Note: Settings the OnSideImage overrules the OnText property. Only the image will be shown.")]
        public Image OnSideImage
        {
            get
            {
                return this._onSideImage;
            }
            set
            {
                if (value != this._onSideImage)
                {
                    this._onSideImage = value;
                    this.Refresh();
                }
            }
        }

        [Category("Behavior")]
        [Description("Gets or sets whether the side image visible when Checked=true should be scaled to fit")]
        [Bindable(false)]
        [DefaultValue(false)]
        public bool OnSideScaleImageToFit
        {
            get
            {
                return this._onSideScaleImage;
            }
            set
            {
                if (value != this._onSideScaleImage)
                {
                    this._onSideScaleImage = value;
                    this.Refresh();
                }
            }
        }

        [DefaultValue(null)]
        [Bindable(false)]
        [Description("Gets or sets the button image")]
        [Category("Appearance")]
        public Image ButtonImage
        {
            get
            {
                return this._buttonImage;
            }
            set
            {
                if (value != this._buttonImage)
                {
                    this._buttonImage = value;
                    this.Refresh();
                }
            }
        }

        [DefaultValue(false)]
        [Bindable(false)]
        [Description("Gets or sets whether the button image should be scaled to fit")]
        [Category("Behavior")]
        public bool ButtonScaleImageToFit
        {
            get
            {
                return this._buttonScaleImage;
            }
            set
            {
                if (value != this._buttonScaleImage)
                {
                    this._buttonScaleImage = value;
                    this.Refresh();
                }
            }
        }

        [Description("Gets or sets how the button image should be aligned")]
        [Category("Appearance")]
        [Bindable(false)]
        [DefaultValue(typeof(ToggleSwitchButtonAlignment), "Center")]
        public ToggleSwitchButtonAlignment ButtonAlignment
        {
            get
            {
                return this._buttonAlignment;
            }
            set
            {
                if (value != this._buttonAlignment)
                {
                    this._buttonAlignment = value;
                    this.Refresh();
                }
            }
        }

        [Description("Gets or sets how the text or side image visible when Checked=true should be aligned")]
        [DefaultValue(typeof(ToggleSwitchAlignment), "Center")]
        [Category("Appearance")]
        [Bindable(false)]
        public ToggleSwitchAlignment OnSideAlignment
        {
            get
            {
                return this._onSideAlignment;
            }
            set
            {
                if (value != this._onSideAlignment)
                {
                    this._onSideAlignment = value;
                    this.Refresh();
                }
            }
        }

        [Category("Appearance")]
        [Bindable(false)]
        [Description("Gets or sets the button image visible when Checked=true and ButtonImage is not set")]
        [DefaultValue(null)]
        public Image OnButtonImage
        {
            get
            {
                return this._onButtonImage;
            }
            set
            {
                if (value != this._onButtonImage)
                {
                    this._onButtonImage = value;
                    this.Refresh();
                }
            }
        }

        [Category("Behavior")]
        [Description("Gets or sets whether the button image visible when Checked=true should be scaled to fit")]
        [DefaultValue(false)]
        [Bindable(false)]
        public bool OnButtonScaleImageToFit
        {
            get
            {
                return this._onButtonScaleImage;
            }
            set
            {
                if (value != this._onButtonScaleImage)
                {
                    this._onButtonScaleImage = value;
                    this.Refresh();
                }
            }
        }

        [Category("Appearance")]
        [Description("Gets or sets how the button image visible when Checked=true should be aligned")]
        [DefaultValue(typeof(ToggleSwitchButtonAlignment), "Center")]
        [Bindable(false)]
        public ToggleSwitchButtonAlignment OnButtonAlignment
        {
            get
            {
                return this._onButtonAlignment;
            }
            set
            {
                if (value != this._onButtonAlignment)
                {
                    this._onButtonAlignment = value;
                    this.Refresh();
                }
            }
        }

        [Description("Gets or sets whether the toggle change should be animated or not")]
        [Bindable(false)]
        [Category("Behavior")]
        [DefaultValue(true)]
        public bool UseAnimation
        {
            get
            {
                return this._useAnimation;
            }
            set
            {
                this._useAnimation = value;
            }
        }

        [DefaultValue(1)]
        [Bindable(false)]
        [Description("Gets or sets the interval in ms between animation frames")]
        [Category("Behavior")]
        public int AnimationInterval
        {
            get
            {
                return this._animationInterval;
            }
            set
            {
                if (value <= 0)
                {
                    throw new ArgumentOutOfRangeException("AnimationInterval must larger than zero!");
                }
                this._animationInterval = value;
            }
        }

        [Category("Behavior")]
        [DefaultValue(10)]
        [Bindable(false)]
        [Description("Gets or sets the step in pixes the button shouldbe moved between each animation interval")]
        public int AnimationStep
        {
            get
            {
                return this._animationStep;
            }
            set
            {
                if (value <= 0)
                {
                    throw new ArgumentOutOfRangeException("AnimationStep must larger than zero!");
                }
                this._animationStep = value;
            }
        }

        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public new string Text
        {
            get
            {
                return "";
            }
            set
            {
                base.Text = "";
            }
        }

        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public new Color ForeColor
        {
            get
            {
                return Color.Black;
            }
            set
            {
                base.ForeColor = Color.Black;
            }
        }

        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public new Font Font
        {
            get
            {
                return base.Font;
            }
            set
            {
                base.Font = new Font(base.Font, FontStyle.Regular);
            }
        }

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        [Browsable(false)]
        internal bool IsButtonHovered
        {
            get
            {
                if (this._isButtonHovered)
                {
                    return !this._isButtonPressed;
                }
                return false;
            }
        }

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        [Browsable(false)]
        internal bool IsButtonPressed => this._isButtonPressed;

        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        internal bool IsLeftSideHovered
        {
            get
            {
                if (this._isLeftFieldHovered)
                {
                    return !this._isLeftFieldPressed;
                }
                return false;
            }
        }

        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        internal bool IsLeftSidePressed => this._isLeftFieldPressed;

        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        internal bool IsRightSideHovered
        {
            get
            {
                if (this._isRightFieldHovered)
                {
                    return !this._isRightFieldPressed;
                }
                return false;
            }
        }

        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        internal bool IsRightSidePressed => this._isRightFieldPressed;

        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        internal int ButtonValue
        {
            get
            {
                if (!this._animating && !this._moving)
                {
                    if (this._checked)
                    {
                        return base.Width - this._renderer.GetButtonWidth();
                    }
                    return 0;
                }
                return this._buttonValue;
            }
            set
            {
                if (value != this._buttonValue)
                {
                    this._buttonValue = value;
                    this.Refresh();
                }
            }
        }

        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        internal bool IsButtonOnLeftSide => this.ButtonValue <= 0;

        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        internal bool IsButtonOnRightSide => this.ButtonValue >= base.Width - this._renderer.GetButtonWidth();

        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        internal bool IsButtonMovingLeft
        {
            get
            {
                if (this._animating && !this.IsButtonOnLeftSide)
                {
                    return !this._animationResult;
                }
                return false;
            }
        }

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        [Browsable(false)]
        internal bool IsButtonMovingRight
        {
            get
            {
                if (this._animating && !this.IsButtonOnRightSide)
                {
                    return this._animationResult;
                }
                return false;
            }
        }

        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        internal bool AnimationResult => this._animationResult;

        protected override Size DefaultSize => new Size(50, 19);

        [Description("Raised when the ToggleSwitch has changed state")]
        public event CheckedChangedDelegate CheckedChanged;

        [Description("Raised when the ToggleSwitch renderer is changed")]
        public event BeforeRenderingDelegate BeforeRendering;

        public ToggleSwitch()
        {
            base.SetStyle(ControlStyles.UserPaint | ControlStyles.ResizeRedraw | ControlStyles.SupportsTransparentBackColor | ControlStyles.AllPaintingInWmPaint | ControlStyles.DoubleBuffer | ControlStyles.OptimizedDoubleBuffer, value: true);
            this.OnFont = base.Font;
            this.OffFont = base.Font;
            this.SetRenderer(new ToggleSwitchMetroRenderer());
            this._animationTimer.Enabled = false;
            this._animationTimer.Interval = this._animationInterval;
            this._animationTimer.Tick += new EventHandler(AnimationTimer_Tick);
        }

        public void SetRenderer(ToggleSwitchRendererBase renderer)
        {
            renderer.SetToggleSwitch(this);
            this._renderer = renderer;
            if (this._renderer != null)
            {
                this.Refresh();
            }
        }

        protected override void OnPaintBackground(PaintEventArgs pevent)
        {
            pevent.Graphics.ResetClip();
            base.OnPaintBackground(pevent);
            if (this._renderer != null)
            {
                this._renderer.RenderBackground(pevent);
            }
        }

        protected override void OnPaint(PaintEventArgs pevent)
        {
            pevent.Graphics.ResetClip();
            base.OnPaint(pevent);
            if (this._renderer != null)
            {
                if (this.BeforeRendering != null)
                {
                    this.BeforeRendering(this, new BeforeRenderingEventArgs(this._renderer));
                }
                this._renderer.RenderControl(pevent);
            }
        }

        protected override void OnMouseMove(MouseEventArgs mevent)
        {
            this._lastMouseEventArgs = mevent;
            int buttonWidth = this._renderer.GetButtonWidth();
            Rectangle buttonRectangle = this._renderer.GetButtonRectangle(buttonWidth);
            if (this._moving)
            {
                int num = this._xValue + (mevent.Location.X - this._xOffset);
                if (num < 0)
                {
                    num = 0;
                }
                if (num > base.Width - buttonWidth)
                {
                    num = base.Width - buttonWidth;
                }
                this.ButtonValue = num;
                this.Refresh();
                return;
            }
            if (buttonRectangle.Contains(mevent.Location))
            {
                this._isButtonHovered = true;
                this._isLeftFieldHovered = false;
                this._isRightFieldHovered = false;
            }
            else if (mevent.Location.X > buttonRectangle.X + buttonRectangle.Width)
            {
                this._isButtonHovered = false;
                this._isLeftFieldHovered = false;
                this._isRightFieldHovered = true;
            }
            else if (mevent.Location.X < buttonRectangle.X)
            {
                this._isButtonHovered = false;
                this._isLeftFieldHovered = true;
                this._isRightFieldHovered = false;
            }
            this.Refresh();
        }

        protected override void OnMouseDown(MouseEventArgs mevent)
        {
            if (!this._animating && this.AllowUserChange)
            {
                int buttonWidth = this._renderer.GetButtonWidth();
                Rectangle buttonRectangle = this._renderer.GetButtonRectangle(buttonWidth);
                this._savedButtonValue = this.ButtonValue;
                if (buttonRectangle.Contains(mevent.Location))
                {
                    this._isButtonPressed = true;
                    this._isLeftFieldPressed = false;
                    this._isRightFieldPressed = false;
                    this._moving = true;
                    this._xOffset = mevent.Location.X;
                    this._buttonValue = buttonRectangle.X;
                    this._xValue = this.ButtonValue;
                }
                else if (mevent.Location.X > buttonRectangle.X + buttonRectangle.Width)
                {
                    this._isButtonPressed = false;
                    this._isLeftFieldPressed = false;
                    this._isRightFieldPressed = true;
                }
                else if (mevent.Location.X < buttonRectangle.X)
                {
                    this._isButtonPressed = false;
                    this._isLeftFieldPressed = true;
                    this._isRightFieldPressed = false;
                }
                this.Refresh();
            }
        }

        protected override void OnMouseUp(MouseEventArgs mevent)
        {
            if (this._animating || !this.AllowUserChange)
            {
                return;
            }
            int buttonWidth = this._renderer.GetButtonWidth();
            bool isLeftSidePressed = this.IsLeftSidePressed;
            bool isRightSidePressed = this.IsRightSidePressed;
            this._isButtonPressed = false;
            this._isLeftFieldPressed = false;
            this._isRightFieldPressed = false;
            if (this._moving)
            {
                int num = (int)(100.0 * (double)this.ButtonValue / ((double)base.Width - (double)buttonWidth));
                if (this._checked)
                {
                    if (num <= 100 - this._thresholdPercentage)
                    {
                        this._animationTarget = 0;
                        this.BeginAnimation(checkedValue: false);
                    }
                    else if (this.ToggleOnButtonClick && this._savedButtonValue == this.ButtonValue)
                    {
                        this._animationTarget = 0;
                        this.BeginAnimation(checkedValue: false);
                    }
                    else
                    {
                        this._animationTarget = base.Width - buttonWidth;
                        this.BeginAnimation(checkedValue: true);
                    }
                }
                else if (num >= this._thresholdPercentage)
                {
                    this._animationTarget = base.Width - buttonWidth;
                    this.BeginAnimation(checkedValue: true);
                }
                else if (this.ToggleOnButtonClick && this._savedButtonValue == this.ButtonValue)
                {
                    this._animationTarget = base.Width - buttonWidth;
                    this.BeginAnimation(checkedValue: true);
                }
                else
                {
                    this._animationTarget = 0;
                    this.BeginAnimation(checkedValue: false);
                }
                this._moving = false;
            }
            else
            {
                if (this.IsButtonOnRightSide)
                {
                    this._buttonValue = base.Width - buttonWidth;
                    this._animationTarget = 0;
                }
                else
                {
                    this._buttonValue = 0;
                    this._animationTarget = base.Width - buttonWidth;
                }
                if (isLeftSidePressed && this.ToggleOnSideClick)
                {
                    this.SetValueInternal(checkedValue: false);
                }
                else if (isRightSidePressed && this.ToggleOnSideClick)
                {
                    this.SetValueInternal(checkedValue: true);
                }
                this.Refresh();
            }
        }

        protected override void OnMouseLeave(EventArgs eventargs)
        {
            this._isButtonHovered = false;
            this._isLeftFieldHovered = false;
            this._isRightFieldHovered = false;
            this._isButtonPressed = false;
            this._isLeftFieldPressed = false;
            this._isRightFieldPressed = false;
            this.Refresh();
        }

        protected override void OnEnabledChanged(EventArgs eventArgs_0)
        {
            base.OnEnabledChanged(eventArgs_0);
            this.Refresh();
        }

        protected override void OnRegionChanged(EventArgs eventArgs_0)
        {
            base.OnRegionChanged(eventArgs_0);
            this.Refresh();
        }

        protected override void OnSizeChanged(EventArgs eventArgs_0)
        {
            if (this._animationTarget > 0)
            {
                int buttonWidth = this._renderer.GetButtonWidth();
                this._animationTarget = base.Width - buttonWidth;
            }
            base.OnSizeChanged(eventArgs_0);
        }

        private void SetValueInternal(bool checkedValue)
        {
            if (checkedValue != this._checked)
            {
                while (this._animating)
                {
                    Application.DoEvents();
                }
                this.BeginAnimation(checkedValue);
            }
        }

        private void BeginAnimation(bool checkedValue)
        {
            this._animating = true;
            this._animationResult = checkedValue;
            if (this._animationTimer != null && this._useAnimation)
            {
                this._animationTimer.Interval = this._animationInterval;
                this._animationTimer.Enabled = true;
            }
            else
            {
                this.AnimationComplete();
            }
        }

        private void AnimationTimer_Tick(object sender, EventArgs e)
        {
            this._animationTimer.Enabled = false;
            bool flag = false;
            if (this.IsButtonMovingRight)
            {
                int num = this.ButtonValue + this._animationStep;
                if (num > this._animationTarget)
                {
                    num = this._animationTarget;
                }
                this.ButtonValue = num;
                flag = this.ButtonValue >= this._animationTarget;
            }
            else
            {
                int num = this.ButtonValue - this._animationStep;
                if (num < this._animationTarget)
                {
                    num = this._animationTarget;
                }
                this.ButtonValue = num;
                flag = this.ButtonValue <= this._animationTarget;
            }
            if (flag)
            {
                this.AnimationComplete();
            }
            else
            {
                this._animationTimer.Enabled = true;
            }
        }

        private void AnimationComplete()
        {
            this._animating = false;
            this._moving = false;
            this._checked = this._animationResult;
            this._isButtonHovered = false;
            this._isButtonPressed = false;
            this._isLeftFieldHovered = false;
            this._isLeftFieldPressed = false;
            this._isRightFieldHovered = false;
            this._isRightFieldPressed = false;
            this.Refresh();
            if (this.CheckedChanged != null)
            {
                this.CheckedChanged(this, new EventArgs());
            }
            if (this._lastMouseEventArgs != null)
            {
                this.OnMouseMove(this._lastMouseEventArgs);
            }
            this._lastMouseEventArgs = null;
        }
    }
}
