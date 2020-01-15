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
    public class xcDBGuildDutyDBGuildDutyItemWrap
    {
        public static void __Register(RealStatePtr L)
        {
			ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			XUtils.BeginObjectRegister(typeof(xc.DBGuildDuty.DBGuildDutyItem), L, translator, 0, 1, 4, 4);
			
			XUtils.RegisterFunc(L, XUtils.METHOD_IDX, "HasLimit", _m_HasLimit);
			
			
			XUtils.RegisterFunc(L, XUtils.GETTER_IDX, "Id", _g_get_Id);
            XUtils.RegisterFunc(L, XUtils.GETTER_IDX, "num", _g_get_num);
            XUtils.RegisterFunc(L, XUtils.GETTER_IDX, "LimitTypeArray", _g_get_LimitTypeArray);
            XUtils.RegisterFunc(L, XUtils.GETTER_IDX, "Name", _g_get_Name);
            
			XUtils.RegisterFunc(L, XUtils.SETTER_IDX, "Id", _s_set_Id);
            XUtils.RegisterFunc(L, XUtils.SETTER_IDX, "num", _s_set_num);
            XUtils.RegisterFunc(L, XUtils.SETTER_IDX, "LimitTypeArray", _s_set_LimitTypeArray);
            XUtils.RegisterFunc(L, XUtils.SETTER_IDX, "Name", _s_set_Name);
            
			XUtils.EndObjectRegister(typeof(xc.DBGuildDuty.DBGuildDutyItem), L, translator, null, null,
			    null, null, null);

		    XUtils.BeginClassRegister(typeof(xc.DBGuildDuty.DBGuildDutyItem), L, __CreateInstance, 1, 0, 0);
			
			
            
            XUtils.RegisterObject(L, translator, XUtils.CLS_IDX, "UnderlyingSystemType", typeof(xc.DBGuildDuty.DBGuildDutyItem));
			
			
			XUtils.EndClassRegister(typeof(xc.DBGuildDuty.DBGuildDutyItem), L, translator);
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int __CreateInstance(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			try {
				if(LuaAPI.lua_gettop(L) == 1)
				{
					
					xc.DBGuildDuty.DBGuildDutyItem __cl_gen_ret = new xc.DBGuildDuty.DBGuildDutyItem();
					translator.Push(L, __cl_gen_ret);
					return 1;
				}
				
			}
			catch(System.Exception __gen_e) {
				return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
			}
            return LuaAPI.luaL_error(L, "invalid arguments to xc.DBGuildDuty.DBGuildDutyItem constructor!");
            
        }
        
		
        
		
        
        
        
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_HasLimit(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            xc.DBGuildDuty.DBGuildDutyItem __cl_gen_to_be_invoked = (xc.DBGuildDuty.DBGuildDutyItem)translator.FastGetCSObj(L, 1);
            
            
            try {
                
                {
                    uint guild_duty_limit = LuaAPI.xlua_touint(L, 2);
                    
                        bool __cl_gen_ret = __cl_gen_to_be_invoked.HasLimit( guild_duty_limit );
                        LuaAPI.lua_pushboolean(L, __cl_gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        
        
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_Id(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.DBGuildDuty.DBGuildDutyItem __cl_gen_to_be_invoked = (xc.DBGuildDuty.DBGuildDutyItem)translator.FastGetCSObj(L, 1);
                LuaAPI.xlua_pushuint(L, __cl_gen_to_be_invoked.Id);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_num(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.DBGuildDuty.DBGuildDutyItem __cl_gen_to_be_invoked = (xc.DBGuildDuty.DBGuildDutyItem)translator.FastGetCSObj(L, 1);
                LuaAPI.xlua_pushuint(L, __cl_gen_to_be_invoked.num);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_LimitTypeArray(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.DBGuildDuty.DBGuildDutyItem __cl_gen_to_be_invoked = (xc.DBGuildDuty.DBGuildDutyItem)translator.FastGetCSObj(L, 1);
                LuaAPI.xlua_pushuint(L, __cl_gen_to_be_invoked.LimitTypeArray);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_Name(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.DBGuildDuty.DBGuildDutyItem __cl_gen_to_be_invoked = (xc.DBGuildDuty.DBGuildDutyItem)translator.FastGetCSObj(L, 1);
                LuaAPI.lua_pushstring(L, __cl_gen_to_be_invoked.Name);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_Id(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.DBGuildDuty.DBGuildDutyItem __cl_gen_to_be_invoked = (xc.DBGuildDuty.DBGuildDutyItem)translator.FastGetCSObj(L, 1);
                __cl_gen_to_be_invoked.Id = LuaAPI.xlua_touint(L, 2);
            
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_num(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.DBGuildDuty.DBGuildDutyItem __cl_gen_to_be_invoked = (xc.DBGuildDuty.DBGuildDutyItem)translator.FastGetCSObj(L, 1);
                __cl_gen_to_be_invoked.num = LuaAPI.xlua_touint(L, 2);
            
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_LimitTypeArray(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.DBGuildDuty.DBGuildDutyItem __cl_gen_to_be_invoked = (xc.DBGuildDuty.DBGuildDutyItem)translator.FastGetCSObj(L, 1);
                __cl_gen_to_be_invoked.LimitTypeArray = LuaAPI.xlua_touint(L, 2);
            
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_Name(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.DBGuildDuty.DBGuildDutyItem __cl_gen_to_be_invoked = (xc.DBGuildDuty.DBGuildDutyItem)translator.FastGetCSObj(L, 1);
                __cl_gen_to_be_invoked.Name = LuaAPI.lua_tostring(L, 2);
            
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 0;
        }
        
		
		
		
		
    }
}
