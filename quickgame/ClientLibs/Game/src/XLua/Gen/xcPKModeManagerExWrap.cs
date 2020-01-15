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
    public class xcPKModeManagerExWrap
    {
        public static void __Register(RealStatePtr L)
        {
			ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			XUtils.BeginObjectRegister(typeof(xc.PKModeManagerEx), L, translator, 0, 21, 12, 11);
			
			XUtils.RegisterFunc(L, XUtils.METHOD_IDX, "UpdatePVPBattleState", _m_UpdatePVPBattleState);
			XUtils.RegisterFunc(L, XUtils.METHOD_IDX, "UpdateAttack", _m_UpdateAttack);
			XUtils.RegisterFunc(L, XUtils.METHOD_IDX, "IsInAttackArea", _m_IsInAttackArea);
			XUtils.RegisterFunc(L, XUtils.METHOD_IDX, "AddOneEnemy", _m_AddOneEnemy);
			XUtils.RegisterFunc(L, XUtils.METHOD_IDX, "DelOneEmey", _m_DelOneEmey);
			XUtils.RegisterFunc(L, XUtils.METHOD_IDX, "UpdateEnemyList", _m_UpdateEnemyList);
			XUtils.RegisterFunc(L, XUtils.METHOD_IDX, "IsInPVPState", _m_IsInPVPState);
			XUtils.RegisterFunc(L, XUtils.METHOD_IDX, "TryToOtherDungeonScene", _m_TryToOtherDungeonScene);
			XUtils.RegisterFunc(L, XUtils.METHOD_IDX, "CanShowPVPBlood", _m_CanShowPVPBlood);
			XUtils.RegisterFunc(L, XUtils.METHOD_IDX, "UpdatePkMode", _m_UpdatePkMode);
			XUtils.RegisterFunc(L, XUtils.METHOD_IDX, "UpdatePKIcons", _m_UpdatePKIcons);
			XUtils.RegisterFunc(L, XUtils.METHOD_IDX, "Reset", _m_Reset);
			XUtils.RegisterFunc(L, XUtils.METHOD_IDX, "IsInPKScene", _m_IsInPKScene);
			XUtils.RegisterFunc(L, XUtils.METHOD_IDX, "IsMonster", _m_IsMonster);
			XUtils.RegisterFunc(L, XUtils.METHOD_IDX, "IsEqualActor", _m_IsEqualActor);
			XUtils.RegisterFunc(L, XUtils.METHOD_IDX, "IsEnemyRelation", _m_IsEnemyRelation);
			XUtils.RegisterFunc(L, XUtils.METHOD_IDX, "IsFriendRelation", _m_IsFriendRelation);
			XUtils.RegisterFunc(L, XUtils.METHOD_IDX, "IsLocalPlayerCanAttackActor", _m_IsLocalPlayerCanAttackActor);
			XUtils.RegisterFunc(L, XUtils.METHOD_IDX, "IsActorCanAttackLocalPlayer", _m_IsActorCanAttackLocalPlayer);
			XUtils.RegisterFunc(L, XUtils.METHOD_IDX, "TryShowHostileAttackTips", _m_TryShowHostileAttackTips);
			XUtils.RegisterFunc(L, XUtils.METHOD_IDX, "IsScenePKSafe", _m_IsScenePKSafe);
			
			
			XUtils.RegisterFunc(L, XUtils.GETTER_IDX, "IsPVPBattleState", _g_get_IsPVPBattleState);
            XUtils.RegisterFunc(L, XUtils.GETTER_IDX, "IsInSafeArea", _g_get_IsInSafeArea);
            XUtils.RegisterFunc(L, XUtils.GETTER_IDX, "IsInPKArea", _g_get_IsInPKArea);
            XUtils.RegisterFunc(L, XUtils.GETTER_IDX, "PKValue", _g_get_PKValue);
            XUtils.RegisterFunc(L, XUtils.GETTER_IDX, "PKMode", _g_get_PKMode);
            XUtils.RegisterFunc(L, XUtils.GETTER_IDX, "ShowPVPBlood", _g_get_ShowPVPBlood);
            XUtils.RegisterFunc(L, XUtils.GETTER_IDX, "IsPKProtectionTeamMate", _g_get_IsPKProtectionTeamMate);
            XUtils.RegisterFunc(L, XUtils.GETTER_IDX, "IsPKProtectionSociety", _g_get_IsPKProtectionSociety);
            XUtils.RegisterFunc(L, XUtils.GETTER_IDX, "IsPKProtectionGreenName", _g_get_IsPKProtectionGreenName);
            XUtils.RegisterFunc(L, XUtils.GETTER_IDX, "PKProtectionLv", _g_get_PKProtectionLv);
            XUtils.RegisterFunc(L, XUtils.GETTER_IDX, "LocalPlayerNameColor", _g_get_LocalPlayerNameColor);
            XUtils.RegisterFunc(L, XUtils.GETTER_IDX, "mGamePKLvProtect", _g_get_mGamePKLvProtect);
            
			XUtils.RegisterFunc(L, XUtils.SETTER_IDX, "IsPVPBattleState", _s_set_IsPVPBattleState);
            XUtils.RegisterFunc(L, XUtils.SETTER_IDX, "IsInSafeArea", _s_set_IsInSafeArea);
            XUtils.RegisterFunc(L, XUtils.SETTER_IDX, "IsInPKArea", _s_set_IsInPKArea);
            XUtils.RegisterFunc(L, XUtils.SETTER_IDX, "PKValue", _s_set_PKValue);
            XUtils.RegisterFunc(L, XUtils.SETTER_IDX, "ShowPVPBlood", _s_set_ShowPVPBlood);
            XUtils.RegisterFunc(L, XUtils.SETTER_IDX, "IsPKProtectionTeamMate", _s_set_IsPKProtectionTeamMate);
            XUtils.RegisterFunc(L, XUtils.SETTER_IDX, "IsPKProtectionSociety", _s_set_IsPKProtectionSociety);
            XUtils.RegisterFunc(L, XUtils.SETTER_IDX, "IsPKProtectionGreenName", _s_set_IsPKProtectionGreenName);
            XUtils.RegisterFunc(L, XUtils.SETTER_IDX, "PKProtectionLv", _s_set_PKProtectionLv);
            XUtils.RegisterFunc(L, XUtils.SETTER_IDX, "LocalPlayerNameColor", _s_set_LocalPlayerNameColor);
            XUtils.RegisterFunc(L, XUtils.SETTER_IDX, "mGamePKLvProtect", _s_set_mGamePKLvProtect);
            
			XUtils.EndObjectRegister(typeof(xc.PKModeManagerEx), L, translator, null, null,
			    null, null, null);

		    XUtils.BeginClassRegister(typeof(xc.PKModeManagerEx), L, __CreateInstance, 1, 0, 0);
			
			
            
            XUtils.RegisterObject(L, translator, XUtils.CLS_IDX, "UnderlyingSystemType", typeof(xc.PKModeManagerEx));
			
			
			XUtils.EndClassRegister(typeof(xc.PKModeManagerEx), L, translator);
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int __CreateInstance(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			try {
				if(LuaAPI.lua_gettop(L) == 1)
				{
					
					xc.PKModeManagerEx __cl_gen_ret = new xc.PKModeManagerEx();
					translator.Push(L, __cl_gen_ret);
					return 1;
				}
				
			}
			catch(System.Exception __gen_e) {
				return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
			}
            return LuaAPI.luaL_error(L, "invalid arguments to xc.PKModeManagerEx constructor!");
            
        }
        
		
        
		
        
        
        
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_UpdatePVPBattleState(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            xc.PKModeManagerEx __cl_gen_to_be_invoked = (xc.PKModeManagerEx)translator.FastGetCSObj(L, 1);
            
            
            try {
                
                {
                    
                    __cl_gen_to_be_invoked.UpdatePVPBattleState(  );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_UpdateAttack(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            xc.PKModeManagerEx __cl_gen_to_be_invoked = (xc.PKModeManagerEx)translator.FastGetCSObj(L, 1);
            
            
            try {
                
                {
                    
                    __cl_gen_to_be_invoked.UpdateAttack(  );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_IsInAttackArea(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            xc.PKModeManagerEx __cl_gen_to_be_invoked = (xc.PKModeManagerEx)translator.FastGetCSObj(L, 1);
            
            
            try {
                
                {
                    
                        bool __cl_gen_ret = __cl_gen_to_be_invoked.IsInAttackArea(  );
                        LuaAPI.lua_pushboolean(L, __cl_gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_AddOneEnemy(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            xc.PKModeManagerEx __cl_gen_to_be_invoked = (xc.PKModeManagerEx)translator.FastGetCSObj(L, 1);
            
            
            try {
                
                {
                    xc.UnitID uid = (xc.UnitID)translator.GetObject(L, 2, typeof(xc.UnitID));
                    
                    __cl_gen_to_be_invoked.AddOneEnemy( uid );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_DelOneEmey(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            xc.PKModeManagerEx __cl_gen_to_be_invoked = (xc.PKModeManagerEx)translator.FastGetCSObj(L, 1);
            
            
            try {
                
                {
                    xc.UnitID uid = (xc.UnitID)translator.GetObject(L, 2, typeof(xc.UnitID));
                    
                    __cl_gen_to_be_invoked.DelOneEmey( uid );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_UpdateEnemyList(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            xc.PKModeManagerEx __cl_gen_to_be_invoked = (xc.PKModeManagerEx)translator.FastGetCSObj(L, 1);
            
            
            try {
                
                {
                    
                    __cl_gen_to_be_invoked.UpdateEnemyList(  );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_IsInPVPState(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            xc.PKModeManagerEx __cl_gen_to_be_invoked = (xc.PKModeManagerEx)translator.FastGetCSObj(L, 1);
            
            
            try {
                
                {
                    
                        bool __cl_gen_ret = __cl_gen_to_be_invoked.IsInPVPState(  );
                        LuaAPI.lua_pushboolean(L, __cl_gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_TryToOtherDungeonScene(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            xc.PKModeManagerEx __cl_gen_to_be_invoked = (xc.PKModeManagerEx)translator.FastGetCSObj(L, 1);
            
            
            try {
                
                {
                    
                        bool __cl_gen_ret = __cl_gen_to_be_invoked.TryToOtherDungeonScene(  );
                        LuaAPI.lua_pushboolean(L, __cl_gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_CanShowPVPBlood(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            xc.PKModeManagerEx __cl_gen_to_be_invoked = (xc.PKModeManagerEx)translator.FastGetCSObj(L, 1);
            
            
            try {
                
                {
                    Actor actor = (Actor)translator.GetObject(L, 2, typeof(Actor));
                    
                        bool __cl_gen_ret = __cl_gen_to_be_invoked.CanShowPVPBlood( actor );
                        LuaAPI.lua_pushboolean(L, __cl_gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_UpdatePkMode(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            xc.PKModeManagerEx __cl_gen_to_be_invoked = (xc.PKModeManagerEx)translator.FastGetCSObj(L, 1);
            
            
            try {
                
                {
                    uint pkMode = LuaAPI.xlua_touint(L, 2);
                    
                    __cl_gen_to_be_invoked.UpdatePkMode( pkMode );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_UpdatePKIcons(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            xc.PKModeManagerEx __cl_gen_to_be_invoked = (xc.PKModeManagerEx)translator.FastGetCSObj(L, 1);
            
            
            try {
                
                {
                    
                    __cl_gen_to_be_invoked.UpdatePKIcons(  );
                    
                    
                    
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
            
            
            xc.PKModeManagerEx __cl_gen_to_be_invoked = (xc.PKModeManagerEx)translator.FastGetCSObj(L, 1);
            
            
            try {
                
                {
                    
                    __cl_gen_to_be_invoked.Reset(  );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_IsInPKScene(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            xc.PKModeManagerEx __cl_gen_to_be_invoked = (xc.PKModeManagerEx)translator.FastGetCSObj(L, 1);
            
            
            try {
                
                {
                    
                        bool __cl_gen_ret = __cl_gen_to_be_invoked.IsInPKScene(  );
                        LuaAPI.lua_pushboolean(L, __cl_gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_IsMonster(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            xc.PKModeManagerEx __cl_gen_to_be_invoked = (xc.PKModeManagerEx)translator.FastGetCSObj(L, 1);
            
            
            try {
                
                {
                    uint uuid = LuaAPI.xlua_touint(L, 2);
                    
                        bool __cl_gen_ret = __cl_gen_to_be_invoked.IsMonster( uuid );
                        LuaAPI.lua_pushboolean(L, __cl_gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_IsEqualActor(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            xc.PKModeManagerEx __cl_gen_to_be_invoked = (xc.PKModeManagerEx)translator.FastGetCSObj(L, 1);
            
            
            try {
                
                {
                    Actor attacker = (Actor)translator.GetObject(L, 2, typeof(Actor));
                    Actor defender = (Actor)translator.GetObject(L, 3, typeof(Actor));
                    
                        bool __cl_gen_ret = __cl_gen_to_be_invoked.IsEqualActor( attacker, defender );
                        LuaAPI.lua_pushboolean(L, __cl_gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_IsEnemyRelation(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            xc.PKModeManagerEx __cl_gen_to_be_invoked = (xc.PKModeManagerEx)translator.FastGetCSObj(L, 1);
            
            
            try {
                
                {
                    Actor attacker = (Actor)translator.GetObject(L, 2, typeof(Actor));
                    Actor defender = (Actor)translator.GetObject(L, 3, typeof(Actor));
                    bool show_tips = LuaAPI.lua_toboolean(L, 4);
                    
                        bool __cl_gen_ret = __cl_gen_to_be_invoked.IsEnemyRelation( attacker, defender, ref show_tips );
                        LuaAPI.lua_pushboolean(L, __cl_gen_ret);
                    LuaAPI.lua_pushboolean(L, show_tips);
                        
                    
                    
                    
                    return 2;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_IsFriendRelation(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            xc.PKModeManagerEx __cl_gen_to_be_invoked = (xc.PKModeManagerEx)translator.FastGetCSObj(L, 1);
            
            
            try {
                
                {
                    Actor attacker = (Actor)translator.GetObject(L, 2, typeof(Actor));
                    Actor defender = (Actor)translator.GetObject(L, 3, typeof(Actor));
                    
                        bool __cl_gen_ret = __cl_gen_to_be_invoked.IsFriendRelation( attacker, defender );
                        LuaAPI.lua_pushboolean(L, __cl_gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_IsLocalPlayerCanAttackActor(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            xc.PKModeManagerEx __cl_gen_to_be_invoked = (xc.PKModeManagerEx)translator.FastGetCSObj(L, 1);
            
            
            try {
                
                {
                    Actor actor = (Actor)translator.GetObject(L, 2, typeof(Actor));
                    bool show_tips = LuaAPI.lua_toboolean(L, 3);
                    
                        bool __cl_gen_ret = __cl_gen_to_be_invoked.IsLocalPlayerCanAttackActor( actor, ref show_tips );
                        LuaAPI.lua_pushboolean(L, __cl_gen_ret);
                    LuaAPI.lua_pushboolean(L, show_tips);
                        
                    
                    
                    
                    return 2;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_IsActorCanAttackLocalPlayer(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            xc.PKModeManagerEx __cl_gen_to_be_invoked = (xc.PKModeManagerEx)translator.FastGetCSObj(L, 1);
            
            
            try {
                
                {
                    Actor actor = (Actor)translator.GetObject(L, 2, typeof(Actor));
                    bool show_tips = LuaAPI.lua_toboolean(L, 3);
                    
                        bool __cl_gen_ret = __cl_gen_to_be_invoked.IsActorCanAttackLocalPlayer( actor, ref show_tips );
                        LuaAPI.lua_pushboolean(L, __cl_gen_ret);
                    LuaAPI.lua_pushboolean(L, show_tips);
                        
                    
                    
                    
                    return 2;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_TryShowHostileAttackTips(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            xc.PKModeManagerEx __cl_gen_to_be_invoked = (xc.PKModeManagerEx)translator.FastGetCSObj(L, 1);
            
            
            try {
                
                {
                    bool isPlayer = LuaAPI.lua_toboolean(L, 2);
                    uint obj_idx = LuaAPI.xlua_touint(L, 3);
                    string name = LuaAPI.lua_tostring(L, 4);
                    
                    __cl_gen_to_be_invoked.TryShowHostileAttackTips( isPlayer, obj_idx, name );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_IsScenePKSafe(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            xc.PKModeManagerEx __cl_gen_to_be_invoked = (xc.PKModeManagerEx)translator.FastGetCSObj(L, 1);
            
            
            try {
                
                {
                    int scene_pk_type = LuaAPI.xlua_tointeger(L, 2);
                    
                        bool __cl_gen_ret = __cl_gen_to_be_invoked.IsScenePKSafe( scene_pk_type );
                        LuaAPI.lua_pushboolean(L, __cl_gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        
        
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_IsPVPBattleState(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.PKModeManagerEx __cl_gen_to_be_invoked = (xc.PKModeManagerEx)translator.FastGetCSObj(L, 1);
                LuaAPI.lua_pushboolean(L, __cl_gen_to_be_invoked.IsPVPBattleState);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_IsInSafeArea(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.PKModeManagerEx __cl_gen_to_be_invoked = (xc.PKModeManagerEx)translator.FastGetCSObj(L, 1);
                LuaAPI.lua_pushboolean(L, __cl_gen_to_be_invoked.IsInSafeArea);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_IsInPKArea(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.PKModeManagerEx __cl_gen_to_be_invoked = (xc.PKModeManagerEx)translator.FastGetCSObj(L, 1);
                LuaAPI.lua_pushboolean(L, __cl_gen_to_be_invoked.IsInPKArea);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_PKValue(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.PKModeManagerEx __cl_gen_to_be_invoked = (xc.PKModeManagerEx)translator.FastGetCSObj(L, 1);
                LuaAPI.xlua_pushuint(L, __cl_gen_to_be_invoked.PKValue);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_PKMode(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.PKModeManagerEx __cl_gen_to_be_invoked = (xc.PKModeManagerEx)translator.FastGetCSObj(L, 1);
                LuaAPI.xlua_pushuint(L, __cl_gen_to_be_invoked.PKMode);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_ShowPVPBlood(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.PKModeManagerEx __cl_gen_to_be_invoked = (xc.PKModeManagerEx)translator.FastGetCSObj(L, 1);
                LuaAPI.lua_pushboolean(L, __cl_gen_to_be_invoked.ShowPVPBlood);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_IsPKProtectionTeamMate(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.PKModeManagerEx __cl_gen_to_be_invoked = (xc.PKModeManagerEx)translator.FastGetCSObj(L, 1);
                LuaAPI.lua_pushboolean(L, __cl_gen_to_be_invoked.IsPKProtectionTeamMate);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_IsPKProtectionSociety(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.PKModeManagerEx __cl_gen_to_be_invoked = (xc.PKModeManagerEx)translator.FastGetCSObj(L, 1);
                LuaAPI.lua_pushboolean(L, __cl_gen_to_be_invoked.IsPKProtectionSociety);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_IsPKProtectionGreenName(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.PKModeManagerEx __cl_gen_to_be_invoked = (xc.PKModeManagerEx)translator.FastGetCSObj(L, 1);
                LuaAPI.lua_pushboolean(L, __cl_gen_to_be_invoked.IsPKProtectionGreenName);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_PKProtectionLv(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.PKModeManagerEx __cl_gen_to_be_invoked = (xc.PKModeManagerEx)translator.FastGetCSObj(L, 1);
                LuaAPI.xlua_pushuint(L, __cl_gen_to_be_invoked.PKProtectionLv);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_LocalPlayerNameColor(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.PKModeManagerEx __cl_gen_to_be_invoked = (xc.PKModeManagerEx)translator.FastGetCSObj(L, 1);
                LuaAPI.xlua_pushuint(L, __cl_gen_to_be_invoked.LocalPlayerNameColor);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_mGamePKLvProtect(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.PKModeManagerEx __cl_gen_to_be_invoked = (xc.PKModeManagerEx)translator.FastGetCSObj(L, 1);
                LuaAPI.xlua_pushinteger(L, __cl_gen_to_be_invoked.mGamePKLvProtect);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_IsPVPBattleState(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.PKModeManagerEx __cl_gen_to_be_invoked = (xc.PKModeManagerEx)translator.FastGetCSObj(L, 1);
                __cl_gen_to_be_invoked.IsPVPBattleState = LuaAPI.lua_toboolean(L, 2);
            
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_IsInSafeArea(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.PKModeManagerEx __cl_gen_to_be_invoked = (xc.PKModeManagerEx)translator.FastGetCSObj(L, 1);
                __cl_gen_to_be_invoked.IsInSafeArea = LuaAPI.lua_toboolean(L, 2);
            
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_IsInPKArea(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.PKModeManagerEx __cl_gen_to_be_invoked = (xc.PKModeManagerEx)translator.FastGetCSObj(L, 1);
                __cl_gen_to_be_invoked.IsInPKArea = LuaAPI.lua_toboolean(L, 2);
            
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_PKValue(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.PKModeManagerEx __cl_gen_to_be_invoked = (xc.PKModeManagerEx)translator.FastGetCSObj(L, 1);
                __cl_gen_to_be_invoked.PKValue = LuaAPI.xlua_touint(L, 2);
            
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_ShowPVPBlood(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.PKModeManagerEx __cl_gen_to_be_invoked = (xc.PKModeManagerEx)translator.FastGetCSObj(L, 1);
                __cl_gen_to_be_invoked.ShowPVPBlood = LuaAPI.lua_toboolean(L, 2);
            
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_IsPKProtectionTeamMate(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.PKModeManagerEx __cl_gen_to_be_invoked = (xc.PKModeManagerEx)translator.FastGetCSObj(L, 1);
                __cl_gen_to_be_invoked.IsPKProtectionTeamMate = LuaAPI.lua_toboolean(L, 2);
            
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_IsPKProtectionSociety(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.PKModeManagerEx __cl_gen_to_be_invoked = (xc.PKModeManagerEx)translator.FastGetCSObj(L, 1);
                __cl_gen_to_be_invoked.IsPKProtectionSociety = LuaAPI.lua_toboolean(L, 2);
            
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_IsPKProtectionGreenName(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.PKModeManagerEx __cl_gen_to_be_invoked = (xc.PKModeManagerEx)translator.FastGetCSObj(L, 1);
                __cl_gen_to_be_invoked.IsPKProtectionGreenName = LuaAPI.lua_toboolean(L, 2);
            
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_PKProtectionLv(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.PKModeManagerEx __cl_gen_to_be_invoked = (xc.PKModeManagerEx)translator.FastGetCSObj(L, 1);
                __cl_gen_to_be_invoked.PKProtectionLv = LuaAPI.xlua_touint(L, 2);
            
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_LocalPlayerNameColor(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.PKModeManagerEx __cl_gen_to_be_invoked = (xc.PKModeManagerEx)translator.FastGetCSObj(L, 1);
                __cl_gen_to_be_invoked.LocalPlayerNameColor = LuaAPI.xlua_touint(L, 2);
            
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_mGamePKLvProtect(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.PKModeManagerEx __cl_gen_to_be_invoked = (xc.PKModeManagerEx)translator.FastGetCSObj(L, 1);
                __cl_gen_to_be_invoked.mGamePKLvProtect = LuaAPI.xlua_tointeger(L, 2);
            
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 0;
        }
        
		
		
		
		
    }
}
