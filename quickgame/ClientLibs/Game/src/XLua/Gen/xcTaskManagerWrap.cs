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
    public class xcTaskManagerWrap
    {
        public static void __Register(RealStatePtr L)
        {
			ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			XUtils.BeginObjectRegister(typeof(xc.TaskManager), L, translator, 0, 20, 30, 14);
			
			XUtils.RegisterFunc(L, XUtils.METHOD_IDX, "RegisterAllMessage", _m_RegisterAllMessage);
			XUtils.RegisterFunc(L, XUtils.METHOD_IDX, "AddTask", _m_AddTask);
			XUtils.RegisterFunc(L, XUtils.METHOD_IDX, "GetTaskByTypeAndId", _m_GetTaskByTypeAndId);
			XUtils.RegisterFunc(L, XUtils.METHOD_IDX, "GetTask", _m_GetTask);
			XUtils.RegisterFunc(L, XUtils.METHOD_IDX, "HasTask", _m_HasTask);
			XUtils.RegisterFunc(L, XUtils.METHOD_IDX, "IsMainTaskFinished", _m_IsMainTaskFinished);
			XUtils.RegisterFunc(L, XUtils.METHOD_IDX, "DeleteTask", _m_DeleteTask);
			XUtils.RegisterFunc(L, XUtils.METHOD_IDX, "ClearAllTasks", _m_ClearAllTasks);
			XUtils.RegisterFunc(L, XUtils.METHOD_IDX, "ChangeTaskCurStepValue", _m_ChangeTaskCurStepValue);
			XUtils.RegisterFunc(L, XUtils.METHOD_IDX, "Reset", _m_Reset);
			XUtils.RegisterFunc(L, XUtils.METHOD_IDX, "GetNpcRelateCurrentStepTasks", _m_GetNpcRelateCurrentStepTasks);
			XUtils.RegisterFunc(L, XUtils.METHOD_IDX, "Update", _m_Update);
			XUtils.RegisterFunc(L, XUtils.METHOD_IDX, "GetTasksByState", _m_GetTasksByState);
			XUtils.RegisterFunc(L, XUtils.METHOD_IDX, "GetTasksByType", _m_GetTasksByType);
			XUtils.RegisterFunc(L, XUtils.METHOD_IDX, "GetTaskNumByTypeAndState", _m_GetTaskNumByTypeAndState);
			XUtils.RegisterFunc(L, XUtils.METHOD_IDX, "GetTaskNumByState", _m_GetTaskNumByState);
			XUtils.RegisterFunc(L, XUtils.METHOD_IDX, "GetVisibleOnBarHigherPriority2TasksNum", _m_GetVisibleOnBarHigherPriority2TasksNum);
			XUtils.RegisterFunc(L, XUtils.METHOD_IDX, "HaveTasksByGoal", _m_HaveTasksByGoal);
			XUtils.RegisterFunc(L, XUtils.METHOD_IDX, "SortTaskList", _m_SortTaskList);
			XUtils.RegisterFunc(L, XUtils.METHOD_IDX, "GetNpcIdsByCurrentInteractGoal", _m_GetNpcIdsByCurrentInteractGoal);
			
			
			XUtils.RegisterFunc(L, XUtils.GETTER_IDX, "NavigatingTask", _g_get_NavigatingTask);
            XUtils.RegisterFunc(L, XUtils.GETTER_IDX, "NavigatingTaskType", _g_get_NavigatingTaskType);
            XUtils.RegisterFunc(L, XUtils.GETTER_IDX, "IsNavigatingMainTask", _g_get_IsNavigatingMainTask);
            XUtils.RegisterFunc(L, XUtils.GETTER_IDX, "SelectedTaskId", _g_get_SelectedTaskId);
            XUtils.RegisterFunc(L, XUtils.GETTER_IDX, "BountyTaskInfo", _g_get_BountyTaskInfo);
            XUtils.RegisterFunc(L, XUtils.GETTER_IDX, "IsNavigatingAcceptBountyTask", _g_get_IsNavigatingAcceptBountyTask);
            XUtils.RegisterFunc(L, XUtils.GETTER_IDX, "IsNavigatingBountyTask", _g_get_IsNavigatingBountyTask);
            XUtils.RegisterFunc(L, XUtils.GETTER_IDX, "FinishBountyTaskNoConfirm", _g_get_FinishBountyTaskNoConfirm);
            XUtils.RegisterFunc(L, XUtils.GETTER_IDX, "BountyTaskCoinReward", _g_get_BountyTaskCoinReward);
            XUtils.RegisterFunc(L, XUtils.GETTER_IDX, "DoNotAutoRunBountyTaskNextTime", _g_get_DoNotAutoRunBountyTaskNextTime);
            XUtils.RegisterFunc(L, XUtils.GETTER_IDX, "GuildTaskInfo", _g_get_GuildTaskInfo);
            XUtils.RegisterFunc(L, XUtils.GETTER_IDX, "IsNavigatingAcceptGuildTask", _g_get_IsNavigatingAcceptGuildTask);
            XUtils.RegisterFunc(L, XUtils.GETTER_IDX, "IsNavigatingGuildTask", _g_get_IsNavigatingGuildTask);
            XUtils.RegisterFunc(L, XUtils.GETTER_IDX, "FinishGuildTaskNoConfirm", _g_get_FinishGuildTaskNoConfirm);
            XUtils.RegisterFunc(L, XUtils.GETTER_IDX, "GuildTaskCtbReward", _g_get_GuildTaskCtbReward);
            XUtils.RegisterFunc(L, XUtils.GETTER_IDX, "DoNotAutoRunGuildTaskNextTime", _g_get_DoNotAutoRunGuildTaskNextTime);
            XUtils.RegisterFunc(L, XUtils.GETTER_IDX, "TransferTaskInfo", _g_get_TransferTaskInfo);
            XUtils.RegisterFunc(L, XUtils.GETTER_IDX, "IsNavigatingAcceptEscortTask", _g_get_IsNavigatingAcceptEscortTask);
            XUtils.RegisterFunc(L, XUtils.GETTER_IDX, "VisibleMainTasks", _g_get_VisibleMainTasks);
            XUtils.RegisterFunc(L, XUtils.GETTER_IDX, "AcceptedBranchTasks", _g_get_AcceptedBranchTasks);
            XUtils.RegisterFunc(L, XUtils.GETTER_IDX, "UnAcceptedBranchTasks", _g_get_UnAcceptedBranchTasks);
            XUtils.RegisterFunc(L, XUtils.GETTER_IDX, "VisibleBranchTasks", _g_get_VisibleBranchTasks);
            XUtils.RegisterFunc(L, XUtils.GETTER_IDX, "VisibleBountyTasks", _g_get_VisibleBountyTasks);
            XUtils.RegisterFunc(L, XUtils.GETTER_IDX, "VisibleGuildTasks", _g_get_VisibleGuildTasks);
            XUtils.RegisterFunc(L, XUtils.GETTER_IDX, "DoingEscortTask", _g_get_DoingEscortTask);
            XUtils.RegisterFunc(L, XUtils.GETTER_IDX, "VisibleTransferTasks", _g_get_VisibleTransferTasks);
            XUtils.RegisterFunc(L, XUtils.GETTER_IDX, "VisibleTitleTasks", _g_get_VisibleTitleTasks);
            XUtils.RegisterFunc(L, XUtils.GETTER_IDX, "VisibleEscortTasks", _g_get_VisibleEscortTasks);
            XUtils.RegisterFunc(L, XUtils.GETTER_IDX, "VisibleOnBarTasks", _g_get_VisibleOnBarTasks);
            XUtils.RegisterFunc(L, XUtils.GETTER_IDX, "AllTasks", _g_get_AllTasks);
            
			XUtils.RegisterFunc(L, XUtils.SETTER_IDX, "NavigatingTask", _s_set_NavigatingTask);
            XUtils.RegisterFunc(L, XUtils.SETTER_IDX, "SelectedTaskId", _s_set_SelectedTaskId);
            XUtils.RegisterFunc(L, XUtils.SETTER_IDX, "BountyTaskInfo", _s_set_BountyTaskInfo);
            XUtils.RegisterFunc(L, XUtils.SETTER_IDX, "IsNavigatingAcceptBountyTask", _s_set_IsNavigatingAcceptBountyTask);
            XUtils.RegisterFunc(L, XUtils.SETTER_IDX, "FinishBountyTaskNoConfirm", _s_set_FinishBountyTaskNoConfirm);
            XUtils.RegisterFunc(L, XUtils.SETTER_IDX, "BountyTaskCoinReward", _s_set_BountyTaskCoinReward);
            XUtils.RegisterFunc(L, XUtils.SETTER_IDX, "DoNotAutoRunBountyTaskNextTime", _s_set_DoNotAutoRunBountyTaskNextTime);
            XUtils.RegisterFunc(L, XUtils.SETTER_IDX, "GuildTaskInfo", _s_set_GuildTaskInfo);
            XUtils.RegisterFunc(L, XUtils.SETTER_IDX, "IsNavigatingAcceptGuildTask", _s_set_IsNavigatingAcceptGuildTask);
            XUtils.RegisterFunc(L, XUtils.SETTER_IDX, "FinishGuildTaskNoConfirm", _s_set_FinishGuildTaskNoConfirm);
            XUtils.RegisterFunc(L, XUtils.SETTER_IDX, "GuildTaskCtbReward", _s_set_GuildTaskCtbReward);
            XUtils.RegisterFunc(L, XUtils.SETTER_IDX, "DoNotAutoRunGuildTaskNextTime", _s_set_DoNotAutoRunGuildTaskNextTime);
            XUtils.RegisterFunc(L, XUtils.SETTER_IDX, "TransferTaskInfo", _s_set_TransferTaskInfo);
            XUtils.RegisterFunc(L, XUtils.SETTER_IDX, "IsNavigatingAcceptEscortTask", _s_set_IsNavigatingAcceptEscortTask);
            
			XUtils.EndObjectRegister(typeof(xc.TaskManager), L, translator, null, null,
			    null, null, null);

		    XUtils.BeginClassRegister(typeof(xc.TaskManager), L, __CreateInstance, 1, 0, 0);
			
			
            
            XUtils.RegisterObject(L, translator, XUtils.CLS_IDX, "UnderlyingSystemType", typeof(xc.TaskManager));
			
			
			XUtils.EndClassRegister(typeof(xc.TaskManager), L, translator);
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int __CreateInstance(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			try {
				if(LuaAPI.lua_gettop(L) == 1)
				{
					
					xc.TaskManager __cl_gen_ret = new xc.TaskManager();
					translator.Push(L, __cl_gen_ret);
					return 1;
				}
				
			}
			catch(System.Exception __gen_e) {
				return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
			}
            return LuaAPI.luaL_error(L, "invalid arguments to xc.TaskManager constructor!");
            
        }
        
		
        
		
        
        
        
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_RegisterAllMessage(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            xc.TaskManager __cl_gen_to_be_invoked = (xc.TaskManager)translator.FastGetCSObj(L, 1);
            
            
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
        static int _m_AddTask(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            xc.TaskManager __cl_gen_to_be_invoked = (xc.TaskManager)translator.FastGetCSObj(L, 1);
            
            
            try {
                
                {
                    xc.Task task = (xc.Task)translator.GetObject(L, 2, typeof(xc.Task));
                    
                    __cl_gen_to_be_invoked.AddTask( task );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_GetTaskByTypeAndId(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            xc.TaskManager __cl_gen_to_be_invoked = (xc.TaskManager)translator.FastGetCSObj(L, 1);
            
            
            try {
                
                {
                    ushort taskType = (ushort)LuaAPI.xlua_tointeger(L, 2);
                    uint id = LuaAPI.xlua_touint(L, 3);
                    
                        xc.Task __cl_gen_ret = __cl_gen_to_be_invoked.GetTaskByTypeAndId( taskType, id );
                        translator.Push(L, __cl_gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_GetTask(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            xc.TaskManager __cl_gen_to_be_invoked = (xc.TaskManager)translator.FastGetCSObj(L, 1);
            
            
            try {
                
                {
                    uint id = LuaAPI.xlua_touint(L, 2);
                    
                        xc.Task __cl_gen_ret = __cl_gen_to_be_invoked.GetTask( id );
                        translator.Push(L, __cl_gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_HasTask(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            xc.TaskManager __cl_gen_to_be_invoked = (xc.TaskManager)translator.FastGetCSObj(L, 1);
            
            
            try {
                
                {
                    uint id = LuaAPI.xlua_touint(L, 2);
                    
                        bool __cl_gen_ret = __cl_gen_to_be_invoked.HasTask( id );
                        LuaAPI.lua_pushboolean(L, __cl_gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_IsMainTaskFinished(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            xc.TaskManager __cl_gen_to_be_invoked = (xc.TaskManager)translator.FastGetCSObj(L, 1);
            
            
            try {
                
                {
                    uint id = LuaAPI.xlua_touint(L, 2);
                    
                        bool __cl_gen_ret = __cl_gen_to_be_invoked.IsMainTaskFinished( id );
                        LuaAPI.lua_pushboolean(L, __cl_gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_DeleteTask(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            xc.TaskManager __cl_gen_to_be_invoked = (xc.TaskManager)translator.FastGetCSObj(L, 1);
            
            
            try {
                
                {
                    uint id = LuaAPI.xlua_touint(L, 2);
                    
                    __cl_gen_to_be_invoked.DeleteTask( id );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_ClearAllTasks(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            xc.TaskManager __cl_gen_to_be_invoked = (xc.TaskManager)translator.FastGetCSObj(L, 1);
            
            
            try {
                
                {
                    
                    __cl_gen_to_be_invoked.ClearAllTasks(  );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_ChangeTaskCurStepValue(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            xc.TaskManager __cl_gen_to_be_invoked = (xc.TaskManager)translator.FastGetCSObj(L, 1);
            
            
            try {
                
                {
                    uint id = LuaAPI.xlua_touint(L, 2);
                    uint value = LuaAPI.xlua_touint(L, 3);
                    
                        bool __cl_gen_ret = __cl_gen_to_be_invoked.ChangeTaskCurStepValue( id, value );
                        LuaAPI.lua_pushboolean(L, __cl_gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_Reset(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            xc.TaskManager __cl_gen_to_be_invoked = (xc.TaskManager)translator.FastGetCSObj(L, 1);
            
            
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
        static int _m_GetNpcRelateCurrentStepTasks(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            xc.TaskManager __cl_gen_to_be_invoked = (xc.TaskManager)translator.FastGetCSObj(L, 1);
            
            
			int __gen_param_count = LuaAPI.lua_gettop(L);
            
            try {
                if(__gen_param_count == 3&& LuaTypes.LUA_TNUMBER == LuaAPI.lua_type(L, 2)&& LuaTypes.LUA_TNUMBER == LuaAPI.lua_type(L, 3)) 
                {
                    uint npcId = LuaAPI.xlua_touint(L, 2);
                    uint sceneId = LuaAPI.xlua_touint(L, 3);
                    
                        System.Collections.Generic.List<xc.Task> __cl_gen_ret = __cl_gen_to_be_invoked.GetNpcRelateCurrentStepTasks( npcId, sceneId );
                        translator.Push(L, __cl_gen_ret);
                    
                    
                    
                    return 1;
                }
                if(__gen_param_count == 2&& LuaTypes.LUA_TNUMBER == LuaAPI.lua_type(L, 2)) 
                {
                    uint npcId = LuaAPI.xlua_touint(L, 2);
                    
                        System.Collections.Generic.List<xc.Task> __cl_gen_ret = __cl_gen_to_be_invoked.GetNpcRelateCurrentStepTasks( npcId );
                        translator.Push(L, __cl_gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
            return LuaAPI.luaL_error(L, "invalid arguments to xc.TaskManager.GetNpcRelateCurrentStepTasks!");
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_Update(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            xc.TaskManager __cl_gen_to_be_invoked = (xc.TaskManager)translator.FastGetCSObj(L, 1);
            
            
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
        static int _m_GetTasksByState(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            xc.TaskManager __cl_gen_to_be_invoked = (xc.TaskManager)translator.FastGetCSObj(L, 1);
            
            
            try {
                
                {
                    uint taskState = LuaAPI.xlua_touint(L, 2);
                    
                        System.Collections.Generic.List<xc.Task> __cl_gen_ret = __cl_gen_to_be_invoked.GetTasksByState( taskState );
                        translator.Push(L, __cl_gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_GetTasksByType(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            xc.TaskManager __cl_gen_to_be_invoked = (xc.TaskManager)translator.FastGetCSObj(L, 1);
            
            
            try {
                
                {
                    ushort taskType = (ushort)LuaAPI.xlua_tointeger(L, 2);
                    
                        System.Collections.Generic.List<xc.Task> __cl_gen_ret = __cl_gen_to_be_invoked.GetTasksByType( taskType );
                        translator.Push(L, __cl_gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_GetTaskNumByTypeAndState(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            xc.TaskManager __cl_gen_to_be_invoked = (xc.TaskManager)translator.FastGetCSObj(L, 1);
            
            
            try {
                
                {
                    ushort type = (ushort)LuaAPI.xlua_tointeger(L, 2);
                    uint state = LuaAPI.xlua_touint(L, 3);
                    
                        uint __cl_gen_ret = __cl_gen_to_be_invoked.GetTaskNumByTypeAndState( type, state );
                        LuaAPI.xlua_pushuint(L, __cl_gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_GetTaskNumByState(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            xc.TaskManager __cl_gen_to_be_invoked = (xc.TaskManager)translator.FastGetCSObj(L, 1);
            
            
            try {
                
                {
                    uint state = LuaAPI.xlua_touint(L, 2);
                    
                        uint __cl_gen_ret = __cl_gen_to_be_invoked.GetTaskNumByState( state );
                        LuaAPI.xlua_pushuint(L, __cl_gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_GetVisibleOnBarHigherPriority2TasksNum(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            xc.TaskManager __cl_gen_to_be_invoked = (xc.TaskManager)translator.FastGetCSObj(L, 1);
            
            
            try {
                
                {
                    uint taskId = LuaAPI.xlua_touint(L, 2);
                    
                        uint __cl_gen_ret = __cl_gen_to_be_invoked.GetVisibleOnBarHigherPriority2TasksNum( taskId );
                        LuaAPI.xlua_pushuint(L, __cl_gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_HaveTasksByGoal(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            xc.TaskManager __cl_gen_to_be_invoked = (xc.TaskManager)translator.FastGetCSObj(L, 1);
            
            
            try {
                
                {
                    string goal = LuaAPI.lua_tostring(L, 2);
                    
                        bool __cl_gen_ret = __cl_gen_to_be_invoked.HaveTasksByGoal( goal );
                        LuaAPI.lua_pushboolean(L, __cl_gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_SortTaskList(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            xc.TaskManager __cl_gen_to_be_invoked = (xc.TaskManager)translator.FastGetCSObj(L, 1);
            
            
            try {
                
                {
                    
                    __cl_gen_to_be_invoked.SortTaskList(  );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_GetNpcIdsByCurrentInteractGoal(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            xc.TaskManager __cl_gen_to_be_invoked = (xc.TaskManager)translator.FastGetCSObj(L, 1);
            
            
			int __gen_param_count = LuaAPI.lua_gettop(L);
            
            try {
                if(__gen_param_count == 1) 
                {
                    
                        System.Collections.Generic.List<int> __cl_gen_ret = __cl_gen_to_be_invoked.GetNpcIdsByCurrentInteractGoal(  );
                        translator.Push(L, __cl_gen_ret);
                    
                    
                    
                    return 1;
                }
                if(__gen_param_count == 2&& LuaTypes.LUA_TNUMBER == LuaAPI.lua_type(L, 2)) 
                {
                    uint taskId = LuaAPI.xlua_touint(L, 2);
                    
                        System.Collections.Generic.List<int> __cl_gen_ret = __cl_gen_to_be_invoked.GetNpcIdsByCurrentInteractGoal( taskId );
                        translator.Push(L, __cl_gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
            return LuaAPI.luaL_error(L, "invalid arguments to xc.TaskManager.GetNpcIdsByCurrentInteractGoal!");
            
        }
        
        
        
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_NavigatingTask(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.TaskManager __cl_gen_to_be_invoked = (xc.TaskManager)translator.FastGetCSObj(L, 1);
                translator.Push(L, __cl_gen_to_be_invoked.NavigatingTask);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_NavigatingTaskType(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.TaskManager __cl_gen_to_be_invoked = (xc.TaskManager)translator.FastGetCSObj(L, 1);
                LuaAPI.xlua_pushinteger(L, __cl_gen_to_be_invoked.NavigatingTaskType);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_IsNavigatingMainTask(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.TaskManager __cl_gen_to_be_invoked = (xc.TaskManager)translator.FastGetCSObj(L, 1);
                LuaAPI.lua_pushboolean(L, __cl_gen_to_be_invoked.IsNavigatingMainTask);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_SelectedTaskId(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.TaskManager __cl_gen_to_be_invoked = (xc.TaskManager)translator.FastGetCSObj(L, 1);
                LuaAPI.xlua_pushuint(L, __cl_gen_to_be_invoked.SelectedTaskId);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_BountyTaskInfo(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.TaskManager __cl_gen_to_be_invoked = (xc.TaskManager)translator.FastGetCSObj(L, 1);
                translator.Push(L, __cl_gen_to_be_invoked.BountyTaskInfo);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_IsNavigatingAcceptBountyTask(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.TaskManager __cl_gen_to_be_invoked = (xc.TaskManager)translator.FastGetCSObj(L, 1);
                LuaAPI.lua_pushboolean(L, __cl_gen_to_be_invoked.IsNavigatingAcceptBountyTask);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_IsNavigatingBountyTask(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.TaskManager __cl_gen_to_be_invoked = (xc.TaskManager)translator.FastGetCSObj(L, 1);
                LuaAPI.lua_pushboolean(L, __cl_gen_to_be_invoked.IsNavigatingBountyTask);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_FinishBountyTaskNoConfirm(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.TaskManager __cl_gen_to_be_invoked = (xc.TaskManager)translator.FastGetCSObj(L, 1);
                LuaAPI.lua_pushboolean(L, __cl_gen_to_be_invoked.FinishBountyTaskNoConfirm);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_BountyTaskCoinReward(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.TaskManager __cl_gen_to_be_invoked = (xc.TaskManager)translator.FastGetCSObj(L, 1);
                LuaAPI.xlua_pushuint(L, __cl_gen_to_be_invoked.BountyTaskCoinReward);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_DoNotAutoRunBountyTaskNextTime(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.TaskManager __cl_gen_to_be_invoked = (xc.TaskManager)translator.FastGetCSObj(L, 1);
                LuaAPI.lua_pushboolean(L, __cl_gen_to_be_invoked.DoNotAutoRunBountyTaskNextTime);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_GuildTaskInfo(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.TaskManager __cl_gen_to_be_invoked = (xc.TaskManager)translator.FastGetCSObj(L, 1);
                translator.Push(L, __cl_gen_to_be_invoked.GuildTaskInfo);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_IsNavigatingAcceptGuildTask(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.TaskManager __cl_gen_to_be_invoked = (xc.TaskManager)translator.FastGetCSObj(L, 1);
                LuaAPI.lua_pushboolean(L, __cl_gen_to_be_invoked.IsNavigatingAcceptGuildTask);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_IsNavigatingGuildTask(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.TaskManager __cl_gen_to_be_invoked = (xc.TaskManager)translator.FastGetCSObj(L, 1);
                LuaAPI.lua_pushboolean(L, __cl_gen_to_be_invoked.IsNavigatingGuildTask);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_FinishGuildTaskNoConfirm(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.TaskManager __cl_gen_to_be_invoked = (xc.TaskManager)translator.FastGetCSObj(L, 1);
                LuaAPI.lua_pushboolean(L, __cl_gen_to_be_invoked.FinishGuildTaskNoConfirm);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_GuildTaskCtbReward(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.TaskManager __cl_gen_to_be_invoked = (xc.TaskManager)translator.FastGetCSObj(L, 1);
                LuaAPI.xlua_pushuint(L, __cl_gen_to_be_invoked.GuildTaskCtbReward);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_DoNotAutoRunGuildTaskNextTime(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.TaskManager __cl_gen_to_be_invoked = (xc.TaskManager)translator.FastGetCSObj(L, 1);
                LuaAPI.lua_pushboolean(L, __cl_gen_to_be_invoked.DoNotAutoRunGuildTaskNextTime);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_TransferTaskInfo(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.TaskManager __cl_gen_to_be_invoked = (xc.TaskManager)translator.FastGetCSObj(L, 1);
                translator.Push(L, __cl_gen_to_be_invoked.TransferTaskInfo);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_IsNavigatingAcceptEscortTask(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.TaskManager __cl_gen_to_be_invoked = (xc.TaskManager)translator.FastGetCSObj(L, 1);
                LuaAPI.lua_pushboolean(L, __cl_gen_to_be_invoked.IsNavigatingAcceptEscortTask);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_VisibleMainTasks(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.TaskManager __cl_gen_to_be_invoked = (xc.TaskManager)translator.FastGetCSObj(L, 1);
                translator.Push(L, __cl_gen_to_be_invoked.VisibleMainTasks);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_AcceptedBranchTasks(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.TaskManager __cl_gen_to_be_invoked = (xc.TaskManager)translator.FastGetCSObj(L, 1);
                translator.Push(L, __cl_gen_to_be_invoked.AcceptedBranchTasks);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_UnAcceptedBranchTasks(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.TaskManager __cl_gen_to_be_invoked = (xc.TaskManager)translator.FastGetCSObj(L, 1);
                translator.Push(L, __cl_gen_to_be_invoked.UnAcceptedBranchTasks);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_VisibleBranchTasks(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.TaskManager __cl_gen_to_be_invoked = (xc.TaskManager)translator.FastGetCSObj(L, 1);
                translator.Push(L, __cl_gen_to_be_invoked.VisibleBranchTasks);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_VisibleBountyTasks(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.TaskManager __cl_gen_to_be_invoked = (xc.TaskManager)translator.FastGetCSObj(L, 1);
                translator.Push(L, __cl_gen_to_be_invoked.VisibleBountyTasks);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_VisibleGuildTasks(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.TaskManager __cl_gen_to_be_invoked = (xc.TaskManager)translator.FastGetCSObj(L, 1);
                translator.Push(L, __cl_gen_to_be_invoked.VisibleGuildTasks);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_DoingEscortTask(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.TaskManager __cl_gen_to_be_invoked = (xc.TaskManager)translator.FastGetCSObj(L, 1);
                translator.Push(L, __cl_gen_to_be_invoked.DoingEscortTask);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_VisibleTransferTasks(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.TaskManager __cl_gen_to_be_invoked = (xc.TaskManager)translator.FastGetCSObj(L, 1);
                translator.Push(L, __cl_gen_to_be_invoked.VisibleTransferTasks);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_VisibleTitleTasks(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.TaskManager __cl_gen_to_be_invoked = (xc.TaskManager)translator.FastGetCSObj(L, 1);
                translator.Push(L, __cl_gen_to_be_invoked.VisibleTitleTasks);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_VisibleEscortTasks(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.TaskManager __cl_gen_to_be_invoked = (xc.TaskManager)translator.FastGetCSObj(L, 1);
                translator.Push(L, __cl_gen_to_be_invoked.VisibleEscortTasks);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_VisibleOnBarTasks(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.TaskManager __cl_gen_to_be_invoked = (xc.TaskManager)translator.FastGetCSObj(L, 1);
                translator.Push(L, __cl_gen_to_be_invoked.VisibleOnBarTasks);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_AllTasks(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.TaskManager __cl_gen_to_be_invoked = (xc.TaskManager)translator.FastGetCSObj(L, 1);
                translator.Push(L, __cl_gen_to_be_invoked.AllTasks);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_NavigatingTask(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.TaskManager __cl_gen_to_be_invoked = (xc.TaskManager)translator.FastGetCSObj(L, 1);
                __cl_gen_to_be_invoked.NavigatingTask = (xc.Task)translator.GetObject(L, 2, typeof(xc.Task));
            
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_SelectedTaskId(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.TaskManager __cl_gen_to_be_invoked = (xc.TaskManager)translator.FastGetCSObj(L, 1);
                __cl_gen_to_be_invoked.SelectedTaskId = LuaAPI.xlua_touint(L, 2);
            
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_BountyTaskInfo(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.TaskManager __cl_gen_to_be_invoked = (xc.TaskManager)translator.FastGetCSObj(L, 1);
                __cl_gen_to_be_invoked.BountyTaskInfo = (xc.BountyTaskInfo)translator.GetObject(L, 2, typeof(xc.BountyTaskInfo));
            
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_IsNavigatingAcceptBountyTask(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.TaskManager __cl_gen_to_be_invoked = (xc.TaskManager)translator.FastGetCSObj(L, 1);
                __cl_gen_to_be_invoked.IsNavigatingAcceptBountyTask = LuaAPI.lua_toboolean(L, 2);
            
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_FinishBountyTaskNoConfirm(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.TaskManager __cl_gen_to_be_invoked = (xc.TaskManager)translator.FastGetCSObj(L, 1);
                __cl_gen_to_be_invoked.FinishBountyTaskNoConfirm = LuaAPI.lua_toboolean(L, 2);
            
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_BountyTaskCoinReward(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.TaskManager __cl_gen_to_be_invoked = (xc.TaskManager)translator.FastGetCSObj(L, 1);
                __cl_gen_to_be_invoked.BountyTaskCoinReward = LuaAPI.xlua_touint(L, 2);
            
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_DoNotAutoRunBountyTaskNextTime(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.TaskManager __cl_gen_to_be_invoked = (xc.TaskManager)translator.FastGetCSObj(L, 1);
                __cl_gen_to_be_invoked.DoNotAutoRunBountyTaskNextTime = LuaAPI.lua_toboolean(L, 2);
            
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_GuildTaskInfo(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.TaskManager __cl_gen_to_be_invoked = (xc.TaskManager)translator.FastGetCSObj(L, 1);
                __cl_gen_to_be_invoked.GuildTaskInfo = (xc.GuildTaskInfo)translator.GetObject(L, 2, typeof(xc.GuildTaskInfo));
            
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_IsNavigatingAcceptGuildTask(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.TaskManager __cl_gen_to_be_invoked = (xc.TaskManager)translator.FastGetCSObj(L, 1);
                __cl_gen_to_be_invoked.IsNavigatingAcceptGuildTask = LuaAPI.lua_toboolean(L, 2);
            
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_FinishGuildTaskNoConfirm(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.TaskManager __cl_gen_to_be_invoked = (xc.TaskManager)translator.FastGetCSObj(L, 1);
                __cl_gen_to_be_invoked.FinishGuildTaskNoConfirm = LuaAPI.lua_toboolean(L, 2);
            
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_GuildTaskCtbReward(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.TaskManager __cl_gen_to_be_invoked = (xc.TaskManager)translator.FastGetCSObj(L, 1);
                __cl_gen_to_be_invoked.GuildTaskCtbReward = LuaAPI.xlua_touint(L, 2);
            
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_DoNotAutoRunGuildTaskNextTime(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.TaskManager __cl_gen_to_be_invoked = (xc.TaskManager)translator.FastGetCSObj(L, 1);
                __cl_gen_to_be_invoked.DoNotAutoRunGuildTaskNextTime = LuaAPI.lua_toboolean(L, 2);
            
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_TransferTaskInfo(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.TaskManager __cl_gen_to_be_invoked = (xc.TaskManager)translator.FastGetCSObj(L, 1);
                __cl_gen_to_be_invoked.TransferTaskInfo = (Net.S2CTaskTransferInfo)translator.GetObject(L, 2, typeof(Net.S2CTaskTransferInfo));
            
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_IsNavigatingAcceptEscortTask(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.TaskManager __cl_gen_to_be_invoked = (xc.TaskManager)translator.FastGetCSObj(L, 1);
                __cl_gen_to_be_invoked.IsNavigatingAcceptEscortTask = LuaAPI.lua_toboolean(L, 2);
            
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 0;
        }
        
		
		
		
		
    }
}
