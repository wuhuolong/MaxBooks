

/*----------------------------------------------------------------
// 文件名： DBMallType.cs
// 文件功能描述： 商城类型表
//----------------------------------------------------------------*/
using UnityEngine;
using System.Collections.Generic;
using Mono.Data.Sqlite;

namespace xc
{
    public class DBMallType : DBSqliteTableResource
    {
        public const uint MallType_WeekLimit = 1;  //每周限购
        public const uint GrowUp = 3; //成长变强
        public const uint Common = 2; //常用道具
        public const uint BindGoldShop = 5;   //绑钻商城
        public const uint Score = 6;  //积分商店
        public const uint BagShop = 10;  //随身商店
        public const uint InvisibilityShop = 11;  //隐形商店
        public const uint TitleTaskMoneyShop = 14;  //头衔任务积分商店
        public const uint EquipExchange = 16;  //装备兑换
        public const uint SoulExchange = 17;  //武魂兑换
        public const uint Equip = 18;  //装备商城
        public const uint Marry = 19;  //情缘商店
        public const uint Active = 20;  //活跃商店

        public class DBMallTypeItem
        {
            public uint Id;             // id
            public string Name;         //名字
            public string TapBkg;   //装饰图片
            public string BottomDesc;   //底部文字
        }
        Dictionary<uint, DBMallTypeItem> mInfos = new Dictionary<uint, DBMallTypeItem>();
        public DBMallType(string strName, string strPath)
            : base(strName, strPath)
        {
        }

        public override void Unload()
        {
            base.Unload();
            mInfos.Clear();
           
        }

        protected override void ParseData(SqliteDataReader reader)
        {
            mInfos.Clear();

            DBMallTypeItem info;
            if (reader != null)
            {
                if (reader.HasRows == true)
                {
                    while (reader.Read())
                    {
                        info = new DBMallTypeItem();

                        info.Id = DBTextResource.ParseUI_s(GetReaderString(reader, "id"), 0);
                        info.Name = GetReaderString(reader, "name");
                        info.TapBkg = GetReaderString(reader, "tap_bkg");
                        info.BottomDesc = GetReaderString(reader, "bottom_desc");
                        mInfos.Add(info.Id, info);
                    }
                }
            }
        }

        public DBMallTypeItem GetOneItem(uint mall_type)
        {
            DBMallTypeItem info;
            if (mInfos.TryGetValue(mall_type, out info))
            {
                return info;
            }
            GameDebug.LogError("[GetOneItem] Can not get info by id: " + mall_type);
            return null;
        }
    }
}
