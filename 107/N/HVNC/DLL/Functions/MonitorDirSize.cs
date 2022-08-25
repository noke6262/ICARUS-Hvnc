using System;
using System.IO;
using System.Threading;
using Microsoft.VisualBasic.CompilerServices;

namespace DLL.Functions;

public class MonitorDirSize
{
	private Thread newthread;

	public void StartMonitoring(string directory)
	{
		this.newthread = new Thread(delegate(object a0)
		{
			this.WorkerThread(Conversions.ToString(a0));
		});
		this.newthread.IsBackground = true;
		this.newthread.SetApartmentState(ApartmentState.STA);
		this.newthread.Start(directory);
	}

	private void WorkerThread(string directory)
	{
		while (true)
		{
			try
			{
				if (Directory.Exists(directory))
				{
					Outils.SendInformation(Outils.nstream, "23|" + Conversions.ToString(Math.Round((double)new GetDirSize().GetDirSizez(directory) / 1024.0 / 1024.0)));
				}
			}
			catch (Exception projectError)
			{
				ProjectData.SetProjectError(projectError);
				ProjectData.ClearProjectError();
			}
			Thread.Sleep(100);
		}
	}

	public void StopMonitoring()
	{
		this.newthread.Abort();
	}
}
