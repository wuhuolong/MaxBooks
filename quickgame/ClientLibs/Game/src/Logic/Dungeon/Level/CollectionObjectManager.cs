using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Net;
using xc.protocol;

namespace xc.Dungeon
{
    public class CollectionObjectManager : xc.Singleton<CollectionObjectManager>
    {
        /// <summary>
        /// 采集物对象字典
        /// </summary>
        public Dictionary<int, CollectionObject> CollectionObjects;

        private bool enable = true;

        public CollectionObjectManager()
        {
            CollectionObjects = new Dictionary<int, CollectionObject>();
            CollectionObjects.Clear();
        }

        public void RegisterMessages()
        {
            Game.GetInstance().SubscribeNetNotify(NetMsg.MSG_NWAR_BAR_APPEAR, HandleServerData);
            Game.GetInstance().SubscribeNetNotify(NetMsg.MSG_NWAR_BAR_DISAPPEAR, HandleServerData);
        }

        public void CreateAllCollectionObjects()
        {
            foreach (Neptune.Collection collection in Neptune.DataManager.Instance.Data.GetData<Neptune.Collection>().Data.Values)
            {
                if (collection != null)
                {
                    if (collection.SpawnDirectly == true)
                    {
                        CreateCollectionObject(collection);
                    }
                }
                else
                {
                    GameDebug.LogError("Create all collection objects error, collection is null!!!");
                }
            }

            ClientEventMgr.Instance.FireEvent((int)ClientEvent.CE_COLLECTION_OBJECTS_COUNT_CHANGED, null);
        }

        /// <summary>
        /// 创建采集物
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        public CollectionObject CreateCollectionObject(Neptune.Collection data)
        {
            if (CollectionObjects.ContainsKey(data.Id) == true)
            {
                GameDebug.LogError("Create collection object error, id " + data.Id + " has already exist!!!");
                return null;
            }

            CollectionObject o = new CollectionObject(data);
            if (o != null)
            {
                if (CollectionObjects.ContainsKey(o.Id) == false)
                {
                    CollectionObjects.Add(o.Id, o);
                }
                else
                {
                    GameDebug.LogError("Add collection object error, id " + o.Id + " has already exist!!!");
                }
            }
            return o;
        }

        public CollectionObject CreateCollectionObject(int id)
        {
            if (GetCollectionObject(id) != null)
            {
                RemoveCollectionObject(id);
            }
            Neptune.Collection collection = Neptune.DataManager.Instance.Data.GetNode<Neptune.Collection>(id);
            if (collection != null)
            {
                collection.Position = PhysicsHelp.GetPosition(collection.Position.x, collection.Position.z);
                return CreateCollectionObject(collection);
            }

            return null;
        }

        public CollectionObject CreateCollectionObject(int id, uint excelId, UnityEngine.Vector3 pos)
        {
            CollectionObject o = new CollectionObject(id, excelId, pos);
            if (o != null)
            {
                if (CollectionObjects.ContainsKey(o.Id) == false)
                {
                    CollectionObjects.Add(o.Id, o);
                }
                else
                {
                    GameDebug.LogError("Create collection object error, id " + o.Id + " has already exist!!!");
                }
            }
            return o;
        }

        /// <summary>
        /// 获取采集物
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public CollectionObject GetCollectionObject(int id)
        {
            CollectionObject o = null;
            if (CollectionObjects.TryGetValue(id, out o))
            {
                return o;
            }
            return o;
        }

        /// <summary>
        /// 移除采集物
        /// </summary>
        /// <param name="id"></param>
        public void RemoveCollectionObject(int id)
        {
            CollectionObject o = GetCollectionObject(id);
            if (o != null)
            {
                o.CleanUp();
            }
            CollectionObjects.Remove(id);
        }

        /// <summary>
        /// 移除所有采集物
        /// </summary>
        public void RemoveAllCollectionObjects()
        {
            foreach (CollectionObject o in CollectionObjects.Values)
            {
                o.CleanUp();
            }
            CollectionObjects.Clear();

            ClientEventMgr.Instance.FireEvent((int)ClientEvent.CE_COLLECTION_OBJECTS_COUNT_CHANGED, null);
        }

        /// <summary>
        /// 采集物数量
        /// </summary>
        public int CollectionObjectsCount
        {
            get
            {
                return CollectionObjects.Count;
            }
        }

        void HandleServerData(ushort protocol, byte[] data)
        {
            switch (protocol)
            {
                case NetMsg.MSG_NWAR_BAR_APPEAR:
                    {
                        S2CNwarBarAppear pack = S2CPackBase.DeserializePack<S2CNwarBarAppear>(data);

                        foreach (PkgNwarBarPos barPos in pack.poss)
                        {
                            if (GetCollectionObject((int)(barPos.bar_id)) != null)
                            {
                                RemoveCollectionObject((int)(barPos.bar_id));
                            }
                            Neptune.Collection collection = Neptune.DataManager.Instance.Data.GetNode<Neptune.Collection>((int)(barPos.bar_id));
                            if (collection != null)
                            {
                                collection.ExcelId = barPos.type;
                                collection.Position = PhysicsHelp.GetPosition(barPos.pos.px * GlobalConst.UnitScale, barPos.pos.py * GlobalConst.UnitScale);
                                CreateCollectionObject(collection);
                            }
                            else
                            {
                                CreateCollectionObject((int)barPos.bar_id, barPos.type, PhysicsHelp.GetPosition(barPos.pos.px * GlobalConst.UnitScale, barPos.pos.py * GlobalConst.UnitScale));
                            }
                        }

                        ClientEventMgr.Instance.FireEvent((int)ClientEvent.CE_COLLECTION_OBJECTS_COUNT_CHANGED, null);

                        break;
                    }
                case NetMsg.MSG_NWAR_BAR_DISAPPEAR:
                    {
                        S2CNwarBarDisappear pack = S2CPackBase.DeserializePack<S2CNwarBarDisappear>(data);

                        RemoveCollectionObject((int)(pack.bar_id));

                        ClientEventMgr.Instance.FireEvent((int)ClientEvent.CE_COLLECTION_OBJECTS_COUNT_CHANGED, null);

                        break;
                    }
                default:
                    break;
            }
        }

        public class ShowCollectionBarData
        {
            public string mInteractButtonText;
            public string mInteractButtonPic;
            public uint mId;
        }
        List<ShowCollectionBarData> mBarDataArray = new List<ShowCollectionBarData>();
        /// <summary>
        /// 
        /// </summary>
        /// <param name="mInteractButtonText"></param>
        /// <param name="mInteractButtonPic"></param>
        /// <param name="mId"></param>
        public void ShowCollectionBar(string mInteractButtonText, string mInteractButtonPic, uint mId)
        {
            for (int index = 0; index < mBarDataArray.Count; ++index)
            {
                if (mBarDataArray[index].mId == mId)
                    return;
            }
            ShowCollectionBarData tmp_data = new ShowCollectionBarData();
            tmp_data.mId = mId;
            tmp_data.mInteractButtonPic = mInteractButtonPic;
            tmp_data.mInteractButtonText = mInteractButtonText;
            mBarDataArray.Add(tmp_data);
            RefreshCollection();
        }

        public void HideCollectionBar(uint mId)
        {
            for (int index = 0; index < mBarDataArray.Count; ++index)
            {
                if (mBarDataArray[index].mId == mId)
                {
                    mBarDataArray.RemoveAt(index);
                    if (index == 0)
                    {//当前显示的进度条ID应该隐藏
                        RefreshCollection();
                    }
                    break;
                }
            }
        }

        void RefreshCollection()
        {
            if (mBarDataArray.Count > 0)
            {//需要显示进度条
                ClientEventMgr.Instance.FireEvent((int)ClientEvent.SHOW_INTERACT_BUTTON, new CEventEventParamArgs(true, mBarDataArray[0].mInteractButtonText, mBarDataArray[0].mInteractButtonPic, mBarDataArray[0].mId));
            }
            else
            {
                ClientEventMgr.Instance.FireEvent((int)ClientEvent.SHOW_INTERACT_BUTTON, new CEventEventParamArgs(false, "", "", 0));
            }
        }

        public bool Enable
        {
            get
            {
                return enable;
            }
            set
            {
                enable = value;
                if(!enable)
                {
                    mBarDataArray.Clear();
                    RefreshCollection();
                }
            }
        }
    }
}
