using System;
using System.Collections.Generic;
using Utils;
using UnityEngine;

namespace xc
{
    class XSceneManager : xc.Singleton<XSceneManager>
    {
        /// <summary>
        /// 是否激活下雨的效果
        /// </summary>
        /// <param name="is_active"></param>
        public void ActiveRain(bool is_active)
        {
            //Debug.Log("ActiveRain:" + is_active);
            var main_camera = Camera.main;
            if (main_camera == null)
                return;

            var cam_trans = main_camera.transform;
            for(int i = 0; i < cam_trans.childCount; ++i)
            {
                var child_trans = cam_trans.GetChild(i);
                if (child_trans != null)
                    child_trans.gameObject.SetActive(is_active);
            }
        }
    }
}
