using UnityEngine;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using xc.protocol;
using xc.ui;
using System.Collections;
using System.Collections.Generic;
using Net;
using Utils;
using System.Xml;
using XLua;
using System;
using xc.Decorate;
using xc.ElementEquip;

namespace xc
{
    //当前背包格子数据
    /// <summary>
    /// 因为目前开格子设计是必须一个一个开格子并且格子必须倒计时到了才让开
    /// </summary>
    [wxb.Hotfix]
    public class BagItemInfo
    {
        public uint Idx = 1;//服务端是从1开始
        public uint StartTime = 0;//倒计时开始时间戳
        public uint EndTime = 0;//倒计时结束时间戳
        public List<Goods> CostGoods;//消耗的物品
        
    }

    /// <summary>
    /// 部位结构
    /// </summary>
    [wxb.Hotfix]
    public class EquipPosInfo
    {
        public uint Pos = GameConst.POS_WEAPON;
        public uint Index = 1;
        public bool IsCanStrength = false;//是否可强化
        public uint SortId = 1;//排序等级
        public uint StrengthLv = 0;//强化等级
        public uint StrengthDegree = 0;//强化熟练度
        public uint StrengthMaxDegree = 0;//最大强化熟练度
        public PkgGoodsGidnum StrengthStuff;
        public PkgGoodsGidnum StrengthShowRedPointGoods;
        public GoodsEquip InstallPosEquip;
        public ActorAttribute AllBaptizeAttr = new ActorAttribute();
        public uint BaptizeNeedLv = 0;//洗练需要等级
        public Dictionary<uint,EquipBaptizeInfo> BaptizeInfos = new Dictionary<uint, EquipBaptizeInfo>();//默认会推4条

        /// <summary>
        /// 是否达到最大强化等级
        /// </summary>
        public bool ReachMaxStrengthLv
        {
            get
            {
                if (InstallPosEquip != null)
                {
                    return StrengthLv >= InstallPosEquip.MaxStrengthLv;
                }

                return false;
            }
        }
    }

    /// <summary>
    /// 洗练结构
    /// </summary>
    [wxb.Hotfix]
    public class EquipBaptizeInfo
    {
        public EquipBaptizeInfo()
        {
        }
        public EquipBaptizeInfo(uint id , uint state , PkgAttrElm attr , uint pos , uint index)
        {
            Id = id;
            Pos = pos;
            Index = index;
            State = (EquipBaptizeState)state;

            DBBaptizeGroove.DBBaptizeGrooveInfo dbBaptizeGrooveInfo = DBManager.Instance.GetDB<DBBaptizeGroove>().GetOneInfo(id);
            if (dbBaptizeGrooveInfo != null)
            {
                OpenCosts.Clear();
                OpenCosts = dbBaptizeGrooveInfo.Cost;
                AttrAdd = dbBaptizeGrooveInfo.AttrAddition;
            }

            BaptizeAttr = new ActorAttribute();
            if(attr != null)
                BaptizeAttr.Add(attr.attr, attr.value);
        }
        public enum EquipBaptizeState
        {
            NO_Open = 0,//未开启
            Open,//开启未锁定
            Lock,
        }
        public uint Pos = GameConst.POS_WEAPON;
        public uint Index = 1;
        public uint Id = 1;//洗练槽索引
        public EquipBaptizeState State = EquipBaptizeState.NO_Open;///洗练槽状态
        public ActorAttribute BaptizeAttr;//洗练属性
        public uint AttrAdd = 0;//洗练槽属性加成
        public Dictionary<uint, uint> OpenCosts = new Dictionary<uint, uint>();
        public uint Color = 0;//根据服务端下发的值确定品质颜色
    }

    /// <summary>
    /// 饰品部位附魔属性结构
    /// </summary>
    [wxb.Hotfix]
    public class DecorateAppendAttr
    {
        public uint AttrId; // 属性id
        public float Value; // 属性值
        public int OpenLv; // 开启等级 
        public uint BreakLv; // 突破等级
        public bool IsOpen = false; // 是否开启
    }

    /// <summary>
    /// 饰品部位结构
    /// </summary>
    [wxb.Hotfix]
    public class DecoratePosInfo
    {
        public uint Pos = 0;
        public bool IsUnlock = false;   // 是否已解锁
        public uint SortId = 1; //排序等级
        public uint StrengthLv = 0; //强化等级
        public uint StrengthMaxLv = 0;  //最大强化等级
        public uint StrengthValue = 0;  //强化熟练度
        public uint StrengthMaxValue = 0;   //最大强化熟练度
        public uint BreakLv = 0; // 突破等级
        public bool IsNeedBreak = false; // 是否需要突破
        public List<DecorateAppendAttr> AppendAttrs = new List<DecorateAppendAttr>(); // 附魔属性
    }

    [wxb.Hotfix]
    public class ItemManager
    {
        private static ItemManager instance = null;

        //新字段
        public Dictionary<ulong, Goods> BagGoodsOids = new Dictionary<ulong, Goods>();//背包
        public Dictionary<uint, List<ulong>> BagTypeIdAndOids = new Dictionary<uint, List<ulong>>();//eid包含的oids
        public List<Goods> BagPanelSort = new List<Goods>(); //背包界面显示数据
        public List<int> NeedUpdateBagIndexArray = new List<int>(); //需要更新的背包格子编号列表

        public Dictionary<ulong, Goods> WareHouseGoodsOids = new Dictionary<ulong, Goods>();//仓库
        public Dictionary<uint, List<ulong>> WareHouseTypeIdAndOids = new Dictionary<uint, List<ulong>>();//eid包含的oids
        public List<Goods> WarePanelSort = new List<Goods>();   //仓库界面显示数据
        public List<int> NeedUpdateWareIndexArray = new List<int>();    //需要更新的仓库格子编号列表

        public Dictionary<ulong, Goods> TreasureHuntGoodsOids = new Dictionary<ulong, Goods>();//寻宝仓库

        public Dictionary<ulong, Goods> IDTreasureGoodsOids = new Dictionary<ulong, Goods>();//鉴宝仓库

        public Dictionary<ulong, Goods> HandbookGoodsOids = new Dictionary<ulong, Goods>();//图鉴背包
        public Dictionary<uint, List<ulong>> HandbookTypeIdAndOids = new Dictionary<uint, List<ulong>>();//eid包含的oids

        public Dictionary<ulong, Goods> SoulGoodsOids = new Dictionary<ulong, Goods>();//武魂背包
        public Dictionary<uint, List<ulong>> SoulTypeIdAndOids = new Dictionary<uint, List<ulong>>();//eid包含的oids

        public Dictionary<ulong, Goods> DecorateGoodsOids = new Dictionary<ulong, Goods>(); // 饰品背包
        public Dictionary<uint, List<ulong>> DecorateTypeIdAndOids = new Dictionary<uint, List<ulong>>();

        public Dictionary<ulong, GoodsMagicEquip> MagicEquipGoodsOids = new Dictionary<ulong, GoodsMagicEquip>(); // 法宝装备背包
        public Dictionary<uint, List<ulong>> MagicEquipTypeIdAndOids = new Dictionary<uint, List<ulong>>(); // 背包里按typeId分类数据

        //穿着身上装备
        public Dictionary<ulong, GoodsEquip> InstallEquip = new Dictionary<ulong, GoodsEquip>();//

        //已镶嵌的武魂
        public Dictionary<uint, GoodsSoul> InstallGoodsSouls = new Dictionary<uint, GoodsSoul>();

        // 已穿戴的饰品
        public Dictionary<uint, GoodsDecorate> WearingDecorate = new Dictionary<uint, GoodsDecorate>();

        // 已穿戴的法宝装备
        public Dictionary<ulong, GoodsMagicEquip> WearingMagicEquip = new Dictionary<ulong, GoodsMagicEquip>();

        public Dictionary<ulong, GoodsEquip> EquipGoodsOid = new Dictionary<ulong, GoodsEquip>();//包含身上跟背包的所有物品

        public Dictionary<uint, uint> GoodsCd = new Dictionary<uint, uint>();//cd(主键是物品表中的cd_id)

        //穿着中的神兵
        public Dictionary<ulong, GoodsGodEquip> InstallGodEquip = new Dictionary<ulong, GoodsGodEquip>();
        //神兵背包
        public Dictionary<ulong, GoodsGodEquip> GodEquipGoodsOids = new Dictionary<ulong, GoodsGodEquip>();

        //穿戴中的元素装备
        //public Dictionary<ulong, GoodsElementEquip> InstallElementEquip = new Dictionary<ulong, GoodsElementEquip>();
        //元素装备背包
        //public Dictionary<ulong, GoodsElementEquip> ElementEquipGoodsOids = new Dictionary<ulong, GoodsElementEquip>();
        // 背包里按typeId分类数据
        //public Dictionary<uint, List<ulong>> ElementEquipTypeIdAndOids = new Dictionary<uint, List<ulong>>(); 

        //穿着中的坐骑装备
        public Dictionary<ulong, GoodsMountEquip> InstallMountEquip = new Dictionary<ulong, GoodsMountEquip>();
        //坐骑装备背包
        public Dictionary<ulong, GoodsMountEquip> MountEquipGoodsOid = new Dictionary<ulong, GoodsMountEquip>();
        public Dictionary<uint, List<ulong>> MountEquipTypeIdAndOids = new Dictionary<uint, List<ulong>>();//eid包含的oids

        // 光武神魂背包
        public Dictionary<ulong, GoodsLightWeaponSoul> LightWeaponGoodsOids = new Dictionary<ulong, GoodsLightWeaponSoul>();
        // 穿戴的神魂(部位_光武类型, (部位_孔位, 兵魂))
        public Dictionary<uint, Dictionary<uint, GoodsLightWeaponSoul>> InstalledLightWeaponSoul = new Dictionary<uint, Dictionary<uint, GoodsLightWeaponSoul>>();

        public uint mBagInitCount = 0;//背包初始大小
        public uint mWareInitCount = 0;//仓库初始大小
        public uint mBagMaxCount = 0;//背包最大格子
        public uint mWareMaxCount = 0;//仓库最大格子
        public uint mBagTotalCount = 0;//背包总格子
        public uint mWareTotalCount = 0;//仓库总格子

        public uint mSoulBagInitCount = 0;//武魂初始大小
        public uint mSoulBagTotalCount = 0;//武魂背包
        public uint mSoulInstallInitCount = 0;//武魂初始大小
        public uint mSoulInstallTotalCount = 0;//镶嵌的长度

        public uint mHandbookBagInitCount = 0;//图鉴背包初始格子数
        public uint mHandbookBagTotalCount = 0;//图鉴背包格子数

        public uint mDecorateBagInitCount = 0; // 饰品背包初始格子数
        public uint mDecorateBagTotalCount = 0; // 饰品背包格子数

        public uint mMagicEquipBagInitCount = 0; // 法宝装备背包初始格子数
        public uint mMagicEquipBagTotalCount = 0; // 法宝装备背包格子数

        public uint mGodEquipBagInitCount = 0; //神兵背包初始格子数
        public uint mGodEquipBagTotalCount = 0; //神兵背包格子数

        public uint mMountEquipBagInitCount = 0;//坐骑装备背包初始格子数
        public uint mMountEquipBagTotalCount = 0;//坐骑装备背包格式数

        public uint mLightWeaponSoulBagInitCount = 0;   // 光武神魂背包初始格子数
        public uint mLightWeaponSoulBagTotalCount = 0;  // 光武神魂背包格子数

        public uint mLuckyTreasureBagMaxCount = 0;  // 鉴宝背包最大格子


        public bool isForceShowfloatTips = false;//强制开启tips
        public bool mIsAutoHp = false;
        public bool mIsAutoMp = false;
        public WXIconAsset mIconConfig;
        private bool mIsLoginBagProtoCallBack = true;
        //开格子
        public Dictionary<ushort, BagItemInfo> CurrentLockBagItem = new Dictionary<ushort, BagItemInfo>();//当前在倒计时的格子总和（包含背包类型）
        private Dictionary<ushort, uint> BagExSize = new Dictionary<ushort, uint>();//背包类型额外格子

        //装备强化（因为跟一般强化不一样所以要保存强化信息）
        public List<EquipPosInfo> StrengthInfos = new List<EquipPosInfo>();

        // 饰品部位信息
        public List<DecoratePosInfo> DecoratePosInfos = new List<DecoratePosInfo>();

        //已获得的武魂id
        public List<uint> GetSoulList = new List<uint>();
        //已开启的武魂id
        public List<uint> OpenSoulList = new List<uint>();

        //强化
        public uint BaptizeCount = 0;//当天已洗练次数

        private Timer mQuickUseTimer = null;
        public Dictionary<uint, bool> mCloseQuickUseGoodsIdArray = new Dictionary<uint, bool>();    //曾经关闭的快捷使用界面的物品ID（模板表中ID）
        public Dictionary<string, bool> mHaveCheckPos = new Dictionary<string, bool>();

        public ulong mIdInCurShortCutWin = 0;  //当前正在显示“快捷使用界面”的物品实例ID

        private List<uint> GetTitleList = new List<uint>(); // 已有称号id

        private Dictionary<ulong, uint> mConsumeValues = new Dictionary<ulong, uint>(); // 消费礼包消费情况

        private bool mInstall1GoodsListHaveInit = false;    // BAG_TYPE_INSTALL_1的数据是否已经初始化完毕

        public static ItemManager Instance
        {
            get { return GetInstance(); }
        }

        public static ItemManager GetInstance()
        {
            if (null == instance)
            {
                instance = new ItemManager();
            }
            return instance;
        }


        /// <summary>
        /// 根据唯一id返回goods仅仓库、临时背包、背包
        /// </summary>
        public Goods GetGoodsForAllByOId(ulong oid)
        {
            Goods goods1 = null;
            if (BagGoodsOids.TryGetValue(oid, out goods1) == true)
            {
                return goods1;
            }
            if (WareHouseGoodsOids.TryGetValue(oid, out goods1) == true)
            {
                return goods1;
            }

            else
                return null;
        }

        /// <summary>
        /// 根据唯一id返回goods
        /// </summary>
        public Goods GetGoodsForBagByOId(ulong oid)
        {
            Goods goods1 = null;
            if (BagGoodsOids.TryGetValue(oid, out goods1) == true)
            {
                return goods1;
            }
            else
                return null;
        }

        /// <summary>
        /// 背包中是否存在指定oid的物品
        /// </summary>
        /// <param name="oid"></param>
        /// <returns></returns>
        public bool HasGoods(ulong oid)
        {
            return BagGoodsOids.ContainsKey(oid);
        }

        /// <summary>
        /// 根据typeId返回总物品数量
        /// </summary>
        public ulong GetGoodsNumForBagByTypeId(uint eid)
        {
            uint money = LocalPlayerManager.Instance.GetMoneyByConst((ushort)eid);//加上货币判断
            if (money != 0)
                return money;
            Goods goods1 = null;
            List<ulong> oids = null;
            ulong num = 0;
            if (BagTypeIdAndOids.TryGetValue(eid, out oids) == true)
            {
                foreach (ulong oid in oids)
                {
                    if (BagGoodsOids.TryGetValue(oid, out goods1) == true)
                    {
                        num = num + goods1.num;
                    }
                }
            }
            return num;
        }

        /// <summary>
        /// 根据oid返回总物品数量
        /// </summary>
        public ulong GetGoodsNumForBag(ulong oid)
        {
            Goods goods = null;
            if (BagGoodsOids.TryGetValue(oid, out goods) == true)
            {
                return goods.num;
            }
            return 0;
        }


        /// <summary>
        /// 根据typeId返回坐骑装备背包总数量
        /// </summary>
        public ulong GetGoodsNumForMountEquipBagByTypeId(uint eid)
        {
            //uint money = LocalPlayerManager.Instance.GetMoneyByConst((ushort)eid);//加上货币判断
            //if (money != 0)
            //    return money;
            GoodsMountEquip goods1 = null;
            List<ulong> oids = null;
            ulong num = 0;
            if (MountEquipTypeIdAndOids.TryGetValue(eid, out oids) == true)
            {
                foreach (ulong oid in oids)
                {
                    if (MountEquipGoodsOid.TryGetValue(oid, out goods1) == true)
                    {
                        num = num + goods1.num;
                    }
                }
            }
            return num;
        }




        public ulong GetGoodsNumFromSoulBagAndBodyByTypeId(uint type_idx)
        {
            uint bag_num = 0;
            List<ulong> oid_list = null;
            if (SoulTypeIdAndOids.TryGetValue(type_idx, out oid_list))
            {
                bag_num = bag_num + (uint)oid_list.Count;
            }
            foreach (var item in InstallGoodsSouls.Values)
            {
                if (item.type_idx == type_idx)
                    bag_num = bag_num + 1;
            }
            return bag_num;
        }

        public ulong GetGoodsNumFromHandbookBagAndBodyByTypeId(uint eid)
        {
            Goods goods1 = null;
            List<ulong> oids = null;
            ulong num = 0;
            if (HandbookTypeIdAndOids.TryGetValue(eid, out oids) == true)
            {
                foreach (ulong oid in oids)
                {
                    if (HandbookGoodsOids.TryGetValue(oid, out goods1) == true)
                    {
                        num = num + goods1.num;
                    }
                }
            }
            return num;
        }

        /// <summary>
        /// 根据指定typeId返回图鉴物品列表
        /// </summary>
        public Dictionary<ulong, Goods> GetHandbookListForBagByTypeId(uint eid)
        {
            Dictionary<ulong, Goods> goods_list = new Dictionary<ulong, Goods>();
            Goods goods1 = null;
            List<ulong> oids = new List<ulong>();
            if (HandbookTypeIdAndOids.TryGetValue(eid, out oids) == true)
            {
                foreach (ulong oid in oids)
                {
                    if (HandbookGoodsOids.TryGetValue(oid, out goods1) == true)
                    {
                        goods_list.Add(oid, goods1);
                    }
                }
                return goods_list;
            }
            else
                return null;
        }


        /// <summary>
        /// 背包中是否存在指定type_id的物品
        /// </summary>
        /// <param name="type_id"></param>
        /// <returns></returns>
        public bool ExistGoods(uint type_id)
        {
            List<ulong> oid_list = null;
            if (BagTypeIdAndOids.TryGetValue(type_id, out oid_list))
            {
                return oid_list.Count > 0;
            }
            else
                return false;

        }
        /// <summary>
        /// 根据typeId返回未绑定的总物品数量
        /// </summary>
        /// <param name="eid"></param>
        /// <returns></returns>
        public ulong GetGoodsUnbindNumForBagByTypeId(uint eid)
        {
            Goods goods1 = null;
            List<ulong> oids = new List<ulong>();
            ulong num = 0;
            if (BagTypeIdAndOids.TryGetValue(eid, out oids) == true)
            {
                foreach (ulong oid in oids)
                {
                    if (BagGoodsOids.TryGetValue(oid, out goods1) == true)
                    {
                        if (goods1.bind == 0)
                        {
                            num = num + goods1.num;
                        }
                    }
                }
            }
            return num;
        }

        /// <summary>
        /// 根据typeId获取判断背包中是否有绑定的该物品
        /// </summary>
        /// <param name="eid"></param>
        /// <returns></returns>
        public bool IsHaveBindGoodsByTypeId(uint eid)
        {
            Goods goods1 = null;

            List<ulong> oids = new List<ulong>();
            if (BagTypeIdAndOids.TryGetValue(eid, out oids))
            {
                foreach (ulong oid in oids)
                {
                    if (BagGoodsOids.TryGetValue(oid, out goods1))
                    {
                        if (goods1.bind == 1)
                        {
                            return true;
                        }
                    }
                }
            }

            return false;
        }

        /// <summary>
        /// 开启某一个武魂id
        /// </summary>
        /// <param name="id"></param>
        public void OpenSoul(uint id)
        {
            var data = new C2SSoulOpenBook();
            data.id = id;
            NetClient.GetBaseClient().SendData<C2SSoulOpenBook>(NetMsg.MSG_SOUL_OPEN_BOOK, data);
        }

        /// <summary>
        /// 武魂升级
        /// </summary>
        /// <param name="oid"></param>
        public void SendSoulUpLv(ulong oid)
        {
            var data = new C2SSoulLvUp();
            data.oid = oid;
            NetClient.GetBaseClient().SendData<C2SSoulLvUp>(NetMsg.MSG_SOUL_LV_UP, data);
        }

        /// <summary>
        /// 镶嵌武魂
        /// </summary>
        /// <param name="oid"></param>
        /// <param name="holeId"></param>
        public void SendInstallSoul(ulong oid, uint holeId)
        {
            var data = new C2SSoulInlay();
            data.oid = oid;
            data.hole_id = holeId;
            NetClient.GetBaseClient().SendData<C2SSoulInlay>(NetMsg.MSG_SOUL_INLAY, data);
        }

        /// <summary>
        /// 武魂分解
        /// </summary>
        /// <param name="oid"></param>
        public void SendResolveSoul(ulong[] oids)
        {
            var data = new C2SSoulResolve();
            if (oids != null)
            {
                for (int i = 0; i < oids.Length; i++)
                {
                    data.oids.Add(oids[i]);
                }
            }
            NetClient.GetBaseClient().SendData<C2SSoulResolve>(NetMsg.MSG_SOUL_RESOLVE, data);
        }

        /// <summary>
        /// 武魂背包中是否存在指定type_id的物品
        /// </summary>
        /// <param name="type_id"></param>
        /// <returns></returns>
        public bool ExistSoul(uint type_id)
        {
            List<ulong> oid_list = null;
            if (SoulTypeIdAndOids.TryGetValue(type_id, out oid_list))
            {
                return oid_list.Count > 0;
            }
            else
                return false;

        }
        /// <summary>
        /// 根据指定subtype返回List
        /// </summary>
        public List<Goods> GetGoodsListBySubType(uint mainType, ushort subtype)
        {
            List<Goods> goodsList = new List<Goods>();
            foreach (var kv in BagGoodsOids)
            {
                if (kv.Value.main_type == mainType)
                {
                    if (kv.Value.sub_type == subtype)
                        goodsList.Add(kv.Value);
                }

            }
            return goodsList;
        }

        /// <summary>
        /// 根据指定typeId返回oid Goods列表
        /// </summary>
        public Dictionary<ulong, Goods> GetGoodsListForBagByTypeId(uint eid)
        {
            Dictionary<ulong, Goods> goods_list = new Dictionary<ulong, Goods>();
            Goods goods1 = null;
            List<ulong> oids = new List<ulong>();
            if (BagTypeIdAndOids.TryGetValue(eid, out oids) == true)
            {
                foreach (ulong oid in oids)
                {
                    if (BagGoodsOids.TryGetValue(oid, out goods1) == true)
                    {
                        goods_list.Add(oid, goods1);
                    }
                }
                return goods_list;
            }
            else
                return null;
        }

        /// <summary>
        ///  获得对应oid的Goods
        /// </summary>
        Goods GetWareHouseGoodsForOid(ulong oid)
        {
            Goods goods = null;
            if (WareHouseGoodsOids.TryGetValue(oid, out goods) == false)
            {
                Debug.Log("无法获得Oid===" + oid.ToString() + "的仓库物品");
            }
            return goods;
        }

        /// <summary>
        ///  获得对应oid的Goods
        /// </summary>
        Goods GetBagGoodsForOid(ulong oid)
        {
            Goods goods = null;
            if (BagGoodsOids.TryGetValue(oid, out goods) == false)
            {
                Debug.Log("无法获得Oid===" + oid.ToString() + "的背包物品");
            }
            return goods;
        }

        /// <summary>
        ///  移除所有类型物品表
        /// </summary>
        void removeGoodsForAllType(ulong oid)
        {

            if (BagGoodsOids.ContainsKey(oid) == true)
                BagGoodsOids.Remove(oid);

            if (WareHouseGoodsOids.ContainsKey(oid) == true)
                WareHouseGoodsOids.Remove(oid);
        }

        public uint GetEmptyItemCount()
        {
            uint itemCount = (uint)BagGoodsOids.Count;
            if (mBagTotalCount > itemCount)
            {
                return mBagTotalCount - itemCount;
            }
            else
            {
                return 0;
            }
        }

        /// <summary>
        /// 背包是否已满
        /// </summary>
        /// <param name="num">新增物品数量</param>
        /// <param name="giveTpye">物品类型</param>
        /// <returns></returns>
        public bool BagIsFull(uint num, uint giveTpye = 1)
        {
            int itemCount;
            uint bagMaxSize;
            switch (giveTpye)
            {
                case GameConst.GIVE_TYPE_GOODS: bagMaxSize = mBagTotalCount; itemCount = BagGoodsOids.Count; break;
                case GameConst.GIVE_TYPE_RIDE_EQUIP: bagMaxSize = mMountEquipBagTotalCount; itemCount = MountEquipGoodsOid.Count; break;
                case GameConst.GIVE_TYPE_MAGIC_EQUIP: bagMaxSize = mMagicEquipBagTotalCount; itemCount = MagicEquipGoodsOids.Count; break;
                case GameConst.GIVE_TYPE_LIGHT_SOUL: bagMaxSize = mLightWeaponSoulBagTotalCount; itemCount = LightWeaponGoodsOids.Count; break;
                default:
                    bagMaxSize = mBagTotalCount; itemCount = BagGoodsOids.Count; break;
            }

            
            if (bagMaxSize >= itemCount + num)
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        /// <summary>
        /// 获取制定位置的装备列表
        /// </summary>
        public List<GoodsEquip> GetBagEquipByPos(uint pos)
        {
            List<GoodsEquip> equipInfo = new List<GoodsEquip>();
            foreach (var kv in BagGoodsOids)
            {
                if (kv.Value != null && kv.Value is GoodsEquip)
                {
                    GoodsEquip equip = kv.Value as GoodsEquip;
                    if (equip.EquipPos == pos)
                    {
                        equipInfo.Add(equip);
                    }
                }
            }
            equipInfo.Sort(delegate (GoodsEquip equip1, GoodsEquip equip2)
            {
                if (equip1.EquipRank > equip2.EquipRank)
                    return -1;
                else if (equip1.EquipRank < equip2.EquipRank)
                    return 1;
                else
                    return 0;
            });
            return equipInfo;
        }

        /// <summary>
        /// 得到指定Gid和品质的数量
        /// </summary>
        /// <param name="gid"></param>
        /// <param name="minQuality"></param>
        /// <returns></returns>
        public uint GetEquipCount(uint gid, uint quality)
        {
            uint result = 0;

            foreach (var kv in BagGoodsOids)
            {
                if (kv.Value.type_idx == gid && (uint)kv.Value.color_type == quality)
                {
                    ++result;
                }
            }

            return result;
        }

        private ItemManager()
        {
        }

        /// <summary>
        ///  重新登外部清空函数
        /// </summary>
        /// ignore_reconnect 若为true, 断线重连； false, 不是断线重连引起的
        public void Reset(bool ignore_reconnect)
        {
            mIsLoginBagProtoCallBack = true;
            mLastCheckEmptyItemCount = 1000;
            BagPanelSort.Clear();
            WarePanelSort.Clear();
            BagGoodsOids.Clear();
            BagTypeIdAndOids.Clear();
            WareHouseGoodsOids.Clear();
            WareHouseTypeIdAndOids.Clear();
            TreasureHuntGoodsOids.Clear();
            IDTreasureGoodsOids.Clear();
            HandbookGoodsOids.Clear();
            SoulGoodsOids.Clear();
            SoulTypeIdAndOids.Clear();
            InstallGoodsSouls.Clear();
            HandbookTypeIdAndOids.Clear();

            GetTitleList.Clear();

            mConsumeValues.Clear();

            //武魂
            if (ignore_reconnect == false)
            {
                OpenSoulList.Clear();
                GetSoulList.Clear();
            }

            // 饰品
            DecorateGoodsOids.Clear();
            DecorateTypeIdAndOids.Clear();
            WearingDecorate.Clear();
            DecoratePosInfos.Clear();

            // 法宝装备
            MagicEquipGoodsOids.Clear();
            MagicEquipTypeIdAndOids.Clear();
            WearingMagicEquip.Clear();

            InstallEquip.Clear();
            CurrentLockBagItem.Clear();
            BagExSize.Clear();
            StrengthInfos.Clear();
            mNoUseTimesGids.Clear();

            InstallGodEquip.Clear();
            GodEquipGoodsOids.Clear();

            //InstallElementEquip.Clear();
            //ElementEquipGoodsOids.Clear();

            MountEquipTypeIdAndOids.Clear();
            InstallMountEquip.Clear();
            MountEquipGoodsOid.Clear();

            InstalledLightWeaponSoul.Clear();
            LightWeaponGoodsOids.Clear();

            if (ignore_reconnect == false)
            {
                mCloseQuickUseGoodsIdArray.Clear();
                mTempGoodsList.Clear();
            }
            string raw = string.Empty;
            string ware_type_str = GameConst.BAG_TYPE_WARE.ToString();
            var data_bag = DBManager.Instance.QuerySqliteRow<string>(GlobalConfig.DBFile, "data_bag", "id", ware_type_str);
            if (data_bag == null || data_bag.Count == 0)
                return;
            Dictionary<string, string> table = data_bag[0];
            if (table.TryGetValue("init_size", out raw))
            {
                mBagInitCount = DBTextResource.ParseUI(raw);
            }

            if (table.TryGetValue("max_size", out raw))
            {
                mBagMaxCount = DBTextResource.ParseUI(raw);
            }

            data_bag = DBManager.Instance.QuerySqliteRow<string>(GlobalConfig.DBFile, "data_bag", "id", GameConst.BAG_TYPE_WARE.ToString());
            table = data_bag[0];
            if (table.TryGetValue("init_size", out raw))
            {
                mWareInitCount = DBTextResource.ParseUI(raw);
            }

            if (table.TryGetValue("max_size", out raw))
            {
                mWareMaxCount = DBTextResource.ParseUI(raw);
            }

            data_bag = DBManager.Instance.QuerySqliteRow<string>(GlobalConfig.DBFile, "data_bag", "id", GameConst.BAG_TYPE_SOUL.ToString());
            table = data_bag[0];
            if (table.TryGetValue("init_size", out raw))
            {
                mSoulBagInitCount = DBTextResource.ParseUI(raw);
            }

            data_bag = DBManager.Instance.QuerySqliteRow<string>(GlobalConfig.DBFile, "data_bag", "id", GameConst.BAG_TYPE_INSTALL_2.ToString());
            table = data_bag[0];
            if (table.TryGetValue("init_size", out raw))
            {
                mSoulInstallInitCount = DBTextResource.ParseUI(raw);
            }

            data_bag = DBManager.Instance.QuerySqliteRow<string>(GlobalConfig.DBFile, "data_bag", "id", GameConst.BAG_TYPE_DECORATE.ToString());
            table = data_bag[0];
            if (table.TryGetValue("init_size", out raw))
            {
                mDecorateBagInitCount = DBTextResource.ParseUI(raw);
            }

            data_bag = DBManager.Instance.QuerySqliteRow<string>(GlobalConfig.DBFile, "data_bag", "id", GameConst.BAG_TYPE_MAGIC_EQUIP.ToString());
            table = data_bag[0];
            if (table.TryGetValue("init_size", out raw))
            {
                mMagicEquipBagInitCount = DBTextResource.ParseUI(raw);
            }

            data_bag = DBManager.Instance.QuerySqliteRow<string>(GlobalConfig.DBFile, "data_bag", "id", GameConst.BAG_TYPE_ARCHIVE.ToString());
            table = data_bag[0];
            if (table.TryGetValue("init_size", out raw))
            {
                mHandbookBagInitCount = DBTextResource.ParseUI(raw);
            }


            data_bag = DBManager.Instance.QuerySqliteRow<string>(GlobalConfig.DBFile, "data_bag", "id", GameConst.BAG_TYPE_GOD_EQUIP.ToString());
            table = data_bag[0];
            if (table.TryGetValue("init_size", out raw))
            {
                mGodEquipBagInitCount = DBTextResource.ParseUI(raw);
            }

            data_bag = DBManager.Instance.QuerySqliteRow<string>(GlobalConfig.DBFile, "data_bag", "id", GameConst.BAG_TYPE_RIDE_EQUIP.ToString());
            table = data_bag[0];
            if (table.TryGetValue("init_size", out raw))
            {
                mMountEquipBagInitCount = DBTextResource.ParseUI(raw);
            }

            data_bag = DBManager.Instance.QuerySqliteRow<string>(GlobalConfig.DBFile, "data_bag", "id", GameConst.BAG_TYPE_LIGHT_SOUL.ToString());
            table = data_bag[0];
            if (table.TryGetValue("init_size", out raw))
            {
                mLightWeaponSoulBagInitCount = DBTextResource.ParseUI(raw);
            }

            data_bag = DBManager.Instance.QuerySqliteRow<string>(GlobalConfig.DBFile, "data_bag", "id", GameConst.BAG_TYPE_ID_TREASURE.ToString());
            table = data_bag[0];
            if (table.TryGetValue("max_size", out raw))
            {
                mLuckyTreasureBagMaxCount = DBTextResource.ParseUI(raw);
            }

            Dictionary<uint, DBEquipPos.DBEquipPosItem> allEquipPosInfos = DBManager.Instance.GetDB<DBEquipPos>().AllEquipPosInfos;
            foreach (DBEquipPos.DBEquipPosItem equipPosInfo in allEquipPosInfos.Values)
            {
                EquipPosInfo info = new EquipPosInfo();
                info.IsCanStrength = equipPosInfo.CanStrength;
                info.SortId = equipPosInfo.SortId;
                info.BaptizeNeedLv = equipPosInfo.CanBaptizeLv;
                info.Pos = equipPosInfo.PosId;
                StrengthInfos.Add(info);
            }

            for (int i = 0; i < StrengthInfos.Count; i++)
            {
                StrengthInfos[i].StrengthStuff = Equip.EquipHelper.GetStrengthStuff(StrengthInfos[i].StrengthLv);
                StrengthInfos[i].StrengthShowRedPointGoods = Equip.EquipHelper.GetStrengthShowRedPointGoods(StrengthInfos[i].StrengthLv);
                //var data_strength_lv = DBManager.Instance.QuerySqliteField<string>(GlobalConfig.DBFile, "data_strength_lv", "lv", StrengthInfos[i].StrengthLv.ToString(), "degree");
                //raw = data_strength_lv[0];
                //StrengthInfos[i].StrengthMaxDegree = DBTextResource.ParseUI(raw);
                DBStrengthLv.StrengthLvInfo strengthLvInfo = DBStrengthLv.Instance.GetStrengthLvInfo(StrengthInfos[i].StrengthLv);
                if (strengthLvInfo != null)
                {
                    StrengthInfos[i].StrengthMaxDegree = strengthLvInfo.Degree;
                }
            }
            StrengthInfos.Sort(delegate (EquipPosInfo infoa, EquipPosInfo infob)
            {
                if (infoa.SortId > infob.SortId)
                    return 1;
                else if (infoa.SortId < infob.SortId)
                    return -1;
                else
                    return 0;
            }
            );

            // 饰品部位信息
            foreach (var data in DBDecoratePos.Instance.SortData)
            {
                var info = new DecoratePosInfo();
                info.Pos = data.Pos;
                info.SortId = data.SortId;

                // 附魔信息
                foreach (var append in data.AppendAttrs)
                {
                    var attr = new DecorateAppendAttr();
                    attr.AttrId = (uint)append.x;
                    attr.Value = append.y;
                    attr.OpenLv = (int)append.z;
                    attr.BreakLv = (uint)append.w;

                    info.AppendAttrs.Add(attr);
                }

                info.AppendAttrs.Sort(delegate (DecorateAppendAttr lhs, DecorateAppendAttr rhs)
                {
                    if (lhs.BreakLv > rhs.BreakLv)
                        return 1;

                    else if (lhs.BreakLv < rhs.BreakLv)
                        return -1;

                    else
                        return 0;
                });

                DecoratePosInfos.Add(info);
            }

            mInstall1GoodsListHaveInit = false;
        }

        /// <summary>
        /// 套装锻造
        /// </summary>
        /// <param name="pos"></param>
        /// <param name="index"></param>
        public void EquipSuitForge(uint pos, uint index)
        {
            var data = new C2SEpSuitForge();
            data.pos = pos;
            data.index = index;
            NetClient.GetBaseClient().SendData<C2SEpSuitForge>(NetMsg.MSG_EP_SUIT_FORGE, data);
        }

        /// <summary>
        /// 套装精炼
        /// </summary>
        /// <param name="pos"></param>
        /// <param name="index"></param>
        public void EquipSuitRefine(uint pos, uint index)
        {
            var data = new C2SEpSuitRefine
            {
                pos = pos,
                index = index
            };

            NetClient.GetBaseClient().SendData<C2SEpSuitRefine>(NetMsg.MSG_EP_SUIT_REFINE, data);
        }

        /// <summary>
        /// 洗练锁住格子
        /// </summary>
        /// <param name="pos"></param>
        /// <param name="index"></param>
        /// <param name="id"></param>
        public void EquipBaptizeLock(uint pos, uint index, uint id)
        {
            var data = new C2SEpBaptizeLock();
            data.pos = pos;
            data.index = index;
            data.id = id;
            NetClient.GetBaseClient().SendData<C2SEpBaptizeLock>(NetMsg.MSG_EP_BAPTIZE_LOCK, data);
        }

        /// <summary>
        /// 洗练开启格子
        /// </summary>
        /// <param name="pos"></param>
        /// <param name="index"></param>
        /// <param name="id"></param>
        public void EquipBaptizeOpen(uint pos, uint index, uint id)
        {
            var data = new C2SEpBaptizeOpen();
            data.pos = pos;
            data.index = index;
            data.id = id;

            ///服务端不判断是否可以开启要客户端自己判断
            //var info = ItemManager.Instance.StrengthInfos.Find(delegate (EquipPosInfo _info) { return (_info.Pos == pos && index == _info.Index); });
            var info = xc.Equip.EquipHelper.GetStrengthInfoByPosAndIndex(pos, index);
            if (info == null)
                return;
            foreach (var item in info.BaptizeInfos)
            {
                if (item.Value.State == EquipBaptizeInfo.EquipBaptizeState.NO_Open)
                {
                    data.id = item.Key;
                    break;
                }
            }
            NetClient.GetBaseClient().SendData<C2SEpBaptizeOpen>(NetMsg.MSG_EP_BAPTIZE_OPEN, data);
        }

        /// <summary>
        /// 洗练
        /// </summary>
        /// <param name="pos"></param>
        /// <param name="index"></param>
        /// <param name="type"></param>
        public void EquipBaptize(uint pos, uint index, uint type)
        {
            var data = new C2SEpBaptize();
            data.pos = pos;
            data.index = index;
            data.type = type;
            NetClient.GetBaseClient().SendData<C2SEpBaptize>(NetMsg.MSG_EP_BAPTIZE, data);
        }

        /// <summary>
        /// 宝石镶嵌自动购买
        /// </summary>
        /// <param name="pos"></param>
        /// <param name="index"></param>
        /// <param name="holeId"></param>
        /// <param name="gemGid"></param>
        public void EquipInstallGem(uint pos, uint index, uint holeId, uint gemGid, uint autBuy = 0, ulong oid = 0)
        {
            var data = new C2SEpGemInlay();
            data.pos = pos;
            data.index = index;
            data.hole_id = holeId;
            data.gem_id = gemGid;
            data.auto_buy = autBuy;
            data.oid = oid;
            NetClient.GetBaseClient().SendData<C2SEpGemInlay>(NetMsg.MSG_EP_GEM_INLAY, data);
        }
        /// <summary>
        /// 卸下宝石
        /// </summary>
        /// <param name="pos"></param>
        /// <param name="index"></param>
        /// <param name="holeId"></param>
        public void EquipUnInstallGem(uint pos, uint index, uint holeId)
        {
            var data = new C2SEpGemDown();
            data.pos = pos;
            data.index = index;
            data.hole_id = holeId;
            NetClient.GetBaseClient().SendData<C2SEpGemDown>(NetMsg.MSG_EP_GEM_DOWN, data);
        }

        //物品使用
        public void UseGoods(uint gid, uint num, ulong oid = 0, params uint[] args)
        {
            if (SceneHelp.Instance.ForbidUseGoods(gid))
            {
                DBInstance.InstanceInfo instanceInfo = InstanceManager.Instance.InstanceInfo;
                if (instanceInfo != null)
                {
                    UINotice.Instance.ShowMessage(String.Format(DBConstText.GetText("INSTANCE_CAN_NOT_USE_GOODS"), instanceInfo.mName));
                }
                return;
            }

            // FIXME 物品使用
            C2SGoodsUse goodsUse = new C2SGoodsUse();
            goodsUse.gid = gid;
            goodsUse.num = num;
            goodsUse.oid = oid;
            goodsUse.args.Clear();
            if (args != null && args.Length > 0)
            {
                foreach (uint arg in args)
                {
                    goodsUse.args.Add(arg);
                }
            }
            ItemManager.GetInstance().isForceShowfloatTips = true;
            NetClient.GetBaseClient().SendData<C2SGoodsUse>(NetMsg.MSG_GOODS_USE, goodsUse);

            object[] param = { gid, num };
            LuaScriptMgr.Instance.CallLuaFunction(LuaScriptMgr.Instance.Lua.Global, "GoodsLuaHelper_CheckCanContinueUseGoods", param);
        }

        /// <summary>
        /// 回收装备
        /// </summary>
        /// <param name="oids"></param>
        public void RecycleGoods(List<ulong> oids, uint type = 1)
        {
            // FIXME 物品使用
            var data = new C2SEquipRecycle();
            foreach (var item in oids)
            {
                data.oids.Add(item);
            }
            data.type = type;
            NetClient.GetBaseClient().SendData<C2SEquipRecycle>(NetMsg.MSG_EQUIP_RECYCLE, data);
        }

        /// <summary>
        /// 提交装备
        /// </summary>
        /// <param name="oids"></param>
        public void SubmitGoods(ulong oid)
        {
            var data = new C2SEquipSubmit();
            data.oid = oid;
            NetClient.GetBaseClient().SendData<C2SEquipSubmit>(NetMsg.MSG_EQUIP_SUBMIT, data);
        }

        /// <summary>
        /// 物品合成
        /// </summary>
        /// <param name="gid"></param>
        /// <param name="num"></param>
        public void ComposeGoods(uint gid, uint num)
        {
            var data = new C2SGoodsCompose();
            data.gid = gid;
            data.num = num;
            NetClient.GetBaseClient().SendData<C2SGoodsCompose>(NetMsg.MSG_GOODS_COMPOSE, data);
        }

        /// <summary>
        /// 强化装备
        /// </summary>
        /// <param name="pos"></param>
        /// <param name="index"></param>
        public void StrengthEquip(uint pos, uint index)
        {
            var data = new C2SEpStrength();
            data.pos = pos;
            data.index = index;
            NetClient.GetBaseClient().SendData<C2SEpStrength>(NetMsg.MSG_EP_STRENGTH, data);
        }
        //物品出售
        public void SellGoods(ulong oid, uint num, uint bag_type = GameConst.BAG_TYPE_NORMAL)
        {
            // FIXME 物品使用
            var data = new C2SGoodsSell();
            data.oid = oid;
            data.num = num;
            if (bag_type != GameConst.BAG_TYPE_NORMAL)
                data.bag_type = bag_type;
            ItemManager.GetInstance().isForceShowfloatTips = true;
            NetClient.GetBaseClient().SendData<C2SGoodsSell>(NetMsg.MSG_GOODS_SELL, data);
        }

        //装备、时装、翅膀等穿戴
        public void CommonInstall(uint fromBag, uint toBag, ulong oid, uint installIdx/*如果是装备代表下表*/)
        {
            var data = new C2SEquipMove();
            data.origin = fromBag;
            data.target = toBag;
            data.oid = oid;
            data.index = installIdx;
            NetClient.GetBaseClient().SendData<C2SEquipMove>(NetMsg.MSG_EQUIP_MOVE, data);
        }

        private void CheckInstall(uint fromBag, uint toBag, GoodsEquip equip, uint installIdx/*如果是装备代表下表*/)
        {
            if (fromBag == GameConst.BAG_TYPE_NORMAL && toBag == GameConst.BAG_TYPE_INSTALL_1)
            {
                var need_con = equip.Data.NeedARCON;
                var need_str = equip.Data.NeedARSTR;
                var need_agi = equip.Data.NeedARAGI;
                var need_int = equip.Data.NeedARINT;
                var need_transfer = equip.use_transfer;
                var _con = LocalPlayerManager.Instance.LocalActorAttribute.Attribute[GameConst.AR_CON].Value;
                var _str = LocalPlayerManager.Instance.LocalActorAttribute.Attribute[GameConst.AR_STR].Value;
                var _agi = LocalPlayerManager.Instance.LocalActorAttribute.Attribute[GameConst.AR_AGI].Value;
                var _int = LocalPlayerManager.Instance.LocalActorAttribute.Attribute[GameConst.AR_INT].Value;
                var _transfer = 0;
                object[] param = { };
                System.Type[] returnType = { typeof(int) };
                object[] objs = LuaScriptMgr.Instance.CallLuaFunction_return(LuaScriptMgr.Instance.Lua.Global, "TransferMgr_GetTransferLevel", param, returnType);
                if (objs != null && objs.Length > 0)
                {
                    if (objs[0] != null)
                    {
                        _transfer = (int)objs[0];
                    }
                }

                if ((equip.use_job != 0 && equip.use_job != LocalPlayerManager.Instance.LocalActorAttribute.Vocation))
                {
                    UINotice.Instance.ShowMessage(xc.DBConstText.GetText("GAME_GOODS_INSTALL_JOB_NO_MATCH"));
                    return;
                }

                if ((equip.use_lv != 0 && equip.use_lv > LocalPlayerManager.Instance.LocalActorAttribute.Level))
                {
                    UINotice.Instance.ShowMessage(DBErrorCode.GetErrorString(ErrorCode.ERR_USE_LV_LIMIT));
                    return;
                }

                if (_transfer < need_transfer)
                {
                    UINotice.Instance.ShowMessage(string.Format(xc.DBConstText.GetText("GAME_GOODS_INSTALL_TRANSFER_NO_MATCH"), need_transfer));
                    return;
                }
                if (Equip.EquipHelper.ShowInstallEquipAllocation(equip, installIdx))
                {
                    return;
                }
                if (need_int > _int)
                {
                    UINotice.Instance.ShowMessage(xc.TextHelper.GetConstText("CODE_TEXT_LOCALIZATION_66"));
                    return;
                }
                else if (need_agi > _agi)
                {
                    UINotice.Instance.ShowMessage(xc.TextHelper.GetConstText("CODE_TEXT_LOCALIZATION_67"));
                    return;
                }
                else if (need_str > _str)
                {
                    UINotice.Instance.ShowMessage(xc.TextHelper.GetConstText("CODE_TEXT_LOCALIZATION_68"));
                    return;
                }
                else if (need_con > _con)
                {
                    UINotice.Instance.ShowMessage(xc.TextHelper.GetConstText("CODE_TEXT_LOCALIZATION_69"));
                    return;
                }
            }


            var data = new C2SEquipMove();
            data.origin = fromBag;
            data.target = toBag;
            data.oid = equip.id;
            data.index = installIdx;
            NetClient.GetBaseClient().SendData<C2SEquipMove>(NetMsg.MSG_EQUIP_MOVE, data);
        }

        //装备、时装、翅膀等穿戴
        public void CommonInstall(uint fromBag, uint toBag, GoodsEquip equip, uint installIdx/*如果是装备代表下表*/)
        {
            if (equip == null || equip.Data == null || xc.LocalPlayerManager.Instance.LocalActorAttribute == null)
                return;
            CheckInstall(fromBag, toBag, equip, installIdx);
        }

        //快速解锁背包
        public bool CheckQuickUnLock(ushort bag_type)
        {
            bool isHave = false;
            uint totalCount = 0;
            uint initCount = 0;
            uint maxCount = 0;
            BagItemInfo info = null;
            switch (bag_type)
            {
                case GameConst.BAG_TYPE_NORMAL:
                    totalCount = mBagTotalCount;
                    initCount = mBagInitCount;
                    maxCount = mBagMaxCount;
                    break;
                case GameConst.BAG_TYPE_WARE:
                    totalCount = mWareTotalCount;
                    initCount = mWareInitCount;
                    maxCount = mWareMaxCount;
                    break;
            }
            if (maxCount == totalCount)
                return false;
            CurrentLockBagItem.TryGetValue(bag_type, out info);
            if (info == null)
                return false;
            uint nextUnlockIdx = totalCount - initCount + 1;
            var currentPage = Mathf.FloorToInt((float)(totalCount + 1) / 25.0f);
            if (nextUnlockIdx < info.Idx)
            {
                uint goodsId = GameConstHelper.GetUint("GAME_BAG_UNLOCK_GOODS_ID");
                if (goodsId != 0)
                {
                    GoodsItem goods = new GoodsItem(goodsId);
                    if (goods != null)
                    {
                        ui.ugui.UIManager.Instance.ShowWindow("UIShortcutUseWindow", goods, bag_type, currentPage);
                        isHave = true;
                    }
                }

            }
            return isHave;
        }

        /// <summary>
        /// 判断一件装备是否比现有装备更好
        /// </summary>
        /// <param name="equip"></param>
        /// <returns></returns>
        public bool IsBetterBagEquip(GoodsEquip equip)
        {
            if (equip == null)
                return false;
            //不符合穿戴条件，不是更好的
            if (Equip.EquipHelper.IsPlayerAllocationCanInstall(equip) == false)
                return false;
            //local installEquip = EquipUtil.Instance:GetInstallPosEquip(goodsEquip)
            var installEquip = Equip.EquipHelper.GetInstallEquipByPos(equip.EquipPos);
            if (installEquip == null)
                return true;
            //评分不高于当前的装备，不是更好的
            if (equip.Rank_CheckExpireTime <= installEquip.Rank_CheckExpireTime)
                return false;
            return true;
        }
        /// <summary>
        /// 返回背包可以穿戴的最好装备(加入等级限定)
        /// </summary>
        /// <returns></returns>
        public GoodsEquip GetBetterBagEquip()
        {
            GoodsEquip BetterEquip = null;

            for (int i = 0; i < StrengthInfos.Count; i++)
            {
                var installEquip = Equip.EquipHelper.GetInstallEquipByPos(StrengthInfos[i].Pos);
                var bagEquips = GetBagEquipByPos(StrengthInfos[i].Pos);

                if (ItemManager.Instance.CheckHavePos(GameConst.GIVE_TYPE_EQUIP, StrengthInfos[i].Pos))
                    continue;

                List<GoodsEquip> equip_list = bagEquips.FindAll(delegate (GoodsEquip equip) { return Equip.EquipHelper.IsPlayerAllocationCanInstall(equip) == true; });
                if (equip_list != null && equip_list.Count > 0)
                {
                    int highest_rank = -99999;
                    if (installEquip != null)
                    {
                        highest_rank = installEquip.Rank_CheckExpireTime;
                    }
                    for (int equip_index = 0; equip_index < equip_list.Count; ++equip_index)
                    {
                        GoodsEquip tmp_equip = equip_list[equip_index];
                        if (mCloseQuickUseGoodsIdArray.ContainsKey(tmp_equip.type_idx))
                            continue;
                        int tmp_equip_rank = tmp_equip.Rank_CheckExpireTime;
                        if (tmp_equip_rank > highest_rank)
                        {
                            BetterEquip = tmp_equip;
                            highest_rank = tmp_equip_rank;
                        }
                    }
                }

                if (BetterEquip != null)
                    return BetterEquip;
            }
            return BetterEquip;
        }
        /// <summary>
        /// 获得可使用的物品
        /// </summary>
        /// <returns></returns>
        public GoodsItem GetCanUseGoods()
        {
            uint local_player_lv = LocalPlayerManager.Instance.LocalActorAttribute.Level;
            List<GoodsItem> GoodsItems = new List<GoodsItem>();

            foreach (var kv in BagGoodsOids)
            {
                if (kv.Value is GoodsEquip || kv.Value is GoodsDecorate)
                {
                    continue;
                }
                else
                {

                    if (kv.Value.is_quickuse && kv.Value.use_lv <= local_player_lv)
                    {
                        bool checkCloseQuickUse = true; //是否检查
                        GoodsItem item = kv.Value as GoodsItem;
                        if (item.effect == "add_title") // 称号道具
                        {
                            uint titleId = 0;
                            uint.TryParse(item.arg, out titleId);

                            if (GetTitleList.Contains(titleId)) // 已有该称号
                                continue;
                        }
                        else if (item.effect == "consume_reward") // 消费宝箱
                        {
                            checkCloseQuickUse = false;
                            if (CheckBagCanQuickUse_ConsumeBox(kv.Value) == false)
                            {
                                continue;
                            }
                        }

                        // 如果之前已经关闭过快捷使用的物品框并且物品不是一直需要快捷使用的类型
                        if (checkCloseQuickUse && mCloseQuickUseGoodsIdArray.ContainsKey(kv.Value.type_idx) && !kv.Value.is_quickuse_always)
                            continue;

                        if (ItemManager.Instance.CheckHavePos(GameConst.GIVE_TYPE_GOODS, kv.Value.type_idx))
                            continue;

                        // 是否已经过期
                        if (kv.Value.IsInEnableTime() == false)
                            continue;

                        return item;
                        //GoodsItems.Add(item);
                    }
                }
            }
            return null;
            //return GoodsItems;
        }

        //检查是否有可以快速装备或使用的物品
        public bool CheckBagCanQuickUse()
        {
            // BAG_TYPE_INSTALL_1背包信息初始化完毕后才检查
            if (mInstall1GoodsListHaveInit == false)
            {
                return false;
            }
            if (mQuickUseTimer != null)
                return false;
            bool isHave = false;
            mQuickUseTimer = new Utils.Timer(1000, false, 1000,
                    (dt) =>
                    {
                        ClientEventMgr.GetInstance().FireEvent((int)ClientEvent.CE_INSTALL_1_EFLIN_UPDATE, new CEventBaseArgs());
                        if (CanShowQuickUseWindow())
                        {
                            //isHave = isFindGoodsToShow();
                            /*ShortCutManager.Instance.FreshState();
                            if (ui.ugui.UIManager.Instance.GetWindow("UIShortcutUseWindow") == null)
                            {
                                GoodsItem good = ShortCutManager.Instance.GetShowItem();
                                if (good != null)
                                {
                                    ui.ugui.UIManager.Instance.ShowWindow("UIShortcutUseWindow", good, good.bag_type);
                                    isHave = true;
                                }
                            }
                            
                            if (isHave == false)
                                isHave = isFindGoodsToShow();*/


                            
                            
                            if (ui.ugui.UIManager.Instance.GetWindow("UIShortcutUseWindow") == null)
                            {
                                //重置遍历过的部位
                                FreshPosState();
                                GoodsItem good = GetShowItem();
                                if (good != null)
                                {
                                    uint bag_type = GetBayTypeByGoods(good);
                                    ui.ugui.UIManager.Instance.ShowWindow("UIShortcutUseWindow", good, bag_type);
                                    isHave = true;
                                }
                            }
                        }
                        mQuickUseTimer.Destroy();
                        mQuickUseTimer = null;
                    });



            return isHave;
        }


        //获取需要显示的item
        public GoodsItem GetShowItem()
        {
            //先按部位顺序查找 部位不重复
            GoodsItem goodsItem = FindShowItem();

            //防止过号
            if (goodsItem == null)
            {
                int len = mTempGoodsList.Count - 1;
                for (int i = len; i >= 0; i--)
                {
                    GoodsItem item = mTempGoodsList[i];
                    mTempGoodsList.Remove(item);
                    if (mCloseQuickUseGoodsIdArray.ContainsKey(item.type_idx) == false && IsBetterThanBody(item))
                    {
                        // 物品数量大于0才可以使用
                        if (GetBayTypeByGoods(item) == GameConst.BAG_TYPE_NORMAL)
                        {
                            if (GetGoodsNumForBag(item.id) > 0)
                            {
                                goodsItem = item;
                                break;
                            }
                        }
                        else
                        {
                            goodsItem = item;
                            break;
                        }
                    }
                }
            }
            return goodsItem;
        }




        private GoodsItem FindShowItem()
        {
            // 装备
            GoodsItem goodItem = GetBetterBagEquip();

            if (goodItem != null && IsBetterThanBody(goodItem))
            {
                return goodItem;
            }

            // 饰品
            goodItem = DecorateHelper.GetBestBagDecorate();
            if (goodItem != null && IsBetterThanBody(goodItem))
            {
                return goodItem;
            }

            //坐骑装备
            goodItem = MountEquipHelper.GetBestMountEquip();
            if (goodItem != null && IsBetterThanBody(goodItem))
            {
                return goodItem;
            }
            
            //神兵装备
            goodItem = GodEquip.GodEquipHelper.GetBestGoodsGodEquip();
            if (goodItem != null && IsBetterThanBody(goodItem))
            {
                return goodItem;
            }

            //GoodsLuaEx
            if (LuaScriptMgr.Instance != null && LuaScriptMgr.Instance.Lua != null)
            {
                object[] param = { };
                object[] result = LuaScriptMgr.Instance.CallLuaFunction(LuaScriptMgr.Instance.Lua.Global, "GoodsLuaHelper_FindShowItem", param);
                if (result != null && result.Length > 0 && result[0] != null)
                {
                    goodItem = result[0] as GoodsItem;
                    if (goodItem != null)
                    {
                        return goodItem;
                    }
                }
            }

            //物品
            goodItem = GetCanUseGoods();
            if (goodItem != null)
            {
                return goodItem;
            }

            return null;
        }



        /*
        private bool isFindGoodsToShow()
        {
            bool isHave = false;

            // 装备
            var equip = GetBetterBagEquip();

            if (equip != null && IsBetterThanBody(equip))
            {
                ui.ugui.UIManager.Instance.ShowWindow("UIShortcutUseWindow", equip, GameConst.BAG_TYPE_NORMAL);
                isHave = true;
            }

            if (!isHave)
            {
                // 饰品
                var decorate = DecorateHelper.GetBestBagDecorate();
                if (decorate != null && IsBetterThanBody(decorate))
                {
                    ui.ugui.UIManager.Instance.ShowWindow("UIShortcutUseWindow", decorate, GameConst.BAG_TYPE_DECORATE);
                    isHave = true;
                }
            }

            if (!isHave)
            {
                var goodsItems = MountEquipHelper.GetBestMountEquip();
                if (goodsItems != null && IsBetterThanBody(goodsItems))
                {
                    ui.ugui.UIManager.Instance.ShowWindow("UIShortcutUseWindow", goodsItems, GameConst.BAG_TYPE_RIDE_EQUIP);
                    isHave = true;
                }
            }

            if (!isHave)
            {
                var goodsItems = ElementEquipHelper.GetBestElementEquip();
                if (goodsItems != null && IsBetterThanBody(goodsItems))
                {
                    ui.ugui.UIManager.Instance.ShowWindow("UIShortcutUseWindow", goodsItems, GameConst.BAG_TYPE_ELEMENT_EP);
                    isHave = true;
                }
            }

            if (!isHave)
            {
                var goodsItems = GodEquip.GodEquipHelper.GetBestGoodsGodEquip();
                if (goodsItems != null && IsBetterThanBody(goodsItems))
                {
                    ui.ugui.UIManager.Instance.ShowWindow("UIShortcutUseWindow", goodsItems, GameConst.BAG_TYPE_GOD_EQUIP);
                    isHave = true;
                }
            }

            if (!isHave)
            {
                var goodsItems = GetCanUseGoods();
                if (goodsItems.Count > 0)
                {
                    ui.ugui.UIManager.Instance.ShowWindow("UIShortcutUseWindow", goodsItems[0], GameConst.BAG_TYPE_NORMAL);
                    isHave = true;
                }
            }

            return isHave;
        }
        */
        //当tips找不到新item
        private void EventShortCutTipsNoGoods(CEventBaseArgs data)
        {


            //GameDebug.LogError("----------EventShortCutTipsNoGoods");
            //bool isFind = isFindGoodsToShow();
            //if (isFind == false)
            //    ui.ugui.UIManager.Instance.CloseWindow("UIShortcutUseWindow");
        }


        public bool CanShowQuickUseWindow()
        {
            uint level = 0;
            if (LocalPlayerManager.Instance.LocalActorAttribute != null)
            {
                level = LocalPlayerManager.Instance.LocalActorAttribute.Level;
            }
            uint need = GameConstHelper.GetUint("GAME_QUICK_AUTO_USE_LEVEL");
            if (need < level)
                return false;

            bool is_ban_show_win = xc.DBInstanceTypeControl.Instance.IsBanShortCutWin(xc.InstanceManager.Instance.InstanceType, xc.InstanceManager.Instance.InstanceSubType);
            if (is_ban_show_win)
            {
                //GameDebug.LogError("禁止显示快捷穿戴");
                return false;
            }

            //if (SceneHelp.Instance.IsInGuildManor == true)
            //{
            //    if(SysConfigManager.GetInstance().CheckSysHasOpened(GameConst.SYS_OPEN_RAIN_RED_PACKET, false) || SysConfigManager.GetInstance().CheckSysHasOpened(GameConst.SYS_OPEN_PRE_RAIN_RED_PACKET, false))
            //        return false;
            //}



            return true;
        }

        /// <summary>
        /// 判定goods 是否可以被快捷使用
        /// </summary>
        /// <param name="goods"></param>
        /// <returns></returns>
        public bool IsBetterBagGoods(GoodsItem goods)
        {
            if (goods == null)
                return false;

            if (goods.effect == "add_title") // 称号道具
            {
                uint titleId = 0;
                uint.TryParse(goods.arg, out titleId);

                if (GetTitleList.Contains(titleId)) // 已有该称号
                    return false;
            }

            uint local_player_lv = LocalPlayerManager.Instance.LocalActorAttribute.Level;
            if (goods.is_quickuse && goods.use_lv <= local_player_lv)
            {
                return true;
            }
            return false;
        }




        //是否比身上的好
        public bool IsBetterThanBody(Goods addGoods)
        {
            if(!addGoods.is_quickuse)
            {
                return false;
            }

            bool is_can_show = false;
            if (addGoods is GoodsEquip)
            {
                is_can_show = IsBetterBagEquip(addGoods as GoodsEquip);
            }
            else if (addGoods is GoodsDecorate)
            {
                is_can_show = DecorateHelper.IsBetterDecorateCanQuickUse(addGoods as GoodsDecorate);
            }
            else if (addGoods is GoodsMountEquip)
            {
                is_can_show = MountEquipHelper.IsBetterMountEquip(addGoods as GoodsMountEquip);
            }
            else if (addGoods is GoodsGodEquip)
            {
                is_can_show = GodEquip.GodEquipHelper.IsBetterGodEquip(addGoods as GoodsGodEquip);
            }
            else if (addGoods is GoodsLuaEx)
            {
                is_can_show = (addGoods as GoodsLuaEx).IsBetterThanBody();
            }
            else if (addGoods is GoodsItem)
            {
                is_can_show = IsBetterBagGoods(addGoods as GoodsItem);
            }

            return is_can_show;
        }
        public uint GetBayTypeByGoods(Goods addGoods)
        {
            uint bag_type = GameConst.BAG_TYPE_NORMAL;

            if (addGoods is GoodsDecorate)
            {
                bag_type = GameConst.BAG_TYPE_DECORATE;
            }
            else if (addGoods is GoodsMountEquip)
            {
                bag_type = GameConst.BAG_TYPE_RIDE_EQUIP;
            }
            else if (addGoods is GoodsGodEquip)
            {
                bag_type = GameConst.BAG_TYPE_GOD_EQUIP;
            }
            else if (addGoods is GoodsLuaEx)
            {
                bag_type = GoodsHelper.GetGoodsBagTypeByGoodsId(addGoods.type_idx);
            }

            return bag_type;
        }

        public void CheckBagCanQuickUse_addGoods(Goods addGoods)
        {
            if (addGoods == null)
                return;
            if (CanShowQuickUseWindow() == false)
                return;


            if (IsBetterThanBody(addGoods))
            {
                if (ui.ugui.UIManager.Instance.GetWindow("UIShortcutUseWindow") == null)
                {
                    //重置遍历过的部位
                    FreshPosState();
                    GoodsItem good = GetShowItem();
                    if (good != null)
                    {
                        uint bag_type = GetBayTypeByGoods(good);
                        ui.ugui.UIManager.Instance.ShowWindow("UIShortcutUseWindow", good, bag_type);
                    }
                }
                else
                {
                    //防止过号
                    mTempGoodsList.Add(addGoods as GoodsItem);
                }
                return;
            }


  

            //bool is_can_show = false;
            //uint bag_type = GameConst.BAG_TYPE_NORMAL;

            //is_can_show = IsBetterThanBody(addGoods);
            //bag_type = GetBayTypeByGoods(addGoods);

            //if (addGoods.effect == "consume_reward")
            //{
            //    is_can_show = CheckBagCanQuickUse_ConsumeBox(addGoods);
            //}

            //if (is_can_show)
            //    ui.ugui.UIManager.Instance.ShowWindow("UIShortcutUseWindow", addGoods, bag_type);
        }

        /// <summary>
        /// 消费宝箱是否可以快捷使用
        /// </summary>
        /// <param name="goods"></param>
        public bool CheckBagCanQuickUse_ConsumeBox(Goods goods)
        {
            if (goods.effect == "consume_reward")
            {
                uint totalValue = DBTextResource.ParseArrayUint(goods.arg, ",")[0];
                if (mConsumeValues.ContainsKey(goods.id) == true && mConsumeValues[goods.id] >= totalValue)
                {
                    return true;
                }
            }

            return false;
        }

        //背包转移 存放、 取回 等
        public void BagTransport(uint from, uint to, ulong oid, uint num)
        {
            C2SBagTransport data = new C2SBagTransport();
            data.origin = from;
            data.target = to;
            data.oid = oid;
            data.num = num;
            NetClient.GetBaseClient().SendData<C2SBagTransport>(NetMsg.MSG_BAG_TRANSPORT, data);
        }

        public void SendAddBagPage(uint idx, ushort bag_type, bool auto_buy = false)
        {
            BagItemInfo info = null;
            CurrentLockBagItem.TryGetValue(bag_type, out info);

            if (info == null)
                return;
            if (bag_type == GameConst.BAG_TYPE_WARE)
            {
                if (mWareTotalCount == mWareMaxCount)
                {
                    UINotice.GetInstance().ShowMessage(xc.TextHelper.GetConstText("CODE_TEXT_LOCALIZATION_70"));
                    return;
                }
            }
            else if (bag_type == GameConst.BAG_TYPE_NORMAL)
            {
                if (mBagTotalCount == mBagMaxCount)
                {
                    UINotice.GetInstance().ShowMessage(xc.TextHelper.GetConstText("CODE_TEXT_LOCALIZATION_71"));
                    return;
                }
            }
            C2SBagAddSize size = new C2SBagAddSize();
            size.bag_type = bag_type;
            size.to_cell = idx;
            if (auto_buy)
                size.auto_buy = GameConst.BOOLEN_INT_TRUE;
            else
                size.auto_buy = GameConst.BOOLEN_INT_FALSE;
            NetClient.GetBaseClient().SendData<C2SBagAddSize>(NetMsg.MSG_BAG_ADD_SIZE, size);
        }

        public void SendBagGoodsListByType(uint _type)
        {
            C2SGoodsList pack = new C2SGoodsList();
            pack.type = _type;
            NetClient.GetBaseClient().SendData<C2SGoodsList>(NetMsg.MSG_GOODS_LIST, pack);
            xc.ui.ugui.UIManager.Instance.ShowWaitScreen(true);
        }

        public void SendOpenWare()
        {
            if (LocalPlayerManager.Instance.Diamond < GameConstHelper.GetUint("GAME_WARE_SYS_OPEN_DIAMOND"))
            {
                UINotice.Instance.ShowMessage(xc.TextHelper.GetConstText("CODE_TEXT_LOCALIZATION_72"));
                return;
            }

            //            C2SWareSysOpen open = new C2SWareSysOpen();
            //            NetClient.GetBaseClient().SendData< C2SWareSysOpen>(NetMsg.MSG_WARE_SYS_OPEN , open);
        }


        private IEnumerator LoadIconConfigAsync()
        {
            XmlDocument xmlDoc = new XmlDocument();
            SGameEngine.AssetResource ar = new SGameEngine.AssetResource();
            yield return xc.MainGame.GetGlobalMono().StartCoroutine(SGameEngine.ResourceLoader.Instance.load_asset(UIDynamicPrefabCfg.NEW_UI_GOODS_PACK_ASSET, typeof(TextAsset), ar));
            string strData = CommonTool.BytesToUtf8((ar.asset_ as TextAsset).bytes);
            if (strData != "")
                xmlDoc.LoadXml(strData);
            ar.destroy();

            XmlNode root = xmlDoc.SelectSingleNode("MainIconTextures");
            mIconConfig = new WXIconAsset();
            foreach (XmlNode kChild in root.ChildNodes)
            {
                if (kChild.Name == "MainIconTexture")
                {
                    List<uint> icon_list = new List<uint>();
                    XmlElement _elem = kChild as XmlElement;
                    string name_path = _elem.GetAttribute("MainTexturePath");

                    foreach (var node in kChild.ChildNodes)
                    {
                        XmlElement elem = node as XmlElement;
                        if (elem != null)
                        {
                            string id = elem.GetAttribute("Id");

                            string x = elem.GetAttribute("x");

                            string y = elem.GetAttribute("y");

                            string width = elem.GetAttribute("width");

                            string height = elem.GetAttribute("height");

                            Rect rect = new Rect(float.Parse(x), float.Parse(y), float.Parse(width), float.Parse(height));
                            mIconConfig.IconList.Add(uint.Parse(id), rect);
                            icon_list.Add(uint.Parse(id));
                        }
                    }
                    mIconConfig.MainTexIconList.Add(name_path, icon_list);
                }
            }

            //            SGameEngine.AssetResource ar = new SGameEngine.AssetResource();
            //            yield return  xc.MainGame.GetGlobalMono().StartCoroutine(SGameEngine.ResourceLoader.Instance.load_asset("Assets/Res/UI/Textures/Goods/GoodsPack/GoodsPackAsset.asset" , typeof(WXIconAsset), ar));
            //            mIconConfig = ar.asset_ as WXIconAsset;
        }

        public void RegisterAllMessage()
        {
            //            LoadIconConfigAsync();
            xc.MainGame.GetGlobalMono().StartCoroutine(LoadIconConfigAsync());
            ClientEventMgr.GetInstance().UnsubscribeClientEvent((int)ClientEvent.CE_SERVER_TIME_CHANGED, OnServerTimeUpdate);
            ClientEventMgr.GetInstance().SubscribeClientEvent((int)ClientEvent.CE_SERVER_TIME_CHANGED, OnServerTimeUpdate);


            ClientEventMgr.GetInstance().UnsubscribeClientEvent((int)ClientEvent.CE_SHORT_CUT_TIPS_NO_GOODS, EventShortCutTipsNoGoods);
            ClientEventMgr.GetInstance().SubscribeClientEvent((int)ClientEvent.CE_SHORT_CUT_TIPS_NO_GOODS, EventShortCutTipsNoGoods);

            Game.GetInstance().SubscribeNetNotify(NetMsg.MSG_GOODS_LIST, HandleServerData);
            Game.GetInstance().SubscribeNetNotify(NetMsg.MSG_BAG_SIZE, HandleServerData);
            Game.GetInstance().SubscribeNetNotify(NetMsg.MSG_GOODS_DEL, HandleServerData);
            Game.GetInstance().SubscribeNetNotify(NetMsg.MSG_EP_STRENGTH, HandleServerData);
            Game.GetInstance().SubscribeNetNotify(NetMsg.MSG_EP_STRENGTH_INFO, HandleServerData);
            Game.GetInstance().SubscribeNetNotify(NetMsg.MSG_EP_BAPTIZE_INFO, HandleServerData);//洗练信息
            Game.GetInstance().SubscribeNetNotify(NetMsg.MSG_EP_BAPTIZE, HandleServerData);
            Game.GetInstance().SubscribeNetNotify(NetMsg.MSG_EP_BAPTIZE_LOCK, HandleServerData);
            Game.GetInstance().SubscribeNetNotify(NetMsg.MSG_EP_BAPTIZE_OPEN, HandleServerData);
            Game.GetInstance().SubscribeNetNotify(NetMsg.MSG_EP_SUIT_FORGE, HandleServerData);
            Game.GetInstance().SubscribeNetNotify(NetMsg.MSG_EP_SUIT_REFINE, HandleServerData);
            Game.GetInstance().SubscribeNetNotify(NetMsg.MSG_EP_GEM_INFO, HandleServerData);
            Game.GetInstance().SubscribeNetNotify(NetMsg.MSG_GOODS_CD, HandleServerData);
            Game.GetInstance().SubscribeNetNotify(NetMsg.MSG_SOUL_BOOK, HandleServerData);
            Game.GetInstance().SubscribeNetNotify(NetMsg.MSG_GOODS_DAILY_LIMIT, HandleServerData);
            Game.GetInstance().SubscribeNetNotify(NetMsg.MSG_GOODS_ALL_DAILY_LIMIT, HandleServerData);

            Game.GetInstance().SubscribeNetNotify(NetMsg.MSG_DECORATE_POS_INFO, HandleServerData);   // 饰品部位信息
            Game.GetInstance().SubscribeNetNotify(NetMsg.MSG_DECORATE_POS_STRENGTH, HandleServerData); // 饰品强化反馈
            Game.GetInstance().SubscribeNetNotify(NetMsg.MSG_DECORATE_BREAK, HandleServerData); // 饰品突破反馈

            Game.GetInstance().SubscribeNetNotify(NetMsg.MSG_TITLE_INFO, HandleServerData); // 称号信息
            Game.GetInstance().SubscribeNetNotify(NetMsg.MSG_ADD_TITLE, HandleServerData); // 添加称号
            Game.GetInstance().SubscribeNetNotify(NetMsg.MSG_DEL_TITLE, HandleServerData); // 删除称号

            Game.GetInstance().SubscribeNetNotify(NetMsg.MSG_CONSUME_BOX, HandleServerData); // 消费礼包消费情况
            Game.GetInstance().SubscribeNetNotify(NetMsg.MSG_EP_FAIRY_RENEW, HandleServerData); // 小精灵续费

            Game.GetInstance().SubscribeNetNotify(NetMsg.MSG_BOSS_DROP_GOODS_INFO, HandleServerData); // 打宝，boss掉落记录装备tips信息

            Game.GetInstance().SubscribeNetNotify(NetMsg.MSG_RIDE_EQUIP_POS_INFO, HandleServerData);//坐骑装备刚登陆的锻造信息
            Game.GetInstance().SubscribeNetNotify(NetMsg.MSG_RIDE_EQUIP_FORGE, HandleServerData);//坐骑装备锻造信息

            Game.GetInstance().SubscribeNetNotify(NetMsg.MSG_LIGHT_EQUIP_INFO, HandleServerData); // 光武信息-神魂信息
            Game.GetInstance().SubscribeNetNotify(NetMsg.MSG_LIGHT_SOUL_PUT_ON, HandleServerData); // 神魂穿戴

        }

        void OnServerTimeUpdate(CEventBaseArgs data)
        {

        }

        /// <summary>
        /// 刷新单个洗练
        /// </summary>
        /// <param name="pkgbaptizeInfo">洗练信息</param>
        /// <param name="isShowSuccessEffect">是否显示洗练成功特效</param>
        /// <param name="showEffectGrooveIds">需要显示特效的洗练槽id列表</param>
        private void RereshOneBaptizeInfo(PkgBaptizeInfo pkgbaptizeInfo, bool isShowSuccessEffect, List<uint> showEffectGrooveIds)
        {

            //var info = StrengthInfos.Find(delegate (EquipPosInfo _info) { return (_info.Pos == (EEquipPos)pkgbaptizeInfo.pos && _info.Index == pkgbaptizeInfo.index); });
            EquipPosInfo info = xc.Equip.EquipHelper.GetStrengthInfoByPosAndIndex(pkgbaptizeInfo.pos, pkgbaptizeInfo.index);
            if (info != null)
            {
                foreach (var baptizeGroove in pkgbaptizeInfo.infos)
                {
                    EquipBaptizeInfo baptizeInfo = null;
                    if (info.BaptizeInfos.TryGetValue(baptizeGroove.id, out baptizeInfo))
                    {
                        baptizeInfo.State = (EquipBaptizeInfo.EquipBaptizeState)baptizeGroove.state;
                        baptizeInfo.BaptizeAttr.Clear();
                        if (baptizeGroove.attr != null && baptizeGroove.attr.Count > 0)
                        {
                            baptizeInfo.BaptizeAttr.Add(baptizeGroove.attr[0].attr, baptizeGroove.attr[0].value);
                            info.AllBaptizeAttr.Add(baptizeGroove.attr[0].attr, baptizeGroove.attr[0].value);
                        }
                    }
                }
            }
            ClientEventMgr.GetInstance().FireEvent((int)ClientEvent.CE_BAPTIZE_EQUIP_RESULT, new CEventEventParamArgs(info, isShowSuccessEffect, showEffectGrooveIds));
        }

        /// <summary>
        /// 洗练改变
        /// </summary>
        /// <param name="msg"></param>
        private void RereshBaptizeInfo(S2CEpBaptizeInfo msg)
        {
            BaptizeCount = msg.num;
            foreach (var item in msg.infos)
            {
                //var info = StrengthInfos.Find(delegate (EquipPosInfo _info) { return (_info.Pos == (EEquipPos)item.pos && _info.Index == item.index); });
                EquipPosInfo info = xc.Equip.EquipHelper.GetStrengthInfoByPosAndIndex(item.pos, item.index);
                if (info != null)
                {
                    if (info.BaptizeInfos == null)
                        info.BaptizeInfos = new Dictionary<uint, EquipBaptizeInfo>();
                    else
                        info.BaptizeInfos.Clear();
                    foreach (var baptizeGroove in item.infos)
                    {
                        EquipBaptizeInfo baptizeInfo = null;
                        if (baptizeGroove.attr != null && baptizeGroove.attr.Count > 0)
                        {
                            baptizeInfo = new EquipBaptizeInfo(baptizeGroove.id, baptizeGroove.state, baptizeGroove.attr[0], info.Pos, info.Index);
                            info.AllBaptizeAttr.Add(baptizeGroove.attr[0].attr, baptizeGroove.attr[0].value);
                        }
                        else
                        {
                            baptizeInfo = new EquipBaptizeInfo(baptizeGroove.id, baptizeGroove.state, null, info.Pos, info.Index);
                        }
                        info.BaptizeInfos.Add(baptizeInfo.Id, baptizeInfo);
                    }
                }
            }
            ClientEventMgr.GetInstance().FireEvent((int)ClientEvent.CE_BAPTIZE_EQUIP_CHANGED, new CEventBaseArgs());
        }


        /// <summary>
        /// 强化改变
        /// </summary>
        /// <param name="msg"></param>
        private void RereshStrengthInfo(S2CEpStrengthInfo msg)
        {

            var installCanUpgrade = Equip.EquipHelper.GetStrengGoodsEquip();
            foreach (var item in msg.infos)
            {
                //var info = StrengthInfos.Find(delegate (EquipPosInfo _info) { return (_info.Pos == (EEquipPos)item.pos&& _info.Index == item.index); });
                EquipPosInfo info = xc.Equip.EquipHelper.GetStrengthInfoByPosAndIndex(item.pos, item.index);

                if (info != null)
                {
                    if (msg.origin == GameConst.GOODS_OPERATE_WEAR)
                    {
                        //如果下发是一定是改变的n
                        if (info.InstallPosEquip != null && info.StrengthLv > item.lv)
                        {
                            string tips_msg = DBConstText.GetText("GAME_GOODS_AUTO_INTERIT_STRENGTHLV_TIPS");
                            xc.ui.UIWidgetHelp.GetInstance().ShowNoticeDlg(tips_msg);

                        }

                    }
                    info.InstallPosEquip = null;
                    info.StrengthDegree = item.degree;
                    if (item.lv != info.StrengthLv)
                    {
                        info.StrengthStuff = Equip.EquipHelper.GetStrengthStuff(item.lv);
                        info.StrengthShowRedPointGoods = Equip.EquipHelper.GetStrengthShowRedPointGoods(item.lv);
                        GoodsEquip equip = Equip.EquipHelper.EquipIsInstallByPos(info.Pos, info.Index);
                        if (equip != null)
                            equip.StrenghtLv = item.lv;
                    }
                    info.StrengthLv = item.lv;
                    //var data_strength_lv = DBManager.Instance.QuerySqliteField<string>(GlobalConfig.DBFile, "data_strength_lv", "lv", info.StrengthLv.ToString(), "degree");
                    //var raw = data_strength_lv[0];
                    //info.StrengthMaxDegree = DBTextResource.ParseUI(raw);
                    DBStrengthLv.StrengthLvInfo strengthLvInfo = DBStrengthLv.Instance.GetStrengthLvInfo(info.StrengthLv);
                    if (strengthLvInfo != null)
                    {
                        info.StrengthMaxDegree = strengthLvInfo.Degree;
                    }


                    foreach (var equip in installCanUpgrade)
                    {
                        if (equip.EquipPos == info.Pos && equip.Index == info.Index)
                        {
                            info.InstallPosEquip = equip;
                        }

                    }
                }
            }



            ClientEventMgr.GetInstance().FireEvent((int)ClientEvent.CE_STRENGTH_EQUIP_CHANGED, new CEventBaseArgs());
        }
        /// <summary>
        /// 强化反馈
        /// </summary>
        /// <param name="msg"></param>
        private void StrengthResult(S2CEpStrength msg)
        {
            EquipPosInfo _info = null;
            foreach (var info in StrengthInfos)
            {
                if (info.Pos == msg.info.pos && info.Index == msg.info.index)
                {
                    info.StrengthDegree = msg.info.degree;
                    if (msg.info.lv != info.StrengthLv)
                    {
                        info.StrengthStuff = Equip.EquipHelper.GetStrengthStuff(msg.info.lv);
                        info.StrengthShowRedPointGoods = Equip.EquipHelper.GetStrengthShowRedPointGoods(msg.info.lv);
                        GoodsEquip equip = Equip.EquipHelper.EquipIsInstallByPos(info.Pos, info.Index);
                        if (equip != null)
                            equip.StrenghtLv = msg.info.lv;
                        ClientEventMgr.Instance.FireEvent((int)ClientEvent.CE_STRENGTH_UP_LV, new CEventEventParamArgs(info.Pos, msg.info.lv));
                    }
                    info.StrengthLv = msg.info.lv;
                    //var data_strength_lv = DBManager.Instance.QuerySqliteField<string>(GlobalConfig.DBFile, "data_strength_lv", "lv", info.StrengthLv.ToString(), "degree");
                    //var raw = data_strength_lv[0];
                    DBStrengthLv.StrengthLvInfo strengthLvInfo = DBStrengthLv.Instance.GetStrengthLvInfo(info.StrengthLv);
                    if (strengthLvInfo != null)
                    {
                        info.StrengthMaxDegree = strengthLvInfo.Degree;
                    }
                    _info = info;
                    break;
                }
            }
            ClientEventMgr.Instance.FireEvent((int)ClientEvent.CE_STRENGTH_RESULT, new CEventEventParamArgs(msg.add_degree, msg.mult, _info));
        }
        Dictionary<string, ulong> mTmpGetGoodsList = new Dictionary<string, ulong>();
        Dictionary<uint, TmpGetGoods> mTmpGetGoodsArray = new Dictionary<uint, TmpGetGoods>();
        public class TmpGetGoods
        {
            public uint goods_id;
            public string name;
            public ulong num;
        }
        Dictionary<uint, uint> mNoUseTimesGids = new Dictionary<uint, uint>(); //没有使用次数的物品ID列表
                                                                               //         public class UseTimesGid
                                                                               //         {
                                                                               //             public uint has_use_times; //已经使用的次数
                                                                               //             public uint total_use_times; //总共使用的次数
                                                                               //         }

        /// <summary>
        /// 判断一个物品ID已经使用的次数
        /// </summary>
        /// <param name="gid"></param>
        /// <returns></returns>
        public uint HasUseTimesByGid(uint gid)
        {
            if (mNoUseTimesGids.ContainsKey(gid))
            {
                return mNoUseTimesGids[gid];
            }
            return 0;
        }


        void RefreshExpireTime(uint bag_type, ulong oid, uint expire_time, uint operation)
        {
            switch (bag_type)
            {
                case GameConst.BAG_TYPE_NORMAL:
                    {
                        Goods goods;
                        if (BagGoodsOids.TryGetValue(oid, out goods))
                        {
                            goods.expire_time = expire_time;
                            ClientEventMgr.GetInstance().FireEvent((int)ClientEvent.CE_BAG_UPDATE, new CEventBaseArgs());
                        }
                        break;
                    }
                case GameConst.BAG_TYPE_INSTALL_1:
                    {
                        GoodsEquip goods;
                        if (InstallEquip.TryGetValue(oid, out goods))
                        {
                            uint EquipModelChange = 0;//换模型
                            uint oldModelId = goods.ModelId;
                            goods.expire_time = expire_time;
                            uint newModelId = goods.ModelId;
                            if (oldModelId != newModelId)
                            {
                                EquipModelChange = Equip.EquipHelper.ChangeEquipPart(LocalPlayerManager.Instance.LocalActorAttribute.UnitId, newModelId, goods.EquipPos);
                            }
                            if (EquipModelChange != 0)
                                ClientEventMgr.Instance.FireEvent((int)ClientEvent.CE_INSTALLED_EQUIP_CHANGED, new CEventEventParamArgs(EquipModelChange, goods.EquipPos));

                            Equip.EquipHelper.CalculatorSuitNum(InstallEquip);
                            ClientEventMgr.GetInstance().FireEvent((int)ClientEvent.CE_INSTALL_1_UPDATE, new CEventBaseArgs());
                            if (goods.EquipPos == GameConst.POS_ELFIN)
                            {
                                ClientEventMgr.GetInstance().FireEvent((int)ClientEvent.CE_INSTALL_1_EFLIN_UPDATE, new CEventBaseArgs());
                            }
                        }
                        break;
                    }
                default:
                    break;
            }
            ClientEventMgr.GetInstance().FireEvent((int)ClientEvent.CE_GOODS_UPDATE_EXPIRE_TIME, new CEventBaseArgs());
            if (operation == 0)//续费成功
                UINotice.Instance.ShowMessage(xc.DBConstText.GetText("ELFIN_SUCCESS_ADD_TIME"));
        }

        public void UpdateEquipRefreshTime(uint equip_pos)
        {
            if (equip_pos != GameConst.POS_ELFIN)
                return;//目前这个方法只接受小精灵调用
            List<GoodsEquip> equip_array = Equip.EquipHelper.GetInstallEquipListByPos(equip_pos);
            if (equip_array == null)
                return;
            for (int index = 0; index < equip_array.Count; ++index)
            {
                GoodsEquip goods = equip_array[index];
                uint EquipModelChange = 0;//换模型
                uint newModelId = goods.ModelId;
                {
                    EquipModelChange = Equip.EquipHelper.ChangeEquipPart(LocalPlayerManager.Instance.LocalActorAttribute.UnitId, newModelId, goods.EquipPos);
                }
                if (EquipModelChange != 0)
                    ClientEventMgr.Instance.FireEvent((int)ClientEvent.CE_INSTALLED_EQUIP_CHANGED, new CEventEventParamArgs(EquipModelChange, goods.EquipPos));

                Equip.EquipHelper.CalculatorSuitNum(InstallEquip);
                ClientEventMgr.GetInstance().FireEvent((int)ClientEvent.CE_INSTALL_1_UPDATE, new CEventBaseArgs());
            }
        }

        private int AddGoodsToBag(Goods goods)
        {
            return AddGoodsToPanelSort(goods, ref BagPanelSort, ref NeedUpdateBagIndexArray);
        }

        private int TryUpdateGoodsToBag(Goods goods)
        {
            return TryUpdateGoodsToPanelSort(goods, ref BagPanelSort, ref NeedUpdateBagIndexArray);
        }

        public void DelGoods()
        {
            DelGoodsToPanelSort(ref BagPanelSort, ref NeedUpdateBagIndexArray);
        }

        void CheckBagForce()
        {
            CheckForcePanelSort(ref BagPanelSort, ref NeedUpdateBagIndexArray, (int)ClientEvent.CE_BAG_UPDATE_SLOT_INSTALL);
        }


        public void SortBagData()
        {
            int before_count = BagPanelSort.Count;
            BagPanelSort.Clear();
            NeedUpdateBagIndexArray.Clear();
            //BagPanelSort.RemoveAll((a) => { return a == null || a.is_deleted; });

            foreach (var item in BagGoodsOids)
            {

                item.Value.RefreshEquipUp();
                BagPanelSort.Add(item.Value);

            }

            for (int index = 0; index < mBagTotalCount; ++index)
            {
                NeedUpdateBagIndexArray.Add(index);
            }

            BagPanelSort.Sort((a, b) =>
            {
                if (a.sort_top > b.sort_top)
                    return -1;
                if (a.sort_top < b.sort_top)
                    return 1;

                if (a.is_equipUp && b.is_equipUp == false)
                    return -1;
                else if (a.is_equipUp == false && b.is_equipUp)
                    return 1;
                if (a.sort_id < b.sort_id)
                    return -1;
                else if (a.sort_id > b.sort_id)
                    return 1;
                if (a.type_idx > b.type_idx)
                    return -1;
                else if (a.type_idx < b.type_idx)
                    return 1;
                if (a.id < b.id)
                    return -1;
                else if (a.id > b.id)
                    return 1;
                return 0;
            });
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="size_before_extend">扩展格子前，拥有的格子数</param>
        /// <param name="extend_size">本次扩展的格子数</param>
        void CheckBagPageUpdate(uint size_before_extend, uint extend_size)
        {
            NeedUpdateBagIndexArray.Clear();
            for (int index = 0; index < extend_size; ++index)
            {
                NeedUpdateBagIndexArray.Add((int)(size_before_extend + index));
            }
            ClientEventMgr.GetInstance().FireEvent((int)ClientEvent.CE_BAG_UPDATE_SLOT_EXTEND, new CEventBaseArgs(NeedUpdateBagIndexArray));
            NeedUpdateBagIndexArray.Clear();
        }

        #region 仓库
        private int AddGoodsToPanelSort(Goods goods, ref List<Goods> panel_sort, ref List<int> index_array)
        {
            for (int index = 0; index < panel_sort.Count; ++index)
            {
                if (panel_sort[index] == null)
                {
                    panel_sort[index] = goods;
                    index_array.Add(index);
                    return index;
                }
            }
            panel_sort.Add(goods);
            int max_count = panel_sort.Count - 1;
            index_array.Add(max_count);
            return max_count;
        }
        private int TryUpdateGoodsToPanelSort(Goods goods, ref List<Goods> panel_sort, ref List<int> index_array)
        {
            for (int index = 0; index < panel_sort.Count; ++index)
            {
                if (panel_sort[index] == goods)
                {
                    if (index_array.Contains(index) == false)
                        index_array.Add(index);
                    return index;
                }
            }
            return -1;
        }
        public void DelGoodsToPanelSort(ref List<Goods> panel_sort, ref List<int> index_array)
        {
            for (int index = 0; index < panel_sort.Count; ++index)
            {
                if (panel_sort[index] != null && panel_sort[index].is_deleted)
                {
                    if (index_array.Contains(index) == false)
                        index_array.Add(index);
                    panel_sort[index] = null;
                }
            }
        }
        void CheckForcePanelSort(ref List<Goods> panel_sort, ref List<int> index_array, int fire_event)
        {
            index_array.Clear();
            Goods goods = null;
            for (int index = 0; index < panel_sort.Count; ++index)
            {
                goods = panel_sort[index];
                if (goods != null && goods.is_deleted == false && goods is GoodsEquip)
                {
                    index_array.Add(index);
                }
            }
            ClientEventMgr.GetInstance().FireEvent(fire_event, null);
            index_array.Clear();
        }
        private int AddGoodsToWare(Goods goods)
        {
            return AddGoodsToPanelSort(goods, ref WarePanelSort, ref NeedUpdateWareIndexArray);
        }

        private int TryUpdateGoodsToWare(Goods goods)
        {
            return TryUpdateGoodsToPanelSort(goods, ref WarePanelSort, ref NeedUpdateWareIndexArray);
        }

        public void DelWareGoods()
        {
            DelGoodsToPanelSort(ref WarePanelSort, ref NeedUpdateWareIndexArray);
        }

        void CheckForcePanelSort_ware()
        {
            CheckForcePanelSort(ref WarePanelSort, ref NeedUpdateWareIndexArray, (int)ClientEvent.CE_WARE_UPDATE_SLOT_INSTALL);
        }


        public void SortWareData()
        {
            int before_count = WarePanelSort.Count;
            WarePanelSort.Clear();
            NeedUpdateWareIndexArray.Clear();
            //WarePanelSort.RemoveAll((a) => { return a == null || a.is_deleted; });

            foreach (var item in WareHouseGoodsOids)
            {

                item.Value.RefreshEquipUp();
                WarePanelSort.Add(item.Value);

            }

            for (int index = 0; index < mWareTotalCount; ++index)
            {
                NeedUpdateWareIndexArray.Add(index);
            }

            WarePanelSort.Sort((a, b) =>
            {
                //                 if (a.is_equipUp && b.is_equipUp == false)
                //                     return -1;
                //                 else if (a.is_equipUp == false && b.is_equipUp)
                //                     return 1;
                if (a.sort_id < b.sort_id)
                    return -1;
                else if (a.sort_id > b.sort_id)
                    return 1;
                if (a.type_idx > b.type_idx)
                    return -1;
                else if (a.type_idx < b.type_idx)
                    return 1;
                if (a.id < b.id)
                    return -1;
                else if (a.id > b.id)
                    return 1;
                return 0;
            });
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="size_before_extend">扩展格子前，拥有的格子数</param>
        /// <param name="extend_size">本次扩展的格子数</param>
        void CheckWarePageUpdate(uint size_before_extend, uint extend_size)
        {
            NeedUpdateWareIndexArray.Clear();
            for (int index = 0; index < extend_size; ++index)
            {
                NeedUpdateWareIndexArray.Add((int)(size_before_extend + index));
            }
            ClientEventMgr.GetInstance().FireEvent((int)ClientEvent.CE_WARE_UPDATE_SLOT_EXTEND, new CEventBaseArgs(NeedUpdateWareIndexArray));
            NeedUpdateWareIndexArray.Clear();
        }
        #endregion
        //刷新只包含增或改变物品容器(背包、仓库等)
        private void RefreshItemByContainer(uint bagType, List<PkgGoodsInfo> goods, uint origin, byte[] data)
        {
            switch (bagType)
            {
                case GameConst.BAG_TYPE_NORMAL:
                    {
                        if (origin == GameConst.GOODS_OPERATE_LOGIN)
                        {//登录的背包信息，需先清空背包数据
                            BagGoodsOids.Clear();
                            BagTypeIdAndOids.Clear();
                            BagPanelSort.Clear();
                        }
                        mTmpGetGoodsList.Clear();
                        mTmpGetGoodsArray.Clear();
                        NeedUpdateBagIndexArray.Clear();
                        for (int i = 0; i < goods.Count; i++)
                        {
                            ulong addGoodsCount = 0; // 添加的物品数量
                            var dataGoods = goods[i];
                            Goods _goods = null;
                            if (BagGoodsOids.TryGetValue(dataGoods.oid, out _goods))// 背包中已经有该物品，则进行更新
                            {
                                //_goods.type_idx = dataGoods.gid;
                                uint new_type_idx = dataGoods.gid;
                                if (dataGoods.num > _goods.num && (origin == GameConst.GOODS_OPERATE_NONE || origin == GameConst.GOODS_OPERATE_DECOMPOSE))
                                {
                                    ulong add_num = dataGoods.num - _goods.num;
                                    if (mTmpGetGoodsList.ContainsKey(_goods.name) == false)
                                        mTmpGetGoodsList.Add(_goods.name, add_num);
                                    else
                                        mTmpGetGoodsList[_goods.name] += add_num;
                                    if (mTmpGetGoodsArray.ContainsKey(new_type_idx) == false)
                                    {
                                        TmpGetGoods tmp_add = new TmpGetGoods();
                                        tmp_add.goods_id = new_type_idx;
                                        tmp_add.num = add_num;
                                        tmp_add.name = _goods.name;
                                        mTmpGetGoodsArray.Add(new_type_idx, tmp_add);
                                    }
                                    else
                                        mTmpGetGoodsArray[new_type_idx].num += add_num;

                                    addGoodsCount = add_num;
                                }

                                GoodsFactory.Update(dataGoods, _goods);
                                TryUpdateGoodsToBag(_goods);

                                // 对于特殊类型的物品，更新物品的时候也弹出快捷使用窗口
                                if (mIsLoginBagProtoCallBack == false && _goods.is_quickuse_always)
                                    CheckBagCanQuickUse_addGoods(_goods);
                            }
                            else// 背包中没有该物品
                            {
                                Goods newGoods = GoodsFactory.Create(dataGoods.type, dataGoods.gid, dataGoods);
                                if (newGoods == null)
                                    newGoods = new GoodsItem(dataGoods.gid);
                                newGoods.id = dataGoods.oid;
                                newGoods.num = dataGoods.num;
                                newGoods.bind = dataGoods.bind;
                                newGoods.expire_time = dataGoods.expire_time;
                                BagGoodsOids.Add(newGoods.id, newGoods);
                                List<ulong> oids = null;
                                if (BagTypeIdAndOids.TryGetValue(dataGoods.gid, out oids))
                                {
                                    oids.Add(dataGoods.oid);
                                }
                                else
                                {
                                    oids = new List<ulong>();
                                    oids.Add(dataGoods.oid);
                                    BagTypeIdAndOids.Add(dataGoods.gid, oids);
                                }

                                addGoodsCount = dataGoods.num;
                                ClientEventMgr.GetInstance().FireEvent((int)ClientEvent.CE_BAG_ADD, new CEventBaseArgs(dataGoods));

                                if (mIsLoginBagProtoCallBack == false && (origin == GameConst.GOODS_OPERATE_NONE || origin == GameConst.GOODS_OPERATE_DECOMPOSE))
                                {
                                    if (mTmpGetGoodsList.ContainsKey(newGoods.name) == false)
                                        mTmpGetGoodsList.Add(newGoods.name, newGoods.num);
                                    else
                                        mTmpGetGoodsList[newGoods.name] += newGoods.num;
                                    if (mTmpGetGoodsArray.ContainsKey(newGoods.type_idx) == false)
                                    {
                                        TmpGetGoods tmp_add = new TmpGetGoods();
                                        tmp_add.goods_id = newGoods.type_idx;
                                        tmp_add.num = newGoods.num;
                                        tmp_add.name = newGoods.name;
                                        mTmpGetGoodsArray.Add(newGoods.type_idx, tmp_add);
                                    }
                                    else
                                        mTmpGetGoodsArray[newGoods.type_idx].num += newGoods.num;


                                    //UINotice.Instance.ShowMessage(string.Format(DBConstText.GetText("BAG_GET_GOODS"), newGoods.name, newGoods.num));
                                }

                                AddGoodsToBag(newGoods);
                                if (mIsLoginBagProtoCallBack == false)
                                    CheckBagCanQuickUse_addGoods(newGoods);
                            }

                            if (addGoodsCount > 0)
                            {
                                ClientEventMgr.GetInstance().FireEvent((int)ClientEvent.CE_BAG_GOODS_ADD_NUM, new CEventEventParamArgs(dataGoods.oid, dataGoods.gid, addGoodsCount));
                                if (origin == GameConst.GOODS_OPERATE_NONE)
                                    ClientEventMgr.GetInstance().FireEvent((int)ClientEvent.CE_BAG_GOODS_ADD_NUM_OPERATE_NONE, new CEventEventParamArgs(dataGoods.oid, dataGoods.gid, addGoodsCount));

                            }
                        }
                        foreach (var item in mTmpGetGoodsList)
                        {
                            string blackBkg_name = GoodsHelper.ReplaceGoodsColor_blackBkg(item.Key);
                            UINotice.Instance.ShowMessage(string.Format(DBConstText.GetText("BAG_GET_GOODS"), blackBkg_name, item.Value));
                        }
                        if (xc.instance_behaviour.PickBossChipBehaviour.mHasSendPickPackage)
                        {
                            float now_time = Time.realtimeSinceStartup;
                            if (now_time > xc.instance_behaviour.PickBossChipBehaviour.mSendPickPackageTime + 5)
                                xc.instance_behaviour.PickBossChipBehaviour.mHasSendPickPackage = false;
                            else
                            {
                                foreach (var item in mTmpGetGoodsArray)
                                {
                                    uint goods_type = GoodsHelper.GetGoodsType(item.Value.goods_id);
                                    uint goods_sub_type = GoodsHelper.GetGoodsSubType(item.Value.goods_id);
                                    if (goods_type == GameConst.GIVE_TYPE_GOODS && goods_sub_type == GameConst.GIVE_SUB_TYPE_BOSS_CHIP)
                                    {
                                        xc.instance_behaviour.PickBossChipBehaviour.mHasSendPickPackage = false;
                                        xc.ui.ugui.UIManager.Instance.ShowWindow("UIBossFragmentsWindow", item.Value.goods_id, item.Value.num);
                                    }
                                }
                            }
                        }

                        if (mIsLoginBagProtoCallBack == true)
                            mIsLoginBagProtoCallBack = false;
                        else if (origin == GameConst.GOODS_OPERATE_LOGIN) //只有登录的时候需要检查一次整个背包
                        {
                            // BAG_TYPE_INSTALL_1背包信息初始化完毕后才检查
                            if (mInstall1GoodsListHaveInit == true)
                            {
                                CheckBagCanQuickUse();
                            }
                        }

                        if (origin == GameConst.GOODS_OPERATE_LOGIN)
                            SortBagData();
                        ClientEventMgr.GetInstance().FireEvent((int)ClientEvent.CE_BAG_UPDATE_SLOT, new CEventBaseArgs(NeedUpdateBagIndexArray));
                        NeedUpdateBagIndexArray.Clear();
                        ClientEventMgr.GetInstance().FireEvent((int)ClientEvent.CE_BAG_UPDATE, new CEventBaseArgs());
                        CheckBagFullRedPoint();
                        break;
                    }
                case GameConst.BAG_TYPE_SOUL:
                    {
                        mTmpGetGoodsArray.Clear();
                        for (int i = 0; i < goods.Count; i++)
                        {
                            var dataGoods = goods[i];
                            Goods _goods = null;
                            if (SoulGoodsOids.TryGetValue(dataGoods.oid, out _goods))
                            {
                                if (dataGoods.num > _goods.num && origin == GameConst.GOODS_OPERATE_NONE)
                                {
                                    ulong add_num = dataGoods.num - _goods.num;
                                    if (mTmpGetGoodsArray.ContainsKey(_goods.type_idx) == false)
                                    {
                                        TmpGetGoods tmp_add = new TmpGetGoods();
                                        tmp_add.goods_id = _goods.type_idx;
                                        tmp_add.num = add_num;
                                        tmp_add.name = _goods.name;
                                        mTmpGetGoodsArray.Add(_goods.type_idx, tmp_add);
                                    }
                                    else
                                        mTmpGetGoodsArray[_goods.type_idx].num += add_num;
                                }
                                GoodsFactory.Update(dataGoods, _goods);
                            }
                            else
                            {
                                Goods newGoods = GoodsFactory.Create(dataGoods.type, dataGoods.gid, dataGoods);
                                newGoods.id = dataGoods.oid;
                                newGoods.num = dataGoods.num;
                                newGoods.bind = dataGoods.bind;
                                newGoods.expire_time = dataGoods.expire_time;
                                SoulGoodsOids.Add(newGoods.id, newGoods);
                                List<ulong> oids = null;
                                if (SoulTypeIdAndOids.TryGetValue(dataGoods.gid, out oids))
                                {
                                    oids.Add(dataGoods.oid);
                                }
                                else
                                {
                                    oids = new List<ulong>();
                                    oids.Add(dataGoods.oid);
                                    SoulTypeIdAndOids.Add(dataGoods.gid, oids);
                                }
                                if (mIsLoginBagProtoCallBack == false && origin == GameConst.GOODS_OPERATE_NONE)
                                {
                                    if (mTmpGetGoodsList.ContainsKey(newGoods.name) == false)
                                        mTmpGetGoodsList.Add(newGoods.name, newGoods.num);
                                    else
                                        mTmpGetGoodsList[newGoods.name] += newGoods.num;
                                    if (mTmpGetGoodsArray.ContainsKey(newGoods.type_idx) == false)
                                    {
                                        TmpGetGoods tmp_add = new TmpGetGoods();
                                        tmp_add.goods_id = newGoods.type_idx;
                                        tmp_add.num = newGoods.num;
                                        tmp_add.name = newGoods.name;
                                        mTmpGetGoodsArray.Add(newGoods.type_idx, tmp_add);
                                    }
                                    else
                                        mTmpGetGoodsArray[newGoods.type_idx].num += newGoods.num;
                                }
                            }
                        }

                        foreach (var item in mTmpGetGoodsArray)
                        {
                            string blackBkg_name = GoodsHelper.ReplaceGoodsColor_blackBkg(item.Value.name);
                            UINotice.Instance.ShowMessage(string.Format(DBConstText.GetText("BAG_GET_GOODS"), blackBkg_name, item.Value.num));
                        }
                        ClientEventMgr.GetInstance().FireEvent((int)ClientEvent.CE_SOUL_UPDATE, new CEventBaseArgs());
                        break;
                    }
                case GameConst.BAG_TYPE_ARCHIVE:
                    {
                        mTmpGetGoodsArray.Clear();
                        for (int i = 0; i < goods.Count; i++)
                        {
                            var dataGoods = goods[i];
                            Goods _goods = null;
                            if (HandbookGoodsOids.TryGetValue(dataGoods.oid, out _goods))
                            {
                                if (dataGoods.num > _goods.num && origin == GameConst.GOODS_OPERATE_NONE)
                                {
                                    ulong add_num = dataGoods.num - _goods.num;
                                    if (mTmpGetGoodsArray.ContainsKey(_goods.type_idx) == false)
                                    {
                                        TmpGetGoods tmp_add = new TmpGetGoods();
                                        tmp_add.goods_id = _goods.type_idx;
                                        tmp_add.num = add_num;
                                        tmp_add.name = _goods.name;
                                        mTmpGetGoodsArray.Add(_goods.type_idx, tmp_add);
                                    }
                                    else
                                        mTmpGetGoodsArray[_goods.type_idx].num += add_num;
                                }
                                GoodsFactory.Update(dataGoods, _goods);
                            }
                            else
                            {
                                Goods newGoods = GoodsFactory.Create(dataGoods.type, dataGoods.gid, dataGoods);
                                newGoods.id = dataGoods.oid;
                                newGoods.num = dataGoods.num;
                                newGoods.bind = dataGoods.bind;
                                newGoods.expire_time = dataGoods.expire_time;
                                HandbookGoodsOids.Add(newGoods.id, newGoods);
                                List<ulong> oids = null;
                                if (HandbookTypeIdAndOids.TryGetValue(dataGoods.gid, out oids))
                                {
                                    oids.Add(dataGoods.oid);
                                }
                                else
                                {
                                    oids = new List<ulong>();
                                    oids.Add(dataGoods.oid);
                                    HandbookTypeIdAndOids.Add(dataGoods.gid, oids);
                                }
                                if (mIsLoginBagProtoCallBack == false && origin == GameConst.GOODS_OPERATE_NONE)
                                {
                                    if (mTmpGetGoodsList.ContainsKey(newGoods.name) == false)
                                        mTmpGetGoodsList.Add(newGoods.name, newGoods.num);
                                    else
                                        mTmpGetGoodsList[newGoods.name] += newGoods.num;
                                    if (mTmpGetGoodsArray.ContainsKey(newGoods.type_idx) == false)
                                    {
                                        TmpGetGoods tmp_add = new TmpGetGoods();
                                        tmp_add.goods_id = newGoods.type_idx;
                                        tmp_add.num = newGoods.num;
                                        tmp_add.name = newGoods.name;
                                        mTmpGetGoodsArray.Add(newGoods.type_idx, tmp_add);
                                    }
                                    else
                                        mTmpGetGoodsArray[newGoods.type_idx].num += newGoods.num;
                                }
                            }
                        }

                        foreach (var item in mTmpGetGoodsArray)
                        {
                            string blackBkg_name = GoodsHelper.ReplaceGoodsColor_blackBkg(item.Value.name);
                            UINotice.Instance.ShowMessage(string.Format(DBConstText.GetText("BAG_GET_GOODS"), blackBkg_name, item.Value.num));
                        }
                        ClientEventMgr.GetInstance().FireEvent((int)ClientEvent.CE_HANDBOOK_UPDATE, new CEventBaseArgs());
                        break;
                    }
                case GameConst.BAG_TYPE_WARE:
                    {
                        NeedUpdateWareIndexArray.Clear();
                        for (int i = 0; i < goods.Count; i++)
                        {
                            var dataGoods = goods[i];
                            Goods _goods = null;
                            if (WareHouseGoodsOids.TryGetValue(dataGoods.oid, out _goods))
                            {
                                GoodsFactory.Update(dataGoods, _goods);
                                TryUpdateGoodsToWare(_goods);
                            }
                            else
                            {
                                Goods newGoods = GoodsFactory.Create(dataGoods.type, dataGoods.gid, dataGoods);
                                newGoods.id = dataGoods.oid;
                                newGoods.num = dataGoods.num;
                                newGoods.bind = dataGoods.bind;
                                newGoods.expire_time = dataGoods.expire_time;
                                WareHouseGoodsOids.Add(newGoods.id, newGoods);
                                List<ulong> oids = null;
                                if (WareHouseTypeIdAndOids.TryGetValue(dataGoods.gid, out oids))
                                {
                                    oids.Add(dataGoods.oid);
                                }
                                else
                                {
                                    oids = new List<ulong>();
                                    oids.Add(dataGoods.oid);
                                    WareHouseTypeIdAndOids.Add(dataGoods.gid, oids);
                                }
                                AddGoodsToWare(newGoods);
                            }
                        }
                        if (origin == GameConst.GOODS_OPERATE_LOGIN)
                            SortWareData();
                        ClientEventMgr.GetInstance().FireEvent((int)ClientEvent.CE_WARE_UPDATE_SLOT, new CEventBaseArgs());
                        ClientEventMgr.GetInstance().FireEvent((int)ClientEvent.CE_WAREHOUSE_UPDATE, new CEventBaseArgs());
                        break;
                    }
                case GameConst.BAG_TYPE_TREASURE_HUNT:
                    {
                        for (int i = 0; i < goods.Count; i++)
                        {
                            var dataGoods = goods[i];
                            Goods _goods = null;
                            if (TreasureHuntGoodsOids.TryGetValue(dataGoods.oid, out _goods))
                            {
                                GoodsFactory.Update(dataGoods, _goods);
                            }
                            else
                            {
                                Goods newGoods = GoodsFactory.Create(dataGoods.type, dataGoods.gid, dataGoods);
                                newGoods.id = dataGoods.oid;
                                newGoods.num = dataGoods.num;
                                newGoods.bind = dataGoods.bind;
                                newGoods.expire_time = dataGoods.expire_time;
                                TreasureHuntGoodsOids.Add(newGoods.id, newGoods);
                            }
                        }
                        ClientEventMgr.GetInstance().FireEvent((int)ClientEvent.CE_TREASURE_HUNT_UPDATE, new CEventBaseArgs());
                        break;
                    }
                case GameConst.BAG_TYPE_ID_TREASURE:
                    {
                        for (int i = 0; i < goods.Count; i++)
                        {
                            var dataGoods = goods[i];
                            Goods _goods = null;
                            if (IDTreasureGoodsOids.TryGetValue(dataGoods.oid, out _goods))
                            {
                                GoodsFactory.Update(dataGoods, _goods);
                            }
                            else
                            {
                                Goods newGoods = GoodsFactory.Create(dataGoods.type, dataGoods.gid, dataGoods);
                                newGoods.id = dataGoods.oid;
                                newGoods.num = dataGoods.num;
                                newGoods.bind = dataGoods.bind;
                                newGoods.expire_time = dataGoods.expire_time;
                                IDTreasureGoodsOids.Add(newGoods.id, newGoods);
                            }
                        }
                        ClientEventMgr.GetInstance().FireEvent((int)ClientEvent.CE_ID_TREASURE_BAG_UPDATE, new CEventBaseArgs());
                        break;
                    }
                case GameConst.BAG_TYPE_DECORATE:
                    {
                        mTmpGetGoodsList.Clear();

                        for (int i = 0; i < goods.Count; i++)
                        {
                            var dataGoods = goods[i];
                            Goods _goods = null;
                            if (DecorateGoodsOids.TryGetValue(dataGoods.oid, out _goods))// 背包中已经有该物品，则进行更新
                            {
                                _goods.type_idx = dataGoods.gid;

                                if (dataGoods.num > _goods.num && origin == GameConst.GOODS_OPERATE_NONE)
                                {
                                    ulong add_num = dataGoods.num - _goods.num;
                                    if (mTmpGetGoodsList.ContainsKey(_goods.name) == false)
                                        mTmpGetGoodsList.Add(_goods.name, add_num);
                                    else
                                        mTmpGetGoodsList[_goods.name] += add_num;
                                }

                                GoodsFactory.Update(dataGoods, _goods);
                            }
                            else// 背包中没有该物品
                            {
                                Goods newGoods = GoodsFactory.Create(dataGoods.type, dataGoods.gid, dataGoods);
                                if (newGoods == null)
                                    newGoods = new GoodsItem(dataGoods.gid);

                                newGoods.id = dataGoods.oid;
                                newGoods.num = dataGoods.num;
                                newGoods.bind = dataGoods.bind;
                                newGoods.expire_time = dataGoods.expire_time;

                                DecorateGoodsOids.Add(newGoods.id, newGoods);
                                if (!DecorateTypeIdAndOids.ContainsKey(dataGoods.gid))
                                    DecorateTypeIdAndOids[dataGoods.gid] = new List<ulong>();
                                DecorateTypeIdAndOids[dataGoods.gid].Add(dataGoods.oid);

                                if (origin == GameConst.GOODS_OPERATE_NONE)
                                {
                                    if (mTmpGetGoodsList.ContainsKey(newGoods.name) == false)
                                        mTmpGetGoodsList.Add(newGoods.name, newGoods.num);
                                    else
                                        mTmpGetGoodsList[newGoods.name] += newGoods.num;

                                    CheckBagCanQuickUse_addGoods(newGoods);
                                }
                            }
                        }

                        foreach (var item in mTmpGetGoodsList)
                        {
                            string blackBkg_name = GoodsHelper.ReplaceGoodsColor_blackBkg(item.Key);
                            UINotice.Instance.ShowMessage(string.Format(DBConstText.GetText("BAG_GET_GOODS"), blackBkg_name, item.Value));
                        }

                        ClientEventMgr.GetInstance().FireEvent((int)ClientEvent.CE_DECORATE_BAG_UPDATE, new CEventBaseArgs()); ;
                        break;
                    }

                case GameConst.BAG_TYPE_MAGIC_EQUIP: // 法宝装备（背包初始化或更新）
                    {
                        mTmpGetGoodsList.Clear();

                        for (int i = 0; i < goods.Count; i++)
                        {
                            var dataGoods = goods[i];
                            GoodsMagicEquip equip = null;

                            if (MagicEquipGoodsOids.TryGetValue(dataGoods.oid, out equip))// 背包中已经有该装备，则进行更新
                            {
                                equip.type_idx = dataGoods.gid;

                                ulong add_num = dataGoods.num - equip.num;
                                if (add_num > 0 && origin == GameConst.GOODS_OPERATE_NONE)
                                {
                                    string equipName = equip.name;
                                    if (!mTmpGetGoodsList.ContainsKey(equipName))
                                        mTmpGetGoodsList.Add(equipName, add_num);

                                    else
                                        mTmpGetGoodsList[equipName] += add_num;
                                }

                                GoodsFactory.Update(dataGoods, equip);
                            }
                            else// 背包中没有该物品
                            {
                                var srvMagicEquip = dataGoods.magic_equip;
                                if (srvMagicEquip != null)
                                {
                                    GoodsMagicEquip newEquip = new GoodsMagicEquip(dataGoods.gid, srvMagicEquip);
                                    newEquip.bag_type = GameConst.BAG_TYPE_MAGIC_EQUIP;
                                    newEquip.id = dataGoods.oid;
                                    newEquip.num = dataGoods.num;
                                    newEquip.bind = dataGoods.bind;
                                    newEquip.expire_time = dataGoods.expire_time;

                                    newEquip.MagicId = srvMagicEquip.id;
                                    newEquip.StrengthLv = srvMagicEquip.str_lv;
                                    newEquip.TotalExp = srvMagicEquip.total_exp;
                                    newEquip.CurExp = srvMagicEquip.exp;

                                    MagicEquipGoodsOids.Add(newEquip.id, newEquip);

                                    List<ulong> oids = null;
                                    if (MagicEquipTypeIdAndOids.TryGetValue(dataGoods.gid, out oids))
                                    {
                                        oids.Add(dataGoods.oid);
                                    }
                                    else
                                    {
                                        oids = new List<ulong>();
                                        oids.Add(dataGoods.oid);
                                        MagicEquipTypeIdAndOids.Add(dataGoods.gid, oids);
                                    }

                                    if (origin == GameConst.GOODS_OPERATE_NONE)
                                    {
                                        if (mTmpGetGoodsList.ContainsKey(newEquip.name) == false)
                                            mTmpGetGoodsList.Add(newEquip.name, newEquip.num);

                                        else
                                            mTmpGetGoodsList[newEquip.name] += newEquip.num;
                                    }
                                }
                            }
                        }

                        foreach (var item in mTmpGetGoodsList)
                        {
                            string blackBkg_name = GoodsHelper.ReplaceGoodsColor_blackBkg(item.Key);
                            UINotice.Instance.ShowMessage(string.Format(DBConstText.GetText("BAG_GET_GOODS"), blackBkg_name, item.Value));
                        }

                        ClientEventMgr.GetInstance().FireEvent((int)ClientEvent.CE_MAGIC_EQUIP_BAG_UPDATE, new CEventBaseArgs()); ;
                        break;
                    }

                case GameConst.BAG_TYPE_INSTALL_2:
                    {
                        for (int i = 0; i < goods.Count; i++)
                        {

                            var dataGoods = goods[i];
                            if (dataGoods.soul != null)
                            {
                                GoodsSoul _goods = null;
                                if (InstallGoodsSouls.TryGetValue(dataGoods.soul.hole_id, out _goods))
                                {
                                    if (dataGoods.oid == _goods.id)
                                    {
                                        GoodsFactory.Update(dataGoods, _goods);
                                    }
                                    else
                                    {
                                        InstallGoodsSouls.Remove(dataGoods.soul.hole_id);
                                        GoodsSoul newGoods = new GoodsSoul(dataGoods.gid, dataGoods);
                                        newGoods.id = dataGoods.oid;
                                        newGoods.num = dataGoods.num;
                                        newGoods.bind = dataGoods.bind;
                                        newGoods.expire_time = dataGoods.expire_time;
                                        InstallGoodsSouls.Add(dataGoods.soul.hole_id, newGoods);
                                    }
                                }
                                else
                                {
                                    GoodsSoul newGoods = new GoodsSoul(dataGoods.gid, dataGoods);
                                    newGoods.id = dataGoods.oid;
                                    newGoods.num = dataGoods.num;
                                    newGoods.bind = dataGoods.bind;
                                    newGoods.expire_time = dataGoods.expire_time;
                                    InstallGoodsSouls.Add(dataGoods.soul.hole_id, newGoods);
                                }
                            }
                        }

                        ClientEventMgr.GetInstance().FireEvent((int)ClientEvent.CE_INSTALL_2_UPDATE, new CEventBaseArgs());
                        break;
                    }
                case GameConst.BAG_TYPE_INSTALL_1:
                    {
                        uint EquipModelChange = 0;//换模型
                        uint pos = GameConst.POS_WEAPON;
                        bool has_elfin = false;
                        for (int i = 0; i < goods.Count; i++)
                        {
                            var dataGoods = goods[i];
                            GoodsEquip _goods = null;

                            if (InstallEquip.TryGetValue(dataGoods.oid, out _goods))
                            {
                                //EquipPosInfo Posinfo = ItemManager.Instance.StrengthInfos.Find(delegate (EquipPosInfo _info) { return (_info.Pos == _goods.EquipPos&& _info.Index == _goods.Index); });
                                EquipPosInfo Posinfo = xc.Equip.EquipHelper.GetStrengthInfoByPosAndIndex(_goods.EquipPos, _goods.Index);
                                if (Posinfo != null)
                                {
                                    _goods.StrenghtLv = Posinfo.StrengthLv;
                                }

                                uint oldModelId = _goods.ModelId;
                                GoodsFactory.Update(dataGoods, _goods);
                                uint newModelId = _goods.ModelId;
                                if (oldModelId != newModelId)
                                {
                                    if (origin == GameConst.GOODS_OPERATE_WEAR)
                                    {
                                        foreach (var info in StrengthInfos)
                                        {
                                            if (_goods.EquipPos == info.Pos && _goods.Index == info.Index)
                                            {
                                                info.InstallPosEquip = _goods;
                                            }
                                        }
                                        EquipModelChange = Equip.EquipHelper.ChangeEquipPart(LocalPlayerManager.Instance.LocalActorAttribute.UnitId, newModelId, _goods.EquipPos);
                                        pos = _goods.EquipPos;
                                    }
                                }
                                if (_goods.EquipPos == GameConst.POS_ELFIN)
                                    has_elfin = true;
                            }
                            else
                            {
                                GoodsEquip newGoods = new GoodsEquip(dataGoods.gid, dataGoods);
                                newGoods.id = dataGoods.oid;
                                newGoods.num = dataGoods.num;
                                newGoods.bind = dataGoods.bind;
                                newGoods.expire_time = dataGoods.expire_time;
                                InstallEquip.Add(newGoods.id, newGoods);
                                //EquipPosInfo Posinfo = ItemManager.Instance.StrengthInfos.Find(delegate (EquipPosInfo _info) { return (_info.Pos == newGoods.EquipPos&& _info.Index == newGoods.Index); });
                                EquipPosInfo Posinfo = xc.Equip.EquipHelper.GetStrengthInfoByPosAndIndex(newGoods.EquipPos, newGoods.Index);
                                if (Posinfo != null)
                                {
                                    newGoods.StrenghtLv = Posinfo.StrengthLv;
                                }
                                if (origin == GameConst.GOODS_OPERATE_WEAR)
                                {
                                    foreach (var info in StrengthInfos)
                                    {
                                        if (newGoods.EquipPos == info.Pos && newGoods.Index == info.Index)
                                        {
                                            info.InstallPosEquip = newGoods;
                                        }
                                    }
                                    EquipModelChange = Equip.EquipHelper.ChangeEquipPart(LocalPlayerManager.Instance.LocalActorAttribute.UnitId, newGoods.ModelId, newGoods.EquipPos);
                                    pos = newGoods.EquipPos;
                                }
                                if (newGoods.EquipPos == GameConst.POS_ELFIN)
                                    has_elfin = true;
                            }
                        }


                        if (EquipModelChange != 0)
                            ClientEventMgr.Instance.FireEvent((int)ClientEvent.CE_INSTALLED_EQUIP_CHANGED, new CEventEventParamArgs(EquipModelChange, pos));
                        CheckBagCanQuickUse();

                        Equip.EquipHelper.CalculatorSuitNum(InstallEquip);
                        if (origin == GameConst.GOODS_OPERATE_LOGIN)
                        {
                            SortBagData();
                            SortWareData();
                        }
                        else
                            CheckBagForce();
                        ClientEventMgr.GetInstance().FireEvent((int)ClientEvent.CE_INSTALL_1_UPDATE, new CEventBaseArgs());
                        if (has_elfin)
                        {
                            ClientEventMgr.GetInstance().FireEvent((int)ClientEvent.CE_INSTALL_1_EFLIN_UPDATE, new CEventBaseArgs());
                        }

                        mInstall1GoodsListHaveInit = true;
                        break;
                    }

                case GameConst.BAG_TYPE_INSTALL_3:
                    {
                        for (int i = 0; i < goods.Count; i++)
                        {

                            var dataGoods = goods[i];
                            if (dataGoods.decorate != null)
                            {
                                GoodsDecorate _goods = null;
                                if (WearingDecorate.TryGetValue(dataGoods.decorate.pos_id, out _goods))
                                {
                                    GoodsFactory.Update(dataGoods, _goods);
                                }
                                else
                                {
                                    GoodsDecorate newGoods = new GoodsDecorate(dataGoods.gid, dataGoods);
                                    newGoods.id = dataGoods.oid;
                                    newGoods.num = dataGoods.num;
                                    newGoods.bind = dataGoods.bind;
                                    newGoods.expire_time = dataGoods.expire_time;

                                    WearingDecorate.Add(dataGoods.decorate.pos_id, newGoods); ;
                                }
                            }
                        }

                        CheckBagCanQuickUse();

                        ClientEventMgr.GetInstance().FireEvent((int)ClientEvent.CE_INSTALL_3_UPDATE, new CEventBaseArgs());
                        break;
                    }

                case GameConst.BAG_TYPE_MAGIC_EQUIP_1: // 法宝装备（穿戴中）
                    {
                        for (int i = 0; i < goods.Count; i++)
                        {
                            var dataGoods = goods[i];
                            var srvMagicEquip = dataGoods.magic_equip;
                            if (srvMagicEquip != null)
                            {
                                GoodsMagicEquip equip = null;
                                if (WearingMagicEquip.TryGetValue(dataGoods.oid, out equip))
                                {
                                    GoodsFactory.Update(dataGoods, equip);
                                }
                                else
                                {
                                    GoodsMagicEquip newEquip = new GoodsMagicEquip(dataGoods.gid, srvMagicEquip);
                                    newEquip.id = dataGoods.oid;
                                    newEquip.num = dataGoods.num;
                                    newEquip.bind = dataGoods.bind;
                                    newEquip.expire_time = dataGoods.expire_time;

                                    newEquip.MagicId = srvMagicEquip.id;
                                    newEquip.StrengthLv = srvMagicEquip.str_lv;
                                    newEquip.TotalExp = srvMagicEquip.total_exp;
                                    newEquip.CurExp = srvMagicEquip.exp;

                                    WearingMagicEquip.Add(newEquip.id, newEquip); ;
                                }
                            }
                        }

                        ClientEventMgr.GetInstance().FireEvent((int)ClientEvent.CE_WEARING_MAGIC_EQUIP_UPDATE, new CEventBaseArgs());
                        break;
                    }

                case GameConst.BAG_TYPE_GOD_EQUIP:  
                    {
                        mTmpGetGoodsList.Clear();

                        for (int i = 0; i < goods.Count; i++)
                        {

                            var dataGoods = goods[i];
                            if (dataGoods.god_equip != null)
                            {
                                GoodsGodEquip _goods = null;
                                if (GodEquipGoodsOids.TryGetValue(dataGoods.oid, out _goods))
                                {
                                    if (origin == GameConst.GOODS_OPERATE_NONE)
                                    {
                                        ulong add_num = dataGoods.num - _goods.num;
                                        if (mTmpGetGoodsList.ContainsKey(_goods.name) == false)
                                            mTmpGetGoodsList.Add(_goods.name, add_num);
                                        else
                                            mTmpGetGoodsList[_goods.name] += add_num;
                                    }
                                    GoodsFactory.Update(dataGoods, _goods);
                                }
                                else
                                {
                                    GoodsGodEquip newGoods = new GoodsGodEquip(dataGoods.gid, dataGoods);
                                    newGoods.id = dataGoods.oid;
                                    newGoods.num = dataGoods.num;
                                    newGoods.bind = dataGoods.bind;
                                    newGoods.expire_time = dataGoods.expire_time;
                                    GodEquipGoodsOids.Add(dataGoods.oid, newGoods);
                                    if (origin == GameConst.GOODS_OPERATE_NONE)
                                    {
                                        if (mTmpGetGoodsList.ContainsKey(newGoods.name))
                                        {
                                            mTmpGetGoodsList[newGoods.name] += newGoods.num;
                                        }
                                        else
                                        {
                                            mTmpGetGoodsList.Add(newGoods.name, newGoods.num);
                                        }
                                        CheckBagCanQuickUse_addGoods(newGoods);
                                    }
                                }
                            }
                        }

                        if (origin == GameConst.GOODS_OPERATE_LOGIN) //只有登录的时候需要检查一次整个背包
                            CheckBagCanQuickUse();

                        foreach (var item in mTmpGetGoodsList)
                        {
                            string blackBkg_name = GoodsHelper.ReplaceGoodsColor_blackBkg(item.Key);
                            UINotice.Instance.ShowMessage(string.Format(DBConstText.GetText("BAG_GET_GOODS"), blackBkg_name, item.Value));
                        }
                        ClientEventMgr.GetInstance().FireEvent((int)ClientEvent.CE_GOD_EQUIP_BAG_UPDATE, new CEventBaseArgs());

                        break;
                    }
                case GameConst.BAG_TYPE_GOD_EQUIP_1:
                    {
                        for (int i = 0; i < goods.Count; i++)
                        {

                            var dataGoods = goods[i];
                            if (dataGoods.god_equip != null)
                            {
                                GoodsGodEquip _goods = null;
                                if (InstallGodEquip.TryGetValue(dataGoods.oid, out _goods))
                                {
                                    GoodsFactory.Update(dataGoods, _goods);
                                }
                                else
                                {
                                    GoodsGodEquip newGoods = new GoodsGodEquip(dataGoods.gid, dataGoods);
                                    newGoods.id = dataGoods.oid;
                                    newGoods.num = dataGoods.num;
                                    newGoods.bind = dataGoods.bind;
                                    newGoods.expire_time = dataGoods.expire_time;
                                    InstallGodEquip.Add(dataGoods.oid, newGoods);
                                }
                            }
                        }
                        ClientEventMgr.GetInstance().FireEvent((int)ClientEvent.CE_GOD_EQUIP_UPDATE, new CEventBaseArgs());

                        break;
                    }
                //case GameConst.BAG_TYPE_ELEMENT_EP: //元素装备增加或更新
                //    {
                //        mTmpGetGoodsList.Clear();

                //        for (int i = 0; i < goods.Count; i++)
                //        {

                //            var dataGoods = goods[i];
                //            if (dataGoods.element_ep != null)
                //            {
                //                GoodsElementEquip _goods = null;
                //                if (ElementEquipGoodsOids.TryGetValue(dataGoods.oid, out _goods))   //更新
                //                {
                //                    if (origin == GameConst.GOODS_OPERATE_NONE)
                //                    {
                //                        ulong add_num = dataGoods.num - _goods.num;
                //                        if (mTmpGetGoodsList.ContainsKey(_goods.name) == false)
                //                            mTmpGetGoodsList.Add(_goods.name, add_num);
                //                        else
                //                            mTmpGetGoodsList[_goods.name] += add_num;
                //                    }

                //                    GoodsFactory.Update(dataGoods, _goods);
                //                }
                //                else    //新增
                //                {
                //                    GoodsElementEquip newGoods = new GoodsElementEquip(dataGoods.gid, dataGoods);
                //                    newGoods.bag_type = GameConst.BAG_TYPE_ELEMENT_EP;
                //                    newGoods.id = dataGoods.oid;
                //                    newGoods.num = dataGoods.num;
                //                    newGoods.bind = dataGoods.bind;
                //                    newGoods.expire_time = dataGoods.expire_time;
                //                    ElementEquipGoodsOids.Add(dataGoods.oid, newGoods);

                //                    List<ulong> oids = null;
                //                    if (ElementEquipTypeIdAndOids.TryGetValue(dataGoods.gid, out oids))
                //                    {
                //                        oids.Add(dataGoods.oid);
                //                    }
                //                    else
                //                    {
                //                        oids = new List<ulong>();
                //                        oids.Add(dataGoods.oid);
                //                        ElementEquipTypeIdAndOids.Add(dataGoods.gid, oids);
                //                    }

                //                    if (origin == GameConst.GOODS_OPERATE_NONE)
                //                    {
                //                        if (mTmpGetGoodsList.ContainsKey(newGoods.name))
                //                        {
                //                            mTmpGetGoodsList[newGoods.name]++;
                //                        }
                //                        else
                //                        {
                //                            mTmpGetGoodsList.Add(newGoods.name, 1);
                //                            CheckBagCanQuickUse_addGoods(newGoods);
                //                        }
                //                    }
                //                }
                //            }
                //        }

                //        foreach (var item in mTmpGetGoodsList)
                //        {
                //            string blackBkg_name = GoodsHelper.ReplaceGoodsColor_blackBkg(item.Key);
                //            UINotice.Instance.ShowMessage(string.Format(DBConstText.GetText("BAG_GET_GOODS"), blackBkg_name, item.Value));
                //        }

                //        ClientEventMgr.GetInstance().FireEvent((int)ClientEvent.CE_ELEMENT_EQUIP_BAG_UPDATE, new CEventBaseArgs());

                //        break;
                //    }
                //case GameConst.BAG_TYPE_INSTALL_5:
                //    {
                //        for (int i = 0; i < goods.Count; i++)
                //        {

                //            var dataGoods = goods[i];
                //            if (dataGoods.element_ep != null)
                //            {
                //                GoodsElementEquip _goods = null;
                //                if (InstallElementEquip.TryGetValue(dataGoods.oid, out _goods))
                //                {
                //                    GoodsFactory.Update(dataGoods, _goods);
                //                }
                //                else
                //                {
                //                    GoodsElementEquip newGoods = new GoodsElementEquip(dataGoods.gid, dataGoods);
                //                    newGoods.bag_type = GameConst.BAG_TYPE_INSTALL_5;
                //                    newGoods.id = dataGoods.oid;
                //                    newGoods.num = dataGoods.num;
                //                    newGoods.bind = dataGoods.bind;
                //                    newGoods.expire_time = dataGoods.expire_time;
                //                    InstallElementEquip.Add(dataGoods.oid, newGoods);
                //                }
                //            }
                //        }
                //        ClientEventMgr.GetInstance().FireEvent((int)ClientEvent.CE_ELEMENT_EQUIP_UPDATE, new CEventBaseArgs());

                //        break;
                //    }
                case GameConst.BAG_TYPE_RIDE_EQUIP:
                    {

                        mTmpGetGoodsList.Clear();
                        mTmpGetGoodsArray.Clear();

                        for (int i = 0; i < goods.Count; i++)
                        {
                            var dataGoods = goods[i];
                            GoodsMountEquip _goods = null;
                            if (MountEquipGoodsOid.TryGetValue(dataGoods.oid, out _goods))// 背包中已经有该物品，则进行更新
                            {
                                _goods.type_idx = dataGoods.gid;
                                if (dataGoods.num > _goods.num && origin == GameConst.GOODS_OPERATE_NONE)
                                {
                                    ulong add_num = dataGoods.num - _goods.num;
                                    if (mTmpGetGoodsList.ContainsKey(_goods.name) == false)
                                        mTmpGetGoodsList.Add(_goods.name, add_num);
                                    else
                                        mTmpGetGoodsList[_goods.name] += add_num;
                                    if (mTmpGetGoodsArray.ContainsKey(_goods.type_idx) == false)
                                    {
                                        TmpGetGoods tmp_add = new TmpGetGoods();
                                        tmp_add.goods_id = _goods.type_idx;
                                        tmp_add.num = _goods.num;
                                        tmp_add.name = _goods.name;
                                        mTmpGetGoodsArray.Add(_goods.type_idx, tmp_add);
                                    }
                                    else
                                        mTmpGetGoodsArray[_goods.type_idx].num += add_num;
                                }

                                GoodsFactory.Update(dataGoods, _goods);
                            }
                            else// 背包中没有该物品
                            {
                                GoodsMountEquip newGoods = new GoodsMountEquip(dataGoods.gid, dataGoods);
                                newGoods.bag_type = GameConst.BAG_TYPE_RIDE_EQUIP;
                                newGoods.id = dataGoods.oid;
                                newGoods.num = dataGoods.num;
                                newGoods.bind = dataGoods.bind;
                                newGoods.expire_time = dataGoods.expire_time;
                                MountEquipGoodsOid.Add(dataGoods.oid, newGoods);

                                List<ulong> oids = null;

                                if (MountEquipTypeIdAndOids.TryGetValue(dataGoods.gid, out oids))
                                {
                                    oids.Add(dataGoods.oid);
                                }
                                else
                                {
                                    oids = new List<ulong>();
                                    oids.Add(dataGoods.oid);
                                    MountEquipTypeIdAndOids.Add(dataGoods.gid, oids);
                                }

                                if (origin == GameConst.GOODS_OPERATE_NONE)
                                {
                                    if (mTmpGetGoodsList.ContainsKey(newGoods.name) == false)
                                        mTmpGetGoodsList.Add(newGoods.name, newGoods.num);
                                    else
                                        mTmpGetGoodsList[newGoods.name] += newGoods.num;
                                    if (mTmpGetGoodsArray.ContainsKey(newGoods.type_idx) == false)
                                    {
                                        TmpGetGoods tmp_add = new TmpGetGoods();
                                        tmp_add.goods_id = newGoods.type_idx;
                                        tmp_add.num = newGoods.num;
                                        tmp_add.name = newGoods.name;
                                        mTmpGetGoodsArray.Add(newGoods.type_idx, tmp_add);
                                    }
                                    else
                                        mTmpGetGoodsArray[newGoods.type_idx].num += newGoods.num;

                                    CheckBagCanQuickUse_addGoods(newGoods);
                                }
                            }
                        }

                        foreach (var item in mTmpGetGoodsList)
                        {
                            string blackBkg_name = GoodsHelper.ReplaceGoodsColor_blackBkg(item.Key);
                            UINotice.Instance.ShowMessage(string.Format(DBConstText.GetText("BAG_GET_GOODS"), blackBkg_name, item.Value));
                        }

                        if (origin == GameConst.GOODS_OPERATE_LOGIN) //只有登录的时候需要检查一次整个背包
                            CheckBagCanQuickUse();

                        ClientEventMgr.GetInstance().FireEvent((int)ClientEvent.CE_MOUNT_EQUIP_BAG_UPDATE, new CEventBaseArgs()); ;
                        break;
                    }
                case GameConst.BAG_TYPE_INSTALL_4:
                    {
                        for (int i = 0; i < goods.Count; i++)
                        {

                            var dataGoods = goods[i];
                            if (dataGoods.ride_equip != null)
                            {
                                GoodsMountEquip _goods = null;
                                if (InstallMountEquip.TryGetValue(dataGoods.oid, out _goods))
                                {
                                    GoodsFactory.Update(dataGoods, _goods);
                                }
                                else
                                {
                                    GoodsMountEquip newGoods = new GoodsMountEquip(dataGoods.gid, dataGoods);
                                    newGoods.bag_type = GameConst.BAG_TYPE_INSTALL_4;
                                    newGoods.id = dataGoods.oid;
                                    newGoods.num = dataGoods.num;
                                    newGoods.bind = dataGoods.bind;
                                    newGoods.expire_time = dataGoods.expire_time;
                                    InstallMountEquip.Add(dataGoods.oid, newGoods);
                                }
                            }
                        }
                        ClientEventMgr.GetInstance().FireEvent((int)ClientEvent.CE_MOUNT_EQUIP_UPDATE, new CEventBaseArgs());

                        break;
                    }
                case GameConst.BAG_TYPE_LIGHT_SOUL:
                    {
                        Dictionary<uint, uint> tmpGoodsList = new Dictionary<uint, uint>();
                        foreach (var dataGoods in goods)
                        {
                            // 注意 光武兵魂的数量不能叠加 每次获得的都是不同oid的
                            LightWeaponGoodsOids[dataGoods.oid] = new GoodsLightWeaponSoul(dataGoods);
                            if (origin == GameConst.GOODS_OPERATE_NONE)
                            {
                                if (tmpGoodsList.ContainsKey(dataGoods.gid))
                                    tmpGoodsList[dataGoods.gid] += 1;
                                else
                                    tmpGoodsList[dataGoods.gid] = 1;
                            }
                        }

                        foreach (var soul in tmpGoodsList)
                        {
                            string blackBkg_name = GoodsHelper.GetGoodsNameByTypeId_blackBkg(soul.Key);
                            UINotice.Instance.ShowMessage(string.Format(DBConstText.GetText("BAG_GET_GOODS"), blackBkg_name, soul.Value));
                        }

                        ClientEventMgr.GetInstance().FireEvent((int)ClientEvent.CE_LIGHT_WEAPON_SOUL_BAG_UPDATE, new CEventBaseArgs());
                        break;
                    }
                default:
                    {
                        object[] param = { data };
                        LuaScriptMgr.Instance.CallLuaFunction(LuaScriptMgr.Instance.Lua.Global, "GoodsLuaHelper_ProcessS2CGoodsList", param);
                        break;
                    }
            }
        }

        //删除物品容器(背包、仓库等)
        private void DelItemByyContainer(uint bagType, List<ulong> oids, uint origin, byte[] data)
        {
            switch (bagType)
            {
                case GameConst.BAG_TYPE_NORMAL:
                    {
                        NeedUpdateBagIndexArray.Clear();
                        bool should_close_shortCutWin = false;
                        List<uint> need_update_bag_index_array = new List<uint>();
                        for (int i = 0; i < oids.Count; i++)
                        {
                            ulong oid = oids[i];
                            Goods goods = null;
                            if (BagGoodsOids.TryGetValue(oid, out goods))
                            {
                                goods.is_deleted = true;
                                List<ulong> _oids = new List<ulong>();
                                if (BagTypeIdAndOids.TryGetValue(goods.type_idx, out _oids))
                                {
                                    BagTypeIdAndOids[goods.type_idx].Remove(oid);
                                }
                            }
                            BagGoodsOids.Remove(oid);
                            if (should_close_shortCutWin == false && mIdInCurShortCutWin != 0 && mIdInCurShortCutWin == oid)
                            {
                                //should_close_shortCutWin = true;
                                //ui.ugui.UIManager.Instance.CloseWindow("UIShortcutUseWindow");
                                ClientEventMgr.GetInstance().FireEvent((int)ClientEvent.CE_SHORT_CUT_TIPS_NO_GOODS, null);
                            }
                        }
                        //if (should_close_shortCutWin)
                        //    CheckBagCanQuickUse();
                        DelGoods();
                        ClientEventMgr.GetInstance().FireEvent((int)ClientEvent.CE_BAG_UPDATE_SLOT_DEL, null);
                        NeedUpdateBagIndexArray.Clear();
                        ClientEventMgr.GetInstance().FireEvent((int)ClientEvent.CE_BAG_UPDATE, new CEventBaseArgs());
                        ClientEventMgr.GetInstance().FireEvent((int)ClientEvent.CE_BAG_DEL, new CEventBaseArgs(oids));
                        CheckBagFullRedPoint();
                        break;
                    }
                case GameConst.BAG_TYPE_WARE:
                    {
                        NeedUpdateWareIndexArray.Clear();
                        for (int i = 0; i < oids.Count; i++)
                        {
                            ulong oid = oids[i];
                            Goods goods = null;
                            if (WareHouseGoodsOids.TryGetValue(oid, out goods))
                            {
                                List<ulong> _oids = new List<ulong>();
                                if (WareHouseTypeIdAndOids.TryGetValue(goods.type_idx, out _oids))
                                {
                                    _oids.Remove(oid);
                                }
                                goods.is_deleted = true;
                            }
                            WareHouseGoodsOids.Remove(oid);
                        }
                        DelWareGoods();
                        ClientEventMgr.GetInstance().FireEvent((int)ClientEvent.CE_WARE_UPDATE_SLOT, null);
                        NeedUpdateWareIndexArray.Clear();
                        ClientEventMgr.GetInstance().FireEvent((int)ClientEvent.CE_WAREHOUSE_UPDATE, new CEventBaseArgs());
                        break;
                    }
                case GameConst.BAG_TYPE_TREASURE_HUNT:
                    {
                        for (int i = 0; i < oids.Count; i++)
                        {
                            ulong oid = oids[i];
                            TreasureHuntGoodsOids.Remove(oid);
                        }
                        ClientEventMgr.GetInstance().FireEvent((int)ClientEvent.CE_TREASURE_HUNT_UPDATE, new CEventBaseArgs());
                        break;
                    }
                case GameConst.BAG_TYPE_ID_TREASURE:
                    {
                        for (int i = 0; i < oids.Count; i++)
                        {
                            ulong oid = oids[i];
                            IDTreasureGoodsOids.Remove(oid);
                        }
                        ClientEventMgr.GetInstance().FireEvent((int)ClientEvent.CE_ID_TREASURE_BAG_UPDATE, new CEventBaseArgs());
                        break;
                    }
                case GameConst.BAG_TYPE_ARCHIVE:
                    {
                        for (int i = 0; i < oids.Count; i++)
                        {
                            ulong oid = oids[i];
                            HandbookGoodsOids.Remove(oid);
                        }
                        ClientEventMgr.GetInstance().FireEvent((int)ClientEvent.CE_HANDBOOK_UPDATE, new CEventBaseArgs());
                        break;
                    }
                case GameConst.BAG_TYPE_SOUL:
                    {
                        for (int i = 0; i < oids.Count; i++)
                        {
                            ulong oid = oids[i];
                            Goods goods = null;
                            if (SoulGoodsOids.TryGetValue(oid, out goods))
                            {
                                List<ulong> _oids = new List<ulong>();
                                if (SoulTypeIdAndOids.TryGetValue(goods.type_idx, out _oids))
                                {
                                    _oids.Remove(oid);
                                }
                            }
                            SoulGoodsOids.Remove(oid);
                        }
                        ClientEventMgr.GetInstance().FireEvent((int)ClientEvent.CE_SOUL_UPDATE, new CEventBaseArgs());
                        break;
                    }
                case GameConst.BAG_TYPE_DECORATE:
                    {
                        bool should_close_shortCutWin = false;

                        for (int i = 0; i < oids.Count; i++)
                        {
                            ulong oid = oids[i];
                            Goods decorate;
                            if (DecorateGoodsOids.TryGetValue(oid, out decorate))
                            {
                                if (DecorateTypeIdAndOids.ContainsKey(decorate.type_idx))
                                    DecorateTypeIdAndOids[decorate.type_idx].Remove(oid);

                            }
                            DecorateGoodsOids.Remove(oid);
                            if (should_close_shortCutWin == false && mIdInCurShortCutWin != 0 && mIdInCurShortCutWin == oid)
                            {
                                ClientEventMgr.GetInstance().FireEvent((int)ClientEvent.CE_SHORT_CUT_TIPS_NO_GOODS, null);
                            }
                        }

                        ClientEventMgr.GetInstance().FireEvent((int)ClientEvent.CE_DECORATE_BAG_UPDATE, new CEventBaseArgs());
                        break;
                    }

                case GameConst.BAG_TYPE_MAGIC_EQUIP: // 法宝装备（删除）
                    {
                        for (int i = 0; i < oids.Count; i++)
                        {
                            ulong oid = oids[i];
                            GoodsMagicEquip equip = null;
                            if (MagicEquipGoodsOids.TryGetValue(oid, out equip))
                            {
                                List<ulong> _oids = new List<ulong>();
                                if (MagicEquipTypeIdAndOids.TryGetValue(equip.type_idx, out _oids))
                                {
                                    _oids.Remove(oid);
                                }

                                MagicEquipGoodsOids.Remove(oid);
                            }
                        }

                        ClientEventMgr.GetInstance().FireEvent((int)ClientEvent.CE_MAGIC_EQUIP_BAG_UPDATE, new CEventBaseArgs());
                        break;
                    }

                case GameConst.BAG_TYPE_MAGIC_EQUIP_1: // 穿戴中的法宝装备（删除）
                    {
                        for (int i = 0; i < oids.Count; i++)
                        {
                            ulong oid = oids[i];

                            if (WearingMagicEquip.ContainsKey(oid))
                                WearingMagicEquip.Remove(oid);
                        }

                        ClientEventMgr.GetInstance().FireEvent((int)ClientEvent.CE_WEARING_MAGIC_EQUIP_UPDATE, new CEventBaseArgs());

                        break;
                    }

                case GameConst.BAG_TYPE_INSTALL_2:
                    {
                        List<uint> delHoleids = new List<uint>();
                        for (int i = 0; i < oids.Count; i++)
                        {
                            foreach (var item in InstallGoodsSouls)
                            {
                                if (item.Value.id == oids[i])
                                {
                                    delHoleids.Add(item.Value.HoleId);
                                }
                            }
                        }
                        for (int i = 0; i < delHoleids.Count; i++)
                        {
                            if (InstallGoodsSouls.ContainsKey(delHoleids[i]))
                            {
                                InstallGoodsSouls.Remove(delHoleids[i]);
                            }
                        }
                        ClientEventMgr.GetInstance().FireEvent((int)ClientEvent.CE_INSTALL_2_UPDATE, new CEventBaseArgs());
                        break;
                    }
                case GameConst.BAG_TYPE_INSTALL_1:
                    {
                        uint EquipModelChange = 0;
                        uint pos = GameConst.POS_WEAPON;
                        bool has_elfin = false;
                        for (int i = 0; i < oids.Count; i++)
                        {
                            GoodsEquip _goods = null;
                            if (InstallEquip.TryGetValue(oids[i], out _goods))
                            {
                                _goods.StrenghtLv = 0;
                                InstallEquip.Remove(oids[i]);
                                if (origin == GameConst.GOODS_OPERATE_WEAR)
                                {
                                    EquipModelChange = Equip.EquipHelper.ChangeEquipPart(LocalPlayerManager.Instance.LocalActorAttribute.UnitId, 0, _goods.EquipPos);
                                    foreach (var info in StrengthInfos)
                                    {
                                        if (_goods.EquipPos == info.Pos && _goods.Index == info.Index)
                                        {
                                            info.InstallPosEquip = null;
                                        }
                                    }
                                    pos = _goods.EquipPos;
                                }
                                if (_goods.EquipPos == GameConst.POS_ELFIN)
                                    has_elfin = true;
                            }

                        }
                        //if (EquipModelChange != 0)
                        ClientEventMgr.Instance.FireEvent((int)ClientEvent.CE_INSTALLED_EQUIP_CHANGED, new CEventEventParamArgs(EquipModelChange, pos));
                        //CheckBagCanQuickUse();
                        Equip.EquipHelper.CalculatorSuitNum(InstallEquip);
                        CheckBagForce();
                        ClientEventMgr.GetInstance().FireEvent((int)ClientEvent.CE_INSTALL_1_UPDATE, new CEventBaseArgs());
                        if (has_elfin)
                        {
                            ClientEventMgr.GetInstance().FireEvent((int)ClientEvent.CE_INSTALL_1_EFLIN_UPDATE, new CEventBaseArgs());
                        }
                        break;
                    }
                case GameConst.BAG_TYPE_INSTALL_3:
                    {
                        List<uint> delDecorateIds = new List<uint>();

                        for (int i = 0; i < oids.Count; i++)
                        {
                            foreach (var item in WearingDecorate)
                            {
                                if (item.Value.id == oids[i])
                                {
                                    delDecorateIds.Add(item.Value.Pos);
                                }
                            }
                        }

                        for (int i = 0; i < delDecorateIds.Count; i++)
                        {
                            if (WearingDecorate.ContainsKey(delDecorateIds[i]))
                            {
                                WearingDecorate.Remove(delDecorateIds[i]);
                            }
                        }

                        ClientEventMgr.GetInstance().FireEvent((int)ClientEvent.CE_INSTALL_3_UPDATE, new CEventBaseArgs());
                        break;
                    }
                case GameConst.BAG_TYPE_GOD_EQUIP:
                    {
                        bool should_close_shortCutWin = false;

                        for (int i = 0; i < oids.Count; i++)
                        {
                            if (GodEquipGoodsOids.ContainsKey(oids[i]))
                            {
                                GodEquipGoodsOids.Remove(oids[i]);
                            }

                            if (should_close_shortCutWin == false && mIdInCurShortCutWin != 0 && mIdInCurShortCutWin == oids[i])
                            {
                                //should_close_shortCutWin = true;
                                //ui.ugui.UIManager.Instance.CloseWindow("UIShortcutUseWindow");
                                ClientEventMgr.GetInstance().FireEvent((int)ClientEvent.CE_SHORT_CUT_TIPS_NO_GOODS, null);
                            }
                        }

                        //if (should_close_shortCutWin)
                        //    CheckBagCanQuickUse();

                        ClientEventMgr.GetInstance().FireEvent((int)ClientEvent.CE_GOD_EQUIP_BAG_UPDATE, new CEventBaseArgs());
                        break;
                    }
                case GameConst.BAG_TYPE_GOD_EQUIP_1:
                    {
                        for (int i = 0; i < oids.Count; i++)
                        {
                            if (InstallGodEquip.ContainsKey(oids[i]))
                            {
                                InstallGodEquip.Remove(oids[i]);
                            }
                        }

                        ClientEventMgr.GetInstance().FireEvent((int)ClientEvent.CE_GOD_EQUIP_UPDATE, new CEventBaseArgs());
                        break;
                    }

                case GameConst.BAG_TYPE_LIGHT_SOUL:
                    {
                        for (int i = 0; i < oids.Count; i++)
                            LightWeaponGoodsOids.Remove(oids[i]);
                        ClientEventMgr.GetInstance().FireEvent((int)ClientEvent.CE_LIGHT_WEAPON_SOUL_BAG_UPDATE, null);
                        break;
                    }
                //case GameConst.BAG_TYPE_ELEMENT_EP:
                //    {
                //        bool should_close_shortCutWin = false;

                //        for (int i = 0; i < oids.Count; i++)
                //        {
                //            ulong oid = oids[i];
                //            GoodsElementEquip equip = null;
                //            if (ElementEquipGoodsOids.TryGetValue(oid, out equip))
                //            {
                //                List<ulong> _oids = new List<ulong>();
                //                if (ElementEquipTypeIdAndOids.TryGetValue(equip.type_idx, out _oids))
                //                {
                //                    _oids.Remove(oid);
                //                }

                //                ElementEquipGoodsOids.Remove(oids[i]);
                //            }

                //            if (should_close_shortCutWin == false && mIdInCurShortCutWin != 0 && mIdInCurShortCutWin == oids[i])
                //            {
                //                //should_close_shortCutWin = true;
                //                //ui.ugui.UIManager.Instance.CloseWindow("UIShortcutUseWindow");
                //                ClientEventMgr.GetInstance().FireEvent((int)ClientEvent.CE_SHORT_CUT_TIPS_NO_GOODS, null);
                //            }
                //        }

                //        //if (should_close_shortCutWin)
                //        //    CheckBagCanQuickUse();

                //        ClientEventMgr.GetInstance().FireEvent((int)ClientEvent.CE_ELEMENT_EQUIP_BAG_UPDATE, new CEventBaseArgs());
                //        break;
                //    }
                //case GameConst.BAG_TYPE_INSTALL_5:
                //    {
                //        for (int i = 0; i < oids.Count; i++)
                //        {
                //            if (InstallElementEquip.ContainsKey(oids[i]))
                //            {
                //                InstallElementEquip.Remove(oids[i]);
                //            }
                //        }

                //        ClientEventMgr.GetInstance().FireEvent((int)ClientEvent.CE_ELEMENT_EQUIP_UPDATE, new CEventBaseArgs());
                //        break;
                //    }

                case GameConst.BAG_TYPE_RIDE_EQUIP:
                    {

                        bool should_close_shortCutWin = false;

                        for (int i = 0; i < oids.Count; i++)
                        {

                            GoodsMountEquip goods = null;
                            if (MountEquipGoodsOid.TryGetValue(oids[i], out goods))
                            {
                                List<ulong> _oids = new List<ulong>();
                                if (MountEquipTypeIdAndOids.TryGetValue(goods.type_idx, out _oids))
                                {
                                    MountEquipTypeIdAndOids[goods.type_idx].Remove(oids[i]);
                                }
                                MountEquipGoodsOid.Remove(oids[i]);
                            }

                            if (should_close_shortCutWin == false && mIdInCurShortCutWin != 0 && mIdInCurShortCutWin == oids[i])
                            {
                                //should_close_shortCutWin = true;
                                //ui.ugui.UIManager.Instance.CloseWindow("UIShortcutUseWindow");
                                ClientEventMgr.GetInstance().FireEvent((int)ClientEvent.CE_SHORT_CUT_TIPS_NO_GOODS, null);
                            }
                        }
                        
                        //if (should_close_shortCutWin)
                        //    CheckBagCanQuickUse();




                        ClientEventMgr.GetInstance().FireEvent((int)ClientEvent.CE_MOUNT_EQUIP_BAG_UPDATE, new CEventBaseArgs());
                        break;
                    }
                case GameConst.BAG_TYPE_INSTALL_4:
                    {
                        for (int i = 0; i < oids.Count; i++)
                        {
                            if (InstallMountEquip.ContainsKey(oids[i]))
                            {
                                InstallMountEquip.Remove(oids[i]);
                            }
                        }

                        ClientEventMgr.GetInstance().FireEvent((int)ClientEvent.CE_MOUNT_EQUIP_UPDATE, new CEventBaseArgs());
                        break;
                    }
                default:
                    {
                        object[] param = { data };
                        LuaScriptMgr.Instance.CallLuaFunction(LuaScriptMgr.Instance.Lua.Global, "GoodsLuaHelper_ProcessS2CGoodsDel", param);
                        break;
                    }
            }
        }

        public Goods GetPkgGoods(ushort protocol, byte[] data)
        {
            switch (protocol)
            {
                case NetMsg.MSG_MARKET_DETAIL:
                    {
                        S2CMarketDetail package = S2CPackBase.DeserializePack<S2CMarketDetail>(data);
                        Goods goods = xc.GoodsFactory.Create(package.goods.type, package.goods.gid, package.goods);
                        if (goods != null)
                        {
                            goods.id = package.goods.oid;
                            goods.num = package.goods.num;
                            goods.bind = package.goods.bind;
                            goods.expire_time = package.goods.expire_time;
                        }
                        return goods;
                    }
                case NetMsg.MSG_MARKET_DETAIL_IN_RECORD:
                    {
                        S2CMarketDetailInRecord package = S2CPackBase.DeserializePack<S2CMarketDetailInRecord>(data);
                        Goods goods = xc.GoodsFactory.Create(package.goods.type, package.goods.gid, package.goods);
                        if (goods != null)
                        {
                            goods.id = package.goods.oid;
                            goods.num = package.goods.num;
                            goods.bind = package.goods.bind;
                            goods.expire_time = package.goods.expire_time;
                        }
                        return goods;
                    }
                case NetMsg.MSG_GUILD_WARE_ADD_GOODS:
                    {
                        S2CGuildWareAddGoods package = S2CPackBase.DeserializePack<S2CGuildWareAddGoods>(data);
                        Goods goods = GetGoodsByProtocolPkg(package.goods);
                        return goods;
                    }
                case NetMsg.MSG_TREASURE_GOODS_INFO:
                    {
                        S2CTreasureGoodsInfo package = S2CPackBase.DeserializePack<S2CTreasureGoodsInfo>(data);
                        Goods goods = GetGoodsByProtocolPkg(package.info);
                        return goods;
                    }
                case NetMsg.MSG_PEAK_GOODS_INFO:
                    {
                        S2CPeakGoodsInfo package = S2CPackBase.DeserializePack<S2CPeakGoodsInfo>(data);
                        Goods goods = GetGoodsByProtocolPkg(package.info);
                        return goods;
                    }
                default:
                    break;
            }
            return null;
        }

        public Goods GetGoodsByProtocolPkg(Net.PkgGoodsInfo info)
        {
            Goods goods = xc.GoodsFactory.Create(info.type, info.gid, info);
            if (goods != null)
            {
                goods.id = info.oid;
                goods.num = info.num;
                goods.bind = info.bind;
                goods.expire_time = info.expire_time;
                goods.create_time = info.create_time;
            }
            return goods;
        }

        public Goods GetGoodsByProtocolPkgLua(LuaTable info)
        {
            uint gid = info.Get<uint>("gid");
            uint type = info.Get<uint>("type");
            ulong oid = info.Get<ulong>("oid");
            ulong num = info.Get<ulong>("num");
            uint bind = info.Get<uint>("bind");
            uint expire_time = info.Get<uint>("expire_time");
            string luaScript = GoodsHelper.GetGoodsLuaScriptByGoodsId(gid);
            GoodsLuaEx newGoods = new GoodsLuaEx(gid, luaScript);
            newGoods.UpdateByPkgGoodsInfo(info);
            newGoods.id = oid;
            newGoods.num = num;
            newGoods.bind = bind;
            newGoods.expire_time = expire_time;

            return newGoods;
        }

        public Dictionary<string, List<Goods>> GetPkgGoodsList(ushort protocol, byte[] data)
        {
            Dictionary<string, List<Goods>> re_data = new Dictionary<string, List<Goods>>();
            switch (protocol)
            {
                case NetMsg.MSG_GUILD_WARE_INFO:
                    {
                        S2CGuildWareInfo package = S2CPackBase.DeserializePack<S2CGuildWareInfo>(data);
                        List<Goods> goods_array = new List<Goods>();
                        for (int index = 0; index < package.goods.Count; ++index)
                        {
                            goods_array.Add(GetGoodsByProtocolPkg(package.goods[index]));
                        }
                        re_data["wareGoodsList"] = goods_array;

                        for (int index = 0; index < package.logs.Count; ++index)
                        {
                            if (package.logs[index].log_goods != null)
                            {
                                List<Goods> one_log_goods_array = new List<Goods>();
                                for (int goods_index = 0; goods_index < package.logs[index].log_goods.Count; goods_index++)
                                {
                                    Net.PkgGoodsInfo info = package.logs[index].log_goods[goods_index].goods;
                                    if (info != null)
                                        one_log_goods_array.Add(GetGoodsByProtocolPkg(info));
                                }
                                re_data[index.ToString()] = one_log_goods_array;
                            }

                        }
                        break;
                    }
                case NetMsg.MSG_GUILD_WARE_ADD_LOG:
                    {
                        S2CGuildWareAddLog package = S2CPackBase.DeserializePack<S2CGuildWareAddLog>(data);
                        List<Goods> goods_array = new List<Goods>();
                        for (int index = 0; index < package.log.log_goods.Count; ++index)
                        {
                            Net.PkgGoodsInfo info = package.log.log_goods[index].goods;
                            if (info != null)
                                goods_array.Add(GetGoodsByProtocolPkg(info));
                        }
                        re_data["1"] = goods_array;
                        break;
                    }
                default:
                    break;
            }
            return re_data;
        }

        public void HandleServerData(ushort protocol, byte[] data)
        {
            switch (protocol)
            {
                case NetMsg.MSG_GOODS_DEL:
                    {
                        var msg = S2CPackBase.DeserializePack<S2CGoodsDel>(data);
                        DelItemByyContainer(msg.type, msg.oids, msg.origin, data);
                        break;
                    }

                case NetMsg.MSG_GOODS_LIST:
                    {
                        var msg = S2CPackBase.DeserializePack<S2CGoodsList>(data);
                        RefreshItemByContainer(msg.type, msg.goods, msg.origin, data);
                        break;
                    }
                case NetMsg.MSG_BAG_SIZE:
                    {
                        S2CBagSize pageCount = S2CPackBase.DeserializePack<S2CBagSize>(data);
                        switch (pageCount.bag_type)
                        {
                            case GameConst.BAG_TYPE_NORMAL:
                                {
                                    uint num = 0;
                                    uint size_before_extend = mBagTotalCount; //开格子前，拥有的格子总数
                                    uint extend_size = 0; //本次实际开放的格子数
                                    if (BagExSize.TryGetValue(GameConst.BAG_TYPE_NORMAL, out num))
                                    {
                                        if (num < pageCount.extra_size)
                                        {
                                            //UINotice.GetInstance().ShowMessage("背包扩充成功！");
                                        }
                                        BagExSize[GameConst.BAG_TYPE_NORMAL] = pageCount.extra_size;
                                        ItemManager.GetInstance().mBagTotalCount = pageCount.extra_size + mBagInitCount;
                                        BagItemInfo info = null;
                                        if (CurrentLockBagItem.TryGetValue(GameConst.BAG_TYPE_NORMAL, out info))
                                        {
                                            info.Idx = pageCount.ticker_cell;
                                            info.StartTime = pageCount.start_time;
                                            info.EndTime = pageCount.stop_time;
                                        }
                                    }
                                    else
                                    {
                                        ItemManager.GetInstance().mBagTotalCount = mBagInitCount + pageCount.extra_size;
                                        BagExSize.Add(GameConst.BAG_TYPE_NORMAL, pageCount.extra_size);
                                        BagItemInfo info = new BagItemInfo();
                                        uint maxExCount = mBagMaxCount - mBagInitCount;
                                        info.Idx = pageCount.ticker_cell;
                                        info.StartTime = pageCount.start_time;
                                        info.EndTime = pageCount.stop_time;
                                        CurrentLockBagItem.Add(GameConst.BAG_TYPE_NORMAL, info);

                                    }
                                    CheckQuickUnLock(GameConst.BAG_TYPE_NORMAL);
                                    if (mBagTotalCount > size_before_extend)
                                    {
                                        extend_size = mBagTotalCount - size_before_extend;
                                        CheckBagPageUpdate(size_before_extend, extend_size);
                                    }
                                    ClientEventMgr.GetInstance().FireEvent((int)ClientEvent.CE_BAG_PAGE_UPDATE, new CEventBaseArgs());
                                    CheckBagFullRedPoint();
                                    break;
                                }
                            case GameConst.BAG_TYPE_SOUL:
                                {
                                    mSoulBagTotalCount = mSoulBagInitCount + pageCount.extra_size;
                                    ClientEventMgr.GetInstance().FireEvent((int)ClientEvent.CE_SOUL_PAGE_UPDATE, new CEventBaseArgs());
                                    break;
                                }

                            case GameConst.BAG_TYPE_DECORATE:
                                {
                                    mDecorateBagTotalCount = mDecorateBagInitCount + pageCount.extra_size;
                                    ClientEventMgr.GetInstance().FireEvent((int)ClientEvent.CE_DECORATE_BAG_SIZE_UPDATE, new CEventBaseArgs());
                                    break;
                                }

                            case GameConst.BAG_TYPE_MAGIC_EQUIP:
                                {
                                    mMagicEquipBagTotalCount = mMagicEquipBagInitCount + pageCount.extra_size;
                                    ClientEventMgr.GetInstance().FireEvent((int)ClientEvent.CE_MAGIC_EQUIP_BAG_SIZE_UPDATE, new CEventBaseArgs());
                                    break;
                                }

                            case GameConst.BAG_TYPE_ARCHIVE:
                                {
                                    mHandbookBagTotalCount = mHandbookBagInitCount + pageCount.extra_size;
                                    ClientEventMgr.GetInstance().FireEvent((int)ClientEvent.CE_HANDBOOK_BAG_SIZE_UPDATE, new CEventBaseArgs());
                                    break;
                                }

                            case GameConst.BAG_TYPE_GOD_EQUIP:
                                {
                                    mGodEquipBagTotalCount = mGodEquipBagInitCount + pageCount.extra_size;
                                    ClientEventMgr.GetInstance().FireEvent((int)ClientEvent.CE_GOD_EQUIP_BAG_SIZE_UPDATE, new CEventBaseArgs());
                                    break;
                                }
                            case GameConst.BAG_TYPE_RIDE_EQUIP:
                                {
                                    mMountEquipBagTotalCount = mMountEquipBagInitCount + pageCount.extra_size;
                                    ClientEventMgr.GetInstance().FireEvent((int)ClientEvent.CE_MOUNT_EQUIP_BAG_SIZE_UPDATE, new CEventBaseArgs());
                                    break;
                                }

                            case GameConst.BAG_TYPE_LIGHT_SOUL:
                                {
                                    mLightWeaponSoulBagTotalCount = mLightWeaponSoulBagInitCount + pageCount.extra_size;
                                    ClientEventMgr.GetInstance().FireEvent((int)ClientEvent.CE_LIGHT_WEAPON_SOUL_BAG_SIZE_UPDATE, new CEventBaseArgs());
                                    break;
                                }
                                
                            case GameConst.BAG_TYPE_INSTALL_2:
                                {
                                    mSoulInstallTotalCount = mSoulInstallInitCount + pageCount.extra_size;
                                    ClientEventMgr.GetInstance().FireEvent((int)ClientEvent.CE_INSTALL_2_PAGE_UPDATE, new CEventBaseArgs());
                                    break;
                                }

                            case GameConst.BAG_TYPE_WARE:
                                {
                                    uint num = 0;

                                    uint size_before_extend = mWareTotalCount; //开格子前，拥有的格子总数
                                    uint extend_size = 0; //本次实际开放的格子数

                                    if (BagExSize.TryGetValue(GameConst.BAG_TYPE_WARE, out num))
                                    {
                                        if (num < pageCount.extra_size)
                                        {
                                            //UINotice.GetInstance().ShowMessage("仓库扩充成功！");
                                        }

                                        BagExSize[GameConst.BAG_TYPE_WARE] = pageCount.extra_size;
                                        ItemManager.GetInstance().mWareTotalCount = pageCount.extra_size + mWareInitCount; ;
                                        BagItemInfo info = null;
                                        if (CurrentLockBagItem.TryGetValue(GameConst.BAG_TYPE_WARE, out info))
                                        {
                                            info.Idx = pageCount.ticker_cell;
                                            info.StartTime = pageCount.start_time;
                                            info.EndTime = pageCount.stop_time;
                                        }
                                    }
                                    else
                                    {
                                        ItemManager.GetInstance().mWareTotalCount = mWareInitCount + pageCount.extra_size;
                                        BagExSize.Add(GameConst.BAG_TYPE_WARE, pageCount.extra_size);
                                        BagItemInfo info = new BagItemInfo();
                                        uint maxExCount = mWareMaxCount - mWareInitCount;
                                        info.Idx = pageCount.ticker_cell;
                                        info.StartTime = pageCount.start_time;
                                        info.EndTime = pageCount.stop_time;
                                        CurrentLockBagItem.Add(GameConst.BAG_TYPE_WARE, info);

                                    }
                                    CheckQuickUnLock(GameConst.BAG_TYPE_WARE);

                                    if (mWareTotalCount > size_before_extend)
                                    {
                                        extend_size = mWareTotalCount - size_before_extend;
                                        CheckWarePageUpdate(size_before_extend, extend_size);
                                    }

                                    ClientEventMgr.GetInstance().FireEvent((int)ClientEvent.CE_WAREHOUSE_PAGE_UPDATE, new CEventBaseArgs());
                                    break;
                                }
                            case GameConst.BAG_TYPE_INSTALL_1:
                                {
                                    break;
                                }
                            default:
                                {
                                    object[] param = { data };
                                    LuaScriptMgr.Instance.CallLuaFunction(LuaScriptMgr.Instance.Lua.Global, "GoodsLuaHelper_ProcessS2CBagSize", param);
                                    break;
                                }
                        }
                        ClientEventMgr.GetInstance().FireEvent((int)ClientEvent.CE_ONE_BAGTYPE_SIZE_UPDATE, new CEventBaseArgs(pageCount.bag_type));
                        break;
                    }

                case NetMsg.MSG_EP_STRENGTH_INFO:
                    {
                        var msg = S2CPackBase.DeserializePack<S2CEpStrengthInfo>(data);
                        RereshStrengthInfo(msg);
                        break;
                    }
                case NetMsg.MSG_EP_STRENGTH:
                    {
                        var msg = S2CPackBase.DeserializePack<S2CEpStrength>(data);
                        StrengthResult(msg);
                        break;
                    }
                case NetMsg.MSG_EP_BAPTIZE_INFO:
                    {
                        var msg = S2CPackBase.DeserializePack<S2CEpBaptizeInfo>(data);
                        RereshBaptizeInfo(msg);
                        break;
                    }
                case NetMsg.MSG_EP_BAPTIZE:
                    {
                        var msg = S2CPackBase.DeserializePack<S2CEpBaptize>(data);
                        BaptizeCount = msg.num;

                        List<uint> openGrooveIds = new List<uint>();
                        openGrooveIds.Clear();
                        foreach (var info in msg.info.infos)
                        {
                            if (info.state == 1 || info.state == 2)
                            {
                                openGrooveIds.Add(info.id);
                            }
                        }

                        RereshOneBaptizeInfo(msg.info, true, openGrooveIds);

                        break;
                    }

                case NetMsg.MSG_EP_BAPTIZE_LOCK:
                    {
                        var msg = S2CPackBase.DeserializePack<S2CEpBaptizeLock>(data);
                        RereshOneBaptizeInfo(msg.info, false, null);
                        break;
                    }
                case NetMsg.MSG_EP_BAPTIZE_OPEN:
                    {
                        var msg = S2CPackBase.DeserializePack<S2CEpBaptizeOpen>(data);

                        uint openGrooveId = 0;
                        foreach (var info in msg.info.infos)
                        {
                            if (info.state == 1 || info.state == 2)
                            {
                                openGrooveId = info.id;
                            }
                        }
                        RereshOneBaptizeInfo(msg.info, false, new List<uint>{openGrooveId});
                        break;
                    }
                case NetMsg.MSG_EP_SUIT_FORGE:
                    {
                        var msg = S2CPackBase.DeserializePack<S2CEpSuitForge>(data);
                        GoodsEquip equip = null;
                        if (InstallEquip.TryGetValue(msg.oid, out equip) == true)
                        {
                            equip.SuitLv = msg.suit_lv;
                            Equip.EquipHelper.CalculatorSuitNum(InstallEquip);
                            ClientEventMgr.GetInstance().FireEvent((int)ClientEvent.CE_SUIT_EQUIP_CHANGED, new CEventBaseArgs(equip));
                        }
                        break;
                    }

                case NetMsg.MSG_EP_SUIT_REFINE:
                    {
                        var msg = S2CPackBase.DeserializePack<S2CEpSuitRefine>(data);
                        GoodsEquip equip = null;
                        if (InstallEquip.TryGetValue(msg.oid, out equip))
                        {
                            equip.RefineLv = msg.refine_lv;
                            ClientEventMgr.GetInstance().FireEvent((int)ClientEvent.CE_SUIT_REFINE_CHANGED, new CEventBaseArgs());
                        }

                        // 背包（卸载装备）
                        GoodsEquip equip1 = null;
                        if (BagGoodsOids.ContainsKey(msg.oid))
                        {
                            equip1 = (GoodsEquip)BagGoodsOids[msg.oid];
                            equip1.RefineLv = msg.refine_lv;
                        }

                        break;
                    }

                case NetMsg.MSG_EP_GEM_INFO:
                    {
                        var msg = S2CPackBase.DeserializePack<S2CEpGemInfo>(data);
                        GoodsEquip equip = null;
                        if (BagGoodsOids.ContainsKey(msg.oid))
                        {
                            equip = (GoodsEquip)BagGoodsOids[msg.oid];
                        }
                        else if (InstallEquip.ContainsKey(msg.oid))
                        {
                            equip = (GoodsEquip)InstallEquip[msg.oid];
                        }

                        if (equip != null)
                        {
                            // 保存变化了的宝石孔，有变化为1，没变化为0
                            Dictionary<uint, uint> changedGems = new Dictionary<uint, uint>();
                            changedGems.Clear();
                            uint gemHoleNum = DBManager.Instance.GetDB<DBGemHole>().GetGemHoleNum();
                            for (uint i = 1; i <= gemHoleNum; i++)
                            {
                                if (equip.Gems.ContainsKey(i))
                                {
                                    changedGems.Add(i, equip.Gems[i]);
                                }
                                else
                                {
                                    changedGems.Add(i, 0);
                                }
                            }

                            equip.Gems.Clear();
                            foreach (var item in msg.gems)
                            {
                                equip.Gems.Add(item.id, item.gem_id);
                                if (changedGems.ContainsKey(item.id) == true)
                                {
                                    if (changedGems[item.id] != item.gem_id)
                                    {
                                        changedGems[item.id] = 1;
                                    }
                                    else
                                    {
                                        changedGems[item.id] = 0;
                                    }
                                }
                                else
                                {
                                    changedGems.Add(item.id, 1);
                                }
                            }
                            ClientEventMgr.GetInstance().FireEvent((int)ClientEvent.CE_EQUIP_GEM_CHANGED, new CEventEventParamArgs(equip, changedGems));
                            ClientEventMgr.GetInstance().FireEvent((int)ClientEvent.CE_INSTALL_1_UPDATE, new CEventBaseArgs());
                        }
                        break;
                    }
                case NetMsg.MSG_GOODS_CD:
                    {
                        var msg = S2CPackBase.DeserializePack<S2CGoodsCd>(data);
                        uint gameTime = Game.Instance.ServerTime;
                        foreach (var kv in msg.cds)
                        {
                            if (GoodsCd.ContainsKey(kv.cd_id))
                            {
                                if (gameTime > kv.time)
                                {
                                    GoodsCd[kv.cd_id] = gameTime;
                                }
                                else
                                    GoodsCd[kv.cd_id] = kv.time;
                            }
                            else
                            {
                                if (gameTime > kv.time)
                                {
                                    GoodsCd.Add(kv.cd_id, gameTime);
                                }
                                else
                                    GoodsCd.Add(kv.cd_id, kv.time);
                            }

                            ClientEventMgr.GetInstance().FireEvent((int)ClientEvent.CE_GOODS_CD_UPDATE, new CEventBaseArgs(kv.cd_id));
                        }
                        break;
                    }
                case NetMsg.MSG_SOUL_BOOK:
                    {
                        var msg = S2CPackBase.DeserializePack<S2CSoulBook>(data);
                        for (int i = 0; i < msg.soul_list.Count; i++)
                        {
                            uint findId = 0;
                            findId = GetSoulList.Find(delegate (uint _id) { return msg.soul_list[i] == _id; });
                            if (findId == 0)
                            {
                                GetSoulList.Add(msg.soul_list[i]);
                            }
                        }

                        for (int i = 0; i < msg.book_list.Count; i++)
                        {
                            uint findId = 0;
                            findId = OpenSoulList.Find(delegate (uint _id) { return msg.book_list[i] == _id; });
                            if (findId == 0)
                            {
                                OpenSoulList.Add(msg.book_list[i]);
                            }
                        }
                        ClientEventMgr.GetInstance().FireEvent((int)ClientEvent.CE_SOUL_OPEN_UPDATE, new CEventBaseArgs());

                        break;
                    }
                case NetMsg.MSG_GOODS_DAILY_LIMIT:
                    {
                        var msg = S2CPackBase.DeserializePack<S2CGoodsDailyLimit>(data);
                        mNoUseTimesGids[msg.goods_info.gid] = msg.goods_info.num;

                        ClientEventMgr.GetInstance().FireEvent((int)ClientEvent.CE_GOODS_USE_TIMES_UPDATE, new CEventBaseArgs(msg.goods_info.gid));
                        break;
                    }
                case NetMsg.MSG_GOODS_ALL_DAILY_LIMIT:
                    {
                        var msg = S2CPackBase.DeserializePack<S2CGoodsAllDailyLimit>(data);
                        mNoUseTimesGids.Clear();
                        for (int index = 0; index < msg.goods_info_list.Count; ++index)
                        {
                            mNoUseTimesGids[msg.goods_info_list[index].gid] = msg.goods_info_list[index].num;

                            ClientEventMgr.GetInstance().FireEvent((int)ClientEvent.CE_GOODS_USE_TIMES_UPDATE, new CEventBaseArgs(msg.goods_info_list[index].gid));
                        }
                        break;
                    }
                case NetMsg.MSG_DECORATE_POS_INFO: // 饰品部位信息列表
                    {
                        var msg = S2CPackBase.DeserializePack<S2CDecoratePosInfo>(data);
                        RereshDecoratePosInfos(msg);
                        break;
                    }
                case NetMsg.MSG_DECORATE_POS_STRENGTH: // 饰品强化响应
                    {
                        var msg = S2CPackBase.DeserializePack<S2CDecoratePosStrength>(data);
                        DecorateStrengthResult(msg);
                        break;
                    }
                case NetMsg.MSG_DECORATE_BREAK: // 饰品突破响应
                    {
                        var msg = S2CPackBase.DeserializePack<S2CDecorateBreak>(data);
                        DecorateBreakResult(msg);
                        break;
                    }
                case NetMsg.MSG_TITLE_INFO: // 称号信息
                    {
                        GetTitleList.Clear();

                        var msg = S2CPackBase.DeserializePack<S2CTitleInfo>(data);

                        for (int idx = 0; idx < msg.titles.Count; ++idx)
                        {
                            GetTitleList.Add(msg.titles[idx].id);
                        }

                        break;
                    }
                case NetMsg.MSG_ADD_TITLE: // 添加称号
                    {
                        var msg = S2CPackBase.DeserializePack<S2CAddTitle>(data);
                        uint id = msg.title.id;

                        if (!GetTitleList.Contains(id))
                            GetTitleList.Add(id);

                        break;
                    }
                case NetMsg.MSG_DEL_TITLE: // 删除称号
                    {
                        var msg = S2CPackBase.DeserializePack<S2CDelTitle>(data);

                        if (GetTitleList.Contains(msg.id))
                            GetTitleList.Remove(msg.id);

                        break;
                    }
                case NetMsg.MSG_CONSUME_BOX:    // 消费礼包消费情况
                    {
                        var msg = S2CPackBase.DeserializePack<S2CConsumeBox>(data);

                        mConsumeValues[msg.oid] = msg.value;

                        if (BagGoodsOids.ContainsKey(msg.oid))
                        {
                            if (CheckBagCanQuickUse_ConsumeBox(BagGoodsOids[msg.oid]) == true)
                            {
                                ui.ugui.UIManager.Instance.ShowWindow("UIShortcutUseWindow", BagGoodsOids[msg.oid], GameConst.BAG_TYPE_NORMAL);
                            }
                        }

                        break;
                    }
                case NetMsg.MSG_EP_FAIRY_RENEW:
                    {
                        var msg = S2CPackBase.DeserializePack<S2CEpFairyRenew>(data);
                        RefreshExpireTime(msg.bag_type, msg.oid, msg.expire_time, msg.operation);
                        break;
                    }
                case NetMsg.MSG_BOSS_DROP_GOODS_INFO:
                    {
                        var msg = Net.S2CPackBase.DeserializePack<Net.S2CBossDropGoodsInfo>(data);
                        var goods = GoodsFactory.Create(msg.info.gid, msg.info);
                        if (goods != null)
                        {
                            goods.id = msg.info.oid;
                            goods.num = msg.info.num;
                            goods.bind = msg.info.bind;
                            goods.expire_time = msg.info.expire_time;

                            GoodsHelper.ShowGoodsTips(goods);
                        }
                        break;
                    }

                case NetMsg.MSG_LIGHT_EQUIP_INFO:
                    {
                        var msg = Net.S2CPackBase.DeserializePack<Net.S2CLightEquipInfo>(data);
                        var lightWeapons = msg.opens;
                        foreach (var lightWeapon in lightWeapons)
                        {
                            var soulPkgs = lightWeapon.souls;
                            foreach (var soulPkg in soulPkgs)
                            {
                                var soul = new GoodsLightWeaponSoul(soulPkg.put_on);
                                var Pos_Type = soul.Pos_Type;
                                var Pos_Index = soul.Pos_Index;
                                soul.bind = soulPkg.is_bind;
                                GoodsLightWeaponHelper.AddInstalledSoul(soul);
                                ClientEventMgr.GetInstance().FireEvent((int)ClientEvent.CE_LIGHT_WEAPON_SOUL_UPDATE_INSTALLED, new CEventEventParamArgs(Pos_Type, Pos_Index));
                            }
                        }

                        break;
                    }

                case NetMsg.MSG_LIGHT_SOUL_PUT_ON:
                    {
                        var msg = Net.S2CPackBase.DeserializePack<Net.S2CLightSoulPutOn>(data);
                        var soul = new GoodsLightWeaponSoul(msg.put_on);
                        soul.bind = msg.is_bind;
                        var Pos_Type = soul.Pos_Type;
                        var Pos_Index = soul.Pos_Index;

                        GoodsLightWeaponHelper.AddInstalledSoul(soul);
                        ClientEventMgr.GetInstance().FireEvent((int)ClientEvent.CE_LIGHT_WEAPON_SOUL_UPDATE_INSTALLED, new CEventEventParamArgs(Pos_Type, Pos_Index));
                        break;
                    }
                    

            }
        }

        public void AddCloseGoodsId(uint type_idx)
        {
            mCloseQuickUseGoodsIdArray[type_idx] = true;
        }

        public bool IsCloseGoodsId(uint type_idx)
        {
            if (mCloseQuickUseGoodsIdArray.ContainsKey(type_idx))
                return true;
            return false;
        }

        public void RemoveCloseGoodsId(uint type_idx)
        {
            mCloseQuickUseGoodsIdArray.Remove(type_idx);
        }
        private uint mLastCheckEmptyItemCount = 1000;
        public void CheckBagFullRedPoint()
        {
            uint cur_empty_item_count = GetEmptyItemCount();
            uint last_count = mLastCheckEmptyItemCount;
            mLastCheckEmptyItemCount = cur_empty_item_count;
            if (cur_empty_item_count < 5)//当背包剩下的空格子＜5时，背包入口图标显示特殊的红点
            {
                RedPointDataMgr.Instance.EnableRedPoint(GameConst.SYS_OPEN_BAG, true);

                //若已经显示了背包已经满，且格子数不再减少，不再主动弹出“背包已满”提示
                if (cur_empty_item_count >= last_count)
                {
                    return;
                }
                xc.ui.ugui.UIManager.Instance.ShowWindow("UIBagFullTipsWindow");
            }
            else
            {
                //之前小红点是亮的，要关闭背包已满界面
                if (RedPointDataMgr.Instance.GetRedPointVisible(GameConst.SYS_OPEN_BAG))
                {
                    xc.ui.ugui.UIManager.Instance.CloseWindow("UIBagFullTipsWindow");
                }

                RedPointDataMgr.Instance.EnableRedPoint(GameConst.SYS_OPEN_BAG, false);
            }
        }

        #region 饰品 

        /// <summary>
        /// 更新饰品部位
        /// </summary>
        private void UpdateDecoratePosInfo(PkgDecoratePosInfo pos_info)
        {
            var info = DecoratePosInfos.Find(delegate (DecoratePosInfo _info) { return (_info.Pos == pos_info.pos_id); });
            if (info != null)
            {
                info.IsUnlock = true;
                info.StrengthMaxLv = pos_info.max_lv;
                info.StrengthLv = pos_info.lv;
                info.StrengthValue = pos_info.value;
                info.BreakLv = pos_info.break_lv;
                info.IsNeedBreak = false;

                string key = string.Format("{0}_{1}", pos_info.pos_id, pos_info.lv);
                var costValue = DBManager.Instance.QuerySqliteField<string>(GlobalConfig.DBFile, "data_decorate_str", "csv_id", key, "cost_value");
                info.StrengthMaxValue = DBTextResource.ParseUI(costValue[0]);

                // 附魔属性

                foreach (var localAttr in info.AppendAttrs)
                {
                    localAttr.IsOpen = false;

                    foreach (var srvAttr in pos_info.attrs)
                    {
                        if (srvAttr.attr_id == localAttr.AttrId
                       && srvAttr.value == localAttr.Value
                       && srvAttr.lv == localAttr.OpenLv
                       && srvAttr.break_lv == localAttr.BreakLv)
                        {
                            localAttr.IsOpen = true;
                            break;
                        }
                    }

                    if (!localAttr.IsOpen 
                        && info.StrengthLv == localAttr.OpenLv
                        && info.BreakLv < localAttr.BreakLv)
                        info.IsNeedBreak = true;
                }
            }
        }

        /// <summary>
        /// 饰品部位信息列表 
        /// </summary>
        /// <param name="msg"></param>
        private void RereshDecoratePosInfos(S2CDecoratePosInfo msg)
        {
            foreach (var item in msg.pos_list)
            {
                UpdateDecoratePosInfo(item);
            }

            ClientEventMgr.Instance.FireEvent((int)ClientEvent.CE_DECORATE_POS_INFO_UPDATE, new CEventBaseArgs());
        }

        /// <summary>
        /// 饰品强化响应 
        /// </summary>
        /// <param name="msg"></param>
        private void DecorateStrengthResult(S2CDecoratePosStrength msg)
        {
            UpdateDecoratePosInfo(msg.pos);

            ClientEventMgr.Instance.FireEvent((int)ClientEvent.CE_DECORATE_STRENGTH_RESULT, new CEventBaseArgs());
        }
        
        /// <summary>
        /// 饰品突破响应
        /// </summary>
        /// <param name="msg"></param>

        private void DecorateBreakResult(S2CDecorateBreak msg)
        {
            UpdateDecoratePosInfo(msg.pos);

            ClientEventMgr.Instance.FireEvent((int)ClientEvent.CE_DECORATE_BREAK_RESULT, new CEventBaseArgs());
        }

        public void DecorateInstall(uint fromBag, uint toBag, ulong oid)
        {
            var data = new C2SDecorateMove();
            data.origin = fromBag;
            data.target = toBag;
            data.oid = oid;

            NetClient.GetBaseClient().SendData<C2SDecorateMove>(NetMsg.MSG_DECORATE_MOVE, data);
        }

        public void TakeOnDecorate(GoodsDecorate decorate)
        {
            if (null == decorate)
            {
                GameDebug.LogError("TakeOnDecorate: decorate is null!!!");
                return;
            }

            // 系统未开启
            if (!SysConfigManager.Instance.CheckSysHasOpened(GameConst.SYS_OPEN_DECORATE, true))
            {
                return;
            }

            ulong oid = decorate.id;

            // 背包不存在该物品
            if (!DecorateGoodsOids.ContainsKey(oid))
                return;

            var wearingDecorate = DecorateHelper.GetWearingDecorateByPos(decorate.Pos);
            if (wearingDecorate != null)
            {
                if (wearingDecorate.LvStep > decorate.LvStep)
                {
                    // 当前身上饰品品质更高是否替换？
                    string tips = DBConstText.GetText("DECORATE_WEAR_TIPS");
                    UIWidgetHelp.GetInstance().ShowNoticeDlg(xc.ui.ugui.UINoticeWindow.EWindowType.WT_OK_Cancel, tips,
                        (dt) =>
                        {
                            DecorateInstall(GameConst.BAG_TYPE_DECORATE, GameConst.BAG_TYPE_INSTALL_3, oid);
                        }
                        , null);

                    return;
                }
            }

            DecorateInstall(GameConst.BAG_TYPE_DECORATE, GameConst.BAG_TYPE_INSTALL_3, oid);
        }

        public void TakeOffDecorate(GoodsDecorate decorate)
        {
            if (null == decorate)
            {
                GameDebug.LogError("TakeOffDecorate: decorate is null!!!");
                return;
            }

            if (DecorateGoodsOids.Count >= mDecorateBagTotalCount)
            {
                // 饰品背包空间不足，请先清理饰品背包!
                string tips = DBConstText.GetText("DECORATE_PACK_SPACE_NOT_ENOUGH");
                UINotice.Instance.ShowMessage(tips);
                return;
            }

            DecorateInstall(GameConst.BAG_TYPE_INSTALL_3, GameConst.BAG_TYPE_DECORATE, decorate.id);
        }

        #endregion

        /// <summary>
        /// 获取某个物品的消费数额
        /// </summary>
        /// <param name="oid"></param>
        /// <returns></returns>
        public uint GetConsumeValue(ulong oid)
        {
            if (mConsumeValues.ContainsKey(oid) == true)
            {
                return mConsumeValues[oid];
            }

            return 0;
        }

        public GoodsGodEquip GetWearingGodEquipGoods(uint id,uint pos)
        {
            foreach (var item in InstallGodEquip)
            {
                //if (item.Value.GodEquipId == id && item.Value.PosId == pos)
                if (item.Value.PosId == pos)
                {
                    return item.Value;
                }
            }
            return null;
        }

        public GoodsMountEquip GetWearingMountEquipGoods(uint pos)
        {
            foreach (var item in InstallMountEquip)
            {
                if (item.Value.pos_id == pos)
                {
                    return item.Value;
                }
            }
            return null;
        }

        public object GetBagDataByBagType(ushort typeId)
        {
            switch (typeId)
            {
                case GameConst.BAG_TYPE_NORMAL: return BagGoodsOids;
                case GameConst.BAG_TYPE_RIDE_EQUIP: return MountEquipGoodsOid;
                case GameConst.BAG_TYPE_MAGIC_EQUIP: return MagicEquipGoodsOids;
                //case GameConst.BAG_TYPE_ELEMENT_EP: return ElementEquipGoodsOids;
                case GameConst.BAG_TYPE_DECORATE: return DecorateGoodsOids;
            }
            return BagGoodsOids;
        }
        
        //判断该部位 是否寻找过  
        public bool CheckHavePos(int main_type, uint pos)
        {
            string key = string.Format("{0}_{1}", main_type, pos);
            bool isHaveCheck = false;
            isHaveCheck = ItemManager.Instance.mHaveCheckPos.ContainsKey(key);
            if (isHaveCheck == false)
                ItemManager.Instance.mHaveCheckPos[key] = true;
            return isHaveCheck;
        }
 
        private List<GoodsItem> mTempGoodsList = new List<GoodsItem>();


        //有新增装备且窗口没打开则重置，重新遍历
        public void FreshPosState()
        {
            ItemManager.Instance.mHaveCheckPos.Clear();
        }

        /// <summary>
        /// 获取排序过的鉴宝背包列表
        /// </summary>
        /// <returns></returns>
        public List<Goods> GetSortedLuckyTreasureGoodsList()
        {
            List<Goods> result = new List<Goods>();
            foreach (var goods in IDTreasureGoodsOids)
            {
                result.Add(goods.Value);
            }
            result.Sort((a, b) =>
            {
                if (a.is_equipUp && b.is_equipUp == false)
                    return -1;
                else if (a.is_equipUp == false && b.is_equipUp)
                    return 1;
                if (a.sort_id < b.sort_id)
                    return -1;
                else if (a.sort_id > b.sort_id)
                    return 1;
                if (a.id < b.id)
                    return -1;
                else if (a.id > b.id)
                    return 1;
                return 0;
            });
            return result;
        }

        /// <summary>
        /// 鉴宝背包是否满了
        /// </summary>
        public bool LuckyTreasureBagIsFull
        {
            get
            {
                return IDTreasureGoodsOids.Count >= mLuckyTreasureBagMaxCount;
            }
        }

        public void ProcessAddGoodsListByLua(LuaTable goodsListToAdd)
        {
            List<GoodsLuaEx> goodsList = new List<GoodsLuaEx>();
            goodsList.Clear();
            goodsListToAdd.ForEach<uint, LuaTable>((k, v) =>
            {
                uint bagType = v.Get<uint>("bagType");
                LuaTable pkgGoodsInfo = v.Get<LuaTable>("pkgGoodsInfo");

                uint gid = pkgGoodsInfo.Get<uint>("gid");
                uint type = pkgGoodsInfo.Get<uint>("type");
                ulong oid = pkgGoodsInfo.Get<ulong>("oid");
                ulong num = pkgGoodsInfo.Get<ulong>("num");
                uint bind = pkgGoodsInfo.Get<uint>("bind");
                uint expire_time = pkgGoodsInfo.Get<uint>("expire_time");
                string luaScript = GoodsHelper.GetGoodsLuaScriptByGoodsId(gid);
                GoodsLuaEx newGoods = new GoodsLuaEx(gid, luaScript);
                newGoods.UpdateByPkgGoodsInfo(pkgGoodsInfo);
                newGoods.bag_type = (ushort)bagType;
                newGoods.id = oid;
                newGoods.num = num;
                newGoods.bind = bind;
                newGoods.expire_time = expire_time;

                goodsList.Add(newGoods);
            });

            object[] param = { goodsList };
            LuaScriptMgr.Instance.CallLuaFunction(LuaScriptMgr.Instance.Lua.Global, "GoodsLuaHelper_AddGoodsListToManager", param);
        }
    }
}
