using System;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Design;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace BirdBrainmofo.RJCodeAdvance.RJControls
{
	[DefaultEvent("OnSelectedIndexChanged")]
	public class RJComboBox : UserControl
	{
		private Color backColor = Color.WhiteSmoke;

		private Color iconColor = Color.MediumSlateBlue;

		private Color listBackColor = Color.FromArgb(230, 228, 245);

		private Color listTextColor = Color.DimGray;

		private Color borderColor = Color.MediumSlateBlue;

		private int borderSize = 1;

		private ComboBox cmbList;

		private Label lblText;

		private Button btnIcon;

		[Category("RJ Code - Appearance")]
		public new Color BackColor
		{
			get
			{
				return this.backColor;
			}
			set
			{
				this.backColor = value;
				this.lblText.BackColor = this.backColor;
				this.btnIcon.BackColor = this.backColor;
			}
		}

		[Category("RJ Code - Appearance")]
		public Color IconColor
		{
			get
			{
				return this.iconColor;
			}
			set
			{
				this.iconColor = value;
				this.btnIcon.Invalidate();
			}
		}

		[Category("RJ Code - Appearance")]
		public Color ListBackColor
		{
			get
			{
				return this.listBackColor;
			}
			set
			{
				this.listBackColor = value;
				this.cmbList.BackColor = this.listBackColor;
			}
		}

		[Category("RJ Code - Appearance")]
		public Color ListTextColor
		{
			get
			{
				return this.listTextColor;
			}
			set
			{
				this.listTextColor = value;
				this.cmbList.ForeColor = this.listTextColor;
			}
		}

		[Category("RJ Code - Appearance")]
		public Color BorderColor
		{
			get
			{
				return this.borderColor;
			}
			set
			{
				this.borderColor = value;
				base.BackColor = this.borderColor;
			}
		}

		[Category("RJ Code - Appearance")]
		public int BorderSize
		{
			get
			{
				return this.borderSize;
			}
			set
			{
				this.borderSize = value;
				base.Padding = new Padding(this.borderSize);
				this.AdjustComboBoxDimensions();
			}
		}

		[Category("RJ Code - Appearance")]
		public override Color ForeColor
		{
			get
			{
				return base.ForeColor;
			}
			set
			{
				base.ForeColor = value;
				this.lblText.ForeColor = value;
			}
		}

		[Category("RJ Code - Appearance")]
		public override Font Font
		{
			get
			{
				return base.Font;
			}
			set
			{
				base.Font = value;
				this.lblText.Font = value;
				this.cmbList.Font = value;
			}
		}

		[Category("RJ Code - Appearance")]
		public string Texts
		{
			get
			{
				return this.lblText.Text;
			}
			set
			{
				this.lblText.Text = value;
			}
		}

		[Category("RJ Code - Appearance")]
		public ComboBoxStyle DropDownStyle
		{
			get
			{
				return this.cmbList.DropDownStyle;
			}
			set
			{
				if (this.cmbList.DropDownStyle != 0)
				{
					this.cmbList.DropDownStyle = value;
				}
			}
		}

		[Editor("System.Windows.Forms.Design.ListControlStringCollectionEditor, System.Design, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a", typeof(UITypeEditor))]
		[MergableProperty(false)]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
		[Localizable(true)]
		[Category("RJ Code - Data")]
		public ComboBox.ObjectCollection Items => this.cmbList.Items;

		[DefaultValue(null)]
		[Category("RJ Code - Data")]
		[AttributeProvider(typeof(IListSource))]
		public object DataSource
		{
			get
			{
				return this.cmbList.DataSource;
			}
			set
			{
				this.cmbList.DataSource = value;
			}
		}

		[Category("RJ Code - Data")]
		[Localizable(true)]
		[Editor("System.Windows.Forms.Design.ListControlStringCollectionEditor, System.Design, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a", typeof(UITypeEditor))]
		[EditorBrowsable(EditorBrowsableState.Always)]
		[Browsable(true)]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
		public AutoCompleteStringCollection AutoCompleteCustomSource
		{
			get
			{
				return this.cmbList.AutoCompleteCustomSource;
			}
			set
			{
				this.cmbList.AutoCompleteCustomSource = value;
			}
		}

		[EditorBrowsable(EditorBrowsableState.Always)]
		[Category("RJ Code - Data")]
		[Browsable(true)]
		[DefaultValue(AutoCompleteSource.None)]
		public AutoCompleteSource AutoCompleteSource
		{
			get
			{
				return this.cmbList.AutoCompleteSource;
			}
			set
			{
				this.cmbList.AutoCompleteSource = value;
			}
		}

		[Category("RJ Code - Data")]
		[DefaultValue(AutoCompleteMode.None)]
		[EditorBrowsable(EditorBrowsableState.Always)]
		[Browsable(true)]
		public AutoCompleteMode AutoCompleteMode
		{
			get
			{
				return this.cmbList.AutoCompleteMode;
			}
			set
			{
				this.cmbList.AutoCompleteMode = value;
			}
		}

		[Bindable(true)]
		[Category("RJ Code - Data")]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		[Browsable(false)]
		public object SelectedItem
		{
			get
			{
				return this.cmbList.SelectedItem;
			}
			set
			{
				this.cmbList.SelectedItem = value;
			}
		}

		[Browsable(false)]
		[Category("RJ Code - Data")]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		public int SelectedIndex
		{
			get
			{
				return this.cmbList.SelectedIndex;
			}
			set
			{
				this.cmbList.SelectedIndex = value;
			}
		}

		[Category("RJ Code - Data")]
		[DefaultValue("")]
		[TypeConverter("System.Windows.Forms.Design.DataMemberFieldConverter, System.Design, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a")]
		[Editor("System.Windows.Forms.Design.DataMemberFieldEditor, System.Design, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a", typeof(UITypeEditor))]
		public string DisplayMember
		{
			get
			{
				return this.cmbList.DisplayMember;
			}
			set
			{
				this.cmbList.DisplayMember = value;
			}
		}

		[DefaultValue("")]
		[Category("RJ Code - Data")]
		[Editor("System.Windows.Forms.Design.DataMemberFieldEditor, System.Design, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a", typeof(UITypeEditor))]
		public string ValueMember
		{
			get
			{
				return this.cmbList.ValueMember;
			}
			set
			{
				this.cmbList.ValueMember = value;
			}
		}

		public event EventHandler OnSelectedIndexChanged;

		public RJComboBox()
		{
			this.cmbList = new ComboBox();
			this.lblText = new Label();
			this.btnIcon = new Button();
			base.SuspendLayout();
			this.cmbList.BackColor = this.listBackColor;
			this.cmbList.Font = new Font(this.Font.Name, 10f);
			this.cmbList.ForeColor = this.listTextColor;
			this.cmbList.SelectedIndexChanged += new EventHandler(ComboBox_SelectedIndexChanged);
			this.cmbList.TextChanged += new EventHandler(ComboBox_TextChanged);
			this.btnIcon.Dock = DockStyle.Right;
			this.btnIcon.FlatStyle = FlatStyle.Flat;
			this.btnIcon.FlatAppearance.BorderSize = 0;
			this.btnIcon.BackColor = this.backColor;
			this.btnIcon.Size = new Size(30, 30);
			this.btnIcon.Cursor = Cursors.Hand;
			this.btnIcon.Click += new EventHandler(Icon_Click);
			this.btnIcon.Paint += new PaintEventHandler(Icon_Paint);
			this.lblText.Dock = DockStyle.Fill;
			this.lblText.AutoSize = false;
			this.lblText.BackColor = this.backColor;
			this.lblText.TextAlign = ContentAlignment.MiddleLeft;
			this.lblText.Padding = new Padding(8, 0, 0, 0);
			this.lblText.Font = new Font(this.Font.Name, 10f);
			this.lblText.Click += new EventHandler(Surface_Click);
			this.lblText.MouseEnter += new EventHandler(Surface_MouseEnter);
			this.lblText.MouseLeave += new EventHandler(Surface_MouseLeave);
			base.Controls.Add(this.lblText);
			base.Controls.Add(this.btnIcon);
			base.Controls.Add(this.cmbList);
			this.MinimumSize = new Size(200, 30);
			base.Size = new Size(200, 30);
			this.ForeColor = Color.DimGray;
			base.Padding = new Padding(this.borderSize);
			this.Font = new Font(this.Font.Name, 10f);
			base.BackColor = this.borderColor;
			base.ResumeLayout();
			this.AdjustComboBoxDimensions();
		}

		private void AdjustComboBoxDimensions()
		{
			this.cmbList.Width = this.lblText.Width;
			this.cmbList.Location = new Point
			{
				X = base.Width - base.Padding.Right - this.cmbList.Width,
				Y = this.lblText.Bottom - this.cmbList.Height
			};
		}

		private void ComboBox_SelectedIndexChanged(object sender, EventArgs e)
		{
			if (this.OnSelectedIndexChanged != null)
			{
				this.OnSelectedIndexChanged(sender, e);
			}
			this.lblText.Text = this.cmbList.Text;
		}

		private void Icon_Paint(object sender, PaintEventArgs e)
		{
			int num = 14;
			Rectangle rectangle = new Rectangle((this.btnIcon.Width - 14) / 2, (this.btnIcon.Height - 6) / 2, 14, 6);
			Graphics graphics = e.Graphics;
			using GraphicsPath graphicsPath = new GraphicsPath();
			using Pen pen = new Pen(this.iconColor, 2f);
			graphics.SmoothingMode = SmoothingMode.AntiAlias;
			graphicsPath.AddLine(rectangle.X, rectangle.Y, rectangle.X + num / 2, rectangle.Bottom);
			graphicsPath.AddLine(rectangle.X + num / 2, rectangle.Bottom, rectangle.Right, rectangle.Y);
			graphics.DrawPath(pen, graphicsPath);
		}

		private void Icon_Click(object sender, EventArgs e)
		{
			this.cmbList.Select();
			this.cmbList.DroppedDown = true;
		}

		private void Surface_Click(object sender, EventArgs e)
		{
			this.OnClick(e);
			this.cmbList.Select();
			if (this.cmbList.DropDownStyle == ComboBoxStyle.DropDownList)
			{
				this.cmbList.DroppedDown = true;
			}
		}

		private void ComboBox_TextChanged(object sender, EventArgs e)
		{
			this.lblText.Text = this.cmbList.Text;
		}

		private void Surface_MouseLeave(object sender, EventArgs e)
		{
			this.OnMouseLeave(e);
		}

		private void Surface_MouseEnter(object sender, EventArgs e)
		{
			this.OnMouseEnter(e);
		}

		protected override void OnResize(EventArgs e)
		{
			base.OnResize(e);
			this.AdjustComboBoxDimensions();
		}
	}
}
