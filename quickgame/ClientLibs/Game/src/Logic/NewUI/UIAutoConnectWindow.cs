//-------------------------------------------
// File: UIAutoConnectWindow.cs
// Desc: 断线重连的窗口
// Author: raorui
// Date: 2018.3.5
//-------------------------------------------
using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

namespace xc
{
    namespace ui.ugui
    {
        [wxb.Hotfix]
        public class UIAutoConnectWindow : UIBaseWindow
        {
            public delegate void OkBtnClickedDelegate(System.Object param);
            public delegate void CancelBtnClickedDelegate(System.Object param);

            /// <summary>
            /// 取消断线重连的按钮
            /// </summary>
            Button mCancelButton;

            /// <summary>
            /// 显示倒计时的文本
            /// </summary>
            Text mTimeText;

            /// <summary>
            /// 倒计时的计数器
            /// </summary>
            Utils.Timer mCountDownTimer;

            /// <summary>
            /// 开始倒计时的时间
            /// </summary>
            float mStartTime;

            /// <summary>
            /// 倒计时的最大时间
            /// </summary>
            uint mTimeout = 30;

            //--------------------------------------------------------
            //  构造函数
            //--------------------------------------------------------
            public UIAutoConnectWindow()
            {
            }

            //--------------------------------------------------------
            //  虚函数
            //--------------------------------------------------------
            protected override void InitUI()
            {
                base.InitUI();
                mCancelButton = FindChild<Button>("CancelButton");
                mTimeText = FindChild<Text>("TimeText");
                mCancelButton.onClick.AddListener(OnClickCancelButton);
            }

            protected override void UnInitUI()
            {
                base.UnInitUI();

                mCancelButton.onClick.RemoveAllListeners();
            }

            protected override void ResetUI()
            {
                base.ResetUI();

                if(mCountDownTimer != null)
                {
                    mCountDownTimer.Destroy();
                }

                mTimeout = GameConstHelper.GetUint("GAME_OFFLINE_TIMEOUT");
                mTimeText.text = string.Format("{0}", mTimeout); // 初始化倒计时的显示
                mStartTime = Time.unscaledTime;
                mCountDownTimer = new Utils.Timer(mTimeout * 1000, false, 1000, OnTimeUpddate);

                Game.Instance.ManualCancelReconnect = false;
            }

            protected override void HideUI()
            {
                base.HideUI();

                if (mCountDownTimer != null)
                {
                    mCountDownTimer.Destroy();
                    mCountDownTimer = null;
                }
            }

            //--------------------------------------------------------
            //  内部调用
            //--------------------------------------------------------
            void OnTimeUpddate(float remaintime)
            {
                float time = Time.unscaledTime - mStartTime;
                mTimeText.text = string.Format("{0}", Mathf.Max(mTimeout - (int)time, 0));
            }

            //--------------------------------------------------------
            //  外部调用
            //--------------------------------------------------------

            //--------------------------------------------------------
            //  控件消息
            //--------------------------------------------------------
            void OnClickCancelButton()
            {
                Close();
                if (Const.Region != RegionType.KOREA)
                {
                    IBridge bridge = DBOSManager.getDBOSManager().getBridge();
                    bridge.logout();
                }
                else
                {
#if UNITY_ANDROID || UNITY_IOS
                    Game.Instance.ManualCancelReconnect = true;
                    Game.Instance.RebotWithoutSdkLogout();
#else
                    IBridge bridge = DBOSManager.getDBOSManager().getBridge();
                    bridge.logout();
#endif
                }
            }
        }
    }
}
