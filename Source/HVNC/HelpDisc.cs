// ICARUS.HVNC.HelpDisc

using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace ICARUS.HVNC
{
    public class HelpDisc : Form
    {
        private IContainer components;

        private PrimeTheme primeTheme1;

        private Label label3;

        private PictureBox pictureBox1;

        private StudioButton studioButton5;
        private Label label2;
        private Panel panel1;
        private Label label1;

        public HelpDisc()
        {
            InitializeComponent();
        }

        private void studioButton5_Click(object sender, EventArgs e)
        {
            Close();
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(HelpDisc));
            this.primeTheme1 = new ICARUS.PrimeTheme();
            this.label1 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.studioButton5 = new ICARUS.StudioButton();
            this.label2 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.primeTheme1.SuspendLayout();
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
            this.primeTheme1.Controls.Add(this.panel1);
            this.primeTheme1.Controls.Add(this.label2);
            this.primeTheme1.Controls.Add(this.label1);
            this.primeTheme1.Controls.Add(this.label3);
            this.primeTheme1.Controls.Add(this.pictureBox1);
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
            this.primeTheme1.Size = new System.Drawing.Size(244, 425);
            this.primeTheme1.SmartBounds = true;
            this.primeTheme1.TabIndex = 0;
            this.primeTheme1.TransparencyKey = System.Drawing.Color.Fuchsia;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(49, 66);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(147, 48);
            this.label1.TabIndex = 45;
            this.label1.Text = "1. Create a Channel\r\n2. Create a Webhook\r\n3. Get Webhook url";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.Black;
            this.label3.Location = new System.Drawing.Point(36, 13);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(155, 16);
            this.label3.TabIndex = 44;
            this.label3.Text = "Discord Stealer Help";
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(0, 0);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(51, 48);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 43;
            this.pictureBox1.TabStop = false;
            // 
            // studioButton5
            // 
            this.studioButton5.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.studioButton5.BackColor = System.Drawing.Color.Transparent;
            bloom11.Name = "DownGradient1";
            bloom11.Value = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(65)))), ((int)(((byte)(95)))));
            bloom12.Name = "DownGradient2";
            bloom12.Value = System.Drawing.Color.FromArgb(((int)(((byte)(65)))), ((int)(((byte)(85)))), ((int)(((byte)(115)))));
            bloom13.Name = "NoneGradient1";
            bloom13.Value = System.Drawing.Color.FromArgb(((int)(((byte)(65)))), ((int)(((byte)(85)))), ((int)(((byte)(115)))));
            bloom14.Name = "NoneGradient2";
            bloom14.Value = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(65)))), ((int)(((byte)(95)))));
            bloom15.Name = "Shine1";
            bloom15.Value = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            bloom16.Name = "Shine2A";
            bloom16.Value = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            bloom17.Name = "Shine2B";
            bloom17.Value = System.Drawing.Color.Transparent;
            bloom18.Name = "Shine3";
            bloom18.Value = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            bloom19.Name = "TextShade";
            bloom19.Value = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            bloom20.Name = "Text";
            bloom20.Value = System.Drawing.Color.White;
            bloom21.Name = "Glow";
            bloom21.Value = System.Drawing.Color.FromArgb(((int)(((byte)(10)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            bloom22.Name = "Border";
            bloom22.Value = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(40)))), ((int)(((byte)(70)))));
            bloom23.Name = "Corners";
            bloom23.Value = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(40)))), ((int)(((byte)(70)))));
            this.studioButton5.Colors = new ICARUS.HVNC.Bloom[] {
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
        bloom21,
        bloom22,
        bloom23};
            this.studioButton5.Customization = "X0Et/3NVQf9zVUH/X0Et/////x7///8e////AP///xQAAAAy/////////wpGKBT/RigU/w==";
            this.studioButton5.Font = new System.Drawing.Font("Verdana", 8F);
            this.studioButton5.Image = null;
            this.studioButton5.Location = new System.Drawing.Point(219, -6);
            this.studioButton5.Name = "studioButton5";
            this.studioButton5.NoRounding = false;
            this.studioButton5.Size = new System.Drawing.Size(13, 30);
            this.studioButton5.TabIndex = 42;
            this.studioButton5.Transparent = true;
            this.studioButton5.Click += new System.EventHandler(this.studioButton5_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Font = new System.Drawing.Font("Verdana", 8F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))));
            this.label2.Location = new System.Drawing.Point(36, 147);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(172, 130);
            this.label2.TabIndex = 46;
            this.label2.Text = resources.GetString("label2.Text");
            // 
            // panel1
            // 
            this.panel1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("panel1.BackgroundImage")));
            this.panel1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.panel1.Location = new System.Drawing.Point(39, 280);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(179, 129);
            this.panel1.TabIndex = 47;
            // 
            // HelpDisc
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(244, 425);
            this.Controls.Add(this.primeTheme1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "HelpDisc";
            this.Text = "HelpDisc";
            this.TransparencyKey = System.Drawing.Color.Fuchsia;
            this.primeTheme1.ResumeLayout(false);
            this.primeTheme1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }
    }
}