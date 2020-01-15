using UnityEngine;
using System.Collections;
using System.Collections.Generic;

namespace xc
{
    /// <summary>
    /// buff对应的特殊战斗状态
    /// </summary>
    public enum BattleStatusType
    {
        BATTLE_STATUS_TYPE_INVALID           = 0,
        BATTLE_STATUS_TYPE_DIZZY             = 1,        //【昏迷】无法进行任何操作(目标单位被完全控制)
        BATTLE_STATUS_TYPE_BLIND             = 1 << 1,   //【沉默】无法主动使用技能(作用单位无法使用技能)
        BATTLE_STATUS_TYPE_SLEEP             = 1 << 2,   //【睡眠】受伤可解除的昏迷
        BATTLE_STATUS_TYPE_INVISIBLE         = 1 << 3,   // 隐身(超过隐身时间或主动攻击会移除隐身BUFF) 【隐身】前端隐身，受伤会正常损失生命，攻击方对隐身的受击方的受伤表现不可知
        BATTLE_STATUS_TYPE_CHAOS             = 1 << 4,   //【混乱】阵营置为全局敌对；自由AI暂时代替操作 

        BATTLE_STATUS_TYPE_FREEZE            = 1 << 5,   // 冰冻(目标单位被完全控制,同时角色的动作被定住)
        BATTLE_STATUS_TYPE_HOLD              = 1 << 6,   // 定身 (目标单位无法移动，但是可以释放技能)
        BATTLE_STATUS_TYPE_SUPER             = 1 << 7,   // 无敌
        BATTLE_STATUS_TYPE_NOSTRIKE          = 1 << 8,   // 不可选中和受击 nostrike
        BATTLE_STATUS_TYPE_BLIND2            = 1 << 9,   //【沉默】无法主动使用技能(作用单位无法使用技能)(可以使用普攻技能)
        BATTLE_STATUS_TYPE_END,

        // 不可移动（冰冻、晕眩、定身）
        BATTLE_STATUS_TYPE_SMoveDisable     = BATTLE_STATUS_TYPE_DIZZY | BATTLE_STATUS_TYPE_SLEEP | BATTLE_STATUS_TYPE_FREEZE | BATTLE_STATUS_TYPE_HOLD,
        // 不可放技能的基础状态（冰冻、晕眩、致盲）
        BATTLE_STATUS_TYPE_SAttakcDisableBase = BATTLE_STATUS_TYPE_DIZZY | BATTLE_STATUS_TYPE_SLEEP | BATTLE_STATUS_TYPE_FREEZE,
        // 受击无动作和位移（冰冻、晕眩、霸体）
        BATTLE_STATUS_TYPE_SBeattackMotionDisable =  BATTLE_STATUS_TYPE_DIZZY | BATTLE_STATUS_TYPE_FREEZE,
        // 不会受击（无敌、隐身、灵魂）
        BATTLE_STATUS_TYPE_SBeattackDisable = BATTLE_STATUS_TYPE_INVISIBLE,
        // 透明特效（灵魂、隐身）
        BATTLE_STATUS_TYPE_STransparenceEffects = BATTLE_STATUS_TYPE_INVISIBLE,
    }

    [wxb.Hotfix]
	public class Buff
	{    
        public static uint BattleStateCount = 10;
        private byte m_OverlayNum = 1; //当前Buff已经叠加的数量

        public uint m_BuffId;

        /// <summary>
        /// 是否不产生变身效果(有多个变身buff的时候使用)
        /// </summary>
        public bool ShiftExcept = false;

		public enum BuffFlags
        {
            AF_NONE							= 0x0000,
            // 作用于释放者
            AF_USE_TO_CASTER				= 0x0008,
            // 作用于目标
            AF_USE_TO_TARGET				= 0x0010,
            // 施法者死亡时，需要回收
            //AF_RECOVERY_AFTER_CASTER_DIE	= 0x0020,
			// 起效果后需要立即删除，表示即时buff(做完伤害计算后就要删除)
			AF_MUST_CLEAN_AFTER_USE			= 0x0040,
			// 死亡后需要回收
			AF_RECOVERY_AFTER_DIE			= 0x0100,
        }

        /// <summary>
        /// 根据字符串来获取对应的效果枚举类型
        /// </summary>
		public static BattleStatusType GetBattleState(string type_str)
		{
            DBBattleState.StateInfo info = DBBattleState.GetInstance().GetBattleStateInfo(type_str);
            if(info != null)
                return (BattleStatusType)(1 << info.value);
            else
                return BattleStatusType.BATTLE_STATUS_TYPE_INVALID;
		}

        /// <summary>
        /// buff的信息，除了包含表格中的数据外，还有buff增加、更新和删除的委托函数
        /// </summary>
		public class BuffInfo : DBBuffSev.DBBuffInfo
		{		
			public delegate void FunctionHandle(Buff buff, BuffInfo buff_info);
			public FunctionHandle mAddHandle = null;
			public FunctionHandle mFinishedHandle 	= null;
			public FunctionHandle mPeriodHandle	= null;
		}

		private BuffCtrl mkOwner;

		private System.WeakReference m_TargetActor;

        /// <summary>
        /// buff生效的目标
        /// </summary>
		public Actor Target_P
		{
            get
            {
                if (m_TargetActor != null && m_TargetActor.IsAlive)
                {
                    Actor actor = (Actor)(m_TargetActor.Target);
                    return actor;
                }

                return null;
            }
        }

        /// <summary>
        /// buff当前的更新时间
        /// </summary>
        private float m_CurTime
        {
            get
            {
                var time = Time.realtimeSinceStartup - mStartEngineTime;
                return time;
            }
        }

        /// <summary>
        /// 当前Engine的Time时间
        /// </summary>
        private float mStartEngineTime;

        /// <summary>
        /// buff当前的周期更新的时间，到达周期时间后，时间会重置
        /// </summary>
		private float m_CycleTime;

        /// <summary>
        /// buff更新的结束时间，正常情况下，该时间不会变化
        /// </summary>
		private float m_FinishTime;
		
        /// <summary>
        /// 当前buff更新时间的进度
        /// </summary>
        public float Progress
        {
            get
            {
                if(m_FinishTime == 0)
                    return 0;
                else
                    return m_CurTime / m_FinishTime;
            }
        }

        /// <summary>
        /// 获取buff的剩余时间
        /// </summary>
        public float RemainTime
        {
            get
            {
                if (m_FinishTime == 0)
                    return 0;
                else
                    return  Mathf.Max(m_FinishTime - m_CurTime, 0);
            }
        }

		private BuffInfo m_BuffInfo;
        /// <summary>
        /// 当前buff的数据
        /// </summary>
		public BuffInfo OwnBuffInfo
        {
			get
			{
				return m_BuffInfo;
			}
		}
		
        /// <summary>
        /// buff开始生效
        /// </summary>
	    bool m_Effective;
        public bool HasActive
        {
            get{
                return m_Effective;
            }
        }
		
		private bool mbNeedDel;
		public bool NeedDel
		{
			get
			{
				return mbNeedDel;
			}
		}
		
		public delegate void UpdateFunc();
		UpdateFunc m_UpdateFunc = null;// buff的更新函数，经历AddUpdate->UpdateCycle&UpdateEnd的过程
		
        public static Buff Construct(BuffCtrl buff_ctrl, BuffInfo kInfo, float lifeTime, uint layer, bool shiftExcept)
		{
            Buff buff = new Buff(buff_ctrl, kInfo, lifeTime, layer, shiftExcept);
			return buff;
		}
		
        protected Buff(BuffCtrl buff_ctrl, BuffInfo buff_info, float lifeTime, uint layer, bool shiftExcept)
		{
			mkOwner = buff_ctrl;
            m_TargetActor = new System.WeakReference(buff_ctrl.Owner);

            m_BuffId = buff_info.buff_id;
            ShiftExcept = shiftExcept;
            Reset(buff_info, lifeTime, layer);
		}
		
        /// <summary>
        /// BuffCtrl调用的更新接口
        /// </summary>
		public void Update()
		{
			if (m_UpdateFunc != null)
			{
                m_UpdateFunc();
			}
		}
		
        /// <summary>
        /// buff刚创建的时候调用的更新，直到buff的延迟时间
        /// </summary>
		void UpdateAddEffect()
		{
            if(m_CurTime >= m_BuffInfo.delay_time)
            {
    			AddEffect();
                m_UpdateFunc -= UpdateAddEffect;
    			UpdateCycle();
                m_UpdateFunc += UpdateCycle;
    			if (m_BuffInfo.life_time != 0.0f)
    			{
    				UpdateEnd();
                    m_UpdateFunc += UpdateEnd;
    			}
            }
		}
		
        /// <summary>
        /// buff激活后，进行周期性的更新
        /// </summary>
		void UpdateCycle()
		{
            m_CycleTime += Time.deltaTime;
			if (m_CycleTime >= m_BuffInfo.period_time)
			{
				DoPeriodEffect();
                m_CycleTime -= m_BuffInfo.period_time;				
			}
		}
		
        /// <summary>
        /// buff激活后，检测buff时间到后删除buff
        /// </summary>
		void UpdateEnd()
		{
			if (m_CurTime >= m_FinishTime)
			{
                Delete();
                m_UpdateFunc = null;
			}
		}
		
		/// <summary>
        /// 创建和叠加buff的时候调用
        /// </summary>
        public void Reset(BuffInfo buff_info, float lifeTime, uint layer)
		{
            // 先清除原有buff效果
            if(m_BuffInfo != null)
                Delete();

            // 重置已叠加数量
            m_OverlayNum = (byte)layer;

            // 设置新的buff变量
			m_BuffInfo = buff_info;

            // 重置时间等变量
            mStartEngineTime = Time.realtimeSinceStartup;
            m_CycleTime = 0.0f;
            if(lifeTime != 0.0f)
                m_FinishTime = lifeTime;
            else
                m_FinishTime = m_BuffInfo.life_time == 0.0f ? Mathf.Infinity : m_BuffInfo.life_time;

            mbNeedDel = false;
            m_Effective = false;

            // 重新执行buff添加效果
            m_UpdateFunc = UpdateAddEffect;
            UpdateAddEffect();
		}	

        /// <summary>
        /// 重置buff的计时
        /// </summary>
        public void ResetTime(float lifeTime, uint layer)
        {
            mStartEngineTime = Time.realtimeSinceStartup;
            m_CycleTime = 0.0f;
            if(lifeTime != 0.0f)
                m_FinishTime = lifeTime;

            // 重置已叠加数量
            m_OverlayNum = (byte)layer;
        }

        /// <summary>
        /// buff延时时间到后开始生效
        /// </summary>
		void AddEffect()
		{		
            // 调用委托函数，设置buff开始效果
			if (m_BuffInfo.mAddHandle != null)
			{
				m_BuffInfo.mAddHandle(this, m_BuffInfo);
			}

            if(m_Effective == false)
            {
                // 增加特效文件
                Target_P.BuffCtrl.AddEffectObj(m_BuffInfo);
                // 飘字
                Target_P.BuffCtrl.AddBuffWord(m_BuffInfo);
                // 设置buff生效的变量为true
                m_Effective = true;
            }
		}
		
        /// <summary>
        /// buff周期性更新
        /// </summary>
		void DoPeriodEffect()
		{
            // buff需要删除或则还没生效时不更新
			if (mbNeedDel || !m_Effective)
				return;
			
            // 调用对应的委托函数
			if (m_BuffInfo.mPeriodHandle != null)
			{
				m_BuffInfo.mPeriodHandle(this, m_BuffInfo);
			}
		}
		
        /// <summary>
        /// 清除buff效果
        /// </summary>
		public void Delete()
		{
			if (!mbNeedDel)
			{
				CleanEffect();		
				mbNeedDel = true;
			}
		}
		
        /// <summary>
        /// 清除buff效果
        /// </summary>
		bool CleanEffect()
		{
            // 如果buff已经生效了，则调用结束对应的委托函数
			if (m_Effective)
			{
				if (m_BuffInfo.mFinishedHandle != null)
				{
					m_BuffInfo.mFinishedHandle(this, m_BuffInfo);
				}
			}
            // 清除特效
            Target_P.BuffCtrl.DestroyEffectObj(m_BuffInfo.buff_id);	
			
			return m_Effective;
		}

        /// <summary>
        /// 设置buff的叠加数量
        /// </summary>
        /// <param name="num"></param>
        public void SetOverlayNum(uint num)
        {
            m_OverlayNum = (byte)num;
        }

        /// <summary>
        /// 获取buff的叠加数量
        /// </summary>
        /// <param name="num"></param>
        public uint GetOverlayNum()
        {
            return (uint)m_OverlayNum;
        }
    }	
}


