using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using System.IO;
using System.Text.RegularExpressions;
using xc.ui.ugui;
using xc.protocol;
using Net;

namespace xc
{
    public class GoodsDropFrom
    {
        public enum DropType : sbyte
        {
            None = -1,
            GENE = 0,
            DUNGEON = 1,
            TRADE = 2,
        }
        public List<DropType> types = new List<DropType>();
        public List<uint> dungeonId_list = new List<uint>();
    }

    public enum EGoodsQuality : byte
    {
        White = 0,
        Green,
        Blue,
        Purple,
        Yellow,
        Gold,
        Premium,
    }

    public class GoodsCompositeData
    {
        public uint CompositeLvId = 0;
        public uint TopLv = 0;
        public string TypeName = string.Empty;
    }

    /// <summary>
    /// 表格中的物品数据
    /// </summary>
    public class GoodsInfo
    {
        public string name; // 物品名字
        public uint sort_id; // 背包排序
        public uint sort_top; // 置顶排序
        public byte type; // 主类型
        public ushort sub_type;// 子类型
        public byte color_type;// 品质
        public ushort max_stack; // 最大堆叠数
        public string effect; // 使用效果
        public string arg; // 效果参数
        public byte client_use; // 客户端效果
        public uint cd_id; // 共用cd的id
        public ushort use_cd; // 使用cd: 单位秒
        public uint use_lv; // 使用条件_等级
        public byte use_job; // 使用条件_职业
        public byte use_transfer;   //使用条件_转职次数
        public byte need_count; // 使用所需格子数
        public uint guild_wpoint;// 帮派仓库捐献、兑换价格
        public uint sell_price; // 出售价格
        public uint expire_time; // 有效期
        public byte mktype_1; // 市场一级类型
        public byte mktype_2; // 市场二级类型
        public byte bind; // 初始绑定状态
        public uint price_recommend; // 市场单价推荐值
        public float price_lower_limit; // 市场单价下限
        public float price_upper_limit; // 市场单价上限
        public string desc; // 物品描述
        public string gain_text; // 获取途径文本
        public string gain_from; // 获得途径导航
        public uint icon_id; // 物品图片id
        public byte is_show; // 是否显示tips
        public byte is_quick; // 是否支持快捷使用
        public byte is_confirmation; // 出售是否需要二次确认
        public uint sys_id; // 使用对应的系统id
        public byte is_mutil_use; // 是否可以批量使用
        public ushort daily_use_limit; // 道具每日使用次数上限
        public byte is_display_goods; // 是否是展示类物品
        public uint wing_exp; // 翅膀精炼增加的经验
        public uint show_step; //icon右上角显示的阶数，0和不填不显示，填3显示3
        public uint is_precious; // 是否珍贵物品
        public uint discount; // 折扣显示
        public uint overdue_notice_time; // 即将过期提示时间
    }

    public class GoodsCompositeStuffData
    {
        public uint CompositeMaxUnBindNum = 0;//根据材料数量返回最大可合成非绑定的数量
        public uint CompositeMaxTotalNum = 0;
        public uint CompositeId = 0;
        public List<GoodsItem> Stuffs = new List<GoodsItem>();
        public List<Dictionary<ushort , uint>> Moneys = new List<Dictionary<ushort , uint>>();//要消耗的货币列表（类型 ， 值）
    }

    [wxb.Hotfix]
    public class GoodsHelper
    {
        public static GameObject GoodsPrefab = SGameEngine.ResourceLoader.Instance.try_load_cached_asset("Assets/Res/UI/Widget/Dynamic/UINewGoodsItem.prefab") as GameObject;

        public delegate void CommonClickFunc(Goods goods);
        public enum ItemMainType : byte
        {
            NULLTYPE = 0,
            ITEM = 1,   
            EQUIP = 2,  
            COIN = 10,
        }

        public static ItemMainType StringToItemSubType(string raw)
        {
            if(raw.Equals("GIVE_TYPE_GOODS"))
            {
                return ItemMainType.ITEM;
            }
            else if(raw.Equals("GIVE_TYPE_EQUIP"))
            {
                return ItemMainType.EQUIP;
            }

            return ItemMainType.NULLTYPE;
        }

        /// <summary>
        /// 获取物品表中的信息
        /// </summary>
        /// <param name="gid"></param>
        /// <returns></returns>
        public static GoodsInfo GetGoodsInfo(uint gid)
        {
            return DBGoods.Instance.GetGoodsInfo(gid);
        }

        //使用物品所需物品格子数
        public static uint GetUseGoodsNeedCount(uint typeId)
        {
            var goods_info = GoodsHelper.GetGoodsInfo(typeId);
            if (goods_info != null)
                return goods_info.need_count;
            else
                return 1;
        }

        //获得使用id（针对使用跳转用）
        public static uint GetGoodsUseid(uint typeId)
        {
            uint id = 0;
            return id;
        }

        //根据反射读表穿goods
        public static void GotoClientFuncByGoodsUseType(Goods goods)
        {
            if(goods == null&& goods.client_use == 0)
            {
                UINotice.Instance.ShowMessage(xc.TextHelper.GetConstText("CODE_TEXT_LOCALIZATION_60"));
                return;
            }

        }

        //获取物品子类型仅限物品表中的
        public static uint GetGoodsSubType(uint typeId)
        {
            var goods_info = GoodsHelper.GetGoodsInfo(typeId);
            if (goods_info != null)
                return goods_info.sub_type;
            else
                return 0;
        }

        public static uint GetGoodsType(uint typeId)
        {
            var goods_info = GoodsHelper.GetGoodsInfo(typeId);
            if (goods_info != null)
                return goods_info.type;
            else
                return 0;
        }

        public static string GetGoodsNameByTypeId(uint typeId)
        {
            var goods_info = GoodsHelper.GetGoodsInfo(typeId);
            if (goods_info != null)
            {
                var color_type = goods_info.color_type;
                var goods_name = string.Format("{0}{1}</color>", GoodsHelper.GetGoodsColor_whiteBkg(color_type) , goods_info.name);
                return goods_name;
            }
            else
                return "";
        }

        public static bool IsGoodsPrecious(uint typeId)
        {
            var goods_info = GoodsHelper.GetGoodsInfo(typeId);
            if (goods_info != null && goods_info.is_precious == 1)
                return true;
            return false;
        }

        public static string GetGoodsNameByTypeId_blackBkg(uint typeId)
        {
            var goods_info = GoodsHelper.GetGoodsInfo(typeId);
            if (goods_info != null)
            {
                var color_type = goods_info.color_type;
                var goods_name = string.Format("{0}{1}</color>", GoodsHelper.GetGoodsColor_blackBkg(color_type), goods_info.name);
                return goods_name;
            }
            else
                return "";
        }

        public static string GetGoodsOriginalNameByTypeId(uint typeId)
        {
            var goods_info = GoodsHelper.GetGoodsInfo(typeId);
            if (goods_info != null)
            {
                var goods_name = goods_info.name;
                return goods_name;
            }
            else
                return "";
        }

        public static string GetGoodsEffectByTypeId(uint typeId)
        {
            var goods_info = GoodsHelper.GetGoodsInfo(typeId);
            if (goods_info != null)
            {
                return goods_info.effect;
            }
            else
                return "0";
        }

        public static uint GetGoodsMarketType1ByTypeId(uint typeId)
        {
            var goods_info = GoodsHelper.GetGoodsInfo(typeId);
            if (goods_info != null)
            {
                return goods_info.mktype_1;
            }
            else
                return 0;
        }

        public static uint GetGoodsMarketType2ByTypeId(uint typeId)
        {
            var goods_info = GoodsHelper.GetGoodsInfo(typeId);
            if (goods_info != null)
            {
                return goods_info.mktype_2;
            }
            else
                return 0;
        }

        public static string GetGoodsArgByTypeId(uint typeId)
        {
            var goods_info = GoodsHelper.GetGoodsInfo(typeId);
            if (goods_info != null)
            {
                return goods_info.arg;
            }
            else
                return "0";
        }

        public static string GetGoodsDescriptionByTypeId(uint typeId)
        {
            var goods_info = GoodsHelper.GetGoodsInfo(typeId);
            if (goods_info != null)
            {
                return goods_info.desc;
            }
            else
                return "";
        }

        /// <summary>
        /// 封装一个list返回用于自定义处理
        /// </summary>
        /// <param name="attr"></param>
        /// <returns></returns>
        public static List<string> GetGoodsCustomBaseDes(ActorAttribute attr)
        {
            List<string> strs = new List<string>();
            if (attr.ContainsKey(GameConst.AR_MIN_ATTACK_BASE) && attr.ContainsKey(GameConst.AR_MAX_ATTACK_BASE))
            {
                var str = string.Format("攻击 {0}-{1}", attr.GetAttr(GameConst.AR_MIN_ATTACK_BASE).Value, attr.GetAttr(GameConst.AR_MAX_ATTACK_BASE).Value);
                strs.Add(str);
            }
            foreach (var item in attr)
            {
                if (item.Key != GameConst.AR_MIN_ATTACK_BASE && item.Key != GameConst.AR_MAX_ATTACK_BASE)
                {
                    if (item.Value is DefaultActorAttribute)
                    {
                        var DefaulAttr = item.Value as DefaultActorAttribute;
                        strs.Add(DefaulAttr.Name);
                    }
                }
            }
            return strs;
        }

        /// <summary>
        /// 从DB中得到物品的绑定数据
        /// </summary>
        /// <param name="typeId"></param>
        /// <returns></returns>
        public static uint GetGoodsBindDBByTypeId(uint typeId)
        {
            var goods_info = GoodsHelper.GetGoodsInfo(typeId);
            if (goods_info != null)
            {
                return goods_info.bind;
            }
            else
                return 0;
        }

        public static uint GetGoodsColorTypeByTypeId(uint typeId)
        {
            var goods_info = GoodsHelper.GetGoodsInfo(typeId);
            if (goods_info != null)
            {
                return goods_info.color_type;
            }
            else
                return 0;
        }

        public static Color GetGoodsColorByTypeId(uint typeId)
        {
            byte color_type = 0;
            var goods_info = GoodsHelper.GetGoodsInfo(typeId);
            if (goods_info != null)
            {
                color_type = goods_info.color_type;
            }

            return GetGoodsColorByQua(color_type);
        }


        public static Color GetGoodsQualityColor(EGoodsQuality quality)
        {
            return GetGoodsColorByQua((uint)quality);
        }

        public static GoodsCompositeStuffData GetCompositeStuffData(uint com_id)
        {
            GoodsCompositeStuffData data = new GoodsCompositeStuffData();
            data.CompositeId = com_id;
            List<Dictionary<string, string>> data_goods_ep_compose = DBManager.Instance.QuerySqliteRow<string>(GlobalConfig.DBFile, "data_goods_ep_compose", "gid", com_id.ToString());
            if (data_goods_ep_compose.Count > 0)
            {
                var _data = data_goods_ep_compose[0];
                string _stuff = _data["needs"];
                string _moneys = _data["moneys"];
                var stuff_matchs = TextHelper.ParseBraceContent(_stuff, true);
                foreach (var _match in stuff_matchs)
                {
                    uint goodsId = DBTextResource.ParseUI(_match[0]);
                    GoodsItem goods = new GoodsItem(goodsId);
                    goods.num = DBTextResource.ParseUI(_match[1]);
                    data.Stuffs.Add(goods);
                }
                SGameEngine.Pool<List<string>>.List.Free(stuff_matchs);

                var money_matchs = TextHelper.ParseBraceContent(_moneys, true);
                foreach (var _match in money_matchs)
                {
                    Dictionary<ushort, uint> dic = new Dictionary<ushort, uint>();
                    ushort _moneyType = DBTextResource.ParseUS(_match[0]);
                    uint num = DBTextResource.ParseUI(_match[1]);
                    dic.Add(_moneyType, num);
                    data.Moneys.Add(dic);
                }
                SGameEngine.Pool<List<string>>.List.Free(money_matchs);

                uint maxUnBindNum = 0;
                uint maxTotalNum = 0;
                for(int i = 0 ; i < data.Stuffs.Count ; i++)
                {
                    uint unbindNum = (uint)Mathf.FloorToInt((float)ItemManager.GetInstance().GetGoodsUnbindNumForBagByTypeId(data.Stuffs[i].type_idx)/(float)data.Stuffs[i].num);
                    uint totalNum = (uint)Mathf.FloorToInt((float)ItemManager.GetInstance().GetGoodsNumForBagByTypeId(data.Stuffs[i].type_idx)/(float)data.Stuffs[i].num);
                    if(i == 0)
                    {
                        maxUnBindNum = unbindNum;
                        maxTotalNum = totalNum;
                    }
                    else
                    {
                        if(unbindNum < maxUnBindNum)
                            maxUnBindNum = unbindNum;
                        if(totalNum < maxTotalNum)
                            maxTotalNum = totalNum;
                    }
                }

                uint lastMoneyNum = 0;
                bool first = true;
                foreach(var money in data.Moneys)
                {
                    foreach(var kv in money)
                    {
                        uint playerMoney = LocalPlayerManager.Instance.GetMoneyByConst(kv.Key);
                        uint moneyNeedNum = (uint)Mathf.FloorToInt((float)playerMoney/ (float)kv.Value);
                        if (first)
                        {
                            lastMoneyNum = moneyNeedNum;
                        }
                        else if(moneyNeedNum < lastMoneyNum)   
                            lastMoneyNum = moneyNeedNum;
                    }
                }
                if(lastMoneyNum < maxTotalNum)
                    data.CompositeMaxTotalNum = lastMoneyNum;
                else
                    data.CompositeMaxTotalNum = maxTotalNum;

                if(lastMoneyNum < maxUnBindNum)
                    data.CompositeMaxUnBindNum = lastMoneyNum;
                else
                    data.CompositeMaxUnBindNum = maxUnBindNum;
                
            }
            return data;
        }

        public static GoodsCompositeData GetCompositeData(string const_value)
        {
            GoodsCompositeData data = new GoodsCompositeData();
            var str = GameConstHelper.GetString(const_value);
            str = str.Substring(1 , str.Length-2);
            str = str.Replace(" ", "");
            string[] _tmp_split = str.Split(',');
            data.CompositeLvId = DBTextResource.ParseUI(_tmp_split[0]);
            data.TopLv = DBTextResource.ParseUI(_tmp_split[1]);
            data.TypeName = _tmp_split[2].Substring(1 , _tmp_split[2].Length-2);
            return data;
        }
        /// <summary>
        /// 打开物品对应的系统id
        /// </summary>
        /// <param name="gid"></param>
        public static bool OpenGoodsSysWindow(uint gid)
        {

            uint sys_id = 0;
            var goods_info = GoodsHelper.GetGoodsInfo(gid);
            if (goods_info != null)
            {
                sys_id = goods_info.sys_id;
            }

            if (sys_id != 0)
            {
                RouterManager.Instance.GenericGoToSysWindow(sys_id, gid);
                return true;
            }
            else
                return false;
        }

        /// <summary>
        /// 根据品质获取特效路径
        /// </summary>
        /// <param name="qua"></param>
        /// <returns></returns>
        public static string GetGoodsEffectPath(uint qua)
        {
            string str = string.Empty;
            switch (qua)
            {
                case GameConst.QUAL_COLOR_WHITE:
                    str = "Assets/" + ResPath.path31;
                    break;
                case GameConst.QUAL_COLOR_GREEN:
                    str = "Assets/" + ResPath.path32;
                    break;
                case GameConst.QUAL_COLOR_BLUE:
                    str = "Assets/" + ResPath.path33;
                    break;
                case GameConst.QUAL_COLOR_PURPLE:
                    str = "Assets/" + ResPath.path34;
                    break;
                case GameConst.QUAL_COLOR_GOLDEN:
                    str = "Assets/" + ResPath.path35;
                    break;
                case GameConst.QUAL_COLOR_PINK:
                    str = "Assets/" + ResPath.path36;
                    break;
                case GameConst.QUAL_COLOR_RED:
                    str = "Assets/"+ ResPath.path37;
                    break;
            }
            return str;
        }

        /// <summary>
        /// 物品品质框
        /// </summary>
        /// <param name="qua"></param>
        /// <returns></returns>
        public static string GetGoodsColorSpr(uint qua)
        {
            string str = string.Empty;
            switch (qua)
            {
                case GameConst.QUAL_COLOR_WHITE:
                    str = "Assets/" + ResPath.path31;
                    break;
                case GameConst.QUAL_COLOR_GREEN:
                    str = "Assets/" + ResPath.path32;
                    break;
                case GameConst.QUAL_COLOR_BLUE:
                    str = "Assets/" + ResPath.path33;
                    break;
                case GameConst.QUAL_COLOR_PURPLE:
                    str = "Assets/" + ResPath.path34;
                    break;
                case GameConst.QUAL_COLOR_GOLDEN:
                    str = "Assets/" + ResPath.path35;
                    break;
                case GameConst.QUAL_COLOR_PINK:
                    str = "Assets/" + ResPath.path36;
                    break;
                case GameConst.QUAL_COLOR_RED:
                    str = "Assets/" + ResPath.path37;
                    break;
            }
            return str;
        }


        public static Color GetGoodsColorByQua(uint qua)
        {
            Color color = Color.white;
            switch (qua)
            {
                case GameConst.QUAL_COLOR_WHITE:
                    color = new Color(114.00f/255.00f, 114.00f / 255.00f, 114.00f / 255.00f, 1f);
                    break;
                case GameConst.QUAL_COLOR_GREEN:
                    color = new Color(75.00f / 255.00f, 163.00f / 255.00f, 33.00f / 255.00f, 1f);
                    break;
                case GameConst.QUAL_COLOR_BLUE:
                    color = new Color(0, 131.00f / 255.00f, 1f, 1f);
                    break;
                case GameConst.QUAL_COLOR_PURPLE:
                    color = new Color(205.00f / 255.00f, 0, 208.00f / 255.00f, 1f);
                    break;
                case GameConst.QUAL_COLOR_GOLDEN:
                    color = new Color(221.00f / 255.00f, 176.00f / 255.00f, 0, 1f);
                    break;
                case GameConst.QUAL_COLOR_PINK:
                    color = new Color(1f, 113.00f / 255.00f, 0f, 1f);
                    break;
                case GameConst.QUAL_COLOR_RED:
                    color = new Color(1f, 0f, 0f, 1f);
                    break;
            }
            return color;
        }

        /// <summary>
        /// 根据传入的物品ID来设置RawImage的图片
        /// </summary>
        /// <param name="id"></param>
        /// <param name="tex"></param>
        /// <returns></returns>
        public static uint GetGoodsIconTexutreByTypeId(uint id ,  RawImage tex)
        {
             return GetGoodsIconTextureByIconId(GetGoodsIconIdByTypeId(id) , tex);
        }

        /// <summary>
        /// 启动加载物品图标资源的协程
        /// </summary>
        /// <param name="icon"></param>
        /// <param name="tx"></param>
        /// <param name="load_icon_id"></param>
        /// <returns></returns>
        static IEnumerator LoadIconAsync(uint icon , RawImage image, uint iconLoadID)
        {
            if (image == null)
            {
                mLoadingIconIDs.Remove(iconLoadID);
                yield break;
            }

            var iconInfo = GoodsHelper.GetIconInfo(icon);
            var ar = new SGameEngine.AssetResource();
            yield return xc.MainGame.GetGlobalMono().StartCoroutine(SGameEngine.ResourceLoader.Instance.load_asset(iconInfo.MainTexturePath , typeof(Texture), ar));

            // 检查资源
            var assetObject = ar.asset_;
            if (assetObject == null)
            {
                mLoadingIconIDs.Remove(iconLoadID);
                yield break;
            }

            // 检查Image
            if (image == null)
            {
                ar.destroy();
                mLoadingIconIDs.Remove(iconLoadID);
                yield break;
            }
               
            // 检查Image加载是否已经被移除
            if (mLoadingIconIDs.Contains(iconLoadID))
            {
                mLoadingIconIDs.Remove(iconLoadID);

                image.texture = assetObject as Texture;
                image.uvRect = iconInfo.IconRect;

                var imageObject = image.gameObject;
                CommonTool.SetActive(imageObject, true);
                SGameEngine.ResourceUtilEx.Instance.host_res_to_gameobj(imageObject, ar);// 将asset资源的生命周期与GameObject关联起来
            }
            else
            {
                ar.destroy();
            }
        }

        /// <summary>
        /// 保存正在加载物品的标记ID
        /// </summary>
        private static HashSet<uint> mLoadingIconIDs = new HashSet<uint>();

        /// <summary>
        /// 当前的图片加载的标记ID
        /// </summary>
        private static uint mIconLoadID = 1;

        /// <summary>
        /// 根据传入的IconID来设置RawImage的图片
        /// </summary>
        /// <param name="iconId"></param>
        /// <param name="text"></param>
        /// <returns></returns>
        public static uint GetGoodsIconTextureByIconId(uint iconId , RawImage text)
        {
            mIconLoadID++;
            if (mIconLoadID > 1000000)
                mIconLoadID = 1;

            if(!mLoadingIconIDs.Contains(mIconLoadID))
                mLoadingIconIDs.Add(mIconLoadID);

            CommonTool.SetActive(text.gameObject, false);
            xc.MainGame.GetGlobalMono().StartCoroutine(GoodsHelper.LoadIconAsync(iconId , text, mIconLoadID));

            return mIconLoadID;
        }

        /// <summary>
        /// 移除某一次的图片加载
        /// </summary>
        /// <param name="load_icon_id"></param>
        public static void RemoveLoadGoodsIcon(uint load_icon_id)
        {
            mLoadingIconIDs.Remove(load_icon_id);
        }

        //只针对物品表中物品
        public static uint GetGoodsIconIdByTypeId(uint id)
        {
            uint icon_id = 0;
            var goods_info = GoodsHelper.GetGoodsInfo(id);
            if (goods_info != null)
            {
                icon_id = goods_info.icon_id;
            }

            return GetDisplayIconId(icon_id);
        }

        public static uint GetGoodsUseJobByTpyeId(uint id)
        {
            uint use_job = 0;
            var goods_info = GoodsHelper.GetGoodsInfo(id);
            if (goods_info != null)
            {
                use_job = goods_info.use_job;
            }
            return use_job;
        }

        //处理转换成要显示的id 如：处理按职业区分图标
        public static uint GetDisplayIconId(uint rawIconId)
        {
            DBGoodsVocationIcon db_vocation_icon = DBManager.Instance.GetDB<DBGoodsVocationIcon>();
            DBGoodsVocationIcon.DBGoodsVocationIconItem vocation_icon_item = db_vocation_icon.GetOneInfo(rawIconId);
            if (vocation_icon_item != null)
            {
                rawIconId = vocation_icon_item.GetIconId(LocalPlayerManager.Instance.LocalActorAttribute.Vocation);
            }
            return rawIconId;
        }

        public static IconInfo GetIconInfo(uint icon_id)
        {
            uint tmp_icon = icon_id;
            IconInfo info = new IconInfo();
            WXIconAsset asset = ItemManager.GetInstance().mIconConfig;
            Rect rect = new Rect();
            if(asset.IconList.TryGetValue(tmp_icon , out rect))
                info.IconRect = rect;
            else
                tmp_icon = 0;
            if (asset.IconList.TryGetValue(tmp_icon , out rect))
                info.IconRect = rect;
            foreach(var kv in asset.MainTexIconList)
            {
                foreach(var _iconId in kv.Value)
                {
                    if(tmp_icon == _iconId)
                    {
                        info.MainTexturePath = kv.Key;
                        return info;
                    }
                }
            }
            return info;
        }

        public static Goods CreateGoodsByTypeId(uint typeId)
        {
            var goods_info = GoodsHelper.GetGoodsInfo(typeId);
            if (goods_info != null)
            {
                var goods = GoodsFactory.Create(goods_info.type, typeId, null);
                return goods;
            }
            else
            {
                //GameDebug.LogError("CreateGoodsByTypeId error, can not find goods " + typeId);
                var goods = GoodsFactory.Create(0, typeId, null);
                return goods;
            }
        }

        //根据使用类型获得文案名称
        public static string GetGoodsUseJob(uint use_job)
        {
            switch (use_job)
            {
                case GameConst.RACE_WARRIOR:
                    return DBConstText.GetText("RACE_WARRIOR");
                case GameConst.RACE_ASSASSIN:
                    return DBConstText.GetText("RACE_ASSASSIN");
                case GameConst.RACE_MAGICIAN:
                    return DBConstText.GetText("RACE_MAGICIAN");
                default:
                    return xc.TextHelper.GetConstText("CODE_TEXT_LOCALIZATION_62");
            }
        }


        /// <summary>
        /// 判断该物品是否为金币
        /// </summary>
        /// <param name="gid"></param>
        /// <returns></returns>
        public static bool GoodsIsMoney(uint gid)
        {

            switch ((ushort)gid)
            {
                case GameConst.MONEY_COIN:
                    {
                        return true;
                    }
                case GameConst.MONEY_COIN_BIND:
                    {
                        return true;
                    }
                case GameConst.MONEY_DIAMOND:
                    {
                        return true;
                    }
                case GameConst.MONEY_DIAMOND_BIND:
                    {
                        return true;
                    }
                default:
                    return false;
            }

        }

        public static string GetGoodsColor(uint quality)
        {
            return GetGoodsColor_whiteBkg(quality);
        }
        static bool m_init_color_array = false;
        public class ColorQualityItem
        {
            public bool isQuality;
            public uint quality;
            public string whiteBkgColor;
            public string blackBkgColor;
            public string qualityName;
        }
        static Dictionary<uint, ColorQualityItem> mColorQualityArray;
        /// <summary>
        /// 替换品质颜色（全部转成白底颜色）
        /// </summary>
        /// <param name="name">包含品质颜色的内容</param>
        /// <returns>使用白底的品质颜色内容</returns>
        public static string ReplaceGoodsColor_whiteBkg(string name)
        {
            InitColorArray();
            string out_name = name;
            foreach(var item in mColorQualityArray)
            {
                out_name = out_name.Replace(item.Value.blackBkgColor, item.Value.whiteBkgColor);
            }
            return out_name;
        }

        /// <summary>
        /// 替换品质颜色（全部转成黑底颜色）
        /// </summary>
        /// <param name="name">包含品质颜色的内容</param>
        /// <returns>使用黑底的品质颜色内容</returns>
        public static string ReplaceGoodsColor_blackBkg(string name)
        {
            InitColorArray();
            string out_name = name;
            foreach (var item in mColorQualityArray)
            {
                out_name = out_name.Replace(item.Value.whiteBkgColor, item.Value.blackBkgColor);
            }
            return out_name;
        }

        static void InitColorArray()
        {
            if (m_init_color_array)
                return;
            m_init_color_array = true;
            mColorQualityArray = new Dictionary<uint, ColorQualityItem>();
            List<uint> all_quality = new List<uint>() { GameConst.QUAL_COLOR_GREEN,
                GameConst.QUAL_COLOR_BLUE, GameConst.QUAL_COLOR_PURPLE, GameConst.QUAL_COLOR_GOLDEN,
                GameConst.QUAL_COLOR_RED, GameConst.QUAL_COLOR_PINK, GameConst.QUAL_COLOR_WHITE};
            uint max_quality = 0;
            for(int index = 0; index < all_quality.Count; ++index)
            {
                ColorQualityItem item = new ColorQualityItem();
                item.quality = all_quality[index];
                item.isQuality = true;
                item.whiteBkgColor = GetGoodsColor_whiteBkg(item.quality);
                item.blackBkgColor = GetGoodsColor_blackBkg(item.quality);
                item.qualityName = GetGoodsColorName(item.quality);
                mColorQualityArray.Add(item.quality, item);
                if(max_quality < item.quality)
                {
                    max_quality = item.quality;
                }
            }
            ColorQualityItem item_1 = new ColorQualityItem();
            item_1.quality = max_quality + 1;
            max_quality = max_quality + 1;
            item_1.isQuality = false;
            item_1.whiteBkgColor = GameConst.COLOR_BRIGHT_RED;
            item_1.blackBkgColor = GameConst.COLOR_DARK_RED;
            mColorQualityArray.Add(item_1.quality, item_1);

            item_1 = new ColorQualityItem();
            item_1.quality = max_quality + 1;
            max_quality = max_quality + 1;
            item_1.isQuality = false;
            item_1.whiteBkgColor = GameConst.COLOR_BRIGHT_DULLRED;
            item_1.blackBkgColor = GameConst.COLOR_DARK_DULLRED;
            mColorQualityArray.Add(item_1.quality, item_1);
        }

        /// <summary>
        /// 返回品质颜色（白色图片底）
        /// </summary>
        /// <param name="quality"></param>
        /// <returns></returns>
        public static string GetGoodsColor_whiteBkg(uint quality)
        {
            switch (quality)
            {
                case GameConst.QUAL_COLOR_GREEN:
                    return GameConst.COLOR_BRIGHT_GREEN;
                case GameConst.QUAL_COLOR_BLUE:
                    return GameConst.COLOR_BRIGHT_BLUE;
                case GameConst.QUAL_COLOR_PURPLE:
                    return GameConst.COLOR_BRIGHT_PURPLE;
                case GameConst.QUAL_COLOR_GOLDEN:
                    return GameConst.COLOR_BRIGHT_YELLOW;
                case GameConst.QUAL_COLOR_PINK:
                    return GameConst.COLOR_BRIGHT_PINK;
                case GameConst.QUAL_COLOR_RED:
                    return GameConst.COLOR_BRIGHT_RED_GOODS;
                default:
                    return GameConst.COLOR_BRIGHT_WHITE;
            }
        }

        /// <summary>
        /// 返回品质颜色（黑底图片底）
        /// </summary>
        /// <param name="quality"></param>
        /// <returns></returns>
        public static string GetGoodsColor_blackBkg(uint quality)
        {
            switch (quality)
            {
                case GameConst.QUAL_COLOR_GREEN: // 绿色
                    return GameConst.COLOR_DARK_GREEN;
                case GameConst.QUAL_COLOR_BLUE: // 蓝色
                    return GameConst.COLOR_DARK_BLUE;
                case GameConst.QUAL_COLOR_PURPLE: // 紫色
                    return GameConst.COLOR_DARK_PURPLE;
                case GameConst.QUAL_COLOR_GOLDEN: // 金色
                    return GameConst.COLOR_DARK_YELLOW;
                case GameConst.QUAL_COLOR_PINK: // 粉色
                    return GameConst.COLOR_DARK_PINK;
                case GameConst.QUAL_COLOR_RED: // 红色
                    return GameConst.COLOR_DARK_RED_GOODS;
                default:
                    return GameConst.COLOR_DARK_WHITE;
            }
        }

        /// <summary>
        /// 返回品质颜色的名字
        /// </summary>
        /// <param name="quality"></param>
        /// <returns></returns>
        public static string GetGoodsColorName(uint quality)
        {
            switch (quality)
            {
                case GameConst.QUAL_COLOR_GREEN: // 绿色
                    return DBConstText.GetText("GAME_GOODS_QUAL_GREEN");
                case GameConst.QUAL_COLOR_BLUE: // 蓝色
                    return DBConstText.GetText("GAME_GOODS_QUAL_BLUE");
                case GameConst.QUAL_COLOR_PURPLE: // 紫色
                    return DBConstText.GetText("GAME_GOODS_QUAL_PURPLE");
                case GameConst.QUAL_COLOR_GOLDEN: // 金色
                    return DBConstText.GetText("GAME_GOODS_QUAL_GOLDEN");
                case GameConst.QUAL_COLOR_PINK: // 粉色
                    return DBConstText.GetText("GAME_GOODS_QUAL_PINK");
                case GameConst.QUAL_COLOR_RED: // 红色
                    return DBConstText.GetText("GAME_GOODS_QUAL_RED");
                default:
                    return DBConstText.GetText("GAME_GOODS_QUAL_WHITE");
            }
        }

        /// <summary>
        /// 返回指定品质和背景框下的颜色字符
        /// </summary>
        /// <param name="quality"></param>
        /// <param name="bk_type">0：浅色 1: 深色</param>
        /// <returns></returns>
        public static string GetTextColor(uint quality, uint bk_type)
        {
            if (quality == GameConst.QUAL_COLOR_RED)
            {
                if (bk_type == 0)
                    return GameConst.COLOR_BRIGHT_RED;
                else
                    return GameConst.COLOR_DARK_RED;
            }
            else if(quality == GameConst.QUAL_COLOR_PINK)
            {
                if (bk_type == 0)
                    return GameConst.COLOR_BRIGHT_PINK;
                else
                    return GameConst.COLOR_DARK_PINK;

            }
            if (bk_type == 0)
            {
                return GetGoodsColor_whiteBkg(quality);
            }
            else
                return GetGoodsColor_blackBkg(quality);
        }

        public static string GetGoodsColor(Goods goods)
        {
            return GetGoodsColor(goods.color_type);
        }
        
        public static Goods CreateGoodsByTypeId(uint typeId , uint main_type)
        {
            var goods_info = GoodsHelper.GetGoodsInfo(typeId);
            if (goods_info == null)
                return null;

            var goods = GoodsFactory.Create(main_type, typeId, null);
            return goods;
        }

        public static Goods GetGoodsFromPkgInfo(Net.PkgGoodsInfo info )
        {
            //根据信息创建物品对象
            Goods goods = CreateGoodsByTypeId(info.gid, info.type);

            //填充物品信息
            goods.main_type = info.type;
//            goods.sub_type = info.type;
            goods.bind = info.bind;
            goods.id = info.oid;
            goods.num = info.num;
            goods.expire_time = info.expire_time;
            //如果是宠物蛋，需要填充宠物蛋信息
//            if (info.egg != null)
//            {
//                PetEgg egg = goods as PetEgg;
//                egg.set_zg_attrs(info.egg.zg_list);
//                egg.set_init_attrs(info.egg.attrs_list);
//                egg.ex_skell = info.egg.ex_skill;
//                egg.skill_list = info.egg.skill_list;
//            }
            return goods;

        }

        public static Goods CreateEquipFromNet(Net.PkgGoodsInfo info)
        {            GoodsEquip goodsEquip = new GoodsEquip(info.gid , info);
            //goodsEquip.InitWithEquipInfo(equip_info);
            goodsEquip.expire_time = info.expire_time;

            return goodsEquip;
        }

        public static GoodsEquip CreateEquipGoodsFromNet(Net.PkgGoodsInfo info)
        {
            var goodsEquip = new GoodsEquip(info.gid, info);
            //goodsEquip.InitWithEquipInfo(equip_info);
            goodsEquip.expire_time = info.expire_time;

            return goodsEquip;
        }

        public static GoodsEquip CreateEquipGoodsByTypeId(uint typeId)
        {
            var goods = CreateGoodsByTypeId(typeId);
            var goodsEquip = goods as GoodsEquip;

            return goodsEquip; 
        }

        #region 构造
        public static List<Goods> CreateGoodsFromNetByProtocol(ushort protocol, byte[] data)
        {
            List<Goods> list = new List<Goods>();
            switch (protocol)
            {
                case NetMsg.MSG_PINK_EQUIP_DECOMPOSE:
                    {
                        var pack = S2CPackBase.DeserializePack<S2CPinkEquipDecompose>(data);
                        foreach (var pkg in pack.info)
                        {
                            Goods goods = GoodsFactory.Create(pkg.gid, pkg);
                            list.Add(goods);
                        }
                        return list;
                    }
                case NetMsg.MSG_PINK_OUTFIT_DECOMPOSE:
                    {
                        var pack = S2CPackBase.DeserializePack<S2CPinkOutfitDecompose>(data);
                        foreach (var pkg in pack.info)
                        {
                            Goods equip = GoodsFactory.Create(pkg.gid, pkg);
                            list.Add(equip);
                        }
                        return list;
                    }

                default:
                    return list;
            }
        }
        #endregion

        /// <summary>
        /// 获得背包武魂按照可镶嵌 评分从高到低 
        /// </summary>
        /// <returns></returns>
        public static List<GoodsSoul> GetSoulSortList(uint hole)
        {
            List<GoodsSoul> soulBag = new List<GoodsSoul>();
            GoodsSoul tmp_soul;
            foreach (var item in ItemManager.Instance.SoulGoodsOids)
            {
                tmp_soul = item.Value as GoodsSoul;
                tmp_soul.RefreshSoulCanInstallHole(hole);
                soulBag.Add(tmp_soul);
            }
            soulBag.Sort(delegate (GoodsSoul a, GoodsSoul b)
            {
                if (a.mCanInstallHole && b.mCanInstallHole == false)
                    return -1;
                else if (a.mCanInstallHole == false && b.mCanInstallHole)
                    return 1;
                else
                {
                    if (a.sort_id < b.sort_id)
                        return -1;
                    else if (a.sort_id > b.sort_id)
                        return 1;

                    if (a.Lv > b.Lv)
                        return -1;
                    else if (a.Lv < b.Lv)
                        return 1;
                    return 0;
                }
            }
            );
            return soulBag;
        }

        /// <summary>
        /// 获得背包武魂按照可镶嵌 评分从高到低 
        /// </summary>
        /// <returns></returns>
        public static List<GoodsSoul> GetSoulSortList_noCheckInstall()
        {
            List<GoodsSoul> soulBag = new List<GoodsSoul>();
            GoodsSoul tmp_soul;
            foreach (var item in ItemManager.Instance.SoulGoodsOids)
            {
                tmp_soul = item.Value as GoodsSoul;
                if(tmp_soul != null)
                    soulBag.Add(tmp_soul);
            }
            soulBag.Sort(delegate (GoodsSoul a, GoodsSoul b)
            {
                if (a.sort_id < b.sort_id)
                    return -1;
                else if (a.sort_id > b.sort_id)
                    return 1;

                if (a.Lv > b.Lv)
                    return -1;
                else if (a.Lv < b.Lv)
                    return 1;
                return 0;
            }
            );
            return soulBag;
        }

        /// <summary>
        /// 判断这个武魂类型是否一镶嵌
        /// </summary>
        /// <param name="soul"></param>
        /// <returns></returns>
        public static bool GetSoulIsInstall(GoodsSoul soul)
        {
            //List<GoodsSoul> list = new List<GoodsSoul>();
            //foreach (var kv in ItemManager.Instance.InstallGoodsSouls)
            //{
            //    list.Add(kv.Value);
            //}

            //var _soul = list.Find(delegate (GoodsSoul goods) { return soul.sub_type == goods.sub_type; });
            //if (_soul != null)
            //    return true;
            return false;
        }
        /// <summary>
        /// 判断是否可以镶嵌
        /// </summary>
        /// <param name="hole"></param>
        /// <param name="soul"></param>
        /// <returns></returns>
        /// 

        //1 能装  2 不能装 因为孔类型不对   3 不能装 因为已经有相同类型
        public static uint SoulCanInstallHole(uint hole, GoodsSoul soul)
        {
            //List<uint> list = new List<uint>();
            //foreach (var kv in ItemManager.Instance.InstallGoodsSouls)
            //{
            //    foreach (var id in kv.Value.BasicAttrs.Keys)
            //    {
            //        list.Add(id);
            //    }
            //}
            //foreach (var id in soul.BasicAttrs.Keys)
            //{
            //    if (list.Contains(id))
            //    {
            //        return false;
            //    }
            //}
            //return true;

            return SoulCanInstallHoleNew(hole, soul);
        }

        static List<uint> mSoulTypeList = null;
        //1 能装  2 不能装 因为孔类型不对   3 不能装 因为已经有相同类型
        public static uint SoulCanInstallHoleNew(uint hole, GoodsSoul soul)
        {

            DBSoulHole.DBSoulHoleItem itemInfo = DBSoulHole.Instance.GetData(hole);
            if (itemInfo == null)
            {
                //异常
                return 3;
            }
            List<uint> limitedList = itemInfo.inlay_type;

            //有限制
            if (limitedList.Count != 0)
            {
                //不符合
                if (soul.IsHaveSame(limitedList) == false)
                    return 2;
            }
            else
            {
                if (soul.IsHaveSame(DBSoulHole.Instance.GetLimitedList()))
                    return 2;
            }


            //List<uint> subTypeList = new List<uint>();
            //foreach (var kv in ItemManager.Instance.InstallGoodsSouls)
            //{
            //    if (kv.Value.HoleId != hole)
            //    {
            //        subTypeList.AddRange(kv.Value.TypeList);
            //    }
            //}
             

            ////不能有相同类型
            //for (int i = 0; i < subTypeList.Count; i++)
            //{
            //    if (soul.TypeList.Contains(subTypeList[i]))
            //        return 3;
            //}
            if (mSoulTypeList == null)
            {
                mSoulTypeList = new List<uint>();
            }
            mSoulTypeList.Clear();
            foreach (var kv in ItemManager.Instance.InstallGoodsSouls)
            {
                if (kv.Value.HoleId != hole)
                {
                    mSoulTypeList.Add(kv.Value.SoulType);
                }
            }
            //不能有相同类型
            for (int i = 0; i < mSoulTypeList.Count; i++)
            {
                if (soul.SoulType == mSoulTypeList[i])
                    return 3;
            }


            return 1;
        }



        public static List<GoodsSoul> CheckNeedRemoveInstallWhenInstall(uint holeId, GoodsSoul soul)
        {
            List<GoodsSoul> needRemove = new List<GoodsSoul>();
            foreach (GoodsSoul installSoul in ItemManager.Instance.InstallGoodsSouls.Values)
            {
                if (installSoul.HoleId != holeId)
                {
                    if (soul.IsHaveSame(installSoul.TypeList))
                    {
                        needRemove.Add(installSoul);
                    }
                }
            }
            return needRemove;
        }




        public static GoodsSoul GetBodyGoodSoulByHoleId(uint holeId)
        {
            GoodsSoul item = null;
            ItemManager.Instance.InstallGoodsSouls.TryGetValue(holeId, out item);
            return item;
        }


        public static uint CheckIsBodyOrBagHaveSoul(uint gid)
        {
            foreach (var soul in ItemManager.Instance.InstallGoodsSouls.Values)
            {
                if (soul.type_idx == gid)
                {
                    return 1;
                }
            }
            foreach (var soul in ItemManager.GetInstance().SoulGoodsOids.Values)
            {
                if (soul.type_idx == gid)
                {
                    return 2;
                }
            }

            return 0;
        }


        public static bool SoulBagIsHaveCanEquipByHoleId(uint holeId)
        {
            foreach (var good in ItemManager.Instance.SoulGoodsOids.Values)
            {
                if (SoulCanInstallHole(holeId, (good as GoodsSoul)) == 1)
                    return true;
            }
            return false;
        }




        /// <summary>
        /// 获取武魂图鉴所有的type
        /// </summary>
        /// <returns></returns>
        public static List<uint> AllSoulTypeIds()
        {
            Dictionary<uint,uint> idAndSubId = new Dictionary<uint, uint>();
            List<Dictionary<string, string>> data_soul_book = DBManager.Instance.QuerySqliteTable<string>(GlobalConfig.DBFile, "data_soul_book");
            for (int i = 0; i < data_soul_book.Count; i++)
            {
                Dictionary<string, string> data = data_soul_book[i];
                uint id = DBTextResource.ParseUI(data["id"]);
                uint _type = DBTextResource.ParseUI(data["type"]);
                if (idAndSubId.ContainsKey(_type) == false)
                {
                    idAndSubId.Add(_type, id);
                }
            }
            List<uint> ids = new List<uint>();
            foreach (var kv in idAndSubId)
            {
                ids.Add(kv.Value);
            }
            return ids;
        }
        /// <summary>
        /// 获得武魂之前消耗的所有val
        /// </summary>
        /// <param name="gid"></param>
        /// <param name="lv"></param>
        /// <returns></returns>
        public static uint GetSoulCostTotalVal(uint gid, uint lv)
        {
            uint val = 0;
            for (int i = 1; i < lv; i++)
            {
                string key = string.Format("{0}_{1}", gid, i);
                var info = DBSoulLv.Instance.GetData(key);
                if (info != null)
                {
                    val = val + info.cream;
                }
            }
            return val;
        }

        /// <summary>
        /// 获得某个类型的图鉴id
        /// </summary>
        /// <param name="type"></param>
        /// <returns></returns>
        public static List<uint> GetSoulBookTypeAllIds(uint type)
        {
            List<uint> ids = new List<uint>();
            List<Dictionary<string, string>> data_soul_book = DBManager.Instance.QuerySqliteRow<string>(GlobalConfig.DBFile, "data_soul_book", "type", type.ToString());
            for (int i = 0; i < data_soul_book.Count; i++)
            {
                var table = data_soul_book[i];
                uint id = DBTextResource.ParseUI(table["id"]);
                ids.Add(id);
            }

            return ids;
        }
        //获得武魂图鉴属性描述
        public static string GetSoulBookAttrStr(uint id)
        {
            string str = string.Empty;
            List<Dictionary<string, string>> data_soul_book = DBManager.Instance.QuerySqliteRow<string>(GlobalConfig.DBFile, "data_soul_book", "id", id.ToString());
            if (data_soul_book.Count > 0)
            {
                var table = data_soul_book[0];
                string special = table["special_des"];
                if (special.CompareTo(str) != 0)
                {
                    return special;
                }
                else
                {
                    string baseAttr = table["base_attr"];
                    var matchs = TextHelper.ParseBraceContent(baseAttr, true);
                    foreach (var _match in matchs)
                    {
                        uint attrId = (DBTextResource.ParseUI(_match[0]));
                        uint attrValue = DBTextResource.ParseUI(_match[1]);
                        DefaultActorAttribute attr = new DefaultActorAttribute(attrId, attrValue);
                        str = attr.Name;
                    }
                    SGameEngine.Pool<List<string>>.List.Free(matchs);
                }
            }
            return str;
        }
        /// <summary>
        /// 获得图鉴总属性
        /// </summary>
        /// <returns></returns>
        public static string GetTotalSoulBookAttr()
        {
            ActorAttribute BaseAttr = new ActorAttribute();
            string specialStr = string.Empty;
            string str = string.Empty;
            for (int i = 0; i < ItemManager.Instance.OpenSoulList.Count; i++)
            {
                List<Dictionary<string, string>> data_soul_book = DBManager.Instance.QuerySqliteRow<string>(GlobalConfig.DBFile, "data_soul_book", "id", ItemManager.Instance.OpenSoulList[i].ToString());
                if (data_soul_book.Count > 0)
                {
                    var table = data_soul_book[0];
                    string special = table["special_des"];
                    if (special.CompareTo(str) != 0)
                    {
                        specialStr = specialStr + special + "\n";
                    }
                    else
                    {
                        string baseAttr = table["base_attr"];
                        var matchs = TextHelper.ParseBraceContent(baseAttr, true);
                        foreach (var _match in matchs)
                        {
                            uint attrId = DBTextResource.ParseUI(_match[0]);
                            uint attrValue = DBTextResource.ParseUI(_match[1]);
                            if (BaseAttr.ContainsKey(attrId))
                            {
                                BaseAttr[attrId].Value = attrValue + BaseAttr[attrId].Value;
                            }
                            else
                                BaseAttr.Add(attrId, attrValue);
                        }
                        SGameEngine.Pool<List<string>>.List.Free(matchs);
                    }
                }
            }
            str = specialStr;
            string baseStr = string.Empty;
            foreach (var kv in BaseAttr)
            {
                if (kv.Value is DefaultActorAttribute)
                {
                    DefaultActorAttribute attr = kv.Value as DefaultActorAttribute;
                    baseStr = baseStr + attr.Name + "\n";
                }
            }
            str = str + baseStr;
            return str;
        }

        /// <summary>
        /// 获得图鉴总属性(分开值)
        /// </summary>
        /// <returns></returns>
        public static List<xc.Equip.EquipHelper.AttributeDescItem> GetTotalSoulBookAttr_list()
        {
            List<xc.Equip.EquipHelper.AttributeDescItem> descItemArray = new List<xc.Equip.EquipHelper.AttributeDescItem>();
            ActorAttribute BaseAttr = new ActorAttribute();
            //string specialStr = string.Empty;
            string str = string.Empty;
            for (int i = 0; i < ItemManager.Instance.OpenSoulList.Count; i++)
            {
                List<Dictionary<string, string>> data_soul_book = DBManager.Instance.QuerySqliteRow<string>(GlobalConfig.DBFile, "data_soul_book", "id", ItemManager.Instance.OpenSoulList[i].ToString());
                if (data_soul_book.Count > 0)
                {
                    var table = data_soul_book[0];
                    string special = table["special_des"];
                    if (special.CompareTo(str) != 0)
                    {
                        xc.Equip.EquipHelper.AttributeDescItem tmp_AttributeDescItem = new xc.Equip.EquipHelper.AttributeDescItem();
                        tmp_AttributeDescItem.PropName = special;
                        tmp_AttributeDescItem.ValueStr = "";
                        descItemArray.Add(tmp_AttributeDescItem);
                        //specialStr = specialStr + special + "\n";
                    }
                    else
                    {
                        string baseAttr = table["base_attr"];
                        var matchs = TextHelper.ParseBraceContent(baseAttr, true);
                        foreach (var _match in matchs)
                        {
                            uint attrId = (DBTextResource.ParseUI(_match[0]));
                            uint attrValue = DBTextResource.ParseUI(_match[1]);
                            if (BaseAttr.ContainsKey(attrId))
                            {
                                BaseAttr[attrId].Value = attrValue + BaseAttr[attrId].Value;
                            }
                            else
                                BaseAttr.Add(attrId, attrValue);

                        }
                        SGameEngine.Pool<List<string>>.List.Free(matchs);
                    }
                }
            }
            //str = specialStr;
            //string baseStr = string.Empty;
            foreach (var kv in BaseAttr)
            {
                if (kv.Value is DefaultActorAttribute)
                {
                    DefaultActorAttribute attr = kv.Value as DefaultActorAttribute;
                    //baseStr = baseStr + attr.Name + "\n";
                    xc.Equip.EquipHelper.AttributeDescItem tmp_AttributeDescItem = new xc.Equip.EquipHelper.AttributeDescItem();
                    tmp_AttributeDescItem.PropName = attr.OrigName; ;
                    tmp_AttributeDescItem.ValueStr = attr.ValuesFormat;
                    descItemArray.Add(tmp_AttributeDescItem);
                }
            }
            //str = str + baseStr;
            return descItemArray;
        }

        /// <summary>
        /// 获得镶嵌的总属性
        /// </summary>
        /// <returns></returns>
        public static string InstallSoulTotalAllAttrStr()
        {
            ActorAttribute BaseAttr = new ActorAttribute();
            string specialStr = string.Empty;
            foreach (var kv in ItemManager.Instance.InstallGoodsSouls)
            {
                foreach (var attr in kv.Value.BasicAttrs)
                {
                    if (BaseAttr.ContainsKey(attr.Key))
                    {
                        BaseAttr[attr.Key].Value = attr.Value.Value + BaseAttr[attr.Key].Value;
                    }
                    else
                    {
                        BaseAttr.Add(attr.Key, attr.Value.Value);
                    }
                }
            }
            foreach (var kv in BaseAttr)
            {
                if (kv.Value is DefaultActorAttribute)
                {
                    DefaultActorAttribute attr = kv.Value as DefaultActorAttribute;
                    specialStr = specialStr + attr.Name + "\n";
                }
            }
            return specialStr;
        }

        /// <summary>
        /// 获得镶嵌的总属性
        /// </summary>
        /// <returns></returns>
        public static List<xc.Equip.EquipHelper.AttributeDescItem> InstallSoulTotalAllAttrStrArray()
        {
            ActorAttribute BaseAttr = new ActorAttribute();
            string specialStr = string.Empty;
            foreach (var kv in ItemManager.Instance.InstallGoodsSouls)
            {
                foreach (var attr in kv.Value.BasicAttrs)
                {
                    if (BaseAttr.ContainsKey(attr.Key))
                    {
                        BaseAttr[attr.Key].Value = attr.Value.Value + BaseAttr[attr.Key].Value;
                    }
                    else
                    {
                        BaseAttr.Add(attr.Key, attr.Value.Value);
                    }
                }
            }
            return xc.Equip.EquipHelper.GetEquipBaseDesItemArray(BaseAttr);
        }

        //从身上和背包获取 最高等级的武魂，优先身上
        public static GoodsSoul GetBodyAndBagMaxLevelSoulItem(uint type_idx)
        {
            GoodsSoul item = null;
            foreach (var soul in ItemManager.Instance.InstallGoodsSouls.Values)
            {
                if (soul.type_idx == type_idx)
                {
                    item = soul;
                }
            }
            if (item == null)
            {
                uint lv = 0;
                foreach (var soul in ItemManager.Instance.SoulGoodsOids.Values)
                {
                    if (soul.type_idx == type_idx)
                    {
                        GoodsSoul temp_data = soul as GoodsSoul;
                        if (temp_data.Lv > lv)
                        {
                            lv = temp_data.Lv;
                            item = temp_data;
                        }
                    }
                }
            }
            return item;
        }




        /// <summary>
        /// 获得某个等级的武魂属性
        /// </summary>
        /// <param name="gid"></param>
        /// <param name="lv"></param>
        /// <returns></returns>
        public static ActorAttribute GetSoulAttrByLv(uint gid , uint lv)
        {
            ActorAttribute BasicAttrs = new ActorAttribute();
            string key = string.Format("{0}_{1}", gid, lv);
            var info = DBSoulLv.Instance.GetData(key);
            if (info != null)
            {
                using (var iter = info.attr.GetEnumerator())
                {
                    while(iter.MoveNext())
                    {
                        var cur = iter.Current;
                        BasicAttrs.Add(cur.Key, cur.Value);
                    }
                }
            }
            return BasicAttrs;
        }
        /// <summary>
        /// 获得已激活的数量
        /// </summary>
        /// <param name="type"></param>
        /// <returns></returns>
        public static uint GetSoulActiveNumByType(uint type)
        {
            uint num = 0;
            for (int i = 0; i < ItemManager.Instance.OpenSoulList.Count; i++)
            {
                List<Dictionary<string, string>> data_soul_book = DBManager.Instance.QuerySqliteRow<string>(GlobalConfig.DBFile, "data_soul_book", "id", ItemManager.Instance.OpenSoulList[i].ToString());
                if (data_soul_book.Count > 0)
                {
                    var table = data_soul_book[0];
                    uint _type = DBTextResource.ParseUI(table["type"]);
                    if (_type == type)
                        num++;
                }
            }
            return num;
        }
        /// <summary>
        /// 获得通关条件描述
        /// </summary>
        /// <param name="kungfuId"></param>
        /// <returns></returns>
        public static string GetSoulOpenCondtionStr(uint kungfuId)
        {
            string str = "";
            List<string> data_secret_area = DBManager.Instance.QuerySqliteField<string>(GlobalConfig.DBFile, "data_secret_area", "id", kungfuId.ToString(), "text_title");
            if (data_secret_area.Count > 0)
            {
                var title = data_secret_area[0];
                if (InstanceManager.Instance.KunfuGodId < kungfuId)
                {
                    string text = DBConstText.GetText(title);
                    str = string.Format(xc.TextHelper.GetConstText("CODE_TEXT_LOCALIZATION_63"), text);
                }
            }
            return str;
        }

        /// <summary>
        /// 是否激活
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public static bool IsSoulActive(uint id)
        {
            bool isActive = false;
            uint _id = 0;
            _id = ItemManager.Instance.OpenSoulList.Find(delegate (uint findId) { return findId == id; });
            if (_id != 0)
                isActive = true;
            return isActive;
        }
        /// <summary>
        /// 是否该武魂获得过
        /// </summary>
        /// <param name="gid"></param>
        /// <returns></returns>
        public static bool IsSoulHave(uint gid)
        {
            bool isHave = false;
            uint _gid = 0;
            _gid = ItemManager.Instance.GetSoulList.Find(delegate (uint findId) { return findId == gid; });
            if (_gid != 0)
                isHave = true;
            return isHave;
        }
        /// <summary>
        /// 获得图鉴中武魂列表
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public static List<Goods> GetSoulBookSoulList(uint id)
        {
            List<Goods> list = new List<Goods>();
            List<string> data_soul_book = DBManager.Instance.QuerySqliteField<string>(GlobalConfig.DBFile, "data_soul_book", "id", id.ToString(), "soul_list");
            if (data_soul_book.Count > 0)
            {
                var soul_list = data_soul_book[0];
                soul_list = soul_list.Replace("[", "");
                soul_list = soul_list.Replace("]", "");
                var strSplit = soul_list.Split(',');
                for (int i = 0; i < strSplit.Length; i++)
                {
                    var goodsId = uint.Parse(strSplit[i]);
                    Goods goods = GoodsFactory.Create(goodsId, null);
                    list.Add(goods);
                }
            }
            return list;
        }
        public static EGoodsQuality GetQualityByGid(uint gid)
        {
            return (EGoodsQuality)GetGoodsColorTypeByTypeId(gid);
        }
        public static Color GetGoodsQualityColor(Goods goods)
        {
            return GetGoodsColorByQua(goods.color_type);
        }
       
        /// <summary>
        /// 获取开个子的数量累加
        /// </summary>
        /// <param name="bag_type"></param>
        /// <param name="start_idx"></param>
        /// <param name="end_idx"></param>
        /// <returns></returns>
        public static Goods GetBagUnLockTotal(ushort bag_type, int start_idx, int end_idx)
        {
            string str = string.Empty;
            GoodsItem goods = null;
            switch (bag_type)
            {
                case GameConst.BAG_TYPE_NORMAL:
                    str = "BAG_TYPE_NORMAL";
                    break;
                case GameConst.BAG_TYPE_WARE:
                    str = "BAG_TYPE_WARE";
                    break;
            }
            for (int i = start_idx; i <= end_idx; i++)
            {
                string key = string.Format("{0}_{1}", i, str);
                List<string> data_open_cell = DBManager.Instance.QuerySqliteField<string>(GlobalConfig.DBFile, "data_open_cell", "csv_id", key, "cost_goods");
                if (data_open_cell.Count > 0)
                {
                    string raw = data_open_cell[0];
                    raw = raw.Replace(" ", "");
                    var matchs = TextHelper.ParseBraceContent(raw, true);
                    foreach (var _match in matchs)
                    {
                        uint goodsid = (DBTextResource.ParseUI(_match[0]));
                        uint num = DBTextResource.ParseUI(_match[1]);
                        if (goods == null)
                        {
                            goods = new GoodsItem(goodsid);
                            goods.num = num;
                        }
                        else
                        {
                            goods.num += num;
                        }
                    }
                    SGameEngine.Pool<List<string>>.List.Free(matchs);
                }
            }
            
            return goods;
        }

        public static bool CheckUseGoodsIsInCD(uint goodsId)
        {
            uint startTime = 0;
            uint cd_id = GoodsHelper.GetGoodsCDId(goodsId);
            if (ItemManager.Instance.GoodsCd.TryGetValue(cd_id, out startTime))
            {
                uint cd = 10;
                var goods_info = GoodsHelper.GetGoodsInfo(goodsId);
                if (goods_info != null)
                    cd = goods_info.use_cd;

                uint endTime = startTime + cd;
                if (endTime != 0)
                {
                    uint serverTime = Game.GetInstance().ServerTime;
                    if (endTime > serverTime)
                    {
                        return true;
                    }
                }
            }

            return false;
        }

        public static bool CheckCanUseByVocation(uint goods_use_job, uint player_vocation)
        {
            if (goods_use_job == 0 || goods_use_job == player_vocation)
            {
                return true;
            }
            return false;
        }

        /// <summary>
        /// 是否可以使用该物品
        /// </summary>
        /// <param name="goodsId"></param>
        /// <returns></returns>
        public static bool CheckGoodsCanUse(uint goodsId)
        {
            Dictionary<ulong, Goods> goodsList = ItemManager.Instance.GetGoodsListForBagByTypeId(goodsId);
            if (goodsList != null)
            {
                foreach (Goods goods in goodsList.Values)
                {
                    uint localPlayerLv = 0;
                    if (LocalPlayerManager.Instance.LocalActorAttribute != null)
                    {
                        localPlayerLv = LocalPlayerManager.Instance.LocalActorAttribute.Level;
                    }
                    if (goods.can_use == true && localPlayerLv >= goods.use_lv)
                    {
                        return true;
                    }
                }
            }

            return false;
        }

        public static uint GetGoodsCDId(uint typeId)
        {
            uint cd_id = 0;
            var goods_info = GoodsHelper.GetGoodsInfo(typeId);
            if (goods_info != null)
                cd_id = goods_info.cd_id;

            return cd_id;
        }

        public static Goods ParseClientGoodsStr(string str)
        {
            string[] str_array = str.Split(";".ToCharArray());
            Dictionary<string, string> param_dict = new Dictionary<string, string>();

            for(int index = 0; index < str_array.Length; ++index)
            {
                string one_str = str_array[index];
                var matchs = System.Text.RegularExpressions.Regex.Matches(one_str, @"(.+)=(.+)");
                foreach (System.Text.RegularExpressions.Match _match in matchs)
                {
                    if (_match.Success)
                    {
                        param_dict[_match.Groups[1].Value] = _match.Groups[2].Value;
                    }
                }
            }

            if (param_dict.ContainsKey("type_idx") == false)
            {
                GameDebug.LogRed("can't find type_idx in " + str);
                return null;
            }
            string type_idx_str = param_dict["type_idx"];
            uint type_idx = DBTextResource.ParseUI_s(type_idx_str, 0);
            Goods goods = GoodsHelper.CreateGoodsByTypeId(type_idx);
            if (goods == null)
            {
                GameDebug.LogRed("type_idx is error! str = " + str);
                return null;
            }
            goods.ParseClientGoodsStr_inner(param_dict);
            return goods;
        }

        public static string GetClientGoodsStr(Goods item)
        {
            System.Text.StringBuilder builder = new System.Text.StringBuilder();
            if (item != null)
                item.GetClientGoodsStr_inner(ref builder);
            return builder.ToString();
        }

        public static void ShowGoodsTips(Goods item, Net.PkgStrengthInfo pkgStrengthInfo = null, Net.PkgBaptizeInfo pkgBaptizeInfo = null, string showType = "Normal")
        {
            if (item == null)
                return;

            if (item is GoodsEquip)
            {
                bool isOtherPlayer = false;
                EquipPosInfo posInfo = Equip.EquipHelper.GetEquipPosInfoByPkgInfo(pkgStrengthInfo, pkgBaptizeInfo);
                if (posInfo != null)
                {
                    MainmapManager.Instance.SetOtherPlayerEquipPosInfo(posInfo);
                    MainmapManager.Instance.OtherPlayerEquipInfos.Clear();
                    MainmapManager.Instance.OtherPlayerEquipInfos.Add(item as GoodsEquip);
                    Equip.EquipHelper.CalculatorSuitNum(MainmapManager.Instance.OtherPlayerEquipInfos);
                    ClientEventMgr.Instance.FireEvent((int)ClientEvent.CE_CLICKPLAY_DISPLAY_INFO, new CEventEventParamArgs(null, MainmapManager.Instance.OtherPlayerEquipInfos, MainmapManager.Instance.OtherPlayerEquipPosInfos));
                    isOtherPlayer = true;
                }
                UIManager.Instance.ShowWindow("UIEquipmentTipsWindow", item, showType, null, null, null, isOtherPlayer);
            }
            else if (item is GoodsDecorate)
            {
                Decorate.DecorateHelper.ShowDecorateTipsWindow(item as GoodsDecorate, showType);
            }
            else if (item is GoodsGodEquip)
            {
                GodEquip.GodEquipHelper.ShowGodEquipTipsWindow(item as GoodsGodEquip, showType);
            }
            else if (item is GoodsMountEquip)
            {
                UIManager.Instance.ShowWindow("UIMountEquipGoodsTipsWindow", item, showType);
            }
            else if (item is GoodsWeddingRing)
            {
                UIManager.Instance.ShowWindow("UIWeddingRingGoodsTipsWindow", item, showType);
            }
            else if (item is GoodsLightWeaponSoul)
            {
                UIManager.Instance.ShowWindow("UILightWeaponSoulTipsWindow", item as GoodsLightWeaponSoul, showType);
            }
            else if (item is GoodsMagicEquip)
            {
                Magic.MagicEquipHelper.ShowMagicEquipTipsWindow(item as GoodsMagicEquip, showType);
            }
            else
            {
                string tipsWindow = GetGoodsTipsWindowByGoodsId(item.type_idx);
                if (!string.IsNullOrEmpty(tipsWindow))
                {
                    UIManager.Instance.ShowWindow(tipsWindow, item, showType);
                }
                else
                {
                    UIManager.Instance.ShowWindow("UIGoodsTipsWindow", item, showType);
                }
            }

        }

        public static uint GetLegendTopScoreByGroupId(uint group_id,uint line_num)
        {
            List<EquipAttrData> list_attr = DBManager.GetInstance().GetDB<DBEquipAttr>().GetAttrDataByGroupId(group_id);
            if (list_attr == null)
                return 0;
            list_attr.Sort((a, b) =>
            {
                uint scoreA = a.GetDefaultScore();
                uint scoreB = b.GetDefaultScore();
                if (scoreA > scoreB)
                    return -1;
                else if (scoreA < scoreB)
                    return 1;
                return 0;
            });
            uint score = 0;
            uint list_len = (uint)list_attr.Count;
            for (int i = 0; i < line_num; i++)
            {
                if(i < list_len)
                    score += list_attr[i].GetDefaultScore();
            }
            return score;
        }

        /// <summary>
        /// 获取物品显示用的属性
        /// </summary>
        /// <param name="gid"></param>
        /// <returns></returns>
        public static ActorAttribute GetGoodsShowAttr(uint gid)
        {
            return DBGoodsShowAttrs.Instance.GetGoodsShowAttr(gid);
        }

        /// <summary>
        /// 获取物品的显示用的战力提升
        /// </summary>
        /// <param name="gid"></param>
        /// <returns></returns>
        public static ulong GetGoodsShowBattlePower(uint gid)
        {
            ActorAttribute attr = DBGoodsShowAttrs.Instance.GetGoodsShowAttr(gid);

            return DBBattlePower.CalBattlePowerByAttrs(attr);
        }

        /// <summary>
        /// 获取指定背包类型的物品是否有快捷使用
        /// </summary>
        /// <param name="bagType"></param>
        /// <returns></returns>
        public static bool GetGoodsCanShortcutUseByBagType(uint bagType)
        {
            var dataBag = DBManager.Instance.QuerySqliteRow<string>(GlobalConfig.DBFile, "data_bag", "id", bagType.ToString());
            if (dataBag != null && dataBag.Count > 0)
            {
                Dictionary<string, string> table = dataBag[0];
                string raw = string.Empty;
                if (table.TryGetValue("shortcut_use", out raw))
                {
                    if (raw.Equals("") == true || raw.Equals("0") == true)
                    {
                        return false;
                    }
                    else
                    {
                        return true;
                    }
                }
            }

            return false;
        }

        /// <summary>
        /// 获取指定背包类型的物品是否有获得提示
        /// </summary>
        /// <param name="bagType"></param>
        /// <returns></returns>
        public static bool GetGoodsHaveGetTipsByBagType(uint bagType)
        {
            var dataBag = DBManager.Instance.QuerySqliteRow<string>(GlobalConfig.DBFile, "data_bag", "id", bagType.ToString());
            if (dataBag != null && dataBag.Count > 0)
            {
                Dictionary<string, string> table = dataBag[0];
                string raw = string.Empty;
                if (table.TryGetValue("have_get_tips", out raw))
                {
                    if (raw.Equals("") == true || raw.Equals("0") == true)
                    {
                        return false;
                    }
                    else
                    {
                        return true;
                    }
                }
            }

            return false;
        }

        /// <summary>
        /// 根据物品id返回对应的物品对象的lua脚本
        /// </summary>
        /// <param name="goodsId"></param>
        /// <returns></returns>
        public static string GetGoodsLuaScriptByGoodsId(uint goodsId)
        {
            uint type = GetGoodsType(goodsId);
            uint subType = GetGoodsSubType(goodsId);
            var dbs = DBManager.Instance.QuerySqliteRow<string>(GlobalConfig.DBFile, "data_goods_lua_script", "type", type + "_" + subType);
            if (dbs != null && dbs.Count > 0)
            {
                Dictionary<string, string> table = dbs[0];
                string raw = string.Empty;
                if (table.TryGetValue("lua_script", out raw))
                {
                    return raw;
                }
            }

            return "";
        }

        /// <summary>
        /// 根据物品id返回对应的tips界面
        /// </summary>
        /// <param name="goodsId"></param>
        /// <returns></returns>
        public static string GetGoodsTipsWindowByGoodsId(uint goodsId)
        {
            uint type = GetGoodsType(goodsId);
            uint subType = GetGoodsSubType(goodsId);
            var dbs = DBManager.Instance.QuerySqliteRow<string>(GlobalConfig.DBFile, "data_goods_lua_script", "type", type + "_" + subType);
            if (dbs != null && dbs.Count > 0)
            {
                Dictionary<string, string> table = dbs[0];
                string raw = string.Empty;
                if (table.TryGetValue("tips_window_name", out raw))
                {
                    return raw;
                }
            }

            return "";
        }

        /// <summary>
        /// 根据物品id返回对应的背包类型
        /// </summary>
        /// <param name="goodsId"></param>
        /// <returns></returns>
        public static uint GetGoodsBagTypeByGoodsId(uint goodsId)
        {
            uint type = GetGoodsType(goodsId);
            uint subType = GetGoodsSubType(goodsId);
            var dbs = DBManager.Instance.QuerySqliteRow<string>(GlobalConfig.DBFile, "data_goods_lua_script", "type", type + "_" + subType);
            if (dbs != null && dbs.Count > 0)
            {
                Dictionary<string, string> table = dbs[0];
                string raw = string.Empty;
                if (table.TryGetValue("bag_type", out raw))
                {
                    uint bagType = GameConst.BAG_TYPE_NORMAL;
                    if (uint.TryParse(raw, out bagType))
                    {
                        return bagType;
                    }
                }
            }
            return GameConst.BAG_TYPE_NORMAL;
        }
    }
}


