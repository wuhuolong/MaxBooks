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
    public class xcChatHelperWrap
    {
        public static void __Register(RealStatePtr L)
        {
			ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			XUtils.BeginObjectRegister(typeof(xc.ChatHelper), L, translator, 0, 0, 0, 0);
			
			
			
			
			
			XUtils.EndObjectRegister(typeof(xc.ChatHelper), L, translator, null, null,
			    null, null, null);

		    XUtils.BeginClassRegister(typeof(xc.ChatHelper), L, __CreateInstance, 18, 0, 0);
			XUtils.RegisterFunc(L, XUtils.CLS_IDX, "GetFixedContent", _m_GetFixedContent_xlua_st_);
            XUtils.RegisterFunc(L, XUtils.CLS_IDX, "GetGoodsRawNameFromUrl", _m_GetGoodsRawNameFromUrl_xlua_st_);
            XUtils.RegisterFunc(L, XUtils.CLS_IDX, "GetGoodsNameColor", _m_GetGoodsNameColor_xlua_st_);
            XUtils.RegisterFunc(L, XUtils.CLS_IDX, "GetChatStringGoodsUrl", _m_GetChatStringGoodsUrl_xlua_st_);
            XUtils.RegisterFunc(L, XUtils.CLS_IDX, "GetFixedGoodsStringFromRawChatString", _m_GetFixedGoodsStringFromRawChatString_xlua_st_);
            XUtils.RegisterFunc(L, XUtils.CLS_IDX, "GetFixedGoodsStringFromRawChatString2", _m_GetFixedGoodsStringFromRawChatString2_xlua_st_);
            XUtils.RegisterFunc(L, XUtils.CLS_IDX, "IsInWifi", _m_IsInWifi_xlua_st_);
            XUtils.RegisterFunc(L, XUtils.CLS_IDX, "GetPrivateLogFilePath", _m_GetPrivateLogFilePath_xlua_st_);
            XUtils.RegisterFunc(L, XUtils.CLS_IDX, "CSharpStringLength", _m_CSharpStringLength_xlua_st_);
            XUtils.RegisterFunc(L, XUtils.CLS_IDX, "GetChatSavePath", _m_GetChatSavePath_xlua_st_);
            XUtils.RegisterFunc(L, XUtils.CLS_IDX, "GetClickStrName", _m_GetClickStrName_xlua_st_);
            XUtils.RegisterFunc(L, XUtils.CLS_IDX, "GetGoodsCount", _m_GetGoodsCount_xlua_st_);
            XUtils.RegisterFunc(L, XUtils.CLS_IDX, "FinalFix", _m_FinalFix_xlua_st_);
            XUtils.RegisterFunc(L, XUtils.CLS_IDX, "FixClickStr", _m_FixClickStr_xlua_st_);
            XUtils.RegisterFunc(L, XUtils.CLS_IDX, "BubbleFixedContent", _m_BubbleFixedContent_xlua_st_);
            XUtils.RegisterFunc(L, XUtils.CLS_IDX, "GetChatEmojiConfigFilePath", _m_GetChatEmojiConfigFilePath_xlua_st_);
            XUtils.RegisterFunc(L, XUtils.CLS_IDX, "ResponseClickEmojiTextHref", _m_ResponseClickEmojiTextHref_xlua_st_);
            
			
            
            XUtils.RegisterObject(L, translator, XUtils.CLS_IDX, "UnderlyingSystemType", typeof(xc.ChatHelper));
			
			
			XUtils.EndClassRegister(typeof(xc.ChatHelper), L, translator);
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int __CreateInstance(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			try {
				if(LuaAPI.lua_gettop(L) == 1)
				{
					
					xc.ChatHelper __cl_gen_ret = new xc.ChatHelper();
					translator.Push(L, __cl_gen_ret);
					return 1;
				}
				
			}
			catch(System.Exception __gen_e) {
				return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
			}
            return LuaAPI.luaL_error(L, "invalid arguments to xc.ChatHelper constructor!");
            
        }
        
		
        
		
        
        
        
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_GetFixedContent_xlua_st_(RealStatePtr L)
        {
            
            
            
            try {
                
                {
                    string color = LuaAPI.lua_tostring(L, 1);
                    string content = LuaAPI.lua_tostring(L, 2);
                    string goodsName = LuaAPI.lua_tostring(L, 3);
                    
                        string __cl_gen_ret = xc.ChatHelper.GetFixedContent( color, content, goodsName );
                        LuaAPI.lua_pushstring(L, __cl_gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_GetGoodsRawNameFromUrl_xlua_st_(RealStatePtr L)
        {
            
            
            
            try {
                
                {
                    string url = LuaAPI.lua_tostring(L, 1);
                    
                        string __cl_gen_ret = xc.ChatHelper.GetGoodsRawNameFromUrl( url );
                        LuaAPI.lua_pushstring(L, __cl_gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_GetGoodsNameColor_xlua_st_(RealStatePtr L)
        {
            
            
            
            try {
                
                {
                    string url = LuaAPI.lua_tostring(L, 1);
                    
                        string __cl_gen_ret = xc.ChatHelper.GetGoodsNameColor( url );
                        LuaAPI.lua_pushstring(L, __cl_gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_GetChatStringGoodsUrl_xlua_st_(RealStatePtr L)
        {
            
            
            
			int __gen_param_count = LuaAPI.lua_gettop(L);
            
            try {
                if(__gen_param_count == 1&& (LuaAPI.lua_isnil(L, 1) || LuaAPI.lua_type(L, 1) == LuaTypes.LUA_TSTRING)) 
                {
                    string rawChat = LuaAPI.lua_tostring(L, 1);
                    
                        string __cl_gen_ret = xc.ChatHelper.GetChatStringGoodsUrl( rawChat );
                        LuaAPI.lua_pushstring(L, __cl_gen_ret);
                    
                    
                    
                    return 1;
                }
                if(__gen_param_count == 1&& (LuaAPI.lua_isnil(L, 1) || LuaAPI.lua_type(L, 1) == LuaTypes.LUA_TSTRING)) 
                {
                    string rawChat = LuaAPI.lua_tostring(L, 1);
                    int startIndex;
                    int endIndex;
                    
                        string __cl_gen_ret = xc.ChatHelper.GetChatStringGoodsUrl( rawChat, out startIndex, out endIndex );
                        LuaAPI.lua_pushstring(L, __cl_gen_ret);
                    LuaAPI.xlua_pushinteger(L, startIndex);
                        
                    LuaAPI.xlua_pushinteger(L, endIndex);
                        
                    
                    
                    
                    return 3;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
            return LuaAPI.luaL_error(L, "invalid arguments to xc.ChatHelper.GetChatStringGoodsUrl!");
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_GetFixedGoodsStringFromRawChatString_xlua_st_(RealStatePtr L)
        {
            
            
            
            try {
                
                {
                    string rawChat = LuaAPI.lua_tostring(L, 1);
                    string goodsUrl;
                    string rawUrl;
                    string replaceGoodsName;
                    
                        string __cl_gen_ret = xc.ChatHelper.GetFixedGoodsStringFromRawChatString( rawChat, out goodsUrl, out rawUrl, out replaceGoodsName );
                        LuaAPI.lua_pushstring(L, __cl_gen_ret);
                    LuaAPI.lua_pushstring(L, goodsUrl);
                        
                    LuaAPI.lua_pushstring(L, rawUrl);
                        
                    LuaAPI.lua_pushstring(L, replaceGoodsName);
                        
                    
                    
                    
                    return 4;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_GetFixedGoodsStringFromRawChatString2_xlua_st_(RealStatePtr L)
        {
            
            
            
            try {
                
                {
                    string rawChat = LuaAPI.lua_tostring(L, 1);
                    string goodsUrl = LuaAPI.lua_tostring(L, 2);
                    string rawUrl = LuaAPI.lua_tostring(L, 3);
                    string replaceGoodsName = LuaAPI.lua_tostring(L, 4);
                    
                        string __cl_gen_ret = xc.ChatHelper.GetFixedGoodsStringFromRawChatString2( rawChat, goodsUrl, rawUrl, replaceGoodsName );
                        LuaAPI.lua_pushstring(L, __cl_gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_IsInWifi_xlua_st_(RealStatePtr L)
        {
            
            
            
            try {
                
                {
                    
                        bool __cl_gen_ret = xc.ChatHelper.IsInWifi(  );
                        LuaAPI.lua_pushboolean(L, __cl_gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_GetPrivateLogFilePath_xlua_st_(RealStatePtr L)
        {
            
            
            
            try {
                
                {
                    string extensionName = LuaAPI.lua_tostring(L, 1);
                    
                        string __cl_gen_ret = xc.ChatHelper.GetPrivateLogFilePath( extensionName );
                        LuaAPI.lua_pushstring(L, __cl_gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_CSharpStringLength_xlua_st_(RealStatePtr L)
        {
            
            
            
            try {
                
                {
                    string str = LuaAPI.lua_tostring(L, 1);
                    
                        int __cl_gen_ret = xc.ChatHelper.CSharpStringLength( str );
                        LuaAPI.xlua_pushinteger(L, __cl_gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_GetChatSavePath_xlua_st_(RealStatePtr L)
        {
            
            
            
            try {
                
                {
                    string saveName = LuaAPI.lua_tostring(L, 1);
                    
                        string __cl_gen_ret = xc.ChatHelper.GetChatSavePath( saveName );
                        LuaAPI.lua_pushstring(L, __cl_gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_GetClickStrName_xlua_st_(RealStatePtr L)
        {
            
            
            
            try {
                
                {
                    string content = LuaAPI.lua_tostring(L, 1);
                    
                        string __cl_gen_ret = xc.ChatHelper.GetClickStrName( content );
                        LuaAPI.lua_pushstring(L, __cl_gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_GetGoodsCount_xlua_st_(RealStatePtr L)
        {
            
            
            
            try {
                
                {
                    string content = LuaAPI.lua_tostring(L, 1);
                    int count = LuaAPI.xlua_tointeger(L, 2);
                    
                        int __cl_gen_ret = xc.ChatHelper.GetGoodsCount( content, count );
                        LuaAPI.xlua_pushinteger(L, __cl_gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_FinalFix_xlua_st_(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            
            try {
                
                {
                    string[] Origs = (string[])translator.GetObject(L, 1, typeof(string[]));
                    string[] Replaces = (string[])translator.GetObject(L, 2, typeof(string[]));
                    string content = LuaAPI.lua_tostring(L, 3);
                    
                        string __cl_gen_ret = xc.ChatHelper.FinalFix( Origs, Replaces, content );
                        LuaAPI.lua_pushstring(L, __cl_gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_FixClickStr_xlua_st_(RealStatePtr L)
        {
            
            
            
            try {
                
                {
                    string content = LuaAPI.lua_tostring(L, 1);
                    string replace = LuaAPI.lua_tostring(L, 2);
                    string orig = LuaAPI.lua_tostring(L, 3);
                    int startIndex = LuaAPI.xlua_tointeger(L, 4);
                    
                        string __cl_gen_ret = xc.ChatHelper.FixClickStr( content, replace, orig, ref startIndex );
                        LuaAPI.lua_pushstring(L, __cl_gen_ret);
                    LuaAPI.xlua_pushinteger(L, startIndex);
                        
                    
                    
                    
                    return 2;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_BubbleFixedContent_xlua_st_(RealStatePtr L)
        {
            
            
            
            try {
                
                {
                    string content = LuaAPI.lua_tostring(L, 1);
                    
                        string __cl_gen_ret = xc.ChatHelper.BubbleFixedContent( content );
                        LuaAPI.lua_pushstring(L, __cl_gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_GetChatEmojiConfigFilePath_xlua_st_(RealStatePtr L)
        {
            
            
            
            try {
                
                {
                    
                        string __cl_gen_ret = xc.ChatHelper.GetChatEmojiConfigFilePath(  );
                        LuaAPI.lua_pushstring(L, __cl_gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_ResponseClickEmojiTextHref_xlua_st_(RealStatePtr L)
        {
            
            
            
            try {
                
                {
                    string origText = LuaAPI.lua_tostring(L, 1);
                    
                    xc.ChatHelper.ResponseClickEmojiTextHref( origText );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        
        
        
        
        
		
		
		
		
    }
}
