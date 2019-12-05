//-------------------------------------------------------------------
// Desc : 特效文件的加载和的实例化
// Author : raorui
// Date : 2018.11.27重构
//-------------------------------------------------------------------
using UnityEngine;
using System.IO;
using System.Collections;
using System.Collections.Generic;

using Utils;
using SGameEngine;

namespace xc
{
    public class EffectEmitter
    {
        /// <summary>
        /// 特效文件对应的Object
        /// </summary>
        UnityEngine.Object mEffectPrefab;

        /// <summary>
        /// 特效bundle资源
        /// </summary>
        AssetResource mAssetRes;

        /// <summary>
        /// 每一个特效可以实例化的最大数量
        /// </summary>
        int mInstMaxCount = 5;

        /// <summary>
        /// 特效文件是否已经加载
        /// </summary>
        public bool Loaded
        {
            get
            {
                return mEffectPrefab != null;
            }
        }

        /// <summary>
        /// 加载完毕的回调函数
        /// </summary>
        /// <param name="effectObject"></param>
        public delegate void InitFunc(GameObject effectObject);

        /// <summary>
        /// 所有的回调函数列表
        /// </summary>
        List<InitFunc> mInitCallback = new List<InitFunc>();

        /// <summary>
        /// 特效的资源路径,例如: Effects/Prefabs/Skill/PublicBuff/EF_buff_xuanyun
        /// </summary>
        string mAssetPath;

        /// <summary>
        /// 组件是否被销毁
        /// </summary>
        bool mIsDestroy = false;

        // 构造函数
        public EffectEmitter(string assetPath,int maxCount)
        {
            MainGame.HeartBehavior.StartCoroutine(InitEmitter(assetPath, maxCount));
        }

        IEnumerator InitEmitter(string assetPath,int maxCount)
        {
            if (string.IsNullOrEmpty(assetPath))
            {
                GameDebug.LogError("特效Prefab名字为空");
                yield break;
            }

            string ext = "";
            if (string.IsNullOrEmpty(Path.GetExtension(assetPath)))
                ext = ".prefab";

            mAssetPath = assetPath;
            mInstMaxCount = maxCount;
            mInitCallback.Clear();

            var assetRes = new AssetResource();
            string fullPath = string.Format("Assets/Res/{0}{1}", mAssetPath, ext);
            yield return MainGame.HeartBehavior.StartCoroutine(SGameEngine.ResourceLoader.Instance.load_asset(fullPath, typeof(Object), assetRes));

            // 检查资源是否加载成功
            if(assetRes.asset_ == null)
            {
                GameDebug.LogError("Init emitter error, can not load prefab " + mAssetPath);
                yield break;
            }

            // 检查组件是否销毁
            if(mIsDestroy)
            {
                assetRes.destroy();
                yield break;
            }

            mAssetRes = assetRes;
            OnObjectLoaded(mAssetRes.asset_);
        }

        /// <summary>
        /// 销毁特效的bundle资源
        /// </summary>
        public void Destroy()
        {
            mIsDestroy = true;

            mEffectPrefab = null;

            if (mAssetRes != null)
            {
                mAssetRes.destroy();
                mAssetRes = null;
            }

            mInitCallback.Clear();
        }

        /// <summary>
        /// 实例化特效物体
        /// </summary>
        public void CreateInstance(InitFunc callBack)
        {
            if(mIsDestroy)
                return;

            // 如果特效文件已经加载完成，则直接进行实例化
            if (mEffectPrefab != null)
            {               
                if (callBack != null)
                {
                    var newEffect = ObjInstHelp.GetInstance().InstantiateReuse(mEffectPrefab, mInstMaxCount);
                    callBack(newEffect);
                }
            }
            // 未加载完成则将初始化回调函数添加到列表中，等到加载完毕后再进行调用
            else
            {
                mInitCallback.Add(callBack);
            }
        }
        
        /// <summary>
        /// 当特效文件加载完毕后，进行相应的实例化处理
        /// </summary>
        void OnObjectLoaded(Object obj)
        {
            // 设置特效Object
            mEffectPrefab = obj;
            
            // 获取特效初始化回调函数列表，实例化特效Object
            for (int i=0; i< mInitCallback.Count; ++i)
            {
                var callBack = mInitCallback[i];
                var newEffect = ObjInstHelp.GetInstance().InstantiateReuse(mEffectPrefab, mInstMaxCount);// 限制最大可实例物体的数量
                callBack(newEffect);
            }

            mInitCallback.Clear();
        }
    }
}
