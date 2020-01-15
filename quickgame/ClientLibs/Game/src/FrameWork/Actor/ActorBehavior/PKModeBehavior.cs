//------------------------------------------------------------------------------
// Desc: 包含PK状态的信息组件
// Date: 2017.7.13
// Author: xusong
//------------------------------------------------------------------------------
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace xc
{
    [wxb.Hotfix]
    public class PKModeBehavior : IActorBehavior
    {
        // ------------------------------------------------
        // 组件的外部接口
        // ------------------------------------------------
        public PKModeBehavior(Actor act)
        {
            mOwner = act;
            UpdatePKMode(act.BitStates);
        }

        public override void EnableBehaviors(bool enable)
        {

        }

        public override void InitBehaviors()
        {
            
        }

        public override void LateUpdate()
        {
            
        }

        public override void Update()
        {
            
        }

        // ------------------------------------------------
        // 组件的变量定义
        // ------------------------------------------------
        public uint m_pkMode = GameConst.PK_MODE_PEACE;
        public uint PkModeType
        {
            set
            {
                if (m_pkMode == value)
                    return;
                m_pkMode = value;
                if (mOwner != null && mOwner.IsLocalPlayer)
                {
                    PKModeManagerEx.Instance.UpdatePkMode(m_pkMode);
                    PKModeManagerEx.Instance.UpdatePKIcons();
                    ClientEventMgr.Instance.FireEvent((int)xc.ClientEvent.CE_CHANGE_LOCALPLAYER_PKMODE, null);
                }
            }
            get { return m_pkMode; }
        }

        // ------------------------------------------------
        // 组件的内部方法
        // ------------------------------------------------
        public void UpdatePKMode(ulong mBitStates)
        {
            if (mOwner != null && mOwner.IsLocalPlayer)    //主角不采用 mBitStates 中的PK模式数据
            {
                SetPKMode(PKModeManagerEx.Instance.PKMode);
                return;
            }
            ushort new_pk_mode;
            if ((mBitStates & GameConst.BIT_STATE_IS_FRIENDLY) == GameConst.BIT_STATE_IS_FRIENDLY)
                new_pk_mode = GameConst.PK_MODE_FRIENDLY;
            else if ((mBitStates & GameConst.BIT_STATE_IS_KILLER) == GameConst.BIT_STATE_IS_KILLER)
                new_pk_mode = GameConst.PK_MODE_KILLER;
            else if ((mBitStates & GameConst.BIT_STATE_IS_DEFEND) == GameConst.BIT_STATE_IS_DEFEND)
                new_pk_mode = GameConst.PK_MODE_DEFEND;
            else if ((mBitStates & GameConst.BIT_STATE_IS_ATTACK) == GameConst.BIT_STATE_IS_ATTACK)
                new_pk_mode = GameConst.PK_MODE_ATTACK;
            else if ((mBitStates & GameConst.BIT_STATE_IS_SERVER) == GameConst.BIT_STATE_IS_SERVER)
                new_pk_mode = GameConst.PK_MODE_SERVER;
            else
                new_pk_mode = GameConst.PK_MODE_PEACE;
            PkModeType = new_pk_mode;
            
        }

        public void SetPKMode(uint new_pk_mode)
        {
            PkModeType = new_pk_mode;
        }
    }
}
 
