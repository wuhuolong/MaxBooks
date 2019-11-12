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
    private static string Tag = "ResMgr";
#if UNITY_EDITOR
    private static bool islog = false;
#endif
    public static void Log(string objname,string method, string msg)
    {
#if UNITY_EDITOR
        if (!islog)
#else
        if (!GameConfig.IsDebug)
#endif
        {
            return;
        }
        Debuger.Log(objname, method, msg);
    }
    public static void LogError(string objname, string method, string msg)
    {
#if UNITY_EDITOR
        if (!islog)
#else
        if (!GameConfig.IsDebug)
#endif
        {
            return;
        }
        Debuger.LogError(objname, method, msg);
    }
    public static GameObject LoadGameObject(string path)
    {
        Log(Tag,"LoadGameObject", path);
        GameObject temp = Load<GameObject>(path);
        //todo add tag scripts.
        return GameObject.Instantiate(temp);
    }
    public static void LoadGobjAsync(string path, Action<GameObject> callback)
    {
        //System.Diagnostics.Stopwatch wa = new System.Diagnostics.Stopwatch();
        //GameObject temp = Load<GameObject>(path);
        LoadAsync<GameObject>(path, (o) =>
        {
            Log(Tag, "LoadGobjAsync" , path);
            //wa.Reset();
            //wa.Start();
            GameObject obj = GameObject.Instantiate(o);
            //Debug.Log(wa.ElapsedMilliseconds);
            callback(obj);
        });
        
        //todo add tag scripts.
    }
    public static void LoadGobjAsync(string path, Action callback)
    {

        //GameObject temp = Load<GameObject>(path);
        LoadAsync<GameObject>(path, (o) =>
        {
            Log(Tag, "LoadGobjAsync", path);
            if (callback!= null)
            {
                callback();
            }
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

    public static UIAtlas GetLevelAtlas(string atlasname)
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
            Log(Tag, "GetAtlasAsync" , path);
            UIAtlas ua = o.GetComponent<UIAtlas>();
            callback(ua);
        });
    }

    public static Font GetFont(string fontname)
    {
        string path = XGamePath.GetFontPath(fontname);
        Font font = Load<Font>(path);
        return font;
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
            Log(Tag, "LoadGameObject" , path);
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
        
        Log(Tag, "Load", path);
        
        AssetBundle ab = AbMgr.GetInstance().SyncLoad(path);
        obj = ab.LoadAsset<T>(ab.GetAllAssetNames()[0]);
        return obj as T;
#endif
    }
    public static void LoadAsync<T>(string path, Action<T> callback) where T : UnityEngine.Object
    {
        int hash = path.GetHashCode();

#if UNITY_EDITOR
        if (AbMgr.IsAbMode)
        {
            //Debug.Log("max==>" + filepath);
            AssetBundle ab;
            Action<AssetBundle> de = (a) =>
            {
                if (a == null)
                {
                    Log(Tag, "LoadAsync", "ab is emptty " + path);
                }
                ab = a;
                AssetBundleRequest abr = ab.LoadAssetAsync<T>(ab.GetAllAssetNames()[0]);
                if (abr == null)
                {
                    Log(Tag, "LoadAsync", "ab is emptty " + path + "|ab name = " + ab.GetAllAssetNames()[0]);
                    return;
                }
                AbMgr.GetInstance().StartCoroutine(LoadAssetAsync(abr, callback));
            };
            AbMgr.GetInstance().AsyncLoad(path, de);
        }
        else
        {
            object obj;
            path = "Assets/" + XGamePath.ResRoot + "/" + path;
            obj = UnityEditor.AssetDatabase.LoadAssetAtPath<T>(path);
            callback(obj as T);
        }
#else
            Action<AssetBundle> de = (ab) =>
            {
                Debug.Log("LoadAsset==>" + ab.GetAllAssetNames()[0]);
                //T tobj = ab.LoadAsset<T>(ab.GetAllAssetNames()[0]);
                //callback(tobj);
                AssetBundleRequest abr = ab.LoadAssetAsync<T>(ab.GetAllAssetNames()[0]);
                AbMgr.GetInstance().StartCoroutine(LoadAssetAsync(abr, callback));
            };
            AbMgr.GetInstance().AsyncLoad(path, de);
#endif
    }
    private static IEnumerator LoadAssetAsync<T>(AssetBundleRequest abr, Action<T> cb) where T : UnityEngine.Object
    {
        yield return abr;
        T t = abr.asset as T;
        if (cb != null)
        {
            cb(t);
        }

    }
}