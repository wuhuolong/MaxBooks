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
    public class xcActorMachineWrap
    {
        public static void __Register(RealStatePtr L)
        {
			ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			XUtils.BeginObjectRegister(typeof(xc.ActorMachine), L, translator, 0, 49, 12, 7);
			
			XUtils.RegisterFunc(L, XUtils.METHOD_IDX, "IsIdle", _m_IsIdle);
			XUtils.RegisterFunc(L, XUtils.METHOD_IDX, "IsWalking", _m_IsWalking);
			XUtils.RegisterFunc(L, XUtils.METHOD_IDX, "IsAttacking", _m_IsAttacking);
			XUtils.RegisterFunc(L, XUtils.METHOD_IDX, "MoveDirInAttacking", _m_MoveDirInAttacking);
			XUtils.RegisterFunc(L, XUtils.METHOD_IDX, "AfterCreate", _m_AfterCreate);
			XUtils.RegisterFunc(L, XUtils.METHOD_IDX, "Init", _m_Init);
			XUtils.RegisterFunc(L, XUtils.METHOD_IDX, "OnResLoaded", _m_OnResLoaded);
			XUtils.RegisterFunc(L, XUtils.METHOD_IDX, "BeattackState", _m_BeattackState);
			XUtils.RegisterFunc(L, XUtils.METHOD_IDX, "EnterState_Normal", _m_EnterState_Normal);
			XUtils.RegisterFunc(L, XUtils.METHOD_IDX, "ExitState_Normal", _m_ExitState_Normal);
			XUtils.RegisterFunc(L, XUtils.METHOD_IDX, "EnterState_Attacking", _m_EnterState_Attacking);
			XUtils.RegisterFunc(L, XUtils.METHOD_IDX, "ExitState_Attacking", _m_ExitState_Attacking);
			XUtils.RegisterFunc(L, XUtils.METHOD_IDX, "UpdateState_Attacking", _m_UpdateState_Attacking);
			XUtils.RegisterFunc(L, XUtils.METHOD_IDX, "EnterState_BeAttacking", _m_EnterState_BeAttacking);
			XUtils.RegisterFunc(L, XUtils.METHOD_IDX, "ExitState_BeAttacking", _m_ExitState_BeAttacking);
			XUtils.RegisterFunc(L, XUtils.METHOD_IDX, "ForceStopFalseHitBack", _m_ForceStopFalseHitBack);
			XUtils.RegisterFunc(L, XUtils.METHOD_IDX, "InitFalseHitBack", _m_InitFalseHitBack);
			XUtils.RegisterFunc(L, XUtils.METHOD_IDX, "EnterState_Death", _m_EnterState_Death);
			XUtils.RegisterFunc(L, XUtils.METHOD_IDX, "UpdateState_Death", _m_UpdateState_Death);
			XUtils.RegisterFunc(L, XUtils.METHOD_IDX, "ExitState_Death", _m_ExitState_Death);
			XUtils.RegisterFunc(L, XUtils.METHOD_IDX, "EnterState_Idle", _m_EnterState_Idle);
			XUtils.RegisterFunc(L, XUtils.METHOD_IDX, "UpdateState_Idle", _m_UpdateState_Idle);
			XUtils.RegisterFunc(L, XUtils.METHOD_IDX, "EnterState_Walk", _m_EnterState_Walk);
			XUtils.RegisterFunc(L, XUtils.METHOD_IDX, "ExitState_Walk", _m_ExitState_Walk);
			XUtils.RegisterFunc(L, XUtils.METHOD_IDX, "UpdateState_Walk", _m_UpdateState_Walk);
			XUtils.RegisterFunc(L, XUtils.METHOD_IDX, "EnterState_Interaction", _m_EnterState_Interaction);
			XUtils.RegisterFunc(L, XUtils.METHOD_IDX, "ExitState_Interaction", _m_ExitState_Interaction);
			XUtils.RegisterFunc(L, XUtils.METHOD_IDX, "UpdateState_Interaction", _m_UpdateState_Interaction);
			XUtils.RegisterFunc(L, XUtils.METHOD_IDX, "EnterState_JumpScene", _m_EnterState_JumpScene);
			XUtils.RegisterFunc(L, XUtils.METHOD_IDX, "UpdateState_JumpScene", _m_UpdateState_JumpScene);
			XUtils.RegisterFunc(L, XUtils.METHOD_IDX, "ExitState_JumpScene", _m_ExitState_JumpScene);
			XUtils.RegisterFunc(L, XUtils.METHOD_IDX, "EnterState_NormalAttack", _m_EnterState_NormalAttack);
			XUtils.RegisterFunc(L, XUtils.METHOD_IDX, "UpdateState_NormalAttack", _m_UpdateState_NormalAttack);
			XUtils.RegisterFunc(L, XUtils.METHOD_IDX, "ExitState_NormalAttack", _m_ExitState_NormalAttack);
			XUtils.RegisterFunc(L, XUtils.METHOD_IDX, "EnterState_BeAtkBackward", _m_EnterState_BeAtkBackward);
			XUtils.RegisterFunc(L, XUtils.METHOD_IDX, "UpdateState_BeAtkBackward", _m_UpdateState_BeAtkBackward);
			XUtils.RegisterFunc(L, XUtils.METHOD_IDX, "ReachDst", _m_ReachDst);
			XUtils.RegisterFunc(L, XUtils.METHOD_IDX, "IsDead", _m_IsDead);
			XUtils.RegisterFunc(L, XUtils.METHOD_IDX, "Stop", _m_Stop);
			XUtils.RegisterFunc(L, XUtils.METHOD_IDX, "Stand", _m_Stand);
			XUtils.RegisterFunc(L, XUtils.METHOD_IDX, "WalkTo", _m_WalkTo);
			XUtils.RegisterFunc(L, XUtils.METHOD_IDX, "WalkAlong", _m_WalkAlong);
			XUtils.RegisterFunc(L, XUtils.METHOD_IDX, "Relive", _m_Relive);
			XUtils.RegisterFunc(L, XUtils.METHOD_IDX, "Update", _m_Update);
			XUtils.RegisterFunc(L, XUtils.METHOD_IDX, "Kill", _m_Kill);
			XUtils.RegisterFunc(L, XUtils.METHOD_IDX, "Destroy", _m_Destroy);
			XUtils.RegisterFunc(L, XUtils.METHOD_IDX, "BeattackBendback", _m_BeattackBendback);
			XUtils.RegisterFunc(L, XUtils.METHOD_IDX, "BeginInteraction", _m_BeginInteraction);
			XUtils.RegisterFunc(L, XUtils.METHOD_IDX, "BeginJumpScene", _m_BeginJumpScene);
			
			
			XUtils.RegisterFunc(L, XUtils.GETTER_IDX, "FSM", _g_get_FSM);
            XUtils.RegisterFunc(L, XUtils.GETTER_IDX, "InteractionAniName", _g_get_InteractionAniName);
            XUtils.RegisterFunc(L, XUtils.GETTER_IDX, "IsBeattacking", _g_get_IsBeattacking);
            XUtils.RegisterFunc(L, XUtils.GETTER_IDX, "IsInInteraction", _g_get_IsInInteraction);
            XUtils.RegisterFunc(L, XUtils.GETTER_IDX, "MoveDir", _g_get_MoveDir);
            XUtils.RegisterFunc(L, XUtils.GETTER_IDX, "WalkMode", _g_get_WalkMode);
            XUtils.RegisterFunc(L, XUtils.GETTER_IDX, "MoveSpeed", _g_get_MoveSpeed);
            XUtils.RegisterFunc(L, XUtils.GETTER_IDX, "DestList", _g_get_DestList);
            XUtils.RegisterFunc(L, XUtils.GETTER_IDX, "OnWalkToPointChange", _g_get_OnWalkToPointChange);
            XUtils.RegisterFunc(L, XUtils.GETTER_IDX, "OnReachTarget", _g_get_OnReachTarget);
            XUtils.RegisterFunc(L, XUtils.GETTER_IDX, "mkBackWardFunc", _g_get_mkBackWardFunc);
            XUtils.RegisterFunc(L, XUtils.GETTER_IDX, "PathPointList", _g_get_PathPointList);
            
			XUtils.RegisterFunc(L, XUtils.SETTER_IDX, "MoveDir", _s_set_MoveDir);
            XUtils.RegisterFunc(L, XUtils.SETTER_IDX, "MoveSpeed", _s_set_MoveSpeed);
            XUtils.RegisterFunc(L, XUtils.SETTER_IDX, "DeathFlyInfo", _s_set_DeathFlyInfo);
            XUtils.RegisterFunc(L, XUtils.SETTER_IDX, "OnWalkToPointChange", _s_set_OnWalkToPointChange);
            XUtils.RegisterFunc(L, XUtils.SETTER_IDX, "OnReachTarget", _s_set_OnReachTarget);
            XUtils.RegisterFunc(L, XUtils.SETTER_IDX, "mkBackWardFunc", _s_set_mkBackWardFunc);
            XUtils.RegisterFunc(L, XUtils.SETTER_IDX, "PathPointList", _s_set_PathPointList);
            
			XUtils.EndObjectRegister(typeof(xc.ActorMachine), L, translator, null, null,
			    null, null, null);

		    XUtils.BeginClassRegister(typeof(xc.ActorMachine), L, __CreateInstance, 1, 0, 0);
			
			
            
            XUtils.RegisterObject(L, translator, XUtils.CLS_IDX, "UnderlyingSystemType", typeof(xc.ActorMachine));
			
			
			XUtils.EndClassRegister(typeof(xc.ActorMachine), L, translator);
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int __CreateInstance(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			try {
				if(LuaAPI.lua_gettop(L) == 2 && translator.Assignable<Actor>(L, 2))
				{
					Actor owner = (Actor)translator.GetObject(L, 2, typeof(Actor));
					
					xc.ActorMachine __cl_gen_ret = new xc.ActorMachine(owner);
					translator.Push(L, __cl_gen_ret);
					return 1;
				}
				
			}
			catch(System.Exception __gen_e) {
				return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
			}
            return LuaAPI.luaL_error(L, "invalid arguments to xc.ActorMachine constructor!");
            
        }
        
		
        
		
        
        
        
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_IsIdle(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            xc.ActorMachine __cl_gen_to_be_invoked = (xc.ActorMachine)translator.FastGetCSObj(L, 1);
            
            
            try {
                
                {
                    
                        bool __cl_gen_ret = __cl_gen_to_be_invoked.IsIdle(  );
                        LuaAPI.lua_pushboolean(L, __cl_gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_IsWalking(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            xc.ActorMachine __cl_gen_to_be_invoked = (xc.ActorMachine)translator.FastGetCSObj(L, 1);
            
            
            try {
                
                {
                    
                        bool __cl_gen_ret = __cl_gen_to_be_invoked.IsWalking(  );
                        LuaAPI.lua_pushboolean(L, __cl_gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_IsAttacking(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            xc.ActorMachine __cl_gen_to_be_invoked = (xc.ActorMachine)translator.FastGetCSObj(L, 1);
            
            
            try {
                
                {
                    
                        bool __cl_gen_ret = __cl_gen_to_be_invoked.IsAttacking(  );
                        LuaAPI.lua_pushboolean(L, __cl_gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_MoveDirInAttacking(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            xc.ActorMachine __cl_gen_to_be_invoked = (xc.ActorMachine)translator.FastGetCSObj(L, 1);
            
            
            try {
                
                {
                    UnityEngine.Vector3 dir;translator.Get(L, 2, out dir);
                    
                        bool __cl_gen_ret = __cl_gen_to_be_invoked.MoveDirInAttacking( dir );
                        LuaAPI.lua_pushboolean(L, __cl_gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_AfterCreate(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            xc.ActorMachine __cl_gen_to_be_invoked = (xc.ActorMachine)translator.FastGetCSObj(L, 1);
            
            
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
        static int _m_Init(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            xc.ActorMachine __cl_gen_to_be_invoked = (xc.ActorMachine)translator.FastGetCSObj(L, 1);
            
            
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
        static int _m_OnResLoaded(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            xc.ActorMachine __cl_gen_to_be_invoked = (xc.ActorMachine)translator.FastGetCSObj(L, 1);
            
            
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
        static int _m_BeattackState(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            xc.ActorMachine __cl_gen_to_be_invoked = (xc.ActorMachine)translator.FastGetCSObj(L, 1);
            
            
            try {
                
                {
                    xc.Damage dam = (xc.Damage)translator.GetObject(L, 2, typeof(xc.Damage));
                    
                    __cl_gen_to_be_invoked.BeattackState( dam );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_EnterState_Normal(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            xc.ActorMachine __cl_gen_to_be_invoked = (xc.ActorMachine)translator.FastGetCSObj(L, 1);
            
            
            try {
                
                {
                    xc.Machine.State s = (xc.Machine.State)translator.GetObject(L, 2, typeof(xc.Machine.State));
                    
                    __cl_gen_to_be_invoked.EnterState_Normal( s );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_ExitState_Normal(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            xc.ActorMachine __cl_gen_to_be_invoked = (xc.ActorMachine)translator.FastGetCSObj(L, 1);
            
            
            try {
                
                {
                    xc.Machine.State s = (xc.Machine.State)translator.GetObject(L, 2, typeof(xc.Machine.State));
                    
                    __cl_gen_to_be_invoked.ExitState_Normal( s );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_EnterState_Attacking(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            xc.ActorMachine __cl_gen_to_be_invoked = (xc.ActorMachine)translator.FastGetCSObj(L, 1);
            
            
            try {
                
                {
                    xc.Machine.State s = (xc.Machine.State)translator.GetObject(L, 2, typeof(xc.Machine.State));
                    
                    __cl_gen_to_be_invoked.EnterState_Attacking( s );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_ExitState_Attacking(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            xc.ActorMachine __cl_gen_to_be_invoked = (xc.ActorMachine)translator.FastGetCSObj(L, 1);
            
            
            try {
                
                {
                    xc.Machine.State s = (xc.Machine.State)translator.GetObject(L, 2, typeof(xc.Machine.State));
                    
                    __cl_gen_to_be_invoked.ExitState_Attacking( s );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_UpdateState_Attacking(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            xc.ActorMachine __cl_gen_to_be_invoked = (xc.ActorMachine)translator.FastGetCSObj(L, 1);
            
            
            try {
                
                {
                    xc.Machine.State s = (xc.Machine.State)translator.GetObject(L, 2, typeof(xc.Machine.State));
                    
                    __cl_gen_to_be_invoked.UpdateState_Attacking( s );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_EnterState_BeAttacking(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            xc.ActorMachine __cl_gen_to_be_invoked = (xc.ActorMachine)translator.FastGetCSObj(L, 1);
            
            
            try {
                
                {
                    xc.Machine.State s = (xc.Machine.State)translator.GetObject(L, 2, typeof(xc.Machine.State));
                    
                    __cl_gen_to_be_invoked.EnterState_BeAttacking( s );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_ExitState_BeAttacking(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            xc.ActorMachine __cl_gen_to_be_invoked = (xc.ActorMachine)translator.FastGetCSObj(L, 1);
            
            
            try {
                
                {
                    xc.Machine.State s = (xc.Machine.State)translator.GetObject(L, 2, typeof(xc.Machine.State));
                    
                    __cl_gen_to_be_invoked.ExitState_BeAttacking( s );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_ForceStopFalseHitBack(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            xc.ActorMachine __cl_gen_to_be_invoked = (xc.ActorMachine)translator.FastGetCSObj(L, 1);
            
            
            try {
                
                {
                    
                    __cl_gen_to_be_invoked.ForceStopFalseHitBack(  );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_InitFalseHitBack(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            xc.ActorMachine __cl_gen_to_be_invoked = (xc.ActorMachine)translator.FastGetCSObj(L, 1);
            
            
            try {
                
                {
                    xc.Damage dam = (xc.Damage)translator.GetObject(L, 2, typeof(xc.Damage));
                    
                    __cl_gen_to_be_invoked.InitFalseHitBack( dam );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_EnterState_Death(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            xc.ActorMachine __cl_gen_to_be_invoked = (xc.ActorMachine)translator.FastGetCSObj(L, 1);
            
            
            try {
                
                {
                    xc.Machine.State s = (xc.Machine.State)translator.GetObject(L, 2, typeof(xc.Machine.State));
                    
                    __cl_gen_to_be_invoked.EnterState_Death( s );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_UpdateState_Death(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            xc.ActorMachine __cl_gen_to_be_invoked = (xc.ActorMachine)translator.FastGetCSObj(L, 1);
            
            
            try {
                
                {
                    xc.Machine.State s = (xc.Machine.State)translator.GetObject(L, 2, typeof(xc.Machine.State));
                    
                    __cl_gen_to_be_invoked.UpdateState_Death( s );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_ExitState_Death(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            xc.ActorMachine __cl_gen_to_be_invoked = (xc.ActorMachine)translator.FastGetCSObj(L, 1);
            
            
            try {
                
                {
                    xc.Machine.State s = (xc.Machine.State)translator.GetObject(L, 2, typeof(xc.Machine.State));
                    
                    __cl_gen_to_be_invoked.ExitState_Death( s );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_EnterState_Idle(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            xc.ActorMachine __cl_gen_to_be_invoked = (xc.ActorMachine)translator.FastGetCSObj(L, 1);
            
            
            try {
                
                {
                    xc.Machine.State s = (xc.Machine.State)translator.GetObject(L, 2, typeof(xc.Machine.State));
                    
                    __cl_gen_to_be_invoked.EnterState_Idle( s );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_UpdateState_Idle(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            xc.ActorMachine __cl_gen_to_be_invoked = (xc.ActorMachine)translator.FastGetCSObj(L, 1);
            
            
            try {
                
                {
                    xc.Machine.State s = (xc.Machine.State)translator.GetObject(L, 2, typeof(xc.Machine.State));
                    
                    __cl_gen_to_be_invoked.UpdateState_Idle( s );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_EnterState_Walk(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            xc.ActorMachine __cl_gen_to_be_invoked = (xc.ActorMachine)translator.FastGetCSObj(L, 1);
            
            
            try {
                
                {
                    xc.Machine.State s = (xc.Machine.State)translator.GetObject(L, 2, typeof(xc.Machine.State));
                    
                    __cl_gen_to_be_invoked.EnterState_Walk( s );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_ExitState_Walk(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            xc.ActorMachine __cl_gen_to_be_invoked = (xc.ActorMachine)translator.FastGetCSObj(L, 1);
            
            
            try {
                
                {
                    xc.Machine.State s = (xc.Machine.State)translator.GetObject(L, 2, typeof(xc.Machine.State));
                    
                    __cl_gen_to_be_invoked.ExitState_Walk( s );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_UpdateState_Walk(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            xc.ActorMachine __cl_gen_to_be_invoked = (xc.ActorMachine)translator.FastGetCSObj(L, 1);
            
            
            try {
                
                {
                    xc.Machine.State s = (xc.Machine.State)translator.GetObject(L, 2, typeof(xc.Machine.State));
                    
                    __cl_gen_to_be_invoked.UpdateState_Walk( s );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_EnterState_Interaction(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            xc.ActorMachine __cl_gen_to_be_invoked = (xc.ActorMachine)translator.FastGetCSObj(L, 1);
            
            
            try {
                
                {
                    xc.Machine.State s = (xc.Machine.State)translator.GetObject(L, 2, typeof(xc.Machine.State));
                    
                    __cl_gen_to_be_invoked.EnterState_Interaction( s );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_ExitState_Interaction(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            xc.ActorMachine __cl_gen_to_be_invoked = (xc.ActorMachine)translator.FastGetCSObj(L, 1);
            
            
            try {
                
                {
                    xc.Machine.State s = (xc.Machine.State)translator.GetObject(L, 2, typeof(xc.Machine.State));
                    
                    __cl_gen_to_be_invoked.ExitState_Interaction( s );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_UpdateState_Interaction(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            xc.ActorMachine __cl_gen_to_be_invoked = (xc.ActorMachine)translator.FastGetCSObj(L, 1);
            
            
            try {
                
                {
                    xc.Machine.State s = (xc.Machine.State)translator.GetObject(L, 2, typeof(xc.Machine.State));
                    
                    __cl_gen_to_be_invoked.UpdateState_Interaction( s );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_EnterState_JumpScene(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            xc.ActorMachine __cl_gen_to_be_invoked = (xc.ActorMachine)translator.FastGetCSObj(L, 1);
            
            
            try {
                
                {
                    xc.Machine.State s = (xc.Machine.State)translator.GetObject(L, 2, typeof(xc.Machine.State));
                    
                    __cl_gen_to_be_invoked.EnterState_JumpScene( s );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_UpdateState_JumpScene(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            xc.ActorMachine __cl_gen_to_be_invoked = (xc.ActorMachine)translator.FastGetCSObj(L, 1);
            
            
            try {
                
                {
                    xc.Machine.State s = (xc.Machine.State)translator.GetObject(L, 2, typeof(xc.Machine.State));
                    
                    __cl_gen_to_be_invoked.UpdateState_JumpScene( s );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_ExitState_JumpScene(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            xc.ActorMachine __cl_gen_to_be_invoked = (xc.ActorMachine)translator.FastGetCSObj(L, 1);
            
            
            try {
                
                {
                    xc.Machine.State s = (xc.Machine.State)translator.GetObject(L, 2, typeof(xc.Machine.State));
                    
                    __cl_gen_to_be_invoked.ExitState_JumpScene( s );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_EnterState_NormalAttack(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            xc.ActorMachine __cl_gen_to_be_invoked = (xc.ActorMachine)translator.FastGetCSObj(L, 1);
            
            
            try {
                
                {
                    xc.Machine.State s = (xc.Machine.State)translator.GetObject(L, 2, typeof(xc.Machine.State));
                    
                    __cl_gen_to_be_invoked.EnterState_NormalAttack( s );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_UpdateState_NormalAttack(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            xc.ActorMachine __cl_gen_to_be_invoked = (xc.ActorMachine)translator.FastGetCSObj(L, 1);
            
            
            try {
                
                {
                    xc.Machine.State s = (xc.Machine.State)translator.GetObject(L, 2, typeof(xc.Machine.State));
                    
                    __cl_gen_to_be_invoked.UpdateState_NormalAttack( s );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_ExitState_NormalAttack(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            xc.ActorMachine __cl_gen_to_be_invoked = (xc.ActorMachine)translator.FastGetCSObj(L, 1);
            
            
            try {
                
                {
                    xc.Machine.State s = (xc.Machine.State)translator.GetObject(L, 2, typeof(xc.Machine.State));
                    
                    __cl_gen_to_be_invoked.ExitState_NormalAttack( s );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_EnterState_BeAtkBackward(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            xc.ActorMachine __cl_gen_to_be_invoked = (xc.ActorMachine)translator.FastGetCSObj(L, 1);
            
            
            try {
                
                {
                    xc.Machine.State s = (xc.Machine.State)translator.GetObject(L, 2, typeof(xc.Machine.State));
                    
                    __cl_gen_to_be_invoked.EnterState_BeAtkBackward( s );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_UpdateState_BeAtkBackward(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            xc.ActorMachine __cl_gen_to_be_invoked = (xc.ActorMachine)translator.FastGetCSObj(L, 1);
            
            
            try {
                
                {
                    xc.Machine.State s = (xc.Machine.State)translator.GetObject(L, 2, typeof(xc.Machine.State));
                    
                    __cl_gen_to_be_invoked.UpdateState_BeAtkBackward( s );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_ReachDst(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            xc.ActorMachine __cl_gen_to_be_invoked = (xc.ActorMachine)translator.FastGetCSObj(L, 1);
            
            
            try {
                
                {
                    
                        bool __cl_gen_ret = __cl_gen_to_be_invoked.ReachDst(  );
                        LuaAPI.lua_pushboolean(L, __cl_gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_IsDead(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            xc.ActorMachine __cl_gen_to_be_invoked = (xc.ActorMachine)translator.FastGetCSObj(L, 1);
            
            
            try {
                
                {
                    
                        bool __cl_gen_ret = __cl_gen_to_be_invoked.IsDead(  );
                        LuaAPI.lua_pushboolean(L, __cl_gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_Stop(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            xc.ActorMachine __cl_gen_to_be_invoked = (xc.ActorMachine)translator.FastGetCSObj(L, 1);
            
            
            try {
                
                {
                    
                        bool __cl_gen_ret = __cl_gen_to_be_invoked.Stop(  );
                        LuaAPI.lua_pushboolean(L, __cl_gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_Stand(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            xc.ActorMachine __cl_gen_to_be_invoked = (xc.ActorMachine)translator.FastGetCSObj(L, 1);
            
            
            try {
                
                {
                    
                        bool __cl_gen_ret = __cl_gen_to_be_invoked.Stand(  );
                        LuaAPI.lua_pushboolean(L, __cl_gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_WalkTo(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            xc.ActorMachine __cl_gen_to_be_invoked = (xc.ActorMachine)translator.FastGetCSObj(L, 1);
            
            
            try {
                
                {
                    UnityEngine.Vector3 dst;translator.Get(L, 2, out dst);
                    
                        bool __cl_gen_ret = __cl_gen_to_be_invoked.WalkTo( dst );
                        LuaAPI.lua_pushboolean(L, __cl_gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_WalkAlong(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            xc.ActorMachine __cl_gen_to_be_invoked = (xc.ActorMachine)translator.FastGetCSObj(L, 1);
            
            
            try {
                
                {
                    UnityEngine.Vector3 dir;translator.Get(L, 2, out dir);
                    
                        bool __cl_gen_ret = __cl_gen_to_be_invoked.WalkAlong( dir );
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
            
            
            xc.ActorMachine __cl_gen_to_be_invoked = (xc.ActorMachine)translator.FastGetCSObj(L, 1);
            
            
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
        static int _m_Update(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            xc.ActorMachine __cl_gen_to_be_invoked = (xc.ActorMachine)translator.FastGetCSObj(L, 1);
            
            
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
        static int _m_Kill(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            xc.ActorMachine __cl_gen_to_be_invoked = (xc.ActorMachine)translator.FastGetCSObj(L, 1);
            
            
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
        static int _m_Destroy(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            xc.ActorMachine __cl_gen_to_be_invoked = (xc.ActorMachine)translator.FastGetCSObj(L, 1);
            
            
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
        static int _m_BeattackBendback(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            xc.ActorMachine __cl_gen_to_be_invoked = (xc.ActorMachine)translator.FastGetCSObj(L, 1);
            
            
            try {
                
                {
                    
                    __cl_gen_to_be_invoked.BeattackBendback(  );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_BeginInteraction(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            xc.ActorMachine __cl_gen_to_be_invoked = (xc.ActorMachine)translator.FastGetCSObj(L, 1);
            
            
            try {
                
                {
                    string aniName = LuaAPI.lua_tostring(L, 2);
                    
                        bool __cl_gen_ret = __cl_gen_to_be_invoked.BeginInteraction( aniName );
                        LuaAPI.lua_pushboolean(L, __cl_gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_BeginJumpScene(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            xc.ActorMachine __cl_gen_to_be_invoked = (xc.ActorMachine)translator.FastGetCSObj(L, 1);
            
            
            try {
                
                {
                    string ani_name = LuaAPI.lua_tostring(L, 2);
                    
                        bool __cl_gen_ret = __cl_gen_to_be_invoked.BeginJumpScene( ani_name );
                        LuaAPI.lua_pushboolean(L, __cl_gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        
        
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_FSM(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.ActorMachine __cl_gen_to_be_invoked = (xc.ActorMachine)translator.FastGetCSObj(L, 1);
                translator.Push(L, __cl_gen_to_be_invoked.FSM);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_InteractionAniName(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.ActorMachine __cl_gen_to_be_invoked = (xc.ActorMachine)translator.FastGetCSObj(L, 1);
                LuaAPI.lua_pushstring(L, __cl_gen_to_be_invoked.InteractionAniName);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_IsBeattacking(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.ActorMachine __cl_gen_to_be_invoked = (xc.ActorMachine)translator.FastGetCSObj(L, 1);
                LuaAPI.lua_pushboolean(L, __cl_gen_to_be_invoked.IsBeattacking);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_IsInInteraction(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.ActorMachine __cl_gen_to_be_invoked = (xc.ActorMachine)translator.FastGetCSObj(L, 1);
                LuaAPI.lua_pushboolean(L, __cl_gen_to_be_invoked.IsInInteraction);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_MoveDir(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.ActorMachine __cl_gen_to_be_invoked = (xc.ActorMachine)translator.FastGetCSObj(L, 1);
                translator.PushUnityEngineVector3(L, __cl_gen_to_be_invoked.MoveDir);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_WalkMode(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.ActorMachine __cl_gen_to_be_invoked = (xc.ActorMachine)translator.FastGetCSObj(L, 1);
                translator.PushxcActorMachineEWalkMode(L, __cl_gen_to_be_invoked.WalkMode);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_MoveSpeed(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.ActorMachine __cl_gen_to_be_invoked = (xc.ActorMachine)translator.FastGetCSObj(L, 1);
                LuaAPI.lua_pushnumber(L, __cl_gen_to_be_invoked.MoveSpeed);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_DestList(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.ActorMachine __cl_gen_to_be_invoked = (xc.ActorMachine)translator.FastGetCSObj(L, 1);
                translator.Push(L, __cl_gen_to_be_invoked.DestList);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_OnWalkToPointChange(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.ActorMachine __cl_gen_to_be_invoked = (xc.ActorMachine)translator.FastGetCSObj(L, 1);
                translator.Push(L, __cl_gen_to_be_invoked.OnWalkToPointChange);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_OnReachTarget(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.ActorMachine __cl_gen_to_be_invoked = (xc.ActorMachine)translator.FastGetCSObj(L, 1);
                translator.Push(L, __cl_gen_to_be_invoked.OnReachTarget);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_mkBackWardFunc(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.ActorMachine __cl_gen_to_be_invoked = (xc.ActorMachine)translator.FastGetCSObj(L, 1);
                translator.Push(L, __cl_gen_to_be_invoked.mkBackWardFunc);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_PathPointList(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.ActorMachine __cl_gen_to_be_invoked = (xc.ActorMachine)translator.FastGetCSObj(L, 1);
                translator.Push(L, __cl_gen_to_be_invoked.PathPointList);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_MoveDir(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.ActorMachine __cl_gen_to_be_invoked = (xc.ActorMachine)translator.FastGetCSObj(L, 1);
                UnityEngine.Vector3 __cl_gen_value;translator.Get(L, 2, out __cl_gen_value);
				__cl_gen_to_be_invoked.MoveDir = __cl_gen_value;
            
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_MoveSpeed(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.ActorMachine __cl_gen_to_be_invoked = (xc.ActorMachine)translator.FastGetCSObj(L, 1);
                __cl_gen_to_be_invoked.MoveSpeed = (float)LuaAPI.lua_tonumber(L, 2);
            
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_DeathFlyInfo(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.ActorMachine __cl_gen_to_be_invoked = (xc.ActorMachine)translator.FastGetCSObj(L, 1);
                __cl_gen_to_be_invoked.DeathFlyInfo = (xc.ActorMachine.DeathInfo)translator.GetObject(L, 2, typeof(xc.ActorMachine.DeathInfo));
            
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_OnWalkToPointChange(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.ActorMachine __cl_gen_to_be_invoked = (xc.ActorMachine)translator.FastGetCSObj(L, 1);
                __cl_gen_to_be_invoked.OnWalkToPointChange = translator.GetDelegate<xc.ActorMachine.WalkToPointChange>(L, 2);
            
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_OnReachTarget(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.ActorMachine __cl_gen_to_be_invoked = (xc.ActorMachine)translator.FastGetCSObj(L, 1);
                __cl_gen_to_be_invoked.OnReachTarget = translator.GetDelegate<xc.ActorMachine.ReachTarget>(L, 2);
            
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_mkBackWardFunc(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.ActorMachine __cl_gen_to_be_invoked = (xc.ActorMachine)translator.FastGetCSObj(L, 1);
                __cl_gen_to_be_invoked.mkBackWardFunc = translator.GetDelegate<xc.ActorMachine.UpdateFunc>(L, 2);
            
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_PathPointList(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.ActorMachine __cl_gen_to_be_invoked = (xc.ActorMachine)translator.FastGetCSObj(L, 1);
                __cl_gen_to_be_invoked.PathPointList = (System.Collections.Generic.List<UnityEngine.Vector3>)translator.GetObject(L, 2, typeof(System.Collections.Generic.List<UnityEngine.Vector3>));
            
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 0;
        }
        
		
		
		
		
    }
}
