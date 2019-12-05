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
    public class TargetModelInfoWrap
    {
        public static void __Register(RealStatePtr L)
        {
			ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			XUtils.BeginObjectRegister(typeof(TargetModelInfo), L, translator, 0, 2, 5, 5);
			
			XUtils.RegisterFunc(L, XUtils.METHOD_IDX, "StartLoadModel", _m_StartLoadModel);
			XUtils.RegisterFunc(L, XUtils.METHOD_IDX, "SetModelInfo", _m_SetModelInfo);
			
			
			XUtils.RegisterFunc(L, XUtils.GETTER_IDX, "ResPath", _g_get_ResPath);
            XUtils.RegisterFunc(L, XUtils.GETTER_IDX, "ModelAction", _g_get_ModelAction);
            XUtils.RegisterFunc(L, XUtils.GETTER_IDX, "LocalPos", _g_get_LocalPos);
            XUtils.RegisterFunc(L, XUtils.GETTER_IDX, "LocalScale", _g_get_LocalScale);
            XUtils.RegisterFunc(L, XUtils.GETTER_IDX, "LocalEuler", _g_get_LocalEuler);
            
			XUtils.RegisterFunc(L, XUtils.SETTER_IDX, "ResPath", _s_set_ResPath);
            XUtils.RegisterFunc(L, XUtils.SETTER_IDX, "ModelAction", _s_set_ModelAction);
            XUtils.RegisterFunc(L, XUtils.SETTER_IDX, "LocalPos", _s_set_LocalPos);
            XUtils.RegisterFunc(L, XUtils.SETTER_IDX, "LocalScale", _s_set_LocalScale);
            XUtils.RegisterFunc(L, XUtils.SETTER_IDX, "LocalEuler", _s_set_LocalEuler);
            
			XUtils.EndObjectRegister(typeof(TargetModelInfo), L, translator, null, null,
			    null, null, null);

		    XUtils.BeginClassRegister(typeof(TargetModelInfo), L, __CreateInstance, 1, 0, 0);
			
			
            
            XUtils.RegisterObject(L, translator, XUtils.CLS_IDX, "UnderlyingSystemType", typeof(TargetModelInfo));
			
			
			XUtils.EndClassRegister(typeof(TargetModelInfo), L, translator);
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int __CreateInstance(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			try {
				if(LuaAPI.lua_gettop(L) == 1)
				{
					
					TargetModelInfo __cl_gen_ret = new TargetModelInfo();
					translator.Push(L, __cl_gen_ret);
					return 1;
				}
				
			}
			catch(System.Exception __gen_e) {
				return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
			}
            return LuaAPI.luaL_error(L, "invalid arguments to TargetModelInfo constructor!");
            
        }
        
		
        
		
        
        
        
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_StartLoadModel(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            TargetModelInfo __cl_gen_to_be_invoked = (TargetModelInfo)translator.FastGetCSObj(L, 1);
            
            
            try {
                
                {
                    
                    __cl_gen_to_be_invoked.StartLoadModel(  );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_SetModelInfo(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            TargetModelInfo __cl_gen_to_be_invoked = (TargetModelInfo)translator.FastGetCSObj(L, 1);
            
            
			int __gen_param_count = LuaAPI.lua_gettop(L);
            
            try {
                if(__gen_param_count == 6&& (LuaAPI.lua_isnil(L, 2) || LuaAPI.lua_type(L, 2) == LuaTypes.LUA_TSTRING)&& translator.Assignable<UnityEngine.Vector3>(L, 3)&& translator.Assignable<UnityEngine.Vector3>(L, 4)&& translator.Assignable<UnityEngine.Vector3>(L, 5)&& (LuaAPI.lua_isnil(L, 6) || LuaAPI.lua_type(L, 6) == LuaTypes.LUA_TSTRING)) 
                {
                    string res_path = LuaAPI.lua_tostring(L, 2);
                    UnityEngine.Vector3 local_pos;translator.Get(L, 3, out local_pos);
                    UnityEngine.Vector3 local_scale;translator.Get(L, 4, out local_scale);
                    UnityEngine.Vector3 local_euler;translator.Get(L, 5, out local_euler);
                    string modelAction = LuaAPI.lua_tostring(L, 6);
                    
                    __cl_gen_to_be_invoked.SetModelInfo( res_path, local_pos, local_scale, local_euler, modelAction );
                    
                    
                    
                    return 0;
                }
                if(__gen_param_count == 5&& (LuaAPI.lua_isnil(L, 2) || LuaAPI.lua_type(L, 2) == LuaTypes.LUA_TSTRING)&& translator.Assignable<UnityEngine.Vector3>(L, 3)&& translator.Assignable<UnityEngine.Vector3>(L, 4)&& translator.Assignable<UnityEngine.Vector3>(L, 5)) 
                {
                    string res_path = LuaAPI.lua_tostring(L, 2);
                    UnityEngine.Vector3 local_pos;translator.Get(L, 3, out local_pos);
                    UnityEngine.Vector3 local_scale;translator.Get(L, 4, out local_scale);
                    UnityEngine.Vector3 local_euler;translator.Get(L, 5, out local_euler);
                    
                    __cl_gen_to_be_invoked.SetModelInfo( res_path, local_pos, local_scale, local_euler );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
            return LuaAPI.luaL_error(L, "invalid arguments to TargetModelInfo.SetModelInfo!");
            
        }
        
        
        
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_ResPath(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                TargetModelInfo __cl_gen_to_be_invoked = (TargetModelInfo)translator.FastGetCSObj(L, 1);
                LuaAPI.lua_pushstring(L, __cl_gen_to_be_invoked.ResPath);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_ModelAction(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                TargetModelInfo __cl_gen_to_be_invoked = (TargetModelInfo)translator.FastGetCSObj(L, 1);
                LuaAPI.lua_pushstring(L, __cl_gen_to_be_invoked.ModelAction);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_LocalPos(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                TargetModelInfo __cl_gen_to_be_invoked = (TargetModelInfo)translator.FastGetCSObj(L, 1);
                translator.PushUnityEngineVector3(L, __cl_gen_to_be_invoked.LocalPos);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_LocalScale(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                TargetModelInfo __cl_gen_to_be_invoked = (TargetModelInfo)translator.FastGetCSObj(L, 1);
                translator.PushUnityEngineVector3(L, __cl_gen_to_be_invoked.LocalScale);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_LocalEuler(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                TargetModelInfo __cl_gen_to_be_invoked = (TargetModelInfo)translator.FastGetCSObj(L, 1);
                translator.PushUnityEngineVector3(L, __cl_gen_to_be_invoked.LocalEuler);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_ResPath(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                TargetModelInfo __cl_gen_to_be_invoked = (TargetModelInfo)translator.FastGetCSObj(L, 1);
                __cl_gen_to_be_invoked.ResPath = LuaAPI.lua_tostring(L, 2);
            
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_ModelAction(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                TargetModelInfo __cl_gen_to_be_invoked = (TargetModelInfo)translator.FastGetCSObj(L, 1);
                __cl_gen_to_be_invoked.ModelAction = LuaAPI.lua_tostring(L, 2);
            
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_LocalPos(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                TargetModelInfo __cl_gen_to_be_invoked = (TargetModelInfo)translator.FastGetCSObj(L, 1);
                UnityEngine.Vector3 __cl_gen_value;translator.Get(L, 2, out __cl_gen_value);
				__cl_gen_to_be_invoked.LocalPos = __cl_gen_value;
            
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_LocalScale(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                TargetModelInfo __cl_gen_to_be_invoked = (TargetModelInfo)translator.FastGetCSObj(L, 1);
                UnityEngine.Vector3 __cl_gen_value;translator.Get(L, 2, out __cl_gen_value);
				__cl_gen_to_be_invoked.LocalScale = __cl_gen_value;
            
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_LocalEuler(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                TargetModelInfo __cl_gen_to_be_invoked = (TargetModelInfo)translator.FastGetCSObj(L, 1);
                UnityEngine.Vector3 __cl_gen_value;translator.Get(L, 2, out __cl_gen_value);
				__cl_gen_to_be_invoked.LocalEuler = __cl_gen_value;
            
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 0;
        }
        
		
		
		
		
    }
}
