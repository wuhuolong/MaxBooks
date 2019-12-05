using UnityEngine;
using System.Text;
using System.Collections;

namespace xc
{
    public class ButtonHoldCtrl : MonoBehaviour
    {
        /// <summary>
        /// 触发按住开始的时间
        /// </summary>
        private float holdBeginTime = float.MaxValue;

        /// <summary>
        /// 按住持续多久时间触发按住开始回调
        /// </summary>
        private float pressTime = 1.0f;
        public float PressTime
        {
            set
            {
                pressTime = value;
            }
        }

        /// <summary>
        /// 是否按住
        /// </summary>
        private bool isHold = false;

        public delegate void Callback();
        public Callback OnClickCallback
        {
            get;
            set;
        }
        public Callback OnHoldBeginCallback
        {
            get;
            set;
        }

        public Callback OnHoldEndCallback
        {
            get;
            set;
        }

        void Update()
        {
            if (!isHold && Time.time > holdBeginTime)
            {
                if (OnHoldBeginCallback != null)
                    OnHoldBeginCallback();
                isHold = true;
            }
        }
        void OnPress(bool isDown)
        {
            if (isDown)
            {
                holdBeginTime = Time.time + pressTime;
            }
            else
            {
                holdBeginTime = float.MaxValue;
                if (isHold)
                {
                    if (OnHoldEndCallback != null)
                        OnHoldEndCallback();
                    isHold = false;
                }
                else
                {
                    if (OnClickCallback != null)
                        OnClickCallback();
                }
            }
        }
    }
}

