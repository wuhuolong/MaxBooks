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
    public class xcGoodsWrap
    {
        public static void __Register(RealStatePtr L)
        {
			ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			XUtils.BeginObjectRegister(typeof(xc.Goods), L, translator, 0, 7, 61, 61);
			
			XUtils.RegisterFunc(L, XUtils.METHOD_IDX, "Copy", _m_Copy);
			XUtils.RegisterFunc(L, XUtils.METHOD_IDX, "Clone", _m_Clone);
			XUtils.RegisterFunc(L, XUtils.METHOD_IDX, "RefreshEquipUp", _m_RefreshEquipUp);
			XUtils.RegisterFunc(L, XUtils.METHOD_IDX, "RefreshDecorateUp", _m_RefreshDecorateUp);
			XUtils.RegisterFunc(L, XUtils.METHOD_IDX, "ParseClientGoodsStr_inner", _m_ParseClientGoodsStr_inner);
			XUtils.RegisterFunc(L, XUtils.METHOD_IDX, "GetClientGoodsStr_inner", _m_GetClientGoodsStr_inner);
			XUtils.RegisterFunc(L, XUtils.METHOD_IDX, "IsInEnableTime", _m_IsInEnableTime);
			
			
			XUtils.RegisterFunc(L, XUtils.GETTER_IDX, "id", _g_get_id);
            XUtils.RegisterFunc(L, XUtils.GETTER_IDX, "bind", _g_get_bind);
            XUtils.RegisterFunc(L, XUtils.GETTER_IDX, "type_idx", _g_get_type_idx);
            XUtils.RegisterFunc(L, XUtils.GETTER_IDX, "color_type", _g_get_color_type);
            XUtils.RegisterFunc(L, XUtils.GETTER_IDX, "icon_id", _g_get_icon_id);
            XUtils.RegisterFunc(L, XUtils.GETTER_IDX, "name", _g_get_name);
            XUtils.RegisterFunc(L, XUtils.GETTER_IDX, "raw_name", _g_get_raw_name);
            XUtils.RegisterFunc(L, XUtils.GETTER_IDX, "num", _g_get_num);
            XUtils.RegisterFunc(L, XUtils.GETTER_IDX, "src_description", _g_get_src_description);
            XUtils.RegisterFunc(L, XUtils.GETTER_IDX, "description", _g_get_description);
            XUtils.RegisterFunc(L, XUtils.GETTER_IDX, "sub_type", _g_get_sub_type);
            XUtils.RegisterFunc(L, XUtils.GETTER_IDX, "drop_effect", _g_get_drop_effect);
            XUtils.RegisterFunc(L, XUtils.GETTER_IDX, "effect", _g_get_effect);
            XUtils.RegisterFunc(L, XUtils.GETTER_IDX, "can_use", _g_get_can_use);
            XUtils.RegisterFunc(L, XUtils.GETTER_IDX, "use_lv", _g_get_use_lv);
            XUtils.RegisterFunc(L, XUtils.GETTER_IDX, "tips_show", _g_get_tips_show);
            XUtils.RegisterFunc(L, XUtils.GETTER_IDX, "start_cd", _g_get_start_cd);
            XUtils.RegisterFunc(L, XUtils.GETTER_IDX, "cd", _g_get_cd);
            XUtils.RegisterFunc(L, XUtils.GETTER_IDX, "expire_time", _g_get_expire_time);
            XUtils.RegisterFunc(L, XUtils.GETTER_IDX, "expire_time_inTmpl", _g_get_expire_time_inTmpl);
            XUtils.RegisterFunc(L, XUtils.GETTER_IDX, "main_type", _g_get_main_type);
            XUtils.RegisterFunc(L, XUtils.GETTER_IDX, "arg", _g_get_arg);
            XUtils.RegisterFunc(L, XUtils.GETTER_IDX, "client_use", _g_get_client_use);
            XUtils.RegisterFunc(L, XUtils.GETTER_IDX, "need_count", _g_get_need_count);
            XUtils.RegisterFunc(L, XUtils.GETTER_IDX, "recycle_price", _g_get_recycle_price);
            XUtils.RegisterFunc(L, XUtils.GETTER_IDX, "use_job", _g_get_use_job);
            XUtils.RegisterFunc(L, XUtils.GETTER_IDX, "use_transfer", _g_get_use_transfer);
            XUtils.RegisterFunc(L, XUtils.GETTER_IDX, "gain_text", _g_get_gain_text);
            XUtils.RegisterFunc(L, XUtils.GETTER_IDX, "gain_from", _g_get_gain_from);
            XUtils.RegisterFunc(L, XUtils.GETTER_IDX, "is_quickuse", _g_get_is_quickuse);
            XUtils.RegisterFunc(L, XUtils.GETTER_IDX, "is_quickuse_always", _g_get_is_quickuse_always);
            XUtils.RegisterFunc(L, XUtils.GETTER_IDX, "is_sell_confirmation", _g_get_is_sell_confirmation);
            XUtils.RegisterFunc(L, XUtils.GETTER_IDX, "sort_id", _g_get_sort_id);
            XUtils.RegisterFunc(L, XUtils.GETTER_IDX, "sort_top", _g_get_sort_top);
            XUtils.RegisterFunc(L, XUtils.GETTER_IDX, "is_equipUp", _g_get_is_equipUp);
            XUtils.RegisterFunc(L, XUtils.GETTER_IDX, "is_equipDown", _g_get_is_equipDown);
            XUtils.RegisterFunc(L, XUtils.GETTER_IDX, "is_decorateUp", _g_get_is_decorateUp);
            XUtils.RegisterFunc(L, XUtils.GETTER_IDX, "is_mutil_use", _g_get_is_mutil_use);
            XUtils.RegisterFunc(L, XUtils.GETTER_IDX, "cd_id", _g_get_cd_id);
            XUtils.RegisterFunc(L, XUtils.GETTER_IDX, "isUpdateFlag", _g_get_isUpdateFlag);
            XUtils.RegisterFunc(L, XUtils.GETTER_IDX, "isDefaultGoods", _g_get_isDefaultGoods);
            XUtils.RegisterFunc(L, XUtils.GETTER_IDX, "unknownGoodsId", _g_get_unknownGoodsId);
            XUtils.RegisterFunc(L, XUtils.GETTER_IDX, "m_group_info", _g_get_m_group_info);
            XUtils.RegisterFunc(L, XUtils.GETTER_IDX, "price_recommend", _g_get_price_recommend);
            XUtils.RegisterFunc(L, XUtils.GETTER_IDX, "price_lower_limit", _g_get_price_lower_limit);
            XUtils.RegisterFunc(L, XUtils.GETTER_IDX, "price_upper_limit", _g_get_price_upper_limit);
            XUtils.RegisterFunc(L, XUtils.GETTER_IDX, "mktype_1", _g_get_mktype_1);
            XUtils.RegisterFunc(L, XUtils.GETTER_IDX, "mktype_2", _g_get_mktype_2);
            XUtils.RegisterFunc(L, XUtils.GETTER_IDX, "daily_use_limit", _g_get_daily_use_limit);
            XUtils.RegisterFunc(L, XUtils.GETTER_IDX, "guild_wpoint", _g_get_guild_wpoint);
            XUtils.RegisterFunc(L, XUtils.GETTER_IDX, "max_stack", _g_get_max_stack);
            XUtils.RegisterFunc(L, XUtils.GETTER_IDX, "create_time", _g_get_create_time);
            XUtils.RegisterFunc(L, XUtils.GETTER_IDX, "is_display_goods", _g_get_is_display_goods);
            XUtils.RegisterFunc(L, XUtils.GETTER_IDX, "wing_exp", _g_get_wing_exp);
            XUtils.RegisterFunc(L, XUtils.GETTER_IDX, "m_level_in_add_lv_exp", _g_get_m_level_in_add_lv_exp);
            XUtils.RegisterFunc(L, XUtils.GETTER_IDX, "is_quickuse_autoUse", _g_get_is_quickuse_autoUse);
            XUtils.RegisterFunc(L, XUtils.GETTER_IDX, "is_deleted", _g_get_is_deleted);
            XUtils.RegisterFunc(L, XUtils.GETTER_IDX, "show_step", _g_get_show_step);
            XUtils.RegisterFunc(L, XUtils.GETTER_IDX, "is_precious", _g_get_is_precious);
            XUtils.RegisterFunc(L, XUtils.GETTER_IDX, "discount", _g_get_discount);
            XUtils.RegisterFunc(L, XUtils.GETTER_IDX, "overdue_notice_time", _g_get_overdue_notice_time);
            
			XUtils.RegisterFunc(L, XUtils.SETTER_IDX, "id", _s_set_id);
            XUtils.RegisterFunc(L, XUtils.SETTER_IDX, "bind", _s_set_bind);
            XUtils.RegisterFunc(L, XUtils.SETTER_IDX, "type_idx", _s_set_type_idx);
            XUtils.RegisterFunc(L, XUtils.SETTER_IDX, "color_type", _s_set_color_type);
            XUtils.RegisterFunc(L, XUtils.SETTER_IDX, "icon_id", _s_set_icon_id);
            XUtils.RegisterFunc(L, XUtils.SETTER_IDX, "name", _s_set_name);
            XUtils.RegisterFunc(L, XUtils.SETTER_IDX, "raw_name", _s_set_raw_name);
            XUtils.RegisterFunc(L, XUtils.SETTER_IDX, "num", _s_set_num);
            XUtils.RegisterFunc(L, XUtils.SETTER_IDX, "src_description", _s_set_src_description);
            XUtils.RegisterFunc(L, XUtils.SETTER_IDX, "description", _s_set_description);
            XUtils.RegisterFunc(L, XUtils.SETTER_IDX, "sub_type", _s_set_sub_type);
            XUtils.RegisterFunc(L, XUtils.SETTER_IDX, "drop_effect", _s_set_drop_effect);
            XUtils.RegisterFunc(L, XUtils.SETTER_IDX, "effect", _s_set_effect);
            XUtils.RegisterFunc(L, XUtils.SETTER_IDX, "can_use", _s_set_can_use);
            XUtils.RegisterFunc(L, XUtils.SETTER_IDX, "use_lv", _s_set_use_lv);
            XUtils.RegisterFunc(L, XUtils.SETTER_IDX, "tips_show", _s_set_tips_show);
            XUtils.RegisterFunc(L, XUtils.SETTER_IDX, "start_cd", _s_set_start_cd);
            XUtils.RegisterFunc(L, XUtils.SETTER_IDX, "cd", _s_set_cd);
            XUtils.RegisterFunc(L, XUtils.SETTER_IDX, "expire_time", _s_set_expire_time);
            XUtils.RegisterFunc(L, XUtils.SETTER_IDX, "expire_time_inTmpl", _s_set_expire_time_inTmpl);
            XUtils.RegisterFunc(L, XUtils.SETTER_IDX, "main_type", _s_set_main_type);
            XUtils.RegisterFunc(L, XUtils.SETTER_IDX, "arg", _s_set_arg);
            XUtils.RegisterFunc(L, XUtils.SETTER_IDX, "client_use", _s_set_client_use);
            XUtils.RegisterFunc(L, XUtils.SETTER_IDX, "need_count", _s_set_need_count);
            XUtils.RegisterFunc(L, XUtils.SETTER_IDX, "recycle_price", _s_set_recycle_price);
            XUtils.RegisterFunc(L, XUtils.SETTER_IDX, "use_job", _s_set_use_job);
            XUtils.RegisterFunc(L, XUtils.SETTER_IDX, "use_transfer", _s_set_use_transfer);
            XUtils.RegisterFunc(L, XUtils.SETTER_IDX, "gain_text", _s_set_gain_text);
            XUtils.RegisterFunc(L, XUtils.SETTER_IDX, "gain_from", _s_set_gain_from);
            XUtils.RegisterFunc(L, XUtils.SETTER_IDX, "is_quickuse", _s_set_is_quickuse);
            XUtils.RegisterFunc(L, XUtils.SETTER_IDX, "is_quickuse_always", _s_set_is_quickuse_always);
            XUtils.RegisterFunc(L, XUtils.SETTER_IDX, "is_sell_confirmation", _s_set_is_sell_confirmation);
            XUtils.RegisterFunc(L, XUtils.SETTER_IDX, "sort_id", _s_set_sort_id);
            XUtils.RegisterFunc(L, XUtils.SETTER_IDX, "sort_top", _s_set_sort_top);
            XUtils.RegisterFunc(L, XUtils.SETTER_IDX, "is_equipUp", _s_set_is_equipUp);
            XUtils.RegisterFunc(L, XUtils.SETTER_IDX, "is_equipDown", _s_set_is_equipDown);
            XUtils.RegisterFunc(L, XUtils.SETTER_IDX, "is_decorateUp", _s_set_is_decorateUp);
            XUtils.RegisterFunc(L, XUtils.SETTER_IDX, "is_mutil_use", _s_set_is_mutil_use);
            XUtils.RegisterFunc(L, XUtils.SETTER_IDX, "cd_id", _s_set_cd_id);
            XUtils.RegisterFunc(L, XUtils.SETTER_IDX, "isUpdateFlag", _s_set_isUpdateFlag);
            XUtils.RegisterFunc(L, XUtils.SETTER_IDX, "isDefaultGoods", _s_set_isDefaultGoods);
            XUtils.RegisterFunc(L, XUtils.SETTER_IDX, "unknownGoodsId", _s_set_unknownGoodsId);
            XUtils.RegisterFunc(L, XUtils.SETTER_IDX, "m_group_info", _s_set_m_group_info);
            XUtils.RegisterFunc(L, XUtils.SETTER_IDX, "price_recommend", _s_set_price_recommend);
            XUtils.RegisterFunc(L, XUtils.SETTER_IDX, "price_lower_limit", _s_set_price_lower_limit);
            XUtils.RegisterFunc(L, XUtils.SETTER_IDX, "price_upper_limit", _s_set_price_upper_limit);
            XUtils.RegisterFunc(L, XUtils.SETTER_IDX, "mktype_1", _s_set_mktype_1);
            XUtils.RegisterFunc(L, XUtils.SETTER_IDX, "mktype_2", _s_set_mktype_2);
            XUtils.RegisterFunc(L, XUtils.SETTER_IDX, "daily_use_limit", _s_set_daily_use_limit);
            XUtils.RegisterFunc(L, XUtils.SETTER_IDX, "guild_wpoint", _s_set_guild_wpoint);
            XUtils.RegisterFunc(L, XUtils.SETTER_IDX, "max_stack", _s_set_max_stack);
            XUtils.RegisterFunc(L, XUtils.SETTER_IDX, "create_time", _s_set_create_time);
            XUtils.RegisterFunc(L, XUtils.SETTER_IDX, "is_display_goods", _s_set_is_display_goods);
            XUtils.RegisterFunc(L, XUtils.SETTER_IDX, "wing_exp", _s_set_wing_exp);
            XUtils.RegisterFunc(L, XUtils.SETTER_IDX, "m_level_in_add_lv_exp", _s_set_m_level_in_add_lv_exp);
            XUtils.RegisterFunc(L, XUtils.SETTER_IDX, "is_quickuse_autoUse", _s_set_is_quickuse_autoUse);
            XUtils.RegisterFunc(L, XUtils.SETTER_IDX, "is_deleted", _s_set_is_deleted);
            XUtils.RegisterFunc(L, XUtils.SETTER_IDX, "show_step", _s_set_show_step);
            XUtils.RegisterFunc(L, XUtils.SETTER_IDX, "is_precious", _s_set_is_precious);
            XUtils.RegisterFunc(L, XUtils.SETTER_IDX, "discount", _s_set_discount);
            XUtils.RegisterFunc(L, XUtils.SETTER_IDX, "overdue_notice_time", _s_set_overdue_notice_time);
            
			XUtils.EndObjectRegister(typeof(xc.Goods), L, translator, null, null,
			    null, null, null);

		    XUtils.BeginClassRegister(typeof(xc.Goods), L, __CreateInstance, 1, 0, 0);
			
			
            
            XUtils.RegisterObject(L, translator, XUtils.CLS_IDX, "UnderlyingSystemType", typeof(xc.Goods));
			
			
			XUtils.EndClassRegister(typeof(xc.Goods), L, translator);
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int __CreateInstance(RealStatePtr L)
        {
            return LuaAPI.luaL_error(L, "xc.Goods does not have a constructor!");
        }
        
		
        
		
        
        
        
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_Copy(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            xc.Goods __cl_gen_to_be_invoked = (xc.Goods)translator.FastGetCSObj(L, 1);
            
            
            try {
                
                {
                    xc.Goods goods = (xc.Goods)translator.GetObject(L, 2, typeof(xc.Goods));
                    
                        xc.Goods __cl_gen_ret = __cl_gen_to_be_invoked.Copy( goods );
                        translator.Push(L, __cl_gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_Clone(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            xc.Goods __cl_gen_to_be_invoked = (xc.Goods)translator.FastGetCSObj(L, 1);
            
            
            try {
                
                {
                    
                        xc.Goods __cl_gen_ret = __cl_gen_to_be_invoked.Clone(  );
                        translator.Push(L, __cl_gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_RefreshEquipUp(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            xc.Goods __cl_gen_to_be_invoked = (xc.Goods)translator.FastGetCSObj(L, 1);
            
            
            try {
                
                {
                    
                    __cl_gen_to_be_invoked.RefreshEquipUp(  );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_RefreshDecorateUp(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            xc.Goods __cl_gen_to_be_invoked = (xc.Goods)translator.FastGetCSObj(L, 1);
            
            
            try {
                
                {
                    
                    __cl_gen_to_be_invoked.RefreshDecorateUp(  );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_ParseClientGoodsStr_inner(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            xc.Goods __cl_gen_to_be_invoked = (xc.Goods)translator.FastGetCSObj(L, 1);
            
            
            try {
                
                {
                    System.Collections.Generic.Dictionary<string, string> param_dict = (System.Collections.Generic.Dictionary<string, string>)translator.GetObject(L, 2, typeof(System.Collections.Generic.Dictionary<string, string>));
                    
                    __cl_gen_to_be_invoked.ParseClientGoodsStr_inner( param_dict );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_GetClientGoodsStr_inner(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            xc.Goods __cl_gen_to_be_invoked = (xc.Goods)translator.FastGetCSObj(L, 1);
            
            
            try {
                
                {
                    System.Text.StringBuilder builder = (System.Text.StringBuilder)translator.GetObject(L, 2, typeof(System.Text.StringBuilder));
                    
                    __cl_gen_to_be_invoked.GetClientGoodsStr_inner( ref builder );
                    translator.Push(L, builder);
                        
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_IsInEnableTime(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            xc.Goods __cl_gen_to_be_invoked = (xc.Goods)translator.FastGetCSObj(L, 1);
            
            
            try {
                
                {
                    
                        bool __cl_gen_ret = __cl_gen_to_be_invoked.IsInEnableTime(  );
                        LuaAPI.lua_pushboolean(L, __cl_gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        
        
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_id(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.Goods __cl_gen_to_be_invoked = (xc.Goods)translator.FastGetCSObj(L, 1);
                LuaAPI.lua_pushuint64(L, __cl_gen_to_be_invoked.id);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_bind(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.Goods __cl_gen_to_be_invoked = (xc.Goods)translator.FastGetCSObj(L, 1);
                LuaAPI.xlua_pushuint(L, __cl_gen_to_be_invoked.bind);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_type_idx(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.Goods __cl_gen_to_be_invoked = (xc.Goods)translator.FastGetCSObj(L, 1);
                LuaAPI.xlua_pushuint(L, __cl_gen_to_be_invoked.type_idx);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_color_type(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.Goods __cl_gen_to_be_invoked = (xc.Goods)translator.FastGetCSObj(L, 1);
                LuaAPI.xlua_pushuint(L, __cl_gen_to_be_invoked.color_type);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_icon_id(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.Goods __cl_gen_to_be_invoked = (xc.Goods)translator.FastGetCSObj(L, 1);
                LuaAPI.xlua_pushuint(L, __cl_gen_to_be_invoked.icon_id);
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
			
                xc.Goods __cl_gen_to_be_invoked = (xc.Goods)translator.FastGetCSObj(L, 1);
                LuaAPI.lua_pushstring(L, __cl_gen_to_be_invoked.name);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_raw_name(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.Goods __cl_gen_to_be_invoked = (xc.Goods)translator.FastGetCSObj(L, 1);
                LuaAPI.lua_pushstring(L, __cl_gen_to_be_invoked.raw_name);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_num(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.Goods __cl_gen_to_be_invoked = (xc.Goods)translator.FastGetCSObj(L, 1);
                LuaAPI.lua_pushuint64(L, __cl_gen_to_be_invoked.num);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_src_description(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.Goods __cl_gen_to_be_invoked = (xc.Goods)translator.FastGetCSObj(L, 1);
                LuaAPI.lua_pushstring(L, __cl_gen_to_be_invoked.src_description);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_description(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.Goods __cl_gen_to_be_invoked = (xc.Goods)translator.FastGetCSObj(L, 1);
                LuaAPI.lua_pushstring(L, __cl_gen_to_be_invoked.description);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_sub_type(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.Goods __cl_gen_to_be_invoked = (xc.Goods)translator.FastGetCSObj(L, 1);
                LuaAPI.xlua_pushuint(L, __cl_gen_to_be_invoked.sub_type);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_drop_effect(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.Goods __cl_gen_to_be_invoked = (xc.Goods)translator.FastGetCSObj(L, 1);
                LuaAPI.lua_pushstring(L, __cl_gen_to_be_invoked.drop_effect);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_effect(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.Goods __cl_gen_to_be_invoked = (xc.Goods)translator.FastGetCSObj(L, 1);
                LuaAPI.lua_pushstring(L, __cl_gen_to_be_invoked.effect);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_can_use(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.Goods __cl_gen_to_be_invoked = (xc.Goods)translator.FastGetCSObj(L, 1);
                LuaAPI.lua_pushboolean(L, __cl_gen_to_be_invoked.can_use);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_use_lv(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.Goods __cl_gen_to_be_invoked = (xc.Goods)translator.FastGetCSObj(L, 1);
                LuaAPI.xlua_pushuint(L, __cl_gen_to_be_invoked.use_lv);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_tips_show(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.Goods __cl_gen_to_be_invoked = (xc.Goods)translator.FastGetCSObj(L, 1);
                LuaAPI.lua_pushboolean(L, __cl_gen_to_be_invoked.tips_show);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_start_cd(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.Goods __cl_gen_to_be_invoked = (xc.Goods)translator.FastGetCSObj(L, 1);
                LuaAPI.xlua_pushuint(L, __cl_gen_to_be_invoked.start_cd);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_cd(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.Goods __cl_gen_to_be_invoked = (xc.Goods)translator.FastGetCSObj(L, 1);
                LuaAPI.xlua_pushuint(L, __cl_gen_to_be_invoked.cd);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_expire_time(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.Goods __cl_gen_to_be_invoked = (xc.Goods)translator.FastGetCSObj(L, 1);
                LuaAPI.xlua_pushuint(L, __cl_gen_to_be_invoked.expire_time);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_expire_time_inTmpl(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.Goods __cl_gen_to_be_invoked = (xc.Goods)translator.FastGetCSObj(L, 1);
                LuaAPI.xlua_pushuint(L, __cl_gen_to_be_invoked.expire_time_inTmpl);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_main_type(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.Goods __cl_gen_to_be_invoked = (xc.Goods)translator.FastGetCSObj(L, 1);
                LuaAPI.xlua_pushuint(L, __cl_gen_to_be_invoked.main_type);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_arg(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.Goods __cl_gen_to_be_invoked = (xc.Goods)translator.FastGetCSObj(L, 1);
                LuaAPI.lua_pushstring(L, __cl_gen_to_be_invoked.arg);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_client_use(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.Goods __cl_gen_to_be_invoked = (xc.Goods)translator.FastGetCSObj(L, 1);
                LuaAPI.xlua_pushuint(L, __cl_gen_to_be_invoked.client_use);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_need_count(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.Goods __cl_gen_to_be_invoked = (xc.Goods)translator.FastGetCSObj(L, 1);
                LuaAPI.xlua_pushuint(L, __cl_gen_to_be_invoked.need_count);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_recycle_price(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.Goods __cl_gen_to_be_invoked = (xc.Goods)translator.FastGetCSObj(L, 1);
                LuaAPI.xlua_pushuint(L, __cl_gen_to_be_invoked.recycle_price);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_use_job(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.Goods __cl_gen_to_be_invoked = (xc.Goods)translator.FastGetCSObj(L, 1);
                LuaAPI.xlua_pushuint(L, __cl_gen_to_be_invoked.use_job);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_use_transfer(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.Goods __cl_gen_to_be_invoked = (xc.Goods)translator.FastGetCSObj(L, 1);
                LuaAPI.xlua_pushuint(L, __cl_gen_to_be_invoked.use_transfer);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_gain_text(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.Goods __cl_gen_to_be_invoked = (xc.Goods)translator.FastGetCSObj(L, 1);
                LuaAPI.lua_pushstring(L, __cl_gen_to_be_invoked.gain_text);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_gain_from(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.Goods __cl_gen_to_be_invoked = (xc.Goods)translator.FastGetCSObj(L, 1);
                LuaAPI.lua_pushstring(L, __cl_gen_to_be_invoked.gain_from);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_is_quickuse(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.Goods __cl_gen_to_be_invoked = (xc.Goods)translator.FastGetCSObj(L, 1);
                LuaAPI.lua_pushboolean(L, __cl_gen_to_be_invoked.is_quickuse);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_is_quickuse_always(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.Goods __cl_gen_to_be_invoked = (xc.Goods)translator.FastGetCSObj(L, 1);
                LuaAPI.lua_pushboolean(L, __cl_gen_to_be_invoked.is_quickuse_always);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_is_sell_confirmation(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.Goods __cl_gen_to_be_invoked = (xc.Goods)translator.FastGetCSObj(L, 1);
                LuaAPI.lua_pushboolean(L, __cl_gen_to_be_invoked.is_sell_confirmation);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_sort_id(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.Goods __cl_gen_to_be_invoked = (xc.Goods)translator.FastGetCSObj(L, 1);
                LuaAPI.xlua_pushuint(L, __cl_gen_to_be_invoked.sort_id);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_sort_top(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.Goods __cl_gen_to_be_invoked = (xc.Goods)translator.FastGetCSObj(L, 1);
                LuaAPI.xlua_pushuint(L, __cl_gen_to_be_invoked.sort_top);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_is_equipUp(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.Goods __cl_gen_to_be_invoked = (xc.Goods)translator.FastGetCSObj(L, 1);
                LuaAPI.lua_pushboolean(L, __cl_gen_to_be_invoked.is_equipUp);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_is_equipDown(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.Goods __cl_gen_to_be_invoked = (xc.Goods)translator.FastGetCSObj(L, 1);
                LuaAPI.lua_pushboolean(L, __cl_gen_to_be_invoked.is_equipDown);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_is_decorateUp(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.Goods __cl_gen_to_be_invoked = (xc.Goods)translator.FastGetCSObj(L, 1);
                LuaAPI.lua_pushboolean(L, __cl_gen_to_be_invoked.is_decorateUp);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_is_mutil_use(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.Goods __cl_gen_to_be_invoked = (xc.Goods)translator.FastGetCSObj(L, 1);
                LuaAPI.lua_pushboolean(L, __cl_gen_to_be_invoked.is_mutil_use);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_cd_id(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.Goods __cl_gen_to_be_invoked = (xc.Goods)translator.FastGetCSObj(L, 1);
                LuaAPI.xlua_pushuint(L, __cl_gen_to_be_invoked.cd_id);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_isUpdateFlag(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.Goods __cl_gen_to_be_invoked = (xc.Goods)translator.FastGetCSObj(L, 1);
                LuaAPI.lua_pushboolean(L, __cl_gen_to_be_invoked.isUpdateFlag);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_isDefaultGoods(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.Goods __cl_gen_to_be_invoked = (xc.Goods)translator.FastGetCSObj(L, 1);
                LuaAPI.lua_pushboolean(L, __cl_gen_to_be_invoked.isDefaultGoods);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_unknownGoodsId(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.Goods __cl_gen_to_be_invoked = (xc.Goods)translator.FastGetCSObj(L, 1);
                LuaAPI.xlua_pushuint(L, __cl_gen_to_be_invoked.unknownGoodsId);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_m_group_info(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.Goods __cl_gen_to_be_invoked = (xc.Goods)translator.FastGetCSObj(L, 1);
                translator.Push(L, __cl_gen_to_be_invoked.m_group_info);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_price_recommend(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.Goods __cl_gen_to_be_invoked = (xc.Goods)translator.FastGetCSObj(L, 1);
                LuaAPI.xlua_pushuint(L, __cl_gen_to_be_invoked.price_recommend);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_price_lower_limit(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.Goods __cl_gen_to_be_invoked = (xc.Goods)translator.FastGetCSObj(L, 1);
                LuaAPI.lua_pushnumber(L, __cl_gen_to_be_invoked.price_lower_limit);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_price_upper_limit(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.Goods __cl_gen_to_be_invoked = (xc.Goods)translator.FastGetCSObj(L, 1);
                LuaAPI.lua_pushnumber(L, __cl_gen_to_be_invoked.price_upper_limit);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_mktype_1(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.Goods __cl_gen_to_be_invoked = (xc.Goods)translator.FastGetCSObj(L, 1);
                LuaAPI.xlua_pushuint(L, __cl_gen_to_be_invoked.mktype_1);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_mktype_2(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.Goods __cl_gen_to_be_invoked = (xc.Goods)translator.FastGetCSObj(L, 1);
                LuaAPI.xlua_pushuint(L, __cl_gen_to_be_invoked.mktype_2);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_daily_use_limit(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.Goods __cl_gen_to_be_invoked = (xc.Goods)translator.FastGetCSObj(L, 1);
                LuaAPI.xlua_pushuint(L, __cl_gen_to_be_invoked.daily_use_limit);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_guild_wpoint(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.Goods __cl_gen_to_be_invoked = (xc.Goods)translator.FastGetCSObj(L, 1);
                LuaAPI.xlua_pushuint(L, __cl_gen_to_be_invoked.guild_wpoint);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_max_stack(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.Goods __cl_gen_to_be_invoked = (xc.Goods)translator.FastGetCSObj(L, 1);
                LuaAPI.xlua_pushuint(L, __cl_gen_to_be_invoked.max_stack);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_create_time(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.Goods __cl_gen_to_be_invoked = (xc.Goods)translator.FastGetCSObj(L, 1);
                LuaAPI.xlua_pushuint(L, __cl_gen_to_be_invoked.create_time);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_is_display_goods(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.Goods __cl_gen_to_be_invoked = (xc.Goods)translator.FastGetCSObj(L, 1);
                LuaAPI.lua_pushboolean(L, __cl_gen_to_be_invoked.is_display_goods);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_wing_exp(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.Goods __cl_gen_to_be_invoked = (xc.Goods)translator.FastGetCSObj(L, 1);
                LuaAPI.xlua_pushuint(L, __cl_gen_to_be_invoked.wing_exp);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_m_level_in_add_lv_exp(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.Goods __cl_gen_to_be_invoked = (xc.Goods)translator.FastGetCSObj(L, 1);
                LuaAPI.xlua_pushuint(L, __cl_gen_to_be_invoked.m_level_in_add_lv_exp);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_is_quickuse_autoUse(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.Goods __cl_gen_to_be_invoked = (xc.Goods)translator.FastGetCSObj(L, 1);
                LuaAPI.lua_pushboolean(L, __cl_gen_to_be_invoked.is_quickuse_autoUse);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_is_deleted(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.Goods __cl_gen_to_be_invoked = (xc.Goods)translator.FastGetCSObj(L, 1);
                LuaAPI.lua_pushboolean(L, __cl_gen_to_be_invoked.is_deleted);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_show_step(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.Goods __cl_gen_to_be_invoked = (xc.Goods)translator.FastGetCSObj(L, 1);
                LuaAPI.xlua_pushuint(L, __cl_gen_to_be_invoked.show_step);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_is_precious(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.Goods __cl_gen_to_be_invoked = (xc.Goods)translator.FastGetCSObj(L, 1);
                LuaAPI.xlua_pushuint(L, __cl_gen_to_be_invoked.is_precious);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_discount(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.Goods __cl_gen_to_be_invoked = (xc.Goods)translator.FastGetCSObj(L, 1);
                LuaAPI.xlua_pushuint(L, __cl_gen_to_be_invoked.discount);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_overdue_notice_time(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.Goods __cl_gen_to_be_invoked = (xc.Goods)translator.FastGetCSObj(L, 1);
                LuaAPI.xlua_pushuint(L, __cl_gen_to_be_invoked.overdue_notice_time);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_id(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.Goods __cl_gen_to_be_invoked = (xc.Goods)translator.FastGetCSObj(L, 1);
                __cl_gen_to_be_invoked.id = LuaAPI.lua_touint64(L, 2);
            
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_bind(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.Goods __cl_gen_to_be_invoked = (xc.Goods)translator.FastGetCSObj(L, 1);
                __cl_gen_to_be_invoked.bind = LuaAPI.xlua_touint(L, 2);
            
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_type_idx(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.Goods __cl_gen_to_be_invoked = (xc.Goods)translator.FastGetCSObj(L, 1);
                __cl_gen_to_be_invoked.type_idx = LuaAPI.xlua_touint(L, 2);
            
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_color_type(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.Goods __cl_gen_to_be_invoked = (xc.Goods)translator.FastGetCSObj(L, 1);
                __cl_gen_to_be_invoked.color_type = LuaAPI.xlua_touint(L, 2);
            
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_icon_id(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.Goods __cl_gen_to_be_invoked = (xc.Goods)translator.FastGetCSObj(L, 1);
                __cl_gen_to_be_invoked.icon_id = LuaAPI.xlua_touint(L, 2);
            
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
			
                xc.Goods __cl_gen_to_be_invoked = (xc.Goods)translator.FastGetCSObj(L, 1);
                __cl_gen_to_be_invoked.name = LuaAPI.lua_tostring(L, 2);
            
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_raw_name(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.Goods __cl_gen_to_be_invoked = (xc.Goods)translator.FastGetCSObj(L, 1);
                __cl_gen_to_be_invoked.raw_name = LuaAPI.lua_tostring(L, 2);
            
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_num(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.Goods __cl_gen_to_be_invoked = (xc.Goods)translator.FastGetCSObj(L, 1);
                __cl_gen_to_be_invoked.num = LuaAPI.lua_touint64(L, 2);
            
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_src_description(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.Goods __cl_gen_to_be_invoked = (xc.Goods)translator.FastGetCSObj(L, 1);
                __cl_gen_to_be_invoked.src_description = LuaAPI.lua_tostring(L, 2);
            
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_description(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.Goods __cl_gen_to_be_invoked = (xc.Goods)translator.FastGetCSObj(L, 1);
                __cl_gen_to_be_invoked.description = LuaAPI.lua_tostring(L, 2);
            
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_sub_type(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.Goods __cl_gen_to_be_invoked = (xc.Goods)translator.FastGetCSObj(L, 1);
                __cl_gen_to_be_invoked.sub_type = LuaAPI.xlua_touint(L, 2);
            
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_drop_effect(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.Goods __cl_gen_to_be_invoked = (xc.Goods)translator.FastGetCSObj(L, 1);
                __cl_gen_to_be_invoked.drop_effect = LuaAPI.lua_tostring(L, 2);
            
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_effect(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.Goods __cl_gen_to_be_invoked = (xc.Goods)translator.FastGetCSObj(L, 1);
                __cl_gen_to_be_invoked.effect = LuaAPI.lua_tostring(L, 2);
            
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_can_use(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.Goods __cl_gen_to_be_invoked = (xc.Goods)translator.FastGetCSObj(L, 1);
                __cl_gen_to_be_invoked.can_use = LuaAPI.lua_toboolean(L, 2);
            
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_use_lv(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.Goods __cl_gen_to_be_invoked = (xc.Goods)translator.FastGetCSObj(L, 1);
                __cl_gen_to_be_invoked.use_lv = LuaAPI.xlua_touint(L, 2);
            
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_tips_show(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.Goods __cl_gen_to_be_invoked = (xc.Goods)translator.FastGetCSObj(L, 1);
                __cl_gen_to_be_invoked.tips_show = LuaAPI.lua_toboolean(L, 2);
            
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_start_cd(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.Goods __cl_gen_to_be_invoked = (xc.Goods)translator.FastGetCSObj(L, 1);
                __cl_gen_to_be_invoked.start_cd = LuaAPI.xlua_touint(L, 2);
            
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_cd(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.Goods __cl_gen_to_be_invoked = (xc.Goods)translator.FastGetCSObj(L, 1);
                __cl_gen_to_be_invoked.cd = LuaAPI.xlua_touint(L, 2);
            
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_expire_time(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.Goods __cl_gen_to_be_invoked = (xc.Goods)translator.FastGetCSObj(L, 1);
                __cl_gen_to_be_invoked.expire_time = LuaAPI.xlua_touint(L, 2);
            
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_expire_time_inTmpl(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.Goods __cl_gen_to_be_invoked = (xc.Goods)translator.FastGetCSObj(L, 1);
                __cl_gen_to_be_invoked.expire_time_inTmpl = LuaAPI.xlua_touint(L, 2);
            
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_main_type(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.Goods __cl_gen_to_be_invoked = (xc.Goods)translator.FastGetCSObj(L, 1);
                __cl_gen_to_be_invoked.main_type = LuaAPI.xlua_touint(L, 2);
            
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_arg(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.Goods __cl_gen_to_be_invoked = (xc.Goods)translator.FastGetCSObj(L, 1);
                __cl_gen_to_be_invoked.arg = LuaAPI.lua_tostring(L, 2);
            
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_client_use(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.Goods __cl_gen_to_be_invoked = (xc.Goods)translator.FastGetCSObj(L, 1);
                __cl_gen_to_be_invoked.client_use = LuaAPI.xlua_touint(L, 2);
            
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_need_count(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.Goods __cl_gen_to_be_invoked = (xc.Goods)translator.FastGetCSObj(L, 1);
                __cl_gen_to_be_invoked.need_count = LuaAPI.xlua_touint(L, 2);
            
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_recycle_price(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.Goods __cl_gen_to_be_invoked = (xc.Goods)translator.FastGetCSObj(L, 1);
                __cl_gen_to_be_invoked.recycle_price = LuaAPI.xlua_touint(L, 2);
            
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_use_job(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.Goods __cl_gen_to_be_invoked = (xc.Goods)translator.FastGetCSObj(L, 1);
                __cl_gen_to_be_invoked.use_job = LuaAPI.xlua_touint(L, 2);
            
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_use_transfer(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.Goods __cl_gen_to_be_invoked = (xc.Goods)translator.FastGetCSObj(L, 1);
                __cl_gen_to_be_invoked.use_transfer = LuaAPI.xlua_touint(L, 2);
            
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_gain_text(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.Goods __cl_gen_to_be_invoked = (xc.Goods)translator.FastGetCSObj(L, 1);
                __cl_gen_to_be_invoked.gain_text = LuaAPI.lua_tostring(L, 2);
            
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_gain_from(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.Goods __cl_gen_to_be_invoked = (xc.Goods)translator.FastGetCSObj(L, 1);
                __cl_gen_to_be_invoked.gain_from = LuaAPI.lua_tostring(L, 2);
            
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_is_quickuse(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.Goods __cl_gen_to_be_invoked = (xc.Goods)translator.FastGetCSObj(L, 1);
                __cl_gen_to_be_invoked.is_quickuse = LuaAPI.lua_toboolean(L, 2);
            
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_is_quickuse_always(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.Goods __cl_gen_to_be_invoked = (xc.Goods)translator.FastGetCSObj(L, 1);
                __cl_gen_to_be_invoked.is_quickuse_always = LuaAPI.lua_toboolean(L, 2);
            
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_is_sell_confirmation(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.Goods __cl_gen_to_be_invoked = (xc.Goods)translator.FastGetCSObj(L, 1);
                __cl_gen_to_be_invoked.is_sell_confirmation = LuaAPI.lua_toboolean(L, 2);
            
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_sort_id(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.Goods __cl_gen_to_be_invoked = (xc.Goods)translator.FastGetCSObj(L, 1);
                __cl_gen_to_be_invoked.sort_id = LuaAPI.xlua_touint(L, 2);
            
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_sort_top(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.Goods __cl_gen_to_be_invoked = (xc.Goods)translator.FastGetCSObj(L, 1);
                __cl_gen_to_be_invoked.sort_top = LuaAPI.xlua_touint(L, 2);
            
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_is_equipUp(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.Goods __cl_gen_to_be_invoked = (xc.Goods)translator.FastGetCSObj(L, 1);
                __cl_gen_to_be_invoked.is_equipUp = LuaAPI.lua_toboolean(L, 2);
            
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_is_equipDown(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.Goods __cl_gen_to_be_invoked = (xc.Goods)translator.FastGetCSObj(L, 1);
                __cl_gen_to_be_invoked.is_equipDown = LuaAPI.lua_toboolean(L, 2);
            
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_is_decorateUp(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.Goods __cl_gen_to_be_invoked = (xc.Goods)translator.FastGetCSObj(L, 1);
                __cl_gen_to_be_invoked.is_decorateUp = LuaAPI.lua_toboolean(L, 2);
            
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_is_mutil_use(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.Goods __cl_gen_to_be_invoked = (xc.Goods)translator.FastGetCSObj(L, 1);
                __cl_gen_to_be_invoked.is_mutil_use = LuaAPI.lua_toboolean(L, 2);
            
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_cd_id(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.Goods __cl_gen_to_be_invoked = (xc.Goods)translator.FastGetCSObj(L, 1);
                __cl_gen_to_be_invoked.cd_id = LuaAPI.xlua_touint(L, 2);
            
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_isUpdateFlag(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.Goods __cl_gen_to_be_invoked = (xc.Goods)translator.FastGetCSObj(L, 1);
                __cl_gen_to_be_invoked.isUpdateFlag = LuaAPI.lua_toboolean(L, 2);
            
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_isDefaultGoods(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.Goods __cl_gen_to_be_invoked = (xc.Goods)translator.FastGetCSObj(L, 1);
                __cl_gen_to_be_invoked.isDefaultGoods = LuaAPI.lua_toboolean(L, 2);
            
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_unknownGoodsId(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.Goods __cl_gen_to_be_invoked = (xc.Goods)translator.FastGetCSObj(L, 1);
                __cl_gen_to_be_invoked.unknownGoodsId = LuaAPI.xlua_touint(L, 2);
            
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_m_group_info(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.Goods __cl_gen_to_be_invoked = (xc.Goods)translator.FastGetCSObj(L, 1);
                __cl_gen_to_be_invoked.m_group_info = (xc.DBRewardGroup.DBRewardGroupInfo)translator.GetObject(L, 2, typeof(xc.DBRewardGroup.DBRewardGroupInfo));
            
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_price_recommend(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.Goods __cl_gen_to_be_invoked = (xc.Goods)translator.FastGetCSObj(L, 1);
                __cl_gen_to_be_invoked.price_recommend = LuaAPI.xlua_touint(L, 2);
            
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_price_lower_limit(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.Goods __cl_gen_to_be_invoked = (xc.Goods)translator.FastGetCSObj(L, 1);
                __cl_gen_to_be_invoked.price_lower_limit = (float)LuaAPI.lua_tonumber(L, 2);
            
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_price_upper_limit(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.Goods __cl_gen_to_be_invoked = (xc.Goods)translator.FastGetCSObj(L, 1);
                __cl_gen_to_be_invoked.price_upper_limit = (float)LuaAPI.lua_tonumber(L, 2);
            
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_mktype_1(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.Goods __cl_gen_to_be_invoked = (xc.Goods)translator.FastGetCSObj(L, 1);
                __cl_gen_to_be_invoked.mktype_1 = LuaAPI.xlua_touint(L, 2);
            
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_mktype_2(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.Goods __cl_gen_to_be_invoked = (xc.Goods)translator.FastGetCSObj(L, 1);
                __cl_gen_to_be_invoked.mktype_2 = LuaAPI.xlua_touint(L, 2);
            
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_daily_use_limit(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.Goods __cl_gen_to_be_invoked = (xc.Goods)translator.FastGetCSObj(L, 1);
                __cl_gen_to_be_invoked.daily_use_limit = LuaAPI.xlua_touint(L, 2);
            
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_guild_wpoint(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.Goods __cl_gen_to_be_invoked = (xc.Goods)translator.FastGetCSObj(L, 1);
                __cl_gen_to_be_invoked.guild_wpoint = LuaAPI.xlua_touint(L, 2);
            
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_max_stack(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.Goods __cl_gen_to_be_invoked = (xc.Goods)translator.FastGetCSObj(L, 1);
                __cl_gen_to_be_invoked.max_stack = LuaAPI.xlua_touint(L, 2);
            
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_create_time(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.Goods __cl_gen_to_be_invoked = (xc.Goods)translator.FastGetCSObj(L, 1);
                __cl_gen_to_be_invoked.create_time = LuaAPI.xlua_touint(L, 2);
            
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_is_display_goods(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.Goods __cl_gen_to_be_invoked = (xc.Goods)translator.FastGetCSObj(L, 1);
                __cl_gen_to_be_invoked.is_display_goods = LuaAPI.lua_toboolean(L, 2);
            
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_wing_exp(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.Goods __cl_gen_to_be_invoked = (xc.Goods)translator.FastGetCSObj(L, 1);
                __cl_gen_to_be_invoked.wing_exp = LuaAPI.xlua_touint(L, 2);
            
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_m_level_in_add_lv_exp(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.Goods __cl_gen_to_be_invoked = (xc.Goods)translator.FastGetCSObj(L, 1);
                __cl_gen_to_be_invoked.m_level_in_add_lv_exp = LuaAPI.xlua_touint(L, 2);
            
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_is_quickuse_autoUse(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.Goods __cl_gen_to_be_invoked = (xc.Goods)translator.FastGetCSObj(L, 1);
                __cl_gen_to_be_invoked.is_quickuse_autoUse = LuaAPI.lua_toboolean(L, 2);
            
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_is_deleted(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.Goods __cl_gen_to_be_invoked = (xc.Goods)translator.FastGetCSObj(L, 1);
                __cl_gen_to_be_invoked.is_deleted = LuaAPI.lua_toboolean(L, 2);
            
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_show_step(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.Goods __cl_gen_to_be_invoked = (xc.Goods)translator.FastGetCSObj(L, 1);
                __cl_gen_to_be_invoked.show_step = LuaAPI.xlua_touint(L, 2);
            
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_is_precious(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.Goods __cl_gen_to_be_invoked = (xc.Goods)translator.FastGetCSObj(L, 1);
                __cl_gen_to_be_invoked.is_precious = LuaAPI.xlua_touint(L, 2);
            
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_discount(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.Goods __cl_gen_to_be_invoked = (xc.Goods)translator.FastGetCSObj(L, 1);
                __cl_gen_to_be_invoked.discount = LuaAPI.xlua_touint(L, 2);
            
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_overdue_notice_time(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.Goods __cl_gen_to_be_invoked = (xc.Goods)translator.FastGetCSObj(L, 1);
                __cl_gen_to_be_invoked.overdue_notice_time = LuaAPI.xlua_touint(L, 2);
            
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 0;
        }
        
		
		
		
		
    }
}
