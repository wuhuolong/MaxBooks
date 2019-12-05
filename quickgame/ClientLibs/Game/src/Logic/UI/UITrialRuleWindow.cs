using UnityEngine;
using System.Collections;
using System.Collections.Generic;

using xc.ui;

namespace xc
{
    namespace ui
    {
        public class UITrialRuleWindow : UIBaseWindow
        {
            //--------------------------------------------------------
            //  变量定义
            //--------------------------------------------------------
            UIButton mCloseButton;
            
            //--------------------------------------------------------
            //  构造函数
            //--------------------------------------------------------
            public UITrialRuleWindow()
            {
                mPrefabName = "UITrialRuleWindow";
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
                mCloseButton.onClick.Clear();
            }
            
            protected override void ResetUI()
            {
                base.ResetUI();
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
