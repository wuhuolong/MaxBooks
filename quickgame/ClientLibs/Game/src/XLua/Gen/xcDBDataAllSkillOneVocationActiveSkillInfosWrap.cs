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
    public class xcDBDataAllSkillOneVocationActiveSkillInfosWrap
    {
        public static void __Register(RealStatePtr L)
        {
			ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			XUtils.BeginObjectRegister(typeof(xc.DBDataAllSkill.OneVocationActiveSkillInfos), L, translator, 0, 1, 2, 2);
			
			XUtils.RegisterFunc(L, XUtils.METHOD_IDX, "AddSkillInfo", _m_AddSkillInfo);
			
			
			XUtils.RegisterFunc(L, XUtils.GETTER_IDX, "mVocation", _g_get_mVocation);
            XUtils.RegisterFunc(L, XUtils.GETTER_IDX, "mSkills", _g_get_mSkills);
            
			XUtils.RegisterFunc(L, XUtils.SETTER_IDX, "mVocation", _s_set_mVocation);
            XUtils.RegisterFunc(L, XUtils.SETTER_IDX, "mSkills", _s_set_mSkills);
            
			XUtils.EndObjectRegister(typeof(xc.DBDataAllSkill.OneVocationActiveSkillInfos), L, translator, null, null,
			    null, null, null);

		    XUtils.BeginClassRegister(typeof(xc.DBDataAllSkill.OneVocationActiveSkillInfos), L, __CreateInstance, 1, 0, 0);
			
			
            
            XUtils.RegisterObject(L, translator, XUtils.CLS_IDX, "UnderlyingSystemType", typeof(xc.DBDataAllSkill.OneVocationActiveSkillInfos));
			
			
			XUtils.EndClassRegister(typeof(xc.DBDataAllSkill.OneVocationActiveSkillInfos), L, translator);
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int __CreateInstance(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			try {
				if(LuaAPI.lua_gettop(L) == 2 && LuaTypes.LUA_TNUMBER == LuaAPI.lua_type(L, 2))
				{
					uint init_vocation = LuaAPI.xlua_touint(L, 2);
					
					xc.DBDataAllSkill.OneVocationActiveSkillInfos __cl_gen_ret = new xc.DBDataAllSkill.OneVocationActiveSkillInfos(init_vocation);
					translator.Push(L, __cl_gen_ret);
					return 1;
				}
				
			}
			catch(System.Exception __gen_e) {
				return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
			}
            return LuaAPI.luaL_error(L, "invalid arguments to xc.DBDataAllSkill.OneVocationActiveSkillInfos constructor!");
            
        }
        
		
        
		
        
        
        
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_AddSkillInfo(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            xc.DBDataAllSkill.OneVocationActiveSkillInfos __cl_gen_to_be_invoked = (xc.DBDataAllSkill.OneVocationActiveSkillInfos)translator.FastGetCSObj(L, 1);
            
            
            try {
                
                {
                    xc.DBDataAllSkill.AllSkillInfo info = (xc.DBDataAllSkill.AllSkillInfo)translator.GetObject(L, 2, typeof(xc.DBDataAllSkill.AllSkillInfo));
                    
                    __cl_gen_to_be_invoked.AddSkillInfo( info );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        
        
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_mVocation(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.DBDataAllSkill.OneVocationActiveSkillInfos __cl_gen_to_be_invoked = (xc.DBDataAllSkill.OneVocationActiveSkillInfos)translator.FastGetCSObj(L, 1);
                LuaAPI.xlua_pushuint(L, __cl_gen_to_be_invoked.mVocation);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_mSkills(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.DBDataAllSkill.OneVocationActiveSkillInfos __cl_gen_to_be_invoked = (xc.DBDataAllSkill.OneVocationActiveSkillInfos)translator.FastGetCSObj(L, 1);
                translator.Push(L, __cl_gen_to_be_invoked.mSkills);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_mVocation(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.DBDataAllSkill.OneVocationActiveSkillInfos __cl_gen_to_be_invoked = (xc.DBDataAllSkill.OneVocationActiveSkillInfos)translator.FastGetCSObj(L, 1);
                __cl_gen_to_be_invoked.mVocation = LuaAPI.xlua_touint(L, 2);
            
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_mSkills(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.DBDataAllSkill.OneVocationActiveSkillInfos __cl_gen_to_be_invoked = (xc.DBDataAllSkill.OneVocationActiveSkillInfos)translator.FastGetCSObj(L, 1);
                __cl_gen_to_be_invoked.mSkills = (System.Collections.Generic.Dictionary<xc.DBDataAllSkill.SET_SLOT_TYPE, System.Collections.Generic.List<xc.DBDataAllSkill.AllSkillInfo>>)translator.GetObject(L, 2, typeof(System.Collections.Generic.Dictionary<xc.DBDataAllSkill.SET_SLOT_TYPE, System.Collections.Generic.List<xc.DBDataAllSkill.AllSkillInfo>>));
            
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 0;
        }
        
		
		
		
		
    }
}
