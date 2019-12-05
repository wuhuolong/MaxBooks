//------------------------------------------
// File : DBGoods.cs
// Desc: 物品表数据读取的辅助类
// Author: raorui
// Date: 2018.8.29
//------------------------------------------
using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using Mono.Data.Sqlite;

namespace xc
{
    public class DBGoods : DBSqliteTableResource
    {
        private static string GoodsTableName = "data_goods";

        static DBGoods mInstance;
        public static DBGoods Instance
        {
            get
            {
                if (mInstance == null)
                    mInstance = new DBGoods(GlobalConfig.DBFile, GoodsTableName);

                return mInstance;
            }
        }

        Dictionary<uint, GoodsInfo> mGoodsInfos = new Dictionary<uint, GoodsInfo>();

        public DBGoods(string strName, string strPath) : base(strName, strPath)
        {

        }

        public override void Load() // 不进行预加载
        {
            IsLoaded = true;
        }

        public GoodsInfo GetGoodsInfo(uint gid)
        {
            GoodsInfo goods_info = null;
            if (mGoodsInfos.TryGetValue(gid, out goods_info))
                return goods_info;

            string query = string.Format("SELECT * FROM {0} WHERE {0}.{1}=\"{2}\"", GoodsTableName, "gid", gid);
            var reader = DBManager.Instance.ExecuteSqliteQueryToReader(GlobalConfig.DBFile, GoodsTableName, query);
            if (reader == null)
            {
                GameDebug.LogError("Can not find goods info by gid " + gid + ", reader is null!!!");

                mGoodsInfos[gid] = null;
                return null;
            }

            if(!reader.HasRows || !reader.Read())
            {
                GameDebug.LogError("Can not find goods info by gid " + gid);

                mGoodsInfos[gid] = null;

                reader.Close();
                reader.Dispose();
                return null;
            }

            goods_info = new GoodsInfo();
            goods_info.name = GetReaderString(reader, "name");
            goods_info.sort_id = DBTextResource.ParseUI_s(GetReaderString(reader, "sort_id"), 0);
            goods_info.sort_top = DBTextResource.ParseUI_s(GetReaderString(reader, "sort_top"), 0);
            goods_info.type = DBTextResource.ParseBT_s(GetReaderString(reader, "type"), 0);
            goods_info.sub_type = DBTextResource.ParseUS_s(GetReaderString(reader, "sub_type"), 0);
            goods_info.color_type = DBTextResource.ParseBT_s(GetReaderString(reader, "color_type"), 0);
            goods_info.max_stack = DBTextResource.ParseUS_s(GetReaderString(reader, "max_stack"), 1);
            goods_info.effect = GetReaderString(reader, "effect");
            var arg = GetReaderString(reader, "arg");
            if (!string.IsNullOrEmpty(arg))
                goods_info.arg = arg.Replace(" ", "");
            else
                goods_info.arg = "";
            goods_info.client_use = DBTextResource.ParseBT_s(GetReaderString(reader, "client_use"), 0);
            goods_info.cd_id = DBTextResource.ParseUI_s(GetReaderString(reader, "cd_id"), 0);
            goods_info.use_cd = DBTextResource.ParseUS_s(GetReaderString(reader, "use_cd"), 0);
            goods_info.use_lv = DBTextResource.ParseUI_s(GetReaderString(reader, "use_lv"), 0);
            goods_info.use_job = DBTextResource.ParseBT_s(GetReaderString(reader, "use_job"), 0);
            goods_info.use_transfer = DBTextResource.ParseBT_s(GetReaderString(reader, "use_transfer"), 0);
            goods_info.need_count = DBTextResource.ParseBT_s(GetReaderString(reader, "need_count"), 0);
            goods_info.guild_wpoint = DBTextResource.ParseUI_s(GetReaderString(reader, "guild_wpoint"), 0);
            goods_info.sell_price = DBTextResource.ParseUI_s(GetReaderString(reader, "sell_price"), 0);
            goods_info.expire_time = DBTextResource.ParseUI_s(GetReaderString(reader, "expire_time"), 0);
            goods_info.mktype_1 = DBTextResource.ParseBT_s(GetReaderString(reader, "mktype_1"), 0);
            goods_info.mktype_2 = DBTextResource.ParseBT_s(GetReaderString(reader, "mktype_2"), 0);
            goods_info.bind = DBTextResource.ParseBT_s(GetReaderString(reader, "bind"), 1);
            goods_info.price_recommend = (uint)(GetReaderFloat(reader, "price_recommend"));
            goods_info.price_lower_limit = GetReaderFloat(reader, "price_lower_limit");
            goods_info.price_upper_limit = GetReaderFloat(reader, "price_upper_limit");
            goods_info.desc = GetReaderString(reader, "desc");
            goods_info.gain_text = GetReaderString(reader, "gain_text");
            goods_info.gain_from = GetReaderString(reader, "gain_from");
            goods_info.icon_id = DBTextResource.ParseUI_s(GetReaderString(reader, "icon_id"), 0);
            goods_info.is_show = DBTextResource.ParseBT_s(GetReaderString(reader, "is_show"), 0);
            goods_info.is_quick = DBTextResource.ParseBT_s(GetReaderString(reader, "is_quick"), 0);
            goods_info.is_confirmation = DBTextResource.ParseBT_s(GetReaderString(reader, "is_confirmation"), 0);
            goods_info.sys_id = DBTextResource.ParseUI_s(GetReaderString(reader, "sys_id"), 0);
            goods_info.is_mutil_use = DBTextResource.ParseBT_s(GetReaderString(reader, "is_mutil_use"), 0);
            goods_info.daily_use_limit = DBTextResource.ParseUS_s(GetReaderString(reader, "daily_use_limit"), 0);
            goods_info.is_display_goods = DBTextResource.ParseBT_s(GetReaderString(reader, "is_display_goods"), 0);
            goods_info.wing_exp = DBTextResource.ParseUI_s(GetReaderString(reader, "wing_exp"), 0);
            goods_info.show_step = DBTextResource.ParseUI_s(GetReaderString(reader, "show_step"), 0);
            goods_info.is_precious = DBTextResource.ParseUI_s(GetReaderString(reader, "is_precious"), 0);
            goods_info.discount = DBTextResource.ParseUI_s(GetReaderString(reader, "discount"), 0);
            goods_info.overdue_notice_time = DBTextResource.ParseUI_s(GetReaderString(reader, "overdue_notice_time"), 0);

            mGoodsInfos[gid] = goods_info;

            reader.Close();
            reader.Dispose();

            return goods_info;
        }
    }
}