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
    public class xcFriendsNetWrap
    {
        public static void __Register(RealStatePtr L)
        {
			ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			XUtils.BeginObjectRegister(typeof(xc.FriendsNet), L, translator, 0, 14, 0, 0);
			
			XUtils.RegisterFunc(L, XUtils.METHOD_IDX, "RegisterMessages", _m_RegisterMessages);
			XUtils.RegisterFunc(L, XUtils.METHOD_IDX, "WatchPlayer", _m_WatchPlayer);
			XUtils.RegisterFunc(L, XUtils.METHOD_IDX, "RecommendFriends", _m_RecommendFriends);
			XUtils.RegisterFunc(L, XUtils.METHOD_IDX, "RequestCloser", _m_RequestCloser);
			XUtils.RegisterFunc(L, XUtils.METHOD_IDX, "SearchFriend", _m_SearchFriend);
			XUtils.RegisterFunc(L, XUtils.METHOD_IDX, "GetFriendList", _m_GetFriendList);
			XUtils.RegisterFunc(L, XUtils.METHOD_IDX, "SendAddFriendRequest", _m_SendAddFriendRequest);
			XUtils.RegisterFunc(L, XUtils.METHOD_IDX, "DeleteFriend", _m_DeleteFriend);
			XUtils.RegisterFunc(L, XUtils.METHOD_IDX, "DeleteBlack", _m_DeleteBlack);
			XUtils.RegisterFunc(L, XUtils.METHOD_IDX, "ApproveApplicant", _m_ApproveApplicant);
			XUtils.RegisterFunc(L, XUtils.METHOD_IDX, "RejectApplicant", _m_RejectApplicant);
			XUtils.RegisterFunc(L, XUtils.METHOD_IDX, "CheckFriendInfo", _m_CheckFriendInfo);
			XUtils.RegisterFunc(L, XUtils.METHOD_IDX, "GetPkgBrief", _m_GetPkgBrief);
			XUtils.RegisterFunc(L, XUtils.METHOD_IDX, "HandleServerData", _m_HandleServerData);
			
			
			
			
			XUtils.EndObjectRegister(typeof(xc.FriendsNet), L, translator, null, null,
			    null, null, null);

		    XUtils.BeginClassRegister(typeof(xc.FriendsNet), L, __CreateInstance, 1, 0, 0);
			
			
            
            XUtils.RegisterObject(L, translator, XUtils.CLS_IDX, "UnderlyingSystemType", typeof(xc.FriendsNet));
			
			
			XUtils.EndClassRegister(typeof(xc.FriendsNet), L, translator);
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int __CreateInstance(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			try {
				if(LuaAPI.lua_gettop(L) == 1)
				{
					
					xc.FriendsNet __cl_gen_ret = new xc.FriendsNet();
					translator.Push(L, __cl_gen_ret);
					return 1;
				}
				
			}
			catch(System.Exception __gen_e) {
				return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
			}
            return LuaAPI.luaL_error(L, "invalid arguments to xc.FriendsNet constructor!");
            
        }
        
		
        
		
        
        
        
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_RegisterMessages(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            xc.FriendsNet __cl_gen_to_be_invoked = (xc.FriendsNet)translator.FastGetCSObj(L, 1);
            
            
            try {
                
                {
                    
                    __cl_gen_to_be_invoked.RegisterMessages(  );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_WatchPlayer(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            xc.FriendsNet __cl_gen_to_be_invoked = (xc.FriendsNet)translator.FastGetCSObj(L, 1);
            
            
            try {
                
                {
                    uint uuid = LuaAPI.xlua_touint(L, 2);
                    
                    __cl_gen_to_be_invoked.WatchPlayer( uuid );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_RecommendFriends(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            xc.FriendsNet __cl_gen_to_be_invoked = (xc.FriendsNet)translator.FastGetCSObj(L, 1);
            
            
            try {
                
                {
                    
                    __cl_gen_to_be_invoked.RecommendFriends(  );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_RequestCloser(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            xc.FriendsNet __cl_gen_to_be_invoked = (xc.FriendsNet)translator.FastGetCSObj(L, 1);
            
            
			int __gen_param_count = LuaAPI.lua_gettop(L);
            
            try {
                if(__gen_param_count >= 1&& (LuaTypes.LUA_TNONE == LuaAPI.lua_type(L, 2) || LuaTypes.LUA_TNUMBER == LuaAPI.lua_type(L, 2))) 
                {
                    uint[] uuids = translator.GetParams<uint>(L, 2);
                    
                    __cl_gen_to_be_invoked.RequestCloser( uuids );
                    
                    
                    
                    return 0;
                }
                if(__gen_param_count == 2&& translator.Assignable<System.Collections.Generic.List<uint>>(L, 2)) 
                {
                    System.Collections.Generic.List<uint> uuids = (System.Collections.Generic.List<uint>)translator.GetObject(L, 2, typeof(System.Collections.Generic.List<uint>));
                    
                    __cl_gen_to_be_invoked.RequestCloser( uuids );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
            return LuaAPI.luaL_error(L, "invalid arguments to xc.FriendsNet.RequestCloser!");
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_SearchFriend(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            xc.FriendsNet __cl_gen_to_be_invoked = (xc.FriendsNet)translator.FastGetCSObj(L, 1);
            
            
            try {
                
                {
                    string name = LuaAPI.lua_tostring(L, 2);
                    
                    __cl_gen_to_be_invoked.SearchFriend( name );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_GetFriendList(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            xc.FriendsNet __cl_gen_to_be_invoked = (xc.FriendsNet)translator.FastGetCSObj(L, 1);
            
            
            try {
                
                {
                    xc.FriendType type;translator.Get(L, 2, out type);
                    uint isFirst = LuaAPI.xlua_touint(L, 3);
                    
                    __cl_gen_to_be_invoked.GetFriendList( type, isFirst );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_SendAddFriendRequest(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            xc.FriendsNet __cl_gen_to_be_invoked = (xc.FriendsNet)translator.FastGetCSObj(L, 1);
            
            
			int __gen_param_count = LuaAPI.lua_gettop(L);
            
            try {
                if(__gen_param_count == 4&& translator.Assignable<xc.FriendType>(L, 2)&& LuaTypes.LUA_TNUMBER == LuaAPI.lua_type(L, 3)&& LuaTypes.LUA_TNUMBER == LuaAPI.lua_type(L, 4)) 
                {
                    xc.FriendType type;translator.Get(L, 2, out type);
                    uint id = LuaAPI.xlua_touint(L, 3);
                    uint targetLv = LuaAPI.xlua_touint(L, 4);
                    
                    __cl_gen_to_be_invoked.SendAddFriendRequest( type, id, targetLv );
                    
                    
                    
                    return 0;
                }
                if(__gen_param_count == 3&& translator.Assignable<xc.FriendType>(L, 2)&& LuaTypes.LUA_TNUMBER == LuaAPI.lua_type(L, 3)) 
                {
                    xc.FriendType type;translator.Get(L, 2, out type);
                    uint id = LuaAPI.xlua_touint(L, 3);
                    
                    __cl_gen_to_be_invoked.SendAddFriendRequest( type, id );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
            return LuaAPI.luaL_error(L, "invalid arguments to xc.FriendsNet.SendAddFriendRequest!");
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_DeleteFriend(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            xc.FriendsNet __cl_gen_to_be_invoked = (xc.FriendsNet)translator.FastGetCSObj(L, 1);
            
            
			int __gen_param_count = LuaAPI.lua_gettop(L);
            
            try {
                if(__gen_param_count == 2&& LuaTypes.LUA_TNUMBER == LuaAPI.lua_type(L, 2)) 
                {
                    uint uid = LuaAPI.xlua_touint(L, 2);
                    
                    __cl_gen_to_be_invoked.DeleteFriend( uid );
                    
                    
                    
                    return 0;
                }
                if(__gen_param_count == 3&& translator.Assignable<xc.FriendType>(L, 2)&& translator.Assignable<xc.FriendsInfo>(L, 3)) 
                {
                    xc.FriendType friendType;translator.Get(L, 2, out friendType);
                    xc.FriendsInfo friendInfo = (xc.FriendsInfo)translator.GetObject(L, 3, typeof(xc.FriendsInfo));
                    
                    __cl_gen_to_be_invoked.DeleteFriend( friendType, friendInfo );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
            return LuaAPI.luaL_error(L, "invalid arguments to xc.FriendsNet.DeleteFriend!");
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_DeleteBlack(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            xc.FriendsNet __cl_gen_to_be_invoked = (xc.FriendsNet)translator.FastGetCSObj(L, 1);
            
            
            try {
                
                {
                    uint uid = LuaAPI.xlua_touint(L, 2);
                    
                    __cl_gen_to_be_invoked.DeleteBlack( uid );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_ApproveApplicant(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            xc.FriendsNet __cl_gen_to_be_invoked = (xc.FriendsNet)translator.FastGetCSObj(L, 1);
            
            
            try {
                
                {
                    uint uuid = LuaAPI.xlua_touint(L, 2);
                    
                    __cl_gen_to_be_invoked.ApproveApplicant( uuid );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_RejectApplicant(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            xc.FriendsNet __cl_gen_to_be_invoked = (xc.FriendsNet)translator.FastGetCSObj(L, 1);
            
            
            try {
                
                {
                    uint uuid = LuaAPI.xlua_touint(L, 2);
                    
                    __cl_gen_to_be_invoked.RejectApplicant( uuid );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_CheckFriendInfo(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            xc.FriendsNet __cl_gen_to_be_invoked = (xc.FriendsNet)translator.FastGetCSObj(L, 1);
            
            
            try {
                
                {
                    uint id = LuaAPI.xlua_touint(L, 2);
                    
                    __cl_gen_to_be_invoked.CheckFriendInfo( id );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_GetPkgBrief(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            xc.FriendsNet __cl_gen_to_be_invoked = (xc.FriendsNet)translator.FastGetCSObj(L, 1);
            
            
            try {
                
                {
                    ushort protocol = (ushort)LuaAPI.xlua_tointeger(L, 2);
                    byte[] data = LuaAPI.lua_tobytes(L, 3);
                    
                        Net.PkgPlayerBrief __cl_gen_ret = __cl_gen_to_be_invoked.GetPkgBrief( protocol, data );
                        translator.Push(L, __cl_gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_HandleServerData(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            xc.FriendsNet __cl_gen_to_be_invoked = (xc.FriendsNet)translator.FastGetCSObj(L, 1);
            
            
            try {
                
                {
                    ushort protocol = (ushort)LuaAPI.xlua_tointeger(L, 2);
                    byte[] data = LuaAPI.lua_tobytes(L, 3);
                    
                    __cl_gen_to_be_invoked.HandleServerData( protocol, data );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        
        
        
        
        
		
		
		
		
    }
}
