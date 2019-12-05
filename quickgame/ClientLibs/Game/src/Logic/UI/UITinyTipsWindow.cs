using UnityEngine;
using System.Collections;
using System.Collections.Generic;

using xc.ui;

namespace xc
{
    namespace ui
    {
        public class UITinyTipsWindow : UIBaseWindow
        {
            private UILabel mInfoLabel;
            private UIButton mMaskButton;
            private UISprite mTipsSprite;

            public UITinyTipsWindow()
            {
                mPrefabName = "UITinyTipsWindow";
            }

            protected override void InitUI()
            {
                base.InitUI();

                mMaskButton = FindChild<UIButton>("Mask");
                mInfoLabel = FindChild<UILabel>("InfoLabel");
                mTipsSprite = FindChild<UISprite>("TipsSprite");

                mUIObject.AddComponent<AutoSize>();
            }

            protected override void InitEvent()
            {
                base.InitEvent();

                EventDelegate.Add(mMaskButton.onClick, OnCloseButtonClicked);
            }

            public override void Show()
            {
                base.Show();
            }

            public void Show(string text)
            {
                mInfoLabel.text = text;
                mTipsSprite.width = 50 + mInfoLabel.width;
                mTipsSprite.height = 30 + mInfoLabel.height;

                Show();
            }

            public void Show(string text, Vector3 pos)
            {
                Show(text);

                mTipsSprite.transform.position = pos;
            }

            public override void Hide()
            {
                base.Hide();
            }

            public static void ShowTips(string text)
            {
                UITinyTipsWindow window = UIManager.Instance.GetWindowImm<UITinyTipsWindow>(true);
                window.Show(text);
            }

            public static void ShowTips(string text, Vector3 pos)
            {
                UITinyTipsWindow window = UIManager.Instance.GetWindowImm<UITinyTipsWindow>(true);
                window.Show(text, pos);
            }

            private void OnCloseButtonClicked()
            {
                UIManager.GetInstance().DestroyWindow(mPrefabName);
            }
        }
    }
}

