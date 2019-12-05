/*******************************************************************/
//   Desc :  系统开关表,用于在ios提审时关闭某些特殊的系统
//   Author : raorui
//   Date   : 2016.10.15
/*******************************************************************/
using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;
using Mono.Data.Sqlite;
using System.Text;

namespace xc
{
    public class DBSystemToggle : DBSqliteTableResource
    {
        public class SystemToggle
        {
            public string Id;
            public bool Toggle;
        }

        private List<SystemToggle> mToggles = new List<SystemToggle>();

        public DBSystemToggle(string strName, string strPath)
        : base(strName, strPath)
        {

        }

        public override void Unload()
        {
            base.Unload();
        }

        protected override void ParseData(SqliteDataReader reader)
        {
            if (reader == null || !reader.HasRows)
            {
                return;
            }

            SystemToggle toggle = null;

            while (reader.Read())
            {
                toggle = new SystemToggle();

                toggle.Id = GetReaderString(reader, "id");

                if(GetReaderString(reader, "toggle") == "0")
                {
                    toggle.Toggle = false;
                }
                else
                {
                    toggle.Toggle = true;
                }

                mToggles.Add(toggle);
            }
        }

        public static bool IsOpen(string key)
        {
            DBSystemToggle db = Instance;

            if(db == null)
            {
                return true;
            }

            foreach (var item in db.mToggles)
            {
                if(item != null && item.Id == key)
                {
                    return item.Toggle;
                }
            }

            return true;
        }

        public static DBSystemToggle Instance
        {
            get
            {
                return DBManager.Instance.GetDB<DBSystemToggle>();
            }
        }
    }
}
