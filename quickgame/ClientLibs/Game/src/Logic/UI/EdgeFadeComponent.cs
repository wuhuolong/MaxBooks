//--------------------------------------------
// File: EdgeFadeComponent.cs
// Desc: 用来控制预览贴图位置偏移的组件(非默认参数的时候需要实例化新的材质)
// Author: raorui 重构
// Date: 2018.10.29
//--------------------------------------------
using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(RawImage))]
public class EdgeFadeComponent : MonoBehaviour
{
    /// <summary>
    /// 当前RawImage的Size数值
    /// </summary>
    Vector2 mTiling = Vector2.one;

    /// <summary>
    /// 当前RawImage的Offset数值
    /// </summary>
    Vector2 mOffset = Vector2.zero;

    RawImage mRawImage;
    Material mTextureMaterial;
    Vector2 mLastTiling = Vector2.zero;
    Vector2 mLastOffset = Vector2.zero;
    bool mInited = false;

    /// <summary>
    /// 实例化的新材质
    /// </summary>
    Material mInstanceMat = null;

    private void Awake()
    {
        Init();
    }

    private void OnEnable()
    {
        Init();

        if (mRawImage != null)
        {
            mTextureMaterial = mRawImage.material; // 保存原始材质
            mTiling = new Vector2(mRawImage.uvRect.width, mRawImage.uvRect.height);
            mOffset = new Vector2(mRawImage.uvRect.x, mRawImage.uvRect.y);

            RefreshSize();
        }
    }

    /// <summary>
    /// 进行获取组件的初始化
    /// </summary>
    private void Init()
    {
        if (mInited)
            return;

        if (mRawImage == null)
            mRawImage = GetComponent<RawImage>();

        if (mRawImage != null)
            mInited = true;
    }

    private void RefreshSize()
    {
        if (mRawImage == null || mTextureMaterial == null)
        {
            return;
        }

        if (mLastTiling == mTiling && mLastOffset == mOffset)
        {
            return;
        }

        mLastTiling = mTiling;
        mLastOffset = mOffset;

        // 默认参数
        if (mTiling == Vector2.one && mOffset == Vector2.zero)
        {
            // 使用默认材质
            var curMat = mRawImage.material;
            if (curMat != mTextureMaterial)
            {
                mRawImage.material = mTextureMaterial;
                GameObject.Destroy(curMat);
            }
                
        }
        // 非默认参数，需要实例化新材质
        else
        {
            if(mInstanceMat == null)
            {
                mInstanceMat = GameObject.Instantiate(mTextureMaterial) as Material;
                mRawImage.material = mInstanceMat;
            }
           
            mRawImage.material.SetVector("_MainTex_ST", new Vector4(mTiling.x, mTiling.y, mOffset.x, mOffset.y));
        }
    }

    private void OnDestroy()
    {
        if(mInstanceMat != null)
        {
            GameObject.Destroy(mInstanceMat);
            mInstanceMat = null;
        }

        mTextureMaterial = null;
    }
}