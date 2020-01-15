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
    public class xcDBInstancePhaseWrap
    {
        public static void __Register(RealStatePtr L)
        {
			ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			XUtils.BeginObjectRegister(typeof(xc.DBInstancePhase), L, translator, 0, 7, 0, 0);
			
			XUtils.RegisterFunc(L, XUtils.METHOD_IDX, "Unload", _m_Unload);
			XUtils.RegisterFunc(L, XUtils.METHOD_IDX, "Load", _m_Load);
			XUtils.RegisterFunc(L, XUtils.METHOD_IDX, "GetInstancePhaseInfo", _m_GetInstancePhaseInfo);
			XUtils.RegisterFunc(L, XUtils.METHOD_IDX, "GetInstancePhaseCount", _m_GetInstancePhaseCount);
			XUtils.RegisterFunc(L, XUtils.METHOD_IDX, "HavePhases", _m_HavePhases);
			XUtils.RegisterFunc(L, XUtils.METHOD_IDX, "PhasesCount", _m_PhasesCount);
			XUtils.RegisterFunc(L, XUtils.METHOD_IDX, "IsLastPhase", _m_IsLastPhase);
			
			
			
			
			XUtils.EndObjectRegister(typeof(xc.DBInstancePhase), L, translator, null, null,
			    null, null, null);

		    XUtils.BeginClassRegister(typeof(xc.DBInstancePhase), L, __CreateInstance, 1, 0, 0);
			
			
            
            XUtils.RegisterObject(L, translator, XUtils.CLS_IDX, "UnderlyingSystemType", typeof(xc.DBInstancePhase));
			
			
			XUtils.EndClassRegister(typeof(xc.DBInstancePhase), L, translator);
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int __CreateInstance(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			try {
				if(LuaAPI.lua_gettop(L) == 3 && (LuaAPI.lua_isnil(L, 2) || LuaAPI.lua_type(L, 2) == LuaTypes.LUA_TSTRING) && (LuaAPI.lua_isnil(L, 3) || LuaAPI.lua_type(L, 3) == LuaTypes.LUA_TSTRING))
				{
					string strName = LuaAPI.lua_tostring(L, 2);
					string strPath = LuaAPI.lua_tostring(L, 3);
					
					xc.DBInstancePhase __cl_gen_ret = new xc.DBInstancePhase(strName, strPath);
					translator.Push(L, __cl_gen_ret);
					return 1;
				}
				
			}
			catch(System.Exception __gen_e) {
				return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
			}
            return LuaAPI.luaL_error(L, "invalid arguments to xc.DBInstancePhase constructor!");
            
        }
        
		
        
		
        
        
        
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_Unload(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            xc.DBInstancePhase __cl_gen_to_be_invoked = (xc.DBInstancePhase)translator.FastGetCSObj(L, 1);
            
            
            try {
                
                {
                    
                    __cl_gen_to_be_invoked.Unload(  );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_Load(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            xc.DBInstancePhase __cl_gen_to_be_invoked = (xc.DBInstancePhase)translator.FastGetCSObj(L, 1);
            
            
            try {
                
                {
                    
                    __cl_gen_to_be_invoked.Load(  );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_GetInstancePhaseInfo(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            xc.DBInstancePhase __cl_gen_to_be_invoked = (xc.DBInstancePhase)translator.FastGetCSObj(L, 1);
            
            
            try {
                
                {
                    uint instanceId = LuaAPI.xlua_touint(L, 2);
                    uint phase = LuaAPI.xlua_touint(L, 3);
                    
                        xc.DBInstancePhase.InstancePhaseInfo __cl_gen_ret = __cl_gen_to_be_invoked.GetInstancePhaseInfo( instanceId, phase );
                        translator.Push(L, __cl_gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_GetInstancePhaseCount(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            xc.DBInstancePhase __cl_gen_to_be_invoked = (xc.DBInstancePhase)translator.FastGetCSObj(L, 1);
            
            
            try {
                
                {
                    uint instanceId = LuaAPI.xlua_touint(L, 2);
                    
                        uint __cl_gen_ret = __cl_gen_to_be_invoked.GetInstancePhaseCount( instanceId );
                        LuaAPI.xlua_pushuint(L, __cl_gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_HavePhases(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            xc.DBInstancePhase __cl_gen_to_be_invoked = (xc.DBInstancePhase)translator.FastGetCSObj(L, 1);
            
            
            try {
                
                {
                    uint instanceId = LuaAPI.xlua_touint(L, 2);
                    
                        bool __cl_gen_ret = __cl_gen_to_be_invoked.HavePhases( instanceId );
                        LuaAPI.lua_pushboolean(L, __cl_gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_PhasesCount(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            xc.DBInstancePhase __cl_gen_to_be_invoked = (xc.DBInstancePhase)translator.FastGetCSObj(L, 1);
            
            
            try {
                
                {
                    uint instanceId = LuaAPI.xlua_touint(L, 2);
                    
                        uint __cl_gen_ret = __cl_gen_to_be_invoked.PhasesCount( instanceId );
                        LuaAPI.xlua_pushuint(L, __cl_gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_IsLastPhase(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            xc.DBInstancePhase __cl_gen_to_be_invoked = (xc.DBInstancePhase)translator.FastGetCSObj(L, 1);
            
            
            try {
                
                {
                    uint instanceId = LuaAPI.xlua_touint(L, 2);
                    uint phase = LuaAPI.xlua_touint(L, 3);
                    
                        bool __cl_gen_ret = __cl_gen_to_be_invoked.IsLastPhase( instanceId, phase );
                        LuaAPI.lua_pushboolean(L, __cl_gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        
        
        
        
        
		
		
		
		
    }
}
