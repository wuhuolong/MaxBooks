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
    public class xcMarryFireworkManagerWrap
    {
        public static void __Register(RealStatePtr L)
        {
			ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			XUtils.BeginObjectRegister(typeof(xc.MarryFireworkManager), L, translator, 0, 4, 0, 0);
			
			XUtils.RegisterFunc(L, XUtils.METHOD_IDX, "Ignite", _m_Ignite);
			XUtils.RegisterFunc(L, XUtils.METHOD_IDX, "Update", _m_Update);
			XUtils.RegisterFunc(L, XUtils.METHOD_IDX, "PlayEffect", _m_PlayEffect);
			XUtils.RegisterFunc(L, XUtils.METHOD_IDX, "PlayAudio", _m_PlayAudio);
			
			
			
			
			XUtils.EndObjectRegister(typeof(xc.MarryFireworkManager), L, translator, null, null,
			    null, null, null);

		    XUtils.BeginClassRegister(typeof(xc.MarryFireworkManager), L, __CreateInstance, 1, 1, 0);
			
			
            
            XUtils.RegisterObject(L, translator, XUtils.CLS_IDX, "UnderlyingSystemType", typeof(xc.MarryFireworkManager));
			XUtils.RegisterFunc(L, XUtils.CLS_GETTER_IDX, "Instance", _g_get_Instance);
            
			
			XUtils.EndClassRegister(typeof(xc.MarryFireworkManager), L, translator);
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int __CreateInstance(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			try {
				if(LuaAPI.lua_gettop(L) == 1)
				{
					
					xc.MarryFireworkManager __cl_gen_ret = new xc.MarryFireworkManager();
					translator.Push(L, __cl_gen_ret);
					return 1;
				}
				
			}
			catch(System.Exception __gen_e) {
				return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
			}
            return LuaAPI.luaL_error(L, "invalid arguments to xc.MarryFireworkManager constructor!");
            
        }
        
		
        
		
        
        
        
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_Ignite(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            xc.MarryFireworkManager __cl_gen_to_be_invoked = (xc.MarryFireworkManager)translator.FastGetCSObj(L, 1);
            
            
            try {
                
                {
                    uint uuid = LuaAPI.xlua_touint(L, 2);
                    uint gid = LuaAPI.xlua_touint(L, 3);
                    
                    __cl_gen_to_be_invoked.Ignite( uuid, gid );
                    
                    
                    
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
            
            
            xc.MarryFireworkManager __cl_gen_to_be_invoked = (xc.MarryFireworkManager)translator.FastGetCSObj(L, 1);
            
            
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
        static int _m_PlayEffect(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            xc.MarryFireworkManager __cl_gen_to_be_invoked = (xc.MarryFireworkManager)translator.FastGetCSObj(L, 1);
            
            
            try {
                
                {
                    string effectPath = LuaAPI.lua_tostring(L, 2);
                    xc.MarryFireworkManager.EmitInfo emitInfo = (xc.MarryFireworkManager.EmitInfo)translator.GetObject(L, 3, typeof(xc.MarryFireworkManager.EmitInfo));
                    uint emitId = LuaAPI.xlua_touint(L, 4);
                    
                        System.Collections.IEnumerator __cl_gen_ret = __cl_gen_to_be_invoked.PlayEffect( effectPath, emitInfo, emitId );
                        translator.Push(L, __cl_gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_PlayAudio(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            xc.MarryFireworkManager __cl_gen_to_be_invoked = (xc.MarryFireworkManager)translator.FastGetCSObj(L, 1);
            
            
            try {
                
                {
                    string resPath = LuaAPI.lua_tostring(L, 2);
                    xc.MarryFireworkManager.EmitInfo emitInfo = (xc.MarryFireworkManager.EmitInfo)translator.GetObject(L, 3, typeof(xc.MarryFireworkManager.EmitInfo));
                    uint emitId = LuaAPI.xlua_touint(L, 4);
                    
                        System.Collections.IEnumerator __cl_gen_ret = __cl_gen_to_be_invoked.PlayAudio( resPath, emitInfo, emitId );
                        translator.Push(L, __cl_gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        
        
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_Instance(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			    translator.Push(L, xc.MarryFireworkManager.Instance);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        
        
		
		
		
		
    }
}
