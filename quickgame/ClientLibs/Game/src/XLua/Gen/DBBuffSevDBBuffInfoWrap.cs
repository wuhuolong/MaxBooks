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
    public class DBBuffSevDBBuffInfoWrap
    {
        public static void __Register(RealStatePtr L)
        {
			ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			XUtils.BeginObjectRegister(typeof(DBBuffSev.DBBuffInfo), L, translator, 0, 1, 25, 25);
			
			XUtils.RegisterFunc(L, XUtils.METHOD_IDX, "HasFlag", _m_HasFlag);
			
			
			XUtils.RegisterFunc(L, XUtils.GETTER_IDX, "buff_id", _g_get_buff_id);
            XUtils.RegisterFunc(L, XUtils.GETTER_IDX, "name", _g_get_name);
            XUtils.RegisterFunc(L, XUtils.GETTER_IDX, "is_show_tip", _g_get_is_show_tip);
            XUtils.RegisterFunc(L, XUtils.GETTER_IDX, "max_add_num", _g_get_max_add_num);
            XUtils.RegisterFunc(L, XUtils.GETTER_IDX, "add_eff", _g_get_add_eff);
            XUtils.RegisterFunc(L, XUtils.GETTER_IDX, "des", _g_get_des);
            XUtils.RegisterFunc(L, XUtils.GETTER_IDX, "battle_effect_type", _g_get_battle_effect_type);
            XUtils.RegisterFunc(L, XUtils.GETTER_IDX, "attr_effect_type", _g_get_attr_effect_type);
            XUtils.RegisterFunc(L, XUtils.GETTER_IDX, "buff_flags", _g_get_buff_flags);
            XUtils.RegisterFunc(L, XUtils.GETTER_IDX, "delay_time", _g_get_delay_time);
            XUtils.RegisterFunc(L, XUtils.GETTER_IDX, "life_time", _g_get_life_time);
            XUtils.RegisterFunc(L, XUtils.GETTER_IDX, "shape_shift", _g_get_shape_shift);
            XUtils.RegisterFunc(L, XUtils.GETTER_IDX, "shift_state", _g_get_shift_state);
            XUtils.RegisterFunc(L, XUtils.GETTER_IDX, "period_time", _g_get_period_time);
            XUtils.RegisterFunc(L, XUtils.GETTER_IDX, "icon", _g_get_icon);
            XUtils.RegisterFunc(L, XUtils.GETTER_IDX, "effect_file", _g_get_effect_file);
            XUtils.RegisterFunc(L, XUtils.GETTER_IDX, "priority", _g_get_priority);
            XUtils.RegisterFunc(L, XUtils.GETTER_IDX, "force_show", _g_get_force_show);
            XUtils.RegisterFunc(L, XUtils.GETTER_IDX, "other_hide", _g_get_other_hide);
            XUtils.RegisterFunc(L, XUtils.GETTER_IDX, "bind_pos", _g_get_bind_pos);
            XUtils.RegisterFunc(L, XUtils.GETTER_IDX, "follow_target", _g_get_follow_target);
            XUtils.RegisterFunc(L, XUtils.GETTER_IDX, "scale", _g_get_scale);
            XUtils.RegisterFunc(L, XUtils.GETTER_IDX, "auto_scale", _g_get_auto_scale);
            XUtils.RegisterFunc(L, XUtils.GETTER_IDX, "hide_countDown", _g_get_hide_countDown);
            XUtils.RegisterFunc(L, XUtils.GETTER_IDX, "max_count", _g_get_max_count);
            
			XUtils.RegisterFunc(L, XUtils.SETTER_IDX, "buff_id", _s_set_buff_id);
            XUtils.RegisterFunc(L, XUtils.SETTER_IDX, "name", _s_set_name);
            XUtils.RegisterFunc(L, XUtils.SETTER_IDX, "is_show_tip", _s_set_is_show_tip);
            XUtils.RegisterFunc(L, XUtils.SETTER_IDX, "max_add_num", _s_set_max_add_num);
            XUtils.RegisterFunc(L, XUtils.SETTER_IDX, "add_eff", _s_set_add_eff);
            XUtils.RegisterFunc(L, XUtils.SETTER_IDX, "des", _s_set_des);
            XUtils.RegisterFunc(L, XUtils.SETTER_IDX, "battle_effect_type", _s_set_battle_effect_type);
            XUtils.RegisterFunc(L, XUtils.SETTER_IDX, "attr_effect_type", _s_set_attr_effect_type);
            XUtils.RegisterFunc(L, XUtils.SETTER_IDX, "buff_flags", _s_set_buff_flags);
            XUtils.RegisterFunc(L, XUtils.SETTER_IDX, "delay_time", _s_set_delay_time);
            XUtils.RegisterFunc(L, XUtils.SETTER_IDX, "life_time", _s_set_life_time);
            XUtils.RegisterFunc(L, XUtils.SETTER_IDX, "shape_shift", _s_set_shape_shift);
            XUtils.RegisterFunc(L, XUtils.SETTER_IDX, "shift_state", _s_set_shift_state);
            XUtils.RegisterFunc(L, XUtils.SETTER_IDX, "period_time", _s_set_period_time);
            XUtils.RegisterFunc(L, XUtils.SETTER_IDX, "icon", _s_set_icon);
            XUtils.RegisterFunc(L, XUtils.SETTER_IDX, "effect_file", _s_set_effect_file);
            XUtils.RegisterFunc(L, XUtils.SETTER_IDX, "priority", _s_set_priority);
            XUtils.RegisterFunc(L, XUtils.SETTER_IDX, "force_show", _s_set_force_show);
            XUtils.RegisterFunc(L, XUtils.SETTER_IDX, "other_hide", _s_set_other_hide);
            XUtils.RegisterFunc(L, XUtils.SETTER_IDX, "bind_pos", _s_set_bind_pos);
            XUtils.RegisterFunc(L, XUtils.SETTER_IDX, "follow_target", _s_set_follow_target);
            XUtils.RegisterFunc(L, XUtils.SETTER_IDX, "scale", _s_set_scale);
            XUtils.RegisterFunc(L, XUtils.SETTER_IDX, "auto_scale", _s_set_auto_scale);
            XUtils.RegisterFunc(L, XUtils.SETTER_IDX, "hide_countDown", _s_set_hide_countDown);
            XUtils.RegisterFunc(L, XUtils.SETTER_IDX, "max_count", _s_set_max_count);
            
			XUtils.EndObjectRegister(typeof(DBBuffSev.DBBuffInfo), L, translator, null, null,
			    null, null, null);

		    XUtils.BeginClassRegister(typeof(DBBuffSev.DBBuffInfo), L, __CreateInstance, 1, 0, 0);
			
			
            
            XUtils.RegisterObject(L, translator, XUtils.CLS_IDX, "UnderlyingSystemType", typeof(DBBuffSev.DBBuffInfo));
			
			
			XUtils.EndClassRegister(typeof(DBBuffSev.DBBuffInfo), L, translator);
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int __CreateInstance(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			try {
				if(LuaAPI.lua_gettop(L) == 1)
				{
					
					DBBuffSev.DBBuffInfo __cl_gen_ret = new DBBuffSev.DBBuffInfo();
					translator.Push(L, __cl_gen_ret);
					return 1;
				}
				
			}
			catch(System.Exception __gen_e) {
				return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
			}
            return LuaAPI.luaL_error(L, "invalid arguments to DBBuffSev.DBBuffInfo constructor!");
            
        }
        
		
        
		
        
        
        
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_HasFlag(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            DBBuffSev.DBBuffInfo __cl_gen_to_be_invoked = (DBBuffSev.DBBuffInfo)translator.FastGetCSObj(L, 1);
            
            
            try {
                
                {
                    xc.Buff.BuffFlags kTargetFlag;translator.Get(L, 2, out kTargetFlag);
                    
                        bool __cl_gen_ret = __cl_gen_to_be_invoked.HasFlag( kTargetFlag );
                        LuaAPI.lua_pushboolean(L, __cl_gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        
        
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_buff_id(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                DBBuffSev.DBBuffInfo __cl_gen_to_be_invoked = (DBBuffSev.DBBuffInfo)translator.FastGetCSObj(L, 1);
                LuaAPI.xlua_pushuint(L, __cl_gen_to_be_invoked.buff_id);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_name(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                DBBuffSev.DBBuffInfo __cl_gen_to_be_invoked = (DBBuffSev.DBBuffInfo)translator.FastGetCSObj(L, 1);
                LuaAPI.lua_pushstring(L, __cl_gen_to_be_invoked.name);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_is_show_tip(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                DBBuffSev.DBBuffInfo __cl_gen_to_be_invoked = (DBBuffSev.DBBuffInfo)translator.FastGetCSObj(L, 1);
                LuaAPI.lua_pushboolean(L, __cl_gen_to_be_invoked.is_show_tip);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_max_add_num(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                DBBuffSev.DBBuffInfo __cl_gen_to_be_invoked = (DBBuffSev.DBBuffInfo)translator.FastGetCSObj(L, 1);
                LuaAPI.xlua_pushinteger(L, __cl_gen_to_be_invoked.max_add_num);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_add_eff(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                DBBuffSev.DBBuffInfo __cl_gen_to_be_invoked = (DBBuffSev.DBBuffInfo)translator.FastGetCSObj(L, 1);
                translator.Push(L, __cl_gen_to_be_invoked.add_eff);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_des(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                DBBuffSev.DBBuffInfo __cl_gen_to_be_invoked = (DBBuffSev.DBBuffInfo)translator.FastGetCSObj(L, 1);
                LuaAPI.lua_pushstring(L, __cl_gen_to_be_invoked.des);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_battle_effect_type(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                DBBuffSev.DBBuffInfo __cl_gen_to_be_invoked = (DBBuffSev.DBBuffInfo)translator.FastGetCSObj(L, 1);
                translator.Push(L, __cl_gen_to_be_invoked.battle_effect_type);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_attr_effect_type(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                DBBuffSev.DBBuffInfo __cl_gen_to_be_invoked = (DBBuffSev.DBBuffInfo)translator.FastGetCSObj(L, 1);
                translator.Push(L, __cl_gen_to_be_invoked.attr_effect_type);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_buff_flags(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                DBBuffSev.DBBuffInfo __cl_gen_to_be_invoked = (DBBuffSev.DBBuffInfo)translator.FastGetCSObj(L, 1);
                LuaAPI.xlua_pushinteger(L, __cl_gen_to_be_invoked.buff_flags);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_delay_time(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                DBBuffSev.DBBuffInfo __cl_gen_to_be_invoked = (DBBuffSev.DBBuffInfo)translator.FastGetCSObj(L, 1);
                LuaAPI.lua_pushnumber(L, __cl_gen_to_be_invoked.delay_time);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_life_time(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                DBBuffSev.DBBuffInfo __cl_gen_to_be_invoked = (DBBuffSev.DBBuffInfo)translator.FastGetCSObj(L, 1);
                LuaAPI.lua_pushnumber(L, __cl_gen_to_be_invoked.life_time);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_shape_shift(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                DBBuffSev.DBBuffInfo __cl_gen_to_be_invoked = (DBBuffSev.DBBuffInfo)translator.FastGetCSObj(L, 1);
                LuaAPI.xlua_pushuint(L, __cl_gen_to_be_invoked.shape_shift);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_shift_state(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                DBBuffSev.DBBuffInfo __cl_gen_to_be_invoked = (DBBuffSev.DBBuffInfo)translator.FastGetCSObj(L, 1);
                LuaAPI.xlua_pushinteger(L, __cl_gen_to_be_invoked.shift_state);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_period_time(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                DBBuffSev.DBBuffInfo __cl_gen_to_be_invoked = (DBBuffSev.DBBuffInfo)translator.FastGetCSObj(L, 1);
                LuaAPI.lua_pushnumber(L, __cl_gen_to_be_invoked.period_time);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_icon(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                DBBuffSev.DBBuffInfo __cl_gen_to_be_invoked = (DBBuffSev.DBBuffInfo)translator.FastGetCSObj(L, 1);
                LuaAPI.lua_pushstring(L, __cl_gen_to_be_invoked.icon);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_effect_file(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                DBBuffSev.DBBuffInfo __cl_gen_to_be_invoked = (DBBuffSev.DBBuffInfo)translator.FastGetCSObj(L, 1);
                LuaAPI.lua_pushstring(L, __cl_gen_to_be_invoked.effect_file);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_priority(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                DBBuffSev.DBBuffInfo __cl_gen_to_be_invoked = (DBBuffSev.DBBuffInfo)translator.FastGetCSObj(L, 1);
                LuaAPI.xlua_pushinteger(L, __cl_gen_to_be_invoked.priority);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_force_show(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                DBBuffSev.DBBuffInfo __cl_gen_to_be_invoked = (DBBuffSev.DBBuffInfo)translator.FastGetCSObj(L, 1);
                LuaAPI.lua_pushboolean(L, __cl_gen_to_be_invoked.force_show);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_other_hide(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                DBBuffSev.DBBuffInfo __cl_gen_to_be_invoked = (DBBuffSev.DBBuffInfo)translator.FastGetCSObj(L, 1);
                LuaAPI.lua_pushboolean(L, __cl_gen_to_be_invoked.other_hide);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_bind_pos(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                DBBuffSev.DBBuffInfo __cl_gen_to_be_invoked = (DBBuffSev.DBBuffInfo)translator.FastGetCSObj(L, 1);
                translator.PushDBBuffSevBindPos(L, __cl_gen_to_be_invoked.bind_pos);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_follow_target(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                DBBuffSev.DBBuffInfo __cl_gen_to_be_invoked = (DBBuffSev.DBBuffInfo)translator.FastGetCSObj(L, 1);
                LuaAPI.lua_pushboolean(L, __cl_gen_to_be_invoked.follow_target);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_scale(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                DBBuffSev.DBBuffInfo __cl_gen_to_be_invoked = (DBBuffSev.DBBuffInfo)translator.FastGetCSObj(L, 1);
                LuaAPI.lua_pushnumber(L, __cl_gen_to_be_invoked.scale);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_auto_scale(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                DBBuffSev.DBBuffInfo __cl_gen_to_be_invoked = (DBBuffSev.DBBuffInfo)translator.FastGetCSObj(L, 1);
                LuaAPI.lua_pushboolean(L, __cl_gen_to_be_invoked.auto_scale);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_hide_countDown(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                DBBuffSev.DBBuffInfo __cl_gen_to_be_invoked = (DBBuffSev.DBBuffInfo)translator.FastGetCSObj(L, 1);
                LuaAPI.lua_pushboolean(L, __cl_gen_to_be_invoked.hide_countDown);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_max_count(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                DBBuffSev.DBBuffInfo __cl_gen_to_be_invoked = (DBBuffSev.DBBuffInfo)translator.FastGetCSObj(L, 1);
                LuaAPI.xlua_pushinteger(L, __cl_gen_to_be_invoked.max_count);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_buff_id(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                DBBuffSev.DBBuffInfo __cl_gen_to_be_invoked = (DBBuffSev.DBBuffInfo)translator.FastGetCSObj(L, 1);
                __cl_gen_to_be_invoked.buff_id = LuaAPI.xlua_touint(L, 2);
            
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_name(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                DBBuffSev.DBBuffInfo __cl_gen_to_be_invoked = (DBBuffSev.DBBuffInfo)translator.FastGetCSObj(L, 1);
                __cl_gen_to_be_invoked.name = LuaAPI.lua_tostring(L, 2);
            
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_is_show_tip(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                DBBuffSev.DBBuffInfo __cl_gen_to_be_invoked = (DBBuffSev.DBBuffInfo)translator.FastGetCSObj(L, 1);
                __cl_gen_to_be_invoked.is_show_tip = LuaAPI.lua_toboolean(L, 2);
            
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_max_add_num(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                DBBuffSev.DBBuffInfo __cl_gen_to_be_invoked = (DBBuffSev.DBBuffInfo)translator.FastGetCSObj(L, 1);
                __cl_gen_to_be_invoked.max_add_num = (ushort)LuaAPI.xlua_tointeger(L, 2);
            
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_add_eff(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                DBBuffSev.DBBuffInfo __cl_gen_to_be_invoked = (DBBuffSev.DBBuffInfo)translator.FastGetCSObj(L, 1);
                __cl_gen_to_be_invoked.add_eff = (System.Collections.Generic.List<uint>)translator.GetObject(L, 2, typeof(System.Collections.Generic.List<uint>));
            
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_des(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                DBBuffSev.DBBuffInfo __cl_gen_to_be_invoked = (DBBuffSev.DBBuffInfo)translator.FastGetCSObj(L, 1);
                __cl_gen_to_be_invoked.des = LuaAPI.lua_tostring(L, 2);
            
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_battle_effect_type(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                DBBuffSev.DBBuffInfo __cl_gen_to_be_invoked = (DBBuffSev.DBBuffInfo)translator.FastGetCSObj(L, 1);
                xc.BattleStatusType __cl_gen_value;translator.Get(L, 2, out __cl_gen_value);
				__cl_gen_to_be_invoked.battle_effect_type = __cl_gen_value;
            
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_attr_effect_type(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                DBBuffSev.DBBuffInfo __cl_gen_to_be_invoked = (DBBuffSev.DBBuffInfo)translator.FastGetCSObj(L, 1);
                __cl_gen_to_be_invoked.attr_effect_type = (int[])translator.GetObject(L, 2, typeof(int[]));
            
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_buff_flags(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                DBBuffSev.DBBuffInfo __cl_gen_to_be_invoked = (DBBuffSev.DBBuffInfo)translator.FastGetCSObj(L, 1);
                __cl_gen_to_be_invoked.buff_flags = (ushort)LuaAPI.xlua_tointeger(L, 2);
            
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_delay_time(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                DBBuffSev.DBBuffInfo __cl_gen_to_be_invoked = (DBBuffSev.DBBuffInfo)translator.FastGetCSObj(L, 1);
                __cl_gen_to_be_invoked.delay_time = (float)LuaAPI.lua_tonumber(L, 2);
            
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_life_time(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                DBBuffSev.DBBuffInfo __cl_gen_to_be_invoked = (DBBuffSev.DBBuffInfo)translator.FastGetCSObj(L, 1);
                __cl_gen_to_be_invoked.life_time = (float)LuaAPI.lua_tonumber(L, 2);
            
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_shape_shift(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                DBBuffSev.DBBuffInfo __cl_gen_to_be_invoked = (DBBuffSev.DBBuffInfo)translator.FastGetCSObj(L, 1);
                __cl_gen_to_be_invoked.shape_shift = LuaAPI.xlua_touint(L, 2);
            
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_shift_state(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                DBBuffSev.DBBuffInfo __cl_gen_to_be_invoked = (DBBuffSev.DBBuffInfo)translator.FastGetCSObj(L, 1);
                __cl_gen_to_be_invoked.shift_state = (byte)LuaAPI.lua_tonumber(L, 2);
            
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_period_time(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                DBBuffSev.DBBuffInfo __cl_gen_to_be_invoked = (DBBuffSev.DBBuffInfo)translator.FastGetCSObj(L, 1);
                __cl_gen_to_be_invoked.period_time = (float)LuaAPI.lua_tonumber(L, 2);
            
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_icon(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                DBBuffSev.DBBuffInfo __cl_gen_to_be_invoked = (DBBuffSev.DBBuffInfo)translator.FastGetCSObj(L, 1);
                __cl_gen_to_be_invoked.icon = LuaAPI.lua_tostring(L, 2);
            
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_effect_file(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                DBBuffSev.DBBuffInfo __cl_gen_to_be_invoked = (DBBuffSev.DBBuffInfo)translator.FastGetCSObj(L, 1);
                __cl_gen_to_be_invoked.effect_file = LuaAPI.lua_tostring(L, 2);
            
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_priority(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                DBBuffSev.DBBuffInfo __cl_gen_to_be_invoked = (DBBuffSev.DBBuffInfo)translator.FastGetCSObj(L, 1);
                __cl_gen_to_be_invoked.priority = (ushort)LuaAPI.xlua_tointeger(L, 2);
            
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_force_show(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                DBBuffSev.DBBuffInfo __cl_gen_to_be_invoked = (DBBuffSev.DBBuffInfo)translator.FastGetCSObj(L, 1);
                __cl_gen_to_be_invoked.force_show = LuaAPI.lua_toboolean(L, 2);
            
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_other_hide(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                DBBuffSev.DBBuffInfo __cl_gen_to_be_invoked = (DBBuffSev.DBBuffInfo)translator.FastGetCSObj(L, 1);
                __cl_gen_to_be_invoked.other_hide = LuaAPI.lua_toboolean(L, 2);
            
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_bind_pos(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                DBBuffSev.DBBuffInfo __cl_gen_to_be_invoked = (DBBuffSev.DBBuffInfo)translator.FastGetCSObj(L, 1);
                DBBuffSev.BindPos __cl_gen_value;translator.Get(L, 2, out __cl_gen_value);
				__cl_gen_to_be_invoked.bind_pos = __cl_gen_value;
            
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_follow_target(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                DBBuffSev.DBBuffInfo __cl_gen_to_be_invoked = (DBBuffSev.DBBuffInfo)translator.FastGetCSObj(L, 1);
                __cl_gen_to_be_invoked.follow_target = LuaAPI.lua_toboolean(L, 2);
            
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_scale(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                DBBuffSev.DBBuffInfo __cl_gen_to_be_invoked = (DBBuffSev.DBBuffInfo)translator.FastGetCSObj(L, 1);
                __cl_gen_to_be_invoked.scale = (float)LuaAPI.lua_tonumber(L, 2);
            
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_auto_scale(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                DBBuffSev.DBBuffInfo __cl_gen_to_be_invoked = (DBBuffSev.DBBuffInfo)translator.FastGetCSObj(L, 1);
                __cl_gen_to_be_invoked.auto_scale = LuaAPI.lua_toboolean(L, 2);
            
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_hide_countDown(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                DBBuffSev.DBBuffInfo __cl_gen_to_be_invoked = (DBBuffSev.DBBuffInfo)translator.FastGetCSObj(L, 1);
                __cl_gen_to_be_invoked.hide_countDown = LuaAPI.lua_toboolean(L, 2);
            
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_max_count(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                DBBuffSev.DBBuffInfo __cl_gen_to_be_invoked = (DBBuffSev.DBBuffInfo)translator.FastGetCSObj(L, 1);
                __cl_gen_to_be_invoked.max_count = LuaAPI.xlua_tointeger(L, 2);
            
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 0;
        }
        
		
		
		
		
    }
}
