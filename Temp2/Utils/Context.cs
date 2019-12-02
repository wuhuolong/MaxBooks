using System;

namespace Utils
{
	internal class Context
	{
		public byte[] mSentence;

		public int mParseIndex;

		public Context(byte[] sentence)
		{
			this.mSentence = sentence;
			this.mParseIndex = 0;
		}

		public void ClearResult()
		{
			this.mSentence = null;
			this.mParseIndex = 0;
		}
	}
}
