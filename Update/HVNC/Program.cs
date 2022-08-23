using System;
using System.Windows.Forms;

namespace BirdBrainmofo.HVNC
{
	internal static class Program
	{
		[STAThread]
		internal static void Main()
		{
			Application.EnableVisualStyles();
			Application.SetCompatibleTextRenderingDefault(defaultValue: false);
			Application.Run(new Manager());
		}
	}
}
