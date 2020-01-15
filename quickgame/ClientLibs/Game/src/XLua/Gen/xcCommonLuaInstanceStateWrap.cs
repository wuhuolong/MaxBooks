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
    public class xcCommonLuaInstanceStateWrap
    {
        public static void __Register(RealStatePtr L)
        {
			ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			XUtils.BeginObjectRegister(typeof(xc.CommonLuaInstanceState), L, translator, 0, 5, 3, 0);
			
			XUtils.RegisterFunc(L, XUtils.METHOD_IDX, "AddComponent", _m_AddComponent);
			XUtils.RegisterFunc(L, XUtils.METHOD_IDX, "Update", _m_Update);
			XUtils.RegisterFunc(L, XUtils.METHOD_IDX, "Enter", _m_Enter);
			XUtils.RegisterFunc(L, XUtils.METHOD_IDX, "Exit", _m_Exit);
			XUtils.RegisterFunc(L, XUtils.METHOD_IDX, "StateEnter_InPlay", _m_StateEnter_InPlay);
			
			
			XUtils.RegisterFunc(L, XUtils.GETTER_IDX, "Name", _g_get_Name);
            XUtils.RegisterFunc(L, XUtils.GETTER_IDX, "DataBossBehaviour", _g_get_DataBossBehaviour);
            XUtils.RegisterFunc(L, XUtils.GETTER_IDX, "LuaScript", _g_get_LuaScript);
            
			
			XUtils.EndObjectRegister(typeof(xc.CommonLuaInstanceState), L, translator, null, null,
			    null, null, null);

		    XUtils.BeginClassRegister(typeof(xc.CommonLuaInstanceState), L, __CreateInstance, 1, 0, 0);
			
			
            
            XUtils.RegisterObject(L, translator, XUtils.CLS_IDX, "UnderlyingSystemType", typeof(xc.CommonLuaInstanceState));
			
			
			XUtils.EndClassRegister(typeof(xc.CommonLuaInstanceState), L, translator);
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int __CreateInstance(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			try {
				if(LuaAPI.lua_gettop(L) == 4 && (LuaAPI.lua_isnil(L, 2) || LuaAPI.lua_type(L, 2) == LuaTypes.LUA_TSTRING) && LuaTypes.LUA_TNUMBER == LuaAPI.lua_type(L, 3) && translator.Assignable<xc.Machine>(L, 4))
				{
					string lua_script = LuaAPI.lua_tostring(L, 2);
					uint id = LuaAPI.xlua_touint(L, 3);
					xc.Machine machine = (xc.Machine)translator.GetObject(L, 4, typeof(xc.Machine));
					
					xc.CommonLuaInstanceState __cl_gen_ret = new xc.CommonLuaInstanceState(lua_script, id, machine);
					translator.Push(L, __cl_gen_ret);
					return 1;
				}
				if(LuaAPI.lua_gettop(L) == 5 && (LuaAPI.lua_isnil(L, 2) || LuaAPI.lua_type(L, 2) == LuaTypes.LUA_TSTRING) && LuaTypes.LUA_TNUMBER == LuaAPI.lua_type(L, 3) && translator.Assignable<xc.Machine>(L, 4) && translator.Assignable<xc.Machine.State>(L, 5))
				{
					string lua_script = LuaAPI.lua_tostring(L, 2);
					uint id = LuaAPI.xlua_touint(L, 3);
					xc.Machine machine = (xc.Machine)translator.GetObject(L, 4, typeof(xc.Machine));
					xc.Machine.State owner = (xc.Machine.State)translator.GetObject(L, 5, typeof(xc.Machine.State));
					
					xc.CommonLuaInstanceState __cl_gen_ret = new xc.CommonLuaInstanceState(lua_script, id, machine, owner);
					translator.Push(L, __cl_gen_ret);
					return 1;
				}
				
			}
			catch(System.Exception __gen_e) {
				return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
			}
            return LuaAPI.luaL_error(L, "invalid arguments to xc.CommonLuaInstanceState constructor!");
            
        }
        
		
        
		
        
        
        
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_AddComponent(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            xc.CommonLuaInstanceState __cl_gen_to_be_invoked = (xc.CommonLuaInstanceState)translator.FastGetCSObj(L, 1);
            
            
            try {
                
                {
                    string component_name = LuaAPI.lua_tostring(L, 2);
                    
                        xc.instance_behaviour.Behaviour __cl_gen_ret = __cl_gen_to_be_invoked.AddComponent( component_name );
                        translator.Push(L, __cl_gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_Update(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            xc.CommonLuaInstanceState __cl_gen_to_be_invoked = (xc.CommonLuaInstanceState)translator.FastGetCSObj(L, 1);
            
            
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
        static int _m_Enter(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            xc.CommonLuaInstanceState __cl_gen_to_be_invoked = (xc.CommonLuaInstanceState)translator.FastGetCSObj(L, 1);
            
            
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
            
            
            xc.CommonLuaInstanceState __cl_gen_to_be_invoked = (xc.CommonLuaInstanceState)translator.FastGetCSObj(L, 1);
            
            
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
        static int _m_StateEnter_InPlay(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            xc.CommonLuaInstanceState __cl_gen_to_be_invoked = (xc.CommonLuaInstanceState)translator.FastGetCSObj(L, 1);
            
            
            try {
                
                {
                    xc.Machine.State s = (xc.Machine.State)translator.GetObject(L, 2, typeof(xc.Machine.State));
                    
                    __cl_gen_to_be_invoked.StateEnter_InPlay( s );
                    
                    
                    
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
			
                xc.CommonLuaInstanceState __cl_gen_to_be_invoked = (xc.CommonLuaInstanceState)translator.FastGetCSObj(L, 1);
                LuaAPI.lua_pushstring(L, __cl_gen_to_be_invoked.Name);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_DataBossBehaviour(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.CommonLuaInstanceState __cl_gen_to_be_invoked = (xc.CommonLuaInstanceState)translator.FastGetCSObj(L, 1);
                translator.Push(L, __cl_gen_to_be_invoked.DataBossBehaviour);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_LuaScript(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.CommonLuaInstanceState __cl_gen_to_be_invoked = (xc.CommonLuaInstanceState)translator.FastGetCSObj(L, 1);
                LuaAPI.lua_pushstring(L, __cl_gen_to_be_invoked.LuaScript);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        
        
		
		
		
		
    }
}
