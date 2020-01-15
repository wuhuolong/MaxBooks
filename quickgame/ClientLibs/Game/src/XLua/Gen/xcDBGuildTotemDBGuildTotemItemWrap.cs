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
    public class xcDBGuildTotemDBGuildTotemItemWrap
    {
        public static void __Register(RealStatePtr L)
        {
			ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			XUtils.BeginObjectRegister(typeof(xc.DBGuildTotem.DBGuildTotemItem), L, translator, 0, 0, 5, 5);
			
			
			
			XUtils.RegisterFunc(L, XUtils.GETTER_IDX, "Lv", _g_get_Lv);
            XUtils.RegisterFunc(L, XUtils.GETTER_IDX, "Exp", _g_get_Exp);
            XUtils.RegisterFunc(L, XUtils.GETTER_IDX, "Buffs", _g_get_Buffs);
            XUtils.RegisterFunc(L, XUtils.GETTER_IDX, "Descs", _g_get_Descs);
            XUtils.RegisterFunc(L, XUtils.GETTER_IDX, "NextOffsetDescs", _g_get_NextOffsetDescs);
            
			XUtils.RegisterFunc(L, XUtils.SETTER_IDX, "Lv", _s_set_Lv);
            XUtils.RegisterFunc(L, XUtils.SETTER_IDX, "Exp", _s_set_Exp);
            XUtils.RegisterFunc(L, XUtils.SETTER_IDX, "Buffs", _s_set_Buffs);
            XUtils.RegisterFunc(L, XUtils.SETTER_IDX, "Descs", _s_set_Descs);
            XUtils.RegisterFunc(L, XUtils.SETTER_IDX, "NextOffsetDescs", _s_set_NextOffsetDescs);
            
			XUtils.EndObjectRegister(typeof(xc.DBGuildTotem.DBGuildTotemItem), L, translator, null, null,
			    null, null, null);

		    XUtils.BeginClassRegister(typeof(xc.DBGuildTotem.DBGuildTotemItem), L, __CreateInstance, 1, 0, 0);
			
			
            
            XUtils.RegisterObject(L, translator, XUtils.CLS_IDX, "UnderlyingSystemType", typeof(xc.DBGuildTotem.DBGuildTotemItem));
			
			
			XUtils.EndClassRegister(typeof(xc.DBGuildTotem.DBGuildTotemItem), L, translator);
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int __CreateInstance(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			try {
				if(LuaAPI.lua_gettop(L) == 1)
				{
					
					xc.DBGuildTotem.DBGuildTotemItem __cl_gen_ret = new xc.DBGuildTotem.DBGuildTotemItem();
					translator.Push(L, __cl_gen_ret);
					return 1;
				}
				
			}
			catch(System.Exception __gen_e) {
				return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
			}
            return LuaAPI.luaL_error(L, "invalid arguments to xc.DBGuildTotem.DBGuildTotemItem constructor!");
            
        }
        
		
        
		
        
        
        
        
        
        
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_Lv(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.DBGuildTotem.DBGuildTotemItem __cl_gen_to_be_invoked = (xc.DBGuildTotem.DBGuildTotemItem)translator.FastGetCSObj(L, 1);
                LuaAPI.xlua_pushuint(L, __cl_gen_to_be_invoked.Lv);
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
			
                xc.DBGuildTotem.DBGuildTotemItem __cl_gen_to_be_invoked = (xc.DBGuildTotem.DBGuildTotemItem)translator.FastGetCSObj(L, 1);
                LuaAPI.lua_pushuint64(L, __cl_gen_to_be_invoked.Exp);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_Buffs(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.DBGuildTotem.DBGuildTotemItem __cl_gen_to_be_invoked = (xc.DBGuildTotem.DBGuildTotemItem)translator.FastGetCSObj(L, 1);
                translator.Push(L, __cl_gen_to_be_invoked.Buffs);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_Descs(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.DBGuildTotem.DBGuildTotemItem __cl_gen_to_be_invoked = (xc.DBGuildTotem.DBGuildTotemItem)translator.FastGetCSObj(L, 1);
                translator.Push(L, __cl_gen_to_be_invoked.Descs);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_NextOffsetDescs(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.DBGuildTotem.DBGuildTotemItem __cl_gen_to_be_invoked = (xc.DBGuildTotem.DBGuildTotemItem)translator.FastGetCSObj(L, 1);
                translator.Push(L, __cl_gen_to_be_invoked.NextOffsetDescs);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_Lv(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.DBGuildTotem.DBGuildTotemItem __cl_gen_to_be_invoked = (xc.DBGuildTotem.DBGuildTotemItem)translator.FastGetCSObj(L, 1);
                __cl_gen_to_be_invoked.Lv = LuaAPI.xlua_touint(L, 2);
            
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_Exp(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.DBGuildTotem.DBGuildTotemItem __cl_gen_to_be_invoked = (xc.DBGuildTotem.DBGuildTotemItem)translator.FastGetCSObj(L, 1);
                __cl_gen_to_be_invoked.Exp = LuaAPI.lua_touint64(L, 2);
            
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_Buffs(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.DBGuildTotem.DBGuildTotemItem __cl_gen_to_be_invoked = (xc.DBGuildTotem.DBGuildTotemItem)translator.FastGetCSObj(L, 1);
                __cl_gen_to_be_invoked.Buffs = (System.Collections.Generic.List<uint>)translator.GetObject(L, 2, typeof(System.Collections.Generic.List<uint>));
            
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_Descs(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.DBGuildTotem.DBGuildTotemItem __cl_gen_to_be_invoked = (xc.DBGuildTotem.DBGuildTotemItem)translator.FastGetCSObj(L, 1);
                __cl_gen_to_be_invoked.Descs = (System.Collections.Generic.List<string>)translator.GetObject(L, 2, typeof(System.Collections.Generic.List<string>));
            
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_NextOffsetDescs(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.DBGuildTotem.DBGuildTotemItem __cl_gen_to_be_invoked = (xc.DBGuildTotem.DBGuildTotemItem)translator.FastGetCSObj(L, 1);
                __cl_gen_to_be_invoked.NextOffsetDescs = (System.Collections.Generic.List<string>)translator.GetObject(L, 2, typeof(System.Collections.Generic.List<string>));
            
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 0;
        }
        
		
		
		
		
    }
}
