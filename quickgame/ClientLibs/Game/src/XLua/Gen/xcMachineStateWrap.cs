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
    public class xcMachineStateWrap
    {
        public static void __Register(RealStatePtr L)
        {
			ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			XUtils.BeginObjectRegister(typeof(xc.Machine.State), L, translator, 0, 16, 1, 0);
			
			XUtils.RegisterFunc(L, XUtils.METHOD_IDX, "Reset", _m_Reset);
			XUtils.RegisterFunc(L, XUtils.METHOD_IDX, "GetID", _m_GetID);
			XUtils.RegisterFunc(L, XUtils.METHOD_IDX, "GetOwner", _m_GetOwner);
			XUtils.RegisterFunc(L, XUtils.METHOD_IDX, "GetChild", _m_GetChild);
			XUtils.RegisterFunc(L, XUtils.METHOD_IDX, "GetParent", _m_GetParent);
			XUtils.RegisterFunc(L, XUtils.METHOD_IDX, "SetChild", _m_SetChild);
			XUtils.RegisterFunc(L, XUtils.METHOD_IDX, "AddTransition", _m_AddTransition);
			XUtils.RegisterFunc(L, XUtils.METHOD_IDX, "React", _m_React);
			XUtils.RegisterFunc(L, XUtils.METHOD_IDX, "SetEnterFunction", _m_SetEnterFunction);
			XUtils.RegisterFunc(L, XUtils.METHOD_IDX, "SetUpdateFunction", _m_SetUpdateFunction);
			XUtils.RegisterFunc(L, XUtils.METHOD_IDX, "SetExitFunction", _m_SetExitFunction);
			XUtils.RegisterFunc(L, XUtils.METHOD_IDX, "Enter", _m_Enter);
			XUtils.RegisterFunc(L, XUtils.METHOD_IDX, "Exit", _m_Exit);
			XUtils.RegisterFunc(L, XUtils.METHOD_IDX, "Update", _m_Update);
			XUtils.RegisterFunc(L, XUtils.METHOD_IDX, "Release", _m_Release);
			XUtils.RegisterFunc(L, XUtils.METHOD_IDX, "Destroy", _m_Destroy);
			
			
			XUtils.RegisterFunc(L, XUtils.GETTER_IDX, "Name", _g_get_Name);
            
			
			XUtils.EndObjectRegister(typeof(xc.Machine.State), L, translator, null, null,
			    null, null, null);

		    XUtils.BeginClassRegister(typeof(xc.Machine.State), L, __CreateInstance, 1, 0, 0);
			
			
            
            XUtils.RegisterObject(L, translator, XUtils.CLS_IDX, "UnderlyingSystemType", typeof(xc.Machine.State));
			
			
			XUtils.EndClassRegister(typeof(xc.Machine.State), L, translator);
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int __CreateInstance(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			try {
				if(LuaAPI.lua_gettop(L) == 3 && LuaTypes.LUA_TNUMBER == LuaAPI.lua_type(L, 2) && translator.Assignable<xc.Machine>(L, 3))
				{
					uint id = LuaAPI.xlua_touint(L, 2);
					xc.Machine machine = (xc.Machine)translator.GetObject(L, 3, typeof(xc.Machine));
					
					xc.Machine.State __cl_gen_ret = new xc.Machine.State(id, machine);
					translator.Push(L, __cl_gen_ret);
					return 1;
				}
				if(LuaAPI.lua_gettop(L) == 4 && LuaTypes.LUA_TNUMBER == LuaAPI.lua_type(L, 2) && translator.Assignable<xc.Machine>(L, 3) && translator.Assignable<xc.Machine.State>(L, 4))
				{
					uint id = LuaAPI.xlua_touint(L, 2);
					xc.Machine machine = (xc.Machine)translator.GetObject(L, 3, typeof(xc.Machine));
					xc.Machine.State owner = (xc.Machine.State)translator.GetObject(L, 4, typeof(xc.Machine.State));
					
					xc.Machine.State __cl_gen_ret = new xc.Machine.State(id, machine, owner);
					translator.Push(L, __cl_gen_ret);
					return 1;
				}
				
			}
			catch(System.Exception __gen_e) {
				return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
			}
            return LuaAPI.luaL_error(L, "invalid arguments to xc.Machine.State constructor!");
            
        }
        
		
        
		
        
        
        
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_Reset(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            xc.Machine.State __cl_gen_to_be_invoked = (xc.Machine.State)translator.FastGetCSObj(L, 1);
            
            
            try {
                
                {
                    uint id = LuaAPI.xlua_touint(L, 2);
                    xc.Machine machine = (xc.Machine)translator.GetObject(L, 3, typeof(xc.Machine));
                    xc.Machine.State owner = (xc.Machine.State)translator.GetObject(L, 4, typeof(xc.Machine.State));
                    
                    __cl_gen_to_be_invoked.Reset( id, machine, owner );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_GetID(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            xc.Machine.State __cl_gen_to_be_invoked = (xc.Machine.State)translator.FastGetCSObj(L, 1);
            
            
            try {
                
                {
                    
                        uint __cl_gen_ret = __cl_gen_to_be_invoked.GetID(  );
                        LuaAPI.xlua_pushuint(L, __cl_gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_GetOwner(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            xc.Machine.State __cl_gen_to_be_invoked = (xc.Machine.State)translator.FastGetCSObj(L, 1);
            
            
            try {
                
                {
                    
                        xc.Machine.State __cl_gen_ret = __cl_gen_to_be_invoked.GetOwner(  );
                        translator.Push(L, __cl_gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_GetChild(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            xc.Machine.State __cl_gen_to_be_invoked = (xc.Machine.State)translator.FastGetCSObj(L, 1);
            
            
            try {
                
                {
                    
                        xc.Machine.State __cl_gen_ret = __cl_gen_to_be_invoked.GetChild(  );
                        translator.Push(L, __cl_gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_GetParent(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            xc.Machine.State __cl_gen_to_be_invoked = (xc.Machine.State)translator.FastGetCSObj(L, 1);
            
            
            try {
                
                {
                    
                        xc.Machine.State __cl_gen_ret = __cl_gen_to_be_invoked.GetParent(  );
                        translator.Push(L, __cl_gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_SetChild(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            xc.Machine.State __cl_gen_to_be_invoked = (xc.Machine.State)translator.FastGetCSObj(L, 1);
            
            
            try {
                
                {
                    xc.Machine.State s = (xc.Machine.State)translator.GetObject(L, 2, typeof(xc.Machine.State));
                    
                    __cl_gen_to_be_invoked.SetChild( s );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_AddTransition(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            xc.Machine.State __cl_gen_to_be_invoked = (xc.Machine.State)translator.FastGetCSObj(L, 1);
            
            
            try {
                
                {
                    uint e = LuaAPI.xlua_touint(L, 2);
                    xc.Machine.State s = (xc.Machine.State)translator.GetObject(L, 3, typeof(xc.Machine.State));
                    
                    __cl_gen_to_be_invoked.AddTransition( e, s );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_React(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            xc.Machine.State __cl_gen_to_be_invoked = (xc.Machine.State)translator.FastGetCSObj(L, 1);
            
            
            try {
                
                {
                    uint e = LuaAPI.xlua_touint(L, 2);
                    
                        xc.Machine.State __cl_gen_ret = __cl_gen_to_be_invoked.React( e );
                        translator.Push(L, __cl_gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_SetEnterFunction(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            xc.Machine.State __cl_gen_to_be_invoked = (xc.Machine.State)translator.FastGetCSObj(L, 1);
            
            
            try {
                
                {
                    xc.Machine.State.StateFunction func = translator.GetDelegate<xc.Machine.State.StateFunction>(L, 2);
                    
                    __cl_gen_to_be_invoked.SetEnterFunction( func );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_SetUpdateFunction(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            xc.Machine.State __cl_gen_to_be_invoked = (xc.Machine.State)translator.FastGetCSObj(L, 1);
            
            
            try {
                
                {
                    xc.Machine.State.StateFunction func = translator.GetDelegate<xc.Machine.State.StateFunction>(L, 2);
                    
                    __cl_gen_to_be_invoked.SetUpdateFunction( func );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_SetExitFunction(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            xc.Machine.State __cl_gen_to_be_invoked = (xc.Machine.State)translator.FastGetCSObj(L, 1);
            
            
            try {
                
                {
                    xc.Machine.State.StateFunction func = translator.GetDelegate<xc.Machine.State.StateFunction>(L, 2);
                    
                    __cl_gen_to_be_invoked.SetExitFunction( func );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_Enter(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            xc.Machine.State __cl_gen_to_be_invoked = (xc.Machine.State)translator.FastGetCSObj(L, 1);
            
            
            try {
                
                {
                    object[] param = translator.GetParams<object>(L, 2);
                    
                    __cl_gen_to_be_invoked.Enter( param );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_Exit(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            xc.Machine.State __cl_gen_to_be_invoked = (xc.Machine.State)translator.FastGetCSObj(L, 1);
            
            
            try {
                
                {
                    
                    __cl_gen_to_be_invoked.Exit(  );
                    
                    
                    
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
            
            
            xc.Machine.State __cl_gen_to_be_invoked = (xc.Machine.State)translator.FastGetCSObj(L, 1);
            
            
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
        static int _m_Release(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            xc.Machine.State __cl_gen_to_be_invoked = (xc.Machine.State)translator.FastGetCSObj(L, 1);
            
            
            try {
                
                {
                    
                    __cl_gen_to_be_invoked.Release(  );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_Destroy(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            xc.Machine.State __cl_gen_to_be_invoked = (xc.Machine.State)translator.FastGetCSObj(L, 1);
            
            
            try {
                
                {
                    
                    __cl_gen_to_be_invoked.Destroy(  );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        
        
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_Name(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.Machine.State __cl_gen_to_be_invoked = (xc.Machine.State)translator.FastGetCSObj(L, 1);
                LuaAPI.lua_pushstring(L, __cl_gen_to_be_invoked.Name);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        
        
		
		
		
		
    }
}
