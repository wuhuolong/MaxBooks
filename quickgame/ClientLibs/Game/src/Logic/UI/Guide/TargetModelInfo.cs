//---------------------------------------
// File: TargetModelInfo.cs
// Desc: 用于因为异步加载问题导致在引导时未出现模型的情况(ps. 要求挂载改脚本的transform没有子节点)
// Author: raorui
// Date: 2018.6.19
//---------------------------------------
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SGameEngine;

public class TargetModelInfo : MonoBehaviour
{
    public string ResPath = ""; // 模型路径
    public string ModelAction = ""; // 模型动作
    public Vector3 LocalPos;
    public Vector3 LocalScale;
    public Vector3 LocalEuler;

    /// <summary>
    /// 是否已经开始模型的加载
    /// </summary>
    bool mIsStart = false;

    bool mIsDestroy = false;

    Transform mCacheTrans;
    AssetResource mAssetRes;

    void Awake()
    {
        mCacheTrans = transform;
    }

    /// <summary>
    /// 开始加载模型
    /// </summary>
    public void StartLoadModel()
    {
        if (mCacheTrans.childCount != 0)
        {
            // 动作
            Animator ani = GetComponentInChildren<Animator>();
            if (null != ani && !string.IsNullOrEmpty(ModelAction))
                ani.Play(ModelAction);

            return;
        }

        if (mIsStart)
            return;

        if(string.IsNullOrEmpty(ResPath))
            return;

        mIsStart = true;

        xc.MainGame.HeartBehavior.StartCoroutine(LoadModel());
    }

    void OnDestroy()
    {
        mIsDestroy = true;

        if (mAssetRes != null)
        {
            mAssetRes.destroy();
            mAssetRes = null;
        }
    }

    public void SetModelInfo(string res_path,Vector3 local_pos, Vector3 local_scale, Vector3 local_euler, string modelAction = "")
    {
        ResPath = res_path;
        LocalPos = local_pos;
        LocalScale = local_scale;
        LocalEuler = local_euler;
        mIsStart = false;
        ModelAction = modelAction;
    }

    /// <summary>
    /// 根据参数来加载模型
    /// </summary>
    /// <returns></returns>
    IEnumerator LoadModel()
    {
        if(mAssetRes != null)
        {
            mAssetRes.destroy();
        }

        mAssetRes = new AssetResource();
        yield return ResourceLoader.Instance.load_asset(ResPath, typeof(GameObject), mAssetRes);

        if (mIsDestroy)
            yield break;

        if (mAssetRes.asset_ == null)
            yield break;

        var game_object = GameObject.Instantiate(mAssetRes.asset_) as GameObject;
        var trans = game_object.transform;
        trans.SetParent(mCacheTrans, false);

        trans.localPosition = LocalPos;
        trans.localScale = LocalScale;
        trans.localEulerAngles = LocalEuler;

        // 动作
        Animator ani = game_object.GetComponent<Animator>();
        if (null != ani && !string.IsNullOrEmpty(ModelAction))
            ani.Play(ModelAction);

        xc.ui.ugui.UIHelper.SetLayer(trans, LayerMask.NameToLayer("UI"));
    }
}