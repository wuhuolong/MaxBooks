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
    public class xcMoveCtrlMoveStepWrap
    {
        public static void __Register(RealStatePtr L)
        {
			ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			XUtils.BeginObjectRegister(typeof(xc.MoveCtrl.MoveStep), L, translator, 0, 0, 4, 4);
			
			
			
			XUtils.RegisterFunc(L, XUtils.GETTER_IDX, "type", _g_get_type);
            XUtils.RegisterFunc(L, XUtils.GETTER_IDX, "pos", _g_get_pos);
            XUtils.RegisterFunc(L, XUtils.GETTER_IDX, "dir", _g_get_dir);
            XUtils.RegisterFunc(L, XUtils.GETTER_IDX, "speed", _g_get_speed);
            
			XUtils.RegisterFunc(L, XUtils.SETTER_IDX, "type", _s_set_type);
            XUtils.RegisterFunc(L, XUtils.SETTER_IDX, "pos", _s_set_pos);
            XUtils.RegisterFunc(L, XUtils.SETTER_IDX, "dir", _s_set_dir);
            XUtils.RegisterFunc(L, XUtils.SETTER_IDX, "speed", _s_set_speed);
            
			XUtils.EndObjectRegister(typeof(xc.MoveCtrl.MoveStep), L, translator, null, null,
			    null, null, null);

		    XUtils.BeginClassRegister(typeof(xc.MoveCtrl.MoveStep), L, __CreateInstance, 1, 0, 0);
			
			
            
            XUtils.RegisterObject(L, translator, XUtils.CLS_IDX, "UnderlyingSystemType", typeof(xc.MoveCtrl.MoveStep));
			
			
			XUtils.EndClassRegister(typeof(xc.MoveCtrl.MoveStep), L, translator);
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int __CreateInstance(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			try {
				if(LuaAPI.lua_gettop(L) == 1)
				{
					
					xc.MoveCtrl.MoveStep __cl_gen_ret = new xc.MoveCtrl.MoveStep();
					translator.Push(L, __cl_gen_ret);
					return 1;
				}
				
			}
			catch(System.Exception __gen_e) {
				return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
			}
            return LuaAPI.luaL_error(L, "invalid arguments to xc.MoveCtrl.MoveStep constructor!");
            
        }
        
		
        
		
        
        
        
        
        
        
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_type(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.MoveCtrl.MoveStep __cl_gen_to_be_invoked = (xc.MoveCtrl.MoveStep)translator.FastGetCSObj(L, 1);
                translator.PushxcMoveCtrlEActorStepType(L, __cl_gen_to_be_invoked.type);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_pos(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.MoveCtrl.MoveStep __cl_gen_to_be_invoked = (xc.MoveCtrl.MoveStep)translator.FastGetCSObj(L, 1);
                translator.PushUnityEngineVector3(L, __cl_gen_to_be_invoked.pos);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_dir(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.MoveCtrl.MoveStep __cl_gen_to_be_invoked = (xc.MoveCtrl.MoveStep)translator.FastGetCSObj(L, 1);
                translator.PushUnityEngineVector3(L, __cl_gen_to_be_invoked.dir);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_speed(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.MoveCtrl.MoveStep __cl_gen_to_be_invoked = (xc.MoveCtrl.MoveStep)translator.FastGetCSObj(L, 1);
                LuaAPI.lua_pushnumber(L, __cl_gen_to_be_invoked.speed);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_type(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.MoveCtrl.MoveStep __cl_gen_to_be_invoked = (xc.MoveCtrl.MoveStep)translator.FastGetCSObj(L, 1);
                xc.MoveCtrl.EActorStepType __cl_gen_value;translator.Get(L, 2, out __cl_gen_value);
				__cl_gen_to_be_invoked.type = __cl_gen_value;
            
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_pos(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.MoveCtrl.MoveStep __cl_gen_to_be_invoked = (xc.MoveCtrl.MoveStep)translator.FastGetCSObj(L, 1);
                UnityEngine.Vector3 __cl_gen_value;translator.Get(L, 2, out __cl_gen_value);
				__cl_gen_to_be_invoked.pos = __cl_gen_value;
            
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_dir(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.MoveCtrl.MoveStep __cl_gen_to_be_invoked = (xc.MoveCtrl.MoveStep)translator.FastGetCSObj(L, 1);
                UnityEngine.Vector3 __cl_gen_value;translator.Get(L, 2, out __cl_gen_value);
				__cl_gen_to_be_invoked.dir = __cl_gen_value;
            
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_speed(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.MoveCtrl.MoveStep __cl_gen_to_be_invoked = (xc.MoveCtrl.MoveStep)translator.FastGetCSObj(L, 1);
                __cl_gen_to_be_invoked.speed = (float)LuaAPI.lua_tonumber(L, 2);
            
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 0;
        }
        
		
		
		
		
    }
}
