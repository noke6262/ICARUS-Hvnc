using System;
using System.IO;
using Microsoft.VisualBasic.CompilerServices;

namespace DLL.Functions;

public class GetDirSize
{
	private long TotalSize;

	public GetDirSize()
	{
		this.TotalSize = 0L;
	}

	public long GetDirSizez(string RootFolder)
	{
		int num = 0;
		long result;
		try
		{
			ProjectData.ClearProjectError();
			DirectoryInfo directoryInfo = new DirectoryInfo(RootFolder);
			FileInfo[] files = directoryInfo.GetFiles();
			for (int i = 0; i < files.Length; i++)
			{
				checked
				{
					this.TotalSize += files[i].Length;
				}
			}
			DirectoryInfo[] directories = directoryInfo.GetDirectories();
			for (int i = 0; i < directories.Length; i++)
			{
				this.GetDirSizez(directories[i].FullName);
			}
			result = this.TotalSize;
		}
		catch (Exception projectError)
		{
			ProjectData.SetProjectError(projectError);
			result = 0L;
		}
		if (num != 0)
		{
			ProjectData.ClearProjectError();
		}
		return result;
	}
}
