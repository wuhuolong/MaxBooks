//--------------------------------------------------------
// File  :  UIBuffUpdate.cs
// Desc  :  Buff的时间和状态的显示和更新
// Author:  raorui 重构
// Date  ： 2018.1.3
//--------------------------------------------------------
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using xc;
using SGameEngine;

[wxb.Hotfix]
public class UIBuffUpdate : MonoBehaviour
{
    // buff显示的最大数量
    int mBuffMaxCount = 5;

    // buff显示的控件
    class BuffWidget
    {
        public GameObject WidgetObject = null;
        public RawImage BuffImage = null;
        public uint LoadingId = 0;
    }

    BuffWidget[] mBuffWidgets = null;
    Transform mTrans;

    // 缓存上一次存在的buff表id，如果发生变化，才需要重新加载buff贴图
    List<uint> mBuffIds;

    static uint mLoadingId = 1;
    Dictionary<uint, AssetResource> mLoadedAssetRes = new Dictionary<uint, AssetResource>();

    RectTransform mRectTrans;

    private Actor mTargetActor;
    public Actor TargetActor
    {
        set
        {
            if (mTargetActor != null)
            {
                mTargetActor.UnsubscribeActorEvent(Actor.ActorEvent.BEFORE_ACTOR_DESTROY, BeforeActorDestroy);
            }
            mTargetActor = value;
            if (mTargetActor != null)
            {
                mTargetActor.SubscribeActorEvent(Actor.ActorEvent.BEFORE_ACTOR_DESTROY, BeforeActorDestroy);
            }
        }
        get
        {
            return mTargetActor;
        }
    }

    private void BeforeActorDestroy(CEventBaseArgs args)
    {
        if (mTargetActor != null)
        {
            mTargetActor.UnsubscribeActorEvent(Actor.ActorEvent.BEFORE_ACTOR_DESTROY, BeforeActorDestroy);
            TargetActor = null;
        }
    }

    public void Awake()
    {
        mTrans = transform;
        mRectTrans = GetComponent<RectTransform>();

        // 通过配置获取可显示的最大buff数量
        mBuffMaxCount = GameConstHelper.GetInt("GAME_BUFF_MAX_COUNT");
        if (mBuffMaxCount == 0)
            mBuffMaxCount = 5;

        mBuffWidgets = new BuffWidget[mBuffMaxCount];

        // 获取所有buff显示的控件
        for (int i = 0; i < mBuffMaxCount; ++i)
        {
            Transform trans = mTrans.Find(string.Format("Buff{0}", i));

            var buffWidget = new BuffWidget();
            buffWidget.WidgetObject = trans.gameObject;
            buffWidget.BuffImage = trans.Find("BuffTex").GetComponent<RawImage>();

            mBuffWidgets[i] = buffWidget;
        }

        mBuffIds = new List<uint>();
    }

    public void Update()
    {
        if (TargetActor == null)
            TargetActor = Game.Instance.GetLocalPlayer();

        if (TargetActor != null)
        {
            var allBuffs = TargetActor.BuffCtrl.AllBuffs;// 获取主角身上所有的buff数据

            bool buff_list_change = false;// buff的列表是否发生了变化
            

            var idList = SGameEngine.Pool<uint>.List.New(allBuffs.Count);
            using (var enumerator = allBuffs.GetEnumerator())
            {
                while(enumerator.MoveNext())
                {
                    var cur = enumerator.Current;
                    var buffId = cur.Key;
                    idList.Add(buffId);
                }
            }

            idList.Sort();
            int i = 0;
            foreach (var buffId in idList)
            {
                if (i >= mBuffMaxCount)
                    continue;

                // 获取buff对象的icon
                var buff = allBuffs[buffId];
                if (string.IsNullOrEmpty(buff.OwnBuffInfo.icon))
                    continue;

                // 当上次缓存的id与本次不同时，重设buff图标
                if (i >= mBuffIds.Count || mBuffIds[i] != buffId)
                {
                    // 取消之前的loading/销毁资源
                    var loadingId = mBuffWidgets[i].LoadingId;
                    if (loadingId != 0)
                    {
                        AssetResource loadRes = null;
                        if (mLoadedAssetRes.TryGetValue(loadingId, out loadRes))
                        {
                            if (loadRes != null)
                            {
                                loadRes.destroy();
                                loadRes = null;
                            }
                            mLoadedAssetRes.Remove(loadingId);
                        }
                    }

                    // 获取新的loadingid
                    if (mLoadingId == 0)
                        mLoadingId++;
                    mBuffWidgets[i].LoadingId = mLoadingId;

                    string iconPath = string.Format("{0}/{1}.png", GlobalConst.BuffIconFolder, buff.OwnBuffInfo.icon);
                    var assetRes = new AssetResource();
                    mLoadedAssetRes[mLoadingId] = null;
                    MainGame.HeartBehavior.StartCoroutine(LoadBuffIcon(mBuffWidgets[i].BuffImage, assetRes, iconPath, mLoadingId));

                    mLoadingId++;
                    buff_list_change = true;
                }

                CommonTool.SetActive(mBuffWidgets[i].WidgetObject, true);
                i++;
            }
            SGameEngine.Pool<uint>.List.Free(idList);

            // 数量不同的时候即表示buff列表发生了变化
            if (i != mBuffIds.Count)
                buff_list_change = true;

            // 隐藏没有buff数据的ui
            for (; i < mBuffMaxCount; ++i)
            {
                CommonTool.SetActive(mBuffWidgets[i].WidgetObject, false);

                // 取消之前的loading/销毁资源
                RemoveLoadingId(mBuffWidgets[i].LoadingId);
                mBuffWidgets[i].LoadingId = 0;
            }

            // 获取最新的buffid列表
            mBuffIds.Clear();
            using (var enumerator = allBuffs.GetEnumerator())
            {
                while(enumerator.MoveNext())
                {
                    var cur = enumerator.Current;
                    var buff = cur.Value;
                    if (!string.IsNullOrEmpty(buff.OwnBuffInfo.icon))// 只取出没有叠加的进行显示
                        mBuffIds.Add(cur.Key);
                }
            }
            mBuffIds.Sort();

            if (buff_list_change)
            {
                // 因为ui动画的问题，需要重新设置layout
                LayoutRebuilder.ForceRebuildLayoutImmediate(mRectTrans);
                ClientEventMgr.Instance.FireEvent((int)ClientEvent.CE_BUFF_LIST_CHANGE, new CEventBaseArgs(TargetActor));
            }
        }
        else
        {
            // 隐藏没有buff数据的ui
            for (int i = 0; i < mBuffMaxCount; ++i)
            {
                CommonTool.SetActive(mBuffWidgets[i].WidgetObject, false);

                RemoveLoadingId(mBuffWidgets[i].LoadingId);
                mBuffWidgets[i].LoadingId = 0;
            }

            // 清除缓存数据
            mBuffIds.Clear();
        }
    }

    /// <summary>
    /// 加载icon
    /// </summary>
    /// <param name="image"></param>
    /// <param name="assetRes"></param>
    /// <param name="path"></param>
    /// <param name="loadingId"></param>
    /// <returns></returns>
    IEnumerator LoadBuffIcon(RawImage image, AssetResource assetRes, string path, uint loadingId)
    {
        //yield return new WaitForSeconds(0.5f);
        yield return MainGame.HeartBehavior.StartCoroutine(SGameEngine.ResourceLoader.Instance.load_asset(path, typeof(UnityEngine.Object), assetRes));

        // 检查加载的资源是否正常
        var assetObject = assetRes.asset_;
        if (assetObject == null)
        {
            mLoadedAssetRes.Remove(loadingId);
            yield break;
        }

        // 检查组件和image等是否已经销毁
        Texture buffTex = assetObject as Texture;
        if (mIsDestroy || image == null || buffTex == null)
        {
            mLoadedAssetRes.Remove(loadingId);
            assetRes.destroy();
            yield break;
        }

        // 检查待加载字典中是否存在loadingid
        if(mLoadedAssetRes.ContainsKey(loadingId))
        {
            mLoadedAssetRes[loadingId] = assetRes;
            image.texture = buffTex;
            image.color = Color.white;
        }
        else
        {
            assetRes.destroy();
        }
    }

    /// <summary>
    /// 取消之前的loading/销毁资源
    /// </summary>
    /// <param name="loadingId"></param>
    void RemoveLoadingId(uint loadingId)
    {
        if (loadingId != 0)
        {
            AssetResource loadRes = null;
            if (mLoadedAssetRes.TryGetValue(loadingId, out loadRes))
            {
                if (loadRes != null)
                {
                    loadRes.destroy();
                    loadRes = null;
                }
                mLoadedAssetRes.Remove(loadingId);
            }
        }
    }

    bool mIsDestroy = false;

    public void OnDestroy()
    {
        TargetActor = null;
        mIsDestroy = true;

        // 清除buff信息列表
        for (int i = 0; i < mBuffWidgets.Length; ++i)
        {
            var buffWidget = mBuffWidgets[i];
            buffWidget.WidgetObject = null;
            buffWidget.BuffImage = null;
        }
        mBuffWidgets = null;

        // 清除buff资源
        using (var enumerator = mLoadedAssetRes.GetEnumerator())
        {
            while(enumerator.MoveNext())
            {
                var cur = enumerator.Current;
                var assetRes = cur.Value;
                if(assetRes != null)
                {
                    assetRes.destroy();
                    assetRes = null;
                }
            }
        }
        mLoadedAssetRes.Clear();

        // 清除buffid列表
        mBuffIds.Clear();
    }
}