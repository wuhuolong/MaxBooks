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
    public class xcDBInstanceTypeControlInstanceTypeInfoWrap
    {
        public static void __Register(RealStatePtr L)
        {
			ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			XUtils.BeginObjectRegister(typeof(xc.DBInstanceTypeControl.InstanceTypeInfo), L, translator, 0, 0, 42, 42);
			
			
			
			XUtils.RegisterFunc(L, XUtils.GETTER_IDX, "m_WarType", _g_get_m_WarType);
            XUtils.RegisterFunc(L, XUtils.GETTER_IDX, "m_WarSubType", _g_get_m_WarSubType);
            XUtils.RegisterFunc(L, XUtils.GETTER_IDX, "m_PrecedentPlayer", _g_get_m_PrecedentPlayer);
            XUtils.RegisterFunc(L, XUtils.GETTER_IDX, "m_CannotHidePlayer", _g_get_m_CannotHidePlayer);
            XUtils.RegisterFunc(L, XUtils.GETTER_IDX, "m_PKLevelLimit", _g_get_m_PKLevelLimit);
            XUtils.RegisterFunc(L, XUtils.GETTER_IDX, "m_UsePKMode", _g_get_m_UsePKMode);
            XUtils.RegisterFunc(L, XUtils.GETTER_IDX, "m_NoShowAtkCampTips", _g_get_m_NoShowAtkCampTips);
            XUtils.RegisterFunc(L, XUtils.GETTER_IDX, "m_IgnoreClickPlayer", _g_get_m_IgnoreClickPlayer);
            XUtils.RegisterFunc(L, XUtils.GETTER_IDX, "m_ForceShowHpBar", _g_get_m_ForceShowHpBar);
            XUtils.RegisterFunc(L, XUtils.GETTER_IDX, "m_ForbidUseGoodsTypes", _g_get_m_ForbidUseGoodsTypes);
            XUtils.RegisterFunc(L, XUtils.GETTER_IDX, "m_ForbidChangePk", _g_get_m_ForbidChangePk);
            XUtils.RegisterFunc(L, XUtils.GETTER_IDX, "m_ForbidOpenWorldMap", _g_get_m_ForbidOpenWorldMap);
            XUtils.RegisterFunc(L, XUtils.GETTER_IDX, "m_HideHpBar", _g_get_m_HideHpBar);
            XUtils.RegisterFunc(L, XUtils.GETTER_IDX, "m_HideCamp", _g_get_m_HideCamp);
            XUtils.RegisterFunc(L, XUtils.GETTER_IDX, "m_ForbidPet", _g_get_m_ForbidPet);
            XUtils.RegisterFunc(L, XUtils.GETTER_IDX, "m_HideTeam", _g_get_m_HideTeam);
            XUtils.RegisterFunc(L, XUtils.GETTER_IDX, "m_ForbidTeam", _g_get_m_ForbidTeam);
            XUtils.RegisterFunc(L, XUtils.GETTER_IDX, "m_HidePvpHpBar", _g_get_m_HidePvpHpBar);
            XUtils.RegisterFunc(L, XUtils.GETTER_IDX, "m_AutoPickDrop", _g_get_m_AutoPickDrop);
            XUtils.RegisterFunc(L, XUtils.GETTER_IDX, "m_IsShowAutoFightingGotExp", _g_get_m_IsShowAutoFightingGotExp);
            XUtils.RegisterFunc(L, XUtils.GETTER_IDX, "m_ShowDanmakuChatChannels", _g_get_m_ShowDanmakuChatChannels);
            XUtils.RegisterFunc(L, XUtils.GETTER_IDX, "m_ActId", _g_get_m_ActId);
            XUtils.RegisterFunc(L, XUtils.GETTER_IDX, "m_ExitTips", _g_get_m_ExitTips);
            XUtils.RegisterFunc(L, XUtils.GETTER_IDX, "m_is_can_exit", _g_get_m_is_can_exit);
            XUtils.RegisterFunc(L, XUtils.GETTER_IDX, "m_ForbidJumpOutAnimationOut", _g_get_m_ForbidJumpOutAnimationOut);
            XUtils.RegisterFunc(L, XUtils.GETTER_IDX, "m_ForbidJumpOutAnimationIn", _g_get_m_ForbidJumpOutAnimationIn);
            XUtils.RegisterFunc(L, XUtils.GETTER_IDX, "m_PlayJumpOutAnimationTeamIn", _g_get_m_PlayJumpOutAnimationTeamIn);
            XUtils.RegisterFunc(L, XUtils.GETTER_IDX, "m_HideCount", _g_get_m_HideCount);
            XUtils.RegisterFunc(L, XUtils.GETTER_IDX, "m_ForbidElfin", _g_get_m_ForbidElfin);
            XUtils.RegisterFunc(L, XUtils.GETTER_IDX, "m_ForbidMagicPet", _g_get_m_ForbidMagicPet);
            XUtils.RegisterFunc(L, XUtils.GETTER_IDX, "m_replace_name", _g_get_m_replace_name);
            XUtils.RegisterFunc(L, XUtils.GETTER_IDX, "m_BanShortCutWin", _g_get_m_BanShortCutWin);
            XUtils.RegisterFunc(L, XUtils.GETTER_IDX, "m_BanBossNoticeWin", _g_get_m_BanBossNoticeWin);
            XUtils.RegisterFunc(L, XUtils.GETTER_IDX, "m_BanMarriageNoticeWin", _g_get_m_BanMarriageNoticeWin);
            XUtils.RegisterFunc(L, XUtils.GETTER_IDX, "m_hide_guild", _g_get_m_hide_guild);
            XUtils.RegisterFunc(L, XUtils.GETTER_IDX, "m_hide_mate", _g_get_m_hide_mate);
            XUtils.RegisterFunc(L, XUtils.GETTER_IDX, "m_NoFlyShoe", _g_get_m_NoFlyShoe);
            XUtils.RegisterFunc(L, XUtils.GETTER_IDX, "m_AutoCollect", _g_get_m_AutoCollect);
            XUtils.RegisterFunc(L, XUtils.GETTER_IDX, "m_DoNotPatrol", _g_get_m_DoNotPatrol);
            XUtils.RegisterFunc(L, XUtils.GETTER_IDX, "m_ShowServerName", _g_get_m_ShowServerName);
            XUtils.RegisterFunc(L, XUtils.GETTER_IDX, "m_ClearCd", _g_get_m_ClearCd);
            XUtils.RegisterFunc(L, XUtils.GETTER_IDX, "m_MinPlayerCount", _g_get_m_MinPlayerCount);
            
			XUtils.RegisterFunc(L, XUtils.SETTER_IDX, "m_WarType", _s_set_m_WarType);
            XUtils.RegisterFunc(L, XUtils.SETTER_IDX, "m_WarSubType", _s_set_m_WarSubType);
            XUtils.RegisterFunc(L, XUtils.SETTER_IDX, "m_PrecedentPlayer", _s_set_m_PrecedentPlayer);
            XUtils.RegisterFunc(L, XUtils.SETTER_IDX, "m_CannotHidePlayer", _s_set_m_CannotHidePlayer);
            XUtils.RegisterFunc(L, XUtils.SETTER_IDX, "m_PKLevelLimit", _s_set_m_PKLevelLimit);
            XUtils.RegisterFunc(L, XUtils.SETTER_IDX, "m_UsePKMode", _s_set_m_UsePKMode);
            XUtils.RegisterFunc(L, XUtils.SETTER_IDX, "m_NoShowAtkCampTips", _s_set_m_NoShowAtkCampTips);
            XUtils.RegisterFunc(L, XUtils.SETTER_IDX, "m_IgnoreClickPlayer", _s_set_m_IgnoreClickPlayer);
            XUtils.RegisterFunc(L, XUtils.SETTER_IDX, "m_ForceShowHpBar", _s_set_m_ForceShowHpBar);
            XUtils.RegisterFunc(L, XUtils.SETTER_IDX, "m_ForbidUseGoodsTypes", _s_set_m_ForbidUseGoodsTypes);
            XUtils.RegisterFunc(L, XUtils.SETTER_IDX, "m_ForbidChangePk", _s_set_m_ForbidChangePk);
            XUtils.RegisterFunc(L, XUtils.SETTER_IDX, "m_ForbidOpenWorldMap", _s_set_m_ForbidOpenWorldMap);
            XUtils.RegisterFunc(L, XUtils.SETTER_IDX, "m_HideHpBar", _s_set_m_HideHpBar);
            XUtils.RegisterFunc(L, XUtils.SETTER_IDX, "m_HideCamp", _s_set_m_HideCamp);
            XUtils.RegisterFunc(L, XUtils.SETTER_IDX, "m_ForbidPet", _s_set_m_ForbidPet);
            XUtils.RegisterFunc(L, XUtils.SETTER_IDX, "m_HideTeam", _s_set_m_HideTeam);
            XUtils.RegisterFunc(L, XUtils.SETTER_IDX, "m_ForbidTeam", _s_set_m_ForbidTeam);
            XUtils.RegisterFunc(L, XUtils.SETTER_IDX, "m_HidePvpHpBar", _s_set_m_HidePvpHpBar);
            XUtils.RegisterFunc(L, XUtils.SETTER_IDX, "m_AutoPickDrop", _s_set_m_AutoPickDrop);
            XUtils.RegisterFunc(L, XUtils.SETTER_IDX, "m_IsShowAutoFightingGotExp", _s_set_m_IsShowAutoFightingGotExp);
            XUtils.RegisterFunc(L, XUtils.SETTER_IDX, "m_ShowDanmakuChatChannels", _s_set_m_ShowDanmakuChatChannels);
            XUtils.RegisterFunc(L, XUtils.SETTER_IDX, "m_ActId", _s_set_m_ActId);
            XUtils.RegisterFunc(L, XUtils.SETTER_IDX, "m_ExitTips", _s_set_m_ExitTips);
            XUtils.RegisterFunc(L, XUtils.SETTER_IDX, "m_is_can_exit", _s_set_m_is_can_exit);
            XUtils.RegisterFunc(L, XUtils.SETTER_IDX, "m_ForbidJumpOutAnimationOut", _s_set_m_ForbidJumpOutAnimationOut);
            XUtils.RegisterFunc(L, XUtils.SETTER_IDX, "m_ForbidJumpOutAnimationIn", _s_set_m_ForbidJumpOutAnimationIn);
            XUtils.RegisterFunc(L, XUtils.SETTER_IDX, "m_PlayJumpOutAnimationTeamIn", _s_set_m_PlayJumpOutAnimationTeamIn);
            XUtils.RegisterFunc(L, XUtils.SETTER_IDX, "m_HideCount", _s_set_m_HideCount);
            XUtils.RegisterFunc(L, XUtils.SETTER_IDX, "m_ForbidElfin", _s_set_m_ForbidElfin);
            XUtils.RegisterFunc(L, XUtils.SETTER_IDX, "m_ForbidMagicPet", _s_set_m_ForbidMagicPet);
            XUtils.RegisterFunc(L, XUtils.SETTER_IDX, "m_replace_name", _s_set_m_replace_name);
            XUtils.RegisterFunc(L, XUtils.SETTER_IDX, "m_BanShortCutWin", _s_set_m_BanShortCutWin);
            XUtils.RegisterFunc(L, XUtils.SETTER_IDX, "m_BanBossNoticeWin", _s_set_m_BanBossNoticeWin);
            XUtils.RegisterFunc(L, XUtils.SETTER_IDX, "m_BanMarriageNoticeWin", _s_set_m_BanMarriageNoticeWin);
            XUtils.RegisterFunc(L, XUtils.SETTER_IDX, "m_hide_guild", _s_set_m_hide_guild);
            XUtils.RegisterFunc(L, XUtils.SETTER_IDX, "m_hide_mate", _s_set_m_hide_mate);
            XUtils.RegisterFunc(L, XUtils.SETTER_IDX, "m_NoFlyShoe", _s_set_m_NoFlyShoe);
            XUtils.RegisterFunc(L, XUtils.SETTER_IDX, "m_AutoCollect", _s_set_m_AutoCollect);
            XUtils.RegisterFunc(L, XUtils.SETTER_IDX, "m_DoNotPatrol", _s_set_m_DoNotPatrol);
            XUtils.RegisterFunc(L, XUtils.SETTER_IDX, "m_ShowServerName", _s_set_m_ShowServerName);
            XUtils.RegisterFunc(L, XUtils.SETTER_IDX, "m_ClearCd", _s_set_m_ClearCd);
            XUtils.RegisterFunc(L, XUtils.SETTER_IDX, "m_MinPlayerCount", _s_set_m_MinPlayerCount);
            
			XUtils.EndObjectRegister(typeof(xc.DBInstanceTypeControl.InstanceTypeInfo), L, translator, null, null,
			    null, null, null);

		    XUtils.BeginClassRegister(typeof(xc.DBInstanceTypeControl.InstanceTypeInfo), L, __CreateInstance, 1, 0, 0);
			
			
            
            XUtils.RegisterObject(L, translator, XUtils.CLS_IDX, "UnderlyingSystemType", typeof(xc.DBInstanceTypeControl.InstanceTypeInfo));
			
			
			XUtils.EndClassRegister(typeof(xc.DBInstanceTypeControl.InstanceTypeInfo), L, translator);
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int __CreateInstance(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			try {
				if(LuaAPI.lua_gettop(L) == 1)
				{
					
					xc.DBInstanceTypeControl.InstanceTypeInfo __cl_gen_ret = new xc.DBInstanceTypeControl.InstanceTypeInfo();
					translator.Push(L, __cl_gen_ret);
					return 1;
				}
				
			}
			catch(System.Exception __gen_e) {
				return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
			}
            return LuaAPI.luaL_error(L, "invalid arguments to xc.DBInstanceTypeControl.InstanceTypeInfo constructor!");
            
        }
        
		
        
		
        
        
        
        
        
        
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_m_WarType(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.DBInstanceTypeControl.InstanceTypeInfo __cl_gen_to_be_invoked = (xc.DBInstanceTypeControl.InstanceTypeInfo)translator.FastGetCSObj(L, 1);
                LuaAPI.xlua_pushuint(L, __cl_gen_to_be_invoked.m_WarType);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_m_WarSubType(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.DBInstanceTypeControl.InstanceTypeInfo __cl_gen_to_be_invoked = (xc.DBInstanceTypeControl.InstanceTypeInfo)translator.FastGetCSObj(L, 1);
                LuaAPI.xlua_pushuint(L, __cl_gen_to_be_invoked.m_WarSubType);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_m_PrecedentPlayer(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.DBInstanceTypeControl.InstanceTypeInfo __cl_gen_to_be_invoked = (xc.DBInstanceTypeControl.InstanceTypeInfo)translator.FastGetCSObj(L, 1);
                LuaAPI.lua_pushboolean(L, __cl_gen_to_be_invoked.m_PrecedentPlayer);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_m_CannotHidePlayer(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.DBInstanceTypeControl.InstanceTypeInfo __cl_gen_to_be_invoked = (xc.DBInstanceTypeControl.InstanceTypeInfo)translator.FastGetCSObj(L, 1);
                LuaAPI.lua_pushboolean(L, __cl_gen_to_be_invoked.m_CannotHidePlayer);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_m_PKLevelLimit(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.DBInstanceTypeControl.InstanceTypeInfo __cl_gen_to_be_invoked = (xc.DBInstanceTypeControl.InstanceTypeInfo)translator.FastGetCSObj(L, 1);
                LuaAPI.lua_pushboolean(L, __cl_gen_to_be_invoked.m_PKLevelLimit);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_m_UsePKMode(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.DBInstanceTypeControl.InstanceTypeInfo __cl_gen_to_be_invoked = (xc.DBInstanceTypeControl.InstanceTypeInfo)translator.FastGetCSObj(L, 1);
                LuaAPI.lua_pushboolean(L, __cl_gen_to_be_invoked.m_UsePKMode);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_m_NoShowAtkCampTips(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.DBInstanceTypeControl.InstanceTypeInfo __cl_gen_to_be_invoked = (xc.DBInstanceTypeControl.InstanceTypeInfo)translator.FastGetCSObj(L, 1);
                LuaAPI.lua_pushboolean(L, __cl_gen_to_be_invoked.m_NoShowAtkCampTips);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_m_IgnoreClickPlayer(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.DBInstanceTypeControl.InstanceTypeInfo __cl_gen_to_be_invoked = (xc.DBInstanceTypeControl.InstanceTypeInfo)translator.FastGetCSObj(L, 1);
                LuaAPI.lua_pushboolean(L, __cl_gen_to_be_invoked.m_IgnoreClickPlayer);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_m_ForceShowHpBar(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.DBInstanceTypeControl.InstanceTypeInfo __cl_gen_to_be_invoked = (xc.DBInstanceTypeControl.InstanceTypeInfo)translator.FastGetCSObj(L, 1);
                LuaAPI.lua_pushboolean(L, __cl_gen_to_be_invoked.m_ForceShowHpBar);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_m_ForbidUseGoodsTypes(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.DBInstanceTypeControl.InstanceTypeInfo __cl_gen_to_be_invoked = (xc.DBInstanceTypeControl.InstanceTypeInfo)translator.FastGetCSObj(L, 1);
                translator.Push(L, __cl_gen_to_be_invoked.m_ForbidUseGoodsTypes);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_m_ForbidChangePk(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.DBInstanceTypeControl.InstanceTypeInfo __cl_gen_to_be_invoked = (xc.DBInstanceTypeControl.InstanceTypeInfo)translator.FastGetCSObj(L, 1);
                LuaAPI.lua_pushboolean(L, __cl_gen_to_be_invoked.m_ForbidChangePk);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_m_ForbidOpenWorldMap(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.DBInstanceTypeControl.InstanceTypeInfo __cl_gen_to_be_invoked = (xc.DBInstanceTypeControl.InstanceTypeInfo)translator.FastGetCSObj(L, 1);
                LuaAPI.lua_pushboolean(L, __cl_gen_to_be_invoked.m_ForbidOpenWorldMap);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_m_HideHpBar(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.DBInstanceTypeControl.InstanceTypeInfo __cl_gen_to_be_invoked = (xc.DBInstanceTypeControl.InstanceTypeInfo)translator.FastGetCSObj(L, 1);
                LuaAPI.lua_pushboolean(L, __cl_gen_to_be_invoked.m_HideHpBar);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_m_HideCamp(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.DBInstanceTypeControl.InstanceTypeInfo __cl_gen_to_be_invoked = (xc.DBInstanceTypeControl.InstanceTypeInfo)translator.FastGetCSObj(L, 1);
                LuaAPI.lua_pushboolean(L, __cl_gen_to_be_invoked.m_HideCamp);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_m_ForbidPet(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.DBInstanceTypeControl.InstanceTypeInfo __cl_gen_to_be_invoked = (xc.DBInstanceTypeControl.InstanceTypeInfo)translator.FastGetCSObj(L, 1);
                LuaAPI.lua_pushboolean(L, __cl_gen_to_be_invoked.m_ForbidPet);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_m_HideTeam(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.DBInstanceTypeControl.InstanceTypeInfo __cl_gen_to_be_invoked = (xc.DBInstanceTypeControl.InstanceTypeInfo)translator.FastGetCSObj(L, 1);
                LuaAPI.lua_pushboolean(L, __cl_gen_to_be_invoked.m_HideTeam);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_m_ForbidTeam(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.DBInstanceTypeControl.InstanceTypeInfo __cl_gen_to_be_invoked = (xc.DBInstanceTypeControl.InstanceTypeInfo)translator.FastGetCSObj(L, 1);
                LuaAPI.lua_pushboolean(L, __cl_gen_to_be_invoked.m_ForbidTeam);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_m_HidePvpHpBar(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.DBInstanceTypeControl.InstanceTypeInfo __cl_gen_to_be_invoked = (xc.DBInstanceTypeControl.InstanceTypeInfo)translator.FastGetCSObj(L, 1);
                LuaAPI.lua_pushboolean(L, __cl_gen_to_be_invoked.m_HidePvpHpBar);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_m_AutoPickDrop(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.DBInstanceTypeControl.InstanceTypeInfo __cl_gen_to_be_invoked = (xc.DBInstanceTypeControl.InstanceTypeInfo)translator.FastGetCSObj(L, 1);
                LuaAPI.lua_pushboolean(L, __cl_gen_to_be_invoked.m_AutoPickDrop);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_m_IsShowAutoFightingGotExp(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.DBInstanceTypeControl.InstanceTypeInfo __cl_gen_to_be_invoked = (xc.DBInstanceTypeControl.InstanceTypeInfo)translator.FastGetCSObj(L, 1);
                LuaAPI.lua_pushboolean(L, __cl_gen_to_be_invoked.m_IsShowAutoFightingGotExp);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_m_ShowDanmakuChatChannels(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.DBInstanceTypeControl.InstanceTypeInfo __cl_gen_to_be_invoked = (xc.DBInstanceTypeControl.InstanceTypeInfo)translator.FastGetCSObj(L, 1);
                translator.Push(L, __cl_gen_to_be_invoked.m_ShowDanmakuChatChannels);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_m_ActId(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.DBInstanceTypeControl.InstanceTypeInfo __cl_gen_to_be_invoked = (xc.DBInstanceTypeControl.InstanceTypeInfo)translator.FastGetCSObj(L, 1);
                LuaAPI.xlua_pushuint(L, __cl_gen_to_be_invoked.m_ActId);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_m_ExitTips(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.DBInstanceTypeControl.InstanceTypeInfo __cl_gen_to_be_invoked = (xc.DBInstanceTypeControl.InstanceTypeInfo)translator.FastGetCSObj(L, 1);
                LuaAPI.lua_pushstring(L, __cl_gen_to_be_invoked.m_ExitTips);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_m_is_can_exit(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.DBInstanceTypeControl.InstanceTypeInfo __cl_gen_to_be_invoked = (xc.DBInstanceTypeControl.InstanceTypeInfo)translator.FastGetCSObj(L, 1);
                LuaAPI.lua_pushboolean(L, __cl_gen_to_be_invoked.m_is_can_exit);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_m_ForbidJumpOutAnimationOut(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.DBInstanceTypeControl.InstanceTypeInfo __cl_gen_to_be_invoked = (xc.DBInstanceTypeControl.InstanceTypeInfo)translator.FastGetCSObj(L, 1);
                LuaAPI.lua_pushboolean(L, __cl_gen_to_be_invoked.m_ForbidJumpOutAnimationOut);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_m_ForbidJumpOutAnimationIn(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.DBInstanceTypeControl.InstanceTypeInfo __cl_gen_to_be_invoked = (xc.DBInstanceTypeControl.InstanceTypeInfo)translator.FastGetCSObj(L, 1);
                LuaAPI.lua_pushboolean(L, __cl_gen_to_be_invoked.m_ForbidJumpOutAnimationIn);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_m_PlayJumpOutAnimationTeamIn(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.DBInstanceTypeControl.InstanceTypeInfo __cl_gen_to_be_invoked = (xc.DBInstanceTypeControl.InstanceTypeInfo)translator.FastGetCSObj(L, 1);
                LuaAPI.lua_pushboolean(L, __cl_gen_to_be_invoked.m_PlayJumpOutAnimationTeamIn);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_m_HideCount(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.DBInstanceTypeControl.InstanceTypeInfo __cl_gen_to_be_invoked = (xc.DBInstanceTypeControl.InstanceTypeInfo)translator.FastGetCSObj(L, 1);
                LuaAPI.lua_pushboolean(L, __cl_gen_to_be_invoked.m_HideCount);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_m_ForbidElfin(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.DBInstanceTypeControl.InstanceTypeInfo __cl_gen_to_be_invoked = (xc.DBInstanceTypeControl.InstanceTypeInfo)translator.FastGetCSObj(L, 1);
                LuaAPI.lua_pushboolean(L, __cl_gen_to_be_invoked.m_ForbidElfin);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_m_ForbidMagicPet(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.DBInstanceTypeControl.InstanceTypeInfo __cl_gen_to_be_invoked = (xc.DBInstanceTypeControl.InstanceTypeInfo)translator.FastGetCSObj(L, 1);
                LuaAPI.lua_pushboolean(L, __cl_gen_to_be_invoked.m_ForbidMagicPet);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_m_replace_name(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.DBInstanceTypeControl.InstanceTypeInfo __cl_gen_to_be_invoked = (xc.DBInstanceTypeControl.InstanceTypeInfo)translator.FastGetCSObj(L, 1);
                LuaAPI.lua_pushstring(L, __cl_gen_to_be_invoked.m_replace_name);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_m_BanShortCutWin(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.DBInstanceTypeControl.InstanceTypeInfo __cl_gen_to_be_invoked = (xc.DBInstanceTypeControl.InstanceTypeInfo)translator.FastGetCSObj(L, 1);
                LuaAPI.lua_pushboolean(L, __cl_gen_to_be_invoked.m_BanShortCutWin);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_m_BanBossNoticeWin(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.DBInstanceTypeControl.InstanceTypeInfo __cl_gen_to_be_invoked = (xc.DBInstanceTypeControl.InstanceTypeInfo)translator.FastGetCSObj(L, 1);
                LuaAPI.lua_pushboolean(L, __cl_gen_to_be_invoked.m_BanBossNoticeWin);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_m_BanMarriageNoticeWin(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.DBInstanceTypeControl.InstanceTypeInfo __cl_gen_to_be_invoked = (xc.DBInstanceTypeControl.InstanceTypeInfo)translator.FastGetCSObj(L, 1);
                LuaAPI.lua_pushboolean(L, __cl_gen_to_be_invoked.m_BanMarriageNoticeWin);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_m_hide_guild(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.DBInstanceTypeControl.InstanceTypeInfo __cl_gen_to_be_invoked = (xc.DBInstanceTypeControl.InstanceTypeInfo)translator.FastGetCSObj(L, 1);
                LuaAPI.lua_pushboolean(L, __cl_gen_to_be_invoked.m_hide_guild);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_m_hide_mate(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.DBInstanceTypeControl.InstanceTypeInfo __cl_gen_to_be_invoked = (xc.DBInstanceTypeControl.InstanceTypeInfo)translator.FastGetCSObj(L, 1);
                LuaAPI.lua_pushboolean(L, __cl_gen_to_be_invoked.m_hide_mate);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_m_NoFlyShoe(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.DBInstanceTypeControl.InstanceTypeInfo __cl_gen_to_be_invoked = (xc.DBInstanceTypeControl.InstanceTypeInfo)translator.FastGetCSObj(L, 1);
                LuaAPI.lua_pushboolean(L, __cl_gen_to_be_invoked.m_NoFlyShoe);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_m_AutoCollect(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.DBInstanceTypeControl.InstanceTypeInfo __cl_gen_to_be_invoked = (xc.DBInstanceTypeControl.InstanceTypeInfo)translator.FastGetCSObj(L, 1);
                LuaAPI.lua_pushboolean(L, __cl_gen_to_be_invoked.m_AutoCollect);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_m_DoNotPatrol(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.DBInstanceTypeControl.InstanceTypeInfo __cl_gen_to_be_invoked = (xc.DBInstanceTypeControl.InstanceTypeInfo)translator.FastGetCSObj(L, 1);
                LuaAPI.lua_pushboolean(L, __cl_gen_to_be_invoked.m_DoNotPatrol);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_m_ShowServerName(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.DBInstanceTypeControl.InstanceTypeInfo __cl_gen_to_be_invoked = (xc.DBInstanceTypeControl.InstanceTypeInfo)translator.FastGetCSObj(L, 1);
                LuaAPI.lua_pushboolean(L, __cl_gen_to_be_invoked.m_ShowServerName);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_m_ClearCd(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.DBInstanceTypeControl.InstanceTypeInfo __cl_gen_to_be_invoked = (xc.DBInstanceTypeControl.InstanceTypeInfo)translator.FastGetCSObj(L, 1);
                LuaAPI.lua_pushboolean(L, __cl_gen_to_be_invoked.m_ClearCd);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_m_MinPlayerCount(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.DBInstanceTypeControl.InstanceTypeInfo __cl_gen_to_be_invoked = (xc.DBInstanceTypeControl.InstanceTypeInfo)translator.FastGetCSObj(L, 1);
                LuaAPI.xlua_pushuint(L, __cl_gen_to_be_invoked.m_MinPlayerCount);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_m_WarType(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.DBInstanceTypeControl.InstanceTypeInfo __cl_gen_to_be_invoked = (xc.DBInstanceTypeControl.InstanceTypeInfo)translator.FastGetCSObj(L, 1);
                __cl_gen_to_be_invoked.m_WarType = LuaAPI.xlua_touint(L, 2);
            
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_m_WarSubType(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.DBInstanceTypeControl.InstanceTypeInfo __cl_gen_to_be_invoked = (xc.DBInstanceTypeControl.InstanceTypeInfo)translator.FastGetCSObj(L, 1);
                __cl_gen_to_be_invoked.m_WarSubType = LuaAPI.xlua_touint(L, 2);
            
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_m_PrecedentPlayer(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.DBInstanceTypeControl.InstanceTypeInfo __cl_gen_to_be_invoked = (xc.DBInstanceTypeControl.InstanceTypeInfo)translator.FastGetCSObj(L, 1);
                __cl_gen_to_be_invoked.m_PrecedentPlayer = LuaAPI.lua_toboolean(L, 2);
            
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_m_CannotHidePlayer(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.DBInstanceTypeControl.InstanceTypeInfo __cl_gen_to_be_invoked = (xc.DBInstanceTypeControl.InstanceTypeInfo)translator.FastGetCSObj(L, 1);
                __cl_gen_to_be_invoked.m_CannotHidePlayer = LuaAPI.lua_toboolean(L, 2);
            
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_m_PKLevelLimit(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.DBInstanceTypeControl.InstanceTypeInfo __cl_gen_to_be_invoked = (xc.DBInstanceTypeControl.InstanceTypeInfo)translator.FastGetCSObj(L, 1);
                __cl_gen_to_be_invoked.m_PKLevelLimit = LuaAPI.lua_toboolean(L, 2);
            
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_m_UsePKMode(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.DBInstanceTypeControl.InstanceTypeInfo __cl_gen_to_be_invoked = (xc.DBInstanceTypeControl.InstanceTypeInfo)translator.FastGetCSObj(L, 1);
                __cl_gen_to_be_invoked.m_UsePKMode = LuaAPI.lua_toboolean(L, 2);
            
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_m_NoShowAtkCampTips(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.DBInstanceTypeControl.InstanceTypeInfo __cl_gen_to_be_invoked = (xc.DBInstanceTypeControl.InstanceTypeInfo)translator.FastGetCSObj(L, 1);
                __cl_gen_to_be_invoked.m_NoShowAtkCampTips = LuaAPI.lua_toboolean(L, 2);
            
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_m_IgnoreClickPlayer(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.DBInstanceTypeControl.InstanceTypeInfo __cl_gen_to_be_invoked = (xc.DBInstanceTypeControl.InstanceTypeInfo)translator.FastGetCSObj(L, 1);
                __cl_gen_to_be_invoked.m_IgnoreClickPlayer = LuaAPI.lua_toboolean(L, 2);
            
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_m_ForceShowHpBar(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.DBInstanceTypeControl.InstanceTypeInfo __cl_gen_to_be_invoked = (xc.DBInstanceTypeControl.InstanceTypeInfo)translator.FastGetCSObj(L, 1);
                __cl_gen_to_be_invoked.m_ForceShowHpBar = LuaAPI.lua_toboolean(L, 2);
            
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_m_ForbidUseGoodsTypes(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.DBInstanceTypeControl.InstanceTypeInfo __cl_gen_to_be_invoked = (xc.DBInstanceTypeControl.InstanceTypeInfo)translator.FastGetCSObj(L, 1);
                __cl_gen_to_be_invoked.m_ForbidUseGoodsTypes = (System.Collections.Generic.List<System.Collections.Generic.KeyValuePair<uint, uint>>)translator.GetObject(L, 2, typeof(System.Collections.Generic.List<System.Collections.Generic.KeyValuePair<uint, uint>>));
            
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_m_ForbidChangePk(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.DBInstanceTypeControl.InstanceTypeInfo __cl_gen_to_be_invoked = (xc.DBInstanceTypeControl.InstanceTypeInfo)translator.FastGetCSObj(L, 1);
                __cl_gen_to_be_invoked.m_ForbidChangePk = LuaAPI.lua_toboolean(L, 2);
            
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_m_ForbidOpenWorldMap(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.DBInstanceTypeControl.InstanceTypeInfo __cl_gen_to_be_invoked = (xc.DBInstanceTypeControl.InstanceTypeInfo)translator.FastGetCSObj(L, 1);
                __cl_gen_to_be_invoked.m_ForbidOpenWorldMap = LuaAPI.lua_toboolean(L, 2);
            
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_m_HideHpBar(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.DBInstanceTypeControl.InstanceTypeInfo __cl_gen_to_be_invoked = (xc.DBInstanceTypeControl.InstanceTypeInfo)translator.FastGetCSObj(L, 1);
                __cl_gen_to_be_invoked.m_HideHpBar = LuaAPI.lua_toboolean(L, 2);
            
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_m_HideCamp(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.DBInstanceTypeControl.InstanceTypeInfo __cl_gen_to_be_invoked = (xc.DBInstanceTypeControl.InstanceTypeInfo)translator.FastGetCSObj(L, 1);
                __cl_gen_to_be_invoked.m_HideCamp = LuaAPI.lua_toboolean(L, 2);
            
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_m_ForbidPet(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.DBInstanceTypeControl.InstanceTypeInfo __cl_gen_to_be_invoked = (xc.DBInstanceTypeControl.InstanceTypeInfo)translator.FastGetCSObj(L, 1);
                __cl_gen_to_be_invoked.m_ForbidPet = LuaAPI.lua_toboolean(L, 2);
            
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_m_HideTeam(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.DBInstanceTypeControl.InstanceTypeInfo __cl_gen_to_be_invoked = (xc.DBInstanceTypeControl.InstanceTypeInfo)translator.FastGetCSObj(L, 1);
                __cl_gen_to_be_invoked.m_HideTeam = LuaAPI.lua_toboolean(L, 2);
            
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_m_ForbidTeam(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.DBInstanceTypeControl.InstanceTypeInfo __cl_gen_to_be_invoked = (xc.DBInstanceTypeControl.InstanceTypeInfo)translator.FastGetCSObj(L, 1);
                __cl_gen_to_be_invoked.m_ForbidTeam = LuaAPI.lua_toboolean(L, 2);
            
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_m_HidePvpHpBar(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.DBInstanceTypeControl.InstanceTypeInfo __cl_gen_to_be_invoked = (xc.DBInstanceTypeControl.InstanceTypeInfo)translator.FastGetCSObj(L, 1);
                __cl_gen_to_be_invoked.m_HidePvpHpBar = LuaAPI.lua_toboolean(L, 2);
            
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_m_AutoPickDrop(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.DBInstanceTypeControl.InstanceTypeInfo __cl_gen_to_be_invoked = (xc.DBInstanceTypeControl.InstanceTypeInfo)translator.FastGetCSObj(L, 1);
                __cl_gen_to_be_invoked.m_AutoPickDrop = LuaAPI.lua_toboolean(L, 2);
            
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_m_IsShowAutoFightingGotExp(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.DBInstanceTypeControl.InstanceTypeInfo __cl_gen_to_be_invoked = (xc.DBInstanceTypeControl.InstanceTypeInfo)translator.FastGetCSObj(L, 1);
                __cl_gen_to_be_invoked.m_IsShowAutoFightingGotExp = LuaAPI.lua_toboolean(L, 2);
            
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_m_ShowDanmakuChatChannels(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.DBInstanceTypeControl.InstanceTypeInfo __cl_gen_to_be_invoked = (xc.DBInstanceTypeControl.InstanceTypeInfo)translator.FastGetCSObj(L, 1);
                __cl_gen_to_be_invoked.m_ShowDanmakuChatChannels = (System.Collections.Generic.List<uint>)translator.GetObject(L, 2, typeof(System.Collections.Generic.List<uint>));
            
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_m_ActId(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.DBInstanceTypeControl.InstanceTypeInfo __cl_gen_to_be_invoked = (xc.DBInstanceTypeControl.InstanceTypeInfo)translator.FastGetCSObj(L, 1);
                __cl_gen_to_be_invoked.m_ActId = LuaAPI.xlua_touint(L, 2);
            
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_m_ExitTips(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.DBInstanceTypeControl.InstanceTypeInfo __cl_gen_to_be_invoked = (xc.DBInstanceTypeControl.InstanceTypeInfo)translator.FastGetCSObj(L, 1);
                __cl_gen_to_be_invoked.m_ExitTips = LuaAPI.lua_tostring(L, 2);
            
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_m_is_can_exit(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.DBInstanceTypeControl.InstanceTypeInfo __cl_gen_to_be_invoked = (xc.DBInstanceTypeControl.InstanceTypeInfo)translator.FastGetCSObj(L, 1);
                __cl_gen_to_be_invoked.m_is_can_exit = LuaAPI.lua_toboolean(L, 2);
            
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_m_ForbidJumpOutAnimationOut(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.DBInstanceTypeControl.InstanceTypeInfo __cl_gen_to_be_invoked = (xc.DBInstanceTypeControl.InstanceTypeInfo)translator.FastGetCSObj(L, 1);
                __cl_gen_to_be_invoked.m_ForbidJumpOutAnimationOut = LuaAPI.lua_toboolean(L, 2);
            
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_m_ForbidJumpOutAnimationIn(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.DBInstanceTypeControl.InstanceTypeInfo __cl_gen_to_be_invoked = (xc.DBInstanceTypeControl.InstanceTypeInfo)translator.FastGetCSObj(L, 1);
                __cl_gen_to_be_invoked.m_ForbidJumpOutAnimationIn = LuaAPI.lua_toboolean(L, 2);
            
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_m_PlayJumpOutAnimationTeamIn(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.DBInstanceTypeControl.InstanceTypeInfo __cl_gen_to_be_invoked = (xc.DBInstanceTypeControl.InstanceTypeInfo)translator.FastGetCSObj(L, 1);
                __cl_gen_to_be_invoked.m_PlayJumpOutAnimationTeamIn = LuaAPI.lua_toboolean(L, 2);
            
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_m_HideCount(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.DBInstanceTypeControl.InstanceTypeInfo __cl_gen_to_be_invoked = (xc.DBInstanceTypeControl.InstanceTypeInfo)translator.FastGetCSObj(L, 1);
                __cl_gen_to_be_invoked.m_HideCount = LuaAPI.lua_toboolean(L, 2);
            
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_m_ForbidElfin(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.DBInstanceTypeControl.InstanceTypeInfo __cl_gen_to_be_invoked = (xc.DBInstanceTypeControl.InstanceTypeInfo)translator.FastGetCSObj(L, 1);
                __cl_gen_to_be_invoked.m_ForbidElfin = LuaAPI.lua_toboolean(L, 2);
            
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_m_ForbidMagicPet(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.DBInstanceTypeControl.InstanceTypeInfo __cl_gen_to_be_invoked = (xc.DBInstanceTypeControl.InstanceTypeInfo)translator.FastGetCSObj(L, 1);
                __cl_gen_to_be_invoked.m_ForbidMagicPet = LuaAPI.lua_toboolean(L, 2);
            
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_m_replace_name(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.DBInstanceTypeControl.InstanceTypeInfo __cl_gen_to_be_invoked = (xc.DBInstanceTypeControl.InstanceTypeInfo)translator.FastGetCSObj(L, 1);
                __cl_gen_to_be_invoked.m_replace_name = LuaAPI.lua_tostring(L, 2);
            
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_m_BanShortCutWin(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.DBInstanceTypeControl.InstanceTypeInfo __cl_gen_to_be_invoked = (xc.DBInstanceTypeControl.InstanceTypeInfo)translator.FastGetCSObj(L, 1);
                __cl_gen_to_be_invoked.m_BanShortCutWin = LuaAPI.lua_toboolean(L, 2);
            
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_m_BanBossNoticeWin(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.DBInstanceTypeControl.InstanceTypeInfo __cl_gen_to_be_invoked = (xc.DBInstanceTypeControl.InstanceTypeInfo)translator.FastGetCSObj(L, 1);
                __cl_gen_to_be_invoked.m_BanBossNoticeWin = LuaAPI.lua_toboolean(L, 2);
            
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_m_BanMarriageNoticeWin(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.DBInstanceTypeControl.InstanceTypeInfo __cl_gen_to_be_invoked = (xc.DBInstanceTypeControl.InstanceTypeInfo)translator.FastGetCSObj(L, 1);
                __cl_gen_to_be_invoked.m_BanMarriageNoticeWin = LuaAPI.lua_toboolean(L, 2);
            
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_m_hide_guild(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.DBInstanceTypeControl.InstanceTypeInfo __cl_gen_to_be_invoked = (xc.DBInstanceTypeControl.InstanceTypeInfo)translator.FastGetCSObj(L, 1);
                __cl_gen_to_be_invoked.m_hide_guild = LuaAPI.lua_toboolean(L, 2);
            
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_m_hide_mate(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.DBInstanceTypeControl.InstanceTypeInfo __cl_gen_to_be_invoked = (xc.DBInstanceTypeControl.InstanceTypeInfo)translator.FastGetCSObj(L, 1);
                __cl_gen_to_be_invoked.m_hide_mate = LuaAPI.lua_toboolean(L, 2);
            
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_m_NoFlyShoe(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.DBInstanceTypeControl.InstanceTypeInfo __cl_gen_to_be_invoked = (xc.DBInstanceTypeControl.InstanceTypeInfo)translator.FastGetCSObj(L, 1);
                __cl_gen_to_be_invoked.m_NoFlyShoe = LuaAPI.lua_toboolean(L, 2);
            
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_m_AutoCollect(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.DBInstanceTypeControl.InstanceTypeInfo __cl_gen_to_be_invoked = (xc.DBInstanceTypeControl.InstanceTypeInfo)translator.FastGetCSObj(L, 1);
                __cl_gen_to_be_invoked.m_AutoCollect = LuaAPI.lua_toboolean(L, 2);
            
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_m_DoNotPatrol(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.DBInstanceTypeControl.InstanceTypeInfo __cl_gen_to_be_invoked = (xc.DBInstanceTypeControl.InstanceTypeInfo)translator.FastGetCSObj(L, 1);
                __cl_gen_to_be_invoked.m_DoNotPatrol = LuaAPI.lua_toboolean(L, 2);
            
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_m_ShowServerName(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.DBInstanceTypeControl.InstanceTypeInfo __cl_gen_to_be_invoked = (xc.DBInstanceTypeControl.InstanceTypeInfo)translator.FastGetCSObj(L, 1);
                __cl_gen_to_be_invoked.m_ShowServerName = LuaAPI.lua_toboolean(L, 2);
            
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_m_ClearCd(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.DBInstanceTypeControl.InstanceTypeInfo __cl_gen_to_be_invoked = (xc.DBInstanceTypeControl.InstanceTypeInfo)translator.FastGetCSObj(L, 1);
                __cl_gen_to_be_invoked.m_ClearCd = LuaAPI.lua_toboolean(L, 2);
            
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_m_MinPlayerCount(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.DBInstanceTypeControl.InstanceTypeInfo __cl_gen_to_be_invoked = (xc.DBInstanceTypeControl.InstanceTypeInfo)translator.FastGetCSObj(L, 1);
                __cl_gen_to_be_invoked.m_MinPlayerCount = LuaAPI.xlua_touint(L, 2);
            
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 0;
        }
        
		
		
		
		
    }
}
