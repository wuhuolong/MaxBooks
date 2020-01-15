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
    public class xcTeamManagerWrap
    {
        public static void __Register(RealStatePtr L)
        {
			ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			XUtils.BeginObjectRegister(typeof(xc.TeamManager), L, translator, 0, 28, 23, 16);
			
			XUtils.RegisterFunc(L, XUtils.METHOD_IDX, "Reset", _m_Reset);
			XUtils.RegisterFunc(L, XUtils.METHOD_IDX, "RegisterAllMessage", _m_RegisterAllMessage);
			XUtils.RegisterFunc(L, XUtils.METHOD_IDX, "Update", _m_Update);
			XUtils.RegisterFunc(L, XUtils.METHOD_IDX, "BuildTeam", _m_BuildTeam);
			XUtils.RegisterFunc(L, XUtils.METHOD_IDX, "Apply", _m_Apply);
			XUtils.RegisterFunc(L, XUtils.METHOD_IDX, "HandleApply", _m_HandleApply);
			XUtils.RegisterFunc(L, XUtils.METHOD_IDX, "LeaveTeamImmediate", _m_LeaveTeamImmediate);
			XUtils.RegisterFunc(L, XUtils.METHOD_IDX, "LeaveTeam", _m_LeaveTeam);
			XUtils.RegisterFunc(L, XUtils.METHOD_IDX, "Expel", _m_Expel);
			XUtils.RegisterFunc(L, XUtils.METHOD_IDX, "Promote", _m_Promote);
			XUtils.RegisterFunc(L, XUtils.METHOD_IDX, "Invite", _m_Invite);
			XUtils.RegisterFunc(L, XUtils.METHOD_IDX, "GetInviteCD", _m_GetInviteCD);
			XUtils.RegisterFunc(L, XUtils.METHOD_IDX, "GetInviteAllCD", _m_GetInviteAllCD);
			XUtils.RegisterFunc(L, XUtils.METHOD_IDX, "HandleInvite", _m_HandleInvite);
			XUtils.RegisterFunc(L, XUtils.METHOD_IDX, "HandleAllInvites", _m_HandleAllInvites);
			XUtils.RegisterFunc(L, XUtils.METHOD_IDX, "Intro", _m_Intro);
			XUtils.RegisterFunc(L, XUtils.METHOD_IDX, "SetTarget", _m_SetTarget);
			XUtils.RegisterFunc(L, XUtils.METHOD_IDX, "MatchPlayer", _m_MatchPlayer);
			XUtils.RegisterFunc(L, XUtils.METHOD_IDX, "MatchTeam", _m_MatchTeam);
			XUtils.RegisterFunc(L, XUtils.METHOD_IDX, "HaveMember", _m_HaveMember);
			XUtils.RegisterFunc(L, XUtils.METHOD_IDX, "GetMember", _m_GetMember);
			XUtils.RegisterFunc(L, XUtils.METHOD_IDX, "IsMember", _m_IsMember);
			XUtils.RegisterFunc(L, XUtils.METHOD_IDX, "IsLeader", _m_IsLeader);
			XUtils.RegisterFunc(L, XUtils.METHOD_IDX, "RemoveApplyInfo", _m_RemoveApplyInfo);
			XUtils.RegisterFunc(L, XUtils.METHOD_IDX, "IsInApllyList", _m_IsInApllyList);
			XUtils.RegisterFunc(L, XUtils.METHOD_IDX, "ClearBeInvitedInfos", _m_ClearBeInvitedInfos);
			XUtils.RegisterFunc(L, XUtils.METHOD_IDX, "RemoveBeInvitedInfo", _m_RemoveBeInvitedInfo);
			XUtils.RegisterFunc(L, XUtils.METHOD_IDX, "RemoveAllBeInvitedInfos", _m_RemoveAllBeInvitedInfos);
			
			
			XUtils.RegisterFunc(L, XUtils.GETTER_IDX, "TeamId", _g_get_TeamId);
            XUtils.RegisterFunc(L, XUtils.GETTER_IDX, "LeaderId", _g_get_LeaderId);
            XUtils.RegisterFunc(L, XUtils.GETTER_IDX, "TeamMembers", _g_get_TeamMembers);
            XUtils.RegisterFunc(L, XUtils.GETTER_IDX, "ApplyList", _g_get_ApplyList);
            XUtils.RegisterFunc(L, XUtils.GETTER_IDX, "IsAutoMatchingTeam", _g_get_IsAutoMatchingTeam);
            XUtils.RegisterFunc(L, XUtils.GETTER_IDX, "IsAutoMatchingPlayer", _g_get_IsAutoMatchingPlayer);
            XUtils.RegisterFunc(L, XUtils.GETTER_IDX, "IsAutoAgree", _g_get_IsAutoAgree);
            XUtils.RegisterFunc(L, XUtils.GETTER_IDX, "BeInvitedInfos", _g_get_BeInvitedInfos);
            XUtils.RegisterFunc(L, XUtils.GETTER_IDX, "IsAutoRejectInvite", _g_get_IsAutoRejectInvite);
            XUtils.RegisterFunc(L, XUtils.GETTER_IDX, "TargetType", _g_get_TargetType);
            XUtils.RegisterFunc(L, XUtils.GETTER_IDX, "TargetId", _g_get_TargetId);
            XUtils.RegisterFunc(L, XUtils.GETTER_IDX, "TargetMinLevel", _g_get_TargetMinLevel);
            XUtils.RegisterFunc(L, XUtils.GETTER_IDX, "TargetMaxLevel", _g_get_TargetMaxLevel);
            XUtils.RegisterFunc(L, XUtils.GETTER_IDX, "PlatformSelectedTargetType", _g_get_PlatformSelectedTargetType);
            XUtils.RegisterFunc(L, XUtils.GETTER_IDX, "PlatformSelectedTargetId", _g_get_PlatformSelectedTargetId);
            XUtils.RegisterFunc(L, XUtils.GETTER_IDX, "MatchingTeamTargetId", _g_get_MatchingTeamTargetId);
            XUtils.RegisterFunc(L, XUtils.GETTER_IDX, "HaveTeam", _g_get_HaveTeam);
            XUtils.RegisterFunc(L, XUtils.GETTER_IDX, "MemberCount", _g_get_MemberCount);
            XUtils.RegisterFunc(L, XUtils.GETTER_IDX, "Leader", _g_get_Leader);
            XUtils.RegisterFunc(L, XUtils.GETTER_IDX, "IsFull", _g_get_IsFull);
            XUtils.RegisterFunc(L, XUtils.GETTER_IDX, "IsReachTargetMemberLimit", _g_get_IsReachTargetMemberLimit);
            XUtils.RegisterFunc(L, XUtils.GETTER_IDX, "MeIsLeader", _g_get_MeIsLeader);
            XUtils.RegisterFunc(L, XUtils.GETTER_IDX, "MembersExceptLeader", _g_get_MembersExceptLeader);
            
			XUtils.RegisterFunc(L, XUtils.SETTER_IDX, "TeamId", _s_set_TeamId);
            XUtils.RegisterFunc(L, XUtils.SETTER_IDX, "LeaderId", _s_set_LeaderId);
            XUtils.RegisterFunc(L, XUtils.SETTER_IDX, "TeamMembers", _s_set_TeamMembers);
            XUtils.RegisterFunc(L, XUtils.SETTER_IDX, "ApplyList", _s_set_ApplyList);
            XUtils.RegisterFunc(L, XUtils.SETTER_IDX, "IsAutoMatchingTeam", _s_set_IsAutoMatchingTeam);
            XUtils.RegisterFunc(L, XUtils.SETTER_IDX, "IsAutoMatchingPlayer", _s_set_IsAutoMatchingPlayer);
            XUtils.RegisterFunc(L, XUtils.SETTER_IDX, "IsAutoAgree", _s_set_IsAutoAgree);
            XUtils.RegisterFunc(L, XUtils.SETTER_IDX, "BeInvitedInfos", _s_set_BeInvitedInfos);
            XUtils.RegisterFunc(L, XUtils.SETTER_IDX, "IsAutoRejectInvite", _s_set_IsAutoRejectInvite);
            XUtils.RegisterFunc(L, XUtils.SETTER_IDX, "TargetType", _s_set_TargetType);
            XUtils.RegisterFunc(L, XUtils.SETTER_IDX, "TargetId", _s_set_TargetId);
            XUtils.RegisterFunc(L, XUtils.SETTER_IDX, "TargetMinLevel", _s_set_TargetMinLevel);
            XUtils.RegisterFunc(L, XUtils.SETTER_IDX, "TargetMaxLevel", _s_set_TargetMaxLevel);
            XUtils.RegisterFunc(L, XUtils.SETTER_IDX, "PlatformSelectedTargetType", _s_set_PlatformSelectedTargetType);
            XUtils.RegisterFunc(L, XUtils.SETTER_IDX, "PlatformSelectedTargetId", _s_set_PlatformSelectedTargetId);
            XUtils.RegisterFunc(L, XUtils.SETTER_IDX, "MatchingTeamTargetId", _s_set_MatchingTeamTargetId);
            
			XUtils.EndObjectRegister(typeof(xc.TeamManager), L, translator, null, null,
			    null, null, null);

		    XUtils.BeginClassRegister(typeof(xc.TeamManager), L, __CreateInstance, 1, 0, 0);
			
			
            
            XUtils.RegisterObject(L, translator, XUtils.CLS_IDX, "UnderlyingSystemType", typeof(xc.TeamManager));
			
			
			XUtils.EndClassRegister(typeof(xc.TeamManager), L, translator);
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int __CreateInstance(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			try {
				if(LuaAPI.lua_gettop(L) == 1)
				{
					
					xc.TeamManager __cl_gen_ret = new xc.TeamManager();
					translator.Push(L, __cl_gen_ret);
					return 1;
				}
				
			}
			catch(System.Exception __gen_e) {
				return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
			}
            return LuaAPI.luaL_error(L, "invalid arguments to xc.TeamManager constructor!");
            
        }
        
		
        
		
        
        
        
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_Reset(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            xc.TeamManager __cl_gen_to_be_invoked = (xc.TeamManager)translator.FastGetCSObj(L, 1);
            
            
            try {
                
                {
                    bool ignore_reconnect = LuaAPI.lua_toboolean(L, 2);
                    
                    __cl_gen_to_be_invoked.Reset( ignore_reconnect );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_RegisterAllMessage(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            xc.TeamManager __cl_gen_to_be_invoked = (xc.TeamManager)translator.FastGetCSObj(L, 1);
            
            
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
        static int _m_Update(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            xc.TeamManager __cl_gen_to_be_invoked = (xc.TeamManager)translator.FastGetCSObj(L, 1);
            
            
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
        static int _m_BuildTeam(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            xc.TeamManager __cl_gen_to_be_invoked = (xc.TeamManager)translator.FastGetCSObj(L, 1);
            
            
            try {
                
                {
                    
                    __cl_gen_to_be_invoked.BuildTeam(  );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_Apply(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            xc.TeamManager __cl_gen_to_be_invoked = (xc.TeamManager)translator.FastGetCSObj(L, 1);
            
            
            try {
                
                {
                    uint teamId = LuaAPI.xlua_touint(L, 2);
                    
                        bool __cl_gen_ret = __cl_gen_to_be_invoked.Apply( teamId );
                        LuaAPI.lua_pushboolean(L, __cl_gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_HandleApply(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            xc.TeamManager __cl_gen_to_be_invoked = (xc.TeamManager)translator.FastGetCSObj(L, 1);
            
            
            try {
                
                {
                    uint choice = LuaAPI.xlua_touint(L, 2);
                    System.Collections.Generic.List<uint> uuids = (System.Collections.Generic.List<uint>)translator.GetObject(L, 3, typeof(System.Collections.Generic.List<uint>));
                    
                    __cl_gen_to_be_invoked.HandleApply( choice, uuids );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_LeaveTeamImmediate(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            xc.TeamManager __cl_gen_to_be_invoked = (xc.TeamManager)translator.FastGetCSObj(L, 1);
            
            
            try {
                
                {
                    
                    __cl_gen_to_be_invoked.LeaveTeamImmediate(  );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_LeaveTeam(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            xc.TeamManager __cl_gen_to_be_invoked = (xc.TeamManager)translator.FastGetCSObj(L, 1);
            
            
            try {
                
                {
                    
                    __cl_gen_to_be_invoked.LeaveTeam(  );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_Expel(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            xc.TeamManager __cl_gen_to_be_invoked = (xc.TeamManager)translator.FastGetCSObj(L, 1);
            
            
            try {
                
                {
                    uint uuid = LuaAPI.xlua_touint(L, 2);
                    
                    __cl_gen_to_be_invoked.Expel( uuid );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_Promote(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            xc.TeamManager __cl_gen_to_be_invoked = (xc.TeamManager)translator.FastGetCSObj(L, 1);
            
            
            try {
                
                {
                    uint uuid = LuaAPI.xlua_touint(L, 2);
                    
                    __cl_gen_to_be_invoked.Promote( uuid );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_Invite(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            xc.TeamManager __cl_gen_to_be_invoked = (xc.TeamManager)translator.FastGetCSObj(L, 1);
            
            
			int __gen_param_count = LuaAPI.lua_gettop(L);
            
            try {
                if(__gen_param_count == 2&& LuaTypes.LUA_TNUMBER == LuaAPI.lua_type(L, 2)) 
                {
                    uint uuid = LuaAPI.xlua_touint(L, 2);
                    
                        bool __cl_gen_ret = __cl_gen_to_be_invoked.Invite( uuid );
                        LuaAPI.lua_pushboolean(L, __cl_gen_ret);
                    
                    
                    
                    return 1;
                }
                if(__gen_param_count == 2&& translator.Assignable<System.Collections.Generic.List<uint>>(L, 2)) 
                {
                    System.Collections.Generic.List<uint> uuids = (System.Collections.Generic.List<uint>)translator.GetObject(L, 2, typeof(System.Collections.Generic.List<uint>));
                    
                    __cl_gen_to_be_invoked.Invite( uuids );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
            return LuaAPI.luaL_error(L, "invalid arguments to xc.TeamManager.Invite!");
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_GetInviteCD(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            xc.TeamManager __cl_gen_to_be_invoked = (xc.TeamManager)translator.FastGetCSObj(L, 1);
            
            
            try {
                
                {
                    uint uuid = LuaAPI.xlua_touint(L, 2);
                    
                        uint __cl_gen_ret = __cl_gen_to_be_invoked.GetInviteCD( uuid );
                        LuaAPI.xlua_pushuint(L, __cl_gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_GetInviteAllCD(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            xc.TeamManager __cl_gen_to_be_invoked = (xc.TeamManager)translator.FastGetCSObj(L, 1);
            
            
            try {
                
                {
                    
                        uint __cl_gen_ret = __cl_gen_to_be_invoked.GetInviteAllCD(  );
                        LuaAPI.xlua_pushuint(L, __cl_gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_HandleInvite(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            xc.TeamManager __cl_gen_to_be_invoked = (xc.TeamManager)translator.FastGetCSObj(L, 1);
            
            
			int __gen_param_count = LuaAPI.lua_gettop(L);
            
            try {
                if(__gen_param_count == 4&& LuaTypes.LUA_TNUMBER == LuaAPI.lua_type(L, 2)&& LuaTypes.LUA_TNUMBER == LuaAPI.lua_type(L, 3)&& LuaTypes.LUA_TNUMBER == LuaAPI.lua_type(L, 4)) 
                {
                    uint choice = LuaAPI.xlua_touint(L, 2);
                    uint teamId = LuaAPI.xlua_touint(L, 3);
                    uint type = LuaAPI.xlua_touint(L, 4);
                    
                    __cl_gen_to_be_invoked.HandleInvite( choice, teamId, type );
                    
                    
                    
                    return 0;
                }
                if(__gen_param_count == 3&& LuaTypes.LUA_TNUMBER == LuaAPI.lua_type(L, 2)&& LuaTypes.LUA_TNUMBER == LuaAPI.lua_type(L, 3)) 
                {
                    uint choice = LuaAPI.xlua_touint(L, 2);
                    uint teamId = LuaAPI.xlua_touint(L, 3);
                    
                    __cl_gen_to_be_invoked.HandleInvite( choice, teamId );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
            return LuaAPI.luaL_error(L, "invalid arguments to xc.TeamManager.HandleInvite!");
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_HandleAllInvites(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            xc.TeamManager __cl_gen_to_be_invoked = (xc.TeamManager)translator.FastGetCSObj(L, 1);
            
            
			int __gen_param_count = LuaAPI.lua_gettop(L);
            
            try {
                if(__gen_param_count == 3&& LuaTypes.LUA_TNUMBER == LuaAPI.lua_type(L, 2)&& LuaTypes.LUA_TNUMBER == LuaAPI.lua_type(L, 3)) 
                {
                    uint choice = LuaAPI.xlua_touint(L, 2);
                    uint type = LuaAPI.xlua_touint(L, 3);
                    
                    __cl_gen_to_be_invoked.HandleAllInvites( choice, type );
                    
                    
                    
                    return 0;
                }
                if(__gen_param_count == 2&& LuaTypes.LUA_TNUMBER == LuaAPI.lua_type(L, 2)) 
                {
                    uint choice = LuaAPI.xlua_touint(L, 2);
                    
                    __cl_gen_to_be_invoked.HandleAllInvites( choice );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
            return LuaAPI.luaL_error(L, "invalid arguments to xc.TeamManager.HandleAllInvites!");
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_Intro(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            xc.TeamManager __cl_gen_to_be_invoked = (xc.TeamManager)translator.FastGetCSObj(L, 1);
            
            
            try {
                
                {
                    uint teamId = LuaAPI.xlua_touint(L, 2);
                    
                    __cl_gen_to_be_invoked.Intro( teamId );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_SetTarget(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            xc.TeamManager __cl_gen_to_be_invoked = (xc.TeamManager)translator.FastGetCSObj(L, 1);
            
            
            try {
                
                {
                    uint targetId = LuaAPI.xlua_touint(L, 2);
                    uint minLv = LuaAPI.xlua_touint(L, 3);
                    uint maxLv = LuaAPI.xlua_touint(L, 4);
                    
                    __cl_gen_to_be_invoked.SetTarget( targetId, minLv, maxLv );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_MatchPlayer(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            xc.TeamManager __cl_gen_to_be_invoked = (xc.TeamManager)translator.FastGetCSObj(L, 1);
            
            
            try {
                
                {
                    bool isMatch = LuaAPI.lua_toboolean(L, 2);
                    
                    __cl_gen_to_be_invoked.MatchPlayer( isMatch );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_MatchTeam(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            xc.TeamManager __cl_gen_to_be_invoked = (xc.TeamManager)translator.FastGetCSObj(L, 1);
            
            
            try {
                
                {
                    bool isMatch = LuaAPI.lua_toboolean(L, 2);
                    
                    __cl_gen_to_be_invoked.MatchTeam( isMatch );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_HaveMember(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            xc.TeamManager __cl_gen_to_be_invoked = (xc.TeamManager)translator.FastGetCSObj(L, 1);
            
            
            try {
                
                {
                    uint uuid = LuaAPI.xlua_touint(L, 2);
                    
                        bool __cl_gen_ret = __cl_gen_to_be_invoked.HaveMember( uuid );
                        LuaAPI.lua_pushboolean(L, __cl_gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_GetMember(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            xc.TeamManager __cl_gen_to_be_invoked = (xc.TeamManager)translator.FastGetCSObj(L, 1);
            
            
            try {
                
                {
                    uint uuid = LuaAPI.xlua_touint(L, 2);
                    
                        Net.PkgTeamMember __cl_gen_ret = __cl_gen_to_be_invoked.GetMember( uuid );
                        translator.Push(L, __cl_gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_IsMember(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            xc.TeamManager __cl_gen_to_be_invoked = (xc.TeamManager)translator.FastGetCSObj(L, 1);
            
            
            try {
                
                {
                    uint uuid = LuaAPI.xlua_touint(L, 2);
                    
                        bool __cl_gen_ret = __cl_gen_to_be_invoked.IsMember( uuid );
                        LuaAPI.lua_pushboolean(L, __cl_gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_IsLeader(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            xc.TeamManager __cl_gen_to_be_invoked = (xc.TeamManager)translator.FastGetCSObj(L, 1);
            
            
            try {
                
                {
                    uint uuid = LuaAPI.xlua_touint(L, 2);
                    
                        bool __cl_gen_ret = __cl_gen_to_be_invoked.IsLeader( uuid );
                        LuaAPI.lua_pushboolean(L, __cl_gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_RemoveApplyInfo(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            xc.TeamManager __cl_gen_to_be_invoked = (xc.TeamManager)translator.FastGetCSObj(L, 1);
            
            
            try {
                
                {
                    uint uuid = LuaAPI.xlua_touint(L, 2);
                    
                    __cl_gen_to_be_invoked.RemoveApplyInfo( uuid );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_IsInApllyList(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            xc.TeamManager __cl_gen_to_be_invoked = (xc.TeamManager)translator.FastGetCSObj(L, 1);
            
            
            try {
                
                {
                    uint uuid = LuaAPI.xlua_touint(L, 2);
                    
                        bool __cl_gen_ret = __cl_gen_to_be_invoked.IsInApllyList( uuid );
                        LuaAPI.lua_pushboolean(L, __cl_gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_ClearBeInvitedInfos(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            xc.TeamManager __cl_gen_to_be_invoked = (xc.TeamManager)translator.FastGetCSObj(L, 1);
            
            
            try {
                
                {
                    
                    __cl_gen_to_be_invoked.ClearBeInvitedInfos(  );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_RemoveBeInvitedInfo(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            xc.TeamManager __cl_gen_to_be_invoked = (xc.TeamManager)translator.FastGetCSObj(L, 1);
            
            
            try {
                
                {
                    uint teamId = LuaAPI.xlua_touint(L, 2);
                    
                    __cl_gen_to_be_invoked.RemoveBeInvitedInfo( teamId );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_RemoveAllBeInvitedInfos(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            xc.TeamManager __cl_gen_to_be_invoked = (xc.TeamManager)translator.FastGetCSObj(L, 1);
            
            
            try {
                
                {
                    
                    __cl_gen_to_be_invoked.RemoveAllBeInvitedInfos(  );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        
        
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_TeamId(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.TeamManager __cl_gen_to_be_invoked = (xc.TeamManager)translator.FastGetCSObj(L, 1);
                LuaAPI.xlua_pushuint(L, __cl_gen_to_be_invoked.TeamId);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_LeaderId(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.TeamManager __cl_gen_to_be_invoked = (xc.TeamManager)translator.FastGetCSObj(L, 1);
                LuaAPI.xlua_pushuint(L, __cl_gen_to_be_invoked.LeaderId);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_TeamMembers(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.TeamManager __cl_gen_to_be_invoked = (xc.TeamManager)translator.FastGetCSObj(L, 1);
                translator.Push(L, __cl_gen_to_be_invoked.TeamMembers);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_ApplyList(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.TeamManager __cl_gen_to_be_invoked = (xc.TeamManager)translator.FastGetCSObj(L, 1);
                translator.Push(L, __cl_gen_to_be_invoked.ApplyList);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_IsAutoMatchingTeam(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.TeamManager __cl_gen_to_be_invoked = (xc.TeamManager)translator.FastGetCSObj(L, 1);
                LuaAPI.lua_pushboolean(L, __cl_gen_to_be_invoked.IsAutoMatchingTeam);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_IsAutoMatchingPlayer(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.TeamManager __cl_gen_to_be_invoked = (xc.TeamManager)translator.FastGetCSObj(L, 1);
                LuaAPI.lua_pushboolean(L, __cl_gen_to_be_invoked.IsAutoMatchingPlayer);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_IsAutoAgree(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.TeamManager __cl_gen_to_be_invoked = (xc.TeamManager)translator.FastGetCSObj(L, 1);
                LuaAPI.lua_pushboolean(L, __cl_gen_to_be_invoked.IsAutoAgree);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_BeInvitedInfos(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.TeamManager __cl_gen_to_be_invoked = (xc.TeamManager)translator.FastGetCSObj(L, 1);
                translator.Push(L, __cl_gen_to_be_invoked.BeInvitedInfos);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_IsAutoRejectInvite(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.TeamManager __cl_gen_to_be_invoked = (xc.TeamManager)translator.FastGetCSObj(L, 1);
                LuaAPI.lua_pushboolean(L, __cl_gen_to_be_invoked.IsAutoRejectInvite);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_TargetType(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.TeamManager __cl_gen_to_be_invoked = (xc.TeamManager)translator.FastGetCSObj(L, 1);
                LuaAPI.xlua_pushuint(L, __cl_gen_to_be_invoked.TargetType);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_TargetId(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.TeamManager __cl_gen_to_be_invoked = (xc.TeamManager)translator.FastGetCSObj(L, 1);
                LuaAPI.xlua_pushuint(L, __cl_gen_to_be_invoked.TargetId);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_TargetMinLevel(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.TeamManager __cl_gen_to_be_invoked = (xc.TeamManager)translator.FastGetCSObj(L, 1);
                LuaAPI.xlua_pushuint(L, __cl_gen_to_be_invoked.TargetMinLevel);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_TargetMaxLevel(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.TeamManager __cl_gen_to_be_invoked = (xc.TeamManager)translator.FastGetCSObj(L, 1);
                LuaAPI.xlua_pushuint(L, __cl_gen_to_be_invoked.TargetMaxLevel);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_PlatformSelectedTargetType(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.TeamManager __cl_gen_to_be_invoked = (xc.TeamManager)translator.FastGetCSObj(L, 1);
                LuaAPI.xlua_pushuint(L, __cl_gen_to_be_invoked.PlatformSelectedTargetType);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_PlatformSelectedTargetId(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.TeamManager __cl_gen_to_be_invoked = (xc.TeamManager)translator.FastGetCSObj(L, 1);
                LuaAPI.xlua_pushuint(L, __cl_gen_to_be_invoked.PlatformSelectedTargetId);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_MatchingTeamTargetId(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.TeamManager __cl_gen_to_be_invoked = (xc.TeamManager)translator.FastGetCSObj(L, 1);
                LuaAPI.xlua_pushuint(L, __cl_gen_to_be_invoked.MatchingTeamTargetId);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_HaveTeam(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.TeamManager __cl_gen_to_be_invoked = (xc.TeamManager)translator.FastGetCSObj(L, 1);
                LuaAPI.lua_pushboolean(L, __cl_gen_to_be_invoked.HaveTeam);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_MemberCount(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.TeamManager __cl_gen_to_be_invoked = (xc.TeamManager)translator.FastGetCSObj(L, 1);
                LuaAPI.xlua_pushinteger(L, __cl_gen_to_be_invoked.MemberCount);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_Leader(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.TeamManager __cl_gen_to_be_invoked = (xc.TeamManager)translator.FastGetCSObj(L, 1);
                translator.Push(L, __cl_gen_to_be_invoked.Leader);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_IsFull(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.TeamManager __cl_gen_to_be_invoked = (xc.TeamManager)translator.FastGetCSObj(L, 1);
                LuaAPI.lua_pushboolean(L, __cl_gen_to_be_invoked.IsFull);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_IsReachTargetMemberLimit(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.TeamManager __cl_gen_to_be_invoked = (xc.TeamManager)translator.FastGetCSObj(L, 1);
                LuaAPI.lua_pushboolean(L, __cl_gen_to_be_invoked.IsReachTargetMemberLimit);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_MeIsLeader(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.TeamManager __cl_gen_to_be_invoked = (xc.TeamManager)translator.FastGetCSObj(L, 1);
                LuaAPI.lua_pushboolean(L, __cl_gen_to_be_invoked.MeIsLeader);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_MembersExceptLeader(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.TeamManager __cl_gen_to_be_invoked = (xc.TeamManager)translator.FastGetCSObj(L, 1);
                translator.Push(L, __cl_gen_to_be_invoked.MembersExceptLeader);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_TeamId(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.TeamManager __cl_gen_to_be_invoked = (xc.TeamManager)translator.FastGetCSObj(L, 1);
                __cl_gen_to_be_invoked.TeamId = LuaAPI.xlua_touint(L, 2);
            
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_LeaderId(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.TeamManager __cl_gen_to_be_invoked = (xc.TeamManager)translator.FastGetCSObj(L, 1);
                __cl_gen_to_be_invoked.LeaderId = LuaAPI.xlua_touint(L, 2);
            
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_TeamMembers(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.TeamManager __cl_gen_to_be_invoked = (xc.TeamManager)translator.FastGetCSObj(L, 1);
                __cl_gen_to_be_invoked.TeamMembers = (System.Collections.Generic.List<Net.PkgTeamMember>)translator.GetObject(L, 2, typeof(System.Collections.Generic.List<Net.PkgTeamMember>));
            
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_ApplyList(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.TeamManager __cl_gen_to_be_invoked = (xc.TeamManager)translator.FastGetCSObj(L, 1);
                __cl_gen_to_be_invoked.ApplyList = (System.Collections.Generic.List<Net.PkgTeamUserIntro>)translator.GetObject(L, 2, typeof(System.Collections.Generic.List<Net.PkgTeamUserIntro>));
            
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_IsAutoMatchingTeam(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.TeamManager __cl_gen_to_be_invoked = (xc.TeamManager)translator.FastGetCSObj(L, 1);
                __cl_gen_to_be_invoked.IsAutoMatchingTeam = LuaAPI.lua_toboolean(L, 2);
            
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_IsAutoMatchingPlayer(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.TeamManager __cl_gen_to_be_invoked = (xc.TeamManager)translator.FastGetCSObj(L, 1);
                __cl_gen_to_be_invoked.IsAutoMatchingPlayer = LuaAPI.lua_toboolean(L, 2);
            
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_IsAutoAgree(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.TeamManager __cl_gen_to_be_invoked = (xc.TeamManager)translator.FastGetCSObj(L, 1);
                __cl_gen_to_be_invoked.IsAutoAgree = LuaAPI.lua_toboolean(L, 2);
            
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_BeInvitedInfos(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.TeamManager __cl_gen_to_be_invoked = (xc.TeamManager)translator.FastGetCSObj(L, 1);
                __cl_gen_to_be_invoked.BeInvitedInfos = (System.Collections.Generic.List<Net.S2CTeamBeInvite>)translator.GetObject(L, 2, typeof(System.Collections.Generic.List<Net.S2CTeamBeInvite>));
            
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_IsAutoRejectInvite(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.TeamManager __cl_gen_to_be_invoked = (xc.TeamManager)translator.FastGetCSObj(L, 1);
                __cl_gen_to_be_invoked.IsAutoRejectInvite = LuaAPI.lua_toboolean(L, 2);
            
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_TargetType(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.TeamManager __cl_gen_to_be_invoked = (xc.TeamManager)translator.FastGetCSObj(L, 1);
                __cl_gen_to_be_invoked.TargetType = LuaAPI.xlua_touint(L, 2);
            
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_TargetId(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.TeamManager __cl_gen_to_be_invoked = (xc.TeamManager)translator.FastGetCSObj(L, 1);
                __cl_gen_to_be_invoked.TargetId = LuaAPI.xlua_touint(L, 2);
            
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_TargetMinLevel(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.TeamManager __cl_gen_to_be_invoked = (xc.TeamManager)translator.FastGetCSObj(L, 1);
                __cl_gen_to_be_invoked.TargetMinLevel = LuaAPI.xlua_touint(L, 2);
            
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_TargetMaxLevel(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.TeamManager __cl_gen_to_be_invoked = (xc.TeamManager)translator.FastGetCSObj(L, 1);
                __cl_gen_to_be_invoked.TargetMaxLevel = LuaAPI.xlua_touint(L, 2);
            
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_PlatformSelectedTargetType(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.TeamManager __cl_gen_to_be_invoked = (xc.TeamManager)translator.FastGetCSObj(L, 1);
                __cl_gen_to_be_invoked.PlatformSelectedTargetType = LuaAPI.xlua_touint(L, 2);
            
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_PlatformSelectedTargetId(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.TeamManager __cl_gen_to_be_invoked = (xc.TeamManager)translator.FastGetCSObj(L, 1);
                __cl_gen_to_be_invoked.PlatformSelectedTargetId = LuaAPI.xlua_touint(L, 2);
            
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_MatchingTeamTargetId(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.TeamManager __cl_gen_to_be_invoked = (xc.TeamManager)translator.FastGetCSObj(L, 1);
                __cl_gen_to_be_invoked.MatchingTeamTargetId = LuaAPI.xlua_touint(L, 2);
            
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 0;
        }
        
		
		
		
		
    }
}
