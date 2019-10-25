using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEditor;
using UnityEngine;

public class AssetInfo
{
    public string Path;
    //public bool isAssetBundle;

    public static void SetTag(AssetInfo asset)
    {
        string path = asset.Path.Substring(asset.Path.LastIndexOf("Assets"));
        AssetImporter importer = AssetImporter.GetAtPath(path);
        if (path.Contains("FakeResources"))
        {
            path = asset.Path.Substring(asset.Path.LastIndexOf("FakeResources"));
        }
        else
        {
            Debug.Log("OutSideFake==>");
        }
        path = path.Replace("/", "_");
        path = path.Replace(".", "_");
        Debug.Log("SetTag==>" + path);
        importer.assetBundleName = path;
        importer.assetBundleVariant = AssetCollector.Variant;
    }
    public static void ClearTag(AssetInfo asset)
    {
        string path = asset.Path.Substring(asset.Path.LastIndexOf("Assets"));
        AssetImporter importer = AssetImporter.GetAtPath(path);
        if (path.Contains("FakeResources"))
        {
            path = asset.Path.Substring(asset.Path.LastIndexOf("FakeResources"));
        }
        else
        {
            Debug.Log("SetTag==>" + path);
        }
        importer.assetBundleName = "";
        importer.assetBundleVariant = "";
    }
}
public static class AssetCollector
{
    public static List<string> tags = new List<string>
    {
        "*.prefab","*.png","*.controller","*.anim","*.TTF","*.mat"
    };
    public static string Variant = "XXX";


    //文件路径和对应的对象
    private static Dictionary<string, AssetInfo> AbPathDic = new Dictionary<string, AssetInfo>();
    //文件路径和是否ab//专门保存被依赖的资源
    private static Dictionary<string, bool> DependsPathList = new Dictionary<string, bool>();

    private static int length;
    public static void Collecttions(string path)
    {
        Debug.Log("AssetCollector--Collecttions==>"+path);
        DirectoryInfo di = new DirectoryInfo(path);
        if (di.Exists)
        {
            List<FileInfo> filelist = new List<FileInfo>();
            for (int ii = 0; ii < tags.Count; ii++)
            {
                FileInfo[] fi = di.GetFiles(tags[ii], SearchOption.AllDirectories);
                filelist.AddRange(fi);
            }

            //分析依赖
            length = Application.dataPath.Length - "Assets".Length;
            AbPathDic.Clear();
            Debug.Log("找到的文件数：" + filelist.Count);
            for (int i = 0; i < filelist.Count; i++)
            {
                EditorUtility.DisplayProgressBar("收集资源中", i + "/" + filelist.Count, (i * 1.0f / filelist.Count));
                string filepath = filelist[i].FullName;
                if (filepath.EndsWith(".meta") || filepath.EndsWith(".bin"))
                {
                    continue;
                }
                AssetInfo ai = new AssetInfo();
                string assetpath = filepath.Substring(length);
                assetpath = assetpath.Replace("\\", "/");
                ai.Path = assetpath;
                if (AbPathDic.ContainsKey(assetpath))
                {
                    if (!DependsPathList.ContainsKey(assetpath))
                    {
                        Debug.LogError("bit shit");
                    }
                }
                else
                {
                    AbPathDic.Add(assetpath, ai);
                }

                string[] depends = AssetDatabase.GetDependencies(assetpath);
                Debug.Log("==>" + ai.Path);
                if (depends.Length > 1)
                {
                    List<string> outputs = new List<string>();
                    AnalysisDepend(assetpath, depends, ref outputs);
                }
            }
            Debug.Log("分析过后变成：" + AbPathDic.Count);
            EditorUtility.ClearProgressBar();
        }
        else
        {
            Debug.Log("文件夹不存在");
        }
    }
    private static bool AnalysisDepend(string orginPath, string[] depends, ref List<string> commondepends)
    {
        for (int i = 0; i < depends.Length; i++)
        {
            string path = depends[i];
            if (path.EndsWith(".cs") || orginPath.Equals(path))
            {
                continue;
            }
            //如果这个资源本身是ab，那么标记ab
            if (AbPathDic.ContainsKey(path))
            {
                if (DependsPathList.ContainsKey(path))
                {
                    DependsPathList[path] = true;
                }
                else
                {
                    DependsPathList.Add(path, true);
                }
            }
            else
            {
                //不是的话根据情况，有重复就标记为ab，没有重复则默认被收集到ab上
                if (DependsPathList.ContainsKey(path))
                {
                    //把这个路径单独设置assetinfo 要设置tag打包
                    AssetInfo ai = new AssetInfo();
                    //path = path.Substring(length);
                    ai.Path = path;
                    Debug.Log("被重复依赖的资源" + path);
                    AbPathDic.Add(path, ai);
                    DependsPathList[path] = true;
                }
                else
                {
                    DependsPathList.Add(path, false);
                }
            }
        }
        return false;
    }

    public static void AllSetTag()
    {
        foreach (var item in AbPathDic)
        {
            AssetInfo.SetTag(item.Value);
        }
    }
    public static void AllClearTag()
    {
        string root = Application.dataPath;
        DirectoryInfo di = new DirectoryInfo(root);
        FileInfo[] fi = di.GetFiles("*.*", SearchOption.AllDirectories);
        string tempStr; AssetImporter importer;
        for (int i = 0; i < fi.Length; i++)
        {
            tempStr = fi[i].FullName;
            if (tempStr.EndsWith(".meta"))
            {
                continue;
            }
            string path = tempStr.Substring(tempStr.LastIndexOf("Assets"));
            EditorUtility.DisplayCancelableProgressBar("清空标签", i + " / " + fi.Length + "   " + path, (i * 1.0f / fi.Length));
            importer = AssetImporter.GetAtPath(path);
            if (importer != null && !string.IsNullOrEmpty(importer.assetBundleName))
            {
                importer.assetBundleVariant = string.Empty;
                importer.assetBundleName = string.Empty;
            }
        }
        EditorUtility.ClearProgressBar();
    }
    //Todo 留到更加复杂的资源处理流程再完善
    //public abstract class AssetHandler
    //{
    //    protected string m_Tag;
    //    public AssetHandler(string tag)
    //    {
    //        m_Tag = tag;
    //    }
    //    public abstract bool Process();
    //}

}
