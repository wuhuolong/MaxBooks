using UnityEngine;
using System.Collections.Generic;
using Mono.Data.Sqlite;

namespace xc
{
    public class DBProbabilityBtn : DBSqliteTableResource
    {
        public class ProbabilityBtnInfo
        {
            public string panel_name; // 界面名字
            public uint sys_id;//对应的系统ID
            public string panel_node; // 界面挂载点 
            public Vector3 panel_pos;// 界面位置
            public string url;//打开的url
            public string panel_param1;// 界面参数
        }

        List<ProbabilityBtnInfo> mInfos = new List<ProbabilityBtnInfo>();

        public DBProbabilityBtn(string strName, string strPath) : base(strName, strPath)
        {

        }

        public override void Unload()
        {
            base.Unload();
            mInfos.Clear();
        }

        protected override void ParseData(SqliteDataReader reader)
        {
            if (reader == null || !reader.HasRows)
            {
                return;
            }

            mInfos.Clear();
            ProbabilityBtnInfo info = null;
            while (reader.Read())
            {
                info = new ProbabilityBtnInfo();
                info.panel_name = GetReaderString(reader, "panel_name");
                string sys_id_str = GetReaderString(reader, "sys_id");
                info.sys_id = uint.Parse(sys_id_str);
                info.panel_node = GetReaderString(reader, "panel_node");
                info.panel_pos = DBTextResource.ParseVector3(GetReaderString(reader, "panel_pos"));
                info.url = GetReaderString(reader, "url");
                info.panel_param1 = GetReaderString(reader, "panel_param1");

                mInfos.Add(info);
            }
        }

        /// <summary>
        /// 根据界面名字和参数获取最合适的概率按钮信息
        /// </summary>
        /// <param name="wnd"></param>
        /// <param name="param"></param>
        /// <returns></returns>
        public ProbabilityBtnInfo GetSuitableInfo(string wnd, string param)
        {
            if (string.IsNullOrEmpty(param))
                param = "";
            ProbabilityBtnInfo default_info = null;
            foreach (var info in mInfos)
            {
                if(info.panel_name.Equals(wnd) == false)
                    continue;
                //与传入窗口的参数一致
                if (info.panel_param1 == param)
                {
                    return info;
                }
                else if (string.IsNullOrEmpty(info.panel_param1))
                {
                    //获取默认参数的信息
                    if (default_info == null)
                        default_info = info;
                }
            }

            return default_info;
        }
    }
}
