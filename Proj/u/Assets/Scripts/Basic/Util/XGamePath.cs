using System.Collections;
using System.Text;
using System.IO;
using UnityEngine;

public static class XGamePath
{
    private static StringBuilder sb = new StringBuilder();
    public static string ResRoot = "FakeResources";

    public static string Output = "AssetBundle";
    public static string OutputPath = string.Format("{0}/../{1}/", Application.dataPath, "AssetBundle");
    //private static string AssetPath = "Asset";
    //private static string LevelJsonConfig = "FakeResources/Data/LevelConfig/LevelMapConfig.json";//LevelMapConfig

    private static string Transfer2Ab(string path)
    {
        sb.Clear();
        sb = sb.Replace("/", "_");
        sb = sb.Replace(".", "_");
        sb.Append(".xxx");
        path = sb.ToString().ToLower();
        return path;
    }

    public static string GetBinPath(string filename)
    {
#if UNITY_EDITOR
        if (AbMgr.IsAbMode)
        {
            return string.Format("{0}/{1}/{2}/{3}.bin", Application.streamingAssetsPath, Output, "bin", filename);
        }
        else
        {
            return string.Format("{0}/Data/DataConfig/{1}.bin", Application.dataPath, filename);
        }
#elif UNITY_IOS || UNITY_IPHONE
            return string.Format("{0}/{1}/{2}/{3}.bin", Application.streamingAssetsPath, Output, "bin", filename);
#elif UNITY_ANDROID
            return string.Format("{0}/{1}/{2}/{3}.bin", Application.streamingAssetsPath, Output, "bin", filename);
#else
            return string.Format("{0}/{1}/{2}/{3}.bin", Application.streamingAssetsPath, Output, "bin", filename);
#endif
    }
    /// <summary>
    /// 图集路径，返回fakeres后的相对路径
    /// </summary>
    /// <param name="filename"></param>
    /// <returns></returns>
    public static string GetAtlasPath(string filename)
    {
#if UNITY_EDITOR
        if (AbMgr.IsAbMode)
        {
            return "Atlas/" + filename + ".Prefab";
        }
        else
        {
            return "Atlas/" + filename + ".Prefab";
        }
#else
        return "Atlas/" + filename + ".Prefab";
#endif
    }
    public static string SavePath(string filename)
    {
#if UNITY_EDITOR ||UNITY_EDITOR_OSX ||UNITY_EDITOR_WIN ||UNITY_EDITOR_LINUX
        //Debug.LogError(Application.dataPath + filename);
        return string.Format("{0}/{1}",Application.streamingAssetsPath , filename);
#elif UNITY_IOS || UNITY_IPHONE
        return string.Format("{0}/{1}",Application.persistentDataPath , filename);
#elif UNITY_ANDROID &&!UNITY_EDITOR
        return string.Format("{0}/{1}",Application.persistentDataPath , filename);
#else
        return string.Format("{0}/{1}",Application.streamingAssetsPath , filename);
#endif
    }

    public static string GetLevelDataJsonPath(string filename)
    {
#if UNITY_EDITOR
        if (AbMgr.IsAbMode)
        {
            return string.Format("{0}/{1}/bin/{2}.json", Application.streamingAssetsPath ,Output , filename);
        }
        else
        {
            return string.Format("{0}/Data/LevelConfig/{1}.json",Application.dataPath, filename);
        }
#elif UNITY_IOS || UNITY_IPHONE
            return string.Format("{0}/{1}/bin/{2}.json", Application.streamingAssetsPath, Output, filename);
#elif UNITY_ANDROID
            return string.Format("{0}/{1}/bin/{2}.json", Application.streamingAssetsPath, Output, filename);
#else
            return string.Format("{0}/{1}/bin/{2}.json", Application.streamingAssetsPath, Output, filename);
#endif
    }

    //*******************
    /// <summary>
    /// 把相对路径转化成ab文件名,用于fakeres下
    /// </summary>
    /// <param name="path"></param>
    /// <returns></returns>
    public static string Path2ResName(string path)
    {
        sb.Clear();
        sb.Append(ResRoot + "/" + path);
        sb = sb.Replace("/", "_");
        sb = sb.Replace(".", "_");
        sb.Append(".xxx");
        path = sb.ToString().ToLower();
        return path;
    }
    public static string GetStreamingAbPath(string path)
    {
        string fullpath = Application.streamingAssetsPath + "/" + Output + "/" + path;
        return fullpath;
    }
    public static string GetResRoot()
    {
        return Application.dataPath + "/" + ResRoot;
    }
}
