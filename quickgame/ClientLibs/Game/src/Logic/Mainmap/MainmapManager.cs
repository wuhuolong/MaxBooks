//------------------------------------------
//  File: MainmapManager.cs
//  Desc: 处理主城和副本中非战斗的一些逻辑
//  Author: raorui
//  Date: 2017.8.23
//------------------------------------------
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using xc;
using xc.ui;
using xc.protocol;
using Net;

using Utils;
using xc.Dungeon;
using SGameEngine;

namespace xc
{
    [wxb.Hotfix]
    public class MainmapManager : xc.Singleton<MainmapManager>
    {
        /// <summary>
        /// 其他玩家的装备信息
        /// </summary>
        public List<GoodsEquip> OtherPlayerEquipInfos
        {
            get
            {
                return m_OtherPlayerEquip;
            }
        }
        List<GoodsEquip> m_OtherPlayerEquip = new List<GoodsEquip>();

        /// <summary>
        /// 其他玩家的部位信息
        /// </summary>
        Dictionary<uint, EquipPosInfo> m_OtherPlayerEquipPosInfos = null;
        public Dictionary<uint, EquipPosInfo> OtherPlayerEquipPosInfos
        {
            get
            {
                return m_OtherPlayerEquipPosInfos;
            }
        }
        public EquipPosInfo GetOtherPlayerEquipPosInfos(uint pos)
        {
            if (m_OtherPlayerEquipPosInfos != null && m_OtherPlayerEquipPosInfos.ContainsKey(pos) == true)
            {
                return m_OtherPlayerEquipPosInfos[pos];
            }
            return null;
        }
        public void SetOtherPlayerEquipPosInfo(EquipPosInfo equipPosInfo)
        {
            if (m_OtherPlayerEquipPosInfos == null)
            {
                m_OtherPlayerEquipPosInfos = new Dictionary<uint, EquipPosInfo>();
            }
            m_OtherPlayerEquipPosInfos.Clear();
            m_OtherPlayerEquipPosInfos.Add(equipPosInfo.Pos, equipPosInfo);
        }

        SafeCoroutine.Coroutine mLocalPlayerWalkCoroutine = null;

        public void RegisterAllMessage()
        {
            Game.Instance.SubscribeNetNotify(NetMsg.MSG_MAP_LINE_STATE, HandleServerData);
            Game.Instance.SubscribeNetNotify(NetMsg.MSG_PLAYER_DISPLAY_INFO, HandleServerData);
            Game.Instance.SubscribeNetNotify(NetMsg.MSG_MAP_GET_HANG_POS, HandleServerData);

            ClientEventMgr.Instance.SubscribeClientEvent((int)ClientEvent.CE_CLICKCOLLISION_INFO, OnClickCollision);
            ClientEventMgr.Instance.SubscribeClientEvent((int)ClientEvent.CE_DISABLE_CLICKEFFECT, OnDisableClickEffect);
            ClientEventMgr.Instance.SubscribeClientEvent((int)ClientEvent.CE_COVER_STATE_CHANGE, OnCoverStateChange);
            ClientEventMgr.Instance.SubscribeClientEvent((int)ClientEvent.CE_START_SWITCHSCENE, OnStartSwitchScene);
            ClientEventMgr.Instance.SubscribeClientEvent((int)ClientEvent.CE_CLICKPLAYER_INFO, OnClickPlayer);
        }

        void HandleServerData(ushort protocol, byte[] data)
        {
            switch (protocol)
            {
                case NetMsg.MSG_MAP_LINE_STATE: // 处理换线逻辑
                    {
                        S2CMapLineState msg = S2CPackBase.DeserializePack<S2CMapLineState>(data);
                        SceneHelp.Instance.ProcessLineInfo(msg);
                    }
                    break;
                case NetMsg.MSG_PLAYER_DISPLAY_INFO: // 处理查看其他玩家信息
                    {
                        var msg = S2CPackBase.DeserializePack<S2CPlayerDisplayInfo>(data);

                        var equip_infos = msg.equips;
                        m_OtherPlayerEquip.Clear();
                        foreach (var info in equip_infos)
                        {
                            var equip_goods = GoodsHelper.CreateEquipGoodsFromNet(info);
                            equip_goods.IsInstalledByOtherPlayer = true;
                            m_OtherPlayerEquip.Add(equip_goods);
                        }
                        Equip.EquipHelper.CalculatorSuitNum(m_OtherPlayerEquip);

                        m_OtherPlayerEquipPosInfos = Equip.EquipHelper.GetEquipPosInfosByPkgInfos(msg.strengths, msg.baptizes);

                        ClientEventMgr.Instance.FireEvent((int)ClientEvent.CE_CLICKPLAY_DISPLAY_INFO, new CEventEventParamArgs(msg.info, m_OtherPlayerEquip, m_OtherPlayerEquipPosInfos));
                    }
                    break;
                case NetMsg.MSG_MAP_GET_HANG_POS: // 请求挂机位置
                    {
                        S2CMapGetHangPos msg = S2CPackBase.DeserializePack<S2CMapGetHangPos>(data);

                        Vector3 pos = new Vector3(msg.pos.px * GlobalConst.UnitScale, 0f, msg.pos.py * GlobalConst.UnitScale);
                        pos = PhysicsHelp.GetPosition(pos.x, pos.z);
                        TargetPathManager.Instance.GoToConstPosition(msg.dungeon_id, msg.line_id, pos, null, () => { InstanceManager.Instance.SetOnHook(true); });
                    }
                    break;
                default:
                    break;
            }
        }

        string m_ClickEffectPath = "Effects/Prefabs/Scene/EF_dianjidimian";
        GameObject m_ArrowEffectTemp;
        GameObject m_ArrowEffectObject;
        List<GameObject> m_LastArrowEffect = new List<GameObject>();

        #region CLIENT_EVENT
        void OnClickPlayer(CEventBaseArgs data)
        {
            // 破碎死域要屏蔽这个界面
            if (SceneHelp.Instance.IgnoreClickPlayer == true)
                return;

            GameObject selectedObj = (GameObject)data.arg;
            if (selectedObj != null)
            {
                ActorMono actMono = ActorHelper.GetActorMono(selectedObj);
                if (actMono != null)
                {
                    Actor actor = actMono.BindActor;
                    if (actor != null && (actor is LocalPlayer) == false && ActorHelper.IsShemale(actor.UID.obj_idx) == false)
                    {
                        Dictionary<string, string> playerInfo = new Dictionary<string, string>();
                        playerInfo.Clear();
                        playerInfo.Add("uuid", actor.UID.obj_idx.ToString());
                        xc.ui.ugui.UIManager.Instance.ShowWindow("UIWatchPlayerWindow", playerInfo);
                    }
                }
            }
        }

        bool AttackActionIsEnded()
        {
            Actor localPlayer = Game.GetInstance().GetLocalPlayer();
            if (localPlayer != null)
            {
                return !localPlayer.IsAttacking() || localPlayer.IsInSkillActionEndingStage();
            }

            return false;
        }

        /// <summary>
        /// 本地玩家移动协程，要等待攻击结束
        /// </summary>
        /// <param name="pos"></param>
        /// <returns></returns>
        IEnumerator LocalPlayerWalkCoroutine(Vector3 pos)
        {
            yield return new SafeCoroutine.WaitForCondition(AttackActionIsEnded);

            Actor local_player = Game.Instance.GetLocalPlayer();
            if (local_player != null)
            {
                local_player.MoveCtrl.TryWalkToAlong(pos);
            }
        }

        public void StopLocalPlayerWalkCoroutine()
        {
            if (mLocalPlayerWalkCoroutine != null)
            {
                mLocalPlayerWalkCoroutine.Stop();
                mLocalPlayerWalkCoroutine = null;
            }
        }

        /// <summary>
        /// 响应点击地面的消息
        /// </summary>
        /// <param name="ent"></param>
        void OnClickCollision(CEventBaseArgs ent)
        {
            Actor local_player = Game.Instance.GetLocalPlayer();
            if (local_player == null)
                return;

            if (GameInput.Instance.GetEnableInput() == false || UIInputEvent.TouchedUI()) /* || InstanceManager.Instance.IsAutoFighting == true*/
            {
                return;
            }

            Vector3 hitPos = (Vector3)ent.arg;

            XNavMeshHit nesrestHit;
            if (XNavMesh.SamplePosition(hitPos, out nesrestHit, 5.0f, LevelManager.GetInstance().AreaExclude))
            {
                hitPos = nesrestHit.position;
            }

            StopLocalPlayerWalkCoroutine();
            mLocalPlayerWalkCoroutine = SafeCoroutine.CoroutineManager.StartCoroutine(LocalPlayerWalkCoroutine(hitPos));

            if (m_ArrowEffectTemp == null)
            {
                MainGame.HeartBehavior.StartCoroutine(LoadEffect(m_ClickEffectPath, hitPos));
            }
                //EffectManager.GetInstance().GetEffectEmitter(effect_path).CreateInstance(x => OnEffectResLoad(x, ));
            else
                OnEffectResLoad(m_ArrowEffectTemp, hitPos);
        }

        IEnumerator LoadEffect(string effect_path, Vector3 hit_pos)
        {
            xc.ObjectWrapper game_object_wrapper = new xc.ObjectWrapper();
            yield return MainGame.HeartBehavior.StartCoroutine(ObjCachePoolMgr.Instance.LoadPrefab(effect_path, ObjCachePoolType.SMALL_PREFAB, effect_path, game_object_wrapper));
            GameObject effect_object = game_object_wrapper.obj as GameObject;

            OnEffectResLoad(effect_object, hit_pos);
        }

        /// <summary>
        /// 当点击地面的特效已经加载完毕
        /// </summary>
        void OnEffectResLoad(GameObject effectObject, Vector3 pos)
        {
            if (effectObject == null)
                return;

            effectObject.SetActive(false);
            m_ArrowEffectObject = effectObject;

            List<int> empty_list = new List<int>(m_LastArrowEffect.Count);
            for(int i = 0; i < m_LastArrowEffect.Count;  ++i)
            {
                GameObject obj = m_LastArrowEffect[i];
                if (obj == null || obj.activeSelf == false)
                {
                    empty_list.Add(i);
                    continue;
                }
                var delay_time = obj.GetComponent<DelayTimeComponent>();
                if (delay_time == null)
                    delay_time = obj.AddComponent<DelayTimeComponent>();
                delay_time.SetEndCallBack(new DelayTimeComponent.EndCallBackInfo(OnDelayTimerFinish, obj));
                delay_time.DelayTime = 0.5f;
                delay_time.Start();
            }

            for(int j = empty_list.Count -1; j >= 0; --j)
            {
                m_LastArrowEffect.RemoveAt(empty_list[j]);
            }

            m_ArrowEffectObject.SetActive(true);
            m_ArrowEffectObject.transform.position = pos;
            m_LastArrowEffect.Add(m_ArrowEffectObject);
        }

        /// <summary>
        /// 响应取消地面特效的消息
        /// </summary>
        /// <param name="data"></param>
        void OnDisableClickEffect(CEventBaseArgs data)
        {
            if (m_ArrowEffectObject != null)
            {
                var delay_time = m_ArrowEffectObject.GetComponent<DelayTimeComponent>();
                if (delay_time != null)
                    delay_time.Reset();
                ObjCachePoolMgr.Instance.RecyclePrefab(m_ArrowEffectObject, ObjCachePoolType.SMALL_PREFAB, m_ClickEffectPath);
            }
        }

        /// <summary>
        /// 主角被遮挡的状态发生改变
        /// </summary>
        /// <param name="data"></param>
        void OnCoverStateChange(CEventBaseArgs data)
        {
            bool state = (bool)data.arg;
            var local_player = Game.Instance.GetLocalPlayer();
            if(local_player != null)
            {
                var mat_ctrl = local_player.m_MatEffectCtrl;
                if (state)
                {
                    if (local_player.IsResLoaded)// 主角资源加载完毕
                    {
                        // 给主角添加材质效果
                        mat_ctrl.AddEffectMat(3600.0f, MaterialEffectCtrl.MAT_TYPE.OUTLING, MaterialEffectCtrl.Priority.OUTLING);

                        // 如果坐骑资源加载完毕，也需要给坐骑添加材质效果
                        if (local_player.mRideCtrl != null && local_player.mRideCtrl.Rider != null && local_player.mRideCtrl.Rider.IsResLoaded)
                        {
                            var rider_mat_ctrl = local_player.mRideCtrl.Rider.m_MatEffectCtrl;
                            rider_mat_ctrl.AddEffectMat(3600.0f, MaterialEffectCtrl.MAT_TYPE.OUTLING, MaterialEffectCtrl.Priority.OUTLING);
                        }
                        else// 进入协程等待
                        {
                            if (m_WaitRider != null)
                            {
                                MainGame.HeartBehavior.StopCoroutine(m_WaitRider);
                                m_WaitRider = null;
                            }
                            m_WaitRider = MainGame.HeartBehavior.StartCoroutine(WaitRider());
                        }
                    }
                    else// 进入协程等待
                    {
                        if (m_WaitLocalPlayer != null)
                        {
                            MainGame.HeartBehavior.StopCoroutine(m_WaitLocalPlayer);
                            m_WaitLocalPlayer = null;
                        }

                        m_WaitLocalPlayer = MainGame.HeartBehavior.StartCoroutine(WaitLocalPlayer());
                    }
                }
                else// 移除材质效果
                {
                    if(m_WaitLocalPlayer != null)
                    {
                        MainGame.HeartBehavior.StopCoroutine(m_WaitLocalPlayer);
                        m_WaitLocalPlayer = null;
                    }

                    mat_ctrl.RemoveEffectMat(MaterialEffectCtrl.MAT_TYPE.OUTLING);

                    if (m_WaitRider != null)
                    {
                        MainGame.HeartBehavior.StopCoroutine(m_WaitRider);
                        m_WaitRider = null;
                    }

                    var rider = local_player.mRideCtrl.Rider;
                    if(rider != null)
                    {
                        rider.m_MatEffectCtrl.RemoveEffectMat(MaterialEffectCtrl.MAT_TYPE.OUTLING);
                    }
                }
            }
        }

        /// <summary>
        /// 开始切换场景
        /// </summary>
        /// <param name="data"></param>
        void OnStartSwitchScene(CEventBaseArgs data)
        {
            if (m_WaitLocalPlayer != null)
            {
                MainGame.HeartBehavior.StopCoroutine(m_WaitLocalPlayer);
                m_WaitLocalPlayer = null;
            }

            StopLocalPlayerWalkCoroutine();
        }

        #endregion

        Coroutine m_WaitRider;

        /// <summary>
        /// 等待坐骑上的角色加载完毕后再添加材质效果
        /// </summary>
        /// <returns></returns>
        IEnumerator WaitRider()
        {
            while (Game.Instance.GetLocalPlayer() == null || Game.Instance.GetLocalPlayer().IsResLoaded == false)
            {
                yield return null;
            }

            var local_player = Game.Instance.GetLocalPlayer();
            var rider = local_player.mRideCtrl.Rider;
            while (rider == null || rider.IsResLoaded == false)
            {
                yield return null;
            }

            var rider_mat_ctrl = rider.m_MatEffectCtrl;
            rider_mat_ctrl.AddEffectMat(3600.0f, MaterialEffectCtrl.MAT_TYPE.OUTLING, MaterialEffectCtrl.Priority.OUTLING);
        }

        Coroutine m_WaitLocalPlayer;

        /// <summary>
        /// 等待角色加载完毕后再添加材质效果
        /// </summary>
        IEnumerator WaitLocalPlayer()
        {
            while(Game.Instance.GetLocalPlayer()== null || Game.Instance.GetLocalPlayer().IsResLoaded == false)
            {
                yield return null;
            }

            var mat_ctrl = Game.Instance.GetLocalPlayer().m_MatEffectCtrl;
            mat_ctrl.AddEffectMat(3600.0f, MaterialEffectCtrl.MAT_TYPE.OUTLING, MaterialEffectCtrl.Priority.OUTLING);
        }

        
        /// <summary>
        /// 特效延时隐藏的回调
        /// </summary>
        /// <param name="effect_object"></param>
        void OnDelayTimerFinish(System.Object effect_object)
        {
            GameObject effet_game_object = effect_object as GameObject;
            if (effet_game_object != null)
            {
                var delay_time = effet_game_object.GetComponent<DelayTimeComponent>();
                if (delay_time != null)
                    delay_time.Reset();
                ObjCachePoolMgr.Instance.RecyclePrefab(effet_game_object, ObjCachePoolType.SMALL_PREFAB, m_ClickEffectPath);
            }
        }

        /// <summary>
        /// 上一次触摸屏幕的时间
        /// </summary>
        float m_LastFigerDownTime = 0;

        public void Update()
        {
            float cur_time = Time.time;
            bool is_finger_down = GameInput.Instance.IsFingerDown;
            if (is_finger_down)
            {
                if (cur_time - m_LastFigerDownTime > 0.3f)
                {
                    m_LastFigerDownTime = cur_time;
                    CameraControl.ProcessHitCollision();
                }
            }
            else
                m_LastFigerDownTime = cur_time;
        }
    }
}
