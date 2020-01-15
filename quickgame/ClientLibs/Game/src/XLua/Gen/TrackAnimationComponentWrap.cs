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
    public class TrackAnimationComponentWrap
    {
        public static void __Register(RealStatePtr L)
        {
			ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			XUtils.BeginObjectRegister(typeof(TrackAnimationComponent), L, translator, 0, 0, 7, 7);
			
			
			
			XUtils.RegisterFunc(L, XUtils.GETTER_IDX, "TargetTran", _g_get_TargetTran);
            XUtils.RegisterFunc(L, XUtils.GETTER_IDX, "TargetOffset", _g_get_TargetOffset);
            XUtils.RegisterFunc(L, XUtils.GETTER_IDX, "OriginalSpeed", _g_get_OriginalSpeed);
            XUtils.RegisterFunc(L, XUtils.GETTER_IDX, "Acceleration", _g_get_Acceleration);
            XUtils.RegisterFunc(L, XUtils.GETTER_IDX, "OriginalOffsetSpeed", _g_get_OriginalOffsetSpeed);
            XUtils.RegisterFunc(L, XUtils.GETTER_IDX, "OffsetSpeedDuration", _g_get_OffsetSpeedDuration);
            XUtils.RegisterFunc(L, XUtils.GETTER_IDX, "FinishCallback", _g_get_FinishCallback);
            
			XUtils.RegisterFunc(L, XUtils.SETTER_IDX, "TargetTran", _s_set_TargetTran);
            XUtils.RegisterFunc(L, XUtils.SETTER_IDX, "TargetOffset", _s_set_TargetOffset);
            XUtils.RegisterFunc(L, XUtils.SETTER_IDX, "OriginalSpeed", _s_set_OriginalSpeed);
            XUtils.RegisterFunc(L, XUtils.SETTER_IDX, "Acceleration", _s_set_Acceleration);
            XUtils.RegisterFunc(L, XUtils.SETTER_IDX, "OriginalOffsetSpeed", _s_set_OriginalOffsetSpeed);
            XUtils.RegisterFunc(L, XUtils.SETTER_IDX, "OffsetSpeedDuration", _s_set_OffsetSpeedDuration);
            XUtils.RegisterFunc(L, XUtils.SETTER_IDX, "FinishCallback", _s_set_FinishCallback);
            
			XUtils.EndObjectRegister(typeof(TrackAnimationComponent), L, translator, null, null,
			    null, null, null);

		    XUtils.BeginClassRegister(typeof(TrackAnimationComponent), L, __CreateInstance, 1, 0, 0);
			
			
            
            XUtils.RegisterObject(L, translator, XUtils.CLS_IDX, "UnderlyingSystemType", typeof(TrackAnimationComponent));
			
			
			XUtils.EndClassRegister(typeof(TrackAnimationComponent), L, translator);
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int __CreateInstance(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			try {
				if(LuaAPI.lua_gettop(L) == 1)
				{
					
					TrackAnimationComponent __cl_gen_ret = new TrackAnimationComponent();
					translator.Push(L, __cl_gen_ret);
					return 1;
				}
				
			}
			catch(System.Exception __gen_e) {
				return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
			}
            return LuaAPI.luaL_error(L, "invalid arguments to TrackAnimationComponent constructor!");
            
        }
        
		
        
		
        
        
        
        
        
        
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_TargetTran(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                TrackAnimationComponent __cl_gen_to_be_invoked = (TrackAnimationComponent)translator.FastGetCSObj(L, 1);
                translator.Push(L, __cl_gen_to_be_invoked.TargetTran);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_TargetOffset(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                TrackAnimationComponent __cl_gen_to_be_invoked = (TrackAnimationComponent)translator.FastGetCSObj(L, 1);
                translator.PushUnityEngineVector3(L, __cl_gen_to_be_invoked.TargetOffset);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_OriginalSpeed(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                TrackAnimationComponent __cl_gen_to_be_invoked = (TrackAnimationComponent)translator.FastGetCSObj(L, 1);
                LuaAPI.lua_pushnumber(L, __cl_gen_to_be_invoked.OriginalSpeed);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_Acceleration(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                TrackAnimationComponent __cl_gen_to_be_invoked = (TrackAnimationComponent)translator.FastGetCSObj(L, 1);
                LuaAPI.lua_pushnumber(L, __cl_gen_to_be_invoked.Acceleration);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_OriginalOffsetSpeed(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                TrackAnimationComponent __cl_gen_to_be_invoked = (TrackAnimationComponent)translator.FastGetCSObj(L, 1);
                translator.PushUnityEngineVector3(L, __cl_gen_to_be_invoked.OriginalOffsetSpeed);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_OffsetSpeedDuration(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                TrackAnimationComponent __cl_gen_to_be_invoked = (TrackAnimationComponent)translator.FastGetCSObj(L, 1);
                LuaAPI.lua_pushnumber(L, __cl_gen_to_be_invoked.OffsetSpeedDuration);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_FinishCallback(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                TrackAnimationComponent __cl_gen_to_be_invoked = (TrackAnimationComponent)translator.FastGetCSObj(L, 1);
                translator.Push(L, __cl_gen_to_be_invoked.FinishCallback);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_TargetTran(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                TrackAnimationComponent __cl_gen_to_be_invoked = (TrackAnimationComponent)translator.FastGetCSObj(L, 1);
                __cl_gen_to_be_invoked.TargetTran = (UnityEngine.Transform)translator.GetObject(L, 2, typeof(UnityEngine.Transform));
            
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_TargetOffset(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                TrackAnimationComponent __cl_gen_to_be_invoked = (TrackAnimationComponent)translator.FastGetCSObj(L, 1);
                UnityEngine.Vector3 __cl_gen_value;translator.Get(L, 2, out __cl_gen_value);
				__cl_gen_to_be_invoked.TargetOffset = __cl_gen_value;
            
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_OriginalSpeed(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                TrackAnimationComponent __cl_gen_to_be_invoked = (TrackAnimationComponent)translator.FastGetCSObj(L, 1);
                __cl_gen_to_be_invoked.OriginalSpeed = (float)LuaAPI.lua_tonumber(L, 2);
            
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_Acceleration(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                TrackAnimationComponent __cl_gen_to_be_invoked = (TrackAnimationComponent)translator.FastGetCSObj(L, 1);
                __cl_gen_to_be_invoked.Acceleration = (float)LuaAPI.lua_tonumber(L, 2);
            
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_OriginalOffsetSpeed(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                TrackAnimationComponent __cl_gen_to_be_invoked = (TrackAnimationComponent)translator.FastGetCSObj(L, 1);
                UnityEngine.Vector3 __cl_gen_value;translator.Get(L, 2, out __cl_gen_value);
				__cl_gen_to_be_invoked.OriginalOffsetSpeed = __cl_gen_value;
            
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_OffsetSpeedDuration(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                TrackAnimationComponent __cl_gen_to_be_invoked = (TrackAnimationComponent)translator.FastGetCSObj(L, 1);
                __cl_gen_to_be_invoked.OffsetSpeedDuration = (float)LuaAPI.lua_tonumber(L, 2);
            
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_FinishCallback(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                TrackAnimationComponent __cl_gen_to_be_invoked = (TrackAnimationComponent)translator.FastGetCSObj(L, 1);
                __cl_gen_to_be_invoked.FinishCallback = translator.GetDelegate<System.Action>(L, 2);
            
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 0;
        }
        
		
		
		
		
    }
}
