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
    public class xcDBActorActorDataWrap
    {
        public static void __Register(RealStatePtr L)
        {
			ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			XUtils.BeginObjectRegister(typeof(xc.DBActor.ActorData), L, translator, 0, 0, 25, 25);
			
			
			
			XUtils.RegisterFunc(L, XUtils.GETTER_IDX, "name", _g_get_name);
            XUtils.RegisterFunc(L, XUtils.GETTER_IDX, "vocation", _g_get_vocation);
            XUtils.RegisterFunc(L, XUtils.GETTER_IDX, "level", _g_get_level);
            XUtils.RegisterFunc(L, XUtils.GETTER_IDX, "color", _g_get_color);
            XUtils.RegisterFunc(L, XUtils.GETTER_IDX, "type", _g_get_type);
            XUtils.RegisterFunc(L, XUtils.GETTER_IDX, "war_tag", _g_get_war_tag);
            XUtils.RegisterFunc(L, XUtils.GETTER_IDX, "race_id", _g_get_race_id);
            XUtils.RegisterFunc(L, XUtils.GETTER_IDX, "skill_count", _g_get_skill_count);
            XUtils.RegisterFunc(L, XUtils.GETTER_IDX, "skill_idx", _g_get_skill_idx);
            XUtils.RegisterFunc(L, XUtils.GETTER_IDX, "cast_rate", _g_get_cast_rate);
            XUtils.RegisterFunc(L, XUtils.GETTER_IDX, "model_id", _g_get_model_id);
            XUtils.RegisterFunc(L, XUtils.GETTER_IDX, "runspeed", _g_get_runspeed);
            XUtils.RegisterFunc(L, XUtils.GETTER_IDX, "motion_radius", _g_get_motion_radius);
            XUtils.RegisterFunc(L, XUtils.GETTER_IDX, "behaviour_tree", _g_get_behaviour_tree);
            XUtils.RegisterFunc(L, XUtils.GETTER_IDX, "summon_behaviour_tree", _g_get_summon_behaviour_tree);
            XUtils.RegisterFunc(L, XUtils.GETTER_IDX, "attack_rotaion", _g_get_attack_rotaion);
            XUtils.RegisterFunc(L, XUtils.GETTER_IDX, "hp_bar_count", _g_get_hp_bar_count);
            XUtils.RegisterFunc(L, XUtils.GETTER_IDX, "gravity", _g_get_gravity);
            XUtils.RegisterFunc(L, XUtils.GETTER_IDX, "dead_notify", _g_get_dead_notify);
            XUtils.RegisterFunc(L, XUtils.GETTER_IDX, "spawn_timeline", _g_get_spawn_timeline);
            XUtils.RegisterFunc(L, XUtils.GETTER_IDX, "dead_timeline", _g_get_dead_timeline);
            XUtils.RegisterFunc(L, XUtils.GETTER_IDX, "is_hide_shadow", _g_get_is_hide_shadow);
            XUtils.RegisterFunc(L, XUtils.GETTER_IDX, "is_hide_select_effect", _g_get_is_hide_select_effect);
            XUtils.RegisterFunc(L, XUtils.GETTER_IDX, "attr_param", _g_get_attr_param);
            XUtils.RegisterFunc(L, XUtils.GETTER_IDX, "default_actor_id", _g_get_default_actor_id);
            
			XUtils.RegisterFunc(L, XUtils.SETTER_IDX, "name", _s_set_name);
            XUtils.RegisterFunc(L, XUtils.SETTER_IDX, "vocation", _s_set_vocation);
            XUtils.RegisterFunc(L, XUtils.SETTER_IDX, "level", _s_set_level);
            XUtils.RegisterFunc(L, XUtils.SETTER_IDX, "color", _s_set_color);
            XUtils.RegisterFunc(L, XUtils.SETTER_IDX, "type", _s_set_type);
            XUtils.RegisterFunc(L, XUtils.SETTER_IDX, "war_tag", _s_set_war_tag);
            XUtils.RegisterFunc(L, XUtils.SETTER_IDX, "race_id", _s_set_race_id);
            XUtils.RegisterFunc(L, XUtils.SETTER_IDX, "skill_count", _s_set_skill_count);
            XUtils.RegisterFunc(L, XUtils.SETTER_IDX, "skill_idx", _s_set_skill_idx);
            XUtils.RegisterFunc(L, XUtils.SETTER_IDX, "cast_rate", _s_set_cast_rate);
            XUtils.RegisterFunc(L, XUtils.SETTER_IDX, "model_id", _s_set_model_id);
            XUtils.RegisterFunc(L, XUtils.SETTER_IDX, "runspeed", _s_set_runspeed);
            XUtils.RegisterFunc(L, XUtils.SETTER_IDX, "motion_radius", _s_set_motion_radius);
            XUtils.RegisterFunc(L, XUtils.SETTER_IDX, "behaviour_tree", _s_set_behaviour_tree);
            XUtils.RegisterFunc(L, XUtils.SETTER_IDX, "summon_behaviour_tree", _s_set_summon_behaviour_tree);
            XUtils.RegisterFunc(L, XUtils.SETTER_IDX, "attack_rotaion", _s_set_attack_rotaion);
            XUtils.RegisterFunc(L, XUtils.SETTER_IDX, "hp_bar_count", _s_set_hp_bar_count);
            XUtils.RegisterFunc(L, XUtils.SETTER_IDX, "gravity", _s_set_gravity);
            XUtils.RegisterFunc(L, XUtils.SETTER_IDX, "dead_notify", _s_set_dead_notify);
            XUtils.RegisterFunc(L, XUtils.SETTER_IDX, "spawn_timeline", _s_set_spawn_timeline);
            XUtils.RegisterFunc(L, XUtils.SETTER_IDX, "dead_timeline", _s_set_dead_timeline);
            XUtils.RegisterFunc(L, XUtils.SETTER_IDX, "is_hide_shadow", _s_set_is_hide_shadow);
            XUtils.RegisterFunc(L, XUtils.SETTER_IDX, "is_hide_select_effect", _s_set_is_hide_select_effect);
            XUtils.RegisterFunc(L, XUtils.SETTER_IDX, "attr_param", _s_set_attr_param);
            XUtils.RegisterFunc(L, XUtils.SETTER_IDX, "default_actor_id", _s_set_default_actor_id);
            
			XUtils.EndObjectRegister(typeof(xc.DBActor.ActorData), L, translator, null, null,
			    null, null, null);

		    XUtils.BeginClassRegister(typeof(xc.DBActor.ActorData), L, __CreateInstance, 1, 0, 0);
			
			
            
            XUtils.RegisterObject(L, translator, XUtils.CLS_IDX, "UnderlyingSystemType", typeof(xc.DBActor.ActorData));
			
			
			XUtils.EndClassRegister(typeof(xc.DBActor.ActorData), L, translator);
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int __CreateInstance(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			try {
				if(LuaAPI.lua_gettop(L) == 1)
				{
					
					xc.DBActor.ActorData __cl_gen_ret = new xc.DBActor.ActorData();
					translator.Push(L, __cl_gen_ret);
					return 1;
				}
				
			}
			catch(System.Exception __gen_e) {
				return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
			}
            return LuaAPI.luaL_error(L, "invalid arguments to xc.DBActor.ActorData constructor!");
            
        }
        
		
        
		
        
        
        
        
        
        
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_name(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.DBActor.ActorData __cl_gen_to_be_invoked = (xc.DBActor.ActorData)translator.FastGetCSObj(L, 1);
                LuaAPI.lua_pushstring(L, __cl_gen_to_be_invoked.name);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_vocation(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.DBActor.ActorData __cl_gen_to_be_invoked = (xc.DBActor.ActorData)translator.FastGetCSObj(L, 1);
                LuaAPI.xlua_pushinteger(L, __cl_gen_to_be_invoked.vocation);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_level(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.DBActor.ActorData __cl_gen_to_be_invoked = (xc.DBActor.ActorData)translator.FastGetCSObj(L, 1);
                LuaAPI.xlua_pushuint(L, __cl_gen_to_be_invoked.level);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_color(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.DBActor.ActorData __cl_gen_to_be_invoked = (xc.DBActor.ActorData)translator.FastGetCSObj(L, 1);
                translator.PushMonsterQualityColor(L, __cl_gen_to_be_invoked.color);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_type(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.DBActor.ActorData __cl_gen_to_be_invoked = (xc.DBActor.ActorData)translator.FastGetCSObj(L, 1);
                LuaAPI.xlua_pushinteger(L, __cl_gen_to_be_invoked.type);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_war_tag(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.DBActor.ActorData __cl_gen_to_be_invoked = (xc.DBActor.ActorData)translator.FastGetCSObj(L, 1);
                LuaAPI.xlua_pushinteger(L, __cl_gen_to_be_invoked.war_tag);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_race_id(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.DBActor.ActorData __cl_gen_to_be_invoked = (xc.DBActor.ActorData)translator.FastGetCSObj(L, 1);
                LuaAPI.xlua_pushuint(L, __cl_gen_to_be_invoked.race_id);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_skill_count(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.DBActor.ActorData __cl_gen_to_be_invoked = (xc.DBActor.ActorData)translator.FastGetCSObj(L, 1);
                LuaAPI.xlua_pushinteger(L, __cl_gen_to_be_invoked.skill_count);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_skill_idx(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.DBActor.ActorData __cl_gen_to_be_invoked = (xc.DBActor.ActorData)translator.FastGetCSObj(L, 1);
                translator.Push(L, __cl_gen_to_be_invoked.skill_idx);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_cast_rate(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.DBActor.ActorData __cl_gen_to_be_invoked = (xc.DBActor.ActorData)translator.FastGetCSObj(L, 1);
                LuaAPI.lua_pushstring(L, __cl_gen_to_be_invoked.cast_rate);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_model_id(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.DBActor.ActorData __cl_gen_to_be_invoked = (xc.DBActor.ActorData)translator.FastGetCSObj(L, 1);
                LuaAPI.xlua_pushuint(L, __cl_gen_to_be_invoked.model_id);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_runspeed(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.DBActor.ActorData __cl_gen_to_be_invoked = (xc.DBActor.ActorData)translator.FastGetCSObj(L, 1);
                LuaAPI.xlua_pushinteger(L, __cl_gen_to_be_invoked.runspeed);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_motion_radius(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.DBActor.ActorData __cl_gen_to_be_invoked = (xc.DBActor.ActorData)translator.FastGetCSObj(L, 1);
                LuaAPI.xlua_pushinteger(L, __cl_gen_to_be_invoked.motion_radius);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_behaviour_tree(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.DBActor.ActorData __cl_gen_to_be_invoked = (xc.DBActor.ActorData)translator.FastGetCSObj(L, 1);
                LuaAPI.lua_pushstring(L, __cl_gen_to_be_invoked.behaviour_tree);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_summon_behaviour_tree(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.DBActor.ActorData __cl_gen_to_be_invoked = (xc.DBActor.ActorData)translator.FastGetCSObj(L, 1);
                LuaAPI.lua_pushstring(L, __cl_gen_to_be_invoked.summon_behaviour_tree);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_attack_rotaion(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.DBActor.ActorData __cl_gen_to_be_invoked = (xc.DBActor.ActorData)translator.FastGetCSObj(L, 1);
                LuaAPI.xlua_pushinteger(L, __cl_gen_to_be_invoked.attack_rotaion);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_hp_bar_count(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.DBActor.ActorData __cl_gen_to_be_invoked = (xc.DBActor.ActorData)translator.FastGetCSObj(L, 1);
                LuaAPI.xlua_pushinteger(L, __cl_gen_to_be_invoked.hp_bar_count);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_gravity(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.DBActor.ActorData __cl_gen_to_be_invoked = (xc.DBActor.ActorData)translator.FastGetCSObj(L, 1);
                LuaAPI.xlua_pushinteger(L, __cl_gen_to_be_invoked.gravity);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_dead_notify(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.DBActor.ActorData __cl_gen_to_be_invoked = (xc.DBActor.ActorData)translator.FastGetCSObj(L, 1);
                LuaAPI.lua_pushstring(L, __cl_gen_to_be_invoked.dead_notify);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_spawn_timeline(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.DBActor.ActorData __cl_gen_to_be_invoked = (xc.DBActor.ActorData)translator.FastGetCSObj(L, 1);
                LuaAPI.xlua_pushuint(L, __cl_gen_to_be_invoked.spawn_timeline);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_dead_timeline(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.DBActor.ActorData __cl_gen_to_be_invoked = (xc.DBActor.ActorData)translator.FastGetCSObj(L, 1);
                LuaAPI.xlua_pushuint(L, __cl_gen_to_be_invoked.dead_timeline);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_is_hide_shadow(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.DBActor.ActorData __cl_gen_to_be_invoked = (xc.DBActor.ActorData)translator.FastGetCSObj(L, 1);
                LuaAPI.lua_pushboolean(L, __cl_gen_to_be_invoked.is_hide_shadow);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_is_hide_select_effect(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.DBActor.ActorData __cl_gen_to_be_invoked = (xc.DBActor.ActorData)translator.FastGetCSObj(L, 1);
                LuaAPI.lua_pushboolean(L, __cl_gen_to_be_invoked.is_hide_select_effect);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_attr_param(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.DBActor.ActorData __cl_gen_to_be_invoked = (xc.DBActor.ActorData)translator.FastGetCSObj(L, 1);
                LuaAPI.xlua_pushuint(L, __cl_gen_to_be_invoked.attr_param);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_default_actor_id(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.DBActor.ActorData __cl_gen_to_be_invoked = (xc.DBActor.ActorData)translator.FastGetCSObj(L, 1);
                LuaAPI.xlua_pushuint(L, __cl_gen_to_be_invoked.default_actor_id);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_name(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.DBActor.ActorData __cl_gen_to_be_invoked = (xc.DBActor.ActorData)translator.FastGetCSObj(L, 1);
                __cl_gen_to_be_invoked.name = LuaAPI.lua_tostring(L, 2);
            
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_vocation(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.DBActor.ActorData __cl_gen_to_be_invoked = (xc.DBActor.ActorData)translator.FastGetCSObj(L, 1);
                __cl_gen_to_be_invoked.vocation = (byte)LuaAPI.lua_tonumber(L, 2);
            
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_level(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.DBActor.ActorData __cl_gen_to_be_invoked = (xc.DBActor.ActorData)translator.FastGetCSObj(L, 1);
                __cl_gen_to_be_invoked.level = LuaAPI.xlua_touint(L, 2);
            
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_color(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.DBActor.ActorData __cl_gen_to_be_invoked = (xc.DBActor.ActorData)translator.FastGetCSObj(L, 1);
                Monster.QualityColor __cl_gen_value;translator.Get(L, 2, out __cl_gen_value);
				__cl_gen_to_be_invoked.color = __cl_gen_value;
            
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_type(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.DBActor.ActorData __cl_gen_to_be_invoked = (xc.DBActor.ActorData)translator.FastGetCSObj(L, 1);
                __cl_gen_to_be_invoked.type = (byte)LuaAPI.lua_tonumber(L, 2);
            
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_war_tag(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.DBActor.ActorData __cl_gen_to_be_invoked = (xc.DBActor.ActorData)translator.FastGetCSObj(L, 1);
                __cl_gen_to_be_invoked.war_tag = (byte)LuaAPI.lua_tonumber(L, 2);
            
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_race_id(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.DBActor.ActorData __cl_gen_to_be_invoked = (xc.DBActor.ActorData)translator.FastGetCSObj(L, 1);
                __cl_gen_to_be_invoked.race_id = LuaAPI.xlua_touint(L, 2);
            
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_skill_count(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.DBActor.ActorData __cl_gen_to_be_invoked = (xc.DBActor.ActorData)translator.FastGetCSObj(L, 1);
                __cl_gen_to_be_invoked.skill_count = (byte)LuaAPI.lua_tonumber(L, 2);
            
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_skill_idx(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.DBActor.ActorData __cl_gen_to_be_invoked = (xc.DBActor.ActorData)translator.FastGetCSObj(L, 1);
                __cl_gen_to_be_invoked.skill_idx = (uint[])translator.GetObject(L, 2, typeof(uint[]));
            
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_cast_rate(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.DBActor.ActorData __cl_gen_to_be_invoked = (xc.DBActor.ActorData)translator.FastGetCSObj(L, 1);
                __cl_gen_to_be_invoked.cast_rate = LuaAPI.lua_tobytes(L, 2);
            
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_model_id(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.DBActor.ActorData __cl_gen_to_be_invoked = (xc.DBActor.ActorData)translator.FastGetCSObj(L, 1);
                __cl_gen_to_be_invoked.model_id = LuaAPI.xlua_touint(L, 2);
            
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_runspeed(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.DBActor.ActorData __cl_gen_to_be_invoked = (xc.DBActor.ActorData)translator.FastGetCSObj(L, 1);
                __cl_gen_to_be_invoked.runspeed = (ushort)LuaAPI.xlua_tointeger(L, 2);
            
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_motion_radius(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.DBActor.ActorData __cl_gen_to_be_invoked = (xc.DBActor.ActorData)translator.FastGetCSObj(L, 1);
                __cl_gen_to_be_invoked.motion_radius = (byte)LuaAPI.lua_tonumber(L, 2);
            
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_behaviour_tree(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.DBActor.ActorData __cl_gen_to_be_invoked = (xc.DBActor.ActorData)translator.FastGetCSObj(L, 1);
                __cl_gen_to_be_invoked.behaviour_tree = LuaAPI.lua_tostring(L, 2);
            
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_summon_behaviour_tree(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.DBActor.ActorData __cl_gen_to_be_invoked = (xc.DBActor.ActorData)translator.FastGetCSObj(L, 1);
                __cl_gen_to_be_invoked.summon_behaviour_tree = LuaAPI.lua_tostring(L, 2);
            
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_attack_rotaion(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.DBActor.ActorData __cl_gen_to_be_invoked = (xc.DBActor.ActorData)translator.FastGetCSObj(L, 1);
                __cl_gen_to_be_invoked.attack_rotaion = (byte)LuaAPI.lua_tonumber(L, 2);
            
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_hp_bar_count(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.DBActor.ActorData __cl_gen_to_be_invoked = (xc.DBActor.ActorData)translator.FastGetCSObj(L, 1);
                __cl_gen_to_be_invoked.hp_bar_count = (byte)LuaAPI.lua_tonumber(L, 2);
            
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_gravity(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.DBActor.ActorData __cl_gen_to_be_invoked = (xc.DBActor.ActorData)translator.FastGetCSObj(L, 1);
                __cl_gen_to_be_invoked.gravity = (ushort)LuaAPI.xlua_tointeger(L, 2);
            
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_dead_notify(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.DBActor.ActorData __cl_gen_to_be_invoked = (xc.DBActor.ActorData)translator.FastGetCSObj(L, 1);
                __cl_gen_to_be_invoked.dead_notify = LuaAPI.lua_tobytes(L, 2);
            
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_spawn_timeline(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.DBActor.ActorData __cl_gen_to_be_invoked = (xc.DBActor.ActorData)translator.FastGetCSObj(L, 1);
                __cl_gen_to_be_invoked.spawn_timeline = LuaAPI.xlua_touint(L, 2);
            
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_dead_timeline(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.DBActor.ActorData __cl_gen_to_be_invoked = (xc.DBActor.ActorData)translator.FastGetCSObj(L, 1);
                __cl_gen_to_be_invoked.dead_timeline = LuaAPI.xlua_touint(L, 2);
            
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_is_hide_shadow(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.DBActor.ActorData __cl_gen_to_be_invoked = (xc.DBActor.ActorData)translator.FastGetCSObj(L, 1);
                __cl_gen_to_be_invoked.is_hide_shadow = LuaAPI.lua_toboolean(L, 2);
            
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_is_hide_select_effect(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.DBActor.ActorData __cl_gen_to_be_invoked = (xc.DBActor.ActorData)translator.FastGetCSObj(L, 1);
                __cl_gen_to_be_invoked.is_hide_select_effect = LuaAPI.lua_toboolean(L, 2);
            
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_attr_param(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.DBActor.ActorData __cl_gen_to_be_invoked = (xc.DBActor.ActorData)translator.FastGetCSObj(L, 1);
                __cl_gen_to_be_invoked.attr_param = LuaAPI.xlua_touint(L, 2);
            
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_default_actor_id(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.DBActor.ActorData __cl_gen_to_be_invoked = (xc.DBActor.ActorData)translator.FastGetCSObj(L, 1);
                __cl_gen_to_be_invoked.default_actor_id = LuaAPI.xlua_touint(L, 2);
            
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 0;
        }
        
		
		
		
		
    }
}
