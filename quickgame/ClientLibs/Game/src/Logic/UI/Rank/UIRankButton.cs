using System;
using UnityEngine;
namespace xc
{
    [wxb.Hotfix]
    public class UIRankButton:MonoBehaviour
    {
        public TweenRotation RotateTweener { get; set; }
        public GameObject Arrow;
        public Vector3 RotateToValue = new Vector3(0, 0, -180);

        public void Active()
        {
            if(Arrow != null)
            {
                Arrow.SetActive(true);
            }
            
            if(RotateTweener != null)
            {
                RotateTweener.duration = 0.13f;
                RotateTweener.from = RotateTweener.transform.localEulerAngles;
                RotateTweener.to = RotateToValue;
                RotateTweener.ResetToBeginning();
                RotateTweener.enabled = true;
            }
        }

        public void DisActive()
        {
            if(RotateTweener != null)
            {
                RotateTweener.from = RotateTweener.transform.localEulerAngles;
                RotateTweener.to = new Vector3(0, 0, 0);
                RotateTweener.ResetToBeginning();
                RotateTweener.enabled = true;
            }
           
            if (Arrow != null)
            {
                Arrow.SetActive(false);
            }
        }
    }
}

