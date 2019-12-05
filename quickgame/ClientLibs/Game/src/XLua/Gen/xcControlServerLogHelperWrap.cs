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
    public class xcControlServerLogHelperWrap
    {
        public static void __Register(RealStatePtr L)
        {
			ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			XUtils.BeginObjectRegister(typeof(xc.ControlServerLogHelper), L, translator, 0, 22, 0, 0);
			
			XUtils.RegisterFunc(L, XUtils.METHOD_IDX, "OnPostDeviceInitFinished", _m_OnPostDeviceInitFinished);
			XUtils.RegisterFunc(L, XUtils.METHOD_IDX, "PostDeviceInit", _m_PostDeviceInit);
			XUtils.RegisterFunc(L, XUtils.METHOD_IDX, "PostRoleInfoWithDelay", _m_PostRoleInfoWithDelay);
			XUtils.RegisterFunc(L, XUtils.METHOD_IDX, "OnPostRoleInfoFinished", _m_OnPostRoleInfoFinished);
			XUtils.RegisterFunc(L, XUtils.METHOD_IDX, "PostRoleInfo", _m_PostRoleInfo);
			XUtils.RegisterFunc(L, XUtils.METHOD_IDX, "PostStartClientLog", _m_PostStartClientLog);
			XUtils.RegisterFunc(L, XUtils.METHOD_IDX, "PostAccountLoginLogS", _m_PostAccountLoginLogS);
			XUtils.RegisterFunc(L, XUtils.METHOD_IDX, "OnGetPackFinished", _m_OnGetPackFinished);
			XUtils.RegisterFunc(L, XUtils.METHOD_IDX, "PostGetPack", _m_PostGetPack);
			XUtils.RegisterFunc(L, XUtils.METHOD_IDX, "GetFeedbackInfo", _m_GetFeedbackInfo);
			XUtils.RegisterFunc(L, XUtils.METHOD_IDX, "OnGetFeedbackInfo", _m_OnGetFeedbackInfo);
			XUtils.RegisterFunc(L, XUtils.METHOD_IDX, "PostFeedback", _m_PostFeedback);
			XUtils.RegisterFunc(L, XUtils.METHOD_IDX, "OnFeedback", _m_OnFeedback);
			XUtils.RegisterFunc(L, XUtils.METHOD_IDX, "LoadImage", _m_LoadImage);
			XUtils.RegisterFunc(L, XUtils.METHOD_IDX, "_LoadImage", _m__LoadImage);
			XUtils.RegisterFunc(L, XUtils.METHOD_IDX, "PostPlayerFollowRecord", _m_PostPlayerFollowRecord);
			XUtils.RegisterFunc(L, XUtils.METHOD_IDX, "GetChannelList", _m_GetChannelList);
			XUtils.RegisterFunc(L, XUtils.METHOD_IDX, "OnGetChannelList", _m_OnGetChannelList);
			XUtils.RegisterFunc(L, XUtils.METHOD_IDX, "GetChannelName", _m_GetChannelName);
			XUtils.RegisterFunc(L, XUtils.METHOD_IDX, "GetServerList", _m_GetServerList);
			XUtils.RegisterFunc(L, XUtils.METHOD_IDX, "OnGetServerList", _m_OnGetServerList);
			XUtils.RegisterFunc(L, XUtils.METHOD_IDX, "PostCloudLadderEventAction", _m_PostCloudLadderEventAction);
			
			
			
			
			XUtils.EndObjectRegister(typeof(xc.ControlServerLogHelper), L, translator, null, null,
			    null, null, null);

		    XUtils.BeginClassRegister(typeof(xc.ControlServerLogHelper), L, __CreateInstance, 3, 0, 0);
			XUtils.RegisterFunc(L, XUtils.CLS_IDX, "CreatePkgAccPhoneInfos", _m_CreatePkgAccPhoneInfos_xlua_st_);
            XUtils.RegisterFunc(L, XUtils.CLS_IDX, "SendMobileInfo", _m_SendMobileInfo_xlua_st_);
            
			
            
            XUtils.RegisterObject(L, translator, XUtils.CLS_IDX, "UnderlyingSystemType", typeof(xc.ControlServerLogHelper));
			
			
			XUtils.EndClassRegister(typeof(xc.ControlServerLogHelper), L, translator);
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int __CreateInstance(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			try {
				if(LuaAPI.lua_gettop(L) == 1)
				{
					
					xc.ControlServerLogHelper __cl_gen_ret = new xc.ControlServerLogHelper();
					translator.Push(L, __cl_gen_ret);
					return 1;
				}
				
			}
			catch(System.Exception __gen_e) {
				return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
			}
            return LuaAPI.luaL_error(L, "invalid arguments to xc.ControlServerLogHelper constructor!");
            
        }
        
		
        
		
        
        
        
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_OnPostDeviceInitFinished(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            xc.ControlServerLogHelper __cl_gen_to_be_invoked = (xc.ControlServerLogHelper)translator.FastGetCSObj(L, 1);
            
            
            try {
                
                {
                    string url = LuaAPI.lua_tostring(L, 2);
                    string error = LuaAPI.lua_tostring(L, 3);
                    string reply = LuaAPI.lua_tostring(L, 4);
                    object userData = translator.GetObject(L, 5, typeof(object));
                    
                    __cl_gen_to_be_invoked.OnPostDeviceInitFinished( url, error, reply, userData );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_PostDeviceInit(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            xc.ControlServerLogHelper __cl_gen_to_be_invoked = (xc.ControlServerLogHelper)translator.FastGetCSObj(L, 1);
            
            
			int __gen_param_count = LuaAPI.lua_gettop(L);
            
            try {
                if(__gen_param_count == 2&& translator.Assignable<System.Action<bool>>(L, 2)) 
                {
                    System.Action<bool> callback = translator.GetDelegate<System.Action<bool>>(L, 2);
                    
                    __cl_gen_to_be_invoked.PostDeviceInit( callback );
                    
                    
                    
                    return 0;
                }
                if(__gen_param_count == 1) 
                {
                    
                    __cl_gen_to_be_invoked.PostDeviceInit(  );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
            return LuaAPI.luaL_error(L, "invalid arguments to xc.ControlServerLogHelper.PostDeviceInit!");
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_PostRoleInfoWithDelay(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            xc.ControlServerLogHelper __cl_gen_to_be_invoked = (xc.ControlServerLogHelper)translator.FastGetCSObj(L, 1);
            
            
            try {
                
                {
                    float remainTime = (float)LuaAPI.lua_tonumber(L, 2);
                    
                    __cl_gen_to_be_invoked.PostRoleInfoWithDelay( remainTime );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_OnPostRoleInfoFinished(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            xc.ControlServerLogHelper __cl_gen_to_be_invoked = (xc.ControlServerLogHelper)translator.FastGetCSObj(L, 1);
            
            
            try {
                
                {
                    string url = LuaAPI.lua_tostring(L, 2);
                    string error = LuaAPI.lua_tostring(L, 3);
                    string reply = LuaAPI.lua_tostring(L, 4);
                    object userData = translator.GetObject(L, 5, typeof(object));
                    
                    __cl_gen_to_be_invoked.OnPostRoleInfoFinished( url, error, reply, userData );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_PostRoleInfo(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            xc.ControlServerLogHelper __cl_gen_to_be_invoked = (xc.ControlServerLogHelper)translator.FastGetCSObj(L, 1);
            
            
            try {
                
                {
                    
                    __cl_gen_to_be_invoked.PostRoleInfo(  );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_PostStartClientLog(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            xc.ControlServerLogHelper __cl_gen_to_be_invoked = (xc.ControlServerLogHelper)translator.FastGetCSObj(L, 1);
            
            
            try {
                
                {
                    
                    __cl_gen_to_be_invoked.PostStartClientLog(  );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_PostAccountLoginLogS(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            xc.ControlServerLogHelper __cl_gen_to_be_invoked = (xc.ControlServerLogHelper)translator.FastGetCSObj(L, 1);
            
            
            try {
                
                {
                    int serverId = LuaAPI.xlua_tointeger(L, 2);
                    xc.EServerState serverType;translator.Get(L, 3, out serverType);
                    
                    __cl_gen_to_be_invoked.PostAccountLoginLogS( serverId, serverType );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_OnGetPackFinished(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            xc.ControlServerLogHelper __cl_gen_to_be_invoked = (xc.ControlServerLogHelper)translator.FastGetCSObj(L, 1);
            
            
            try {
                
                {
                    string url = LuaAPI.lua_tostring(L, 2);
                    string error = LuaAPI.lua_tostring(L, 3);
                    string reply = LuaAPI.lua_tostring(L, 4);
                    object userData = translator.GetObject(L, 5, typeof(object));
                    
                    __cl_gen_to_be_invoked.OnGetPackFinished( url, error, reply, userData );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_PostGetPack(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            xc.ControlServerLogHelper __cl_gen_to_be_invoked = (xc.ControlServerLogHelper)translator.FastGetCSObj(L, 1);
            
            
			int __gen_param_count = LuaAPI.lua_gettop(L);
            
            try {
                if(__gen_param_count == 3&& (LuaAPI.lua_isnil(L, 2) || LuaAPI.lua_type(L, 2) == LuaTypes.LUA_TSTRING)&& translator.Assignable<System.Action<bool>>(L, 3)) 
                {
                    string code = LuaAPI.lua_tostring(L, 2);
                    System.Action<bool> callback = translator.GetDelegate<System.Action<bool>>(L, 3);
                    
                    __cl_gen_to_be_invoked.PostGetPack( code, callback );
                    
                    
                    
                    return 0;
                }
                if(__gen_param_count == 2&& (LuaAPI.lua_isnil(L, 2) || LuaAPI.lua_type(L, 2) == LuaTypes.LUA_TSTRING)) 
                {
                    string code = LuaAPI.lua_tostring(L, 2);
                    
                    __cl_gen_to_be_invoked.PostGetPack( code );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
            return LuaAPI.luaL_error(L, "invalid arguments to xc.ControlServerLogHelper.PostGetPack!");
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_CreatePkgAccPhoneInfos_xlua_st_(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            
            try {
                
                {
                    System.Collections.Generic.List<Net.PkgAccPhoneInfo> infos = (System.Collections.Generic.List<Net.PkgAccPhoneInfo>)translator.GetObject(L, 1, typeof(System.Collections.Generic.List<Net.PkgAccPhoneInfo>));
                    
                    xc.ControlServerLogHelper.CreatePkgAccPhoneInfos( infos );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_SendMobileInfo_xlua_st_(RealStatePtr L)
        {
            
            
            
            try {
                
                {
                    
                    xc.ControlServerLogHelper.SendMobileInfo(  );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_GetFeedbackInfo(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            xc.ControlServerLogHelper __cl_gen_to_be_invoked = (xc.ControlServerLogHelper)translator.FastGetCSObj(L, 1);
            
            
			int __gen_param_count = LuaAPI.lua_gettop(L);
            
            try {
                if(__gen_param_count == 2&& translator.Assignable<System.Action<XLua.LuaTable>>(L, 2)) 
                {
                    System.Action<XLua.LuaTable> callback = translator.GetDelegate<System.Action<XLua.LuaTable>>(L, 2);
                    
                    __cl_gen_to_be_invoked.GetFeedbackInfo( callback );
                    
                    
                    
                    return 0;
                }
                if(__gen_param_count == 1) 
                {
                    
                    __cl_gen_to_be_invoked.GetFeedbackInfo(  );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
            return LuaAPI.luaL_error(L, "invalid arguments to xc.ControlServerLogHelper.GetFeedbackInfo!");
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_OnGetFeedbackInfo(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            xc.ControlServerLogHelper __cl_gen_to_be_invoked = (xc.ControlServerLogHelper)translator.FastGetCSObj(L, 1);
            
            
            try {
                
                {
                    string url = LuaAPI.lua_tostring(L, 2);
                    string error = LuaAPI.lua_tostring(L, 3);
                    string reply = LuaAPI.lua_tostring(L, 4);
                    object userData = translator.GetObject(L, 5, typeof(object));
                    
                    __cl_gen_to_be_invoked.OnGetFeedbackInfo( url, error, reply, userData );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_PostFeedback(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            xc.ControlServerLogHelper __cl_gen_to_be_invoked = (xc.ControlServerLogHelper)translator.FastGetCSObj(L, 1);
            
            
			int __gen_param_count = LuaAPI.lua_gettop(L);
            
            try {
                if(__gen_param_count == 4&& LuaTypes.LUA_TNUMBER == LuaAPI.lua_type(L, 2)&& (LuaAPI.lua_isnil(L, 3) || LuaAPI.lua_type(L, 3) == LuaTypes.LUA_TSTRING)&& translator.Assignable<System.Action<bool>>(L, 4)) 
                {
                    int type = LuaAPI.xlua_tointeger(L, 2);
                    string msg = LuaAPI.lua_tostring(L, 3);
                    System.Action<bool> callback = translator.GetDelegate<System.Action<bool>>(L, 4);
                    
                    __cl_gen_to_be_invoked.PostFeedback( type, msg, callback );
                    
                    
                    
                    return 0;
                }
                if(__gen_param_count == 3&& LuaTypes.LUA_TNUMBER == LuaAPI.lua_type(L, 2)&& (LuaAPI.lua_isnil(L, 3) || LuaAPI.lua_type(L, 3) == LuaTypes.LUA_TSTRING)) 
                {
                    int type = LuaAPI.xlua_tointeger(L, 2);
                    string msg = LuaAPI.lua_tostring(L, 3);
                    
                    __cl_gen_to_be_invoked.PostFeedback( type, msg );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
            return LuaAPI.luaL_error(L, "invalid arguments to xc.ControlServerLogHelper.PostFeedback!");
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_OnFeedback(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            xc.ControlServerLogHelper __cl_gen_to_be_invoked = (xc.ControlServerLogHelper)translator.FastGetCSObj(L, 1);
            
            
            try {
                
                {
                    string url = LuaAPI.lua_tostring(L, 2);
                    string error = LuaAPI.lua_tostring(L, 3);
                    string reply = LuaAPI.lua_tostring(L, 4);
                    object userData = translator.GetObject(L, 5, typeof(object));
                    
                    __cl_gen_to_be_invoked.OnFeedback( url, error, reply, userData );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_LoadImage(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            xc.ControlServerLogHelper __cl_gen_to_be_invoked = (xc.ControlServerLogHelper)translator.FastGetCSObj(L, 1);
            
            
            try {
                
                {
                    string path = LuaAPI.lua_tostring(L, 2);
                    System.Action<UnityEngine.Sprite> callback = translator.GetDelegate<System.Action<UnityEngine.Sprite>>(L, 3);
                    
                    __cl_gen_to_be_invoked.LoadImage( path, callback );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m__LoadImage(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            xc.ControlServerLogHelper __cl_gen_to_be_invoked = (xc.ControlServerLogHelper)translator.FastGetCSObj(L, 1);
            
            
            try {
                
                {
                    string path = LuaAPI.lua_tostring(L, 2);
                    System.Action<UnityEngine.Sprite> callback = translator.GetDelegate<System.Action<UnityEngine.Sprite>>(L, 3);
                    
                        System.Collections.IEnumerator __cl_gen_ret = __cl_gen_to_be_invoked._LoadImage( path, callback );
                        translator.Push(L, __cl_gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_PostPlayerFollowRecord(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            xc.ControlServerLogHelper __cl_gen_to_be_invoked = (xc.ControlServerLogHelper)translator.FastGetCSObj(L, 1);
            
            
			int __gen_param_count = LuaAPI.lua_gettop(L);
            
            try {
                if(__gen_param_count == 4&& translator.Assignable<xc.PlayerFollowRecordSceneId>(L, 2)&& (LuaAPI.lua_isnil(L, 3) || LuaAPI.lua_type(L, 3) == LuaTypes.LUA_TSTRING)&& LuaTypes.LUA_TBOOLEAN == LuaAPI.lua_type(L, 4)) 
                {
                    xc.PlayerFollowRecordSceneId sceneId;translator.Get(L, 2, out sceneId);
                    string desc = LuaAPI.lua_tostring(L, 3);
                    bool isEnterGame = LuaAPI.lua_toboolean(L, 4);
                    
                    __cl_gen_to_be_invoked.PostPlayerFollowRecord( sceneId, desc, isEnterGame );
                    
                    
                    
                    return 0;
                }
                if(__gen_param_count == 3&& translator.Assignable<xc.PlayerFollowRecordSceneId>(L, 2)&& (LuaAPI.lua_isnil(L, 3) || LuaAPI.lua_type(L, 3) == LuaTypes.LUA_TSTRING)) 
                {
                    xc.PlayerFollowRecordSceneId sceneId;translator.Get(L, 2, out sceneId);
                    string desc = LuaAPI.lua_tostring(L, 3);
                    
                    __cl_gen_to_be_invoked.PostPlayerFollowRecord( sceneId, desc );
                    
                    
                    
                    return 0;
                }
                if(__gen_param_count == 2&& translator.Assignable<xc.PlayerFollowRecordSceneId>(L, 2)) 
                {
                    xc.PlayerFollowRecordSceneId sceneId;translator.Get(L, 2, out sceneId);
                    
                    __cl_gen_to_be_invoked.PostPlayerFollowRecord( sceneId );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
            return LuaAPI.luaL_error(L, "invalid arguments to xc.ControlServerLogHelper.PostPlayerFollowRecord!");
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_GetChannelList(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            xc.ControlServerLogHelper __cl_gen_to_be_invoked = (xc.ControlServerLogHelper)translator.FastGetCSObj(L, 1);
            
            
			int __gen_param_count = LuaAPI.lua_gettop(L);
            
            try {
                if(__gen_param_count == 2&& LuaTypes.LUA_TNUMBER == LuaAPI.lua_type(L, 2)) 
                {
                    uint channelId = LuaAPI.xlua_touint(L, 2);
                    
                    __cl_gen_to_be_invoked.GetChannelList( channelId );
                    
                    
                    
                    return 0;
                }
                if(__gen_param_count == 1) 
                {
                    
                    __cl_gen_to_be_invoked.GetChannelList(  );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
            return LuaAPI.luaL_error(L, "invalid arguments to xc.ControlServerLogHelper.GetChannelList!");
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_OnGetChannelList(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            xc.ControlServerLogHelper __cl_gen_to_be_invoked = (xc.ControlServerLogHelper)translator.FastGetCSObj(L, 1);
            
            
            try {
                
                {
                    string url = LuaAPI.lua_tostring(L, 2);
                    string error = LuaAPI.lua_tostring(L, 3);
                    string reply = LuaAPI.lua_tostring(L, 4);
                    object userData = translator.GetObject(L, 5, typeof(object));
                    
                    __cl_gen_to_be_invoked.OnGetChannelList( url, error, reply, userData );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_GetChannelName(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            xc.ControlServerLogHelper __cl_gen_to_be_invoked = (xc.ControlServerLogHelper)translator.FastGetCSObj(L, 1);
            
            
            try {
                
                {
                    string channel = LuaAPI.lua_tostring(L, 2);
                    
                        string __cl_gen_ret = __cl_gen_to_be_invoked.GetChannelName( channel );
                        LuaAPI.lua_pushstring(L, __cl_gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_GetServerList(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            xc.ControlServerLogHelper __cl_gen_to_be_invoked = (xc.ControlServerLogHelper)translator.FastGetCSObj(L, 1);
            
            
            try {
                
                {
                    
                    __cl_gen_to_be_invoked.GetServerList(  );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_OnGetServerList(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            xc.ControlServerLogHelper __cl_gen_to_be_invoked = (xc.ControlServerLogHelper)translator.FastGetCSObj(L, 1);
            
            
            try {
                
                {
                    string url = LuaAPI.lua_tostring(L, 2);
                    string error = LuaAPI.lua_tostring(L, 3);
                    string reply = LuaAPI.lua_tostring(L, 4);
                    object userData = translator.GetObject(L, 5, typeof(object));
                    
                    __cl_gen_to_be_invoked.OnGetServerList( url, error, reply, userData );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_PostCloudLadderEventAction(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            xc.ControlServerLogHelper __cl_gen_to_be_invoked = (xc.ControlServerLogHelper)translator.FastGetCSObj(L, 1);
            
            
            try {
                
                {
                    xc.CloudLadderMarkEnum mark;translator.Get(L, 2, out mark);
                    
                    __cl_gen_to_be_invoked.PostCloudLadderEventAction( mark );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        
        
        
        
        
		
		
		
		
    }
}
