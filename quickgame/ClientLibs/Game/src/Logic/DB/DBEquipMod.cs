using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using Mono.Data.Sqlite;
namespace xc
{
    /// <summary>
    /// 上下限
    /// </summary>
    public class ValueRange
    {
        /// <summary>
        /// 最小值
        /// </summary>
        public uint Min { get; private set; }

        /// <summary>
        /// 最大值
        /// </summary>
        public uint Max { get; private set; }

        /// <summary>
        /// 判断v是否在range之间
        /// </summary>
        /// <param name="v"></param>
        /// <returns></returns>
        public bool IsInRange(uint v)
        {
            return v >= Min && v < Max;
        }

        public static ValueRange FromString(string minstr, string maxstr)
        {
            var min = 0u;
            if (minstr == "infinity")
                min = uint.MaxValue;
            else
                uint.TryParse(minstr, out min);

            var max = 0u;
            if (maxstr == "infinity")
                max = uint.MaxValue;
            else
                uint.TryParse(maxstr, out max);

            return new ValueRange(min, max);
        }

        public ValueRange(uint min, uint max)
        {
            Min = min;
            Max = max;
        }

        public static ValueRange Default = new ValueRange(0, 0);
    }

    /// <summary>
    /// 装备底模数据
    /// </summary>
    public class EquipModData : System.IComparable
    {
        /// <summary>
        /// 是否为武器
        /// </summary>
        public bool IsWeapon
        {
            get { return this.Pos == GameConst.POS_WEAPON; }
        }
        /// <summary>
        /// 底模id
        /// </summary>
        public uint Id { get; private set; }

        /// <summary>
        /// 装备部位
        /// </summary>
        public uint Pos { get; private set; }
        /// 模型 id
        /// </summary>
        public uint ModelId { get; private set; }
        /// <summary>
        /// 传奇属性条数
        /// </summary>
        public uint LegendCount { get; private set; }
        /// <summary>
        /// 体质需求
        /// </summary>
        public uint NeedARCON { get; private set; }
        /// <summary>
        /// 力量需求
        /// </summary>
        public uint NeedARSTR { get; private set; }
        /// <summary>
        /// 敏捷需求
        /// </summary>
        public uint NeedARAGI { get; private set; }
        /// <summary>
        /// 智力需求
        /// </summary>
        public uint NeedARINT { get; private set; }
        /// <summary>
        /// 转职需求
        /// </summary>
        //public uint NeedTransfer { get; private set; }

        public uint LvStep { get; private set; }
        /// <summary>
        /// 装备最大可强化等级
        /// </summary>
        public uint StrengthMax { get; private set; }
        /// <summary>
        /// 套装id
        /// </summary>
        public uint SuitId { get; private set; }

        public uint PetExp { get; private set; }

        public uint DefaultStar { get; private set; }
        public string DefaultExtraDesc
        {
            get
            {
                if (mDefaultExtraDesc != null)
                {
                    if(string.IsNullOrEmpty(mDefaultExtraDescStr))
                    {
                        var str = string.Intern(System.Text.Encoding.UTF8.GetString(mDefaultExtraDesc));
                        mDefaultExtraDescStr = xc.TextHelper.GetTranslateText(str);
                    }
                    return mDefaultExtraDescStr;
                }
                else
                    return string.Empty;
            }
        }

        byte[] mDefaultExtraDesc = null;
        string mDefaultExtraDescStr = string.Empty;

        public bool CanIdentify { get; private set; }  //是否可以被鉴定（2018/5/21）


        public uint DefaultScore;

        public List<List<uint>> LegendAttrs;

        public EquipModData()
        {

        }

        public EquipModData(uint id, uint pos,   uint ar_con_need , uint ar_str_need , 
            uint ar_agi_need , uint ar_int_need ,/*uint transfer_need, */uint legend_attrs_num ,
            uint model , uint lv_step ,uint strength_max , uint suit_id, uint pet_exp, byte[] default_extra_desc, uint default_star, bool can_identify, uint default_score, List<List<uint>> legend_attrs)
        {
            Id = id;
            Pos = pos;
            NeedARCON = ar_con_need;
            NeedARSTR = ar_str_need;
            NeedARAGI = ar_agi_need;
            NeedARINT = ar_int_need;
            //NeedTransfer = transfer_need;
            LegendCount = legend_attrs_num;
            ModelId = model;
            LvStep = lv_step;
            StrengthMax = strength_max;
            SuitId = suit_id;
            PetExp = pet_exp;
            mDefaultExtraDesc = default_extra_desc;
            DefaultStar = default_star;
            CanIdentify = can_identify;
            DefaultScore = default_score;
            LegendAttrs = legend_attrs;
        }

        public int CompareTo(object targetObj)
        {
            //            EquipModData targetInfo = targetObj as EquipModData;

            //            List<Equip.EquipInfo> canUseEquip = Equip.EquipIllustrationManager.Instance.GetCanUseEquips(this.Id);
            //            List<Equip.EquipInfo> targetCanUseEquip = Equip.EquipIllustrationManager.Instance.GetCanUseEquips(targetInfo.Id);
            //
            //            if (canUseEquip.Count > 0 && targetCanUseEquip.Count == 0)
            //            {
            //                return -1;
            //            }
            //            else if(targetCanUseEquip.Count > 0 && canUseEquip.Count == 0)
            //            {
            //                return 1;
            //            }
            //
            //            if(targetInfo.Id > this.Id)
            //            {
            //                return -1;
            //            }
            //            else if(targetInfo.Id < this.Id)
            //            {
            //                return 1;
            //            }

            return 0;
        }
    }


    /// <summary>
    /// 装备底模表
    /// </summary>
    public class DBEquipMod : DBSqliteTableResource
    {
        public Dictionary<uint, EquipModData> EquipModDatas { get; private set; }

        public DBEquipMod(string name, string path)
            : base(name, path)
        {
            EquipModDatas = new Dictionary<uint, EquipModData>();
        }

        public EquipModData GetModData(uint eid)
        {
            EquipModData data = null;
            if (EquipModDatas.TryGetValue(eid, out data))
            {
                return data;
            }

            string query_str = string.Format("SELECT * FROM {0} WHERE {0}.{1}=\"{2}\"", mTableName, "gid", eid.ToString());
            var reader = DBManager.Instance.ExecuteSqliteQueryToReader(GlobalConfig.DBFile, mTableName, query_str);
            if (reader == null)
            {
                EquipModDatas[eid] = null;
                return null;
            }

            if (!reader.HasRows)
            {
                EquipModDatas[eid] = null;
                reader.Close();
                reader.Dispose();
                return null;
            }

            if (!reader.Read())
            {
                EquipModDatas[eid] = null;
                reader.Close();
                reader.Dispose();
                return null;
            }

            var id = DBTextResource.ParseUI(GetReaderString(reader, "gid"));
            var pos = DBTextResource.ParseUI(GetReaderString(reader, "pos"));
            var ar_con_need = DBTextResource.ParseUI(GetReaderString(reader, "ar_con_need"));
            var ar_str_need = DBTextResource.ParseUI(GetReaderString(reader, "ar_str_need"));
            var ar_agi_need = DBTextResource.ParseUI(GetReaderString(reader, "ar_agi_need"));
            var ar_int_need = DBTextResource.ParseUI(GetReaderString(reader, "ar_int_need"));
            //var transfer_need = DBTextResource.ParseUI(GetReaderString(reader, "transfer_need"));
            var legend_attrs_num = DBTextResource.ParseUI(GetReaderString(reader, "legend_attrs_num"));
            var model = DBTextResource.ParseUI(GetReaderString(reader, "model"));
            var lv_step = DBTextResource.ParseUI(GetReaderString(reader, "lv_step"));
            var strength_max = DBTextResource.ParseUI(GetReaderString(reader, "strength_limit"));
            var suit_id = DBTextResource.ParseUI(GetReaderString(reader, "suit_id"));
            var pet_exp = DBTextResource.ParseUI(GetReaderString(reader, "pet_exp"));
            var default_extra_desc = GetReaderBytes(reader, "default_extra_desc");
            var default_star = DBTextResource.ParseUI_s(GetReaderString(reader, "default_star"), 0);
            var can_identify = DBTextResource.ParseUI_s(GetReaderString(reader, "can_identify"), 0) == 1;
            var default_score = DBTextResource.ParseUI_s(GetReaderString(reader, "default_score"), 0);
            var legend_attrs = DBTextResource.ParseArrayUintUint(GetReaderString(reader, "legend_attrs"));
            var mod_data = new EquipModData(id, pos, ar_con_need, ar_str_need, ar_agi_need, ar_int_need, legend_attrs_num,
                model, lv_step, strength_max, suit_id, pet_exp, default_extra_desc, default_star, can_identify, default_score, legend_attrs);
            EquipModDatas.Add(mod_data.Id, mod_data);

            reader.Close();
            reader.Dispose();

            return mod_data;
        }

        public static DBEquipMod Instance
        {
            get
            {
                return DBManager.Instance.GetDB<DBEquipMod>();
            }
        }

        public override void Unload()
        {
            EquipModDatas.Clear();

            base.Unload();
        }

        public override void Load() // 不进行预加载
        {
            IsLoaded = true;
        }

        protected override void ParseData(SqliteDataReader reader)
        {
            EquipModDatas.Clear();
            //if (reader != null)
            //{
            //    if (reader.HasRows == true)
            //    {
            //        while (reader.Read())
            //        {
            //            var id = DBTextResource.ParseUI(GetReaderString(reader, "gid"));
            //            var pos = (EEquipPos)DBTextResource.ParseUI(GetReaderString(reader, "pos"));
            //            var ar_con_need = DBTextResource.ParseUI(GetReaderString(reader, "ar_con_need"));
            //            var ar_str_need = DBTextResource.ParseUI(GetReaderString(reader, "ar_str_need"));
            //            var ar_agi_need = DBTextResource.ParseUI(GetReaderString(reader, "ar_agi_need"));
            //            var ar_int_need = DBTextResource.ParseUI(GetReaderString(reader, "ar_int_need"));
            //            //var transfer_need = DBTextResource.ParseUI(GetReaderString(reader, "transfer_need"));
            //            var legend_attrs_num = DBTextResource.ParseUI(GetReaderString(reader, "legend_attrs_num"));
            //            var model = DBTextResource.ParseUI(GetReaderString(reader, "model"));
            //            var lv_step = DBTextResource.ParseUI(GetReaderString(reader, "lv_step"));
            //            var strength_max = DBTextResource.ParseUI(GetReaderString(reader, "strength_limit"));
            //            var suit_id = DBTextResource.ParseUI(GetReaderString(reader, "suit_id"));
            //            var pet_exp = DBTextResource.ParseUI(GetReaderString(reader, "pet_exp"));
            //            var default_extra_desc = GetReaderBytes(reader, "default_extra_desc");
            //            var default_star = DBTextResource.ParseUI_s(GetReaderString(reader, "default_star"), 0);
            //            var can_identify = DBTextResource.ParseUI_s(GetReaderString(reader, "can_identify"), 0) == 1;
            //            var default_score = DBTextResource.ParseUI_s(GetReaderString(reader, "default_score"), 0);
            //            var legend_attrs = DBTextResource.ParseArrayUintUint(GetReaderString(reader, "legend_attrs"));
            //            var mod_data = new EquipModData(id,pos, ar_con_need, ar_str_need, ar_agi_need, ar_int_need, legend_attrs_num,
            //                model, lv_step, strength_max, suit_id, pet_exp, default_extra_desc, default_star, can_identify, default_score, legend_attrs);
            //            EquipModDatas.Add(mod_data.Id, mod_data);
            //        }
            //    }
            //}
        }
    }
}
