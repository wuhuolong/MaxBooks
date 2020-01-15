//--------------------------------------------
// File: BuffImageLoader.cs
// Author: raorui
// Desc: buff列表中用来加载buff图标和控制资源生命周期的组件
// Date: 2018.12.13
//--------------------------------------------
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using SGameEngine;

namespace xc
{
    public class BuffImageLoader
    {
        static BuffImageLoader mInstance;
        public static BuffImageLoader Instance
        {
            get
            {
                if (mInstance == null)
                    mInstance = new BuffImageLoader();

                return mInstance;
            }
        }

        static uint sLoadingId = 0;
        Dictionary<int, uint> mLoadingIDs = new Dictionary<int, uint>();// instid->loadingid
        Dictionary<uint, AssetResource> mLoadedAssetRes = new Dictionary<uint, AssetResource>(); //loadingid->assetresource

        /// <summary>
        /// 在指定的Image上加载assetPath的贴图并赋值
        /// </summary>
        /// <param name="image"></param>
        /// <param name="assetPath"></param>
        public void LoadBuffIcon(RawImage image, string assetPath)
        {
            if (image == null)
                return;

            // 获取RawImage的InstanceID
            int instId = image.GetInstanceID();

            // 取消之前的loading/销毁资源
            uint loadingId = 0;
            mLoadingIDs.TryGetValue(instId, out loadingId);
            RemoveLoadingId(loadingId);

            // 获取新的loadingid
            if (sLoadingId == 0)
                sLoadingId++;
            mLoadingIDs[instId] = sLoadingId;
            mLoadedAssetRes[sLoadingId] = null;

            // 开启新的加载
            MainGame.HeartBehavior.StartCoroutine(LoadTexture(image, assetPath, sLoadingId));

            sLoadingId++;
        }

        /// <summary>
        /// 销毁所有的buff资源
        /// </summary>
        public void Destroy()
        {
            mLoadingIDs.Clear();

            // 清除buff资源
            using (var enumerator = mLoadedAssetRes.GetEnumerator())
            {
                while (enumerator.MoveNext())
                {
                    var cur = enumerator.Current;
                    var assetRes = cur.Value;
                    if (assetRes != null)
                    {
                        assetRes.destroy();
                        assetRes = null;
                    }
                }
            }
            mLoadedAssetRes.Clear();
        }

        /// <summary>
        /// 加载资源的协程
        /// </summary>
        /// <param name="image"></param>
        /// <param name="assetPath"></param>
        /// <param name="loadingId"></param>
        /// <returns></returns>
        IEnumerator LoadTexture(RawImage image, string assetPath, uint loadingId)
        {
            var assetRes = new AssetResource();
            yield return MainGame.HeartBehavior.StartCoroutine(ResourceLoader.Instance.load_asset(assetPath, typeof(UnityEngine.Object), assetRes));

            // 检查加载的资源是否正常
            var assetObject = assetRes.asset_;
            if (assetObject == null)
            {
                mLoadedAssetRes.Remove(loadingId);
                yield break;
            }

            // 检查组件和image等是否已经销毁
            Texture buffTex = assetObject as Texture;
            if (image == null || buffTex == null)
            {
                mLoadedAssetRes.Remove(loadingId);
                assetRes.destroy();
                yield break;
            }

            // 检查待加载字典中是否存在loadingid
            if (mLoadedAssetRes.ContainsKey(loadingId))
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
    }
}
