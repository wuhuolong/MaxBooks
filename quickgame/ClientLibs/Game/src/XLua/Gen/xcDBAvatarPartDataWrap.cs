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
    public class xcDBAvatarPartDataWrap
    {
        public static void __Register(RealStatePtr L)
        {
			ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			XUtils.BeginObjectRegister(typeof(xc.DBAvatarPart.Data), L, translator, 0, 2, 6, 6);
			
			XUtils.RegisterFunc(L, XUtils.METHOD_IDX, "Clone", _m_Clone);
			XUtils.RegisterFunc(L, XUtils.METHOD_IDX, "SuitablePath", _m_SuitablePath);
			
			
			XUtils.RegisterFunc(L, XUtils.GETTER_IDX, "path", _g_get_path);
            XUtils.RegisterFunc(L, XUtils.GETTER_IDX, "low_path", _g_get_low_path);
            XUtils.RegisterFunc(L, XUtils.GETTER_IDX, "part", _g_get_part);
            XUtils.RegisterFunc(L, XUtils.GETTER_IDX, "vocation", _g_get_vocation);
            XUtils.RegisterFunc(L, XUtils.GETTER_IDX, "isFashion", _g_get_isFashion);
            XUtils.RegisterFunc(L, XUtils.GETTER_IDX, "isShowWin", _g_get_isShowWin);
            
			XUtils.RegisterFunc(L, XUtils.SETTER_IDX, "path", _s_set_path);
            XUtils.RegisterFunc(L, XUtils.SETTER_IDX, "low_path", _s_set_low_path);
            XUtils.RegisterFunc(L, XUtils.SETTER_IDX, "part", _s_set_part);
            XUtils.RegisterFunc(L, XUtils.SETTER_IDX, "vocation", _s_set_vocation);
            XUtils.RegisterFunc(L, XUtils.SETTER_IDX, "isFashion", _s_set_isFashion);
            XUtils.RegisterFunc(L, XUtils.SETTER_IDX, "isShowWin", _s_set_isShowWin);
            
			XUtils.EndObjectRegister(typeof(xc.DBAvatarPart.Data), L, translator, null, null,
			    null, null, null);

		    XUtils.BeginClassRegister(typeof(xc.DBAvatarPart.Data), L, __CreateInstance, 1, 0, 0);
			
			
            
            XUtils.RegisterObject(L, translator, XUtils.CLS_IDX, "UnderlyingSystemType", typeof(xc.DBAvatarPart.Data));
			
			
			XUtils.EndClassRegister(typeof(xc.DBAvatarPart.Data), L, translator);
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int __CreateInstance(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			try {
				if(LuaAPI.lua_gettop(L) == 1)
				{
					
					xc.DBAvatarPart.Data __cl_gen_ret = new xc.DBAvatarPart.Data();
					translator.Push(L, __cl_gen_ret);
					return 1;
				}
				
			}
			catch(System.Exception __gen_e) {
				return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
			}
            return LuaAPI.luaL_error(L, "invalid arguments to xc.DBAvatarPart.Data constructor!");
            
        }
        
		
        
		
        
        
        
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_Clone(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            xc.DBAvatarPart.Data __cl_gen_to_be_invoked = (xc.DBAvatarPart.Data)translator.FastGetCSObj(L, 1);
            
            
            try {
                
                {
                    
                        xc.DBAvatarPart.Data __cl_gen_ret = __cl_gen_to_be_invoked.Clone(  );
                        translator.Push(L, __cl_gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_SuitablePath(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            xc.DBAvatarPart.Data __cl_gen_to_be_invoked = (xc.DBAvatarPart.Data)translator.FastGetCSObj(L, 1);
            
            
            try {
                
                {
                    bool is_local_player = LuaAPI.lua_toboolean(L, 2);
                    
                        string __cl_gen_ret = __cl_gen_to_be_invoked.SuitablePath( is_local_player );
                        LuaAPI.lua_pushstring(L, __cl_gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        
        
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_path(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.DBAvatarPart.Data __cl_gen_to_be_invoked = (xc.DBAvatarPart.Data)translator.FastGetCSObj(L, 1);
                LuaAPI.lua_pushstring(L, __cl_gen_to_be_invoked.path);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_low_path(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.DBAvatarPart.Data __cl_gen_to_be_invoked = (xc.DBAvatarPart.Data)translator.FastGetCSObj(L, 1);
                LuaAPI.lua_pushstring(L, __cl_gen_to_be_invoked.low_path);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_part(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.DBAvatarPart.Data __cl_gen_to_be_invoked = (xc.DBAvatarPart.Data)translator.FastGetCSObj(L, 1);
                translator.PushxcDBAvatarPartBODY_PART(L, __cl_gen_to_be_invoked.part);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_vocation(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.DBAvatarPart.Data __cl_gen_to_be_invoked = (xc.DBAvatarPart.Data)translator.FastGetCSObj(L, 1);
                translator.PushActorEVocationType(L, __cl_gen_to_be_invoked.vocation);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_isFashion(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.DBAvatarPart.Data __cl_gen_to_be_invoked = (xc.DBAvatarPart.Data)translator.FastGetCSObj(L, 1);
                LuaAPI.lua_pushboolean(L, __cl_gen_to_be_invoked.isFashion);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_isShowWin(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.DBAvatarPart.Data __cl_gen_to_be_invoked = (xc.DBAvatarPart.Data)translator.FastGetCSObj(L, 1);
                LuaAPI.lua_pushboolean(L, __cl_gen_to_be_invoked.isShowWin);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_path(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.DBAvatarPart.Data __cl_gen_to_be_invoked = (xc.DBAvatarPart.Data)translator.FastGetCSObj(L, 1);
                __cl_gen_to_be_invoked.path = LuaAPI.lua_tostring(L, 2);
            
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_low_path(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.DBAvatarPart.Data __cl_gen_to_be_invoked = (xc.DBAvatarPart.Data)translator.FastGetCSObj(L, 1);
                __cl_gen_to_be_invoked.low_path = LuaAPI.lua_tostring(L, 2);
            
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_part(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.DBAvatarPart.Data __cl_gen_to_be_invoked = (xc.DBAvatarPart.Data)translator.FastGetCSObj(L, 1);
                xc.DBAvatarPart.BODY_PART __cl_gen_value;translator.Get(L, 2, out __cl_gen_value);
				__cl_gen_to_be_invoked.part = __cl_gen_value;
            
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_vocation(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.DBAvatarPart.Data __cl_gen_to_be_invoked = (xc.DBAvatarPart.Data)translator.FastGetCSObj(L, 1);
                Actor.EVocationType __cl_gen_value;translator.Get(L, 2, out __cl_gen_value);
				__cl_gen_to_be_invoked.vocation = __cl_gen_value;
            
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_isFashion(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.DBAvatarPart.Data __cl_gen_to_be_invoked = (xc.DBAvatarPart.Data)translator.FastGetCSObj(L, 1);
                __cl_gen_to_be_invoked.isFashion = LuaAPI.lua_toboolean(L, 2);
            
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_isShowWin(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.DBAvatarPart.Data __cl_gen_to_be_invoked = (xc.DBAvatarPart.Data)translator.FastGetCSObj(L, 1);
                __cl_gen_to_be_invoked.isShowWin = LuaAPI.lua_toboolean(L, 2);
            
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 0;
        }
        
		
		
		
		
    }
}
