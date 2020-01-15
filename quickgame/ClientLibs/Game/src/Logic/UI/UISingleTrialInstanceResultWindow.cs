using UnityEngine;
using System.Collections;
using System.Collections.Generic;

using Net;
using xc.ui;
using xc.protocol;

namespace xc
{
    namespace ui
    {
        public class UISingleTrialInstanceResultWindow : UIBaseWindow
        {
            //--------------------------------------------------------
            //  变量定义
            //--------------------------------------------------------
            UIButton mReturnToMapButton;
            UIButton mContinueButton;
            UILabel mDescLabel;
            UIGrid mRewardItemGrid;
            UIScrollView mRewardItemScrollView;
            
            //--------------------------------------------------------
            //  构造函数
            //--------------------------------------------------------
            public UISingleTrialInstanceResultWindow()
            {
                mPrefabName = "UISingleTrialInstanceResultWindow";
            }
                    
            //--------------------------------------------------------
            //  虚函数
            //--------------------------------------------------------
            protected override void InitUI()
            {
                base.InitUI();
                
                GameObject childObj;

                childObj = FindChild("ReturnToMapButton");
                mReturnToMapButton = childObj.GetComponent<UIButton>();

                childObj = FindChild("ContinueButton");
                mContinueButton = childObj.GetComponent<UIButton>();

                childObj = FindChild("DescLabel");
                mDescLabel = childObj.GetComponent<UILabel>();

                childObj = FindChild("RewardItemGrid");
                mRewardItemGrid = childObj.GetComponent<UIGrid>();

                childObj = FindChild("RewardItemPanel");
                mRewardItemScrollView = childObj.GetComponent<UIScrollView>();

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
                EventDelegate.Add(mReturnToMapButton.onClick, OnClickReturnToMapButton);
                EventDelegate.Add(mContinueButton.onClick, OnClickContinueButton);
                
                // 注册网络消息
                
                // 注册客户端消息
            }
            
            protected override void UnInitEvent()
            {
                base.UnInitEvent();
                
                // 取消注册客户端消息
                
                // 取消注册网络消息
                
                // 取消注册控件消息
                EventDelegate.Remove(mReturnToMapButton.onClick, OnClickReturnToMapButton);
                EventDelegate.Remove(mContinueButton.onClick, OnClickContinueButton);
            }
            
            protected override void ResetUI()
            {
                base.ResetUI();

                uint killBossNum = InstanceManager.Instance.InstanceKillBossNum;
                uint bossNum = InstanceHelper.BossNum;
                mDescLabel.text = string.Format(DBConstText.GetText("SINGLE_TRIAL_INST_RESULT"), killBossNum, killBossNum + "/" + bossNum);

                // 掉落
                RemoveAllDrops();
                InstanceManager.Instance.SortDrops();
                //foreach (PkgGoodsGive pkgGoodsGive in InstanceManager.Instance.InstanceDrops.Values)
                //{
                //    if (pkgGoodsGive != null)
                //    {
                //        GameObject obj = UIWidgetHelp.GetInstance().CreateGoodsGiveItem(pkgGoodsGive);
                //        Transform trans = obj.transform;
                //        mRewardItemGrid.AddChild(trans);
                //        trans.localScale = new Vector3(80f / 95f, 80f / 95f, 1f);
                        
                //        obj.AddComponent<UIDragScrollView>();
                //    }
                //}
                mRewardItemGrid.Reposition();
                mRewardItemScrollView.ScrollToTop();
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
            void RemoveAllDrops()
            {
                List<Transform> children = mRewardItemGrid.GetChildList();
                foreach (Transform child in children)
                {
                    mRewardItemGrid.RemoveChild(child);
                    NGUITools.DestroyImmediate(child.gameObject);
                }
            }
            
            //--------------------------------------------------------
            //  外部调用
            //--------------------------------------------------------
            
            //--------------------------------------------------------
            //  控件消息
            //--------------------------------------------------------
            void OnClickReturnToMapButton()
            {
                InstanceHelper.ExitInstance();
            }

            void OnClickContinueButton()
            {
                //ActivityManager.Instance.EnterActivity(ActivityID.ACT_SINGLE_TRIAL);
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
