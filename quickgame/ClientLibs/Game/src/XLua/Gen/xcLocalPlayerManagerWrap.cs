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
    public class xcLocalPlayerManagerWrap
    {
        public static void __Register(RealStatePtr L)
        {
			ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			XUtils.BeginObjectRegister(typeof(xc.LocalPlayerManager), L, translator, 0, 17, 34, 31);
			
			XUtils.RegisterFunc(L, XUtils.METHOD_IDX, "ClearMainPetExSkills", _m_ClearMainPetExSkills);
			XUtils.RegisterFunc(L, XUtils.METHOD_IDX, "AddMainPetExSkill", _m_AddMainPetExSkill);
			XUtils.RegisterFunc(L, XUtils.METHOD_IDX, "Reset", _m_Reset);
			XUtils.RegisterFunc(L, XUtils.METHOD_IDX, "OnDestroyScene", _m_OnDestroyScene);
			XUtils.RegisterFunc(L, XUtils.METHOD_IDX, "GetMoneyByConst", _m_GetMoneyByConst);
			XUtils.RegisterFunc(L, XUtils.METHOD_IDX, "RegisterAllMessage", _m_RegisterAllMessage);
			XUtils.RegisterFunc(L, XUtils.METHOD_IDX, "UnRegisterAllMessage", _m_UnRegisterAllMessage);
			XUtils.RegisterFunc(L, XUtils.METHOD_IDX, "ProcessCharacterInfo", _m_ProcessCharacterInfo);
			XUtils.RegisterFunc(L, XUtils.METHOD_IDX, "InitAttribute", _m_InitAttribute);
			XUtils.RegisterFunc(L, XUtils.METHOD_IDX, "TryShowFightRankAnim", _m_TryShowFightRankAnim);
			XUtils.RegisterFunc(L, XUtils.METHOD_IDX, "GetNextFightRankNum", _m_GetNextFightRankNum);
			XUtils.RegisterFunc(L, XUtils.METHOD_IDX, "RemoveNextFightRankNum", _m_RemoveNextFightRankNum);
			XUtils.RegisterFunc(L, XUtils.METHOD_IDX, "PopAllFightRankNum", _m_PopAllFightRankNum);
			XUtils.RegisterFunc(L, XUtils.METHOD_IDX, "ClearFightRank", _m_ClearFightRank);
			XUtils.RegisterFunc(L, XUtils.METHOD_IDX, "GetFightRankCount", _m_GetFightRankCount);
			XUtils.RegisterFunc(L, XUtils.METHOD_IDX, "ResetOpenSysMount", _m_ResetOpenSysMount);
			XUtils.RegisterFunc(L, XUtils.METHOD_IDX, "IsFinishOpenMountAnim", _m_IsFinishOpenMountAnim);
			
			
			XUtils.RegisterFunc(L, XUtils.GETTER_IDX, "BornRotation", _g_get_BornRotation);
            XUtils.RegisterFunc(L, XUtils.GETTER_IDX, "InBallteStatus", _g_get_InBallteStatus);
            XUtils.RegisterFunc(L, XUtils.GETTER_IDX, "Level", _g_get_Level);
            XUtils.RegisterFunc(L, XUtils.GETTER_IDX, "GuildID", _g_get_GuildID);
            XUtils.RegisterFunc(L, XUtils.GETTER_IDX, "GuildName", _g_get_GuildName);
            XUtils.RegisterFunc(L, XUtils.GETTER_IDX, "MainPetID", _g_get_MainPetID);
            XUtils.RegisterFunc(L, XUtils.GETTER_IDX, "MainPetExSkills", _g_get_MainPetExSkills);
            XUtils.RegisterFunc(L, XUtils.GETTER_IDX, "MountId", _g_get_MountId);
            XUtils.RegisterFunc(L, XUtils.GETTER_IDX, "FristGetNewMountId", _g_get_FristGetNewMountId);
            XUtils.RegisterFunc(L, XUtils.GETTER_IDX, "HasOpenSysMount", _g_get_HasOpenSysMount);
            XUtils.RegisterFunc(L, XUtils.GETTER_IDX, "LocalActorAttribute", _g_get_LocalActorAttribute);
            XUtils.RegisterFunc(L, XUtils.GETTER_IDX, "Exp", _g_get_Exp);
            XUtils.RegisterFunc(L, XUtils.GETTER_IDX, "ExpMax", _g_get_ExpMax);
            XUtils.RegisterFunc(L, XUtils.GETTER_IDX, "Coin", _g_get_Coin);
            XUtils.RegisterFunc(L, XUtils.GETTER_IDX, "BindCoin", _g_get_BindCoin);
            XUtils.RegisterFunc(L, XUtils.GETTER_IDX, "Diamond", _g_get_Diamond);
            XUtils.RegisterFunc(L, XUtils.GETTER_IDX, "BindDiamond", _g_get_BindDiamond);
            XUtils.RegisterFunc(L, XUtils.GETTER_IDX, "SoulCream", _g_get_SoulCream);
            XUtils.RegisterFunc(L, XUtils.GETTER_IDX, "SoulHolyWater", _g_get_SoulHolyWater);
            XUtils.RegisterFunc(L, XUtils.GETTER_IDX, "GuildMoney", _g_get_GuildMoney);
            XUtils.RegisterFunc(L, XUtils.GETTER_IDX, "BfireScore", _g_get_BfireScore);
            XUtils.RegisterFunc(L, XUtils.GETTER_IDX, "RaceScore", _g_get_RaceScore);
            XUtils.RegisterFunc(L, XUtils.GETTER_IDX, "ActivityScore", _g_get_ActivityScore);
            XUtils.RegisterFunc(L, XUtils.GETTER_IDX, "TrigramSp", _g_get_TrigramSp);
            XUtils.RegisterFunc(L, XUtils.GETTER_IDX, "HangTime", _g_get_HangTime);
            XUtils.RegisterFunc(L, XUtils.GETTER_IDX, "Fury", _g_get_Fury);
            XUtils.RegisterFunc(L, XUtils.GETTER_IDX, "MoneyData", _g_get_MoneyData);
            XUtils.RegisterFunc(L, XUtils.GETTER_IDX, "WorldLevel", _g_get_WorldLevel);
            XUtils.RegisterFunc(L, XUtils.GETTER_IDX, "LimitLevel", _g_get_LimitLevel);
            XUtils.RegisterFunc(L, XUtils.GETTER_IDX, "HiBreak", _g_get_HiBreak);
            XUtils.RegisterFunc(L, XUtils.GETTER_IDX, "ReaminLvPoint", _g_get_ReaminLvPoint);
            XUtils.RegisterFunc(L, XUtils.GETTER_IDX, "MountLv", _g_get_MountLv);
            XUtils.RegisterFunc(L, XUtils.GETTER_IDX, "m_isFirstLoadingScene", _g_get_m_isFirstLoadingScene);
            XUtils.RegisterFunc(L, XUtils.GETTER_IDX, "m_canShowBuffTips", _g_get_m_canShowBuffTips);
            
			XUtils.RegisterFunc(L, XUtils.SETTER_IDX, "BornRotation", _s_set_BornRotation);
            XUtils.RegisterFunc(L, XUtils.SETTER_IDX, "InBallteStatus", _s_set_InBallteStatus);
            XUtils.RegisterFunc(L, XUtils.SETTER_IDX, "GuildID", _s_set_GuildID);
            XUtils.RegisterFunc(L, XUtils.SETTER_IDX, "GuildName", _s_set_GuildName);
            XUtils.RegisterFunc(L, XUtils.SETTER_IDX, "MainPetID", _s_set_MainPetID);
            XUtils.RegisterFunc(L, XUtils.SETTER_IDX, "MountId", _s_set_MountId);
            XUtils.RegisterFunc(L, XUtils.SETTER_IDX, "FristGetNewMountId", _s_set_FristGetNewMountId);
            XUtils.RegisterFunc(L, XUtils.SETTER_IDX, "LocalActorAttribute", _s_set_LocalActorAttribute);
            XUtils.RegisterFunc(L, XUtils.SETTER_IDX, "Exp", _s_set_Exp);
            XUtils.RegisterFunc(L, XUtils.SETTER_IDX, "ExpMax", _s_set_ExpMax);
            XUtils.RegisterFunc(L, XUtils.SETTER_IDX, "Coin", _s_set_Coin);
            XUtils.RegisterFunc(L, XUtils.SETTER_IDX, "BindCoin", _s_set_BindCoin);
            XUtils.RegisterFunc(L, XUtils.SETTER_IDX, "Diamond", _s_set_Diamond);
            XUtils.RegisterFunc(L, XUtils.SETTER_IDX, "BindDiamond", _s_set_BindDiamond);
            XUtils.RegisterFunc(L, XUtils.SETTER_IDX, "SoulCream", _s_set_SoulCream);
            XUtils.RegisterFunc(L, XUtils.SETTER_IDX, "SoulHolyWater", _s_set_SoulHolyWater);
            XUtils.RegisterFunc(L, XUtils.SETTER_IDX, "GuildMoney", _s_set_GuildMoney);
            XUtils.RegisterFunc(L, XUtils.SETTER_IDX, "BfireScore", _s_set_BfireScore);
            XUtils.RegisterFunc(L, XUtils.SETTER_IDX, "RaceScore", _s_set_RaceScore);
            XUtils.RegisterFunc(L, XUtils.SETTER_IDX, "ActivityScore", _s_set_ActivityScore);
            XUtils.RegisterFunc(L, XUtils.SETTER_IDX, "TrigramSp", _s_set_TrigramSp);
            XUtils.RegisterFunc(L, XUtils.SETTER_IDX, "HangTime", _s_set_HangTime);
            XUtils.RegisterFunc(L, XUtils.SETTER_IDX, "Fury", _s_set_Fury);
            XUtils.RegisterFunc(L, XUtils.SETTER_IDX, "MoneyData", _s_set_MoneyData);
            XUtils.RegisterFunc(L, XUtils.SETTER_IDX, "WorldLevel", _s_set_WorldLevel);
            XUtils.RegisterFunc(L, XUtils.SETTER_IDX, "LimitLevel", _s_set_LimitLevel);
            XUtils.RegisterFunc(L, XUtils.SETTER_IDX, "HiBreak", _s_set_HiBreak);
            XUtils.RegisterFunc(L, XUtils.SETTER_IDX, "ReaminLvPoint", _s_set_ReaminLvPoint);
            XUtils.RegisterFunc(L, XUtils.SETTER_IDX, "MountLv", _s_set_MountLv);
            XUtils.RegisterFunc(L, XUtils.SETTER_IDX, "m_isFirstLoadingScene", _s_set_m_isFirstLoadingScene);
            XUtils.RegisterFunc(L, XUtils.SETTER_IDX, "m_canShowBuffTips", _s_set_m_canShowBuffTips);
            
			XUtils.EndObjectRegister(typeof(xc.LocalPlayerManager), L, translator, null, null,
			    null, null, null);

		    XUtils.BeginClassRegister(typeof(xc.LocalPlayerManager), L, __CreateInstance, 4, 0, 0);
			XUtils.RegisterFunc(L, XUtils.CLS_IDX, "GetMoneyNameByConst", _m_GetMoneyNameByConst_xlua_st_);
            XUtils.RegisterFunc(L, XUtils.CLS_IDX, "GetMoneyTypeByString", _m_GetMoneyTypeByString_xlua_st_);
            XUtils.RegisterFunc(L, XUtils.CLS_IDX, "GetMoneySpriteName", _m_GetMoneySpriteName_xlua_st_);
            
			
            
            XUtils.RegisterObject(L, translator, XUtils.CLS_IDX, "UnderlyingSystemType", typeof(xc.LocalPlayerManager));
			
			
			XUtils.EndClassRegister(typeof(xc.LocalPlayerManager), L, translator);
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int __CreateInstance(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			try {
				if(LuaAPI.lua_gettop(L) == 1)
				{
					
					xc.LocalPlayerManager __cl_gen_ret = new xc.LocalPlayerManager();
					translator.Push(L, __cl_gen_ret);
					return 1;
				}
				
			}
			catch(System.Exception __gen_e) {
				return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
			}
            return LuaAPI.luaL_error(L, "invalid arguments to xc.LocalPlayerManager constructor!");
            
        }
        
		
        
		
        
        
        
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_ClearMainPetExSkills(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            xc.LocalPlayerManager __cl_gen_to_be_invoked = (xc.LocalPlayerManager)translator.FastGetCSObj(L, 1);
            
            
            try {
                
                {
                    
                    __cl_gen_to_be_invoked.ClearMainPetExSkills(  );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_AddMainPetExSkill(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            xc.LocalPlayerManager __cl_gen_to_be_invoked = (xc.LocalPlayerManager)translator.FastGetCSObj(L, 1);
            
            
            try {
                
                {
                    uint skillId = LuaAPI.xlua_touint(L, 2);
                    
                    __cl_gen_to_be_invoked.AddMainPetExSkill( skillId );
                    
                    
                    
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
            
            
            xc.LocalPlayerManager __cl_gen_to_be_invoked = (xc.LocalPlayerManager)translator.FastGetCSObj(L, 1);
            
            
            try {
                
                {
                    bool is_reconnect = LuaAPI.lua_toboolean(L, 2);
                    
                    __cl_gen_to_be_invoked.Reset( is_reconnect );
                    
                    
                    
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
            
            
            xc.LocalPlayerManager __cl_gen_to_be_invoked = (xc.LocalPlayerManager)translator.FastGetCSObj(L, 1);
            
            
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
        static int _m_GetMoneyByConst(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            xc.LocalPlayerManager __cl_gen_to_be_invoked = (xc.LocalPlayerManager)translator.FastGetCSObj(L, 1);
            
            
            try {
                
                {
                    ushort moneyType = (ushort)LuaAPI.xlua_tointeger(L, 2);
                    
                        uint __cl_gen_ret = __cl_gen_to_be_invoked.GetMoneyByConst( moneyType );
                        LuaAPI.xlua_pushuint(L, __cl_gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_GetMoneyNameByConst_xlua_st_(RealStatePtr L)
        {
            
            
            
            try {
                
                {
                    ushort moneyType = (ushort)LuaAPI.xlua_tointeger(L, 1);
                    
                        string __cl_gen_ret = xc.LocalPlayerManager.GetMoneyNameByConst( moneyType );
                        LuaAPI.lua_pushstring(L, __cl_gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_GetMoneyTypeByString_xlua_st_(RealStatePtr L)
        {
            
            
            
            try {
                
                {
                    string type = LuaAPI.lua_tostring(L, 1);
                    
                        ushort __cl_gen_ret = xc.LocalPlayerManager.GetMoneyTypeByString( type );
                        LuaAPI.xlua_pushinteger(L, __cl_gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_GetMoneySpriteName_xlua_st_(RealStatePtr L)
        {
            
            
            
			int __gen_param_count = LuaAPI.lua_gettop(L);
            
            try {
                if(__gen_param_count == 1&& LuaTypes.LUA_TNUMBER == LuaAPI.lua_type(L, 1)) 
                {
                    int moneyType = LuaAPI.xlua_tointeger(L, 1);
                    
                        string __cl_gen_ret = xc.LocalPlayerManager.GetMoneySpriteName( moneyType );
                        LuaAPI.lua_pushstring(L, __cl_gen_ret);
                    
                    
                    
                    return 1;
                }
                if(__gen_param_count == 1&& (LuaAPI.lua_isnil(L, 1) || LuaAPI.lua_type(L, 1) == LuaTypes.LUA_TSTRING)) 
                {
                    string type = LuaAPI.lua_tostring(L, 1);
                    
                        string __cl_gen_ret = xc.LocalPlayerManager.GetMoneySpriteName( type );
                        LuaAPI.lua_pushstring(L, __cl_gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
            return LuaAPI.luaL_error(L, "invalid arguments to xc.LocalPlayerManager.GetMoneySpriteName!");
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_RegisterAllMessage(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            xc.LocalPlayerManager __cl_gen_to_be_invoked = (xc.LocalPlayerManager)translator.FastGetCSObj(L, 1);
            
            
            try {
                
                {
                    
                    __cl_gen_to_be_invoked.RegisterAllMessage(  );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_UnRegisterAllMessage(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            xc.LocalPlayerManager __cl_gen_to_be_invoked = (xc.LocalPlayerManager)translator.FastGetCSObj(L, 1);
            
            
            try {
                
                {
                    
                    __cl_gen_to_be_invoked.UnRegisterAllMessage(  );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_ProcessCharacterInfo(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            xc.LocalPlayerManager __cl_gen_to_be_invoked = (xc.LocalPlayerManager)translator.FastGetCSObj(L, 1);
            
            
			int __gen_param_count = LuaAPI.lua_gettop(L);
            
            try {
                if(__gen_param_count == 2&& translator.Assignable<Net.S2CPlayerLvExp>(L, 2)) 
                {
                    Net.S2CPlayerLvExp lv_exp = (Net.S2CPlayerLvExp)translator.GetObject(L, 2, typeof(Net.S2CPlayerLvExp));
                    
                    __cl_gen_to_be_invoked.ProcessCharacterInfo( lv_exp );
                    
                    
                    
                    return 0;
                }
                if(__gen_param_count == 2&& translator.Assignable<Net.S2CPlayerSyncAttrs>(L, 2)) 
                {
                    Net.S2CPlayerSyncAttrs attrs = (Net.S2CPlayerSyncAttrs)translator.GetObject(L, 2, typeof(Net.S2CPlayerSyncAttrs));
                    
                    __cl_gen_to_be_invoked.ProcessCharacterInfo( attrs );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
            return LuaAPI.luaL_error(L, "invalid arguments to xc.LocalPlayerManager.ProcessCharacterInfo!");
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_InitAttribute(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            xc.LocalPlayerManager __cl_gen_to_be_invoked = (xc.LocalPlayerManager)translator.FastGetCSObj(L, 1);
            
            
            try {
                
                {
                    uint type_id = LuaAPI.xlua_touint(L, 2);
                    string name = LuaAPI.lua_tostring(L, 3);
                    
                    __cl_gen_to_be_invoked.InitAttribute( type_id, name );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_TryShowFightRankAnim(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            xc.LocalPlayerManager __cl_gen_to_be_invoked = (xc.LocalPlayerManager)translator.FastGetCSObj(L, 1);
            
            
            try {
                
                {
                    long add_num = LuaAPI.lua_toint64(L, 2);
                    
                    __cl_gen_to_be_invoked.TryShowFightRankAnim( add_num );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_GetNextFightRankNum(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            xc.LocalPlayerManager __cl_gen_to_be_invoked = (xc.LocalPlayerManager)translator.FastGetCSObj(L, 1);
            
            
            try {
                
                {
                    
                        long __cl_gen_ret = __cl_gen_to_be_invoked.GetNextFightRankNum(  );
                        LuaAPI.lua_pushint64(L, __cl_gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_RemoveNextFightRankNum(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            xc.LocalPlayerManager __cl_gen_to_be_invoked = (xc.LocalPlayerManager)translator.FastGetCSObj(L, 1);
            
            
            try {
                
                {
                    
                    __cl_gen_to_be_invoked.RemoveNextFightRankNum(  );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_PopAllFightRankNum(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            xc.LocalPlayerManager __cl_gen_to_be_invoked = (xc.LocalPlayerManager)translator.FastGetCSObj(L, 1);
            
            
            try {
                
                {
                    
                        long __cl_gen_ret = __cl_gen_to_be_invoked.PopAllFightRankNum(  );
                        LuaAPI.lua_pushint64(L, __cl_gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_ClearFightRank(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            xc.LocalPlayerManager __cl_gen_to_be_invoked = (xc.LocalPlayerManager)translator.FastGetCSObj(L, 1);
            
            
            try {
                
                {
                    
                    __cl_gen_to_be_invoked.ClearFightRank(  );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_GetFightRankCount(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            xc.LocalPlayerManager __cl_gen_to_be_invoked = (xc.LocalPlayerManager)translator.FastGetCSObj(L, 1);
            
            
            try {
                
                {
                    
                        int __cl_gen_ret = __cl_gen_to_be_invoked.GetFightRankCount(  );
                        LuaAPI.xlua_pushinteger(L, __cl_gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_ResetOpenSysMount(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            xc.LocalPlayerManager __cl_gen_to_be_invoked = (xc.LocalPlayerManager)translator.FastGetCSObj(L, 1);
            
            
            try {
                
                {
                    
                    __cl_gen_to_be_invoked.ResetOpenSysMount(  );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_IsFinishOpenMountAnim(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            xc.LocalPlayerManager __cl_gen_to_be_invoked = (xc.LocalPlayerManager)translator.FastGetCSObj(L, 1);
            
            
            try {
                
                {
                    
                        bool __cl_gen_ret = __cl_gen_to_be_invoked.IsFinishOpenMountAnim(  );
                        LuaAPI.lua_pushboolean(L, __cl_gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        
        
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_BornRotation(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.LocalPlayerManager __cl_gen_to_be_invoked = (xc.LocalPlayerManager)translator.FastGetCSObj(L, 1);
                translator.PushUnityEngineQuaternion(L, __cl_gen_to_be_invoked.BornRotation);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_InBallteStatus(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.LocalPlayerManager __cl_gen_to_be_invoked = (xc.LocalPlayerManager)translator.FastGetCSObj(L, 1);
                LuaAPI.lua_pushboolean(L, __cl_gen_to_be_invoked.InBallteStatus);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_Level(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.LocalPlayerManager __cl_gen_to_be_invoked = (xc.LocalPlayerManager)translator.FastGetCSObj(L, 1);
                LuaAPI.xlua_pushuint(L, __cl_gen_to_be_invoked.Level);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_GuildID(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.LocalPlayerManager __cl_gen_to_be_invoked = (xc.LocalPlayerManager)translator.FastGetCSObj(L, 1);
                LuaAPI.xlua_pushuint(L, __cl_gen_to_be_invoked.GuildID);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_GuildName(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.LocalPlayerManager __cl_gen_to_be_invoked = (xc.LocalPlayerManager)translator.FastGetCSObj(L, 1);
                LuaAPI.lua_pushstring(L, __cl_gen_to_be_invoked.GuildName);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_MainPetID(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.LocalPlayerManager __cl_gen_to_be_invoked = (xc.LocalPlayerManager)translator.FastGetCSObj(L, 1);
                LuaAPI.xlua_pushuint(L, __cl_gen_to_be_invoked.MainPetID);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_MainPetExSkills(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.LocalPlayerManager __cl_gen_to_be_invoked = (xc.LocalPlayerManager)translator.FastGetCSObj(L, 1);
                translator.Push(L, __cl_gen_to_be_invoked.MainPetExSkills);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_MountId(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.LocalPlayerManager __cl_gen_to_be_invoked = (xc.LocalPlayerManager)translator.FastGetCSObj(L, 1);
                LuaAPI.xlua_pushuint(L, __cl_gen_to_be_invoked.MountId);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_FristGetNewMountId(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.LocalPlayerManager __cl_gen_to_be_invoked = (xc.LocalPlayerManager)translator.FastGetCSObj(L, 1);
                LuaAPI.xlua_pushuint(L, __cl_gen_to_be_invoked.FristGetNewMountId);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_HasOpenSysMount(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.LocalPlayerManager __cl_gen_to_be_invoked = (xc.LocalPlayerManager)translator.FastGetCSObj(L, 1);
                LuaAPI.lua_pushboolean(L, __cl_gen_to_be_invoked.HasOpenSysMount);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_LocalActorAttribute(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.LocalPlayerManager __cl_gen_to_be_invoked = (xc.LocalPlayerManager)translator.FastGetCSObj(L, 1);
                translator.Push(L, __cl_gen_to_be_invoked.LocalActorAttribute);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_Exp(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.LocalPlayerManager __cl_gen_to_be_invoked = (xc.LocalPlayerManager)translator.FastGetCSObj(L, 1);
                LuaAPI.lua_pushuint64(L, __cl_gen_to_be_invoked.Exp);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_ExpMax(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.LocalPlayerManager __cl_gen_to_be_invoked = (xc.LocalPlayerManager)translator.FastGetCSObj(L, 1);
                LuaAPI.lua_pushuint64(L, __cl_gen_to_be_invoked.ExpMax);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_Coin(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.LocalPlayerManager __cl_gen_to_be_invoked = (xc.LocalPlayerManager)translator.FastGetCSObj(L, 1);
                LuaAPI.xlua_pushuint(L, __cl_gen_to_be_invoked.Coin);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_BindCoin(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.LocalPlayerManager __cl_gen_to_be_invoked = (xc.LocalPlayerManager)translator.FastGetCSObj(L, 1);
                LuaAPI.xlua_pushuint(L, __cl_gen_to_be_invoked.BindCoin);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_Diamond(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.LocalPlayerManager __cl_gen_to_be_invoked = (xc.LocalPlayerManager)translator.FastGetCSObj(L, 1);
                LuaAPI.xlua_pushuint(L, __cl_gen_to_be_invoked.Diamond);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_BindDiamond(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.LocalPlayerManager __cl_gen_to_be_invoked = (xc.LocalPlayerManager)translator.FastGetCSObj(L, 1);
                LuaAPI.xlua_pushuint(L, __cl_gen_to_be_invoked.BindDiamond);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_SoulCream(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.LocalPlayerManager __cl_gen_to_be_invoked = (xc.LocalPlayerManager)translator.FastGetCSObj(L, 1);
                LuaAPI.xlua_pushuint(L, __cl_gen_to_be_invoked.SoulCream);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_SoulHolyWater(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.LocalPlayerManager __cl_gen_to_be_invoked = (xc.LocalPlayerManager)translator.FastGetCSObj(L, 1);
                LuaAPI.xlua_pushuint(L, __cl_gen_to_be_invoked.SoulHolyWater);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_GuildMoney(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.LocalPlayerManager __cl_gen_to_be_invoked = (xc.LocalPlayerManager)translator.FastGetCSObj(L, 1);
                LuaAPI.xlua_pushuint(L, __cl_gen_to_be_invoked.GuildMoney);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_BfireScore(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.LocalPlayerManager __cl_gen_to_be_invoked = (xc.LocalPlayerManager)translator.FastGetCSObj(L, 1);
                LuaAPI.xlua_pushuint(L, __cl_gen_to_be_invoked.BfireScore);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_RaceScore(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.LocalPlayerManager __cl_gen_to_be_invoked = (xc.LocalPlayerManager)translator.FastGetCSObj(L, 1);
                LuaAPI.xlua_pushuint(L, __cl_gen_to_be_invoked.RaceScore);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_ActivityScore(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.LocalPlayerManager __cl_gen_to_be_invoked = (xc.LocalPlayerManager)translator.FastGetCSObj(L, 1);
                LuaAPI.xlua_pushuint(L, __cl_gen_to_be_invoked.ActivityScore);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_TrigramSp(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.LocalPlayerManager __cl_gen_to_be_invoked = (xc.LocalPlayerManager)translator.FastGetCSObj(L, 1);
                LuaAPI.xlua_pushuint(L, __cl_gen_to_be_invoked.TrigramSp);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_HangTime(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.LocalPlayerManager __cl_gen_to_be_invoked = (xc.LocalPlayerManager)translator.FastGetCSObj(L, 1);
                LuaAPI.xlua_pushuint(L, __cl_gen_to_be_invoked.HangTime);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_Fury(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.LocalPlayerManager __cl_gen_to_be_invoked = (xc.LocalPlayerManager)translator.FastGetCSObj(L, 1);
                LuaAPI.xlua_pushuint(L, __cl_gen_to_be_invoked.Fury);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_MoneyData(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.LocalPlayerManager __cl_gen_to_be_invoked = (xc.LocalPlayerManager)translator.FastGetCSObj(L, 1);
                translator.Push(L, __cl_gen_to_be_invoked.MoneyData);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_WorldLevel(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.LocalPlayerManager __cl_gen_to_be_invoked = (xc.LocalPlayerManager)translator.FastGetCSObj(L, 1);
                LuaAPI.xlua_pushuint(L, __cl_gen_to_be_invoked.WorldLevel);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_LimitLevel(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.LocalPlayerManager __cl_gen_to_be_invoked = (xc.LocalPlayerManager)translator.FastGetCSObj(L, 1);
                LuaAPI.xlua_pushuint(L, __cl_gen_to_be_invoked.LimitLevel);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_HiBreak(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.LocalPlayerManager __cl_gen_to_be_invoked = (xc.LocalPlayerManager)translator.FastGetCSObj(L, 1);
                LuaAPI.xlua_pushuint(L, __cl_gen_to_be_invoked.HiBreak);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_ReaminLvPoint(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.LocalPlayerManager __cl_gen_to_be_invoked = (xc.LocalPlayerManager)translator.FastGetCSObj(L, 1);
                LuaAPI.xlua_pushuint(L, __cl_gen_to_be_invoked.ReaminLvPoint);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_MountLv(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.LocalPlayerManager __cl_gen_to_be_invoked = (xc.LocalPlayerManager)translator.FastGetCSObj(L, 1);
                LuaAPI.xlua_pushuint(L, __cl_gen_to_be_invoked.MountLv);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_m_isFirstLoadingScene(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.LocalPlayerManager __cl_gen_to_be_invoked = (xc.LocalPlayerManager)translator.FastGetCSObj(L, 1);
                LuaAPI.lua_pushboolean(L, __cl_gen_to_be_invoked.m_isFirstLoadingScene);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_m_canShowBuffTips(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.LocalPlayerManager __cl_gen_to_be_invoked = (xc.LocalPlayerManager)translator.FastGetCSObj(L, 1);
                LuaAPI.lua_pushboolean(L, __cl_gen_to_be_invoked.m_canShowBuffTips);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_BornRotation(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.LocalPlayerManager __cl_gen_to_be_invoked = (xc.LocalPlayerManager)translator.FastGetCSObj(L, 1);
                UnityEngine.Quaternion __cl_gen_value;translator.Get(L, 2, out __cl_gen_value);
				__cl_gen_to_be_invoked.BornRotation = __cl_gen_value;
            
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_InBallteStatus(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.LocalPlayerManager __cl_gen_to_be_invoked = (xc.LocalPlayerManager)translator.FastGetCSObj(L, 1);
                __cl_gen_to_be_invoked.InBallteStatus = LuaAPI.lua_toboolean(L, 2);
            
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_GuildID(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.LocalPlayerManager __cl_gen_to_be_invoked = (xc.LocalPlayerManager)translator.FastGetCSObj(L, 1);
                __cl_gen_to_be_invoked.GuildID = LuaAPI.xlua_touint(L, 2);
            
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_GuildName(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.LocalPlayerManager __cl_gen_to_be_invoked = (xc.LocalPlayerManager)translator.FastGetCSObj(L, 1);
                __cl_gen_to_be_invoked.GuildName = LuaAPI.lua_tostring(L, 2);
            
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_MainPetID(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.LocalPlayerManager __cl_gen_to_be_invoked = (xc.LocalPlayerManager)translator.FastGetCSObj(L, 1);
                __cl_gen_to_be_invoked.MainPetID = LuaAPI.xlua_touint(L, 2);
            
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_MountId(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.LocalPlayerManager __cl_gen_to_be_invoked = (xc.LocalPlayerManager)translator.FastGetCSObj(L, 1);
                __cl_gen_to_be_invoked.MountId = LuaAPI.xlua_touint(L, 2);
            
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_FristGetNewMountId(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.LocalPlayerManager __cl_gen_to_be_invoked = (xc.LocalPlayerManager)translator.FastGetCSObj(L, 1);
                __cl_gen_to_be_invoked.FristGetNewMountId = LuaAPI.xlua_touint(L, 2);
            
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_LocalActorAttribute(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.LocalPlayerManager __cl_gen_to_be_invoked = (xc.LocalPlayerManager)translator.FastGetCSObj(L, 1);
                __cl_gen_to_be_invoked.LocalActorAttribute = (xc.ActorAttributeData)translator.GetObject(L, 2, typeof(xc.ActorAttributeData));
            
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_Exp(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.LocalPlayerManager __cl_gen_to_be_invoked = (xc.LocalPlayerManager)translator.FastGetCSObj(L, 1);
                __cl_gen_to_be_invoked.Exp = LuaAPI.lua_touint64(L, 2);
            
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_ExpMax(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.LocalPlayerManager __cl_gen_to_be_invoked = (xc.LocalPlayerManager)translator.FastGetCSObj(L, 1);
                __cl_gen_to_be_invoked.ExpMax = LuaAPI.lua_touint64(L, 2);
            
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_Coin(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.LocalPlayerManager __cl_gen_to_be_invoked = (xc.LocalPlayerManager)translator.FastGetCSObj(L, 1);
                __cl_gen_to_be_invoked.Coin = LuaAPI.xlua_touint(L, 2);
            
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_BindCoin(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.LocalPlayerManager __cl_gen_to_be_invoked = (xc.LocalPlayerManager)translator.FastGetCSObj(L, 1);
                __cl_gen_to_be_invoked.BindCoin = LuaAPI.xlua_touint(L, 2);
            
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_Diamond(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.LocalPlayerManager __cl_gen_to_be_invoked = (xc.LocalPlayerManager)translator.FastGetCSObj(L, 1);
                __cl_gen_to_be_invoked.Diamond = LuaAPI.xlua_touint(L, 2);
            
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_BindDiamond(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.LocalPlayerManager __cl_gen_to_be_invoked = (xc.LocalPlayerManager)translator.FastGetCSObj(L, 1);
                __cl_gen_to_be_invoked.BindDiamond = LuaAPI.xlua_touint(L, 2);
            
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_SoulCream(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.LocalPlayerManager __cl_gen_to_be_invoked = (xc.LocalPlayerManager)translator.FastGetCSObj(L, 1);
                __cl_gen_to_be_invoked.SoulCream = LuaAPI.xlua_touint(L, 2);
            
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_SoulHolyWater(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.LocalPlayerManager __cl_gen_to_be_invoked = (xc.LocalPlayerManager)translator.FastGetCSObj(L, 1);
                __cl_gen_to_be_invoked.SoulHolyWater = LuaAPI.xlua_touint(L, 2);
            
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_GuildMoney(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.LocalPlayerManager __cl_gen_to_be_invoked = (xc.LocalPlayerManager)translator.FastGetCSObj(L, 1);
                __cl_gen_to_be_invoked.GuildMoney = LuaAPI.xlua_touint(L, 2);
            
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_BfireScore(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.LocalPlayerManager __cl_gen_to_be_invoked = (xc.LocalPlayerManager)translator.FastGetCSObj(L, 1);
                __cl_gen_to_be_invoked.BfireScore = LuaAPI.xlua_touint(L, 2);
            
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_RaceScore(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.LocalPlayerManager __cl_gen_to_be_invoked = (xc.LocalPlayerManager)translator.FastGetCSObj(L, 1);
                __cl_gen_to_be_invoked.RaceScore = LuaAPI.xlua_touint(L, 2);
            
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_ActivityScore(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.LocalPlayerManager __cl_gen_to_be_invoked = (xc.LocalPlayerManager)translator.FastGetCSObj(L, 1);
                __cl_gen_to_be_invoked.ActivityScore = LuaAPI.xlua_touint(L, 2);
            
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_TrigramSp(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.LocalPlayerManager __cl_gen_to_be_invoked = (xc.LocalPlayerManager)translator.FastGetCSObj(L, 1);
                __cl_gen_to_be_invoked.TrigramSp = LuaAPI.xlua_touint(L, 2);
            
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_HangTime(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.LocalPlayerManager __cl_gen_to_be_invoked = (xc.LocalPlayerManager)translator.FastGetCSObj(L, 1);
                __cl_gen_to_be_invoked.HangTime = LuaAPI.xlua_touint(L, 2);
            
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_Fury(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.LocalPlayerManager __cl_gen_to_be_invoked = (xc.LocalPlayerManager)translator.FastGetCSObj(L, 1);
                __cl_gen_to_be_invoked.Fury = LuaAPI.xlua_touint(L, 2);
            
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_MoneyData(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.LocalPlayerManager __cl_gen_to_be_invoked = (xc.LocalPlayerManager)translator.FastGetCSObj(L, 1);
                __cl_gen_to_be_invoked.MoneyData = (System.Collections.Generic.Dictionary<ushort, uint>)translator.GetObject(L, 2, typeof(System.Collections.Generic.Dictionary<ushort, uint>));
            
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_WorldLevel(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.LocalPlayerManager __cl_gen_to_be_invoked = (xc.LocalPlayerManager)translator.FastGetCSObj(L, 1);
                __cl_gen_to_be_invoked.WorldLevel = LuaAPI.xlua_touint(L, 2);
            
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_LimitLevel(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.LocalPlayerManager __cl_gen_to_be_invoked = (xc.LocalPlayerManager)translator.FastGetCSObj(L, 1);
                __cl_gen_to_be_invoked.LimitLevel = LuaAPI.xlua_touint(L, 2);
            
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_HiBreak(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.LocalPlayerManager __cl_gen_to_be_invoked = (xc.LocalPlayerManager)translator.FastGetCSObj(L, 1);
                __cl_gen_to_be_invoked.HiBreak = LuaAPI.xlua_touint(L, 2);
            
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_ReaminLvPoint(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.LocalPlayerManager __cl_gen_to_be_invoked = (xc.LocalPlayerManager)translator.FastGetCSObj(L, 1);
                __cl_gen_to_be_invoked.ReaminLvPoint = LuaAPI.xlua_touint(L, 2);
            
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_MountLv(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.LocalPlayerManager __cl_gen_to_be_invoked = (xc.LocalPlayerManager)translator.FastGetCSObj(L, 1);
                __cl_gen_to_be_invoked.MountLv = LuaAPI.xlua_touint(L, 2);
            
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_m_isFirstLoadingScene(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.LocalPlayerManager __cl_gen_to_be_invoked = (xc.LocalPlayerManager)translator.FastGetCSObj(L, 1);
                __cl_gen_to_be_invoked.m_isFirstLoadingScene = LuaAPI.lua_toboolean(L, 2);
            
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_m_canShowBuffTips(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.LocalPlayerManager __cl_gen_to_be_invoked = (xc.LocalPlayerManager)translator.FastGetCSObj(L, 1);
                __cl_gen_to_be_invoked.m_canShowBuffTips = LuaAPI.lua_toboolean(L, 2);
            
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 0;
        }
        
		
		
		
		
    }
}
