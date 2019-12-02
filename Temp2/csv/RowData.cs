using System;
using System.Collections.Generic;
using UnityEngine;

namespace csv
{
	public class RowData
	{
		private Dictionary<string, string> mRowData;

		public RowData(Dictionary<string, string> data)
		{
			this.mRowData = data;
		}

		public string Select(string field)
		{
			bool flag = this.mRowData != null;
			string result;
			if (flag)
			{
				string text;
				bool flag2 = this.mRowData.TryGetValue(field, ref text);
				if (flag2)
				{
					result = text;
					return result;
				}
			}
			Debug.LogError(string.Format("Column[{0}] don't exist in RowData", field));
			result = "";
			return result;
		}
	}
}
