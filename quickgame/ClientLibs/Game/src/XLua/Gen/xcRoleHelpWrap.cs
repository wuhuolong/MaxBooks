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
    public class xcRoleHelpWrap
    {
        public static void __Register(RealStatePtr L)
        {
			ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			XUtils.BeginObjectRegister(typeof(xc.RoleHelp), L, translator, 0, 0, 0, 0);
			
			
			
			
			
			XUtils.EndObjectRegister(typeof(xc.RoleHelp), L, translator, null, null,
			    null, null, null);

		    XUtils.BeginClassRegister(typeof(xc.RoleHelp), L, __CreateInstance, 12, 0, 0);
			XUtils.RegisterFunc(L, XUtils.CLS_IDX, "GetPrefabName", _m_GetPrefabName_xlua_st_);
            XUtils.RegisterFunc(L, XUtils.CLS_IDX, "GetRoleIcon", _m_GetRoleIcon_xlua_st_);
            XUtils.RegisterFunc(L, XUtils.CLS_IDX, "GetPrefabScale", _m_GetPrefabScale_xlua_st_);
            XUtils.RegisterFunc(L, XUtils.CLS_IDX, "GetPrefabFloatScale", _m_GetPrefabFloatScale_xlua_st_);
            XUtils.RegisterFunc(L, XUtils.CLS_IDX, "GetPrefabCamOffsetInDialogWnd", _m_GetPrefabCamOffsetInDialogWnd_xlua_st_);
            XUtils.RegisterFunc(L, XUtils.CLS_IDX, "GetPrefabCamRotateInDialogWnd", _m_GetPrefabCamRotateInDialogWnd_xlua_st_);
            XUtils.RegisterFunc(L, XUtils.CLS_IDX, "GetHeightInScene", _m_GetHeightInScene_xlua_st_);
            XUtils.RegisterFunc(L, XUtils.CLS_IDX, "GetPositionInScene", _m_GetPositionInScene_xlua_st_);
            XUtils.RegisterFunc(L, XUtils.CLS_IDX, "GetActorName", _m_GetActorName_xlua_st_);
            XUtils.RegisterFunc(L, XUtils.CLS_IDX, "GetPlayerIconName", _m_GetPlayerIconName_xlua_st_);
            XUtils.RegisterFunc(L, XUtils.CLS_IDX, "GetInstColorName", _m_GetInstColorName_xlua_st_);
            
			
            
            XUtils.RegisterObject(L, translator, XUtils.CLS_IDX, "UnderlyingSystemType", typeof(xc.RoleHelp));
			
			
			XUtils.EndClassRegister(typeof(xc.RoleHelp), L, translator);
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int __CreateInstance(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			try {
				if(LuaAPI.lua_gettop(L) == 1)
				{
					
					xc.RoleHelp __cl_gen_ret = new xc.RoleHelp();
					translator.Push(L, __cl_gen_ret);
					return 1;
				}
				
			}
			catch(System.Exception __gen_e) {
				return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
			}
            return LuaAPI.luaL_error(L, "invalid arguments to xc.RoleHelp constructor!");
            
        }
        
		
        
		
        
        
        
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_GetPrefabName_xlua_st_(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            
			int __gen_param_count = LuaAPI.lua_gettop(L);
            
            try {
                if(__gen_param_count == 2&& LuaTypes.LUA_TNUMBER == LuaAPI.lua_type(L, 1)&& LuaTypes.LUA_TBOOLEAN == LuaAPI.lua_type(L, 2)) 
                {
                    uint type_id = LuaAPI.xlua_touint(L, 1);
                    bool is_local_player = LuaAPI.lua_toboolean(L, 2);
                    
                        string __cl_gen_ret = xc.RoleHelp.GetPrefabName( type_id, is_local_player );
                        LuaAPI.lua_pushstring(L, __cl_gen_ret);
                    
                    
                    
                    return 1;
                }
                if(__gen_param_count == 1&& LuaTypes.LUA_TNUMBER == LuaAPI.lua_type(L, 1)) 
                {
                    uint type_id = LuaAPI.xlua_touint(L, 1);
                    
                        string __cl_gen_ret = xc.RoleHelp.GetPrefabName( type_id );
                        LuaAPI.lua_pushstring(L, __cl_gen_ret);
                    
                    
                    
                    return 1;
                }
                if(__gen_param_count == 1&& translator.Assignable<xc.UnitCacheInfo>(L, 1)) 
                {
                    xc.UnitCacheInfo info = (xc.UnitCacheInfo)translator.GetObject(L, 1, typeof(xc.UnitCacheInfo));
                    
                        string __cl_gen_ret = xc.RoleHelp.GetPrefabName( info );
                        LuaAPI.lua_pushstring(L, __cl_gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
            return LuaAPI.luaL_error(L, "invalid arguments to xc.RoleHelp.GetPrefabName!");
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_GetRoleIcon_xlua_st_(RealStatePtr L)
        {
            
            
            
            try {
                
                {
                    uint type_id = LuaAPI.xlua_touint(L, 1);
                    
                        string __cl_gen_ret = xc.RoleHelp.GetRoleIcon( type_id );
                        LuaAPI.lua_pushstring(L, __cl_gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_GetPrefabScale_xlua_st_(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            
			int __gen_param_count = LuaAPI.lua_gettop(L);
            
            try {
                if(__gen_param_count == 1&& LuaTypes.LUA_TNUMBER == LuaAPI.lua_type(L, 1)) 
                {
                    uint type_id = LuaAPI.xlua_touint(L, 1);
                    
                        UnityEngine.Vector3 __cl_gen_ret = xc.RoleHelp.GetPrefabScale( type_id );
                        translator.PushUnityEngineVector3(L, __cl_gen_ret);
                    
                    
                    
                    return 1;
                }
                if(__gen_param_count == 1&& translator.Assignable<xc.UnitCacheInfo>(L, 1)) 
                {
                    xc.UnitCacheInfo info = (xc.UnitCacheInfo)translator.GetObject(L, 1, typeof(xc.UnitCacheInfo));
                    
                        UnityEngine.Vector3 __cl_gen_ret = xc.RoleHelp.GetPrefabScale( info );
                        translator.PushUnityEngineVector3(L, __cl_gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
            return LuaAPI.luaL_error(L, "invalid arguments to xc.RoleHelp.GetPrefabScale!");
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_GetPrefabFloatScale_xlua_st_(RealStatePtr L)
        {
            
            
            
            try {
                
                {
                    uint type_id = LuaAPI.xlua_touint(L, 1);
                    
                        float __cl_gen_ret = xc.RoleHelp.GetPrefabFloatScale( type_id );
                        LuaAPI.lua_pushnumber(L, __cl_gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_GetPrefabCamOffsetInDialogWnd_xlua_st_(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            
            try {
                
                {
                    uint type_id = LuaAPI.xlua_touint(L, 1);
                    
                        UnityEngine.Vector3 __cl_gen_ret = xc.RoleHelp.GetPrefabCamOffsetInDialogWnd( type_id );
                        translator.PushUnityEngineVector3(L, __cl_gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_GetPrefabCamRotateInDialogWnd_xlua_st_(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            
            try {
                
                {
                    uint type_id = LuaAPI.xlua_touint(L, 1);
                    
                        UnityEngine.Vector3 __cl_gen_ret = xc.RoleHelp.GetPrefabCamRotateInDialogWnd( type_id );
                        translator.PushUnityEngineVector3(L, __cl_gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_GetHeightInScene_xlua_st_(RealStatePtr L)
        {
            
            
            
            try {
                
                {
                    uint type_id = LuaAPI.xlua_touint(L, 1);
                    float x = (float)LuaAPI.lua_tonumber(L, 2);
                    float z = (float)LuaAPI.lua_tonumber(L, 3);
                    
                        float __cl_gen_ret = xc.RoleHelp.GetHeightInScene( type_id, x, z );
                        LuaAPI.lua_pushnumber(L, __cl_gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_GetPositionInScene_xlua_st_(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            
            try {
                
                {
                    uint type_id = LuaAPI.xlua_touint(L, 1);
                    float x = (float)LuaAPI.lua_tonumber(L, 2);
                    float z = (float)LuaAPI.lua_tonumber(L, 3);
                    
                        UnityEngine.Vector3 __cl_gen_ret = xc.RoleHelp.GetPositionInScene( type_id, x, z );
                        translator.PushUnityEngineVector3(L, __cl_gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_GetActorName_xlua_st_(RealStatePtr L)
        {
            
            
            
            try {
                
                {
                    uint type_id = LuaAPI.xlua_touint(L, 1);
                    
                        string __cl_gen_ret = xc.RoleHelp.GetActorName( type_id );
                        LuaAPI.lua_pushstring(L, __cl_gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_GetPlayerIconName_xlua_st_(RealStatePtr L)
        {
            
            
            
			int __gen_param_count = LuaAPI.lua_gettop(L);
            
            try {
                if(__gen_param_count == 3&& LuaTypes.LUA_TNUMBER == LuaAPI.lua_type(L, 1)&& LuaTypes.LUA_TNUMBER == LuaAPI.lua_type(L, 2)&& LuaTypes.LUA_TBOOLEAN == LuaAPI.lua_type(L, 3)) 
                {
                    uint vocationId = LuaAPI.xlua_touint(L, 1);
                    uint transferLv = LuaAPI.xlua_touint(L, 2);
                    bool showTips = LuaAPI.lua_toboolean(L, 3);
                    
                        string __cl_gen_ret = xc.RoleHelp.GetPlayerIconName( vocationId, transferLv, showTips );
                        LuaAPI.lua_pushstring(L, __cl_gen_ret);
                    
                    
                    
                    return 1;
                }
                if(__gen_param_count == 2&& LuaTypes.LUA_TNUMBER == LuaAPI.lua_type(L, 1)&& LuaTypes.LUA_TNUMBER == LuaAPI.lua_type(L, 2)) 
                {
                    uint vocationId = LuaAPI.xlua_touint(L, 1);
                    uint transferLv = LuaAPI.xlua_touint(L, 2);
                    
                        string __cl_gen_ret = xc.RoleHelp.GetPlayerIconName( vocationId, transferLv );
                        LuaAPI.lua_pushstring(L, __cl_gen_ret);
                    
                    
                    
                    return 1;
                }
                if(__gen_param_count == 1&& LuaTypes.LUA_TNUMBER == LuaAPI.lua_type(L, 1)) 
                {
                    uint vocationId = LuaAPI.xlua_touint(L, 1);
                    
                        string __cl_gen_ret = xc.RoleHelp.GetPlayerIconName( vocationId );
                        LuaAPI.lua_pushstring(L, __cl_gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
            return LuaAPI.luaL_error(L, "invalid arguments to xc.RoleHelp.GetPlayerIconName!");
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_GetInstColorName_xlua_st_(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            
            try {
                
                {
                    Actor act = (Actor)translator.GetObject(L, 1, typeof(Actor));
                    string name = LuaAPI.lua_tostring(L, 2);
                    
                        string __cl_gen_ret = xc.RoleHelp.GetInstColorName( act, name );
                        LuaAPI.lua_pushstring(L, __cl_gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        
        
        
        
        
		
		
		
		
    }
}
