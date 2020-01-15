//------------------------------------------------------------------------------
// File ： CullManager.cs
// Desc ： 控制同屏角色数量的管理类
// Author : raorui 
// Date : 2016.9.21 Comments
//------------------------------------------------------------------------------
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace xc
{
    [wxb.Hotfix]
    public class CullManager : xc.Singleton<CullManager>
    {
        // Actor的排序
        public class CullSorted : IComparer<Actor>
        {
            public int Compare(Actor x, Actor y)
            {
                if(x == null)
                    return 1;
                else if(y == null)
                    return -1;

                // 按显示模式先排序（模型可见>显示黑影>显示名字>完全不可见）
                if (x.mVisibleCtrl.VisibleMode != y.mVisibleCtrl.VisibleMode)
                {
                    if (x.mVisibleCtrl.VisibleMode == EVisibleMode.Visible)
                        return -1;
                    else if (y.mVisibleCtrl.VisibleMode == EVisibleMode.Visible)
                        return 1;
                    else if(x.mVisibleCtrl.VisibleMode == EVisibleMode.Name)
                        return -1;
                    else
                        return 1;
                }

                // 比较是否曾经被显示过(显示过>还未被显示)
                if (x.mVisibleCtrl.HasShow && !y.mVisibleCtrl.HasShow)
                    return -1;
                else if (!x.mVisibleCtrl.HasShow && y.mVisibleCtrl.HasShow)
                    return 1;

                // 比较加入同屏列表的时间(早加入的放在前面，后加入的不会顶替更早显示的玩家)
                float timeX = x.mVisibleCtrl.VisibleTime;
                float timeY = y.mVisibleCtrl.VisibleTime;
                if (timeX < timeY)
                    return -1;
                else if (timeX > timeY)
                    return 1;
                else
                    return 0;
            }
        }
        
        private CullSorted mSort = new CullSorted();
        private List<Actor> mActorSortedList = new List<Actor>();// 经过同屏显示规则排序过的Actor列表
        private Dictionary<uint, Actor> mActorMap = new Dictionary<uint, Actor>();// 包含当前同屏的所有玩家

        int UpdateDelayInMS = 1000;// TimerUpdate的时间间隔
        private Utils.Timer mUpdateTimer = null;

        private bool mDirty = false;

        public bool IsEnabled { get; set; }

        /// <summary>
        /// 设置Dirty后，会对同屏的玩家根据规则进行排序
        /// </summary>
        public void SetDirty()
        {
            mDirty = true;
        }
        
        public void RigisterAllMessage()
        {
            QualitySetting.Instance.OnGLChanged += OnGraphicLevelChanged;

            // 注册客户端消息
            ClientEventMgr.GetInstance().SubscribeClientEvent((int)ClientEvent.CE_LEAVEAOI, OnLeaveAOI);

            mUpdateTimer = new Utils.Timer(UpdateDelayInMS, true, (float)UpdateDelayInMS, OnUpdate);
        }
        
        public void UnRigisterAllMessage()
        {
            QualitySetting.Instance.OnGLChanged -= OnGraphicLevelChanged;

            ClientEventMgr.GetInstance().UnsubscribeClientEvent((int)ClientEvent.CE_LEAVEAOI, OnLeaveAOI);

            if (mUpdateTimer != null)
            {
                mUpdateTimer.Destroy();
                mUpdateTimer = null;
            }
        }

        /// <summary>
        /// 重置CullManager,清除Cache
        /// </summary>
        public void Reset()
        {
            mActorSortedList.Clear();
            mActorMap.Clear();

            UnRigisterAllMessage();
            RigisterAllMessage();

            IsEnabled = true;
        }

        /// <summary>
        /// 角色被删除时，将其从同屏可视列表中移除
        /// </summary>
        public void RemoveActor(Actor actor)
        {
            RemoveFromVisibleQueue(actor);
        }

        /// <summary>
        /// 每秒进行更新
        /// </summary>
        private void OnUpdate(float dt)
        {
            if (IsEnabled == false)
            {
                return;
            }

            ProcessActors();
            if (mDirty)
            {
                Sort();
                mDirty = false;
            }
        }

        /// <summary>
        /// 将角色添加到同屏可视列表中
        /// </summary>
        private void AddToVisibleQueue(Actor actor)
        {
            if(actor == null || actor.UID == Game.GetInstance().LocalPlayerID)
                return;

            if (!mActorMap.ContainsKey(actor.UID.obj_idx))
            {
                actor.mVisibleCtrl.VisibleTime = UnityEngine.Time.realtimeSinceStartup;
                mActorMap.Add(actor.UID.obj_idx, actor);

                SetDirty();
            }
        }

        /// <summary>
        /// 将角色从同屏可视列表中移除
        /// </summary>
        private void RemoveFromVisibleQueue(Actor actor)
        {
            if(actor == null || actor.UID == Game.GetInstance().LocalPlayerID)
                return;

            if (mActorMap.ContainsKey(actor.UID.obj_idx))
            {
                actor.mVisibleCtrl.SetActorVisible(false, VisiblePriority.CULL);
                mActorMap.Remove(actor.UID.obj_idx);
                //mDirty = true;
            }
        }

        float mFactor = 1.0f;

        /// <summary>
        /// 用来控制同屏显示模型数量的Factor
        /// </summary>
        public float Factor
        {
            get
            {
                return mFactor;
            }
            set
            {
                mFactor = value;
            }
        }

        Rect nearRect = new Rect();
        Rect farRect = new Rect();
        float nearOffset = 65.0f;
        float farOffset = 115.0f;

        /// <summary>
        /// 每秒对PlayerSet中的角色进行同屏判断，在屏幕之内的则将其添加到可视列表中
        /// </summary>
        void ProcessActors()
        {
            Camera cam = Game.Instance.MainCamera;
            if(cam == null)
                return;

            Rect camRect = cam.pixelRect;
            // 获取屏幕内的Rect
            nearRect.xMin = camRect.xMin - nearOffset;
            nearRect.xMax = camRect.xMax + nearOffset;
            nearRect.yMin = camRect.yMin - nearOffset;
            nearRect.yMax = camRect.yMax + nearOffset;
            // 获取屏幕外的Rect
            farRect.xMin = camRect.xMin - farOffset;
            farRect.xMax = camRect.xMax + farOffset;
            farRect.yMin = camRect.yMin - farOffset;
            farRect.yMax = camRect.yMax + farOffset;

            using (var enumerator = ActorManager.Instance.PlayerSet.GetEnumerator())
            {
                while (enumerator.MoveNext())
                {
                    var cur = enumerator.Current;

                    Actor actor = cur.Value;
                    // 屏蔽预览角色
                    if (actor == null)
                    {
                        continue;
                    }

                    if (actor is ClientModel)
                    {
                        continue;
                    }

                    // 屏蔽本地玩家
                    if (actor.UID == Game.GetInstance().LocalPlayerID)
                    {
                        actor.mVisibleCtrl.SetActorVisible(true, VisiblePriority.CULL);

                        bool real_shadow = QualitySetting.GraphicLevel <= 1;
                        var shadow_behavior = actor.GetBehavior<ShadowBehavior>();
                        if (real_shadow)
                        {
                            shadow_behavior.ShadowType = ShadowType.REAL_SHADOW;
                            shadow_behavior.RealShadow = true;
                        }
                        else
                        {
                            shadow_behavior.ShadowType = ShadowType.FAKE_SHADOW;
                            shadow_behavior.RealShadow = false;
                        }

                        continue;
                    }

                    // 角色模型被销毁时
                    if (actor.transform == null)
                    {
                        continue;
                    }

                    Vector3 pos = actor.transform.position;
                    // 获取玩家的屏蔽坐标，在nearRect内将其添加到可视列表，在farRect外将其移出可视列表
                    // 在在nearRect和farRect之间变化时，不做改变
                    Vector3 screenPos = cam.WorldToScreenPoint(pos);
                    if (nearRect.Contains(screenPos))
                    {
                        AddToVisibleQueue(actor);
                        continue;
                    }

                    if (!farRect.Contains(pos))
                    {
                        // 当AI有target的时候，不能将其从可视列表中移除
                        bool hasTarget = false;
                        if (actor.GetAI() != null)
                        {
                            BehaviourAI ai = actor.GetAI() as BehaviourAI;
                            if (ai != null)
                            {
                                hasTarget = ai.IsHaveTarget;
                            }
                        }

                        if (hasTarget)
                        {
                            continue;
                        }

                        // 在屏幕外时，将其从列表中移除
                        RemoveFromVisibleQueue(actor);
                    }
                }
            }
        }

        /// <summary>
        /// 对同屏内的所有玩家进行排序，完全可见的角色才显示模型
        /// 画面等级发生变化时，可以在外部强制调用
        /// </summary>
        private void Sort()
        {
            mActorSortedList.Clear();
            mActorSortedList.AddRange(mActorMap.Values);
            mActorSortedList.Sort(mSort);

            uint visible_count = 0;
            uint name_visible_count = 0;
            uint realshadow_cout = 0;
            uint total_count = (uint)mActorSortedList.Count;

            uint max_player_count = QualitySetting.MaxPlayerCount;
            visible_count = (uint)(max_player_count * mFactor);
            visible_count = (uint)Mathf.Clamp((int)visible_count, GlobalConst.MinPlayerCount, (int)max_player_count);
            name_visible_count = total_count > visible_count ? total_count - visible_count : 0;
            realshadow_cout = 0;
            if (QualitySetting.GraphicLevel <= 1)
            {
                realshadow_cout = 3;
            }
            else
                realshadow_cout = 0;

            UpdateActorVisible(visible_count, name_visible_count,realshadow_cout);
        }

        /// <summary>
        /// 当前在屏幕视野内的所有玩家
        /// </summary>
        public uint ActorNum
        {
            get
            {
                return (uint)(mActorMap.Count);
            }
        }

        uint mVisibleNum = 0;

        /// <summary>
        /// 当前在屏幕视野内显示的玩家数量
        /// </summary>
        public uint VisibleActorNum
        {
            get
            {
                if(mVisibleNum <= mActorMap.Count)
                    return (uint)mVisibleNum;
                else
                    return (uint)mActorMap.Count;
            }
        }

        /// <summary>
        /// 根据传入的显示数量来显示、隐藏玩家
        /// </summary>
        /// <param name="visible_num">模型可见的数量</param>
        /// <param name="name_visible_num">名字和阴影可见的数量</param>
        /// <param name="realshadow_num">真实阴影可见的数量</param>
        void UpdateActorVisible(uint visible_num, uint name_visible_num, uint realshadow_num)
        {
            // 为计算方面，各显示层级的数量包含上一层级的数量
            name_visible_num = visible_num + name_visible_num;

            var index = 0u;
            mVisibleNum = 0;
            foreach (var actor in mActorSortedList)
            {
                if (actor == null)
                    continue;

                if (index < visible_num)
                {
                    actor.mVisibleCtrl.SetActorVisible(true, VisiblePriority.CULL);
                    if (index < realshadow_num)
                    {
                        actor.GetBehavior<ShadowBehavior>().ShadowType = ShadowType.REAL_SHADOW;
                        actor.GetBehavior<ShadowBehavior>().RealShadow = true;
                    }
                    else
                    {
                        actor.GetBehavior<ShadowBehavior>().ShadowType = ShadowType.FAKE_SHADOW;
                        actor.GetBehavior<ShadowBehavior>().RealShadow = false;
                    }

                    mVisibleNum++;
                }
                else if (index < name_visible_num)
                {
                    actor.mVisibleCtrl.SetActorNameVisible();
                    mVisibleNum++;
                }
                else
                    actor.mVisibleCtrl.SetActorVisible(false, VisiblePriority.CULL);
                    
                ++index;
            }
        }

        /// <summary>
        /// 画质调整后，需要重新设置同屏人数
        /// </summary>
        void OnGraphicLevelChanged(int level)
        {
            Sort();
        }

        /// <summary>
        /// 玩家离开AOI后，需要将其从ActorMap中移除
        /// </summary>
        void OnLeaveAOI(CEventBaseArgs data)
        {
            uint uid = (uint)data.arg;

            if (mActorMap.ContainsKey(uid))
            {
                mActorMap.Remove(uid);
                //mDirty = true;
            }
        }

        /// <summary>
        /// 设置怪物的可见(is_summon 为 true表示召唤怪)
        /// </summary>
        /// <param name="is_visible"></param>
        public void SetMonsterVisible(bool is_visible, bool is_summon)
        {
            // 设置召唤怪的时候，也需要设置宠物
            if(is_summon)
            {
                using (var enumerator = ActorManager.Instance.PetSet.GetEnumerator())
                {
                    while (enumerator.MoveNext())
                    {
                        var cur = enumerator.Current;
                        var pet = cur.Value as Pet;
                        if (pet == null)
                            continue;

                        var create_param = pet.CreateParamInfo;
                        if (create_param.master == null || create_param.master != Game.Instance.LocalPlayerID)
                        {
                            pet.mVisibleCtrl.SetActorVisible(is_visible, false, false, VisiblePriority.CULL);
                        }
                    }
                }
            }

            // 设置怪物/召唤怪物
            using (var enumerator = ActorManager.Instance.MonsterSet.GetEnumerator())
            {
                var select_actor = LockTargetManager.Instance.SelectActor;
                while (enumerator.MoveNext())
                {
                    var cur = enumerator.Current;
                    var monster = cur.Value as Monster;
                    if(monster != null)
                    {
                        if(monster.IsBoss())
                            continue;

                        var create_param = monster.CreateParamInfo;
                        if (is_summon)
                        {
                            // 设置召唤怪的可见
                            if (monster.IsSummonMonster && (create_param.master == null || create_param.master != Game.Instance.LocalPlayerID))
                            {
                                if(monster == select_actor)// 选中的角色选中显示头顶名字和血条等
                                {
                                    monster.mVisibleCtrl.SetActorVisible(is_visible, false, true, VisiblePriority.CULL);
                                }
                                else
                                    monster.mVisibleCtrl.SetActorVisible(is_visible, false, false, VisiblePriority.CULL);
                            }
                                
                        }
                        else
                        {
                            // 设置普通怪物的可见
                            if (monster.IsSummonMonster == false)
                            {
                                if (monster == select_actor)// 选中的角色选中显示头顶名字
                                {
                                    monster.mVisibleCtrl.SetActorVisible(is_visible, false, true, VisiblePriority.CULL);
                                }
                                else
                                    monster.mVisibleCtrl.SetActorVisible(is_visible, false, false, VisiblePriority.CULL);
                            }
                                
                        }
                    }
                }
            }
        }
    }
}
