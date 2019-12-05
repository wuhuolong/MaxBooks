using System;
using UnityEngine;

namespace xc
{
    //add to a actor object
    [wxb.Hotfix]
    public class ActorMono : MonoBehaviour
    {
        public Actor BindActor;

        void OnTriggerEnter(Collider other)
        {
            if(BindActor != null)
            {
                BindActor.NotifyTriggerEnter(other);
            }
        }

        void OnTriggerExit(Collider other)
        {
            if (BindActor != null)
            {
                BindActor.NotifyTriggerExit(other);
            }
        }

        void OnDestroy()
        {
            BindActor = null;
        }
    }
}

