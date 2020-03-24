using System;
using System.Collections;
using System.Collections.Generic;

namespace Utils
{
	class Context
	{
		public byte[] mSentence;
		//public List<byte[]> mParseSentence;
		public int mParseIndex;

		public Context (byte[] sentence)
		{
			mSentence = sentence;
			mParseIndex = 0;
		
			/*if (mParseSentence != null)
				mParseSentence.Clear ();
			else
				mParseSentence = new List<byte[]> ();*/
		}
                
		public void ClearResult ()
		{
			mSentence = null;
			mParseIndex = 0;
		
			/*if (mParseSentence != null)
				mParseSentence.Clear ();
			else
				mParseSentence = new List<byte[]> ();*/
		} 
	}

	class ParseBase
	{
		public virtual int GetByteNum ()
		{
			return 0;
		}
	
		public void Interprete (Context c)
		{
			int charNum = GetByteNum ();
			if ((c.mParseIndex + charNum) <= c.mSentence.GetLength (0)) {
				//byte[] word = new byte[charNum];
				//Array.Copy (c.mSentence, c.mParseIndex, word, 0, charNum);
				//Execute (c, word);
				c.mParseIndex += charNum;
			} else {
				c.mParseIndex = c.mSentence.GetLength (0);
			}
		}
       
		public void Execute (Context c, byte[] str_word)
		{
			//c.mParseSentence.Add (str_word);
		}
	}
              
	class OneByteParse:ParseBase
	{
		public override int GetByteNum ()
		{
			return 1;
		}
	}

	class TwoByteParse:ParseBase
	{
		public override int GetByteNum ()
		{
			return 2;
		}
	}

	class ThreeByteParse:ParseBase
	{
		public override int GetByteNum ()
		{
			return 3;
		}
	}

	class FourByteParse:ParseBase
	{
		public override int GetByteNum ()
		{
			return 4;
		}
	}

	public class Utf8Parse
	{
		Context context;

		public Utf8Parse (string str)
		{
			byte[] sen = System.Text.Encoding.UTF8.GetBytes (str);
			context = new Context (sen);
		}
                
		/*public void SetSentence (string str)
		{
			context.ClearResult ();
			byte[] sen = System.Text.Encoding.UTF8.GetBytes (str);
			context.mSentence = sen;
		}*/
                
		public void ParseSentence ()
		{
			int len = context.mSentence.GetLength (0);
			while (context.mParseIndex < len) {
				ParseBase parse = null;
				int byte_val = (int)(context.mSentence [context.mParseIndex]);
				if (byte_val >= 0 && byte_val <= 0x7f)
					parse = new OneByteParse ();
				else if (byte_val >= 0xc0 && byte_val < 0xe0)
					parse = new TwoByteParse ();
				else if (byte_val >= 0xe0 && byte_val < 0xf0)
					parse = new ThreeByteParse ();
				else if (byte_val >= 0xf0)
					parse = new FourByteParse ();
				else
					break;

				if (parse != null)
					parse.Interprete (context);
			}
		}

        /// <summary>
        /// 根据规则返回字符串的长度(汉字+1,英文和数字+0.5)
        /// </summary>
        /// <returns></returns>
        public float GetWordLenByRule()
        {
            float word_len = 0;
            int len = context.mSentence.GetLength(0);
            while (context.mParseIndex < len)
            {
                ParseBase parse = null;
                int byte_val = (int)(context.mSentence[context.mParseIndex]);
                if (byte_val >= 0 && byte_val <= 0x7f)
                {
                    parse = new OneByteParse();
                    word_len+=0.7f;
                }
                else if (byte_val >= 0xc0 && byte_val < 0xe0)
                {
                    parse = new TwoByteParse();
                    word_len ++;
                }
                else if (byte_val >= 0xe0 && byte_val < 0xf0)
                {
                    parse = new ThreeByteParse();
                    word_len++;
                }
                else if (byte_val >= 0xf0)
                {
                    parse = new FourByteParse();
                    word_len++;
                }
                else
                    break;

                if (parse != null)
                    parse.Interprete(context);
            }

            return word_len;
        }

		
		public int GetSubWordsLen (int maxLen)
		{
			context.mParseIndex = 0;
			
			int len = context.mSentence.GetLength (0);
			while (context.mParseIndex < len) {
				ParseBase parse = null;
				int byte_val = (int)(context.mSentence [context.mParseIndex]);
				if (byte_val >= 0 && byte_val <= 0x7f)
					parse = new OneByteParse ();
				else if (byte_val >= 0xc0 && byte_val < 0xe0)
					parse = new TwoByteParse ();
				else if (byte_val >= 0xe0 && byte_val < 0xf0)
					parse = new ThreeByteParse ();
				else if (byte_val >= 0xf0)
					parse = new FourByteParse ();
				else
					break;
				
				if(context.mParseIndex + parse.GetByteNum() > maxLen)
					return context.mParseIndex;
						
				if (parse != null)
					parse.Interprete (context);
			}
			
			return context.mParseIndex;
		}

		public static string BinToUtf8(byte[] total)
		{
            byte[] result = total;

            if (total.Length <= 0)
            {
                return string.Empty;
            }

            int start_idx = 0;
            int bytes_num = total.Length;
            if (total[0] == 0xef && total[1] == 0xbb && total[2] == 0xbf)
            {
                // utf8文件的前三个字节为特殊占位符，要跳过
                start_idx = 3;
                bytes_num -= 3;
            }

            string utf8string = System.Text.Encoding.UTF8.GetString(result, start_idx, bytes_num);
            return utf8string;
		}
		/*public int GetWordLen ()
		{
			return context.mParseSentence.Count;
		}*/
        
		/*public List<byte[]> GetWords ()
		{
			return context.mParseSentence;
		}*/
	}
}