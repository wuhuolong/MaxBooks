#define BEATTACK_LOW_PROPETY
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using xc.Dungeon;

namespace xc
{
    [wxb.Hotfix]
    public class ActorMachine
    {
        //-----------------------------------------------
        //    类型定义
        //-----------------------------------------------
        public enum EFSMState : byte
        {
            //空状态
            DS_NULL = 0,
            // 顶层状态
            DS_Normal,
            DS_Attacking,
            DS_BeAttacking,
            DS_Death,

            // 属于DS_Normal的子状态
            DS_Idle,
            DS_Walking,
            DS_Interaction, // 交互中状态
            DS_JumpScene, // 跳场景状态，不能被受击动作打断

            // 属于DS_BeAttacking的子状态
            // 被击退，后仰，击飞
            DS_BeAtkBackward,
            DS_NormalAttack,
        }

        public enum EFSMEvent : byte
        {
            DE_Walk = 0,
            DE_ResetWalk,
            DE_ReachDst,
            DE_Stop,
            DS_BeAtkNormal,
            DE_BeAtkBackward,
            DE_Death,
            DE_Relive,
            DE_NormalAttack,
            DE_Interaction,
            DE_JumpScene,
            DE_JumpSceneFinish
        }

        public enum EWalkMode : byte
        {
            EWM_Uninit = 0,
            EWM_Dst,            // 以目标点行走
            EWM_Dir,            // 延指定方向行走
        }

        public xc.Machine FSM
        {
            get { return mMachine; }
        }

        //-----------------------------------------------
        //  变量定义
        //-----------------------------------------------
        protected xc.Machine mMachine;
        private Actor mOwner;
        private Transform mOwnerTrans;
        private MoveImpl mMoveImpl;
        private EWalkMode mWalkMode = EWalkMode.EWM_Dst;
        private float mVerticalSpeed = 0.0f;// 垂直方向的速度

        public delegate void WalkToPointChange(Vector3 nextPoint);// 寻路行走时，当走到下一个节点时的回调
        public WalkToPointChange OnWalkToPointChange;
        public delegate void ReachTarget(Vector3 next);// 寻路行走时，走到目标点的回调
        public ReachTarget OnReachTarget;

        /// <summary>
        /// 角色行走目标点的位置
        /// </summary>
		private Vector3 mDst;

        /// <summary>
        /// 角色走到目标点的移动方向
        /// </summary>
		private Vector3 mDir;

        private bool mIsIdle = false;
        private bool mIsWalking = false;
        private bool mIsInInteraction = false;
        private bool mIsDead = false;
        private bool mIsAttacking = false;
        private bool mIsBeattacking = false;
        private bool mSwitch = false;

        private bool mbFlaseHitBack_should = false;    //是否进行假击退（只是用来标注应该要做假击退）
        private bool mbFalseHitBack = false;    //是否进行假击退
        private float mbFalseHitBackInterval = 0.2f; //假击退的时长
        private float mbFalseHitBackHasAnimTime = 0;    //假击退动画已经进行的时长
        private Vector3 mbFalseHitBackDestPos = Vector3.zero; //假击退的终点
        private Vector3 mbFalseHitBackStartPos = Vector3.zero; //假击退的起点

        public delegate void UpdateFunc();
        public UpdateFunc mkBackWardFunc = null;

        const string DeathAnimation = "die";

        /// <summary>
        /// 交互动画的名字
        /// </summary>
        string mInteractionAniName = string.Empty;

        /// <summary>
        /// 跳场景动画的名字
        /// </summary>
        string mJumpSceneAnimation = "";

        AnimatorCullingMode mCullingMode = AnimatorCullingMode.CullCompletely;

        //-----------------------------------------------
        //  属性访问器
        //-----------------------------------------------
        public bool IsIdle()
        {
            return mIsIdle;
        }

        public string InteractionAniName
        {
            get
            {
                return mInteractionAniName;
            }
        }

        public bool IsBeattacking
        {
            get
            {
                return mIsBeattacking;
            }
        }

		public bool IsWalking()
		{
			return mIsWalking;
		}

        public bool IsInInteraction
        {
            get
            {
                return mIsInInteraction;
            }
        }


        public bool IsAttacking()
		{
			return mIsAttacking;
		}
		
        /// <summary>
        /// 角色走到目标点的移动方向
        /// </summary>
		public Vector3 MoveDir
		{
			get{ return mDir;}
			set{ mDir = value;}
		}

        /// <summary>
        /// 在攻击时候改变移动方向
        /// </summary>
        /// <param name="dir">当在攻击中并且方向与之前不同时返回true</param>
        /// <returns></returns>
        public bool MoveDirInAttacking(Vector3 dir)
        {
            if (mIsAttacking && mDir != dir)
            {
                mDir = dir;
                mDir.Normalize();
                return true;
            }
            return false;
        }

		public EWalkMode WalkMode
		{
			get
			{
				return mWalkMode;
			}
		}
		
		public float MoveSpeed
		{
			set
			{
                mOwner.MoveSpeed = value;
			}
			get
            {
                return mOwner.MoveSpeed;
            }
		}

		//-----------------------------------------------
		//  函数定义
		//-----------------------------------------------
		public ActorMachine(Actor owner)
		{
			mOwner = owner;
			if (mOwner == null)
			{
				GameDebug.LogError("ActorMachine's owner is null");
			}
			else
			{
                mMoveImpl = mOwner.MoveImplement;
            }
        }

        public void AfterCreate()
        {
            if(mOwner != null)
            {
                mMoveImpl = mOwner.MoveImplement;
                mOwnerTrans = mOwner.transform;
            }
        }

        const string mMachinePoolKey = "actormachine";
        const string mStatePoolKey = "actormachine_state";

        /// <summary>
        /// 创建对应的角色状态
        /// </summary>
        xc.Machine.State CreateState(uint id, xc.Machine machine, xc.Machine.State owner = null)
        {
            var state = ObjCachePoolMgr.Instance.TryLoadCSharpObject<xc.Machine.State>(ObjCachePoolType.STATE, mStatePoolKey);
            if (state == null)
            {
                state = new xc.Machine.State(id, mMachine, owner);
            }
            else
                state.Reset(id, machine, null);

            return state;
        }

        bool mIsRecycled = false;

        /// <summary>
        /// 回收角色状态对象
        /// </summary>
        void RecycleState()
        {
            if (mIsRecycled)
                return;

            mIsRecycled = true;

            if (mMachine == null)
                return;

            var state_list = mMachine.StateList;
            foreach (var state in state_list)
            {
                state.Release();
                ObjCachePoolMgr.Instance.RecycleCSharpObject(state, ObjCachePoolType.STATE, mStatePoolKey);
            }
        }

		public void Init()
		{
			// 初始化状态机
            mMachine = ObjCachePoolMgr.Instance.TryLoadCSharpObject<xc.Machine>(ObjCachePoolType.MACHINE, mMachinePoolKey);
            if (mMachine == null)
            {
                mMachine = new xc.Machine();
            }
            else
            {
                mMachine.Reset();
            }

            // 构建状态图
            // 第一层状态: normal, beattacking, attacking, death, transfering
            xc.Machine.State normalState = CreateState((uint)EFSMState.DS_Normal, mMachine);
			xc.Machine.State beattackingState = CreateState((uint)EFSMState.DS_BeAttacking, mMachine);
			xc.Machine.State attackingState = CreateState((uint)EFSMState.DS_Attacking, mMachine);
			xc.Machine.State deathState = CreateState((uint)EFSMState.DS_Death, mMachine);
            xc.Machine.State jumpsceneState = CreateState((uint)EFSMState.DS_JumpScene, mMachine);

            // normal state的子状态
            xc.Machine.State normalNullState = CreateState((uint)EFSMState.DS_NULL, mMachine, normalState);
			xc.Machine.State idleState = CreateState((uint)EFSMState.DS_Idle, mMachine, normalState);
			xc.Machine.State walkState = CreateState((uint)EFSMState.DS_Walking, mMachine, normalState);
            xc.Machine.State interactionState = CreateState((uint)EFSMState.DS_Interaction, mMachine, normalState);

            // attacking state的子状态
            xc.Machine.State nullAttackState = CreateState((uint)EFSMState.DS_NULL, mMachine, attackingState);
			xc.Machine.State normalAttackState = CreateState((uint)EFSMState.DS_NormalAttack, mMachine, attackingState);

			// beattacking state的子状态
			xc.Machine.State beAtkNullState = CreateState((uint)EFSMState.DS_NULL, mMachine, beattackingState);
            xc.Machine.State beAtkBackwardState = CreateState((uint)EFSMState.DS_BeAtkBackward, mMachine, beattackingState);

            // 设置初始子状态
            normalState.SetChild(idleState);
			beattackingState.SetChild(beAtkNullState);
			attackingState.SetChild(nullAttackState);

			// 设置Enter/Exit/Update State的函数
			normalState.SetEnterFunction(EnterState_Normal);
            normalState.SetExitFunction(ExitState_Normal);
            attackingState.SetEnterFunction(EnterState_Attacking);
			attackingState.SetUpdateFunction(UpdateState_Attacking);
			attackingState.SetExitFunction(ExitState_Attacking);
			beattackingState.SetEnterFunction(EnterState_BeAttacking);
			beattackingState.SetExitFunction(ExitState_BeAttacking);
			deathState.SetEnterFunction(EnterState_Death);
			deathState.SetUpdateFunction(UpdateState_Death);
			deathState.SetExitFunction(ExitState_Death);

			idleState.SetEnterFunction(EnterState_Idle);
			idleState.SetUpdateFunction(UpdateState_Idle);
            idleState.SetExitFunction(ExitState_Idle);
			walkState.SetEnterFunction(EnterState_Walk);
			walkState.SetUpdateFunction(UpdateState_Walk);
			walkState.SetExitFunction(ExitState_Walk);
            interactionState.SetEnterFunction(EnterState_Interaction);
            interactionState.SetUpdateFunction(UpdateState_Interaction);
            interactionState.SetExitFunction(ExitState_Interaction);
            jumpsceneState.SetEnterFunction(EnterState_JumpScene);
            jumpsceneState.SetUpdateFunction(UpdateState_JumpScene);
            jumpsceneState.SetExitFunction(ExitState_JumpScene);

            beAtkBackwardState.SetEnterFunction(EnterState_BeAtkBackward);
			beAtkBackwardState.SetUpdateFunction(UpdateState_BeAtkBackward);
			
			normalAttackState.SetEnterFunction(EnterState_NormalAttack);
			normalAttackState.SetUpdateFunction(UpdateState_NormalAttack);
			normalAttackState.SetExitFunction(ExitState_NormalAttack);

			//// 构建状态图
			//// 第一层
            // normal
			normalState.AddTransition((uint)EFSMEvent.DE_BeAtkBackward, beattackingState);
			normalState.AddTransition((uint)EFSMEvent.DE_NormalAttack, attackingState);
			normalState.AddTransition((uint)EFSMEvent.DE_Death, deathState);
            normalState.AddTransition((uint)EFSMEvent.DE_JumpScene, jumpsceneState);
            // jumpscene
            jumpsceneState.AddTransition((uint)EFSMEvent.DE_JumpSceneFinish, normalState);
            jumpsceneState.AddTransition((uint)EFSMEvent.DE_Death, deathState);
            jumpsceneState.AddTransition((uint)EFSMEvent.DE_Stop, normalState);
            // death
            deathState.AddTransition((uint)EFSMEvent.DE_Relive, normalState);
            deathState.AddTransition((uint)EFSMEvent.DE_JumpScene, jumpsceneState); // 防止死亡后的异常
            // beattacking
            beattackingState.AddTransition((uint)EFSMEvent.DE_Stop, normalState);
			beattackingState.AddTransition((uint)EFSMEvent.DE_Death, deathState);
            beattackingState.AddTransition((uint)EFSMEvent.DE_JumpScene, jumpsceneState);
            // 受击的优先级最低，需要增加受击到各状态的转换 @rr add 2016.10.10 
#if BEATTACK_LOW_PROPETY
            beattackingState.AddTransition((uint)EFSMEvent.DE_NormalAttack, attackingState);
            beattackingState.AddTransition((uint)EFSMEvent.DE_Walk, normalState);
#endif
            // attacking
			attackingState.AddTransition((uint)EFSMEvent.DE_Stop, normalState);
            attackingState.AddTransition((uint)EFSMEvent.DE_NormalAttack, attackingState);
            attackingState.AddTransition((uint)EFSMEvent.DE_JumpScene, jumpsceneState);
            // 受击的优先级最低,攻击时不能被受击打断 @rr del 2016.10.10
#if !BEATTACK_LOW_PROPETY
            attackingState.AddTransition((uint)EFSMEvent.DE_BeAtkThrowAway, beattackingState);
            attackingState.AddTransition((uint)EFSMEvent.DE_BeAtkBackward, beattackingState);
#endif

            //// 第二层
            // normal state的子状态图
            normalNullState.AddTransition((uint)EFSMEvent.DE_Stop, idleState);
			normalNullState.AddTransition((uint)EFSMEvent.DE_ReachDst, idleState);
			normalNullState.AddTransition((uint)EFSMEvent.DE_Walk, walkState);
            normalNullState.AddTransition((uint)EFSMEvent.DE_Interaction, interactionState);
            normalNullState.AddTransition((uint)EFSMEvent.DE_Relive, idleState);

            idleState.AddTransition((uint)EFSMEvent.DE_Walk, walkState);
			idleState.AddTransition((uint)EFSMEvent.DE_BeAtkBackward, normalNullState);
			idleState.AddTransition((uint)EFSMEvent.DE_NormalAttack, normalNullState);
            idleState.AddTransition((uint)EFSMEvent.DE_Interaction, interactionState);
            idleState.AddTransition((uint)EFSMEvent.DE_Death, normalNullState);
			idleState.AddTransition((uint)EFSMEvent.DE_Stop, idleState);
            idleState.AddTransition((uint)EFSMEvent.DE_JumpScene, normalNullState);

            walkState.AddTransition((uint)EFSMEvent.DE_ReachDst, idleState);
            walkState.AddTransition((uint)EFSMEvent.DE_ResetWalk, walkState); // 增加walk事件的响应，使其重新调用EnterState_Walk
			walkState.AddTransition((uint)EFSMEvent.DE_BeAtkBackward, normalNullState);
			walkState.AddTransition((uint)EFSMEvent.DE_NormalAttack, normalNullState);
            walkState.AddTransition((uint)EFSMEvent.DE_Interaction, interactionState);
            walkState.AddTransition((uint)EFSMEvent.DE_Death, normalNullState);
            walkState.AddTransition((uint)EFSMEvent.DE_Stop, idleState);
            walkState.AddTransition((uint)EFSMEvent.DE_JumpScene, normalNullState);

            interactionState.AddTransition((uint)EFSMEvent.DE_Walk, walkState);
            interactionState.AddTransition((uint)EFSMEvent.DE_BeAtkBackward, normalNullState);
            interactionState.AddTransition((uint)EFSMEvent.DE_NormalAttack, normalNullState);
            interactionState.AddTransition((uint)EFSMEvent.DE_Death, normalNullState);
            interactionState.AddTransition((uint)EFSMEvent.DE_Stop, idleState);
            interactionState.AddTransition((uint)EFSMEvent.DE_JumpScene, normalNullState);

            // beattacking state的子状态图
            beAtkNullState.AddTransition((uint)EFSMEvent.DE_BeAtkBackward, beAtkBackwardState);

            beAtkBackwardState.AddTransition((uint)EFSMEvent.DE_BeAtkBackward, beAtkBackwardState);
			beAtkBackwardState.AddTransition((uint)EFSMEvent.DE_Stop, beAtkNullState);
            beAtkBackwardState.AddTransition((uint)EFSMEvent.DE_JumpScene, beAtkNullState);

            // attacking state的子状态图
            nullAttackState.AddTransition((uint)EFSMEvent.DE_NormalAttack, normalAttackState);
			
			normalAttackState.AddTransition((uint)EFSMEvent.DE_Stop, nullAttackState);
			normalAttackState.AddTransition((uint)EFSMEvent.DE_NormalAttack, normalAttackState);
            normalAttackState.AddTransition((uint)EFSMEvent.DE_JumpScene, nullAttackState);

            mMachine.SetCurState(normalState);
		}

        /// <summary>
        /// 角色资源加载完毕后调用
        /// </summary>
        public void OnResLoaded()
        {

        }

		//-----------------------------------------------
		//  受击类型触发事件
		//-----------------------------------------------
        /// <summary>
        /// 根据伤害信息来切换受击状态
        /// </summary>
        public void BeattackState(Damage dam)
		{
            // 只有的Idle或受击状态下才能切换受击状态（受击状态的优先级最低） @rr 2016.10.9
            // 在交互过程中要判断是否能被受击打断
            if (!IsIdle() && !IsBeattacking && (!IsInInteraction || !mOwner.CanBeInterruptedWhenInInteractionAndBeAttacked))
                return;

            // 晕眩等情况下不受击
            if(mOwner.HasBattleState(BattleStatusType.BATTLE_STATUS_TYPE_SBeattackMotionDisable))
                return;

            InitFalseHitBack(dam);

            Vector3 dir = Vector3.zero;
			switch (dam.BeattackState)
			{
                case Damage.EBeattackState.BS_BendBack:
                {
                    MoveSpeed = 0;
                    Stop();
                    BeattackBendback();
                    if (!mOwner.IsFreezeState)
                        mOwner.UnFreeze();
                    mMachine.React((uint)ActorMachine.EFSMEvent.DE_BeAtkBackward);
                } break;
				default:
                    mMachine.React((uint)ActorMachine.EFSMEvent.DS_BeAtkNormal);
					break;
			}
		}

		//-----------------------------------------------
		//  各状态的Enter/Exit/Update函数
		//-----------------------------------------------
		// 第一层状态： 普通、攻击和受击
		public void EnterState_Normal(xc.Machine.State s) // Normal State
		{

		}

        public void ExitState_Normal(xc.Machine.State s) // Normal State
        {

        }

        public void EnterState_Attacking(xc.Machine.State s)// Attack State
		{
            mIsAttacking = true;

            if (mOwner.mRideCtrl != null && mOwner.mRideCtrl.IsRiding())
            {
                mOwner.mRideCtrl.UnRide(true);
            }
        }
		
		public void ExitState_Attacking(xc.Machine.State s)
		{
            mIsAttacking = false;

			if (mOwner.GetCurSkill() != null)
            {
                mOwner.GetCurSkill().Interrupt();
            }
        }
		
		public void UpdateState_Attacking(xc.Machine.State s)
		{

		}

		public void EnterState_BeAttacking(xc.Machine.State s)// BeAttack State
		{
            mIsBeattacking = true;
		}
		
		public void ExitState_BeAttacking(xc.Machine.State s)
		{
            mIsBeattacking = false;
            //强制关闭“假击退”
            ForceStopFalseHitBack();
        }

        public void ForceStopFalseHitBack()
        {
            if (mbFalseHitBack)
            {
                if(mOwner != null && mOwner.transform != null)
                {
                    mOwner.transform.position = mbFalseHitBackStartPos;
                }
                mbFalseHitBack = false;
                mbFlaseHitBack_should = false;
            }
        }
        public void InitFalseHitBack(Damage dam)
        {
            if (mOwner == null || mOwner.transform == null)
                return;
            if (mOwner is Player)
                return;
            DBSkillSev.SkillInfoSev info_sev = DBManager.Instance.GetDB<DBSkillSev>().GetSkillInfo(dam.SkillID);
            if (info_sev == null || info_sev.IsFalseHitBack == false)
                return;
            ForceStopFalseHitBack();
            Actor attacker = ActorManager.Instance.GetActor(dam.SrcID);
            Vector3 hitBackForward;
            if (attacker != null && attacker.transform != null)
            {
                hitBackForward = (mOwner.transform.position - attacker.transform.position).normalized;
            }
            else if (mOwner != null && mOwner.transform != null)
                hitBackForward = -mOwner.transform.forward;
            else
                return;
            mbFalseHitBackStartPos = mOwner.transform.position; //假击退的起点
            mbFalseHitBackDestPos = mbFalseHitBackStartPos + hitBackForward * 0.5f; //假击退的终点
            mbFalseHitBackInterval = 0.15f; //假击退的时长
            mbFalseHitBackHasAnimTime = 0;    //假击退动画已经进行的时长
            mbFlaseHitBack_should = true;
        }
        /// <summary>
        /// 死亡击飞后是否落地
        /// </summary>
        bool mDeathFlyDown = false;

        public class DeathInfo
        {
            public bool IsFlying = false; // 是否死亡后击飞
            public float MoveXSpeed = 0; // 击飞后的水平速度
            public float MoveXFric = 0; // 击飞后的水平摩擦系数
            public float MoveYSpeed = 0; // 击飞后的高度方向的速度
            public Vector3 MoveDir = Vector3.zero; // 浮空的方向
        }

        DeathInfo mDeathInfo = new DeathInfo();
        /// <summary>
        /// 死亡击飞的信息
        /// </summary>
        public DeathInfo DeathFlyInfo
        {
            set
            {
                mDeathInfo = value;
            }
        }

        /// <summary>
        /// 重力参数
        /// </summary>
        ushort m_Gravity = 50;

        /// <summary>
        /// 进入死亡状态
        /// </summary>
        public void EnterState_Death(xc.Machine.State s)
		{
            m_Gravity = DBActor.Gravity;

            // 下坐骑
            if (mOwner.mRideCtrl != null && mOwner.mRideCtrl.IsRiding())
            {
                mOwner.mRideCtrl.UnRide(true);
            }

            // Unfreeze
			mOwner.UnFreeze();

            // 获取死亡动作
			AnimationOptions op = GetAnimationOptions(Actor.EAnimation.death);

            bool is_shape_shifted = mOwner.IsShapeShift;// 删除buff前判断是否在变身状态

            // 删除buff
            if (mOwner.BuffCtrl != null)
                mOwner.BuffCtrl.DelAllBuff();
			
			if (!mIsDead)// 角色之前还进入死亡时，则播放死亡动作
			{				
				mIsDead = true;

                // 先检查是否有浮空动作
                AnimationOptions floatingOp = GetAnimationOptions(Actor.EAnimation.floating);
                if(!mOwner.HasAnimation(floatingOp.Name) || is_shape_shifted)// 变身状态、没有击飞动画时
                    mDeathInfo.IsFlying = false;

                if(!mDeathInfo.IsFlying)
                {
                    PlayAnimation(op);
                }
                else
                {
                    // 移动方向
                    MoveDir = mDeathInfo.MoveDir;
                    // 移动速度
                    MoveSpeed = mDeathInfo.MoveXSpeed;
                    mVerticalSpeed = mDeathInfo.MoveYSpeed;
                    m_Gravity = mOwner.ActorAttribute.Gravity;
                    // 播放动画
                    PlayAnimation(floatingOp);
                    
                    mSwitch = false;
                    mDeathFlyDown = false;
                }
			}
			else
			{
                SkillEffectPlayer effect_player = mOwner.SkillEffectPlayer;
                if(effect_player != null)
                    effect_player.PlayEffect(DeathAnimation);
			}

            if(mOwner.IsLocalPlayer)
                ClientEventMgr.GetInstance().FireEvent((int)ClientEvent.CE_LOCAL_PLAYER_NWAR_DEAD, null);

            if (SceneHelp.Instance.IsInWorldBossExperienceInstance && mOwner.IsLocalPlayer == false && mOwner.IsPlayer())
                mOwner.SetNameLayoutVisiable(false);
        }
		
        /// <summary>
        /// 更新死亡状态
        /// </summary>
		public void UpdateState_Death(xc.Machine.State s)
		{
            if(mMoveImpl == null)
                return;

            if(!mDeathInfo.IsFlying)
            {
    			if (!IsGrounded())
    			{
    				Vector3 move = MoveSpeed * mDir * Time.deltaTime;
    				move.y = mVerticalSpeed * Time.deltaTime;
    				mMoveImpl.Move(move,true, false);
    				
    				mVerticalSpeed -= Time.deltaTime * m_Gravity;
    			}

                // 因此在死亡前可能有恢复了变身状态，播放死亡动画的不是当前的模型
                // 因此需要在此处检查下Animator下的状态是否正常
                if(!mOwner.IsInAnimationState(DeathAnimation))
                {
                    PlayAnimation(DeathAnimation);
                }
            }
            else
            {
                // 浮空上升阶段
                if (mVerticalSpeed > 0.0f || !mMoveImpl.IsGrounded)
                {
                    Vector3 move = mDir * MoveSpeed * Time.deltaTime;// xz平面的移动
                    move.y = mVerticalSpeed * Time.deltaTime;// y高度的移动
                    
                    mVerticalSpeed -= Time.deltaTime * m_Gravity;

                    MoveSpeed -= Time.deltaTime * mDeathInfo.MoveXFric;
                    MoveSpeed = Mathf.Max(MoveSpeed, 0);
                    mMoveImpl.Move(move, false, false);
                }

                // 浮空下落阶段
                if (mSwitch == false && mVerticalSpeed <= 0.0f)
                {
                    AnimationOptions op = GetAnimationOptions(Actor.EAnimation.falling);
                    PlayAnimation(op);
                    mSwitch = true;
                }

                // 落地阶段
                if (mDeathFlyDown == false && mMoveImpl.IsGrounded)
                {
                    AnimationOptions falldownOp = GetAnimationOptions(Actor.EAnimation.falldown);
                    PlayAnimation(falldownOp);
                    mDeathFlyDown = true;
                }
            }
		}
		
		public void ExitState_Death(xc.Machine.State s)
		{
			mIsDead = false;
            MoveSpeed = 0.0f;
            mVerticalSpeed = 0.0f;
            if (mOwner != null && mOwner.IsLocalPlayer)
                ClientEventMgr.GetInstance().FireEvent((int)ClientEvent.CE_LOCAL_PLAYER_NWAR_REVIVE, null);
        }

        /// <summary>
        /// 是否处于战斗状态
        /// </summary>
        bool mInBattleStatus = false;

		// 第二层状态： normal State 的子状态
		public void EnterState_Idle(xc.Machine.State s) // idle State
		{
            mIsIdle = true;
            mOwner.FireActorEvent(Actor.ActorEvent.ENTERIDLE, null);
            mWalkMode = EWalkMode.EWM_Uninit;
            CrossFadeAnimation(mOwner.GetIdleAniOptions());
            mInBattleStatus = mOwner.InBattleStatus;
        }

		public void  UpdateState_Idle(xc.Machine.State s)
		{
            if(mInBattleStatus != mOwner.InBattleStatus)
            {
                mInBattleStatus = mOwner.InBattleStatus;
                CrossFadeAnimation(mOwner.GetIdleAniOptions());
            }
        }

        void ExitState_Idle(xc.Machine.State s)
        {
            mIsIdle = false;
            mOwner.FireActorEvent(Actor.ActorEvent.EXITIDLE, null);

            if (mOwner is LocalPlayer)
            {
                xc.ClientEventManager<ClientEvent>.Instance.FireEvent(ClientEvent.PLAYER_EXIT_IDLE, null);
            }
        }

		public void EnterState_Walk(xc.Machine.State s) // Walk State
		{
            AnimationOptions op = mOwner.GetWalkAniOptions();

            if (op != null)
            {
                if (0.0f == MoveSpeed)
                    MoveSpeed = op.Speed;

                float scale = op.OriSpeed != 0 ? MoveSpeed / op.OriSpeed : 1.0f;
                mOwner.SetMoveAnimationSpeed(scale);
                CrossFadeAnimation(op);
            }

            CalcMovePath();
            mIsWalking = true;
            mInBattleStatus = mOwner.InBattleStatus;

        }
		
		public void ExitState_Walk(xc.Machine.State s)
		{
            mIsWalking = false;
            OnWalkToPointChange = null;
            OnReachTarget = null;
		}
		
		public void UpdateState_Walk(xc.Machine.State s)
		{
            if (mOwner == null)
                return;

            if (mInBattleStatus != mOwner.InBattleStatus)
            {
                mInBattleStatus = mOwner.InBattleStatus;
                AnimationOptions op = mOwner.GetWalkAniOptions();
                if (op != null)
                {
                    float scale = op.OriSpeed != 0 ? MoveSpeed / op.OriSpeed : 1.0f;
                    mOwner.SetMoveAnimationSpeed(scale);
                    CrossFadeAnimation(op);
                }
            }

            // 变身状态下，播放动画的不是当前的模型
            // 因此需要在此处检查下Animator下的状态是否正常
            var walkOpt = mOwner.GetWalkAniOptions();
            if(walkOpt != null)
            {
                if (!mOwner.IsInAnimationState(walkOpt.Name))
                    CrossFadeAnimation(walkOpt);
            }

            UpdateMoveToDest();
		}

        XNavMeshPath walkMeshPath = new XNavMeshPath();// 自动寻路的路径

        BetterList<Vector3> mDestList = new BetterList<Vector3>(); //自动寻路的下一目标点

        public BetterList<Vector3> DestList
        {
            get
            {
                return mDestList;
            }
        }

        public List<Vector3> PathPointList = new List<Vector3>();   // 自动寻路的路点

        float minCornerDis = 0.1f * 0.1f;

        /// <summary>
        /// 计算到目标点的路径
        /// </summary>
        void CalcMovePath()
        {
            if (mWalkMode == EWalkMode.EWM_Dst)// 只有走到目标点的行走方式才需要寻路
            {
                mDestList.Clear();
                walkMeshPath.ClearCorners();
                XNavMesh.CalculatePath(mOwnerTrans.position, mDst, LevelManager.GetInstance().AreaExclude, walkMeshPath);
                if(walkMeshPath.status == XNavMeshPathStatus.PathComplete && walkMeshPath.corners.GetLength(0) >= 2)
                {
                    // 调整路径的拐弯点
                    Vector3[] adjuestCorners = walkMeshPath.corners;

#if UNITY_EDITOR
                    if (mOwner is LocalPlayer)
                    {
                        for (int j = 1; j < adjuestCorners.Length; ++j)
                        {
                            Debug.DrawLine(adjuestCorners[j - 1], adjuestCorners[j], Color.red, 1.0f * adjuestCorners.Length);
                        }
                    }
#endif

                    int len = adjuestCorners.Length;
                    if(len > 3)
                    {
                        adjuestCorners = new Vector3[len];
                        adjuestCorners[0] = walkMeshPath.corners[0];
                        for(int i = 1; i < len; ++i)
                        {
                            if(i + 1>=len)
                            {
                                adjuestCorners[i] = walkMeshPath.corners[i];
                                break;
                            }

                            Vector3 pre_vec = walkMeshPath.corners[i-1]-walkMeshPath.corners[i];
                            pre_vec.y = 0;
                            pre_vec.Normalize();
                            Vector3 next_vec = walkMeshPath.corners[i+1]-walkMeshPath.corners[i];
                            next_vec.y = 0;
                            next_vec.Normalize();
                            if(pre_vec.sqrMagnitude < minCornerDis || next_vec.sqrMagnitude < minCornerDis)
                            {
                                adjuestCorners[i] = walkMeshPath.corners[i];
                                continue;
                            }

                            // 先计算调整后的位置(增加MoveImpl.Radius)
                            Vector3 middle_vec = pre_vec + next_vec;
                            var adjuestCorner = walkMeshPath.corners[i] - middle_vec * (0.8f + MoveImpl.Radius * 2);

                            // 在该位置点附近进行采样
                            XNavMeshHit nearestHit;
                            if (XNavMesh.SamplePosition(adjuestCorner, out nearestHit, 5f, LevelManager.GetInstance().AreaExclude))
                            {
                                // 如果调整后的位置可行走，则使用新位置，否则使用原始位置
                                var dis = nearestHit.position - adjuestCorner;
                                if (dis.sqrMagnitude < 0.01f)
                                    adjuestCorners[i] = walkMeshPath.corners[i] - middle_vec * 0.8f;
                                else
                                    adjuestCorners[i] = walkMeshPath.corners[i];
                            }
                            else
                                adjuestCorners[i] = walkMeshPath.corners[i];
                        }
                    }

                    mDst = adjuestCorners[1];
                    for (int j=1; j<adjuestCorners.Length; ++j)
                    {
                        mDestList.Add(adjuestCorners[j]);
                    }

                    if(mOwner.IsLocalPlayer)
                        ClientEventMgr.GetInstance().FireEvent((int)ClientEvent.CE_ACTOR_PATH_POINTS_CHANGED, null);

#if UNITY_EDITOR
                    if (mOwner is LocalPlayer)
                    {
                        for (int j = 1; j < adjuestCorners.Length; ++j)
                        {
                            Debug.DrawLine(adjuestCorners[j - 1], adjuestCorners[j], Color.green, 1f * adjuestCorners.Length);
                        }
                    }
#endif
                }
                else
                {
                    // 如果寻路不成功，则设置目标点为初始点
                    mDst = mOwnerTrans.position;
                }
                mWalkToPoint = false;
            }
        }


        bool mWalkToPoint = false;
        void UpdateMoveToDest()
        {
            Vector3 move = Vector3.zero;
            if (mWalkMode == EWalkMode.EWM_Dst)
            {
                // 开始移动时，需要先同步一次位置
                if(mWalkToPoint == false)
                {
                    mWalkToPoint = true;
                    if(OnWalkToPointChange!= null)
                        OnWalkToPointChange(mDst);
                }

                Vector3 d = mDst;
                d.y = 0.0f;
                Vector3 p = mOwnerTrans.position;
                p.y = 0.0f;
                Vector3 vec = d - p;
                float ds = MoveSpeed * Time.deltaTime;

                if (vec.magnitude <= ds)
                {
                    move = vec;
                    mOwner.MoveImplement.Move(move, true);
                    if(mDestList.size <= 0)
                    {
                        TurnDirImmediate(move);
                        ReachDst();//TODO @hzb 跳转进副本后，如果角色没有进一步动作，此处会不停调用
                        return;
                    }
                    else
                    {
                        // 到达目标位置后，从mDestList中移除第一个点
                        mDestList.RemoveAt(0);
                        if (mDestList.size <= 0)
                        {
                            TurnDirImmediate(move);
                            ReachDst();
                            return;
                        }

                        mDst = mDestList[0];

                        if (OnWalkToPointChange!= null)
                        {
                            OnWalkToPointChange(mDst);
                        }
                        return;
                    }
                }

                mDir = vec.normalized;
                move.x = mDir.x * MoveSpeed * Time.deltaTime;
                move.z = mDir.z * MoveSpeed * Time.deltaTime;
            }
            else
            {
                move.x = mDir.x * MoveSpeed * Time.deltaTime;
                move.z = mDir.z * MoveSpeed * Time.deltaTime;
            }
            
            //if (!IsGrounded())
            //    move.y = -Time.deltaTime  * 0.3f;
            
            TurnDirSmooth(move);
            mOwner.MoveImplement.Move(move, true);
        }

        public void EnterState_Interaction(xc.Machine.State s) // Interaction State
        {
            //GameDebug.LogError("EnterState_Interaction");
            mIsInInteraction = true;
            mOwner.Play(mInteractionAniName);
        }

        public void ExitState_Interaction(xc.Machine.State s)
        {
            //GameDebug.LogError("ExitState_Interaction");
            mIsInInteraction = false;
            if(mOwner != null && mOwner.IsLocalPlayer)
            {
                ClientEventMgr.GetInstance().FireEvent((int)ClientEvent.CE_LOCAL_PLAYER_EXIT_INTERACTION, new CEventBaseArgs(null));
            }
        }

        public void UpdateState_Interaction(xc.Machine.State s)
        {

        }

        float mJumpTime = 0;
        float mJumpMaxTime = 3.0f;
        public void EnterState_JumpScene(xc.Machine.State s) // JumpScene State
        {
            Debug.Log("EnterState_JumpScene");
            mJumpTime = Time.time;
            if (mOwner.AnimationCtrl != null)
            {
                mCullingMode = mOwner.AnimationCtrl.CullMode;
                mOwner.AnimationCtrl.CullMode = AnimatorCullingMode.AlwaysAnimate;
            }

            if(mOwner.HasAnimation(mJumpSceneAnimation))
            {
                mOwner.Play(mJumpSceneAnimation);
                mJumpMaxTime = 3.0f;
            }
            else
                mJumpMaxTime = 1.0f;
        }

        public void UpdateState_JumpScene(xc.Machine.State s)
        {
            float curTime = Time.time;
            if (!mOwner.IsPlaying(mJumpSceneAnimation) || curTime - mJumpTime > mJumpMaxTime)
            {
                mMachine.React((uint)ActorMachine.EFSMEvent.DE_JumpSceneFinish);
            }
        }

        public void ExitState_JumpScene(xc.Machine.State s)
        {
            Debug.Log("ExitState_JumpScene");
            if (mOwner.AnimationCtrl != null)
            {
                mOwner.AnimationCtrl.CullMode = mCullingMode;
            }
            mOwner.FireActorEvent(Actor.ActorEvent.EXIT_JUMPSCENE_STATE, null);
        }

        // 第二层状态： Attack State的子状态
        public void EnterState_NormalAttack(xc.Machine.State s) //normalAttackState
		{
            mWalkToPoint = false;
		}

		public void UpdateState_NormalAttack(xc.Machine.State s)
		{
            UpdateMove(Time.deltaTime);
            //UpdateMoveToDest();
        }

		public void ExitState_NormalAttack(xc.Machine.State s)
		{

		}


		//第二层状态： beAttacking的子状态 
		public void EnterState_BeAtkBackward(xc.Machine.State s) //beAtkBackwardState
		{
			AnimationOptions op = mOwner.GetAnimationOptions(Actor.EAnimation.beAtk_Backward);
            PlayAnimation(op);

			mVerticalSpeed = 0;

            if (mbFlaseHitBack_should)
            {
                mbFalseHitBack = true;    //是否进行假击退
                mbFlaseHitBack_should = false;
            }
        }

		public void UpdateState_BeAtkBackward(xc.Machine.State s)
		{	
			if (mkBackWardFunc != null)
				mkBackWardFunc();
		}
		
        /// <summary>
        /// 播放受击动作
        /// </summary>
		void UpdateAnimationStage()
		{
            if(mbFalseHitBack)
            {
                mbFalseHitBackHasAnimTime = mbFalseHitBackHasAnimTime + Time.deltaTime;
                if (mbFalseHitBackHasAnimTime >= mbFalseHitBackInterval)
                {
                    mbFalseHitBackHasAnimTime = mbFalseHitBackInterval;
                    mbFalseHitBack = false;
                    mbFlaseHitBack_should = false;
                }
                float percent = mbFalseHitBackHasAnimTime / mbFalseHitBackInterval;
                Vector3 new_pos = Vector3.zero;
                if (percent <= 0.5f)
                    new_pos = (mbFalseHitBackDestPos - mbFalseHitBackStartPos) * percent / 0.5f + mbFalseHitBackStartPos;
                else
                    new_pos = (mbFalseHitBackStartPos - mbFalseHitBackDestPos) * (percent - 0.5f) / 0.5f + mbFalseHitBackDestPos;
                mOwner.SetPosition(new_pos);
            }

            // 受击动作播放完毕后再退出受击状态
			AnimationOptions op = GetAnimationOptions(Actor.EAnimation.beAtk_Backward);

            if(!mOwner.IsPlaying(op.Name))
            {
                MoveSpeed = 0.0f;
                mkBackWardFunc = null;
                mMachine.React((uint)EFSMEvent.DE_Stop);
            }
		}

        void UpdateMove(float deltaTime)
		{
            if (mMoveImpl == null)
            {
                return;
            }

            Vector3 move = mDir * MoveSpeed * deltaTime;

			mMoveImpl.Move(move, true, false);
		}
		
		void TurnDirImmediate(Vector3 dir)
		{
			if (mOwner != null)
				mOwner.TurnDir(dir);
		}

		private void TurnDirSmooth(Vector3 dir)
		{
            //TurnDirImmediate(dir);
            //return;
            if (Mathf.Abs(dir.x) < 1.0e-6f && Mathf.Abs(dir.z) < 1.0e-6f)
            {
                return;
            }

            Vector3 curDir = mOwnerTrans.forward;
            float degrees = Vector3.Angle(curDir, dir);
            Vector3 newDir;
            if(degrees <= 30.0f)
            {
                float step = 16.0f * Time.deltaTime;
                newDir = Vector3.RotateTowards(curDir, dir, step, 0);
            }
            else
            {
                float step = degrees/30.0f * 16.0f * Time.deltaTime;
                newDir = Vector3.RotateTowards(curDir, dir, step, 0);
            }
            mOwnerTrans.forward = newDir;
		}
        
		public bool ReachDst()
		{
            if(OnReachTarget!= null)
            {
                OnReachTarget(mDst);
                OnReachTarget = null;
            }

            return mMachine.React((uint)EFSMEvent.DE_ReachDst);
		}

		AnimationOptions GetAnimationOptions(Actor.EAnimation id)
		{
			return mOwner.GetAnimationOptions(id);
		}

        /// <summary>
        /// 播放动画
        /// </summary>
        /// <param name="op"></param>
		void PlayAnimation(AnimationOptions op)
		{
			mOwner.Play(op);
		}

        /// <summary>
        /// 播放指定名字的动画
        /// </summary>
        /// <param name="ani"></param>
        void PlayAnimation(string ani)
        {
            mOwner.Play(ani);
        }

        /// <summary>
        /// 播放融合动画
        /// </summary>
        /// <param name="op"></param>
		void CrossFadeAnimation(AnimationOptions op)
		{
			mOwner.CrossFade(op);
		}

		bool IsGrounded()
		{
			return mOwner.IsGrounded();
		}

		public bool IsDead()
		{
			return mIsDead;
		}

		public bool Stop()
		{
			if (mIsDead)
			{
				return true;
			}
            if (mOwner is LocalPlayer && InstanceHelper.IsJumpingOut())
            {
                return false;
            }
			return mMachine.React((uint)EFSMEvent.DE_Stop);
		}

		public bool Stand()
		{
			if (mIsDead)
			{
				return mMachine.React((uint)EFSMEvent.DE_Death);
			}
            if (mOwner is LocalPlayer && InstanceHelper.IsJumpingOut())
            {
                return false;
            }
            else
            {
                return mMachine.React((uint)EFSMEvent.DE_Stop);
            }
        }

		public bool WalkTo(Vector3 dst)
		{		
            // 切换状态机后需要立即用到WalkMode
            // 所以不管状态机是否切换成功，都先设置WlakMode
            // 如果切换失败，再设置会原来的WalkMode
            EWalkMode oriWalkMode = mWalkMode;
            mWalkMode = EWalkMode.EWM_Dst;

            bool r;
            if(mIsWalking)
                r = mMachine.CanReact((uint)EFSMEvent.DE_ResetWalk);
            else 
                r = mMachine.CanReact((uint)EFSMEvent.DE_Walk);

            if (r)
            {
                mDst = dst;
                mDir = (mDst - mOwnerTrans.position);
                mDir.y = 0;
                mDir.Normalize();
            }
            else
                mWalkMode = oriWalkMode;

            if(mIsWalking)
                r = mMachine.React((uint)EFSMEvent.DE_ResetWalk);
            else 
                r = mMachine.React((uint)EFSMEvent.DE_Walk);
			//r = r || mbWalking;
			
			return r;
		}

		// 沿着指定方向行走
		public bool WalkAlong(Vector3 dir)
		{
            EWalkMode oriWalkMode = mWalkMode;
            mWalkMode = EWalkMode.EWM_Dir;

			bool r = mMachine.React((uint)EFSMEvent.DE_Walk);
			r = r || mIsWalking;
			if (r)
			{
				mDir = dir;
				mDir.Normalize();
			}
            else
                mWalkMode = oriWalkMode;
			return r;
		}

		public bool Relive()
		{
			bool r = mMachine.React((uint)EFSMEvent.DE_Relive);
			if (r)
			{
				mIsDead = false;
                if (mOwner != null && mOwner.IsLocalPlayer)
                    ClientEventMgr.GetInstance().FireEvent((int)ClientEvent.CE_LOCAL_PLAYER_NWAR_REVIVE, null);
            }		
			return r;
		}

		public void Update()
		{
			mMachine.Update();
		}
		
		public bool Kill()
		{
            Stop();
            return mMachine.React((uint)EFSMEvent.DE_Death);
        }

        public void Destroy()
        {
            RecycleState();

            if (mMachine != null)
            {
                mMachine.Destroy();

                ObjCachePoolMgr.Instance.RecycleCSharpObject(mMachine, ObjCachePoolType.MACHINE, mMachinePoolKey);

                mMachine = null;
            }

            mDestList.Release();
        }

        /// <summary>
        /// 后仰状态的更新逻辑
        /// </summary>
        public void BeattackBendback()
        {
            mkBackWardFunc = UpdateAnimationStage;
        }

        /// <summary>
        /// 触发交互状态
        /// </summary>
        /// <param name="aniName"></param>
        /// <returns></returns>
        public bool BeginInteraction(string aniName)
        {
            mInteractionAniName = aniName;
            return mMachine.React((uint)ActorMachine.EFSMEvent.DE_Interaction);
        }

        /// <summary>
        /// 触发跳场景状态
        /// </summary>
        /// <returns></returns>
        public bool BeginJumpScene(string ani_name)
        {
            mJumpSceneAnimation = ani_name;
            return mMachine.React((uint)ActorMachine.EFSMEvent.DE_JumpScene);
        }
    }
}
