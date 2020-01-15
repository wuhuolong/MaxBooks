//-----------------------------------------
// File : UINotice.cs
// Desc: 通用飘窗提示的组件
// raorui 重构
// Date: 2017.12.25
//-----------------------------------------
using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using xc;
using xc.ui;
using xc.ui.ugui;

namespace xc
{
    public class UINotice : xc.Singleton<UINotice>
    {
        private List<string> mCacheText = new List<string>();
        private List<UICommonTips> mDisplayTips = new List<UICommonTips>();
        private List<UICommonTips> mDisplayingTips = new List<UICommonTips>();
        private List<Transform> mDisplayingTipTransforms = new List<Transform>();
        private bool mIsLoad = false;
        private bool mIsInit = false;
        private int mTipsObjCount = 12;//tip个数 做了代码保留 1.3个轮询顶替 2.单个tips替换 
        private int mChacheMaxCount = 20;
        private Utils.Timer mTimer;

        private const float mTipsHeight = 40f;

        /// <summary>
        /// 重登之后需要重置
        /// </summary>
        public void Reset()
        {
            if (mDisplayTips.Count > 0)
            {
                foreach (var item in mDisplayTips)
                {
                    item.mLabel.text = string.Empty;
                }
            }
            else
            {
                mIsLoad = false;
                MainGame.HeartBehavior.StartCoroutine(InitLoad());
                mIsInit = true;
            }

            mCacheText.Clear();
            foreach (var item in mDisplayingTips)
            {
                item.gameObject.SetActive(false);
                item.transform.parent.gameObject.SetActive(false);
            }
            mDisplayingTips.Clear();
            mDisplayingTipTransforms.Clear();

            if (mTimer != null)
            {
                mTimer.Destroy();
                mTimer = null;
            }
            mTimer = new Utils.Timer((int)(GameConstHelper.GetFloat("GAME_FLOAT_TIPS_INTERVAL") * 1000f), true, Mathf.Infinity, UpdateTimer);

            ClientEventMgr.Instance.SubscribeClientEvent((int)ClientEvent.CE_SWITCHINSTANCE, OnSwitchInstance);
            ClientEventMgr.Instance.SubscribeClientEvent((int)ClientEvent.CE_SHOW_ROLLING_NOTICE_END, OnShowRollingNoticeEnd);
        }


        void UpdateTimer(float deltaTime)
        {
            OnShowNext(null, null);
        }

        /// <summary>
        /// 加载资源并进行实例化
        /// </summary>
        /// <returns></returns>
        IEnumerator InitLoad()
        {
            // 加载UICommonTips的资源
            SGameEngine.PrefabResource pr = new SGameEngine.PrefabResource();
            yield return ui.ugui.UIManager.Instance.MainCtrl.StartCoroutine(SGameEngine.ResourceLoader.Instance.load_prefab("Assets/Res/UI/Widget/Preset/UICommonTips.prefab", pr, false));
            GameObject go = pr.obj_ as GameObject;
            GameObject.DontDestroyOnLoad(go);

            // 设置父节点
            go.transform.SetParent(UIMainCtrl.MainCam.transform);
            var canvas = go.GetComponent<Canvas>();
            if (canvas != null)
            {
                canvas.worldCamera = UIMainCtrl.MainCam;
                canvas.planeDistance = 0;
                canvas.sortingOrder = 10000 - 1;
            }

            // 实例化多个Tips的gameobject
            Transform tips_trans = go.transform.Find("TipsParent");
            Transform tips_parent_trans = tips_trans.parent;
            GameObject tips_game_object = tips_trans.gameObject;
            tips_game_object.SetActive(false);
            for (int i = 0; i < mTipsObjCount; i++)
            {
                GameObject parentObj = GameObject.Instantiate(tips_game_object) as GameObject;
                GameObject obj = parentObj.transform.Find("Tips").gameObject;
                GameObject.DontDestroyOnLoad(parentObj);

                parentObj.name = "TipsParent";
                obj.name = "Tips";
                parentObj.transform.SetParent(tips_parent_trans);
                parentObj.transform.localPosition = Vector3.one;
                parentObj.transform.localScale = Vector3.one;

                Transform localTrans = obj.transform;
                RectTransform rect = localTrans.GetComponent<RectTransform>();
                rect.sizeDelta = new Vector2(60, mTipsHeight);
                rect.anchoredPosition = Vector3.zero;
                UICommonTips commonTips = localTrans.gameObject.AddComponent<UICommonTips>();
                InitCallBack(commonTips);
                commonTips.Check();
                obj.SetActive(false);
                mDisplayTips.Add(commonTips);
            }

            mIsLoad = true;
        }

        public void Update()
        {
            // 调整各个tips的位置，使其不重叠
            for (int i = 0; i < mDisplayingTipTransforms.Count; ++i)
            {
                Transform commonTipsTransform = mDisplayingTipTransforms[i];
                int next = i + 1;
                if (next < mDisplayingTipTransforms.Count)
                {
                    Transform nextCommonTipsTransform = mDisplayingTipTransforms[next];
                    if (commonTipsTransform.localPosition.y < (nextCommonTipsTransform.localPosition.y + mTipsHeight))
                    {
                        mDisplayingTips[i].TipsAnimation.enabled = false;
                        mDisplayingTips[i].TipsAnimation.transform.GetComponent<UnityEngine.UI.Image>().color = Color.white;
                        mDisplayingTips[i].mLabel.color = Color.white;
                        commonTipsTransform.localPosition = nextCommonTipsTransform.localPosition + new Vector3(0f, mTipsHeight, 0f);
                    }
                }
            }
        }
        
        void ShowTips()
        {
            foreach(var item in mDisplayTips)
            {
                if (item.mLabel.text.CompareTo(string.Empty) == 0)
                {
                    if (mCacheText.Count > 0)
                    {
                        item.ShowAnimation(mCacheText[0], xc.GameConstHelper.GetInt("GAME_FLOAT_TIPS_MIN_WIDTH"));
                        mCacheText.RemoveAt(0);

                        mDisplayingTips.Add(item);
                        mDisplayingTipTransforms.Add(item.transform);

                        if (mDisplayingTips.Count > 3)
                        {
                            HideTips(mDisplayingTips[0]);
                            mDisplayingTips.Remove(mDisplayingTips[0]);
                            mDisplayingTipTransforms.Remove(mDisplayingTipTransforms[0]);
                        }
                        break;
                    }
                }
            }
        }

        private void InitCallBack(UICommonTips commonTips)
        {
            commonTips.onFinish = showFinish;
            //commonTips.onNext = OnShowNext;
            commonTips.onDestroy = DestroyFinish;
        }

        /// <summary>
        /// 外部通过单例直接调用此方法即可(最多显示一个同样的提示)
        /// </summary>
        /// <param name="str"></param>
        public void ShowMessage_showMaxOne(string str, bool is_important_msg = false)
        {
            if (str == null || str.CompareTo("") == 0)
            {
                GameDebug.LogError(string.Format("ShowMessage str === null or string.Empty"));
                return;
            }
            str = GoodsHelper.ReplaceGoodsColor_blackBkg(str);  //颜色全部转成暗底颜色
            foreach (var item in mDisplayTips)
            {
                if (item.mLabel.text == str)
                    return;
            }
            for (int index = 0; index < mCacheText.Count; ++index)
            {
                if (mCacheText[index] == str)
                    return;
            }

            ShowMessage(str, is_important_msg);
        }

        /// <summary>
        /// 外部通过单例直接调用此方法即可
        /// </summary>
        /// <param name="str"></param>
        /// <param name="is_important_msg">是否是重要的msg（是否可以不合并）</param>
        public void ShowMessage(string str, bool is_important_msg = false)
        {
            if (str == null || str.CompareTo("") == 0)
            {
                GameDebug.LogError(string.Format("ShowMessage str === null or string.Empty"));
                return;
            }
            str = GoodsHelper.ReplaceGoodsColor_blackBkg(str);  //颜色全部转成暗底颜色
            int count = 0;
            foreach (var item in mDisplayTips)
            {
                if (item.mLabel.text.CompareTo("") == 0)
                    count += 1;
            }
            if(is_important_msg == false)
            {
                if (mChacheMaxCount >= mCacheText.Count)
                    mCacheText.Add(str);
            }
            else
                mCacheText.Add(str);

            if (count == mTipsObjCount)
                ShowTips();
        }

        void OnShowNext(UICommonTips tips, GameObject go)
        {
            if(mCacheText.Count >0)
                ShowTips();
        }
        void DestroyFinish(UICommonTips tips , GameObject go)
        {
            tips.mLabel.text = "";
            tips.gameObject.SetActive(false);
            mIsLoad = false;
            mDisplayTips.Clear();
            mCacheText.Clear();
        }

        void showFinish(UICommonTips tips , GameObject go)
        {
            tips.mLabel.text = "";
            tips.gameObject.SetActive(false);
            tips.transform.localPosition = Vector3.zero;
            tips.TipsAnimation.enabled = true;

            GameObject parentObject = tips.gameObject.transform.parent.gameObject;
            parentObject.transform.localPosition = Vector3.zero;

            bool needToDispear = false;
            for (int i = (mDisplayingTips.Count - 1); i >= 0; --i)
            {
                UICommonTips commonTips = mDisplayingTips[i];
                if (needToDispear == true)
                {
                    HideTips(commonTips);
                }
                if (commonTips == tips)
                {
                    needToDispear = true;
                }
            }

            mDisplayingTips.Remove(tips);
            mDisplayingTipTransforms.Remove(tips.transform);
        }

        void HideTips(UICommonTips tips)
        {
            xc.ui.ugui.TweenAlpha tweenAlpha = xc.ui.ugui.TweenAlpha.Begin(tips.gameObject, 0.1f, 0f);
            tweenAlpha.onFinished = (t) =>
            {
                UnityEngine.Object.Destroy(t);

                t.gameObject.SetActive(false);
                t.gameObject.transform.parent.gameObject.SetActive(false);
                tips.mLabel.text = "";
                tips.onFinish(tips, tips.gameObject);
                tips.IsPlayEnd = true;
            };
        }

        void OnSwitchInstance(CEventBaseArgs evt)
        {
            IsShowingRollingNotice = false;
        }

        void OnShowRollingNoticeEnd(CEventBaseArgs evt)
        {
            IsShowingRollingNotice = false;
        }

        /// <summary>
        /// 滚动系统提示（跑马灯）
        /// </summary>
        public bool IsShowingRollingNotice = false;
        public void ShowRollingNotice(string str)
        {
            ClientEventMgr.Instance.FireEvent((int)ClientEvent.CE_SHOW_ROLLING_NOTICE, new CEventBaseArgs(GoodsHelper.ReplaceGoodsColor_blackBkg(str)));

            IsShowingRollingNotice = true;
        }

        /// <summary>
        /// 系统警告
        /// </summary>
        public void ShowWarnning(string str)
        {
            ClientEventMgr.Instance.FireEvent((int)ClientEvent.CE_SHOW_COMMON_TIPS_WARNNING, new CEventBaseArgs(str));
        }

        /// <summary>
        /// 弹幕
        /// </summary>
        public void ShowDanmaku(string str)
        {
            ClientEventMgr.Instance.FireEvent((int)ClientEvent.CE_SHOW_DANMAKU, new CEventBaseArgs(GoodsHelper.ReplaceGoodsColor_blackBkg(str)));
        }

        /// <summary>
        /// 屏幕底部的提示
        /// </summary>
        public void ShowBottomMessage(string str)
        {
            ClientEventMgr.Instance.FireEvent((int)ClientEvent.CE_SHOW_BOTTOM_MESSAGE, new CEventBaseArgs(str));
        }

        /// <summary>
        /// 通用文字提示
        /// </summary>
        public void ShowCommonTextTips(string str)
        {
            ClientEventMgr.Instance.FireEvent((int)ClientEvent.CE_SHOW_COMMON_TEXT_TIPS, new CEventBaseArgs(str));
        }

        /// <summary>
        /// 通用文字提示，大界面的
        /// </summary>
        public void ShowBigCommonTextTips(string str)
        {
            ClientEventMgr.Instance.FireEvent((int)ClientEvent.CE_SHOW_BIG_COMMON_TEXT_TIPS, new CEventBaseArgs(str));
        }
    }
}

