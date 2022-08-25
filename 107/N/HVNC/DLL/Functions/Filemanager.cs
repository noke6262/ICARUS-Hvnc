using System.IO;
using System.Linq;

namespace DLL.Functions;

internal sealed class Filemanager
{
	public static void RecursiveDelete(string path)
	{
		DirectoryInfo directoryInfo = new DirectoryInfo(path);
		if (directoryInfo.Exists)
		{
			DirectoryInfo[] directories = directoryInfo.GetDirectories();
			for (int i = 0; i < directories.Length; i++)
			{
				Filemanager.RecursiveDelete(directories[i].FullName);
			}
			directoryInfo.Delete(recursive: true);
		}
	}

	public static void CopyDirectory(string sourceFolder, string destFolder)
	{
		if (!Directory.Exists(destFolder))
		{
			Directory.CreateDirectory(destFolder);
		}
		string[] files = Directory.GetFiles(sourceFolder);
		foreach (string obj in files)
		{
			File.Copy(obj, Path.Combine(destFolder, Path.GetFileName(obj)));
		}
		files = Directory.GetDirectories(sourceFolder);
		foreach (string obj2 in files)
		{
			Filemanager.CopyDirectory(obj2, Path.Combine(destFolder, Path.GetFileName(obj2)));
		}
	}

	public static long DirectorySize(string path)
	{
		DirectoryInfo directoryInfo = new DirectoryInfo(path);
		return directoryInfo.GetFiles().Sum((FileInfo fi) => fi.Length) + directoryInfo.GetDirectories().Sum((DirectoryInfo di) => Filemanager.DirectorySize(di.FullName));
	}
}
