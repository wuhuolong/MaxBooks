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
    public class xcCommonToolWrap
    {
        public static void __Register(RealStatePtr L)
        {
			ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			XUtils.BeginObjectRegister(typeof(xc.CommonTool), L, translator, 0, 0, 0, 0);
			
			
			
			
			
			XUtils.EndObjectRegister(typeof(xc.CommonTool), L, translator, null, null,
			    null, null, null);

		    XUtils.BeginClassRegister(typeof(xc.CommonTool), L, __CreateInstance, 22, 0, 0);
			XUtils.RegisterFunc(L, XUtils.CLS_IDX, "BytesToUtf8", _m_BytesToUtf8_xlua_st_);
            XUtils.RegisterFunc(L, XUtils.CLS_IDX, "GetWordLenByRule", _m_GetWordLenByRule_xlua_st_);
            XUtils.RegisterFunc(L, XUtils.CLS_IDX, "GetMD5", _m_GetMD5_xlua_st_);
            XUtils.RegisterFunc(L, XUtils.CLS_IDX, "GetFileMD5", _m_GetFileMD5_xlua_st_);
            XUtils.RegisterFunc(L, XUtils.CLS_IDX, "CreateChildGameObject", _m_CreateChildGameObject_xlua_st_);
            XUtils.RegisterFunc(L, XUtils.CLS_IDX, "FindChildInHierarchy", _m_FindChildInHierarchy_xlua_st_);
            XUtils.RegisterFunc(L, XUtils.CLS_IDX, "DestroyObjectImmediate", _m_DestroyObjectImmediate_xlua_st_);
            XUtils.RegisterFunc(L, XUtils.CLS_IDX, "GetDayOfWeekString", _m_GetDayOfWeekString_xlua_st_);
            XUtils.RegisterFunc(L, XUtils.CLS_IDX, "ColorToHex", _m_ColorToHex_xlua_st_);
            XUtils.RegisterFunc(L, XUtils.CLS_IDX, "HexToColor", _m_HexToColor_xlua_st_);
            XUtils.RegisterFunc(L, XUtils.CLS_IDX, "SecondsToStr", _m_SecondsToStr_xlua_st_);
            XUtils.RegisterFunc(L, XUtils.CLS_IDX, "SecondsToStr_2", _m_SecondsToStr_2_xlua_st_);
            XUtils.RegisterFunc(L, XUtils.CLS_IDX, "SecondsToStr_3", _m_SecondsToStr_3_xlua_st_);
            XUtils.RegisterFunc(L, XUtils.CLS_IDX, "SecondsToStr_4", _m_SecondsToStr_4_xlua_st_);
            XUtils.RegisterFunc(L, XUtils.CLS_IDX, "SecondsToStr_showAllTime", _m_SecondsToStr_showAllTime_xlua_st_);
            XUtils.RegisterFunc(L, XUtils.CLS_IDX, "SetChildLayer", _m_SetChildLayer_xlua_st_);
            XUtils.RegisterFunc(L, XUtils.CLS_IDX, "SetActive", _m_SetActive_xlua_st_);
            XUtils.RegisterFunc(L, XUtils.CLS_IDX, "RemoveAllChildrenExcept", _m_RemoveAllChildrenExcept_xlua_st_);
            XUtils.RegisterFunc(L, XUtils.CLS_IDX, "GetCurTimeStamp", _m_GetCurTimeStamp_xlua_st_);
            XUtils.RegisterFunc(L, XUtils.CLS_IDX, "WipeFileSprit", _m_WipeFileSprit_xlua_st_);
            XUtils.RegisterFunc(L, XUtils.CLS_IDX, "ParsePrice", _m_ParsePrice_xlua_st_);
            
			
            
            XUtils.RegisterObject(L, translator, XUtils.CLS_IDX, "UnderlyingSystemType", typeof(xc.CommonTool));
			
			
			XUtils.EndClassRegister(typeof(xc.CommonTool), L, translator);
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int __CreateInstance(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			try {
				if(LuaAPI.lua_gettop(L) == 1)
				{
					
					xc.CommonTool __cl_gen_ret = new xc.CommonTool();
					translator.Push(L, __cl_gen_ret);
					return 1;
				}
				
			}
			catch(System.Exception __gen_e) {
				return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
			}
            return LuaAPI.luaL_error(L, "invalid arguments to xc.CommonTool constructor!");
            
        }
        
		
        
		
        
        
        
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_BytesToUtf8_xlua_st_(RealStatePtr L)
        {
            
            
            
            try {
                
                {
                    byte[] total = LuaAPI.lua_tobytes(L, 1);
                    
                        string __cl_gen_ret = xc.CommonTool.BytesToUtf8( total );
                        LuaAPI.lua_pushstring(L, __cl_gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_GetWordLenByRule_xlua_st_(RealStatePtr L)
        {
            
            
            
            try {
                
                {
                    string str = LuaAPI.lua_tostring(L, 1);
                    
                        float __cl_gen_ret = xc.CommonTool.GetWordLenByRule( str );
                        LuaAPI.lua_pushnumber(L, __cl_gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_GetMD5_xlua_st_(RealStatePtr L)
        {
            
            
            
			int __gen_param_count = LuaAPI.lua_gettop(L);
            
            try {
                if(__gen_param_count == 1&& (LuaAPI.lua_isnil(L, 1) || LuaAPI.lua_type(L, 1) == LuaTypes.LUA_TSTRING)) 
                {
                    string v = LuaAPI.lua_tostring(L, 1);
                    
                        string __cl_gen_ret = xc.CommonTool.GetMD5( v );
                        LuaAPI.lua_pushstring(L, __cl_gen_ret);
                    
                    
                    
                    return 1;
                }
                if(__gen_param_count == 1&& (LuaAPI.lua_isnil(L, 1) || LuaAPI.lua_type(L, 1) == LuaTypes.LUA_TSTRING)) 
                {
                    byte[] bin = LuaAPI.lua_tobytes(L, 1);
                    
                        string __cl_gen_ret = xc.CommonTool.GetMD5( bin );
                        LuaAPI.lua_pushstring(L, __cl_gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
            return LuaAPI.luaL_error(L, "invalid arguments to xc.CommonTool.GetMD5!");
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_GetFileMD5_xlua_st_(RealStatePtr L)
        {
            
            
            
            try {
                
                {
                    string filePath = LuaAPI.lua_tostring(L, 1);
                    
                        string __cl_gen_ret = xc.CommonTool.GetFileMD5( filePath );
                        LuaAPI.lua_pushstring(L, __cl_gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_CreateChildGameObject_xlua_st_(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            
            try {
                
                {
                    UnityEngine.GameObject _parent = (UnityEngine.GameObject)translator.GetObject(L, 1, typeof(UnityEngine.GameObject));
                    string _name = LuaAPI.lua_tostring(L, 2);
                    
                        UnityEngine.GameObject __cl_gen_ret = xc.CommonTool.CreateChildGameObject( _parent, _name );
                        translator.Push(L, __cl_gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_FindChildInHierarchy_xlua_st_(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            
            try {
                
                {
                    UnityEngine.Transform parent = (UnityEngine.Transform)translator.GetObject(L, 1, typeof(UnityEngine.Transform));
                    string name = LuaAPI.lua_tostring(L, 2);
                    
                        UnityEngine.Transform __cl_gen_ret = xc.CommonTool.FindChildInHierarchy( parent, name );
                        translator.Push(L, __cl_gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_DestroyObjectImmediate_xlua_st_(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            
            try {
                
                {
                    UnityEngine.Object obj = (UnityEngine.Object)translator.GetObject(L, 1, typeof(UnityEngine.Object));
                    
                    xc.CommonTool.DestroyObjectImmediate( obj );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_GetDayOfWeekString_xlua_st_(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            
            try {
                
                {
                    System.DayOfWeek day;translator.Get(L, 1, out day);
                    
                        string __cl_gen_ret = xc.CommonTool.GetDayOfWeekString( day );
                        LuaAPI.lua_pushstring(L, __cl_gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_ColorToHex_xlua_st_(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            
            try {
                
                {
                    UnityEngine.Color color;translator.Get(L, 1, out color);
                    
                        string __cl_gen_ret = xc.CommonTool.ColorToHex( color );
                        LuaAPI.lua_pushstring(L, __cl_gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_HexToColor_xlua_st_(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            
            try {
                
                {
                    string hex = LuaAPI.lua_tostring(L, 1);
                    
                        UnityEngine.Color __cl_gen_ret = xc.CommonTool.HexToColor( hex );
                        translator.PushUnityEngineColor(L, __cl_gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_SecondsToStr_xlua_st_(RealStatePtr L)
        {
            
            
            
            try {
                
                {
                    int total_seconds = LuaAPI.xlua_tointeger(L, 1);
                    
                        string __cl_gen_ret = xc.CommonTool.SecondsToStr( total_seconds );
                        LuaAPI.lua_pushstring(L, __cl_gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_SecondsToStr_2_xlua_st_(RealStatePtr L)
        {
            
            
            
            try {
                
                {
                    int total_seconds = LuaAPI.xlua_tointeger(L, 1);
                    
                        string __cl_gen_ret = xc.CommonTool.SecondsToStr_2( total_seconds );
                        LuaAPI.lua_pushstring(L, __cl_gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_SecondsToStr_3_xlua_st_(RealStatePtr L)
        {
            
            
            
            try {
                
                {
                    int total_seconds = LuaAPI.xlua_tointeger(L, 1);
                    
                        string __cl_gen_ret = xc.CommonTool.SecondsToStr_3( total_seconds );
                        LuaAPI.lua_pushstring(L, __cl_gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_SecondsToStr_4_xlua_st_(RealStatePtr L)
        {
            
            
            
            try {
                
                {
                    int total_seconds = LuaAPI.xlua_tointeger(L, 1);
                    
                        string __cl_gen_ret = xc.CommonTool.SecondsToStr_4( total_seconds );
                        LuaAPI.lua_pushstring(L, __cl_gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_SecondsToStr_showAllTime_xlua_st_(RealStatePtr L)
        {
            
            
            
            try {
                
                {
                    int total_seconds = LuaAPI.xlua_tointeger(L, 1);
                    
                        string __cl_gen_ret = xc.CommonTool.SecondsToStr_showAllTime( total_seconds );
                        LuaAPI.lua_pushstring(L, __cl_gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_SetChildLayer_xlua_st_(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            
            try {
                
                {
                    UnityEngine.Transform t = (UnityEngine.Transform)translator.GetObject(L, 1, typeof(UnityEngine.Transform));
                    int layer = LuaAPI.xlua_tointeger(L, 2);
                    
                    xc.CommonTool.SetChildLayer( t, layer );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_SetActive_xlua_st_(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            
            try {
                
                {
                    UnityEngine.GameObject game_object = (UnityEngine.GameObject)translator.GetObject(L, 1, typeof(UnityEngine.GameObject));
                    bool active = LuaAPI.lua_toboolean(L, 2);
                    
                    xc.CommonTool.SetActive( game_object, active );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_RemoveAllChildrenExcept_xlua_st_(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            
            try {
                
                {
                    UnityEngine.GameObject parent = (UnityEngine.GameObject)translator.GetObject(L, 1, typeof(UnityEngine.GameObject));
                    string exceptName = LuaAPI.lua_tostring(L, 2);
                    
                    xc.CommonTool.RemoveAllChildrenExcept( parent, exceptName );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_GetCurTimeStamp_xlua_st_(RealStatePtr L)
        {
            
            
            
            try {
                
                {
                    
                        long __cl_gen_ret = xc.CommonTool.GetCurTimeStamp(  );
                        LuaAPI.lua_pushint64(L, __cl_gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_WipeFileSprit_xlua_st_(RealStatePtr L)
        {
            
            
            
            try {
                
                {
                    string bundle_url = LuaAPI.lua_tostring(L, 1);
                    
                        string __cl_gen_ret = xc.CommonTool.WipeFileSprit( bundle_url );
                        LuaAPI.lua_pushstring(L, __cl_gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_ParsePrice_xlua_st_(RealStatePtr L)
        {
            
            
            
			int __gen_param_count = LuaAPI.lua_gettop(L);
            
            try {
                if(__gen_param_count == 1&& LuaTypes.LUA_TNUMBER == LuaAPI.lua_type(L, 1)) 
                {
                    float price = (float)LuaAPI.lua_tonumber(L, 1);
                    
                        string __cl_gen_ret = xc.CommonTool.ParsePrice( price );
                        LuaAPI.lua_pushstring(L, __cl_gen_ret);
                    
                    
                    
                    return 1;
                }
                if(__gen_param_count == 1&& (LuaAPI.lua_isnil(L, 1) || LuaAPI.lua_type(L, 1) == LuaTypes.LUA_TSTRING)) 
                {
                    string price = LuaAPI.lua_tostring(L, 1);
                    
                        string __cl_gen_ret = xc.CommonTool.ParsePrice( price );
                        LuaAPI.lua_pushstring(L, __cl_gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
            return LuaAPI.luaL_error(L, "invalid arguments to xc.CommonTool.ParsePrice!");
            
        }
        
        
        
        
        
        
		
		
		
		
    }
}
