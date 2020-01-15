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
    public class xcEquipPosInfoWrap
    {
        public static void __Register(RealStatePtr L)
        {
			ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			XUtils.BeginObjectRegister(typeof(xc.EquipPosInfo), L, translator, 0, 0, 14, 13);
			
			
			
			XUtils.RegisterFunc(L, XUtils.GETTER_IDX, "ReachMaxStrengthLv", _g_get_ReachMaxStrengthLv);
            XUtils.RegisterFunc(L, XUtils.GETTER_IDX, "Pos", _g_get_Pos);
            XUtils.RegisterFunc(L, XUtils.GETTER_IDX, "Index", _g_get_Index);
            XUtils.RegisterFunc(L, XUtils.GETTER_IDX, "IsCanStrength", _g_get_IsCanStrength);
            XUtils.RegisterFunc(L, XUtils.GETTER_IDX, "SortId", _g_get_SortId);
            XUtils.RegisterFunc(L, XUtils.GETTER_IDX, "StrengthLv", _g_get_StrengthLv);
            XUtils.RegisterFunc(L, XUtils.GETTER_IDX, "StrengthDegree", _g_get_StrengthDegree);
            XUtils.RegisterFunc(L, XUtils.GETTER_IDX, "StrengthMaxDegree", _g_get_StrengthMaxDegree);
            XUtils.RegisterFunc(L, XUtils.GETTER_IDX, "StrengthStuff", _g_get_StrengthStuff);
            XUtils.RegisterFunc(L, XUtils.GETTER_IDX, "StrengthShowRedPointGoods", _g_get_StrengthShowRedPointGoods);
            XUtils.RegisterFunc(L, XUtils.GETTER_IDX, "InstallPosEquip", _g_get_InstallPosEquip);
            XUtils.RegisterFunc(L, XUtils.GETTER_IDX, "AllBaptizeAttr", _g_get_AllBaptizeAttr);
            XUtils.RegisterFunc(L, XUtils.GETTER_IDX, "BaptizeNeedLv", _g_get_BaptizeNeedLv);
            XUtils.RegisterFunc(L, XUtils.GETTER_IDX, "BaptizeInfos", _g_get_BaptizeInfos);
            
			XUtils.RegisterFunc(L, XUtils.SETTER_IDX, "Pos", _s_set_Pos);
            XUtils.RegisterFunc(L, XUtils.SETTER_IDX, "Index", _s_set_Index);
            XUtils.RegisterFunc(L, XUtils.SETTER_IDX, "IsCanStrength", _s_set_IsCanStrength);
            XUtils.RegisterFunc(L, XUtils.SETTER_IDX, "SortId", _s_set_SortId);
            XUtils.RegisterFunc(L, XUtils.SETTER_IDX, "StrengthLv", _s_set_StrengthLv);
            XUtils.RegisterFunc(L, XUtils.SETTER_IDX, "StrengthDegree", _s_set_StrengthDegree);
            XUtils.RegisterFunc(L, XUtils.SETTER_IDX, "StrengthMaxDegree", _s_set_StrengthMaxDegree);
            XUtils.RegisterFunc(L, XUtils.SETTER_IDX, "StrengthStuff", _s_set_StrengthStuff);
            XUtils.RegisterFunc(L, XUtils.SETTER_IDX, "StrengthShowRedPointGoods", _s_set_StrengthShowRedPointGoods);
            XUtils.RegisterFunc(L, XUtils.SETTER_IDX, "InstallPosEquip", _s_set_InstallPosEquip);
            XUtils.RegisterFunc(L, XUtils.SETTER_IDX, "AllBaptizeAttr", _s_set_AllBaptizeAttr);
            XUtils.RegisterFunc(L, XUtils.SETTER_IDX, "BaptizeNeedLv", _s_set_BaptizeNeedLv);
            XUtils.RegisterFunc(L, XUtils.SETTER_IDX, "BaptizeInfos", _s_set_BaptizeInfos);
            
			XUtils.EndObjectRegister(typeof(xc.EquipPosInfo), L, translator, null, null,
			    null, null, null);

		    XUtils.BeginClassRegister(typeof(xc.EquipPosInfo), L, __CreateInstance, 1, 0, 0);
			
			
            
            XUtils.RegisterObject(L, translator, XUtils.CLS_IDX, "UnderlyingSystemType", typeof(xc.EquipPosInfo));
			
			
			XUtils.EndClassRegister(typeof(xc.EquipPosInfo), L, translator);
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int __CreateInstance(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			try {
				if(LuaAPI.lua_gettop(L) == 1)
				{
					
					xc.EquipPosInfo __cl_gen_ret = new xc.EquipPosInfo();
					translator.Push(L, __cl_gen_ret);
					return 1;
				}
				
			}
			catch(System.Exception __gen_e) {
				return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
			}
            return LuaAPI.luaL_error(L, "invalid arguments to xc.EquipPosInfo constructor!");
            
        }
        
		
        
		
        
        
        
        
        
        
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_ReachMaxStrengthLv(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.EquipPosInfo __cl_gen_to_be_invoked = (xc.EquipPosInfo)translator.FastGetCSObj(L, 1);
                LuaAPI.lua_pushboolean(L, __cl_gen_to_be_invoked.ReachMaxStrengthLv);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_Pos(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.EquipPosInfo __cl_gen_to_be_invoked = (xc.EquipPosInfo)translator.FastGetCSObj(L, 1);
                LuaAPI.xlua_pushuint(L, __cl_gen_to_be_invoked.Pos);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_Index(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.EquipPosInfo __cl_gen_to_be_invoked = (xc.EquipPosInfo)translator.FastGetCSObj(L, 1);
                LuaAPI.xlua_pushuint(L, __cl_gen_to_be_invoked.Index);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_IsCanStrength(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.EquipPosInfo __cl_gen_to_be_invoked = (xc.EquipPosInfo)translator.FastGetCSObj(L, 1);
                LuaAPI.lua_pushboolean(L, __cl_gen_to_be_invoked.IsCanStrength);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_SortId(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.EquipPosInfo __cl_gen_to_be_invoked = (xc.EquipPosInfo)translator.FastGetCSObj(L, 1);
                LuaAPI.xlua_pushuint(L, __cl_gen_to_be_invoked.SortId);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_StrengthLv(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.EquipPosInfo __cl_gen_to_be_invoked = (xc.EquipPosInfo)translator.FastGetCSObj(L, 1);
                LuaAPI.xlua_pushuint(L, __cl_gen_to_be_invoked.StrengthLv);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_StrengthDegree(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.EquipPosInfo __cl_gen_to_be_invoked = (xc.EquipPosInfo)translator.FastGetCSObj(L, 1);
                LuaAPI.xlua_pushuint(L, __cl_gen_to_be_invoked.StrengthDegree);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_StrengthMaxDegree(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.EquipPosInfo __cl_gen_to_be_invoked = (xc.EquipPosInfo)translator.FastGetCSObj(L, 1);
                LuaAPI.xlua_pushuint(L, __cl_gen_to_be_invoked.StrengthMaxDegree);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_StrengthStuff(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.EquipPosInfo __cl_gen_to_be_invoked = (xc.EquipPosInfo)translator.FastGetCSObj(L, 1);
                translator.Push(L, __cl_gen_to_be_invoked.StrengthStuff);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_StrengthShowRedPointGoods(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.EquipPosInfo __cl_gen_to_be_invoked = (xc.EquipPosInfo)translator.FastGetCSObj(L, 1);
                translator.Push(L, __cl_gen_to_be_invoked.StrengthShowRedPointGoods);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_InstallPosEquip(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.EquipPosInfo __cl_gen_to_be_invoked = (xc.EquipPosInfo)translator.FastGetCSObj(L, 1);
                translator.Push(L, __cl_gen_to_be_invoked.InstallPosEquip);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_AllBaptizeAttr(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.EquipPosInfo __cl_gen_to_be_invoked = (xc.EquipPosInfo)translator.FastGetCSObj(L, 1);
                translator.Push(L, __cl_gen_to_be_invoked.AllBaptizeAttr);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_BaptizeNeedLv(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.EquipPosInfo __cl_gen_to_be_invoked = (xc.EquipPosInfo)translator.FastGetCSObj(L, 1);
                LuaAPI.xlua_pushuint(L, __cl_gen_to_be_invoked.BaptizeNeedLv);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_BaptizeInfos(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.EquipPosInfo __cl_gen_to_be_invoked = (xc.EquipPosInfo)translator.FastGetCSObj(L, 1);
                translator.Push(L, __cl_gen_to_be_invoked.BaptizeInfos);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_Pos(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.EquipPosInfo __cl_gen_to_be_invoked = (xc.EquipPosInfo)translator.FastGetCSObj(L, 1);
                __cl_gen_to_be_invoked.Pos = LuaAPI.xlua_touint(L, 2);
            
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_Index(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.EquipPosInfo __cl_gen_to_be_invoked = (xc.EquipPosInfo)translator.FastGetCSObj(L, 1);
                __cl_gen_to_be_invoked.Index = LuaAPI.xlua_touint(L, 2);
            
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_IsCanStrength(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.EquipPosInfo __cl_gen_to_be_invoked = (xc.EquipPosInfo)translator.FastGetCSObj(L, 1);
                __cl_gen_to_be_invoked.IsCanStrength = LuaAPI.lua_toboolean(L, 2);
            
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_SortId(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.EquipPosInfo __cl_gen_to_be_invoked = (xc.EquipPosInfo)translator.FastGetCSObj(L, 1);
                __cl_gen_to_be_invoked.SortId = LuaAPI.xlua_touint(L, 2);
            
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_StrengthLv(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.EquipPosInfo __cl_gen_to_be_invoked = (xc.EquipPosInfo)translator.FastGetCSObj(L, 1);
                __cl_gen_to_be_invoked.StrengthLv = LuaAPI.xlua_touint(L, 2);
            
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_StrengthDegree(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.EquipPosInfo __cl_gen_to_be_invoked = (xc.EquipPosInfo)translator.FastGetCSObj(L, 1);
                __cl_gen_to_be_invoked.StrengthDegree = LuaAPI.xlua_touint(L, 2);
            
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_StrengthMaxDegree(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.EquipPosInfo __cl_gen_to_be_invoked = (xc.EquipPosInfo)translator.FastGetCSObj(L, 1);
                __cl_gen_to_be_invoked.StrengthMaxDegree = LuaAPI.xlua_touint(L, 2);
            
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_StrengthStuff(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.EquipPosInfo __cl_gen_to_be_invoked = (xc.EquipPosInfo)translator.FastGetCSObj(L, 1);
                __cl_gen_to_be_invoked.StrengthStuff = (Net.PkgGoodsGidnum)translator.GetObject(L, 2, typeof(Net.PkgGoodsGidnum));
            
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_StrengthShowRedPointGoods(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.EquipPosInfo __cl_gen_to_be_invoked = (xc.EquipPosInfo)translator.FastGetCSObj(L, 1);
                __cl_gen_to_be_invoked.StrengthShowRedPointGoods = (Net.PkgGoodsGidnum)translator.GetObject(L, 2, typeof(Net.PkgGoodsGidnum));
            
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_InstallPosEquip(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.EquipPosInfo __cl_gen_to_be_invoked = (xc.EquipPosInfo)translator.FastGetCSObj(L, 1);
                __cl_gen_to_be_invoked.InstallPosEquip = (xc.GoodsEquip)translator.GetObject(L, 2, typeof(xc.GoodsEquip));
            
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_AllBaptizeAttr(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.EquipPosInfo __cl_gen_to_be_invoked = (xc.EquipPosInfo)translator.FastGetCSObj(L, 1);
                __cl_gen_to_be_invoked.AllBaptizeAttr = (xc.ActorAttribute)translator.GetObject(L, 2, typeof(xc.ActorAttribute));
            
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_BaptizeNeedLv(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.EquipPosInfo __cl_gen_to_be_invoked = (xc.EquipPosInfo)translator.FastGetCSObj(L, 1);
                __cl_gen_to_be_invoked.BaptizeNeedLv = LuaAPI.xlua_touint(L, 2);
            
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_BaptizeInfos(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.EquipPosInfo __cl_gen_to_be_invoked = (xc.EquipPosInfo)translator.FastGetCSObj(L, 1);
                __cl_gen_to_be_invoked.BaptizeInfos = (System.Collections.Generic.Dictionary<uint, xc.EquipBaptizeInfo>)translator.GetObject(L, 2, typeof(System.Collections.Generic.Dictionary<uint, xc.EquipBaptizeInfo>));
            
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 0;
        }
        
		
		
		
		
    }
}
