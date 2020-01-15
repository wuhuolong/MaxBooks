/*----------------------------------------------------------------
// 文件名： HookSettingManager.cs
// 文件功能描述： 挂机设置管理类
// 注意，因为本设置的选项都是默认开启，而GlobalSettings那边的默认设置是0，所以这里0定义为开启，1为关闭
//----------------------------------------------------------------*/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using xc.ui;
using Net;
using xc.protocol;

namespace xc
{
    /// <summary>
    /// 挂机范围类型
    /// </summary>
    public enum EHookRangeType
    {
        InRange = 0,    // 当前屏
        FixedPos = 1,   // 定点
    }

    /// <summary>
    /// 挂机设置的物品信息，参考挂机设置表
    /// </summary>
    [wxb.Hotfix]
    public class HookGoodsSettingInfo
    {
        public enum ECondition
        {
            Yes = 0,
            Not = 1,
        }

        public enum EType
        {
            OtherAll = 0,               // 其他全部
            GoodsIds = 1,               // 物品id列表
            GoodsType = 2,              // 某类型的物品
            EquipCertainColor = 3,      // 某颜色的装备
            EquipUponCertainColor = 4,  // 某颜色以上的装备
            EquipPoses = 5,             // 装备部位列表
        }

        public HookGoodsSettingInfo()
        {
            Id = 0;
            Condition = ECondition.Yes;
            Type = EType.OtherAll;
            Params = new List<uint>();
            Params.Clear();
            Name = string.Empty;
            IsOn = true;
        }

        /// <summary>
        /// Id
        /// </summary>
        public uint Id { get; set; }

        /// <summary>
        /// 条件枚举
        /// </summary>
        public ECondition Condition { get; set; }

        /// <summary>
        /// 类型枚举
        /// </summary>
        public EType Type { get; set; }

        /// <summary>
        /// 参数列表
        /// </summary>
        public List<uint> Params { get; set; }

        /// <summary>
        /// 名字
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// 开关
        /// </summary>
        public bool IsOn { get; set; }
    }

    [wxb.Hotfix]
    public class HookSettingManager : xc.Singleton<HookSettingManager>
    {
        Utils.Timer mTimer;

        /// <summary>
        /// 挂机自动吃生命药水的生命值
        /// </summary>
        float mUseHPDrugHPRatio;
        public float UseHPDrugHPRatio
        {
            get
            {
                return mUseHPDrugHPRatio;
            }
            set
            {
                mUseHPDrugHPRatio = value;
                GlobalSettings.Instance.ChangePlayerSetting(GameConst.SETTING_KEY_HOOK_USE_HP_DRUG_HP_RATIO, (uint)(mUseHPDrugHPRatio * 100f));
            }
        }
        List<uint> mUseHPDrugGoodsIds = GameConstHelper.GetUintList("GAME_HOOK_USE_HP_DRUG_GOODS_ID");
        bool mIsUsingHPDrug = false; // 是否正在吃生命药水，即发了吃药的消息且服务端还没回复

        /// <summary>
        /// 挂机自动吃魔法药水的魔法值
        /// </summary>
        float mUseMPDrugMPRatio;
        public float UseMPDrugMPRatio
        {
            get
            {
                return mUseMPDrugMPRatio;
            }
            set
            {
                mUseMPDrugMPRatio = value;
                GlobalSettings.Instance.ChangePlayerSetting(GameConst.SETTING_KEY_HOOK_USE_MP_DRUG_MP_RATIO, (uint)(mUseMPDrugMPRatio * 100f));
            }
        }
        List<uint> mUseMPDrugGoodsIds = GameConstHelper.GetUintList("GAME_HOOK_USE_MP_DRUG_GOODS_ID");
        bool mIsUsingMPDrug = false; // 是否正在吃魔法药水，即发了吃药的消息且服务端还没回复

        /// <summary>
        /// 挂机范围类型
        /// </summary>
        EHookRangeType mRangeType;
        public EHookRangeType RangeType
        {
            get
            {
                return mRangeType;
            }
            set
            {
                mRangeType = value;
                GlobalSettings.Instance.ChangePlayerSetting(GameConst.SETTING_KEY_HOOK_RANGE_TYPE, (uint)(mRangeType));
            }
        }

        /// <summary>
        /// 挂机自动买药
        /// </summary>
        bool mAutoBuyDrug;
        public bool AutoBuyDrug
        {
            get
            {
                return mAutoBuyDrug;
            }
            set
            {
                mAutoBuyDrug = value;
                uint uintValue = (uint)((mAutoBuyDrug == true) ? 1 : 0);
                GlobalSettings.Instance.ChangePlayerSetting(GameConst.SETTING_KEY_HOOK_AUTO_BUY_DRUG, (uint)(uintValue));
            }
        }
        uint mAutoBuyHPDrugGoodsId = 0;
        uint mAutoBuyHPDrugNum = GameConstHelper.GetUint("GAME_HOOK_BUY_HP_DRUG_NUM");
        uint mAutoBuyHPDrugMoneyType;
        uint mAutoBuyHPDrugPrice;
        uint mAutoBuyMPDrugGoodsId = 0;
        uint mAutoBuyMPDrugNum = GameConstHelper.GetUint("GAME_HOOK_BUY_MP_DRUG_NUM");
        uint mAutoBuyMPDrugMoneyType;
        uint mAutoBuyMPDrugPrice;
        bool mIsBuyingDrug = false; // 是否正在买药，即发了买药的消息且服务端还没回复
        public void UpdateAutoBuyDrugGoodsId()
        {
            if (LocalPlayerManager.Instance.LocalActorAttribute != null)
            {
                uint level = LocalPlayerManager.Instance.LocalActorAttribute.Level;
                List<List<uint>> uintUintList = DBTextResource.ParseArrayUintUint(GameConstHelper.GetString("GAME_HOOK_BUY_HP_DRUG_GOODS_ID"));
                foreach (List<uint> uintList in uintUintList)
                {
                    if (level < uintList[0])
                    {
                        mAutoBuyHPDrugGoodsId = uintList[1];
                        break;
                    }
                }
                uintUintList = DBTextResource.ParseArrayUintUint(GameConstHelper.GetString("GAME_HOOK_BUY_MP_DRUG_GOODS_ID"));
                foreach (List<uint> uintList in uintUintList)
                {
                    if (level < uintList[0])
                    {
                        mAutoBuyMPDrugGoodsId = uintList[1];
                        break;
                    }
                }

                UpdateAutoBuyDrugGoodsPrice();
            }
        }

        public void UpdateAutoBuyDrugGoodsPrice()
        {
            object[] param = { DBMallType.BagShop, mAutoBuyHPDrugGoodsId };
            System.Type[] returnType = { typeof(int), typeof(int) };
            object[] objs = LuaScriptMgr.Instance.CallLuaFunction_return(LuaScriptMgr.Instance.Lua.Global, "MallDataManager_GetMoneyTypeAndPriceByGoodsId", param, returnType);
            if (objs != null && objs.Length > 1)
            {
                if (objs[0] != null)
                {
                    int a = (int)objs[0];
                    mAutoBuyHPDrugMoneyType = (uint)a;
                }
                else
                {
                    GameDebug.Log("MallDataManager_GetMoneyTypeAndPriceByGoodsId first return is null!!!");
                }
                if (objs[1] != null)
                {
                    int a = (int)objs[1];
                    mAutoBuyHPDrugPrice = (uint)a;
                }
                else
                {
                    GameDebug.Log("MallDataManager_GetMoneyTypeAndPriceByGoodsId second return is null!!!");
                }
            }

            object[] param1 = { DBMallType.BagShop, mAutoBuyMPDrugGoodsId };
            System.Type[] returnType1 = { typeof(int), typeof(int) };
            object[] objs1 = LuaScriptMgr.Instance.CallLuaFunction_return(LuaScriptMgr.Instance.Lua.Global, "MallDataManager_GetMoneyTypeAndPriceByGoodsId", param1, returnType1);
            if (objs1 != null && objs1.Length > 1)
            {
                if (objs1[0] != null)
                {
                    int a = (int)objs1[0];
                    mAutoBuyMPDrugMoneyType = (uint)a;
                }
                else
                {
                    GameDebug.Log("MallDataManager_GetMoneyTypeAndPriceByGoodsId first return is null!!!");
                }
                if (objs1[1] != null)
                {
                    int a = (int)objs1[1];
                    mAutoBuyMPDrugPrice = (uint)a;
                }
                else
                {
                    GameDebug.Log("MallDataManager_GetMoneyTypeAndPriceByGoodsId second return is null!!!");
                }
            }
        }

        /// <summary>
        /// 挂机自动吞噬
        /// </summary>
        bool mAutoSwallow;
        public bool AutoSwallow
        {
            get
            {
                return mAutoSwallow;
            }
            set
            {
                mAutoSwallow = value;
                uint uintValue = (uint)((mAutoSwallow == true) ? 1 : 0);
                GlobalSettings.Instance.ChangePlayerSetting(GameConst.SETTING_KEY_HOOK_AUTO_SWALLOW, (uint)(uintValue));
            }
        }

        /// <summary>
        /// 挂机自动复活
        /// </summary>
        bool mAutoRevive;
        public bool AutoRevive
        {
            get
            {
                return mAutoRevive;
            }
            set
            {
                mAutoRevive = value;
                uint uintValue = (uint)((mAutoRevive == true) ? 1 : 0);
                GlobalSettings.Instance.ChangePlayerSetting(GameConst.SETTING_KEY_HOOK_AUTO_REVIVE, (uint)(uintValue));
            }
        }

        /// <summary>
        /// 挂机自动出售物品
        /// </summary>
        bool mAutoSellGoods;
        public bool AutoSellGoods
        {
            get
            {
                return mAutoSellGoods;
            }
            set
            {
                mAutoSellGoods = value;
                uint uintValue = (uint)((mAutoSellGoods == true) ? 1 : 0);
                GlobalSettings.Instance.ChangePlayerSetting(GameConst.SETTING_KEY_HOOK_AUTO_SELL_GOODS, (uint)(uintValue));

                if (mAutoSellGoods == true)
                {
                    CheckAllGoodsAndSellGoods();
                }
            }
        }
        bool mIsSellingGoods = false; // 是否正在出售物品，即发了出售的消息且服务端还没回复

        /// <summary>
        /// 需要自动出售的物品配置信息
        /// </summary>
        Dictionary<uint, HookGoodsSettingInfo> mAutoSellGoodsInfos;

        /// <summary>
        /// 不需要需要自动出售的物品配置信息
        /// </summary>
        Dictionary<uint, HookGoodsSettingInfo> mDoNotAutoSellGoodsInfos;

        /// <summary>
        /// 挂机自动拾取
        /// </summary>
        bool mAutoPickDrop;
        public bool AutoPickDrop
        {
            get
            {
                return mAutoPickDrop;
            }
            set
            {
                mAutoPickDrop = value;
                uint uintValue = (uint)((mAutoPickDrop == true) ? 1 : 0);
                GlobalSettings.Instance.ChangePlayerSetting(GameConst.SETTING_KEY_HOOK_AUTO_PICK_DROP_PREFIX, (uint)(uintValue));
            }
        }

        Dictionary<uint, HookGoodsSettingInfo> mAutoPickDropInfos;
        public Dictionary<uint, HookGoodsSettingInfo> AutoPickDropInfos
        {
            get
            {
                return mAutoPickDropInfos;
            }
        }

        /// <summary>
        /// 获取具体某种类型的拾取设置
        /// </summary>
        /// <param name="id">自动拾取配置表里面的id</param>
        /// <returns></returns>
        public bool GetAutoPickDrop(uint id)
        {
            foreach (HookGoodsSettingInfo hookGoodsSettingInfo in mAutoPickDropInfos.Values)
            {
                if (hookGoodsSettingInfo.Id == id)
                {
                    return hookGoodsSettingInfo.IsOn;
                }
            }

            return false;
        }

        /// <summary>
        /// 设置具体某种类型的拾取设置
        /// </summary>
        /// <param name="id">自动拾取配置表里面的id</param>
        /// <param name="isOn">是否自动拾取</param>
        public void SetAutoPickDrop(uint id, bool isOn)
        {
            foreach (HookGoodsSettingInfo hookGoodsSettingInfo in mAutoPickDropInfos.Values)
            {
                if (hookGoodsSettingInfo.Id == id)
                {
                    hookGoodsSettingInfo.IsOn = isOn;
                }
            }
        }

        public void ChangeAutoPickDropSetting(uint id, bool isOn)
        {
            uint uintValue = (uint)((isOn == true) ? 1 : 0);
            GlobalSettings.Instance.ChangePlayerSetting(GameConst.SETTING_KEY_HOOK_AUTO_PICK_DROP_PREFIX + id, (uint)(uintValue));
        }

        public HookSettingManager()
        {
            if (mAutoSellGoodsInfos == null)
            {
                mAutoSellGoodsInfos = ReadHookSettingGoodsInfos("hook_auto_sell_goods_setting", HookGoodsSettingInfo.ECondition.Yes);
            }
            if (mDoNotAutoSellGoodsInfos == null)
            {
                mDoNotAutoSellGoodsInfos = ReadHookSettingGoodsInfos("hook_auto_sell_goods_setting", HookGoodsSettingInfo.ECondition.Not);
            }
            if (mAutoPickDropInfos == null)
            {
                mAutoPickDropInfos = ReadHookSettingGoodsInfos("hook_pick_drop_setting", HookGoodsSettingInfo.ECondition.Yes);
            }
        }

        public void Reset()
        {
            foreach (Dictionary<string, string> row in DBManager.Instance.QuerySqliteTable<string>(GlobalConfig.DBFile, "data_persional_default"))
            {
                uint id = 0;
                uint.TryParse(row["id"], out id);
                uint defaultValue = 0;
                uint.TryParse(row["default"], out defaultValue);
                switch (id)
                {
                    case GameConst.SETTING_KEY_HOOK_USE_HP_DRUG_HP_RATIO:
                        {
                            mUseHPDrugHPRatio = ((float)defaultValue) / 100f;
                            break;
                        }
                    case GameConst.SETTING_KEY_HOOK_USE_MP_DRUG_MP_RATIO:
                        {
                            mUseMPDrugMPRatio = ((float)defaultValue) / 100f;
                            break;
                        }
                    case GameConst.SETTING_KEY_HOOK_RANGE_TYPE:
                        {
                            mRangeType = (EHookRangeType)defaultValue;
                            break;
                        }
                    case GameConst.SETTING_KEY_HOOK_AUTO_BUY_DRUG:
                        {
                            mAutoBuyDrug = (defaultValue > 0) ? true : false;
                            break;
                        }
                    case GameConst.SETTING_KEY_HOOK_AUTO_SWALLOW:
                        {
                            mAutoSwallow = (defaultValue > 0) ? true : false;
                            break;
                        }
                    case GameConst.SETTING_KEY_HOOK_AUTO_REVIVE:
                        {
                            mAutoRevive = (defaultValue > 0) ? true : false;
                            break;
                        }
                    case GameConst.SETTING_KEY_HOOK_AUTO_SELL_GOODS:
                        {
                            mAutoSellGoods = (defaultValue > 0) ? true : false;
                            break;
                        }
                    case GameConst.SETTING_KEY_HOOK_AUTO_PICK_DROP_PREFIX:
                        {
                            mAutoPickDrop = (defaultValue > 0) ? true : false;
                            break;
                        }
                    default:
                        break;
                }
            }

            mAutoBuyHPDrugGoodsId = 0;
            mAutoBuyHPDrugMoneyType = 0;
            mAutoBuyHPDrugPrice = 0;
            mAutoBuyMPDrugGoodsId = 0;
            mAutoBuyMPDrugMoneyType = 0;
            mAutoBuyMPDrugPrice = 0;

            mIsBuyingDrug = false;
            mIsSellingGoods = false;
            mIsUsingHPDrug = false;
            mIsUsingMPDrug = false;

            if (mTimer != null)
            {
                mTimer.Destroy();
                mTimer = null;
            }
            mTimer = new Utils.Timer(5000, true, Mathf.Infinity, UpdateTimer);

            mUseHPDrugGoodsIds = GameConstHelper.GetUintList("GAME_HOOK_USE_HP_DRUG_GOODS_ID");
            mUseMPDrugGoodsIds = GameConstHelper.GetUintList("GAME_HOOK_USE_MP_DRUG_GOODS_ID");
            mAutoBuyHPDrugNum = GameConstHelper.GetUint("GAME_HOOK_BUY_HP_DRUG_NUM");
            mAutoBuyMPDrugNum = GameConstHelper.GetUint("GAME_HOOK_BUY_MP_DRUG_NUM");
        }

        void UpdateTimer(float deltaTime)
        {
            // 这个计时器是为了将下面的状态变量重置，因为如果向服务端发送协议失败，这些变量就可能永远都是true
            mIsSellingGoods = false;
            mIsUsingHPDrug = false;
            mIsUsingMPDrug = false;
        }

        public void RegisterMessages()
        {
            ClientEventMgr.GetInstance().SubscribeClientEvent((int)ClientEvent.CE_SETTING_CHANGED, OnPlayerSettingsChanged);
            ClientEventMgr.GetInstance().SubscribeClientEvent((int)ClientEvent.CE_AUTO_FIGHT_STATE_CHANGED, OnAutoFightStateChangedChanged);
            ClientEventMgr.GetInstance().SubscribeClientEvent((int)ClientEvent.CE_MALL_RECV_SHOP_GOODS, OnMallRecvShopGoods);
            ClientEventMgr.GetInstance().SubscribeClientEvent((int)ClientEvent.CE_BAG_ADD, OnBagAdd);
            ClientEventMgr.GetInstance().SubscribeClientEvent((int)ClientEvent.CE_BAG_UPDATE, OnBagUpdate);
            ClientEventMgr.GetInstance().SubscribeClientEvent((int)ClientEvent.CE_INSTALL_1_UPDATE, OnInstall1Update);
            ClientEventMgr.GetInstance().SubscribeClientEvent((int)ClientEvent.CE_SWITCHINSTANCE, OnSwitchInstance);
            ClientEventMgr.GetInstance().SubscribeClientEvent((int)ClientEvent.CE_ACTOR_LEVEL_UPDATE, OnActorLevelUpdate);

            Game.GetInstance().SubscribeNetNotify(NetMsg.MSG_PLAYER_HANG_SETTLE, HandleServerData);
        }

        public void Update()
        {
            if (Game.Instance.AllSystemInited == false)
            {
                return;
            }

            // 自动吃药
            if (mIsUsingHPDrug == false && mUseHPDrugHPRatio > 0f && LocalPlayerManager.Instance.LocalActorAttribute != null)
            {
                long hp = LocalPlayerManager.Instance.LocalActorAttribute.HP;
                long hpMax = LocalPlayerManager.Instance.LocalActorAttribute.HPMax;
                if (hp > 0 && ((double)hp / (double)hpMax) < mUseHPDrugHPRatio)
                {
                    foreach (uint useHPDrugGoodsId in mUseHPDrugGoodsIds)
                    {
                        if (SceneHelp.Instance.ForbidUseGoods(useHPDrugGoodsId) == false && GoodsHelper.CheckGoodsCanUse(useHPDrugGoodsId) == true && ItemManager.Instance.GetGoodsNumForBagByTypeId(useHPDrugGoodsId) > 0)
                        {
                            if (GoodsHelper.CheckUseGoodsIsInCD(useHPDrugGoodsId) == false)
                            {
                                ItemManager.Instance.UseGoods(useHPDrugGoodsId, 1);
                                mIsUsingHPDrug = true;
                                return;
                            }

                            break;
                        }
                    }
                }
            }
            if (mIsUsingMPDrug == false && mUseMPDrugMPRatio > 0f && LocalPlayerManager.Instance.LocalActorAttribute != null)
            {
                long mp = LocalPlayerManager.Instance.LocalActorAttribute.MP;
                long mpMax = LocalPlayerManager.Instance.LocalActorAttribute.MPMax;
                if (mp > 0 && ((double)mp / (double)mpMax) < mUseMPDrugMPRatio)
                {
                    foreach (uint useMPDrugGoodsId in mUseMPDrugGoodsIds)
                    {
                        if (SceneHelp.Instance.ForbidUseGoods(useMPDrugGoodsId) == false && GoodsHelper.CheckGoodsCanUse(useMPDrugGoodsId) == true && ItemManager.Instance.GetGoodsNumForBagByTypeId(useMPDrugGoodsId) > 0)
                        {
                            if (GoodsHelper.CheckUseGoodsIsInCD(useMPDrugGoodsId) == false)
                            {
                                ItemManager.Instance.UseGoods(useMPDrugGoodsId, 1);
                                mIsUsingMPDrug = true;
                                return;
                            }

                            break;
                        }
                    }
                }
            }

            // 自动买药
            if (mAutoBuyDrug == true && mIsBuyingDrug == false)
            {
                if (mAutoBuyHPDrugGoodsId > 0)
                {
                    ulong hpDrugNum = ItemManager.Instance.GetGoodsNumForBagByTypeId(mAutoBuyHPDrugGoodsId);
                    if (hpDrugNum < 3)
                    {
                        if (LocalPlayerManager.Instance.GetMoneyByConst((ushort)mAutoBuyHPDrugMoneyType) >= mAutoBuyHPDrugPrice * mAutoBuyHPDrugNum)
                        {
                            BuyGoods(DBMallType.BagShop, mAutoBuyHPDrugGoodsId, mAutoBuyHPDrugNum);
                        }
                    }
                }

                if (mAutoBuyMPDrugGoodsId > 0)
                {
                    ulong mpDrugNum = ItemManager.Instance.GetGoodsNumForBagByTypeId(mAutoBuyMPDrugGoodsId);
                    if (mpDrugNum < 3)
                    {
                        if (LocalPlayerManager.Instance.GetMoneyByConst((ushort)mAutoBuyMPDrugMoneyType) >= mAutoBuyMPDrugPrice * mAutoBuyMPDrugNum)
                        {
                            BuyGoods(DBMallType.BagShop, mAutoBuyMPDrugGoodsId, mAutoBuyMPDrugNum);
                        }
                    }
                }
            }
        }

        Dictionary<uint, HookGoodsSettingInfo> ReadHookSettingGoodsInfos(string tableName, HookGoodsSettingInfo.ECondition condition)
        {
            Dictionary<uint, HookGoodsSettingInfo> hookSettingGoodsInfos = new Dictionary<uint, HookGoodsSettingInfo>();
            hookSettingGoodsInfos.Clear();

            List<Dictionary<string, string>> datas = DBManager.Instance.QuerySqliteTable<string>(GlobalConfig.DBFile, tableName);
            foreach (Dictionary<string, string> row in datas)
            {
                HookGoodsSettingInfo hookSettingGoodsInfo = new HookGoodsSettingInfo();
                foreach (KeyValuePair<string, string> kv in row)
                {
                    if (kv.Key == "id")
                    {
                        hookSettingGoodsInfo.Id = DBTextResource.ParseUI_s(kv.Value, 0);
                    }
                    else if (kv.Key == "condition")
                    {
                        hookSettingGoodsInfo.Condition = (HookGoodsSettingInfo.ECondition)DBTextResource.ParseUI_s(kv.Value, 0);
                    }
                    else if (kv.Key == "type")
                    {
                        hookSettingGoodsInfo.Type = (HookGoodsSettingInfo.EType)DBTextResource.ParseUI_s(kv.Value, 0);
                    }
                    else if (kv.Key == "param")
                    {
                        switch (hookSettingGoodsInfo.Type)
                        {
                            case HookGoodsSettingInfo.EType.OtherAll:
                                {
                                    break;
                                }
                            case HookGoodsSettingInfo.EType.GoodsIds:
                                {
                                    hookSettingGoodsInfo.Params = DBTextResource.ParseArrayUint(kv.Value, ",");
                                    break;
                                }
                            case HookGoodsSettingInfo.EType.GoodsType:
                                {
                                    hookSettingGoodsInfo.Params = DBTextResource.ParseArrayUint(kv.Value, ",");
                                    break;
                                }
                            case HookGoodsSettingInfo.EType.EquipCertainColor:
                                {
                                    hookSettingGoodsInfo.Params = new List<uint>();
                                    hookSettingGoodsInfo.Params.Clear();
                                    hookSettingGoodsInfo.Params.Add(DBTextResource.ParseUI_s(kv.Value, 0));
                                    break;
                                }
                            case HookGoodsSettingInfo.EType.EquipUponCertainColor:
                                {
                                    hookSettingGoodsInfo.Params = new List<uint>();
                                    hookSettingGoodsInfo.Params.Clear();
                                    hookSettingGoodsInfo.Params.Add(DBTextResource.ParseUI_s(kv.Value, 0));
                                    break;
                                }
                            case HookGoodsSettingInfo.EType.EquipPoses:
                                {
                                    hookSettingGoodsInfo.Params = DBTextResource.ParseArrayUint(kv.Value, ",");
                                    break;
                                }
                            default:
                                break;
                        }
                    }
                    else if (kv.Key == "name")
                    {
                        hookSettingGoodsInfo.Name = kv.Value;
                    }
                }
                hookSettingGoodsInfo.IsOn = true;

                if (condition == hookSettingGoodsInfo.Condition)
                {
                    hookSettingGoodsInfos.Add(hookSettingGoodsInfo.Id, hookSettingGoodsInfo);
                }
            }

            return hookSettingGoodsInfos;
        }

        public bool CheckIsInAutoPickDropGoodsSettingInfo(uint goodsId)
        {
            if (mAutoPickDrop == false)
            {
                return false;
            }

            foreach (HookGoodsSettingInfo hookGoodsSettingInfo in mAutoPickDropInfos.Values)
            {
                if (hookGoodsSettingInfo.IsOn == true && CheckMeetGoodsSettingInfoCondition(goodsId, hookGoodsSettingInfo, mAutoPickDropInfos, "auto_pick_drop") == true)
                {
                    return true;
                }
            }

            return false;
        }

        /// <summary>
        /// 该gid的物品是否满足GoodsSettingInfo的条件
        /// </summary>
        /// <returns></returns>
        Dictionary<string, bool> mGoodsSettingInfoConditionsCache = null;    // 条件缓存
        bool CheckMeetGoodsSettingInfoCondition(uint goodsId, HookGoodsSettingInfo hookGoodsSettingInfo, Dictionary<uint, HookGoodsSettingInfo> hookGoodsSettingInfos, string cacheKeyPrefix)
        {
            System.Text.StringBuilder sb = new System.Text.StringBuilder();
            sb.Append(cacheKeyPrefix);
            sb.Append("_");
            sb.Append(goodsId);
            sb.Append("_");
            sb.Append(hookGoodsSettingInfo.Id);
            string cacheKey = sb.ToString();

            if (mGoodsSettingInfoConditionsCache == null)
            {
                mGoodsSettingInfoConditionsCache = new Dictionary<string, bool>();
                mGoodsSettingInfoConditionsCache.Clear();
            }
            if (mGoodsSettingInfoConditionsCache.ContainsKey(cacheKey) == true)
            {
                return mGoodsSettingInfoConditionsCache[cacheKey];
            }

            bool ret = false;
            switch (hookGoodsSettingInfo.Type)
            {
                case HookGoodsSettingInfo.EType.OtherAll:
                    {
                        Dictionary<uint, HookGoodsSettingInfo> otherAllHookGoodsSettingInfos = new Dictionary<uint, HookGoodsSettingInfo>();
                        otherAllHookGoodsSettingInfos.Clear();
                        foreach (HookGoodsSettingInfo otherHookGoodsSettingInfo in hookGoodsSettingInfos.Values)
                        {
                            if (otherHookGoodsSettingInfo.Type != HookGoodsSettingInfo.EType.OtherAll)
                            {
                                otherAllHookGoodsSettingInfos.Add(otherHookGoodsSettingInfo.Id, otherHookGoodsSettingInfo);
                            }
                        }
                        ret = true;
                        foreach (HookGoodsSettingInfo otherHookGoodsSettingInfo in otherAllHookGoodsSettingInfos.Values)
                        {
                            if (CheckMeetGoodsSettingInfoCondition(goodsId, otherHookGoodsSettingInfo, otherAllHookGoodsSettingInfos, "other_all_hook_goods_setting") == true)
                            {
                                ret = false;
                                break;
                            }
                        }
                        break;
                    }
                case HookGoodsSettingInfo.EType.GoodsIds:
                    {
                        if (hookGoodsSettingInfo.Params.Contains(goodsId) == true)
                        {
                            ret = true;
                            break;
                        }
                        break;
                    }
                case HookGoodsSettingInfo.EType.GoodsType:
                    {
                        uint goodsType = GoodsHelper.GetGoodsType(goodsId);
                        uint goodsSubType = GoodsHelper.GetGoodsSubType(goodsId);
                        if (hookGoodsSettingInfo.Params.Count >= 2)
                        {
                            if (goodsType == hookGoodsSettingInfo.Params[0] && goodsSubType == hookGoodsSettingInfo.Params[1])
                            {
                                ret = true;
                                break;
                            }
                        }
                        break;
                    }
                case HookGoodsSettingInfo.EType.EquipCertainColor:
                    {
                        uint goodsType = GoodsHelper.GetGoodsType(goodsId);
                        if (goodsType == GameConst.GIVE_TYPE_EQUIP)
                        {
                            uint color = GoodsHelper.GetGoodsColorTypeByTypeId(goodsId);
                            if (color == hookGoodsSettingInfo.Params[0])
                            {
                                ret = true;
                                break;
                            }
                        }
                        break;
                    }
                case HookGoodsSettingInfo.EType.EquipUponCertainColor:
                    {
                        uint goodsType = GoodsHelper.GetGoodsType(goodsId);
                        if (goodsType == GameConst.GIVE_TYPE_EQUIP)
                        {
                            uint color = GoodsHelper.GetGoodsColorTypeByTypeId(goodsId);
                            if (color >= hookGoodsSettingInfo.Params[0])
                            {
                                ret = true;
                                break;
                            }
                        }
                        break;
                    }
                case HookGoodsSettingInfo.EType.EquipPoses:
                    {
                        uint pos = xc.Equip.EquipHelper.GetEquipPosByGid(goodsId);
                        foreach (uint param in hookGoodsSettingInfo.Params)
                        {
                            if (pos == param)
                            {
                                ret = true;
                                break;
                            }
                        }
                        break;
                    }
                default:
                    break;
            }

            mGoodsSettingInfoConditionsCache.Add(cacheKey, ret);
            return ret;
        }

        /// <summary>
        /// 检查指定物品是否可以自动出售
        /// </summary>
        /// <param name="goods"></param>
        bool CheckCanSellGoods(Goods goods)
        {
            if (goods == null)
            {
                return false;
            }

            // 装备评分高于该部位已装备的评分则不出售
            GoodsEquip goodsEquip = goods as GoodsEquip;
            if (goodsEquip != null)
            {
                List<GoodsEquip> installEquipList = xc.Equip.EquipHelper.GetInstallEquipListByPos(goodsEquip.EquipPos);
                if (installEquipList != null && installEquipList.Count > 0)
                {
                    foreach (GoodsEquip installEquip in installEquipList)
                    {
                        if (goodsEquip.EquipRank >= installEquip.EquipRank)
                        {
                            return false;
                        }
                    }
                }
                // 如果身上没有穿这个装备，则不出售
                else
                {
                    return false;
                }
            }

            ulong oid = goods.id;
            uint goodsId = goods.type_idx;
            ulong num = goods.num;

            // 先判断是否是不需要出售的物品
            foreach (HookGoodsSettingInfo hookGoodsSettingInfo in mDoNotAutoSellGoodsInfos.Values)
            {
                if (CheckMeetGoodsSettingInfoCondition(goodsId, hookGoodsSettingInfo, mDoNotAutoSellGoodsInfos, "do_not_auto_sell_goods") == true)
                {
                    return false;
                }
            }

            foreach (HookGoodsSettingInfo hookGoodsSettingInfo in mAutoSellGoodsInfos.Values)
            {
                if (CheckMeetGoodsSettingInfoCondition(goodsId, hookGoodsSettingInfo, mAutoSellGoodsInfos, "auto_sell_goods") == true)
                {
                    return true;
                }
            }

            return false;
        }

        /// <summary>
        /// 检查指定gid的物品是否可以自动出售，可以的话马上出售
        /// </summary>
        void CheckAndSellGoods(Goods goods)
        {
            if (CheckCanSellGoods(goods) == true)
            {
                GoodsEquip goodsEquip = goods as GoodsEquip;
                // 如果是装备则发送回收协议
                if (goodsEquip != null)
                {
                    ItemManager.Instance.RecycleGoods(new List<ulong> { goods.id }, 0);
                }
                else
                {
                    ItemManager.Instance.SellGoods(goods.id, (uint)goods.num);
                }
                mIsSellingGoods = true;
            }
        }

        /// <summary>
        /// 检查所有物品并自动出售
        /// </summary>
        void CheckAllGoodsAndSellGoods()
        {
            // 需要批量出售的装备列表
            List<ulong> equipListToSell = new List<ulong>();
            equipListToSell.Clear();

            foreach (Goods goods in ItemManager.Instance.BagGoodsOids.Values)
            {
                if (CheckCanSellGoods(goods) == true)
                {
                    GoodsEquip goodsEquip = goods as GoodsEquip;
                    if (goodsEquip != null)
                    {
                        equipListToSell.Add(goods.id);
                    }
                    else
                    {
                        // 非装备物品一个一个地出售
                        ItemManager.Instance.SellGoods(goods.id, (uint)goods.num);
                    }
                }
            }

            // 装备可以多种装备批量出售
            if (equipListToSell.Count > 0)
            {
                ItemManager.Instance.RecycleGoods(equipListToSell, 0);
            }

            mIsSellingGoods = true;
        }

        void OnPlayerSettingsChanged(CEventBaseArgs data)
        {
            bool isSettingHookChanged = false;

            foreach (PkgPlayerPersonality settingInfo in GlobalSettings.Instance.PlayerSettings)
            {
                switch (settingInfo.type)
                {
                    case GameConst.SETTING_KEY_HOOK_USE_HP_DRUG_HP_RATIO:
                        {
                            mUseHPDrugHPRatio = (float)(settingInfo.value) / 100f;
                            isSettingHookChanged = true;
                            break;
                        }
                    case GameConst.SETTING_KEY_HOOK_USE_MP_DRUG_MP_RATIO:
                        {
                            mUseMPDrugMPRatio = (float)(settingInfo.value) / 100f;
                            isSettingHookChanged = true;
                            break;
                        }
                    case GameConst.SETTING_KEY_HOOK_RANGE_TYPE:
                        {
                            mRangeType = (EHookRangeType)settingInfo.value;
                            isSettingHookChanged = true;
                            break;
                        }
                    case GameConst.SETTING_KEY_HOOK_AUTO_BUY_DRUG:
                        {
                            mAutoBuyDrug = settingInfo.value == 0 ? false : true;
                            isSettingHookChanged = true;
                            break;
                        }
                    case GameConst.SETTING_KEY_HOOK_AUTO_SWALLOW:
                        {
                            mAutoSwallow = settingInfo.value == 0 ? false : true;
                            isSettingHookChanged = true;
                            break;
                        }
                    case GameConst.SETTING_KEY_HOOK_AUTO_REVIVE:
                        {
                            mAutoRevive = settingInfo.value == 0 ? false : true;
                            isSettingHookChanged = true;
                            break;
                        }
                    case GameConst.SETTING_KEY_HOOK_AUTO_SELL_GOODS:
                        {
                            mAutoSellGoods = settingInfo.value == 0 ? false : true;
                            isSettingHookChanged = true;
                            break;
                        }
                    case GameConst.SETTING_KEY_HOOK_AUTO_PICK_DROP_PREFIX:
                        {
                            mAutoPickDrop = settingInfo.value == 0 ? false : true;
                            isSettingHookChanged = true;
                            break;
                        }
                    default:
                        break;
                }

                HookGoodsSettingInfo hookGoodsSettingInfo = null;
                int hookGoodsSettingInfoId = (int)(settingInfo.type) - (int)(GameConst.SETTING_KEY_HOOK_AUTO_PICK_DROP_PREFIX);
                if (hookGoodsSettingInfoId > 0)
                {
                    if (mAutoPickDropInfos.TryGetValue((uint)(hookGoodsSettingInfoId), out hookGoodsSettingInfo) == true && hookGoodsSettingInfo != null)
                    {
                        SetAutoPickDrop((uint)(hookGoodsSettingInfoId), settingInfo.value == 0 ? false : true);
                        isSettingHookChanged = true;
                    }
                }
            }

            if (isSettingHookChanged == true)
            {
                ClientEventMgr.GetInstance().FireEvent((int)ClientEvent.CE_SETTING_HOOK_CHANGED, null);
            }
        }

        void OnAutoFightStateChangedChanged(CEventBaseArgs data)
        {
            if (mAutoSellGoods == true)
            {
                CheckAllGoodsAndSellGoods();
            }
        }

        void OnMallRecvShopGoods(CEventBaseArgs data)
        {
            string argStr = data.arg.ToString();
            if (DBTextResource.ParseUI_s(argStr, 0) == DBMallType.BagShop)
            {
                UpdateAutoBuyDrugGoodsPrice();
            }
        }

        void OnBagAdd(CEventBaseArgs data)
        {
            mIsBuyingDrug = false;

            PkgGoodsInfo pkgGoodsInfo = data.arg as PkgGoodsInfo;
            if (pkgGoodsInfo != null)
            {
                if (mAutoSellGoods == true)
                {
                    Goods goods = ItemManager.Instance.GetGoodsForBagByOId(pkgGoodsInfo.oid);
                    CheckAndSellGoods(goods);
                }
            }
        }

        void OnBagUpdate(CEventBaseArgs data)
        {
            mIsSellingGoods = false;
            mIsUsingHPDrug = false;
            mIsUsingMPDrug = false;
        }

        void OnInstall1Update(CEventBaseArgs data)
        {
            if (mAutoSellGoods == true)
            {
                CheckAllGoodsAndSellGoods();
            }
        }

        void OnSwitchInstance(CEventBaseArgs data)
        {
            UpdateAutoBuyDrugGoodsId();
        }

        void OnActorLevelUpdate(CEventBaseArgs data)
        {
            //UpdateAutoBuyDrugGoodsId();
        }

        void BuyGoods(uint mallType, uint goodsId, uint num)
        {
            if (ItemManager.Instance.BagIsFull(1) == true)
            {
                return;
            }

            var data = new C2SShopBuy();
            data.type = mallType;
            data.gid = goodsId;
            data.num = num;
            NetClient.GetBaseClient().SendData<C2SShopBuy>(protocol.NetMsg.MSG_SHOP_BUY, data);

            mIsBuyingDrug = true;
            SafeCoroutine.CoroutineManager.StartCoroutine(BuyDrugEndCoroutine());
        }

        IEnumerator BuyDrugEndCoroutine()
        {
            yield return new SafeCoroutine.SafeWaitForSeconds(5f);

            mIsBuyingDrug = false;
        }

        void HandleServerData(ushort protocol, byte[] data)
        {
            switch (protocol)
            {
                case NetMsg.MSG_PLAYER_HANG_SETTLE:
                    {
                        S2CPlayerHangSettle pack = S2CPackBase.DeserializePack<S2CPlayerHangSettle>(data);
                        ClientEventMgr.GetInstance().PostEvent((int)ClientEvent.CE_SETTING_OFFLINE_REWARD, new CEventBaseArgs(pack));
                        break;
                    }
                default:
                    break;
            }
        }
    }
}
