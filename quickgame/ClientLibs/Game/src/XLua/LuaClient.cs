using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;
using System.Reflection;
using SGameEngine;
using XLua;

public class LuaClient : MonoBehaviour 
{
    public static string BundlePassword = "r1z2i3p!f@i#l$e%";

    public static LuaClient Instance;

    void Awake()
    {
        Instance = this;
    }

    //void OnApplicationQuit()
    //{
    //    LuaScriptMgr.Instance.Destroy();
    //}

    //private void OnDestroy()
    //{
    //    LuaScriptMgr.Instance.Destroy();
    //}

    ~LuaClient()
    {
        Instance = null;
    }

    public void Init()
    {
        StartCoroutine(InitRoutine());
    }

    public IEnumerator InitRoutine()
    {
        var assetRes = new AssetResource();

        yield return StartCoroutine(SGameEngine.ResourceLoader.Instance.load_asset("Assets/" + xc.ResPath.path3,
                                                       typeof(TextAsset), assetRes, true, false, string.Empty));

        var asset = assetRes.asset_ as TextAsset;
        if (asset == null)
        {
            GameDebug.LogError("InitRoutine load_asset failed.");
            yield break;
        }

        var mgr = LuaScriptMgr.Instance;
        mgr.ReloadBytes(asset.bytes);
        assetRes.destroy();

        // 等待1帧，防止一帧内GC对象太多
        yield return null;
        mgr.Start();
    }

    public void Reload()
    {
        StartCoroutine(ReloadRoutine());
    }

    private IEnumerator ReloadRoutine()
    {
        var assetRes = new SGameEngine.AssetResource();

        yield return StartCoroutine(SGameEngine.ResourceLoader.Instance.load_asset("Assets/" + xc.ResPath.path3,
                                                       typeof(TextAsset), assetRes, true, false, string.Empty));

        var asset = assetRes.asset_ as TextAsset;
        if(asset == null)
        {
            GameDebug.LogError("ReloadRoutine load_asset failed.");
            yield break;
        }

        var mgr = LuaScriptMgr.Instance;
        mgr.ReloadBytes(asset.bytes);
        assetRes.destroy();
    }

    void Update()
    {
        if (LuaScriptMgr.Instance != null)
        {
            LuaScriptMgr.Instance.Update();
        }
    }
}