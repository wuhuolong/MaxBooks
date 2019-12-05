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
    public class MonsterWrap
    {
        public static void __Register(RealStatePtr L)
        {
			ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			XUtils.BeginObjectRegister(typeof(Monster), L, translator, 0, 19, 11, 7);
			
			XUtils.RegisterFunc(L, XUtils.METHOD_IDX, "OnBecomeVisible", _m_OnBecomeVisible);
			XUtils.RegisterFunc(L, XUtils.METHOD_IDX, "OnResLoaded", _m_OnResLoaded);
			XUtils.RegisterFunc(L, XUtils.METHOD_IDX, "AfterCreate", _m_AfterCreate);
			XUtils.RegisterFunc(L, XUtils.METHOD_IDX, "SetMonsterType", _m_SetMonsterType);
			XUtils.RegisterFunc(L, XUtils.METHOD_IDX, "ActiveAI", _m_ActiveAI);
			XUtils.RegisterFunc(L, XUtils.METHOD_IDX, "Kill", _m_Kill);
			XUtils.RegisterFunc(L, XUtils.METHOD_IDX, "DoDamage", _m_DoDamage);
			XUtils.RegisterFunc(L, XUtils.METHOD_IDX, "Beattacked", _m_Beattacked);
			XUtils.RegisterFunc(L, XUtils.METHOD_IDX, "EnterFreezeState", _m_EnterFreezeState);
			XUtils.RegisterFunc(L, XUtils.METHOD_IDX, "ExitFreezeState", _m_ExitFreezeState);
			XUtils.RegisterFunc(L, XUtils.METHOD_IDX, "EnterDizzyState", _m_EnterDizzyState);
			XUtils.RegisterFunc(L, XUtils.METHOD_IDX, "ExitDizzyState", _m_ExitDizzyState);
			XUtils.RegisterFunc(L, XUtils.METHOD_IDX, "IsBoss", _m_IsBoss);
			XUtils.RegisterFunc(L, XUtils.METHOD_IDX, "IsWorldBoss", _m_IsWorldBoss);
			XUtils.RegisterFunc(L, XUtils.METHOD_IDX, "GetMonsterColorStr", _m_GetMonsterColorStr);
			XUtils.RegisterFunc(L, XUtils.METHOD_IDX, "IsMonster", _m_IsMonster);
			XUtils.RegisterFunc(L, XUtils.METHOD_IDX, "SetHeadIcons", _m_SetHeadIcons);
			XUtils.RegisterFunc(L, XUtils.METHOD_IDX, "CanBeChoosed", _m_CanBeChoosed);
			XUtils.RegisterFunc(L, XUtils.METHOD_IDX, "CanBeHited", _m_CanBeHited);
			
			
			XUtils.RegisterFunc(L, XUtils.GETTER_IDX, "AlwaysShowHpBar", _g_get_AlwaysShowHpBar);
            XUtils.RegisterFunc(L, XUtils.GETTER_IDX, "IsSummonMonster", _g_get_IsSummonMonster);
            XUtils.RegisterFunc(L, XUtils.GETTER_IDX, "InstMonsterType", _g_get_InstMonsterType);
            XUtils.RegisterFunc(L, XUtils.GETTER_IDX, "SpawnType", _g_get_SpawnType);
            XUtils.RegisterFunc(L, XUtils.GETTER_IDX, "Color", _g_get_Color);
            XUtils.RegisterFunc(L, XUtils.GETTER_IDX, "CenterSpawnPos", _g_get_CenterSpawnPos);
            XUtils.RegisterFunc(L, XUtils.GETTER_IDX, "MotionRadius", _g_get_MotionRadius);
            XUtils.RegisterFunc(L, XUtils.GETTER_IDX, "MaxChaseDistance", _g_get_MaxChaseDistance);
            XUtils.RegisterFunc(L, XUtils.GETTER_IDX, "SkillIds", _g_get_SkillIds);
            XUtils.RegisterFunc(L, XUtils.GETTER_IDX, "BeSummonedType", _g_get_BeSummonedType);
            XUtils.RegisterFunc(L, XUtils.GETTER_IDX, "m_SummonMonster", _g_get_m_SummonMonster);
            
			XUtils.RegisterFunc(L, XUtils.SETTER_IDX, "AlwaysShowHpBar", _s_set_AlwaysShowHpBar);
            XUtils.RegisterFunc(L, XUtils.SETTER_IDX, "SpawnType", _s_set_SpawnType);
            XUtils.RegisterFunc(L, XUtils.SETTER_IDX, "Color", _s_set_Color);
            XUtils.RegisterFunc(L, XUtils.SETTER_IDX, "CenterSpawnPos", _s_set_CenterSpawnPos);
            XUtils.RegisterFunc(L, XUtils.SETTER_IDX, "SkillIds", _s_set_SkillIds);
            XUtils.RegisterFunc(L, XUtils.SETTER_IDX, "BeSummonedType", _s_set_BeSummonedType);
            XUtils.RegisterFunc(L, XUtils.SETTER_IDX, "m_SummonMonster", _s_set_m_SummonMonster);
            
			XUtils.EndObjectRegister(typeof(Monster), L, translator, null, null,
			    null, null, null);

		    XUtils.BeginClassRegister(typeof(Monster), L, __CreateInstance, 1, 0, 0);
			
			
            
            XUtils.RegisterObject(L, translator, XUtils.CLS_IDX, "UnderlyingSystemType", typeof(Monster));
			
			
			XUtils.EndClassRegister(typeof(Monster), L, translator);
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int __CreateInstance(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			try {
				if(LuaAPI.lua_gettop(L) == 1)
				{
					
					Monster __cl_gen_ret = new Monster();
					translator.Push(L, __cl_gen_ret);
					return 1;
				}
				
			}
			catch(System.Exception __gen_e) {
				return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
			}
            return LuaAPI.luaL_error(L, "invalid arguments to Monster constructor!");
            
        }
        
		
        
		
        
        
        
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_OnBecomeVisible(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            Monster __cl_gen_to_be_invoked = (Monster)translator.FastGetCSObj(L, 1);
            
            
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
        static int _m_OnResLoaded(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            Monster __cl_gen_to_be_invoked = (Monster)translator.FastGetCSObj(L, 1);
            
            
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
            
            
            Monster __cl_gen_to_be_invoked = (Monster)translator.FastGetCSObj(L, 1);
            
            
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
        static int _m_SetMonsterType(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            Monster __cl_gen_to_be_invoked = (Monster)translator.FastGetCSObj(L, 1);
            
            
            try {
                
                {
                    Monster.MonsterType t;translator.Get(L, 2, out t);
                    
                    __cl_gen_to_be_invoked.SetMonsterType( t );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_ActiveAI(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            Monster __cl_gen_to_be_invoked = (Monster)translator.FastGetCSObj(L, 1);
            
            
            try {
                
                {
                    bool active = LuaAPI.lua_toboolean(L, 2);
                    
                    __cl_gen_to_be_invoked.ActiveAI( active );
                    
                    
                    
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
            
            
            Monster __cl_gen_to_be_invoked = (Monster)translator.FastGetCSObj(L, 1);
            
            
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
        static int _m_DoDamage(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            Monster __cl_gen_to_be_invoked = (Monster)translator.FastGetCSObj(L, 1);
            
            
            try {
                
                {
                    uint attacker_obj_idx = LuaAPI.xlua_touint(L, 2);
                    int iDamageValue = LuaAPI.xlua_tointeger(L, 3);
                    float fShowDelayTime = (float)LuaAPI.lua_tonumber(L, 4);
                    bool bCritic = LuaAPI.lua_toboolean(L, 5);
                    uint proto_damageEffectType = LuaAPI.xlua_touint(L, 6);
                    
                    __cl_gen_to_be_invoked.DoDamage( attacker_obj_idx, iDamageValue, fShowDelayTime, bCritic, proto_damageEffectType );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_Beattacked(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            Monster __cl_gen_to_be_invoked = (Monster)translator.FastGetCSObj(L, 1);
            
            
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
        static int _m_EnterFreezeState(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            Monster __cl_gen_to_be_invoked = (Monster)translator.FastGetCSObj(L, 1);
            
            
            try {
                
                {
                    
                    __cl_gen_to_be_invoked.EnterFreezeState(  );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_ExitFreezeState(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            Monster __cl_gen_to_be_invoked = (Monster)translator.FastGetCSObj(L, 1);
            
            
            try {
                
                {
                    
                    __cl_gen_to_be_invoked.ExitFreezeState(  );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_EnterDizzyState(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            Monster __cl_gen_to_be_invoked = (Monster)translator.FastGetCSObj(L, 1);
            
            
            try {
                
                {
                    
                    __cl_gen_to_be_invoked.EnterDizzyState(  );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_ExitDizzyState(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            Monster __cl_gen_to_be_invoked = (Monster)translator.FastGetCSObj(L, 1);
            
            
            try {
                
                {
                    
                    __cl_gen_to_be_invoked.ExitDizzyState(  );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_IsBoss(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            Monster __cl_gen_to_be_invoked = (Monster)translator.FastGetCSObj(L, 1);
            
            
            try {
                
                {
                    
                        bool __cl_gen_ret = __cl_gen_to_be_invoked.IsBoss(  );
                        LuaAPI.lua_pushboolean(L, __cl_gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_IsWorldBoss(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            Monster __cl_gen_to_be_invoked = (Monster)translator.FastGetCSObj(L, 1);
            
            
            try {
                
                {
                    
                        bool __cl_gen_ret = __cl_gen_to_be_invoked.IsWorldBoss(  );
                        LuaAPI.lua_pushboolean(L, __cl_gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_GetMonsterColorStr(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            Monster __cl_gen_to_be_invoked = (Monster)translator.FastGetCSObj(L, 1);
            
            
            try {
                
                {
                    
                        string __cl_gen_ret = __cl_gen_to_be_invoked.GetMonsterColorStr(  );
                        LuaAPI.lua_pushstring(L, __cl_gen_ret);
                    
                    
                    
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
            
            
            Monster __cl_gen_to_be_invoked = (Monster)translator.FastGetCSObj(L, 1);
            
            
            try {
                
                {
                    
                        bool __cl_gen_ret = __cl_gen_to_be_invoked.IsMonster(  );
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
            
            
            Monster __cl_gen_to_be_invoked = (Monster)translator.FastGetCSObj(L, 1);
            
            
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
        static int _m_CanBeChoosed(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            Monster __cl_gen_to_be_invoked = (Monster)translator.FastGetCSObj(L, 1);
            
            
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
        static int _m_CanBeHited(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            Monster __cl_gen_to_be_invoked = (Monster)translator.FastGetCSObj(L, 1);
            
            
            try {
                
                {
                    
                        bool __cl_gen_ret = __cl_gen_to_be_invoked.CanBeHited(  );
                        LuaAPI.lua_pushboolean(L, __cl_gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        
        
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_AlwaysShowHpBar(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                Monster __cl_gen_to_be_invoked = (Monster)translator.FastGetCSObj(L, 1);
                LuaAPI.lua_pushboolean(L, __cl_gen_to_be_invoked.AlwaysShowHpBar);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_IsSummonMonster(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                Monster __cl_gen_to_be_invoked = (Monster)translator.FastGetCSObj(L, 1);
                LuaAPI.lua_pushboolean(L, __cl_gen_to_be_invoked.IsSummonMonster);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_InstMonsterType(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                Monster __cl_gen_to_be_invoked = (Monster)translator.FastGetCSObj(L, 1);
                translator.PushMonsterMonsterType(L, __cl_gen_to_be_invoked.InstMonsterType);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_SpawnType(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                Monster __cl_gen_to_be_invoked = (Monster)translator.FastGetCSObj(L, 1);
                translator.PushMonsterMonsterSpawnType(L, __cl_gen_to_be_invoked.SpawnType);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_Color(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                Monster __cl_gen_to_be_invoked = (Monster)translator.FastGetCSObj(L, 1);
                translator.PushMonsterQualityColor(L, __cl_gen_to_be_invoked.Color);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_CenterSpawnPos(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                Monster __cl_gen_to_be_invoked = (Monster)translator.FastGetCSObj(L, 1);
                translator.PushUnityEngineVector3(L, __cl_gen_to_be_invoked.CenterSpawnPos);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_MotionRadius(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                Monster __cl_gen_to_be_invoked = (Monster)translator.FastGetCSObj(L, 1);
                LuaAPI.xlua_pushinteger(L, __cl_gen_to_be_invoked.MotionRadius);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_MaxChaseDistance(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                Monster __cl_gen_to_be_invoked = (Monster)translator.FastGetCSObj(L, 1);
                LuaAPI.xlua_pushinteger(L, __cl_gen_to_be_invoked.MaxChaseDistance);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_SkillIds(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                Monster __cl_gen_to_be_invoked = (Monster)translator.FastGetCSObj(L, 1);
                translator.Push(L, __cl_gen_to_be_invoked.SkillIds);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_BeSummonedType(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                Monster __cl_gen_to_be_invoked = (Monster)translator.FastGetCSObj(L, 1);
                translator.PushMonsterBeSummonType(L, __cl_gen_to_be_invoked.BeSummonedType);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_m_SummonMonster(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                Monster __cl_gen_to_be_invoked = (Monster)translator.FastGetCSObj(L, 1);
                LuaAPI.lua_pushboolean(L, __cl_gen_to_be_invoked.m_SummonMonster);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_AlwaysShowHpBar(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                Monster __cl_gen_to_be_invoked = (Monster)translator.FastGetCSObj(L, 1);
                __cl_gen_to_be_invoked.AlwaysShowHpBar = LuaAPI.lua_toboolean(L, 2);
            
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_SpawnType(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                Monster __cl_gen_to_be_invoked = (Monster)translator.FastGetCSObj(L, 1);
                Monster.MonsterSpawnType __cl_gen_value;translator.Get(L, 2, out __cl_gen_value);
				__cl_gen_to_be_invoked.SpawnType = __cl_gen_value;
            
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_Color(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                Monster __cl_gen_to_be_invoked = (Monster)translator.FastGetCSObj(L, 1);
                Monster.QualityColor __cl_gen_value;translator.Get(L, 2, out __cl_gen_value);
				__cl_gen_to_be_invoked.Color = __cl_gen_value;
            
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_CenterSpawnPos(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                Monster __cl_gen_to_be_invoked = (Monster)translator.FastGetCSObj(L, 1);
                UnityEngine.Vector3 __cl_gen_value;translator.Get(L, 2, out __cl_gen_value);
				__cl_gen_to_be_invoked.CenterSpawnPos = __cl_gen_value;
            
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_SkillIds(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                Monster __cl_gen_to_be_invoked = (Monster)translator.FastGetCSObj(L, 1);
                __cl_gen_to_be_invoked.SkillIds = (System.Collections.Generic.List<uint>)translator.GetObject(L, 2, typeof(System.Collections.Generic.List<uint>));
            
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_BeSummonedType(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                Monster __cl_gen_to_be_invoked = (Monster)translator.FastGetCSObj(L, 1);
                Monster.BeSummonType __cl_gen_value;translator.Get(L, 2, out __cl_gen_value);
				__cl_gen_to_be_invoked.BeSummonedType = __cl_gen_value;
            
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_m_SummonMonster(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                Monster __cl_gen_to_be_invoked = (Monster)translator.FastGetCSObj(L, 1);
                __cl_gen_to_be_invoked.m_SummonMonster = LuaAPI.lua_toboolean(L, 2);
            
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 0;
        }
        
		
		
		
		
    }
}
