using System;
using System.Text;

namespace Utils
{
	public class Utf8Parse
	{
		private Context context;

		public Utf8Parse(string str)
		{
			byte[] bytes = Encoding.get_UTF8().GetBytes(str);
			this.context = new Context(bytes);
		}

		public void ParseSentence()
		{
			int length = this.context.mSentence.GetLength(0);
			while (this.context.mParseIndex < length)
			{
				int num = (int)this.context.mSentence[this.context.mParseIndex];
				bool flag = num >= 0 && num <= 127;
				ParseBase parseBase;
				if (flag)
				{
					parseBase = new OneByteParse();
				}
				else
				{
					bool flag2 = num >= 192 && num < 224;
					if (flag2)
					{
						parseBase = new TwoByteParse();
					}
					else
					{
						bool flag3 = num >= 224 && num < 240;
						if (flag3)
						{
							parseBase = new ThreeByteParse();
						}
						else
						{
							bool flag4 = num >= 240;
							if (!flag4)
							{
								break;
							}
							parseBase = new FourByteParse();
						}
					}
				}
				bool flag5 = parseBase != null;
				if (flag5)
				{
					parseBase.Interprete(this.context);
				}
			}
		}

		public float GetWordLenByRule()
		{
			float num = 0f;
			int length = this.context.mSentence.GetLength(0);
			while (this.context.mParseIndex < length)
			{
				int num2 = (int)this.context.mSentence[this.context.mParseIndex];
				bool flag = num2 >= 0 && num2 <= 127;
				ParseBase parseBase;
				if (flag)
				{
					parseBase = new OneByteParse();
					num += 0.7f;
				}
				else
				{
					bool flag2 = num2 >= 192 && num2 < 224;
					if (flag2)
					{
						parseBase = new TwoByteParse();
						float num3 = num;
						num = num3 + 1f;
					}
					else
					{
						bool flag3 = num2 >= 224 && num2 < 240;
						if (flag3)
						{
							parseBase = new ThreeByteParse();
							float num3 = num;
							num = num3 + 1f;
						}
						else
						{
							bool flag4 = num2 >= 240;
							if (!flag4)
							{
								break;
							}
							parseBase = new FourByteParse();
							float num3 = num;
							num = num3 + 1f;
						}
					}
				}
				bool flag5 = parseBase != null;
				if (flag5)
				{
					parseBase.Interprete(this.context);
				}
			}
			return num;
		}

		public int GetSubWordsLen(int maxLen)
		{
			this.context.mParseIndex = 0;
			int length = this.context.mSentence.GetLength(0);
			int mParseIndex;
			while (this.context.mParseIndex < length)
			{
				int num = (int)this.context.mSentence[this.context.mParseIndex];
				bool flag = num >= 0 && num <= 127;
				ParseBase parseBase;
				if (flag)
				{
					parseBase = new OneByteParse();
				}
				else
				{
					bool flag2 = num >= 192 && num < 224;
					if (flag2)
					{
						parseBase = new TwoByteParse();
					}
					else
					{
						bool flag3 = num >= 224 && num < 240;
						if (flag3)
						{
							parseBase = new ThreeByteParse();
						}
						else
						{
							bool flag4 = num >= 240;
							if (!flag4)
							{
								break;
							}
							parseBase = new FourByteParse();
						}
					}
				}
				bool flag5 = this.context.mParseIndex + parseBase.GetByteNum() > maxLen;
				if (flag5)
				{
					mParseIndex = this.context.mParseIndex;
					return mParseIndex;
				}
				bool flag6 = parseBase != null;
				if (flag6)
				{
					parseBase.Interprete(this.context);
				}
			}
			mParseIndex = this.context.mParseIndex;
			return mParseIndex;
		}

		public static string BinToUtf8(byte[] total)
		{
			bool flag = total.Length == 0;
			string result;
			if (flag)
			{
				result = string.Empty;
			}
			else
			{
				int num = 0;
				int num2 = total.Length;
				bool flag2 = total[0] == 239 && total[1] == 187 && total[2] == 191;
				if (flag2)
				{
					num = 3;
					num2 -= 3;
				}
				string @string = Encoding.get_UTF8().GetString(total, num, num2);
				result = @string;
			}
			return result;
		}
	}
}
