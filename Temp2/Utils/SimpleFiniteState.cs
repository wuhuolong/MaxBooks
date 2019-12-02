using System;
using UnityEngine;

namespace Utils
{
	public class SimpleFiniteState<StateType>
	{
		private StateType mId;

		private float mStatingDuration = 0f;

		public StateType Id
		{
			get
			{
				return this.mId;
			}
		}

		public float StatingDuration
		{
			get
			{
				return this.mStatingDuration;
			}
			set
			{
				this.mStatingDuration = value;
			}
		}

		public SimpleFiniteState(StateType id)
		{
			this.mId = id;
		}

		public virtual void Update()
		{
			this.mStatingDuration += Time.get_deltaTime();
		}

		public virtual void Enter()
		{
			this.mStatingDuration = 0f;
		}

		public virtual void Exit()
		{
		}
	}
}
