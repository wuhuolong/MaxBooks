using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using System.IO;
using UnityEngine;
using Net;
using xc.protocol;

namespace xc
{
    /// <summary>
    /// 技能类
    /// </summary>
    public class Skill
    {
        /// <summary>
        /// 对应的技能按键是否在按下状态
        /// </summary>
        public bool IsPress = false;

        /// <summary>
        /// 技能表中的静态数据，通过clone而来，不能进行修改
        /// </summary>
        protected List<SkillAction> mSkillActionList;
        public DBSkill.SkillData SkillData;

        /// <summary>
        /// 当前技能的id
        /// </summary>
        public uint SkillID
        {
            get
            {
                return SkillData.SkillID;
            }
        }
                
        /// <summary>
        /// 技能当前的时间，在Update函数中更新
        /// </summary>
        protected float mSkillTime;

        /// <summary>
        /// 当前SkillAction的下标
        /// </summary>
        public int CurIndex
        {
            get
            {
                return mCurIndex;
            }
        }
        protected int mCurIndex;

        /// <summary>
        /// 当前SkillAction
        /// </summary>
        SkillAction m_CurAction;   

        public SkillAction CurAction
        {
            get
            {
                return m_CurAction;
            }
        }

        /// <summary>
        /// 攻速的缩放数值
        /// </summary>
        public float SpeedScale
        {
            set
            {
                mSpeedScale = Mathf.Clamp(value, 0.1f, 10.0f);
            }
            get
            {
                return mSpeedScale;
            }
        }
        float mSpeedScale = 1.0f;

        /// <summary>
        /// 技能释放者
        /// </summary>
        public Actor SrcActor
        {
            get
            {
                return mCaster;
            }
        }
        protected Actor mCaster;

        private Vector3 mAttackDir;
        public Vector3 AttackDir
        {
            get{return mAttackDir;}

            set{mAttackDir = value;}
        }

        public bool IsFreeze
        {
            get { return m_IsFreeze; }
        }
        private bool m_IsFreeze = false;
        
        public delegate void FuncUpdateSkill();
        protected FuncUpdateSkill mkUpdateFuncList;

        
        public float MovingSpeed
        {
            get
            {
                return mfMovingSpeed;
            }
           
            set
            {
                mfMovingSpeed = value;
            }
        }
        private float mfMovingSpeed;

        public void SetUpdateFuncRun(FuncUpdateSkill kUpdate)
        {
            mkUpdateFuncList = kUpdate;
            kUpdate();
        }
        
        public void RemoveUpdateFunc(FuncUpdateSkill kUpdate)
        {
            mkUpdateFuncList = null;
        }
                
        public Skill(DBSkill.SkillData kSkillData)
        {
            LoadFromData(kSkillData);
            mCurIndex = -1;
            SpeedScale = 1.0f;
        }
        
        protected void LoadFromData(DBSkill.SkillData kSkillData)
        {
            SkillData = kSkillData;
            mSkillActionList = new List<SkillAction>(kSkillData.SkillActionList.Count);
            foreach (DBSkill.SkillActionData kActionData in kSkillData.SkillActionList)
            {
                SkillAction skill_action = new SkillAction(kActionData);
                skill_action.SkillParent = this;
                mSkillActionList.Add(skill_action);
            }
        }
        
        public Skill Clone(Actor kOwner)
        {
            Skill kNewSkill = MemberwiseClone() as Skill;
            kNewSkill.mCaster = kOwner;
            kNewSkill.mSkillActionList = new List<SkillAction>(mSkillActionList.Count);
            foreach (SkillAction kAction in mSkillActionList)
            {
                kNewSkill.mSkillActionList.Add(kAction.Clone(kNewSkill));
            }
            return kNewSkill;
        }

        /// <summary>
        /// 技能开始
        /// </summary>
        public void Begin()
        {
            mCaster.SetCurSkill(this);
            mAttackDir = mCaster.ForwardDir;

            // 显隐
            if(mCaster.IsActorInvisiable)
            {
                mCaster.BuffCtrl.DelBattleStatus("invisible");
            }

            mSkillTime = 0.0f;
        }
    
        /// <summary>
        /// 开始技能中的某一Action
        /// </summary>
        public void BeginIndex(int index)
        {
            // 先中断之前的SkillAction
            if (m_CurAction != null)
                m_CurAction.Stop();

            mkUpdateFuncList = null;
            m_IsFreeze = false;
            mfMovingSpeed = 0.0f;

            mCurIndex = index;
            m_CurAction = mSkillActionList [mCurIndex];
            m_CurAction.Begin();

            //if (mCaster is LocalPlayer)
            //{
            //    GameDebug.LogError("BeginIndex: " + SkillID + ", " + mCurIndex);
            //}
        }

        /// <summary>
        /// 强制结束这个技能
        /// </summary>
        public void Interrupt()
        {
            mCaster.SetCurSkill(null);
            if (m_CurAction != null)
            {
                m_CurAction.Stop();
                m_CurAction = null;
            }

            mkUpdateFuncList = null;
            mCurIndex = -1;
        }

        /// <summary>
        /// 技能正常结束
        /// </summary>
        public void End()
        {
            Interrupt();

            mCaster.Stop();
        }

        /// <summary>
        /// 技能的更新
        /// </summary>
        public void Update()
        {       
            if (!m_IsFreeze)
            {
                float deltaTime = (Time.deltaTime * SpeedScale);
                mSkillTime += deltaTime;
            }

            if (mkUpdateFuncList != null)
                mkUpdateFuncList();
        }

        /// <summary>
        /// 当前技能是否在cd中
        /// </summary>
        /// <returns></returns>
        public bool IsInCD()
        {
            int action_idx = mCurIndex;
            if (mCurIndex == -1)
            {
                action_idx = 0;
            }
            return GetAction(action_idx).IsInCD();
        }

        /// <summary>
        /// 即将触发的技能是否在cd中
        /// </summary>
        /// <returns></returns>
        public bool IsNextActionInCD()
        {
            int action_idx = mCurIndex + 1;
            if (action_idx >= GetSkillActionCount())
                action_idx = 0;

            return GetAction(action_idx).IsInCD();
        }

        public SkillAction GetNextAction()
        {
            int action_idx = mCurIndex + 1;
            if (action_idx >= GetSkillActionCount())
                action_idx = 0;

            return GetAction(action_idx);
        }

        public CooldownCtrl.CDInstance GetCurrentCD()
        {
            int action_idx = mCurIndex;
            if (mCurIndex == -1)
            {
                action_idx = 0;
            }
            
            return GetAction(action_idx).GetCDInstance();
        }

        public int GetSkillActionCount()
        {
            return mSkillActionList.Count;
        }

        /// <summary>
        /// 获取技能的Action，同时更新Action的结束时间
        /// </summary>
        public SkillAction GetAction(int iIndex)
        {
            if (iIndex < GetSkillActionCount())
            {
                SkillAction kAction = mSkillActionList [iIndex];
                kAction.UpdateSkillEndPoint();
                return kAction;
            }
            return null;
        }
        
        public Vector2 GetAttackRange(int actionIndex)
        {           
            if (actionIndex < GetSkillActionCount())
            {
                Vector2 range = mSkillActionList [actionIndex].GetAttackRange();

                if (range.x < 0)
                {
                    range.y += range.x;
                    range.x = 0;
                }
                
                if (range.y < 0)
                    range.y = 0;
                
                return range;
            }
            return new Vector2(0.0f, Mathf.Infinity);
        }
        
        public bool IsCanCacheNext()
        {
            if (m_CurAction == null)
            {
                return false;
            }
            if (mSkillTime > m_CurAction.ActionData.CacheTime && m_CurAction.CanCacheNext())
            {
                return true;
            }

            return false;
        }

        public bool IsInSkillActionEndingStage()
        {
            if (m_CurAction == null)
            {
                return false;
            }
            if (m_CurAction.IsInSkillActionEndingStage())
            {
                return true;
            }
            return false;
        }

        /// <summary>
        /// 处于后摇阶段之前
        /// </summary>
        /// <returns></returns>
        public bool IsInBeforeSkillActionEndingStage()
        {
            if (m_CurAction == null)
            {
                return false;
            }
            if (m_CurAction.IsInBeforeSkillActionEndingStage())
            {
                return true;
            }
            return false;
        }


        public void SetCaster(Actor kActor)
        {
            mCaster = kActor;
        }

        /// <summary>
        /// 技能是否有多个SkillAction
        /// </summary>
        public bool IsMultiAction()
        {
            // 技能表中不再有普通攻击的配置，因此通过action的数量来判断
            return mSkillActionList.Count > 1;
        }

        /// <summary>
        /// 设置最接近当前技能攻击范围内的目标点的位置
        /// </summary>
        private uint m_TargetID = 0;
        public uint TargetID
        {
            get { return m_TargetID; }
            set { m_TargetID = value; }
        }
    }
}

