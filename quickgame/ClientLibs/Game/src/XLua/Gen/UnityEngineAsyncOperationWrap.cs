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
    public class UnityEngineAsyncOperationWrap
    {
        public static void __Register(RealStatePtr L)
        {
			ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			XUtils.BeginObjectRegister(typeof(UnityEngine.AsyncOperation), L, translator, 0, 1, 4, 2);
			
			
			XUtils.RegisterFunc(L, XUtils.METHOD_IDX, "completed", _e_completed);
			
			XUtils.RegisterFunc(L, XUtils.GETTER_IDX, "isDone", _g_get_isDone);
            XUtils.RegisterFunc(L, XUtils.GETTER_IDX, "progress", _g_get_progress);
            XUtils.RegisterFunc(L, XUtils.GETTER_IDX, "priority", _g_get_priority);
            XUtils.RegisterFunc(L, XUtils.GETTER_IDX, "allowSceneActivation", _g_get_allowSceneActivation);
            
			XUtils.RegisterFunc(L, XUtils.SETTER_IDX, "priority", _s_set_priority);
            XUtils.RegisterFunc(L, XUtils.SETTER_IDX, "allowSceneActivation", _s_set_allowSceneActivation);
            
			XUtils.EndObjectRegister(typeof(UnityEngine.AsyncOperation), L, translator, null, null,
			    null, null, null);

		    XUtils.BeginClassRegister(typeof(UnityEngine.AsyncOperation), L, __CreateInstance, 1, 0, 0);
			
			
            
            XUtils.RegisterObject(L, translator, XUtils.CLS_IDX, "UnderlyingSystemType", typeof(UnityEngine.AsyncOperation));
			
			
			XUtils.EndClassRegister(typeof(UnityEngine.AsyncOperation), L, translator);
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int __CreateInstance(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			try {
				if(LuaAPI.lua_gettop(L) == 1)
				{
					
					UnityEngine.AsyncOperation __cl_gen_ret = new UnityEngine.AsyncOperation();
					translator.Push(L, __cl_gen_ret);
					return 1;
				}
				
			}
			catch(System.Exception __gen_e) {
				return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
			}
            return LuaAPI.luaL_error(L, "invalid arguments to UnityEngine.AsyncOperation constructor!");
            
        }
        
		
        
		
        
        
        
        
        
        
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_isDone(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                UnityEngine.AsyncOperation __cl_gen_to_be_invoked = (UnityEngine.AsyncOperation)translator.FastGetCSObj(L, 1);
                LuaAPI.lua_pushboolean(L, __cl_gen_to_be_invoked.isDone);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_progress(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                UnityEngine.AsyncOperation __cl_gen_to_be_invoked = (UnityEngine.AsyncOperation)translator.FastGetCSObj(L, 1);
                LuaAPI.lua_pushnumber(L, __cl_gen_to_be_invoked.progress);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_priority(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                UnityEngine.AsyncOperation __cl_gen_to_be_invoked = (UnityEngine.AsyncOperation)translator.FastGetCSObj(L, 1);
                LuaAPI.xlua_pushinteger(L, __cl_gen_to_be_invoked.priority);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_allowSceneActivation(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                UnityEngine.AsyncOperation __cl_gen_to_be_invoked = (UnityEngine.AsyncOperation)translator.FastGetCSObj(L, 1);
                LuaAPI.lua_pushboolean(L, __cl_gen_to_be_invoked.allowSceneActivation);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_priority(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                UnityEngine.AsyncOperation __cl_gen_to_be_invoked = (UnityEngine.AsyncOperation)translator.FastGetCSObj(L, 1);
                __cl_gen_to_be_invoked.priority = LuaAPI.xlua_tointeger(L, 2);
            
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_allowSceneActivation(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                UnityEngine.AsyncOperation __cl_gen_to_be_invoked = (UnityEngine.AsyncOperation)translator.FastGetCSObj(L, 1);
                __cl_gen_to_be_invoked.allowSceneActivation = LuaAPI.lua_toboolean(L, 2);
            
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 0;
        }
        
		
		
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _e_completed(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			int __gen_param_count = LuaAPI.lua_gettop(L);
			UnityEngine.AsyncOperation __cl_gen_to_be_invoked = (UnityEngine.AsyncOperation)translator.FastGetCSObj(L, 1);
            try {
                System.Action<UnityEngine.AsyncOperation> __gen_delegate = translator.GetDelegate<System.Action<UnityEngine.AsyncOperation>>(L, 3);
                if (__gen_delegate == null) {
                    return LuaAPI.luaL_error(L, "#3 need System.Action<UnityEngine.AsyncOperation>!");
                }
				
				if (__gen_param_count == 3)
				{
					System.IntPtr strlen;

					System.IntPtr str = LuaAPI.lua_tolstring(L, 2, out strlen);

					if (str != System.IntPtr.Zero && strlen.ToInt32() == 1)
					{
						byte op = System.Runtime.InteropServices.Marshal.ReadByte(str);
					
						
						if (op == (byte)'+') {
							__cl_gen_to_be_invoked.completed += __gen_delegate;
							return 0;
						} 
						
						
						if (op == (byte)'-') {
							__cl_gen_to_be_invoked.completed -= __gen_delegate;
							return 0;
						} 
						
					}
				}
			} catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
			LuaAPI.luaL_error(L, "invalid arguments to UnityEngine.AsyncOperation.completed!");
            return 0;
        }
        
		
		
    }
}
