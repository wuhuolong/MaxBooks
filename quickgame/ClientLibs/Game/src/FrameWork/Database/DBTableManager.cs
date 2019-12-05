//----------------------------------------------
// File: DBTableManager.cs
// Desc: 管理表格与Sqlite文件对应关系
// Author: raorui
// Date: 2018.9.19
//----------------------------------------------
using Mono.Data.Sqlite;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.IO;
using UnityEngine;
using SGameEngine;

namespace xc
{
    public class SqliteTableInfo
    {
        public string table_file; // 表格的名字
        public string sqlite_file; // sqlite文件的名字
        public bool use_password = true;// 是否使用密码
        public string bundle_path;// 资源文件路径
        public string bundle_res_name; // 资源在bundle中的名字
        public AssetBundle bundle; // 表格的bundle文件
    }

    class DBTableManager : xc.Singleton<DBTableManager>
    {
        private Dictionary<string, SqliteTableInfo> mSqliteTableInfos = new Dictionary<string, SqliteTableInfo>();

        private bool mInited = false;

        /// <summary>
        /// 初始化
        /// </summary>
        public void Init()
        {
            if (mInited)
                return;

            mInited = true;

            var sqlite_table = Resources.Load("sqlite_table") as TextAsset;

            if (sqlite_table != null)
            {
                var table = new csv.Table();
                table.InitFromString(sqlite_table.text);
                for (int i = 0; i < table.Count; ++i)
                {
                    var info = new SqliteTableInfo();
                    info.table_file = table.Select(i, "table_file");
                    info.sqlite_file = table.Select(i, "sqlite_file", "data");
                    info.use_password = table.Select(i, "use_password", "1") == "1";
                    info.bundle_path = table.Select(i, "bundle_path", "");
                    info.bundle_res_name = table.Select(i, "bundle_res_name", "1");
                    mSqliteTableInfos[info.table_file] = info;
                }

                table.Clear();

                Resources.UnloadAsset(sqlite_table);
            }
            else
                GameDebug.LogError("DBTableManager init failed");
        }

        /// <summary>
        /// 获取指定表格对应的Sqlite数据库文件的名字
        /// </summary>
        /// <param name="table_name"></param>
        /// <returns></returns>
        public string GetSqliteFileName(string table_name)
        {
            SqliteTableInfo info = null;
            if(mSqliteTableInfos.TryGetValue(table_name, out info))
            {
                return info.sqlite_file;
            }
            else
                return "data";
        }

        /// <summary>
        /// 获取表格对应的assetbundle资源
        /// </summary>
        /// <param name="table_name"></param>
        /// <returns></returns>
        public AssetBundle GetSqliteBundle(string table_name)
        {
            SqliteTableInfo info = null;
            if (mSqliteTableInfos.TryGetValue(table_name, out info))
            {
                if (string.IsNullOrEmpty(info.bundle_path))
                    return DBManager.Instance.DBBundle;
                else
                    return info.bundle;
            }
            else
                return DBManager.Instance.DBBundle;
        }

        /// <summary>
        /// 获取表格对应的assetbundle资源
        /// </summary>
        /// <param name="table_name"></param>
        /// <returns></returns>
        public string GetBundleResName(string table_name)
        {
            SqliteTableInfo info = null;
            if (mSqliteTableInfos.TryGetValue(table_name, out info))
            {
                return info.bundle_res_name;
            }
            else
                return "";
        }

        /// <summary>
        /// 指定的表格是否使用了密码
        /// </summary>
        /// <param name="table_name"></param>
        /// <returns></returns>
        public bool IsUsePassword(string table_name)
        {
            SqliteTableInfo info = null;
            if (mSqliteTableInfos.TryGetValue(table_name, out info))
            {
                return info.use_password;
            }
            else
                return true;
        }

        /// <summary>
        /// 预加载表格的bundle文件
        /// </summary>
        /// <returns></returns>
        public IEnumerator Preload()
        {
            foreach (var info in mSqliteTableInfos)
            {
                var bundle_path = info.Value.bundle_path;
                if (string.IsNullOrEmpty(bundle_path))
                    continue;

                AssetResource ar = new AssetResource();
                string full_bundle_path = "Assets/Res/" + bundle_path;
                yield return MainGame.GlobalMono.StartCoroutine(ResourceLoader.Instance.load_asset(full_bundle_path, typeof(UnityEngine.Object), ar));
                AssetObject asset_obj = ar.get_obj();
                if (asset_obj == null)
                {
                    GameDebug.LogError(string.Format("Preload table {0} error", bundle_path));
                }
                else
                {
                    var bundl_list = asset_obj.get_dependence_bundles_;
                    if (bundl_list.Count > 0)
                        info.Value.bundle = bundl_list[0].get_asset_bundle_; // 表格默认只有一个bundle文件

                    // 连接sqlite表格前会重新加载assetbundle的资源
                    Resources.UnloadAsset(ar.asset_);
                }
                
                //ar.destroy();
            }
        }
    }
}
