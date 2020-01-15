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
    public class UnityEngineAnimatorWrap
    {
        public static void __Register(RealStatePtr L)
        {
			ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			XUtils.BeginObjectRegister(typeof(UnityEngine.Animator), L, translator, 0, 3, 0, 0);
			
			XUtils.RegisterFunc(L, XUtils.METHOD_IDX, "SetBool", _m_SetBool);
			XUtils.RegisterFunc(L, XUtils.METHOD_IDX, "SetInteger", _m_SetInteger);
			XUtils.RegisterFunc(L, XUtils.METHOD_IDX, "Play", _m_Play);
			
			
			
			
			XUtils.EndObjectRegister(typeof(UnityEngine.Animator), L, translator, null, null,
			    null, null, null);

		    XUtils.BeginClassRegister(typeof(UnityEngine.Animator), L, __CreateInstance, 1, 0, 0);
			
			
            
            XUtils.RegisterObject(L, translator, XUtils.CLS_IDX, "UnderlyingSystemType", typeof(UnityEngine.Animator));
			
			
			XUtils.EndClassRegister(typeof(UnityEngine.Animator), L, translator);
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int __CreateInstance(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			try {
				if(LuaAPI.lua_gettop(L) == 1)
				{
					
					UnityEngine.Animator __cl_gen_ret = new UnityEngine.Animator();
					translator.Push(L, __cl_gen_ret);
					return 1;
				}
				
			}
			catch(System.Exception __gen_e) {
				return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
			}
            return LuaAPI.luaL_error(L, "invalid arguments to UnityEngine.Animator constructor!");
            
        }
        
		
        
		
        
        
        
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_SetBool(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            UnityEngine.Animator __cl_gen_to_be_invoked = (UnityEngine.Animator)translator.FastGetCSObj(L, 1);
            
            
			int __gen_param_count = LuaAPI.lua_gettop(L);
            
            try {
                if(__gen_param_count == 3&& LuaTypes.LUA_TNUMBER == LuaAPI.lua_type(L, 2)&& LuaTypes.LUA_TBOOLEAN == LuaAPI.lua_type(L, 3)) 
                {
                    int id = LuaAPI.xlua_tointeger(L, 2);
                    bool value = LuaAPI.lua_toboolean(L, 3);
                    
                    __cl_gen_to_be_invoked.SetBool( id, value );
                    
                    
                    
                    return 0;
                }
                if(__gen_param_count == 3&& (LuaAPI.lua_isnil(L, 2) || LuaAPI.lua_type(L, 2) == LuaTypes.LUA_TSTRING)&& LuaTypes.LUA_TBOOLEAN == LuaAPI.lua_type(L, 3)) 
                {
                    string name = LuaAPI.lua_tostring(L, 2);
                    bool value = LuaAPI.lua_toboolean(L, 3);
                    
                    __cl_gen_to_be_invoked.SetBool( name, value );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
            return LuaAPI.luaL_error(L, "invalid arguments to UnityEngine.Animator.SetBool!");
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_SetInteger(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            UnityEngine.Animator __cl_gen_to_be_invoked = (UnityEngine.Animator)translator.FastGetCSObj(L, 1);
            
            
			int __gen_param_count = LuaAPI.lua_gettop(L);
            
            try {
                if(__gen_param_count == 3&& LuaTypes.LUA_TNUMBER == LuaAPI.lua_type(L, 2)&& LuaTypes.LUA_TNUMBER == LuaAPI.lua_type(L, 3)) 
                {
                    int id = LuaAPI.xlua_tointeger(L, 2);
                    int value = LuaAPI.xlua_tointeger(L, 3);
                    
                    __cl_gen_to_be_invoked.SetInteger( id, value );
                    
                    
                    
                    return 0;
                }
                if(__gen_param_count == 3&& (LuaAPI.lua_isnil(L, 2) || LuaAPI.lua_type(L, 2) == LuaTypes.LUA_TSTRING)&& LuaTypes.LUA_TNUMBER == LuaAPI.lua_type(L, 3)) 
                {
                    string name = LuaAPI.lua_tostring(L, 2);
                    int value = LuaAPI.xlua_tointeger(L, 3);
                    
                    __cl_gen_to_be_invoked.SetInteger( name, value );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
            return LuaAPI.luaL_error(L, "invalid arguments to UnityEngine.Animator.SetInteger!");
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_Play(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            UnityEngine.Animator __cl_gen_to_be_invoked = (UnityEngine.Animator)translator.FastGetCSObj(L, 1);
            
            
			int __gen_param_count = LuaAPI.lua_gettop(L);
            
            try {
                if(__gen_param_count == 2&& LuaTypes.LUA_TNUMBER == LuaAPI.lua_type(L, 2)) 
                {
                    int stateNameHash = LuaAPI.xlua_tointeger(L, 2);
                    
                    __cl_gen_to_be_invoked.Play( stateNameHash );
                    
                    
                    
                    return 0;
                }
                if(__gen_param_count == 3&& LuaTypes.LUA_TNUMBER == LuaAPI.lua_type(L, 2)&& LuaTypes.LUA_TNUMBER == LuaAPI.lua_type(L, 3)) 
                {
                    int stateNameHash = LuaAPI.xlua_tointeger(L, 2);
                    int layer = LuaAPI.xlua_tointeger(L, 3);
                    
                    __cl_gen_to_be_invoked.Play( stateNameHash, layer );
                    
                    
                    
                    return 0;
                }
                if(__gen_param_count == 4&& LuaTypes.LUA_TNUMBER == LuaAPI.lua_type(L, 2)&& LuaTypes.LUA_TNUMBER == LuaAPI.lua_type(L, 3)&& LuaTypes.LUA_TNUMBER == LuaAPI.lua_type(L, 4)) 
                {
                    int stateNameHash = LuaAPI.xlua_tointeger(L, 2);
                    int layer = LuaAPI.xlua_tointeger(L, 3);
                    float normalizedTime = (float)LuaAPI.lua_tonumber(L, 4);
                    
                    __cl_gen_to_be_invoked.Play( stateNameHash, layer, normalizedTime );
                    
                    
                    
                    return 0;
                }
                if(__gen_param_count == 2&& (LuaAPI.lua_isnil(L, 2) || LuaAPI.lua_type(L, 2) == LuaTypes.LUA_TSTRING)) 
                {
                    string stateName = LuaAPI.lua_tostring(L, 2);
                    
                    __cl_gen_to_be_invoked.Play( stateName );
                    
                    
                    
                    return 0;
                }
                if(__gen_param_count == 3&& (LuaAPI.lua_isnil(L, 2) || LuaAPI.lua_type(L, 2) == LuaTypes.LUA_TSTRING)&& LuaTypes.LUA_TNUMBER == LuaAPI.lua_type(L, 3)) 
                {
                    string stateName = LuaAPI.lua_tostring(L, 2);
                    int layer = LuaAPI.xlua_tointeger(L, 3);
                    
                    __cl_gen_to_be_invoked.Play( stateName, layer );
                    
                    
                    
                    return 0;
                }
                if(__gen_param_count == 4&& (LuaAPI.lua_isnil(L, 2) || LuaAPI.lua_type(L, 2) == LuaTypes.LUA_TSTRING)&& LuaTypes.LUA_TNUMBER == LuaAPI.lua_type(L, 3)&& LuaTypes.LUA_TNUMBER == LuaAPI.lua_type(L, 4)) 
                {
                    string stateName = LuaAPI.lua_tostring(L, 2);
                    int layer = LuaAPI.xlua_tointeger(L, 3);
                    float normalizedTime = (float)LuaAPI.lua_tonumber(L, 4);
                    
                    __cl_gen_to_be_invoked.Play( stateName, layer, normalizedTime );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
            return LuaAPI.luaL_error(L, "invalid arguments to UnityEngine.Animator.Play!");
            
        }
        
        
        
        
        
        
		
		
		
		
    }
}
