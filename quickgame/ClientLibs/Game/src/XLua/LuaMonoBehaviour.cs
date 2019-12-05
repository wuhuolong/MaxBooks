//------------------------------------------------------------------------------
// Desc   :  Lua模拟Unity的MonoBehaviour
// Author :  ljy
// Date   :  2018.5.14
//------------------------------------------------------------------------------
using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using XLua;
using System;

[LuaCallCSharp]
public class LuaMonoBehaviour : MonoBehaviour
{
    public string mLuaScript;

    private LuaTable mLuaTable;

    private Dictionary<string, Action> mFuncDict = new Dictionary<string, Action>();

    /// <summary>
    /// 初始化
    /// </summary>
    /// <param name="luaScript">lua脚本的路径</param>
    public void Init(string luaScript)
    {
        if (LuaScriptMgr.Instance != null && LuaScriptMgr.Instance.IsLuaScriptExist(luaScript) == true)
        {
            mLuaTable = LuaScriptMgr.Instance.Require(luaScript) as LuaTable;

            CallLuaFunc<GameObject>("SetGameObject", this.gameObject);
        }
        else
        {
            GameDebug.LogError("LuaMonoBehaviour load script error, can not find script file: " + luaScript);
        }

        mLuaScript = luaScript;

        mFuncDict.Clear();
        mFuncDict.Add("Start", GetLuaFunc("Start"));
        mFuncDict.Add("OnDestroy", GetLuaFunc("OnDestroy"));
        mFuncDict.Add("OnEnable", GetLuaFunc("OnEnable"));
        mFuncDict.Add("OnDisable", GetLuaFunc("OnDisable"));

        //GameDebug.LogError("Init");
    }

    // Use this for initialization
    void Start()
    {
        CallLuaFunc("Start");

        //GameDebug.LogError("OnDisable");
    }

    void OnDestroy()
    {
        CallLuaFunc("OnDestroy");

        /*if (mLuaTable != null)
        {
            mLuaTable.Dispose();
            mLuaTable = null;
        }
        LuaScriptMgr.Instance.RemoveRequire(mLuaScript);*/

        mFuncDict.Clear();

        //GameDebug.LogError("OnDestroy");
    }

    void OnEnable()
    {
        CallLuaFunc("OnEnable");

        //GameDebug.LogError("OnEnable");
    }

    void OnDisable()
    {
        CallLuaFunc("OnDisable");

        //GameDebug.LogError("OnDisable");
    }


    /// <summary>
    /// 获取lua的函数
    /// </summary>
    /// <param name="func_name"></param>
    /// <returns></returns>
    Action GetLuaFunc(string func_name)
    {
        if (mLuaTable != null)
        {
            Action action = mLuaTable.Get<Action>(func_name);
            return action;
        }
        return null;
    }

    bool CallLuaFunc(string func_name)
    {
        // LuaEnv是否为空
        if (LuaScriptMgr.Instance.Lua == null)
        {
            return false;
        }

        Action action = null;
        mFuncDict.TryGetValue(func_name, out action);
        if (action != null)
        {
            action();
            return true;
        }

        return false;
    }

    bool CallLuaFunc<T>(string func_name, T param)
    {
        // LuaEnv是否为空
        if (LuaScriptMgr.Instance.Lua == null)
        {
            return false;
        }

        if (mLuaTable != null)
        {
            Action<T> action = mLuaTable.Get<Action<T>>(func_name);
            if (action != null)
            {
                action(param);
                return true;
            }
        }
        return false;
    }
}
