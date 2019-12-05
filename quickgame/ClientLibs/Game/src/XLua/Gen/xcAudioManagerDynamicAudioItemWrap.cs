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
    public class xcAudioManagerDynamicAudioItemWrap
    {
        public static void __Register(RealStatePtr L)
        {
			ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			XUtils.BeginObjectRegister(typeof(xc.AudioManager.DynamicAudioItem), L, translator, 0, 0, 7, 7);
			
			
			
			XUtils.RegisterFunc(L, XUtils.GETTER_IDX, "audioSource", _g_get_audioSource);
            XUtils.RegisterFunc(L, XUtils.GETTER_IDX, "clip", _g_get_clip);
            XUtils.RegisterFunc(L, XUtils.GETTER_IDX, "res_path", _g_get_res_path);
            XUtils.RegisterFunc(L, XUtils.GETTER_IDX, "is_loop", _g_get_is_loop);
            XUtils.RegisterFunc(L, XUtils.GETTER_IDX, "unique_id", _g_get_unique_id);
            XUtils.RegisterFunc(L, XUtils.GETTER_IDX, "volume", _g_get_volume);
            XUtils.RegisterFunc(L, XUtils.GETTER_IDX, "is_destroy", _g_get_is_destroy);
            
			XUtils.RegisterFunc(L, XUtils.SETTER_IDX, "audioSource", _s_set_audioSource);
            XUtils.RegisterFunc(L, XUtils.SETTER_IDX, "clip", _s_set_clip);
            XUtils.RegisterFunc(L, XUtils.SETTER_IDX, "res_path", _s_set_res_path);
            XUtils.RegisterFunc(L, XUtils.SETTER_IDX, "is_loop", _s_set_is_loop);
            XUtils.RegisterFunc(L, XUtils.SETTER_IDX, "unique_id", _s_set_unique_id);
            XUtils.RegisterFunc(L, XUtils.SETTER_IDX, "volume", _s_set_volume);
            XUtils.RegisterFunc(L, XUtils.SETTER_IDX, "is_destroy", _s_set_is_destroy);
            
			XUtils.EndObjectRegister(typeof(xc.AudioManager.DynamicAudioItem), L, translator, null, null,
			    null, null, null);

		    XUtils.BeginClassRegister(typeof(xc.AudioManager.DynamicAudioItem), L, __CreateInstance, 1, 0, 0);
			
			
            
            XUtils.RegisterObject(L, translator, XUtils.CLS_IDX, "UnderlyingSystemType", typeof(xc.AudioManager.DynamicAudioItem));
			
			
			XUtils.EndClassRegister(typeof(xc.AudioManager.DynamicAudioItem), L, translator);
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int __CreateInstance(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			try {
				if(LuaAPI.lua_gettop(L) == 1)
				{
					
					xc.AudioManager.DynamicAudioItem __cl_gen_ret = new xc.AudioManager.DynamicAudioItem();
					translator.Push(L, __cl_gen_ret);
					return 1;
				}
				
			}
			catch(System.Exception __gen_e) {
				return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
			}
            return LuaAPI.luaL_error(L, "invalid arguments to xc.AudioManager.DynamicAudioItem constructor!");
            
        }
        
		
        
		
        
        
        
        
        
        
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_audioSource(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.AudioManager.DynamicAudioItem __cl_gen_to_be_invoked = (xc.AudioManager.DynamicAudioItem)translator.FastGetCSObj(L, 1);
                translator.Push(L, __cl_gen_to_be_invoked.audioSource);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_clip(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.AudioManager.DynamicAudioItem __cl_gen_to_be_invoked = (xc.AudioManager.DynamicAudioItem)translator.FastGetCSObj(L, 1);
                translator.Push(L, __cl_gen_to_be_invoked.clip);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_res_path(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.AudioManager.DynamicAudioItem __cl_gen_to_be_invoked = (xc.AudioManager.DynamicAudioItem)translator.FastGetCSObj(L, 1);
                LuaAPI.lua_pushstring(L, __cl_gen_to_be_invoked.res_path);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_is_loop(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.AudioManager.DynamicAudioItem __cl_gen_to_be_invoked = (xc.AudioManager.DynamicAudioItem)translator.FastGetCSObj(L, 1);
                LuaAPI.lua_pushboolean(L, __cl_gen_to_be_invoked.is_loop);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_unique_id(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.AudioManager.DynamicAudioItem __cl_gen_to_be_invoked = (xc.AudioManager.DynamicAudioItem)translator.FastGetCSObj(L, 1);
                LuaAPI.xlua_pushuint(L, __cl_gen_to_be_invoked.unique_id);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_volume(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.AudioManager.DynamicAudioItem __cl_gen_to_be_invoked = (xc.AudioManager.DynamicAudioItem)translator.FastGetCSObj(L, 1);
                LuaAPI.lua_pushnumber(L, __cl_gen_to_be_invoked.volume);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_is_destroy(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.AudioManager.DynamicAudioItem __cl_gen_to_be_invoked = (xc.AudioManager.DynamicAudioItem)translator.FastGetCSObj(L, 1);
                LuaAPI.lua_pushboolean(L, __cl_gen_to_be_invoked.is_destroy);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_audioSource(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.AudioManager.DynamicAudioItem __cl_gen_to_be_invoked = (xc.AudioManager.DynamicAudioItem)translator.FastGetCSObj(L, 1);
                __cl_gen_to_be_invoked.audioSource = (UnityEngine.AudioSource)translator.GetObject(L, 2, typeof(UnityEngine.AudioSource));
            
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_clip(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.AudioManager.DynamicAudioItem __cl_gen_to_be_invoked = (xc.AudioManager.DynamicAudioItem)translator.FastGetCSObj(L, 1);
                __cl_gen_to_be_invoked.clip = (UnityEngine.AudioClip)translator.GetObject(L, 2, typeof(UnityEngine.AudioClip));
            
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_res_path(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.AudioManager.DynamicAudioItem __cl_gen_to_be_invoked = (xc.AudioManager.DynamicAudioItem)translator.FastGetCSObj(L, 1);
                __cl_gen_to_be_invoked.res_path = LuaAPI.lua_tostring(L, 2);
            
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_is_loop(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.AudioManager.DynamicAudioItem __cl_gen_to_be_invoked = (xc.AudioManager.DynamicAudioItem)translator.FastGetCSObj(L, 1);
                __cl_gen_to_be_invoked.is_loop = LuaAPI.lua_toboolean(L, 2);
            
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_unique_id(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.AudioManager.DynamicAudioItem __cl_gen_to_be_invoked = (xc.AudioManager.DynamicAudioItem)translator.FastGetCSObj(L, 1);
                __cl_gen_to_be_invoked.unique_id = LuaAPI.xlua_touint(L, 2);
            
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_volume(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.AudioManager.DynamicAudioItem __cl_gen_to_be_invoked = (xc.AudioManager.DynamicAudioItem)translator.FastGetCSObj(L, 1);
                __cl_gen_to_be_invoked.volume = (float)LuaAPI.lua_tonumber(L, 2);
            
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_is_destroy(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.AudioManager.DynamicAudioItem __cl_gen_to_be_invoked = (xc.AudioManager.DynamicAudioItem)translator.FastGetCSObj(L, 1);
                __cl_gen_to_be_invoked.is_destroy = LuaAPI.lua_toboolean(L, 2);
            
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 0;
        }
        
		
		
		
		
    }
}
