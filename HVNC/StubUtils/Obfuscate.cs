using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using dnlib.DotNet;
using dnlib.DotNet.Emit;

namespace BirdBrainmofo.HVNC.StubUtils
{
    internal class Obfuscate
    {
        private static Random random;

        private static List<string> names;

        public static string random_string(int length)
        {
            string text = "";
            do
            {
                text = new string((from string_0 in Enumerable.Repeat("ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789", length)
                                   select string_0[random.Next(string_0.Length)]).ToArray());
            }
            while (names.Contains(text));
            return text;
        }

        public static void clean_asm(ModuleDef moduleDef_0)
        {
            foreach (TypeDef type in moduleDef_0.GetTypes())
            {
                foreach (MethodDef method in type.Methods)
                {
                    if (method.HasBody)
                    {
                        method.Body.SimplifyBranches();
                        method.Body.OptimizeBranches();
                    }
                }
            }
        }

        public static void obfuscate_strings(ModuleDef moduleDef_0)
        {
            foreach (TypeDef type in moduleDef_0.GetTypes())
            {
                foreach (MethodDef method in type.Methods)
                {
                    if (!method.HasBody)
                    {
                        continue;
                    }
                    for (int i = 0; i < method.Body.Instructions.Count(); i++)
                    {
                        if (method.Body.Instructions[i].OpCode == OpCodes.Ldstr)
                        {
                            string text = method.Body.Instructions[i].Operand.ToString();
                            string text2 = Convert.ToBase64String(Encoding.UTF8.GetBytes(text));
                            Console.WriteLine(text + " -> " + text2);
                            method.Body.Instructions[i].OpCode = OpCodes.Nop;
                            method.Body.Instructions.Insert(i + 1, new Instruction(OpCodes.Call, moduleDef_0.Import(typeof(Encoding).GetMethod("get_UTF8", new Type[0]))));
                            method.Body.Instructions.Insert(i + 2, new Instruction(OpCodes.Ldstr, text2));
                            method.Body.Instructions.Insert(i + 3, new Instruction(OpCodes.Call, moduleDef_0.Import(typeof(Convert).GetMethod("FromBase64String", new Type[1] { typeof(string) }))));
                            method.Body.Instructions.Insert(i + 4, new Instruction(OpCodes.Callvirt, moduleDef_0.Import(typeof(Encoding).GetMethod("GetString", new Type[1] { typeof(byte[]) }))));
                            i += 4;
                        }
                    }
                }
            }
        }

        public static void obfuscate_classes(ModuleDef moduleDef_0)
        {
            foreach (TypeDef type in moduleDef_0.GetTypes())
            {
                string text = random_string(12);
                Console.WriteLine($"{type.Name} -> {text}");
                type.Name = text;
            }
        }

        public static void obfuscate_namespace(ModuleDef moduleDef_0)
        {
            foreach (TypeDef type in moduleDef_0.GetTypes())
            {
                string text = random_string(12);
                Console.WriteLine($"{type.Namespace} -> {text}");
                type.Namespace = text;
            }
        }

        public static void obfuscate_assembly_info(ModuleDef moduleDef_0)
        {
            string text = random_string(12);
            Console.WriteLine($"{moduleDef_0.Assembly.Name} -> {text}");
            moduleDef_0.Assembly.Name = text;
            string[] source = new string[6] { "AssemblyDescriptionAttribute", "AssemblyTitleAttribute", "AssemblyProductAttribute", "AssemblyCopyrightAttribute", "AssemblyCompanyAttribute", "AssemblyFileVersionAttribute" };
            foreach (CustomAttribute customAttribute in moduleDef_0.Assembly.CustomAttributes)
            {
                if (source.Any(customAttribute.AttributeType.Name.Contains))
                {
                    string text2 = random_string(12);
                    Console.WriteLine($"{customAttribute.AttributeType.Name} = {text2}");
                    customAttribute.ConstructorArguments[0] = new CAArgument(moduleDef_0.CorLibTypes.String, new UTF8String(text2));
                }
            }
        }

        public static ModuleDefMD obfuscate(ModuleDefMD moduleDefMD_0)
        {
            moduleDefMD_0.Name = random_string(12);
            obfuscate_strings(moduleDefMD_0);
            obfuscate_classes(moduleDefMD_0);
            obfuscate_namespace(moduleDefMD_0);
            obfuscate_assembly_info(moduleDefMD_0);
            clean_asm(moduleDefMD_0);
            return moduleDefMD_0;
        }

        static Obfuscate()
        {
            random = new Random();
            names = new List<string>();
        }
    }
}
