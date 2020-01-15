//------------------------------------------------------------------------------
// File: BindEffectInfo.cs
// Desc: 保存绑定在玩家身上特效的资源和实例化物体
// Author: raorui
// Date: 2018.11.27
//------------------------------------------------------------------------------
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SGameEngine;

namespace xc
{
    public class BindEffectInfo
    {
        /// <summary>
        /// 特效资源的路径
        /// </summary>
        public string mEffectResPath;

        /// <summary>
        /// 特效绑定的位置
        /// </summary>
        public DBBuffSev.BindPos BindPos;

        /// <summary>
        /// 是否跟随目标点移动
        /// </summary>
        public bool FollowTarget;

        /// <summary>
        /// 特效的缩放数值
        /// </summary>
        public float mScale = 1.0f;

        /// <summary>
        /// 可实例化的最大特效物体
        /// </summary>
        public int MaxCount = 5;

        /// <summary>
        /// 特效的发射器
        /// </summary>
        public EffectEmitter mEmitter = null;

        /// <summary>
        /// 已经加载的特效物体
        /// </summary>
        public GameObject mEffectObject = null;

        /// <summary>
        /// 特效加载完毕后的处理函数
        /// </summary>
        public EffectEmitter.InitFunc mInitFunc;

        /// <summary>
        /// 特效是否已经被销毁
        /// </summary>
        public bool IsDestroy
        {
            get
            {
                return mIsDestory;
            }
        }

        bool mIsDestory = true;

        public BindEffectInfo(string effect_path, DBBuffSev.BindPos bind_pos, bool follow_target, float scale, int maxCount)
        {
            mEffectResPath = effect_path;
            if (!string.IsNullOrEmpty(mEffectResPath))
                mEmitter = EffectManager.GetInstance().GetEffectEmitter(mEffectResPath, maxCount);
            BindPos = bind_pos;
            FollowTarget = follow_target;
            mScale = scale;
            MaxCount = maxCount;
        }

        /// <summary>
        /// 加载特效文件
        /// </summary>
        public void CreateInstance()
        {
            if (mIsDestory)
            {
                mIsDestory = false;
                if (mEmitter != null)
                {
                    mEmitter.CreateInstance(OnEffectLoaded);
                }
                else
                {
                    OnEffectLoaded(null);
                }
            }
        }

        void OnEffectLoaded(GameObject effect_object)
        {
            if (mInitFunc != null)
                mInitFunc(effect_object);
        }

        /// <summary>
        /// 销毁特效文件
        /// </summary>
        public void DestroyInstance()
        {
            mIsDestory = true;
            if (mEffectObject != null)
            {
                GameObject.DestroyImmediate(mEffectObject);
                mEffectObject = null;
            }
        }
    }
}
