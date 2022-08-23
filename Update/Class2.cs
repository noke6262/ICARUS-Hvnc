using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Reflection;
using System.Reflection.Emit;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Security.Cryptography;
using System.Text;

namespace BirdBrainmofo
{
    internal class Class2
    {
        private delegate void Delegate1(object o);

        internal class Attribute0 : Attribute
        {
            internal class Class3<T>
            {
                public Class3()
                {
                    throw /*Error near IL_0001: Stack underflow*/;
                }
            }

            public Attribute0(object object_0)
            {
            }
        }

        internal class Class4
        {
            internal static string smethod_0(string string_0, string string_1)
            {
                byte[] bytes = Encoding.Unicode.GetBytes(string_0);
                byte[] array = new byte[32];
                RuntimeHelpers.InitializeArray(array, (RuntimeFieldHandle)array);
                byte[] key = (byte[])/*Error near IL_0026: Stack underflow*/;
                byte[] iV = Class2.erhwkCleV(Encoding.Unicode.GetBytes(string_1));
                MemoryStream memoryStream = new MemoryStream();
                SymmetricAlgorithm symmetricAlgorithm = Class2.smethod_7();
                symmetricAlgorithm.Key = key;
                symmetricAlgorithm.IV = iV;
                CryptoStream cryptoStream = new CryptoStream(memoryStream, symmetricAlgorithm.CreateEncryptor(), CryptoStreamMode.Write);
                cryptoStream.Write(bytes, 0, bytes.Length);
                cryptoStream.Close();
                return Convert.ToBase64String(memoryStream.ToArray());
            }

            public Class4()
            {
                throw /*Error near IL_0001: Stack underflow*/;
            }
        }

        [UnmanagedFunctionPointer(CallingConvention.StdCall)]
        internal delegate uint Delegate2(IntPtr classthis, IntPtr comp, IntPtr info, [MarshalAs(UnmanagedType.U4)] uint flags, IntPtr nativeEntry, ref uint nativeSizeOfCode);

        [UnmanagedFunctionPointer(CallingConvention.StdCall)]
        private delegate IntPtr Delegate3();

        internal struct Struct3
        {
            internal bool bool_0;

            internal byte[] byte_0;
        }

        internal class Class5
        {
            private BinaryReader binaryReader_0;

            public Class5(Stream stream_0)
            {
                this.binaryReader_0 = new BinaryReader(stream_0);
            }

            [SpecialName]
            internal Stream method_0()
            {
                return this.binaryReader_0.BaseStream;
            }

            internal byte[] method_1(int int_0)
            {
                return this.binaryReader_0.ReadBytes(int_0);
            }

            internal int method_2(byte[] byte_0, int int_0, int int_1)
            {
                return this.binaryReader_0.Read(byte_0, int_0, int_1);
            }

            internal int method_3()
            {
                return this.binaryReader_0.ReadInt32();
            }

            internal void method_4()
            {
                this.binaryReader_0.Close();
            }
        }

        [UnmanagedFunctionPointer(/*Could not decode attribute arguments.*/)]
        private delegate IntPtr Delegate4(IntPtr hModule, string lpName, uint lpType);

        [UnmanagedFunctionPointer(CallingConvention.StdCall)]
        private delegate IntPtr Delegate5(IntPtr lpAddress, uint dwSize, uint flAllocationType, uint flProtect);

        [UnmanagedFunctionPointer(CallingConvention.StdCall)]
        private delegate int Delegate6(IntPtr hProcess, IntPtr lpBaseAddress, [In][Out] byte[] buffer, uint size, out IntPtr lpNumberOfBytesWritten);

        [UnmanagedFunctionPointer(CallingConvention.StdCall)]
        private delegate int Delegate7(IntPtr lpAddress, int dwSize, int flNewProtect, ref int lpflOldProtect);

        [UnmanagedFunctionPointer(CallingConvention.StdCall)]
        private delegate IntPtr Delegate8(uint dwDesiredAccess, int bInheritHandle, uint dwProcessId);

        [UnmanagedFunctionPointer(CallingConvention.StdCall)]
        private delegate int Delegate9(IntPtr ptr);

        [Flags]
        private enum Enum0
        {

        }

        internal static Delegate2 delegate2_0;

        private static Delegate5 delegate5_0;

        private static int int_0;

        private static bool bool_0;

        private static Delegate4 delegate4_0;

        private static int int_1;

        private static object object_0;

        private static IntPtr intptr_0;

        private static IntPtr intptr_1;

        private static bool bool_1;

        private static List<int> list_0;

        private static Delegate9 delegate9_0;

        private static string string_0;

        private static long long_0;

        private static int int_2;

        private static List<string> list_1;

        private static Delegate8 delegate8_0;

        private static Dictionary<int, int> dictionary_0;

        internal static Hashtable hashtable_0;

        private static int[] int_3;

        internal static Assembly assembly_0;

        private static bool bool_2;

        private static bool bool_3;

        private static IntPtr intptr_2;

        private static int int_4;

        private static int int_5;

        private static bool bool_4;

        private static Delegate7 delegate7_0;

        [Attribute0(typeof(Class3<Object>[]))]
        private static bool firstrundone;

        private static IntPtr intptr_3;

        private static object object_1;

        private static Delegate6 delegate6_0;

        internal static Delegate2 delegate2_1;

        private static byte[] byte_0;

        private static long long_1;

        private static byte[] byte_1;

        private static string[] string_1;

        private static bool bool_5;

        private static uint[] uint_0;

        private static SortedList sortedList_0;

        internal static RSACryptoServiceProvider rsacryptoServiceProvider_0;

        private void method_0()
        {
        }

        internal static byte[] smethod_0(byte[] byte_2)
        {
            uint[] array = new uint[16];
            uint num = (uint)((448 - byte_2.Length * 8 % 512 + 512) % 512);
            if (num == 0)
            {
                num = 512u;
            }
            uint num2 = (uint)(byte_2.Length + num / 8u + 8L);
            ulong num3 = (ulong)(byte_2.Length * 8L);
            byte[] array2 = new byte[num2];
            for (int i = 0; i < byte_2.Length; i++)
            {
                array2[i] = byte_2[i];
            }
            array2[byte_2.Length] |= 128;
            for (int num4 = 8; num4 > 0; num4--)
            {
                array2[num2 - num4] = (byte)((num3 >> (8 - num4) * 8) & 0xFFuL);
            }
            uint num5 = (uint)(array2.Length * 8) / 32u;
            uint uint_ = 1732584193u;
            uint uint_2 = 4023233417u;
            uint uint_3 = 2562383102u;
            uint uint_4 = 271733878u;
            uint num6 = default(uint);
            do
            {
                uint num7 = num6 << 6;
                for (uint num8 = 0u; num8 < 61; num8 += 4)
                {
                    array[num8 >> 2] = (uint)((array2[num7 + (num8 + 3)] << 24) | (array2[num7 + (num8 + 2)] << 16) | (array2[num7 + (num8 + 1)] << 8) | array2[num7 + num8]);
                }
                uint num9 = uint_;
                uint num10 = uint_2;
                uint num11 = uint_3;
                uint num12 = uint_4;
                Class2.smethod_1(ref uint_, uint_2, uint_3, uint_4, 0u, 7, 1u, array);
                Class2.smethod_1(ref uint_4, uint_, uint_2, uint_3, 1u, 12, 2u, array);
                Class2.smethod_1(ref uint_3, uint_4, uint_, uint_2, 2u, 17, 3u, array);
                Class2.smethod_1(ref uint_2, uint_3, uint_4, uint_, 3u, 22, 4u, array);
                Class2.smethod_1(ref uint_, uint_2, uint_3, uint_4, 4u, 7, 5u, array);
                Class2.smethod_1(ref uint_4, uint_, uint_2, uint_3, 5u, 12, 6u, array);
                Class2.smethod_1(ref uint_3, uint_4, uint_, uint_2, 6u, 17, 7u, array);
                Class2.smethod_1(ref uint_2, uint_3, uint_4, uint_, 7u, 22, 8u, array);
                Class2.smethod_1(ref uint_, uint_2, uint_3, uint_4, 8u, 7, 9u, array);
                Class2.smethod_1(ref uint_4, uint_, uint_2, uint_3, 9u, 12, 10u, array);
                Class2.smethod_1(ref uint_3, uint_4, uint_, uint_2, 10u, 17, 11u, array);
                Class2.smethod_1(ref uint_2, uint_3, uint_4, uint_, 11u, 22, 12u, array);
                Class2.smethod_1(ref uint_, uint_2, uint_3, uint_4, 12u, 7, 13u, array);
                Class2.smethod_1(ref uint_4, uint_, uint_2, uint_3, 13u, 12, 14u, array);
                Class2.smethod_1(ref uint_3, uint_4, uint_, uint_2, 14u, 17, 15u, array);
                Class2.smethod_1(ref uint_2, uint_3, uint_4, uint_, 15u, 22, 16u, array);
                Class2.smethod_2(ref uint_, uint_2, uint_3, uint_4, 1u, 5, 17u, array);
                Class2.smethod_2(ref uint_4, uint_, uint_2, uint_3, 6u, 9, 18u, array);
                Class2.smethod_2(ref uint_3, uint_4, uint_, uint_2, 11u, 14, 19u, array);
                Class2.smethod_2(ref uint_2, uint_3, uint_4, uint_, 0u, 20, 20u, array);
                Class2.smethod_2(ref uint_, uint_2, uint_3, uint_4, 5u, 5, 21u, array);
                Class2.smethod_2(ref uint_4, uint_, uint_2, uint_3, 10u, 9, 22u, array);
                Class2.smethod_2(ref uint_3, uint_4, uint_, uint_2, 15u, 14, 23u, array);
                Class2.smethod_2(ref uint_2, uint_3, uint_4, uint_, 4u, 20, 24u, array);
                Class2.smethod_2(ref uint_, uint_2, uint_3, uint_4, 9u, 5, 25u, array);
                Class2.smethod_2(ref uint_4, uint_, uint_2, uint_3, 14u, 9, 26u, array);
                Class2.smethod_2(ref uint_3, uint_4, uint_, uint_2, 3u, 14, 27u, array);
                Class2.smethod_2(ref uint_2, uint_3, uint_4, uint_, 8u, 20, 28u, array);
                Class2.smethod_2(ref uint_, uint_2, uint_3, uint_4, 13u, 5, 29u, array);
                Class2.smethod_2(ref uint_4, uint_, uint_2, uint_3, 2u, 9, 30u, array);
                Class2.smethod_2(ref uint_3, uint_4, uint_, uint_2, 7u, 14, 31u, array);
                Class2.smethod_2(ref uint_2, uint_3, uint_4, uint_, 12u, 20, 32u, array);
                Class2.smethod_3(ref uint_, uint_2, uint_3, uint_4, 5u, 4, 33u, array);
                Class2.smethod_3(ref uint_4, uint_, uint_2, uint_3, 8u, 11, 34u, array);
                Class2.smethod_3(ref uint_3, uint_4, uint_, uint_2, 11u, 16, 35u, array);
                Class2.smethod_3(ref uint_2, uint_3, uint_4, uint_, 14u, 23, 36u, array);
                Class2.smethod_3(ref uint_, uint_2, uint_3, uint_4, 1u, 4, 37u, array);
                Class2.smethod_3(ref uint_4, uint_, uint_2, uint_3, 4u, 11, 38u, array);
                Class2.smethod_3(ref uint_3, uint_4, uint_, uint_2, 7u, 16, 39u, array);
                Class2.smethod_3(ref uint_2, uint_3, uint_4, uint_, 10u, 23, 40u, array);
                Class2.smethod_3(ref uint_, uint_2, uint_3, uint_4, 13u, 4, 41u, array);
                Class2.smethod_3(ref uint_4, uint_, uint_2, uint_3, 0u, 11, 42u, array);
                Class2.smethod_3(ref uint_3, uint_4, uint_, uint_2, 3u, 16, 43u, array);
                Class2.smethod_3(ref uint_2, uint_3, uint_4, uint_, 6u, 23, 44u, array);
                Class2.smethod_3(ref uint_, uint_2, uint_3, uint_4, 9u, 4, 45u, array);
                Class2.smethod_3(ref uint_4, uint_, uint_2, uint_3, 12u, 11, 46u, array);
                Class2.smethod_3(ref uint_3, uint_4, uint_, uint_2, 15u, 16, 47u, array);
                Class2.smethod_3(ref uint_2, uint_3, uint_4, uint_, 2u, 23, 48u, array);
                Class2.smethod_4(ref uint_, uint_2, uint_3, uint_4, 0u, 6, 49u, array);
                Class2.smethod_4(ref uint_4, uint_, uint_2, uint_3, 7u, 10, 50u, array);
                Class2.smethod_4(ref uint_3, uint_4, uint_, uint_2, 14u, 15, 51u, array);
                Class2.smethod_4(ref uint_2, uint_3, uint_4, uint_, 5u, 21, 52u, array);
                Class2.smethod_4(ref uint_, uint_2, uint_3, uint_4, 12u, 6, 53u, array);
                Class2.smethod_4(ref uint_4, uint_, uint_2, uint_3, 3u, 10, 54u, array);
                Class2.smethod_4(ref uint_3, uint_4, uint_, uint_2, 10u, 15, 55u, array);
                Class2.smethod_4(ref uint_2, uint_3, uint_4, uint_, 1u, 21, 56u, array);
                Class2.smethod_4(ref uint_, uint_2, uint_3, uint_4, 8u, 6, 57u, array);
                Class2.smethod_4(ref uint_4, uint_, uint_2, uint_3, 15u, 10, 58u, array);
                Class2.smethod_4(ref uint_3, uint_4, uint_, uint_2, 6u, 15, 59u, array);
                Class2.smethod_4(ref uint_2, uint_3, uint_4, uint_, 13u, 21, 60u, array);
                Class2.smethod_4(ref uint_, uint_2, uint_3, uint_4, 4u, 6, 61u, array);
                Class2.smethod_4(ref uint_4, uint_, uint_2, uint_3, 11u, 10, 62u, array);
                Class2.smethod_4(ref uint_3, uint_4, uint_, uint_2, 2u, 15, 63u, array);
                Class2.smethod_4(ref uint_2, uint_3, uint_4, uint_, 9u, 21, 64u, array);
                uint_ += num9;
                uint_2 += num10;
                uint_3 += num11;
                uint_4 += num12;
                num6++;
            }
            while (num6 < num5 / 16u);
            byte[] array3 = new byte[16];
            Array.Copy(BitConverter.GetBytes(uint_), 0, array3, 0, 4);
            Array.Copy(BitConverter.GetBytes(uint_2), 0, array3, 4, 4);
            Array.Copy(BitConverter.GetBytes(uint_3), 0, array3, 8, 4);
            Array.Copy(BitConverter.GetBytes(uint_4), 0, array3, 12, 4);
            return array3;
        }

        private static void smethod_1(ref uint uint_1, uint uint_2, uint uint_3, uint uint_4, uint uint_5, ushort ushort_0, uint uint_6, uint[] uint_7)
        {
            uint_1 = uint_2 + Class2.smethod_5(uint_1 + ((uint_2 & uint_3) | (~uint_2 & uint_4)) + uint_7[uint_5] + Class2.uint_0[uint_6 - 1], ushort_0);
        }

        private static void smethod_2(ref uint uint_1, uint uint_2, uint uint_3, uint uint_4, uint uint_5, ushort ushort_0, uint uint_6, uint[] uint_7)
        {
            uint_1 = uint_2 + Class2.smethod_5(uint_1 + ((uint_2 & uint_4) | (uint_3 & ~uint_4)) + uint_7[uint_5] + Class2.uint_0[uint_6 - 1], ushort_0);
        }

        private static void smethod_3(ref uint uint_1, uint uint_2, uint uint_3, uint uint_4, uint uint_5, ushort ushort_0, uint uint_6, uint[] uint_7)
        {
            uint_1 = uint_2 + Class2.smethod_5(uint_1 + (uint_2 ^ uint_3 ^ uint_4) + uint_7[uint_5] + Class2.uint_0[uint_6 - 1], ushort_0);
        }

        private static void smethod_4(ref uint uint_1, uint uint_2, uint uint_3, uint uint_4, uint uint_5, ushort ushort_0, uint uint_6, uint[] uint_7)
        {
            uint_1 = uint_2 + Class2.smethod_5(uint_1 + (uint_3 ^ (uint_2 | ~uint_4)) + uint_7[uint_5] + Class2.uint_0[uint_6 - 1], ushort_0);
        }

        private static uint smethod_5(uint uint_1, ushort ushort_0)
        {
            return (uint_1 >> 32 - ushort_0) | (uint_1 << (int)ushort_0);
        }

        private void method_1(byte[] byte_2, byte[] byte_3, byte[] byte_4)
        {
            int num = byte_4.Length % 4;
            int num2 = byte_4.Length / 4;
            byte[] array = new byte[byte_4.Length];
            int num3 = byte_2.Length / 4;
            uint num4 = 0u;
            uint num5 = 0u;
            uint num6 = 0u;
            if (num > 0)
            {
                num2++;
            }
            uint num7 = 0u;
            int num8 = default(int);
            do
            {
                int num9 = num8 % num3;
                int num10 = num8 * 4;
                num7 = (uint)(num9 * 4);
                num5 = (uint)((byte_2[num7 + 3] << 24) | (byte_2[num7 + 2] << 16) | (byte_2[num7 + 1] << 8) | byte_2[num7]);
                uint num11 = 255u;
                int num12 = 0;
                if (num8 != num2 - 1 || num <= 0)
                {
                    num4 += num5;
                    num7 = (uint)num10;
                    num6 = (uint)((byte_4[num7 + 3] << 24) | (byte_4[num7 + 2] << 16) | (byte_4[num7 + 1] << 8) | byte_4[num7]);
                }
                else
                {
                    num6 = 0u;
                    num4 += num5;
                    for (int i = 0; i < num; i++)
                    {
                        if (i > 0)
                        {
                            num6 <<= 8;
                        }
                        num6 |= byte_4[byte_4.Length - (1 + i)];
                    }
                }
                uint num13 = num4;
                num4 = 0u;
                uint num14 = num13;
                num14 = (num14 ^ (num14 << 13)) + 1578322186;
                num14 = (num14 ^ (num14 << 11)) + 2326903265u;
                num4 = num13 + (uint)(double)(uint)(-844237686 + ((int)(num14 ^ (num14 >> 21)) + -1787683927));
                if (num8 == num2 - 1 && num > 0)
                {
                    uint num15 = num4 ^ num6;
                    for (int j = 0; j < num; j++)
                    {
                        if (j > 0)
                        {
                            num11 <<= 8;
                            num12 += 8;
                        }
                        array[num10 + j] = (byte)((num15 & num11) >> num12);
                    }
                }
                else
                {
                    uint num16 = num4 ^ num6;
                    array[num10] = (byte)(num16 & 0xFFu);
                    array[num10 + 1] = (byte)((num16 & 0xFF00) >> 8);
                    array[num10 + 2] = (byte)((num16 & 0xFF0000) >> 16);
                    array[num10 + 3] = (byte)((num16 & 0xFF000000u) >> 24);
                }
                num8++;
            }
            while (num8 < num2);
            Class2.byte_0 = array;
        }

        internal static SymmetricAlgorithm smethod_7()
        {
            SymmetricAlgorithm symmetricAlgorithm = null;
            if (CryptoConfig.AllowOnlyFipsAlgorithms)
            {
                return new AesCryptoServiceProvider();
            }
            try
            {
                return new RijndaelManaged();
            }
            catch
            {
                return (SymmetricAlgorithm)Activator.CreateInstance("System.Core, Version=3.5.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089", "System.Security.Cryptography.AesCryptoServiceProvider").Unwrap();
            }
        }

        internal static byte[] erhwkCleV(byte[] byte_2)
        {
            if (!CryptoConfig.AllowOnlyFipsAlgorithms)
            {
                return new MD5CryptoServiceProvider().ComputeHash(byte_2);
            }
            return Class2.smethod_0(byte_2);
        }

        internal static void smethod_9(HashAlgorithm hashAlgorithm_0, Stream stream_0, uint uint_1, byte[] byte_2)
        {
            //IL_004b: Expected O, but got I4
            //IL_004b: Expected I4, but got O
            //IL_004b: Expected I4, but got O
            //IL_0054: Incompatible stack heights: 0 vs 1
            while (uint_1 != 0)
            {
                int num = ((uint_1 > (uint)byte_2.Length) ? byte_2.Length : ((int)uint_1));
                stream_0.Read(byte_2, 0, num);
                ((HashAlgorithm)/*Error near IL_004b: Stack underflow*/).TransformBlock((byte[])/*Error near IL_004b: Stack underflow*/, (int)hashAlgorithm_0, (int)byte_2, (byte[])0, num);
                uint_1 -= (uint)num;
            }
        }

        internal static uint smethod_11(uint uint_1, int int_6, long long_2, BinaryReader binaryReader_0)
        {
            int num = 0;
            uint num3;
            uint num4;
            while (true)
            {
                if (num < int_6)
                {
                    binaryReader_0.BaseStream.Position = long_2 + (num * 40 + 8);
                    uint num2 = binaryReader_0.ReadUInt32();
                    num3 = binaryReader_0.ReadUInt32();
                    binaryReader_0.ReadUInt32();
                    num4 = binaryReader_0.ReadUInt32();
                    if (num3 <= uint_1 && uint_1 < num3 + num2)
                    {
                        break;
                    }
                    num++;
                    continue;
                }
                return 0u;
            }
            return num4 + uint_1 - num3;
        }

        public static void smethod_12(RuntimeTypeHandle runtimeTypeHandle_0)
        {
            try
            {
                Type typeFromHandle = Type.GetTypeFromHandle(runtimeTypeHandle_0);
                if (Class2.dictionary_0 == null)
                {
                    lock (Class2.object_1)
                    {
                        Dictionary<int, int> dictionary = new Dictionary<int, int>();
                        BinaryReader binaryReader = new BinaryReader(typeof(Class2).Assembly.GetManifestResourceStream("f4eCc2aBDKKOTv8gMY.GvtnfM3LmrA5oCvwVV"));
                        binaryReader.BaseStream.Position = 0L;
                        byte[] array = binaryReader.ReadBytes((int)binaryReader.BaseStream.Length);
                        binaryReader.Close();
                        if (array.Length != 0)
                        {
                            int num = array.Length % 4;
                            int num2 = array.Length / 4;
                            byte[] array2 = new byte[array.Length];
                            uint num3 = 0u;
                            uint num4 = 0u;
                            if (num > 0)
                            {
                                num2++;
                            }
                            uint num5 = 0u;
                            int num6 = default(int);
                            do
                            {
                                int num7 = num6 * 4;
                                uint num8 = 255u;
                                int num9 = 0;
                                if (num6 != num2 - 1 || num <= 0)
                                {
                                    num5 = (uint)num7;
                                    num4 = (uint)((array[num5 + 3] << 24) | (array[num5 + 2] << 16) | (array[num5 + 1] << 8) | array[num5]);
                                }
                                else
                                {
                                    num4 = 0u;
                                    for (int i = 0; i < num; i++)
                                    {
                                        if (i > 0)
                                        {
                                            num4 <<= 8;
                                        }
                                        num4 |= array[array.Length - (1 + i)];
                                    }
                                }
                                num3 += 0;
                                if (num6 == num2 - 1 && num > 0)
                                {
                                    uint num10 = num3 ^ num4;
                                    for (int j = 0; j < num; j++)
                                    {
                                        if (j > 0)
                                        {
                                            num8 <<= 8;
                                            num9 += 8;
                                        }
                                        array2[num7 + j] = (byte)((num10 & num8) >> num9);
                                    }
                                }
                                else
                                {
                                    uint num11 = num3 ^ num4;
                                    array2[num7] = (byte)(num11 & 0xFFu);
                                    array2[num7 + 1] = (byte)((num11 & 0xFF00) >> 8);
                                    array2[num7 + 2] = (byte)((num11 & 0xFF0000) >> 16);
                                    array2[num7 + 3] = (byte)((num11 & 0xFF000000u) >> 24);
                                }
                                num6++;
                            }
                            while (num6 < num2);
                            array = array2;
                            array2 = null;
                            int num12 = array.Length / 8;
                            Class5 @class = new Class5(new MemoryStream(array));
                            for (int k = 0; k < num12; k++)
                            {
                                dictionary.Add(@class.method_3(), @class.method_3());
                            }
                            @class.method_4();
                        }
                        Class2.dictionary_0 = dictionary;
                    }
                }
                FieldInfo[] fields = typeFromHandle.GetFields(BindingFlags.Static | BindingFlags.NonPublic | BindingFlags.GetField);
                for (int l = 0; l < fields.Length; l++)
                {
                    try
                    {
                        FieldInfo fieldInfo = fields[l];
                        int metadataToken = fieldInfo.MetadataToken;
                        int num13 = Class2.dictionary_0[metadataToken];
                        bool flag = (num13 & 0x40000000) > 0;
                        MethodInfo methodInfo = (MethodInfo)typeof(Class2).Module.ResolveMethod(num13 & 0x3FFFFFFF, typeFromHandle.GetGenericArguments(), new Type[0]);
                        if (methodInfo.IsStatic)
                        {
                            fieldInfo.SetValue(null, Delegate.CreateDelegate(fieldInfo.FieldType, methodInfo));
                            continue;
                        }
                        ParameterInfo[] parameters = methodInfo.GetParameters();
                        int num14 = parameters.Length + 1;
                        Type[] array3 = new Type[num14];
                        if (methodInfo.DeclaringType.IsValueType)
                        {
                            array3[0] = methodInfo.DeclaringType.MakeByRefType();
                        }
                        else
                        {
                            array3[0] = typeof(object);
                        }
                        for (int m = 0; m < parameters.Length; m++)
                        {
                            array3[m + 1] = parameters[m].ParameterType;
                        }
                        DynamicMethod dynamicMethod = new DynamicMethod(string.Empty, methodInfo.ReturnType, array3, typeFromHandle, skipVisibility: true);
                        ILGenerator iLGenerator = dynamicMethod.GetILGenerator();
                        for (int n = 0; n < num14; n++)
                        {
                            switch (n)
                            {
                                default:
                                    iLGenerator.Emit(OpCodes.Ldarg_S, n);
                                    break;
                                case 0:
                                    iLGenerator.Emit(OpCodes.Ldarg_0);
                                    break;
                                case 1:
                                    iLGenerator.Emit(OpCodes.Ldarg_1);
                                    break;
                                case 2:
                                    iLGenerator.Emit(OpCodes.Ldarg_2);
                                    break;
                                case 3:
                                    iLGenerator.Emit(OpCodes.Ldarg_3);
                                    break;
                            }
                        }
                        iLGenerator.Emit(OpCodes.Tailcall);
                        iLGenerator.Emit(flag ? OpCodes.Callvirt : OpCodes.Call, methodInfo);
                        iLGenerator.Emit(OpCodes.Ret);
                        fieldInfo.SetValue(null, dynamicMethod.CreateDelegate(typeFromHandle));
                    }
                    catch
                    {
                    }
                }
            }
            catch (Exception)
            {
            }
        }

        private static void smethod_14(Stream stream_0, int int_6)
        {
            Class8.smethod_2(0, new object[2] { stream_0, int_6 }, null);
        }

        internal static string smethod_15(int int_6)
        {
            if (Class2.byte_0.Length == 0)
            {
                Class2.list_1 = new List<string>();
                Class2.list_0 = new List<int>();
                Class2.smethod_14(Class2.assembly_0.GetManifestResourceStream("VBLVIN15y3Mx68Qe8m.bXwSjvHVAiEcZOFDwT"), int_6);
            }
            if (Class2.int_1 < 75)
            {
                if (Class2.assembly_0 != new StackFrame(1).GetMethod().DeclaringType.Assembly)
                {
                    throw new Exception();
                }
                Class2.int_1++;
            }
            lock (Class2.object_0)
            {
                int num = BitConverter.ToInt32(Class2.byte_0, int_6);
                if (num < Class2.list_0.Count && Class2.list_0[num] == int_6)
                {
                    return Class2.list_1[num];
                }
                try
                {
                    byte[] array = new byte[num];
                    Array.Copy(Class2.byte_0, int_6 + 4, array, 0, num);
                    string @string = Encoding.Unicode.GetString(array, 0, array.Length);
                    Class2.list_1.Add(@string);
                    Class2.list_0.Add(int_6);
                    Array.Copy(BitConverter.GetBytes(Class2.list_1.Count - 1), 0, Class2.byte_0, int_6, 4);
                    return @string;
                }
                catch
                {
                }
            }
            return "";
        }

        internal static string smethod_16(string string_2)
        {
            "{11111-22222-50001-00000}".Trim();
            byte[] array = Convert.FromBase64String(string_2);
            return Encoding.Unicode.GetString(array, 0, array.Length);
        }

        internal static uint smethod_17(IntPtr intptr_4, IntPtr intptr_5, IntPtr intptr_6, [MarshalAs(UnmanagedType.U4)] uint uint_1, IntPtr intptr_7, ref uint uint_2)
        {
            IntPtr ptr = intptr_6;
            if (Class2.bool_3)
            {
                ptr = intptr_5;
            }
            long num = 0L;
            num = ((IntPtr.Size != 4) ? Marshal.ReadInt64(ptr, IntPtr.Size * 2) : Marshal.ReadInt32(ptr, IntPtr.Size * 2));
            object obj = Class2.hashtable_0[num];
            if (obj != null)
            {
                Struct3 @struct = (Struct3)obj;
                IntPtr intPtr = Marshal.AllocCoTaskMem(@struct.byte_0.Length);
                Marshal.Copy(@struct.byte_0, 0, intPtr, @struct.byte_0.Length);
                if (@struct.bool_0)
                {
                    intptr_7 = intPtr;
                    uint_2 = (uint)@struct.byte_0.Length;
                    Class2.smethod_23(intptr_7, @struct.byte_0.Length, 64, ref Class2.int_4);
                    return 0u;
                }
                Marshal.WriteIntPtr(ptr, IntPtr.Size * 2, intPtr);
                Marshal.WriteInt32(ptr, IntPtr.Size * 3, @struct.byte_0.Length);
                uint result = 0u;
                if (uint_1 == 216669565 && !Class2.firstrundone)
                {
                    Class2.firstrundone = true;
                }
                else
                {
                    result = Class2.delegate2_0(intptr_4, intptr_5, intptr_6, uint_1, intptr_7, ref uint_2);
                }
                return result;
            }
            return Class2.delegate2_0(intptr_4, intptr_5, intptr_6, uint_1, intptr_7, ref uint_2);
        }

        private static Delegate smethod_19(IntPtr intptr_4, Type type_0)
        {
            return (Delegate)typeof(Marshal).GetMethod("GetDelegateForFunctionPointer", new Type[2]
            {
                typeof(IntPtr),
                typeof(Type)
            }).Invoke(null, new object[2] { intptr_4, type_0 });
        }

        internal unsafe static void uWdOlFaAb()
        {
            if (Class2.bool_1)
            {
                return;
            }
            Class2.bool_1 = true;
            long num = 0L;
            Marshal.ReadIntPtr(new IntPtr(&num), 0);
            Marshal.ReadInt32(new IntPtr(&num), 0);
            Marshal.ReadInt64(new IntPtr(&num), 0);
            Marshal.WriteIntPtr(new IntPtr(&num), 0, IntPtr.Zero);
            Marshal.WriteInt32(new IntPtr(&num), 0, 0);
            Marshal.WriteInt64(new IntPtr(&num), 0, 0L);
            Marshal.Copy(new byte[1], 0, Marshal.AllocCoTaskMem(8), 1);
            RSACryptoServiceProvider.UseMachineKeyStore = (byte)/*Error near IL_00d7: Stack underflow*/ != 0;
            if (!(Class2.smethod_20(Process.GetCurrentProcess().MainModule.BaseAddress, "__", 10u) != IntPtr.Zero))
            {
                return;
            }
            if (IntPtr.Size == 4 && Type.GetType("System.Reflection.ReflectionContext", throwOnError: false) != null)
            {
                {
                    IEnumerator enumerator = Process.GetCurrentProcess().Modules.GetEnumerator();
                    try
                    {
                        do
                        {
                            ProcessModule processModule = (ProcessModule)enumerator.Current;
                            if (processModule.ModuleName.ToLower() == "clrjit.dll")
                            {
                                Version version = new Version(processModule.FileVersionInfo.ProductMajorPart, processModule.FileVersionInfo.ProductMinorPart, processModule.FileVersionInfo.ProductBuildPart, processModule.FileVersionInfo.ProductPrivatePart);
                                Version version2 = new Version(4, 0, 30319, 17020);
                                Version version3 = new Version(4, 0, 30319, 17921);
                                if (version >= version2 && version < version3)
                                {
                                    Class2.bool_3 = true;
                                    break;
                                }
                            }
                        }
                        while (enumerator.MoveNext());
                    }
                    finally
                    {
                        IDisposable disposable = enumerator as IDisposable;
                        if (disposable != null)
                        {
                            disposable.Dispose();
                        }
                    }
                }
            }
            Class5 @class = new Class5(Class2.assembly_0.GetManifestResourceStream("dkQR24YvWSEDekmRiH.jSbRHsuxn8LiyGXk1r"));
            @class.method_0().Position = 0L;
            byte[] array = @class.method_1((int)@class.method_0().Length);
            byte[] array2 = new byte[32];
            array2[0] = 104;
            array2[0] = 132;
            array2[0] = 58;
            array2[0] = 104;
            array2[0] = 156;
            array2[0] = 139;
            array2[1] = 147;
            array2[1] = 47;
            array2[1] = 168;
            array2[1] = 148;
            array2[1] = 81;
            array2[1] = 169;
            array2[2] = 146;
            array2[2] = 130;
            array2[2] = 95;
            array2[3] = 170;
            array2[3] = 103;
            array2[3] = 100;
            array2[3] = 165;
            array2[3] = 164;
            array2[3] = 205;
            array2[4] = 142;
            array2[4] = 98;
            array2[4] = 237;
            array2[4] = 215;
            array2[4] = 80;
            array2[5] = 145;
            array2[5] = 130;
            array2[5] = 124;
            array2[5] = 107;
            array2[5] = 120;
            array2[5] = 50;
            array2[6] = 56;
            array2[6] = 154;
            array2[6] = 183;
            array2[6] = 118;
            array2[7] = 105;
            array2[7] = 132;
            array2[7] = 53;
            array2[7] = 21;
            array2[8] = 166;
            array2[8] = 91;
            array2[8] = 182;
            array2[9] = 125;
            array2[9] = 157;
            array2[9] = 104;
            array2[10] = 142;
            array2[10] = 177;
            array2[10] = 143;
            array2[10] = 151;
            array2[11] = 154;
            array2[11] = 144;
            array2[11] = 5;
            array2[12] = 110;
            array2[12] = 129;
            array2[12] = 150;
            array2[12] = 136;
            array2[12] = 140;
            array2[13] = 152;
            array2[13] = 137;
            array2[13] = 147;
            array2[13] = 165;
            array2[13] = 216;
            array2[14] = 93;
            array2[14] = 86;
            array2[14] = 178;
            array2[15] = 164;
            array2[15] = 130;
            array2[15] = 108;
            array2[15] = 151;
            array2[15] = 105;
            array2[15] = 77;
            array2[16] = 159;
            array2[16] = 57;
            array2[16] = 94;
            array2[16] = 103;
            array2[16] = 147;
            array2[17] = 108;
            array2[17] = 150;
            array2[17] = 6;
            array2[18] = 146;
            array2[18] = 90;
            array2[18] = 247;
            array2[19] = 185;
            array2[19] = 146;
            array2[19] = 153;
            array2[19] = 84;
            array2[20] = 154;
            array2[20] = 106;
            array2[20] = 109;
            array2[20] = 158;
            array2[20] = 179;
            array2[20] = 158;
            array2[21] = 101;
            array2[21] = 126;
            array2[21] = 123;
            array2[21] = 170;
            array2[21] = 188;
            array2[21] = 53;
            array2[22] = 150;
            array2[22] = 135;
            array2[22] = 122;
            array2[22] = 94;
            array2[22] = 10;
            array2[23] = 98;
            array2[23] = 133;
            array2[23] = 134;
            array2[23] = 107;
            array2[23] = 98;
            array2[24] = 131;
            array2[24] = 24;
            array2[24] = 114;
            array2[24] = 100;
            array2[25] = 94;
            array2[25] = 67;
            array2[25] = 121;
            array2[25] = 158;
            array2[25] = 44;
            array2[26] = 102;
            array2[26] = 143;
            array2[26] = 98;
            array2[26] = 139;
            array2[26] = 196;
            array2[27] = 152;
            array2[27] = 148;
            array2[27] = 176;
            array2[27] = 130;
            array2[27] = 50;
            array2[27] = 110;
            array2[28] = 133;
            array2[28] = 17;
            array2[28] = 188;
            array2[28] = 202;
            array2[29] = 201;
            array2[29] = 93;
            array2[29] = 115;
            array2[29] = 134;
            array2[29] = 219;
            array2[30] = 138;
            array2[30] = 100;
            array2[30] = 9;
            array2[31] = 163;
            array2[31] = 156;
            array2[31] = 94;
            array2[31] = 52;
            byte[] array3 = array2;
            byte[] array4 = new byte[16];
            array4[0] = 119;
            array4[0] = 103;
            array4[0] = 176;
            array4[1] = 76;
            array4[1] = 111;
            array4[1] = 101;
            array4[1] = 172;
            array4[2] = 161;
            array4[2] = 106;
            array4[2] = 156;
            array4[2] = 92;
            array4[2] = 41;
            array4[3] = 111;
            array4[3] = 172;
            array4[3] = 89;
            array4[3] = 100;
            array4[3] = 148;
            array4[4] = 216;
            array4[4] = 58;
            array4[4] = 129;
            array4[5] = 107;
            array4[5] = 138;
            array4[5] = 188;
            array4[5] = 166;
            array4[5] = 94;
            array4[5] = 126;
            array4[6] = 126;
            array4[6] = 97;
            array4[6] = 208;
            array4[7] = 85;
            array4[7] = 74;
            array4[7] = 150;
            array4[7] = 183;
            array4[7] = 94;
            array4[7] = 133;
            array4[8] = 132;
            array4[8] = 53;
            array4[8] = 190;
            array4[9] = 146;
            array4[9] = 142;
            array4[9] = 168;
            array4[9] = 125;
            array4[9] = 249;
            array4[10] = 126;
            array4[10] = 149;
            array4[10] = 136;
            array4[10] = 43;
            array4[10] = 250;
            array4[11] = 170;
            array4[11] = 92;
            array4[11] = 110;
            array4[11] = 110;
            array4[11] = 129;
            array4[11] = 38;
            array4[12] = 126;
            array4[12] = 122;
            array4[12] = 112;
            array4[13] = 130;
            array4[13] = 142;
            array4[13] = 198;
            array4[13] = 128;
            array4[13] = 185;
            array4[14] = 106;
            array4[14] = 163;
            array4[14] = 51;
            array4[14] = 145;
            array4[15] = 108;
            array4[15] = 118;
            array4[15] = 207;
            byte[] array5 = array4;
            Array.Reverse(array5);
            byte[] publicKeyToken = Class2.assembly_0.GetName().GetPublicKeyToken();
            if (publicKeyToken != null && publicKeyToken.Length != 0)
            {
                array5[1] = publicKeyToken[0];
                array5[3] = publicKeyToken[1];
                array5[5] = publicKeyToken[2];
                array5[7] = publicKeyToken[3];
                array5[9] = publicKeyToken[4];
                array5[11] = publicKeyToken[5];
                array5[13] = publicKeyToken[6];
                array5[15] = publicKeyToken[7];
                Array.Clear(publicKeyToken, 0, publicKeyToken.Length);
            }
            for (int i = 0; i < array5.Length; i++)
            {
                array3[i] = (byte)(array3[i] ^ array5[i]);
            }
            byte[] array6 = array;
            int num2 = array6.Length % 4;
            int num3 = array6.Length / 4;
            byte[] array7 = new byte[array6.Length];
            int num4 = array3.Length / 4;
            uint num5 = 0u;
            uint num6 = 0u;
            uint num7 = 0u;
            if (num2 > 0)
            {
                num3++;
            }
            uint num8 = 0u;
            int num9 = default(int);
            do
            {
                int num10 = num9 % num4;
                int num11 = num9 * 4;
                num8 = (uint)(num10 * 4);
                num6 = (uint)((array3[num8 + 3] << 24) | (array3[num8 + 2] << 16) | (array3[num8 + 1] << 8) | array3[num8]);
                uint num12 = 255u;
                int num13 = 0;
                if (num9 != num3 - 1 || num2 <= 0)
                {
                    num8 = (uint)num11;
                    num5 += num6;
                    num7 = (uint)((array6[num8 + 3] << 24) | (array6[num8 + 2] << 16) | (array6[num8 + 1] << 8) | array6[num8]);
                }
                else
                {
                    num5 += num6;
                    num7 = 0u;
                    for (int j = 0; j < num2; j++)
                    {
                        if (j > 0)
                        {
                            num7 <<= 8;
                        }
                        num7 |= array6[array6.Length - (1 + j)];
                    }
                }
                num5 = num5;
                uint num14 = num5;
                uint num15 = num5;
                num15 = (num15 ^ (num15 << 13)) + 1578322186;
                num15 = (num15 ^ (num15 << 11)) + 2326903265u;
                num5 = num14 + (uint)(double)(uint)(-844237686 + ((int)(num15 ^ (num15 >> 21)) + -1787683927));
                if (num9 == num3 - 1 && num2 > 0)
                {
                    uint num16 = num5 ^ num7;
                    for (int k = 0; k < num2; k++)
                    {
                        if (k > 0)
                        {
                            num12 <<= 8;
                            num13 += 8;
                        }
                        array7[num11 + k] = (byte)((num16 & num12) >> num13);
                    }
                }
                else
                {
                    uint num17 = num5 ^ num7;
                    array7[num11] = (byte)(num17 & 0xFFu);
                    array7[num11 + 1] = (byte)((num17 & 0xFF00) >> 8);
                    array7[num11 + 2] = (byte)((num17 & 0xFF0000) >> 16);
                    array7[num11 + 3] = (byte)((num17 & 0xFF000000u) >> 24);
                }
                num9++;
            }
            while (num9 < num3);
            byte[] array8 = array7;
            int num18 = array8.Length / 8;
            fixed (byte* ptr = array8)
            {
                for (int l = 0; l < num18; l++)
                {
                    *(long*)(ptr + l * 8) ^= 1461082234L;
                }
            }
            @class = new Class5(new MemoryStream(array8));
            @class.method_0().Position = 0L;
            long num19 = Marshal.GetHINSTANCE(Class2.assembly_0.GetModules()[0]).ToInt64();
            int int_ = 0;
            int num20 = 0;
            if (Class2.assembly_0.Location == null || Class2.assembly_0.Location.Length == 0)
            {
                num20 = 7680;
            }
            @class.method_3();
            @class.method_3();
            int num21 = @class.method_3();
            int num22 = @class.method_3();
            if (num22 == 4)
            {
                SymmetricAlgorithm symmetricAlgorithm = Class2.smethod_7();
                symmetricAlgorithm.Mode = CipherMode.CBC;
                ICryptoTransform transform = symmetricAlgorithm.CreateDecryptor(array3, array5);
                Array.Clear(array3, 0, array3.Length);
                MemoryStream memoryStream = new MemoryStream();
                CryptoStream cryptoStream = new CryptoStream(memoryStream, transform, CryptoStreamMode.Write);
                cryptoStream.Write(array, 0, array.Length);
                cryptoStream.FlushFinalBlock();
                array8 = memoryStream.ToArray();
                Array.Clear(array5, 0, array5.Length);
                memoryStream.Close();
                cryptoStream.Close();
                @class.method_4();
                num21 = @class.method_3();
                num22 = @class.method_3();
            }
            if (num22 == 1)
            {
                IntPtr zero = IntPtr.Zero;
                zero = Class2.smethod_24(56u, 1, (uint)Process.GetCurrentProcess().Id);
                if (IntPtr.Size == 4)
                {
                    Class2.int_2 = Marshal.GetHINSTANCE(Class2.assembly_0.GetModules()[0]).ToInt32();
                }
                Class2.long_0 = Marshal.GetHINSTANCE(Class2.assembly_0.GetModules()[0]).ToInt64();
                IntPtr intptr_ = IntPtr.Zero;
                int num23 = default(int);
                do
                {
                    IntPtr intPtr = new IntPtr(Class2.long_0 + @class.method_3() - num20);
                    if (Class2.smethod_23(intPtr, 4, 4, ref int_) == 0)
                    {
                        Class2.smethod_23(intPtr, 4, 8, ref int_);
                    }
                    if (IntPtr.Size == 4)
                    {
                        Class2.smethod_22(zero, intPtr, BitConverter.GetBytes(@class.method_3()), 4u, out intptr_);
                    }
                    else
                    {
                        Class2.smethod_22(zero, intPtr, BitConverter.GetBytes(@class.method_3()), 4u, out intptr_);
                    }
                    Class2.smethod_23(intPtr, 4, int_, ref int_);
                    num23++;
                }
                while (num23 < num21);
                while (@class.method_0().Position < @class.method_0().Length - 1L)
                {
                    int num24 = @class.method_3();
                    IntPtr intptr_2 = new IntPtr(Class2.long_0 + num24 - num20);
                    int num25 = @class.method_3();
                    if (Class2.smethod_23(intptr_2, num25 * 4, 4, ref int_) == 0)
                    {
                        Class2.smethod_23(intptr_2, num25 * 4, 8, ref int_);
                    }
                    for (int m = 0; m < num25; m++)
                    {
                        Marshal.WriteInt32(new IntPtr(intptr_2.ToInt64() + m * 4), @class.method_3());
                    }
                    Class2.smethod_23(intptr_2, num25 * 4, int_, ref int_);
                }
                Class2.smethod_25(zero);
                return;
            }
            int num26 = default(int);
            do
            {
                IntPtr intPtr2 = new IntPtr(num19 + @class.method_3() - num20);
                if (Class2.smethod_23(intPtr2, 4, 4, ref int_) == 0)
                {
                    Class2.smethod_23(intPtr2, 4, 8, ref int_);
                }
                Marshal.WriteInt32(intPtr2, @class.method_3());
                Class2.smethod_23(intPtr2, 4, int_, ref int_);
                num26++;
            }
            while (num26 < num21);
            Class2.hashtable_0 = new Hashtable(@class.method_3() + 1);
            Struct3 @struct = default(Struct3);
            @struct.byte_0 = new byte[1] { 42 };
            @struct.bool_0 = false;
            Class2.hashtable_0.Add(0L, @struct);
            do
            {
                int num27 = @class.method_3() - num20;
                int num28 = @class.method_3();
                bool flag = false;
                if (num28 >= 1879048192)
                {
                    flag = true;
                }
                byte[] array9 = @class.method_1(@class.method_3());
                Struct3 struct2 = default(Struct3);
                struct2.byte_0 = array9;
                struct2.bool_0 = flag;
                Class2.hashtable_0.Add(num19 + num27, struct2);
            }
            while (@class.method_0().Position < @class.method_0().Length - 1L);
            Class2.long_1 = Marshal.GetHINSTANCE(typeof(Class2).Assembly.GetModules()[0]).ToInt64();
            if (IntPtr.Size == 4)
            {
                Class2.int_0 = Convert.ToInt32(Class2.long_1);
            }
            byte[] bytes = new byte[12]
            {
                109, 115, 99, 111, 114, 106, 105, 116, 46, 100,
                108, 108
            };
            string @string = Encoding.UTF8.GetString(bytes);
            IntPtr intPtr3 = Class2.LoadLibrary(@string);
            if (intPtr3 == IntPtr.Zero)
            {
                bytes = new byte[10] { 99, 108, 114, 106, 105, 116, 46, 100, 108, 108 };
                @string = Encoding.UTF8.GetString(bytes);
                intPtr3 = Class2.LoadLibrary(@string);
            }
            byte[] bytes2 = new byte[6] { 103, 101, 116, 74, 105, 116 };
            IntPtr ptr2 = ((Delegate3)Class2.smethod_19(Class2.GetProcAddress(intPtr3, Encoding.UTF8.GetString(bytes2)), typeof(Delegate3)))();
            long num29 = 0L;
            num29 = ((IntPtr.Size != 4) ? Marshal.ReadInt64(ptr2) : Marshal.ReadInt32(ptr2));
            Marshal.ReadIntPtr(ptr2, 0);
            Class2.delegate2_1 = new Delegate2(smethod_17);
            IntPtr zero2 = IntPtr.Zero;
            zero2 = Marshal.GetFunctionPointerForDelegate((Delegate)Class2.delegate2_1);
            long num30 = 0L;
            num30 = ((IntPtr.Size != 4) ? Marshal.ReadInt64(new IntPtr(num29)) : Marshal.ReadInt32(new IntPtr(num29)));
            Process currentProcess = Process.GetCurrentProcess();
            try
            {
                IEnumerator enumerator = currentProcess.Modules.GetEnumerator();
                try
                {
                    do
                    {
                        ProcessModule processModule2 = (ProcessModule)enumerator.Current;
                        if (processModule2.ModuleName == @string && (num30 < processModule2.BaseAddress.ToInt64() || num30 > processModule2.BaseAddress.ToInt64() + processModule2.ModuleMemorySize) && typeof(Class2).Assembly.EntryPoint != null)
                        {
                            return;
                        }
                    }
                    while (enumerator.MoveNext());
                }
                finally
                {
                    IDisposable disposable2 = enumerator as IDisposable;
                    if (disposable2 != null)
                    {
                        disposable2.Dispose();
                    }
                }
            }
            catch
            {
            }
            try
            {
                foreach (ProcessModule module in currentProcess.Modules)
                {
                    if (module.BaseAddress.ToInt64() == Class2.long_1)
                    {
                        num20 = 0;
                        break;
                    }
                }
            }
            catch
            {
            }
            Class2.delegate2_0 = null;
            try
            {
                Class2.delegate2_0 = (Delegate2)Class2.smethod_19(new IntPtr(num30), typeof(Delegate2));
            }
            catch
            {
                try
                {
                    Class2.delegate2_0 = (Delegate2)Delegate.CreateDelegate(method: Class2.smethod_19(new IntPtr(num30), typeof(Delegate2)).Method, type: typeof(Delegate2));
                }
                catch
                {
                }
            }
            int int_2 = 0;
            if (typeof(Class2).Assembly.EntryPoint != null && typeof(Class2).Assembly.EntryPoint.GetParameters().Length == 2 && typeof(Class2).Assembly.Location != null && typeof(Class2).Assembly.Location.Length > 0)
            {
                return;
            }
            try
            {
                object value = typeof(Class2).Assembly.ManifestModule.ModuleHandle.GetType().GetField("m_ptr", BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic).GetValue(typeof(Class2).Assembly.ManifestModule.ModuleHandle);
                if (value is IntPtr)
                {
                    Class2.intptr_2 = (IntPtr)value;
                }
                if (value.GetType().ToString() == "System.Reflection.RuntimeModule")
                {
                    Class2.intptr_2 = (IntPtr)value.GetType().GetField("m_pData", BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic).GetValue(value);
                }
                MemoryStream memoryStream2 = new MemoryStream();
                memoryStream2.Write(new byte[IntPtr.Size], 0, IntPtr.Size);
                if (IntPtr.Size == 4)
                {
                    memoryStream2.Write(BitConverter.GetBytes(Class2.intptr_2.ToInt32()), 0, 4);
                }
                else
                {
                    memoryStream2.Write(BitConverter.GetBytes(Class2.intptr_2.ToInt64()), 0, 8);
                }
                memoryStream2.Write(new byte[IntPtr.Size], 0, IntPtr.Size);
                memoryStream2.Write(new byte[IntPtr.Size], 0, IntPtr.Size);
                memoryStream2.Position = 0L;
                byte[] array10 = memoryStream2.ToArray();
                memoryStream2.Close();
                uint nativeSizeOfCode = 0u;
                try
                {
                    fixed (byte* value2 = array10)
                    {
                        Class2.delegate2_1(new IntPtr(value2), new IntPtr(value2), new IntPtr(value2), 216669565u, new IntPtr(value2), ref nativeSizeOfCode);
                    }
                }
                finally
                {
                }
            }
            catch
            {
            }
            RuntimeHelpers.PrepareDelegate(Class2.delegate2_0);
            RuntimeHelpers.PrepareMethod(Class2.delegate2_0.Method.MethodHandle);
            RuntimeHelpers.PrepareDelegate(Class2.delegate2_1);
            RuntimeHelpers.PrepareMethod(Class2.delegate2_1.Method.MethodHandle);
            byte[] array11 = null;
            if (IntPtr.Size != 4)
            {
                byte[] array12 = new byte[40];
                RuntimeHelpers.InitializeArray(array12, (RuntimeFieldHandle)array12);
                array11 = (byte[])/*Error near IL_22d6: Stack underflow*/;
            }
            else
            {
                byte[] array13 = new byte[30];
                RuntimeHelpers.InitializeArray(array13, (RuntimeFieldHandle)array13);
                array11 = (byte[])/*Error near IL_22ec: Stack underflow*/;
            }
            IntPtr intPtr4 = Class2.smethod_21(IntPtr.Zero, (uint)array11.Length, 4096u, 64u);
            byte[] array14 = array11;
            byte[] array15 = null;
            byte[] array16 = null;
            byte[] array17 = null;
            if (IntPtr.Size == 4)
            {
                array17 = BitConverter.GetBytes(Class2.intptr_2.ToInt32());
                array15 = BitConverter.GetBytes(zero2.ToInt32());
                array16 = BitConverter.GetBytes(Convert.ToInt32(num30));
            }
            else
            {
                array17 = BitConverter.GetBytes(Class2.intptr_2.ToInt64());
                array15 = BitConverter.GetBytes(zero2.ToInt64());
                array16 = BitConverter.GetBytes(num30);
            }
            if (IntPtr.Size == 4)
            {
                array14[9] = array17[0];
                array14[10] = array17[1];
                array14[11] = array17[2];
                array14[12] = array17[3];
                array14[16] = array16[0];
                array14[17] = array16[1];
                array14[18] = array16[2];
                array14[19] = array16[3];
                array14[23] = array15[0];
                array14[24] = array15[1];
                array14[25] = array15[2];
                array14[26] = array15[3];
            }
            else
            {
                array14[2] = array17[0];
                array14[3] = array17[1];
                array14[4] = array17[2];
                array14[5] = array17[3];
                array14[6] = array17[4];
                array14[7] = array17[5];
                array14[8] = array17[6];
                array14[9] = array17[7];
                array14[18] = array16[0];
                array14[19] = array16[1];
                array14[20] = array16[2];
                array14[21] = array16[3];
                array14[22] = array16[4];
                array14[23] = array16[5];
                array14[24] = array16[6];
                array14[25] = array16[7];
                array14[30] = array15[0];
                array14[31] = array15[1];
                array14[32] = array15[2];
                array14[33] = array15[3];
                array14[34] = array15[4];
                array14[35] = array15[5];
                array14[36] = array15[6];
                array14[37] = array15[7];
            }
            Marshal.Copy(array14, 0, intPtr4, array14.Length);
            Class2.bool_0 = false;
            Class2.smethod_23(new IntPtr(num29), IntPtr.Size, 64, ref int_2);
            Marshal.WriteIntPtr(new IntPtr(num29), intPtr4);
            Class2.smethod_23(new IntPtr(num29), IntPtr.Size, int_2, ref int_2);
        }

        internal static object oGhoVyLwi(Assembly assembly_1)
        {
            try
            {
                if (File.Exists(assembly_1.Location))
                {
                    return assembly_1.Location;
                }
            }
            catch
            {
            }
            try
            {
                if (File.Exists(assembly_1.GetName().CodeBase.ToString().Replace("file:///", "")))
                {
                    return assembly_1.GetName().CodeBase.ToString().Replace("file:///", "");
                }
            }
            catch
            {
            }
            try
            {
                if (File.Exists(assembly_1.GetType().GetProperty("Location").GetValue(assembly_1, new object[0])
                        .ToString()))
                {
                    return assembly_1.GetType().GetProperty("Location").GetValue(assembly_1, new object[0])
                        .ToString();
                }
            }
            catch
            {
            }
            return "";
        }

        [DllImport("kernel32")]
        public static extern IntPtr LoadLibrary(string string_2);

        [DllImport("kernel32", CharSet = CharSet.Ansi)]
        public static extern IntPtr GetProcAddress(IntPtr intptr_4, string string_2);

        private static IntPtr smethod_20(IntPtr intptr_4, string string_2, uint uint_1)
        {
            if (Class2.delegate4_0 == null)
            {
                Class2.delegate4_0 = (Delegate4)Marshal.GetDelegateForFunctionPointer(Class2.GetProcAddress(Class2.smethod_26(), "Find ".Trim() + "ResourceA"), typeof(Delegate4));
            }
            return Class2.delegate4_0(intptr_4, string_2, uint_1);
        }

        private static IntPtr smethod_21(IntPtr intptr_4, uint uint_1, uint uint_2, uint uint_3)
        {
            if (Class2.delegate5_0 == null)
            {
                Class2.delegate5_0 = (Delegate5)Marshal.GetDelegateForFunctionPointer(Class2.GetProcAddress(Class2.smethod_26(), "Virtual ".Trim() + "Alloc"), typeof(Delegate5));
            }
            return Class2.delegate5_0(intptr_4, uint_1, uint_2, uint_3);
        }

        private static int smethod_22(IntPtr intptr_4, IntPtr intptr_5, [In][Out] byte[] byte_2, uint uint_1, out IntPtr intptr_6)
        {
            if (Class2.delegate6_0 == null)
            {
                Class2.delegate6_0 = (Delegate6)Marshal.GetDelegateForFunctionPointer(Class2.GetProcAddress(Class2.smethod_26(), "Write ".Trim() + "Process ".Trim() + "Memory"), typeof(Delegate6));
            }
            return Class2.delegate6_0(intptr_4, intptr_5, byte_2, uint_1, out intptr_6);
        }

        private static int smethod_23(IntPtr intptr_4, int int_6, int int_7, ref int int_8)
        {
            if (Class2.delegate7_0 == null)
            {
                Class2.delegate7_0 = (Delegate7)Marshal.GetDelegateForFunctionPointer(Class2.GetProcAddress(Class2.smethod_26(), "Virtual ".Trim() + "Protect"), typeof(Delegate7));
            }
            return Class2.delegate7_0(intptr_4, int_6, int_7, ref int_8);
        }

        private static IntPtr smethod_24(uint uint_1, int int_6, uint uint_2)
        {
            if (Class2.delegate8_0 == null)
            {
                Class2.delegate8_0 = (Delegate8)Marshal.GetDelegateForFunctionPointer(Class2.GetProcAddress(Class2.smethod_26(), "Open ".Trim() + "Process"), typeof(Delegate8));
            }
            return Class2.delegate8_0(uint_1, int_6, uint_2);
        }

        private static int smethod_25(IntPtr intptr_4)
        {
            if (Class2.delegate9_0 == null)
            {
                Class2.delegate9_0 = (Delegate9)Marshal.GetDelegateForFunctionPointer(Class2.GetProcAddress(Class2.smethod_26(), "Close ".Trim() + "Handle"), typeof(Delegate9));
            }
            return Class2.delegate9_0(intptr_4);
        }

        [SpecialName]
        private static IntPtr smethod_26()
        {
            if (Class2.intptr_0 == IntPtr.Zero)
            {
                Class2.intptr_0 = Class2.LoadLibrary("kernel ".Trim() + "32.dll");
            }
            return Class2.intptr_0;
        }

        private static byte[] smethod_27(string string_2)
        {
            using FileStream fileStream = new FileStream(string_2, FileMode.Open, FileAccess.Read, FileShare.Read);
            int num = 0;
            int num2 = (int)fileStream.Length;
            byte[] array = new byte[num2];
            while (num2 > 0)
            {
                int num3 = fileStream.Read(array, num, num2);
                num += num3;
                num2 -= num3;
            }
            return array;
        }

        internal static byte[] smethod_29(Stream stream_0)
        {
            throw /*Error near IL_0001: Stack underflow*/;
        }

        private static byte[] smethod_30(byte[] byte_2)
        {
            Stream stream = new MemoryStream();
            SymmetricAlgorithm symmetricAlgorithm = Class2.smethod_7();
            byte[] array = new byte[32];
            RuntimeHelpers.InitializeArray(array, (RuntimeFieldHandle)array);
            ((SymmetricAlgorithm)/*Error near IL_002b: Stack underflow*/).Key = (byte[])(object)symmetricAlgorithm;
            byte[] array2 = new byte[16];
            RuntimeHelpers.InitializeArray(array2, (RuntimeFieldHandle)array2);
            ((SymmetricAlgorithm)/*Error near IL_0044: Stack underflow*/).IV = (byte[])(object)symmetricAlgorithm;
            CryptoStream cryptoStream = new CryptoStream(stream, symmetricAlgorithm.CreateDecryptor(), CryptoStreamMode.Write);
            cryptoStream.Write(byte_2, 0, byte_2.Length);
            cryptoStream.Close();
            return ((MemoryStream)stream).ToArray();
        }

        private unsafe static int smethod_31(string string_2)
        {
            fixed (char* ptr = string_2)
            {
                int num = 5381;
                int num2 = 5381;
                char* ptr2 = ptr;
                int num3;
                while ((num3 = *ptr2) != 0)
                {
                    num = ((num << 5) + num) ^ num3;
                    num3 = ptr2[1];
                    if (num3 == 0)
                    {
                        break;
                    }
                    num2 = ((num2 << 5) + num2) ^ num3;
                    ptr2 += 2;
                }
                return num + num2 * 1566083941;
            }
        }

        internal static bool smethod_32(string string_2, string string_3)
        {
            if (string_2 == string_3)
            {
                return true;
            }
            if (string_2 != null && string_3 != null)
            {
                bool flag = false;
                bool flag2 = false;
                int num = 0;
                int num2 = 0;
                if (string_2.StartsWith(Class2.string_0))
                {
                    flag = true;
                    num = (int)(string_2[4] | ((uint)string_2[5] << 8) | ((uint)string_2[6] << 16) | ((uint)string_2[7] << 24));
                }
                if (string_3.StartsWith(Class2.string_0))
                {
                    flag2 = true;
                    num2 = (int)(string_3[4] | ((uint)string_3[5] << 8) | ((uint)string_3[6] << 16) | ((uint)string_3[7] << 24));
                }
                if (!flag && !flag2)
                {
                    return false;
                }
                if (!flag)
                {
                    num = Class2.smethod_31(string_2);
                }
                if (!flag2)
                {
                    num2 = Class2.smethod_31(string_3);
                }
                return num == num2;
            }
            return false;
        }

        private byte[] method_2()
        {
            return null;
        }

        private byte[] method_3()
        {
            return null;
        }

        private byte[] method_4()
        {
            _ = "{11111-22222-20001-00001}".Length;
            return new byte[2] { 1, 2 };
        }

        private byte[] method_5()
        {
            _ = "{11111-22222-20001-00002}".Length;
            return new byte[2] { 1, 2 };
        }

        private byte[] uvKydBjv4()
        {
            return null;
        }

        private byte[] method_6()
        {
            return null;
        }

        internal byte[] mfvBdphXy()
        {
            _ = "{11111-22222-40001-00001}".Length;
            return new byte[2] { 1, 2 };
        }

        internal byte[] method_7()
        {
            _ = "{11111-22222-40001-00002}".Length;
            return new byte[2] { 1, 2 };
        }

        internal byte[] method_8()
        {
            _ = "{11111-22222-50001-00001}".Length;
            return new byte[2] { 1, 2 };
        }

        internal byte[] method_9()
        {
            _ = "{11111-22222-50001-00002}".Length;
            return new byte[2] { 1, 2 };
        }

        internal static bool smethod_33()
        {
            return (object)null == null;
        }

        internal static bool smethod_34()
        {
            return (object)null == null;
        }
    }
}
