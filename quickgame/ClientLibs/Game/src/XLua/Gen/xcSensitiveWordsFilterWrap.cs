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
    public class xcSensitiveWordsFilterWrap
    {
        public static void __Register(RealStatePtr L)
        {
			ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			XUtils.BeginObjectRegister(typeof(xc.SensitiveWordsFilter), L, translator, 0, 7, 0, 0);
			
			XUtils.RegisterFunc(L, XUtils.METHOD_IDX, "GetFilterString", _m_GetFilterString);
			XUtils.RegisterFunc(L, XUtils.METHOD_IDX, "AddSensitiveWord", _m_AddSensitiveWord);
			XUtils.RegisterFunc(L, XUtils.METHOD_IDX, "ToLowerWord", _m_ToLowerWord);
			XUtils.RegisterFunc(L, XUtils.METHOD_IDX, "Filter", _m_Filter);
			XUtils.RegisterFunc(L, XUtils.METHOD_IDX, "IsHaveSensitiveWords", _m_IsHaveSensitiveWords);
			XUtils.RegisterFunc(L, XUtils.METHOD_IDX, "IsInputUserNameLegal", _m_IsInputUserNameLegal);
			XUtils.RegisterFunc(L, XUtils.METHOD_IDX, "ReplaceEmoji", _m_ReplaceEmoji);
			
			
			
			
			XUtils.EndObjectRegister(typeof(xc.SensitiveWordsFilter), L, translator, null, null,
			    null, null, null);

		    XUtils.BeginClassRegister(typeof(xc.SensitiveWordsFilter), L, __CreateInstance, 1, 0, 0);
			
			
            
            XUtils.RegisterObject(L, translator, XUtils.CLS_IDX, "UnderlyingSystemType", typeof(xc.SensitiveWordsFilter));
			
			
			XUtils.EndClassRegister(typeof(xc.SensitiveWordsFilter), L, translator);
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int __CreateInstance(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			try {
				if(LuaAPI.lua_gettop(L) == 1)
				{
					
					xc.SensitiveWordsFilter __cl_gen_ret = new xc.SensitiveWordsFilter();
					translator.Push(L, __cl_gen_ret);
					return 1;
				}
				
			}
			catch(System.Exception __gen_e) {
				return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
			}
            return LuaAPI.luaL_error(L, "invalid arguments to xc.SensitiveWordsFilter constructor!");
            
        }
        
		
        
		
        
        
        
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_GetFilterString(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            xc.SensitiveWordsFilter __cl_gen_to_be_invoked = (xc.SensitiveWordsFilter)translator.FastGetCSObj(L, 1);
            
            
            try {
                
                {
                    string raw = LuaAPI.lua_tostring(L, 2);
                    
                        string __cl_gen_ret = __cl_gen_to_be_invoked.GetFilterString( raw );
                        LuaAPI.lua_pushstring(L, __cl_gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_AddSensitiveWord(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            xc.SensitiveWordsFilter __cl_gen_to_be_invoked = (xc.SensitiveWordsFilter)translator.FastGetCSObj(L, 1);
            
            
            try {
                
                {
                    string sensitiveWord = LuaAPI.lua_tostring(L, 2);
                    
                    __cl_gen_to_be_invoked.AddSensitiveWord( sensitiveWord );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_ToLowerWord(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            xc.SensitiveWordsFilter __cl_gen_to_be_invoked = (xc.SensitiveWordsFilter)translator.FastGetCSObj(L, 1);
            
            
            try {
                
                {
                    string word = LuaAPI.lua_tostring(L, 2);
                    
                        string __cl_gen_ret = __cl_gen_to_be_invoked.ToLowerWord( word );
                        LuaAPI.lua_pushstring(L, __cl_gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_Filter(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            xc.SensitiveWordsFilter __cl_gen_to_be_invoked = (xc.SensitiveWordsFilter)translator.FastGetCSObj(L, 1);
            
            
            try {
                
                {
                    string raw = LuaAPI.lua_tostring(L, 2);
                    
                        string __cl_gen_ret = __cl_gen_to_be_invoked.Filter( raw );
                        LuaAPI.lua_pushstring(L, __cl_gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_IsHaveSensitiveWords(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            xc.SensitiveWordsFilter __cl_gen_to_be_invoked = (xc.SensitiveWordsFilter)translator.FastGetCSObj(L, 1);
            
            
            try {
                
                {
                    string raw = LuaAPI.lua_tostring(L, 2);
                    
                        bool __cl_gen_ret = __cl_gen_to_be_invoked.IsHaveSensitiveWords( raw );
                        LuaAPI.lua_pushboolean(L, __cl_gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_IsInputUserNameLegal(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            xc.SensitiveWordsFilter __cl_gen_to_be_invoked = (xc.SensitiveWordsFilter)translator.FastGetCSObj(L, 1);
            
            
			int __gen_param_count = LuaAPI.lua_gettop(L);
            
            try {
                if(__gen_param_count == 2&& (LuaAPI.lua_isnil(L, 2) || LuaAPI.lua_type(L, 2) == LuaTypes.LUA_TSTRING)) 
                {
                    string input = LuaAPI.lua_tostring(L, 2);
                    
                        bool __cl_gen_ret = __cl_gen_to_be_invoked.IsInputUserNameLegal( input );
                        LuaAPI.lua_pushboolean(L, __cl_gen_ret);
                    
                    
                    
                    return 1;
                }
                if(__gen_param_count == 3&& (LuaAPI.lua_isnil(L, 2) || LuaAPI.lua_type(L, 2) == LuaTypes.LUA_TSTRING)&& translator.Assignable<xc.RegionType>(L, 3)) 
                {
                    string input = LuaAPI.lua_tostring(L, 2);
                    xc.RegionType region;translator.Get(L, 3, out region);
                    
                        bool __cl_gen_ret = __cl_gen_to_be_invoked.IsInputUserNameLegal( input, region );
                        LuaAPI.lua_pushboolean(L, __cl_gen_ret);
                    
                    
                    
                    return 1;
                }
                if(__gen_param_count == 3&& (LuaAPI.lua_isnil(L, 2) || LuaAPI.lua_type(L, 2) == LuaTypes.LUA_TSTRING)&& translator.Assignable<xc.LanguageType>(L, 3)) 
                {
                    string input = LuaAPI.lua_tostring(L, 2);
                    xc.LanguageType lang;translator.Get(L, 3, out lang);
                    
                        bool __cl_gen_ret = __cl_gen_to_be_invoked.IsInputUserNameLegal( input, lang );
                        LuaAPI.lua_pushboolean(L, __cl_gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
            return LuaAPI.luaL_error(L, "invalid arguments to xc.SensitiveWordsFilter.IsInputUserNameLegal!");
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_ReplaceEmoji(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            xc.SensitiveWordsFilter __cl_gen_to_be_invoked = (xc.SensitiveWordsFilter)translator.FastGetCSObj(L, 1);
            
            
            try {
                
                {
                    string input = LuaAPI.lua_tostring(L, 2);
                    
                        string __cl_gen_ret = __cl_gen_to_be_invoked.ReplaceEmoji( input );
                        LuaAPI.lua_pushstring(L, __cl_gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        
        
        
        
        
		
		
		
		
    }
}
