using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;
using System;

namespace xc
{
	namespace ui.ugui
    {
        [wxb.Hotfix]
        public class UINoticeWindow : UIBaseWindow
		{
			/// <summary>
			/// 提示框类型
			/// </summary>
			public enum EWindowType
			{
                WT_No_Button = 0,

                SH_CloseBtn = 1,
                SH_OKBtn = 1 << 1,
                SH_CancelBtn = 1 << 2,
                SH_DisableClose = 1 << 3,
                SH_Toggle = 1 << 4,

                WT_OK = SH_OKBtn | SH_CloseBtn,
                WT_OK_Toggle = SH_OKBtn | SH_CloseBtn | SH_Toggle,
                WT_Cancel = SH_CancelBtn | SH_CloseBtn,
                WT_OK_Cancel = SH_OKBtn | SH_CancelBtn | SH_CloseBtn,
                WT_OK_Cancel_Toggle = SH_OKBtn | SH_CancelBtn | SH_CloseBtn | SH_Toggle,

                WT_OK_DisableCloseBtn = SH_OKBtn | SH_DisableClose,
                WT_Cancel_DisableCloseBtn = SH_CancelBtn | SH_DisableClose,
                WT_OK_Cancel_DisableCloseBtn = SH_OKBtn | SH_CancelBtn | SH_DisableClose,
            }
			
			public delegate void OkBtnClickedDelegate(System.Object param);
			public delegate void CancelBtnClickedDelegate(System.Object param);
            public delegate void OkBtnWithToggleClickedDelegate(bool toggleIsOn, System.Object param);

            public delegate void OnClickToggleDelegate(bool isOn);

            //--------------------------------------------------------
            //  变量定义
            //--------------------------------------------------------
            Button mOkButton;
			Button mCancelButton;
            Button mCloseButton;
            Button mMaskButton;
            Text mTitleText;
            Text mContentText;
            Image mTitleBg;
            Toggle mToggle;
            Text mToggleText;
            Text mOKCountDownText;
            Text mCancelCountDownText;

            EWindowType mNoticeWindowType;

			OkBtnClickedDelegate mOKCallback;
			System.Object mOKCallbackParam;

			CancelBtnClickedDelegate mCancelCallback;
			System.Object mCancelCallbackParam;

            OkBtnWithToggleClickedDelegate mOKWithToggleCallback;

            OnClickToggleDelegate mOnClickToggleCallback;

            string mTitleString;
            string mContengString;

            /// <summary>
            /// 自动确认计时器
            /// </summary>
            Utils.Timer mOKTimer;

            /// <summary>
            /// 自动取消计时器
            /// </summary>
            Utils.Timer mCancelTimer;

            //--------------------------------------------------------
            //  构造函数
            //--------------------------------------------------------
            public UINoticeWindow ()
			{
			}
			
			//--------------------------------------------------------
			//  虚函数
			//--------------------------------------------------------
			protected override void InitUI ()
			{
				base.InitUI ();

                mOkButton = FindChild("OKButton").GetComponent<Button>();
                mCancelButton = FindChild("CancelButton").GetComponent<Button>();
                mCloseButton = FindChild("CloseButton").GetComponent<Button>();
                mMaskButton = FindChild("mask").GetComponent<Button>();

                mTitleText = FindChild("TitleText").GetComponent<Text>();
                mTitleText.text = "";
                mContentText = FindChild("ContentText").GetComponent<Text>();
                mContentText.text = "";

                mTitleBg = FindChild("TitleBg").GetComponent<Image>();
                mTitleBg.enabled = false;

                mToggle = FindChild("Toggle").GetComponent<Toggle>();
                mToggleText = FindChild("ToggleText").GetComponent<Text>();

                mOKCountDownText = FindChild("OKCountDownText").GetComponent<Text>();
                mOKCountDownText.text = "";
                mCancelCountDownText = FindChild("CancelCountDownText").GetComponent<Text>();
                mCancelCountDownText.text = "";

                mOkButton.onClick.AddListener(OnClickOkButton);
                mCancelButton.onClick.AddListener(OnClickCancelButton);
                mCloseButton.onClick.AddListener(OnClickCloseButton);
                mMaskButton.onClick.AddListener(OnClickMaskButton);

                NoticeWindowType = mNoticeWindowType;
                mTitleText.text = mTitleString;
                mContentText.text = mContengString;

                //mToggle.onValueChanged.AddListener(OnToggleValueChange);



            }

            //private void OnToggleValueChange(bool isOn)
            //{
            //    if (mOnClickToggleCallback != null)
            //    {
            //        mOnClickToggleCallback(isOn);
            //    }
            //}

            protected override void UnInitUI ()
			{
				base.UnInitUI ();

                mOkButton.onClick.RemoveAllListeners();
                mCancelButton.onClick.RemoveAllListeners();
                mCloseButton.onClick.RemoveAllListeners();
                mMaskButton.onClick.RemoveAllListeners();

                DestroyOKTimer();
                DestroyCancelTimer();
                UIWidgetHelp.NoticeDlgAutoCancelTime = 0;
                UIWidgetHelp.NoticeDlgAutoOKTime = 0;
            }
			
			protected override void ResetUI ()
			{
				base.ResetUI ();

                if (ShowParam == null)
                {
                    return;
                }

                this.NoticeWindowType = (EWindowType)this.ShowParam[0];
                this.TitleText = (string)this.ShowParam[1];
                this.ContentText = (string)this.ShowParam[2];

                this.OKCallback = (OkBtnClickedDelegate)this.ShowParam[3];
                this.OKCallbackParam = (System.Object)this.ShowParam[4];
                this.CancelCallback = (CancelBtnClickedDelegate)this.ShowParam[5];
                this.CancelCallbackParam = (System.Object)this.ShowParam[6];
                this.OKButtonText = (string)this.ShowParam[7];
                this.CancelButtonText = (string)this.ShowParam[8];
                this.ToggleText = (string)this.ShowParam[9];
                this.ToggleIsOn = (bool)this.ShowParam[10];
                this.OKWithToggleCallback = (OkBtnWithToggleClickedDelegate)this.ShowParam[11];

                this.mOnClickToggleCallback = (OnClickToggleDelegate)this.ShowParam[12];


                mOKCountDownText.text = "";
                if (UIWidgetHelp.NoticeDlgAutoOKTime > 0)
                {
                    StartAutoOKTimer();
                    UIWidgetHelp.NoticeDlgAutoOKTime = 0;
                }

                mCancelCountDownText.text = "";
                if (UIWidgetHelp.NoticeDlgAutoCancelTime > 0)
                {
                    StartAutoCancelTimer();
                    UIWidgetHelp.NoticeDlgAutoCancelTime = 0;
                }

                mContentText.alignment = UIWidgetHelp.NoticeDlgAlignment;
                UIWidgetHelp.NoticeDlgAlignment = TextAnchor.MiddleLeft;
            }
			
			protected override void HideUI ()
			{
				base.HideUI ();

                DestroyOKTimer();
                DestroyCancelTimer();
                UIWidgetHelp.NoticeDlgAutoCancelTime = 0;
                UIWidgetHelp.NoticeDlgAutoOKTime = 0;
            }

            //--------------------------------------------------------
            //  内部调用
            //--------------------------------------------------------
            void DestroyOKTimer()
            {
                if (mOKTimer != null)
                {
                    mOKTimer.Destroy();
                    mOKTimer = null;
                }
            }

            void DestroyCancelTimer()
            {
                if (mCancelTimer != null)
                {
                    mCancelTimer.Destroy();
                    mCancelTimer = null;
                }
            }

            //--------------------------------------------------------
            //  外部调用
            //--------------------------------------------------------

            /// <summary>
            /// 提示框标题
            /// </summary>
            /// <value>The title.</value>
            public string TitleText
			{
				get
				{
					if (mTitleText)
						return mTitleText.text;
					else
						return "";
				}
				set
				{
					if (mTitleText)
					{
                        if (value.CompareTo("") == 0)
                        {
                            mTitleText.text = "";
                            mTitleBg.enabled = false;
                        }
                        else
                        {
                            mTitleText.text = value;
                            mTitleBg.enabled = true;
                        }
                    }

                    mTitleString = value;
                }
			}

			/// <summary>
			/// 提示框内容
			/// </summary>
			/// <value>The content.</value>
			public string ContentText
			{
				get
				{
					if (mContentText)
						return mContentText.text;
					else
						return "";
				}
				set
				{
					if (mContentText)
					{
                        mContentText.text = "";
                        float heightPerLine = mContentText.preferredHeight;
                        mContentText.text = value;
                    }

                    mContengString = value;
				}
			}

			public string OKButtonText
			{
				set
				{
					if (mOkButton)
					{
                        Text text = mOkButton.gameObject.transform.Find("Text").gameObject.GetComponent<Text>();
                        if (string.IsNullOrEmpty(value) == true)
                        {
                            text.text = xc.TextHelper.BtnConfirm;
                        }
                        else
                        {
                            text.text = value;
                        }
					}
				}
			}

			public string CancelButtonText
			{
				set
				{
					if (mCancelButton)
					{
                        Text text = mCancelButton.gameObject.transform.Find("Text").gameObject.GetComponent<Text>();
                        if (string.IsNullOrEmpty(value) == true)
                        {
                            text.text = xc.TextHelper.BtnCancel;
                        }
                        else
                        {
                            text.text = value;
                        }
                    }
				}
			}

            public string ToggleText
            {
                set
                {
                    if (mToggleText)
                    {
                        if (string.IsNullOrEmpty(value) == true)
                        {
                            mToggleText.text = DBConstText.GetText("NO_LONGER_SHOW_REMIND");
                        }
                        else
                        {
                            mToggleText.text = value;
                        }
                    }
                }
            }

            public bool ToggleIsOn
            {
                set
                {
                    if (mToggle)
                    {
                        mToggle.isOn = value;
                    }
                }
            }

			public EWindowType NoticeWindowType
			{
				get
				{
					return mNoticeWindowType;
				}
				set
				{
                    mNoticeWindowType = value;

                    if (mCloseButton == null || mOkButton == null || mCancelButton == null || mMaskButton == null || mToggle == null || mCloseButton.gameObject == null || mOkButton.gameObject == null || mCancelButton.gameObject == null || mMaskButton.gameObject == null || mToggle.gameObject == null)
                    {
                        return;
                    }

                    if(FlagOperate.HasFlag((int)mNoticeWindowType, (int)EWindowType.SH_CloseBtn))
                    {
                        mCloseButton.gameObject.SetActive(true);
                    }
                    else
                    {
                        mCloseButton.gameObject.SetActive(false);
                    }

                    if(FlagOperate.HasFlag((int)mNoticeWindowType, (int)EWindowType.SH_DisableClose) || mNoticeWindowType == EWindowType.WT_No_Button)
                    {
                        mCloseButton.enabled = false;
                        mMaskButton.enabled = false;
                    }
                    else
                    {
                        mCloseButton.enabled = true;
                        mMaskButton.enabled = true;
                    }

                    if (FlagOperate.HasFlag((int)mNoticeWindowType, (int)EWindowType.SH_OKBtn))
					{
                        Vector3 pos = mOkButton.gameObject.transform.localPosition;
                        if(FlagOperate.HasFlag((int)mNoticeWindowType, (int)EWindowType.SH_CancelBtn))// 有Cancel按钮的偏移位置
                        {
                            mOkButton.gameObject.transform.localPosition = new Vector3(130f, pos.y, pos.z);
                            mOkButton.gameObject.SetActive(true);
                            mCancelButton.gameObject.transform.localPosition = new Vector3(-130f, pos.y, pos.z);
                            mCancelButton.gameObject.SetActive(true);
                        }
                        else
                        {
                            mOkButton.gameObject.transform.localPosition = new Vector3(0f, pos.y, pos.z);
                            mOkButton.gameObject.SetActive(true);
                            mCancelButton.gameObject.SetActive(false);
                        }
					}
                    else if (FlagOperate.HasFlag((int)mNoticeWindowType, (int)EWindowType.SH_CancelBtn))
                    {
                        Vector3 pos = mCancelButton.gameObject.transform.localPosition;
                        mCancelButton.gameObject.transform.localPosition = new Vector3(0f, pos.y, pos.z);
                        mCancelButton.gameObject.SetActive(true);
                        mOkButton.gameObject.SetActive(false);
                    }
                    else
                    {
                        Vector3 pos = mCancelButton.gameObject.transform.localPosition;
                        mCancelButton.gameObject.transform.localPosition = new Vector3(-130f, pos.y, pos.z);
                        mOkButton.gameObject.SetActive(false);
                        mCancelButton.gameObject.SetActive(false);
                    }

                    if (FlagOperate.HasFlag((int)mNoticeWindowType, (int)EWindowType.SH_Toggle))
                    {
                        mToggle.gameObject.SetActive(true);
                    }
                    else
                    {
                        mToggle.gameObject.SetActive(false);
                    }
                }
			}

			/// <summary>
			/// 提示框回调
			/// </summary>
			/// <value>The OK callback.</value>
			public OkBtnClickedDelegate OKCallback
			{
				set
				{
					mOKCallback = value;
				}
			}

			public System.Object OKCallbackParam
			{
				set
				{
					mOKCallbackParam = value;
				}
			}

			/// <summary>
			/// Sets a value indicating whether this instance cancel callback.
			/// </summary>
			/// <value><c>true</c> if this instance cancel callback; otherwise, <c>false</c>.</value>
			public CancelBtnClickedDelegate CancelCallback
			{
				set
				{
					mCancelCallback = value;
				}
			}
			
			public System.Object CancelCallbackParam
			{
				set
				{
					mCancelCallbackParam = value;
				}
			}

            public OkBtnWithToggleClickedDelegate OKWithToggleCallback
            {
                set
                {
                    mOKWithToggleCallback = value;
                }
            }

            //--------------------------------------------------------
            //  控件消息
            //--------------------------------------------------------
            void OnClickOkButton()
			{
				Close();

                if (mToggle != null)
                    UIWidgetHelp.ToggleValue = mToggle.isOn;

                UIWidgetHelp.BlockOtherNoticeDlg = false;

                if (mOnClickToggleCallback != null)
                {
                    mOnClickToggleCallback(mToggle.isOn);
                }

                if (mOKCallback != null)
					mOKCallback(mOKCallbackParam);
                if (mOKWithToggleCallback != null && mToggle != null)
                    mOKWithToggleCallback(mToggle.isOn, mOKCallbackParam);
            }

			void OnClickCancelButton()
			{
                Close();

                if (mToggle != null)
                    UIWidgetHelp.ToggleValue = mToggle.isOn;

                UIWidgetHelp.BlockOtherNoticeDlg = false;
				if (mCancelCallback != null)
					mCancelCallback(mCancelCallbackParam);
			}

            void OnClickCloseButton()
            {
                Close();
            }

            void OnClickMaskButton()
            {
                Close();
            }

            //--------------------------------------------------------
            //  客户端消息
            //--------------------------------------------------------	
            void StartAutoOKTimer()
            {
                DestroyOKTimer();

                int time = UIWidgetHelp.NoticeDlgAutoOKTime;
                mOKCountDownText.text = string.Format("({0})", time.ToString());
                mOKTimer = new Utils.Timer(time * 1000, false, 1000,
                    (remainTime) =>
                    {
                        mOKCountDownText.text = string.Format("({0})", ((int)(remainTime / 1000f)).ToString());

                        if (remainTime <= 0f)
                        {
                            mOKTimer.Destroy();
                            mOKTimer = null;

                            mOKCountDownText.text = "";

                            OnClickOkButton();
                        }
                    });
            }

            void StartAutoCancelTimer()
            {
                DestroyCancelTimer();

                int time = UIWidgetHelp.NoticeDlgAutoCancelTime;
                mCancelCountDownText.text = string.Format("({0})", time.ToString());
                mCancelTimer = new Utils.Timer(time * 1000, false, 1000,
                    (remainTime) =>
                    {
                        mCancelCountDownText.text = string.Format("({0})", ((int)(remainTime / 1000f)).ToString());

                        if (remainTime <= 0f)
                        {
                            mCancelTimer.Destroy();
                            mCancelTimer = null;

                            mCancelCountDownText.text = "";

                            OnClickCancelButton();
                        }
                    });
            }

            //--------------------------------------------------------
            //  网络消息
            //--------------------------------------------------------	


        }
		
	}
}
