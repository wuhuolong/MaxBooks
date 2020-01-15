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
    public class LuaDragComponentWrap
    {
        public static void __Register(RealStatePtr L)
        {
			ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			XUtils.BeginObjectRegister(typeof(LuaDragComponent), L, translator, 0, 2, 2, 2);
			
			XUtils.RegisterFunc(L, XUtils.METHOD_IDX, "OnBeginDrag", _m_OnBeginDrag);
			XUtils.RegisterFunc(L, XUtils.METHOD_IDX, "OnEndDrag", _m_OnEndDrag);
			
			
			XUtils.RegisterFunc(L, XUtils.GETTER_IDX, "CbOnBeginDrag", _g_get_CbOnBeginDrag);
            XUtils.RegisterFunc(L, XUtils.GETTER_IDX, "CbOnEndDrag", _g_get_CbOnEndDrag);
            
			XUtils.RegisterFunc(L, XUtils.SETTER_IDX, "CbOnBeginDrag", _s_set_CbOnBeginDrag);
            XUtils.RegisterFunc(L, XUtils.SETTER_IDX, "CbOnEndDrag", _s_set_CbOnEndDrag);
            
			XUtils.EndObjectRegister(typeof(LuaDragComponent), L, translator, null, null,
			    null, null, null);

		    XUtils.BeginClassRegister(typeof(LuaDragComponent), L, __CreateInstance, 1, 0, 0);
			
			
            
            XUtils.RegisterObject(L, translator, XUtils.CLS_IDX, "UnderlyingSystemType", typeof(LuaDragComponent));
			
			
			XUtils.EndClassRegister(typeof(LuaDragComponent), L, translator);
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int __CreateInstance(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			try {
				if(LuaAPI.lua_gettop(L) == 1)
				{
					
					LuaDragComponent __cl_gen_ret = new LuaDragComponent();
					translator.Push(L, __cl_gen_ret);
					return 1;
				}
				
			}
			catch(System.Exception __gen_e) {
				return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
			}
            return LuaAPI.luaL_error(L, "invalid arguments to LuaDragComponent constructor!");
            
        }
        
		
        
		
        
        
        
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_OnBeginDrag(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            LuaDragComponent __cl_gen_to_be_invoked = (LuaDragComponent)translator.FastGetCSObj(L, 1);
            
            
            try {
                
                {
                    UnityEngine.EventSystems.PointerEventData eventData = (UnityEngine.EventSystems.PointerEventData)translator.GetObject(L, 2, typeof(UnityEngine.EventSystems.PointerEventData));
                    
                    __cl_gen_to_be_invoked.OnBeginDrag( eventData );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_OnEndDrag(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            LuaDragComponent __cl_gen_to_be_invoked = (LuaDragComponent)translator.FastGetCSObj(L, 1);
            
            
            try {
                
                {
                    UnityEngine.EventSystems.PointerEventData eventData = (UnityEngine.EventSystems.PointerEventData)translator.GetObject(L, 2, typeof(UnityEngine.EventSystems.PointerEventData));
                    
                    __cl_gen_to_be_invoked.OnEndDrag( eventData );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        
        
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_CbOnBeginDrag(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                LuaDragComponent __cl_gen_to_be_invoked = (LuaDragComponent)translator.FastGetCSObj(L, 1);
                translator.Push(L, __cl_gen_to_be_invoked.CbOnBeginDrag);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_CbOnEndDrag(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                LuaDragComponent __cl_gen_to_be_invoked = (LuaDragComponent)translator.FastGetCSObj(L, 1);
                translator.Push(L, __cl_gen_to_be_invoked.CbOnEndDrag);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_CbOnBeginDrag(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                LuaDragComponent __cl_gen_to_be_invoked = (LuaDragComponent)translator.FastGetCSObj(L, 1);
                __cl_gen_to_be_invoked.CbOnBeginDrag = translator.GetDelegate<System.Action>(L, 2);
            
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_CbOnEndDrag(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                LuaDragComponent __cl_gen_to_be_invoked = (LuaDragComponent)translator.FastGetCSObj(L, 1);
                __cl_gen_to_be_invoked.CbOnEndDrag = translator.GetDelegate<System.Action>(L, 2);
            
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 0;
        }
        
		
		
		
		
    }
}
