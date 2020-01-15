using UnityEngine;
using System.Collections.Generic;
using xc;
using xc.Dungeon;

[wxb.Hotfix]
public class AIHelper
{
    public static bool IsInScreen(Vector3 pos)
    {
        Rect screenRect = Game.Instance.MainCamera.pixelRect;

        Vector3 screenPos = Game.Instance.MainCamera.WorldToScreenPoint(pos);

        if(screenPos.x >= screenRect.xMin && screenPos.x <= screenRect.xMax)
        {
            return true;
        }

        return false;
    }

    public static void WriteErrorLog(string log, BehaviourAI ai)
    {
        if(ai != null)
        {
            log = log + "|AI file:" + ai.AIFile;
        }

        GameDebug.LogError(log);
    }

    /// <summary>
    /// 两点距离的平方
    /// </summary>
    /// <param name="a"></param>
    /// <param name="b"></param>
    /// <returns></returns>
    public static float DistanceSquare(Vector3 a, Vector3 b)
    {
        a.y = 0f;
        b.y = 0f;
        return (a.x - b.x) * (a.x - b.x) + (a.y - b.y) * (a.y - b.y) + (a.z - b.z) * (a.z - b.z);
    }

    public static float ROUGHLY_EQUAL_PRECISION = 100.0F;

    /// <summary>
    /// 粗略的判断是否相等
    /// </summary>
    /// <param name="a"></param>
    /// <param name="b"></param>
    /// <returns></returns>
    public static bool RoughlyEqual(float a, float b)
    {
        int x1 = (int)(a * ROUGHLY_EQUAL_PRECISION);
        int x2 = (int)(b * ROUGHLY_EQUAL_PRECISION);

        if(x1 != x2)
        {
            return false;
        }

        return true;
    }
    /// <summary>
    /// 粗略的判断是否相等
    /// </summary>
    /// <param name="a"></param>
    /// <param name="b"></param>
    /// <returns></returns>
    public static bool RoughlyEqual(Vector3 a, Vector3 b)
    {
        bool result = RoughlyEqual(a.x, b.x);

        if(result)
        {
            //result = RoughlyEqual(a.y, b.y);

            if(result)
            {
                return RoughlyEqual(a.z, b.z);
            }
        }

        return false;
    }

    /// <summary>
    /// 粗略的判断目标坐标高度的是不是有点问题
    /// </summary>
    /// <returns></returns>
    private static bool TargetPositionHeightIsAbnormal(Vector3 source)
    {
        if(Mathf.Approximately(source.y, PhysicsHelp.ILLEGAL_HEIGHT))
        {
            return false;
        }

        return true;
    }

    public static Actor GetNearestActor(AIRunningProperty runningProperty, Dictionary<UnitID, Actor> actors, Vector3 targetPos)
    {
        if (actors == null || runningProperty == null)
        {
            return null;
        }

        Actor targetActor = null;

        float shortest = float.MaxValue;
        float viewRange = runningProperty.ViewRange * runningProperty.ViewRange;

        bool show_tips = false;
        // 计算出最短距离

        foreach (var item in actors)
        {
            if(item.Value == null)
            {
                continue;
            }

            if(item.Value.transform == null)
            {
                continue;
            }

            if(!TargetPositionHeightIsAbnormal(item.Value.transform.position))
            {
                continue;
            }

            if(runningProperty.SelfActor is LocalPlayer || runningProperty.SelfActor.ParentActor is LocalPlayer)
            {
                show_tips = false;
                if (PKModeManagerEx.Instance.IsLocalPlayerCanAttackActor(item.Value, ref show_tips) == false)
                {
                    continue;
                }
            }

            if (item.Value.IsDead() || (item.Value.gameObject.activeSelf == false))
            {
                continue;
            }

            if (item.Value.IsActorInvisiable)
            {
                continue;
            }

            if (item.Value is Pet)
            {
                continue;
            }

            if (item.Value.Camp == runningProperty.SelfActor.Camp)
            {
                continue;
            }

            float distanceSquare = AIHelper.DistanceSquare(targetPos, item.Value.transform.position);
            if (distanceSquare < shortest)
            {
                shortest = distanceSquare;
                targetActor = item.Value;
            }
        }

        if (shortest > viewRange)
        {
            targetActor = null;
        }

        return targetActor;
    }

    public static Actor GetNearestActor(AIRunningProperty runningProperty, Dictionary<UnitID, Actor> actors)
    {
        return GetNearestActor(runningProperty, actors, runningProperty.SelfActorPos);
    }

    /// <summary>
    /// 找出是boss的角色
    /// </summary>
    /// <param name="actors"></param>
    /// <returns></returns>
    public static Actor GetBossActor(Dictionary<UnitID, Actor> actors)
    {
        foreach (Actor actor in actors.Values)
        {
            if (actor.IsBoss() == true)
            {
                return actor;
            }
        }

        return null;
    }

    public static Actor GetParentNearestSummonMonsterTargetActor(AIRunningProperty runningProperty)
    {
        if (runningProperty == null)
        {
            return null;
        }

        Actor targetActor = null;

        float shortest = float.MaxValue;
        float viewRange = runningProperty.ViewRange * runningProperty.ViewRange;

        // 若开启了PK模式，同条件下，敌对玩家优先级高于怪物
        if (PKModeManagerEx.Instance.PKMode != GameConst.PK_MODE_PEACE)
        {
            targetActor = GetNearestActor(runningProperty, xc.ActorManager.Instance.PlayerSet, runningProperty.SelfActor.ParentActor.transform.position);
            if (targetActor == null)
            {
                targetActor = GetNearestActor(runningProperty, xc.ActorManager.Instance.MonsterSet, runningProperty.SelfActor.ParentActor.transform.position);
            }
        }
        else
        {
            Dictionary<UnitID, Actor> actors = xc.ActorManager.Instance.ActorSet;
            targetActor = GetNearestActor(runningProperty, actors, runningProperty.SelfActor.ParentActor.transform.position);
        }

        return targetActor;
    }

    public static Actor GetSelfNearestSummonMonsterTargetActor(AIRunningProperty runningProperty)
    {
        if (runningProperty == null)
        {
            return null;
        }

        Actor targetActor = null;

        float shortest = float.MaxValue;
        float viewRange = runningProperty.ViewRange * runningProperty.ViewRange;

        // 若开启了PK模式，同条件下，敌对玩家优先级高于怪物
        if (PKModeManagerEx.Instance.PKMode != GameConst.PK_MODE_PEACE)
        {
            targetActor = GetNearestActor(runningProperty, xc.ActorManager.Instance.PlayerSet, runningProperty.SelfActor.transform.position);
            if (targetActor == null)
            {
                targetActor = GetNearestActor(runningProperty, xc.ActorManager.Instance.MonsterSet, runningProperty.SelfActor.transform.position);
            }
        }
        else
        {
            Dictionary<UnitID, Actor> actors = xc.ActorManager.Instance.ActorSet;
            targetActor = GetNearestActor(runningProperty, actors, runningProperty.SelfActor.transform.position);
        }

        return targetActor;
    }

    public static Dictionary<UnitID, Actor> GetMonsterListByRange(Vector3 center, float radius)
    {
        Dictionary<UnitID, Actor> monsterList = new Dictionary<UnitID, Actor>();
        monsterList.Clear();
        Dictionary<UnitID, Actor> tempMonsters = ActorManager.Instance.MonsterSet;
        foreach (KeyValuePair<UnitID, Actor> kv in tempMonsters)
        {
            if (kv.Value.IsDead() == false && Vector3.Distance(kv.Value.transform.position, center) <= radius)
            {
                monsterList.Add(kv.Key, kv.Value);
            }
        }

        return monsterList;
    }

    public static Dictionary<UnitID, Actor> GetMonsterListByActorIdAndRange(uint actorId, Vector3 center, float radius)
    {
        Dictionary<UnitID, Actor> monsterList = new Dictionary<UnitID, Actor>();
        monsterList.Clear();
        Dictionary<UnitID, Actor> tempMonsters = ActorManager.Instance.GetMonsterSetByActorId(actorId);
        foreach (KeyValuePair<UnitID, Actor> kv in tempMonsters)
        {
            if (kv.Value.IsDead() == false && Vector3.Distance(kv.Value.transform.position, center) <= radius)
            {
                monsterList.Add(kv.Key, kv.Value);
            }
        }

        return monsterList;
    }

    /// <summary>
    /// 获取指定actor指定半径范围内的随机坐标
    /// </summary>
    public static Vector3 GetActorRangeRandomPosition(Actor actor, float nearRadius, float farRadius)
    {
        if (actor == null)
        {
            return Vector3.zero;
        }

        Vector3 actorPos = actor.transform.position;

        float radius = UnityEngine.Random.Range(nearRadius, farRadius);

        if (RoughlyEqual(radius, 0f) == true)
        {
            return actorPos;
        }

        float randomPosX = UnityEngine.Random.Range(actorPos.x - radius, actorPos.x + radius);
        float randomPosZ = UnityEngine.Mathf.Sqrt(radius * radius - (randomPosX - actorPos.x) * (randomPosX - actorPos.x)) + actorPos.z;

        return xc.PhysicsHelp.GetPosition(randomPosX, randomPosZ);
    }

    /// <summary>
    /// 找最近的可以寻路的触发器
    /// </summary>
    /// <param name="runningProperty"></param>
    /// <returns></returns>
    public static Vector3 GetNearestNeedNavigateColliderPosition(AIRunningProperty runningProperty)
    {
        if (runningProperty == null)
        {
            return Vector3.zero;
        }

        float shortest = float.MaxValue;
        Vector3 selfActorPos = runningProperty.SelfActorPos;
        Vector3 targetPos = Vector3.zero;

        List<xc.Dungeon.ColliderObject> colliderObjects = xc.Dungeon.ColliderObjectManager.Instance.GetNeedNavigateColliderObjects();
        foreach (xc.Dungeon.ColliderObject colliderObject in colliderObjects)
        {
            if (colliderObject == null || colliderObject.BindGameObject == null || colliderObject.BindGameObject.transform == null)
            {
                continue;
            }

            Vector3 pos = colliderObject.BindGameObject.transform.position;
            if (!TargetPositionHeightIsAbnormal(pos))
            {
                continue;
            }

            float distanceSquare = AIHelper.DistanceSquare(selfActorPos, pos);
            if (distanceSquare < shortest)
            {
                shortest = distanceSquare;
                targetPos = pos;
            }
        }

        return targetPos;
    }

    /// <summary>
    /// 找最近的可以自动采集的采集物
    /// </summary>
    /// <param name="runningProperty"></param>
    /// <returns></returns>
    public static CollectionObject GetNearstAutoCollectableCollectionObject(AIRunningProperty runningProperty)
    {
        if (runningProperty == null)
        {
            return null;
        }

        float shortest = float.MaxValue;
        Vector3 selfActorPos = runningProperty.SelfActorPos;
        CollectionObject retCollectionObject = null;

        Dictionary<int, CollectionObject> collectionObjects = xc.Dungeon.CollectionObjectManager.Instance.CollectionObjects;
        foreach (CollectionObject collectionObject in collectionObjects.Values)
        {
            if (collectionObject == null || collectionObject.BindGameObject == null || collectionObject.BindGameObject.transform == null)
            {
                continue;
            }

            CollectionObjectBehaviour collectionObjectBehaviour = collectionObject.BindGameObject.GetComponent<CollectionObjectBehaviour>();
            if (collectionObjectBehaviour == null)
            {
                continue;
            }

            // 婚宴食物是否能采集
            if (collectionObjectBehaviour.Class == "wedding_foods" && MarryManager.Instance.WeddingFoodsCanBeCollected == false)
            {
                continue;
            }

            // 婚宴宝箱是否能采集
            if (collectionObjectBehaviour.Class == "wedding_bos" && MarryManager.Instance.WeddingBoxCanBeCollected == false)
            {
                continue;
            }

            Vector3 pos = collectionObject.BindGameObject.transform.position;
            if (!TargetPositionHeightIsAbnormal(pos))
            {
                continue;
            }
            if (!InstanceHelper.CanWalkTo(pos))
            {
                continue;
            }

            float distanceSquare = AIHelper.DistanceSquare(selfActorPos, pos);
            if (distanceSquare < shortest)
            {
                shortest = distanceSquare;
                retCollectionObject = collectionObject;
            }
        }

        return retCollectionObject;
    }
}
