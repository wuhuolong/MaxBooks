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
    public class xcUIPhotoFrameWidgetWrap
    {
        public static void __Register(RealStatePtr L)
        {
			ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			XUtils.BeginObjectRegister(typeof(xc.UIPhotoFrameWidget), L, translator, 0, 3, 2, 2);
			
			XUtils.RegisterFunc(L, XUtils.METHOD_IDX, "SetModelId", _m_SetModelId);
			XUtils.RegisterFunc(L, XUtils.METHOD_IDX, "SetGrey", _m_SetGrey);
			XUtils.RegisterFunc(L, XUtils.METHOD_IDX, "Clean", _m_Clean);
			
			
			XUtils.RegisterFunc(L, XUtils.GETTER_IDX, "mShowingId", _g_get_mShowingId);
            XUtils.RegisterFunc(L, XUtils.GETTER_IDX, "mShowingFileName", _g_get_mShowingFileName);
            
			XUtils.RegisterFunc(L, XUtils.SETTER_IDX, "mShowingId", _s_set_mShowingId);
            XUtils.RegisterFunc(L, XUtils.SETTER_IDX, "mShowingFileName", _s_set_mShowingFileName);
            
			XUtils.EndObjectRegister(typeof(xc.UIPhotoFrameWidget), L, translator, null, null,
			    null, null, null);

		    XUtils.BeginClassRegister(typeof(xc.UIPhotoFrameWidget), L, __CreateInstance, 1, 0, 0);
			
			
            
            XUtils.RegisterObject(L, translator, XUtils.CLS_IDX, "UnderlyingSystemType", typeof(xc.UIPhotoFrameWidget));
			
			
			XUtils.EndClassRegister(typeof(xc.UIPhotoFrameWidget), L, translator);
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int __CreateInstance(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			try {
				if(LuaAPI.lua_gettop(L) == 1)
				{
					
					xc.UIPhotoFrameWidget __cl_gen_ret = new xc.UIPhotoFrameWidget();
					translator.Push(L, __cl_gen_ret);
					return 1;
				}
				
			}
			catch(System.Exception __gen_e) {
				return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
			}
            return LuaAPI.luaL_error(L, "invalid arguments to xc.UIPhotoFrameWidget constructor!");
            
        }
        
		
        
		
        
        
        
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_SetModelId(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            xc.UIPhotoFrameWidget __cl_gen_to_be_invoked = (xc.UIPhotoFrameWidget)translator.FastGetCSObj(L, 1);
            
            
            try {
                
                {
                    uint modelId = LuaAPI.xlua_touint(L, 2);
                    
                        bool __cl_gen_ret = __cl_gen_to_be_invoked.SetModelId( modelId );
                        LuaAPI.lua_pushboolean(L, __cl_gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_SetGrey(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            xc.UIPhotoFrameWidget __cl_gen_to_be_invoked = (xc.UIPhotoFrameWidget)translator.FastGetCSObj(L, 1);
            
            
            try {
                
                {
                    bool isGrey = LuaAPI.lua_toboolean(L, 2);
                    
                    __cl_gen_to_be_invoked.SetGrey( isGrey );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_Clean(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            xc.UIPhotoFrameWidget __cl_gen_to_be_invoked = (xc.UIPhotoFrameWidget)translator.FastGetCSObj(L, 1);
            
            
            try {
                
                {
                    
                    __cl_gen_to_be_invoked.Clean(  );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        
        
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_mShowingId(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.UIPhotoFrameWidget __cl_gen_to_be_invoked = (xc.UIPhotoFrameWidget)translator.FastGetCSObj(L, 1);
                LuaAPI.xlua_pushuint(L, __cl_gen_to_be_invoked.mShowingId);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_mShowingFileName(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.UIPhotoFrameWidget __cl_gen_to_be_invoked = (xc.UIPhotoFrameWidget)translator.FastGetCSObj(L, 1);
                LuaAPI.lua_pushstring(L, __cl_gen_to_be_invoked.mShowingFileName);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_mShowingId(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.UIPhotoFrameWidget __cl_gen_to_be_invoked = (xc.UIPhotoFrameWidget)translator.FastGetCSObj(L, 1);
                __cl_gen_to_be_invoked.mShowingId = LuaAPI.xlua_touint(L, 2);
            
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_mShowingFileName(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.UIPhotoFrameWidget __cl_gen_to_be_invoked = (xc.UIPhotoFrameWidget)translator.FastGetCSObj(L, 1);
                __cl_gen_to_be_invoked.mShowingFileName = LuaAPI.lua_tostring(L, 2);
            
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 0;
        }
        
		
		
		
		
    }
}
