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
    public class xcItemManagerWrap
    {
        public static void __Register(RealStatePtr L)
        {
			ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			XUtils.BeginObjectRegister(typeof(xc.ItemManager), L, translator, 0, 82, 68, 67);
			
			XUtils.RegisterFunc(L, XUtils.METHOD_IDX, "GetGoodsForAllByOId", _m_GetGoodsForAllByOId);
			XUtils.RegisterFunc(L, XUtils.METHOD_IDX, "GetGoodsForBagByOId", _m_GetGoodsForBagByOId);
			XUtils.RegisterFunc(L, XUtils.METHOD_IDX, "HasGoods", _m_HasGoods);
			XUtils.RegisterFunc(L, XUtils.METHOD_IDX, "GetGoodsNumForBagByTypeId", _m_GetGoodsNumForBagByTypeId);
			XUtils.RegisterFunc(L, XUtils.METHOD_IDX, "GetGoodsNumForBag", _m_GetGoodsNumForBag);
			XUtils.RegisterFunc(L, XUtils.METHOD_IDX, "GetGoodsNumForMountEquipBagByTypeId", _m_GetGoodsNumForMountEquipBagByTypeId);
			XUtils.RegisterFunc(L, XUtils.METHOD_IDX, "GetGoodsNumFromSoulBagAndBodyByTypeId", _m_GetGoodsNumFromSoulBagAndBodyByTypeId);
			XUtils.RegisterFunc(L, XUtils.METHOD_IDX, "GetGoodsNumFromHandbookBagAndBodyByTypeId", _m_GetGoodsNumFromHandbookBagAndBodyByTypeId);
			XUtils.RegisterFunc(L, XUtils.METHOD_IDX, "GetHandbookListForBagByTypeId", _m_GetHandbookListForBagByTypeId);
			XUtils.RegisterFunc(L, XUtils.METHOD_IDX, "ExistGoods", _m_ExistGoods);
			XUtils.RegisterFunc(L, XUtils.METHOD_IDX, "GetGoodsUnbindNumForBagByTypeId", _m_GetGoodsUnbindNumForBagByTypeId);
			XUtils.RegisterFunc(L, XUtils.METHOD_IDX, "IsHaveBindGoodsByTypeId", _m_IsHaveBindGoodsByTypeId);
			XUtils.RegisterFunc(L, XUtils.METHOD_IDX, "OpenSoul", _m_OpenSoul);
			XUtils.RegisterFunc(L, XUtils.METHOD_IDX, "SendSoulUpLv", _m_SendSoulUpLv);
			XUtils.RegisterFunc(L, XUtils.METHOD_IDX, "SendInstallSoul", _m_SendInstallSoul);
			XUtils.RegisterFunc(L, XUtils.METHOD_IDX, "SendResolveSoul", _m_SendResolveSoul);
			XUtils.RegisterFunc(L, XUtils.METHOD_IDX, "ExistSoul", _m_ExistSoul);
			XUtils.RegisterFunc(L, XUtils.METHOD_IDX, "GetGoodsListBySubType", _m_GetGoodsListBySubType);
			XUtils.RegisterFunc(L, XUtils.METHOD_IDX, "GetGoodsListForBagByTypeId", _m_GetGoodsListForBagByTypeId);
			XUtils.RegisterFunc(L, XUtils.METHOD_IDX, "GetEmptyItemCount", _m_GetEmptyItemCount);
			XUtils.RegisterFunc(L, XUtils.METHOD_IDX, "BagIsFull", _m_BagIsFull);
			XUtils.RegisterFunc(L, XUtils.METHOD_IDX, "GetBagEquipByPos", _m_GetBagEquipByPos);
			XUtils.RegisterFunc(L, XUtils.METHOD_IDX, "GetEquipCount", _m_GetEquipCount);
			XUtils.RegisterFunc(L, XUtils.METHOD_IDX, "Reset", _m_Reset);
			XUtils.RegisterFunc(L, XUtils.METHOD_IDX, "EquipSuitForge", _m_EquipSuitForge);
			XUtils.RegisterFunc(L, XUtils.METHOD_IDX, "EquipSuitRefine", _m_EquipSuitRefine);
			XUtils.RegisterFunc(L, XUtils.METHOD_IDX, "EquipBaptizeLock", _m_EquipBaptizeLock);
			XUtils.RegisterFunc(L, XUtils.METHOD_IDX, "EquipBaptizeOpen", _m_EquipBaptizeOpen);
			XUtils.RegisterFunc(L, XUtils.METHOD_IDX, "EquipBaptize", _m_EquipBaptize);
			XUtils.RegisterFunc(L, XUtils.METHOD_IDX, "EquipInstallGem", _m_EquipInstallGem);
			XUtils.RegisterFunc(L, XUtils.METHOD_IDX, "EquipUnInstallGem", _m_EquipUnInstallGem);
			XUtils.RegisterFunc(L, XUtils.METHOD_IDX, "UseGoods", _m_UseGoods);
			XUtils.RegisterFunc(L, XUtils.METHOD_IDX, "RecycleGoods", _m_RecycleGoods);
			XUtils.RegisterFunc(L, XUtils.METHOD_IDX, "SubmitGoods", _m_SubmitGoods);
			XUtils.RegisterFunc(L, XUtils.METHOD_IDX, "ComposeGoods", _m_ComposeGoods);
			XUtils.RegisterFunc(L, XUtils.METHOD_IDX, "StrengthEquip", _m_StrengthEquip);
			XUtils.RegisterFunc(L, XUtils.METHOD_IDX, "SellGoods", _m_SellGoods);
			XUtils.RegisterFunc(L, XUtils.METHOD_IDX, "CommonInstall", _m_CommonInstall);
			XUtils.RegisterFunc(L, XUtils.METHOD_IDX, "CheckQuickUnLock", _m_CheckQuickUnLock);
			XUtils.RegisterFunc(L, XUtils.METHOD_IDX, "IsBetterBagEquip", _m_IsBetterBagEquip);
			XUtils.RegisterFunc(L, XUtils.METHOD_IDX, "GetBetterBagEquip", _m_GetBetterBagEquip);
			XUtils.RegisterFunc(L, XUtils.METHOD_IDX, "GetCanUseGoods", _m_GetCanUseGoods);
			XUtils.RegisterFunc(L, XUtils.METHOD_IDX, "CheckBagCanQuickUse", _m_CheckBagCanQuickUse);
			XUtils.RegisterFunc(L, XUtils.METHOD_IDX, "GetShowItem", _m_GetShowItem);
			XUtils.RegisterFunc(L, XUtils.METHOD_IDX, "CanShowQuickUseWindow", _m_CanShowQuickUseWindow);
			XUtils.RegisterFunc(L, XUtils.METHOD_IDX, "IsBetterBagGoods", _m_IsBetterBagGoods);
			XUtils.RegisterFunc(L, XUtils.METHOD_IDX, "IsBetterThanBody", _m_IsBetterThanBody);
			XUtils.RegisterFunc(L, XUtils.METHOD_IDX, "GetBayTypeByGoods", _m_GetBayTypeByGoods);
			XUtils.RegisterFunc(L, XUtils.METHOD_IDX, "CheckBagCanQuickUse_addGoods", _m_CheckBagCanQuickUse_addGoods);
			XUtils.RegisterFunc(L, XUtils.METHOD_IDX, "CheckBagCanQuickUse_ConsumeBox", _m_CheckBagCanQuickUse_ConsumeBox);
			XUtils.RegisterFunc(L, XUtils.METHOD_IDX, "BagTransport", _m_BagTransport);
			XUtils.RegisterFunc(L, XUtils.METHOD_IDX, "SendAddBagPage", _m_SendAddBagPage);
			XUtils.RegisterFunc(L, XUtils.METHOD_IDX, "SendBagGoodsListByType", _m_SendBagGoodsListByType);
			XUtils.RegisterFunc(L, XUtils.METHOD_IDX, "SendOpenWare", _m_SendOpenWare);
			XUtils.RegisterFunc(L, XUtils.METHOD_IDX, "RegisterAllMessage", _m_RegisterAllMessage);
			XUtils.RegisterFunc(L, XUtils.METHOD_IDX, "HasUseTimesByGid", _m_HasUseTimesByGid);
			XUtils.RegisterFunc(L, XUtils.METHOD_IDX, "UpdateEquipRefreshTime", _m_UpdateEquipRefreshTime);
			XUtils.RegisterFunc(L, XUtils.METHOD_IDX, "DelGoods", _m_DelGoods);
			XUtils.RegisterFunc(L, XUtils.METHOD_IDX, "SortBagData", _m_SortBagData);
			XUtils.RegisterFunc(L, XUtils.METHOD_IDX, "DelGoodsToPanelSort", _m_DelGoodsToPanelSort);
			XUtils.RegisterFunc(L, XUtils.METHOD_IDX, "DelWareGoods", _m_DelWareGoods);
			XUtils.RegisterFunc(L, XUtils.METHOD_IDX, "SortWareData", _m_SortWareData);
			XUtils.RegisterFunc(L, XUtils.METHOD_IDX, "GetPkgGoods", _m_GetPkgGoods);
			XUtils.RegisterFunc(L, XUtils.METHOD_IDX, "GetGoodsByProtocolPkg", _m_GetGoodsByProtocolPkg);
			XUtils.RegisterFunc(L, XUtils.METHOD_IDX, "GetGoodsByProtocolPkgLua", _m_GetGoodsByProtocolPkgLua);
			XUtils.RegisterFunc(L, XUtils.METHOD_IDX, "GetPkgGoodsList", _m_GetPkgGoodsList);
			XUtils.RegisterFunc(L, XUtils.METHOD_IDX, "HandleServerData", _m_HandleServerData);
			XUtils.RegisterFunc(L, XUtils.METHOD_IDX, "AddCloseGoodsId", _m_AddCloseGoodsId);
			XUtils.RegisterFunc(L, XUtils.METHOD_IDX, "IsCloseGoodsId", _m_IsCloseGoodsId);
			XUtils.RegisterFunc(L, XUtils.METHOD_IDX, "RemoveCloseGoodsId", _m_RemoveCloseGoodsId);
			XUtils.RegisterFunc(L, XUtils.METHOD_IDX, "CheckBagFullRedPoint", _m_CheckBagFullRedPoint);
			XUtils.RegisterFunc(L, XUtils.METHOD_IDX, "DecorateInstall", _m_DecorateInstall);
			XUtils.RegisterFunc(L, XUtils.METHOD_IDX, "TakeOnDecorate", _m_TakeOnDecorate);
			XUtils.RegisterFunc(L, XUtils.METHOD_IDX, "TakeOffDecorate", _m_TakeOffDecorate);
			XUtils.RegisterFunc(L, XUtils.METHOD_IDX, "GetConsumeValue", _m_GetConsumeValue);
			XUtils.RegisterFunc(L, XUtils.METHOD_IDX, "GetWearingGodEquipGoods", _m_GetWearingGodEquipGoods);
			XUtils.RegisterFunc(L, XUtils.METHOD_IDX, "GetWearingMountEquipGoods", _m_GetWearingMountEquipGoods);
			XUtils.RegisterFunc(L, XUtils.METHOD_IDX, "GetBagDataByBagType", _m_GetBagDataByBagType);
			XUtils.RegisterFunc(L, XUtils.METHOD_IDX, "CheckHavePos", _m_CheckHavePos);
			XUtils.RegisterFunc(L, XUtils.METHOD_IDX, "FreshPosState", _m_FreshPosState);
			XUtils.RegisterFunc(L, XUtils.METHOD_IDX, "GetSortedLuckyTreasureGoodsList", _m_GetSortedLuckyTreasureGoodsList);
			XUtils.RegisterFunc(L, XUtils.METHOD_IDX, "ProcessAddGoodsListByLua", _m_ProcessAddGoodsListByLua);
			
			
			XUtils.RegisterFunc(L, XUtils.GETTER_IDX, "LuckyTreasureBagIsFull", _g_get_LuckyTreasureBagIsFull);
            XUtils.RegisterFunc(L, XUtils.GETTER_IDX, "BagGoodsOids", _g_get_BagGoodsOids);
            XUtils.RegisterFunc(L, XUtils.GETTER_IDX, "BagTypeIdAndOids", _g_get_BagTypeIdAndOids);
            XUtils.RegisterFunc(L, XUtils.GETTER_IDX, "BagPanelSort", _g_get_BagPanelSort);
            XUtils.RegisterFunc(L, XUtils.GETTER_IDX, "NeedUpdateBagIndexArray", _g_get_NeedUpdateBagIndexArray);
            XUtils.RegisterFunc(L, XUtils.GETTER_IDX, "WareHouseGoodsOids", _g_get_WareHouseGoodsOids);
            XUtils.RegisterFunc(L, XUtils.GETTER_IDX, "WareHouseTypeIdAndOids", _g_get_WareHouseTypeIdAndOids);
            XUtils.RegisterFunc(L, XUtils.GETTER_IDX, "WarePanelSort", _g_get_WarePanelSort);
            XUtils.RegisterFunc(L, XUtils.GETTER_IDX, "NeedUpdateWareIndexArray", _g_get_NeedUpdateWareIndexArray);
            XUtils.RegisterFunc(L, XUtils.GETTER_IDX, "TreasureHuntGoodsOids", _g_get_TreasureHuntGoodsOids);
            XUtils.RegisterFunc(L, XUtils.GETTER_IDX, "IDTreasureGoodsOids", _g_get_IDTreasureGoodsOids);
            XUtils.RegisterFunc(L, XUtils.GETTER_IDX, "HandbookGoodsOids", _g_get_HandbookGoodsOids);
            XUtils.RegisterFunc(L, XUtils.GETTER_IDX, "HandbookTypeIdAndOids", _g_get_HandbookTypeIdAndOids);
            XUtils.RegisterFunc(L, XUtils.GETTER_IDX, "SoulGoodsOids", _g_get_SoulGoodsOids);
            XUtils.RegisterFunc(L, XUtils.GETTER_IDX, "SoulTypeIdAndOids", _g_get_SoulTypeIdAndOids);
            XUtils.RegisterFunc(L, XUtils.GETTER_IDX, "DecorateGoodsOids", _g_get_DecorateGoodsOids);
            XUtils.RegisterFunc(L, XUtils.GETTER_IDX, "DecorateTypeIdAndOids", _g_get_DecorateTypeIdAndOids);
            XUtils.RegisterFunc(L, XUtils.GETTER_IDX, "MagicEquipGoodsOids", _g_get_MagicEquipGoodsOids);
            XUtils.RegisterFunc(L, XUtils.GETTER_IDX, "MagicEquipTypeIdAndOids", _g_get_MagicEquipTypeIdAndOids);
            XUtils.RegisterFunc(L, XUtils.GETTER_IDX, "InstallEquip", _g_get_InstallEquip);
            XUtils.RegisterFunc(L, XUtils.GETTER_IDX, "InstallGoodsSouls", _g_get_InstallGoodsSouls);
            XUtils.RegisterFunc(L, XUtils.GETTER_IDX, "WearingDecorate", _g_get_WearingDecorate);
            XUtils.RegisterFunc(L, XUtils.GETTER_IDX, "WearingMagicEquip", _g_get_WearingMagicEquip);
            XUtils.RegisterFunc(L, XUtils.GETTER_IDX, "EquipGoodsOid", _g_get_EquipGoodsOid);
            XUtils.RegisterFunc(L, XUtils.GETTER_IDX, "GoodsCd", _g_get_GoodsCd);
            XUtils.RegisterFunc(L, XUtils.GETTER_IDX, "InstallGodEquip", _g_get_InstallGodEquip);
            XUtils.RegisterFunc(L, XUtils.GETTER_IDX, "GodEquipGoodsOids", _g_get_GodEquipGoodsOids);
            XUtils.RegisterFunc(L, XUtils.GETTER_IDX, "InstallMountEquip", _g_get_InstallMountEquip);
            XUtils.RegisterFunc(L, XUtils.GETTER_IDX, "MountEquipGoodsOid", _g_get_MountEquipGoodsOid);
            XUtils.RegisterFunc(L, XUtils.GETTER_IDX, "MountEquipTypeIdAndOids", _g_get_MountEquipTypeIdAndOids);
            XUtils.RegisterFunc(L, XUtils.GETTER_IDX, "LightWeaponGoodsOids", _g_get_LightWeaponGoodsOids);
            XUtils.RegisterFunc(L, XUtils.GETTER_IDX, "InstalledLightWeaponSoul", _g_get_InstalledLightWeaponSoul);
            XUtils.RegisterFunc(L, XUtils.GETTER_IDX, "mBagInitCount", _g_get_mBagInitCount);
            XUtils.RegisterFunc(L, XUtils.GETTER_IDX, "mWareInitCount", _g_get_mWareInitCount);
            XUtils.RegisterFunc(L, XUtils.GETTER_IDX, "mBagMaxCount", _g_get_mBagMaxCount);
            XUtils.RegisterFunc(L, XUtils.GETTER_IDX, "mWareMaxCount", _g_get_mWareMaxCount);
            XUtils.RegisterFunc(L, XUtils.GETTER_IDX, "mBagTotalCount", _g_get_mBagTotalCount);
            XUtils.RegisterFunc(L, XUtils.GETTER_IDX, "mWareTotalCount", _g_get_mWareTotalCount);
            XUtils.RegisterFunc(L, XUtils.GETTER_IDX, "mSoulBagInitCount", _g_get_mSoulBagInitCount);
            XUtils.RegisterFunc(L, XUtils.GETTER_IDX, "mSoulBagTotalCount", _g_get_mSoulBagTotalCount);
            XUtils.RegisterFunc(L, XUtils.GETTER_IDX, "mSoulInstallInitCount", _g_get_mSoulInstallInitCount);
            XUtils.RegisterFunc(L, XUtils.GETTER_IDX, "mSoulInstallTotalCount", _g_get_mSoulInstallTotalCount);
            XUtils.RegisterFunc(L, XUtils.GETTER_IDX, "mHandbookBagInitCount", _g_get_mHandbookBagInitCount);
            XUtils.RegisterFunc(L, XUtils.GETTER_IDX, "mHandbookBagTotalCount", _g_get_mHandbookBagTotalCount);
            XUtils.RegisterFunc(L, XUtils.GETTER_IDX, "mDecorateBagInitCount", _g_get_mDecorateBagInitCount);
            XUtils.RegisterFunc(L, XUtils.GETTER_IDX, "mDecorateBagTotalCount", _g_get_mDecorateBagTotalCount);
            XUtils.RegisterFunc(L, XUtils.GETTER_IDX, "mMagicEquipBagInitCount", _g_get_mMagicEquipBagInitCount);
            XUtils.RegisterFunc(L, XUtils.GETTER_IDX, "mMagicEquipBagTotalCount", _g_get_mMagicEquipBagTotalCount);
            XUtils.RegisterFunc(L, XUtils.GETTER_IDX, "mGodEquipBagInitCount", _g_get_mGodEquipBagInitCount);
            XUtils.RegisterFunc(L, XUtils.GETTER_IDX, "mGodEquipBagTotalCount", _g_get_mGodEquipBagTotalCount);
            XUtils.RegisterFunc(L, XUtils.GETTER_IDX, "mMountEquipBagInitCount", _g_get_mMountEquipBagInitCount);
            XUtils.RegisterFunc(L, XUtils.GETTER_IDX, "mMountEquipBagTotalCount", _g_get_mMountEquipBagTotalCount);
            XUtils.RegisterFunc(L, XUtils.GETTER_IDX, "mLightWeaponSoulBagInitCount", _g_get_mLightWeaponSoulBagInitCount);
            XUtils.RegisterFunc(L, XUtils.GETTER_IDX, "mLightWeaponSoulBagTotalCount", _g_get_mLightWeaponSoulBagTotalCount);
            XUtils.RegisterFunc(L, XUtils.GETTER_IDX, "mLuckyTreasureBagMaxCount", _g_get_mLuckyTreasureBagMaxCount);
            XUtils.RegisterFunc(L, XUtils.GETTER_IDX, "isForceShowfloatTips", _g_get_isForceShowfloatTips);
            XUtils.RegisterFunc(L, XUtils.GETTER_IDX, "mIsAutoHp", _g_get_mIsAutoHp);
            XUtils.RegisterFunc(L, XUtils.GETTER_IDX, "mIsAutoMp", _g_get_mIsAutoMp);
            XUtils.RegisterFunc(L, XUtils.GETTER_IDX, "mIconConfig", _g_get_mIconConfig);
            XUtils.RegisterFunc(L, XUtils.GETTER_IDX, "CurrentLockBagItem", _g_get_CurrentLockBagItem);
            XUtils.RegisterFunc(L, XUtils.GETTER_IDX, "StrengthInfos", _g_get_StrengthInfos);
            XUtils.RegisterFunc(L, XUtils.GETTER_IDX, "DecoratePosInfos", _g_get_DecoratePosInfos);
            XUtils.RegisterFunc(L, XUtils.GETTER_IDX, "GetSoulList", _g_get_GetSoulList);
            XUtils.RegisterFunc(L, XUtils.GETTER_IDX, "OpenSoulList", _g_get_OpenSoulList);
            XUtils.RegisterFunc(L, XUtils.GETTER_IDX, "BaptizeCount", _g_get_BaptizeCount);
            XUtils.RegisterFunc(L, XUtils.GETTER_IDX, "mCloseQuickUseGoodsIdArray", _g_get_mCloseQuickUseGoodsIdArray);
            XUtils.RegisterFunc(L, XUtils.GETTER_IDX, "mHaveCheckPos", _g_get_mHaveCheckPos);
            XUtils.RegisterFunc(L, XUtils.GETTER_IDX, "mIdInCurShortCutWin", _g_get_mIdInCurShortCutWin);
            
			XUtils.RegisterFunc(L, XUtils.SETTER_IDX, "BagGoodsOids", _s_set_BagGoodsOids);
            XUtils.RegisterFunc(L, XUtils.SETTER_IDX, "BagTypeIdAndOids", _s_set_BagTypeIdAndOids);
            XUtils.RegisterFunc(L, XUtils.SETTER_IDX, "BagPanelSort", _s_set_BagPanelSort);
            XUtils.RegisterFunc(L, XUtils.SETTER_IDX, "NeedUpdateBagIndexArray", _s_set_NeedUpdateBagIndexArray);
            XUtils.RegisterFunc(L, XUtils.SETTER_IDX, "WareHouseGoodsOids", _s_set_WareHouseGoodsOids);
            XUtils.RegisterFunc(L, XUtils.SETTER_IDX, "WareHouseTypeIdAndOids", _s_set_WareHouseTypeIdAndOids);
            XUtils.RegisterFunc(L, XUtils.SETTER_IDX, "WarePanelSort", _s_set_WarePanelSort);
            XUtils.RegisterFunc(L, XUtils.SETTER_IDX, "NeedUpdateWareIndexArray", _s_set_NeedUpdateWareIndexArray);
            XUtils.RegisterFunc(L, XUtils.SETTER_IDX, "TreasureHuntGoodsOids", _s_set_TreasureHuntGoodsOids);
            XUtils.RegisterFunc(L, XUtils.SETTER_IDX, "IDTreasureGoodsOids", _s_set_IDTreasureGoodsOids);
            XUtils.RegisterFunc(L, XUtils.SETTER_IDX, "HandbookGoodsOids", _s_set_HandbookGoodsOids);
            XUtils.RegisterFunc(L, XUtils.SETTER_IDX, "HandbookTypeIdAndOids", _s_set_HandbookTypeIdAndOids);
            XUtils.RegisterFunc(L, XUtils.SETTER_IDX, "SoulGoodsOids", _s_set_SoulGoodsOids);
            XUtils.RegisterFunc(L, XUtils.SETTER_IDX, "SoulTypeIdAndOids", _s_set_SoulTypeIdAndOids);
            XUtils.RegisterFunc(L, XUtils.SETTER_IDX, "DecorateGoodsOids", _s_set_DecorateGoodsOids);
            XUtils.RegisterFunc(L, XUtils.SETTER_IDX, "DecorateTypeIdAndOids", _s_set_DecorateTypeIdAndOids);
            XUtils.RegisterFunc(L, XUtils.SETTER_IDX, "MagicEquipGoodsOids", _s_set_MagicEquipGoodsOids);
            XUtils.RegisterFunc(L, XUtils.SETTER_IDX, "MagicEquipTypeIdAndOids", _s_set_MagicEquipTypeIdAndOids);
            XUtils.RegisterFunc(L, XUtils.SETTER_IDX, "InstallEquip", _s_set_InstallEquip);
            XUtils.RegisterFunc(L, XUtils.SETTER_IDX, "InstallGoodsSouls", _s_set_InstallGoodsSouls);
            XUtils.RegisterFunc(L, XUtils.SETTER_IDX, "WearingDecorate", _s_set_WearingDecorate);
            XUtils.RegisterFunc(L, XUtils.SETTER_IDX, "WearingMagicEquip", _s_set_WearingMagicEquip);
            XUtils.RegisterFunc(L, XUtils.SETTER_IDX, "EquipGoodsOid", _s_set_EquipGoodsOid);
            XUtils.RegisterFunc(L, XUtils.SETTER_IDX, "GoodsCd", _s_set_GoodsCd);
            XUtils.RegisterFunc(L, XUtils.SETTER_IDX, "InstallGodEquip", _s_set_InstallGodEquip);
            XUtils.RegisterFunc(L, XUtils.SETTER_IDX, "GodEquipGoodsOids", _s_set_GodEquipGoodsOids);
            XUtils.RegisterFunc(L, XUtils.SETTER_IDX, "InstallMountEquip", _s_set_InstallMountEquip);
            XUtils.RegisterFunc(L, XUtils.SETTER_IDX, "MountEquipGoodsOid", _s_set_MountEquipGoodsOid);
            XUtils.RegisterFunc(L, XUtils.SETTER_IDX, "MountEquipTypeIdAndOids", _s_set_MountEquipTypeIdAndOids);
            XUtils.RegisterFunc(L, XUtils.SETTER_IDX, "LightWeaponGoodsOids", _s_set_LightWeaponGoodsOids);
            XUtils.RegisterFunc(L, XUtils.SETTER_IDX, "InstalledLightWeaponSoul", _s_set_InstalledLightWeaponSoul);
            XUtils.RegisterFunc(L, XUtils.SETTER_IDX, "mBagInitCount", _s_set_mBagInitCount);
            XUtils.RegisterFunc(L, XUtils.SETTER_IDX, "mWareInitCount", _s_set_mWareInitCount);
            XUtils.RegisterFunc(L, XUtils.SETTER_IDX, "mBagMaxCount", _s_set_mBagMaxCount);
            XUtils.RegisterFunc(L, XUtils.SETTER_IDX, "mWareMaxCount", _s_set_mWareMaxCount);
            XUtils.RegisterFunc(L, XUtils.SETTER_IDX, "mBagTotalCount", _s_set_mBagTotalCount);
            XUtils.RegisterFunc(L, XUtils.SETTER_IDX, "mWareTotalCount", _s_set_mWareTotalCount);
            XUtils.RegisterFunc(L, XUtils.SETTER_IDX, "mSoulBagInitCount", _s_set_mSoulBagInitCount);
            XUtils.RegisterFunc(L, XUtils.SETTER_IDX, "mSoulBagTotalCount", _s_set_mSoulBagTotalCount);
            XUtils.RegisterFunc(L, XUtils.SETTER_IDX, "mSoulInstallInitCount", _s_set_mSoulInstallInitCount);
            XUtils.RegisterFunc(L, XUtils.SETTER_IDX, "mSoulInstallTotalCount", _s_set_mSoulInstallTotalCount);
            XUtils.RegisterFunc(L, XUtils.SETTER_IDX, "mHandbookBagInitCount", _s_set_mHandbookBagInitCount);
            XUtils.RegisterFunc(L, XUtils.SETTER_IDX, "mHandbookBagTotalCount", _s_set_mHandbookBagTotalCount);
            XUtils.RegisterFunc(L, XUtils.SETTER_IDX, "mDecorateBagInitCount", _s_set_mDecorateBagInitCount);
            XUtils.RegisterFunc(L, XUtils.SETTER_IDX, "mDecorateBagTotalCount", _s_set_mDecorateBagTotalCount);
            XUtils.RegisterFunc(L, XUtils.SETTER_IDX, "mMagicEquipBagInitCount", _s_set_mMagicEquipBagInitCount);
            XUtils.RegisterFunc(L, XUtils.SETTER_IDX, "mMagicEquipBagTotalCount", _s_set_mMagicEquipBagTotalCount);
            XUtils.RegisterFunc(L, XUtils.SETTER_IDX, "mGodEquipBagInitCount", _s_set_mGodEquipBagInitCount);
            XUtils.RegisterFunc(L, XUtils.SETTER_IDX, "mGodEquipBagTotalCount", _s_set_mGodEquipBagTotalCount);
            XUtils.RegisterFunc(L, XUtils.SETTER_IDX, "mMountEquipBagInitCount", _s_set_mMountEquipBagInitCount);
            XUtils.RegisterFunc(L, XUtils.SETTER_IDX, "mMountEquipBagTotalCount", _s_set_mMountEquipBagTotalCount);
            XUtils.RegisterFunc(L, XUtils.SETTER_IDX, "mLightWeaponSoulBagInitCount", _s_set_mLightWeaponSoulBagInitCount);
            XUtils.RegisterFunc(L, XUtils.SETTER_IDX, "mLightWeaponSoulBagTotalCount", _s_set_mLightWeaponSoulBagTotalCount);
            XUtils.RegisterFunc(L, XUtils.SETTER_IDX, "mLuckyTreasureBagMaxCount", _s_set_mLuckyTreasureBagMaxCount);
            XUtils.RegisterFunc(L, XUtils.SETTER_IDX, "isForceShowfloatTips", _s_set_isForceShowfloatTips);
            XUtils.RegisterFunc(L, XUtils.SETTER_IDX, "mIsAutoHp", _s_set_mIsAutoHp);
            XUtils.RegisterFunc(L, XUtils.SETTER_IDX, "mIsAutoMp", _s_set_mIsAutoMp);
            XUtils.RegisterFunc(L, XUtils.SETTER_IDX, "mIconConfig", _s_set_mIconConfig);
            XUtils.RegisterFunc(L, XUtils.SETTER_IDX, "CurrentLockBagItem", _s_set_CurrentLockBagItem);
            XUtils.RegisterFunc(L, XUtils.SETTER_IDX, "StrengthInfos", _s_set_StrengthInfos);
            XUtils.RegisterFunc(L, XUtils.SETTER_IDX, "DecoratePosInfos", _s_set_DecoratePosInfos);
            XUtils.RegisterFunc(L, XUtils.SETTER_IDX, "GetSoulList", _s_set_GetSoulList);
            XUtils.RegisterFunc(L, XUtils.SETTER_IDX, "OpenSoulList", _s_set_OpenSoulList);
            XUtils.RegisterFunc(L, XUtils.SETTER_IDX, "BaptizeCount", _s_set_BaptizeCount);
            XUtils.RegisterFunc(L, XUtils.SETTER_IDX, "mCloseQuickUseGoodsIdArray", _s_set_mCloseQuickUseGoodsIdArray);
            XUtils.RegisterFunc(L, XUtils.SETTER_IDX, "mHaveCheckPos", _s_set_mHaveCheckPos);
            XUtils.RegisterFunc(L, XUtils.SETTER_IDX, "mIdInCurShortCutWin", _s_set_mIdInCurShortCutWin);
            
			XUtils.EndObjectRegister(typeof(xc.ItemManager), L, translator, null, null,
			    null, null, null);

		    XUtils.BeginClassRegister(typeof(xc.ItemManager), L, __CreateInstance, 2, 1, 0);
			XUtils.RegisterFunc(L, XUtils.CLS_IDX, "GetInstance", _m_GetInstance_xlua_st_);
            
			
            
            XUtils.RegisterObject(L, translator, XUtils.CLS_IDX, "UnderlyingSystemType", typeof(xc.ItemManager));
			XUtils.RegisterFunc(L, XUtils.CLS_GETTER_IDX, "Instance", _g_get_Instance);
            
			
			XUtils.EndClassRegister(typeof(xc.ItemManager), L, translator);
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int __CreateInstance(RealStatePtr L)
        {
            return LuaAPI.luaL_error(L, "xc.ItemManager does not have a constructor!");
        }
        
		
        
		
        
        
        
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_GetInstance_xlua_st_(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            
            try {
                
                {
                    
                        xc.ItemManager __cl_gen_ret = xc.ItemManager.GetInstance(  );
                        translator.Push(L, __cl_gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_GetGoodsForAllByOId(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            xc.ItemManager __cl_gen_to_be_invoked = (xc.ItemManager)translator.FastGetCSObj(L, 1);
            
            
            try {
                
                {
                    ulong oid = LuaAPI.lua_touint64(L, 2);
                    
                        xc.Goods __cl_gen_ret = __cl_gen_to_be_invoked.GetGoodsForAllByOId( oid );
                        translator.Push(L, __cl_gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_GetGoodsForBagByOId(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            xc.ItemManager __cl_gen_to_be_invoked = (xc.ItemManager)translator.FastGetCSObj(L, 1);
            
            
            try {
                
                {
                    ulong oid = LuaAPI.lua_touint64(L, 2);
                    
                        xc.Goods __cl_gen_ret = __cl_gen_to_be_invoked.GetGoodsForBagByOId( oid );
                        translator.Push(L, __cl_gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_HasGoods(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            xc.ItemManager __cl_gen_to_be_invoked = (xc.ItemManager)translator.FastGetCSObj(L, 1);
            
            
            try {
                
                {
                    ulong oid = LuaAPI.lua_touint64(L, 2);
                    
                        bool __cl_gen_ret = __cl_gen_to_be_invoked.HasGoods( oid );
                        LuaAPI.lua_pushboolean(L, __cl_gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_GetGoodsNumForBagByTypeId(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            xc.ItemManager __cl_gen_to_be_invoked = (xc.ItemManager)translator.FastGetCSObj(L, 1);
            
            
            try {
                
                {
                    uint eid = LuaAPI.xlua_touint(L, 2);
                    
                        ulong __cl_gen_ret = __cl_gen_to_be_invoked.GetGoodsNumForBagByTypeId( eid );
                        LuaAPI.lua_pushuint64(L, __cl_gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_GetGoodsNumForBag(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            xc.ItemManager __cl_gen_to_be_invoked = (xc.ItemManager)translator.FastGetCSObj(L, 1);
            
            
            try {
                
                {
                    ulong oid = LuaAPI.lua_touint64(L, 2);
                    
                        ulong __cl_gen_ret = __cl_gen_to_be_invoked.GetGoodsNumForBag( oid );
                        LuaAPI.lua_pushuint64(L, __cl_gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_GetGoodsNumForMountEquipBagByTypeId(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            xc.ItemManager __cl_gen_to_be_invoked = (xc.ItemManager)translator.FastGetCSObj(L, 1);
            
            
            try {
                
                {
                    uint eid = LuaAPI.xlua_touint(L, 2);
                    
                        ulong __cl_gen_ret = __cl_gen_to_be_invoked.GetGoodsNumForMountEquipBagByTypeId( eid );
                        LuaAPI.lua_pushuint64(L, __cl_gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_GetGoodsNumFromSoulBagAndBodyByTypeId(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            xc.ItemManager __cl_gen_to_be_invoked = (xc.ItemManager)translator.FastGetCSObj(L, 1);
            
            
            try {
                
                {
                    uint type_idx = LuaAPI.xlua_touint(L, 2);
                    
                        ulong __cl_gen_ret = __cl_gen_to_be_invoked.GetGoodsNumFromSoulBagAndBodyByTypeId( type_idx );
                        LuaAPI.lua_pushuint64(L, __cl_gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_GetGoodsNumFromHandbookBagAndBodyByTypeId(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            xc.ItemManager __cl_gen_to_be_invoked = (xc.ItemManager)translator.FastGetCSObj(L, 1);
            
            
            try {
                
                {
                    uint eid = LuaAPI.xlua_touint(L, 2);
                    
                        ulong __cl_gen_ret = __cl_gen_to_be_invoked.GetGoodsNumFromHandbookBagAndBodyByTypeId( eid );
                        LuaAPI.lua_pushuint64(L, __cl_gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_GetHandbookListForBagByTypeId(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            xc.ItemManager __cl_gen_to_be_invoked = (xc.ItemManager)translator.FastGetCSObj(L, 1);
            
            
            try {
                
                {
                    uint eid = LuaAPI.xlua_touint(L, 2);
                    
                        System.Collections.Generic.Dictionary<ulong, xc.Goods> __cl_gen_ret = __cl_gen_to_be_invoked.GetHandbookListForBagByTypeId( eid );
                        translator.Push(L, __cl_gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_ExistGoods(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            xc.ItemManager __cl_gen_to_be_invoked = (xc.ItemManager)translator.FastGetCSObj(L, 1);
            
            
            try {
                
                {
                    uint type_id = LuaAPI.xlua_touint(L, 2);
                    
                        bool __cl_gen_ret = __cl_gen_to_be_invoked.ExistGoods( type_id );
                        LuaAPI.lua_pushboolean(L, __cl_gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_GetGoodsUnbindNumForBagByTypeId(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            xc.ItemManager __cl_gen_to_be_invoked = (xc.ItemManager)translator.FastGetCSObj(L, 1);
            
            
            try {
                
                {
                    uint eid = LuaAPI.xlua_touint(L, 2);
                    
                        ulong __cl_gen_ret = __cl_gen_to_be_invoked.GetGoodsUnbindNumForBagByTypeId( eid );
                        LuaAPI.lua_pushuint64(L, __cl_gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_IsHaveBindGoodsByTypeId(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            xc.ItemManager __cl_gen_to_be_invoked = (xc.ItemManager)translator.FastGetCSObj(L, 1);
            
            
            try {
                
                {
                    uint eid = LuaAPI.xlua_touint(L, 2);
                    
                        bool __cl_gen_ret = __cl_gen_to_be_invoked.IsHaveBindGoodsByTypeId( eid );
                        LuaAPI.lua_pushboolean(L, __cl_gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_OpenSoul(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            xc.ItemManager __cl_gen_to_be_invoked = (xc.ItemManager)translator.FastGetCSObj(L, 1);
            
            
            try {
                
                {
                    uint id = LuaAPI.xlua_touint(L, 2);
                    
                    __cl_gen_to_be_invoked.OpenSoul( id );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_SendSoulUpLv(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            xc.ItemManager __cl_gen_to_be_invoked = (xc.ItemManager)translator.FastGetCSObj(L, 1);
            
            
            try {
                
                {
                    ulong oid = LuaAPI.lua_touint64(L, 2);
                    
                    __cl_gen_to_be_invoked.SendSoulUpLv( oid );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_SendInstallSoul(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            xc.ItemManager __cl_gen_to_be_invoked = (xc.ItemManager)translator.FastGetCSObj(L, 1);
            
            
            try {
                
                {
                    ulong oid = LuaAPI.lua_touint64(L, 2);
                    uint holeId = LuaAPI.xlua_touint(L, 3);
                    
                    __cl_gen_to_be_invoked.SendInstallSoul( oid, holeId );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_SendResolveSoul(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            xc.ItemManager __cl_gen_to_be_invoked = (xc.ItemManager)translator.FastGetCSObj(L, 1);
            
            
            try {
                
                {
                    ulong[] oids = (ulong[])translator.GetObject(L, 2, typeof(ulong[]));
                    
                    __cl_gen_to_be_invoked.SendResolveSoul( oids );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_ExistSoul(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            xc.ItemManager __cl_gen_to_be_invoked = (xc.ItemManager)translator.FastGetCSObj(L, 1);
            
            
            try {
                
                {
                    uint type_id = LuaAPI.xlua_touint(L, 2);
                    
                        bool __cl_gen_ret = __cl_gen_to_be_invoked.ExistSoul( type_id );
                        LuaAPI.lua_pushboolean(L, __cl_gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_GetGoodsListBySubType(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            xc.ItemManager __cl_gen_to_be_invoked = (xc.ItemManager)translator.FastGetCSObj(L, 1);
            
            
            try {
                
                {
                    uint mainType = LuaAPI.xlua_touint(L, 2);
                    ushort subtype = (ushort)LuaAPI.xlua_tointeger(L, 3);
                    
                        System.Collections.Generic.List<xc.Goods> __cl_gen_ret = __cl_gen_to_be_invoked.GetGoodsListBySubType( mainType, subtype );
                        translator.Push(L, __cl_gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_GetGoodsListForBagByTypeId(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            xc.ItemManager __cl_gen_to_be_invoked = (xc.ItemManager)translator.FastGetCSObj(L, 1);
            
            
            try {
                
                {
                    uint eid = LuaAPI.xlua_touint(L, 2);
                    
                        System.Collections.Generic.Dictionary<ulong, xc.Goods> __cl_gen_ret = __cl_gen_to_be_invoked.GetGoodsListForBagByTypeId( eid );
                        translator.Push(L, __cl_gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_GetEmptyItemCount(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            xc.ItemManager __cl_gen_to_be_invoked = (xc.ItemManager)translator.FastGetCSObj(L, 1);
            
            
            try {
                
                {
                    
                        uint __cl_gen_ret = __cl_gen_to_be_invoked.GetEmptyItemCount(  );
                        LuaAPI.xlua_pushuint(L, __cl_gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_BagIsFull(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            xc.ItemManager __cl_gen_to_be_invoked = (xc.ItemManager)translator.FastGetCSObj(L, 1);
            
            
			int __gen_param_count = LuaAPI.lua_gettop(L);
            
            try {
                if(__gen_param_count == 3&& LuaTypes.LUA_TNUMBER == LuaAPI.lua_type(L, 2)&& LuaTypes.LUA_TNUMBER == LuaAPI.lua_type(L, 3)) 
                {
                    uint num = LuaAPI.xlua_touint(L, 2);
                    uint giveTpye = LuaAPI.xlua_touint(L, 3);
                    
                        bool __cl_gen_ret = __cl_gen_to_be_invoked.BagIsFull( num, giveTpye );
                        LuaAPI.lua_pushboolean(L, __cl_gen_ret);
                    
                    
                    
                    return 1;
                }
                if(__gen_param_count == 2&& LuaTypes.LUA_TNUMBER == LuaAPI.lua_type(L, 2)) 
                {
                    uint num = LuaAPI.xlua_touint(L, 2);
                    
                        bool __cl_gen_ret = __cl_gen_to_be_invoked.BagIsFull( num );
                        LuaAPI.lua_pushboolean(L, __cl_gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
            return LuaAPI.luaL_error(L, "invalid arguments to xc.ItemManager.BagIsFull!");
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_GetBagEquipByPos(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            xc.ItemManager __cl_gen_to_be_invoked = (xc.ItemManager)translator.FastGetCSObj(L, 1);
            
            
            try {
                
                {
                    uint pos = LuaAPI.xlua_touint(L, 2);
                    
                        System.Collections.Generic.List<xc.GoodsEquip> __cl_gen_ret = __cl_gen_to_be_invoked.GetBagEquipByPos( pos );
                        translator.Push(L, __cl_gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_GetEquipCount(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            xc.ItemManager __cl_gen_to_be_invoked = (xc.ItemManager)translator.FastGetCSObj(L, 1);
            
            
            try {
                
                {
                    uint gid = LuaAPI.xlua_touint(L, 2);
                    uint quality = LuaAPI.xlua_touint(L, 3);
                    
                        uint __cl_gen_ret = __cl_gen_to_be_invoked.GetEquipCount( gid, quality );
                        LuaAPI.xlua_pushuint(L, __cl_gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_Reset(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            xc.ItemManager __cl_gen_to_be_invoked = (xc.ItemManager)translator.FastGetCSObj(L, 1);
            
            
            try {
                
                {
                    bool ignore_reconnect = LuaAPI.lua_toboolean(L, 2);
                    
                    __cl_gen_to_be_invoked.Reset( ignore_reconnect );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_EquipSuitForge(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            xc.ItemManager __cl_gen_to_be_invoked = (xc.ItemManager)translator.FastGetCSObj(L, 1);
            
            
            try {
                
                {
                    uint pos = LuaAPI.xlua_touint(L, 2);
                    uint index = LuaAPI.xlua_touint(L, 3);
                    
                    __cl_gen_to_be_invoked.EquipSuitForge( pos, index );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_EquipSuitRefine(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            xc.ItemManager __cl_gen_to_be_invoked = (xc.ItemManager)translator.FastGetCSObj(L, 1);
            
            
            try {
                
                {
                    uint pos = LuaAPI.xlua_touint(L, 2);
                    uint index = LuaAPI.xlua_touint(L, 3);
                    
                    __cl_gen_to_be_invoked.EquipSuitRefine( pos, index );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_EquipBaptizeLock(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            xc.ItemManager __cl_gen_to_be_invoked = (xc.ItemManager)translator.FastGetCSObj(L, 1);
            
            
            try {
                
                {
                    uint pos = LuaAPI.xlua_touint(L, 2);
                    uint index = LuaAPI.xlua_touint(L, 3);
                    uint id = LuaAPI.xlua_touint(L, 4);
                    
                    __cl_gen_to_be_invoked.EquipBaptizeLock( pos, index, id );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_EquipBaptizeOpen(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            xc.ItemManager __cl_gen_to_be_invoked = (xc.ItemManager)translator.FastGetCSObj(L, 1);
            
            
            try {
                
                {
                    uint pos = LuaAPI.xlua_touint(L, 2);
                    uint index = LuaAPI.xlua_touint(L, 3);
                    uint id = LuaAPI.xlua_touint(L, 4);
                    
                    __cl_gen_to_be_invoked.EquipBaptizeOpen( pos, index, id );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_EquipBaptize(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            xc.ItemManager __cl_gen_to_be_invoked = (xc.ItemManager)translator.FastGetCSObj(L, 1);
            
            
            try {
                
                {
                    uint pos = LuaAPI.xlua_touint(L, 2);
                    uint index = LuaAPI.xlua_touint(L, 3);
                    uint type = LuaAPI.xlua_touint(L, 4);
                    
                    __cl_gen_to_be_invoked.EquipBaptize( pos, index, type );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_EquipInstallGem(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            xc.ItemManager __cl_gen_to_be_invoked = (xc.ItemManager)translator.FastGetCSObj(L, 1);
            
            
			int __gen_param_count = LuaAPI.lua_gettop(L);
            
            try {
                if(__gen_param_count == 7&& LuaTypes.LUA_TNUMBER == LuaAPI.lua_type(L, 2)&& LuaTypes.LUA_TNUMBER == LuaAPI.lua_type(L, 3)&& LuaTypes.LUA_TNUMBER == LuaAPI.lua_type(L, 4)&& LuaTypes.LUA_TNUMBER == LuaAPI.lua_type(L, 5)&& LuaTypes.LUA_TNUMBER == LuaAPI.lua_type(L, 6)&& (LuaTypes.LUA_TNUMBER == LuaAPI.lua_type(L, 7) || LuaAPI.lua_isuint64(L, 7))) 
                {
                    uint pos = LuaAPI.xlua_touint(L, 2);
                    uint index = LuaAPI.xlua_touint(L, 3);
                    uint holeId = LuaAPI.xlua_touint(L, 4);
                    uint gemGid = LuaAPI.xlua_touint(L, 5);
                    uint autBuy = LuaAPI.xlua_touint(L, 6);
                    ulong oid = LuaAPI.lua_touint64(L, 7);
                    
                    __cl_gen_to_be_invoked.EquipInstallGem( pos, index, holeId, gemGid, autBuy, oid );
                    
                    
                    
                    return 0;
                }
                if(__gen_param_count == 6&& LuaTypes.LUA_TNUMBER == LuaAPI.lua_type(L, 2)&& LuaTypes.LUA_TNUMBER == LuaAPI.lua_type(L, 3)&& LuaTypes.LUA_TNUMBER == LuaAPI.lua_type(L, 4)&& LuaTypes.LUA_TNUMBER == LuaAPI.lua_type(L, 5)&& LuaTypes.LUA_TNUMBER == LuaAPI.lua_type(L, 6)) 
                {
                    uint pos = LuaAPI.xlua_touint(L, 2);
                    uint index = LuaAPI.xlua_touint(L, 3);
                    uint holeId = LuaAPI.xlua_touint(L, 4);
                    uint gemGid = LuaAPI.xlua_touint(L, 5);
                    uint autBuy = LuaAPI.xlua_touint(L, 6);
                    
                    __cl_gen_to_be_invoked.EquipInstallGem( pos, index, holeId, gemGid, autBuy );
                    
                    
                    
                    return 0;
                }
                if(__gen_param_count == 5&& LuaTypes.LUA_TNUMBER == LuaAPI.lua_type(L, 2)&& LuaTypes.LUA_TNUMBER == LuaAPI.lua_type(L, 3)&& LuaTypes.LUA_TNUMBER == LuaAPI.lua_type(L, 4)&& LuaTypes.LUA_TNUMBER == LuaAPI.lua_type(L, 5)) 
                {
                    uint pos = LuaAPI.xlua_touint(L, 2);
                    uint index = LuaAPI.xlua_touint(L, 3);
                    uint holeId = LuaAPI.xlua_touint(L, 4);
                    uint gemGid = LuaAPI.xlua_touint(L, 5);
                    
                    __cl_gen_to_be_invoked.EquipInstallGem( pos, index, holeId, gemGid );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
            return LuaAPI.luaL_error(L, "invalid arguments to xc.ItemManager.EquipInstallGem!");
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_EquipUnInstallGem(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            xc.ItemManager __cl_gen_to_be_invoked = (xc.ItemManager)translator.FastGetCSObj(L, 1);
            
            
            try {
                
                {
                    uint pos = LuaAPI.xlua_touint(L, 2);
                    uint index = LuaAPI.xlua_touint(L, 3);
                    uint holeId = LuaAPI.xlua_touint(L, 4);
                    
                    __cl_gen_to_be_invoked.EquipUnInstallGem( pos, index, holeId );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_UseGoods(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            xc.ItemManager __cl_gen_to_be_invoked = (xc.ItemManager)translator.FastGetCSObj(L, 1);
            
            
			int __gen_param_count = LuaAPI.lua_gettop(L);
            
            try {
                if(__gen_param_count >= 4&& LuaTypes.LUA_TNUMBER == LuaAPI.lua_type(L, 2)&& LuaTypes.LUA_TNUMBER == LuaAPI.lua_type(L, 3)&& (LuaTypes.LUA_TNUMBER == LuaAPI.lua_type(L, 4) || LuaAPI.lua_isuint64(L, 4))&& (LuaTypes.LUA_TNONE == LuaAPI.lua_type(L, 5) || LuaTypes.LUA_TNUMBER == LuaAPI.lua_type(L, 5))) 
                {
                    uint gid = LuaAPI.xlua_touint(L, 2);
                    uint num = LuaAPI.xlua_touint(L, 3);
                    ulong oid = LuaAPI.lua_touint64(L, 4);
                    uint[] args = translator.GetParams<uint>(L, 5);
                    
                    __cl_gen_to_be_invoked.UseGoods( gid, num, oid, args );
                    
                    
                    
                    return 0;
                }
                if(__gen_param_count >= 3&& LuaTypes.LUA_TNUMBER == LuaAPI.lua_type(L, 2)&& LuaTypes.LUA_TNUMBER == LuaAPI.lua_type(L, 3)&& (LuaTypes.LUA_TNUMBER == LuaAPI.lua_type(L, 4) || LuaAPI.lua_isuint64(L, 4))) 
                {
                    uint gid = LuaAPI.xlua_touint(L, 2);
                    uint num = LuaAPI.xlua_touint(L, 3);
                    ulong oid = LuaAPI.lua_touint64(L, 4);
                    
                    __cl_gen_to_be_invoked.UseGoods( gid, num, oid );
                    
                    
                    
                    return 0;
                }
                if(__gen_param_count >= 2&& LuaTypes.LUA_TNUMBER == LuaAPI.lua_type(L, 2)&& LuaTypes.LUA_TNUMBER == LuaAPI.lua_type(L, 3)) 
                {
                    uint gid = LuaAPI.xlua_touint(L, 2);
                    uint num = LuaAPI.xlua_touint(L, 3);
                    
                    __cl_gen_to_be_invoked.UseGoods( gid, num );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
            return LuaAPI.luaL_error(L, "invalid arguments to xc.ItemManager.UseGoods!");
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_RecycleGoods(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            xc.ItemManager __cl_gen_to_be_invoked = (xc.ItemManager)translator.FastGetCSObj(L, 1);
            
            
			int __gen_param_count = LuaAPI.lua_gettop(L);
            
            try {
                if(__gen_param_count == 3&& translator.Assignable<System.Collections.Generic.List<ulong>>(L, 2)&& LuaTypes.LUA_TNUMBER == LuaAPI.lua_type(L, 3)) 
                {
                    System.Collections.Generic.List<ulong> oids = (System.Collections.Generic.List<ulong>)translator.GetObject(L, 2, typeof(System.Collections.Generic.List<ulong>));
                    uint type = LuaAPI.xlua_touint(L, 3);
                    
                    __cl_gen_to_be_invoked.RecycleGoods( oids, type );
                    
                    
                    
                    return 0;
                }
                if(__gen_param_count == 2&& translator.Assignable<System.Collections.Generic.List<ulong>>(L, 2)) 
                {
                    System.Collections.Generic.List<ulong> oids = (System.Collections.Generic.List<ulong>)translator.GetObject(L, 2, typeof(System.Collections.Generic.List<ulong>));
                    
                    __cl_gen_to_be_invoked.RecycleGoods( oids );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
            return LuaAPI.luaL_error(L, "invalid arguments to xc.ItemManager.RecycleGoods!");
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_SubmitGoods(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            xc.ItemManager __cl_gen_to_be_invoked = (xc.ItemManager)translator.FastGetCSObj(L, 1);
            
            
            try {
                
                {
                    ulong oid = LuaAPI.lua_touint64(L, 2);
                    
                    __cl_gen_to_be_invoked.SubmitGoods( oid );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_ComposeGoods(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            xc.ItemManager __cl_gen_to_be_invoked = (xc.ItemManager)translator.FastGetCSObj(L, 1);
            
            
            try {
                
                {
                    uint gid = LuaAPI.xlua_touint(L, 2);
                    uint num = LuaAPI.xlua_touint(L, 3);
                    
                    __cl_gen_to_be_invoked.ComposeGoods( gid, num );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_StrengthEquip(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            xc.ItemManager __cl_gen_to_be_invoked = (xc.ItemManager)translator.FastGetCSObj(L, 1);
            
            
            try {
                
                {
                    uint pos = LuaAPI.xlua_touint(L, 2);
                    uint index = LuaAPI.xlua_touint(L, 3);
                    
                    __cl_gen_to_be_invoked.StrengthEquip( pos, index );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_SellGoods(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            xc.ItemManager __cl_gen_to_be_invoked = (xc.ItemManager)translator.FastGetCSObj(L, 1);
            
            
			int __gen_param_count = LuaAPI.lua_gettop(L);
            
            try {
                if(__gen_param_count == 4&& (LuaTypes.LUA_TNUMBER == LuaAPI.lua_type(L, 2) || LuaAPI.lua_isuint64(L, 2))&& LuaTypes.LUA_TNUMBER == LuaAPI.lua_type(L, 3)&& LuaTypes.LUA_TNUMBER == LuaAPI.lua_type(L, 4)) 
                {
                    ulong oid = LuaAPI.lua_touint64(L, 2);
                    uint num = LuaAPI.xlua_touint(L, 3);
                    uint bag_type = LuaAPI.xlua_touint(L, 4);
                    
                    __cl_gen_to_be_invoked.SellGoods( oid, num, bag_type );
                    
                    
                    
                    return 0;
                }
                if(__gen_param_count == 3&& (LuaTypes.LUA_TNUMBER == LuaAPI.lua_type(L, 2) || LuaAPI.lua_isuint64(L, 2))&& LuaTypes.LUA_TNUMBER == LuaAPI.lua_type(L, 3)) 
                {
                    ulong oid = LuaAPI.lua_touint64(L, 2);
                    uint num = LuaAPI.xlua_touint(L, 3);
                    
                    __cl_gen_to_be_invoked.SellGoods( oid, num );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
            return LuaAPI.luaL_error(L, "invalid arguments to xc.ItemManager.SellGoods!");
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_CommonInstall(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            xc.ItemManager __cl_gen_to_be_invoked = (xc.ItemManager)translator.FastGetCSObj(L, 1);
            
            
			int __gen_param_count = LuaAPI.lua_gettop(L);
            
            try {
                if(__gen_param_count == 5&& LuaTypes.LUA_TNUMBER == LuaAPI.lua_type(L, 2)&& LuaTypes.LUA_TNUMBER == LuaAPI.lua_type(L, 3)&& (LuaTypes.LUA_TNUMBER == LuaAPI.lua_type(L, 4) || LuaAPI.lua_isuint64(L, 4))&& LuaTypes.LUA_TNUMBER == LuaAPI.lua_type(L, 5)) 
                {
                    uint fromBag = LuaAPI.xlua_touint(L, 2);
                    uint toBag = LuaAPI.xlua_touint(L, 3);
                    ulong oid = LuaAPI.lua_touint64(L, 4);
                    uint installIdx = LuaAPI.xlua_touint(L, 5);
                    
                    __cl_gen_to_be_invoked.CommonInstall( fromBag, toBag, oid, installIdx );
                    
                    
                    
                    return 0;
                }
                if(__gen_param_count == 5&& LuaTypes.LUA_TNUMBER == LuaAPI.lua_type(L, 2)&& LuaTypes.LUA_TNUMBER == LuaAPI.lua_type(L, 3)&& translator.Assignable<xc.GoodsEquip>(L, 4)&& LuaTypes.LUA_TNUMBER == LuaAPI.lua_type(L, 5)) 
                {
                    uint fromBag = LuaAPI.xlua_touint(L, 2);
                    uint toBag = LuaAPI.xlua_touint(L, 3);
                    xc.GoodsEquip equip = (xc.GoodsEquip)translator.GetObject(L, 4, typeof(xc.GoodsEquip));
                    uint installIdx = LuaAPI.xlua_touint(L, 5);
                    
                    __cl_gen_to_be_invoked.CommonInstall( fromBag, toBag, equip, installIdx );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
            return LuaAPI.luaL_error(L, "invalid arguments to xc.ItemManager.CommonInstall!");
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_CheckQuickUnLock(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            xc.ItemManager __cl_gen_to_be_invoked = (xc.ItemManager)translator.FastGetCSObj(L, 1);
            
            
            try {
                
                {
                    ushort bag_type = (ushort)LuaAPI.xlua_tointeger(L, 2);
                    
                        bool __cl_gen_ret = __cl_gen_to_be_invoked.CheckQuickUnLock( bag_type );
                        LuaAPI.lua_pushboolean(L, __cl_gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_IsBetterBagEquip(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            xc.ItemManager __cl_gen_to_be_invoked = (xc.ItemManager)translator.FastGetCSObj(L, 1);
            
            
            try {
                
                {
                    xc.GoodsEquip equip = (xc.GoodsEquip)translator.GetObject(L, 2, typeof(xc.GoodsEquip));
                    
                        bool __cl_gen_ret = __cl_gen_to_be_invoked.IsBetterBagEquip( equip );
                        LuaAPI.lua_pushboolean(L, __cl_gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_GetBetterBagEquip(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            xc.ItemManager __cl_gen_to_be_invoked = (xc.ItemManager)translator.FastGetCSObj(L, 1);
            
            
            try {
                
                {
                    
                        xc.GoodsEquip __cl_gen_ret = __cl_gen_to_be_invoked.GetBetterBagEquip(  );
                        translator.Push(L, __cl_gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_GetCanUseGoods(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            xc.ItemManager __cl_gen_to_be_invoked = (xc.ItemManager)translator.FastGetCSObj(L, 1);
            
            
            try {
                
                {
                    
                        xc.GoodsItem __cl_gen_ret = __cl_gen_to_be_invoked.GetCanUseGoods(  );
                        translator.Push(L, __cl_gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_CheckBagCanQuickUse(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            xc.ItemManager __cl_gen_to_be_invoked = (xc.ItemManager)translator.FastGetCSObj(L, 1);
            
            
            try {
                
                {
                    
                        bool __cl_gen_ret = __cl_gen_to_be_invoked.CheckBagCanQuickUse(  );
                        LuaAPI.lua_pushboolean(L, __cl_gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_GetShowItem(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            xc.ItemManager __cl_gen_to_be_invoked = (xc.ItemManager)translator.FastGetCSObj(L, 1);
            
            
            try {
                
                {
                    
                        xc.GoodsItem __cl_gen_ret = __cl_gen_to_be_invoked.GetShowItem(  );
                        translator.Push(L, __cl_gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_CanShowQuickUseWindow(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            xc.ItemManager __cl_gen_to_be_invoked = (xc.ItemManager)translator.FastGetCSObj(L, 1);
            
            
            try {
                
                {
                    
                        bool __cl_gen_ret = __cl_gen_to_be_invoked.CanShowQuickUseWindow(  );
                        LuaAPI.lua_pushboolean(L, __cl_gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_IsBetterBagGoods(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            xc.ItemManager __cl_gen_to_be_invoked = (xc.ItemManager)translator.FastGetCSObj(L, 1);
            
            
            try {
                
                {
                    xc.GoodsItem goods = (xc.GoodsItem)translator.GetObject(L, 2, typeof(xc.GoodsItem));
                    
                        bool __cl_gen_ret = __cl_gen_to_be_invoked.IsBetterBagGoods( goods );
                        LuaAPI.lua_pushboolean(L, __cl_gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_IsBetterThanBody(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            xc.ItemManager __cl_gen_to_be_invoked = (xc.ItemManager)translator.FastGetCSObj(L, 1);
            
            
            try {
                
                {
                    xc.Goods addGoods = (xc.Goods)translator.GetObject(L, 2, typeof(xc.Goods));
                    
                        bool __cl_gen_ret = __cl_gen_to_be_invoked.IsBetterThanBody( addGoods );
                        LuaAPI.lua_pushboolean(L, __cl_gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_GetBayTypeByGoods(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            xc.ItemManager __cl_gen_to_be_invoked = (xc.ItemManager)translator.FastGetCSObj(L, 1);
            
            
            try {
                
                {
                    xc.Goods addGoods = (xc.Goods)translator.GetObject(L, 2, typeof(xc.Goods));
                    
                        uint __cl_gen_ret = __cl_gen_to_be_invoked.GetBayTypeByGoods( addGoods );
                        LuaAPI.xlua_pushuint(L, __cl_gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_CheckBagCanQuickUse_addGoods(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            xc.ItemManager __cl_gen_to_be_invoked = (xc.ItemManager)translator.FastGetCSObj(L, 1);
            
            
            try {
                
                {
                    xc.Goods addGoods = (xc.Goods)translator.GetObject(L, 2, typeof(xc.Goods));
                    
                    __cl_gen_to_be_invoked.CheckBagCanQuickUse_addGoods( addGoods );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_CheckBagCanQuickUse_ConsumeBox(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            xc.ItemManager __cl_gen_to_be_invoked = (xc.ItemManager)translator.FastGetCSObj(L, 1);
            
            
            try {
                
                {
                    xc.Goods goods = (xc.Goods)translator.GetObject(L, 2, typeof(xc.Goods));
                    
                        bool __cl_gen_ret = __cl_gen_to_be_invoked.CheckBagCanQuickUse_ConsumeBox( goods );
                        LuaAPI.lua_pushboolean(L, __cl_gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_BagTransport(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            xc.ItemManager __cl_gen_to_be_invoked = (xc.ItemManager)translator.FastGetCSObj(L, 1);
            
            
            try {
                
                {
                    uint from = LuaAPI.xlua_touint(L, 2);
                    uint to = LuaAPI.xlua_touint(L, 3);
                    ulong oid = LuaAPI.lua_touint64(L, 4);
                    uint num = LuaAPI.xlua_touint(L, 5);
                    
                    __cl_gen_to_be_invoked.BagTransport( from, to, oid, num );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_SendAddBagPage(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            xc.ItemManager __cl_gen_to_be_invoked = (xc.ItemManager)translator.FastGetCSObj(L, 1);
            
            
			int __gen_param_count = LuaAPI.lua_gettop(L);
            
            try {
                if(__gen_param_count == 4&& LuaTypes.LUA_TNUMBER == LuaAPI.lua_type(L, 2)&& LuaTypes.LUA_TNUMBER == LuaAPI.lua_type(L, 3)&& LuaTypes.LUA_TBOOLEAN == LuaAPI.lua_type(L, 4)) 
                {
                    uint idx = LuaAPI.xlua_touint(L, 2);
                    ushort bag_type = (ushort)LuaAPI.xlua_tointeger(L, 3);
                    bool auto_buy = LuaAPI.lua_toboolean(L, 4);
                    
                    __cl_gen_to_be_invoked.SendAddBagPage( idx, bag_type, auto_buy );
                    
                    
                    
                    return 0;
                }
                if(__gen_param_count == 3&& LuaTypes.LUA_TNUMBER == LuaAPI.lua_type(L, 2)&& LuaTypes.LUA_TNUMBER == LuaAPI.lua_type(L, 3)) 
                {
                    uint idx = LuaAPI.xlua_touint(L, 2);
                    ushort bag_type = (ushort)LuaAPI.xlua_tointeger(L, 3);
                    
                    __cl_gen_to_be_invoked.SendAddBagPage( idx, bag_type );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
            return LuaAPI.luaL_error(L, "invalid arguments to xc.ItemManager.SendAddBagPage!");
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_SendBagGoodsListByType(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            xc.ItemManager __cl_gen_to_be_invoked = (xc.ItemManager)translator.FastGetCSObj(L, 1);
            
            
            try {
                
                {
                    uint _type = LuaAPI.xlua_touint(L, 2);
                    
                    __cl_gen_to_be_invoked.SendBagGoodsListByType( _type );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_SendOpenWare(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            xc.ItemManager __cl_gen_to_be_invoked = (xc.ItemManager)translator.FastGetCSObj(L, 1);
            
            
            try {
                
                {
                    
                    __cl_gen_to_be_invoked.SendOpenWare(  );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_RegisterAllMessage(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            xc.ItemManager __cl_gen_to_be_invoked = (xc.ItemManager)translator.FastGetCSObj(L, 1);
            
            
            try {
                
                {
                    
                    __cl_gen_to_be_invoked.RegisterAllMessage(  );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_HasUseTimesByGid(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            xc.ItemManager __cl_gen_to_be_invoked = (xc.ItemManager)translator.FastGetCSObj(L, 1);
            
            
            try {
                
                {
                    uint gid = LuaAPI.xlua_touint(L, 2);
                    
                        uint __cl_gen_ret = __cl_gen_to_be_invoked.HasUseTimesByGid( gid );
                        LuaAPI.xlua_pushuint(L, __cl_gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_UpdateEquipRefreshTime(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            xc.ItemManager __cl_gen_to_be_invoked = (xc.ItemManager)translator.FastGetCSObj(L, 1);
            
            
            try {
                
                {
                    uint equip_pos = LuaAPI.xlua_touint(L, 2);
                    
                    __cl_gen_to_be_invoked.UpdateEquipRefreshTime( equip_pos );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_DelGoods(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            xc.ItemManager __cl_gen_to_be_invoked = (xc.ItemManager)translator.FastGetCSObj(L, 1);
            
            
            try {
                
                {
                    
                    __cl_gen_to_be_invoked.DelGoods(  );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_SortBagData(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            xc.ItemManager __cl_gen_to_be_invoked = (xc.ItemManager)translator.FastGetCSObj(L, 1);
            
            
            try {
                
                {
                    
                    __cl_gen_to_be_invoked.SortBagData(  );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_DelGoodsToPanelSort(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            xc.ItemManager __cl_gen_to_be_invoked = (xc.ItemManager)translator.FastGetCSObj(L, 1);
            
            
            try {
                
                {
                    System.Collections.Generic.List<xc.Goods> panel_sort = (System.Collections.Generic.List<xc.Goods>)translator.GetObject(L, 2, typeof(System.Collections.Generic.List<xc.Goods>));
                    System.Collections.Generic.List<int> index_array = (System.Collections.Generic.List<int>)translator.GetObject(L, 3, typeof(System.Collections.Generic.List<int>));
                    
                    __cl_gen_to_be_invoked.DelGoodsToPanelSort( ref panel_sort, ref index_array );
                    translator.Push(L, panel_sort);
                        
                    translator.Push(L, index_array);
                        
                    
                    
                    
                    return 2;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_DelWareGoods(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            xc.ItemManager __cl_gen_to_be_invoked = (xc.ItemManager)translator.FastGetCSObj(L, 1);
            
            
            try {
                
                {
                    
                    __cl_gen_to_be_invoked.DelWareGoods(  );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_SortWareData(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            xc.ItemManager __cl_gen_to_be_invoked = (xc.ItemManager)translator.FastGetCSObj(L, 1);
            
            
            try {
                
                {
                    
                    __cl_gen_to_be_invoked.SortWareData(  );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_GetPkgGoods(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            xc.ItemManager __cl_gen_to_be_invoked = (xc.ItemManager)translator.FastGetCSObj(L, 1);
            
            
            try {
                
                {
                    ushort protocol = (ushort)LuaAPI.xlua_tointeger(L, 2);
                    byte[] data = LuaAPI.lua_tobytes(L, 3);
                    
                        xc.Goods __cl_gen_ret = __cl_gen_to_be_invoked.GetPkgGoods( protocol, data );
                        translator.Push(L, __cl_gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_GetGoodsByProtocolPkg(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            xc.ItemManager __cl_gen_to_be_invoked = (xc.ItemManager)translator.FastGetCSObj(L, 1);
            
            
            try {
                
                {
                    Net.PkgGoodsInfo info = (Net.PkgGoodsInfo)translator.GetObject(L, 2, typeof(Net.PkgGoodsInfo));
                    
                        xc.Goods __cl_gen_ret = __cl_gen_to_be_invoked.GetGoodsByProtocolPkg( info );
                        translator.Push(L, __cl_gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_GetGoodsByProtocolPkgLua(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            xc.ItemManager __cl_gen_to_be_invoked = (xc.ItemManager)translator.FastGetCSObj(L, 1);
            
            
            try {
                
                {
                    XLua.LuaTable info = (XLua.LuaTable)translator.GetObject(L, 2, typeof(XLua.LuaTable));
                    
                        xc.Goods __cl_gen_ret = __cl_gen_to_be_invoked.GetGoodsByProtocolPkgLua( info );
                        translator.Push(L, __cl_gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_GetPkgGoodsList(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            xc.ItemManager __cl_gen_to_be_invoked = (xc.ItemManager)translator.FastGetCSObj(L, 1);
            
            
            try {
                
                {
                    ushort protocol = (ushort)LuaAPI.xlua_tointeger(L, 2);
                    byte[] data = LuaAPI.lua_tobytes(L, 3);
                    
                        System.Collections.Generic.Dictionary<string, System.Collections.Generic.List<xc.Goods>> __cl_gen_ret = __cl_gen_to_be_invoked.GetPkgGoodsList( protocol, data );
                        translator.Push(L, __cl_gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_HandleServerData(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            xc.ItemManager __cl_gen_to_be_invoked = (xc.ItemManager)translator.FastGetCSObj(L, 1);
            
            
            try {
                
                {
                    ushort protocol = (ushort)LuaAPI.xlua_tointeger(L, 2);
                    byte[] data = LuaAPI.lua_tobytes(L, 3);
                    
                    __cl_gen_to_be_invoked.HandleServerData( protocol, data );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_AddCloseGoodsId(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            xc.ItemManager __cl_gen_to_be_invoked = (xc.ItemManager)translator.FastGetCSObj(L, 1);
            
            
            try {
                
                {
                    uint type_idx = LuaAPI.xlua_touint(L, 2);
                    
                    __cl_gen_to_be_invoked.AddCloseGoodsId( type_idx );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_IsCloseGoodsId(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            xc.ItemManager __cl_gen_to_be_invoked = (xc.ItemManager)translator.FastGetCSObj(L, 1);
            
            
            try {
                
                {
                    uint type_idx = LuaAPI.xlua_touint(L, 2);
                    
                        bool __cl_gen_ret = __cl_gen_to_be_invoked.IsCloseGoodsId( type_idx );
                        LuaAPI.lua_pushboolean(L, __cl_gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_RemoveCloseGoodsId(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            xc.ItemManager __cl_gen_to_be_invoked = (xc.ItemManager)translator.FastGetCSObj(L, 1);
            
            
            try {
                
                {
                    uint type_idx = LuaAPI.xlua_touint(L, 2);
                    
                    __cl_gen_to_be_invoked.RemoveCloseGoodsId( type_idx );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_CheckBagFullRedPoint(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            xc.ItemManager __cl_gen_to_be_invoked = (xc.ItemManager)translator.FastGetCSObj(L, 1);
            
            
            try {
                
                {
                    
                    __cl_gen_to_be_invoked.CheckBagFullRedPoint(  );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_DecorateInstall(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            xc.ItemManager __cl_gen_to_be_invoked = (xc.ItemManager)translator.FastGetCSObj(L, 1);
            
            
            try {
                
                {
                    uint fromBag = LuaAPI.xlua_touint(L, 2);
                    uint toBag = LuaAPI.xlua_touint(L, 3);
                    ulong oid = LuaAPI.lua_touint64(L, 4);
                    
                    __cl_gen_to_be_invoked.DecorateInstall( fromBag, toBag, oid );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_TakeOnDecorate(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            xc.ItemManager __cl_gen_to_be_invoked = (xc.ItemManager)translator.FastGetCSObj(L, 1);
            
            
            try {
                
                {
                    xc.GoodsDecorate decorate = (xc.GoodsDecorate)translator.GetObject(L, 2, typeof(xc.GoodsDecorate));
                    
                    __cl_gen_to_be_invoked.TakeOnDecorate( decorate );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_TakeOffDecorate(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            xc.ItemManager __cl_gen_to_be_invoked = (xc.ItemManager)translator.FastGetCSObj(L, 1);
            
            
            try {
                
                {
                    xc.GoodsDecorate decorate = (xc.GoodsDecorate)translator.GetObject(L, 2, typeof(xc.GoodsDecorate));
                    
                    __cl_gen_to_be_invoked.TakeOffDecorate( decorate );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_GetConsumeValue(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            xc.ItemManager __cl_gen_to_be_invoked = (xc.ItemManager)translator.FastGetCSObj(L, 1);
            
            
            try {
                
                {
                    ulong oid = LuaAPI.lua_touint64(L, 2);
                    
                        uint __cl_gen_ret = __cl_gen_to_be_invoked.GetConsumeValue( oid );
                        LuaAPI.xlua_pushuint(L, __cl_gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_GetWearingGodEquipGoods(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            xc.ItemManager __cl_gen_to_be_invoked = (xc.ItemManager)translator.FastGetCSObj(L, 1);
            
            
            try {
                
                {
                    uint id = LuaAPI.xlua_touint(L, 2);
                    uint pos = LuaAPI.xlua_touint(L, 3);
                    
                        xc.GoodsGodEquip __cl_gen_ret = __cl_gen_to_be_invoked.GetWearingGodEquipGoods( id, pos );
                        translator.Push(L, __cl_gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_GetWearingMountEquipGoods(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            xc.ItemManager __cl_gen_to_be_invoked = (xc.ItemManager)translator.FastGetCSObj(L, 1);
            
            
            try {
                
                {
                    uint pos = LuaAPI.xlua_touint(L, 2);
                    
                        xc.GoodsMountEquip __cl_gen_ret = __cl_gen_to_be_invoked.GetWearingMountEquipGoods( pos );
                        translator.Push(L, __cl_gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_GetBagDataByBagType(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            xc.ItemManager __cl_gen_to_be_invoked = (xc.ItemManager)translator.FastGetCSObj(L, 1);
            
            
            try {
                
                {
                    ushort typeId = (ushort)LuaAPI.xlua_tointeger(L, 2);
                    
                        object __cl_gen_ret = __cl_gen_to_be_invoked.GetBagDataByBagType( typeId );
                        translator.PushAny(L, __cl_gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_CheckHavePos(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            xc.ItemManager __cl_gen_to_be_invoked = (xc.ItemManager)translator.FastGetCSObj(L, 1);
            
            
            try {
                
                {
                    int main_type = LuaAPI.xlua_tointeger(L, 2);
                    uint pos = LuaAPI.xlua_touint(L, 3);
                    
                        bool __cl_gen_ret = __cl_gen_to_be_invoked.CheckHavePos( main_type, pos );
                        LuaAPI.lua_pushboolean(L, __cl_gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_FreshPosState(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            xc.ItemManager __cl_gen_to_be_invoked = (xc.ItemManager)translator.FastGetCSObj(L, 1);
            
            
            try {
                
                {
                    
                    __cl_gen_to_be_invoked.FreshPosState(  );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_GetSortedLuckyTreasureGoodsList(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            xc.ItemManager __cl_gen_to_be_invoked = (xc.ItemManager)translator.FastGetCSObj(L, 1);
            
            
            try {
                
                {
                    
                        System.Collections.Generic.List<xc.Goods> __cl_gen_ret = __cl_gen_to_be_invoked.GetSortedLuckyTreasureGoodsList(  );
                        translator.Push(L, __cl_gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_ProcessAddGoodsListByLua(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            xc.ItemManager __cl_gen_to_be_invoked = (xc.ItemManager)translator.FastGetCSObj(L, 1);
            
            
            try {
                
                {
                    XLua.LuaTable goodsListToAdd = (XLua.LuaTable)translator.GetObject(L, 2, typeof(XLua.LuaTable));
                    
                    __cl_gen_to_be_invoked.ProcessAddGoodsListByLua( goodsListToAdd );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        
        
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_Instance(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			    translator.Push(L, xc.ItemManager.Instance);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_LuckyTreasureBagIsFull(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.ItemManager __cl_gen_to_be_invoked = (xc.ItemManager)translator.FastGetCSObj(L, 1);
                LuaAPI.lua_pushboolean(L, __cl_gen_to_be_invoked.LuckyTreasureBagIsFull);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_BagGoodsOids(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.ItemManager __cl_gen_to_be_invoked = (xc.ItemManager)translator.FastGetCSObj(L, 1);
                translator.Push(L, __cl_gen_to_be_invoked.BagGoodsOids);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_BagTypeIdAndOids(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.ItemManager __cl_gen_to_be_invoked = (xc.ItemManager)translator.FastGetCSObj(L, 1);
                translator.Push(L, __cl_gen_to_be_invoked.BagTypeIdAndOids);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_BagPanelSort(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.ItemManager __cl_gen_to_be_invoked = (xc.ItemManager)translator.FastGetCSObj(L, 1);
                translator.Push(L, __cl_gen_to_be_invoked.BagPanelSort);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_NeedUpdateBagIndexArray(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.ItemManager __cl_gen_to_be_invoked = (xc.ItemManager)translator.FastGetCSObj(L, 1);
                translator.Push(L, __cl_gen_to_be_invoked.NeedUpdateBagIndexArray);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_WareHouseGoodsOids(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.ItemManager __cl_gen_to_be_invoked = (xc.ItemManager)translator.FastGetCSObj(L, 1);
                translator.Push(L, __cl_gen_to_be_invoked.WareHouseGoodsOids);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_WareHouseTypeIdAndOids(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.ItemManager __cl_gen_to_be_invoked = (xc.ItemManager)translator.FastGetCSObj(L, 1);
                translator.Push(L, __cl_gen_to_be_invoked.WareHouseTypeIdAndOids);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_WarePanelSort(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.ItemManager __cl_gen_to_be_invoked = (xc.ItemManager)translator.FastGetCSObj(L, 1);
                translator.Push(L, __cl_gen_to_be_invoked.WarePanelSort);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_NeedUpdateWareIndexArray(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.ItemManager __cl_gen_to_be_invoked = (xc.ItemManager)translator.FastGetCSObj(L, 1);
                translator.Push(L, __cl_gen_to_be_invoked.NeedUpdateWareIndexArray);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_TreasureHuntGoodsOids(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.ItemManager __cl_gen_to_be_invoked = (xc.ItemManager)translator.FastGetCSObj(L, 1);
                translator.Push(L, __cl_gen_to_be_invoked.TreasureHuntGoodsOids);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_IDTreasureGoodsOids(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.ItemManager __cl_gen_to_be_invoked = (xc.ItemManager)translator.FastGetCSObj(L, 1);
                translator.Push(L, __cl_gen_to_be_invoked.IDTreasureGoodsOids);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_HandbookGoodsOids(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.ItemManager __cl_gen_to_be_invoked = (xc.ItemManager)translator.FastGetCSObj(L, 1);
                translator.Push(L, __cl_gen_to_be_invoked.HandbookGoodsOids);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_HandbookTypeIdAndOids(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.ItemManager __cl_gen_to_be_invoked = (xc.ItemManager)translator.FastGetCSObj(L, 1);
                translator.Push(L, __cl_gen_to_be_invoked.HandbookTypeIdAndOids);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_SoulGoodsOids(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.ItemManager __cl_gen_to_be_invoked = (xc.ItemManager)translator.FastGetCSObj(L, 1);
                translator.Push(L, __cl_gen_to_be_invoked.SoulGoodsOids);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_SoulTypeIdAndOids(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.ItemManager __cl_gen_to_be_invoked = (xc.ItemManager)translator.FastGetCSObj(L, 1);
                translator.Push(L, __cl_gen_to_be_invoked.SoulTypeIdAndOids);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_DecorateGoodsOids(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.ItemManager __cl_gen_to_be_invoked = (xc.ItemManager)translator.FastGetCSObj(L, 1);
                translator.Push(L, __cl_gen_to_be_invoked.DecorateGoodsOids);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_DecorateTypeIdAndOids(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.ItemManager __cl_gen_to_be_invoked = (xc.ItemManager)translator.FastGetCSObj(L, 1);
                translator.Push(L, __cl_gen_to_be_invoked.DecorateTypeIdAndOids);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_MagicEquipGoodsOids(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.ItemManager __cl_gen_to_be_invoked = (xc.ItemManager)translator.FastGetCSObj(L, 1);
                translator.Push(L, __cl_gen_to_be_invoked.MagicEquipGoodsOids);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_MagicEquipTypeIdAndOids(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.ItemManager __cl_gen_to_be_invoked = (xc.ItemManager)translator.FastGetCSObj(L, 1);
                translator.Push(L, __cl_gen_to_be_invoked.MagicEquipTypeIdAndOids);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_InstallEquip(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.ItemManager __cl_gen_to_be_invoked = (xc.ItemManager)translator.FastGetCSObj(L, 1);
                translator.Push(L, __cl_gen_to_be_invoked.InstallEquip);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_InstallGoodsSouls(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.ItemManager __cl_gen_to_be_invoked = (xc.ItemManager)translator.FastGetCSObj(L, 1);
                translator.Push(L, __cl_gen_to_be_invoked.InstallGoodsSouls);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_WearingDecorate(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.ItemManager __cl_gen_to_be_invoked = (xc.ItemManager)translator.FastGetCSObj(L, 1);
                translator.Push(L, __cl_gen_to_be_invoked.WearingDecorate);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_WearingMagicEquip(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.ItemManager __cl_gen_to_be_invoked = (xc.ItemManager)translator.FastGetCSObj(L, 1);
                translator.Push(L, __cl_gen_to_be_invoked.WearingMagicEquip);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_EquipGoodsOid(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.ItemManager __cl_gen_to_be_invoked = (xc.ItemManager)translator.FastGetCSObj(L, 1);
                translator.Push(L, __cl_gen_to_be_invoked.EquipGoodsOid);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_GoodsCd(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.ItemManager __cl_gen_to_be_invoked = (xc.ItemManager)translator.FastGetCSObj(L, 1);
                translator.Push(L, __cl_gen_to_be_invoked.GoodsCd);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_InstallGodEquip(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.ItemManager __cl_gen_to_be_invoked = (xc.ItemManager)translator.FastGetCSObj(L, 1);
                translator.Push(L, __cl_gen_to_be_invoked.InstallGodEquip);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_GodEquipGoodsOids(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.ItemManager __cl_gen_to_be_invoked = (xc.ItemManager)translator.FastGetCSObj(L, 1);
                translator.Push(L, __cl_gen_to_be_invoked.GodEquipGoodsOids);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_InstallMountEquip(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.ItemManager __cl_gen_to_be_invoked = (xc.ItemManager)translator.FastGetCSObj(L, 1);
                translator.Push(L, __cl_gen_to_be_invoked.InstallMountEquip);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_MountEquipGoodsOid(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.ItemManager __cl_gen_to_be_invoked = (xc.ItemManager)translator.FastGetCSObj(L, 1);
                translator.Push(L, __cl_gen_to_be_invoked.MountEquipGoodsOid);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_MountEquipTypeIdAndOids(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.ItemManager __cl_gen_to_be_invoked = (xc.ItemManager)translator.FastGetCSObj(L, 1);
                translator.Push(L, __cl_gen_to_be_invoked.MountEquipTypeIdAndOids);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_LightWeaponGoodsOids(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.ItemManager __cl_gen_to_be_invoked = (xc.ItemManager)translator.FastGetCSObj(L, 1);
                translator.Push(L, __cl_gen_to_be_invoked.LightWeaponGoodsOids);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_InstalledLightWeaponSoul(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.ItemManager __cl_gen_to_be_invoked = (xc.ItemManager)translator.FastGetCSObj(L, 1);
                translator.Push(L, __cl_gen_to_be_invoked.InstalledLightWeaponSoul);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_mBagInitCount(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.ItemManager __cl_gen_to_be_invoked = (xc.ItemManager)translator.FastGetCSObj(L, 1);
                LuaAPI.xlua_pushuint(L, __cl_gen_to_be_invoked.mBagInitCount);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_mWareInitCount(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.ItemManager __cl_gen_to_be_invoked = (xc.ItemManager)translator.FastGetCSObj(L, 1);
                LuaAPI.xlua_pushuint(L, __cl_gen_to_be_invoked.mWareInitCount);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_mBagMaxCount(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.ItemManager __cl_gen_to_be_invoked = (xc.ItemManager)translator.FastGetCSObj(L, 1);
                LuaAPI.xlua_pushuint(L, __cl_gen_to_be_invoked.mBagMaxCount);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_mWareMaxCount(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.ItemManager __cl_gen_to_be_invoked = (xc.ItemManager)translator.FastGetCSObj(L, 1);
                LuaAPI.xlua_pushuint(L, __cl_gen_to_be_invoked.mWareMaxCount);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_mBagTotalCount(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.ItemManager __cl_gen_to_be_invoked = (xc.ItemManager)translator.FastGetCSObj(L, 1);
                LuaAPI.xlua_pushuint(L, __cl_gen_to_be_invoked.mBagTotalCount);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_mWareTotalCount(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.ItemManager __cl_gen_to_be_invoked = (xc.ItemManager)translator.FastGetCSObj(L, 1);
                LuaAPI.xlua_pushuint(L, __cl_gen_to_be_invoked.mWareTotalCount);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_mSoulBagInitCount(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.ItemManager __cl_gen_to_be_invoked = (xc.ItemManager)translator.FastGetCSObj(L, 1);
                LuaAPI.xlua_pushuint(L, __cl_gen_to_be_invoked.mSoulBagInitCount);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_mSoulBagTotalCount(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.ItemManager __cl_gen_to_be_invoked = (xc.ItemManager)translator.FastGetCSObj(L, 1);
                LuaAPI.xlua_pushuint(L, __cl_gen_to_be_invoked.mSoulBagTotalCount);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_mSoulInstallInitCount(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.ItemManager __cl_gen_to_be_invoked = (xc.ItemManager)translator.FastGetCSObj(L, 1);
                LuaAPI.xlua_pushuint(L, __cl_gen_to_be_invoked.mSoulInstallInitCount);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_mSoulInstallTotalCount(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.ItemManager __cl_gen_to_be_invoked = (xc.ItemManager)translator.FastGetCSObj(L, 1);
                LuaAPI.xlua_pushuint(L, __cl_gen_to_be_invoked.mSoulInstallTotalCount);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_mHandbookBagInitCount(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.ItemManager __cl_gen_to_be_invoked = (xc.ItemManager)translator.FastGetCSObj(L, 1);
                LuaAPI.xlua_pushuint(L, __cl_gen_to_be_invoked.mHandbookBagInitCount);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_mHandbookBagTotalCount(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.ItemManager __cl_gen_to_be_invoked = (xc.ItemManager)translator.FastGetCSObj(L, 1);
                LuaAPI.xlua_pushuint(L, __cl_gen_to_be_invoked.mHandbookBagTotalCount);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_mDecorateBagInitCount(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.ItemManager __cl_gen_to_be_invoked = (xc.ItemManager)translator.FastGetCSObj(L, 1);
                LuaAPI.xlua_pushuint(L, __cl_gen_to_be_invoked.mDecorateBagInitCount);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_mDecorateBagTotalCount(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.ItemManager __cl_gen_to_be_invoked = (xc.ItemManager)translator.FastGetCSObj(L, 1);
                LuaAPI.xlua_pushuint(L, __cl_gen_to_be_invoked.mDecorateBagTotalCount);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_mMagicEquipBagInitCount(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.ItemManager __cl_gen_to_be_invoked = (xc.ItemManager)translator.FastGetCSObj(L, 1);
                LuaAPI.xlua_pushuint(L, __cl_gen_to_be_invoked.mMagicEquipBagInitCount);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_mMagicEquipBagTotalCount(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.ItemManager __cl_gen_to_be_invoked = (xc.ItemManager)translator.FastGetCSObj(L, 1);
                LuaAPI.xlua_pushuint(L, __cl_gen_to_be_invoked.mMagicEquipBagTotalCount);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_mGodEquipBagInitCount(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.ItemManager __cl_gen_to_be_invoked = (xc.ItemManager)translator.FastGetCSObj(L, 1);
                LuaAPI.xlua_pushuint(L, __cl_gen_to_be_invoked.mGodEquipBagInitCount);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_mGodEquipBagTotalCount(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.ItemManager __cl_gen_to_be_invoked = (xc.ItemManager)translator.FastGetCSObj(L, 1);
                LuaAPI.xlua_pushuint(L, __cl_gen_to_be_invoked.mGodEquipBagTotalCount);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_mMountEquipBagInitCount(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.ItemManager __cl_gen_to_be_invoked = (xc.ItemManager)translator.FastGetCSObj(L, 1);
                LuaAPI.xlua_pushuint(L, __cl_gen_to_be_invoked.mMountEquipBagInitCount);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_mMountEquipBagTotalCount(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.ItemManager __cl_gen_to_be_invoked = (xc.ItemManager)translator.FastGetCSObj(L, 1);
                LuaAPI.xlua_pushuint(L, __cl_gen_to_be_invoked.mMountEquipBagTotalCount);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_mLightWeaponSoulBagInitCount(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.ItemManager __cl_gen_to_be_invoked = (xc.ItemManager)translator.FastGetCSObj(L, 1);
                LuaAPI.xlua_pushuint(L, __cl_gen_to_be_invoked.mLightWeaponSoulBagInitCount);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_mLightWeaponSoulBagTotalCount(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.ItemManager __cl_gen_to_be_invoked = (xc.ItemManager)translator.FastGetCSObj(L, 1);
                LuaAPI.xlua_pushuint(L, __cl_gen_to_be_invoked.mLightWeaponSoulBagTotalCount);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_mLuckyTreasureBagMaxCount(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.ItemManager __cl_gen_to_be_invoked = (xc.ItemManager)translator.FastGetCSObj(L, 1);
                LuaAPI.xlua_pushuint(L, __cl_gen_to_be_invoked.mLuckyTreasureBagMaxCount);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_isForceShowfloatTips(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.ItemManager __cl_gen_to_be_invoked = (xc.ItemManager)translator.FastGetCSObj(L, 1);
                LuaAPI.lua_pushboolean(L, __cl_gen_to_be_invoked.isForceShowfloatTips);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_mIsAutoHp(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.ItemManager __cl_gen_to_be_invoked = (xc.ItemManager)translator.FastGetCSObj(L, 1);
                LuaAPI.lua_pushboolean(L, __cl_gen_to_be_invoked.mIsAutoHp);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_mIsAutoMp(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.ItemManager __cl_gen_to_be_invoked = (xc.ItemManager)translator.FastGetCSObj(L, 1);
                LuaAPI.lua_pushboolean(L, __cl_gen_to_be_invoked.mIsAutoMp);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_mIconConfig(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.ItemManager __cl_gen_to_be_invoked = (xc.ItemManager)translator.FastGetCSObj(L, 1);
                translator.Push(L, __cl_gen_to_be_invoked.mIconConfig);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_CurrentLockBagItem(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.ItemManager __cl_gen_to_be_invoked = (xc.ItemManager)translator.FastGetCSObj(L, 1);
                translator.Push(L, __cl_gen_to_be_invoked.CurrentLockBagItem);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_StrengthInfos(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.ItemManager __cl_gen_to_be_invoked = (xc.ItemManager)translator.FastGetCSObj(L, 1);
                translator.Push(L, __cl_gen_to_be_invoked.StrengthInfos);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_DecoratePosInfos(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.ItemManager __cl_gen_to_be_invoked = (xc.ItemManager)translator.FastGetCSObj(L, 1);
                translator.Push(L, __cl_gen_to_be_invoked.DecoratePosInfos);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_GetSoulList(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.ItemManager __cl_gen_to_be_invoked = (xc.ItemManager)translator.FastGetCSObj(L, 1);
                translator.Push(L, __cl_gen_to_be_invoked.GetSoulList);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_OpenSoulList(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.ItemManager __cl_gen_to_be_invoked = (xc.ItemManager)translator.FastGetCSObj(L, 1);
                translator.Push(L, __cl_gen_to_be_invoked.OpenSoulList);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_BaptizeCount(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.ItemManager __cl_gen_to_be_invoked = (xc.ItemManager)translator.FastGetCSObj(L, 1);
                LuaAPI.xlua_pushuint(L, __cl_gen_to_be_invoked.BaptizeCount);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_mCloseQuickUseGoodsIdArray(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.ItemManager __cl_gen_to_be_invoked = (xc.ItemManager)translator.FastGetCSObj(L, 1);
                translator.Push(L, __cl_gen_to_be_invoked.mCloseQuickUseGoodsIdArray);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_mHaveCheckPos(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.ItemManager __cl_gen_to_be_invoked = (xc.ItemManager)translator.FastGetCSObj(L, 1);
                translator.Push(L, __cl_gen_to_be_invoked.mHaveCheckPos);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_mIdInCurShortCutWin(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.ItemManager __cl_gen_to_be_invoked = (xc.ItemManager)translator.FastGetCSObj(L, 1);
                LuaAPI.lua_pushuint64(L, __cl_gen_to_be_invoked.mIdInCurShortCutWin);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_BagGoodsOids(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.ItemManager __cl_gen_to_be_invoked = (xc.ItemManager)translator.FastGetCSObj(L, 1);
                __cl_gen_to_be_invoked.BagGoodsOids = (System.Collections.Generic.Dictionary<ulong, xc.Goods>)translator.GetObject(L, 2, typeof(System.Collections.Generic.Dictionary<ulong, xc.Goods>));
            
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_BagTypeIdAndOids(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.ItemManager __cl_gen_to_be_invoked = (xc.ItemManager)translator.FastGetCSObj(L, 1);
                __cl_gen_to_be_invoked.BagTypeIdAndOids = (System.Collections.Generic.Dictionary<uint, System.Collections.Generic.List<ulong>>)translator.GetObject(L, 2, typeof(System.Collections.Generic.Dictionary<uint, System.Collections.Generic.List<ulong>>));
            
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_BagPanelSort(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.ItemManager __cl_gen_to_be_invoked = (xc.ItemManager)translator.FastGetCSObj(L, 1);
                __cl_gen_to_be_invoked.BagPanelSort = (System.Collections.Generic.List<xc.Goods>)translator.GetObject(L, 2, typeof(System.Collections.Generic.List<xc.Goods>));
            
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_NeedUpdateBagIndexArray(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.ItemManager __cl_gen_to_be_invoked = (xc.ItemManager)translator.FastGetCSObj(L, 1);
                __cl_gen_to_be_invoked.NeedUpdateBagIndexArray = (System.Collections.Generic.List<int>)translator.GetObject(L, 2, typeof(System.Collections.Generic.List<int>));
            
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_WareHouseGoodsOids(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.ItemManager __cl_gen_to_be_invoked = (xc.ItemManager)translator.FastGetCSObj(L, 1);
                __cl_gen_to_be_invoked.WareHouseGoodsOids = (System.Collections.Generic.Dictionary<ulong, xc.Goods>)translator.GetObject(L, 2, typeof(System.Collections.Generic.Dictionary<ulong, xc.Goods>));
            
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_WareHouseTypeIdAndOids(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.ItemManager __cl_gen_to_be_invoked = (xc.ItemManager)translator.FastGetCSObj(L, 1);
                __cl_gen_to_be_invoked.WareHouseTypeIdAndOids = (System.Collections.Generic.Dictionary<uint, System.Collections.Generic.List<ulong>>)translator.GetObject(L, 2, typeof(System.Collections.Generic.Dictionary<uint, System.Collections.Generic.List<ulong>>));
            
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_WarePanelSort(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.ItemManager __cl_gen_to_be_invoked = (xc.ItemManager)translator.FastGetCSObj(L, 1);
                __cl_gen_to_be_invoked.WarePanelSort = (System.Collections.Generic.List<xc.Goods>)translator.GetObject(L, 2, typeof(System.Collections.Generic.List<xc.Goods>));
            
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_NeedUpdateWareIndexArray(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.ItemManager __cl_gen_to_be_invoked = (xc.ItemManager)translator.FastGetCSObj(L, 1);
                __cl_gen_to_be_invoked.NeedUpdateWareIndexArray = (System.Collections.Generic.List<int>)translator.GetObject(L, 2, typeof(System.Collections.Generic.List<int>));
            
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_TreasureHuntGoodsOids(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.ItemManager __cl_gen_to_be_invoked = (xc.ItemManager)translator.FastGetCSObj(L, 1);
                __cl_gen_to_be_invoked.TreasureHuntGoodsOids = (System.Collections.Generic.Dictionary<ulong, xc.Goods>)translator.GetObject(L, 2, typeof(System.Collections.Generic.Dictionary<ulong, xc.Goods>));
            
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_IDTreasureGoodsOids(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.ItemManager __cl_gen_to_be_invoked = (xc.ItemManager)translator.FastGetCSObj(L, 1);
                __cl_gen_to_be_invoked.IDTreasureGoodsOids = (System.Collections.Generic.Dictionary<ulong, xc.Goods>)translator.GetObject(L, 2, typeof(System.Collections.Generic.Dictionary<ulong, xc.Goods>));
            
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_HandbookGoodsOids(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.ItemManager __cl_gen_to_be_invoked = (xc.ItemManager)translator.FastGetCSObj(L, 1);
                __cl_gen_to_be_invoked.HandbookGoodsOids = (System.Collections.Generic.Dictionary<ulong, xc.Goods>)translator.GetObject(L, 2, typeof(System.Collections.Generic.Dictionary<ulong, xc.Goods>));
            
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_HandbookTypeIdAndOids(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.ItemManager __cl_gen_to_be_invoked = (xc.ItemManager)translator.FastGetCSObj(L, 1);
                __cl_gen_to_be_invoked.HandbookTypeIdAndOids = (System.Collections.Generic.Dictionary<uint, System.Collections.Generic.List<ulong>>)translator.GetObject(L, 2, typeof(System.Collections.Generic.Dictionary<uint, System.Collections.Generic.List<ulong>>));
            
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_SoulGoodsOids(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.ItemManager __cl_gen_to_be_invoked = (xc.ItemManager)translator.FastGetCSObj(L, 1);
                __cl_gen_to_be_invoked.SoulGoodsOids = (System.Collections.Generic.Dictionary<ulong, xc.Goods>)translator.GetObject(L, 2, typeof(System.Collections.Generic.Dictionary<ulong, xc.Goods>));
            
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_SoulTypeIdAndOids(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.ItemManager __cl_gen_to_be_invoked = (xc.ItemManager)translator.FastGetCSObj(L, 1);
                __cl_gen_to_be_invoked.SoulTypeIdAndOids = (System.Collections.Generic.Dictionary<uint, System.Collections.Generic.List<ulong>>)translator.GetObject(L, 2, typeof(System.Collections.Generic.Dictionary<uint, System.Collections.Generic.List<ulong>>));
            
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_DecorateGoodsOids(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.ItemManager __cl_gen_to_be_invoked = (xc.ItemManager)translator.FastGetCSObj(L, 1);
                __cl_gen_to_be_invoked.DecorateGoodsOids = (System.Collections.Generic.Dictionary<ulong, xc.Goods>)translator.GetObject(L, 2, typeof(System.Collections.Generic.Dictionary<ulong, xc.Goods>));
            
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_DecorateTypeIdAndOids(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.ItemManager __cl_gen_to_be_invoked = (xc.ItemManager)translator.FastGetCSObj(L, 1);
                __cl_gen_to_be_invoked.DecorateTypeIdAndOids = (System.Collections.Generic.Dictionary<uint, System.Collections.Generic.List<ulong>>)translator.GetObject(L, 2, typeof(System.Collections.Generic.Dictionary<uint, System.Collections.Generic.List<ulong>>));
            
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_MagicEquipGoodsOids(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.ItemManager __cl_gen_to_be_invoked = (xc.ItemManager)translator.FastGetCSObj(L, 1);
                __cl_gen_to_be_invoked.MagicEquipGoodsOids = (System.Collections.Generic.Dictionary<ulong, xc.GoodsMagicEquip>)translator.GetObject(L, 2, typeof(System.Collections.Generic.Dictionary<ulong, xc.GoodsMagicEquip>));
            
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_MagicEquipTypeIdAndOids(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.ItemManager __cl_gen_to_be_invoked = (xc.ItemManager)translator.FastGetCSObj(L, 1);
                __cl_gen_to_be_invoked.MagicEquipTypeIdAndOids = (System.Collections.Generic.Dictionary<uint, System.Collections.Generic.List<ulong>>)translator.GetObject(L, 2, typeof(System.Collections.Generic.Dictionary<uint, System.Collections.Generic.List<ulong>>));
            
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_InstallEquip(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.ItemManager __cl_gen_to_be_invoked = (xc.ItemManager)translator.FastGetCSObj(L, 1);
                __cl_gen_to_be_invoked.InstallEquip = (System.Collections.Generic.Dictionary<ulong, xc.GoodsEquip>)translator.GetObject(L, 2, typeof(System.Collections.Generic.Dictionary<ulong, xc.GoodsEquip>));
            
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_InstallGoodsSouls(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.ItemManager __cl_gen_to_be_invoked = (xc.ItemManager)translator.FastGetCSObj(L, 1);
                __cl_gen_to_be_invoked.InstallGoodsSouls = (System.Collections.Generic.Dictionary<uint, xc.GoodsSoul>)translator.GetObject(L, 2, typeof(System.Collections.Generic.Dictionary<uint, xc.GoodsSoul>));
            
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_WearingDecorate(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.ItemManager __cl_gen_to_be_invoked = (xc.ItemManager)translator.FastGetCSObj(L, 1);
                __cl_gen_to_be_invoked.WearingDecorate = (System.Collections.Generic.Dictionary<uint, xc.GoodsDecorate>)translator.GetObject(L, 2, typeof(System.Collections.Generic.Dictionary<uint, xc.GoodsDecorate>));
            
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_WearingMagicEquip(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.ItemManager __cl_gen_to_be_invoked = (xc.ItemManager)translator.FastGetCSObj(L, 1);
                __cl_gen_to_be_invoked.WearingMagicEquip = (System.Collections.Generic.Dictionary<ulong, xc.GoodsMagicEquip>)translator.GetObject(L, 2, typeof(System.Collections.Generic.Dictionary<ulong, xc.GoodsMagicEquip>));
            
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_EquipGoodsOid(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.ItemManager __cl_gen_to_be_invoked = (xc.ItemManager)translator.FastGetCSObj(L, 1);
                __cl_gen_to_be_invoked.EquipGoodsOid = (System.Collections.Generic.Dictionary<ulong, xc.GoodsEquip>)translator.GetObject(L, 2, typeof(System.Collections.Generic.Dictionary<ulong, xc.GoodsEquip>));
            
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_GoodsCd(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.ItemManager __cl_gen_to_be_invoked = (xc.ItemManager)translator.FastGetCSObj(L, 1);
                __cl_gen_to_be_invoked.GoodsCd = (System.Collections.Generic.Dictionary<uint, uint>)translator.GetObject(L, 2, typeof(System.Collections.Generic.Dictionary<uint, uint>));
            
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_InstallGodEquip(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.ItemManager __cl_gen_to_be_invoked = (xc.ItemManager)translator.FastGetCSObj(L, 1);
                __cl_gen_to_be_invoked.InstallGodEquip = (System.Collections.Generic.Dictionary<ulong, xc.GoodsGodEquip>)translator.GetObject(L, 2, typeof(System.Collections.Generic.Dictionary<ulong, xc.GoodsGodEquip>));
            
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_GodEquipGoodsOids(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.ItemManager __cl_gen_to_be_invoked = (xc.ItemManager)translator.FastGetCSObj(L, 1);
                __cl_gen_to_be_invoked.GodEquipGoodsOids = (System.Collections.Generic.Dictionary<ulong, xc.GoodsGodEquip>)translator.GetObject(L, 2, typeof(System.Collections.Generic.Dictionary<ulong, xc.GoodsGodEquip>));
            
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_InstallMountEquip(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.ItemManager __cl_gen_to_be_invoked = (xc.ItemManager)translator.FastGetCSObj(L, 1);
                __cl_gen_to_be_invoked.InstallMountEquip = (System.Collections.Generic.Dictionary<ulong, xc.GoodsMountEquip>)translator.GetObject(L, 2, typeof(System.Collections.Generic.Dictionary<ulong, xc.GoodsMountEquip>));
            
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_MountEquipGoodsOid(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.ItemManager __cl_gen_to_be_invoked = (xc.ItemManager)translator.FastGetCSObj(L, 1);
                __cl_gen_to_be_invoked.MountEquipGoodsOid = (System.Collections.Generic.Dictionary<ulong, xc.GoodsMountEquip>)translator.GetObject(L, 2, typeof(System.Collections.Generic.Dictionary<ulong, xc.GoodsMountEquip>));
            
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_MountEquipTypeIdAndOids(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.ItemManager __cl_gen_to_be_invoked = (xc.ItemManager)translator.FastGetCSObj(L, 1);
                __cl_gen_to_be_invoked.MountEquipTypeIdAndOids = (System.Collections.Generic.Dictionary<uint, System.Collections.Generic.List<ulong>>)translator.GetObject(L, 2, typeof(System.Collections.Generic.Dictionary<uint, System.Collections.Generic.List<ulong>>));
            
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_LightWeaponGoodsOids(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.ItemManager __cl_gen_to_be_invoked = (xc.ItemManager)translator.FastGetCSObj(L, 1);
                __cl_gen_to_be_invoked.LightWeaponGoodsOids = (System.Collections.Generic.Dictionary<ulong, xc.GoodsLightWeaponSoul>)translator.GetObject(L, 2, typeof(System.Collections.Generic.Dictionary<ulong, xc.GoodsLightWeaponSoul>));
            
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_InstalledLightWeaponSoul(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.ItemManager __cl_gen_to_be_invoked = (xc.ItemManager)translator.FastGetCSObj(L, 1);
                __cl_gen_to_be_invoked.InstalledLightWeaponSoul = (System.Collections.Generic.Dictionary<uint, System.Collections.Generic.Dictionary<uint, xc.GoodsLightWeaponSoul>>)translator.GetObject(L, 2, typeof(System.Collections.Generic.Dictionary<uint, System.Collections.Generic.Dictionary<uint, xc.GoodsLightWeaponSoul>>));
            
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_mBagInitCount(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.ItemManager __cl_gen_to_be_invoked = (xc.ItemManager)translator.FastGetCSObj(L, 1);
                __cl_gen_to_be_invoked.mBagInitCount = LuaAPI.xlua_touint(L, 2);
            
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_mWareInitCount(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.ItemManager __cl_gen_to_be_invoked = (xc.ItemManager)translator.FastGetCSObj(L, 1);
                __cl_gen_to_be_invoked.mWareInitCount = LuaAPI.xlua_touint(L, 2);
            
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_mBagMaxCount(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.ItemManager __cl_gen_to_be_invoked = (xc.ItemManager)translator.FastGetCSObj(L, 1);
                __cl_gen_to_be_invoked.mBagMaxCount = LuaAPI.xlua_touint(L, 2);
            
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_mWareMaxCount(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.ItemManager __cl_gen_to_be_invoked = (xc.ItemManager)translator.FastGetCSObj(L, 1);
                __cl_gen_to_be_invoked.mWareMaxCount = LuaAPI.xlua_touint(L, 2);
            
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_mBagTotalCount(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.ItemManager __cl_gen_to_be_invoked = (xc.ItemManager)translator.FastGetCSObj(L, 1);
                __cl_gen_to_be_invoked.mBagTotalCount = LuaAPI.xlua_touint(L, 2);
            
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_mWareTotalCount(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.ItemManager __cl_gen_to_be_invoked = (xc.ItemManager)translator.FastGetCSObj(L, 1);
                __cl_gen_to_be_invoked.mWareTotalCount = LuaAPI.xlua_touint(L, 2);
            
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_mSoulBagInitCount(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.ItemManager __cl_gen_to_be_invoked = (xc.ItemManager)translator.FastGetCSObj(L, 1);
                __cl_gen_to_be_invoked.mSoulBagInitCount = LuaAPI.xlua_touint(L, 2);
            
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_mSoulBagTotalCount(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.ItemManager __cl_gen_to_be_invoked = (xc.ItemManager)translator.FastGetCSObj(L, 1);
                __cl_gen_to_be_invoked.mSoulBagTotalCount = LuaAPI.xlua_touint(L, 2);
            
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_mSoulInstallInitCount(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.ItemManager __cl_gen_to_be_invoked = (xc.ItemManager)translator.FastGetCSObj(L, 1);
                __cl_gen_to_be_invoked.mSoulInstallInitCount = LuaAPI.xlua_touint(L, 2);
            
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_mSoulInstallTotalCount(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.ItemManager __cl_gen_to_be_invoked = (xc.ItemManager)translator.FastGetCSObj(L, 1);
                __cl_gen_to_be_invoked.mSoulInstallTotalCount = LuaAPI.xlua_touint(L, 2);
            
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_mHandbookBagInitCount(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.ItemManager __cl_gen_to_be_invoked = (xc.ItemManager)translator.FastGetCSObj(L, 1);
                __cl_gen_to_be_invoked.mHandbookBagInitCount = LuaAPI.xlua_touint(L, 2);
            
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_mHandbookBagTotalCount(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.ItemManager __cl_gen_to_be_invoked = (xc.ItemManager)translator.FastGetCSObj(L, 1);
                __cl_gen_to_be_invoked.mHandbookBagTotalCount = LuaAPI.xlua_touint(L, 2);
            
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_mDecorateBagInitCount(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.ItemManager __cl_gen_to_be_invoked = (xc.ItemManager)translator.FastGetCSObj(L, 1);
                __cl_gen_to_be_invoked.mDecorateBagInitCount = LuaAPI.xlua_touint(L, 2);
            
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_mDecorateBagTotalCount(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.ItemManager __cl_gen_to_be_invoked = (xc.ItemManager)translator.FastGetCSObj(L, 1);
                __cl_gen_to_be_invoked.mDecorateBagTotalCount = LuaAPI.xlua_touint(L, 2);
            
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_mMagicEquipBagInitCount(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.ItemManager __cl_gen_to_be_invoked = (xc.ItemManager)translator.FastGetCSObj(L, 1);
                __cl_gen_to_be_invoked.mMagicEquipBagInitCount = LuaAPI.xlua_touint(L, 2);
            
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_mMagicEquipBagTotalCount(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.ItemManager __cl_gen_to_be_invoked = (xc.ItemManager)translator.FastGetCSObj(L, 1);
                __cl_gen_to_be_invoked.mMagicEquipBagTotalCount = LuaAPI.xlua_touint(L, 2);
            
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_mGodEquipBagInitCount(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.ItemManager __cl_gen_to_be_invoked = (xc.ItemManager)translator.FastGetCSObj(L, 1);
                __cl_gen_to_be_invoked.mGodEquipBagInitCount = LuaAPI.xlua_touint(L, 2);
            
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_mGodEquipBagTotalCount(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.ItemManager __cl_gen_to_be_invoked = (xc.ItemManager)translator.FastGetCSObj(L, 1);
                __cl_gen_to_be_invoked.mGodEquipBagTotalCount = LuaAPI.xlua_touint(L, 2);
            
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_mMountEquipBagInitCount(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.ItemManager __cl_gen_to_be_invoked = (xc.ItemManager)translator.FastGetCSObj(L, 1);
                __cl_gen_to_be_invoked.mMountEquipBagInitCount = LuaAPI.xlua_touint(L, 2);
            
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_mMountEquipBagTotalCount(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.ItemManager __cl_gen_to_be_invoked = (xc.ItemManager)translator.FastGetCSObj(L, 1);
                __cl_gen_to_be_invoked.mMountEquipBagTotalCount = LuaAPI.xlua_touint(L, 2);
            
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_mLightWeaponSoulBagInitCount(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.ItemManager __cl_gen_to_be_invoked = (xc.ItemManager)translator.FastGetCSObj(L, 1);
                __cl_gen_to_be_invoked.mLightWeaponSoulBagInitCount = LuaAPI.xlua_touint(L, 2);
            
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_mLightWeaponSoulBagTotalCount(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.ItemManager __cl_gen_to_be_invoked = (xc.ItemManager)translator.FastGetCSObj(L, 1);
                __cl_gen_to_be_invoked.mLightWeaponSoulBagTotalCount = LuaAPI.xlua_touint(L, 2);
            
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_mLuckyTreasureBagMaxCount(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.ItemManager __cl_gen_to_be_invoked = (xc.ItemManager)translator.FastGetCSObj(L, 1);
                __cl_gen_to_be_invoked.mLuckyTreasureBagMaxCount = LuaAPI.xlua_touint(L, 2);
            
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_isForceShowfloatTips(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.ItemManager __cl_gen_to_be_invoked = (xc.ItemManager)translator.FastGetCSObj(L, 1);
                __cl_gen_to_be_invoked.isForceShowfloatTips = LuaAPI.lua_toboolean(L, 2);
            
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_mIsAutoHp(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.ItemManager __cl_gen_to_be_invoked = (xc.ItemManager)translator.FastGetCSObj(L, 1);
                __cl_gen_to_be_invoked.mIsAutoHp = LuaAPI.lua_toboolean(L, 2);
            
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_mIsAutoMp(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.ItemManager __cl_gen_to_be_invoked = (xc.ItemManager)translator.FastGetCSObj(L, 1);
                __cl_gen_to_be_invoked.mIsAutoMp = LuaAPI.lua_toboolean(L, 2);
            
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_mIconConfig(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.ItemManager __cl_gen_to_be_invoked = (xc.ItemManager)translator.FastGetCSObj(L, 1);
                __cl_gen_to_be_invoked.mIconConfig = (xc.WXIconAsset)translator.GetObject(L, 2, typeof(xc.WXIconAsset));
            
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_CurrentLockBagItem(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.ItemManager __cl_gen_to_be_invoked = (xc.ItemManager)translator.FastGetCSObj(L, 1);
                __cl_gen_to_be_invoked.CurrentLockBagItem = (System.Collections.Generic.Dictionary<ushort, xc.BagItemInfo>)translator.GetObject(L, 2, typeof(System.Collections.Generic.Dictionary<ushort, xc.BagItemInfo>));
            
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_StrengthInfos(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.ItemManager __cl_gen_to_be_invoked = (xc.ItemManager)translator.FastGetCSObj(L, 1);
                __cl_gen_to_be_invoked.StrengthInfos = (System.Collections.Generic.List<xc.EquipPosInfo>)translator.GetObject(L, 2, typeof(System.Collections.Generic.List<xc.EquipPosInfo>));
            
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_DecoratePosInfos(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.ItemManager __cl_gen_to_be_invoked = (xc.ItemManager)translator.FastGetCSObj(L, 1);
                __cl_gen_to_be_invoked.DecoratePosInfos = (System.Collections.Generic.List<xc.DecoratePosInfo>)translator.GetObject(L, 2, typeof(System.Collections.Generic.List<xc.DecoratePosInfo>));
            
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_GetSoulList(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.ItemManager __cl_gen_to_be_invoked = (xc.ItemManager)translator.FastGetCSObj(L, 1);
                __cl_gen_to_be_invoked.GetSoulList = (System.Collections.Generic.List<uint>)translator.GetObject(L, 2, typeof(System.Collections.Generic.List<uint>));
            
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_OpenSoulList(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.ItemManager __cl_gen_to_be_invoked = (xc.ItemManager)translator.FastGetCSObj(L, 1);
                __cl_gen_to_be_invoked.OpenSoulList = (System.Collections.Generic.List<uint>)translator.GetObject(L, 2, typeof(System.Collections.Generic.List<uint>));
            
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_BaptizeCount(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.ItemManager __cl_gen_to_be_invoked = (xc.ItemManager)translator.FastGetCSObj(L, 1);
                __cl_gen_to_be_invoked.BaptizeCount = LuaAPI.xlua_touint(L, 2);
            
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_mCloseQuickUseGoodsIdArray(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.ItemManager __cl_gen_to_be_invoked = (xc.ItemManager)translator.FastGetCSObj(L, 1);
                __cl_gen_to_be_invoked.mCloseQuickUseGoodsIdArray = (System.Collections.Generic.Dictionary<uint, bool>)translator.GetObject(L, 2, typeof(System.Collections.Generic.Dictionary<uint, bool>));
            
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_mHaveCheckPos(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.ItemManager __cl_gen_to_be_invoked = (xc.ItemManager)translator.FastGetCSObj(L, 1);
                __cl_gen_to_be_invoked.mHaveCheckPos = (System.Collections.Generic.Dictionary<string, bool>)translator.GetObject(L, 2, typeof(System.Collections.Generic.Dictionary<string, bool>));
            
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_mIdInCurShortCutWin(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.ItemManager __cl_gen_to_be_invoked = (xc.ItemManager)translator.FastGetCSObj(L, 1);
                __cl_gen_to_be_invoked.mIdInCurShortCutWin = LuaAPI.lua_touint64(L, 2);
            
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 0;
        }
        
		
		
		
		
    }
}
