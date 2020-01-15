//----------------------------------------------------------------
// File: DBCurrency.cs
// Desc: H货币显示.xlsx 界面货币的显示信息的数据
// Author: raorui
// Date: 2018.8.25
//----------------------------------------------------------------
using UnityEngine;
using System.Collections.Generic;
using Mono.Data.Sqlite;

namespace xc
{
    public class DBCurrencyPanel : DBSqliteTableResource
    {
        public class CurrencyPanelInfo
        {
            public string panel_name; // 界面名字
            public string money_type_list; // 显示货币列表
            public string panel_node; // 界面挂载点 
            public Vector3 panel_pos;// 界面位置
            public string panel_param1;// 界面参数
        }

        List<CurrencyPanelInfo> mInfos = new List<CurrencyPanelInfo>();

        public DBCurrencyPanel(string strName, string strPath) : base(strName, strPath)
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
            CurrencyPanelInfo info = null;
            while (reader.Read())
            {

                info = new CurrencyPanelInfo();
                info.panel_name = GetReaderString(reader, "panel_name");
                if (Const.Region == RegionType.KOREA)
                    info.money_type_list = GetReaderString(reader, "money_type_list_kr");
                else
                    info.money_type_list = GetReaderString(reader, "money_type_list");
                info.panel_node = GetReaderString(reader, "panel_node");
                info.panel_pos = DBTextResource.ParseVector3(GetReaderString(reader, "panel_pos"));
                info.panel_param1 = GetReaderString(reader, "panel_param1");

                mInfos.Add(info);
            }
        }

        /// <summary>
        /// 根据界面名字和参数的参数获取最合适的货币栏信息
        /// </summary>
        /// <param name="wnd"></param>
        /// <returns></returns>
        public CurrencyPanelInfo GetSuitableInfo(string wnd, string param)
        {
            if (string.IsNullOrEmpty(param))
                param = "";

            CurrencyPanelInfo default_info = null;
            foreach (var info in mInfos)
            {
                if (info.panel_name != wnd)
                    continue;

                if (info.panel_param1 == param)// 与传入窗口的参数一直
                {
                    return info;
                }
                else if (string.IsNullOrEmpty(info.panel_param1)) // 获取默认参数的信息
                {
                    if (default_info == null)
                        default_info = info;
                }
            }

            return default_info;
        }
    }
}
