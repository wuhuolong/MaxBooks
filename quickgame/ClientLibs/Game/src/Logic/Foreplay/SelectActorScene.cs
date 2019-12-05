using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using Net;
using xc;
using xc.protocol;
using xc.ui;

[wxb.Hotfix]
public class SelectActorScene : MonoBehaviour
{
    /// <summary>
    /// 创建好的Actor挂载的总节点
    /// </summary>
    public Transform ActorPos { get; set; }

    /// <summary>
    /// 待机动作
    /// </summary>
    private const string IDLE_ANIMATION = "loadidle";

    public static SelectActorScene Instance;

    void Awake()
    {
        Instance = this;
        ActorPos = transform;

        // 查找主光源
        Vector3 light_dir = new Vector3(0, -1, -1);
        var shadow_light_info = GetComponent<ShadowLightInfo>();
        if (shadow_light_info != null)
            light_dir = shadow_light_info.LightDir;
        ShadowManager.Instance.SetRealShadow(ActorPos, light_dir, 1 << LayerMask.NameToLayer("UIPreview"));
    }

    private void OnDestroy()
    {
        Instance = null;
    }

    public GameObject PreviewObject
    {
        get { return mPreviewObj; }
        set
        {
            mPreviewObj = value;
            mPreviewObj.transform.localRotation = Quaternion.identity; // 重置旋转

            // 播放待机
            PlayAnimation(IDLE_ANIMATION, mPreviewObj);
        }
    }

    /// <summary>
    /// 当前的主相机
    /// </summary>
    private Camera m_Camera;

    /// <summary>
    /// 当前显示的GameObject
    /// </summary>
    private GameObject mPreviewObj;

    /// <summary>
    /// 是否已经开始拖拽
    /// </summary>
    private bool mStartDrag = false;

   /// <summary>
   /// 开始拖拽的位置
   /// </summary>
    private Vector3 mStartPos = new Vector3(0, 0, 0);

    /// <summary>
    /// 播放动画
    /// </summary>
    /// <param name="anim"></param>
    /// <param name="go"></param>
    void PlayAnimation(string anim, GameObject go)
    {
        if (go == null)
            return;

        AnimationController ac = go.GetComponentInChildren<AnimationController>();
        if (ac != null)
        {
            ac.CullMode = AnimatorCullingMode.AlwaysAnimate;
            ac.PlayAnimation(anim);
        }
    }

    /// <summary>
    /// 播放动画
    /// </summary>
    /// <param name="anim"></param>
    /// <param name="go"></param>
    void CrossAnimation(string anim, GameObject go)
    {
        if (go == null)
            return;

        AnimationController ac = go.GetComponentInChildren<AnimationController>();
        if (ac != null)
        {
            ac.CullMode = AnimatorCullingMode.AlwaysAnimate;
            ac.CrossfadeAnimation(anim, 0.1f);
        }
    }

    /// <summary>
    /// 正在播放动画
    /// </summary>
    /// <param name="anim"></param>
    /// <param name="go"></param>
    /// <returns></returns>
    static public bool IsPlayingAnimation(string anim, GameObject go)
    {
        if (go == null)
            return false;

        AnimationController ac = go.GetComponentInChildren<AnimationController>();
        if (ac != null)
        {
            ac.CullMode = AnimatorCullingMode.AlwaysAnimate;
            return ac.IsPlaying(anim);
        }
        return false;
    }

    /// <summary>
    /// 更新动画的播放
    /// </summary>
    void UpdateAnimation()
    {
        if (mPreviewObj == null)
            return;

        if(IsPlayingAnimation(IDLE_ANIMATION, mPreviewObj) == false)
        {
            CrossAnimation(IDLE_ANIMATION, mPreviewObj);
        }
    }

    /// <summary>
    /// 更新角色的旋转
    /// </summary>
    void UpdateRotation()
    {
        if (mPreviewObj == null)
            return;

        if (m_Camera == null)
            m_Camera = Camera.main;

        if (m_Camera == null)
            return;

        if (Input.GetMouseButton(0))
        {
            if (!mStartDrag)
            {
                int layerMask = 1 << LayerMask.NameToLayer("UIPreview");
                Vector3 screenPos;
                Ray ray;

                screenPos = Input.mousePosition;
                ray = m_Camera.ScreenPointToRay(screenPos);
                RaycastHit hit;
                if (Physics.Raycast(ray, out hit, 100.0f, layerMask))
                {
                    mStartDrag = true;
                    mStartPos = Input.mousePosition;
                }
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

            mPreviewObj.transform.Rotate(Vector3.up, angle);

            mStartPos = Input.mousePosition;
        }
    }

    void LateUpdate()
    {
        UpdateAnimation();
        UpdateRotation();
    }
}