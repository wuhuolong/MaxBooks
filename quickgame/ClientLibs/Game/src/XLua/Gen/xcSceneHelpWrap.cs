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
    public class xcSceneHelpWrap
    {
        public static void __Register(RealStatePtr L)
        {
			ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			XUtils.BeginObjectRegister(typeof(xc.SceneHelp), L, translator, 0, 11, 52, 11);
			
			XUtils.RegisterFunc(L, XUtils.METHOD_IDX, "ForbidUseGoods", _m_ForbidUseGoods);
			XUtils.RegisterFunc(L, XUtils.METHOD_IDX, "ShowDanmakuInChatChannel", _m_ShowDanmakuInChatChannel);
			XUtils.RegisterFunc(L, XUtils.METHOD_IDX, "IsInGuildLeagueInstance", _m_IsInGuildLeagueInstance);
			XUtils.RegisterFunc(L, XUtils.METHOD_IDX, "IsInSpanGuildWarInstance", _m_IsInSpanGuildWarInstance);
			XUtils.RegisterFunc(L, XUtils.METHOD_IDX, "IsInWildInstance", _m_IsInWildInstance);
			XUtils.RegisterFunc(L, XUtils.METHOD_IDX, "IsInNormalWild", _m_IsInNormalWild);
			XUtils.RegisterFunc(L, XUtils.METHOD_IDX, "IsInstanceUseAoi", _m_IsInstanceUseAoi);
			XUtils.RegisterFunc(L, XUtils.METHOD_IDX, "ProcessLineCD", _m_ProcessLineCD);
			XUtils.RegisterFunc(L, XUtils.METHOD_IDX, "ProcessLineInfo", _m_ProcessLineInfo);
			XUtils.RegisterFunc(L, XUtils.METHOD_IDX, "SwitchScene", _m_SwitchScene);
			XUtils.RegisterFunc(L, XUtils.METHOD_IDX, "SwitchPreposeScene", _m_SwitchPreposeScene);
			
			
			XUtils.RegisterFunc(L, XUtils.GETTER_IDX, "AutoHideLoadingUI", _g_get_AutoHideLoadingUI);
            XUtils.RegisterFunc(L, XUtils.GETTER_IDX, "CurSceneName", _g_get_CurSceneName);
            XUtils.RegisterFunc(L, XUtils.GETTER_IDX, "CurSceneResPath", _g_get_CurSceneResPath);
            XUtils.RegisterFunc(L, XUtils.GETTER_IDX, "MapInfo", _g_get_MapInfo);
            XUtils.RegisterFunc(L, XUtils.GETTER_IDX, "WillSwitchScene", _g_get_WillSwitchScene);
            XUtils.RegisterFunc(L, XUtils.GETTER_IDX, "IsAutoFightingAfterSwitchInstance", _g_get_IsAutoFightingAfterSwitchInstance);
            XUtils.RegisterFunc(L, XUtils.GETTER_IDX, "IsAutoFightingWhenShowExitTips", _g_get_IsAutoFightingWhenShowExitTips);
            XUtils.RegisterFunc(L, XUtils.GETTER_IDX, "CurSceneID", _g_get_CurSceneID);
            XUtils.RegisterFunc(L, XUtils.GETTER_IDX, "PreSceneID", _g_get_PreSceneID);
            XUtils.RegisterFunc(L, XUtils.GETTER_IDX, "CanHidePlayer", _g_get_CanHidePlayer);
            XUtils.RegisterFunc(L, XUtils.GETTER_IDX, "PrecedentPlayer", _g_get_PrecedentPlayer);
            XUtils.RegisterFunc(L, XUtils.GETTER_IDX, "PKLevelLimit", _g_get_PKLevelLimit);
            XUtils.RegisterFunc(L, XUtils.GETTER_IDX, "IgnoreClickPlayer", _g_get_IgnoreClickPlayer);
            XUtils.RegisterFunc(L, XUtils.GETTER_IDX, "ForceShowHpBar", _g_get_ForceShowHpBar);
            XUtils.RegisterFunc(L, XUtils.GETTER_IDX, "ForbidChangePkMode", _g_get_ForbidChangePkMode);
            XUtils.RegisterFunc(L, XUtils.GETTER_IDX, "ShowDanmakuSwitch", _g_get_ShowDanmakuSwitch);
            XUtils.RegisterFunc(L, XUtils.GETTER_IDX, "ForbidOpenWorldMap", _g_get_ForbidOpenWorldMap);
            XUtils.RegisterFunc(L, XUtils.GETTER_IDX, "ForbidTeam", _g_get_ForbidTeam);
            XUtils.RegisterFunc(L, XUtils.GETTER_IDX, "IsKungfuInstance", _g_get_IsKungfuInstance);
            XUtils.RegisterFunc(L, XUtils.GETTER_IDX, "IsInGuildBossInstance", _g_get_IsInGuildBossInstance);
            XUtils.RegisterFunc(L, XUtils.GETTER_IDX, "IsInDeadSpaceInstance", _g_get_IsInDeadSpaceInstance);
            XUtils.RegisterFunc(L, XUtils.GETTER_IDX, "IsInTrialBossInstance", _g_get_IsInTrialBossInstance);
            XUtils.RegisterFunc(L, XUtils.GETTER_IDX, "IsInPeakBossInstance", _g_get_IsInPeakBossInstance);
            XUtils.RegisterFunc(L, XUtils.GETTER_IDX, "IsInSecretDefendInstance", _g_get_IsInSecretDefendInstance);
            XUtils.RegisterFunc(L, XUtils.GETTER_IDX, "IsInSouthLandInstance", _g_get_IsInSouthLandInstance);
            XUtils.RegisterFunc(L, XUtils.GETTER_IDX, "IsInElementAreaInstance", _g_get_IsInElementAreaInstance);
            XUtils.RegisterFunc(L, XUtils.GETTER_IDX, "IsInBossHomeInstance", _g_get_IsInBossHomeInstance);
            XUtils.RegisterFunc(L, XUtils.GETTER_IDX, "IsInDeedInheritInstance", _g_get_IsInDeedInheritInstance);
            XUtils.RegisterFunc(L, XUtils.GETTER_IDX, "IsInFirstWorldBossInstance", _g_get_IsInFirstWorldBossInstance);
            XUtils.RegisterFunc(L, XUtils.GETTER_IDX, "IsInFairyValleyInstance", _g_get_IsInFairyValleyInstance);
            XUtils.RegisterFunc(L, XUtils.GETTER_IDX, "IsInWorshipMeetingInstance", _g_get_IsInWorshipMeetingInstance);
            XUtils.RegisterFunc(L, XUtils.GETTER_IDX, "IsInCatchBossInstance", _g_get_IsInCatchBossInstance);
            XUtils.RegisterFunc(L, XUtils.GETTER_IDX, "IsInWorldBossExperienceInstance", _g_get_IsInWorldBossExperienceInstance);
            XUtils.RegisterFunc(L, XUtils.GETTER_IDX, "IsInWorldBossFirstInstance", _g_get_IsInWorldBossFirstInstance);
            XUtils.RegisterFunc(L, XUtils.GETTER_IDX, "IsInPersonalBossInstance", _g_get_IsInPersonalBossInstance);
            XUtils.RegisterFunc(L, XUtils.GETTER_IDX, "IsInLoveInstance", _g_get_IsInLoveInstance);
            XUtils.RegisterFunc(L, XUtils.GETTER_IDX, "IsInWeddingInstance", _g_get_IsInWeddingInstance);
            XUtils.RegisterFunc(L, XUtils.GETTER_IDX, "IsInInstance", _g_get_IsInInstance);
            XUtils.RegisterFunc(L, XUtils.GETTER_IDX, "IsPlayingInstance", _g_get_IsPlayingInstance);
            XUtils.RegisterFunc(L, XUtils.GETTER_IDX, "IsInGuildManor", _g_get_IsInGuildManor);
            XUtils.RegisterFunc(L, XUtils.GETTER_IDX, "IsInDevilComeInstance", _g_get_IsInDevilComeInstance);
            XUtils.RegisterFunc(L, XUtils.GETTER_IDX, "UsePKMode", _g_get_UsePKMode);
            XUtils.RegisterFunc(L, XUtils.GETTER_IDX, "NoShowAtkCampTips", _g_get_NoShowAtkCampTips);
            XUtils.RegisterFunc(L, XUtils.GETTER_IDX, "CanRide", _g_get_CanRide);
            XUtils.RegisterFunc(L, XUtils.GETTER_IDX, "IsShowDungeonUI_inMainMap", _g_get_IsShowDungeonUI_inMainMap);
            XUtils.RegisterFunc(L, XUtils.GETTER_IDX, "IsCanExitBtnInWild", _g_get_IsCanExitBtnInWild);
            XUtils.RegisterFunc(L, XUtils.GETTER_IDX, "IsSwitchingScene", _g_get_IsSwitchingScene);
            XUtils.RegisterFunc(L, XUtils.GETTER_IDX, "IsLoadingQuadTreeScene", _g_get_IsLoadingQuadTreeScene);
            XUtils.RegisterFunc(L, XUtils.GETTER_IDX, "mLineInfos", _g_get_mLineInfos);
            XUtils.RegisterFunc(L, XUtils.GETTER_IDX, "mChangeLineCDTime", _g_get_mChangeLineCDTime);
            XUtils.RegisterFunc(L, XUtils.GETTER_IDX, "mDelyLineCdTime", _g_get_mDelyLineCdTime);
            XUtils.RegisterFunc(L, XUtils.GETTER_IDX, "CurLine", _g_get_CurLine);
            
			XUtils.RegisterFunc(L, XUtils.SETTER_IDX, "WillSwitchScene", _s_set_WillSwitchScene);
            XUtils.RegisterFunc(L, XUtils.SETTER_IDX, "IsAutoFightingAfterSwitchInstance", _s_set_IsAutoFightingAfterSwitchInstance);
            XUtils.RegisterFunc(L, XUtils.SETTER_IDX, "IsAutoFightingWhenShowExitTips", _s_set_IsAutoFightingWhenShowExitTips);
            XUtils.RegisterFunc(L, XUtils.SETTER_IDX, "CurSceneID", _s_set_CurSceneID);
            XUtils.RegisterFunc(L, XUtils.SETTER_IDX, "PreSceneID", _s_set_PreSceneID);
            XUtils.RegisterFunc(L, XUtils.SETTER_IDX, "IsSwitchingScene", _s_set_IsSwitchingScene);
            XUtils.RegisterFunc(L, XUtils.SETTER_IDX, "IsLoadingQuadTreeScene", _s_set_IsLoadingQuadTreeScene);
            XUtils.RegisterFunc(L, XUtils.SETTER_IDX, "mLineInfos", _s_set_mLineInfos);
            XUtils.RegisterFunc(L, XUtils.SETTER_IDX, "mChangeLineCDTime", _s_set_mChangeLineCDTime);
            XUtils.RegisterFunc(L, XUtils.SETTER_IDX, "mDelyLineCdTime", _s_set_mDelyLineCdTime);
            XUtils.RegisterFunc(L, XUtils.SETTER_IDX, "CurLine", _s_set_CurLine);
            
			XUtils.EndObjectRegister(typeof(xc.SceneHelp), L, translator, null, null,
			    null, null, null);

		    XUtils.BeginClassRegister(typeof(xc.SceneHelp), L, __CreateInstance, 12, 2, 0);
			XUtils.RegisterFunc(L, XUtils.CLS_IDX, "PreCheckInstanceIsDownloaded", _m_PreCheckInstanceIsDownloaded_xlua_st_);
            XUtils.RegisterFunc(L, XUtils.CLS_IDX, "PostCheckInstanceIsDownloaded", _m_PostCheckInstanceIsDownloaded_xlua_st_);
            XUtils.RegisterFunc(L, XUtils.CLS_IDX, "JumpToScene", _m_JumpToScene_xlua_st_);
            XUtils.RegisterFunc(L, XUtils.CLS_IDX, "ReenterScene", _m_ReenterScene_xlua_st_);
            XUtils.RegisterFunc(L, XUtils.CLS_IDX, "CheckCanSwitch", _m_CheckCanSwitch_xlua_st_);
            XUtils.RegisterFunc(L, XUtils.CLS_IDX, "JumpToPreScene", _m_JumpToPreScene_xlua_st_);
            XUtils.RegisterFunc(L, XUtils.CLS_IDX, "TravelBootsJump", _m_TravelBootsJump_xlua_st_);
            XUtils.RegisterFunc(L, XUtils.CLS_IDX, "GetFirstStageId", _m_GetFirstStageId_xlua_st_);
            XUtils.RegisterFunc(L, XUtils.CLS_IDX, "GetFirstMapIdByInstanceId", _m_GetFirstMapIdByInstanceId_xlua_st_);
            XUtils.RegisterFunc(L, XUtils.CLS_IDX, "GetMapIdByStageId", _m_GetMapIdByStageId_xlua_st_);
            XUtils.RegisterFunc(L, XUtils.CLS_IDX, "CheckLocalPlayerEscortTaskState", _m_CheckLocalPlayerEscortTaskState_xlua_st_);
            
			
            
            XUtils.RegisterObject(L, translator, XUtils.CLS_IDX, "UnderlyingSystemType", typeof(xc.SceneHelp));
			XUtils.RegisterFunc(L, XUtils.CLS_GETTER_IDX, "loadedLevelName", _g_get_loadedLevelName);
            XUtils.RegisterFunc(L, XUtils.CLS_GETTER_IDX, "IsReEnterScene", _g_get_IsReEnterScene);
            
			
			XUtils.EndClassRegister(typeof(xc.SceneHelp), L, translator);
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int __CreateInstance(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			try {
				if(LuaAPI.lua_gettop(L) == 1)
				{
					
					xc.SceneHelp __cl_gen_ret = new xc.SceneHelp();
					translator.Push(L, __cl_gen_ret);
					return 1;
				}
				
			}
			catch(System.Exception __gen_e) {
				return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
			}
            return LuaAPI.luaL_error(L, "invalid arguments to xc.SceneHelp constructor!");
            
        }
        
		
        
		
        
        
        
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_ForbidUseGoods(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            xc.SceneHelp __cl_gen_to_be_invoked = (xc.SceneHelp)translator.FastGetCSObj(L, 1);
            
            
            try {
                
                {
                    uint goodsId = LuaAPI.xlua_touint(L, 2);
                    
                        bool __cl_gen_ret = __cl_gen_to_be_invoked.ForbidUseGoods( goodsId );
                        LuaAPI.lua_pushboolean(L, __cl_gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_ShowDanmakuInChatChannel(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            xc.SceneHelp __cl_gen_to_be_invoked = (xc.SceneHelp)translator.FastGetCSObj(L, 1);
            
            
            try {
                
                {
                    uint chatChannel = LuaAPI.xlua_touint(L, 2);
                    
                        bool __cl_gen_ret = __cl_gen_to_be_invoked.ShowDanmakuInChatChannel( chatChannel );
                        LuaAPI.lua_pushboolean(L, __cl_gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_IsInGuildLeagueInstance(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            xc.SceneHelp __cl_gen_to_be_invoked = (xc.SceneHelp)translator.FastGetCSObj(L, 1);
            
            
			int __gen_param_count = LuaAPI.lua_gettop(L);
            
            try {
                if(__gen_param_count == 2&& LuaTypes.LUA_TNUMBER == LuaAPI.lua_type(L, 2)) 
                {
                    uint instanceId = LuaAPI.xlua_touint(L, 2);
                    
                        bool __cl_gen_ret = __cl_gen_to_be_invoked.IsInGuildLeagueInstance( instanceId );
                        LuaAPI.lua_pushboolean(L, __cl_gen_ret);
                    
                    
                    
                    return 1;
                }
                if(__gen_param_count == 1) 
                {
                    
                        bool __cl_gen_ret = __cl_gen_to_be_invoked.IsInGuildLeagueInstance(  );
                        LuaAPI.lua_pushboolean(L, __cl_gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
            return LuaAPI.luaL_error(L, "invalid arguments to xc.SceneHelp.IsInGuildLeagueInstance!");
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_IsInSpanGuildWarInstance(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            xc.SceneHelp __cl_gen_to_be_invoked = (xc.SceneHelp)translator.FastGetCSObj(L, 1);
            
            
			int __gen_param_count = LuaAPI.lua_gettop(L);
            
            try {
                if(__gen_param_count == 2&& LuaTypes.LUA_TNUMBER == LuaAPI.lua_type(L, 2)) 
                {
                    uint instanceId = LuaAPI.xlua_touint(L, 2);
                    
                        bool __cl_gen_ret = __cl_gen_to_be_invoked.IsInSpanGuildWarInstance( instanceId );
                        LuaAPI.lua_pushboolean(L, __cl_gen_ret);
                    
                    
                    
                    return 1;
                }
                if(__gen_param_count == 1) 
                {
                    
                        bool __cl_gen_ret = __cl_gen_to_be_invoked.IsInSpanGuildWarInstance(  );
                        LuaAPI.lua_pushboolean(L, __cl_gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
            return LuaAPI.luaL_error(L, "invalid arguments to xc.SceneHelp.IsInSpanGuildWarInstance!");
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_IsInWildInstance(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            xc.SceneHelp __cl_gen_to_be_invoked = (xc.SceneHelp)translator.FastGetCSObj(L, 1);
            
            
			int __gen_param_count = LuaAPI.lua_gettop(L);
            
            try {
                if(__gen_param_count == 2&& LuaTypes.LUA_TNUMBER == LuaAPI.lua_type(L, 2)) 
                {
                    uint instanceId = LuaAPI.xlua_touint(L, 2);
                    
                        bool __cl_gen_ret = __cl_gen_to_be_invoked.IsInWildInstance( instanceId );
                        LuaAPI.lua_pushboolean(L, __cl_gen_ret);
                    
                    
                    
                    return 1;
                }
                if(__gen_param_count == 1) 
                {
                    
                        bool __cl_gen_ret = __cl_gen_to_be_invoked.IsInWildInstance(  );
                        LuaAPI.lua_pushboolean(L, __cl_gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
            return LuaAPI.luaL_error(L, "invalid arguments to xc.SceneHelp.IsInWildInstance!");
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_IsInNormalWild(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            xc.SceneHelp __cl_gen_to_be_invoked = (xc.SceneHelp)translator.FastGetCSObj(L, 1);
            
            
			int __gen_param_count = LuaAPI.lua_gettop(L);
            
            try {
                if(__gen_param_count == 2&& LuaTypes.LUA_TNUMBER == LuaAPI.lua_type(L, 2)) 
                {
                    uint instanceId = LuaAPI.xlua_touint(L, 2);
                    
                        bool __cl_gen_ret = __cl_gen_to_be_invoked.IsInNormalWild( instanceId );
                        LuaAPI.lua_pushboolean(L, __cl_gen_ret);
                    
                    
                    
                    return 1;
                }
                if(__gen_param_count == 1) 
                {
                    
                        bool __cl_gen_ret = __cl_gen_to_be_invoked.IsInNormalWild(  );
                        LuaAPI.lua_pushboolean(L, __cl_gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
            return LuaAPI.luaL_error(L, "invalid arguments to xc.SceneHelp.IsInNormalWild!");
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_IsInstanceUseAoi(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            xc.SceneHelp __cl_gen_to_be_invoked = (xc.SceneHelp)translator.FastGetCSObj(L, 1);
            
            
            try {
                
                {
                    
                        bool __cl_gen_ret = __cl_gen_to_be_invoked.IsInstanceUseAoi(  );
                        LuaAPI.lua_pushboolean(L, __cl_gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_ProcessLineCD(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            xc.SceneHelp __cl_gen_to_be_invoked = (xc.SceneHelp)translator.FastGetCSObj(L, 1);
            
            
            try {
                
                {
                    uint time = LuaAPI.xlua_touint(L, 2);
                    
                    __cl_gen_to_be_invoked.ProcessLineCD( time );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_ProcessLineInfo(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            xc.SceneHelp __cl_gen_to_be_invoked = (xc.SceneHelp)translator.FastGetCSObj(L, 1);
            
            
            try {
                
                {
                    Net.S2CMapLineState msg = (Net.S2CMapLineState)translator.GetObject(L, 2, typeof(Net.S2CMapLineState));
                    
                    __cl_gen_to_be_invoked.ProcessLineInfo( msg );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_PreCheckInstanceIsDownloaded_xlua_st_(RealStatePtr L)
        {
            
            
            
            try {
                
                {
                    uint instance_id = LuaAPI.xlua_touint(L, 1);
                    
                        bool __cl_gen_ret = xc.SceneHelp.PreCheckInstanceIsDownloaded( instance_id );
                        LuaAPI.lua_pushboolean(L, __cl_gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_PostCheckInstanceIsDownloaded_xlua_st_(RealStatePtr L)
        {
            
            
            
            try {
                
                {
                    uint instance_id = LuaAPI.xlua_touint(L, 1);
                    
                        bool __cl_gen_ret = xc.SceneHelp.PostCheckInstanceIsDownloaded( instance_id );
                        LuaAPI.lua_pushboolean(L, __cl_gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_JumpToScene_xlua_st_(RealStatePtr L)
        {
            
            
            
			int __gen_param_count = LuaAPI.lua_gettop(L);
            
            try {
                if(__gen_param_count == 4&& LuaTypes.LUA_TNUMBER == LuaAPI.lua_type(L, 1)&& LuaTypes.LUA_TNUMBER == LuaAPI.lua_type(L, 2)&& LuaTypes.LUA_TNUMBER == LuaAPI.lua_type(L, 3)&& LuaTypes.LUA_TBOOLEAN == LuaAPI.lua_type(L, 4)) 
                {
                    uint id = LuaAPI.xlua_touint(L, 1);
                    uint line = LuaAPI.xlua_touint(L, 2);
                    uint transferPosId = LuaAPI.xlua_touint(L, 3);
                    bool checkAttr = LuaAPI.lua_toboolean(L, 4);
                    
                    xc.SceneHelp.JumpToScene( id, line, transferPosId, checkAttr );
                    
                    
                    
                    return 0;
                }
                if(__gen_param_count == 3&& LuaTypes.LUA_TNUMBER == LuaAPI.lua_type(L, 1)&& LuaTypes.LUA_TNUMBER == LuaAPI.lua_type(L, 2)&& LuaTypes.LUA_TNUMBER == LuaAPI.lua_type(L, 3)) 
                {
                    uint id = LuaAPI.xlua_touint(L, 1);
                    uint line = LuaAPI.xlua_touint(L, 2);
                    uint transferPosId = LuaAPI.xlua_touint(L, 3);
                    
                    xc.SceneHelp.JumpToScene( id, line, transferPosId );
                    
                    
                    
                    return 0;
                }
                if(__gen_param_count == 2&& LuaTypes.LUA_TNUMBER == LuaAPI.lua_type(L, 1)&& LuaTypes.LUA_TNUMBER == LuaAPI.lua_type(L, 2)) 
                {
                    uint id = LuaAPI.xlua_touint(L, 1);
                    uint line = LuaAPI.xlua_touint(L, 2);
                    
                    xc.SceneHelp.JumpToScene( id, line );
                    
                    
                    
                    return 0;
                }
                if(__gen_param_count == 1&& LuaTypes.LUA_TNUMBER == LuaAPI.lua_type(L, 1)) 
                {
                    uint id = LuaAPI.xlua_touint(L, 1);
                    
                    xc.SceneHelp.JumpToScene( id );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
            return LuaAPI.luaL_error(L, "invalid arguments to xc.SceneHelp.JumpToScene!");
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_ReenterScene_xlua_st_(RealStatePtr L)
        {
            
            
            
            try {
                
                {
                    
                    xc.SceneHelp.ReenterScene(  );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_CheckCanSwitch_xlua_st_(RealStatePtr L)
        {
            
            
            
			int __gen_param_count = LuaAPI.lua_gettop(L);
            
            try {
                if(__gen_param_count == 0) 
                {
                    
                        bool __cl_gen_ret = xc.SceneHelp.CheckCanSwitch(  );
                        LuaAPI.lua_pushboolean(L, __cl_gen_ret);
                    
                    
                    
                    return 1;
                }
                if(__gen_param_count == 2&& LuaTypes.LUA_TNUMBER == LuaAPI.lua_type(L, 1)&& LuaTypes.LUA_TBOOLEAN == LuaAPI.lua_type(L, 2)) 
                {
                    uint instanceId = LuaAPI.xlua_touint(L, 1);
                    bool show_notice = LuaAPI.lua_toboolean(L, 2);
                    
                        bool __cl_gen_ret = xc.SceneHelp.CheckCanSwitch( instanceId, show_notice );
                        LuaAPI.lua_pushboolean(L, __cl_gen_ret);
                    
                    
                    
                    return 1;
                }
                if(__gen_param_count == 1&& LuaTypes.LUA_TNUMBER == LuaAPI.lua_type(L, 1)) 
                {
                    uint instanceId = LuaAPI.xlua_touint(L, 1);
                    
                        bool __cl_gen_ret = xc.SceneHelp.CheckCanSwitch( instanceId );
                        LuaAPI.lua_pushboolean(L, __cl_gen_ret);
                    
                    
                    
                    return 1;
                }
                if(__gen_param_count == 3&& LuaTypes.LUA_TNUMBER == LuaAPI.lua_type(L, 1)&& LuaTypes.LUA_TNUMBER == LuaAPI.lua_type(L, 2)&& LuaTypes.LUA_TBOOLEAN == LuaAPI.lua_type(L, 3)) 
                {
                    uint warType = LuaAPI.xlua_touint(L, 1);
                    uint warSubType = LuaAPI.xlua_touint(L, 2);
                    bool show_notice = LuaAPI.lua_toboolean(L, 3);
                    
                        bool __cl_gen_ret = xc.SceneHelp.CheckCanSwitch( warType, warSubType, show_notice );
                        LuaAPI.lua_pushboolean(L, __cl_gen_ret);
                    
                    
                    
                    return 1;
                }
                if(__gen_param_count == 2&& LuaTypes.LUA_TNUMBER == LuaAPI.lua_type(L, 1)&& LuaTypes.LUA_TNUMBER == LuaAPI.lua_type(L, 2)) 
                {
                    uint warType = LuaAPI.xlua_touint(L, 1);
                    uint warSubType = LuaAPI.xlua_touint(L, 2);
                    
                        bool __cl_gen_ret = xc.SceneHelp.CheckCanSwitch( warType, warSubType );
                        LuaAPI.lua_pushboolean(L, __cl_gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
            return LuaAPI.luaL_error(L, "invalid arguments to xc.SceneHelp.CheckCanSwitch!");
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_JumpToPreScene_xlua_st_(RealStatePtr L)
        {
            
            
            
            try {
                
                {
                    
                    xc.SceneHelp.JumpToPreScene(  );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_TravelBootsJump_xlua_st_(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            
			int __gen_param_count = LuaAPI.lua_gettop(L);
            
            try {
                if(__gen_param_count == 5&& translator.Assignable<UnityEngine.Vector3>(L, 1)&& LuaTypes.LUA_TNUMBER == LuaAPI.lua_type(L, 2)&& LuaTypes.LUA_TBOOLEAN == LuaAPI.lua_type(L, 3)&& LuaTypes.LUA_TNUMBER == LuaAPI.lua_type(L, 4)&& LuaTypes.LUA_TBOOLEAN == LuaAPI.lua_type(L, 5)) 
                {
                    UnityEngine.Vector3 pos;translator.Get(L, 1, out pos);
                    uint instanceId = LuaAPI.xlua_touint(L, 2);
                    bool isFree = LuaAPI.lua_toboolean(L, 3);
                    uint line = LuaAPI.xlua_touint(L, 4);
                    bool isAutoFighting = LuaAPI.lua_toboolean(L, 5);
                    
                        bool __cl_gen_ret = xc.SceneHelp.TravelBootsJump( pos, instanceId, isFree, line, isAutoFighting );
                        LuaAPI.lua_pushboolean(L, __cl_gen_ret);
                    
                    
                    
                    return 1;
                }
                if(__gen_param_count == 4&& translator.Assignable<UnityEngine.Vector3>(L, 1)&& LuaTypes.LUA_TNUMBER == LuaAPI.lua_type(L, 2)&& LuaTypes.LUA_TBOOLEAN == LuaAPI.lua_type(L, 3)&& LuaTypes.LUA_TNUMBER == LuaAPI.lua_type(L, 4)) 
                {
                    UnityEngine.Vector3 pos;translator.Get(L, 1, out pos);
                    uint instanceId = LuaAPI.xlua_touint(L, 2);
                    bool isFree = LuaAPI.lua_toboolean(L, 3);
                    uint line = LuaAPI.xlua_touint(L, 4);
                    
                        bool __cl_gen_ret = xc.SceneHelp.TravelBootsJump( pos, instanceId, isFree, line );
                        LuaAPI.lua_pushboolean(L, __cl_gen_ret);
                    
                    
                    
                    return 1;
                }
                if(__gen_param_count == 3&& translator.Assignable<UnityEngine.Vector3>(L, 1)&& LuaTypes.LUA_TNUMBER == LuaAPI.lua_type(L, 2)&& LuaTypes.LUA_TBOOLEAN == LuaAPI.lua_type(L, 3)) 
                {
                    UnityEngine.Vector3 pos;translator.Get(L, 1, out pos);
                    uint instanceId = LuaAPI.xlua_touint(L, 2);
                    bool isFree = LuaAPI.lua_toboolean(L, 3);
                    
                        bool __cl_gen_ret = xc.SceneHelp.TravelBootsJump( pos, instanceId, isFree );
                        LuaAPI.lua_pushboolean(L, __cl_gen_ret);
                    
                    
                    
                    return 1;
                }
                if(__gen_param_count == 2&& translator.Assignable<UnityEngine.Vector3>(L, 1)&& LuaTypes.LUA_TNUMBER == LuaAPI.lua_type(L, 2)) 
                {
                    UnityEngine.Vector3 pos;translator.Get(L, 1, out pos);
                    uint instanceId = LuaAPI.xlua_touint(L, 2);
                    
                        bool __cl_gen_ret = xc.SceneHelp.TravelBootsJump( pos, instanceId );
                        LuaAPI.lua_pushboolean(L, __cl_gen_ret);
                    
                    
                    
                    return 1;
                }
                if(__gen_param_count == 1&& translator.Assignable<UnityEngine.Vector3>(L, 1)) 
                {
                    UnityEngine.Vector3 pos;translator.Get(L, 1, out pos);
                    
                        bool __cl_gen_ret = xc.SceneHelp.TravelBootsJump( pos );
                        LuaAPI.lua_pushboolean(L, __cl_gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
            return LuaAPI.luaL_error(L, "invalid arguments to xc.SceneHelp.TravelBootsJump!");
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_GetFirstStageId_xlua_st_(RealStatePtr L)
        {
            
            
            
            try {
                
                {
                    uint instanceId = LuaAPI.xlua_touint(L, 1);
                    
                        uint __cl_gen_ret = xc.SceneHelp.GetFirstStageId( instanceId );
                        LuaAPI.xlua_pushuint(L, __cl_gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_GetFirstMapIdByInstanceId_xlua_st_(RealStatePtr L)
        {
            
            
            
            try {
                
                {
                    uint instanceId = LuaAPI.xlua_touint(L, 1);
                    
                        uint __cl_gen_ret = xc.SceneHelp.GetFirstMapIdByInstanceId( instanceId );
                        LuaAPI.xlua_pushuint(L, __cl_gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_GetMapIdByStageId_xlua_st_(RealStatePtr L)
        {
            
            
            
            try {
                
                {
                    uint stage_id = LuaAPI.xlua_touint(L, 1);
                    
                        uint __cl_gen_ret = xc.SceneHelp.GetMapIdByStageId( stage_id );
                        LuaAPI.xlua_pushuint(L, __cl_gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_SwitchScene(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            xc.SceneHelp __cl_gen_to_be_invoked = (xc.SceneHelp)translator.FastGetCSObj(L, 1);
            
            
			int __gen_param_count = LuaAPI.lua_gettop(L);
            
            try {
                if(__gen_param_count == 4&& LuaTypes.LUA_TNUMBER == LuaAPI.lua_type(L, 2)&& LuaTypes.LUA_TBOOLEAN == LuaAPI.lua_type(L, 3)&& LuaTypes.LUA_TBOOLEAN == LuaAPI.lua_type(L, 4)) 
                {
                    uint map_id = LuaAPI.xlua_touint(L, 2);
                    bool auto_hide_loadingUI = LuaAPI.lua_toboolean(L, 3);
                    bool willSwitchScene = LuaAPI.lua_toboolean(L, 4);
                    
                    __cl_gen_to_be_invoked.SwitchScene( map_id, auto_hide_loadingUI, willSwitchScene );
                    
                    
                    
                    return 0;
                }
                if(__gen_param_count == 4&& translator.Assignable<xc.DBMap.MapInfo>(L, 2)&& LuaTypes.LUA_TBOOLEAN == LuaAPI.lua_type(L, 3)&& LuaTypes.LUA_TBOOLEAN == LuaAPI.lua_type(L, 4)) 
                {
                    xc.DBMap.MapInfo map_info = (xc.DBMap.MapInfo)translator.GetObject(L, 2, typeof(xc.DBMap.MapInfo));
                    bool auto_hide_loadingUI = LuaAPI.lua_toboolean(L, 3);
                    bool willSwitchScene = LuaAPI.lua_toboolean(L, 4);
                    
                    __cl_gen_to_be_invoked.SwitchScene( map_info, auto_hide_loadingUI, willSwitchScene );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
            return LuaAPI.luaL_error(L, "invalid arguments to xc.SceneHelp.SwitchScene!");
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_SwitchPreposeScene(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            xc.SceneHelp __cl_gen_to_be_invoked = (xc.SceneHelp)translator.FastGetCSObj(L, 1);
            
            
            try {
                
                {
                    string name = LuaAPI.lua_tostring(L, 2);
                    bool auto_hide_loading_ui = LuaAPI.lua_toboolean(L, 3);
                    
                    __cl_gen_to_be_invoked.SwitchPreposeScene( name, auto_hide_loading_ui );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_CheckLocalPlayerEscortTaskState_xlua_st_(RealStatePtr L)
        {
            
            
            
			int __gen_param_count = LuaAPI.lua_gettop(L);
            
            try {
                if(__gen_param_count == 1&& LuaTypes.LUA_TBOOLEAN == LuaAPI.lua_type(L, 1)) 
                {
                    bool showTips = LuaAPI.lua_toboolean(L, 1);
                    
                        bool __cl_gen_ret = xc.SceneHelp.CheckLocalPlayerEscortTaskState( showTips );
                        LuaAPI.lua_pushboolean(L, __cl_gen_ret);
                    
                    
                    
                    return 1;
                }
                if(__gen_param_count == 0) 
                {
                    
                        bool __cl_gen_ret = xc.SceneHelp.CheckLocalPlayerEscortTaskState(  );
                        LuaAPI.lua_pushboolean(L, __cl_gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
            return LuaAPI.luaL_error(L, "invalid arguments to xc.SceneHelp.CheckLocalPlayerEscortTaskState!");
            
        }
        
        
        
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_loadedLevelName(RealStatePtr L)
        {
            
            try {
			    LuaAPI.lua_pushstring(L, xc.SceneHelp.loadedLevelName);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_AutoHideLoadingUI(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.SceneHelp __cl_gen_to_be_invoked = (xc.SceneHelp)translator.FastGetCSObj(L, 1);
                LuaAPI.lua_pushboolean(L, __cl_gen_to_be_invoked.AutoHideLoadingUI);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_CurSceneName(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.SceneHelp __cl_gen_to_be_invoked = (xc.SceneHelp)translator.FastGetCSObj(L, 1);
                LuaAPI.lua_pushstring(L, __cl_gen_to_be_invoked.CurSceneName);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_CurSceneResPath(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.SceneHelp __cl_gen_to_be_invoked = (xc.SceneHelp)translator.FastGetCSObj(L, 1);
                LuaAPI.lua_pushstring(L, __cl_gen_to_be_invoked.CurSceneResPath);
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
			
                xc.SceneHelp __cl_gen_to_be_invoked = (xc.SceneHelp)translator.FastGetCSObj(L, 1);
                translator.Push(L, __cl_gen_to_be_invoked.MapInfo);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_WillSwitchScene(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.SceneHelp __cl_gen_to_be_invoked = (xc.SceneHelp)translator.FastGetCSObj(L, 1);
                LuaAPI.lua_pushboolean(L, __cl_gen_to_be_invoked.WillSwitchScene);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_IsAutoFightingAfterSwitchInstance(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.SceneHelp __cl_gen_to_be_invoked = (xc.SceneHelp)translator.FastGetCSObj(L, 1);
                LuaAPI.lua_pushboolean(L, __cl_gen_to_be_invoked.IsAutoFightingAfterSwitchInstance);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_IsAutoFightingWhenShowExitTips(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.SceneHelp __cl_gen_to_be_invoked = (xc.SceneHelp)translator.FastGetCSObj(L, 1);
                LuaAPI.lua_pushboolean(L, __cl_gen_to_be_invoked.IsAutoFightingWhenShowExitTips);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_CurSceneID(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.SceneHelp __cl_gen_to_be_invoked = (xc.SceneHelp)translator.FastGetCSObj(L, 1);
                LuaAPI.xlua_pushuint(L, __cl_gen_to_be_invoked.CurSceneID);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_PreSceneID(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.SceneHelp __cl_gen_to_be_invoked = (xc.SceneHelp)translator.FastGetCSObj(L, 1);
                LuaAPI.xlua_pushuint(L, __cl_gen_to_be_invoked.PreSceneID);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_CanHidePlayer(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.SceneHelp __cl_gen_to_be_invoked = (xc.SceneHelp)translator.FastGetCSObj(L, 1);
                LuaAPI.lua_pushboolean(L, __cl_gen_to_be_invoked.CanHidePlayer);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_PrecedentPlayer(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.SceneHelp __cl_gen_to_be_invoked = (xc.SceneHelp)translator.FastGetCSObj(L, 1);
                LuaAPI.lua_pushboolean(L, __cl_gen_to_be_invoked.PrecedentPlayer);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_PKLevelLimit(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.SceneHelp __cl_gen_to_be_invoked = (xc.SceneHelp)translator.FastGetCSObj(L, 1);
                LuaAPI.lua_pushboolean(L, __cl_gen_to_be_invoked.PKLevelLimit);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_IgnoreClickPlayer(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.SceneHelp __cl_gen_to_be_invoked = (xc.SceneHelp)translator.FastGetCSObj(L, 1);
                LuaAPI.lua_pushboolean(L, __cl_gen_to_be_invoked.IgnoreClickPlayer);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_ForceShowHpBar(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.SceneHelp __cl_gen_to_be_invoked = (xc.SceneHelp)translator.FastGetCSObj(L, 1);
                LuaAPI.lua_pushboolean(L, __cl_gen_to_be_invoked.ForceShowHpBar);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_ForbidChangePkMode(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.SceneHelp __cl_gen_to_be_invoked = (xc.SceneHelp)translator.FastGetCSObj(L, 1);
                LuaAPI.lua_pushboolean(L, __cl_gen_to_be_invoked.ForbidChangePkMode);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_ShowDanmakuSwitch(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.SceneHelp __cl_gen_to_be_invoked = (xc.SceneHelp)translator.FastGetCSObj(L, 1);
                LuaAPI.lua_pushboolean(L, __cl_gen_to_be_invoked.ShowDanmakuSwitch);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_ForbidOpenWorldMap(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.SceneHelp __cl_gen_to_be_invoked = (xc.SceneHelp)translator.FastGetCSObj(L, 1);
                LuaAPI.lua_pushboolean(L, __cl_gen_to_be_invoked.ForbidOpenWorldMap);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_ForbidTeam(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.SceneHelp __cl_gen_to_be_invoked = (xc.SceneHelp)translator.FastGetCSObj(L, 1);
                LuaAPI.lua_pushboolean(L, __cl_gen_to_be_invoked.ForbidTeam);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_IsKungfuInstance(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.SceneHelp __cl_gen_to_be_invoked = (xc.SceneHelp)translator.FastGetCSObj(L, 1);
                LuaAPI.lua_pushboolean(L, __cl_gen_to_be_invoked.IsKungfuInstance);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_IsInGuildBossInstance(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.SceneHelp __cl_gen_to_be_invoked = (xc.SceneHelp)translator.FastGetCSObj(L, 1);
                LuaAPI.lua_pushboolean(L, __cl_gen_to_be_invoked.IsInGuildBossInstance);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_IsInDeadSpaceInstance(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.SceneHelp __cl_gen_to_be_invoked = (xc.SceneHelp)translator.FastGetCSObj(L, 1);
                LuaAPI.lua_pushboolean(L, __cl_gen_to_be_invoked.IsInDeadSpaceInstance);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_IsInTrialBossInstance(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.SceneHelp __cl_gen_to_be_invoked = (xc.SceneHelp)translator.FastGetCSObj(L, 1);
                LuaAPI.lua_pushboolean(L, __cl_gen_to_be_invoked.IsInTrialBossInstance);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_IsInPeakBossInstance(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.SceneHelp __cl_gen_to_be_invoked = (xc.SceneHelp)translator.FastGetCSObj(L, 1);
                LuaAPI.lua_pushboolean(L, __cl_gen_to_be_invoked.IsInPeakBossInstance);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_IsInSecretDefendInstance(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.SceneHelp __cl_gen_to_be_invoked = (xc.SceneHelp)translator.FastGetCSObj(L, 1);
                LuaAPI.lua_pushboolean(L, __cl_gen_to_be_invoked.IsInSecretDefendInstance);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_IsInSouthLandInstance(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.SceneHelp __cl_gen_to_be_invoked = (xc.SceneHelp)translator.FastGetCSObj(L, 1);
                LuaAPI.lua_pushboolean(L, __cl_gen_to_be_invoked.IsInSouthLandInstance);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_IsInElementAreaInstance(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.SceneHelp __cl_gen_to_be_invoked = (xc.SceneHelp)translator.FastGetCSObj(L, 1);
                LuaAPI.lua_pushboolean(L, __cl_gen_to_be_invoked.IsInElementAreaInstance);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_IsInBossHomeInstance(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.SceneHelp __cl_gen_to_be_invoked = (xc.SceneHelp)translator.FastGetCSObj(L, 1);
                LuaAPI.lua_pushboolean(L, __cl_gen_to_be_invoked.IsInBossHomeInstance);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_IsInDeedInheritInstance(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.SceneHelp __cl_gen_to_be_invoked = (xc.SceneHelp)translator.FastGetCSObj(L, 1);
                LuaAPI.lua_pushboolean(L, __cl_gen_to_be_invoked.IsInDeedInheritInstance);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_IsInFirstWorldBossInstance(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.SceneHelp __cl_gen_to_be_invoked = (xc.SceneHelp)translator.FastGetCSObj(L, 1);
                LuaAPI.lua_pushboolean(L, __cl_gen_to_be_invoked.IsInFirstWorldBossInstance);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_IsInFairyValleyInstance(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.SceneHelp __cl_gen_to_be_invoked = (xc.SceneHelp)translator.FastGetCSObj(L, 1);
                LuaAPI.lua_pushboolean(L, __cl_gen_to_be_invoked.IsInFairyValleyInstance);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_IsInWorshipMeetingInstance(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.SceneHelp __cl_gen_to_be_invoked = (xc.SceneHelp)translator.FastGetCSObj(L, 1);
                LuaAPI.lua_pushboolean(L, __cl_gen_to_be_invoked.IsInWorshipMeetingInstance);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_IsInCatchBossInstance(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.SceneHelp __cl_gen_to_be_invoked = (xc.SceneHelp)translator.FastGetCSObj(L, 1);
                LuaAPI.lua_pushboolean(L, __cl_gen_to_be_invoked.IsInCatchBossInstance);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_IsInWorldBossExperienceInstance(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.SceneHelp __cl_gen_to_be_invoked = (xc.SceneHelp)translator.FastGetCSObj(L, 1);
                LuaAPI.lua_pushboolean(L, __cl_gen_to_be_invoked.IsInWorldBossExperienceInstance);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_IsInWorldBossFirstInstance(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.SceneHelp __cl_gen_to_be_invoked = (xc.SceneHelp)translator.FastGetCSObj(L, 1);
                LuaAPI.lua_pushboolean(L, __cl_gen_to_be_invoked.IsInWorldBossFirstInstance);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_IsInPersonalBossInstance(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.SceneHelp __cl_gen_to_be_invoked = (xc.SceneHelp)translator.FastGetCSObj(L, 1);
                LuaAPI.lua_pushboolean(L, __cl_gen_to_be_invoked.IsInPersonalBossInstance);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_IsInLoveInstance(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.SceneHelp __cl_gen_to_be_invoked = (xc.SceneHelp)translator.FastGetCSObj(L, 1);
                LuaAPI.lua_pushboolean(L, __cl_gen_to_be_invoked.IsInLoveInstance);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_IsInWeddingInstance(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.SceneHelp __cl_gen_to_be_invoked = (xc.SceneHelp)translator.FastGetCSObj(L, 1);
                LuaAPI.lua_pushboolean(L, __cl_gen_to_be_invoked.IsInWeddingInstance);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_IsInInstance(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.SceneHelp __cl_gen_to_be_invoked = (xc.SceneHelp)translator.FastGetCSObj(L, 1);
                LuaAPI.lua_pushboolean(L, __cl_gen_to_be_invoked.IsInInstance);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_IsPlayingInstance(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.SceneHelp __cl_gen_to_be_invoked = (xc.SceneHelp)translator.FastGetCSObj(L, 1);
                LuaAPI.lua_pushboolean(L, __cl_gen_to_be_invoked.IsPlayingInstance);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_IsInGuildManor(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.SceneHelp __cl_gen_to_be_invoked = (xc.SceneHelp)translator.FastGetCSObj(L, 1);
                LuaAPI.lua_pushboolean(L, __cl_gen_to_be_invoked.IsInGuildManor);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_IsInDevilComeInstance(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.SceneHelp __cl_gen_to_be_invoked = (xc.SceneHelp)translator.FastGetCSObj(L, 1);
                LuaAPI.lua_pushboolean(L, __cl_gen_to_be_invoked.IsInDevilComeInstance);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_UsePKMode(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.SceneHelp __cl_gen_to_be_invoked = (xc.SceneHelp)translator.FastGetCSObj(L, 1);
                LuaAPI.lua_pushboolean(L, __cl_gen_to_be_invoked.UsePKMode);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_NoShowAtkCampTips(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.SceneHelp __cl_gen_to_be_invoked = (xc.SceneHelp)translator.FastGetCSObj(L, 1);
                LuaAPI.lua_pushboolean(L, __cl_gen_to_be_invoked.NoShowAtkCampTips);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_CanRide(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.SceneHelp __cl_gen_to_be_invoked = (xc.SceneHelp)translator.FastGetCSObj(L, 1);
                LuaAPI.lua_pushboolean(L, __cl_gen_to_be_invoked.CanRide);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_IsShowDungeonUI_inMainMap(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.SceneHelp __cl_gen_to_be_invoked = (xc.SceneHelp)translator.FastGetCSObj(L, 1);
                LuaAPI.lua_pushboolean(L, __cl_gen_to_be_invoked.IsShowDungeonUI_inMainMap);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_IsCanExitBtnInWild(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.SceneHelp __cl_gen_to_be_invoked = (xc.SceneHelp)translator.FastGetCSObj(L, 1);
                LuaAPI.lua_pushboolean(L, __cl_gen_to_be_invoked.IsCanExitBtnInWild);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_IsReEnterScene(RealStatePtr L)
        {
            
            try {
			    LuaAPI.lua_pushboolean(L, xc.SceneHelp.IsReEnterScene);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_IsSwitchingScene(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.SceneHelp __cl_gen_to_be_invoked = (xc.SceneHelp)translator.FastGetCSObj(L, 1);
                LuaAPI.lua_pushboolean(L, __cl_gen_to_be_invoked.IsSwitchingScene);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_IsLoadingQuadTreeScene(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.SceneHelp __cl_gen_to_be_invoked = (xc.SceneHelp)translator.FastGetCSObj(L, 1);
                translator.PushxcSceneHelpLoadQuadTreeSceneState(L, __cl_gen_to_be_invoked.IsLoadingQuadTreeScene);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_mLineInfos(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.SceneHelp __cl_gen_to_be_invoked = (xc.SceneHelp)translator.FastGetCSObj(L, 1);
                translator.Push(L, __cl_gen_to_be_invoked.mLineInfos);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_mChangeLineCDTime(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.SceneHelp __cl_gen_to_be_invoked = (xc.SceneHelp)translator.FastGetCSObj(L, 1);
                LuaAPI.xlua_pushuint(L, __cl_gen_to_be_invoked.mChangeLineCDTime);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_mDelyLineCdTime(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.SceneHelp __cl_gen_to_be_invoked = (xc.SceneHelp)translator.FastGetCSObj(L, 1);
                LuaAPI.lua_pushnumber(L, __cl_gen_to_be_invoked.mDelyLineCdTime);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_CurLine(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.SceneHelp __cl_gen_to_be_invoked = (xc.SceneHelp)translator.FastGetCSObj(L, 1);
                LuaAPI.xlua_pushuint(L, __cl_gen_to_be_invoked.CurLine);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_WillSwitchScene(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.SceneHelp __cl_gen_to_be_invoked = (xc.SceneHelp)translator.FastGetCSObj(L, 1);
                __cl_gen_to_be_invoked.WillSwitchScene = LuaAPI.lua_toboolean(L, 2);
            
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_IsAutoFightingAfterSwitchInstance(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.SceneHelp __cl_gen_to_be_invoked = (xc.SceneHelp)translator.FastGetCSObj(L, 1);
                __cl_gen_to_be_invoked.IsAutoFightingAfterSwitchInstance = LuaAPI.lua_toboolean(L, 2);
            
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_IsAutoFightingWhenShowExitTips(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.SceneHelp __cl_gen_to_be_invoked = (xc.SceneHelp)translator.FastGetCSObj(L, 1);
                __cl_gen_to_be_invoked.IsAutoFightingWhenShowExitTips = LuaAPI.lua_toboolean(L, 2);
            
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_CurSceneID(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.SceneHelp __cl_gen_to_be_invoked = (xc.SceneHelp)translator.FastGetCSObj(L, 1);
                __cl_gen_to_be_invoked.CurSceneID = LuaAPI.xlua_touint(L, 2);
            
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_PreSceneID(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.SceneHelp __cl_gen_to_be_invoked = (xc.SceneHelp)translator.FastGetCSObj(L, 1);
                __cl_gen_to_be_invoked.PreSceneID = LuaAPI.xlua_touint(L, 2);
            
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_IsSwitchingScene(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.SceneHelp __cl_gen_to_be_invoked = (xc.SceneHelp)translator.FastGetCSObj(L, 1);
                __cl_gen_to_be_invoked.IsSwitchingScene = LuaAPI.lua_toboolean(L, 2);
            
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_IsLoadingQuadTreeScene(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.SceneHelp __cl_gen_to_be_invoked = (xc.SceneHelp)translator.FastGetCSObj(L, 1);
                xc.SceneHelp.LoadQuadTreeSceneState __cl_gen_value;translator.Get(L, 2, out __cl_gen_value);
				__cl_gen_to_be_invoked.IsLoadingQuadTreeScene = __cl_gen_value;
            
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_mLineInfos(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.SceneHelp __cl_gen_to_be_invoked = (xc.SceneHelp)translator.FastGetCSObj(L, 1);
                __cl_gen_to_be_invoked.mLineInfos = (System.Collections.Generic.Dictionary<uint, uint>)translator.GetObject(L, 2, typeof(System.Collections.Generic.Dictionary<uint, uint>));
            
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_mChangeLineCDTime(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.SceneHelp __cl_gen_to_be_invoked = (xc.SceneHelp)translator.FastGetCSObj(L, 1);
                __cl_gen_to_be_invoked.mChangeLineCDTime = LuaAPI.xlua_touint(L, 2);
            
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_mDelyLineCdTime(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.SceneHelp __cl_gen_to_be_invoked = (xc.SceneHelp)translator.FastGetCSObj(L, 1);
                __cl_gen_to_be_invoked.mDelyLineCdTime = (float)LuaAPI.lua_tonumber(L, 2);
            
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_CurLine(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.SceneHelp __cl_gen_to_be_invoked = (xc.SceneHelp)translator.FastGetCSObj(L, 1);
                __cl_gen_to_be_invoked.CurLine = LuaAPI.xlua_touint(L, 2);
            
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 0;
        }
        
		
		
		
		
    }
}
