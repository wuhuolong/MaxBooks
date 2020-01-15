
//----------------------------------------------
// File: UIPreviewModel.cs
// Desc: 在2D图片上显示3D模型的组件,挂载到界面window上去
// Author: xusong 
// Date: 2018.6.4
//----------------------------------------------
using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;

[wxb.Hotfix]
public class UIPreviewModel : MonoBehaviour
{
    #region 外部变量

//     /// <summary>
//     /// 挂载RawImage组件的物体
//     /// </summary>
//     public GameObject TargetObject;

    /// <summary>
    /// 预览的3D模型
    /// </summary>
    public GameObject mGameObject = null;

//     /// <summary>
//     /// 3D模型的父节点的localPosition
//     /// </summary>
//     public Vector3 ModelParentLocalPos = new Vector3(0, 0, 0);

    /// <summary>
    /// 3D模型的旋转角度
    /// </summary>
    public Vector3 ModelLocalEulerAngles = new Vector3(0, 0, 0);

    /// <summary>
    /// 3D模型的localPosition
    /// </summary>
    public Vector3 ModelLocalPosition = new Vector3(0, 0, 0);

    /// <summary>
    /// 3D模型的localPosition
    /// </summary>
    public Vector3 ModelLocalScale = new Vector3(1, 1, 1);

    //     /// <summary>
    //     /// 3D模型的父节点的角度
    //     /// </summary>
    public Vector3 ModelParentLocalEulerAngles = new Vector3(0, 0, 0);

    //     /// <summary>
    //     /// 3D模型的父节点的localPosition
    //     /// </summary>
    public Vector3 ModelParentLocalPos = new Vector3(0, 0, 0);


    //     /// <summary>
    //     /// 是否只处理触摸到当前预览图片上的拖拽(以避免在二级界面上拖拽UI控件时旋转预览模型)
    //     /// </summary>
    //     public bool m_CheckUI = false;

    /// <summary>
    /// 触摸修正的点击区域
    /// </summary>
    public RectTransform m_FixedTouchTransform = null;
    #endregion

    #region 内部变量

    RenderqueueComponent mRenderqueueCom = null;

    bool mEffectSetVisiable = true;
    int mOldAddPanelOrder = 0;
    /// <summary>
    /// 缓存的Transform
    /// </summary>
    Transform mCacheTrans;

//     /// <summary>
//     /// 相机组件
//     /// </summary>
//     Camera mCamera;

//     /// <summary>
//     /// 创建的UIPreviewWindow组件
//     /// </summary>
//     UIPreviewWindow mPreviewWindow;

    /// <summary>
    /// 是否进行了初始化
    /// </summary>
    bool mInited = false;

//     /// <summary>
//     /// 对应GameObject的实例ID
//     /// </summary>
//     int mInstId = 0;

    /// <summary>
    /// 下次更新的时间
    /// </summary>
    float mUpdateNextTime = 0;


    public bool CanRotate = true;
    bool mStartDrag = false;
    Vector3 mStartPos = new Vector3(0, 0, 0);

    #endregion

    #region 属性访问器



    #endregion

    #region 引擎接口函数
    void Awake()
    {
        Init();
    }

    void OnEnable()
    {
    }

    void OnDisable()
    {

    }

    int mUIPreviewLayer = -1;
    int mHideLayer = -1;

    void Update()
    {
        if (mGameObject != null)
        {
            // 因为资源的异步加载问题，需要定时更新模型的层级
            float cur_time = Time.time;
            if (cur_time > mUpdateNextTime)
            {
                mUpdateNextTime = cur_time + 1.0f;
                Renderer[] rds = mGameObject.transform.GetComponentsInChildren<Renderer>();
                for (int i = 0; i < rds.GetLength(0); ++i)
                {
                    var game_object = rds[i].gameObject;

                    // hide层级不进行设置
                    if (game_object.layer != mHideLayer)
                        game_object.layer = mUIPreviewLayer;
                }
            }

            UpdateRotate();
        }
    }
    
    void UpdateRotate()
    {


        if (CanRotate)
        {
            if (Input.GetMouseButton(0) && mGameObject != null && m_FixedTouchTransform != null && UIInputEvent.TouchedUI(m_FixedTouchTransform.gameObject))
            {
                if (!mStartDrag)
                {
                    mStartDrag = true;
                    mStartPos = Input.mousePosition;
                }
            }
            else if (mStartDrag)
            {
                mStartDrag = false;
            }

            if (mStartDrag)
            {
                float angle = mStartPos.x - Input.mousePosition.x;
                angle *= 0.6f;

                mCacheTrans.transform.Rotate(Vector3.up, angle);

                mStartPos = Input.mousePosition;
            }
        }
    }
    #endregion

    /// <summary>
    /// 进行初始化
    /// </summary>
    void Init()
    {
        if (mInited)
            return;

        mInited = true;

        mUIPreviewLayer = LayerMask.NameToLayer("UI");
        mHideLayer = LayerMask.NameToLayer("Hide");
        GameObject cache = new GameObject();
        cache.transform.parent = transform;
        cache.transform.localScale = Vector3.one;
        cache.transform.localPosition = Vector3.zero;
        cache.transform.localEulerAngles = Vector3.zero;
        mCacheTrans = cache.transform;

        mRenderqueueCom = transform.GetComponent<RenderqueueComponent>();
    }

    /// <summary>
    /// 设置预览的3D模型
    /// </summary>
    /// <param name="go"></param>
    public void SetGameObject(GameObject go)
    {
        if (go == null)
        {
            Debug.LogError("UIPreviewModel::SetGameObject error,gameobject go is null!");
            return;
        }

        Init();

        if (mGameObject != null)
        {
            Debug.LogError("UIPreviewModel::SetGameObject, old gameObject is not destroyed");
        }

        // 设置模型的位置和旋转
        mGameObject = go;
        mGameObject.transform.parent = mCacheTrans;
        mGameObject.transform.localScale = ModelLocalScale;
        mGameObject.transform.localPosition = ModelLocalPosition;
        mGameObject.transform.localEulerAngles = ModelLocalEulerAngles;
        mCacheTrans.transform.localEulerAngles = ModelParentLocalEulerAngles;
        mCacheTrans.transform.localPosition = ModelParentLocalPos;

        // 设置模型的layer
        mGameObject.layer = mUIPreviewLayer;
        Renderer[] rds = mGameObject.transform.GetComponentsInChildren<Renderer>();
        foreach (Renderer rd in rds)
        {
            var game_object = rd.gameObject;
            if (game_object.layer != mHideLayer)
                game_object.layer = mUIPreviewLayer;
        }


        // 根据模型设置不同的预览灯光
        AssemblyBridge.Instance.ComponentEmployer.UpdatePreviewLight(mGameObject);

        UpdateQueue();
    }

    public void UpdateQueue()
    {
        if(mRenderqueueCom != null)
        {
            mRenderqueueCom.LastIncreaseOrder = -1;
        }
    }

    public void SetEffectVisiable(bool is_visiable)
    {
        if(mEffectSetVisiable == is_visiable)
        {
            return;
        }
        if (mRenderqueueCom != null)
        {
            if (mEffectSetVisiable && is_visiable == false)
            {
                mOldAddPanelOrder = mRenderqueueCom.AddPanelOrder;
            }
            mRenderqueueCom.LastIncreaseOrder = -1;
            if (is_visiable)
                mRenderqueueCom.AddPanelOrder = mOldAddPanelOrder;
            else
                mRenderqueueCom.AddPanelOrder = -100;
            Renderer[] renders = GetComponentsInChildren<Renderer>(true);
            foreach (Renderer render in renders)
            {
                render.enabled = is_visiable;
            }
        }
        mEffectSetVisiable = is_visiable;
    }

    /// <summary>
    /// 销毁操作
    /// </summary>
    public void Destroy()
    {
        mGameObject = null;
    }
}

