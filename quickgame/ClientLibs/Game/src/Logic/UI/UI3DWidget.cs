/*----------------------------------------------------------------
// 文件名： UI3DWidget.cs
// 文件功能描述： 挂接在3D对象上的UI挂件
//----------------------------------------------------------------*/
using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using xc.ui.ugui;

[wxb.Hotfix]
public class UI3DWidget : MonoBehaviour
{
    public class StyleInfo
    {
        public Vector3 Offset = Vector3.zero;
        public Vector3 ScreenOffset = Vector3.zero;
        public Vector3 Scale = Vector3.one;
    }
    protected StyleInfo mStyleInfo;

    public void ResetStyleInfo(StyleInfo info)
    {
        mStyleInfo = info;

        Offset = info.Offset;
        ScreenOffset = info.ScreenOffset;
        Scale = info.Scale;
    }

    protected Vector3 mOffset = Vector3.zero;//offset in world
    protected Vector3 mScreenOffset = Vector3.zero;
    protected Vector3 mScale = Vector3.one;

    protected Transform mOwnerTrans;
    protected Transform mTrans;// 在UI中UI3DWidget对应的Transform

    //新逻辑
    protected UIHudActorWindow mHudActorWin;
    Transform uiParent;
    bool isInit = false;

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
            pos.z = 0f;
            // 在屏幕外
            Rect camRect = mainCamera.pixelRect;
            if(!camRect.Contains(pos))
            {
                mTrans.localPosition = new Vector3(0, -10000.0f, 0);
            }
            Camera uiCamera = xc.ui.ugui.UIMainCtrl.MainCam;
            //Camera uiCamera = xc.ui.UIManager.GetInstance().UIMain.MainCam;
            Vector3 lblPos = uiCamera.ScreenToWorldPoint(pos);
    		mTrans.position = lblPos;
    		if (screenOffset.Equals(Vector3.zero) == false)
    		{
    			Vector3 localPos = mTrans.localPosition;
    			mTrans.localPosition = localPos + screenOffset;
            }
            mTrans.localPosition = new Vector3(mTrans.localPosition.x, mTrans.localPosition.y, 0);
        }
	}

	public void UpdatePosition()
	{
        Camera mainCamera = xc.Game.Instance.MainCamera;
        if (mainCamera == null)
        {
            return;
        }

		if (mOwnerTrans != null)
		{
			UpdatePosition(mOwnerTrans.position, mOffset, mScreenOffset);
		}
	}

    protected virtual void Init()
    {
        uiParent = mHudActorWin.mUIObject.transform;
        Object obj = uiParent.Find(RootName).gameObject;
        GameObject imageObj = (GameObject)GameObject.Instantiate(obj);
        Transform imageTrans = imageObj.transform;
        imageTrans.SetParent(uiParent);
        imageTrans.localPosition = Vector3.zero;
        imageTrans.localScale = mScale;
        imageObj.SetActive(true);
        mTrans = imageTrans;

        mOwnerTrans = transform;
    }

    protected virtual string RootName
    {
        get
        {
            return string.Empty;
        }
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
		if (mTrans)
		{
			GameObject.Destroy(mTrans.gameObject);
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

    public bool Visible
    {
        get
        {
            if (mTrans != null)
            {
                return mTrans.gameObject.activeSelf;
            }

            return false;
        }
        set
        {
            if (mTrans != null)
            {
                mTrans.gameObject.SetActive(value);
            }
        }
    }
}
