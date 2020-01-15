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
    public class AnimationControllerCallBackInfoWrap
    {
        public static void __Register(RealStatePtr L)
        {
			ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			XUtils.BeginObjectRegister(typeof(AnimationController.CallBackInfo), L, translator, 0, 0, 3, 3);
			
			
			
			XUtils.RegisterFunc(L, XUtils.GETTER_IDX, "mParam", _g_get_mParam);
            XUtils.RegisterFunc(L, XUtils.GETTER_IDX, "mCallBack", _g_get_mCallBack);
            XUtils.RegisterFunc(L, XUtils.GETTER_IDX, "mTime", _g_get_mTime);
            
			XUtils.RegisterFunc(L, XUtils.SETTER_IDX, "mParam", _s_set_mParam);
            XUtils.RegisterFunc(L, XUtils.SETTER_IDX, "mCallBack", _s_set_mCallBack);
            XUtils.RegisterFunc(L, XUtils.SETTER_IDX, "mTime", _s_set_mTime);
            
			XUtils.EndObjectRegister(typeof(AnimationController.CallBackInfo), L, translator, null, null,
			    null, null, null);

		    XUtils.BeginClassRegister(typeof(AnimationController.CallBackInfo), L, __CreateInstance, 1, 0, 0);
			
			
            
            XUtils.RegisterObject(L, translator, XUtils.CLS_IDX, "UnderlyingSystemType", typeof(AnimationController.CallBackInfo));
			
			
			XUtils.EndClassRegister(typeof(AnimationController.CallBackInfo), L, translator);
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int __CreateInstance(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			try {
				if(LuaAPI.lua_gettop(L) == 1)
				{
					
					AnimationController.CallBackInfo __cl_gen_ret = new AnimationController.CallBackInfo();
					translator.Push(L, __cl_gen_ret);
					return 1;
				}
				
			}
			catch(System.Exception __gen_e) {
				return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
			}
            return LuaAPI.luaL_error(L, "invalid arguments to AnimationController.CallBackInfo constructor!");
            
        }
        
		
        
		
        
        
        
        
        
        
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_mParam(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                AnimationController.CallBackInfo __cl_gen_to_be_invoked = (AnimationController.CallBackInfo)translator.FastGetCSObj(L, 1);
                translator.PushAny(L, __cl_gen_to_be_invoked.mParam);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_mCallBack(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                AnimationController.CallBackInfo __cl_gen_to_be_invoked = (AnimationController.CallBackInfo)translator.FastGetCSObj(L, 1);
                translator.Push(L, __cl_gen_to_be_invoked.mCallBack);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_mTime(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                AnimationController.CallBackInfo __cl_gen_to_be_invoked = (AnimationController.CallBackInfo)translator.FastGetCSObj(L, 1);
                LuaAPI.lua_pushnumber(L, __cl_gen_to_be_invoked.mTime);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_mParam(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                AnimationController.CallBackInfo __cl_gen_to_be_invoked = (AnimationController.CallBackInfo)translator.FastGetCSObj(L, 1);
                __cl_gen_to_be_invoked.mParam = translator.GetObject(L, 2, typeof(object));
            
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_mCallBack(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                AnimationController.CallBackInfo __cl_gen_to_be_invoked = (AnimationController.CallBackInfo)translator.FastGetCSObj(L, 1);
                __cl_gen_to_be_invoked.mCallBack = translator.GetDelegate<AnimationController.AnimationCtrlCallBack>(L, 2);
            
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_mTime(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                AnimationController.CallBackInfo __cl_gen_to_be_invoked = (AnimationController.CallBackInfo)translator.FastGetCSObj(L, 1);
                __cl_gen_to_be_invoked.mTime = (float)LuaAPI.lua_tonumber(L, 2);
            
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 0;
        }
        
		
		
		
		
    }
}
