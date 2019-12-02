using System;

namespace Utils
{
	internal class ParseBase
	{
		public virtual int GetByteNum()
		{
			return 0;
		}

		public void Interprete(Context c)
		{
			int byteNum = this.GetByteNum();
			bool flag = c.mParseIndex + byteNum <= c.mSentence.GetLength(0);
			if (flag)
			{
				c.mParseIndex += byteNum;
			}
			else
			{
				c.mParseIndex = c.mSentence.GetLength(0);
			}
		}

		public void Execute(Context c, byte[] str_word)
		{
		}
	}
}
