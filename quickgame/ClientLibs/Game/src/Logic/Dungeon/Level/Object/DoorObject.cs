using UnityEngine;
using System.Collections.Generic;
using Neptune;
using Neptune.External;

namespace xc.Dungeon
{
    /// <summary>
    /// 门
    /// </summary>
    public class DoorObject : ILevelObject
    {
        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="data"></param>
        public DoorObject(Neptune.Door data)
        : base(data)
        {
            List<string> prefabPaths = DBManager.Instance.QuerySqliteField<string>(GlobalConfig.DBFile, "data_door", "id", data.ExcelId.ToString(), "res_path");
            if (prefabPaths.Count > 0)
            {
                NodePrefabInfo prefabInfo = new NodePrefabInfo();
                prefabInfo.PrefabFile = "Res" + prefabPaths[0] + ".prefab";
                prefabInfo.LocalPosition = Vector3.zero;
                prefabInfo.LocalScale = Vector3.one;
                prefabInfo.LocalRotation = Quaternion.identity;
                mLoadPrefabCoroutine = LevelObjectHelper.SetObjectPrefab(gameObject, prefabInfo);
            }

            xc.Dungeon.LevelManager.Instance.SetAreaClose(1 << (1 + data.Flag));
        }

        public override void CleanUp()
        {
            Neptune.Door data = rawData as Neptune.Door;
            if (data != null)
            {
                xc.Dungeon.LevelManager.Instance.SetAreaOpen(1 << (1 + data.Flag));
            }

            base.CleanUp();
        }
    }
}
