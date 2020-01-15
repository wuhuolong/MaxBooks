#if USE_UNI_LUA
using LuaAPI = UniLua.Lua;
using RealStatePtr = UniLua.ILuaState;
using LuaCSFunction = UniLua.CSharpFunctionDelegate;
#else
using LuaAPI = XLua.LuaDLL.Lua;
using RealStatePtr = System.IntPtr;
using LuaCSFunction = XLua.LuaDLL.lua_CSFunction;
#endif

using XLua;
using System.Collections.Generic;


namespace XLua.CSObjectWrap
{
    using XUtils = XLua.XUtils;
    public class xcGoodsLightWeaponSoulWrap
    {
        public static void __Register(RealStatePtr L)
        {
			ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			XUtils.BeginObjectRegister(typeof(xc.GoodsLightWeaponSoul), L, translator, 0, 0, 11, 3);
			
			
			
			XUtils.RegisterFunc(L, XUtils.GETTER_IDX, "Pos_Type", _g_get_Pos_Type);
            XUtils.RegisterFunc(L, XUtils.GETTER_IDX, "Pos_Index", _g_get_Pos_Index);
            XUtils.RegisterFunc(L, XUtils.GETTER_IDX, "ResolveAmount", _g_get_ResolveAmount);
            XUtils.RegisterFunc(L, XUtils.GETTER_IDX, "ResolveType", _g_get_ResolveType);
            XUtils.RegisterFunc(L, XUtils.GETTER_IDX, "BasicAttrs", _g_get_BasicAttrs);
            XUtils.RegisterFunc(L, XUtils.GETTER_IDX, "Score", _g_get_Score);
            XUtils.RegisterFunc(L, XUtils.GETTER_IDX, "TotalScore", _g_get_TotalScore);
            XUtils.RegisterFunc(L, XUtils.GETTER_IDX, "DBSoul", _g_get_DBSoul);
            XUtils.RegisterFunc(L, XUtils.GETTER_IDX, "Level", _g_get_Level);
            XUtils.RegisterFunc(L, XUtils.GETTER_IDX, "IsWearing", _g_get_IsWearing);
            XUtils.RegisterFunc(L, XUtils.GETTER_IDX, "UpgradeAttrs", _g_get_UpgradeAttrs);
            
			XUtils.RegisterFunc(L, XUtils.SETTER_IDX, "Level", _s_set_Level);
            XUtils.RegisterFunc(L, XUtils.SETTER_IDX, "IsWearing", _s_set_IsWearing);
            XUtils.RegisterFunc(L, XUtils.SETTER_IDX, "UpgradeAttrs", _s_set_UpgradeAttrs);
            
			XUtils.EndObjectRegister(typeof(xc.GoodsLightWeaponSoul), L, translator, null, null,
			    null, null, null);

		    XUtils.BeginClassRegister(typeof(xc.GoodsLightWeaponSoul), L, __CreateInstance, 1, 0, 0);
			
			
            
            XUtils.RegisterObject(L, translator, XUtils.CLS_IDX, "UnderlyingSystemType", typeof(xc.GoodsLightWeaponSoul));
			
			
			XUtils.EndClassRegister(typeof(xc.GoodsLightWeaponSoul), L, translator);
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int __CreateInstance(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			try {
				if(LuaAPI.lua_gettop(L) == 2 && translator.Assignable<Net.PkgGoodsInfo>(L, 2))
				{
					Net.PkgGoodsInfo pkgGoodsInfo = (Net.PkgGoodsInfo)translator.GetObject(L, 2, typeof(Net.PkgGoodsInfo));
					
					xc.GoodsLightWeaponSoul __cl_gen_ret = new xc.GoodsLightWeaponSoul(pkgGoodsInfo);
					translator.Push(L, __cl_gen_ret);
					return 1;
				}
				if(LuaAPI.lua_gettop(L) == 2 && LuaTypes.LUA_TNUMBER == LuaAPI.lua_type(L, 2))
				{
					uint GID = LuaAPI.xlua_touint(L, 2);
					
					xc.GoodsLightWeaponSoul __cl_gen_ret = new xc.GoodsLightWeaponSoul(GID);
					translator.Push(L, __cl_gen_ret);
					return 1;
				}
				
			}
			catch(System.Exception __gen_e) {
				return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
			}
            return LuaAPI.luaL_error(L, "invalid arguments to xc.GoodsLightWeaponSoul constructor!");
            
        }
        
		
        
		
        
        
        
        
        
        
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_Pos_Type(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.GoodsLightWeaponSoul __cl_gen_to_be_invoked = (xc.GoodsLightWeaponSoul)translator.FastGetCSObj(L, 1);
                LuaAPI.xlua_pushuint(L, __cl_gen_to_be_invoked.Pos_Type);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_Pos_Index(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.GoodsLightWeaponSoul __cl_gen_to_be_invoked = (xc.GoodsLightWeaponSoul)translator.FastGetCSObj(L, 1);
                LuaAPI.xlua_pushuint(L, __cl_gen_to_be_invoked.Pos_Index);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_ResolveAmount(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.GoodsLightWeaponSoul __cl_gen_to_be_invoked = (xc.GoodsLightWeaponSoul)translator.FastGetCSObj(L, 1);
                LuaAPI.xlua_pushuint(L, __cl_gen_to_be_invoked.ResolveAmount);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_ResolveType(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.GoodsLightWeaponSoul __cl_gen_to_be_invoked = (xc.GoodsLightWeaponSoul)translator.FastGetCSObj(L, 1);
                LuaAPI.xlua_pushuint(L, __cl_gen_to_be_invoked.ResolveType);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_BasicAttrs(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.GoodsLightWeaponSoul __cl_gen_to_be_invoked = (xc.GoodsLightWeaponSoul)translator.FastGetCSObj(L, 1);
                translator.Push(L, __cl_gen_to_be_invoked.BasicAttrs);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_Score(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.GoodsLightWeaponSoul __cl_gen_to_be_invoked = (xc.GoodsLightWeaponSoul)translator.FastGetCSObj(L, 1);
                LuaAPI.xlua_pushuint(L, __cl_gen_to_be_invoked.Score);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_TotalScore(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.GoodsLightWeaponSoul __cl_gen_to_be_invoked = (xc.GoodsLightWeaponSoul)translator.FastGetCSObj(L, 1);
                LuaAPI.xlua_pushuint(L, __cl_gen_to_be_invoked.TotalScore);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_DBSoul(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.GoodsLightWeaponSoul __cl_gen_to_be_invoked = (xc.GoodsLightWeaponSoul)translator.FastGetCSObj(L, 1);
                translator.Push(L, __cl_gen_to_be_invoked.DBSoul);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_Level(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.GoodsLightWeaponSoul __cl_gen_to_be_invoked = (xc.GoodsLightWeaponSoul)translator.FastGetCSObj(L, 1);
                LuaAPI.xlua_pushuint(L, __cl_gen_to_be_invoked.Level);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_IsWearing(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.GoodsLightWeaponSoul __cl_gen_to_be_invoked = (xc.GoodsLightWeaponSoul)translator.FastGetCSObj(L, 1);
                LuaAPI.lua_pushboolean(L, __cl_gen_to_be_invoked.IsWearing);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_UpgradeAttrs(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.GoodsLightWeaponSoul __cl_gen_to_be_invoked = (xc.GoodsLightWeaponSoul)translator.FastGetCSObj(L, 1);
                translator.Push(L, __cl_gen_to_be_invoked.UpgradeAttrs);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_Level(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.GoodsLightWeaponSoul __cl_gen_to_be_invoked = (xc.GoodsLightWeaponSoul)translator.FastGetCSObj(L, 1);
                __cl_gen_to_be_invoked.Level = LuaAPI.xlua_touint(L, 2);
            
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_IsWearing(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.GoodsLightWeaponSoul __cl_gen_to_be_invoked = (xc.GoodsLightWeaponSoul)translator.FastGetCSObj(L, 1);
                __cl_gen_to_be_invoked.IsWearing = LuaAPI.lua_toboolean(L, 2);
            
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_UpgradeAttrs(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.GoodsLightWeaponSoul __cl_gen_to_be_invoked = (xc.GoodsLightWeaponSoul)translator.FastGetCSObj(L, 1);
                __cl_gen_to_be_invoked.UpgradeAttrs = (xc.ActorAttribute)translator.GetObject(L, 2, typeof(xc.ActorAttribute));
            
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 0;
        }
        
		
		
		
		
    }
}
