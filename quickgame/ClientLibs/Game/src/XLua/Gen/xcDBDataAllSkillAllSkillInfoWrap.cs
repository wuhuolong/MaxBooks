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
    public class xcDBDataAllSkillAllSkillInfoWrap
    {
        public static void __Register(RealStatePtr L)
        {
			ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			XUtils.BeginObjectRegister(typeof(xc.DBDataAllSkill.AllSkillInfo), L, translator, 0, 0, 25, 25);
			
			
			
			XUtils.RegisterFunc(L, XUtils.GETTER_IDX, "Id", _g_get_Id);
            XUtils.RegisterFunc(L, XUtils.GETTER_IDX, "SkillType", _g_get_SkillType);
            XUtils.RegisterFunc(L, XUtils.GETTER_IDX, "Sub_id", _g_get_Sub_id);
            XUtils.RegisterFunc(L, XUtils.GETTER_IDX, "SortId", _g_get_SortId);
            XUtils.RegisterFunc(L, XUtils.GETTER_IDX, "Name", _g_get_Name);
            XUtils.RegisterFunc(L, XUtils.GETTER_IDX, "Source", _g_get_Source);
            XUtils.RegisterFunc(L, XUtils.GETTER_IDX, "Desc", _g_get_Desc);
            XUtils.RegisterFunc(L, XUtils.GETTER_IDX, "Icon", _g_get_Icon);
            XUtils.RegisterFunc(L, XUtils.GETTER_IDX, "ModelId", _g_get_ModelId);
            XUtils.RegisterFunc(L, XUtils.GETTER_IDX, "ModelAction", _g_get_ModelAction);
            XUtils.RegisterFunc(L, XUtils.GETTER_IDX, "Require_race", _g_get_Require_race);
            XUtils.RegisterFunc(L, XUtils.GETTER_IDX, "Skill_type_descript", _g_get_Skill_type_descript);
            XUtils.RegisterFunc(L, XUtils.GETTER_IDX, "Can_set_key", _g_get_Can_set_key);
            XUtils.RegisterFunc(L, XUtils.GETTER_IDX, "FixedKeyPos", _g_get_FixedKeyPos);
            XUtils.RegisterFunc(L, XUtils.GETTER_IDX, "OpenHole", _g_get_OpenHole);
            XUtils.RegisterFunc(L, XUtils.GETTER_IDX, "SetSlotType", _g_get_SetSlotType);
            XUtils.RegisterFunc(L, XUtils.GETTER_IDX, "ReplaceIds", _g_get_ReplaceIds);
            XUtils.RegisterFunc(L, XUtils.GETTER_IDX, "Level", _g_get_Level);
            XUtils.RegisterFunc(L, XUtils.GETTER_IDX, "ShowInPanel", _g_get_ShowInPanel);
            XUtils.RegisterFunc(L, XUtils.GETTER_IDX, "LevelNotice", _g_get_LevelNotice);
            XUtils.RegisterFunc(L, XUtils.GETTER_IDX, "MinLevelTotalSkillId", _g_get_MinLevelTotalSkillId);
            XUtils.RegisterFunc(L, XUtils.GETTER_IDX, "NextLevelSkillTmpl", _g_get_NextLevelSkillTmpl);
            XUtils.RegisterFunc(L, XUtils.GETTER_IDX, "StopHookWhenGain", _g_get_StopHookWhenGain);
            XUtils.RegisterFunc(L, XUtils.GETTER_IDX, "Attrs", _g_get_Attrs);
            XUtils.RegisterFunc(L, XUtils.GETTER_IDX, "zhuhun_txt", _g_get_zhuhun_txt);
            
			XUtils.RegisterFunc(L, XUtils.SETTER_IDX, "Id", _s_set_Id);
            XUtils.RegisterFunc(L, XUtils.SETTER_IDX, "SkillType", _s_set_SkillType);
            XUtils.RegisterFunc(L, XUtils.SETTER_IDX, "Sub_id", _s_set_Sub_id);
            XUtils.RegisterFunc(L, XUtils.SETTER_IDX, "SortId", _s_set_SortId);
            XUtils.RegisterFunc(L, XUtils.SETTER_IDX, "Name", _s_set_Name);
            XUtils.RegisterFunc(L, XUtils.SETTER_IDX, "Source", _s_set_Source);
            XUtils.RegisterFunc(L, XUtils.SETTER_IDX, "Desc", _s_set_Desc);
            XUtils.RegisterFunc(L, XUtils.SETTER_IDX, "Icon", _s_set_Icon);
            XUtils.RegisterFunc(L, XUtils.SETTER_IDX, "ModelId", _s_set_ModelId);
            XUtils.RegisterFunc(L, XUtils.SETTER_IDX, "ModelAction", _s_set_ModelAction);
            XUtils.RegisterFunc(L, XUtils.SETTER_IDX, "Require_race", _s_set_Require_race);
            XUtils.RegisterFunc(L, XUtils.SETTER_IDX, "Skill_type_descript", _s_set_Skill_type_descript);
            XUtils.RegisterFunc(L, XUtils.SETTER_IDX, "Can_set_key", _s_set_Can_set_key);
            XUtils.RegisterFunc(L, XUtils.SETTER_IDX, "FixedKeyPos", _s_set_FixedKeyPos);
            XUtils.RegisterFunc(L, XUtils.SETTER_IDX, "OpenHole", _s_set_OpenHole);
            XUtils.RegisterFunc(L, XUtils.SETTER_IDX, "SetSlotType", _s_set_SetSlotType);
            XUtils.RegisterFunc(L, XUtils.SETTER_IDX, "ReplaceIds", _s_set_ReplaceIds);
            XUtils.RegisterFunc(L, XUtils.SETTER_IDX, "Level", _s_set_Level);
            XUtils.RegisterFunc(L, XUtils.SETTER_IDX, "ShowInPanel", _s_set_ShowInPanel);
            XUtils.RegisterFunc(L, XUtils.SETTER_IDX, "LevelNotice", _s_set_LevelNotice);
            XUtils.RegisterFunc(L, XUtils.SETTER_IDX, "MinLevelTotalSkillId", _s_set_MinLevelTotalSkillId);
            XUtils.RegisterFunc(L, XUtils.SETTER_IDX, "NextLevelSkillTmpl", _s_set_NextLevelSkillTmpl);
            XUtils.RegisterFunc(L, XUtils.SETTER_IDX, "StopHookWhenGain", _s_set_StopHookWhenGain);
            XUtils.RegisterFunc(L, XUtils.SETTER_IDX, "Attrs", _s_set_Attrs);
            XUtils.RegisterFunc(L, XUtils.SETTER_IDX, "zhuhun_txt", _s_set_zhuhun_txt);
            
			XUtils.EndObjectRegister(typeof(xc.DBDataAllSkill.AllSkillInfo), L, translator, null, null,
			    null, null, null);

		    XUtils.BeginClassRegister(typeof(xc.DBDataAllSkill.AllSkillInfo), L, __CreateInstance, 1, 0, 0);
			
			
            
            XUtils.RegisterObject(L, translator, XUtils.CLS_IDX, "UnderlyingSystemType", typeof(xc.DBDataAllSkill.AllSkillInfo));
			
			
			XUtils.EndClassRegister(typeof(xc.DBDataAllSkill.AllSkillInfo), L, translator);
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int __CreateInstance(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			try {
				if(LuaAPI.lua_gettop(L) == 1)
				{
					
					xc.DBDataAllSkill.AllSkillInfo __cl_gen_ret = new xc.DBDataAllSkill.AllSkillInfo();
					translator.Push(L, __cl_gen_ret);
					return 1;
				}
				
			}
			catch(System.Exception __gen_e) {
				return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
			}
            return LuaAPI.luaL_error(L, "invalid arguments to xc.DBDataAllSkill.AllSkillInfo constructor!");
            
        }
        
		
        
		
        
        
        
        
        
        
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_Id(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.DBDataAllSkill.AllSkillInfo __cl_gen_to_be_invoked = (xc.DBDataAllSkill.AllSkillInfo)translator.FastGetCSObj(L, 1);
                LuaAPI.xlua_pushuint(L, __cl_gen_to_be_invoked.Id);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_SkillType(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.DBDataAllSkill.AllSkillInfo __cl_gen_to_be_invoked = (xc.DBDataAllSkill.AllSkillInfo)translator.FastGetCSObj(L, 1);
                translator.PushxcDBDataAllSkillSKILL_TYPE(L, __cl_gen_to_be_invoked.SkillType);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_Sub_id(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.DBDataAllSkill.AllSkillInfo __cl_gen_to_be_invoked = (xc.DBDataAllSkill.AllSkillInfo)translator.FastGetCSObj(L, 1);
                LuaAPI.xlua_pushuint(L, __cl_gen_to_be_invoked.Sub_id);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_SortId(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.DBDataAllSkill.AllSkillInfo __cl_gen_to_be_invoked = (xc.DBDataAllSkill.AllSkillInfo)translator.FastGetCSObj(L, 1);
                LuaAPI.xlua_pushinteger(L, __cl_gen_to_be_invoked.SortId);
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
			
                xc.DBDataAllSkill.AllSkillInfo __cl_gen_to_be_invoked = (xc.DBDataAllSkill.AllSkillInfo)translator.FastGetCSObj(L, 1);
                LuaAPI.lua_pushstring(L, __cl_gen_to_be_invoked.Name);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_Source(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.DBDataAllSkill.AllSkillInfo __cl_gen_to_be_invoked = (xc.DBDataAllSkill.AllSkillInfo)translator.FastGetCSObj(L, 1);
                LuaAPI.lua_pushstring(L, __cl_gen_to_be_invoked.Source);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_Desc(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.DBDataAllSkill.AllSkillInfo __cl_gen_to_be_invoked = (xc.DBDataAllSkill.AllSkillInfo)translator.FastGetCSObj(L, 1);
                LuaAPI.lua_pushstring(L, __cl_gen_to_be_invoked.Desc);
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
			
                xc.DBDataAllSkill.AllSkillInfo __cl_gen_to_be_invoked = (xc.DBDataAllSkill.AllSkillInfo)translator.FastGetCSObj(L, 1);
                LuaAPI.lua_pushstring(L, __cl_gen_to_be_invoked.Icon);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_ModelId(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.DBDataAllSkill.AllSkillInfo __cl_gen_to_be_invoked = (xc.DBDataAllSkill.AllSkillInfo)translator.FastGetCSObj(L, 1);
                LuaAPI.xlua_pushuint(L, __cl_gen_to_be_invoked.ModelId);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_ModelAction(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.DBDataAllSkill.AllSkillInfo __cl_gen_to_be_invoked = (xc.DBDataAllSkill.AllSkillInfo)translator.FastGetCSObj(L, 1);
                LuaAPI.lua_pushstring(L, __cl_gen_to_be_invoked.ModelAction);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_Require_race(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.DBDataAllSkill.AllSkillInfo __cl_gen_to_be_invoked = (xc.DBDataAllSkill.AllSkillInfo)translator.FastGetCSObj(L, 1);
                LuaAPI.xlua_pushuint(L, __cl_gen_to_be_invoked.Require_race);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_Skill_type_descript(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.DBDataAllSkill.AllSkillInfo __cl_gen_to_be_invoked = (xc.DBDataAllSkill.AllSkillInfo)translator.FastGetCSObj(L, 1);
                LuaAPI.lua_pushstring(L, __cl_gen_to_be_invoked.Skill_type_descript);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_Can_set_key(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.DBDataAllSkill.AllSkillInfo __cl_gen_to_be_invoked = (xc.DBDataAllSkill.AllSkillInfo)translator.FastGetCSObj(L, 1);
                LuaAPI.lua_pushboolean(L, __cl_gen_to_be_invoked.Can_set_key);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_FixedKeyPos(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.DBDataAllSkill.AllSkillInfo __cl_gen_to_be_invoked = (xc.DBDataAllSkill.AllSkillInfo)translator.FastGetCSObj(L, 1);
                LuaAPI.xlua_pushuint(L, __cl_gen_to_be_invoked.FixedKeyPos);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_OpenHole(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.DBDataAllSkill.AllSkillInfo __cl_gen_to_be_invoked = (xc.DBDataAllSkill.AllSkillInfo)translator.FastGetCSObj(L, 1);
                LuaAPI.xlua_pushuint(L, __cl_gen_to_be_invoked.OpenHole);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_SetSlotType(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.DBDataAllSkill.AllSkillInfo __cl_gen_to_be_invoked = (xc.DBDataAllSkill.AllSkillInfo)translator.FastGetCSObj(L, 1);
                translator.PushxcDBDataAllSkillSET_SLOT_TYPE(L, __cl_gen_to_be_invoked.SetSlotType);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_ReplaceIds(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.DBDataAllSkill.AllSkillInfo __cl_gen_to_be_invoked = (xc.DBDataAllSkill.AllSkillInfo)translator.FastGetCSObj(L, 1);
                translator.Push(L, __cl_gen_to_be_invoked.ReplaceIds);
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
			
                xc.DBDataAllSkill.AllSkillInfo __cl_gen_to_be_invoked = (xc.DBDataAllSkill.AllSkillInfo)translator.FastGetCSObj(L, 1);
                LuaAPI.xlua_pushuint(L, __cl_gen_to_be_invoked.Level);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_ShowInPanel(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.DBDataAllSkill.AllSkillInfo __cl_gen_to_be_invoked = (xc.DBDataAllSkill.AllSkillInfo)translator.FastGetCSObj(L, 1);
                LuaAPI.lua_pushboolean(L, __cl_gen_to_be_invoked.ShowInPanel);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_LevelNotice(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.DBDataAllSkill.AllSkillInfo __cl_gen_to_be_invoked = (xc.DBDataAllSkill.AllSkillInfo)translator.FastGetCSObj(L, 1);
                LuaAPI.lua_pushstring(L, __cl_gen_to_be_invoked.LevelNotice);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_MinLevelTotalSkillId(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.DBDataAllSkill.AllSkillInfo __cl_gen_to_be_invoked = (xc.DBDataAllSkill.AllSkillInfo)translator.FastGetCSObj(L, 1);
                LuaAPI.xlua_pushuint(L, __cl_gen_to_be_invoked.MinLevelTotalSkillId);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_NextLevelSkillTmpl(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.DBDataAllSkill.AllSkillInfo __cl_gen_to_be_invoked = (xc.DBDataAllSkill.AllSkillInfo)translator.FastGetCSObj(L, 1);
                translator.Push(L, __cl_gen_to_be_invoked.NextLevelSkillTmpl);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_StopHookWhenGain(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.DBDataAllSkill.AllSkillInfo __cl_gen_to_be_invoked = (xc.DBDataAllSkill.AllSkillInfo)translator.FastGetCSObj(L, 1);
                LuaAPI.lua_pushboolean(L, __cl_gen_to_be_invoked.StopHookWhenGain);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_Attrs(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.DBDataAllSkill.AllSkillInfo __cl_gen_to_be_invoked = (xc.DBDataAllSkill.AllSkillInfo)translator.FastGetCSObj(L, 1);
                translator.Push(L, __cl_gen_to_be_invoked.Attrs);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_zhuhun_txt(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.DBDataAllSkill.AllSkillInfo __cl_gen_to_be_invoked = (xc.DBDataAllSkill.AllSkillInfo)translator.FastGetCSObj(L, 1);
                LuaAPI.lua_pushstring(L, __cl_gen_to_be_invoked.zhuhun_txt);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_Id(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.DBDataAllSkill.AllSkillInfo __cl_gen_to_be_invoked = (xc.DBDataAllSkill.AllSkillInfo)translator.FastGetCSObj(L, 1);
                __cl_gen_to_be_invoked.Id = LuaAPI.xlua_touint(L, 2);
            
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_SkillType(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.DBDataAllSkill.AllSkillInfo __cl_gen_to_be_invoked = (xc.DBDataAllSkill.AllSkillInfo)translator.FastGetCSObj(L, 1);
                xc.DBDataAllSkill.SKILL_TYPE __cl_gen_value;translator.Get(L, 2, out __cl_gen_value);
				__cl_gen_to_be_invoked.SkillType = __cl_gen_value;
            
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_Sub_id(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.DBDataAllSkill.AllSkillInfo __cl_gen_to_be_invoked = (xc.DBDataAllSkill.AllSkillInfo)translator.FastGetCSObj(L, 1);
                __cl_gen_to_be_invoked.Sub_id = LuaAPI.xlua_touint(L, 2);
            
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_SortId(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.DBDataAllSkill.AllSkillInfo __cl_gen_to_be_invoked = (xc.DBDataAllSkill.AllSkillInfo)translator.FastGetCSObj(L, 1);
                __cl_gen_to_be_invoked.SortId = (ushort)LuaAPI.xlua_tointeger(L, 2);
            
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
			
                xc.DBDataAllSkill.AllSkillInfo __cl_gen_to_be_invoked = (xc.DBDataAllSkill.AllSkillInfo)translator.FastGetCSObj(L, 1);
                __cl_gen_to_be_invoked.Name = LuaAPI.lua_tostring(L, 2);
            
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_Source(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.DBDataAllSkill.AllSkillInfo __cl_gen_to_be_invoked = (xc.DBDataAllSkill.AllSkillInfo)translator.FastGetCSObj(L, 1);
                __cl_gen_to_be_invoked.Source = LuaAPI.lua_tostring(L, 2);
            
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_Desc(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.DBDataAllSkill.AllSkillInfo __cl_gen_to_be_invoked = (xc.DBDataAllSkill.AllSkillInfo)translator.FastGetCSObj(L, 1);
                __cl_gen_to_be_invoked.Desc = LuaAPI.lua_tostring(L, 2);
            
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
			
                xc.DBDataAllSkill.AllSkillInfo __cl_gen_to_be_invoked = (xc.DBDataAllSkill.AllSkillInfo)translator.FastGetCSObj(L, 1);
                __cl_gen_to_be_invoked.Icon = LuaAPI.lua_tostring(L, 2);
            
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_ModelId(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.DBDataAllSkill.AllSkillInfo __cl_gen_to_be_invoked = (xc.DBDataAllSkill.AllSkillInfo)translator.FastGetCSObj(L, 1);
                __cl_gen_to_be_invoked.ModelId = LuaAPI.xlua_touint(L, 2);
            
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_ModelAction(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.DBDataAllSkill.AllSkillInfo __cl_gen_to_be_invoked = (xc.DBDataAllSkill.AllSkillInfo)translator.FastGetCSObj(L, 1);
                __cl_gen_to_be_invoked.ModelAction = LuaAPI.lua_tostring(L, 2);
            
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_Require_race(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.DBDataAllSkill.AllSkillInfo __cl_gen_to_be_invoked = (xc.DBDataAllSkill.AllSkillInfo)translator.FastGetCSObj(L, 1);
                __cl_gen_to_be_invoked.Require_race = LuaAPI.xlua_touint(L, 2);
            
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_Skill_type_descript(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.DBDataAllSkill.AllSkillInfo __cl_gen_to_be_invoked = (xc.DBDataAllSkill.AllSkillInfo)translator.FastGetCSObj(L, 1);
                __cl_gen_to_be_invoked.Skill_type_descript = LuaAPI.lua_tostring(L, 2);
            
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_Can_set_key(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.DBDataAllSkill.AllSkillInfo __cl_gen_to_be_invoked = (xc.DBDataAllSkill.AllSkillInfo)translator.FastGetCSObj(L, 1);
                __cl_gen_to_be_invoked.Can_set_key = LuaAPI.lua_toboolean(L, 2);
            
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_FixedKeyPos(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.DBDataAllSkill.AllSkillInfo __cl_gen_to_be_invoked = (xc.DBDataAllSkill.AllSkillInfo)translator.FastGetCSObj(L, 1);
                __cl_gen_to_be_invoked.FixedKeyPos = LuaAPI.xlua_touint(L, 2);
            
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_OpenHole(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.DBDataAllSkill.AllSkillInfo __cl_gen_to_be_invoked = (xc.DBDataAllSkill.AllSkillInfo)translator.FastGetCSObj(L, 1);
                __cl_gen_to_be_invoked.OpenHole = LuaAPI.xlua_touint(L, 2);
            
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_SetSlotType(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.DBDataAllSkill.AllSkillInfo __cl_gen_to_be_invoked = (xc.DBDataAllSkill.AllSkillInfo)translator.FastGetCSObj(L, 1);
                xc.DBDataAllSkill.SET_SLOT_TYPE __cl_gen_value;translator.Get(L, 2, out __cl_gen_value);
				__cl_gen_to_be_invoked.SetSlotType = __cl_gen_value;
            
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_ReplaceIds(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.DBDataAllSkill.AllSkillInfo __cl_gen_to_be_invoked = (xc.DBDataAllSkill.AllSkillInfo)translator.FastGetCSObj(L, 1);
                __cl_gen_to_be_invoked.ReplaceIds = (System.Collections.Generic.List<uint>)translator.GetObject(L, 2, typeof(System.Collections.Generic.List<uint>));
            
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
			
                xc.DBDataAllSkill.AllSkillInfo __cl_gen_to_be_invoked = (xc.DBDataAllSkill.AllSkillInfo)translator.FastGetCSObj(L, 1);
                __cl_gen_to_be_invoked.Level = LuaAPI.xlua_touint(L, 2);
            
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_ShowInPanel(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.DBDataAllSkill.AllSkillInfo __cl_gen_to_be_invoked = (xc.DBDataAllSkill.AllSkillInfo)translator.FastGetCSObj(L, 1);
                __cl_gen_to_be_invoked.ShowInPanel = LuaAPI.lua_toboolean(L, 2);
            
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_LevelNotice(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.DBDataAllSkill.AllSkillInfo __cl_gen_to_be_invoked = (xc.DBDataAllSkill.AllSkillInfo)translator.FastGetCSObj(L, 1);
                __cl_gen_to_be_invoked.LevelNotice = LuaAPI.lua_tostring(L, 2);
            
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_MinLevelTotalSkillId(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.DBDataAllSkill.AllSkillInfo __cl_gen_to_be_invoked = (xc.DBDataAllSkill.AllSkillInfo)translator.FastGetCSObj(L, 1);
                __cl_gen_to_be_invoked.MinLevelTotalSkillId = LuaAPI.xlua_touint(L, 2);
            
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_NextLevelSkillTmpl(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.DBDataAllSkill.AllSkillInfo __cl_gen_to_be_invoked = (xc.DBDataAllSkill.AllSkillInfo)translator.FastGetCSObj(L, 1);
                __cl_gen_to_be_invoked.NextLevelSkillTmpl = (xc.DBDataAllSkill.AllSkillInfo)translator.GetObject(L, 2, typeof(xc.DBDataAllSkill.AllSkillInfo));
            
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_StopHookWhenGain(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.DBDataAllSkill.AllSkillInfo __cl_gen_to_be_invoked = (xc.DBDataAllSkill.AllSkillInfo)translator.FastGetCSObj(L, 1);
                __cl_gen_to_be_invoked.StopHookWhenGain = LuaAPI.lua_toboolean(L, 2);
            
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_Attrs(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.DBDataAllSkill.AllSkillInfo __cl_gen_to_be_invoked = (xc.DBDataAllSkill.AllSkillInfo)translator.FastGetCSObj(L, 1);
                __cl_gen_to_be_invoked.Attrs = (System.Collections.Generic.List<System.Collections.Generic.List<uint>>)translator.GetObject(L, 2, typeof(System.Collections.Generic.List<System.Collections.Generic.List<uint>>));
            
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_zhuhun_txt(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.DBDataAllSkill.AllSkillInfo __cl_gen_to_be_invoked = (xc.DBDataAllSkill.AllSkillInfo)translator.FastGetCSObj(L, 1);
                __cl_gen_to_be_invoked.zhuhun_txt = LuaAPI.lua_tostring(L, 2);
            
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 0;
        }
        
		
		
		
		
    }
}
