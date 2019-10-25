using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(UIAtlas))]
public class UIAtlasInspector : Editor
{
    private List<Sprite> list = new List<Sprite>();
    public override void OnInspectorGUI()
    {
        UIAtlas ua = target as UIAtlas;
        if (ua.mainText!= null && GUILayout.Button("刷新图集", GUILayout.Width(50)))
        {
            ua .spriteLists = GetSprites(ua.mainText);
        }
        base.OnInspectorGUI();
    }
    private List<Sprite> GetSprites(Texture2D sp)
    {
        string path = AssetDatabase.GetAssetPath(sp);
        object[] objs = AssetDatabase.LoadAllAssetsAtPath(path);

        list.Clear();
        foreach (var item in objs)
        {
            System.Type type = item.GetType();
            if (type == typeof(Sprite))
            {
                list.Add(item as Sprite);
            }
        }
        return list;
    }
}

