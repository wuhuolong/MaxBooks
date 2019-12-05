using UnityEngine;
using System;
using System.Reflection;
using System.Collections;
using System.Collections.Generic;
using Utils;
using Net;

using xc.protocol;
using UnityEngine.AI;
using xc.Dungeon;
using SGameEngine;

namespace xc
{
    [wxb.Hotfix]
    public class ActorManager : MonoBehaviour
    {
        public static ActorManager Instance;
        public delegate bool UnitCacheDataFilter(UnitCacheInfo info);

        protected LinkedList<UnitCacheInfo> mUnitCacheData = new LinkedList<UnitCacheInfo>();

        /// <summary>
        /// 目前在队列中的UnitCacheInfo索引
        /// </summary>
        protected Dictionary<UnitID, UnitCacheInfo> mCacheDataMap = new Dictionary<UnitID, UnitCacheInfo>();

        List<Coroutine> mDestroyActorCoroutines = new List<Coroutine>();

        private static uint mClientModelId = 0;
        const uint ClientModelStartId = 300; // 起始ID, 预留300给NPC和膜拜雕像使用
        const uint ClientModelIdCount = 10000 - ClientModelStartId; // ClientModel可拥有ID的最大数量，服务端ID从10000开始

        public class CreateInfo
        {
            public string prefabName;
            public GameObject go;
        }


        /// <summary>
        /// 保存所有角色对象
        /// </summary>
        protected Dictionary<UnitID, Actor> mActorSet;

        /// <summary>
        /// 预览模型
        /// </summary>
        protected Dictionary<UnitID, ClientModel> m_ClientModelSet;

        /// <summary>
        /// 膜拜模型
        /// </summary>
        protected Dictionary<UnitID, WorshipModel> m_WorshipModelSet;

        /// <summary>
        /// 保存本地和远程怪物的对象
        /// </summary>
        protected Dictionary<UnitID, Actor> mMonsterSet;

        /// <summary>
        /// 保存所有宠物的对象
        /// </summary>
        protected Dictionary<UnitID, Actor> m_PetSet;

        /// <summary>
        /// 保存玩家召唤怪物的对象
        /// </summary>
        protected Dictionary<UnitID, Actor> mSummonMonsterSet;

        /// <summary>
        /// 保存boss召唤怪物的对象
        /// </summary>
        protected Dictionary<UnitID, Actor> mCalledMonsterSet;

        /// <summary>
        /// 保存本地和远程玩家的对象
        /// </summary>
        protected Dictionary<UnitID, Actor> mPlayerSet;

        /// <summary>
        /// 正在加载的模型，在删除的时候需要放到该列表中
        /// </summary>
        protected List<Actor> mRemoveWaitList;

        private Game mGame;


        public void Awake()
        {
            Instance = this;
            mGame = xc.Game.GetInstance();
            mActorSet = new Dictionary<UnitID, Actor>();
            m_ClientModelSet = new Dictionary<UnitID, ClientModel>();
            m_WorshipModelSet = new Dictionary<UnitID, WorshipModel>();
            mMonsterSet = new Dictionary<UnitID, Actor>();
            m_PetSet = new Dictionary<UnitID, Actor>();
            mSummonMonsterSet = new Dictionary<UnitID, Actor>();
            mCalledMonsterSet = new Dictionary<UnitID, Actor>();
            mPlayerSet = new Dictionary<UnitID, Actor>();
            mRemoveWaitList = new List<Actor>();

            mDestroyActorCoroutines.Clear();
        }

        List<UnitID> mActorKeys = new List<UnitID>(50);
        public void Update()
        {
            if (mActorSet == null)
                return;

            int actorCount = mActorSet.Count;
            int index = 0;
            using (var enumerator = mActorSet.GetEnumerator())
            {
                while(enumerator.MoveNext())
                {
                    var cur = enumerator.Current;
                    var k = cur.Key;

                    if (index >= mActorKeys.Count)
                    {
                        mActorKeys.Add(k);
                    }
                    else
                    {
                        mActorKeys[index] = k;
                    }
                    index++;
                }
            }

            for (int i = 0; i < actorCount; ++i)
            {
                Actor actor = null;
                if (mActorSet.TryGetValue(mActorKeys[i], out actor))
                {
                    if (actor != null && actor.NoUpdate == false)
                    {
                        actor.Update();
                        actor.LateUpdate();
                    }
                }
            }

            // 检查是否有因为正在加载模型而没有销毁的角色
            if(mRemoveWaitList.Count > 0)
            {
                // mRemoveWaitList 在迭代的过程中可能发生改变，因此需要添加到wait_actor_list中
                List<Actor> wait_actor_list = Pool<Actor>.List.New(mRemoveWaitList.Count);
                List<Actor> remove_actor_list = Pool<Actor>.List.New();
                foreach (var actor in mRemoveWaitList)
                {
                    wait_actor_list.Add(actor);
                }

                foreach (var actor in wait_actor_list)
                {
                    if (actor.mAvatarCtrl == null || actor.mAvatarCtrl.IsProcessingModel == false)
                    {
                        actor.Destroy();
                        remove_actor_list.Add(actor);
                    }
                }
                Pool<Actor>.List.Free(wait_actor_list);

                foreach (var actor in remove_actor_list)
                {
                    mRemoveWaitList.Remove(actor);
                }
                Pool<Actor>.List.Free(remove_actor_list);
            }
        }

        public Dictionary<UnitID, Actor> ActorSet
        {
            get { return mActorSet; }
        }

        public Dictionary<UnitID, ClientModel> ClientModelSet
        {
            get
            {
                return m_ClientModelSet;
            }
        }

        public Dictionary<UnitID, WorshipModel> WorshipModelSet
        {
            get
            {
                return m_WorshipModelSet;
            }
        }

        public Dictionary<UnitID, Actor> MonsterSet
        {
            get { return mMonsterSet; }
        }

        /// <summary>
        /// 宠物列表
        /// </summary>
        public Dictionary<UnitID, Actor> PetSet
        {
            get { return m_PetSet; }
        }

        public Dictionary<UnitID, Actor> SummonMonsterSet
        {
            get{ return mSummonMonsterSet;}
        }

        public Dictionary<UnitID, Actor> CalledMonsterSet
        {
            get{ return mCalledMonsterSet;}
        }

        public Dictionary<UnitID, Actor> PlayerSet
        {
            get { return mPlayerSet; }
        }

        public Dictionary<UnitID, Actor> GetMonsterSetByActorId(uint actorId)
        {
            Dictionary<UnitID, Actor> monsterSet = new Dictionary<UnitID, Actor>();
            monsterSet.Clear();
            foreach (Actor monster in mMonsterSet.Values)
            {
                if (monster.TypeIdx == actorId)
                {
                    monsterSet.Add(monster.UID, monster);
                }
            }

            return monsterSet;
        }

        public Actor GetGuardedNpc()
        {
            foreach (Actor monster in mMonsterSet.Values)
            {
                if (monster.IsGuardedNpc())
                    return monster;
            }

            return null;
        }

        public void OnEnterScene()
        {

        }

        public void OnDestroyScene()
        {
            foreach (Coroutine coroutine in mDestroyActorCoroutines)
            {
                StopCoroutine(coroutine);
            }
            mDestroyActorCoroutines.Clear();

            List<UnitID> keys = new List<UnitID>(mActorSet.Keys);
            for (int i =0;i <keys.Count; ++i)
            {
                Actor actor = null;
                if(mActorSet.TryGetValue(keys[i], out actor))
                {
                    DestroyActor(actor.UID, 0);
                }
            }

            mActorSet.Clear();
            mMonsterSet.Clear();
            m_PetSet.Clear();
            mSummonMonsterSet.Clear();
            mCalledMonsterSet.Clear();
            mPlayerSet.Clear();
            m_ClientModelSet.Clear();
            m_WorshipModelSet.Clear();
            mUnitCacheData.Clear();
            mCacheDataMap.Clear();

            // 切换场景的时候重置膜拜雕像的唯一id
            WorshipModel.ResetUUId();
        }

        /// <summary>
        /// 销毁所有的怪物
        /// </summary>
        public void DestroyAllMonsters()
        {
            List<UnitID> keys = new List<UnitID>(mMonsterSet.Keys);
            for (int i = 0; i < keys.Count; ++i)
            {
                Actor actor = null;
                if (mActorSet.TryGetValue(keys[i], out actor))
                {
                    DestroyActor(actor.UID, 0);
                }
            }
        }

        /// <summary>
        /// 销毁所有的怪物，除了守护NPC
        /// </summary>
        public void DestroyAllMonstersExceptGuardedNpc()
        {
            List<UnitID> keys = new List<UnitID>(mMonsterSet.Keys);
            for (int i = 0; i < keys.Count; ++i)
            {
                Actor actor = null;
                if (mActorSet.TryGetValue(keys[i], out actor))
                {
                    if (actor.IsGuardedNpc() == false)
                    {
                        DestroyActor(actor.UID, 0);
                    }
                }
            }
        }

        /// <summary>
        /// 清除所有的创建角色的缓存信息
        /// </summary>
        public void ClearUnitCache()
        {
            mUnitCacheData.Clear();
            mCacheDataMap.Clear();

            ClientEventMgr.Instance.FireEvent((int)ClientEvent.CE_CLEAR_UNITCACHE, new CEventBaseArgs());
        }

        public T CreateActor<T>(xc.UnitCacheInfo info, Quaternion rot, Monster.CreateParam createParam, bool showFashion = false, Action<Actor> cbResloaded = null ) where T:Actor,new ()
        {
            if (mActorSet.ContainsKey(info.UnitID))
            {
                GameDebug.LogError("Actor's key conflict. Type: " + info.UnitID.type + ", UID: " + info.UnitID.obj_idx);
                return null;
            }

            Vector3 scale = RoleHelp.GetPrefabScale(info);

            T actor = new T(); // Activator.CreateInstance<T>();
            actor.OnCreate(info, createParam);
            mActorSet.Add(info.UnitID, actor);

            if (info.UnitType == EUnitType.UNITTYPE_PLAYER)
            {
                var voaction = (Actor.EVocationType)ActorHelper.TypeIdToRoleId(info.AOIPlayer.type_idx);
                StartCoroutine(actor.mAvatarCtrl.CreateModelFromModleList(info.PosBorn, rot, scale, info.AOIPlayer.model_id_list, info.AOIPlayer.fashions, info.AOIPlayer.suit_effects,voaction ,cbResloaded));
            }
            else
            {
                string prefab = RoleHelp.GetPrefabName(info);
//                 if(info.UnitType == EUnitType.UNITTYPE_MONSTER && info.AOIMonster != null)
//                 {
//                     if(info.AOIMonster.type_idx >= 201 && info.AOIMonster.type_idx < 208)
//                     {//守护
//                         prefab = prefab + "_pet_test";
//                     }
//                     else if (info.AOIMonster.type_idx >= 301 && info.AOIMonster.type_idx < 308)
//                     {//坐骑
//                         prefab = prefab + "_mount_test";
//                     }
//                 }
                StartCoroutine(actor.mAvatarCtrl.CreateModelFromPrefab(prefab, info.PosBorn, rot, scale, cbResloaded));
            }

            //actor.transform.position = info.PosBorn;
            actor.AfterCreate();

            return actor;
        }
            
        /// <summary>
        /// 创建角色
        /// </summary>
        /// <param name="actorId"></param>
        /// <param name="pos"></param>
        /// <param name="rot"></param>
        /// <returns></returns>
      
        //private uint PeiID = 8000;

        /// <summary>
        /// 创建怪物
        /// </summary>
        /// <param name="actorId"></param>
        /// <param name="pos"></param>
        /// <param name="rot"></param>
        /// <returns></returns>
        public UnitID CreatePet(uint pet_id, uint actorId, Vector3 pos, Quaternion rot, Actor parent)
        {
            if(parent == null)
                return null;

            //++PeiID;
            UnitID unit_id = ActorManager.GetAvailableModelId((byte)EUnitType.UNITTYPE_PET);
            var unit_cache_info = ActorHelper.CreatePetUnitCacheInfo(unit_id.obj_idx, pet_id, actorId, pos, rot, parent);

            ActorManager.Instance.PushUnitCacheData(unit_cache_info);
            return unit_cache_info.UnitID;
        }
     
        public void DestroyActor(UnitID id, float delayTime = 0 )
        {
            if(delayTime > 0)
            {
                Coroutine coroutine = StartCoroutine(DelayDestroyActor(id, delayTime));
                mDestroyActorCoroutines.Add(coroutine);
                return;
            }

            Actor actor = null;
            if (mActorSet.TryGetValue(id, out actor))
            {
                if(actor.mAvatarCtrl.IsProcessingModel)
                {
                    RemoveActorWait(actor);
                }
                else
                {
                    actor.Destroy();
                }

                mActorSet.Remove(id);
            }
            else
                GameDebug.Log("actor: " + id.obj_idx + " has been removed.");

            if (mMonsterSet.ContainsKey(id))
            {
                mMonsterSet.Remove(id);

                if (mSummonMonsterSet.ContainsKey(id))
                {
                    mSummonMonsterSet.Remove(id);
                }
                else if (mCalledMonsterSet.ContainsKey(id))
                {
                    mCalledMonsterSet.Remove(id);
                }
            }
            else if (mPlayerSet.ContainsKey(id))
            {
                mPlayerSet.Remove(id);
            }
            else if (m_ClientModelSet.ContainsKey(id))
            {
                m_ClientModelSet.Remove(id);
            }
            else if (m_WorshipModelSet.ContainsKey(id))
            {
                m_WorshipModelSet.Remove(id);
            }
            else if(m_PetSet.ContainsKey(id))
            {
                m_PetSet.Remove(id);
            }
        }

        #region CreateCache
        public void PushUnitCacheData(UnitCacheInfo data)
        {
            mUnitCacheData.AddLast(data);
            mCacheDataMap[data.UnitID] = data;
        }
        
        public UnitCacheInfo PopUnitCacheData()
        {
            if (mUnitCacheData.Count == 0)
                return null;
            UnitCacheInfo head = mUnitCacheData.First.Value;
            mUnitCacheData.RemoveFirst();

            mCacheDataMap.Remove(head.UnitID);
            return head;
        }

        public bool RemoveUnitCacheData(UnitCacheDataFilter func)
        {
            foreach (var info in mUnitCacheData)
            {
                if (func(info))
                {
                    mUnitCacheData.Remove(info);
                    mCacheDataMap.Remove(info.UnitID);
                    return true;
                }
            }
            
            return false;
        }

        /// <summary>
        /// 从AOI列表中获取CacheInfo
        /// </summary>
        /// <param name="uid"></param>
        /// <returns></returns>
        public UnitCacheInfo GetUnitCacheInfo(UnitID uid)
        {
            UnitCacheInfo info;
            mCacheDataMap.TryGetValue(uid, out info);
            return info;
        }

        public void UpdateUnitCache(bool doAll)
        {
            UpdateUnitCache(doAll, null);
        }

        /// <summary>
        /// 将模型列表中的BODY替换成高模
        /// </summary>
        public static List<uint> ReplaceModelList(List<uint> model_list, Actor.EVocationType vocation, bool newList = false)
        {
            // 暂时使用之前的model_list
            return model_list;

            List<uint> modelList = null;
            if(newList)
                modelList = new List<uint>(model_list);
            else
                modelList = model_list;

            if(modelList == null)
            {
                GameDebug.LogError("[ReplaceModelList]ModelList is null");
                return null;
            }

            if(modelList.Count > 0)
            {
                for(int k = 0; k < modelList.Count; ++k)
                {
                    DBAvatarPart dbAvatar = DBManager.GetInstance().GetDB<DBAvatarPart>();
                    DBAvatarPart.Data data = null;
                    dbAvatar.mData.TryGetValue(modelList[k], out data);
                    if(data != null)
                    {
                        if(data.part == DBAvatarPart.BODY_PART.BODY)
                        {
                            // 替换bodypart
                            modelList[k] = modelList[k] * 100;
                        }
                    }
                }
            }
            else
            {
                DBAvatarDefault.Data defaultAvatar = null;
                if(DBManager.GetInstance().GetDB<DBAvatarDefault>().mData.TryGetValue(vocation, out defaultAvatar))
                {
                    modelList.Add(defaultAvatar.bodyId * 100);
                    modelList.Add(defaultAvatar.weaponId);
                }
            }

            return modelList;
        }

        public void UpdateUnitCache(bool doAll, UnitCacheDataFilter filter)
        {
            const int MAX_PROCESS_UNIT_PER_FRAME = 3;
            
            for (int i=0; mUnitCacheData.Count != 0; ++i)
            {
                if (!doAll)
                {
                    if (i >= MAX_PROCESS_UNIT_PER_FRAME)
                        break;
                }
                
                UnitCacheInfo info = PopUnitCacheData();
                
                if(info == null)
                {
                    continue;
                }
                
                if (info.UnitType != EUnitType.UNITTYPE_PLAYER && info.UnitType != EUnitType.UNITTYPE_NPC && 
                    info.UnitType != EUnitType.UNITTYPE_MONSTER && info.UnitType != EUnitType.UNITTYPE_PET)
                    continue;

                if (filter != null && !filter(info))
                    continue;
                
                Actor actor = null;
                if (info.CacheType == UnitCacheInfo.EType.ET_Create)
                {
                    float rawY = info.PosBorn.y;
                    info.PosBorn = PhysicsHelp.GetPosition(info.PosBorn.x, info.PosBorn.z);
                    if (info.UnitType == EUnitType.UNITTYPE_PLAYER)
                    {
                        if (info.UnitID.Equals(mGame.LocalPlayerID))// 创建本地玩家
                        {
                            actor = mGame.GetLocalPlayer();
                            if (actor == null)
                            {
                                var vocation = (Actor.EVocationType)ActorHelper.TypeIdToRoleId(info.AOIPlayer.type_idx);
                                info.AOIPlayer.model_id_list = ReplaceModelList(info.AOIPlayer.model_id_list, vocation, false);
                                actor = ActorManager.Instance.CreateActor<LocalPlayer>(info, info.Rotation, null);
                                ClientEventMgr.GetInstance().FireEvent((int)ClientEvent.CE_LOCALPLAYER_CREATE, new CEventBaseArgs(actor));
                            }
                        }
                        else// 创建其他玩家
                        {
                            if (ActorManager.Instance.ActorSet.ContainsKey(info.UnitID))
                            {
                                GameDebug.Log(string.Format("Player(ID: {0}) has been created.", info.UnitID.obj_idx));
                                continue;
                            }
                            
                            actor = ActorManager.Instance.CreateActor<RemotePlayer>(info, info.Rotation, null);

                            // FIXME 创建本地玩家的时候也会发送该消息
                            ClientEventMgr.GetInstance().FireEvent((int)ClientEvent.CE_REMOTEPLAYER_CREATE, new CEventBaseArgs(actor));
                        }
                    }
                    else if (info.UnitType == EUnitType.UNITTYPE_NPC)
                    {
                        actor = ActorManager.Instance.CreateActor<NpcPlayer>(info, info.ClientNpc.Rotation, null);
                    }
                    else if (info.UnitType == EUnitType.UNITTYPE_MONSTER)
                    {
                        if (ActorManager.Instance.ActorSet.ContainsKey(info.UnitID))
                        {
                            GameDebug.LogError(string.Format("Monster(ID: {0}) has been created.", info.UnitID.obj_idx));
                            continue;
                        }
                        Monster.CreateParam createParam = new Monster.CreateParam();
                        createParam.is_pet = false;
                        if(ActorHelper.IsSummon(info.UnitID.obj_idx ))
                        {
                            createParam.summon = true;
                            createParam.summonType = Monster.MonsterType.SummonRemoteMonster;
                            if (info.ParentActor != null)
                            {
                                createParam.master = info.ParentActor.UID;
                                // 判断是不是本地召唤怪
                                if (createParam.master.Equals(Game.Instance.LocalPlayerID) == true)
                                {
                                    createParam.summonType = Monster.MonsterType.SummonLocalMonster;
                                }
                            }
                        }
                        var obj = ActorManager.Instance.CreateActor<Monster>(info, info.Rotation, createParam);
                    }
                    else if (info.UnitType == EUnitType.UNITTYPE_PET)
                    {
                        if (ActorManager.Instance.ActorSet.ContainsKey(info.UnitID))
                        {
                            GameDebug.LogError(string.Format("Pet(ID: {0}) has been created.", info.UnitID.obj_idx));
                            continue;
                        }

                        Monster.CreateParam createParam = new Monster.CreateParam();
                        createParam.is_pet = true;
                        createParam.summon = false;
                        if (info.ParentActor != null)
                        {
                            createParam.master = info.ParentActor.UID;
                        }

                        if(info.AOIPet.is_local)
                            ActorManager.Instance.CreateActor<LocalPet>(info, info.Rotation, createParam);
                        else
                            ActorManager.Instance.CreateActor<RemotePet>(info, info.Rotation, createParam);
                    }
                }
                else if (info.CacheType == UnitCacheInfo.EType.ET_Destroy)
                {
                    ActorManager.Instance.DestroyActor(info.UnitID, 0);
                }
                else
                {
                    GameDebug.LogError("Error Cache data!");
                }
            }
        }
        #endregion

        private IEnumerator DelayDestroyActor(UnitID id, float delayTime)
        {
            yield return new WaitForSeconds(delayTime);
            DestroyActor(id, 0);
        }

        /// <summary>
        /// 将还在加载模型的角色添加到mRemoveWaitList列表中
        /// </summary>
        /// <param name="actor"></param>
        private void RemoveActorWait(Actor actor)
        {
            mRemoveWaitList.Add(actor);
        }

        /// <summary>
        /// 获取指定uid的角色
        /// </summary>
        /// <param name="uuid"></param>
        /// <returns></returns>
        public Actor GetActor(UnitID id)
        {
            if(id == null)
                return null;

            Actor actor = null;
            mActorSet.TryGetValue(id, out actor);

            return actor;
        }

        UnitID m_CacheUID = new UnitID();

        /// <summary>
        /// 获取指定uid的角色
        /// </summary>
        /// <param name="uuid"></param>
        /// <returns></returns>
        public Actor GetActor(uint uid)
        {
            Actor actor = null;
            m_CacheUID.obj_idx = uid;
            mActorSet.TryGetValue(m_CacheUID, out actor);

            return actor;
        }

        /// <summary>
        /// GetPlayer，UnitID经过特殊处理，可以获取obj_idx匹配的角色或者怪物
        /// </summary>
        /// <returns>The player.</uid>
        public Actor GetPlayer(uint uid)
        {
            return GetActor(uid);
        }

        /// <summary>
        /// 获得一个可用的模型ID
        /// </summary>
        /// <returns></returns>
        public static UnitID GetAvailableModelId(byte actor_type)
        {
            uint new_mClientModelId = ClientModelStartId + mClientModelId % ClientModelIdCount;
            UnitID tmp_id = new UnitID(actor_type, new_mClientModelId);
            uint start_model_id = new_mClientModelId;
            while (true)
            {
                if (Instance == null || Instance.mActorSet == null || Instance.mActorSet.ContainsKey(tmp_id) == false)
                {
                    break;
                }
                mClientModelId = mClientModelId + 1;
                new_mClientModelId = ClientModelStartId + mClientModelId % ClientModelIdCount;
                tmp_id.obj_idx = new_mClientModelId;
                if (start_model_id == new_mClientModelId)
                    break;
            }

            mClientModelId = mClientModelId + 1;
            mClientModelId = mClientModelId % ClientModelIdCount;
            return tmp_id;
        }

        /// <summary>
        /// 本地玩家外观变化后同步更新客户端模型
        /// </summary>
        public void UpdateLocalPlayerClientModels()
        {
            var local_player = Game.Instance.GetLocalPlayer() as LocalPlayer;
            if (local_player == null)
            {
                return;
            }
            foreach (var client_modle in ClientModelSet.Values)
            {
                if (client_modle != null && client_modle.RawUID == local_player.UID.obj_idx && client_modle.UpdateWithRawActor)
                {
                    client_modle.mAvatarCtrl.SetAvatarProperty(local_player.mAvatarCtrl.GetLatestAvatartProperty(), local_player.VocationID);
                }
            }
        }
    }
}

