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
    public class xcuiuguiUILoadingWindowWrap
    {
        public static void __Register(RealStatePtr L)
        {
			ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			XUtils.BeginObjectRegister(typeof(xc.ui.ugui.UILoadingWindow), L, translator, 0, 6, 3, 2);
			
			XUtils.RegisterFunc(L, XUtils.METHOD_IDX, "ShowWaitScreen", _m_ShowWaitScreen);
			XUtils.RegisterFunc(L, XUtils.METHOD_IDX, "SetLoadingTip", _m_SetLoadingTip);
			XUtils.RegisterFunc(L, XUtils.METHOD_IDX, "ShowLoadingBK", _m_ShowLoadingBK);
			XUtils.RegisterFunc(L, XUtils.METHOD_IDX, "SetLoadingImage", _m_SetLoadingImage);
			XUtils.RegisterFunc(L, XUtils.METHOD_IDX, "UpdateLoadingBar", _m_UpdateLoadingBar);
			XUtils.RegisterFunc(L, XUtils.METHOD_IDX, "EnableLuaBehaviour", _m_EnableLuaBehaviour);
			
			
			XUtils.RegisterFunc(L, XUtils.GETTER_IDX, "LoadingBKIsShow", _g_get_LoadingBKIsShow);
            XUtils.RegisterFunc(L, XUtils.GETTER_IDX, "MessageBox", _g_get_MessageBox);
            XUtils.RegisterFunc(L, XUtils.GETTER_IDX, "Background", _g_get_Background);
            
			XUtils.RegisterFunc(L, XUtils.SETTER_IDX, "MessageBox", _s_set_MessageBox);
            XUtils.RegisterFunc(L, XUtils.SETTER_IDX, "Background", _s_set_Background);
            
			XUtils.EndObjectRegister(typeof(xc.ui.ugui.UILoadingWindow), L, translator, null, null,
			    null, null, null);

		    XUtils.BeginClassRegister(typeof(xc.ui.ugui.UILoadingWindow), L, __CreateInstance, 1, 0, 0);
			
			
            
            XUtils.RegisterObject(L, translator, XUtils.CLS_IDX, "UnderlyingSystemType", typeof(xc.ui.ugui.UILoadingWindow));
			
			
			XUtils.EndClassRegister(typeof(xc.ui.ugui.UILoadingWindow), L, translator);
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int __CreateInstance(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			try {
				if(LuaAPI.lua_gettop(L) == 1)
				{
					
					xc.ui.ugui.UILoadingWindow __cl_gen_ret = new xc.ui.ugui.UILoadingWindow();
					translator.Push(L, __cl_gen_ret);
					return 1;
				}
				
			}
			catch(System.Exception __gen_e) {
				return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
			}
            return LuaAPI.luaL_error(L, "invalid arguments to xc.ui.ugui.UILoadingWindow constructor!");
            
        }
        
		
        
		
        
        
        
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_ShowWaitScreen(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            xc.ui.ugui.UILoadingWindow __cl_gen_to_be_invoked = (xc.ui.ugui.UILoadingWindow)translator.FastGetCSObj(L, 1);
            
            
			int __gen_param_count = LuaAPI.lua_gettop(L);
            
            try {
                if(__gen_param_count == 3&& LuaTypes.LUA_TBOOLEAN == LuaAPI.lua_type(L, 2)&& LuaTypes.LUA_TNUMBER == LuaAPI.lua_type(L, 3)) 
                {
                    bool isShow = LuaAPI.lua_toboolean(L, 2);
                    float wait_time = (float)LuaAPI.lua_tonumber(L, 3);
                    
                    __cl_gen_to_be_invoked.ShowWaitScreen( isShow, wait_time );
                    
                    
                    
                    return 0;
                }
                if(__gen_param_count == 2&& LuaTypes.LUA_TBOOLEAN == LuaAPI.lua_type(L, 2)) 
                {
                    bool isShow = LuaAPI.lua_toboolean(L, 2);
                    
                    __cl_gen_to_be_invoked.ShowWaitScreen( isShow );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
            return LuaAPI.luaL_error(L, "invalid arguments to xc.ui.ugui.UILoadingWindow.ShowWaitScreen!");
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_SetLoadingTip(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            xc.ui.ugui.UILoadingWindow __cl_gen_to_be_invoked = (xc.ui.ugui.UILoadingWindow)translator.FastGetCSObj(L, 1);
            
            
            try {
                
                {
                    string text = LuaAPI.lua_tostring(L, 2);
                    
                    __cl_gen_to_be_invoked.SetLoadingTip( text );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_ShowLoadingBK(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            xc.ui.ugui.UILoadingWindow __cl_gen_to_be_invoked = (xc.ui.ugui.UILoadingWindow)translator.FastGetCSObj(L, 1);
            
            
            try {
                
                {
                    bool isShow = LuaAPI.lua_toboolean(L, 2);
                    
                    __cl_gen_to_be_invoked.ShowLoadingBK( isShow );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_SetLoadingImage(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            xc.ui.ugui.UILoadingWindow __cl_gen_to_be_invoked = (xc.ui.ugui.UILoadingWindow)translator.FastGetCSObj(L, 1);
            
            
            try {
                
                {
                    bool isShow = LuaAPI.lua_toboolean(L, 2);
                    bool needDestroy = LuaAPI.lua_toboolean(L, 3);
                    
                    __cl_gen_to_be_invoked.SetLoadingImage( isShow, needDestroy );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_UpdateLoadingBar(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            xc.ui.ugui.UILoadingWindow __cl_gen_to_be_invoked = (xc.ui.ugui.UILoadingWindow)translator.FastGetCSObj(L, 1);
            
            
            try {
                
                {
                    double process = LuaAPI.lua_tonumber(L, 2);
                    
                    __cl_gen_to_be_invoked.UpdateLoadingBar( process );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_EnableLuaBehaviour(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            xc.ui.ugui.UILoadingWindow __cl_gen_to_be_invoked = (xc.ui.ugui.UILoadingWindow)translator.FastGetCSObj(L, 1);
            
            
            try {
                
                {
                    bool isEnable = LuaAPI.lua_toboolean(L, 2);
                    
                    __cl_gen_to_be_invoked.EnableLuaBehaviour( isEnable );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        
        
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_LoadingBKIsShow(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.ui.ugui.UILoadingWindow __cl_gen_to_be_invoked = (xc.ui.ugui.UILoadingWindow)translator.FastGetCSObj(L, 1);
                LuaAPI.lua_pushboolean(L, __cl_gen_to_be_invoked.LoadingBKIsShow);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_MessageBox(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.ui.ugui.UILoadingWindow __cl_gen_to_be_invoked = (xc.ui.ugui.UILoadingWindow)translator.FastGetCSObj(L, 1);
                translator.Push(L, __cl_gen_to_be_invoked.MessageBox);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_Background(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.ui.ugui.UILoadingWindow __cl_gen_to_be_invoked = (xc.ui.ugui.UILoadingWindow)translator.FastGetCSObj(L, 1);
                translator.Push(L, __cl_gen_to_be_invoked.Background);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_MessageBox(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.ui.ugui.UILoadingWindow __cl_gen_to_be_invoked = (xc.ui.ugui.UILoadingWindow)translator.FastGetCSObj(L, 1);
                __cl_gen_to_be_invoked.MessageBox = (MessageBoxUI)translator.GetObject(L, 2, typeof(MessageBoxUI));
            
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_Background(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.ui.ugui.UILoadingWindow __cl_gen_to_be_invoked = (xc.ui.ugui.UILoadingWindow)translator.FastGetCSObj(L, 1);
                __cl_gen_to_be_invoked.Background = (UnityEngine.GameObject)translator.GetObject(L, 2, typeof(UnityEngine.GameObject));
            
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 0;
        }
        
		
		
		
		
    }
}
