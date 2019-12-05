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
    public class LoadMaJiaImageWrap
    {
        public static void __Register(RealStatePtr L)
        {
			ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			XUtils.BeginObjectRegister(typeof(LoadMaJiaImage), L, translator, 0, 3, 2, 2);
			
			XUtils.RegisterFunc(L, XUtils.METHOD_IDX, "GetRawImage", _m_GetRawImage);
			XUtils.RegisterFunc(L, XUtils.METHOD_IDX, "SetCallBack", _m_SetCallBack);
			XUtils.RegisterFunc(L, XUtils.METHOD_IDX, "SetFailCallBack", _m_SetFailCallBack);
			
			
			XUtils.RegisterFunc(L, XUtils.GETTER_IDX, "mIsNativeSize", _g_get_mIsNativeSize);
            XUtils.RegisterFunc(L, XUtils.GETTER_IDX, "mPath", _g_get_mPath);
            
			XUtils.RegisterFunc(L, XUtils.SETTER_IDX, "mIsNativeSize", _s_set_mIsNativeSize);
            XUtils.RegisterFunc(L, XUtils.SETTER_IDX, "mPath", _s_set_mPath);
            
			XUtils.EndObjectRegister(typeof(LoadMaJiaImage), L, translator, null, null,
			    null, null, null);

		    XUtils.BeginClassRegister(typeof(LoadMaJiaImage), L, __CreateInstance, 1, 0, 0);
			
			
            
            XUtils.RegisterObject(L, translator, XUtils.CLS_IDX, "UnderlyingSystemType", typeof(LoadMaJiaImage));
			
			
			XUtils.EndClassRegister(typeof(LoadMaJiaImage), L, translator);
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int __CreateInstance(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			try {
				if(LuaAPI.lua_gettop(L) == 1)
				{
					
					LoadMaJiaImage __cl_gen_ret = new LoadMaJiaImage();
					translator.Push(L, __cl_gen_ret);
					return 1;
				}
				
			}
			catch(System.Exception __gen_e) {
				return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
			}
            return LuaAPI.luaL_error(L, "invalid arguments to LoadMaJiaImage constructor!");
            
        }
        
		
        
		
        
        
        
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_GetRawImage(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            LoadMaJiaImage __cl_gen_to_be_invoked = (LoadMaJiaImage)translator.FastGetCSObj(L, 1);
            
            
            try {
                
                {
                    
                        UnityEngine.UI.RawImage __cl_gen_ret = __cl_gen_to_be_invoked.GetRawImage(  );
                        translator.Push(L, __cl_gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_SetCallBack(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            LoadMaJiaImage __cl_gen_to_be_invoked = (LoadMaJiaImage)translator.FastGetCSObj(L, 1);
            
            
            try {
                
                {
                    System.Action callback = translator.GetDelegate<System.Action>(L, 2);
                    
                    __cl_gen_to_be_invoked.SetCallBack( callback );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_SetFailCallBack(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            LoadMaJiaImage __cl_gen_to_be_invoked = (LoadMaJiaImage)translator.FastGetCSObj(L, 1);
            
            
            try {
                
                {
                    System.Action callback = translator.GetDelegate<System.Action>(L, 2);
                    
                    __cl_gen_to_be_invoked.SetFailCallBack( callback );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        
        
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_mIsNativeSize(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                LoadMaJiaImage __cl_gen_to_be_invoked = (LoadMaJiaImage)translator.FastGetCSObj(L, 1);
                LuaAPI.lua_pushboolean(L, __cl_gen_to_be_invoked.mIsNativeSize);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_mPath(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                LoadMaJiaImage __cl_gen_to_be_invoked = (LoadMaJiaImage)translator.FastGetCSObj(L, 1);
                LuaAPI.lua_pushstring(L, __cl_gen_to_be_invoked.mPath);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_mIsNativeSize(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                LoadMaJiaImage __cl_gen_to_be_invoked = (LoadMaJiaImage)translator.FastGetCSObj(L, 1);
                __cl_gen_to_be_invoked.mIsNativeSize = LuaAPI.lua_toboolean(L, 2);
            
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_mPath(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                LoadMaJiaImage __cl_gen_to_be_invoked = (LoadMaJiaImage)translator.FastGetCSObj(L, 1);
                __cl_gen_to_be_invoked.mPath = LuaAPI.lua_tostring(L, 2);
            
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 0;
        }
        
		
		
		
		
    }
}
