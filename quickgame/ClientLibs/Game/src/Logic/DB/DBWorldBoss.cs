
using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using Mono.Data.Sqlite;

namespace xc
{
    public class DBWorldBoss : DBSqliteTableResource
    {
        public class DBWorldBossRewardItem
        {
            public uint goods_id;
            public uint goods_num;
            public string reward_type;
        }

        public const uint TAG_PK = 1;
        public const uint TAG_PEACE = 2;
        public class DBWorldBossItem
        {
            public uint Id; //对应特殊怪物表中的id
            public uint Rank;
            public uint Tag;    //标签
            //public List<DBTextResource.DBGoodsItem> ShowAward;
            public List<DBWorldBossRewardItem> ShowAward;
            public Vector3 ModelCameraOffset;
            public Vector3 DeathModelCenter;
            public Vector3 ModelCameraRotate;
            public Vector3 ModelDefaultAngle;
            public float DeathModelRadius;
            public uint ColorType;  //品质
            public uint Order;  //产出的阶数
            public List<DBWorldBossRewardItem> MustDropAwardArray;
        }

        private Dictionary<uint, DBWorldBossItem> data = new Dictionary<uint, DBWorldBossItem>();
        public List<DBWorldBossItem> m_sortData = new List<DBWorldBossItem>();

        public DBWorldBoss(string strName, string strPath) : base(strName, strPath)
        {

        }

        public DBWorldBossItem GetData(uint id)
        {
            DBWorldBossItem ad = null;
            data.TryGetValue(id, out ad);
            return ad;
        }

        protected override void ParseData(SqliteDataReader reader)
        {
            if (reader == null || !reader.HasRows)
            {
                return;
            }

            while (reader.Read())
            {
                DBWorldBossItem ad = new DBWorldBossItem();
                ad.Id = DBTextResource.ParseUI(GetReaderString(reader, "id"));
                ad.ShowAward = new List<DBWorldBoss.DBWorldBossRewardItem>();
                List<List<string>> award_str_array = DBTextResource.ParseArrayStringString(GetReaderString(reader, "show_award_new"));
                for(int gid_index = 0; gid_index < award_str_array.Count; ++gid_index)
                {
                    List<string> one_goods_array = award_str_array[gid_index];
                    if (one_goods_array.Count < 2)
                        continue;
                    uint goods_id = 0;
                    if (uint.TryParse(one_goods_array[0], out goods_id) == false)
                        continue;
                    uint goods_num = 0;
                    if (uint.TryParse(one_goods_array[1], out goods_num) == false)
                        continue;
                    string reward_type = "";
                    if (one_goods_array.Count > 2 && one_goods_array[2] != "" && one_goods_array[2] != "0")
                        reward_type = one_goods_array[2];
                    DBWorldBossRewardItem reward_item = new DBWorldBossRewardItem();
                    reward_item.goods_id = goods_id;
                    reward_item.goods_num = goods_num;
                    reward_item.reward_type = reward_type;
                    ad.ShowAward.Add(reward_item);
                }

                ad.MustDropAwardArray = new List<DBWorldBossRewardItem>();
                award_str_array = DBTextResource.ParseArrayStringString(GetReaderString(reader, "must_drop_award"));
                for (int gid_index = 0; gid_index < award_str_array.Count; ++gid_index)
                {
                    List<string> one_goods_array = award_str_array[gid_index];
                    if (one_goods_array.Count < 2)
                        continue;
                    uint goods_id = 0;
                    if (uint.TryParse(one_goods_array[0], out goods_id) == false)
                        continue;
                    uint goods_num = 0;
                    if (uint.TryParse(one_goods_array[1], out goods_num) == false)
                        continue;
                    string reward_type = "";
                    if (one_goods_array.Count > 2 && one_goods_array[2] != "" && one_goods_array[2] != "0")
                        reward_type = one_goods_array[2];
                    DBWorldBossRewardItem reward_item = new DBWorldBossRewardItem();
                    reward_item.goods_id = goods_id;
                    reward_item.goods_num = goods_num;
                    reward_item.reward_type = reward_type;
                    ad.MustDropAwardArray.Add(reward_item);
                }

                //ad.ShowAward = DBTextResource.ParseDBGoodsItem(GetReaderString(reader, "show_award"));
                ad.Tag = DBTextResource.ParseUI_s(GetReaderString(reader, "tag"), 0);
                ad.Rank = DBTextResource.ParseUI(GetReaderString(reader, "rank"));
                ad.ModelCameraOffset = DBTextResource.ParseVector3(GetReaderString(reader, "model_camera_offset"));
                ad.ModelCameraRotate = DBTextResource.ParseVector3(GetReaderString(reader, "model_camera_rotate"));
                ad.ModelDefaultAngle = DBTextResource.ParseVector3(GetReaderString(reader, "model_default_angle"));
                ad.DeathModelCenter = DBTextResource.ParseVector3(GetReaderString(reader, "death_model_center"));
                ad.DeathModelRadius = DBTextResource.ParseF(GetReaderString(reader, "death_model_radius"));
                ad.ColorType = DBTextResource.ParseUI_s(GetReaderString(reader, "color_type"), 0);
                ad.Order = DBTextResource.ParseUI_s(GetReaderString(reader, "order"), 0);
                data.Add(ad.Id, ad);
                m_sortData.Add(ad);
            }
            m_sortData.Sort((a, b) =>
            {
                if (a.Rank < b.Rank)
                    return -1;
                else if (a.Rank > b.Rank)
                    return 1;
                return 0;
            });
        }

        public override void Unload()
        {
            data.Clear();
        }
    }
}


