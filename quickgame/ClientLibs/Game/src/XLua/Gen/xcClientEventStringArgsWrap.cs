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
    public class xcClientEventStringArgsWrap
    {
        public static void __Register(RealStatePtr L)
        {
			ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			XUtils.BeginObjectRegister(typeof(xc.ClientEventStringArgs), L, translator, 0, 0, 1, 1);
			
			
			
			XUtils.RegisterFunc(L, XUtils.GETTER_IDX, "StringArgs", _g_get_StringArgs);
            
			XUtils.RegisterFunc(L, XUtils.SETTER_IDX, "StringArgs", _s_set_StringArgs);
            
			XUtils.EndObjectRegister(typeof(xc.ClientEventStringArgs), L, translator, null, null,
			    null, null, null);

		    XUtils.BeginClassRegister(typeof(xc.ClientEventStringArgs), L, __CreateInstance, 1, 0, 0);
			
			
            
            XUtils.RegisterObject(L, translator, XUtils.CLS_IDX, "UnderlyingSystemType", typeof(xc.ClientEventStringArgs));
			
			
			XUtils.EndClassRegister(typeof(xc.ClientEventStringArgs), L, translator);
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int __CreateInstance(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			try {
				if(LuaAPI.lua_gettop(L) == 2 && (LuaAPI.lua_isnil(L, 2) || LuaAPI.lua_type(L, 2) == LuaTypes.LUA_TSTRING))
				{
					string args = LuaAPI.lua_tostring(L, 2);
					
					xc.ClientEventStringArgs __cl_gen_ret = new xc.ClientEventStringArgs(args);
					translator.Push(L, __cl_gen_ret);
					return 1;
				}
				if(LuaAPI.lua_gettop(L) == 1)
				{
					
					xc.ClientEventStringArgs __cl_gen_ret = new xc.ClientEventStringArgs();
					translator.Push(L, __cl_gen_ret);
					return 1;
				}
				
			}
			catch(System.Exception __gen_e) {
				return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
			}
            return LuaAPI.luaL_error(L, "invalid arguments to xc.ClientEventStringArgs constructor!");
            
        }
        
		
        
		
        
        
        
        
        
        
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_StringArgs(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.ClientEventStringArgs __cl_gen_to_be_invoked = (xc.ClientEventStringArgs)translator.FastGetCSObj(L, 1);
                LuaAPI.lua_pushstring(L, __cl_gen_to_be_invoked.StringArgs);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_StringArgs(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.ClientEventStringArgs __cl_gen_to_be_invoked = (xc.ClientEventStringArgs)translator.FastGetCSObj(L, 1);
                __cl_gen_to_be_invoked.StringArgs = LuaAPI.lua_tostring(L, 2);
            
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 0;
        }
        
		
		
		
		
    }
}
