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
    public class xcCEventActorArgsWrap
    {
        public static void __Register(RealStatePtr L)
        {
			ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			XUtils.BeginObjectRegister(typeof(xc.CEventActorArgs), L, translator, 0, 0, 1, 0);
			
			
			
			XUtils.RegisterFunc(L, XUtils.GETTER_IDX, "Act", _g_get_Act);
            
			
			XUtils.EndObjectRegister(typeof(xc.CEventActorArgs), L, translator, null, null,
			    null, null, null);

		    XUtils.BeginClassRegister(typeof(xc.CEventActorArgs), L, __CreateInstance, 1, 0, 0);
			
			
            
            XUtils.RegisterObject(L, translator, XUtils.CLS_IDX, "UnderlyingSystemType", typeof(xc.CEventActorArgs));
			
			
			XUtils.EndClassRegister(typeof(xc.CEventActorArgs), L, translator);
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int __CreateInstance(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			try {
				if(LuaAPI.lua_gettop(L) == 2 && translator.Assignable<Actor>(L, 2))
				{
					Actor act = (Actor)translator.GetObject(L, 2, typeof(Actor));
					
					xc.CEventActorArgs __cl_gen_ret = new xc.CEventActorArgs(act);
					translator.Push(L, __cl_gen_ret);
					return 1;
				}
				
			}
			catch(System.Exception __gen_e) {
				return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
			}
            return LuaAPI.luaL_error(L, "invalid arguments to xc.CEventActorArgs constructor!");
            
        }
        
		
        
		
        
        
        
        
        
        
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_Act(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.CEventActorArgs __cl_gen_to_be_invoked = (xc.CEventActorArgs)translator.FastGetCSObj(L, 1);
                translator.Push(L, __cl_gen_to_be_invoked.Act);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        
        
		
		
		
		
    }
}
