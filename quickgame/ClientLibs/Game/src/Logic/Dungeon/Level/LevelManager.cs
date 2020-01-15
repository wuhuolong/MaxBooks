using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using SGameEngine;

namespace xc.Dungeon
{
    public class LevelManager : xc.Singleton<LevelManager>
    {
        public ushort AreaExclude { set; get; }

        protected const ushort mAreaDefault = 0;

        /// <summary>
        /// 当前已经加载好的Navmesh文件路径
        /// </summary>
        private string mCurNavmeshFile = string.Empty;

        /// <summary>
        /// 是否在加载Navmesh文件
        /// </summary>
        public bool IsLoadingNavmeshFile = false;

        public LevelManager()
        {
            AreaExclude = mAreaDefault;
        }

        public void SetAreaOpen(int flag)
        {
            int val = AreaExclude;
            AreaExclude = (ushort)(val & ~flag);
        }

        public void SetAreaClose(int flag)
        {
            int val = AreaExclude;
            AreaExclude = (ushort)(val | flag);
        }

        /// <summary>
        /// id转路径
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        private string Id2Path(uint id)
        {
            return string.Format("Assets/Res/DB/Nep/data_nep_{0}.json", id); 
        }

        /// <summary>
        /// 加载关卡配置
        /// </summary>
        /// <param name="id"></param>
        public void LoadLevelFile(uint stage_id, bool async)
        {
            string path = Id2Path(stage_id);
            LoadLevelFile(path, async);

            //Debug.LogError("test navmesh .........");

            uint map_id = SceneHelp.GetMapIdByStageId(stage_id);
            string navmesh_file = "Assets/Res/NavMesh/" + map_id.ToString() + ".txt";
            if (mCurNavmeshFile.Equals(navmesh_file) == false)
            {
                IsLoadingNavmeshFile = true;

                MainGame.HeartBehavior.StartCoroutine(CoLoadNavmeshFile(navmesh_file));
            }
        }

        /// <summary>
        /// 加载关卡配置
        /// </summary>
        /// <param name="path"></param>
        private void LoadLevelFile(string path, bool async)
        {
#if UNITY_EDITOR
            if (!System.IO.File.Exists(path))
            {
                Neptune.DataManager.Instance.Data.Clear();
                return;
            }
#endif

            Neptune.Data data = null;
            if (data == null)
            {
                if (async)
                {
                    MainGame.HeartBehavior.StartCoroutine(CoLoadLevelFile(path));
                }
                else
                {
                    data = LoadLevelFileTemporary(path);
                    OnLevelLoadFinished(data);
                }
            }
            else
            {
                OnLevelLoadFinished(data);
            }
        }

        /// <summary>
        /// 协程加载关卡配置
        /// </summary>
        /// <param name="path"></param>
        /// <returns></returns>\
        private IEnumerator CoLoadLevelFile(string path)
        {
            SGameEngine.AssetResource result = new SGameEngine.AssetResource();

            yield return MainGame.HeartBehavior.StartCoroutine(SGameEngine.ResourceLoader.Instance.load_asset(path, typeof(TextAsset), result));

            if (result.asset_ == null)
            {
                yield break;
            }

            TextAsset textAsset = result.asset_ as TextAsset;
            if (textAsset == null || textAsset.text == null)
            {
                result.destroy();
                Debug.LogError("LevelManager::CoLoadLevelFile, can not read level file:" + path);
                yield break;
            }

            Neptune.Data data = new Neptune.Data();
            FullSerializer.fsData fsdata = FullSerializer.fsJsonParser.Parse(textAsset.text);
            var serializer = new FullSerializer.fsSerializer();
            var processor = new Neptune.FileSerializerProcessor();
            serializer.AddProcessor(processor);
            serializer.TryDeserialize<Neptune.Data>(fsdata, ref data);

            if (data == null)
            {
                result.destroy();
                yield break;
            }

            OnLevelLoadFinished(data);
            ObjCachePoolMgr.Instance.RecycleCSharpObject(data, ObjCachePoolType.JSON, path);

            result.destroy();
        }

        private IEnumerator CoLoadNavmeshFile(string path)
        {
            SGameEngine.AssetResource result = new SGameEngine.AssetResource();

            yield return MainGame.HeartBehavior.StartCoroutine(SGameEngine.ResourceLoader.Instance.load_asset(path, typeof(TextAsset), result));

            // 加载好的数据是否是当前场景的数据
            uint stage_id = SceneHelp.GetFirstStageId(SceneHelp.Instance.CurSceneID);
            uint map_id = SceneHelp.GetMapIdByStageId(stage_id);
            string navmesh_file = "Assets/Res/NavMesh/" + map_id.ToString() + ".txt";
            if (navmesh_file.Equals(path) == false)
            {
                yield break;
            }

            if (result.asset_ == null)
            {
                IsLoadingNavmeshFile = false;
                yield break;
            }

            TextAsset textAsset = result.asset_ as TextAsset;
            if (textAsset == null || textAsset.text == null)
            {
                IsLoadingNavmeshFile = false;
                Debug.LogError("LevelManager::CoLoadNavmeshFile, can not read navmesh file:" + path);
                yield break;
            }

            bool ret = XNavMesh.LoadBuffer(textAsset.bytes);
            if (!ret)
            {
                mCurNavmeshFile = string.Empty;
                GameDebug.LogError("navmesh LoadBuffer error : " + path);
            }
            else
            {
                mCurNavmeshFile = path;
            }

            result.destroy();

            IsLoadingNavmeshFile = false;
        }

        /// <summary>
        /// 临时的加载回调
        /// </summary>
        /// <param name="data"></param>
        private void OnLevelLoadFinished(Neptune.Data data)
        {
            if (data == null)
                return;

            AreaExclude = mAreaDefault;
            Neptune.DataManager.Instance.Data = data;
        }

        /// <summary>
        /// 缓存最近3个场景的关卡数据
        /// </summary>
        Dictionary<string, Neptune.Data> m_NepCache = new Dictionary<string, Neptune.Data>();
        Queue<string> m_NepPath = new Queue<string>(3);

        Neptune.Data LoadLevelFileTemporary(string path)
        {
            Neptune.Data data = null;
            if(m_NepCache.TryGetValue(path, out data))
            {
                return data;
            }

            string text = DBManager.Instance.LoadDBFile(path.Replace("Assets/Res/", ""));
            if (string.IsNullOrEmpty(text) == true)
            {
                return null;
            }
            data = new Neptune.Data();
            FullSerializer.fsData fsdata = FullSerializer.fsJsonParser.Parse(text);
            var serializer = new FullSerializer.fsSerializer();
            var processor = new Neptune.FileSerializerProcessor();
            serializer.AddProcessor(processor);
            serializer.TryDeserialize<Neptune.Data>(fsdata, ref data);
            if (data == null)
            {
                return null;
            }

            if(m_NepCache.Count >= 3)
            {
                string first_path = m_NepPath.Dequeue();
                m_NepCache.Remove(first_path);
            }

            m_NepCache[path] = data;
            m_NepPath.Enqueue(path);

            return data;
        }

        /// <summary>
        /// 加载一份数据做临时用，同步的
        /// </summary>
        public Neptune.Data LoadLevelFileTemporary(uint id)
        {
            string path = Id2Path(id);
            return LoadLevelFileTemporary(path);
        }
    }
}
