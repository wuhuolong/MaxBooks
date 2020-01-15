using System;
using System.Collections.Generic;
using Utils;

using UnityEngine;
using SGameEngine;
using DynamicShadowProjector;

namespace xc
{
    class ShadowManager : xc.Singleton<ShadowManager>
    {
        GameObject m_ShadowProjector;
        DrawSceneObject mDrawSceneObject;

        private Material shadowShareMaterial;

        private class ShadowCache
        {
            public Color color;
            public Material mat;
        }

        private int dynCount = 1;
        private int staCount = 1;

        private List<ShadowCache> shadowMatCache;

        private List<Material> shadowMatDynCache;

        private const string SHADOW_MAT_PATH = "Core/Materials/Shadow";

        public Material GetNewDynShadowMaterial()
        {
            if (shadowMatDynCache == null)
                return null;

            if (shadowMatDynCache.Count > 0)
            {
                var mat = shadowMatDynCache[shadowMatDynCache.Count - 1];

                shadowMatDynCache.RemoveAt(shadowMatDynCache.Count - 1);

                return mat;
            }
            else
            {
                var newMat = new Material(shadowShareMaterial);
                newMat.name = newMat + "_DynMat_" + dynCount;
                dynCount++;
                return newMat;
            }
        }

        public void FreeDynShadowMat(Material mat)
        {
            if (shadowMatDynCache == null)
            {
                return;
            }

            shadowMatDynCache.Add(mat);
        }


        public Material GetShadowMaterial(Color color)
        {
            if (shadowShareMaterial == null)
            {
                return null;
            }

            foreach (var cache in shadowMatCache)
            {
                if (cache.color == color)
                {
                    return cache.mat;
                }
            }
            //generate

            ShadowCache newCache = new ShadowCache();
            newCache.color = color;

            newCache.mat = new Material(shadowShareMaterial);

            newCache.mat.SetColor("_Color", color);

            shadowMatCache.Add(newCache);

            newCache.mat.name = newCache.mat.name + "_StaMat_" + staCount;
            staCount++;

            return newCache.mat;
        }

        public ShadowManager()
        {

            shadowShareMaterial = Resources.Load<Material>(SHADOW_MAT_PATH);

            if (shadowShareMaterial)
            {
                shadowMatCache = new List<ShadowCache>();
                shadowMatDynCache = new List<Material>();
                ShadowCache cache = new ShadowCache();

                cache.color = new Color(1, 1, 1, 1);

                cache.mat = shadowShareMaterial;
            }
            else
            {
                Debug.LogError("shadow路径不存在:" + SHADOW_MAT_PATH);
            }

            Init();
            //UnityEngine.Object shadowObj = ResourceLoader.Instance.try_load_cached_asset("Assets/Res/Core/ShadowProjector/HardShadowProjector.prefab") as UnityEngine.Object;
            //if(shadowObj != null)
            //{
            //    m_ShadowProjector = GameObject.Instantiate(shadowObj) as GameObject;
            //    if(m_ShadowProjector != null)
            //    {
            //        mDrawSceneObject = m_ShadowProjector.GetComponent<DrawSceneObject>();
            //        GameObject.DontDestroyOnLoad(m_ShadowProjector);
            //    }
            //}

            ClientEventMgr.Instance.SubscribeClientEvent((int)ClientEvent.CE_LOCALPLAYER_MODEL_CHANGE, OnLocalPlayerModelChange);
            ClientEventMgr.Instance.SubscribeClientEvent((int)ClientEvent.CE_FINISH_SWITCHSCENE, OnSceneLoaded);
        }

        /// <summary>
        /// 角色模型变化时需要重设Camera的Target
        /// </summary>
        /// <param name="data"></param>
        void OnLocalPlayerModelChange(CEventBaseArgs data)
        {
            Init();
            var local_player = Game.Instance.GetLocalPlayer();
            if (mDrawSceneObject != null && local_player != null)
            {
                mDrawSceneObject.FollowTarget = local_player.transform;
            }
        }

        LayerMask mShadowMask;

        public void Reset()
        {
            mShadowMask = 1 << LayerMask.NameToLayer("ShadowCaster");
        }

        public void Update()
        {
            Init();
            var local_player = Game.Instance.GetLocalPlayer();
            if (mDrawSceneObject != null && local_player != null && local_player.IsDestroy == false)
            {
                mDrawSceneObject.cullingMask = mShadowMask;
                mDrawSceneObject.FollowTarget = local_player.transform;
            }
        }

        /// <summary>
        /// 当场景发生变化时
        /// </summary>
        /// <param name="data"></param>
        void OnSceneLoaded(CEventBaseArgs data)
        {
            Init();
            if (m_ShadowProjector != null)
                m_ShadowProjector.SendMessage("OnSceneLoaded");
        }

        /// <summary>
        /// 设置实时阴影的参数(在创角等没有loacalplayer的场景使用)
        /// </summary>
        /// <param name="target"></param>
        /// <param name="shadow_mask"></param>
        public void SetRealShadow(Transform target, Vector3 light_dir, LayerMask shadow_mask)
        {
            Init();
            if (mDrawSceneObject != null)
            {
                mDrawSceneObject.FollowTarget = target;
                mDrawSceneObject.FollowDir = light_dir;

                mDrawSceneObject.cullingMask = shadow_mask;
            }
        }

        private void Init()
        {
            if (m_ShadowProjector != null && mDrawSceneObject != null)
            {
                return;
            }

            UnityEngine.Object shadowObj = ResourceLoader.Instance.try_load_cached_asset("Assets/Res/Core/ShadowProjector/HardShadowProjector.prefab") as UnityEngine.Object;
            if (shadowObj != null)
            {
                m_ShadowProjector = GameObject.Instantiate(shadowObj) as GameObject;
                if (m_ShadowProjector != null)
                {
                    mDrawSceneObject = m_ShadowProjector.GetComponent<DrawSceneObject>();
                    GameObject.DontDestroyOnLoad(m_ShadowProjector);
                }
            }
        }
    }
}
