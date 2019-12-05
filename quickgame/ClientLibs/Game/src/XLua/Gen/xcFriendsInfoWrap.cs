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
    public class xcFriendsInfoWrap
    {
        public static void __Register(RealStatePtr L)
        {
			ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			XUtils.BeginObjectRegister(typeof(xc.FriendsInfo), L, translator, 0, 2, 29, 29);
			
			XUtils.RegisterFunc(L, XUtils.METHOD_IDX, "Copy", _m_Copy);
			XUtils.RegisterFunc(L, XUtils.METHOD_IDX, "UpdateOnlineState", _m_UpdateOnlineState);
			
			
			XUtils.RegisterFunc(L, XUtils.GETTER_IDX, "Friendtype", _g_get_Friendtype);
            XUtils.RegisterFunc(L, XUtils.GETTER_IDX, "BattlePower", _g_get_BattlePower);
            XUtils.RegisterFunc(L, XUtils.GETTER_IDX, "Friendly", _g_get_Friendly);
            XUtils.RegisterFunc(L, XUtils.GETTER_IDX, "Name", _g_get_Name);
            XUtils.RegisterFunc(L, XUtils.GETTER_IDX, "SocietyName", _g_get_SocietyName);
            XUtils.RegisterFunc(L, XUtils.GETTER_IDX, "SocietyPos", _g_get_SocietyPos);
            XUtils.RegisterFunc(L, XUtils.GETTER_IDX, "Level", _g_get_Level);
            XUtils.RegisterFunc(L, XUtils.GETTER_IDX, "HiLevel", _g_get_HiLevel);
            XUtils.RegisterFunc(L, XUtils.GETTER_IDX, "Honor", _g_get_Honor);
            XUtils.RegisterFunc(L, XUtils.GETTER_IDX, "Online", _g_get_Online);
            XUtils.RegisterFunc(L, XUtils.GETTER_IDX, "RoleId", _g_get_RoleId);
            XUtils.RegisterFunc(L, XUtils.GETTER_IDX, "Uid", _g_get_Uid);
            XUtils.RegisterFunc(L, XUtils.GETTER_IDX, "TeamId", _g_get_TeamId);
            XUtils.RegisterFunc(L, XUtils.GETTER_IDX, "NewMsg", _g_get_NewMsg);
            XUtils.RegisterFunc(L, XUtils.GETTER_IDX, "LastChatTime", _g_get_LastChatTime);
            XUtils.RegisterFunc(L, XUtils.GETTER_IDX, "IsFirst", _g_get_IsFirst);
            XUtils.RegisterFunc(L, XUtils.GETTER_IDX, "TransferLv", _g_get_TransferLv);
            XUtils.RegisterFunc(L, XUtils.GETTER_IDX, "VipLv", _g_get_VipLv);
            XUtils.RegisterFunc(L, XUtils.GETTER_IDX, "BubbleId", _g_get_BubbleId);
            XUtils.RegisterFunc(L, XUtils.GETTER_IDX, "PhotoFrameId", _g_get_PhotoFrameId);
            XUtils.RegisterFunc(L, XUtils.GETTER_IDX, "MateUUID", _g_get_MateUUID);
            XUtils.RegisterFunc(L, XUtils.GETTER_IDX, "MateName", _g_get_MateName);
            XUtils.RegisterFunc(L, XUtils.GETTER_IDX, "EnemyPos", _g_get_EnemyPos);
            XUtils.RegisterFunc(L, XUtils.GETTER_IDX, "Intimacy", _g_get_Intimacy);
            XUtils.RegisterFunc(L, XUtils.GETTER_IDX, "EnemyInfo", _g_get_EnemyInfo);
            XUtils.RegisterFunc(L, XUtils.GETTER_IDX, "MapType", _g_get_MapType);
            XUtils.RegisterFunc(L, XUtils.GETTER_IDX, "MapId", _g_get_MapId);
            XUtils.RegisterFunc(L, XUtils.GETTER_IDX, "Interactive", _g_get_Interactive);
            XUtils.RegisterFunc(L, XUtils.GETTER_IDX, "IsSys", _g_get_IsSys);
            
			XUtils.RegisterFunc(L, XUtils.SETTER_IDX, "Friendtype", _s_set_Friendtype);
            XUtils.RegisterFunc(L, XUtils.SETTER_IDX, "BattlePower", _s_set_BattlePower);
            XUtils.RegisterFunc(L, XUtils.SETTER_IDX, "Friendly", _s_set_Friendly);
            XUtils.RegisterFunc(L, XUtils.SETTER_IDX, "Name", _s_set_Name);
            XUtils.RegisterFunc(L, XUtils.SETTER_IDX, "SocietyName", _s_set_SocietyName);
            XUtils.RegisterFunc(L, XUtils.SETTER_IDX, "SocietyPos", _s_set_SocietyPos);
            XUtils.RegisterFunc(L, XUtils.SETTER_IDX, "Level", _s_set_Level);
            XUtils.RegisterFunc(L, XUtils.SETTER_IDX, "HiLevel", _s_set_HiLevel);
            XUtils.RegisterFunc(L, XUtils.SETTER_IDX, "Honor", _s_set_Honor);
            XUtils.RegisterFunc(L, XUtils.SETTER_IDX, "Online", _s_set_Online);
            XUtils.RegisterFunc(L, XUtils.SETTER_IDX, "RoleId", _s_set_RoleId);
            XUtils.RegisterFunc(L, XUtils.SETTER_IDX, "Uid", _s_set_Uid);
            XUtils.RegisterFunc(L, XUtils.SETTER_IDX, "TeamId", _s_set_TeamId);
            XUtils.RegisterFunc(L, XUtils.SETTER_IDX, "NewMsg", _s_set_NewMsg);
            XUtils.RegisterFunc(L, XUtils.SETTER_IDX, "LastChatTime", _s_set_LastChatTime);
            XUtils.RegisterFunc(L, XUtils.SETTER_IDX, "IsFirst", _s_set_IsFirst);
            XUtils.RegisterFunc(L, XUtils.SETTER_IDX, "TransferLv", _s_set_TransferLv);
            XUtils.RegisterFunc(L, XUtils.SETTER_IDX, "VipLv", _s_set_VipLv);
            XUtils.RegisterFunc(L, XUtils.SETTER_IDX, "BubbleId", _s_set_BubbleId);
            XUtils.RegisterFunc(L, XUtils.SETTER_IDX, "PhotoFrameId", _s_set_PhotoFrameId);
            XUtils.RegisterFunc(L, XUtils.SETTER_IDX, "MateUUID", _s_set_MateUUID);
            XUtils.RegisterFunc(L, XUtils.SETTER_IDX, "MateName", _s_set_MateName);
            XUtils.RegisterFunc(L, XUtils.SETTER_IDX, "EnemyPos", _s_set_EnemyPos);
            XUtils.RegisterFunc(L, XUtils.SETTER_IDX, "Intimacy", _s_set_Intimacy);
            XUtils.RegisterFunc(L, XUtils.SETTER_IDX, "EnemyInfo", _s_set_EnemyInfo);
            XUtils.RegisterFunc(L, XUtils.SETTER_IDX, "MapType", _s_set_MapType);
            XUtils.RegisterFunc(L, XUtils.SETTER_IDX, "MapId", _s_set_MapId);
            XUtils.RegisterFunc(L, XUtils.SETTER_IDX, "Interactive", _s_set_Interactive);
            XUtils.RegisterFunc(L, XUtils.SETTER_IDX, "IsSys", _s_set_IsSys);
            
			XUtils.EndObjectRegister(typeof(xc.FriendsInfo), L, translator, null, null,
			    null, null, null);

		    XUtils.BeginClassRegister(typeof(xc.FriendsInfo), L, __CreateInstance, 1, 0, 0);
			
			
            
            XUtils.RegisterObject(L, translator, XUtils.CLS_IDX, "UnderlyingSystemType", typeof(xc.FriendsInfo));
			
			
			XUtils.EndClassRegister(typeof(xc.FriendsInfo), L, translator);
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int __CreateInstance(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			try {
				if(LuaAPI.lua_gettop(L) == 14 && LuaTypes.LUA_TNUMBER == LuaAPI.lua_type(L, 2) && (LuaAPI.lua_isnil(L, 3) || LuaAPI.lua_type(L, 3) == LuaTypes.LUA_TSTRING) && LuaTypes.LUA_TNUMBER == LuaAPI.lua_type(L, 4) && LuaTypes.LUA_TNUMBER == LuaAPI.lua_type(L, 5) && LuaTypes.LUA_TBOOLEAN == LuaAPI.lua_type(L, 6) && LuaTypes.LUA_TNUMBER == LuaAPI.lua_type(L, 7) && LuaTypes.LUA_TNUMBER == LuaAPI.lua_type(L, 8) && LuaTypes.LUA_TNUMBER == LuaAPI.lua_type(L, 9) && LuaTypes.LUA_TNUMBER == LuaAPI.lua_type(L, 10) && LuaTypes.LUA_TNUMBER == LuaAPI.lua_type(L, 11) && (LuaAPI.lua_isnil(L, 12) || LuaAPI.lua_type(L, 12) == LuaTypes.LUA_TSTRING) && LuaTypes.LUA_TNUMBER == LuaAPI.lua_type(L, 13) && LuaTypes.LUA_TNUMBER == LuaAPI.lua_type(L, 14))
				{
					uint uuid = LuaAPI.xlua_touint(L, 2);
					string name = LuaAPI.lua_tostring(L, 3);
					uint level = LuaAPI.xlua_touint(L, 4);
					uint roleId = LuaAPI.xlua_touint(L, 5);
					bool online = LuaAPI.lua_toboolean(L, 6);
					uint teamId = LuaAPI.xlua_touint(L, 7);
					uint honor = LuaAPI.xlua_touint(L, 8);
					uint transferLv = LuaAPI.xlua_touint(L, 9);
					uint vipLv = LuaAPI.xlua_touint(L, 10);
					uint mateUUID = LuaAPI.xlua_touint(L, 11);
					string mateName = LuaAPI.lua_tostring(L, 12);
					uint BubbleId = LuaAPI.xlua_touint(L, 13);
					uint PhotoFrameId = LuaAPI.xlua_touint(L, 14);
					
					xc.FriendsInfo __cl_gen_ret = new xc.FriendsInfo(uuid, name, level, roleId, online, teamId, honor, transferLv, vipLv, mateUUID, mateName, BubbleId, PhotoFrameId);
					translator.Push(L, __cl_gen_ret);
					return 1;
				}
				if(LuaAPI.lua_gettop(L) == 13 && LuaTypes.LUA_TNUMBER == LuaAPI.lua_type(L, 2) && (LuaAPI.lua_isnil(L, 3) || LuaAPI.lua_type(L, 3) == LuaTypes.LUA_TSTRING) && LuaTypes.LUA_TNUMBER == LuaAPI.lua_type(L, 4) && LuaTypes.LUA_TNUMBER == LuaAPI.lua_type(L, 5) && LuaTypes.LUA_TBOOLEAN == LuaAPI.lua_type(L, 6) && LuaTypes.LUA_TNUMBER == LuaAPI.lua_type(L, 7) && LuaTypes.LUA_TNUMBER == LuaAPI.lua_type(L, 8) && LuaTypes.LUA_TNUMBER == LuaAPI.lua_type(L, 9) && LuaTypes.LUA_TNUMBER == LuaAPI.lua_type(L, 10) && LuaTypes.LUA_TNUMBER == LuaAPI.lua_type(L, 11) && (LuaAPI.lua_isnil(L, 12) || LuaAPI.lua_type(L, 12) == LuaTypes.LUA_TSTRING) && LuaTypes.LUA_TNUMBER == LuaAPI.lua_type(L, 13))
				{
					uint uuid = LuaAPI.xlua_touint(L, 2);
					string name = LuaAPI.lua_tostring(L, 3);
					uint level = LuaAPI.xlua_touint(L, 4);
					uint roleId = LuaAPI.xlua_touint(L, 5);
					bool online = LuaAPI.lua_toboolean(L, 6);
					uint teamId = LuaAPI.xlua_touint(L, 7);
					uint honor = LuaAPI.xlua_touint(L, 8);
					uint transferLv = LuaAPI.xlua_touint(L, 9);
					uint vipLv = LuaAPI.xlua_touint(L, 10);
					uint mateUUID = LuaAPI.xlua_touint(L, 11);
					string mateName = LuaAPI.lua_tostring(L, 12);
					uint BubbleId = LuaAPI.xlua_touint(L, 13);
					
					xc.FriendsInfo __cl_gen_ret = new xc.FriendsInfo(uuid, name, level, roleId, online, teamId, honor, transferLv, vipLv, mateUUID, mateName, BubbleId);
					translator.Push(L, __cl_gen_ret);
					return 1;
				}
				if(LuaAPI.lua_gettop(L) == 12 && LuaTypes.LUA_TNUMBER == LuaAPI.lua_type(L, 2) && (LuaAPI.lua_isnil(L, 3) || LuaAPI.lua_type(L, 3) == LuaTypes.LUA_TSTRING) && LuaTypes.LUA_TNUMBER == LuaAPI.lua_type(L, 4) && LuaTypes.LUA_TNUMBER == LuaAPI.lua_type(L, 5) && LuaTypes.LUA_TBOOLEAN == LuaAPI.lua_type(L, 6) && LuaTypes.LUA_TNUMBER == LuaAPI.lua_type(L, 7) && LuaTypes.LUA_TNUMBER == LuaAPI.lua_type(L, 8) && LuaTypes.LUA_TNUMBER == LuaAPI.lua_type(L, 9) && LuaTypes.LUA_TNUMBER == LuaAPI.lua_type(L, 10) && LuaTypes.LUA_TNUMBER == LuaAPI.lua_type(L, 11) && (LuaAPI.lua_isnil(L, 12) || LuaAPI.lua_type(L, 12) == LuaTypes.LUA_TSTRING))
				{
					uint uuid = LuaAPI.xlua_touint(L, 2);
					string name = LuaAPI.lua_tostring(L, 3);
					uint level = LuaAPI.xlua_touint(L, 4);
					uint roleId = LuaAPI.xlua_touint(L, 5);
					bool online = LuaAPI.lua_toboolean(L, 6);
					uint teamId = LuaAPI.xlua_touint(L, 7);
					uint honor = LuaAPI.xlua_touint(L, 8);
					uint transferLv = LuaAPI.xlua_touint(L, 9);
					uint vipLv = LuaAPI.xlua_touint(L, 10);
					uint mateUUID = LuaAPI.xlua_touint(L, 11);
					string mateName = LuaAPI.lua_tostring(L, 12);
					
					xc.FriendsInfo __cl_gen_ret = new xc.FriendsInfo(uuid, name, level, roleId, online, teamId, honor, transferLv, vipLv, mateUUID, mateName);
					translator.Push(L, __cl_gen_ret);
					return 1;
				}
				if(LuaAPI.lua_gettop(L) == 11 && LuaTypes.LUA_TNUMBER == LuaAPI.lua_type(L, 2) && (LuaAPI.lua_isnil(L, 3) || LuaAPI.lua_type(L, 3) == LuaTypes.LUA_TSTRING) && LuaTypes.LUA_TNUMBER == LuaAPI.lua_type(L, 4) && LuaTypes.LUA_TNUMBER == LuaAPI.lua_type(L, 5) && LuaTypes.LUA_TBOOLEAN == LuaAPI.lua_type(L, 6) && LuaTypes.LUA_TNUMBER == LuaAPI.lua_type(L, 7) && LuaTypes.LUA_TNUMBER == LuaAPI.lua_type(L, 8) && LuaTypes.LUA_TNUMBER == LuaAPI.lua_type(L, 9) && LuaTypes.LUA_TNUMBER == LuaAPI.lua_type(L, 10) && LuaTypes.LUA_TNUMBER == LuaAPI.lua_type(L, 11))
				{
					uint uuid = LuaAPI.xlua_touint(L, 2);
					string name = LuaAPI.lua_tostring(L, 3);
					uint level = LuaAPI.xlua_touint(L, 4);
					uint roleId = LuaAPI.xlua_touint(L, 5);
					bool online = LuaAPI.lua_toboolean(L, 6);
					uint teamId = LuaAPI.xlua_touint(L, 7);
					uint honor = LuaAPI.xlua_touint(L, 8);
					uint transferLv = LuaAPI.xlua_touint(L, 9);
					uint vipLv = LuaAPI.xlua_touint(L, 10);
					uint mateUUID = LuaAPI.xlua_touint(L, 11);
					
					xc.FriendsInfo __cl_gen_ret = new xc.FriendsInfo(uuid, name, level, roleId, online, teamId, honor, transferLv, vipLv, mateUUID);
					translator.Push(L, __cl_gen_ret);
					return 1;
				}
				if(LuaAPI.lua_gettop(L) == 10 && LuaTypes.LUA_TNUMBER == LuaAPI.lua_type(L, 2) && (LuaAPI.lua_isnil(L, 3) || LuaAPI.lua_type(L, 3) == LuaTypes.LUA_TSTRING) && LuaTypes.LUA_TNUMBER == LuaAPI.lua_type(L, 4) && LuaTypes.LUA_TNUMBER == LuaAPI.lua_type(L, 5) && LuaTypes.LUA_TBOOLEAN == LuaAPI.lua_type(L, 6) && LuaTypes.LUA_TNUMBER == LuaAPI.lua_type(L, 7) && LuaTypes.LUA_TNUMBER == LuaAPI.lua_type(L, 8) && LuaTypes.LUA_TNUMBER == LuaAPI.lua_type(L, 9) && LuaTypes.LUA_TNUMBER == LuaAPI.lua_type(L, 10))
				{
					uint uuid = LuaAPI.xlua_touint(L, 2);
					string name = LuaAPI.lua_tostring(L, 3);
					uint level = LuaAPI.xlua_touint(L, 4);
					uint roleId = LuaAPI.xlua_touint(L, 5);
					bool online = LuaAPI.lua_toboolean(L, 6);
					uint teamId = LuaAPI.xlua_touint(L, 7);
					uint honor = LuaAPI.xlua_touint(L, 8);
					uint transferLv = LuaAPI.xlua_touint(L, 9);
					uint vipLv = LuaAPI.xlua_touint(L, 10);
					
					xc.FriendsInfo __cl_gen_ret = new xc.FriendsInfo(uuid, name, level, roleId, online, teamId, honor, transferLv, vipLv);
					translator.Push(L, __cl_gen_ret);
					return 1;
				}
				if(LuaAPI.lua_gettop(L) == 2 && translator.Assignable<Net.PkgPlayerBrief>(L, 2))
				{
					Net.PkgPlayerBrief player_brief = (Net.PkgPlayerBrief)translator.GetObject(L, 2, typeof(Net.PkgPlayerBrief));
					
					xc.FriendsInfo __cl_gen_ret = new xc.FriendsInfo(player_brief);
					translator.Push(L, __cl_gen_ret);
					return 1;
				}
				if(LuaAPI.lua_gettop(L) == 1)
				{
					
					xc.FriendsInfo __cl_gen_ret = new xc.FriendsInfo();
					translator.Push(L, __cl_gen_ret);
					return 1;
				}
				
			}
			catch(System.Exception __gen_e) {
				return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
			}
            return LuaAPI.luaL_error(L, "invalid arguments to xc.FriendsInfo constructor!");
            
        }
        
		
        
		
        
        
        
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_Copy(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            xc.FriendsInfo __cl_gen_to_be_invoked = (xc.FriendsInfo)translator.FastGetCSObj(L, 1);
            
            
            try {
                
                {
                    xc.FriendsInfo friend = (xc.FriendsInfo)translator.GetObject(L, 2, typeof(xc.FriendsInfo));
                    
                    __cl_gen_to_be_invoked.Copy( friend );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_UpdateOnlineState(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            xc.FriendsInfo __cl_gen_to_be_invoked = (xc.FriendsInfo)translator.FastGetCSObj(L, 1);
            
            
            try {
                
                {
                    uint online = LuaAPI.xlua_touint(L, 2);
                    
                    __cl_gen_to_be_invoked.UpdateOnlineState( online );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        
        
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_Friendtype(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.FriendsInfo __cl_gen_to_be_invoked = (xc.FriendsInfo)translator.FastGetCSObj(L, 1);
                translator.PushxcFriendType(L, __cl_gen_to_be_invoked.Friendtype);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_BattlePower(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.FriendsInfo __cl_gen_to_be_invoked = (xc.FriendsInfo)translator.FastGetCSObj(L, 1);
                LuaAPI.lua_pushint64(L, __cl_gen_to_be_invoked.BattlePower);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_Friendly(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.FriendsInfo __cl_gen_to_be_invoked = (xc.FriendsInfo)translator.FastGetCSObj(L, 1);
                LuaAPI.xlua_pushuint(L, __cl_gen_to_be_invoked.Friendly);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_Name(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.FriendsInfo __cl_gen_to_be_invoked = (xc.FriendsInfo)translator.FastGetCSObj(L, 1);
                LuaAPI.lua_pushstring(L, __cl_gen_to_be_invoked.Name);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_SocietyName(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.FriendsInfo __cl_gen_to_be_invoked = (xc.FriendsInfo)translator.FastGetCSObj(L, 1);
                LuaAPI.lua_pushstring(L, __cl_gen_to_be_invoked.SocietyName);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_SocietyPos(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.FriendsInfo __cl_gen_to_be_invoked = (xc.FriendsInfo)translator.FastGetCSObj(L, 1);
                LuaAPI.xlua_pushuint(L, __cl_gen_to_be_invoked.SocietyPos);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_Level(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.FriendsInfo __cl_gen_to_be_invoked = (xc.FriendsInfo)translator.FastGetCSObj(L, 1);
                LuaAPI.xlua_pushuint(L, __cl_gen_to_be_invoked.Level);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_HiLevel(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.FriendsInfo __cl_gen_to_be_invoked = (xc.FriendsInfo)translator.FastGetCSObj(L, 1);
                LuaAPI.xlua_pushuint(L, __cl_gen_to_be_invoked.HiLevel);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_Honor(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.FriendsInfo __cl_gen_to_be_invoked = (xc.FriendsInfo)translator.FastGetCSObj(L, 1);
                LuaAPI.xlua_pushuint(L, __cl_gen_to_be_invoked.Honor);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_Online(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.FriendsInfo __cl_gen_to_be_invoked = (xc.FriendsInfo)translator.FastGetCSObj(L, 1);
                LuaAPI.lua_pushboolean(L, __cl_gen_to_be_invoked.Online);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_RoleId(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.FriendsInfo __cl_gen_to_be_invoked = (xc.FriendsInfo)translator.FastGetCSObj(L, 1);
                LuaAPI.xlua_pushuint(L, __cl_gen_to_be_invoked.RoleId);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_Uid(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.FriendsInfo __cl_gen_to_be_invoked = (xc.FriendsInfo)translator.FastGetCSObj(L, 1);
                LuaAPI.xlua_pushuint(L, __cl_gen_to_be_invoked.Uid);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_TeamId(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.FriendsInfo __cl_gen_to_be_invoked = (xc.FriendsInfo)translator.FastGetCSObj(L, 1);
                LuaAPI.xlua_pushuint(L, __cl_gen_to_be_invoked.TeamId);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_NewMsg(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.FriendsInfo __cl_gen_to_be_invoked = (xc.FriendsInfo)translator.FastGetCSObj(L, 1);
                LuaAPI.lua_pushboolean(L, __cl_gen_to_be_invoked.NewMsg);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_LastChatTime(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.FriendsInfo __cl_gen_to_be_invoked = (xc.FriendsInfo)translator.FastGetCSObj(L, 1);
                LuaAPI.xlua_pushuint(L, __cl_gen_to_be_invoked.LastChatTime);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_IsFirst(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.FriendsInfo __cl_gen_to_be_invoked = (xc.FriendsInfo)translator.FastGetCSObj(L, 1);
                LuaAPI.lua_pushboolean(L, __cl_gen_to_be_invoked.IsFirst);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_TransferLv(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.FriendsInfo __cl_gen_to_be_invoked = (xc.FriendsInfo)translator.FastGetCSObj(L, 1);
                LuaAPI.xlua_pushuint(L, __cl_gen_to_be_invoked.TransferLv);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_VipLv(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.FriendsInfo __cl_gen_to_be_invoked = (xc.FriendsInfo)translator.FastGetCSObj(L, 1);
                LuaAPI.xlua_pushuint(L, __cl_gen_to_be_invoked.VipLv);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_BubbleId(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.FriendsInfo __cl_gen_to_be_invoked = (xc.FriendsInfo)translator.FastGetCSObj(L, 1);
                LuaAPI.xlua_pushuint(L, __cl_gen_to_be_invoked.BubbleId);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_PhotoFrameId(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.FriendsInfo __cl_gen_to_be_invoked = (xc.FriendsInfo)translator.FastGetCSObj(L, 1);
                LuaAPI.xlua_pushuint(L, __cl_gen_to_be_invoked.PhotoFrameId);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_MateUUID(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.FriendsInfo __cl_gen_to_be_invoked = (xc.FriendsInfo)translator.FastGetCSObj(L, 1);
                LuaAPI.xlua_pushuint(L, __cl_gen_to_be_invoked.MateUUID);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_MateName(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.FriendsInfo __cl_gen_to_be_invoked = (xc.FriendsInfo)translator.FastGetCSObj(L, 1);
                LuaAPI.lua_pushstring(L, __cl_gen_to_be_invoked.MateName);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_EnemyPos(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.FriendsInfo __cl_gen_to_be_invoked = (xc.FriendsInfo)translator.FastGetCSObj(L, 1);
                translator.PushUnityEngineVector3(L, __cl_gen_to_be_invoked.EnemyPos);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_Intimacy(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.FriendsInfo __cl_gen_to_be_invoked = (xc.FriendsInfo)translator.FastGetCSObj(L, 1);
                LuaAPI.xlua_pushuint(L, __cl_gen_to_be_invoked.Intimacy);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_EnemyInfo(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.FriendsInfo __cl_gen_to_be_invoked = (xc.FriendsInfo)translator.FastGetCSObj(L, 1);
                translator.Push(L, __cl_gen_to_be_invoked.EnemyInfo);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_MapType(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.FriendsInfo __cl_gen_to_be_invoked = (xc.FriendsInfo)translator.FastGetCSObj(L, 1);
                LuaAPI.xlua_pushuint(L, __cl_gen_to_be_invoked.MapType);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_MapId(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.FriendsInfo __cl_gen_to_be_invoked = (xc.FriendsInfo)translator.FastGetCSObj(L, 1);
                LuaAPI.xlua_pushuint(L, __cl_gen_to_be_invoked.MapId);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_Interactive(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.FriendsInfo __cl_gen_to_be_invoked = (xc.FriendsInfo)translator.FastGetCSObj(L, 1);
                translator.PushxcInteractiveType(L, __cl_gen_to_be_invoked.Interactive);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_IsSys(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.FriendsInfo __cl_gen_to_be_invoked = (xc.FriendsInfo)translator.FastGetCSObj(L, 1);
                LuaAPI.lua_pushboolean(L, __cl_gen_to_be_invoked.IsSys);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_Friendtype(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.FriendsInfo __cl_gen_to_be_invoked = (xc.FriendsInfo)translator.FastGetCSObj(L, 1);
                xc.FriendType __cl_gen_value;translator.Get(L, 2, out __cl_gen_value);
				__cl_gen_to_be_invoked.Friendtype = __cl_gen_value;
            
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_BattlePower(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.FriendsInfo __cl_gen_to_be_invoked = (xc.FriendsInfo)translator.FastGetCSObj(L, 1);
                __cl_gen_to_be_invoked.BattlePower = LuaAPI.lua_toint64(L, 2);
            
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_Friendly(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.FriendsInfo __cl_gen_to_be_invoked = (xc.FriendsInfo)translator.FastGetCSObj(L, 1);
                __cl_gen_to_be_invoked.Friendly = LuaAPI.xlua_touint(L, 2);
            
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_Name(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.FriendsInfo __cl_gen_to_be_invoked = (xc.FriendsInfo)translator.FastGetCSObj(L, 1);
                __cl_gen_to_be_invoked.Name = LuaAPI.lua_tostring(L, 2);
            
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_SocietyName(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.FriendsInfo __cl_gen_to_be_invoked = (xc.FriendsInfo)translator.FastGetCSObj(L, 1);
                __cl_gen_to_be_invoked.SocietyName = LuaAPI.lua_tostring(L, 2);
            
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_SocietyPos(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.FriendsInfo __cl_gen_to_be_invoked = (xc.FriendsInfo)translator.FastGetCSObj(L, 1);
                __cl_gen_to_be_invoked.SocietyPos = LuaAPI.xlua_touint(L, 2);
            
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_Level(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.FriendsInfo __cl_gen_to_be_invoked = (xc.FriendsInfo)translator.FastGetCSObj(L, 1);
                __cl_gen_to_be_invoked.Level = LuaAPI.xlua_touint(L, 2);
            
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_HiLevel(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.FriendsInfo __cl_gen_to_be_invoked = (xc.FriendsInfo)translator.FastGetCSObj(L, 1);
                __cl_gen_to_be_invoked.HiLevel = LuaAPI.xlua_touint(L, 2);
            
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_Honor(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.FriendsInfo __cl_gen_to_be_invoked = (xc.FriendsInfo)translator.FastGetCSObj(L, 1);
                __cl_gen_to_be_invoked.Honor = LuaAPI.xlua_touint(L, 2);
            
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_Online(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.FriendsInfo __cl_gen_to_be_invoked = (xc.FriendsInfo)translator.FastGetCSObj(L, 1);
                __cl_gen_to_be_invoked.Online = LuaAPI.lua_toboolean(L, 2);
            
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_RoleId(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.FriendsInfo __cl_gen_to_be_invoked = (xc.FriendsInfo)translator.FastGetCSObj(L, 1);
                __cl_gen_to_be_invoked.RoleId = LuaAPI.xlua_touint(L, 2);
            
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_Uid(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.FriendsInfo __cl_gen_to_be_invoked = (xc.FriendsInfo)translator.FastGetCSObj(L, 1);
                __cl_gen_to_be_invoked.Uid = LuaAPI.xlua_touint(L, 2);
            
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_TeamId(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.FriendsInfo __cl_gen_to_be_invoked = (xc.FriendsInfo)translator.FastGetCSObj(L, 1);
                __cl_gen_to_be_invoked.TeamId = LuaAPI.xlua_touint(L, 2);
            
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_NewMsg(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.FriendsInfo __cl_gen_to_be_invoked = (xc.FriendsInfo)translator.FastGetCSObj(L, 1);
                __cl_gen_to_be_invoked.NewMsg = LuaAPI.lua_toboolean(L, 2);
            
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_LastChatTime(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.FriendsInfo __cl_gen_to_be_invoked = (xc.FriendsInfo)translator.FastGetCSObj(L, 1);
                __cl_gen_to_be_invoked.LastChatTime = LuaAPI.xlua_touint(L, 2);
            
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_IsFirst(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.FriendsInfo __cl_gen_to_be_invoked = (xc.FriendsInfo)translator.FastGetCSObj(L, 1);
                __cl_gen_to_be_invoked.IsFirst = LuaAPI.lua_toboolean(L, 2);
            
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_TransferLv(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.FriendsInfo __cl_gen_to_be_invoked = (xc.FriendsInfo)translator.FastGetCSObj(L, 1);
                __cl_gen_to_be_invoked.TransferLv = LuaAPI.xlua_touint(L, 2);
            
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_VipLv(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.FriendsInfo __cl_gen_to_be_invoked = (xc.FriendsInfo)translator.FastGetCSObj(L, 1);
                __cl_gen_to_be_invoked.VipLv = LuaAPI.xlua_touint(L, 2);
            
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_BubbleId(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.FriendsInfo __cl_gen_to_be_invoked = (xc.FriendsInfo)translator.FastGetCSObj(L, 1);
                __cl_gen_to_be_invoked.BubbleId = LuaAPI.xlua_touint(L, 2);
            
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_PhotoFrameId(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.FriendsInfo __cl_gen_to_be_invoked = (xc.FriendsInfo)translator.FastGetCSObj(L, 1);
                __cl_gen_to_be_invoked.PhotoFrameId = LuaAPI.xlua_touint(L, 2);
            
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_MateUUID(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.FriendsInfo __cl_gen_to_be_invoked = (xc.FriendsInfo)translator.FastGetCSObj(L, 1);
                __cl_gen_to_be_invoked.MateUUID = LuaAPI.xlua_touint(L, 2);
            
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_MateName(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.FriendsInfo __cl_gen_to_be_invoked = (xc.FriendsInfo)translator.FastGetCSObj(L, 1);
                __cl_gen_to_be_invoked.MateName = LuaAPI.lua_tostring(L, 2);
            
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_EnemyPos(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.FriendsInfo __cl_gen_to_be_invoked = (xc.FriendsInfo)translator.FastGetCSObj(L, 1);
                UnityEngine.Vector3 __cl_gen_value;translator.Get(L, 2, out __cl_gen_value);
				__cl_gen_to_be_invoked.EnemyPos = __cl_gen_value;
            
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_Intimacy(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.FriendsInfo __cl_gen_to_be_invoked = (xc.FriendsInfo)translator.FastGetCSObj(L, 1);
                __cl_gen_to_be_invoked.Intimacy = LuaAPI.xlua_touint(L, 2);
            
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_EnemyInfo(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.FriendsInfo __cl_gen_to_be_invoked = (xc.FriendsInfo)translator.FastGetCSObj(L, 1);
                __cl_gen_to_be_invoked.EnemyInfo = (Net.PkgNwarPos)translator.GetObject(L, 2, typeof(Net.PkgNwarPos));
            
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_MapType(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.FriendsInfo __cl_gen_to_be_invoked = (xc.FriendsInfo)translator.FastGetCSObj(L, 1);
                __cl_gen_to_be_invoked.MapType = LuaAPI.xlua_touint(L, 2);
            
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_MapId(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.FriendsInfo __cl_gen_to_be_invoked = (xc.FriendsInfo)translator.FastGetCSObj(L, 1);
                __cl_gen_to_be_invoked.MapId = LuaAPI.xlua_touint(L, 2);
            
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_Interactive(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.FriendsInfo __cl_gen_to_be_invoked = (xc.FriendsInfo)translator.FastGetCSObj(L, 1);
                xc.InteractiveType __cl_gen_value;translator.Get(L, 2, out __cl_gen_value);
				__cl_gen_to_be_invoked.Interactive = __cl_gen_value;
            
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_IsSys(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.FriendsInfo __cl_gen_to_be_invoked = (xc.FriendsInfo)translator.FastGetCSObj(L, 1);
                __cl_gen_to_be_invoked.IsSys = LuaAPI.lua_toboolean(L, 2);
            
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 0;
        }
        
		
		
		
		
    }
}
