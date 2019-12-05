
/*----------------------------------------------------------------
// 文件名： UIDropAffiBar.cs
// 文件功能描述： 挂接在3D对象上的归属组件
//----------------------------------------------------------------*/
using System;
using UnityEngine;
using UnityEngine.UI;
using xc;
using xc.ui.ugui;

[wxb.Hotfix]
public class UIDropAffiBar : MonoBehaviour
{
    
    Vector3 mOffset = Vector3.zero;

    Vector3 mHeadOffset = new Vector3(0, 0.8f, 0);
    Transform mOwnerTrans;
    
    //WeakReference mActor;
    GameObject mDropAffiBarObj;
    Transform mHeadTrans;

    UIHudActorWindow mHudActorWin;

    bool mIsInit = false;

    string mPlayerName = "";
    Text mAffiPlayerNameText;
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
        Transform parent = mHudActorWin.mUIObject.transform;

        GameObject obj = parent.Find("UIDropAffiBar").gameObject;
        obj.gameObject.SetActive(false);
        mDropAffiBarObj = (GameObject)GameObject.Instantiate(obj);
        mDropAffiBarObj.transform.SetParent(parent);
        mDropAffiBarObj.transform.localPosition = Vector3.zero;
        mDropAffiBarObj.transform.localScale = new Vector3(1f, 1f, 1f);
        mDropAffiBarObj.SetActive(false);

        mAffiPlayerNameText = UIHelper.FindChild(mDropAffiBarObj, "AffiPlayerName").gameObject.GetComponent<Text>();
        
        mOwnerTrans = transform;

        mScreenOffset = Vector3.zero;//UI3DText.HpProgressScreenOffset;
        AffiPlayerName = mPlayerName;
        InitEvent();
    }

    void InitEvent()
    {
        
    }
    
    void UninitEvent()
    {
      
    }

    public void SetHeadTrans(Transform headTrans)
    {
        mHeadTrans = headTrans;
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
    public Vector3 ScreenOffset
    {
        get { return mScreenOffset; }
        set { mScreenOffset = value; }
    }
    public void UpdatePosition()
    {
        Camera mainCamera = xc.Game.Instance.MainCamera;
        if (mainCamera == null)
        {
            return;
        }

        if (mDropAffiBarObj == null || mDropAffiBarObj.activeSelf == false)
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

        if (mDropAffiBarObj.transform != null)
        {
            Vector3 pos = mainCamera.WorldToScreenPoint(targetPosition + offset);
            pos.z = 0f;
            // 在屏幕外
            Rect camRect = mainCamera.pixelRect;
            if (!camRect.Contains(pos))
            {
                mDropAffiBarObj.transform.localPosition = new Vector3(0, -10000.0f, 0);
            }
            Camera uiCamera = xc.ui.ugui.UIMainCtrl.MainCam;
            //Camera uiCamera = xc.ui.UIManager.GetInstance().UIMain.MainCam;
            Vector3 lblPos = uiCamera.ScreenToWorldPoint(pos);
            mDropAffiBarObj.transform.position = lblPos;
            if (screenOffset.Equals(Vector3.zero) == false)
            {
                Vector3 localPos = mDropAffiBarObj.transform.localPosition;
                mDropAffiBarObj.transform.localPosition = localPos + screenOffset;
            }
            mDropAffiBarObj.transform.localPosition = new Vector3(mDropAffiBarObj.transform.localPosition.x, mDropAffiBarObj.transform.localPosition.y, 0);
        }
    }

    void OnEnable()
    {
        
    }

    void OnDisable()
    {
        
    }

    bool m_IsDestory = false;

    void OnDestroy()
    {
        m_IsDestory = true;
        UninitEvent();

        if (mDropAffiBarObj)
        {
            GameObject.Destroy(mDropAffiBarObj);
            mDropAffiBarObj = null;
        }
    }

    public bool Visible
    {
        get
        {
            if (mDropAffiBarObj != null)
            {
                return mDropAffiBarObj.activeSelf;
            }

            return false;
        }
        set
        {
            if(mDropAffiBarObj != null)
                mDropAffiBarObj.gameObject.SetActive(value);
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
    
    public string AffiPlayerName
    {
        get { return mPlayerName; }
        set {
            mPlayerName = value;
            if (mAffiPlayerNameText != null)
                mAffiPlayerNameText.text = mPlayerName;
        }
    }
//     public void SetTargetActor(Actor actor)
//     {
//         mActor = new WeakReference(actor);
//     }
}
