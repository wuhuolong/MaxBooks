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
    public class xcMarryManagerWrap
    {
        public static void __Register(RealStatePtr L)
        {
			ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			XUtils.BeginObjectRegister(typeof(xc.MarryManager), L, translator, 0, 2, 4, 2);
			
			XUtils.RegisterFunc(L, XUtils.METHOD_IDX, "RegisterAllMessage", _m_RegisterAllMessage);
			XUtils.RegisterFunc(L, XUtils.METHOD_IDX, "Reset", _m_Reset);
			
			
			XUtils.RegisterFunc(L, XUtils.GETTER_IDX, "WeddingInstanceFoodsCount", _g_get_WeddingInstanceFoodsCount);
            XUtils.RegisterFunc(L, XUtils.GETTER_IDX, "WeddingInstanceBoxCount", _g_get_WeddingInstanceBoxCount);
            XUtils.RegisterFunc(L, XUtils.GETTER_IDX, "WeddingFoodsCanBeCollected", _g_get_WeddingFoodsCanBeCollected);
            XUtils.RegisterFunc(L, XUtils.GETTER_IDX, "WeddingBoxCanBeCollected", _g_get_WeddingBoxCanBeCollected);
            
			XUtils.RegisterFunc(L, XUtils.SETTER_IDX, "WeddingInstanceFoodsCount", _s_set_WeddingInstanceFoodsCount);
            XUtils.RegisterFunc(L, XUtils.SETTER_IDX, "WeddingInstanceBoxCount", _s_set_WeddingInstanceBoxCount);
            
			XUtils.EndObjectRegister(typeof(xc.MarryManager), L, translator, null, null,
			    null, null, null);

		    XUtils.BeginClassRegister(typeof(xc.MarryManager), L, __CreateInstance, 1, 0, 0);
			
			
            
            XUtils.RegisterObject(L, translator, XUtils.CLS_IDX, "UnderlyingSystemType", typeof(xc.MarryManager));
			
			
			XUtils.EndClassRegister(typeof(xc.MarryManager), L, translator);
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int __CreateInstance(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			try {
				if(LuaAPI.lua_gettop(L) == 1)
				{
					
					xc.MarryManager __cl_gen_ret = new xc.MarryManager();
					translator.Push(L, __cl_gen_ret);
					return 1;
				}
				
			}
			catch(System.Exception __gen_e) {
				return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
			}
            return LuaAPI.luaL_error(L, "invalid arguments to xc.MarryManager constructor!");
            
        }
        
		
        
		
        
        
        
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_RegisterAllMessage(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            xc.MarryManager __cl_gen_to_be_invoked = (xc.MarryManager)translator.FastGetCSObj(L, 1);
            
            
            try {
                
                {
                    
                    __cl_gen_to_be_invoked.RegisterAllMessage(  );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_Reset(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            xc.MarryManager __cl_gen_to_be_invoked = (xc.MarryManager)translator.FastGetCSObj(L, 1);
            
            
            try {
                
                {
                    
                    __cl_gen_to_be_invoked.Reset(  );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        
        
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_WeddingInstanceFoodsCount(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.MarryManager __cl_gen_to_be_invoked = (xc.MarryManager)translator.FastGetCSObj(L, 1);
                LuaAPI.xlua_pushuint(L, __cl_gen_to_be_invoked.WeddingInstanceFoodsCount);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_WeddingInstanceBoxCount(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.MarryManager __cl_gen_to_be_invoked = (xc.MarryManager)translator.FastGetCSObj(L, 1);
                LuaAPI.xlua_pushuint(L, __cl_gen_to_be_invoked.WeddingInstanceBoxCount);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_WeddingFoodsCanBeCollected(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.MarryManager __cl_gen_to_be_invoked = (xc.MarryManager)translator.FastGetCSObj(L, 1);
                LuaAPI.lua_pushboolean(L, __cl_gen_to_be_invoked.WeddingFoodsCanBeCollected);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_WeddingBoxCanBeCollected(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.MarryManager __cl_gen_to_be_invoked = (xc.MarryManager)translator.FastGetCSObj(L, 1);
                LuaAPI.lua_pushboolean(L, __cl_gen_to_be_invoked.WeddingBoxCanBeCollected);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_WeddingInstanceFoodsCount(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.MarryManager __cl_gen_to_be_invoked = (xc.MarryManager)translator.FastGetCSObj(L, 1);
                __cl_gen_to_be_invoked.WeddingInstanceFoodsCount = LuaAPI.xlua_touint(L, 2);
            
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_WeddingInstanceBoxCount(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.MarryManager __cl_gen_to_be_invoked = (xc.MarryManager)translator.FastGetCSObj(L, 1);
                __cl_gen_to_be_invoked.WeddingInstanceBoxCount = LuaAPI.xlua_touint(L, 2);
            
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 0;
        }
        
		
		
		
		
    }
}
