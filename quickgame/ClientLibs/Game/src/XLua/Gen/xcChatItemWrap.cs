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
    public class xcChatItemWrap
    {
        public static void __Register(RealStatePtr L)
        {
			ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			XUtils.BeginObjectRegister(typeof(xc.ChatItem), L, translator, 0, 18, 0, 0);
			
			XUtils.RegisterFunc(L, XUtils.METHOD_IDX, "Init", _m_Init);
			XUtils.RegisterFunc(L, XUtils.METHOD_IDX, "SetIsVoiceMsg", _m_SetIsVoiceMsg);
			XUtils.RegisterFunc(L, XUtils.METHOD_IDX, "SetTextLabelText", _m_SetTextLabelText);
			XUtils.RegisterFunc(L, XUtils.METHOD_IDX, "SetVipIcon", _m_SetVipIcon);
			XUtils.RegisterFunc(L, XUtils.METHOD_IDX, "SetNameLabelText", _m_SetNameLabelText);
			XUtils.RegisterFunc(L, XUtils.METHOD_IDX, "SetSenderLevelText", _m_SetSenderLevelText);
			XUtils.RegisterFunc(L, XUtils.METHOD_IDX, "SetSystemChannelContent", _m_SetSystemChannelContent);
			XUtils.RegisterFunc(L, XUtils.METHOD_IDX, "SetVoiceChatContent", _m_SetVoiceChatContent);
			XUtils.RegisterFunc(L, XUtils.METHOD_IDX, "SetVoiceChatLenght", _m_SetVoiceChatLenght);
			XUtils.RegisterFunc(L, XUtils.METHOD_IDX, "SetVoiceReadState", _m_SetVoiceReadState);
			XUtils.RegisterFunc(L, XUtils.METHOD_IDX, "SetVoiceId", _m_SetVoiceId);
			XUtils.RegisterFunc(L, XUtils.METHOD_IDX, "OnRecordPlayDone", _m_OnRecordPlayDone);
			XUtils.RegisterFunc(L, XUtils.METHOD_IDX, "GetVoiceID", _m_GetVoiceID);
			XUtils.RegisterFunc(L, XUtils.METHOD_IDX, "SetVoicePlayState", _m_SetVoicePlayState);
			XUtils.RegisterFunc(L, XUtils.METHOD_IDX, "ShowWineIcon", _m_ShowWineIcon);
			XUtils.RegisterFunc(L, XUtils.METHOD_IDX, "ShowRechargeRedPacket", _m_ShowRechargeRedPacket);
			XUtils.RegisterFunc(L, XUtils.METHOD_IDX, "SetRechargeRedPacketIconTranslucence", _m_SetRechargeRedPacketIconTranslucence);
			XUtils.RegisterFunc(L, XUtils.METHOD_IDX, "GetVoiceButton", _m_GetVoiceButton);
			
			
			
			
			XUtils.EndObjectRegister(typeof(xc.ChatItem), L, translator, null, null,
			    null, null, null);

		    XUtils.BeginClassRegister(typeof(xc.ChatItem), L, __CreateInstance, 1, 0, 0);
			
			
            
            XUtils.RegisterObject(L, translator, XUtils.CLS_IDX, "UnderlyingSystemType", typeof(xc.ChatItem));
			
			
			XUtils.EndClassRegister(typeof(xc.ChatItem), L, translator);
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int __CreateInstance(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			try {
				if(LuaAPI.lua_gettop(L) == 1)
				{
					
					xc.ChatItem __cl_gen_ret = new xc.ChatItem();
					translator.Push(L, __cl_gen_ret);
					return 1;
				}
				
			}
			catch(System.Exception __gen_e) {
				return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
			}
            return LuaAPI.luaL_error(L, "invalid arguments to xc.ChatItem constructor!");
            
        }
        
		
        
		
        
        
        
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_Init(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            xc.ChatItem __cl_gen_to_be_invoked = (xc.ChatItem)translator.FastGetCSObj(L, 1);
            
            
			int __gen_param_count = LuaAPI.lua_gettop(L);
            
            try {
                if(__gen_param_count == 9&& LuaTypes.LUA_TNUMBER == LuaAPI.lua_type(L, 2)&& LuaTypes.LUA_TNUMBER == LuaAPI.lua_type(L, 3)&& LuaTypes.LUA_TNUMBER == LuaAPI.lua_type(L, 4)&& LuaTypes.LUA_TNUMBER == LuaAPI.lua_type(L, 5)&& LuaTypes.LUA_TNUMBER == LuaAPI.lua_type(L, 6)&& translator.Assignable<UnityEngine.GameObject>(L, 7)&& LuaTypes.LUA_TNUMBER == LuaAPI.lua_type(L, 8)&& LuaTypes.LUA_TNUMBER == LuaAPI.lua_type(L, 9)) 
                {
                    uint senderID = LuaAPI.xlua_touint(L, 2);
                    uint teamID = LuaAPI.xlua_touint(L, 3);
                    uint roleId = LuaAPI.xlua_touint(L, 4);
                    int chatItemType = LuaAPI.xlua_tointeger(L, 5);
                    uint transferLv = LuaAPI.xlua_touint(L, 6);
                    UnityEngine.GameObject wnd = (UnityEngine.GameObject)translator.GetObject(L, 7, typeof(UnityEngine.GameObject));
                    uint photoFrameId = LuaAPI.xlua_touint(L, 8);
                    uint chatBubbleId = LuaAPI.xlua_touint(L, 9);
                    
                    __cl_gen_to_be_invoked.Init( senderID, teamID, roleId, chatItemType, transferLv, wnd, photoFrameId, chatBubbleId );
                    
                    
                    
                    return 0;
                }
                if(__gen_param_count == 8&& LuaTypes.LUA_TNUMBER == LuaAPI.lua_type(L, 2)&& LuaTypes.LUA_TNUMBER == LuaAPI.lua_type(L, 3)&& LuaTypes.LUA_TNUMBER == LuaAPI.lua_type(L, 4)&& LuaTypes.LUA_TNUMBER == LuaAPI.lua_type(L, 5)&& LuaTypes.LUA_TNUMBER == LuaAPI.lua_type(L, 6)&& translator.Assignable<UnityEngine.GameObject>(L, 7)&& LuaTypes.LUA_TNUMBER == LuaAPI.lua_type(L, 8)) 
                {
                    uint senderID = LuaAPI.xlua_touint(L, 2);
                    uint teamID = LuaAPI.xlua_touint(L, 3);
                    uint roleId = LuaAPI.xlua_touint(L, 4);
                    int chatItemType = LuaAPI.xlua_tointeger(L, 5);
                    uint transferLv = LuaAPI.xlua_touint(L, 6);
                    UnityEngine.GameObject wnd = (UnityEngine.GameObject)translator.GetObject(L, 7, typeof(UnityEngine.GameObject));
                    uint photoFrameId = LuaAPI.xlua_touint(L, 8);
                    
                    __cl_gen_to_be_invoked.Init( senderID, teamID, roleId, chatItemType, transferLv, wnd, photoFrameId );
                    
                    
                    
                    return 0;
                }
                if(__gen_param_count == 7&& LuaTypes.LUA_TNUMBER == LuaAPI.lua_type(L, 2)&& LuaTypes.LUA_TNUMBER == LuaAPI.lua_type(L, 3)&& LuaTypes.LUA_TNUMBER == LuaAPI.lua_type(L, 4)&& LuaTypes.LUA_TNUMBER == LuaAPI.lua_type(L, 5)&& LuaTypes.LUA_TNUMBER == LuaAPI.lua_type(L, 6)&& translator.Assignable<UnityEngine.GameObject>(L, 7)) 
                {
                    uint senderID = LuaAPI.xlua_touint(L, 2);
                    uint teamID = LuaAPI.xlua_touint(L, 3);
                    uint roleId = LuaAPI.xlua_touint(L, 4);
                    int chatItemType = LuaAPI.xlua_tointeger(L, 5);
                    uint transferLv = LuaAPI.xlua_touint(L, 6);
                    UnityEngine.GameObject wnd = (UnityEngine.GameObject)translator.GetObject(L, 7, typeof(UnityEngine.GameObject));
                    
                    __cl_gen_to_be_invoked.Init( senderID, teamID, roleId, chatItemType, transferLv, wnd );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
            return LuaAPI.luaL_error(L, "invalid arguments to xc.ChatItem.Init!");
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_SetIsVoiceMsg(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            xc.ChatItem __cl_gen_to_be_invoked = (xc.ChatItem)translator.FastGetCSObj(L, 1);
            
            
            try {
                
                {
                    bool isVoiceChat = LuaAPI.lua_toboolean(L, 2);
                    
                    __cl_gen_to_be_invoked.SetIsVoiceMsg( isVoiceChat );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_SetTextLabelText(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            xc.ChatItem __cl_gen_to_be_invoked = (xc.ChatItem)translator.FastGetCSObj(L, 1);
            
            
            try {
                
                {
                    string text = LuaAPI.lua_tostring(L, 2);
                    
                    __cl_gen_to_be_invoked.SetTextLabelText( text );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_SetVipIcon(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            xc.ChatItem __cl_gen_to_be_invoked = (xc.ChatItem)translator.FastGetCSObj(L, 1);
            
            
            try {
                
                {
                    uint lv = LuaAPI.xlua_touint(L, 2);
                    
                    __cl_gen_to_be_invoked.SetVipIcon( lv );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_SetNameLabelText(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            xc.ChatItem __cl_gen_to_be_invoked = (xc.ChatItem)translator.FastGetCSObj(L, 1);
            
            
            try {
                
                {
                    string text = LuaAPI.lua_tostring(L, 2);
                    
                    __cl_gen_to_be_invoked.SetNameLabelText( text );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_SetSenderLevelText(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            xc.ChatItem __cl_gen_to_be_invoked = (xc.ChatItem)translator.FastGetCSObj(L, 1);
            
            
            try {
                
                {
                    int level = LuaAPI.xlua_tointeger(L, 2);
                    uint transferLv = LuaAPI.xlua_touint(L, 3);
                    
                    __cl_gen_to_be_invoked.SetSenderLevelText( level, transferLv );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_SetSystemChannelContent(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            xc.ChatItem __cl_gen_to_be_invoked = (xc.ChatItem)translator.FastGetCSObj(L, 1);
            
            
            try {
                
                {
                    string text = LuaAPI.lua_tostring(L, 2);
                    
                    __cl_gen_to_be_invoked.SetSystemChannelContent( text );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_SetVoiceChatContent(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            xc.ChatItem __cl_gen_to_be_invoked = (xc.ChatItem)translator.FastGetCSObj(L, 1);
            
            
            try {
                
                {
                    string content = LuaAPI.lua_tostring(L, 2);
                    
                    __cl_gen_to_be_invoked.SetVoiceChatContent( content );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_SetVoiceChatLenght(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            xc.ChatItem __cl_gen_to_be_invoked = (xc.ChatItem)translator.FastGetCSObj(L, 1);
            
            
            try {
                
                {
                    string voiceLength = LuaAPI.lua_tostring(L, 2);
                    
                    __cl_gen_to_be_invoked.SetVoiceChatLenght( voiceLength );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_SetVoiceReadState(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            xc.ChatItem __cl_gen_to_be_invoked = (xc.ChatItem)translator.FastGetCSObj(L, 1);
            
            
            try {
                
                {
                    bool isRead = LuaAPI.lua_toboolean(L, 2);
                    
                    __cl_gen_to_be_invoked.SetVoiceReadState( isRead );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_SetVoiceId(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            xc.ChatItem __cl_gen_to_be_invoked = (xc.ChatItem)translator.FastGetCSObj(L, 1);
            
            
            try {
                
                {
                    string voice_id = LuaAPI.lua_tostring(L, 2);
                    
                    __cl_gen_to_be_invoked.SetVoiceId( voice_id );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_OnRecordPlayDone(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            xc.ChatItem __cl_gen_to_be_invoked = (xc.ChatItem)translator.FastGetCSObj(L, 1);
            
            
            try {
                
                {
                    CEventBaseArgs args = (CEventBaseArgs)translator.GetObject(L, 2, typeof(CEventBaseArgs));
                    
                    __cl_gen_to_be_invoked.OnRecordPlayDone( args );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_GetVoiceID(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            xc.ChatItem __cl_gen_to_be_invoked = (xc.ChatItem)translator.FastGetCSObj(L, 1);
            
            
            try {
                
                {
                    
                        string __cl_gen_ret = __cl_gen_to_be_invoked.GetVoiceID(  );
                        LuaAPI.lua_pushstring(L, __cl_gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_SetVoicePlayState(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            xc.ChatItem __cl_gen_to_be_invoked = (xc.ChatItem)translator.FastGetCSObj(L, 1);
            
            
            try {
                
                {
                    bool ret = LuaAPI.lua_toboolean(L, 2);
                    
                    __cl_gen_to_be_invoked.SetVoicePlayState( ret );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_ShowWineIcon(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            xc.ChatItem __cl_gen_to_be_invoked = (xc.ChatItem)translator.FastGetCSObj(L, 1);
            
            
            try {
                
                {
                    bool isShow = LuaAPI.lua_toboolean(L, 2);
                    
                    __cl_gen_to_be_invoked.ShowWineIcon( isShow );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_ShowRechargeRedPacket(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            xc.ChatItem __cl_gen_to_be_invoked = (xc.ChatItem)translator.FastGetCSObj(L, 1);
            
            
            try {
                
                {
                    uint id = LuaAPI.xlua_touint(L, 2);
                    
                    __cl_gen_to_be_invoked.ShowRechargeRedPacket( id );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_SetRechargeRedPacketIconTranslucence(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            xc.ChatItem __cl_gen_to_be_invoked = (xc.ChatItem)translator.FastGetCSObj(L, 1);
            
            
            try {
                
                {
                    bool b = LuaAPI.lua_toboolean(L, 2);
                    
                    __cl_gen_to_be_invoked.SetRechargeRedPacketIconTranslucence( b );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_GetVoiceButton(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            xc.ChatItem __cl_gen_to_be_invoked = (xc.ChatItem)translator.FastGetCSObj(L, 1);
            
            
            try {
                
                {
                    
                        UnityEngine.UI.Button __cl_gen_ret = __cl_gen_to_be_invoked.GetVoiceButton(  );
                        translator.Push(L, __cl_gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        
        
        
        
        
		
		
		
		
    }
}
