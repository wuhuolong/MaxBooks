using UnityEngine;
using System.Collections.Generic;
using Mono.Data.Sqlite;

namespace xc
{
    public class DBRefundBtn : DBSqliteTableResource
    {
        public class RefundBtnInfo
        {
            public string panel_name; // 界面名字
            public uint open_type; // 打开类型
            public string panel_param1;// 界面参数
            public string panel_node; // 界面挂载点 
            public Vector3 btn_panel_pos;// 按钮界面位置
            public Vector3 tips_panel_pos;// 提示界面位置
            public string btn_text;
            public string tips_panel_text;
            public string message_box_text;
            public string url; // 链接
        }

        List<RefundBtnInfo> mInfos = new List<RefundBtnInfo>();

        public DBRefundBtn(string strName, string strPath) : base(strName, strPath)
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
            RefundBtnInfo info = null;
            while (reader.Read())
            {
                info = new RefundBtnInfo();
                info.panel_name = GetReaderString(reader, "panel_name");
                info.open_type = DBTextResource.ParseUI(GetReaderString(reader, "open_type"));
                info.panel_param1 = GetReaderString(reader, "panel_param1");
                info.panel_node = GetReaderString(reader, "panel_node");
                info.btn_panel_pos = DBTextResource.ParseVector3(GetReaderString(reader, "btn_panel_pos"));
                info.tips_panel_pos = DBTextResource.ParseVector3(GetReaderString(reader, "tips_panel_pos"));
                info.btn_text = GetReaderString(reader, "btn_text");
                info.tips_panel_text = GetReaderString(reader, "tips_panel_text");
                info.message_box_text = GetReaderString(reader, "message_box_text");
                info.url = GetReaderString(reader, "url");

                mInfos.Add(info);
            }
        }

        /// <summary>
        /// 根据界面名字和参数获取最合适的退款按钮信息
        /// </summary>
        /// <param name="wnd"></param>
        /// <param name="param"></param>
        /// <returns></returns>
        public RefundBtnInfo GetSuitableInfo(string wnd, string param)
        {
            if (string.IsNullOrEmpty(param))
                param = "";
            RefundBtnInfo default_info = null;
            foreach (var info in mInfos)
            {
                if (info.panel_name.Equals(wnd) == false)
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
