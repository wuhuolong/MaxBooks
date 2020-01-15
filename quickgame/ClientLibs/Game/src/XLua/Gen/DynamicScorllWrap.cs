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
    public class DynamicScorllWrap
    {
        public static void __Register(RealStatePtr L)
        {
			ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			XUtils.BeginObjectRegister(typeof(DynamicScorll), L, translator, 0, 3, 7, 7);
			
			XUtils.RegisterFunc(L, XUtils.METHOD_IDX, "ScrollToBottom", _m_ScrollToBottom);
			XUtils.RegisterFunc(L, XUtils.METHOD_IDX, "AddItems", _m_AddItems);
			XUtils.RegisterFunc(L, XUtils.METHOD_IDX, "GetItems", _m_GetItems);
			
			
			XUtils.RegisterFunc(L, XUtils.GETTER_IDX, "totalCount", _g_get_totalCount);
            XUtils.RegisterFunc(L, XUtils.GETTER_IDX, "prefab", _g_get_prefab);
            XUtils.RegisterFunc(L, XUtils.GETTER_IDX, "poolSize", _g_get_poolSize);
            XUtils.RegisterFunc(L, XUtils.GETTER_IDX, "spacing", _g_get_spacing);
            XUtils.RegisterFunc(L, XUtils.GETTER_IDX, "onSetFunc", _g_get_onSetFunc);
            XUtils.RegisterFunc(L, XUtils.GETTER_IDX, "onSlider2Top", _g_get_onSlider2Top);
            XUtils.RegisterFunc(L, XUtils.GETTER_IDX, "onSlider2Bottom", _g_get_onSlider2Bottom);
            
			XUtils.RegisterFunc(L, XUtils.SETTER_IDX, "totalCount", _s_set_totalCount);
            XUtils.RegisterFunc(L, XUtils.SETTER_IDX, "prefab", _s_set_prefab);
            XUtils.RegisterFunc(L, XUtils.SETTER_IDX, "poolSize", _s_set_poolSize);
            XUtils.RegisterFunc(L, XUtils.SETTER_IDX, "spacing", _s_set_spacing);
            XUtils.RegisterFunc(L, XUtils.SETTER_IDX, "onSetFunc", _s_set_onSetFunc);
            XUtils.RegisterFunc(L, XUtils.SETTER_IDX, "onSlider2Top", _s_set_onSlider2Top);
            XUtils.RegisterFunc(L, XUtils.SETTER_IDX, "onSlider2Bottom", _s_set_onSlider2Bottom);
            
			XUtils.EndObjectRegister(typeof(DynamicScorll), L, translator, null, null,
			    null, null, null);

		    XUtils.BeginClassRegister(typeof(DynamicScorll), L, __CreateInstance, 1, 0, 0);
			
			
            
            XUtils.RegisterObject(L, translator, XUtils.CLS_IDX, "UnderlyingSystemType", typeof(DynamicScorll));
			
			
			XUtils.EndClassRegister(typeof(DynamicScorll), L, translator);
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int __CreateInstance(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			try {
				if(LuaAPI.lua_gettop(L) == 1)
				{
					
					DynamicScorll __cl_gen_ret = new DynamicScorll();
					translator.Push(L, __cl_gen_ret);
					return 1;
				}
				
			}
			catch(System.Exception __gen_e) {
				return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
			}
            return LuaAPI.luaL_error(L, "invalid arguments to DynamicScorll constructor!");
            
        }
        
		
        
		
        
        
        
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_ScrollToBottom(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            DynamicScorll __cl_gen_to_be_invoked = (DynamicScorll)translator.FastGetCSObj(L, 1);
            
            
            try {
                
                {
                    
                    __cl_gen_to_be_invoked.ScrollToBottom(  );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_AddItems(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            DynamicScorll __cl_gen_to_be_invoked = (DynamicScorll)translator.FastGetCSObj(L, 1);
            
            
            try {
                
                {
                    int count = LuaAPI.xlua_tointeger(L, 2);
                    
                    __cl_gen_to_be_invoked.AddItems( count );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_GetItems(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            DynamicScorll __cl_gen_to_be_invoked = (DynamicScorll)translator.FastGetCSObj(L, 1);
            
            
            try {
                
                {
                    
                        System.Collections.Generic.Dictionary<int, DynamicScorll.ItemInfo> __cl_gen_ret = __cl_gen_to_be_invoked.GetItems(  );
                        translator.Push(L, __cl_gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        
        
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_totalCount(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                DynamicScorll __cl_gen_to_be_invoked = (DynamicScorll)translator.FastGetCSObj(L, 1);
                LuaAPI.xlua_pushinteger(L, __cl_gen_to_be_invoked.totalCount);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_prefab(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                DynamicScorll __cl_gen_to_be_invoked = (DynamicScorll)translator.FastGetCSObj(L, 1);
                translator.Push(L, __cl_gen_to_be_invoked.prefab);
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
			
                DynamicScorll __cl_gen_to_be_invoked = (DynamicScorll)translator.FastGetCSObj(L, 1);
                LuaAPI.xlua_pushinteger(L, __cl_gen_to_be_invoked.poolSize);
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
			
                DynamicScorll __cl_gen_to_be_invoked = (DynamicScorll)translator.FastGetCSObj(L, 1);
                LuaAPI.lua_pushnumber(L, __cl_gen_to_be_invoked.spacing);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_onSetFunc(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                DynamicScorll __cl_gen_to_be_invoked = (DynamicScorll)translator.FastGetCSObj(L, 1);
                translator.Push(L, __cl_gen_to_be_invoked.onSetFunc);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_onSlider2Top(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                DynamicScorll __cl_gen_to_be_invoked = (DynamicScorll)translator.FastGetCSObj(L, 1);
                translator.Push(L, __cl_gen_to_be_invoked.onSlider2Top);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_onSlider2Bottom(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                DynamicScorll __cl_gen_to_be_invoked = (DynamicScorll)translator.FastGetCSObj(L, 1);
                translator.Push(L, __cl_gen_to_be_invoked.onSlider2Bottom);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_totalCount(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                DynamicScorll __cl_gen_to_be_invoked = (DynamicScorll)translator.FastGetCSObj(L, 1);
                __cl_gen_to_be_invoked.totalCount = LuaAPI.xlua_tointeger(L, 2);
            
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_prefab(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                DynamicScorll __cl_gen_to_be_invoked = (DynamicScorll)translator.FastGetCSObj(L, 1);
                __cl_gen_to_be_invoked.prefab = (UnityEngine.GameObject)translator.GetObject(L, 2, typeof(UnityEngine.GameObject));
            
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
			
                DynamicScorll __cl_gen_to_be_invoked = (DynamicScorll)translator.FastGetCSObj(L, 1);
                __cl_gen_to_be_invoked.poolSize = LuaAPI.xlua_tointeger(L, 2);
            
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
			
                DynamicScorll __cl_gen_to_be_invoked = (DynamicScorll)translator.FastGetCSObj(L, 1);
                __cl_gen_to_be_invoked.spacing = (float)LuaAPI.lua_tonumber(L, 2);
            
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_onSetFunc(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                DynamicScorll __cl_gen_to_be_invoked = (DynamicScorll)translator.FastGetCSObj(L, 1);
                __cl_gen_to_be_invoked.onSetFunc = translator.GetDelegate<DynamicScorll.OnSetItemFunc>(L, 2);
            
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_onSlider2Top(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                DynamicScorll __cl_gen_to_be_invoked = (DynamicScorll)translator.FastGetCSObj(L, 1);
                __cl_gen_to_be_invoked.onSlider2Top = translator.GetDelegate<DynamicScorll.OnSlider2Top>(L, 2);
            
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_onSlider2Bottom(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                DynamicScorll __cl_gen_to_be_invoked = (DynamicScorll)translator.FastGetCSObj(L, 1);
                __cl_gen_to_be_invoked.onSlider2Bottom = translator.GetDelegate<DynamicScorll.OnSlider2Bottom>(L, 2);
            
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 0;
        }
        
		
		
		
		
    }
}
