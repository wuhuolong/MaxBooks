using System;
using UnityEngine;

namespace Utils
{
	public class PathHelp
	{
		private static int ResPathLen = "resources".get_Length();

		public static string ConfirmAssetName(string name)
		{
			name = name.Trim().ToLower();
			bool flag = name.get_Chars(0) != '/';
			if (flag)
			{
				name = string.Format("/{0}", name);
			}
			return name;
		}

		public static string ReplaceAssetExt(string path)
		{
			int num = path.LastIndexOf(".");
			bool flag = num < 0;
			string result;
			if (flag)
			{
				result = path;
			}
			else
			{
				string text = path.Substring(0, num);
				string text2 = string.Format("{0}.asset", text);
				result = text2;
			}
			return result;
		}

		public static string GetPaltformDir()
		{
			bool flag = Application.get_platform() == 11 || Application.get_platform() == 8;
			string result;
			if (flag)
			{
				result = Application.get_persistentDataPath();
			}
			else
			{
				bool flag2 = Application.get_platform() == 2;
				if (flag2)
				{
					result = Application.get_dataPath();
				}
				else
				{
					int num = Application.get_dataPath().LastIndexOf('/');
					bool flag3 = num < 0;
					if (flag3)
					{
						result = Application.get_dataPath();
					}
					else
					{
						result = Application.get_dataPath().Substring(0, num);
					}
				}
			}
			return result;
		}

		public static string GetPackageDir()
		{
			bool flag = !Application.get_isEditor();
			string result;
			if (flag)
			{
				bool flag2 = Application.get_platform() == 11;
				if (flag2)
				{
					result = "/package/android";
				}
				else
				{
					bool flag3 = Application.get_platform() == 8;
					if (flag3)
					{
						result = "/package/ios";
					}
					else
					{
						Debug.LogError("No Support Platform for Package");
						result = "";
					}
				}
			}
			else
			{
				bool flag4 = Application.get_platform() == 7;
				if (flag4)
				{
					result = "/package/win32";
				}
				else
				{
					bool flag5 = Application.get_platform() == 0;
					if (flag5)
					{
						result = "/package/ios";
					}
					else
					{
						Debug.LogError("No Support Editor Platform for Package");
						result = "";
					}
				}
			}
			return result;
		}

		public static string GetFullPaltformPath(string filename, bool filePrefix)
		{
			filename = filename.Trim().ToLower();
			string text = "";
			if (filePrefix)
			{
				text = "file://";
			}
			bool flag = filename.get_Chars(0) != '/';
			string result;
			if (flag)
			{
				result = string.Format("{0}{1}/{2}", text, PathHelp.GetPaltformDir(), filename);
			}
			else
			{
				result = string.Format("{0}{1}{2}", text, PathHelp.GetPaltformDir(), filename);
			}
			return result;
		}

		public static string GetFullPackagePath(string resFile, bool filePrefix, bool replaceExt)
		{
			resFile = resFile.Trim().ToLower();
			if (replaceExt)
			{
				resFile = PathHelp.ReplaceAssetExt(resFile);
			}
			string text = "";
			if (filePrefix)
			{
				text = "file://";
			}
			bool flag = resFile.get_Length() <= 0 || resFile.get_Chars(0) == '/';
			string result;
			if (flag)
			{
				result = string.Format("{0}{1}{2}{3}", new object[]
				{
					text,
					PathHelp.GetPaltformDir(),
					PathHelp.GetPackageDir(),
					resFile
				});
			}
			else
			{
				result = string.Format("{0}{1}{2}/{3}", new object[]
				{
					text,
					PathHelp.GetPaltformDir(),
					PathHelp.GetPackageDir(),
					resFile
				});
			}
			return result;
		}

		public static string GetPathWithNoExtend(string path)
		{
			int num = path.LastIndexOf(".");
			bool flag = num < 0;
			string result;
			if (flag)
			{
				result = path;
			}
			else
			{
				string text = path.Substring(0, num);
				result = text;
			}
			return result;
		}

		public static string GetBundleName(string resName)
		{
			bool flag = resName.get_Length() <= 0;
			string result;
			if (flag)
			{
				result = "";
			}
			else
			{
				string text = resName.Trim().ToLower();
				bool flag2 = text.get_Chars(0) != '/';
				if (flag2)
				{
					bool flag3 = !PathHelp.ContainResPath(text);
					if (flag3)
					{
						text = string.Format("/resources/{0}", text);
					}
					else
					{
						text = string.Format("/{0}", text);
					}
				}
				else
				{
					bool flag4 = !PathHelp.ContainResPath(text);
					if (flag4)
					{
						text = string.Format("/resources{0}", text);
					}
				}
				result = text;
			}
			return result;
		}

		public static string GetResourceName(string bundleName)
		{
			bool flag = bundleName.get_Length() <= 0;
			string result;
			if (flag)
			{
				result = "";
			}
			else
			{
				string text = bundleName.Trim().ToLower();
				bool flag2 = text.get_Chars(0) != '/';
				if (flag2)
				{
					bool flag3 = PathHelp.ContainResPath(text);
					if (flag3)
					{
						text = text.Substring(PathHelp.ResPathLen + 1);
					}
				}
				else
				{
					bool flag4 = PathHelp.ContainResPath(text);
					if (flag4)
					{
						text = text.Substring(PathHelp.ResPathLen + 2);
					}
					else
					{
						text = text.Substring(1);
					}
				}
				result = PathHelp.GetPathWithNoExtend(text);
			}
			return result;
		}

		private static bool ContainResPath(string name)
		{
			bool flag = name.get_Chars(0) == '/';
			string text;
			int length;
			if (flag)
			{
				text = "/resources";
				length = text.get_Length();
			}
			else
			{
				text = "resources";
				length = text.get_Length();
			}
			bool flag2 = name.get_Length() < length;
			bool result;
			if (flag2)
			{
				result = false;
			}
			else
			{
				int num;
				for (int i = 0; i < length; i = num)
				{
					bool flag3 = name.get_Chars(i) != text.get_Chars(i);
					if (flag3)
					{
						result = false;
						return result;
					}
					num = i + 1;
				}
				result = true;
			}
			return result;
		}

		public static string GetSetupPackName(string ver)
		{
			bool flag = Application.get_platform() == 11;
			string text;
			if (flag)
			{
				text = ".apk";
			}
			else
			{
				bool flag2 = Application.get_platform() == 8;
				if (flag2)
				{
					text = ".ida";
				}
				else
				{
					text = ".exe";
				}
			}
			return "setup_" + ver + text;
		}
	}
}
