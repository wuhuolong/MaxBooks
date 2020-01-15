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
    public class xcSkillHoleManagerWrap
    {
        public static void __Register(RealStatePtr L)
        {
			ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			XUtils.BeginObjectRegister(typeof(xc.SkillHoleManager), L, translator, 0, 13, 1, 0);
			
			XUtils.RegisterFunc(L, XUtils.METHOD_IDX, "Reset", _m_Reset);
			XUtils.RegisterFunc(L, XUtils.METHOD_IDX, "OpenSkill", _m_OpenSkill);
			XUtils.RegisterFunc(L, XUtils.METHOD_IDX, "OpenNewSkill", _m_OpenNewSkill);
			XUtils.RegisterFunc(L, XUtils.METHOD_IDX, "OpenNewHoleFinish", _m_OpenNewHoleFinish);
			XUtils.RegisterFunc(L, XUtils.METHOD_IDX, "ClearSkill", _m_ClearSkill);
			XUtils.RegisterFunc(L, XUtils.METHOD_IDX, "DeleteSkill", _m_DeleteSkill);
			XUtils.RegisterFunc(L, XUtils.METHOD_IDX, "GetSkillHolePosition", _m_GetSkillHolePosition);
			XUtils.RegisterFunc(L, XUtils.METHOD_IDX, "GetScaleToSkillHole", _m_GetScaleToSkillHole);
			XUtils.RegisterFunc(L, XUtils.METHOD_IDX, "IsHoleOpen", _m_IsHoleOpen);
			XUtils.RegisterFunc(L, XUtils.METHOD_IDX, "IsHoleWillOpen", _m_IsHoleWillOpen);
			XUtils.RegisterFunc(L, XUtils.METHOD_IDX, "GetOpenSkillHole", _m_GetOpenSkillHole);
			XUtils.RegisterFunc(L, XUtils.METHOD_IDX, "GetNextWillOpenSkillHole", _m_GetNextWillOpenSkillHole);
			XUtils.RegisterFunc(L, XUtils.METHOD_IDX, "GetWillOpenSkillId", _m_GetWillOpenSkillId);
			
			
			XUtils.RegisterFunc(L, XUtils.GETTER_IDX, "WillOpenSkillHoles", _g_get_WillOpenSkillHoles);
            
			
			XUtils.EndObjectRegister(typeof(xc.SkillHoleManager), L, translator, null, null,
			    null, null, null);

		    XUtils.BeginClassRegister(typeof(xc.SkillHoleManager), L, __CreateInstance, 1, 1, 1);
			
			
            
            XUtils.RegisterObject(L, translator, XUtils.CLS_IDX, "UnderlyingSystemType", typeof(xc.SkillHoleManager));
			XUtils.RegisterFunc(L, XUtils.CLS_GETTER_IDX, "ForceOpenHole", _g_get_ForceOpenHole);
            
			XUtils.RegisterFunc(L, XUtils.CLS_SETTER_IDX, "ForceOpenHole", _s_set_ForceOpenHole);
            
			XUtils.EndClassRegister(typeof(xc.SkillHoleManager), L, translator);
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int __CreateInstance(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			try {
				if(LuaAPI.lua_gettop(L) == 1)
				{
					
					xc.SkillHoleManager __cl_gen_ret = new xc.SkillHoleManager();
					translator.Push(L, __cl_gen_ret);
					return 1;
				}
				
			}
			catch(System.Exception __gen_e) {
				return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
			}
            return LuaAPI.luaL_error(L, "invalid arguments to xc.SkillHoleManager constructor!");
            
        }
        
		
        
		
        
        
        
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_Reset(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            xc.SkillHoleManager __cl_gen_to_be_invoked = (xc.SkillHoleManager)translator.FastGetCSObj(L, 1);
            
            
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
        static int _m_OpenSkill(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            xc.SkillHoleManager __cl_gen_to_be_invoked = (xc.SkillHoleManager)translator.FastGetCSObj(L, 1);
            
            
            try {
                
                {
                    uint skill_id = LuaAPI.xlua_touint(L, 2);
                    
                    __cl_gen_to_be_invoked.OpenSkill( skill_id );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_OpenNewSkill(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            xc.SkillHoleManager __cl_gen_to_be_invoked = (xc.SkillHoleManager)translator.FastGetCSObj(L, 1);
            
            
            try {
                
                {
                    uint skill_id = LuaAPI.xlua_touint(L, 2);
                    
                    __cl_gen_to_be_invoked.OpenNewSkill( skill_id );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_OpenNewHoleFinish(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            xc.SkillHoleManager __cl_gen_to_be_invoked = (xc.SkillHoleManager)translator.FastGetCSObj(L, 1);
            
            
            try {
                
                {
                    uint skill_id = LuaAPI.xlua_touint(L, 2);
                    
                    __cl_gen_to_be_invoked.OpenNewHoleFinish( skill_id );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_ClearSkill(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            xc.SkillHoleManager __cl_gen_to_be_invoked = (xc.SkillHoleManager)translator.FastGetCSObj(L, 1);
            
            
            try {
                
                {
                    uint skill_id = LuaAPI.xlua_touint(L, 2);
                    
                    __cl_gen_to_be_invoked.ClearSkill( skill_id );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_DeleteSkill(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            xc.SkillHoleManager __cl_gen_to_be_invoked = (xc.SkillHoleManager)translator.FastGetCSObj(L, 1);
            
            
            try {
                
                {
                    uint skill_id = LuaAPI.xlua_touint(L, 2);
                    
                    __cl_gen_to_be_invoked.DeleteSkill( skill_id );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_GetSkillHolePosition(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            xc.SkillHoleManager __cl_gen_to_be_invoked = (xc.SkillHoleManager)translator.FastGetCSObj(L, 1);
            
            
            try {
                
                {
                    uint skill_id = LuaAPI.xlua_touint(L, 2);
                    
                        UnityEngine.Vector3 __cl_gen_ret = __cl_gen_to_be_invoked.GetSkillHolePosition( skill_id );
                        translator.PushUnityEngineVector3(L, __cl_gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_GetScaleToSkillHole(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            xc.SkillHoleManager __cl_gen_to_be_invoked = (xc.SkillHoleManager)translator.FastGetCSObj(L, 1);
            
            
            try {
                
                {
                    uint skill_id = LuaAPI.xlua_touint(L, 2);
                    UnityEngine.GameObject widget = (UnityEngine.GameObject)translator.GetObject(L, 3, typeof(UnityEngine.GameObject));
                    
                        float __cl_gen_ret = __cl_gen_to_be_invoked.GetScaleToSkillHole( skill_id, widget );
                        LuaAPI.lua_pushnumber(L, __cl_gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_IsHoleOpen(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            xc.SkillHoleManager __cl_gen_to_be_invoked = (xc.SkillHoleManager)translator.FastGetCSObj(L, 1);
            
            
            try {
                
                {
                    uint skil_hole = LuaAPI.xlua_touint(L, 2);
                    
                        bool __cl_gen_ret = __cl_gen_to_be_invoked.IsHoleOpen( skil_hole );
                        LuaAPI.lua_pushboolean(L, __cl_gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_IsHoleWillOpen(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            xc.SkillHoleManager __cl_gen_to_be_invoked = (xc.SkillHoleManager)translator.FastGetCSObj(L, 1);
            
            
            try {
                
                {
                    uint skill_hole = LuaAPI.xlua_touint(L, 2);
                    
                        bool __cl_gen_ret = __cl_gen_to_be_invoked.IsHoleWillOpen( skill_hole );
                        LuaAPI.lua_pushboolean(L, __cl_gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_GetOpenSkillHole(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            xc.SkillHoleManager __cl_gen_to_be_invoked = (xc.SkillHoleManager)translator.FastGetCSObj(L, 1);
            
            
            try {
                
                {
                    uint skill_id = LuaAPI.xlua_touint(L, 2);
                    
                        uint __cl_gen_ret = __cl_gen_to_be_invoked.GetOpenSkillHole( skill_id );
                        LuaAPI.xlua_pushuint(L, __cl_gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_GetNextWillOpenSkillHole(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            xc.SkillHoleManager __cl_gen_to_be_invoked = (xc.SkillHoleManager)translator.FastGetCSObj(L, 1);
            
            
            try {
                
                {
                    
                        uint __cl_gen_ret = __cl_gen_to_be_invoked.GetNextWillOpenSkillHole(  );
                        LuaAPI.xlua_pushuint(L, __cl_gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_GetWillOpenSkillId(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            xc.SkillHoleManager __cl_gen_to_be_invoked = (xc.SkillHoleManager)translator.FastGetCSObj(L, 1);
            
            
            try {
                
                {
                    uint hole_id = LuaAPI.xlua_touint(L, 2);
                    
                        uint __cl_gen_ret = __cl_gen_to_be_invoked.GetWillOpenSkillId( hole_id );
                        LuaAPI.xlua_pushuint(L, __cl_gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        
        
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_WillOpenSkillHoles(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.SkillHoleManager __cl_gen_to_be_invoked = (xc.SkillHoleManager)translator.FastGetCSObj(L, 1);
                translator.Push(L, __cl_gen_to_be_invoked.WillOpenSkillHoles);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_ForceOpenHole(RealStatePtr L)
        {
            
            try {
			    LuaAPI.xlua_pushuint(L, xc.SkillHoleManager.ForceOpenHole);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_ForceOpenHole(RealStatePtr L)
        {
            
            try {
			    xc.SkillHoleManager.ForceOpenHole = LuaAPI.xlua_touint(L, 1);
            
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 0;
        }
        
		
		
		
		
    }
}
