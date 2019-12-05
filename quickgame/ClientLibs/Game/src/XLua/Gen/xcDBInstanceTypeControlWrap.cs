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
    public class xcDBInstanceTypeControlWrap
    {
        public static void __Register(RealStatePtr L)
        {
			ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			XUtils.BeginObjectRegister(typeof(xc.DBInstanceTypeControl), L, translator, 0, 42, 0, 0);
			
			XUtils.RegisterFunc(L, XUtils.METHOD_IDX, "Load", _m_Load);
			XUtils.RegisterFunc(L, XUtils.METHOD_IDX, "PrecedentPlayer", _m_PrecedentPlayer);
			XUtils.RegisterFunc(L, XUtils.METHOD_IDX, "CannotHidePlayer", _m_CannotHidePlayer);
			XUtils.RegisterFunc(L, XUtils.METHOD_IDX, "PKLevelLimit", _m_PKLevelLimit);
			XUtils.RegisterFunc(L, XUtils.METHOD_IDX, "UsePKMode", _m_UsePKMode);
			XUtils.RegisterFunc(L, XUtils.METHOD_IDX, "NoShowAtkCampTips", _m_NoShowAtkCampTips);
			XUtils.RegisterFunc(L, XUtils.METHOD_IDX, "IgnoreClickPlayer", _m_IgnoreClickPlayer);
			XUtils.RegisterFunc(L, XUtils.METHOD_IDX, "ForceShowHpBar", _m_ForceShowHpBar);
			XUtils.RegisterFunc(L, XUtils.METHOD_IDX, "ForbidUseGoods", _m_ForbidUseGoods);
			XUtils.RegisterFunc(L, XUtils.METHOD_IDX, "ForbiChangePkMode", _m_ForbiChangePkMode);
			XUtils.RegisterFunc(L, XUtils.METHOD_IDX, "ShowDanmakuSwitch", _m_ShowDanmakuSwitch);
			XUtils.RegisterFunc(L, XUtils.METHOD_IDX, "ShowDanmaku", _m_ShowDanmaku);
			XUtils.RegisterFunc(L, XUtils.METHOD_IDX, "ForbidOpenWorldMap", _m_ForbidOpenWorldMap);
			XUtils.RegisterFunc(L, XUtils.METHOD_IDX, "HideHpBar", _m_HideHpBar);
			XUtils.RegisterFunc(L, XUtils.METHOD_IDX, "HideCamp", _m_HideCamp);
			XUtils.RegisterFunc(L, XUtils.METHOD_IDX, "ForbidPet", _m_ForbidPet);
			XUtils.RegisterFunc(L, XUtils.METHOD_IDX, "HideTeam", _m_HideTeam);
			XUtils.RegisterFunc(L, XUtils.METHOD_IDX, "ForbidTeam", _m_ForbidTeam);
			XUtils.RegisterFunc(L, XUtils.METHOD_IDX, "HidePvpHpBar", _m_HidePvpHpBar);
			XUtils.RegisterFunc(L, XUtils.METHOD_IDX, "AutoPickDrop", _m_AutoPickDrop);
			XUtils.RegisterFunc(L, XUtils.METHOD_IDX, "IsShowAutoFightingGotExp", _m_IsShowAutoFightingGotExp);
			XUtils.RegisterFunc(L, XUtils.METHOD_IDX, "GetActivityId", _m_GetActivityId);
			XUtils.RegisterFunc(L, XUtils.METHOD_IDX, "GetExitTips", _m_GetExitTips);
			XUtils.RegisterFunc(L, XUtils.METHOD_IDX, "GetCanExit", _m_GetCanExit);
			XUtils.RegisterFunc(L, XUtils.METHOD_IDX, "IsBanShortCutWin", _m_IsBanShortCutWin);
			XUtils.RegisterFunc(L, XUtils.METHOD_IDX, "IsBanBossNoticeWin", _m_IsBanBossNoticeWin);
			XUtils.RegisterFunc(L, XUtils.METHOD_IDX, "IsBanMarriageNoticeWin", _m_IsBanMarriageNoticeWin);
			XUtils.RegisterFunc(L, XUtils.METHOD_IDX, "ForbidJumpOutAnimationOut", _m_ForbidJumpOutAnimationOut);
			XUtils.RegisterFunc(L, XUtils.METHOD_IDX, "ForbidJumpOutAnimationIn", _m_ForbidJumpOutAnimationIn);
			XUtils.RegisterFunc(L, XUtils.METHOD_IDX, "PlayJumpOutAnimationTeamIn", _m_PlayJumpOutAnimationTeamIn);
			XUtils.RegisterFunc(L, XUtils.METHOD_IDX, "HideCount", _m_HideCount);
			XUtils.RegisterFunc(L, XUtils.METHOD_IDX, "ForbidElfin", _m_ForbidElfin);
			XUtils.RegisterFunc(L, XUtils.METHOD_IDX, "ForbidMagicPet", _m_ForbidMagicPet);
			XUtils.RegisterFunc(L, XUtils.METHOD_IDX, "GetReplaceOtherPlayerName", _m_GetReplaceOtherPlayerName);
			XUtils.RegisterFunc(L, XUtils.METHOD_IDX, "HideGuild", _m_HideGuild);
			XUtils.RegisterFunc(L, XUtils.METHOD_IDX, "HideMate", _m_HideMate);
			XUtils.RegisterFunc(L, XUtils.METHOD_IDX, "NoFlyShoe", _m_NoFlyShoe);
			XUtils.RegisterFunc(L, XUtils.METHOD_IDX, "AutoCollect", _m_AutoCollect);
			XUtils.RegisterFunc(L, XUtils.METHOD_IDX, "DoNotPatrol", _m_DoNotPatrol);
			XUtils.RegisterFunc(L, XUtils.METHOD_IDX, "ShowServerName", _m_ShowServerName);
			XUtils.RegisterFunc(L, XUtils.METHOD_IDX, "ClearCd", _m_ClearCd);
			XUtils.RegisterFunc(L, XUtils.METHOD_IDX, "MinPlayerCount", _m_MinPlayerCount);
			
			
			
			
			XUtils.EndObjectRegister(typeof(xc.DBInstanceTypeControl), L, translator, null, null,
			    null, null, null);

		    XUtils.BeginClassRegister(typeof(xc.DBInstanceTypeControl), L, __CreateInstance, 1, 1, 0);
			
			
            
            XUtils.RegisterObject(L, translator, XUtils.CLS_IDX, "UnderlyingSystemType", typeof(xc.DBInstanceTypeControl));
			XUtils.RegisterFunc(L, XUtils.CLS_GETTER_IDX, "Instance", _g_get_Instance);
            
			
			XUtils.EndClassRegister(typeof(xc.DBInstanceTypeControl), L, translator);
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int __CreateInstance(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			try {
				if(LuaAPI.lua_gettop(L) == 3 && (LuaAPI.lua_isnil(L, 2) || LuaAPI.lua_type(L, 2) == LuaTypes.LUA_TSTRING) && (LuaAPI.lua_isnil(L, 3) || LuaAPI.lua_type(L, 3) == LuaTypes.LUA_TSTRING))
				{
					string name = LuaAPI.lua_tostring(L, 2);
					string path = LuaAPI.lua_tostring(L, 3);
					
					xc.DBInstanceTypeControl __cl_gen_ret = new xc.DBInstanceTypeControl(name, path);
					translator.Push(L, __cl_gen_ret);
					return 1;
				}
				
			}
			catch(System.Exception __gen_e) {
				return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
			}
            return LuaAPI.luaL_error(L, "invalid arguments to xc.DBInstanceTypeControl constructor!");
            
        }
        
		
        
		
        
        
        
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_Load(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            xc.DBInstanceTypeControl __cl_gen_to_be_invoked = (xc.DBInstanceTypeControl)translator.FastGetCSObj(L, 1);
            
            
            try {
                
                {
                    
                    __cl_gen_to_be_invoked.Load(  );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_PrecedentPlayer(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            xc.DBInstanceTypeControl __cl_gen_to_be_invoked = (xc.DBInstanceTypeControl)translator.FastGetCSObj(L, 1);
            
            
            try {
                
                {
                    uint war_type = LuaAPI.xlua_touint(L, 2);
                    uint war_sub_type = LuaAPI.xlua_touint(L, 3);
                    
                        bool __cl_gen_ret = __cl_gen_to_be_invoked.PrecedentPlayer( war_type, war_sub_type );
                        LuaAPI.lua_pushboolean(L, __cl_gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_CannotHidePlayer(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            xc.DBInstanceTypeControl __cl_gen_to_be_invoked = (xc.DBInstanceTypeControl)translator.FastGetCSObj(L, 1);
            
            
            try {
                
                {
                    uint war_type = LuaAPI.xlua_touint(L, 2);
                    uint war_sub_type = LuaAPI.xlua_touint(L, 3);
                    
                        bool __cl_gen_ret = __cl_gen_to_be_invoked.CannotHidePlayer( war_type, war_sub_type );
                        LuaAPI.lua_pushboolean(L, __cl_gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_PKLevelLimit(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            xc.DBInstanceTypeControl __cl_gen_to_be_invoked = (xc.DBInstanceTypeControl)translator.FastGetCSObj(L, 1);
            
            
            try {
                
                {
                    uint war_type = LuaAPI.xlua_touint(L, 2);
                    uint war_sub_type = LuaAPI.xlua_touint(L, 3);
                    
                        bool __cl_gen_ret = __cl_gen_to_be_invoked.PKLevelLimit( war_type, war_sub_type );
                        LuaAPI.lua_pushboolean(L, __cl_gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_UsePKMode(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            xc.DBInstanceTypeControl __cl_gen_to_be_invoked = (xc.DBInstanceTypeControl)translator.FastGetCSObj(L, 1);
            
            
            try {
                
                {
                    uint war_type = LuaAPI.xlua_touint(L, 2);
                    uint war_sub_type = LuaAPI.xlua_touint(L, 3);
                    
                        bool __cl_gen_ret = __cl_gen_to_be_invoked.UsePKMode( war_type, war_sub_type );
                        LuaAPI.lua_pushboolean(L, __cl_gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_NoShowAtkCampTips(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            xc.DBInstanceTypeControl __cl_gen_to_be_invoked = (xc.DBInstanceTypeControl)translator.FastGetCSObj(L, 1);
            
            
            try {
                
                {
                    uint war_type = LuaAPI.xlua_touint(L, 2);
                    uint war_sub_type = LuaAPI.xlua_touint(L, 3);
                    
                        bool __cl_gen_ret = __cl_gen_to_be_invoked.NoShowAtkCampTips( war_type, war_sub_type );
                        LuaAPI.lua_pushboolean(L, __cl_gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_IgnoreClickPlayer(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            xc.DBInstanceTypeControl __cl_gen_to_be_invoked = (xc.DBInstanceTypeControl)translator.FastGetCSObj(L, 1);
            
            
            try {
                
                {
                    uint war_type = LuaAPI.xlua_touint(L, 2);
                    uint war_sub_type = LuaAPI.xlua_touint(L, 3);
                    
                        bool __cl_gen_ret = __cl_gen_to_be_invoked.IgnoreClickPlayer( war_type, war_sub_type );
                        LuaAPI.lua_pushboolean(L, __cl_gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_ForceShowHpBar(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            xc.DBInstanceTypeControl __cl_gen_to_be_invoked = (xc.DBInstanceTypeControl)translator.FastGetCSObj(L, 1);
            
            
            try {
                
                {
                    uint war_type = LuaAPI.xlua_touint(L, 2);
                    uint war_sub_type = LuaAPI.xlua_touint(L, 3);
                    
                        bool __cl_gen_ret = __cl_gen_to_be_invoked.ForceShowHpBar( war_type, war_sub_type );
                        LuaAPI.lua_pushboolean(L, __cl_gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_ForbidUseGoods(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            xc.DBInstanceTypeControl __cl_gen_to_be_invoked = (xc.DBInstanceTypeControl)translator.FastGetCSObj(L, 1);
            
            
            try {
                
                {
                    uint war_type = LuaAPI.xlua_touint(L, 2);
                    uint war_sub_type = LuaAPI.xlua_touint(L, 3);
                    uint goods_type = LuaAPI.xlua_touint(L, 4);
                    uint goods_sub_type = LuaAPI.xlua_touint(L, 5);
                    
                        bool __cl_gen_ret = __cl_gen_to_be_invoked.ForbidUseGoods( war_type, war_sub_type, goods_type, goods_sub_type );
                        LuaAPI.lua_pushboolean(L, __cl_gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_ForbiChangePkMode(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            xc.DBInstanceTypeControl __cl_gen_to_be_invoked = (xc.DBInstanceTypeControl)translator.FastGetCSObj(L, 1);
            
            
            try {
                
                {
                    uint war_type = LuaAPI.xlua_touint(L, 2);
                    uint war_sub_type = LuaAPI.xlua_touint(L, 3);
                    
                        bool __cl_gen_ret = __cl_gen_to_be_invoked.ForbiChangePkMode( war_type, war_sub_type );
                        LuaAPI.lua_pushboolean(L, __cl_gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_ShowDanmakuSwitch(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            xc.DBInstanceTypeControl __cl_gen_to_be_invoked = (xc.DBInstanceTypeControl)translator.FastGetCSObj(L, 1);
            
            
            try {
                
                {
                    uint war_type = LuaAPI.xlua_touint(L, 2);
                    uint war_sub_type = LuaAPI.xlua_touint(L, 3);
                    
                        bool __cl_gen_ret = __cl_gen_to_be_invoked.ShowDanmakuSwitch( war_type, war_sub_type );
                        LuaAPI.lua_pushboolean(L, __cl_gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_ShowDanmaku(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            xc.DBInstanceTypeControl __cl_gen_to_be_invoked = (xc.DBInstanceTypeControl)translator.FastGetCSObj(L, 1);
            
            
            try {
                
                {
                    uint war_type = LuaAPI.xlua_touint(L, 2);
                    uint war_sub_type = LuaAPI.xlua_touint(L, 3);
                    uint chat_channel = LuaAPI.xlua_touint(L, 4);
                    
                        bool __cl_gen_ret = __cl_gen_to_be_invoked.ShowDanmaku( war_type, war_sub_type, chat_channel );
                        LuaAPI.lua_pushboolean(L, __cl_gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_ForbidOpenWorldMap(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            xc.DBInstanceTypeControl __cl_gen_to_be_invoked = (xc.DBInstanceTypeControl)translator.FastGetCSObj(L, 1);
            
            
            try {
                
                {
                    uint war_type = LuaAPI.xlua_touint(L, 2);
                    uint war_sub_type = LuaAPI.xlua_touint(L, 3);
                    
                        bool __cl_gen_ret = __cl_gen_to_be_invoked.ForbidOpenWorldMap( war_type, war_sub_type );
                        LuaAPI.lua_pushboolean(L, __cl_gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_HideHpBar(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            xc.DBInstanceTypeControl __cl_gen_to_be_invoked = (xc.DBInstanceTypeControl)translator.FastGetCSObj(L, 1);
            
            
            try {
                
                {
                    uint war_type = LuaAPI.xlua_touint(L, 2);
                    uint war_sub_type = LuaAPI.xlua_touint(L, 3);
                    
                        bool __cl_gen_ret = __cl_gen_to_be_invoked.HideHpBar( war_type, war_sub_type );
                        LuaAPI.lua_pushboolean(L, __cl_gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_HideCamp(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            xc.DBInstanceTypeControl __cl_gen_to_be_invoked = (xc.DBInstanceTypeControl)translator.FastGetCSObj(L, 1);
            
            
            try {
                
                {
                    uint war_type = LuaAPI.xlua_touint(L, 2);
                    uint war_sub_type = LuaAPI.xlua_touint(L, 3);
                    
                        bool __cl_gen_ret = __cl_gen_to_be_invoked.HideCamp( war_type, war_sub_type );
                        LuaAPI.lua_pushboolean(L, __cl_gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_ForbidPet(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            xc.DBInstanceTypeControl __cl_gen_to_be_invoked = (xc.DBInstanceTypeControl)translator.FastGetCSObj(L, 1);
            
            
            try {
                
                {
                    uint war_type = LuaAPI.xlua_touint(L, 2);
                    uint war_sub_type = LuaAPI.xlua_touint(L, 3);
                    
                        bool __cl_gen_ret = __cl_gen_to_be_invoked.ForbidPet( war_type, war_sub_type );
                        LuaAPI.lua_pushboolean(L, __cl_gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_HideTeam(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            xc.DBInstanceTypeControl __cl_gen_to_be_invoked = (xc.DBInstanceTypeControl)translator.FastGetCSObj(L, 1);
            
            
            try {
                
                {
                    uint war_type = LuaAPI.xlua_touint(L, 2);
                    uint war_sub_type = LuaAPI.xlua_touint(L, 3);
                    
                        bool __cl_gen_ret = __cl_gen_to_be_invoked.HideTeam( war_type, war_sub_type );
                        LuaAPI.lua_pushboolean(L, __cl_gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_ForbidTeam(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            xc.DBInstanceTypeControl __cl_gen_to_be_invoked = (xc.DBInstanceTypeControl)translator.FastGetCSObj(L, 1);
            
            
            try {
                
                {
                    uint war_type = LuaAPI.xlua_touint(L, 2);
                    uint war_sub_type = LuaAPI.xlua_touint(L, 3);
                    
                        bool __cl_gen_ret = __cl_gen_to_be_invoked.ForbidTeam( war_type, war_sub_type );
                        LuaAPI.lua_pushboolean(L, __cl_gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_HidePvpHpBar(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            xc.DBInstanceTypeControl __cl_gen_to_be_invoked = (xc.DBInstanceTypeControl)translator.FastGetCSObj(L, 1);
            
            
            try {
                
                {
                    uint war_type = LuaAPI.xlua_touint(L, 2);
                    uint war_sub_type = LuaAPI.xlua_touint(L, 3);
                    
                        bool __cl_gen_ret = __cl_gen_to_be_invoked.HidePvpHpBar( war_type, war_sub_type );
                        LuaAPI.lua_pushboolean(L, __cl_gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_AutoPickDrop(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            xc.DBInstanceTypeControl __cl_gen_to_be_invoked = (xc.DBInstanceTypeControl)translator.FastGetCSObj(L, 1);
            
            
            try {
                
                {
                    uint war_type = LuaAPI.xlua_touint(L, 2);
                    uint war_sub_type = LuaAPI.xlua_touint(L, 3);
                    
                        bool __cl_gen_ret = __cl_gen_to_be_invoked.AutoPickDrop( war_type, war_sub_type );
                        LuaAPI.lua_pushboolean(L, __cl_gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_IsShowAutoFightingGotExp(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            xc.DBInstanceTypeControl __cl_gen_to_be_invoked = (xc.DBInstanceTypeControl)translator.FastGetCSObj(L, 1);
            
            
            try {
                
                {
                    uint war_type = LuaAPI.xlua_touint(L, 2);
                    uint war_sub_type = LuaAPI.xlua_touint(L, 3);
                    
                        bool __cl_gen_ret = __cl_gen_to_be_invoked.IsShowAutoFightingGotExp( war_type, war_sub_type );
                        LuaAPI.lua_pushboolean(L, __cl_gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_GetActivityId(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            xc.DBInstanceTypeControl __cl_gen_to_be_invoked = (xc.DBInstanceTypeControl)translator.FastGetCSObj(L, 1);
            
            
            try {
                
                {
                    uint war_type = LuaAPI.xlua_touint(L, 2);
                    uint war_sub_type = LuaAPI.xlua_touint(L, 3);
                    
                        uint __cl_gen_ret = __cl_gen_to_be_invoked.GetActivityId( war_type, war_sub_type );
                        LuaAPI.xlua_pushuint(L, __cl_gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_GetExitTips(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            xc.DBInstanceTypeControl __cl_gen_to_be_invoked = (xc.DBInstanceTypeControl)translator.FastGetCSObj(L, 1);
            
            
            try {
                
                {
                    uint war_type = LuaAPI.xlua_touint(L, 2);
                    uint war_sub_type = LuaAPI.xlua_touint(L, 3);
                    
                        string __cl_gen_ret = __cl_gen_to_be_invoked.GetExitTips( war_type, war_sub_type );
                        LuaAPI.lua_pushstring(L, __cl_gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_GetCanExit(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            xc.DBInstanceTypeControl __cl_gen_to_be_invoked = (xc.DBInstanceTypeControl)translator.FastGetCSObj(L, 1);
            
            
            try {
                
                {
                    uint war_type = LuaAPI.xlua_touint(L, 2);
                    uint war_sub_type = LuaAPI.xlua_touint(L, 3);
                    
                        bool __cl_gen_ret = __cl_gen_to_be_invoked.GetCanExit( war_type, war_sub_type );
                        LuaAPI.lua_pushboolean(L, __cl_gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_IsBanShortCutWin(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            xc.DBInstanceTypeControl __cl_gen_to_be_invoked = (xc.DBInstanceTypeControl)translator.FastGetCSObj(L, 1);
            
            
            try {
                
                {
                    uint war_type = LuaAPI.xlua_touint(L, 2);
                    uint war_sub_type = LuaAPI.xlua_touint(L, 3);
                    
                        bool __cl_gen_ret = __cl_gen_to_be_invoked.IsBanShortCutWin( war_type, war_sub_type );
                        LuaAPI.lua_pushboolean(L, __cl_gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_IsBanBossNoticeWin(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            xc.DBInstanceTypeControl __cl_gen_to_be_invoked = (xc.DBInstanceTypeControl)translator.FastGetCSObj(L, 1);
            
            
            try {
                
                {
                    uint war_type = LuaAPI.xlua_touint(L, 2);
                    uint war_sub_type = LuaAPI.xlua_touint(L, 3);
                    
                        bool __cl_gen_ret = __cl_gen_to_be_invoked.IsBanBossNoticeWin( war_type, war_sub_type );
                        LuaAPI.lua_pushboolean(L, __cl_gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_IsBanMarriageNoticeWin(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            xc.DBInstanceTypeControl __cl_gen_to_be_invoked = (xc.DBInstanceTypeControl)translator.FastGetCSObj(L, 1);
            
            
            try {
                
                {
                    uint war_type = LuaAPI.xlua_touint(L, 2);
                    uint war_sub_type = LuaAPI.xlua_touint(L, 3);
                    
                        bool __cl_gen_ret = __cl_gen_to_be_invoked.IsBanMarriageNoticeWin( war_type, war_sub_type );
                        LuaAPI.lua_pushboolean(L, __cl_gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_ForbidJumpOutAnimationOut(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            xc.DBInstanceTypeControl __cl_gen_to_be_invoked = (xc.DBInstanceTypeControl)translator.FastGetCSObj(L, 1);
            
            
            try {
                
                {
                    uint war_type = LuaAPI.xlua_touint(L, 2);
                    uint war_sub_type = LuaAPI.xlua_touint(L, 3);
                    
                        bool __cl_gen_ret = __cl_gen_to_be_invoked.ForbidJumpOutAnimationOut( war_type, war_sub_type );
                        LuaAPI.lua_pushboolean(L, __cl_gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_ForbidJumpOutAnimationIn(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            xc.DBInstanceTypeControl __cl_gen_to_be_invoked = (xc.DBInstanceTypeControl)translator.FastGetCSObj(L, 1);
            
            
            try {
                
                {
                    uint war_type = LuaAPI.xlua_touint(L, 2);
                    uint war_sub_type = LuaAPI.xlua_touint(L, 3);
                    
                        bool __cl_gen_ret = __cl_gen_to_be_invoked.ForbidJumpOutAnimationIn( war_type, war_sub_type );
                        LuaAPI.lua_pushboolean(L, __cl_gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_PlayJumpOutAnimationTeamIn(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            xc.DBInstanceTypeControl __cl_gen_to_be_invoked = (xc.DBInstanceTypeControl)translator.FastGetCSObj(L, 1);
            
            
            try {
                
                {
                    uint war_type = LuaAPI.xlua_touint(L, 2);
                    uint war_sub_type = LuaAPI.xlua_touint(L, 3);
                    
                        bool __cl_gen_ret = __cl_gen_to_be_invoked.PlayJumpOutAnimationTeamIn( war_type, war_sub_type );
                        LuaAPI.lua_pushboolean(L, __cl_gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_HideCount(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            xc.DBInstanceTypeControl __cl_gen_to_be_invoked = (xc.DBInstanceTypeControl)translator.FastGetCSObj(L, 1);
            
            
            try {
                
                {
                    uint war_type = LuaAPI.xlua_touint(L, 2);
                    uint war_sub_type = LuaAPI.xlua_touint(L, 3);
                    
                        bool __cl_gen_ret = __cl_gen_to_be_invoked.HideCount( war_type, war_sub_type );
                        LuaAPI.lua_pushboolean(L, __cl_gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_ForbidElfin(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            xc.DBInstanceTypeControl __cl_gen_to_be_invoked = (xc.DBInstanceTypeControl)translator.FastGetCSObj(L, 1);
            
            
            try {
                
                {
                    uint war_type = LuaAPI.xlua_touint(L, 2);
                    uint war_sub_type = LuaAPI.xlua_touint(L, 3);
                    
                        bool __cl_gen_ret = __cl_gen_to_be_invoked.ForbidElfin( war_type, war_sub_type );
                        LuaAPI.lua_pushboolean(L, __cl_gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_ForbidMagicPet(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            xc.DBInstanceTypeControl __cl_gen_to_be_invoked = (xc.DBInstanceTypeControl)translator.FastGetCSObj(L, 1);
            
            
            try {
                
                {
                    uint war_type = LuaAPI.xlua_touint(L, 2);
                    uint war_sub_type = LuaAPI.xlua_touint(L, 3);
                    
                        bool __cl_gen_ret = __cl_gen_to_be_invoked.ForbidMagicPet( war_type, war_sub_type );
                        LuaAPI.lua_pushboolean(L, __cl_gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_GetReplaceOtherPlayerName(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            xc.DBInstanceTypeControl __cl_gen_to_be_invoked = (xc.DBInstanceTypeControl)translator.FastGetCSObj(L, 1);
            
            
            try {
                
                {
                    uint war_type = LuaAPI.xlua_touint(L, 2);
                    uint war_sub_type = LuaAPI.xlua_touint(L, 3);
                    
                        string __cl_gen_ret = __cl_gen_to_be_invoked.GetReplaceOtherPlayerName( war_type, war_sub_type );
                        LuaAPI.lua_pushstring(L, __cl_gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_HideGuild(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            xc.DBInstanceTypeControl __cl_gen_to_be_invoked = (xc.DBInstanceTypeControl)translator.FastGetCSObj(L, 1);
            
            
            try {
                
                {
                    uint war_type = LuaAPI.xlua_touint(L, 2);
                    uint war_sub_type = LuaAPI.xlua_touint(L, 3);
                    
                        bool __cl_gen_ret = __cl_gen_to_be_invoked.HideGuild( war_type, war_sub_type );
                        LuaAPI.lua_pushboolean(L, __cl_gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_HideMate(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            xc.DBInstanceTypeControl __cl_gen_to_be_invoked = (xc.DBInstanceTypeControl)translator.FastGetCSObj(L, 1);
            
            
            try {
                
                {
                    uint war_type = LuaAPI.xlua_touint(L, 2);
                    uint war_sub_type = LuaAPI.xlua_touint(L, 3);
                    
                        bool __cl_gen_ret = __cl_gen_to_be_invoked.HideMate( war_type, war_sub_type );
                        LuaAPI.lua_pushboolean(L, __cl_gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_NoFlyShoe(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            xc.DBInstanceTypeControl __cl_gen_to_be_invoked = (xc.DBInstanceTypeControl)translator.FastGetCSObj(L, 1);
            
            
            try {
                
                {
                    uint war_type = LuaAPI.xlua_touint(L, 2);
                    uint war_sub_type = LuaAPI.xlua_touint(L, 3);
                    
                        bool __cl_gen_ret = __cl_gen_to_be_invoked.NoFlyShoe( war_type, war_sub_type );
                        LuaAPI.lua_pushboolean(L, __cl_gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_AutoCollect(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            xc.DBInstanceTypeControl __cl_gen_to_be_invoked = (xc.DBInstanceTypeControl)translator.FastGetCSObj(L, 1);
            
            
            try {
                
                {
                    uint war_type = LuaAPI.xlua_touint(L, 2);
                    uint war_sub_type = LuaAPI.xlua_touint(L, 3);
                    
                        bool __cl_gen_ret = __cl_gen_to_be_invoked.AutoCollect( war_type, war_sub_type );
                        LuaAPI.lua_pushboolean(L, __cl_gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_DoNotPatrol(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            xc.DBInstanceTypeControl __cl_gen_to_be_invoked = (xc.DBInstanceTypeControl)translator.FastGetCSObj(L, 1);
            
            
            try {
                
                {
                    uint war_type = LuaAPI.xlua_touint(L, 2);
                    uint war_sub_type = LuaAPI.xlua_touint(L, 3);
                    
                        bool __cl_gen_ret = __cl_gen_to_be_invoked.DoNotPatrol( war_type, war_sub_type );
                        LuaAPI.lua_pushboolean(L, __cl_gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_ShowServerName(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            xc.DBInstanceTypeControl __cl_gen_to_be_invoked = (xc.DBInstanceTypeControl)translator.FastGetCSObj(L, 1);
            
            
            try {
                
                {
                    uint war_type = LuaAPI.xlua_touint(L, 2);
                    uint war_sub_type = LuaAPI.xlua_touint(L, 3);
                    
                        bool __cl_gen_ret = __cl_gen_to_be_invoked.ShowServerName( war_type, war_sub_type );
                        LuaAPI.lua_pushboolean(L, __cl_gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_ClearCd(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            xc.DBInstanceTypeControl __cl_gen_to_be_invoked = (xc.DBInstanceTypeControl)translator.FastGetCSObj(L, 1);
            
            
            try {
                
                {
                    uint war_type = LuaAPI.xlua_touint(L, 2);
                    uint war_sub_type = LuaAPI.xlua_touint(L, 3);
                    
                        bool __cl_gen_ret = __cl_gen_to_be_invoked.ClearCd( war_type, war_sub_type );
                        LuaAPI.lua_pushboolean(L, __cl_gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_MinPlayerCount(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            xc.DBInstanceTypeControl __cl_gen_to_be_invoked = (xc.DBInstanceTypeControl)translator.FastGetCSObj(L, 1);
            
            
            try {
                
                {
                    uint war_type = LuaAPI.xlua_touint(L, 2);
                    uint war_sub_type = LuaAPI.xlua_touint(L, 3);
                    
                        uint __cl_gen_ret = __cl_gen_to_be_invoked.MinPlayerCount( war_type, war_sub_type );
                        LuaAPI.xlua_pushuint(L, __cl_gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        
        
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_Instance(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			    translator.Push(L, xc.DBInstanceTypeControl.Instance);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        
        
		
		
		
		
    }
}
