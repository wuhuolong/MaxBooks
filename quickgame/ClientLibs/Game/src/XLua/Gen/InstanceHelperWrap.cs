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
    public class InstanceHelperWrap
    {
        public static void __Register(RealStatePtr L)
        {
			ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			XUtils.BeginObjectRegister(typeof(InstanceHelper), L, translator, 0, 0, 0, 0);
			
			
			
			
			
			XUtils.EndObjectRegister(typeof(InstanceHelper), L, translator, null, null,
			    null, null, null);

		    XUtils.BeginClassRegister(typeof(InstanceHelper), L, __CreateInstance, 37, 0, 0);
			XUtils.RegisterFunc(L, XUtils.CLS_IDX, "Vote", _m_Vote_xlua_st_);
            XUtils.RegisterFunc(L, XUtils.CLS_IDX, "HastenVote", _m_HastenVote_xlua_st_);
            XUtils.RegisterFunc(L, XUtils.CLS_IDX, "JumpToInstance", _m_JumpToInstance_xlua_st_);
            XUtils.RegisterFunc(L, XUtils.CLS_IDX, "EnterKungFuGod", _m_EnterKungFuGod_xlua_st_);
            XUtils.RegisterFunc(L, XUtils.CLS_IDX, "EnterDeadSpace", _m_EnterDeadSpace_xlua_st_);
            XUtils.RegisterFunc(L, XUtils.CLS_IDX, "EnterWorshipMeeting", _m_EnterWorshipMeeting_xlua_st_);
            XUtils.RegisterFunc(L, XUtils.CLS_IDX, "EnterGuildManor", _m_EnterGuildManor_xlua_st_);
            XUtils.RegisterFunc(L, XUtils.CLS_IDX, "EnterGuildRainRedPacket", _m_EnterGuildRainRedPacket_xlua_st_);
            XUtils.RegisterFunc(L, XUtils.CLS_IDX, "EnterCorsair", _m_EnterCorsair_xlua_st_);
            XUtils.RegisterFunc(L, XUtils.CLS_IDX, "EnterGuildBoss", _m_EnterGuildBoss_xlua_st_);
            XUtils.RegisterFunc(L, XUtils.CLS_IDX, "EnterGuildLeague", _m_EnterGuildLeague_xlua_st_);
            XUtils.RegisterFunc(L, XUtils.CLS_IDX, "EnterWeddingInstance", _m_EnterWeddingInstance_xlua_st_);
            XUtils.RegisterFunc(L, XUtils.CLS_IDX, "UseDrugInInstance", _m_UseDrugInInstance_xlua_st_);
            XUtils.RegisterFunc(L, XUtils.CLS_IDX, "FindAvailableWalkablePos", _m_FindAvailableWalkablePos_xlua_st_);
            XUtils.RegisterFunc(L, XUtils.CLS_IDX, "ClampInWalkableRange", _m_ClampInWalkableRange_xlua_st_);
            XUtils.RegisterFunc(L, XUtils.CLS_IDX, "GetKungfuGodInstanceId", _m_GetKungfuGodInstanceId_xlua_st_);
            XUtils.RegisterFunc(L, XUtils.CLS_IDX, "GetKungfuGodInstanceName", _m_GetKungfuGodInstanceName_xlua_st_);
            XUtils.RegisterFunc(L, XUtils.CLS_IDX, "GetKungfuGodReward", _m_GetKungfuGodReward_xlua_st_);
            XUtils.RegisterFunc(L, XUtils.CLS_IDX, "GetInstanceDifficultyName", _m_GetInstanceDifficultyName_xlua_st_);
            XUtils.RegisterFunc(L, XUtils.CLS_IDX, "CanWalkTo", _m_CanWalkTo_xlua_st_);
            XUtils.RegisterFunc(L, XUtils.CLS_IDX, "GetAutoRunnerTargetLocation", _m_GetAutoRunnerTargetLocation_xlua_st_);
            XUtils.RegisterFunc(L, XUtils.CLS_IDX, "InstanceIsInPlay", _m_InstanceIsInPlay_xlua_st_);
            XUtils.RegisterFunc(L, XUtils.CLS_IDX, "InstanceIsInCave", _m_InstanceIsInCave_xlua_st_);
            XUtils.RegisterFunc(L, XUtils.CLS_IDX, "ExitInstance", _m_ExitInstance_xlua_st_);
            XUtils.RegisterFunc(L, XUtils.CLS_IDX, "CompleteInstance", _m_CompleteInstance_xlua_st_);
            XUtils.RegisterFunc(L, XUtils.CLS_IDX, "PauseInstance", _m_PauseInstance_xlua_st_);
            XUtils.RegisterFunc(L, XUtils.CLS_IDX, "ResumeInstance", _m_ResumeInstance_xlua_st_);
            XUtils.RegisterFunc(L, XUtils.CLS_IDX, "InstanceIsInState", _m_InstanceIsInState_xlua_st_);
            XUtils.RegisterFunc(L, XUtils.CLS_IDX, "GetMonsters", _m_GetMonsters_xlua_st_);
            XUtils.RegisterFunc(L, XUtils.CLS_IDX, "GetInstanceNeedRoleLevel", _m_GetInstanceNeedRoleLevel_xlua_st_);
            XUtils.RegisterFunc(L, XUtils.CLS_IDX, "GetInstanceName", _m_GetInstanceName_xlua_st_);
            XUtils.RegisterFunc(L, XUtils.CLS_IDX, "IsNeedShowRuneTips", _m_IsNeedShowRuneTips_xlua_st_);
            XUtils.RegisterFunc(L, XUtils.CLS_IDX, "CheckInstanceEnterAttrs", _m_CheckInstanceEnterAttrs_xlua_st_);
            XUtils.RegisterFunc(L, XUtils.CLS_IDX, "IsGuardedNpc", _m_IsGuardedNpc_xlua_st_);
            XUtils.RegisterFunc(L, XUtils.CLS_IDX, "IsJumpingOut", _m_IsJumpingOut_xlua_st_);
            XUtils.RegisterFunc(L, XUtils.CLS_IDX, "IsAffiliation", _m_IsAffiliation_xlua_st_);
            
			
            
            XUtils.RegisterObject(L, translator, XUtils.CLS_IDX, "UnderlyingSystemType", typeof(InstanceHelper));
			
			
			XUtils.EndClassRegister(typeof(InstanceHelper), L, translator);
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int __CreateInstance(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			try {
				if(LuaAPI.lua_gettop(L) == 1)
				{
					
					InstanceHelper __cl_gen_ret = new InstanceHelper();
					translator.Push(L, __cl_gen_ret);
					return 1;
				}
				
			}
			catch(System.Exception __gen_e) {
				return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
			}
            return LuaAPI.luaL_error(L, "invalid arguments to InstanceHelper constructor!");
            
        }
        
		
        
		
        
        
        
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_Vote_xlua_st_(RealStatePtr L)
        {
            
            
            
			int __gen_param_count = LuaAPI.lua_gettop(L);
            
            try {
                if(__gen_param_count == 2&& LuaTypes.LUA_TNUMBER == LuaAPI.lua_type(L, 1)&& LuaTypes.LUA_TNUMBER == LuaAPI.lua_type(L, 2)) 
                {
                    uint vote = LuaAPI.xlua_touint(L, 1);
                    uint reason = LuaAPI.xlua_touint(L, 2);
                    
                    InstanceHelper.Vote( vote, reason );
                    
                    
                    
                    return 0;
                }
                if(__gen_param_count == 1&& LuaTypes.LUA_TNUMBER == LuaAPI.lua_type(L, 1)) 
                {
                    uint vote = LuaAPI.xlua_touint(L, 1);
                    
                    InstanceHelper.Vote( vote );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
            return LuaAPI.luaL_error(L, "invalid arguments to InstanceHelper.Vote!");
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_HastenVote_xlua_st_(RealStatePtr L)
        {
            
            
            
            try {
                
                {
                    uint instanceId = LuaAPI.xlua_touint(L, 1);
                    
                    InstanceHelper.HastenVote( instanceId );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_JumpToInstance_xlua_st_(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            
            try {
                
                {
                    uint id = LuaAPI.xlua_touint(L, 1);
                    uint warType = LuaAPI.xlua_touint(L, 2);
                    uint warSubType = LuaAPI.xlua_touint(L, 3);
                    System.Action sendJumpFunc = translator.GetDelegate<System.Action>(L, 4);
                    
                    InstanceHelper.JumpToInstance( id, warType, warSubType, sendJumpFunc );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_EnterKungFuGod_xlua_st_(RealStatePtr L)
        {
            
            
            
            try {
                
                {
                    
                    InstanceHelper.EnterKungFuGod(  );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_EnterDeadSpace_xlua_st_(RealStatePtr L)
        {
            
            
            
            try {
                
                {
                    
                    InstanceHelper.EnterDeadSpace(  );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_EnterWorshipMeeting_xlua_st_(RealStatePtr L)
        {
            
            
            
            try {
                
                {
                    
                    InstanceHelper.EnterWorshipMeeting(  );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_EnterGuildManor_xlua_st_(RealStatePtr L)
        {
            
            
            
			int __gen_param_count = LuaAPI.lua_gettop(L);
            
            try {
                if(__gen_param_count == 1&& LuaTypes.LUA_TBOOLEAN == LuaAPI.lua_type(L, 1)) 
                {
                    bool playJumpOutAnimation = LuaAPI.lua_toboolean(L, 1);
                    
                    InstanceHelper.EnterGuildManor( playJumpOutAnimation );
                    
                    
                    
                    return 0;
                }
                if(__gen_param_count == 0) 
                {
                    
                    InstanceHelper.EnterGuildManor(  );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
            return LuaAPI.luaL_error(L, "invalid arguments to InstanceHelper.EnterGuildManor!");
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_EnterGuildRainRedPacket_xlua_st_(RealStatePtr L)
        {
            
            
            
			int __gen_param_count = LuaAPI.lua_gettop(L);
            
            try {
                if(__gen_param_count == 1&& LuaTypes.LUA_TBOOLEAN == LuaAPI.lua_type(L, 1)) 
                {
                    bool playJumpOutAnimation = LuaAPI.lua_toboolean(L, 1);
                    
                    InstanceHelper.EnterGuildRainRedPacket( playJumpOutAnimation );
                    
                    
                    
                    return 0;
                }
                if(__gen_param_count == 0) 
                {
                    
                    InstanceHelper.EnterGuildRainRedPacket(  );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
            return LuaAPI.luaL_error(L, "invalid arguments to InstanceHelper.EnterGuildRainRedPacket!");
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_EnterCorsair_xlua_st_(RealStatePtr L)
        {
            
            
            
            try {
                
                {
                    uint type = LuaAPI.xlua_touint(L, 1);
                    
                    InstanceHelper.EnterCorsair( type );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_EnterGuildBoss_xlua_st_(RealStatePtr L)
        {
            
            
            
            try {
                
                {
                    
                    InstanceHelper.EnterGuildBoss(  );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_EnterGuildLeague_xlua_st_(RealStatePtr L)
        {
            
            
            
            try {
                
                {
                    
                    InstanceHelper.EnterGuildLeague(  );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_EnterWeddingInstance_xlua_st_(RealStatePtr L)
        {
            
            
            
            try {
                
                {
                    
                    InstanceHelper.EnterWeddingInstance(  );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_UseDrugInInstance_xlua_st_(RealStatePtr L)
        {
            
            
            
            try {
                
                {
                    
                    InstanceHelper.UseDrugInInstance(  );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_FindAvailableWalkablePos_xlua_st_(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            
            try {
                
                {
                    UnityEngine.Vector3 center;translator.Get(L, 1, out center);
                    float radius = (float)LuaAPI.lua_tonumber(L, 2);
                    
                        UnityEngine.Vector3 __cl_gen_ret = InstanceHelper.FindAvailableWalkablePos( center, radius );
                        translator.PushUnityEngineVector3(L, __cl_gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_ClampInWalkableRange_xlua_st_(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            
			int __gen_param_count = LuaAPI.lua_gettop(L);
            
            try {
                if(__gen_param_count == 2&& translator.Assignable<UnityEngine.Vector3>(L, 1)&& LuaTypes.LUA_TNUMBER == LuaAPI.lua_type(L, 2)) 
                {
                    UnityEngine.Vector3 raw;translator.Get(L, 1, out raw);
                    float maxDistance = (float)LuaAPI.lua_tonumber(L, 2);
                    
                        UnityEngine.Vector3 __cl_gen_ret = InstanceHelper.ClampInWalkableRange( raw, maxDistance );
                        translator.PushUnityEngineVector3(L, __cl_gen_ret);
                    
                    
                    
                    return 1;
                }
                if(__gen_param_count == 1&& translator.Assignable<UnityEngine.Vector3>(L, 1)) 
                {
                    UnityEngine.Vector3 raw;translator.Get(L, 1, out raw);
                    
                        UnityEngine.Vector3 __cl_gen_ret = InstanceHelper.ClampInWalkableRange( raw );
                        translator.PushUnityEngineVector3(L, __cl_gen_ret);
                    
                    
                    
                    return 1;
                }
                if(__gen_param_count == 3&& translator.Assignable<UnityEngine.Vector3>(L, 1)&& translator.Assignable<UnityEngine.Vector3>(L, 2)&& LuaTypes.LUA_TNUMBER == LuaAPI.lua_type(L, 3)) 
                {
                    UnityEngine.Vector3 raw;translator.Get(L, 1, out raw);
                    UnityEngine.Vector3 defaultPos;translator.Get(L, 2, out defaultPos);
                    float maxDistance = (float)LuaAPI.lua_tonumber(L, 3);
                    
                        UnityEngine.Vector3 __cl_gen_ret = InstanceHelper.ClampInWalkableRange( raw, defaultPos, maxDistance );
                        translator.PushUnityEngineVector3(L, __cl_gen_ret);
                    
                    
                    
                    return 1;
                }
                if(__gen_param_count == 2&& translator.Assignable<UnityEngine.Vector3>(L, 1)&& translator.Assignable<UnityEngine.Vector3>(L, 2)) 
                {
                    UnityEngine.Vector3 raw;translator.Get(L, 1, out raw);
                    UnityEngine.Vector3 defaultPos;translator.Get(L, 2, out defaultPos);
                    
                        UnityEngine.Vector3 __cl_gen_ret = InstanceHelper.ClampInWalkableRange( raw, defaultPos );
                        translator.PushUnityEngineVector3(L, __cl_gen_ret);
                    
                    
                    
                    return 1;
                }
                if(__gen_param_count == 3&& translator.Assignable<UnityEngine.Vector3>(L, 1)&& translator.Assignable<UnityEngine.Vector3>(L, 2)&& LuaTypes.LUA_TNUMBER == LuaAPI.lua_type(L, 3)) 
                {
                    UnityEngine.Vector3 raw;translator.Get(L, 1, out raw);
                    UnityEngine.Vector3 defaultPos;translator.Get(L, 2, out defaultPos);
                    bool result;
                    float maxDistance = (float)LuaAPI.lua_tonumber(L, 3);
                    
                        UnityEngine.Vector3 __cl_gen_ret = InstanceHelper.ClampInWalkableRange( raw, defaultPos, out result, maxDistance );
                        translator.PushUnityEngineVector3(L, __cl_gen_ret);
                    LuaAPI.lua_pushboolean(L, result);
                        
                    
                    
                    
                    return 2;
                }
                if(__gen_param_count == 2&& translator.Assignable<UnityEngine.Vector3>(L, 1)&& translator.Assignable<UnityEngine.Vector3>(L, 2)) 
                {
                    UnityEngine.Vector3 raw;translator.Get(L, 1, out raw);
                    UnityEngine.Vector3 defaultPos;translator.Get(L, 2, out defaultPos);
                    bool result;
                    
                        UnityEngine.Vector3 __cl_gen_ret = InstanceHelper.ClampInWalkableRange( raw, defaultPos, out result );
                        translator.PushUnityEngineVector3(L, __cl_gen_ret);
                    LuaAPI.lua_pushboolean(L, result);
                        
                    
                    
                    
                    return 2;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
            return LuaAPI.luaL_error(L, "invalid arguments to InstanceHelper.ClampInWalkableRange!");
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_GetKungfuGodInstanceId_xlua_st_(RealStatePtr L)
        {
            
            
            
            try {
                
                {
                    uint id = LuaAPI.xlua_touint(L, 1);
                    
                        uint __cl_gen_ret = InstanceHelper.GetKungfuGodInstanceId( id );
                        LuaAPI.xlua_pushuint(L, __cl_gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_GetKungfuGodInstanceName_xlua_st_(RealStatePtr L)
        {
            
            
            
            try {
                
                {
                    uint id = LuaAPI.xlua_touint(L, 1);
                    
                        string __cl_gen_ret = InstanceHelper.GetKungfuGodInstanceName( id );
                        LuaAPI.lua_pushstring(L, __cl_gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_GetKungfuGodReward_xlua_st_(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            
            try {
                
                {
                    uint id = LuaAPI.xlua_touint(L, 1);
                    
                        System.Collections.Generic.List<xc.Goods> __cl_gen_ret = InstanceHelper.GetKungfuGodReward( id );
                        translator.Push(L, __cl_gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_GetInstanceDifficultyName_xlua_st_(RealStatePtr L)
        {
            
            
            
            try {
                
                {
                    uint instanceDifficulty = LuaAPI.xlua_touint(L, 1);
                    
                        string __cl_gen_ret = InstanceHelper.GetInstanceDifficultyName( instanceDifficulty );
                        LuaAPI.lua_pushstring(L, __cl_gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_CanWalkTo_xlua_st_(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            
            try {
                
                {
                    UnityEngine.Vector3 dst;translator.Get(L, 1, out dst);
                    
                        bool __cl_gen_ret = InstanceHelper.CanWalkTo( dst );
                        LuaAPI.lua_pushboolean(L, __cl_gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_GetAutoRunnerTargetLocation_xlua_st_(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            
            try {
                
                {
                    
                        UnityEngine.Vector3 __cl_gen_ret = InstanceHelper.GetAutoRunnerTargetLocation(  );
                        translator.PushUnityEngineVector3(L, __cl_gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_InstanceIsInPlay_xlua_st_(RealStatePtr L)
        {
            
            
            
            try {
                
                {
                    
                        bool __cl_gen_ret = InstanceHelper.InstanceIsInPlay(  );
                        LuaAPI.lua_pushboolean(L, __cl_gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_InstanceIsInCave_xlua_st_(RealStatePtr L)
        {
            
            
            
            try {
                
                {
                    
                        bool __cl_gen_ret = InstanceHelper.InstanceIsInCave(  );
                        LuaAPI.lua_pushboolean(L, __cl_gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_ExitInstance_xlua_st_(RealStatePtr L)
        {
            
            
            
            try {
                
                {
                    
                    InstanceHelper.ExitInstance(  );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_CompleteInstance_xlua_st_(RealStatePtr L)
        {
            
            
            
            try {
                
                {
                    
                    InstanceHelper.CompleteInstance(  );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_PauseInstance_xlua_st_(RealStatePtr L)
        {
            
            
            
            try {
                
                {
                    
                    InstanceHelper.PauseInstance(  );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_ResumeInstance_xlua_st_(RealStatePtr L)
        {
            
            
            
            try {
                
                {
                    
                    InstanceHelper.ResumeInstance(  );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_InstanceIsInState_xlua_st_(RealStatePtr L)
        {
            
            
            
            try {
                
                {
                    uint state = LuaAPI.xlua_touint(L, 1);
                    
                        bool __cl_gen_ret = InstanceHelper.InstanceIsInState( state );
                        LuaAPI.lua_pushboolean(L, __cl_gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_GetMonsters_xlua_st_(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            
            try {
                
                {
                    uint actorId = LuaAPI.xlua_touint(L, 1);
                    
                        System.Collections.Generic.List<Actor> __cl_gen_ret = InstanceHelper.GetMonsters( actorId );
                        translator.Push(L, __cl_gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_GetInstanceNeedRoleLevel_xlua_st_(RealStatePtr L)
        {
            
            
            
            try {
                
                {
                    uint instanceId = LuaAPI.xlua_touint(L, 1);
                    
                        uint __cl_gen_ret = InstanceHelper.GetInstanceNeedRoleLevel( instanceId );
                        LuaAPI.xlua_pushuint(L, __cl_gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_GetInstanceName_xlua_st_(RealStatePtr L)
        {
            
            
            
            try {
                
                {
                    uint instanceId = LuaAPI.xlua_touint(L, 1);
                    
                        string __cl_gen_ret = InstanceHelper.GetInstanceName( instanceId );
                        LuaAPI.lua_pushstring(L, __cl_gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_IsNeedShowRuneTips_xlua_st_(RealStatePtr L)
        {
            
            
            
            try {
                
                {
                    uint id = LuaAPI.xlua_touint(L, 1);
                    
                        bool __cl_gen_ret = InstanceHelper.IsNeedShowRuneTips( id );
                        LuaAPI.lua_pushboolean(L, __cl_gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_CheckInstanceEnterAttrs_xlua_st_(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            
            try {
                
                {
                    xc.DBInstance.InstanceInfo instanceInfo = (xc.DBInstance.InstanceInfo)translator.GetObject(L, 1, typeof(xc.DBInstance.InstanceInfo));
                    
                        bool __cl_gen_ret = InstanceHelper.CheckInstanceEnterAttrs( instanceInfo );
                        LuaAPI.lua_pushboolean(L, __cl_gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_IsGuardedNpc_xlua_st_(RealStatePtr L)
        {
            
            
            
			int __gen_param_count = LuaAPI.lua_gettop(L);
            
            try {
                if(__gen_param_count == 1&& LuaTypes.LUA_TNUMBER == LuaAPI.lua_type(L, 1)) 
                {
                    uint actorId = LuaAPI.xlua_touint(L, 1);
                    
                        bool __cl_gen_ret = InstanceHelper.IsGuardedNpc( actorId );
                        LuaAPI.lua_pushboolean(L, __cl_gen_ret);
                    
                    
                    
                    return 1;
                }
                if(__gen_param_count == 2&& LuaTypes.LUA_TNUMBER == LuaAPI.lua_type(L, 1)&& LuaTypes.LUA_TNUMBER == LuaAPI.lua_type(L, 2)) 
                {
                    uint actorId = LuaAPI.xlua_touint(L, 1);
                    uint instanceId = LuaAPI.xlua_touint(L, 2);
                    
                        bool __cl_gen_ret = InstanceHelper.IsGuardedNpc( actorId, instanceId );
                        LuaAPI.lua_pushboolean(L, __cl_gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
            return LuaAPI.luaL_error(L, "invalid arguments to InstanceHelper.IsGuardedNpc!");
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_IsJumpingOut_xlua_st_(RealStatePtr L)
        {
            
            
            
            try {
                
                {
                    
                        bool __cl_gen_ret = InstanceHelper.IsJumpingOut(  );
                        LuaAPI.lua_pushboolean(L, __cl_gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_IsAffiliation_xlua_st_(RealStatePtr L)
        {
            
            
            
            try {
                
                {
                    uint uuid = LuaAPI.xlua_touint(L, 1);
                    uint teamId = LuaAPI.xlua_touint(L, 2);
                    
                        bool __cl_gen_ret = InstanceHelper.IsAffiliation( uuid, teamId );
                        LuaAPI.lua_pushboolean(L, __cl_gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        
        
        
        
        
		
		
		
		
    }
}
