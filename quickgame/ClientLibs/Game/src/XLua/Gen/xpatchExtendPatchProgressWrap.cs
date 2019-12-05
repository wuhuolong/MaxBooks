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
    public class xpatchExtendPatchProgressWrap
    {
        public static void __Register(RealStatePtr L)
        {
			ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			XUtils.BeginObjectRegister(typeof(xpatch.ExtendPatchProgress), L, translator, 0, 1, 9, 1);
			
			XUtils.RegisterFunc(L, XUtils.METHOD_IDX, "Start", _m_Start);
			
			
			XUtils.RegisterFunc(L, XUtils.GETTER_IDX, "Current", _g_get_Current);
            XUtils.RegisterFunc(L, XUtils.GETTER_IDX, "Total", _g_get_Total);
            XUtils.RegisterFunc(L, XUtils.GETTER_IDX, "Value", _g_get_Value);
            XUtils.RegisterFunc(L, XUtils.GETTER_IDX, "IsFinish", _g_get_IsFinish);
            XUtils.RegisterFunc(L, XUtils.GETTER_IDX, "IsReady", _g_get_IsReady);
            XUtils.RegisterFunc(L, XUtils.GETTER_IDX, "NeedDownload", _g_get_NeedDownload);
            XUtils.RegisterFunc(L, XUtils.GETTER_IDX, "TotalBytesToDownload", _g_get_TotalBytesToDownload);
            XUtils.RegisterFunc(L, XUtils.GETTER_IDX, "BytesDownloaded", _g_get_BytesDownloaded);
            XUtils.RegisterFunc(L, XUtils.GETTER_IDX, "PatchContext", _g_get_PatchContext);
            
			XUtils.RegisterFunc(L, XUtils.SETTER_IDX, "PatchContext", _s_set_PatchContext);
            
			XUtils.EndObjectRegister(typeof(xpatch.ExtendPatchProgress), L, translator, null, null,
			    null, null, null);

		    XUtils.BeginClassRegister(typeof(xpatch.ExtendPatchProgress), L, __CreateInstance, 1, 0, 0);
			
			
            
            XUtils.RegisterObject(L, translator, XUtils.CLS_IDX, "UnderlyingSystemType", typeof(xpatch.ExtendPatchProgress));
			
			
			XUtils.EndClassRegister(typeof(xpatch.ExtendPatchProgress), L, translator);
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int __CreateInstance(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			try {
				if(LuaAPI.lua_gettop(L) == 1)
				{
					
					xpatch.ExtendPatchProgress __cl_gen_ret = new xpatch.ExtendPatchProgress();
					translator.Push(L, __cl_gen_ret);
					return 1;
				}
				
			}
			catch(System.Exception __gen_e) {
				return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
			}
            return LuaAPI.luaL_error(L, "invalid arguments to xpatch.ExtendPatchProgress constructor!");
            
        }
        
		
        
		
        
        
        
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_Start(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            xpatch.ExtendPatchProgress __cl_gen_to_be_invoked = (xpatch.ExtendPatchProgress)translator.FastGetCSObj(L, 1);
            
            
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
        static int _g_get_Current(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xpatch.ExtendPatchProgress __cl_gen_to_be_invoked = (xpatch.ExtendPatchProgress)translator.FastGetCSObj(L, 1);
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
			
                xpatch.ExtendPatchProgress __cl_gen_to_be_invoked = (xpatch.ExtendPatchProgress)translator.FastGetCSObj(L, 1);
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
			
                xpatch.ExtendPatchProgress __cl_gen_to_be_invoked = (xpatch.ExtendPatchProgress)translator.FastGetCSObj(L, 1);
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
			
                xpatch.ExtendPatchProgress __cl_gen_to_be_invoked = (xpatch.ExtendPatchProgress)translator.FastGetCSObj(L, 1);
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
			
                xpatch.ExtendPatchProgress __cl_gen_to_be_invoked = (xpatch.ExtendPatchProgress)translator.FastGetCSObj(L, 1);
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
			
                xpatch.ExtendPatchProgress __cl_gen_to_be_invoked = (xpatch.ExtendPatchProgress)translator.FastGetCSObj(L, 1);
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
			
                xpatch.ExtendPatchProgress __cl_gen_to_be_invoked = (xpatch.ExtendPatchProgress)translator.FastGetCSObj(L, 1);
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
			
                xpatch.ExtendPatchProgress __cl_gen_to_be_invoked = (xpatch.ExtendPatchProgress)translator.FastGetCSObj(L, 1);
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
			
                xpatch.ExtendPatchProgress __cl_gen_to_be_invoked = (xpatch.ExtendPatchProgress)translator.FastGetCSObj(L, 1);
                translator.Push(L, __cl_gen_to_be_invoked.PatchContext);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_PatchContext(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xpatch.ExtendPatchProgress __cl_gen_to_be_invoked = (xpatch.ExtendPatchProgress)translator.FastGetCSObj(L, 1);
                __cl_gen_to_be_invoked.PatchContext = (xpatch.DL_ExtendPatchContext)translator.GetObject(L, 2, typeof(xpatch.DL_ExtendPatchContext));
            
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 0;
        }
        
		
		
		
		
    }
}
