using UnityEngine;
using UnityEditor;
using UnityEditor.Callbacks;
using UnityEditor.XCodeEditor;
using System.IO;

public static class XCodePostProcess
{
	[PostProcessBuild]
	public static void OnPostProcessBuild( BuildTarget target, string path )
	{
		if (target != BuildTarget.iOS) {
			Debug.LogWarning("Target is not iPhone. XCodePostProcess will not run");
			return;
		}

		//// Create a new project object from build target
		//XCProject project = new XCProject( path );

		//// Find and run through all projmods files to patch the project.
		////Please pay attention that ALL projmods files in your project folder will be excuted!
		//string[] files = Directory.GetFiles( Application.dataPath, "*.projmods", SearchOption.AllDirectories );
		//foreach( string file in files ) {
		//	project.ApplyMod( file );
		//}

		//// Finally save the xcode project
		//project.Save();
        OnPostProcessBuildV1(target, path);

    }
    public static void OnPostProcessBuildV1(BuildTarget target, string path)
    {
        Debug.Log("============开始移动文件=============");
        string filepath = path + "/Classes/UnityAppController.mm";
        if (File.Exists(filepath))
        {
            try
            {
                File.Delete(filepath);
                string filepath_o = Application.dataPath + "/Editor/XUPorter/Mods/iOS/UnityAppController.mm";
                File.Copy(filepath_o, filepath);
            }
            catch (System.Exception e)
            {
                Debug.LogError("移动文件出错==>"+ filepath +"\n==>"+ e.Message);
            }
        }
        else
        {
            Debug.LogError("文件不存在 ==> "+filepath);
        }
        filepath = path + "/Info.plist";
        if (File.Exists(filepath))
        {
            try
            {
                File.Delete(filepath);
                string filepath_o = Application.dataPath + "/Editor/XUPorter/Mods/iOS/Info.plist";
                File.Copy(filepath_o, filepath);
            }
            catch (System.Exception e)
            {
                Debug.LogError("移动文件出错==>" + filepath + "\n==>" + e.Message);
            }
        }
        else
        {
            Debug.LogError("文件不存在 ==> " + filepath);
        }
    }
}