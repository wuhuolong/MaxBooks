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
    public class UnityEngineUIRawImageWrap
    {
        public static void __Register(RealStatePtr L)
        {
			ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			XUtils.BeginObjectRegister(typeof(UnityEngine.UI.RawImage), L, translator, 0, 2, 3, 2);
			
			XUtils.RegisterFunc(L, XUtils.METHOD_IDX, "SetNativeSize", _m_SetNativeSize);
            XUtils.RegisterFunc(L, XUtils.METHOD_IDX, "IsDestroyed", _m_IsDestroyed);

            XUtils.RegisterFunc(L, XUtils.GETTER_IDX, "mainTexture", _g_get_mainTexture);
            XUtils.RegisterFunc(L, XUtils.GETTER_IDX, "texture", _g_get_texture);
            XUtils.RegisterFunc(L, XUtils.GETTER_IDX, "uvRect", _g_get_uvRect);
            
			XUtils.RegisterFunc(L, XUtils.SETTER_IDX, "texture", _s_set_texture);
            XUtils.RegisterFunc(L, XUtils.SETTER_IDX, "uvRect", _s_set_uvRect);
            
			XUtils.EndObjectRegister(typeof(UnityEngine.UI.RawImage), L, translator, null, null,
			    null, null, null);

		    XUtils.BeginClassRegister(typeof(UnityEngine.UI.RawImage), L, __CreateInstance, 1, 0, 0);
			
			
            
            XUtils.RegisterObject(L, translator, XUtils.CLS_IDX, "UnderlyingSystemType", typeof(UnityEngine.UI.RawImage));
			
			
			XUtils.EndClassRegister(typeof(UnityEngine.UI.RawImage), L, translator);
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int __CreateInstance(RealStatePtr L)
        {
            return LuaAPI.luaL_error(L, "UnityEngine.UI.RawImage does not have a constructor!");
        }
        
		
        
		
        
        
        
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_SetNativeSize(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            UnityEngine.UI.RawImage __cl_gen_to_be_invoked = (UnityEngine.UI.RawImage)translator.FastGetCSObj(L, 1);
            
            
            try {
                
                {
                    
                    __cl_gen_to_be_invoked.SetNativeSize(  );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }

        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_IsDestroyed(RealStatePtr L)
        {

            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);

            try
            {
                UnityEngine.UI.RawImage __cl_gen_to_be_invoked = (UnityEngine.UI.RawImage)translator.FastGetCSObj(L, 1);
                bool isDestroyed = false;
                if (__cl_gen_to_be_invoked != null)
                    isDestroyed = __cl_gen_to_be_invoked.IsDestroyed();
                else
                    isDestroyed = true;
                LuaAPI.lua_pushboolean(L, isDestroyed);

                return 1;
            }
            catch (System.Exception __gen_e)
            {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
        }

        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_mainTexture(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                UnityEngine.UI.RawImage __cl_gen_to_be_invoked = (UnityEngine.UI.RawImage)translator.FastGetCSObj(L, 1);
                translator.Push(L, __cl_gen_to_be_invoked.mainTexture);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_texture(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                UnityEngine.UI.RawImage __cl_gen_to_be_invoked = (UnityEngine.UI.RawImage)translator.FastGetCSObj(L, 1);
                translator.Push(L, __cl_gen_to_be_invoked.texture);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_uvRect(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                UnityEngine.UI.RawImage __cl_gen_to_be_invoked = (UnityEngine.UI.RawImage)translator.FastGetCSObj(L, 1);
                translator.Push(L, __cl_gen_to_be_invoked.uvRect);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_texture(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                UnityEngine.UI.RawImage __cl_gen_to_be_invoked = (UnityEngine.UI.RawImage)translator.FastGetCSObj(L, 1);
                __cl_gen_to_be_invoked.texture = (UnityEngine.Texture)translator.GetObject(L, 2, typeof(UnityEngine.Texture));
            
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_uvRect(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                UnityEngine.UI.RawImage __cl_gen_to_be_invoked = (UnityEngine.UI.RawImage)translator.FastGetCSObj(L, 1);
                UnityEngine.Rect __cl_gen_value;translator.Get(L, 2, out __cl_gen_value);
				__cl_gen_to_be_invoked.uvRect = __cl_gen_value;
            
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 0;
        }
        
		
		
		
		
    }
}
