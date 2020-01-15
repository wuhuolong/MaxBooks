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
    public class GameDebugWrap
    {
        public static void __Register(RealStatePtr L)
        {
			ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			XUtils.BeginObjectRegister(typeof(GameDebug), L, translator, 0, 0, 0, 0);
			
			
			
			
			
			XUtils.EndObjectRegister(typeof(GameDebug), L, translator, null, null,
			    null, null, null);

		    XUtils.BeginClassRegister(typeof(GameDebug), L, __CreateInstance, 12, 0, 0);
			XUtils.RegisterFunc(L, XUtils.CLS_IDX, "Log", _m_Log_xlua_st_);
            XUtils.RegisterFunc(L, XUtils.CLS_IDX, "LogRed", _m_LogRed_xlua_st_);
            XUtils.RegisterFunc(L, XUtils.CLS_IDX, "LogGreen", _m_LogGreen_xlua_st_);
            XUtils.RegisterFunc(L, XUtils.CLS_IDX, "LogYellow", _m_LogYellow_xlua_st_);
            XUtils.RegisterFunc(L, XUtils.CLS_IDX, "LogColor", _m_LogColor_xlua_st_);
            XUtils.RegisterFunc(L, XUtils.CLS_IDX, "LogWarning", _m_LogWarning_xlua_st_);
            XUtils.RegisterFunc(L, XUtils.CLS_IDX, "LogError", _m_LogError_xlua_st_);
            XUtils.RegisterFunc(L, XUtils.CLS_IDX, "ParseProtoPack", _m_ParseProtoPack_xlua_st_);
            
			
            XUtils.RegisterObject(L, translator, XUtils.CLS_IDX, "RED", GameDebug.RED);
            XUtils.RegisterObject(L, translator, XUtils.CLS_IDX, "GREEN", GameDebug.GREEN);
            XUtils.RegisterObject(L, translator, XUtils.CLS_IDX, "YELLOW", GameDebug.YELLOW);
            
            XUtils.RegisterObject(L, translator, XUtils.CLS_IDX, "UnderlyingSystemType", typeof(GameDebug));
			
			
			XUtils.EndClassRegister(typeof(GameDebug), L, translator);
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int __CreateInstance(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			try {
				if(LuaAPI.lua_gettop(L) == 1)
				{
					
					GameDebug __cl_gen_ret = new GameDebug();
					translator.Push(L, __cl_gen_ret);
					return 1;
				}
				
			}
			catch(System.Exception __gen_e) {
				return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
			}
            return LuaAPI.luaL_error(L, "invalid arguments to GameDebug constructor!");
            
        }
        
		
        
		
        
        
        
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_Log_xlua_st_(RealStatePtr L)
        {
            
            
            
            try {
                
                {
#if UNITY_EDITOR
                    string text = LuaAPI.lua_tostring(L, 1);
                    
                    GameDebug.Log( text );
#else
                    LuaAPI.lua_tostring_noret(L, 1);
#endif



                    return 0;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_LogRed_xlua_st_(RealStatePtr L)
        {
            
            
            
            try {
                
                {
#if UNITY_EDITOR
                    string text = LuaAPI.lua_tostring(L, 1);
                    
                    GameDebug.LogRed( text );
#else
                    LuaAPI.lua_tostring_noret(L, 1);
#endif



                    return 0;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_LogGreen_xlua_st_(RealStatePtr L)
        {
            
            
            
            try {
                
                {
#if UNITY_EDITOR
                    string text = LuaAPI.lua_tostring(L, 1);
                    
                    GameDebug.LogGreen( text );
#else
                    LuaAPI.lua_tostring_noret(L, 1);
#endif


                    return 0;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_LogYellow_xlua_st_(RealStatePtr L)
        {
            
            
            
            try {
                
                {
#if UNITY_EDITOR
                    string text = LuaAPI.lua_tostring(L, 1);
                    
                    GameDebug.LogYellow( text );

#else
                    LuaAPI.lua_tostring_noret(L, 1);
#endif

                    return 0;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_LogColor_xlua_st_(RealStatePtr L)
        {
            
            
            
            try {
                
                {
#if UNITY_EDITOR
                    string text = LuaAPI.lua_tostring(L, 1);
                    string color = LuaAPI.lua_tostring(L, 2);
                    
                    GameDebug.LogColor( text, color );

#else
                    LuaAPI.lua_tostring_noret(L, 1);
                    LuaAPI.lua_tostring_noret(L, 2);
#endif

                    return 0;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_LogWarning_xlua_st_(RealStatePtr L)
        {
            
            
            
            try {
                
                {
#if UNITY_EDITOR
                    string text = LuaAPI.lua_tostring(L, 1);
                    
                    GameDebug.LogWarning( text );

#else
                    LuaAPI.lua_tostring_noret(L, 1);
#endif

                    return 0;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_LogError_xlua_st_(RealStatePtr L)
        {
            
            
            
            try {
                
                {
                    string text = LuaAPI.lua_tostring(L, 1);
                    
                    GameDebug.LogError( text );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_ParseProtoPack_xlua_st_(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            
            try {
                
                {
                    object pack = translator.GetObject(L, 1, typeof(object));
                    
                        string __cl_gen_ret = GameDebug.ParseProtoPack( pack );
                        LuaAPI.lua_pushstring(L, __cl_gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        
        
        
        
        
		
		
		
		
    }
}
