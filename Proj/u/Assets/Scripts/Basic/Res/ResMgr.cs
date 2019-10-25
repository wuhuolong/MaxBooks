using System;
using System.IO;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum ResourcesType
{
    Prefab,
    Texture,

}

public class ResMgr
{
    private static bool islog = false;
    public static void Log(string method, string msg)
    {
        if (!islog)
        {
            return;
        }
        Debuger.Log("ResMgr", method, msg);
    }
    public static GameObject LoadGameObject(string path)
    {
        Log("LoadGameObject", path);
        GameObject temp = Load<GameObject>(path);
        //todo add tag scripts.
        return GameObject.Instantiate(temp);
    }
    public static void LoadGobjAsync(string path, Action<GameObject> callback)
    {

        //GameObject temp = Load<GameObject>(path);
        LoadAsync<GameObject>(path, (o) =>
        {
            Log("LoadGobjAsync" , path);
            GameObject obj = GameObject.Instantiate(o);
            callback(obj);
        });
        //todo add tag scripts.
    }

    public static UIAtlas GetAtlas(string atlasname)
    {
        string path = XGamePath.GetAtlasPath(atlasname);
        GameObject go = Load<GameObject>(path);
        UIAtlas ua = go.GetComponent<UIAtlas>();
        return ua;
    }
    public static void GetAtlasAsync(string atlasname, Action<UIAtlas> callback)
    {
        string path = XGamePath.GetAtlasPath(atlasname);
        LoadAsync<GameObject>(path, (o) =>
        {
            Log("GetAtlasAsync" , path);
            UIAtlas ua = o.GetComponent<UIAtlas>();
            callback(ua);
        });
    }

    public static GameObject LoadGameObject(string path, Transform parent)
    {
        //Debug.Log(path);
        GameObject temp = Load<GameObject>(path);
        //todo add tag scripts.
        return GameObject.Instantiate(temp, parent);
    }
    public static void LoadGameObject(string path, Transform parent, Action<GameObject> callback)
    {
        //Debug.Log(path);
        LoadAsync<GameObject>(path, (o) =>
        {
            Log("LoadGameObject" , path);
            GameObject obj = GameObject.Instantiate(o, parent);
            callback(obj);
        });
        //todo add tag scripts.
    }
    private static T Load<T>(string path) where T : UnityEngine.Object
    {
        int hash = path.GetHashCode();
        object obj;

#if UNITY_EDITOR
        if (AbMgr.IsAbMode)
        {
            //Debug.Log("max==>" + filepath);
            AssetBundle ab = AbMgr.GetInstance().SyncLoad(path);
            return ab.LoadAsset<T>(ab.GetAllAssetNames()[0]);
        }
        else
        {
            //Debug.Log("max=111=>" + filepath);
            path = "Assets/" + XGamePath.ResRoot + "/" + path;
            //Debug.Log("max=22=>" + path);
            obj = UnityEditor.AssetDatabase.LoadAssetAtPath<T>(path);
            return obj as T;
        }
#else
        
        Log("Load", path);
        
        AssetBundle ab = AbMgr.GetInstance().SyncLoad(path);
        return ab.LoadAsset<T>(ab.GetAllAssetNames()[0]);
#endif
    }
    private static void LoadAsync<T>(string path, Action<T> callback) where T : UnityEngine.Object
    {
        int hash = path.GetHashCode();
        object obj ;

#if UNITY_EDITOR
        if (AbMgr.IsAbMode)
        {
            //Debug.Log("max==>" + filepath);
            AssetBundle ab;
            Action<AssetBundle> de = (a) =>
            {
                if (a == null)
                {
                    Log("LoadAsync", "ab is emptty " + path);
                }
                ab = a;
                T tobj = ab.LoadAsset<T>(ab.GetAllAssetNames()[0]);
                if (tobj == null)
                {
                    Log("LoadAsync", "ab is emptty " + path + "|ab name = " + ab.GetAllAssetNames()[0]);
                }
                callback(tobj);
            };
            AbMgr.GetInstance().AsyncLoad(path, de);
            //return ab.LoadAsset<T>(ab.GetAllAssetNames()[0]);
        }
        else
        {
            //Debug.Log("max=111=>" + filepath);
            path = "Assets/" + XGamePath.ResRoot + "/" + path;
            //Debug.Log("max=22=>" + path);
            obj = UnityEditor.AssetDatabase.LoadAssetAtPath<T>(path);
            callback(obj as T);
        }
#else
            Action<AssetBundle> de = (ab) =>
            {
                Debug.Log("max=33=>" + ab.GetAllAssetNames()[0]);
                T tobj = ab.LoadAsset<T>(ab.GetAllAssetNames()[0]);
                callback(tobj);
            };
            AbMgr.GetInstance().AsyncLoad(path, de);
#endif
    }
}