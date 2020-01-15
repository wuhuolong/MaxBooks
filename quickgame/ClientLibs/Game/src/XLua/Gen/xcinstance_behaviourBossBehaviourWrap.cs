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
    public class xcinstance_behaviourBossBehaviourWrap
    {
        public static void __Register(RealStatePtr L)
        {
			ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			XUtils.BeginObjectRegister(typeof(xc.instance_behaviour.BossBehaviour), L, translator, 0, 11, 0, 0);
			
			XUtils.RegisterFunc(L, XUtils.METHOD_IDX, "Enter", _m_Enter);
			XUtils.RegisterFunc(L, XUtils.METHOD_IDX, "Exit", _m_Exit);
			XUtils.RegisterFunc(L, XUtils.METHOD_IDX, "OnMonsterDead", _m_OnMonsterDead);
			XUtils.RegisterFunc(L, XUtils.METHOD_IDX, "Clear", _m_Clear);
			XUtils.RegisterFunc(L, XUtils.METHOD_IDX, "ClearBossModels", _m_ClearBossModels);
			XUtils.RegisterFunc(L, XUtils.METHOD_IDX, "HandleServerData", _m_HandleServerData);
			XUtils.RegisterFunc(L, XUtils.METHOD_IDX, "UpdateInfo", _m_UpdateInfo);
			XUtils.RegisterFunc(L, XUtils.METHOD_IDX, "Update", _m_Update);
			XUtils.RegisterFunc(L, XUtils.METHOD_IDX, "UpdateModel", _m_UpdateModel);
			XUtils.RegisterFunc(L, XUtils.METHOD_IDX, "UpdateAffiliation", _m_UpdateAffiliation);
			XUtils.RegisterFunc(L, XUtils.METHOD_IDX, "IsAffiliation", _m_IsAffiliation);
			
			
			
			
			XUtils.EndObjectRegister(typeof(xc.instance_behaviour.BossBehaviour), L, translator, null, null,
			    null, null, null);

		    XUtils.BeginClassRegister(typeof(xc.instance_behaviour.BossBehaviour), L, __CreateInstance, 4, 2, 1);
			XUtils.RegisterFunc(L, XUtils.CLS_IDX, "GetPkgBossInfo", _m_GetPkgBossInfo_xlua_st_);
            XUtils.RegisterFunc(L, XUtils.CLS_IDX, "GetPkgBossInfoByActorId", _m_GetPkgBossInfoByActorId_xlua_st_);
            XUtils.RegisterFunc(L, XUtils.CLS_IDX, "GetPkgBossInfoBySceneId", _m_GetPkgBossInfoBySceneId_xlua_st_);
            
			
            
            XUtils.RegisterObject(L, translator, XUtils.CLS_IDX, "UnderlyingSystemType", typeof(xc.instance_behaviour.BossBehaviour));
			XUtils.RegisterFunc(L, XUtils.CLS_GETTER_IDX, "DataAffiliTimes", _g_get_DataAffiliTimes);
            XUtils.RegisterFunc(L, XUtils.CLS_GETTER_IDX, "mBossInfoAll", _g_get_mBossInfoAll);
            
			XUtils.RegisterFunc(L, XUtils.CLS_SETTER_IDX, "mBossInfoAll", _s_set_mBossInfoAll);
            
			XUtils.EndClassRegister(typeof(xc.instance_behaviour.BossBehaviour), L, translator);
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int __CreateInstance(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			try {
				if(LuaAPI.lua_gettop(L) == 1)
				{
					
					xc.instance_behaviour.BossBehaviour __cl_gen_ret = new xc.instance_behaviour.BossBehaviour();
					translator.Push(L, __cl_gen_ret);
					return 1;
				}
				
			}
			catch(System.Exception __gen_e) {
				return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
			}
            return LuaAPI.luaL_error(L, "invalid arguments to xc.instance_behaviour.BossBehaviour constructor!");
            
        }
        
		
        
		
        
        
        
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_Enter(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            xc.instance_behaviour.BossBehaviour __cl_gen_to_be_invoked = (xc.instance_behaviour.BossBehaviour)translator.FastGetCSObj(L, 1);
            
            
            try {
                
                {
                    object[] param = translator.GetParams<object>(L, 2);
                    
                    __cl_gen_to_be_invoked.Enter( param );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_Exit(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            xc.instance_behaviour.BossBehaviour __cl_gen_to_be_invoked = (xc.instance_behaviour.BossBehaviour)translator.FastGetCSObj(L, 1);
            
            
            try {
                
                {
                    
                    __cl_gen_to_be_invoked.Exit(  );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_OnMonsterDead(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            xc.instance_behaviour.BossBehaviour __cl_gen_to_be_invoked = (xc.instance_behaviour.BossBehaviour)translator.FastGetCSObj(L, 1);
            
            
            try {
                
                {
                    CEventBaseArgs data = (CEventBaseArgs)translator.GetObject(L, 2, typeof(CEventBaseArgs));
                    
                    __cl_gen_to_be_invoked.OnMonsterDead( data );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_Clear(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            xc.instance_behaviour.BossBehaviour __cl_gen_to_be_invoked = (xc.instance_behaviour.BossBehaviour)translator.FastGetCSObj(L, 1);
            
            
            try {
                
                {
                    
                    __cl_gen_to_be_invoked.Clear(  );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_ClearBossModels(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            xc.instance_behaviour.BossBehaviour __cl_gen_to_be_invoked = (xc.instance_behaviour.BossBehaviour)translator.FastGetCSObj(L, 1);
            
            
            try {
                
                {
                    
                    __cl_gen_to_be_invoked.ClearBossModels(  );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_HandleServerData(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            xc.instance_behaviour.BossBehaviour __cl_gen_to_be_invoked = (xc.instance_behaviour.BossBehaviour)translator.FastGetCSObj(L, 1);
            
            
            try {
                
                {
                    ushort protocol = (ushort)LuaAPI.xlua_tointeger(L, 2);
                    byte[] data = LuaAPI.lua_tobytes(L, 3);
                    
                    __cl_gen_to_be_invoked.HandleServerData( protocol, data );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_UpdateInfo(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            xc.instance_behaviour.BossBehaviour __cl_gen_to_be_invoked = (xc.instance_behaviour.BossBehaviour)translator.FastGetCSObj(L, 1);
            
            
            try {
                
                {
                    System.Collections.Generic.List<Net.PkgBossInfo> boss_list = (System.Collections.Generic.List<Net.PkgBossInfo>)translator.GetObject(L, 2, typeof(System.Collections.Generic.List<Net.PkgBossInfo>));
                    
                    __cl_gen_to_be_invoked.UpdateInfo( boss_list );
                    
                    
                    
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
            
            
            xc.instance_behaviour.BossBehaviour __cl_gen_to_be_invoked = (xc.instance_behaviour.BossBehaviour)translator.FastGetCSObj(L, 1);
            
            
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
        static int _m_UpdateModel(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            xc.instance_behaviour.BossBehaviour __cl_gen_to_be_invoked = (xc.instance_behaviour.BossBehaviour)translator.FastGetCSObj(L, 1);
            
            
            try {
                
                {
                    
                    __cl_gen_to_be_invoked.UpdateModel(  );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_UpdateAffiliation(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            xc.instance_behaviour.BossBehaviour __cl_gen_to_be_invoked = (xc.instance_behaviour.BossBehaviour)translator.FastGetCSObj(L, 1);
            
            
            try {
                
                {
                    System.Collections.Generic.List<xc.instance_behaviour.BossBehaviour.UpdateBossAffiItem> item_array = (System.Collections.Generic.List<xc.instance_behaviour.BossBehaviour.UpdateBossAffiItem>)translator.GetObject(L, 2, typeof(System.Collections.Generic.List<xc.instance_behaviour.BossBehaviour.UpdateBossAffiItem>));
                    
                    __cl_gen_to_be_invoked.UpdateAffiliation( item_array );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_IsAffiliation(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            xc.instance_behaviour.BossBehaviour __cl_gen_to_be_invoked = (xc.instance_behaviour.BossBehaviour)translator.FastGetCSObj(L, 1);
            
            
			int __gen_param_count = LuaAPI.lua_gettop(L);
            
            try {
                if(__gen_param_count == 3&& LuaTypes.LUA_TNUMBER == LuaAPI.lua_type(L, 2)&& LuaTypes.LUA_TNUMBER == LuaAPI.lua_type(L, 3)) 
                {
                    uint uuid = LuaAPI.xlua_touint(L, 2);
                    uint teamId = LuaAPI.xlua_touint(L, 3);
                    
                        bool __cl_gen_ret = __cl_gen_to_be_invoked.IsAffiliation( uuid, teamId );
                        LuaAPI.lua_pushboolean(L, __cl_gen_ret);
                    
                    
                    
                    return 1;
                }
                if(__gen_param_count == 2&& translator.Assignable<Actor>(L, 2)) 
                {
                    Actor actor = (Actor)translator.GetObject(L, 2, typeof(Actor));
                    
                        bool __cl_gen_ret = __cl_gen_to_be_invoked.IsAffiliation( actor );
                        LuaAPI.lua_pushboolean(L, __cl_gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
            return LuaAPI.luaL_error(L, "invalid arguments to xc.instance_behaviour.BossBehaviour.IsAffiliation!");
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_GetPkgBossInfo_xlua_st_(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            
            try {
                
                {
                    uint special_id = LuaAPI.xlua_touint(L, 1);
                    
                        xc.instance_behaviour.BossBehaviour.RedefineBossInfo __cl_gen_ret = xc.instance_behaviour.BossBehaviour.GetPkgBossInfo( special_id );
                        translator.Push(L, __cl_gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_GetPkgBossInfoByActorId_xlua_st_(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            
            try {
                
                {
                    uint actor_id = LuaAPI.xlua_touint(L, 1);
                    
                        xc.instance_behaviour.BossBehaviour.RedefineBossInfo __cl_gen_ret = xc.instance_behaviour.BossBehaviour.GetPkgBossInfoByActorId( actor_id );
                        translator.Push(L, __cl_gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_GetPkgBossInfoBySceneId_xlua_st_(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            
            try {
                
                {
                    uint scene_id = LuaAPI.xlua_touint(L, 1);
                    
                        System.Collections.Generic.List<xc.instance_behaviour.BossBehaviour.RedefineBossInfo> __cl_gen_ret = xc.instance_behaviour.BossBehaviour.GetPkgBossInfoBySceneId( scene_id );
                        translator.Push(L, __cl_gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        
        
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_DataAffiliTimes(RealStatePtr L)
        {
            
            try {
			    LuaAPI.xlua_pushuint(L, xc.instance_behaviour.BossBehaviour.DataAffiliTimes);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_mBossInfoAll(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			    translator.Push(L, xc.instance_behaviour.BossBehaviour.mBossInfoAll);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_mBossInfoAll(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			    xc.instance_behaviour.BossBehaviour.mBossInfoAll = (System.Collections.Generic.List<xc.instance_behaviour.BossBehaviour.RedefineBossInfo>)translator.GetObject(L, 1, typeof(System.Collections.Generic.List<xc.instance_behaviour.BossBehaviour.RedefineBossInfo>));
            
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 0;
        }
        
		
		
		
		
    }
}
