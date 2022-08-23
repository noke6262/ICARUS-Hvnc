using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using System.Reflection.Emit;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Text;

namespace BirdBrainmofo
{
    internal class Class8
    {
        [StructLayout(LayoutKind.Explicit)]
        public struct Struct4
        {
            [FieldOffset(0)]
            public byte byte_0;

            [FieldOffset(0)]
            public sbyte sbyte_0;

            [FieldOffset(0)]
            public ushort ushort_0;

            [FieldOffset(0)]
            public short short_0;

            [FieldOffset(0)]
            public uint uint_0;

            [FieldOffset(0)]
            public int int_0;
        }

        private class Class21 : Class20
        {
            public Struct4 struct4_0;

            public Enum1 enum1_0;

            internal override void vmethod_10(Class19 class19_0)
            {
                this.struct4_0 = ((Class21)class19_0).struct4_0;
                this.enum1_0 = ((Class21)class19_0).enum1_0;
            }

            internal override void vmethod_2(Class19 class19_0)
            {
                this.vmethod_10(class19_0);
            }

            public Class21(bool bool_0)
            {
                base.enum4_0 = (Enum4)1;
                if (bool_0)
                {
                    this.struct4_0.int_0 = 1;
                }
                else
                {
                    this.struct4_0.int_0 = 0;
                }
                this.enum1_0 = (Enum1)11;
            }

            public Class21(Class21 class21_0)
            {
                base.enum4_0 = class21_0.enum4_0;
                this.struct4_0.int_0 = class21_0.struct4_0.int_0;
                this.enum1_0 = class21_0.enum1_0;
            }

            public override Class20 vmethod_73()
            {
                return new Class21(this);
            }

            public Class21(int int_0)
            {
                base.enum4_0 = (Enum4)1;
                this.struct4_0.int_0 = int_0;
                this.enum1_0 = (Enum1)5;
            }

            public Class21(uint uint_0)
            {
                base.enum4_0 = (Enum4)1;
                this.struct4_0.uint_0 = uint_0;
                this.enum1_0 = (Enum1)6;
            }

            public Class21(int int_0, Enum1 enum1_1)
            {
                base.enum4_0 = (Enum4)1;
                this.struct4_0.int_0 = int_0;
                this.enum1_0 = enum1_1;
            }

            public Class21(uint uint_0, Enum1 enum1_1)
            {
                base.enum4_0 = (Enum4)1;
                this.struct4_0.uint_0 = uint_0;
                this.enum1_0 = enum1_1;
            }

            public override bool vmethod_11()
            {
                switch (this.enum1_0)
                {
                    default:
                        return this.struct4_0.uint_0 == 0;
                    case (Enum1)1:
                    case (Enum1)3:
                    case (Enum1)5:
                    case (Enum1)7:
                    case (Enum1)11:
                    case (Enum1)15:
                        return this.struct4_0.int_0 == 0;
                }
            }

            public override bool vmethod_12()
            {
                return !this.vmethod_11();
            }

            public override Class19 vmethod_13(Enum1 enum1_1)
            {
                return enum1_1 switch
                {
                    (Enum1)1 => this.vmethod_15(), 
                    (Enum1)2 => this.vmethod_16(), 
                    (Enum1)3 => this.vmethod_17(), 
                    (Enum1)4 => this.vmethod_18(), 
                    (Enum1)5 => this.vmethod_19(), 
                    (Enum1)6 => this.vmethod_20(), 
                    (Enum1)11 => this.vmethod_14(), 
                    (Enum1)15 => this.method_7(), 
                    (Enum1)16 => this.vmethod_73(), 
                    _ => throw new Exception(((Enum5)4).ToString()), 
                };
            }

            internal override object vmethod_4(Type type_0)
            {
                if (type_0 != null && type_0.IsByRef)
                {
                    type_0 = type_0.GetElementType();
                }
                if (!(type_0 == null) && !(type_0 == typeof(object)))
                {
                    if (type_0 == typeof(int))
                    {
                        return this.struct4_0.int_0;
                    }
                    if (type_0 == typeof(uint))
                    {
                        return this.struct4_0.uint_0;
                    }
                    if (type_0 == typeof(short))
                    {
                        return this.struct4_0.short_0;
                    }
                    if (type_0 == typeof(ushort))
                    {
                        return this.struct4_0.ushort_0;
                    }
                    if (type_0 == typeof(byte))
                    {
                        return this.struct4_0.byte_0;
                    }
                    if (type_0 == typeof(sbyte))
                    {
                        return this.struct4_0.sbyte_0;
                    }
                    if (type_0 == typeof(bool))
                    {
                        return !this.vmethod_11();
                    }
                    if (type_0 == typeof(long))
                    {
                        return (long)this.struct4_0.int_0;
                    }
                    if (type_0 == typeof(ulong))
                    {
                        return (ulong)this.struct4_0.uint_0;
                    }
                    if (type_0 == typeof(char))
                    {
                        return (char)this.struct4_0.int_0;
                    }
                    if (type_0 == typeof(IntPtr))
                    {
                        return new IntPtr(this.struct4_0.int_0);
                    }
                    if (type_0 == typeof(UIntPtr))
                    {
                        return new UIntPtr(this.struct4_0.uint_0);
                    }
                    if (!type_0.IsEnum)
                    {
                        throw new Exception1();
                    }
                    return this.method_6(type_0);
                }
                return this.enum1_0 switch
                {
                    (Enum1)1 => this.struct4_0.sbyte_0, 
                    (Enum1)2 => this.struct4_0.byte_0, 
                    (Enum1)3 => this.struct4_0.short_0, 
                    (Enum1)4 => this.struct4_0.ushort_0, 
                    (Enum1)5 => this.struct4_0.int_0, 
                    (Enum1)6 => this.struct4_0.uint_0, 
                    (Enum1)7 => (long)this.struct4_0.int_0, 
                    (Enum1)8 => (ulong)this.struct4_0.uint_0, 
                    (Enum1)11 => this.vmethod_12(), 
                    (Enum1)15 => (char)this.struct4_0.int_0, 
                    _ => this.struct4_0.int_0, 
                };
            }

            internal object method_6(Type type_0)
            {
                Type underlyingType = Enum.GetUnderlyingType(type_0);
                if (underlyingType == typeof(int))
                {
                    return Enum.ToObject(type_0, this.struct4_0.int_0);
                }
                if (underlyingType == typeof(uint))
                {
                    return Enum.ToObject(type_0, this.struct4_0.uint_0);
                }
                if (underlyingType == typeof(short))
                {
                    return Enum.ToObject(type_0, this.struct4_0.short_0);
                }
                if (underlyingType == typeof(ushort))
                {
                    return Enum.ToObject(type_0, this.struct4_0.ushort_0);
                }
                if (underlyingType == typeof(byte))
                {
                    return Enum.ToObject(type_0, this.struct4_0.byte_0);
                }
                if (underlyingType == typeof(sbyte))
                {
                    return Enum.ToObject(type_0, this.struct4_0.sbyte_0);
                }
                if (underlyingType == typeof(long))
                {
                    return Enum.ToObject(type_0, (long)this.struct4_0.int_0);
                }
                if (underlyingType == typeof(ulong))
                {
                    return Enum.ToObject(type_0, (ulong)this.struct4_0.uint_0);
                }
                if (underlyingType == typeof(char))
                {
                    return Enum.ToObject(type_0, (ushort)this.struct4_0.int_0);
                }
                return Enum.ToObject(type_0, this.struct4_0.int_0);
            }

            public override Class21 vmethod_14()
            {
                return new Class21((!this.vmethod_11()) ? 1 : 0);
            }

            internal override bool vmethod_7()
            {
                return this.vmethod_12();
            }

            public override Class21 vmethod_15()
            {
                return new Class21(this.struct4_0.sbyte_0, (Enum1)1);
            }

            public Class21 method_7()
            {
                return new Class21(this.struct4_0.int_0, (Enum1)15);
            }

            public override Class21 vmethod_16()
            {
                return new Class21((uint)this.struct4_0.byte_0, (Enum1)2);
            }

            public override Class21 vmethod_17()
            {
                return new Class21(this.struct4_0.short_0, (Enum1)3);
            }

            public override Class21 vmethod_18()
            {
                return new Class21((uint)this.struct4_0.ushort_0, (Enum1)4);
            }

            public override Class21 vmethod_19()
            {
                return new Class21(this.struct4_0.int_0, (Enum1)5);
            }

            public override Class21 vmethod_20()
            {
                return new Class21(this.struct4_0.uint_0, (Enum1)6);
            }

            public override Class22 vmethod_21()
            {
                return new Class22(this.struct4_0.int_0, (Enum1)7);
            }

            public override Class22 vmethod_22()
            {
                return new Class22((ulong)this.struct4_0.uint_0, (Enum1)8);
            }

            public override Class21 vmethod_23()
            {
                return this.vmethod_15();
            }

            public override Class21 vmethod_24()
            {
                return this.vmethod_17();
            }

            public override Class21 vmethod_25()
            {
                return this.vmethod_19();
            }

            public override Class22 vmethod_26()
            {
                return this.vmethod_21();
            }

            public override Class21 vmethod_27()
            {
                return this.vmethod_16();
            }

            public override Class21 vmethod_28()
            {
                return this.vmethod_18();
            }

            public override Class21 vmethod_29()
            {
                return this.vmethod_20();
            }

            public override Class22 vmethod_30()
            {
                return this.vmethod_22();
            }

            public override Class21 vmethod_31()
            {
                return new Class21(checked((sbyte)this.struct4_0.int_0), (Enum1)1);
            }

            public override Class21 vmethod_32()
            {
                return new Class21(checked((sbyte)this.struct4_0.uint_0), (Enum1)1);
            }

            public override Class21 vmethod_33()
            {
                return new Class21(checked((short)this.struct4_0.int_0), (Enum1)3);
            }

            public override Class21 vmethod_34()
            {
                return new Class21(checked((short)this.struct4_0.uint_0), (Enum1)3);
            }

            public override Class21 vmethod_35()
            {
                return new Class21(this.struct4_0.int_0, (Enum1)5);
            }

            public override Class21 vmethod_36()
            {
                return new Class21(checked((int)this.struct4_0.uint_0), (Enum1)5);
            }

            public override Class22 vmethod_37()
            {
                return new Class22(this.struct4_0.int_0, (Enum1)7);
            }

            public override Class22 vmethod_38()
            {
                return new Class22(this.struct4_0.uint_0, (Enum1)7);
            }

            public override Class21 vmethod_39()
            {
                return new Class21(checked((byte)this.struct4_0.int_0), (Enum1)2);
            }

            public override Class21 vmethod_40()
            {
                return new Class21(checked((byte)this.struct4_0.uint_0), (Enum1)2);
            }

            public override Class21 vmethod_41()
            {
                return new Class21(checked((ushort)this.struct4_0.int_0), (Enum1)4);
            }

            public override Class21 vmethod_42()
            {
                return new Class21(checked((ushort)this.struct4_0.uint_0), (Enum1)4);
            }

            public override Class21 vmethod_43()
            {
                return new Class21(checked((uint)this.struct4_0.int_0), (Enum1)6);
            }

            public override Class21 vmethod_44()
            {
                return new Class21(this.struct4_0.uint_0, (Enum1)6);
            }

            public override Class22 vmethod_45()
            {
                return new Class22(checked((ulong)this.struct4_0.int_0), (Enum1)8);
            }

            public override Class22 vmethod_46()
            {
                return new Class22((ulong)this.struct4_0.uint_0, (Enum1)8);
            }

            public override Class24 vmethod_47()
            {
                return new Class24(this.struct4_0.int_0);
            }

            public override Class24 vmethod_48()
            {
                return new Class24((double)this.struct4_0.int_0);
            }

            public override Class24 vmethod_49()
            {
                return new Class24((double)this.struct4_0.uint_0);
            }

            public override Class23 vmethod_50()
            {
                if (IntPtr.Size == 8)
                {
                    return new Class23(this.vmethod_26().struct5_0.long_0);
                }
                return new Class23(this.vmethod_25().struct4_0.int_0);
            }

            public override Class23 vmethod_51()
            {
                if (IntPtr.Size == 8)
                {
                    return new Class23(this.vmethod_30().struct5_0.ulong_0);
                }
                return new Class23((ulong)this.vmethod_29().struct4_0.uint_0);
            }

            public override Class23 vmethod_52()
            {
                if (IntPtr.Size == 8)
                {
                    return new Class23(this.vmethod_37().struct5_0.long_0);
                }
                return new Class23(this.vmethod_35().struct4_0.int_0);
            }

            public override Class23 vmethod_53()
            {
                if (IntPtr.Size == 8)
                {
                    return new Class23(this.vmethod_45().struct5_0.ulong_0);
                }
                return new Class23((ulong)this.vmethod_43().struct4_0.uint_0);
            }

            public override Class23 vmethod_54()
            {
                if (IntPtr.Size == 8)
                {
                    return new Class23(this.vmethod_38().struct5_0.long_0);
                }
                return new Class23(this.vmethod_36().struct4_0.int_0);
            }

            public override Class23 vmethod_55()
            {
                if (IntPtr.Size == 8)
                {
                    return new Class23(this.vmethod_46().struct5_0.ulong_0);
                }
                return new Class23((ulong)this.vmethod_44().struct4_0.uint_0);
            }

            public override Class19 vmethod_56()
            {
                switch (this.enum1_0)
                {
                    default:
                        return new Class21((int)(0L - (long)this.struct4_0.uint_0));
                    case (Enum1)1:
                    case (Enum1)3:
                    case (Enum1)5:
                    case (Enum1)11:
                    case (Enum1)15:
                        return new Class21(-this.struct4_0.int_0);
                }
            }

            public override Class19 Add(Class19 class19_0)
            {
                if (class19_0.vmethod_0())
                {
                    class19_0 = class19_0.vmethod_8();
                }
                if (class19_0.method_1())
                {
                    return new Class21(this.struct4_0.int_0 + ((Class21)class19_0).struct4_0.int_0);
                }
                if (!class19_0.method_2())
                {
                    throw new Exception1();
                }
                return ((Class23)class19_0).Add(this);
            }

            public override Class19 vmethod_57(Class19 class19_0)
            {
                if (class19_0.vmethod_0())
                {
                    class19_0 = class19_0.vmethod_8();
                }
                if (class19_0.method_1())
                {
                    return new Class21(checked(this.struct4_0.int_0 + ((Class21)class19_0).struct4_0.int_0));
                }
                if (!class19_0.method_2())
                {
                    throw new Exception1();
                }
                return ((Class23)class19_0).vmethod_57(this);
            }

            public override Class19 vmethod_58(Class19 class19_0)
            {
                if (class19_0.vmethod_0())
                {
                    class19_0 = class19_0.vmethod_8();
                }
                if (class19_0.method_1())
                {
                    return new Class21(checked(this.struct4_0.uint_0 + ((Class21)class19_0).struct4_0.uint_0));
                }
                if (!class19_0.method_2())
                {
                    throw new Exception1();
                }
                return ((Class23)class19_0).vmethod_58(this);
            }

            public override Class19 vmethod_59(Class19 class19_0)
            {
                if (class19_0.vmethod_0())
                {
                    class19_0 = class19_0.vmethod_8();
                }
                if (class19_0.method_1())
                {
                    return new Class21(this.struct4_0.int_0 - ((Class21)class19_0).struct4_0.int_0);
                }
                if (!class19_0.method_2())
                {
                    throw new Exception1();
                }
                return ((Class23)class19_0).method_8(this);
            }

            public override Class19 vmethod_60(Class19 class19_0)
            {
                if (class19_0.vmethod_0())
                {
                    class19_0 = class19_0.vmethod_8();
                }
                if (class19_0.method_1())
                {
                    return new Class21(checked(this.struct4_0.int_0 - ((Class21)class19_0).struct4_0.int_0));
                }
                if (!class19_0.method_2())
                {
                    throw new Exception1();
                }
                return ((Class23)class19_0).method_9(this);
            }

            public override Class19 vmethod_61(Class19 class19_0)
            {
                if (class19_0.vmethod_0())
                {
                    class19_0 = class19_0.vmethod_8();
                }
                if (class19_0.method_1())
                {
                    return new Class21(checked(this.struct4_0.uint_0 - ((Class21)class19_0).struct4_0.uint_0));
                }
                if (!class19_0.method_2())
                {
                    throw new Exception1();
                }
                return ((Class23)class19_0).method_10(this);
            }

            public override Class19 vmethod_62(Class19 class19_0)
            {
                if (class19_0.vmethod_0())
                {
                    class19_0 = class19_0.vmethod_8();
                }
                if (class19_0.method_1())
                {
                    return new Class21(this.struct4_0.int_0 * ((Class21)class19_0).struct4_0.int_0);
                }
                if (!class19_0.method_2())
                {
                    throw new Exception1();
                }
                return ((Class23)class19_0).vmethod_62(this);
            }

            public override Class19 vmethod_63(Class19 class19_0)
            {
                if (class19_0.vmethod_0())
                {
                    class19_0 = class19_0.vmethod_8();
                }
                if (class19_0.method_1())
                {
                    return new Class21(checked(this.struct4_0.int_0 * ((Class21)class19_0).struct4_0.int_0));
                }
                if (!class19_0.method_2())
                {
                    throw new Exception1();
                }
                return ((Class23)class19_0).vmethod_63(this);
            }

            public override Class19 vmethod_64(Class19 class19_0)
            {
                if (class19_0.vmethod_0())
                {
                    class19_0 = class19_0.vmethod_8();
                }
                if (class19_0.method_1())
                {
                    return new Class21(checked(this.struct4_0.uint_0 * ((Class21)class19_0).struct4_0.uint_0));
                }
                if (!class19_0.method_2())
                {
                    throw new Exception1();
                }
                return ((Class23)class19_0).vmethod_64(this);
            }

            public override Class19 vmethod_65(Class19 class19_0)
            {
                if (class19_0.vmethod_0())
                {
                    class19_0 = class19_0.vmethod_8();
                }
                if (class19_0.method_1())
                {
                    return new Class21(this.struct4_0.int_0 / ((Class21)class19_0).struct4_0.int_0);
                }
                if (!class19_0.method_2())
                {
                    throw new Exception1();
                }
                return ((Class23)class19_0).method_11(this);
            }

            public override Class19 vmethod_66(Class19 class19_0)
            {
                if (class19_0.vmethod_0())
                {
                    class19_0 = class19_0.vmethod_8();
                }
                if (class19_0.method_1())
                {
                    return new Class21(this.struct4_0.uint_0 / ((Class21)class19_0).struct4_0.uint_0);
                }
                if (!class19_0.method_2())
                {
                    throw new Exception1();
                }
                return ((Class23)class19_0).method_12(this);
            }

            public override Class19 vmethod_67(Class19 class19_0)
            {
                if (class19_0.vmethod_0())
                {
                    class19_0 = class19_0.vmethod_8();
                }
                if (class19_0.method_1())
                {
                    return new Class21(this.struct4_0.int_0 % ((Class21)class19_0).struct4_0.int_0);
                }
                if (!class19_0.method_2())
                {
                    throw new Exception1();
                }
                return ((Class23)class19_0).method_13(this);
            }

            public override Class19 vmethod_68(Class19 class19_0)
            {
                if (class19_0.vmethod_0())
                {
                    class19_0 = class19_0.vmethod_8();
                }
                if (class19_0.method_1())
                {
                    return new Class21(this.struct4_0.uint_0 % ((Class21)class19_0).struct4_0.uint_0);
                }
                if (!class19_0.method_2())
                {
                    throw new Exception1();
                }
                return ((Class23)class19_0).method_14(this);
            }

            public override Class19 vmethod_69(Class19 class19_0)
            {
                if (class19_0.vmethod_0())
                {
                    class19_0 = class19_0.vmethod_8();
                }
                if (class19_0.method_1())
                {
                    return new Class21(this.struct4_0.int_0 & ((Class21)class19_0).struct4_0.int_0);
                }
                if (!class19_0.method_2())
                {
                    throw new Exception1();
                }
                return ((Class23)class19_0).vmethod_69(this);
            }

            public override Class19 vmethod_70(Class19 class19_0)
            {
                if (class19_0.vmethod_0())
                {
                    class19_0 = class19_0.vmethod_8();
                }
                if (class19_0.method_1())
                {
                    return new Class21(this.struct4_0.int_0 | ((Class21)class19_0).struct4_0.int_0);
                }
                if (!class19_0.method_2())
                {
                    throw new Exception1();
                }
                return ((Class23)class19_0).vmethod_70(this);
            }

            public override Class19 vmethod_71()
            {
                return new Class21(~this.struct4_0.int_0);
            }

            public override Class19 vmethod_72(Class19 class19_0)
            {
                if (class19_0.vmethod_0())
                {
                    class19_0 = class19_0.vmethod_8();
                }
                if (class19_0.method_1())
                {
                    return new Class21(this.struct4_0.int_0 ^ ((Class21)class19_0).struct4_0.int_0);
                }
                if (!class19_0.method_2())
                {
                    throw new Exception1();
                }
                return ((Class23)class19_0).vmethod_72(this);
            }

            public override Class19 vmethod_74(Class19 class19_0)
            {
                if (class19_0.vmethod_0())
                {
                    class19_0 = class19_0.vmethod_8();
                }
                if (class19_0.method_1())
                {
                    return new Class21(this.struct4_0.int_0 << ((Class21)class19_0).struct4_0.int_0);
                }
                if (!class19_0.method_2())
                {
                    throw new Exception1();
                }
                return ((Class23)class19_0).method_17(this);
            }

            public override Class19 vmethod_75(Class19 class19_0)
            {
                if (class19_0.vmethod_0())
                {
                    class19_0 = class19_0.vmethod_8();
                }
                if (class19_0.method_1())
                {
                    return new Class21(this.struct4_0.int_0 >> ((Class21)class19_0).struct4_0.int_0);
                }
                if (!class19_0.method_2())
                {
                    throw new Exception1();
                }
                return ((Class23)class19_0).method_16(this);
            }

            public override Class19 vmethod_76(Class19 class19_0)
            {
                if (class19_0.vmethod_0())
                {
                    class19_0 = class19_0.vmethod_8();
                }
                if (class19_0.method_1())
                {
                    return new Class21(this.struct4_0.uint_0 >> ((Class21)class19_0).struct4_0.int_0);
                }
                if (!class19_0.method_2())
                {
                    throw new Exception1();
                }
                return ((Class23)class19_0).method_15(this);
            }

            public override string ToString()
            {
                switch (this.enum1_0)
                {
                    default:
                        return this.struct4_0.uint_0.ToString();
                    case (Enum1)1:
                    case (Enum1)3:
                    case (Enum1)5:
                    case (Enum1)11:
                        return this.struct4_0.int_0.ToString();
                }
            }

            internal override Class19 vmethod_8()
            {
                return this;
            }

            internal override bool vmethod_9()
            {
                return true;
            }

            internal override bool vmethod_5(Class19 class19_0)
            {
                if (class19_0.method_0())
                {
                    return ((Class31)class19_0).vmethod_5(this);
                }
                if (class19_0.vmethod_0())
                {
                    return ((Class25)class19_0).vmethod_5(this);
                }
                Class19 @class = class19_0.vmethod_8();
                if (!@class.vmethod_9())
                {
                    return false;
                }
                if (@class.method_3())
                {
                    return false;
                }
                if (@class.method_1())
                {
                    return this.struct4_0.int_0 == ((Class21)@class).struct4_0.int_0;
                }
                return ((Class23)@class).vmethod_5(this);
            }

            private static Class20 smethod_4(Class19 class19_0)
            {
                Class20 @class = class19_0 as Class20;
                if (@class == null && class19_0.vmethod_0())
                {
                    @class = class19_0.vmethod_8() as Class20;
                }
                return @class;
            }

            internal override bool vmethod_6(Class19 class19_0)
            {
                if (class19_0.method_0())
                {
                    return false;
                }
                if (class19_0.vmethod_0())
                {
                    return ((Class25)class19_0).vmethod_6(this);
                }
                Class19 @class = class19_0.vmethod_8();
                if (!@class.vmethod_9())
                {
                    return false;
                }
                if (@class.method_3())
                {
                    return false;
                }
                if (@class.method_1())
                {
                    return this.struct4_0.uint_0 != ((Class21)@class).struct4_0.uint_0;
                }
                return ((Class23)@class).vmethod_6(this);
            }

            public override bool vmethod_77(Class19 class19_0)
            {
                if (class19_0.vmethod_0())
                {
                    class19_0 = class19_0.vmethod_8();
                }
                if (class19_0.method_1())
                {
                    return this.struct4_0.int_0 >= ((Class21)class19_0).struct4_0.int_0;
                }
                if (!class19_0.method_2())
                {
                    throw new Exception1();
                }
                return ((Class23)class19_0).vmethod_81(this);
            }

            public override bool vmethod_78(Class19 class19_0)
            {
                if (class19_0.vmethod_0())
                {
                    class19_0 = class19_0.vmethod_8();
                }
                if (class19_0.method_1())
                {
                    return this.struct4_0.uint_0 >= ((Class21)class19_0).struct4_0.uint_0;
                }
                if (!class19_0.method_2())
                {
                    throw new Exception1();
                }
                return ((Class23)class19_0).vTminFdwf1(this);
            }

            public override bool vmethod_79(Class19 class19_0)
            {
                if (class19_0.vmethod_0())
                {
                    class19_0 = class19_0.vmethod_8();
                }
                if (class19_0.method_1())
                {
                    return this.struct4_0.int_0 > ((Class21)class19_0).struct4_0.int_0;
                }
                if (!class19_0.method_2())
                {
                    throw new Exception1();
                }
                return ((Class23)class19_0).vmethod_82(this);
            }

            public override bool vmethod_80(Class19 class19_0)
            {
                if (class19_0.vmethod_0())
                {
                    class19_0 = class19_0.vmethod_8();
                }
                if (class19_0.method_1())
                {
                    return this.struct4_0.uint_0 > ((Class21)class19_0).struct4_0.uint_0;
                }
                if (!class19_0.method_2())
                {
                    throw new Exception1();
                }
                return ((Class23)class19_0).vmethod_83(this);
            }

            public override bool vmethod_81(Class19 class19_0)
            {
                if (class19_0.vmethod_0())
                {
                    class19_0 = class19_0.vmethod_8();
                }
                if (class19_0.method_1())
                {
                    return this.struct4_0.int_0 <= ((Class21)class19_0).struct4_0.int_0;
                }
                if (!class19_0.method_2())
                {
                    throw new Exception1();
                }
                return ((Class23)class19_0).vmethod_77(this);
            }

            public override bool vTminFdwf1(Class19 class19_0)
            {
                if (class19_0.vmethod_0())
                {
                    class19_0 = class19_0.vmethod_8();
                }
                if (class19_0.method_1())
                {
                    return this.struct4_0.uint_0 <= ((Class21)class19_0).struct4_0.uint_0;
                }
                if (!class19_0.method_2())
                {
                    throw new Exception1();
                }
                return ((Class23)class19_0).vmethod_78(this);
            }

            public override bool vmethod_82(Class19 class19_0)
            {
                if (class19_0.vmethod_0())
                {
                    class19_0 = class19_0.vmethod_8();
                }
                if (class19_0.method_1())
                {
                    return this.struct4_0.int_0 < ((Class21)class19_0).struct4_0.int_0;
                }
                if (!class19_0.method_2())
                {
                    throw new Exception1();
                }
                return ((Class23)class19_0).vmethod_79(this);
            }

            public override bool vmethod_83(Class19 class19_0)
            {
                if (class19_0.vmethod_0())
                {
                    class19_0 = class19_0.vmethod_8();
                }
                if (class19_0.method_1())
                {
                    return this.struct4_0.uint_0 < ((Class21)class19_0).struct4_0.uint_0;
                }
                if (!class19_0.method_2())
                {
                    throw new Exception1();
                }
                return ((Class23)class19_0).vmethod_80(this);
            }
        }

        [StructLayout(LayoutKind.Explicit)]
        private struct Struct5
        {
            [FieldOffset(0)]
            public byte byte_0;

            [FieldOffset(0)]
            public sbyte sbyte_0;

            [FieldOffset(0)]
            public ushort ushort_0;

            [FieldOffset(0)]
            public short short_0;

            [FieldOffset(0)]
            public uint uint_0;

            [FieldOffset(0)]
            public int int_0;

            [FieldOffset(0)]
            public ulong ulong_0;

            [FieldOffset(0)]
            public long long_0;
        }

        private class Class22 : Class20
        {
            public Struct5 struct5_0;

            public Enum1 enum1_0;

            internal override void vmethod_10(Class19 class19_0)
            {
                this.struct5_0 = ((Class22)class19_0).struct5_0;
                this.enum1_0 = ((Class22)class19_0).enum1_0;
            }

            internal override void vmethod_2(Class19 class19_0)
            {
                this.vmethod_10(class19_0);
            }

            public Class22(long long_0)
            {
                base.enum4_0 = (Enum4)2;
                this.struct5_0.long_0 = long_0;
                this.enum1_0 = (Enum1)7;
            }

            public Class22(Class22 class22_0)
            {
                base.enum4_0 = class22_0.enum4_0;
                this.struct5_0.long_0 = class22_0.struct5_0.long_0;
                this.enum1_0 = class22_0.enum1_0;
            }

            public override Class20 vmethod_73()
            {
                return new Class22(this);
            }

            public Class22(long long_0, Enum1 enum1_1)
            {
                base.enum4_0 = (Enum4)2;
                this.struct5_0.long_0 = long_0;
                this.enum1_0 = enum1_1;
            }

            public Class22(ulong ulong_0)
            {
                base.enum4_0 = (Enum4)2;
                this.struct5_0.ulong_0 = ulong_0;
                this.enum1_0 = (Enum1)8;
            }

            public Class22(ulong ulong_0, Enum1 enum1_1)
            {
                base.enum4_0 = (Enum4)2;
                this.struct5_0.ulong_0 = ulong_0;
                this.enum1_0 = enum1_1;
            }

            public override bool vmethod_11()
            {
                if (this.enum1_0 == (Enum1)7)
                {
                    return this.struct5_0.long_0 == 0L;
                }
                return this.struct5_0.ulong_0 == 0L;
            }

            public override bool vmethod_12()
            {
                return !this.vmethod_11();
            }

            public override Class19 vmethod_13(Enum1 enum1_1)
            {
                return enum1_1 switch
                {
                    (Enum1)1 => this.vmethod_15(), 
                    (Enum1)2 => this.vmethod_16(), 
                    (Enum1)3 => this.vmethod_17(), 
                    (Enum1)4 => this.vmethod_18(), 
                    (Enum1)5 => this.vmethod_19(), 
                    (Enum1)6 => this.vmethod_20(), 
                    (Enum1)7 => this.vmethod_21(), 
                    (Enum1)8 => this.vmethod_22(), 
                    (Enum1)11 => this.vmethod_14(), 
                    (Enum1)15 => this.method_7(), 
                    (Enum1)16 => this.vmethod_73(), 
                    _ => throw new Exception(((Enum5)4).ToString()), 
                };
            }

            internal override object vmethod_4(Type type_0)
            {
                if (type_0 != null && type_0.IsByRef)
                {
                    type_0 = type_0.GetElementType();
                }
                if (!(type_0 == null) && !(type_0 == typeof(object)))
                {
                    if (type_0 == typeof(int))
                    {
                        return this.struct5_0.int_0;
                    }
                    if (type_0 == typeof(uint))
                    {
                        return this.struct5_0.uint_0;
                    }
                    if (type_0 == typeof(short))
                    {
                        return this.struct5_0.short_0;
                    }
                    if (type_0 == typeof(ushort))
                    {
                        return this.struct5_0.ushort_0;
                    }
                    if (type_0 == typeof(byte))
                    {
                        return this.struct5_0.byte_0;
                    }
                    if (type_0 == typeof(sbyte))
                    {
                        return this.struct5_0.sbyte_0;
                    }
                    if (type_0 == typeof(bool))
                    {
                        return !this.vmethod_11();
                    }
                    if (type_0 == typeof(long))
                    {
                        return this.struct5_0.long_0;
                    }
                    if (type_0 == typeof(ulong))
                    {
                        return this.struct5_0.ulong_0;
                    }
                    if (type_0 == typeof(char))
                    {
                        return (char)this.struct5_0.long_0;
                    }
                    if (!type_0.IsEnum)
                    {
                        throw new Exception1();
                    }
                    return this.method_6(type_0);
                }
                return this.enum1_0 switch
                {
                    (Enum1)1 => this.struct5_0.sbyte_0, 
                    (Enum1)2 => this.struct5_0.byte_0, 
                    (Enum1)3 => this.struct5_0.short_0, 
                    (Enum1)4 => this.struct5_0.ushort_0, 
                    (Enum1)5 => this.struct5_0.int_0, 
                    (Enum1)6 => this.struct5_0.uint_0, 
                    (Enum1)7 => this.struct5_0.long_0, 
                    (Enum1)8 => this.struct5_0.ulong_0, 
                    (Enum1)11 => this.vmethod_12(), 
                    (Enum1)15 => (char)this.struct5_0.int_0, 
                    _ => this.struct5_0.long_0, 
                };
            }

            internal object method_6(Type type_0)
            {
                Type underlyingType = Enum.GetUnderlyingType(type_0);
                if (underlyingType == typeof(int))
                {
                    return Enum.ToObject(type_0, this.struct5_0.int_0);
                }
                if (underlyingType == typeof(uint))
                {
                    return Enum.ToObject(type_0, this.struct5_0.uint_0);
                }
                if (underlyingType == typeof(short))
                {
                    return Enum.ToObject(type_0, this.struct5_0.short_0);
                }
                if (underlyingType == typeof(ushort))
                {
                    return Enum.ToObject(type_0, this.struct5_0.ushort_0);
                }
                if (underlyingType == typeof(byte))
                {
                    return Enum.ToObject(type_0, this.struct5_0.byte_0);
                }
                if (underlyingType == typeof(sbyte))
                {
                    return Enum.ToObject(type_0, this.struct5_0.sbyte_0);
                }
                if (underlyingType == typeof(long))
                {
                    return Enum.ToObject(type_0, this.struct5_0.long_0);
                }
                if (underlyingType == typeof(ulong))
                {
                    return Enum.ToObject(type_0, this.struct5_0.ulong_0);
                }
                if (underlyingType == typeof(char))
                {
                    return Enum.ToObject(type_0, (ushort)this.struct5_0.int_0);
                }
                return Enum.ToObject(type_0, this.struct5_0.long_0);
            }

            public override Class21 vmethod_14()
            {
                return new Class21((!this.vmethod_11()) ? 1 : 0);
            }

            internal override bool vmethod_7()
            {
                return this.vmethod_12();
            }

            public Class21 method_7()
            {
                return new Class21(this.struct5_0.sbyte_0, (Enum1)15);
            }

            public override Class21 vmethod_15()
            {
                return new Class21(this.struct5_0.sbyte_0, (Enum1)1);
            }

            public override Class21 vmethod_16()
            {
                return new Class21((uint)this.struct5_0.byte_0, (Enum1)2);
            }

            public override Class21 vmethod_17()
            {
                return new Class21(this.struct5_0.short_0, (Enum1)3);
            }

            public override Class21 vmethod_18()
            {
                return new Class21((uint)this.struct5_0.ushort_0, (Enum1)4);
            }

            public override Class21 vmethod_19()
            {
                return new Class21(this.struct5_0.int_0, (Enum1)5);
            }

            public override Class21 vmethod_20()
            {
                return new Class21(this.struct5_0.uint_0, (Enum1)6);
            }

            public override Class22 vmethod_21()
            {
                return new Class22(this.struct5_0.long_0, (Enum1)7);
            }

            public override Class22 vmethod_22()
            {
                return new Class22(this.struct5_0.ulong_0, (Enum1)8);
            }

            public override Class21 vmethod_23()
            {
                return this.vmethod_15();
            }

            public override Class21 vmethod_24()
            {
                return this.vmethod_17();
            }

            public override Class21 vmethod_25()
            {
                return this.vmethod_19();
            }

            public override Class22 vmethod_26()
            {
                return this.vmethod_21();
            }

            public override Class21 vmethod_27()
            {
                return this.vmethod_16();
            }

            public override Class21 vmethod_28()
            {
                return this.vmethod_18();
            }

            public override Class21 vmethod_29()
            {
                return this.vmethod_20();
            }

            public override Class22 vmethod_30()
            {
                return this.vmethod_22();
            }

            public override Class21 vmethod_31()
            {
                return new Class21(checked((sbyte)this.struct5_0.long_0), (Enum1)1);
            }

            public override Class21 vmethod_32()
            {
                return new Class21(checked((sbyte)this.struct5_0.ulong_0), (Enum1)1);
            }

            public override Class21 vmethod_33()
            {
                return new Class21(checked((short)this.struct5_0.long_0), (Enum1)3);
            }

            public override Class21 vmethod_34()
            {
                return new Class21(checked((short)this.struct5_0.ulong_0), (Enum1)3);
            }

            public override Class21 vmethod_35()
            {
                return new Class21(checked((int)this.struct5_0.long_0), (Enum1)5);
            }

            public override Class21 vmethod_36()
            {
                return new Class21(checked((int)this.struct5_0.ulong_0), (Enum1)5);
            }

            public override Class22 vmethod_37()
            {
                return new Class22(this.struct5_0.long_0, (Enum1)7);
            }

            public override Class22 vmethod_38()
            {
                return new Class22(checked((long)this.struct5_0.ulong_0), (Enum1)7);
            }

            public override Class21 vmethod_39()
            {
                return new Class21(checked((byte)this.struct5_0.long_0), (Enum1)2);
            }

            public override Class21 vmethod_40()
            {
                return new Class21(checked((byte)this.struct5_0.ulong_0), (Enum1)2);
            }

            public override Class21 vmethod_41()
            {
                return new Class21(checked((ushort)this.struct5_0.long_0), (Enum1)4);
            }

            public override Class21 vmethod_42()
            {
                return new Class21(checked((ushort)this.struct5_0.ulong_0), (Enum1)4);
            }

            public override Class21 vmethod_43()
            {
                return new Class21(checked((uint)this.struct5_0.long_0), (Enum1)6);
            }

            public override Class21 vmethod_44()
            {
                return new Class21(checked((uint)this.struct5_0.ulong_0), (Enum1)6);
            }

            public override Class22 vmethod_45()
            {
                return new Class22(checked((ulong)this.struct5_0.long_0), (Enum1)8);
            }

            public override Class22 vmethod_46()
            {
                return new Class22(this.struct5_0.ulong_0, (Enum1)8);
            }

            public override Class24 vmethod_47()
            {
                return new Class24(this.struct5_0.long_0);
            }

            public override Class24 vmethod_48()
            {
                return new Class24((double)this.struct5_0.long_0);
            }

            public override Class24 vmethod_49()
            {
                return new Class24((double)this.struct5_0.ulong_0);
            }

            public override Class23 vmethod_50()
            {
                if (IntPtr.Size == 8)
                {
                    return new Class23(this.vmethod_26().struct5_0.long_0);
                }
                return new Class23(this.vmethod_25().struct4_0.int_0);
            }

            public override Class23 vmethod_51()
            {
                if (IntPtr.Size == 8)
                {
                    return new Class23(this.vmethod_30().struct5_0.ulong_0);
                }
                return new Class23((ulong)this.vmethod_29().struct4_0.uint_0);
            }

            public override Class23 vmethod_52()
            {
                if (IntPtr.Size == 8)
                {
                    return new Class23(this.vmethod_37().struct5_0.long_0);
                }
                return new Class23(this.vmethod_35().struct4_0.int_0);
            }

            public override Class23 vmethod_53()
            {
                if (IntPtr.Size == 8)
                {
                    return new Class23(this.vmethod_45().struct5_0.ulong_0);
                }
                return new Class23((ulong)this.vmethod_43().struct4_0.uint_0);
            }

            public override Class23 vmethod_54()
            {
                if (IntPtr.Size == 8)
                {
                    return new Class23(this.vmethod_38().struct5_0.long_0);
                }
                return new Class23(this.vmethod_36().struct4_0.int_0);
            }

            public override Class23 vmethod_55()
            {
                if (IntPtr.Size == 8)
                {
                    return new Class23(this.struct5_0.ulong_0);
                }
                return new Class23((ulong)checked((uint)this.struct5_0.ulong_0));
            }

            public override Class19 vmethod_56()
            {
                return new Class22(-this.struct5_0.long_0);
            }

            public override Class19 Add(Class19 class19_0)
            {
                if (class19_0.vmethod_0())
                {
                    class19_0 = class19_0.vmethod_8();
                }
                if (!class19_0.method_3())
                {
                    throw new Exception1();
                }
                return new Class22(this.struct5_0.long_0 + ((Class22)class19_0).struct5_0.long_0);
            }

            public override Class19 vmethod_57(Class19 class19_0)
            {
                if (class19_0.vmethod_0())
                {
                    class19_0 = class19_0.vmethod_8();
                }
                if (!class19_0.method_3())
                {
                    throw new Exception1();
                }
                return new Class22(checked(this.struct5_0.long_0 + ((Class22)class19_0).struct5_0.long_0));
            }

            public override Class19 vmethod_58(Class19 class19_0)
            {
                if (class19_0.vmethod_0())
                {
                    class19_0 = class19_0.vmethod_8();
                }
                if (!class19_0.method_3())
                {
                    throw new Exception1();
                }
                return new Class22(checked(this.struct5_0.ulong_0 + ((Class22)class19_0).struct5_0.ulong_0));
            }

            public override Class19 vmethod_59(Class19 class19_0)
            {
                if (class19_0.vmethod_0())
                {
                    class19_0 = class19_0.vmethod_8();
                }
                if (!class19_0.method_3())
                {
                    throw new Exception1();
                }
                return new Class22(this.struct5_0.long_0 - ((Class22)class19_0).struct5_0.long_0);
            }

            public override Class19 vmethod_60(Class19 class19_0)
            {
                if (class19_0.vmethod_0())
                {
                    class19_0 = class19_0.vmethod_8();
                }
                if (!class19_0.method_3())
                {
                    throw new Exception1();
                }
                return new Class22(checked(this.struct5_0.long_0 - ((Class22)class19_0).struct5_0.long_0));
            }

            public override Class19 vmethod_61(Class19 class19_0)
            {
                if (class19_0.vmethod_0())
                {
                    class19_0 = class19_0.vmethod_8();
                }
                if (!class19_0.method_3())
                {
                    throw new Exception1();
                }
                return new Class22(checked(this.struct5_0.ulong_0 - ((Class22)class19_0).struct5_0.ulong_0));
            }

            public override Class19 vmethod_62(Class19 class19_0)
            {
                if (class19_0.vmethod_0())
                {
                    class19_0 = class19_0.vmethod_8();
                }
                if (!class19_0.method_3())
                {
                    throw new Exception1();
                }
                return new Class22(this.struct5_0.long_0 * ((Class22)class19_0).struct5_0.long_0);
            }

            public override Class19 vmethod_63(Class19 class19_0)
            {
                if (class19_0.vmethod_0())
                {
                    class19_0 = class19_0.vmethod_8();
                }
                if (!class19_0.method_3())
                {
                    throw new Exception1();
                }
                return new Class22(checked(this.struct5_0.long_0 * ((Class22)class19_0).struct5_0.long_0));
            }

            public override Class19 vmethod_64(Class19 class19_0)
            {
                if (class19_0.vmethod_0())
                {
                    class19_0 = class19_0.vmethod_8();
                }
                if (!class19_0.method_3())
                {
                    throw new Exception1();
                }
                return new Class22(checked(this.struct5_0.ulong_0 * ((Class22)class19_0).struct5_0.ulong_0));
            }

            public override Class19 vmethod_65(Class19 class19_0)
            {
                if (class19_0.vmethod_0())
                {
                    class19_0 = class19_0.vmethod_8();
                }
                if (!class19_0.method_3())
                {
                    throw new Exception1();
                }
                return new Class22(this.struct5_0.long_0 / ((Class22)class19_0).struct5_0.long_0);
            }

            public override Class19 vmethod_66(Class19 class19_0)
            {
                if (class19_0.vmethod_0())
                {
                    class19_0 = class19_0.vmethod_8();
                }
                if (!class19_0.method_3())
                {
                    throw new Exception1();
                }
                return new Class22(this.struct5_0.ulong_0 / ((Class22)class19_0).struct5_0.ulong_0);
            }

            public override Class19 vmethod_67(Class19 class19_0)
            {
                if (class19_0.vmethod_0())
                {
                    class19_0 = class19_0.vmethod_8();
                }
                if (!class19_0.method_3())
                {
                    throw new Exception1();
                }
                return new Class22(this.struct5_0.long_0 % ((Class22)class19_0).struct5_0.long_0);
            }

            public override Class19 vmethod_68(Class19 class19_0)
            {
                if (class19_0.vmethod_0())
                {
                    class19_0 = class19_0.vmethod_8();
                }
                if (!class19_0.method_3())
                {
                    throw new Exception1();
                }
                return new Class22(this.struct5_0.ulong_0 % ((Class22)class19_0).struct5_0.ulong_0);
            }

            public override Class19 vmethod_69(Class19 class19_0)
            {
                if (class19_0.vmethod_0())
                {
                    class19_0 = class19_0.vmethod_8();
                }
                if (!class19_0.method_3())
                {
                    throw new Exception1();
                }
                return new Class22(this.struct5_0.long_0 & ((Class22)class19_0).struct5_0.long_0);
            }

            public override Class19 vmethod_70(Class19 class19_0)
            {
                if (class19_0.vmethod_0())
                {
                    class19_0 = class19_0.vmethod_8();
                }
                if (!class19_0.method_3())
                {
                    throw new Exception1();
                }
                return new Class22(this.struct5_0.long_0 | ((Class22)class19_0).struct5_0.long_0);
            }

            public override Class19 vmethod_71()
            {
                return new Class22(~this.struct5_0.long_0);
            }

            public override Class19 vmethod_72(Class19 class19_0)
            {
                if (class19_0.vmethod_0())
                {
                    class19_0 = class19_0.vmethod_8();
                }
                if (!class19_0.method_3())
                {
                    throw new Exception1();
                }
                return new Class22(this.struct5_0.long_0 ^ ((Class22)class19_0).struct5_0.long_0);
            }

            public override Class19 vmethod_74(Class19 class19_0)
            {
                if (class19_0.vmethod_0())
                {
                    class19_0 = class19_0.vmethod_8();
                }
                if (class19_0.method_3())
                {
                    return new Class22(this.struct5_0.long_0 << ((Class22)class19_0).struct5_0.int_0);
                }
                if (!class19_0.vmethod_3())
                {
                    throw new Exception1();
                }
                return new Class22(this.struct5_0.long_0 << ((Class20)class19_0).vmethod_19().struct4_0.int_0);
            }

            public override Class19 vmethod_75(Class19 class19_0)
            {
                if (class19_0.vmethod_0())
                {
                    class19_0 = class19_0.vmethod_8();
                }
                if (class19_0.method_3())
                {
                    return new Class22(this.struct5_0.long_0 >> ((Class22)class19_0).struct5_0.int_0);
                }
                if (!class19_0.vmethod_3())
                {
                    throw new Exception1();
                }
                return new Class22(this.struct5_0.long_0 >> ((Class20)class19_0).vmethod_19().struct4_0.int_0);
            }

            public override Class19 vmethod_76(Class19 class19_0)
            {
                if (class19_0.vmethod_0())
                {
                    class19_0 = class19_0.vmethod_8();
                }
                if (class19_0.method_3())
                {
                    return new Class22(this.struct5_0.ulong_0 >> ((Class22)class19_0).struct5_0.int_0);
                }
                if (!class19_0.vmethod_3())
                {
                    throw new Exception1();
                }
                return new Class22(this.struct5_0.ulong_0 >> ((Class20)class19_0).vmethod_19().struct4_0.int_0);
            }

            public override string ToString()
            {
                if (this.enum1_0 == (Enum1)7)
                {
                    return this.struct5_0.long_0.ToString();
                }
                return this.struct5_0.ulong_0.ToString();
            }

            internal override Class19 vmethod_8()
            {
                return this;
            }

            internal override bool vmethod_9()
            {
                return true;
            }

            internal override bool vmethod_5(Class19 class19_0)
            {
                if (class19_0.method_0())
                {
                    return ((Class31)class19_0).vmethod_5(this);
                }
                if (class19_0.vmethod_0())
                {
                    return ((Class25)class19_0).vmethod_5(this);
                }
                Class19 @class = class19_0.vmethod_8();
                if (!@class.method_3())
                {
                    return false;
                }
                return this.struct5_0.long_0 == ((Class22)@class).struct5_0.long_0;
            }

            private static Class20 smethod_4(Class19 class19_0)
            {
                Class20 @class = class19_0 as Class20;
                if (@class == null && class19_0.vmethod_0())
                {
                    @class = class19_0.vmethod_8() as Class20;
                }
                return @class;
            }

            internal override bool vmethod_6(Class19 class19_0)
            {
                if (class19_0.method_0())
                {
                    return false;
                }
                if (class19_0.vmethod_0())
                {
                    return ((Class25)class19_0).vmethod_6(this);
                }
                Class19 @class = class19_0.vmethod_8();
                if (!@class.method_3())
                {
                    return false;
                }
                return this.struct5_0.ulong_0 != ((Class22)@class).struct5_0.ulong_0;
            }

            public override bool vmethod_77(Class19 class19_0)
            {
                if (class19_0.vmethod_0())
                {
                    class19_0 = class19_0.vmethod_8();
                }
                if (!class19_0.method_3())
                {
                    throw new Exception1();
                }
                return this.struct5_0.long_0 >= ((Class22)class19_0).struct5_0.long_0;
            }

            public override bool vmethod_78(Class19 class19_0)
            {
                if (class19_0.vmethod_0())
                {
                    class19_0 = class19_0.vmethod_8();
                }
                if (!class19_0.method_3())
                {
                    throw new Exception1();
                }
                return this.struct5_0.ulong_0 >= ((Class22)class19_0).struct5_0.ulong_0;
            }

            public override bool vmethod_79(Class19 class19_0)
            {
                if (class19_0.vmethod_0())
                {
                    class19_0 = class19_0.vmethod_8();
                }
                if (!class19_0.method_3())
                {
                    throw new Exception1();
                }
                return this.struct5_0.long_0 > ((Class22)class19_0).struct5_0.long_0;
            }

            public override bool vmethod_80(Class19 class19_0)
            {
                if (class19_0.vmethod_0())
                {
                    class19_0 = class19_0.vmethod_8();
                }
                if (!class19_0.method_3())
                {
                    throw new Exception1();
                }
                return this.struct5_0.ulong_0 > ((Class22)class19_0).struct5_0.ulong_0;
            }

            public override bool vmethod_81(Class19 class19_0)
            {
                if (class19_0.vmethod_0())
                {
                    class19_0 = class19_0.vmethod_8();
                }
                if (!class19_0.method_3())
                {
                    throw new Exception1();
                }
                return this.struct5_0.long_0 <= ((Class22)class19_0).struct5_0.long_0;
            }

            public override bool vTminFdwf1(Class19 class19_0)
            {
                if (class19_0.vmethod_0())
                {
                    class19_0 = class19_0.vmethod_8();
                }
                if (!class19_0.method_3())
                {
                    throw new Exception1();
                }
                return this.struct5_0.ulong_0 <= ((Class22)class19_0).struct5_0.ulong_0;
            }

            public override bool vmethod_82(Class19 class19_0)
            {
                if (class19_0.vmethod_0())
                {
                    class19_0 = class19_0.vmethod_8();
                }
                if (!class19_0.method_3())
                {
                    throw new Exception1();
                }
                return this.struct5_0.long_0 < ((Class22)class19_0).struct5_0.long_0;
            }

            public override bool vmethod_83(Class19 class19_0)
            {
                if (class19_0.vmethod_0())
                {
                    class19_0 = class19_0.vmethod_8();
                }
                if (!class19_0.method_3())
                {
                    throw new Exception1();
                }
                return this.struct5_0.ulong_0 < ((Class22)class19_0).struct5_0.ulong_0;
            }
        }

        private class Class23 : Class20
        {
            public Class20 class20_0;

            public Enum1 enum1_0;

            internal void method_6(Class19 class19_0)
            {
                if (class19_0.method_2())
                {
                    this.class20_0 = ((Class23)class19_0).class20_0;
                    this.enum1_0 = ((Class23)class19_0).enum1_0;
                }
                else
                {
                    this.vmethod_10(class19_0);
                }
            }

            internal unsafe override void vmethod_10(Class19 class19_0)
            {
                if (class19_0.method_2())
                {
                    if (IntPtr.Size == 8)
                    {
                        IntPtr intPtr = new IntPtr(((Class22)this.class20_0).struct5_0.long_0);
                        IntPtr intPtr2 = new IntPtr(((Class22)((Class23)class19_0).class20_0).struct5_0.long_0);
                        *(long*)(void*)intPtr = intPtr2.ToInt64();
                    }
                    else
                    {
                        IntPtr intPtr3 = new IntPtr(((Class21)this.class20_0).struct4_0.int_0);
                        IntPtr intPtr4 = new IntPtr(((Class21)((Class23)class19_0).class20_0).struct4_0.int_0);
                        *(int*)(void*)intPtr3 = intPtr4.ToInt32();
                    }
                    return;
                }
                object obj = class19_0.vmethod_4(null);
                if (obj == null)
                {
                    return;
                }
                IntPtr intPtr5 = ((IntPtr.Size != 8) ? new IntPtr(((Class21)this.class20_0).struct4_0.int_0) : new IntPtr(((Class22)this.class20_0).struct5_0.long_0));
                Type type = obj.GetType();
                if (type == typeof(string))
                {
                    return;
                }
                if (type == typeof(byte))
                {
                    *(byte*)(void*)intPtr5 = (byte)obj;
                    return;
                }
                if (type == typeof(sbyte))
                {
                    *(sbyte*)(void*)intPtr5 = (sbyte)obj;
                    return;
                }
                if (type == typeof(short))
                {
                    *(short*)(void*)intPtr5 = (short)obj;
                    return;
                }
                if (type == typeof(ushort))
                {
                    *(ushort*)(void*)intPtr5 = (ushort)obj;
                    return;
                }
                if (type == typeof(int))
                {
                    *(int*)(void*)intPtr5 = (int)obj;
                    return;
                }
                if (type == typeof(uint))
                {
                    *(uint*)(void*)intPtr5 = (uint)obj;
                    return;
                }
                if (type == typeof(long))
                {
                    *(long*)(void*)intPtr5 = (long)obj;
                    return;
                }
                if (type == typeof(ulong))
                {
                    *(ulong*)(void*)intPtr5 = (ulong)obj;
                    return;
                }
                if (type == typeof(float))
                {
                    *(float*)(void*)intPtr5 = (float)obj;
                    return;
                }
                if (type == typeof(double))
                {
                    *(double*)(void*)intPtr5 = (double)obj;
                    return;
                }
                if (type == typeof(bool))
                {
                    *(bool*)(void*)intPtr5 = (bool)obj;
                    return;
                }
                if (type == typeof(IntPtr))
                {
                    *(IntPtr*)(void*)intPtr5 = (IntPtr)obj;
                    return;
                }
                if (type == typeof(UIntPtr))
                {
                    *(UIntPtr*)(void*)intPtr5 = (UIntPtr)obj;
                    return;
                }
                if (!(type == typeof(char)))
                {
                    throw new Exception1();
                }
                *(char*)(void*)intPtr5 = (char)obj;
            }

            internal override void vmethod_2(Class19 class19_0)
            {
                this.vmethod_10(class19_0);
            }

            public Class23(IntPtr intptr_0)
            {
                base.enum4_0 = (Enum4)3;
                if (IntPtr.Size == 8)
                {
                    this.class20_0 = new Class22(intptr_0.ToInt64());
                    this.enum1_0 = (Enum1)12;
                }
                else
                {
                    this.class20_0 = new Class21(intptr_0.ToInt32());
                    this.enum1_0 = (Enum1)12;
                }
            }

            public Class23(UIntPtr uintptr_0)
            {
                base.enum4_0 = (Enum4)3;
                if (IntPtr.Size == 8)
                {
                    this.class20_0 = new Class22(uintptr_0.ToUInt64());
                    this.enum1_0 = (Enum1)12;
                }
                else
                {
                    this.class20_0 = new Class21(uintptr_0.ToUInt32());
                    this.enum1_0 = (Enum1)12;
                }
            }

            public Class23()
            {
                base.enum4_0 = (Enum4)3;
                if (IntPtr.Size == 8)
                {
                    this.class20_0 = new Class22(0L);
                    this.enum1_0 = (Enum1)12;
                }
                else
                {
                    this.class20_0 = new Class21(0);
                    this.enum1_0 = (Enum1)12;
                }
            }

            public override Class20 vmethod_73()
            {
                return new Class23
                {
                    class20_0 = this.class20_0.vmethod_73(),
                    enum1_0 = this.enum1_0
                };
            }

            public Class23(long long_0)
            {
                base.enum4_0 = (Enum4)3;
                if (IntPtr.Size == 8)
                {
                    this.class20_0 = new Class22(long_0);
                    this.enum1_0 = (Enum1)12;
                }
                else
                {
                    this.class20_0 = new Class21((int)long_0);
                    this.enum1_0 = (Enum1)12;
                }
            }

            public Class23(long long_0, Enum1 enum1_1)
            {
                base.enum4_0 = (Enum4)3;
                if (IntPtr.Size == 8)
                {
                    this.class20_0 = new Class22(long_0);
                    this.enum1_0 = enum1_1;
                }
                else
                {
                    this.class20_0 = new Class21((int)long_0);
                    this.enum1_0 = enum1_1;
                }
            }

            public Class23(ulong ulong_0)
            {
                base.enum4_0 = (Enum4)4;
                if (IntPtr.Size == 8)
                {
                    this.class20_0 = new Class22(ulong_0);
                    this.enum1_0 = (Enum1)13;
                }
                else
                {
                    this.class20_0 = new Class21((uint)ulong_0);
                    this.enum1_0 = (Enum1)13;
                }
            }

            public Class23(ulong ulong_0, Enum1 enum1_1)
            {
                base.enum4_0 = (Enum4)4;
                if (IntPtr.Size == 8)
                {
                    this.class20_0 = new Class22(ulong_0);
                    this.enum1_0 = enum1_1;
                }
                else
                {
                    this.class20_0 = new Class21((uint)ulong_0);
                    this.enum1_0 = enum1_1;
                }
            }

            public override bool vmethod_11()
            {
                return this.class20_0.vmethod_11();
            }

            public override bool vmethod_12()
            {
                return !this.vmethod_11();
            }

            internal override bool vmethod_7()
            {
                return this.vmethod_12();
            }

            internal override bool vmethod_1()
            {
                return true;
            }

            public override Class19 vmethod_13(Enum1 enum1_1)
            {
                return enum1_1 switch
                {
                    (Enum1)1 => this.vmethod_15(), 
                    (Enum1)2 => this.vmethod_16(), 
                    (Enum1)3 => this.vmethod_17(), 
                    (Enum1)4 => this.vmethod_18(), 
                    (Enum1)5 => this.vmethod_19(), 
                    (Enum1)6 => this.vmethod_20(), 
                    (Enum1)7 => this.vmethod_21(), 
                    (Enum1)8 => this.vmethod_22(), 
                    (Enum1)11 => this.vmethod_14(), 
                    (Enum1)12 => this, 
                    (Enum1)13 => this, 
                    (Enum1)16 => this.vmethod_73(), 
                    _ => throw new Exception(((Enum5)4).ToString()), 
                };
            }

            internal IntPtr method_7()
            {
                if (IntPtr.Size == 8)
                {
                    return new IntPtr(((Class22)this.class20_0).struct5_0.long_0);
                }
                return new IntPtr(((Class21)this.class20_0).struct4_0.int_0);
            }

            internal override object vmethod_4(Type type_0)
            {
                if (type_0 != null && type_0.IsByRef)
                {
                    type_0 = type_0.GetElementType();
                }
                if (type_0 == typeof(IntPtr))
                {
                    if (IntPtr.Size == 8)
                    {
                        return new IntPtr(((Class22)this.class20_0).struct5_0.long_0);
                    }
                    return new IntPtr(((Class21)this.class20_0).struct4_0.int_0);
                }
                if (type_0 == typeof(UIntPtr))
                {
                    if (IntPtr.Size == 8)
                    {
                        return new UIntPtr(((Class22)this.class20_0).struct5_0.ulong_0);
                    }
                    return new UIntPtr(((Class21)this.class20_0).struct4_0.uint_0);
                }
                if (!(type_0 == null) && !(type_0 == typeof(object)))
                {
                    throw new Exception1();
                }
                if (IntPtr.Size == 8)
                {
                    if (this.enum1_0 == (Enum1)12)
                    {
                        return new IntPtr(((Class22)this.class20_0).struct5_0.long_0);
                    }
                    return new UIntPtr(((Class22)this.class20_0).struct5_0.ulong_0);
                }
                if (this.enum1_0 == (Enum1)12)
                {
                    return new IntPtr(((Class22)this.class20_0).struct5_0.int_0);
                }
                return new UIntPtr(((Class21)this.class20_0).struct4_0.uint_0);
            }

            public override Class21 vmethod_14()
            {
                return this.class20_0.vmethod_14();
            }

            public override Class21 vmethod_15()
            {
                return this.class20_0.vmethod_15();
            }

            public override Class21 vmethod_16()
            {
                return this.class20_0.vmethod_16();
            }

            public override Class21 vmethod_17()
            {
                return this.class20_0.vmethod_17();
            }

            public override Class21 vmethod_18()
            {
                return this.class20_0.vmethod_18();
            }

            public override Class21 vmethod_19()
            {
                return this.class20_0.vmethod_19();
            }

            public override Class21 vmethod_20()
            {
                return this.class20_0.vmethod_20();
            }

            public override Class22 vmethod_21()
            {
                return this.class20_0.vmethod_21();
            }

            public override Class22 vmethod_22()
            {
                return this.class20_0.vmethod_22();
            }

            public override Class21 vmethod_23()
            {
                return this.vmethod_15();
            }

            public override Class21 vmethod_24()
            {
                return this.vmethod_17();
            }

            public override Class21 vmethod_25()
            {
                return this.vmethod_19();
            }

            public override Class22 vmethod_26()
            {
                return this.vmethod_21();
            }

            public override Class21 vmethod_27()
            {
                return this.vmethod_16();
            }

            public override Class21 vmethod_28()
            {
                return this.vmethod_18();
            }

            public override Class21 vmethod_29()
            {
                return this.vmethod_20();
            }

            public override Class22 vmethod_30()
            {
                return this.vmethod_22();
            }

            public override Class21 vmethod_31()
            {
                return this.class20_0.vmethod_31();
            }

            public override Class21 vmethod_32()
            {
                return this.class20_0.vmethod_32();
            }

            public override Class21 vmethod_33()
            {
                return this.class20_0.vmethod_33();
            }

            public override Class21 vmethod_34()
            {
                return this.class20_0.vmethod_34();
            }

            public override Class21 vmethod_35()
            {
                return this.class20_0.vmethod_35();
            }

            public override Class21 vmethod_36()
            {
                return this.class20_0.vmethod_36();
            }

            public override Class22 vmethod_37()
            {
                return this.class20_0.vmethod_37();
            }

            public override Class22 vmethod_38()
            {
                return this.class20_0.vmethod_38();
            }

            public override Class21 vmethod_39()
            {
                return this.class20_0.vmethod_39();
            }

            public override Class21 vmethod_40()
            {
                return this.class20_0.vmethod_40();
            }

            public override Class21 vmethod_41()
            {
                return this.class20_0.vmethod_41();
            }

            public override Class21 vmethod_42()
            {
                return this.class20_0.vmethod_42();
            }

            public override Class21 vmethod_43()
            {
                return this.class20_0.vmethod_43();
            }

            public override Class21 vmethod_44()
            {
                return this.class20_0.vmethod_44();
            }

            public override Class22 vmethod_45()
            {
                return this.class20_0.vmethod_45();
            }

            public override Class22 vmethod_46()
            {
                return this.class20_0.vmethod_46();
            }

            public override Class24 vmethod_47()
            {
                return this.class20_0.vmethod_47();
            }

            public override Class24 vmethod_48()
            {
                return this.class20_0.vmethod_48();
            }

            public override Class24 vmethod_49()
            {
                return this.class20_0.vmethod_49();
            }

            public override Class23 vmethod_50()
            {
                if (IntPtr.Size == 8)
                {
                    return new Class23(this.vmethod_26().struct5_0.long_0);
                }
                return new Class23(this.vmethod_25().struct4_0.int_0);
            }

            public override Class23 vmethod_51()
            {
                if (IntPtr.Size == 8)
                {
                    return new Class23(this.vmethod_30().struct5_0.ulong_0);
                }
                return new Class23((ulong)this.vmethod_29().struct4_0.uint_0);
            }

            public override Class23 vmethod_52()
            {
                if (IntPtr.Size == 8)
                {
                    return new Class23(this.vmethod_37().struct5_0.long_0);
                }
                return new Class23(this.vmethod_35().struct4_0.int_0);
            }

            public override Class23 vmethod_53()
            {
                if (IntPtr.Size == 8)
                {
                    return new Class23(this.vmethod_45().struct5_0.ulong_0);
                }
                return new Class23((ulong)this.vmethod_43().struct4_0.uint_0);
            }

            public override Class23 vmethod_54()
            {
                if (IntPtr.Size == 8)
                {
                    return new Class23(this.vmethod_38().struct5_0.long_0);
                }
                return new Class23(this.vmethod_36().struct4_0.int_0);
            }

            public override Class23 vmethod_55()
            {
                if (IntPtr.Size == 8)
                {
                    return new Class23(this.vmethod_46().struct5_0.ulong_0);
                }
                return new Class23((ulong)this.vmethod_44().struct4_0.uint_0);
            }

            public override Class19 vmethod_56()
            {
                if (IntPtr.Size == 8)
                {
                    return new Class23(-((Class22)this.class20_0).struct5_0.long_0);
                }
                return new Class23(-((Class21)this.class20_0).struct4_0.int_0);
            }

            public override Class19 Add(Class19 class19_0)
            {
                if (class19_0.vmethod_0())
                {
                    class19_0 = class19_0.vmethod_8();
                }
                if (class19_0.method_1())
                {
                    if (IntPtr.Size == 8)
                    {
                        return new Class23(this.vmethod_21().struct5_0.long_0 + ((Class21)class19_0).vmethod_21().struct5_0.long_0);
                    }
                    return new Class23(this.vmethod_19().struct4_0.int_0 + ((Class21)class19_0).struct4_0.int_0);
                }
                if (class19_0.method_2())
                {
                    if (IntPtr.Size == 8)
                    {
                        return new Class23(this.vmethod_21().struct5_0.long_0 + ((Class23)class19_0).vmethod_21().struct5_0.long_0);
                    }
                    return new Class23(this.vmethod_19().struct4_0.int_0 + ((Class23)class19_0).vmethod_19().struct4_0.int_0);
                }
                throw new Exception1();
            }

            public override Class19 vmethod_57(Class19 class19_0)
            {
                if (class19_0.vmethod_0())
                {
                    class19_0 = class19_0.vmethod_8();
                }
                checked
                {
                    if (class19_0.method_1())
                    {
                        if (IntPtr.Size == 8)
                        {
                            return new Class23(this.vmethod_21().struct5_0.long_0 + ((Class21)class19_0).vmethod_21().struct5_0.long_0);
                        }
                        return new Class23(this.vmethod_19().struct4_0.int_0 + ((Class21)class19_0).struct4_0.int_0);
                    }
                    if (class19_0.method_2())
                    {
                        if (IntPtr.Size == 8)
                        {
                            return new Class23(this.vmethod_21().struct5_0.long_0 + ((Class23)class19_0).vmethod_21().struct5_0.long_0);
                        }
                        return new Class23(this.vmethod_19().struct4_0.int_0 + ((Class23)class19_0).vmethod_19().struct4_0.int_0);
                    }
                    throw new Exception1();
                }
            }

            public override Class19 vmethod_58(Class19 class19_0)
            {
                if (class19_0.vmethod_0())
                {
                    class19_0 = class19_0.vmethod_8();
                }
                checked
                {
                    if (class19_0.method_1())
                    {
                        if (IntPtr.Size == 8)
                        {
                            return new Class23(this.vmethod_21().struct5_0.ulong_0 + ((Class21)class19_0).struct4_0.uint_0);
                        }
                        return new Class23(this.vmethod_19().struct4_0.uint_0 + ((Class21)class19_0).struct4_0.uint_0);
                    }
                }
                if (class19_0.method_2())
                {
                    if (IntPtr.Size == 8)
                    {
                        return new Class23(checked(this.vmethod_21().struct5_0.ulong_0 + ((Class23)class19_0).vmethod_21().struct5_0.ulong_0));
                    }
                    return new Class23((ulong)checked(this.vmethod_19().struct4_0.uint_0 + ((Class23)class19_0).vmethod_19().struct4_0.uint_0));
                }
                throw new Exception1();
            }

            public override Class19 vmethod_59(Class19 class19_0)
            {
                if (class19_0.vmethod_0())
                {
                    class19_0 = class19_0.vmethod_8();
                }
                if (class19_0.method_1())
                {
                    if (IntPtr.Size == 8)
                    {
                        return new Class23(this.vmethod_21().struct5_0.long_0 - ((Class21)class19_0).vmethod_21().struct5_0.long_0);
                    }
                    return new Class23(this.vmethod_19().struct4_0.int_0 - ((Class21)class19_0).struct4_0.int_0);
                }
                if (class19_0.method_2())
                {
                    if (IntPtr.Size == 8)
                    {
                        return new Class23(this.vmethod_21().struct5_0.long_0 - ((Class23)class19_0).vmethod_21().struct5_0.long_0);
                    }
                    return new Class23(this.vmethod_19().struct4_0.int_0 - ((Class23)class19_0).vmethod_19().struct4_0.int_0);
                }
                throw new Exception1();
            }

            public Class19 method_8(Class19 class19_0)
            {
                if (class19_0.vmethod_0())
                {
                    class19_0 = class19_0.vmethod_8();
                }
                if (class19_0.method_1())
                {
                    if (IntPtr.Size == 8)
                    {
                        return new Class23(((Class21)class19_0).vmethod_21().struct5_0.long_0 - this.vmethod_21().struct5_0.long_0);
                    }
                    return new Class23(((Class21)class19_0).struct4_0.int_0 - this.vmethod_19().struct4_0.int_0);
                }
                if (class19_0.method_2())
                {
                    if (IntPtr.Size == 8)
                    {
                        return new Class23(((Class23)class19_0).vmethod_21().struct5_0.long_0 - this.vmethod_21().struct5_0.long_0);
                    }
                    return new Class23(((Class23)class19_0).vmethod_19().struct4_0.int_0 - this.vmethod_19().struct4_0.int_0);
                }
                throw new Exception1();
            }

            public override Class19 vmethod_60(Class19 class19_0)
            {
                if (class19_0.vmethod_0())
                {
                    class19_0 = class19_0.vmethod_8();
                }
                checked
                {
                    if (class19_0.method_1())
                    {
                        if (IntPtr.Size == 8)
                        {
                            return new Class23(this.vmethod_21().struct5_0.long_0 - ((Class21)class19_0).vmethod_21().struct5_0.long_0);
                        }
                        return new Class23(this.vmethod_19().struct4_0.int_0 - ((Class21)class19_0).struct4_0.int_0);
                    }
                    if (class19_0.method_2())
                    {
                        if (IntPtr.Size == 8)
                        {
                            return new Class23(this.vmethod_21().struct5_0.long_0 - ((Class23)class19_0).vmethod_21().struct5_0.long_0);
                        }
                        return new Class23(this.vmethod_19().struct4_0.int_0 - ((Class23)class19_0).vmethod_19().struct4_0.int_0);
                    }
                    throw new Exception1();
                }
            }

            public Class19 method_9(Class19 class19_0)
            {
                if (class19_0.vmethod_0())
                {
                    class19_0 = class19_0.vmethod_8();
                }
                checked
                {
                    if (class19_0.method_1())
                    {
                        if (IntPtr.Size == 8)
                        {
                            return new Class23(((Class21)class19_0).vmethod_21().struct5_0.long_0 - this.vmethod_21().struct5_0.long_0);
                        }
                        return new Class23(((Class21)class19_0).struct4_0.int_0 - this.vmethod_19().struct4_0.int_0);
                    }
                    if (class19_0.method_2())
                    {
                        if (IntPtr.Size == 8)
                        {
                            return new Class23(((Class23)class19_0).vmethod_21().struct5_0.long_0 - this.vmethod_21().struct5_0.long_0);
                        }
                        return new Class23(((Class23)class19_0).vmethod_19().struct4_0.int_0 - this.vmethod_19().struct4_0.int_0);
                    }
                    throw new Exception1();
                }
            }

            public override Class19 vmethod_61(Class19 class19_0)
            {
                if (class19_0.vmethod_0())
                {
                    class19_0 = class19_0.vmethod_8();
                }
                checked
                {
                    if (class19_0.method_1())
                    {
                        if (IntPtr.Size == 8)
                        {
                            return new Class23(this.vmethod_21().struct5_0.ulong_0 - ((Class21)class19_0).struct4_0.uint_0);
                        }
                        return new Class23(this.vmethod_19().struct4_0.uint_0 - ((Class21)class19_0).struct4_0.uint_0);
                    }
                }
                if (class19_0.method_2())
                {
                    if (IntPtr.Size == 8)
                    {
                        return new Class23(checked(this.vmethod_21().struct5_0.ulong_0 - ((Class23)class19_0).vmethod_21().struct5_0.ulong_0));
                    }
                    return new Class23((ulong)checked(this.vmethod_19().struct4_0.uint_0 - ((Class23)class19_0).vmethod_19().struct4_0.uint_0));
                }
                throw new Exception1();
            }

            public Class19 method_10(Class19 class19_0)
            {
                if (class19_0.vmethod_0())
                {
                    class19_0 = class19_0.vmethod_8();
                }
                checked
                {
                    if (class19_0.method_1())
                    {
                        if (IntPtr.Size == 8)
                        {
                            return new Class23(((Class21)class19_0).struct4_0.uint_0 - this.vmethod_21().struct5_0.ulong_0);
                        }
                        return new Class23(((Class21)class19_0).struct4_0.uint_0 - this.vmethod_19().struct4_0.uint_0);
                    }
                }
                if (class19_0.method_2())
                {
                    if (IntPtr.Size == 8)
                    {
                        return new Class23(checked(((Class23)class19_0).vmethod_21().struct5_0.ulong_0 - this.vmethod_21().struct5_0.ulong_0));
                    }
                    return new Class23((ulong)checked(((Class23)class19_0).vmethod_19().struct4_0.uint_0 - this.vmethod_19().struct4_0.uint_0));
                }
                throw new Exception1();
            }

            public override Class19 vmethod_62(Class19 class19_0)
            {
                if (class19_0.vmethod_0())
                {
                    class19_0 = class19_0.vmethod_8();
                }
                if (class19_0.method_1())
                {
                    if (IntPtr.Size == 8)
                    {
                        return new Class23(this.vmethod_21().struct5_0.long_0 * ((Class21)class19_0).vmethod_21().struct5_0.long_0);
                    }
                    return new Class23(this.vmethod_19().struct4_0.int_0 * ((Class21)class19_0).struct4_0.int_0);
                }
                if (class19_0.method_2())
                {
                    if (IntPtr.Size == 8)
                    {
                        return new Class23(this.vmethod_21().struct5_0.long_0 * ((Class23)class19_0).vmethod_21().struct5_0.long_0);
                    }
                    return new Class23(this.vmethod_19().struct4_0.int_0 * ((Class23)class19_0).vmethod_19().struct4_0.int_0);
                }
                throw new Exception1();
            }

            public override Class19 vmethod_63(Class19 class19_0)
            {
                if (class19_0.vmethod_0())
                {
                    class19_0 = class19_0.vmethod_8();
                }
                checked
                {
                    if (class19_0.method_1())
                    {
                        if (IntPtr.Size == 8)
                        {
                            return new Class23(this.vmethod_21().struct5_0.long_0 * ((Class21)class19_0).vmethod_21().struct5_0.long_0);
                        }
                        return new Class23(this.vmethod_19().struct4_0.int_0 * ((Class21)class19_0).struct4_0.int_0);
                    }
                    if (class19_0.method_2())
                    {
                        if (IntPtr.Size == 8)
                        {
                            return new Class23(this.vmethod_21().struct5_0.long_0 * ((Class23)class19_0).vmethod_21().struct5_0.long_0);
                        }
                        return new Class23(this.vmethod_19().struct4_0.int_0 * ((Class23)class19_0).vmethod_19().struct4_0.int_0);
                    }
                    throw new Exception1();
                }
            }

            public override Class19 vmethod_64(Class19 class19_0)
            {
                if (class19_0.vmethod_0())
                {
                    class19_0 = class19_0.vmethod_8();
                }
                checked
                {
                    if (class19_0.method_1())
                    {
                        if (IntPtr.Size == 8)
                        {
                            return new Class23(this.vmethod_21().struct5_0.ulong_0 * ((Class21)class19_0).struct4_0.uint_0);
                        }
                        return new Class23(this.vmethod_19().struct4_0.uint_0 * ((Class21)class19_0).struct4_0.uint_0);
                    }
                }
                if (class19_0.method_2())
                {
                    if (IntPtr.Size == 8)
                    {
                        return new Class23(checked(this.vmethod_21().struct5_0.ulong_0 * ((Class23)class19_0).vmethod_21().struct5_0.ulong_0));
                    }
                    return new Class23((ulong)checked(this.vmethod_19().struct4_0.uint_0 * ((Class23)class19_0).vmethod_19().struct4_0.uint_0));
                }
                throw new Exception1();
            }

            public override Class19 vmethod_65(Class19 class19_0)
            {
                if (class19_0.vmethod_0())
                {
                    class19_0 = class19_0.vmethod_8();
                }
                if (class19_0.method_1())
                {
                    if (IntPtr.Size == 8)
                    {
                        return new Class23(this.vmethod_21().struct5_0.long_0 / ((Class21)class19_0).vmethod_21().struct5_0.long_0);
                    }
                    return new Class23(this.vmethod_19().struct4_0.int_0 / ((Class21)class19_0).struct4_0.int_0);
                }
                if (class19_0.method_2())
                {
                    if (IntPtr.Size == 8)
                    {
                        return new Class23(this.vmethod_21().struct5_0.long_0 / ((Class23)class19_0).vmethod_21().struct5_0.long_0);
                    }
                    return new Class23(this.vmethod_19().struct4_0.int_0 / ((Class23)class19_0).vmethod_19().struct4_0.int_0);
                }
                throw new Exception1();
            }

            public Class19 method_11(Class19 class19_0)
            {
                if (class19_0.vmethod_0())
                {
                    class19_0 = class19_0.vmethod_8();
                }
                if (class19_0.method_1())
                {
                    if (IntPtr.Size == 8)
                    {
                        return new Class23(((Class21)class19_0).vmethod_21().struct5_0.long_0 / this.vmethod_21().struct5_0.long_0);
                    }
                    return new Class23(((Class21)class19_0).struct4_0.int_0 / this.vmethod_19().struct4_0.int_0);
                }
                if (class19_0.method_2())
                {
                    if (IntPtr.Size == 8)
                    {
                        return new Class23(((Class23)class19_0).vmethod_21().struct5_0.long_0 / this.vmethod_21().struct5_0.long_0);
                    }
                    return new Class23(((Class23)class19_0).vmethod_19().struct4_0.int_0 / this.vmethod_19().struct4_0.int_0);
                }
                throw new Exception1();
            }

            public override Class19 vmethod_66(Class19 class19_0)
            {
                if (class19_0.vmethod_0())
                {
                    class19_0 = class19_0.vmethod_8();
                }
                if (class19_0.method_1())
                {
                    if (IntPtr.Size == 8)
                    {
                        return new Class23(this.vmethod_21().struct5_0.ulong_0 / ((Class21)class19_0).vmethod_21().struct5_0.ulong_0);
                    }
                    return new Class23(this.vmethod_19().struct4_0.uint_0 / ((Class21)class19_0).struct4_0.uint_0);
                }
                if (class19_0.method_2())
                {
                    if (IntPtr.Size == 8)
                    {
                        return new Class23(this.vmethod_21().struct5_0.ulong_0 / ((Class23)class19_0).vmethod_21().struct5_0.ulong_0);
                    }
                    return new Class23((ulong)(this.vmethod_19().struct4_0.uint_0 / ((Class23)class19_0).vmethod_19().struct4_0.uint_0));
                }
                throw new Exception1();
            }

            public Class19 method_12(Class19 class19_0)
            {
                if (class19_0.vmethod_0())
                {
                    class19_0 = class19_0.vmethod_8();
                }
                if (class19_0.method_1())
                {
                    if (IntPtr.Size == 8)
                    {
                        return new Class23(((Class21)class19_0).vmethod_21().struct5_0.ulong_0 / this.vmethod_21().struct5_0.ulong_0);
                    }
                    return new Class23(((Class21)class19_0).struct4_0.uint_0 / this.vmethod_19().struct4_0.uint_0);
                }
                if (class19_0.method_2())
                {
                    if (IntPtr.Size == 8)
                    {
                        return new Class23(((Class23)class19_0).vmethod_21().struct5_0.ulong_0 / this.vmethod_21().struct5_0.ulong_0);
                    }
                    return new Class23((ulong)(((Class23)class19_0).vmethod_19().struct4_0.uint_0 / this.vmethod_19().struct4_0.uint_0));
                }
                throw new Exception1();
            }

            public override Class19 vmethod_67(Class19 class19_0)
            {
                if (class19_0.vmethod_0())
                {
                    class19_0 = class19_0.vmethod_8();
                }
                if (class19_0.method_1())
                {
                    if (IntPtr.Size == 8)
                    {
                        return new Class23(this.vmethod_21().struct5_0.long_0 % ((Class21)class19_0).vmethod_21().struct5_0.long_0);
                    }
                    return new Class23(this.vmethod_19().struct4_0.int_0 % ((Class21)class19_0).struct4_0.int_0);
                }
                if (class19_0.method_2())
                {
                    if (IntPtr.Size == 8)
                    {
                        return new Class23(this.vmethod_21().struct5_0.long_0 % ((Class23)class19_0).vmethod_21().struct5_0.long_0);
                    }
                    return new Class23(this.vmethod_19().struct4_0.int_0 % ((Class23)class19_0).vmethod_19().struct4_0.int_0);
                }
                throw new Exception1();
            }

            public Class19 method_13(Class19 class19_0)
            {
                if (class19_0.vmethod_0())
                {
                    class19_0 = class19_0.vmethod_8();
                }
                if (class19_0.method_1())
                {
                    if (IntPtr.Size == 8)
                    {
                        return new Class23(((Class21)class19_0).vmethod_21().struct5_0.long_0 % this.vmethod_21().struct5_0.long_0);
                    }
                    return new Class23(((Class21)class19_0).struct4_0.int_0 % this.vmethod_19().struct4_0.int_0);
                }
                if (class19_0.method_2())
                {
                    if (IntPtr.Size == 8)
                    {
                        return new Class23(((Class23)class19_0).vmethod_21().struct5_0.long_0 % this.vmethod_21().struct5_0.long_0);
                    }
                    return new Class23(((Class23)class19_0).vmethod_19().struct4_0.int_0 % this.vmethod_19().struct4_0.int_0);
                }
                throw new Exception1();
            }

            public override Class19 vmethod_68(Class19 class19_0)
            {
                if (class19_0.vmethod_0())
                {
                    class19_0 = class19_0.vmethod_8();
                }
                if (class19_0.method_1())
                {
                    if (IntPtr.Size == 8)
                    {
                        return new Class23(this.vmethod_21().struct5_0.ulong_0 % ((Class21)class19_0).vmethod_21().struct5_0.ulong_0);
                    }
                    return new Class23(this.vmethod_19().struct4_0.uint_0 % ((Class21)class19_0).struct4_0.uint_0);
                }
                if (class19_0.method_2())
                {
                    if (IntPtr.Size == 8)
                    {
                        return new Class23(this.vmethod_21().struct5_0.ulong_0 % ((Class23)class19_0).vmethod_21().struct5_0.ulong_0);
                    }
                    return new Class23((ulong)(this.vmethod_19().struct4_0.uint_0 % ((Class23)class19_0).vmethod_19().struct4_0.uint_0));
                }
                throw new Exception1();
            }

            public Class19 method_14(Class19 class19_0)
            {
                if (class19_0.vmethod_0())
                {
                    class19_0 = class19_0.vmethod_8();
                }
                if (class19_0.method_1())
                {
                    if (IntPtr.Size == 8)
                    {
                        return new Class23(((Class21)class19_0).vmethod_21().struct5_0.ulong_0 % this.vmethod_21().struct5_0.ulong_0);
                    }
                    return new Class23(((Class21)class19_0).struct4_0.uint_0 % this.vmethod_19().struct4_0.uint_0);
                }
                if (class19_0.method_2())
                {
                    if (IntPtr.Size == 8)
                    {
                        return new Class23(((Class23)class19_0).vmethod_21().struct5_0.ulong_0 % this.vmethod_21().struct5_0.ulong_0);
                    }
                    return new Class23((ulong)(((Class23)class19_0).vmethod_19().struct4_0.uint_0 % this.vmethod_19().struct4_0.uint_0));
                }
                throw new Exception1();
            }

            public override Class19 vmethod_69(Class19 class19_0)
            {
                if (class19_0.vmethod_0())
                {
                    class19_0 = class19_0.vmethod_8();
                }
                if (class19_0.method_1())
                {
                    if (IntPtr.Size == 8)
                    {
                        return new Class23(this.vmethod_21().struct5_0.long_0 & ((Class21)class19_0).vmethod_21().struct5_0.long_0);
                    }
                    return new Class23(this.vmethod_19().struct4_0.int_0 & ((Class21)class19_0).struct4_0.int_0);
                }
                if (class19_0.method_2())
                {
                    if (IntPtr.Size == 8)
                    {
                        return new Class23(this.vmethod_21().struct5_0.long_0 & ((Class23)class19_0).vmethod_21().struct5_0.long_0);
                    }
                    return new Class23(this.vmethod_19().struct4_0.int_0 & ((Class23)class19_0).vmethod_19().struct4_0.int_0);
                }
                throw new Exception1();
            }

            public override Class19 vmethod_70(Class19 class19_0)
            {
                if (class19_0.vmethod_0())
                {
                    class19_0 = class19_0.vmethod_8();
                }
                if (class19_0.method_1())
                {
                    if (IntPtr.Size == 8)
                    {
                        return new Class23(this.vmethod_21().struct5_0.long_0 | ((Class21)class19_0).vmethod_21().struct5_0.long_0);
                    }
                    return new Class23(this.vmethod_19().struct4_0.int_0 | ((Class21)class19_0).struct4_0.int_0);
                }
                if (class19_0.method_2())
                {
                    if (IntPtr.Size == 8)
                    {
                        return new Class23(this.vmethod_21().struct5_0.long_0 | ((Class23)class19_0).vmethod_21().struct5_0.long_0);
                    }
                    return new Class23(this.vmethod_19().struct4_0.int_0 | ((Class23)class19_0).vmethod_19().struct4_0.int_0);
                }
                throw new Exception1();
            }

            public override Class19 vmethod_71()
            {
                if (IntPtr.Size == 8)
                {
                    return new Class23(~this.vmethod_21().struct5_0.long_0);
                }
                return new Class23(~this.vmethod_19().struct4_0.int_0);
            }

            public override Class19 vmethod_72(Class19 class19_0)
            {
                if (class19_0.vmethod_0())
                {
                    class19_0 = class19_0.vmethod_8();
                }
                if (class19_0.method_1())
                {
                    if (IntPtr.Size == 8)
                    {
                        return new Class23(this.vmethod_21().struct5_0.long_0 ^ ((Class21)class19_0).vmethod_21().struct5_0.long_0);
                    }
                    return new Class23(this.vmethod_19().struct4_0.int_0 ^ ((Class21)class19_0).struct4_0.int_0);
                }
                if (class19_0.method_2())
                {
                    if (IntPtr.Size == 8)
                    {
                        return new Class23(this.vmethod_21().struct5_0.long_0 ^ ((Class23)class19_0).vmethod_21().struct5_0.long_0);
                    }
                    return new Class23(this.vmethod_19().struct4_0.int_0 ^ ((Class23)class19_0).vmethod_19().struct4_0.int_0);
                }
                throw new Exception1();
            }

            public override Class19 vmethod_74(Class19 class19_0)
            {
                if (class19_0.vmethod_0())
                {
                    class19_0 = class19_0.vmethod_8();
                }
                if (class19_0.method_1())
                {
                    if (IntPtr.Size == 8)
                    {
                        return new Class23(this.vmethod_21().struct5_0.long_0 << ((Class21)class19_0).struct4_0.int_0);
                    }
                    return new Class23(this.vmethod_19().struct4_0.int_0 << ((Class21)class19_0).struct4_0.int_0);
                }
                if (class19_0.method_2())
                {
                    if (IntPtr.Size == 8)
                    {
                        return new Class23(this.vmethod_21().struct5_0.long_0 << ((Class23)class19_0).vmethod_21().struct5_0.int_0);
                    }
                    return new Class23(this.vmethod_19().struct4_0.int_0 << ((Class23)class19_0).vmethod_19().struct4_0.int_0);
                }
                throw new Exception1();
            }

            public override Class19 vmethod_75(Class19 class19_0)
            {
                if (class19_0.vmethod_0())
                {
                    class19_0 = class19_0.vmethod_8();
                }
                if (class19_0.method_1())
                {
                    if (IntPtr.Size == 8)
                    {
                        return new Class23(this.vmethod_21().struct5_0.long_0 >> ((Class21)class19_0).struct4_0.int_0);
                    }
                    return new Class23(this.vmethod_19().struct4_0.int_0 >> ((Class21)class19_0).struct4_0.int_0);
                }
                if (class19_0.method_2())
                {
                    if (IntPtr.Size == 8)
                    {
                        return new Class23(this.vmethod_21().struct5_0.long_0 >> ((Class23)class19_0).vmethod_21().struct5_0.int_0);
                    }
                    return new Class23(this.vmethod_19().struct4_0.int_0 >> ((Class23)class19_0).vmethod_19().struct4_0.int_0);
                }
                throw new Exception1();
            }

            public override Class19 vmethod_76(Class19 class19_0)
            {
                if (class19_0.vmethod_0())
                {
                    class19_0 = class19_0.vmethod_8();
                }
                if (class19_0.method_1())
                {
                    if (IntPtr.Size == 8)
                    {
                        return new Class23(this.vmethod_21().struct5_0.ulong_0 >> ((Class21)class19_0).struct4_0.int_0);
                    }
                    return new Class23(this.vmethod_19().struct4_0.uint_0 >> ((Class21)class19_0).struct4_0.int_0);
                }
                if (class19_0.method_2())
                {
                    if (IntPtr.Size == 8)
                    {
                        return new Class23(this.vmethod_21().struct5_0.ulong_0 >> ((Class23)class19_0).vmethod_21().struct5_0.int_0);
                    }
                    return new Class23(this.vmethod_19().struct4_0.uint_0 >> ((Class23)class19_0).vmethod_19().struct4_0.int_0);
                }
                throw new Exception1();
            }

            public Class19 method_15(Class21 class21_0)
            {
                return new Class23(class21_0.struct4_0.uint_0 >> this.vmethod_19().struct4_0.int_0);
            }

            public Class19 method_16(Class21 class21_0)
            {
                return new Class23(class21_0.struct4_0.int_0 >> this.vmethod_21().struct5_0.int_0);
            }

            public Class19 method_17(Class21 class21_0)
            {
                return new Class23(class21_0.struct4_0.int_0 << this.vmethod_21().struct5_0.int_0);
            }

            public override string ToString()
            {
                return this.class20_0.ToString();
            }

            internal override Class19 vmethod_8()
            {
                return this;
            }

            internal override bool vmethod_9()
            {
                return true;
            }

            internal override bool vmethod_5(Class19 class19_0)
            {
                if (class19_0.method_0())
                {
                    return false;
                }
                if (class19_0.vmethod_0())
                {
                    return ((Class25)class19_0).vmethod_5(this);
                }
                Class19 @class = class19_0.vmethod_8();
                if (@class.vmethod_9())
                {
                    if (@class.method_1())
                    {
                        if (IntPtr.Size == 8)
                        {
                            return this.vmethod_21().struct5_0.long_0 == ((Class21)class19_0).vmethod_21().struct5_0.long_0;
                        }
                        return this.vmethod_19().struct4_0.int_0 == ((Class21)class19_0).struct4_0.int_0;
                    }
                    if (@class.method_2())
                    {
                        _ = IntPtr.Size;
                        return this.vmethod_21().struct5_0.long_0 == ((Class23)class19_0).vmethod_21().struct5_0.long_0;
                    }
                    return false;
                }
                return false;
            }

            internal override bool vmethod_6(Class19 class19_0)
            {
                if (class19_0.method_0())
                {
                    return false;
                }
                if (class19_0.vmethod_0())
                {
                    return ((Class25)class19_0).vmethod_6(this);
                }
                Class19 @class = class19_0.vmethod_8();
                if (@class.vmethod_9())
                {
                    if (@class.method_1())
                    {
                        if (IntPtr.Size == 8)
                        {
                            return this.vmethod_21().struct5_0.ulong_0 != ((Class21)class19_0).vmethod_21().struct5_0.ulong_0;
                        }
                        return this.vmethod_19().struct4_0.uint_0 != ((Class21)class19_0).struct4_0.uint_0;
                    }
                    if (@class.method_2())
                    {
                        _ = IntPtr.Size;
                        return this.vmethod_21().struct5_0.ulong_0 != ((Class23)class19_0).vmethod_21().struct5_0.ulong_0;
                    }
                    return false;
                }
                return false;
            }

            public override bool vmethod_77(Class19 class19_0)
            {
                if (class19_0.vmethod_0())
                {
                    class19_0 = class19_0.vmethod_8();
                }
                if (class19_0.method_1())
                {
                    if (IntPtr.Size == 8)
                    {
                        return this.vmethod_21().struct5_0.long_0 >= ((Class21)class19_0).vmethod_21().struct5_0.long_0;
                    }
                    return this.vmethod_19().struct4_0.int_0 >= ((Class21)class19_0).struct4_0.int_0;
                }
                if (class19_0.method_2())
                {
                    if (IntPtr.Size == 8)
                    {
                        return this.vmethod_21().struct5_0.long_0 >= ((Class23)class19_0).vmethod_21().struct5_0.long_0;
                    }
                    return this.vmethod_19().struct4_0.int_0 >= ((Class23)class19_0).vmethod_19().struct4_0.int_0;
                }
                throw new Exception1();
            }

            public override bool vmethod_78(Class19 class19_0)
            {
                if (class19_0.vmethod_0())
                {
                    class19_0 = class19_0.vmethod_8();
                }
                if (class19_0.method_1())
                {
                    if (IntPtr.Size == 8)
                    {
                        return this.vmethod_21().struct5_0.ulong_0 >= ((Class21)class19_0).vmethod_21().struct5_0.ulong_0;
                    }
                    return this.vmethod_19().struct4_0.uint_0 >= ((Class21)class19_0).struct4_0.uint_0;
                }
                if (class19_0.method_2())
                {
                    if (IntPtr.Size == 8)
                    {
                        return this.vmethod_21().struct5_0.ulong_0 >= ((Class23)class19_0).vmethod_21().struct5_0.ulong_0;
                    }
                    return this.vmethod_19().struct4_0.uint_0 >= ((Class23)class19_0).vmethod_19().struct4_0.uint_0;
                }
                throw new Exception1();
            }

            public override bool vmethod_79(Class19 class19_0)
            {
                if (class19_0.vmethod_0())
                {
                    class19_0 = class19_0.vmethod_8();
                }
                if (class19_0.method_1())
                {
                    if (IntPtr.Size == 8)
                    {
                        return this.vmethod_21().struct5_0.long_0 > ((Class21)class19_0).vmethod_21().struct5_0.long_0;
                    }
                    return this.vmethod_19().struct4_0.int_0 > ((Class21)class19_0).struct4_0.int_0;
                }
                if (class19_0.method_2())
                {
                    if (IntPtr.Size == 8)
                    {
                        return this.vmethod_21().struct5_0.long_0 > ((Class23)class19_0).vmethod_21().struct5_0.long_0;
                    }
                    return this.vmethod_19().struct4_0.int_0 > ((Class23)class19_0).vmethod_19().struct4_0.int_0;
                }
                throw new Exception1();
            }

            public override bool vmethod_80(Class19 class19_0)
            {
                if (class19_0.vmethod_0())
                {
                    class19_0 = class19_0.vmethod_8();
                }
                if (class19_0.method_1())
                {
                    if (IntPtr.Size == 8)
                    {
                        return this.vmethod_21().struct5_0.ulong_0 > ((Class21)class19_0).vmethod_21().struct5_0.ulong_0;
                    }
                    return this.vmethod_19().struct4_0.uint_0 > ((Class21)class19_0).struct4_0.uint_0;
                }
                if (class19_0.method_2())
                {
                    if (IntPtr.Size == 8)
                    {
                        return this.vmethod_21().struct5_0.ulong_0 > ((Class23)class19_0).vmethod_21().struct5_0.ulong_0;
                    }
                    return this.vmethod_19().struct4_0.uint_0 > ((Class23)class19_0).vmethod_19().struct4_0.uint_0;
                }
                throw new Exception1();
            }

            public override bool vmethod_81(Class19 class19_0)
            {
                if (class19_0.vmethod_0())
                {
                    class19_0 = class19_0.vmethod_8();
                }
                if (class19_0.method_1())
                {
                    if (IntPtr.Size == 8)
                    {
                        return this.vmethod_21().struct5_0.long_0 <= ((Class21)class19_0).vmethod_21().struct5_0.long_0;
                    }
                    return this.vmethod_19().struct4_0.int_0 <= ((Class21)class19_0).struct4_0.int_0;
                }
                if (class19_0.method_2())
                {
                    if (IntPtr.Size == 8)
                    {
                        return this.vmethod_21().struct5_0.long_0 <= ((Class23)class19_0).vmethod_21().struct5_0.long_0;
                    }
                    return this.vmethod_19().struct4_0.int_0 <= ((Class23)class19_0).vmethod_19().struct4_0.int_0;
                }
                throw new Exception1();
            }

            public override bool vTminFdwf1(Class19 class19_0)
            {
                if (class19_0.vmethod_0())
                {
                    class19_0 = class19_0.vmethod_8();
                }
                if (class19_0.method_1())
                {
                    if (IntPtr.Size == 8)
                    {
                        return this.vmethod_21().struct5_0.ulong_0 <= ((Class21)class19_0).vmethod_21().struct5_0.ulong_0;
                    }
                    return this.vmethod_19().struct4_0.uint_0 <= ((Class21)class19_0).struct4_0.uint_0;
                }
                if (class19_0.method_2())
                {
                    if (IntPtr.Size == 8)
                    {
                        return this.vmethod_21().struct5_0.ulong_0 <= ((Class23)class19_0).vmethod_21().struct5_0.ulong_0;
                    }
                    return this.vmethod_19().struct4_0.uint_0 <= ((Class23)class19_0).vmethod_19().struct4_0.uint_0;
                }
                throw new Exception1();
            }

            public override bool vmethod_82(Class19 class19_0)
            {
                if (class19_0.vmethod_0())
                {
                    class19_0 = class19_0.vmethod_8();
                }
                if (class19_0.method_1())
                {
                    if (IntPtr.Size == 8)
                    {
                        return this.vmethod_21().struct5_0.long_0 < ((Class21)class19_0).vmethod_21().struct5_0.long_0;
                    }
                    return this.vmethod_19().struct4_0.int_0 < ((Class21)class19_0).struct4_0.int_0;
                }
                if (class19_0.method_2())
                {
                    if (IntPtr.Size == 8)
                    {
                        return this.vmethod_21().struct5_0.long_0 < ((Class23)class19_0).vmethod_21().struct5_0.long_0;
                    }
                    return this.vmethod_19().struct4_0.int_0 < ((Class23)class19_0).vmethod_19().struct4_0.int_0;
                }
                throw new Exception1();
            }

            public override bool vmethod_83(Class19 class19_0)
            {
                if (class19_0.vmethod_0())
                {
                    class19_0 = class19_0.vmethod_8();
                }
                if (class19_0.method_1())
                {
                    if (IntPtr.Size == 8)
                    {
                        return this.vmethod_21().struct5_0.ulong_0 < ((Class21)class19_0).vmethod_21().struct5_0.ulong_0;
                    }
                    return this.vmethod_19().struct4_0.uint_0 < ((Class21)class19_0).struct4_0.uint_0;
                }
                if (class19_0.method_2())
                {
                    if (IntPtr.Size == 8)
                    {
                        return this.vmethod_21().struct5_0.ulong_0 < ((Class23)class19_0).vmethod_21().struct5_0.ulong_0;
                    }
                    return this.vmethod_19().struct4_0.uint_0 < ((Class23)class19_0).vmethod_19().struct4_0.uint_0;
                }
                throw new Exception1();
            }
        }

        private abstract class Class20 : Class19
        {
            public abstract bool vmethod_11();

            public abstract bool vmethod_12();

            public abstract Class19 vmethod_13(Enum1 enum1_0);

            public abstract Class21 vmethod_14();

            public abstract Class21 vmethod_15();

            public abstract Class21 vmethod_16();

            public abstract Class21 vmethod_17();

            public abstract Class21 vmethod_18();

            public abstract Class21 vmethod_19();

            public abstract Class21 vmethod_20();

            public abstract Class22 vmethod_21();

            public abstract Class22 vmethod_22();

            public abstract Class21 vmethod_23();

            public abstract Class21 vmethod_24();

            public abstract Class21 vmethod_25();

            public abstract Class22 vmethod_26();

            public abstract Class21 vmethod_27();

            public abstract Class21 vmethod_28();

            public abstract Class21 vmethod_29();

            public abstract Class22 vmethod_30();

            public abstract Class21 vmethod_31();

            public abstract Class21 vmethod_32();

            public abstract Class21 vmethod_33();

            public abstract Class21 vmethod_34();

            public abstract Class21 vmethod_35();

            public abstract Class21 vmethod_36();

            public abstract Class22 vmethod_37();

            public abstract Class22 vmethod_38();

            public abstract Class21 vmethod_39();

            public abstract Class21 vmethod_40();

            public abstract Class21 vmethod_41();

            public abstract Class21 vmethod_42();

            public abstract Class21 vmethod_43();

            public abstract Class21 vmethod_44();

            public abstract Class22 vmethod_45();

            public abstract Class22 vmethod_46();

            public abstract Class24 vmethod_47();

            public abstract Class24 vmethod_48();

            public abstract Class24 vmethod_49();

            public abstract Class23 vmethod_50();

            public abstract Class23 vmethod_51();

            public abstract Class23 vmethod_52();

            public abstract Class23 vmethod_53();

            public abstract Class23 vmethod_54();

            public abstract Class23 vmethod_55();

            public abstract Class19 vmethod_56();

            public abstract Class19 Add(Class19 class19_0);

            public abstract Class19 vmethod_57(Class19 class19_0);

            public abstract Class19 vmethod_58(Class19 class19_0);

            public abstract Class19 vmethod_59(Class19 class19_0);

            public abstract Class19 vmethod_60(Class19 class19_0);

            public abstract Class19 vmethod_61(Class19 class19_0);

            public abstract Class19 vmethod_62(Class19 class19_0);

            public abstract Class19 vmethod_63(Class19 class19_0);

            public abstract Class19 vmethod_64(Class19 class19_0);

            public abstract Class19 vmethod_65(Class19 class19_0);

            public abstract Class19 vmethod_66(Class19 class19_0);

            public abstract Class19 vmethod_67(Class19 class19_0);

            public abstract Class19 vmethod_68(Class19 class19_0);

            public abstract Class19 vmethod_69(Class19 class19_0);

            public abstract Class19 vmethod_70(Class19 class19_0);

            public abstract Class19 vmethod_71();

            public abstract Class19 vmethod_72(Class19 class19_0);

            public abstract Class20 vmethod_73();

            public abstract Class19 vmethod_74(Class19 class19_0);

            public abstract Class19 vmethod_75(Class19 class19_0);

            public abstract Class19 vmethod_76(Class19 class19_0);

            public abstract bool vmethod_77(Class19 class19_0);

            public abstract bool vmethod_78(Class19 class19_0);

            public abstract bool vmethod_79(Class19 class19_0);

            public abstract bool vmethod_80(Class19 class19_0);

            public abstract bool vmethod_81(Class19 class19_0);

            public abstract bool vTminFdwf1(Class19 class19_0);

            public abstract bool vmethod_82(Class19 class19_0);

            public abstract bool vmethod_83(Class19 class19_0);

            internal override bool vmethod_3()
            {
                return true;
            }
        }

        private class Class24 : Class20
        {
            public double double_0;

            public Enum1 enum1_0;

            internal override void vmethod_10(Class19 class19_0)
            {
                this.double_0 = ((Class24)class19_0).double_0;
                this.enum1_0 = ((Class24)class19_0).enum1_0;
            }

            internal override void vmethod_2(Class19 class19_0)
            {
                this.vmethod_10(class19_0);
            }

            public Class24(double double_1)
            {
                base.enum4_0 = (Enum4)5;
                this.enum1_0 = (Enum1)10;
                this.double_0 = double_1;
            }

            public Class24(Class24 class24_0)
            {
                base.enum4_0 = class24_0.enum4_0;
                this.enum1_0 = class24_0.enum1_0;
                this.double_0 = class24_0.double_0;
            }

            public override Class20 vmethod_73()
            {
                return new Class24(this);
            }

            public Class24(double double_1, Enum1 enum1_1)
            {
                base.enum4_0 = (Enum4)5;
                this.double_0 = double_1;
                this.enum1_0 = enum1_1;
            }

            public Class24(float float_0)
            {
                base.enum4_0 = (Enum4)5;
                this.double_0 = float_0;
                this.enum1_0 = (Enum1)9;
            }

            public Class24(float float_0, Enum1 enum1_1)
            {
                base.enum4_0 = (Enum4)5;
                this.double_0 = float_0;
                this.enum1_0 = enum1_1;
            }

            public override bool vmethod_11()
            {
                return this.double_0 == 0.0;
            }

            public override bool vmethod_12()
            {
                return !this.vmethod_11();
            }

            public override string ToString()
            {
                return this.double_0.ToString();
            }

            public override Class19 vmethod_13(Enum1 enum1_1)
            {
                return enum1_1 switch
                {
                    (Enum1)1 => this.vmethod_15(), 
                    (Enum1)2 => this.vmethod_16(), 
                    (Enum1)3 => this.vmethod_17(), 
                    (Enum1)4 => this.vmethod_18(), 
                    (Enum1)5 => this.vmethod_19(), 
                    (Enum1)6 => this.vmethod_20(), 
                    (Enum1)7 => this.vmethod_21(), 
                    (Enum1)8 => this.vmethod_22(), 
                    (Enum1)9 => this.vmethod_47(), 
                    (Enum1)10 => this.vmethod_48(), 
                    (Enum1)11 => this.vmethod_14(), 
                    _ => throw new Exception(((Enum5)4).ToString()), 
                };
            }

            internal override object vmethod_4(Type type_0)
            {
                if (type_0 != null && type_0.IsByRef)
                {
                    type_0 = type_0.GetElementType();
                }
                if (type_0 == typeof(float))
                {
                    return (float)this.double_0;
                }
                if (type_0 == typeof(double))
                {
                    return this.double_0;
                }
                if ((type_0 == null || type_0 == typeof(object)) && this.enum1_0 == (Enum1)9)
                {
                    return (float)this.double_0;
                }
                return this.double_0;
            }

            public override Class21 vmethod_14()
            {
                return new Class21(this.vmethod_11() ? 1 : 0);
            }

            internal override bool vmethod_7()
            {
                return this.vmethod_12();
            }

            public override Class21 vmethod_15()
            {
                return new Class21((sbyte)this.double_0, (Enum1)1);
            }

            public override Class21 vmethod_16()
            {
                return new Class21((uint)(byte)this.double_0, (Enum1)2);
            }

            public override Class21 vmethod_17()
            {
                return new Class21((short)this.double_0, (Enum1)3);
            }

            public override Class21 vmethod_18()
            {
                return new Class21((uint)(ushort)this.double_0, (Enum1)4);
            }

            public override Class21 vmethod_19()
            {
                return new Class21((int)this.double_0, (Enum1)5);
            }

            public override Class21 vmethod_20()
            {
                return new Class21((uint)this.double_0, (Enum1)6);
            }

            public override Class22 vmethod_21()
            {
                return new Class22((long)this.double_0, (Enum1)7);
            }

            public override Class22 vmethod_22()
            {
                return new Class22((ulong)this.double_0, (Enum1)8);
            }

            public override Class21 vmethod_23()
            {
                return this.vmethod_15();
            }

            public override Class21 vmethod_24()
            {
                return this.vmethod_17();
            }

            public override Class21 vmethod_25()
            {
                return this.vmethod_19();
            }

            public override Class22 vmethod_26()
            {
                return this.vmethod_21();
            }

            public override Class21 vmethod_27()
            {
                return this.vmethod_16();
            }

            public override Class21 vmethod_28()
            {
                return this.vmethod_18();
            }

            public override Class21 vmethod_29()
            {
                return this.vmethod_20();
            }

            public override Class22 vmethod_30()
            {
                return this.vmethod_22();
            }

            public override Class21 vmethod_31()
            {
                return new Class21(checked((sbyte)this.double_0), (Enum1)1);
            }

            public override Class21 vmethod_32()
            {
                return new Class21(checked((sbyte)this.double_0), (Enum1)1);
            }

            public override Class21 vmethod_33()
            {
                return new Class21(checked((short)this.double_0), (Enum1)3);
            }

            public override Class21 vmethod_34()
            {
                return new Class21(checked((short)this.double_0), (Enum1)3);
            }

            public override Class21 vmethod_35()
            {
                return new Class21(checked((int)this.double_0), (Enum1)5);
            }

            public override Class21 vmethod_36()
            {
                return new Class21(checked((int)this.double_0), (Enum1)5);
            }

            public override Class22 vmethod_37()
            {
                return new Class22(checked((long)this.double_0), (Enum1)7);
            }

            public override Class22 vmethod_38()
            {
                return new Class22(checked((long)this.double_0), (Enum1)7);
            }

            public override Class21 vmethod_39()
            {
                return new Class21(checked((byte)this.double_0), (Enum1)2);
            }

            public override Class21 vmethod_40()
            {
                return new Class21(checked((byte)this.double_0), (Enum1)2);
            }

            public override Class21 vmethod_41()
            {
                return new Class21(checked((ushort)this.double_0), (Enum1)4);
            }

            public override Class21 vmethod_42()
            {
                return new Class21(checked((ushort)this.double_0), (Enum1)4);
            }

            public override Class21 vmethod_43()
            {
                return new Class21(checked((uint)this.double_0), (Enum1)6);
            }

            public override Class21 vmethod_44()
            {
                return new Class21(checked((uint)this.double_0), (Enum1)6);
            }

            public override Class22 vmethod_45()
            {
                return new Class22(checked((ulong)this.double_0), (Enum1)8);
            }

            public override Class22 vmethod_46()
            {
                return new Class22(checked((ulong)this.double_0), (Enum1)8);
            }

            public override Class24 vmethod_47()
            {
                return new Class24((float)this.double_0, (Enum1)9);
            }

            public override Class24 vmethod_48()
            {
                return new Class24(this.double_0, (Enum1)10);
            }

            public override Class24 vmethod_49()
            {
                return new Class24(this.double_0);
            }

            public override Class23 vmethod_50()
            {
                if (IntPtr.Size == 8)
                {
                    return new Class23(this.vmethod_26().struct5_0.long_0);
                }
                return new Class23(this.vmethod_25().struct4_0.int_0);
            }

            public override Class23 vmethod_51()
            {
                if (IntPtr.Size == 8)
                {
                    return new Class23(this.vmethod_30().struct5_0.ulong_0);
                }
                return new Class23((ulong)this.vmethod_29().struct4_0.uint_0);
            }

            public override Class23 vmethod_52()
            {
                if (IntPtr.Size == 8)
                {
                    return new Class23(this.vmethod_37().struct5_0.long_0);
                }
                return new Class23(this.vmethod_35().struct4_0.int_0);
            }

            public override Class23 vmethod_53()
            {
                if (IntPtr.Size == 8)
                {
                    return new Class23(this.vmethod_45().struct5_0.ulong_0);
                }
                return new Class23((ulong)this.vmethod_43().struct4_0.uint_0);
            }

            public override Class23 vmethod_54()
            {
                if (IntPtr.Size == 8)
                {
                    return new Class23(this.vmethod_38().struct5_0.long_0);
                }
                return new Class23(this.vmethod_36().struct4_0.int_0);
            }

            public override Class23 vmethod_55()
            {
                if (IntPtr.Size == 8)
                {
                    return new Class23(this.vmethod_46().struct5_0.ulong_0);
                }
                return new Class23((ulong)this.vmethod_44().struct4_0.uint_0);
            }

            public override Class19 vmethod_56()
            {
                if (this.enum1_0 == (Enum1)9)
                {
                    return new Class24((float)(0.0 - this.double_0));
                }
                return new Class24(0.0 - this.double_0);
            }

            public override Class19 Add(Class19 class19_0)
            {
                if (class19_0.vmethod_0())
                {
                    class19_0 = class19_0.vmethod_8();
                }
                if (!class19_0.method_4())
                {
                    throw new Exception1();
                }
                return new Class24(this.double_0 + ((Class24)class19_0).double_0);
            }

            public override Class19 vmethod_57(Class19 class19_0)
            {
                if (class19_0.vmethod_0())
                {
                    class19_0 = class19_0.vmethod_8();
                }
                if (!class19_0.method_4())
                {
                    throw new Exception1();
                }
                return new Class24(this.double_0 + ((Class24)class19_0).double_0);
            }

            public override Class19 vmethod_58(Class19 class19_0)
            {
                if (class19_0.vmethod_0())
                {
                    class19_0 = class19_0.vmethod_8();
                }
                if (!class19_0.method_4())
                {
                    throw new Exception1();
                }
                return new Class24(this.double_0 + ((Class24)class19_0).double_0);
            }

            public override Class19 vmethod_59(Class19 class19_0)
            {
                if (class19_0.vmethod_0())
                {
                    class19_0 = class19_0.vmethod_8();
                }
                if (!class19_0.method_4())
                {
                    throw new Exception1();
                }
                return new Class24(this.double_0 - ((Class24)class19_0).double_0);
            }

            public override Class19 vmethod_60(Class19 class19_0)
            {
                if (class19_0.vmethod_0())
                {
                    class19_0 = class19_0.vmethod_8();
                }
                if (!class19_0.method_4())
                {
                    throw new Exception1();
                }
                return new Class24(this.double_0 - ((Class24)class19_0).double_0);
            }

            public override Class19 vmethod_61(Class19 class19_0)
            {
                if (class19_0.vmethod_0())
                {
                    class19_0 = class19_0.vmethod_8();
                }
                if (!class19_0.method_4())
                {
                    throw new Exception1();
                }
                return new Class24(this.double_0 - ((Class24)class19_0).double_0);
            }

            public override Class19 vmethod_62(Class19 class19_0)
            {
                if (class19_0.vmethod_0())
                {
                    class19_0 = class19_0.vmethod_8();
                }
                if (!class19_0.method_4() || !class19_0.method_4())
                {
                    throw new Exception1();
                }
                return new Class24(this.double_0 * ((Class24)class19_0).double_0);
            }

            public override Class19 vmethod_63(Class19 class19_0)
            {
                if (class19_0.vmethod_0())
                {
                    class19_0 = class19_0.vmethod_8();
                }
                if (!class19_0.method_4())
                {
                    throw new Exception1();
                }
                return new Class24(this.double_0 * ((Class24)class19_0).double_0);
            }

            public override Class19 vmethod_64(Class19 class19_0)
            {
                if (class19_0.vmethod_0())
                {
                    class19_0 = class19_0.vmethod_8();
                }
                if (!class19_0.method_4())
                {
                    throw new Exception1();
                }
                return new Class24(this.double_0 * ((Class24)class19_0).double_0);
            }

            public override Class19 vmethod_65(Class19 class19_0)
            {
                if (class19_0.vmethod_0())
                {
                    class19_0 = class19_0.vmethod_8();
                }
                if (!class19_0.method_4())
                {
                    throw new Exception1();
                }
                return new Class24(this.double_0 / ((Class24)class19_0).double_0);
            }

            public override Class19 vmethod_66(Class19 class19_0)
            {
                if (class19_0.vmethod_0())
                {
                    class19_0 = class19_0.vmethod_8();
                }
                if (!class19_0.method_4())
                {
                    throw new Exception1();
                }
                return new Class24(this.double_0 / ((Class24)class19_0).double_0);
            }

            public override Class19 vmethod_67(Class19 class19_0)
            {
                if (class19_0.vmethod_0())
                {
                    class19_0 = class19_0.vmethod_8();
                }
                if (!class19_0.method_4())
                {
                    throw new Exception1();
                }
                return new Class24(this.double_0 % ((Class24)class19_0).double_0);
            }

            public override Class19 vmethod_68(Class19 class19_0)
            {
                if (class19_0.vmethod_0())
                {
                    class19_0 = class19_0.vmethod_8();
                }
                if (!class19_0.method_4())
                {
                    throw new Exception1();
                }
                return new Class24(this.double_0 % ((Class24)class19_0).double_0);
            }

            public override Class19 vmethod_69(Class19 class19_0)
            {
                throw new Exception1();
            }

            public override Class19 vmethod_70(Class19 class19_0)
            {
                throw new Exception1();
            }

            public override Class19 vmethod_71()
            {
                throw new Exception1();
            }

            public override Class19 vmethod_72(Class19 class19_0)
            {
                throw new Exception1();
            }

            public override Class19 vmethod_74(Class19 class19_0)
            {
                throw new Exception1();
            }

            public override Class19 vmethod_75(Class19 class19_0)
            {
                throw new Exception1();
            }

            public override Class19 vmethod_76(Class19 class19_0)
            {
                throw new Exception1();
            }

            internal override Class19 vmethod_8()
            {
                return this;
            }

            internal override bool vmethod_5(Class19 class19_0)
            {
                if (class19_0.method_0())
                {
                    return false;
                }
                if (class19_0.vmethod_0())
                {
                    return ((Class25)class19_0).vmethod_5(this);
                }
                Class19 @class = class19_0.vmethod_8();
                if (!@class.method_4())
                {
                    return false;
                }
                return this.double_0 == ((Class24)@class).double_0;
            }

            internal override bool vmethod_6(Class19 class19_0)
            {
                if (class19_0.method_0())
                {
                    return false;
                }
                if (class19_0.vmethod_0())
                {
                    return ((Class25)class19_0).vmethod_6(this);
                }
                Class19 @class = class19_0.vmethod_8();
                if (!@class.method_4())
                {
                    return false;
                }
                return this.double_0 != ((Class24)@class).double_0;
            }

            public override bool vmethod_77(Class19 class19_0)
            {
                if (class19_0.vmethod_0())
                {
                    class19_0 = class19_0.vmethod_8();
                }
                if (!class19_0.method_4())
                {
                    throw new Exception1();
                }
                return this.double_0 >= ((Class24)class19_0).double_0;
            }

            public override bool vmethod_78(Class19 class19_0)
            {
                if (class19_0.vmethod_0())
                {
                    class19_0 = class19_0.vmethod_8();
                }
                if (!class19_0.method_4())
                {
                    throw new Exception1();
                }
                return this.double_0 >= ((Class24)class19_0).double_0;
            }

            public override bool vmethod_79(Class19 class19_0)
            {
                if (class19_0.vmethod_0())
                {
                    class19_0 = class19_0.vmethod_8();
                }
                if (!class19_0.method_4())
                {
                    throw new Exception1();
                }
                return this.double_0 > ((Class24)class19_0).double_0;
            }

            public override bool vmethod_80(Class19 class19_0)
            {
                if (class19_0.vmethod_0())
                {
                    class19_0 = class19_0.vmethod_8();
                }
                if (!class19_0.method_4())
                {
                    throw new Exception1();
                }
                return this.double_0 > ((Class24)class19_0).double_0;
            }

            public override bool vmethod_81(Class19 class19_0)
            {
                if (class19_0.vmethod_0())
                {
                    class19_0 = class19_0.vmethod_8();
                }
                if (!class19_0.method_4())
                {
                    throw new Exception1();
                }
                return this.double_0 <= ((Class24)class19_0).double_0;
            }

            public override bool vTminFdwf1(Class19 class19_0)
            {
                if (class19_0.vmethod_0())
                {
                    class19_0 = class19_0.vmethod_8();
                }
                if (!class19_0.method_4())
                {
                    throw new Exception1();
                }
                return this.double_0 <= ((Class24)class19_0).double_0;
            }

            public override bool vmethod_82(Class19 class19_0)
            {
                if (class19_0.vmethod_0())
                {
                    class19_0 = class19_0.vmethod_8();
                }
                if (!class19_0.method_4())
                {
                    throw new Exception1();
                }
                return this.double_0 < ((Class24)class19_0).double_0;
            }

            public override bool vmethod_83(Class19 class19_0)
            {
                if (class19_0.vmethod_0())
                {
                    class19_0 = class19_0.vmethod_8();
                }
                if (!class19_0.method_4())
                {
                    throw new Exception1();
                }
                return this.double_0 < ((Class24)class19_0).double_0;
            }
        }

        internal enum Enum1 : byte
        {

        }

        internal enum Enum2 : byte
        {

        }

        private class Exception0 : Exception
        {
            public Exception0(string string_0)
                : base(string_0)
            {
            }
        }

        private class Exception1 : Exception
        {
            public Exception1()
            {
            }

            public Exception1(string string_0)
                : base(string_0)
            {
            }
        }

        internal class Class9
        {
            internal Enum3 enum3_0 = (Enum3)126;

            internal object object_0;

            public override string ToString()
            {
                object obj = this.enum3_0;
                if (this.object_0 != null)
                {
                    return obj.ToString() + 'H' + this.object_0.ToString();
                }
                return obj.ToString();
            }
        }

        internal abstract class Class25 : Class19
        {
            public Class25()
            {
            }

            internal override bool vmethod_0()
            {
                return true;
            }

            internal abstract IntPtr vmethod_11();

            internal abstract void XdGiHrMhoi(Class19 class19_0);

            internal override bool vmethod_1()
            {
                return true;
            }
        }

        internal class Class26 : Class25
        {
            private Class17 class17_0;

            internal int int_0;

            public Class26(int int_1, Class17 class17_1)
            {
                this.class17_0 = class17_1;
                this.int_0 = int_1;
                base.enum4_0 = (Enum4)7;
            }

            internal override void vmethod_10(Class19 class19_0)
            {
                if (class19_0 is Class26)
                {
                    this.class17_0 = ((Class26)class19_0).class17_0;
                    this.int_0 = ((Class26)class19_0).int_0;
                    return;
                }
                Class11 @class = this.class17_0.class14_0.list_1[this.int_0];
                if (class19_0 is Class25 && (int)(@class.enum1_0 & (Enum1)226) > 0)
                {
                    this.XdGiHrMhoi((class19_0 as Class25).vmethod_8());
                }
                else
                {
                    this.XdGiHrMhoi(class19_0);
                }
            }

            internal override void vmethod_2(Class19 class19_0)
            {
                this.XdGiHrMhoi(class19_0);
            }

            internal override IntPtr vmethod_11()
            {
                throw new NotImplementedException();
            }

            internal override void XdGiHrMhoi(Class19 class19_0)
            {
                this.class17_0.class19_1[this.int_0] = class19_0;
            }

            internal override object vmethod_4(Type type_0)
            {
                if (this.class17_0.class19_1[this.int_0] == null)
                {
                    return null;
                }
                return this.vmethod_8().vmethod_4(type_0);
            }

            internal override Class19 vmethod_8()
            {
                if (this.class17_0.class19_1[this.int_0] == null)
                {
                    return new Class31(null);
                }
                return this.class17_0.class19_1[this.int_0].vmethod_8();
            }

            internal override bool vmethod_9()
            {
                return this.vmethod_8().vmethod_9();
            }

            internal override bool vmethod_5(Class19 class19_0)
            {
                if (class19_0.vmethod_0())
                {
                    if (class19_0 is Class26)
                    {
                        if (((Class26)class19_0).int_0 == this.int_0)
                        {
                            return true;
                        }
                        return false;
                    }
                    return false;
                }
                return false;
            }

            internal override bool vmethod_6(Class19 class19_0)
            {
                if (class19_0.vmethod_0())
                {
                    if (class19_0 is Class26)
                    {
                        if (((Class26)class19_0).int_0 != this.int_0)
                        {
                            return true;
                        }
                        return false;
                    }
                    return true;
                }
                return true;
            }

            internal override bool vmethod_7()
            {
                return this.vmethod_8().vmethod_7();
            }
        }

        internal class Class27 : Class25
        {
            private Array array_0;

            internal int int_0;

            public Class27(int int_1, Array array_1)
            {
                this.array_0 = array_1;
                this.int_0 = int_1;
                base.enum4_0 = (Enum4)7;
            }

            internal override IntPtr vmethod_11()
            {
                throw new NotImplementedException();
            }

            internal override void vmethod_10(Class19 class19_0)
            {
                if (class19_0 is Class27)
                {
                    this.array_0 = ((Class27)class19_0).array_0;
                    this.int_0 = ((Class27)class19_0).int_0;
                }
                else
                {
                    this.XdGiHrMhoi(class19_0);
                }
            }

            internal override void vmethod_2(Class19 class19_0)
            {
                this.XdGiHrMhoi(class19_0);
            }

            internal override void XdGiHrMhoi(Class19 class19_0)
            {
                this.array_0.SetValue(class19_0.vmethod_4(null), this.int_0);
            }

            internal override object vmethod_4(Type type_0)
            {
                return this.vmethod_8().vmethod_4(type_0);
            }

            internal override Class19 vmethod_8()
            {
                return Class19.smethod_1(this.array_0.GetType().GetElementType(), this.array_0.GetValue(this.int_0));
            }

            internal override bool vmethod_9()
            {
                return this.vmethod_8().vmethod_9();
            }

            internal override bool vmethod_5(Class19 class19_0)
            {
                if (class19_0.vmethod_0())
                {
                    if (class19_0 is Class27)
                    {
                        Class27 @class = (Class27)class19_0;
                        if (@class.int_0 != this.int_0)
                        {
                            return false;
                        }
                        if (@class.array_0 != this.array_0)
                        {
                            return false;
                        }
                        return true;
                    }
                    return false;
                }
                return false;
            }

            internal override bool vmethod_6(Class19 class19_0)
            {
                if (class19_0.vmethod_0())
                {
                    if (class19_0 is Class27)
                    {
                        Class27 @class = (Class27)class19_0;
                        if (@class.int_0 != this.int_0)
                        {
                            return true;
                        }
                        if (@class.array_0 != this.array_0)
                        {
                            return true;
                        }
                        return false;
                    }
                    return true;
                }
                return true;
            }

            internal override bool vmethod_7()
            {
                return this.vmethod_8().vmethod_7();
            }
        }

        internal class Class28 : Class25
        {
            internal FieldInfo fieldInfo_0;

            internal object object_0;

            public Class28(FieldInfo fieldInfo_1, object object_1)
            {
                this.fieldInfo_0 = fieldInfo_1;
                this.object_0 = object_1;
                base.enum4_0 = (Enum4)7;
            }

            internal override IntPtr vmethod_11()
            {
                throw new NotImplementedException();
            }

            internal override void XdGiHrMhoi(Class19 class19_0)
            {
                if (this.object_0 != null && this.object_0 is Class19)
                {
                    this.fieldInfo_0.SetValue(((Class19)this.object_0).vmethod_4(null), class19_0.vmethod_4(null));
                }
                else
                {
                    this.fieldInfo_0.SetValue(this.object_0, class19_0.vmethod_4(null));
                }
            }

            internal override void vmethod_10(Class19 class19_0)
            {
                if (class19_0 is Class28)
                {
                    this.fieldInfo_0 = ((Class28)class19_0).fieldInfo_0;
                    this.object_0 = ((Class28)class19_0).object_0;
                }
                else
                {
                    this.XdGiHrMhoi(class19_0);
                }
            }

            internal override void vmethod_2(Class19 class19_0)
            {
                this.XdGiHrMhoi(class19_0);
            }

            internal override object vmethod_4(Type type_0)
            {
                return this.vmethod_8().vmethod_4(type_0);
            }

            internal override Class19 vmethod_8()
            {
                if (this.object_0 != null && this.object_0 is Class19)
                {
                    return Class19.smethod_1(this.fieldInfo_0.FieldType, this.fieldInfo_0.GetValue(((Class19)this.object_0).vmethod_4(null)));
                }
                return Class19.smethod_1(this.fieldInfo_0.FieldType, this.fieldInfo_0.GetValue(this.object_0));
            }

            internal override bool vmethod_9()
            {
                return this.vmethod_8().vmethod_9();
            }

            internal override bool vmethod_5(Class19 class19_0)
            {
                if (class19_0.vmethod_0())
                {
                    if (class19_0 is Class28)
                    {
                        Class28 @class = (Class28)class19_0;
                        if (@class.fieldInfo_0 != this.fieldInfo_0)
                        {
                            return false;
                        }
                        if (@class.object_0 != this.object_0)
                        {
                            return false;
                        }
                        return true;
                    }
                    return false;
                }
                return false;
            }

            internal override bool vmethod_6(Class19 class19_0)
            {
                if (class19_0.vmethod_0())
                {
                    if (class19_0 is Class28)
                    {
                        Class28 @class = (Class28)class19_0;
                        if (@class.fieldInfo_0 != this.fieldInfo_0)
                        {
                            return true;
                        }
                        if (@class.object_0 != this.object_0)
                        {
                            return true;
                        }
                        return false;
                    }
                    return true;
                }
                return true;
            }

            internal override bool vmethod_7()
            {
                return this.vmethod_8().vmethod_7();
            }
        }

        internal class Class29 : Class25
        {
            private Class17 class17_0;

            internal int int_0;

            public Class29(int int_1, Class17 class17_1)
            {
                this.class17_0 = class17_1;
                this.int_0 = int_1;
                base.enum4_0 = (Enum4)7;
            }

            internal override IntPtr vmethod_11()
            {
                throw new NotImplementedException();
            }

            internal override void vmethod_10(Class19 class19_0)
            {
                if (class19_0 is Class29)
                {
                    this.class17_0 = ((Class29)class19_0).class17_0;
                    this.int_0 = ((Class29)class19_0).int_0;
                }
                else
                {
                    this.XdGiHrMhoi(class19_0);
                }
            }

            internal override void vmethod_2(Class19 class19_0)
            {
                this.XdGiHrMhoi(class19_0);
            }

            internal override void XdGiHrMhoi(Class19 class19_0)
            {
                this.class17_0.class19_0[this.int_0] = class19_0;
            }

            internal override object vmethod_4(Type type_0)
            {
                if (this.class17_0.class19_0[this.int_0] == null)
                {
                    return null;
                }
                return this.vmethod_8().vmethod_4(type_0);
            }

            internal override Class19 vmethod_8()
            {
                if (this.class17_0.class19_0[this.int_0] == null)
                {
                    return new Class31(null);
                }
                return this.class17_0.class19_0[this.int_0].vmethod_8();
            }

            internal override bool vmethod_9()
            {
                return this.vmethod_8().vmethod_9();
            }

            internal override bool vmethod_5(Class19 class19_0)
            {
                if (class19_0.vmethod_0())
                {
                    if (class19_0 is Class29)
                    {
                        return ((Class29)class19_0).int_0 == this.int_0;
                    }
                    return false;
                }
                return false;
            }

            internal override bool vmethod_6(Class19 class19_0)
            {
                if (class19_0.vmethod_0())
                {
                    if (class19_0 is Class29)
                    {
                        return ((Class29)class19_0).int_0 != this.int_0;
                    }
                    return true;
                }
                return true;
            }

            internal override bool vmethod_7()
            {
                return this.vmethod_8().vmethod_7();
            }
        }

        internal class Class30 : Class25
        {
            private Class19 class19_0;

            private Type type_0;

            public Class30(Class19 class19_1, Type type_1)
            {
                this.class19_0 = class19_1;
                this.type_0 = type_1;
                base.enum4_0 = (Enum4)7;
            }

            internal override IntPtr vmethod_11()
            {
                throw new NotImplementedException();
            }

            internal override void vmethod_10(Class19 class19_1)
            {
                if (class19_1 is Class30)
                {
                    this.type_0 = ((Class30)class19_1).type_0;
                    this.class19_0 = ((Class30)class19_1).class19_0;
                }
                else
                {
                    this.class19_0.vmethod_10(class19_1);
                }
            }

            internal override void vmethod_2(Class19 class19_1)
            {
                this.XdGiHrMhoi(class19_1);
            }

            internal override void XdGiHrMhoi(Class19 class19_1)
            {
                this.class19_0 = class19_1;
            }

            internal override object vmethod_4(Type type_1)
            {
                if (this.class19_0 == null)
                {
                    return new Class31(null);
                }
                if (!(type_1 == null) && !(type_1 == typeof(object)))
                {
                    return this.class19_0.vmethod_4(type_1);
                }
                return this.class19_0.vmethod_4(this.type_0);
            }

            internal override Class19 vmethod_8()
            {
                if (this.class19_0 == null)
                {
                    return new Class31(null);
                }
                return this.class19_0.vmethod_8();
            }

            internal override bool vmethod_9()
            {
                return this.vmethod_8().vmethod_9();
            }

            internal override bool vmethod_5(Class19 class19_1)
            {
                if (class19_1.vmethod_0())
                {
                    if (class19_1 is Class30)
                    {
                        Class30 @class = (Class30)class19_1;
                        if (@class.type_0 != this.type_0)
                        {
                            return false;
                        }
                        if (this.class19_0 == null)
                        {
                            if (@class.class19_0 == null)
                            {
                                return true;
                            }
                            return false;
                        }
                        return this.class19_0.vmethod_5(@class.class19_0);
                    }
                    return false;
                }
                return false;
            }

            internal override bool vmethod_6(Class19 class19_1)
            {
                if (class19_1.vmethod_0())
                {
                    if (class19_1 is Class30)
                    {
                        Class30 @class = (Class30)class19_1;
                        if (@class.type_0 != this.type_0)
                        {
                            return true;
                        }
                        if (this.class19_0 == null)
                        {
                            if (@class.class19_0 != null)
                            {
                                return true;
                            }
                            return false;
                        }
                        return this.class19_0.vmethod_6(@class.class19_0);
                    }
                    return true;
                }
                return true;
            }

            internal override bool vmethod_7()
            {
                return this.vmethod_8().vmethod_7();
            }
        }

        internal class Class10
        {
            public int int_0;

            public bool bool_0;

            public Enum1 enum1_0;

            public Class10()
            {
                throw /*Error near IL_0001: Stack underflow*/;
            }
        }

        internal class Class11
        {
            public int int_0;

            public Enum1 enum1_0;

            public bool bool_0;

            public Type type_0 = typeof(object);
        }

        internal class Class12
        {
            public int int_0;

            public int bOdiOkNrnU;

            public Class13 class13_0;

            public Class12()
            {
                throw /*Error near IL_0001: Stack underflow*/;
            }
        }

        internal class Class13
        {
            public int int_0;

            public int int_1;

            public byte byte_0;

            public Type type_0;

            public int int_2;

            public int int_3;

            public Class13()
            {
                throw /*Error near IL_0001: Stack underflow*/;
            }
        }

        internal class Class14
        {
            internal MethodBase methodBase_0;

            internal List<Class9> list_0;

            internal Class10[] class10_0;

            internal List<Class11> list_1;

            internal List<Class12> list_2;

            public Class14()
            {
                throw /*Error near IL_0001: Stack underflow*/;
            }
        }

        private class Class15
        {
            internal FieldInfo fieldInfo_0;

            internal int int_0;

            public Class15(FieldInfo fieldInfo_1, int int_1)
            {
                this.fieldInfo_0 = fieldInfo_1;
                this.int_0 = int_1;
            }
        }

        private class Class16
        {
            private List<Class15> list_0 = new List<Class15>();

            private MethodBase methodBase_0;

            public Class16(MethodBase methodBase_1, List<Class15> list_1)
            {
                this.list_0 = list_1;
                this.methodBase_0 = methodBase_1;
            }

            public Class16(MethodBase methodBase_1, Class15[] class15_0)
            {
                this.list_0.AddRange(class15_0);
            }

            public override bool Equals(object obj)
            {
                Class16 @class = obj as Class16;
                if (obj == null)
                {
                    return false;
                }
                if (this.methodBase_0 != @class.methodBase_0)
                {
                    return false;
                }
                if (this.list_0.Count != @class.list_0.Count)
                {
                    return false;
                }
                int num = 0;
                while (true)
                {
                    if (num < this.list_0.Count)
                    {
                        if (this.list_0[num].fieldInfo_0 != @class.list_0[num].fieldInfo_0)
                        {
                            break;
                        }
                        if (this.list_0[num].int_0 == @class.list_0[num].int_0)
                        {
                            num++;
                            continue;
                        }
                        return false;
                    }
                    return true;
                }
                return false;
            }

            public override int GetHashCode()
            {
                int num = this.methodBase_0.GetHashCode();
                foreach (Class15 item in this.list_0)
                {
                    int num2 = item.fieldInfo_0.GetHashCode() + item.int_0;
                    num = (num ^ num2) + num2;
                }
                return num;
            }

            public Class15 method_0(int int_0)
            {
                foreach (Class15 item in this.list_0)
                {
                    if (item.int_0 == int_0)
                    {
                        return item;
                    }
                }
                return null;
            }

            public bool method_1(int int_0)
            {
                foreach (Class15 item in this.list_0)
                {
                    if (item.int_0 == int_0)
                    {
                        return true;
                    }
                }
                return false;
            }
        }

        private delegate object Delegate10(object target, object[] paramters);

        private delegate object Delegate11(object target);

        private delegate void Delegate12(IntPtr a, byte b, int c);

        private delegate void Delegate13(IntPtr s, IntPtr t, uint c);

        internal class Class17
        {
            [Serializable]
            [CompilerGenerated]
            private sealed class Class18
            {
                public static readonly Class18 _003C_003E9;

                public static Comparison<Class12> _003C_003E9__12_0;

                static Class18()
                {
                    Class18._003C_003E9 = new Class18();
                }

                public Class18()
                {
                    throw /*Error near IL_0001: Stack underflow*/;
                }

                internal int method_0(Class12 x, Class12 y)
                {
                    return x.class13_0.int_0.CompareTo(y.class13_0.int_0);
                }
            }

            internal Class14 class14_0;

            internal Class19[] class19_0 = new Class19[0];

            internal Class19[] class19_1 = new Class19[0];

            internal Class33 class33_0 = new Class33();

            internal Class19 class19_2;

            internal Exception exception_0;

            internal List<IntPtr> list_0;

            private int int_0;

            private int int_1;

            private int int_2 = -1;

            private object object_0;

            private bool bool_0;

            private bool bool_1;

            private bool bool_2;

            private bool bool_3;

            private static Dictionary<Type, int> dictionary_0;

            private static Dictionary<object, Class19> dictionary_1;

            private static Dictionary<MethodBase, Delegate10> dictionary_2;

            private static Dictionary<MethodBase, Delegate10> dictionary_3;

            private static Dictionary<Class16, Delegate10> dictionary_4;

            private static Dictionary<Class16, Delegate10> dictionary_5;

            private static Dictionary<Class16, Delegate10> dictionary_6;

            private static Dictionary<Type, Delegate11> dictionary_7;

            private static Delegate12 delegate12_0;

            private static Delegate13 delegate13_0;

            internal void method_0()
            {
                bool bool_ = false;
                this.method_2(ref bool_);
            }

            internal void method_1()
            {
                this.class33_0.method_1();
                this.class19_1 = null;
                if (this.list_0 == null)
                {
                    return;
                }
                foreach (IntPtr item in this.list_0)
                {
                    try
                    {
                        Marshal.FreeHGlobal(item);
                    }
                    catch
                    {
                    }
                }
                this.list_0.Clear();
                this.list_0 = null;
            }

            internal void method_2(ref bool bool_4)
            {
                while (true)
                {
                    if (this.bool_0)
                    {
                        this.bool_0 = false;
                        int num = this.int_1;
                        int num2 = this.int_0;
                        this.method_4(this.int_1, this.int_0);
                        this.int_0 = num2;
                        this.int_1 = num;
                    }
                    if (this.bool_2)
                    {
                        break;
                    }
                    if (!this.bool_1)
                    {
                        this.int_1 = this.int_0;
                        Class9 @class = this.class14_0.list_0[this.int_0];
                        this.object_0 = @class.object_0;
                        try
                        {
                            this.method_7(@class);
                        }
                        catch (Exception innerException)
                        {
                            if (innerException is TargetInvocationException)
                            {
                                TargetInvocationException ex = (TargetInvocationException)innerException;
                                if (ex.InnerException != null)
                                {
                                    innerException = ex.InnerException;
                                }
                            }
                            this.exception_0 = innerException;
                            bool_4 = true;
                            this.class33_0.method_1();
                            int int_ = this.int_1;
                            Class12 class2 = this.method_5(int_, innerException);
                            List<Class12> list = this.method_6(int_, bool_4: false);
                            List<Class12> list2 = new List<Class12>();
                            if (class2 != null)
                            {
                                list2.Add(class2);
                            }
                            if (list != null && list.Count > 0)
                            {
                                list2.AddRange(list);
                            }
                            list2.Sort((Class12 x, Class12 y) => x.class13_0.int_0.CompareTo(y.class13_0.int_0));
                            Class12 class3 = null;
                            foreach (Class12 item in list2)
                            {
                                if (item.class13_0.int_3 != 0)
                                {
                                    this.class33_0.method_2(new Class31(innerException));
                                    this.int_1 = item.class13_0.int_2;
                                    this.int_0 = this.int_1;
                                    this.method_0();
                                    if (this.bool_3)
                                    {
                                        this.bool_3 = false;
                                        class3 = item;
                                        break;
                                    }
                                    continue;
                                }
                                class3 = item;
                                break;
                            }
                            if (class3 == null)
                            {
                                throw innerException;
                            }
                            this.int_2 = class3.class13_0.int_0;
                            this.method_3(int_, class3.class13_0.int_0);
                            if (this.int_2 >= 0)
                            {
                                this.class33_0.method_2(new Class31(innerException));
                                this.int_1 = this.int_2;
                                this.int_0 = this.int_1;
                                this.int_2 = -1;
                                this.method_0();
                            }
                            return;
                        }
                        this.int_0++;
                        if (this.int_0 > -2)
                        {
                            continue;
                        }
                        this.class33_0.method_1();
                        return;
                    }
                    this.bool_1 = false;
                    return;
                }
                this.bool_2 = false;
            }

            internal void method_3(int int_3, int int_4)
            {
                if (this.class14_0.list_2 == null)
                {
                    return;
                }
                using List<Class12>.Enumerator enumerator = this.class14_0.list_2.GetEnumerator();
                do
                {
                    Class12 current = enumerator.Current;
                    if ((current.class13_0.int_3 == 4 || current.class13_0.int_3 == 2) && current.class13_0.int_0 >= int_3 && current.class13_0.int_1 <= int_4)
                    {
                        this.int_1 = current.class13_0.int_0;
                        this.int_0 = this.int_1;
                        bool bool_ = false;
                        this.method_2(ref bool_);
                        if (bool_)
                        {
                            break;
                        }
                    }
                }
                while (enumerator.MoveNext());
            }

            internal void method_4(int int_3, int int_4)
            {
                if (this.class14_0.list_2 == null)
                {
                    return;
                }
                using List<Class12>.Enumerator enumerator = this.class14_0.list_2.GetEnumerator();
                do
                {
                    Class12 current = enumerator.Current;
                    if (current.class13_0.int_3 == 2 && current.class13_0.int_0 >= int_3 && current.class13_0.int_1 <= int_4)
                    {
                        this.int_1 = current.class13_0.int_0;
                        this.int_0 = this.int_1;
                        bool bool_ = false;
                        this.method_2(ref bool_);
                        if (bool_)
                        {
                            break;
                        }
                    }
                }
                while (enumerator.MoveNext());
            }

            internal Class12 method_5(int int_3, Exception exception_1)
            {
                Class12 @class = null;
                if (this.class14_0.list_2 != null)
                {
                    using (List<Class12>.Enumerator enumerator = this.class14_0.list_2.GetEnumerator())
                    {
                        do
                        {
                            Class12 current = enumerator.Current;
                            if (current.class13_0.int_3 == 0 && (current.class13_0.type_0 == exception_1.GetType() || (current.class13_0.type_0 != null && (current.class13_0.type_0.FullName == exception_1.GetType().FullName || current.class13_0.type_0.FullName == typeof(object).FullName || current.class13_0.type_0.FullName == typeof(Exception).FullName))) && int_3 >= current.int_0 && int_3 <= current.bOdiOkNrnU)
                            {
                                if (@class == null)
                                {
                                    @class = current;
                                }
                                else if (current.class13_0.int_0 < @class.class13_0.int_0)
                                {
                                    @class = current;
                                }
                            }
                        }
                        while (enumerator.MoveNext());
                        return @class;
                    }
                }
                return @class;
            }

            internal List<Class12> method_6(int int_3, bool bool_4)
            {
                if (this.class14_0.list_2 == null)
                {
                    return null;
                }
                List<Class12> list = new List<Class12>();
                foreach (Class12 item in this.class14_0.list_2)
                {
                    if ((item.class13_0.int_3 & 1) == 1 && int_3 >= item.int_0 && int_3 <= item.bOdiOkNrnU)
                    {
                        list.Add(item);
                    }
                }
                if (list.Count == 0)
                {
                    return null;
                }
                return list;
            }

            private unsafe void method_7(Class9 class9_0)
            {
                switch (class9_0.enum3_0)
                {
                    case (Enum3)0:
                        this.class33_0.method_2(new Class31(null));
                        break;
                    case (Enum3)1:
                    {
                        int metadataToken4 = (int)this.object_0;
                        FieldInfo fieldInfo = typeof(Class8).Module.ResolveField(metadataToken4);
                        this.class33_0.method_2(Class19.smethod_1(fieldInfo.FieldType, fieldInfo.GetValue(null)));
                        break;
                    }
                    case (Enum3)2:
                    {
                        Class20 @class = Class17.smethod_1(this.class33_0.method_4());
                        Class20 class2 = Class17.smethod_1(this.class33_0.method_4());
                        if (class2 != null && @class != null)
                        {
                            this.class33_0.method_2(class2.vmethod_67(@class));
                            break;
                        }
                        throw new Exception1();
                    }
                    case (Enum3)3:
                    {
                        int metadataToken12 = (int)this.object_0;
                        Type type = typeof(Class8).Module.ResolveType(metadataToken12);
                        Class19 value = this.class33_0.method_4();
                        object value3 = value.vmethod_4(null);
                        if (value3 == null)
                        {
                            this.class33_0.method_2(new Class31(null));
                        }
                        else if (!type.IsAssignableFrom(value3.GetType()))
                        {
                            this.class33_0.method_2(new Class31(null));
                        }
                        else
                        {
                            this.class33_0.method_2(value);
                        }
                        break;
                    }
                    case (Enum3)5:
                    {
                        Class20 @class = Class17.smethod_1(this.class33_0.method_4());
                        if (@class != null)
                        {
                            this.class33_0.method_2(@class.vmethod_29());
                            break;
                        }
                        throw new Exception1();
                    }
                    case (Enum3)6:
                    {
                        Class20 @class = Class17.smethod_1(this.class33_0.method_4());
                        Class20 class2 = Class17.smethod_1(this.class33_0.method_4());
                        if (class2 != null && @class != null)
                        {
                            this.class33_0.method_2(class2.vmethod_57(@class));
                            break;
                        }
                        throw new Exception1();
                    }
                    case (Enum3)7:
                    {
                        Class19 value = this.class33_0.method_4();
                        if (value.vmethod_3())
                        {
                            value = ((Class20)value).vmethod_23();
                        }
                        this.class33_0.method_4().vmethod_2(value);
                        break;
                    }
                    case (Enum3)8:
                    {
                        Type type = typeof(Class8).Module.ResolveType((int)this.object_0);
                        object value3 = this.class33_0.method_4().vmethod_4(type);
                        if (value3 == null)
                        {
                            value3 = Activator.CreateInstance(type);
                        }
                        this.class33_0.method_2(new Class31(Class19.smethod_1(type, Class17.smethod_9(value3))));
                        break;
                    }
                    case (Enum3)9:
                    {
                        Class20 class32 = Class17.smethod_1(this.class33_0.method_4());
                        object value13 = ((Array)this.class33_0.method_4().vmethod_4(null)).GetValue(class32.vmethod_19().struct4_0.int_0);
                        this.class33_0.method_2(Class19.smethod_1(typeof(int), value13));
                        break;
                    }
                    case (Enum3)11:
                    {
                        Class20 @class = Class17.smethod_1(this.class33_0.method_4());
                        if (@class != null)
                        {
                            this.class33_0.method_2(@class.vmethod_36());
                            break;
                        }
                        throw new Exception1();
                    }
                    case (Enum3)12:
                    {
                        Class20 @class = Class17.smethod_1(this.class33_0.method_4());
                        if (@class != null)
                        {
                            this.class33_0.method_2(@class.vmethod_33());
                            break;
                        }
                        throw new Exception1();
                    }
                    case (Enum3)13:
                    {
                        IntPtr intPtr = Marshal.AllocHGlobal((this.class33_0.method_4() as Class20).vmethod_19().struct4_0.int_0);
                        if (this.list_0 == null)
                        {
                            this.list_0 = new List<IntPtr>();
                        }
                        this.list_0.Add(intPtr);
                        this.class33_0.method_2(new Class23(intPtr));
                        break;
                    }
                    case (Enum3)14:
                    {
                        Class19 class15 = this.class33_0.method_4();
                        if (Class17.smethod_1(this.class33_0.method_4()).vmethod_78(class15))
                        {
                            this.int_0 = (int)this.object_0 - 1;
                        }
                        break;
                    }
                    case (Enum3)15:
                    {
                        int metadataToken11 = (int)this.object_0;
                        Type type = typeof(Class8).Module.ResolveType(metadataToken11);
                        object value3 = ((this.class33_0.method_4() as Class25) ?? throw new Exception1()).vmethod_4(type);
                        Class19 value;
                        if (value3 == null)
                        {
                            value = ((!type.IsValueType) ? new Class31(null) : Class19.smethod_1(type, Activator.CreateInstance(type)));
                        }
                        else
                        {
                            if (type.IsValueType)
                            {
                                value3 = Class17.smethod_9(value3);
                            }
                            value = Class19.smethod_1(type, value3);
                        }
                        this.class33_0.method_2(value);
                        break;
                    }
                    case (Enum3)16:
                    {
                        Class19 class11 = this.class33_0.method_4();
                        if (Class17.smethod_1(this.class33_0.method_4()).vmethod_82(class11))
                        {
                            this.int_0 = (int)this.object_0 - 1;
                        }
                        break;
                    }
                    case (Enum3)17:
                    {
                        Array obj4 = (Array)this.class33_0.method_4().vmethod_4(null);
                        this.class33_0.method_2(new Class21(obj4.Length, (Enum1)5));
                        break;
                    }
                    case (Enum3)18:
                    {
                        Class20 @class = Class17.smethod_1(this.class33_0.method_4());
                        Class20 class2 = Class17.smethod_1(this.class33_0.method_4());
                        if (@class != null && class2 != null)
                        {
                            this.class33_0.method_2(@class.vmethod_70(class2));
                            break;
                        }
                        throw new Exception1();
                    }
                    case (Enum3)19:
                    {
                        Class20 @class = Class17.smethod_1(this.class33_0.method_4());
                        Class20 class2 = Class17.smethod_1(this.class33_0.method_4());
                        if (class2 != null && @class != null)
                        {
                            this.class33_0.method_2(class2.vmethod_63(@class));
                            break;
                        }
                        throw new Exception1();
                    }
                    case (Enum3)20:
                        throw this.exception_0;
                    case (Enum3)21:
                    {
                        Class19 class23 = this.class33_0.method_4();
                        if (Class17.smethod_1(this.class33_0.method_4()).vmethod_79(class23))
                        {
                            this.int_0 = (int)this.object_0 - 1;
                        }
                        break;
                    }
                    case (Enum3)22:
                        this.bool_2 = true;
                        break;
                    case (Enum3)23:
                    {
                        Class19 value = this.class33_0.method_4();
                        Class20 @class = Class17.smethod_1(value);
                        if (value != null && value.vmethod_0() && @class != null)
                        {
                            this.class33_0.method_2(@class.vmethod_27());
                            break;
                        }
                        if (@class != null && @class.method_2())
                        {
                            IntPtr intPtr6 = ((Class23)@class).method_7();
                            this.class33_0.method_2(new Class21(*(byte*)(void*)intPtr6, (Enum1)2));
                            break;
                        }
                        throw new Exception1();
                    }
                    case (Enum3)24:
                    {
                        Class20 @class = Class17.smethod_1(this.class33_0.method_4());
                        Class20 class2 = Class17.smethod_1(this.class33_0.method_4());
                        if (class2 != null && @class != null)
                        {
                            this.class33_0.method_2(class2.Add(@class));
                            break;
                        }
                        throw new Exception1();
                    }
                    case (Enum3)25:
                        this.class33_0.method_4();
                        break;
                    case (Enum3)26:
                        this.bool_3 = (bool)this.class33_0.method_4().vmethod_4(typeof(bool));
                        this.bool_1 = true;
                        break;
                    case (Enum3)27:
                    {
                        int[] array3 = (int[])this.object_0;
                        Class20 @class = Class17.smethod_1(this.class33_0.method_4());
                        long num5 = @class.vmethod_21().struct5_0.long_0;
                        if ((num5 < 0L || @class.method_4()) && IntPtr.Size == 4)
                        {
                            num5 = (int)num5;
                        }
                        if (@class.method_1())
                        {
                            Class21 class26 = (Class21)@class;
                            if (class26.enum1_0 == (Enum1)6)
                            {
                                num5 = class26.struct4_0.uint_0;
                            }
                        }
                        if (num5 < array3.Length && num5 >= 0L)
                        {
                            this.int_0 = array3[num5] - 1;
                        }
                        break;
                    }
                    case (Enum3)28:
                    {
                        Class19 value = this.class33_0.method_4();
                        Class20 @class = Class17.smethod_1(value);
                        if (value != null && value.vmethod_0() && @class != null)
                        {
                            this.class33_0.method_2(@class.vmethod_48());
                            break;
                        }
                        if (@class != null && @class.method_2())
                        {
                            IntPtr intPtr9 = ((Class23)@class).method_7();
                            this.class33_0.method_2(new Class24(*(double*)(void*)intPtr9, (Enum1)10));
                            break;
                        }
                        throw new Exception1();
                    }
                    case (Enum3)29:
                    {
                        Class19 class16 = this.class33_0.method_4();
                        if (Class17.smethod_1(this.class33_0.method_4()).vmethod_82(class16))
                        {
                            this.class33_0.method_2(new Class21(1));
                        }
                        else
                        {
                            this.class33_0.method_2(new Class21(0));
                        }
                        break;
                    }
                    case (Enum3)30:
                    {
                        object value3 = this.class33_0.method_4().vmethod_4(null);
                        Class19 value = null;
                        if (Class17.dictionary_1.TryGetValue(value3, out value))
                        {
                            this.class33_0.method_2(value);
                        }
                        else
                        {
                            this.class33_0.method_2(new Class31(null));
                        }
                        break;
                    }
                    case (Enum3)31:
                    {
                        int num = (int)this.object_0;
                        if (this.class14_0.methodBase_0.IsStatic)
                        {
                            this.class19_0[num] = this.method_8(this.class33_0.method_4(), this.class14_0.class10_0[num].enum1_0);
                        }
                        else
                        {
                            this.class19_0[num] = this.method_8(this.class33_0.method_4(), this.class14_0.class10_0[num - 1].enum1_0);
                        }
                        break;
                    }
                    case (Enum3)32:
                    {
                        Class20 @class = Class17.smethod_1(this.class33_0.method_4());
                        Class20 class2 = Class17.smethod_1(this.class33_0.method_4());
                        if (class2 != null && @class != null)
                        {
                            this.class33_0.method_2(class2.vmethod_76(@class));
                            break;
                        }
                        throw new Exception1();
                    }
                    case (Enum3)33:
                    {
                        int metadataToken17 = (int)this.object_0;
                        Type type = typeof(Class8).Module.ResolveType(metadataToken17);
                        if (!(this.class33_0.method_4() is Class25 class31))
                        {
                            throw new Exception1();
                        }
                        if (type.IsValueType)
                        {
                            class31.XdGiHrMhoi(Class19.smethod_1(type, Activator.CreateInstance(type)));
                        }
                        else
                        {
                            class31.XdGiHrMhoi(new Class31(null));
                        }
                        break;
                    }
                    case (Enum3)34:
                    {
                        Class19 value = this.class33_0.method_4();
                        Class20 @class = Class17.smethod_1(value);
                        Class19 class19_ = this.class33_0.method_4();
                        Class20 class2 = Class17.smethod_1(class19_);
                        if (class2 != null && @class != null)
                        {
                            if (class2.vmethod_80(value))
                            {
                                this.int_0 = (int)this.object_0 - 1;
                            }
                        }
                        else if (value.vmethod_6(class19_))
                        {
                            this.int_0 = (int)this.object_0 - 1;
                        }
                        break;
                    }
                    case (Enum3)35:
                    {
                        int metadataToken14 = (int)this.object_0;
                        Array array4 = Array.CreateInstance(typeof(Class8).Module.ResolveType(metadataToken14), Class17.smethod_1(this.class33_0.method_4()).vmethod_19().struct4_0.int_0);
                        this.class33_0.method_2(new Class31(array4));
                        break;
                    }
                    case (Enum3)36:
                    {
                        Class20 @class = Class17.smethod_1(this.class33_0.method_4());
                        if (@class != null)
                        {
                            this.class33_0.method_2(@class.vmethod_44());
                            break;
                        }
                        throw new Exception1();
                    }
                    case (Enum3)38:
                    {
                        Class19 obj9 = this.class19_1[(int)this.object_0];
                        this.class33_0.method_2(obj9);
                        break;
                    }
                    case (Enum3)39:
                    {
                        Class20 @class = Class17.smethod_1(this.class33_0.method_4());
                        if (@class != null)
                        {
                            this.class33_0.method_2(@class.vmethod_30());
                            break;
                        }
                        throw new Exception1();
                    }
                    case (Enum3)40:
                    {
                        Class19 value = this.class33_0.method_4();
                        Class20 @class = Class17.smethod_1(value);
                        if (value != null && value.vmethod_0() && @class != null)
                        {
                            this.class33_0.method_2(@class.vmethod_25());
                            break;
                        }
                        if (@class != null && @class.method_2())
                        {
                            IntPtr intPtr8 = ((Class23)@class).method_7();
                            this.class33_0.method_2(new Class21(*(int*)(void*)intPtr8, (Enum1)5));
                            break;
                        }
                        throw new Exception1();
                    }
                    case (Enum3)41:
                    {
                        Class20 class18 = Class17.smethod_1(this.class33_0.method_4());
                        object value6 = ((Array)this.class33_0.method_4().vmethod_4(null)).GetValue(class18.vmethod_19().struct4_0.int_0);
                        this.class33_0.method_2(Class19.smethod_1(typeof(float), value6));
                        break;
                    }
                    case (Enum3)42:
                    {
                        Class20 @class = Class17.smethod_1(this.class33_0.method_4());
                        Class20 class2 = (Class20)this.class33_0.method_4();
                        if (class2 != null && @class != null)
                        {
                            this.class33_0.method_2(class2.vmethod_60(@class));
                            break;
                        }
                        throw new Exception1();
                    }
                    case (Enum3)43:
                    {
                        int num = (int)this.object_0;
                        Module module = typeof(Class8).Module;
                        object value3 = null;
                        try
                        {
                            value3 = module.ResolveType(num);
                        }
                        catch
                        {
                            try
                            {
                                value3 = module.ResolveMethod(num);
                            }
                            catch
                            {
                                try
                                {
                                    value3 = module.ResolveField(num);
                                    goto end_IL_123e;
                                }
                                catch
                                {
                                    value3 = module.ResolveMember(num);
                                    goto end_IL_123e;
                                }
                                end_IL_123e:;
                            }
                        }
                        this.class33_0.method_2(new Class31(value3));
                        break;
                    }
                    case (Enum3)44:
                        throw (Exception)this.class33_0.method_4().vmethod_4(null);
                    case (Enum3)45:
                    {
                        int metadataToken6 = (int)this.object_0;
                        FieldInfo fieldInfo_ = typeof(Class8).Module.ResolveField(metadataToken6);
                        this.class33_0.method_2(new Class28(fieldInfo_, null));
                        break;
                    }
                    case (Enum3)46:
                        this.class33_0.method_2(new Class21((int)this.object_0));
                        break;
                    case (Enum3)48:
                    {
                        Class20 @class = Class17.smethod_1(this.class33_0.method_4());
                        if (@class != null)
                        {
                            this.class33_0.method_2(@class.vmethod_38());
                            break;
                        }
                        throw new Exception1();
                    }
                    case (Enum3)49:
                    {
                        Class19 value = this.class33_0.method_4();
                        Class20 @class = Class17.smethod_1(value);
                        if (value != null && value.vmethod_0() && @class != null)
                        {
                            this.class33_0.method_2(@class.vmethod_28());
                            break;
                        }
                        if (@class != null && @class.method_2())
                        {
                            IntPtr intPtr3 = ((Class23)@class).method_7();
                            this.class33_0.method_2(new Class21(*(ushort*)(void*)intPtr3, (Enum1)4));
                            break;
                        }
                        throw new Exception1();
                    }
                    case (Enum3)50:
                    {
                        Class20 @class = Class17.smethod_1(this.class33_0.method_4());
                        if (@class != null)
                        {
                            this.class33_0.method_2(@class.vmethod_53());
                            break;
                        }
                        throw new Exception1();
                    }
                    case (Enum3)51:
                    {
                        Class19 value = this.class33_0.method_4();
                        Class20 @class = Class17.smethod_1(value);
                        Class19 class19_ = this.class33_0.method_4();
                        Class20 class2 = Class17.smethod_1(class19_);
                        if (class2 != null && @class != null)
                        {
                            if (class2.vmethod_80(value))
                            {
                                this.class33_0.method_2(new Class21(1));
                            }
                            else
                            {
                                this.class33_0.method_2(new Class21(0));
                            }
                        }
                        else if (value.vmethod_6(class19_))
                        {
                            this.class33_0.method_2(new Class21(1));
                        }
                        else
                        {
                            this.class33_0.method_2(new Class21(0));
                        }
                        break;
                    }
                    case (Enum3)53:
                    {
                        Class19 class27 = this.class33_0.method_4();
                        bool num6 = Class17.smethod_1(this.class33_0.method_4()).vmethod_83(class27);
                        if (num6)
                        {
                            this.class33_0.method_2(new Class21(1));
                        }
                        else
                        {
                            this.class33_0.method_2(new Class21(0));
                        }
                        if (num6)
                        {
                            this.int_0 = (int)this.object_0 - 1;
                        }
                        break;
                    }
                    case (Enum3)54:
                        this.int_0 = (int)this.object_0 - 1;
                        this.bool_0 = true;
                        break;
                    case (Enum3)55:
                    {
                        Class19 value = this.class33_0.method_4();
                        if (value.vmethod_3())
                        {
                            value = ((Class20)value).vmethod_25();
                        }
                        this.class33_0.method_4().vmethod_2(value);
                        break;
                    }
                    case (Enum3)56:
                    {
                        Class20 @class = Class17.smethod_1(this.class33_0.method_4());
                        if (@class != null)
                        {
                            this.class33_0.method_2(@class.vmethod_37());
                            break;
                        }
                        throw new Exception1();
                    }
                    case (Enum3)58:
                    {
                        Class20 @class = Class17.smethod_1(this.class33_0.method_4());
                        if (@class != null)
                        {
                            this.class33_0.method_2(@class.vmethod_48());
                            break;
                        }
                        throw new Exception1();
                    }
                    case (Enum3)59:
                    {
                        Class20 @class = Class17.smethod_1(this.class33_0.method_4());
                        if (@class != null)
                        {
                            this.class33_0.method_2(@class.vmethod_41());
                            break;
                        }
                        throw new Exception1();
                    }
                    case (Enum3)60:
                    {
                        Class20 @class = Class17.smethod_1(this.class33_0.method_4());
                        if (@class != null)
                        {
                            this.class33_0.method_2(@class.vmethod_23());
                            break;
                        }
                        throw new Exception1();
                    }
                    case (Enum3)61:
                        this.int_0 = -3;
                        if (this.class33_0.method_0() > 0)
                        {
                            this.class19_2 = this.class33_0.method_4();
                        }
                        break;
                    case (Enum3)62:
                    {
                        int metadataToken9 = (int)this.object_0;
                        FieldInfo fieldInfo = typeof(Class8).Module.ResolveField(metadataToken9);
                        fieldInfo.SetValue(null, this.class33_0.method_4().vmethod_4(fieldInfo.FieldType));
                        break;
                    }
                    case (Enum3)63:
                    {
                        Class20 class20 = Class17.smethod_1(this.class33_0.method_4());
                        object value8 = ((Array)this.class33_0.method_4().vmethod_4(null)).GetValue(class20.vmethod_19().struct4_0.int_0);
                        this.class33_0.method_2(Class19.smethod_1(typeof(IntPtr), value8));
                        break;
                    }
                    case (Enum3)65:
                    {
                        Class19 value = this.class33_0.method_4();
                        if (value.vmethod_3())
                        {
                            value = ((Class20)value).vmethod_24();
                        }
                        this.class33_0.method_4().vmethod_2(value);
                        break;
                    }
                    case (Enum3)66:
                    {
                        Class19 value = this.class33_0.method_4();
                        if (value.vmethod_3())
                        {
                            value = ((Class20)value).vmethod_47();
                        }
                        this.class33_0.method_4().vmethod_2(value);
                        break;
                    }
                    case (Enum3)69:
                    {
                        Class20 @class = Class17.smethod_1(this.class33_0.method_4());
                        Class20 class2 = Class17.smethod_1(this.class33_0.method_4());
                        if (class2 != null && @class != null)
                        {
                            this.class33_0.method_2(class2.vmethod_65(@class));
                            break;
                        }
                        throw new Exception1();
                    }
                    case (Enum3)70:
                    {
                        Class19 value = this.class33_0.method_4();
                        Class20 @class = Class17.smethod_1(value);
                        if (value != null && value.vmethod_0() && @class != null)
                        {
                            this.class33_0.method_2(@class.vmethod_24());
                            break;
                        }
                        if (@class != null && @class.method_2())
                        {
                            IntPtr intPtr5 = ((Class23)@class).method_7();
                            this.class33_0.method_2(new Class21(*(short*)(void*)intPtr5, (Enum1)3));
                            break;
                        }
                        throw new Exception1();
                    }
                    case (Enum3)71:
                    {
                        Class20 @class = Class17.smethod_1(this.class33_0.method_4());
                        if (@class != null)
                        {
                            this.class33_0.method_2(@class.vmethod_54());
                            break;
                        }
                        throw new Exception1();
                    }
                    case (Enum3)73:
                    {
                        Class19 value = this.class33_0.method_4();
                        if (value.vmethod_3())
                        {
                            value = ((Class20)value).vmethod_50();
                        }
                        this.class33_0.method_4().vmethod_2(value);
                        break;
                    }
                    case (Enum3)74:
                    {
                        Class20 @class = Class17.smethod_1(this.class33_0.method_4());
                        if (@class != null)
                        {
                            this.class33_0.method_2(@class.vmethod_52());
                            break;
                        }
                        throw new Exception1();
                    }
                    case (Enum3)76:
                    {
                        int metadataToken2 = (int)this.object_0;
                        FieldInfo fieldInfo = typeof(Class8).Module.ResolveField(metadataToken2);
                        object obj2 = this.class33_0.method_4().vmethod_4(null);
                        this.class33_0.method_2(Class19.smethod_1(fieldInfo.FieldType, fieldInfo.GetValue(obj2)));
                        break;
                    }
                    case (Enum3)77:
                    {
                        Class20 @class = this.class33_0.method_4() as Class20;
                        IntPtr intPtr = Class17.smethod_8(this.class33_0.method_4());
                        IntPtr intPtr2 = Class17.smethod_8(this.class33_0.method_4());
                        if (intPtr != IntPtr.Zero && intPtr2 != IntPtr.Zero)
                        {
                            Class17.smethod_11(intPtr2, intPtr, @class.vmethod_20().struct4_0.uint_0);
                        }
                        break;
                    }
                    case (Enum3)78:
                    {
                        Class19 value = this.class33_0.method_4();
                        object key = this.class33_0.method_4().vmethod_4(null);
                        Class17.dictionary_1[key] = value;
                        break;
                    }
                    case (Enum3)79:
                    {
                        Class20 @class = Class17.smethod_1(this.class33_0.method_4());
                        if (@class != null)
                        {
                            this.class33_0.method_2(@class.vmethod_39());
                            break;
                        }
                        throw new Exception1();
                    }
                    case (Enum3)80:
                    {
                        Class20 @class = Class17.smethod_1(this.class33_0.method_4());
                        Class20 class2 = Class17.smethod_1(this.class33_0.method_4());
                        if (class2 != null && @class != null)
                        {
                            this.class33_0.method_2(class2.vmethod_75(@class));
                            break;
                        }
                        throw new Exception1();
                    }
                    case (Enum3)81:
                        this.class33_0.method_2(((Class20)this.class33_0.method_4()).vmethod_56());
                        break;
                    case (Enum3)82:
                        this.int_0 = (int)this.object_0 - 1;
                        break;
                    case (Enum3)83:
                    {
                        Class20 @class = Class17.smethod_1(this.class33_0.method_4());
                        if (@class != null)
                        {
                            this.class33_0.method_2(@class.vmethod_25());
                            break;
                        }
                        throw new Exception1();
                    }
                    case (Enum3)84:
                    {
                        Class20 class30 = Class17.smethod_1(this.class33_0.method_4());
                        object value12 = ((Array)this.class33_0.method_4().vmethod_4(null)).GetValue(class30.vmethod_19().struct4_0.int_0);
                        this.class33_0.method_2(Class19.smethod_1(typeof(short), value12));
                        break;
                    }
                    case (Enum3)86:
                    {
                        int metadataToken16 = (int)this.object_0;
                        typeof(Class8).Module.ResolveType(metadataToken16);
                        Class20 @class = Class17.smethod_1(this.class33_0.method_4());
                        Array array_ = (Array)this.class33_0.method_4().vmethod_4(null);
                        this.class33_0.method_2(new Class27(@class.vmethod_19().struct4_0.int_0, array_));
                        break;
                    }
                    case (Enum3)87:
                        if (this.class33_0.method_4().vmethod_5(this.class33_0.method_4()))
                        {
                            this.int_0 = (int)this.object_0 - 1;
                        }
                        break;
                    case (Enum3)88:
                    {
                        Class20 class29 = Class17.smethod_1(this.class33_0.method_4());
                        object value11 = ((Array)this.class33_0.method_4().vmethod_4(null)).GetValue(class29.vmethod_19().struct4_0.int_0);
                        this.class33_0.method_2(Class19.smethod_1(typeof(long), value11));
                        break;
                    }
                    case (Enum3)89:
                    {
                        int metadataToken15 = (int)this.object_0;
                        Type type = typeof(Class8).Module.ResolveType(metadataToken15);
                        Class19 value = this.class33_0.method_4();
                        Class20 class28 = Class17.smethod_1(this.class33_0.method_4());
                        ((Array)this.class33_0.method_4().vmethod_4(null)).SetValue(value.vmethod_4(type), class28.vmethod_19().struct4_0.int_0);
                        break;
                    }
                    case (Enum3)90:
                    {
                        Class20 @class = Class17.smethod_1(this.class33_0.method_4());
                        Class20 class2 = Class17.smethod_1(this.class33_0.method_4());
                        if (class2 != null && @class != null)
                        {
                            this.class33_0.method_2(class2.vmethod_62(@class));
                            break;
                        }
                        throw new Exception1();
                    }
                    case (Enum3)91:
                    {
                        Class19 value = this.class33_0.method_4();
                        if (value.vmethod_3())
                        {
                            value = ((Class20)value).vmethod_26();
                        }
                        this.class33_0.method_4().vmethod_2(value);
                        break;
                    }
                    case (Enum3)92:
                    {
                        Class20 @class = Class17.smethod_1(this.class33_0.method_4());
                        Class20 class2 = Class17.smethod_1(this.class33_0.method_4());
                        if (class2 != null && @class != null)
                        {
                            this.class33_0.method_2(class2.vmethod_68(@class));
                            break;
                        }
                        throw new Exception1();
                    }
                    case (Enum3)93:
                    {
                        Class19 class25 = this.class33_0.method_4();
                        if (Class17.smethod_1(this.class33_0.method_4()).vmethod_77(class25))
                        {
                            this.int_0 = (int)this.object_0 - 1;
                        }
                        break;
                    }
                    case (Enum3)94:
                    {
                        Class20 @class = Class17.smethod_1(this.class33_0.method_4());
                        if (@class != null)
                        {
                            this.class33_0.method_2(@class.vmethod_51());
                            break;
                        }
                        throw new Exception1();
                    }
                    case (Enum3)95:
                    {
                        Class20 @class = Class17.smethod_1(this.class33_0.method_4());
                        if (@class != null)
                        {
                            this.class33_0.method_2(@class.vmethod_27());
                            break;
                        }
                        throw new Exception1();
                    }
                    case (Enum3)96:
                        if (this.class33_0.method_4().vmethod_6(this.class33_0.method_4()))
                        {
                            this.int_0 = (int)this.object_0 - 1;
                        }
                        break;
                    case (Enum3)97:
                    {
                        int metadataToken13 = (int)this.object_0;
                        Type type = typeof(Class8).Module.ResolveType(metadataToken13);
                        Class19 class22 = Class19.smethod_1(type, this.class33_0.method_4().vmethod_8().vmethod_4(type));
                        this.class33_0.method_2(class22);
                        break;
                    }
                    case (Enum3)75:
                    case (Enum3)98:
                    {
                        int metadataToken10 = (int)this.object_0;
                        Type type = typeof(Class8).Module.ResolveType(metadataToken10);
                        object value3 = this.class33_0.method_4().vmethod_4(type);
                        Class19 value;
                        if (value3 == null)
                        {
                            value = ((!type.IsValueType) ? new Class31(null) : Class19.smethod_1(type, Activator.CreateInstance(type)));
                        }
                        else
                        {
                            if (type.IsValueType)
                            {
                                value3 = Class17.smethod_9(value3);
                            }
                            value = Class19.smethod_1(type, value3);
                        }
                        ((this.class33_0.method_4() as Class25) ?? throw new Exception1()).vmethod_10(value);
                        break;
                    }
                    case (Enum3)99:
                    {
                        Class19 value = this.class33_0.method_4();
                        if (value.vmethod_0())
                        {
                            object value3 = value.vmethod_4(null);
                            value = ((value3 == null) ? new Class31(null) : Class19.smethod_1(value3.GetType(), value3));
                            this.class33_0.method_2(value);
                            break;
                        }
                        throw new Exception1();
                    }
                    case (Enum3)100:
                    {
                        Class20 class19 = Class17.smethod_1(this.class33_0.method_4());
                        object value7 = ((Array)this.class33_0.method_4().vmethod_4(null)).GetValue(class19.vmethod_19().struct4_0.int_0);
                        this.class33_0.method_2(Class19.smethod_1(typeof(ushort), value7));
                        break;
                    }
                    case (Enum3)101:
                    {
                        Class19 value = this.class33_0.method_4();
                        Class20 @class = Class17.smethod_1(value);
                        if (value != null && value.vmethod_0() && @class != null)
                        {
                            this.class33_0.method_2(@class.vmethod_29());
                            break;
                        }
                        if (@class != null && @class.method_2())
                        {
                            IntPtr intPtr7 = ((Class23)@class).method_7();
                            this.class33_0.method_2(new Class21(*(uint*)(void*)intPtr7, (Enum1)6));
                            break;
                        }
                        throw new Exception1();
                    }
                    case (Enum3)102:
                    {
                        Class20 @class = Class17.smethod_1(this.class33_0.method_4());
                        if (@class != null)
                        {
                            this.class33_0.method_2(@class.vmethod_55());
                            break;
                        }
                        throw new Exception1();
                    }
                    case (Enum3)103:
                    {
                        Class20 class14 = Class17.smethod_1(this.class33_0.method_4());
                        object value5 = ((Array)this.class33_0.method_4().vmethod_4(null)).GetValue(class14.vmethod_19().struct4_0.int_0);
                        this.class33_0.method_2(Class19.smethod_1(typeof(double), value5));
                        break;
                    }
                    case (Enum3)104:
                    {
                        Class20 @class = Class17.smethod_1(this.class33_0.method_4());
                        Class20 class2 = Class17.smethod_1(this.class33_0.method_4());
                        if (@class != null && class2 != null)
                        {
                            this.class33_0.method_2(@class.vmethod_72(class2));
                            break;
                        }
                        throw new Exception1();
                    }
                    case (Enum3)105:
                    {
                        Class20 @class = Class17.smethod_1(this.class33_0.method_4());
                        Class20 class2 = Class17.smethod_1(this.class33_0.method_4());
                        if (class2 != null && @class != null)
                        {
                            this.class33_0.method_2(class2.vmethod_74(@class));
                            break;
                        }
                        throw new Exception1();
                    }
                    case (Enum3)106:
                    {
                        Class20 @class = Class17.smethod_1(this.class33_0.method_4());
                        if (@class != null)
                        {
                            this.class33_0.method_2(@class.vmethod_50());
                            break;
                        }
                        throw new Exception1();
                    }
                    case (Enum3)107:
                    {
                        int metadataToken3 = (int)this.object_0;
                        ConstructorInfo constructorInfo = (ConstructorInfo)typeof(Class8).Module.ResolveMethod(metadataToken3);
                        ParameterInfo[] parameters = constructorInfo.GetParameters();
                        object[] array = new object[parameters.Length];
                        Class19[] array2 = new Class19[parameters.Length];
                        List<Class15> list = null;
                        Class16 class6 = null;
                        int num2 = default(int);
                        do
                        {
                            Class19 value = this.class33_0.method_4();
                            Type type = parameters[parameters.Length - 1 - num2].ParameterType;
                            object obj = null;
                            bool flag = false;
                            if (type.IsByRef && value is Class28 class7)
                            {
                                if (list == null)
                                {
                                    list = new List<Class15>();
                                }
                                list.Add(new Class15(class7.fieldInfo_0, num2));
                                obj = class7.object_0;
                                if (obj is Class19)
                                {
                                    value = obj as Class19;
                                }
                                else
                                {
                                    flag = true;
                                }
                            }
                            if (!flag)
                            {
                                if (value != null)
                                {
                                    obj = value.vmethod_4(type);
                                }
                                if (obj == null)
                                {
                                    if (type.IsByRef)
                                    {
                                        type = type.GetElementType();
                                    }
                                    if (type.IsValueType)
                                    {
                                        obj = Activator.CreateInstance(type);
                                        if (value is Class26)
                                        {
                                            ((Class25)value).XdGiHrMhoi(Class19.smethod_1(type, obj));
                                        }
                                    }
                                }
                            }
                            array2[array.Length - 1 - num2] = value;
                            array[array.Length - 1 - num2] = obj;
                            num2++;
                        }
                        while (num2 < parameters.Length);
                        Delegate10 @delegate = null;
                        if (list != null)
                        {
                            class6 = new Class16(constructorInfo, list);
                            @delegate = Class17.smethod_4(constructorInfo, bool_4: true, class6);
                        }
                        object value3 = null;
                        value3 = ((@delegate == null) ? constructorInfo.Invoke(array) : @delegate(null, array));
                        int num3 = default(int);
                        do
                        {
                            if (parameters[num3].ParameterType.IsByRef && (class6 == null || !class6.method_1(num3)))
                            {
                                if (array2[num3].method_2())
                                {
                                    ((Class23)array2[num3]).method_6(Class19.smethod_1(parameters[num3].ParameterType, array[num3]));
                                }
                                else if (array2[num3] is Class26)
                                {
                                    array2[num3].vmethod_10(Class19.smethod_1(parameters[num3].ParameterType.GetElementType(), array[num3]));
                                }
                                else
                                {
                                    array2[num3].vmethod_10(Class19.smethod_1(parameters[num3].ParameterType, array[num3]));
                                }
                            }
                            num3++;
                        }
                        while (num3 < parameters.Length);
                        this.class33_0.method_2(Class19.smethod_1(constructorInfo.DeclaringType, value3));
                        break;
                    }
                    case (Enum3)108:
                    {
                        Class19 class5 = this.class33_0.method_4();
                        if (Class17.smethod_1(this.class33_0.method_4()).vmethod_83(class5))
                        {
                            this.class33_0.method_2(new Class21(1));
                        }
                        else
                        {
                            this.class33_0.method_2(new Class21(0));
                        }
                        break;
                    }
                    case (Enum3)109:
                    {
                        Class19 class8 = this.class33_0.method_4();
                        if (Class17.smethod_1(this.class33_0.method_4()).vmethod_79(class8))
                        {
                            this.class33_0.method_2(new Class21(1));
                        }
                        else
                        {
                            this.class33_0.method_2(new Class21(0));
                        }
                        break;
                    }
                    case (Enum3)110:
                        this.class33_0.method_2(new Class24((float)this.object_0));
                        break;
                    case (Enum3)112:
                    {
                        int num = (int)this.object_0;
                        this.class19_1[num] = this.method_8(this.class33_0.method_4(), this.class14_0.list_1[num].enum1_0, this.class14_0.list_1[num].bool_0);
                        break;
                    }
                    case (Enum3)113:
                    {
                        Class20 @class = Class17.smethod_1(this.class33_0.method_4());
                        if (@class != null)
                        {
                            this.class33_0.method_2(@class.vmethod_40());
                            break;
                        }
                        throw new Exception1();
                    }
                    case (Enum3)114:
                    {
                        Class20 class3 = Class17.smethod_1(this.class33_0.method_4());
                        object value2 = ((Array)this.class33_0.method_4().vmethod_4(null)).GetValue(class3.vmethod_19().struct4_0.int_0);
                        this.class33_0.method_2(Class19.smethod_1(typeof(uint), value2));
                        break;
                    }
                    case (Enum3)115:
                    {
                        Class19 value = this.class33_0.method_4();
                        if (value.vmethod_3())
                        {
                            value = ((Class20)value).vmethod_48();
                        }
                        this.class33_0.method_4().vmethod_2(value);
                        break;
                    }
                    case (Enum3)116:
                    {
                        Class19 value = this.class33_0.method_4();
                        Class20 @class = Class17.smethod_1(value);
                        if (value != null && value.vmethod_0() && @class != null)
                        {
                            this.class33_0.method_2(@class.vmethod_23());
                            break;
                        }
                        if (@class != null && @class.method_2())
                        {
                            IntPtr intPtr11 = ((Class23)@class).method_7();
                            this.class33_0.method_2(new Class21(*(sbyte*)(void*)intPtr11, (Enum1)1));
                            break;
                        }
                        throw new Exception1();
                    }
                    case (Enum3)117:
                    {
                        Class20 @class = Class17.smethod_1(this.class33_0.method_4());
                        Class20 class2 = Class17.smethod_1(this.class33_0.method_4());
                        if (class2 != null && @class != null)
                        {
                            this.class33_0.method_2(class2.vmethod_64(@class));
                            break;
                        }
                        throw new Exception1();
                    }
                    case (Enum3)119:
                    {
                        Class20 @class = Class17.smethod_1(this.class33_0.method_4());
                        if (@class != null)
                        {
                            this.class33_0.method_2(@class.vmethod_45());
                            break;
                        }
                        throw new Exception1();
                    }
                    case (Enum3)121:
                        this.method_12(bool_4: true);
                        break;
                    case (Enum3)122:
                    {
                        bool flag = false;
                        Class19 value = this.class33_0.method_4();
                        if (value == null || !value.vmethod_7())
                        {
                            this.int_0 = (int)this.object_0 - 1;
                        }
                        break;
                    }
                    case (Enum3)124:
                        this.method_12(bool_4: false);
                        break;
                    case (Enum3)126:
                    {
                        Class19 value = this.class33_0.method_4();
                        Class20 @class = Class17.smethod_1(value);
                        if (value != null && value.vmethod_0() && @class != null)
                        {
                            this.class33_0.method_2(@class.vmethod_47());
                            break;
                        }
                        if (@class != null && @class.method_2())
                        {
                            IntPtr intPtr10 = ((Class23)@class).method_7();
                            this.class33_0.method_2(new Class24(*(float*)(void*)intPtr10, (Enum1)9));
                            break;
                        }
                        throw new Exception1();
                    }
                    case (Enum3)127:
                    {
                        Class20 @class = Class17.smethod_1(this.class33_0.method_4());
                        if (@class != null)
                        {
                            this.class33_0.method_2(@class.vmethod_71());
                            break;
                        }
                        throw new Exception1();
                    }
                    case (Enum3)128:
                    {
                        Class20 @class = Class17.smethod_1(this.class33_0.method_4());
                        Class20 class2 = Class17.smethod_1(this.class33_0.method_4());
                        if (class2 != null && @class != null)
                        {
                            this.class33_0.method_2(class2.vmethod_61(@class));
                            break;
                        }
                        throw new Exception1();
                    }
                    case (Enum3)129:
                    {
                        Class20 @class = Class17.smethod_1(this.class33_0.method_4());
                        if (@class != null)
                        {
                            this.class33_0.method_2(@class.vmethod_26());
                            break;
                        }
                        throw new Exception1();
                    }
                    case (Enum3)130:
                    {
                        Class20 class24 = Class17.smethod_1(this.class33_0.method_4());
                        object value10 = ((Array)this.class33_0.method_4().vmethod_4(null)).GetValue(class24.vmethod_19().struct4_0.int_0);
                        this.class33_0.method_2(Class19.smethod_1(typeof(byte), value10));
                        break;
                    }
                    case (Enum3)131:
                    {
                        Class19 value = this.class33_0.method_4();
                        Class20 @class = Class17.smethod_1(value);
                        if (value != null && value.vmethod_0() && @class != null)
                        {
                            this.class33_0.method_2(@class.vmethod_50());
                            break;
                        }
                        if (@class != null && @class.method_2())
                        {
                            IntPtr intPtr = ((Class23)@class).method_7();
                            if (IntPtr.Size == 8)
                            {
                                long long_ = *(long*)(void*)intPtr;
                                this.class33_0.method_2(new Class23(long_, (Enum1)12));
                            }
                            else
                            {
                                int num4 = *(int*)(void*)intPtr;
                                this.class33_0.method_2(new Class23(num4, (Enum1)12));
                            }
                            break;
                        }
                        throw new Exception1();
                    }
                    case (Enum3)132:
                    {
                        Class20 @class = this.class33_0.method_4() as Class20;
                        Class20 class2 = this.class33_0.method_4() as Class20;
                        IntPtr intPtr = Class17.smethod_8(this.class33_0.method_4());
                        if (intPtr != IntPtr.Zero)
                        {
                            Class17.smethod_10(intPtr, class2.vmethod_16().struct4_0.byte_0, (int)@class.vmethod_20().struct4_0.uint_0);
                        }
                        break;
                    }
                    case (Enum3)133:
                    {
                        Class20 class21 = Class17.smethod_1(this.class33_0.method_4());
                        object value9 = ((Array)this.class33_0.method_4().vmethod_4(null)).GetValue(class21.vmethod_19().struct4_0.int_0);
                        this.class33_0.method_2(Class19.smethod_1(typeof(sbyte), value9));
                        break;
                    }
                    case (Enum3)134:
                        if (Class17.smethod_6(this.class33_0.method_4()).vmethod_5(Class17.smethod_6(this.class33_0.method_4())))
                        {
                            this.class33_0.method_2(new Class21(1));
                        }
                        else
                        {
                            this.class33_0.method_2(new Class21(0));
                        }
                        break;
                    case (Enum3)85:
                    case (Enum3)135:
                    {
                        int num = (int)this.object_0;
                        Module module = typeof(Class8).Module;
                        this.class33_0.method_2(new Class23(module.ResolveMethod(num).MethodHandle.GetFunctionPointer()));
                        break;
                    }
                    case (Enum3)136:
                        this.class33_0.method_2(new Class26((int)this.object_0, this));
                        break;
                    case (Enum3)137:
                        if (Class8.list_0.Count == 0)
                        {
                            Module module2 = typeof(Class8).Module;
                            this.class33_0.method_2(new Class32(module2.ResolveString((int)this.object_0 | 0x70000000)));
                        }
                        else
                        {
                            this.class33_0.method_2(new Class32(Class8.list_0[(int)this.object_0]));
                        }
                        break;
                    case (Enum3)138:
                        this.class33_0.method_2(this.class33_0.method_4().vmethod_8());
                        break;
                    case (Enum3)139:
                    {
                        Class20 @class = Class17.smethod_1(this.class33_0.method_4());
                        Class20 class2 = Class17.smethod_1(this.class33_0.method_4());
                        if (class2 != null && @class != null)
                        {
                            this.class33_0.method_2(class2.vmethod_66(@class));
                            break;
                        }
                        throw new Exception1();
                    }
                    case (Enum3)140:
                    {
                        Class20 @class = Class17.smethod_1(this.class33_0.method_4());
                        if (@class != null)
                        {
                            this.class33_0.method_2(@class.vmethod_46());
                            break;
                        }
                        throw new Exception1();
                    }
                    case (Enum3)141:
                    {
                        Class20 @class = Class17.smethod_1(this.class33_0.method_4());
                        if (@class != null)
                        {
                            this.class33_0.method_2(@class.vmethod_24());
                            break;
                        }
                        throw new Exception1();
                    }
                    case (Enum3)142:
                    {
                        Class20 @class = Class17.smethod_1(this.class33_0.method_4());
                        Array obj8 = (Array)this.class33_0.method_4().vmethod_4(null);
                        object value3 = obj8.GetValue(@class.vmethod_19().struct4_0.int_0);
                        Type elementType = obj8.GetType().GetElementType();
                        this.class33_0.method_2(Class19.smethod_1(elementType, value3));
                        break;
                    }
                    case (Enum3)64:
                    case (Enum3)67:
                    case (Enum3)68:
                    case (Enum3)118:
                    case (Enum3)123:
                    case (Enum3)143:
                        break;
                    case (Enum3)144:
                        this.class33_0.method_2(new Class22((long)this.object_0));
                        break;
                    case (Enum3)145:
                    {
                        Class20 @class = Class17.smethod_1(this.class33_0.method_4());
                        if (@class != null)
                        {
                            this.class33_0.method_2(@class.vmethod_28());
                            break;
                        }
                        throw new Exception1();
                    }
                    case (Enum3)146:
                        break;
                    case (Enum3)147:
                        if ((Class17.smethod_1(this.class33_0.method_3()) ?? throw new ArithmeticException(((Enum5)0).ToString())) is Class24 class17)
                        {
                            if (double.IsNaN(class17.double_0))
                            {
                                throw new OverflowException(((Enum5)2).ToString());
                            }
                            if (double.IsInfinity(class17.double_0))
                            {
                                throw new OverflowException(((Enum5)1).ToString());
                            }
                        }
                        break;
                    case (Enum3)148:
                        this.class33_0.method_2(new Class29((int)this.object_0, this));
                        break;
                    case (Enum3)149:
                    {
                        Class20 @class = Class17.smethod_1(this.class33_0.method_4());
                        if (@class != null)
                        {
                            this.class33_0.method_2(@class.vmethod_47());
                            break;
                        }
                        throw new Exception1();
                    }
                    case (Enum3)150:
                    {
                        Class20 @class = Class17.smethod_1(this.class33_0.method_4());
                        if (@class != null)
                        {
                            this.class33_0.method_2(@class.vmethod_42());
                            break;
                        }
                        throw new Exception1();
                    }
                    case (Enum3)152:
                    {
                        int metadataToken8 = (int)this.object_0;
                        int uint_ = Class17.smethod_0(typeof(Class8).Module.ResolveType(metadataToken8));
                        this.class33_0.method_2(new Class21((uint)uint_, (Enum1)6));
                        break;
                    }
                    case (Enum3)153:
                    {
                        Class20 @class = Class17.smethod_1(this.class33_0.method_4());
                        Class20 class2 = Class17.smethod_1(this.class33_0.method_4());
                        if (class2 != null && @class != null)
                        {
                            this.class33_0.method_2(class2.vmethod_58(@class));
                            break;
                        }
                        throw new Exception1();
                    }
                    case (Enum3)155:
                        this.class33_0.method_2(this.class33_0.method_3());
                        break;
                    case (Enum3)156:
                    {
                        Class20 @class = Class17.smethod_1(this.class33_0.method_4());
                        if (@class != null)
                        {
                            this.class33_0.method_2(@class.vmethod_49());
                            break;
                        }
                        throw new Exception1();
                    }
                    case (Enum3)157:
                    {
                        Class20 @class = Class17.smethod_1(this.class33_0.method_4());
                        if (@class != null)
                        {
                            this.class33_0.method_2(@class.vmethod_34());
                            break;
                        }
                        throw new Exception1();
                    }
                    case (Enum3)158:
                    {
                        int metadataToken7 = (int)this.object_0;
                        Type type = typeof(Class8).Module.ResolveType(metadataToken7);
                        Class20 class13 = Class17.smethod_1(this.class33_0.method_4());
                        object value4 = ((Array)this.class33_0.method_4().vmethod_4(null)).GetValue(class13.vmethod_19().struct4_0.int_0);
                        this.class33_0.method_2(Class19.smethod_1(type, value4));
                        break;
                    }
                    case (Enum3)159:
                    {
                        Class20 @class = Class17.smethod_1(this.class33_0.method_4());
                        Class20 class2 = Class17.smethod_1(this.class33_0.method_4());
                        if (class2 != null && @class != null)
                        {
                            this.class33_0.method_2(class2.vmethod_59(@class));
                            break;
                        }
                        throw new Exception1();
                    }
                    case (Enum3)160:
                    {
                        Class19 class12 = this.class33_0.method_4();
                        if (Class17.smethod_1(this.class33_0.method_4()).vTminFdwf1(class12))
                        {
                            this.int_0 = (int)this.object_0 - 1;
                        }
                        break;
                    }
                    case (Enum3)161:
                    {
                        Class19 value = this.class33_0.method_4();
                        if (value != null && value.vmethod_7())
                        {
                            this.int_0 = (int)this.object_0 - 1;
                        }
                        break;
                    }
                    case (Enum3)162:
                    {
                        Class20 @class = Class17.smethod_1(this.class33_0.method_4());
                        if (@class != null)
                        {
                            this.class33_0.method_2(@class.vmethod_35());
                            break;
                        }
                        throw new Exception1();
                    }
                    case (Enum3)4:
                    case (Enum3)10:
                    case (Enum3)57:
                    case (Enum3)111:
                    case (Enum3)120:
                    case (Enum3)125:
                    case (Enum3)154:
                    case (Enum3)163:
                    {
                        Class19 value = this.class33_0.method_4();
                        Class20 @class = Class17.smethod_1(this.class33_0.method_4());
                        Array obj3 = (Array)this.class33_0.method_4().vmethod_4(null);
                        obj3.SetValue(value.vmethod_4(obj3.GetType().GetElementType()), @class.vmethod_19().struct4_0.int_0);
                        break;
                    }
                    case (Enum3)164:
                    {
                        Class20 @class = Class17.smethod_1(this.class33_0.method_4());
                        if (@class != null)
                        {
                            this.class33_0.method_2(@class.vmethod_43());
                            break;
                        }
                        throw new Exception1();
                    }
                    case (Enum3)165:
                    {
                        Class19 class10 = this.class33_0.method_4();
                        this.class33_0.method_4().vmethod_2(class10);
                        break;
                    }
                    case (Enum3)166:
                    {
                        int metadataToken5 = (int)this.object_0;
                        FieldInfo fieldInfo = typeof(Class8).Module.ResolveField(metadataToken5);
                        Class19 class9 = this.class33_0.method_4();
                        class9.vmethod_8();
                        object object_ = class9.vmethod_4(null);
                        this.class33_0.method_2(new Class28(fieldInfo, object_));
                        break;
                    }
                    case (Enum3)167:
                    {
                        Class19 value = this.class33_0.method_4();
                        Class20 @class = Class17.smethod_1(value);
                        if (value != null && value.vmethod_0() && @class != null)
                        {
                            this.class33_0.method_2(@class.vmethod_26());
                            break;
                        }
                        if (@class != null && @class.method_2())
                        {
                            IntPtr intPtr4 = ((Class23)@class).method_7();
                            this.class33_0.method_2(new Class22(*(long*)(void*)intPtr4, (Enum1)7));
                            break;
                        }
                        throw new Exception1();
                    }
                    case (Enum3)37:
                    case (Enum3)47:
                    case (Enum3)52:
                    case (Enum3)72:
                    case (Enum3)151:
                    case (Enum3)168:
                        throw new Exception1();
                    case (Enum3)169:
                        this.class33_0.method_2(this.class19_0[(int)this.object_0]);
                        break;
                    case (Enum3)170:
                    {
                        int metadataToken = (int)this.object_0;
                        FieldInfo fieldInfo = typeof(Class8).Module.ResolveField(metadataToken);
                        object value3 = this.class33_0.method_4().vmethod_4(fieldInfo.FieldType);
                        Class19 value = this.class33_0.method_4();
                        object obj = value.vmethod_4(null);
                        if (obj == null)
                        {
                            Type type = fieldInfo.DeclaringType;
                            if (type.IsByRef)
                            {
                                type = type.GetElementType();
                            }
                            if (!type.IsValueType)
                            {
                                throw new NullReferenceException();
                            }
                            obj = Activator.CreateInstance(type);
                            if (value is Class26)
                            {
                                ((Class25)value).XdGiHrMhoi(Class19.smethod_1(type, obj));
                            }
                        }
                        fieldInfo.SetValue(obj, value3);
                        break;
                    }
                    case (Enum3)171:
                    {
                        Class19 class4 = this.class33_0.method_4();
                        if (Class17.smethod_1(this.class33_0.method_4()).vmethod_81(class4))
                        {
                            this.int_0 = (int)this.object_0 - 1;
                        }
                        break;
                    }
                    case (Enum3)172:
                    {
                        Class20 @class = Class17.smethod_1(this.class33_0.method_4());
                        if (@class != null)
                        {
                            this.class33_0.method_2(@class.vmethod_31());
                            break;
                        }
                        throw new Exception1();
                    }
                    case (Enum3)173:
                        this.class33_0.method_2(new Class24((double)this.object_0));
                        break;
                    case (Enum3)174:
                    {
                        Class20 @class = Class17.smethod_1(this.class33_0.method_4());
                        Class20 class2 = Class17.smethod_1(this.class33_0.method_4());
                        if (@class != null && class2 != null)
                        {
                            this.class33_0.method_2(@class.vmethod_69(class2));
                            break;
                        }
                        throw new Exception1();
                    }
                    case (Enum3)175:
                    {
                        Class20 @class = Class17.smethod_1(this.class33_0.method_4());
                        if (@class == null)
                        {
                            throw new Exception1();
                        }
                        this.class33_0.method_2(@class.vmethod_32());
                        break;
                    }
                }
            }

            private Class19 method_8(Class19 class19_3, Enum1 enum1_0, bool bool_4 = false)
            {
                if (!bool_4 && class19_3.vmethod_0())
                {
                    class19_3 = class19_3.vmethod_8();
                }
                if (class19_3.method_1())
                {
                    return ((Class21)class19_3).vmethod_13(enum1_0);
                }
                if (class19_3.method_3())
                {
                    return ((Class22)class19_3).vmethod_13(enum1_0);
                }
                if (class19_3.method_4())
                {
                    return ((Class24)class19_3).vmethod_13(enum1_0);
                }
                if (class19_3.method_2())
                {
                    return ((Class23)class19_3).vmethod_13(enum1_0);
                }
                return class19_3;
            }

            private Class19 method_9(int int_3)
            {
                return this.class19_1[int_3];
            }

            private void method_10(int int_3)
            {
                this.method_11(int_3, this.class33_0.method_4());
            }

            private static int smethod_0(Type type_0)
            {
                if (Class17.dictionary_0 == null)
                {
                    Class17.dictionary_0 = new Dictionary<Type, int>();
                }
                try
                {
                    int value = 0;
                    if (Class17.dictionary_0.TryGetValue(type_0, out value))
                    {
                        return value;
                    }
                    DynamicMethod dynamicMethod = new DynamicMethod(string.Empty, typeof(int), Type.EmptyTypes, restrictedSkipVisibility: true);
                    ILGenerator iLGenerator = dynamicMethod.GetILGenerator();
                    iLGenerator.Emit(OpCodes.Sizeof, type_0);
                    iLGenerator.Emit(OpCodes.Ret);
                    value = (int)dynamicMethod.Invoke(null, null);
                    Class17.dictionary_0[type_0] = value;
                    return value;
                }
                catch
                {
                    return 0;
                }
            }

            private void method_11(int int_3, Class19 class19_3)
            {
                this.class19_1[int_3] = this.method_8(class19_3, this.class14_0.list_1[int_3].enum1_0, this.class14_0.list_1[int_3].bool_0);
            }

            private static Class20 smethod_1(Class19 class19_3)
            {
                Class20 @class = class19_3 as Class20;
                if (@class == null && class19_3.vmethod_0())
                {
                    @class = class19_3.vmethod_8() as Class20;
                }
                return @class;
            }

            private void method_12(bool bool_4)
            {
                int metadataToken = (int)this.object_0;
                MethodBase methodBase = typeof(Class8).Module.ResolveMethod(metadataToken);
                MethodInfo methodInfo = methodBase as MethodInfo;
                ParameterInfo[] parameters = methodBase.GetParameters();
                object[] array = new object[parameters.Length];
                Class19[] array2 = new Class19[parameters.Length];
                List<Class15> list = null;
                Class16 @class = null;
                int num = default(int);
                do
                {
                    Class19 class2 = this.class33_0.method_4();
                    Type type = parameters[parameters.Length - 1 - num].ParameterType;
                    object obj = null;
                    bool flag = false;
                    if (type.IsByRef && class2 is Class28 class3)
                    {
                        if (list == null)
                        {
                            list = new List<Class15>();
                        }
                        list.Add(new Class15(class3.fieldInfo_0, num));
                        obj = class3.object_0;
                        if (obj is Class19)
                        {
                            class2 = obj as Class19;
                        }
                        else
                        {
                            flag = true;
                        }
                    }
                    if (!flag)
                    {
                        if (class2 != null)
                        {
                            obj = class2.vmethod_4(type);
                        }
                        if (obj == null)
                        {
                            if (type.IsByRef)
                            {
                                type = type.GetElementType();
                            }
                            if (type.IsValueType)
                            {
                                obj = Activator.CreateInstance(type);
                                if (class2 is Class26)
                                {
                                    ((Class25)class2).XdGiHrMhoi(Class19.smethod_1(type, obj));
                                }
                            }
                        }
                    }
                    array2[array.Length - 1 - num] = class2;
                    array[array.Length - 1 - num] = obj;
                    num++;
                }
                while (num < parameters.Length);
                Delegate10 @delegate = null;
                if (list != null)
                {
                    @class = new Class16(methodBase, list);
                    @delegate = Class17.smethod_3(methodBase, bool_4, @class);
                }
                else if (methodInfo != null && methodInfo.ReturnType.IsByRef)
                {
                    @delegate = Class17.smethod_2(methodBase, bool_4);
                }
                object obj2 = null;
                Class19 class4 = null;
                if (!methodBase.IsStatic)
                {
                    class4 = this.class33_0.method_4();
                    if (class4 != null)
                    {
                        obj2 = class4.vmethod_4(methodBase.DeclaringType);
                    }
                    if (obj2 == null)
                    {
                        Type type2 = methodBase.DeclaringType;
                        if (type2.IsByRef)
                        {
                            type2 = type2.GetElementType();
                        }
                        if (!type2.IsValueType)
                        {
                            throw new NullReferenceException();
                        }
                        obj2 = Activator.CreateInstance(type2);
                        if (class4 is Class26)
                        {
                            ((Class25)class4).XdGiHrMhoi(Class19.smethod_1(type2, obj2));
                        }
                    }
                }
                object obj3 = null;
                obj3 = ((@delegate == null) ? methodBase.Invoke(obj2, array) : @delegate(obj2, array));
                int num2 = default(int);
                do
                {
                    if (parameters[num2].ParameterType.IsByRef && (@class == null || !@class.method_1(num2)))
                    {
                        if (array2[num2].method_2())
                        {
                            ((Class23)array2[num2]).method_6(Class19.smethod_1(parameters[num2].ParameterType, array[num2]));
                        }
                        else if (array2[num2] is Class26)
                        {
                            array2[num2].vmethod_10(Class19.smethod_1(parameters[num2].ParameterType.GetElementType(), array[num2]));
                        }
                        else
                        {
                            array2[num2].vmethod_10(Class19.smethod_1(parameters[num2].ParameterType, array[num2]));
                        }
                    }
                    num2++;
                }
                while (num2 < parameters.Length);
                if (methodInfo != null && methodInfo.ReturnType != typeof(void))
                {
                    this.class33_0.method_2(Class19.smethod_1(methodInfo.ReturnType, obj3));
                }
            }

            private static Delegate10 smethod_2(MethodBase methodBase_0, bool bool_4)
            {
                Delegate10 value = null;
                if (bool_4)
                {
                    if (Class17.dictionary_2.TryGetValue(methodBase_0, out value))
                    {
                        return value;
                    }
                }
                else if (Class17.dictionary_3.TryGetValue(methodBase_0, out value))
                {
                    return value;
                }
                MethodInfo methodInfo = methodBase_0 as MethodInfo;
                DynamicMethod dynamicMethod = new DynamicMethod(string.Empty, typeof(object), new Type[2]
                {
                    typeof(object),
                    typeof(object[])
                }, restrictedSkipVisibility: true);
                ILGenerator iLGenerator = dynamicMethod.GetILGenerator();
                ParameterInfo[] parameters = methodBase_0.GetParameters();
                Type[] array = new Type[parameters.Length];
                for (int i = 0; i < array.Length; i++)
                {
                    if (parameters[i].ParameterType.IsByRef)
                    {
                        array[i] = parameters[i].ParameterType.GetElementType();
                    }
                    else
                    {
                        array[i] = parameters[i].ParameterType;
                    }
                }
                int num = array.Length;
                if (methodBase_0.DeclaringType.IsValueType)
                {
                    num++;
                }
                LocalBuilder[] array2 = new LocalBuilder[num];
                for (int j = 0; j < array.Length; j++)
                {
                    array2[j] = iLGenerator.DeclareLocal(array[j]);
                }
                if (methodBase_0.DeclaringType.IsValueType)
                {
                    array2[array2.Length - 1] = iLGenerator.DeclareLocal(methodBase_0.DeclaringType.MakeByRefType());
                }
                int num2 = default(int);
                do
                {
                    iLGenerator.Emit(OpCodes.Ldarg_1);
                    Class17.smethod_5(iLGenerator, num2);
                    iLGenerator.Emit(OpCodes.Ldelem_Ref);
                    if (!array[num2].IsValueType)
                    {
                        if (array[num2] != typeof(object))
                        {
                            iLGenerator.Emit(OpCodes.Castclass, array[num2]);
                        }
                    }
                    else
                    {
                        iLGenerator.Emit(OpCodes.Unbox_Any, array[num2]);
                    }
                    iLGenerator.Emit(OpCodes.Stloc, array2[num2]);
                    num2++;
                }
                while (num2 < array.Length);
                if (!methodBase_0.IsStatic)
                {
                    iLGenerator.Emit(OpCodes.Ldarg_0);
                    if (methodBase_0.DeclaringType.IsValueType)
                    {
                        iLGenerator.Emit(OpCodes.Unbox, methodBase_0.DeclaringType);
                        iLGenerator.Emit(OpCodes.Stloc, array2[array2.Length - 1]);
                        iLGenerator.Emit(OpCodes.Ldloc_S, array2[array2.Length - 1]);
                    }
                    else
                    {
                        iLGenerator.Emit(OpCodes.Castclass, methodBase_0.DeclaringType);
                    }
                }
                for (int k = 0; k < array.Length; k++)
                {
                    if (parameters[k].ParameterType.IsByRef)
                    {
                        iLGenerator.Emit(OpCodes.Ldloca_S, array2[k]);
                    }
                    else
                    {
                        iLGenerator.Emit(OpCodes.Ldloc, array2[k]);
                    }
                }
                if (bool_4)
                {
                    if (methodInfo != null)
                    {
                        iLGenerator.EmitCall(OpCodes.Call, methodInfo, null);
                    }
                    else
                    {
                        iLGenerator.Emit(OpCodes.Call, methodBase_0 as ConstructorInfo);
                    }
                }
                else if (methodInfo != null)
                {
                    iLGenerator.EmitCall(OpCodes.Callvirt, methodInfo, null);
                }
                else
                {
                    iLGenerator.Emit(OpCodes.Callvirt, methodBase_0 as ConstructorInfo);
                }
                if (!(methodInfo == null) && !(methodInfo.ReturnType == typeof(void)))
                {
                    if (methodInfo.ReturnType.IsByRef)
                    {
                        Type elementType = methodInfo.ReturnType.GetElementType();
                        if (elementType.IsValueType)
                        {
                            iLGenerator.Emit(OpCodes.Ldobj, elementType);
                        }
                        else
                        {
                            iLGenerator.Emit(OpCodes.Ldind_Ref, elementType);
                        }
                        if (elementType.IsValueType)
                        {
                            iLGenerator.Emit(OpCodes.Box, elementType);
                        }
                    }
                    else if (methodInfo.ReturnType.IsValueType)
                    {
                        iLGenerator.Emit(OpCodes.Box, methodInfo.ReturnType);
                    }
                }
                else
                {
                    iLGenerator.Emit(OpCodes.Ldnull);
                }
                int num3 = default(int);
                do
                {
                    if (parameters[num3].ParameterType.IsByRef)
                    {
                        iLGenerator.Emit(OpCodes.Ldarg_1);
                        Class17.smethod_5(iLGenerator, num3);
                        iLGenerator.Emit(OpCodes.Ldloc, array2[num3]);
                        if (array2[num3].LocalType.IsValueType)
                        {
                            iLGenerator.Emit(OpCodes.Box, array2[num3].LocalType);
                        }
                        iLGenerator.Emit(OpCodes.Stelem_Ref);
                    }
                    num3++;
                }
                while (num3 < array.Length);
                iLGenerator.Emit(OpCodes.Ret);
                Delegate10 @delegate = (Delegate10)dynamicMethod.CreateDelegate(typeof(Delegate10));
                if (bool_4)
                {
                    Class17.dictionary_2.Add(methodBase_0, @delegate);
                }
                else
                {
                    Class17.dictionary_3.Add(methodBase_0, @delegate);
                }
                return @delegate;
            }

            private static Delegate10 smethod_3(MethodBase methodBase_0, bool bool_4, Class16 class16_0)
            {
                Delegate10 value = null;
                if (bool_4)
                {
                    if (Class17.dictionary_4.TryGetValue(class16_0, out value))
                    {
                        return value;
                    }
                }
                else if (Class17.dictionary_5.TryGetValue(class16_0, out value))
                {
                    return value;
                }
                MethodInfo methodInfo = methodBase_0 as MethodInfo;
                DynamicMethod dynamicMethod = new DynamicMethod(string.Empty, typeof(object), new Type[2]
                {
                    typeof(object),
                    typeof(object[])
                }, typeof(Class8), skipVisibility: true);
                ILGenerator iLGenerator = dynamicMethod.GetILGenerator();
                ParameterInfo[] parameters = methodBase_0.GetParameters();
                Type[] array = new Type[parameters.Length];
                for (int i = 0; i < array.Length; i++)
                {
                    if (parameters[i].ParameterType.IsByRef)
                    {
                        array[i] = parameters[i].ParameterType.GetElementType();
                    }
                    else
                    {
                        array[i] = parameters[i].ParameterType;
                    }
                }
                int num = array.Length;
                if (methodBase_0.DeclaringType.IsValueType)
                {
                    num++;
                }
                LocalBuilder[] array2 = new LocalBuilder[num];
                for (int j = 0; j < array.Length; j++)
                {
                    if (class16_0.method_1(j))
                    {
                        array2[j] = iLGenerator.DeclareLocal(typeof(object));
                    }
                    else
                    {
                        array2[j] = iLGenerator.DeclareLocal(array[j]);
                    }
                }
                if (methodBase_0.DeclaringType.IsValueType)
                {
                    array2[array2.Length - 1] = iLGenerator.DeclareLocal(methodBase_0.DeclaringType.MakeByRefType());
                }
                int num2 = default(int);
                do
                {
                    iLGenerator.Emit(OpCodes.Ldarg_1);
                    Class17.smethod_5(iLGenerator, num2);
                    iLGenerator.Emit(OpCodes.Ldelem_Ref);
                    if (!class16_0.method_1(num2))
                    {
                        if (array[num2].IsValueType)
                        {
                            iLGenerator.Emit(OpCodes.Unbox_Any, array[num2]);
                        }
                        else if (array[num2] != typeof(object))
                        {
                            iLGenerator.Emit(OpCodes.Castclass, array[num2]);
                        }
                    }
                    iLGenerator.Emit(OpCodes.Stloc, array2[num2]);
                    num2++;
                }
                while (num2 < array.Length);
                if (!methodBase_0.IsStatic)
                {
                    iLGenerator.Emit(OpCodes.Ldarg_0);
                    if (methodBase_0.DeclaringType.IsValueType)
                    {
                        iLGenerator.Emit(OpCodes.Unbox, methodBase_0.DeclaringType);
                        iLGenerator.Emit(OpCodes.Stloc, array2[array2.Length - 1]);
                        iLGenerator.Emit(OpCodes.Ldloc_S, array2[array2.Length - 1]);
                    }
                    else
                    {
                        iLGenerator.Emit(OpCodes.Castclass, methodBase_0.DeclaringType);
                    }
                }
                int num3 = default(int);
                do
                {
                    if (class16_0.method_1(num3))
                    {
                        Class15 @class = class16_0.method_0(num3);
                        if (@class.fieldInfo_0.IsStatic)
                        {
                            iLGenerator.Emit(OpCodes.Ldsflda, @class.fieldInfo_0);
                        }
                        else if (@class.fieldInfo_0.DeclaringType.IsValueType)
                        {
                            iLGenerator.Emit(OpCodes.Ldloc, array2[num3]);
                            iLGenerator.Emit(OpCodes.Unbox, @class.fieldInfo_0.DeclaringType);
                            iLGenerator.Emit(OpCodes.Ldflda, @class.fieldInfo_0);
                        }
                        else
                        {
                            iLGenerator.Emit(OpCodes.Ldloc, array2[num3]);
                            iLGenerator.Emit(OpCodes.Castclass, @class.fieldInfo_0.DeclaringType);
                            iLGenerator.Emit(OpCodes.Ldflda, @class.fieldInfo_0);
                        }
                    }
                    else if (parameters[num3].ParameterType.IsByRef)
                    {
                        iLGenerator.Emit(OpCodes.Ldloca_S, array2[num3]);
                    }
                    else
                    {
                        iLGenerator.Emit(OpCodes.Ldloc, array2[num3]);
                    }
                    num3++;
                }
                while (num3 < array.Length);
                if (bool_4)
                {
                    if (methodInfo != null)
                    {
                        iLGenerator.EmitCall(OpCodes.Call, methodInfo, null);
                    }
                    else
                    {
                        iLGenerator.Emit(OpCodes.Call, methodBase_0 as ConstructorInfo);
                    }
                }
                else if (methodInfo != null)
                {
                    iLGenerator.EmitCall(OpCodes.Callvirt, methodInfo, null);
                }
                else
                {
                    iLGenerator.Emit(OpCodes.Callvirt, methodBase_0 as ConstructorInfo);
                }
                if (!(methodInfo == null) && !(methodInfo.ReturnType == typeof(void)))
                {
                    if (methodInfo.ReturnType.IsByRef)
                    {
                        Type elementType = methodInfo.ReturnType.GetElementType();
                        if (elementType.IsValueType)
                        {
                            iLGenerator.Emit(OpCodes.Ldobj, elementType);
                        }
                        else
                        {
                            iLGenerator.Emit(OpCodes.Ldind_Ref, elementType);
                        }
                        if (elementType.IsValueType)
                        {
                            iLGenerator.Emit(OpCodes.Box, elementType);
                        }
                    }
                    else if (methodInfo.ReturnType.IsValueType)
                    {
                        iLGenerator.Emit(OpCodes.Box, methodInfo.ReturnType);
                    }
                }
                else
                {
                    iLGenerator.Emit(OpCodes.Ldnull);
                }
                int num4 = default(int);
                do
                {
                    if (parameters[num4].ParameterType.IsByRef)
                    {
                        if (!class16_0.method_1(num4))
                        {
                            iLGenerator.Emit(OpCodes.Ldarg_1);
                            Class17.smethod_5(iLGenerator, num4);
                            iLGenerator.Emit(OpCodes.Ldloc, array2[num4]);
                            if (array2[num4].LocalType.IsValueType)
                            {
                                iLGenerator.Emit(OpCodes.Box, array2[num4].LocalType);
                            }
                            iLGenerator.Emit(OpCodes.Stelem_Ref);
                        }
                        else
                        {
                            Class15 class2 = class16_0.method_0(num4);
                            if (class2.fieldInfo_0.IsStatic)
                            {
                                iLGenerator.Emit(OpCodes.Ldarg_1);
                                Class17.smethod_5(iLGenerator, num4);
                                iLGenerator.Emit(OpCodes.Ldsfld, class2.fieldInfo_0);
                                if (class2.fieldInfo_0.FieldType.IsValueType)
                                {
                                    iLGenerator.Emit(OpCodes.Box, array2[num4].LocalType);
                                }
                                iLGenerator.Emit(OpCodes.Stelem_Ref);
                            }
                            else
                            {
                                iLGenerator.Emit(OpCodes.Ldarg_1);
                                Class17.smethod_5(iLGenerator, num4);
                                iLGenerator.Emit(OpCodes.Ldloc, array2[num4]);
                                if (array2[num4].LocalType.IsValueType)
                                {
                                    iLGenerator.Emit(OpCodes.Box, array2[num4].LocalType);
                                }
                                iLGenerator.Emit(OpCodes.Stelem_Ref);
                            }
                        }
                    }
                    num4++;
                }
                while (num4 < array.Length);
                iLGenerator.Emit(OpCodes.Ret);
                Delegate10 @delegate = (Delegate10)dynamicMethod.CreateDelegate(typeof(Delegate10));
                if (bool_4)
                {
                    Class17.dictionary_4.Add(class16_0, @delegate);
                }
                else
                {
                    Class17.dictionary_5.Add(class16_0, @delegate);
                }
                return @delegate;
            }

            private static Delegate10 smethod_4(MethodBase methodBase_0, bool bool_4, Class16 class16_0)
            {
                Delegate10 value = null;
                if (Class17.dictionary_6.TryGetValue(class16_0, out value))
                {
                    return value;
                }
                ConstructorInfo constructorInfo = methodBase_0 as ConstructorInfo;
                DynamicMethod dynamicMethod = new DynamicMethod(string.Empty, typeof(object), new Type[2]
                {
                    typeof(object),
                    typeof(object[])
                }, typeof(Class8), skipVisibility: true);
                ILGenerator iLGenerator = dynamicMethod.GetILGenerator();
                ParameterInfo[] parameters = methodBase_0.GetParameters();
                Type[] array = new Type[parameters.Length];
                for (int i = 0; i < array.Length; i++)
                {
                    if (parameters[i].ParameterType.IsByRef)
                    {
                        array[i] = parameters[i].ParameterType.GetElementType();
                    }
                    else
                    {
                        array[i] = parameters[i].ParameterType;
                    }
                }
                int num = array.Length;
                if (methodBase_0.DeclaringType.IsValueType)
                {
                    num++;
                }
                LocalBuilder[] array2 = new LocalBuilder[num];
                for (int j = 0; j < array.Length; j++)
                {
                    if (class16_0.method_1(j))
                    {
                        array2[j] = iLGenerator.DeclareLocal(typeof(object));
                    }
                    else
                    {
                        array2[j] = iLGenerator.DeclareLocal(array[j]);
                    }
                }
                if (methodBase_0.DeclaringType.IsValueType)
                {
                    array2[array2.Length - 1] = iLGenerator.DeclareLocal(methodBase_0.DeclaringType.MakeByRefType());
                }
                int num2 = default(int);
                do
                {
                    iLGenerator.Emit(OpCodes.Ldarg_1);
                    Class17.smethod_5(iLGenerator, num2);
                    iLGenerator.Emit(OpCodes.Ldelem_Ref);
                    if (!class16_0.method_1(num2))
                    {
                        if (array[num2].IsValueType)
                        {
                            iLGenerator.Emit(OpCodes.Unbox_Any, array[num2]);
                        }
                        else if (array[num2] != typeof(object))
                        {
                            iLGenerator.Emit(OpCodes.Castclass, array[num2]);
                        }
                    }
                    iLGenerator.Emit(OpCodes.Stloc, array2[num2]);
                    num2++;
                }
                while (num2 < array.Length);
                int num3 = default(int);
                do
                {
                    if (class16_0.method_1(num3))
                    {
                        Class15 @class = class16_0.method_0(num3);
                        if (@class.fieldInfo_0.IsStatic)
                        {
                            iLGenerator.Emit(OpCodes.Ldsflda, @class.fieldInfo_0);
                        }
                        else if (@class.fieldInfo_0.DeclaringType.IsValueType)
                        {
                            iLGenerator.Emit(OpCodes.Ldloc, array2[num3]);
                            iLGenerator.Emit(OpCodes.Unbox, @class.fieldInfo_0.DeclaringType);
                            iLGenerator.Emit(OpCodes.Ldflda, @class.fieldInfo_0);
                        }
                        else
                        {
                            iLGenerator.Emit(OpCodes.Ldloc, array2[num3]);
                            iLGenerator.Emit(OpCodes.Castclass, @class.fieldInfo_0.DeclaringType);
                            iLGenerator.Emit(OpCodes.Ldflda, @class.fieldInfo_0);
                        }
                    }
                    else if (parameters[num3].ParameterType.IsByRef)
                    {
                        iLGenerator.Emit(OpCodes.Ldloca_S, array2[num3]);
                    }
                    else
                    {
                        iLGenerator.Emit(OpCodes.Ldloc, array2[num3]);
                    }
                    num3++;
                }
                while (num3 < array.Length);
                iLGenerator.Emit(OpCodes.Newobj, methodBase_0 as ConstructorInfo);
                if (constructorInfo.DeclaringType.IsValueType)
                {
                    iLGenerator.Emit(OpCodes.Box, constructorInfo.DeclaringType);
                }
                int num4 = default(int);
                do
                {
                    if (parameters[num4].ParameterType.IsByRef)
                    {
                        if (!class16_0.method_1(num4))
                        {
                            iLGenerator.Emit(OpCodes.Ldarg_1);
                            Class17.smethod_5(iLGenerator, num4);
                            iLGenerator.Emit(OpCodes.Ldloc, array2[num4]);
                            if (array2[num4].LocalType.IsValueType)
                            {
                                iLGenerator.Emit(OpCodes.Box, array2[num4].LocalType);
                            }
                            iLGenerator.Emit(OpCodes.Stelem_Ref);
                        }
                        else
                        {
                            Class15 class2 = class16_0.method_0(num4);
                            if (class2.fieldInfo_0.IsStatic)
                            {
                                iLGenerator.Emit(OpCodes.Ldarg_1);
                                Class17.smethod_5(iLGenerator, num4);
                                iLGenerator.Emit(OpCodes.Ldsfld, class2.fieldInfo_0);
                                if (class2.fieldInfo_0.FieldType.IsValueType)
                                {
                                    iLGenerator.Emit(OpCodes.Box, array2[num4].LocalType);
                                }
                                iLGenerator.Emit(OpCodes.Stelem_Ref);
                            }
                            else
                            {
                                iLGenerator.Emit(OpCodes.Ldarg_1);
                                Class17.smethod_5(iLGenerator, num4);
                                iLGenerator.Emit(OpCodes.Ldloc, array2[num4]);
                                if (array2[num4].LocalType.IsValueType)
                                {
                                    iLGenerator.Emit(OpCodes.Box, array2[num4].LocalType);
                                }
                                iLGenerator.Emit(OpCodes.Stelem_Ref);
                            }
                        }
                    }
                    num4++;
                }
                while (num4 < array.Length);
                iLGenerator.Emit(OpCodes.Ret);
                Delegate10 @delegate = (Delegate10)dynamicMethod.CreateDelegate(typeof(Delegate10));
                Class17.dictionary_6.Add(class16_0, @delegate);
                return @delegate;
            }

            private static void smethod_5(ILGenerator ilgenerator_0, int int_3)
            {
                switch (int_3)
                {
                    case -1:
                        ilgenerator_0.Emit(OpCodes.Ldc_I4_M1);
                        return;
                    case 0:
                        ilgenerator_0.Emit(OpCodes.Ldc_I4_0);
                        return;
                    case 1:
                        ilgenerator_0.Emit(OpCodes.Ldc_I4_1);
                        return;
                    case 2:
                        ilgenerator_0.Emit(OpCodes.Ldc_I4_2);
                        return;
                    case 3:
                        ilgenerator_0.Emit(OpCodes.Ldc_I4_3);
                        return;
                    case 4:
                        ilgenerator_0.Emit(OpCodes.Ldc_I4_4);
                        return;
                    case 5:
                        ilgenerator_0.Emit(OpCodes.Ldc_I4_5);
                        return;
                    case 6:
                        ilgenerator_0.Emit(OpCodes.Ldc_I4_6);
                        return;
                    case 7:
                        ilgenerator_0.Emit(OpCodes.Ldc_I4_7);
                        return;
                    case 8:
                        ilgenerator_0.Emit(OpCodes.Ldc_I4_8);
                        return;
                }
                if (int_3 > -129 && int_3 < 128)
                {
                    ilgenerator_0.Emit(OpCodes.Ldc_I4_S, (sbyte)int_3);
                }
                else
                {
                    ilgenerator_0.Emit(OpCodes.Ldc_I4, int_3);
                }
            }

            private static Class19 smethod_6(Class19 class19_3)
            {
                if (class19_3.vmethod_8().method_0())
                {
                    object obj = class19_3.vmethod_4(null);
                    if (obj != null && obj.GetType().IsEnum)
                    {
                        Type underlyingType = Enum.GetUnderlyingType(obj.GetType());
                        Class19 @class = Class17.smethod_7(Class19.smethod_1(underlyingType, Convert.ChangeType(obj, underlyingType)));
                        if (@class != null)
                        {
                            return @class as Class20;
                        }
                    }
                }
                return class19_3;
            }

            private static Class20 smethod_7(Class19 class19_3)
            {
                Class20 @class = class19_3 as Class20;
                if (@class == null && class19_3.vmethod_0())
                {
                    @class = class19_3.vmethod_8() as Class20;
                }
                return @class;
            }

            private static IntPtr smethod_8(Class19 class19_3)
            {
                if (class19_3 == null)
                {
                    return IntPtr.Zero;
                }
                if (class19_3.method_2())
                {
                    return ((Class23)class19_3).method_7();
                }
                if (class19_3.vmethod_0())
                {
                    Class25 @class = (Class25)class19_3;
                    try
                    {
                        return @class.vmethod_11();
                    }
                    catch
                    {
                    }
                }
                object obj2 = class19_3.vmethod_4(typeof(IntPtr));
                if (obj2 == null || !(obj2.GetType() == typeof(IntPtr)))
                {
                    throw new Exception1();
                }
                return (IntPtr)obj2;
            }

            private static object smethod_9(object object_1)
            {
                if (Class17.dictionary_7 == null)
                {
                    Class17.dictionary_7 = new Dictionary<Type, Delegate11>();
                }
                if (object_1 == null)
                {
                    return null;
                }
                try
                {
                    Type type = object_1.GetType();
                    if (Class17.dictionary_7.TryGetValue(type, out var value))
                    {
                        return value(object_1);
                    }
                    DynamicMethod dynamicMethod = new DynamicMethod(string.Empty, typeof(object), new Type[1] { typeof(object) }, restrictedSkipVisibility: true);
                    ILGenerator iLGenerator = dynamicMethod.GetILGenerator();
                    iLGenerator.Emit(OpCodes.Ldarg_0);
                    iLGenerator.Emit(OpCodes.Unbox_Any, type);
                    iLGenerator.Emit(OpCodes.Box, type);
                    iLGenerator.Emit(OpCodes.Ret);
                    Delegate11 @delegate = (Delegate11)dynamicMethod.CreateDelegate(typeof(Delegate11));
                    Class17.dictionary_7.Add(type, @delegate);
                    return @delegate(object_1);
                }
                catch
                {
                    return null;
                }
            }

            private static void smethod_10(IntPtr intptr_0, byte byte_0, int int_3)
            {
                if (Class17.delegate12_0 == null)
                {
                    DynamicMethod dynamicMethod = new DynamicMethod(string.Empty, typeof(void), new Type[3]
                    {
                        typeof(IntPtr),
                        typeof(byte),
                        typeof(int)
                    }, typeof(Class8), skipVisibility: true);
                    ILGenerator iLGenerator = dynamicMethod.GetILGenerator();
                    iLGenerator.Emit(OpCodes.Ldarg_0);
                    iLGenerator.Emit(OpCodes.Ldarg_1);
                    iLGenerator.Emit(OpCodes.Ldarg_2);
                    iLGenerator.Emit(OpCodes.Initblk);
                    iLGenerator.Emit(OpCodes.Ret);
                    Class17.delegate12_0 = (Delegate12)dynamicMethod.CreateDelegate(typeof(Delegate12));
                }
                Class17.delegate12_0(intptr_0, byte_0, int_3);
            }

            private static void smethod_11(IntPtr intptr_0, IntPtr intptr_1, uint uint_0)
            {
                if (Class17.delegate13_0 == null)
                {
                    DynamicMethod dynamicMethod = new DynamicMethod(string.Empty, typeof(void), new Type[3]
                    {
                        typeof(IntPtr),
                        typeof(IntPtr),
                        typeof(uint)
                    }, typeof(Class8), skipVisibility: true);
                    ILGenerator iLGenerator = dynamicMethod.GetILGenerator();
                    iLGenerator.Emit(OpCodes.Ldarg_0);
                    iLGenerator.Emit(OpCodes.Ldarg_1);
                    iLGenerator.Emit(OpCodes.Ldarg_2);
                    iLGenerator.Emit(OpCodes.Cpblk);
                    iLGenerator.Emit(OpCodes.Ret);
                    Class17.delegate13_0 = (Delegate13)dynamicMethod.CreateDelegate(typeof(Delegate13));
                }
                Class17.delegate13_0(intptr_0, intptr_1, uint_0);
            }

            static Class17()
            {
                Class17.dictionary_1 = new Dictionary<object, Class19>();
                Class17.dictionary_2 = new Dictionary<MethodBase, Delegate10>();
                Class17.dictionary_3 = new Dictionary<MethodBase, Delegate10>();
                Class17.dictionary_4 = new Dictionary<Class16, Delegate10>();
                Class17.dictionary_5 = new Dictionary<Class16, Delegate10>();
                Class17.dictionary_6 = new Dictionary<Class16, Delegate10>();
            }
        }

        internal enum Enum3 : byte
        {

        }

        internal enum Enum4 : byte
        {

        }

        internal abstract class Class19
        {
            internal Enum4 enum4_0;

            public Class19()
            {
                throw /*Error near IL_0001: Stack underflow*/;
            }

            internal bool method_0()
            {
                return this.enum4_0 == (Enum4)0;
            }

            internal bool method_1()
            {
                return this.enum4_0 == (Enum4)1;
            }

            internal bool method_2()
            {
                if (this.enum4_0 != (Enum4)3)
                {
                    return this.enum4_0 == (Enum4)4;
                }
                return true;
            }

            internal bool method_3()
            {
                return this.enum4_0 == (Enum4)2;
            }

            internal bool method_4()
            {
                return this.enum4_0 == (Enum4)5;
            }

            internal bool method_5()
            {
                return this.enum4_0 == (Enum4)6;
            }

            internal virtual bool vmethod_0()
            {
                return false;
            }

            internal virtual bool vmethod_1()
            {
                return false;
            }

            internal abstract void vmethod_2(Class19 class19_0);

            internal virtual bool vmethod_3()
            {
                return false;
            }

            internal Class19(Enum4 enum4_1)
            {
                this.enum4_0 = enum4_1;
            }

            internal abstract object vmethod_4(Type type_0);

            internal abstract bool vmethod_5(Class19 class19_0);

            internal abstract bool vmethod_6(Class19 class19_0);

            internal abstract bool vmethod_7();

            internal abstract Class19 vmethod_8();

            internal virtual bool vmethod_9()
            {
                return false;
            }

            internal abstract void vmethod_10(Class19 class19_0);

            internal static Enum2 smethod_0(Type type_0)
            {
                Type type = type_0;
                if (type != null)
                {
                    if (type.IsByRef)
                    {
                        type = type.GetElementType();
                    }
                    if (type == typeof(string))
                    {
                        return (Enum2)14;
                    }
                    if (type == typeof(byte))
                    {
                        return (Enum2)2;
                    }
                    if (type == typeof(sbyte))
                    {
                        return (Enum2)1;
                    }
                    if (type == typeof(short))
                    {
                        return (Enum2)3;
                    }
                    if (type == typeof(ushort))
                    {
                        return (Enum2)4;
                    }
                    if (type == typeof(int))
                    {
                        return (Enum2)5;
                    }
                    if (type == typeof(uint))
                    {
                        return (Enum2)6;
                    }
                    if (type == typeof(long))
                    {
                        return (Enum2)7;
                    }
                    if (type == typeof(ulong))
                    {
                        return (Enum2)8;
                    }
                    if (type == typeof(float))
                    {
                        return (Enum2)9;
                    }
                    if (type == typeof(double))
                    {
                        return (Enum2)10;
                    }
                    if (type == typeof(bool))
                    {
                        return (Enum2)11;
                    }
                    if (type == typeof(IntPtr))
                    {
                        return (Enum2)12;
                    }
                    if (type == typeof(UIntPtr))
                    {
                        return (Enum2)13;
                    }
                    if (type == typeof(char))
                    {
                        return (Enum2)15;
                    }
                    if (type == typeof(object))
                    {
                        return (Enum2)0;
                    }
                    if (type.IsEnum)
                    {
                        return (Enum2)16;
                    }
                    return (Enum2)17;
                }
                return (Enum2)18;
            }

            internal static Class19 smethod_1(Type type_0, object object_0)
            {
                Enum2 @enum = Class19.smethod_0(type_0);
                Enum2 enum2 = (Enum2)18;
                if (object_0 != null)
                {
                    enum2 = Class19.smethod_0(object_0.GetType());
                }
                Class19 @class = null;
                switch (@enum)
                {
                    case (Enum2)0:
                        @class = ((enum2 != (Enum2)15) ? Class19.smethod_2(object_0) : new Class31(object_0));
                        goto default;
                    case (Enum2)1:
                        @class = enum2 switch
                        {
                            (Enum2)2 => new Class21((sbyte)(byte)object_0, (Enum1)1), 
                            (Enum2)1 => new Class21((sbyte)object_0, (Enum1)1), 
                            (Enum2)15 => new Class21((sbyte)(char)object_0, (Enum1)1), 
                            (Enum2)11 => (!(bool)object_0) ? new Class21(0, (Enum1)1) : new Class21(1, (Enum1)1), 
                            _ => throw new InvalidCastException(), 
                        };
                        goto default;
                    case (Enum2)2:
                        @class = enum2 switch
                        {
                            (Enum2)2 => new Class21((byte)object_0, (Enum1)2), 
                            (Enum2)1 => new Class21((byte)(sbyte)object_0, (Enum1)2), 
                            (Enum2)15 => new Class21((byte)(char)object_0, (Enum1)2), 
                            (Enum2)11 => (!(bool)object_0) ? new Class21(0, (Enum1)2) : new Class21(1, (Enum1)2), 
                            _ => throw new InvalidCastException(), 
                        };
                        goto default;
                    case (Enum2)3:
                        @class = enum2 switch
                        {
                            (Enum2)15 => new Class21((short)(char)object_0, (Enum1)3), 
                            (Enum2)11 => (!(bool)object_0) ? new Class21(0, (Enum1)3) : new Class21(1, (Enum1)3), 
                            (Enum2)3 => new Class21((short)object_0, (Enum1)3), 
                            _ => throw new InvalidCastException(), 
                        };
                        goto default;
                    case (Enum2)4:
                        @class = enum2 switch
                        {
                            (Enum2)15 => new Class21((char)object_0, (Enum1)4), 
                            (Enum2)11 => (!(bool)object_0) ? new Class21(0, (Enum1)4) : new Class21(1, (Enum1)4), 
                            (Enum2)4 => new Class21((ushort)object_0, (Enum1)4), 
                            _ => throw new InvalidCastException(), 
                        };
                        goto default;
                    case (Enum2)5:
                        @class = enum2 switch
                        {
                            (Enum2)15 => new Class21((char)object_0, (Enum1)5), 
                            (Enum2)11 => (!(bool)object_0) ? new Class21(0, (Enum1)5) : new Class21(1, (Enum1)5), 
                            (Enum2)5 => new Class21((int)object_0, (Enum1)5), 
                            _ => throw new InvalidCastException(), 
                        };
                        goto default;
                    case (Enum2)6:
                        @class = enum2 switch
                        {
                            (Enum2)15 => new Class21((uint)(char)object_0, (Enum1)6), 
                            (Enum2)11 => (!(bool)object_0) ? new Class21(0u, (Enum1)6) : new Class21(1u, (Enum1)6), 
                            (Enum2)6 => new Class21((uint)object_0, (Enum1)6), 
                            _ => throw new InvalidCastException(), 
                        };
                        goto default;
                    case (Enum2)7:
                        @class = enum2 switch
                        {
                            (Enum2)15 => new Class22((char)object_0, (Enum1)7), 
                            (Enum2)11 => (!(bool)object_0) ? new Class22(0L, (Enum1)7) : new Class22(1L, (Enum1)7), 
                            (Enum2)7 => new Class22((long)object_0, (Enum1)7), 
                            _ => throw new InvalidCastException(), 
                        };
                        goto default;
                    case (Enum2)8:
                        @class = enum2 switch
                        {
                            (Enum2)15 => new Class22((ulong)(char)object_0, (Enum1)8), 
                            (Enum2)11 => (!(bool)object_0) ? new Class22(0uL, (Enum1)8) : new Class22(1uL, (Enum1)8), 
                            (Enum2)8 => new Class22((ulong)object_0, (Enum1)8), 
                            _ => throw new InvalidCastException(), 
                        };
                        goto default;
                    case (Enum2)9:
                        if (enum2 == (Enum2)9)
                        {
                            @class = new Class24((float)object_0);
                            goto default;
                        }
                        throw new InvalidCastException();
                    case (Enum2)10:
                        if (enum2 == (Enum2)10)
                        {
                            @class = new Class24((double)object_0);
                            goto default;
                        }
                        throw new InvalidCastException();
                    case (Enum2)11:
                        switch (enum2)
                        {
                            case (Enum2)1:
                                @class = new Class21((sbyte)object_0 != 0);
                                break;
                            case (Enum2)2:
                                @class = new Class21((byte)object_0 != 0);
                                break;
                            case (Enum2)3:
                                @class = new Class21((short)object_0 != 0);
                                break;
                            case (Enum2)4:
                                @class = new Class21((ushort)object_0 != 0);
                                break;
                            case (Enum2)5:
                                @class = new Class21((int)object_0 != 0);
                                break;
                            case (Enum2)6:
                                @class = new Class21((uint)object_0 != 0);
                                break;
                            case (Enum2)7:
                                @class = new Class21((ulong)(long)object_0 > 0uL);
                                break;
                            case (Enum2)8:
                                @class = new Class21((ulong)object_0 > 0L);
                                break;
                            case (Enum2)11:
                                @class = new Class21((bool)object_0);
                                break;
                            case (Enum2)9:
                            case (Enum2)10:
                            case (Enum2)12:
                            case (Enum2)13:
                            case (Enum2)14:
                            case (Enum2)15:
                            case (Enum2)16:
                                throw new InvalidCastException();
                            default:
                                @class = new Class21(object_0 != null);
                                break;
                            case (Enum2)18:
                                @class = new Class21(bool_0: false);
                                break;
                        }
                        goto default;
                    case (Enum2)12:
                        if (enum2 == (Enum2)12)
                        {
                            @class = new Class23((IntPtr)object_0);
                            goto default;
                        }
                        throw new InvalidCastException();
                    case (Enum2)13:
                        if (enum2 == (Enum2)13)
                        {
                            @class = new Class23((UIntPtr)object_0);
                            goto default;
                        }
                        throw new InvalidCastException();
                    case (Enum2)14:
                        @class = new Class32(object_0 as string);
                        goto default;
                    case (Enum2)15:
                        @class = enum2 switch
                        {
                            (Enum2)15 => new Class21((char)object_0, (Enum1)15), 
                            (Enum2)1 => new Class21((sbyte)object_0, (Enum1)15), 
                            (Enum2)2 => new Class21((byte)object_0, (Enum1)15), 
                            (Enum2)3 => new Class21((short)object_0, (Enum1)15), 
                            (Enum2)4 => new Class21((ushort)object_0, (Enum1)15), 
                            (Enum2)5 => new Class21((int)object_0, (Enum1)15), 
                            (Enum2)6 => new Class21((int)(uint)object_0, (Enum1)15), 
                            _ => throw new InvalidCastException(), 
                        };
                        goto default;
                    case (Enum2)16:
                    case (Enum2)17:
                        @class = Class19.smethod_2(object_0);
                        goto default;
                    default:
                        if (type_0.IsByRef)
                        {
                            @class = new Class30(@class, type_0.GetElementType());
                        }
                        return @class;
                    case (Enum2)18:
                        throw new InvalidCastException();
                }
            }

            private static Class19 smethod_2(object object_0)
            {
                if (object_0 != null && object_0.GetType().IsEnum)
                {
                    Type underlyingType = Enum.GetUnderlyingType(object_0.GetType());
                    Class19 @class = Class19.smethod_3(Class19.smethod_1(underlyingType, Convert.ChangeType(object_0, underlyingType)));
                    if (@class != null)
                    {
                        return @class as Class20;
                    }
                }
                return new Class31(object_0);
            }

            private static Class20 smethod_3(Class19 class19_0)
            {
                Class20 @class = class19_0 as Class20;
                if (@class == null && class19_0.vmethod_0())
                {
                    @class = class19_0.vmethod_8() as Class20;
                }
                return @class;
            }
        }

        private class Class31 : Class19
        {
            public Class19 class19_0;

            public Type type_0;

            public Class31()
                : this(null)
            {
            }

            internal override void vmethod_10(Class19 class19_1)
            {
                if (class19_1 is Class31)
                {
                    this.class19_0 = ((Class31)class19_1).class19_0;
                    this.type_0 = ((Class31)class19_1).type_0;
                }
                else
                {
                    this.class19_0 = class19_1.vmethod_8();
                }
            }

            internal override void vmethod_2(Class19 class19_1)
            {
                this.vmethod_10(class19_1);
            }

            public Class31(object object_0)
                : base((Enum4)0)
            {
                this.class19_0 = (Class19)object_0;
                this.type_0 = null;
            }

            public Class31(object object_0, Type type_1)
                : base((Enum4)0)
            {
                this.class19_0 = (Class19)object_0;
                this.type_0 = type_1;
            }

            public override string ToString()
            {
                if (this.class19_0 != null)
                {
                    return this.class19_0.ToString();
                }
                return ((Enum5)5).ToString();
            }

            internal override object vmethod_4(Type type_1)
            {
                if (this.class19_0 == null)
                {
                    return null;
                }
                if (type_1 != null && type_1.IsByRef)
                {
                    type_1 = type_1.GetElementType();
                }
                if (!(this.class19_0 is Class19))
                {
                    object obj = this.class19_0;
                    if (obj != null && type_1 != null && obj.GetType() != type_1)
                    {
                        if (type_1 == typeof(RuntimeFieldHandle) && obj is FieldInfo)
                        {
                            obj = ((FieldInfo)obj).FieldHandle;
                        }
                        else if (type_1 == typeof(RuntimeTypeHandle) && obj is Type)
                        {
                            obj = ((Type)obj).TypeHandle;
                        }
                        else if (type_1 == typeof(RuntimeMethodHandle) && obj is MethodBase)
                        {
                            obj = ((MethodBase)obj).MethodHandle;
                        }
                    }
                    return obj;
                }
                if (this.type_0 != null)
                {
                    return this.class19_0.vmethod_4(this.type_0);
                }
                object obj2 = this.class19_0.vmethod_4(type_1);
                if (obj2 != null && type_1 != null && obj2.GetType() != type_1)
                {
                    if (type_1 == typeof(RuntimeFieldHandle) && obj2 is FieldInfo)
                    {
                        obj2 = ((FieldInfo)obj2).FieldHandle;
                    }
                    else if (type_1 == typeof(RuntimeTypeHandle) && obj2 is Type)
                    {
                        obj2 = ((Type)obj2).TypeHandle;
                    }
                    else if (type_1 == typeof(RuntimeMethodHandle) && obj2 is MethodBase)
                    {
                        obj2 = ((MethodBase)obj2).MethodHandle;
                    }
                }
                return obj2;
            }

            internal override bool vmethod_5(Class19 class19_1)
            {
                if (class19_1.vmethod_0())
                {
                    return ((Class25)class19_1).vmethod_5(this);
                }
                return this.vmethod_4(null) == class19_1.vmethod_4(null);
            }

            internal override bool vmethod_6(Class19 class19_1)
            {
                if (class19_1.vmethod_0())
                {
                    return ((Class25)class19_1).vmethod_6(this);
                }
                return this.vmethod_4(null) != class19_1.vmethod_4(null);
            }

            internal override Class19 vmethod_8()
            {
                if (!(this.class19_0 is Class19 @class))
                {
                    return this;
                }
                return @class.vmethod_8();
            }

            internal override bool vmethod_7()
            {
                if (this.class19_0 == null)
                {
                    return false;
                }
                if (this.class19_0 is Class19 @class)
                {
                    if (@class.vmethod_4(null) != null)
                    {
                        return true;
                    }
                    return false;
                }
                return true;
            }
        }

        private class Class32 : Class19
        {
            public string string_0;

            public Class32(string string_1)
                : base((Enum4)6)
            {
                this.string_0 = string_1;
            }

            internal override void vmethod_10(Class19 class19_0)
            {
                this.string_0 = ((Class32)class19_0).string_0;
            }

            internal override void vmethod_2(Class19 class19_0)
            {
                this.vmethod_10(class19_0);
            }

            public override string ToString()
            {
                if (this.string_0 == null)
                {
                    return ((Enum5)5).ToString();
                }
                return '*' + this.string_0 + '*';
            }

            internal override bool vmethod_7()
            {
                return this.string_0 != null;
            }

            internal override object vmethod_4(Type type_0)
            {
                return this.string_0;
            }

            internal override bool vmethod_5(Class19 class19_0)
            {
                if (class19_0.vmethod_0())
                {
                    return ((Class25)class19_0).vmethod_5(this);
                }
                return this.string_0 == class19_0.vmethod_4(null);
            }

            internal override bool vmethod_6(Class19 class19_0)
            {
                if (class19_0.vmethod_0())
                {
                    return ((Class25)class19_0).vmethod_6(this);
                }
                return this.string_0 != class19_0.vmethod_4(null);
            }

            internal override Class19 vmethod_8()
            {
                return this;
            }
        }

        internal class Class33
        {
            private List<Class19> list_0 = new List<Class19>();

            [SpecialName]
            public int method_0()
            {
                return this.list_0.Count;
            }

            public void method_1()
            {
                this.list_0.Clear();
            }

            public void method_2(Class19 class19_0)
            {
                this.list_0.Add(class19_0);
            }

            public Class19 method_3()
            {
                return this.list_0[this.list_0.Count - 1];
            }

            public Class19 method_4()
            {
                Class19 result = this.method_3();
                if (this.list_0.Count != 0)
                {
                    this.list_0.RemoveAt(this.list_0.Count - 1);
                }
                return result;
            }
        }

        internal enum Enum5
        {

        }

        [Serializable]
        [CompilerGenerated]
        private sealed class Class34<T>
        {
            public static readonly Class34<T> _003C_003E9;

            public static Comparison<Class12> _003C_003E9__45_0;

            static Class34()
            {
                Class34<T>._003C_003E9 = new Class34<T>();
            }

            public Class34()
            {
                throw /*Error near IL_0001: Stack underflow*/;
            }

            internal int method_0(Class12 x, Class12 y)
            {
                return x.class13_0.int_0.CompareTo(y.class13_0.int_0);
            }
        }

        internal static Class14[] class14_0;

        internal static int[] int_0;

        internal static List<string> list_0;

        private static BinaryReader binaryReader_0;

        private static byte[] byte_0;

        private static bool bool_0;

        private static object object_0;

        private static int int_1;

        internal static object[] smethod_0()
        {
            return new object[1];
        }

        internal static object[] smethod_1<T>(int int_2, object[] object_1, object object_2, ref T gparam_0)
        {
            lock (Class8.object_0)
            {
                if (!Class8.bool_0)
                {
                    Class8.bool_0 = true;
                    Class8.smethod_4();
                }
            }
            Class14 @class = null;
            if (Class8.class14_0[int_2] != null)
            {
                @class = Class8.class14_0[int_2];
            }
            else
            {
                Class8.binaryReader_0.BaseStream.Position = Class8.int_0[int_2];
                @class = new Class14();
                Module module = typeof(Class8).Module;
                int metadataToken = Class8.smethod_6(Class8.binaryReader_0);
                int num = Class8.smethod_6(Class8.binaryReader_0);
                int num2 = Class8.smethod_6(Class8.binaryReader_0);
                int num3 = Class8.smethod_6(Class8.binaryReader_0);
                @class.methodBase_0 = module.ResolveMethod(metadataToken);
                ParameterInfo[] parameters = @class.methodBase_0.GetParameters();
                @class.class10_0 = new Class10[parameters.Length];
                int num4 = default(int);
                do
                {
                    Type type = parameters[num4].ParameterType;
                    Class10 class2 = new Class10();
                    class2.bool_0 = type.IsByRef;
                    class2.int_0 = num4;
                    @class.class10_0[num4] = class2;
                    if (type.IsByRef)
                    {
                        type = type.GetElementType();
                    }
                    Enum1 @enum = (Enum1)0;
                    if (!(type == typeof(string)))
                    {
                    }
                    if (!(type == typeof(byte)))
                    {
                    }
                    if (!(type == typeof(sbyte)))
                    {
                    }
                    if (!(type == typeof(short)))
                    {
                    }
                    if (!(type == typeof(ushort)))
                    {
                    }
                    if (!(type == typeof(int)))
                    {
                    }
                    if (!(type == typeof(uint)))
                    {
                    }
                    if (!(type == typeof(long)))
                    {
                    }
                    if (!(type == typeof(ulong)))
                    {
                    }
                    if (!(type == typeof(float)))
                    {
                    }
                    if (!(type == typeof(double)))
                    {
                    }
                    class2.enum1_0 = ((type == typeof(bool)) ? ((Enum1)11) : ((type == typeof(IntPtr)) ? ((Enum1)12) : ((type == typeof(UIntPtr)) ? ((Enum1)13) : ((type == typeof(char)) ? ((Enum1)15) : ((Enum1)0)))));
                    num4++;
                }
                while (num4 < parameters.Length);
                @class.list_1 = new List<Class11>(num);
                int num6 = default(int);
                do
                {
                    int num5 = Class8.smethod_6(Class8.binaryReader_0);
                    Class11 class3 = new Class11();
                    class3.type_0 = null;
                    if (num5 >= 0 && num5 < 50)
                    {
                        class3.enum1_0 = (Enum1)((uint)num5 & 0x1Fu);
                        class3.bool_0 = (num5 & 0x20) > 0;
                    }
                    class3.int_0 = num6;
                    @class.list_1.Add(class3);
                    num6++;
                }
                while (num6 < num);
                @class.list_2 = new List<Class12>(num2);
                int num9 = default(int);
                do
                {
                    int num7 = Class8.smethod_6(Class8.binaryReader_0);
                    int bOdiOkNrnU = Class8.smethod_6(Class8.binaryReader_0);
                    Class12 class4 = new Class12();
                    class4.int_0 = num7;
                    class4.bOdiOkNrnU = bOdiOkNrnU;
                    Class13 class5 = (class4.class13_0 = new Class13());
                    num7 = Class8.smethod_6(Class8.binaryReader_0);
                    bOdiOkNrnU = Class8.smethod_6(Class8.binaryReader_0);
                    int num8 = Class8.smethod_6(Class8.binaryReader_0);
                    class5.int_0 = num7;
                    class5.int_1 = bOdiOkNrnU;
                    class5.int_3 = num8;
                    switch (num8)
                    {
                        case 1:
                            class5.int_2 = Class8.smethod_6(Class8.binaryReader_0);
                            break;
                        default:
                            Class8.smethod_6(Class8.binaryReader_0);
                            break;
                        case 0:
                            class5.type_0 = module.ResolveType(Class8.smethod_6(Class8.binaryReader_0));
                            break;
                    }
                    @class.list_2.Add(class4);
                    num9++;
                }
                while (num9 < num2);
                @class.list_2.Sort((Class12 x, Class12 y) => x.class13_0.int_0.CompareTo(y.class13_0.int_0));
                @class.list_0 = new List<Class9>(num3);
                int num12 = default(int);
                do
                {
                    Class9 class6 = new Class9();
                    byte b = (byte)(class6.enum3_0 = (Enum3)Class8.binaryReader_0.ReadByte());
                    if (b < 176)
                    {
                        int num10 = Class8.byte_0[b];
                        if (num10 == 0)
                        {
                            class6.object_0 = null;
                        }
                        else
                        {
                            object obj = null;
                            switch (num10)
                            {
                                case 1:
                                    obj = Class8.smethod_6(Class8.binaryReader_0);
                                    goto IL_066a;
                                case 2:
                                    obj = Class8.binaryReader_0.ReadInt64();
                                    goto IL_066a;
                                case 3:
                                    obj = Class8.binaryReader_0.ReadSingle();
                                    goto IL_066a;
                                case 4:
                                    obj = Class8.binaryReader_0.ReadDouble();
                                    goto IL_066a;
                                case 5:
                                {
                                    int num11 = Class8.smethod_6(Class8.binaryReader_0);
                                    int[] array = new int[num11];
                                    for (int i = 0; i < num11; i++)
                                    {
                                        array[i] = Class8.smethod_6(Class8.binaryReader_0);
                                    }
                                    obj = array;
                                    goto IL_066a;
                                }
                                default:
                                {
                                    throw new Exception();
                                }
                                    IL_066a:
                                    class6.object_0 = obj;
                                    break;
                            }
                        }
                        @class.list_0.Add(class6);
                        num12++;
                        continue;
                    }
                    throw new Exception();
                }
                while (num12 < num3);
                Class8.class14_0[int_2] = @class;
            }
            Class17 class7 = new Class17();
            class7.class14_0 = @class;
            ParameterInfo[] parameters2 = @class.methodBase_0.GetParameters();
            bool flag = false;
            int num13 = 0;
            if (@class.methodBase_0 is MethodInfo && ((MethodInfo)@class.methodBase_0).ReturnType != typeof(void))
            {
                flag = true;
            }
            if (@class.methodBase_0.IsStatic)
            {
                class7.class19_0 = new Class19[parameters2.Length];
                for (int j = 0; j < parameters2.Length; j++)
                {
                    Type parameterType = parameters2[j].ParameterType;
                    class7.class19_0[j] = Class19.smethod_1(parameterType, object_1[j]);
                    if (parameterType.IsByRef)
                    {
                        num13++;
                    }
                }
            }
            else
            {
                class7.class19_0 = new Class19[parameters2.Length + 1];
                if (@class.methodBase_0.DeclaringType.IsValueType)
                {
                    class7.class19_0[0] = new Class30(new Class31(object_2), @class.methodBase_0.DeclaringType);
                }
                else
                {
                    class7.class19_0[0] = new Class31(object_2);
                }
                int num14 = default(int);
                do
                {
                    Type parameterType2 = parameters2[num14].ParameterType;
                    if (!parameterType2.IsByRef)
                    {
                        class7.class19_0[num14 + 1] = Class19.smethod_1(parameterType2, object_1[num14]);
                    }
                    else
                    {
                        class7.class19_0[num14 + 1] = Class19.smethod_1(parameterType2, object_1[num14]);
                        num13++;
                    }
                    num14++;
                }
                while (num14 < parameters2.Length);
            }
            class7.class19_1 = new Class19[@class.list_1.Count];
            int num15 = default(int);
            do
            {
                Class11 class8 = @class.list_1[num15];
                switch (class8.enum1_0)
                {
                    case (Enum1)16:
                        class7.class19_1[num15] = new Class31(null);
                        break;
                    case (Enum1)1:
                    case (Enum1)2:
                    case (Enum1)3:
                    case (Enum1)4:
                    case (Enum1)5:
                    case (Enum1)6:
                    case (Enum1)11:
                    case (Enum1)15:
                        class7.class19_1[num15] = new Class21(0, class8.enum1_0);
                        break;
                    case (Enum1)14:
                        class7.class19_1[num15] = null;
                        break;
                    case (Enum1)13:
                        class7.class19_1[num15] = new Class23(UIntPtr.Zero);
                        break;
                    case (Enum1)12:
                        class7.class19_1[num15] = new Class23(IntPtr.Zero);
                        break;
                    case (Enum1)9:
                    case (Enum1)10:
                        class7.class19_1[num15] = new Class24(0.0, class8.enum1_0);
                        break;
                    case (Enum1)7:
                    case (Enum1)8:
                        class7.class19_1[num15] = new Class22(0L, class8.enum1_0);
                        break;
                    case (Enum1)0:
                        class7.class19_1[num15] = null;
                        break;
                }
                num15++;
            }
            while (num15 < @class.list_1.Count);
            try
            {
                class7.method_0();
            }
            finally
            {
                class7.method_1();
            }
            int num16 = 0;
            if (flag)
            {
                num16 = 1;
            }
            object[] array2 = new object[num16 + num13];
            if (flag)
            {
                array2[0] = null;
            }
            if (@class.methodBase_0 is MethodInfo)
            {
                MethodInfo methodInfo = (MethodInfo)@class.methodBase_0;
                if (methodInfo.ReturnType != typeof(void) && class7.class19_2 != null)
                {
                    array2[0] = class7.class19_2.vmethod_4(methodInfo.ReturnType);
                }
            }
            if (num13 > 0)
            {
                int num17 = 0;
                if (flag)
                {
                    num17++;
                }
                int num18 = default(int);
                do
                {
                    Type parameterType3 = parameters2[num18].ParameterType;
                    if (parameterType3.IsByRef)
                    {
                        parameterType3 = parameterType3.GetElementType();
                        if (class7.class19_0[num18] != null)
                        {
                            if (@class.methodBase_0.IsStatic)
                            {
                                array2[num17] = class7.class19_0[num18].vmethod_4(parameterType3);
                            }
                            else
                            {
                                array2[num17] = class7.class19_0[num18 + 1].vmethod_4(parameterType3);
                            }
                        }
                        else
                        {
                            array2[num17] = null;
                        }
                        num17++;
                    }
                    num18++;
                }
                while (num18 < parameters2.Length);
            }
            if (!@class.methodBase_0.IsStatic && @class.methodBase_0.DeclaringType.IsValueType)
            {
                gparam_0 = (T)class7.class19_0[0].vmethod_4(@class.methodBase_0.DeclaringType);
            }
            return array2;
        }

        internal static object[] smethod_2(int int_2, object[] object_1, object object_2)
        {
            return Class8.smethod_1(int_2, object_1, object_2, ref Class8.int_1);
        }

        internal static object[] smethod_3<T>(int int_2, object[] object_1, ref T gparam_0)
        {
            return Class8.smethod_1(int_2, object_1, gparam_0, ref gparam_0);
        }

        internal static void smethod_4()
        {
            if (Class8.int_0 == null)
            {
                BinaryReader binaryReader = new BinaryReader(typeof(Class8).Assembly.GetManifestResourceStream("qT8DjKpvRcBQxlwUc2.1V2OLwGeIEb6lyLCOW"));
                binaryReader.BaseStream.Position = 0L;
                byte[] byte_ = binaryReader.ReadBytes((int)binaryReader.BaseStream.Length);
                binaryReader.Close();
                Class8.smethod_5(byte_);
            }
        }

        internal static void smethod_5(byte[] byte_1)
        {
            Class8.binaryReader_0 = new BinaryReader(new MemoryStream(byte_1));
            Class8.byte_0 = new byte[255];
            int num = Class8.smethod_6(Class8.binaryReader_0);
            for (int i = 0; i < num; i++)
            {
                byte num2 = Class8.binaryReader_0.ReadByte();
                Class8.byte_0[num2] = Class8.binaryReader_0.ReadByte();
            }
            num = Class8.smethod_6(Class8.binaryReader_0);
            Class8.list_0 = new List<string>(num);
            for (int j = 0; j < num; j++)
            {
                Class8.list_0.Add(Encoding.Unicode.GetString(Class8.binaryReader_0.ReadBytes(Class8.smethod_6(Class8.binaryReader_0))));
            }
            num = Class8.smethod_6(Class8.binaryReader_0);
            Class8.class14_0 = new Class14[num];
            Class8.int_0 = new int[num];
            for (int k = 0; k < num; k++)
            {
                Class8.class14_0[k] = null;
                Class8.int_0[k] = Class8.smethod_6(Class8.binaryReader_0);
            }
            int num3 = (int)Class8.binaryReader_0.BaseStream.Position;
            for (int l = 0; l < num; l++)
            {
                int num4 = Class8.int_0[l];
                Class8.int_0[l] = num3;
                num3 += num4;
            }
        }

        internal static int smethod_6(BinaryReader binaryReader_1)
        {
            bool flag = false;
            uint num = 0u;
            uint num2 = binaryReader_1.ReadByte();
            num = 0u | (num2 & 0x3Fu);
            if ((num2 & 0x40u) != 0)
            {
                flag = true;
            }
            if (num2 < 128)
            {
                if (flag)
                {
                    return (int)(~num);
                }
                return (int)num;
            }
            int num3 = 0;
            while (true)
            {
                uint num4 = binaryReader_1.ReadByte();
                num |= (num4 & 0x7F) << 7 * num3 + 6;
                if (num4 < 128)
                {
                    break;
                }
                num3++;
            }
            if (flag)
            {
                return (int)(~num);
            }
            return (int)num;
        }

        public Class8()
        {
            throw /*Error near IL_0001: Stack underflow*/;
        }

        static Class8()
        {
            Class8.class14_0 = null;
            Class8.int_0 = null;
            Class8.bool_0 = false;
            Class8.object_0 = 1;
        }
    }
}
