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
    public class xcTaskDefineWrap
    {
        public static void __Register(RealStatePtr L)
        {
			ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			XUtils.BeginObjectRegister(typeof(xc.TaskDefine), L, translator, 0, 6, 38, 32);
			
			XUtils.RegisterFunc(L, XUtils.METHOD_IDX, "GetFollowNpcName", _m_GetFollowNpcName);
			XUtils.RegisterFunc(L, XUtils.METHOD_IDX, "GetStep", _m_GetStep);
			XUtils.RegisterFunc(L, XUtils.METHOD_IDX, "GetStepFixedDescription", _m_GetStepFixedDescription);
			XUtils.RegisterFunc(L, XUtils.METHOD_IDX, "GetSubmitNpcPlayer", _m_GetSubmitNpcPlayer);
			XUtils.RegisterFunc(L, XUtils.METHOD_IDX, "GetFollowNpcPlayer", _m_GetFollowNpcPlayer);
			XUtils.RegisterFunc(L, XUtils.METHOD_IDX, "GetSkillByVocation", _m_GetSkillByVocation);
			
			
			XUtils.RegisterFunc(L, XUtils.GETTER_IDX, "Name", _g_get_Name);
            XUtils.RegisterFunc(L, XUtils.GETTER_IDX, "Description", _g_get_Description);
            XUtils.RegisterFunc(L, XUtils.GETTER_IDX, "AutoRunType", _g_get_AutoRunType);
            XUtils.RegisterFunc(L, XUtils.GETTER_IDX, "ShowRewardGoodsId", _g_get_ShowRewardGoodsId);
            XUtils.RegisterFunc(L, XUtils.GETTER_IDX, "ShowRewardGoodsNum", _g_get_ShowRewardGoodsNum);
            XUtils.RegisterFunc(L, XUtils.GETTER_IDX, "ShowRewardGoodsIsBind", _g_get_ShowRewardGoodsIsBind);
            XUtils.RegisterFunc(L, XUtils.GETTER_IDX, "RewardInfos", _g_get_RewardInfos);
            XUtils.RegisterFunc(L, XUtils.GETTER_IDX, "Id", _g_get_Id);
            XUtils.RegisterFunc(L, XUtils.GETTER_IDX, "NameBytes", _g_get_NameBytes);
            XUtils.RegisterFunc(L, XUtils.GETTER_IDX, "DescriptionBytes", _g_get_DescriptionBytes);
            XUtils.RegisterFunc(L, XUtils.GETTER_IDX, "Type", _g_get_Type);
            XUtils.RegisterFunc(L, XUtils.GETTER_IDX, "SubType", _g_get_SubType);
            XUtils.RegisterFunc(L, XUtils.GETTER_IDX, "RequestLevelMin", _g_get_RequestLevelMin);
            XUtils.RegisterFunc(L, XUtils.GETTER_IDX, "PreviousId", _g_get_PreviousId);
            XUtils.RegisterFunc(L, XUtils.GETTER_IDX, "NextId", _g_get_NextId);
            XUtils.RegisterFunc(L, XUtils.GETTER_IDX, "RewardIds", _g_get_RewardIds);
            XUtils.RegisterFunc(L, XUtils.GETTER_IDX, "GetSkills", _g_get_GetSkills);
            XUtils.RegisterFunc(L, XUtils.GETTER_IDX, "IsShowGetSkillProgress", _g_get_IsShowGetSkillProgress);
            XUtils.RegisterFunc(L, XUtils.GETTER_IDX, "Steps", _g_get_Steps);
            XUtils.RegisterFunc(L, XUtils.GETTER_IDX, "ReceiveDialogId", _g_get_ReceiveDialogId);
            XUtils.RegisterFunc(L, XUtils.GETTER_IDX, "SubmitDialogId", _g_get_SubmitDialogId);
            XUtils.RegisterFunc(L, XUtils.GETTER_IDX, "ReceiveNpc", _g_get_ReceiveNpc);
            XUtils.RegisterFunc(L, XUtils.GETTER_IDX, "SubmitNpc", _g_get_SubmitNpc);
            XUtils.RegisterFunc(L, XUtils.GETTER_IDX, "ShowPriority", _g_get_ShowPriority);
            XUtils.RegisterFunc(L, XUtils.GETTER_IDX, "ShowPriority2", _g_get_ShowPriority2);
            XUtils.RegisterFunc(L, XUtils.GETTER_IDX, "IsTemporaryOnTop", _g_get_IsTemporaryOnTop);
            XUtils.RegisterFunc(L, XUtils.GETTER_IDX, "CreateNpcsWhenReceived", _g_get_CreateNpcsWhenReceived);
            XUtils.RegisterFunc(L, XUtils.GETTER_IDX, "DeleteNpcsWhenReceived", _g_get_DeleteNpcsWhenReceived);
            XUtils.RegisterFunc(L, XUtils.GETTER_IDX, "CreateNpcsWhenDone", _g_get_CreateNpcsWhenDone);
            XUtils.RegisterFunc(L, XUtils.GETTER_IDX, "DeleteNpcsWhenDone", _g_get_DeleteNpcsWhenDone);
            XUtils.RegisterFunc(L, XUtils.GETTER_IDX, "FollowNpcs", _g_get_FollowNpcs);
            XUtils.RegisterFunc(L, XUtils.GETTER_IDX, "CanUseBoots", _g_get_CanUseBoots);
            XUtils.RegisterFunc(L, XUtils.GETTER_IDX, "ReceivedTimelineId", _g_get_ReceivedTimelineId);
            XUtils.RegisterFunc(L, XUtils.GETTER_IDX, "SubmitedTimelineId", _g_get_SubmitedTimelineId);
            XUtils.RegisterFunc(L, XUtils.GETTER_IDX, "Costs", _g_get_Costs);
            XUtils.RegisterFunc(L, XUtils.GETTER_IDX, "ShowRewardGoodsIds", _g_get_ShowRewardGoodsIds);
            XUtils.RegisterFunc(L, XUtils.GETTER_IDX, "ShowRewardGoodsNums", _g_get_ShowRewardGoodsNums);
            XUtils.RegisterFunc(L, XUtils.GETTER_IDX, "ShowRewardGoodsIsBinds", _g_get_ShowRewardGoodsIsBinds);
            
			XUtils.RegisterFunc(L, XUtils.SETTER_IDX, "AutoRunType", _s_set_AutoRunType);
            XUtils.RegisterFunc(L, XUtils.SETTER_IDX, "Id", _s_set_Id);
            XUtils.RegisterFunc(L, XUtils.SETTER_IDX, "NameBytes", _s_set_NameBytes);
            XUtils.RegisterFunc(L, XUtils.SETTER_IDX, "DescriptionBytes", _s_set_DescriptionBytes);
            XUtils.RegisterFunc(L, XUtils.SETTER_IDX, "Type", _s_set_Type);
            XUtils.RegisterFunc(L, XUtils.SETTER_IDX, "SubType", _s_set_SubType);
            XUtils.RegisterFunc(L, XUtils.SETTER_IDX, "RequestLevelMin", _s_set_RequestLevelMin);
            XUtils.RegisterFunc(L, XUtils.SETTER_IDX, "PreviousId", _s_set_PreviousId);
            XUtils.RegisterFunc(L, XUtils.SETTER_IDX, "NextId", _s_set_NextId);
            XUtils.RegisterFunc(L, XUtils.SETTER_IDX, "RewardIds", _s_set_RewardIds);
            XUtils.RegisterFunc(L, XUtils.SETTER_IDX, "GetSkills", _s_set_GetSkills);
            XUtils.RegisterFunc(L, XUtils.SETTER_IDX, "IsShowGetSkillProgress", _s_set_IsShowGetSkillProgress);
            XUtils.RegisterFunc(L, XUtils.SETTER_IDX, "Steps", _s_set_Steps);
            XUtils.RegisterFunc(L, XUtils.SETTER_IDX, "ReceiveDialogId", _s_set_ReceiveDialogId);
            XUtils.RegisterFunc(L, XUtils.SETTER_IDX, "SubmitDialogId", _s_set_SubmitDialogId);
            XUtils.RegisterFunc(L, XUtils.SETTER_IDX, "ReceiveNpc", _s_set_ReceiveNpc);
            XUtils.RegisterFunc(L, XUtils.SETTER_IDX, "SubmitNpc", _s_set_SubmitNpc);
            XUtils.RegisterFunc(L, XUtils.SETTER_IDX, "ShowPriority", _s_set_ShowPriority);
            XUtils.RegisterFunc(L, XUtils.SETTER_IDX, "ShowPriority2", _s_set_ShowPriority2);
            XUtils.RegisterFunc(L, XUtils.SETTER_IDX, "IsTemporaryOnTop", _s_set_IsTemporaryOnTop);
            XUtils.RegisterFunc(L, XUtils.SETTER_IDX, "CreateNpcsWhenReceived", _s_set_CreateNpcsWhenReceived);
            XUtils.RegisterFunc(L, XUtils.SETTER_IDX, "DeleteNpcsWhenReceived", _s_set_DeleteNpcsWhenReceived);
            XUtils.RegisterFunc(L, XUtils.SETTER_IDX, "CreateNpcsWhenDone", _s_set_CreateNpcsWhenDone);
            XUtils.RegisterFunc(L, XUtils.SETTER_IDX, "DeleteNpcsWhenDone", _s_set_DeleteNpcsWhenDone);
            XUtils.RegisterFunc(L, XUtils.SETTER_IDX, "FollowNpcs", _s_set_FollowNpcs);
            XUtils.RegisterFunc(L, XUtils.SETTER_IDX, "CanUseBoots", _s_set_CanUseBoots);
            XUtils.RegisterFunc(L, XUtils.SETTER_IDX, "ReceivedTimelineId", _s_set_ReceivedTimelineId);
            XUtils.RegisterFunc(L, XUtils.SETTER_IDX, "SubmitedTimelineId", _s_set_SubmitedTimelineId);
            XUtils.RegisterFunc(L, XUtils.SETTER_IDX, "Costs", _s_set_Costs);
            XUtils.RegisterFunc(L, XUtils.SETTER_IDX, "ShowRewardGoodsIds", _s_set_ShowRewardGoodsIds);
            XUtils.RegisterFunc(L, XUtils.SETTER_IDX, "ShowRewardGoodsNums", _s_set_ShowRewardGoodsNums);
            XUtils.RegisterFunc(L, XUtils.SETTER_IDX, "ShowRewardGoodsIsBinds", _s_set_ShowRewardGoodsIsBinds);
            
			XUtils.EndObjectRegister(typeof(xc.TaskDefine), L, translator, null, null,
			    null, null, null);

		    XUtils.BeginClassRegister(typeof(xc.TaskDefine), L, __CreateInstance, 11, 0, 0);
			XUtils.RegisterFunc(L, XUtils.CLS_IDX, "ClearCache", _m_ClearCache_xlua_st_);
            XUtils.RegisterFunc(L, XUtils.CLS_IDX, "MakeDefine", _m_MakeDefine_xlua_st_);
            XUtils.RegisterFunc(L, XUtils.CLS_IDX, "MakeNpcScenePositions", _m_MakeNpcScenePositions_xlua_st_);
            XUtils.RegisterFunc(L, XUtils.CLS_IDX, "GetTaskName", _m_GetTaskName_xlua_st_);
            XUtils.RegisterFunc(L, XUtils.CLS_IDX, "GetTaskType", _m_GetTaskType_xlua_st_);
            XUtils.RegisterFunc(L, XUtils.CLS_IDX, "GetTaskRequestLevelMin", _m_GetTaskRequestLevelMin_xlua_st_);
            XUtils.RegisterFunc(L, XUtils.CLS_IDX, "GetCreateNpcsWhenReceived", _m_GetCreateNpcsWhenReceived_xlua_st_);
            XUtils.RegisterFunc(L, XUtils.CLS_IDX, "GetDeleteNpcsWhenReceived", _m_GetDeleteNpcsWhenReceived_xlua_st_);
            XUtils.RegisterFunc(L, XUtils.CLS_IDX, "GetCreateNpcsWhenDone", _m_GetCreateNpcsWhenDone_xlua_st_);
            XUtils.RegisterFunc(L, XUtils.CLS_IDX, "GetDeleteNpcsWhenDone", _m_GetDeleteNpcsWhenDone_xlua_st_);
            
			
            
            XUtils.RegisterObject(L, translator, XUtils.CLS_IDX, "UnderlyingSystemType", typeof(xc.TaskDefine));
			
			
			XUtils.EndClassRegister(typeof(xc.TaskDefine), L, translator);
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int __CreateInstance(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			try {
				if(LuaAPI.lua_gettop(L) == 1)
				{
					
					xc.TaskDefine __cl_gen_ret = new xc.TaskDefine();
					translator.Push(L, __cl_gen_ret);
					return 1;
				}
				
			}
			catch(System.Exception __gen_e) {
				return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
			}
            return LuaAPI.luaL_error(L, "invalid arguments to xc.TaskDefine constructor!");
            
        }
        
		
        
		
        
        
        
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_ClearCache_xlua_st_(RealStatePtr L)
        {
            
            
            
            try {
                
                {
                    
                    xc.TaskDefine.ClearCache(  );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_GetFollowNpcName(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            xc.TaskDefine __cl_gen_to_be_invoked = (xc.TaskDefine)translator.FastGetCSObj(L, 1);
            
            
            try {
                
                {
                    int index = LuaAPI.xlua_tointeger(L, 2);
                    
                        string __cl_gen_ret = __cl_gen_to_be_invoked.GetFollowNpcName( index );
                        LuaAPI.lua_pushstring(L, __cl_gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_GetStep(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            xc.TaskDefine __cl_gen_to_be_invoked = (xc.TaskDefine)translator.FastGetCSObj(L, 1);
            
            
            try {
                
                {
                    int index = LuaAPI.xlua_tointeger(L, 2);
                    
                        xc.TaskDefine.TaskStep __cl_gen_ret = __cl_gen_to_be_invoked.GetStep( index );
                        translator.Push(L, __cl_gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_GetStepFixedDescription(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            xc.TaskDefine __cl_gen_to_be_invoked = (xc.TaskDefine)translator.FastGetCSObj(L, 1);
            
            
            try {
                
                {
                    int stepIndex = LuaAPI.xlua_tointeger(L, 2);
                    
                        string __cl_gen_ret = __cl_gen_to_be_invoked.GetStepFixedDescription( stepIndex );
                        LuaAPI.lua_pushstring(L, __cl_gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_GetSubmitNpcPlayer(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            xc.TaskDefine __cl_gen_to_be_invoked = (xc.TaskDefine)translator.FastGetCSObj(L, 1);
            
            
            try {
                
                {
                    
                        NpcPlayer __cl_gen_ret = __cl_gen_to_be_invoked.GetSubmitNpcPlayer(  );
                        translator.Push(L, __cl_gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_GetFollowNpcPlayer(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            xc.TaskDefine __cl_gen_to_be_invoked = (xc.TaskDefine)translator.FastGetCSObj(L, 1);
            
            
            try {
                
                {
                    
                        NpcPlayer __cl_gen_ret = __cl_gen_to_be_invoked.GetFollowNpcPlayer(  );
                        translator.Push(L, __cl_gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_GetSkillByVocation(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            xc.TaskDefine __cl_gen_to_be_invoked = (xc.TaskDefine)translator.FastGetCSObj(L, 1);
            
            
			int __gen_param_count = LuaAPI.lua_gettop(L);
            
            try {
                if(__gen_param_count == 2&& LuaTypes.LUA_TNUMBER == LuaAPI.lua_type(L, 2)) 
                {
                    uint vocation = LuaAPI.xlua_touint(L, 2);
                    
                        uint __cl_gen_ret = __cl_gen_to_be_invoked.GetSkillByVocation( vocation );
                        LuaAPI.xlua_pushuint(L, __cl_gen_ret);
                    
                    
                    
                    return 1;
                }
                if(__gen_param_count == 1) 
                {
                    
                        uint __cl_gen_ret = __cl_gen_to_be_invoked.GetSkillByVocation(  );
                        LuaAPI.xlua_pushuint(L, __cl_gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
            return LuaAPI.luaL_error(L, "invalid arguments to xc.TaskDefine.GetSkillByVocation!");
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_MakeDefine_xlua_st_(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            
            try {
                
                {
                    uint id = LuaAPI.xlua_touint(L, 1);
                    
                        xc.TaskDefine __cl_gen_ret = xc.TaskDefine.MakeDefine( id );
                        translator.Push(L, __cl_gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_MakeNpcScenePositions_xlua_st_(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            
            try {
                
                {
                    string raw = LuaAPI.lua_tostring(L, 1);
                    
                        System.Collections.Generic.List<NpcScenePosition> __cl_gen_ret = xc.TaskDefine.MakeNpcScenePositions( raw );
                        translator.Push(L, __cl_gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_GetTaskName_xlua_st_(RealStatePtr L)
        {
            
            
            
            try {
                
                {
                    uint id = LuaAPI.xlua_touint(L, 1);
                    
                        string __cl_gen_ret = xc.TaskDefine.GetTaskName( id );
                        LuaAPI.lua_pushstring(L, __cl_gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_GetTaskType_xlua_st_(RealStatePtr L)
        {
            
            
            
            try {
                
                {
                    uint id = LuaAPI.xlua_touint(L, 1);
                    
                        ushort __cl_gen_ret = xc.TaskDefine.GetTaskType( id );
                        LuaAPI.xlua_pushinteger(L, __cl_gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_GetTaskRequestLevelMin_xlua_st_(RealStatePtr L)
        {
            
            
            
            try {
                
                {
                    uint id = LuaAPI.xlua_touint(L, 1);
                    
                        int __cl_gen_ret = xc.TaskDefine.GetTaskRequestLevelMin( id );
                        LuaAPI.xlua_pushinteger(L, __cl_gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_GetCreateNpcsWhenReceived_xlua_st_(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            
			int __gen_param_count = LuaAPI.lua_gettop(L);
            
            try {
                if(__gen_param_count == 2&& LuaTypes.LUA_TNUMBER == LuaAPI.lua_type(L, 1)&& (LuaAPI.lua_isnil(L, 2) || LuaAPI.lua_type(L, 2) == LuaTypes.LUA_TSTRING)) 
                {
                    uint id = LuaAPI.xlua_touint(L, 1);
                    string npcsRawString = LuaAPI.lua_tostring(L, 2);
                    
                        System.Collections.Generic.List<NpcScenePosition> __cl_gen_ret = xc.TaskDefine.GetCreateNpcsWhenReceived( id, npcsRawString );
                        translator.Push(L, __cl_gen_ret);
                    
                    
                    
                    return 1;
                }
                if(__gen_param_count == 1&& LuaTypes.LUA_TNUMBER == LuaAPI.lua_type(L, 1)) 
                {
                    uint id = LuaAPI.xlua_touint(L, 1);
                    
                        System.Collections.Generic.List<NpcScenePosition> __cl_gen_ret = xc.TaskDefine.GetCreateNpcsWhenReceived( id );
                        translator.Push(L, __cl_gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
            return LuaAPI.luaL_error(L, "invalid arguments to xc.TaskDefine.GetCreateNpcsWhenReceived!");
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_GetDeleteNpcsWhenReceived_xlua_st_(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            
			int __gen_param_count = LuaAPI.lua_gettop(L);
            
            try {
                if(__gen_param_count == 2&& LuaTypes.LUA_TNUMBER == LuaAPI.lua_type(L, 1)&& (LuaAPI.lua_isnil(L, 2) || LuaAPI.lua_type(L, 2) == LuaTypes.LUA_TSTRING)) 
                {
                    uint id = LuaAPI.xlua_touint(L, 1);
                    string npcsRawString = LuaAPI.lua_tostring(L, 2);
                    
                        System.Collections.Generic.List<NpcScenePosition> __cl_gen_ret = xc.TaskDefine.GetDeleteNpcsWhenReceived( id, npcsRawString );
                        translator.Push(L, __cl_gen_ret);
                    
                    
                    
                    return 1;
                }
                if(__gen_param_count == 1&& LuaTypes.LUA_TNUMBER == LuaAPI.lua_type(L, 1)) 
                {
                    uint id = LuaAPI.xlua_touint(L, 1);
                    
                        System.Collections.Generic.List<NpcScenePosition> __cl_gen_ret = xc.TaskDefine.GetDeleteNpcsWhenReceived( id );
                        translator.Push(L, __cl_gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
            return LuaAPI.luaL_error(L, "invalid arguments to xc.TaskDefine.GetDeleteNpcsWhenReceived!");
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_GetCreateNpcsWhenDone_xlua_st_(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            
			int __gen_param_count = LuaAPI.lua_gettop(L);
            
            try {
                if(__gen_param_count == 2&& LuaTypes.LUA_TNUMBER == LuaAPI.lua_type(L, 1)&& (LuaAPI.lua_isnil(L, 2) || LuaAPI.lua_type(L, 2) == LuaTypes.LUA_TSTRING)) 
                {
                    uint id = LuaAPI.xlua_touint(L, 1);
                    string npcsRawString = LuaAPI.lua_tostring(L, 2);
                    
                        System.Collections.Generic.List<NpcScenePosition> __cl_gen_ret = xc.TaskDefine.GetCreateNpcsWhenDone( id, npcsRawString );
                        translator.Push(L, __cl_gen_ret);
                    
                    
                    
                    return 1;
                }
                if(__gen_param_count == 1&& LuaTypes.LUA_TNUMBER == LuaAPI.lua_type(L, 1)) 
                {
                    uint id = LuaAPI.xlua_touint(L, 1);
                    
                        System.Collections.Generic.List<NpcScenePosition> __cl_gen_ret = xc.TaskDefine.GetCreateNpcsWhenDone( id );
                        translator.Push(L, __cl_gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
            return LuaAPI.luaL_error(L, "invalid arguments to xc.TaskDefine.GetCreateNpcsWhenDone!");
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_GetDeleteNpcsWhenDone_xlua_st_(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            
            try {
                
                {
                    uint id = LuaAPI.xlua_touint(L, 1);
                    
                        System.Collections.Generic.List<NpcScenePosition> __cl_gen_ret = xc.TaskDefine.GetDeleteNpcsWhenDone( id );
                        translator.Push(L, __cl_gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        
        
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_Name(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.TaskDefine __cl_gen_to_be_invoked = (xc.TaskDefine)translator.FastGetCSObj(L, 1);
                LuaAPI.lua_pushstring(L, __cl_gen_to_be_invoked.Name);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_Description(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.TaskDefine __cl_gen_to_be_invoked = (xc.TaskDefine)translator.FastGetCSObj(L, 1);
                LuaAPI.lua_pushstring(L, __cl_gen_to_be_invoked.Description);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_AutoRunType(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.TaskDefine __cl_gen_to_be_invoked = (xc.TaskDefine)translator.FastGetCSObj(L, 1);
                translator.PushxcTaskDefineEAutoRunType(L, __cl_gen_to_be_invoked.AutoRunType);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_ShowRewardGoodsId(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.TaskDefine __cl_gen_to_be_invoked = (xc.TaskDefine)translator.FastGetCSObj(L, 1);
                LuaAPI.xlua_pushuint(L, __cl_gen_to_be_invoked.ShowRewardGoodsId);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_ShowRewardGoodsNum(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.TaskDefine __cl_gen_to_be_invoked = (xc.TaskDefine)translator.FastGetCSObj(L, 1);
                LuaAPI.xlua_pushuint(L, __cl_gen_to_be_invoked.ShowRewardGoodsNum);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_ShowRewardGoodsIsBind(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.TaskDefine __cl_gen_to_be_invoked = (xc.TaskDefine)translator.FastGetCSObj(L, 1);
                LuaAPI.xlua_pushinteger(L, __cl_gen_to_be_invoked.ShowRewardGoodsIsBind);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_RewardInfos(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.TaskDefine __cl_gen_to_be_invoked = (xc.TaskDefine)translator.FastGetCSObj(L, 1);
                translator.Push(L, __cl_gen_to_be_invoked.RewardInfos);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_Id(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.TaskDefine __cl_gen_to_be_invoked = (xc.TaskDefine)translator.FastGetCSObj(L, 1);
                LuaAPI.xlua_pushuint(L, __cl_gen_to_be_invoked.Id);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_NameBytes(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.TaskDefine __cl_gen_to_be_invoked = (xc.TaskDefine)translator.FastGetCSObj(L, 1);
                LuaAPI.lua_pushstring(L, __cl_gen_to_be_invoked.NameBytes);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_DescriptionBytes(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.TaskDefine __cl_gen_to_be_invoked = (xc.TaskDefine)translator.FastGetCSObj(L, 1);
                LuaAPI.lua_pushstring(L, __cl_gen_to_be_invoked.DescriptionBytes);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_Type(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.TaskDefine __cl_gen_to_be_invoked = (xc.TaskDefine)translator.FastGetCSObj(L, 1);
                LuaAPI.xlua_pushinteger(L, __cl_gen_to_be_invoked.Type);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_SubType(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.TaskDefine __cl_gen_to_be_invoked = (xc.TaskDefine)translator.FastGetCSObj(L, 1);
                LuaAPI.xlua_pushuint(L, __cl_gen_to_be_invoked.SubType);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_RequestLevelMin(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.TaskDefine __cl_gen_to_be_invoked = (xc.TaskDefine)translator.FastGetCSObj(L, 1);
                LuaAPI.xlua_pushinteger(L, __cl_gen_to_be_invoked.RequestLevelMin);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_PreviousId(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.TaskDefine __cl_gen_to_be_invoked = (xc.TaskDefine)translator.FastGetCSObj(L, 1);
                LuaAPI.xlua_pushuint(L, __cl_gen_to_be_invoked.PreviousId);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_NextId(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.TaskDefine __cl_gen_to_be_invoked = (xc.TaskDefine)translator.FastGetCSObj(L, 1);
                LuaAPI.xlua_pushuint(L, __cl_gen_to_be_invoked.NextId);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_RewardIds(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.TaskDefine __cl_gen_to_be_invoked = (xc.TaskDefine)translator.FastGetCSObj(L, 1);
                translator.Push(L, __cl_gen_to_be_invoked.RewardIds);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_GetSkills(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.TaskDefine __cl_gen_to_be_invoked = (xc.TaskDefine)translator.FastGetCSObj(L, 1);
                translator.Push(L, __cl_gen_to_be_invoked.GetSkills);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_IsShowGetSkillProgress(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.TaskDefine __cl_gen_to_be_invoked = (xc.TaskDefine)translator.FastGetCSObj(L, 1);
                LuaAPI.lua_pushboolean(L, __cl_gen_to_be_invoked.IsShowGetSkillProgress);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_Steps(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.TaskDefine __cl_gen_to_be_invoked = (xc.TaskDefine)translator.FastGetCSObj(L, 1);
                translator.Push(L, __cl_gen_to_be_invoked.Steps);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_ReceiveDialogId(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.TaskDefine __cl_gen_to_be_invoked = (xc.TaskDefine)translator.FastGetCSObj(L, 1);
                LuaAPI.xlua_pushuint(L, __cl_gen_to_be_invoked.ReceiveDialogId);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_SubmitDialogId(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.TaskDefine __cl_gen_to_be_invoked = (xc.TaskDefine)translator.FastGetCSObj(L, 1);
                LuaAPI.xlua_pushuint(L, __cl_gen_to_be_invoked.SubmitDialogId);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_ReceiveNpc(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.TaskDefine __cl_gen_to_be_invoked = (xc.TaskDefine)translator.FastGetCSObj(L, 1);
                translator.Push(L, __cl_gen_to_be_invoked.ReceiveNpc);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_SubmitNpc(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.TaskDefine __cl_gen_to_be_invoked = (xc.TaskDefine)translator.FastGetCSObj(L, 1);
                translator.Push(L, __cl_gen_to_be_invoked.SubmitNpc);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_ShowPriority(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.TaskDefine __cl_gen_to_be_invoked = (xc.TaskDefine)translator.FastGetCSObj(L, 1);
                LuaAPI.xlua_pushinteger(L, __cl_gen_to_be_invoked.ShowPriority);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_ShowPriority2(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.TaskDefine __cl_gen_to_be_invoked = (xc.TaskDefine)translator.FastGetCSObj(L, 1);
                LuaAPI.xlua_pushinteger(L, __cl_gen_to_be_invoked.ShowPriority2);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_IsTemporaryOnTop(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.TaskDefine __cl_gen_to_be_invoked = (xc.TaskDefine)translator.FastGetCSObj(L, 1);
                LuaAPI.lua_pushboolean(L, __cl_gen_to_be_invoked.IsTemporaryOnTop);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_CreateNpcsWhenReceived(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.TaskDefine __cl_gen_to_be_invoked = (xc.TaskDefine)translator.FastGetCSObj(L, 1);
                translator.Push(L, __cl_gen_to_be_invoked.CreateNpcsWhenReceived);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_DeleteNpcsWhenReceived(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.TaskDefine __cl_gen_to_be_invoked = (xc.TaskDefine)translator.FastGetCSObj(L, 1);
                translator.Push(L, __cl_gen_to_be_invoked.DeleteNpcsWhenReceived);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_CreateNpcsWhenDone(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.TaskDefine __cl_gen_to_be_invoked = (xc.TaskDefine)translator.FastGetCSObj(L, 1);
                translator.Push(L, __cl_gen_to_be_invoked.CreateNpcsWhenDone);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_DeleteNpcsWhenDone(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.TaskDefine __cl_gen_to_be_invoked = (xc.TaskDefine)translator.FastGetCSObj(L, 1);
                translator.Push(L, __cl_gen_to_be_invoked.DeleteNpcsWhenDone);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_FollowNpcs(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.TaskDefine __cl_gen_to_be_invoked = (xc.TaskDefine)translator.FastGetCSObj(L, 1);
                translator.Push(L, __cl_gen_to_be_invoked.FollowNpcs);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_CanUseBoots(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.TaskDefine __cl_gen_to_be_invoked = (xc.TaskDefine)translator.FastGetCSObj(L, 1);
                LuaAPI.lua_pushboolean(L, __cl_gen_to_be_invoked.CanUseBoots);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_ReceivedTimelineId(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.TaskDefine __cl_gen_to_be_invoked = (xc.TaskDefine)translator.FastGetCSObj(L, 1);
                LuaAPI.xlua_pushuint(L, __cl_gen_to_be_invoked.ReceivedTimelineId);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_SubmitedTimelineId(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.TaskDefine __cl_gen_to_be_invoked = (xc.TaskDefine)translator.FastGetCSObj(L, 1);
                LuaAPI.xlua_pushuint(L, __cl_gen_to_be_invoked.SubmitedTimelineId);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_Costs(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.TaskDefine __cl_gen_to_be_invoked = (xc.TaskDefine)translator.FastGetCSObj(L, 1);
                translator.Push(L, __cl_gen_to_be_invoked.Costs);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_ShowRewardGoodsIds(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.TaskDefine __cl_gen_to_be_invoked = (xc.TaskDefine)translator.FastGetCSObj(L, 1);
                translator.Push(L, __cl_gen_to_be_invoked.ShowRewardGoodsIds);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_ShowRewardGoodsNums(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.TaskDefine __cl_gen_to_be_invoked = (xc.TaskDefine)translator.FastGetCSObj(L, 1);
                translator.Push(L, __cl_gen_to_be_invoked.ShowRewardGoodsNums);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_ShowRewardGoodsIsBinds(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.TaskDefine __cl_gen_to_be_invoked = (xc.TaskDefine)translator.FastGetCSObj(L, 1);
                translator.Push(L, __cl_gen_to_be_invoked.ShowRewardGoodsIsBinds);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_AutoRunType(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.TaskDefine __cl_gen_to_be_invoked = (xc.TaskDefine)translator.FastGetCSObj(L, 1);
                xc.TaskDefine.EAutoRunType __cl_gen_value;translator.Get(L, 2, out __cl_gen_value);
				__cl_gen_to_be_invoked.AutoRunType = __cl_gen_value;
            
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_Id(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.TaskDefine __cl_gen_to_be_invoked = (xc.TaskDefine)translator.FastGetCSObj(L, 1);
                __cl_gen_to_be_invoked.Id = LuaAPI.xlua_touint(L, 2);
            
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_NameBytes(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.TaskDefine __cl_gen_to_be_invoked = (xc.TaskDefine)translator.FastGetCSObj(L, 1);
                __cl_gen_to_be_invoked.NameBytes = LuaAPI.lua_tobytes(L, 2);
            
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_DescriptionBytes(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.TaskDefine __cl_gen_to_be_invoked = (xc.TaskDefine)translator.FastGetCSObj(L, 1);
                __cl_gen_to_be_invoked.DescriptionBytes = LuaAPI.lua_tobytes(L, 2);
            
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_Type(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.TaskDefine __cl_gen_to_be_invoked = (xc.TaskDefine)translator.FastGetCSObj(L, 1);
                __cl_gen_to_be_invoked.Type = (ushort)LuaAPI.xlua_tointeger(L, 2);
            
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_SubType(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.TaskDefine __cl_gen_to_be_invoked = (xc.TaskDefine)translator.FastGetCSObj(L, 1);
                __cl_gen_to_be_invoked.SubType = LuaAPI.xlua_touint(L, 2);
            
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_RequestLevelMin(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.TaskDefine __cl_gen_to_be_invoked = (xc.TaskDefine)translator.FastGetCSObj(L, 1);
                __cl_gen_to_be_invoked.RequestLevelMin = LuaAPI.xlua_tointeger(L, 2);
            
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_PreviousId(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.TaskDefine __cl_gen_to_be_invoked = (xc.TaskDefine)translator.FastGetCSObj(L, 1);
                __cl_gen_to_be_invoked.PreviousId = LuaAPI.xlua_touint(L, 2);
            
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_NextId(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.TaskDefine __cl_gen_to_be_invoked = (xc.TaskDefine)translator.FastGetCSObj(L, 1);
                __cl_gen_to_be_invoked.NextId = LuaAPI.xlua_touint(L, 2);
            
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_RewardIds(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.TaskDefine __cl_gen_to_be_invoked = (xc.TaskDefine)translator.FastGetCSObj(L, 1);
                __cl_gen_to_be_invoked.RewardIds = (System.Collections.Generic.List<uint>)translator.GetObject(L, 2, typeof(System.Collections.Generic.List<uint>));
            
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_GetSkills(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.TaskDefine __cl_gen_to_be_invoked = (xc.TaskDefine)translator.FastGetCSObj(L, 1);
                __cl_gen_to_be_invoked.GetSkills = (System.Collections.Generic.List<uint>)translator.GetObject(L, 2, typeof(System.Collections.Generic.List<uint>));
            
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_IsShowGetSkillProgress(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.TaskDefine __cl_gen_to_be_invoked = (xc.TaskDefine)translator.FastGetCSObj(L, 1);
                __cl_gen_to_be_invoked.IsShowGetSkillProgress = LuaAPI.lua_toboolean(L, 2);
            
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_Steps(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.TaskDefine __cl_gen_to_be_invoked = (xc.TaskDefine)translator.FastGetCSObj(L, 1);
                __cl_gen_to_be_invoked.Steps = (System.Collections.Generic.List<xc.TaskDefine.TaskStep>)translator.GetObject(L, 2, typeof(System.Collections.Generic.List<xc.TaskDefine.TaskStep>));
            
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_ReceiveDialogId(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.TaskDefine __cl_gen_to_be_invoked = (xc.TaskDefine)translator.FastGetCSObj(L, 1);
                __cl_gen_to_be_invoked.ReceiveDialogId = LuaAPI.xlua_touint(L, 2);
            
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_SubmitDialogId(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.TaskDefine __cl_gen_to_be_invoked = (xc.TaskDefine)translator.FastGetCSObj(L, 1);
                __cl_gen_to_be_invoked.SubmitDialogId = LuaAPI.xlua_touint(L, 2);
            
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_ReceiveNpc(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.TaskDefine __cl_gen_to_be_invoked = (xc.TaskDefine)translator.FastGetCSObj(L, 1);
                NpcScenePosition __cl_gen_value;translator.Get(L, 2, out __cl_gen_value);
				__cl_gen_to_be_invoked.ReceiveNpc = __cl_gen_value;
            
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_SubmitNpc(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.TaskDefine __cl_gen_to_be_invoked = (xc.TaskDefine)translator.FastGetCSObj(L, 1);
                NpcScenePosition __cl_gen_value;translator.Get(L, 2, out __cl_gen_value);
				__cl_gen_to_be_invoked.SubmitNpc = __cl_gen_value;
            
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_ShowPriority(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.TaskDefine __cl_gen_to_be_invoked = (xc.TaskDefine)translator.FastGetCSObj(L, 1);
                __cl_gen_to_be_invoked.ShowPriority = (byte)LuaAPI.lua_tonumber(L, 2);
            
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_ShowPriority2(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.TaskDefine __cl_gen_to_be_invoked = (xc.TaskDefine)translator.FastGetCSObj(L, 1);
                __cl_gen_to_be_invoked.ShowPriority2 = (byte)LuaAPI.lua_tonumber(L, 2);
            
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_IsTemporaryOnTop(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.TaskDefine __cl_gen_to_be_invoked = (xc.TaskDefine)translator.FastGetCSObj(L, 1);
                __cl_gen_to_be_invoked.IsTemporaryOnTop = LuaAPI.lua_toboolean(L, 2);
            
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_CreateNpcsWhenReceived(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.TaskDefine __cl_gen_to_be_invoked = (xc.TaskDefine)translator.FastGetCSObj(L, 1);
                __cl_gen_to_be_invoked.CreateNpcsWhenReceived = (System.Collections.Generic.List<NpcScenePosition>)translator.GetObject(L, 2, typeof(System.Collections.Generic.List<NpcScenePosition>));
            
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_DeleteNpcsWhenReceived(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.TaskDefine __cl_gen_to_be_invoked = (xc.TaskDefine)translator.FastGetCSObj(L, 1);
                __cl_gen_to_be_invoked.DeleteNpcsWhenReceived = (System.Collections.Generic.List<NpcScenePosition>)translator.GetObject(L, 2, typeof(System.Collections.Generic.List<NpcScenePosition>));
            
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_CreateNpcsWhenDone(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.TaskDefine __cl_gen_to_be_invoked = (xc.TaskDefine)translator.FastGetCSObj(L, 1);
                __cl_gen_to_be_invoked.CreateNpcsWhenDone = (System.Collections.Generic.List<NpcScenePosition>)translator.GetObject(L, 2, typeof(System.Collections.Generic.List<NpcScenePosition>));
            
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_DeleteNpcsWhenDone(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.TaskDefine __cl_gen_to_be_invoked = (xc.TaskDefine)translator.FastGetCSObj(L, 1);
                __cl_gen_to_be_invoked.DeleteNpcsWhenDone = (System.Collections.Generic.List<NpcScenePosition>)translator.GetObject(L, 2, typeof(System.Collections.Generic.List<NpcScenePosition>));
            
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_FollowNpcs(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.TaskDefine __cl_gen_to_be_invoked = (xc.TaskDefine)translator.FastGetCSObj(L, 1);
                __cl_gen_to_be_invoked.FollowNpcs = (System.Collections.Generic.List<NpcScenePosition>)translator.GetObject(L, 2, typeof(System.Collections.Generic.List<NpcScenePosition>));
            
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_CanUseBoots(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.TaskDefine __cl_gen_to_be_invoked = (xc.TaskDefine)translator.FastGetCSObj(L, 1);
                __cl_gen_to_be_invoked.CanUseBoots = LuaAPI.lua_toboolean(L, 2);
            
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_ReceivedTimelineId(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.TaskDefine __cl_gen_to_be_invoked = (xc.TaskDefine)translator.FastGetCSObj(L, 1);
                __cl_gen_to_be_invoked.ReceivedTimelineId = LuaAPI.xlua_touint(L, 2);
            
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_SubmitedTimelineId(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.TaskDefine __cl_gen_to_be_invoked = (xc.TaskDefine)translator.FastGetCSObj(L, 1);
                __cl_gen_to_be_invoked.SubmitedTimelineId = LuaAPI.xlua_touint(L, 2);
            
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_Costs(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.TaskDefine __cl_gen_to_be_invoked = (xc.TaskDefine)translator.FastGetCSObj(L, 1);
                __cl_gen_to_be_invoked.Costs = (System.Collections.Generic.List<System.Collections.Generic.List<string>>)translator.GetObject(L, 2, typeof(System.Collections.Generic.List<System.Collections.Generic.List<string>>));
            
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_ShowRewardGoodsIds(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.TaskDefine __cl_gen_to_be_invoked = (xc.TaskDefine)translator.FastGetCSObj(L, 1);
                __cl_gen_to_be_invoked.ShowRewardGoodsIds = (System.Collections.Generic.Dictionary<uint, uint>)translator.GetObject(L, 2, typeof(System.Collections.Generic.Dictionary<uint, uint>));
            
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_ShowRewardGoodsNums(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.TaskDefine __cl_gen_to_be_invoked = (xc.TaskDefine)translator.FastGetCSObj(L, 1);
                __cl_gen_to_be_invoked.ShowRewardGoodsNums = (System.Collections.Generic.Dictionary<uint, uint>)translator.GetObject(L, 2, typeof(System.Collections.Generic.Dictionary<uint, uint>));
            
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_ShowRewardGoodsIsBinds(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.TaskDefine __cl_gen_to_be_invoked = (xc.TaskDefine)translator.FastGetCSObj(L, 1);
                __cl_gen_to_be_invoked.ShowRewardGoodsIsBinds = (System.Collections.Generic.Dictionary<uint, byte>)translator.GetObject(L, 2, typeof(System.Collections.Generic.Dictionary<uint, byte>));
            
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 0;
        }
        
		
		
		
		
    }
}
