using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Utils
{
	public static class DataFormatHelper
	{
		public static Vector3 StringToVector3(string raw)
		{
			raw = raw.Replace("(", "").Replace(")", "");
			string[] array = raw.Split(new char[]
			{
				','
			});
			bool flag = array.Length < 3;
			Vector3 result;
			if (flag)
			{
				result = Vector3.get_zero();
			}
			else
			{
				result = new Vector3(float.Parse(array[0]), float.Parse(array[1]), float.Parse(array[2]));
			}
			return result;
		}

		public static Vector2 StringToVector2(string raw)
		{
			raw = raw.Replace("(", "").Replace(")", "");
			raw = raw.Replace("[", "").Replace("]", "");
			raw = raw.Replace("{", "").Replace("}", "");
			string[] array = raw.Split(new char[]
			{
				','
			});
			bool flag = array.Length < 2;
			Vector2 result;
			if (flag)
			{
				result = Vector2.get_zero();
			}
			else
			{
				result = new Vector2(float.Parse(array[0]), float.Parse(array[1]));
			}
			return result;
		}

		public static Quaternion StringToQuaternion(string raw)
		{
			raw = raw.Replace("(", "").Replace(")", "");
			string[] array = raw.Split(new char[]
			{
				','
			});
			bool flag = array.Length < 4;
			Quaternion result;
			if (flag)
			{
				result = Quaternion.get_identity();
			}
			else
			{
				result = new Quaternion(float.Parse(array[0]), float.Parse(array[1]), float.Parse(array[2]), float.Parse(array[3]));
			}
			return result;
		}

		public static string ContainerToString<T>(T container) where T : IEnumerable
		{
			string text = "(";
			int num = 0;
			IEnumerator enumerator = container.GetEnumerator();
			try
			{
				while (enumerator.MoveNext())
				{
					object current = enumerator.get_Current();
					text += current;
					text += ",";
					int num2 = num + 1;
					num = num2;
				}
			}
			finally
			{
				IDisposable disposable = enumerator as IDisposable;
				if (disposable != null)
				{
					disposable.Dispose();
				}
			}
			bool flag = num > 0;
			if (flag)
			{
				text = text.Remove(text.get_Length() - 1);
			}
			text += ")";
			return text;
		}

		public static void DBRawStringReplaceBracketToIds(string rawString, List<uint> ids)
		{
			bool flag = ids == null || string.IsNullOrEmpty(rawString);
			if (!flag)
			{
				rawString = rawString.Replace("[", "");
				rawString = rawString.Replace("]", "");
				rawString = rawString.Replace("{", "");
				rawString = rawString.Replace("}", "");
				string[] array = rawString.Split(new char[]
				{
					','
				});
				string[] array2 = array;
				for (int i = 0; i < array2.Length; i++)
				{
					string text = array2[i];
					uint num = 0u;
					uint.TryParse(text, ref num);
					bool flag2 = num > 0u;
					if (flag2)
					{
						ids.Add(num);
					}
				}
			}
		}

		public static void DBRawStringReplaceBraceToIds(string rawString, List<uint> ids)
		{
			bool flag = ids == null || string.IsNullOrEmpty(rawString);
			if (!flag)
			{
				rawString = rawString.Replace("{", "");
				rawString = rawString.Replace("}", "");
				string[] array = rawString.Split(new char[]
				{
					','
				});
				string[] array2 = array;
				for (int i = 0; i < array2.Length; i++)
				{
					string text = array2[i];
					uint num = 0u;
					uint.TryParse(text, ref num);
					bool flag2 = num > 0u;
					if (flag2)
					{
						ids.Add(num);
					}
				}
			}
		}

		public static void DBRawStringReplaceBracketToId(string rawString, out uint id)
		{
			id = 0u;
			bool flag = string.IsNullOrEmpty(rawString);
			if (!flag)
			{
				rawString = rawString.Replace("[", "");
				rawString = rawString.Replace("]", "");
				uint.TryParse(rawString, ref id);
			}
		}

		public static string GetDBValue(List<Dictionary<string, string>> dbs, string idName, string idKey, string targetName)
		{
			bool flag = dbs == null;
			string result;
			if (flag)
			{
				result = string.Empty;
			}
			else
			{
				using (List<Dictionary<string, string>>.Enumerator enumerator = dbs.GetEnumerator())
				{
					while (enumerator.MoveNext())
					{
						Dictionary<string, string> current = enumerator.get_Current();
						string empty = string.Empty;
						bool flag2 = current.TryGetValue(idName, ref empty);
						if (!flag2)
						{
							result = string.Empty;
							return result;
						}
						bool flag3 = empty != idKey;
						if (!flag3)
						{
							string empty2 = string.Empty;
							bool flag4 = current.TryGetValue(targetName, ref empty2);
							if (flag4)
							{
								result = empty2;
								return result;
							}
						}
					}
				}
				result = string.Empty;
			}
			return result;
		}

		public static uint GetDBValueByUint(List<Dictionary<string, string>> dbs, string idName, string idKey, string targetName)
		{
			string dBValue = DataFormatHelper.GetDBValue(dbs, idName, idKey, targetName);
			uint result = 0u;
			uint.TryParse(dBValue, ref result);
			return result;
		}

		public static float GetDBValueByFloat(List<Dictionary<string, string>> dbs, string idName, string idKey, string targetName)
		{
			string dBValue = DataFormatHelper.GetDBValue(dbs, idName, idKey, targetName);
			float result = 0f;
			float.TryParse(dBValue, ref result);
			return result;
		}
	}
}
