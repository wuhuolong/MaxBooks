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
    public class xcClientEventParamArgsWrap
    {
        public static void __Register(RealStatePtr L)
        {
			ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			XUtils.BeginObjectRegister(typeof(xc.ClientEventParamArgs), L, translator, 0, 1, 1, 1);
			
			XUtils.RegisterFunc(L, XUtils.METHOD_IDX, "GetMoreParam", _m_GetMoreParam);
			
			
			XUtils.RegisterFunc(L, XUtils.GETTER_IDX, "mMoreParam", _g_get_mMoreParam);
            
			XUtils.RegisterFunc(L, XUtils.SETTER_IDX, "mMoreParam", _s_set_mMoreParam);
            
			XUtils.EndObjectRegister(typeof(xc.ClientEventParamArgs), L, translator, null, null,
			    null, null, null);

		    XUtils.BeginClassRegister(typeof(xc.ClientEventParamArgs), L, __CreateInstance, 1, 0, 0);
			
			
            
            XUtils.RegisterObject(L, translator, XUtils.CLS_IDX, "UnderlyingSystemType", typeof(xc.ClientEventParamArgs));
			
			
			XUtils.EndClassRegister(typeof(xc.ClientEventParamArgs), L, translator);
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int __CreateInstance(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			try {
				if(LuaAPI.lua_gettop(L) >= 1 && (LuaTypes.LUA_TNONE == LuaAPI.lua_type(L, 2) || translator.Assignable<object>(L, 2)))
				{
					object[] args = translator.GetParams<object>(L, 2);
					
					xc.ClientEventParamArgs __cl_gen_ret = new xc.ClientEventParamArgs(args);
					translator.Push(L, __cl_gen_ret);
					return 1;
				}
				if(LuaAPI.lua_gettop(L) == 1)
				{
					
					xc.ClientEventParamArgs __cl_gen_ret = new xc.ClientEventParamArgs();
					translator.Push(L, __cl_gen_ret);
					return 1;
				}
				
			}
			catch(System.Exception __gen_e) {
				return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
			}
            return LuaAPI.luaL_error(L, "invalid arguments to xc.ClientEventParamArgs constructor!");
            
        }
        
		
        
		
        
        
        
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_GetMoreParam(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            xc.ClientEventParamArgs __cl_gen_to_be_invoked = (xc.ClientEventParamArgs)translator.FastGetCSObj(L, 1);
            
            
            try {
                
                {
                    uint index = LuaAPI.xlua_touint(L, 2);
                    
                        object __cl_gen_ret = __cl_gen_to_be_invoked.GetMoreParam( index );
                        translator.PushAny(L, __cl_gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        
        
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_mMoreParam(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.ClientEventParamArgs __cl_gen_to_be_invoked = (xc.ClientEventParamArgs)translator.FastGetCSObj(L, 1);
                translator.Push(L, __cl_gen_to_be_invoked.mMoreParam);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_mMoreParam(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.ClientEventParamArgs __cl_gen_to_be_invoked = (xc.ClientEventParamArgs)translator.FastGetCSObj(L, 1);
                __cl_gen_to_be_invoked.mMoreParam = (object[])translator.GetObject(L, 2, typeof(object[]));
            
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 0;
        }
        
		
		
		
		
    }
}
