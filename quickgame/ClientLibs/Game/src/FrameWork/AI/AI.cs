using UnityEngine;
using System.Collections;
using System.Collections.Generic;

namespace xc
{
	// AI基类，所有具体的AI类从此类继承
	public class AI
	{
		public float Delta;	// AI的激活频率
		bool mEnabled;
		
		protected float mTime;
		
		public AI ()
		{
			mTime = 0;
			mEnabled = true;
		}
		
        public virtual void Init()
        {

        }

		public virtual void Update()
		{
			if(!mEnabled)
				return;

			mTime += Time.deltaTime;
			if (mTime < Delta)
				return;
			mTime = 0;

            Active();
		}

        public virtual void Reset()
        {

        }
		
		public bool Enabled
		{
			set
            {
                mEnabled = value;

                Reset();
            }
			get
            {
                return mEnabled;
            }
		}
		
		public virtual void Active()
		{
			return;
		}
		
		public virtual void BeAttack(Damage dam)
		{
			return;
		}
        public virtual void OnDestroy()
        {
            return;
        }
	}
}

