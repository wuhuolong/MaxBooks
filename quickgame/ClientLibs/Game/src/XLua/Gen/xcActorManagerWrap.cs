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
    public class xcActorManagerWrap
    {
        public static void __Register(RealStatePtr L)
        {
			ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			XUtils.BeginObjectRegister(typeof(xc.ActorManager), L, translator, 0, 19, 8, 0);
			
			XUtils.RegisterFunc(L, XUtils.METHOD_IDX, "Awake", _m_Awake);
			XUtils.RegisterFunc(L, XUtils.METHOD_IDX, "Update", _m_Update);
			XUtils.RegisterFunc(L, XUtils.METHOD_IDX, "GetMonsterSetByActorId", _m_GetMonsterSetByActorId);
			XUtils.RegisterFunc(L, XUtils.METHOD_IDX, "GetGuardedNpc", _m_GetGuardedNpc);
			XUtils.RegisterFunc(L, XUtils.METHOD_IDX, "OnEnterScene", _m_OnEnterScene);
			XUtils.RegisterFunc(L, XUtils.METHOD_IDX, "OnDestroyScene", _m_OnDestroyScene);
			XUtils.RegisterFunc(L, XUtils.METHOD_IDX, "DestroyAllMonsters", _m_DestroyAllMonsters);
			XUtils.RegisterFunc(L, XUtils.METHOD_IDX, "DestroyAllMonstersExceptGuardedNpc", _m_DestroyAllMonstersExceptGuardedNpc);
			XUtils.RegisterFunc(L, XUtils.METHOD_IDX, "ClearUnitCache", _m_ClearUnitCache);
			XUtils.RegisterFunc(L, XUtils.METHOD_IDX, "CreatePet", _m_CreatePet);
			XUtils.RegisterFunc(L, XUtils.METHOD_IDX, "DestroyActor", _m_DestroyActor);
			XUtils.RegisterFunc(L, XUtils.METHOD_IDX, "PushUnitCacheData", _m_PushUnitCacheData);
			XUtils.RegisterFunc(L, XUtils.METHOD_IDX, "PopUnitCacheData", _m_PopUnitCacheData);
			XUtils.RegisterFunc(L, XUtils.METHOD_IDX, "RemoveUnitCacheData", _m_RemoveUnitCacheData);
			XUtils.RegisterFunc(L, XUtils.METHOD_IDX, "GetUnitCacheInfo", _m_GetUnitCacheInfo);
			XUtils.RegisterFunc(L, XUtils.METHOD_IDX, "UpdateUnitCache", _m_UpdateUnitCache);
			XUtils.RegisterFunc(L, XUtils.METHOD_IDX, "GetActor", _m_GetActor);
			XUtils.RegisterFunc(L, XUtils.METHOD_IDX, "GetPlayer", _m_GetPlayer);
			XUtils.RegisterFunc(L, XUtils.METHOD_IDX, "UpdateLocalPlayerClientModels", _m_UpdateLocalPlayerClientModels);
			
			
			XUtils.RegisterFunc(L, XUtils.GETTER_IDX, "ActorSet", _g_get_ActorSet);
            XUtils.RegisterFunc(L, XUtils.GETTER_IDX, "ClientModelSet", _g_get_ClientModelSet);
            XUtils.RegisterFunc(L, XUtils.GETTER_IDX, "WorshipModelSet", _g_get_WorshipModelSet);
            XUtils.RegisterFunc(L, XUtils.GETTER_IDX, "MonsterSet", _g_get_MonsterSet);
            XUtils.RegisterFunc(L, XUtils.GETTER_IDX, "PetSet", _g_get_PetSet);
            XUtils.RegisterFunc(L, XUtils.GETTER_IDX, "SummonMonsterSet", _g_get_SummonMonsterSet);
            XUtils.RegisterFunc(L, XUtils.GETTER_IDX, "CalledMonsterSet", _g_get_CalledMonsterSet);
            XUtils.RegisterFunc(L, XUtils.GETTER_IDX, "PlayerSet", _g_get_PlayerSet);
            
			
			XUtils.EndObjectRegister(typeof(xc.ActorManager), L, translator, null, null,
			    null, null, null);

		    XUtils.BeginClassRegister(typeof(xc.ActorManager), L, __CreateInstance, 3, 1, 1);
			XUtils.RegisterFunc(L, XUtils.CLS_IDX, "ReplaceModelList", _m_ReplaceModelList_xlua_st_);
            XUtils.RegisterFunc(L, XUtils.CLS_IDX, "GetAvailableModelId", _m_GetAvailableModelId_xlua_st_);
            
			
            
            XUtils.RegisterObject(L, translator, XUtils.CLS_IDX, "UnderlyingSystemType", typeof(xc.ActorManager));
			XUtils.RegisterFunc(L, XUtils.CLS_GETTER_IDX, "Instance", _g_get_Instance);
            
			XUtils.RegisterFunc(L, XUtils.CLS_SETTER_IDX, "Instance", _s_set_Instance);
            
			XUtils.EndClassRegister(typeof(xc.ActorManager), L, translator);
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int __CreateInstance(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			try {
				if(LuaAPI.lua_gettop(L) == 1)
				{
					
					xc.ActorManager __cl_gen_ret = new xc.ActorManager();
					translator.Push(L, __cl_gen_ret);
					return 1;
				}
				
			}
			catch(System.Exception __gen_e) {
				return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
			}
            return LuaAPI.luaL_error(L, "invalid arguments to xc.ActorManager constructor!");
            
        }
        
		
        
		
        
        
        
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_Awake(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            xc.ActorManager __cl_gen_to_be_invoked = (xc.ActorManager)translator.FastGetCSObj(L, 1);
            
            
            try {
                
                {
                    
                    __cl_gen_to_be_invoked.Awake(  );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_Update(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            xc.ActorManager __cl_gen_to_be_invoked = (xc.ActorManager)translator.FastGetCSObj(L, 1);
            
            
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
        static int _m_GetMonsterSetByActorId(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            xc.ActorManager __cl_gen_to_be_invoked = (xc.ActorManager)translator.FastGetCSObj(L, 1);
            
            
            try {
                
                {
                    uint actorId = LuaAPI.xlua_touint(L, 2);
                    
                        System.Collections.Generic.Dictionary<xc.UnitID, Actor> __cl_gen_ret = __cl_gen_to_be_invoked.GetMonsterSetByActorId( actorId );
                        translator.Push(L, __cl_gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_GetGuardedNpc(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            xc.ActorManager __cl_gen_to_be_invoked = (xc.ActorManager)translator.FastGetCSObj(L, 1);
            
            
            try {
                
                {
                    
                        Actor __cl_gen_ret = __cl_gen_to_be_invoked.GetGuardedNpc(  );
                        translator.Push(L, __cl_gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_OnEnterScene(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            xc.ActorManager __cl_gen_to_be_invoked = (xc.ActorManager)translator.FastGetCSObj(L, 1);
            
            
            try {
                
                {
                    
                    __cl_gen_to_be_invoked.OnEnterScene(  );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_OnDestroyScene(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            xc.ActorManager __cl_gen_to_be_invoked = (xc.ActorManager)translator.FastGetCSObj(L, 1);
            
            
            try {
                
                {
                    
                    __cl_gen_to_be_invoked.OnDestroyScene(  );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_DestroyAllMonsters(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            xc.ActorManager __cl_gen_to_be_invoked = (xc.ActorManager)translator.FastGetCSObj(L, 1);
            
            
            try {
                
                {
                    
                    __cl_gen_to_be_invoked.DestroyAllMonsters(  );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_DestroyAllMonstersExceptGuardedNpc(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            xc.ActorManager __cl_gen_to_be_invoked = (xc.ActorManager)translator.FastGetCSObj(L, 1);
            
            
            try {
                
                {
                    
                    __cl_gen_to_be_invoked.DestroyAllMonstersExceptGuardedNpc(  );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_ClearUnitCache(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            xc.ActorManager __cl_gen_to_be_invoked = (xc.ActorManager)translator.FastGetCSObj(L, 1);
            
            
            try {
                
                {
                    
                    __cl_gen_to_be_invoked.ClearUnitCache(  );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_CreatePet(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            xc.ActorManager __cl_gen_to_be_invoked = (xc.ActorManager)translator.FastGetCSObj(L, 1);
            
            
            try {
                
                {
                    uint pet_id = LuaAPI.xlua_touint(L, 2);
                    uint actorId = LuaAPI.xlua_touint(L, 3);
                    UnityEngine.Vector3 pos;translator.Get(L, 4, out pos);
                    UnityEngine.Quaternion rot;translator.Get(L, 5, out rot);
                    Actor parent = (Actor)translator.GetObject(L, 6, typeof(Actor));
                    
                        xc.UnitID __cl_gen_ret = __cl_gen_to_be_invoked.CreatePet( pet_id, actorId, pos, rot, parent );
                        translator.Push(L, __cl_gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_DestroyActor(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            xc.ActorManager __cl_gen_to_be_invoked = (xc.ActorManager)translator.FastGetCSObj(L, 1);
            
            
			int __gen_param_count = LuaAPI.lua_gettop(L);
            
            try {
                if(__gen_param_count == 3&& translator.Assignable<xc.UnitID>(L, 2)&& LuaTypes.LUA_TNUMBER == LuaAPI.lua_type(L, 3)) 
                {
                    xc.UnitID id = (xc.UnitID)translator.GetObject(L, 2, typeof(xc.UnitID));
                    float delayTime = (float)LuaAPI.lua_tonumber(L, 3);
                    
                    __cl_gen_to_be_invoked.DestroyActor( id, delayTime );
                    
                    
                    
                    return 0;
                }
                if(__gen_param_count == 2&& translator.Assignable<xc.UnitID>(L, 2)) 
                {
                    xc.UnitID id = (xc.UnitID)translator.GetObject(L, 2, typeof(xc.UnitID));
                    
                    __cl_gen_to_be_invoked.DestroyActor( id );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
            return LuaAPI.luaL_error(L, "invalid arguments to xc.ActorManager.DestroyActor!");
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_PushUnitCacheData(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            xc.ActorManager __cl_gen_to_be_invoked = (xc.ActorManager)translator.FastGetCSObj(L, 1);
            
            
            try {
                
                {
                    xc.UnitCacheInfo data = (xc.UnitCacheInfo)translator.GetObject(L, 2, typeof(xc.UnitCacheInfo));
                    
                    __cl_gen_to_be_invoked.PushUnitCacheData( data );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_PopUnitCacheData(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            xc.ActorManager __cl_gen_to_be_invoked = (xc.ActorManager)translator.FastGetCSObj(L, 1);
            
            
            try {
                
                {
                    
                        xc.UnitCacheInfo __cl_gen_ret = __cl_gen_to_be_invoked.PopUnitCacheData(  );
                        translator.Push(L, __cl_gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_RemoveUnitCacheData(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            xc.ActorManager __cl_gen_to_be_invoked = (xc.ActorManager)translator.FastGetCSObj(L, 1);
            
            
            try {
                
                {
                    xc.ActorManager.UnitCacheDataFilter func = translator.GetDelegate<xc.ActorManager.UnitCacheDataFilter>(L, 2);
                    
                        bool __cl_gen_ret = __cl_gen_to_be_invoked.RemoveUnitCacheData( func );
                        LuaAPI.lua_pushboolean(L, __cl_gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_GetUnitCacheInfo(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            xc.ActorManager __cl_gen_to_be_invoked = (xc.ActorManager)translator.FastGetCSObj(L, 1);
            
            
            try {
                
                {
                    xc.UnitID uid = (xc.UnitID)translator.GetObject(L, 2, typeof(xc.UnitID));
                    
                        xc.UnitCacheInfo __cl_gen_ret = __cl_gen_to_be_invoked.GetUnitCacheInfo( uid );
                        translator.Push(L, __cl_gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_UpdateUnitCache(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            xc.ActorManager __cl_gen_to_be_invoked = (xc.ActorManager)translator.FastGetCSObj(L, 1);
            
            
			int __gen_param_count = LuaAPI.lua_gettop(L);
            
            try {
                if(__gen_param_count == 2&& LuaTypes.LUA_TBOOLEAN == LuaAPI.lua_type(L, 2)) 
                {
                    bool doAll = LuaAPI.lua_toboolean(L, 2);
                    
                    __cl_gen_to_be_invoked.UpdateUnitCache( doAll );
                    
                    
                    
                    return 0;
                }
                if(__gen_param_count == 3&& LuaTypes.LUA_TBOOLEAN == LuaAPI.lua_type(L, 2)&& translator.Assignable<xc.ActorManager.UnitCacheDataFilter>(L, 3)) 
                {
                    bool doAll = LuaAPI.lua_toboolean(L, 2);
                    xc.ActorManager.UnitCacheDataFilter filter = translator.GetDelegate<xc.ActorManager.UnitCacheDataFilter>(L, 3);
                    
                    __cl_gen_to_be_invoked.UpdateUnitCache( doAll, filter );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
            return LuaAPI.luaL_error(L, "invalid arguments to xc.ActorManager.UpdateUnitCache!");
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_ReplaceModelList_xlua_st_(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            
			int __gen_param_count = LuaAPI.lua_gettop(L);
            
            try {
                if(__gen_param_count == 3&& translator.Assignable<System.Collections.Generic.List<uint>>(L, 1)&& translator.Assignable<Actor.EVocationType>(L, 2)&& LuaTypes.LUA_TBOOLEAN == LuaAPI.lua_type(L, 3)) 
                {
                    System.Collections.Generic.List<uint> model_list = (System.Collections.Generic.List<uint>)translator.GetObject(L, 1, typeof(System.Collections.Generic.List<uint>));
                    Actor.EVocationType vocation;translator.Get(L, 2, out vocation);
                    bool newList = LuaAPI.lua_toboolean(L, 3);
                    
                        System.Collections.Generic.List<uint> __cl_gen_ret = xc.ActorManager.ReplaceModelList( model_list, vocation, newList );
                        translator.Push(L, __cl_gen_ret);
                    
                    
                    
                    return 1;
                }
                if(__gen_param_count == 2&& translator.Assignable<System.Collections.Generic.List<uint>>(L, 1)&& translator.Assignable<Actor.EVocationType>(L, 2)) 
                {
                    System.Collections.Generic.List<uint> model_list = (System.Collections.Generic.List<uint>)translator.GetObject(L, 1, typeof(System.Collections.Generic.List<uint>));
                    Actor.EVocationType vocation;translator.Get(L, 2, out vocation);
                    
                        System.Collections.Generic.List<uint> __cl_gen_ret = xc.ActorManager.ReplaceModelList( model_list, vocation );
                        translator.Push(L, __cl_gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
            return LuaAPI.luaL_error(L, "invalid arguments to xc.ActorManager.ReplaceModelList!");
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_GetActor(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            xc.ActorManager __cl_gen_to_be_invoked = (xc.ActorManager)translator.FastGetCSObj(L, 1);
            
            
			int __gen_param_count = LuaAPI.lua_gettop(L);
            
            try {
                if(__gen_param_count == 2&& LuaTypes.LUA_TNUMBER == LuaAPI.lua_type(L, 2)) 
                {
                    uint uid = LuaAPI.xlua_touint(L, 2);
                    
                        Actor __cl_gen_ret = __cl_gen_to_be_invoked.GetActor( uid );
                        translator.Push(L, __cl_gen_ret);
                    
                    
                    
                    return 1;
                }
                if(__gen_param_count == 2&& translator.Assignable<xc.UnitID>(L, 2)) 
                {
                    xc.UnitID id = (xc.UnitID)translator.GetObject(L, 2, typeof(xc.UnitID));
                    
                        Actor __cl_gen_ret = __cl_gen_to_be_invoked.GetActor( id );
                        translator.Push(L, __cl_gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
            return LuaAPI.luaL_error(L, "invalid arguments to xc.ActorManager.GetActor!");
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_GetPlayer(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            xc.ActorManager __cl_gen_to_be_invoked = (xc.ActorManager)translator.FastGetCSObj(L, 1);
            
            
            try {
                
                {
                    uint uid = LuaAPI.xlua_touint(L, 2);
                    
                        Actor __cl_gen_ret = __cl_gen_to_be_invoked.GetPlayer( uid );
                        translator.Push(L, __cl_gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_GetAvailableModelId_xlua_st_(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            
            try {
                
                {
                    byte actor_type = (byte)LuaAPI.lua_tonumber(L, 1);
                    
                        xc.UnitID __cl_gen_ret = xc.ActorManager.GetAvailableModelId( actor_type );
                        translator.Push(L, __cl_gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_UpdateLocalPlayerClientModels(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            xc.ActorManager __cl_gen_to_be_invoked = (xc.ActorManager)translator.FastGetCSObj(L, 1);
            
            
            try {
                
                {
                    
                    __cl_gen_to_be_invoked.UpdateLocalPlayerClientModels(  );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        
        
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_ActorSet(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.ActorManager __cl_gen_to_be_invoked = (xc.ActorManager)translator.FastGetCSObj(L, 1);
                translator.Push(L, __cl_gen_to_be_invoked.ActorSet);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_ClientModelSet(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.ActorManager __cl_gen_to_be_invoked = (xc.ActorManager)translator.FastGetCSObj(L, 1);
                translator.Push(L, __cl_gen_to_be_invoked.ClientModelSet);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_WorshipModelSet(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.ActorManager __cl_gen_to_be_invoked = (xc.ActorManager)translator.FastGetCSObj(L, 1);
                translator.Push(L, __cl_gen_to_be_invoked.WorshipModelSet);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_MonsterSet(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.ActorManager __cl_gen_to_be_invoked = (xc.ActorManager)translator.FastGetCSObj(L, 1);
                translator.Push(L, __cl_gen_to_be_invoked.MonsterSet);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_PetSet(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.ActorManager __cl_gen_to_be_invoked = (xc.ActorManager)translator.FastGetCSObj(L, 1);
                translator.Push(L, __cl_gen_to_be_invoked.PetSet);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_SummonMonsterSet(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.ActorManager __cl_gen_to_be_invoked = (xc.ActorManager)translator.FastGetCSObj(L, 1);
                translator.Push(L, __cl_gen_to_be_invoked.SummonMonsterSet);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_CalledMonsterSet(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.ActorManager __cl_gen_to_be_invoked = (xc.ActorManager)translator.FastGetCSObj(L, 1);
                translator.Push(L, __cl_gen_to_be_invoked.CalledMonsterSet);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_PlayerSet(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.ActorManager __cl_gen_to_be_invoked = (xc.ActorManager)translator.FastGetCSObj(L, 1);
                translator.Push(L, __cl_gen_to_be_invoked.PlayerSet);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_Instance(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			    translator.Push(L, xc.ActorManager.Instance);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_Instance(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			    xc.ActorManager.Instance = (xc.ActorManager)translator.GetObject(L, 1, typeof(xc.ActorManager));
            
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 0;
        }
        
		
		
		
		
    }
}
