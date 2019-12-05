/*----------------------------------------------------------------
// 文件名： UI3DText.cs
// 文件功能描述： 挂接在3D对象上的文本组件
//----------------------------------------------------------------*/
using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using xc.ui.ugui;
using xc;

[wxb.Hotfix]
public class UI3DText : MonoBehaviour
{
    public static Vector3 NameTextScreenOffset = new Vector3(0, 15, 0); //名字距离头顶高度  (UI界面距离)
    public static Vector3 HpProgressScreenOffset = new Vector3(0, 20, 0);   //血条距离头顶高度（UI界面距离）
    public static string LocalPlayerHpName = "MainWindow_New@Combat_PlayerHp"; //"Commonality@Loading_EXP@6x6x6x6";
    public static string FriendHpName = "MainWindow_New@Combat_PlayerHp"; //"Commonality @Loading_MP@6x6x6x6";
    public static string EnemyHpName = "MainWindow_New@Combat_EnemyHp";//"Commonality@Loading_HP@6x6x6x6";
    public class StyleInfo
    {
        public Vector3 Offset = Vector3.zero;
        public Vector3 HeadOffset = Vector3.zero;
        public Vector3 ScreenOffset = Vector3.zero;
        public Vector3 Scale = Vector3.one;
        public string SpritName = "";
        public int SpriteWidth = 0;
        public int SpriteHeight = 0;
        public Vector3 TextPos = Vector3.zero;
        public Color TextColor = Color.white;
        public bool IsShowBg = false;
        public bool IsShowBgPreHead = false;//是否显示头像前的图标
        public bool IsShowTeamIcon = false;//是否显示队伍标志
        public Vector3 BgPreHeadOffset = Vector3.zero;  //头像的偏移值
        public bool IsShowAffiliationPanel = false; //是否显示掉落所属
        public bool IsShowBar = false;  //是否显示血条
        public string HpBarName = string.Empty;   //血条名字
        public bool IsEnemyRelation = true;     //是否是敌人的血条
        public bool LayoutIsVisiable = true;    //默认是可见的
        //public System.WeakReference mActor;
        //public string GuildNameTextLabel;   //帮派名字
        //public string HangUpTextLabel;      //挂机中
    }
    StyleInfo mStyleInfo;

    public void ResetStyleInfo(StyleInfo info, Actor owner = null)
    {
        mStyleInfo = info;
        if(mStyleInfo !=  null)
        {
            Offset = info.Offset;
            HeadOffset = info.HeadOffset;
            ScreenOffset = info.ScreenOffset;
            Scale = info.Scale;

            SpritName = info.SpritName;
            if(Sprite != null)
            {
                Sprite.rectTransform.sizeDelta = new Vector2(info.SpriteWidth, info.SpriteHeight);
            }

            if(TextLabel != null)
            {
                //TextLabel.transform.localPosition = info.TextPos;
                TextLabel.color = info.TextColor;
            }

            ShowBGSprite = info.IsShowBg;
            ShowPreBGSprite = info.IsShowBgPreHead;
            BgPreHeadOffset = info.BgPreHeadOffset;
            IsShowAffiliationPanel = info.IsShowAffiliationPanel;
            IsShowBar = info.IsShowBar;
            HpBarName = info.HpBarName;
            SetLayoutVisiable(mStyleInfo.LayoutIsVisiable);
            SetActor(owner);
        }
    }

    string mTextString = "";
	Text mTextLabel;
    Text mGuildNameTextLabel;   //帮派名
    Text mMateNameTextLabel;   //情缘名
    Text mRankTextLabel;    // 排名，目前用于剑域盛会雕像
    Text mHangUpTextLabel;  //挂机中
    GameObject mHonorPanel; //头衔panel
    Image mHonorIcon; // 头衔图标
    Image mTitleIcon; // 称号图标
    RawImage mTitleEffect; // 称号图标特效
    Image mSprite;
	RawImage mTexture;
    Image mBGSprite;
    Image mPreBGSprite;
    Image mPeakTeamIconImage;
    Image mTeamIconImage;
    Button mButton;
    Vector3 mOffset = Vector3.zero;//offset in world
	public Vector3 HeadOffset = new Vector3(0,1f,0); //
	Vector3 mScreenOffset = Vector3.zero;
	Transform mOwnerTrans;
	Transform mHeadTrans;
    Transform mTrans;// 在UI中3DText对应的Transform
    GameObject mTextObject; // 3DText对应的GameObject

    string mSpriteName;
	Vector3 mScale = Vector3.one;
    EmojiText DialogBubbleText;
    Transform DialogBubbleParent;
    Transform DialogChatMsgArrow;

    Transform mAffiliationPanel;    //掉落归属图标
    Transform mHpBar;   //血条
    Image mHpBarForegroundFillImage;
    //新逻辑
    UIHudActorWindow mHudActorWin;
    Transform uiParent;
    bool isInit = false;

    Utils.Timer timer;
    UIPlayerHpBar m_hpBarScript;

    float mMaxVisibleDistanceSquare = 2000f;

    string mPoolKey = "UI_3DText";
    ObjCachePoolType mPoolType = ObjCachePoolType.SMALL_PREFAB;

    void Awake()
	{
        var basewin = UIManager.Instance.GetWindow("UIHudActorWindow");
        if (basewin != null && basewin.IsLoadDone == true)
        {
            mHudActorWin = basewin as UIHudActorWindow;
            isInit = true;
            Init();
        }
        else
        {
            //UIManager.Instance.ShowWindow("UIHudActorWindow");
        }
    }

	public void SetOwnerTrans(Transform trans)
	{
		mOwnerTrans = trans;
	}

	public void SetHeadTrans(Transform trans)
	{
		mHeadTrans = trans;
	}

    Vector3 mOffeset = new Vector3(0, -10000.0f, 0);

    public void UpdatePosition(Vector3 targetPosition, Vector3 offset, Vector3 screenOffset)
	{
        Camera mainCamera = xc.Game.Instance.MainCamera;
		if (mainCamera == null)
		{
			return;
		}

        if (mTrans != null)
        {
            Vector3 pos = mainCamera.WorldToScreenPoint(targetPosition + offset);

            // 在屏幕后面
            if (pos.z < 0f)
            {
                mTrans.localPosition = new Vector3(0, -10000.0f, 0);
                return;
            }

            pos.z = 0f;

            // 在屏幕外
            //Rect camRect = mainCamera.pixelRect;
            //if(!camRect.Contains(pos))
            //{
            //    mTrans.localPosition = new Vector3(0, -10000.0f, 0);
            //}

            // 离主角一定距离外面
            Actor localPlayer = Game.Instance.GetLocalPlayer();
            if (localPlayer != null && (targetPosition - localPlayer.ActorTrans.position).sqrMagnitude >= mMaxVisibleDistanceSquare)
            {
                mTrans.localPosition = mOffeset;
            }
            else
            {
                Camera uiCamera = xc.ui.ugui.UIMainCtrl.MainCam;
                Vector3 lblPos = uiCamera.ScreenToWorldPoint(pos);
                mTrans.position = lblPos;

                mTrans.localPosition = new Vector3(mTrans.localPosition.x, mTrans.localPosition.y, 0);

                mTrans.localPosition += screenOffset;
            }
        }
	}
    

    public void UpdatePosition()
	{
        Camera mainCamera = xc.Game.Instance.MainCamera;
        if (mainCamera == null)
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

    void Init()
    {
        mTextObject = ObjCachePoolMgr.Instance.LoadFromCache(mPoolType, mPoolKey) as GameObject;
        if (mTextObject == null)
        {
            mTextObject = (GameObject)GameObject.Instantiate(mHudActorWin.TextObj);

            PoolGameObject pg = mTextObject.AddComponent<PoolGameObject>();
            pg.poolType = mPoolType;
            pg.key = mPoolKey;
        }
        
        Transform textTrans = mTextObject.transform;
        textTrans.SetParent(mHudActorWin.TextRootTrans);
        textTrans.localPosition = Vector3.zero;
        textTrans.localScale = mScale;

        // 激活VerticalLayoutGroup
        var layout_trans = textTrans.Find("Layout");
        if(layout_trans != null)
        {
            CommonTool.SetActive(layout_trans.gameObject, true);
            var vert_layout = layout_trans.GetComponent<VerticalLayoutGroup>();
            if (vert_layout != null)
            {
                if(!vert_layout.enabled)
                    vert_layout.enabled = true;
            }
        }

        mTextObject.SetActive(true);
        mTextLabel = UIHelper.FindChild(textTrans, "TextLabel").GetComponent<Text>();
        if (mTextLabel != null)
            mDefaultFontSize = mTextLabel.fontSize; // 保存默认的字体大小
        mGuildNameTextLabel = UIHelper.FindChild(textTrans, "GuildNameTextLabel").GetComponent<Text>();   //帮派名
        mMateNameTextLabel = UIHelper.FindChild(textTrans, "MateNameTextLabel").GetComponent<Text>();   //帮派名
        mRankTextLabel = UIHelper.FindChild(textTrans, "RankTextLabel").GetComponent<Text>();   //排名
        mHangUpTextLabel = UIHelper.FindChild(textTrans, "HangUpTextLabel").GetComponent<Text>();  //挂机中
        mTextLabel.text = mTextString;
        mGuildNameTextLabel.gameObject.SetActive(false);
        mMateNameTextLabel.gameObject.SetActive(false);
        mRankTextLabel.gameObject.SetActive(false);
        mHangUpTextLabel.gameObject.SetActive(false);
        mBGSprite = UIHelper.FindChild(textTrans, "BGSprite").GetComponent<Image>();
        mPreBGSprite = UIHelper.FindChild(textTrans, "PreBGSprite").GetComponent<Image>();
        mPeakTeamIconImage = UIHelper.FindChild(textTrans, "PeakTeamIconImage").GetComponent<Image>();
        mTeamIconImage = UIHelper.FindChild(textTrans, "TeamIconImage").GetComponent<Image>();
        mAffiliationPanel = UIHelper.FindChild(textTrans.gameObject, "AffiliationPanel").transform;
        mHpBar = UIHelper.FindChild(textTrans.gameObject, "PlayerHpBar").transform;
        mHpBar.gameObject.SetActive(false);
        mHpBarForegroundFillImage = mHpBar.Find("Foreground/Fill Area/Fill").GetComponent<Image>();

        mHonorPanel = UIHelper.FindChild(textTrans, "HonorPanel");
        mHonorPanel.SetActive(false);

        mHonorIcon = UIHelper.FindChild(textTrans, "HonorIcon").GetComponent<Image>();
        mHonorIcon.gameObject.SetActive(true);

        mTitleIcon = UIHelper.FindChild(textTrans, "TitleIcon").GetComponent<Image>();
        mTitleIcon.gameObject.SetActive(false);

        mTitleEffect = mTitleIcon.transform.Find("Effect").GetComponent<RawImage>();
        mTitleEffect.gameObject.SetActive(false);

        m_hpBarScript = mHpBar.gameObject.GetComponent<UIPlayerHpBar>();
        if(m_hpBarScript == null)
        {
            m_hpBarScript = mHpBar.gameObject.AddComponent<UIPlayerHpBar>();
        }

        DialogBubbleParent = UIHelper.FindChild(textTrans.gameObject, "ChatMsgBg").transform;
        DialogBubbleText = UIHelper.FindChild(textTrans.gameObject, "ChatMsgText").GetComponent<EmojiText>();
        DialogChatMsgArrow = UIHelper.FindChild(textTrans.gameObject, "ChatMsgArrow").transform;
        mButton = textTrans.Find("Button").GetComponent<Button>();
        mButton.gameObject.SetActive(false);
        mTrans = textTrans;

        mOwnerTrans = transform;

        if (mStyleInfo != null)
        {
            mBGSprite.gameObject.SetActive(mStyleInfo.IsShowBg);
            mPreBGSprite.gameObject.SetActive(mStyleInfo.IsShowBgPreHead);
            mTeamIconImage.gameObject.SetActive(mStyleInfo.IsShowTeamIcon);
            IsShowAffiliationPanel = mStyleInfo.IsShowAffiliationPanel;
        }
        else
        {
            mBGSprite.gameObject.SetActive(false);
            mPreBGSprite.gameObject.SetActive(false);
            IsShowAffiliationPanel = false;
            mTeamIconImage.gameObject.SetActive(false);
        }
        mPeakTeamIconImage.gameObject.SetActive(false);

        mMaxVisibleDistanceSquare = GameConstHelper.GetFloat("GAME_MWAR_ACTOR_HEAD_TEXT_MAX_VISIBLE_DISTANCE_SQUARE");
    }

	void LateUpdate()
	{
        //这里这样处理是考虑新UI框架是吧头顶文字封装到一个UIHudActorWindow，这样脱离业务逻辑的耦合性
        if (isInit == false)
        {
            var basewin = UIManager.Instance.GetWindow("UIHudActorWindow");
            if (basewin != null&& basewin.IsLoadDone)
            {
                mHudActorWin = basewin as UIHudActorWindow;
                isInit = true;
                Init();
            }
        }
        else
		    UpdatePosition();

	}

	void OnEnable()
	{
		if (mTrans)
		{
			mTrans.gameObject.SetActive(true);
		}
	}

	void OnDisable()
	{
		if (mTrans)
		{
			mTrans.gameObject.SetActive(false);
		}
	}

	void OnDestroy()
	{
        HideDialogBubble(0);

        if (m_hpBarScript != null)
        {
            m_hpBarScript.SetTargetActor(null);
            m_hpBarScript = null;
        }

		if (mTextObject != null)
		{
            // 取消激活VerticalLayoutGroup
            var layout_trans = mTextObject.transform.Find("Layout");
            if (layout_trans != null)
            {
                var vert_layout = layout_trans.GetComponent<VerticalLayoutGroup>();
                if (vert_layout != null)
                {
                    if (vert_layout.enabled)
                        vert_layout.enabled = false;
                }
            }

            if(mDefaultFontSize != 0)
                FontSize = mDefaultFontSize;

            ObjCachePoolMgr.Instance.RecyclePrefab(mTextObject, mPoolType, mPoolKey);
            mTextObject = null;
		}

        mTextString = "";

        if (timer != null)
        {
            timer.Destroy();
            timer = null;
        }
    }

    public void SetLayoutVisiable(bool is_visiable)
    {
        if(mStyleInfo != null)
            mStyleInfo.LayoutIsVisiable = is_visiable;
        if (mTextObject == null)
            return;
        var layout_trans = mTextObject.transform.Find("Layout");
        if (layout_trans != null)
        {
            CommonTool.SetActive(layout_trans.gameObject, is_visiable);
            //layout_trans.gameObject.name = "dddddd";
        }

    }
    public Sprite LoadSprite(string spriteName)
    {
        if (mHudActorWin != null)
        {
            return mHudActorWin.LoadSprite(spriteName);
        }

        return null;
    }

    /// <summary>
    /// 获取以及设置文本内容
    /// </summary>
    public string Text
	{
		get
		{
			if (mTextLabel)
				return mTextLabel.text;
			else
				return "";
		}
		set
		{
			if (mTextLabel)
            {
                if(mTextLabel.gameObject.activeSelf == false)
                {
                    mTextLabel.gameObject.SetActive(true);
                }

                mTextLabel.text = value;
            }
            mTextString = value;
        }
	}
    public string GuildNameTextLabel
    {
        get
        {
            if (mGuildNameTextLabel)
                return mGuildNameTextLabel.text;
            else
                return "";
        }
        set
        {
            if (mGuildNameTextLabel)
            {
                if (value == "")
                    mGuildNameTextLabel.gameObject.SetActive(false);
                else
                    mGuildNameTextLabel.gameObject.SetActive(true);
                mGuildNameTextLabel.text = value;
            }
        }
    }

    public string MateNameTextLabel
    {
        get
        {
            if (mMateNameTextLabel)
                return mMateNameTextLabel.text;
            else
                return "";
        }
        set
        {
            if (mMateNameTextLabel)
            {
                if (value == "")
                    mMateNameTextLabel.gameObject.SetActive(false);
                else
                    mMateNameTextLabel.gameObject.SetActive(true);
                mMateNameTextLabel.text = value;
            }
        }
    }

    public string RankTextLabel
    {
        get
        {
            if (mRankTextLabel)
                return mRankTextLabel.text;
            else
                return "";
        }
        set
        {
            if (mRankTextLabel)
            {
                if (value == "")
                    mRankTextLabel.gameObject.SetActive(false);
                else
                    mRankTextLabel.gameObject.SetActive(true);
                mRankTextLabel.text = value;
            }
        }
    }

    public string HangUpTextLabel
    {
        get
        {
            if (mHangUpTextLabel)
                return mHangUpTextLabel.text;
            else
                return "";
        }
        set
        {
            if (mHangUpTextLabel)
            {
                if (value == "")
                    mHangUpTextLabel.gameObject.SetActive(false);
                else
                    mHangUpTextLabel.gameObject.SetActive(true);
                mHangUpTextLabel.text = value;
            }
        }
    }

    public uint Honor
    {
        set
        {
            if (mHonorIcon)
            {
                var icon = xc.DBManager.Instance.GetDB<xc.DBHonor>().GetHonorIcon(value);
                if (null == icon)
                {
                    mHonorPanel.SetActive(false);
                }
                else
                {
                    mHonorPanel.SetActive(true);
                    mHonorIcon.sprite = LoadSprite(icon);
                }
            }
        }
    }

    public uint Title
    {
        set
        {
            if (mTitleIcon)
            {
                var dbTitle = xc.DBManager.Instance.GetDB<xc.DBTitle>();
                var icon = dbTitle.GetTitleIcon(value);
                if (null == icon)
                {
                    mTitleIcon.gameObject.SetActive(false);
                }
                else
                {
                    mTitleIcon.gameObject.SetActive(true);
                    mTitleIcon.sprite = LoadSprite(icon);
                    mTitleIcon.SetNativeSize();

                    // 特效
                    dbTitle.SetTitleEffect(value, mTitleEffect);
                }
            }
        }
    }

    public Image Sprite
    {
        get { return mSprite; }
    }
	public string SpritName
	{
		set
		{
			mSpriteName = value;
			if(mSprite != null)
			{
				//mSprite.sprite = UIHelper.GetAtlasSprite("Demo" , mSpriteName) ;
                mSprite.SetNativeSize();
                //mSprite.MakePixelPerfect();
			}
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

	public Vector3 ScreenOffset
	{
		get { return mScreenOffset; }
		set { mScreenOffset = value; }
	}

    /// <summary>
    /// 名字背景框是否显示
    /// </summary>
    public bool ShowBGSprite
    {
        get
        {
            if (mBGSprite != null)
            {
                return mBGSprite.gameObject.activeSelf;
            }
            else
            {
                return false;
            }
        }
        set
        {
            if (mBGSprite != null)
            {
                mBGSprite.gameObject.SetActive(value);
                if (mPreBGSprite != null)
                {
                    if (value)
                    {
                        mPreBGSprite.rectTransform.anchoredPosition3D = new Vector3(-42.85f, 10.43999f, 0);
                    }
                    else
                    {
                        mPreBGSprite.rectTransform.anchoredPosition3D = new Vector3(-6.7f, 10.43999f, 0);
                    }
                }
                if (mTeamIconImage != null)
                {
                    if (value)
                    {
                        mTeamIconImage.transform.parent.GetComponent<RectTransform>().anchoredPosition3D = new Vector3(100f, 3f, 0);
                    }
                    else
                    {
                        mTeamIconImage.transform.parent.GetComponent<RectTransform>().anchoredPosition3D = new Vector3(60f, 3f, 0);
                    }
                }
            }
            if (mStyleInfo != null)
            {
                mStyleInfo.IsShowBg = value;
            }
        }
    }

    /// <summary>
    /// 名字背景框是否显示
    /// </summary>
    public bool ShowPreBGSprite
    {
        get
        {
            if (mPreBGSprite != null)
            {
                return mPreBGSprite.gameObject.activeSelf;
            }
            else
            {
                return false;
            }
        }
        set
        {
            if (mPreBGSprite != null)
            {
                mPreBGSprite.gameObject.SetActive(value);
            }
            if (mStyleInfo != null)
            {
                mStyleInfo.IsShowBgPreHead = value;
            }
        }
    }

    /// <summary>
    /// 名字背景框是否显示
    /// </summary>
    public bool IsShowAffiliationPanel
    {
        set
        {
            if (mAffiliationPanel != null)
            {
                mAffiliationPanel.gameObject.SetActive(value);
            }
            if (mStyleInfo != null)
            {
                mStyleInfo.IsShowAffiliationPanel = value;
            }
        }
    }

    public bool IsShowBar
    {
        set
        {
            if (mHpBar != null)
            {
                mHpBar.gameObject.SetActive(value);
                mHpBar.parent.gameObject.SetActive(false);
                mHpBar.parent.gameObject.SetActive(true);
            }
            if (mStyleInfo != null)
            {
                mStyleInfo.IsShowBar = value;
            }
        }
    }

    public string HpBarName
    {
        set
        {
            if (mHpBarForegroundFillImage != null)
            {
                if (mHudActorWin != null && mBGSprite != null)
                {
                    mHpBarForegroundFillImage.sprite = mHudActorWin.LoadSprite(value);
                }
            }
            if (mStyleInfo != null)
            {
                mStyleInfo.HpBarName = value;
            }
        }
    }



    public Vector3 BgPreHeadOffset
    {
        set
        {
            if (mPreBGSprite != null)
            {
                //mPreBGSprite.transform.localPosition = value;
            }
            if (mStyleInfo != null)
            {
                mStyleInfo.BgPreHeadOffset = value;
            }
        }
    }

    public bool SetDialogBubbleText(string text, int time)
    {
        if (timer != null)
        {
            timer.Destroy();
            timer = null;
        }
        if (DialogBubbleParent == null || DialogBubbleText == null)
            return false;
        DialogBubbleText.text = text;
        LayoutMaxSize layoutMaxSize = DialogBubbleText.GetComponent<LayoutMaxSize>();
        if (layoutMaxSize != null)
        {
            layoutMaxSize.OriginalText = text;
        }
        DialogBubbleParent.gameObject.SetActive(true);
        DialogChatMsgArrow.gameObject.SetActive(true);
        if (layoutMaxSize != null)
        {
            layoutMaxSize.ReCalculateText();
        }
        timer = new Utils.Timer(time * 1000, false, time * 1000, HideDialogBubble);
        return true;
    }

    void HideDialogBubble(float remainTime)
    {
        if (remainTime <= 0)
        {
            if (DialogBubbleParent == null)
                return;

            DialogBubbleParent.gameObject.SetActive(false);
            DialogChatMsgArrow.gameObject.SetActive(false);

            if (timer != null)
            {
                timer.Destroy();
                timer = null;
            }
        }
    }

    public void SetBGSprite(string spriteName)
    {
        if (mHudActorWin != null && mBGSprite != null)
        {
            mBGSprite.sprite = mHudActorWin.LoadSprite(spriteName);
        }
    }

    public void SetBGMaterial(string materialName)
    {
        if (mHudActorWin != null && mBGSprite != null)
        {
            mBGSprite.material = mHudActorWin.LoadMaterial(materialName);
        }
    }

    /// <summary>
    /// 获取以及设置文本位置
    /// </summary>
    public Vector3 Position
	{
		get
		{
			if (mTrans)
				return mTrans.position;
			else
				return Vector3.zero;
		}
		set
		{
			if (mTrans)
				mTrans.transform.position = value;
		}
	}

	public Transform Trans
	{
		get { return mTrans; }
	}

	public Text TextLabel
	{
		get { return mTextLabel; }
	}

	public Color TextColor
	{
		get
		{
			if (mTextLabel != null)
			{
				return mTextLabel.color;
			}
			else
			{
				return Color.white;
			}
		}
		set
		{
			if (mTextLabel != null)
			{
				mTextLabel.color = value;
			}
		}
	}

	public Vector3 Scale
	{
		set
		{
			mScale = value;
			if (mTrans != null)
			{
				mTrans.localScale = mScale;
			}
		}
	}

	public int Width
	{
		get
		{
			if (mTextLabel != null)
			{
				return (int)mTextLabel.rectTransform.sizeDelta.x;
			}
			if (mSprite != null)
			{
				return (int)mSprite.rectTransform.sizeDelta.x;
			}
			if (mTexture != null)
			{
				return (int)mTexture.rectTransform.sizeDelta.x;
			}

			return 0;
		}
        set
        {
            if(mSprite != null)
            {
                //mSprite.rectTransform.sizeDelta.Set((float)value , mSprite.rectTransform.sizeDelta.y);
            }
        }
	}

    public int Height
    {
        get
        {
            if(mSprite != null)
            {
                return (int)mSprite.rectTransform.sizeDelta.y;
            }

            return 0;
        }
        set
        {
            if(mSprite != null)
            { 
                
                mSprite.rectTransform.sizeDelta.Set(mSprite.rectTransform.sizeDelta.x ,(float)value);
            }
        }
    }

    public bool Visible
    {
        get
        {
            if(mTrans != null)
            {
                return mTrans.gameObject.activeSelf;
            }

            return false;
        }
        set
        {
            if(mTrans != null)
            {
                mTrans.gameObject.SetActive(value);
            }
        }
    }

    /// <summary>
    /// 字体默认的大小
    /// </summary>
    private int mDefaultFontSize = 0;

    public int FontSize
    {
        get
        {
            if (mTextLabel != null)
            {
                return mTextLabel.fontSize;
            }
            return 0;
        }
        set
        {
            if (mTextLabel != null)
            {
                mTextLabel.fontSize = value;
            }
        }
    }

    public void ShowFrame(bool isShow, bool showPreBGSprite = true)
	{
		if (mBGSprite != null)
		{
            mBGSprite.gameObject.SetActive(isShow);
            if (mPreBGSprite != null)
            {
                mPreBGSprite.gameObject.SetActive(showPreBGSprite);
                if (isShow)
                {
                    mPreBGSprite.rectTransform.anchoredPosition3D = new Vector3(-42.85f, 10.43999f, 0);
                }
                else
                {
                    mPreBGSprite.rectTransform.anchoredPosition3D = new Vector3(-6.7f, 10.43999f, 0);
                }
            }
            if (mTeamIconImage != null)
            {
                if (isShow)
                {
                    mTeamIconImage.transform.parent.GetComponent<RectTransform>().anchoredPosition3D = new Vector3(100f, 3f, 0);
                }
                else
                {
                    mTeamIconImage.transform.parent.GetComponent<RectTransform>().anchoredPosition3D = new Vector3(60f, 3f, 0);
                }
            }
        }
	}

    public void ShowButton(bool isShow)
    {
        if (mButton != null)
        {
            mButton.gameObject.SetActive(isShow);
        }
    }

    public void SetClickCallback(UnityEngine.Events.UnityAction clickCallback)
    {
        if (mButton != null)
        {
            mButton.gameObject.SetActive(true);
            mButton.onClick.RemoveAllListeners();
            mButton.onClick.AddListener(clickCallback);
        }
    }

    public void SetButtonStyle(string buttonSpriteName, string buttonText, int buttonTextFontSize, Color buttonTextColor, Vector3 buttonTextOffset)
    {
        if (mButton != null)
        {
            Image image = mButton.transform.GetComponent<Image>();
            if (string.IsNullOrEmpty(buttonSpriteName) == false)
            {
                image.sprite = mHudActorWin.LoadSprite(buttonSpriteName);
                image.SetNativeSize();
            }
            else
                image.sprite = null;

            Color color = Color.white;
            if (image.sprite != null)
                color.a = 1;
            else
                color.a = 0;
            image.color = color;

            Text text = mButton.transform.Find("Text").GetComponent<Text>();
            text.text = buttonText;
            text.fontSize = buttonTextFontSize;
            text.color = buttonTextColor;
            text.transform.localPosition = buttonTextOffset;
        }
    }

    public void SetButtonOffset(Vector3 offset)
    {
        if (mButton != null)
        {
            mButton.transform.localPosition = offset;
        }
    }

    public Image ButtonImage
    {
        get
        {
            if (mButton != null && mButton.transform != null)
            {
                Transform imageTrans = mButton.transform.Find("Image");
                if (imageTrans != null)
                {
                    return imageTrans.GetComponent<Image>();
                }
            }

            return null;
        }
    }

    public void SetActor(Actor owner)
    {
        if (m_hpBarScript != null)
            m_hpBarScript.SetTargetActor(owner);
    }

    public void ShowTeamIcon(string spriteName, bool isShow)
    {
        DBInstance.InstanceInfo instanceInfo = InstanceManager.Instance.InstanceInfo;
        if (mHudActorWin != null && mTeamIconImage != null && instanceInfo != null)
        {
            if (DBInstanceTypeControl.Instance.HideTeam(instanceInfo.mWarType, instanceInfo.mWarSubType))
            {
                mTeamIconImage.gameObject.SetActive(false);
                return;
            }
            mTeamIconImage.sprite = mHudActorWin.LoadSprite(spriteName);
            mTeamIconImage.gameObject.SetActive(isShow);
        }
    }

    public void ShowPeakTeamIcon(bool isShow)
    {
        if (mPeakTeamIconImage != null)
        {
            mPeakTeamIconImage.gameObject.SetActive(isShow);
        }
    }
}
