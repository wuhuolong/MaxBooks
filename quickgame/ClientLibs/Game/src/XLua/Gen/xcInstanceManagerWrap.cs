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
    public class xcInstanceManagerWrap
    {
        public static void __Register(RealStatePtr L)
        {
			ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			XUtils.BeginObjectRegister(typeof(xc.InstanceManager), L, translator, 0, 11, 27, 23);
			
			XUtils.RegisterFunc(L, XUtils.METHOD_IDX, "SetInCastingReadyStage", _m_SetInCastingReadyStage);
			XUtils.RegisterFunc(L, XUtils.METHOD_IDX, "Reset", _m_Reset);
			XUtils.RegisterFunc(L, XUtils.METHOD_IDX, "ResetInstanceData", _m_ResetInstanceData);
			XUtils.RegisterFunc(L, XUtils.METHOD_IDX, "RegisterAllMessages", _m_RegisterAllMessages);
			XUtils.RegisterFunc(L, XUtils.METHOD_IDX, "Update", _m_Update);
			XUtils.RegisterFunc(L, XUtils.METHOD_IDX, "PauseAutoFighting", _m_PauseAutoFighting);
			XUtils.RegisterFunc(L, XUtils.METHOD_IDX, "SetOnHook", _m_SetOnHook);
			XUtils.RegisterFunc(L, XUtils.METHOD_IDX, "SetAutoFightingTargetMonsterId", _m_SetAutoFightingTargetMonsterId);
			XUtils.RegisterFunc(L, XUtils.METHOD_IDX, "SetIsAutoFightingOutsideInstance", _m_SetIsAutoFightingOutsideInstance);
			XUtils.RegisterFunc(L, XUtils.METHOD_IDX, "InitPollInfo", _m_InitPollInfo);
			XUtils.RegisterFunc(L, XUtils.METHOD_IDX, "GetVote", _m_GetVote);
			
			
			XUtils.RegisterFunc(L, XUtils.GETTER_IDX, "InstanceCostTime", _g_get_InstanceCostTime);
            XUtils.RegisterFunc(L, XUtils.GETTER_IDX, "ReviveLayer", _g_get_ReviveLayer);
            XUtils.RegisterFunc(L, XUtils.GETTER_IDX, "IsOnHook", _g_get_IsOnHook);
            XUtils.RegisterFunc(L, XUtils.GETTER_IDX, "IsInCastingReadyStage", _g_get_IsInCastingReadyStage);
            XUtils.RegisterFunc(L, XUtils.GETTER_IDX, "InCastingReadyStageMaxInterval", _g_get_InCastingReadyStageMaxInterval);
            XUtils.RegisterFunc(L, XUtils.GETTER_IDX, "KillPieceNum", _g_get_KillPieceNum);
            XUtils.RegisterFunc(L, XUtils.GETTER_IDX, "DogHeadScore", _g_get_DogHeadScore);
            XUtils.RegisterFunc(L, XUtils.GETTER_IDX, "DeadSpaceScore", _g_get_DeadSpaceScore);
            XUtils.RegisterFunc(L, XUtils.GETTER_IDX, "FairyValleyInfo", _g_get_FairyValleyInfo);
            XUtils.RegisterFunc(L, XUtils.GETTER_IDX, "FairyValleyExpRecord", _g_get_FairyValleyExpRecord);
            XUtils.RegisterFunc(L, XUtils.GETTER_IDX, "FairyValleyInspireNum1", _g_get_FairyValleyInspireNum1);
            XUtils.RegisterFunc(L, XUtils.GETTER_IDX, "FairyValleyInspireNum2", _g_get_FairyValleyInspireNum2);
            XUtils.RegisterFunc(L, XUtils.GETTER_IDX, "PollInfo", _g_get_PollInfo);
            XUtils.RegisterFunc(L, XUtils.GETTER_IDX, "PollStartTime", _g_get_PollStartTime);
            XUtils.RegisterFunc(L, XUtils.GETTER_IDX, "InstancePhase", _g_get_InstancePhase);
            XUtils.RegisterFunc(L, XUtils.GETTER_IDX, "InstancePhaseStartTime", _g_get_InstancePhaseStartTime);
            XUtils.RegisterFunc(L, XUtils.GETTER_IDX, "InstancePhaseProgress", _g_get_InstancePhaseProgress);
            XUtils.RegisterFunc(L, XUtils.GETTER_IDX, "InstanceMark", _g_get_InstanceMark);
            XUtils.RegisterFunc(L, XUtils.GETTER_IDX, "InstanceInfo", _g_get_InstanceInfo);
            XUtils.RegisterFunc(L, XUtils.GETTER_IDX, "MapInfo", _g_get_MapInfo);
            XUtils.RegisterFunc(L, XUtils.GETTER_IDX, "InstanceType", _g_get_InstanceType);
            XUtils.RegisterFunc(L, XUtils.GETTER_IDX, "InstanceSubType", _g_get_InstanceSubType);
            XUtils.RegisterFunc(L, XUtils.GETTER_IDX, "IsPlayerVSPlayerType", _g_get_IsPlayerVSPlayerType);
            XUtils.RegisterFunc(L, XUtils.GETTER_IDX, "IsAutoFighting", _g_get_IsAutoFighting);
            XUtils.RegisterFunc(L, XUtils.GETTER_IDX, "InstanceOpenState", _g_get_InstanceOpenState);
            XUtils.RegisterFunc(L, XUtils.GETTER_IDX, "KunfuGodId", _g_get_KunfuGodId);
            XUtils.RegisterFunc(L, XUtils.GETTER_IDX, "KunfuGodShowRunesTipsCache", _g_get_KunfuGodShowRunesTipsCache);
            
			XUtils.RegisterFunc(L, XUtils.SETTER_IDX, "InstanceCostTime", _s_set_InstanceCostTime);
            XUtils.RegisterFunc(L, XUtils.SETTER_IDX, "ReviveLayer", _s_set_ReviveLayer);
            XUtils.RegisterFunc(L, XUtils.SETTER_IDX, "IsShowAutoFightingGotExp", _s_set_IsShowAutoFightingGotExp);
            XUtils.RegisterFunc(L, XUtils.SETTER_IDX, "IsOnHook", _s_set_IsOnHook);
            XUtils.RegisterFunc(L, XUtils.SETTER_IDX, "KillPieceNum", _s_set_KillPieceNum);
            XUtils.RegisterFunc(L, XUtils.SETTER_IDX, "DogHeadScore", _s_set_DogHeadScore);
            XUtils.RegisterFunc(L, XUtils.SETTER_IDX, "DeadSpaceScore", _s_set_DeadSpaceScore);
            XUtils.RegisterFunc(L, XUtils.SETTER_IDX, "FairyValleyInfo", _s_set_FairyValleyInfo);
            XUtils.RegisterFunc(L, XUtils.SETTER_IDX, "FairyValleyExpRecord", _s_set_FairyValleyExpRecord);
            XUtils.RegisterFunc(L, XUtils.SETTER_IDX, "FairyValleyInspireNum1", _s_set_FairyValleyInspireNum1);
            XUtils.RegisterFunc(L, XUtils.SETTER_IDX, "FairyValleyInspireNum2", _s_set_FairyValleyInspireNum2);
            XUtils.RegisterFunc(L, XUtils.SETTER_IDX, "PollInfo", _s_set_PollInfo);
            XUtils.RegisterFunc(L, XUtils.SETTER_IDX, "PollStartTime", _s_set_PollStartTime);
            XUtils.RegisterFunc(L, XUtils.SETTER_IDX, "InstancePhase", _s_set_InstancePhase);
            XUtils.RegisterFunc(L, XUtils.SETTER_IDX, "InstancePhaseStartTime", _s_set_InstancePhaseStartTime);
            XUtils.RegisterFunc(L, XUtils.SETTER_IDX, "InstancePhaseProgress", _s_set_InstancePhaseProgress);
            XUtils.RegisterFunc(L, XUtils.SETTER_IDX, "InstanceMark", _s_set_InstanceMark);
            XUtils.RegisterFunc(L, XUtils.SETTER_IDX, "InstanceInfo", _s_set_InstanceInfo);
            XUtils.RegisterFunc(L, XUtils.SETTER_IDX, "MapInfo", _s_set_MapInfo);
            XUtils.RegisterFunc(L, XUtils.SETTER_IDX, "IsAutoFighting", _s_set_IsAutoFighting);
            XUtils.RegisterFunc(L, XUtils.SETTER_IDX, "InstanceOpenState", _s_set_InstanceOpenState);
            XUtils.RegisterFunc(L, XUtils.SETTER_IDX, "KunfuGodId", _s_set_KunfuGodId);
            XUtils.RegisterFunc(L, XUtils.SETTER_IDX, "KunfuGodShowRunesTipsCache", _s_set_KunfuGodShowRunesTipsCache);
            
			XUtils.EndObjectRegister(typeof(xc.InstanceManager), L, translator, null, null,
			    null, null, null);

		    XUtils.BeginClassRegister(typeof(xc.InstanceManager), L, __CreateInstance, 1, 0, 0);
			
			
            
            XUtils.RegisterObject(L, translator, XUtils.CLS_IDX, "UnderlyingSystemType", typeof(xc.InstanceManager));
			
			
			XUtils.EndClassRegister(typeof(xc.InstanceManager), L, translator);
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int __CreateInstance(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			try {
				if(LuaAPI.lua_gettop(L) == 1)
				{
					
					xc.InstanceManager __cl_gen_ret = new xc.InstanceManager();
					translator.Push(L, __cl_gen_ret);
					return 1;
				}
				
			}
			catch(System.Exception __gen_e) {
				return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
			}
            return LuaAPI.luaL_error(L, "invalid arguments to xc.InstanceManager constructor!");
            
        }
        
		
        
		
        
        
        
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_SetInCastingReadyStage(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            xc.InstanceManager __cl_gen_to_be_invoked = (xc.InstanceManager)translator.FastGetCSObj(L, 1);
            
            
            try {
                
                {
                    bool var_isInCastingReadyStage = LuaAPI.lua_toboolean(L, 2);
                    float max_castingReady_interval = (float)LuaAPI.lua_tonumber(L, 3);
                    
                    __cl_gen_to_be_invoked.SetInCastingReadyStage( var_isInCastingReadyStage, max_castingReady_interval );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_Reset(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            xc.InstanceManager __cl_gen_to_be_invoked = (xc.InstanceManager)translator.FastGetCSObj(L, 1);
            
            
            try {
                
                {
                    bool isBreakLine = LuaAPI.lua_toboolean(L, 2);
                    
                    __cl_gen_to_be_invoked.Reset( isBreakLine );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_ResetInstanceData(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            xc.InstanceManager __cl_gen_to_be_invoked = (xc.InstanceManager)translator.FastGetCSObj(L, 1);
            
            
            try {
                
                {
                    
                    __cl_gen_to_be_invoked.ResetInstanceData(  );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_RegisterAllMessages(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            xc.InstanceManager __cl_gen_to_be_invoked = (xc.InstanceManager)translator.FastGetCSObj(L, 1);
            
            
            try {
                
                {
                    
                    __cl_gen_to_be_invoked.RegisterAllMessages(  );
                    
                    
                    
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
            
            
            xc.InstanceManager __cl_gen_to_be_invoked = (xc.InstanceManager)translator.FastGetCSObj(L, 1);
            
            
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
        static int _m_PauseAutoFighting(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            xc.InstanceManager __cl_gen_to_be_invoked = (xc.InstanceManager)translator.FastGetCSObj(L, 1);
            
            
			int __gen_param_count = LuaAPI.lua_gettop(L);
            
            try {
                if(__gen_param_count == 2&& LuaTypes.LUA_TBOOLEAN == LuaAPI.lua_type(L, 2)) 
                {
                    bool isShowTips = LuaAPI.lua_toboolean(L, 2);
                    
                    __cl_gen_to_be_invoked.PauseAutoFighting( isShowTips );
                    
                    
                    
                    return 0;
                }
                if(__gen_param_count == 1) 
                {
                    
                    __cl_gen_to_be_invoked.PauseAutoFighting(  );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
            return LuaAPI.luaL_error(L, "invalid arguments to xc.InstanceManager.PauseAutoFighting!");
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_SetOnHook(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            xc.InstanceManager __cl_gen_to_be_invoked = (xc.InstanceManager)translator.FastGetCSObj(L, 1);
            
            
            try {
                
                {
                    bool isOnHook = LuaAPI.lua_toboolean(L, 2);
                    
                    __cl_gen_to_be_invoked.SetOnHook( isOnHook );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_SetAutoFightingTargetMonsterId(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            xc.InstanceManager __cl_gen_to_be_invoked = (xc.InstanceManager)translator.FastGetCSObj(L, 1);
            
            
            try {
                
                {
                    uint targetMonsterId = LuaAPI.xlua_touint(L, 2);
                    
                    __cl_gen_to_be_invoked.SetAutoFightingTargetMonsterId( targetMonsterId );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_SetIsAutoFightingOutsideInstance(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            xc.InstanceManager __cl_gen_to_be_invoked = (xc.InstanceManager)translator.FastGetCSObj(L, 1);
            
            
            try {
                
                {
                    bool isAutoFighting = LuaAPI.lua_toboolean(L, 2);
                    
                    __cl_gen_to_be_invoked.SetIsAutoFightingOutsideInstance( isAutoFighting );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_InitPollInfo(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            xc.InstanceManager __cl_gen_to_be_invoked = (xc.InstanceManager)translator.FastGetCSObj(L, 1);
            
            
            try {
                
                {
                    uint instanceId = LuaAPI.xlua_touint(L, 2);
                    uint pollId = LuaAPI.xlua_touint(L, 3);
                    
                    __cl_gen_to_be_invoked.InitPollInfo( instanceId, pollId );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_GetVote(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            xc.InstanceManager __cl_gen_to_be_invoked = (xc.InstanceManager)translator.FastGetCSObj(L, 1);
            
            
            try {
                
                {
                    uint uuid = LuaAPI.xlua_touint(L, 2);
                    
                        uint __cl_gen_ret = __cl_gen_to_be_invoked.GetVote( uuid );
                        LuaAPI.xlua_pushuint(L, __cl_gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        
        
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_InstanceCostTime(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.InstanceManager __cl_gen_to_be_invoked = (xc.InstanceManager)translator.FastGetCSObj(L, 1);
                LuaAPI.xlua_pushuint(L, __cl_gen_to_be_invoked.InstanceCostTime);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_ReviveLayer(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.InstanceManager __cl_gen_to_be_invoked = (xc.InstanceManager)translator.FastGetCSObj(L, 1);
                LuaAPI.xlua_pushuint(L, __cl_gen_to_be_invoked.ReviveLayer);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_IsOnHook(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.InstanceManager __cl_gen_to_be_invoked = (xc.InstanceManager)translator.FastGetCSObj(L, 1);
                LuaAPI.lua_pushboolean(L, __cl_gen_to_be_invoked.IsOnHook);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_IsInCastingReadyStage(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.InstanceManager __cl_gen_to_be_invoked = (xc.InstanceManager)translator.FastGetCSObj(L, 1);
                LuaAPI.lua_pushboolean(L, __cl_gen_to_be_invoked.IsInCastingReadyStage);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_InCastingReadyStageMaxInterval(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.InstanceManager __cl_gen_to_be_invoked = (xc.InstanceManager)translator.FastGetCSObj(L, 1);
                LuaAPI.lua_pushnumber(L, __cl_gen_to_be_invoked.InCastingReadyStageMaxInterval);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_KillPieceNum(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.InstanceManager __cl_gen_to_be_invoked = (xc.InstanceManager)translator.FastGetCSObj(L, 1);
                LuaAPI.xlua_pushuint(L, __cl_gen_to_be_invoked.KillPieceNum);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_DogHeadScore(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.InstanceManager __cl_gen_to_be_invoked = (xc.InstanceManager)translator.FastGetCSObj(L, 1);
                LuaAPI.xlua_pushuint(L, __cl_gen_to_be_invoked.DogHeadScore);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_DeadSpaceScore(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.InstanceManager __cl_gen_to_be_invoked = (xc.InstanceManager)translator.FastGetCSObj(L, 1);
                translator.Push(L, __cl_gen_to_be_invoked.DeadSpaceScore);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_FairyValleyInfo(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.InstanceManager __cl_gen_to_be_invoked = (xc.InstanceManager)translator.FastGetCSObj(L, 1);
                translator.Push(L, __cl_gen_to_be_invoked.FairyValleyInfo);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_FairyValleyExpRecord(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.InstanceManager __cl_gen_to_be_invoked = (xc.InstanceManager)translator.FastGetCSObj(L, 1);
                LuaAPI.lua_pushuint64(L, __cl_gen_to_be_invoked.FairyValleyExpRecord);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_FairyValleyInspireNum1(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.InstanceManager __cl_gen_to_be_invoked = (xc.InstanceManager)translator.FastGetCSObj(L, 1);
                LuaAPI.xlua_pushuint(L, __cl_gen_to_be_invoked.FairyValleyInspireNum1);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_FairyValleyInspireNum2(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.InstanceManager __cl_gen_to_be_invoked = (xc.InstanceManager)translator.FastGetCSObj(L, 1);
                LuaAPI.xlua_pushuint(L, __cl_gen_to_be_invoked.FairyValleyInspireNum2);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_PollInfo(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.InstanceManager __cl_gen_to_be_invoked = (xc.InstanceManager)translator.FastGetCSObj(L, 1);
                translator.Push(L, __cl_gen_to_be_invoked.PollInfo);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_PollStartTime(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.InstanceManager __cl_gen_to_be_invoked = (xc.InstanceManager)translator.FastGetCSObj(L, 1);
                LuaAPI.xlua_pushuint(L, __cl_gen_to_be_invoked.PollStartTime);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_InstancePhase(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.InstanceManager __cl_gen_to_be_invoked = (xc.InstanceManager)translator.FastGetCSObj(L, 1);
                LuaAPI.xlua_pushuint(L, __cl_gen_to_be_invoked.InstancePhase);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_InstancePhaseStartTime(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.InstanceManager __cl_gen_to_be_invoked = (xc.InstanceManager)translator.FastGetCSObj(L, 1);
                LuaAPI.xlua_pushuint(L, __cl_gen_to_be_invoked.InstancePhaseStartTime);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_InstancePhaseProgress(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.InstanceManager __cl_gen_to_be_invoked = (xc.InstanceManager)translator.FastGetCSObj(L, 1);
                LuaAPI.xlua_pushuint(L, __cl_gen_to_be_invoked.InstancePhaseProgress);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_InstanceMark(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.InstanceManager __cl_gen_to_be_invoked = (xc.InstanceManager)translator.FastGetCSObj(L, 1);
                LuaAPI.xlua_pushuint(L, __cl_gen_to_be_invoked.InstanceMark);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_InstanceInfo(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.InstanceManager __cl_gen_to_be_invoked = (xc.InstanceManager)translator.FastGetCSObj(L, 1);
                translator.Push(L, __cl_gen_to_be_invoked.InstanceInfo);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_MapInfo(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.InstanceManager __cl_gen_to_be_invoked = (xc.InstanceManager)translator.FastGetCSObj(L, 1);
                translator.Push(L, __cl_gen_to_be_invoked.MapInfo);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_InstanceType(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.InstanceManager __cl_gen_to_be_invoked = (xc.InstanceManager)translator.FastGetCSObj(L, 1);
                LuaAPI.xlua_pushuint(L, __cl_gen_to_be_invoked.InstanceType);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_InstanceSubType(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.InstanceManager __cl_gen_to_be_invoked = (xc.InstanceManager)translator.FastGetCSObj(L, 1);
                LuaAPI.xlua_pushuint(L, __cl_gen_to_be_invoked.InstanceSubType);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_IsPlayerVSPlayerType(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.InstanceManager __cl_gen_to_be_invoked = (xc.InstanceManager)translator.FastGetCSObj(L, 1);
                LuaAPI.lua_pushboolean(L, __cl_gen_to_be_invoked.IsPlayerVSPlayerType);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_IsAutoFighting(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.InstanceManager __cl_gen_to_be_invoked = (xc.InstanceManager)translator.FastGetCSObj(L, 1);
                LuaAPI.lua_pushboolean(L, __cl_gen_to_be_invoked.IsAutoFighting);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_InstanceOpenState(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.InstanceManager __cl_gen_to_be_invoked = (xc.InstanceManager)translator.FastGetCSObj(L, 1);
                translator.Push(L, __cl_gen_to_be_invoked.InstanceOpenState);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_KunfuGodId(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.InstanceManager __cl_gen_to_be_invoked = (xc.InstanceManager)translator.FastGetCSObj(L, 1);
                LuaAPI.xlua_pushuint(L, __cl_gen_to_be_invoked.KunfuGodId);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_KunfuGodShowRunesTipsCache(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.InstanceManager __cl_gen_to_be_invoked = (xc.InstanceManager)translator.FastGetCSObj(L, 1);
                translator.Push(L, __cl_gen_to_be_invoked.KunfuGodShowRunesTipsCache);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_InstanceCostTime(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.InstanceManager __cl_gen_to_be_invoked = (xc.InstanceManager)translator.FastGetCSObj(L, 1);
                __cl_gen_to_be_invoked.InstanceCostTime = LuaAPI.xlua_touint(L, 2);
            
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_ReviveLayer(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.InstanceManager __cl_gen_to_be_invoked = (xc.InstanceManager)translator.FastGetCSObj(L, 1);
                __cl_gen_to_be_invoked.ReviveLayer = LuaAPI.xlua_touint(L, 2);
            
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_IsShowAutoFightingGotExp(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.InstanceManager __cl_gen_to_be_invoked = (xc.InstanceManager)translator.FastGetCSObj(L, 1);
                __cl_gen_to_be_invoked.IsShowAutoFightingGotExp = LuaAPI.lua_toboolean(L, 2);
            
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_IsOnHook(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.InstanceManager __cl_gen_to_be_invoked = (xc.InstanceManager)translator.FastGetCSObj(L, 1);
                __cl_gen_to_be_invoked.IsOnHook = LuaAPI.lua_toboolean(L, 2);
            
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_KillPieceNum(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.InstanceManager __cl_gen_to_be_invoked = (xc.InstanceManager)translator.FastGetCSObj(L, 1);
                __cl_gen_to_be_invoked.KillPieceNum = LuaAPI.xlua_touint(L, 2);
            
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_DogHeadScore(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.InstanceManager __cl_gen_to_be_invoked = (xc.InstanceManager)translator.FastGetCSObj(L, 1);
                __cl_gen_to_be_invoked.DogHeadScore = LuaAPI.xlua_touint(L, 2);
            
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_DeadSpaceScore(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.InstanceManager __cl_gen_to_be_invoked = (xc.InstanceManager)translator.FastGetCSObj(L, 1);
                __cl_gen_to_be_invoked.DeadSpaceScore = (xc.DungeonDeadSpaceScore)translator.GetObject(L, 2, typeof(xc.DungeonDeadSpaceScore));
            
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_FairyValleyInfo(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.InstanceManager __cl_gen_to_be_invoked = (xc.InstanceManager)translator.FastGetCSObj(L, 1);
                __cl_gen_to_be_invoked.FairyValleyInfo = (xc.DungeonFairyValleyInfo)translator.GetObject(L, 2, typeof(xc.DungeonFairyValleyInfo));
            
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_FairyValleyExpRecord(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.InstanceManager __cl_gen_to_be_invoked = (xc.InstanceManager)translator.FastGetCSObj(L, 1);
                __cl_gen_to_be_invoked.FairyValleyExpRecord = LuaAPI.lua_touint64(L, 2);
            
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_FairyValleyInspireNum1(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.InstanceManager __cl_gen_to_be_invoked = (xc.InstanceManager)translator.FastGetCSObj(L, 1);
                __cl_gen_to_be_invoked.FairyValleyInspireNum1 = LuaAPI.xlua_touint(L, 2);
            
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_FairyValleyInspireNum2(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.InstanceManager __cl_gen_to_be_invoked = (xc.InstanceManager)translator.FastGetCSObj(L, 1);
                __cl_gen_to_be_invoked.FairyValleyInspireNum2 = LuaAPI.xlua_touint(L, 2);
            
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_PollInfo(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.InstanceManager __cl_gen_to_be_invoked = (xc.InstanceManager)translator.FastGetCSObj(L, 1);
                __cl_gen_to_be_invoked.PollInfo = (xc.InstanceManager.InstancePollInfo)translator.GetObject(L, 2, typeof(xc.InstanceManager.InstancePollInfo));
            
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_PollStartTime(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.InstanceManager __cl_gen_to_be_invoked = (xc.InstanceManager)translator.FastGetCSObj(L, 1);
                __cl_gen_to_be_invoked.PollStartTime = LuaAPI.xlua_touint(L, 2);
            
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_InstancePhase(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.InstanceManager __cl_gen_to_be_invoked = (xc.InstanceManager)translator.FastGetCSObj(L, 1);
                __cl_gen_to_be_invoked.InstancePhase = LuaAPI.xlua_touint(L, 2);
            
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_InstancePhaseStartTime(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.InstanceManager __cl_gen_to_be_invoked = (xc.InstanceManager)translator.FastGetCSObj(L, 1);
                __cl_gen_to_be_invoked.InstancePhaseStartTime = LuaAPI.xlua_touint(L, 2);
            
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_InstancePhaseProgress(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.InstanceManager __cl_gen_to_be_invoked = (xc.InstanceManager)translator.FastGetCSObj(L, 1);
                __cl_gen_to_be_invoked.InstancePhaseProgress = LuaAPI.xlua_touint(L, 2);
            
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_InstanceMark(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.InstanceManager __cl_gen_to_be_invoked = (xc.InstanceManager)translator.FastGetCSObj(L, 1);
                __cl_gen_to_be_invoked.InstanceMark = LuaAPI.xlua_touint(L, 2);
            
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_InstanceInfo(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.InstanceManager __cl_gen_to_be_invoked = (xc.InstanceManager)translator.FastGetCSObj(L, 1);
                __cl_gen_to_be_invoked.InstanceInfo = (xc.DBInstance.InstanceInfo)translator.GetObject(L, 2, typeof(xc.DBInstance.InstanceInfo));
            
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_MapInfo(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.InstanceManager __cl_gen_to_be_invoked = (xc.InstanceManager)translator.FastGetCSObj(L, 1);
                __cl_gen_to_be_invoked.MapInfo = (xc.DBMap.MapInfo)translator.GetObject(L, 2, typeof(xc.DBMap.MapInfo));
            
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_IsAutoFighting(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.InstanceManager __cl_gen_to_be_invoked = (xc.InstanceManager)translator.FastGetCSObj(L, 1);
                __cl_gen_to_be_invoked.IsAutoFighting = LuaAPI.lua_toboolean(L, 2);
            
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_InstanceOpenState(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.InstanceManager __cl_gen_to_be_invoked = (xc.InstanceManager)translator.FastGetCSObj(L, 1);
                __cl_gen_to_be_invoked.InstanceOpenState = (System.Collections.Generic.Dictionary<uint, xc.InstanceManager.InstaneOpenState>)translator.GetObject(L, 2, typeof(System.Collections.Generic.Dictionary<uint, xc.InstanceManager.InstaneOpenState>));
            
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_KunfuGodId(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.InstanceManager __cl_gen_to_be_invoked = (xc.InstanceManager)translator.FastGetCSObj(L, 1);
                __cl_gen_to_be_invoked.KunfuGodId = LuaAPI.xlua_touint(L, 2);
            
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_KunfuGodShowRunesTipsCache(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.InstanceManager __cl_gen_to_be_invoked = (xc.InstanceManager)translator.FastGetCSObj(L, 1);
                __cl_gen_to_be_invoked.KunfuGodShowRunesTipsCache = (System.Collections.Generic.List<uint>)translator.GetObject(L, 2, typeof(System.Collections.Generic.List<uint>));
            
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 0;
        }
        
		
		
		
		
    }
}
