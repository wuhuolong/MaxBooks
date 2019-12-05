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
    public class xcDBNoticeNoticeWrap
    {
        public static void __Register(RealStatePtr L)
        {
			ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			XUtils.BeginObjectRegister(typeof(xc.DBNotice.Notice), L, translator, 0, 1, 19, 8);
			
			XUtils.RegisterFunc(L, XUtils.METHOD_IDX, "GetContent", _m_GetContent);
			
			
			XUtils.RegisterFunc(L, XUtils.GETTER_IDX, "PlayInWorldChannel", _g_get_PlayInWorldChannel);
            XUtils.RegisterFunc(L, XUtils.GETTER_IDX, "PlayInGuildChannel", _g_get_PlayInGuildChannel);
            XUtils.RegisterFunc(L, XUtils.GETTER_IDX, "PlayInTeamChannel", _g_get_PlayInTeamChannel);
            XUtils.RegisterFunc(L, XUtils.GETTER_IDX, "PlayInCurChannel", _g_get_PlayInCurChannel);
            XUtils.RegisterFunc(L, XUtils.GETTER_IDX, "PlayInSystemChannel", _g_get_PlayInSystemChannel);
            XUtils.RegisterFunc(L, XUtils.GETTER_IDX, "PlayInPrivateChannel", _g_get_PlayInPrivateChannel);
            XUtils.RegisterFunc(L, XUtils.GETTER_IDX, "PlayInBottomMsg", _g_get_PlayInBottomMsg);
            XUtils.RegisterFunc(L, XUtils.GETTER_IDX, "PlayInRollingNotice", _g_get_PlayInRollingNotice);
            XUtils.RegisterFunc(L, XUtils.GETTER_IDX, "PlayInDanmaku", _g_get_PlayInDanmaku);
            XUtils.RegisterFunc(L, XUtils.GETTER_IDX, "PlayInSpanChannel", _g_get_PlayInSpanChannel);
            XUtils.RegisterFunc(L, XUtils.GETTER_IDX, "PlayInTrumpet", _g_get_PlayInTrumpet);
            XUtils.RegisterFunc(L, XUtils.GETTER_IDX, "Id", _g_get_Id);
            XUtils.RegisterFunc(L, XUtils.GETTER_IDX, "Template", _g_get_Template);
            XUtils.RegisterFunc(L, XUtils.GETTER_IDX, "RichTemplate", _g_get_RichTemplate);
            XUtils.RegisterFunc(L, XUtils.GETTER_IDX, "Limited", _g_get_Limited);
            XUtils.RegisterFunc(L, XUtils.GETTER_IDX, "Interval", _g_get_Interval);
            XUtils.RegisterFunc(L, XUtils.GETTER_IDX, "MinLv", _g_get_MinLv);
            XUtils.RegisterFunc(L, XUtils.GETTER_IDX, "MaxLv", _g_get_MaxLv);
            XUtils.RegisterFunc(L, XUtils.GETTER_IDX, "ShowChannels", _g_get_ShowChannels);
            
			XUtils.RegisterFunc(L, XUtils.SETTER_IDX, "Id", _s_set_Id);
            XUtils.RegisterFunc(L, XUtils.SETTER_IDX, "Template", _s_set_Template);
            XUtils.RegisterFunc(L, XUtils.SETTER_IDX, "RichTemplate", _s_set_RichTemplate);
            XUtils.RegisterFunc(L, XUtils.SETTER_IDX, "Limited", _s_set_Limited);
            XUtils.RegisterFunc(L, XUtils.SETTER_IDX, "Interval", _s_set_Interval);
            XUtils.RegisterFunc(L, XUtils.SETTER_IDX, "MinLv", _s_set_MinLv);
            XUtils.RegisterFunc(L, XUtils.SETTER_IDX, "MaxLv", _s_set_MaxLv);
            XUtils.RegisterFunc(L, XUtils.SETTER_IDX, "ShowChannels", _s_set_ShowChannels);
            
			XUtils.EndObjectRegister(typeof(xc.DBNotice.Notice), L, translator, null, null,
			    null, null, null);

		    XUtils.BeginClassRegister(typeof(xc.DBNotice.Notice), L, __CreateInstance, 1, 0, 0);
			
			
            
            XUtils.RegisterObject(L, translator, XUtils.CLS_IDX, "UnderlyingSystemType", typeof(xc.DBNotice.Notice));
			
			
			XUtils.EndClassRegister(typeof(xc.DBNotice.Notice), L, translator);
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int __CreateInstance(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			try {
				if(LuaAPI.lua_gettop(L) == 1)
				{
					
					xc.DBNotice.Notice __cl_gen_ret = new xc.DBNotice.Notice();
					translator.Push(L, __cl_gen_ret);
					return 1;
				}
				
			}
			catch(System.Exception __gen_e) {
				return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
			}
            return LuaAPI.luaL_error(L, "invalid arguments to xc.DBNotice.Notice constructor!");
            
        }
        
		
        
		
        
        
        
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_GetContent(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            xc.DBNotice.Notice __cl_gen_to_be_invoked = (xc.DBNotice.Notice)translator.FastGetCSObj(L, 1);
            
            
            try {
                
                {
                    string[] param_list = (string[])translator.GetObject(L, 2, typeof(string[]));
                    
                        string __cl_gen_ret = __cl_gen_to_be_invoked.GetContent( param_list );
                        LuaAPI.lua_pushstring(L, __cl_gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        
        
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_PlayInWorldChannel(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.DBNotice.Notice __cl_gen_to_be_invoked = (xc.DBNotice.Notice)translator.FastGetCSObj(L, 1);
                LuaAPI.lua_pushboolean(L, __cl_gen_to_be_invoked.PlayInWorldChannel);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_PlayInGuildChannel(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.DBNotice.Notice __cl_gen_to_be_invoked = (xc.DBNotice.Notice)translator.FastGetCSObj(L, 1);
                LuaAPI.lua_pushboolean(L, __cl_gen_to_be_invoked.PlayInGuildChannel);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_PlayInTeamChannel(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.DBNotice.Notice __cl_gen_to_be_invoked = (xc.DBNotice.Notice)translator.FastGetCSObj(L, 1);
                LuaAPI.lua_pushboolean(L, __cl_gen_to_be_invoked.PlayInTeamChannel);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_PlayInCurChannel(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.DBNotice.Notice __cl_gen_to_be_invoked = (xc.DBNotice.Notice)translator.FastGetCSObj(L, 1);
                LuaAPI.lua_pushboolean(L, __cl_gen_to_be_invoked.PlayInCurChannel);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_PlayInSystemChannel(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.DBNotice.Notice __cl_gen_to_be_invoked = (xc.DBNotice.Notice)translator.FastGetCSObj(L, 1);
                LuaAPI.lua_pushboolean(L, __cl_gen_to_be_invoked.PlayInSystemChannel);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_PlayInPrivateChannel(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.DBNotice.Notice __cl_gen_to_be_invoked = (xc.DBNotice.Notice)translator.FastGetCSObj(L, 1);
                LuaAPI.lua_pushboolean(L, __cl_gen_to_be_invoked.PlayInPrivateChannel);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_PlayInBottomMsg(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.DBNotice.Notice __cl_gen_to_be_invoked = (xc.DBNotice.Notice)translator.FastGetCSObj(L, 1);
                LuaAPI.lua_pushboolean(L, __cl_gen_to_be_invoked.PlayInBottomMsg);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_PlayInRollingNotice(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.DBNotice.Notice __cl_gen_to_be_invoked = (xc.DBNotice.Notice)translator.FastGetCSObj(L, 1);
                LuaAPI.lua_pushboolean(L, __cl_gen_to_be_invoked.PlayInRollingNotice);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_PlayInDanmaku(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.DBNotice.Notice __cl_gen_to_be_invoked = (xc.DBNotice.Notice)translator.FastGetCSObj(L, 1);
                LuaAPI.lua_pushboolean(L, __cl_gen_to_be_invoked.PlayInDanmaku);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_PlayInSpanChannel(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.DBNotice.Notice __cl_gen_to_be_invoked = (xc.DBNotice.Notice)translator.FastGetCSObj(L, 1);
                LuaAPI.lua_pushboolean(L, __cl_gen_to_be_invoked.PlayInSpanChannel);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_PlayInTrumpet(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.DBNotice.Notice __cl_gen_to_be_invoked = (xc.DBNotice.Notice)translator.FastGetCSObj(L, 1);
                LuaAPI.lua_pushboolean(L, __cl_gen_to_be_invoked.PlayInTrumpet);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_Id(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.DBNotice.Notice __cl_gen_to_be_invoked = (xc.DBNotice.Notice)translator.FastGetCSObj(L, 1);
                LuaAPI.xlua_pushuint(L, __cl_gen_to_be_invoked.Id);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_Template(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.DBNotice.Notice __cl_gen_to_be_invoked = (xc.DBNotice.Notice)translator.FastGetCSObj(L, 1);
                LuaAPI.lua_pushstring(L, __cl_gen_to_be_invoked.Template);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_RichTemplate(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.DBNotice.Notice __cl_gen_to_be_invoked = (xc.DBNotice.Notice)translator.FastGetCSObj(L, 1);
                LuaAPI.lua_pushstring(L, __cl_gen_to_be_invoked.RichTemplate);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_Limited(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.DBNotice.Notice __cl_gen_to_be_invoked = (xc.DBNotice.Notice)translator.FastGetCSObj(L, 1);
                LuaAPI.xlua_pushuint(L, __cl_gen_to_be_invoked.Limited);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_Interval(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.DBNotice.Notice __cl_gen_to_be_invoked = (xc.DBNotice.Notice)translator.FastGetCSObj(L, 1);
                LuaAPI.xlua_pushuint(L, __cl_gen_to_be_invoked.Interval);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_MinLv(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.DBNotice.Notice __cl_gen_to_be_invoked = (xc.DBNotice.Notice)translator.FastGetCSObj(L, 1);
                LuaAPI.xlua_pushuint(L, __cl_gen_to_be_invoked.MinLv);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_MaxLv(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.DBNotice.Notice __cl_gen_to_be_invoked = (xc.DBNotice.Notice)translator.FastGetCSObj(L, 1);
                LuaAPI.xlua_pushuint(L, __cl_gen_to_be_invoked.MaxLv);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_ShowChannels(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.DBNotice.Notice __cl_gen_to_be_invoked = (xc.DBNotice.Notice)translator.FastGetCSObj(L, 1);
                translator.Push(L, __cl_gen_to_be_invoked.ShowChannels);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_Id(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.DBNotice.Notice __cl_gen_to_be_invoked = (xc.DBNotice.Notice)translator.FastGetCSObj(L, 1);
                __cl_gen_to_be_invoked.Id = LuaAPI.xlua_touint(L, 2);
            
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_Template(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.DBNotice.Notice __cl_gen_to_be_invoked = (xc.DBNotice.Notice)translator.FastGetCSObj(L, 1);
                __cl_gen_to_be_invoked.Template = LuaAPI.lua_tostring(L, 2);
            
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_RichTemplate(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.DBNotice.Notice __cl_gen_to_be_invoked = (xc.DBNotice.Notice)translator.FastGetCSObj(L, 1);
                __cl_gen_to_be_invoked.RichTemplate = LuaAPI.lua_tostring(L, 2);
            
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_Limited(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.DBNotice.Notice __cl_gen_to_be_invoked = (xc.DBNotice.Notice)translator.FastGetCSObj(L, 1);
                __cl_gen_to_be_invoked.Limited = LuaAPI.xlua_touint(L, 2);
            
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_Interval(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.DBNotice.Notice __cl_gen_to_be_invoked = (xc.DBNotice.Notice)translator.FastGetCSObj(L, 1);
                __cl_gen_to_be_invoked.Interval = LuaAPI.xlua_touint(L, 2);
            
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_MinLv(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.DBNotice.Notice __cl_gen_to_be_invoked = (xc.DBNotice.Notice)translator.FastGetCSObj(L, 1);
                __cl_gen_to_be_invoked.MinLv = LuaAPI.xlua_touint(L, 2);
            
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_MaxLv(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.DBNotice.Notice __cl_gen_to_be_invoked = (xc.DBNotice.Notice)translator.FastGetCSObj(L, 1);
                __cl_gen_to_be_invoked.MaxLv = LuaAPI.xlua_touint(L, 2);
            
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_ShowChannels(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.DBNotice.Notice __cl_gen_to_be_invoked = (xc.DBNotice.Notice)translator.FastGetCSObj(L, 1);
                __cl_gen_to_be_invoked.ShowChannels = (System.Collections.Generic.List<uint>)translator.GetObject(L, 2, typeof(System.Collections.Generic.List<uint>));
            
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 0;
        }
        
		
		
		
		
    }
}
