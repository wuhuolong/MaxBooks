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
    public class xcSkillManagerWrap
    {
        public static void __Register(RealStatePtr L)
        {
			ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			XUtils.BeginObjectRegister(typeof(xc.SkillManager), L, translator, 0, 15, 4, 1);
			
			XUtils.RegisterFunc(L, XUtils.METHOD_IDX, "RegisterAllMessage", _m_RegisterAllMessage);
			XUtils.RegisterFunc(L, XUtils.METHOD_IDX, "ResetLocalPlayerSkill", _m_ResetLocalPlayerSkill);
			XUtils.RegisterFunc(L, XUtils.METHOD_IDX, "InitSkillOwner", _m_InitSkillOwner);
			XUtils.RegisterFunc(L, XUtils.METHOD_IDX, "AddSelfSkill", _m_AddSelfSkill);
			XUtils.RegisterFunc(L, XUtils.METHOD_IDX, "IsMateSkill", _m_IsMateSkill);
			XUtils.RegisterFunc(L, XUtils.METHOD_IDX, "IsFurySkill", _m_IsFurySkill);
			XUtils.RegisterFunc(L, XUtils.METHOD_IDX, "IsMateSkillByActive", _m_IsMateSkillByActive);
			XUtils.RegisterFunc(L, XUtils.METHOD_IDX, "GetAvailableSkill", _m_GetAvailableSkill);
			XUtils.RegisterFunc(L, XUtils.METHOD_IDX, "GetLearnedSkill", _m_GetLearnedSkill);
			XUtils.RegisterFunc(L, XUtils.METHOD_IDX, "Reset", _m_Reset);
			XUtils.RegisterFunc(L, XUtils.METHOD_IDX, "SetOpeningSkill", _m_SetOpeningSkill);
			XUtils.RegisterFunc(L, XUtils.METHOD_IDX, "GetFitSkillId", _m_GetFitSkillId);
			XUtils.RegisterFunc(L, XUtils.METHOD_IDX, "GetNormalFitSkillId", _m_GetNormalFitSkillId);
			XUtils.RegisterFunc(L, XUtils.METHOD_IDX, "IsFitSkillId", _m_IsFitSkillId);
			XUtils.RegisterFunc(L, XUtils.METHOD_IDX, "GetLocalSkill", _m_GetLocalSkill);
			
			
			XUtils.RegisterFunc(L, XUtils.GETTER_IDX, "ShapeShifted", _g_get_ShapeShifted);
            XUtils.RegisterFunc(L, XUtils.GETTER_IDX, "UsingtSkillConfigIndex", _g_get_UsingtSkillConfigIndex);
            XUtils.RegisterFunc(L, XUtils.GETTER_IDX, "UsingSkillConfig", _g_get_UsingSkillConfig);
            XUtils.RegisterFunc(L, XUtils.GETTER_IDX, "NormalSkillConfig", _g_get_NormalSkillConfig);
            
			XUtils.RegisterFunc(L, XUtils.SETTER_IDX, "UsingtSkillConfigIndex", _s_set_UsingtSkillConfigIndex);
            
			XUtils.EndObjectRegister(typeof(xc.SkillManager), L, translator, null, null,
			    null, null, null);

		    XUtils.BeginClassRegister(typeof(xc.SkillManager), L, __CreateInstance, 1, 0, 0);
			
			
            
            XUtils.RegisterObject(L, translator, XUtils.CLS_IDX, "UnderlyingSystemType", typeof(xc.SkillManager));
			
			
			XUtils.EndClassRegister(typeof(xc.SkillManager), L, translator);
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int __CreateInstance(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			try {
				if(LuaAPI.lua_gettop(L) == 1)
				{
					
					xc.SkillManager __cl_gen_ret = new xc.SkillManager();
					translator.Push(L, __cl_gen_ret);
					return 1;
				}
				
			}
			catch(System.Exception __gen_e) {
				return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
			}
            return LuaAPI.luaL_error(L, "invalid arguments to xc.SkillManager constructor!");
            
        }
        
		
        
		
        
        
        
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_RegisterAllMessage(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            xc.SkillManager __cl_gen_to_be_invoked = (xc.SkillManager)translator.FastGetCSObj(L, 1);
            
            
            try {
                
                {
                    
                    __cl_gen_to_be_invoked.RegisterAllMessage(  );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_ResetLocalPlayerSkill(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            xc.SkillManager __cl_gen_to_be_invoked = (xc.SkillManager)translator.FastGetCSObj(L, 1);
            
            
            try {
                
                {
                    
                    __cl_gen_to_be_invoked.ResetLocalPlayerSkill(  );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_InitSkillOwner(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            xc.SkillManager __cl_gen_to_be_invoked = (xc.SkillManager)translator.FastGetCSObj(L, 1);
            
            
            try {
                
                {
                    LocalPlayer kActor = (LocalPlayer)translator.GetObject(L, 2, typeof(LocalPlayer));
                    
                    __cl_gen_to_be_invoked.InitSkillOwner( kActor );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_AddSelfSkill(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            xc.SkillManager __cl_gen_to_be_invoked = (xc.SkillManager)translator.FastGetCSObj(L, 1);
            
            
            try {
                
                {
                    uint uiID = LuaAPI.xlua_touint(L, 2);
                    
                        xc.Skill __cl_gen_ret = __cl_gen_to_be_invoked.AddSelfSkill( uiID );
                        translator.Push(L, __cl_gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_IsMateSkill(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            xc.SkillManager __cl_gen_to_be_invoked = (xc.SkillManager)translator.FastGetCSObj(L, 1);
            
            
            try {
                
                {
                    uint skill_id = LuaAPI.xlua_touint(L, 2);
                    
                        bool __cl_gen_ret = __cl_gen_to_be_invoked.IsMateSkill( skill_id );
                        LuaAPI.lua_pushboolean(L, __cl_gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_IsFurySkill(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            xc.SkillManager __cl_gen_to_be_invoked = (xc.SkillManager)translator.FastGetCSObj(L, 1);
            
            
            try {
                
                {
                    uint skill_id = LuaAPI.xlua_touint(L, 2);
                    
                        bool __cl_gen_ret = __cl_gen_to_be_invoked.IsFurySkill( skill_id );
                        LuaAPI.lua_pushboolean(L, __cl_gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_IsMateSkillByActive(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            xc.SkillManager __cl_gen_to_be_invoked = (xc.SkillManager)translator.FastGetCSObj(L, 1);
            
            
            try {
                
                {
                    uint skill_id = LuaAPI.xlua_touint(L, 2);
                    
                        bool __cl_gen_ret = __cl_gen_to_be_invoked.IsMateSkillByActive( skill_id );
                        LuaAPI.lua_pushboolean(L, __cl_gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_GetAvailableSkill(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            xc.SkillManager __cl_gen_to_be_invoked = (xc.SkillManager)translator.FastGetCSObj(L, 1);
            
            
            try {
                
                {
                    
                        uint __cl_gen_ret = __cl_gen_to_be_invoked.GetAvailableSkill(  );
                        LuaAPI.xlua_pushuint(L, __cl_gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_GetLearnedSkill(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            xc.SkillManager __cl_gen_to_be_invoked = (xc.SkillManager)translator.FastGetCSObj(L, 1);
            
            
            try {
                
                {
                    uint uiID = LuaAPI.xlua_touint(L, 2);
                    
                        xc.Skill __cl_gen_ret = __cl_gen_to_be_invoked.GetLearnedSkill( uiID );
                        translator.Push(L, __cl_gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_Reset(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            xc.SkillManager __cl_gen_to_be_invoked = (xc.SkillManager)translator.FastGetCSObj(L, 1);
            
            
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
        static int _m_SetOpeningSkill(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            xc.SkillManager __cl_gen_to_be_invoked = (xc.SkillManager)translator.FastGetCSObj(L, 1);
            
            
            try {
                
                {
                    xc.DBCommandList.OPFlag pos;translator.Get(L, 2, out pos);
                    uint skill_id = LuaAPI.xlua_touint(L, 3);
                    
                    __cl_gen_to_be_invoked.SetOpeningSkill( pos, skill_id );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_GetFitSkillId(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            xc.SkillManager __cl_gen_to_be_invoked = (xc.SkillManager)translator.FastGetCSObj(L, 1);
            
            
            try {
                
                {
                    uint skillPos = LuaAPI.xlua_touint(L, 2);
                    
                        uint __cl_gen_ret = __cl_gen_to_be_invoked.GetFitSkillId( skillPos );
                        LuaAPI.xlua_pushuint(L, __cl_gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_GetNormalFitSkillId(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            xc.SkillManager __cl_gen_to_be_invoked = (xc.SkillManager)translator.FastGetCSObj(L, 1);
            
            
            try {
                
                {
                    uint skillPos = LuaAPI.xlua_touint(L, 2);
                    
                        uint __cl_gen_ret = __cl_gen_to_be_invoked.GetNormalFitSkillId( skillPos );
                        LuaAPI.xlua_pushuint(L, __cl_gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_IsFitSkillId(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            xc.SkillManager __cl_gen_to_be_invoked = (xc.SkillManager)translator.FastGetCSObj(L, 1);
            
            
            try {
                
                {
                    uint active_skill_id = LuaAPI.xlua_touint(L, 2);
                    
                        bool __cl_gen_ret = __cl_gen_to_be_invoked.IsFitSkillId( active_skill_id );
                        LuaAPI.lua_pushboolean(L, __cl_gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_GetLocalSkill(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            xc.SkillManager __cl_gen_to_be_invoked = (xc.SkillManager)translator.FastGetCSObj(L, 1);
            
            
            try {
                
                {
                    
                        System.Collections.Generic.Dictionary<uint, xc.Skill>.ValueCollection __cl_gen_ret = __cl_gen_to_be_invoked.GetLocalSkill(  );
                        translator.Push(L, __cl_gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        
        
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_ShapeShifted(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.SkillManager __cl_gen_to_be_invoked = (xc.SkillManager)translator.FastGetCSObj(L, 1);
                LuaAPI.lua_pushboolean(L, __cl_gen_to_be_invoked.ShapeShifted);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_UsingtSkillConfigIndex(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.SkillManager __cl_gen_to_be_invoked = (xc.SkillManager)translator.FastGetCSObj(L, 1);
                LuaAPI.xlua_pushuint(L, __cl_gen_to_be_invoked.UsingtSkillConfigIndex);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_UsingSkillConfig(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.SkillManager __cl_gen_to_be_invoked = (xc.SkillManager)translator.FastGetCSObj(L, 1);
                translator.Push(L, __cl_gen_to_be_invoked.UsingSkillConfig);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_NormalSkillConfig(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.SkillManager __cl_gen_to_be_invoked = (xc.SkillManager)translator.FastGetCSObj(L, 1);
                translator.Push(L, __cl_gen_to_be_invoked.NormalSkillConfig);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_UsingtSkillConfigIndex(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.SkillManager __cl_gen_to_be_invoked = (xc.SkillManager)translator.FastGetCSObj(L, 1);
                __cl_gen_to_be_invoked.UsingtSkillConfigIndex = LuaAPI.xlua_touint(L, 2);
            
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 0;
        }
        
		
		
		
		
    }
}
