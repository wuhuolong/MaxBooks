using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace xc.Dungeon
{
    public class ColliderObjectManager : xc.Singleton<ColliderObjectManager>
    {
        /// <summary>
        /// 区域对象字典
        /// </summary>
        public Dictionary<int, ColliderObject> ColliderObjects;

        /// <summary>
        /// 已经触发过的触发器
        /// </summary>
        List<int> mTriggeredColliderObjectIds;

        public ColliderObjectManager()
        {
            ColliderObjects = new Dictionary<int, ColliderObject>();
            ColliderObjects.Clear();

            mTriggeredColliderObjectIds = new List<int>();
            mTriggeredColliderObjectIds.Clear();

            ClientEventMgr.Instance.SubscribeClientEvent((int)ClientEvent.CE_CHANGE_LOCALPLAYER_RADIUS, OnChangeLocalPlayerRadius);
            ClientEventMgr.Instance.SubscribeClientEvent((int)ClientEvent.CE_START_SWITCHSCENE, OnStartSwitchScene);
            ClientEventMgr.Instance.SubscribeClientEvent((int)ClientEvent.TASK_FINISHED, OnTaskFinished);
        }

        public void CreateAllColliderObjects()
        {
            foreach (Neptune.Collider collider in Neptune.DataManager.Instance.Data.GetData<Neptune.Collider>().Data.Values)
            {
                if (collider != null)
                {
                    if (collider.SpawnDirectly == true)
                    {
                        CreateColliderObject(collider);
                    }
                }
                else
                {
                    GameDebug.LogError("Create all collider objects error, collider is null!!!");
                }
            }
        }

        /// <summary>
        /// 创建区域
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        public ColliderObject CreateColliderObject(Neptune.Collider data)
        {
            if (ColliderObjects.ContainsKey(data.Id) == true)
            {
                GameDebug.LogError("Create collider object error, id " + data.Id + " has already exist!!!");
                return null;
            }

            // 已经触发过的的LifeTime是ONCE的触发器不再创建
            if (data.LifeTime == Neptune.Collider.ETypeLifeTime.ONCE && mTriggeredColliderObjectIds.Contains(data.Id) == true)
            {
                return null;
            }

            // 前置任务未完成不创建
            if (data.PreMainTaskId > 0 && TaskHelper.MainTaskIsPassed(data.PreMainTaskId) == false)
            {
                return null;
            }

            ColliderObject o = new ColliderObject(data);
            if (o != null)
            {
                //o.SetLocalPlayerRadius(Game.Instance.LocalPlayerRadius);
                if (ColliderObjects.ContainsKey(o.Id) == false)
                {
                    ColliderObjects.Add(o.Id, o);
                }
                else
                {
                    GameDebug.LogError("Add collider object error, id " + o.Id + " has already exist!!!");
                }
            }
            return o;
        }

        public ColliderObject CreateColliderObject(int id)
        {
            Neptune.Collider collider = Neptune.DataManager.Instance.Data.GetNode<Neptune.Collider>(id);
            if (collider == null)
            {
                GameDebug.LogError("Create collider object error, id " + id + " can not find!!!");
                return null;
            }

            return CreateColliderObject(collider);
        }

        /// <summary>
        /// 获取区域
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public ColliderObject GetColliderObject(int id)
        {
            ColliderObject o = null;
            if (ColliderObjects.TryGetValue(id, out o))
            {
                return o;
            }
            return o;
        }

        public List<ColliderObject> GetNeedNavigateColliderObjects()
        {
            List<ColliderObject> colliderObjects = new List<ColliderObject>();
            colliderObjects.Clear();

            foreach (ColliderObject colliderObject in ColliderObjects.Values)
            {
                if (colliderObject.NeedNavigate == true)
                {
                    colliderObjects.Add(colliderObject);
                }
            }
            return colliderObjects;
        }

        /// <summary>
        /// 获取ColliderObjectBehaviour组件
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public ColliderObjectBehaviour GetColliderObjectBehaviour(int id)
        {
            ColliderObject o = GetColliderObject(id);
            if (o != null && o.BindGameObject != null)
            {
                var behaviour = o.BindGameObject.GetComponent<ColliderObjectBehaviour>();
                if (behaviour != null)
                {
                    return behaviour;
                }
            }
            return null;
        }

        /// <summary>
        /// 移除区域
        /// </summary>
        /// <param name="id"></param>
        public void RemoveColliderObject(int id)
        {
            ColliderObject o = GetColliderObject(id);
            if (o != null)
            {
                o.CleanUp();
            }
            ColliderObjects.Remove(id);
        }

        /// <summary>
        /// 移除所有区域
        /// </summary>
        public void RemoveAllColliderObjects()
        {
            foreach (ColliderObject o in ColliderObjects.Values)
            {
                o.CleanUp();
            }
            ColliderObjects.Clear();
        }

        public void TriggerColliderObject(int id)
        {
            if (mTriggeredColliderObjectIds.Contains(id) == false)
            {
                mTriggeredColliderObjectIds.Add(id);
            }
        }

        void OnChangeLocalPlayerRadius(CEventBaseArgs data)
        {
            foreach(var item in ColliderObjects)
            {
                //if(item.Value != null)
                //    item.Value.SetLocalPlayerRadius(Game.Instance.LocalPlayerRadius);
            }
        }

        void OnStartSwitchScene(CEventBaseArgs data)
        {
            mTriggeredColliderObjectIds.Clear();
        }

        void OnTaskFinished(CEventBaseArgs data)
        {
            var taskId = (uint)(data.arg);
            foreach (Neptune.Collider collider in Neptune.DataManager.Instance.Data.GetData<Neptune.Collider>().Data.Values)
            {
                if (collider != null)
                {
                    if (collider.PreMainTaskId == taskId)
                    {
                        CreateColliderObject(collider);
                    }
                }
            }
        }
    }
}
