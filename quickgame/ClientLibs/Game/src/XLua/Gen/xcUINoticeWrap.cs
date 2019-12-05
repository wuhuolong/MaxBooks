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
    public class xcUINoticeWrap
    {
        public static void __Register(RealStatePtr L)
        {
			ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			XUtils.BeginObjectRegister(typeof(xc.UINotice), L, translator, 0, 10, 1, 1);
			
			XUtils.RegisterFunc(L, XUtils.METHOD_IDX, "Reset", _m_Reset);
			XUtils.RegisterFunc(L, XUtils.METHOD_IDX, "Update", _m_Update);
			XUtils.RegisterFunc(L, XUtils.METHOD_IDX, "ShowMessage_showMaxOne", _m_ShowMessage_showMaxOne);
			XUtils.RegisterFunc(L, XUtils.METHOD_IDX, "ShowMessage", _m_ShowMessage);
			XUtils.RegisterFunc(L, XUtils.METHOD_IDX, "ShowRollingNotice", _m_ShowRollingNotice);
			XUtils.RegisterFunc(L, XUtils.METHOD_IDX, "ShowWarnning", _m_ShowWarnning);
			XUtils.RegisterFunc(L, XUtils.METHOD_IDX, "ShowDanmaku", _m_ShowDanmaku);
			XUtils.RegisterFunc(L, XUtils.METHOD_IDX, "ShowBottomMessage", _m_ShowBottomMessage);
			XUtils.RegisterFunc(L, XUtils.METHOD_IDX, "ShowCommonTextTips", _m_ShowCommonTextTips);
			XUtils.RegisterFunc(L, XUtils.METHOD_IDX, "ShowBigCommonTextTips", _m_ShowBigCommonTextTips);
			
			
			XUtils.RegisterFunc(L, XUtils.GETTER_IDX, "IsShowingRollingNotice", _g_get_IsShowingRollingNotice);
            
			XUtils.RegisterFunc(L, XUtils.SETTER_IDX, "IsShowingRollingNotice", _s_set_IsShowingRollingNotice);
            
			XUtils.EndObjectRegister(typeof(xc.UINotice), L, translator, null, null,
			    null, null, null);

		    XUtils.BeginClassRegister(typeof(xc.UINotice), L, __CreateInstance, 1, 0, 0);
			
			
            
            XUtils.RegisterObject(L, translator, XUtils.CLS_IDX, "UnderlyingSystemType", typeof(xc.UINotice));
			
			
			XUtils.EndClassRegister(typeof(xc.UINotice), L, translator);
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int __CreateInstance(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			try {
				if(LuaAPI.lua_gettop(L) == 1)
				{
					
					xc.UINotice __cl_gen_ret = new xc.UINotice();
					translator.Push(L, __cl_gen_ret);
					return 1;
				}
				
			}
			catch(System.Exception __gen_e) {
				return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
			}
            return LuaAPI.luaL_error(L, "invalid arguments to xc.UINotice constructor!");
            
        }
        
		
        
		
        
        
        
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_Reset(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            xc.UINotice __cl_gen_to_be_invoked = (xc.UINotice)translator.FastGetCSObj(L, 1);
            
            
            try {
                
                {
                    
                    __cl_gen_to_be_invoked.Reset(  );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_Update(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            xc.UINotice __cl_gen_to_be_invoked = (xc.UINotice)translator.FastGetCSObj(L, 1);
            
            
            try {
                
                {
                    
                    __cl_gen_to_be_invoked.Update(  );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_ShowMessage_showMaxOne(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            xc.UINotice __cl_gen_to_be_invoked = (xc.UINotice)translator.FastGetCSObj(L, 1);
            
            
			int __gen_param_count = LuaAPI.lua_gettop(L);
            
            try {
                if(__gen_param_count == 3&& (LuaAPI.lua_isnil(L, 2) || LuaAPI.lua_type(L, 2) == LuaTypes.LUA_TSTRING)&& LuaTypes.LUA_TBOOLEAN == LuaAPI.lua_type(L, 3)) 
                {
                    string str = LuaAPI.lua_tostring(L, 2);
                    bool is_important_msg = LuaAPI.lua_toboolean(L, 3);
                    
                    __cl_gen_to_be_invoked.ShowMessage_showMaxOne( str, is_important_msg );
                    
                    
                    
                    return 0;
                }
                if(__gen_param_count == 2&& (LuaAPI.lua_isnil(L, 2) || LuaAPI.lua_type(L, 2) == LuaTypes.LUA_TSTRING)) 
                {
                    string str = LuaAPI.lua_tostring(L, 2);
                    
                    __cl_gen_to_be_invoked.ShowMessage_showMaxOne( str );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
            return LuaAPI.luaL_error(L, "invalid arguments to xc.UINotice.ShowMessage_showMaxOne!");
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_ShowMessage(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            xc.UINotice __cl_gen_to_be_invoked = (xc.UINotice)translator.FastGetCSObj(L, 1);
            
            
			int __gen_param_count = LuaAPI.lua_gettop(L);
            
            try {
                if(__gen_param_count == 3&& (LuaAPI.lua_isnil(L, 2) || LuaAPI.lua_type(L, 2) == LuaTypes.LUA_TSTRING)&& LuaTypes.LUA_TBOOLEAN == LuaAPI.lua_type(L, 3)) 
                {
                    string str = LuaAPI.lua_tostring(L, 2);
                    bool is_important_msg = LuaAPI.lua_toboolean(L, 3);
                    
                    __cl_gen_to_be_invoked.ShowMessage( str, is_important_msg );
                    
                    
                    
                    return 0;
                }
                if(__gen_param_count == 2&& (LuaAPI.lua_isnil(L, 2) || LuaAPI.lua_type(L, 2) == LuaTypes.LUA_TSTRING)) 
                {
                    string str = LuaAPI.lua_tostring(L, 2);
                    
                    __cl_gen_to_be_invoked.ShowMessage( str );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
            return LuaAPI.luaL_error(L, "invalid arguments to xc.UINotice.ShowMessage!");
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_ShowRollingNotice(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            xc.UINotice __cl_gen_to_be_invoked = (xc.UINotice)translator.FastGetCSObj(L, 1);
            
            
            try {
                
                {
                    string str = LuaAPI.lua_tostring(L, 2);
                    
                    __cl_gen_to_be_invoked.ShowRollingNotice( str );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_ShowWarnning(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            xc.UINotice __cl_gen_to_be_invoked = (xc.UINotice)translator.FastGetCSObj(L, 1);
            
            
            try {
                
                {
                    string str = LuaAPI.lua_tostring(L, 2);
                    
                    __cl_gen_to_be_invoked.ShowWarnning( str );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_ShowDanmaku(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            xc.UINotice __cl_gen_to_be_invoked = (xc.UINotice)translator.FastGetCSObj(L, 1);
            
            
            try {
                
                {
                    string str = LuaAPI.lua_tostring(L, 2);
                    
                    __cl_gen_to_be_invoked.ShowDanmaku( str );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_ShowBottomMessage(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            xc.UINotice __cl_gen_to_be_invoked = (xc.UINotice)translator.FastGetCSObj(L, 1);
            
            
            try {
                
                {
                    string str = LuaAPI.lua_tostring(L, 2);
                    
                    __cl_gen_to_be_invoked.ShowBottomMessage( str );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_ShowCommonTextTips(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            xc.UINotice __cl_gen_to_be_invoked = (xc.UINotice)translator.FastGetCSObj(L, 1);
            
            
            try {
                
                {
                    string str = LuaAPI.lua_tostring(L, 2);
                    
                    __cl_gen_to_be_invoked.ShowCommonTextTips( str );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_ShowBigCommonTextTips(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            xc.UINotice __cl_gen_to_be_invoked = (xc.UINotice)translator.FastGetCSObj(L, 1);
            
            
            try {
                
                {
                    string str = LuaAPI.lua_tostring(L, 2);
                    
                    __cl_gen_to_be_invoked.ShowBigCommonTextTips( str );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        
        
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_IsShowingRollingNotice(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.UINotice __cl_gen_to_be_invoked = (xc.UINotice)translator.FastGetCSObj(L, 1);
                LuaAPI.lua_pushboolean(L, __cl_gen_to_be_invoked.IsShowingRollingNotice);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_IsShowingRollingNotice(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.UINotice __cl_gen_to_be_invoked = (xc.UINotice)translator.FastGetCSObj(L, 1);
                __cl_gen_to_be_invoked.IsShowingRollingNotice = LuaAPI.lua_toboolean(L, 2);
            
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 0;
        }
        
		
		
		
		
    }
}
