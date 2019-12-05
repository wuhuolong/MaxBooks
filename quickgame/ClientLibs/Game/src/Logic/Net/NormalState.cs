using System;
using System.Collections.Generic;
using Utils;
using UnityEngine;

namespace xc
{
    partial class NetReconnect
    {
        bool m_IsNormal = true;

        /// <summary>
        /// 是否在正常状态
        /// </summary>
        public bool IsNormalState
        {
            get
            {
                return m_IsNormal;
            }
        }

        /// <summary>
        /// NormalState
        /// </summary>
        /// <param name="s"></param>
        public void EnterState_Normal(xc.Machine.State s)
        {
            GameDebug.Log("EnterState_Normal");
            m_IsNormal = true;
        }

        public void UpdateState_Normal(xc.Machine.State s)
        {

        }

        public void ExitState_Normal(xc.Machine.State s)
        {
            m_IsNormal = false;
        }
    }
}
