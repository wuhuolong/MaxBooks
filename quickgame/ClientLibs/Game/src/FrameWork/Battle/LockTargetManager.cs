using System;
using System.Collections.Generic;
using Utils;

namespace xc
{
    /// <summary>
    /// 技能选择目标的逻辑
    /// </summary>
    class LockTargetManager : xc.Singleton<LockTargetManager>
    {
        /// <summary>
        /// 获取当前被选中的角色
        /// </summary>
        public Actor SelectActor
        {
            get
            {
                if (m_Selected == null)
                    return null;
                else
                    return m_Selected.BindActor;
            }
        }

        ActorMono m_Selected;
        public LockTargetManager()
        {
            ClientEventMgr.Instance.SubscribeClientEvent((int)ClientEvent.CE_SELECTACTOR_CHANGE, OnSelectActorChange);
        }

        void OnSelectActorChange(CEventBaseArgs data)
        {
            if(m_Selected != null && m_Selected.BindActor.IsMonster() && !m_Selected.BindActor.IsGuardedNpc())
            {
                m_Selected.BindActor.ShowTextName(false);
            }

            var act_mono = (ActorMono)data.arg;
            if (act_mono != null)
            {
                m_Selected = act_mono;

                if(m_Selected.BindActor.IsBoss() == false)
                    m_Selected.BindActor.ShowTextName(true);
            }
        }

        public void Reset()
        {
            m_Selected = null;
        }
    }
}
