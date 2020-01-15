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
    public class xcGameWrap
    {
        public static void __Register(RealStatePtr L)
        {
			ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			XUtils.BeginObjectRegister(typeof(xc.Game), L, translator, 0, 34, 38, 18);
			
			XUtils.RegisterFunc(L, XUtils.METHOD_IDX, "GetScreenWidth", _m_GetScreenWidth);
			XUtils.RegisterFunc(L, XUtils.METHOD_IDX, "GetScreenHeight", _m_GetScreenHeight);
			XUtils.RegisterFunc(L, XUtils.METHOD_IDX, "GetCurStateId", _m_GetCurStateId);
			XUtils.RegisterFunc(L, XUtils.METHOD_IDX, "GetLoadAsyncOp", _m_GetLoadAsyncOp);
			XUtils.RegisterFunc(L, XUtils.METHOD_IDX, "SetLoadAsyncOp", _m_SetLoadAsyncOp);
			XUtils.RegisterFunc(L, XUtils.METHOD_IDX, "SetLocalPlayer", _m_SetLocalPlayer);
			XUtils.RegisterFunc(L, XUtils.METHOD_IDX, "GetLocalPlayer", _m_GetLocalPlayer);
			XUtils.RegisterFunc(L, XUtils.METHOD_IDX, "SubscribeNetNotify", _m_SubscribeNetNotify);
			XUtils.RegisterFunc(L, XUtils.METHOD_IDX, "UnsubscribeNetNotify", _m_UnsubscribeNetNotify);
			XUtils.RegisterFunc(L, XUtils.METHOD_IDX, "SubscribeLuaNetNotify", _m_SubscribeLuaNetNotify);
			XUtils.RegisterFunc(L, XUtils.METHOD_IDX, "UnsubscribeLuaNetNotify", _m_UnsubscribeLuaNetNotify);
			XUtils.RegisterFunc(L, XUtils.METHOD_IDX, "Quit", _m_Quit);
			XUtils.RegisterFunc(L, XUtils.METHOD_IDX, "Init", _m_Init);
			XUtils.RegisterFunc(L, XUtils.METHOD_IDX, "OnLog", _m_OnLog);
			XUtils.RegisterFunc(L, XUtils.METHOD_IDX, "Reset", _m_Reset);
			XUtils.RegisterFunc(L, XUtils.METHOD_IDX, "IsNetMode", _m_IsNetMode);
			XUtils.RegisterFunc(L, XUtils.METHOD_IDX, "GetFSM", _m_GetFSM);
			XUtils.RegisterFunc(L, XUtils.METHOD_IDX, "InitFSM", _m_InitFSM);
			XUtils.RegisterFunc(L, XUtils.METHOD_IDX, "Update", _m_Update);
			XUtils.RegisterFunc(L, XUtils.METHOD_IDX, "Rebot", _m_Rebot);
			XUtils.RegisterFunc(L, XUtils.METHOD_IDX, "RebotWithoutSdkLogout", _m_RebotWithoutSdkLogout);
			XUtils.RegisterFunc(L, XUtils.METHOD_IDX, "ChangeRole", _m_ChangeRole);
			XUtils.RegisterFunc(L, XUtils.METHOD_IDX, "TimeZoneHour", _m_TimeZoneHour);
			XUtils.RegisterFunc(L, XUtils.METHOD_IDX, "TimeZoneMin", _m_TimeZoneMin);
			XUtils.RegisterFunc(L, XUtils.METHOD_IDX, "GetOpenDay", _m_GetOpenDay);
			XUtils.RegisterFunc(L, XUtils.METHOD_IDX, "OnNetConnect", _m_OnNetConnect);
			XUtils.RegisterFunc(L, XUtils.METHOD_IDX, "OnNetDisconnect", _m_OnNetDisconnect);
			XUtils.RegisterFunc(L, XUtils.METHOD_IDX, "OnNetDataReply", _m_OnNetDataReply);
			XUtils.RegisterFunc(L, XUtils.METHOD_IDX, "ProcessServerData", _m_ProcessServerData);
			XUtils.RegisterFunc(L, XUtils.METHOD_IDX, "HandleServerData", _m_HandleServerData);
			XUtils.RegisterFunc(L, XUtils.METHOD_IDX, "Login", _m_Login);
			XUtils.RegisterFunc(L, XUtils.METHOD_IDX, "StopNetClient", _m_StopNetClient);
			XUtils.RegisterFunc(L, XUtils.METHOD_IDX, "GetServerDateTime", _m_GetServerDateTime);
			XUtils.RegisterFunc(L, XUtils.METHOD_IDX, "CancelQueueTime", _m_CancelQueueTime);
			
			
			XUtils.RegisterFunc(L, XUtils.GETTER_IDX, "IsRebooting", _g_get_IsRebooting);
            XUtils.RegisterFunc(L, XUtils.GETTER_IDX, "ManualCancelReconnect", _g_get_ManualCancelReconnect);
            XUtils.RegisterFunc(L, XUtils.GETTER_IDX, "MainCamera", _g_get_MainCamera);
            XUtils.RegisterFunc(L, XUtils.GETTER_IDX, "CameraControl", _g_get_CameraControl);
            XUtils.RegisterFunc(L, XUtils.GETTER_IDX, "GameObjectControl", _g_get_GameObjectControl);
            XUtils.RegisterFunc(L, XUtils.GETTER_IDX, "AccountIdx", _g_get_AccountIdx);
            XUtils.RegisterFunc(L, XUtils.GETTER_IDX, "CharacterList", _g_get_CharacterList);
            XUtils.RegisterFunc(L, XUtils.GETTER_IDX, "CharactorMaxCount", _g_get_CharactorMaxCount);
            XUtils.RegisterFunc(L, XUtils.GETTER_IDX, "LocalPlayerID", _g_get_LocalPlayerID);
            XUtils.RegisterFunc(L, XUtils.GETTER_IDX, "LocalPlayerName", _g_get_LocalPlayerName);
            XUtils.RegisterFunc(L, XUtils.GETTER_IDX, "LocalPlayerTypeID", _g_get_LocalPlayerTypeID);
            XUtils.RegisterFunc(L, XUtils.GETTER_IDX, "LocalPlayerVocation", _g_get_LocalPlayerVocation);
            XUtils.RegisterFunc(L, XUtils.GETTER_IDX, "LocalPlayerRadius", _g_get_LocalPlayerRadius);
            XUtils.RegisterFunc(L, XUtils.GETTER_IDX, "LocalPlayerAOIInfo", _g_get_LocalPlayerAOIInfo);
            XUtils.RegisterFunc(L, XUtils.GETTER_IDX, "IsSwitchingScene", _g_get_IsSwitchingScene);
            XUtils.RegisterFunc(L, XUtils.GETTER_IDX, "IsCreateRoleEnter", _g_get_IsCreateRoleEnter);
            XUtils.RegisterFunc(L, XUtils.GETTER_IDX, "Connected", _g_get_Connected);
            XUtils.RegisterFunc(L, XUtils.GETTER_IDX, "Converted", _g_get_Converted);
            XUtils.RegisterFunc(L, XUtils.GETTER_IDX, "ServerOpenTime", _g_get_ServerOpenTime);
            XUtils.RegisterFunc(L, XUtils.GETTER_IDX, "ServerOpenDateTime", _g_get_ServerOpenDateTime);
            XUtils.RegisterFunc(L, XUtils.GETTER_IDX, "TimeZone", _g_get_TimeZone);
            XUtils.RegisterFunc(L, XUtils.GETTER_IDX, "MergeServerTime", _g_get_MergeServerTime);
            XUtils.RegisterFunc(L, XUtils.GETTER_IDX, "MergeServerDateTime", _g_get_MergeServerDateTime);
            XUtils.RegisterFunc(L, XUtils.GETTER_IDX, "AllSystemInited", _g_get_AllSystemInited);
            XUtils.RegisterFunc(L, XUtils.GETTER_IDX, "QueueMax", _g_get_QueueMax);
            XUtils.RegisterFunc(L, XUtils.GETTER_IDX, "LoginConflict", _g_get_LoginConflict);
            XUtils.RegisterFunc(L, XUtils.GETTER_IDX, "MaintainServer", _g_get_MaintainServer);
            XUtils.RegisterFunc(L, XUtils.GETTER_IDX, "ForceDisconnect", _g_get_ForceDisconnect);
            XUtils.RegisterFunc(L, XUtils.GETTER_IDX, "ServerTime", _g_get_ServerTime);
            XUtils.RegisterFunc(L, XUtils.GETTER_IDX, "IsSkillEditorScene", _g_get_IsSkillEditorScene);
            XUtils.RegisterFunc(L, XUtils.GETTER_IDX, "GameMode", _g_get_GameMode);
            XUtils.RegisterFunc(L, XUtils.GETTER_IDX, "ServerIP", _g_get_ServerIP);
            XUtils.RegisterFunc(L, XUtils.GETTER_IDX, "ServerPort", _g_get_ServerPort);
            XUtils.RegisterFunc(L, XUtils.GETTER_IDX, "Account", _g_get_Account);
            XUtils.RegisterFunc(L, XUtils.GETTER_IDX, "Password", _g_get_Password);
            XUtils.RegisterFunc(L, XUtils.GETTER_IDX, "ServerID", _g_get_ServerID);
            XUtils.RegisterFunc(L, XUtils.GETTER_IDX, "mIsInited", _g_get_mIsInited);
            XUtils.RegisterFunc(L, XUtils.GETTER_IDX, "IsEnterGame", _g_get_IsEnterGame);
            
			XUtils.RegisterFunc(L, XUtils.SETTER_IDX, "IsRebooting", _s_set_IsRebooting);
            XUtils.RegisterFunc(L, XUtils.SETTER_IDX, "ManualCancelReconnect", _s_set_ManualCancelReconnect);
            XUtils.RegisterFunc(L, XUtils.SETTER_IDX, "LocalPlayerID", _s_set_LocalPlayerID);
            XUtils.RegisterFunc(L, XUtils.SETTER_IDX, "LocalPlayerName", _s_set_LocalPlayerName);
            XUtils.RegisterFunc(L, XUtils.SETTER_IDX, "LocalPlayerTypeID", _s_set_LocalPlayerTypeID);
            XUtils.RegisterFunc(L, XUtils.SETTER_IDX, "LocalPlayerRadius", _s_set_LocalPlayerRadius);
            XUtils.RegisterFunc(L, XUtils.SETTER_IDX, "LocalPlayerAOIInfo", _s_set_LocalPlayerAOIInfo);
            XUtils.RegisterFunc(L, XUtils.SETTER_IDX, "IsSwitchingScene", _s_set_IsSwitchingScene);
            XUtils.RegisterFunc(L, XUtils.SETTER_IDX, "IsCreateRoleEnter", _s_set_IsCreateRoleEnter);
            XUtils.RegisterFunc(L, XUtils.SETTER_IDX, "IsSkillEditorScene", _s_set_IsSkillEditorScene);
            XUtils.RegisterFunc(L, XUtils.SETTER_IDX, "GameMode", _s_set_GameMode);
            XUtils.RegisterFunc(L, XUtils.SETTER_IDX, "ServerIP", _s_set_ServerIP);
            XUtils.RegisterFunc(L, XUtils.SETTER_IDX, "ServerPort", _s_set_ServerPort);
            XUtils.RegisterFunc(L, XUtils.SETTER_IDX, "Account", _s_set_Account);
            XUtils.RegisterFunc(L, XUtils.SETTER_IDX, "Password", _s_set_Password);
            XUtils.RegisterFunc(L, XUtils.SETTER_IDX, "ServerID", _s_set_ServerID);
            XUtils.RegisterFunc(L, XUtils.SETTER_IDX, "mIsInited", _s_set_mIsInited);
            XUtils.RegisterFunc(L, XUtils.SETTER_IDX, "IsEnterGame", _s_set_IsEnterGame);
            
			XUtils.EndObjectRegister(typeof(xc.Game), L, translator, null, null,
			    null, null, null);

		    XUtils.BeginClassRegister(typeof(xc.Game), L, __CreateInstance, 3, 1, 0);
			XUtils.RegisterFunc(L, XUtils.CLS_IDX, "GetInstance", _m_GetInstance_xlua_st_);
            XUtils.RegisterFunc(L, XUtils.CLS_IDX, "WaitForSceneLoadAsyncOp", _m_WaitForSceneLoadAsyncOp_xlua_st_);
            
			
            
            XUtils.RegisterObject(L, translator, XUtils.CLS_IDX, "UnderlyingSystemType", typeof(xc.Game));
			XUtils.RegisterFunc(L, XUtils.CLS_GETTER_IDX, "Instance", _g_get_Instance);
            
			
			XUtils.EndClassRegister(typeof(xc.Game), L, translator);
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int __CreateInstance(RealStatePtr L)
        {
            return LuaAPI.luaL_error(L, "xc.Game does not have a constructor!");
        }
        
		
        
		
        
        
        
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_GetScreenWidth(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            xc.Game __cl_gen_to_be_invoked = (xc.Game)translator.FastGetCSObj(L, 1);
            
            
            try {
                
                {
                    
                        int __cl_gen_ret = __cl_gen_to_be_invoked.GetScreenWidth(  );
                        LuaAPI.xlua_pushinteger(L, __cl_gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_GetScreenHeight(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            xc.Game __cl_gen_to_be_invoked = (xc.Game)translator.FastGetCSObj(L, 1);
            
            
            try {
                
                {
                    
                        int __cl_gen_ret = __cl_gen_to_be_invoked.GetScreenHeight(  );
                        LuaAPI.xlua_pushinteger(L, __cl_gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_GetInstance_xlua_st_(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            
            try {
                
                {
                    
                        xc.Game __cl_gen_ret = xc.Game.GetInstance(  );
                        translator.Push(L, __cl_gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_GetCurStateId(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            xc.Game __cl_gen_to_be_invoked = (xc.Game)translator.FastGetCSObj(L, 1);
            
            
            try {
                
                {
                    
                        uint __cl_gen_ret = __cl_gen_to_be_invoked.GetCurStateId(  );
                        LuaAPI.xlua_pushuint(L, __cl_gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_GetLoadAsyncOp(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            xc.Game __cl_gen_to_be_invoked = (xc.Game)translator.FastGetCSObj(L, 1);
            
            
            try {
                
                {
                    
                        UnityEngine.AsyncOperation __cl_gen_ret = __cl_gen_to_be_invoked.GetLoadAsyncOp(  );
                        translator.Push(L, __cl_gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_SetLoadAsyncOp(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            xc.Game __cl_gen_to_be_invoked = (xc.Game)translator.FastGetCSObj(L, 1);
            
            
            try {
                
                {
                    UnityEngine.AsyncOperation op = (UnityEngine.AsyncOperation)translator.GetObject(L, 2, typeof(UnityEngine.AsyncOperation));
                    
                    __cl_gen_to_be_invoked.SetLoadAsyncOp( op );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_SetLocalPlayer(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            xc.Game __cl_gen_to_be_invoked = (xc.Game)translator.FastGetCSObj(L, 1);
            
            
            try {
                
                {
                    Actor player = (Actor)translator.GetObject(L, 2, typeof(Actor));
                    
                    __cl_gen_to_be_invoked.SetLocalPlayer( player );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_GetLocalPlayer(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            xc.Game __cl_gen_to_be_invoked = (xc.Game)translator.FastGetCSObj(L, 1);
            
            
            try {
                
                {
                    
                        Actor __cl_gen_ret = __cl_gen_to_be_invoked.GetLocalPlayer(  );
                        translator.Push(L, __cl_gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_SubscribeNetNotify(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            xc.Game __cl_gen_to_be_invoked = (xc.Game)translator.FastGetCSObj(L, 1);
            
            
            try {
                
                {
                    ushort protocol = (ushort)LuaAPI.xlua_tointeger(L, 2);
                    xc.Game.DataReplyDelegate func = translator.GetDelegate<xc.Game.DataReplyDelegate>(L, 3);
                    
                    __cl_gen_to_be_invoked.SubscribeNetNotify( protocol, func );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_UnsubscribeNetNotify(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            xc.Game __cl_gen_to_be_invoked = (xc.Game)translator.FastGetCSObj(L, 1);
            
            
            try {
                
                {
                    ushort protocol = (ushort)LuaAPI.xlua_tointeger(L, 2);
                    xc.Game.DataReplyDelegate func = translator.GetDelegate<xc.Game.DataReplyDelegate>(L, 3);
                    
                    __cl_gen_to_be_invoked.UnsubscribeNetNotify( protocol, func );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_SubscribeLuaNetNotify(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            xc.Game __cl_gen_to_be_invoked = (xc.Game)translator.FastGetCSObj(L, 1);
            
            
            try {
                
                {
                    ushort protocol = (ushort)LuaAPI.xlua_tointeger(L, 2);
                    xc.Game.DataReplyDelegate func = translator.GetDelegate<xc.Game.DataReplyDelegate>(L, 3);
                    
                    __cl_gen_to_be_invoked.SubscribeLuaNetNotify( protocol, func );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_UnsubscribeLuaNetNotify(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            xc.Game __cl_gen_to_be_invoked = (xc.Game)translator.FastGetCSObj(L, 1);
            
            
            try {
                
                {
                    ushort protocol = (ushort)LuaAPI.xlua_tointeger(L, 2);
                    xc.Game.DataReplyDelegate func = translator.GetDelegate<xc.Game.DataReplyDelegate>(L, 3);
                    
                    __cl_gen_to_be_invoked.UnsubscribeLuaNetNotify( protocol, func );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_Quit(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            xc.Game __cl_gen_to_be_invoked = (xc.Game)translator.FastGetCSObj(L, 1);
            
            
            try {
                
                {
                    bool callApplicationQuit = LuaAPI.lua_toboolean(L, 2);
                    
                    __cl_gen_to_be_invoked.Quit( callApplicationQuit );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_Init(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            xc.Game __cl_gen_to_be_invoked = (xc.Game)translator.FastGetCSObj(L, 1);
            
            
            try {
                
                {
                    
                    __cl_gen_to_be_invoked.Init(  );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_OnLog(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            xc.Game __cl_gen_to_be_invoked = (xc.Game)translator.FastGetCSObj(L, 1);
            
            
            try {
                
                {
                    string log = LuaAPI.lua_tostring(L, 2);
                    string stackTrace = LuaAPI.lua_tostring(L, 3);
                    UnityEngine.LogType type;translator.Get(L, 4, out type);
                    
                    __cl_gen_to_be_invoked.OnLog( log, stackTrace, type );
                    
                    
                    
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
            
            
            xc.Game __cl_gen_to_be_invoked = (xc.Game)translator.FastGetCSObj(L, 1);
            
            
			int __gen_param_count = LuaAPI.lua_gettop(L);
            
            try {
                if(__gen_param_count == 2&& LuaTypes.LUA_TBOOLEAN == LuaAPI.lua_type(L, 2)) 
                {
                    bool ignore_reconnect = LuaAPI.lua_toboolean(L, 2);
                    
                    __cl_gen_to_be_invoked.Reset( ignore_reconnect );
                    
                    
                    
                    return 0;
                }
                if(__gen_param_count == 1) 
                {
                    
                    __cl_gen_to_be_invoked.Reset(  );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
            return LuaAPI.luaL_error(L, "invalid arguments to xc.Game.Reset!");
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_IsNetMode(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            xc.Game __cl_gen_to_be_invoked = (xc.Game)translator.FastGetCSObj(L, 1);
            
            
            try {
                
                {
                    
                        bool __cl_gen_ret = __cl_gen_to_be_invoked.IsNetMode(  );
                        LuaAPI.lua_pushboolean(L, __cl_gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_GetFSM(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            xc.Game __cl_gen_to_be_invoked = (xc.Game)translator.FastGetCSObj(L, 1);
            
            
            try {
                
                {
                    
                        xc.Machine __cl_gen_ret = __cl_gen_to_be_invoked.GetFSM(  );
                        translator.Push(L, __cl_gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_InitFSM(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            xc.Game __cl_gen_to_be_invoked = (xc.Game)translator.FastGetCSObj(L, 1);
            
            
            try {
                
                {
                    
                        xc.Machine.State __cl_gen_ret = __cl_gen_to_be_invoked.InitFSM(  );
                        translator.Push(L, __cl_gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_Update(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            xc.Game __cl_gen_to_be_invoked = (xc.Game)translator.FastGetCSObj(L, 1);
            
            
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
        static int _m_WaitForSceneLoadAsyncOp_xlua_st_(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            
            try {
                
                {
                    
                        System.Collections.IEnumerator __cl_gen_ret = xc.Game.WaitForSceneLoadAsyncOp(  );
                        translator.Push(L, __cl_gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_Rebot(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            xc.Game __cl_gen_to_be_invoked = (xc.Game)translator.FastGetCSObj(L, 1);
            
            
            try {
                
                {
                    
                    __cl_gen_to_be_invoked.Rebot(  );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_RebotWithoutSdkLogout(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            xc.Game __cl_gen_to_be_invoked = (xc.Game)translator.FastGetCSObj(L, 1);
            
            
            try {
                
                {
                    
                    __cl_gen_to_be_invoked.RebotWithoutSdkLogout(  );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_ChangeRole(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            xc.Game __cl_gen_to_be_invoked = (xc.Game)translator.FastGetCSObj(L, 1);
            
            
            try {
                
                {
                    
                    __cl_gen_to_be_invoked.ChangeRole(  );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_TimeZoneHour(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            xc.Game __cl_gen_to_be_invoked = (xc.Game)translator.FastGetCSObj(L, 1);
            
            
            try {
                
                {
                    
                        int __cl_gen_ret = __cl_gen_to_be_invoked.TimeZoneHour(  );
                        LuaAPI.xlua_pushinteger(L, __cl_gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_TimeZoneMin(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            xc.Game __cl_gen_to_be_invoked = (xc.Game)translator.FastGetCSObj(L, 1);
            
            
            try {
                
                {
                    
                        int __cl_gen_ret = __cl_gen_to_be_invoked.TimeZoneMin(  );
                        LuaAPI.xlua_pushinteger(L, __cl_gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_GetOpenDay(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            xc.Game __cl_gen_to_be_invoked = (xc.Game)translator.FastGetCSObj(L, 1);
            
            
            try {
                
                {
                    
                        int __cl_gen_ret = __cl_gen_to_be_invoked.GetOpenDay(  );
                        LuaAPI.xlua_pushinteger(L, __cl_gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_OnNetConnect(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            xc.Game __cl_gen_to_be_invoked = (xc.Game)translator.FastGetCSObj(L, 1);
            
            
            try {
                
                {
                    Net.NetType netType;translator.Get(L, 2, out netType);
                    
                    __cl_gen_to_be_invoked.OnNetConnect( netType );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_OnNetDisconnect(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            xc.Game __cl_gen_to_be_invoked = (xc.Game)translator.FastGetCSObj(L, 1);
            
            
            try {
                
                {
                    Net.NetType netType;translator.Get(L, 2, out netType);
                    int e = LuaAPI.xlua_tointeger(L, 3);
                    
                    __cl_gen_to_be_invoked.OnNetDisconnect( netType, e );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_OnNetDataReply(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            xc.Game __cl_gen_to_be_invoked = (xc.Game)translator.FastGetCSObj(L, 1);
            
            
            try {
                
                {
                    Net.NetType netType;translator.Get(L, 2, out netType);
                    ushort protocol = (ushort)LuaAPI.xlua_tointeger(L, 3);
                    byte[] data = LuaAPI.lua_tobytes(L, 4);
                    
                    __cl_gen_to_be_invoked.OnNetDataReply( netType, protocol, data );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_ProcessServerData(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            xc.Game __cl_gen_to_be_invoked = (xc.Game)translator.FastGetCSObj(L, 1);
            
            
            try {
                
                {
                    ushort protocol = (ushort)LuaAPI.xlua_tointeger(L, 2);
                    byte[] data = LuaAPI.lua_tobytes(L, 3);
                    
                    __cl_gen_to_be_invoked.ProcessServerData( protocol, data );
                    
                    
                    
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
            
            
            xc.Game __cl_gen_to_be_invoked = (xc.Game)translator.FastGetCSObj(L, 1);
            
            
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
        static int _m_Login(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            xc.Game __cl_gen_to_be_invoked = (xc.Game)translator.FastGetCSObj(L, 1);
            
            
			int __gen_param_count = LuaAPI.lua_gettop(L);
            
            try {
                if(__gen_param_count == 1) 
                {
                    
                    __cl_gen_to_be_invoked.Login(  );
                    
                    
                    
                    return 0;
                }
                if(__gen_param_count == 3&& (LuaAPI.lua_isnil(L, 2) || LuaAPI.lua_type(L, 2) == LuaTypes.LUA_TSTRING)&& LuaTypes.LUA_TNUMBER == LuaAPI.lua_type(L, 3)) 
                {
                    string ip = LuaAPI.lua_tostring(L, 2);
                    int port = LuaAPI.xlua_tointeger(L, 3);
                    
                    __cl_gen_to_be_invoked.Login( ip, port );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
            return LuaAPI.luaL_error(L, "invalid arguments to xc.Game.Login!");
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_StopNetClient(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            xc.Game __cl_gen_to_be_invoked = (xc.Game)translator.FastGetCSObj(L, 1);
            
            
            try {
                
                {
                    
                    __cl_gen_to_be_invoked.StopNetClient(  );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_GetServerDateTime(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            xc.Game __cl_gen_to_be_invoked = (xc.Game)translator.FastGetCSObj(L, 1);
            
            
            try {
                
                {
                    
                        System.DateTime __cl_gen_ret = __cl_gen_to_be_invoked.GetServerDateTime(  );
                        translator.Push(L, __cl_gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_CancelQueueTime(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            xc.Game __cl_gen_to_be_invoked = (xc.Game)translator.FastGetCSObj(L, 1);
            
            
            try {
                
                {
                    
                    __cl_gen_to_be_invoked.CancelQueueTime(  );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        
        
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_IsRebooting(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.Game __cl_gen_to_be_invoked = (xc.Game)translator.FastGetCSObj(L, 1);
                LuaAPI.lua_pushboolean(L, __cl_gen_to_be_invoked.IsRebooting);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_ManualCancelReconnect(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.Game __cl_gen_to_be_invoked = (xc.Game)translator.FastGetCSObj(L, 1);
                LuaAPI.lua_pushboolean(L, __cl_gen_to_be_invoked.ManualCancelReconnect);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_MainCamera(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.Game __cl_gen_to_be_invoked = (xc.Game)translator.FastGetCSObj(L, 1);
                translator.Push(L, __cl_gen_to_be_invoked.MainCamera);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_CameraControl(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.Game __cl_gen_to_be_invoked = (xc.Game)translator.FastGetCSObj(L, 1);
                translator.Push(L, __cl_gen_to_be_invoked.CameraControl);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_GameObjectControl(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.Game __cl_gen_to_be_invoked = (xc.Game)translator.FastGetCSObj(L, 1);
                translator.Push(L, __cl_gen_to_be_invoked.GameObjectControl);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_AccountIdx(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.Game __cl_gen_to_be_invoked = (xc.Game)translator.FastGetCSObj(L, 1);
                LuaAPI.xlua_pushinteger(L, __cl_gen_to_be_invoked.AccountIdx);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_CharacterList(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.Game __cl_gen_to_be_invoked = (xc.Game)translator.FastGetCSObj(L, 1);
                translator.Push(L, __cl_gen_to_be_invoked.CharacterList);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_CharactorMaxCount(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.Game __cl_gen_to_be_invoked = (xc.Game)translator.FastGetCSObj(L, 1);
                LuaAPI.xlua_pushinteger(L, __cl_gen_to_be_invoked.CharactorMaxCount);
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
			    translator.Push(L, xc.Game.Instance);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_LocalPlayerID(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.Game __cl_gen_to_be_invoked = (xc.Game)translator.FastGetCSObj(L, 1);
                translator.Push(L, __cl_gen_to_be_invoked.LocalPlayerID);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_LocalPlayerName(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.Game __cl_gen_to_be_invoked = (xc.Game)translator.FastGetCSObj(L, 1);
                LuaAPI.lua_pushstring(L, __cl_gen_to_be_invoked.LocalPlayerName);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_LocalPlayerTypeID(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.Game __cl_gen_to_be_invoked = (xc.Game)translator.FastGetCSObj(L, 1);
                LuaAPI.xlua_pushuint(L, __cl_gen_to_be_invoked.LocalPlayerTypeID);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_LocalPlayerVocation(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.Game __cl_gen_to_be_invoked = (xc.Game)translator.FastGetCSObj(L, 1);
                LuaAPI.xlua_pushuint(L, __cl_gen_to_be_invoked.LocalPlayerVocation);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_LocalPlayerRadius(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.Game __cl_gen_to_be_invoked = (xc.Game)translator.FastGetCSObj(L, 1);
                LuaAPI.lua_pushnumber(L, __cl_gen_to_be_invoked.LocalPlayerRadius);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_LocalPlayerAOIInfo(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.Game __cl_gen_to_be_invoked = (xc.Game)translator.FastGetCSObj(L, 1);
                translator.Push(L, __cl_gen_to_be_invoked.LocalPlayerAOIInfo);
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
			
                xc.Game __cl_gen_to_be_invoked = (xc.Game)translator.FastGetCSObj(L, 1);
                LuaAPI.lua_pushboolean(L, __cl_gen_to_be_invoked.IsSwitchingScene);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_IsCreateRoleEnter(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.Game __cl_gen_to_be_invoked = (xc.Game)translator.FastGetCSObj(L, 1);
                LuaAPI.lua_pushboolean(L, __cl_gen_to_be_invoked.IsCreateRoleEnter);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_Connected(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.Game __cl_gen_to_be_invoked = (xc.Game)translator.FastGetCSObj(L, 1);
                LuaAPI.lua_pushboolean(L, __cl_gen_to_be_invoked.Connected);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_Converted(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.Game __cl_gen_to_be_invoked = (xc.Game)translator.FastGetCSObj(L, 1);
                translator.Push(L, __cl_gen_to_be_invoked.Converted);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_ServerOpenTime(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.Game __cl_gen_to_be_invoked = (xc.Game)translator.FastGetCSObj(L, 1);
                LuaAPI.xlua_pushuint(L, __cl_gen_to_be_invoked.ServerOpenTime);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_ServerOpenDateTime(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.Game __cl_gen_to_be_invoked = (xc.Game)translator.FastGetCSObj(L, 1);
                translator.Push(L, __cl_gen_to_be_invoked.ServerOpenDateTime);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_TimeZone(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.Game __cl_gen_to_be_invoked = (xc.Game)translator.FastGetCSObj(L, 1);
                LuaAPI.xlua_pushinteger(L, __cl_gen_to_be_invoked.TimeZone);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_MergeServerTime(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.Game __cl_gen_to_be_invoked = (xc.Game)translator.FastGetCSObj(L, 1);
                LuaAPI.xlua_pushuint(L, __cl_gen_to_be_invoked.MergeServerTime);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_MergeServerDateTime(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.Game __cl_gen_to_be_invoked = (xc.Game)translator.FastGetCSObj(L, 1);
                translator.Push(L, __cl_gen_to_be_invoked.MergeServerDateTime);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_AllSystemInited(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.Game __cl_gen_to_be_invoked = (xc.Game)translator.FastGetCSObj(L, 1);
                LuaAPI.lua_pushboolean(L, __cl_gen_to_be_invoked.AllSystemInited);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_QueueMax(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.Game __cl_gen_to_be_invoked = (xc.Game)translator.FastGetCSObj(L, 1);
                LuaAPI.lua_pushboolean(L, __cl_gen_to_be_invoked.QueueMax);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_LoginConflict(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.Game __cl_gen_to_be_invoked = (xc.Game)translator.FastGetCSObj(L, 1);
                LuaAPI.lua_pushboolean(L, __cl_gen_to_be_invoked.LoginConflict);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_MaintainServer(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.Game __cl_gen_to_be_invoked = (xc.Game)translator.FastGetCSObj(L, 1);
                LuaAPI.lua_pushboolean(L, __cl_gen_to_be_invoked.MaintainServer);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_ForceDisconnect(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.Game __cl_gen_to_be_invoked = (xc.Game)translator.FastGetCSObj(L, 1);
                LuaAPI.lua_pushboolean(L, __cl_gen_to_be_invoked.ForceDisconnect);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_ServerTime(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.Game __cl_gen_to_be_invoked = (xc.Game)translator.FastGetCSObj(L, 1);
                LuaAPI.xlua_pushuint(L, __cl_gen_to_be_invoked.ServerTime);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_IsSkillEditorScene(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.Game __cl_gen_to_be_invoked = (xc.Game)translator.FastGetCSObj(L, 1);
                LuaAPI.lua_pushboolean(L, __cl_gen_to_be_invoked.IsSkillEditorScene);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_GameMode(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.Game __cl_gen_to_be_invoked = (xc.Game)translator.FastGetCSObj(L, 1);
                translator.PushxcGameEGameMode(L, __cl_gen_to_be_invoked.GameMode);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_ServerIP(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.Game __cl_gen_to_be_invoked = (xc.Game)translator.FastGetCSObj(L, 1);
                LuaAPI.lua_pushstring(L, __cl_gen_to_be_invoked.ServerIP);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_ServerPort(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.Game __cl_gen_to_be_invoked = (xc.Game)translator.FastGetCSObj(L, 1);
                LuaAPI.xlua_pushinteger(L, __cl_gen_to_be_invoked.ServerPort);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_Account(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.Game __cl_gen_to_be_invoked = (xc.Game)translator.FastGetCSObj(L, 1);
                LuaAPI.lua_pushstring(L, __cl_gen_to_be_invoked.Account);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_Password(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.Game __cl_gen_to_be_invoked = (xc.Game)translator.FastGetCSObj(L, 1);
                LuaAPI.lua_pushstring(L, __cl_gen_to_be_invoked.Password);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_ServerID(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.Game __cl_gen_to_be_invoked = (xc.Game)translator.FastGetCSObj(L, 1);
                LuaAPI.xlua_pushuint(L, __cl_gen_to_be_invoked.ServerID);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_mIsInited(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.Game __cl_gen_to_be_invoked = (xc.Game)translator.FastGetCSObj(L, 1);
                LuaAPI.lua_pushboolean(L, __cl_gen_to_be_invoked.mIsInited);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_IsEnterGame(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.Game __cl_gen_to_be_invoked = (xc.Game)translator.FastGetCSObj(L, 1);
                LuaAPI.lua_pushboolean(L, __cl_gen_to_be_invoked.IsEnterGame);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_IsRebooting(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.Game __cl_gen_to_be_invoked = (xc.Game)translator.FastGetCSObj(L, 1);
                __cl_gen_to_be_invoked.IsRebooting = LuaAPI.lua_toboolean(L, 2);
            
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_ManualCancelReconnect(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.Game __cl_gen_to_be_invoked = (xc.Game)translator.FastGetCSObj(L, 1);
                __cl_gen_to_be_invoked.ManualCancelReconnect = LuaAPI.lua_toboolean(L, 2);
            
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_LocalPlayerID(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.Game __cl_gen_to_be_invoked = (xc.Game)translator.FastGetCSObj(L, 1);
                __cl_gen_to_be_invoked.LocalPlayerID = (xc.UnitID)translator.GetObject(L, 2, typeof(xc.UnitID));
            
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_LocalPlayerName(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.Game __cl_gen_to_be_invoked = (xc.Game)translator.FastGetCSObj(L, 1);
                __cl_gen_to_be_invoked.LocalPlayerName = LuaAPI.lua_tostring(L, 2);
            
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_LocalPlayerTypeID(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.Game __cl_gen_to_be_invoked = (xc.Game)translator.FastGetCSObj(L, 1);
                __cl_gen_to_be_invoked.LocalPlayerTypeID = LuaAPI.xlua_touint(L, 2);
            
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_LocalPlayerRadius(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.Game __cl_gen_to_be_invoked = (xc.Game)translator.FastGetCSObj(L, 1);
                __cl_gen_to_be_invoked.LocalPlayerRadius = (float)LuaAPI.lua_tonumber(L, 2);
            
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_LocalPlayerAOIInfo(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.Game __cl_gen_to_be_invoked = (xc.Game)translator.FastGetCSObj(L, 1);
                __cl_gen_to_be_invoked.LocalPlayerAOIInfo = (xc.UnitEnterAOI._Player)translator.GetObject(L, 2, typeof(xc.UnitEnterAOI._Player));
            
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
			
                xc.Game __cl_gen_to_be_invoked = (xc.Game)translator.FastGetCSObj(L, 1);
                __cl_gen_to_be_invoked.IsSwitchingScene = LuaAPI.lua_toboolean(L, 2);
            
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_IsCreateRoleEnter(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.Game __cl_gen_to_be_invoked = (xc.Game)translator.FastGetCSObj(L, 1);
                __cl_gen_to_be_invoked.IsCreateRoleEnter = LuaAPI.lua_toboolean(L, 2);
            
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_IsSkillEditorScene(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.Game __cl_gen_to_be_invoked = (xc.Game)translator.FastGetCSObj(L, 1);
                __cl_gen_to_be_invoked.IsSkillEditorScene = LuaAPI.lua_toboolean(L, 2);
            
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_GameMode(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.Game __cl_gen_to_be_invoked = (xc.Game)translator.FastGetCSObj(L, 1);
                xc.Game.EGameMode __cl_gen_value;translator.Get(L, 2, out __cl_gen_value);
				__cl_gen_to_be_invoked.GameMode = __cl_gen_value;
            
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_ServerIP(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.Game __cl_gen_to_be_invoked = (xc.Game)translator.FastGetCSObj(L, 1);
                __cl_gen_to_be_invoked.ServerIP = LuaAPI.lua_tostring(L, 2);
            
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_ServerPort(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.Game __cl_gen_to_be_invoked = (xc.Game)translator.FastGetCSObj(L, 1);
                __cl_gen_to_be_invoked.ServerPort = LuaAPI.xlua_tointeger(L, 2);
            
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_Account(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.Game __cl_gen_to_be_invoked = (xc.Game)translator.FastGetCSObj(L, 1);
                __cl_gen_to_be_invoked.Account = LuaAPI.lua_tostring(L, 2);
            
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_Password(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.Game __cl_gen_to_be_invoked = (xc.Game)translator.FastGetCSObj(L, 1);
                __cl_gen_to_be_invoked.Password = LuaAPI.lua_tostring(L, 2);
            
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_ServerID(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.Game __cl_gen_to_be_invoked = (xc.Game)translator.FastGetCSObj(L, 1);
                __cl_gen_to_be_invoked.ServerID = LuaAPI.xlua_touint(L, 2);
            
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_mIsInited(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.Game __cl_gen_to_be_invoked = (xc.Game)translator.FastGetCSObj(L, 1);
                __cl_gen_to_be_invoked.mIsInited = LuaAPI.lua_toboolean(L, 2);
            
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_IsEnterGame(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.Game __cl_gen_to_be_invoked = (xc.Game)translator.FastGetCSObj(L, 1);
                __cl_gen_to_be_invoked.IsEnterGame = LuaAPI.lua_toboolean(L, 2);
            
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 0;
        }
        
		
		
		
		
    }
}
