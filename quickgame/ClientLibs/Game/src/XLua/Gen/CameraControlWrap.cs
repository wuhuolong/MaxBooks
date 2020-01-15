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
    public class CameraControlWrap
    {
        public static void __Register(RealStatePtr L)
        {
			ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			XUtils.BeginObjectRegister(typeof(CameraControl), L, translator, 0, 6, 11, 11);
			
			XUtils.RegisterFunc(L, XUtils.METHOD_IDX, "CloneCamera", _m_CloneCamera);
			XUtils.RegisterFunc(L, XUtils.METHOD_IDX, "SimpleShake", _m_SimpleShake);
			XUtils.RegisterFunc(L, XUtils.METHOD_IDX, "CurveShake", _m_CurveShake);
			XUtils.RegisterFunc(L, XUtils.METHOD_IDX, "SelectChildCamera", _m_SelectChildCamera);
			XUtils.RegisterFunc(L, XUtils.METHOD_IDX, "HideLayer", _m_HideLayer);
			XUtils.RegisterFunc(L, XUtils.METHOD_IDX, "ShowLayer", _m_ShowLayer);
			
			
			XUtils.RegisterFunc(L, XUtils.GETTER_IDX, "ForceForwardObject", _g_get_ForceForwardObject);
            XUtils.RegisterFunc(L, XUtils.GETTER_IDX, "RealCamera", _g_get_RealCamera);
            XUtils.RegisterFunc(L, XUtils.GETTER_IDX, "Target", _g_get_Target);
            XUtils.RegisterFunc(L, XUtils.GETTER_IDX, "SelectedChildCamera", _g_get_SelectedChildCamera);
            XUtils.RegisterFunc(L, XUtils.GETTER_IDX, "CullDistances", _g_get_CullDistances);
            XUtils.RegisterFunc(L, XUtils.GETTER_IDX, "FollowInterpolationDistance", _g_get_FollowInterpolationDistance);
            XUtils.RegisterFunc(L, XUtils.GETTER_IDX, "NeedFollowInterpolation", _g_get_NeedFollowInterpolation);
            XUtils.RegisterFunc(L, XUtils.GETTER_IDX, "FollowDistance", _g_get_FollowDistance);
            XUtils.RegisterFunc(L, XUtils.GETTER_IDX, "FollowOffset", _g_get_FollowOffset);
            XUtils.RegisterFunc(L, XUtils.GETTER_IDX, "Mode", _g_get_Mode);
            XUtils.RegisterFunc(L, XUtils.GETTER_IDX, "CameraSelects", _g_get_CameraSelects);
            
			XUtils.RegisterFunc(L, XUtils.SETTER_IDX, "ForceForwardObject", _s_set_ForceForwardObject);
            XUtils.RegisterFunc(L, XUtils.SETTER_IDX, "Target", _s_set_Target);
            XUtils.RegisterFunc(L, XUtils.SETTER_IDX, "Zoom", _s_set_Zoom);
            XUtils.RegisterFunc(L, XUtils.SETTER_IDX, "FOV", _s_set_FOV);
            XUtils.RegisterFunc(L, XUtils.SETTER_IDX, "CullDistances", _s_set_CullDistances);
            XUtils.RegisterFunc(L, XUtils.SETTER_IDX, "FollowInterpolationDistance", _s_set_FollowInterpolationDistance);
            XUtils.RegisterFunc(L, XUtils.SETTER_IDX, "NeedFollowInterpolation", _s_set_NeedFollowInterpolation);
            XUtils.RegisterFunc(L, XUtils.SETTER_IDX, "FollowDistance", _s_set_FollowDistance);
            XUtils.RegisterFunc(L, XUtils.SETTER_IDX, "FollowOffset", _s_set_FollowOffset);
            XUtils.RegisterFunc(L, XUtils.SETTER_IDX, "Mode", _s_set_Mode);
            XUtils.RegisterFunc(L, XUtils.SETTER_IDX, "CameraSelects", _s_set_CameraSelects);
            
			XUtils.EndObjectRegister(typeof(CameraControl), L, translator, null, null,
			    null, null, null);

		    XUtils.BeginClassRegister(typeof(CameraControl), L, __CreateInstance, 2, 0, 0);
			XUtils.RegisterFunc(L, XUtils.CLS_IDX, "ProcessHitCollision", _m_ProcessHitCollision_xlua_st_);
            
			
            
            XUtils.RegisterObject(L, translator, XUtils.CLS_IDX, "UnderlyingSystemType", typeof(CameraControl));
			
			
			XUtils.EndClassRegister(typeof(CameraControl), L, translator);
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int __CreateInstance(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			try {
				if(LuaAPI.lua_gettop(L) == 1)
				{
					
					CameraControl __cl_gen_ret = new CameraControl();
					translator.Push(L, __cl_gen_ret);
					return 1;
				}
				
			}
			catch(System.Exception __gen_e) {
				return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
			}
            return LuaAPI.luaL_error(L, "invalid arguments to CameraControl constructor!");
            
        }
        
		
        
		
        
        
        
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_CloneCamera(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            CameraControl __cl_gen_to_be_invoked = (CameraControl)translator.FastGetCSObj(L, 1);
            
            
            try {
                
                {
                    UnityEngine.Camera cam = (UnityEngine.Camera)translator.GetObject(L, 2, typeof(UnityEngine.Camera));
                    
                    __cl_gen_to_be_invoked.CloneCamera( cam );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_SimpleShake(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            CameraControl __cl_gen_to_be_invoked = (CameraControl)translator.FastGetCSObj(L, 1);
            
            
            try {
                
                {
                    float strength = (float)LuaAPI.lua_tonumber(L, 2);
                    float length = (float)LuaAPI.lua_tonumber(L, 3);
                    
                    __cl_gen_to_be_invoked.SimpleShake( strength, length );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_CurveShake(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            CameraControl __cl_gen_to_be_invoked = (CameraControl)translator.FastGetCSObj(L, 1);
            
            
            try {
                
                {
                    CameraCurveShake shake = (CameraCurveShake)translator.GetObject(L, 2, typeof(CameraCurveShake));
                    
                    __cl_gen_to_be_invoked.CurveShake( shake );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_SelectChildCamera(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            CameraControl __cl_gen_to_be_invoked = (CameraControl)translator.FastGetCSObj(L, 1);
            
            
            try {
                
                {
                    int index = LuaAPI.xlua_tointeger(L, 2);
                    
                    __cl_gen_to_be_invoked.SelectChildCamera( index );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_HideLayer(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            CameraControl __cl_gen_to_be_invoked = (CameraControl)translator.FastGetCSObj(L, 1);
            
            
            try {
                
                {
                    string layerName = LuaAPI.lua_tostring(L, 2);
                    
                    __cl_gen_to_be_invoked.HideLayer( layerName );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_ShowLayer(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            CameraControl __cl_gen_to_be_invoked = (CameraControl)translator.FastGetCSObj(L, 1);
            
            
            try {
                
                {
                    string layerName = LuaAPI.lua_tostring(L, 2);
                    
                    __cl_gen_to_be_invoked.ShowLayer( layerName );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_ProcessHitCollision_xlua_st_(RealStatePtr L)
        {
            
            
            
            try {
                
                {
                    
                    CameraControl.ProcessHitCollision(  );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        
        
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_ForceForwardObject(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                CameraControl __cl_gen_to_be_invoked = (CameraControl)translator.FastGetCSObj(L, 1);
                translator.Push(L, __cl_gen_to_be_invoked.ForceForwardObject);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_RealCamera(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                CameraControl __cl_gen_to_be_invoked = (CameraControl)translator.FastGetCSObj(L, 1);
                translator.Push(L, __cl_gen_to_be_invoked.RealCamera);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_Target(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                CameraControl __cl_gen_to_be_invoked = (CameraControl)translator.FastGetCSObj(L, 1);
                translator.Push(L, __cl_gen_to_be_invoked.Target);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_SelectedChildCamera(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                CameraControl __cl_gen_to_be_invoked = (CameraControl)translator.FastGetCSObj(L, 1);
                translator.Push(L, __cl_gen_to_be_invoked.SelectedChildCamera);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_CullDistances(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                CameraControl __cl_gen_to_be_invoked = (CameraControl)translator.FastGetCSObj(L, 1);
                LuaAPI.lua_pushnumber(L, __cl_gen_to_be_invoked.CullDistances);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_FollowInterpolationDistance(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                CameraControl __cl_gen_to_be_invoked = (CameraControl)translator.FastGetCSObj(L, 1);
                LuaAPI.lua_pushnumber(L, __cl_gen_to_be_invoked.FollowInterpolationDistance);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_NeedFollowInterpolation(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                CameraControl __cl_gen_to_be_invoked = (CameraControl)translator.FastGetCSObj(L, 1);
                LuaAPI.lua_pushboolean(L, __cl_gen_to_be_invoked.NeedFollowInterpolation);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_FollowDistance(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                CameraControl __cl_gen_to_be_invoked = (CameraControl)translator.FastGetCSObj(L, 1);
                LuaAPI.lua_pushnumber(L, __cl_gen_to_be_invoked.FollowDistance);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_FollowOffset(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                CameraControl __cl_gen_to_be_invoked = (CameraControl)translator.FastGetCSObj(L, 1);
                translator.PushUnityEngineVector3(L, __cl_gen_to_be_invoked.FollowOffset);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_Mode(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                CameraControl __cl_gen_to_be_invoked = (CameraControl)translator.FastGetCSObj(L, 1);
                translator.PushCameraControlEMode(L, __cl_gen_to_be_invoked.Mode);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_CameraSelects(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                CameraControl __cl_gen_to_be_invoked = (CameraControl)translator.FastGetCSObj(L, 1);
                translator.Push(L, __cl_gen_to_be_invoked.CameraSelects);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_ForceForwardObject(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                CameraControl __cl_gen_to_be_invoked = (CameraControl)translator.FastGetCSObj(L, 1);
                __cl_gen_to_be_invoked.ForceForwardObject = (UnityEngine.GameObject)translator.GetObject(L, 2, typeof(UnityEngine.GameObject));
            
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_Target(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                CameraControl __cl_gen_to_be_invoked = (CameraControl)translator.FastGetCSObj(L, 1);
                __cl_gen_to_be_invoked.Target = (UnityEngine.Transform)translator.GetObject(L, 2, typeof(UnityEngine.Transform));
            
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_Zoom(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                CameraControl __cl_gen_to_be_invoked = (CameraControl)translator.FastGetCSObj(L, 1);
                __cl_gen_to_be_invoked.Zoom = (float)LuaAPI.lua_tonumber(L, 2);
            
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_FOV(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                CameraControl __cl_gen_to_be_invoked = (CameraControl)translator.FastGetCSObj(L, 1);
                __cl_gen_to_be_invoked.FOV = (float)LuaAPI.lua_tonumber(L, 2);
            
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_CullDistances(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                CameraControl __cl_gen_to_be_invoked = (CameraControl)translator.FastGetCSObj(L, 1);
                __cl_gen_to_be_invoked.CullDistances = (float)LuaAPI.lua_tonumber(L, 2);
            
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_FollowInterpolationDistance(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                CameraControl __cl_gen_to_be_invoked = (CameraControl)translator.FastGetCSObj(L, 1);
                __cl_gen_to_be_invoked.FollowInterpolationDistance = (float)LuaAPI.lua_tonumber(L, 2);
            
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_NeedFollowInterpolation(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                CameraControl __cl_gen_to_be_invoked = (CameraControl)translator.FastGetCSObj(L, 1);
                __cl_gen_to_be_invoked.NeedFollowInterpolation = LuaAPI.lua_toboolean(L, 2);
            
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_FollowDistance(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                CameraControl __cl_gen_to_be_invoked = (CameraControl)translator.FastGetCSObj(L, 1);
                __cl_gen_to_be_invoked.FollowDistance = (float)LuaAPI.lua_tonumber(L, 2);
            
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_FollowOffset(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                CameraControl __cl_gen_to_be_invoked = (CameraControl)translator.FastGetCSObj(L, 1);
                UnityEngine.Vector3 __cl_gen_value;translator.Get(L, 2, out __cl_gen_value);
				__cl_gen_to_be_invoked.FollowOffset = __cl_gen_value;
            
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_Mode(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                CameraControl __cl_gen_to_be_invoked = (CameraControl)translator.FastGetCSObj(L, 1);
                CameraControl.EMode __cl_gen_value;translator.Get(L, 2, out __cl_gen_value);
				__cl_gen_to_be_invoked.Mode = __cl_gen_value;
            
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_CameraSelects(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                CameraControl __cl_gen_to_be_invoked = (CameraControl)translator.FastGetCSObj(L, 1);
                __cl_gen_to_be_invoked.CameraSelects = (UnityEngine.Transform[])translator.GetObject(L, 2, typeof(UnityEngine.Transform[]));
            
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 0;
        }
        
		
		
		
		
    }
}
