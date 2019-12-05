//-------------------------------------------
// File: WaterWaveEffect.cs
// Desc: 控制全屏波纹效果的开启和关闭
// Author: raorui
// Date: 2018.7.5
//-------------------------------------------
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Utils;
using xc.ui.ugui;

namespace xc
{
    public class WaterWaveEffect : xc.Singleton<WaterWaveEffect>
    {
        Coroutine mDelayCoroutine;

        /// <summary>
        /// 开启效果
        /// </summary>
        /// <param name="delay_time"></param>
        /// <returns></returns>
        public bool Start(float delay_time, Action finish_handle)
        {
            var camera = UIMainCtrl.PostCamera;
            if (camera == null)
            {
                if (finish_handle != null)
                    finish_handle();
                return false;
            }

            camera.gameObject.SetActive(false);
            camera.gameObject.SetActive(true);

            if(mDelayCoroutine != null)
                MainGame.HeartBehavior.StopCoroutine(mDelayCoroutine);
            mDelayCoroutine = MainGame.HeartBehavior.StartCoroutine(DelayDisable(delay_time, finish_handle));
            return true;
        }

        IEnumerator DelayDisable(float delay_time, Action finish_handle)
        {
            yield return new WaitForSeconds(delay_time);

            var camera = UIMainCtrl.PostCamera;
            if (camera != null)
                camera.gameObject.SetActive(false);

            if (finish_handle != null)
                finish_handle();
        }

        /// <summary>
        /// 结束效果
        /// </summary>
        public void End()
        {
            var camera = UIMainCtrl.PostCamera;
            if (camera != null)
            {
                camera.gameObject.SetActive(false);
            }

            if (mDelayCoroutine != null)
            {
                MainGame.HeartBehavior.StopCoroutine(mDelayCoroutine);
                mDelayCoroutine = null;
            }
        }
    }
}
