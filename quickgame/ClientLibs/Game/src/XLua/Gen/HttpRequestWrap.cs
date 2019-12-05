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
    public class HttpRequestWrap
    {
        public static void __Register(RealStatePtr L)
        {
			ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			XUtils.BeginObjectRegister(typeof(HttpRequest), L, translator, 0, 3, 0, 0);
			
			XUtils.RegisterFunc(L, XUtils.METHOD_IDX, "GET", _m_GET);
			XUtils.RegisterFunc(L, XUtils.METHOD_IDX, "POST", _m_POST);
			XUtils.RegisterFunc(L, XUtils.METHOD_IDX, "CoGET", _m_CoGET);
			
			
			
			
			XUtils.EndObjectRegister(typeof(HttpRequest), L, translator, null, null,
			    null, null, null);

		    XUtils.BeginClassRegister(typeof(HttpRequest), L, __CreateInstance, 2, 1, 1);
			XUtils.RegisterFunc(L, XUtils.CLS_IDX, "UrlEncode", _m_UrlEncode_xlua_st_);
            
			
            
            XUtils.RegisterObject(L, translator, XUtils.CLS_IDX, "UnderlyingSystemType", typeof(HttpRequest));
			XUtils.RegisterFunc(L, XUtils.CLS_GETTER_IDX, "Instance", _g_get_Instance);
            
			XUtils.RegisterFunc(L, XUtils.CLS_SETTER_IDX, "Instance", _s_set_Instance);
            
			XUtils.EndClassRegister(typeof(HttpRequest), L, translator);
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int __CreateInstance(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			try {
				if(LuaAPI.lua_gettop(L) == 1)
				{
					
					HttpRequest __cl_gen_ret = new HttpRequest();
					translator.Push(L, __cl_gen_ret);
					return 1;
				}
				
			}
			catch(System.Exception __gen_e) {
				return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
			}
            return LuaAPI.luaL_error(L, "invalid arguments to HttpRequest constructor!");
            
        }
        
		
        
		
        
        
        
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_GET(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            HttpRequest __cl_gen_to_be_invoked = (HttpRequest)translator.FastGetCSObj(L, 1);
            
            
			int __gen_param_count = LuaAPI.lua_gettop(L);
            
            try {
                if(__gen_param_count == 3&& (LuaAPI.lua_isnil(L, 2) || LuaAPI.lua_type(L, 2) == LuaTypes.LUA_TSTRING)&& translator.Assignable<HttpRequest.GETCB>(L, 3)) 
                {
                    string url = LuaAPI.lua_tostring(L, 2);
                    HttpRequest.GETCB cb = translator.GetDelegate<HttpRequest.GETCB>(L, 3);
                    
                    __cl_gen_to_be_invoked.GET( url, cb );
                    
                    
                    
                    return 0;
                }
                if(__gen_param_count == 4&& (LuaAPI.lua_isnil(L, 2) || LuaAPI.lua_type(L, 2) == LuaTypes.LUA_TSTRING)&& translator.Assignable<HttpRequest.GETCB>(L, 3)&& translator.Assignable<object>(L, 4)) 
                {
                    string url = LuaAPI.lua_tostring(L, 2);
                    HttpRequest.GETCB cb = translator.GetDelegate<HttpRequest.GETCB>(L, 3);
                    object userData = translator.GetObject(L, 4, typeof(object));
                    
                    __cl_gen_to_be_invoked.GET( url, cb, userData );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
            return LuaAPI.luaL_error(L, "invalid arguments to HttpRequest.GET!");
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_POST(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            HttpRequest __cl_gen_to_be_invoked = (HttpRequest)translator.FastGetCSObj(L, 1);
            
            
			int __gen_param_count = LuaAPI.lua_gettop(L);
            
            try {
                if(__gen_param_count == 4&& (LuaAPI.lua_isnil(L, 2) || LuaAPI.lua_type(L, 2) == LuaTypes.LUA_TSTRING)&& translator.Assignable<System.Collections.Generic.Dictionary<string, string>>(L, 3)&& translator.Assignable<HttpRequest.POSTCB>(L, 4)) 
                {
                    string url = LuaAPI.lua_tostring(L, 2);
                    System.Collections.Generic.Dictionary<string, string> data = (System.Collections.Generic.Dictionary<string, string>)translator.GetObject(L, 3, typeof(System.Collections.Generic.Dictionary<string, string>));
                    HttpRequest.POSTCB cb = translator.GetDelegate<HttpRequest.POSTCB>(L, 4);
                    
                    __cl_gen_to_be_invoked.POST( url, data, cb );
                    
                    
                    
                    return 0;
                }
                if(__gen_param_count == 5&& (LuaAPI.lua_isnil(L, 2) || LuaAPI.lua_type(L, 2) == LuaTypes.LUA_TSTRING)&& translator.Assignable<System.Collections.Generic.Dictionary<string, string>>(L, 3)&& translator.Assignable<HttpRequest.POSTCB>(L, 4)&& translator.Assignable<object>(L, 5)) 
                {
                    string url = LuaAPI.lua_tostring(L, 2);
                    System.Collections.Generic.Dictionary<string, string> data = (System.Collections.Generic.Dictionary<string, string>)translator.GetObject(L, 3, typeof(System.Collections.Generic.Dictionary<string, string>));
                    HttpRequest.POSTCB cb = translator.GetDelegate<HttpRequest.POSTCB>(L, 4);
                    object userData = translator.GetObject(L, 5, typeof(object));
                    
                    __cl_gen_to_be_invoked.POST( url, data, cb, userData );
                    
                    
                    
                    return 0;
                }
                if(__gen_param_count == 5&& (LuaAPI.lua_isnil(L, 2) || LuaAPI.lua_type(L, 2) == LuaTypes.LUA_TSTRING)&& (LuaAPI.lua_isnil(L, 3) || LuaAPI.lua_type(L, 3) == LuaTypes.LUA_TTABLE)&& (LuaAPI.lua_isnil(L, 4) || LuaAPI.lua_type(L, 4) == LuaTypes.LUA_TTABLE)&& translator.Assignable<HttpRequest.POSTCB>(L, 5)) 
                {
                    string url = LuaAPI.lua_tostring(L, 2);
                    XLua.LuaTable values = (XLua.LuaTable)translator.GetObject(L, 3, typeof(XLua.LuaTable));
                    XLua.LuaTable files = (XLua.LuaTable)translator.GetObject(L, 4, typeof(XLua.LuaTable));
                    HttpRequest.POSTCB cb = translator.GetDelegate<HttpRequest.POSTCB>(L, 5);
                    
                    __cl_gen_to_be_invoked.POST( url, values, files, cb );
                    
                    
                    
                    return 0;
                }
                if(__gen_param_count == 6&& (LuaAPI.lua_isnil(L, 2) || LuaAPI.lua_type(L, 2) == LuaTypes.LUA_TSTRING)&& translator.Assignable<System.Collections.Generic.Dictionary<string, string>>(L, 3)&& translator.Assignable<System.Collections.Generic.Dictionary<string, System.Collections.Generic.KeyValuePair<string, byte[]>>>(L, 4)&& translator.Assignable<HttpRequest.POSTCB>(L, 5)&& translator.Assignable<object>(L, 6)) 
                {
                    string url = LuaAPI.lua_tostring(L, 2);
                    System.Collections.Generic.Dictionary<string, string> data = (System.Collections.Generic.Dictionary<string, string>)translator.GetObject(L, 3, typeof(System.Collections.Generic.Dictionary<string, string>));
                    System.Collections.Generic.Dictionary<string, System.Collections.Generic.KeyValuePair<string, byte[]>> stream = (System.Collections.Generic.Dictionary<string, System.Collections.Generic.KeyValuePair<string, byte[]>>)translator.GetObject(L, 4, typeof(System.Collections.Generic.Dictionary<string, System.Collections.Generic.KeyValuePair<string, byte[]>>));
                    HttpRequest.POSTCB cb = translator.GetDelegate<HttpRequest.POSTCB>(L, 5);
                    object userData = translator.GetObject(L, 6, typeof(object));
                    
                    __cl_gen_to_be_invoked.POST( url, data, stream, cb, userData );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
            return LuaAPI.luaL_error(L, "invalid arguments to HttpRequest.POST!");
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_CoGET(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            HttpRequest __cl_gen_to_be_invoked = (HttpRequest)translator.FastGetCSObj(L, 1);
            
            
            try {
                
                {
                    string url = LuaAPI.lua_tostring(L, 2);
                    HttpRequest.GETCB cb = translator.GetDelegate<HttpRequest.GETCB>(L, 3);
                    object userData = translator.GetObject(L, 4, typeof(object));
                    
                        System.Collections.IEnumerator __cl_gen_ret = __cl_gen_to_be_invoked.CoGET( url, cb, userData );
                        translator.Push(L, __cl_gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_UrlEncode_xlua_st_(RealStatePtr L)
        {
            
            
            
            try {
                
                {
                    string str = LuaAPI.lua_tostring(L, 1);
                    
                        string __cl_gen_ret = HttpRequest.UrlEncode( str );
                        LuaAPI.lua_pushstring(L, __cl_gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        
        
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_Instance(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			    translator.Push(L, HttpRequest.Instance);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_Instance(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			    HttpRequest.Instance = (HttpRequest)translator.GetObject(L, 1, typeof(HttpRequest));
            
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 0;
        }
        
		
		
		
		
    }
}
