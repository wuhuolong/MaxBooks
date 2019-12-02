using System;

namespace Utils
{
	public class Identifier<T>
	{
		private int mIdentifierId;

		private static int mIdentifierLastId = 0;

		public int Id
		{
			get
			{
				return this.mIdentifierId;
			}
		}

		public Identifier()
		{
			this.mIdentifierId = Identifier<T>.mIdentifierLastId;
			int num = Identifier<T>.mIdentifierLastId + 1;
			Identifier<T>.mIdentifierLastId = num;
		}

		public int GetID()
		{
			return this.mIdentifierId;
		}
	}
}
