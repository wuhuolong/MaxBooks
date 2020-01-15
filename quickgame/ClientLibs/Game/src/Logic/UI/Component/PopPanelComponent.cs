using UnityEngine;
using System.Collections;
using System.Collections.Generic;
//用作焦点面板监听点击事件非作用于面板自身的控件(根据策划需求要求点击itemslot不关闭直接刷新面板so这个控件无法通用)
public class PopPanelComponent : MonoBehaviour
{
    UICamera mUICamera = null;
    List<UISprite> mFrameSpr = new List<UISprite>();
    public xc.ui.UIBaseWindow mWindow = null;
    public delegate void OnLostFoucs();
    public OnLostFoucs onLost;
    public bool IsFirst = true;
    private UIButton CloseBtn;
//    public <T> mType = null;
    // Use this for initialization
    void Start()
    {
    
    }

    void Awake()
    {
         if( xc.ui.UIManager.GetInstance().UIMain.MainCam != null)
        {
            mUICamera = xc.ui.UIManager.GetInstance().UIMain.MainCam.GetComponent<UICamera>();
        }
        if(CloseBtn != null)
            CloseBtn.gameObject.SetActive(false);
//        mFrameSpr = gameObject.GetComponent<UISprite>();    
    }

    public void AddSpr(UISprite spr)
    {
        mFrameSpr.Add(spr);
    }
    public void RemoveSpr(UISprite spr)
    {
        mFrameSpr.Remove(spr);
    }

    public void Init(UIButton closeBtn)
    {
        CloseBtn = closeBtn;
    }

    void OnClick()
    {
            
        UICamera.MouseOrTouch currentTouch = UICamera.currentTouch;
//        currentTouch.
        if(mWindow != null )
        {
            int frameCount = 0;
            foreach(var frame in mFrameSpr)
            {
                if(UICamera.selectedObject != frame.gameObject)
                    frameCount++;
            }
            if(mWindow.IsShow&&frameCount == mFrameSpr.Count)
            {
                if(mFrameSpr.Count != 0)
                {
//                    Vector3 panelScreenPos = xc.ui.UIManager.GetInstance().UIMain.MainCam.WorldToScreenPoint(mFrameSpr.transform.position);
                    int idx = 0;
                    foreach(var frameSpr in mFrameSpr)
                    {
                        Vector2 vec = NGUIMath.ScreenToPixels(currentTouch.pos , frameSpr.transform);
                        float minx =  - frameSpr.width /2;
                        float miny =  - frameSpr.height /2;
                        float maxx = + frameSpr.width/2;
                        float maxy = + frameSpr.height /2;
                        if(vec.x < minx|| vec.x > maxx || vec.y < miny || vec.y > maxy)
                        {
                            var item = UICamera.selectedObject.GetComponent<xc.ui.UIItemSlot>();
                            if(item == null)
                            {
                                idx ++;
                            }
                            else if(item.ItemInfo == null)
                            {
                                idx ++;
                            }  
                        }
                    }  
                    if(idx == mFrameSpr.Count && onLost != null)
                        onLost();
                }
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        if(mUICamera != null&&enabled == true)
        {
            if(UICamera.genericEventHandler != gameObject)
            {
                if(CloseBtn != null&&CloseBtn.gameObject.activeSelf == false)
                    CloseBtn.gameObject.SetActive(true);
            }
        }
    }

    void OnEnable ()
    {
        if(mUICamera != null)
        {
            UICamera.genericEventHandler = gameObject;
            if(CloseBtn != null)
                CloseBtn.gameObject.SetActive(false);
        }
        else
        {
            if(CloseBtn != null)
                CloseBtn.gameObject.SetActive(true);
        }
    }

    void OnDisable ()
    {
        if(mUICamera != null)
        {
            IsFirst = true;
            if(UICamera.genericEventHandler == gameObject)
                UICamera.genericEventHandler = null;
        }
    }
}

