using Net;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;
using Utils;
using xc.protocol;

namespace xc
{
    [wxb.Hotfix]
    class ChangeRoleManager : xc.Singleton<ChangeRoleManager>
    {
        bool m_IsChangeRole = false;
        uint m_ConnectCount = 0;
        uint m_MaxConnectCount = 5;
        float m_UsedTime = 0;
        float m_NextTime = 0;
        uint m_IntervalTime = 5;
        uint m_MaxTime = 30;
        bool m_HasGetToken = false;
        uint m_PreUuid = 0;

        public bool IsChangeRole
        {
            get
            {
                return m_IsChangeRole;
            }
            set
            {
                m_IsChangeRole = value;
            }
        }

        public uint PreUuid
        {
            get
            {
                return m_PreUuid;
            }
            set
            {
                m_PreUuid = value;
            }
        }

        public void ChangeRole()
        {
            m_HasGetToken = false;
            Game.Instance.SubscribeNetNotify(NetMsg.MSG_ACC_ACCOUNT_TOKEN, HandleAccAccountToken);
            var acc_account_token = new C2SAccAccountToken();
            NetClient.GetBaseClient().SendData<C2SAccAccountToken>(NetMsg.MSG_ACC_ACCOUNT_TOKEN, acc_account_token);
        }

        private void HandleAccAccountToken(ushort protocol, byte[] data)
        {
            Game.Instance.UnsubscribeNetNotify(NetMsg.MSG_ACC_ACCOUNT_TOKEN, HandleAccAccountToken);
            var pack = S2CPackBase.DeserializePack<S2CAccAccountToken>(data);
            GlobalConfig.Instance.Token = pack.token;
            PreUuid = LocalPlayerManager.Instance.LocalActorAttribute.UnitId.obj_idx;
            Game.Instance.Reset();
            Connect();
        }

        private void Connect()
        {
            m_ConnectCount ++;
            m_NextTime += m_IntervalTime;
            Game.Instance.StopNetClient();
            Game.Instance.Login();
        }

        public void Update()
        {
            if (m_IsChangeRole && m_HasGetToken)
            {
                m_UsedTime += Time.deltaTime;
                if (m_UsedTime >= m_MaxTime || m_ConnectCount >= m_MaxConnectCount)
                {
                    m_IsChangeRole = false;

                    IBridge bridge = DBOSManager.getDBOSManager().getBridge();
                    bridge.logout();

                    return;
                }
                if (m_UsedTime >= m_NextTime)
                {
                    Connect();
                }
            }
        }
    }
}
