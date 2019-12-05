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
    public class xcDBGuildSkillDBGuildSkillItemWrap
    {
        public static void __Register(RealStatePtr L)
        {
			ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			XUtils.BeginObjectRegister(typeof(xc.DBGuildSkill.DBGuildSkillItem), L, translator, 0, 0, 10, 10);
			
			
			
			XUtils.RegisterFunc(L, XUtils.GETTER_IDX, "SkillId", _g_get_SkillId);
            XUtils.RegisterFunc(L, XUtils.GETTER_IDX, "Name", _g_get_Name);
            XUtils.RegisterFunc(L, XUtils.GETTER_IDX, "Level", _g_get_Level);
            XUtils.RegisterFunc(L, XUtils.GETTER_IDX, "OpenLv", _g_get_OpenLv);
            XUtils.RegisterFunc(L, XUtils.GETTER_IDX, "OpenCost", _g_get_OpenCost);
            XUtils.RegisterFunc(L, XUtils.GETTER_IDX, "LvUpCost", _g_get_LvUpCost);
            XUtils.RegisterFunc(L, XUtils.GETTER_IDX, "AttrArray", _g_get_AttrArray);
            XUtils.RegisterFunc(L, XUtils.GETTER_IDX, "Icon", _g_get_Icon);
            XUtils.RegisterFunc(L, XUtils.GETTER_IDX, "CurAttrId", _g_get_CurAttrId);
            XUtils.RegisterFunc(L, XUtils.GETTER_IDX, "CurShowAttrArray", _g_get_CurShowAttrArray);
            
			XUtils.RegisterFunc(L, XUtils.SETTER_IDX, "SkillId", _s_set_SkillId);
            XUtils.RegisterFunc(L, XUtils.SETTER_IDX, "Name", _s_set_Name);
            XUtils.RegisterFunc(L, XUtils.SETTER_IDX, "Level", _s_set_Level);
            XUtils.RegisterFunc(L, XUtils.SETTER_IDX, "OpenLv", _s_set_OpenLv);
            XUtils.RegisterFunc(L, XUtils.SETTER_IDX, "OpenCost", _s_set_OpenCost);
            XUtils.RegisterFunc(L, XUtils.SETTER_IDX, "LvUpCost", _s_set_LvUpCost);
            XUtils.RegisterFunc(L, XUtils.SETTER_IDX, "AttrArray", _s_set_AttrArray);
            XUtils.RegisterFunc(L, XUtils.SETTER_IDX, "Icon", _s_set_Icon);
            XUtils.RegisterFunc(L, XUtils.SETTER_IDX, "CurAttrId", _s_set_CurAttrId);
            XUtils.RegisterFunc(L, XUtils.SETTER_IDX, "CurShowAttrArray", _s_set_CurShowAttrArray);
            
			XUtils.EndObjectRegister(typeof(xc.DBGuildSkill.DBGuildSkillItem), L, translator, null, null,
			    null, null, null);

		    XUtils.BeginClassRegister(typeof(xc.DBGuildSkill.DBGuildSkillItem), L, __CreateInstance, 1, 0, 0);
			
			
            
            XUtils.RegisterObject(L, translator, XUtils.CLS_IDX, "UnderlyingSystemType", typeof(xc.DBGuildSkill.DBGuildSkillItem));
			
			
			XUtils.EndClassRegister(typeof(xc.DBGuildSkill.DBGuildSkillItem), L, translator);
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int __CreateInstance(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			try {
				if(LuaAPI.lua_gettop(L) == 1)
				{
					
					xc.DBGuildSkill.DBGuildSkillItem __cl_gen_ret = new xc.DBGuildSkill.DBGuildSkillItem();
					translator.Push(L, __cl_gen_ret);
					return 1;
				}
				
			}
			catch(System.Exception __gen_e) {
				return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
			}
            return LuaAPI.luaL_error(L, "invalid arguments to xc.DBGuildSkill.DBGuildSkillItem constructor!");
            
        }
        
		
        
		
        
        
        
        
        
        
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_SkillId(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.DBGuildSkill.DBGuildSkillItem __cl_gen_to_be_invoked = (xc.DBGuildSkill.DBGuildSkillItem)translator.FastGetCSObj(L, 1);
                LuaAPI.xlua_pushuint(L, __cl_gen_to_be_invoked.SkillId);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_Name(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.DBGuildSkill.DBGuildSkillItem __cl_gen_to_be_invoked = (xc.DBGuildSkill.DBGuildSkillItem)translator.FastGetCSObj(L, 1);
                LuaAPI.lua_pushstring(L, __cl_gen_to_be_invoked.Name);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_Level(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.DBGuildSkill.DBGuildSkillItem __cl_gen_to_be_invoked = (xc.DBGuildSkill.DBGuildSkillItem)translator.FastGetCSObj(L, 1);
                LuaAPI.xlua_pushuint(L, __cl_gen_to_be_invoked.Level);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_OpenLv(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.DBGuildSkill.DBGuildSkillItem __cl_gen_to_be_invoked = (xc.DBGuildSkill.DBGuildSkillItem)translator.FastGetCSObj(L, 1);
                LuaAPI.xlua_pushuint(L, __cl_gen_to_be_invoked.OpenLv);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_OpenCost(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.DBGuildSkill.DBGuildSkillItem __cl_gen_to_be_invoked = (xc.DBGuildSkill.DBGuildSkillItem)translator.FastGetCSObj(L, 1);
                LuaAPI.xlua_pushuint(L, __cl_gen_to_be_invoked.OpenCost);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_LvUpCost(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.DBGuildSkill.DBGuildSkillItem __cl_gen_to_be_invoked = (xc.DBGuildSkill.DBGuildSkillItem)translator.FastGetCSObj(L, 1);
                LuaAPI.xlua_pushuint(L, __cl_gen_to_be_invoked.LvUpCost);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_AttrArray(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.DBGuildSkill.DBGuildSkillItem __cl_gen_to_be_invoked = (xc.DBGuildSkill.DBGuildSkillItem)translator.FastGetCSObj(L, 1);
                translator.Push(L, __cl_gen_to_be_invoked.AttrArray);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_Icon(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.DBGuildSkill.DBGuildSkillItem __cl_gen_to_be_invoked = (xc.DBGuildSkill.DBGuildSkillItem)translator.FastGetCSObj(L, 1);
                LuaAPI.lua_pushstring(L, __cl_gen_to_be_invoked.Icon);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_CurAttrId(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.DBGuildSkill.DBGuildSkillItem __cl_gen_to_be_invoked = (xc.DBGuildSkill.DBGuildSkillItem)translator.FastGetCSObj(L, 1);
                LuaAPI.xlua_pushuint(L, __cl_gen_to_be_invoked.CurAttrId);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_CurShowAttrArray(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.DBGuildSkill.DBGuildSkillItem __cl_gen_to_be_invoked = (xc.DBGuildSkill.DBGuildSkillItem)translator.FastGetCSObj(L, 1);
                translator.Push(L, __cl_gen_to_be_invoked.CurShowAttrArray);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_SkillId(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.DBGuildSkill.DBGuildSkillItem __cl_gen_to_be_invoked = (xc.DBGuildSkill.DBGuildSkillItem)translator.FastGetCSObj(L, 1);
                __cl_gen_to_be_invoked.SkillId = LuaAPI.xlua_touint(L, 2);
            
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_Name(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.DBGuildSkill.DBGuildSkillItem __cl_gen_to_be_invoked = (xc.DBGuildSkill.DBGuildSkillItem)translator.FastGetCSObj(L, 1);
                __cl_gen_to_be_invoked.Name = LuaAPI.lua_tostring(L, 2);
            
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_Level(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.DBGuildSkill.DBGuildSkillItem __cl_gen_to_be_invoked = (xc.DBGuildSkill.DBGuildSkillItem)translator.FastGetCSObj(L, 1);
                __cl_gen_to_be_invoked.Level = LuaAPI.xlua_touint(L, 2);
            
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_OpenLv(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.DBGuildSkill.DBGuildSkillItem __cl_gen_to_be_invoked = (xc.DBGuildSkill.DBGuildSkillItem)translator.FastGetCSObj(L, 1);
                __cl_gen_to_be_invoked.OpenLv = LuaAPI.xlua_touint(L, 2);
            
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_OpenCost(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.DBGuildSkill.DBGuildSkillItem __cl_gen_to_be_invoked = (xc.DBGuildSkill.DBGuildSkillItem)translator.FastGetCSObj(L, 1);
                __cl_gen_to_be_invoked.OpenCost = LuaAPI.xlua_touint(L, 2);
            
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_LvUpCost(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.DBGuildSkill.DBGuildSkillItem __cl_gen_to_be_invoked = (xc.DBGuildSkill.DBGuildSkillItem)translator.FastGetCSObj(L, 1);
                __cl_gen_to_be_invoked.LvUpCost = LuaAPI.xlua_touint(L, 2);
            
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_AttrArray(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.DBGuildSkill.DBGuildSkillItem __cl_gen_to_be_invoked = (xc.DBGuildSkill.DBGuildSkillItem)translator.FastGetCSObj(L, 1);
                __cl_gen_to_be_invoked.AttrArray = (System.Collections.Generic.List<xc.DBGuildSkill.DBCommonAttrItem>)translator.GetObject(L, 2, typeof(System.Collections.Generic.List<xc.DBGuildSkill.DBCommonAttrItem>));
            
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_Icon(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.DBGuildSkill.DBGuildSkillItem __cl_gen_to_be_invoked = (xc.DBGuildSkill.DBGuildSkillItem)translator.FastGetCSObj(L, 1);
                __cl_gen_to_be_invoked.Icon = LuaAPI.lua_tostring(L, 2);
            
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_CurAttrId(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.DBGuildSkill.DBGuildSkillItem __cl_gen_to_be_invoked = (xc.DBGuildSkill.DBGuildSkillItem)translator.FastGetCSObj(L, 1);
                __cl_gen_to_be_invoked.CurAttrId = LuaAPI.xlua_touint(L, 2);
            
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_CurShowAttrArray(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.DBGuildSkill.DBGuildSkillItem __cl_gen_to_be_invoked = (xc.DBGuildSkill.DBGuildSkillItem)translator.FastGetCSObj(L, 1);
                __cl_gen_to_be_invoked.CurShowAttrArray = (System.Collections.Generic.List<System.Collections.Generic.List<uint>>)translator.GetObject(L, 2, typeof(System.Collections.Generic.List<System.Collections.Generic.List<uint>>));
            
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 0;
        }
        
		
		
		
		
    }
}
