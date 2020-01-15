using System;
using UnityEngine;

namespace xc
{
    public enum EVisibleMode
    {
        Visible = 1,// 显示
        Name, //显示名字和阴影
        Invisible,// 不显示
    }

    /// <summary>
    /// 控制是否显示的优先级
    /// </summary>
    public enum VisiblePriority
    {
        NORMAL = 0,// 创建角色后的控制
        SKILL,// 技能控制
        BUFF_STATE, // buff状态控制
        CULL, //cullmanager控制
        EXCEPT, //例外的控制
        MAX
    }

    [wxb.Hotfix]
    public class VisibleCtrl: BaseCtrl
    {
        public VisibleCtrl(Actor mOwner) :base(mOwner)
        {
        }

        VisiblePriority m_VisiblePriority = VisiblePriority.NORMAL;
        int m_VisiblePriorityBits;// 显示优先级的状态位

        private bool mHasShow = false;
        private float visibleTime = float.MaxValue;
        protected EVisibleMode mVisibleMode = EVisibleMode.Invisible;

        public EVisibleMode VisibleMode
        {
            get { return mVisibleMode; }
        }

        /// <summary>
        /// 当前是否处在模型可见状态下
        /// </summary>
        public bool IsVisible
        {
            get
            {
                return mVisibleMode == EVisibleMode.Visible;
            }
        }

        /// <summary>
        /// 上一次被添加到同屏可视列表的时间
        /// </summary>
        public float VisibleTime
        {
            get{ return visibleTime;}
            set{ visibleTime = value;}
        }

        public bool HasShow { get { return mHasShow; } }

        //you should never call this function except the cullmanager
        public void SetActorVisible(bool bVisible, VisiblePriority priority)
        {
            SetActorVisible(bVisible, false, false, priority);
        }

        public void RecoverPriority()
        {
            m_VisiblePriorityBits = 0;
        }

        /// <summary>
        /// 设置角色是否可见
        /// </summary>
        /// <param name="visible">If set to <c>true</c> b visible.</param>
        /// <param name="ignoreEffect">If set to <c>true</c> ignore effect.</param>
        public void SetActorVisible(bool visible, bool ignore_effect, bool force_show_headinfo, VisiblePriority priority)
        {
            if(visible)
            {
                m_VisiblePriorityBits = FlagOperate.RemoveFlag(m_VisiblePriorityBits, (int)(1 << (int)priority));

                for (int i = (int)priority + 1; i < (int)VisiblePriority.MAX; ++i)
                {
                    if (FlagOperate.HasFlag(m_VisiblePriorityBits, 1 << i))
                        return;
                }
            }
            else
            {
                m_VisiblePriorityBits = FlagOperate.AddFlag(m_VisiblePriorityBits, (int)(1 << (int)priority));
            }

            if (visible)
            {
                if (mVisibleMode == EVisibleMode.Visible)
                {
                    return;
                }
                mVisibleMode = EVisibleMode.Visible;
                mHasShow = true;
                mOwner.mAvatarCtrl.SetVisible(true);
            }
            else
            {
                if (mVisibleMode == EVisibleMode.Invisible)
                {
                    return;
                }
                mVisibleMode = EVisibleMode.Invisible;
                mOwner.mAvatarCtrl.SetVisible(false);
            }

            if(force_show_headinfo)
            {
                if (InstanceManager.Instance.InstanceInfo != null && InstanceManager.Instance.InstanceInfo.mWarSubType == GameConst.WAR_SUBTYPE_BATTLE_FIELD)
                {
                    mOwner.ShowTextBehaviors(false);
                }
                else
                {
                    mOwner.ShowTextBehaviors(true);
                }
            }
            else
            {
                if (InstanceManager.Instance.InstanceInfo != null && InstanceManager.Instance.InstanceInfo.mWarSubType == GameConst.WAR_SUBTYPE_BATTLE_FIELD)
                {
                    mOwner.ShowTextBehaviors(false);
                }
                else
                {
                    mOwner.ShowTextBehaviors(visible);
                }
            }

            mOwner.GetBehavior<ShadowBehavior>().OnVisibleChange(mVisibleMode);

            if (mOwner.SkillEffectPlayer != null && ignore_effect == false)
            {
                mOwner.SkillEffectPlayer.ClearEffects();
                mOwner.SkillEffectPlayer.IsEnable = visible;
            }

            if(mOwner.StateEffectPlayer != null && ignore_effect == false)
            {
                mOwner.StateEffectPlayer.ClearEffects();
                mOwner.StateEffectPlayer.IsEnable = visible;
            }

            mOwner.OnBecomeVisible(visible);  
        }

        //you should never call this function except the cullmanager
        public virtual void SetActorNameVisible()
        {
            if (mVisibleMode == EVisibleMode.Name)
                return;

            mVisibleMode = EVisibleMode.Name;
            mOwner.mAvatarCtrl.SetVisible(false);
            mOwner.SetNameText();
            if (InstanceManager.Instance.InstanceInfo != null && InstanceManager.Instance.InstanceInfo.mWarSubType == GameConst.WAR_SUBTYPE_BATTLE_FIELD)
            {
                mOwner.ShowTextBehaviors(false);
            }
            else
            {
                mOwner.ShowTextBehaviors(true);
            }

            mOwner.GetBehavior<ShadowBehavior>().OnVisibleChange(mVisibleMode);

            if (mOwner.SkillEffectPlayer != null)
            {
                mOwner.SkillEffectPlayer.ClearEffects();
                mOwner.SkillEffectPlayer.IsEnable = false;
            }

            if (mOwner.StateEffectPlayer != null)
            {
                mOwner.StateEffectPlayer.ClearEffects();
                mOwner.StateEffectPlayer.IsEnable = false;
            }

            mOwner.OnBecomeNameVisible();
        }
    }
}

