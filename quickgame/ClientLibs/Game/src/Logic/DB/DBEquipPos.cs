
/*----------------------------------------------------------------
// 文件名： DBEquipPos.cs
// 文件功能描述： 玩家身上的装备位置配置表
//----------------------------------------------------------------*/
using UnityEngine;
using System.Collections.Generic;
using Mono.Data.Sqlite;

namespace xc
{
    public class DBEquipPos : DBSqliteTableResource
    {
        public enum EquipPosType
        {
            None = 0,   //空
            Normal = 1, //普通装备
            Wing = 2,   //翅膀
        }
        public class DBEquipPosItem
        {
            public uint PosId;
            public string Name;
            public EquipPosType PosType;
            public bool CanStrength;    //能否强化
            public bool CanBaptize;     //能否洗练
            public bool CanInlay;       //能否镶嵌宝石
            public bool CanSuit;        //能否锻造套装
            public bool CanCastSoul;    //能否铸魂
            public uint SortId;
            public uint CanBaptizeLv;       //可洗练需要的等级
            public bool CanAutoRecycle; //是否自动回收
            public bool CanEngrave; //能否镶嵌铭刻
            public string EngraveAtrrsDesc; //铭刻可获得属性描述
            public List<uint> EngraveShowAttrIds; //铭刻展示属性ids
        }
        
        public Dictionary<uint, DBEquipPosItem> mInfos = new Dictionary<uint, DBEquipPosItem>();
        public DBEquipPos(string strName, string strPath)
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


            DBEquipPosItem info;
            if (reader != null)
            {
                if (reader.HasRows == true)
                {
                    while (reader.Read())
                    {
                        info = new DBEquipPosItem();

                        info.PosId = DBTextResource.ParseUI_s(GetReaderString(reader, "pos"), 0);
                        info.Name = GetReaderString(reader, "name");
                        info.PosType = (EquipPosType)DBTextResource.ParseUI_s(GetReaderString(reader, "type"), 0);
                        info.CanStrength = DBTextResource.ParseUI_s(GetReaderString(reader, "can_strength"), 0) == 1;    //能否强化
                        info.CanBaptize = DBTextResource.ParseUI_s(GetReaderString(reader, "can_baptize"), 0) == 1;     //能否洗练
                        info.CanInlay = DBTextResource.ParseUI_s(GetReaderString(reader, "can_inlay"), 0) == 1;       //能否镶嵌宝石
                        info.CanSuit = DBTextResource.ParseUI_s(GetReaderString(reader, "can_suit"), 0) == 1;        //能否锻造套装
                        info.CanCastSoul = DBTextResource.ParseUI_s(GetReaderString(reader, "can_cast_soul"), 0) == 1;  //能否铸魂
                        info.SortId = DBTextResource.ParseUI_s(GetReaderString(reader, "sort_id"), 0);
                        info.CanBaptizeLv = DBTextResource.ParseUI_s(GetReaderString(reader, "can_baptize_lv"), 0);       //可洗练需要的等级
                        info.CanAutoRecycle = DBTextResource.ParseUI_s(GetReaderString(reader, "can_auto_recycle"), 0) == 1;       //能否自动置入回收

                        info.CanEngrave = DBTextResource.ParseUI_s(GetReaderString(reader, "can_engrave"), 0) == 1;       //能否镶嵌铭刻
                        info.EngraveAtrrsDesc = GetReaderString(reader, "engrave_attrs_desc");
                        info.EngraveShowAttrIds = DBTextResource.ParseArrayUint(GetReaderString(reader, "engrave_show_attrs"));

                        mInfos[info.PosId] = info;
                    }
                }
            }
        }

        /// <summary>
        /// 获取一个部位信息
        /// </summary>
        /// <param name="posId"></param>
        /// <returns></returns>
        public DBEquipPosItem GetOneInfo(uint posId)
        {
            DBEquipPosItem info;
            if (mInfos.TryGetValue(posId, out info))
            {
                return info;
            }
            return null;
        }

        /// <summary>
        /// 获取所有部位信息
        /// </summary>
        public Dictionary<uint, DBEquipPosItem> AllEquipPosInfos
        {
            get
            {
                return mInfos;
            }
        }
    }
}
