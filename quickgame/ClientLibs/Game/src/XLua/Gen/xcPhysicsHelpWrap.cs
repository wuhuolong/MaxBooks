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
    public class xcPhysicsHelpWrap
    {
        public static void __Register(RealStatePtr L)
        {
			ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			XUtils.BeginObjectRegister(typeof(xc.PhysicsHelp), L, translator, 0, 0, 0, 0);
			
			
			
			
			
			XUtils.EndObjectRegister(typeof(xc.PhysicsHelp), L, translator, null, null,
			    null, null, null);

		    XUtils.BeginClassRegister(typeof(xc.PhysicsHelp), L, __CreateInstance, 5, 0, 0);
			XUtils.RegisterFunc(L, XUtils.CLS_IDX, "GetHeight", _m_GetHeight_xlua_st_);
            XUtils.RegisterFunc(L, XUtils.CLS_IDX, "GetPosition", _m_GetPosition_xlua_st_);
            XUtils.RegisterFunc(L, XUtils.CLS_IDX, "BoundaryHitPos", _m_BoundaryHitPos_xlua_st_);
            
			
            XUtils.RegisterObject(L, translator, XUtils.CLS_IDX, "ILLEGAL_HEIGHT", xc.PhysicsHelp.ILLEGAL_HEIGHT);
            
            XUtils.RegisterObject(L, translator, XUtils.CLS_IDX, "UnderlyingSystemType", typeof(xc.PhysicsHelp));
			
			
			XUtils.EndClassRegister(typeof(xc.PhysicsHelp), L, translator);
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int __CreateInstance(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			try {
				if(LuaAPI.lua_gettop(L) == 1)
				{
					
					xc.PhysicsHelp __cl_gen_ret = new xc.PhysicsHelp();
					translator.Push(L, __cl_gen_ret);
					return 1;
				}
				
			}
			catch(System.Exception __gen_e) {
				return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
			}
            return LuaAPI.luaL_error(L, "invalid arguments to xc.PhysicsHelp constructor!");
            
        }
        
		
        
		
        
        
        
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_GetHeight_xlua_st_(RealStatePtr L)
        {
            
            
            
            try {
                
                {
                    float x = (float)LuaAPI.lua_tonumber(L, 1);
                    float z = (float)LuaAPI.lua_tonumber(L, 2);
                    
                        float __cl_gen_ret = xc.PhysicsHelp.GetHeight( x, z );
                        LuaAPI.lua_pushnumber(L, __cl_gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_GetPosition_xlua_st_(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            
            try {
                
                {
                    float x = (float)LuaAPI.lua_tonumber(L, 1);
                    float z = (float)LuaAPI.lua_tonumber(L, 2);
                    
                        UnityEngine.Vector3 __cl_gen_ret = xc.PhysicsHelp.GetPosition( x, z );
                        translator.PushUnityEngineVector3(L, __cl_gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_BoundaryHitPos_xlua_st_(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            
            try {
                
                {
                    UnityEngine.Vector3 src_pos;translator.Get(L, 1, out src_pos);
                    UnityEngine.Vector3 hit_pos;translator.Get(L, 2, out hit_pos);
                    
                        UnityEngine.Vector3 __cl_gen_ret = xc.PhysicsHelp.BoundaryHitPos( src_pos, hit_pos );
                        translator.PushUnityEngineVector3(L, __cl_gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        
        
        
        
        
		
		
		
		
    }
}
