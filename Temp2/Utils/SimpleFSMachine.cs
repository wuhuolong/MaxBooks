using System;
using System.Collections.Generic;

namespace Utils
{
	public class SimpleFSMachine<StateType>
	{
		private Dictionary<StateType, SimpleFiniteState<StateType>> mStates = new Dictionary<StateType, SimpleFiniteState<StateType>>();

		private SimpleFiniteState<StateType> mCurrentState;

		public void AddState(StateType id, SimpleFiniteState<StateType> state)
		{
			bool flag = state == null;
			if (!flag)
			{
				this.mStates.set_Item(id, state);
			}
		}

		public SimpleFiniteState<StateType> GetState(StateType id)
		{
			SimpleFiniteState<StateType> simpleFiniteState = null;
			bool flag = this.mStates.TryGetValue(id, ref simpleFiniteState);
			SimpleFiniteState<StateType> result;
			if (flag)
			{
				result = simpleFiniteState;
			}
			else
			{
				result = null;
			}
			return result;
		}

		public void Update()
		{
			bool flag = this.mCurrentState == null;
			if (!flag)
			{
				this.mCurrentState.Update();
			}
		}

		public void SwitchToState(StateType id)
		{
			SimpleFiniteState<StateType> state = this.GetState(id);
			bool flag = state == null;
			if (!flag)
			{
				bool flag2 = state == this.mCurrentState;
				if (!flag2)
				{
					bool flag3 = this.mCurrentState != null;
					if (flag3)
					{
						this.mCurrentState.Exit();
					}
					state.Enter();
					this.mCurrentState = state;
				}
			}
		}

		public SimpleFiniteState<StateType> GetCurrentState()
		{
			return this.mCurrentState;
		}

		public StateType GetCurrentStateId()
		{
			bool flag = this.mCurrentState == null;
			StateType result;
			if (flag)
			{
				result = default(StateType);
			}
			else
			{
				result = this.mCurrentState.Id;
			}
			return result;
		}
	}
}
