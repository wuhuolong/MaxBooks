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
    public class UIPreviewModelWrap
    {
        public static void __Register(RealStatePtr L)
        {
			ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			XUtils.BeginObjectRegister(typeof(UIPreviewModel), L, translator, 0, 4, 8, 8);
			
			XUtils.RegisterFunc(L, XUtils.METHOD_IDX, "SetGameObject", _m_SetGameObject);
			XUtils.RegisterFunc(L, XUtils.METHOD_IDX, "UpdateQueue", _m_UpdateQueue);
			XUtils.RegisterFunc(L, XUtils.METHOD_IDX, "SetEffectVisiable", _m_SetEffectVisiable);
			XUtils.RegisterFunc(L, XUtils.METHOD_IDX, "Destroy", _m_Destroy);
			
			
			XUtils.RegisterFunc(L, XUtils.GETTER_IDX, "mGameObject", _g_get_mGameObject);
            XUtils.RegisterFunc(L, XUtils.GETTER_IDX, "ModelLocalEulerAngles", _g_get_ModelLocalEulerAngles);
            XUtils.RegisterFunc(L, XUtils.GETTER_IDX, "ModelLocalPosition", _g_get_ModelLocalPosition);
            XUtils.RegisterFunc(L, XUtils.GETTER_IDX, "ModelLocalScale", _g_get_ModelLocalScale);
            XUtils.RegisterFunc(L, XUtils.GETTER_IDX, "ModelParentLocalEulerAngles", _g_get_ModelParentLocalEulerAngles);
            XUtils.RegisterFunc(L, XUtils.GETTER_IDX, "ModelParentLocalPos", _g_get_ModelParentLocalPos);
            XUtils.RegisterFunc(L, XUtils.GETTER_IDX, "m_FixedTouchTransform", _g_get_m_FixedTouchTransform);
            XUtils.RegisterFunc(L, XUtils.GETTER_IDX, "CanRotate", _g_get_CanRotate);
            
			XUtils.RegisterFunc(L, XUtils.SETTER_IDX, "mGameObject", _s_set_mGameObject);
            XUtils.RegisterFunc(L, XUtils.SETTER_IDX, "ModelLocalEulerAngles", _s_set_ModelLocalEulerAngles);
            XUtils.RegisterFunc(L, XUtils.SETTER_IDX, "ModelLocalPosition", _s_set_ModelLocalPosition);
            XUtils.RegisterFunc(L, XUtils.SETTER_IDX, "ModelLocalScale", _s_set_ModelLocalScale);
            XUtils.RegisterFunc(L, XUtils.SETTER_IDX, "ModelParentLocalEulerAngles", _s_set_ModelParentLocalEulerAngles);
            XUtils.RegisterFunc(L, XUtils.SETTER_IDX, "ModelParentLocalPos", _s_set_ModelParentLocalPos);
            XUtils.RegisterFunc(L, XUtils.SETTER_IDX, "m_FixedTouchTransform", _s_set_m_FixedTouchTransform);
            XUtils.RegisterFunc(L, XUtils.SETTER_IDX, "CanRotate", _s_set_CanRotate);
            
			XUtils.EndObjectRegister(typeof(UIPreviewModel), L, translator, null, null,
			    null, null, null);

		    XUtils.BeginClassRegister(typeof(UIPreviewModel), L, __CreateInstance, 1, 0, 0);
			
			
            
            XUtils.RegisterObject(L, translator, XUtils.CLS_IDX, "UnderlyingSystemType", typeof(UIPreviewModel));
			
			
			XUtils.EndClassRegister(typeof(UIPreviewModel), L, translator);
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int __CreateInstance(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			try {
				if(LuaAPI.lua_gettop(L) == 1)
				{
					
					UIPreviewModel __cl_gen_ret = new UIPreviewModel();
					translator.Push(L, __cl_gen_ret);
					return 1;
				}
				
			}
			catch(System.Exception __gen_e) {
				return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
			}
            return LuaAPI.luaL_error(L, "invalid arguments to UIPreviewModel constructor!");
            
        }
        
		
        
		
        
        
        
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_SetGameObject(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            UIPreviewModel __cl_gen_to_be_invoked = (UIPreviewModel)translator.FastGetCSObj(L, 1);
            
            
            try {
                
                {
                    UnityEngine.GameObject go = (UnityEngine.GameObject)translator.GetObject(L, 2, typeof(UnityEngine.GameObject));
                    
                    __cl_gen_to_be_invoked.SetGameObject( go );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_UpdateQueue(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            UIPreviewModel __cl_gen_to_be_invoked = (UIPreviewModel)translator.FastGetCSObj(L, 1);
            
            
            try {
                
                {
                    
                    __cl_gen_to_be_invoked.UpdateQueue(  );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_SetEffectVisiable(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            UIPreviewModel __cl_gen_to_be_invoked = (UIPreviewModel)translator.FastGetCSObj(L, 1);
            
            
            try {
                
                {
                    bool is_visiable = LuaAPI.lua_toboolean(L, 2);
                    
                    __cl_gen_to_be_invoked.SetEffectVisiable( is_visiable );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_Destroy(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            UIPreviewModel __cl_gen_to_be_invoked = (UIPreviewModel)translator.FastGetCSObj(L, 1);
            
            
            try {
                
                {
                    
                    __cl_gen_to_be_invoked.Destroy(  );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        
        
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_mGameObject(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                UIPreviewModel __cl_gen_to_be_invoked = (UIPreviewModel)translator.FastGetCSObj(L, 1);
                translator.Push(L, __cl_gen_to_be_invoked.mGameObject);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_ModelLocalEulerAngles(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                UIPreviewModel __cl_gen_to_be_invoked = (UIPreviewModel)translator.FastGetCSObj(L, 1);
                translator.PushUnityEngineVector3(L, __cl_gen_to_be_invoked.ModelLocalEulerAngles);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_ModelLocalPosition(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                UIPreviewModel __cl_gen_to_be_invoked = (UIPreviewModel)translator.FastGetCSObj(L, 1);
                translator.PushUnityEngineVector3(L, __cl_gen_to_be_invoked.ModelLocalPosition);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_ModelLocalScale(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                UIPreviewModel __cl_gen_to_be_invoked = (UIPreviewModel)translator.FastGetCSObj(L, 1);
                translator.PushUnityEngineVector3(L, __cl_gen_to_be_invoked.ModelLocalScale);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_ModelParentLocalEulerAngles(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                UIPreviewModel __cl_gen_to_be_invoked = (UIPreviewModel)translator.FastGetCSObj(L, 1);
                translator.PushUnityEngineVector3(L, __cl_gen_to_be_invoked.ModelParentLocalEulerAngles);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_ModelParentLocalPos(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                UIPreviewModel __cl_gen_to_be_invoked = (UIPreviewModel)translator.FastGetCSObj(L, 1);
                translator.PushUnityEngineVector3(L, __cl_gen_to_be_invoked.ModelParentLocalPos);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_m_FixedTouchTransform(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                UIPreviewModel __cl_gen_to_be_invoked = (UIPreviewModel)translator.FastGetCSObj(L, 1);
                translator.Push(L, __cl_gen_to_be_invoked.m_FixedTouchTransform);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_CanRotate(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                UIPreviewModel __cl_gen_to_be_invoked = (UIPreviewModel)translator.FastGetCSObj(L, 1);
                LuaAPI.lua_pushboolean(L, __cl_gen_to_be_invoked.CanRotate);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_mGameObject(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                UIPreviewModel __cl_gen_to_be_invoked = (UIPreviewModel)translator.FastGetCSObj(L, 1);
                __cl_gen_to_be_invoked.mGameObject = (UnityEngine.GameObject)translator.GetObject(L, 2, typeof(UnityEngine.GameObject));
            
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_ModelLocalEulerAngles(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                UIPreviewModel __cl_gen_to_be_invoked = (UIPreviewModel)translator.FastGetCSObj(L, 1);
                UnityEngine.Vector3 __cl_gen_value;translator.Get(L, 2, out __cl_gen_value);
				__cl_gen_to_be_invoked.ModelLocalEulerAngles = __cl_gen_value;
            
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_ModelLocalPosition(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                UIPreviewModel __cl_gen_to_be_invoked = (UIPreviewModel)translator.FastGetCSObj(L, 1);
                UnityEngine.Vector3 __cl_gen_value;translator.Get(L, 2, out __cl_gen_value);
				__cl_gen_to_be_invoked.ModelLocalPosition = __cl_gen_value;
            
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_ModelLocalScale(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                UIPreviewModel __cl_gen_to_be_invoked = (UIPreviewModel)translator.FastGetCSObj(L, 1);
                UnityEngine.Vector3 __cl_gen_value;translator.Get(L, 2, out __cl_gen_value);
				__cl_gen_to_be_invoked.ModelLocalScale = __cl_gen_value;
            
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_ModelParentLocalEulerAngles(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                UIPreviewModel __cl_gen_to_be_invoked = (UIPreviewModel)translator.FastGetCSObj(L, 1);
                UnityEngine.Vector3 __cl_gen_value;translator.Get(L, 2, out __cl_gen_value);
				__cl_gen_to_be_invoked.ModelParentLocalEulerAngles = __cl_gen_value;
            
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_ModelParentLocalPos(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                UIPreviewModel __cl_gen_to_be_invoked = (UIPreviewModel)translator.FastGetCSObj(L, 1);
                UnityEngine.Vector3 __cl_gen_value;translator.Get(L, 2, out __cl_gen_value);
				__cl_gen_to_be_invoked.ModelParentLocalPos = __cl_gen_value;
            
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_m_FixedTouchTransform(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                UIPreviewModel __cl_gen_to_be_invoked = (UIPreviewModel)translator.FastGetCSObj(L, 1);
                __cl_gen_to_be_invoked.m_FixedTouchTransform = (UnityEngine.RectTransform)translator.GetObject(L, 2, typeof(UnityEngine.RectTransform));
            
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_CanRotate(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                UIPreviewModel __cl_gen_to_be_invoked = (UIPreviewModel)translator.FastGetCSObj(L, 1);
                __cl_gen_to_be_invoked.CanRotate = LuaAPI.lua_toboolean(L, 2);
            
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 0;
        }
        
		
		
		
		
    }
}
