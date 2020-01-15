using System;
using System.Runtime.InteropServices;
using Net;
using xc.protocol;
using xc;

//[DisableLuaBugFix]
public class CRC8
{
    /// <summary> 
    /// CRC8位校验表 
    /// </summary> 
    private static byte[] CRC8Table = new byte[] 
    { 
        0,94,188,226,97,63,221,131,194,156,126,32,163,253,31,65, 
        157,195,33,127,252,162,64,30, 95,1,227,189,62,96,130,220,
        35,125,159,193,66,28,254,160,225,191,93,3,128,222,60,98,
        190,224,2,92,223,129,99,61,124,34,192,158,29,67,161,255,
        70,24,250,164,39,121,155,197,132,218,56,102,229,187,89,7,
        219,133,103,57,186,228,6,88,25,71,165,251,120,38,196,154,
        101,59,217,135,4,90,184,230,167,249,27,69,198,152,122,36,
        248,166,68,26,153,199,37,123,58,100,134,216,91,5,231,185,
        140,210,48,110,237,179,81,15,78,16,242,172,47,113,147,205,
        17,79,173,243,112,46,204,146,211,141,111,49,178,236,14,80,
        175,241,19,77,206,144,114,44,109,51,209,143,12,82,176,238,
        50,108,142,208,83,13,239,177,240,174,76,18,145,207,45,115,
        202,148,118,40,171,245,23,73,8,86,180,234,105,55,213,139,
        87,9,235,181,54,104,138,212,149,203, 41,119,244,170,72,22,
        233,183,85,11,136,214,52,106,43,117,151,201,74,20,246,168,
        116,42,200,150,21,75,169,247,182,232,10,84,215,137,107,53 
    };

    public static byte CRC(int value)
    {
        byte crc = 0;

        for (int i = 0; i < 4; i++)
        {
            byte ib = (byte) (value>>(8*i) & 0xFF);
            crc = CRC8Table[crc ^ ib];
        }
        return crc;
    }

    public static byte CRC(uint value)
    {
        byte crc = 0;
        
        for (int i = 0; i < 4; i++)
        {
            byte ib = (byte) (value>>(8*i) & 0xFF);
            crc = CRC8Table[crc ^ ib];
        }
        return crc;
    }

    /// <summary>
    /// 只校验后四个字节
    /// </summary>
    public static byte CRC(long value)
    {
        byte crc = 0;
        
        for (int i = 0; i < 4; i++)
        {
            byte ib = (byte) (value>>(8*i) & 0xFF);
            crc = CRC8Table[crc ^ ib];
        }
        return crc;
    }

    /*public static byte CRC(byte[] buffer)
    {
        return CRC(buffer, 0, buffer.Length);
    }
    
    public static byte CRC(byte[] buffer, int off, int len)
    {
        byte crc = 0;
        if (buffer == null)
        {
            throw new ArgumentNullException("buffer");
        }
        if (off < 0 || len < 0 || off + len > buffer.Length)
        {
            throw new ArgumentOutOfRangeException();
        }
        
        for (int i = off; i < len; i++)
        {
            crc = CRC8Table[crc ^ buffer[i]];
        }
        return crc;
    }*/
}

[StructLayout(LayoutKind.Sequential)]
public struct SafeInteger
{
    private const long Mask     = 0x6c6c6c6c6c6c6c6c;
    private const long SignMask = 0x00000000FFFFFFFF;
    //private const long Mask = 0x3c3c3c3c3c3c3c3c;
    private long mValue;
    private byte CrcValue;
    private static bool mHasSend = false;
	/*
    public override unsafe string ToString()
    {
        int num = *((int*) this);
        return num.ToString();
    }
    */
	public override string ToString()
    {
        uint num = (uint)this;
		return num.ToString();
    }

    private static void SendError()
    {
        xc.UserPlayerPrefs.Instance.SetString("playsi","1");

        if(mHasSend == false)
        {
            mHasSend = true;
        }
        //xc.Game.GetInstance().Quit(true);
    }

    public static implicit operator float(SafeInteger si)
    {
        // 表示safeint的数值没有初始化
        if(si.mValue == 0 && si.CrcValue == 0)
        {
            //si.mValue = Mask;
            //si.CrcValue = CRC8.CRC(si.mValue);
            return 0.0f;
        }

        long num = (si.mValue << 0x10) | (si.mValue >> 0x10);
        int val = (int)(num ^ Mask);
        if(CRC8.CRC(si.mValue) != si.CrcValue)
        {
            SendError();
            return (float)val;
        }
        else
            return (float)val;
    }

    public static implicit operator int(SafeInteger si)
    {
        // 表示safeint的数值没有初始化
        if(si.mValue == 0 && si.CrcValue == 0)
        {
            //si.mValue = Mask;
            //si.CrcValue = CRC8.CRC(si.mValue);
            return 0;
        }

        long num = (si.mValue << 0x10) | (si.mValue >> 0x10);
        int val = (int)(num ^ Mask);
        if(CRC8.CRC(si.mValue) != si.CrcValue)
        {
            SendError();
            return val;
        }
        else
            return val;
    }

    public static implicit operator uint(SafeInteger si)
    {
        // 表示safeint的数值没有初始化
        if(si.mValue == 0 && si.CrcValue == 0)
        {
            //si.mValue = Mask;
            //si.CrcValue = CRC8.CRC(si.mValue);
            return 0;
        }

        long num = (si.mValue << 0x10) | (si.mValue >> 0x10);
        uint val = (uint)(num ^ Mask);
        if(CRC8.CRC(si.mValue) != si.CrcValue)
        {
            SendError();
            return val;
        }
        else
            return val;
    }

    public static implicit operator SafeInteger(int n)
    {
        SafeInteger integer;
        long num = n & SignMask;
		num = (num << 0x10) | (num >> 0x10);
        integer.mValue = num ^ Mask;
        integer.CrcValue = CRC8.CRC(integer.mValue);
        return integer;
    }

    public static implicit operator SafeInteger(uint n)
    {
        SafeInteger integer;
        long num = n & SignMask;
        num = (num << 0x10) | (num >> 0x10);
        integer.mValue = num ^ Mask;
        integer.CrcValue = CRC8.CRC(integer.mValue);
        return integer;
    }
}

