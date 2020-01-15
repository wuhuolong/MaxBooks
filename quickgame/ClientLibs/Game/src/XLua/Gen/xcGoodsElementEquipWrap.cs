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
    public class xcGoodsElementEquipWrap
    {
        public static void __Register(RealStatePtr L)
        {
			ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			XUtils.BeginObjectRegister(typeof(xc.GoodsElementEquip), L, translator, 0, 2, 11, 1);
			
			XUtils.RegisterFunc(L, XUtils.METHOD_IDX, "UpdateGodEquip", _m_UpdateGodEquip);
			XUtils.RegisterFunc(L, XUtils.METHOD_IDX, "IsReward", _m_IsReward);
			
			
			XUtils.RegisterFunc(L, XUtils.GETTER_IDX, "LvStep", _g_get_LvStep);
            XUtils.RegisterFunc(L, XUtils.GETTER_IDX, "Star", _g_get_Star);
            XUtils.RegisterFunc(L, XUtils.GETTER_IDX, "StrenthenLimit", _g_get_StrenthenLimit);
            XUtils.RegisterFunc(L, XUtils.GETTER_IDX, "Exp", _g_get_Exp);
            XUtils.RegisterFunc(L, XUtils.GETTER_IDX, "PosId", _g_get_PosId);
            XUtils.RegisterFunc(L, XUtils.GETTER_IDX, "BasicAttrs", _g_get_BasicAttrs);
            XUtils.RegisterFunc(L, XUtils.GETTER_IDX, "ExtraAttrs", _g_get_ExtraAttrs);
            XUtils.RegisterFunc(L, XUtils.GETTER_IDX, "BaseScore", _g_get_BaseScore);
            XUtils.RegisterFunc(L, XUtils.GETTER_IDX, "ExtraScore", _g_get_ExtraScore);
            XUtils.RegisterFunc(L, XUtils.GETTER_IDX, "Score", _g_get_Score);
            XUtils.RegisterFunc(L, XUtils.GETTER_IDX, "ServerScore", _g_get_ServerScore);
            
			XUtils.RegisterFunc(L, XUtils.SETTER_IDX, "ServerScore", _s_set_ServerScore);
            
			XUtils.EndObjectRegister(typeof(xc.GoodsElementEquip), L, translator, null, null,
			    null, null, null);

		    XUtils.BeginClassRegister(typeof(xc.GoodsElementEquip), L, __CreateInstance, 1, 0, 0);
			
			
            
            XUtils.RegisterObject(L, translator, XUtils.CLS_IDX, "UnderlyingSystemType", typeof(xc.GoodsElementEquip));
			
			
			XUtils.EndClassRegister(typeof(xc.GoodsElementEquip), L, translator);
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int __CreateInstance(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			try {
				if(LuaAPI.lua_gettop(L) == 3 && LuaTypes.LUA_TNUMBER == LuaAPI.lua_type(L, 2) && translator.Assignable<Net.PkgGoodsInfo>(L, 3))
				{
					uint typeId = LuaAPI.xlua_touint(L, 2);
					Net.PkgGoodsInfo elementEquip = (Net.PkgGoodsInfo)translator.GetObject(L, 3, typeof(Net.PkgGoodsInfo));
					
					xc.GoodsElementEquip __cl_gen_ret = new xc.GoodsElementEquip(typeId, elementEquip);
					translator.Push(L, __cl_gen_ret);
					return 1;
				}
				
			}
			catch(System.Exception __gen_e) {
				return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
			}
            return LuaAPI.luaL_error(L, "invalid arguments to xc.GoodsElementEquip constructor!");
            
        }
        
		
        
		
        
        
        
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_UpdateGodEquip(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            xc.GoodsElementEquip __cl_gen_to_be_invoked = (xc.GoodsElementEquip)translator.FastGetCSObj(L, 1);
            
            
            try {
                
                {
                    Net.PkgElementEp elementEquip = (Net.PkgElementEp)translator.GetObject(L, 2, typeof(Net.PkgElementEp));
                    
                    __cl_gen_to_be_invoked.UpdateGodEquip( elementEquip );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_IsReward(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            xc.GoodsElementEquip __cl_gen_to_be_invoked = (xc.GoodsElementEquip)translator.FastGetCSObj(L, 1);
            
            
            try {
                
                {
                    
                        bool __cl_gen_ret = __cl_gen_to_be_invoked.IsReward(  );
                        LuaAPI.lua_pushboolean(L, __cl_gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        
        
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_LvStep(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.GoodsElementEquip __cl_gen_to_be_invoked = (xc.GoodsElementEquip)translator.FastGetCSObj(L, 1);
                LuaAPI.xlua_pushuint(L, __cl_gen_to_be_invoked.LvStep);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_Star(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.GoodsElementEquip __cl_gen_to_be_invoked = (xc.GoodsElementEquip)translator.FastGetCSObj(L, 1);
                LuaAPI.xlua_pushuint(L, __cl_gen_to_be_invoked.Star);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_StrenthenLimit(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.GoodsElementEquip __cl_gen_to_be_invoked = (xc.GoodsElementEquip)translator.FastGetCSObj(L, 1);
                LuaAPI.xlua_pushuint(L, __cl_gen_to_be_invoked.StrenthenLimit);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_Exp(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.GoodsElementEquip __cl_gen_to_be_invoked = (xc.GoodsElementEquip)translator.FastGetCSObj(L, 1);
                LuaAPI.xlua_pushuint(L, __cl_gen_to_be_invoked.Exp);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_PosId(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.GoodsElementEquip __cl_gen_to_be_invoked = (xc.GoodsElementEquip)translator.FastGetCSObj(L, 1);
                LuaAPI.xlua_pushuint(L, __cl_gen_to_be_invoked.PosId);
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
			
                xc.GoodsElementEquip __cl_gen_to_be_invoked = (xc.GoodsElementEquip)translator.FastGetCSObj(L, 1);
                translator.Push(L, __cl_gen_to_be_invoked.BasicAttrs);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_ExtraAttrs(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.GoodsElementEquip __cl_gen_to_be_invoked = (xc.GoodsElementEquip)translator.FastGetCSObj(L, 1);
                translator.Push(L, __cl_gen_to_be_invoked.ExtraAttrs);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_BaseScore(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.GoodsElementEquip __cl_gen_to_be_invoked = (xc.GoodsElementEquip)translator.FastGetCSObj(L, 1);
                LuaAPI.xlua_pushuint(L, __cl_gen_to_be_invoked.BaseScore);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_ExtraScore(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.GoodsElementEquip __cl_gen_to_be_invoked = (xc.GoodsElementEquip)translator.FastGetCSObj(L, 1);
                LuaAPI.xlua_pushuint(L, __cl_gen_to_be_invoked.ExtraScore);
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
			
                xc.GoodsElementEquip __cl_gen_to_be_invoked = (xc.GoodsElementEquip)translator.FastGetCSObj(L, 1);
                LuaAPI.xlua_pushuint(L, __cl_gen_to_be_invoked.Score);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_ServerScore(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.GoodsElementEquip __cl_gen_to_be_invoked = (xc.GoodsElementEquip)translator.FastGetCSObj(L, 1);
                LuaAPI.xlua_pushuint(L, __cl_gen_to_be_invoked.ServerScore);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_ServerScore(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.GoodsElementEquip __cl_gen_to_be_invoked = (xc.GoodsElementEquip)translator.FastGetCSObj(L, 1);
                __cl_gen_to_be_invoked.ServerScore = LuaAPI.xlua_touint(L, 2);
            
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 0;
        }
        
		
		
		
		
    }
}
