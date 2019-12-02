using System;
using System.Collections;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using UnityEngine;

namespace BehaviourTree
{
	public class BehaviourConditionalNode : BehaviourWithParametersNode
	{
		private enum EOperator : byte
		{
			And,
			Or
		}

		private enum EConditionType : byte
		{
			Function,
			Expression,
			Null
		}

		private class Condition
		{
			public BehaviourConditionalNode.EConditionType Type = BehaviourConditionalNode.EConditionType.Null;

			public string FunctorByString;

			public bool IsNot = false;

			public string LeftValue;

			public string RightValue;

			public string Operator;
		}

		private LinkedList<BehaviourConditionalNode.Condition> mConditions = new LinkedList<BehaviourConditionalNode.Condition>();

		private BehaviourConditionalNode.EOperator mOperator = BehaviourConditionalNode.EOperator.And;

		private BehaviourNode mTrueBehavior;

		private BehaviourNode mFalseBehavior;

		private const string mSplitRegularPattern = "(.+?)\\s*([!<>=]+)\\s*(.+)";

		private bool mIsCacheTurnOn = false;

		private float mLastExecutionTime = 0f;

		private float mConstRefreshTime = 0f;

		private bool mCachedExpressionResult;

		public BehaviourConditionalNode(Hashtable options, IBehaviourEmployee employee) : base(employee)
		{
			bool flag = options == null;
			if (!flag)
			{
				string text = options.get_Item("condition") as string;
				bool flag2 = !string.IsNullOrEmpty(text);
				if (flag2)
				{
					string[] array = text.Split(new char[]
					{
						'|'
					});
					int num;
					for (int i = 0; i < array.Length; i = num + 1)
					{
						string text2 = array[i];
						bool flag3 = text2 == null || text2 == string.Empty;
						if (!flag3)
						{
							string[] array2 = Regex.Split(array[i].Trim(), "(.+?)\\s*([!<>=]+)\\s*(.+)", 0);
							bool flag4 = array2.Length == 1;
							if (flag4)
							{
								BehaviourConditionalNode.Condition condition = new BehaviourConditionalNode.Condition();
								condition.IsNot = false;
								string text3 = array2[0];
								char c = text3.get_Chars(0);
								bool flag5 = c == '!';
								if (flag5)
								{
									condition.IsNot = true;
									text3 = text3.Substring(1, text3.get_Length() - 1);
								}
								condition.FunctorByString = text3;
								condition.Type = BehaviourConditionalNode.EConditionType.Function;
								this.mConditions.AddLast(condition);
							}
							else
							{
								bool flag6 = array2.Length >= 5;
								if (flag6)
								{
									BehaviourConditionalNode.Condition condition2 = new BehaviourConditionalNode.Condition();
									condition2.Type = BehaviourConditionalNode.EConditionType.Expression;
									condition2.LeftValue = array2[1];
									condition2.Operator = array2[2];
									condition2.RightValue = array2[3];
									this.mConditions.AddLast(condition2);
								}
							}
						}
						num = i;
					}
				}
				Hashtable options2 = options.get_Item("true") as Hashtable;
				this.mTrueBehavior = BehaviourNode.CreateNode(options2, employee);
				options2 = (options.get_Item("false") as Hashtable);
				this.mFalseBehavior = BehaviourNode.CreateNode(options2, employee);
				string text4 = options.get_Item("operator") as string;
				bool flag7 = text4 != null && text4.ToLower() == "or";
				if (flag7)
				{
					this.mOperator = BehaviourConditionalNode.EOperator.Or;
				}
				else
				{
					this.mOperator = BehaviourConditionalNode.EOperator.And;
				}
				base.ParseParamters(options);
				string text5 = options.get_Item("cache") as string;
				bool flag8 = text5 != null && text5.ToLower() == "true";
				if (flag8)
				{
					this.mIsCacheTurnOn = true;
				}
				else
				{
					this.mIsCacheTurnOn = false;
				}
				bool flag9 = this.mIsCacheTurnOn;
				if (flag9)
				{
					string text6 = options.get_Item("refresh") as string;
					bool flag10 = text6 == null;
					if (flag10)
					{
						this.mIsCacheTurnOn = false;
					}
					else
					{
						string[] array3 = text6.Split(new char[]
						{
							'~'
						});
						bool flag11 = array3.Length > 1;
						if (flag11)
						{
							float num2 = (float)Convert.ToDouble(array3[0]);
							float num3 = (float)Convert.ToDouble(array3[1]);
							this.mConstRefreshTime = Random.Range(num2, num3);
						}
						else
						{
							this.mConstRefreshTime = (float)Convert.ToDouble(text6);
						}
					}
				}
			}
		}

		public override void Reset(IBehaviourEmployee employee)
		{
			this.mEmployee = employee;
			bool flag = this.mTrueBehavior != null;
			if (flag)
			{
				this.mTrueBehavior.Reset(employee);
			}
			bool flag2 = this.mFalseBehavior != null;
			if (flag2)
			{
				this.mFalseBehavior.Reset(employee);
			}
			this.mLastExecutionTime = 0f;
			this.mCachedExpressionResult = false;
		}

		private bool IsNumeric(string value)
		{
			float num;
			return float.TryParse(value, ref num);
		}

		private float GetFloat(string param)
		{
			bool flag = this.IsNumeric(param);
			float result;
			if (flag)
			{
				result = Convert.ToSingle(param);
			}
			else
			{
				result = this.mEmployee.RunGetProperty(param);
			}
			return result;
		}

		private bool DetectResult(float left, string operation, float right)
		{
			bool result = false;
			bool flag = operation == ">";
			if (flag)
			{
				result = (left > right);
			}
			else
			{
				bool flag2 = operation == "<";
				if (flag2)
				{
					result = (left < right);
				}
				else
				{
					bool flag3 = operation == "==";
					if (flag3)
					{
						result = (Math.Abs(left - right) <= 1E-06f);
					}
					else
					{
						bool flag4 = operation == ">=";
						if (flag4)
						{
							result = (left >= right);
						}
						else
						{
							bool flag5 = operation == "<=";
							if (flag5)
							{
								result = (left <= right);
							}
							else
							{
								bool flag6 = operation == "!=" || operation == "<>" || operation == "><";
								if (flag6)
								{
									result = (left - right > 1E-06f);
								}
							}
						}
					}
				}
			}
			return result;
		}

		public override BehaviourReturnCode Run()
		{
			float time = Time.get_time();
			float num = this.mConstRefreshTime;
			bool flag = this.mIsCacheTurnOn && this.mCachedExpressionResult;
			BehaviourReturnCode mReturnCode;
			if (flag)
			{
				bool flag2 = num > 0f && this.mLastExecutionTime > 0f;
				if (flag2)
				{
					float num2 = time - this.mLastExecutionTime;
					bool flag3 = num2 < num;
					if (flag3)
					{
						bool flag4 = this.mCachedExpressionResult;
						if (flag4)
						{
							bool flag5 = this.mTrueBehavior != null;
							if (flag5)
							{
								this.mReturnCode = this.mTrueBehavior.Run();
								mReturnCode = this.mReturnCode;
								return mReturnCode;
							}
							this.mReturnCode = BehaviourReturnCode.Success;
							mReturnCode = this.mReturnCode;
							return mReturnCode;
						}
						else
						{
							bool flag6 = this.mFalseBehavior != null;
							if (flag6)
							{
								this.mReturnCode = this.mFalseBehavior.Run();
								mReturnCode = this.mReturnCode;
								return mReturnCode;
							}
							this.mReturnCode = BehaviourReturnCode.Failure;
							mReturnCode = this.mReturnCode;
							return mReturnCode;
						}
					}
				}
			}
			this.mLastExecutionTime = time;
			bool flag7 = false;
			int num3 = 0;
			using (LinkedList<BehaviourConditionalNode.Condition>.Enumerator enumerator = this.mConditions.GetEnumerator())
			{
				while (enumerator.MoveNext())
				{
					BehaviourConditionalNode.Condition current = enumerator.get_Current();
					bool flag8 = current.Type == BehaviourConditionalNode.EConditionType.Function;
					if (flag8)
					{
						object[] parameters = base.PackInvokeParamters(num3);
						flag7 = this.mEmployee.RunCondition(current.FunctorByString, parameters);
						bool isNot = current.IsNot;
						if (isNot)
						{
							flag7 = !flag7;
						}
					}
					else
					{
						bool flag9 = current.Type == BehaviourConditionalNode.EConditionType.Expression;
						if (flag9)
						{
							float @float = this.GetFloat(current.LeftValue);
							float float2 = this.GetFloat(current.RightValue);
							flag7 = this.DetectResult(@float, current.Operator, float2);
						}
					}
					int num4 = num3 + 1;
					num3 = num4;
					bool flag10 = this.mOperator == BehaviourConditionalNode.EOperator.And;
					if (flag10)
					{
						bool flag11 = !flag7;
						if (flag11)
						{
							this.mCachedExpressionResult = false;
							bool flag12 = this.mFalseBehavior != null;
							if (flag12)
							{
								this.mReturnCode = this.mFalseBehavior.Run();
								mReturnCode = this.mReturnCode;
								return mReturnCode;
							}
							this.mReturnCode = BehaviourReturnCode.Failure;
							mReturnCode = this.mReturnCode;
							return mReturnCode;
						}
					}
					else
					{
						bool flag13 = flag7;
						if (flag13)
						{
							this.mCachedExpressionResult = true;
							bool flag14 = this.mTrueBehavior != null;
							if (flag14)
							{
								this.mReturnCode = this.mTrueBehavior.Run();
								mReturnCode = this.mReturnCode;
								return mReturnCode;
							}
							this.mReturnCode = BehaviourReturnCode.Success;
							mReturnCode = this.mReturnCode;
							return mReturnCode;
						}
					}
				}
			}
			bool flag15 = this.mOperator == BehaviourConditionalNode.EOperator.And;
			if (flag15)
			{
				this.mCachedExpressionResult = true;
				bool flag16 = this.mTrueBehavior != null;
				if (flag16)
				{
					this.mReturnCode = this.mTrueBehavior.Run();
					mReturnCode = this.mReturnCode;
				}
				else
				{
					this.mReturnCode = BehaviourReturnCode.Success;
					mReturnCode = this.mReturnCode;
				}
			}
			else
			{
				this.mCachedExpressionResult = false;
				bool flag17 = this.mFalseBehavior != null;
				if (flag17)
				{
					this.mReturnCode = this.mFalseBehavior.Run();
					mReturnCode = this.mReturnCode;
				}
				else
				{
					this.mReturnCode = BehaviourReturnCode.Failure;
					mReturnCode = this.mReturnCode;
				}
			}
			return mReturnCode;
		}
	}
}
