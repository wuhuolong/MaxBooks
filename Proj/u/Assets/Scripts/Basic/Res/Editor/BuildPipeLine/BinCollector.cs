using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEditor;
using UnityEngine;

public static class BinCollector
{
    public static List<string> tags = new List<string>
    {
        "*.bin",
        "*.json",
    };

    public static void Collecttions(string path,string outpath)
    {

        //Debug.Log("BinCollector--path==>" + path);
        //Debug.Log("BinCollector--outpath==>" + outpath);
        if (Directory.Exists(outpath))
        {
            Directory.Delete(outpath,true);
        }
        Directory.CreateDirectory(outpath);
        Directory.CreateDirectory(outpath+ "bin/");
        DirectoryInfo di = new DirectoryInfo(path);
        if (di.Exists)
        {
            List<FileInfo> filelist = new List<FileInfo>();
            for (int i = 0; i < tags.Count; i++)
            {
                FileInfo[] fis = di.GetFiles(tags[i], SearchOption.AllDirectories);
                filelist.AddRange(fis);
            }
            for (int i = 0; i < filelist.Count; i++)
            {
                FileInfo fi = filelist[i];
                File.Copy(fi.FullName, outpath + "bin/" + fi.Name);
                Debug.Log("BinCollector ==> "+ outpath + "bin/" + fi.Name);
            }
        }
    }
}

public static class ShaderCollector
{
    public static List<string> tags = new List<string>
    {
        "*.shader",
    };
    
    public static void Collecttions(string path)
    {
        DirectoryInfo di = new DirectoryInfo(path);
        if (di.Exists)
        {
            List<FileInfo> filelist = new List<FileInfo>();
            for (int i = 0; i < tags.Count; i++)
            {
                FileInfo[] fis = di.GetFiles(tags[i], SearchOption.AllDirectories);
                filelist.AddRange(fis);
            }
            int length = Application.dataPath.Length - 6;
            string abname = path.Substring(Application.dataPath.Length+1).TrimEnd('/');
            for (int i = 0; i < filelist.Count; i++)
            {
                FileInfo fi = filelist[i];
                string filepath = fi.FullName.Substring(length);
                AssetImporter importer = AssetImporter.GetAtPath(filepath);
                //path = path.Substring(Application.dataPath.Length);
                //path = path.Replace("/", "_");
                //path = path.Replace(".", "_");
                Debug.Log("shader SetTag==>" + abname);
                importer.assetBundleName = abname;
                importer.assetBundleVariant = AssetCollector.Variant;

            }
        }
    }
}

public static class FontCollector
{
    public static List<string> tags = new List<string>
    {
        "*.TTF",
    };

    public static void Collecttions(string path)
    {
        DirectoryInfo di = new DirectoryInfo(path);
        if (di.Exists)
        {
            List<FileInfo> filelist = new List<FileInfo>();
            for (int i = 0; i < tags.Count; i++)
            {
                FileInfo[] fis = di.GetFiles(tags[i], SearchOption.AllDirectories);
                filelist.AddRange(fis);
            }
            int length = Application.dataPath.Length - 6;
            string abname = "Font";
            for (int i = 0; i < filelist.Count; i++)
            {
                FileInfo fi = filelist[i];
                string filepath = fi.FullName.Substring(length);
                AssetImporter importer = AssetImporter.GetAtPath(filepath);

                Debug.Log("shader SetTag==>" + abname);
                importer.assetBundleName = fi.Name.Split('.')[0];
                importer.assetBundleVariant = AssetCollector.Variant;

            }
        }
    }
}
