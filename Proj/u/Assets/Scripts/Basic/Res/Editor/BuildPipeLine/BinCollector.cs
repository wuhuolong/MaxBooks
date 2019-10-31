using System.Collections;
using System.Collections.Generic;
using System.IO;
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

            }
        }
    }
}
