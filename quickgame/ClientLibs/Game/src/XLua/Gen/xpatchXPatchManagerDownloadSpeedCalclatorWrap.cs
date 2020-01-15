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
    public class xpatchXPatchManagerDownloadSpeedCalclatorWrap
    {
        public static void __Register(RealStatePtr L)
        {
			ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			XUtils.BeginObjectRegister(typeof(xpatch.XPatchManager.DownloadSpeedCalclator), L, translator, 0, 1, 1, 0);
			
			XUtils.RegisterFunc(L, XUtils.METHOD_IDX, "Update", _m_Update);
			
			
			XUtils.RegisterFunc(L, XUtils.GETTER_IDX, "BytesDownloadedPerSec", _g_get_BytesDownloadedPerSec);
            
			
			XUtils.EndObjectRegister(typeof(xpatch.XPatchManager.DownloadSpeedCalclator), L, translator, null, null,
			    null, null, null);

		    XUtils.BeginClassRegister(typeof(xpatch.XPatchManager.DownloadSpeedCalclator), L, __CreateInstance, 1, 0, 0);
			
			
            
            XUtils.RegisterObject(L, translator, XUtils.CLS_IDX, "UnderlyingSystemType", typeof(xpatch.XPatchManager.DownloadSpeedCalclator));
			
			
			XUtils.EndClassRegister(typeof(xpatch.XPatchManager.DownloadSpeedCalclator), L, translator);
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int __CreateInstance(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			try {
				if(LuaAPI.lua_gettop(L) == 1)
				{
					
					xpatch.XPatchManager.DownloadSpeedCalclator __cl_gen_ret = new xpatch.XPatchManager.DownloadSpeedCalclator();
					translator.Push(L, __cl_gen_ret);
					return 1;
				}
				
			}
			catch(System.Exception __gen_e) {
				return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
			}
            return LuaAPI.luaL_error(L, "invalid arguments to xpatch.XPatchManager.DownloadSpeedCalclator constructor!");
            
        }
        
		
        
		
        
        
        
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_Update(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            xpatch.XPatchManager.DownloadSpeedCalclator __cl_gen_to_be_invoked = (xpatch.XPatchManager.DownloadSpeedCalclator)translator.FastGetCSObj(L, 1);
            
            
            try {
                
                {
                    xpatch.SimplePool<xpatch.DL_BundleContext> downloading_pool = (xpatch.SimplePool<xpatch.DL_BundleContext>)translator.GetObject(L, 2, typeof(xpatch.SimplePool<xpatch.DL_BundleContext>));
                    float dt = (float)LuaAPI.lua_tonumber(L, 3);
                    
                    __cl_gen_to_be_invoked.Update( downloading_pool, dt );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        
        
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_BytesDownloadedPerSec(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xpatch.XPatchManager.DownloadSpeedCalclator __cl_gen_to_be_invoked = (xpatch.XPatchManager.DownloadSpeedCalclator)translator.FastGetCSObj(L, 1);
                LuaAPI.lua_pushnumber(L, __cl_gen_to_be_invoked.BytesDownloadedPerSec);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        
        
		
		
		
		
    }
}
