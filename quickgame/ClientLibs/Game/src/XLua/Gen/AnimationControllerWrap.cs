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
    public class AnimationControllerWrap
    {
        public static void __Register(RealStatePtr L)
        {
			ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			XUtils.BeginObjectRegister(typeof(AnimationController), L, translator, 0, 13, 1, 1);
			
			XUtils.RegisterFunc(L, XUtils.METHOD_IDX, "IsPlaying", _m_IsPlaying);
			XUtils.RegisterFunc(L, XUtils.METHOD_IDX, "IsInAnimationState", _m_IsInAnimationState);
			XUtils.RegisterFunc(L, XUtils.METHOD_IDX, "SetAnimationSpeed", _m_SetAnimationSpeed);
			XUtils.RegisterFunc(L, XUtils.METHOD_IDX, "SetMoveSpeed", _m_SetMoveSpeed);
			XUtils.RegisterFunc(L, XUtils.METHOD_IDX, "GetAnimationLength", _m_GetAnimationLength);
			XUtils.RegisterFunc(L, XUtils.METHOD_IDX, "Pause", _m_Pause);
			XUtils.RegisterFunc(L, XUtils.METHOD_IDX, "Reset", _m_Reset);
			XUtils.RegisterFunc(L, XUtils.METHOD_IDX, "HasAnimation", _m_HasAnimation);
			XUtils.RegisterFunc(L, XUtils.METHOD_IDX, "PlayAnimation", _m_PlayAnimation);
			XUtils.RegisterFunc(L, XUtils.METHOD_IDX, "CrossfadeAnimation", _m_CrossfadeAnimation);
			XUtils.RegisterFunc(L, XUtils.METHOD_IDX, "OnPlayBegin", _m_OnPlayBegin);
			XUtils.RegisterFunc(L, XUtils.METHOD_IDX, "OnPlayEnd", _m_OnPlayEnd);
			XUtils.RegisterFunc(L, XUtils.METHOD_IDX, "OnHit", _m_OnHit);
			
			
			XUtils.RegisterFunc(L, XUtils.GETTER_IDX, "CullMode", _g_get_CullMode);
            
			XUtils.RegisterFunc(L, XUtils.SETTER_IDX, "CullMode", _s_set_CullMode);
            
			XUtils.EndObjectRegister(typeof(AnimationController), L, translator, null, null,
			    null, null, null);

		    XUtils.BeginClassRegister(typeof(AnimationController), L, __CreateInstance, 1, 1, 0);
			
			
            
            XUtils.RegisterObject(L, translator, XUtils.CLS_IDX, "UnderlyingSystemType", typeof(AnimationController));
			XUtils.RegisterFunc(L, XUtils.CLS_GETTER_IDX, "LoopAnimations", _g_get_LoopAnimations);
            
			
			XUtils.EndClassRegister(typeof(AnimationController), L, translator);
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int __CreateInstance(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			try {
				if(LuaAPI.lua_gettop(L) == 1)
				{
					
					AnimationController __cl_gen_ret = new AnimationController();
					translator.Push(L, __cl_gen_ret);
					return 1;
				}
				
			}
			catch(System.Exception __gen_e) {
				return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
			}
            return LuaAPI.luaL_error(L, "invalid arguments to AnimationController constructor!");
            
        }
        
		
        
		
        
        
        
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_IsPlaying(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            AnimationController __cl_gen_to_be_invoked = (AnimationController)translator.FastGetCSObj(L, 1);
            
            
			int __gen_param_count = LuaAPI.lua_gettop(L);
            
            try {
                if(__gen_param_count == 1) 
                {
                    
                        bool __cl_gen_ret = __cl_gen_to_be_invoked.IsPlaying(  );
                        LuaAPI.lua_pushboolean(L, __cl_gen_ret);
                    
                    
                    
                    return 1;
                }
                if(__gen_param_count == 2&& (LuaAPI.lua_isnil(L, 2) || LuaAPI.lua_type(L, 2) == LuaTypes.LUA_TSTRING)) 
                {
                    string strName = LuaAPI.lua_tostring(L, 2);
                    
                        bool __cl_gen_ret = __cl_gen_to_be_invoked.IsPlaying( strName );
                        LuaAPI.lua_pushboolean(L, __cl_gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
            return LuaAPI.luaL_error(L, "invalid arguments to AnimationController.IsPlaying!");
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_IsInAnimationState(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            AnimationController __cl_gen_to_be_invoked = (AnimationController)translator.FastGetCSObj(L, 1);
            
            
            try {
                
                {
                    string ani = LuaAPI.lua_tostring(L, 2);
                    
                        bool __cl_gen_ret = __cl_gen_to_be_invoked.IsInAnimationState( ani );
                        LuaAPI.lua_pushboolean(L, __cl_gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_SetAnimationSpeed(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            AnimationController __cl_gen_to_be_invoked = (AnimationController)translator.FastGetCSObj(L, 1);
            
            
            try {
                
                {
                    float speed = (float)LuaAPI.lua_tonumber(L, 2);
                    
                    __cl_gen_to_be_invoked.SetAnimationSpeed( speed );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_SetMoveSpeed(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            AnimationController __cl_gen_to_be_invoked = (AnimationController)translator.FastGetCSObj(L, 1);
            
            
            try {
                
                {
                    float speed = (float)LuaAPI.lua_tonumber(L, 2);
                    
                    __cl_gen_to_be_invoked.SetMoveSpeed( speed );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_GetAnimationLength(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            AnimationController __cl_gen_to_be_invoked = (AnimationController)translator.FastGetCSObj(L, 1);
            
            
            try {
                
                {
                    string ani = LuaAPI.lua_tostring(L, 2);
                    
                        float __cl_gen_ret = __cl_gen_to_be_invoked.GetAnimationLength( ani );
                        LuaAPI.lua_pushnumber(L, __cl_gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_Pause(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            AnimationController __cl_gen_to_be_invoked = (AnimationController)translator.FastGetCSObj(L, 1);
            
            
            try {
                
                {
                    bool bPause = LuaAPI.lua_toboolean(L, 2);
                    
                    __cl_gen_to_be_invoked.Pause( bPause );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_Reset(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            AnimationController __cl_gen_to_be_invoked = (AnimationController)translator.FastGetCSObj(L, 1);
            
            
            try {
                
                {
                    
                    __cl_gen_to_be_invoked.Reset(  );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_HasAnimation(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            AnimationController __cl_gen_to_be_invoked = (AnimationController)translator.FastGetCSObj(L, 1);
            
            
            try {
                
                {
                    string ani = LuaAPI.lua_tostring(L, 2);
                    
                        bool __cl_gen_ret = __cl_gen_to_be_invoked.HasAnimation( ani );
                        LuaAPI.lua_pushboolean(L, __cl_gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_PlayAnimation(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            AnimationController __cl_gen_to_be_invoked = (AnimationController)translator.FastGetCSObj(L, 1);
            
            
			int __gen_param_count = LuaAPI.lua_gettop(L);
            
            try {
                if(__gen_param_count == 3&& (LuaAPI.lua_isnil(L, 2) || LuaAPI.lua_type(L, 2) == LuaTypes.LUA_TSTRING)&& LuaTypes.LUA_TNUMBER == LuaAPI.lua_type(L, 3)) 
                {
                    string name = LuaAPI.lua_tostring(L, 2);
                    float time = (float)LuaAPI.lua_tonumber(L, 3);
                    
                        bool __cl_gen_ret = __cl_gen_to_be_invoked.PlayAnimation( name, time );
                        LuaAPI.lua_pushboolean(L, __cl_gen_ret);
                    
                    
                    
                    return 1;
                }
                if(__gen_param_count == 2&& (LuaAPI.lua_isnil(L, 2) || LuaAPI.lua_type(L, 2) == LuaTypes.LUA_TSTRING)) 
                {
                    string name = LuaAPI.lua_tostring(L, 2);
                    
                        bool __cl_gen_ret = __cl_gen_to_be_invoked.PlayAnimation( name );
                        LuaAPI.lua_pushboolean(L, __cl_gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
            return LuaAPI.luaL_error(L, "invalid arguments to AnimationController.PlayAnimation!");
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_CrossfadeAnimation(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            AnimationController __cl_gen_to_be_invoked = (AnimationController)translator.FastGetCSObj(L, 1);
            
            
            try {
                
                {
                    string name = LuaAPI.lua_tostring(L, 2);
                    float fadeTime = (float)LuaAPI.lua_tonumber(L, 3);
                    
                        bool __cl_gen_ret = __cl_gen_to_be_invoked.CrossfadeAnimation( name, fadeTime );
                        LuaAPI.lua_pushboolean(L, __cl_gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_OnPlayBegin(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            AnimationController __cl_gen_to_be_invoked = (AnimationController)translator.FastGetCSObj(L, 1);
            
            
            try {
                
                {
                    string param = LuaAPI.lua_tostring(L, 2);
                    
                    __cl_gen_to_be_invoked.OnPlayBegin( param );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_OnPlayEnd(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            AnimationController __cl_gen_to_be_invoked = (AnimationController)translator.FastGetCSObj(L, 1);
            
            
            try {
                
                {
                    string param = LuaAPI.lua_tostring(L, 2);
                    
                    __cl_gen_to_be_invoked.OnPlayEnd( param );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_OnHit(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            AnimationController __cl_gen_to_be_invoked = (AnimationController)translator.FastGetCSObj(L, 1);
            
            
            try {
                
                {
                    int param = LuaAPI.xlua_tointeger(L, 2);
                    
                    __cl_gen_to_be_invoked.OnHit( param );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        
        
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_CullMode(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                AnimationController __cl_gen_to_be_invoked = (AnimationController)translator.FastGetCSObj(L, 1);
                translator.PushUnityEngineAnimatorCullingMode(L, __cl_gen_to_be_invoked.CullMode);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_LoopAnimations(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			    translator.Push(L, AnimationController.LoopAnimations);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_CullMode(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                AnimationController __cl_gen_to_be_invoked = (AnimationController)translator.FastGetCSObj(L, 1);
                UnityEngine.AnimatorCullingMode __cl_gen_value;translator.Get(L, 2, out __cl_gen_value);
				__cl_gen_to_be_invoked.CullMode = __cl_gen_value;
            
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 0;
        }
        
		
		
		
		
    }
}
