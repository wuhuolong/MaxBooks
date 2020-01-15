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
    public class xcuiuguiUINoticeWindowWrap
    {
        public static void __Register(RealStatePtr L)
        {
			ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			XUtils.BeginObjectRegister(typeof(xc.ui.ugui.UINoticeWindow), L, translator, 0, 0, 3, 12);
			
			
			
			XUtils.RegisterFunc(L, XUtils.GETTER_IDX, "TitleText", _g_get_TitleText);
            XUtils.RegisterFunc(L, XUtils.GETTER_IDX, "ContentText", _g_get_ContentText);
            XUtils.RegisterFunc(L, XUtils.GETTER_IDX, "NoticeWindowType", _g_get_NoticeWindowType);
            
			XUtils.RegisterFunc(L, XUtils.SETTER_IDX, "TitleText", _s_set_TitleText);
            XUtils.RegisterFunc(L, XUtils.SETTER_IDX, "ContentText", _s_set_ContentText);
            XUtils.RegisterFunc(L, XUtils.SETTER_IDX, "OKButtonText", _s_set_OKButtonText);
            XUtils.RegisterFunc(L, XUtils.SETTER_IDX, "CancelButtonText", _s_set_CancelButtonText);
            XUtils.RegisterFunc(L, XUtils.SETTER_IDX, "ToggleText", _s_set_ToggleText);
            XUtils.RegisterFunc(L, XUtils.SETTER_IDX, "ToggleIsOn", _s_set_ToggleIsOn);
            XUtils.RegisterFunc(L, XUtils.SETTER_IDX, "NoticeWindowType", _s_set_NoticeWindowType);
            XUtils.RegisterFunc(L, XUtils.SETTER_IDX, "OKCallback", _s_set_OKCallback);
            XUtils.RegisterFunc(L, XUtils.SETTER_IDX, "OKCallbackParam", _s_set_OKCallbackParam);
            XUtils.RegisterFunc(L, XUtils.SETTER_IDX, "CancelCallback", _s_set_CancelCallback);
            XUtils.RegisterFunc(L, XUtils.SETTER_IDX, "CancelCallbackParam", _s_set_CancelCallbackParam);
            XUtils.RegisterFunc(L, XUtils.SETTER_IDX, "OKWithToggleCallback", _s_set_OKWithToggleCallback);
            
			XUtils.EndObjectRegister(typeof(xc.ui.ugui.UINoticeWindow), L, translator, null, null,
			    null, null, null);

		    XUtils.BeginClassRegister(typeof(xc.ui.ugui.UINoticeWindow), L, __CreateInstance, 1, 0, 0);
			
			
            
            XUtils.RegisterObject(L, translator, XUtils.CLS_IDX, "UnderlyingSystemType", typeof(xc.ui.ugui.UINoticeWindow));
			
			
			XUtils.EndClassRegister(typeof(xc.ui.ugui.UINoticeWindow), L, translator);
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int __CreateInstance(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			try {
				if(LuaAPI.lua_gettop(L) == 1)
				{
					
					xc.ui.ugui.UINoticeWindow __cl_gen_ret = new xc.ui.ugui.UINoticeWindow();
					translator.Push(L, __cl_gen_ret);
					return 1;
				}
				
			}
			catch(System.Exception __gen_e) {
				return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
			}
            return LuaAPI.luaL_error(L, "invalid arguments to xc.ui.ugui.UINoticeWindow constructor!");
            
        }
        
		
        
		
        
        
        
        
        
        
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_TitleText(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.ui.ugui.UINoticeWindow __cl_gen_to_be_invoked = (xc.ui.ugui.UINoticeWindow)translator.FastGetCSObj(L, 1);
                LuaAPI.lua_pushstring(L, __cl_gen_to_be_invoked.TitleText);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_ContentText(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.ui.ugui.UINoticeWindow __cl_gen_to_be_invoked = (xc.ui.ugui.UINoticeWindow)translator.FastGetCSObj(L, 1);
                LuaAPI.lua_pushstring(L, __cl_gen_to_be_invoked.ContentText);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_NoticeWindowType(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.ui.ugui.UINoticeWindow __cl_gen_to_be_invoked = (xc.ui.ugui.UINoticeWindow)translator.FastGetCSObj(L, 1);
                translator.PushxcuiuguiUINoticeWindowEWindowType(L, __cl_gen_to_be_invoked.NoticeWindowType);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_TitleText(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.ui.ugui.UINoticeWindow __cl_gen_to_be_invoked = (xc.ui.ugui.UINoticeWindow)translator.FastGetCSObj(L, 1);
                __cl_gen_to_be_invoked.TitleText = LuaAPI.lua_tostring(L, 2);
            
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_ContentText(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.ui.ugui.UINoticeWindow __cl_gen_to_be_invoked = (xc.ui.ugui.UINoticeWindow)translator.FastGetCSObj(L, 1);
                __cl_gen_to_be_invoked.ContentText = LuaAPI.lua_tostring(L, 2);
            
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_OKButtonText(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.ui.ugui.UINoticeWindow __cl_gen_to_be_invoked = (xc.ui.ugui.UINoticeWindow)translator.FastGetCSObj(L, 1);
                __cl_gen_to_be_invoked.OKButtonText = LuaAPI.lua_tostring(L, 2);
            
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_CancelButtonText(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.ui.ugui.UINoticeWindow __cl_gen_to_be_invoked = (xc.ui.ugui.UINoticeWindow)translator.FastGetCSObj(L, 1);
                __cl_gen_to_be_invoked.CancelButtonText = LuaAPI.lua_tostring(L, 2);
            
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_ToggleText(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.ui.ugui.UINoticeWindow __cl_gen_to_be_invoked = (xc.ui.ugui.UINoticeWindow)translator.FastGetCSObj(L, 1);
                __cl_gen_to_be_invoked.ToggleText = LuaAPI.lua_tostring(L, 2);
            
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_ToggleIsOn(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.ui.ugui.UINoticeWindow __cl_gen_to_be_invoked = (xc.ui.ugui.UINoticeWindow)translator.FastGetCSObj(L, 1);
                __cl_gen_to_be_invoked.ToggleIsOn = LuaAPI.lua_toboolean(L, 2);
            
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_NoticeWindowType(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.ui.ugui.UINoticeWindow __cl_gen_to_be_invoked = (xc.ui.ugui.UINoticeWindow)translator.FastGetCSObj(L, 1);
                xc.ui.ugui.UINoticeWindow.EWindowType __cl_gen_value;translator.Get(L, 2, out __cl_gen_value);
				__cl_gen_to_be_invoked.NoticeWindowType = __cl_gen_value;
            
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_OKCallback(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.ui.ugui.UINoticeWindow __cl_gen_to_be_invoked = (xc.ui.ugui.UINoticeWindow)translator.FastGetCSObj(L, 1);
                __cl_gen_to_be_invoked.OKCallback = translator.GetDelegate<xc.ui.ugui.UINoticeWindow.OkBtnClickedDelegate>(L, 2);
            
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_OKCallbackParam(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.ui.ugui.UINoticeWindow __cl_gen_to_be_invoked = (xc.ui.ugui.UINoticeWindow)translator.FastGetCSObj(L, 1);
                __cl_gen_to_be_invoked.OKCallbackParam = translator.GetObject(L, 2, typeof(object));
            
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_CancelCallback(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.ui.ugui.UINoticeWindow __cl_gen_to_be_invoked = (xc.ui.ugui.UINoticeWindow)translator.FastGetCSObj(L, 1);
                __cl_gen_to_be_invoked.CancelCallback = translator.GetDelegate<xc.ui.ugui.UINoticeWindow.CancelBtnClickedDelegate>(L, 2);
            
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_CancelCallbackParam(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.ui.ugui.UINoticeWindow __cl_gen_to_be_invoked = (xc.ui.ugui.UINoticeWindow)translator.FastGetCSObj(L, 1);
                __cl_gen_to_be_invoked.CancelCallbackParam = translator.GetObject(L, 2, typeof(object));
            
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_OKWithToggleCallback(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.ui.ugui.UINoticeWindow __cl_gen_to_be_invoked = (xc.ui.ugui.UINoticeWindow)translator.FastGetCSObj(L, 1);
                __cl_gen_to_be_invoked.OKWithToggleCallback = translator.GetDelegate<xc.ui.ugui.UINoticeWindow.OkBtnWithToggleClickedDelegate>(L, 2);
            
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 0;
        }
        
		
		
		
		
    }
}
