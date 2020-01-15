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
    public class xcRouterManagerWrap
    {
        public static void __Register(RealStatePtr L)
        {
			ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			XUtils.BeginObjectRegister(typeof(xc.RouterManager), L, translator, 0, 60, 0, 0);
			
			XUtils.RegisterFunc(L, XUtils.METHOD_IDX, "CheckSysDownloaded", _m_CheckSysDownloaded);
			XUtils.RegisterFunc(L, XUtils.METHOD_IDX, "GenericGoToSysWindow", _m_GenericGoToSysWindow);
			XUtils.RegisterFunc(L, XUtils.METHOD_IDX, "RegisterRouter", _m_RegisterRouter);
			XUtils.RegisterFunc(L, XUtils.METHOD_IDX, "RegisterRouterById", _m_RegisterRouterById);
			XUtils.RegisterFunc(L, XUtils.METHOD_IDX, "GoToBagWnd", _m_GoToBagWnd);
			XUtils.RegisterFunc(L, XUtils.METHOD_IDX, "GoToMailWnd", _m_GoToMailWnd);
			XUtils.RegisterFunc(L, XUtils.METHOD_IDX, "GoToSkillWnd", _m_GoToSkillWnd);
			XUtils.RegisterFunc(L, XUtils.METHOD_IDX, "GoToFriendsWnd", _m_GoToFriendsWnd);
			XUtils.RegisterFunc(L, XUtils.METHOD_IDX, "GoToChatWindow", _m_GoToChatWindow);
			XUtils.RegisterFunc(L, XUtils.METHOD_IDX, "GoToPlayerMainWnd", _m_GoToPlayerMainWnd);
			XUtils.RegisterFunc(L, XUtils.METHOD_IDX, "GotoSoulWnd", _m_GotoSoulWnd);
			XUtils.RegisterFunc(L, XUtils.METHOD_IDX, "GotoSettingWnd", _m_GotoSettingWnd);
			XUtils.RegisterFunc(L, XUtils.METHOD_IDX, "GotoSoulTownWnd", _m_GotoSoulTownWnd);
			XUtils.RegisterFunc(L, XUtils.METHOD_IDX, "GotoPetWnd", _m_GotoPetWnd);
			XUtils.RegisterFunc(L, XUtils.METHOD_IDX, "GotoMapWnd", _m_GotoMapWnd);
			XUtils.RegisterFunc(L, XUtils.METHOD_IDX, "GotoPlayIngWnd", _m_GotoPlayIngWnd);
			XUtils.RegisterFunc(L, XUtils.METHOD_IDX, "GotoWelfareWnd", _m_GotoWelfareWnd);
			XUtils.RegisterFunc(L, XUtils.METHOD_IDX, "GotoShopWnd", _m_GotoShopWnd);
			XUtils.RegisterFunc(L, XUtils.METHOD_IDX, "GoToGuildWnd", _m_GoToGuildWnd);
			XUtils.RegisterFunc(L, XUtils.METHOD_IDX, "GotoTrialBoss", _m_GotoTrialBoss);
			XUtils.RegisterFunc(L, XUtils.METHOD_IDX, "GotoRank", _m_GotoRank);
			XUtils.RegisterFunc(L, XUtils.METHOD_IDX, "GotoTreasure", _m_GotoTreasure);
			XUtils.RegisterFunc(L, XUtils.METHOD_IDX, "GotoCorsair", _m_GotoCorsair);
			XUtils.RegisterFunc(L, XUtils.METHOD_IDX, "GotoFairyValley", _m_GotoFairyValley);
			XUtils.RegisterFunc(L, XUtils.METHOD_IDX, "GotoWorshipMeeting", _m_GotoWorshipMeeting);
			XUtils.RegisterFunc(L, XUtils.METHOD_IDX, "GotoForgottenTomb", _m_GotoForgottenTomb);
			XUtils.RegisterFunc(L, XUtils.METHOD_IDX, "GotoTransfer", _m_GotoTransfer);
			XUtils.RegisterFunc(L, XUtils.METHOD_IDX, "GotoOpenDragonForest", _m_GotoOpenDragonForest);
			XUtils.RegisterFunc(L, XUtils.METHOD_IDX, "GotoGuildBoss", _m_GotoGuildBoss);
			XUtils.RegisterFunc(L, XUtils.METHOD_IDX, "GoToEquipStrength", _m_GoToEquipStrength);
			XUtils.RegisterFunc(L, XUtils.METHOD_IDX, "GoToEquipBaptize", _m_GoToEquipBaptize);
			XUtils.RegisterFunc(L, XUtils.METHOD_IDX, "GoToEquipGem", _m_GoToEquipGem);
			XUtils.RegisterFunc(L, XUtils.METHOD_IDX, "GoToEquipSuit", _m_GoToEquipSuit);
			XUtils.RegisterFunc(L, XUtils.METHOD_IDX, "GoToEquipSuitRefine", _m_GoToEquipSuitRefine);
			XUtils.RegisterFunc(L, XUtils.METHOD_IDX, "GotoDeadSpace", _m_GotoDeadSpace);
			XUtils.RegisterFunc(L, XUtils.METHOD_IDX, "GotoBountyTask", _m_GotoBountyTask);
			XUtils.RegisterFunc(L, XUtils.METHOD_IDX, "GotoGuildTask", _m_GotoGuildTask);
			XUtils.RegisterFunc(L, XUtils.METHOD_IDX, "GotoOpenSouthLand", _m_GotoOpenSouthLand);
			XUtils.RegisterFunc(L, XUtils.METHOD_IDX, "GotoOpenTargetSys", _m_GotoOpenTargetSys);
			XUtils.RegisterFunc(L, XUtils.METHOD_IDX, "GotoGuildLeaguePreview", _m_GotoGuildLeaguePreview);
			XUtils.RegisterFunc(L, XUtils.METHOD_IDX, "GotoGuildLeague", _m_GotoGuildLeague);
			XUtils.RegisterFunc(L, XUtils.METHOD_IDX, "GotoGuildLeaguePrime", _m_GotoGuildLeaguePrime);
			XUtils.RegisterFunc(L, XUtils.METHOD_IDX, "GotoArena", _m_GotoArena);
			XUtils.RegisterFunc(L, XUtils.METHOD_IDX, "GotoSevenGift", _m_GotoSevenGift);
			XUtils.RegisterFunc(L, XUtils.METHOD_IDX, "GotoSecretDefend", _m_GotoSecretDefend);
			XUtils.RegisterFunc(L, XUtils.METHOD_IDX, "GotoGuildFire", _m_GotoGuildFire);
			XUtils.RegisterFunc(L, XUtils.METHOD_IDX, "GotoGuilRainRedPacket", _m_GotoGuilRainRedPacket);
			XUtils.RegisterFunc(L, XUtils.METHOD_IDX, "GotoCloudBuy", _m_GotoCloudBuy);
			XUtils.RegisterFunc(L, XUtils.METHOD_IDX, "GotoTreasureHome", _m_GotoTreasureHome);
			XUtils.RegisterFunc(L, XUtils.METHOD_IDX, "GotoQuest", _m_GotoQuest);
			XUtils.RegisterFunc(L, XUtils.METHOD_IDX, "GotoOpenServerAct", _m_GotoOpenServerAct);
			XUtils.RegisterFunc(L, XUtils.METHOD_IDX, "GotoWingInstance", _m_GotoWingInstance);
			XUtils.RegisterFunc(L, XUtils.METHOD_IDX, "GotoEquipCompose", _m_GotoEquipCompose);
			XUtils.RegisterFunc(L, XUtils.METHOD_IDX, "GotoGodGoodsCompose", _m_GotoGodGoodsCompose);
			XUtils.RegisterFunc(L, XUtils.METHOD_IDX, "GotoBattleHall", _m_GotoBattleHall);
			XUtils.RegisterFunc(L, XUtils.METHOD_IDX, "GotoExchangeMall", _m_GotoExchangeMall);
			XUtils.RegisterFunc(L, XUtils.METHOD_IDX, "GotoEquipExchange", _m_GotoEquipExchange);
			XUtils.RegisterFunc(L, XUtils.METHOD_IDX, "GotoSoulExchange", _m_GotoSoulExchange);
			XUtils.RegisterFunc(L, XUtils.METHOD_IDX, "GotoInstanceHall", _m_GotoInstanceHall);
			XUtils.RegisterFunc(L, XUtils.METHOD_IDX, "IsRegisterSysId", _m_IsRegisterSysId);
			
			
			
			
			XUtils.EndObjectRegister(typeof(xc.RouterManager), L, translator, null, null,
			    null, null, null);

		    XUtils.BeginClassRegister(typeof(xc.RouterManager), L, __CreateInstance, 1, 0, 0);
			
			
            
            XUtils.RegisterObject(L, translator, XUtils.CLS_IDX, "UnderlyingSystemType", typeof(xc.RouterManager));
			
			
			XUtils.EndClassRegister(typeof(xc.RouterManager), L, translator);
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int __CreateInstance(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			try {
				if(LuaAPI.lua_gettop(L) == 1)
				{
					
					xc.RouterManager __cl_gen_ret = new xc.RouterManager();
					translator.Push(L, __cl_gen_ret);
					return 1;
				}
				
			}
			catch(System.Exception __gen_e) {
				return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
			}
            return LuaAPI.luaL_error(L, "invalid arguments to xc.RouterManager constructor!");
            
        }
        
		
        
		
        
        
        
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_CheckSysDownloaded(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            xc.RouterManager __cl_gen_to_be_invoked = (xc.RouterManager)translator.FastGetCSObj(L, 1);
            
            
            try {
                
                {
                    uint sys_id = LuaAPI.xlua_touint(L, 2);
                    
                        bool __cl_gen_ret = __cl_gen_to_be_invoked.CheckSysDownloaded( sys_id );
                        LuaAPI.lua_pushboolean(L, __cl_gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_GenericGoToSysWindow(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            xc.RouterManager __cl_gen_to_be_invoked = (xc.RouterManager)translator.FastGetCSObj(L, 1);
            
            
            try {
                
                {
                    uint sys_id = LuaAPI.xlua_touint(L, 2);
                    object[] args = translator.GetParams<object>(L, 3);
                    
                        bool __cl_gen_ret = __cl_gen_to_be_invoked.GenericGoToSysWindow( sys_id, args );
                        LuaAPI.lua_pushboolean(L, __cl_gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_RegisterRouter(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            xc.RouterManager __cl_gen_to_be_invoked = (xc.RouterManager)translator.FastGetCSObj(L, 1);
            
            
            try {
                
                {
                    uint sys_type = LuaAPI.xlua_touint(L, 2);
                    xc.RouterManager.OpenSysWindowDelegate dlg = translator.GetDelegate<xc.RouterManager.OpenSysWindowDelegate>(L, 3);
                    
                    __cl_gen_to_be_invoked.RegisterRouter( sys_type, dlg );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_RegisterRouterById(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            xc.RouterManager __cl_gen_to_be_invoked = (xc.RouterManager)translator.FastGetCSObj(L, 1);
            
            
            try {
                
                {
                    uint sys_id = LuaAPI.xlua_touint(L, 2);
                    xc.RouterManager.OpenSysWindowDelegate dlg = translator.GetDelegate<xc.RouterManager.OpenSysWindowDelegate>(L, 3);
                    
                    __cl_gen_to_be_invoked.RegisterRouterById( sys_id, dlg );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_GoToBagWnd(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            xc.RouterManager __cl_gen_to_be_invoked = (xc.RouterManager)translator.FastGetCSObj(L, 1);
            
            
            try {
                
                {
                    object[] args = translator.GetParams<object>(L, 2);
                    
                        bool __cl_gen_ret = __cl_gen_to_be_invoked.GoToBagWnd( args );
                        LuaAPI.lua_pushboolean(L, __cl_gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_GoToMailWnd(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            xc.RouterManager __cl_gen_to_be_invoked = (xc.RouterManager)translator.FastGetCSObj(L, 1);
            
            
            try {
                
                {
                    object[] args = translator.GetParams<object>(L, 2);
                    
                        bool __cl_gen_ret = __cl_gen_to_be_invoked.GoToMailWnd( args );
                        LuaAPI.lua_pushboolean(L, __cl_gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_GoToSkillWnd(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            xc.RouterManager __cl_gen_to_be_invoked = (xc.RouterManager)translator.FastGetCSObj(L, 1);
            
            
            try {
                
                {
                    object[] args = translator.GetParams<object>(L, 2);
                    
                        bool __cl_gen_ret = __cl_gen_to_be_invoked.GoToSkillWnd( args );
                        LuaAPI.lua_pushboolean(L, __cl_gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_GoToFriendsWnd(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            xc.RouterManager __cl_gen_to_be_invoked = (xc.RouterManager)translator.FastGetCSObj(L, 1);
            
            
            try {
                
                {
                    object[] args = translator.GetParams<object>(L, 2);
                    
                        bool __cl_gen_ret = __cl_gen_to_be_invoked.GoToFriendsWnd( args );
                        LuaAPI.lua_pushboolean(L, __cl_gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_GoToChatWindow(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            xc.RouterManager __cl_gen_to_be_invoked = (xc.RouterManager)translator.FastGetCSObj(L, 1);
            
            
            try {
                
                {
                    object[] args = translator.GetParams<object>(L, 2);
                    
                        bool __cl_gen_ret = __cl_gen_to_be_invoked.GoToChatWindow( args );
                        LuaAPI.lua_pushboolean(L, __cl_gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_GoToPlayerMainWnd(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            xc.RouterManager __cl_gen_to_be_invoked = (xc.RouterManager)translator.FastGetCSObj(L, 1);
            
            
            try {
                
                {
                    object[] args = translator.GetParams<object>(L, 2);
                    
                        bool __cl_gen_ret = __cl_gen_to_be_invoked.GoToPlayerMainWnd( args );
                        LuaAPI.lua_pushboolean(L, __cl_gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_GotoSoulWnd(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            xc.RouterManager __cl_gen_to_be_invoked = (xc.RouterManager)translator.FastGetCSObj(L, 1);
            
            
            try {
                
                {
                    object[] args = translator.GetParams<object>(L, 2);
                    
                        bool __cl_gen_ret = __cl_gen_to_be_invoked.GotoSoulWnd( args );
                        LuaAPI.lua_pushboolean(L, __cl_gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_GotoSettingWnd(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            xc.RouterManager __cl_gen_to_be_invoked = (xc.RouterManager)translator.FastGetCSObj(L, 1);
            
            
            try {
                
                {
                    object[] args = translator.GetParams<object>(L, 2);
                    
                        bool __cl_gen_ret = __cl_gen_to_be_invoked.GotoSettingWnd( args );
                        LuaAPI.lua_pushboolean(L, __cl_gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_GotoSoulTownWnd(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            xc.RouterManager __cl_gen_to_be_invoked = (xc.RouterManager)translator.FastGetCSObj(L, 1);
            
            
            try {
                
                {
                    object[] args = translator.GetParams<object>(L, 2);
                    
                        bool __cl_gen_ret = __cl_gen_to_be_invoked.GotoSoulTownWnd( args );
                        LuaAPI.lua_pushboolean(L, __cl_gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_GotoPetWnd(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            xc.RouterManager __cl_gen_to_be_invoked = (xc.RouterManager)translator.FastGetCSObj(L, 1);
            
            
            try {
                
                {
                    object[] args = translator.GetParams<object>(L, 2);
                    
                        bool __cl_gen_ret = __cl_gen_to_be_invoked.GotoPetWnd( args );
                        LuaAPI.lua_pushboolean(L, __cl_gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_GotoMapWnd(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            xc.RouterManager __cl_gen_to_be_invoked = (xc.RouterManager)translator.FastGetCSObj(L, 1);
            
            
            try {
                
                {
                    object[] args = translator.GetParams<object>(L, 2);
                    
                        bool __cl_gen_ret = __cl_gen_to_be_invoked.GotoMapWnd( args );
                        LuaAPI.lua_pushboolean(L, __cl_gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_GotoPlayIngWnd(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            xc.RouterManager __cl_gen_to_be_invoked = (xc.RouterManager)translator.FastGetCSObj(L, 1);
            
            
            try {
                
                {
                    object[] args = translator.GetParams<object>(L, 2);
                    
                        bool __cl_gen_ret = __cl_gen_to_be_invoked.GotoPlayIngWnd( args );
                        LuaAPI.lua_pushboolean(L, __cl_gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_GotoWelfareWnd(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            xc.RouterManager __cl_gen_to_be_invoked = (xc.RouterManager)translator.FastGetCSObj(L, 1);
            
            
            try {
                
                {
                    object[] args = translator.GetParams<object>(L, 2);
                    
                        bool __cl_gen_ret = __cl_gen_to_be_invoked.GotoWelfareWnd( args );
                        LuaAPI.lua_pushboolean(L, __cl_gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_GotoShopWnd(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            xc.RouterManager __cl_gen_to_be_invoked = (xc.RouterManager)translator.FastGetCSObj(L, 1);
            
            
            try {
                
                {
                    object[] args = translator.GetParams<object>(L, 2);
                    
                        bool __cl_gen_ret = __cl_gen_to_be_invoked.GotoShopWnd( args );
                        LuaAPI.lua_pushboolean(L, __cl_gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_GoToGuildWnd(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            xc.RouterManager __cl_gen_to_be_invoked = (xc.RouterManager)translator.FastGetCSObj(L, 1);
            
            
            try {
                
                {
                    object[] args = translator.GetParams<object>(L, 2);
                    
                        bool __cl_gen_ret = __cl_gen_to_be_invoked.GoToGuildWnd( args );
                        LuaAPI.lua_pushboolean(L, __cl_gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_GotoTrialBoss(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            xc.RouterManager __cl_gen_to_be_invoked = (xc.RouterManager)translator.FastGetCSObj(L, 1);
            
            
            try {
                
                {
                    object[] args = translator.GetParams<object>(L, 2);
                    
                        bool __cl_gen_ret = __cl_gen_to_be_invoked.GotoTrialBoss( args );
                        LuaAPI.lua_pushboolean(L, __cl_gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_GotoRank(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            xc.RouterManager __cl_gen_to_be_invoked = (xc.RouterManager)translator.FastGetCSObj(L, 1);
            
            
            try {
                
                {
                    object[] args = translator.GetParams<object>(L, 2);
                    
                        bool __cl_gen_ret = __cl_gen_to_be_invoked.GotoRank( args );
                        LuaAPI.lua_pushboolean(L, __cl_gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_GotoTreasure(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            xc.RouterManager __cl_gen_to_be_invoked = (xc.RouterManager)translator.FastGetCSObj(L, 1);
            
            
            try {
                
                {
                    object[] args = translator.GetParams<object>(L, 2);
                    
                        bool __cl_gen_ret = __cl_gen_to_be_invoked.GotoTreasure( args );
                        LuaAPI.lua_pushboolean(L, __cl_gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_GotoCorsair(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            xc.RouterManager __cl_gen_to_be_invoked = (xc.RouterManager)translator.FastGetCSObj(L, 1);
            
            
            try {
                
                {
                    object[] args = translator.GetParams<object>(L, 2);
                    
                        bool __cl_gen_ret = __cl_gen_to_be_invoked.GotoCorsair( args );
                        LuaAPI.lua_pushboolean(L, __cl_gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_GotoFairyValley(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            xc.RouterManager __cl_gen_to_be_invoked = (xc.RouterManager)translator.FastGetCSObj(L, 1);
            
            
            try {
                
                {
                    object[] args = translator.GetParams<object>(L, 2);
                    
                        bool __cl_gen_ret = __cl_gen_to_be_invoked.GotoFairyValley( args );
                        LuaAPI.lua_pushboolean(L, __cl_gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_GotoWorshipMeeting(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            xc.RouterManager __cl_gen_to_be_invoked = (xc.RouterManager)translator.FastGetCSObj(L, 1);
            
            
            try {
                
                {
                    object[] args = translator.GetParams<object>(L, 2);
                    
                        bool __cl_gen_ret = __cl_gen_to_be_invoked.GotoWorshipMeeting( args );
                        LuaAPI.lua_pushboolean(L, __cl_gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_GotoForgottenTomb(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            xc.RouterManager __cl_gen_to_be_invoked = (xc.RouterManager)translator.FastGetCSObj(L, 1);
            
            
            try {
                
                {
                    object[] args = translator.GetParams<object>(L, 2);
                    
                        bool __cl_gen_ret = __cl_gen_to_be_invoked.GotoForgottenTomb( args );
                        LuaAPI.lua_pushboolean(L, __cl_gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_GotoTransfer(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            xc.RouterManager __cl_gen_to_be_invoked = (xc.RouterManager)translator.FastGetCSObj(L, 1);
            
            
            try {
                
                {
                    object[] args = translator.GetParams<object>(L, 2);
                    
                        bool __cl_gen_ret = __cl_gen_to_be_invoked.GotoTransfer( args );
                        LuaAPI.lua_pushboolean(L, __cl_gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_GotoOpenDragonForest(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            xc.RouterManager __cl_gen_to_be_invoked = (xc.RouterManager)translator.FastGetCSObj(L, 1);
            
            
            try {
                
                {
                    object[] args = translator.GetParams<object>(L, 2);
                    
                        bool __cl_gen_ret = __cl_gen_to_be_invoked.GotoOpenDragonForest( args );
                        LuaAPI.lua_pushboolean(L, __cl_gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_GotoGuildBoss(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            xc.RouterManager __cl_gen_to_be_invoked = (xc.RouterManager)translator.FastGetCSObj(L, 1);
            
            
            try {
                
                {
                    object[] args = translator.GetParams<object>(L, 2);
                    
                        bool __cl_gen_ret = __cl_gen_to_be_invoked.GotoGuildBoss( args );
                        LuaAPI.lua_pushboolean(L, __cl_gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_GoToEquipStrength(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            xc.RouterManager __cl_gen_to_be_invoked = (xc.RouterManager)translator.FastGetCSObj(L, 1);
            
            
            try {
                
                {
                    object[] args = translator.GetParams<object>(L, 2);
                    
                        bool __cl_gen_ret = __cl_gen_to_be_invoked.GoToEquipStrength( args );
                        LuaAPI.lua_pushboolean(L, __cl_gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_GoToEquipBaptize(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            xc.RouterManager __cl_gen_to_be_invoked = (xc.RouterManager)translator.FastGetCSObj(L, 1);
            
            
            try {
                
                {
                    object[] args = translator.GetParams<object>(L, 2);
                    
                        bool __cl_gen_ret = __cl_gen_to_be_invoked.GoToEquipBaptize( args );
                        LuaAPI.lua_pushboolean(L, __cl_gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_GoToEquipGem(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            xc.RouterManager __cl_gen_to_be_invoked = (xc.RouterManager)translator.FastGetCSObj(L, 1);
            
            
            try {
                
                {
                    object[] args = translator.GetParams<object>(L, 2);
                    
                        bool __cl_gen_ret = __cl_gen_to_be_invoked.GoToEquipGem( args );
                        LuaAPI.lua_pushboolean(L, __cl_gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_GoToEquipSuit(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            xc.RouterManager __cl_gen_to_be_invoked = (xc.RouterManager)translator.FastGetCSObj(L, 1);
            
            
            try {
                
                {
                    object[] args = translator.GetParams<object>(L, 2);
                    
                        bool __cl_gen_ret = __cl_gen_to_be_invoked.GoToEquipSuit( args );
                        LuaAPI.lua_pushboolean(L, __cl_gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_GoToEquipSuitRefine(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            xc.RouterManager __cl_gen_to_be_invoked = (xc.RouterManager)translator.FastGetCSObj(L, 1);
            
            
            try {
                
                {
                    object[] args = translator.GetParams<object>(L, 2);
                    
                        bool __cl_gen_ret = __cl_gen_to_be_invoked.GoToEquipSuitRefine( args );
                        LuaAPI.lua_pushboolean(L, __cl_gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_GotoDeadSpace(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            xc.RouterManager __cl_gen_to_be_invoked = (xc.RouterManager)translator.FastGetCSObj(L, 1);
            
            
            try {
                
                {
                    object[] args = translator.GetParams<object>(L, 2);
                    
                        bool __cl_gen_ret = __cl_gen_to_be_invoked.GotoDeadSpace( args );
                        LuaAPI.lua_pushboolean(L, __cl_gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_GotoBountyTask(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            xc.RouterManager __cl_gen_to_be_invoked = (xc.RouterManager)translator.FastGetCSObj(L, 1);
            
            
            try {
                
                {
                    object[] args = translator.GetParams<object>(L, 2);
                    
                        bool __cl_gen_ret = __cl_gen_to_be_invoked.GotoBountyTask( args );
                        LuaAPI.lua_pushboolean(L, __cl_gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_GotoGuildTask(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            xc.RouterManager __cl_gen_to_be_invoked = (xc.RouterManager)translator.FastGetCSObj(L, 1);
            
            
            try {
                
                {
                    object[] args = translator.GetParams<object>(L, 2);
                    
                        bool __cl_gen_ret = __cl_gen_to_be_invoked.GotoGuildTask( args );
                        LuaAPI.lua_pushboolean(L, __cl_gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_GotoOpenSouthLand(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            xc.RouterManager __cl_gen_to_be_invoked = (xc.RouterManager)translator.FastGetCSObj(L, 1);
            
            
            try {
                
                {
                    object[] args = translator.GetParams<object>(L, 2);
                    
                        bool __cl_gen_ret = __cl_gen_to_be_invoked.GotoOpenSouthLand( args );
                        LuaAPI.lua_pushboolean(L, __cl_gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_GotoOpenTargetSys(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            xc.RouterManager __cl_gen_to_be_invoked = (xc.RouterManager)translator.FastGetCSObj(L, 1);
            
            
            try {
                
                {
                    object[] args = translator.GetParams<object>(L, 2);
                    
                        bool __cl_gen_ret = __cl_gen_to_be_invoked.GotoOpenTargetSys( args );
                        LuaAPI.lua_pushboolean(L, __cl_gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_GotoGuildLeaguePreview(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            xc.RouterManager __cl_gen_to_be_invoked = (xc.RouterManager)translator.FastGetCSObj(L, 1);
            
            
            try {
                
                {
                    object[] args = translator.GetParams<object>(L, 2);
                    
                        bool __cl_gen_ret = __cl_gen_to_be_invoked.GotoGuildLeaguePreview( args );
                        LuaAPI.lua_pushboolean(L, __cl_gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_GotoGuildLeague(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            xc.RouterManager __cl_gen_to_be_invoked = (xc.RouterManager)translator.FastGetCSObj(L, 1);
            
            
            try {
                
                {
                    object[] args = translator.GetParams<object>(L, 2);
                    
                        bool __cl_gen_ret = __cl_gen_to_be_invoked.GotoGuildLeague( args );
                        LuaAPI.lua_pushboolean(L, __cl_gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_GotoGuildLeaguePrime(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            xc.RouterManager __cl_gen_to_be_invoked = (xc.RouterManager)translator.FastGetCSObj(L, 1);
            
            
            try {
                
                {
                    object[] args = translator.GetParams<object>(L, 2);
                    
                        bool __cl_gen_ret = __cl_gen_to_be_invoked.GotoGuildLeaguePrime( args );
                        LuaAPI.lua_pushboolean(L, __cl_gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_GotoArena(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            xc.RouterManager __cl_gen_to_be_invoked = (xc.RouterManager)translator.FastGetCSObj(L, 1);
            
            
            try {
                
                {
                    object[] args = translator.GetParams<object>(L, 2);
                    
                        bool __cl_gen_ret = __cl_gen_to_be_invoked.GotoArena( args );
                        LuaAPI.lua_pushboolean(L, __cl_gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_GotoSevenGift(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            xc.RouterManager __cl_gen_to_be_invoked = (xc.RouterManager)translator.FastGetCSObj(L, 1);
            
            
            try {
                
                {
                    object[] args = translator.GetParams<object>(L, 2);
                    
                        bool __cl_gen_ret = __cl_gen_to_be_invoked.GotoSevenGift( args );
                        LuaAPI.lua_pushboolean(L, __cl_gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_GotoSecretDefend(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            xc.RouterManager __cl_gen_to_be_invoked = (xc.RouterManager)translator.FastGetCSObj(L, 1);
            
            
            try {
                
                {
                    object[] args = translator.GetParams<object>(L, 2);
                    
                        bool __cl_gen_ret = __cl_gen_to_be_invoked.GotoSecretDefend( args );
                        LuaAPI.lua_pushboolean(L, __cl_gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_GotoGuildFire(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            xc.RouterManager __cl_gen_to_be_invoked = (xc.RouterManager)translator.FastGetCSObj(L, 1);
            
            
            try {
                
                {
                    object[] args = translator.GetParams<object>(L, 2);
                    
                        bool __cl_gen_ret = __cl_gen_to_be_invoked.GotoGuildFire( args );
                        LuaAPI.lua_pushboolean(L, __cl_gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_GotoGuilRainRedPacket(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            xc.RouterManager __cl_gen_to_be_invoked = (xc.RouterManager)translator.FastGetCSObj(L, 1);
            
            
            try {
                
                {
                    object[] args = translator.GetParams<object>(L, 2);
                    
                        bool __cl_gen_ret = __cl_gen_to_be_invoked.GotoGuilRainRedPacket( args );
                        LuaAPI.lua_pushboolean(L, __cl_gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_GotoCloudBuy(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            xc.RouterManager __cl_gen_to_be_invoked = (xc.RouterManager)translator.FastGetCSObj(L, 1);
            
            
            try {
                
                {
                    object[] args = translator.GetParams<object>(L, 2);
                    
                        bool __cl_gen_ret = __cl_gen_to_be_invoked.GotoCloudBuy( args );
                        LuaAPI.lua_pushboolean(L, __cl_gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_GotoTreasureHome(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            xc.RouterManager __cl_gen_to_be_invoked = (xc.RouterManager)translator.FastGetCSObj(L, 1);
            
            
            try {
                
                {
                    object[] args = translator.GetParams<object>(L, 2);
                    
                        bool __cl_gen_ret = __cl_gen_to_be_invoked.GotoTreasureHome( args );
                        LuaAPI.lua_pushboolean(L, __cl_gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_GotoQuest(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            xc.RouterManager __cl_gen_to_be_invoked = (xc.RouterManager)translator.FastGetCSObj(L, 1);
            
            
            try {
                
                {
                    object[] args = translator.GetParams<object>(L, 2);
                    
                        bool __cl_gen_ret = __cl_gen_to_be_invoked.GotoQuest( args );
                        LuaAPI.lua_pushboolean(L, __cl_gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_GotoOpenServerAct(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            xc.RouterManager __cl_gen_to_be_invoked = (xc.RouterManager)translator.FastGetCSObj(L, 1);
            
            
            try {
                
                {
                    object[] args = translator.GetParams<object>(L, 2);
                    
                        bool __cl_gen_ret = __cl_gen_to_be_invoked.GotoOpenServerAct( args );
                        LuaAPI.lua_pushboolean(L, __cl_gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_GotoWingInstance(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            xc.RouterManager __cl_gen_to_be_invoked = (xc.RouterManager)translator.FastGetCSObj(L, 1);
            
            
            try {
                
                {
                    object[] args = translator.GetParams<object>(L, 2);
                    
                        bool __cl_gen_ret = __cl_gen_to_be_invoked.GotoWingInstance( args );
                        LuaAPI.lua_pushboolean(L, __cl_gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_GotoEquipCompose(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            xc.RouterManager __cl_gen_to_be_invoked = (xc.RouterManager)translator.FastGetCSObj(L, 1);
            
            
            try {
                
                {
                    object[] args = translator.GetParams<object>(L, 2);
                    
                        bool __cl_gen_ret = __cl_gen_to_be_invoked.GotoEquipCompose( args );
                        LuaAPI.lua_pushboolean(L, __cl_gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_GotoGodGoodsCompose(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            xc.RouterManager __cl_gen_to_be_invoked = (xc.RouterManager)translator.FastGetCSObj(L, 1);
            
            
            try {
                
                {
                    object[] args = translator.GetParams<object>(L, 2);
                    
                        bool __cl_gen_ret = __cl_gen_to_be_invoked.GotoGodGoodsCompose( args );
                        LuaAPI.lua_pushboolean(L, __cl_gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_GotoBattleHall(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            xc.RouterManager __cl_gen_to_be_invoked = (xc.RouterManager)translator.FastGetCSObj(L, 1);
            
            
            try {
                
                {
                    object[] args = translator.GetParams<object>(L, 2);
                    
                        bool __cl_gen_ret = __cl_gen_to_be_invoked.GotoBattleHall( args );
                        LuaAPI.lua_pushboolean(L, __cl_gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_GotoExchangeMall(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            xc.RouterManager __cl_gen_to_be_invoked = (xc.RouterManager)translator.FastGetCSObj(L, 1);
            
            
            try {
                
                {
                    object[] args = translator.GetParams<object>(L, 2);
                    
                        bool __cl_gen_ret = __cl_gen_to_be_invoked.GotoExchangeMall( args );
                        LuaAPI.lua_pushboolean(L, __cl_gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_GotoEquipExchange(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            xc.RouterManager __cl_gen_to_be_invoked = (xc.RouterManager)translator.FastGetCSObj(L, 1);
            
            
            try {
                
                {
                    object[] args = translator.GetParams<object>(L, 2);
                    
                        bool __cl_gen_ret = __cl_gen_to_be_invoked.GotoEquipExchange( args );
                        LuaAPI.lua_pushboolean(L, __cl_gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_GotoSoulExchange(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            xc.RouterManager __cl_gen_to_be_invoked = (xc.RouterManager)translator.FastGetCSObj(L, 1);
            
            
            try {
                
                {
                    object[] args = translator.GetParams<object>(L, 2);
                    
                        bool __cl_gen_ret = __cl_gen_to_be_invoked.GotoSoulExchange( args );
                        LuaAPI.lua_pushboolean(L, __cl_gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_GotoInstanceHall(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            xc.RouterManager __cl_gen_to_be_invoked = (xc.RouterManager)translator.FastGetCSObj(L, 1);
            
            
            try {
                
                {
                    object[] args = translator.GetParams<object>(L, 2);
                    
                        bool __cl_gen_ret = __cl_gen_to_be_invoked.GotoInstanceHall( args );
                        LuaAPI.lua_pushboolean(L, __cl_gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_IsRegisterSysId(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            xc.RouterManager __cl_gen_to_be_invoked = (xc.RouterManager)translator.FastGetCSObj(L, 1);
            
            
            try {
                
                {
                    uint sys_id = LuaAPI.xlua_touint(L, 2);
                    
                        bool __cl_gen_ret = __cl_gen_to_be_invoked.IsRegisterSysId( sys_id );
                        LuaAPI.lua_pushboolean(L, __cl_gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        
        
        
        
        
		
		
		
		
    }
}
