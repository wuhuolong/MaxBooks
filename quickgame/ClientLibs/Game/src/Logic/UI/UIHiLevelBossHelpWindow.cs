using UnityEngine;
using System.Collections;
using System.Collections.Generic;

using xc.ui;

namespace xc
{
    namespace ui
    {
        [wxb.Hotfix]
        public class UIHiLevelBossHelpWindow : UIBaseWindow
        {
            //--------------------------------------------------------
            //  变量定义
            //--------------------------------------------------------
            UIButton mCloseButton;
            UILabel mTextLabel;
            
            //--------------------------------------------------------
            //  构造函数
            //--------------------------------------------------------
            public UIHiLevelBossHelpWindow()
            {
                mPrefabName = "UIHiLevelBossHelpWindow";
            }
                    
            //--------------------------------------------------------
            //  虚函数
            //--------------------------------------------------------
            protected override void InitUI()
            {
                base.InitUI();
                
                GameObject childObj;
                childObj = FindChild("CloseButton");
                mCloseButton = childObj.GetComponent<UIButton>();

                childObj = FindChild("TextLabel");
                mTextLabel = childObj.GetComponent<UILabel>();

                mUIObject.AddComponent<AutoSize>();
            }
            
            protected override void UnInitUI()
            {
                base.UnInitUI();
            }
            
            protected override void InitEvent()
            {
                base.InitEvent();
                
                // 注册控件消息
                EventDelegate.Add(mCloseButton.onClick, OnClickCloseButton);
                
                // 注册网络消息
                
                // 注册客户端消息
            }
            
            protected override void UnInitEvent()
            {
                base.UnInitEvent();
                
                // 取消注册客户端消息
                
                // 取消注册网络消息
                
                // 取消注册控件消息
                EventDelegate.Remove(mCloseButton.onClick, OnClickCloseButton);
            }
            
            protected override void ResetUI()
            {
                base.ResetUI();

                mTextLabel.text = DBConstText.GetText("HILV_BOSS_HELP");
            }
            
            protected override void ResetVar()
            {
                base.ResetVar();
            }
            
            protected override void HideUI()
            {
                base.HideUI();
            }
            
            //--------------------------------------------------------
            //  内部调用
            //--------------------------------------------------------
            
            
            //--------------------------------------------------------
            //  外部调用
            //--------------------------------------------------------
            
            
            //--------------------------------------------------------
            //  控件消息
            //--------------------------------------------------------
            void OnClickCloseButton()
            {
                Hide();
            }
            
            //--------------------------------------------------------
            //  客户端消息
            //--------------------------------------------------------  
            
            //--------------------------------------------------------
            //  网络消息
            //--------------------------------------------------------  
            
            
        }
        
    }
}
