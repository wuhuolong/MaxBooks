using System;
using System.Collections.Generic;
using UnityEngine;

namespace xc
{
    public class SpriteMaterialManager : xc.Singleton<SpriteMaterialManager>
    {
        Dictionary<string, Material> mIconMaterials = new Dictionary<string, Material>();

        public SpriteMaterialManager()
        {
            ClientEventMgr.GetInstance().SubscribeClientEvent((int)ClientEvent.CE_SWITCHINSTANCE, OnSwitchInstance);
        }

        /// <summary>
        /// 根据贴图路径获取可用材质
        /// </summary>
        /// <param name="iconPath"></param>
        /// <returns></returns>
        public Material GetMaterial(string iconPath)
        {
            Material mat = null;
            mIconMaterials.TryGetValue(iconPath, out mat);
            return mat;
        }

        /// <summary>
        /// 设置贴图对应的材质
        /// </summary>
        /// <param name="iconPath"></param>
        /// <param name="mat"></param>
        public void SetMaterial(string iconPath, Material mat)
        {
            mIconMaterials[iconPath] = mat;
        }

        /// <summary>
        /// 切换副本(切换、不切换场景均调用)
        /// </summary>
        /// <param name="data"></param>
        void OnSwitchInstance(CEventBaseArgs data)
        {
            foreach(var mat in mIconMaterials.Values)
            {
                if (mat != null)
                    GameObject.Destroy(mat);
            }

            mIconMaterials.Clear();
        }
    }
}
