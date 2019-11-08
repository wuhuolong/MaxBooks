using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Text;
using UnityEditor;
using UnityEngine;

public class AssetInfo
{
    public string Path;
    public bool isAssetBundle;
    public List<string> depends = new List<string>();
    public List<string> bedepends = new List<string>();
    public static void SetTag(AssetInfo asset)
    {
        if (!asset.isAssetBundle||asset.Path.EndsWith(".cs"))
        {
            return;
        }
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

    public override string ToString()
    {
        StringBuilder ab = new StringBuilder();
        ab.Append("路径:" + Path + ",");
        ab.Append("依赖:" + depends.Count + ",");
        ab.Append("被依赖:" + bedepends.Count + "\n");
        ab.Append("依赖============\n");
        for (int i = 0; i < depends.Count; i++)
        {
            ab.Append(depends[i] + "\n");
        }
        ab.Append("被依赖============\n");
        for (int i = 0; i < bedepends.Count; i++)
        {
            ab.Append(bedepends[i] + "\n");
        }
        //ab.Append("路径:" + Path + "\n");
        return ab.ToString();
    }
}
public static class AssetCollector
{
    private static bool islog = true;
    private static string Tag = "AssetCollector";
    private static void Log(string msg)
    {
        if (!islog) return;
        Debuger.Log(Tag,string.Empty,msg);
    }
    public static List<string> tags = new List<string>
    {
        "*.prefab"/*,"*.png","*.controller","*.anim","*.TTF","*.mat"*/
    };
    public static string Variant = "XXX";
    private static Dictionary<string, AssetInfo> AllAssets = new Dictionary<string, AssetInfo>();

    ////文件路径和对应的对象
    //private static Dictionary<string, AssetInfo> AbPathDic = new Dictionary<string, AssetInfo>();

    private static int length;
    public static void Collecttions(string path)
    {
        Log("======AssetCollector--Collecttions==>" + path);
        Debuger.EnableLog = true;
        DirectoryInfo di = new DirectoryInfo(path);
        if (di.Exists)
        {
            List<FileInfo> filelist = new List<FileInfo>();
            for (int ii = 0; ii < tags.Count; ii++)
            {
                FileInfo[] fi = di.GetFiles(tags[ii], SearchOption.AllDirectories);
                filelist.AddRange(fi);
            }
            length = Application.dataPath.Length - "Assets".Length;
            /*AbPathDic.Clear();*/
            AllAssets.Clear();
            Log("找到的文件数：" + filelist.Count);
            for (int i = 0; i < filelist.Count; i++)
            {
                EditorUtility.DisplayProgressBar("收集资源中", i + "/" + filelist.Count, (i * 1.0f / filelist.Count));
                string filepath = filelist[i].FullName;
                Log("处理资源==>" + filepath);
                if (filepath.EndsWith(".meta")/* || filepath.EndsWith(".bin")*/)
                {
                    continue;
                }

                string assetpath = filepath.Substring(length);
                assetpath = assetpath.Replace("\\", "/");
                AssetInfo ai;
                if (!AllAssets.TryGetValue(assetpath, out ai))
                {
                    ai = new AssetInfo
                    {
                        Path = assetpath,
                        isAssetBundle = true
                    };
                    AllAssets.Add(ai.Path, ai);
                }

                string[] depends = AssetDatabase.GetDependencies(assetpath);
                List<string> list = new List<string>(depends);
                list.Remove(assetpath);

                for (int ii = 0; ii < list.Count; ii++)
                {
                    if (!ai.depends.Contains(list[ii]))
                    {
                        ai.depends.Add(list[ii]);
                    }
                    AnalysisDepend(list[ii], assetpath);
                }
            }
            Log("分析==>" + AllAssets.Count);
            Print();
            //分析依赖
            Log("===分析依赖====");
            SortDepends();
            Print();
            SetAb();
            EditorUtility.ClearProgressBar();
            Debuger.EnableLog = false;
        }
        else
        {
            Log("文件夹不存在");
        }
    }

    private static void Print()
    {
        var ie = AllAssets.GetEnumerator();
        while (ie.MoveNext())
        {
            Log(ie.Current.Value.ToString());
        }
    }

    private static void AnalysisDepend(string assetpath, string bedepend)
    {
        Log("AnalysisDepend==>" + assetpath + "==>" + bedepend);
        if (AllAssets.ContainsKey(assetpath))
        {
            if (!AllAssets[assetpath].bedepends.Contains(bedepend))
            {
                AllAssets[assetpath].bedepends.Add(bedepend);
            }
            return;
        }
        List<string> temp = new List<string>();
        temp.AddRange(AssetDatabase.GetDependencies(assetpath));
        temp.Remove(assetpath);
        AssetInfo ai = new AssetInfo();
        ai.depends = temp;
        ai.Path = assetpath;
        ai.bedepends.Add(bedepend);
        AllAssets.Add(ai.Path, ai);
        for (int i = 0; i < temp.Count; i++)
        {
            AnalysisDepend(temp[i], assetpath);
        }
        Log("AnalysisDepend==>" + assetpath + "==>" + bedepend + "*Over");
    }
    private static void SetAb()
    {
        var ie = AllAssets.GetEnumerator();
        AssetInfo ai;
        while (ie.MoveNext())
        {
            ai = ie.Current.Value;
            if (ai.isAssetBundle)
            {
                continue;
            }
            if (ai.bedepends.Count != 1)
            {
                ai.isAssetBundle = true;
                continue;
            }

        }
    }
    private static void SortDepends()
    {
        var ie = AllAssets.GetEnumerator();
        AssetInfo ai;
        while (ie.MoveNext())
        {
            ai = ie.Current.Value;
            AssetInfo aiparent;
            for (int i = 0; i < ai.bedepends.Count; i++)
            {
                aiparent = AllAssets[ai.bedepends[i]];
                SortDepends(aiparent.Path, ai.Path, ai.bedepends);
            }
        }
    }
    private static void SortDepends(string assetpath, string tag, List<string> bedepends)
    {
        AssetInfo ai = AllAssets[assetpath];
        AssetInfo aiparent;
        for (int i = 0; i < ai.bedepends.Count; i++)
        {
            aiparent = AllAssets[ai.bedepends[i]];
            if (bedepends.Contains(ai.bedepends[i]))
            {
                aiparent.depends.Remove(tag);
                AllAssets[tag].bedepends.Remove(aiparent.Path);
            }
            SortDepends(aiparent.Path, tag, bedepends);
        }
    }

    public static void AllSetTag()
    {
        foreach (var item in AllAssets)
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
}
