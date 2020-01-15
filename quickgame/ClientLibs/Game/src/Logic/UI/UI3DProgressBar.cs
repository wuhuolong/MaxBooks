/*----------------------------------------------------------------
// 文件名： UI3DProgressBar.cs
// 文件功能描述： 挂接在3D对象上的进度条组件
//----------------------------------------------------------------*/
using System;
using UnityEngine;
using UnityEngine.UI;
using xc;
using xc.ui.ugui;

[wxb.Hotfix]
public class UI3DProgressBar : MonoBehaviour
{
    Slider mProgressBar;
    Image mBackgroundSprite;
    Slider mForegroundBar;

	Vector3 mOffset = Vector3.zero;

    Vector3 mHeadOffset = new Vector3(0,0.8f,0);
    Transform mOwnerTrans;
    Transform mTextTrans;
    WeakReference mActor;
    GameObject mProgressBarObj;
    Transform mHeadTrans;

    GameObject mEvilValueTag;
    Text mEvilValue;     // Boss的浊气值

    UIHudActorWindow mHudActorWin;

    bool mIsInit = false;
    long mLastHPValue;
    long mSliderHPValue;

    Image mBarFill;

    string mPoolKey = "UI_3DProgressBar";
    ObjCachePoolType mPoolType = ObjCachePoolType.SMALL_PREFAB;
    //bool mShouldShowHPBar = false;

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
        mProgressBarObj = ObjCachePoolMgr.Instance.LoadFromCache(mPoolType, mPoolKey) as GameObject;
        if (mProgressBarObj == null)
        {
            mProgressBarObj = (GameObject)GameObject.Instantiate(mHudActorWin.ProgressObj);

            PoolGameObject pg = mProgressBarObj.AddComponent<PoolGameObject>();
            pg.poolType = mPoolType;
            pg.key = mPoolKey;
        }

        var trans = mProgressBarObj.transform;
        trans.SetParent(mHudActorWin.ProgressRootTrans);
        trans.localPosition = Vector3.zero;
        trans.localScale = new Vector3(1f, 1f, 1f);
        CommonTool.SetActive(mProgressBarObj, true);

        mProgressBar = UIHelper.FindChild(mProgressBarObj, "Slider").gameObject.GetComponent<Slider>();
        mProgressBar.interactable = false;

        GameObject groundObject = UIHelper.FindChild(mProgressBarObj, "Background").gameObject;
        mBackgroundSprite = groundObject.GetComponent<Image>();

        groundObject = UIHelper.FindChild(mProgressBarObj, "Foreground").gameObject;
        mForegroundBar = groundObject.GetComponent<Slider>();
        mForegroundBar.interactable = false;

        mBarFill = UIHelper.FindChild(groundObject, "Fill").GetComponent<Image>();

        mTextTrans = mProgressBarObj.transform;
        mOwnerTrans = transform;

        mScreenOffset = UI3DText.HpProgressScreenOffset;

        mEvilValueTag = UIHelper.FindChild(mProgressBarObj, "EvilValueTag");
        mEvilValue = UIHelper.FindChild(mProgressBarObj, "EvilValue").GetComponent<Text>();

        InitEvent();
    }

    void InitEvent()
    {
        xc.ClientEventManager<ClientEvent>.Instance.SubscribeClientEvent(ClientEvent.EC_ACTOR_HP_CHANGE, OnActorHpChange);
        // ClientEventMgr.Instance.SubscribeClientEvent((int)ClientEvent.CE_CLICKMONSTER, OnClickMonster);
        ClientEventMgr.Instance.SubscribeClientEvent((int)ClientEvent.CE_SELECTACTOR_CHANGE, OnSelectActorChange);
    }

    void OnSelectActorChange(CEventBaseArgs data)
    {
        if (mActor == null || !mActor.IsAlive)
        {
            return;
        }

        var myActor = (Actor)mActor.Target;

        var actorMono = (ActorMono)data.arg;
        if (actorMono != null && mProgressBarObj != null && actorMono.BindActor != null)
        {
            bool is_show = false;

            if (actorMono.BindActor.UID == myActor.UID || myActor.IsGuardedNpc()) // 守护Npc
                is_show = true;

            if (mProgressBarObj.activeSelf != is_show)
            {
                mProgressBarObj.SetActive(is_show);
                if (is_show)
                {
                    if (myActor.IsGuardedNpc())
                    {
                        mBarFill.sprite = mHudActorWin.LoadSprite(UI3DText.FriendHpName);
                    }
                    else
                    {
                        LocalPlayer localPlayer = (LocalPlayer)Game.GetInstance().GetLocalPlayer();
                        if (PKModeManagerEx.Instance.IsFriendRelation(localPlayer, myActor))
                            mBarFill.sprite = mHudActorWin.LoadSprite(UI3DText.FriendHpName);
                        else
                            mBarFill.sprite = mHudActorWin.LoadSprite(UI3DText.EnemyHpName);
                    }
                }
            }

            // 浊气值
            SetEvilValue(actorMono.BindActor.ActorId);
        }
    }

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
            if(myActor.FullLife > 0)
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
        ClientEventMgr.Instance.UnsubscribeClientEvent((int)ClientEvent.CE_SELECTACTOR_CHANGE, OnSelectActorChange);
    }

    /// <summary>
    /// 显示角色的浊气值
    /// </summary>
    /// <param name="actorId"></param>
    void SetEvilValue(uint actorId)
    {
        bool display_evil = false;
        uint value = 0;

        if (xc.SceneHelp.Instance.IsInSouthLandInstance) // 南天圣地
        {
            var evilValueItem = DBManager.Instance.GetDB<DBEvilValue>().GetData(actorId);
            if (null != evilValueItem)
            {
                display_evil = true;
                value = evilValueItem.Value;
            }
        }
        else if (xc.SceneHelp.Instance.IsInElementAreaInstance) // 元素禁地
        {
            var evilValueItem = DBManager.Instance.GetDB<DBElementAreaEvilValue>().GetData(actorId);
            if (null != evilValueItem)
            {
                display_evil = true;
                value = evilValueItem.Value;
            }
        }

        if (mEvilValue != null)
        {
            mEvilValue.text = value.ToString();
        }

        if (mEvilValueTag != null)
        {
            CommonTool.SetActive(mEvilValueTag, display_evil);
        }
    }

    public void SetHeadTrans(Transform headTrans)
    {
        mHeadTrans = headTrans;
    }

    float mProgressSliderTime = 0f;
    float mSliderPlayTime = 0.8f;
    private void Update()
    {
        if (!mIsInit || mIsDestory)
            return;

        if (mActor == null || !mActor.IsAlive)
            return;

        var myActor = (Actor)mActor.Target;

        if (myActor.HPProgressBarIsActive)
        {
            float sliderRate = 0;
            float targetRate = 0;
            if (myActor.FullLife > 0)
            {
                sliderRate = (float)((double)mSliderHPValue / (double)myActor.FullLife);
                targetRate = (float)((double)myActor.CurLife / (double)myActor.FullLife);
            }

            mProgressSliderTime = mProgressSliderTime + Time.deltaTime;
            var offset = mProgressSliderTime / mSliderPlayTime;
            offset = Mathf.Min(offset, 1);
            mProgressBar.value = Mathf.Lerp(sliderRate, targetRate, offset);

            // 浊气值
            SetEvilValue(myActor.ActorId);
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
            if (mIsDestory)
                return;

            UpdatePosition();
        }
	}

    Vector3 mScreenOffset;
    public void UpdatePosition()
    {
        Camera mainCamera = xc.Game.Instance.MainCamera;
        if (mainCamera == null)
        {
            return;
        }

        if (mProgressBarObj == null || mProgressBarObj.activeSelf == false)
        {
            return;
        }

        if (mHeadTrans != null)
        {
            UpdatePosition(mHeadTrans.position, HeadOffset, mScreenOffset);
        }
        else if (mOwnerTrans != null)
        {
            UpdatePosition(mOwnerTrans.position, mOffset, mScreenOffset);
        }
    }

    public void UpdatePosition(Vector3 targetPosition, Vector3 offset, Vector3 screenOffset)
    {
        Camera mainCamera = xc.Game.Instance.MainCamera;
        if (mainCamera == null)
        {
            return;
        }

        if (mProgressBarObj.transform != null)
        {
            Vector3 pos = mainCamera.WorldToScreenPoint(targetPosition + offset);
            pos.z = 0f;
            // 在屏幕外
            Rect camRect = mainCamera.pixelRect;
            if (!camRect.Contains(pos))
            {
                mProgressBarObj.transform.localPosition = new Vector3(0, -10000.0f, 0);
            }
            Camera uiCamera = xc.ui.ugui.UIMainCtrl.MainCam;
            //Camera uiCamera = xc.ui.UIManager.GetInstance().UIMain.MainCam;
            Vector3 lblPos = uiCamera.ScreenToWorldPoint(pos);
            mProgressBarObj.transform.position = lblPos;
            if (screenOffset.Equals(Vector3.zero) == false)
            {
                Vector3 localPos = mProgressBarObj.transform.localPosition;
                mProgressBarObj.transform.localPosition = localPos + screenOffset;
            }
            mProgressBarObj.transform.localPosition = new Vector3(mProgressBarObj.transform.localPosition.x, mProgressBarObj.transform.localPosition.y, 0);
        }
    }

    void OnEnable()
	{
        if (mProgressBar)
		{
            mProgressBar.gameObject.SetActive(true);
		}

        if(mForegroundBar)
        {
            mForegroundBar.gameObject.SetActive(true);
        }
	}

	void OnDisable()
	{
        if (mProgressBar)
		{
            mProgressBar.gameObject.SetActive(false);
		}

        if (mForegroundBar)
        {
            mForegroundBar.gameObject.SetActive(false);
        }

        if (mEvilValueTag)
        {
            mEvilValueTag.SetActive(false);
        }
    }

    bool mIsDestory = false;

	void OnDestroy()
	{
        mIsDestory = true;
        UninitEvent();

        mActor = null;
        if (mProgressBarObj)
		{
            ObjCachePoolMgr.Instance.RecyclePrefab(mProgressBarObj, ObjCachePoolType.SMALL_PREFAB, mPoolKey);
            mProgressBarObj = null;
        }
	}

    public bool Visible
    {
        get
        {
            if(mProgressBar != null)
            {
                return mProgressBar.gameObject.activeSelf;
            }

            return false;
        }
        set
        {
            mProgressBar.gameObject.SetActive(value);
            mBackgroundSprite.gameObject.SetActive(value);
            mForegroundBar.gameObject.SetActive(value);
        }
    }

	/// <summary>
	/// 获取以及设置位置偏移值
	/// </summary>
	public Vector3 Offset
	{
		get { return mOffset; }
		set { mOffset = value; }
	}

    /// <summary>
    /// 获取以及设置位置偏移值
    /// </summary>
    public Vector3 HeadOffset
    {
        get { return mHeadOffset; }
        set { mHeadOffset = value; }
    }

	/// <summary>
	/// 获取以及设置进度条位置
	/// </summary>
	public Vector3 Position
	{
		get
		{
            if (mProgressBar)
                return mProgressBar.transform.position;
			else
				return Vector3.zero;
		}
		set
		{
            if (mProgressBar)
                mProgressBar.transform.position = value;
		}
	}

    public Image backgroundSprite
    {
        get
        {
            return mBackgroundSprite;
        }
    }

    public string backgroundSpriteName
    {
        get
        {
            if (mBackgroundSprite != null)
            {
                return mBackgroundSprite.sprite.name;
            }

            return string.Empty;
        }
        set
        {
            if (mBackgroundSprite != null)
            {
                mBackgroundSprite.sprite.name = value;
            }
        }
    }

    public void SetTargetActor(Actor actor)
    {
        if (actor == null)
        {
            return;
        }

        mActor = new WeakReference(actor);
        mLastHPValue = actor.CurLife;
        mSliderHPValue = actor.CurLife;

        if (mProgressBarObj != null)
            mProgressBarObj.SetActive(true);

        if (mHudActorWin != null && mBarFill != null)
        {
            if(actor.IsGuardedNpc())// 守护npc强制使用指定Sprite
            {
                mBarFill.sprite = mHudActorWin.LoadSprite(UI3DText.FriendHpName);
            }
            else
            {
                LocalPlayer localPlayer = (LocalPlayer)Game.GetInstance().GetLocalPlayer();
                if (PKModeManagerEx.Instance.IsFriendRelation(localPlayer, actor))
                    mBarFill.sprite = mHudActorWin.LoadSprite(UI3DText.FriendHpName);
                else
                    mBarFill.sprite = mHudActorWin.LoadSprite(UI3DText.EnemyHpName);
            }
            OnActorHpChange(new xc.ClientEventBaseArgs(actor));
        }
    }
}
