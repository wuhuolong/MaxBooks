using UnityEngine;
using System.Collections;
using System.Collections.Generic;

namespace xc
{
    public class BaseCtrl
    {
        public bool mIsSendMsg = false;
        public bool mIsRecvMsg = false;
        public bool mIsProcessInput = false;
        protected bool mIsDestroy = false;

        protected Actor mOwner = null;
        public Actor Owner
        {
            get
            {
                return mOwner;
            }
        }

        public bool IsDestroy
        {
            get
            {
                return mIsDestroy;
            }
        }

        public virtual void Destroy()
        {
            mOwner = null;
            mIsDestroy = true;
        }

        public virtual void Update()
        {

        }

        public BaseCtrl(Actor owner)
        {
            mOwner = owner;
        }
    }
}