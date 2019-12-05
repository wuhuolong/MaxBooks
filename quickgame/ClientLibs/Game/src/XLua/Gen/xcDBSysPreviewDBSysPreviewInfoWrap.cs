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
    public class xcDBSysPreviewDBSysPreviewInfoWrap
    {
        public static void __Register(RealStatePtr L)
        {
			ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			XUtils.BeginObjectRegister(typeof(xc.DBSysPreview.DBSysPreviewInfo), L, translator, 0, 0, 5, 5);
			
			
			
			XUtils.RegisterFunc(L, XUtils.GETTER_IDX, "SysId", _g_get_SysId);
            XUtils.RegisterFunc(L, XUtils.GETTER_IDX, "Notice", _g_get_Notice);
            XUtils.RegisterFunc(L, XUtils.GETTER_IDX, "UiNotice", _g_get_UiNotice);
            XUtils.RegisterFunc(L, XUtils.GETTER_IDX, "RewardId", _g_get_RewardId);
            XUtils.RegisterFunc(L, XUtils.GETTER_IDX, "SysDesc", _g_get_SysDesc);
            
			XUtils.RegisterFunc(L, XUtils.SETTER_IDX, "SysId", _s_set_SysId);
            XUtils.RegisterFunc(L, XUtils.SETTER_IDX, "Notice", _s_set_Notice);
            XUtils.RegisterFunc(L, XUtils.SETTER_IDX, "UiNotice", _s_set_UiNotice);
            XUtils.RegisterFunc(L, XUtils.SETTER_IDX, "RewardId", _s_set_RewardId);
            XUtils.RegisterFunc(L, XUtils.SETTER_IDX, "SysDesc", _s_set_SysDesc);
            
			XUtils.EndObjectRegister(typeof(xc.DBSysPreview.DBSysPreviewInfo), L, translator, null, null,
			    null, null, null);

		    XUtils.BeginClassRegister(typeof(xc.DBSysPreview.DBSysPreviewInfo), L, __CreateInstance, 1, 0, 0);
			
			
            
            XUtils.RegisterObject(L, translator, XUtils.CLS_IDX, "UnderlyingSystemType", typeof(xc.DBSysPreview.DBSysPreviewInfo));
			
			
			XUtils.EndClassRegister(typeof(xc.DBSysPreview.DBSysPreviewInfo), L, translator);
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int __CreateInstance(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			try {
				if(LuaAPI.lua_gettop(L) == 1)
				{
					
					xc.DBSysPreview.DBSysPreviewInfo __cl_gen_ret = new xc.DBSysPreview.DBSysPreviewInfo();
					translator.Push(L, __cl_gen_ret);
					return 1;
				}
				
			}
			catch(System.Exception __gen_e) {
				return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
			}
            return LuaAPI.luaL_error(L, "invalid arguments to xc.DBSysPreview.DBSysPreviewInfo constructor!");
            
        }
        
		
        
		
        
        
        
        
        
        
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_SysId(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.DBSysPreview.DBSysPreviewInfo __cl_gen_to_be_invoked = (xc.DBSysPreview.DBSysPreviewInfo)translator.FastGetCSObj(L, 1);
                LuaAPI.xlua_pushuint(L, __cl_gen_to_be_invoked.SysId);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_Notice(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.DBSysPreview.DBSysPreviewInfo __cl_gen_to_be_invoked = (xc.DBSysPreview.DBSysPreviewInfo)translator.FastGetCSObj(L, 1);
                LuaAPI.lua_pushstring(L, __cl_gen_to_be_invoked.Notice);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_UiNotice(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.DBSysPreview.DBSysPreviewInfo __cl_gen_to_be_invoked = (xc.DBSysPreview.DBSysPreviewInfo)translator.FastGetCSObj(L, 1);
                LuaAPI.lua_pushstring(L, __cl_gen_to_be_invoked.UiNotice);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_RewardId(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.DBSysPreview.DBSysPreviewInfo __cl_gen_to_be_invoked = (xc.DBSysPreview.DBSysPreviewInfo)translator.FastGetCSObj(L, 1);
                LuaAPI.xlua_pushuint(L, __cl_gen_to_be_invoked.RewardId);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_SysDesc(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.DBSysPreview.DBSysPreviewInfo __cl_gen_to_be_invoked = (xc.DBSysPreview.DBSysPreviewInfo)translator.FastGetCSObj(L, 1);
                LuaAPI.lua_pushstring(L, __cl_gen_to_be_invoked.SysDesc);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_SysId(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.DBSysPreview.DBSysPreviewInfo __cl_gen_to_be_invoked = (xc.DBSysPreview.DBSysPreviewInfo)translator.FastGetCSObj(L, 1);
                __cl_gen_to_be_invoked.SysId = LuaAPI.xlua_touint(L, 2);
            
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_Notice(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.DBSysPreview.DBSysPreviewInfo __cl_gen_to_be_invoked = (xc.DBSysPreview.DBSysPreviewInfo)translator.FastGetCSObj(L, 1);
                __cl_gen_to_be_invoked.Notice = LuaAPI.lua_tostring(L, 2);
            
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_UiNotice(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.DBSysPreview.DBSysPreviewInfo __cl_gen_to_be_invoked = (xc.DBSysPreview.DBSysPreviewInfo)translator.FastGetCSObj(L, 1);
                __cl_gen_to_be_invoked.UiNotice = LuaAPI.lua_tostring(L, 2);
            
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_RewardId(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.DBSysPreview.DBSysPreviewInfo __cl_gen_to_be_invoked = (xc.DBSysPreview.DBSysPreviewInfo)translator.FastGetCSObj(L, 1);
                __cl_gen_to_be_invoked.RewardId = LuaAPI.xlua_touint(L, 2);
            
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_SysDesc(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.DBSysPreview.DBSysPreviewInfo __cl_gen_to_be_invoked = (xc.DBSysPreview.DBSysPreviewInfo)translator.FastGetCSObj(L, 1);
                __cl_gen_to_be_invoked.SysDesc = LuaAPI.lua_tostring(L, 2);
            
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 0;
        }
        
		
		
		
		
    }
}
