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
    public class xcClientEventBaseArgsWrap
    {
        public static void __Register(RealStatePtr L)
        {
			ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			XUtils.BeginObjectRegister(typeof(xc.ClientEventBaseArgs), L, translator, 0, 1, 1, 1);
			
			XUtils.RegisterFunc(L, XUtils.METHOD_IDX, "GetArg", _m_GetArg);
			
			
			XUtils.RegisterFunc(L, XUtils.GETTER_IDX, "Arg", _g_get_Arg);
            
			XUtils.RegisterFunc(L, XUtils.SETTER_IDX, "Arg", _s_set_Arg);
            
			XUtils.EndObjectRegister(typeof(xc.ClientEventBaseArgs), L, translator, null, null,
			    null, null, null);

		    XUtils.BeginClassRegister(typeof(xc.ClientEventBaseArgs), L, __CreateInstance, 1, 0, 0);
			
			
            
            XUtils.RegisterObject(L, translator, XUtils.CLS_IDX, "UnderlyingSystemType", typeof(xc.ClientEventBaseArgs));
			
			
			XUtils.EndClassRegister(typeof(xc.ClientEventBaseArgs), L, translator);
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int __CreateInstance(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			try {
				if(LuaAPI.lua_gettop(L) == 2 && translator.Assignable<object>(L, 2))
				{
					object obj = translator.GetObject(L, 2, typeof(object));
					
					xc.ClientEventBaseArgs __cl_gen_ret = new xc.ClientEventBaseArgs(obj);
					translator.Push(L, __cl_gen_ret);
					return 1;
				}
				if(LuaAPI.lua_gettop(L) == 1)
				{
					
					xc.ClientEventBaseArgs __cl_gen_ret = new xc.ClientEventBaseArgs();
					translator.Push(L, __cl_gen_ret);
					return 1;
				}
				
			}
			catch(System.Exception __gen_e) {
				return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
			}
            return LuaAPI.luaL_error(L, "invalid arguments to xc.ClientEventBaseArgs constructor!");
            
        }
        
		
        
		
        
        
        
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_GetArg(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            xc.ClientEventBaseArgs __cl_gen_to_be_invoked = (xc.ClientEventBaseArgs)translator.FastGetCSObj(L, 1);
            
            
            try {
                
                {
                    
                        object __cl_gen_ret = __cl_gen_to_be_invoked.GetArg(  );
                        translator.PushAny(L, __cl_gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        
        
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_Arg(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.ClientEventBaseArgs __cl_gen_to_be_invoked = (xc.ClientEventBaseArgs)translator.FastGetCSObj(L, 1);
                translator.PushAny(L, __cl_gen_to_be_invoked.Arg);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_Arg(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.ClientEventBaseArgs __cl_gen_to_be_invoked = (xc.ClientEventBaseArgs)translator.FastGetCSObj(L, 1);
                __cl_gen_to_be_invoked.Arg = translator.GetObject(L, 2, typeof(object));
            
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 0;
        }
        
		
		
		
		
    }
}
