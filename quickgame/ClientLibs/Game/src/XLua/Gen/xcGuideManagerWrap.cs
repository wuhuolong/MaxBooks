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
    public class xcGuideManagerWrap
    {
        public static void __Register(RealStatePtr L)
        {
			ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			XUtils.BeginObjectRegister(typeof(xc.GuideManager), L, translator, 0, 31, 9, 2);
			
			XUtils.RegisterFunc(L, XUtils.METHOD_IDX, "RegisterAllMessages", _m_RegisterAllMessages);
			XUtils.RegisterFunc(L, XUtils.METHOD_IDX, "Reset", _m_Reset);
			XUtils.RegisterFunc(L, XUtils.METHOD_IDX, "StartGuide", _m_StartGuide);
			XUtils.RegisterFunc(L, XUtils.METHOD_IDX, "IsGuideForceStart", _m_IsGuideForceStart);
			XUtils.RegisterFunc(L, XUtils.METHOD_IDX, "ForceReStartGuide", _m_ForceReStartGuide);
			XUtils.RegisterFunc(L, XUtils.METHOD_IDX, "ForceCheckGuides", _m_ForceCheckGuides);
			XUtils.RegisterFunc(L, XUtils.METHOD_IDX, "FinishGuideStep", _m_FinishGuideStep);
			XUtils.RegisterFunc(L, XUtils.METHOD_IDX, "SkipGuideStep", _m_SkipGuideStep);
			XUtils.RegisterFunc(L, XUtils.METHOD_IDX, "SkipCurrentGuide", _m_SkipCurrentGuide);
			XUtils.RegisterFunc(L, XUtils.METHOD_IDX, "IsTaskFinished", _m_IsTaskFinished);
			XUtils.RegisterFunc(L, XUtils.METHOD_IDX, "IsTimelineFinish", _m_IsTimelineFinish);
			XUtils.RegisterFunc(L, XUtils.METHOD_IDX, "TryToFinishGuideStep", _m_TryToFinishGuideStep);
			XUtils.RegisterFunc(L, XUtils.METHOD_IDX, "TryToStopGuideStep", _m_TryToStopGuideStep);
			XUtils.RegisterFunc(L, XUtils.METHOD_IDX, "TryToResetGuideStep", _m_TryToResetGuideStep);
			XUtils.RegisterFunc(L, XUtils.METHOD_IDX, "Pause", _m_Pause);
			XUtils.RegisterFunc(L, XUtils.METHOD_IDX, "Resume", _m_Resume);
			XUtils.RegisterFunc(L, XUtils.METHOD_IDX, "ResetEnableRef", _m_ResetEnableRef);
			XUtils.RegisterFunc(L, XUtils.METHOD_IDX, "ForceToSleepGuide", _m_ForceToSleepGuide);
			XUtils.RegisterFunc(L, XUtils.METHOD_IDX, "ResetAllSysGuide", _m_ResetAllSysGuide);
			XUtils.RegisterFunc(L, XUtils.METHOD_IDX, "GetWidgetByPath", _m_GetWidgetByPath);
			XUtils.RegisterFunc(L, XUtils.METHOD_IDX, "IsWidgetVisible", _m_IsWidgetVisible);
			XUtils.RegisterFunc(L, XUtils.METHOD_IDX, "MatchComponent", _m_MatchComponent);
			XUtils.RegisterFunc(L, XUtils.METHOD_IDX, "IsWidgetTouched", _m_IsWidgetTouched);
			XUtils.RegisterFunc(L, XUtils.METHOD_IDX, "IsParent", _m_IsParent);
			XUtils.RegisterFunc(L, XUtils.METHOD_IDX, "ForceFinishAllGuides", _m_ForceFinishAllGuides);
			XUtils.RegisterFunc(L, XUtils.METHOD_IDX, "IsSysGuideStepPlaying", _m_IsSysGuideStepPlaying);
			XUtils.RegisterFunc(L, XUtils.METHOD_IDX, "IsGuidePlaying", _m_IsGuidePlaying);
			XUtils.RegisterFunc(L, XUtils.METHOD_IDX, "IsSysOpenPlaying", _m_IsSysOpenPlaying);
			XUtils.RegisterFunc(L, XUtils.METHOD_IDX, "GetPlayingGuides", _m_GetPlayingGuides);
			XUtils.RegisterFunc(L, XUtils.METHOD_IDX, "Update", _m_Update);
			XUtils.RegisterFunc(L, XUtils.METHOD_IDX, "IsGuideFinish", _m_IsGuideFinish);
			
			
			XUtils.RegisterFunc(L, XUtils.GETTER_IDX, "IsPause", _g_get_IsPause);
            XUtils.RegisterFunc(L, XUtils.GETTER_IDX, "TestGuide", _g_get_TestGuide);
            XUtils.RegisterFunc(L, XUtils.GETTER_IDX, "ListeningStepDict", _g_get_ListeningStepDict);
            XUtils.RegisterFunc(L, XUtils.GETTER_IDX, "ForceStartStepDict", _g_get_ForceStartStepDict);
            XUtils.RegisterFunc(L, XUtils.GETTER_IDX, "IgnoreRaycastGameObjects", _g_get_IgnoreRaycastGameObjects);
            XUtils.RegisterFunc(L, XUtils.GETTER_IDX, "IsPlayingGuideStep", _g_get_IsPlayingGuideStep);
            XUtils.RegisterFunc(L, XUtils.GETTER_IDX, "PlayingGuideStep", _g_get_PlayingGuideStep);
            XUtils.RegisterFunc(L, XUtils.GETTER_IDX, "IsPlayingForcibleStep", _g_get_IsPlayingForcibleStep);
            XUtils.RegisterFunc(L, XUtils.GETTER_IDX, "OnTouched", _g_get_OnTouched);
            
			XUtils.RegisterFunc(L, XUtils.SETTER_IDX, "TestGuide", _s_set_TestGuide);
            XUtils.RegisterFunc(L, XUtils.SETTER_IDX, "OnTouched", _s_set_OnTouched);
            
			XUtils.EndObjectRegister(typeof(xc.GuideManager), L, translator, null, null,
			    null, null, null);

		    XUtils.BeginClassRegister(typeof(xc.GuideManager), L, __CreateInstance, 1, 0, 0);
			
			
            
            XUtils.RegisterObject(L, translator, XUtils.CLS_IDX, "UnderlyingSystemType", typeof(xc.GuideManager));
			
			
			XUtils.EndClassRegister(typeof(xc.GuideManager), L, translator);
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int __CreateInstance(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			try {
				if(LuaAPI.lua_gettop(L) == 1)
				{
					
					xc.GuideManager __cl_gen_ret = new xc.GuideManager();
					translator.Push(L, __cl_gen_ret);
					return 1;
				}
				
			}
			catch(System.Exception __gen_e) {
				return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
			}
            return LuaAPI.luaL_error(L, "invalid arguments to xc.GuideManager constructor!");
            
        }
        
		
        
		
        
        
        
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_RegisterAllMessages(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            xc.GuideManager __cl_gen_to_be_invoked = (xc.GuideManager)translator.FastGetCSObj(L, 1);
            
            
            try {
                
                {
                    
                    __cl_gen_to_be_invoked.RegisterAllMessages(  );
                    
                    
                    
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
            
            
            xc.GuideManager __cl_gen_to_be_invoked = (xc.GuideManager)translator.FastGetCSObj(L, 1);
            
            
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
        static int _m_StartGuide(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            xc.GuideManager __cl_gen_to_be_invoked = (xc.GuideManager)translator.FastGetCSObj(L, 1);
            
            
            try {
                
                {
                    uint guide_id = LuaAPI.xlua_touint(L, 2);
                    xc.GuideManager.WaitGuideFinishDelegate finish_cb = translator.GetDelegate<xc.GuideManager.WaitGuideFinishDelegate>(L, 3);
                    
                    __cl_gen_to_be_invoked.StartGuide( guide_id, finish_cb );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_IsGuideForceStart(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            xc.GuideManager __cl_gen_to_be_invoked = (xc.GuideManager)translator.FastGetCSObj(L, 1);
            
            
            try {
                
                {
                    uint guide_id = LuaAPI.xlua_touint(L, 2);
                    
                        bool __cl_gen_ret = __cl_gen_to_be_invoked.IsGuideForceStart( guide_id );
                        LuaAPI.lua_pushboolean(L, __cl_gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_ForceReStartGuide(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            xc.GuideManager __cl_gen_to_be_invoked = (xc.GuideManager)translator.FastGetCSObj(L, 1);
            
            
            try {
                
                {
                    uint guide_id = LuaAPI.xlua_touint(L, 2);
                    
                    __cl_gen_to_be_invoked.ForceReStartGuide( guide_id );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_ForceCheckGuides(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            xc.GuideManager __cl_gen_to_be_invoked = (xc.GuideManager)translator.FastGetCSObj(L, 1);
            
            
            try {
                
                {
                    
                    __cl_gen_to_be_invoked.ForceCheckGuides(  );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_FinishGuideStep(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            xc.GuideManager __cl_gen_to_be_invoked = (xc.GuideManager)translator.FastGetCSObj(L, 1);
            
            
            try {
                
                {
                    uint guideId = LuaAPI.xlua_touint(L, 2);
                    uint stepId = LuaAPI.xlua_touint(L, 3);
                    
                    __cl_gen_to_be_invoked.FinishGuideStep( guideId, stepId );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_SkipGuideStep(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            xc.GuideManager __cl_gen_to_be_invoked = (xc.GuideManager)translator.FastGetCSObj(L, 1);
            
            
            try {
                
                {
                    Guide.Step guide_step = (Guide.Step)translator.GetObject(L, 2, typeof(Guide.Step));
                    
                    __cl_gen_to_be_invoked.SkipGuideStep( guide_step );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_SkipCurrentGuide(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            xc.GuideManager __cl_gen_to_be_invoked = (xc.GuideManager)translator.FastGetCSObj(L, 1);
            
            
            try {
                
                {
                    
                    __cl_gen_to_be_invoked.SkipCurrentGuide(  );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_IsTaskFinished(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            xc.GuideManager __cl_gen_to_be_invoked = (xc.GuideManager)translator.FastGetCSObj(L, 1);
            
            
            try {
                
                {
                    uint task_id = LuaAPI.xlua_touint(L, 2);
                    
                        bool __cl_gen_ret = __cl_gen_to_be_invoked.IsTaskFinished( task_id );
                        LuaAPI.lua_pushboolean(L, __cl_gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_IsTimelineFinish(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            xc.GuideManager __cl_gen_to_be_invoked = (xc.GuideManager)translator.FastGetCSObj(L, 1);
            
            
            try {
                
                {
                    uint timeline_id = LuaAPI.xlua_touint(L, 2);
                    
                        bool __cl_gen_ret = __cl_gen_to_be_invoked.IsTimelineFinish( timeline_id );
                        LuaAPI.lua_pushboolean(L, __cl_gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_TryToFinishGuideStep(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            xc.GuideManager __cl_gen_to_be_invoked = (xc.GuideManager)translator.FastGetCSObj(L, 1);
            
            
            try {
                
                {
                    Guide.Step guideStep = (Guide.Step)translator.GetObject(L, 2, typeof(Guide.Step));
                    
                    __cl_gen_to_be_invoked.TryToFinishGuideStep( guideStep );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_TryToStopGuideStep(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            xc.GuideManager __cl_gen_to_be_invoked = (xc.GuideManager)translator.FastGetCSObj(L, 1);
            
            
            try {
                
                {
                    Guide.Step guideStep = (Guide.Step)translator.GetObject(L, 2, typeof(Guide.Step));
                    
                        bool __cl_gen_ret = __cl_gen_to_be_invoked.TryToStopGuideStep( guideStep );
                        LuaAPI.lua_pushboolean(L, __cl_gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_TryToResetGuideStep(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            xc.GuideManager __cl_gen_to_be_invoked = (xc.GuideManager)translator.FastGetCSObj(L, 1);
            
            
            try {
                
                {
                    Guide.Step guideStep = (Guide.Step)translator.GetObject(L, 2, typeof(Guide.Step));
                    
                    __cl_gen_to_be_invoked.TryToResetGuideStep( guideStep );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_Pause(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            xc.GuideManager __cl_gen_to_be_invoked = (xc.GuideManager)translator.FastGetCSObj(L, 1);
            
            
            try {
                
                {
                    
                    __cl_gen_to_be_invoked.Pause(  );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_Resume(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            xc.GuideManager __cl_gen_to_be_invoked = (xc.GuideManager)translator.FastGetCSObj(L, 1);
            
            
            try {
                
                {
                    
                    __cl_gen_to_be_invoked.Resume(  );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_ResetEnableRef(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            xc.GuideManager __cl_gen_to_be_invoked = (xc.GuideManager)translator.FastGetCSObj(L, 1);
            
            
            try {
                
                {
                    
                    __cl_gen_to_be_invoked.ResetEnableRef(  );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_ForceToSleepGuide(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            xc.GuideManager __cl_gen_to_be_invoked = (xc.GuideManager)translator.FastGetCSObj(L, 1);
            
            
            try {
                
                {
                    
                    __cl_gen_to_be_invoked.ForceToSleepGuide(  );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_ResetAllSysGuide(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            xc.GuideManager __cl_gen_to_be_invoked = (xc.GuideManager)translator.FastGetCSObj(L, 1);
            
            
            try {
                
                {
                    
                    __cl_gen_to_be_invoked.ResetAllSysGuide(  );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_GetWidgetByPath(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            xc.GuideManager __cl_gen_to_be_invoked = (xc.GuideManager)translator.FastGetCSObj(L, 1);
            
            
            try {
                
                {
                    string path = LuaAPI.lua_tostring(L, 2);
                    
                        UnityEngine.GameObject __cl_gen_ret = __cl_gen_to_be_invoked.GetWidgetByPath( path );
                        translator.Push(L, __cl_gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_IsWidgetVisible(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            xc.GuideManager __cl_gen_to_be_invoked = (xc.GuideManager)translator.FastGetCSObj(L, 1);
            
            
            try {
                
                {
                    UnityEngine.GameObject widget = (UnityEngine.GameObject)translator.GetObject(L, 2, typeof(UnityEngine.GameObject));
                    
                        bool __cl_gen_ret = __cl_gen_to_be_invoked.IsWidgetVisible( widget );
                        LuaAPI.lua_pushboolean(L, __cl_gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_MatchComponent(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            xc.GuideManager __cl_gen_to_be_invoked = (xc.GuideManager)translator.FastGetCSObj(L, 1);
            
            
            try {
                
                {
                    UnityEngine.GameObject widget = (UnityEngine.GameObject)translator.GetObject(L, 2, typeof(UnityEngine.GameObject));
                    string path = LuaAPI.lua_tostring(L, 3);
                    
                        bool __cl_gen_ret = __cl_gen_to_be_invoked.MatchComponent( widget, path );
                        LuaAPI.lua_pushboolean(L, __cl_gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_IsWidgetTouched(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            xc.GuideManager __cl_gen_to_be_invoked = (xc.GuideManager)translator.FastGetCSObj(L, 1);
            
            
            try {
                
                {
                    UnityEngine.GameObject widget = (UnityEngine.GameObject)translator.GetObject(L, 2, typeof(UnityEngine.GameObject));
                    
                        bool __cl_gen_ret = __cl_gen_to_be_invoked.IsWidgetTouched( widget );
                        LuaAPI.lua_pushboolean(L, __cl_gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_IsParent(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            xc.GuideManager __cl_gen_to_be_invoked = (xc.GuideManager)translator.FastGetCSObj(L, 1);
            
            
            try {
                
                {
                    UnityEngine.GameObject parentWidget = (UnityEngine.GameObject)translator.GetObject(L, 2, typeof(UnityEngine.GameObject));
                    UnityEngine.GameObject childWidget = (UnityEngine.GameObject)translator.GetObject(L, 3, typeof(UnityEngine.GameObject));
                    
                        bool __cl_gen_ret = __cl_gen_to_be_invoked.IsParent( parentWidget, childWidget );
                        LuaAPI.lua_pushboolean(L, __cl_gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_ForceFinishAllGuides(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            xc.GuideManager __cl_gen_to_be_invoked = (xc.GuideManager)translator.FastGetCSObj(L, 1);
            
            
            try {
                
                {
                    
                    __cl_gen_to_be_invoked.ForceFinishAllGuides(  );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_IsSysGuideStepPlaying(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            xc.GuideManager __cl_gen_to_be_invoked = (xc.GuideManager)translator.FastGetCSObj(L, 1);
            
            
            try {
                
                {
                    
                        bool __cl_gen_ret = __cl_gen_to_be_invoked.IsSysGuideStepPlaying(  );
                        LuaAPI.lua_pushboolean(L, __cl_gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_IsGuidePlaying(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            xc.GuideManager __cl_gen_to_be_invoked = (xc.GuideManager)translator.FastGetCSObj(L, 1);
            
            
            try {
                
                {
                    
                        bool __cl_gen_ret = __cl_gen_to_be_invoked.IsGuidePlaying(  );
                        LuaAPI.lua_pushboolean(L, __cl_gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_IsSysOpenPlaying(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            xc.GuideManager __cl_gen_to_be_invoked = (xc.GuideManager)translator.FastGetCSObj(L, 1);
            
            
            try {
                
                {
                    
                        bool __cl_gen_ret = __cl_gen_to_be_invoked.IsSysOpenPlaying(  );
                        LuaAPI.lua_pushboolean(L, __cl_gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_GetPlayingGuides(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            xc.GuideManager __cl_gen_to_be_invoked = (xc.GuideManager)translator.FastGetCSObj(L, 1);
            
            
            try {
                
                {
                    
                        System.Collections.Generic.List<uint> __cl_gen_ret = __cl_gen_to_be_invoked.GetPlayingGuides(  );
                        translator.Push(L, __cl_gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_Update(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            xc.GuideManager __cl_gen_to_be_invoked = (xc.GuideManager)translator.FastGetCSObj(L, 1);
            
            
            try {
                
                {
                    
                    __cl_gen_to_be_invoked.Update(  );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_IsGuideFinish(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            xc.GuideManager __cl_gen_to_be_invoked = (xc.GuideManager)translator.FastGetCSObj(L, 1);
            
            
            try {
                
                {
                    uint guide_id = LuaAPI.xlua_touint(L, 2);
                    
                        bool __cl_gen_ret = __cl_gen_to_be_invoked.IsGuideFinish( guide_id );
                        LuaAPI.lua_pushboolean(L, __cl_gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        
        
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_IsPause(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.GuideManager __cl_gen_to_be_invoked = (xc.GuideManager)translator.FastGetCSObj(L, 1);
                LuaAPI.lua_pushboolean(L, __cl_gen_to_be_invoked.IsPause);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_TestGuide(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.GuideManager __cl_gen_to_be_invoked = (xc.GuideManager)translator.FastGetCSObj(L, 1);
                LuaAPI.lua_pushboolean(L, __cl_gen_to_be_invoked.TestGuide);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_ListeningStepDict(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.GuideManager __cl_gen_to_be_invoked = (xc.GuideManager)translator.FastGetCSObj(L, 1);
                translator.Push(L, __cl_gen_to_be_invoked.ListeningStepDict);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_ForceStartStepDict(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.GuideManager __cl_gen_to_be_invoked = (xc.GuideManager)translator.FastGetCSObj(L, 1);
                translator.Push(L, __cl_gen_to_be_invoked.ForceStartStepDict);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_IgnoreRaycastGameObjects(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.GuideManager __cl_gen_to_be_invoked = (xc.GuideManager)translator.FastGetCSObj(L, 1);
                translator.Push(L, __cl_gen_to_be_invoked.IgnoreRaycastGameObjects);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_IsPlayingGuideStep(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.GuideManager __cl_gen_to_be_invoked = (xc.GuideManager)translator.FastGetCSObj(L, 1);
                LuaAPI.lua_pushboolean(L, __cl_gen_to_be_invoked.IsPlayingGuideStep);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_PlayingGuideStep(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.GuideManager __cl_gen_to_be_invoked = (xc.GuideManager)translator.FastGetCSObj(L, 1);
                translator.Push(L, __cl_gen_to_be_invoked.PlayingGuideStep);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_IsPlayingForcibleStep(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.GuideManager __cl_gen_to_be_invoked = (xc.GuideManager)translator.FastGetCSObj(L, 1);
                LuaAPI.lua_pushboolean(L, __cl_gen_to_be_invoked.IsPlayingForcibleStep);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_OnTouched(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.GuideManager __cl_gen_to_be_invoked = (xc.GuideManager)translator.FastGetCSObj(L, 1);
                translator.Push(L, __cl_gen_to_be_invoked.OnTouched);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_TestGuide(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.GuideManager __cl_gen_to_be_invoked = (xc.GuideManager)translator.FastGetCSObj(L, 1);
                __cl_gen_to_be_invoked.TestGuide = LuaAPI.lua_toboolean(L, 2);
            
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_OnTouched(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.GuideManager __cl_gen_to_be_invoked = (xc.GuideManager)translator.FastGetCSObj(L, 1);
                __cl_gen_to_be_invoked.OnTouched = translator.GetDelegate<xc.GuideManager.OnTouchedDelegate>(L, 2);
            
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 0;
        }
        
		
		
		
		
    }
}
