//-------------------------------------------------------------------
//   File : DBWidgetShield.cs
//   Desc : 控件屏蔽配置表(版署服用)
//   Author : raorui
//   Date   : 2017.12.14
//-------------------------------------------------------------------
using System;
using System.Collections.Generic;
using Mono.Data.Sqlite;
using UnityEngine;

namespace xc
{
    public class DBWidgetShield : DBSqliteTableResource
    {
        public class WidgetInfo
        {
            /// <summary>
            /// 控件id
            /// </summary>
            public uint id;

            /// <summary>
            /// 控件的路径
            /// </summary>
            public string path;

            /// <summary>
            /// 是否送审需要
            /// </summary>
            public bool is_audit;
        }

        private Dictionary<string, List<WidgetInfo>> m_WidgetInfos = new Dictionary<string, List<WidgetInfo>>();
        

        static DBWidgetShield m_Instance;
        public static DBWidgetShield Instance
        {
            get
            {
                return m_Instance;
            }
        }

        public DBWidgetShield(string name, string path) : base(name, path)
        {
            m_Instance = this;
        }


        public override void Unload()
        {
            base.Unload();

            m_WidgetInfos.Clear();
        }

        protected override void ParseData(SqliteDataReader reader)
        {
            if (reader == null || !reader.HasRows)
            {
                return;
            }

            m_WidgetInfos.Clear();
            while (reader.Read())
            {
                var id = DBTextResource.ParseUI(GetReaderString(reader, "id"));
                var window = GetReaderString(reader, "window");
                var path = GetReaderString(reader, "path");
                var is_audit = DBTextResource.ParseUI(GetReaderString(reader, "is_audit"));

                if (m_WidgetInfos.ContainsKey(window))
                {
                    var list = m_WidgetInfos[window];
                    WidgetInfo info = new WidgetInfo();
                    info.path = path;
                    info.is_audit = is_audit == 1;
                    info.id = id;
                    list.Add(info);
                }
                else
                {
                    var list = new List<WidgetInfo>();
                    WidgetInfo info = new WidgetInfo();
                    info.path = path;
                    info.is_audit = is_audit == 1;
                    info.id = id;
                    list.Add(info);
                    m_WidgetInfos[window] = list;
                }

            }
        }

        public bool NeedShield(string window_name)
        {
            return m_WidgetInfos.ContainsKey(window_name);
        }

        public List<WidgetInfo> GetAllWidget(string window_name)
        {
            List<WidgetInfo> all_widget_path = null;
            m_WidgetInfos.TryGetValue(window_name, out all_widget_path);
            return all_widget_path;
        }
    }
}
