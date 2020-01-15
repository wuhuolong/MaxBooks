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
    public class xcUnitIDWrap
    {
        public static void __Register(RealStatePtr L)
        {
			ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			XUtils.BeginObjectRegister(typeof(xc.UnitID), L, translator, 1, 4, 2, 2);
			XUtils.RegisterFunc(L, XUtils.OBJ_META_IDX, "__eq", __EqMeta);
            
			XUtils.RegisterFunc(L, XUtils.METHOD_IDX, "Equals", _m_Equals);
			XUtils.RegisterFunc(L, XUtils.METHOD_IDX, "GetHashCode", _m_GetHashCode);
			XUtils.RegisterFunc(L, XUtils.METHOD_IDX, "Copy", _m_Copy);
			XUtils.RegisterFunc(L, XUtils.METHOD_IDX, "ToString", _m_ToString);
			
			
			XUtils.RegisterFunc(L, XUtils.GETTER_IDX, "type", _g_get_type);
            XUtils.RegisterFunc(L, XUtils.GETTER_IDX, "obj_idx", _g_get_obj_idx);
            
			XUtils.RegisterFunc(L, XUtils.SETTER_IDX, "type", _s_set_type);
            XUtils.RegisterFunc(L, XUtils.SETTER_IDX, "obj_idx", _s_set_obj_idx);
            
			XUtils.EndObjectRegister(typeof(xc.UnitID), L, translator, null, null,
			    null, null, null);

		    XUtils.BeginClassRegister(typeof(xc.UnitID), L, __CreateInstance, 1, 0, 0);
			
			
            
            XUtils.RegisterObject(L, translator, XUtils.CLS_IDX, "UnderlyingSystemType", typeof(xc.UnitID));
			
			
			XUtils.EndClassRegister(typeof(xc.UnitID), L, translator);
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int __CreateInstance(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			try {
				if(LuaAPI.lua_gettop(L) == 1)
				{
					
					xc.UnitID __cl_gen_ret = new xc.UnitID();
					translator.Push(L, __cl_gen_ret);
					return 1;
				}
				if(LuaAPI.lua_gettop(L) == 3 && LuaTypes.LUA_TNUMBER == LuaAPI.lua_type(L, 2) && LuaTypes.LUA_TNUMBER == LuaAPI.lua_type(L, 3))
				{
					byte t = (byte)LuaAPI.lua_tonumber(L, 2);
					uint idx = LuaAPI.xlua_touint(L, 3);
					
					xc.UnitID __cl_gen_ret = new xc.UnitID(t, idx);
					translator.Push(L, __cl_gen_ret);
					return 1;
				}
				
			}
			catch(System.Exception __gen_e) {
				return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
			}
            return LuaAPI.luaL_error(L, "invalid arguments to xc.UnitID constructor!");
            
        }
        
		
        
		
        
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int __EqMeta(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
			try {
				if (translator.Assignable<xc.UnitID>(L, 1) && translator.Assignable<xc.UnitID>(L, 2))
				{
					xc.UnitID leftside = (xc.UnitID)translator.GetObject(L, 1, typeof(xc.UnitID));
					xc.UnitID rightside = (xc.UnitID)translator.GetObject(L, 2, typeof(xc.UnitID));
					
					LuaAPI.lua_pushboolean(L, leftside == rightside);
					
					return 1;
				}
			}
			catch(System.Exception __gen_e) {
				return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
			}
            
            return LuaAPI.luaL_error(L, "invalid arguments to right hand of == operator, need xc.UnitID!");
            
        }
        
        
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_Equals(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            xc.UnitID __cl_gen_to_be_invoked = (xc.UnitID)translator.FastGetCSObj(L, 1);
            
            
			int __gen_param_count = LuaAPI.lua_gettop(L);
            
            try {
                if(__gen_param_count == 2&& translator.Assignable<object>(L, 2)) 
                {
                    object obj = translator.GetObject(L, 2, typeof(object));
                    
                        bool __cl_gen_ret = __cl_gen_to_be_invoked.Equals( obj );
                        LuaAPI.lua_pushboolean(L, __cl_gen_ret);
                    
                    
                    
                    return 1;
                }
                if(__gen_param_count == 2&& translator.Assignable<xc.UnitID>(L, 2)) 
                {
                    xc.UnitID a = (xc.UnitID)translator.GetObject(L, 2, typeof(xc.UnitID));
                    
                        bool __cl_gen_ret = __cl_gen_to_be_invoked.Equals( a );
                        LuaAPI.lua_pushboolean(L, __cl_gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
            return LuaAPI.luaL_error(L, "invalid arguments to xc.UnitID.Equals!");
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_GetHashCode(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            xc.UnitID __cl_gen_to_be_invoked = (xc.UnitID)translator.FastGetCSObj(L, 1);
            
            
            try {
                
                {
                    
                        int __cl_gen_ret = __cl_gen_to_be_invoked.GetHashCode(  );
                        LuaAPI.xlua_pushinteger(L, __cl_gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_Copy(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            xc.UnitID __cl_gen_to_be_invoked = (xc.UnitID)translator.FastGetCSObj(L, 1);
            
            
            try {
                
                {
                    
                        xc.UnitID __cl_gen_ret = __cl_gen_to_be_invoked.Copy(  );
                        translator.Push(L, __cl_gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_ToString(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            xc.UnitID __cl_gen_to_be_invoked = (xc.UnitID)translator.FastGetCSObj(L, 1);
            
            
            try {
                
                {
                    
                        string __cl_gen_ret = __cl_gen_to_be_invoked.ToString(  );
                        LuaAPI.lua_pushstring(L, __cl_gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        
        
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_type(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.UnitID __cl_gen_to_be_invoked = (xc.UnitID)translator.FastGetCSObj(L, 1);
                LuaAPI.xlua_pushinteger(L, __cl_gen_to_be_invoked.type);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_obj_idx(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.UnitID __cl_gen_to_be_invoked = (xc.UnitID)translator.FastGetCSObj(L, 1);
                LuaAPI.xlua_pushuint(L, __cl_gen_to_be_invoked.obj_idx);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_type(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.UnitID __cl_gen_to_be_invoked = (xc.UnitID)translator.FastGetCSObj(L, 1);
                __cl_gen_to_be_invoked.type = (byte)LuaAPI.lua_tonumber(L, 2);
            
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_obj_idx(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.UnitID __cl_gen_to_be_invoked = (xc.UnitID)translator.FastGetCSObj(L, 1);
                __cl_gen_to_be_invoked.obj_idx = LuaAPI.xlua_touint(L, 2);
            
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 0;
        }
        
		
		
		
		
    }
}
