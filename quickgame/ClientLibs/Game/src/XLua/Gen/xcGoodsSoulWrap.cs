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
    public class xcGoodsSoulWrap
    {
        public static void __Register(RealStatePtr L)
        {
			ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			XUtils.BeginObjectRegister(typeof(xc.GoodsSoul), L, translator, 0, 4, 19, 12);
			
			XUtils.RegisterFunc(L, XUtils.METHOD_IDX, "UpdateSoul", _m_UpdateSoul);
			XUtils.RegisterFunc(L, XUtils.METHOD_IDX, "GetTextByAttr", _m_GetTextByAttr);
			XUtils.RegisterFunc(L, XUtils.METHOD_IDX, "RefreshSoulCanInstallHole", _m_RefreshSoulCanInstallHole);
			XUtils.RegisterFunc(L, XUtils.METHOD_IDX, "IsHaveSame", _m_IsHaveSame);
			
			
			XUtils.RegisterFunc(L, XUtils.GETTER_IDX, "HolyWater", _g_get_HolyWater);
            XUtils.RegisterFunc(L, XUtils.GETTER_IDX, "can_use", _g_get_can_use);
            XUtils.RegisterFunc(L, XUtils.GETTER_IDX, "BasicAttrs", _g_get_BasicAttrs);
            XUtils.RegisterFunc(L, XUtils.GETTER_IDX, "MaxBasicAttrs", _g_get_MaxBasicAttrs);
            XUtils.RegisterFunc(L, XUtils.GETTER_IDX, "name", _g_get_name);
            XUtils.RegisterFunc(L, XUtils.GETTER_IDX, "SoulType", _g_get_SoulType);
            XUtils.RegisterFunc(L, XUtils.GETTER_IDX, "IsExpSoul", _g_get_IsExpSoul);
            XUtils.RegisterFunc(L, XUtils.GETTER_IDX, "TypeList", _g_get_TypeList);
            XUtils.RegisterFunc(L, XUtils.GETTER_IDX, "TypeCount", _g_get_TypeCount);
            XUtils.RegisterFunc(L, XUtils.GETTER_IDX, "NetSoul", _g_get_NetSoul);
            XUtils.RegisterFunc(L, XUtils.GETTER_IDX, "Lv", _g_get_Lv);
            XUtils.RegisterFunc(L, XUtils.GETTER_IDX, "ResolveGetVal", _g_get_ResolveGetVal);
            XUtils.RegisterFunc(L, XUtils.GETTER_IDX, "IsMaxLv", _g_get_IsMaxLv);
            XUtils.RegisterFunc(L, XUtils.GETTER_IDX, "UpLvNeedVal", _g_get_UpLvNeedVal);
            XUtils.RegisterFunc(L, XUtils.GETTER_IDX, "HoleId", _g_get_HoleId);
            XUtils.RegisterFunc(L, XUtils.GETTER_IDX, "MaxLv", _g_get_MaxLv);
            XUtils.RegisterFunc(L, XUtils.GETTER_IDX, "Tips", _g_get_Tips);
            XUtils.RegisterFunc(L, XUtils.GETTER_IDX, "CurLvHaveVal", _g_get_CurLvHaveVal);
            XUtils.RegisterFunc(L, XUtils.GETTER_IDX, "mCanInstallHole", _g_get_mCanInstallHole);
            
			XUtils.RegisterFunc(L, XUtils.SETTER_IDX, "can_use", _s_set_can_use);
            XUtils.RegisterFunc(L, XUtils.SETTER_IDX, "name", _s_set_name);
            XUtils.RegisterFunc(L, XUtils.SETTER_IDX, "NetSoul", _s_set_NetSoul);
            XUtils.RegisterFunc(L, XUtils.SETTER_IDX, "Lv", _s_set_Lv);
            XUtils.RegisterFunc(L, XUtils.SETTER_IDX, "ResolveGetVal", _s_set_ResolveGetVal);
            XUtils.RegisterFunc(L, XUtils.SETTER_IDX, "IsMaxLv", _s_set_IsMaxLv);
            XUtils.RegisterFunc(L, XUtils.SETTER_IDX, "UpLvNeedVal", _s_set_UpLvNeedVal);
            XUtils.RegisterFunc(L, XUtils.SETTER_IDX, "HoleId", _s_set_HoleId);
            XUtils.RegisterFunc(L, XUtils.SETTER_IDX, "MaxLv", _s_set_MaxLv);
            XUtils.RegisterFunc(L, XUtils.SETTER_IDX, "Tips", _s_set_Tips);
            XUtils.RegisterFunc(L, XUtils.SETTER_IDX, "CurLvHaveVal", _s_set_CurLvHaveVal);
            XUtils.RegisterFunc(L, XUtils.SETTER_IDX, "mCanInstallHole", _s_set_mCanInstallHole);
            
			XUtils.EndObjectRegister(typeof(xc.GoodsSoul), L, translator, null, null,
			    null, null, null);

		    XUtils.BeginClassRegister(typeof(xc.GoodsSoul), L, __CreateInstance, 1, 0, 0);
			
			
            
            XUtils.RegisterObject(L, translator, XUtils.CLS_IDX, "UnderlyingSystemType", typeof(xc.GoodsSoul));
			
			
			XUtils.EndClassRegister(typeof(xc.GoodsSoul), L, translator);
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int __CreateInstance(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			try {
				if(LuaAPI.lua_gettop(L) == 3 && LuaTypes.LUA_TNUMBER == LuaAPI.lua_type(L, 2) && translator.Assignable<Net.PkgGoodsInfo>(L, 3))
				{
					uint typeId = LuaAPI.xlua_touint(L, 2);
					Net.PkgGoodsInfo info = (Net.PkgGoodsInfo)translator.GetObject(L, 3, typeof(Net.PkgGoodsInfo));
					
					xc.GoodsSoul __cl_gen_ret = new xc.GoodsSoul(typeId, info);
					translator.Push(L, __cl_gen_ret);
					return 1;
				}
				
			}
			catch(System.Exception __gen_e) {
				return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
			}
            return LuaAPI.luaL_error(L, "invalid arguments to xc.GoodsSoul constructor!");
            
        }
        
		
        
		
        
        
        
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_UpdateSoul(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            xc.GoodsSoul __cl_gen_to_be_invoked = (xc.GoodsSoul)translator.FastGetCSObj(L, 1);
            
            
			int __gen_param_count = LuaAPI.lua_gettop(L);
            
            try {
                if(__gen_param_count == 1) 
                {
                    
                    __cl_gen_to_be_invoked.UpdateSoul(  );
                    
                    
                    
                    return 0;
                }
                if(__gen_param_count == 2&& LuaTypes.LUA_TNUMBER == LuaAPI.lua_type(L, 2)) 
                {
                    uint lv = LuaAPI.xlua_touint(L, 2);
                    
                    __cl_gen_to_be_invoked.UpdateSoul( lv );
                    
                    
                    
                    return 0;
                }
                if(__gen_param_count == 2&& translator.Assignable<Net.PkgSoul>(L, 2)) 
                {
                    Net.PkgSoul soul = (Net.PkgSoul)translator.GetObject(L, 2, typeof(Net.PkgSoul));
                    
                    __cl_gen_to_be_invoked.UpdateSoul( soul );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
            return LuaAPI.luaL_error(L, "invalid arguments to xc.GoodsSoul.UpdateSoul!");
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_GetTextByAttr(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            xc.GoodsSoul __cl_gen_to_be_invoked = (xc.GoodsSoul)translator.FastGetCSObj(L, 1);
            
            
            try {
                
                {
                    xc.ActorAttribute attr = (xc.ActorAttribute)translator.GetObject(L, 2, typeof(xc.ActorAttribute));
                    
                        string __cl_gen_ret = __cl_gen_to_be_invoked.GetTextByAttr( attr );
                        LuaAPI.lua_pushstring(L, __cl_gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_RefreshSoulCanInstallHole(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            xc.GoodsSoul __cl_gen_to_be_invoked = (xc.GoodsSoul)translator.FastGetCSObj(L, 1);
            
            
            try {
                
                {
                    uint holdId = LuaAPI.xlua_touint(L, 2);
                    
                    __cl_gen_to_be_invoked.RefreshSoulCanInstallHole( holdId );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_IsHaveSame(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            xc.GoodsSoul __cl_gen_to_be_invoked = (xc.GoodsSoul)translator.FastGetCSObj(L, 1);
            
            
            try {
                
                {
                    System.Collections.Generic.List<uint> listA = (System.Collections.Generic.List<uint>)translator.GetObject(L, 2, typeof(System.Collections.Generic.List<uint>));
                    
                        bool __cl_gen_ret = __cl_gen_to_be_invoked.IsHaveSame( listA );
                        LuaAPI.lua_pushboolean(L, __cl_gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        
        
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_HolyWater(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.GoodsSoul __cl_gen_to_be_invoked = (xc.GoodsSoul)translator.FastGetCSObj(L, 1);
                LuaAPI.xlua_pushuint(L, __cl_gen_to_be_invoked.HolyWater);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_can_use(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.GoodsSoul __cl_gen_to_be_invoked = (xc.GoodsSoul)translator.FastGetCSObj(L, 1);
                LuaAPI.lua_pushboolean(L, __cl_gen_to_be_invoked.can_use);
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
			
                xc.GoodsSoul __cl_gen_to_be_invoked = (xc.GoodsSoul)translator.FastGetCSObj(L, 1);
                translator.Push(L, __cl_gen_to_be_invoked.BasicAttrs);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_MaxBasicAttrs(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.GoodsSoul __cl_gen_to_be_invoked = (xc.GoodsSoul)translator.FastGetCSObj(L, 1);
                translator.Push(L, __cl_gen_to_be_invoked.MaxBasicAttrs);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_name(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.GoodsSoul __cl_gen_to_be_invoked = (xc.GoodsSoul)translator.FastGetCSObj(L, 1);
                LuaAPI.lua_pushstring(L, __cl_gen_to_be_invoked.name);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_SoulType(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.GoodsSoul __cl_gen_to_be_invoked = (xc.GoodsSoul)translator.FastGetCSObj(L, 1);
                LuaAPI.xlua_pushuint(L, __cl_gen_to_be_invoked.SoulType);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_IsExpSoul(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.GoodsSoul __cl_gen_to_be_invoked = (xc.GoodsSoul)translator.FastGetCSObj(L, 1);
                LuaAPI.lua_pushboolean(L, __cl_gen_to_be_invoked.IsExpSoul);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_TypeList(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.GoodsSoul __cl_gen_to_be_invoked = (xc.GoodsSoul)translator.FastGetCSObj(L, 1);
                translator.Push(L, __cl_gen_to_be_invoked.TypeList);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_TypeCount(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.GoodsSoul __cl_gen_to_be_invoked = (xc.GoodsSoul)translator.FastGetCSObj(L, 1);
                LuaAPI.xlua_pushuint(L, __cl_gen_to_be_invoked.TypeCount);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_NetSoul(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.GoodsSoul __cl_gen_to_be_invoked = (xc.GoodsSoul)translator.FastGetCSObj(L, 1);
                translator.Push(L, __cl_gen_to_be_invoked.NetSoul);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_Lv(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.GoodsSoul __cl_gen_to_be_invoked = (xc.GoodsSoul)translator.FastGetCSObj(L, 1);
                LuaAPI.xlua_pushuint(L, __cl_gen_to_be_invoked.Lv);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_ResolveGetVal(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.GoodsSoul __cl_gen_to_be_invoked = (xc.GoodsSoul)translator.FastGetCSObj(L, 1);
                LuaAPI.xlua_pushuint(L, __cl_gen_to_be_invoked.ResolveGetVal);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_IsMaxLv(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.GoodsSoul __cl_gen_to_be_invoked = (xc.GoodsSoul)translator.FastGetCSObj(L, 1);
                LuaAPI.lua_pushboolean(L, __cl_gen_to_be_invoked.IsMaxLv);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_UpLvNeedVal(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.GoodsSoul __cl_gen_to_be_invoked = (xc.GoodsSoul)translator.FastGetCSObj(L, 1);
                LuaAPI.xlua_pushuint(L, __cl_gen_to_be_invoked.UpLvNeedVal);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_HoleId(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.GoodsSoul __cl_gen_to_be_invoked = (xc.GoodsSoul)translator.FastGetCSObj(L, 1);
                LuaAPI.xlua_pushuint(L, __cl_gen_to_be_invoked.HoleId);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_MaxLv(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.GoodsSoul __cl_gen_to_be_invoked = (xc.GoodsSoul)translator.FastGetCSObj(L, 1);
                LuaAPI.xlua_pushuint(L, __cl_gen_to_be_invoked.MaxLv);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_Tips(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.GoodsSoul __cl_gen_to_be_invoked = (xc.GoodsSoul)translator.FastGetCSObj(L, 1);
                LuaAPI.lua_pushstring(L, __cl_gen_to_be_invoked.Tips);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_CurLvHaveVal(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.GoodsSoul __cl_gen_to_be_invoked = (xc.GoodsSoul)translator.FastGetCSObj(L, 1);
                LuaAPI.xlua_pushuint(L, __cl_gen_to_be_invoked.CurLvHaveVal);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_mCanInstallHole(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.GoodsSoul __cl_gen_to_be_invoked = (xc.GoodsSoul)translator.FastGetCSObj(L, 1);
                LuaAPI.lua_pushboolean(L, __cl_gen_to_be_invoked.mCanInstallHole);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_can_use(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.GoodsSoul __cl_gen_to_be_invoked = (xc.GoodsSoul)translator.FastGetCSObj(L, 1);
                __cl_gen_to_be_invoked.can_use = LuaAPI.lua_toboolean(L, 2);
            
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_name(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.GoodsSoul __cl_gen_to_be_invoked = (xc.GoodsSoul)translator.FastGetCSObj(L, 1);
                __cl_gen_to_be_invoked.name = LuaAPI.lua_tostring(L, 2);
            
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_NetSoul(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.GoodsSoul __cl_gen_to_be_invoked = (xc.GoodsSoul)translator.FastGetCSObj(L, 1);
                __cl_gen_to_be_invoked.NetSoul = (Net.PkgSoul)translator.GetObject(L, 2, typeof(Net.PkgSoul));
            
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_Lv(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.GoodsSoul __cl_gen_to_be_invoked = (xc.GoodsSoul)translator.FastGetCSObj(L, 1);
                __cl_gen_to_be_invoked.Lv = LuaAPI.xlua_touint(L, 2);
            
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_ResolveGetVal(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.GoodsSoul __cl_gen_to_be_invoked = (xc.GoodsSoul)translator.FastGetCSObj(L, 1);
                __cl_gen_to_be_invoked.ResolveGetVal = LuaAPI.xlua_touint(L, 2);
            
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_IsMaxLv(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.GoodsSoul __cl_gen_to_be_invoked = (xc.GoodsSoul)translator.FastGetCSObj(L, 1);
                __cl_gen_to_be_invoked.IsMaxLv = LuaAPI.lua_toboolean(L, 2);
            
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_UpLvNeedVal(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.GoodsSoul __cl_gen_to_be_invoked = (xc.GoodsSoul)translator.FastGetCSObj(L, 1);
                __cl_gen_to_be_invoked.UpLvNeedVal = LuaAPI.xlua_touint(L, 2);
            
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_HoleId(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.GoodsSoul __cl_gen_to_be_invoked = (xc.GoodsSoul)translator.FastGetCSObj(L, 1);
                __cl_gen_to_be_invoked.HoleId = LuaAPI.xlua_touint(L, 2);
            
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_MaxLv(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.GoodsSoul __cl_gen_to_be_invoked = (xc.GoodsSoul)translator.FastGetCSObj(L, 1);
                __cl_gen_to_be_invoked.MaxLv = LuaAPI.xlua_touint(L, 2);
            
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_Tips(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.GoodsSoul __cl_gen_to_be_invoked = (xc.GoodsSoul)translator.FastGetCSObj(L, 1);
                __cl_gen_to_be_invoked.Tips = LuaAPI.lua_tostring(L, 2);
            
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_CurLvHaveVal(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.GoodsSoul __cl_gen_to_be_invoked = (xc.GoodsSoul)translator.FastGetCSObj(L, 1);
                __cl_gen_to_be_invoked.CurLvHaveVal = LuaAPI.xlua_touint(L, 2);
            
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_mCanInstallHole(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.GoodsSoul __cl_gen_to_be_invoked = (xc.GoodsSoul)translator.FastGetCSObj(L, 1);
                __cl_gen_to_be_invoked.mCanInstallHole = LuaAPI.lua_toboolean(L, 2);
            
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 0;
        }
        
		
		
		
		
    }
}
