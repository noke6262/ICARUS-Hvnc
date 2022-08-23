using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using System.Security.Cryptography;

namespace BirdBrainmofo
{
    internal class EmbeddedAssembly
    {
        private static Dictionary<string, Assembly> dic;

        public static void Load(string embeddedResource, string fileName)
        {
            if (EmbeddedAssembly.dic == null)
            {
                EmbeddedAssembly.dic = new Dictionary<string, Assembly>();
            }
            byte[] array = null;
            Assembly assembly = null;
            using (Stream stream = Assembly.GetExecutingAssembly().GetManifestResourceStream(embeddedResource))
            {
                if (stream == null)
                {
                    throw new Exception(embeddedResource + " is not found in Embedded Resources.");
                }
                array = new byte[(int)stream.Length];
                stream.Read(array, 0, (int)stream.Length);
                try
                {
                    assembly = Assembly.Load(array);
                    EmbeddedAssembly.dic.Add(assembly.FullName, assembly);
                    return;
                }
                catch
                {
                }
            }
            bool flag = false;
            string path = "";
            using (SHA1CryptoServiceProvider sHA1CryptoServiceProvider = new SHA1CryptoServiceProvider())
            {
                string text = BitConverter.ToString(sHA1CryptoServiceProvider.ComputeHash(array)).Replace("-", string.Empty);
                path = Path.GetTempPath() + fileName;
                flag = File.Exists(path) && ((text == BitConverter.ToString(sHA1CryptoServiceProvider.ComputeHash(File.ReadAllBytes(path))).Replace("-", string.Empty)) ? true : false);
            }
            if (!flag)
            {
                File.WriteAllBytes(path, array);
            }
            assembly = Assembly.LoadFile(path);
            EmbeddedAssembly.dic.Add(assembly.FullName, assembly);
        }

        public static Assembly Get(string assemblyFullName)
        {
            if (EmbeddedAssembly.dic != null && EmbeddedAssembly.dic.Count != 0)
            {
                if (EmbeddedAssembly.dic.ContainsKey(assemblyFullName))
                {
                    return EmbeddedAssembly.dic[assemblyFullName];
                }
                return null;
            }
            return null;
        }
    }
}
