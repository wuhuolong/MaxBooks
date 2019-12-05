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
    public class PlayerWrap
    {
        public static void __Register(RealStatePtr L)
        {
			ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			XUtils.BeginObjectRegister(typeof(Player), L, translator, 0, 32, 4, 4);
			
			XUtils.RegisterFunc(L, XUtils.METHOD_IDX, "SetShowBar", _m_SetShowBar);
			XUtils.RegisterFunc(L, XUtils.METHOD_IDX, "RefreshPVPBlood", _m_RefreshPVPBlood);
			XUtils.RegisterFunc(L, XUtils.METHOD_IDX, "Update", _m_Update);
			XUtils.RegisterFunc(L, XUtils.METHOD_IDX, "LateUpdate", _m_LateUpdate);
			XUtils.RegisterFunc(L, XUtils.METHOD_IDX, "Kill", _m_Kill);
			XUtils.RegisterFunc(L, XUtils.METHOD_IDX, "Relive", _m_Relive);
			XUtils.RegisterFunc(L, XUtils.METHOD_IDX, "Destroy", _m_Destroy);
			XUtils.RegisterFunc(L, XUtils.METHOD_IDX, "OnResLoaded", _m_OnResLoaded);
			XUtils.RegisterFunc(L, XUtils.METHOD_IDX, "AfterCreate", _m_AfterCreate);
			XUtils.RegisterFunc(L, XUtils.METHOD_IDX, "IsPlayer", _m_IsPlayer);
			XUtils.RegisterFunc(L, XUtils.METHOD_IDX, "SetHeadIcons", _m_SetHeadIcons);
			XUtils.RegisterFunc(L, XUtils.METHOD_IDX, "UpdatePetId", _m_UpdatePetId);
			XUtils.RegisterFunc(L, XUtils.METHOD_IDX, "UpdateEscortNPC", _m_UpdateEscortNPC);
			XUtils.RegisterFunc(L, XUtils.METHOD_IDX, "GetEscortNPC", _m_GetEscortNPC);
			XUtils.RegisterFunc(L, XUtils.METHOD_IDX, "OnBecomeVisible", _m_OnBecomeVisible);
			XUtils.RegisterFunc(L, XUtils.METHOD_IDX, "OnBecomeNameVisible", _m_OnBecomeNameVisible);
			XUtils.RegisterFunc(L, XUtils.METHOD_IDX, "GetPet", _m_GetPet);
			XUtils.RegisterFunc(L, XUtils.METHOD_IDX, "Beattacked", _m_Beattacked);
			XUtils.RegisterFunc(L, XUtils.METHOD_IDX, "OnBattleTrigger", _m_OnBattleTrigger);
			XUtils.RegisterFunc(L, XUtils.METHOD_IDX, "OnBattleTimeOut", _m_OnBattleTimeOut);
			XUtils.RegisterFunc(L, XUtils.METHOD_IDX, "InitBehaviors", _m_InitBehaviors);
			XUtils.RegisterFunc(L, XUtils.METHOD_IDX, "GetPKModeBehavior", _m_GetPKModeBehavior);
			XUtils.RegisterFunc(L, XUtils.METHOD_IDX, "UpdatePKMode", _m_UpdatePKMode);
			XUtils.RegisterFunc(L, XUtils.METHOD_IDX, "SetPKMode", _m_SetPKMode);
			XUtils.RegisterFunc(L, XUtils.METHOD_IDX, "GetPKMode", _m_GetPKMode);
			XUtils.RegisterFunc(L, XUtils.METHOD_IDX, "CanBeChoosed", _m_CanBeChoosed);
			XUtils.RegisterFunc(L, XUtils.METHOD_IDX, "UpdatePetAttackSpeed", _m_UpdatePetAttackSpeed);
			XUtils.RegisterFunc(L, XUtils.METHOD_IDX, "UpdatePetMoveSpeed", _m_UpdatePetMoveSpeed);
			XUtils.RegisterFunc(L, XUtils.METHOD_IDX, "UpdateEscortNPCMoveSpeed", _m_UpdateEscortNPCMoveSpeed);
			XUtils.RegisterFunc(L, XUtils.METHOD_IDX, "UpdatePVPBlood", _m_UpdatePVPBlood);
			XUtils.RegisterFunc(L, XUtils.METHOD_IDX, "StartPickUpBossChipEffect", _m_StartPickUpBossChipEffect);
			XUtils.RegisterFunc(L, XUtils.METHOD_IDX, "FinishPickUpEffect", _m_FinishPickUpEffect);
			
			
			XUtils.RegisterFunc(L, XUtils.GETTER_IDX, "IsShowPickUpBossChip", _g_get_IsShowPickUpBossChip);
            XUtils.RegisterFunc(L, XUtils.GETTER_IDX, "CurrentPet", _g_get_CurrentPet);
            XUtils.RegisterFunc(L, XUtils.GETTER_IDX, "CurrentEscortNPC", _g_get_CurrentEscortNPC);
            XUtils.RegisterFunc(L, XUtils.GETTER_IDX, "CreatePetWhenVisible", _g_get_CreatePetWhenVisible);
            
			XUtils.RegisterFunc(L, XUtils.SETTER_IDX, "OpenPVPBlood", _s_set_OpenPVPBlood);
            XUtils.RegisterFunc(L, XUtils.SETTER_IDX, "CurrentPet", _s_set_CurrentPet);
            XUtils.RegisterFunc(L, XUtils.SETTER_IDX, "CurrentEscortNPC", _s_set_CurrentEscortNPC);
            XUtils.RegisterFunc(L, XUtils.SETTER_IDX, "CreatePetWhenVisible", _s_set_CreatePetWhenVisible);
            
			XUtils.EndObjectRegister(typeof(Player), L, translator, null, null,
			    null, null, null);

		    XUtils.BeginClassRegister(typeof(Player), L, __CreateInstance, 1, 1, 0);
			
			
            
            XUtils.RegisterObject(L, translator, XUtils.CLS_IDX, "UnderlyingSystemType", typeof(Player));
			XUtils.RegisterFunc(L, XUtils.CLS_GETTER_IDX, "ExitBattleStateTime", _g_get_ExitBattleStateTime);
            
			
			XUtils.EndClassRegister(typeof(Player), L, translator);
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int __CreateInstance(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			try {
				if(LuaAPI.lua_gettop(L) == 1)
				{
					
					Player __cl_gen_ret = new Player();
					translator.Push(L, __cl_gen_ret);
					return 1;
				}
				
			}
			catch(System.Exception __gen_e) {
				return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
			}
            return LuaAPI.luaL_error(L, "invalid arguments to Player constructor!");
            
        }
        
		
        
		
        
        
        
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_SetShowBar(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            Player __cl_gen_to_be_invoked = (Player)translator.FastGetCSObj(L, 1);
            
            
            try {
                
                {
                    UI3DText.StyleInfo info = (UI3DText.StyleInfo)translator.GetObject(L, 2, typeof(UI3DText.StyleInfo));
                    bool is_show_bar = LuaAPI.lua_toboolean(L, 3);
                    
                    __cl_gen_to_be_invoked.SetShowBar( info, is_show_bar );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_RefreshPVPBlood(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            Player __cl_gen_to_be_invoked = (Player)translator.FastGetCSObj(L, 1);
            
            
            try {
                
                {
                    
                    __cl_gen_to_be_invoked.RefreshPVPBlood(  );
                    
                    
                    
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
            
            
            Player __cl_gen_to_be_invoked = (Player)translator.FastGetCSObj(L, 1);
            
            
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
        static int _m_LateUpdate(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            Player __cl_gen_to_be_invoked = (Player)translator.FastGetCSObj(L, 1);
            
            
            try {
                
                {
                    
                    __cl_gen_to_be_invoked.LateUpdate(  );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_Kill(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            Player __cl_gen_to_be_invoked = (Player)translator.FastGetCSObj(L, 1);
            
            
            try {
                
                {
                    
                        bool __cl_gen_ret = __cl_gen_to_be_invoked.Kill(  );
                        LuaAPI.lua_pushboolean(L, __cl_gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_Relive(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            Player __cl_gen_to_be_invoked = (Player)translator.FastGetCSObj(L, 1);
            
            
            try {
                
                {
                    
                        bool __cl_gen_ret = __cl_gen_to_be_invoked.Relive(  );
                        LuaAPI.lua_pushboolean(L, __cl_gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_Destroy(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            Player __cl_gen_to_be_invoked = (Player)translator.FastGetCSObj(L, 1);
            
            
            try {
                
                {
                    
                    __cl_gen_to_be_invoked.Destroy(  );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_OnResLoaded(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            Player __cl_gen_to_be_invoked = (Player)translator.FastGetCSObj(L, 1);
            
            
            try {
                
                {
                    
                    __cl_gen_to_be_invoked.OnResLoaded(  );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_AfterCreate(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            Player __cl_gen_to_be_invoked = (Player)translator.FastGetCSObj(L, 1);
            
            
            try {
                
                {
                    
                    __cl_gen_to_be_invoked.AfterCreate(  );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_IsPlayer(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            Player __cl_gen_to_be_invoked = (Player)translator.FastGetCSObj(L, 1);
            
            
            try {
                
                {
                    
                        bool __cl_gen_ret = __cl_gen_to_be_invoked.IsPlayer(  );
                        LuaAPI.lua_pushboolean(L, __cl_gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_SetHeadIcons(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            Player __cl_gen_to_be_invoked = (Player)translator.FastGetCSObj(L, 1);
            
            
            try {
                
                {
                    Actor.EHeadIcon icon_type;translator.Get(L, 2, out icon_type);
                    
                    __cl_gen_to_be_invoked.SetHeadIcons( icon_type );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_UpdatePetId(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            Player __cl_gen_to_be_invoked = (Player)translator.FastGetCSObj(L, 1);
            
            
            try {
                
                {
                    uint new_pet_id = LuaAPI.xlua_touint(L, 2);
                    
                    __cl_gen_to_be_invoked.UpdatePetId( new_pet_id );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_UpdateEscortNPC(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            Player __cl_gen_to_be_invoked = (Player)translator.FastGetCSObj(L, 1);
            
            
            try {
                
                {
                    
                    __cl_gen_to_be_invoked.UpdateEscortNPC(  );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_GetEscortNPC(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            Player __cl_gen_to_be_invoked = (Player)translator.FastGetCSObj(L, 1);
            
            
            try {
                
                {
                    
                        Actor __cl_gen_ret = __cl_gen_to_be_invoked.GetEscortNPC(  );
                        translator.Push(L, __cl_gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_OnBecomeVisible(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            Player __cl_gen_to_be_invoked = (Player)translator.FastGetCSObj(L, 1);
            
            
            try {
                
                {
                    bool bVisible = LuaAPI.lua_toboolean(L, 2);
                    
                    __cl_gen_to_be_invoked.OnBecomeVisible( bVisible );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_OnBecomeNameVisible(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            Player __cl_gen_to_be_invoked = (Player)translator.FastGetCSObj(L, 1);
            
            
            try {
                
                {
                    
                    __cl_gen_to_be_invoked.OnBecomeNameVisible(  );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_GetPet(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            Player __cl_gen_to_be_invoked = (Player)translator.FastGetCSObj(L, 1);
            
            
            try {
                
                {
                    
                        Pet __cl_gen_ret = __cl_gen_to_be_invoked.GetPet(  );
                        translator.Push(L, __cl_gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_Beattacked(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            Player __cl_gen_to_be_invoked = (Player)translator.FastGetCSObj(L, 1);
            
            
            try {
                
                {
                    xc.Damage dam = (xc.Damage)translator.GetObject(L, 2, typeof(xc.Damage));
                    
                    __cl_gen_to_be_invoked.Beattacked( dam );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_OnBattleTrigger(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            Player __cl_gen_to_be_invoked = (Player)translator.FastGetCSObj(L, 1);
            
            
            try {
                
                {
                    
                    __cl_gen_to_be_invoked.OnBattleTrigger(  );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_OnBattleTimeOut(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            Player __cl_gen_to_be_invoked = (Player)translator.FastGetCSObj(L, 1);
            
            
            try {
                
                {
                    float remain = (float)LuaAPI.lua_tonumber(L, 2);
                    
                    __cl_gen_to_be_invoked.OnBattleTimeOut( remain );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_InitBehaviors(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            Player __cl_gen_to_be_invoked = (Player)translator.FastGetCSObj(L, 1);
            
            
            try {
                
                {
                    
                    __cl_gen_to_be_invoked.InitBehaviors(  );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_GetPKModeBehavior(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            Player __cl_gen_to_be_invoked = (Player)translator.FastGetCSObj(L, 1);
            
            
            try {
                
                {
                    
                        xc.PKModeBehavior __cl_gen_ret = __cl_gen_to_be_invoked.GetPKModeBehavior(  );
                        translator.Push(L, __cl_gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_UpdatePKMode(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            Player __cl_gen_to_be_invoked = (Player)translator.FastGetCSObj(L, 1);
            
            
            try {
                
                {
                    ulong mBitStates = LuaAPI.lua_touint64(L, 2);
                    
                    __cl_gen_to_be_invoked.UpdatePKMode( mBitStates );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_SetPKMode(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            Player __cl_gen_to_be_invoked = (Player)translator.FastGetCSObj(L, 1);
            
            
            try {
                
                {
                    uint new_pk_mode = LuaAPI.xlua_touint(L, 2);
                    
                    __cl_gen_to_be_invoked.SetPKMode( new_pk_mode );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_GetPKMode(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            Player __cl_gen_to_be_invoked = (Player)translator.FastGetCSObj(L, 1);
            
            
            try {
                
                {
                    
                        uint __cl_gen_ret = __cl_gen_to_be_invoked.GetPKMode(  );
                        LuaAPI.xlua_pushuint(L, __cl_gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_CanBeChoosed(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            Player __cl_gen_to_be_invoked = (Player)translator.FastGetCSObj(L, 1);
            
            
            try {
                
                {
                    
                        bool __cl_gen_ret = __cl_gen_to_be_invoked.CanBeChoosed(  );
                        LuaAPI.lua_pushboolean(L, __cl_gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_UpdatePetAttackSpeed(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            Player __cl_gen_to_be_invoked = (Player)translator.FastGetCSObj(L, 1);
            
            
            try {
                
                {
                    
                    __cl_gen_to_be_invoked.UpdatePetAttackSpeed(  );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_UpdatePetMoveSpeed(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            Player __cl_gen_to_be_invoked = (Player)translator.FastGetCSObj(L, 1);
            
            
            try {
                
                {
                    
                    __cl_gen_to_be_invoked.UpdatePetMoveSpeed(  );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_UpdateEscortNPCMoveSpeed(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            Player __cl_gen_to_be_invoked = (Player)translator.FastGetCSObj(L, 1);
            
            
            try {
                
                {
                    
                    __cl_gen_to_be_invoked.UpdateEscortNPCMoveSpeed(  );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_UpdatePVPBlood(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            Player __cl_gen_to_be_invoked = (Player)translator.FastGetCSObj(L, 1);
            
            
            try {
                
                {
                    
                    __cl_gen_to_be_invoked.UpdatePVPBlood(  );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_StartPickUpBossChipEffect(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            Player __cl_gen_to_be_invoked = (Player)translator.FastGetCSObj(L, 1);
            
            
            try {
                
                {
                    UnityEngine.Vector3 drop_dest_world_pos;translator.Get(L, 2, out drop_dest_world_pos);
                    
                    __cl_gen_to_be_invoked.StartPickUpBossChipEffect( drop_dest_world_pos );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_FinishPickUpEffect(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            Player __cl_gen_to_be_invoked = (Player)translator.FastGetCSObj(L, 1);
            
            
            try {
                
                {
                    
                    __cl_gen_to_be_invoked.FinishPickUpEffect(  );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        
        
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_ExitBattleStateTime(RealStatePtr L)
        {
            
            try {
			    LuaAPI.xlua_pushuint(L, Player.ExitBattleStateTime);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_IsShowPickUpBossChip(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                Player __cl_gen_to_be_invoked = (Player)translator.FastGetCSObj(L, 1);
                LuaAPI.lua_pushboolean(L, __cl_gen_to_be_invoked.IsShowPickUpBossChip);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_CurrentPet(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                Player __cl_gen_to_be_invoked = (Player)translator.FastGetCSObj(L, 1);
                translator.Push(L, __cl_gen_to_be_invoked.CurrentPet);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_CurrentEscortNPC(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                Player __cl_gen_to_be_invoked = (Player)translator.FastGetCSObj(L, 1);
                translator.Push(L, __cl_gen_to_be_invoked.CurrentEscortNPC);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_CreatePetWhenVisible(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                Player __cl_gen_to_be_invoked = (Player)translator.FastGetCSObj(L, 1);
                LuaAPI.lua_pushboolean(L, __cl_gen_to_be_invoked.CreatePetWhenVisible);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_OpenPVPBlood(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                Player __cl_gen_to_be_invoked = (Player)translator.FastGetCSObj(L, 1);
                __cl_gen_to_be_invoked.OpenPVPBlood = LuaAPI.lua_toboolean(L, 2);
            
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_CurrentPet(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                Player __cl_gen_to_be_invoked = (Player)translator.FastGetCSObj(L, 1);
                __cl_gen_to_be_invoked.CurrentPet = (xc.UnitID)translator.GetObject(L, 2, typeof(xc.UnitID));
            
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_CurrentEscortNPC(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                Player __cl_gen_to_be_invoked = (Player)translator.FastGetCSObj(L, 1);
                __cl_gen_to_be_invoked.CurrentEscortNPC = (xc.UnitID)translator.GetObject(L, 2, typeof(xc.UnitID));
            
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_CreatePetWhenVisible(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                Player __cl_gen_to_be_invoked = (Player)translator.FastGetCSObj(L, 1);
                __cl_gen_to_be_invoked.CreatePetWhenVisible = LuaAPI.lua_toboolean(L, 2);
            
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 0;
        }
        
		
		
		
		
    }
}
