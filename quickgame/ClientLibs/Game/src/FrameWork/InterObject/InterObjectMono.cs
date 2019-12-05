using System;
using UnityEngine;

namespace xc
{
    //add to a actor object
    [wxb.Hotfix]
    public class InterObjectMono : MonoBehaviour
    {
        public InterObject BindObject;

        void OnDestroy()
        {
            BindObject = null;
        }

        void OnTriggerEnter(Collider other)
        {
            if (BindObject != null)
            {
                BindObject.NotifyTriggerEnter(other);
            }
        }

        void OnTriggerExit(Collider other)
        {
            if (BindObject != null)
            {
                BindObject.NotifyTriggerExit(other);
            }
        }
    }
}

