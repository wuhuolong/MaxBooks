using System;
using System.Collections.Generic;
using UnityEngine;
using XLua;
using xc;

public class LuaScriptMgr
{
    private static LuaScriptMgr instance;

    public static LuaScriptMgr Instance
    {
        get
        {
            if (instance == null)
            {
                instance = new LuaScriptMgr();
            }
            return instance;
        }
    }

    public LuaEnv Lua;

    Dictionary<string, object> mRequireDict = new Dictionary<string, object>();

    LuaFunction updateFunc = null;
    LuaFunction luaUranusHotfixInit = null;
    LuaFunction luaUranusHotfixFunc = null;

    private LuaScriptMgr()
    {
        Lua = new LuaEnv();
        Lua.AddLoader(Loader);

        mRequireDict.Clear();
    }

    byte[] Loader(ref string filepath)
    {
        string path = XLua.XUtils.LuaPath(filepath);
        byte[] data = mResExtract.GetFileBytes(path);

        return data;
    }

    void OnBundleLoaded()
    {
        Lua.AddBuildin("protobuf.c", XLua.LuaDLL.Lua.LoadProtobufC);

        DoFile("System.Global");
        DoFile("System.Main");

        updateFunc = GetLuaFunction("Main_Update");
        luaUranusHotfixInit = GetLuaFunction("Main_UranusHotfixInit");
        luaUranusHotfixFunc = GetLuaFunction("Main_UranusHotfixFunc");

        // 先初始化protobuf
        var initProtobuf = GetLuaFunction("InitProtobuf");
        if (initProtobuf != null)
        {
            byte[] pb_bytes = mResExtract.GetFileBytes("lmsg_proto.bytes");

            if (pb_bytes != null)
            {
                initProtobuf.Call(pb_bytes);

                // FIXME 看下pbc里是否需要外部保留这个byte[]
                // dictBundle.Remove("lmsg_proto");

                GameDebug.Log("Load protobuf successed!!!");
            }
            else
            {
                GameDebug.LogError("Load protobuf failed!!!");
            }
        }

        CallLuaFunction("Main");
    }

    public bool IsLuaScriptExist(string fileName)
    {
        if (mResExtract != null)
        {
            string path = XLua.XUtils.LuaPath(fileName);
            return mResExtract.IsExistFile(path);
        }

        return false;
    }

    ResExtract mResExtract = null;
    public void ReloadBytes(byte[] bytes)
    {
        if (mResExtract != null)
            mResExtract.Destroy();

        mResExtract = new ResExtract(bytes);
    }

    public bool IsLoaded()
    {
        return mResExtract != null;
    }

    public void Start()
    {
        OnBundleLoaded();
    }

    public void Destroy()
    {
        if (Lua == null)
        {
            return;
        }

        SafeRelease(ref updateFunc);
        SafeRelease(ref luaUranusHotfixInit);
        SafeRelease(ref luaUranusHotfixFunc);

        //XLua.LuaDLL.Lua.lua_gc(Lua.L, LuaGCOptions.LUA_GCCOLLECT, 0);
        Lua.FullGc();

        Lua.Dispose();
        Lua = null;

        GameDebug.Log("Lua module destroy");
    }

    public void Update()
    {
        if (updateFunc != null)
        {
            updateFunc.Call(null, null);
        }
    }

    public int UranusHotfixInit(bool is_condition, string class_name, string args)
    {
        if (luaUranusHotfixInit != null)
        {
            return luaUranusHotfixInit.Func<bool, string, string, int>(is_condition, class_name, args);
        }
        return 0;
    }

    public int UranusHotfixFunc(int id, string func_name)
    {
        if (luaUranusHotfixFunc != null)
        {
            return luaUranusHotfixFunc.Func<int, string, int>(id, func_name);
        }
        return 0;
    }

    public void Reset(bool ignore_reconnect)
    {
        CallLuaFunction("Main_Reset", ignore_reconnect);
    }

    void SafeRelease(ref LuaFunction func)
    {
        if (func != null)
        {
            func.Dispose();
            func = null;
        }
    }

    public object[] DoString(string str, string chunkName = "chunk")
    {
        return Lua.DoString(str, chunkName);
    }

    public object[] DoStringBinary(byte[] data, string chunkName = "chunk")
    {
        return Lua.DoStringBinary(data, chunkName);
    }

    public object[] DoFile(string fileName)
    {
        if (mResExtract == null)
            return null;

        string path = XLua.XUtils.LuaPath(fileName);
        var fileBytes = mResExtract.GetFileBytes(path);
        if (fileBytes != null)
        {
            return DoStringBinary(fileBytes, path);
        }

        return null;
    }

    public object Require(string fileName, bool reload = false)
    {
        object ret = null;
        if (!reload && mRequireDict.TryGetValue(fileName, out ret))
            return ret;

        var file_ret = DoFile(fileName);
        if (file_ret != null && file_ret.Length > 0)
        {
            ret = file_ret[0];

#if UNITY_ANDROID || UNITY_IPHONE
            mRequireDict[fileName] = ret;
#else
            // windows下为了方便测试，每次require都会dofile一次
#endif
        }

        return ret;
    }

    /// <summary>
    /// 移除掉Lua对象的引用，当调用Lua对象的Dispose函数析构的时候一定要调用一次这个
    /// </summary>
    /// <param name="fileName"></param>
    public void RemoveRequire(string fileName)
    {
        if (mRequireDict.ContainsKey(fileName))
        {
            mRequireDict.Remove(fileName);
        }
    }

    public object[] CallLuaFunction(string name, params object[] args)
    {
        return CallLuaFunction(Lua.Global, name, args);
    }

    public object[] CallLuaFunction(LuaTable luaTable, string name, params object[] args)
    {
        // LuaEnv是否为空
        if (LuaScriptMgr.Instance.Lua == null)
        {
            GameDebug.LogError("Can not call lua function " + name + ", lua env is null!!!");
            return null;
        }

        LuaFunction func = GetLuaFunction(luaTable, name);
        if (func != null)
        {
            return func.Call(args);
        }

        GameDebug.LogError("Can not find lua function " + name + " in table " + luaTable.ToString());
        return null;
    }

    public object[] CallLuaFunction_return(LuaTable luaTable, string name, object[] args, Type[] returnTypes)
    {
        // LuaEnv是否为空
        if (LuaScriptMgr.Instance.Lua == null)
        {
            GameDebug.LogError("Can not call lua function " + name + "with return, lua env is null!!!");
            return null;
        }

        LuaFunction func = GetLuaFunction(luaTable, name);
        if (func != null)
        {
            return func.Call(args, returnTypes);
        }

        GameDebug.LogError("Can not find lua function " + name + " in table " + luaTable.ToString());
        return null;
    }

    public LuaFunction GetLuaFunction(string name)
    {
        // LuaEnv是否为空
        if (LuaScriptMgr.Instance.Lua == null)
        {
            return null;
        }

        return GetLuaFunction(Lua.Global, name);
    }

    public LuaFunction GetLuaFunction(LuaTable luaTable, string name)
    {
        return luaTable.Get<LuaFunction>(name) as LuaFunction;
    }

    /// <summary>
    /// 打印Lua下的堆栈信息
    /// </summary>
    /// <param name="L"></param>
    public static void PrintLuaStack( System.IntPtr L, string msg)
    {
        if (L == null)
            return;

        XLua.LuaDLL.Lua.xlua_getglobal(L, "debug");
        XLua.LuaDLL.Lua.xlua_pgettable_bypath(L, -1, "traceback");
        var error = XLua.LuaDLL.Lua.lua_pcall(L, 0, 1, 0);
        var str = XLua.LuaDLL.Lua.lua_tostring(L, -1);

        GameDebug.Log(string.Format("{0} {1}", msg, str));
    }
}
