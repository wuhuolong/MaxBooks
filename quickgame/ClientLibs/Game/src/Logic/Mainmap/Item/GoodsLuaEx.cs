using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using xc;
using XLua;
using System;

namespace xc
{
    [wxb.Hotfix]
    public class GoodsLuaEx: GoodsItem
    {
        string mLuaScript;
        LuaTable mLuaTable;
        public Dictionary<string, string> ExData = new Dictionary<string, string>();
        protected Dictionary<string, LuaFunction> LuaMethods { get; set; }
        public GoodsLuaEx()
        {

        }
        public GoodsLuaEx(uint typeid , string lua_script)
        {
            CreateGoodsByTypeId(typeid);

            mLuaScript = lua_script;
            if (LuaScriptMgr.Instance != null && LuaScriptMgr.Instance.IsLuaScriptExist(mLuaScript) == true)
            {
                LuaTable classTable = LuaScriptMgr.Instance.Require(mLuaScript) as LuaTable;
                object[] param = { this };
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
                GameDebug.LogError("GoodsLuaEx load script error, can not find script file, typeid:" + typeid + ", script:" + lua_script);
            }

            LuaMethods = new Dictionary<string, LuaFunction>();
            if (mLuaTable != null)
            {
                LuaMethods["UpdateByPkgGoodsInfo"] = mLuaTable.Get<LuaFunction>("UpdateByPkgGoodsInfo");
                LuaMethods["SetItemSlot"] = mLuaTable.Get<LuaFunction>("SetItemSlot");
                LuaMethods["RefreshMatch"] = mLuaTable.Get<LuaFunction>("RefreshMatch");
            }
        }

        ~GoodsLuaEx()
        {
            mLuaTable = null;
            if (LuaMethods != null)
            {
                LuaMethods.Clear();
                LuaMethods = null;
            }
        }

        public void UpdateByPkgGoodsInfo(LuaTable goodsInfo)
        {
            CallLuaFunc("UpdateByPkgGoodsInfo", mLuaTable, goodsInfo);
        }

        public LuaTable LuaObject
        {
            get
            {
                return mLuaTable;
            }
        }

        bool CallLuaFunc<T>(string func_name,T param)
        {
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

        protected bool CallLuaFunc(string func_name, params object[] args)
        {
            if (LuaMethods != null)
            {
                LuaFunction method;
                if (LuaMethods.TryGetValue(func_name, out method))
                {
                    if (method != null)
                    {
                        method.Call(args);

                        return true;
                    }
                    else
                    {
                        //GameDebug.LogWarning("Can not find method " + func_name + " with file " + LuaScriptFileName);
                    }
                }
            }

            return false;
        }

        public bool CallLuaFunc(string func_name)
        {
            if (mLuaTable != null)
            {
                Action action = mLuaTable.Get<Action>(func_name);
                if (action != null)
                {
                    action();
                    return true;
                }
            }
            return false;
        }

        public object GetLuaValue(string key)
        {
            if (mLuaTable != null)
            {
                LuaFunction function = mLuaTable.Get<LuaFunction>("GetLuaValue");
                if (function != null)
                {
                    object[] param = { mLuaTable, key };
                    object[] result = function.Call(param);
                    if (result != null && result.Length > 0)
                    {
                        return result[0];
                    }
                }
            }
            return null;
        }

        public object SetLuaValue(string key, object value)
        {
            if (mLuaTable != null)
            {
                LuaFunction function = mLuaTable.Get<LuaFunction>("SetLuaValue");
                if (function != null)
                {
                    object[] param = { mLuaTable, key, value };
                    function.Call(param);
                }
            }
            return null;
        }

        //public T GetLuaValue<T>(string key)
        //{
        //    if (mLuaTable != null)
        //    {
        //        LuaFunction function = mLuaTable.Get<LuaFunction>("GetValue");
        //        if (function != null)
        //        {
        //            object[] param = { mLuaTable, key };
        //            Type[] returnTypes = { typeof(T) };
        //            object[] result = function.Call(param, returnTypes);
        //            if (result != null && result.Length > 0)
        //            {
        //                return (T)System.Convert.ChangeType(result[0], result[0].GetType());
        //            }
        //        }
        //    }
        //    return default(T);
        //}

        //public string GetLuaStringValue(string key)
        //{
        //    return GetLuaValue<string>(key);
        //}

        /// <summary>
        /// lua下调用
        /// </summary>
        /// <param name="name"></param>
        /// <param name="value"></param>
        public void SetValue(string name, string value)
        {
            if (ExData.ContainsKey(name))
                ExData[name] = value;
            else
                ExData.Add(name, value);
        }

        public void SetItemSlot(GameObject itemSlot)
        {
            CallLuaFunc("SetItemSlot", mLuaTable, itemSlot);
        }

        public void RefreshMatch(Goods matchGoods, GameObject itemSlot)
        {
            CallLuaFunc("RefreshMatch", mLuaTable, matchGoods, itemSlot);
        }

        public bool IsBetterThanBody()
        {
            if (mLuaTable != null)
            {
                LuaFunction function = mLuaTable.Get<LuaFunction>("IsBetterThanBody");
                if (function != null)
                {
                    object[] param = { mLuaTable };
                    Type[] returnTypes = { typeof(bool) };
                    object[] result = function.Call(param, returnTypes);
                    if (result != null && result.Length > 0)
                    {
                        return (bool)result[0];
                    }
                }
            }
            return false;
        }

        public Goods Copy(GoodsLuaEx cp)
        {
            (this as GoodsItem).Copy(cp);
            mLuaTable = cp.mLuaTable;
            foreach(var item in cp.ExData)
            {
                ExData[item.Key] = item.Value;
            }
            if(LuaMethods == null)
                LuaMethods = new Dictionary<string, LuaFunction>();
            foreach (var item in cp.LuaMethods)
            {
                LuaMethods[item.Key] = item.Value;
            }
            return this;
        }
    }
}
