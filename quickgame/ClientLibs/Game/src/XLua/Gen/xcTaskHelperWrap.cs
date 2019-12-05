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
    public class xcTaskHelperWrap
    {
        public static void __Register(RealStatePtr L)
        {
			ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			XUtils.BeginObjectRegister(typeof(xc.TaskHelper), L, translator, 0, 0, 0, 0);
			
			
			
			
			
			XUtils.EndObjectRegister(typeof(xc.TaskHelper), L, translator, null, null,
			    null, null, null);

		    XUtils.BeginClassRegister(typeof(xc.TaskHelper), L, __CreateInstance, 33, 5, 3);
			XUtils.RegisterFunc(L, XUtils.CLS_IDX, "StepGoalIsRelateSearchNpc", _m_StepGoalIsRelateSearchNpc_xlua_st_);
            XUtils.RegisterFunc(L, XUtils.CLS_IDX, "GetTrigramName", _m_GetTrigramName_xlua_st_);
            XUtils.RegisterFunc(L, XUtils.CLS_IDX, "GetTrigramChapterId", _m_GetTrigramChapterId_xlua_st_);
            XUtils.RegisterFunc(L, XUtils.CLS_IDX, "GetTrigramRace", _m_GetTrigramRace_xlua_st_);
            XUtils.RegisterFunc(L, XUtils.CLS_IDX, "TaskGuideCoroutine", _m_TaskGuideCoroutine_xlua_st_);
            XUtils.RegisterFunc(L, XUtils.CLS_IDX, "TaskGuide", _m_TaskGuide_xlua_st_);
            XUtils.RegisterFunc(L, XUtils.CLS_IDX, "StopTaskGuideCoroutine", _m_StopTaskGuideCoroutine_xlua_st_);
            XUtils.RegisterFunc(L, XUtils.CLS_IDX, "TaskNpcGuide", _m_TaskNpcGuide_xlua_st_);
            XUtils.RegisterFunc(L, XUtils.CLS_IDX, "ProcessTouchInteractTasksNpc", _m_ProcessTouchInteractTasksNpc_xlua_st_);
            XUtils.RegisterFunc(L, XUtils.CLS_IDX, "ProcessTouchTasksNpc", _m_ProcessTouchTasksNpc_xlua_st_);
            XUtils.RegisterFunc(L, XUtils.CLS_IDX, "GetNpcRelatedTasks", _m_GetNpcRelatedTasks_xlua_st_);
            XUtils.RegisterFunc(L, XUtils.CLS_IDX, "CanTransfer", _m_CanTransfer_xlua_st_);
            XUtils.RegisterFunc(L, XUtils.CLS_IDX, "TransferToTaskTarget", _m_TransferToTaskTarget_xlua_st_);
            XUtils.RegisterFunc(L, XUtils.CLS_IDX, "ShowTaskProgressTips", _m_ShowTaskProgressTips_xlua_st_);
            XUtils.RegisterFunc(L, XUtils.CLS_IDX, "AcceptBountyTaskGuide", _m_AcceptBountyTaskGuide_xlua_st_);
            XUtils.RegisterFunc(L, XUtils.CLS_IDX, "AcceptGuildTaskGuide", _m_AcceptGuildTaskGuide_xlua_st_);
            XUtils.RegisterFunc(L, XUtils.CLS_IDX, "AcceptEscortTaskGuide", _m_AcceptEscortTaskGuide_xlua_st_);
            XUtils.RegisterFunc(L, XUtils.CLS_IDX, "TaskCanAccept", _m_TaskCanAccept_xlua_st_);
            XUtils.RegisterFunc(L, XUtils.CLS_IDX, "IsTaskAccepted", _m_IsTaskAccepted_xlua_st_);
            XUtils.RegisterFunc(L, XUtils.CLS_IDX, "IsTaskCanSubmit", _m_IsTaskCanSubmit_xlua_st_);
            XUtils.RegisterFunc(L, XUtils.CLS_IDX, "GetBountyTaskMaxTimes", _m_GetBountyTaskMaxTimes_xlua_st_);
            XUtils.RegisterFunc(L, XUtils.CLS_IDX, "GetGuildTaskMaxTimes", _m_GetGuildTaskMaxTimes_xlua_st_);
            XUtils.RegisterFunc(L, XUtils.CLS_IDX, "GetEscortTaskIsDone", _m_GetEscortTaskIsDone_xlua_st_);
            XUtils.RegisterFunc(L, XUtils.CLS_IDX, "MainTaskIsPassed", _m_MainTaskIsPassed_xlua_st_);
            XUtils.RegisterFunc(L, XUtils.CLS_IDX, "GetPreMainTasksId", _m_GetPreMainTasksId_xlua_st_);
            XUtils.RegisterFunc(L, XUtils.CLS_IDX, "ShouldDeleteNpcInCurMainTask", _m_ShouldDeleteNpcInCurMainTask_xlua_st_);
            XUtils.RegisterFunc(L, XUtils.CLS_IDX, "CheckNpcAndActiveNpcFollowAI", _m_CheckNpcAndActiveNpcFollowAI_xlua_st_);
            XUtils.RegisterFunc(L, XUtils.CLS_IDX, "CheckTaskAndActiveNpcFollowAI", _m_CheckTaskAndActiveNpcFollowAI_xlua_st_);
            XUtils.RegisterFunc(L, XUtils.CLS_IDX, "LocalPlayerIsInEscortTaskState", _m_LocalPlayerIsInEscortTaskState_xlua_st_);
            XUtils.RegisterFunc(L, XUtils.CLS_IDX, "GetStepFixedDescriptionByLua", _m_GetStepFixedDescriptionByLua_xlua_st_);
            XUtils.RegisterFunc(L, XUtils.CLS_IDX, "GotoTaskByLua", _m_GotoTaskByLua_xlua_st_);
            XUtils.RegisterFunc(L, XUtils.CLS_IDX, "GetTaskNumByState", _m_GetTaskNumByState_xlua_st_);
            
			
            
            XUtils.RegisterObject(L, translator, XUtils.CLS_IDX, "UnderlyingSystemType", typeof(xc.TaskHelper));
			XUtils.RegisterFunc(L, XUtils.CLS_GETTER_IDX, "MainTaskIsInGuideCoroutine", _g_get_MainTaskIsInGuideCoroutine);
            XUtils.RegisterFunc(L, XUtils.CLS_GETTER_IDX, "TaskTypeInGuideCoroutine", _g_get_TaskTypeInGuideCoroutine);
            XUtils.RegisterFunc(L, XUtils.CLS_GETTER_IDX, "TaskIdInGuideCoroutine", _g_get_TaskIdInGuideCoroutine);
            XUtils.RegisterFunc(L, XUtils.CLS_GETTER_IDX, "IsAutoMainTask", _g_get_IsAutoMainTask);
            XUtils.RegisterFunc(L, XUtils.CLS_GETTER_IDX, "TransferingNpcId", _g_get_TransferingNpcId);
            
			XUtils.RegisterFunc(L, XUtils.CLS_SETTER_IDX, "TaskIdInGuideCoroutine", _s_set_TaskIdInGuideCoroutine);
            XUtils.RegisterFunc(L, XUtils.CLS_SETTER_IDX, "IsAutoMainTask", _s_set_IsAutoMainTask);
            XUtils.RegisterFunc(L, XUtils.CLS_SETTER_IDX, "TransferingNpcId", _s_set_TransferingNpcId);
            
			XUtils.EndClassRegister(typeof(xc.TaskHelper), L, translator);
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int __CreateInstance(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			try {
				if(LuaAPI.lua_gettop(L) == 1)
				{
					
					xc.TaskHelper __cl_gen_ret = new xc.TaskHelper();
					translator.Push(L, __cl_gen_ret);
					return 1;
				}
				
			}
			catch(System.Exception __gen_e) {
				return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
			}
            return LuaAPI.luaL_error(L, "invalid arguments to xc.TaskHelper constructor!");
            
        }
        
		
        
		
        
        
        
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_StepGoalIsRelateSearchNpc_xlua_st_(RealStatePtr L)
        {
            
            
            
            try {
                
                {
                    string goal = LuaAPI.lua_tostring(L, 1);
                    
                        bool __cl_gen_ret = xc.TaskHelper.StepGoalIsRelateSearchNpc( goal );
                        LuaAPI.lua_pushboolean(L, __cl_gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_GetTrigramName_xlua_st_(RealStatePtr L)
        {
            
            
            
            try {
                
                {
                    uint trigramId = LuaAPI.xlua_touint(L, 1);
                    
                        string __cl_gen_ret = xc.TaskHelper.GetTrigramName( trigramId );
                        LuaAPI.lua_pushstring(L, __cl_gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_GetTrigramChapterId_xlua_st_(RealStatePtr L)
        {
            
            
            
            try {
                
                {
                    uint trigramId = LuaAPI.xlua_touint(L, 1);
                    
                        uint __cl_gen_ret = xc.TaskHelper.GetTrigramChapterId( trigramId );
                        LuaAPI.xlua_pushuint(L, __cl_gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_GetTrigramRace_xlua_st_(RealStatePtr L)
        {
            
            
            
            try {
                
                {
                    uint trigramId = LuaAPI.xlua_touint(L, 1);
                    
                        uint __cl_gen_ret = xc.TaskHelper.GetTrigramRace( trigramId );
                        LuaAPI.xlua_pushuint(L, __cl_gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_TaskGuideCoroutine_xlua_st_(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            
            try {
                
                {
                    xc.Task task = (xc.Task)translator.GetObject(L, 1, typeof(xc.Task));
                    bool needRecoverAutoFight = LuaAPI.lua_toboolean(L, 2);
                    
                        System.Collections.IEnumerator __cl_gen_ret = xc.TaskHelper.TaskGuideCoroutine( task, needRecoverAutoFight );
                        translator.Push(L, __cl_gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_TaskGuide_xlua_st_(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            
			int __gen_param_count = LuaAPI.lua_gettop(L);
            
            try {
                if(__gen_param_count == 1&& LuaTypes.LUA_TNUMBER == LuaAPI.lua_type(L, 1)) 
                {
                    uint taskId = LuaAPI.xlua_touint(L, 1);
                    
                        bool __cl_gen_ret = xc.TaskHelper.TaskGuide( taskId );
                        LuaAPI.lua_pushboolean(L, __cl_gen_ret);
                    
                    
                    
                    return 1;
                }
                if(__gen_param_count == 1&& translator.Assignable<xc.Task>(L, 1)) 
                {
                    xc.Task task = (xc.Task)translator.GetObject(L, 1, typeof(xc.Task));
                    
                        bool __cl_gen_ret = xc.TaskHelper.TaskGuide( task );
                        LuaAPI.lua_pushboolean(L, __cl_gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
            return LuaAPI.luaL_error(L, "invalid arguments to xc.TaskHelper.TaskGuide!");
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_StopTaskGuideCoroutine_xlua_st_(RealStatePtr L)
        {
            
            
            
            try {
                
                {
                    
                    xc.TaskHelper.StopTaskGuideCoroutine(  );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_TaskNpcGuide_xlua_st_(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            
            try {
                
                {
                    NpcPlayer npcPlayer = (NpcPlayer)translator.GetObject(L, 1, typeof(NpcPlayer));
                    
                    xc.TaskHelper.TaskNpcGuide( npcPlayer );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_ProcessTouchInteractTasksNpc_xlua_st_(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            
            try {
                
                {
                    NpcPlayer npcPlayer = (NpcPlayer)translator.GetObject(L, 1, typeof(NpcPlayer));
                    
                        bool __cl_gen_ret = xc.TaskHelper.ProcessTouchInteractTasksNpc( npcPlayer );
                        LuaAPI.lua_pushboolean(L, __cl_gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_ProcessTouchTasksNpc_xlua_st_(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            
            try {
                
                {
                    NpcPlayer npcPlayer = (NpcPlayer)translator.GetObject(L, 1, typeof(NpcPlayer));
                    
                        bool __cl_gen_ret = xc.TaskHelper.ProcessTouchTasksNpc( npcPlayer );
                        LuaAPI.lua_pushboolean(L, __cl_gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_GetNpcRelatedTasks_xlua_st_(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            
            try {
                
                {
                    NpcPlayer npcPlayer = (NpcPlayer)translator.GetObject(L, 1, typeof(NpcPlayer));
                    System.Collections.Generic.List<xc.Task> needDoTasks;
                    System.Collections.Generic.List<xc.Task> needAcceptAndSubmitTasks;
                    
                        bool __cl_gen_ret = xc.TaskHelper.GetNpcRelatedTasks( npcPlayer, out needDoTasks, out needAcceptAndSubmitTasks );
                        LuaAPI.lua_pushboolean(L, __cl_gen_ret);
                    translator.Push(L, needDoTasks);
                        
                    translator.Push(L, needAcceptAndSubmitTasks);
                        
                    
                    
                    
                    return 3;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_CanTransfer_xlua_st_(RealStatePtr L)
        {
            
            
            
            try {
                
                {
                    uint id = LuaAPI.xlua_touint(L, 1);
                    
                        bool __cl_gen_ret = xc.TaskHelper.CanTransfer( id );
                        LuaAPI.lua_pushboolean(L, __cl_gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_TransferToTaskTarget_xlua_st_(RealStatePtr L)
        {
            
            
            
            try {
                
                {
                    uint id = LuaAPI.xlua_touint(L, 1);
                    
                    xc.TaskHelper.TransferToTaskTarget( id );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_ShowTaskProgressTips_xlua_st_(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            
            try {
                
                {
                    xc.Task task = (xc.Task)translator.GetObject(L, 1, typeof(xc.Task));
                    
                    xc.TaskHelper.ShowTaskProgressTips( task );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_AcceptBountyTaskGuide_xlua_st_(RealStatePtr L)
        {
            
            
            
            try {
                
                {
                    
                    xc.TaskHelper.AcceptBountyTaskGuide(  );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_AcceptGuildTaskGuide_xlua_st_(RealStatePtr L)
        {
            
            
            
            try {
                
                {
                    
                    xc.TaskHelper.AcceptGuildTaskGuide(  );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_AcceptEscortTaskGuide_xlua_st_(RealStatePtr L)
        {
            
            
            
            try {
                
                {
                    
                    xc.TaskHelper.AcceptEscortTaskGuide(  );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_TaskCanAccept_xlua_st_(RealStatePtr L)
        {
            
            
            
            try {
                
                {
                    uint taskId = LuaAPI.xlua_touint(L, 1);
                    
                        bool __cl_gen_ret = xc.TaskHelper.TaskCanAccept( taskId );
                        LuaAPI.lua_pushboolean(L, __cl_gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_IsTaskAccepted_xlua_st_(RealStatePtr L)
        {
            
            
            
            try {
                
                {
                    uint taskId = LuaAPI.xlua_touint(L, 1);
                    
                        bool __cl_gen_ret = xc.TaskHelper.IsTaskAccepted( taskId );
                        LuaAPI.lua_pushboolean(L, __cl_gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_IsTaskCanSubmit_xlua_st_(RealStatePtr L)
        {
            
            
            
            try {
                
                {
                    uint taskId = LuaAPI.xlua_touint(L, 1);
                    
                        bool __cl_gen_ret = xc.TaskHelper.IsTaskCanSubmit( taskId );
                        LuaAPI.lua_pushboolean(L, __cl_gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_GetBountyTaskMaxTimes_xlua_st_(RealStatePtr L)
        {
            
            
            
            try {
                
                {
                    
                        uint __cl_gen_ret = xc.TaskHelper.GetBountyTaskMaxTimes(  );
                        LuaAPI.xlua_pushuint(L, __cl_gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_GetGuildTaskMaxTimes_xlua_st_(RealStatePtr L)
        {
            
            
            
            try {
                
                {
                    
                        uint __cl_gen_ret = xc.TaskHelper.GetGuildTaskMaxTimes(  );
                        LuaAPI.xlua_pushuint(L, __cl_gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_GetEscortTaskIsDone_xlua_st_(RealStatePtr L)
        {
            
            
            
            try {
                
                {
                    
                        bool __cl_gen_ret = xc.TaskHelper.GetEscortTaskIsDone(  );
                        LuaAPI.lua_pushboolean(L, __cl_gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_MainTaskIsPassed_xlua_st_(RealStatePtr L)
        {
            
            
            
            try {
                
                {
                    uint taskId = LuaAPI.xlua_touint(L, 1);
                    
                        bool __cl_gen_ret = xc.TaskHelper.MainTaskIsPassed( taskId );
                        LuaAPI.lua_pushboolean(L, __cl_gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_GetPreMainTasksId_xlua_st_(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            
            try {
                
                {
                    uint taskId = LuaAPI.xlua_touint(L, 1);
                    
                        System.Collections.Generic.List<uint> __cl_gen_ret = xc.TaskHelper.GetPreMainTasksId( taskId );
                        translator.Push(L, __cl_gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_ShouldDeleteNpcInCurMainTask_xlua_st_(RealStatePtr L)
        {
            
            
            
            try {
                
                {
                    int npcId = LuaAPI.xlua_tointeger(L, 1);
                    
                        bool __cl_gen_ret = xc.TaskHelper.ShouldDeleteNpcInCurMainTask( npcId );
                        LuaAPI.lua_pushboolean(L, __cl_gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_CheckNpcAndActiveNpcFollowAI_xlua_st_(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            
            try {
                
                {
                    NpcPlayer npcPlayer = (NpcPlayer)translator.GetObject(L, 1, typeof(NpcPlayer));
                    
                    xc.TaskHelper.CheckNpcAndActiveNpcFollowAI( npcPlayer );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_CheckTaskAndActiveNpcFollowAI_xlua_st_(RealStatePtr L)
        {
            
            
            
            try {
                
                {
                    uint taskId = LuaAPI.xlua_touint(L, 1);
                    bool active = LuaAPI.lua_toboolean(L, 2);
                    
                    xc.TaskHelper.CheckTaskAndActiveNpcFollowAI( taskId, active );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_LocalPlayerIsInEscortTaskState_xlua_st_(RealStatePtr L)
        {
            
            
            
            try {
                
                {
                    
                        bool __cl_gen_ret = xc.TaskHelper.LocalPlayerIsInEscortTaskState(  );
                        LuaAPI.lua_pushboolean(L, __cl_gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_GetStepFixedDescriptionByLua_xlua_st_(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            
            try {
                
                {
                    xc.TaskDefine.TaskStep step = (xc.TaskDefine.TaskStep)translator.GetObject(L, 1, typeof(xc.TaskDefine.TaskStep));
                    
                        string __cl_gen_ret = xc.TaskHelper.GetStepFixedDescriptionByLua( step );
                        LuaAPI.lua_pushstring(L, __cl_gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_GotoTaskByLua_xlua_st_(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            
            try {
                
                {
                    xc.Task task = (xc.Task)translator.GetObject(L, 1, typeof(xc.Task));
                    
                    xc.TaskHelper.GotoTaskByLua( task );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_GetTaskNumByState_xlua_st_(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            
            try {
                
                {
                    System.Collections.Generic.List<xc.Task> tasks = (System.Collections.Generic.List<xc.Task>)translator.GetObject(L, 1, typeof(System.Collections.Generic.List<xc.Task>));
                    uint state = LuaAPI.xlua_touint(L, 2);
                    
                        uint __cl_gen_ret = xc.TaskHelper.GetTaskNumByState( tasks, state );
                        LuaAPI.xlua_pushuint(L, __cl_gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        
        
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_MainTaskIsInGuideCoroutine(RealStatePtr L)
        {
            
            try {
			    LuaAPI.lua_pushboolean(L, xc.TaskHelper.MainTaskIsInGuideCoroutine);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_TaskTypeInGuideCoroutine(RealStatePtr L)
        {
            
            try {
			    LuaAPI.xlua_pushinteger(L, xc.TaskHelper.TaskTypeInGuideCoroutine);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_TaskIdInGuideCoroutine(RealStatePtr L)
        {
            
            try {
			    LuaAPI.xlua_pushuint(L, xc.TaskHelper.TaskIdInGuideCoroutine);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_IsAutoMainTask(RealStatePtr L)
        {
            
            try {
			    LuaAPI.lua_pushboolean(L, xc.TaskHelper.IsAutoMainTask);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_TransferingNpcId(RealStatePtr L)
        {
            
            try {
			    LuaAPI.xlua_pushinteger(L, xc.TaskHelper.TransferingNpcId);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_TaskIdInGuideCoroutine(RealStatePtr L)
        {
            
            try {
			    xc.TaskHelper.TaskIdInGuideCoroutine = LuaAPI.xlua_touint(L, 1);
            
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_IsAutoMainTask(RealStatePtr L)
        {
            
            try {
			    xc.TaskHelper.IsAutoMainTask = LuaAPI.lua_toboolean(L, 1);
            
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_TransferingNpcId(RealStatePtr L)
        {
            
            try {
			    xc.TaskHelper.TransferingNpcId = LuaAPI.xlua_tointeger(L, 1);
            
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 0;
        }
        
		
		
		
		
    }
}
