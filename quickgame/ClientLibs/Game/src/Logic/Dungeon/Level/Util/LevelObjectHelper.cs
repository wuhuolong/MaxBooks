using UnityEngine;
using SGameEngine;
using System.Collections;
using System.Collections.Generic;

namespace xc.Dungeon
{
    /// <summary>
    /// 关卡对象工具类
    /// </summary>
    public class LevelObjectHelper
    {
        /// <summary>
        /// 设置shape信息的Collider
        /// </summary>
        /// <param name="targetObject"></param>
        /// <param name="shapeInfo"></param>
        static public void SetObjectShapeCollider(GameObject targetObject, Neptune.ShapeInfo shapeInfo)
        {
            if (targetObject == null || shapeInfo == null)
            {
                Debug.LogError("[LevelObjectHelper SetObjectShapeCollider Error]: targetObject or shapeInfo is null");
                return;
            }

            switch (shapeInfo.Type)
            {
                case Neptune.ShapeType.SPHERE:
                    // 需要触发的时候才添加Collider组件
                    if(shapeInfo.IsTrigger)
                    {
                        var sphereCollider = targetObject.AddComponent<SphereCollider>();
                        sphereCollider.radius = shapeInfo.SphereRadius;
                        sphereCollider.isTrigger = true;
                    }
                    
                    break;

                case Neptune.ShapeType.BOX:
                    if(shapeInfo.IsTrigger)
                    {
                        var boxCollider = targetObject.AddComponent<BoxCollider>();
                        boxCollider.size = shapeInfo.BoxSize;
                        boxCollider.isTrigger = true;
                    }
                    
                    break;

                default:
                    Debug.LogError("[LevelObjectHelper SetObjectShapeCollider Error]: shapeType error");
                    break;
            }
        }

        /// <summary>
        /// 设置Prefab
        /// </summary>
        /// <param name="targetObject"></param>
        /// <param name="prefabInfo"></param>
        static public Coroutine SetObjectPrefab(GameObject targetObject, Neptune.NodePrefabInfo prefabInfo, System.Action finishCallback = null)
        {
            if (targetObject == null || prefabInfo == null)
            {
                Debug.LogError("[LevelObjectHelper SetObjectPrefab Error]: targetObject or prefabInfo is null");
                return null;
            }

            if (!string.IsNullOrEmpty(prefabInfo.PrefabFile))
            {
                return MainGame.HeartBehavior.StartCoroutine(CoSetObjectPrefab(targetObject, prefabInfo, finishCallback));
            }

            return null;
        }

        /// <summary>
        /// 设置Prefab协程函数
        /// </summary>
        /// <param name="targetObject"></param>
        /// <param name="prefabInfo"></param>
        /// <returns></returns>
        static private IEnumerator CoSetObjectPrefab(GameObject targetObject, Neptune.NodePrefabInfo prefabInfo, System.Action finishCallback)
        {
            PrefabResource prefabRes = new PrefabResource();
            string path = "Assets/" + prefabInfo.PrefabFile;
            yield return MainGame.HeartBehavior.StartCoroutine(SGameEngine.ResourceLoader.Instance.load_prefab(path, prefabRes));

            if (prefabRes == null || prefabRes.obj_ == null)
            {
                GameDebug.LogError("Set object prefab " + path + " error, can not load prefab!");
                yield break;
            }

            if (targetObject != null && prefabInfo != null)
            {
                Transform trans = prefabRes.obj_.transform;
                trans.parent = targetObject.transform;
                trans.localPosition = prefabInfo.LocalPosition;
                trans.localScale = prefabInfo.LocalScale;
                trans.localRotation = prefabInfo.LocalRotation;

                CollectionObjectBehaviour collectionObjectBehaviour = targetObject.GetComponent<CollectionObjectBehaviour>();
                if (collectionObjectBehaviour != null)
                {
                    collectionObjectBehaviour.OnResLoaded();
                }

                if (finishCallback != null)
                {
                    finishCallback();
                }
            }
            else
            {
                GameDebug.LogError("Set object prefab " + path + " error, target object is null!");
            }
        }

        /// <summary>
        /// 根据怪物组id获取怪物的位置
        /// </summary>
        /// <param name="id"></param>
        /// <param name="data"></param>
        /// <returns></returns>
        static public Vector3 GetMonsterPosition(uint id, Neptune.Data data = null)
        {
            if (data == null)
            {
                data = Neptune.DataManager.Instance.Data;
            }

            Neptune.MonsterBase monsterBase = data.GetNode<Neptune.MonsterBase>((int)id);
            if (monsterBase != null)
            {
                return monsterBase.Position;
            }

            return Vector3.zero;
        }

        /// <summary>
        /// 根据角色id获取怪物的位置
        /// </summary>
        static public List<Vector3> GetMonsterPositionsByActorId(uint actorId, Neptune.Data data = null)
        {
            if (data == null)
            {
                data = Neptune.DataManager.Instance.Data;
            }
            Dictionary<int, Neptune.BaseGenericNode> monsters = data.GetData<Neptune.MonsterBase>().Data;
            List<Vector3> retPositions = new List<Vector3>();
            retPositions.Clear();

            if (monsters != null)
            {
                foreach (var monsterBase in monsters.Values)
                {
                    if (monsterBase is Neptune.Monster)
                    {
                        Neptune.Monster monster = (Neptune.Monster)monsterBase;
                        if (monster != null && monster.ExcelId == actorId)
                        {
                            retPositions.Add(monster.Position);
                        }
                    }
                    else if (monsterBase is Neptune.MonsterGroup)
                    {
                        Neptune.MonsterGroup monsterGroup = (Neptune.MonsterGroup)monsterBase;
                        if (monsterGroup != null)
                        {
                            List<string> strs = DBManager.Instance.QuerySqliteField<string>(GlobalConfig.DBFile, "data_monster", "id", monsterGroup.ExcelId.ToString(), "actor");
                            foreach (string str in strs)
                            {
                                uint ret = 0;
                                uint.TryParse(str, out ret);
                                if (ret == actorId)
                                {
                                    retPositions.Add(monsterGroup.Position);
                                    break;
                                }
                            }
                        }
                    }
                }
            }

            return retPositions;
        }

        /// <summary>
        /// 根据角色id获取最近怪物的位置
        /// </summary>
        static public Vector3 GetNearestMonsterPositionByActorId(uint actorId, Neptune.Data data = null)
        {
            List<Vector3> posList = GetMonsterPositionsByActorId(actorId, data);
            Actor localPlayer = Game.GetInstance().GetLocalPlayer();
            if (localPlayer != null)
            {
                Vector3 nearestPos = Vector3.zero;
                Transform localPlayerTrans = localPlayer.transform;
                if (posList.Count > 0)
                {
                    float minDistance = Vector3.Distance(localPlayerTrans.position, posList[0]);
                    nearestPos = posList[0];
                    foreach (Vector3 pos in posList)
                    {
                        float distance = Vector3.Distance(localPlayerTrans.position, pos);
                        if (minDistance > distance)
                        {
                            minDistance = distance;
                            nearestPos = pos;
                        }
                    }
                    return nearestPos;
                }
                else
                {
                    return nearestPos;
                }
            }
            else if (posList.Count > 0)
            {
                return posList[0];
            }
            else
            {
                return Vector3.zero;
            }
        }

        /// <summary>
        /// 获取boss角色id列表
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        static public List<uint> GetBossMonsterList(Neptune.Data data = null)
        {
            if (data == null)
            {
                data = Neptune.DataManager.Instance.Data;
            }
            Dictionary<int, Neptune.BaseGenericNode> monsters = data.GetData<Neptune.MonsterBase>().Data;

            List<uint> actorIdList = new List<uint>();
            actorIdList.Clear();
            if (monsters != null)
            {
                foreach (var monsterBase in monsters.Values)
                {
                    if (monsterBase is Neptune.Monster)
                    {
                        Neptune.Monster monster = (Neptune.Monster)monsterBase;
                        if (ActorHelper.IsBoss(monster.ExcelId) == true)
                        {
                            actorIdList.Add(monster.ExcelId);
                        }
                    }
                }
            }

            return actorIdList;
        }

        /// <summary>
        /// 获取本地玩家到指定id的tag的距离
        /// </summary>
        /// <param name="id"></param>
        /// <param name="data"></param>
        /// <returns></returns>
        static public float GetDistanceBetweenLocalPlayerAndTag(uint id, Neptune.Data data = null)
        {
            if (data == null)
            {
                data = Neptune.DataManager.Instance.Data;
            }

            Actor localPlayer = Game.Instance.GetLocalPlayer();
            if (localPlayer == null)
            {
                return float.MaxValue;
            }

            Neptune.Tag tagInfo = data.GetNode<Neptune.Tag>((int)id);
            if (tagInfo != null)
            {
                return Vector3.Distance(localPlayer.ActorTrans.position, tagInfo.Position);
            }
            else
            {
                return float.MaxValue;
            }
        }

        /// <summary>
        /// 获取指定tag的位置
        /// </summary>
        /// <returns></returns>
        static public List<Vector3> GetTagPositionsByType(string type, Neptune.Data data = null)
        {
            if (data == null)
            {
                data = Neptune.DataManager.Instance.Data;
            }

            List<Vector3> posList = new List<Vector3>();
            posList.Clear();
            List<Neptune.Tag> tagList = Neptune.DataHelper.GetTagListByType(data, type);
            foreach (Neptune.Tag tag in tagList)
            {
                posList.Add(tag.Position);
            }

            return posList;
        }

        static public Vector3 GetTagPosition(uint id, Neptune.Data data = null)
        {
            if (data == null)
            {
                data = Neptune.DataManager.Instance.Data;
            }

            Neptune.Tag tagInfo = data.GetNode<Neptune.Tag>((int)id);
            if (tagInfo != null)
            {
                return tagInfo.Position;
            }

            return Vector3.zero;
        }

        /// <summary>
        /// 获取指定id和type的tag的位置
        /// </summary>
        /// <param name="idAndType">id和type的字符串组合，例如boss_pos_2</param>
        /// <param name="data"></param>
        /// <returns></returns>
        static public Vector3 GetTagPosition(string idAndType, Neptune.Data data = null)
        {
            if (data == null)
            {
                data = Neptune.DataManager.Instance.Data;
            }

            var tag_data = data.GetData<Neptune.Tag>().Data;

            // 解析idAndType中的id
            int id = -1;
            int digit_place = 1;
            int type_length = -1;
            int num_0 = (int)'0';
            for (int i = idAndType.Length - 1; i>=0; --i)
            {
                char c = idAndType[i];
                if (c >= '0' && c <= '9')
                {
                    if(id == -1)
                    {
                        id = digit_place * ((int)c - num_0);
                    }
                    else
                        id += digit_place * ((int)c - num_0);

                    digit_place *= 10;
                }
                else if (c == '_')
                {
                    type_length = i;
                    break;
                }
            }

            Neptune.BaseGenericNode node_info = null;
            if(!tag_data.TryGetValue(id, out node_info))
                return Vector3.zero;

            Neptune.Tag tag_info = node_info as Neptune.Tag;
            if (tag_info != null)
            {
                // 判断类型是否相同
                string type = tag_info.Type;
                for(int i = 0; i< type.Length  && i < type_length; ++i)
                {
                    char c1 = type[i];
                    char c2 = idAndType[i];
                    if (c1 != c2)
                        return Vector3.zero;
                }

                return tag_info.Position;
            }
            else
                return Vector3.zero;
        }

        static public Quaternion GetBornPosRotation(int key)
        {
            List<Neptune.Tag> tags = Neptune.DataHelper.GetTagListByType(Neptune.DataManager.Instance.Data, "born_pos");
            return tags[key-1].Rotation;
        }
    }
}
