//------------------------------------------------------------------------------
// Desc   :  掉落逻辑
// Author :  ljy
// Date   :  2017.6.20
//------------------------------------------------------------------------------
using Net;
using System.Collections.Generic;
using UnityEngine;
using System.Collections;
using xc.protocol;

namespace xc.instance_behaviour
{
    [wxb.Hotfix]
    public class DropBehaviour : Behaviour
    {
        protected Vector3 mDropPosition;
        protected List<Utils.Timer> mTimerList;

        List<Coroutine> mLoadDropPrefabCoroutine;

        /// <summary>
        /// 飘字CD计时器
        /// </summary>
        private Utils.Timer mFloatTipsTimer;

        /// <summary>
        /// 飘字CD长度(秒)
        /// </summary>
        private float mFloatTipsCD;

        public static string DropObjectPrefabPoolKey = "DropObject";
        public static ObjCachePoolType DropPrefabPoolType = ObjCachePoolType.DROP_PREFAB;

        public override void Enter(params object[] param)
        {
            Game.GetInstance().SubscribeNetNotify(NetMsg.MSG_NWAR_DROP, HandleServerData);
            Game.GetInstance().SubscribeNetNotify(NetMsg.MSG_NWAR_PICK, HandleServerData);
            Game.GetInstance().SubscribeNetNotify(NetMsg.MSG_NWAR_PICK_FAIL, HandleServerData);

            ClientEventMgr.GetInstance().SubscribeClientEvent((int)ClientEvent.CE_MONSTERDEAD, OnMonsterDead);
            ClientEventMgr.GetInstance().SubscribeClientEvent((int)ClientEvent.CE_PICK_DROP, OnPickDrop);
            ClientEventMgr.GetInstance().SubscribeClientEvent((int)ClientEvent.CE_DESTROY_DROP, OnDestroyDrop);
            ClientEventMgr.GetInstance().SubscribeClientEvent((int)ClientEvent.CE_SHOW_PICK_DROP_FLOAT_TIPS, OnShowPickDropFloatTips);

            mTimerList = new List<Utils.Timer>();
            mTimerList.Clear();

            mLoadDropPrefabCoroutine = new List<Coroutine>();
            mLoadDropPrefabCoroutine.Clear();

            mFloatTipsCD = GameConstHelper.GetFloat("GAME_MWAR_DROP_FLOAT_TIPS_CD");
        }


        public override void Exit()
        {
            InstanceDropManager.Instance.DestroyAllDrops();

            Game.GetInstance().UnsubscribeNetNotify(NetMsg.MSG_NWAR_DROP, HandleServerData);
            Game.GetInstance().UnsubscribeNetNotify(NetMsg.MSG_NWAR_PICK, HandleServerData);
            Game.GetInstance().UnsubscribeNetNotify(NetMsg.MSG_NWAR_PICK_FAIL, HandleServerData);

            ClientEventMgr.GetInstance().UnsubscribeClientEvent((int)ClientEvent.CE_MONSTERDEAD, OnMonsterDead);
            ClientEventMgr.GetInstance().UnsubscribeClientEvent((int)ClientEvent.CE_PICK_DROP, OnPickDrop);
            ClientEventMgr.GetInstance().UnsubscribeClientEvent((int)ClientEvent.CE_DESTROY_DROP, OnDestroyDrop);
            ClientEventMgr.GetInstance().UnsubscribeClientEvent((int)ClientEvent.CE_SHOW_PICK_DROP_FLOAT_TIPS, OnShowPickDropFloatTips);

            if (mTimerList != null)
            {
                foreach (var timer in mTimerList)
                {
                    if (timer != null)
                        timer.Destroy();
                }
            }
            else
                mTimerList = new List<Utils.Timer>();

            mTimerList.Clear();

            if (mLoadDropPrefabCoroutine != null && mLoadDropPrefabCoroutine.Count > 0)
            {
                foreach (Coroutine coroutine in mLoadDropPrefabCoroutine)
                {
                    SGameEngine.ResourceLoader.Instance.StopCoroutine(coroutine);
                }
                mLoadDropPrefabCoroutine.Clear();
            }

            ClearFloatTipsCD();
        }

        protected virtual void OnMonsterDead(CEventBaseArgs data)
        {
            var uid = (UnitID)data.arg;
            var act = ActorManager.Instance.GetActor(uid);
            if (act != null)
            {
                mDropPosition = act.transform.localPosition;
            }
        }

        void OnLoadDropObjectFinished(GameObject dropGameObject, PkgDropGive dropInfo, DropComponent.EDropType dropType)
        {
#if UNITY_EDITOR
            dropGameObject.name = string.Format("Drop_{0}_{1}", dropInfo.oid, dropInfo.gid);
#endif
            if (dropType == DropComponent.EDropType.Noncompetitive || dropInfo.pos == null)
            {
                dropGameObject.transform.position = InstanceDropManager.GetInstance().GenerateDropPosition(mDropPosition, 0);
            }
            else
            {
                //GameDebug.LogError("Create drop1 " + dropInfo.oid + ", pos " + dropInfo.pos.px * GlobalConst.UnitScale + " " + dropInfo.pos.py * GlobalConst.UnitScale);

                Vector3 pos = new Vector3((float)dropInfo.pos.px * GlobalConst.UnitScale, 0, (float)dropInfo.pos.py * GlobalConst.UnitScale);
                //pos.y = PhysicsHelp.GetHeight(pos.x, pos.z);
                //pos = InstanceHelper.ClampInWalkableRange(pos);
                pos.y = PhysicsHelp.GetHeight(pos.x, pos.z);
                dropGameObject.transform.position = pos;

                //GameDebug.LogError("Create drop2 " + dropInfo.oid + ", pos " + pos.ToString());
            }
            var dropComponent = dropGameObject.transform.Find("Mesh").GetComponent<DropComponent>();
            dropComponent.DropType = dropType;
            dropComponent.DropInfo = dropInfo;
            dropComponent.Init();
        }

        public void CreateDrops(List<PkgDropGive> drops, DropComponent.EDropType dropType, uint emId)
        {
            for (int i = 0; i < drops.Count; ++i)
            {
                var dropInfo = drops[i];

                // 经验直接拾取
                if (dropInfo.type == GameConst.GIVE_TYPE_EXP)
                {
                    C2SNwarPick msg = new C2SNwarPick();
                    msg.oid = dropInfo.oid;
                    msg.drop_type = (uint)dropType;
                    NetClient.GetBaseClient().SendData<C2SNwarPick>(NetMsg.MSG_NWAR_PICK, msg);

                    continue;
                }

                if (dropType == DropComponent.EDropType.Noncompetitive && dropInfo.pos != null)
                {
                    Vector3 pos = new Vector3((float)dropInfo.pos.px * GlobalConst.UnitScale, 0, (float)dropInfo.pos.py * GlobalConst.UnitScale);
                    pos.y = PhysicsHelp.GetHeight(pos.x, pos.z);
                    pos = InstanceHelper.ClampInWalkableRange(pos);
                    mDropPosition = pos;
                }

                // 是否超过最大掉落数
                if (InstanceDropManager.Instance.DropNum < InstanceDropManager.Instance.MaxDropNum)
                {
                    //mLoadDropPrefabCoroutine.Add(SGameEngine.ResourceLoader.Instance.StartCoroutine(LoadDropObject(dropInfo, dropType)));

                    GameObject dropGameObject = (GameObject)xc.ObjCachePoolMgr.Instance.LoadFromCache(DropBehaviour.DropPrefabPoolType, DropBehaviour.DropObjectPrefabPoolKey);
                    if (dropGameObject == null)
                    {
                        dropGameObject = (GameObject)GameObject.Instantiate(InstanceDropManager.Instance.DropObjectTemplate);
                        if (dropGameObject != null)
                        {
                            PoolGameObject pg = dropGameObject.AddComponent<PoolGameObject>();
                            pg.poolType = DropBehaviour.DropPrefabPoolType;
                            pg.key = DropBehaviour.DropObjectPrefabPoolKey;
                        }
                    }
                    if (dropGameObject != null)
                    {
                        dropGameObject.SetActive(true);
                        OnLoadDropObjectFinished(dropGameObject, dropInfo, dropType);
                    }
                    else
                    {
                        GameDebug.LogError("Create drop object error, is null!!!");
                    }
                }
                else
                {
                    GameDebug.LogError("Can not create drop" + dropInfo.oid + ", reach max num, current num is " + InstanceDropManager.Instance.DropNum + ", max num is " + InstanceDropManager.Instance.MaxDropNum);
                }
            }
        }

        IEnumerator LoadDropEffect(string path, Vector3 dropPosition)
        {
            SGameEngine.PrefabResource prefab = new SGameEngine.PrefabResource();

            yield return SGameEngine.ResourceLoader.Instance.StartCoroutine(SGameEngine.ResourceLoader.Instance.load_prefab(path, prefab));

            if (prefab != null && prefab.obj_ != null)
            {
                GameObject dropEffectGameObject = prefab.obj_;
                Actor localPlayer = Game.GetInstance().GetLocalPlayer();
                if (localPlayer != null)
                {
                    dropEffectGameObject.transform.parent = null;
                    dropEffectGameObject.transform.localScale = Vector3.one;
                    dropEffectGameObject.transform.localPosition = dropPosition;
                    dropEffectGameObject.transform.localRotation = Quaternion.identity;

                    TrackAnimationComponent com = dropEffectGameObject.AddComponent<TrackAnimationComponent>();
                    com.TargetTran = localPlayer.ActorTrans;
                    com.TargetOffset = new Vector3(0f, 0.5f * localPlayer.Height, 0f);
                }
                else
                {
                    GameObject.DestroyImmediate(dropEffectGameObject);
                }
            }
        }

        void PickDropImpl(uint uuid, uint id, DropComponent.EDropType dropType)
        {
            var dropComponent = InstanceDropManager.Instance.GetDrop(id);
            if (dropComponent == null)
                return;

            var dropGameObject = dropComponent.transform.parent.gameObject;
            if (dropGameObject == null)
                return;

            // 是否是本地玩家拾取
            var isLocalPlayerPick = false;
            if (uuid == Game.GetInstance().LocalPlayerID.obj_idx)
            {
                isLocalPlayerPick = true;
            }

            // 拾取特效
            if (isLocalPlayerPick == true)
            {
                var path = "Assets/" + ResPath.path19;
                if (dropComponent.DropInfo.type == GameConst.GIVE_TYPE_EXP)
                {
                    path = "Assets/" + ResPath.EF_ui_jingyansaluo_fly;
                }
                Vector3 dropPosition = dropGameObject.transform.localPosition;
                mLoadDropPrefabCoroutine.Add(SGameEngine.ResourceLoader.Instance.StartCoroutine(LoadDropEffect(path, dropPosition)));
            }

            DestroyDrop(id);
        }

        protected virtual void OnPickDrop(CEventBaseArgs data)
        {
            CEventObjectArgs args = (CEventObjectArgs)data;
            PkgDropGive dropInfo = (PkgDropGive)args.Value[0];
            uint dropType = (uint)args.Value[1];
            GameObject dropGameObject = (GameObject)args.Value[2];

            if (dropType == 0)
            {
                GameDebug.LogError("Can not this drop " + dropInfo.oid + ", because it's drop type is zero!!!");
                return;
            }

            C2SNwarPick msg = new C2SNwarPick();
            msg.oid = dropInfo.oid;
            msg.drop_type = dropType;
            NetClient.GetBaseClient().SendData<C2SNwarPick>(NetMsg.MSG_NWAR_PICK, msg);

            //GameDebug.LogError("Send MSG_NWAR_PICK: " + msg.oid + ", " + msg.drop_type);

            //// 使碰撞体失效
            //dropGameObject.transform.Find("Mesh").GetComponent<SphereCollider>().enabled = false;

            //int delayTime = 1000;
            //mTimerList.Add(new Utils.Timer(delayTime, false, delayTime, PickDropImpl, tfArgs));
        }

        void OnDestroyDrop(CEventBaseArgs data)
        {
            uint id = (uint)data.arg;
            DestroyDrop(id);
        }

        void DestroyDrop(ulong id)
        {
            var dropComponent = InstanceDropManager.Instance.GetDrop(id);
            if (dropComponent == null)
                return;

            dropComponent.Destroy();

            var dropGameObject = dropComponent.transform.parent.gameObject;
            if (dropGameObject == null)
                return;

            // 清除特效
            ModelHelper.ClearChildren(dropGameObject.transform.Find("EffectGameObject"));

            // 设置物品图标隐藏
            var nameSprite3D = dropComponent.gameObject.GetComponent<Sprite3DEx>();
            if (nameSprite3D != null)
                nameSprite3D.BeforeRecycle();

            // 清除头顶名字
            UI3DText nameText = dropComponent.gameObject.GetComponent<UI3DText>();
            if (nameText != null)
            {
                Object.DestroyImmediate(nameText);
            }

            // 清除UIDropAffiBar组件
            UIDropAffiBar bar = dropComponent.gameObject.GetComponent<UIDropAffiBar>();
            if (bar != null)
            {
                Object.DestroyImmediate(bar);
            }

            xc.ObjCachePoolMgr.Instance.RecyclePrefab(dropGameObject, xc.instance_behaviour.DropBehaviour.DropPrefabPoolType, xc.instance_behaviour.DropBehaviour.DropObjectPrefabPoolKey);

            CommonTool.SetActive(dropComponent.gameObject, true);
        }

        void OnShowPickDropFloatTips(CEventBaseArgs data)
        {
            if (mFloatTipsTimer == null)
            {
                string str = (string)data.arg;
                UINotice.Instance.ShowMessage(str);

                StartFloatTipsCD();
            }
        }

        /// <summary>
        /// 开始计算CD
        /// </summary>
        void StartFloatTipsCD()
        {
            ClearFloatTipsCD();
            float cd = 1000f * mFloatTipsCD;
            mFloatTipsTimer = new Utils.Timer(cd, false, cd,
                (dt) =>
                {
                    ClearFloatTipsCD();
                });
        }

        /// <summary>
        /// 清除飘字CD
        /// </summary>
        void ClearFloatTipsCD()
        {
            if (mFloatTipsTimer != null)
            {
                mFloatTipsTimer.Destroy();
                mFloatTipsTimer = null;
            }
        }

        protected virtual void HandleServerData(ushort protocol, byte[] data)
        {
            switch (protocol)
            {
                case NetMsg.MSG_NWAR_DROP:
                    {
                        var pack = S2CPackBase.DeserializePack<S2CNwarDrop>(data);

                        //GameDebug.LogError(">>>MSG_NWAR_DROP");
                        CreateDrops(pack.drops, (DropComponent.EDropType)pack.drop_type, pack.em_id);
                        return;
                    }
                case NetMsg.MSG_NWAR_PICK:
                    {
                        var pack = S2CPackBase.DeserializePack<S2CNwarPick>(data);

                        //GameDebug.LogError("Recv MSG_NWAR_PICK: " + pack.oid + ", " + pack.drop_type);

                        PickDropImpl(pack.uuid, pack.oid, (DropComponent.EDropType)pack.drop_type);
                        return;
                    }
                case NetMsg.MSG_NWAR_PICK_FAIL:
                    {
                        var pack = S2CPackBase.DeserializePack<S2CNwarPickFail>(data);

                        if (pack.reason == 1)   // 物品已消失
                        {
                            DestroyDrop(pack.oid);
                            UINotice.Instance.ShowMessage(DBConstText.GetText("DROP_IS_DISAPPEAR"));
                        }
                        else if (pack.reason == 2)  // 物品拾取次数已满
                        {
                            UINotice.Instance.ShowMessage(DBConstText.GetText("DROP_REACH_LIMIT"));

                            DropComponent drop = InstanceDropManager.Instance.GetDrop(pack.oid);
                            if (drop != null)
                            {
                                drop.CanPick = false;
                                drop.CanNotPickReason = pack.reason;
                            }
                        }
                        return;
                    }
                default:
                    break;
            }
        }
    }
}
