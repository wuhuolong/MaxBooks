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
    public class xcFriendsManagerWrap
    {
        public static void __Register(RealStatePtr L)
        {
			ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			XUtils.BeginObjectRegister(typeof(xc.FriendsManager), L, translator, 0, 27, 6, 6);
			
			XUtils.RegisterFunc(L, XUtils.METHOD_IDX, "Reset", _m_Reset);
			XUtils.RegisterFunc(L, XUtils.METHOD_IDX, "SaveCloser", _m_SaveCloser);
			XUtils.RegisterFunc(L, XUtils.METHOD_IDX, "LoadCloser", _m_LoadCloser);
			XUtils.RegisterFunc(L, XUtils.METHOD_IDX, "CreateSelfFriendInfo", _m_CreateSelfFriendInfo);
			XUtils.RegisterFunc(L, XUtils.METHOD_IDX, "CreatePersonSys", _m_CreatePersonSys);
			XUtils.RegisterFunc(L, XUtils.METHOD_IDX, "CreateStrangeData", _m_CreateStrangeData);
			XUtils.RegisterFunc(L, XUtils.METHOD_IDX, "AddStrange", _m_AddStrange);
			XUtils.RegisterFunc(L, XUtils.METHOD_IDX, "AddBlackList", _m_AddBlackList);
			XUtils.RegisterFunc(L, XUtils.METHOD_IDX, "AddApplicant", _m_AddApplicant);
			XUtils.RegisterFunc(L, XUtils.METHOD_IDX, "RemoveApplicant", _m_RemoveApplicant);
			XUtils.RegisterFunc(L, XUtils.METHOD_IDX, "IsCloser", _m_IsCloser);
			XUtils.RegisterFunc(L, XUtils.METHOD_IDX, "IsBlackList", _m_IsBlackList);
			XUtils.RegisterFunc(L, XUtils.METHOD_IDX, "IsEnemyer", _m_IsEnemyer);
			XUtils.RegisterFunc(L, XUtils.METHOD_IDX, "SortFriends", _m_SortFriends);
			XUtils.RegisterFunc(L, XUtils.METHOD_IDX, "GetListByType", _m_GetListByType);
			XUtils.RegisterFunc(L, XUtils.METHOD_IDX, "GetFriend", _m_GetFriend);
			XUtils.RegisterFunc(L, XUtils.METHOD_IDX, "IsStranger", _m_IsStranger);
			XUtils.RegisterFunc(L, XUtils.METHOD_IDX, "IsUnknowPlayer", _m_IsUnknowPlayer);
			XUtils.RegisterFunc(L, XUtils.METHOD_IDX, "IsFriend", _m_IsFriend);
			XUtils.RegisterFunc(L, XUtils.METHOD_IDX, "Remove", _m_Remove);
			XUtils.RegisterFunc(L, XUtils.METHOD_IDX, "AddFriend", _m_AddFriend);
			XUtils.RegisterFunc(L, XUtils.METHOD_IDX, "IsCommonEmpty", _m_IsCommonEmpty);
			XUtils.RegisterFunc(L, XUtils.METHOD_IDX, "UpdateFriendLastChatTime", _m_UpdateFriendLastChatTime);
			XUtils.RegisterFunc(L, XUtils.METHOD_IDX, "UpdateCloserLastChatTime", _m_UpdateCloserLastChatTime);
			XUtils.RegisterFunc(L, XUtils.METHOD_IDX, "GetFriendIntimacy", _m_GetFriendIntimacy);
			XUtils.RegisterFunc(L, XUtils.METHOD_IDX, "AreYouSingle", _m_AreYouSingle);
			XUtils.RegisterFunc(L, XUtils.METHOD_IDX, "GetFriendListSortedByIntimacy", _m_GetFriendListSortedByIntimacy);
			
			
			XUtils.RegisterFunc(L, XUtils.GETTER_IDX, "mCommon", _g_get_mCommon);
            XUtils.RegisterFunc(L, XUtils.GETTER_IDX, "Recommends", _g_get_Recommends);
            XUtils.RegisterFunc(L, XUtils.GETTER_IDX, "Applicants", _g_get_Applicants);
            XUtils.RegisterFunc(L, XUtils.GETTER_IDX, "ListPrivateUid", _g_get_ListPrivateUid);
            XUtils.RegisterFunc(L, XUtils.GETTER_IDX, "ChangeTime", _g_get_ChangeTime);
            XUtils.RegisterFunc(L, XUtils.GETTER_IDX, "isCD", _g_get_isCD);
            
			XUtils.RegisterFunc(L, XUtils.SETTER_IDX, "mCommon", _s_set_mCommon);
            XUtils.RegisterFunc(L, XUtils.SETTER_IDX, "Recommends", _s_set_Recommends);
            XUtils.RegisterFunc(L, XUtils.SETTER_IDX, "Applicants", _s_set_Applicants);
            XUtils.RegisterFunc(L, XUtils.SETTER_IDX, "ListPrivateUid", _s_set_ListPrivateUid);
            XUtils.RegisterFunc(L, XUtils.SETTER_IDX, "ChangeTime", _s_set_ChangeTime);
            XUtils.RegisterFunc(L, XUtils.SETTER_IDX, "isCD", _s_set_isCD);
            
			XUtils.EndObjectRegister(typeof(xc.FriendsManager), L, translator, null, null,
			    null, null, null);

		    XUtils.BeginClassRegister(typeof(xc.FriendsManager), L, __CreateInstance, 1, 0, 0);
			
			
            
            XUtils.RegisterObject(L, translator, XUtils.CLS_IDX, "UnderlyingSystemType", typeof(xc.FriendsManager));
			
			
			XUtils.EndClassRegister(typeof(xc.FriendsManager), L, translator);
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int __CreateInstance(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			try {
				if(LuaAPI.lua_gettop(L) == 1)
				{
					
					xc.FriendsManager __cl_gen_ret = new xc.FriendsManager();
					translator.Push(L, __cl_gen_ret);
					return 1;
				}
				
			}
			catch(System.Exception __gen_e) {
				return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
			}
            return LuaAPI.luaL_error(L, "invalid arguments to xc.FriendsManager constructor!");
            
        }
        
		
        
		
        
        
        
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_Reset(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            xc.FriendsManager __cl_gen_to_be_invoked = (xc.FriendsManager)translator.FastGetCSObj(L, 1);
            
            
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
        static int _m_SaveCloser(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            xc.FriendsManager __cl_gen_to_be_invoked = (xc.FriendsManager)translator.FastGetCSObj(L, 1);
            
            
            try {
                
                {
                    
                    __cl_gen_to_be_invoked.SaveCloser(  );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_LoadCloser(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            xc.FriendsManager __cl_gen_to_be_invoked = (xc.FriendsManager)translator.FastGetCSObj(L, 1);
            
            
            try {
                
                {
                    
                    __cl_gen_to_be_invoked.LoadCloser(  );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_CreateSelfFriendInfo(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            xc.FriendsManager __cl_gen_to_be_invoked = (xc.FriendsManager)translator.FastGetCSObj(L, 1);
            
            
            try {
                
                {
                    
                        xc.FriendsInfo __cl_gen_ret = __cl_gen_to_be_invoked.CreateSelfFriendInfo(  );
                        translator.Push(L, __cl_gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_CreatePersonSys(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            xc.FriendsManager __cl_gen_to_be_invoked = (xc.FriendsManager)translator.FastGetCSObj(L, 1);
            
            
            try {
                
                {
                    
                    __cl_gen_to_be_invoked.CreatePersonSys(  );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_CreateStrangeData(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            xc.FriendsManager __cl_gen_to_be_invoked = (xc.FriendsManager)translator.FastGetCSObj(L, 1);
            
            
            try {
                
                {
                    uint uuid = LuaAPI.xlua_touint(L, 2);
                    string name = LuaAPI.lua_tostring(L, 3);
                    uint level = LuaAPI.xlua_touint(L, 4);
                    uint roleId = LuaAPI.xlua_touint(L, 5);
                    uint teamId = LuaAPI.xlua_touint(L, 6);
                    uint honor = LuaAPI.xlua_touint(L, 7);
                    uint transferLv = LuaAPI.xlua_touint(L, 8);
                    uint vipLv = LuaAPI.xlua_touint(L, 9);
                    
                    __cl_gen_to_be_invoked.CreateStrangeData( uuid, name, level, roleId, teamId, honor, transferLv, vipLv );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_AddStrange(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            xc.FriendsManager __cl_gen_to_be_invoked = (xc.FriendsManager)translator.FastGetCSObj(L, 1);
            
            
            try {
                
                {
                    xc.FriendsInfo info = (xc.FriendsInfo)translator.GetObject(L, 2, typeof(xc.FriendsInfo));
                    bool first = LuaAPI.lua_toboolean(L, 3);
                    
                    __cl_gen_to_be_invoked.AddStrange( info, first );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_AddBlackList(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            xc.FriendsManager __cl_gen_to_be_invoked = (xc.FriendsManager)translator.FastGetCSObj(L, 1);
            
            
            try {
                
                {
                    uint uuid = LuaAPI.xlua_touint(L, 2);
                    
                    __cl_gen_to_be_invoked.AddBlackList( uuid );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_AddApplicant(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            xc.FriendsManager __cl_gen_to_be_invoked = (xc.FriendsManager)translator.FastGetCSObj(L, 1);
            
            
            try {
                
                {
                    xc.FriendsInfo friendsInfo = (xc.FriendsInfo)translator.GetObject(L, 2, typeof(xc.FriendsInfo));
                    
                    __cl_gen_to_be_invoked.AddApplicant( friendsInfo );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_RemoveApplicant(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            xc.FriendsManager __cl_gen_to_be_invoked = (xc.FriendsManager)translator.FastGetCSObj(L, 1);
            
            
			int __gen_param_count = LuaAPI.lua_gettop(L);
            
            try {
                if(__gen_param_count == 2&& LuaTypes.LUA_TNUMBER == LuaAPI.lua_type(L, 2)) 
                {
                    uint uuid = LuaAPI.xlua_touint(L, 2);
                    
                    __cl_gen_to_be_invoked.RemoveApplicant( uuid );
                    
                    
                    
                    return 0;
                }
                if(__gen_param_count == 2&& translator.Assignable<Net.PkgPlayerBrief>(L, 2)) 
                {
                    Net.PkgPlayerBrief pkgPlayerBrief = (Net.PkgPlayerBrief)translator.GetObject(L, 2, typeof(Net.PkgPlayerBrief));
                    
                    __cl_gen_to_be_invoked.RemoveApplicant( pkgPlayerBrief );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
            return LuaAPI.luaL_error(L, "invalid arguments to xc.FriendsManager.RemoveApplicant!");
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_IsCloser(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            xc.FriendsManager __cl_gen_to_be_invoked = (xc.FriendsManager)translator.FastGetCSObj(L, 1);
            
            
            try {
                
                {
                    uint uuid = LuaAPI.xlua_touint(L, 2);
                    
                        bool __cl_gen_ret = __cl_gen_to_be_invoked.IsCloser( uuid );
                        LuaAPI.lua_pushboolean(L, __cl_gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_IsBlackList(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            xc.FriendsManager __cl_gen_to_be_invoked = (xc.FriendsManager)translator.FastGetCSObj(L, 1);
            
            
            try {
                
                {
                    uint uuid = LuaAPI.xlua_touint(L, 2);
                    
                        bool __cl_gen_ret = __cl_gen_to_be_invoked.IsBlackList( uuid );
                        LuaAPI.lua_pushboolean(L, __cl_gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_IsEnemyer(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            xc.FriendsManager __cl_gen_to_be_invoked = (xc.FriendsManager)translator.FastGetCSObj(L, 1);
            
            
            try {
                
                {
                    uint uuid = LuaAPI.xlua_touint(L, 2);
                    
                        bool __cl_gen_ret = __cl_gen_to_be_invoked.IsEnemyer( uuid );
                        LuaAPI.lua_pushboolean(L, __cl_gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_SortFriends(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            xc.FriendsManager __cl_gen_to_be_invoked = (xc.FriendsManager)translator.FastGetCSObj(L, 1);
            
            
            try {
                
                {
                    
                    __cl_gen_to_be_invoked.SortFriends(  );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_GetListByType(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            xc.FriendsManager __cl_gen_to_be_invoked = (xc.FriendsManager)translator.FastGetCSObj(L, 1);
            
            
            try {
                
                {
                    xc.FriendType type;translator.Get(L, 2, out type);
                    
                        System.Collections.Generic.List<xc.FriendsInfo> __cl_gen_ret = __cl_gen_to_be_invoked.GetListByType( type );
                        translator.Push(L, __cl_gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_GetFriend(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            xc.FriendsManager __cl_gen_to_be_invoked = (xc.FriendsManager)translator.FastGetCSObj(L, 1);
            
            
            try {
                
                {
                    xc.FriendType type;translator.Get(L, 2, out type);
                    uint uid = LuaAPI.xlua_touint(L, 3);
                    
                        xc.FriendsInfo __cl_gen_ret = __cl_gen_to_be_invoked.GetFriend( type, uid );
                        translator.Push(L, __cl_gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_IsStranger(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            xc.FriendsManager __cl_gen_to_be_invoked = (xc.FriendsManager)translator.FastGetCSObj(L, 1);
            
            
            try {
                
                {
                    uint uid = LuaAPI.xlua_touint(L, 2);
                    
                        bool __cl_gen_ret = __cl_gen_to_be_invoked.IsStranger( uid );
                        LuaAPI.lua_pushboolean(L, __cl_gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_IsUnknowPlayer(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            xc.FriendsManager __cl_gen_to_be_invoked = (xc.FriendsManager)translator.FastGetCSObj(L, 1);
            
            
            try {
                
                {
                    uint uid = LuaAPI.xlua_touint(L, 2);
                    
                        bool __cl_gen_ret = __cl_gen_to_be_invoked.IsUnknowPlayer( uid );
                        LuaAPI.lua_pushboolean(L, __cl_gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_IsFriend(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            xc.FriendsManager __cl_gen_to_be_invoked = (xc.FriendsManager)translator.FastGetCSObj(L, 1);
            
            
            try {
                
                {
                    uint uid = LuaAPI.xlua_touint(L, 2);
                    
                        bool __cl_gen_ret = __cl_gen_to_be_invoked.IsFriend( uid );
                        LuaAPI.lua_pushboolean(L, __cl_gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_Remove(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            xc.FriendsManager __cl_gen_to_be_invoked = (xc.FriendsManager)translator.FastGetCSObj(L, 1);
            
            
			int __gen_param_count = LuaAPI.lua_gettop(L);
            
            try {
                if(__gen_param_count == 2&& LuaTypes.LUA_TNUMBER == LuaAPI.lua_type(L, 2)) 
                {
                    uint uid = LuaAPI.xlua_touint(L, 2);
                    
                    __cl_gen_to_be_invoked.Remove( uid );
                    
                    
                    
                    return 0;
                }
                if(__gen_param_count == 3&& translator.Assignable<xc.FriendType>(L, 2)&& LuaTypes.LUA_TNUMBER == LuaAPI.lua_type(L, 3)) 
                {
                    xc.FriendType type;translator.Get(L, 2, out type);
                    uint uid = LuaAPI.xlua_touint(L, 3);
                    
                    __cl_gen_to_be_invoked.Remove( type, uid );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
            return LuaAPI.luaL_error(L, "invalid arguments to xc.FriendsManager.Remove!");
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_AddFriend(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            xc.FriendsManager __cl_gen_to_be_invoked = (xc.FriendsManager)translator.FastGetCSObj(L, 1);
            
            
            try {
                
                {
                    xc.FriendType type;translator.Get(L, 2, out type);
                    xc.FriendsInfo friend = (xc.FriendsInfo)translator.GetObject(L, 3, typeof(xc.FriendsInfo));
                    bool isInit = LuaAPI.lua_toboolean(L, 4);
                    
                    __cl_gen_to_be_invoked.AddFriend( type, friend, isInit );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_IsCommonEmpty(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            xc.FriendsManager __cl_gen_to_be_invoked = (xc.FriendsManager)translator.FastGetCSObj(L, 1);
            
            
            try {
                
                {
                    
                        bool __cl_gen_ret = __cl_gen_to_be_invoked.IsCommonEmpty(  );
                        LuaAPI.lua_pushboolean(L, __cl_gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_UpdateFriendLastChatTime(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            xc.FriendsManager __cl_gen_to_be_invoked = (xc.FriendsManager)translator.FastGetCSObj(L, 1);
            
            
            try {
                
                {
                    uint uuid = LuaAPI.xlua_touint(L, 2);
                    
                    __cl_gen_to_be_invoked.UpdateFriendLastChatTime( uuid );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_UpdateCloserLastChatTime(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            xc.FriendsManager __cl_gen_to_be_invoked = (xc.FriendsManager)translator.FastGetCSObj(L, 1);
            
            
            try {
                
                {
                    uint uuid = LuaAPI.xlua_touint(L, 2);
                    
                    __cl_gen_to_be_invoked.UpdateCloserLastChatTime( uuid );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_GetFriendIntimacy(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            xc.FriendsManager __cl_gen_to_be_invoked = (xc.FriendsManager)translator.FastGetCSObj(L, 1);
            
            
            try {
                
                {
                    uint uuid = LuaAPI.xlua_touint(L, 2);
                    
                        uint __cl_gen_ret = __cl_gen_to_be_invoked.GetFriendIntimacy( uuid );
                        LuaAPI.xlua_pushuint(L, __cl_gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_AreYouSingle(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            xc.FriendsManager __cl_gen_to_be_invoked = (xc.FriendsManager)translator.FastGetCSObj(L, 1);
            
            
            try {
                
                {
                    uint uuid = LuaAPI.xlua_touint(L, 2);
                    
                        bool __cl_gen_ret = __cl_gen_to_be_invoked.AreYouSingle( uuid );
                        LuaAPI.lua_pushboolean(L, __cl_gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_GetFriendListSortedByIntimacy(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            xc.FriendsManager __cl_gen_to_be_invoked = (xc.FriendsManager)translator.FastGetCSObj(L, 1);
            
            
            try {
                
                {
                    
                        System.Collections.Generic.List<xc.FriendsInfo> __cl_gen_ret = __cl_gen_to_be_invoked.GetFriendListSortedByIntimacy(  );
                        translator.Push(L, __cl_gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        
        
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_mCommon(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.FriendsManager __cl_gen_to_be_invoked = (xc.FriendsManager)translator.FastGetCSObj(L, 1);
                translator.Push(L, __cl_gen_to_be_invoked.mCommon);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_Recommends(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.FriendsManager __cl_gen_to_be_invoked = (xc.FriendsManager)translator.FastGetCSObj(L, 1);
                translator.Push(L, __cl_gen_to_be_invoked.Recommends);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_Applicants(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.FriendsManager __cl_gen_to_be_invoked = (xc.FriendsManager)translator.FastGetCSObj(L, 1);
                translator.Push(L, __cl_gen_to_be_invoked.Applicants);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_ListPrivateUid(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.FriendsManager __cl_gen_to_be_invoked = (xc.FriendsManager)translator.FastGetCSObj(L, 1);
                LuaAPI.xlua_pushuint(L, __cl_gen_to_be_invoked.ListPrivateUid);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_ChangeTime(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.FriendsManager __cl_gen_to_be_invoked = (xc.FriendsManager)translator.FastGetCSObj(L, 1);
                LuaAPI.xlua_pushuint(L, __cl_gen_to_be_invoked.ChangeTime);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_isCD(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.FriendsManager __cl_gen_to_be_invoked = (xc.FriendsManager)translator.FastGetCSObj(L, 1);
                LuaAPI.lua_pushboolean(L, __cl_gen_to_be_invoked.isCD);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_mCommon(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.FriendsManager __cl_gen_to_be_invoked = (xc.FriendsManager)translator.FastGetCSObj(L, 1);
                __cl_gen_to_be_invoked.mCommon = (System.Collections.Generic.Dictionary<xc.FriendType, System.Collections.Generic.List<xc.FriendsInfo>>)translator.GetObject(L, 2, typeof(System.Collections.Generic.Dictionary<xc.FriendType, System.Collections.Generic.List<xc.FriendsInfo>>));
            
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_Recommends(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.FriendsManager __cl_gen_to_be_invoked = (xc.FriendsManager)translator.FastGetCSObj(L, 1);
                __cl_gen_to_be_invoked.Recommends = (System.Collections.Generic.List<xc.FriendsInfo>)translator.GetObject(L, 2, typeof(System.Collections.Generic.List<xc.FriendsInfo>));
            
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_Applicants(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.FriendsManager __cl_gen_to_be_invoked = (xc.FriendsManager)translator.FastGetCSObj(L, 1);
                __cl_gen_to_be_invoked.Applicants = (System.Collections.Generic.List<xc.FriendsInfo>)translator.GetObject(L, 2, typeof(System.Collections.Generic.List<xc.FriendsInfo>));
            
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_ListPrivateUid(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.FriendsManager __cl_gen_to_be_invoked = (xc.FriendsManager)translator.FastGetCSObj(L, 1);
                __cl_gen_to_be_invoked.ListPrivateUid = LuaAPI.xlua_touint(L, 2);
            
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_ChangeTime(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.FriendsManager __cl_gen_to_be_invoked = (xc.FriendsManager)translator.FastGetCSObj(L, 1);
                __cl_gen_to_be_invoked.ChangeTime = LuaAPI.xlua_touint(L, 2);
            
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_isCD(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.FriendsManager __cl_gen_to_be_invoked = (xc.FriendsManager)translator.FastGetCSObj(L, 1);
                __cl_gen_to_be_invoked.isCD = LuaAPI.lua_toboolean(L, 2);
            
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 0;
        }
        
		
		
		
		
    }
}
