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
    public class xcRockCommandSystemWrap
    {
        public static void __Register(RealStatePtr L)
        {
			ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			XUtils.BeginObjectRegister(typeof(xc.RockCommandSystem), L, translator, 0, 12, 3, 2);
			
			XUtils.RegisterFunc(L, XUtils.METHOD_IDX, "IsLearnedSkill", _m_IsLearnedSkill);
			XUtils.RegisterFunc(L, XUtils.METHOD_IDX, "Reset", _m_Reset);
			XUtils.RegisterFunc(L, XUtils.METHOD_IDX, "GetOneSkillsUsing", _m_GetOneSkillsUsing);
			XUtils.RegisterFunc(L, XUtils.METHOD_IDX, "GetOneSkillsInfo", _m_GetOneSkillsInfo);
			XUtils.RegisterFunc(L, XUtils.METHOD_IDX, "DeleteOneSkill", _m_DeleteOneSkill);
			XUtils.RegisterFunc(L, XUtils.METHOD_IDX, "GetSetTotalSkillId_bySkillPos", _m_GetSetTotalSkillId_bySkillPos);
			XUtils.RegisterFunc(L, XUtils.METHOD_IDX, "AddSkillList", _m_AddSkillList);
			XUtils.RegisterFunc(L, XUtils.METHOD_IDX, "IsNewLearnSkill", _m_IsNewLearnSkill);
			XUtils.RegisterFunc(L, XUtils.METHOD_IDX, "RemoveFromNewLearnSkillList", _m_RemoveFromNewLearnSkillList);
			XUtils.RegisterFunc(L, XUtils.METHOD_IDX, "RefreshSkillLevel", _m_RefreshSkillLevel);
			XUtils.RegisterFunc(L, XUtils.METHOD_IDX, "IsInReplaceIds", _m_IsInReplaceIds);
			XUtils.RegisterFunc(L, XUtils.METHOD_IDX, "GetLastestSkillId", _m_GetLastestSkillId);
			
			
			XUtils.RegisterFunc(L, XUtils.GETTER_IDX, "DataSkillsUsingArray", _g_get_DataSkillsUsingArray);
            XUtils.RegisterFunc(L, XUtils.GETTER_IDX, "DataSkillsInfoArray", _g_get_DataSkillsInfoArray);
            XUtils.RegisterFunc(L, XUtils.GETTER_IDX, "Enable", _g_get_Enable);
            
			XUtils.RegisterFunc(L, XUtils.SETTER_IDX, "DataSkillsUsingArray", _s_set_DataSkillsUsingArray);
            XUtils.RegisterFunc(L, XUtils.SETTER_IDX, "Enable", _s_set_Enable);
            
			XUtils.EndObjectRegister(typeof(xc.RockCommandSystem), L, translator, null, null,
			    null, null, null);

		    XUtils.BeginClassRegister(typeof(xc.RockCommandSystem), L, __CreateInstance, 1, 0, 0);
			
			
            
            XUtils.RegisterObject(L, translator, XUtils.CLS_IDX, "UnderlyingSystemType", typeof(xc.RockCommandSystem));
			
			
			XUtils.EndClassRegister(typeof(xc.RockCommandSystem), L, translator);
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int __CreateInstance(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			try {
				if(LuaAPI.lua_gettop(L) == 1)
				{
					
					xc.RockCommandSystem __cl_gen_ret = new xc.RockCommandSystem();
					translator.Push(L, __cl_gen_ret);
					return 1;
				}
				
			}
			catch(System.Exception __gen_e) {
				return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
			}
            return LuaAPI.luaL_error(L, "invalid arguments to xc.RockCommandSystem constructor!");
            
        }
        
		
        
		
        
        
        
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_IsLearnedSkill(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            xc.RockCommandSystem __cl_gen_to_be_invoked = (xc.RockCommandSystem)translator.FastGetCSObj(L, 1);
            
            
            try {
                
                {
                    uint skill_total_id = LuaAPI.xlua_touint(L, 2);
                    
                        bool __cl_gen_ret = __cl_gen_to_be_invoked.IsLearnedSkill( skill_total_id );
                        LuaAPI.lua_pushboolean(L, __cl_gen_ret);
                    
                    
                    
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
            
            
            xc.RockCommandSystem __cl_gen_to_be_invoked = (xc.RockCommandSystem)translator.FastGetCSObj(L, 1);
            
            
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
        static int _m_GetOneSkillsUsing(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            xc.RockCommandSystem __cl_gen_to_be_invoked = (xc.RockCommandSystem)translator.FastGetCSObj(L, 1);
            
            
            try {
                
                {
                    uint id = LuaAPI.xlua_touint(L, 2);
                    
                        Net.PkgSkillsPos __cl_gen_ret = __cl_gen_to_be_invoked.GetOneSkillsUsing( id );
                        translator.Push(L, __cl_gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_GetOneSkillsInfo(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            xc.RockCommandSystem __cl_gen_to_be_invoked = (xc.RockCommandSystem)translator.FastGetCSObj(L, 1);
            
            
            try {
                
                {
                    uint id = LuaAPI.xlua_touint(L, 2);
                    
                        Net.PkgSkillsOne __cl_gen_ret = __cl_gen_to_be_invoked.GetOneSkillsInfo( id );
                        translator.Push(L, __cl_gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_DeleteOneSkill(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            xc.RockCommandSystem __cl_gen_to_be_invoked = (xc.RockCommandSystem)translator.FastGetCSObj(L, 1);
            
            
            try {
                
                {
                    uint skill_id = LuaAPI.xlua_touint(L, 2);
                    
                    __cl_gen_to_be_invoked.DeleteOneSkill( skill_id );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_GetSetTotalSkillId_bySkillPos(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            xc.RockCommandSystem __cl_gen_to_be_invoked = (xc.RockCommandSystem)translator.FastGetCSObj(L, 1);
            
            
            try {
                
                {
                    uint pos = LuaAPI.xlua_touint(L, 2);
                    
                        uint __cl_gen_ret = __cl_gen_to_be_invoked.GetSetTotalSkillId_bySkillPos( pos );
                        LuaAPI.xlua_pushuint(L, __cl_gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_AddSkillList(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            xc.RockCommandSystem __cl_gen_to_be_invoked = (xc.RockCommandSystem)translator.FastGetCSObj(L, 1);
            
            
            try {
                
                {
                    System.Collections.Generic.List<Net.PkgSkillsOne> add_skills = (System.Collections.Generic.List<Net.PkgSkillsOne>)translator.GetObject(L, 2, typeof(System.Collections.Generic.List<Net.PkgSkillsOne>));
                    
                    __cl_gen_to_be_invoked.AddSkillList( add_skills );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_IsNewLearnSkill(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            xc.RockCommandSystem __cl_gen_to_be_invoked = (xc.RockCommandSystem)translator.FastGetCSObj(L, 1);
            
            
            try {
                
                {
                    uint skill_total_id = LuaAPI.xlua_touint(L, 2);
                    
                        bool __cl_gen_ret = __cl_gen_to_be_invoked.IsNewLearnSkill( skill_total_id );
                        LuaAPI.lua_pushboolean(L, __cl_gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_RemoveFromNewLearnSkillList(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            xc.RockCommandSystem __cl_gen_to_be_invoked = (xc.RockCommandSystem)translator.FastGetCSObj(L, 1);
            
            
            try {
                
                {
                    uint skill_total_id = LuaAPI.xlua_touint(L, 2);
                    
                    __cl_gen_to_be_invoked.RemoveFromNewLearnSkillList( skill_total_id );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_RefreshSkillLevel(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            xc.RockCommandSystem __cl_gen_to_be_invoked = (xc.RockCommandSystem)translator.FastGetCSObj(L, 1);
            
            
            try {
                
                {
                    
                    __cl_gen_to_be_invoked.RefreshSkillLevel(  );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_IsInReplaceIds(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            xc.RockCommandSystem __cl_gen_to_be_invoked = (xc.RockCommandSystem)translator.FastGetCSObj(L, 1);
            
            
            try {
                
                {
                    uint all_skill_id = LuaAPI.xlua_touint(L, 2);
                    
                        bool __cl_gen_ret = __cl_gen_to_be_invoked.IsInReplaceIds( all_skill_id );
                        LuaAPI.lua_pushboolean(L, __cl_gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_GetLastestSkillId(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            xc.RockCommandSystem __cl_gen_to_be_invoked = (xc.RockCommandSystem)translator.FastGetCSObj(L, 1);
            
            
            try {
                
                {
                    uint all_skill_id = LuaAPI.xlua_touint(L, 2);
                    
                        uint __cl_gen_ret = __cl_gen_to_be_invoked.GetLastestSkillId( all_skill_id );
                        LuaAPI.xlua_pushuint(L, __cl_gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        
        
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_DataSkillsUsingArray(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.RockCommandSystem __cl_gen_to_be_invoked = (xc.RockCommandSystem)translator.FastGetCSObj(L, 1);
                translator.Push(L, __cl_gen_to_be_invoked.DataSkillsUsingArray);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_DataSkillsInfoArray(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.RockCommandSystem __cl_gen_to_be_invoked = (xc.RockCommandSystem)translator.FastGetCSObj(L, 1);
                translator.Push(L, __cl_gen_to_be_invoked.DataSkillsInfoArray);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_Enable(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.RockCommandSystem __cl_gen_to_be_invoked = (xc.RockCommandSystem)translator.FastGetCSObj(L, 1);
                LuaAPI.lua_pushboolean(L, __cl_gen_to_be_invoked.Enable);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_DataSkillsUsingArray(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.RockCommandSystem __cl_gen_to_be_invoked = (xc.RockCommandSystem)translator.FastGetCSObj(L, 1);
                __cl_gen_to_be_invoked.DataSkillsUsingArray = (System.Collections.Generic.List<Net.PkgSkillsPos>)translator.GetObject(L, 2, typeof(System.Collections.Generic.List<Net.PkgSkillsPos>));
            
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_Enable(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.RockCommandSystem __cl_gen_to_be_invoked = (xc.RockCommandSystem)translator.FastGetCSObj(L, 1);
                __cl_gen_to_be_invoked.Enable = LuaAPI.lua_toboolean(L, 2);
            
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 0;
        }
        
		
		
		
		
    }
}
