using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using System.Text;
using System.IO;

using Utils;
using SGameEngine;

namespace xc
{
	#region 相关特性
	public abstract class Data2StringParseAttribute : System.Attribute
	{
		public abstract void Parse(System.Object kTarget, FieldInfo kInfo, string strValue);		
	}
	
	public class IntStringParseAttribute : Data2StringParseAttribute
	{
		int miDefault = 0;
		public IntStringParseAttribute(int iDefault)
		{
			miDefault = iDefault;
		}
		
		public override void Parse (object kTarget, FieldInfo kInfo, string strValue)
		{
			int iValue = 0;
			kInfo.SetValue(kTarget, int.TryParse(strValue, out iValue) ? iValue : miDefault);
		}
	}
	
	public class UintStringParseAttribute : Data2StringParseAttribute
	{
		uint muiDefault = 0;
		public UintStringParseAttribute(uint uiDefault)
		{
			muiDefault = uiDefault;
		}
		
		public override void Parse (object kTarget, FieldInfo kInfo, string strValue)
		{
			uint uiValue = 0;
			kInfo.SetValue(kTarget, uint.TryParse(strValue, out uiValue) ? uiValue : muiDefault);
		}
	}
	
	public class StringParseAttribute : Data2StringParseAttribute
	{
		public StringParseAttribute()
		{
		}
		
		public override void Parse (object kTarget, FieldInfo kInfo, string strValue)
		{
			kInfo.SetValue(kTarget, strValue);			
		}
	}
	#endregion
	
	public class DBTextResource : DBManager.DBBase
	{
		public string mStrName;
		public string mStrPath;
		public DBTextResource(string strName, string strPath)
		{
			mStrName = strName;
			mStrPath = strPath;
		}
		
		public override void Load ()
		{
#if UNITY_EDITOR
            string resName = DBManager.AssetsResPath + "/" + mStrPath;

            TextAsset textObj = EditorResourceLoader.LoadAssetAtPath(resName, typeof(TextAsset)) as TextAsset;
			if(textObj != null)
			{
				string strData = CommonTool.BytesToUtf8(textObj.bytes);
				if(strData != "")
					ParseData(strData);
					
				IsLoaded = true;
			}
			else
				GameDebug.LogError("DB file load failed: " + mStrPath);
#else
			AssetBundle db_bundle = DBManager.GetInstance().DBBundle;
			if(db_bundle != null)
			{
				string fileName = Path.GetFileNameWithoutExtension(mStrPath);
				Object resObj = db_bundle.LoadAsset(fileName);

				TextAsset text = resObj as TextAsset;
				if (text != null)
				{
					string strData = CommonTool.BytesToUtf8(text.bytes);
					if(strData != "")
						ParseData(strData);

					IsLoaded = true;
                    Resources.UnloadAsset(text);
                }
				else
					GameDebug.LogError("DB file load failed: " + mStrPath);
			}
			else
				GameDebug.LogError("DB asset is null!!!");
#endif

			/*AssetManager manager = Game.GetInstance().MainInterface.GetAssetManager();                
			if (manager== null)
			{
				GameDebug.LogError("No AssetManager!");
				return;
			}*/

			/*if (xc.Game.GetInstance().IsUsePackage() || Application.platform != RuntimePlatform.WindowsPlayer)
			{
				string path = mStrPath;
				//string ext = Path.GetExtension(mStrPath).ToLower();
				manager.LoadAsset(path, LoadData);
			}
			else
			{
				string path = "";
				string nameNoExtend = PathHelp.GetPathWithNoExtend(mStrPath);
					
				path = "Resources/" + mStrPath;
				path = PathHelp.GetFullPaltformPath(path, false);
					
				System.IO.FileStream stream = new System.IO.FileStream(path, System.IO.FileMode.Open);
				byte[] content = new byte[stream.Length];
				stream.Read(content, 0, (int)stream.Length);
					
				IsLoaded = true;
					
				string strData = AssetManager.BinToUtf8(content);
				ParseData(strData);
				stream.Close();
			}*/
		}
		
		protected void LoadData(string name, AssetBundle bundle, Object resObj, System.Object userData)
		{
			IsLoaded = true;
			
			string strData = "";
			if (bundle != null)
			{
				Object obj = bundle.mainAsset;
				TextAsset text = obj as TextAsset;
				strData = CommonTool.BytesToUtf8(text.bytes);
                Resources.UnloadAsset(text);
                //strData = ta.text;
            }
			else
			{
				TextAsset text = resObj as TextAsset;
				if (text != null)
                {
                    strData = CommonTool.BytesToUtf8(text.bytes);
                    Resources.UnloadAsset(text);
                }
				else
					GameDebug.LogError("db file load fail:"+name);
			}

			if(strData != "")
				ParseData(strData);
		}
		
		protected virtual void ParseData(string strData)
		{
			
		}
		
		public static uint ParseUI(string strValue)
		{
			if (string.IsNullOrEmpty(strValue))
				return 0;
            uint iResult;
            if (uint.TryParse(strValue, out iResult))
                return iResult;
            return 0;
		}
		
		public static uint ParseUI_s(string strValue, uint uiDefault)
		{
			if (string.IsNullOrEmpty(strValue))
				return uiDefault;
			uint uiResult;
			if (uint.TryParse(strValue, out uiResult))
				return uiResult;
			return uiDefault;
		}
				
		public static int ParseI(string strValue)
		{
			if (string.IsNullOrEmpty(strValue))
				return 0;
            int iResult;
            if (int.TryParse(strValue, out iResult))
                return iResult;
            return 0;
		}
		
		public static int ParseI_s(string strValue, int iDefault)
		{
			if (string.IsNullOrEmpty(strValue))
				return iDefault;
			int iResult;
			if (int.TryParse(strValue, out iResult))
				return iResult;
			return iDefault;
		}

        public static ulong ParseUL(string strValue)
        {
            if (string.IsNullOrEmpty(strValue))
                return 0;
            return ulong.Parse(strValue);
        }

        public static ulong ParseUL_s(string strValue, ulong iDefault)
        {
            if (string.IsNullOrEmpty(strValue))
                return iDefault;
            ulong iResult;
            if (ulong.TryParse(strValue, out iResult))
                return iResult;
            return iDefault;
        }

        public static long ParseL(string strValue)
		{
			if (string.IsNullOrEmpty(strValue))
				return 0;
			return long.Parse(strValue);
		}
		
		public static long ParseL_s(string strValue, long iDefault)
		{
			if (string.IsNullOrEmpty(strValue))
				return iDefault;
			long iResult;
			if (long.TryParse(strValue, out iResult))
				return iResult;
			return iDefault;
		}
		
		public static float ParseF(string strValue)
		{
			if (string.IsNullOrEmpty(strValue))
				return 0f;
			return float.Parse(strValue);
		}
		
		public static float ParseF_s(string strValue, float fDefault)
		{
			if (string.IsNullOrEmpty(strValue))
				return fDefault;
			float fResult;
			if (float.TryParse(strValue, out fResult))			
				return fResult;
			return fDefault;
		}
		
		public static byte ParseBT(string strValue)
		{
			if (string.IsNullOrEmpty(strValue))
				return 0;
			return byte.Parse(strValue);
		}

        public static sbyte ParseSBT(string strValue)
        {
            if (string.IsNullOrEmpty(strValue))
                return 0;
            return sbyte.Parse(strValue);
        }
		
		public static byte ParseBT_s(string strValue, byte btDefault)
		{
			if (string.IsNullOrEmpty(strValue))
				return btDefault;
			byte btResult;
			if (byte.TryParse(strValue, out btResult))			
				return btResult;
			return btDefault;
		}

        public static byte[] ParseByteArray(string strValue)
        {
            if (string.IsNullOrEmpty(strValue))
                return null;

            return System.Text.Encoding.UTF8.GetBytes(strValue);
        }

		public static bool ParseB(string strValue)
		{
			if (string.IsNullOrEmpty(strValue))
				return false;
			return bool.Parse(strValue);
		}
		
		public static bool ParseB_s(string strValue, bool bDefault)
		{
			if (string.IsNullOrEmpty(strValue))
				return bDefault;
			bool bResult;
			if (bool.TryParse(strValue, out bResult))
			{
				return bResult;
			}
			return bDefault;
		}
		
		public static ushort ParseUS(string strValue)
		{
			if (string.IsNullOrEmpty(strValue))
				return 0;
			return ushort.Parse(strValue);
		}
		
		public static ushort ParseUS_s(string strValue, ushort usDefault)
		{
			if (string.IsNullOrEmpty(strValue))
				return usDefault;
			ushort usResult;
			if (ushort.TryParse(strValue, out usResult))
			{
				return usResult;
			}
			return usDefault;
		}
		
		public static short ParseS(string strValue)
		{
			if (string.IsNullOrEmpty(strValue))
				return 0;
			return short.Parse(strValue);
		}
		
		public static short ParseS_s(string strValue, short sDefault)
		{
			if (string.IsNullOrEmpty(strValue))
				return sDefault;
			short sResult;
			if(short.TryParse(strValue, out sResult))
			{
				return sResult;
			}
			return sDefault;
		}

        public static string Byte2Str(byte[] strData)
        {
            return System.Text.Encoding.UTF8.GetString(strData);
        }

        public static byte[] Str2Byte(string bytesData)
        {
            return System.Text.Encoding.UTF8.GetBytes(bytesData);
        }

        /// <summary>
        /// 解析表中的字符串数组
        /// </summary>
        /// <returns>The array string.</returns>
        /// <param name="arrayString">Array string.</param>
        /// <param name="del">Del.</param>
        /// <param name="exceptHeadAndEndChar">是否排除首尾字符</param>
        public static List<string> ParseArrayString(string arrayString, string del, bool exceptHeadAndEndChar = true)
		{
			List<string> list = new List<string>();
			if (!string.IsNullOrEmpty(arrayString))
			{
                if(exceptHeadAndEndChar)
                {
                    arrayString = arrayString.Substring(1);
                    if(arrayString.Length > 0)
                        arrayString = arrayString.Substring(0, arrayString.Length - 1);
                }
				string[] strs = arrayString.Split(del.ToCharArray());
				if (strs.Length != 0)
				{
					foreach(string str in strs)
					{
						list.Add(str);
					}
				}
			}

			return list;
		}

		/// <summary>
		/// 解析表中的字符串数组，用逗号做分隔符
		/// </summary>
		/// <returns>The array string.</returns>
		/// <param name="arrayString">Array string.</param>
		public static List<string> ParseArrayString(string arrayString)
		{
			return ParseArrayString(arrayString, ",");
		}

		public static List<uint> ParseArrayUint(string arrayString, string del, bool exceptHeadAndEndChar = true)
		{
			List<uint> list = new List<uint>();
            list.Clear();
            if (string.IsNullOrEmpty(arrayString) == false)
			{
                if (exceptHeadAndEndChar)
                {
                    arrayString = arrayString.Substring(1);
                    if (arrayString.Length > 0)
                        arrayString = arrayString.Substring(0, arrayString.Length - 1);
                    else
                        arrayString = "";
                }
                if (arrayString.Length > 0)
                {
                    //arrayString = arrayString.Substring(0, arrayString.Length - 1);
                    if (string.IsNullOrEmpty(arrayString) == false)
                    {
                        string[] strs = arrayString.Split(del.ToCharArray());
                        if (strs.Length != 0)
                        {
                            foreach (string str in strs)
                            {
                                list.Add(ParseUI_s(str, 0));
                            }
                        }
                    }
                }
            }
			
			return list;
		}

        public static List<long> ParseArrayLong(string arrayString, string del)
        {
            List<long> list = new List<long>();
            list.Clear();
            if (string.IsNullOrEmpty(arrayString) == false)
            {
                arrayString = arrayString.Substring(1);
                if (arrayString.Length > 0)
                {
                    arrayString = arrayString.Substring(0, arrayString.Length - 1);
                    if (string.IsNullOrEmpty(arrayString) == false)
                    {
                        string[] strs = arrayString.Split(del.ToCharArray());
                        if (strs.Length != 0)
                        {
                            foreach (string str in strs)
                            {
                                list.Add(ParseL_s(str, 0));
                            }
                        }
                    }
                }
            }

            return list;
        }

        public static List<byte> ParseArrayByte(string arrayString, string del)
        {
            List<byte> list = new List<byte>();
            list.Clear();
            if (string.IsNullOrEmpty(arrayString) == false)
            {
                arrayString = arrayString.Substring(1);
                arrayString = arrayString.Substring(0, arrayString.Length - 1);
                string[] strs = arrayString.Split(del.ToCharArray());
                if (strs.Length != 0)
                {
                    foreach (string str in strs)
                    {
                        list.Add(ParseBT_s(str, 0));
                    }
                }
            }

            return list;
        }

        public static List<uint> ParseArrayUint(string arrayString)
		{
			return ParseArrayUint(arrayString, ";");
		}

		public static List<Vector2> ParseArrayVector2(string arrayString)
		{
			List<Vector2> retVector2s = new List<Vector2>();

            var strList = ParseArrayStringStringPool(arrayString, true);

            foreach (List<string> posStrings in strList)
			{
				Vector2 pos = new Vector2(ParseI_s(posStrings[0], 0), ParseI_s(posStrings[1], 0));
				retVector2s.Add(pos);
			}

            FreeDualList(strList);

            return retVector2s;
		}

        public static List<Vector3> ParseArrayVector3(string arrayString)
        {
            List<Vector3> retVector3s = new List<Vector3>();

            var strList = ParseArrayStringStringPool(arrayString, true);
            foreach (List<string> posStrings in strList)
            {
                Vector3 pos = new Vector3(ParseI_s(posStrings[0], 0), ParseI_s(posStrings[1], 0), ParseI_s(posStrings[2], 0));
                retVector3s.Add(pos);
            }

            FreeDualList(strList);
            return retVector3s;
        }

        public static List<Vector4> ParseArrayVector4(string arrayString)
        {
            List<Vector4> ret = new List<Vector4>();

            var strList = ParseArrayStringStringPool(arrayString, true);
            foreach (List<string> posStrings in strList)
            {
                Vector4 pos = new Vector4(ParseI_s(posStrings[0], 0), ParseI_s(posStrings[1], 0), ParseI_s(posStrings[2], 0), ParseI_s(posStrings[3], 0));
                ret.Add(pos);
            }
            FreeDualList(strList);

            return ret;
        }

        public static Vector2 ParseVector2(string str)
		{
			Vector2 vec = Vector2.zero;
			List<string> posStrings = ParseArrayString(str);
			if (posStrings.Count == 0)
			{
				return vec;
			}
			else if (posStrings.Count == 1)
			{
				vec.x = ParseF_s(posStrings[0], 0f);
			}
			else
			{
				vec.x = ParseF_s(posStrings[0], 0f);
				vec.y = ParseF_s(posStrings[1], 0f);
			}

			return vec;
		}

        public static Vector3 ParseVector3(string str)
        {
            Vector3 vec = Vector3.zero;
            List<string> posStrings = ParseArrayString(str);
            if (posStrings.Count == 0)
            {
                return vec;
            }
            else if (posStrings.Count == 1)
            {
                vec.x = ParseF_s(posStrings[0], 0f);
            }
            else if (posStrings.Count == 2)
            {
                vec.x = ParseF_s(posStrings[0], 0f);
                vec.y = ParseF_s(posStrings[1], 0f);
            }
            else
            {
                vec.x = ParseF_s(posStrings[0], 0f);
                vec.y = ParseF_s(posStrings[1], 0f);
                vec.z = ParseF_s(posStrings[2], 0f);
            }

            return vec;
        }

        public static Vector4 ParseVector4(string str)
        {
            Vector4 vec = Vector4.zero;
            List<string> posStrings = ParseArrayString(str);
            if (posStrings.Count == 0)
            {
                return vec;
            }
            else if (posStrings.Count == 1)
            {
                vec.x = ParseF_s(posStrings[0], 0f);
            }
            else if (posStrings.Count == 2)
            {
                vec.x = ParseF_s(posStrings[0], 0f);
                vec.y = ParseF_s(posStrings[1], 0f);
            }
            else if (posStrings.Count == 3)
            {
                vec.x = ParseF_s(posStrings[0], 0f);
                vec.y = ParseF_s(posStrings[1], 0f);
                vec.z = ParseF_s(posStrings[2], 0f);
            }
            else
            {
                vec.x = ParseF_s(posStrings[0], 0f);
                vec.y = ParseF_s(posStrings[1], 0f);
                vec.z = ParseF_s(posStrings[2], 0f);
                vec.w = ParseF_s(posStrings[3], 0f);
            }

            return vec;
        }

        public static Rect ParseRect(string str)
		{
			Rect rect = new Rect(0f, 0f, 0f, 0f);
			List<string> rectStrings = ParseArrayString(str);
			int rectStringsCount = rectStrings.Count;
			if (rectStringsCount == 0)
			{
			}
			else if (rectStringsCount == 1)
			{
				rect.x = ParseF_s(rectStrings[0], 0f);
			}
			else if (rectStringsCount == 2)
			{
				rect.x = ParseF_s(rectStrings[0], 0f);
				rect.y = ParseF_s(rectStrings[1], 0f);
			}
			else if (rectStringsCount == 3)
			{
				rect.x = ParseF_s(rectStrings[0], 0f);
				rect.y = ParseF_s(rectStrings[1], 0f);
				rect.width = ParseF_s(rectStrings[2], 0f);
			}
			else
			{
				rect.x = ParseF_s(rectStrings[0], 0f);
				rect.y = ParseF_s(rectStrings[1], 0f);
				rect.width = ParseF_s(rectStrings[2], 0f);
				rect.height = ParseF_s(rectStrings[3], 0f);
			}

			return rect;
		}

        public static List<List<string>> ParseArrayStringString(string str)
        {
            return ParseArrayStringStringPool(str, false);
        }

        public static void FreeDualList(List<List<string>> dual_list)
        {
            if (dual_list == null)
                return;

            foreach(var list in dual_list)
            {
                SGameEngine.Pool<string>.List.Free(list);
            }
            SGameEngine.Pool<List<string>>.List.Free(dual_list);
        }

        /// <summary>
        /// 解析“[{a,b},{c,d,e},...]”这种类型的字符串，返回一个string二维数组
        /// </summary>
        /// <returns>The array string string.</returns>
        /// <param name="str">String.</param>
        public static List<List<string>> ParseArrayStringStringPool(string str, bool usePool)
		{
			var strStrList = usePool ? SGameEngine.Pool<List<string>>.List.New() : new List<List<string>>();

            if (!string.IsNullOrEmpty(str) && str.Length >= 2)
			{
                bool brace_start = false;
                List<string> brace_content = null;
                StringBuilder char_content = null;
                bool start = false;
                for (int i = 0; i < str.Length; ++i)
                {
                    char c = str[i];

                    if (c == '[')
                    {
                        start = true;
                        continue;
                    }
                    else if (c == ']')
                    {
                        break;
                    }
                    else if (c == '{')
                    {
                        if (brace_start)
                        {
                            GameDebug.LogError("ParseArrayStringString error, duplication brace.");
                            break;
                        }
                        else
                        {
                            brace_start = true;
                            brace_content = usePool ? SGameEngine.Pool<string>.List.New() : new List<string>();
                            char_content = new StringBuilder(5);
                            strStrList.Add(brace_content);
                        }
                    }
                    else if(c == '}')
                    {
                        if (brace_start)
                        {
                            brace_start = false;

                            if (brace_content != null)
                            {
                                if(char_content != null)
                                {
                                    var content_str = char_content.ToString();
                                    char_content = null;
                                    brace_content.Add(content_str);
                                    brace_content = null;
                                }
                                else
                                {
                                    GameDebug.LogError("ParseArrayStringString error, char_content is null.");
                                    break;
                                }
                            }
                        }
                        else
                        {
                            GameDebug.LogError("ParseArrayStringString error, brace_start state is invalid.");
                            break;
                        }
                    }
                    else if (c == ',')
                    {
                        if (brace_content != null)
                        {
                            if(char_content != null)
                            {
                                var content_str = char_content.ToString();
                                brace_content.Add(content_str);
                                char_content = new StringBuilder(10);
                            }
                            else
                            {
                                GameDebug.LogError("ParseArrayStringString error, char_content is null.");
                                break;
                            }
                        }
                    }
                    else
                    {
                        if(start == false)
                        {
                            GameDebug.LogError("ParseArrayStringString error, has same char before start.");
                            continue;
                        }
                        else if (brace_start)
                        {
                            if(char_content != null)
                                char_content.Append(c);
                            else
                            {
                                GameDebug.LogError("ParseArrayStringString error, char_content is null.");
                                break;
                            }
                        }
                    }
                }
			}

			return strStrList;
		}

        public static List<List<uint>> ParseArrayUintUint(string str)
        {
            var uintUintList = new List<List<uint>>();

            if (!string.IsNullOrEmpty(str) && str.Length >= 2)
            {
                bool brace_start = false;
                List<uint> brace_content = null;
                StringBuilder char_content = null;
                bool start = false;
                for (int i = 0; i < str.Length; ++i)
                {
                    char c = str[i];

                    if (c == '[')
                    {
                        start = true;
                        continue;
                    }
                    else if (c == ']')
                    {
                        break;
                    }
                    else if (c == '{')
                    {
                        if (brace_start)
                        {
                            GameDebug.LogError("ParseArrayStringString error, duplication brace.");
                            break;
                        }
                        else
                        {
                            brace_start = true;
                            brace_content = new List<uint>();
                            char_content = new StringBuilder(5);
                            uintUintList.Add(brace_content);
                        }
                    }
                    else if (c == '}')
                    {
                        if (brace_start)
                        {
                            brace_start = false;

                            if (brace_content != null)
                            {
                                if (char_content != null)
                                {
                                    var content_str = char_content.ToString();
                                    char_content = null;
                                    brace_content.Add(ParseUI_s(content_str, 0));
                                    brace_content = null;
                                }
                                else
                                {
                                    GameDebug.LogError("ParseArrayStringString error, char_content is null.");
                                    break;
                                }
                            }
                        }
                        else
                        {
                            GameDebug.LogError("ParseArrayStringString error, brace_start state is invalid.");
                            break;
                        }
                    }
                    else if (c == ',')
                    {
                        if (brace_content != null)
                        {
                            if (char_content != null)
                            {
                                var content_str = char_content.ToString();
                                brace_content.Add(ParseUI_s(content_str, 0));
                                char_content = new StringBuilder(10);
                            }
                            else
                            {
                                GameDebug.LogError("ParseArrayStringString error, char_content is null.");
                                break;
                            }
                        }
                    }
                    else
                    {
                        if (start == false)
                        {
                            GameDebug.LogError("ParseArrayStringString error, has same char before start.");
                            continue;
                        }
                        else if (brace_start)
                        {
                            if (char_content != null)
                                char_content.Append(c);
                            else
                            {
                                GameDebug.LogError("ParseArrayStringString error, char_content is null.");
                                break;
                            }
                        }
                    }
                }
            }

            return uintUintList;
        }

        public static List<KeyValuePair<uint, uint>> ParseArrayKeyValuePairUintUint(string str)
        {
            List<KeyValuePair<uint, uint>> uintUintList = new List<KeyValuePair<uint, uint>>();

            var strStrList = ParseArrayStringStringPool(str, true);
            foreach (List<string> strList in strStrList)
            {
                if (strList.Count >= 2)
                {
                    KeyValuePair<uint, uint> uintUint = new KeyValuePair<uint, uint>(ParseUI_s(strList[0], 0), ParseUI_s(strList[1], 0));
                    uintUintList.Add(uintUint);
                }
            }

            FreeDualList(strStrList);

            return uintUintList;
        }

        public static List<uint> ParseUintListByBrace(string raw)
        {
            string[] splits = raw.Split('{', '}', ',');
            uint v;
            List<uint> lst = new List<uint>();
            foreach (string s in splits)
            {
                if (uint.TryParse(s, out v))
                {
                    lst.Add(v);
                }
            }
            return lst;
        }

        public static Dictionary<uint, uint> ParseDictionaryUintUint(string str)
        {
            Dictionary<uint, uint> uintUintDict = new Dictionary<uint, uint>();
            uintUintDict.Clear();

            if (string.IsNullOrEmpty(str) == false)
            {
                var strStrList = ParseArrayStringStringPool(str, true);
                foreach (List<string> strList in strStrList)
                {
                    if (strList.Count >= 2)
                    {
                        uintUintDict.Add(ParseUI_s(strList[0], 0), ParseUI_s(strList[1], 0));
                    }
                }
                FreeDualList(strStrList);
            }

            return uintUintDict;
        }

        public class DBGoodsItem
        {
            public uint goods_id;
            public uint goods_num;
        }
        public class DBAttrItem
        {
            public uint attr_id;
            public uint attr_num;
        }

        /// <summary>
        /// 解析物品列表
        /// </summary>
        /// <param name="raw"></param>
        /// <returns></returns>
        public static List<DBGoodsItem> ParseDBGoodsItem(string raw)
        {
            List < DBGoodsItem > goods_item_array = new List<DBGoodsItem>();
            raw = raw.Replace(" ", "");
            var matchs = System.Text.RegularExpressions.Regex.Matches(raw, @"\{(\d+),(\d+)\}");
            foreach (System.Text.RegularExpressions.Match _match in matchs)
            {
                if (_match.Success)
                {
                    uint goodsId = (DBTextResource.ParseUI(_match.Groups[1].Value));
                    uint num = DBTextResource.ParseUI(_match.Groups[2].Value);
                    DBGoodsItem goods = new DBGoodsItem();
                    goods.goods_id = goodsId;
                    goods.goods_num = num;
                    goods_item_array.Add(goods);
                }
            }
            return goods_item_array;
        }
        public static List<DBAttrItem> ParseDBAttrItems(string raw)
        {
            List<DBAttrItem> item_array = new List<DBAttrItem>();
            List<List<uint>> uint_uint_array = DBTextResource.ParseArrayUintUint(raw);
            for (int index = 0; index < uint_uint_array.Count; ++index)
            {
                if (uint_uint_array[index].Count >= 2)
                {
                    DBAttrItem item = new DBAttrItem();
                    item.attr_id = uint_uint_array[index][0];
                    item.attr_num = uint_uint_array[index][1];
                    item_array.Add(item);
                }
            }
            return item_array;
        }

        public static string GetStringArrayUint(List<uint> uint_array, string del, string prefix_str, string suffix_str)
        {
            System.Text.StringBuilder builder = new System.Text.StringBuilder();
            builder.Append(prefix_str);
            bool is_first_uint = true;
            for(int index = 0; index < uint_array.Count; ++index)
            {
                if (is_first_uint)
                {
                    builder.AppendFormat("{0}", uint_array[index]);
                    is_first_uint = false;
                }
                else
                    builder.AppendFormat("{1}{0}", uint_array[index], del);
            }
            builder.Append(suffix_str);
            return builder.ToString();
        }

        public static List<KeyValuePair<uint, uint>> ParseKeyValuePairList(string str)
        {
            List<KeyValuePair<uint, uint>> ret = new List<KeyValuePair<uint, uint>>();
            ret.Clear();

            str = str.Replace(" ", "");
            var matchs = System.Text.RegularExpressions.Regex.Matches(str, @"\{(\d+),(\d+)\}");
            foreach (System.Text.RegularExpressions.Match _match in matchs)
            {
                if (_match.Success)
                {
                    uint goodsId = (DBTextResource.ParseUI(_match.Groups[1].Value));
                    uint num = DBTextResource.ParseUI(_match.Groups[2].Value);

                    ret.Add(new KeyValuePair<uint, uint>(goodsId, num));
                }
            }

            return ret;
        }

        public static List<KeyValuePair<uint, ulong>> ParseKeyUlongValuePairList(string str)
        {
            List<KeyValuePair<uint, ulong>> ret = new List<KeyValuePair<uint, ulong>>();
            ret.Clear();

            str = str.Replace(" ", "");
            var matchs = System.Text.RegularExpressions.Regex.Matches(str, @"\{(\d+),(\d+)\}");
            foreach (System.Text.RegularExpressions.Match _match in matchs)
            {
                if (_match.Success)
                {
                    uint goodsId = (DBTextResource.ParseUI(_match.Groups[1].Value));
                    ulong num = DBTextResource.ParseUL(_match.Groups[2].Value);

                    ret.Add(new KeyValuePair<uint, ulong>(goodsId, num));
                }
            }

            return ret;
        }

        public static List<uint> ParseArrayUintAndUint(string arrayString, string del)
        {
            List<uint> list = null;
            if (arrayString.Contains("["))
            {
                list = DBTextResource.ParseArrayUint(arrayString, del);
            }
            else
            {
                list = new List<uint>();
                uint value = DBTextResource.ParseUI(arrayString);
                list.Add(value);
            }
            return list;
        }


    }
	
	public class CFGTextResource : DBTextResource
	{
		public CFGTextResource(string strName, string strPath) : base(strName, strPath)
		{			
		}
		
		public void SetPath(string strPath)
		{
			mStrPath = strPath;
		}
		
		public override void Load()
		{
			string path = PathHelp.GetFullPaltformPath(mStrPath, false);
			
			if (System.IO.File.Exists(path))
			{
				System.IO.FileStream stream = new System.IO.FileStream(path, System.IO.FileMode.Open);
				if (stream != null)
				{						
					byte[] content = new byte[stream.Length];
					stream.Read(content, 0, (int)stream.Length);
					
					IsLoaded = true;
					
					string strData = CommonTool.BytesToUtf8(content);
					ParseData(strData);
					stream.Close();
				}
			}
		}
		
		public virtual void Save()
		{
			
		}
	}
}
