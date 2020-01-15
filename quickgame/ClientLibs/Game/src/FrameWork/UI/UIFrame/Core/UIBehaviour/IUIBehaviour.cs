using UnityEngine;
using System.Collections;
using System;
using xc;
namespace xc.ui.ugui
{
	public abstract class IUIBehaviour
	{
		public UIBaseWindow Window;
        public bool isInit = false;
        public bool IsEnable = false;
        public bool OldEnable = false;
        public virtual void InitBehaviour()
        {
            isInit = true;
        }
        public virtual void UpdateBehaviour()
        {
        }

        public virtual void DestroyBehaviour()
        {
            isInit = false;
            Window = null;
        }
        public virtual void EnableBehaviour(bool isEnable)
        {
            OldEnable = IsEnable;
            IsEnable = isEnable;
        }
	}
}


