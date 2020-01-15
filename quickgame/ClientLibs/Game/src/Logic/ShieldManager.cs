//-------------------------------------------
// File ： ShieldManager.cs
// Desc ： 外显等屏蔽规则的管理类
// Author : Raorui 
// Date : 2017.11.30
//-------------------------------------------
using System;
using System.Collections;
using System.Collections.Generic;
using Utils;

namespace xc
{
    [wxb.Hotfix]
    public class ShieldManager : xc.Singleton<ShieldManager>
    {
        bool m_NormalMonsterVisible = true;
        bool m_SummonMonsterVisible = true;

        /// <summary>
        /// 普通怪物是否可见
        /// </summary>
        public bool NomralMonsterVisible
        {
            get
            {
                return m_NormalMonsterVisible;
            }

            set
            {
                m_NormalMonsterVisible = value;
                GlobalSettings.Instance.NormalMonsterVisible = value;
                CullManager.Instance.SetMonsterVisible(m_NormalMonsterVisible, false);
            }
        }

        /// <summary>
        /// 召唤怪物是否可见
        /// </summary>
        public bool SummonMonsterVisible
        {
            get
            {
                return m_SummonMonsterVisible;
            }

            set
            {
                m_SummonMonsterVisible = value;
                GlobalSettings.Instance.SummonMonsterVisible = value;
                CullManager.Instance.SetMonsterVisible(m_SummonMonsterVisible, true);
            }
        }

        /// <summary>
        /// 是否要隐藏子弹的特效
        /// </summary>
        /// <param name="src_actor"></param>
        /// <param name="target_actor"></param>
        /// <returns></returns>
        public bool IsHideBulletEffect(Actor src_actor, Actor target_actor)
        {
            return false;
            if (src_actor == null || target_actor == null)
                return true;

            bool is_hide_effect = false;

            // 判断攻击者
            if (src_actor.mVisibleCtrl.IsVisible == false)
                is_hide_effect = true;
            else
            {
                // 其他玩家和其他玩家的召唤物都不显示特效
                if (src_actor.IsPlayer())
                {
                    if (!src_actor.IsLocalPlayer)
                        is_hide_effect = true;
                }
                else
                {
                    var parent_actor = src_actor.ParentActor;
                    if (parent_actor != null && parent_actor.IsPlayer() && !parent_actor.IsLocalPlayer)
                        is_hide_effect = true;
                }
            }

            // 判断受击者
            is_hide_effect = target_actor.mVisibleCtrl.IsVisible == false || is_hide_effect;

            return is_hide_effect;
        }

        /// <summary>
        /// 是否需要隐藏buff的特效
        /// </summary>
        /// <param name="actor"></param>
        /// <returns></returns>
        public bool IsHideBuffEffect(Actor actor)
        {
            if (actor == null)
                return true;

            bool is_hide = false;

            // 其他玩家和其他玩家的召唤物都不显示特效
            if (actor.IsPlayer())
            {
                if (!actor.IsLocalPlayer)
                    is_hide = true;
            }
            else
            {
                var parent_actor = actor.ParentActor;
                if (parent_actor != null && parent_actor.IsPlayer() && !parent_actor.IsLocalPlayer)
                    is_hide = true;
            }

            return is_hide;
        }
        
        /// <summary>
        /// 是否隐藏受击特效
        /// </summary>
        /// <param name="src_actor"></param>
        /// <param name="target_actor"></param>
        public bool IsHideBeattackEffect(Actor src_actor, Actor target_actor)
        {
            if (src_actor == null || target_actor == null)
                return true;

            if (src_actor.IsLocalPlayer || target_actor.IsLocalPlayer)
                return false;
            else
                return true;
        }

        public void Reset()
        {
            m_NormalMonsterVisible = GlobalSettings.Instance.NormalMonsterVisible;
            m_SummonMonsterVisible = GlobalSettings.Instance.SummonMonsterVisible;
        }
    }
}
