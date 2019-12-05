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
    public class xcDungeonLevelObjectHelperWrap
    {
        public static void __Register(RealStatePtr L)
        {
			ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			XUtils.BeginObjectRegister(typeof(xc.Dungeon.LevelObjectHelper), L, translator, 0, 0, 0, 0);
			
			
			
			
			
			XUtils.EndObjectRegister(typeof(xc.Dungeon.LevelObjectHelper), L, translator, null, null,
			    null, null, null);

		    XUtils.BeginClassRegister(typeof(xc.Dungeon.LevelObjectHelper), L, __CreateInstance, 11, 0, 0);
			XUtils.RegisterFunc(L, XUtils.CLS_IDX, "SetObjectShapeCollider", _m_SetObjectShapeCollider_xlua_st_);
            XUtils.RegisterFunc(L, XUtils.CLS_IDX, "SetObjectPrefab", _m_SetObjectPrefab_xlua_st_);
            XUtils.RegisterFunc(L, XUtils.CLS_IDX, "GetMonsterPosition", _m_GetMonsterPosition_xlua_st_);
            XUtils.RegisterFunc(L, XUtils.CLS_IDX, "GetMonsterPositionsByActorId", _m_GetMonsterPositionsByActorId_xlua_st_);
            XUtils.RegisterFunc(L, XUtils.CLS_IDX, "GetNearestMonsterPositionByActorId", _m_GetNearestMonsterPositionByActorId_xlua_st_);
            XUtils.RegisterFunc(L, XUtils.CLS_IDX, "GetBossMonsterList", _m_GetBossMonsterList_xlua_st_);
            XUtils.RegisterFunc(L, XUtils.CLS_IDX, "GetDistanceBetweenLocalPlayerAndTag", _m_GetDistanceBetweenLocalPlayerAndTag_xlua_st_);
            XUtils.RegisterFunc(L, XUtils.CLS_IDX, "GetTagPositionsByType", _m_GetTagPositionsByType_xlua_st_);
            XUtils.RegisterFunc(L, XUtils.CLS_IDX, "GetTagPosition", _m_GetTagPosition_xlua_st_);
            XUtils.RegisterFunc(L, XUtils.CLS_IDX, "GetBornPosRotation", _m_GetBornPosRotation_xlua_st_);
            
			
            
            XUtils.RegisterObject(L, translator, XUtils.CLS_IDX, "UnderlyingSystemType", typeof(xc.Dungeon.LevelObjectHelper));
			
			
			XUtils.EndClassRegister(typeof(xc.Dungeon.LevelObjectHelper), L, translator);
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int __CreateInstance(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			try {
				if(LuaAPI.lua_gettop(L) == 1)
				{
					
					xc.Dungeon.LevelObjectHelper __cl_gen_ret = new xc.Dungeon.LevelObjectHelper();
					translator.Push(L, __cl_gen_ret);
					return 1;
				}
				
			}
			catch(System.Exception __gen_e) {
				return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
			}
            return LuaAPI.luaL_error(L, "invalid arguments to xc.Dungeon.LevelObjectHelper constructor!");
            
        }
        
		
        
		
        
        
        
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_SetObjectShapeCollider_xlua_st_(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            
            try {
                
                {
                    UnityEngine.GameObject targetObject = (UnityEngine.GameObject)translator.GetObject(L, 1, typeof(UnityEngine.GameObject));
                    Neptune.ShapeInfo shapeInfo = (Neptune.ShapeInfo)translator.GetObject(L, 2, typeof(Neptune.ShapeInfo));
                    
                    xc.Dungeon.LevelObjectHelper.SetObjectShapeCollider( targetObject, shapeInfo );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_SetObjectPrefab_xlua_st_(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            
			int __gen_param_count = LuaAPI.lua_gettop(L);
            
            try {
                if(__gen_param_count == 3&& translator.Assignable<UnityEngine.GameObject>(L, 1)&& translator.Assignable<Neptune.NodePrefabInfo>(L, 2)&& translator.Assignable<System.Action>(L, 3)) 
                {
                    UnityEngine.GameObject targetObject = (UnityEngine.GameObject)translator.GetObject(L, 1, typeof(UnityEngine.GameObject));
                    Neptune.NodePrefabInfo prefabInfo = (Neptune.NodePrefabInfo)translator.GetObject(L, 2, typeof(Neptune.NodePrefabInfo));
                    System.Action finishCallback = translator.GetDelegate<System.Action>(L, 3);
                    
                        UnityEngine.Coroutine __cl_gen_ret = xc.Dungeon.LevelObjectHelper.SetObjectPrefab( targetObject, prefabInfo, finishCallback );
                        translator.Push(L, __cl_gen_ret);
                    
                    
                    
                    return 1;
                }
                if(__gen_param_count == 2&& translator.Assignable<UnityEngine.GameObject>(L, 1)&& translator.Assignable<Neptune.NodePrefabInfo>(L, 2)) 
                {
                    UnityEngine.GameObject targetObject = (UnityEngine.GameObject)translator.GetObject(L, 1, typeof(UnityEngine.GameObject));
                    Neptune.NodePrefabInfo prefabInfo = (Neptune.NodePrefabInfo)translator.GetObject(L, 2, typeof(Neptune.NodePrefabInfo));
                    
                        UnityEngine.Coroutine __cl_gen_ret = xc.Dungeon.LevelObjectHelper.SetObjectPrefab( targetObject, prefabInfo );
                        translator.Push(L, __cl_gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
            return LuaAPI.luaL_error(L, "invalid arguments to xc.Dungeon.LevelObjectHelper.SetObjectPrefab!");
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_GetMonsterPosition_xlua_st_(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            
			int __gen_param_count = LuaAPI.lua_gettop(L);
            
            try {
                if(__gen_param_count == 2&& LuaTypes.LUA_TNUMBER == LuaAPI.lua_type(L, 1)&& translator.Assignable<Neptune.Data>(L, 2)) 
                {
                    uint id = LuaAPI.xlua_touint(L, 1);
                    Neptune.Data data = (Neptune.Data)translator.GetObject(L, 2, typeof(Neptune.Data));
                    
                        UnityEngine.Vector3 __cl_gen_ret = xc.Dungeon.LevelObjectHelper.GetMonsterPosition( id, data );
                        translator.PushUnityEngineVector3(L, __cl_gen_ret);
                    
                    
                    
                    return 1;
                }
                if(__gen_param_count == 1&& LuaTypes.LUA_TNUMBER == LuaAPI.lua_type(L, 1)) 
                {
                    uint id = LuaAPI.xlua_touint(L, 1);
                    
                        UnityEngine.Vector3 __cl_gen_ret = xc.Dungeon.LevelObjectHelper.GetMonsterPosition( id );
                        translator.PushUnityEngineVector3(L, __cl_gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
            return LuaAPI.luaL_error(L, "invalid arguments to xc.Dungeon.LevelObjectHelper.GetMonsterPosition!");
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_GetMonsterPositionsByActorId_xlua_st_(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            
			int __gen_param_count = LuaAPI.lua_gettop(L);
            
            try {
                if(__gen_param_count == 2&& LuaTypes.LUA_TNUMBER == LuaAPI.lua_type(L, 1)&& translator.Assignable<Neptune.Data>(L, 2)) 
                {
                    uint actorId = LuaAPI.xlua_touint(L, 1);
                    Neptune.Data data = (Neptune.Data)translator.GetObject(L, 2, typeof(Neptune.Data));
                    
                        System.Collections.Generic.List<UnityEngine.Vector3> __cl_gen_ret = xc.Dungeon.LevelObjectHelper.GetMonsterPositionsByActorId( actorId, data );
                        translator.Push(L, __cl_gen_ret);
                    
                    
                    
                    return 1;
                }
                if(__gen_param_count == 1&& LuaTypes.LUA_TNUMBER == LuaAPI.lua_type(L, 1)) 
                {
                    uint actorId = LuaAPI.xlua_touint(L, 1);
                    
                        System.Collections.Generic.List<UnityEngine.Vector3> __cl_gen_ret = xc.Dungeon.LevelObjectHelper.GetMonsterPositionsByActorId( actorId );
                        translator.Push(L, __cl_gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
            return LuaAPI.luaL_error(L, "invalid arguments to xc.Dungeon.LevelObjectHelper.GetMonsterPositionsByActorId!");
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_GetNearestMonsterPositionByActorId_xlua_st_(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            
			int __gen_param_count = LuaAPI.lua_gettop(L);
            
            try {
                if(__gen_param_count == 2&& LuaTypes.LUA_TNUMBER == LuaAPI.lua_type(L, 1)&& translator.Assignable<Neptune.Data>(L, 2)) 
                {
                    uint actorId = LuaAPI.xlua_touint(L, 1);
                    Neptune.Data data = (Neptune.Data)translator.GetObject(L, 2, typeof(Neptune.Data));
                    
                        UnityEngine.Vector3 __cl_gen_ret = xc.Dungeon.LevelObjectHelper.GetNearestMonsterPositionByActorId( actorId, data );
                        translator.PushUnityEngineVector3(L, __cl_gen_ret);
                    
                    
                    
                    return 1;
                }
                if(__gen_param_count == 1&& LuaTypes.LUA_TNUMBER == LuaAPI.lua_type(L, 1)) 
                {
                    uint actorId = LuaAPI.xlua_touint(L, 1);
                    
                        UnityEngine.Vector3 __cl_gen_ret = xc.Dungeon.LevelObjectHelper.GetNearestMonsterPositionByActorId( actorId );
                        translator.PushUnityEngineVector3(L, __cl_gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
            return LuaAPI.luaL_error(L, "invalid arguments to xc.Dungeon.LevelObjectHelper.GetNearestMonsterPositionByActorId!");
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_GetBossMonsterList_xlua_st_(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            
			int __gen_param_count = LuaAPI.lua_gettop(L);
            
            try {
                if(__gen_param_count == 1&& translator.Assignable<Neptune.Data>(L, 1)) 
                {
                    Neptune.Data data = (Neptune.Data)translator.GetObject(L, 1, typeof(Neptune.Data));
                    
                        System.Collections.Generic.List<uint> __cl_gen_ret = xc.Dungeon.LevelObjectHelper.GetBossMonsterList( data );
                        translator.Push(L, __cl_gen_ret);
                    
                    
                    
                    return 1;
                }
                if(__gen_param_count == 0) 
                {
                    
                        System.Collections.Generic.List<uint> __cl_gen_ret = xc.Dungeon.LevelObjectHelper.GetBossMonsterList(  );
                        translator.Push(L, __cl_gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
            return LuaAPI.luaL_error(L, "invalid arguments to xc.Dungeon.LevelObjectHelper.GetBossMonsterList!");
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_GetDistanceBetweenLocalPlayerAndTag_xlua_st_(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            
			int __gen_param_count = LuaAPI.lua_gettop(L);
            
            try {
                if(__gen_param_count == 2&& LuaTypes.LUA_TNUMBER == LuaAPI.lua_type(L, 1)&& translator.Assignable<Neptune.Data>(L, 2)) 
                {
                    uint id = LuaAPI.xlua_touint(L, 1);
                    Neptune.Data data = (Neptune.Data)translator.GetObject(L, 2, typeof(Neptune.Data));
                    
                        float __cl_gen_ret = xc.Dungeon.LevelObjectHelper.GetDistanceBetweenLocalPlayerAndTag( id, data );
                        LuaAPI.lua_pushnumber(L, __cl_gen_ret);
                    
                    
                    
                    return 1;
                }
                if(__gen_param_count == 1&& LuaTypes.LUA_TNUMBER == LuaAPI.lua_type(L, 1)) 
                {
                    uint id = LuaAPI.xlua_touint(L, 1);
                    
                        float __cl_gen_ret = xc.Dungeon.LevelObjectHelper.GetDistanceBetweenLocalPlayerAndTag( id );
                        LuaAPI.lua_pushnumber(L, __cl_gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
            return LuaAPI.luaL_error(L, "invalid arguments to xc.Dungeon.LevelObjectHelper.GetDistanceBetweenLocalPlayerAndTag!");
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_GetTagPositionsByType_xlua_st_(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            
			int __gen_param_count = LuaAPI.lua_gettop(L);
            
            try {
                if(__gen_param_count == 2&& (LuaAPI.lua_isnil(L, 1) || LuaAPI.lua_type(L, 1) == LuaTypes.LUA_TSTRING)&& translator.Assignable<Neptune.Data>(L, 2)) 
                {
                    string type = LuaAPI.lua_tostring(L, 1);
                    Neptune.Data data = (Neptune.Data)translator.GetObject(L, 2, typeof(Neptune.Data));
                    
                        System.Collections.Generic.List<UnityEngine.Vector3> __cl_gen_ret = xc.Dungeon.LevelObjectHelper.GetTagPositionsByType( type, data );
                        translator.Push(L, __cl_gen_ret);
                    
                    
                    
                    return 1;
                }
                if(__gen_param_count == 1&& (LuaAPI.lua_isnil(L, 1) || LuaAPI.lua_type(L, 1) == LuaTypes.LUA_TSTRING)) 
                {
                    string type = LuaAPI.lua_tostring(L, 1);
                    
                        System.Collections.Generic.List<UnityEngine.Vector3> __cl_gen_ret = xc.Dungeon.LevelObjectHelper.GetTagPositionsByType( type );
                        translator.Push(L, __cl_gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
            return LuaAPI.luaL_error(L, "invalid arguments to xc.Dungeon.LevelObjectHelper.GetTagPositionsByType!");
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_GetTagPosition_xlua_st_(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            
			int __gen_param_count = LuaAPI.lua_gettop(L);
            
            try {
                if(__gen_param_count == 2&& LuaTypes.LUA_TNUMBER == LuaAPI.lua_type(L, 1)&& translator.Assignable<Neptune.Data>(L, 2)) 
                {
                    uint id = LuaAPI.xlua_touint(L, 1);
                    Neptune.Data data = (Neptune.Data)translator.GetObject(L, 2, typeof(Neptune.Data));
                    
                        UnityEngine.Vector3 __cl_gen_ret = xc.Dungeon.LevelObjectHelper.GetTagPosition( id, data );
                        translator.PushUnityEngineVector3(L, __cl_gen_ret);
                    
                    
                    
                    return 1;
                }
                if(__gen_param_count == 1&& LuaTypes.LUA_TNUMBER == LuaAPI.lua_type(L, 1)) 
                {
                    uint id = LuaAPI.xlua_touint(L, 1);
                    
                        UnityEngine.Vector3 __cl_gen_ret = xc.Dungeon.LevelObjectHelper.GetTagPosition( id );
                        translator.PushUnityEngineVector3(L, __cl_gen_ret);
                    
                    
                    
                    return 1;
                }
                if(__gen_param_count == 2&& (LuaAPI.lua_isnil(L, 1) || LuaAPI.lua_type(L, 1) == LuaTypes.LUA_TSTRING)&& translator.Assignable<Neptune.Data>(L, 2)) 
                {
                    string idAndType = LuaAPI.lua_tostring(L, 1);
                    Neptune.Data data = (Neptune.Data)translator.GetObject(L, 2, typeof(Neptune.Data));
                    
                        UnityEngine.Vector3 __cl_gen_ret = xc.Dungeon.LevelObjectHelper.GetTagPosition( idAndType, data );
                        translator.PushUnityEngineVector3(L, __cl_gen_ret);
                    
                    
                    
                    return 1;
                }
                if(__gen_param_count == 1&& (LuaAPI.lua_isnil(L, 1) || LuaAPI.lua_type(L, 1) == LuaTypes.LUA_TSTRING)) 
                {
                    string idAndType = LuaAPI.lua_tostring(L, 1);
                    
                        UnityEngine.Vector3 __cl_gen_ret = xc.Dungeon.LevelObjectHelper.GetTagPosition( idAndType );
                        translator.PushUnityEngineVector3(L, __cl_gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
            return LuaAPI.luaL_error(L, "invalid arguments to xc.Dungeon.LevelObjectHelper.GetTagPosition!");
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_GetBornPosRotation_xlua_st_(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            
            try {
                
                {
                    int key = LuaAPI.xlua_tointeger(L, 1);
                    
                        UnityEngine.Quaternion __cl_gen_ret = xc.Dungeon.LevelObjectHelper.GetBornPosRotation( key );
                        translator.PushUnityEngineQuaternion(L, __cl_gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        
        
        
        
        
		
		
		
		
    }
}
