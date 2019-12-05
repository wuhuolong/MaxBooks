//-----------------------------------
// File: LoadMaJiaImage.cs
// Desc: 参考 WWWLoadImage
// Author: luozhuocheng
// Date: 2018/12/26 15:32:19
//-----------------------------------


using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.UI;
using xc;
 
//送审后不需要还原的。直接代码加脚本。stream里面图片存在，则优先使用
//送审后需要还原的。采用双prefab处理。送审状态用送审prefab，非送审用原来



//[RequireComponent(typeof(RawImage))]
public class LoadMaJiaImage : MonoBehaviour
{
    public bool mIsNativeSize = true;
    public string mPath = "";
    private string mRealPath = "";
    private WWW mWWW;
    private Action mSuccessBack = null;
    private Action mFailBack = null;

    private Image mImage = null;
    private RawImage mRawImage = null;
    private State state = State.Raw;
    private enum State
    {
        Raw,Img
    }
    public RawImage GetRawImage()
    {
        return mRawImage;
    }

    public void SetCallBack(Action callback)
    {
        mSuccessBack += callback;
    }
    public void SetFailCallBack(Action callback)
    {
        mFailBack += callback;
    }

    private void SuccessHandle()
    {
        if (state == State.Raw)
        {
            SetImageActive(true, false);
        }
        else
        {
            SetImageActive(true, false);
        }
    }
    private void FailHandle()
    {
        if (state == State.Raw)
        {
            SetImageActive(true, false);
        }
        else
        {
            SetImageActive(false, true);
        }
    }

    void Start()
    {
        mSuccessBack += SuccessHandle;
        mFailBack += FailHandle;

        mImage = GetComponent<Image>();
        mRawImage = GetComponent<RawImage>();
        if (mRawImage == null)
        {
            state = State.Img;
            //mRawImage = gameObject.AddComponent<RawImage>();
            GameObject go = new GameObject();
            go.name = "RawImage";
            go.transform.SetParent(transform);
            mRawImage = go.AddComponent<RawImage>();
            RectTransform rectTran = go.GetComponent<RectTransform>();
            if (rectTran != null)
            {
                rectTran.localEulerAngles = Vector3.zero;
                rectTran.localScale = new Vector3(1, 1, 1);
                rectTran.anchorMin = new Vector2(0.5f, 0.5f);
                rectTran.anchorMax = new Vector2(0.5f, 0.5f);
                rectTran.pivot = new Vector2(0.5f, 0.5f);
                rectTran.anchoredPosition3D = new Vector3(0, 0, 0);
                //rectTran.offsetMin = new Vector2(0, 0);
                //rectTran.offsetMax = new Vector2(0, 0);
            }

        }
        else
        {
            state = State.Raw;
        }


        if (string.IsNullOrEmpty(mPath) == false)
        {
            mRealPath = Application.streamingAssetsPath + "/" + mPath;
            if (string.IsNullOrEmpty(mRealPath) == false)
            {
                if (File.Exists(mRealPath))
                {
                    StartCoroutine(LoadLocalImage(mRealPath));
                    SetImageActive(false, false);
                    return;
                }
            }
        }
        if (mFailBack != null)
            mFailBack();
     
        
        
    }

    void OnDestroy()
    {
        if (mWWW != null)
        {
            mWWW.Dispose();
            mWWW = null;
        }
    }


    //public void LoadImage(string path)
    //{
    //    if (string.IsNullOrEmpty(path) == false)
    //    {
    //        mPath = path;
    //        mRealPath = Application.streamingAssetsPath + "/" + mPath;
    //        LoadImage();
    //    }
    //}

    private void SetImageActive(bool raw,bool img)
    {
        if (mRawImage != null)
            mRawImage.enabled = raw;
        if (mImage != null)
            mImage.enabled = img;
    }
    
    private void LoadImage()
    {

    }

    private IEnumerator LoadLocalImage(string localPath)
    {
        string filePath = "file:///" + localPath;
        mWWW = new WWW(filePath);
        yield return mWWW;
        SetImage();
    }
     
    private bool SetImage()
    {

       

        if (mWWW == null)
        {
            if (mFailBack != null)
                mFailBack();
            return false;
        }

        Texture2D texture2D = mWWW.texture;
        if (texture2D == null)
        {
            if (mFailBack != null)
                mFailBack();
            return false;
        }
        // 销毁旧的资源
        int width = texture2D.width;
        int height = texture2D.height;
        DestroyImmediate(texture2D, true);

        // 重新创建RBGA16的贴图, 并禁用mipmap
        TextureFormat texture_format = TextureFormat.ARGB4444;

#if UNITY_ANDROID || UNITY_IPHONE
        texture_format = TextureFormat.RGBA4444;
#endif

        Texture2D newTexture2D = new Texture2D(width, height, texture_format, false);
        newTexture2D.LoadImage(mWWW.bytes);
        if (newTexture2D == null)
        {
            if (mFailBack != null)
                mFailBack();
            return false;
        }

        
        if (mRawImage == null)
        {
            if (mFailBack != null)
                mFailBack();
            return false;
        }


        mRawImage.texture = newTexture2D;

        if (mIsNativeSize)
            mRawImage.SetNativeSize();

        if (mSuccessBack != null)
            mSuccessBack();

        return true;
    }

}
