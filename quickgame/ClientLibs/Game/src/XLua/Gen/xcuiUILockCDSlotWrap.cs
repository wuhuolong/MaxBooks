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
    public class xcuiUILockCDSlotWrap
    {
        public static void __Register(RealStatePtr L)
        {
			ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			XUtils.BeginObjectRegister(typeof(xc.ui.UILockCDSlot), L, translator, 0, 4, 3, 3);
			
			XUtils.RegisterFunc(L, XUtils.METHOD_IDX, "RestTime", _m_RestTime);
			XUtils.RegisterFunc(L, XUtils.METHOD_IDX, "SetNoStart", _m_SetNoStart);
			XUtils.RegisterFunc(L, XUtils.METHOD_IDX, "Clear", _m_Clear);
			XUtils.RegisterFunc(L, XUtils.METHOD_IDX, "Init", _m_Init);
			
			
			XUtils.RegisterFunc(L, XUtils.GETTER_IDX, "State", _g_get_State);
            XUtils.RegisterFunc(L, XUtils.GETTER_IDX, "mFunc", _g_get_mFunc);
            XUtils.RegisterFunc(L, XUtils.GETTER_IDX, "mParam", _g_get_mParam);
            
			XUtils.RegisterFunc(L, XUtils.SETTER_IDX, "State", _s_set_State);
            XUtils.RegisterFunc(L, XUtils.SETTER_IDX, "mFunc", _s_set_mFunc);
            XUtils.RegisterFunc(L, XUtils.SETTER_IDX, "mParam", _s_set_mParam);
            
			XUtils.EndObjectRegister(typeof(xc.ui.UILockCDSlot), L, translator, null, null,
			    null, null, null);

		    XUtils.BeginClassRegister(typeof(xc.ui.UILockCDSlot), L, __CreateInstance, 2, 0, 0);
			XUtils.RegisterFunc(L, XUtils.CLS_IDX, "Bind", _m_Bind_xlua_st_);
            
			
            
            XUtils.RegisterObject(L, translator, XUtils.CLS_IDX, "UnderlyingSystemType", typeof(xc.ui.UILockCDSlot));
			
			
			XUtils.EndClassRegister(typeof(xc.ui.UILockCDSlot), L, translator);
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int __CreateInstance(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			try {
				if(LuaAPI.lua_gettop(L) == 1)
				{
					
					xc.ui.UILockCDSlot __cl_gen_ret = new xc.ui.UILockCDSlot();
					translator.Push(L, __cl_gen_ret);
					return 1;
				}
				
			}
			catch(System.Exception __gen_e) {
				return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
			}
            return LuaAPI.luaL_error(L, "invalid arguments to xc.ui.UILockCDSlot constructor!");
            
        }
        
		
        
		
        
        
        
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_Bind_xlua_st_(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            
            try {
                
                {
                    UnityEngine.GameObject obj = (UnityEngine.GameObject)translator.GetObject(L, 1, typeof(UnityEngine.GameObject));
                    
                    xc.ui.UILockCDSlot.Bind( obj );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_RestTime(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            xc.ui.UILockCDSlot __cl_gen_to_be_invoked = (xc.ui.UILockCDSlot)translator.FastGetCSObj(L, 1);
            
            
            try {
                
                {
                    uint start_cd = LuaAPI.xlua_touint(L, 2);
                    uint cd = LuaAPI.xlua_touint(L, 3);
                    
                    __cl_gen_to_be_invoked.RestTime( start_cd, cd );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_SetNoStart(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            xc.ui.UILockCDSlot __cl_gen_to_be_invoked = (xc.ui.UILockCDSlot)translator.FastGetCSObj(L, 1);
            
            
            try {
                
                {
                    
                    __cl_gen_to_be_invoked.SetNoStart(  );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_Clear(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            xc.ui.UILockCDSlot __cl_gen_to_be_invoked = (xc.ui.UILockCDSlot)translator.FastGetCSObj(L, 1);
            
            
            try {
                
                {
                    
                    __cl_gen_to_be_invoked.Clear(  );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_Init(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            xc.ui.UILockCDSlot __cl_gen_to_be_invoked = (xc.ui.UILockCDSlot)translator.FastGetCSObj(L, 1);
            
            
			int __gen_param_count = LuaAPI.lua_gettop(L);
            
            try {
                if(__gen_param_count == 3&& translator.Assignable<xc.ui.UILockCDSlot.OnClickFunc>(L, 2)&& translator.Assignable<object>(L, 3)) 
                {
                    xc.ui.UILockCDSlot.OnClickFunc func = translator.GetDelegate<xc.ui.UILockCDSlot.OnClickFunc>(L, 2);
                    object param = translator.GetObject(L, 3, typeof(object));
                    
                    __cl_gen_to_be_invoked.Init( func, param );
                    
                    
                    
                    return 0;
                }
                if(__gen_param_count == 2&& translator.Assignable<xc.ui.UILockCDSlot.OnClickFunc>(L, 2)) 
                {
                    xc.ui.UILockCDSlot.OnClickFunc func = translator.GetDelegate<xc.ui.UILockCDSlot.OnClickFunc>(L, 2);
                    
                    __cl_gen_to_be_invoked.Init( func );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
            return LuaAPI.luaL_error(L, "invalid arguments to xc.ui.UILockCDSlot.Init!");
            
        }
        
        
        
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_State(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.ui.UILockCDSlot __cl_gen_to_be_invoked = (xc.ui.UILockCDSlot)translator.FastGetCSObj(L, 1);
                translator.Push(L, __cl_gen_to_be_invoked.State);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_mFunc(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.ui.UILockCDSlot __cl_gen_to_be_invoked = (xc.ui.UILockCDSlot)translator.FastGetCSObj(L, 1);
                translator.Push(L, __cl_gen_to_be_invoked.mFunc);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_mParam(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.ui.UILockCDSlot __cl_gen_to_be_invoked = (xc.ui.UILockCDSlot)translator.FastGetCSObj(L, 1);
                translator.PushAny(L, __cl_gen_to_be_invoked.mParam);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_State(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.ui.UILockCDSlot __cl_gen_to_be_invoked = (xc.ui.UILockCDSlot)translator.FastGetCSObj(L, 1);
                xc.ui.LockState __cl_gen_value;translator.Get(L, 2, out __cl_gen_value);
				__cl_gen_to_be_invoked.State = __cl_gen_value;
            
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_mFunc(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.ui.UILockCDSlot __cl_gen_to_be_invoked = (xc.ui.UILockCDSlot)translator.FastGetCSObj(L, 1);
                __cl_gen_to_be_invoked.mFunc = translator.GetDelegate<xc.ui.UILockCDSlot.OnClickFunc>(L, 2);
            
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_mParam(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.ui.UILockCDSlot __cl_gen_to_be_invoked = (xc.ui.UILockCDSlot)translator.FastGetCSObj(L, 1);
                __cl_gen_to_be_invoked.mParam = translator.GetObject(L, 2, typeof(object));
            
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 0;
        }
        
		
		
		
		
    }
}
