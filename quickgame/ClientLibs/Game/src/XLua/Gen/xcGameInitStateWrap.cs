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
    public class xcGameInitStateWrap
    {
        public static void __Register(RealStatePtr L)
        {
			ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			XUtils.BeginObjectRegister(typeof(xc.GameInitState), L, translator, 0, 2, 0, 0);
			
			XUtils.RegisterFunc(L, XUtils.METHOD_IDX, "Enter", _m_Enter);
			XUtils.RegisterFunc(L, XUtils.METHOD_IDX, "Exit", _m_Exit);
			
			
			
			
			XUtils.EndObjectRegister(typeof(xc.GameInitState), L, translator, null, null,
			    null, null, null);

		    XUtils.BeginClassRegister(typeof(xc.GameInitState), L, __CreateInstance, 1, 2, 2);
			
			
            
            XUtils.RegisterObject(L, translator, XUtils.CLS_IDX, "UnderlyingSystemType", typeof(xc.GameInitState));
			XUtils.RegisterFunc(L, XUtils.CLS_GETTER_IDX, "PreviewPlayerPos", _g_get_PreviewPlayerPos);
            XUtils.RegisterFunc(L, XUtils.CLS_GETTER_IDX, "PieviewPlayerRot", _g_get_PieviewPlayerRot);
            
			XUtils.RegisterFunc(L, XUtils.CLS_SETTER_IDX, "PreviewPlayerPos", _s_set_PreviewPlayerPos);
            XUtils.RegisterFunc(L, XUtils.CLS_SETTER_IDX, "PieviewPlayerRot", _s_set_PieviewPlayerRot);
            
			XUtils.EndClassRegister(typeof(xc.GameInitState), L, translator);
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int __CreateInstance(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			try {
				if(LuaAPI.lua_gettop(L) == 2 && translator.Assignable<xc.Machine>(L, 2))
				{
					xc.Machine machine = (xc.Machine)translator.GetObject(L, 2, typeof(xc.Machine));
					
					xc.GameInitState __cl_gen_ret = new xc.GameInitState(machine);
					translator.Push(L, __cl_gen_ret);
					return 1;
				}
				if(LuaAPI.lua_gettop(L) == 3 && translator.Assignable<xc.Machine>(L, 2) && translator.Assignable<xc.Machine.State>(L, 3))
				{
					xc.Machine machine = (xc.Machine)translator.GetObject(L, 2, typeof(xc.Machine));
					xc.Machine.State owner = (xc.Machine.State)translator.GetObject(L, 3, typeof(xc.Machine.State));
					
					xc.GameInitState __cl_gen_ret = new xc.GameInitState(machine, owner);
					translator.Push(L, __cl_gen_ret);
					return 1;
				}
				
			}
			catch(System.Exception __gen_e) {
				return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
			}
            return LuaAPI.luaL_error(L, "invalid arguments to xc.GameInitState constructor!");
            
        }
        
		
        
		
        
        
        
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_Enter(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            xc.GameInitState __cl_gen_to_be_invoked = (xc.GameInitState)translator.FastGetCSObj(L, 1);
            
            
            try {
                
                {
                    object[] param = translator.GetParams<object>(L, 2);
                    
                    __cl_gen_to_be_invoked.Enter( param );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_Exit(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            xc.GameInitState __cl_gen_to_be_invoked = (xc.GameInitState)translator.FastGetCSObj(L, 1);
            
            
            try {
                
                {
                    
                    __cl_gen_to_be_invoked.Exit(  );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        
        
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_PreviewPlayerPos(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			    translator.PushUnityEngineVector3(L, xc.GameInitState.PreviewPlayerPos);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_PieviewPlayerRot(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			    translator.PushUnityEngineQuaternion(L, xc.GameInitState.PieviewPlayerRot);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_PreviewPlayerPos(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			UnityEngine.Vector3 __cl_gen_value;translator.Get(L, 1, out __cl_gen_value);
				xc.GameInitState.PreviewPlayerPos = __cl_gen_value;
            
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_PieviewPlayerRot(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			UnityEngine.Quaternion __cl_gen_value;translator.Get(L, 1, out __cl_gen_value);
				xc.GameInitState.PieviewPlayerRot = __cl_gen_value;
            
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 0;
        }
        
		
		
		
		
    }
}
