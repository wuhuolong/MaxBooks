using System;
using System.Collections.Generic;
using System.Text;
using UnityEngine;

namespace csv
{
	public class Table
	{
		protected Dictionary<string, Dictionary<string, string>> mData;

		protected List<Dictionary<string, string>> mDataOri;

		protected List<string> mFields;

		protected Dictionary<string, string> mCurRow;

		public int Count
		{
			get
			{
				return this.mDataOri.get_Count();
			}
		}

		public void Clear()
		{
			this.mData.Clear();
			this.mDataOri.Clear();
			this.mFields.Clear();
		}

		public Table()
		{
			this.mData = new Dictionary<string, Dictionary<string, string>>();
			this.mDataOri = new List<Dictionary<string, string>>();
			this.mFields = new List<string>();
		}

		public int InitFromMemory(byte[] raw)
		{
			string @string = Encoding.get_UTF8().GetString(raw);
			return this.InitFromString(@string);
		}

		public int InitFromString(string data)
		{
			int result = 0;
			int num = data.IndexOf("\r\n");
			bool flag = num < 0;
			if (flag)
			{
				data = data.Replace("\n", "\r\n");
				num = data.IndexOf("\r\n");
			}
			bool flag2 = num < 0;
			if (flag2)
			{
				data = data.Replace("\r", "\r\n");
				num = data.IndexOf("\r\n");
			}
			string text = data.Substring(0, num);
			string text2 = data.Substring(num);
			string[] array = text.Split(new char[]
			{
				'`'
			});
			string[] array2 = array;
			for (int i = 0; i < array2.Length; i++)
			{
				string text3 = array2[i];
				string text4 = text3.Trim();
				this.mFields.Add(text4);
			}
			string[] array3 = text2.Split(new string[]
			{
				"\r\n"
			}, 1);
			string[] array4 = array3;
			for (int j = 0; j < array4.Length; j++)
			{
				string text5 = array4[j];
				string[] array5 = text5.Split(new char[]
				{
					'`'
				});
				Dictionary<string, string> dictionary = new Dictionary<string, string>();
				int num2;
				for (int k = 0; k < this.mFields.get_Count(); k = num2)
				{
					string text6 = this.mFields.get_Item(k);
					string text7 = "";
					bool flag3 = k < array5.Length;
					if (flag3)
					{
						text7 = array5[k];
					}
					dictionary.Add(text6, text7);
					num2 = k + 1;
				}
				string text8 = array5[0];
				bool flag4 = this.mData.ContainsKey(text8);
				if (flag4)
				{
					result = 1;
					Debug.LogError(string.Format("csv Error conflict key[{0}]", text8));
				}
				else
				{
					this.mData.Add(text8, dictionary);
					this.mDataOri.Add(dictionary);
				}
			}
			return result;
		}

		public string Select(int row, string field)
		{
			bool flag = row >= this.mDataOri.get_Count();
			string result;
			if (flag)
			{
				result = string.Empty;
			}
			else
			{
				Dictionary<string, string> dictionary = this.mDataOri.get_Item(row);
				bool flag2 = dictionary == null;
				if (flag2)
				{
					result = "";
				}
				else
				{
					string text = "";
					bool flag3 = dictionary.TryGetValue(field, ref text);
					if (flag3)
					{
						result = text;
					}
					else
					{
						Debug.LogError(string.Format("Column[{0}] don't exist", field));
						result = "";
					}
				}
			}
			return result;
		}

		public string Select(int row, string field, string default_value)
		{
			bool flag = row >= this.mDataOri.get_Count();
			string result;
			if (flag)
			{
				result = default_value;
			}
			else
			{
				Dictionary<string, string> dictionary = this.mDataOri.get_Item(row);
				bool flag2 = dictionary == null;
				if (flag2)
				{
					result = default_value;
				}
				else
				{
					string text = "";
					bool flag3 = dictionary.TryGetValue(field, ref text);
					if (flag3)
					{
						result = text;
					}
					else
					{
						result = default_value;
					}
				}
			}
			return result;
		}

		public bool TrySelect(int row, string field, out string value)
		{
			value = string.Empty;
			bool flag = row >= this.mDataOri.get_Count();
			bool result;
			if (flag)
			{
				result = false;
			}
			else
			{
				Dictionary<string, string> dictionary = this.mDataOri.get_Item(row);
				bool flag2 = dictionary == null;
				if (flag2)
				{
					result = false;
				}
				else
				{
					string text = "";
					bool flag3 = dictionary.TryGetValue(field, ref text);
					if (flag3)
					{
						value = text;
						result = true;
					}
					else
					{
						result = false;
					}
				}
			}
			return result;
		}

		public RowData SelectRow(string key)
		{
			Dictionary<string, string> data;
			bool flag = this.mData.TryGetValue(key, ref data);
			RowData result;
			if (flag)
			{
				result = new RowData(data);
			}
			else
			{
				Debug.LogError(string.Format("Data don't exist in key {0}", key));
				result = null;
			}
			return result;
		}

		public string Select(string key, string field)
		{
			Dictionary<string, string> dictionary;
			bool flag = this.mData.TryGetValue(key, ref dictionary);
			string result;
			if (flag)
			{
				string text;
				bool flag2 = dictionary.TryGetValue(field, ref text);
				if (flag2)
				{
					result = text;
					return result;
				}
			}
			Debug.LogError(string.Format("Column[{0}] don't exist in key {1}", field, key));
			result = "";
			return result;
		}

		public bool FieldExist(string field)
		{
			bool result;
			using (List<string>.Enumerator enumerator = this.mFields.GetEnumerator())
			{
				while (enumerator.MoveNext())
				{
					string current = enumerator.get_Current();
					bool flag = current == field;
					if (flag)
					{
						result = true;
						return result;
					}
				}
			}
			result = false;
			return result;
		}

		public bool RecordExist(string key)
		{
			return this.mData.ContainsKey(key);
		}

		public void AddField(string field)
		{
			this.mFields.Add(field);
		}

		public void AddRow(string key)
		{
			this.mCurRow = new Dictionary<string, string>();
			using (List<string>.Enumerator enumerator = this.mFields.GetEnumerator())
			{
				while (enumerator.MoveNext())
				{
					string current = enumerator.get_Current();
					this.mCurRow.Add(current, "");
				}
			}
			this.mCurRow.set_Item(this.mFields.get_Item(0), key);
			this.mData.Add(key, this.mCurRow);
		}

		public void AddValue(string field, string data)
		{
			string text;
			bool flag = this.mCurRow.TryGetValue(field, ref text);
			if (flag)
			{
				this.mCurRow.set_Item(field, data);
			}
		}

		public string ToString()
		{
			string text = "";
			using (List<string>.Enumerator enumerator = this.mFields.GetEnumerator())
			{
				while (enumerator.MoveNext())
				{
					string current = enumerator.get_Current();
					text += current;
					text += ",";
				}
			}
			text += "\r\n";
			using (Dictionary<string, Dictionary<string, string>>.ValueCollection.Enumerator enumerator2 = this.mData.get_Values().GetEnumerator())
			{
				while (enumerator2.MoveNext())
				{
					Dictionary<string, string> current2 = enumerator2.get_Current();
					using (List<string>.Enumerator enumerator3 = this.mFields.GetEnumerator())
					{
						while (enumerator3.MoveNext())
						{
							string current3 = enumerator3.get_Current();
							string text2 = current2.get_Item(current3);
							text += text2;
							text += ",";
						}
					}
					text += "\r\n";
				}
			}
			return text;
		}

		public byte[] ToBin()
		{
			string text = this.ToString();
			return Encoding.get_UTF8().GetBytes(text);
		}
	}
}
