using Mono.Data.Sqlite;
using SGameEngine;
using SGameFirstPass;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.IO;
using UnityEngine;

namespace xc
{
    public class DBManager : xc.Singleton<DBManager>
    {
        public enum CommandTag
        {
            TAG_2 = 2,
            TAG_3
        }

        public const string CharIndexTable = "data_chars_index";

        public class DBBase
        {
            virtual public void Load()
            { }

            virtual public void Unload()
            { }

            public bool IsLoaded;
        }

        public class SqliteCache : IPoolable
        {
#if UNITY_EDITOR
            [XLua.BlackList]
            public string key;
#endif
            public List<Dictionary<string, string>> Data;
            private List<object> retList;

            public List<T> GetRetList<T>()
            {
                if (retList != null)
                {
                    return retList as List<T>;
                }

                List<T> ret = new List<T>();

                if (Data.Count > 0)
                {
                    var data_row = Data[0];
                    using (var iter = data_row.Values.GetEnumerator())
                    {
                        while(iter.MoveNext())
                        {
                            var v = iter.Current;
                            ret.Add((T)System.Convert.ChangeType(v, v.GetType()));
                        }
                    }
                }
                this.retList = ret as List<object>;

                return ret;
            }

            public List<Dictionary<string, string>> GetRetListDic()
            {
                return Data;
            }

            public void OnFreeToPool()
            {
                if (this.retList != null)
                {
                    this.retList.Clear();
                    this.retList = null;
                }

                if (Data != null)
                {
                    Data.Clear();
                    Data = null;
                }
            }

            public void OnGetFromPool()
            {
            }
        }

        /// <summary>
        /// 记录查询顺序
        /// </summary>
        private Queue<string> sqliteQuerySeq;

        /// <summary>
        /// 查询缓存
        /// </summary>
        private Dictionary<string, SqliteCache> sqliteCache;
        
        /// <summary>
        /// 缓存池
        /// </summary>
        private ObjectPool sqliteCachePool;

        /// <summary>
        /// 只记录查询的最大条数
        /// </summary>
        private const int MAX_COUNT = 1000;

        /// <summary>
        /// 每次删除最先插入的10条数据
        /// </summary>
        private const int DELETE_COUNT = 500;


        public DBManager()
        {
            string destDirectoryPath = Const.persistentDataPath + "/DB";
            if (Directory.Exists(destDirectoryPath) == false)
            {
                Directory.CreateDirectory(destDirectoryPath);
            }

            sqliteCachePool = new ObjectPool(GetSqliteCacheFactory, 10000);
            sqliteCache = new Dictionary<string, SqliteCache>();
            sqliteQuerySeq = new Queue<string>();
        }

        private IPoolable GetSqliteCacheFactory()
        {
            return new SqliteCache();
        }

        public DBBase GetDB(string name)
        {
            DBBase db = null;
            mDBSet.TryGetValue(name.ToLower(), out db);
            return db;
        }

        public T GetDB<T>()
            where T : class
        {
            DBBase db;
            mDBSet.TryGetValue(UtilType.GetTypeLowerName(typeof(T)), out db);
            return db as T;
        }

        public void RegisterDB(DBBase db)
        {
            string db_key = UtilType.GetTypeLowerName(db.GetType());
            mDBKeys.Add(db_key);
            mDBSet.Add(db_key, db);
        }

        private AssetBundle mDBBundle;

        public AssetBundle DBBundle
        {
            get
            {
                return mDBBundle;
            }
        }

        /// <summary>
        /// 表格的最新版本号
        /// </summary>
        public string LatestVbn
        {
            get
            {
                return mLatestVbn;
            }
        }

        private string mLatestVbn = "0";

        /// <summary>
        /// 当前表格加载和更新各阶段的进度
        /// </summary>
        public float CurProcess
        {
            get
            {
                return mCurProcess;
            }
        }

        private float mCurProcess;

        private bool mHasRegister = false;

        public bool IsLoadAllFinished
        {
            get; protected set;
        }

        /// <summary>
        /// 加载所有的数据表格
        /// </summary>
        public IEnumerator Load()
        {
            if (!mHasRegister)
            {
                DBRegister.RegisterAllDB();
                mHasRegister = true;
            }

            mCurProcess = 0;
            NewInitSceneLoader.Instance.SetProcess(mCurProcess);

            // 为首次运行准备数据开始
            var firstLaunchBegin = PlayerPrefs.GetInt(BuriedPointConst.firstLaunchBegin, 0);
            if (firstLaunchBegin == 0) {
                PlayerPrefs.SetInt(BuriedPointConst.firstLaunchBegin, 1);
                PlayerPrefs.Save();
                BuriedPointHelper.ReportEsaAppsflyerEvnet("custom_loss", "prepare_first_launch_begin", 1);
            }
            if (AuditManager.Instance.Open)
                NewInitSceneLoader.Instance.SetProcessText(xc.TextHelper.LoadingNotice);
            else
                NewInitSceneLoader.Instance.SetProcessText(xc.TextHelper.InitDataNotice);

            IsLoadAllFinished = false;
#if UNITY_EDITOR
            foreach (var key in mDBKeys)
            {
                mDBSet[key].Load();
            }
            mDBKeys.Clear();

            mCurProcess = 1;
            NewInitSceneLoader.Instance.SetProcess(mCurProcess);

            //System.GC.Collect();
            yield return null;
            //GameDebug.LogError(string.Format("MonoHeapSize:{0} GetMonoUsedSize:{1} TotalAllocatedMemory:{2}  UsedHeapSize:{3}", Profiler.GetMonoHeapSize(), Profiler.GetMonoUsedSize(), Profiler.GetTotalAllocatedMemory(), Profiler.usedHeapSize));
#else
    #if UNITY_IPHONE
            string[] filePath = new string[2];
            filePath[0] = ResNameMapping.Instance.GetTableFileName();
            filePath[1] = ResNameMapping.Instance.GetExVersionName();

            // 如果是提审状态，则不检查表格的更新
            if (AuditManager.Instance.Open)
            {
                yield return NewInitSceneLoader.Instance.StartCoroutine(LoadAllDBAsset());
            }
            else
            {
                string[] targetfilePath = new string[2];
                targetfilePath[0] = ResNameMapping.Instance.GetTableFileName(true);
                targetfilePath[1] = ResNameMapping.Instance.GetExVersionName(true);

                // 先把Stream文件夹中的表格文件拷贝出来
                yield return NewInitSceneLoader.Instance.StartCoroutine(NewInitSceneLoader.Instance.copy_streamassets(filePath, "", targetfilePath));
                // 检查表格更新
                yield return NewInitSceneLoader.Instance.StartCoroutine(RequestUpdateInfo());
            }
                
    #else
        #if UNITY_MOBILE_LOCAL
            string[] filePath = new string[1];
            filePath[0] = ResNameMapping.Instance.GetTableFileName();

            // 先把Stream文件夹中的表格文件拷贝出来
            yield return NewInitSceneLoader.Instance.StartCoroutine(NewInitSceneLoader.Instance.copy_streamassets(filePath));
            yield return NewInitSceneLoader.Instance.StartCoroutine(LoadAllDBAsset());
        #else
            yield return NewInitSceneLoader.Instance.StartCoroutine(LoadAllDBAsset());
            yield return null;
        #endif
    #endif
#endif
            IsLoadAllFinished = true;

            // 为首次运行准备数据结束
            var firstLauchEnd = PlayerPrefs.GetInt(BuriedPointConst.firstLaunchEnd, 0);
            if (firstLauchEnd == 0) {
                PlayerPrefs.SetInt(BuriedPointConst.firstLaunchEnd, 1);
                PlayerPrefs.Save();
                BuriedPointHelper.ReportEsaAppsflyerEvnet("custom_loss", "prepare_first_launch_end", 1);
            }
        }

        /// <summary>
        /// 清除所有已加载表格的数据
        /// </summary>
        public void Unload()
        {
            foreach (DBBase db in mDBSet.Values)
            {
                db.Unload();
                db.IsLoaded = false;
            }
            IsLoadAllFinished = false;
        }

        /// <summary>
        /// 加载特定的表格文件（比如: "DB/Nep/data_nep_1001.json"）,暂时只用于json的加载
        /// </summary>
        public string LoadDBFile(string fileName)
        {
            string strData = "";
            // 从resource下加载
#if UNITY_EDITOR
            string resName = AssetsResPath + "/" + fileName;

            TextAsset textObj = EditorResourceLoader.LoadAssetAtPath(resName, typeof(TextAsset)) as TextAsset;
            if (textObj != null)
            {
                strData = Utils.Utf8Parse.BinToUtf8(textObj.bytes);
                Resources.UnloadAsset(textObj);
            }
            else
            {
                //GameDebug.LogError("DB file load failed: " + fileName);
            }
#else
            // 从assetbundle下加载
            if(mDBBundle != null)
            {
                fileName = System.IO.Path.GetFileNameWithoutExtension(fileName);
                var file_text = mDBBundle.LoadAsset(fileName) as TextAsset;

                if (file_text != null)
                {
                    strData = Utils.Utf8Parse.BinToUtf8(file_text.bytes);
                    Resources.UnloadAsset(file_text);
                }
            }
            else
                GameDebug.LogError("DB asset is null!!!");
#endif
            return strData;
        }

        /// <summary>
        /// 保存所有的表格信息
        /// </summary>
        private Dictionary<string, DBBase> mDBSet = new Dictionary<string, DBBase>();

        /// <summary>
        /// 保存所有表格的key
        /// </summary>
        private List<string> mDBKeys = new List<string>();

        /// <summary>
        /// 从assetbundle中加载所有的表格数据
        /// </summary>
        public IEnumerator LoadAllDBAsset()
        {
            mCurProcess = 0.0f;

#if UNITY_ANDROID || UNITY_IPHONE
            IBridge bridge = DBOSManager.getDBOSManager().getBridge();
            string targetPath = bridge.getGameResPath();
            string filePath = targetPath + ResNameMapping.Instance.GetTableFileName(true);

            // ios提审状态直接从streamingAssets目录读取
            #if UNITY_IPHONE
            if (AuditManager.Instance.Open)
            {
                filePath = Application.streamingAssetsPath + "/" + ResNameMapping.Instance.GetTableFileName();
            }
            #endif
#else
    #if UNITY_MOBILE_LOCAL
            IBridge bridge = DBOSManager.getDBOSManager().getBridge();
            string targetPath = bridge.getGameResPath();
            string filePath = targetPath + ResNameMapping.Instance.GetTableFileName();
    #else
            string filePath = Application.streamingAssetsPath + "/" +ResNameMapping.Instance.GetTableFileName();
    #endif
#endif
            if (System.IO.File.Exists(filePath))
            {
                byte[] file_data = Utils.ZipClass.GetInstance().UnZipFileToMemoryEx(filePath, "r1z2i3p!f@i#l$e%");

                // 创建assetbundle
                if (file_data.GetLength(0) > 0)
                {
                    // 销毁旧的assetbundle
                    if (mDBBundle != null)
                        mDBBundle.Unload(true);

                    mDBBundle = AssetBundle.LoadFromMemory(file_data);
                    if (mDBBundle == null)
                        GameDebug.LogError("[LoadAllDBAsset]Create assetbundle failed.");
                }
                else
                    GameDebug.LogError("[LoadAllDBAsset]Unzip table failed.");
            }
            else
                GameDebug.LogError("[LoadAllDBAsset]" + filePath + " is not exist.");

            yield return null;

            mCurProcess = 0.0f;

            // 加载的时候要按注册的顺序进行
            int i = 0;
            float count = mDBKeys.Count;
            foreach (var key in mDBKeys)
            {
                i++;

                mDBSet[key].Load();

                if (i%10 == 0)
                {
                    var process = 0.8f * i / count;
                    NewInitSceneLoader.Instance.SetProcess(process);
                    NewInitSceneLoader.Instance.SetProcessRatio(string.Format("{0}/100", (int)(process * 100)));
                    yield return null;
                }
            }
            mDBKeys.Clear();

            int time = 0;
#if UNITY_IPHONE
            if(SystemInfo.systemMemorySize <= 1024)// iphone6的systemMemorySize为989M
                time = 15;
#endif

            NewInitSceneLoader.Instance.AutoProcess(0.8f, xc.TextHelper.LoadingNotice, time);
        }

        private string GetDBUpdateUrl()
        {
#if UNITY_IPHONE
            var server_url = DBOSManager.getOSBridge().getUpdateCheckUrlEx();
#else
            var server_url = DBOSManager.getOSBridge().getUpdateCheckUrl();
#endif
            if (!server_url.StartsWith("http://"))
            {
                server_url = "http://" + server_url;
            }
            return server_url;
        }

#region SQLite

        private Dictionary<string, SqliteConnection> mSqliteDBConnections = new Dictionary<string, SqliteConnection>();
        private Dictionary<long, SqliteCommand> mSqliteCommands = new Dictionary<long, SqliteCommand>();
        private long mOpenSqliteTime = 0;

        public static string AssetsResPath = "Assets/Res";

        private DateTime mBaseline = new System.DateTime(1970, 1, 1, 0, 0, 0, 0);

        /// <summary>
        /// 获取表格对应的assetbundle资源
        /// </summary>
        /// <param name="table_name"></param>
        /// <returns></returns>
        private AssetBundle GetSqliteBundle(string table_name)
        {
            return DBTableManager.Instance.GetSqliteBundle(table_name);
        }

        /// <summary>
        /// 连接指定的数据库文件
        /// </summary>
        /// <param name="fileName"></param>
        /// <returns></returns>
        private SqliteConnection OpenSqliteDB(string fileName, string table_name)
        {
            if (mOpenSqliteTime == 0)
                mOpenSqliteTime = Convert.ToInt64((System.DateTime.UtcNow - mBaseline).TotalSeconds);

            // 目标文件的路径
            string dest_dir_path = Const.persistentDataPath + "/DB";
#if UNITY_ANDROID || UNITY_IPHONE || UNITY_MOBILE_LOCAL
            string dest_file_path = string.Format("{0}/{1}_{2}.txt", dest_dir_path, fileName, GlobalConfig.GetInstance().PlatformName);
#else
            string dest_file_path = string.Format("{0}/{1}_{2}_{3}.txt", dest_dir_path, fileName, GlobalConfig.GetInstance().PlatformName, mOpenSqliteTime);
#endif

            try
            {
                // 删除旧文件
                if (File.Exists(dest_file_path))
                    File.Delete(dest_file_path);

                bool load_db_file_succ = false;

                // 从资源中读取表格二进制数据并写文件
#if UNITY_EDITOR
                var src_file_path = string.Format("{0}/DB/{1}.bytes", AssetsResPath, fileName);
                var file_txt = EditorResourceLoader.LoadAssetAtPath(src_file_path, typeof(TextAsset)) as TextAsset;
                if (file_txt != null)
                {
                    load_db_file_succ = true;
                    File.WriteAllBytes(dest_file_path, file_txt.bytes);
                    Resources.UnloadAsset(file_txt);
                }
#else
                var db_bundle = GetSqliteBundle(table_name);
                if(db_bundle != null)
                {
                    // 获取表格在bundle中的名字
                    var res_name = DBTableManager.Instance.GetBundleResName(table_name);
                    if (string.IsNullOrEmpty(res_name))
                        res_name = Path.GetFileNameWithoutExtension(fileName);

                    var file_txt = db_bundle.LoadAsset(res_name) as TextAsset;
                    if(file_txt != null)
                    {
                        load_db_file_succ = true;
                        File.WriteAllBytes(dest_file_path, file_txt.bytes);
                        Resources.UnloadAsset(file_txt);
                    }
                    else
                    {
                        GameDebug.LogError(string.Format("[OpenSqliteDB]load {0} from bundle failed.", fileName));
                    }
                }
                else
                    GameDebug.LogError(string.Format("[OpenSqliteDB]read table {0} failed, bundle is null.", table_name));
#endif

                // 连接数据库
                if (load_db_file_succ)
                {
                    var connection_str = @"Data Source=" + dest_file_path + ";Cache Size=800000";
                    var db_connection = new SqliteConnection(connection_str);

                    if (DBTableManager.Instance.IsUsePassword(table_name))
                        db_connection.SetPassword("jindaxina305");

                    db_connection.Open();

                    return db_connection;
                }
                else
                    return null;
            }
            catch (Exception e)
            {
                GameDebug.LogError(e.ToString());
            }

            return null;
        }

        /// <summary>
        /// 获取指定数据库的连接
        /// </summary>
        /// <param name="fileName"></param>
        /// <returns></returns>
        private SqliteConnection GetSqliteConnection(string file_name, string table_name)
        {
            SqliteConnection sql_connect = null;
            if(!mSqliteDBConnections.TryGetValue(file_name, out sql_connect))
            {
                sql_connect = OpenSqliteDB(file_name, table_name);
                if(sql_connect != null)
                    mSqliteDBConnections[file_name] = sql_connect;
            }

            return sql_connect;
        }

        /// <summary>
        /// 获取SqliteConnection对应的SqliteCommand
        /// </summary>
        /// <param name="db_connection"></param>
        /// <returns></returns>
        private SqliteCommand GetSqliteCommand(SqliteConnection db_connection, int commandTag = 0)
        {
            if (db_connection == null)
                return null;

            // 可能在SqliteReader内部会嵌套另外的SqliteReader, 因此通过commandTag来创建多个SqliteCommand
            long connectId = db_connection.GetHashCode();
            if (commandTag != 0)
                connectId = connectId * 100 + commandTag;

            SqliteCommand db_command = null;
            if (!mSqliteCommands.TryGetValue(connectId, out db_command))
            {
                db_command = db_connection.CreateCommand();
                mSqliteCommands[connectId] = db_command;
            }

            return db_command;
        }

        private IEnumerator CloseAllSqliteDBCoroutine()
        {
            yield return new SafeCoroutine.SafeWaitForSeconds(0.1f);

            CloseAllSqliteDB();
        }

        /// <summary>
        /// 对指定的表格执行Sql查询
        /// </summary>
        /// <param name="file_name">sqlite 数据库的名字</param>
        /// <param name="table_name">表格的名字</param>
        /// <param name="sql_query">sql查询的字符串</param>
        /// <param name="mapping_sqlite_file">是否通过表格名字获取数据库文件</param>
        /// <returns></returns>
        [XLua.BlackList]
        public SqliteDataReader ExecuteSqliteQueryToReader(string file_name, string table_name, string sql_query, int commandTag = 0)
        {
            try
            {
                var sqlite_file_name = DBTableManager.Instance.GetSqliteFileName(table_name);
                var db_connection = GetSqliteConnection(sqlite_file_name, table_name);
                if (db_connection != null)
                {
                    var db_command = GetSqliteCommand(db_connection, commandTag);
                    db_command.CommandText = sql_query;

                    var reader = db_command.ExecuteReader();
#if UNITY_EDITOR
                    // 编辑器下要实时关闭数据库连接，不然有时候会造成编辑器卡死
                    SafeCoroutine.CoroutineManager.StartCoroutine(CloseAllSqliteDBCoroutine());
#endif
                    return reader;
                }
            }
            catch (Exception e)
            {
                GameDebug.LogError(string.Format("[ExecuteSqliteQueryToReader]{0} {1} {2} ", e,file_name,table_name));
            }

            return null;
        }

        private const string CACHE_KEY = "{0}_{1}";

        /// <summary>
        /// 表格列信息
        /// </summary>
        public class ColumnInfo
        {
            public string name; // 列的数据名
            public Type type; // 列的类型
        }

        /// <summary>
        /// 缓存已查询表的列信息
        /// </summary>
        Dictionary<string, List<ColumnInfo>> mTableColumnCache = new Dictionary<string, List<ColumnInfo>>();

        /// <summary>
        /// 获取表格的列信息
        /// </summary>
        /// <param name="table_name"></param>
        /// <returns></returns>
        public List<ColumnInfo> GetColumnInfo(string table_name)
        {
            List<ColumnInfo> info = null;
            mTableColumnCache.TryGetValue(table_name, out info);
            return info;
        }

        /// <summary>
        /// 设置表格的列信息
        /// </summary>
        /// <param name="table_name"></param>
        /// <returns></returns>
        public void SetColumnInfo(string table_name, List<ColumnInfo> info)
        {
            if(!string.IsNullOrEmpty(table_name) && info != null)
                mTableColumnCache[table_name] = info;
        }

        /// <summary>
        /// 对db_file数据库执行query_str的sql查询，返回读取的数据
        /// </summary>
        /// <param name="db_file"></param>
        /// <param name="query_str"></param>
        List<Dictionary<string,string>> ExecuteSqliteQuery(string db_file, string table_name, string query_str)
        {
            List<Dictionary<string, string>> data = new List<Dictionary<string, string>>();
            var data_reader = ExecuteSqliteQueryToReader(db_file, table_name, query_str);
            if (data_reader == null)
                return data;

            if(!data_reader.HasRows)
            {
                data_reader.Close();
                data_reader.Dispose();
                return data;
            }

            int field_count = data_reader.FieldCount;

            // 从缓存中获取表格的列信息
            bool has_column_info = false;
            List<ColumnInfo> column_info = null;
            if (!string.IsNullOrEmpty(table_name))
            {
                // 只对SELECT * 的SQL语句进行列信息的缓存和获取
                bool select_all = false;
                for(int i = 0; i < query_str.Length && i < 10; ++i)
                {
                    char c = query_str[i];
                    if(c=='*')
                    {
                        select_all = true;
                        break;
                    }
                }

                if(select_all)
                {
                    has_column_info = mTableColumnCache.TryGetValue(table_name, out column_info);
                    if (column_info != null && column_info.Count != field_count)
                    {
                        has_column_info = false;
                        mTableColumnCache.Remove(table_name);
                        GameDebug.LogError(string.Format("{0} column_info is invalid, count:{1}", table_name, column_info.Count));
                    }

                    if (!has_column_info)
                    {
                        column_info = new List<ColumnInfo>();
                    }
                }
            }
            else
                GameDebug.LogError(string.Format("{0} : table name is null", query_str));

            while (data_reader.Read())
            {
                // 读取一行的数据
                var row_data = new Dictionary<string, string>(field_count);
                for (int i = 0; i < field_count; ++i)
                {
                    // 获取当前列的名字和Type
                    string field_name = "";
                    Type field_type = null;
                    if(has_column_info)
                    {
                        var info = column_info[i];
                        field_name = info.name;
                        field_type = info.type;
                    }
                    else
                    {
                        field_name = data_reader.GetName(i);
                        field_type = data_reader.GetFieldType(i);

                        if (column_info != null)
                        {
                            var info = new ColumnInfo();
                            info.name = field_name;
                            info.type = field_type;

                            column_info.Add(info);
                        }
                    }

                    if (field_type.Equals(typeof(string)))
                    {
                        row_data[field_name] = xc.TextHelper.GetTranslateText(table_name, field_name, data_reader.GetString(i));
                    }
                    else if (field_type.Equals(typeof(int)))
                    {
                        row_data[field_name] = data_reader.GetInt32(i).ToString();
                    }
                    else if (field_type.Equals(typeof(float)))
                    {
                        row_data[field_name] = data_reader.GetFloat(i).ToString();
                    }
                    else
                    {
                        row_data[field_name] = Convert.ToString(data_reader.GetValue(i));
                    }
                }

                // 读取当前行之后就可以缓存列信息
                if (!has_column_info && column_info != null)
                {
                    mTableColumnCache[table_name] = column_info;
                    has_column_info = true;
                }

                data.Add(row_data);
            }

            data_reader.Close();
            data_reader.Dispose();

            return data;
        }

        /// <summary>
        /// 获取指定数据表的查询缓存数据
        /// </summary>
        /// <param name="fileName"></param>
        /// <param name="queryStr"></param>
        /// <param name="save_cache">是否将查询的数据缓存下来</param>
        /// <returns></returns>
        public SqliteCache GetSqliteCache(string fileName, string table_name, string queryStr)
        {
            string key = queryStr;
            SqliteCache cache = null;

            if (!sqliteCache.TryGetValue(key, out cache))
            {
                cache = this.sqliteCachePool.Get() as SqliteCache;
#if UNITY_EDITOR
                cache.key = key;
#endif
                cache.Data = ExecuteSqliteQuery(fileName, table_name, queryStr);

                sqliteQuerySeq.Enqueue(key);
                sqliteCache.Add(key, cache);

                ///如果过长则删除最先查询的几个
                if (sqliteQuerySeq.Count > MAX_COUNT)
                {
                    for (int i = 0; i < DELETE_COUNT; i++)
                    {
                        string sqliteKey = sqliteQuerySeq.Dequeue();

                        SqliteCache cc = this.sqliteCache[sqliteKey];

                        sqliteCache.Remove(sqliteKey);

                        this.sqliteCachePool.Free(cc);
                    }
                }
            }

            return cache;
        }

        /// <summary>
        /// 通过SQL语句来查询指定的数据表，并返回所有符合条件的行
        /// </summary>
        /// <typeparam name="T">T泛型已经没用</typeparam>
        /// <param name="fileName"></param>
        /// <param name="queryStr"></param>
        /// <returns></returns>
        public List<Dictionary<string, string>> QuerySqliteRow(string fileName, string table_name, string queryStr)
        {
            var cache = this.GetSqliteCache(fileName, table_name, queryStr);

            return cache.GetRetListDic();
        }

        /// <summary>
        /// 查询sqlite表，并将查询结果封装成一个Dictionary
        /// T泛型已经没用
        /// </summary>
        public List<Dictionary<string, string>> QuerySqliteTable<T>(string fileName, string tableName)
        {
            string queryStr = "SELECT * FROM " + tableName;
            return QuerySqliteRow(fileName, tableName, queryStr);
        }

        /// <summary>
        /// 查询sqlite表的行，并将查询结果封装成一个Dictionary
        /// T泛型已经没用
        /// </summary>
        /// <param name="fileName">指定的数据库</param>
        /// <param name="tableName">表名</param>
        /// <param name="key">主键的名字</param>
        /// <param name="value">主键的值</param>
        /// <returns></returns>
        public List<Dictionary<string, string>> QuerySqliteRow<T>(string fileName, string tableName, string key, string value)
        {
            string query_str = string.Format("SELECT * FROM {0} WHERE {1}=\"{2}\"", tableName, key, value);
            return QuerySqliteRow(fileName, tableName, query_str);
        }

        /// <summary>
        /// 根据两列主键查询sqlite表的行，并将查询结果封装成一个Dictionary
        /// T泛型已经没用
        /// </summary>
        /// <param name="fileName">指定的数据库</param>
        /// <param name="tableName">表名</param>
        /// <param name="key">主键的名字</param>
        /// <param name="value">主键的值</param>
        /// <param name="key2">主键2的名字</param>
        /// <param name="value2">主键2的值</param>
        /// <returns></returns>
        public List<Dictionary<string, string>> QuerySqliteRow<T>(string fileName, string tableName, string key, string value, string key2, string value2)
        {
            string quest_str = string.Format("SELECT * FROM {0} WHERE {1}=\"{2}\" AND {3}=\"{4}\"", tableName, key, value, key2, value2);
            return QuerySqliteRow(fileName, tableName, quest_str);
        }

        /// <summary>
        /// 查询sqlite表的行，并且得到所指定行的最大值列，将查询结果封装成一个Dictionary
        /// </summary>
        /// <param name="fileName"></param>
        /// <param name="tableName"></param>
        /// <param name="key"></param>
        /// <param name="value"></param>
        /// <param name="maxKey">最大行的值</param>
        /// <returns></returns>
        public List<Dictionary<string, string>> QuerySqliteRowWithMaxValue<T>(string fileName, string tableName, string key, string value, string maxKey)
        {
            string queryStr = string.Format("SELECT * FROM {0} WHERE {0}.{1} = \"{2}\" AND {0}.{3} = (SELECT MAX({0}.{3}) FROM {0})", tableName, key, value, maxKey);
            return QuerySqliteRow(fileName, tableName, queryStr);
        }

        /// <summary>
        /// 查询sqlite表的行，并将查询结果封装成一个Dictionary
        /// </summary>
        /// <param name="fileName">指定的数据库</param>
        /// <param name="tableName">表名</param>
        /// <param name="key">主键的名字</param>
        /// <param name="value">主键的值</param>
        /// <returns></returns>
        public List<Dictionary<string, string>> QuerySqliteRow<T>(string fileName, string tableName, string key, uint value)
        {
            const string format_str = @"SELECT * FROM {0} WHERE {1}={2}";
            string queryStr = string.Format(format_str, tableName, key, value);
            return QuerySqliteRow(fileName, tableName, queryStr);
        }

        /// <summary>
        /// 查询Sqlite的行，符合包含value值的所有值
        /// </summary>
        /// <param name="fileName"></param>
        /// <param name="tableName"></param>
        /// <param name="key"></param>
        /// <param name="value">符合其像的值</param>
        /// <returns></returns>
        public List<Dictionary<string, string>> QuerySqliteLikeKeyRow<T>(string fileName, string tableName, string key, string value)
        {
            const string format_str = @"SELECT * FROM {0} WHERE {0}.{1} LIKE '%{2}%'";
            string queryStr = string.Format(format_str, tableName, key, value);

            return QuerySqliteRow(fileName, tableName, queryStr);
        }

        List<T> QuerySqliteField<T>(string fileName, string table_name, string queryStr)
        {
            var cache = this.GetSqliteCache(fileName, table_name, queryStr);

            return cache.GetRetList<T>();
        }

        /// <summary>
        /// 查询sqlite表的域，返回查询结果的具体值
        /// </summary>
        /// <param name="fileName">指定的数据库</param>
        /// <param name="tableName">表名</param>
        /// <param name="key">主键的名字</param>
        /// <param name="value">主键的值</param>
        /// <param name="field">要查询的域的名字</param>
        /// <returns></returns>
        public List<T> QuerySqliteField<T>(string fileName, string tableName, string key, string value, string field)
        {
            const string format_str = "SELECT {1} FROM {0} WHERE {2}=\"{3}\"";
            string queryStr = string.Format(format_str, tableName, field, key, value);

            return QuerySqliteField<T>(fileName, tableName, queryStr);
        }

        /// <summary>
        /// 查询sqlite表的域，返回查询结果的具体值
        /// </summary>
        /// <param name="fileName">指定的数据库</param>
        /// <param name="tableName">表名</param>
        /// <param name="key">主键的名字</param>
        /// <param name="value">主键的值</param>
        /// <param name="field">要查询的域的名字</param>
        /// <returns></returns>
        public List<T> QuerySqliteField<T>(string fileName, string tableName, string key, uint value, string field)
        {
            const string format_str = @"SELECT {1} FROM {0} WHERE {2}={3}";

            string queryStr = string.Format(format_str, tableName, field, key, value);

            return QuerySqliteField<T>(fileName, tableName, queryStr);
        }

        public void CloseAllSqliteDB()
        {
            foreach (var sql_command in mSqliteCommands.Values)
            {
                sql_command.Cancel();
                sql_command.Dispose();
            }
            mSqliteCommands.Clear();

            foreach (KeyValuePair<string, SqliteConnection> kv in mSqliteDBConnections)
            {
                kv.Value.Dispose();
                kv.Value.Close();

#if UNITY_ANDROID || UNITY_IPHONE
                string destFilePath = Const.persistentDataPath + "/DB/" + kv.Key + "_" + GlobalConfig.GetInstance().PlatformName + "_" + ".txt";
#else
                string destFilePath = Const.persistentDataPath + "/DB/" + kv.Key + "_" + GlobalConfig.GetInstance().PlatformName + "_" + mOpenSqliteTime + ".txt";
#endif
                if (File.Exists(destFilePath) == true)
                {
                    File.Delete(destFilePath);
                }
            }
            mSqliteDBConnections.Clear();
        }

        public void ClearCache()
        {
            this.sqliteCache.Clear();
            this.sqliteCachePool.ClearAll();
            this.sqliteQuerySeq.Clear();
        }

#endregion SQLite


#region UPDATE_TABLE
#if UNITY_IPHONE
        /// <summary>
        /// Step1 : 请求更新信息
        /// </summary>
        IEnumerator RequestUpdateInfo()
        {
            // 检查配置表文件更新
            ControlServerLogHelper.Instance.PostPlayerFollowRecord(PlayerFollowRecordSceneId.Res2iOSUpdateCheckStart, "", false);

            mCurProcess = 0.25f;
            NewInitSceneLoader.Instance.SetProcessText(xc.TextHelper.InitDataNotice);
            NewInitSceneLoader.Instance.SetProcess(mCurProcess);

            WWW www = new WWW(GetDBUpdateUrl());
            yield return www;

            while(string.IsNullOrEmpty(www.error) == false)
            {
                // 检查配置表文件更新
                ControlServerLogHelper.Instance.PostPlayerFollowRecord(PlayerFollowRecordSceneId.Res2iOSUpdateCheckFail, www.error, false);

                string str = xc.TextHelper.DBInitFailed;
                yield return NewInitSceneLoader.Instance.StartCoroutine(NewInitSceneLoader.Instance.ShowRoutine(str, xc.TextHelper.BtnConfirm));

                // 检查配置表文件更新
                ControlServerLogHelper.Instance.PostPlayerFollowRecord(PlayerFollowRecordSceneId.Res2iOSUpdateCheckStart, "", false);

                www = new WWW(GetDBUpdateUrl());
                yield return www;
            }

            while (string.IsNullOrEmpty(www.text))
            {
                string str = xc.TextHelper.DBInitFailed;

                // 检查配置表文件更新
                ControlServerLogHelper.Instance.PostPlayerFollowRecord(PlayerFollowRecordSceneId.Res2iOSUpdateCheckFail, str, false);

                yield return NewInitSceneLoader.Instance.StartCoroutine(NewInitSceneLoader.Instance.ShowRoutine(str, xc.TextHelper.BtnConfirm));

                // 检查配置表文件更新
                ControlServerLogHelper.Instance.PostPlayerFollowRecord(PlayerFollowRecordSceneId.Res2iOSUpdateCheckStart, "", false);

                www = new WWW(GetDBUpdateUrl());
                yield return www;
            }
             
            string wwwText = Utils.AES.Decode(www.text, Const.CS_URL_KEY, Const.CS_URL_IV);
            yield return NewInitSceneLoader.Instance.StartCoroutine(ParseUpdateInfo(wwwText));
        }

        IEnumerator OnFail(string fail_reason = "")
        {
            // 检查配置表文件更新
            ControlServerLogHelper.Instance.PostPlayerFollowRecord(PlayerFollowRecordSceneId.Res2iOSUpdateCheckFail, fail_reason, false);

            if (string.IsNullOrEmpty(fail_reason) == false)
                Debug.LogError(fail_reason);

            string str = xc.TextHelper.DBInitFailed;
            yield return NewInitSceneLoader.Instance.StartCoroutine(NewInitSceneLoader.Instance.ShowRoutine(str, xc.TextHelper.BtnConfirm));

            yield return NewInitSceneLoader.Instance.StartCoroutine(RequestUpdateInfo());
        }

        /// <summary>
        /// Step2 : 解析获取到的更新信息，并检查本地的表格和版本文件
        /// 如果没有更新，则直接加载文件，否则需要从服务器上下载文件
        /// </summary>
        string db_url = "";
        string db_ver = "";
        string db_md5 = "";
        ulong db_size = 0;
        IEnumerator ParseUpdateInfo(string reply)
        {
            Hashtable reply_table = MiniJSON.JsonDecode(reply) as Hashtable;
            var ret = reply_table["result"];
            if (ret == null)
            {
                string fail_reason = "[OnGetDBVersion]result is null";
                yield return NewInitSceneLoader.Instance.StartCoroutine(OnFail(fail_reason));
            }

            var result = (int)(double)ret;
            Debug.Log(string.Format("[DBManager][OnGetDBVersion]result {0}", result));

            if (result != 1)
            {
                string fail_reason = "[OnGetDBVersion]result is invaild";
                yield return NewInitSceneLoader.Instance.StartCoroutine(OnFail(fail_reason));
            }

            var update_args = reply_table["args"] as Hashtable;
            if (update_args == null)
            {
                string fail_reason = "[OnGetDBVersion]args is null";
                yield return NewInitSceneLoader.Instance.StartCoroutine(OnFail(fail_reason));
            }

            db_url = "";
            db_md5 = "";
            db_ver = "";
            db_size = 0;
            var update_cfg = update_args["update_cfg"] as ArrayList;
            if (update_cfg != null)
            {
                for (int i = 0; i < update_cfg.Count; ++i)
                {
                    Hashtable update_table = update_cfg[i] as Hashtable;

                    if (update_table != null)
                    {
                        string type = update_table["type"] as string;
                        if (!string.IsNullOrEmpty(type) && type == "res2")
                        {
                            db_url = update_table["url"] as string;
                            db_md5 = update_table["targetMd5"] as string;
                            db_ver = update_table["ver"] as string;
                            db_size = Convert.ToUInt64(update_table["targetSize"]);
                            mLatestVbn = "";//db_vbn;
                            break;
                        }
                    }
                }
            }

            Debug.Log(string.Format("最新数据：{0}", db_ver));

            if (string.IsNullOrEmpty(db_url))
            {
                string fail_reason = "OnGetDBVersion: db_url is null!";
                yield return NewInitSceneLoader.Instance.StartCoroutine(OnFail(fail_reason));
            }

            IBridge bridge = DBOSManager.getDBOSManager().getBridge();
            string targetPath = bridge.getGameResPath();
            string filePath = targetPath + ResNameMapping.Instance.GetTableFileName(true);
            string fileVerPath = targetPath + ResNameMapping.Instance.GetExVersionName(true);
            bool isEXVerExist = false;
            if (System.IO.File.Exists(fileVerPath))
            {
                isEXVerExist = true;
            }
            else
            {
                fileVerPath = Application.dataPath + "/Raw/" + ResNameMapping.Instance.GetExVersionName();
                if (System.IO.File.Exists(fileVerPath))
                {
                    isEXVerExist = true;
                }
            }

            // 检查配置表文件更新
            ControlServerLogHelper.Instance.PostPlayerFollowRecord(PlayerFollowRecordSceneId.Res2iOSUpdateCheckEnd, "", false);

            if (System.IO.File.Exists(filePath) && isEXVerExist)
            {
                string verstr = System.IO.File.ReadAllText(fileVerPath);
                Hashtable verTabel = MiniJSON.JsonDecode(verstr) as Hashtable;
                int localDBVer = int.Parse(verTabel["ver"] as string);

                if(int.Parse(db_ver) > localDBVer) // 使用版本号控制表格的更新
                {
                    // 下载配置表文件
                    ControlServerLogHelper.Instance.PostPlayerFollowRecord(PlayerFollowRecordSceneId.Res2iOSUpdateStart, "", false);
        
                    if (Const.Region != RegionType.CHINA)
                    {
                        var messagebox_ui = NewInitSceneLoader.Instance.MessageBoxUI;
                        if (messagebox_ui != null)
                        {
                            //GameDebug.LogError(string.Format("================= db_size = {0}", db_size));

                            float show_size = (int)(db_size * 10 / 1024 / 1024) / 10.0f;

                            var cur_network_state = Application.internetReachability;
                            if (cur_network_state == NetworkReachability.ReachableViaCarrierDataNetwork)
                            {
                                // wait messagebox 提示下载
                                //GameDebug.LogError("=================  test ios res2 1");
                                yield return NewInitSceneLoader.Instance.StartCoroutine(messagebox_ui.ShowRoutine(
                                    string.Format(xc.LocalizeManager.Instance.Localize.UpgradeNoWifiTips2, show_size), xc.LocalizeManager.Instance.Localize.BtnContinue, xc.TextHelper.BtnCancel));

                                if (messagebox_ui.Result == MessageBoxUI.EResult.Cancel)
                                {
                                    Application.Quit();
                                }
                            }
                            else
                            {
                                //GameDebug.LogError("================= test ios res2 2");
                                // wait messagebox 提示下载
                                yield return NewInitSceneLoader.Instance.StartCoroutine(messagebox_ui.ShowRoutine(
                                    string.Format(xc.LocalizeManager.Instance.Localize.UpgradeWithWifiTips, show_size), xc.TextHelper.BtnConfirm, xc.TextHelper.BtnCancel));

                                if (messagebox_ui.Result == MessageBoxUI.EResult.Cancel)
                                {
                                    Application.Quit();
                                }
                            }
                        }
                    }

                    //GameDebug.LogError("=================== test ios res2 3");

                    mCurProcess = 0.5f;
                    NewInitSceneLoader.Instance.SetProcess(mCurProcess);
                    NewInitSceneLoader.Instance.SetProcessText(xc.TextHelper.DBDownloading);
                    NewInitSceneLoader.Instance.AutoProcess(mCurProcess, xc.TextHelper.DBDownloading);
                    db_url = string.Format("{0}", db_url);

                    WWW www = new WWW(db_url);
                    yield return www;

                    Debug.Log("[DBManager][ParseUpdateInfo]start download db,url:" + db_url);
                    while(string.IsNullOrEmpty(www.error) == false)
                    {
                        // 下载配置表文件
                        ControlServerLogHelper.Instance.PostPlayerFollowRecord(PlayerFollowRecordSceneId.Res2iOSUpdateFail, www.error, false);

                        GameDebug.LogError("remote file download error, file: " + db_url);

                        var messagebox_ui = NewInitSceneLoader.Instance.MessageBoxUI;
                        if (messagebox_ui != null)
                        {
                            string str = xc.TextHelper.DBInitFailed;
                            yield return NewInitSceneLoader.Instance.StartCoroutine(messagebox_ui.ShowRoutine(str, xc.TextHelper.BtnConfirm));

                            if (messagebox_ui.Result == MessageBoxUI.EResult.OK)
                            {
                                // 下载配置表文件
                                ControlServerLogHelper.Instance.PostPlayerFollowRecord(PlayerFollowRecordSceneId.Res2iOSUpdateStart, "", false);

                                www = new WWW(db_url);
                                yield return www;
                            }
                        }
                        else
                        {
                            // 下载配置表文件
                            ControlServerLogHelper.Instance.PostPlayerFollowRecord(PlayerFollowRecordSceneId.Res2iOSUpdateStart, "", false);

                            www = new WWW(db_url);
                            yield return www;
                        }
                    }

                    while (CommonTool.GetMD5(www.bytes).ToLower() != db_md5.ToLower())
                    {
                        // 下载配置表文件
                        ControlServerLogHelper.Instance.PostPlayerFollowRecord(PlayerFollowRecordSceneId.Res2iOSUpdateFail, "Md5 Error", false);

                        GameDebug.LogError("remote file download error, file: " + db_url);

                        var messagebox_ui = NewInitSceneLoader.Instance.MessageBoxUI;
                        if (messagebox_ui != null)
                        {
                            string str = LocalizeManager.Instance.Localize.Md5Failed;
                            yield return NewInitSceneLoader.Instance.StartCoroutine(messagebox_ui.ShowRoutine(str, xc.TextHelper.BtnConfirm));

                            if (messagebox_ui.Result == MessageBoxUI.EResult.OK)
                            {
                                // 下载配置表文件
                                ControlServerLogHelper.Instance.PostPlayerFollowRecord(PlayerFollowRecordSceneId.Res2iOSUpdateStart, "", false);

                                www = new WWW(db_url);
                                yield return www;
                            }
                        }
                        else
                        {
                            // 下载配置表文件
                            ControlServerLogHelper.Instance.PostPlayerFollowRecord(PlayerFollowRecordSceneId.Res2iOSUpdateStart, "", false);

                            www = new WWW(db_url);
                            yield return www;
                        }
                    }
                    // 下载配置表文件
                    ControlServerLogHelper.Instance.PostPlayerFollowRecord(PlayerFollowRecordSceneId.Res2iOSUpdateEnd, "", false);

                    yield return NewInitSceneLoader.Instance.StartCoroutine(OnRemoteFileDownload(www.bytes));
                }
                else
                {
                    yield return NewInitSceneLoader.Instance.StartCoroutine(LoadAllDBAsset());
                }
            }
            else
            {
                string fail_reason = "OnGetDBVersion:" + filePath + " is not exist.";
                yield return NewInitSceneLoader.Instance.StartCoroutine(OnFail(fail_reason));
            }
        }

        /// <summary>
        /// step3：从服务器下载文件后，写入SD卡
        /// </summary>
        IEnumerator OnRemoteFileDownload(byte[] fileData)
        {
            IBridge bridge = DBOSManager.getDBOSManager().getBridge();
            string targetPath = bridge.getGameResPath();
            string filePath = targetPath + ResNameMapping.Instance.GetTableFileName(true);

            string dir = System.IO.Path.GetDirectoryName(filePath);
            if (!System.IO.Directory.Exists(dir))
                System.IO.Directory.CreateDirectory(dir);

            // 写入数据文件
            System.IO.FileStream stream = new System.IO.FileStream(filePath, System.IO.FileMode.Create, System.IO.FileAccess.Write);
            stream.Write(fileData, 0, fileData.Length);
            stream.Flush();
            stream.Close();

            // 写入版本信息
            string fileVerPath = targetPath + ResNameMapping.Instance.GetExVersionName(true);
            Dictionary<string, string> versionDict = new Dictionary<string, string>();
            versionDict["md5"] = db_md5;
            versionDict["ver"] = db_ver;
            Hashtable table = new Hashtable(versionDict);
            string str = MiniJSON.JsonEncode(table);
            System.IO.File.WriteAllText(fileVerPath, str);

            yield return NewInitSceneLoader.Instance.StartCoroutine(LoadAllDBAsset());
        }

        /// <summary>
        /// 拷贝文件失败后退出程序
        /// </summary>
        void OnClickQuitBtn()
        {
            Game.GetInstance().Quit(true);
        }
#endif
#endregion
    }
}