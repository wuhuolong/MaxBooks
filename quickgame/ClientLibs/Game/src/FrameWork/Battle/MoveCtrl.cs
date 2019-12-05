using UnityEngine;
using UnityEngine.AI;
using System.Collections;
using System.Collections.Generic;


using xc.Maths;
using xc.ui;
using xc.protocol;
using Net;

namespace xc
{
	public class MoveCtrl : BaseCtrl
	{
        /// <summary>
        /// 保存从服务端收到的移动信息
        /// </summary>
        protected MoveStep mCurStep;

        /// <summary>
        /// 收到服务发送的移动信息时，标记为true
        /// </summary>
        protected bool mbDirty = false;
		
        /// <summary>
        /// 玩家是否有输入
        /// </summary>
		protected bool mIsNoneInput;

        /// <summary>
        /// 玩家是否有移动信息的输入，目前与mIsNoneInput的数值相反
        /// </summary>
		protected bool mbMovingInput = false;
		
		// 移动回调		
		public delegate void MoveDirCallback();
        // 移动方向改变时的回调函数
		public MoveDirCallback OnMoveDirChange = null;
        // 移动结束时的回调函数
		public MoveDirCallback OnMoveEnd = null;

        Dictionary<int, System.Action> mReachCallbacks = null;

        private float mLastSendMovePackageTime = 0;
        private bool mIsMoving = false;
        private float mSendMovePackageInterval = 1.5f;
        private Vector3 mLastSendMoveDir;

        public bool IsMoving
        {
            set {
                if (value)
                    return;//不允许设定为true
                mIsMoving = value;
            }
        }

        public enum EActorStepType
	    {
		    AT_WALK_BEGIN = 0,
		    AT_WALK_END
	    }

	    public class MoveStep
	    {
		    public EActorStepType type;// 移动开始、结束
		    public Vector3 pos = new Vector3(0,0,0);// 移动开始的位置
		    public Vector3 dir = new Vector3(0,0,0);// 移动的方向
		    public float speed;// 移动的速度
	    }
		
		public MoveCtrl(Actor owner):base(owner)
		{
		}
		
        /// <summary>
        /// 析构函数
        /// </summary>
        public override void Destroy()
        {
            base.Destroy();

            if (mEndTimer != null)
            {
                mEndTimer.Destroy();
                mEndTimer = null;
            }
        }

		public virtual void Interrupt()
		{
			mCurStep = null;
            ClientEventMgr.Instance.FireEvent((int)ClientEvent.CE_DISABLE_CLICKEFFECT, null);
        }

        /// <summary>
        /// 试图沿着某一方向进行移动
        /// </summary>
        public bool TryWalkAlong(Vector3 dir)
        {
            return TryWalkAlong(dir, false);
        }

        public bool TryWalkAlong(Vector3 dir, bool force_sendmsg)
		{
            //GameDebug.LogError("TryWalkAlong: " + dir.ToString());

            if(mOwner.DisableMoveState)
                return false;

            if (mOwner.IsInSkillActionEndingStage())    //后摇阶段，可以移动
            {
                Skill cur_skill = mOwner.GetCurSkill();
                if (cur_skill != null)
                {
                    cur_skill.End();
                }
            }

            if (mOwner.ActorMachine.IsWalking() || mOwner.FSM.CanReact((uint)ActorMachine.EFSMEvent.DE_Walk))
                mOwner.MoveSpeed = mOwner.GetWalkSpeed();

            if (mOwner.WalkAlong(dir))
			{
                ClientEventMgr.Instance.FireEvent((int)ClientEvent.CE_DISABLE_CLICKEFFECT, null);
                SendWalkBegin(dir, force_sendmsg);
				return true;
			}
			return false;
		}
		
        /// <summary>
        /// 沿着方向移动停止
        /// </summary>
		public bool TryWalkAlongStop()
		{
			if(mOwner.WalkAlongStop())
			{
				SendWalkEnd();
				return true;
			}

			return false;
		}

        int m_WalkId = 0;

        /// <summary>
        /// 试图走到目标点，但是通过方向、速度来进行同步
        /// </summary>
        public int TryWalkToAlong(Vector3 pos, System.Action reachCallback = null)
        {
            // 被定身或者在攻击的时候不能移动
            if (mOwner.DisableMoveState)
            {
                GameDebug.LogWarning("TryWalkToAlong warning, actor is in disable move state!!!");
                return 0;
            }
            if(mOwner.IsAttacking())
            {
                if (mOwner.IsInSkillActionEndingStage())    //后摇阶段，可以移动
                {
                    Skill cur_skill = mOwner.GetCurSkill();
                    if (cur_skill != null)
                    {
                        cur_skill.End();
                    }
                }
                else    //非后摇阶段，不可以移动
                {
                    GameDebug.LogWarning("TryWalkToAlong warning, actor is attacking and not ending stage!!!");
                    return 0;
                }
            }
            
            // 只有当可以行走时，才设置移动速度
            if(mOwner.ActorMachine.IsWalking() || mOwner.FSM.CanReact((uint)ActorMachine.EFSMEvent.DE_Walk))
            {
                mOwner.MoveSpeed = mOwner.GetWalkSpeed();
            }
            
            if(mOwner.WalkTo(pos))
            {
                m_WalkId++;

                mOwner.ActorMachine.OnWalkToPointChange = OnWalkingChange;
                mOwner.ActorMachine.OnReachTarget = OnWalktoTarget;

                if (reachCallback != null)
                {
                    if (mReachCallbacks == null)
                    {
                        mReachCallbacks = new Dictionary<int, System.Action>();
                        mReachCallbacks.Clear();
                    }
                    mReachCallbacks.Add(m_WalkId, reachCallback);
                }

                return m_WalkId;
            }
            return 0;
        }

        /// <summary>
        /// 当寻路的下一目标点更新时调用
        /// </summary>
        void OnWalkingChange(Vector3 dst)
        {
            if(mIsSendMsg)
            {
                Vector3 dir = dst - mOwner.Trans.position;
                dir.Normalize();
                SendWalkBegin(dir, false);
            }
        }

        /// <summary>
        /// 当寻路到达目标点
        /// </summary>
        void OnWalktoTarget(Vector3 dst)
        {
            mOwner.ActorMachine.OnWalkToPointChange = null;

            // 要先发送停止行走的协议，因为在REACH_TARGET事件触发时，有可能有技能施法的逻辑
            if (mIsSendMsg)
            {
                SendWalkEnd();
            }

            mOwner.FireActorEvent(Actor.ActorEvent.REACH_TARGET, new CEventBaseArgs(m_WalkId));

            if (mReachCallbacks != null && mReachCallbacks.ContainsKey(m_WalkId) == true)
            {
                mReachCallbacks[m_WalkId]();
                mReachCallbacks.Remove(m_WalkId);
            }

            ClientEventMgr.Instance.FireEvent((int)ClientEvent.CE_DISABLE_CLICKEFFECT, null);
        }

        /// <summary>
        /// 上一次同步给服务器的方向角
        /// </summary>
        float mLastSendAngle = -100;

        /// <summary>
        /// 方向改变超过minAngle的数值时，才发送方向角给服务端
        /// </summary>
        float minAngle = Mathf.PI*5/180.0f;

        /// <summary>
        /// 开始朝方向移动时，发送消息
        /// </summary>
        protected void SendWalkBegin(Vector3 dir, bool force_sendmsg)
	    {
            if(!mIsSendMsg)
                return;

            dir.Normalize();

            // 通过限制夹角来控制方向同步的频率
            float curAngle = Maths.Util.VectorToAngle(dir);
            if(mLastSendAngle != -100 && force_sendmsg == false)
            {
                if(Mathf.Abs(curAngle - mLastSendAngle) < minAngle)
                    return;
            }

            mLastSendAngle = curAngle;

            Vector3 pos = mOwner.Trans.position;

            C2SNwarMove c2sMove = new C2SNwarMove();
            PkgNwarMove move_data = new PkgNwarMove();
            move_data.id = mOwner.UID.obj_idx;
            //move_data.type = (uint)walk_type;
            PkgNwarPos nwarPos = new PkgNwarPos();
            nwarPos.px = (int)(pos.x * 100);
            nwarPos.py = (int)(pos.z * 100);
            move_data.pos = nwarPos;
            //move_data.dir = Mathf.Atan(dir.z / dir.x);
            move_data.dir = Maths.Util.VectorToAngle(dir);
            move_data.speed = (uint)(mOwner.MoveSpeed * 100);
            c2sMove.move = move_data;
            
            Net.NetClient.GetCrossClient().SendData<C2SNwarMove>(NetMsg.MSG_NWAR_MOVE, c2sMove);
            mIsMoving = true;
            mLastSendMovePackageTime = Time.realtimeSinceStartup;
            mLastSendMoveDir = dir;
            //GameDebug.Log("<<<MSG_NWAR_MOVE, dirx: " + dir.x + " diry: " + dir.z);
        }

        /// <summary>
        /// 朝方向移动结束时，发送消息
        /// </summary>
        public void SendWalkEnd()
	    {
            if(!mIsSendMsg || !Game.GetInstance().IsNetMode())
                return;

            if(mOwner == null)
            {
                return;
            }

            mLastSendAngle = -100;

            Vector3 pos = mOwner.Trans.position;
            Vector3 dir = mOwner.ForwardDir;

            C2SNwarMoveStop c2sMoveStop = new C2SNwarMoveStop();
            c2sMoveStop.stop = new PkgNwarMove();
            c2sMoveStop.stop.id = mOwner.UID.obj_idx;
            c2sMoveStop.stop.pos = new PkgNwarPos();
            c2sMoveStop.stop.pos.px = (int)(pos.x * 100);
            c2sMoveStop.stop.pos.py = (int)(pos.z * 100);
            c2sMoveStop.stop.dir = Maths.Util.VectorToAngle(dir);
            Net.NetClient.GetCrossClient().SendData<C2SNwarMoveStop>(NetMsg.MSG_NWAR_MOVE_STOP, c2sMoveStop);
            mIsMoving = false;
        }

        /// <summary>
        /// 发送剧情远距离跳的协议
        /// </summary>
        /// <param name="pos"></param>
        public void SendFly(Vector3 pos)
        {
            var msg = new C2SNwarFly();
            msg.stop = new PkgNwarMove();
            msg.stop.id = mOwner.UID.obj_idx;
            msg.stop.pos = new PkgNwarPos();
            msg.stop.pos.px = (int)(pos.x * 100);
            msg.stop.pos.py = (int)(pos.z * 100);
            Net.NetClient.GetCrossClient().SendData<C2SNwarFly>(NetMsg.MSG_NWAR_FLY, msg);
        }
		
        /// <summary>
        /// 移动到确定的目标点时，发送消息
        /// </summary>
        void SendMoveTo(Vector3 dst)
        {
            if(!mIsSendMsg) 
                return;

            // 已经没有移动到某个点的协议
        }

		void _walk(Vector3 dir)
		{
            if(Vector3.Angle(mOwner.MoveDir, dir) > DBActor.MinimumAngle || false == mOwner.IsWalking())
	    	{
                TryWalkAlong(dir);
	    	}
		}

        /// <summary>
        /// 改变攻击时的移动方向
        /// </summary>
		public void MoveDirInAttacking(Vector3 dir)
		{
            if(Vector3.Angle(mOwner.MoveDir, dir) > DBActor.MinimumAngle)
			{
				if(mOwner.MoveDirInAttacking(dir))
				{
                    if (dir == Vector3.zero)
					{
						if (OnMoveEnd != null)
                            OnMoveEnd();
					}
					else
					{
						if (OnMoveDirChange != null)
                            OnMoveDirChange();
					}
				}
			}
		}

        /// <summary>
        /// 获取用户输入，设置对应方向变量
        /// </summary>
		void ProcessInput()
		{	
	        float v = GameInput.GetInstance().Position.y;
	        float h = GameInput.GetInstance().Position.x;
			
			mbMovingInput = v != 0 || h != 0;

            //GameDebug.LogError("v:" + v + " h:" + h);
			
			if (mbMovingInput)
		    {
			    Vector3 dir =  Vector3.zero;

                if (Game.Instance.CameraControl != null && Game.Instance.CameraControl.Mode == CameraControl.EMode.CM_FOLLOW_FORCE_FOCUS)
                {
                    CameraControl camControl = Game.Instance.CameraControl;
                    Vector3 cameraForward = camControl.transform.forward;
                    Vector3 right = Vector3.zero;
                    Vector3 forward = Vector3.zero;

                    if(h < 0.0f)
                    {
                        right = camControl.transform.right;
                    }
                    else if(h > 0.0f)
                    {
                        right = -camControl.transform.right;
                    }

                    if(v < 0.0f)
                    {
                        forward = cameraForward;
                    }
                    else if(v > 0.0f)
                    {
                        forward = -cameraForward;
                    }

                    dir = right + forward;
                }
                else
                {
                    dir.x = -h;
                    dir.z = -v;

                    if(Game.Instance.CameraControl != null && Game.Instance.CameraControl.SelectedChildCamera != null)
                    {
                        float cameraForward = Game.Instance.CameraControl.SelectedChildCamera.eulerAngles.y;

                        var rotation = Quaternion.Euler(0, cameraForward, 0);
                        dir = rotation * dir;
                    }
                }

                dir.Normalize();
                //dir.y = 0.0f;

                // 方向的细分限制
                /*float angle = Maths.Util.VectorToAngle(dir);
                float minAngle = Mathf.PI/16.0f;
                float angleF = Mathf.RoundToInt(angle/minAngle) * minAngle;
                dir = Maths.Util.AngleToVector(angleF);*/

                _walk(dir);

			    mIsNoneInput = false;
		    }
		    else
		    {
			    mIsNoneInput = true;
		    }
			
			if (false == mbMovingInput && mOwner.WalkMode == ActorMachine.EWalkMode.EWM_Dir && (mOwner.IsWalking()))
		    {
                // 当非任务指引的时候才停止 并且也不在非跟随模式才停止
                if(TargetPathManager.Instance.IsNavigating == false)
                {
                    Actor localPlayer = Game.GetInstance().GetLocalPlayer();

                    if(localPlayer.GetAIEnable() == false)
                    {
                        TryWalkAlongStop();
                    } 
                }
		    }

            if (!mIsNoneInput)
            {
                Actor localPlayer = Game.GetInstance().GetLocalPlayer();
                if (localPlayer != null)
                {
                    ClientEventMgr.GetInstance().FireEvent((int)ClientEvent.CE_PLAYERCONTROLED, null);
                }
            }
		}
		
        //从当前位置直接走到目的位置之后再按照指定方向行走
        void UpdateWalk()
        {
            if (mIsMoving)
            {
                float now_time = Time.realtimeSinceStartup;
                if(now_time >= mLastSendMovePackageTime + mSendMovePackageInterval)
                {
                    SendWalkBegin(mLastSendMoveDir, true); 
                }
            }
            if(null == mCurStep)
                return;
            
            bool reachDst = HasReachedPos(mCurStep.pos);
            if(mbDirty || reachDst)
            {
                mbDirty = false;
                bool change = false;
                change = SpeedUpShortCut();
                
                if(change)
                    reachDst = HasReachedPos(mCurStep.pos);
                
                if(reachDst)
                {
                    if(mCurStep.type == EActorStepType.AT_WALK_BEGIN)
                    {
                        mOwner.Stand();
                        mOwner.WalkAlong(mCurStep.dir);

                        mCurStep = null;
                    }
                    else if(mCurStep.type == EActorStepType.AT_WALK_END)
                    {
                        mOwner.SetPosition(mCurStep.pos);
                        mOwner.TurnDir(mCurStep.dir);
                        mOwner.Stand();
                        mCurStep = null;
                    }
                }
                else
                {
                    // FIXME 先暂时瞬移过去
                    mOwner.Stand();
                    mOwner.SetPosition(mCurStep.pos);

                    /*mOwner.Stand();
                    if(EMoveType.MT_WALK  == mCurStep.moveType)
                        mOwner.WalkTo(mCurStep.pos);
                    else if(EMoveType.MT_RUN == mCurStep.moveType)
                        mOwner.RunTo(mCurStep.pos);
                    else
                    {
                        if(EMoveType.MT_WALK == mBeginMoveType)
                            mOwner.WalkTo(mCurStep.pos);
                        else
                            mOwner.RunTo(mCurStep.pos);
                    }*/
                }
            }
        }

        /// <summary>
        /// 开始移动的时间
        /// </summary>
        float mMoveTime = 0;

        /// <summary>
        /// 角色开始移动
        /// </summary>
        bool mStartMove = false;

        /// <summary>
        /// 给服务器同步位置的间隔时间
        /// </summary>
        const float mSendDetalTime = 2.0f;


		float GetDistanceOfCurToDst(Vector3 dst)
		{
			Vector3 pos = mOwner.Trans.position;
		    pos.y = 0.0f;
			return Vector3.Distance(pos, dst);
		}
		
		Vector3 CalcDstPosition()
	    {
			if(null == mCurStep)
                return Vector3.zero;
			
		    Vector3 dst = mCurStep.pos;
			if(mCurStep.type == EActorStepType.AT_WALK_BEGIN && mbDirty)
			{
				Vector3 step = Vector3.ClampMagnitude(mCurStep.dir, DBActor.SpeedUpMinDis);
				dst += step;
			}
			return dst;
	    }
		
		bool HasReachedPos(Vector3 pos)
		{
            if(mOwner.Trans == null)
                return false;

			pos.y = 0.0f;
			Vector3 curPos = mOwner.Trans.position;
			curPos.y = 0.0f;
			if(Vector3.Distance(curPos, pos) <= DBActor.MinimumDistance)
				return true;
		
			return false;
		}
		
        bool SpeedUpShortCut()
	    {
            if (mCurStep == null || mOwner == null)
            {
                return false;
            }

		    Vector3 calcPos = CalcDstPosition();
			float curDis = GetDistanceOfCurToDst(calcPos);//当前位置到推算的目标点位置的距离
			//float diff = Mathf.Abs(curDis-DBActor.SpeedUpMinDis);
		    
            MoveStep step = mCurStep;
		    float speed = step.speed;
		    if(step.type == EActorStepType.AT_WALK_END)
			{
                AnimationOptions op = mOwner.GetWalkAniOptions();

                if (op != null)
				    speed = op.Speed;
			}
    		
		    bool drag = false;
    		
		    if(curDis <= DBActor.SpeedUpMinDis)
		    {
			    mOwner.MoveSpeed = speed;
		    }
		    else if(curDis > DBActor.SpeedUpMaxDis)
		    {
			    mOwner.MoveSpeed = speed;
			    mOwner.SetPosition(step.pos);
			    mOwner.TurnDir(mCurStep.dir);
			    drag = true;
		    }
		    else
		    {  	
				if(0 == speed)
				{
					GameDebug.LogError("zero speed");
                    speed = 0.5f;
				}
			    float costTime = DBActor.SpeedUpMinDis / speed;
				float s = curDis / costTime;
				if(s > 0)
					mOwner.MoveSpeed = s;
		    }
			
			if(mCurStep.type == EActorStepType.AT_WALK_BEGIN)
			{
				mCurStep.pos = calcPos;
				drag = true;
			}
    		
		    return drag;
	    }

        Utils.Timer mEndTimer;// 移动结束的Timer
        public void ReceiveWalkBegin(PkgNwarMove moves)
        {
            if (false == mIsRecvMsg)
                return;

            // 移动时的位置和方向
            Vector3 pos = Vector3.zero;
            Vector3 dir = Vector3.zero;
            pos.x = moves.pos.px * GlobalConst.UnitScale;
            pos.z = moves.pos.py * GlobalConst.UnitScale;

            // 如果速度为0,直接设置到目标点(移动时间太短的话也当作停止处理)
            if (moves.speed == 0 || (moves.time != 0 && moves.time <= 66))
            {
                pos = RoleHelp.GetPositionInScene(mOwner.ActorId, pos.x, pos.z);
                mOwner.SetPosition(pos);
                mOwner.MoveSpeed = 0;
                return;
            }

            dir.x = moves.speed * Mathf.Cos(moves.dir);
            dir.z = moves.speed * Mathf.Sin(moves.dir);

            MoveStep step = new MoveStep();
            step.type = EActorStepType.AT_WALK_BEGIN;
            step.pos = pos;
            step.dir = dir;
            step.speed = moves.speed * GlobalConst.UnitScale;

            mCurStep = step;
            mbDirty = true;

            // 如果移动时间不为0，则在规定的时间内自动停止
            if (moves.time != 0)
            {
                if (mEndTimer != null)
                {
                    mEndTimer.Destroy();
                }

                mEndTimer = new Utils.Timer((int)moves.time, false, moves.time, OnTimerFinish);
            }
        }

        /// <summary>
        /// 规定的移动时间结束
        /// </summary>
        /// <param name="remainTime"></param>
        void OnTimerFinish(float remainTime)
        {
            if(mOwner.IsWalking())
            {
                mOwner.Stand();
                mCurStep = null;
            }
        }

        public void ReceiveWalkEnd(S2CNwarMoveStop walk)
	    {
            if(false == mIsRecvMsg)
                return;
			
		    Vector3 pos = Vector3.zero;
		    Vector3 dir = Vector3.zero;
		    pos.x = walk.stop.pos.px * GlobalConst.UnitScale;
            pos.z = walk.stop.pos.py * GlobalConst.UnitScale;
            Maths.Util.AngleToVector(walk.stop.dir, ref dir);// 停止移动时，默认z轴方向为0
    		
            MoveStep step = new MoveStep();
		    step.type = EActorStepType.AT_WALK_END;
		    step.pos = pos;
		    step.dir = dir;
		    step.speed = 0.0f;

		    mCurStep = step;
		    mbDirty = true;
        }

        public void ReceiveSetPos(S2CNwarSetPos pack)
        {
            if (mOwner.MoveImplement != null)
            {
                Vector3 pos = RoleHelp.GetPositionInScene(mOwner.ActorId, pack.move.pos.px * GlobalConst.UnitScale, pack.move.pos.py * GlobalConst.UnitScale);
                bool result = false;
                pos = InstanceHelper.ClampInWalkableRange(pos, pos, out result);
                mOwner.MoveImplement.SetPosition(pos);
            }

            bool isWalking = mOwner.ActorMachine.IsWalking();
            mOwner.Stop();
            TryWalkAlongStop();

            // 如果当前正在寻路，则重新寻路，因为需要重新计算路径
            if (isWalking == true && mOwner.ActorMachine.DestList.size > 0)
            {
                int newWalkId = 0;
                if (mReachCallbacks != null && mReachCallbacks.ContainsKey(m_WalkId) == true)
                {
                    newWalkId = TryWalkToAlong(mOwner.ActorMachine.DestList[mOwner.ActorMachine.DestList.size - 1], mReachCallbacks[m_WalkId]);
                }
                else
                {
                    newWalkId = TryWalkToAlong(mOwner.ActorMachine.DestList[mOwner.ActorMachine.DestList.size - 1]);
                }

                // 如果当前正在任务寻路，则赋值给最新的walk id
                if (TargetPathManager.Instance.IsNavigating == true && TargetPathManager.Instance.PathWalker != null)
                {
                    TargetPathManager.Instance.PathWalker.WalkId = newWalkId;
                }
            }

            // 本地是否要激活自动战斗
            if (pack.move.id == LocalPlayerManager.Instance.LocalActorAttribute.UnitId.obj_idx)
            {
                if (SceneHelp.Instance.IsAutoFightingAfterSwitchInstance == true)
                {
                    SceneHelp.Instance.IsAutoFightingAfterSwitchInstance = false;
                    InstanceManager.Instance.IsAutoFighting = true;
                }
                mIsMoving = false;
            }
        }
        public override void Update()
		{
			if(GameInput.Instance.GetEnableInput() && mIsProcessInput)
            {
                ProcessInput();
            }

            // 检测自动状态下，是不是按下了方向
            if (mIsProcessInput && GameInput.Instance.GetEnableInput() == false && InstanceManager.Instance.IsAutoFighting)
            {
                float v = GameInput.GetInstance().Position.y;
                float h = GameInput.GetInstance().Position.x;

                bool state = v != 0 || h != 0;

                if(state)
                {
                    Actor localPlayer = Game.GetInstance().GetLocalPlayer();
                    if (localPlayer != null)
                    {
                        ClientEventMgr.GetInstance().FireEvent((int)ClientEvent.CE_PLAYERCONTROLED, null);
                    }
                }
            }
			
			UpdateWalk();
		}
		
		public static void RegisterAllMessage()
		{
            Game.GetInstance().SubscribeNetNotify(NetMsg.MSG_NWAR_MOVE, HandleServerData);
            Game.GetInstance().SubscribeNetNotify(NetMsg.MSG_NWAR_MOVE_STOP, HandleServerData);
            Game.GetInstance().SubscribeNetNotify(NetMsg.MSG_NWAR_SET_POS, HandleServerData);
            //Game.GetInstance().SubscribeNetNotify(NetMsg.MSG_MAP_WALK, HandleServerData);
        }
		
		public static void HandleServerData(ushort protocol, byte[] data)
		{
			// 判断行走相关的协议
			// 根据mIsRecvMsg来决定是否处理
			switch(protocol)
			{
                case NetMsg.MSG_NWAR_MOVE:
                    {
                        ReceiveWalkBegin(data);
                    }
                    break;
                case NetMsg.MSG_NWAR_MOVE_STOP:
				    {
                        ReceiveWalkEnd(data);
				    }
				    break;
                case NetMsg.MSG_NWAR_SET_POS:
                    {
                        ReceiveSetPos(data);
                    }
                    break;
            }
		}
		
		//沿着指定方向行走 开始
		public static void ReceiveWalkBegin(byte[] data)
		{
            S2CNwarMove playerWalk = S2CPackBase.DeserializePack<S2CNwarMove>(data);

            if(playerWalk.move.id.Equals(Game.GetInstance().LocalPlayerID.obj_idx))
				return;

            Actor actor = ActorManager.Instance.GetPlayer(playerWalk.move.id);
			if(null == actor)
                return;
			
			MoveCtrl ctrl = actor.MoveCtrl;
			if(null != ctrl)
                ctrl.ReceiveWalkBegin(playerWalk.move);
		}
		
		//沿着指定方向行走 结束
		public static void ReceiveWalkEnd(byte[] data)
		{
            S2CNwarMoveStop playerWalkStop = S2CPackBase.DeserializePack<S2CNwarMoveStop>(data);

            if(playerWalkStop.stop.id.Equals(Game.GetInstance().LocalPlayerID.obj_idx))
				return;

            Actor actor = ActorManager.Instance.GetPlayer(playerWalkStop.stop.id);
			if(null == actor)
                return;
			
			MoveCtrl ctrl = actor.MoveCtrl;
			if(null != ctrl)
                ctrl.ReceiveWalkEnd(playerWalkStop);
		}

        // 强制位置同步
        public static void ReceiveSetPos(byte[] data)
        {
            S2CNwarSetPos pack = S2CPackBase.DeserializePack<S2CNwarSetPos>(data);

            Actor actor = ActorManager.Instance.GetPlayer(pack.move.id);
            if (null == actor)
                return;

            MoveCtrl ctrl = actor.MoveCtrl;
            if (null != ctrl)
                ctrl.ReceiveSetPos(pack);
        }

        /*protected void SpeedUpTo(Vector3 realPos, Vector3 dstPos, short speed)
        {
            Vector3 curPos = mOwner.Trans.position;
            curPos.y = 0.0f;
            
            float curDisToDst = Vector3.Distance(curPos, dstPos);       //当前位置距离目标位置的距离
            float realDisToDst = Vector3.Distance(realPos, dstPos);     //真实位置距离目标位置的距离
            float disDiff = curDisToDst - realDisToDst;                 //两距离的差值，可能会出现负数
            
            AnimationOptions op = mOwner.GetMoveToOptions();
            
            mOwner.MoveSpeed = speed / 100.0f;
            
            if(disDiff < DBActor.SpeedUpMinDis)             //不加速
            {
                mOwner.MoveSpeed = speed / 100.0f;
            }
            else if(disDiff > DBActor.SpeedUpMaxDis)        //瞬间转移到目标位置
            {
                mOwner.SetActorPositionXZ(realPos);
            }
            else                                    //加速
            {
                if(realDisToDst < DBActor.SpeedUpMinDis)
                    realDisToDst = DBActor.SpeedUpMinDis;
                float costTime = realDisToDst / speed * 100.0f;
                mOwner.MoveSpeed = curDisToDst / costTime;
            }
        }*/
    }
}

