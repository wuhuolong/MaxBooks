/*----------------------------------------------------------------
// 文件名： UI3DTargetGuide.cs
// 文件功能描述： 挂接在3D对象上的目标指引挂件
//----------------------------------------------------------------*/
using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;
using xc;
using xc.ui.ugui;

public class UI3DTargetGuide : MonoBehaviour
{
    public class StyleInfo
    {
        public float EllipseRadius1;
        public float EllipseRadius2;
    }
    protected StyleInfo mStyleInfo;

    public void ResetStyleInfo(StyleInfo info)
    {
        mStyleInfo = info;

        mEllipseRadius1 = info.EllipseRadius1;
        mEllipseRadius2 = info.EllipseRadius2;
    }

    protected float mEllipseRadius1;
    protected float mEllipseRadius2;

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

	public void UpdatePosition(Vector3 sourcePosition, Vector3 ownerPosition)
	{
        Camera mainCamera = xc.Game.Instance.MainCamera;
		if (mainCamera == null)
		{
			return;
		}

        Vector3 offset = ownerPosition - sourcePosition;
        offset = offset.normalized;
        ownerPosition = sourcePosition + offset;

        Vector3 sourceScreenPos = mainCamera.WorldToScreenPoint(sourcePosition);
        sourceScreenPos.z = 0f;
        Vector3 ownerScreenPos = mainCamera.WorldToScreenPoint(ownerPosition);
        ownerScreenPos.z = 0f;

        Vector3 screenOffset = ownerScreenPos - sourceScreenPos;
        float a = 2f * mEllipseRadius1;
        float b = 2f * mEllipseRadius2;
        float x = 1f / Mathf.Sqrt((1f / (a * a)) + ((screenOffset.y * screenOffset.y) / ((b * b) * (screenOffset.x * screenOffset.x))));
        if (screenOffset.x < 0f)
        {
            x = -x;
        }
        float y = (x * screenOffset.y) / screenOffset.x;

        Vector3 screenPos = new Vector3(x + sourceScreenPos.x, y + sourceScreenPos.y, 0f);
        Camera uiCamera = xc.ui.ugui.UIMainCtrl.MainCam;
        Vector3 worldPos = uiCamera.ScreenToWorldPoint(screenPos);
        mTrans.position = worldPos;
        Vector3 localPosition = mTrans.localPosition;
        localPosition.z = 0f;
        mTrans.localPosition = localPosition;

        // 箭头的旋转
        float degree = 0f;
        if (screenOffset.y == 0f)
        {
            if (screenOffset.x >= 0f)
            {
                degree = 270f;
            }
            else
            {
                degree = 90f;
            }
        }
        else
        {
            float radians = Mathf.Atan(screenOffset.x / screenOffset.y);
            if (screenOffset.y >= 0f)
            {
                degree = -180f * radians / Mathf.PI;
            }
            else
            {
                degree = 180f - 180f * radians / Mathf.PI;
            }
        }
        mTrans.localRotation = Quaternion.Euler(0f, 0f, degree);
    }

	public void UpdatePosition()
	{
        Camera mainCamera = xc.Game.Instance.MainCamera;
        if (mainCamera == null)
        {
            return;
        }

        Actor localPlayer = Game.Instance.GetLocalPlayer();
		if (localPlayer != null && mOwnerTrans != null)
		{
			UpdatePosition(localPlayer.Trans.position, mOwnerTrans.position);
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
        imageTrans.localScale = Vector3.one;
        imageObj.SetActive(true);
        mTrans = imageTrans;

        mOwnerTrans = transform;
    }

    protected virtual string RootName
    {
        get
        {
            return "3DTargetArrowImage";
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
