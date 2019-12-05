using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using Net;
using xc.protocol;
using xc.ui;


namespace xc
{
    namespace ui
    {
        [wxb.Hotfix]
        public class UIHaveTitleWindow : UIBaseWindow
        {
            private UIButton mCloseBtn;
            private UIButton mGotoBtn;
            private UITexture mTexture;
            uint mId = 0;
            /// <summary>
            /// 获得称号
            /// </summary>
            public UIHaveTitleWindow ()
            {
                mPrefabName = "UIHaveTitleWindow";
            }

            protected override void InitUI ()
            {
                mCloseBtn = FindChild("CloseBtn").GetComponent<UIButton>();
                mTexture = FindChild("Texture").GetComponent<UITexture>();
                mGotoBtn = FindChild("GotoBtn").GetComponent<UIButton>();
                base.InitUI ();
            }
            protected override void InitEvent ()
            {
                EventDelegate.Add(mCloseBtn.onClick, OnClickCloseBtn);
                EventDelegate.Add(mGotoBtn.onClick, OnClickGoToBtn);
                base.InitEvent ();
            }
            protected override void UnInitEvent ()
            {
                EventDelegate.Remove(mCloseBtn.onClick, OnClickCloseBtn);
                EventDelegate.Remove(mGotoBtn.onClick, OnClickGoToBtn);
                base.UnInitEvent ();
            }
            protected override void ResetUI ()
            {
                base.ResetUI ();
            }
            
            protected override void ResetVar ()
            {
                base.ResetVar ();
            }
            void OnClickCloseBtn()
            {
                Hide ();
            }

            void OnClickGoToBtn()
            {

                Hide ();
            }

            protected override void HideUI ()
            {
                base.HideUI ();
            }
            public void Show(uint id)
            {
                mId = id;
                DBTitle.SetTitleIcon(mId , mTexture);                
                base.Show();
            }
        }
    }
}


