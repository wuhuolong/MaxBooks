using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using Mono.Data.Sqlite;
namespace xc
{
    /// <summary>
    /// 装备子描述的formatter
    /// </summary>
    public class AttrDescFormatter : IFormatProvider, ICustomFormatter
    {
        public object GetFormat(Type formatType)
        {
            if (formatType == typeof(ICustomFormatter))
                return this;
            else
                return null;
        }

        public string Format(string format, object arg, IFormatProvider formatProvider)
        {
            if (!this.Equals(formatProvider))
            {
                return null;
            }
            else
            {
                var arg_str = arg.ToString();

                if (String.IsNullOrEmpty(format))
                    return arg_str;

                format = format.ToUpper();
                switch (format)
                {
                    case "%":
                        {
                            // 装备属性的百分比的数字都是预先乘以1000的
                            // 如果要显示百分比，这里要除以10
                            uint num;
                            if (uint.TryParse(arg_str, out num))
                            {
                                return (num / 10f).ToString("0.0");
                            }
                            else
                            {
                                // 附魔用的特殊匹配
                                var match = Regex.Match(arg_str, @"\[(\d+)\-(\d+)\]");
                                if (match.Success)
                                {
                                    uint num_1, num_2;
                                    if (uint.TryParse(match.Groups[1].Value, out num_1) && 
                                        uint.TryParse(match.Groups[2].Value, out num_2))
                                    {
                                        return string.Format("[{0}-{1}]", num_1 / 10f, num_2 / 10f);
                                    }
                                }

                                return arg_str;
                            }
                        }
                    default:
                        return arg_str;
                }
            }
        }
    }
    public class EquipSubAttrData
    {
        public uint SubId { get; private set; }
        public string Des { get; private set; }
        public List<uint> DesType = new List<uint>();
        public EquipSubAttrData(uint sub_id , string des , List<uint> attr_type)
        {
            SubId = sub_id;
            Des = des;
            DesType = attr_type;
        }
    }

    /// <summary>
    /// 装备子属性表
    /// </summary>
    public class DBEquipSubAttr : DBSqliteTableResource
    {
//        public static AttrDescFormatter DescFormatter = new AttrDescFormatter();

        public Dictionary<uint, EquipSubAttrData> EquipSubAttrDescs = new Dictionary<uint, EquipSubAttrData>();

        public DBEquipSubAttr(string name, string path)
            : base(name, path)
        { }

        public string GetSubAttrDesc(uint sub_attr_id)
        {
            EquipSubAttrData data = GetSubAttrData(sub_attr_id);
            if (data != null)
            {
                return data.Des;
            }

            // TODO log warning
            return string.Empty;
        }

        public EquipSubAttrData GetSubAttrData(uint sub_attr_id)
        {
            EquipSubAttrData data = null;
            if (EquipSubAttrDescs.TryGetValue(sub_attr_id, out data))
            {
                return data;
            }

            string query = string.Format("SELECT * FROM {0} WHERE {0}.{1}=\"{2}\"", mTableName, "id", sub_attr_id);
            var reader = DBManager.Instance.ExecuteSqliteQueryToReader(GlobalConfig.DBFile, mTableName, query);
            if (reader == null)
            {
                EquipSubAttrDescs[sub_attr_id] = null;
                return null;
            }

            if (!reader.HasRows || !reader.Read())
            {
                EquipSubAttrDescs[sub_attr_id] = null;

                reader.Close();
                reader.Dispose();
                return null;
            }

            var id = DBTextResource.ParseUI(GetReaderString(reader, "id"));
            var des = GetReaderString(reader, "desc");
            var tmp_str = GetReaderString(reader, "attr_type");
            tmp_str = tmp_str.Substring(1, tmp_str.Length - 2);
            var _tmp_split = tmp_str.Split(',');
            List<uint> at_type = new List<uint>();
            uint c = 0;
            for (int i = 0; i < _tmp_split.Length; i++)
            {
                if (uint.TryParse(_tmp_split[i], out c))
                {
                    if (c != 9)
                        at_type.Add(c);
                }
            }
            data = new EquipSubAttrData(id, des, at_type);
            EquipSubAttrDescs.Add(id, data);

            reader.Close();
            reader.Dispose();
            return data;
        }

        public string GetSubAttrDesc(EquipAttrData attrData , string replace_str, uint sub_attr_id, out uint color, params uint[] values)
        {
            color = 0;
            string colorStr = string.Empty;
            string attr = "";

            EquipSubAttrData data = GetSubAttrData(sub_attr_id);
            if (data != null)
            {
                List<string> des_value = new List<string>();
                for (int i = 0; i < data.DesType.Count; i++)
                {
                    for (int j = 0; j < attrData.ColorType.Count; j++)
                    {
                        var valuerange = attrData.ColorType[j];
                        if (values[i] >= valuerange.Min && values[i] <= valuerange.Max)
                        {
                            color = (uint)j;
                            colorStr = GoodsHelper.GetGoodsColor((uint)j);//对应就是0~4品质
                            break;
                        }
                    }
                    if (i < values.Length)
                    {
                        switch (data.DesType[i])
                        {
                            case 0:
                                {
                                    string val = values[i].ToString();

                                    des_value.Add(val);
                                }
                                break;
                            case 1:
                                {
                                    string val = (values[i] / ActorHelper.UnitConvert).ToString("0.00");
                                    val = ActorUtils.Instance.TrimFloatStr(val);
                                    des_value.Add(val);
                                }
                                break;
                            case 2:
                                {
                                    string val_noSign = (values[i] / ActorHelper.DisplayPercentUnitConvert).ToString("0.00");
                                    val_noSign = ActorUtils.Instance.TrimFloatStr(val_noSign);
                                    string val = val_noSign + "%";
                                    des_value.Add(val);
                                }
                                break;
                        }
                    }
                }
                string des_str = data.Des;
                if (replace_str != null && replace_str.Length > 0)
                {
                    for (int index = 0; index < des_value.Count; ++index)
                    {
                        des_str = des_str.Replace("{" + index.ToString() + "}", replace_str + "{" + index.ToString() + "}");
                    }

                }
                if (des_value.Count > 0)
                    attr = string.Format(des_str, des_value.ToArray());
            }
            if (colorStr.CompareTo(string.Empty) != 0)
            {
                attr = colorStr + attr + "</color>";
            }
            return attr;
        }

        public override void Unload()
        {
            EquipSubAttrDescs.Clear();

            base.Unload();
        }

        protected override void ParseData(SqliteDataReader reader)
        {

            EquipSubAttrDescs.Clear();
            if (reader != null)
            {
                if (reader.HasRows == true)
                {
                    while (reader.Read())
                    {
                        var id = DBTextResource.ParseUI(GetReaderString(reader ,"id"));
                        var des = GetReaderString(reader ,"desc");
                        var tmp_str = GetReaderString(reader ,"attr_type");
                        tmp_str = tmp_str.Substring(1 , tmp_str.Length-2);
                        var _tmp_split = tmp_str.Split(',');
                        List<uint> at_type = new List<uint>();
                        uint c = 0;
                        for(int i = 0 ; i < _tmp_split.Length ; i ++)
                        {
                            if(uint.TryParse(_tmp_split[i] , out c))
                            {
                                if(c != 9)
                                    at_type.Add(c);
                            }
                        }
                        EquipSubAttrData subData = new EquipSubAttrData(id , des , at_type);
                        EquipSubAttrDescs.Add(id , subData);
                    }
                }
            }
        }
    }
}
