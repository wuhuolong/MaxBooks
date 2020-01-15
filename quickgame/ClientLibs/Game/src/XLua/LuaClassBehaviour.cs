//------------------------------------------------------------------------------
// Desc   :  Lua class 模拟Unity的MonoBehaviour 与LuaMonoBehaviour区别在于实例化
// Author :  dengjunjie
// Date   :  2018.11.15
//------------------------------------------------------------------------------
using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using XLua;
using System;

public class LuaClassBehaviour : MonoBehaviour
{
    public string mLuaScript;
    private LuaTable mLuaTable;
    private Dictionary<string, LuaFunction> mFuncDict = new Dictionary<string, LuaFunction>();
    private HashSet<string> mMarkGetFunc = new HashSet<string>();

    /// <summary>
    /// 初始化
    /// </summary>
    /// <param name="luaScript">lua脚本的路径</param>
    public void Init(string luaScript)
    {
        ResetLuaTable();
        mLuaScript = luaScript;
    }

    void Start()
    {
        if (mLuaTable == null)
        {
            if (LuaScriptMgr.Instance != null && LuaScriptMgr.Instance.IsLuaScriptExist(mLuaScript) == true)
            {
                LuaTable classTable = LuaScriptMgr.Instance.Require(mLuaScript) as LuaTable;
                object[] param = { gameObject };
                System.Type[] return_type = { typeof(LuaTable) };
                object[] objs = LuaScriptMgr.Instance.CallLuaFunction_return(classTable, "New", param, return_type);
                if (objs != null && objs.Length > 0)
                {
                    if (objs[0] != null)
                    {
                        mLuaTable = (LuaTable)objs[0];
                    }
                }
            }
            else
            {
                GameDebug.LogError("LuaMonoBehaviour load script error, can not find script file: " + mLuaScript);
            }
        }
        CallLuaFunc("Start");
    }

    void OnDisable()
    {
        CallLuaFunc("OnDisable");
    }

    void OnDestroy()
    {
        CallLuaFunc("OnDestroy");
        ResetLuaTable();
    }

    void ResetLuaTable()
    {
        if (LuaScriptMgr.Instance.Lua != null)
        {
            foreach (LuaFunction val in mFuncDict.Values)
            {
                val.Dispose();
            }
            if (mLuaTable != null)
            {
                mLuaTable.Dispose();
            }
        }
        mLuaTable = null;
        mFuncDict.Clear();
        mMarkGetFunc.Clear();
      
        mLuaScript = "";
    }
    /// <summary>
    /// 获取lua的函数
    /// </summary>
    /// <param name="func_name"></param>
    /// <returns></returns>
    LuaFunction GetLuaFunc(string func_name)
    {
        if (mLuaTable != null)
        {
            LuaFunction action = mLuaTable.Get<LuaFunction>(func_name);
            return action;
        }
        return null;
    }

    bool CallLuaFunc(string func_name)
    {
        // LuaEnv是否为空
        if (LuaScriptMgr.Instance.Lua == null || mLuaTable == null)
        {
            return false;
        }

        //GameDebug.Log("LuaClassBehaviour   " + func_name);

        LuaFunction func = null;
        if (mMarkGetFunc.Contains(func_name))
        {
            mFuncDict.TryGetValue(func_name, out func);
            if (func == null)
            {
                return false;
            }
        }
        else
        {
            func = GetLuaFunc(func_name);
            mMarkGetFunc.Add(func_name);
            if (func != null)
            {
                mFuncDict.Add(func_name, func);
            }
            else
            {
                return false;
            }
        }
        func.Action(mLuaTable);
        return true;
    }
}

