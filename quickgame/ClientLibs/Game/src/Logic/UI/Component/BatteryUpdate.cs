//------------------------------------------------------------------------------
// FileName : BatteryUpdate.cs
// Author: raorui
// Ddate: 2017.7.21
// Desc: 更新电量显示的组件UGUI
//------------------------------------------------------------------------------
using System;
using UnityEngine;
using UnityEngine.UI;
using xc;

public class BatteryUpdate : MonoBehaviour
{
    float mTime = 0;
    const float mBatteryCD = 480;
    Slider mBatterySlider;
    void Start()
    {
        mTime = 0;
        mBatterySlider = GetComponent<Slider>();
        if(mBatterySlider != null)
            mBatterySlider.value = DBOSManager.getOSBridge().getBattery();
    }

    void Update()
    {
        if(null != mBatterySlider)
        {
            if(mTime >= mBatteryCD)
            {
                mTime = 0;
                if(mBatterySlider != null)
                    mBatterySlider.value = DBOSManager.getOSBridge().getBattery() ;
            }
            mTime += Time.deltaTime;
        }
    }
}


