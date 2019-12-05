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
    public class xcTaskWrap
    {
        public static void __Register(RealStatePtr L)
        {
			ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			XUtils.BeginObjectRegister(typeof(xc.Task), L, translator, 0, 6, 14, 6);
			
			XUtils.RegisterFunc(L, XUtils.METHOD_IDX, "CompareTo", _m_CompareTo);
			XUtils.RegisterFunc(L, XUtils.METHOD_IDX, "GetStepProgressValue", _m_GetStepProgressValue);
			XUtils.RegisterFunc(L, XUtils.METHOD_IDX, "GetStepProgress", _m_GetStepProgress);
			XUtils.RegisterFunc(L, XUtils.METHOD_IDX, "Update", _m_Update);
			XUtils.RegisterFunc(L, XUtils.METHOD_IDX, "GetStepFixedDescription", _m_GetStepFixedDescription);
			XUtils.RegisterFunc(L, XUtils.METHOD_IDX, "ToString", _m_ToString);
			
			
			XUtils.RegisterFunc(L, XUtils.GETTER_IDX, "Define", _g_get_Define);
            XUtils.RegisterFunc(L, XUtils.GETTER_IDX, "CurrentGoal", _g_get_CurrentGoal);
            XUtils.RegisterFunc(L, XUtils.GETTER_IDX, "CurrentStepFixedDescription", _g_get_CurrentStepFixedDescription);
            XUtils.RegisterFunc(L, XUtils.GETTER_IDX, "CurrentStepIndex", _g_get_CurrentStepIndex);
            XUtils.RegisterFunc(L, XUtils.GETTER_IDX, "CurrentStep", _g_get_CurrentStep);
            XUtils.RegisterFunc(L, XUtils.GETTER_IDX, "FirstStep", _g_get_FirstStep);
            XUtils.RegisterFunc(L, XUtils.GETTER_IDX, "NextStep", _g_get_NextStep);
            XUtils.RegisterFunc(L, XUtils.GETTER_IDX, "CurrentStepProgress", _g_get_CurrentStepProgress);
            XUtils.RegisterFunc(L, XUtils.GETTER_IDX, "NextStepProgress", _g_get_NextStepProgress);
            XUtils.RegisterFunc(L, XUtils.GETTER_IDX, "State", _g_get_State);
            XUtils.RegisterFunc(L, XUtils.GETTER_IDX, "StepProgresss", _g_get_StepProgresss);
            XUtils.RegisterFunc(L, XUtils.GETTER_IDX, "StartTime", _g_get_StartTime);
            XUtils.RegisterFunc(L, XUtils.GETTER_IDX, "DynamicShowPriority", _g_get_DynamicShowPriority);
            XUtils.RegisterFunc(L, XUtils.GETTER_IDX, "IsOnTop", _g_get_IsOnTop);
            
			XUtils.RegisterFunc(L, XUtils.SETTER_IDX, "CurrentStepIndex", _s_set_CurrentStepIndex);
            XUtils.RegisterFunc(L, XUtils.SETTER_IDX, "State", _s_set_State);
            XUtils.RegisterFunc(L, XUtils.SETTER_IDX, "StepProgresss", _s_set_StepProgresss);
            XUtils.RegisterFunc(L, XUtils.SETTER_IDX, "StartTime", _s_set_StartTime);
            XUtils.RegisterFunc(L, XUtils.SETTER_IDX, "DynamicShowPriority", _s_set_DynamicShowPriority);
            XUtils.RegisterFunc(L, XUtils.SETTER_IDX, "IsOnTop", _s_set_IsOnTop);
            
			XUtils.EndObjectRegister(typeof(xc.Task), L, translator, null, null,
			    null, null, null);

		    XUtils.BeginClassRegister(typeof(xc.Task), L, __CreateInstance, 2, 1, 1);
			XUtils.RegisterFunc(L, XUtils.CLS_IDX, "IncreaseCurDynamicShowPriority", _m_IncreaseCurDynamicShowPriority_xlua_st_);
            
			
            
            XUtils.RegisterObject(L, translator, XUtils.CLS_IDX, "UnderlyingSystemType", typeof(xc.Task));
			XUtils.RegisterFunc(L, XUtils.CLS_GETTER_IDX, "CurDynamicShowPriority", _g_get_CurDynamicShowPriority);
            
			XUtils.RegisterFunc(L, XUtils.CLS_SETTER_IDX, "CurDynamicShowPriority", _s_set_CurDynamicShowPriority);
            
			XUtils.EndClassRegister(typeof(xc.Task), L, translator);
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int __CreateInstance(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			try {
				if(LuaAPI.lua_gettop(L) == 2 && translator.Assignable<xc.TaskDefine>(L, 2))
				{
					xc.TaskDefine task = (xc.TaskDefine)translator.GetObject(L, 2, typeof(xc.TaskDefine));
					
					xc.Task __cl_gen_ret = new xc.Task(task);
					translator.Push(L, __cl_gen_ret);
					return 1;
				}
				
			}
			catch(System.Exception __gen_e) {
				return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
			}
            return LuaAPI.luaL_error(L, "invalid arguments to xc.Task constructor!");
            
        }
        
		
        
		
        
        
        
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_CompareTo(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            xc.Task __cl_gen_to_be_invoked = (xc.Task)translator.FastGetCSObj(L, 1);
            
            
            try {
                
                {
                    object targetObj = translator.GetObject(L, 2, typeof(object));
                    
                        int __cl_gen_ret = __cl_gen_to_be_invoked.CompareTo( targetObj );
                        LuaAPI.xlua_pushinteger(L, __cl_gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_IncreaseCurDynamicShowPriority_xlua_st_(RealStatePtr L)
        {
            
            
            
            try {
                
                {
                    
                    xc.Task.IncreaseCurDynamicShowPriority(  );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_GetStepProgressValue(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            xc.Task __cl_gen_to_be_invoked = (xc.Task)translator.FastGetCSObj(L, 1);
            
            
            try {
                
                {
                    int stepIndex = LuaAPI.xlua_tointeger(L, 2);
                    
                        uint __cl_gen_ret = __cl_gen_to_be_invoked.GetStepProgressValue( stepIndex );
                        LuaAPI.xlua_pushuint(L, __cl_gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_GetStepProgress(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            xc.Task __cl_gen_to_be_invoked = (xc.Task)translator.FastGetCSObj(L, 1);
            
            
            try {
                
                {
                    int stepIndex = LuaAPI.xlua_tointeger(L, 2);
                    
                        xc.Task.StepProgress __cl_gen_ret = __cl_gen_to_be_invoked.GetStepProgress( stepIndex );
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
            
            
            xc.Task __cl_gen_to_be_invoked = (xc.Task)translator.FastGetCSObj(L, 1);
            
            
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
        static int _m_GetStepFixedDescription(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            xc.Task __cl_gen_to_be_invoked = (xc.Task)translator.FastGetCSObj(L, 1);
            
            
            try {
                
                {
                    int stepIndex = LuaAPI.xlua_tointeger(L, 2);
                    
                        string __cl_gen_ret = __cl_gen_to_be_invoked.GetStepFixedDescription( stepIndex );
                        LuaAPI.lua_pushstring(L, __cl_gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_ToString(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            xc.Task __cl_gen_to_be_invoked = (xc.Task)translator.FastGetCSObj(L, 1);
            
            
            try {
                
                {
                    
                        string __cl_gen_ret = __cl_gen_to_be_invoked.ToString(  );
                        LuaAPI.lua_pushstring(L, __cl_gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        
        
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_Define(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.Task __cl_gen_to_be_invoked = (xc.Task)translator.FastGetCSObj(L, 1);
                translator.Push(L, __cl_gen_to_be_invoked.Define);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_CurrentGoal(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.Task __cl_gen_to_be_invoked = (xc.Task)translator.FastGetCSObj(L, 1);
                LuaAPI.lua_pushstring(L, __cl_gen_to_be_invoked.CurrentGoal);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_CurrentStepFixedDescription(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.Task __cl_gen_to_be_invoked = (xc.Task)translator.FastGetCSObj(L, 1);
                LuaAPI.lua_pushstring(L, __cl_gen_to_be_invoked.CurrentStepFixedDescription);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_CurrentStepIndex(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.Task __cl_gen_to_be_invoked = (xc.Task)translator.FastGetCSObj(L, 1);
                LuaAPI.xlua_pushuint(L, __cl_gen_to_be_invoked.CurrentStepIndex);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_CurrentStep(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.Task __cl_gen_to_be_invoked = (xc.Task)translator.FastGetCSObj(L, 1);
                translator.Push(L, __cl_gen_to_be_invoked.CurrentStep);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_FirstStep(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.Task __cl_gen_to_be_invoked = (xc.Task)translator.FastGetCSObj(L, 1);
                translator.Push(L, __cl_gen_to_be_invoked.FirstStep);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_NextStep(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.Task __cl_gen_to_be_invoked = (xc.Task)translator.FastGetCSObj(L, 1);
                translator.Push(L, __cl_gen_to_be_invoked.NextStep);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_CurrentStepProgress(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.Task __cl_gen_to_be_invoked = (xc.Task)translator.FastGetCSObj(L, 1);
                translator.Push(L, __cl_gen_to_be_invoked.CurrentStepProgress);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_NextStepProgress(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.Task __cl_gen_to_be_invoked = (xc.Task)translator.FastGetCSObj(L, 1);
                translator.Push(L, __cl_gen_to_be_invoked.NextStepProgress);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_State(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.Task __cl_gen_to_be_invoked = (xc.Task)translator.FastGetCSObj(L, 1);
                LuaAPI.xlua_pushuint(L, __cl_gen_to_be_invoked.State);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_StepProgresss(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.Task __cl_gen_to_be_invoked = (xc.Task)translator.FastGetCSObj(L, 1);
                translator.Push(L, __cl_gen_to_be_invoked.StepProgresss);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_StartTime(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.Task __cl_gen_to_be_invoked = (xc.Task)translator.FastGetCSObj(L, 1);
                LuaAPI.xlua_pushuint(L, __cl_gen_to_be_invoked.StartTime);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_CurDynamicShowPriority(RealStatePtr L)
        {
            
            try {
			    LuaAPI.xlua_pushinteger(L, xc.Task.CurDynamicShowPriority);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_DynamicShowPriority(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.Task __cl_gen_to_be_invoked = (xc.Task)translator.FastGetCSObj(L, 1);
                LuaAPI.xlua_pushinteger(L, __cl_gen_to_be_invoked.DynamicShowPriority);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_IsOnTop(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.Task __cl_gen_to_be_invoked = (xc.Task)translator.FastGetCSObj(L, 1);
                LuaAPI.lua_pushboolean(L, __cl_gen_to_be_invoked.IsOnTop);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_CurrentStepIndex(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.Task __cl_gen_to_be_invoked = (xc.Task)translator.FastGetCSObj(L, 1);
                __cl_gen_to_be_invoked.CurrentStepIndex = LuaAPI.xlua_touint(L, 2);
            
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_State(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.Task __cl_gen_to_be_invoked = (xc.Task)translator.FastGetCSObj(L, 1);
                __cl_gen_to_be_invoked.State = LuaAPI.xlua_touint(L, 2);
            
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_StepProgresss(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.Task __cl_gen_to_be_invoked = (xc.Task)translator.FastGetCSObj(L, 1);
                __cl_gen_to_be_invoked.StepProgresss = (System.Collections.Generic.List<xc.Task.StepProgress>)translator.GetObject(L, 2, typeof(System.Collections.Generic.List<xc.Task.StepProgress>));
            
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_StartTime(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.Task __cl_gen_to_be_invoked = (xc.Task)translator.FastGetCSObj(L, 1);
                __cl_gen_to_be_invoked.StartTime = LuaAPI.xlua_touint(L, 2);
            
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_CurDynamicShowPriority(RealStatePtr L)
        {
            
            try {
			    xc.Task.CurDynamicShowPriority = LuaAPI.xlua_tointeger(L, 1);
            
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_DynamicShowPriority(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.Task __cl_gen_to_be_invoked = (xc.Task)translator.FastGetCSObj(L, 1);
                __cl_gen_to_be_invoked.DynamicShowPriority = LuaAPI.xlua_tointeger(L, 2);
            
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_IsOnTop(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.Task __cl_gen_to_be_invoked = (xc.Task)translator.FastGetCSObj(L, 1);
                __cl_gen_to_be_invoked.IsOnTop = LuaAPI.lua_toboolean(L, 2);
            
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 0;
        }
        
		
		
		
		
    }
}
