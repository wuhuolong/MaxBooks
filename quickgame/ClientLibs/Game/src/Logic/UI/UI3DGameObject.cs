/*----------------------------------------------------------------
// 文件名： UI3DGameObject.cs
// 文件功能描述： 挂接在3D对象上的物体组件
//----------------------------------------------------------------*/
using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using xc.ui.ugui;

[wxb.Hotfix]
public class UI3DGameObject : UI3DWidget
{
    public new class StyleInfo : UI3DWidget.StyleInfo
    {
        public string PrefabPath = "";
    }

    public void ResetStyleInfo(StyleInfo info)
    {
        base.ResetStyleInfo(info);

        PrefabPath = info.PrefabPath;
    }

	string mPrefabPath;
    GameObject mParentGameObject;
    GameObject mEffectGameObject;

    bool mIsDestory = false;

    void OnDestroy()
    {
        mIsDestory = true;

        if (mEffectGameObject != null)
        {
            GameObject.DestroyImmediate(mEffectGameObject);
            mEffectGameObject = null;
        }
    }

    protected override void Init()
    {
        base.Init();

        mParentGameObject = mTrans.Find("ParentGameObject").gameObject;
    }

    protected override string RootName
    {
        get
        {
            return "3DGameObject";
        }
    }

    public string PrefabPath
    {
		set
		{
            mPrefabPath = value;

            if (mEffectGameObject != null)
            {
                GameObject.Destroy(mEffectGameObject);
                mEffectGameObject = null;
            }

            SGameEngine.ResourceLoader.Instance.StartCoroutine(LoadEffect(mPrefabPath));
        }
	}

    IEnumerator LoadEffect(string path)
    {
        if (gameObject == null || this == null)
        {
            yield return null;
        }

        SGameEngine.PrefabResource prefab = new SGameEngine.PrefabResource();

        yield return SGameEngine.ResourceLoader.Instance.StartCoroutine(SGameEngine.ResourceLoader.Instance.load_prefab(path, prefab));

        if (mIsDestory == true)
        {
            if (prefab != null && prefab.obj_ != null)
            {
                GameObject.DestroyImmediate(prefab.obj_);
            }
            yield return null;
        }

        if (mParentGameObject == null)
        {
            GameDebug.LogError("Load UI3DGameObject error, parent GameObject is null!!!");
            GameObject.DestroyImmediate(prefab.obj_);
            yield return null;
        }

        if (mIsDestory == false && prefab != null && prefab.obj_ != null)
        {
            try
            {
                mEffectGameObject = prefab.obj_;
                mEffectGameObject.transform.SetParent(mParentGameObject.transform);
                mEffectGameObject.transform.localScale = Vector3.one;
                mEffectGameObject.transform.localPosition = Vector3.zero;
                mEffectGameObject.transform.localRotation = Quaternion.identity;
            }
            catch (System.Exception e)
            {
                throw;
            }
        }
    }
}
