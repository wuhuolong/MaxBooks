using System;
using System.Collections;
using UnityEngine;

namespace BehaviourTree
{
	public class BehaviourActionNode : BehaviourWithParametersNode
	{
		private string mActionFunctor;

		private BehaviourNode mIntervalAction;

		private float mContinuousExecutionConstIntervalTime = 0f;

		private float mContinuousExecutionConstIntervalTimeBak;

		private float mBeginIntervalTime = 0f;

		private float mEndIntervalTime = 0f;

		private float mStartTime = 0f;

		private float mLastExecutionTime = 0f;

		private bool mIsFirstRunInThisCircle = true;

		private bool mIsRandomFirstRunTime = false;

		private bool mIsRandomFirstRunTimeBak;

		private float mFirstRunTime = 0f;

		public BehaviourActionNode(Hashtable options, IBehaviourEmployee employee) : base(employee)
		{
			this.mActionFunctor = (options.get_Item("action") as string);
			string text = options.get_Item("randomfirst") as string;
			bool flag = text != null && text == "true";
			if (flag)
			{
				this.mIsRandomFirstRunTime = true;
			}
			else
			{
				this.mIsRandomFirstRunTime = false;
			}
			this.mIsRandomFirstRunTimeBak = this.mIsRandomFirstRunTime;
			string text2 = options.get_Item("interval") as string;
			bool flag2 = !string.IsNullOrEmpty(text2);
			if (flag2)
			{
				string[] array = text2.Split(new char[]
				{
					'~'
				});
				bool flag3 = array.Length > 1;
				if (flag3)
				{
					this.mBeginIntervalTime = (float)Convert.ToDouble(array[0]);
					this.mEndIntervalTime = (float)Convert.ToDouble(array[1]);
					this.mContinuousExecutionConstIntervalTime = Random.Range(this.mBeginIntervalTime, this.mEndIntervalTime);
				}
				else
				{
					this.mContinuousExecutionConstIntervalTime = (float)Convert.ToDouble(text2);
				}
			}
			else
			{
				this.mContinuousExecutionConstIntervalTime = 0f;
			}
			this.mContinuousExecutionConstIntervalTimeBak = this.mContinuousExecutionConstIntervalTime;
			bool flag4 = this.mIsRandomFirstRunTime;
			if (flag4)
			{
				this.mFirstRunTime = Random.Range(0f, this.mContinuousExecutionConstIntervalTime);
			}
			Hashtable hashtable = options.get_Item("intervalaction") as Hashtable;
			bool flag5 = hashtable != null;
			if (flag5)
			{
				this.mIntervalAction = BehaviourNode.CreateNode(hashtable, employee);
			}
			base.ParseParamters(options);
		}

		public override void Reset(IBehaviourEmployee employee)
		{
			this.mEmployee = employee;
			this.mContinuousExecutionConstIntervalTime = this.mContinuousExecutionConstIntervalTimeBak;
			this.mStartTime = 0f;
			this.mLastExecutionTime = 0f;
			this.mIsFirstRunInThisCircle = true;
			this.mIsRandomFirstRunTime = this.mIsRandomFirstRunTimeBak;
			bool flag = this.mIntervalAction != null;
			if (flag)
			{
				this.mIntervalAction.Reset(employee);
			}
		}

		private BehaviourReturnCode RunImplenment()
		{
			this.mReturnCode = BehaviourReturnCode.Success;
			bool flag = this.mActionFunctor != null && this.mEmployee != null;
			if (flag)
			{
				object[] parameters = base.PackInvokeParamters(0);
				this.mReturnCode = this.mEmployee.RunAction(this.mActionFunctor, parameters);
			}
			return this.mReturnCode;
		}

		public override BehaviourReturnCode Run()
		{
			float time = Time.get_time();
			bool flag = this.mStartTime <= 0f;
			if (flag)
			{
				this.mStartTime = time;
			}
			bool flag2 = this.mIsFirstRunInThisCircle;
			BehaviourReturnCode result;
			if (flag2)
			{
				bool flag3 = this.mIsRandomFirstRunTime;
				if (flag3)
				{
					float num = time - this.mStartTime;
					bool flag4 = num < this.mFirstRunTime;
					if (flag4)
					{
						bool flag5 = this.mIntervalAction != null;
						if (flag5)
						{
							this.mIntervalAction.Run();
						}
						result = BehaviourReturnCode.Running;
						return result;
					}
					this.mIsRandomFirstRunTime = false;
				}
				this.mReturnCode = this.RunImplenment();
				this.mLastExecutionTime = time;
				bool flag6 = this.mEndIntervalTime > 0f;
				if (flag6)
				{
					this.mContinuousExecutionConstIntervalTime = Random.Range(this.mBeginIntervalTime, this.mEndIntervalTime);
				}
				bool flag7 = this.mContinuousExecutionConstIntervalTime <= 0f;
				if (flag7)
				{
					this.mIsFirstRunInThisCircle = true;
					result = this.mReturnCode;
					return result;
				}
			}
			this.mIsFirstRunInThisCircle = false;
			bool flag8 = this.mReturnCode == BehaviourReturnCode.Failure;
			if (flag8)
			{
				this.mIsFirstRunInThisCircle = true;
			}
			bool flag9 = this.mContinuousExecutionConstIntervalTime > 0f;
			if (flag9)
			{
				float num2 = time - this.mLastExecutionTime;
				bool flag10 = num2 < this.mContinuousExecutionConstIntervalTime;
				if (flag10)
				{
					bool flag11 = this.mIntervalAction != null;
					if (flag11)
					{
						this.mIntervalAction.Run();
					}
					result = BehaviourReturnCode.Running;
				}
				else
				{
					this.mIsFirstRunInThisCircle = true;
					result = BehaviourReturnCode.Success;
				}
			}
			else
			{
				result = BehaviourReturnCode.Success;
			}
			return result;
		}
	}
}
