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
    public class xcHookSettingManagerWrap
    {
        public static void __Register(RealStatePtr L)
        {
			ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			XUtils.BeginObjectRegister(typeof(xc.HookSettingManager), L, translator, 0, 9, 9, 8);
			
			XUtils.RegisterFunc(L, XUtils.METHOD_IDX, "UpdateAutoBuyDrugGoodsId", _m_UpdateAutoBuyDrugGoodsId);
			XUtils.RegisterFunc(L, XUtils.METHOD_IDX, "UpdateAutoBuyDrugGoodsPrice", _m_UpdateAutoBuyDrugGoodsPrice);
			XUtils.RegisterFunc(L, XUtils.METHOD_IDX, "GetAutoPickDrop", _m_GetAutoPickDrop);
			XUtils.RegisterFunc(L, XUtils.METHOD_IDX, "SetAutoPickDrop", _m_SetAutoPickDrop);
			XUtils.RegisterFunc(L, XUtils.METHOD_IDX, "ChangeAutoPickDropSetting", _m_ChangeAutoPickDropSetting);
			XUtils.RegisterFunc(L, XUtils.METHOD_IDX, "Reset", _m_Reset);
			XUtils.RegisterFunc(L, XUtils.METHOD_IDX, "RegisterMessages", _m_RegisterMessages);
			XUtils.RegisterFunc(L, XUtils.METHOD_IDX, "Update", _m_Update);
			XUtils.RegisterFunc(L, XUtils.METHOD_IDX, "CheckIsInAutoPickDropGoodsSettingInfo", _m_CheckIsInAutoPickDropGoodsSettingInfo);
			
			
			XUtils.RegisterFunc(L, XUtils.GETTER_IDX, "UseHPDrugHPRatio", _g_get_UseHPDrugHPRatio);
            XUtils.RegisterFunc(L, XUtils.GETTER_IDX, "UseMPDrugMPRatio", _g_get_UseMPDrugMPRatio);
            XUtils.RegisterFunc(L, XUtils.GETTER_IDX, "RangeType", _g_get_RangeType);
            XUtils.RegisterFunc(L, XUtils.GETTER_IDX, "AutoBuyDrug", _g_get_AutoBuyDrug);
            XUtils.RegisterFunc(L, XUtils.GETTER_IDX, "AutoSwallow", _g_get_AutoSwallow);
            XUtils.RegisterFunc(L, XUtils.GETTER_IDX, "AutoRevive", _g_get_AutoRevive);
            XUtils.RegisterFunc(L, XUtils.GETTER_IDX, "AutoSellGoods", _g_get_AutoSellGoods);
            XUtils.RegisterFunc(L, XUtils.GETTER_IDX, "AutoPickDrop", _g_get_AutoPickDrop);
            XUtils.RegisterFunc(L, XUtils.GETTER_IDX, "AutoPickDropInfos", _g_get_AutoPickDropInfos);
            
			XUtils.RegisterFunc(L, XUtils.SETTER_IDX, "UseHPDrugHPRatio", _s_set_UseHPDrugHPRatio);
            XUtils.RegisterFunc(L, XUtils.SETTER_IDX, "UseMPDrugMPRatio", _s_set_UseMPDrugMPRatio);
            XUtils.RegisterFunc(L, XUtils.SETTER_IDX, "RangeType", _s_set_RangeType);
            XUtils.RegisterFunc(L, XUtils.SETTER_IDX, "AutoBuyDrug", _s_set_AutoBuyDrug);
            XUtils.RegisterFunc(L, XUtils.SETTER_IDX, "AutoSwallow", _s_set_AutoSwallow);
            XUtils.RegisterFunc(L, XUtils.SETTER_IDX, "AutoRevive", _s_set_AutoRevive);
            XUtils.RegisterFunc(L, XUtils.SETTER_IDX, "AutoSellGoods", _s_set_AutoSellGoods);
            XUtils.RegisterFunc(L, XUtils.SETTER_IDX, "AutoPickDrop", _s_set_AutoPickDrop);
            
			XUtils.EndObjectRegister(typeof(xc.HookSettingManager), L, translator, null, null,
			    null, null, null);

		    XUtils.BeginClassRegister(typeof(xc.HookSettingManager), L, __CreateInstance, 1, 0, 0);
			
			
            
            XUtils.RegisterObject(L, translator, XUtils.CLS_IDX, "UnderlyingSystemType", typeof(xc.HookSettingManager));
			
			
			XUtils.EndClassRegister(typeof(xc.HookSettingManager), L, translator);
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int __CreateInstance(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			try {
				if(LuaAPI.lua_gettop(L) == 1)
				{
					
					xc.HookSettingManager __cl_gen_ret = new xc.HookSettingManager();
					translator.Push(L, __cl_gen_ret);
					return 1;
				}
				
			}
			catch(System.Exception __gen_e) {
				return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
			}
            return LuaAPI.luaL_error(L, "invalid arguments to xc.HookSettingManager constructor!");
            
        }
        
		
        
		
        
        
        
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_UpdateAutoBuyDrugGoodsId(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            xc.HookSettingManager __cl_gen_to_be_invoked = (xc.HookSettingManager)translator.FastGetCSObj(L, 1);
            
            
            try {
                
                {
                    
                    __cl_gen_to_be_invoked.UpdateAutoBuyDrugGoodsId(  );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_UpdateAutoBuyDrugGoodsPrice(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            xc.HookSettingManager __cl_gen_to_be_invoked = (xc.HookSettingManager)translator.FastGetCSObj(L, 1);
            
            
            try {
                
                {
                    
                    __cl_gen_to_be_invoked.UpdateAutoBuyDrugGoodsPrice(  );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_GetAutoPickDrop(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            xc.HookSettingManager __cl_gen_to_be_invoked = (xc.HookSettingManager)translator.FastGetCSObj(L, 1);
            
            
            try {
                
                {
                    uint id = LuaAPI.xlua_touint(L, 2);
                    
                        bool __cl_gen_ret = __cl_gen_to_be_invoked.GetAutoPickDrop( id );
                        LuaAPI.lua_pushboolean(L, __cl_gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_SetAutoPickDrop(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            xc.HookSettingManager __cl_gen_to_be_invoked = (xc.HookSettingManager)translator.FastGetCSObj(L, 1);
            
            
            try {
                
                {
                    uint id = LuaAPI.xlua_touint(L, 2);
                    bool isOn = LuaAPI.lua_toboolean(L, 3);
                    
                    __cl_gen_to_be_invoked.SetAutoPickDrop( id, isOn );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_ChangeAutoPickDropSetting(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            xc.HookSettingManager __cl_gen_to_be_invoked = (xc.HookSettingManager)translator.FastGetCSObj(L, 1);
            
            
            try {
                
                {
                    uint id = LuaAPI.xlua_touint(L, 2);
                    bool isOn = LuaAPI.lua_toboolean(L, 3);
                    
                    __cl_gen_to_be_invoked.ChangeAutoPickDropSetting( id, isOn );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_Reset(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            xc.HookSettingManager __cl_gen_to_be_invoked = (xc.HookSettingManager)translator.FastGetCSObj(L, 1);
            
            
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
        static int _m_RegisterMessages(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            xc.HookSettingManager __cl_gen_to_be_invoked = (xc.HookSettingManager)translator.FastGetCSObj(L, 1);
            
            
            try {
                
                {
                    
                    __cl_gen_to_be_invoked.RegisterMessages(  );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_Update(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            xc.HookSettingManager __cl_gen_to_be_invoked = (xc.HookSettingManager)translator.FastGetCSObj(L, 1);
            
            
            try {
                
                {
                    
                    __cl_gen_to_be_invoked.Update(  );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_CheckIsInAutoPickDropGoodsSettingInfo(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            xc.HookSettingManager __cl_gen_to_be_invoked = (xc.HookSettingManager)translator.FastGetCSObj(L, 1);
            
            
            try {
                
                {
                    uint goodsId = LuaAPI.xlua_touint(L, 2);
                    
                        bool __cl_gen_ret = __cl_gen_to_be_invoked.CheckIsInAutoPickDropGoodsSettingInfo( goodsId );
                        LuaAPI.lua_pushboolean(L, __cl_gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        
        
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_UseHPDrugHPRatio(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.HookSettingManager __cl_gen_to_be_invoked = (xc.HookSettingManager)translator.FastGetCSObj(L, 1);
                LuaAPI.lua_pushnumber(L, __cl_gen_to_be_invoked.UseHPDrugHPRatio);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_UseMPDrugMPRatio(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.HookSettingManager __cl_gen_to_be_invoked = (xc.HookSettingManager)translator.FastGetCSObj(L, 1);
                LuaAPI.lua_pushnumber(L, __cl_gen_to_be_invoked.UseMPDrugMPRatio);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_RangeType(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.HookSettingManager __cl_gen_to_be_invoked = (xc.HookSettingManager)translator.FastGetCSObj(L, 1);
                translator.PushxcEHookRangeType(L, __cl_gen_to_be_invoked.RangeType);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_AutoBuyDrug(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.HookSettingManager __cl_gen_to_be_invoked = (xc.HookSettingManager)translator.FastGetCSObj(L, 1);
                LuaAPI.lua_pushboolean(L, __cl_gen_to_be_invoked.AutoBuyDrug);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_AutoSwallow(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.HookSettingManager __cl_gen_to_be_invoked = (xc.HookSettingManager)translator.FastGetCSObj(L, 1);
                LuaAPI.lua_pushboolean(L, __cl_gen_to_be_invoked.AutoSwallow);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_AutoRevive(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.HookSettingManager __cl_gen_to_be_invoked = (xc.HookSettingManager)translator.FastGetCSObj(L, 1);
                LuaAPI.lua_pushboolean(L, __cl_gen_to_be_invoked.AutoRevive);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_AutoSellGoods(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.HookSettingManager __cl_gen_to_be_invoked = (xc.HookSettingManager)translator.FastGetCSObj(L, 1);
                LuaAPI.lua_pushboolean(L, __cl_gen_to_be_invoked.AutoSellGoods);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_AutoPickDrop(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.HookSettingManager __cl_gen_to_be_invoked = (xc.HookSettingManager)translator.FastGetCSObj(L, 1);
                LuaAPI.lua_pushboolean(L, __cl_gen_to_be_invoked.AutoPickDrop);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_AutoPickDropInfos(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.HookSettingManager __cl_gen_to_be_invoked = (xc.HookSettingManager)translator.FastGetCSObj(L, 1);
                translator.Push(L, __cl_gen_to_be_invoked.AutoPickDropInfos);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_UseHPDrugHPRatio(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.HookSettingManager __cl_gen_to_be_invoked = (xc.HookSettingManager)translator.FastGetCSObj(L, 1);
                __cl_gen_to_be_invoked.UseHPDrugHPRatio = (float)LuaAPI.lua_tonumber(L, 2);
            
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_UseMPDrugMPRatio(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.HookSettingManager __cl_gen_to_be_invoked = (xc.HookSettingManager)translator.FastGetCSObj(L, 1);
                __cl_gen_to_be_invoked.UseMPDrugMPRatio = (float)LuaAPI.lua_tonumber(L, 2);
            
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_RangeType(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.HookSettingManager __cl_gen_to_be_invoked = (xc.HookSettingManager)translator.FastGetCSObj(L, 1);
                xc.EHookRangeType __cl_gen_value;translator.Get(L, 2, out __cl_gen_value);
				__cl_gen_to_be_invoked.RangeType = __cl_gen_value;
            
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_AutoBuyDrug(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.HookSettingManager __cl_gen_to_be_invoked = (xc.HookSettingManager)translator.FastGetCSObj(L, 1);
                __cl_gen_to_be_invoked.AutoBuyDrug = LuaAPI.lua_toboolean(L, 2);
            
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_AutoSwallow(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.HookSettingManager __cl_gen_to_be_invoked = (xc.HookSettingManager)translator.FastGetCSObj(L, 1);
                __cl_gen_to_be_invoked.AutoSwallow = LuaAPI.lua_toboolean(L, 2);
            
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_AutoRevive(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.HookSettingManager __cl_gen_to_be_invoked = (xc.HookSettingManager)translator.FastGetCSObj(L, 1);
                __cl_gen_to_be_invoked.AutoRevive = LuaAPI.lua_toboolean(L, 2);
            
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_AutoSellGoods(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.HookSettingManager __cl_gen_to_be_invoked = (xc.HookSettingManager)translator.FastGetCSObj(L, 1);
                __cl_gen_to_be_invoked.AutoSellGoods = LuaAPI.lua_toboolean(L, 2);
            
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_AutoPickDrop(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.HookSettingManager __cl_gen_to_be_invoked = (xc.HookSettingManager)translator.FastGetCSObj(L, 1);
                __cl_gen_to_be_invoked.AutoPickDrop = LuaAPI.lua_toboolean(L, 2);
            
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 0;
        }
        
		
		
		
		
    }
}
