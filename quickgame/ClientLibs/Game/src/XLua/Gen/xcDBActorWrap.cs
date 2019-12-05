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
    public class xcDBActorWrap
    {
        public static void __Register(RealStatePtr L)
        {
			ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			XUtils.BeginObjectRegister(typeof(xc.DBActor), L, translator, 0, 4, 0, 0);
			
			XUtils.RegisterFunc(L, XUtils.METHOD_IDX, "GetData", _m_GetData);
			XUtils.RegisterFunc(L, XUtils.METHOD_IDX, "ContainsKey", _m_ContainsKey);
			XUtils.RegisterFunc(L, XUtils.METHOD_IDX, "Load", _m_Load);
			XUtils.RegisterFunc(L, XUtils.METHOD_IDX, "Unload", _m_Unload);
			
			
			
			
			XUtils.EndObjectRegister(typeof(xc.DBActor), L, translator, null, null,
			    null, null, null);

		    XUtils.BeginClassRegister(typeof(xc.DBActor), L, __CreateInstance, 14, 6, 6);
			
			
            XUtils.RegisterObject(L, translator, XUtils.CLS_IDX, "ANGLE_TO_RADIAN", xc.DBActor.ANGLE_TO_RADIAN);
            XUtils.RegisterObject(L, translator, XUtils.CLS_IDX, "RADIAN_TO_ANGLE", xc.DBActor.RADIAN_TO_ANGLE);
            XUtils.RegisterObject(L, translator, XUtils.CLS_IDX, "UF_NONE", xc.DBActor.UF_NONE);
            XUtils.RegisterObject(L, translator, XUtils.CLS_IDX, "UF_ALL", xc.DBActor.UF_ALL);
            XUtils.RegisterObject(L, translator, XUtils.CLS_IDX, "UF_ACTION", xc.DBActor.UF_ACTION);
            XUtils.RegisterObject(L, translator, XUtils.CLS_IDX, "UF_ANIMATION", xc.DBActor.UF_ANIMATION);
            XUtils.RegisterObject(L, translator, XUtils.CLS_IDX, "UF_MOVE", xc.DBActor.UF_MOVE);
            XUtils.RegisterObject(L, translator, XUtils.CLS_IDX, "UF_ATTACK", xc.DBActor.UF_ATTACK);
            XUtils.RegisterObject(L, translator, XUtils.CLS_IDX, "UF_BEATTACK", xc.DBActor.UF_BEATTACK);
            XUtils.RegisterObject(L, translator, XUtils.CLS_IDX, "UF_SKILL", xc.DBActor.UF_SKILL);
            XUtils.RegisterObject(L, translator, XUtils.CLS_IDX, "UF_AI", xc.DBActor.UF_AI);
            XUtils.RegisterObject(L, translator, XUtils.CLS_IDX, "UF_BUFF", xc.DBActor.UF_BUFF);
            XUtils.RegisterObject(L, translator, XUtils.CLS_IDX, "UF_BATTLESTATE", xc.DBActor.UF_BATTLESTATE);
            
            XUtils.RegisterObject(L, translator, XUtils.CLS_IDX, "UnderlyingSystemType", typeof(xc.DBActor));
			XUtils.RegisterFunc(L, XUtils.CLS_GETTER_IDX, "SpeedUpMinDis", _g_get_SpeedUpMinDis);
            XUtils.RegisterFunc(L, XUtils.CLS_GETTER_IDX, "SpeedUpMaxDis", _g_get_SpeedUpMaxDis);
            XUtils.RegisterFunc(L, XUtils.CLS_GETTER_IDX, "Gravity", _g_get_Gravity);
            XUtils.RegisterFunc(L, XUtils.CLS_GETTER_IDX, "MinimumAngle", _g_get_MinimumAngle);
            XUtils.RegisterFunc(L, XUtils.CLS_GETTER_IDX, "MinimumDistance", _g_get_MinimumDistance);
            XUtils.RegisterFunc(L, XUtils.CLS_GETTER_IDX, "MinDisToGround", _g_get_MinDisToGround);
            
			XUtils.RegisterFunc(L, XUtils.CLS_SETTER_IDX, "SpeedUpMinDis", _s_set_SpeedUpMinDis);
            XUtils.RegisterFunc(L, XUtils.CLS_SETTER_IDX, "SpeedUpMaxDis", _s_set_SpeedUpMaxDis);
            XUtils.RegisterFunc(L, XUtils.CLS_SETTER_IDX, "Gravity", _s_set_Gravity);
            XUtils.RegisterFunc(L, XUtils.CLS_SETTER_IDX, "MinimumAngle", _s_set_MinimumAngle);
            XUtils.RegisterFunc(L, XUtils.CLS_SETTER_IDX, "MinimumDistance", _s_set_MinimumDistance);
            XUtils.RegisterFunc(L, XUtils.CLS_SETTER_IDX, "MinDisToGround", _s_set_MinDisToGround);
            
			XUtils.EndClassRegister(typeof(xc.DBActor), L, translator);
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
					
					xc.DBActor __cl_gen_ret = new xc.DBActor(strName, strPath);
					translator.Push(L, __cl_gen_ret);
					return 1;
				}
				
			}
			catch(System.Exception __gen_e) {
				return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
			}
            return LuaAPI.luaL_error(L, "invalid arguments to xc.DBActor constructor!");
            
        }
        
		
        
		
        
        
        
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_GetData(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            xc.DBActor __cl_gen_to_be_invoked = (xc.DBActor)translator.FastGetCSObj(L, 1);
            
            
			int __gen_param_count = LuaAPI.lua_gettop(L);
            
            try {
                if(__gen_param_count == 2&& LuaTypes.LUA_TNUMBER == LuaAPI.lua_type(L, 2)) 
                {
                    uint id = LuaAPI.xlua_touint(L, 2);
                    
                        xc.DBActor.ActorData __cl_gen_ret = __cl_gen_to_be_invoked.GetData( id );
                        translator.Push(L, __cl_gen_ret);
                    
                    
                    
                    return 1;
                }
                if(__gen_param_count == 2&& (LuaAPI.lua_isnil(L, 2) || LuaAPI.lua_type(L, 2) == LuaTypes.LUA_TSTRING)) 
                {
                    string id = LuaAPI.lua_tostring(L, 2);
                    
                        xc.DBActor.ActorData __cl_gen_ret = __cl_gen_to_be_invoked.GetData( id );
                        translator.Push(L, __cl_gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
            return LuaAPI.luaL_error(L, "invalid arguments to xc.DBActor.GetData!");
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_ContainsKey(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            xc.DBActor __cl_gen_to_be_invoked = (xc.DBActor)translator.FastGetCSObj(L, 1);
            
            
            try {
                
                {
                    uint id = LuaAPI.xlua_touint(L, 2);
                    
                        bool __cl_gen_ret = __cl_gen_to_be_invoked.ContainsKey( id );
                        LuaAPI.lua_pushboolean(L, __cl_gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_Load(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            xc.DBActor __cl_gen_to_be_invoked = (xc.DBActor)translator.FastGetCSObj(L, 1);
            
            
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
        static int _m_Unload(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            xc.DBActor __cl_gen_to_be_invoked = (xc.DBActor)translator.FastGetCSObj(L, 1);
            
            
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
        static int _g_get_SpeedUpMinDis(RealStatePtr L)
        {
            
            try {
			    LuaAPI.lua_pushnumber(L, xc.DBActor.SpeedUpMinDis);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_SpeedUpMaxDis(RealStatePtr L)
        {
            
            try {
			    LuaAPI.lua_pushnumber(L, xc.DBActor.SpeedUpMaxDis);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_Gravity(RealStatePtr L)
        {
            
            try {
			    LuaAPI.xlua_pushinteger(L, xc.DBActor.Gravity);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_MinimumAngle(RealStatePtr L)
        {
            
            try {
			    LuaAPI.lua_pushnumber(L, xc.DBActor.MinimumAngle);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_MinimumDistance(RealStatePtr L)
        {
            
            try {
			    LuaAPI.lua_pushnumber(L, xc.DBActor.MinimumDistance);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_MinDisToGround(RealStatePtr L)
        {
            
            try {
			    LuaAPI.lua_pushnumber(L, xc.DBActor.MinDisToGround);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_SpeedUpMinDis(RealStatePtr L)
        {
            
            try {
			    xc.DBActor.SpeedUpMinDis = (float)LuaAPI.lua_tonumber(L, 1);
            
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_SpeedUpMaxDis(RealStatePtr L)
        {
            
            try {
			    xc.DBActor.SpeedUpMaxDis = (float)LuaAPI.lua_tonumber(L, 1);
            
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_Gravity(RealStatePtr L)
        {
            
            try {
			    xc.DBActor.Gravity = (ushort)LuaAPI.xlua_tointeger(L, 1);
            
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_MinimumAngle(RealStatePtr L)
        {
            
            try {
			    xc.DBActor.MinimumAngle = (float)LuaAPI.lua_tonumber(L, 1);
            
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_MinimumDistance(RealStatePtr L)
        {
            
            try {
			    xc.DBActor.MinimumDistance = (float)LuaAPI.lua_tonumber(L, 1);
            
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_MinDisToGround(RealStatePtr L)
        {
            
            try {
			    xc.DBActor.MinDisToGround = (float)LuaAPI.lua_tonumber(L, 1);
            
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 0;
        }
        
		
		
		
		
    }
}
