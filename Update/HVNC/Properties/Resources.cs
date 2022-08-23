using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Globalization;
using System.Resources;
using System.Runtime.CompilerServices;

namespace BirdBrainmofo.HVNC.Properties
{
	[DebuggerNonUserCode]
	[CompilerGenerated]
	[GeneratedCode("System.Resources.Tools.StronglyTypedResourceBuilder", "16.0.0.0")]
	internal class Resources
	{
		private static ResourceManager resourceMan;

		private static CultureInfo resourceCulture;

		[EditorBrowsable(EditorBrowsableState.Advanced)]
		internal static ResourceManager ResourceManager
		{
			get
			{
				if (Resources.resourceMan == null)
				{
					Resources.resourceMan = new ResourceManager("BirdBrainmofo.HVNC.Properties.Resources", typeof(Resources).Assembly);
				}
				return Resources.resourceMan;
			}
		}

		[EditorBrowsable(EditorBrowsableState.Advanced)]
		internal static CultureInfo Culture
		{
			set
			{
				Resources.resourceCulture = value;
			}
		}

		internal static byte[] AESStub => (byte[])Resources.ResourceManager.GetObject("AESStub", Resources.resourceCulture);

		internal static byte[] apiunhooker => (byte[])Resources.ResourceManager.GetObject("apiunhooker", Resources.resourceCulture);

		internal static Bitmap close_window => (Bitmap)Resources.ResourceManager.GetObject("close-window", Resources.resourceCulture);

		internal static Bitmap finalRecovered => (Bitmap)Resources.ResourceManager.GetObject("finalRecovered", Resources.resourceCulture);

		internal static Bitmap info => (Bitmap)Resources.ResourceManager.GetObject("info", Resources.resourceCulture);

		internal static Bitmap maximize_window => (Bitmap)Resources.ResourceManager.GetObject("maximize-window", Resources.resourceCulture);

		internal static Bitmap minimize_window => (Bitmap)Resources.ResourceManager.GetObject("minimize-window", Resources.resourceCulture);

		internal static byte[] runpe => (byte[])Resources.ResourceManager.GetObject("runpe", Resources.resourceCulture);

		internal static string Stub => Resources.ResourceManager.GetString("Stub", Resources.resourceCulture);

		internal static byte[] XORStub => (byte[])Resources.ResourceManager.GetObject("XORStub", Resources.resourceCulture);

		internal Resources()
		{
		}
	}
}
