using UnityEngine;
using System.Collections.Generic;
using Neptune;
using Neptune.External;

namespace xc.Dungeon
{
    /// <summary>
    /// 采集物
    /// </summary>
    [wxb.Hotfix]
    public class CollectionObject : ILevelObject
    {
        /// <summary>
        /// 配置表内容
        /// </summary>
        Dictionary<string, string> mDBConfig = null;

        // 帮派BOSS火把组件
        GuildBossFireComponent mGuildBossFireComponent = null;

        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="data"></param>
        public CollectionObject(Neptune.Collection data)
        : base(data)
        {
            Init(data.Id, data.ExcelId);
        }

        public CollectionObject(int id, uint excelId, UnityEngine.Vector3 pos)
            : base(id, "Collection_" + id, pos, Quaternion.identity, Vector3.one)
        {
            Init(id, excelId);
        }

        public void Init(int id, uint excelId)
        {
            List<Dictionary<string, string>> dbs = DBManager.Instance.QuerySqliteRow<string>(GlobalConfig.DBFile, "data_collection", "id", excelId.ToString());
            if (dbs.Count > 0)
            {
                mDBConfig = dbs[0];
                // 帮派BOSS火把
                mGuildBossFireComponent = null;
                if (mDBConfig["class"] == "guild_boss_fire")
                {
                    mGuildBossFireComponent = gameObject.AddComponent<GuildBossFireComponent>();
                    mGuildBossFireComponent.Init((uint)id);
                }

                UpdateModel();

                var collectionObjectBehaviour = gameObject.AddComponent<CollectionObjectBehaviour>();
                collectionObjectBehaviour.Init((uint)id, excelId);

                // 头顶名字
                if (string.IsNullOrEmpty(mDBConfig["head_name"]) == false)
                {
                    UI3DText textComponent = gameObject.AddComponent<UI3DText>();
                    UI3DText.StyleInfo styleInfo = new UI3DText.StyleInfo();
                    styleInfo.Offset = DBTextResource.ParseVector3(mDBConfig["head_name_pos_offset"]);
                    textComponent.ResetStyleInfo(styleInfo);
                    textComponent.Text = mDBConfig["head_name"];
                }
            }

            ClientEventMgr.GetInstance().SubscribeClientEvent((int)ClientEvent.CE_SETTING_QUALITY_CHANGED, OnSettingQualityChanged);
        }

        public override void CleanUp()
        {
            ClientEventMgr.GetInstance().UnsubscribeClientEvent((int)ClientEvent.CE_SETTING_QUALITY_CHANGED, OnSettingQualityChanged);

            base.CleanUp();
        }

        /// <summary>
        /// 更新模型
        /// </summary>
        void UpdateModel()
        {
            DestroyModel();

            if (mDBConfig == null)
            {
                return;
            }

            NodePrefabInfo prefabInfo = new NodePrefabInfo();
            bool isMiddleRes = false;
            string haveMiddleResStr = mDBConfig["has_middle_res"];
            if (QualitySetting.GraphicLevel > 0 && string.IsNullOrEmpty(haveMiddleResStr) == false && haveMiddleResStr.Equals("1") == true)
            {
                isMiddleRes = true;
            }
            if (isMiddleRes == true)
            {
                prefabInfo.PrefabFile = "Res" + mDBConfig["res_path"] + "_middle.prefab";
            }
            else
            {
                prefabInfo.PrefabFile = "Res" + mDBConfig["res_path"] + ".prefab";
            }
            prefabInfo.LocalPosition = Vector3.zero;
            prefabInfo.LocalScale = Vector3.one;
            prefabInfo.LocalRotation = Quaternion.identity;
            mLoadPrefabCoroutine = LevelObjectHelper.SetObjectPrefab(gameObject, prefabInfo, () =>
            {
                if (mGuildBossFireComponent != null)
                {
                    mGuildBossFireComponent.OnResLoaded();
                }
            });
        }

        void OnSettingQualityChanged(CEventBaseArgs data)
        {
            UpdateModel();
        }
    }
}
