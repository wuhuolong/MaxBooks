using System;
using System.Collections;
using UnityEngine;

namespace SafeCoroutine
{
	public class Coroutine : IYieldInstruction
	{
		public enum EState
		{
			NotInit,
			Stopped,
			Running,
			Paused
		}

		protected IEnumerator mIterator;

		protected Coroutine mChildCoroutine;

		protected Coroutine mParentCoroutine;

		protected Coroutine.EState mState = Coroutine.EState.NotInit;

		protected object mResult;

		public Coroutine.EState State
		{
			get
			{
				return this.mState;
			}
		}

		public object Result
		{
			get
			{
				return this.mResult;
			}
		}

		public bool HasResult
		{
			get
			{
				return this.mResult != null;
			}
		}

		public bool IsRunning
		{
			get
			{
				return this.mState == Coroutine.EState.Running;
			}
		}

		public bool IsFinish
		{
			get
			{
				return this.mState == Coroutine.EState.Stopped;
			}
		}

		public bool IsPause
		{
			get
			{
				return this.mState == Coroutine.EState.Paused || this.IsParentPaused;
			}
		}

		public bool IsSelfPaused
		{
			get
			{
				return this.mState == Coroutine.EState.Paused;
			}
		}

		protected bool IsParentPaused
		{
			get
			{
				bool flag = this.mParentCoroutine == null;
				return !flag && this.mParentCoroutine.IsPause;
			}
		}

		public Coroutine(IEnumerator itr)
		{
			this.mIterator = itr;
			bool flag = this.mIterator != null;
			if (flag)
			{
				this.mState = Coroutine.EState.Running;
				this.mIterator.MoveNext();
			}
			else
			{
				this.mState = Coroutine.EState.Stopped;
			}
		}

		private bool finish()
		{
			this.mState = Coroutine.EState.Stopped;
			bool flag = this.mParentCoroutine != null;
			if (flag)
			{
				this.mParentCoroutine = null;
			}
			return true;
		}

		public void Pause()
		{
			bool flag = this.mState == Coroutine.EState.Running;
			if (flag)
			{
				this.mState = Coroutine.EState.Paused;
			}
			else
			{
				this.logStateError("Pause");
			}
		}

		protected void logStateError(string function_name)
		{
			Debug.LogWarning(string.Concat(new object[]
			{
				"Coroutine.",
				function_name,
				" error! state = ",
				this.mState
			}));
		}

		public void Resume()
		{
			bool flag = this.mState == Coroutine.EState.Paused;
			if (flag)
			{
				this.mState = Coroutine.EState.Running;
			}
			else
			{
				this.logStateError("Resume");
			}
		}

		public void Stop()
		{
			this.mIterator = null;
			this.mState = Coroutine.EState.Stopped;
			bool flag = this.mChildCoroutine != null;
			if (flag)
			{
				this.mChildCoroutine.Stop();
				this.mChildCoroutine = null;
			}
			else
			{
				bool flag2 = this.mParentCoroutine != null;
				if (flag2)
				{
					this.mParentCoroutine = null;
				}
			}
		}

		public bool Update(float delta_time)
		{
			bool flag = this.mIterator == null;
			bool result;
			if (flag)
			{
				result = this.finish();
			}
			else
			{
				bool isPause = this.IsPause;
				if (isPause)
				{
					result = false;
				}
				else
				{
					bool flag2 = this.mIterator.get_Current() == null;
					if (flag2)
					{
						bool flag3 = !this.mIterator.MoveNext();
						if (flag3)
						{
							result = this.finish();
							return result;
						}
					}
					else
					{
						bool flag4 = this.mIterator.get_Current() is Coroutine;
						if (flag4)
						{
							bool flag5 = this.mChildCoroutine == null;
							if (flag5)
							{
								this.mChildCoroutine = (this.mIterator.get_Current() as Coroutine);
								this.mChildCoroutine.mParentCoroutine = this;
							}
							else
							{
								bool isFinish = this.mChildCoroutine.IsFinish;
								if (isFinish)
								{
									object result2 = this.mChildCoroutine.Result;
									this.mChildCoroutine = null;
									bool flag6 = !this.mIterator.MoveNext();
									if (flag6)
									{
										this.mResult = result2;
										result = this.finish();
										return result;
									}
								}
							}
						}
						else
						{
							bool flag7 = this.mIterator.get_Current() is IYieldInstruction;
							if (flag7)
							{
								IYieldInstruction yieldInstruction = this.mIterator.get_Current() as IYieldInstruction;
								bool flag8 = yieldInstruction.Update(delta_time);
								bool flag9 = flag8 && !this.mIterator.MoveNext();
								if (flag9)
								{
									result = this.finish();
									return result;
								}
							}
							else
							{
								bool flag10 = this.mIterator.get_Current() is WWW;
								if (flag10)
								{
									WWW wWW = this.mIterator.get_Current() as WWW;
									bool flag11 = wWW.get_isDone() && !this.mIterator.MoveNext();
									if (flag11)
									{
										result = this.finish();
										return result;
									}
								}
								else
								{
									bool flag12 = this.mIterator.get_Current() is ResourceRequest;
									if (flag12)
									{
										ResourceRequest resourceRequest = this.mIterator.get_Current() as ResourceRequest;
										bool flag13 = resourceRequest.get_isDone() && !this.mIterator.MoveNext();
										if (flag13)
										{
											result = this.finish();
											return result;
										}
									}
									else
									{
										bool flag14 = this.mIterator.get_Current() is WaitForEndOfFrame;
										if (flag14)
										{
											Debug.LogError("SafeCoroutine 不支持 UnityEngine.WaitForEndOfFrame!");
											bool flag15 = !this.mIterator.MoveNext();
											if (flag15)
											{
												result = this.finish();
												return result;
											}
										}
										else
										{
											bool flag16 = this.mIterator.get_Current() is WaitForFixedUpdate;
											if (flag16)
											{
												Debug.LogError("SafeCoroutine 不支持 UnityEngine.WaitForFixedUpdate!");
												bool flag17 = !this.mIterator.MoveNext();
												if (flag17)
												{
													result = this.finish();
													return result;
												}
											}
											else
											{
												bool flag18 = this.mIterator.get_Current() is WaitForSeconds;
												if (flag18)
												{
													Debug.LogError("SafeCoroutine 不支持 UnityEngine.WaitForSeconds! 请使用 SafeCoroutine.SafeWaitForSeconds!");
													bool flag19 = !this.mIterator.MoveNext();
													if (flag19)
													{
														result = this.finish();
														return result;
													}
												}
												else
												{
													bool flag20 = !this.mIterator.MoveNext();
													if (flag20)
													{
														this.mResult = this.mIterator.get_Current();
														result = this.finish();
														return result;
													}
												}
											}
										}
									}
								}
							}
						}
					}
					result = false;
				}
			}
			return result;
		}
	}
}
