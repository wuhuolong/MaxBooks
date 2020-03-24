using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Utils
{
	public class PathHelp
	{
		public static string ConfirmAssetName(string name)
		{
			name = name.Trim().ToLower();
			if (name [0] != '/')
				name = string.Format("/{0}", name);
			return name;
		}
		
		// 后缀换成.asset
		static public string ReplaceAssetExt(string path)
		{
			string fileOri = path;
			int idx = fileOri.LastIndexOf(".");
			if (idx < 0)
			{
				return path;
			}
			else
			{
				string noExtend = fileOri.Substring(0, idx);
				string file = string.Format("{0}.asset", noExtend);
				return file;
			}
		}
		
		/// <summary>
		/// 返回平台数据储存目录
		/// </summary>
		/// <returns>The paltform dir.</returns>
		public static string GetPaltformDir()
		{ 
			string dir = "";
			if (Application.platform == RuntimePlatform.Android ||
			    Application.platform == RuntimePlatform.IPhonePlayer)
			{
				dir = Application.persistentDataPath;
			}
			else if (Application.platform == RuntimePlatform.WindowsPlayer)
			{
				dir = Application.dataPath;
			}
			else// 编辑器下为工程目录
			{
				int len = Application.dataPath.LastIndexOf('/');
				if (len < 0)
					dir = Application.dataPath;
				else
				{
					dir = Application.dataPath.Substring(0, len);
				}
			}
			return dir;
		}
		
		/// <summary>
		/// 返回Package的目录，Sample: /package/android
		/// </summary>
		/// <returns>The package dir.</returns>
		static public string GetPackageDir()
		{
			string dir = "";
			if (!Application.isEditor)
			{
				if (Application.platform == RuntimePlatform.Android)
					dir = "/package/android";
				else if (Application.platform == RuntimePlatform.IPhonePlayer)
					dir = "/package/ios";
				else
				{
					Debug.LogError("No Support Platform for Package");
					dir = "";
				}
			}
			else
			{
				if (Application.platform == RuntimePlatform.WindowsEditor)
					dir = "/package/win32";
				else if (Application.platform == RuntimePlatform.OSXEditor)
					dir = "/package/ios";
				else
				{
					Debug.LogError("No Support Editor Platform for Package");
					dir = "";
				}
			}
			
			return dir;
		}
		
		/// <summary>
		/// 返回平台数据储存路径
		/// </summary>
		/// <returns>The full paltform path.</returns>
		/// <param name="filename">Filename.</param>
		/// <param name="filePrefix">If set to <c>true</c> file prefix.</param>
		public static string GetFullPaltformPath(string filename, bool filePrefix)
		{
			filename = filename.Trim().ToLower();
			string prefix = "";
			if (filePrefix)
				prefix = "file://";
			
			if (filename [0] != '/')
				return string.Format("{0}{1}/{2}", prefix, GetPaltformDir(), filename);
			else
				return string.Format("{0}{1}{2}", prefix, GetPaltformDir(), filename);
		}
		
		/// <summary>
		/// <para> 返回完整Package路径 </para>
		/// <para> Sample: d:/projx2/package/android/resources/.../res.asset </para>
		/// <para> 传入参数格式: /resources/...</para>
		/// </summary>
		/// <returns>The full package path.</returns>
		/// <param name="resFile">路径格式: /resources/...</param>
		static public string GetFullPackagePath(string resFile, bool filePrefix, bool replaceExt)
		{
			resFile = resFile.Trim().ToLower();
			if (replaceExt)
				resFile = PathHelp.ReplaceAssetExt(resFile);
			
			string prefix = "";
			if (filePrefix)
				prefix = "file://";
			
			string fullPackagePath;
			if (resFile.Length <= 0 || resFile [0] == '/')
				fullPackagePath = string.Format("{0}{1}{2}{3}", prefix, GetPaltformDir(), GetPackageDir(), resFile);
			else
				fullPackagePath = string.Format("{0}{1}{2}/{3}", prefix, GetPaltformDir(), GetPackageDir(), resFile);
			
			return fullPackagePath;
		}
		
		public static string GetPathWithNoExtend(string path)
		{
			int idx = path.LastIndexOf(".");
			if (idx < 0)
				return path;
			string noext = path.Substring(0, idx);
			return noext;
		}
		
		public static string GetBundleName(string resName)
		{
			if(resName.Length <=0 )
				return "";
			
			string bundleName = resName.Trim().ToLower();
			if (bundleName [0] != '/') 
			{
				if(!ContainResPath(bundleName))
					bundleName = string.Format("/resources/{0}", bundleName);
				else
					bundleName = string.Format("/{0}", bundleName);
			}
			else
			{
				if(!ContainResPath(bundleName))
					bundleName = string.Format("/resources{0}", bundleName);
			}
			return bundleName;
		}
		
		public static string GetResourceName(string bundleName)
		{
			if(bundleName.Length <=0 )
				return "";
			
			string resName = bundleName.Trim().ToLower();
			if (resName [0] != '/')
			{
				if(ContainResPath(resName))
					resName = resName.Substring(ResPathLen+1);
			}
			else
			{
				if(ContainResPath(resName))
					resName = resName.Substring(ResPathLen+2);
				else
					resName = resName.Substring(1);
			}
			return GetPathWithNoExtend(resName);
		}
		
		static int ResPathLen = "resources".Length;
		static bool ContainResPath(string name)
		{
			string resPath;
			int resPathLen;
			if(name[0] == '/')
			{
				resPath = "/resources";
				resPathLen = resPath.Length;
			}
			else
			{
				resPath = "resources";
				resPathLen = resPath.Length;
			}
			
			if(name.Length < resPathLen)
				return false;
			else
			{
				for(int i=0; i< resPathLen; ++i)
				{
					if(name[i] != resPath[i])
						return false;
				}
				return true;
			}
		}
		
		public static string GetSetupPackName(string ver)
		{
			string ext = "";
			if (Application.platform == RuntimePlatform.Android)
				ext = ".apk";
			else if (Application.platform == RuntimePlatform.IPhonePlayer)
				ext = ".ida";
			else
				ext = ".exe";
			
			return "setup_" + ver + ext;
		}
	}
}