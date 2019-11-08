using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System;

public class AbMgr : MonoSingleton<AbMgr>
{
    private static string Tag = "AbMgr";
    private static string m_manifest_name = "AssetBundle";
    //private static string m_AssetBundle_name = "/AssetBundleManifest/";
    private Dictionary<int, AbAbstractLoader> m_Ab_Dic = new Dictionary<int, AbAbstractLoader>();
    private Dictionary<int, AbAsyncLoader> m_loading_Dic = new Dictionary<int, AbAsyncLoader>();
    private List<int> m_delay = new List<int>();
    private AssetBundle m_manifest_ab;
    private AssetBundleManifest m_manifest;
    private Dictionary<int, string[]> depends = new Dictionary<int, string[]>();
    public bool isHaveAb(int hash)
    {
        AbAbstractLoader loader = null;
        return m_Ab_Dic.TryGetValue(hash, out loader);
    }
    public bool isHaveAb(string abname)
    {
        int hash = abname.GetHashCode();
        AbAbstractLoader loader = null;
        return m_Ab_Dic.TryGetValue(hash, out loader);
    }
    public void OnAbAsyncDownloadOver(int hash)
    {
        if (m_loading_Dic.ContainsKey(hash))
        {
            AbAbstractLoader loader = m_loading_Dic[hash];
            m_Ab_Dic.Add(hash, loader);
            if (!(loader as AbAsyncLoader).Tick())
            {
                m_delay.Add(hash);
            }
            m_loading_Dic.Remove(hash);
            Debuger.Log(Tag,"transfer ", loader.AbName);
            bool issuc;
            for (int i = m_delay.Count - 1; i>-1; i--)
            {
                issuc = (m_Ab_Dic[m_delay[i]] as AbAsyncLoader).Tick();
                if (issuc)
                {
                    m_delay.RemoveAt(i);
                }
            }
        }
        else
        {
            Debuger.Log(Tag, "transfer ", "this should never happen too !!!!!");
        }
    }
#if UNITY_EDITOR
    public static string key = "";
    private static bool isabmodeb = false;
    public static bool IsAbMode
    {
        get
        {
            isabmodeb = UnityEditor.EditorPrefs.GetBool(AbMgr.key);
            return isabmodeb;
        }
        set
        {
            UnityEditor.EditorPrefs.SetBool(AbMgr.key, value);
        }
    }
#endif
    public IEnumerator Init()
    {
        ResMgr.Log(Tag, "Init", "Start Async Init");
        string path = XGamePath.GetStreamingAbPath(m_manifest_name);
        ResMgr.Log(Tag, "Init", "==>" + path);
        if (File.Exists(path))
        {
            //同步加载
            //FileStream fs = File.Open(path, FileMode.Open);
            //m_manifest_ab = AssetBundle.LoadFromStream(fs);
            //m_manifest = m_manifest_ab.LoadAsset<AssetBundleManifest>("AssetBundleManifest");

            //if (m_Ab_Dic.Count > 0)
            //{
            //    Debug.LogError("不应该发生的事情发生了");
            //}
            //m_Ab_Dic.Clear();
            //loader = new AbSyncLoader();
            //异步加载
            AssetBundleCreateRequest request = AssetBundle.LoadFromFileAsync(path);
            yield return request;
            if (request.isDone)
            {
                m_manifest = request.assetBundle.LoadAsset<AssetBundleManifest>("AssetBundleManifest");
                if (m_Ab_Dic.Count > 0)
                {
                    ResMgr.LogError(Tag, "Init", "this should never happen !!!!");
                }
                //string[] depends = m_manifest.GetAllAssetBundles();
                //foreach (var item in depends)
                //{
                //    Debug.Log("depends log ==>" + item);
                //}
                m_Ab_Dic.Clear();
                ResMgr.Log(Tag, "Init", "load manifest success");
            }
            else
            {
                ResMgr.Log(Tag, "Init", "load manifest fail");
            }
        }
        else
        {
            ResMgr.Log(Tag, "Init", "manifest not exist");
        }
    }

    public AssetBundle SyncLoad(string path, bool isdepend = false)
    {
        if (m_manifest == null)
        {
            return null;
        }
        string abname;
        if (isdepend)
        {
            abname = path;
        }
        else
        {
            abname = XGamePath.Path2ResName(path);
        }
        string fullpath = XGamePath.GetStreamingAbPath(abname);
        int hash = path.GetHashCode();

        string[] depends = AbMgr.GetInstance().GetDepends(abname);
        for (int i = 0; i < depends.Length; i++)
        {
            ResMgr.Log(Tag,"SyncLoad|depends" , depends[i]);
            int hash2 = depends[i].GetHashCode();
            AbAbstractLoader loader2 = null;
            if (m_Ab_Dic.TryGetValue(hash2, out loader2))
            {
                continue;
            }
            if (m_loading_Dic.ContainsKey(hash2))
            {
                AbAsyncLoader asyncloader = m_loading_Dic[hash2] as AbAsyncLoader;
                asyncloader.request.priority++;
                continue;
            }
            AbMgr.GetInstance().SyncLoad(depends[i],true);
        }
        AbAbstractLoader loader;
        if (m_Ab_Dic.TryGetValue(hash, out loader))
        {
            switch (loader.State)
            {
                case AbBundleState.success:
                    return loader.Bundle;
                case AbBundleState.loading:
                    if (!loader.isSync)
                    {
                        //todo 转同步加载
                    }
                    break;
                case AbBundleState.none:
                default:
                    break;
            }
        }
        loader = new AbSyncLoader(fullpath, abname);
        loader.LoadAsset(fullpath);
        m_Ab_Dic.Add(hash, loader);
        return m_Ab_Dic[hash].Bundle;
    }
    public void AsyncLoad(string path, Action<AssetBundle> callback, bool isdepend = false)
    {
        if (m_manifest == null)
        {
            ResMgr.Log(Tag,"AsyncLoad", "manifest is null");
            return;
        }
        string abname;
        if (isdepend)
        {
            abname = path;
        }
        else
        {
            abname = XGamePath.Path2ResName(path);
        }
        int hash = abname.GetHashCode();
        AbAbstractLoader loader = null;
        if (m_Ab_Dic.TryGetValue(hash, out loader))
        {
            if (callback != null)
            {
                callback(loader.Bundle);
            }
            return;
        }

        string[] depends = AbMgr.GetInstance().GetDepends(abname);
        for (int i = 0; i < depends.Length; i++)
        {
            ResMgr.Log(Tag,"AsyncLoad|depends", depends[i]);
            int hash2 = depends[i].GetHashCode();
            AbAbstractLoader loader2 = null;
            if (m_Ab_Dic.TryGetValue(hash2, out loader2))
            {
                continue;
            }
            if (m_loading_Dic.ContainsKey(hash2))
            {
                AbAsyncLoader asyncloader = m_loading_Dic[hash2] as AbAsyncLoader;
                asyncloader.request.priority++;
                continue;
            }
            AbMgr.GetInstance().AsyncLoad(depends[i], null, true);
        }

        loader = new AbAsyncLoader(path, abname, callback);
        path = XGamePath.GetStreamingAbPath(abname);
        loader.LoadAsset(path);
        m_loading_Dic.Add(hash, loader as AbAsyncLoader);
    }
    public string[] GetDepends(string abname)
    {
        int hash = abname.GetHashCode();
        if (!depends.ContainsKey(hash))
        {
            depends.Add(hash, m_manifest.GetAllDependencies(abname));
        }
        return depends[hash];
    }

}
public enum AbBundleState
{
    none,
    error,
    loading,
    success,
}
public abstract class AbAbstractLoader
{
    protected string Tag = "AbAbstractLoader";
    protected string m_Ab_Name;
    protected string m_Ab_Path;
    public bool isSync;
    public AbBundleState State;
    public AssetBundle Bundle { get; protected set; }
    public abstract void LoadAsset(string path);
    public string AbName
    {
        get
        {
            return m_Ab_Name;
        }
    }
    protected void Log(string msg)
    {
        Debuger.Log(Tag, string.Empty, msg);
    }
}
public class AbSyncLoader : AbAbstractLoader
{
    public AbSyncLoader(string path, string abname)
    {
        m_Ab_Path = path;
        isSync = true;
        m_Ab_Name = abname;
        Tag = "AbSyncLoader";
    }
    public AbSyncLoader()
    {
        Tag = "AbSyncLoader";
    }
    public override void LoadAsset(string path)
    {
        ResMgr.Log(Tag,"LoadAsset" , path);
        if (File.Exists(path))
        {
            AssetBundle tempbundle = AssetBundle.LoadFromFile(path);
            if (tempbundle != null)
            {
                State = AbBundleState.success;
                Bundle = tempbundle;
            }
            else
            {
                State = AbBundleState.error;
            }
        }
        else
        {
            this.Log("sync path is not exist ==>" +path);
            State = AbBundleState.error;
        }
    }
}
public class AbAsyncLoader : AbAbstractLoader
{
    private Action<AssetBundle> m_callback;
    public AssetBundleCreateRequest request;
    private string[] depends;
    private List<string> dynamicdepends;
    public AbAsyncLoader(string path, string abname)
    {
        m_Ab_Path = path;
        isSync = false;
        m_Ab_Name = abname;
        dynamicdepends = new List<string>();
        Tag = "AbAsyncLoader";
    }
    public AbAsyncLoader(string path, string abname, Action<AssetBundle> callback)
    {
        m_Ab_Path = path;
        isSync = false;
        m_Ab_Name = abname;
        m_callback = callback;
        dynamicdepends = new List<string>();
    }
    public bool Tick()
    {
        if (dynamicdepends.Count > 0)
        {
            for (int i = dynamicdepends.Count - 1; i > -1; i--)
            {
                if (AbMgr.GetInstance().isHaveAb(dynamicdepends[i]))
                {
                    dynamicdepends.RemoveAt(i);
                }
            }
            if (dynamicdepends.Count == 0 && request.isDone)
            {
                if (m_callback != null)
                {
                    m_callback(Bundle);
                    m_callback = null;
                }
                this.Log("depends is load over self callback");
                return true;
            }
        }
        return false;
    }
    public override void LoadAsset(string path)
    {
        depends = AbMgr.GetInstance().GetDepends(m_Ab_Name);
        dynamicdepends.Clear();
        dynamicdepends.AddRange(depends);
        AbMgr.GetInstance().StartCoroutine(LoadAsync(path));
    }
    IEnumerator LoadAsync(string path)
    {
        if (request != null)
        {
            ResMgr.Log(Tag, "LoadAsync", "this should never happen tooo !!");
        }
        if (!File.Exists(path))
        {
            ResMgr.Log(Tag, "LoadAsync", "async path is not exist");
            State = AbBundleState.error;
            yield break ;
        }
        request = AssetBundle.LoadFromFileAsync(path);
        yield return request;
        if (request.isDone)
        {
            this.Log("AbAsyncLoader LoadAsync succ==>" + path);
            Bundle = request.assetBundle;
            State = AbBundleState.success;
            AbMgr.GetInstance().OnAbAsyncDownloadOver(m_Ab_Name.GetHashCode());
        }
        else
        {
            State = AbBundleState.error;
            this.Log("async big problem");
        }
    }
}
