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
    public class ScrollViewExWrap
    {
        public static void __Register(RealStatePtr L)
        {
			ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			XUtils.BeginObjectRegister(typeof(ScrollViewEx), L, translator, 0, 11, 6, 6);
			
			XUtils.RegisterFunc(L, XUtils.METHOD_IDX, "PreviewInit", _m_PreviewInit);
			XUtils.RegisterFunc(L, XUtils.METHOD_IDX, "GetCellByIdx", _m_GetCellByIdx);
			XUtils.RegisterFunc(L, XUtils.METHOD_IDX, "ScrollToItem", _m_ScrollToItem);
			XUtils.RegisterFunc(L, XUtils.METHOD_IDX, "ScrollToOldPos", _m_ScrollToOldPos);
			XUtils.RegisterFunc(L, XUtils.METHOD_IDX, "EnabledScroll", _m_EnabledScroll);
			XUtils.RegisterFunc(L, XUtils.METHOD_IDX, "ReloadData", _m_ReloadData);
			XUtils.RegisterFunc(L, XUtils.METHOD_IDX, "GetVisualStartIdx", _m_GetVisualStartIdx);
			XUtils.RegisterFunc(L, XUtils.METHOD_IDX, "GetVisualEndIdx", _m_GetVisualEndIdx);
			XUtils.RegisterFunc(L, XUtils.METHOD_IDX, "GetCellsNum", _m_GetCellsNum);
			XUtils.RegisterFunc(L, XUtils.METHOD_IDX, "SetAtOrderValue", _m_SetAtOrderValue);
			XUtils.RegisterFunc(L, XUtils.METHOD_IDX, "SetCustomMove", _m_SetCustomMove);
			
			
			XUtils.RegisterFunc(L, XUtils.GETTER_IDX, "dataCount", _g_get_dataCount);
            XUtils.RegisterFunc(L, XUtils.GETTER_IDX, "rowNum", _g_get_rowNum);
            XUtils.RegisterFunc(L, XUtils.GETTER_IDX, "colNum", _g_get_colNum);
            XUtils.RegisterFunc(L, XUtils.GETTER_IDX, "spacing", _g_get_spacing);
            XUtils.RegisterFunc(L, XUtils.GETTER_IDX, "poolSize", _g_get_poolSize);
            XUtils.RegisterFunc(L, XUtils.GETTER_IDX, "LoopItemRefreshData", _g_get_LoopItemRefreshData);
            
			XUtils.RegisterFunc(L, XUtils.SETTER_IDX, "dataCount", _s_set_dataCount);
            XUtils.RegisterFunc(L, XUtils.SETTER_IDX, "rowNum", _s_set_rowNum);
            XUtils.RegisterFunc(L, XUtils.SETTER_IDX, "colNum", _s_set_colNum);
            XUtils.RegisterFunc(L, XUtils.SETTER_IDX, "spacing", _s_set_spacing);
            XUtils.RegisterFunc(L, XUtils.SETTER_IDX, "poolSize", _s_set_poolSize);
            XUtils.RegisterFunc(L, XUtils.SETTER_IDX, "LoopItemRefreshData", _s_set_LoopItemRefreshData);
            
			XUtils.EndObjectRegister(typeof(ScrollViewEx), L, translator, null, null,
			    null, null, null);

		    XUtils.BeginClassRegister(typeof(ScrollViewEx), L, __CreateInstance, 1, 0, 0);
			
			
            
            XUtils.RegisterObject(L, translator, XUtils.CLS_IDX, "UnderlyingSystemType", typeof(ScrollViewEx));
			
			
			XUtils.EndClassRegister(typeof(ScrollViewEx), L, translator);
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int __CreateInstance(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			try {
				if(LuaAPI.lua_gettop(L) == 1)
				{
					
					ScrollViewEx __cl_gen_ret = new ScrollViewEx();
					translator.Push(L, __cl_gen_ret);
					return 1;
				}
				
			}
			catch(System.Exception __gen_e) {
				return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
			}
            return LuaAPI.luaL_error(L, "invalid arguments to ScrollViewEx constructor!");
            
        }
        
		
        
		
        
        
        
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_PreviewInit(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            ScrollViewEx __cl_gen_to_be_invoked = (ScrollViewEx)translator.FastGetCSObj(L, 1);
            
            
            try {
                
                {
                    
                    __cl_gen_to_be_invoked.PreviewInit(  );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_GetCellByIdx(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            ScrollViewEx __cl_gen_to_be_invoked = (ScrollViewEx)translator.FastGetCSObj(L, 1);
            
            
            try {
                
                {
                    int idx = LuaAPI.xlua_tointeger(L, 2);
                    
                        UnityEngine.GameObject __cl_gen_ret = __cl_gen_to_be_invoked.GetCellByIdx( idx );
                        translator.Push(L, __cl_gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_ScrollToItem(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            ScrollViewEx __cl_gen_to_be_invoked = (ScrollViewEx)translator.FastGetCSObj(L, 1);
            
            
            try {
                
                {
                    int idx = LuaAPI.xlua_tointeger(L, 2);
                    
                    __cl_gen_to_be_invoked.ScrollToItem( idx );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_ScrollToOldPos(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            ScrollViewEx __cl_gen_to_be_invoked = (ScrollViewEx)translator.FastGetCSObj(L, 1);
            
            
            try {
                
                {
                    
                    __cl_gen_to_be_invoked.ScrollToOldPos(  );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_EnabledScroll(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            ScrollViewEx __cl_gen_to_be_invoked = (ScrollViewEx)translator.FastGetCSObj(L, 1);
            
            
			int __gen_param_count = LuaAPI.lua_gettop(L);
            
            try {
                if(__gen_param_count == 3&& LuaTypes.LUA_TBOOLEAN == LuaAPI.lua_type(L, 2)&& LuaTypes.LUA_TBOOLEAN == LuaAPI.lua_type(L, 3)) 
                {
                    bool bForce = LuaAPI.lua_toboolean(L, 2);
                    bool bScroll = LuaAPI.lua_toboolean(L, 3);
                    
                    __cl_gen_to_be_invoked.EnabledScroll( bForce, bScroll );
                    
                    
                    
                    return 0;
                }
                if(__gen_param_count == 2&& LuaTypes.LUA_TBOOLEAN == LuaAPI.lua_type(L, 2)) 
                {
                    bool bForce = LuaAPI.lua_toboolean(L, 2);
                    
                    __cl_gen_to_be_invoked.EnabledScroll( bForce );
                    
                    
                    
                    return 0;
                }
                if(__gen_param_count == 1) 
                {
                    
                    __cl_gen_to_be_invoked.EnabledScroll(  );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
            return LuaAPI.luaL_error(L, "invalid arguments to ScrollViewEx.EnabledScroll!");
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_ReloadData(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            ScrollViewEx __cl_gen_to_be_invoked = (ScrollViewEx)translator.FastGetCSObj(L, 1);
            
            
            try {
                
                {
                    
                    __cl_gen_to_be_invoked.ReloadData(  );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_GetVisualStartIdx(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            ScrollViewEx __cl_gen_to_be_invoked = (ScrollViewEx)translator.FastGetCSObj(L, 1);
            
            
            try {
                
                {
                    
                        int __cl_gen_ret = __cl_gen_to_be_invoked.GetVisualStartIdx(  );
                        LuaAPI.xlua_pushinteger(L, __cl_gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_GetVisualEndIdx(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            ScrollViewEx __cl_gen_to_be_invoked = (ScrollViewEx)translator.FastGetCSObj(L, 1);
            
            
            try {
                
                {
                    
                        int __cl_gen_ret = __cl_gen_to_be_invoked.GetVisualEndIdx(  );
                        LuaAPI.xlua_pushinteger(L, __cl_gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_GetCellsNum(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            ScrollViewEx __cl_gen_to_be_invoked = (ScrollViewEx)translator.FastGetCSObj(L, 1);
            
            
            try {
                
                {
                    
                        int __cl_gen_ret = __cl_gen_to_be_invoked.GetCellsNum(  );
                        LuaAPI.xlua_pushinteger(L, __cl_gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_SetAtOrderValue(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            ScrollViewEx __cl_gen_to_be_invoked = (ScrollViewEx)translator.FastGetCSObj(L, 1);
            
            
            try {
                
                {
                    bool enable = LuaAPI.lua_toboolean(L, 2);
                    
                    __cl_gen_to_be_invoked.SetAtOrderValue( enable );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_SetCustomMove(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            ScrollViewEx __cl_gen_to_be_invoked = (ScrollViewEx)translator.FastGetCSObj(L, 1);
            
            
            try {
                
                {
                    bool enable = LuaAPI.lua_toboolean(L, 2);
                    
                    __cl_gen_to_be_invoked.SetCustomMove( enable );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        
        
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_dataCount(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                ScrollViewEx __cl_gen_to_be_invoked = (ScrollViewEx)translator.FastGetCSObj(L, 1);
                LuaAPI.xlua_pushinteger(L, __cl_gen_to_be_invoked.dataCount);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_rowNum(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                ScrollViewEx __cl_gen_to_be_invoked = (ScrollViewEx)translator.FastGetCSObj(L, 1);
                LuaAPI.xlua_pushinteger(L, __cl_gen_to_be_invoked.rowNum);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_colNum(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                ScrollViewEx __cl_gen_to_be_invoked = (ScrollViewEx)translator.FastGetCSObj(L, 1);
                LuaAPI.xlua_pushinteger(L, __cl_gen_to_be_invoked.colNum);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_spacing(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                ScrollViewEx __cl_gen_to_be_invoked = (ScrollViewEx)translator.FastGetCSObj(L, 1);
                translator.PushUnityEngineVector2(L, __cl_gen_to_be_invoked.spacing);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_poolSize(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                ScrollViewEx __cl_gen_to_be_invoked = (ScrollViewEx)translator.FastGetCSObj(L, 1);
                LuaAPI.xlua_pushinteger(L, __cl_gen_to_be_invoked.poolSize);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_LoopItemRefreshData(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                ScrollViewEx __cl_gen_to_be_invoked = (ScrollViewEx)translator.FastGetCSObj(L, 1);
                translator.Push(L, __cl_gen_to_be_invoked.LoopItemRefreshData);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_dataCount(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                ScrollViewEx __cl_gen_to_be_invoked = (ScrollViewEx)translator.FastGetCSObj(L, 1);
                __cl_gen_to_be_invoked.dataCount = LuaAPI.xlua_tointeger(L, 2);
            
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_rowNum(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                ScrollViewEx __cl_gen_to_be_invoked = (ScrollViewEx)translator.FastGetCSObj(L, 1);
                __cl_gen_to_be_invoked.rowNum = LuaAPI.xlua_tointeger(L, 2);
            
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_colNum(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                ScrollViewEx __cl_gen_to_be_invoked = (ScrollViewEx)translator.FastGetCSObj(L, 1);
                __cl_gen_to_be_invoked.colNum = LuaAPI.xlua_tointeger(L, 2);
            
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_spacing(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                ScrollViewEx __cl_gen_to_be_invoked = (ScrollViewEx)translator.FastGetCSObj(L, 1);
                UnityEngine.Vector2 __cl_gen_value;translator.Get(L, 2, out __cl_gen_value);
				__cl_gen_to_be_invoked.spacing = __cl_gen_value;
            
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_poolSize(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                ScrollViewEx __cl_gen_to_be_invoked = (ScrollViewEx)translator.FastGetCSObj(L, 1);
                __cl_gen_to_be_invoked.poolSize = LuaAPI.xlua_tointeger(L, 2);
            
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_LoopItemRefreshData(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                ScrollViewEx __cl_gen_to_be_invoked = (ScrollViewEx)translator.FastGetCSObj(L, 1);
                __cl_gen_to_be_invoked.LoopItemRefreshData = translator.GetDelegate<System.Func<UnityEngine.GameObject, int, bool>>(L, 2);
            
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 0;
        }
        
		
		
		
		
    }
}
