using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using Mono.Data.Sqlite;

namespace xc
{
    /// <summary>
    /// 装备属性类型
    /// </summary>
    public enum EEquipAttrType : ushort
    {
        InvalidAttr = 0,

        /// <summary>
        /// 基础属性
        /// </summary>
        NormalAttr = 101,

        /// <summary>
        /// 多个属性加成一个值
        /// </summary>
        MultiAttrOneValue = 102,

        /// <summary>
        /// 
        /// </summary>
        NormalAttrEx = 103,

        /// <summary>
        /// 加成其他属性的属性
        /// </summary>
        AdditionAttr = 111,
        
        /// <summary>
        /// 技能加成
        /// </summary>
        SkillAdditive = 201,

        /// <summary>
        /// 技能
        /// </summary>
        BuffAdditive = 301,

        /// <summary>
        /// 监听类
        /// </summary>
        Listener = 401,

        /// <summary>
        /// 免疫效果
        /// </summary>
        Immune = 801,

        /// <summary>
        /// 无钻
        /// </summary>
        NoDiamond = 910, 

        /// <summary>
        /// 神赐
        /// </summary>
        God = 911, 

        /// <summary>
        /// 降低装备使用等级
        /// </summary>
        CutUseLv = 810, 


    }

    /// <summary>
    /// 装备属性数据
    /// </summary>
    public class EquipAttrData
    {
        /// <summary>
        /// 装备属性id
        /// </summary>
        public uint Id { get; private set; }

        public uint AttrId;
        public string ArgsStr; //参数
        public List<uint> Args; //参数

        /// <summary>
        /// 基础属性系数评分（动态需要value）
        /// </summary>
        public float BaseScoreG { get; private set; }

        /// <summary>
        /// 子属性id
        /// </summary>
        public uint SubAttrId { get; private set; }

        public List<ValueRange> ColorType = new List<ValueRange>();

        /// <summary>
        /// 子属性描述
        /// </summary>
        /// <value>The sub attr desc.</value>
        public string SubAttrDesc 
        {
            get
            {
                return DBManager.GetInstance().GetDB<DBEquipSubAttr>().GetSubAttrDesc(SubAttrId);
            }
        }

        //因为涉及到101这条基础属性 所有公式统一为 基础属性战力（value *g） + 固定特效属性
        public uint GetScore(List<uint> value)
        {
            var data =  DBManager.GetInstance().GetDB<DBEquipAttr>().GetAttrData(Id);
            uint score = 0;
            foreach(var val in value)
            {
                score += (uint)Mathf.CeilToInt(data.BaseScoreG * val);
            }
            return score;
        }


        public uint GetDefaultScore()
        {
            //用最大的属性值计算默认评分
            string temp = ArgsStr.Replace('[', '\0');
            temp = temp.Replace(']', '\0');
            temp = temp.Replace('{', '\0');
            temp = temp.Replace('}', '\0');
            List<uint> parseList = DBTextResource.ParseArrayUint(temp, ",", false);
            List<uint> attrValue = new List<uint>();
            attrValue.Add(parseList[parseList.Count - 1]);
            return GetScore(attrValue);
        }



        /// <summary>
        /// 非法的装备属性id
        /// </summary>
        public static readonly uint INVALID_EQUIP_ATTR_ID = 0;

        public static readonly List<uint> INVALID_COMMON_ID = new List<uint>();

        public static readonly List<uint> INVALID_COMMON_ARG = new List<uint>();

        public EquipAttrData(uint id,  uint sub_attr_id, float attr_pw_g , List<ValueRange> values)
        {
            Id = id;
            SubAttrId = sub_attr_id;
            BaseScoreG = attr_pw_g;
            ColorType = values;
        }
    }

    /// <summary>
    /// 装备属性表
    /// </summary>
    public class DBEquipAttr : DBSqliteTableResource
    {
        /// <summary>
        /// 装备属性信息列表
        /// </summary>
        public Dictionary<uint, EquipAttrData> EquipAttrDatas = new Dictionary<uint, EquipAttrData>();

        /// <summary>
        /// 装备组的属性信息列表
        /// </summary>
        public Dictionary<uint, List<EquipAttrData>> EquipGroup = new Dictionary<uint, List<EquipAttrData>>();

        public DBEquipAttr(string name, string path)
            : base(name, path)
        {}

        /// <summary>
        /// 根据装备id来获取装备属性
        /// </summary>
        /// <param name="attr_id"></param>
        /// <returns></returns>
        public EquipAttrData GetAttrData(uint attr_id)
        {
            EquipAttrData attr_data = null;
            if (EquipAttrDatas.TryGetValue(attr_id, out attr_data))
            {
                return attr_data;
            }

            string query_str = string.Format("SELECT * FROM {0} WHERE {0}.{1}={2}", mTableName, "id", attr_id);
            var reader = DBManager.Instance.ExecuteSqliteQueryToReader(GlobalConfig.DBFile, mTableName, query_str);
            if (reader == null)
            {
                EquipAttrDatas[attr_id] = null;
                return null;
            }

            if (!reader.HasRows || !reader.Read())
            {
                EquipAttrDatas[attr_id] = null;
                reader.Close();
                reader.Dispose();
                return null;
            }

            attr_data = ReadInfo(reader);
            EquipAttrDatas.Add(attr_data.Id, attr_data);

            reader.Close();
            reader.Dispose();

            return attr_data;
        }

        EquipAttrData ReadInfo(SqliteDataReader reader)
        {
            var id = GetReaderUint(reader, "id");
            var base_g = GetReaderFloat(reader, "val"); // DBTextResource.ParseUI(GetReaderString(reader, "val"),0.0f);

            var sub_attr_id = DBTextResource.ParseUI(GetReaderString(reader, "sub_attr_id"));
            var attr_color_type = GetReaderString(reader, "attr_color_type");
            var matchs = Regex.Matches(attr_color_type, @"\{(\d+),(\d+)\}");
            List<ValueRange> attr_color_types = new List<ValueRange>();
            foreach (Match _match in matchs)
            {
                if (_match.Success)
                {
                    uint min = (DBTextResource.ParseUI(_match.Groups[1].Value));
                    uint max = DBTextResource.ParseUI(_match.Groups[2].Value);
                    ValueRange value = new ValueRange(min, max);
                    attr_color_types.Add(value);
                }
            }

            var attr_data = new EquipAttrData(id, sub_attr_id, base_g, attr_color_types);
            attr_data.AttrId = DBTextResource.ParseUI(GetReaderString(reader, "attr"));
            attr_data.ArgsStr = GetReaderString(reader, "args");
            attr_data.Args = DBTextResource.ParseArrayUint(attr_data.ArgsStr, ",");

            return attr_data;
        }

        /// <summary>
        /// 根据装备组的id来获取装备属性的列表
        /// </summary>
        /// <param name="group_id"></param>
        /// <returns></returns>
        public List<EquipAttrData> GetAttrDataByGroupId(uint group_id)
        {
            List<EquipAttrData> info_list = null;
            if (EquipGroup.TryGetValue(group_id, out info_list))
            {
                return info_list;
            }

            string query_str = string.Format("SELECT {0}.{1} FROM {0} WHERE {0}.{1} BETWEEN {2} AND {3}", mTableName, "id", group_id*100 + 1, group_id * 100 + 99);
            var reader = DBManager.Instance.ExecuteSqliteQueryToReader(GlobalConfig.DBFile, mTableName, query_str);
            if (reader == null)
            {
                EquipGroup[group_id] = null;
                return null;
            }

            if (!reader.HasRows)
            {
                EquipAttrDatas[group_id] = null;
                reader.Close();
                reader.Dispose();
                return null;
            }

            var id_list = new List<uint>();
            while (reader.Read())
            {
                var id = GetReaderUint(reader, "id");
                id_list.Add(id);
            }

            reader.Close();
            reader.Dispose();

            // 通过GetAttrData接口获取Info
            info_list = new List<EquipAttrData>();
            for (int i = 0; i < id_list.Count; ++i)
            {
                var id = id_list[i];
                info_list.Add(GetAttrData(id));
            }

            EquipGroup[group_id] = info_list;
            return info_list;
        }

        public override void Unload()
        {
            EquipAttrDatas.Clear();
            EquipGroup.Clear();

            base.Unload();
        }

        public override void Load()
        {
            IsLoaded = true;
        }
    }
}
