using System.Collections.Generic;
using System.Linq;
using System.Text;

using UnityEngine;
using System.Collections;

/*----------------------------------------------------------------
// 文件名： UI3DComponent.cs
// 文件功能描述： 挂接在3D对象上的通用UI组件，用于将UI元素对齐到3D对象上
// @author hzb
//----------------------------------------------------------------*/
[wxb.Hotfix]
public class UI3DComponent : MonoBehaviour
{
    /// <summary>
    /// 以同步的方式，绑定3D对象（宿主）与2D对象（可以是prefab）的实例化对象
    /// </summary>
    /// <param name="owner">3D对象</param>
    /// <param name="obj">2D对象</param>
    /// <param name="resultInstance">实例化的2D对象</param>
    /// <returns>UI3DComponent</returns>
    public static UI3DComponent Bind(GameObject owner, Object obj, out GameObject resultInstance)
    {
        var basewin = xc.ui.ugui.UIManager.Instance.GetWindow("UIHudActorWindow");
        if (basewin == null)
        {
            resultInstance = null;
            return null;
        }
        GameObject uiRoot = basewin.mUIObject;
        Transform parent = uiRoot.transform.Find("UI3DGameObject");

        GameObject go = (GameObject)GameObject.Instantiate(obj);
        go.transform.parent = parent;
        go.transform.localPosition = Vector3.zero;
        go.transform.localScale = Vector3.one;
        go.SetActive(true);
        resultInstance = go;

        UI3DComponent comp = owner.AddComponent<UI3DComponent>();
        comp.mTrans = go.transform;
        comp.mFollow = owner.transform;         //默认跟随owner.transform

        return comp;
    }

    Transform mFollow;
    Transform mTrans;

    Vector3 mOffset2D = Vector3.zero;
    Vector3 mOffset3D = Vector3.zero;

    /// <summary>
    /// 3D对象的Transform
    /// </summary>
    public Transform Follow
    {
        get { return mFollow; }
    }

    /// <summary>
    /// 2D对象的Transform
    /// </summary>
    public Transform Trans
    {
        get { return mTrans; }
    }

    public Vector3 Offset2D { get { return mOffset2D; } }
    public Vector3 Offset3D { get { return mOffset3D; } }

    public UI3DComponent SetOffset2D(Vector3 v)
    {
        this.mOffset2D = v;
        return this;
    }

    public UI3DComponent SetOffset3D(Vector3 v)
    {
        this.mOffset3D = v;
        return this;
    }


    void Awake()
    {
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

    void LateUpdate()
    {
        UpdatePosition();
    }

    public void UpdatePosition()
    {
        if (mFollow == null)
            return;

        Camera mainCamera = xc.Game.Instance.MainCamera;
        if (mainCamera == null)
        {
            return;
        }

        Vector3 pos = mainCamera.WorldToScreenPoint(mFollow.position + mOffset3D);
        pos.z = 0f;

        if (mTrans != null)
        {
            Camera uiCamera = xc.ui.ugui.UIMainCtrl.MainCam;
            Vector3 lblPos = uiCamera.ScreenToWorldPoint(pos);
            mTrans.position = lblPos;
            if (mOffset2D.Equals(Vector3.zero) == false)
            {
                Vector3 localPos = mTrans.localPosition;
                mTrans.localPosition = localPos + mOffset2D;
            }
        }

    }
}