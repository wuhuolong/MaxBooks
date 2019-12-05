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
    public class xpatchPatchProgressWrap
    {
        public static void __Register(RealStatePtr L)
        {
			ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			XUtils.BeginObjectRegister(typeof(xpatch.PatchProgress), L, translator, 0, 1, 12, 5);
			
			XUtils.RegisterFunc(L, XUtils.METHOD_IDX, "Start", _m_Start);
			
			
			XUtils.RegisterFunc(L, XUtils.GETTER_IDX, "HasError", _g_get_HasError);
            XUtils.RegisterFunc(L, XUtils.GETTER_IDX, "Current", _g_get_Current);
            XUtils.RegisterFunc(L, XUtils.GETTER_IDX, "Total", _g_get_Total);
            XUtils.RegisterFunc(L, XUtils.GETTER_IDX, "Value", _g_get_Value);
            XUtils.RegisterFunc(L, XUtils.GETTER_IDX, "IsFinish", _g_get_IsFinish);
            XUtils.RegisterFunc(L, XUtils.GETTER_IDX, "IsReady", _g_get_IsReady);
            XUtils.RegisterFunc(L, XUtils.GETTER_IDX, "NeedDownload", _g_get_NeedDownload);
            XUtils.RegisterFunc(L, XUtils.GETTER_IDX, "TotalBytesToDownload", _g_get_TotalBytesToDownload);
            XUtils.RegisterFunc(L, XUtils.GETTER_IDX, "BytesDownloaded", _g_get_BytesDownloaded);
            XUtils.RegisterFunc(L, XUtils.GETTER_IDX, "PatchContext", _g_get_PatchContext);
            XUtils.RegisterFunc(L, XUtils.GETTER_IDX, "StepTxt", _g_get_StepTxt);
            XUtils.RegisterFunc(L, XUtils.GETTER_IDX, "Error", _g_get_Error);
            
			XUtils.RegisterFunc(L, XUtils.SETTER_IDX, "Current", _s_set_Current);
            XUtils.RegisterFunc(L, XUtils.SETTER_IDX, "Total", _s_set_Total);
            XUtils.RegisterFunc(L, XUtils.SETTER_IDX, "PatchContext", _s_set_PatchContext);
            XUtils.RegisterFunc(L, XUtils.SETTER_IDX, "StepTxt", _s_set_StepTxt);
            XUtils.RegisterFunc(L, XUtils.SETTER_IDX, "Error", _s_set_Error);
            
			XUtils.EndObjectRegister(typeof(xpatch.PatchProgress), L, translator, null, null,
			    null, null, null);

		    XUtils.BeginClassRegister(typeof(xpatch.PatchProgress), L, __CreateInstance, 1, 0, 0);
			
			
            
            XUtils.RegisterObject(L, translator, XUtils.CLS_IDX, "UnderlyingSystemType", typeof(xpatch.PatchProgress));
			
			
			XUtils.EndClassRegister(typeof(xpatch.PatchProgress), L, translator);
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int __CreateInstance(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			try {
				if(LuaAPI.lua_gettop(L) == 1)
				{
					
					xpatch.PatchProgress __cl_gen_ret = new xpatch.PatchProgress();
					translator.Push(L, __cl_gen_ret);
					return 1;
				}
				
			}
			catch(System.Exception __gen_e) {
				return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
			}
            return LuaAPI.luaL_error(L, "invalid arguments to xpatch.PatchProgress constructor!");
            
        }
        
		
        
		
        
        
        
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_Start(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            xpatch.PatchProgress __cl_gen_to_be_invoked = (xpatch.PatchProgress)translator.FastGetCSObj(L, 1);
            
            
            try {
                
                {
                    
                        bool __cl_gen_ret = __cl_gen_to_be_invoked.Start(  );
                        LuaAPI.lua_pushboolean(L, __cl_gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        
        
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_HasError(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xpatch.PatchProgress __cl_gen_to_be_invoked = (xpatch.PatchProgress)translator.FastGetCSObj(L, 1);
                LuaAPI.lua_pushboolean(L, __cl_gen_to_be_invoked.HasError);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_Current(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xpatch.PatchProgress __cl_gen_to_be_invoked = (xpatch.PatchProgress)translator.FastGetCSObj(L, 1);
                LuaAPI.xlua_pushinteger(L, __cl_gen_to_be_invoked.Current);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_Total(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xpatch.PatchProgress __cl_gen_to_be_invoked = (xpatch.PatchProgress)translator.FastGetCSObj(L, 1);
                LuaAPI.xlua_pushinteger(L, __cl_gen_to_be_invoked.Total);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_Value(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xpatch.PatchProgress __cl_gen_to_be_invoked = (xpatch.PatchProgress)translator.FastGetCSObj(L, 1);
                LuaAPI.lua_pushnumber(L, __cl_gen_to_be_invoked.Value);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_IsFinish(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xpatch.PatchProgress __cl_gen_to_be_invoked = (xpatch.PatchProgress)translator.FastGetCSObj(L, 1);
                LuaAPI.lua_pushboolean(L, __cl_gen_to_be_invoked.IsFinish);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_IsReady(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xpatch.PatchProgress __cl_gen_to_be_invoked = (xpatch.PatchProgress)translator.FastGetCSObj(L, 1);
                LuaAPI.lua_pushboolean(L, __cl_gen_to_be_invoked.IsReady);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_NeedDownload(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xpatch.PatchProgress __cl_gen_to_be_invoked = (xpatch.PatchProgress)translator.FastGetCSObj(L, 1);
                LuaAPI.lua_pushboolean(L, __cl_gen_to_be_invoked.NeedDownload);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_TotalBytesToDownload(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xpatch.PatchProgress __cl_gen_to_be_invoked = (xpatch.PatchProgress)translator.FastGetCSObj(L, 1);
                LuaAPI.lua_pushint64(L, __cl_gen_to_be_invoked.TotalBytesToDownload);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_BytesDownloaded(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xpatch.PatchProgress __cl_gen_to_be_invoked = (xpatch.PatchProgress)translator.FastGetCSObj(L, 1);
                LuaAPI.lua_pushint64(L, __cl_gen_to_be_invoked.BytesDownloaded);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_PatchContext(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xpatch.PatchProgress __cl_gen_to_be_invoked = (xpatch.PatchProgress)translator.FastGetCSObj(L, 1);
                translator.Push(L, __cl_gen_to_be_invoked.PatchContext);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_StepTxt(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xpatch.PatchProgress __cl_gen_to_be_invoked = (xpatch.PatchProgress)translator.FastGetCSObj(L, 1);
                LuaAPI.lua_pushstring(L, __cl_gen_to_be_invoked.StepTxt);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_Error(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xpatch.PatchProgress __cl_gen_to_be_invoked = (xpatch.PatchProgress)translator.FastGetCSObj(L, 1);
                LuaAPI.lua_pushstring(L, __cl_gen_to_be_invoked.Error);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_Current(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xpatch.PatchProgress __cl_gen_to_be_invoked = (xpatch.PatchProgress)translator.FastGetCSObj(L, 1);
                __cl_gen_to_be_invoked.Current = LuaAPI.xlua_tointeger(L, 2);
            
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_Total(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xpatch.PatchProgress __cl_gen_to_be_invoked = (xpatch.PatchProgress)translator.FastGetCSObj(L, 1);
                __cl_gen_to_be_invoked.Total = LuaAPI.xlua_tointeger(L, 2);
            
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_PatchContext(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xpatch.PatchProgress __cl_gen_to_be_invoked = (xpatch.PatchProgress)translator.FastGetCSObj(L, 1);
                __cl_gen_to_be_invoked.PatchContext = (xpatch.DL_PatchContext)translator.GetObject(L, 2, typeof(xpatch.DL_PatchContext));
            
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_StepTxt(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xpatch.PatchProgress __cl_gen_to_be_invoked = (xpatch.PatchProgress)translator.FastGetCSObj(L, 1);
                __cl_gen_to_be_invoked.StepTxt = LuaAPI.lua_tostring(L, 2);
            
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_Error(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xpatch.PatchProgress __cl_gen_to_be_invoked = (xpatch.PatchProgress)translator.FastGetCSObj(L, 1);
                __cl_gen_to_be_invoked.Error = LuaAPI.lua_tostring(L, 2);
            
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 0;
        }
        
		
		
		
		
    }
}
