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
    public class xcDBStigmaDBStigmaSkillItemSkillItemWrap
    {
        public static void __Register(RealStatePtr L)
        {
			ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			XUtils.BeginObjectRegister(typeof(xc.DBStigma.DBStigmaSkillItemSkillItem), L, translator, 0, 0, 2, 2);
			
			
			
			XUtils.RegisterFunc(L, XUtils.GETTER_IDX, "skill_id", _g_get_skill_id);
            XUtils.RegisterFunc(L, XUtils.GETTER_IDX, "open_level", _g_get_open_level);
            
			XUtils.RegisterFunc(L, XUtils.SETTER_IDX, "skill_id", _s_set_skill_id);
            XUtils.RegisterFunc(L, XUtils.SETTER_IDX, "open_level", _s_set_open_level);
            
			XUtils.EndObjectRegister(typeof(xc.DBStigma.DBStigmaSkillItemSkillItem), L, translator, null, null,
			    null, null, null);

		    XUtils.BeginClassRegister(typeof(xc.DBStigma.DBStigmaSkillItemSkillItem), L, __CreateInstance, 1, 0, 0);
			
			
            
            XUtils.RegisterObject(L, translator, XUtils.CLS_IDX, "UnderlyingSystemType", typeof(xc.DBStigma.DBStigmaSkillItemSkillItem));
			
			
			XUtils.EndClassRegister(typeof(xc.DBStigma.DBStigmaSkillItemSkillItem), L, translator);
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int __CreateInstance(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			try {
				if(LuaAPI.lua_gettop(L) == 1)
				{
					
					xc.DBStigma.DBStigmaSkillItemSkillItem __cl_gen_ret = new xc.DBStigma.DBStigmaSkillItemSkillItem();
					translator.Push(L, __cl_gen_ret);
					return 1;
				}
				
			}
			catch(System.Exception __gen_e) {
				return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
			}
            return LuaAPI.luaL_error(L, "invalid arguments to xc.DBStigma.DBStigmaSkillItemSkillItem constructor!");
            
        }
        
		
        
		
        
        
        
        
        
        
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_skill_id(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.DBStigma.DBStigmaSkillItemSkillItem __cl_gen_to_be_invoked = (xc.DBStigma.DBStigmaSkillItemSkillItem)translator.FastGetCSObj(L, 1);
                LuaAPI.xlua_pushuint(L, __cl_gen_to_be_invoked.skill_id);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_open_level(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.DBStigma.DBStigmaSkillItemSkillItem __cl_gen_to_be_invoked = (xc.DBStigma.DBStigmaSkillItemSkillItem)translator.FastGetCSObj(L, 1);
                LuaAPI.xlua_pushuint(L, __cl_gen_to_be_invoked.open_level);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_skill_id(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.DBStigma.DBStigmaSkillItemSkillItem __cl_gen_to_be_invoked = (xc.DBStigma.DBStigmaSkillItemSkillItem)translator.FastGetCSObj(L, 1);
                __cl_gen_to_be_invoked.skill_id = LuaAPI.xlua_touint(L, 2);
            
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_open_level(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.DBStigma.DBStigmaSkillItemSkillItem __cl_gen_to_be_invoked = (xc.DBStigma.DBStigmaSkillItemSkillItem)translator.FastGetCSObj(L, 1);
                __cl_gen_to_be_invoked.open_level = LuaAPI.xlua_touint(L, 2);
            
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 0;
        }
        
		
		
		
		
    }
}
