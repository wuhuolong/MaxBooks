/*----------------------------------------------------------------
// 文件名： UI3DDialogBubble.cs
// 文件功能描述： 挂接在3D对象上的冒泡对话框
//----------------------------------------------------------------*/
using UnityEngine;
using xc.ui.ugui;
using UnityEngine.UI;

[wxb.Hotfix]
public class UI3DDialogBubble : MonoBehaviour
{
    
    Image mDialogBubbleBgSprite;
    Text mTextLabel;
    Vector3 mOffset = Vector3.zero;

    //新逻辑
    UIHudActorWindow mHudActorWin;
    bool isInit = false;

    void Awake()
    {

        var basewin = UIManager.Instance.GetWindow("UIHudActorWindow");
        if (basewin != null)
        {
            mHudActorWin = basewin as UIHudActorWindow;
            isInit = true;
            Init();
        }
        else
        {
            UIManager.Instance.ShowWindow("UIHudActorWindow");
        }


        
    }
    void Init()
    {

        Transform parent = mHudActorWin.mUIObject.transform;

        Object obj = parent.Find("DialogBubbleBgSprite").gameObject;
        GameObject newObj = (GameObject)GameObject.Instantiate(obj);
        newObj.transform.parent = parent;
        newObj.transform.localPosition = Vector3.zero;
        newObj.transform.localScale = new Vector3(1, 1, 0);
        newObj.SetActive(true);
        mDialogBubbleBgSprite = newObj.GetComponent<Image>();
        mTextLabel = newObj.transform.Find("TextLabel").GetComponent<Text>();
    }

    void LateUpdate()
    {

        if (isInit == false)
        {
            var basewin = UIManager.Instance.GetWindow("UIHudActorWindow");
            if (basewin != null)
            {
                mHudActorWin = basewin as UIHudActorWindow;
                isInit = true;
                Init();
            }
        }
        else
        {
            if (gameObject)
            {
                Camera mainCamera = xc.Game.Instance.MainCamera;
                Vector3 pos = mainCamera.WorldToScreenPoint(gameObject.transform.position + mOffset);
                pos.z = 0f;

                Camera uiCamera = xc.ui.ugui.UIMainCtrl.MainCam;
                Vector3 lblPos = uiCamera.ScreenToWorldPoint(pos);
                mDialogBubbleBgSprite.transform.position = lblPos;
            }
        }
        
    }

    void OnEnable()
    {
        if (mDialogBubbleBgSprite)
        {
            mDialogBubbleBgSprite.gameObject.SetActive(true);
        }
    }

    void OnDisable()
    {
        if (mDialogBubbleBgSprite)
        {
            mDialogBubbleBgSprite.gameObject.SetActive(false);
        }
    }

    void OnDestroy()
    {
        if (mDialogBubbleBgSprite)
        {
            GameObject.Destroy(mDialogBubbleBgSprite.gameObject);
            mDialogBubbleBgSprite = null;
        }
    }

    void Resize()
    {
        mDialogBubbleBgSprite.rectTransform.sizeDelta.Set(mDialogBubbleBgSprite.rectTransform.sizeDelta.x, mTextLabel.rectTransform.sizeDelta.y + 65);
    }

    /// <summary>
    /// 获取以及设置文本内容
    /// </summary>
    public string Text
    {
        get
        {
            if (mTextLabel)
            {
                return mTextLabel.text;
            }
            else
                return "";
        }
        set
        {
            if (mTextLabel)
            {
                mTextLabel.text = value;
                Resize();
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

    /// <summary>
    /// 获取以及设置对话框位置
    /// </summary>
    public Vector3 Position
    {
        get
        {
            if (mDialogBubbleBgSprite)
                return mDialogBubbleBgSprite.transform.position;
            else
                return Vector3.zero;
        }
        set
        {
            if (mDialogBubbleBgSprite)
                mDialogBubbleBgSprite.transform.position = value;
        }
    }
}
