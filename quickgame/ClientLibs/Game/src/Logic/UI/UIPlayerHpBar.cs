
/*----------------------------------------------------------------
// 文件名： UIPlayerHpBar.cs
// 文件功能描述： 挂接在3D对象上的进度条组件
//----------------------------------------------------------------*/
using System;
using UnityEngine;
using UnityEngine.UI;
using xc;
using xc.ui.ugui;

[wxb.Hotfix]
public class UIPlayerHpBar : MonoBehaviour
{
    Slider mProgressBar;
//    Image mBackgroundSprite;
    Slider mForegroundBar;

    Vector3 mOffset = Vector3.zero;

    Vector3 mHeadOffset = new Vector3(0, 0.8f, 0);
    Transform mOwnerTrans;
    Transform mTextTrans;
    WeakReference mActor;
    GameObject mProgressBarObj;
    Transform mHeadTrans;

    UIHudActorWindow mHudActorWin;

    bool mIsInit = false;
    long mLastHPValue;
    long mSliderHPValue;

    bool mShouldShowHPBar = false;

    void Awake()
    {
        var basewin = UIManager.Instance.GetWindow("UIHudActorWindow");
        if (basewin != null && basewin.IsLoadDone == true)
        {
            mHudActorWin = basewin as UIHudActorWindow;
            Init();
            mIsInit = true;
        }
    }

    void Init()
    {
        //Transform parent = mHudActorWin.mUIObject.transform;

        //GameObject obj = parent.Find("UIPlayerHpBar").gameObject;
        mProgressBarObj = transform.gameObject; //(GameObject)GameObject.Instantiate(obj);
        //mProgressBarObj.transform.SetParent(parent);
        //mProgressBarObj.transform.localPosition = Vector3.zero;
        //mProgressBarObj.transform.localScale = new Vector3(1f, 1f, 1f);
        //mProgressBarObj.SetActive(false);

        mProgressBar = UIHelper.FindChild(mProgressBarObj, "Slider").gameObject.GetComponent<Slider>();
        mProgressBar.interactable = false;

        GameObject groundObject = null;
        //UIHelper.FindChild(mProgressBarObj, "Background").gameObject;
        //mBackgroundSprite = groundObject.GetComponent<Image>();

        groundObject = UIHelper.FindChild(mProgressBarObj, "Foreground").gameObject;
        mForegroundBar = groundObject.GetComponent<Slider>();
        mForegroundBar.interactable = false;

        mTextTrans = mProgressBarObj.transform;
        mOwnerTrans = transform;

        mScreenOffset = UI3DText.HpProgressScreenOffset;

        InitBar();
    }

    void InitEvent()
    {
         xc.ClientEventManager<ClientEvent>.Instance.SubscribeClientEvent(ClientEvent.EC_ACTOR_HP_CHANGE, OnActorHpChange);
//         // ClientEventMgr.Instance.SubscribeClientEvent((int)ClientEvent.CE_CLICKMONSTER, OnClickMonster);
//         ClientEventMgr.Instance.SubscribeClientEvent((int)ClientEvent.CE_SELECTACTOR_CHANGE, OnSelectActorChange);
    }

//     public void OnSelectActorChange(Actor bind_actor)
//     {
//         if (mActor == null || !mActor.IsAlive)
//         {
//             return;
//         }
// 
//         var myActor = (Actor)mActor.Target;
// 
//        
//         if (actorMono != null)
//         {
//             mProgressBarObj.SetActive(actorMono.BindActor.UID == myActor.UID);
//         }
//     }

    void OnActorHpChange(xc.ClientEventBaseArgs args)
    {
        if (mActor == null || !mActor.IsAlive)
        {
            return;
        }
        var myActor = (Actor)mActor.Target;

        var actor = (Actor)args.GetArg();
        if (actor == null)
        {
            GameDebug.LogError("actor == null");
            return;
        }

        if (myActor.UID == actor.UID)
        {
            if (myActor.IsDead() == false && myActor.FullLife > 0)
                mForegroundBar.value = (float)((double)myActor.CurLife / (double)myActor.FullLife);
            else
                mForegroundBar.value = 0;
            mSliderHPValue = mLastHPValue;
            mLastHPValue = myActor.CurLife;
            mProgressSliderTime = 0;
        }
    }

    void UninitEvent()
    {
        xc.ClientEventManager<ClientEvent>.Instance.UnsubscribeClientEvent(ClientEvent.EC_ACTOR_HP_CHANGE, OnActorHpChange);
        // ClientEventMgr.Instance.UnsubscribeClientEvent((int)ClientEvent.CE_CLICKMONSTER, OnClickMonster);
//        ClientEventMgr.Instance.UnsubscribeClientEvent((int)ClientEvent.CE_SELECTACTOR_CHANGE, OnSelectActorChange);
    }

    public void SetHeadTrans(Transform headTrans)
    {
        mHeadTrans = headTrans;
    }

    float mProgressSliderTime = 0f;
    float mSliderPlayTime = 0.8f;
    private void Update()
    {
        if (!mIsInit)
        {
            return;
        }

        if (mActor == null || !mActor.IsAlive)
        {
            return;
        }
        var myActor = (Actor)mActor.Target;

        //if (myActor.HPProgressBarIsActive)
        {
            float sliderRate = 0;
            float targetRate = 0;
            if (myActor.FullLife > 0)
            {
                
                sliderRate = (float)((double)mSliderHPValue / (double)myActor.FullLife);
                if (myActor.IsDead() == false)
                {
                    targetRate = (float)((double)myActor.CurLife / (double)myActor.FullLife);
                    mForegroundBar.value = (float)((double)myActor.CurLife / (double)myActor.FullLife);
                }
                else
                    mForegroundBar.value = 0;
            }
            if(sliderRate == targetRate)
            {
                mProgressSliderTime = 0;
                mProgressBar.value = targetRate;
                mSliderHPValue = myActor.CurLife;
            }
            else
            {
                mProgressSliderTime = mProgressSliderTime + Time.deltaTime;
                var offset = mProgressSliderTime / mSliderPlayTime;
                offset = Mathf.Min(offset, 1);
                mProgressBar.value = Mathf.Lerp(sliderRate, targetRate, offset);
                if(offset >= 0.99f)
                {
                    mSliderHPValue = myActor.CurLife;
                }
            }
        }
    }

    void LateUpdate()
    {
        if (!mIsInit)
        {
            var basewin = UIManager.Instance.GetWindow("UIHudActorWindow");
            if (basewin != null && basewin.IsLoadDone == true)
            {
                mHudActorWin = basewin as UIHudActorWindow;
                Init();
                mIsInit = true;
            }
        }
        else
        {
            if (m_IsDestory)
                return;

            UpdatePosition();
        }
    }

    Vector3 mScreenOffset;
    public void UpdatePosition()
    {
//         Camera mainCamera = xc.Game.Instance.MainCamera;
//         if (mainCamera == null)
//         {
//             return;
//         }
// 
//         if (mProgressBarObj == null || mProgressBarObj.activeSelf == false)
//         {
//             return;
//         }
// 
//         if (mHeadTrans != null)
//         {
//             UpdatePosition(mHeadTrans.position, HeadOffset, mScreenOffset);
//         }
//         else if (mOwnerTrans != null)
//         {
//             UpdatePosition(mOwnerTrans.position, mOffset, mScreenOffset);
//         }
    }

//     public void UpdatePosition(Vector3 targetPosition, Vector3 offset, Vector3 screenOffset)
//     {
//         Camera mainCamera = xc.Game.Instance.MainCamera;
//         if (mainCamera == null)
//         {
//             return;
//         }
// 
//         if (mProgressBarObj.transform != null)
//         {
//             Vector3 pos = mainCamera.WorldToScreenPoint(targetPosition + offset);
//             pos.z = 0f;
//             // 在屏幕外
//             Rect camRect = mainCamera.pixelRect;
//             if (!camRect.Contains(pos))
//             {
//                 mProgressBarObj.transform.localPosition = new Vector3(0, -10000.0f, 0);
//             }
//             Camera uiCamera = xc.ui.ugui.UIManager.GetInstance().MainCtrl.MainCam;
//             //Camera uiCamera = xc.ui.UIManager.GetInstance().UIMain.MainCam;
//             Vector3 lblPos = uiCamera.ScreenToWorldPoint(pos);
//             mProgressBarObj.transform.position = lblPos;
//             if (screenOffset.Equals(Vector3.zero) == false)
//             {
//                 Vector3 localPos = mProgressBarObj.transform.localPosition;
//                 mProgressBarObj.transform.localPosition = localPos + screenOffset;
//             }
//             mProgressBarObj.transform.localPosition = new Vector3(mProgressBarObj.transform.localPosition.x, mProgressBarObj.transform.localPosition.y, 0);
//         }
//     }

    void OnEnable()
    {
        if (mProgressBar)
        {
            mProgressBar.gameObject.SetActive(true);
        }
        InitBar();


        InitEvent();
    }

    void OnDisable()
    {
        if (mProgressBar)
        {
            mProgressBar.gameObject.SetActive(false);
        }
        UninitEvent();
    }

    bool m_IsDestory = false;

    void OnDestroy()
    {
        m_IsDestory = true;
        UninitEvent();

        if (mProgressBarObj)
        {
            GameObject.Destroy(mProgressBarObj);
            mProgressBarObj = null;
        }
    }

    public bool Visible
    {
        get
        {
            if (mProgressBar != null)
            {
                return mProgressBar.gameObject.activeSelf;
            }

            return false;
        }
        set
        {
            mProgressBar.gameObject.SetActive(value);
            //mBackgroundSprite.gameObject.SetActive(value);
            mForegroundBar.gameObject.SetActive(value);
        }
    }

//     /// <summary>
//     /// 获取以及设置位置偏移值
//     /// </summary>
//     public Vector3 Offset
//     {
//         get { return mOffset; }
//         set { mOffset = value; }
//     }

//     /// <summary>
//     /// 获取以及设置位置偏移值
//     /// </summary>
//     public Vector3 HeadOffset
//     {
//         get { return mHeadOffset; }
//         set { mHeadOffset = value; }
//     }

//     /// <summary>
//     /// 获取以及设置进度条位置
//     /// </summary>
//     public Vector3 Position
//     {
//         get
//         {
//             if (mProgressBar)
//                 return mProgressBar.transform.position;
//             else
//                 return Vector3.zero;
//         }
//         set
//         {
//             if (mProgressBar)
//                 mProgressBar.transform.position = value;
//         }
//     }

//     public Image backgroundSprite
//     {
//         get
//         {
//             return mBackgroundSprite;
//         }
//     }

//     public string backgroundSpriteName
//     {
//         get
//         {
//             if (mBackgroundSprite != null)
//             {
//                 return mBackgroundSprite.sprite.name;
//             }
// 
//             return string.Empty;
//         }
//         set
//         {
//             if (mBackgroundSprite != null)
//             {
//                 mBackgroundSprite.sprite.name = value;
//             }
//         }
//     }

    public void SetTargetActor(Actor actor)
    {
        if (actor == null)
        {
            mActor = null;
            return;
        }
        mActor = new WeakReference(actor);
        mLastHPValue = actor.CurLife;
        mSliderHPValue = actor.CurLife;
        InitBar();
    }

    void InitBar()
    {
        if (mActor != null && mActor.IsAlive)
        {
            var myActor = (Actor)mActor.Target;
            mLastHPValue = myActor.CurLife;
            mSliderHPValue = myActor.CurLife;
            if(mForegroundBar != null)
            {
                if (myActor.IsDead() == false && myActor.FullLife > 0)
                    mForegroundBar.value = (float)((double)myActor.CurLife / (double)myActor.FullLife);
                else
                    mForegroundBar.value = 0;
            }
        }
    }
}
