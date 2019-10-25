using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using System.IO;
using UnityEngine;

public static class ResTools
{
    public static bool IsAbMode = false;
    [MenuItem("AssetBundle/MoveAbToStreamingAssets")]
    private static void MoveAbToStreamingAssets()
    {
        if (!Directory.Exists(Application.streamingAssetsPath))
        {
            Directory.CreateDirectory(Application.streamingAssetsPath);
        }
        string des = Application.streamingAssetsPath + "/" + XGamePath.Output + "/";
        if (Directory.Exists(des))
        {
            Directory.Delete(des, true);
        }
        AssetDatabase.Refresh();
        Directory.CreateDirectory(des);
        string path = Application.dataPath.Substring(0,Application.dataPath.LastIndexOf("/"));
        DirectoryInfo di = new DirectoryInfo(XGamePath.OutputPath);
        DirectoryInfo[] dirs = di.GetDirectories();
        string binpath = des+"/bin/";
        Directory.CreateDirectory(binpath);
        for (int i = 0; i < dirs.Length; i++)
        {
            FileInfo[] fi = dirs[i].GetFiles();
            for (int ii = 0; ii < fi.Length; ii++)
            {
                EditorUtility.DisplayProgressBar("移动文件夹", fi[i].Name, i * 1.0f / fi.Length);
                File.Copy(fi[ii].FullName, binpath + fi[ii].Name,true);
            }
            EditorUtility.ClearProgressBar();
        }
        FileInfo[] files = di.GetFiles();
        for (int i = 0; i < files.Length; i++)
        {
            if (files[i].Name.EndsWith(".manifest"))
            {
                continue;
            }
            EditorUtility.DisplayProgressBar("移动文件", files[i].Name, i * 1.0f / files.Length);
            File.Copy(files[i].FullName, des + files[i].Name,true);
        }
        EditorUtility.ClearProgressBar();
        AssetDatabase.Refresh();
    }
    const string kSimulationMode = "AssetBundle/Use Ab Mode";


    [MenuItem(kSimulationMode,false)]
    public static void ToggleSimulationMode()
    {
        Debug.Log("ToggleSimulationMode");
        AbMgr.IsAbMode = !AbMgr.IsAbMode;
    }

    [MenuItem(kSimulationMode, true)]
    public static bool ToggleSimulationModeValidate()
    {
        Debug.Log("ToggleSimulationModeValidate");
        Menu.SetChecked(kSimulationMode,AbMgr.IsAbMode);
        return true;
    }
}
