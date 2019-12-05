using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace xc.Dungeon
{
    public class DoorObjectManager : xc.Singleton<DoorObjectManager>
    {
        /// <summary>
        /// 门对象字典
        /// </summary>
        public Dictionary<int, DoorObject> DoorObjects;

        public DoorObjectManager()
        {
            DoorObjects = new Dictionary<int, DoorObject>();
            DoorObjects.Clear();
        }

        public void CreateAllDoorObjects()
        {
            foreach (Neptune.Door door in Neptune.DataManager.Instance.Data.GetData<Neptune.Door>().Data.Values)
            {
                if (door != null)
                {
                    if (door.SpawnDirectly == true)
                    {
                        CreateDoorObject(door);
                    }
                }
                else
                {
                    GameDebug.LogError("Create all door objects error, door is null!!!");
                }
            }
        }

        /// <summary>
        /// 创建门
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        public DoorObject CreateDoorObject(Neptune.Door data)
        {
            if (DoorObjects.ContainsKey(data.Id) == true)
            {
                GameDebug.LogError("Create collider object error, id " + data.Id + " has already exist!!!");
                return null;
            }

            DoorObject o = new DoorObject(data);
            if (o != null)
            {
                if (DoorObjects.ContainsKey(o.Id) == false)
                {
                    DoorObjects.Add(o.Id, o);
                }
                else
                {
                    GameDebug.LogError("Create collider object error, id " + o.Id + " has already exist!!!");
                }
            }
            return o;
        }

        public DoorObject CreateDoorObject(int id)
        {
            if (GetDoorObject(id) != null)
            {
                RemoveDoorObject(id);
            }
            Neptune.Door door = Neptune.DataManager.Instance.Data.GetNode<Neptune.Door>(id);
            if (door != null)
            {
                return CreateDoorObject(door);
            }

            return null;
        }

        /// <summary>
        /// 获取门
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public DoorObject GetDoorObject(int id)
        {
            DoorObject o = null;
            if (DoorObjects.TryGetValue(id, out o))
            {
                return o;
            }
            return o;
        }

        /// <summary>
        /// 移除门
        /// </summary>
        /// <param name="id"></param>
        public void RemoveDoorObject(int id)
        {
            DoorObject o = GetDoorObject(id);
            if (o != null)
            {
                o.CleanUp();
            }
            DoorObjects.Remove(id);
        }

        /// <summary>
        /// 移除所有门
        /// </summary>
        public void RemoveAllDoorObjects()
        {
            foreach (DoorObject o in DoorObjects.Values)
            {
                o.CleanUp();
            }
            DoorObjects.Clear();
        }
    }
}
