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
    public class xcDBInstancePhaseInstancePhaseInfoWrap
    {
        public static void __Register(RealStatePtr L)
        {
			ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			XUtils.BeginObjectRegister(typeof(xc.DBInstancePhase.InstancePhaseInfo), L, translator, 0, 1, 12, 11);
			
			XUtils.RegisterFunc(L, XUtils.METHOD_IDX, "GetMarkStr", _m_GetMarkStr);
			
			
			XUtils.RegisterFunc(L, XUtils.GETTER_IDX, "TargetNum", _g_get_TargetNum);
            XUtils.RegisterFunc(L, XUtils.GETTER_IDX, "CsvId", _g_get_CsvId);
            XUtils.RegisterFunc(L, XUtils.GETTER_IDX, "Id", _g_get_Id);
            XUtils.RegisterFunc(L, XUtils.GETTER_IDX, "Phase", _g_get_Phase);
            XUtils.RegisterFunc(L, XUtils.GETTER_IDX, "Mark1", _g_get_Mark1);
            XUtils.RegisterFunc(L, XUtils.GETTER_IDX, "Mark2", _g_get_Mark2);
            XUtils.RegisterFunc(L, XUtils.GETTER_IDX, "Mark3", _g_get_Mark3);
            XUtils.RegisterFunc(L, XUtils.GETTER_IDX, "Mark4", _g_get_Mark4);
            XUtils.RegisterFunc(L, XUtils.GETTER_IDX, "Mark5", _g_get_Mark5);
            XUtils.RegisterFunc(L, XUtils.GETTER_IDX, "Desc", _g_get_Desc);
            XUtils.RegisterFunc(L, XUtils.GETTER_IDX, "Tips", _g_get_Tips);
            XUtils.RegisterFunc(L, XUtils.GETTER_IDX, "TargetStr", _g_get_TargetStr);
            
			XUtils.RegisterFunc(L, XUtils.SETTER_IDX, "CsvId", _s_set_CsvId);
            XUtils.RegisterFunc(L, XUtils.SETTER_IDX, "Id", _s_set_Id);
            XUtils.RegisterFunc(L, XUtils.SETTER_IDX, "Phase", _s_set_Phase);
            XUtils.RegisterFunc(L, XUtils.SETTER_IDX, "Mark1", _s_set_Mark1);
            XUtils.RegisterFunc(L, XUtils.SETTER_IDX, "Mark2", _s_set_Mark2);
            XUtils.RegisterFunc(L, XUtils.SETTER_IDX, "Mark3", _s_set_Mark3);
            XUtils.RegisterFunc(L, XUtils.SETTER_IDX, "Mark4", _s_set_Mark4);
            XUtils.RegisterFunc(L, XUtils.SETTER_IDX, "Mark5", _s_set_Mark5);
            XUtils.RegisterFunc(L, XUtils.SETTER_IDX, "Desc", _s_set_Desc);
            XUtils.RegisterFunc(L, XUtils.SETTER_IDX, "Tips", _s_set_Tips);
            XUtils.RegisterFunc(L, XUtils.SETTER_IDX, "TargetStr", _s_set_TargetStr);
            
			XUtils.EndObjectRegister(typeof(xc.DBInstancePhase.InstancePhaseInfo), L, translator, null, null,
			    null, null, null);

		    XUtils.BeginClassRegister(typeof(xc.DBInstancePhase.InstancePhaseInfo), L, __CreateInstance, 1, 0, 0);
			
			
            
            XUtils.RegisterObject(L, translator, XUtils.CLS_IDX, "UnderlyingSystemType", typeof(xc.DBInstancePhase.InstancePhaseInfo));
			
			
			XUtils.EndClassRegister(typeof(xc.DBInstancePhase.InstancePhaseInfo), L, translator);
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int __CreateInstance(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			try {
				if(LuaAPI.lua_gettop(L) == 1)
				{
					
					xc.DBInstancePhase.InstancePhaseInfo __cl_gen_ret = new xc.DBInstancePhase.InstancePhaseInfo();
					translator.Push(L, __cl_gen_ret);
					return 1;
				}
				
			}
			catch(System.Exception __gen_e) {
				return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
			}
            return LuaAPI.luaL_error(L, "invalid arguments to xc.DBInstancePhase.InstancePhaseInfo constructor!");
            
        }
        
		
        
		
        
        
        
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_GetMarkStr(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            xc.DBInstancePhase.InstancePhaseInfo __cl_gen_to_be_invoked = (xc.DBInstancePhase.InstancePhaseInfo)translator.FastGetCSObj(L, 1);
            
            
            try {
                
                {
                    uint mark = LuaAPI.xlua_touint(L, 2);
                    
                        string __cl_gen_ret = __cl_gen_to_be_invoked.GetMarkStr( mark );
                        LuaAPI.lua_pushstring(L, __cl_gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        
        
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_TargetNum(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.DBInstancePhase.InstancePhaseInfo __cl_gen_to_be_invoked = (xc.DBInstancePhase.InstancePhaseInfo)translator.FastGetCSObj(L, 1);
                LuaAPI.xlua_pushuint(L, __cl_gen_to_be_invoked.TargetNum);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_CsvId(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.DBInstancePhase.InstancePhaseInfo __cl_gen_to_be_invoked = (xc.DBInstancePhase.InstancePhaseInfo)translator.FastGetCSObj(L, 1);
                LuaAPI.lua_pushstring(L, __cl_gen_to_be_invoked.CsvId);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_Id(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.DBInstancePhase.InstancePhaseInfo __cl_gen_to_be_invoked = (xc.DBInstancePhase.InstancePhaseInfo)translator.FastGetCSObj(L, 1);
                LuaAPI.xlua_pushuint(L, __cl_gen_to_be_invoked.Id);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_Phase(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.DBInstancePhase.InstancePhaseInfo __cl_gen_to_be_invoked = (xc.DBInstancePhase.InstancePhaseInfo)translator.FastGetCSObj(L, 1);
                LuaAPI.xlua_pushuint(L, __cl_gen_to_be_invoked.Phase);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_Mark1(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.DBInstancePhase.InstancePhaseInfo __cl_gen_to_be_invoked = (xc.DBInstancePhase.InstancePhaseInfo)translator.FastGetCSObj(L, 1);
                LuaAPI.lua_pushstring(L, __cl_gen_to_be_invoked.Mark1);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_Mark2(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.DBInstancePhase.InstancePhaseInfo __cl_gen_to_be_invoked = (xc.DBInstancePhase.InstancePhaseInfo)translator.FastGetCSObj(L, 1);
                LuaAPI.lua_pushstring(L, __cl_gen_to_be_invoked.Mark2);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_Mark3(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.DBInstancePhase.InstancePhaseInfo __cl_gen_to_be_invoked = (xc.DBInstancePhase.InstancePhaseInfo)translator.FastGetCSObj(L, 1);
                LuaAPI.lua_pushstring(L, __cl_gen_to_be_invoked.Mark3);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_Mark4(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.DBInstancePhase.InstancePhaseInfo __cl_gen_to_be_invoked = (xc.DBInstancePhase.InstancePhaseInfo)translator.FastGetCSObj(L, 1);
                LuaAPI.lua_pushstring(L, __cl_gen_to_be_invoked.Mark4);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_Mark5(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.DBInstancePhase.InstancePhaseInfo __cl_gen_to_be_invoked = (xc.DBInstancePhase.InstancePhaseInfo)translator.FastGetCSObj(L, 1);
                LuaAPI.lua_pushstring(L, __cl_gen_to_be_invoked.Mark5);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_Desc(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.DBInstancePhase.InstancePhaseInfo __cl_gen_to_be_invoked = (xc.DBInstancePhase.InstancePhaseInfo)translator.FastGetCSObj(L, 1);
                LuaAPI.lua_pushstring(L, __cl_gen_to_be_invoked.Desc);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_Tips(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.DBInstancePhase.InstancePhaseInfo __cl_gen_to_be_invoked = (xc.DBInstancePhase.InstancePhaseInfo)translator.FastGetCSObj(L, 1);
                LuaAPI.lua_pushstring(L, __cl_gen_to_be_invoked.Tips);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_TargetStr(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.DBInstancePhase.InstancePhaseInfo __cl_gen_to_be_invoked = (xc.DBInstancePhase.InstancePhaseInfo)translator.FastGetCSObj(L, 1);
                LuaAPI.lua_pushstring(L, __cl_gen_to_be_invoked.TargetStr);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_CsvId(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.DBInstancePhase.InstancePhaseInfo __cl_gen_to_be_invoked = (xc.DBInstancePhase.InstancePhaseInfo)translator.FastGetCSObj(L, 1);
                __cl_gen_to_be_invoked.CsvId = LuaAPI.lua_tostring(L, 2);
            
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_Id(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.DBInstancePhase.InstancePhaseInfo __cl_gen_to_be_invoked = (xc.DBInstancePhase.InstancePhaseInfo)translator.FastGetCSObj(L, 1);
                __cl_gen_to_be_invoked.Id = LuaAPI.xlua_touint(L, 2);
            
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_Phase(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.DBInstancePhase.InstancePhaseInfo __cl_gen_to_be_invoked = (xc.DBInstancePhase.InstancePhaseInfo)translator.FastGetCSObj(L, 1);
                __cl_gen_to_be_invoked.Phase = LuaAPI.xlua_touint(L, 2);
            
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_Mark1(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.DBInstancePhase.InstancePhaseInfo __cl_gen_to_be_invoked = (xc.DBInstancePhase.InstancePhaseInfo)translator.FastGetCSObj(L, 1);
                __cl_gen_to_be_invoked.Mark1 = LuaAPI.lua_tostring(L, 2);
            
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_Mark2(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.DBInstancePhase.InstancePhaseInfo __cl_gen_to_be_invoked = (xc.DBInstancePhase.InstancePhaseInfo)translator.FastGetCSObj(L, 1);
                __cl_gen_to_be_invoked.Mark2 = LuaAPI.lua_tostring(L, 2);
            
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_Mark3(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.DBInstancePhase.InstancePhaseInfo __cl_gen_to_be_invoked = (xc.DBInstancePhase.InstancePhaseInfo)translator.FastGetCSObj(L, 1);
                __cl_gen_to_be_invoked.Mark3 = LuaAPI.lua_tostring(L, 2);
            
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_Mark4(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.DBInstancePhase.InstancePhaseInfo __cl_gen_to_be_invoked = (xc.DBInstancePhase.InstancePhaseInfo)translator.FastGetCSObj(L, 1);
                __cl_gen_to_be_invoked.Mark4 = LuaAPI.lua_tostring(L, 2);
            
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_Mark5(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.DBInstancePhase.InstancePhaseInfo __cl_gen_to_be_invoked = (xc.DBInstancePhase.InstancePhaseInfo)translator.FastGetCSObj(L, 1);
                __cl_gen_to_be_invoked.Mark5 = LuaAPI.lua_tostring(L, 2);
            
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_Desc(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.DBInstancePhase.InstancePhaseInfo __cl_gen_to_be_invoked = (xc.DBInstancePhase.InstancePhaseInfo)translator.FastGetCSObj(L, 1);
                __cl_gen_to_be_invoked.Desc = LuaAPI.lua_tostring(L, 2);
            
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_Tips(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.DBInstancePhase.InstancePhaseInfo __cl_gen_to_be_invoked = (xc.DBInstancePhase.InstancePhaseInfo)translator.FastGetCSObj(L, 1);
                __cl_gen_to_be_invoked.Tips = LuaAPI.lua_tostring(L, 2);
            
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_TargetStr(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.DBInstancePhase.InstancePhaseInfo __cl_gen_to_be_invoked = (xc.DBInstancePhase.InstancePhaseInfo)translator.FastGetCSObj(L, 1);
                __cl_gen_to_be_invoked.TargetStr = LuaAPI.lua_tostring(L, 2);
            
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 0;
        }
        
		
		
		
		
    }
}
