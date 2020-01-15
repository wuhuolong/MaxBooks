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
    public class xcTargetPathManagerWrap
    {
        public static void __Register(RealStatePtr L)
        {
			ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			XUtils.BeginObjectRegister(typeof(xc.TargetPathManager), L, translator, 0, 21, 8, 2);
			
			XUtils.RegisterFunc(L, XUtils.METHOD_IDX, "OnPlayerControled", _m_OnPlayerControled);
			XUtils.RegisterFunc(L, XUtils.METHOD_IDX, "OnStartSwitchScene", _m_OnStartSwitchScene);
			XUtils.RegisterFunc(L, XUtils.METHOD_IDX, "Reset", _m_Reset);
			XUtils.RegisterFunc(L, XUtils.METHOD_IDX, "StopPlayerAndReset", _m_StopPlayerAndReset);
			XUtils.RegisterFunc(L, XUtils.METHOD_IDX, "TaskNavigationActive", _m_TaskNavigationActive);
			XUtils.RegisterFunc(L, XUtils.METHOD_IDX, "LocalPlayerWalkToDestination", _m_LocalPlayerWalkToDestination);
			XUtils.RegisterFunc(L, XUtils.METHOD_IDX, "NotifyLastPathNodeReached", _m_NotifyLastPathNodeReached);
			XUtils.RegisterFunc(L, XUtils.METHOD_IDX, "Update", _m_Update);
			XUtils.RegisterFunc(L, XUtils.METHOD_IDX, "ClearAllTargetPathNodes", _m_ClearAllTargetPathNodes);
			XUtils.RegisterFunc(L, XUtils.METHOD_IDX, "NotifyMetNpc", _m_NotifyMetNpc);
			XUtils.RegisterFunc(L, XUtils.METHOD_IDX, "NotifyMetTrigger", _m_NotifyMetTrigger);
			XUtils.RegisterFunc(L, XUtils.METHOD_IDX, "NotifyMetMonster", _m_NotifyMetMonster);
			XUtils.RegisterFunc(L, XUtils.METHOD_IDX, "NotifyMetTag", _m_NotifyMetTag);
			XUtils.RegisterFunc(L, XUtils.METHOD_IDX, "GoToConstPosition", _m_GoToConstPosition);
			XUtils.RegisterFunc(L, XUtils.METHOD_IDX, "GoToInstance", _m_GoToInstance);
			XUtils.RegisterFunc(L, XUtils.METHOD_IDX, "GoToMonsterPos", _m_GoToMonsterPos);
			XUtils.RegisterFunc(L, XUtils.METHOD_IDX, "GoToMap", _m_GoToMap);
			XUtils.RegisterFunc(L, XUtils.METHOD_IDX, "GoToNpcPos", _m_GoToNpcPos);
			XUtils.RegisterFunc(L, XUtils.METHOD_IDX, "GoToTagPos", _m_GoToTagPos);
			XUtils.RegisterFunc(L, XUtils.METHOD_IDX, "SetIsFirstNavigatingJumpToScene", _m_SetIsFirstNavigatingJumpToScene);
			XUtils.RegisterFunc(L, XUtils.METHOD_IDX, "JumpToScene", _m_JumpToScene);
			
			
			XUtils.RegisterFunc(L, XUtils.GETTER_IDX, "Counter", _g_get_Counter);
            XUtils.RegisterFunc(L, XUtils.GETTER_IDX, "TargetPos", _g_get_TargetPos);
            XUtils.RegisterFunc(L, XUtils.GETTER_IDX, "TargetPathNodes", _g_get_TargetPathNodes);
            XUtils.RegisterFunc(L, XUtils.GETTER_IDX, "PathWalker", _g_get_PathWalker);
            XUtils.RegisterFunc(L, XUtils.GETTER_IDX, "IsNavigating", _g_get_IsNavigating);
            XUtils.RegisterFunc(L, XUtils.GETTER_IDX, "RunningTargetPathNode", _g_get_RunningTargetPathNode);
            XUtils.RegisterFunc(L, XUtils.GETTER_IDX, "CurrentSceneTargetPathNode", _g_get_CurrentSceneTargetPathNode);
            XUtils.RegisterFunc(L, XUtils.GETTER_IDX, "IsFirstNavigatingJumpToScene", _g_get_IsFirstNavigatingJumpToScene);
            
			XUtils.RegisterFunc(L, XUtils.SETTER_IDX, "IsNavigating", _s_set_IsNavigating);
            XUtils.RegisterFunc(L, XUtils.SETTER_IDX, "RunningTargetPathNode", _s_set_RunningTargetPathNode);
            
			XUtils.EndObjectRegister(typeof(xc.TargetPathManager), L, translator, null, null,
			    null, null, null);

		    XUtils.BeginClassRegister(typeof(xc.TargetPathManager), L, __CreateInstance, 1, 0, 0);
			
			
            
            XUtils.RegisterObject(L, translator, XUtils.CLS_IDX, "UnderlyingSystemType", typeof(xc.TargetPathManager));
			
			
			XUtils.EndClassRegister(typeof(xc.TargetPathManager), L, translator);
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int __CreateInstance(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			try {
				if(LuaAPI.lua_gettop(L) == 1)
				{
					
					xc.TargetPathManager __cl_gen_ret = new xc.TargetPathManager();
					translator.Push(L, __cl_gen_ret);
					return 1;
				}
				
			}
			catch(System.Exception __gen_e) {
				return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
			}
            return LuaAPI.luaL_error(L, "invalid arguments to xc.TargetPathManager constructor!");
            
        }
        
		
        
		
        
        
        
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_OnPlayerControled(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            xc.TargetPathManager __cl_gen_to_be_invoked = (xc.TargetPathManager)translator.FastGetCSObj(L, 1);
            
            
            try {
                
                {
                    CEventBaseArgs data = (CEventBaseArgs)translator.GetObject(L, 2, typeof(CEventBaseArgs));
                    
                    __cl_gen_to_be_invoked.OnPlayerControled( data );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_OnStartSwitchScene(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            xc.TargetPathManager __cl_gen_to_be_invoked = (xc.TargetPathManager)translator.FastGetCSObj(L, 1);
            
            
            try {
                
                {
                    CEventBaseArgs data = (CEventBaseArgs)translator.GetObject(L, 2, typeof(CEventBaseArgs));
                    
                    __cl_gen_to_be_invoked.OnStartSwitchScene( data );
                    
                    
                    
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
            
            
            xc.TargetPathManager __cl_gen_to_be_invoked = (xc.TargetPathManager)translator.FastGetCSObj(L, 1);
            
            
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
        static int _m_StopPlayerAndReset(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            xc.TargetPathManager __cl_gen_to_be_invoked = (xc.TargetPathManager)translator.FastGetCSObj(L, 1);
            
            
			int __gen_param_count = LuaAPI.lua_gettop(L);
            
            try {
                if(__gen_param_count == 3&& LuaTypes.LUA_TBOOLEAN == LuaAPI.lua_type(L, 2)&& LuaTypes.LUA_TBOOLEAN == LuaAPI.lua_type(L, 3)) 
                {
                    bool setAutoFightingFalse = LuaAPI.lua_toboolean(L, 2);
                    bool isStopLocalPlayer = LuaAPI.lua_toboolean(L, 3);
                    
                    __cl_gen_to_be_invoked.StopPlayerAndReset( setAutoFightingFalse, isStopLocalPlayer );
                    
                    
                    
                    return 0;
                }
                if(__gen_param_count == 2&& LuaTypes.LUA_TBOOLEAN == LuaAPI.lua_type(L, 2)) 
                {
                    bool setAutoFightingFalse = LuaAPI.lua_toboolean(L, 2);
                    
                    __cl_gen_to_be_invoked.StopPlayerAndReset( setAutoFightingFalse );
                    
                    
                    
                    return 0;
                }
                if(__gen_param_count == 1) 
                {
                    
                    __cl_gen_to_be_invoked.StopPlayerAndReset(  );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
            return LuaAPI.luaL_error(L, "invalid arguments to xc.TargetPathManager.StopPlayerAndReset!");
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_TaskNavigationActive(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            xc.TargetPathManager __cl_gen_to_be_invoked = (xc.TargetPathManager)translator.FastGetCSObj(L, 1);
            
            
            try {
                
                {
                    bool active = LuaAPI.lua_toboolean(L, 2);
                    
                    __cl_gen_to_be_invoked.TaskNavigationActive( active );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_LocalPlayerWalkToDestination(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            xc.TargetPathManager __cl_gen_to_be_invoked = (xc.TargetPathManager)translator.FastGetCSObj(L, 1);
            
            
			int __gen_param_count = LuaAPI.lua_gettop(L);
            
            try {
                if(__gen_param_count == 3&& translator.Assignable<UnityEngine.Vector3>(L, 2)&& translator.Assignable<xc.Task>(L, 3)) 
                {
                    UnityEngine.Vector3 targetPos;translator.Get(L, 2, out targetPos);
                    xc.Task relateTask = (xc.Task)translator.GetObject(L, 3, typeof(xc.Task));
                    
                    __cl_gen_to_be_invoked.LocalPlayerWalkToDestination( targetPos, relateTask );
                    
                    
                    
                    return 0;
                }
                if(__gen_param_count == 2&& translator.Assignable<UnityEngine.Vector3>(L, 2)) 
                {
                    UnityEngine.Vector3 targetPos;translator.Get(L, 2, out targetPos);
                    
                    __cl_gen_to_be_invoked.LocalPlayerWalkToDestination( targetPos );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
            return LuaAPI.luaL_error(L, "invalid arguments to xc.TargetPathManager.LocalPlayerWalkToDestination!");
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_NotifyLastPathNodeReached(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            xc.TargetPathManager __cl_gen_to_be_invoked = (xc.TargetPathManager)translator.FastGetCSObj(L, 1);
            
            
            try {
                
                {
                    
                    __cl_gen_to_be_invoked.NotifyLastPathNodeReached(  );
                    
                    
                    
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
            
            
            xc.TargetPathManager __cl_gen_to_be_invoked = (xc.TargetPathManager)translator.FastGetCSObj(L, 1);
            
            
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
        static int _m_ClearAllTargetPathNodes(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            xc.TargetPathManager __cl_gen_to_be_invoked = (xc.TargetPathManager)translator.FastGetCSObj(L, 1);
            
            
            try {
                
                {
                    
                    __cl_gen_to_be_invoked.ClearAllTargetPathNodes(  );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_NotifyMetNpc(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            xc.TargetPathManager __cl_gen_to_be_invoked = (xc.TargetPathManager)translator.FastGetCSObj(L, 1);
            
            
            try {
                
                {
                    uint npcId = LuaAPI.xlua_touint(L, 2);
                    
                        bool __cl_gen_ret = __cl_gen_to_be_invoked.NotifyMetNpc( npcId );
                        LuaAPI.lua_pushboolean(L, __cl_gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_NotifyMetTrigger(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            xc.TargetPathManager __cl_gen_to_be_invoked = (xc.TargetPathManager)translator.FastGetCSObj(L, 1);
            
            
            try {
                
                {
                    uint triggerId = LuaAPI.xlua_touint(L, 2);
                    
                    __cl_gen_to_be_invoked.NotifyMetTrigger( triggerId );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_NotifyMetMonster(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            xc.TargetPathManager __cl_gen_to_be_invoked = (xc.TargetPathManager)translator.FastGetCSObj(L, 1);
            
            
            try {
                
                {
                    uint monsterId = LuaAPI.xlua_touint(L, 2);
                    
                    __cl_gen_to_be_invoked.NotifyMetMonster( monsterId );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_NotifyMetTag(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            xc.TargetPathManager __cl_gen_to_be_invoked = (xc.TargetPathManager)translator.FastGetCSObj(L, 1);
            
            
            try {
                
                {
                    uint tagId = LuaAPI.xlua_touint(L, 2);
                    
                    __cl_gen_to_be_invoked.NotifyMetTag( tagId );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_GoToConstPosition(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            xc.TargetPathManager __cl_gen_to_be_invoked = (xc.TargetPathManager)translator.FastGetCSObj(L, 1);
            
            
			int __gen_param_count = LuaAPI.lua_gettop(L);
            
            try {
                if(__gen_param_count == 2&& translator.Assignable<UnityEngine.Vector3>(L, 2)) 
                {
                    UnityEngine.Vector3 pos;translator.Get(L, 2, out pos);
                    
                        bool __cl_gen_ret = __cl_gen_to_be_invoked.GoToConstPosition( pos );
                        LuaAPI.lua_pushboolean(L, __cl_gen_ret);
                    
                    
                    
                    return 1;
                }
                if(__gen_param_count == 4&& LuaTypes.LUA_TNUMBER == LuaAPI.lua_type(L, 2)&& LuaTypes.LUA_TNUMBER == LuaAPI.lua_type(L, 3)&& translator.Assignable<UnityEngine.Vector3>(L, 4)) 
                {
                    uint mapId = LuaAPI.xlua_touint(L, 2);
                    uint line = LuaAPI.xlua_touint(L, 3);
                    UnityEngine.Vector3 pos;translator.Get(L, 4, out pos);
                    
                        bool __cl_gen_ret = __cl_gen_to_be_invoked.GoToConstPosition( mapId, line, pos );
                        LuaAPI.lua_pushboolean(L, __cl_gen_ret);
                    
                    
                    
                    return 1;
                }
                if(__gen_param_count == 5&& LuaTypes.LUA_TNUMBER == LuaAPI.lua_type(L, 2)&& LuaTypes.LUA_TNUMBER == LuaAPI.lua_type(L, 3)&& translator.Assignable<UnityEngine.Vector3>(L, 4)&& translator.Assignable<xc.Task>(L, 5)) 
                {
                    uint mapId = LuaAPI.xlua_touint(L, 2);
                    uint line = LuaAPI.xlua_touint(L, 3);
                    UnityEngine.Vector3 pos;translator.Get(L, 4, out pos);
                    xc.Task relateTask = (xc.Task)translator.GetObject(L, 5, typeof(xc.Task));
                    
                        bool __cl_gen_ret = __cl_gen_to_be_invoked.GoToConstPosition( mapId, line, pos, relateTask );
                        LuaAPI.lua_pushboolean(L, __cl_gen_ret);
                    
                    
                    
                    return 1;
                }
                if(__gen_param_count == 6&& LuaTypes.LUA_TNUMBER == LuaAPI.lua_type(L, 2)&& LuaTypes.LUA_TNUMBER == LuaAPI.lua_type(L, 3)&& translator.Assignable<UnityEngine.Vector3>(L, 4)&& translator.Assignable<xc.Task>(L, 5)&& translator.Assignable<System.Action>(L, 6)) 
                {
                    uint mapId = LuaAPI.xlua_touint(L, 2);
                    uint line = LuaAPI.xlua_touint(L, 3);
                    UnityEngine.Vector3 pos;translator.Get(L, 4, out pos);
                    xc.Task relateTask = (xc.Task)translator.GetObject(L, 5, typeof(xc.Task));
                    System.Action finishedCallback = translator.GetDelegate<System.Action>(L, 6);
                    
                        bool __cl_gen_ret = __cl_gen_to_be_invoked.GoToConstPosition( mapId, line, pos, relateTask, finishedCallback );
                        LuaAPI.lua_pushboolean(L, __cl_gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
            return LuaAPI.luaL_error(L, "invalid arguments to xc.TargetPathManager.GoToConstPosition!");
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_GoToInstance(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            xc.TargetPathManager __cl_gen_to_be_invoked = (xc.TargetPathManager)translator.FastGetCSObj(L, 1);
            
            
            try {
                
                {
                    uint entranceMapId = LuaAPI.xlua_touint(L, 2);
                    uint instanceId = LuaAPI.xlua_touint(L, 3);
                    xc.Task relateTask = (xc.Task)translator.GetObject(L, 4, typeof(xc.Task));
                    
                        bool __cl_gen_ret = __cl_gen_to_be_invoked.GoToInstance( entranceMapId, instanceId, relateTask );
                        LuaAPI.lua_pushboolean(L, __cl_gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_GoToMonsterPos(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            xc.TargetPathManager __cl_gen_to_be_invoked = (xc.TargetPathManager)translator.FastGetCSObj(L, 1);
            
            
			int __gen_param_count = LuaAPI.lua_gettop(L);
            
            try {
                if(__gen_param_count == 4&& LuaTypes.LUA_TNUMBER == LuaAPI.lua_type(L, 2)&& LuaTypes.LUA_TNUMBER == LuaAPI.lua_type(L, 3)&& translator.Assignable<xc.Task>(L, 4)) 
                {
                    uint mapId = LuaAPI.xlua_touint(L, 2);
                    uint monsterId = LuaAPI.xlua_touint(L, 3);
                    xc.Task relateTask = (xc.Task)translator.GetObject(L, 4, typeof(xc.Task));
                    
                        bool __cl_gen_ret = __cl_gen_to_be_invoked.GoToMonsterPos( mapId, monsterId, relateTask );
                        LuaAPI.lua_pushboolean(L, __cl_gen_ret);
                    
                    
                    
                    return 1;
                }
                if(__gen_param_count == 5&& LuaTypes.LUA_TNUMBER == LuaAPI.lua_type(L, 2)&& LuaTypes.LUA_TNUMBER == LuaAPI.lua_type(L, 3)&& LuaTypes.LUA_TNUMBER == LuaAPI.lua_type(L, 4)&& translator.Assignable<xc.Task>(L, 5)) 
                {
                    uint mapId = LuaAPI.xlua_touint(L, 2);
                    uint instanceId = LuaAPI.xlua_touint(L, 3);
                    uint monsterId = LuaAPI.xlua_touint(L, 4);
                    xc.Task relateTask = (xc.Task)translator.GetObject(L, 5, typeof(xc.Task));
                    
                        bool __cl_gen_ret = __cl_gen_to_be_invoked.GoToMonsterPos( mapId, instanceId, monsterId, relateTask );
                        LuaAPI.lua_pushboolean(L, __cl_gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
            return LuaAPI.luaL_error(L, "invalid arguments to xc.TargetPathManager.GoToMonsterPos!");
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_GoToMap(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            xc.TargetPathManager __cl_gen_to_be_invoked = (xc.TargetPathManager)translator.FastGetCSObj(L, 1);
            
            
            try {
                
                {
                    uint mapId = LuaAPI.xlua_touint(L, 2);
                    
                        bool __cl_gen_ret = __cl_gen_to_be_invoked.GoToMap( mapId );
                        LuaAPI.lua_pushboolean(L, __cl_gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_GoToNpcPos(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            xc.TargetPathManager __cl_gen_to_be_invoked = (xc.TargetPathManager)translator.FastGetCSObj(L, 1);
            
            
			int __gen_param_count = LuaAPI.lua_gettop(L);
            
            try {
                if(__gen_param_count == 5&& LuaTypes.LUA_TNUMBER == LuaAPI.lua_type(L, 2)&& LuaTypes.LUA_TNUMBER == LuaAPI.lua_type(L, 3)&& translator.Assignable<xc.Task>(L, 4)&& LuaTypes.LUA_TNUMBER == LuaAPI.lua_type(L, 5)) 
                {
                    uint mapId = LuaAPI.xlua_touint(L, 2);
                    uint npcId = LuaAPI.xlua_touint(L, 3);
                    xc.Task relateTask = (xc.Task)translator.GetObject(L, 4, typeof(xc.Task));
                    uint npcExcelId = LuaAPI.xlua_touint(L, 5);
                    
                        bool __cl_gen_ret = __cl_gen_to_be_invoked.GoToNpcPos( mapId, npcId, relateTask, npcExcelId );
                        LuaAPI.lua_pushboolean(L, __cl_gen_ret);
                    
                    
                    
                    return 1;
                }
                if(__gen_param_count == 4&& LuaTypes.LUA_TNUMBER == LuaAPI.lua_type(L, 2)&& LuaTypes.LUA_TNUMBER == LuaAPI.lua_type(L, 3)&& translator.Assignable<xc.Task>(L, 4)) 
                {
                    uint mapId = LuaAPI.xlua_touint(L, 2);
                    uint npcId = LuaAPI.xlua_touint(L, 3);
                    xc.Task relateTask = (xc.Task)translator.GetObject(L, 4, typeof(xc.Task));
                    
                        bool __cl_gen_ret = __cl_gen_to_be_invoked.GoToNpcPos( mapId, npcId, relateTask );
                        LuaAPI.lua_pushboolean(L, __cl_gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
            return LuaAPI.luaL_error(L, "invalid arguments to xc.TargetPathManager.GoToNpcPos!");
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_GoToTagPos(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            xc.TargetPathManager __cl_gen_to_be_invoked = (xc.TargetPathManager)translator.FastGetCSObj(L, 1);
            
            
			int __gen_param_count = LuaAPI.lua_gettop(L);
            
            try {
                if(__gen_param_count == 5&& LuaTypes.LUA_TNUMBER == LuaAPI.lua_type(L, 2)&& LuaTypes.LUA_TNUMBER == LuaAPI.lua_type(L, 3)&& translator.Assignable<xc.Task>(L, 4)&& translator.Assignable<System.Action>(L, 5)) 
                {
                    uint mapId = LuaAPI.xlua_touint(L, 2);
                    uint tagId = LuaAPI.xlua_touint(L, 3);
                    xc.Task relateTask = (xc.Task)translator.GetObject(L, 4, typeof(xc.Task));
                    System.Action finishedCallback = translator.GetDelegate<System.Action>(L, 5);
                    
                        bool __cl_gen_ret = __cl_gen_to_be_invoked.GoToTagPos( mapId, tagId, relateTask, finishedCallback );
                        LuaAPI.lua_pushboolean(L, __cl_gen_ret);
                    
                    
                    
                    return 1;
                }
                if(__gen_param_count == 4&& LuaTypes.LUA_TNUMBER == LuaAPI.lua_type(L, 2)&& LuaTypes.LUA_TNUMBER == LuaAPI.lua_type(L, 3)&& translator.Assignable<xc.Task>(L, 4)) 
                {
                    uint mapId = LuaAPI.xlua_touint(L, 2);
                    uint tagId = LuaAPI.xlua_touint(L, 3);
                    xc.Task relateTask = (xc.Task)translator.GetObject(L, 4, typeof(xc.Task));
                    
                        bool __cl_gen_ret = __cl_gen_to_be_invoked.GoToTagPos( mapId, tagId, relateTask );
                        LuaAPI.lua_pushboolean(L, __cl_gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
            return LuaAPI.luaL_error(L, "invalid arguments to xc.TargetPathManager.GoToTagPos!");
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_SetIsFirstNavigatingJumpToScene(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            xc.TargetPathManager __cl_gen_to_be_invoked = (xc.TargetPathManager)translator.FastGetCSObj(L, 1);
            
            
            try {
                
                {
                    bool isFirst = LuaAPI.lua_toboolean(L, 2);
                    
                    __cl_gen_to_be_invoked.SetIsFirstNavigatingJumpToScene( isFirst );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_JumpToScene(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            xc.TargetPathManager __cl_gen_to_be_invoked = (xc.TargetPathManager)translator.FastGetCSObj(L, 1);
            
            
			int __gen_param_count = LuaAPI.lua_gettop(L);
            
            try {
                if(__gen_param_count == 5&& LuaTypes.LUA_TBOOLEAN == LuaAPI.lua_type(L, 2)&& LuaTypes.LUA_TNUMBER == LuaAPI.lua_type(L, 3)&& LuaTypes.LUA_TNUMBER == LuaAPI.lua_type(L, 4)&& translator.Assignable<xc.Task>(L, 5)) 
                {
                    bool check = LuaAPI.lua_toboolean(L, 2);
                    uint id = LuaAPI.xlua_touint(L, 3);
                    uint line = LuaAPI.xlua_touint(L, 4);
                    xc.Task relateTask = (xc.Task)translator.GetObject(L, 5, typeof(xc.Task));
                    
                    __cl_gen_to_be_invoked.JumpToScene( check, id, line, relateTask );
                    
                    
                    
                    return 0;
                }
                if(__gen_param_count == 4&& LuaTypes.LUA_TBOOLEAN == LuaAPI.lua_type(L, 2)&& LuaTypes.LUA_TNUMBER == LuaAPI.lua_type(L, 3)&& LuaTypes.LUA_TNUMBER == LuaAPI.lua_type(L, 4)) 
                {
                    bool check = LuaAPI.lua_toboolean(L, 2);
                    uint id = LuaAPI.xlua_touint(L, 3);
                    uint line = LuaAPI.xlua_touint(L, 4);
                    
                    __cl_gen_to_be_invoked.JumpToScene( check, id, line );
                    
                    
                    
                    return 0;
                }
                if(__gen_param_count == 3&& LuaTypes.LUA_TBOOLEAN == LuaAPI.lua_type(L, 2)&& LuaTypes.LUA_TNUMBER == LuaAPI.lua_type(L, 3)) 
                {
                    bool check = LuaAPI.lua_toboolean(L, 2);
                    uint id = LuaAPI.xlua_touint(L, 3);
                    
                    __cl_gen_to_be_invoked.JumpToScene( check, id );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
            return LuaAPI.luaL_error(L, "invalid arguments to xc.TargetPathManager.JumpToScene!");
            
        }
        
        
        
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_Counter(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.TargetPathManager __cl_gen_to_be_invoked = (xc.TargetPathManager)translator.FastGetCSObj(L, 1);
                LuaAPI.xlua_pushuint(L, __cl_gen_to_be_invoked.Counter);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_TargetPos(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.TargetPathManager __cl_gen_to_be_invoked = (xc.TargetPathManager)translator.FastGetCSObj(L, 1);
                translator.PushUnityEngineVector3(L, __cl_gen_to_be_invoked.TargetPos);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_TargetPathNodes(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.TargetPathManager __cl_gen_to_be_invoked = (xc.TargetPathManager)translator.FastGetCSObj(L, 1);
                translator.Push(L, __cl_gen_to_be_invoked.TargetPathNodes);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_PathWalker(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.TargetPathManager __cl_gen_to_be_invoked = (xc.TargetPathManager)translator.FastGetCSObj(L, 1);
                translator.Push(L, __cl_gen_to_be_invoked.PathWalker);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_IsNavigating(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.TargetPathManager __cl_gen_to_be_invoked = (xc.TargetPathManager)translator.FastGetCSObj(L, 1);
                LuaAPI.lua_pushboolean(L, __cl_gen_to_be_invoked.IsNavigating);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_RunningTargetPathNode(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.TargetPathManager __cl_gen_to_be_invoked = (xc.TargetPathManager)translator.FastGetCSObj(L, 1);
                translator.Push(L, __cl_gen_to_be_invoked.RunningTargetPathNode);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_CurrentSceneTargetPathNode(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.TargetPathManager __cl_gen_to_be_invoked = (xc.TargetPathManager)translator.FastGetCSObj(L, 1);
                translator.Push(L, __cl_gen_to_be_invoked.CurrentSceneTargetPathNode);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_IsFirstNavigatingJumpToScene(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.TargetPathManager __cl_gen_to_be_invoked = (xc.TargetPathManager)translator.FastGetCSObj(L, 1);
                LuaAPI.lua_pushboolean(L, __cl_gen_to_be_invoked.IsFirstNavigatingJumpToScene);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_IsNavigating(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.TargetPathManager __cl_gen_to_be_invoked = (xc.TargetPathManager)translator.FastGetCSObj(L, 1);
                __cl_gen_to_be_invoked.IsNavigating = LuaAPI.lua_toboolean(L, 2);
            
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_RunningTargetPathNode(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.TargetPathManager __cl_gen_to_be_invoked = (xc.TargetPathManager)translator.FastGetCSObj(L, 1);
                __cl_gen_to_be_invoked.RunningTargetPathNode = (xc.TargetPathNode)translator.GetObject(L, 2, typeof(xc.TargetPathNode));
            
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 0;
        }
        
		
		
		
		
    }
}
