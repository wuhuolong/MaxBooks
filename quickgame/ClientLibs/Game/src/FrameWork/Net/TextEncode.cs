using System;
using System.Text;

namespace TextEncode
{
	public class Convert
	{
		static public string GBK2Unicode(byte[] gbkData)
		{
			Encoding gbkencoding = Encoding.GetEncoding(936);
            if(gbkencoding == null)
                return "";

            byte[] buf = Encoding.Convert(gbkencoding, Encoding.Unicode, gbkData);
			string text = Encoding.Unicode.GetString(buf);
			return text;
		}
		
		static public byte[] Unicode2GBK(string data)
		{
			Encoding gbkEncoding = Encoding.GetEncoding(936);
            if(gbkEncoding == null)
                return null;

            byte[] uniBytes = Encoding.Unicode.GetBytes(data);
            byte[] gbkBytes = Encoding.Convert(Encoding.Unicode, gbkEncoding, uniBytes);
            return gbkBytes;
		}
		
		static public byte[] Utf8ToGB2312(string utf8Str)
		{
            System.Text.Encoding gb2312Encoding = System.Text.Encoding.GetEncoding ("GB2312");
            if(gb2312Encoding == null)
                return null;

			byte[] utfBytes = System.Text.Encoding.UTF8.GetBytes (utf8Str);
            byte[] gb2312Bytes = System.Text.Encoding.Convert (Encoding.UTF8, gb2312Encoding, utfBytes);
            return gb2312Bytes;
		}
		
		static public byte[] Unicode2Utf8(string strUnicode)
		{
			System.Text.Encoding srcCode  = System.Text.Encoding.Unicode;
			System.Text.Encoding destCode = System.Text.Encoding.UTF8;
			byte[] bytes = System.Text.Encoding.Unicode.GetBytes(strUnicode);
			return System.Text.Encoding.Convert(srcCode, destCode, bytes);
		}
		
		static public string Utf82Unicode(byte[] utf8)
		{
			// c#的string求长度会包含0，所以这里要去掉
			System.Collections.Generic.List<byte> buf = new System.Collections.Generic.List<byte>();
			for (int i=0; i<utf8.Length; ++i)
			{
				if (utf8[i] != 0)
					buf.Add(utf8[i]);
				else
					break;
			}
			
			string s = System.Text.Encoding.UTF8.GetString(buf.ToArray());
			return s;
		}
	}
}

