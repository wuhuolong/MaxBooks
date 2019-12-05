using UnityEngine;
using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using Mono.Data.Sqlite;

namespace xc
{
    [wxb.Hotfix]
    public class DBNotice : DBSqliteTableResource
    {
        public enum EFillType
        {
            ORDINARY = 0,
            PLAYER_NAME = 1,
            PLAYER_ID = 2,
            GOODS_NAME = 3,
            GOODS_GID = 4,
            MONSTER_NAME = 5,
            INSTANCE_NAME = 6,
            ACTIVITY_SCENE_NAME = 7,
            COLOR_TYPE = 11, //品质颜色
            CHAT_GOODS_TYPELINK = 12,   //物品超链接标识，物品的oid
            CLIENT_GOODS_TYPELINK = 13,   //客户端物品超链接，物品的属性串
            HIDE_PLAYER_ID = 14,   //隐藏的玩家uuid
            GOODS_GID_NEW = 15, // 物品gid，用来显示物品基础信息
            PET_ID = 18,        //守护ID
            TITLE_ID = 19,      //头衔ID
            QUAL_WORD = 20,      //品质名字
            TRANSFER_LV = 21,      //转职初始职业
            InitVocation = 22,      //转职等级
            
            SHOW_TYPE_TO_NAME = 23, //外显系统ID =>外显系统名字
            SHOW_TYPE_TO_PARAM = 24,        //外显系统ID => 与25一起使用，组成外显系统的外观名字
            SHOW_TYPE_TO_FACADE_ID = 25,
            SHOW_TYPE_TO_SYS_ID = 26,   //外显系统ID =>外显系统ID

            FASHION_NAME = 27,   //带品质颜色的时装名字
            MALL_NAME = 28, //商城名字
            ESCORT_TASK_ID = 29, //护送任务的id
            INSTANCE_ID = 30,    //副本id

                    
            GODWARE_ID = 31, //神器id
            TIMEFORMAT = 32,//时间格式
            BIG_PACKET = 33,//大红包
            SMALL_PACKET = 34,//小红包
            MARKET_ID = 35, // 市场OID

            CONTROL_ID = 77,    // 
            CHANNEL_ID = 78,    // 渠道ID
        }

        [wxb.Hotfix]
        public class Notice
        {
            public uint Id;
            public string Template;
            public string RichTemplate;
            public uint Limited;
            public uint Interval;
            public uint MinLv;
            public uint MaxLv;
            public bool PlayInWorldChannel
            {
                get
                {
                    return ShowChannels.Contains(1);
                }
            }

            public bool PlayInGuildChannel
            {
                get
                {
                    return ShowChannels.Contains(2);
                }
            }

            public bool PlayInTeamChannel
            {
                get
                {
                    return ShowChannels.Contains(3);
                }
            }

            public bool PlayInCurChannel
            {
                get
                {
                    return ShowChannels.Contains(4);
                }
            }

            public bool PlayInSystemChannel
            {
                get
                {
                    return ShowChannels.Contains(5);
                }
            }

            public bool PlayInPrivateChannel //私聊
            {
                get
                {
                    return ShowChannels.Contains(6);
                }
            }

            public bool PlayInBottomMsg //底部弹窗
            {
                get
                {
                    return ShowChannels.Contains(7);
                }
            }

            public bool PlayInRollingNotice //跑马灯
            {
                get
                {
                    return ShowChannels.Contains(8);
                }
            }

            public bool PlayInDanmaku //弹幕
            {
                get
                {
                    return ShowChannels.Contains(9);
                }
            }

            public bool PlayInSpanChannel // 跨服
            {
                get
                {
                    return ShowChannels.Contains(10);
                }
            }

            // 喇叭
            public bool PlayInTrumpet { get { return ShowChannels.Contains(11); } }

            public List<uint> ShowChannels;

            public string GetContent(string[] param_list)
            {
                return DBNotice.FillTemplateByContentList(Template, param_list);
            }
        }

        private Dictionary<uint, Notice> mNoticeDict;
        
        public DBNotice(string strName, string strPath)
            : base(strName, strPath)
        {
            mNoticeDict = new Dictionary<uint, Notice>();
        }

        public override void Load()
        {
            IsLoaded = true;
        }

        public override void Unload()
        {
            base.Unload();
            mNoticeDict.Clear();
        }

        Notice GetItemInfo(uint id)
        {
            string query = string.Format("SELECT * FROM {0} WHERE {0}.{1}=\"{2}\"", mTableName, "id", id);
            var reader = DBManager.Instance.ExecuteSqliteQueryToReader(GlobalConfig.DBFile, mTableName, query);
            if (reader == null)
            {
                mNoticeDict[id] = null;
                return null;
            }

            if (!reader.HasRows || !reader.Read())
            {
                mNoticeDict[id] = null;

                reader.Close();
                reader.Dispose();
                return null;
            }

            Notice notice = new Notice();
            notice.Id = id;
            notice.Template = GetReaderString(reader, "content");
            notice.ShowChannels = DBTextResource.ParseArrayUint(GetReaderString(reader, "channel"), ",");
            notice.MinLv = DBTextResource.ParseUI_s(GetReaderString(reader, "min_lv"), 0);
            notice.MaxLv = DBTextResource.ParseUI_s(GetReaderString(reader, "max_lv"), 0);

            mNoticeDict.Add(notice.Id, notice);

            reader.Close();
            reader.Dispose();
            return notice;
        }

        // API
        public Notice GetNoticeById(uint noticeId)
        {
            Notice info = null;
            if (!mNoticeDict.TryGetValue(noticeId, out info))
            {
                info = GetItemInfo(noticeId);
            }

            return info;
        }

        static Regex mNoticeRegex = new Regex(@"\{[0-9]*?\}");

        public static string FillTemplateByContentList(string template, string[] param_list)
        {
            if (param_list.Length <= 0)
            {
                return template;
            }
            if (string.IsNullOrEmpty(template))
            {
                return string.Empty;
            }

            int index = 0;

            return mNoticeRegex.Replace(template, new MatchEvaluator(
                delegate(Match match)
            {
                string ret = string.Empty;
                if (index >= param_list.Length)
                {
                    return ret;
                }

                string content = param_list [index];
                string target = match.ToString();
                if (target.Length >= 3)
                {
                    target = target.Substring(1, target.Length - 2);
                    EFillType contentType = (EFillType)(int.Parse(target));
                    uint contentNum = 0xffffffff;
                    try
                    {
                        contentNum = Convert.ToUInt32(content);
                    } catch
                    {
                        // Do nothing.
                    }

                    switch (contentType)
                    {
                        // 怪物名字是后端未经过翻译就发过来的，要翻译一下
                        case EFillType.MONSTER_NAME:
                            ret = xc.TextHelper.GetTranslateText(content);
                            break;

                        // 玩法场景名字是后端未经过翻译就发过来的，要翻译一下
                        case EFillType.ACTIVITY_SCENE_NAME:
                            ret = xc.TextHelper.GetTranslateText(content);
                            break;

                        case EFillType.COLOR_TYPE:
                            ret = GoodsHelper.GetGoodsColor(contentNum);
                            break;

                        case EFillType.CHAT_GOODS_TYPELINK:     // 物品超链接
                            {
                                if(param_list.Length >= 3)
                                {
                                    uint playerId = Convert.ToUInt32(param_list[index - 2]);
                                    uint goods_gid = Convert.ToUInt32(param_list[index - 1]);
                                    ulong goods_oid = Convert.ToUInt64(content);

                                    uint color_type = GoodsHelper.GetGoodsColorTypeByTypeId(goods_gid);
                                    string color_str = GoodsHelper.GetGoodsColor(color_type);
                                    string goods_name = GoodsHelper.GetGoodsOriginalNameByTypeId(goods_gid);

                                    uint goodsType = GoodsHelper.GetGoodsType(goods_gid);
                                    if (goodsType == GameConst.GIVE_TYPE_EQUIP          // 装备
                                    || goodsType == GameConst.GIVE_TYPE_RIDE_EQUIP      // 坐骑装备
                                    || goodsType == GameConst.GIVE_TYPE_MAGIC_EQUIP     // 法宝装备
                                    || goodsType == GameConst.GIVE_TYPE_DECORATE     // 饰品 
                                    || goodsType == GameConst.GIVE_TYPE_ELEMENT_EP    // 元素装备
                                    || goodsType == GameConst.GIVE_TYPE_GOD_EQUIP    // 神兵
                                    || goodsType == GameConst.GIVE_TYPE_ARTIFACT_EP    // 神器装备
                                    || goodsType == GameConst.GIVE_TYPE_FIVE_ELEM)    // 五行战印 
            {
                                        ret = string.Format(xc.TextHelper.GetConstText("CODE_TEXT_LOCALIZATION_20"), color_str, goods_name);
                                        ret = ret + "{" + playerId + "," + goods_oid +","+ goods_gid + "})";
                                    }
                                    else
                                    {
                                        ret = string.Format(xc.TextHelper.GetConstText("CODE_TEXT_LOCALIZATION_21"), color_str, goods_name);
                                        ret = ret + "{" + playerId + "," + goods_gid + "})";
                                    }

                               }
                                else
                                    ret = content;
                            }
                            break;
                        case EFillType.CLIENT_GOODS_TYPELINK:   // 客户端物品超链接
                            {
                                
                                uint goods_gid = Convert.ToUInt32(param_list[index - 1]);
                                uint goods_oid = contentNum;

                                uint color_type = GoodsHelper.GetGoodsColorTypeByTypeId(goods_gid);
                                string color_str = GoodsHelper.GetGoodsColor(color_type);
                                string goods_name = GoodsHelper.GetGoodsOriginalNameByTypeId(goods_gid);
                                ret = string.Format(xc.TextHelper.GetConstText("CODE_TEXT_LOCALIZATION_22"), color_str, goods_name);
                                ret = ret + "{" + content + "})";
                            }
                            break;
                        case EFillType.GOODS_GID:
                            ret = string.Empty;
                            break;
                        case EFillType.HIDE_PLAYER_ID:
                            ret = string.Empty;
                            break;
                        case EFillType.GOODS_GID_NEW:
                            {
                                if (param_list.Length >= 2)
                                {
                                    uint playerId = Convert.ToUInt32(param_list[index - 1]);
                                    uint goods_gid = Convert.ToUInt32(param_list[index]);

                                    uint color_type = GoodsHelper.GetGoodsColorTypeByTypeId(goods_gid);
                                    string color_str = GoodsHelper.GetGoodsColor(color_type);
                                    string goods_name = GoodsHelper.GetGoodsOriginalNameByTypeId(goods_gid);
                                    ret = string.Format(xc.TextHelper.GetConstText("CODE_TEXT_LOCALIZATION_21"), color_str, goods_name);
                                    ret = ret + "{" + playerId + "," + goods_gid + "})";
                                }
                                else
                                    ret = content;

                                break;
                            }
                        case EFillType.PET_ID: // 守护ID（显示带守护品质颜色的守护名字）
                            {
                                uint pet_id = Convert.ToUInt32(content);
                                var pet_info = DBManager.Instance.GetDB<DBPet>().GetOnePetInfo(pet_id);
                                if (pet_info != null)
                                {
                                    string color_str = GoodsHelper.GetGoodsColor(pet_info.Quality + 1);//守护品质颜色和物品相差1
                                    string actor_name = ActorHelper.GetActorName(pet_info.Actor_id);
                                    ret = string.Format("{0}{1}</color>", color_str, actor_name);
                                }
                                else
                                    ret = content;
                            }
                            break;
                        case EFillType.TITLE_ID:
                            {
                                uint title_id = Convert.ToUInt32(content);
                                var title_info = DBManager.Instance.GetDB<DBHonor>().GetData(title_id);
                                if (title_info != null)
                                {
                                    string color_str = GoodsHelper.GetGoodsColor(title_info.Quality);
                                    string title_name = title_info.Name;
                                    ret = string.Format("{0}{1}</color>", color_str, title_name);
                                }
                                else
                                    ret = content;
                            }
                            break;
                        case EFillType.QUAL_WORD:
                            {
                                uint qual = Convert.ToUInt32(content);
                                string color_str_name = GoodsHelper.GetGoodsColorName(qual);
                                string color_str = GoodsHelper.GetGoodsColor(qual);
                                ret = string.Format("{0}{1}</color>", color_str, color_str_name);
                            }
                            break;
                        case EFillType.TRANSFER_LV:
                            {
                                if (param_list.Length >= 2)
                                {
                                    uint init_vocation = Convert.ToUInt32(param_list[index]);
                                    uint transfer_lv = Convert.ToUInt32(param_list[index - 1]);
                                    object[] param = { transfer_lv, init_vocation };
                                    System.Type[] returnType = { typeof(string) };
                                    object[] objs = LuaScriptMgr.Instance.CallLuaFunction_return(LuaScriptMgr.Instance.Lua.Global, "TransferMgr_GetVocationName", param, returnType);
                                    if (objs != null && objs.Length > 0 && objs[0] != null)
                                    {
                                        ret = (string)objs[0];
                                    }
                                    else
                                        ret = content;
                                }
                                else
                                    ret = content;
                            }
                            break;
                        case EFillType.InitVocation:
                            ret = string.Empty;
                            break;
                        case EFillType.SHOW_TYPE_TO_NAME: //外显系统ID =>外显系统名字
                            {
                                uint show_type = Convert.ToUInt32(param_list[index]);
                                object[] param = { show_type };
                                System.Type[] returnType = { typeof(string) };
                                object[] objs = LuaScriptMgr.Instance.CallLuaFunction_return(LuaScriptMgr.Instance.Lua.Global, "ShowManager_GetShowName", param, returnType);
                                if (objs != null && objs.Length > 0 && objs[0] != null)
                                {
                                    ret = (string)objs[0];
                                }
                                else
                                    ret = content;
                            }
                            break;
                        case EFillType.SHOW_TYPE_TO_PARAM://外显系统ID => 与25一起使用，组成外显系统的外观名字
                            {
                                ret = string.Empty;
                            }
                            break;
                        case EFillType.SHOW_TYPE_TO_FACADE_ID:
                            {
                                if (param_list.Length >= 2)
                                {
                                    uint facade_id = Convert.ToUInt32(param_list[index]);
                                    uint show_type = Convert.ToUInt32(param_list[index - 1]);
                                    object[] param = { show_type, facade_id };
                                    System.Type[] returnType = { typeof(string) };
                                    object[] objs = LuaScriptMgr.Instance.CallLuaFunction_return(LuaScriptMgr.Instance.Lua.Global, "ShowManager_GetFacadeName", param, returnType);
                                    if (objs != null && objs.Length > 0 && objs[0] != null)
                                    {
                                        ret = (string)objs[0];
                                    }
                                    else
                                        ret = content;
                                }
                                else
                                    ret = content;
                            }
                            break;
                        case EFillType.SHOW_TYPE_TO_SYS_ID:   //外显系统ID =>外显系统ID
                            {
                                uint show_type = Convert.ToUInt32(param_list[index]);
                                object[] param = { show_type };
                                System.Type[] returnType = { typeof(string) };
                                object[] objs = LuaScriptMgr.Instance.CallLuaFunction_return(LuaScriptMgr.Instance.Lua.Global, "ShowManager_GetSysIdStr", param, returnType);
                                if (objs != null && objs.Length > 0 && objs[0] != null)
                                {
                                    ret = (string)objs[0];
                                }
                                else
                                    ret = content;
                            }
                            break;
                        case EFillType.FASHION_NAME:   //时装
                            {
                                uint fashionId = Convert.ToUInt32(param_list[index]);
                                object[] param = { fashionId };
                                System.Type[] returnType = { typeof(string) };
                                object[] objs = LuaScriptMgr.Instance.CallLuaFunction_return(LuaScriptMgr.Instance.Lua.Global, "FashionManager_GetFashionNameWithColor", param, returnType);
                                if (objs != null && objs.Length > 0 && objs[0] != null)
                                {
                                    ret = (string)objs[0];
                                }
                                else
                                    ret = content;
                            }
                            break;
                        case EFillType.MALL_NAME: //商城名字
                            {
                                uint mall_id = Convert.ToUInt32(param_list[index]);
                                var mall_tmpl = xc.DBManager.Instance.GetDB<DBMallType>().GetOneItem(mall_id);
                                if (mall_tmpl != null)
                                {
                                    //string color_str = GoodsHelper.GetGoodsColor(mall_tmpl);
                                    string tmall_name = mall_tmpl.Name;
                                    //ret = string.Format("{0}{1}</color>", color_str, tmall_name);
                                    ret = tmall_name;
                                }
                                else
                                    ret = content;
                            }
                            break;
                        case EFillType.ESCORT_TASK_ID: //护送任务的id
                            {
                                uint taskId = Convert.ToUInt32(param_list[index]);
                                TaskDefine taskDefine = TaskDefine.MakeDefine(taskId);
                                if (taskDefine != null)
                                {
                                    ret = taskDefine.GetFollowNpcName(0);
                                }
                                else
                                    ret = content;
                            }
                            break;
                        case EFillType.INSTANCE_ID: //副本id
                            {
                                uint instanceId = Convert.ToUInt32(param_list[index]);
                                DBInstance.InstanceInfo instanceInfo = DBInstance.Instance.GetInstanceInfo(instanceId);
                                if (instanceInfo != null)
                                {
                                    ret = instanceInfo.mName;
                                }
                                else
                                    ret = content;
                            }
                            break;

                        case EFillType.GODWARE_ID://神器id
                            {
                                uint god_ware_id = Convert.ToUInt32(param_list[index]);
                                object[] param = { god_ware_id };
                                System.Type[] returnType = { typeof(string) };
                                object[] objs = LuaScriptMgr.Instance.CallLuaFunction_return(LuaScriptMgr.Instance.Lua.Global, "GodWareManager_GetGodWareName", param, returnType);
                                if (objs != null && objs.Length > 0 && objs[0] != null)
                                {
                                    ret = (string)objs[0];
                                }
                                else
                                    ret = content;
                            }
                            break;
                        case EFillType.TIMEFORMAT:
                            int time = Convert.ToInt32(param_list[index]);
                            string strShowTime = CommonTool.SecondsToStr_2(time);
                            ret = strShowTime;
                            break;
                        case EFillType.BIG_PACKET:
                            uint bigNum = Convert.ToUInt32(param_list[index]);
                            if (bigNum != 0)
                                //ret = string.Format("{0}个大红包，", bigNum);
                                ret = string.Format(xc.DBConstText.GetText("RAIN_RED_PACKET_BIG"), bigNum);
                            else
                                ret = "";
                                break;
                        case EFillType.SMALL_PACKET:
                            uint smallNum = Convert.ToUInt32(param_list[index]);
                            if (smallNum != 0)
                                //ret = string.Format("{0}个小红包，", smallNum);
                                ret = string.Format(xc.DBConstText.GetText("RAIN_RED_PACKET_SMALL"), smallNum);
                            else
                                ret = "";
                            break;

                        case EFillType.MARKET_ID:
                            {

                                uint goods_gid = Convert.ToUInt32(param_list[index - 1]);
                                uint goods_oid = contentNum;

                                uint color_type = GoodsHelper.GetGoodsColorTypeByTypeId(goods_gid);
                                string color_str = GoodsHelper.GetGoodsColor(color_type);
                                string goods_name = GoodsHelper.GetGoodsOriginalNameByTypeId(goods_gid);

                                // 【click={0}[{1}]</color>】(marketGoodsTips=
                                ret = string.Format(xc.TextHelper.GetConstText("GAME_CHAT_CLICK_MARKET_GOODS"), color_str, goods_name);
                                ret = ret + "{" + content + "})";
                            }
                            break;

                        case EFillType.CONTROL_ID:
                            var id = Convert.ToInt32(param_list[index]);
                            ret = SpanServerManager.Instance.GetServerNameByControlServerId((uint)id);
                            break;

                        case EFillType.CHANNEL_ID:
                            ret = ChannelHelper.GetChannelName(param_list[index]);
                            break;

                        default:
                            ret = xc.TextHelper.GetTranslateText(content);
                            break;
                    }
                }

                index++;
                return ret;
            }
            ));
        }
    }
}

