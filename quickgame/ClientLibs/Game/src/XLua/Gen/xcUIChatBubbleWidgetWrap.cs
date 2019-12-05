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
    public class xcUIChatBubbleWidgetWrap
    {
        public static void __Register(RealStatePtr L)
        {
			ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			XUtils.BeginObjectRegister(typeof(xc.UIChatBubbleWidget), L, translator, 0, 7, 3, 3);
			
			XUtils.RegisterFunc(L, XUtils.METHOD_IDX, "SetModelId", _m_SetModelId);
			XUtils.RegisterFunc(L, XUtils.METHOD_IDX, "Clean", _m_Clean);
			XUtils.RegisterFunc(L, XUtils.METHOD_IDX, "UpdateFlip", _m_UpdateFlip);
			XUtils.RegisterFunc(L, XUtils.METHOD_IDX, "Load", _m_Load);
			XUtils.RegisterFunc(L, XUtils.METHOD_IDX, "RemoveChatBubble", _m_RemoveChatBubble);
			XUtils.RegisterFunc(L, XUtils.METHOD_IDX, "SetDefaultImageEnabled", _m_SetDefaultImageEnabled);
			XUtils.RegisterFunc(L, XUtils.METHOD_IDX, "StopLoadCoroutine", _m_StopLoadCoroutine);
			
			
			XUtils.RegisterFunc(L, XUtils.GETTER_IDX, "mShowingId", _g_get_mShowingId);
            XUtils.RegisterFunc(L, XUtils.GETTER_IDX, "mShowingFileName", _g_get_mShowingFileName);
            XUtils.RegisterFunc(L, XUtils.GETTER_IDX, "mFlip", _g_get_mFlip);
            
			XUtils.RegisterFunc(L, XUtils.SETTER_IDX, "mShowingId", _s_set_mShowingId);
            XUtils.RegisterFunc(L, XUtils.SETTER_IDX, "mShowingFileName", _s_set_mShowingFileName);
            XUtils.RegisterFunc(L, XUtils.SETTER_IDX, "mFlip", _s_set_mFlip);
            
			XUtils.EndObjectRegister(typeof(xc.UIChatBubbleWidget), L, translator, null, null,
			    null, null, null);

		    XUtils.BeginClassRegister(typeof(xc.UIChatBubbleWidget), L, __CreateInstance, 1, 0, 0);
			
			
            
            XUtils.RegisterObject(L, translator, XUtils.CLS_IDX, "UnderlyingSystemType", typeof(xc.UIChatBubbleWidget));
			
			
			XUtils.EndClassRegister(typeof(xc.UIChatBubbleWidget), L, translator);
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int __CreateInstance(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			try {
				if(LuaAPI.lua_gettop(L) == 1)
				{
					
					xc.UIChatBubbleWidget __cl_gen_ret = new xc.UIChatBubbleWidget();
					translator.Push(L, __cl_gen_ret);
					return 1;
				}
				
			}
			catch(System.Exception __gen_e) {
				return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
			}
            return LuaAPI.luaL_error(L, "invalid arguments to xc.UIChatBubbleWidget constructor!");
            
        }
        
		
        
		
        
        
        
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_SetModelId(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            xc.UIChatBubbleWidget __cl_gen_to_be_invoked = (xc.UIChatBubbleWidget)translator.FastGetCSObj(L, 1);
            
            
            try {
                
                {
                    uint modelId = LuaAPI.xlua_touint(L, 2);
                    
                    __cl_gen_to_be_invoked.SetModelId( modelId );
                    
                    
                    
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
            
            
            xc.UIChatBubbleWidget __cl_gen_to_be_invoked = (xc.UIChatBubbleWidget)translator.FastGetCSObj(L, 1);
            
            
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
        static int _m_UpdateFlip(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            xc.UIChatBubbleWidget __cl_gen_to_be_invoked = (xc.UIChatBubbleWidget)translator.FastGetCSObj(L, 1);
            
            
            try {
                
                {
                    
                    __cl_gen_to_be_invoked.UpdateFlip(  );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_Load(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            xc.UIChatBubbleWidget __cl_gen_to_be_invoked = (xc.UIChatBubbleWidget)translator.FastGetCSObj(L, 1);
            
            
            try {
                
                {
                    string fileName = LuaAPI.lua_tostring(L, 2);
                    
                        System.Collections.IEnumerator __cl_gen_ret = __cl_gen_to_be_invoked.Load( fileName );
                        translator.Push(L, __cl_gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_RemoveChatBubble(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            xc.UIChatBubbleWidget __cl_gen_to_be_invoked = (xc.UIChatBubbleWidget)translator.FastGetCSObj(L, 1);
            
            
            try {
                
                {
                    
                    __cl_gen_to_be_invoked.RemoveChatBubble(  );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_SetDefaultImageEnabled(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            xc.UIChatBubbleWidget __cl_gen_to_be_invoked = (xc.UIChatBubbleWidget)translator.FastGetCSObj(L, 1);
            
            
            try {
                
                {
                    bool enabled = LuaAPI.lua_toboolean(L, 2);
                    
                    __cl_gen_to_be_invoked.SetDefaultImageEnabled( enabled );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_StopLoadCoroutine(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            xc.UIChatBubbleWidget __cl_gen_to_be_invoked = (xc.UIChatBubbleWidget)translator.FastGetCSObj(L, 1);
            
            
            try {
                
                {
                    
                    __cl_gen_to_be_invoked.StopLoadCoroutine(  );
                    
                    
                    
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
			
                xc.UIChatBubbleWidget __cl_gen_to_be_invoked = (xc.UIChatBubbleWidget)translator.FastGetCSObj(L, 1);
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
			
                xc.UIChatBubbleWidget __cl_gen_to_be_invoked = (xc.UIChatBubbleWidget)translator.FastGetCSObj(L, 1);
                LuaAPI.lua_pushstring(L, __cl_gen_to_be_invoked.mShowingFileName);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_mFlip(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.UIChatBubbleWidget __cl_gen_to_be_invoked = (xc.UIChatBubbleWidget)translator.FastGetCSObj(L, 1);
                LuaAPI.lua_pushboolean(L, __cl_gen_to_be_invoked.mFlip);
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
			
                xc.UIChatBubbleWidget __cl_gen_to_be_invoked = (xc.UIChatBubbleWidget)translator.FastGetCSObj(L, 1);
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
			
                xc.UIChatBubbleWidget __cl_gen_to_be_invoked = (xc.UIChatBubbleWidget)translator.FastGetCSObj(L, 1);
                __cl_gen_to_be_invoked.mShowingFileName = LuaAPI.lua_tostring(L, 2);
            
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_mFlip(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.UIChatBubbleWidget __cl_gen_to_be_invoked = (xc.UIChatBubbleWidget)translator.FastGetCSObj(L, 1);
                __cl_gen_to_be_invoked.mFlip = LuaAPI.lua_toboolean(L, 2);
            
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 0;
        }
        
		
		
		
		
    }
}
