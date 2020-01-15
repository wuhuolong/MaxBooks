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
    public class UnityEngineTextureWrap
    {
        public static void __Register(RealStatePtr L)
        {
			ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			XUtils.BeginObjectRegister(typeof(UnityEngine.Texture), L, translator, 0, 1, 12, 11);
			
			XUtils.RegisterFunc(L, XUtils.METHOD_IDX, "GetNativeTexturePtr", _m_GetNativeTexturePtr);
			
			
			XUtils.RegisterFunc(L, XUtils.GETTER_IDX, "width", _g_get_width);
            XUtils.RegisterFunc(L, XUtils.GETTER_IDX, "height", _g_get_height);
            XUtils.RegisterFunc(L, XUtils.GETTER_IDX, "dimension", _g_get_dimension);
            XUtils.RegisterFunc(L, XUtils.GETTER_IDX, "filterMode", _g_get_filterMode);
            XUtils.RegisterFunc(L, XUtils.GETTER_IDX, "anisoLevel", _g_get_anisoLevel);
            XUtils.RegisterFunc(L, XUtils.GETTER_IDX, "wrapMode", _g_get_wrapMode);
            XUtils.RegisterFunc(L, XUtils.GETTER_IDX, "wrapModeU", _g_get_wrapModeU);
            XUtils.RegisterFunc(L, XUtils.GETTER_IDX, "wrapModeV", _g_get_wrapModeV);
            XUtils.RegisterFunc(L, XUtils.GETTER_IDX, "wrapModeW", _g_get_wrapModeW);
            XUtils.RegisterFunc(L, XUtils.GETTER_IDX, "mipMapBias", _g_get_mipMapBias);
            XUtils.RegisterFunc(L, XUtils.GETTER_IDX, "texelSize", _g_get_texelSize);
            XUtils.RegisterFunc(L, XUtils.GETTER_IDX, "imageContentsHash", _g_get_imageContentsHash);
            
			XUtils.RegisterFunc(L, XUtils.SETTER_IDX, "width", _s_set_width);
            XUtils.RegisterFunc(L, XUtils.SETTER_IDX, "height", _s_set_height);
            XUtils.RegisterFunc(L, XUtils.SETTER_IDX, "dimension", _s_set_dimension);
            XUtils.RegisterFunc(L, XUtils.SETTER_IDX, "filterMode", _s_set_filterMode);
            XUtils.RegisterFunc(L, XUtils.SETTER_IDX, "anisoLevel", _s_set_anisoLevel);
            XUtils.RegisterFunc(L, XUtils.SETTER_IDX, "wrapMode", _s_set_wrapMode);
            XUtils.RegisterFunc(L, XUtils.SETTER_IDX, "wrapModeU", _s_set_wrapModeU);
            XUtils.RegisterFunc(L, XUtils.SETTER_IDX, "wrapModeV", _s_set_wrapModeV);
            XUtils.RegisterFunc(L, XUtils.SETTER_IDX, "wrapModeW", _s_set_wrapModeW);
            XUtils.RegisterFunc(L, XUtils.SETTER_IDX, "mipMapBias", _s_set_mipMapBias);
            XUtils.RegisterFunc(L, XUtils.SETTER_IDX, "imageContentsHash", _s_set_imageContentsHash);
            
			XUtils.EndObjectRegister(typeof(UnityEngine.Texture), L, translator, null, null,
			    null, null, null);

		    XUtils.BeginClassRegister(typeof(UnityEngine.Texture), L, __CreateInstance, 2, 2, 2);
			XUtils.RegisterFunc(L, XUtils.CLS_IDX, "SetGlobalAnisotropicFilteringLimits", _m_SetGlobalAnisotropicFilteringLimits_xlua_st_);
            
			
            
            XUtils.RegisterObject(L, translator, XUtils.CLS_IDX, "UnderlyingSystemType", typeof(UnityEngine.Texture));
			XUtils.RegisterFunc(L, XUtils.CLS_GETTER_IDX, "masterTextureLimit", _g_get_masterTextureLimit);
            XUtils.RegisterFunc(L, XUtils.CLS_GETTER_IDX, "anisotropicFiltering", _g_get_anisotropicFiltering);
            
			XUtils.RegisterFunc(L, XUtils.CLS_SETTER_IDX, "masterTextureLimit", _s_set_masterTextureLimit);
            XUtils.RegisterFunc(L, XUtils.CLS_SETTER_IDX, "anisotropicFiltering", _s_set_anisotropicFiltering);
            
			XUtils.EndClassRegister(typeof(UnityEngine.Texture), L, translator);
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int __CreateInstance(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			try {
				if(LuaAPI.lua_gettop(L) == 1)
				{
					
					UnityEngine.Texture __cl_gen_ret = new UnityEngine.Texture();
					translator.Push(L, __cl_gen_ret);
					return 1;
				}
				
			}
			catch(System.Exception __gen_e) {
				return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
			}
            return LuaAPI.luaL_error(L, "invalid arguments to UnityEngine.Texture constructor!");
            
        }
        
		
        
		
        
        
        
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_SetGlobalAnisotropicFilteringLimits_xlua_st_(RealStatePtr L)
        {
            
            
            
            try {
                
                {
                    int forcedMin = LuaAPI.xlua_tointeger(L, 1);
                    int globalMax = LuaAPI.xlua_tointeger(L, 2);
                    
                    UnityEngine.Texture.SetGlobalAnisotropicFilteringLimits( forcedMin, globalMax );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_GetNativeTexturePtr(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            UnityEngine.Texture __cl_gen_to_be_invoked = (UnityEngine.Texture)translator.FastGetCSObj(L, 1);
            
            
            try {
                
                {
                    
                        System.IntPtr __cl_gen_ret = __cl_gen_to_be_invoked.GetNativeTexturePtr(  );
                        LuaAPI.lua_pushlightuserdata(L, __cl_gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        
        
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_masterTextureLimit(RealStatePtr L)
        {
            
            try {
			    LuaAPI.xlua_pushinteger(L, UnityEngine.Texture.masterTextureLimit);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_anisotropicFiltering(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			    translator.Push(L, UnityEngine.Texture.anisotropicFiltering);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_width(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                UnityEngine.Texture __cl_gen_to_be_invoked = (UnityEngine.Texture)translator.FastGetCSObj(L, 1);
                LuaAPI.xlua_pushinteger(L, __cl_gen_to_be_invoked.width);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_height(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                UnityEngine.Texture __cl_gen_to_be_invoked = (UnityEngine.Texture)translator.FastGetCSObj(L, 1);
                LuaAPI.xlua_pushinteger(L, __cl_gen_to_be_invoked.height);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_dimension(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                UnityEngine.Texture __cl_gen_to_be_invoked = (UnityEngine.Texture)translator.FastGetCSObj(L, 1);
                translator.Push(L, __cl_gen_to_be_invoked.dimension);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_filterMode(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                UnityEngine.Texture __cl_gen_to_be_invoked = (UnityEngine.Texture)translator.FastGetCSObj(L, 1);
                translator.Push(L, __cl_gen_to_be_invoked.filterMode);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_anisoLevel(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                UnityEngine.Texture __cl_gen_to_be_invoked = (UnityEngine.Texture)translator.FastGetCSObj(L, 1);
                LuaAPI.xlua_pushinteger(L, __cl_gen_to_be_invoked.anisoLevel);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_wrapMode(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                UnityEngine.Texture __cl_gen_to_be_invoked = (UnityEngine.Texture)translator.FastGetCSObj(L, 1);
                translator.Push(L, __cl_gen_to_be_invoked.wrapMode);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_wrapModeU(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                UnityEngine.Texture __cl_gen_to_be_invoked = (UnityEngine.Texture)translator.FastGetCSObj(L, 1);
                translator.Push(L, __cl_gen_to_be_invoked.wrapModeU);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_wrapModeV(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                UnityEngine.Texture __cl_gen_to_be_invoked = (UnityEngine.Texture)translator.FastGetCSObj(L, 1);
                translator.Push(L, __cl_gen_to_be_invoked.wrapModeV);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_wrapModeW(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                UnityEngine.Texture __cl_gen_to_be_invoked = (UnityEngine.Texture)translator.FastGetCSObj(L, 1);
                translator.Push(L, __cl_gen_to_be_invoked.wrapModeW);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_mipMapBias(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                UnityEngine.Texture __cl_gen_to_be_invoked = (UnityEngine.Texture)translator.FastGetCSObj(L, 1);
                LuaAPI.lua_pushnumber(L, __cl_gen_to_be_invoked.mipMapBias);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_texelSize(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                UnityEngine.Texture __cl_gen_to_be_invoked = (UnityEngine.Texture)translator.FastGetCSObj(L, 1);
                translator.PushUnityEngineVector2(L, __cl_gen_to_be_invoked.texelSize);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_imageContentsHash(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                UnityEngine.Texture __cl_gen_to_be_invoked = (UnityEngine.Texture)translator.FastGetCSObj(L, 1);
                translator.Push(L, __cl_gen_to_be_invoked.imageContentsHash);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_masterTextureLimit(RealStatePtr L)
        {
            
            try {
			    UnityEngine.Texture.masterTextureLimit = LuaAPI.xlua_tointeger(L, 1);
            
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_anisotropicFiltering(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			UnityEngine.AnisotropicFiltering __cl_gen_value;translator.Get(L, 1, out __cl_gen_value);
				UnityEngine.Texture.anisotropicFiltering = __cl_gen_value;
            
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_width(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                UnityEngine.Texture __cl_gen_to_be_invoked = (UnityEngine.Texture)translator.FastGetCSObj(L, 1);
                __cl_gen_to_be_invoked.width = LuaAPI.xlua_tointeger(L, 2);
            
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_height(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                UnityEngine.Texture __cl_gen_to_be_invoked = (UnityEngine.Texture)translator.FastGetCSObj(L, 1);
                __cl_gen_to_be_invoked.height = LuaAPI.xlua_tointeger(L, 2);
            
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_dimension(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                UnityEngine.Texture __cl_gen_to_be_invoked = (UnityEngine.Texture)translator.FastGetCSObj(L, 1);
                UnityEngine.Rendering.TextureDimension __cl_gen_value;translator.Get(L, 2, out __cl_gen_value);
				__cl_gen_to_be_invoked.dimension = __cl_gen_value;
            
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_filterMode(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                UnityEngine.Texture __cl_gen_to_be_invoked = (UnityEngine.Texture)translator.FastGetCSObj(L, 1);
                UnityEngine.FilterMode __cl_gen_value;translator.Get(L, 2, out __cl_gen_value);
				__cl_gen_to_be_invoked.filterMode = __cl_gen_value;
            
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_anisoLevel(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                UnityEngine.Texture __cl_gen_to_be_invoked = (UnityEngine.Texture)translator.FastGetCSObj(L, 1);
                __cl_gen_to_be_invoked.anisoLevel = LuaAPI.xlua_tointeger(L, 2);
            
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_wrapMode(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                UnityEngine.Texture __cl_gen_to_be_invoked = (UnityEngine.Texture)translator.FastGetCSObj(L, 1);
                UnityEngine.TextureWrapMode __cl_gen_value;translator.Get(L, 2, out __cl_gen_value);
				__cl_gen_to_be_invoked.wrapMode = __cl_gen_value;
            
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_wrapModeU(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                UnityEngine.Texture __cl_gen_to_be_invoked = (UnityEngine.Texture)translator.FastGetCSObj(L, 1);
                UnityEngine.TextureWrapMode __cl_gen_value;translator.Get(L, 2, out __cl_gen_value);
				__cl_gen_to_be_invoked.wrapModeU = __cl_gen_value;
            
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_wrapModeV(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                UnityEngine.Texture __cl_gen_to_be_invoked = (UnityEngine.Texture)translator.FastGetCSObj(L, 1);
                UnityEngine.TextureWrapMode __cl_gen_value;translator.Get(L, 2, out __cl_gen_value);
				__cl_gen_to_be_invoked.wrapModeV = __cl_gen_value;
            
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_wrapModeW(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                UnityEngine.Texture __cl_gen_to_be_invoked = (UnityEngine.Texture)translator.FastGetCSObj(L, 1);
                UnityEngine.TextureWrapMode __cl_gen_value;translator.Get(L, 2, out __cl_gen_value);
				__cl_gen_to_be_invoked.wrapModeW = __cl_gen_value;
            
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_mipMapBias(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                UnityEngine.Texture __cl_gen_to_be_invoked = (UnityEngine.Texture)translator.FastGetCSObj(L, 1);
                __cl_gen_to_be_invoked.mipMapBias = (float)LuaAPI.lua_tonumber(L, 2);
            
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_imageContentsHash(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                UnityEngine.Texture __cl_gen_to_be_invoked = (UnityEngine.Texture)translator.FastGetCSObj(L, 1);
                UnityEngine.Hash128 __cl_gen_value;translator.Get(L, 2, out __cl_gen_value);
				__cl_gen_to_be_invoked.imageContentsHash = __cl_gen_value;
            
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 0;
        }
        
		
		
		
		
    }
}
