using System;
using System.Collections.Generic;
using UnityEngine;

namespace csv
{
	public class RowData
	{
		Dictionary<string, string> mRowData;
		public RowData(Dictionary<string, string> data)
		{
			mRowData = data;
		}

		public string Select(string field)
		{
			if (mRowData != null)
			{
				string data;
				if (mRowData.TryGetValue(field, out data))
					return data;
			}
			Debug.LogError(string.Format("Column[{0}] don't exist in RowData", field));
			return "";
		}
	}

	// 全部字段区分大小写！
	// 字符编码为utf8
	public class Table
	{
		// row -> rowData
		// rowData: field -> value
		protected Dictionary<string, Dictionary<string, string> > mData;
		
		protected List<Dictionary<string, string> > mDataOri;
		
		protected List<string> mFields;
		
		public int Count
		{
			get
			{
				return mDataOri.Count;
			}
		}
		
		public void Clear()
		{
			mData.Clear();
			mDataOri.Clear();
			mFields.Clear();
		}
		
		// 创建表时用到的临时数据
		protected Dictionary<string, string> mCurRow;
		
		public Table()
		{
			mData = new Dictionary<string, Dictionary<string, string> >();
			mDataOri = new List<Dictionary<string, string>>();
			mFields = new List<string>();
		}
		
		public int InitFromMemory(byte[] raw)
		{
			string data = System.Text.Encoding.UTF8.GetString(raw);
			return InitFromString(data);
		}
		
		public int InitFromString(string data)
		{
			int result = 0;

			int firstEnter = data.IndexOf("\r\n");
			if (firstEnter < 0)
			{ // Hack for line ending used with mac os style
				data = data.Replace("\n", "\r\n");
				firstEnter = data.IndexOf("\r\n");
			}
            if (firstEnter < 0)
            {
                data = data.Replace("\r", "\r\n");
                firstEnter = data.IndexOf("\r\n");
            }
			
			// 字段数据
			string rawFields = data.Substring(0, firstEnter);
			
			// 条目数据
			string rawRows = data.Substring(firstEnter);
			
			// 分离出字段
			string[] fields = rawFields.Split('`');
			foreach (string f in fields)
			{
				string v = f.Trim();
#if UNITY_EDITOR
				if (v == string.Empty)
				{
					Debug.LogError("表格字段不能为空串");
					continue;
				}
#endif
				mFields.Add(v);
			}
			
			// 分离出各个条目
			string[] rows = rawRows.Split(new string[1]{"\r\n"}, StringSplitOptions.RemoveEmptyEntries);
			
			foreach (string row in rows)
			{
				string[] rowData = row.Split('`');
				Dictionary<string, string> rowFormat = new Dictionary<string, string>();
				for (int i=0; i<mFields.Count; ++i)
				{
					string field = mFields [i];
					string v = "";
					if (i < rowData.Length)
						v = rowData [i];
					
#if UNITY_EDITOR
					if (rowFormat.ContainsKey(field))
					{
						Debug.LogError("同一条记录，添加重复的属性:" + field);
						continue;
					}
#endif
					
					rowFormat.Add(field, v);
				}
				
				string key = rowData [0];
				if (mData.ContainsKey(key))
				{
					result = 1;
					Debug.LogError(string.Format("csv Error conflict key[{0}]", key));
				}
				else
				{
					mData.Add(key, rowFormat);
					mDataOri.Add(rowFormat);
				}
			}

			return result;
		}
		
		public string Select(int row, string field)
		{
            if(row >= mDataOri.Count)
            {
                return string.Empty;
            }

			Dictionary<string, string> r = mDataOri [row];
			if (r == null)
				return "";
			
			string result = "";
			if (r.TryGetValue(field, out result))
				return result;
			
			Debug.LogError(string.Format("Column[{0}] don't exist", field));
			return "";
		}

        public string Select(int row, string field, string default_value)
        {
            if (row >= mDataOri.Count) {
                return default_value;
            }

            Dictionary<string, string> r = mDataOri[row];
            if (r == null) {
                return default_value;
            }

            string result = "";
            if (r.TryGetValue(field, out result)) {
                return result;
            }

            return default_value;
        }

        public bool TrySelect(int row, string field, out string value)
        {
            value = string.Empty;
            if (row >= mDataOri.Count) {
                return false;
            }

            Dictionary<string, string> r = mDataOri[row];
            if (r == null) {
                return false;
            }

            string result = "";
            if (r.TryGetValue(field, out result)) {
                value = result;
                return true;
            }

            return false;
        }

        /// <summary>
        /// 获取某一行的数据
        /// </summary>
        public RowData SelectRow(string key)
		{
			Dictionary<string, string> row;
			if (mData.TryGetValue(key, out row))
			{
				return new RowData(row);
			}
			Debug.LogError(string.Format("Data don't exist in key {0}", key));
			return null;
		}

		public string Select(string key, string field)
		{
			Dictionary<string, string> row;
			if (mData.TryGetValue(key, out row))
			{
				string data;
				if (row.TryGetValue(field, out data))
					return data;
			}
            Debug.LogError(string.Format("Column[{0}] don't exist in key {1}", field, key));
			return "";
		}
		
        public bool FieldExist(string field)
        {
            foreach (var f in mFields) {
                if (f == field) {
                    return true;
                }
            }

            return false;
        }

		public bool RecordExist(string key)
		{
			return mData.ContainsKey(key);
		}
		
		public void AddField(string field)
		{
			mFields.Add(field);
		}
		
		public void AddRow(string key)
		{
			mCurRow = new Dictionary<string, string>();
			foreach (string field in mFields)
			{
				mCurRow.Add(field, "");
			}
			mCurRow [this.mFields [0]] = key;
			mData.Add(key, mCurRow);
		}
		
		public void AddValue(string field, string data)
		{
			string cur;
			if (mCurRow.TryGetValue(field, out cur))
			{
				mCurRow [field] = data;
			}
		}
		
		new public string ToString()
		{
			string data = "";
			foreach (string f in mFields)
			{
				data += f;
				data += ",";
			}
			data += "\r\n";
			
			foreach (Dictionary<string, string> row in mData.Values)
			{
				foreach (string field in mFields)
				{
					string v = row [field];
					data += v;
					data += ",";
				}
				data += "\r\n";	
			}
			return data;
		}
		
		public byte[] ToBin()
		{
			string data = ToString();
			
			// unicode 编码
			return System.Text.Encoding.UTF8.GetBytes(data);
		}
	}
}

