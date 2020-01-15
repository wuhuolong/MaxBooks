//-----------------------------------------
// WorshipModel.cs
// 膜拜模型组件，用于剑域盛会的膜拜功能
// lijiayong create
// 2017.12.20
//-----------------------------------------
using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;
namespace xc
{
    [wxb.Hotfix]
    public class WorshipModel : Actor
    {
        public uint RawUID { get; set; }

        private static uint sWorshipModelStartID = 200;// 200-299给膜拜雕像
        private static uint sWorshipModelIDCount = 100;
        private static uint sWorshipModelIndex = 0;

        /// <summary>
        /// 排行
        /// </summary>
        public uint Rank { get; set; }

        /// <summary>
        /// 帮派名字
        /// </summary>
        public string GuildName { get; set; }

        float mTouchSqrRadius = 4f;

        bool mIsTouching = false;

        bool IsLocalPlayerCloseEnough
        {
            get
            {
                var player = Game.GetInstance().GetLocalPlayer();
                if (player == null)
                    return false;

                return (player.transform.position - transform.position).sqrMagnitude < mTouchSqrRadius;
            }
        }

        public override void AfterCreate()
        {
            base.AfterCreate();
            Camp = 0xffffffff;
        }

        protected override void InitAOIData(xc.UnitCacheInfo info)
        {
            base.InitAOIData(info);

            if (ActorManager.Instance.WorshipModelSet.ContainsKey(info.UnitID) == false)
            {
                ActorManager.Instance.WorshipModelSet.Add(info.UnitID, this);
            }
            else
            {
                GameDebug.LogError("WorshipModel has conflict key " + info.UnitID.obj_idx);
            }

            float touchRadius = GameConstHelper.GetFloat("GAME_DUNGEON_WORSHIP_MODEL_TOUCH_RADIUS");
            mTouchSqrRadius = touchRadius * touchRadius;
        }

        public override void InitBehaviors()
        {
            AddBehavior(new WorshipModelHeadBehavior(this));

            base.InitBehaviors();
        }

        public override void OnResLoaded()
        {
            base.OnResLoaded();

            GetModelParent().name = "WorshipModel_" + Rank;

            // 雕像是静止不动的，所以要去除动画组件
            AnimationController animationController = GetModelParent().GetComponentInChildren<AnimationController>();
            if (animationController != null)
            {
                UnityEngine.Object.DestroyImmediate(animationController);
            }
            Animator[] animators = GetModelParent().GetComponentsInChildren<Animator>();
            if (animators != null)
            {
                foreach (Animator animator in animators)
                {
                    UnityEngine.Object.DestroyImmediate(animator);
                }
            }

            if (m_MatEffectCtrl != null)
            {
                m_MatEffectCtrl.AddEffectMat(float.MaxValue, MaterialEffectCtrl.MAT_TYPE.DEAD_TOMBSTONE, MaterialEffectCtrl.Priority.TOMB);
            }
        }

        override public void Update()
        {
            if (this == null)
            {
                return;
            }

            base.Update();

            if (mIsTouching == true)
            {
                if (IsLocalPlayerCloseEnough == false)
                {
                    OnTouchExit();
                }
            }
            else
            {
                if (IsLocalPlayerCloseEnough == true)
                {
                    OnTouchEnter();
                }
            }
        }

        void OnTouchEnter()
        {
            mIsTouching = true;

            GetBehavior<WorshipModelHeadBehavior>().ShowWorshipButton(true);

            Actor localPlayer = Game.Instance.GetLocalPlayer();
            if (localPlayer != null)
            {
                localPlayer.MoveCtrl.TryWalkAlongStop();
                localPlayer.Stop();
            }
        }

        void OnTouchExit()
        {
            mIsTouching = false;

            GetBehavior<WorshipModelHeadBehavior>().ShowWorshipButton(false);
        }

        /// <summary>
        /// 获取可用的唯一id
        /// </summary>
        /// <returns></returns>
        static uint GetAvailableUUId()
        {
            uint uuid = sWorshipModelStartID + sWorshipModelIndex % sWorshipModelIDCount;
            ++sWorshipModelIndex;
            return uuid;
        }

        /// <summary>
        /// 重置唯一id
        /// </summary>
        public static void ResetUUId()
        {
            sWorshipModelIndex = 0;
        }

        public static UnitID CreateWorshipModelForLua(uint type_id, uint uid, uint rank, string name, string guildName, uint honor, uint title, XLua.LuaTable modIdLst, XLua.LuaTable fashions, XLua.LuaTable suit_effects, Action<Actor> cbResLoad = null)
        {
            Vector3 pos = Vector3.zero;
            Quaternion rotation = Quaternion.identity;
            List<Neptune.Tag> tags = Neptune.DataHelper.GetTagListByType(Neptune.DataManager.Instance.Data, "special_pos");
            if (rank <= tags.Count)
            {
                pos = tags[(int)(rank - 1)].Position;
                pos = RoleHelp.GetPositionInScene(type_id, pos.x, pos.z);
                rotation = tags[(int)(rank - 1)].Rotation;
            }

            xc.UnitCacheInfo info = new xc.UnitCacheInfo(EUnitType.UNITTYPE_PLAYER, GetAvailableUUId());
            info.AOIPlayer.model_id_list = XLua.XUtils.CreateListByLuaTable<uint, uint>(modIdLst);
            info.AOIPlayer.fashions = XLua.XUtils.CreateListByLuaTable<uint, uint>(fashions);
            info.AOIPlayer.suit_effects = XLua.XUtils.CreateListByLuaTable<uint, uint>(suit_effects);
            info.AOIPlayer.type_idx = type_id;
            info.PosBorn = pos;
            info.Rotation = rotation;

            info.AOIPlayer.model_id_list.AddRange(info.AOIPlayer.fashions);

            ActorHelper.GetModelFashionList(info.AOIPlayer.model_id_list, info.AOIPlayer.model_id_list, info.AOIPlayer.fashions);

            var model = ActorManager.Instance.CreateActor<WorshipModel>(info, info.Rotation, null, true, cbResLoad);

            model.RawUID = uid;
            model.Rank = rank;
            model.UserName = name;
            model.GuildName = guildName;
            model.mActorAttr.Honor = honor;
            model.mActorAttr.Title = title;

            WorshipModelHeadBehavior worshipModelHeadBehavior = model.GetBehavior<WorshipModelHeadBehavior>();
            worshipModelHeadBehavior.ResetHeadInfo();
            worshipModelHeadBehavior.Honor = honor;
            worshipModelHeadBehavior.Title = title;

            return info.UnitID;
        }
    }
}

