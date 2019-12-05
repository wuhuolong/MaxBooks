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
    public class xcEquipEquipHelperWrap
    {
        public static void __Register(RealStatePtr L)
        {
			ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			XUtils.BeginObjectRegister(typeof(xc.Equip.EquipHelper), L, translator, 0, 0, 0, 0);
			
			
			
			
			
			XUtils.EndObjectRegister(typeof(xc.Equip.EquipHelper), L, translator, null, null,
			    null, null, null);

		    XUtils.BeginClassRegister(typeof(xc.Equip.EquipHelper), L, __CreateInstance, 106, 0, 0);
			XUtils.RegisterFunc(L, XUtils.CLS_IDX, "GetEquipModData", _m_GetEquipModData_xlua_st_);
            XUtils.RegisterFunc(L, XUtils.CLS_IDX, "GetEquipAttrData", _m_GetEquipAttrData_xlua_st_);
            XUtils.RegisterFunc(L, XUtils.CLS_IDX, "GetEquipPosStr", _m_GetEquipPosStr_xlua_st_);
            XUtils.RegisterFunc(L, XUtils.CLS_IDX, "GetEquipPosEngraveAtrrsDesc", _m_GetEquipPosEngraveAtrrsDesc_xlua_st_);
            XUtils.RegisterFunc(L, XUtils.CLS_IDX, "GetEquipPosEngraveShowAttrs", _m_GetEquipPosEngraveShowAttrs_xlua_st_);
            XUtils.RegisterFunc(L, XUtils.CLS_IDX, "GetEquipNameByGid", _m_GetEquipNameByGid_xlua_st_);
            XUtils.RegisterFunc(L, XUtils.CLS_IDX, "GetInstallEquipIndex", _m_GetInstallEquipIndex_xlua_st_);
            XUtils.RegisterFunc(L, XUtils.CLS_IDX, "GetSuitInfos", _m_GetSuitInfos_xlua_st_);
            XUtils.RegisterFunc(L, XUtils.CLS_IDX, "GetGemInfos", _m_GetGemInfos_xlua_st_);
            XUtils.RegisterFunc(L, XUtils.CLS_IDX, "GetEngraveEquipPosInfoList", _m_GetEngraveEquipPosInfoList_xlua_st_);
            XUtils.RegisterFunc(L, XUtils.CLS_IDX, "GetEngraveEquipPosInfo", _m_GetEngraveEquipPosInfo_xlua_st_);
            XUtils.RegisterFunc(L, XUtils.CLS_IDX, "SortBaptizePosInfos", _m_SortBaptizePosInfos_xlua_st_);
            XUtils.RegisterFunc(L, XUtils.CLS_IDX, "GetBaptizeInfos", _m_GetBaptizeInfos_xlua_st_);
            XUtils.RegisterFunc(L, XUtils.CLS_IDX, "GetStrengthInfos", _m_GetStrengthInfos_xlua_st_);
            XUtils.RegisterFunc(L, XUtils.CLS_IDX, "SortPosInfos", _m_SortPosInfos_xlua_st_);
            XUtils.RegisterFunc(L, XUtils.CLS_IDX, "SortPosInfosForStrength", _m_SortPosInfosForStrength_xlua_st_);
            XUtils.RegisterFunc(L, XUtils.CLS_IDX, "GetEquipDBInfoBindState", _m_GetEquipDBInfoBindState_xlua_st_);
            XUtils.RegisterFunc(L, XUtils.CLS_IDX, "GetEquipLevelByGid", _m_GetEquipLevelByGid_xlua_st_);
            XUtils.RegisterFunc(L, XUtils.CLS_IDX, "GetEquipPosByGid", _m_GetEquipPosByGid_xlua_st_);
            XUtils.RegisterFunc(L, XUtils.CLS_IDX, "GetEquipGidByName", _m_GetEquipGidByName_xlua_st_);
            XUtils.RegisterFunc(L, XUtils.CLS_IDX, "GetGoodsGidByMurkyName", _m_GetGoodsGidByMurkyName_xlua_st_);
            XUtils.RegisterFunc(L, XUtils.CLS_IDX, "ChangeEquipPart", _m_ChangeEquipPart_xlua_st_);
            XUtils.RegisterFunc(L, XUtils.CLS_IDX, "GetEquipBaseAttrOri", _m_GetEquipBaseAttrOri_xlua_st_);
            XUtils.RegisterFunc(L, XUtils.CLS_IDX, "IsPlayerAllocationCanInstall", _m_IsPlayerAllocationCanInstall_xlua_st_);
            XUtils.RegisterFunc(L, XUtils.CLS_IDX, "ShowInstallEquipAllocation", _m_ShowInstallEquipAllocation_xlua_st_);
            XUtils.RegisterFunc(L, XUtils.CLS_IDX, "EquipIsInstall", _m_EquipIsInstall_xlua_st_);
            XUtils.RegisterFunc(L, XUtils.CLS_IDX, "EquipIsInstallByPos", _m_EquipIsInstallByPos_xlua_st_);
            XUtils.RegisterFunc(L, XUtils.CLS_IDX, "GetStarAddEquip", _m_GetStarAddEquip_xlua_st_);
            XUtils.RegisterFunc(L, XUtils.CLS_IDX, "GetInstallEquipByPos", _m_GetInstallEquipByPos_xlua_st_);
            XUtils.RegisterFunc(L, XUtils.CLS_IDX, "GetInstallEquipListByPos", _m_GetInstallEquipListByPos_xlua_st_);
            XUtils.RegisterFunc(L, XUtils.CLS_IDX, "CheckEquipCanInstall", _m_CheckEquipCanInstall_xlua_st_);
            XUtils.RegisterFunc(L, XUtils.CLS_IDX, "GetEquipRecycleRewardGoods", _m_GetEquipRecycleRewardGoods_xlua_st_);
            XUtils.RegisterFunc(L, XUtils.CLS_IDX, "GetEquipCustomBaseDes", _m_GetEquipCustomBaseDes_xlua_st_);
            XUtils.RegisterFunc(L, XUtils.CLS_IDX, "GetEquipBaseDes", _m_GetEquipBaseDes_xlua_st_);
            XUtils.RegisterFunc(L, XUtils.CLS_IDX, "GetEquipBaseDesItemArray", _m_GetEquipBaseDesItemArray_xlua_st_);
            XUtils.RegisterFunc(L, XUtils.CLS_IDX, "GetBagEquipsOidsByColorAndLvStep", _m_GetBagEquipsOidsByColorAndLvStep_xlua_st_);
            XUtils.RegisterFunc(L, XUtils.CLS_IDX, "GetBagEquipsByIdsAndStar", _m_GetBagEquipsByIdsAndStar_xlua_st_);
            XUtils.RegisterFunc(L, XUtils.CLS_IDX, "GetComposeMoney", _m_GetComposeMoney_xlua_st_);
            XUtils.RegisterFunc(L, XUtils.CLS_IDX, "GetComposeStuffs", _m_GetComposeStuffs_xlua_st_);
            XUtils.RegisterFunc(L, XUtils.CLS_IDX, "GetGemNextGems", _m_GetGemNextGems_xlua_st_);
            XUtils.RegisterFunc(L, XUtils.CLS_IDX, "GetGemTypeNameByHole", _m_GetGemTypeNameByHole_xlua_st_);
            XUtils.RegisterFunc(L, XUtils.CLS_IDX, "GetBagGemSordList", _m_GetBagGemSordList_xlua_st_);
            XUtils.RegisterFunc(L, XUtils.CLS_IDX, "isCanComposeGem", _m_isCanComposeGem_xlua_st_);
            XUtils.RegisterFunc(L, XUtils.CLS_IDX, "IsCanComposeEngrave", _m_IsCanComposeEngrave_xlua_st_);
            XUtils.RegisterFunc(L, XUtils.CLS_IDX, "GetGemTypeByGemGid", _m_GetGemTypeByGemGid_xlua_st_);
            XUtils.RegisterFunc(L, XUtils.CLS_IDX, "GetGemLevelByGemGid", _m_GetGemLevelByGemGid_xlua_st_);
            XUtils.RegisterFunc(L, XUtils.CLS_IDX, "GetGemTypeHole", _m_GetGemTypeHole_xlua_st_);
            XUtils.RegisterFunc(L, XUtils.CLS_IDX, "GetGemMinLvByGemType", _m_GetGemMinLvByGemType_xlua_st_);
            XUtils.RegisterFunc(L, XUtils.CLS_IDX, "GetBagGemByHole", _m_GetBagGemByHole_xlua_st_);
            XUtils.RegisterFunc(L, XUtils.CLS_IDX, "GetBagIsCanGemInstall", _m_GetBagIsCanGemInstall_xlua_st_);
            XUtils.RegisterFunc(L, XUtils.CLS_IDX, "GetBagIsCanHigherGemInstall", _m_GetBagIsCanHigherGemInstall_xlua_st_);
            XUtils.RegisterFunc(L, XUtils.CLS_IDX, "GetGemHoleInstallCondtion", _m_GetGemHoleInstallCondtion_xlua_st_);
            XUtils.RegisterFunc(L, XUtils.CLS_IDX, "GetAllEquipGemAttr", _m_GetAllEquipGemAttr_xlua_st_);
            XUtils.RegisterFunc(L, XUtils.CLS_IDX, "GetGemAttr", _m_GetGemAttr_xlua_st_);
            XUtils.RegisterFunc(L, XUtils.CLS_IDX, "GetEngraveAttrs", _m_GetEngraveAttrs_xlua_st_);
            XUtils.RegisterFunc(L, XUtils.CLS_IDX, "GetGemTotalLv", _m_GetGemTotalLv_xlua_st_);
            XUtils.RegisterFunc(L, XUtils.CLS_IDX, "GetGemAttrByTotalLv", _m_GetGemAttrByTotalLv_xlua_st_);
            XUtils.RegisterFunc(L, XUtils.CLS_IDX, "GetEngraveAttrByTotalLv", _m_GetEngraveAttrByTotalLv_xlua_st_);
            XUtils.RegisterFunc(L, XUtils.CLS_IDX, "GetGemDataTotalLv", _m_GetGemDataTotalLv_xlua_st_);
            XUtils.RegisterFunc(L, XUtils.CLS_IDX, "CheckEquipCanSuit", _m_CheckEquipCanSuit_xlua_st_);
            XUtils.RegisterFunc(L, XUtils.CLS_IDX, "GetMaxNum", _m_GetMaxNum_xlua_st_);
            XUtils.RegisterFunc(L, XUtils.CLS_IDX, "GetEquipTipsUpgradeRank", _m_GetEquipTipsUpgradeRank_xlua_st_);
            XUtils.RegisterFunc(L, XUtils.CLS_IDX, "GetOtherPlayerEquipTipsUpgradeRank", _m_GetOtherPlayerEquipTipsUpgradeRank_xlua_st_);
            XUtils.RegisterFunc(L, XUtils.CLS_IDX, "GetSuitRank", _m_GetSuitRank_xlua_st_);
            XUtils.RegisterFunc(L, XUtils.CLS_IDX, "GetSuitRefineRank", _m_GetSuitRefineRank_xlua_st_);
            XUtils.RegisterFunc(L, XUtils.CLS_IDX, "CalculatorInstallSuitNum", _m_CalculatorInstallSuitNum_xlua_st_);
            XUtils.RegisterFunc(L, XUtils.CLS_IDX, "CalculatorSuitNum", _m_CalculatorSuitNum_xlua_st_);
            XUtils.RegisterFunc(L, XUtils.CLS_IDX, "GetActiveSuitNum", _m_GetActiveSuitNum_xlua_st_);
            XUtils.RegisterFunc(L, XUtils.CLS_IDX, "GetInstallEquipSuitNum", _m_GetInstallEquipSuitNum_xlua_st_);
            XUtils.RegisterFunc(L, XUtils.CLS_IDX, "EnableEquipBaptizeRedPoint", _m_EnableEquipBaptizeRedPoint_xlua_st_);
            XUtils.RegisterFunc(L, XUtils.CLS_IDX, "GetEquipBaptizeRank", _m_GetEquipBaptizeRank_xlua_st_);
            XUtils.RegisterFunc(L, XUtils.CLS_IDX, "GetEquipBaptizeRankType", _m_GetEquipBaptizeRankType_xlua_st_);
            XUtils.RegisterFunc(L, XUtils.CLS_IDX, "GetLockCountByPos", _m_GetLockCountByPos_xlua_st_);
            XUtils.RegisterFunc(L, XUtils.CLS_IDX, "GetOpenCountByPos", _m_GetOpenCountByPos_xlua_st_);
            XUtils.RegisterFunc(L, XUtils.CLS_IDX, "GetCurrentEquipBaptizeAttrDes", _m_GetCurrentEquipBaptizeAttrDes_xlua_st_);
            XUtils.RegisterFunc(L, XUtils.CLS_IDX, "GetUnLockCountByPos", _m_GetUnLockCountByPos_xlua_st_);
            XUtils.RegisterFunc(L, XUtils.CLS_IDX, "GetBaptizeLockCostGoods", _m_GetBaptizeLockCostGoods_xlua_st_);
            XUtils.RegisterFunc(L, XUtils.CLS_IDX, "GetBaptizeLockCostDiamond", _m_GetBaptizeLockCostDiamond_xlua_st_);
            XUtils.RegisterFunc(L, XUtils.CLS_IDX, "GetBaptizeAddBaseAttrDisplay", _m_GetBaptizeAddBaseAttrDisplay_xlua_st_);
            XUtils.RegisterFunc(L, XUtils.CLS_IDX, "GetBaptizeMinValue", _m_GetBaptizeMinValue_xlua_st_);
            XUtils.RegisterFunc(L, XUtils.CLS_IDX, "GetBaptizeMaxValue", _m_GetBaptizeMaxValue_xlua_st_);
            XUtils.RegisterFunc(L, XUtils.CLS_IDX, "GetBaptizeColor", _m_GetBaptizeColor_xlua_st_);
            XUtils.RegisterFunc(L, XUtils.CLS_IDX, "CheckEquipCanStrength", _m_CheckEquipCanStrength_xlua_st_);
            XUtils.RegisterFunc(L, XUtils.CLS_IDX, "CheckAllInstallEquipsCanStrength", _m_CheckAllInstallEquipsCanStrength_xlua_st_);
            XUtils.RegisterFunc(L, XUtils.CLS_IDX, "GetStrengthDataLv", _m_GetStrengthDataLv_xlua_st_);
            XUtils.RegisterFunc(L, XUtils.CLS_IDX, "GetInstallStrength", _m_GetInstallStrength_xlua_st_);
            XUtils.RegisterFunc(L, XUtils.CLS_IDX, "GetAllStrengthExAttribute", _m_GetAllStrengthExAttribute_xlua_st_);
            XUtils.RegisterFunc(L, XUtils.CLS_IDX, "GetStrengthStuff", _m_GetStrengthStuff_xlua_st_);
            XUtils.RegisterFunc(L, XUtils.CLS_IDX, "GetStrengthShowRedPointGoods", _m_GetStrengthShowRedPointGoods_xlua_st_);
            XUtils.RegisterFunc(L, XUtils.CLS_IDX, "GetStrengGoodsEquip", _m_GetStrengGoodsEquip_xlua_st_);
            XUtils.RegisterFunc(L, XUtils.CLS_IDX, "GetPosInfoByPos_suitIgnoreIndex", _m_GetPosInfoByPos_suitIgnoreIndex_xlua_st_);
            XUtils.RegisterFunc(L, XUtils.CLS_IDX, "GetEquipStrengthRank", _m_GetEquipStrengthRank_xlua_st_);
            XUtils.RegisterFunc(L, XUtils.CLS_IDX, "GetEquipBaseAttrScoreByType", _m_GetEquipBaseAttrScoreByType_xlua_st_);
            XUtils.RegisterFunc(L, XUtils.CLS_IDX, "GetEquipStrengthAttr", _m_GetEquipStrengthAttr_xlua_st_);
            XUtils.RegisterFunc(L, XUtils.CLS_IDX, "GetStrengthInfoByPosAndIndex", _m_GetStrengthInfoByPosAndIndex_xlua_st_);
            XUtils.RegisterFunc(L, XUtils.CLS_IDX, "GetEquipPosInfosByPkgInfos", _m_GetEquipPosInfosByPkgInfos_xlua_st_);
            XUtils.RegisterFunc(L, XUtils.CLS_IDX, "GetEquipPosInfoByPkgInfo", _m_GetEquipPosInfoByPkgInfo_xlua_st_);
            XUtils.RegisterFunc(L, XUtils.CLS_IDX, "GetSubAttrDes", _m_GetSubAttrDes_xlua_st_);
            XUtils.RegisterFunc(L, XUtils.CLS_IDX, "GetEquipLegendAttrStr", _m_GetEquipLegendAttrStr_xlua_st_);
            XUtils.RegisterFunc(L, XUtils.CLS_IDX, "GetLegendAttrDesStrArray", _m_GetLegendAttrDesStrArray_xlua_st_);
            XUtils.RegisterFunc(L, XUtils.CLS_IDX, "GetEquipStarAttr", _m_GetEquipStarAttr_xlua_st_);
            XUtils.RegisterFunc(L, XUtils.CLS_IDX, "GetEquipLvStepName", _m_GetEquipLvStepName_xlua_st_);
            XUtils.RegisterFunc(L, XUtils.CLS_IDX, "GetAttrbutesByDBStr", _m_GetAttrbutesByDBStr_xlua_st_);
            XUtils.RegisterFunc(L, XUtils.CLS_IDX, "DelEquipPart", _m_DelEquipPart_xlua_st_);
            XUtils.RegisterFunc(L, XUtils.CLS_IDX, "GetShowsAfterDelEquipPart", _m_GetShowsAfterDelEquipPart_xlua_st_);
            
			
            
            XUtils.RegisterObject(L, translator, XUtils.CLS_IDX, "UnderlyingSystemType", typeof(xc.Equip.EquipHelper));
			
			
			XUtils.EndClassRegister(typeof(xc.Equip.EquipHelper), L, translator);
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int __CreateInstance(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			try {
				if(LuaAPI.lua_gettop(L) == 1)
				{
					
					xc.Equip.EquipHelper __cl_gen_ret = new xc.Equip.EquipHelper();
					translator.Push(L, __cl_gen_ret);
					return 1;
				}
				
			}
			catch(System.Exception __gen_e) {
				return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
			}
            return LuaAPI.luaL_error(L, "invalid arguments to xc.Equip.EquipHelper constructor!");
            
        }
        
		
        
		
        
        
        
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_GetEquipModData_xlua_st_(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            
            try {
                
                {
                    uint equip_id = LuaAPI.xlua_touint(L, 1);
                    
                        xc.EquipModData __cl_gen_ret = xc.Equip.EquipHelper.GetEquipModData( equip_id );
                        translator.Push(L, __cl_gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_GetEquipAttrData_xlua_st_(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            
            try {
                
                {
                    uint attr_id = LuaAPI.xlua_touint(L, 1);
                    
                        xc.EquipAttrData __cl_gen_ret = xc.Equip.EquipHelper.GetEquipAttrData( attr_id );
                        translator.Push(L, __cl_gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_GetEquipPosStr_xlua_st_(RealStatePtr L)
        {
            
            
            
            try {
                
                {
                    uint pos = LuaAPI.xlua_touint(L, 1);
                    
                        string __cl_gen_ret = xc.Equip.EquipHelper.GetEquipPosStr( pos );
                        LuaAPI.lua_pushstring(L, __cl_gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_GetEquipPosEngraveAtrrsDesc_xlua_st_(RealStatePtr L)
        {
            
            
            
            try {
                
                {
                    uint pos = LuaAPI.xlua_touint(L, 1);
                    
                        string __cl_gen_ret = xc.Equip.EquipHelper.GetEquipPosEngraveAtrrsDesc( pos );
                        LuaAPI.lua_pushstring(L, __cl_gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_GetEquipPosEngraveShowAttrs_xlua_st_(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            
            try {
                
                {
                    uint pos = LuaAPI.xlua_touint(L, 1);
                    
                        xc.ActorAttribute __cl_gen_ret = xc.Equip.EquipHelper.GetEquipPosEngraveShowAttrs( pos );
                        translator.Push(L, __cl_gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_GetEquipNameByGid_xlua_st_(RealStatePtr L)
        {
            
            
            
            try {
                
                {
                    uint gid = LuaAPI.xlua_touint(L, 1);
                    
                        string __cl_gen_ret = xc.Equip.EquipHelper.GetEquipNameByGid( gid );
                        LuaAPI.lua_pushstring(L, __cl_gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_GetInstallEquipIndex_xlua_st_(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            
            try {
                
                {
                    xc.GoodsEquip equip = (xc.GoodsEquip)translator.GetObject(L, 1, typeof(xc.GoodsEquip));
                    
                        uint __cl_gen_ret = xc.Equip.EquipHelper.GetInstallEquipIndex( equip );
                        LuaAPI.xlua_pushuint(L, __cl_gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_GetSuitInfos_xlua_st_(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            
			int __gen_param_count = LuaAPI.lua_gettop(L);
            
            try {
                if(__gen_param_count == 1&& LuaTypes.LUA_TNUMBER == LuaAPI.lua_type(L, 1)) 
                {
                    uint suitLv = LuaAPI.xlua_touint(L, 1);
                    
                        System.Collections.Generic.List<xc.EquipPosInfo> __cl_gen_ret = xc.Equip.EquipHelper.GetSuitInfos( suitLv );
                        translator.Push(L, __cl_gen_ret);
                    
                    
                    
                    return 1;
                }
                if(__gen_param_count == 0) 
                {
                    
                        System.Collections.Generic.List<xc.EquipPosInfo> __cl_gen_ret = xc.Equip.EquipHelper.GetSuitInfos(  );
                        translator.Push(L, __cl_gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
            return LuaAPI.luaL_error(L, "invalid arguments to xc.Equip.EquipHelper.GetSuitInfos!");
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_GetGemInfos_xlua_st_(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            
            try {
                
                {
                    
                        System.Collections.Generic.List<xc.EquipPosInfo> __cl_gen_ret = xc.Equip.EquipHelper.GetGemInfos(  );
                        translator.Push(L, __cl_gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_GetEngraveEquipPosInfoList_xlua_st_(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            
            try {
                
                {
                    
                        System.Collections.Generic.List<xc.EquipPosInfo> __cl_gen_ret = xc.Equip.EquipHelper.GetEngraveEquipPosInfoList(  );
                        translator.Push(L, __cl_gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_GetEngraveEquipPosInfo_xlua_st_(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            
            try {
                
                {
                    uint equipPos = LuaAPI.xlua_touint(L, 1);
                    
                        xc.EquipPosInfo __cl_gen_ret = xc.Equip.EquipHelper.GetEngraveEquipPosInfo( equipPos );
                        translator.Push(L, __cl_gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_SortBaptizePosInfos_xlua_st_(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            
            try {
                
                {
                    System.Collections.Generic.List<xc.EquipPosInfo> list = (System.Collections.Generic.List<xc.EquipPosInfo>)translator.GetObject(L, 1, typeof(System.Collections.Generic.List<xc.EquipPosInfo>));
                    
                    xc.Equip.EquipHelper.SortBaptizePosInfos( list );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_GetBaptizeInfos_xlua_st_(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            
            try {
                
                {
                    
                        System.Collections.Generic.List<xc.EquipPosInfo> __cl_gen_ret = xc.Equip.EquipHelper.GetBaptizeInfos(  );
                        translator.Push(L, __cl_gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_GetStrengthInfos_xlua_st_(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            
            try {
                
                {
                    
                        System.Collections.Generic.List<xc.EquipPosInfo> __cl_gen_ret = xc.Equip.EquipHelper.GetStrengthInfos(  );
                        translator.Push(L, __cl_gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_SortPosInfos_xlua_st_(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            
            try {
                
                {
                    System.Collections.Generic.List<xc.EquipPosInfo> list = (System.Collections.Generic.List<xc.EquipPosInfo>)translator.GetObject(L, 1, typeof(System.Collections.Generic.List<xc.EquipPosInfo>));
                    
                    xc.Equip.EquipHelper.SortPosInfos( list );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_SortPosInfosForStrength_xlua_st_(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            
            try {
                
                {
                    System.Collections.Generic.List<xc.EquipPosInfo> list = (System.Collections.Generic.List<xc.EquipPosInfo>)translator.GetObject(L, 1, typeof(System.Collections.Generic.List<xc.EquipPosInfo>));
                    
                    xc.Equip.EquipHelper.SortPosInfosForStrength( list );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_GetEquipDBInfoBindState_xlua_st_(RealStatePtr L)
        {
            
            
            
            try {
                
                {
                    uint gid = LuaAPI.xlua_touint(L, 1);
                    
                        uint __cl_gen_ret = xc.Equip.EquipHelper.GetEquipDBInfoBindState( gid );
                        LuaAPI.xlua_pushuint(L, __cl_gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_GetEquipLevelByGid_xlua_st_(RealStatePtr L)
        {
            
            
            
            try {
                
                {
                    uint gid = LuaAPI.xlua_touint(L, 1);
                    
                        uint __cl_gen_ret = xc.Equip.EquipHelper.GetEquipLevelByGid( gid );
                        LuaAPI.xlua_pushuint(L, __cl_gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_GetEquipPosByGid_xlua_st_(RealStatePtr L)
        {
            
            
            
            try {
                
                {
                    uint gid = LuaAPI.xlua_touint(L, 1);
                    
                        uint __cl_gen_ret = xc.Equip.EquipHelper.GetEquipPosByGid( gid );
                        LuaAPI.xlua_pushuint(L, __cl_gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_GetEquipGidByName_xlua_st_(RealStatePtr L)
        {
            
            
            
            try {
                
                {
                    string name = LuaAPI.lua_tostring(L, 1);
                    
                        uint __cl_gen_ret = xc.Equip.EquipHelper.GetEquipGidByName( name );
                        LuaAPI.xlua_pushuint(L, __cl_gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_GetGoodsGidByMurkyName_xlua_st_(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            
            try {
                
                {
                    string name = LuaAPI.lua_tostring(L, 1);
                    
                        System.Collections.Generic.List<uint> __cl_gen_ret = xc.Equip.EquipHelper.GetGoodsGidByMurkyName( name );
                        translator.Push(L, __cl_gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_ChangeEquipPart_xlua_st_(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            
            try {
                
                {
                    xc.UnitID id = (xc.UnitID)translator.GetObject(L, 1, typeof(xc.UnitID));
                    uint modelId = LuaAPI.xlua_touint(L, 2);
                    uint equipPos = LuaAPI.xlua_touint(L, 3);
                    
                        uint __cl_gen_ret = xc.Equip.EquipHelper.ChangeEquipPart( id, modelId, equipPos );
                        LuaAPI.xlua_pushuint(L, __cl_gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_GetEquipBaseAttrOri_xlua_st_(RealStatePtr L)
        {
            
            
            
            try {
                
                {
                    uint baseId = LuaAPI.xlua_touint(L, 1);
                    
                        string __cl_gen_ret = xc.Equip.EquipHelper.GetEquipBaseAttrOri( baseId );
                        LuaAPI.lua_pushstring(L, __cl_gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_IsPlayerAllocationCanInstall_xlua_st_(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            
            try {
                
                {
                    xc.GoodsEquip equip = (xc.GoodsEquip)translator.GetObject(L, 1, typeof(xc.GoodsEquip));
                    
                        bool __cl_gen_ret = xc.Equip.EquipHelper.IsPlayerAllocationCanInstall( equip );
                        LuaAPI.lua_pushboolean(L, __cl_gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_ShowInstallEquipAllocation_xlua_st_(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            
            try {
                
                {
                    xc.GoodsEquip equip = (xc.GoodsEquip)translator.GetObject(L, 1, typeof(xc.GoodsEquip));
                    uint index = LuaAPI.xlua_touint(L, 2);
                    
                        bool __cl_gen_ret = xc.Equip.EquipHelper.ShowInstallEquipAllocation( equip, index );
                        LuaAPI.lua_pushboolean(L, __cl_gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_EquipIsInstall_xlua_st_(RealStatePtr L)
        {
            
            
            
            try {
                
                {
                    ulong oid = LuaAPI.lua_touint64(L, 1);
                    
                        bool __cl_gen_ret = xc.Equip.EquipHelper.EquipIsInstall( oid );
                        LuaAPI.lua_pushboolean(L, __cl_gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_EquipIsInstallByPos_xlua_st_(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            
            try {
                
                {
                    uint pos = LuaAPI.xlua_touint(L, 1);
                    uint index = LuaAPI.xlua_touint(L, 2);
                    
                        xc.GoodsEquip __cl_gen_ret = xc.Equip.EquipHelper.EquipIsInstallByPos( pos, index );
                        translator.Push(L, __cl_gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_GetStarAddEquip_xlua_st_(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            
			int __gen_param_count = LuaAPI.lua_gettop(L);
            
            try {
                if(__gen_param_count == 1&& (LuaTypes.LUA_TNUMBER == LuaAPI.lua_type(L, 1) || LuaAPI.lua_isuint64(L, 1))) 
                {
                    ulong oid = LuaAPI.lua_touint64(L, 1);
                    
                        int __cl_gen_ret = xc.Equip.EquipHelper.GetStarAddEquip( oid );
                        LuaAPI.xlua_pushinteger(L, __cl_gen_ret);
                    
                    
                    
                    return 1;
                }
                if(__gen_param_count == 1&& translator.Assignable<xc.GoodsEquip>(L, 1)) 
                {
                    xc.GoodsEquip equip = (xc.GoodsEquip)translator.GetObject(L, 1, typeof(xc.GoodsEquip));
                    
                        int __cl_gen_ret = xc.Equip.EquipHelper.GetStarAddEquip( equip );
                        LuaAPI.xlua_pushinteger(L, __cl_gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
            return LuaAPI.luaL_error(L, "invalid arguments to xc.Equip.EquipHelper.GetStarAddEquip!");
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_GetInstallEquipByPos_xlua_st_(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            
            try {
                
                {
                    uint pos = LuaAPI.xlua_touint(L, 1);
                    
                        xc.GoodsEquip __cl_gen_ret = xc.Equip.EquipHelper.GetInstallEquipByPos( pos );
                        translator.Push(L, __cl_gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_GetInstallEquipListByPos_xlua_st_(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            
            try {
                
                {
                    uint pos = LuaAPI.xlua_touint(L, 1);
                    
                        System.Collections.Generic.List<xc.GoodsEquip> __cl_gen_ret = xc.Equip.EquipHelper.GetInstallEquipListByPos( pos );
                        translator.Push(L, __cl_gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_CheckEquipCanInstall_xlua_st_(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            
            try {
                
                {
                    xc.GoodsEquip equip = (xc.GoodsEquip)translator.GetObject(L, 1, typeof(xc.GoodsEquip));
                    
                        bool __cl_gen_ret = xc.Equip.EquipHelper.CheckEquipCanInstall( equip );
                        LuaAPI.lua_pushboolean(L, __cl_gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_GetEquipRecycleRewardGoods_xlua_st_(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            
            try {
                
                {
                    xc.GoodsEquip equip = (xc.GoodsEquip)translator.GetObject(L, 1, typeof(xc.GoodsEquip));
                    
                        xc.Goods __cl_gen_ret = xc.Equip.EquipHelper.GetEquipRecycleRewardGoods( equip );
                        translator.Push(L, __cl_gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_GetEquipCustomBaseDes_xlua_st_(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            
            try {
                
                {
                    xc.ActorAttribute attr = (xc.ActorAttribute)translator.GetObject(L, 1, typeof(xc.ActorAttribute));
                    
                        System.Collections.Generic.List<string> __cl_gen_ret = xc.Equip.EquipHelper.GetEquipCustomBaseDes( attr );
                        translator.Push(L, __cl_gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_GetEquipBaseDes_xlua_st_(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            
            try {
                
                {
                    xc.ActorAttribute attr = (xc.ActorAttribute)translator.GetObject(L, 1, typeof(xc.ActorAttribute));
                    string color = LuaAPI.lua_tostring(L, 2);
                    
                        string __cl_gen_ret = xc.Equip.EquipHelper.GetEquipBaseDes( attr, color );
                        LuaAPI.lua_pushstring(L, __cl_gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_GetEquipBaseDesItemArray_xlua_st_(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            
			int __gen_param_count = LuaAPI.lua_gettop(L);
            
            try {
                if(__gen_param_count == 2&& translator.Assignable<xc.ActorAttribute>(L, 1)&& LuaTypes.LUA_TBOOLEAN == LuaAPI.lua_type(L, 2)) 
                {
                    xc.ActorAttribute attr = (xc.ActorAttribute)translator.GetObject(L, 1, typeof(xc.ActorAttribute));
                    bool needSort = LuaAPI.lua_toboolean(L, 2);
                    
                        System.Collections.Generic.List<xc.Equip.EquipHelper.AttributeDescItem> __cl_gen_ret = xc.Equip.EquipHelper.GetEquipBaseDesItemArray( attr, needSort );
                        translator.Push(L, __cl_gen_ret);
                    
                    
                    
                    return 1;
                }
                if(__gen_param_count == 1&& translator.Assignable<xc.ActorAttribute>(L, 1)) 
                {
                    xc.ActorAttribute attr = (xc.ActorAttribute)translator.GetObject(L, 1, typeof(xc.ActorAttribute));
                    
                        System.Collections.Generic.List<xc.Equip.EquipHelper.AttributeDescItem> __cl_gen_ret = xc.Equip.EquipHelper.GetEquipBaseDesItemArray( attr );
                        translator.Push(L, __cl_gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
            return LuaAPI.luaL_error(L, "invalid arguments to xc.Equip.EquipHelper.GetEquipBaseDesItemArray!");
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_GetBagEquipsOidsByColorAndLvStep_xlua_st_(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            
            try {
                
                {
                    uint color = LuaAPI.xlua_touint(L, 1);
                    uint lvStep = LuaAPI.xlua_touint(L, 2);
                    
                        System.Collections.Generic.Dictionary<ulong, xc.Goods> __cl_gen_ret = xc.Equip.EquipHelper.GetBagEquipsOidsByColorAndLvStep( color, lvStep );
                        translator.Push(L, __cl_gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_GetBagEquipsByIdsAndStar_xlua_st_(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            
            try {
                
                {
                    XLua.LuaTable idTable = (XLua.LuaTable)translator.GetObject(L, 1, typeof(XLua.LuaTable));
                    uint star = LuaAPI.xlua_touint(L, 2);
                    
                        System.Collections.Generic.Dictionary<ulong, xc.Goods> __cl_gen_ret = xc.Equip.EquipHelper.GetBagEquipsByIdsAndStar( idTable, star );
                        translator.Push(L, __cl_gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_GetComposeMoney_xlua_st_(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            
            try {
                
                {
                    uint gid = LuaAPI.xlua_touint(L, 1);
                    
                        System.Collections.Generic.Dictionary<uint, uint> __cl_gen_ret = xc.Equip.EquipHelper.GetComposeMoney( gid );
                        translator.Push(L, __cl_gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_GetComposeStuffs_xlua_st_(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            
            try {
                
                {
                    uint gid = LuaAPI.xlua_touint(L, 1);
                    
                        System.Collections.Generic.List<xc.Goods> __cl_gen_ret = xc.Equip.EquipHelper.GetComposeStuffs( gid );
                        translator.Push(L, __cl_gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_GetGemNextGems_xlua_st_(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            
            try {
                
                {
                    uint currentTypeId = LuaAPI.xlua_touint(L, 1);
                    
                        xc.GoodsLuaEx __cl_gen_ret = xc.Equip.EquipHelper.GetGemNextGems( currentTypeId );
                        translator.Push(L, __cl_gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_GetGemTypeNameByHole_xlua_st_(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            
            try {
                
                {
                    uint hole = LuaAPI.xlua_touint(L, 1);
                    xc.GoodsEquip equip = (xc.GoodsEquip)translator.GetObject(L, 2, typeof(xc.GoodsEquip));
                    
                        string __cl_gen_ret = xc.Equip.EquipHelper.GetGemTypeNameByHole( hole, equip );
                        LuaAPI.lua_pushstring(L, __cl_gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_GetBagGemSordList_xlua_st_(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            
            try {
                
                {
                    System.Collections.Generic.List<uint> gemTypes = (System.Collections.Generic.List<uint>)translator.GetObject(L, 1, typeof(System.Collections.Generic.List<uint>));
                    
                        System.Collections.Generic.List<xc.GoodsLuaEx> __cl_gen_ret = xc.Equip.EquipHelper.GetBagGemSordList( gemTypes );
                        translator.Push(L, __cl_gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_isCanComposeGem_xlua_st_(RealStatePtr L)
        {
            
            
            
            try {
                
                {
                    uint gid = LuaAPI.xlua_touint(L, 1);
                    
                        bool __cl_gen_ret = xc.Equip.EquipHelper.isCanComposeGem( gid );
                        LuaAPI.lua_pushboolean(L, __cl_gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_IsCanComposeEngrave_xlua_st_(RealStatePtr L)
        {
            
            
            
            try {
                
                {
                    uint gid = LuaAPI.xlua_touint(L, 1);
                    
                        bool __cl_gen_ret = xc.Equip.EquipHelper.IsCanComposeEngrave( gid );
                        LuaAPI.lua_pushboolean(L, __cl_gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_GetGemTypeByGemGid_xlua_st_(RealStatePtr L)
        {
            
            
            
            try {
                
                {
                    uint gid = LuaAPI.xlua_touint(L, 1);
                    
                        uint __cl_gen_ret = xc.Equip.EquipHelper.GetGemTypeByGemGid( gid );
                        LuaAPI.xlua_pushuint(L, __cl_gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_GetGemLevelByGemGid_xlua_st_(RealStatePtr L)
        {
            
            
            
            try {
                
                {
                    uint gid = LuaAPI.xlua_touint(L, 1);
                    
                        uint __cl_gen_ret = xc.Equip.EquipHelper.GetGemLevelByGemGid( gid );
                        LuaAPI.xlua_pushuint(L, __cl_gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_GetGemTypeHole_xlua_st_(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            
            try {
                
                {
                    uint hole = LuaAPI.xlua_touint(L, 1);
                    xc.GoodsEquip equip = (xc.GoodsEquip)translator.GetObject(L, 2, typeof(xc.GoodsEquip));
                    
                        System.Collections.Generic.List<uint> __cl_gen_ret = xc.Equip.EquipHelper.GetGemTypeHole( hole, equip );
                        translator.Push(L, __cl_gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_GetGemMinLvByGemType_xlua_st_(RealStatePtr L)
        {
            
            
            
            try {
                
                {
                    uint type = LuaAPI.xlua_touint(L, 1);
                    
                        uint __cl_gen_ret = xc.Equip.EquipHelper.GetGemMinLvByGemType( type );
                        LuaAPI.xlua_pushuint(L, __cl_gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_GetBagGemByHole_xlua_st_(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            
            try {
                
                {
                    uint hole = LuaAPI.xlua_touint(L, 1);
                    xc.GoodsEquip equip = (xc.GoodsEquip)translator.GetObject(L, 2, typeof(xc.GoodsEquip));
                    
                        System.Collections.Generic.List<xc.Goods> __cl_gen_ret = xc.Equip.EquipHelper.GetBagGemByHole( hole, equip );
                        translator.Push(L, __cl_gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_GetBagIsCanGemInstall_xlua_st_(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            
            try {
                
                {
                    xc.GoodsEquip equip = (xc.GoodsEquip)translator.GetObject(L, 1, typeof(xc.GoodsEquip));
                    
                        bool __cl_gen_ret = xc.Equip.EquipHelper.GetBagIsCanGemInstall( equip );
                        LuaAPI.lua_pushboolean(L, __cl_gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_GetBagIsCanHigherGemInstall_xlua_st_(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            
            try {
                
                {
                    xc.GoodsEquip equip = (xc.GoodsEquip)translator.GetObject(L, 1, typeof(xc.GoodsEquip));
                    uint hole = LuaAPI.xlua_touint(L, 2);
                    
                        bool __cl_gen_ret = xc.Equip.EquipHelper.GetBagIsCanHigherGemInstall( equip, hole );
                        LuaAPI.lua_pushboolean(L, __cl_gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_GetGemHoleInstallCondtion_xlua_st_(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            
            try {
                
                {
                    uint hole = LuaAPI.xlua_touint(L, 1);
                    xc.GoodsEquip equip = (xc.GoodsEquip)translator.GetObject(L, 2, typeof(xc.GoodsEquip));
                    
                        System.Collections.Generic.Dictionary<string, uint> __cl_gen_ret = xc.Equip.EquipHelper.GetGemHoleInstallCondtion( hole, equip );
                        translator.Push(L, __cl_gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_GetAllEquipGemAttr_xlua_st_(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            
            try {
                
                {
                    xc.GoodsEquip equip = (xc.GoodsEquip)translator.GetObject(L, 1, typeof(xc.GoodsEquip));
                    
                        xc.ActorAttribute __cl_gen_ret = xc.Equip.EquipHelper.GetAllEquipGemAttr( equip );
                        translator.Push(L, __cl_gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_GetGemAttr_xlua_st_(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            
            try {
                
                {
                    uint type_id = LuaAPI.xlua_touint(L, 1);
                    
                        xc.ActorAttribute __cl_gen_ret = xc.Equip.EquipHelper.GetGemAttr( type_id );
                        translator.Push(L, __cl_gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_GetEngraveAttrs_xlua_st_(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            
            try {
                
                {
                    xc.DBEngrave.EngraveInfo engraveInfo = (xc.DBEngrave.EngraveInfo)translator.GetObject(L, 1, typeof(xc.DBEngrave.EngraveInfo));
                    
                        xc.ActorAttribute __cl_gen_ret = xc.Equip.EquipHelper.GetEngraveAttrs( engraveInfo );
                        translator.Push(L, __cl_gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_GetGemTotalLv_xlua_st_(RealStatePtr L)
        {
            
            
            
            try {
                
                {
                    
                        uint __cl_gen_ret = xc.Equip.EquipHelper.GetGemTotalLv(  );
                        LuaAPI.xlua_pushuint(L, __cl_gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_GetGemAttrByTotalLv_xlua_st_(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            
            try {
                
                {
                    uint totalLv = LuaAPI.xlua_touint(L, 1);
                    
                        xc.ActorAttribute __cl_gen_ret = xc.Equip.EquipHelper.GetGemAttrByTotalLv( totalLv );
                        translator.Push(L, __cl_gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_GetEngraveAttrByTotalLv_xlua_st_(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            
            try {
                
                {
                    uint totalLv = LuaAPI.xlua_touint(L, 1);
                    
                        xc.ActorAttribute __cl_gen_ret = xc.Equip.EquipHelper.GetEngraveAttrByTotalLv( totalLv );
                        translator.Push(L, __cl_gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_GetGemDataTotalLv_xlua_st_(RealStatePtr L)
        {
            
            
            
            try {
                
                {
                    uint realLv = LuaAPI.xlua_touint(L, 1);
                    
                        uint __cl_gen_ret = xc.Equip.EquipHelper.GetGemDataTotalLv( realLv );
                        LuaAPI.xlua_pushuint(L, __cl_gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_CheckEquipCanSuit_xlua_st_(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            
            try {
                
                {
                    xc.GoodsEquip equip = (xc.GoodsEquip)translator.GetObject(L, 1, typeof(xc.GoodsEquip));
                    uint suitLv = LuaAPI.xlua_touint(L, 2);
                    
                        bool __cl_gen_ret = xc.Equip.EquipHelper.CheckEquipCanSuit( equip, suitLv );
                        LuaAPI.lua_pushboolean(L, __cl_gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_GetMaxNum_xlua_st_(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            
            try {
                
                {
                    xc.GoodsEquip equip = (xc.GoodsEquip)translator.GetObject(L, 1, typeof(xc.GoodsEquip));
                    
                        uint __cl_gen_ret = xc.Equip.EquipHelper.GetMaxNum( equip );
                        LuaAPI.xlua_pushuint(L, __cl_gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_GetEquipTipsUpgradeRank_xlua_st_(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            
            try {
                
                {
                    xc.GoodsEquip equip = (xc.GoodsEquip)translator.GetObject(L, 1, typeof(xc.GoodsEquip));
                    
                        int __cl_gen_ret = xc.Equip.EquipHelper.GetEquipTipsUpgradeRank( equip );
                        LuaAPI.xlua_pushinteger(L, __cl_gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_GetOtherPlayerEquipTipsUpgradeRank_xlua_st_(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            
            try {
                
                {
                    xc.GoodsEquip equip = (xc.GoodsEquip)translator.GetObject(L, 1, typeof(xc.GoodsEquip));
                    
                        int __cl_gen_ret = xc.Equip.EquipHelper.GetOtherPlayerEquipTipsUpgradeRank( equip );
                        LuaAPI.xlua_pushinteger(L, __cl_gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_GetSuitRank_xlua_st_(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            
            try {
                
                {
                    xc.GoodsEquip equip = (xc.GoodsEquip)translator.GetObject(L, 1, typeof(xc.GoodsEquip));
                    
                        int __cl_gen_ret = xc.Equip.EquipHelper.GetSuitRank( equip );
                        LuaAPI.xlua_pushinteger(L, __cl_gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_GetSuitRefineRank_xlua_st_(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            
            try {
                
                {
                    xc.GoodsEquip equip = (xc.GoodsEquip)translator.GetObject(L, 1, typeof(xc.GoodsEquip));
                    
                        int __cl_gen_ret = xc.Equip.EquipHelper.GetSuitRefineRank( equip );
                        LuaAPI.xlua_pushinteger(L, __cl_gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_CalculatorInstallSuitNum_xlua_st_(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            
			int __gen_param_count = LuaAPI.lua_gettop(L);
            
            try {
                if(__gen_param_count == 2&& translator.Assignable<xc.GoodsEquip>(L, 1)&& translator.Assignable<System.Collections.Generic.Dictionary<ulong, xc.GoodsEquip>>(L, 2)) 
                {
                    xc.GoodsEquip equip = (xc.GoodsEquip)translator.GetObject(L, 1, typeof(xc.GoodsEquip));
                    System.Collections.Generic.Dictionary<ulong, xc.GoodsEquip> installEquip = (System.Collections.Generic.Dictionary<ulong, xc.GoodsEquip>)translator.GetObject(L, 2, typeof(System.Collections.Generic.Dictionary<ulong, xc.GoodsEquip>));
                    
                        uint __cl_gen_ret = xc.Equip.EquipHelper.CalculatorInstallSuitNum( equip, installEquip );
                        LuaAPI.xlua_pushuint(L, __cl_gen_ret);
                    
                    
                    
                    return 1;
                }
                if(__gen_param_count == 1&& translator.Assignable<xc.GoodsEquip>(L, 1)) 
                {
                    xc.GoodsEquip equip = (xc.GoodsEquip)translator.GetObject(L, 1, typeof(xc.GoodsEquip));
                    
                        uint __cl_gen_ret = xc.Equip.EquipHelper.CalculatorInstallSuitNum( equip );
                        LuaAPI.xlua_pushuint(L, __cl_gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
            return LuaAPI.luaL_error(L, "invalid arguments to xc.Equip.EquipHelper.CalculatorInstallSuitNum!");
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_CalculatorSuitNum_xlua_st_(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            
			int __gen_param_count = LuaAPI.lua_gettop(L);
            
            try {
                if(__gen_param_count == 1&& translator.Assignable<System.Collections.Generic.Dictionary<ulong, xc.GoodsEquip>>(L, 1)) 
                {
                    System.Collections.Generic.Dictionary<ulong, xc.GoodsEquip> installEquip = (System.Collections.Generic.Dictionary<ulong, xc.GoodsEquip>)translator.GetObject(L, 1, typeof(System.Collections.Generic.Dictionary<ulong, xc.GoodsEquip>));
                    
                    xc.Equip.EquipHelper.CalculatorSuitNum( installEquip );
                    
                    
                    
                    return 0;
                }
                if(__gen_param_count == 1&& translator.Assignable<System.Collections.Generic.List<xc.GoodsEquip>>(L, 1)) 
                {
                    System.Collections.Generic.List<xc.GoodsEquip> installEquip = (System.Collections.Generic.List<xc.GoodsEquip>)translator.GetObject(L, 1, typeof(System.Collections.Generic.List<xc.GoodsEquip>));
                    
                    xc.Equip.EquipHelper.CalculatorSuitNum( installEquip );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
            return LuaAPI.luaL_error(L, "invalid arguments to xc.Equip.EquipHelper.CalculatorSuitNum!");
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_GetActiveSuitNum_xlua_st_(RealStatePtr L)
        {
            
            
            
            try {
                
                {
                    uint suitId = LuaAPI.xlua_touint(L, 1);
                    uint suitLv = LuaAPI.xlua_touint(L, 2);
                    uint suitNum = LuaAPI.xlua_touint(L, 3);
                    
                        uint __cl_gen_ret = xc.Equip.EquipHelper.GetActiveSuitNum( suitId, suitLv, suitNum );
                        LuaAPI.xlua_pushuint(L, __cl_gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_GetInstallEquipSuitNum_xlua_st_(RealStatePtr L)
        {
            
            
            
            try {
                
                {
                    
                        uint __cl_gen_ret = xc.Equip.EquipHelper.GetInstallEquipSuitNum(  );
                        LuaAPI.xlua_pushuint(L, __cl_gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_EnableEquipBaptizeRedPoint_xlua_st_(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            
            try {
                
                {
                    xc.GoodsEquip equip = (xc.GoodsEquip)translator.GetObject(L, 1, typeof(xc.GoodsEquip));
                    
                        bool __cl_gen_ret = xc.Equip.EquipHelper.EnableEquipBaptizeRedPoint( equip );
                        LuaAPI.lua_pushboolean(L, __cl_gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_GetEquipBaptizeRank_xlua_st_(RealStatePtr L)
        {
            
            
            
            try {
                
                {
                    uint pos = LuaAPI.xlua_touint(L, 1);
                    uint index = LuaAPI.xlua_touint(L, 2);
                    
                        int __cl_gen_ret = xc.Equip.EquipHelper.GetEquipBaptizeRank( pos, index );
                        LuaAPI.xlua_pushinteger(L, __cl_gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_GetEquipBaptizeRankType_xlua_st_(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            
			int __gen_param_count = LuaAPI.lua_gettop(L);
            
            try {
                if(__gen_param_count == 3&& LuaTypes.LUA_TNUMBER == LuaAPI.lua_type(L, 1)&& LuaTypes.LUA_TNUMBER == LuaAPI.lua_type(L, 2)&& translator.Assignable<xc.AttrScoreGType>(L, 3)) 
                {
                    uint pos = LuaAPI.xlua_touint(L, 1);
                    uint index = LuaAPI.xlua_touint(L, 2);
                    xc.AttrScoreGType _type;translator.Get(L, 3, out _type);
                    
                        int __cl_gen_ret = xc.Equip.EquipHelper.GetEquipBaptizeRankType( pos, index, _type );
                        LuaAPI.xlua_pushinteger(L, __cl_gen_ret);
                    
                    
                    
                    return 1;
                }
                if(__gen_param_count == 4&& LuaTypes.LUA_TNUMBER == LuaAPI.lua_type(L, 1)&& LuaTypes.LUA_TNUMBER == LuaAPI.lua_type(L, 2)&& translator.Assignable<xc.AttrScoreGType>(L, 3)&& translator.Assignable<xc.EquipPosInfo>(L, 4)) 
                {
                    uint pos = LuaAPI.xlua_touint(L, 1);
                    uint index = LuaAPI.xlua_touint(L, 2);
                    xc.AttrScoreGType _type;translator.Get(L, 3, out _type);
                    xc.EquipPosInfo posinfo = (xc.EquipPosInfo)translator.GetObject(L, 4, typeof(xc.EquipPosInfo));
                    
                        int __cl_gen_ret = xc.Equip.EquipHelper.GetEquipBaptizeRankType( pos, index, _type, posinfo );
                        LuaAPI.xlua_pushinteger(L, __cl_gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
            return LuaAPI.luaL_error(L, "invalid arguments to xc.Equip.EquipHelper.GetEquipBaptizeRankType!");
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_GetLockCountByPos_xlua_st_(RealStatePtr L)
        {
            
            
            
            try {
                
                {
                    uint pos = LuaAPI.xlua_touint(L, 1);
                    uint index = LuaAPI.xlua_touint(L, 2);
                    
                        uint __cl_gen_ret = xc.Equip.EquipHelper.GetLockCountByPos( pos, index );
                        LuaAPI.xlua_pushuint(L, __cl_gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_GetOpenCountByPos_xlua_st_(RealStatePtr L)
        {
            
            
            
            try {
                
                {
                    uint pos = LuaAPI.xlua_touint(L, 1);
                    uint index = LuaAPI.xlua_touint(L, 2);
                    
                        uint __cl_gen_ret = xc.Equip.EquipHelper.GetOpenCountByPos( pos, index );
                        LuaAPI.xlua_pushuint(L, __cl_gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_GetCurrentEquipBaptizeAttrDes_xlua_st_(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            
            try {
                
                {
                    xc.GoodsEquip equip = (xc.GoodsEquip)translator.GetObject(L, 1, typeof(xc.GoodsEquip));
                    
                        string __cl_gen_ret = xc.Equip.EquipHelper.GetCurrentEquipBaptizeAttrDes( equip );
                        LuaAPI.lua_pushstring(L, __cl_gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_GetUnLockCountByPos_xlua_st_(RealStatePtr L)
        {
            
            
            
            try {
                
                {
                    uint pos = LuaAPI.xlua_touint(L, 1);
                    uint index = LuaAPI.xlua_touint(L, 2);
                    
                        uint __cl_gen_ret = xc.Equip.EquipHelper.GetUnLockCountByPos( pos, index );
                        LuaAPI.xlua_pushuint(L, __cl_gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_GetBaptizeLockCostGoods_xlua_st_(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            
            try {
                
                {
                    uint lockCount = LuaAPI.xlua_touint(L, 1);
                    
                        xc.Goods __cl_gen_ret = xc.Equip.EquipHelper.GetBaptizeLockCostGoods( lockCount );
                        translator.Push(L, __cl_gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_GetBaptizeLockCostDiamond_xlua_st_(RealStatePtr L)
        {
            
            
            
            try {
                
                {
                    uint lockCount = LuaAPI.xlua_touint(L, 1);
                    
                        uint __cl_gen_ret = xc.Equip.EquipHelper.GetBaptizeLockCostDiamond( lockCount );
                        LuaAPI.xlua_pushuint(L, __cl_gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_GetBaptizeAddBaseAttrDisplay_xlua_st_(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            
            try {
                
                {
                    xc.GoodsEquip installEquip = (xc.GoodsEquip)translator.GetObject(L, 1, typeof(xc.GoodsEquip));
                    xc.EquipBaptizeInfo baptizeInfo = (xc.EquipBaptizeInfo)translator.GetObject(L, 2, typeof(xc.EquipBaptizeInfo));
                    
                        string __cl_gen_ret = xc.Equip.EquipHelper.GetBaptizeAddBaseAttrDisplay( installEquip, baptizeInfo );
                        LuaAPI.lua_pushstring(L, __cl_gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_GetBaptizeMinValue_xlua_st_(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            
            try {
                
                {
                    xc.GoodsEquip installEquip = (xc.GoodsEquip)translator.GetObject(L, 1, typeof(xc.GoodsEquip));
                    xc.EquipBaptizeInfo baptizeInfo = (xc.EquipBaptizeInfo)translator.GetObject(L, 2, typeof(xc.EquipBaptizeInfo));
                    
                        xc.ActorAttribute __cl_gen_ret = xc.Equip.EquipHelper.GetBaptizeMinValue( installEquip, baptizeInfo );
                        translator.Push(L, __cl_gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_GetBaptizeMaxValue_xlua_st_(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            
            try {
                
                {
                    xc.GoodsEquip installEquip = (xc.GoodsEquip)translator.GetObject(L, 1, typeof(xc.GoodsEquip));
                    xc.EquipBaptizeInfo baptizeInfo = (xc.EquipBaptizeInfo)translator.GetObject(L, 2, typeof(xc.EquipBaptizeInfo));
                    
                        xc.ActorAttribute __cl_gen_ret = xc.Equip.EquipHelper.GetBaptizeMaxValue( installEquip, baptizeInfo );
                        translator.Push(L, __cl_gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_GetBaptizeColor_xlua_st_(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            
            try {
                
                {
                    xc.GoodsEquip installEquip = (xc.GoodsEquip)translator.GetObject(L, 1, typeof(xc.GoodsEquip));
                    xc.EquipBaptizeInfo baptizeInfo = (xc.EquipBaptizeInfo)translator.GetObject(L, 2, typeof(xc.EquipBaptizeInfo));
                    
                        uint __cl_gen_ret = xc.Equip.EquipHelper.GetBaptizeColor( installEquip, baptizeInfo );
                        LuaAPI.xlua_pushuint(L, __cl_gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_CheckEquipCanStrength_xlua_st_(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            
            try {
                
                {
                    xc.GoodsEquip equip = (xc.GoodsEquip)translator.GetObject(L, 1, typeof(xc.GoodsEquip));
                    
                        bool __cl_gen_ret = xc.Equip.EquipHelper.CheckEquipCanStrength( equip );
                        LuaAPI.lua_pushboolean(L, __cl_gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_CheckAllInstallEquipsCanStrength_xlua_st_(RealStatePtr L)
        {
            
            
            
            try {
                
                {
                    
                        bool __cl_gen_ret = xc.Equip.EquipHelper.CheckAllInstallEquipsCanStrength(  );
                        LuaAPI.lua_pushboolean(L, __cl_gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_GetStrengthDataLv_xlua_st_(RealStatePtr L)
        {
            
            
            
            try {
                
                {
                    uint realLv = LuaAPI.xlua_touint(L, 1);
                    
                        uint __cl_gen_ret = xc.Equip.EquipHelper.GetStrengthDataLv( realLv );
                        LuaAPI.xlua_pushuint(L, __cl_gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_GetInstallStrength_xlua_st_(RealStatePtr L)
        {
            
            
            
            try {
                
                {
                    
                        uint __cl_gen_ret = xc.Equip.EquipHelper.GetInstallStrength(  );
                        LuaAPI.xlua_pushuint(L, __cl_gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_GetAllStrengthExAttribute_xlua_st_(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            
            try {
                
                {
                    uint current = LuaAPI.xlua_touint(L, 1);
                    uint vocation = LuaAPI.xlua_touint(L, 2);
                    
                        xc.ActorAttribute __cl_gen_ret = xc.Equip.EquipHelper.GetAllStrengthExAttribute( current, vocation );
                        translator.Push(L, __cl_gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_GetStrengthStuff_xlua_st_(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            
            try {
                
                {
                    uint lv = LuaAPI.xlua_touint(L, 1);
                    
                        Net.PkgGoodsGidnum __cl_gen_ret = xc.Equip.EquipHelper.GetStrengthStuff( lv );
                        translator.Push(L, __cl_gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_GetStrengthShowRedPointGoods_xlua_st_(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            
            try {
                
                {
                    uint lv = LuaAPI.xlua_touint(L, 1);
                    
                        Net.PkgGoodsGidnum __cl_gen_ret = xc.Equip.EquipHelper.GetStrengthShowRedPointGoods( lv );
                        translator.Push(L, __cl_gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_GetStrengGoodsEquip_xlua_st_(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            
            try {
                
                {
                    
                        System.Collections.Generic.List<xc.GoodsEquip> __cl_gen_ret = xc.Equip.EquipHelper.GetStrengGoodsEquip(  );
                        translator.Push(L, __cl_gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_GetPosInfoByPos_suitIgnoreIndex_xlua_st_(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            
            try {
                
                {
                    uint pos = LuaAPI.xlua_touint(L, 1);
                    uint index = LuaAPI.xlua_touint(L, 2);
                    
                        xc.EquipPosInfo __cl_gen_ret = xc.Equip.EquipHelper.GetPosInfoByPos_suitIgnoreIndex( pos, index );
                        translator.Push(L, __cl_gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_GetEquipStrengthRank_xlua_st_(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            
            try {
                
                {
                    uint lv = LuaAPI.xlua_touint(L, 1);
                    xc.GoodsEquip equip = (xc.GoodsEquip)translator.GetObject(L, 2, typeof(xc.GoodsEquip));
                    
                        int __cl_gen_ret = xc.Equip.EquipHelper.GetEquipStrengthRank( lv, equip );
                        LuaAPI.xlua_pushinteger(L, __cl_gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_GetEquipBaseAttrScoreByType_xlua_st_(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            
            try {
                
                {
                    xc.AttrScoreGType type;translator.Get(L, 1, out type);
                    xc.ActorAttribute baseAttr = (xc.ActorAttribute)translator.GetObject(L, 2, typeof(xc.ActorAttribute));
                    
                        int __cl_gen_ret = xc.Equip.EquipHelper.GetEquipBaseAttrScoreByType( type, baseAttr );
                        LuaAPI.xlua_pushinteger(L, __cl_gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_GetEquipStrengthAttr_xlua_st_(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            
            try {
                
                {
                    uint Strengthlv = LuaAPI.xlua_touint(L, 1);
                    xc.GoodsEquip equip = (xc.GoodsEquip)translator.GetObject(L, 2, typeof(xc.GoodsEquip));
                    
                        xc.ActorAttribute __cl_gen_ret = xc.Equip.EquipHelper.GetEquipStrengthAttr( Strengthlv, equip );
                        translator.Push(L, __cl_gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_GetStrengthInfoByPosAndIndex_xlua_st_(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            
            try {
                
                {
                    uint pos = LuaAPI.xlua_touint(L, 1);
                    uint index = LuaAPI.xlua_touint(L, 2);
                    
                        xc.EquipPosInfo __cl_gen_ret = xc.Equip.EquipHelper.GetStrengthInfoByPosAndIndex( pos, index );
                        translator.Push(L, __cl_gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_GetEquipPosInfosByPkgInfos_xlua_st_(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            
            try {
                
                {
                    System.Collections.Generic.List<Net.PkgStrengthInfo> pkgStrengthInfos = (System.Collections.Generic.List<Net.PkgStrengthInfo>)translator.GetObject(L, 1, typeof(System.Collections.Generic.List<Net.PkgStrengthInfo>));
                    System.Collections.Generic.List<Net.PkgBaptizeInfo> pkgBaptizeInfos = (System.Collections.Generic.List<Net.PkgBaptizeInfo>)translator.GetObject(L, 2, typeof(System.Collections.Generic.List<Net.PkgBaptizeInfo>));
                    
                        System.Collections.Generic.Dictionary<uint, xc.EquipPosInfo> __cl_gen_ret = xc.Equip.EquipHelper.GetEquipPosInfosByPkgInfos( pkgStrengthInfos, pkgBaptizeInfos );
                        translator.Push(L, __cl_gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_GetEquipPosInfoByPkgInfo_xlua_st_(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            
            try {
                
                {
                    Net.PkgStrengthInfo pkgStrengthInfo = (Net.PkgStrengthInfo)translator.GetObject(L, 1, typeof(Net.PkgStrengthInfo));
                    Net.PkgBaptizeInfo pkgBaptizeInfo = (Net.PkgBaptizeInfo)translator.GetObject(L, 2, typeof(Net.PkgBaptizeInfo));
                    
                        xc.EquipPosInfo __cl_gen_ret = xc.Equip.EquipHelper.GetEquipPosInfoByPkgInfo( pkgStrengthInfo, pkgBaptizeInfo );
                        translator.Push(L, __cl_gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_GetSubAttrDes_xlua_st_(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            
			int __gen_param_count = LuaAPI.lua_gettop(L);
            
            try {
                if(__gen_param_count == 1&& translator.Assignable<xc.Equip.IEquipAttribute>(L, 1)) 
                {
                    xc.Equip.IEquipAttribute attr = (xc.Equip.IEquipAttribute)translator.GetObject(L, 1, typeof(xc.Equip.IEquipAttribute));
                    
                        string __cl_gen_ret = xc.Equip.EquipHelper.GetSubAttrDes( attr );
                        LuaAPI.lua_pushstring(L, __cl_gen_ret);
                    
                    
                    
                    return 1;
                }
                if(__gen_param_count == 3&& LuaTypes.LUA_TNUMBER == LuaAPI.lua_type(L, 1)&& translator.Assignable<System.Collections.Generic.List<uint>>(L, 2)&& (LuaAPI.lua_isnil(L, 3) || LuaAPI.lua_type(L, 3) == LuaTypes.LUA_TSTRING)) 
                {
                    uint id = LuaAPI.xlua_touint(L, 1);
                    System.Collections.Generic.List<uint> values = (System.Collections.Generic.List<uint>)translator.GetObject(L, 2, typeof(System.Collections.Generic.List<uint>));
                    string insert_str = LuaAPI.lua_tostring(L, 3);
                    uint color;
                    
                        string __cl_gen_ret = xc.Equip.EquipHelper.GetSubAttrDes( id, values, insert_str, out color );
                        LuaAPI.lua_pushstring(L, __cl_gen_ret);
                    LuaAPI.xlua_pushuint(L, color);
                        
                    
                    
                    
                    return 2;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
            return LuaAPI.luaL_error(L, "invalid arguments to xc.Equip.EquipHelper.GetSubAttrDes!");
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_GetEquipLegendAttrStr_xlua_st_(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            
            try {
                
                {
                    xc.GoodsEquip equip = (xc.GoodsEquip)translator.GetObject(L, 1, typeof(xc.GoodsEquip));
                    
                        string __cl_gen_ret = xc.Equip.EquipHelper.GetEquipLegendAttrStr( equip );
                        LuaAPI.lua_pushstring(L, __cl_gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_GetLegendAttrDesStrArray_xlua_st_(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            
            try {
                
                {
                    xc.Equip.EquipAttributes attrs = (xc.Equip.EquipAttributes)translator.GetObject(L, 1, typeof(xc.Equip.EquipAttributes));
                    
                        System.Collections.Generic.List<string> __cl_gen_ret = xc.Equip.EquipHelper.GetLegendAttrDesStrArray( attrs );
                        translator.Push(L, __cl_gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_GetEquipStarAttr_xlua_st_(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            
            try {
                
                {
                    int star = LuaAPI.xlua_tointeger(L, 1);
                    
                        xc.ActorAttribute __cl_gen_ret = xc.Equip.EquipHelper.GetEquipStarAttr( star );
                        translator.Push(L, __cl_gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_GetEquipLvStepName_xlua_st_(RealStatePtr L)
        {
            
            
            
            try {
                
                {
                    uint lvStep = LuaAPI.xlua_touint(L, 1);
                    
                        string __cl_gen_ret = xc.Equip.EquipHelper.GetEquipLvStepName( lvStep );
                        LuaAPI.lua_pushstring(L, __cl_gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_GetAttrbutesByDBStr_xlua_st_(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            
            try {
                
                {
                    string str = LuaAPI.lua_tostring(L, 1);
                    
                        xc.ActorAttribute __cl_gen_ret = xc.Equip.EquipHelper.GetAttrbutesByDBStr( str );
                        translator.Push(L, __cl_gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_DelEquipPart_xlua_st_(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            
            try {
                
                {
                    System.Collections.Generic.List<uint> shows = (System.Collections.Generic.List<uint>)translator.GetObject(L, 1, typeof(System.Collections.Generic.List<uint>));
                    xc.DBAvatarPart.BODY_PART body_part;translator.Get(L, 2, out body_part);
                    
                    xc.Equip.EquipHelper.DelEquipPart( shows, body_part );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_GetShowsAfterDelEquipPart_xlua_st_(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            
            try {
                
                {
                    System.Collections.Generic.List<uint> shows = (System.Collections.Generic.List<uint>)translator.GetObject(L, 1, typeof(System.Collections.Generic.List<uint>));
                    xc.DBAvatarPart.BODY_PART body_part;translator.Get(L, 2, out body_part);
                    
                        System.Collections.Generic.List<uint> __cl_gen_ret = xc.Equip.EquipHelper.GetShowsAfterDelEquipPart( shows, body_part );
                        translator.Push(L, __cl_gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        
        
        
        
        
		
		
		
		
    }
}
