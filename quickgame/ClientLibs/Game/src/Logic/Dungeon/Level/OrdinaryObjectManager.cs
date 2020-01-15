using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace xc.Dungeon
{
    public class OrdinaryObjectManager : xc.Singleton<OrdinaryObjectManager>
    {
        /// <summary>
        /// 普通节点对象字典
        /// </summary>
        public Dictionary<int, OrdinaryObjectObject> OrdinaryObjects;

        public OrdinaryObjectManager()
        {
            OrdinaryObjects = new Dictionary<int, OrdinaryObjectObject>();
            OrdinaryObjects.Clear();
        }

        public void CreateAllOrdinaryObjects()
        {
            foreach (Neptune.OrdinaryObject ordinary in Neptune.DataManager.Instance.Data.GetData<Neptune.OrdinaryObject>().Data.Values)
            {
                if (ordinary != null)
                {
                    if (ordinary.SpawnDirectly == true)
                    {
                        CreateOrdinaryObject(ordinary);
                    }
                }
                else
                {
                    GameDebug.LogError("Create all ordinary objects error, ordinary object is null!!!");
                }
            }
        }

        /// <summary>
        /// 创建普通节点对象
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        public OrdinaryObjectObject CreateOrdinaryObject(Neptune.OrdinaryObject data)
        {
            if (OrdinaryObjects.ContainsKey(data.Id) == true)
            {
                GameDebug.LogError("Create ordinary object error, id " + data.Id + " has already exist!!!");
                return null;
            }

            OrdinaryObjectObject o = new OrdinaryObjectObject(data);
            if (o != null)
            {
                if (OrdinaryObjects.ContainsKey(o.Id) == false)
                {
                    OrdinaryObjects.Add(o.Id, o);
                }
                else
                {
                    GameDebug.LogError("Add ordinary object error, id " + o.Id + " has already exist!!!");
                }
            }
            return o;
        }

        public OrdinaryObjectObject CreateOrdinaryObject(int id)
        {
            OrdinaryObjectObject o = GetOrdinaryObject(id);
            if (o != null)
            {
                return o;
            }
            Neptune.OrdinaryObject ordinary = Neptune.DataManager.Instance.Data.GetNode<Neptune.OrdinaryObject>(id);
            if (ordinary != null)
            {
                return CreateOrdinaryObject(ordinary);
            }
            return null;
        }

        /// <summary>
        /// 获取普通节点对象
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public OrdinaryObjectObject GetOrdinaryObject(int id)
        {
            OrdinaryObjectObject o = null;
            if (OrdinaryObjects.TryGetValue(id, out o))
            {
                return o;
            }
            return o;
        }

        /// <summary>
        /// 移除普通节点对象
        /// </summary>
        /// <param name="id"></param>
        public void RemoveOrdinaryObject(int id)
        {
            OrdinaryObjectObject o = GetOrdinaryObject(id);
            if (o != null)
            {
                o.CleanUp();
            }
            if (OrdinaryObjects.ContainsKey(id) == true)
            {
                OrdinaryObjects.Remove(id);
            }
        }

        /// <summary>
        /// 移除所有普通节点对象
        /// </summary>
        public void RemoveAllOrdinaryObjects()
        {
            foreach (OrdinaryObjectObject o in OrdinaryObjects.Values)
            {
                o.CleanUp();
            }
            OrdinaryObjects.Clear();
        }
    }
}
