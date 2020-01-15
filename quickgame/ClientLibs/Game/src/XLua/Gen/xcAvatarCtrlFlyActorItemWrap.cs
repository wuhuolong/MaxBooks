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
    public class xcAvatarCtrlFlyActorItemWrap
    {
        public static void __Register(RealStatePtr L)
        {
			ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			XUtils.BeginObjectRegister(typeof(xc.AvatarCtrl.FlyActorItem), L, translator, 0, 0, 7, 7);
			
			
			
			XUtils.RegisterFunc(L, XUtils.GETTER_IDX, "m_circleFlyingTotalInterval", _g_get_m_circleFlyingTotalInterval);
            XUtils.RegisterFunc(L, XUtils.GETTER_IDX, "m_is_circleFlying", _g_get_m_is_circleFlying);
            XUtils.RegisterFunc(L, XUtils.GETTER_IDX, "m_is_followMoving", _g_get_m_is_followMoving);
            XUtils.RegisterFunc(L, XUtils.GETTER_IDX, "m_circleFlyingInterval", _g_get_m_circleFlyingInterval);
            XUtils.RegisterFunc(L, XUtils.GETTER_IDX, "m_next_circleFlyingInterval", _g_get_m_next_circleFlyingInterval);
            XUtils.RegisterFunc(L, XUtils.GETTER_IDX, "m_circleFly_startPos", _g_get_m_circleFly_startPos);
            XUtils.RegisterFunc(L, XUtils.GETTER_IDX, "resetPos_callback", _g_get_resetPos_callback);
            
			XUtils.RegisterFunc(L, XUtils.SETTER_IDX, "m_circleFlyingTotalInterval", _s_set_m_circleFlyingTotalInterval);
            XUtils.RegisterFunc(L, XUtils.SETTER_IDX, "m_is_circleFlying", _s_set_m_is_circleFlying);
            XUtils.RegisterFunc(L, XUtils.SETTER_IDX, "m_is_followMoving", _s_set_m_is_followMoving);
            XUtils.RegisterFunc(L, XUtils.SETTER_IDX, "m_circleFlyingInterval", _s_set_m_circleFlyingInterval);
            XUtils.RegisterFunc(L, XUtils.SETTER_IDX, "m_next_circleFlyingInterval", _s_set_m_next_circleFlyingInterval);
            XUtils.RegisterFunc(L, XUtils.SETTER_IDX, "m_circleFly_startPos", _s_set_m_circleFly_startPos);
            XUtils.RegisterFunc(L, XUtils.SETTER_IDX, "resetPos_callback", _s_set_resetPos_callback);
            
			XUtils.EndObjectRegister(typeof(xc.AvatarCtrl.FlyActorItem), L, translator, null, null,
			    null, null, null);

		    XUtils.BeginClassRegister(typeof(xc.AvatarCtrl.FlyActorItem), L, __CreateInstance, 1, 0, 0);
			
			
            
            XUtils.RegisterObject(L, translator, XUtils.CLS_IDX, "UnderlyingSystemType", typeof(xc.AvatarCtrl.FlyActorItem));
			
			
			XUtils.EndClassRegister(typeof(xc.AvatarCtrl.FlyActorItem), L, translator);
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int __CreateInstance(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			try {
				if(LuaAPI.lua_gettop(L) == 2 && translator.Assignable<System.Action>(L, 2))
				{
					System.Action var_resetPos_callback = translator.GetDelegate<System.Action>(L, 2);
					
					xc.AvatarCtrl.FlyActorItem __cl_gen_ret = new xc.AvatarCtrl.FlyActorItem(var_resetPos_callback);
					translator.Push(L, __cl_gen_ret);
					return 1;
				}
				
			}
			catch(System.Exception __gen_e) {
				return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
			}
            return LuaAPI.luaL_error(L, "invalid arguments to xc.AvatarCtrl.FlyActorItem constructor!");
            
        }
        
		
        
		
        
        
        
        
        
        
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_m_circleFlyingTotalInterval(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.AvatarCtrl.FlyActorItem __cl_gen_to_be_invoked = (xc.AvatarCtrl.FlyActorItem)translator.FastGetCSObj(L, 1);
                LuaAPI.lua_pushnumber(L, __cl_gen_to_be_invoked.m_circleFlyingTotalInterval);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_m_is_circleFlying(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.AvatarCtrl.FlyActorItem __cl_gen_to_be_invoked = (xc.AvatarCtrl.FlyActorItem)translator.FastGetCSObj(L, 1);
                LuaAPI.lua_pushboolean(L, __cl_gen_to_be_invoked.m_is_circleFlying);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_m_is_followMoving(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.AvatarCtrl.FlyActorItem __cl_gen_to_be_invoked = (xc.AvatarCtrl.FlyActorItem)translator.FastGetCSObj(L, 1);
                LuaAPI.lua_pushboolean(L, __cl_gen_to_be_invoked.m_is_followMoving);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_m_circleFlyingInterval(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.AvatarCtrl.FlyActorItem __cl_gen_to_be_invoked = (xc.AvatarCtrl.FlyActorItem)translator.FastGetCSObj(L, 1);
                LuaAPI.lua_pushnumber(L, __cl_gen_to_be_invoked.m_circleFlyingInterval);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_m_next_circleFlyingInterval(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.AvatarCtrl.FlyActorItem __cl_gen_to_be_invoked = (xc.AvatarCtrl.FlyActorItem)translator.FastGetCSObj(L, 1);
                LuaAPI.lua_pushnumber(L, __cl_gen_to_be_invoked.m_next_circleFlyingInterval);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_m_circleFly_startPos(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.AvatarCtrl.FlyActorItem __cl_gen_to_be_invoked = (xc.AvatarCtrl.FlyActorItem)translator.FastGetCSObj(L, 1);
                translator.PushUnityEngineVector3(L, __cl_gen_to_be_invoked.m_circleFly_startPos);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_resetPos_callback(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.AvatarCtrl.FlyActorItem __cl_gen_to_be_invoked = (xc.AvatarCtrl.FlyActorItem)translator.FastGetCSObj(L, 1);
                translator.Push(L, __cl_gen_to_be_invoked.resetPos_callback);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_m_circleFlyingTotalInterval(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.AvatarCtrl.FlyActorItem __cl_gen_to_be_invoked = (xc.AvatarCtrl.FlyActorItem)translator.FastGetCSObj(L, 1);
                __cl_gen_to_be_invoked.m_circleFlyingTotalInterval = (float)LuaAPI.lua_tonumber(L, 2);
            
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_m_is_circleFlying(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.AvatarCtrl.FlyActorItem __cl_gen_to_be_invoked = (xc.AvatarCtrl.FlyActorItem)translator.FastGetCSObj(L, 1);
                __cl_gen_to_be_invoked.m_is_circleFlying = LuaAPI.lua_toboolean(L, 2);
            
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_m_is_followMoving(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.AvatarCtrl.FlyActorItem __cl_gen_to_be_invoked = (xc.AvatarCtrl.FlyActorItem)translator.FastGetCSObj(L, 1);
                __cl_gen_to_be_invoked.m_is_followMoving = LuaAPI.lua_toboolean(L, 2);
            
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_m_circleFlyingInterval(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.AvatarCtrl.FlyActorItem __cl_gen_to_be_invoked = (xc.AvatarCtrl.FlyActorItem)translator.FastGetCSObj(L, 1);
                __cl_gen_to_be_invoked.m_circleFlyingInterval = (float)LuaAPI.lua_tonumber(L, 2);
            
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_m_next_circleFlyingInterval(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.AvatarCtrl.FlyActorItem __cl_gen_to_be_invoked = (xc.AvatarCtrl.FlyActorItem)translator.FastGetCSObj(L, 1);
                __cl_gen_to_be_invoked.m_next_circleFlyingInterval = (float)LuaAPI.lua_tonumber(L, 2);
            
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_m_circleFly_startPos(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.AvatarCtrl.FlyActorItem __cl_gen_to_be_invoked = (xc.AvatarCtrl.FlyActorItem)translator.FastGetCSObj(L, 1);
                UnityEngine.Vector3 __cl_gen_value;translator.Get(L, 2, out __cl_gen_value);
				__cl_gen_to_be_invoked.m_circleFly_startPos = __cl_gen_value;
            
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_resetPos_callback(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.AvatarCtrl.FlyActorItem __cl_gen_to_be_invoked = (xc.AvatarCtrl.FlyActorItem)translator.FastGetCSObj(L, 1);
                __cl_gen_to_be_invoked.resetPos_callback = translator.GetDelegate<System.Action>(L, 2);
            
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 0;
        }
        
		
		
		
		
    }
}
