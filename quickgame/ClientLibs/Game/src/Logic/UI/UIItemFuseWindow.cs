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
        public class UIItemFuseWindow : UIBaseWindow
        {
            public UIItemFuseWindow()
            {
                mPrefabName = "UIItemFuseWindow";
            }
            private UIButton mCloseBtn;


            //--------------------------------------------------------
            //  虚函数
            //--------------------------------------------------------
            protected override void InitUI ()
            {
                mCloseBtn = FindChild("CloseBtn").GetComponent<UIButton>();
                base.InitUI ();
            }
            protected override void UnInitUI ()
            {
                base.UnInitUI ();
            }
            protected override void ResetUI ()
            {
                base.ResetUI ();
            }
            protected override void ResetVar()
            {

                base.ResetVar();
            }
            protected override void InitEvent ()
            {
                EventDelegate.Add(mCloseBtn.onClick ,OnClickCloseBtn);
                base.InitEvent ();
            }
            
            protected override void UnInitEvent ()
            {
				EventDelegate.Remove(mCloseBtn.onClick ,OnClickCloseBtn);
                mCloseBtn.onClick.Clear();
                base.UnInitEvent ();
            }
            //--------------------------------------------------------
            //  控件消息
            //--------------------------------------------------------
            void OnClickCloseBtn()
            {
                Hide ();
            }
           

            protected override void HideUI ()
            {
                base.HideUI ();
            }
        }
    }
}


