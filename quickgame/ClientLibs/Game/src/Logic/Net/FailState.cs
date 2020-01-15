using System;
using System.Collections.Generic;
using Utils;
using UnityEngine;
using xc.ui.ugui;

namespace xc
{
    [wxb.Hotfix]
    partial class NetReconnect
    {
        /// <summary>
        /// 重连失败后是否重启
        /// </summary>
        bool m_ForceRebot = false;

        /// <summary>
        /// FailState
        /// </summary>
        /// <param name="s"></param>
        public void EnterState_FailState(xc.Machine.State s)
        {
            GameDebug.Log("EnterState_FailState");

            if(m_WaitConnect != null)
            {
                MainGame.HeartBehavior.StopCoroutine(m_WaitConnect);
                m_WaitConnect = null;
            }

            if(m_AutoConnect && m_ForceRebot == false)
            {
                string notice = xc.TextHelper.GetConstText("CODE_TEXT_LOCALIZATION_84");
                ui.UIWidgetHelp.GetInstance().ShowNoticeDlg(UINoticeWindow.EWindowType.WT_OK_DisableCloseBtn, notice, Retry, null, "UINotice2Window");//, Relogin, null);
            }
            else
            {
                string notice = xc.TextHelper.GetConstText("CODE_TEXT_LOCALIZATION_85");
                ui.UIWidgetHelp.GetInstance().ShowNoticeDlg(UINoticeWindow.EWindowType.WT_OK_DisableCloseBtn, notice, Rebot, null, "UINotice2Window");
            }
        }

        public void UpdateState_FailState(xc.Machine.State s)
        {

        }

        /// <summary>
        /// 重新登录(经过完整的登录流程)
        /// </summary>
        /// <param name="userData"></param>
        void Rebot(System.Object user_data)
        {
            IBridge bridge = DBOSManager.getDBOSManager().getBridge();
            bridge.logout();
        }

        /// <summary>
        /// 再次重试重连
        /// </summary>
        /// <param name="user_data"></param>
        void Retry(System.Object user_data)
        {
            if (m_Machine != null)
                m_Machine.React((uint)EFSMEvent.DE_Retry, null);
        }
    }
}
