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
    public class RandomObjectEmitterWrap
    {
        public static void __Register(RealStatePtr L)
        {
			ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			XUtils.BeginObjectRegister(typeof(RandomObjectEmitter), L, translator, 0, 2, 7, 7);
			
			XUtils.RegisterFunc(L, XUtils.METHOD_IDX, "Play", _m_Play);
			XUtils.RegisterFunc(L, XUtils.METHOD_IDX, "Stop", _m_Stop);
			
			
			XUtils.RegisterFunc(L, XUtils.GETTER_IDX, "Template", _g_get_Template);
            XUtils.RegisterFunc(L, XUtils.GETTER_IDX, "LifeTime", _g_get_LifeTime);
            XUtils.RegisterFunc(L, XUtils.GETTER_IDX, "EmiterLifeTime", _g_get_EmiterLifeTime);
            XUtils.RegisterFunc(L, XUtils.GETTER_IDX, "DeltaTime", _g_get_DeltaTime);
            XUtils.RegisterFunc(L, XUtils.GETTER_IDX, "MaxEmitCount", _g_get_MaxEmitCount);
            XUtils.RegisterFunc(L, XUtils.GETTER_IDX, "MinPos", _g_get_MinPos);
            XUtils.RegisterFunc(L, XUtils.GETTER_IDX, "MaxPos", _g_get_MaxPos);
            
			XUtils.RegisterFunc(L, XUtils.SETTER_IDX, "Template", _s_set_Template);
            XUtils.RegisterFunc(L, XUtils.SETTER_IDX, "LifeTime", _s_set_LifeTime);
            XUtils.RegisterFunc(L, XUtils.SETTER_IDX, "EmiterLifeTime", _s_set_EmiterLifeTime);
            XUtils.RegisterFunc(L, XUtils.SETTER_IDX, "DeltaTime", _s_set_DeltaTime);
            XUtils.RegisterFunc(L, XUtils.SETTER_IDX, "MaxEmitCount", _s_set_MaxEmitCount);
            XUtils.RegisterFunc(L, XUtils.SETTER_IDX, "MinPos", _s_set_MinPos);
            XUtils.RegisterFunc(L, XUtils.SETTER_IDX, "MaxPos", _s_set_MaxPos);
            
			XUtils.EndObjectRegister(typeof(RandomObjectEmitter), L, translator, null, null,
			    null, null, null);

		    XUtils.BeginClassRegister(typeof(RandomObjectEmitter), L, __CreateInstance, 1, 0, 0);
			
			
            
            XUtils.RegisterObject(L, translator, XUtils.CLS_IDX, "UnderlyingSystemType", typeof(RandomObjectEmitter));
			
			
			XUtils.EndClassRegister(typeof(RandomObjectEmitter), L, translator);
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int __CreateInstance(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			try {
				if(LuaAPI.lua_gettop(L) == 1)
				{
					
					RandomObjectEmitter __cl_gen_ret = new RandomObjectEmitter();
					translator.Push(L, __cl_gen_ret);
					return 1;
				}
				
			}
			catch(System.Exception __gen_e) {
				return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
			}
            return LuaAPI.luaL_error(L, "invalid arguments to RandomObjectEmitter constructor!");
            
        }
        
		
        
		
        
        
        
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_Play(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            RandomObjectEmitter __cl_gen_to_be_invoked = (RandomObjectEmitter)translator.FastGetCSObj(L, 1);
            
            
            try {
                
                {
                    
                    __cl_gen_to_be_invoked.Play(  );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_Stop(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            RandomObjectEmitter __cl_gen_to_be_invoked = (RandomObjectEmitter)translator.FastGetCSObj(L, 1);
            
            
            try {
                
                {
                    
                    __cl_gen_to_be_invoked.Stop(  );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        
        
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_Template(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                RandomObjectEmitter __cl_gen_to_be_invoked = (RandomObjectEmitter)translator.FastGetCSObj(L, 1);
                translator.Push(L, __cl_gen_to_be_invoked.Template);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_LifeTime(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                RandomObjectEmitter __cl_gen_to_be_invoked = (RandomObjectEmitter)translator.FastGetCSObj(L, 1);
                LuaAPI.lua_pushnumber(L, __cl_gen_to_be_invoked.LifeTime);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_EmiterLifeTime(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                RandomObjectEmitter __cl_gen_to_be_invoked = (RandomObjectEmitter)translator.FastGetCSObj(L, 1);
                LuaAPI.lua_pushnumber(L, __cl_gen_to_be_invoked.EmiterLifeTime);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_DeltaTime(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                RandomObjectEmitter __cl_gen_to_be_invoked = (RandomObjectEmitter)translator.FastGetCSObj(L, 1);
                LuaAPI.lua_pushnumber(L, __cl_gen_to_be_invoked.DeltaTime);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_MaxEmitCount(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                RandomObjectEmitter __cl_gen_to_be_invoked = (RandomObjectEmitter)translator.FastGetCSObj(L, 1);
                LuaAPI.xlua_pushinteger(L, __cl_gen_to_be_invoked.MaxEmitCount);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_MinPos(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                RandomObjectEmitter __cl_gen_to_be_invoked = (RandomObjectEmitter)translator.FastGetCSObj(L, 1);
                translator.PushUnityEngineVector2(L, __cl_gen_to_be_invoked.MinPos);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_MaxPos(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                RandomObjectEmitter __cl_gen_to_be_invoked = (RandomObjectEmitter)translator.FastGetCSObj(L, 1);
                translator.PushUnityEngineVector2(L, __cl_gen_to_be_invoked.MaxPos);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_Template(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                RandomObjectEmitter __cl_gen_to_be_invoked = (RandomObjectEmitter)translator.FastGetCSObj(L, 1);
                __cl_gen_to_be_invoked.Template = (UnityEngine.GameObject)translator.GetObject(L, 2, typeof(UnityEngine.GameObject));
            
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_LifeTime(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                RandomObjectEmitter __cl_gen_to_be_invoked = (RandomObjectEmitter)translator.FastGetCSObj(L, 1);
                __cl_gen_to_be_invoked.LifeTime = (float)LuaAPI.lua_tonumber(L, 2);
            
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_EmiterLifeTime(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                RandomObjectEmitter __cl_gen_to_be_invoked = (RandomObjectEmitter)translator.FastGetCSObj(L, 1);
                __cl_gen_to_be_invoked.EmiterLifeTime = (float)LuaAPI.lua_tonumber(L, 2);
            
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_DeltaTime(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                RandomObjectEmitter __cl_gen_to_be_invoked = (RandomObjectEmitter)translator.FastGetCSObj(L, 1);
                __cl_gen_to_be_invoked.DeltaTime = (float)LuaAPI.lua_tonumber(L, 2);
            
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_MaxEmitCount(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                RandomObjectEmitter __cl_gen_to_be_invoked = (RandomObjectEmitter)translator.FastGetCSObj(L, 1);
                __cl_gen_to_be_invoked.MaxEmitCount = LuaAPI.xlua_tointeger(L, 2);
            
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_MinPos(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                RandomObjectEmitter __cl_gen_to_be_invoked = (RandomObjectEmitter)translator.FastGetCSObj(L, 1);
                UnityEngine.Vector2 __cl_gen_value;translator.Get(L, 2, out __cl_gen_value);
				__cl_gen_to_be_invoked.MinPos = __cl_gen_value;
            
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_MaxPos(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                RandomObjectEmitter __cl_gen_to_be_invoked = (RandomObjectEmitter)translator.FastGetCSObj(L, 1);
                UnityEngine.Vector2 __cl_gen_value;translator.Get(L, 2, out __cl_gen_value);
				__cl_gen_to_be_invoked.MaxPos = __cl_gen_value;
            
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 0;
        }
        
		
		
		
		
    }
}
