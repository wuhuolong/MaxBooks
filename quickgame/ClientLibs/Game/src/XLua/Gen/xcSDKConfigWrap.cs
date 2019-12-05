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
    public class xcSDKConfigWrap
    {
        public static void __Register(RealStatePtr L)
        {
			ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			XUtils.BeginObjectRegister(typeof(xc.SDKConfig), L, translator, 0, 0, 26, 26);
			
			
			
			XUtils.RegisterFunc(L, XUtils.GETTER_IDX, "SDKNamePrefix", _g_get_SDKNamePrefix);
            XUtils.RegisterFunc(L, XUtils.GETTER_IDX, "LogoName", _g_get_LogoName);
            XUtils.RegisterFunc(L, XUtils.GETTER_IDX, "VersionInfo", _g_get_VersionInfo);
            XUtils.RegisterFunc(L, XUtils.GETTER_IDX, "LoginPrefab", _g_get_LoginPrefab);
            XUtils.RegisterFunc(L, XUtils.GETTER_IDX, "UIServerListWindow", _g_get_UIServerListWindow);
            XUtils.RegisterFunc(L, XUtils.GETTER_IDX, "UICreateActorWindow", _g_get_UICreateActorWindow);
            XUtils.RegisterFunc(L, XUtils.GETTER_IDX, "UIChargeWindow", _g_get_UIChargeWindow);
            XUtils.RegisterFunc(L, XUtils.GETTER_IDX, "UIMapWindow", _g_get_UIMapWindow);
            XUtils.RegisterFunc(L, XUtils.GETTER_IDX, "UIBagWindow", _g_get_UIBagWindow);
            XUtils.RegisterFunc(L, XUtils.GETTER_IDX, "UIPlayerPropertyWindow", _g_get_UIPlayerPropertyWindow);
            XUtils.RegisterFunc(L, XUtils.GETTER_IDX, "UIWelfareWindow", _g_get_UIWelfareWindow);
            XUtils.RegisterFunc(L, XUtils.GETTER_IDX, "UIOpenServerActWindow", _g_get_UIOpenServerActWindow);
            XUtils.RegisterFunc(L, XUtils.GETTER_IDX, "UIForecastWindow", _g_get_UIForecastWindow);
            XUtils.RegisterFunc(L, XUtils.GETTER_IDX, "UINpcDialogWindow", _g_get_UINpcDialogWindow);
            XUtils.RegisterFunc(L, XUtils.GETTER_IDX, "UISkillWindow", _g_get_UISkillWindow);
            XUtils.RegisterFunc(L, XUtils.GETTER_IDX, "UISettingMainWindow", _g_get_UISettingMainWindow);
            XUtils.RegisterFunc(L, XUtils.GETTER_IDX, "UIGoodsComposeWindow", _g_get_UIGoodsComposeWindow);
            XUtils.RegisterFunc(L, XUtils.GETTER_IDX, "UIDialogWindow", _g_get_UIDialogWindow);
            XUtils.RegisterFunc(L, XUtils.GETTER_IDX, "UISurfaceWindow", _g_get_UISurfaceWindow);
            XUtils.RegisterFunc(L, XUtils.GETTER_IDX, "UIPayWindow", _g_get_UIPayWindow);
            XUtils.RegisterFunc(L, XUtils.GETTER_IDX, "UIMainmapWindow", _g_get_UIMainmapWindow);
            XUtils.RegisterFunc(L, XUtils.GETTER_IDX, "is_copy_bag", _g_get_is_copy_bag);
            XUtils.RegisterFunc(L, XUtils.GETTER_IDX, "copy_bag_id", _g_get_copy_bag_id);
            XUtils.RegisterFunc(L, XUtils.GETTER_IDX, "role_list", _g_get_role_list);
            XUtils.RegisterFunc(L, XUtils.GETTER_IDX, "fashion_id", _g_get_fashion_id);
            XUtils.RegisterFunc(L, XUtils.GETTER_IDX, "switch_model_scene", _g_get_switch_model_scene);
            
			XUtils.RegisterFunc(L, XUtils.SETTER_IDX, "SDKNamePrefix", _s_set_SDKNamePrefix);
            XUtils.RegisterFunc(L, XUtils.SETTER_IDX, "LogoName", _s_set_LogoName);
            XUtils.RegisterFunc(L, XUtils.SETTER_IDX, "VersionInfo", _s_set_VersionInfo);
            XUtils.RegisterFunc(L, XUtils.SETTER_IDX, "LoginPrefab", _s_set_LoginPrefab);
            XUtils.RegisterFunc(L, XUtils.SETTER_IDX, "UIServerListWindow", _s_set_UIServerListWindow);
            XUtils.RegisterFunc(L, XUtils.SETTER_IDX, "UICreateActorWindow", _s_set_UICreateActorWindow);
            XUtils.RegisterFunc(L, XUtils.SETTER_IDX, "UIChargeWindow", _s_set_UIChargeWindow);
            XUtils.RegisterFunc(L, XUtils.SETTER_IDX, "UIMapWindow", _s_set_UIMapWindow);
            XUtils.RegisterFunc(L, XUtils.SETTER_IDX, "UIBagWindow", _s_set_UIBagWindow);
            XUtils.RegisterFunc(L, XUtils.SETTER_IDX, "UIPlayerPropertyWindow", _s_set_UIPlayerPropertyWindow);
            XUtils.RegisterFunc(L, XUtils.SETTER_IDX, "UIWelfareWindow", _s_set_UIWelfareWindow);
            XUtils.RegisterFunc(L, XUtils.SETTER_IDX, "UIOpenServerActWindow", _s_set_UIOpenServerActWindow);
            XUtils.RegisterFunc(L, XUtils.SETTER_IDX, "UIForecastWindow", _s_set_UIForecastWindow);
            XUtils.RegisterFunc(L, XUtils.SETTER_IDX, "UINpcDialogWindow", _s_set_UINpcDialogWindow);
            XUtils.RegisterFunc(L, XUtils.SETTER_IDX, "UISkillWindow", _s_set_UISkillWindow);
            XUtils.RegisterFunc(L, XUtils.SETTER_IDX, "UISettingMainWindow", _s_set_UISettingMainWindow);
            XUtils.RegisterFunc(L, XUtils.SETTER_IDX, "UIGoodsComposeWindow", _s_set_UIGoodsComposeWindow);
            XUtils.RegisterFunc(L, XUtils.SETTER_IDX, "UIDialogWindow", _s_set_UIDialogWindow);
            XUtils.RegisterFunc(L, XUtils.SETTER_IDX, "UISurfaceWindow", _s_set_UISurfaceWindow);
            XUtils.RegisterFunc(L, XUtils.SETTER_IDX, "UIPayWindow", _s_set_UIPayWindow);
            XUtils.RegisterFunc(L, XUtils.SETTER_IDX, "UIMainmapWindow", _s_set_UIMainmapWindow);
            XUtils.RegisterFunc(L, XUtils.SETTER_IDX, "is_copy_bag", _s_set_is_copy_bag);
            XUtils.RegisterFunc(L, XUtils.SETTER_IDX, "copy_bag_id", _s_set_copy_bag_id);
            XUtils.RegisterFunc(L, XUtils.SETTER_IDX, "role_list", _s_set_role_list);
            XUtils.RegisterFunc(L, XUtils.SETTER_IDX, "fashion_id", _s_set_fashion_id);
            XUtils.RegisterFunc(L, XUtils.SETTER_IDX, "switch_model_scene", _s_set_switch_model_scene);
            
			XUtils.EndObjectRegister(typeof(xc.SDKConfig), L, translator, null, null,
			    null, null, null);

		    XUtils.BeginClassRegister(typeof(xc.SDKConfig), L, __CreateInstance, 1, 0, 0);
			
			
            
            XUtils.RegisterObject(L, translator, XUtils.CLS_IDX, "UnderlyingSystemType", typeof(xc.SDKConfig));
			
			
			XUtils.EndClassRegister(typeof(xc.SDKConfig), L, translator);
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int __CreateInstance(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			try {
				if(LuaAPI.lua_gettop(L) == 1)
				{
					
					xc.SDKConfig __cl_gen_ret = new xc.SDKConfig();
					translator.Push(L, __cl_gen_ret);
					return 1;
				}
				
			}
			catch(System.Exception __gen_e) {
				return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
			}
            return LuaAPI.luaL_error(L, "invalid arguments to xc.SDKConfig constructor!");
            
        }
        
		
        
		
        
        
        
        
        
        
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_SDKNamePrefix(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.SDKConfig __cl_gen_to_be_invoked = (xc.SDKConfig)translator.FastGetCSObj(L, 1);
                LuaAPI.lua_pushstring(L, __cl_gen_to_be_invoked.SDKNamePrefix);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_LogoName(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.SDKConfig __cl_gen_to_be_invoked = (xc.SDKConfig)translator.FastGetCSObj(L, 1);
                LuaAPI.lua_pushstring(L, __cl_gen_to_be_invoked.LogoName);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_VersionInfo(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.SDKConfig __cl_gen_to_be_invoked = (xc.SDKConfig)translator.FastGetCSObj(L, 1);
                LuaAPI.lua_pushstring(L, __cl_gen_to_be_invoked.VersionInfo);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_LoginPrefab(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.SDKConfig __cl_gen_to_be_invoked = (xc.SDKConfig)translator.FastGetCSObj(L, 1);
                LuaAPI.lua_pushstring(L, __cl_gen_to_be_invoked.LoginPrefab);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_UIServerListWindow(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.SDKConfig __cl_gen_to_be_invoked = (xc.SDKConfig)translator.FastGetCSObj(L, 1);
                LuaAPI.lua_pushstring(L, __cl_gen_to_be_invoked.UIServerListWindow);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_UICreateActorWindow(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.SDKConfig __cl_gen_to_be_invoked = (xc.SDKConfig)translator.FastGetCSObj(L, 1);
                LuaAPI.lua_pushstring(L, __cl_gen_to_be_invoked.UICreateActorWindow);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_UIChargeWindow(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.SDKConfig __cl_gen_to_be_invoked = (xc.SDKConfig)translator.FastGetCSObj(L, 1);
                LuaAPI.lua_pushstring(L, __cl_gen_to_be_invoked.UIChargeWindow);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_UIMapWindow(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.SDKConfig __cl_gen_to_be_invoked = (xc.SDKConfig)translator.FastGetCSObj(L, 1);
                LuaAPI.lua_pushstring(L, __cl_gen_to_be_invoked.UIMapWindow);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_UIBagWindow(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.SDKConfig __cl_gen_to_be_invoked = (xc.SDKConfig)translator.FastGetCSObj(L, 1);
                LuaAPI.lua_pushstring(L, __cl_gen_to_be_invoked.UIBagWindow);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_UIPlayerPropertyWindow(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.SDKConfig __cl_gen_to_be_invoked = (xc.SDKConfig)translator.FastGetCSObj(L, 1);
                LuaAPI.lua_pushstring(L, __cl_gen_to_be_invoked.UIPlayerPropertyWindow);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_UIWelfareWindow(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.SDKConfig __cl_gen_to_be_invoked = (xc.SDKConfig)translator.FastGetCSObj(L, 1);
                LuaAPI.lua_pushstring(L, __cl_gen_to_be_invoked.UIWelfareWindow);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_UIOpenServerActWindow(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.SDKConfig __cl_gen_to_be_invoked = (xc.SDKConfig)translator.FastGetCSObj(L, 1);
                LuaAPI.lua_pushstring(L, __cl_gen_to_be_invoked.UIOpenServerActWindow);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_UIForecastWindow(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.SDKConfig __cl_gen_to_be_invoked = (xc.SDKConfig)translator.FastGetCSObj(L, 1);
                LuaAPI.lua_pushstring(L, __cl_gen_to_be_invoked.UIForecastWindow);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_UINpcDialogWindow(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.SDKConfig __cl_gen_to_be_invoked = (xc.SDKConfig)translator.FastGetCSObj(L, 1);
                LuaAPI.lua_pushstring(L, __cl_gen_to_be_invoked.UINpcDialogWindow);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_UISkillWindow(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.SDKConfig __cl_gen_to_be_invoked = (xc.SDKConfig)translator.FastGetCSObj(L, 1);
                LuaAPI.lua_pushstring(L, __cl_gen_to_be_invoked.UISkillWindow);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_UISettingMainWindow(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.SDKConfig __cl_gen_to_be_invoked = (xc.SDKConfig)translator.FastGetCSObj(L, 1);
                LuaAPI.lua_pushstring(L, __cl_gen_to_be_invoked.UISettingMainWindow);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_UIGoodsComposeWindow(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.SDKConfig __cl_gen_to_be_invoked = (xc.SDKConfig)translator.FastGetCSObj(L, 1);
                LuaAPI.lua_pushstring(L, __cl_gen_to_be_invoked.UIGoodsComposeWindow);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_UIDialogWindow(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.SDKConfig __cl_gen_to_be_invoked = (xc.SDKConfig)translator.FastGetCSObj(L, 1);
                LuaAPI.lua_pushstring(L, __cl_gen_to_be_invoked.UIDialogWindow);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_UISurfaceWindow(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.SDKConfig __cl_gen_to_be_invoked = (xc.SDKConfig)translator.FastGetCSObj(L, 1);
                LuaAPI.lua_pushstring(L, __cl_gen_to_be_invoked.UISurfaceWindow);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_UIPayWindow(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.SDKConfig __cl_gen_to_be_invoked = (xc.SDKConfig)translator.FastGetCSObj(L, 1);
                LuaAPI.lua_pushstring(L, __cl_gen_to_be_invoked.UIPayWindow);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_UIMainmapWindow(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.SDKConfig __cl_gen_to_be_invoked = (xc.SDKConfig)translator.FastGetCSObj(L, 1);
                LuaAPI.lua_pushstring(L, __cl_gen_to_be_invoked.UIMainmapWindow);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_is_copy_bag(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.SDKConfig __cl_gen_to_be_invoked = (xc.SDKConfig)translator.FastGetCSObj(L, 1);
                LuaAPI.lua_pushstring(L, __cl_gen_to_be_invoked.is_copy_bag);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_copy_bag_id(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.SDKConfig __cl_gen_to_be_invoked = (xc.SDKConfig)translator.FastGetCSObj(L, 1);
                LuaAPI.xlua_pushuint(L, __cl_gen_to_be_invoked.copy_bag_id);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_role_list(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.SDKConfig __cl_gen_to_be_invoked = (xc.SDKConfig)translator.FastGetCSObj(L, 1);
                translator.Push(L, __cl_gen_to_be_invoked.role_list);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_fashion_id(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.SDKConfig __cl_gen_to_be_invoked = (xc.SDKConfig)translator.FastGetCSObj(L, 1);
                LuaAPI.xlua_pushuint(L, __cl_gen_to_be_invoked.fashion_id);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_switch_model_scene(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.SDKConfig __cl_gen_to_be_invoked = (xc.SDKConfig)translator.FastGetCSObj(L, 1);
                LuaAPI.xlua_pushuint(L, __cl_gen_to_be_invoked.switch_model_scene);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_SDKNamePrefix(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.SDKConfig __cl_gen_to_be_invoked = (xc.SDKConfig)translator.FastGetCSObj(L, 1);
                __cl_gen_to_be_invoked.SDKNamePrefix = LuaAPI.lua_tostring(L, 2);
            
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_LogoName(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.SDKConfig __cl_gen_to_be_invoked = (xc.SDKConfig)translator.FastGetCSObj(L, 1);
                __cl_gen_to_be_invoked.LogoName = LuaAPI.lua_tostring(L, 2);
            
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_VersionInfo(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.SDKConfig __cl_gen_to_be_invoked = (xc.SDKConfig)translator.FastGetCSObj(L, 1);
                __cl_gen_to_be_invoked.VersionInfo = LuaAPI.lua_tostring(L, 2);
            
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_LoginPrefab(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.SDKConfig __cl_gen_to_be_invoked = (xc.SDKConfig)translator.FastGetCSObj(L, 1);
                __cl_gen_to_be_invoked.LoginPrefab = LuaAPI.lua_tostring(L, 2);
            
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_UIServerListWindow(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.SDKConfig __cl_gen_to_be_invoked = (xc.SDKConfig)translator.FastGetCSObj(L, 1);
                __cl_gen_to_be_invoked.UIServerListWindow = LuaAPI.lua_tostring(L, 2);
            
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_UICreateActorWindow(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.SDKConfig __cl_gen_to_be_invoked = (xc.SDKConfig)translator.FastGetCSObj(L, 1);
                __cl_gen_to_be_invoked.UICreateActorWindow = LuaAPI.lua_tostring(L, 2);
            
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_UIChargeWindow(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.SDKConfig __cl_gen_to_be_invoked = (xc.SDKConfig)translator.FastGetCSObj(L, 1);
                __cl_gen_to_be_invoked.UIChargeWindow = LuaAPI.lua_tostring(L, 2);
            
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_UIMapWindow(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.SDKConfig __cl_gen_to_be_invoked = (xc.SDKConfig)translator.FastGetCSObj(L, 1);
                __cl_gen_to_be_invoked.UIMapWindow = LuaAPI.lua_tostring(L, 2);
            
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_UIBagWindow(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.SDKConfig __cl_gen_to_be_invoked = (xc.SDKConfig)translator.FastGetCSObj(L, 1);
                __cl_gen_to_be_invoked.UIBagWindow = LuaAPI.lua_tostring(L, 2);
            
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_UIPlayerPropertyWindow(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.SDKConfig __cl_gen_to_be_invoked = (xc.SDKConfig)translator.FastGetCSObj(L, 1);
                __cl_gen_to_be_invoked.UIPlayerPropertyWindow = LuaAPI.lua_tostring(L, 2);
            
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_UIWelfareWindow(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.SDKConfig __cl_gen_to_be_invoked = (xc.SDKConfig)translator.FastGetCSObj(L, 1);
                __cl_gen_to_be_invoked.UIWelfareWindow = LuaAPI.lua_tostring(L, 2);
            
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_UIOpenServerActWindow(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.SDKConfig __cl_gen_to_be_invoked = (xc.SDKConfig)translator.FastGetCSObj(L, 1);
                __cl_gen_to_be_invoked.UIOpenServerActWindow = LuaAPI.lua_tostring(L, 2);
            
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_UIForecastWindow(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.SDKConfig __cl_gen_to_be_invoked = (xc.SDKConfig)translator.FastGetCSObj(L, 1);
                __cl_gen_to_be_invoked.UIForecastWindow = LuaAPI.lua_tostring(L, 2);
            
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_UINpcDialogWindow(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.SDKConfig __cl_gen_to_be_invoked = (xc.SDKConfig)translator.FastGetCSObj(L, 1);
                __cl_gen_to_be_invoked.UINpcDialogWindow = LuaAPI.lua_tostring(L, 2);
            
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_UISkillWindow(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.SDKConfig __cl_gen_to_be_invoked = (xc.SDKConfig)translator.FastGetCSObj(L, 1);
                __cl_gen_to_be_invoked.UISkillWindow = LuaAPI.lua_tostring(L, 2);
            
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_UISettingMainWindow(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.SDKConfig __cl_gen_to_be_invoked = (xc.SDKConfig)translator.FastGetCSObj(L, 1);
                __cl_gen_to_be_invoked.UISettingMainWindow = LuaAPI.lua_tostring(L, 2);
            
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_UIGoodsComposeWindow(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.SDKConfig __cl_gen_to_be_invoked = (xc.SDKConfig)translator.FastGetCSObj(L, 1);
                __cl_gen_to_be_invoked.UIGoodsComposeWindow = LuaAPI.lua_tostring(L, 2);
            
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_UIDialogWindow(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.SDKConfig __cl_gen_to_be_invoked = (xc.SDKConfig)translator.FastGetCSObj(L, 1);
                __cl_gen_to_be_invoked.UIDialogWindow = LuaAPI.lua_tostring(L, 2);
            
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_UISurfaceWindow(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.SDKConfig __cl_gen_to_be_invoked = (xc.SDKConfig)translator.FastGetCSObj(L, 1);
                __cl_gen_to_be_invoked.UISurfaceWindow = LuaAPI.lua_tostring(L, 2);
            
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_UIPayWindow(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.SDKConfig __cl_gen_to_be_invoked = (xc.SDKConfig)translator.FastGetCSObj(L, 1);
                __cl_gen_to_be_invoked.UIPayWindow = LuaAPI.lua_tostring(L, 2);
            
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_UIMainmapWindow(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.SDKConfig __cl_gen_to_be_invoked = (xc.SDKConfig)translator.FastGetCSObj(L, 1);
                __cl_gen_to_be_invoked.UIMainmapWindow = LuaAPI.lua_tostring(L, 2);
            
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_is_copy_bag(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.SDKConfig __cl_gen_to_be_invoked = (xc.SDKConfig)translator.FastGetCSObj(L, 1);
                __cl_gen_to_be_invoked.is_copy_bag = LuaAPI.lua_tostring(L, 2);
            
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_copy_bag_id(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.SDKConfig __cl_gen_to_be_invoked = (xc.SDKConfig)translator.FastGetCSObj(L, 1);
                __cl_gen_to_be_invoked.copy_bag_id = LuaAPI.xlua_touint(L, 2);
            
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_role_list(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.SDKConfig __cl_gen_to_be_invoked = (xc.SDKConfig)translator.FastGetCSObj(L, 1);
                __cl_gen_to_be_invoked.role_list = (System.Collections.Generic.List<uint>)translator.GetObject(L, 2, typeof(System.Collections.Generic.List<uint>));
            
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_fashion_id(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.SDKConfig __cl_gen_to_be_invoked = (xc.SDKConfig)translator.FastGetCSObj(L, 1);
                __cl_gen_to_be_invoked.fashion_id = LuaAPI.xlua_touint(L, 2);
            
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_switch_model_scene(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.SDKConfig __cl_gen_to_be_invoked = (xc.SDKConfig)translator.FastGetCSObj(L, 1);
                __cl_gen_to_be_invoked.switch_model_scene = LuaAPI.xlua_touint(L, 2);
            
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 0;
        }
        
		
		
		
		
    }
}
