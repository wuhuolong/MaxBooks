using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Utils
{
    /// <summary>
    ///     Converts base data types to an array of bytes, and an array of bytes to base
    ///     data types.
    ///     All info taken from the meta data of System.BitConverter. This implementation
    ///     allows for Endianness consideration.
    ///</summary>
    public static class BitConverter
    {
        /// <summary>
        ///     Indicates the byte order ("endianess") in which data is stored in this computer
        ///     architecture.
        ///</summary>
        public static bool IsLittleEndian { get; set; } // should default to false, which is what we want for Empire

        /// <summary>
        ///     Returns the specified 16-bit unsigned integer value as an array of bytes.
        ///</summary>
        public static byte[] GetBytes(ushort value)
        {
            if (IsLittleEndian)
            {
                return System.BitConverter.GetBytes(value);
            }
            else
            {
                byte[] array = System.BitConverter.GetBytes(value);
                if (array.Length == 2)
                {
                    byte tmp;
                    tmp = array[0];
                    array[0] = array[1];
                    array[1] = tmp;
                }
                else
                {
                    array = array.Reverse().ToArray();
                }
                return array;
            }
        }

        /// <summary>
        ///     Returns a 16-bit signed integer converted from two bytes at a specified position
        ///     in a byte array.
        ///</summary>
        public static short ToInt16(byte[] value, int startIndex)
        {
            short val = System.BitConverter.ToInt16(value, startIndex);
            if (!IsLittleEndian)
                val = val.SwapInt16();

            return val;
        }

        /// <summary>
        ///     Returns a 32-bit signed integer converted from four bytes at a specified
        ///     position in a byte array.
        ///</summary>
        public static int ToInt32(byte[] value, int startIndex)
        {
            int val = System.BitConverter.ToInt32(value, startIndex);
            if (!IsLittleEndian)
                val = val.SwapInt32();

            return val;
        }

        /// <summary>
        ///     Returns a 64-bit signed integer converted from eight bytes at a specified
        ///     position in a byte array.
        ///</summary>
        public static long ToInt64(byte[] value, int startIndex)
        {
            long val = System.BitConverter.ToInt64(value, startIndex);
            if (!IsLittleEndian)
                val = val.SwapInt64();

            return val;
        }

        /// <summary>
        ///     Returns a 16-bit unsigned integer converted from two bytes at a specified
        ///     position in a byte array.
        ///</summary>
        public static ushort ToUInt16(byte[] value, int startIndex)
        {
            ushort val = System.BitConverter.ToUInt16(value, startIndex);
            if (!IsLittleEndian)
                val = val.SwapUInt16();

            return val;
        }

        /// <summary>
        ///     Returns a 32-bit unsigned integer converted from four bytes at a specified
        ///     position in a byte array.
        /// </summary>
        public static uint ToUInt32(byte[] value, int startIndex)
        {
            uint val = System.BitConverter.ToUInt32(value, startIndex);
            if (!IsLittleEndian)
                val = val.SwapUInt32();

            return val;
        }

        /// <summary>
        ///     Returns a 64-bit unsigned integer converted from eight bytes at a specified
        ///     position in a byte array.
        ///</summary>
        public static ulong ToUInt64(byte[] value, int startIndex)
        {
            ulong val = System.BitConverter.ToUInt64(value, startIndex);
            if (!IsLittleEndian)
                val = val.SwapUInt64();

            return val;
        }

        /// <summary>
        ///     Returns a single-precision floating point number converted from four bytes
        ///     at a specified position in a byte array.
        ///</summary>
        public static float ToSingle(byte[] value, int startIndex)
        {
            if (IsLittleEndian)
            {
                return System.BitConverter.ToSingle(value, startIndex);
            }
            else
            {
                return System.BitConverter.ToSingle(value.Reverse().ToArray(), value.Length - sizeof(Single) - startIndex);
            }
        }

        /// <summary>
        ///     Converts the numeric value of each element of a specified array of bytes
        ///     to its equivalent hexadecimal string representation.
        ///</summary>
        public static string ToString(byte[] value)
        {
            if (IsLittleEndian)
            {
                return System.BitConverter.ToString(value);
            }
            else
            {
                return System.BitConverter.ToString(value.Reverse().ToArray());
            }
        }

        /// <summary>
        ///     Converts the numeric value of each element of a specified subarray of bytes
        ///     to its equivalent hexadecimal string representation.
        ///</summary>
        public static string ToString(byte[] value, int startIndex)
        {
            if (IsLittleEndian)
            {
                return System.BitConverter.ToString(value, startIndex);
            }
            else
            {
                return System.BitConverter.ToString(value.Reverse().ToArray(), startIndex);
            }
        }

        /// <summary>
        ///     Converts the numeric value of each element of a specified subarray of bytes
        ///     to its equivalent hexadecimal string representation.
        ///</summary>
        public static string ToString(byte[] value, int startIndex, int length)
        {
            if (IsLittleEndian)
            {
                return System.BitConverter.ToString(value, startIndex, length);
            }
            else
            {
                return System.BitConverter.ToString(value.Reverse().ToArray(), startIndex, length);
            }
        }
    }

    /// <summary>  
    /// 字节序转换  
    /// </summary>  
    public static class Endian
    {
        public static short SwapInt16(this short n)
        {
            return (short)(((n & 0xff) << 8) | ((n >> 8) & 0xff));
        }

        public static ushort SwapUInt16(this ushort n)
        {
            return (ushort)(((n & 0xff) << 8) | ((n >> 8) & 0xff));
        }

        public static int SwapInt32(this int n)
        {
            return (int)(((SwapInt16((short)n) & 0xffff) << 0x10) | (SwapInt16((short)(n >> 0x10)) & 0xffff));
        }

        public static uint SwapUInt32(this uint n)
        {
            return (uint)(((SwapUInt16((ushort)n) & 0xffff) << 0x10) | (SwapUInt16((ushort)(n >> 0x10)) & 0xffff));
        }

        public static long SwapInt64(this long n)
        {
            return (long)(((SwapInt32((int)n) & 0xffffffffL) << 0x20) | (SwapInt32((int)(n >> 0x20)) & 0xffffffffL));
        }

        public static ulong SwapUInt64(this ulong n)
        {
            return (ulong)(((SwapUInt32((uint)n) & 0xffffffffL) << 0x20) | (SwapUInt32((uint)(n >> 0x20)) & 0xffffffffL));
        }
    }
}