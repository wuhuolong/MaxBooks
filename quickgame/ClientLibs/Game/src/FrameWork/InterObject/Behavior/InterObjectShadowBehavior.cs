//------------------------------------------------------------------------------
// InterObjectShadowBehavior.cs
// 控制互动物体阴影的显示
// raorui
// 2017.7.20
//------------------------------------------------------------------------------
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SGameEngine;

namespace xc
{
    public class InterObjectShadowBehavior
    {
        // ------------------------------------------------
        // 接口的实现
        // ------------------------------------------------
        /*public void Start()
        {
            MainGame.HeartBehavior.StartCoroutine(LoadFakeShadow());
        }

        public void Destory()
        {
            if (m_FakeShadow != null)
                ObjCachePoolMgr.Instance.RecyclePrefab(m_FakeShadow, ObjCachePoolType.SMALL_PREFAB, ShadowEffectPrefab);
        }


        // ------------------------------------------------
        // 组件的变量定义
        // ------------------------------------------------
        const string ShadowEffectPrefab = "Core/ShadowProjector/ShadowProjector";

        /// <summary>
        /// 角色假阴影对应的GameObject
        /// </summary>
        GameObject m_FakeShadow;

        // ------------------------------------------------
        // 组件的内部方法
        // ------------------------------------------------

        private IEnumerator LoadFakeShadow()
        {
            ObjectWrapper ow = new ObjectWrapper();

            yield return ObjCachePoolMgr.Instance.StartCoroutine(ObjCachePoolMgr.Instance.LoadPrefab(ShadowEffectPrefab, ObjCachePoolType.SMALL_PREFAB, ShadowEffectPrefab, ow));

            m_FakeShadow = ow.obj as GameObject;

            // 异步加载资源时，可能角色已经被销毁了
            if (mOwner == null)
            {
                if (m_FakeShadow != null)
                    ObjCachePoolMgr.Instance.RecyclePrefab(m_FakeShadow, ObjCachePoolType.SMALL_PREFAB, ShadowEffectPrefab);
                yield break;
            }

            Transform mFakeShadowTrans = m_FakeShadow.transform;
            mFakeShadowTrans.parent = mOwner.Trans;
            mFakeShadowTrans.localPosition = Vector3.zero;
        }

        // ------------------------------------------------
        // 组件的外部接口
        // ------------------------------------------------
        
        void OnAfterCreate(CEventBaseArgs data)
        {
            if (m_FakeShadow != null)
            {
                Transform mFakeShadowTrans = m_FakeShadow.transform;
                mFakeShadowTrans.parent = mOwner.Trans;
                mFakeShadowTrans.localPosition = Vector3.zero;
            }
        }*/
    }
}
