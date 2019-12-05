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
    public class xcGoodsHelperWrap
    {
        public static void __Register(RealStatePtr L)
        {
			ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			XUtils.BeginObjectRegister(typeof(xc.GoodsHelper), L, translator, 0, 0, 0, 0);
			
			
			
			
			
			XUtils.EndObjectRegister(typeof(xc.GoodsHelper), L, translator, null, null,
			    null, null, null);

		    XUtils.BeginClassRegister(typeof(xc.GoodsHelper), L, __CreateInstance, 91, 1, 1);
			XUtils.RegisterFunc(L, XUtils.CLS_IDX, "StringToItemSubType", _m_StringToItemSubType_xlua_st_);
            XUtils.RegisterFunc(L, XUtils.CLS_IDX, "GetGoodsInfo", _m_GetGoodsInfo_xlua_st_);
            XUtils.RegisterFunc(L, XUtils.CLS_IDX, "GetUseGoodsNeedCount", _m_GetUseGoodsNeedCount_xlua_st_);
            XUtils.RegisterFunc(L, XUtils.CLS_IDX, "GetGoodsUseid", _m_GetGoodsUseid_xlua_st_);
            XUtils.RegisterFunc(L, XUtils.CLS_IDX, "GotoClientFuncByGoodsUseType", _m_GotoClientFuncByGoodsUseType_xlua_st_);
            XUtils.RegisterFunc(L, XUtils.CLS_IDX, "GetGoodsSubType", _m_GetGoodsSubType_xlua_st_);
            XUtils.RegisterFunc(L, XUtils.CLS_IDX, "GetGoodsType", _m_GetGoodsType_xlua_st_);
            XUtils.RegisterFunc(L, XUtils.CLS_IDX, "GetGoodsNameByTypeId", _m_GetGoodsNameByTypeId_xlua_st_);
            XUtils.RegisterFunc(L, XUtils.CLS_IDX, "IsGoodsPrecious", _m_IsGoodsPrecious_xlua_st_);
            XUtils.RegisterFunc(L, XUtils.CLS_IDX, "GetGoodsNameByTypeId_blackBkg", _m_GetGoodsNameByTypeId_blackBkg_xlua_st_);
            XUtils.RegisterFunc(L, XUtils.CLS_IDX, "GetGoodsOriginalNameByTypeId", _m_GetGoodsOriginalNameByTypeId_xlua_st_);
            XUtils.RegisterFunc(L, XUtils.CLS_IDX, "GetGoodsEffectByTypeId", _m_GetGoodsEffectByTypeId_xlua_st_);
            XUtils.RegisterFunc(L, XUtils.CLS_IDX, "GetGoodsMarketType1ByTypeId", _m_GetGoodsMarketType1ByTypeId_xlua_st_);
            XUtils.RegisterFunc(L, XUtils.CLS_IDX, "GetGoodsMarketType2ByTypeId", _m_GetGoodsMarketType2ByTypeId_xlua_st_);
            XUtils.RegisterFunc(L, XUtils.CLS_IDX, "GetGoodsArgByTypeId", _m_GetGoodsArgByTypeId_xlua_st_);
            XUtils.RegisterFunc(L, XUtils.CLS_IDX, "GetGoodsDescriptionByTypeId", _m_GetGoodsDescriptionByTypeId_xlua_st_);
            XUtils.RegisterFunc(L, XUtils.CLS_IDX, "GetGoodsCustomBaseDes", _m_GetGoodsCustomBaseDes_xlua_st_);
            XUtils.RegisterFunc(L, XUtils.CLS_IDX, "GetGoodsBindDBByTypeId", _m_GetGoodsBindDBByTypeId_xlua_st_);
            XUtils.RegisterFunc(L, XUtils.CLS_IDX, "GetGoodsColorTypeByTypeId", _m_GetGoodsColorTypeByTypeId_xlua_st_);
            XUtils.RegisterFunc(L, XUtils.CLS_IDX, "GetGoodsColorByTypeId", _m_GetGoodsColorByTypeId_xlua_st_);
            XUtils.RegisterFunc(L, XUtils.CLS_IDX, "GetGoodsQualityColor", _m_GetGoodsQualityColor_xlua_st_);
            XUtils.RegisterFunc(L, XUtils.CLS_IDX, "GetCompositeStuffData", _m_GetCompositeStuffData_xlua_st_);
            XUtils.RegisterFunc(L, XUtils.CLS_IDX, "GetCompositeData", _m_GetCompositeData_xlua_st_);
            XUtils.RegisterFunc(L, XUtils.CLS_IDX, "OpenGoodsSysWindow", _m_OpenGoodsSysWindow_xlua_st_);
            XUtils.RegisterFunc(L, XUtils.CLS_IDX, "GetGoodsEffectPath", _m_GetGoodsEffectPath_xlua_st_);
            XUtils.RegisterFunc(L, XUtils.CLS_IDX, "GetGoodsColorSpr", _m_GetGoodsColorSpr_xlua_st_);
            XUtils.RegisterFunc(L, XUtils.CLS_IDX, "GetGoodsColorByQua", _m_GetGoodsColorByQua_xlua_st_);
            XUtils.RegisterFunc(L, XUtils.CLS_IDX, "GetGoodsIconTexutreByTypeId", _m_GetGoodsIconTexutreByTypeId_xlua_st_);
            XUtils.RegisterFunc(L, XUtils.CLS_IDX, "GetGoodsIconTextureByIconId", _m_GetGoodsIconTextureByIconId_xlua_st_);
            XUtils.RegisterFunc(L, XUtils.CLS_IDX, "RemoveLoadGoodsIcon", _m_RemoveLoadGoodsIcon_xlua_st_);
            XUtils.RegisterFunc(L, XUtils.CLS_IDX, "GetGoodsIconIdByTypeId", _m_GetGoodsIconIdByTypeId_xlua_st_);
            XUtils.RegisterFunc(L, XUtils.CLS_IDX, "GetGoodsUseJobByTpyeId", _m_GetGoodsUseJobByTpyeId_xlua_st_);
            XUtils.RegisterFunc(L, XUtils.CLS_IDX, "GetDisplayIconId", _m_GetDisplayIconId_xlua_st_);
            XUtils.RegisterFunc(L, XUtils.CLS_IDX, "GetIconInfo", _m_GetIconInfo_xlua_st_);
            XUtils.RegisterFunc(L, XUtils.CLS_IDX, "CreateGoodsByTypeId", _m_CreateGoodsByTypeId_xlua_st_);
            XUtils.RegisterFunc(L, XUtils.CLS_IDX, "GetGoodsUseJob", _m_GetGoodsUseJob_xlua_st_);
            XUtils.RegisterFunc(L, XUtils.CLS_IDX, "GoodsIsMoney", _m_GoodsIsMoney_xlua_st_);
            XUtils.RegisterFunc(L, XUtils.CLS_IDX, "GetGoodsColor", _m_GetGoodsColor_xlua_st_);
            XUtils.RegisterFunc(L, XUtils.CLS_IDX, "ReplaceGoodsColor_whiteBkg", _m_ReplaceGoodsColor_whiteBkg_xlua_st_);
            XUtils.RegisterFunc(L, XUtils.CLS_IDX, "ReplaceGoodsColor_blackBkg", _m_ReplaceGoodsColor_blackBkg_xlua_st_);
            XUtils.RegisterFunc(L, XUtils.CLS_IDX, "GetGoodsColor_whiteBkg", _m_GetGoodsColor_whiteBkg_xlua_st_);
            XUtils.RegisterFunc(L, XUtils.CLS_IDX, "GetGoodsColor_blackBkg", _m_GetGoodsColor_blackBkg_xlua_st_);
            XUtils.RegisterFunc(L, XUtils.CLS_IDX, "GetGoodsColorName", _m_GetGoodsColorName_xlua_st_);
            XUtils.RegisterFunc(L, XUtils.CLS_IDX, "GetTextColor", _m_GetTextColor_xlua_st_);
            XUtils.RegisterFunc(L, XUtils.CLS_IDX, "GetGoodsFromPkgInfo", _m_GetGoodsFromPkgInfo_xlua_st_);
            XUtils.RegisterFunc(L, XUtils.CLS_IDX, "CreateEquipFromNet", _m_CreateEquipFromNet_xlua_st_);
            XUtils.RegisterFunc(L, XUtils.CLS_IDX, "CreateEquipGoodsFromNet", _m_CreateEquipGoodsFromNet_xlua_st_);
            XUtils.RegisterFunc(L, XUtils.CLS_IDX, "CreateEquipGoodsByTypeId", _m_CreateEquipGoodsByTypeId_xlua_st_);
            XUtils.RegisterFunc(L, XUtils.CLS_IDX, "CreateGoodsFromNetByProtocol", _m_CreateGoodsFromNetByProtocol_xlua_st_);
            XUtils.RegisterFunc(L, XUtils.CLS_IDX, "GetSoulSortList", _m_GetSoulSortList_xlua_st_);
            XUtils.RegisterFunc(L, XUtils.CLS_IDX, "GetSoulSortList_noCheckInstall", _m_GetSoulSortList_noCheckInstall_xlua_st_);
            XUtils.RegisterFunc(L, XUtils.CLS_IDX, "GetSoulIsInstall", _m_GetSoulIsInstall_xlua_st_);
            XUtils.RegisterFunc(L, XUtils.CLS_IDX, "SoulCanInstallHole", _m_SoulCanInstallHole_xlua_st_);
            XUtils.RegisterFunc(L, XUtils.CLS_IDX, "SoulCanInstallHoleNew", _m_SoulCanInstallHoleNew_xlua_st_);
            XUtils.RegisterFunc(L, XUtils.CLS_IDX, "CheckNeedRemoveInstallWhenInstall", _m_CheckNeedRemoveInstallWhenInstall_xlua_st_);
            XUtils.RegisterFunc(L, XUtils.CLS_IDX, "GetBodyGoodSoulByHoleId", _m_GetBodyGoodSoulByHoleId_xlua_st_);
            XUtils.RegisterFunc(L, XUtils.CLS_IDX, "CheckIsBodyOrBagHaveSoul", _m_CheckIsBodyOrBagHaveSoul_xlua_st_);
            XUtils.RegisterFunc(L, XUtils.CLS_IDX, "SoulBagIsHaveCanEquipByHoleId", _m_SoulBagIsHaveCanEquipByHoleId_xlua_st_);
            XUtils.RegisterFunc(L, XUtils.CLS_IDX, "AllSoulTypeIds", _m_AllSoulTypeIds_xlua_st_);
            XUtils.RegisterFunc(L, XUtils.CLS_IDX, "GetSoulCostTotalVal", _m_GetSoulCostTotalVal_xlua_st_);
            XUtils.RegisterFunc(L, XUtils.CLS_IDX, "GetSoulBookTypeAllIds", _m_GetSoulBookTypeAllIds_xlua_st_);
            XUtils.RegisterFunc(L, XUtils.CLS_IDX, "GetSoulBookAttrStr", _m_GetSoulBookAttrStr_xlua_st_);
            XUtils.RegisterFunc(L, XUtils.CLS_IDX, "GetTotalSoulBookAttr", _m_GetTotalSoulBookAttr_xlua_st_);
            XUtils.RegisterFunc(L, XUtils.CLS_IDX, "GetTotalSoulBookAttr_list", _m_GetTotalSoulBookAttr_list_xlua_st_);
            XUtils.RegisterFunc(L, XUtils.CLS_IDX, "InstallSoulTotalAllAttrStr", _m_InstallSoulTotalAllAttrStr_xlua_st_);
            XUtils.RegisterFunc(L, XUtils.CLS_IDX, "InstallSoulTotalAllAttrStrArray", _m_InstallSoulTotalAllAttrStrArray_xlua_st_);
            XUtils.RegisterFunc(L, XUtils.CLS_IDX, "GetBodyAndBagMaxLevelSoulItem", _m_GetBodyAndBagMaxLevelSoulItem_xlua_st_);
            XUtils.RegisterFunc(L, XUtils.CLS_IDX, "GetSoulAttrByLv", _m_GetSoulAttrByLv_xlua_st_);
            XUtils.RegisterFunc(L, XUtils.CLS_IDX, "GetSoulActiveNumByType", _m_GetSoulActiveNumByType_xlua_st_);
            XUtils.RegisterFunc(L, XUtils.CLS_IDX, "GetSoulOpenCondtionStr", _m_GetSoulOpenCondtionStr_xlua_st_);
            XUtils.RegisterFunc(L, XUtils.CLS_IDX, "IsSoulActive", _m_IsSoulActive_xlua_st_);
            XUtils.RegisterFunc(L, XUtils.CLS_IDX, "IsSoulHave", _m_IsSoulHave_xlua_st_);
            XUtils.RegisterFunc(L, XUtils.CLS_IDX, "GetSoulBookSoulList", _m_GetSoulBookSoulList_xlua_st_);
            XUtils.RegisterFunc(L, XUtils.CLS_IDX, "GetQualityByGid", _m_GetQualityByGid_xlua_st_);
            XUtils.RegisterFunc(L, XUtils.CLS_IDX, "GetBagUnLockTotal", _m_GetBagUnLockTotal_xlua_st_);
            XUtils.RegisterFunc(L, XUtils.CLS_IDX, "CheckUseGoodsIsInCD", _m_CheckUseGoodsIsInCD_xlua_st_);
            XUtils.RegisterFunc(L, XUtils.CLS_IDX, "CheckCanUseByVocation", _m_CheckCanUseByVocation_xlua_st_);
            XUtils.RegisterFunc(L, XUtils.CLS_IDX, "CheckGoodsCanUse", _m_CheckGoodsCanUse_xlua_st_);
            XUtils.RegisterFunc(L, XUtils.CLS_IDX, "GetGoodsCDId", _m_GetGoodsCDId_xlua_st_);
            XUtils.RegisterFunc(L, XUtils.CLS_IDX, "ParseClientGoodsStr", _m_ParseClientGoodsStr_xlua_st_);
            XUtils.RegisterFunc(L, XUtils.CLS_IDX, "GetClientGoodsStr", _m_GetClientGoodsStr_xlua_st_);
            XUtils.RegisterFunc(L, XUtils.CLS_IDX, "ShowGoodsTips", _m_ShowGoodsTips_xlua_st_);
            XUtils.RegisterFunc(L, XUtils.CLS_IDX, "GetLegendTopScoreByGroupId", _m_GetLegendTopScoreByGroupId_xlua_st_);
            XUtils.RegisterFunc(L, XUtils.CLS_IDX, "GetGoodsShowAttr", _m_GetGoodsShowAttr_xlua_st_);
            XUtils.RegisterFunc(L, XUtils.CLS_IDX, "GetGoodsShowBattlePower", _m_GetGoodsShowBattlePower_xlua_st_);
            XUtils.RegisterFunc(L, XUtils.CLS_IDX, "GetGoodsCanShortcutUseByBagType", _m_GetGoodsCanShortcutUseByBagType_xlua_st_);
            XUtils.RegisterFunc(L, XUtils.CLS_IDX, "GetGoodsHaveGetTipsByBagType", _m_GetGoodsHaveGetTipsByBagType_xlua_st_);
            XUtils.RegisterFunc(L, XUtils.CLS_IDX, "GetGoodsLuaScriptByGoodsId", _m_GetGoodsLuaScriptByGoodsId_xlua_st_);
            XUtils.RegisterFunc(L, XUtils.CLS_IDX, "GetGoodsTipsWindowByGoodsId", _m_GetGoodsTipsWindowByGoodsId_xlua_st_);
            XUtils.RegisterFunc(L, XUtils.CLS_IDX, "GetGoodsBagTypeByGoodsId", _m_GetGoodsBagTypeByGoodsId_xlua_st_);
            
			
            
            XUtils.RegisterObject(L, translator, XUtils.CLS_IDX, "UnderlyingSystemType", typeof(xc.GoodsHelper));
			XUtils.RegisterFunc(L, XUtils.CLS_GETTER_IDX, "GoodsPrefab", _g_get_GoodsPrefab);
            
			XUtils.RegisterFunc(L, XUtils.CLS_SETTER_IDX, "GoodsPrefab", _s_set_GoodsPrefab);
            
			XUtils.EndClassRegister(typeof(xc.GoodsHelper), L, translator);
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int __CreateInstance(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			try {
				if(LuaAPI.lua_gettop(L) == 1)
				{
					
					xc.GoodsHelper __cl_gen_ret = new xc.GoodsHelper();
					translator.Push(L, __cl_gen_ret);
					return 1;
				}
				
			}
			catch(System.Exception __gen_e) {
				return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
			}
            return LuaAPI.luaL_error(L, "invalid arguments to xc.GoodsHelper constructor!");
            
        }
        
		
        
		
        
        
        
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_StringToItemSubType_xlua_st_(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            
            try {
                
                {
                    string raw = LuaAPI.lua_tostring(L, 1);
                    
                        xc.GoodsHelper.ItemMainType __cl_gen_ret = xc.GoodsHelper.StringToItemSubType( raw );
                        translator.PushxcGoodsHelperItemMainType(L, __cl_gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_GetGoodsInfo_xlua_st_(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            
            try {
                
                {
                    uint gid = LuaAPI.xlua_touint(L, 1);
                    
                        xc.GoodsInfo __cl_gen_ret = xc.GoodsHelper.GetGoodsInfo( gid );
                        translator.Push(L, __cl_gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_GetUseGoodsNeedCount_xlua_st_(RealStatePtr L)
        {
            
            
            
            try {
                
                {
                    uint typeId = LuaAPI.xlua_touint(L, 1);
                    
                        uint __cl_gen_ret = xc.GoodsHelper.GetUseGoodsNeedCount( typeId );
                        LuaAPI.xlua_pushuint(L, __cl_gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_GetGoodsUseid_xlua_st_(RealStatePtr L)
        {
            
            
            
            try {
                
                {
                    uint typeId = LuaAPI.xlua_touint(L, 1);
                    
                        uint __cl_gen_ret = xc.GoodsHelper.GetGoodsUseid( typeId );
                        LuaAPI.xlua_pushuint(L, __cl_gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_GotoClientFuncByGoodsUseType_xlua_st_(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            
            try {
                
                {
                    xc.Goods goods = (xc.Goods)translator.GetObject(L, 1, typeof(xc.Goods));
                    
                    xc.GoodsHelper.GotoClientFuncByGoodsUseType( goods );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_GetGoodsSubType_xlua_st_(RealStatePtr L)
        {
            
            
            
            try {
                
                {
                    uint typeId = LuaAPI.xlua_touint(L, 1);
                    
                        uint __cl_gen_ret = xc.GoodsHelper.GetGoodsSubType( typeId );
                        LuaAPI.xlua_pushuint(L, __cl_gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_GetGoodsType_xlua_st_(RealStatePtr L)
        {
            
            
            
            try {
                
                {
                    uint typeId = LuaAPI.xlua_touint(L, 1);
                    
                        uint __cl_gen_ret = xc.GoodsHelper.GetGoodsType( typeId );
                        LuaAPI.xlua_pushuint(L, __cl_gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_GetGoodsNameByTypeId_xlua_st_(RealStatePtr L)
        {
            
            
            
            try {
                
                {
                    uint typeId = LuaAPI.xlua_touint(L, 1);
                    
                        string __cl_gen_ret = xc.GoodsHelper.GetGoodsNameByTypeId( typeId );
                        LuaAPI.lua_pushstring(L, __cl_gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_IsGoodsPrecious_xlua_st_(RealStatePtr L)
        {
            
            
            
            try {
                
                {
                    uint typeId = LuaAPI.xlua_touint(L, 1);
                    
                        bool __cl_gen_ret = xc.GoodsHelper.IsGoodsPrecious( typeId );
                        LuaAPI.lua_pushboolean(L, __cl_gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_GetGoodsNameByTypeId_blackBkg_xlua_st_(RealStatePtr L)
        {
            
            
            
            try {
                
                {
                    uint typeId = LuaAPI.xlua_touint(L, 1);
                    
                        string __cl_gen_ret = xc.GoodsHelper.GetGoodsNameByTypeId_blackBkg( typeId );
                        LuaAPI.lua_pushstring(L, __cl_gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_GetGoodsOriginalNameByTypeId_xlua_st_(RealStatePtr L)
        {
            
            
            
            try {
                
                {
                    uint typeId = LuaAPI.xlua_touint(L, 1);
                    
                        string __cl_gen_ret = xc.GoodsHelper.GetGoodsOriginalNameByTypeId( typeId );
                        LuaAPI.lua_pushstring(L, __cl_gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_GetGoodsEffectByTypeId_xlua_st_(RealStatePtr L)
        {
            
            
            
            try {
                
                {
                    uint typeId = LuaAPI.xlua_touint(L, 1);
                    
                        string __cl_gen_ret = xc.GoodsHelper.GetGoodsEffectByTypeId( typeId );
                        LuaAPI.lua_pushstring(L, __cl_gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_GetGoodsMarketType1ByTypeId_xlua_st_(RealStatePtr L)
        {
            
            
            
            try {
                
                {
                    uint typeId = LuaAPI.xlua_touint(L, 1);
                    
                        uint __cl_gen_ret = xc.GoodsHelper.GetGoodsMarketType1ByTypeId( typeId );
                        LuaAPI.xlua_pushuint(L, __cl_gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_GetGoodsMarketType2ByTypeId_xlua_st_(RealStatePtr L)
        {
            
            
            
            try {
                
                {
                    uint typeId = LuaAPI.xlua_touint(L, 1);
                    
                        uint __cl_gen_ret = xc.GoodsHelper.GetGoodsMarketType2ByTypeId( typeId );
                        LuaAPI.xlua_pushuint(L, __cl_gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_GetGoodsArgByTypeId_xlua_st_(RealStatePtr L)
        {
            
            
            
            try {
                
                {
                    uint typeId = LuaAPI.xlua_touint(L, 1);
                    
                        string __cl_gen_ret = xc.GoodsHelper.GetGoodsArgByTypeId( typeId );
                        LuaAPI.lua_pushstring(L, __cl_gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_GetGoodsDescriptionByTypeId_xlua_st_(RealStatePtr L)
        {
            
            
            
            try {
                
                {
                    uint typeId = LuaAPI.xlua_touint(L, 1);
                    
                        string __cl_gen_ret = xc.GoodsHelper.GetGoodsDescriptionByTypeId( typeId );
                        LuaAPI.lua_pushstring(L, __cl_gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_GetGoodsCustomBaseDes_xlua_st_(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            
            try {
                
                {
                    xc.ActorAttribute attr = (xc.ActorAttribute)translator.GetObject(L, 1, typeof(xc.ActorAttribute));
                    
                        System.Collections.Generic.List<string> __cl_gen_ret = xc.GoodsHelper.GetGoodsCustomBaseDes( attr );
                        translator.Push(L, __cl_gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_GetGoodsBindDBByTypeId_xlua_st_(RealStatePtr L)
        {
            
            
            
            try {
                
                {
                    uint typeId = LuaAPI.xlua_touint(L, 1);
                    
                        uint __cl_gen_ret = xc.GoodsHelper.GetGoodsBindDBByTypeId( typeId );
                        LuaAPI.xlua_pushuint(L, __cl_gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_GetGoodsColorTypeByTypeId_xlua_st_(RealStatePtr L)
        {
            
            
            
            try {
                
                {
                    uint typeId = LuaAPI.xlua_touint(L, 1);
                    
                        uint __cl_gen_ret = xc.GoodsHelper.GetGoodsColorTypeByTypeId( typeId );
                        LuaAPI.xlua_pushuint(L, __cl_gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_GetGoodsColorByTypeId_xlua_st_(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            
            try {
                
                {
                    uint typeId = LuaAPI.xlua_touint(L, 1);
                    
                        UnityEngine.Color __cl_gen_ret = xc.GoodsHelper.GetGoodsColorByTypeId( typeId );
                        translator.PushUnityEngineColor(L, __cl_gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_GetGoodsQualityColor_xlua_st_(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            
			int __gen_param_count = LuaAPI.lua_gettop(L);
            
            try {
                if(__gen_param_count == 1&& translator.Assignable<xc.EGoodsQuality>(L, 1)) 
                {
                    xc.EGoodsQuality quality;translator.Get(L, 1, out quality);
                    
                        UnityEngine.Color __cl_gen_ret = xc.GoodsHelper.GetGoodsQualityColor( quality );
                        translator.PushUnityEngineColor(L, __cl_gen_ret);
                    
                    
                    
                    return 1;
                }
                if(__gen_param_count == 1&& translator.Assignable<xc.Goods>(L, 1)) 
                {
                    xc.Goods goods = (xc.Goods)translator.GetObject(L, 1, typeof(xc.Goods));
                    
                        UnityEngine.Color __cl_gen_ret = xc.GoodsHelper.GetGoodsQualityColor( goods );
                        translator.PushUnityEngineColor(L, __cl_gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
            return LuaAPI.luaL_error(L, "invalid arguments to xc.GoodsHelper.GetGoodsQualityColor!");
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_GetCompositeStuffData_xlua_st_(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            
            try {
                
                {
                    uint com_id = LuaAPI.xlua_touint(L, 1);
                    
                        xc.GoodsCompositeStuffData __cl_gen_ret = xc.GoodsHelper.GetCompositeStuffData( com_id );
                        translator.Push(L, __cl_gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_GetCompositeData_xlua_st_(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            
            try {
                
                {
                    string const_value = LuaAPI.lua_tostring(L, 1);
                    
                        xc.GoodsCompositeData __cl_gen_ret = xc.GoodsHelper.GetCompositeData( const_value );
                        translator.Push(L, __cl_gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_OpenGoodsSysWindow_xlua_st_(RealStatePtr L)
        {
            
            
            
            try {
                
                {
                    uint gid = LuaAPI.xlua_touint(L, 1);
                    
                        bool __cl_gen_ret = xc.GoodsHelper.OpenGoodsSysWindow( gid );
                        LuaAPI.lua_pushboolean(L, __cl_gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_GetGoodsEffectPath_xlua_st_(RealStatePtr L)
        {
            
            
            
            try {
                
                {
                    uint qua = LuaAPI.xlua_touint(L, 1);
                    
                        string __cl_gen_ret = xc.GoodsHelper.GetGoodsEffectPath( qua );
                        LuaAPI.lua_pushstring(L, __cl_gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_GetGoodsColorSpr_xlua_st_(RealStatePtr L)
        {
            
            
            
            try {
                
                {
                    uint qua = LuaAPI.xlua_touint(L, 1);
                    
                        string __cl_gen_ret = xc.GoodsHelper.GetGoodsColorSpr( qua );
                        LuaAPI.lua_pushstring(L, __cl_gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_GetGoodsColorByQua_xlua_st_(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            
            try {
                
                {
                    uint qua = LuaAPI.xlua_touint(L, 1);
                    
                        UnityEngine.Color __cl_gen_ret = xc.GoodsHelper.GetGoodsColorByQua( qua );
                        translator.PushUnityEngineColor(L, __cl_gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_GetGoodsIconTexutreByTypeId_xlua_st_(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            
            try {
                
                {
                    uint id = LuaAPI.xlua_touint(L, 1);
                    UnityEngine.UI.RawImage tex = (UnityEngine.UI.RawImage)translator.GetObject(L, 2, typeof(UnityEngine.UI.RawImage));
                    
                        uint __cl_gen_ret = xc.GoodsHelper.GetGoodsIconTexutreByTypeId( id, tex );
                        LuaAPI.xlua_pushuint(L, __cl_gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_GetGoodsIconTextureByIconId_xlua_st_(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            
            try {
                
                {
                    uint iconId = LuaAPI.xlua_touint(L, 1);
                    UnityEngine.UI.RawImage text = (UnityEngine.UI.RawImage)translator.GetObject(L, 2, typeof(UnityEngine.UI.RawImage));
                    
                        uint __cl_gen_ret = xc.GoodsHelper.GetGoodsIconTextureByIconId( iconId, text );
                        LuaAPI.xlua_pushuint(L, __cl_gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_RemoveLoadGoodsIcon_xlua_st_(RealStatePtr L)
        {
            
            
            
            try {
                
                {
                    uint load_icon_id = LuaAPI.xlua_touint(L, 1);
                    
                    xc.GoodsHelper.RemoveLoadGoodsIcon( load_icon_id );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_GetGoodsIconIdByTypeId_xlua_st_(RealStatePtr L)
        {
            
            
            
            try {
                
                {
                    uint id = LuaAPI.xlua_touint(L, 1);
                    
                        uint __cl_gen_ret = xc.GoodsHelper.GetGoodsIconIdByTypeId( id );
                        LuaAPI.xlua_pushuint(L, __cl_gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_GetGoodsUseJobByTpyeId_xlua_st_(RealStatePtr L)
        {
            
            
            
            try {
                
                {
                    uint id = LuaAPI.xlua_touint(L, 1);
                    
                        uint __cl_gen_ret = xc.GoodsHelper.GetGoodsUseJobByTpyeId( id );
                        LuaAPI.xlua_pushuint(L, __cl_gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_GetDisplayIconId_xlua_st_(RealStatePtr L)
        {
            
            
            
            try {
                
                {
                    uint rawIconId = LuaAPI.xlua_touint(L, 1);
                    
                        uint __cl_gen_ret = xc.GoodsHelper.GetDisplayIconId( rawIconId );
                        LuaAPI.xlua_pushuint(L, __cl_gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_GetIconInfo_xlua_st_(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            
            try {
                
                {
                    uint icon_id = LuaAPI.xlua_touint(L, 1);
                    
                        xc.IconInfo __cl_gen_ret = xc.GoodsHelper.GetIconInfo( icon_id );
                        translator.Push(L, __cl_gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_CreateGoodsByTypeId_xlua_st_(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            
			int __gen_param_count = LuaAPI.lua_gettop(L);
            
            try {
                if(__gen_param_count == 1&& LuaTypes.LUA_TNUMBER == LuaAPI.lua_type(L, 1)) 
                {
                    uint typeId = LuaAPI.xlua_touint(L, 1);
                    
                        xc.Goods __cl_gen_ret = xc.GoodsHelper.CreateGoodsByTypeId( typeId );
                        translator.Push(L, __cl_gen_ret);
                    
                    
                    
                    return 1;
                }
                if(__gen_param_count == 2&& LuaTypes.LUA_TNUMBER == LuaAPI.lua_type(L, 1)&& LuaTypes.LUA_TNUMBER == LuaAPI.lua_type(L, 2)) 
                {
                    uint typeId = LuaAPI.xlua_touint(L, 1);
                    uint main_type = LuaAPI.xlua_touint(L, 2);
                    
                        xc.Goods __cl_gen_ret = xc.GoodsHelper.CreateGoodsByTypeId( typeId, main_type );
                        translator.Push(L, __cl_gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
            return LuaAPI.luaL_error(L, "invalid arguments to xc.GoodsHelper.CreateGoodsByTypeId!");
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_GetGoodsUseJob_xlua_st_(RealStatePtr L)
        {
            
            
            
            try {
                
                {
                    uint use_job = LuaAPI.xlua_touint(L, 1);
                    
                        string __cl_gen_ret = xc.GoodsHelper.GetGoodsUseJob( use_job );
                        LuaAPI.lua_pushstring(L, __cl_gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_GoodsIsMoney_xlua_st_(RealStatePtr L)
        {
            
            
            
            try {
                
                {
                    uint gid = LuaAPI.xlua_touint(L, 1);
                    
                        bool __cl_gen_ret = xc.GoodsHelper.GoodsIsMoney( gid );
                        LuaAPI.lua_pushboolean(L, __cl_gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_GetGoodsColor_xlua_st_(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            
			int __gen_param_count = LuaAPI.lua_gettop(L);
            
            try {
                if(__gen_param_count == 1&& LuaTypes.LUA_TNUMBER == LuaAPI.lua_type(L, 1)) 
                {
                    uint quality = LuaAPI.xlua_touint(L, 1);
                    
                        string __cl_gen_ret = xc.GoodsHelper.GetGoodsColor( quality );
                        LuaAPI.lua_pushstring(L, __cl_gen_ret);
                    
                    
                    
                    return 1;
                }
                if(__gen_param_count == 1&& translator.Assignable<xc.Goods>(L, 1)) 
                {
                    xc.Goods goods = (xc.Goods)translator.GetObject(L, 1, typeof(xc.Goods));
                    
                        string __cl_gen_ret = xc.GoodsHelper.GetGoodsColor( goods );
                        LuaAPI.lua_pushstring(L, __cl_gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
            return LuaAPI.luaL_error(L, "invalid arguments to xc.GoodsHelper.GetGoodsColor!");
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_ReplaceGoodsColor_whiteBkg_xlua_st_(RealStatePtr L)
        {
            
            
            
            try {
                
                {
                    string name = LuaAPI.lua_tostring(L, 1);
                    
                        string __cl_gen_ret = xc.GoodsHelper.ReplaceGoodsColor_whiteBkg( name );
                        LuaAPI.lua_pushstring(L, __cl_gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_ReplaceGoodsColor_blackBkg_xlua_st_(RealStatePtr L)
        {
            
            
            
            try {
                
                {
                    string name = LuaAPI.lua_tostring(L, 1);
                    
                        string __cl_gen_ret = xc.GoodsHelper.ReplaceGoodsColor_blackBkg( name );
                        LuaAPI.lua_pushstring(L, __cl_gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_GetGoodsColor_whiteBkg_xlua_st_(RealStatePtr L)
        {
            
            
            
            try {
                
                {
                    uint quality = LuaAPI.xlua_touint(L, 1);
                    
                        string __cl_gen_ret = xc.GoodsHelper.GetGoodsColor_whiteBkg( quality );
                        LuaAPI.lua_pushstring(L, __cl_gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_GetGoodsColor_blackBkg_xlua_st_(RealStatePtr L)
        {
            
            
            
            try {
                
                {
                    uint quality = LuaAPI.xlua_touint(L, 1);
                    
                        string __cl_gen_ret = xc.GoodsHelper.GetGoodsColor_blackBkg( quality );
                        LuaAPI.lua_pushstring(L, __cl_gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_GetGoodsColorName_xlua_st_(RealStatePtr L)
        {
            
            
            
            try {
                
                {
                    uint quality = LuaAPI.xlua_touint(L, 1);
                    
                        string __cl_gen_ret = xc.GoodsHelper.GetGoodsColorName( quality );
                        LuaAPI.lua_pushstring(L, __cl_gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_GetTextColor_xlua_st_(RealStatePtr L)
        {
            
            
            
            try {
                
                {
                    uint quality = LuaAPI.xlua_touint(L, 1);
                    uint bk_type = LuaAPI.xlua_touint(L, 2);
                    
                        string __cl_gen_ret = xc.GoodsHelper.GetTextColor( quality, bk_type );
                        LuaAPI.lua_pushstring(L, __cl_gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_GetGoodsFromPkgInfo_xlua_st_(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            
            try {
                
                {
                    Net.PkgGoodsInfo info = (Net.PkgGoodsInfo)translator.GetObject(L, 1, typeof(Net.PkgGoodsInfo));
                    
                        xc.Goods __cl_gen_ret = xc.GoodsHelper.GetGoodsFromPkgInfo( info );
                        translator.Push(L, __cl_gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_CreateEquipFromNet_xlua_st_(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            
            try {
                
                {
                    Net.PkgGoodsInfo info = (Net.PkgGoodsInfo)translator.GetObject(L, 1, typeof(Net.PkgGoodsInfo));
                    
                        xc.Goods __cl_gen_ret = xc.GoodsHelper.CreateEquipFromNet( info );
                        translator.Push(L, __cl_gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_CreateEquipGoodsFromNet_xlua_st_(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            
            try {
                
                {
                    Net.PkgGoodsInfo info = (Net.PkgGoodsInfo)translator.GetObject(L, 1, typeof(Net.PkgGoodsInfo));
                    
                        xc.GoodsEquip __cl_gen_ret = xc.GoodsHelper.CreateEquipGoodsFromNet( info );
                        translator.Push(L, __cl_gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_CreateEquipGoodsByTypeId_xlua_st_(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            
            try {
                
                {
                    uint typeId = LuaAPI.xlua_touint(L, 1);
                    
                        xc.GoodsEquip __cl_gen_ret = xc.GoodsHelper.CreateEquipGoodsByTypeId( typeId );
                        translator.Push(L, __cl_gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_CreateGoodsFromNetByProtocol_xlua_st_(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            
            try {
                
                {
                    ushort protocol = (ushort)LuaAPI.xlua_tointeger(L, 1);
                    byte[] data = LuaAPI.lua_tobytes(L, 2);
                    
                        System.Collections.Generic.List<xc.Goods> __cl_gen_ret = xc.GoodsHelper.CreateGoodsFromNetByProtocol( protocol, data );
                        translator.Push(L, __cl_gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_GetSoulSortList_xlua_st_(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            
            try {
                
                {
                    uint hole = LuaAPI.xlua_touint(L, 1);
                    
                        System.Collections.Generic.List<xc.GoodsSoul> __cl_gen_ret = xc.GoodsHelper.GetSoulSortList( hole );
                        translator.Push(L, __cl_gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_GetSoulSortList_noCheckInstall_xlua_st_(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            
            try {
                
                {
                    
                        System.Collections.Generic.List<xc.GoodsSoul> __cl_gen_ret = xc.GoodsHelper.GetSoulSortList_noCheckInstall(  );
                        translator.Push(L, __cl_gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_GetSoulIsInstall_xlua_st_(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            
            try {
                
                {
                    xc.GoodsSoul soul = (xc.GoodsSoul)translator.GetObject(L, 1, typeof(xc.GoodsSoul));
                    
                        bool __cl_gen_ret = xc.GoodsHelper.GetSoulIsInstall( soul );
                        LuaAPI.lua_pushboolean(L, __cl_gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_SoulCanInstallHole_xlua_st_(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            
            try {
                
                {
                    uint hole = LuaAPI.xlua_touint(L, 1);
                    xc.GoodsSoul soul = (xc.GoodsSoul)translator.GetObject(L, 2, typeof(xc.GoodsSoul));
                    
                        uint __cl_gen_ret = xc.GoodsHelper.SoulCanInstallHole( hole, soul );
                        LuaAPI.xlua_pushuint(L, __cl_gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_SoulCanInstallHoleNew_xlua_st_(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            
            try {
                
                {
                    uint hole = LuaAPI.xlua_touint(L, 1);
                    xc.GoodsSoul soul = (xc.GoodsSoul)translator.GetObject(L, 2, typeof(xc.GoodsSoul));
                    
                        uint __cl_gen_ret = xc.GoodsHelper.SoulCanInstallHoleNew( hole, soul );
                        LuaAPI.xlua_pushuint(L, __cl_gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_CheckNeedRemoveInstallWhenInstall_xlua_st_(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            
            try {
                
                {
                    uint holeId = LuaAPI.xlua_touint(L, 1);
                    xc.GoodsSoul soul = (xc.GoodsSoul)translator.GetObject(L, 2, typeof(xc.GoodsSoul));
                    
                        System.Collections.Generic.List<xc.GoodsSoul> __cl_gen_ret = xc.GoodsHelper.CheckNeedRemoveInstallWhenInstall( holeId, soul );
                        translator.Push(L, __cl_gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_GetBodyGoodSoulByHoleId_xlua_st_(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            
            try {
                
                {
                    uint holeId = LuaAPI.xlua_touint(L, 1);
                    
                        xc.GoodsSoul __cl_gen_ret = xc.GoodsHelper.GetBodyGoodSoulByHoleId( holeId );
                        translator.Push(L, __cl_gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_CheckIsBodyOrBagHaveSoul_xlua_st_(RealStatePtr L)
        {
            
            
            
            try {
                
                {
                    uint gid = LuaAPI.xlua_touint(L, 1);
                    
                        uint __cl_gen_ret = xc.GoodsHelper.CheckIsBodyOrBagHaveSoul( gid );
                        LuaAPI.xlua_pushuint(L, __cl_gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_SoulBagIsHaveCanEquipByHoleId_xlua_st_(RealStatePtr L)
        {
            
            
            
            try {
                
                {
                    uint holeId = LuaAPI.xlua_touint(L, 1);
                    
                        bool __cl_gen_ret = xc.GoodsHelper.SoulBagIsHaveCanEquipByHoleId( holeId );
                        LuaAPI.lua_pushboolean(L, __cl_gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_AllSoulTypeIds_xlua_st_(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            
            try {
                
                {
                    
                        System.Collections.Generic.List<uint> __cl_gen_ret = xc.GoodsHelper.AllSoulTypeIds(  );
                        translator.Push(L, __cl_gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_GetSoulCostTotalVal_xlua_st_(RealStatePtr L)
        {
            
            
            
            try {
                
                {
                    uint gid = LuaAPI.xlua_touint(L, 1);
                    uint lv = LuaAPI.xlua_touint(L, 2);
                    
                        uint __cl_gen_ret = xc.GoodsHelper.GetSoulCostTotalVal( gid, lv );
                        LuaAPI.xlua_pushuint(L, __cl_gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_GetSoulBookTypeAllIds_xlua_st_(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            
            try {
                
                {
                    uint type = LuaAPI.xlua_touint(L, 1);
                    
                        System.Collections.Generic.List<uint> __cl_gen_ret = xc.GoodsHelper.GetSoulBookTypeAllIds( type );
                        translator.Push(L, __cl_gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_GetSoulBookAttrStr_xlua_st_(RealStatePtr L)
        {
            
            
            
            try {
                
                {
                    uint id = LuaAPI.xlua_touint(L, 1);
                    
                        string __cl_gen_ret = xc.GoodsHelper.GetSoulBookAttrStr( id );
                        LuaAPI.lua_pushstring(L, __cl_gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_GetTotalSoulBookAttr_xlua_st_(RealStatePtr L)
        {
            
            
            
            try {
                
                {
                    
                        string __cl_gen_ret = xc.GoodsHelper.GetTotalSoulBookAttr(  );
                        LuaAPI.lua_pushstring(L, __cl_gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_GetTotalSoulBookAttr_list_xlua_st_(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            
            try {
                
                {
                    
                        System.Collections.Generic.List<xc.Equip.EquipHelper.AttributeDescItem> __cl_gen_ret = xc.GoodsHelper.GetTotalSoulBookAttr_list(  );
                        translator.Push(L, __cl_gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_InstallSoulTotalAllAttrStr_xlua_st_(RealStatePtr L)
        {
            
            
            
            try {
                
                {
                    
                        string __cl_gen_ret = xc.GoodsHelper.InstallSoulTotalAllAttrStr(  );
                        LuaAPI.lua_pushstring(L, __cl_gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_InstallSoulTotalAllAttrStrArray_xlua_st_(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            
            try {
                
                {
                    
                        System.Collections.Generic.List<xc.Equip.EquipHelper.AttributeDescItem> __cl_gen_ret = xc.GoodsHelper.InstallSoulTotalAllAttrStrArray(  );
                        translator.Push(L, __cl_gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_GetBodyAndBagMaxLevelSoulItem_xlua_st_(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            
            try {
                
                {
                    uint type_idx = LuaAPI.xlua_touint(L, 1);
                    
                        xc.GoodsSoul __cl_gen_ret = xc.GoodsHelper.GetBodyAndBagMaxLevelSoulItem( type_idx );
                        translator.Push(L, __cl_gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_GetSoulAttrByLv_xlua_st_(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            
            try {
                
                {
                    uint gid = LuaAPI.xlua_touint(L, 1);
                    uint lv = LuaAPI.xlua_touint(L, 2);
                    
                        xc.ActorAttribute __cl_gen_ret = xc.GoodsHelper.GetSoulAttrByLv( gid, lv );
                        translator.Push(L, __cl_gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_GetSoulActiveNumByType_xlua_st_(RealStatePtr L)
        {
            
            
            
            try {
                
                {
                    uint type = LuaAPI.xlua_touint(L, 1);
                    
                        uint __cl_gen_ret = xc.GoodsHelper.GetSoulActiveNumByType( type );
                        LuaAPI.xlua_pushuint(L, __cl_gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_GetSoulOpenCondtionStr_xlua_st_(RealStatePtr L)
        {
            
            
            
            try {
                
                {
                    uint kungfuId = LuaAPI.xlua_touint(L, 1);
                    
                        string __cl_gen_ret = xc.GoodsHelper.GetSoulOpenCondtionStr( kungfuId );
                        LuaAPI.lua_pushstring(L, __cl_gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_IsSoulActive_xlua_st_(RealStatePtr L)
        {
            
            
            
            try {
                
                {
                    uint id = LuaAPI.xlua_touint(L, 1);
                    
                        bool __cl_gen_ret = xc.GoodsHelper.IsSoulActive( id );
                        LuaAPI.lua_pushboolean(L, __cl_gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_IsSoulHave_xlua_st_(RealStatePtr L)
        {
            
            
            
            try {
                
                {
                    uint gid = LuaAPI.xlua_touint(L, 1);
                    
                        bool __cl_gen_ret = xc.GoodsHelper.IsSoulHave( gid );
                        LuaAPI.lua_pushboolean(L, __cl_gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_GetSoulBookSoulList_xlua_st_(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            
            try {
                
                {
                    uint id = LuaAPI.xlua_touint(L, 1);
                    
                        System.Collections.Generic.List<xc.Goods> __cl_gen_ret = xc.GoodsHelper.GetSoulBookSoulList( id );
                        translator.Push(L, __cl_gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_GetQualityByGid_xlua_st_(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            
            try {
                
                {
                    uint gid = LuaAPI.xlua_touint(L, 1);
                    
                        xc.EGoodsQuality __cl_gen_ret = xc.GoodsHelper.GetQualityByGid( gid );
                        translator.Push(L, __cl_gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_GetBagUnLockTotal_xlua_st_(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            
            try {
                
                {
                    ushort bag_type = (ushort)LuaAPI.xlua_tointeger(L, 1);
                    int start_idx = LuaAPI.xlua_tointeger(L, 2);
                    int end_idx = LuaAPI.xlua_tointeger(L, 3);
                    
                        xc.Goods __cl_gen_ret = xc.GoodsHelper.GetBagUnLockTotal( bag_type, start_idx, end_idx );
                        translator.Push(L, __cl_gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_CheckUseGoodsIsInCD_xlua_st_(RealStatePtr L)
        {
            
            
            
            try {
                
                {
                    uint goodsId = LuaAPI.xlua_touint(L, 1);
                    
                        bool __cl_gen_ret = xc.GoodsHelper.CheckUseGoodsIsInCD( goodsId );
                        LuaAPI.lua_pushboolean(L, __cl_gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_CheckCanUseByVocation_xlua_st_(RealStatePtr L)
        {
            
            
            
            try {
                
                {
                    uint goods_use_job = LuaAPI.xlua_touint(L, 1);
                    uint player_vocation = LuaAPI.xlua_touint(L, 2);
                    
                        bool __cl_gen_ret = xc.GoodsHelper.CheckCanUseByVocation( goods_use_job, player_vocation );
                        LuaAPI.lua_pushboolean(L, __cl_gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_CheckGoodsCanUse_xlua_st_(RealStatePtr L)
        {
            
            
            
            try {
                
                {
                    uint goodsId = LuaAPI.xlua_touint(L, 1);
                    
                        bool __cl_gen_ret = xc.GoodsHelper.CheckGoodsCanUse( goodsId );
                        LuaAPI.lua_pushboolean(L, __cl_gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_GetGoodsCDId_xlua_st_(RealStatePtr L)
        {
            
            
            
            try {
                
                {
                    uint typeId = LuaAPI.xlua_touint(L, 1);
                    
                        uint __cl_gen_ret = xc.GoodsHelper.GetGoodsCDId( typeId );
                        LuaAPI.xlua_pushuint(L, __cl_gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_ParseClientGoodsStr_xlua_st_(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            
            try {
                
                {
                    string str = LuaAPI.lua_tostring(L, 1);
                    
                        xc.Goods __cl_gen_ret = xc.GoodsHelper.ParseClientGoodsStr( str );
                        translator.Push(L, __cl_gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_GetClientGoodsStr_xlua_st_(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            
            try {
                
                {
                    xc.Goods item = (xc.Goods)translator.GetObject(L, 1, typeof(xc.Goods));
                    
                        string __cl_gen_ret = xc.GoodsHelper.GetClientGoodsStr( item );
                        LuaAPI.lua_pushstring(L, __cl_gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_ShowGoodsTips_xlua_st_(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            
			int __gen_param_count = LuaAPI.lua_gettop(L);
            
            try {
                if(__gen_param_count == 4&& translator.Assignable<xc.Goods>(L, 1)&& translator.Assignable<Net.PkgStrengthInfo>(L, 2)&& translator.Assignable<Net.PkgBaptizeInfo>(L, 3)&& (LuaAPI.lua_isnil(L, 4) || LuaAPI.lua_type(L, 4) == LuaTypes.LUA_TSTRING)) 
                {
                    xc.Goods item = (xc.Goods)translator.GetObject(L, 1, typeof(xc.Goods));
                    Net.PkgStrengthInfo pkgStrengthInfo = (Net.PkgStrengthInfo)translator.GetObject(L, 2, typeof(Net.PkgStrengthInfo));
                    Net.PkgBaptizeInfo pkgBaptizeInfo = (Net.PkgBaptizeInfo)translator.GetObject(L, 3, typeof(Net.PkgBaptizeInfo));
                    string showType = LuaAPI.lua_tostring(L, 4);
                    
                    xc.GoodsHelper.ShowGoodsTips( item, pkgStrengthInfo, pkgBaptizeInfo, showType );
                    
                    
                    
                    return 0;
                }
                if(__gen_param_count == 3&& translator.Assignable<xc.Goods>(L, 1)&& translator.Assignable<Net.PkgStrengthInfo>(L, 2)&& translator.Assignable<Net.PkgBaptizeInfo>(L, 3)) 
                {
                    xc.Goods item = (xc.Goods)translator.GetObject(L, 1, typeof(xc.Goods));
                    Net.PkgStrengthInfo pkgStrengthInfo = (Net.PkgStrengthInfo)translator.GetObject(L, 2, typeof(Net.PkgStrengthInfo));
                    Net.PkgBaptizeInfo pkgBaptizeInfo = (Net.PkgBaptizeInfo)translator.GetObject(L, 3, typeof(Net.PkgBaptizeInfo));
                    
                    xc.GoodsHelper.ShowGoodsTips( item, pkgStrengthInfo, pkgBaptizeInfo );
                    
                    
                    
                    return 0;
                }
                if(__gen_param_count == 2&& translator.Assignable<xc.Goods>(L, 1)&& translator.Assignable<Net.PkgStrengthInfo>(L, 2)) 
                {
                    xc.Goods item = (xc.Goods)translator.GetObject(L, 1, typeof(xc.Goods));
                    Net.PkgStrengthInfo pkgStrengthInfo = (Net.PkgStrengthInfo)translator.GetObject(L, 2, typeof(Net.PkgStrengthInfo));
                    
                    xc.GoodsHelper.ShowGoodsTips( item, pkgStrengthInfo );
                    
                    
                    
                    return 0;
                }
                if(__gen_param_count == 1&& translator.Assignable<xc.Goods>(L, 1)) 
                {
                    xc.Goods item = (xc.Goods)translator.GetObject(L, 1, typeof(xc.Goods));
                    
                    xc.GoodsHelper.ShowGoodsTips( item );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
            return LuaAPI.luaL_error(L, "invalid arguments to xc.GoodsHelper.ShowGoodsTips!");
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_GetLegendTopScoreByGroupId_xlua_st_(RealStatePtr L)
        {
            
            
            
            try {
                
                {
                    uint group_id = LuaAPI.xlua_touint(L, 1);
                    uint line_num = LuaAPI.xlua_touint(L, 2);
                    
                        uint __cl_gen_ret = xc.GoodsHelper.GetLegendTopScoreByGroupId( group_id, line_num );
                        LuaAPI.xlua_pushuint(L, __cl_gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_GetGoodsShowAttr_xlua_st_(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            
            try {
                
                {
                    uint gid = LuaAPI.xlua_touint(L, 1);
                    
                        xc.ActorAttribute __cl_gen_ret = xc.GoodsHelper.GetGoodsShowAttr( gid );
                        translator.Push(L, __cl_gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_GetGoodsShowBattlePower_xlua_st_(RealStatePtr L)
        {
            
            
            
            try {
                
                {
                    uint gid = LuaAPI.xlua_touint(L, 1);
                    
                        ulong __cl_gen_ret = xc.GoodsHelper.GetGoodsShowBattlePower( gid );
                        LuaAPI.lua_pushuint64(L, __cl_gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_GetGoodsCanShortcutUseByBagType_xlua_st_(RealStatePtr L)
        {
            
            
            
            try {
                
                {
                    uint bagType = LuaAPI.xlua_touint(L, 1);
                    
                        bool __cl_gen_ret = xc.GoodsHelper.GetGoodsCanShortcutUseByBagType( bagType );
                        LuaAPI.lua_pushboolean(L, __cl_gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_GetGoodsHaveGetTipsByBagType_xlua_st_(RealStatePtr L)
        {
            
            
            
            try {
                
                {
                    uint bagType = LuaAPI.xlua_touint(L, 1);
                    
                        bool __cl_gen_ret = xc.GoodsHelper.GetGoodsHaveGetTipsByBagType( bagType );
                        LuaAPI.lua_pushboolean(L, __cl_gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_GetGoodsLuaScriptByGoodsId_xlua_st_(RealStatePtr L)
        {
            
            
            
            try {
                
                {
                    uint goodsId = LuaAPI.xlua_touint(L, 1);
                    
                        string __cl_gen_ret = xc.GoodsHelper.GetGoodsLuaScriptByGoodsId( goodsId );
                        LuaAPI.lua_pushstring(L, __cl_gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_GetGoodsTipsWindowByGoodsId_xlua_st_(RealStatePtr L)
        {
            
            
            
            try {
                
                {
                    uint goodsId = LuaAPI.xlua_touint(L, 1);
                    
                        string __cl_gen_ret = xc.GoodsHelper.GetGoodsTipsWindowByGoodsId( goodsId );
                        LuaAPI.lua_pushstring(L, __cl_gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_GetGoodsBagTypeByGoodsId_xlua_st_(RealStatePtr L)
        {
            
            
            
            try {
                
                {
                    uint goodsId = LuaAPI.xlua_touint(L, 1);
                    
                        uint __cl_gen_ret = xc.GoodsHelper.GetGoodsBagTypeByGoodsId( goodsId );
                        LuaAPI.xlua_pushuint(L, __cl_gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        
        
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_GoodsPrefab(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			    translator.Push(L, xc.GoodsHelper.GoodsPrefab);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_GoodsPrefab(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			    xc.GoodsHelper.GoodsPrefab = (UnityEngine.GameObject)translator.GetObject(L, 1, typeof(UnityEngine.GameObject));
            
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 0;
        }
        
		
		
		
		
    }
}
