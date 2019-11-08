using UnityEngine;
using System.Collections;
using UnityEditor;

public class NameChanger : EditorWindow
{
    GameObject parentObj;
    string prefixName;
    //初始化，也就是一个MenuItem，当点击时调用Init()
    [MenuItem("Tools/子对象批量重命名")]
    static void Init()
    {
        GetWindow(typeof(NameChanger));

    }

    void OnGUI()
    {
        GUILayout.Label("子对象批量重命名");
        parentObj = (GameObject)EditorGUILayout.ObjectField("父对象：", parentObj, typeof(GameObject),true);
        prefixName = EditorGUILayout.TextField("前缀：", prefixName);

        if (GUILayout.Button("确定"))
        {
            if (parentObj != null)
            {
                Debug.Log(parentObj.transform.childCount);
                for (int i = 0; i < parentObj.transform.childCount; ++i)
                {
                    Transform childObj = parentObj.transform.GetChild(i);
                    childObj.name = prefixName+i.ToString();
                }
            }
        }


    }


}
