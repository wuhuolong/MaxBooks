using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using Mono.Data.Sqlite;

namespace xc
{
    public class DBUIManager : DBSqliteTableResource
    {
        public class UIInfo
        {
            public string name; //面板名称（带canvas的）
            public bool support_back; // 支持返回
            public bool is_modal;
            public byte ui_type;
            public bool is_global;
            public string sub_panels;
            public string init_open_panels;
            public byte sub_canvas_lenght;
            public string lua_path;
            public ushort destroy_delay_time;
            public short static_layer_index = -1;
            public byte reconnect_handle;
            public byte return_handle;
            public bool stay_when_switch_plane_instance; //切换位面副本时候的窗口是否保留
            public byte close_wins_type_when_show;
            public bool ban_back_last_panel;
            public bool ban_sub_window_when_back;
            public bool reopen;
            public byte patch_id;
        }

        public Dictionary<string, UIInfo> mData = new Dictionary<string, UIInfo>();

        public static DBUIManager Instance;
        public DBUIManager(string strName, string strPath) : base(strName, strPath)
        {
            Instance = this;
        }

        public override void Load()
        {
            IsLoaded = true;
        }

        public override void Unload()
        {
            mData.Clear();
        }

        /// <summary>
        /// 获取指定窗口的配置
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public UIInfo GetData(string name)
        {
            UIInfo info = null;
            if (!mData.TryGetValue(name, out info))
                info = GetUIInfo(name);

            return info;
        }

        /// <summary>
        /// 读取指定窗口的配置
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        private UIInfo GetUIInfo(string name)
        {
            string queryStr = string.Format("SELECT * FROM {0} WHERE {0}.{1}=\"{2}\"", mTableName, "name", name);

            var reader = DBManager.Instance.ExecuteSqliteQueryToReader(GlobalConfig.DBFile, mTableName, queryStr);
            if (reader == null)
                return null;

            if (!reader.HasRows || !reader.Read())
            {
                reader.Close();
                reader.Dispose();
                return null;
            }

            UIInfo info = new UIInfo();
            info.name = name;
            info.support_back = DBTextResource.ParseBT_s(GetReaderString(reader, "support_back"), 0) == 1;
            info.is_modal = DBTextResource.ParseBT_s(GetReaderString(reader, "is_modal"), 0) == 1;
            info.ui_type = DBTextResource.ParseBT_s(GetReaderString(reader, "ui_type"), 0);
            info.is_global = DBTextResource.ParseBT_s(GetReaderString(reader, "is_global"), 0) == 1;
            info.sub_panels = GetReaderString(reader, "sub_panels");
            info.init_open_panels = GetReaderString(reader, "init_open_panels");
            info.sub_canvas_lenght = DBTextResource.ParseBT_s(GetReaderString(reader, "sub_canvas_lenght"), 0);
            info.lua_path = GetReaderString(reader, "lua_path");

            var delay_time_text = GetReaderString(reader, "destroy_delay_time");
            ushort delay_time = 0;
            if (string.IsNullOrEmpty(delay_time_text))
            {
                if (SystemInfo.systemMemorySize <= 1024)
                    delay_time = 10;
                else
                    delay_time = 20;
            }
            else
                delay_time = DBTextResource.ParseUS_s(delay_time_text, 10);
            info.destroy_delay_time = delay_time;

            info.static_layer_index = DBTextResource.ParseS_s(GetReaderString(reader, "static_layer_index"), -1);
            info.reconnect_handle = DBTextResource.ParseBT_s(GetReaderString(reader, "reconnect_handle"), 0);
            info.return_handle = DBTextResource.ParseBT_s(GetReaderString(reader, "return_handle"), 0);
            info.stay_when_switch_plane_instance = DBTextResource.ParseBT_s(GetReaderString(reader, "stay_when_switch_plane_instance"), 0) == 1;
            info.close_wins_type_when_show = DBTextResource.ParseBT_s(GetReaderString(reader, "close_wins_type_when_show"), 0);
            info.ban_back_last_panel = DBTextResource.ParseBT_s(GetReaderString(reader, "ban_back_last_panel"), 0) == 1;
            info.ban_sub_window_when_back = DBTextResource.ParseBT_s(GetReaderString(reader, "ban_sub_window_when_back"), 0) == 1;
            info.reopen = DBTextResource.ParseBT_s(GetReaderString(reader, "reopen"), 0) == 1;
            info.patch_id = DBTextResource.ParseBT_s(GetReaderString(reader, "patch_id"), 0);

            mData[info.name] = info;

            reader.Close();
            reader.Dispose();

            return info;
        }
    }
}