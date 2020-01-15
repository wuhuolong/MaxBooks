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
        public class UILevelUpWindow : UIBaseWindow
        {
            /// <summary>
            /// 升级弹出界面
            /// </summary>
            public UILevelUpWindow ()
            {
                mPrefabName = "UILevelUpWindow";
            }
            private List<GameObject> mFrame = new List<GameObject>();
            private List<UILabel> mNewLabel  = new List<UILabel>();
            private List<UILabel> mOldLabel = new List<UILabel>();
            private UILabel mAdd;
            private int mShowCount = 4;
            private UISprite mUnlockImg;
            private UIButton mCloseBtn;
            private UISprite mTypeimg;
            private bool isFinish = false;
            private UIRollNumWidget mRollWidget;
            void ShowBarWithDelay(GameObject gameObject, float delay)
            {
                gameObject.GetComponent<UISprite>().fillAmount = 0f;
                UISprite sprite;
                UISprite arrow;
                if(gameObject.transform.FindChild("Sprite") != null)
                {
                    sprite = gameObject.transform.FindChild("Sprite").GetComponent<UISprite>();
                    TweenSpriteFill.Begin(sprite.gameObject, delay, 0, 1);
                }
                if(gameObject.transform.FindChild("Arrrow") != null)
                {
                    arrow = gameObject.transform.FindChild("Arrrow").GetComponent<UISprite>();
                    TweenSpriteFill.Begin(arrow.gameObject, delay, 0, 1);
                }
                TweenSpriteFill.Begin(gameObject, delay, 0, 1);
            }
            void ShowTextAlphaAndScale(GameObject gameObject, float delay)
            {
                gameObject.GetComponent<UILabel>().alpha = 0f;
                gameObject.transform.localScale = new Vector3(3, 3, 3);
                if(mShowCount == 5)
                {
                    mTypeimg.gameObject.transform.localScale = new Vector3(3, 3, 3);
                    TweenAlpha.Begin(mTypeimg.gameObject, delay, 1);
                    TweenScale.Begin(mTypeimg.gameObject, delay, Vector3.one);
                }
                TweenAlpha.Begin(gameObject, delay, 1);
                TweenScale.Begin(gameObject, delay, Vector3.one);
            }
            protected override void InitUI ()
            {
                for (int i = 1 ; i <= 5 ; i++)
                {
                    string str = "frame"+i;
                    mFrame.Add(FindChild(str));
                }
                mTypeimg = FindChild("localImg").GetComponent<UISprite>();
                for (int i = 1; i <= 4 ; i++)
                {
                    string str = "new"+i;
                    string str1 = "old"+i;
                    mNewLabel.Add(FindChild(str).GetComponent<UILabel>());
                    mOldLabel.Add(FindChild(str1).GetComponent<UILabel>());
                }
                mRollWidget = FindChild("RollNum").GetComponent<UIRollNumWidget>();
                mAdd = FindChild("add").GetComponent<UILabel>();
                mCloseBtn = FindChild("CloseBtn").GetComponent<UIButton>();
                mUnlockImg = FindChild("localImg").GetComponent<UISprite>();
                mFrame[0].transform.localPosition = new Vector3(0 ,90 ,0);
                base.InitUI ();
            }
            protected override void InitEvent ()
            {
                EventDelegate.Add(mCloseBtn.onClick, OnClickCloseBtn);
                base.InitEvent ();
            }
            protected override void UnInitEvent ()
            {
                EventDelegate.Remove(mCloseBtn.onClick, OnClickCloseBtn);
                base.UnInitEvent ();
            }
            protected override void ResetUI ()
            {
                mAdd.text = "+";
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
            public void Show(uint old_energy , uint new_energy , uint new_energy_max ,uint last_enetgy_max ,uint new_level , uint last_level ,  uint orig_rank , uint total_rank)
            {
                mOldLabel[0].text = ""+last_level;
                mOldLabel[1].text = ""+old_energy;
                mOldLabel[2].text = ""+last_enetgy_max;
                mOldLabel[3].text = ""+last_level;

                mNewLabel[0].text = ""+new_level;
                mNewLabel[1].text = ""+new_energy;
                mNewLabel[2].text = ""+new_energy_max;
                mNewLabel[3].text = ""+new_level;
                if(LocalPlayerManager.Instance.LocalActorAttribute.Level == 1)
                {
                    mShowCount = 5;
                    for(int i = 0 ; i < mFrame.Count ; i ++)
                    {
                        if(i != 0)
                            mFrame[i].transform.localPosition = new Vector3(0,mFrame[i-1].transform.localPosition.y - 53 , 0);
                    }
                }
                else
                {
                    mShowCount = 4;
                    for(int i = 0 ; i < mFrame.Count ; i ++)
                    {
                        if(i != 0)
                            mFrame[i].transform.localPosition = new Vector3(0,mFrame[i-1].transform.localPosition.y - 60 , 0);
                    }
                    mFrame[4].SetActive(false);
                }
                float delay = 0.5f;
                for(int i = 0 ; i <mShowCount ; i ++)
                {
                    ShowBarWithDelay(mFrame[i] , delay);
                }
                delay = 1f;
                for(int i = 0 ; i <4 ; i ++)
                {
                    ShowTextAlphaAndScale(mOldLabel[i].gameObject , delay);
                    ShowTextAlphaAndScale(mNewLabel[i].gameObject , delay);
                }
                if(orig_rank != 0 && total_rank != 0)
                {
//                    mRollWidget.SetNum(total_rank , orig_rank);
                }

                base.Show();
            }
            protected override void HideUI ()
            {
                base.HideUI ();
            }
        }
    }
}


