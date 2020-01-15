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
    public class xcDBSysConfigSysConfigWrap
    {
        public static void __Register(RealStatePtr L)
        {
			ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			XUtils.BeginObjectRegister(typeof(xc.DBSysConfig.SysConfig), L, translator, 0, 2, 34, 22);
			
			XUtils.RegisterFunc(L, XUtils.METHOD_IDX, "Init", _m_Init);
			XUtils.RegisterFunc(L, XUtils.METHOD_IDX, "CompareTo", _m_CompareTo);
			
			
			XUtils.RegisterFunc(L, XUtils.GETTER_IDX, "Id", _g_get_Id);
            XUtils.RegisterFunc(L, XUtils.GETTER_IDX, "Level", _g_get_Level);
            XUtils.RegisterFunc(L, XUtils.GETTER_IDX, "TaskType", _g_get_TaskType);
            XUtils.RegisterFunc(L, XUtils.GETTER_IDX, "TaskId", _g_get_TaskId);
            XUtils.RegisterFunc(L, XUtils.GETTER_IDX, "Pos", _g_get_Pos);
            XUtils.RegisterFunc(L, XUtils.GETTER_IDX, "SubPos", _g_get_SubPos);
            XUtils.RegisterFunc(L, XUtils.GETTER_IDX, "FixedPos", _g_get_FixedPos);
            XUtils.RegisterFunc(L, XUtils.GETTER_IDX, "ShowBg", _g_get_ShowBg);
            XUtils.RegisterFunc(L, XUtils.GETTER_IDX, "IsActivity", _g_get_IsActivity);
            XUtils.RegisterFunc(L, XUtils.GETTER_IDX, "MainMapSysBtnId", _g_get_MainMapSysBtnId);
            XUtils.RegisterFunc(L, XUtils.GETTER_IDX, "Desc", _g_get_Desc);
            XUtils.RegisterFunc(L, XUtils.GETTER_IDX, "BtnSprite", _g_get_BtnSprite);
            XUtils.RegisterFunc(L, XUtils.GETTER_IDX, "BtnText", _g_get_BtnText);
            XUtils.RegisterFunc(L, XUtils.GETTER_IDX, "SortOrder", _g_get_SortOrder);
            XUtils.RegisterFunc(L, XUtils.GETTER_IDX, "RedSpot", _g_get_RedSpot);
            XUtils.RegisterFunc(L, XUtils.GETTER_IDX, "TransferLimit", _g_get_TransferLimit);
            XUtils.RegisterFunc(L, XUtils.GETTER_IDX, "NotOpenTips", _g_get_NotOpenTips);
            XUtils.RegisterFunc(L, XUtils.GETTER_IDX, "Title", _g_get_Title);
            XUtils.RegisterFunc(L, XUtils.GETTER_IDX, "InitNeedShow", _g_get_InitNeedShow);
            XUtils.RegisterFunc(L, XUtils.GETTER_IDX, "NeedAnim", _g_get_NeedAnim);
            XUtils.RegisterFunc(L, XUtils.GETTER_IDX, "PatchId", _g_get_PatchId);
            XUtils.RegisterFunc(L, XUtils.GETTER_IDX, "HideBtnWhenActNotOpen", _g_get_HideBtnWhenActNotOpen);
            XUtils.RegisterFunc(L, XUtils.GETTER_IDX, "SysIdClosePresent", _g_get_SysIdClosePresent);
            XUtils.RegisterFunc(L, XUtils.GETTER_IDX, "TabOrder", _g_get_TabOrder);
            XUtils.RegisterFunc(L, XUtils.GETTER_IDX, "DropDown", _g_get_DropDown);
            XUtils.RegisterFunc(L, XUtils.GETTER_IDX, "DropDownType", _g_get_DropDownType);
            XUtils.RegisterFunc(L, XUtils.GETTER_IDX, "UIBehavior", _g_get_UIBehavior);
            XUtils.RegisterFunc(L, XUtils.GETTER_IDX, "TimeLimitStr", _g_get_TimeLimitStr);
            XUtils.RegisterFunc(L, XUtils.GETTER_IDX, "CustomCondition", _g_get_CustomCondition);
            XUtils.RegisterFunc(L, XUtils.GETTER_IDX, "IsOpened", _g_get_IsOpened);
            XUtils.RegisterFunc(L, XUtils.GETTER_IDX, "IsWaitingSystem", _g_get_IsWaitingSystem);
            XUtils.RegisterFunc(L, XUtils.GETTER_IDX, "IsWaitFinished", _g_get_IsWaitFinished);
            XUtils.RegisterFunc(L, XUtils.GETTER_IDX, "TimeLimit", _g_get_TimeLimit);
            XUtils.RegisterFunc(L, XUtils.GETTER_IDX, "TimeLimitDay", _g_get_TimeLimitDay);
            
			XUtils.RegisterFunc(L, XUtils.SETTER_IDX, "TaskId", _s_set_TaskId);
            XUtils.RegisterFunc(L, XUtils.SETTER_IDX, "Pos", _s_set_Pos);
            XUtils.RegisterFunc(L, XUtils.SETTER_IDX, "SubPos", _s_set_SubPos);
            XUtils.RegisterFunc(L, XUtils.SETTER_IDX, "FixedPos", _s_set_FixedPos);
            XUtils.RegisterFunc(L, XUtils.SETTER_IDX, "ShowBg", _s_set_ShowBg);
            XUtils.RegisterFunc(L, XUtils.SETTER_IDX, "IsActivity", _s_set_IsActivity);
            XUtils.RegisterFunc(L, XUtils.SETTER_IDX, "MainMapSysBtnId", _s_set_MainMapSysBtnId);
            XUtils.RegisterFunc(L, XUtils.SETTER_IDX, "RedSpot", _s_set_RedSpot);
            XUtils.RegisterFunc(L, XUtils.SETTER_IDX, "TransferLimit", _s_set_TransferLimit);
            XUtils.RegisterFunc(L, XUtils.SETTER_IDX, "NotOpenTips", _s_set_NotOpenTips);
            XUtils.RegisterFunc(L, XUtils.SETTER_IDX, "Title", _s_set_Title);
            XUtils.RegisterFunc(L, XUtils.SETTER_IDX, "InitNeedShow", _s_set_InitNeedShow);
            XUtils.RegisterFunc(L, XUtils.SETTER_IDX, "NeedAnim", _s_set_NeedAnim);
            XUtils.RegisterFunc(L, XUtils.SETTER_IDX, "PatchId", _s_set_PatchId);
            XUtils.RegisterFunc(L, XUtils.SETTER_IDX, "HideBtnWhenActNotOpen", _s_set_HideBtnWhenActNotOpen);
            XUtils.RegisterFunc(L, XUtils.SETTER_IDX, "SysIdClosePresent", _s_set_SysIdClosePresent);
            XUtils.RegisterFunc(L, XUtils.SETTER_IDX, "TabOrder", _s_set_TabOrder);
            XUtils.RegisterFunc(L, XUtils.SETTER_IDX, "DropDown", _s_set_DropDown);
            XUtils.RegisterFunc(L, XUtils.SETTER_IDX, "DropDownType", _s_set_DropDownType);
            XUtils.RegisterFunc(L, XUtils.SETTER_IDX, "UIBehavior", _s_set_UIBehavior);
            XUtils.RegisterFunc(L, XUtils.SETTER_IDX, "TimeLimitStr", _s_set_TimeLimitStr);
            XUtils.RegisterFunc(L, XUtils.SETTER_IDX, "CustomCondition", _s_set_CustomCondition);
            
			XUtils.EndObjectRegister(typeof(xc.DBSysConfig.SysConfig), L, translator, null, null,
			    null, null, null);

		    XUtils.BeginClassRegister(typeof(xc.DBSysConfig.SysConfig), L, __CreateInstance, 1, 1, 1);
			
			
            
            XUtils.RegisterObject(L, translator, XUtils.CLS_IDX, "UnderlyingSystemType", typeof(xc.DBSysConfig.SysConfig));
			XUtils.RegisterFunc(L, XUtils.CLS_GETTER_IDX, "NONE_ID", _g_get_NONE_ID);
            
			XUtils.RegisterFunc(L, XUtils.CLS_SETTER_IDX, "NONE_ID", _s_set_NONE_ID);
            
			XUtils.EndClassRegister(typeof(xc.DBSysConfig.SysConfig), L, translator);
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int __CreateInstance(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			try {
				if(LuaAPI.lua_gettop(L) == 2 && LuaTypes.LUA_TNUMBER == LuaAPI.lua_type(L, 2))
				{
					uint id = LuaAPI.xlua_touint(L, 2);
					
					xc.DBSysConfig.SysConfig __cl_gen_ret = new xc.DBSysConfig.SysConfig(id);
					translator.Push(L, __cl_gen_ret);
					return 1;
				}
				
			}
			catch(System.Exception __gen_e) {
				return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
			}
            return LuaAPI.luaL_error(L, "invalid arguments to xc.DBSysConfig.SysConfig constructor!");
            
        }
        
		
        
		
        
        
        
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_Init(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            xc.DBSysConfig.SysConfig __cl_gen_to_be_invoked = (xc.DBSysConfig.SysConfig)translator.FastGetCSObj(L, 1);
            
            
            try {
                
                {
                    ushort lv = (ushort)LuaAPI.xlua_tointeger(L, 2);
                    xc.DBSysConfig.ESysTaskType task_type;translator.Get(L, 3, out task_type);
                    uint task_id = LuaAPI.xlua_touint(L, 4);
                    xc.DBSysConfig.ESysBtnPos pos;translator.Get(L, 5, out pos);
                    uint sub_pos = LuaAPI.xlua_touint(L, 6);
                    xc.DBSysConfig.ESysBtnFixType fixed_pos;translator.Get(L, 7, out fixed_pos);
                    bool show_bg = LuaAPI.lua_toboolean(L, 8);
                    bool is_activity = LuaAPI.lua_toboolean(L, 9);
                    string desc = LuaAPI.lua_tostring(L, 10);
                    string btn_sprite = LuaAPI.lua_tostring(L, 11);
                    string btn_text = LuaAPI.lua_tostring(L, 12);
                    byte sort_order = (byte)LuaAPI.lua_tonumber(L, 13);
                    uint transfer_limit = LuaAPI.xlua_touint(L, 14);
                    string not_open_tips = LuaAPI.lua_tostring(L, 15);
                    string sys_title = LuaAPI.lua_tostring(L, 16);
                    uint main_ui_id = LuaAPI.xlua_touint(L, 17);
                    
                    __cl_gen_to_be_invoked.Init( lv, task_type, task_id, pos, sub_pos, fixed_pos, show_bg, is_activity, desc, btn_sprite, btn_text, sort_order, transfer_limit, not_open_tips, sys_title, main_ui_id );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_CompareTo(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            xc.DBSysConfig.SysConfig __cl_gen_to_be_invoked = (xc.DBSysConfig.SysConfig)translator.FastGetCSObj(L, 1);
            
            
            try {
                
                {
                    object obj = translator.GetObject(L, 2, typeof(object));
                    
                        int __cl_gen_ret = __cl_gen_to_be_invoked.CompareTo( obj );
                        LuaAPI.xlua_pushinteger(L, __cl_gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        
        
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_Id(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.DBSysConfig.SysConfig __cl_gen_to_be_invoked = (xc.DBSysConfig.SysConfig)translator.FastGetCSObj(L, 1);
                LuaAPI.xlua_pushuint(L, __cl_gen_to_be_invoked.Id);
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
			
                xc.DBSysConfig.SysConfig __cl_gen_to_be_invoked = (xc.DBSysConfig.SysConfig)translator.FastGetCSObj(L, 1);
                LuaAPI.xlua_pushinteger(L, __cl_gen_to_be_invoked.Level);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_TaskType(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.DBSysConfig.SysConfig __cl_gen_to_be_invoked = (xc.DBSysConfig.SysConfig)translator.FastGetCSObj(L, 1);
                translator.PushxcDBSysConfigESysTaskType(L, __cl_gen_to_be_invoked.TaskType);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_TaskId(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.DBSysConfig.SysConfig __cl_gen_to_be_invoked = (xc.DBSysConfig.SysConfig)translator.FastGetCSObj(L, 1);
                LuaAPI.xlua_pushuint(L, __cl_gen_to_be_invoked.TaskId);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_Pos(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.DBSysConfig.SysConfig __cl_gen_to_be_invoked = (xc.DBSysConfig.SysConfig)translator.FastGetCSObj(L, 1);
                translator.PushxcDBSysConfigESysBtnPos(L, __cl_gen_to_be_invoked.Pos);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_SubPos(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.DBSysConfig.SysConfig __cl_gen_to_be_invoked = (xc.DBSysConfig.SysConfig)translator.FastGetCSObj(L, 1);
                LuaAPI.xlua_pushuint(L, __cl_gen_to_be_invoked.SubPos);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_FixedPos(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.DBSysConfig.SysConfig __cl_gen_to_be_invoked = (xc.DBSysConfig.SysConfig)translator.FastGetCSObj(L, 1);
                translator.PushxcDBSysConfigESysBtnFixType(L, __cl_gen_to_be_invoked.FixedPos);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_ShowBg(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.DBSysConfig.SysConfig __cl_gen_to_be_invoked = (xc.DBSysConfig.SysConfig)translator.FastGetCSObj(L, 1);
                LuaAPI.lua_pushboolean(L, __cl_gen_to_be_invoked.ShowBg);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_IsActivity(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.DBSysConfig.SysConfig __cl_gen_to_be_invoked = (xc.DBSysConfig.SysConfig)translator.FastGetCSObj(L, 1);
                LuaAPI.lua_pushboolean(L, __cl_gen_to_be_invoked.IsActivity);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_MainMapSysBtnId(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.DBSysConfig.SysConfig __cl_gen_to_be_invoked = (xc.DBSysConfig.SysConfig)translator.FastGetCSObj(L, 1);
                LuaAPI.xlua_pushuint(L, __cl_gen_to_be_invoked.MainMapSysBtnId);
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
			
                xc.DBSysConfig.SysConfig __cl_gen_to_be_invoked = (xc.DBSysConfig.SysConfig)translator.FastGetCSObj(L, 1);
                LuaAPI.lua_pushstring(L, __cl_gen_to_be_invoked.Desc);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_BtnSprite(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.DBSysConfig.SysConfig __cl_gen_to_be_invoked = (xc.DBSysConfig.SysConfig)translator.FastGetCSObj(L, 1);
                LuaAPI.lua_pushstring(L, __cl_gen_to_be_invoked.BtnSprite);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_BtnText(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.DBSysConfig.SysConfig __cl_gen_to_be_invoked = (xc.DBSysConfig.SysConfig)translator.FastGetCSObj(L, 1);
                LuaAPI.lua_pushstring(L, __cl_gen_to_be_invoked.BtnText);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_SortOrder(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.DBSysConfig.SysConfig __cl_gen_to_be_invoked = (xc.DBSysConfig.SysConfig)translator.FastGetCSObj(L, 1);
                LuaAPI.xlua_pushinteger(L, __cl_gen_to_be_invoked.SortOrder);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_RedSpot(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.DBSysConfig.SysConfig __cl_gen_to_be_invoked = (xc.DBSysConfig.SysConfig)translator.FastGetCSObj(L, 1);
                LuaAPI.lua_pushboolean(L, __cl_gen_to_be_invoked.RedSpot);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_TransferLimit(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.DBSysConfig.SysConfig __cl_gen_to_be_invoked = (xc.DBSysConfig.SysConfig)translator.FastGetCSObj(L, 1);
                LuaAPI.xlua_pushuint(L, __cl_gen_to_be_invoked.TransferLimit);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_NotOpenTips(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.DBSysConfig.SysConfig __cl_gen_to_be_invoked = (xc.DBSysConfig.SysConfig)translator.FastGetCSObj(L, 1);
                LuaAPI.lua_pushstring(L, __cl_gen_to_be_invoked.NotOpenTips);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_Title(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.DBSysConfig.SysConfig __cl_gen_to_be_invoked = (xc.DBSysConfig.SysConfig)translator.FastGetCSObj(L, 1);
                LuaAPI.lua_pushstring(L, __cl_gen_to_be_invoked.Title);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_InitNeedShow(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.DBSysConfig.SysConfig __cl_gen_to_be_invoked = (xc.DBSysConfig.SysConfig)translator.FastGetCSObj(L, 1);
                LuaAPI.lua_pushboolean(L, __cl_gen_to_be_invoked.InitNeedShow);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_NeedAnim(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.DBSysConfig.SysConfig __cl_gen_to_be_invoked = (xc.DBSysConfig.SysConfig)translator.FastGetCSObj(L, 1);
                LuaAPI.lua_pushboolean(L, __cl_gen_to_be_invoked.NeedAnim);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_PatchId(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.DBSysConfig.SysConfig __cl_gen_to_be_invoked = (xc.DBSysConfig.SysConfig)translator.FastGetCSObj(L, 1);
                LuaAPI.xlua_pushinteger(L, __cl_gen_to_be_invoked.PatchId);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_HideBtnWhenActNotOpen(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.DBSysConfig.SysConfig __cl_gen_to_be_invoked = (xc.DBSysConfig.SysConfig)translator.FastGetCSObj(L, 1);
                LuaAPI.lua_pushboolean(L, __cl_gen_to_be_invoked.HideBtnWhenActNotOpen);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_SysIdClosePresent(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.DBSysConfig.SysConfig __cl_gen_to_be_invoked = (xc.DBSysConfig.SysConfig)translator.FastGetCSObj(L, 1);
                LuaAPI.xlua_pushuint(L, __cl_gen_to_be_invoked.SysIdClosePresent);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_TabOrder(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.DBSysConfig.SysConfig __cl_gen_to_be_invoked = (xc.DBSysConfig.SysConfig)translator.FastGetCSObj(L, 1);
                LuaAPI.xlua_pushuint(L, __cl_gen_to_be_invoked.TabOrder);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_DropDown(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.DBSysConfig.SysConfig __cl_gen_to_be_invoked = (xc.DBSysConfig.SysConfig)translator.FastGetCSObj(L, 1);
                translator.Push(L, __cl_gen_to_be_invoked.DropDown);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_DropDownType(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.DBSysConfig.SysConfig __cl_gen_to_be_invoked = (xc.DBSysConfig.SysConfig)translator.FastGetCSObj(L, 1);
                LuaAPI.xlua_pushuint(L, __cl_gen_to_be_invoked.DropDownType);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_UIBehavior(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.DBSysConfig.SysConfig __cl_gen_to_be_invoked = (xc.DBSysConfig.SysConfig)translator.FastGetCSObj(L, 1);
                translator.Push(L, __cl_gen_to_be_invoked.UIBehavior);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_TimeLimitStr(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.DBSysConfig.SysConfig __cl_gen_to_be_invoked = (xc.DBSysConfig.SysConfig)translator.FastGetCSObj(L, 1);
                LuaAPI.lua_pushstring(L, __cl_gen_to_be_invoked.TimeLimitStr);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_CustomCondition(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.DBSysConfig.SysConfig __cl_gen_to_be_invoked = (xc.DBSysConfig.SysConfig)translator.FastGetCSObj(L, 1);
                LuaAPI.lua_pushboolean(L, __cl_gen_to_be_invoked.CustomCondition);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_IsOpened(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.DBSysConfig.SysConfig __cl_gen_to_be_invoked = (xc.DBSysConfig.SysConfig)translator.FastGetCSObj(L, 1);
                LuaAPI.lua_pushboolean(L, __cl_gen_to_be_invoked.IsOpened);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_IsWaitingSystem(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.DBSysConfig.SysConfig __cl_gen_to_be_invoked = (xc.DBSysConfig.SysConfig)translator.FastGetCSObj(L, 1);
                LuaAPI.lua_pushboolean(L, __cl_gen_to_be_invoked.IsWaitingSystem);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_IsWaitFinished(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.DBSysConfig.SysConfig __cl_gen_to_be_invoked = (xc.DBSysConfig.SysConfig)translator.FastGetCSObj(L, 1);
                LuaAPI.lua_pushboolean(L, __cl_gen_to_be_invoked.IsWaitFinished);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_TimeLimit(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.DBSysConfig.SysConfig __cl_gen_to_be_invoked = (xc.DBSysConfig.SysConfig)translator.FastGetCSObj(L, 1);
                translator.Push(L, __cl_gen_to_be_invoked.TimeLimit);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_TimeLimitDay(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.DBSysConfig.SysConfig __cl_gen_to_be_invoked = (xc.DBSysConfig.SysConfig)translator.FastGetCSObj(L, 1);
                LuaAPI.xlua_pushuint(L, __cl_gen_to_be_invoked.TimeLimitDay);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_NONE_ID(RealStatePtr L)
        {
            
            try {
			    LuaAPI.xlua_pushinteger(L, xc.DBSysConfig.SysConfig.NONE_ID);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_TaskId(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.DBSysConfig.SysConfig __cl_gen_to_be_invoked = (xc.DBSysConfig.SysConfig)translator.FastGetCSObj(L, 1);
                __cl_gen_to_be_invoked.TaskId = LuaAPI.xlua_touint(L, 2);
            
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_Pos(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.DBSysConfig.SysConfig __cl_gen_to_be_invoked = (xc.DBSysConfig.SysConfig)translator.FastGetCSObj(L, 1);
                xc.DBSysConfig.ESysBtnPos __cl_gen_value;translator.Get(L, 2, out __cl_gen_value);
				__cl_gen_to_be_invoked.Pos = __cl_gen_value;
            
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_SubPos(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.DBSysConfig.SysConfig __cl_gen_to_be_invoked = (xc.DBSysConfig.SysConfig)translator.FastGetCSObj(L, 1);
                __cl_gen_to_be_invoked.SubPos = LuaAPI.xlua_touint(L, 2);
            
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_FixedPos(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.DBSysConfig.SysConfig __cl_gen_to_be_invoked = (xc.DBSysConfig.SysConfig)translator.FastGetCSObj(L, 1);
                xc.DBSysConfig.ESysBtnFixType __cl_gen_value;translator.Get(L, 2, out __cl_gen_value);
				__cl_gen_to_be_invoked.FixedPos = __cl_gen_value;
            
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_ShowBg(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.DBSysConfig.SysConfig __cl_gen_to_be_invoked = (xc.DBSysConfig.SysConfig)translator.FastGetCSObj(L, 1);
                __cl_gen_to_be_invoked.ShowBg = LuaAPI.lua_toboolean(L, 2);
            
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_IsActivity(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.DBSysConfig.SysConfig __cl_gen_to_be_invoked = (xc.DBSysConfig.SysConfig)translator.FastGetCSObj(L, 1);
                __cl_gen_to_be_invoked.IsActivity = LuaAPI.lua_toboolean(L, 2);
            
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_MainMapSysBtnId(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.DBSysConfig.SysConfig __cl_gen_to_be_invoked = (xc.DBSysConfig.SysConfig)translator.FastGetCSObj(L, 1);
                __cl_gen_to_be_invoked.MainMapSysBtnId = LuaAPI.xlua_touint(L, 2);
            
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_RedSpot(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.DBSysConfig.SysConfig __cl_gen_to_be_invoked = (xc.DBSysConfig.SysConfig)translator.FastGetCSObj(L, 1);
                __cl_gen_to_be_invoked.RedSpot = LuaAPI.lua_toboolean(L, 2);
            
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_TransferLimit(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.DBSysConfig.SysConfig __cl_gen_to_be_invoked = (xc.DBSysConfig.SysConfig)translator.FastGetCSObj(L, 1);
                __cl_gen_to_be_invoked.TransferLimit = LuaAPI.xlua_touint(L, 2);
            
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_NotOpenTips(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.DBSysConfig.SysConfig __cl_gen_to_be_invoked = (xc.DBSysConfig.SysConfig)translator.FastGetCSObj(L, 1);
                __cl_gen_to_be_invoked.NotOpenTips = LuaAPI.lua_tostring(L, 2);
            
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_Title(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.DBSysConfig.SysConfig __cl_gen_to_be_invoked = (xc.DBSysConfig.SysConfig)translator.FastGetCSObj(L, 1);
                __cl_gen_to_be_invoked.Title = LuaAPI.lua_tostring(L, 2);
            
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_InitNeedShow(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.DBSysConfig.SysConfig __cl_gen_to_be_invoked = (xc.DBSysConfig.SysConfig)translator.FastGetCSObj(L, 1);
                __cl_gen_to_be_invoked.InitNeedShow = LuaAPI.lua_toboolean(L, 2);
            
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_NeedAnim(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.DBSysConfig.SysConfig __cl_gen_to_be_invoked = (xc.DBSysConfig.SysConfig)translator.FastGetCSObj(L, 1);
                __cl_gen_to_be_invoked.NeedAnim = LuaAPI.lua_toboolean(L, 2);
            
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_PatchId(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.DBSysConfig.SysConfig __cl_gen_to_be_invoked = (xc.DBSysConfig.SysConfig)translator.FastGetCSObj(L, 1);
                __cl_gen_to_be_invoked.PatchId = LuaAPI.xlua_tointeger(L, 2);
            
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_HideBtnWhenActNotOpen(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.DBSysConfig.SysConfig __cl_gen_to_be_invoked = (xc.DBSysConfig.SysConfig)translator.FastGetCSObj(L, 1);
                __cl_gen_to_be_invoked.HideBtnWhenActNotOpen = LuaAPI.lua_toboolean(L, 2);
            
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_SysIdClosePresent(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.DBSysConfig.SysConfig __cl_gen_to_be_invoked = (xc.DBSysConfig.SysConfig)translator.FastGetCSObj(L, 1);
                __cl_gen_to_be_invoked.SysIdClosePresent = LuaAPI.xlua_touint(L, 2);
            
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_TabOrder(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.DBSysConfig.SysConfig __cl_gen_to_be_invoked = (xc.DBSysConfig.SysConfig)translator.FastGetCSObj(L, 1);
                __cl_gen_to_be_invoked.TabOrder = LuaAPI.xlua_touint(L, 2);
            
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_DropDown(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.DBSysConfig.SysConfig __cl_gen_to_be_invoked = (xc.DBSysConfig.SysConfig)translator.FastGetCSObj(L, 1);
                __cl_gen_to_be_invoked.DropDown = (System.Collections.Generic.List<uint>)translator.GetObject(L, 2, typeof(System.Collections.Generic.List<uint>));
            
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_DropDownType(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.DBSysConfig.SysConfig __cl_gen_to_be_invoked = (xc.DBSysConfig.SysConfig)translator.FastGetCSObj(L, 1);
                __cl_gen_to_be_invoked.DropDownType = LuaAPI.xlua_touint(L, 2);
            
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_UIBehavior(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.DBSysConfig.SysConfig __cl_gen_to_be_invoked = (xc.DBSysConfig.SysConfig)translator.FastGetCSObj(L, 1);
                __cl_gen_to_be_invoked.UIBehavior = (System.Collections.Generic.List<string>)translator.GetObject(L, 2, typeof(System.Collections.Generic.List<string>));
            
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_TimeLimitStr(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.DBSysConfig.SysConfig __cl_gen_to_be_invoked = (xc.DBSysConfig.SysConfig)translator.FastGetCSObj(L, 1);
                __cl_gen_to_be_invoked.TimeLimitStr = LuaAPI.lua_tostring(L, 2);
            
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_CustomCondition(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.DBSysConfig.SysConfig __cl_gen_to_be_invoked = (xc.DBSysConfig.SysConfig)translator.FastGetCSObj(L, 1);
                __cl_gen_to_be_invoked.CustomCondition = LuaAPI.lua_toboolean(L, 2);
            
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_NONE_ID(RealStatePtr L)
        {
            
            try {
			    xc.DBSysConfig.SysConfig.NONE_ID = (byte)LuaAPI.lua_tonumber(L, 1);
            
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 0;
        }
        
		
		
		
		
    }
}
