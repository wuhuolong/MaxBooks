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
    public class xcMagicMagicEquipHelperWrap
    {
        public static void __Register(RealStatePtr L)
        {
			ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			XUtils.BeginObjectRegister(typeof(xc.Magic.MagicEquipHelper), L, translator, 0, 0, 0, 0);
			
			
			
			
			
			XUtils.EndObjectRegister(typeof(xc.Magic.MagicEquipHelper), L, translator, null, null,
			    null, null, null);

		    XUtils.BeginClassRegister(typeof(xc.Magic.MagicEquipHelper), L, __CreateInstance, 12, 0, 0);
			XUtils.RegisterFunc(L, XUtils.CLS_IDX, "GetStrengthAttr", _m_GetStrengthAttr_xlua_st_);
            XUtils.RegisterFunc(L, XUtils.CLS_IDX, "GetWearingEquipListByMagicId", _m_GetWearingEquipListByMagicId_xlua_st_);
            XUtils.RegisterFunc(L, XUtils.CLS_IDX, "GetWearingEquipByMagicIdAndPosId", _m_GetWearingEquipByMagicIdAndPosId_xlua_st_);
            XUtils.RegisterFunc(L, XUtils.CLS_IDX, "GetMagicAssistBaseAtts", _m_GetMagicAssistBaseAtts_xlua_st_);
            XUtils.RegisterFunc(L, XUtils.CLS_IDX, "GetMagicAssistEquipsAddAttrs", _m_GetMagicAssistEquipsAddAttrs_xlua_st_);
            XUtils.RegisterFunc(L, XUtils.CLS_IDX, "GetMagicScore", _m_GetMagicScore_xlua_st_);
            XUtils.RegisterFunc(L, XUtils.CLS_IDX, "IsHaveMatchEquip", _m_IsHaveMatchEquip_xlua_st_);
            XUtils.RegisterFunc(L, XUtils.CLS_IDX, "GetEquipAttributesString", _m_GetEquipAttributesString_xlua_st_);
            XUtils.RegisterFunc(L, XUtils.CLS_IDX, "ShowMagicEquipTipsWindowLayer", _m_ShowMagicEquipTipsWindowLayer_xlua_st_);
            XUtils.RegisterFunc(L, XUtils.CLS_IDX, "ShowMagicEquipTipsWindow", _m_ShowMagicEquipTipsWindow_xlua_st_);
            XUtils.RegisterFunc(L, XUtils.CLS_IDX, "GetGoodsNumForMagicEquipBagByTypeId", _m_GetGoodsNumForMagicEquipBagByTypeId_xlua_st_);
            
			
            
            XUtils.RegisterObject(L, translator, XUtils.CLS_IDX, "UnderlyingSystemType", typeof(xc.Magic.MagicEquipHelper));
			
			
			XUtils.EndClassRegister(typeof(xc.Magic.MagicEquipHelper), L, translator);
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int __CreateInstance(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			try {
				if(LuaAPI.lua_gettop(L) == 1)
				{
					
					xc.Magic.MagicEquipHelper __cl_gen_ret = new xc.Magic.MagicEquipHelper();
					translator.Push(L, __cl_gen_ret);
					return 1;
				}
				
			}
			catch(System.Exception __gen_e) {
				return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
			}
            return LuaAPI.luaL_error(L, "invalid arguments to xc.Magic.MagicEquipHelper constructor!");
            
        }
        
		
        
		
        
        
        
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_GetStrengthAttr_xlua_st_(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            
            try {
                
                {
                    uint strengthLv = LuaAPI.xlua_touint(L, 1);
                    xc.GoodsMagicEquip equip = (xc.GoodsMagicEquip)translator.GetObject(L, 2, typeof(xc.GoodsMagicEquip));
                    
                        xc.ActorAttribute __cl_gen_ret = xc.Magic.MagicEquipHelper.GetStrengthAttr( strengthLv, equip );
                        translator.Push(L, __cl_gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_GetWearingEquipListByMagicId_xlua_st_(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            
            try {
                
                {
                    uint magicId = LuaAPI.xlua_touint(L, 1);
                    
                        System.Collections.Generic.List<xc.GoodsMagicEquip> __cl_gen_ret = xc.Magic.MagicEquipHelper.GetWearingEquipListByMagicId( magicId );
                        translator.Push(L, __cl_gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_GetWearingEquipByMagicIdAndPosId_xlua_st_(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            
            try {
                
                {
                    uint magicId = LuaAPI.xlua_touint(L, 1);
                    uint posId = LuaAPI.xlua_touint(L, 2);
                    
                        xc.GoodsMagicEquip __cl_gen_ret = xc.Magic.MagicEquipHelper.GetWearingEquipByMagicIdAndPosId( magicId, posId );
                        translator.Push(L, __cl_gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_GetMagicAssistBaseAtts_xlua_st_(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            
            try {
                
                {
                    uint magicId = LuaAPI.xlua_touint(L, 1);
                    
                        xc.ActorAttribute __cl_gen_ret = xc.Magic.MagicEquipHelper.GetMagicAssistBaseAtts( magicId );
                        translator.Push(L, __cl_gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_GetMagicAssistEquipsAddAttrs_xlua_st_(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            
            try {
                
                {
                    uint magicId = LuaAPI.xlua_touint(L, 1);
                    
                        xc.ActorAttribute __cl_gen_ret = xc.Magic.MagicEquipHelper.GetMagicAssistEquipsAddAttrs( magicId );
                        translator.Push(L, __cl_gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_GetMagicScore_xlua_st_(RealStatePtr L)
        {
            
            
            
            try {
                
                {
                    uint magicId = LuaAPI.xlua_touint(L, 1);
                    
                        int __cl_gen_ret = xc.Magic.MagicEquipHelper.GetMagicScore( magicId );
                        LuaAPI.xlua_pushinteger(L, __cl_gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_IsHaveMatchEquip_xlua_st_(RealStatePtr L)
        {
            
            
            
            try {
                
                {
                    uint posId = LuaAPI.xlua_touint(L, 1);
                    uint color = LuaAPI.xlua_touint(L, 2);
                    
                        bool __cl_gen_ret = xc.Magic.MagicEquipHelper.IsHaveMatchEquip( posId, color );
                        LuaAPI.lua_pushboolean(L, __cl_gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_GetEquipAttributesString_xlua_st_(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            
            try {
                
                {
                    xc.Equip.EquipAttributes attrs = (xc.Equip.EquipAttributes)translator.GetObject(L, 1, typeof(xc.Equip.EquipAttributes));
                    
                        string __cl_gen_ret = xc.Magic.MagicEquipHelper.GetEquipAttributesString( attrs );
                        LuaAPI.lua_pushstring(L, __cl_gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_ShowMagicEquipTipsWindowLayer_xlua_st_(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            
            try {
                
                {
                    int layer = LuaAPI.xlua_tointeger(L, 1);
                    xc.GoodsMagicEquip equip = (xc.GoodsMagicEquip)translator.GetObject(L, 2, typeof(xc.GoodsMagicEquip));
                    string showType = LuaAPI.lua_tostring(L, 3);
                    
                    xc.Magic.MagicEquipHelper.ShowMagicEquipTipsWindowLayer( layer, equip, showType );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_ShowMagicEquipTipsWindow_xlua_st_(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            
			int __gen_param_count = LuaAPI.lua_gettop(L);
            
            try {
                if(__gen_param_count == 2&& translator.Assignable<xc.GoodsMagicEquip>(L, 1)&& (LuaAPI.lua_isnil(L, 2) || LuaAPI.lua_type(L, 2) == LuaTypes.LUA_TSTRING)) 
                {
                    xc.GoodsMagicEquip equip = (xc.GoodsMagicEquip)translator.GetObject(L, 1, typeof(xc.GoodsMagicEquip));
                    string showType = LuaAPI.lua_tostring(L, 2);
                    
                    xc.Magic.MagicEquipHelper.ShowMagicEquipTipsWindow( equip, showType );
                    
                    
                    
                    return 0;
                }
                if(__gen_param_count == 3&& translator.Assignable<xc.GoodsMagicEquip>(L, 1)&& (LuaAPI.lua_isnil(L, 2) || LuaAPI.lua_type(L, 2) == LuaTypes.LUA_TSTRING)&& LuaTypes.LUA_TNUMBER == LuaAPI.lua_type(L, 3)) 
                {
                    xc.GoodsMagicEquip equip = (xc.GoodsMagicEquip)translator.GetObject(L, 1, typeof(xc.GoodsMagicEquip));
                    string showType = LuaAPI.lua_tostring(L, 2);
                    uint magicId = LuaAPI.xlua_touint(L, 3);
                    
                    xc.Magic.MagicEquipHelper.ShowMagicEquipTipsWindow( equip, showType, magicId );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
            return LuaAPI.luaL_error(L, "invalid arguments to xc.Magic.MagicEquipHelper.ShowMagicEquipTipsWindow!");
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_GetGoodsNumForMagicEquipBagByTypeId_xlua_st_(RealStatePtr L)
        {
            
            
            
            try {
                
                {
                    uint eid = LuaAPI.xlua_touint(L, 1);
                    
                        ulong __cl_gen_ret = xc.Magic.MagicEquipHelper.GetGoodsNumForMagicEquipBagByTypeId( eid );
                        LuaAPI.lua_pushuint64(L, __cl_gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        
        
        
        
        
		
		
		
		
    }
}
