using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.Security.Cryptography;
using UnityEngine;
using xc;

namespace wxb
{
    public class HotLoader
    {
        static byte[] mBytes = null;
        public static byte[] DllBytes
        {
            get
            {
                return mBytes;
            }
        }

        static MD5 md5Hash = MD5.Create();

        //md5 utils
        public static string GetMD5(string _s)
        {
            byte[] data = md5Hash.ComputeHash(Encoding.UTF8.GetBytes(_s));
            StringBuilder sBuilder = new StringBuilder();
            for (int i = 0; i < data.Length; i++)
            {
                sBuilder.Append(data[i].ToString("x2"));
            }
            return sBuilder.ToString();
        }

        public static string GetBundleURL(string assetPath)
        {
            var bundleName = GetMD5(assetPath);
            return String.Format("{0}/{1}.unity3d", Const.BUNDLE_FILE_FOLDER_DISK, bundleName);
        }

        public static IEnumerator LoadDll()
        {
            var assetPath = "Assets/Res/DB/Common/hotdll.bytes";
            UnityEngine.Object loadedAsset = null;
#if UNITY_EDITOR
            loadedAsset = EditorResourceLoader.LoadAssetAtPath(assetPath, typeof(TextAsset));
            if (loadedAsset == null)
            {
                Debug.LogError(string.Format("asset counld not be loaded {0},check xls or your project", assetPath));
                yield break;
            }
#else
            var bundle_url = GetBundleURL(assetPath);
            bundle_url = CommonTool.WipeFileSprit(bundle_url);

            var requeset = AssetBundle.LoadFromFileAsync(bundle_url);
            yield return requeset;

            var bundle = requeset.assetBundle;
            if (bundle == null)
			{
				Debug.LogError( string.Format("[ResourceLoader](load_bundle_from_disk_coroutine)load bundle rfrom www failed, unity3d file is in valid, bundle path is {0} device is {1}", bundle_url, SystemInfo.deviceModel) );
				yield break;
			}

            loadedAsset = bundle.LoadAsset("1", typeof(TextAsset));
            bundle.Unload(false);
#endif
            var textAsset = loadedAsset as TextAsset;
            mBytes = textAsset.bytes;
            Resources.UnloadAsset(textAsset);
        }

        public static void ReleaseBytes()
        {
            mBytes = null;
        }
    }
}
