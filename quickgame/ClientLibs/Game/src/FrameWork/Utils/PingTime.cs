using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using Utils;

namespace xc
{
	public class PingTime : xc.Singleton<PingTime>
	{
		public float DelayTime
		{
			get { return mDelayTime; }
            set { mDelayTime = value; }
		}
		
		protected float mDelayTime = 0.0f;
	}
}

