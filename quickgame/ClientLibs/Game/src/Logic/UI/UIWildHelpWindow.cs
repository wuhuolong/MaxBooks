using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace xc.ui
{
    public class UIWildHelpWindow : UIBaseWindow
    {
        public UIWildHelpWindow()
        {
            mPrefabName = "UIWildHelpWindow";
        }

        protected override void InitUI()
        {
            base.InitUI();

            mUIObject.AddComponent<AutoSize>();
        }

        protected override void InitEvent()
        {
            base.InitEvent();

            EventDelegate.Add(FindChild<UIButton>("CloseBtn").onClick, OnCloseBtnClicked);
        }

        protected override void UnInitEvent()
        {
            base.UnInitEvent();

            EventDelegate.Remove(FindChild<UIButton>("CloseBtn").onClick, OnCloseBtnClicked);
        }

        private void OnCloseBtnClicked()
        {
            UIManager.Instance.DestroyWindow(mPrefabName);
        }
    }
}
