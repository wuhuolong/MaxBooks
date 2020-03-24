/// <summary>
/// 协程
/// 
/// 特性：
/// 1.可扩展：
///     通过继承IYieldInstruction可以派生出自己的等待指令
/// 2.支持返回值：
///     返回值指的是协程内最后一个yield return返回的值
///     通过Coroutine.HasResult判断是否有返回值，通过Coroutine.Result获取返回值。
/// 3.可暂停/恢复：
///     通过Coroutine.Pause和Coroutine.Resume可暂停和恢复协程
///     通过Coroutine.Stop终止协程执行
/// 4.支持嵌套：
///     在协程内可以开启另一个协程，这样2者形成父子关系，子协程受父协程影响，暂停父协程会同时暂停子协程。
///     通过Coroutine.IsPaused判断自己是否在运行中
///     通过Coroutine.IsSelfPaused判断自己是否被暂停（父亲被暂停不算）
///     通过Coroutine.IsParentPaused判断父亲是否被暂停
/// 5.不依赖MonoBehaviour：
///     通过SafeCoroutine.CoroutineManager.StartCoroutine()开启协程
/// 6.支持yield return UnityEngine.WWW 和 UnityEngine.ResourceRequest
///     
/// 注意：
/// 1.不支持UnityEngine的WaitForEndOfFrame、WaitForFixedUpdate
/// 2.不支持UnityEngine.WaitForSeconds，但可以改用SafeCoroutine.SafeWaitForSeconds
/// </summary>
using UnityEngine;
using System.Collections;

namespace SafeCoroutine
{
    /// <summary>
    /// 安全的协程
    /// </summary>
    public class Coroutine : IYieldInstruction
    {
        /// <summary>
        /// 协程的状态
        /// </summary>
        public enum EState
        {
            NotInit = 0, // 未初始化
            Stopped = 1, // 完成了或停止了
            Running = 2, // 运行中（但有可能因为父亲被暂停而无法运行）
            Paused = 3,  // 暂停了
        }

        /// <summary>
        /// 协程
        /// C#中的协程就是用IEnumerator实现的
        /// </summary>
        protected IEnumerator mIterator;

        /// <summary>
        /// 孩子协程
        /// 在自身运行中开启的子协程
        /// </summary>
        protected Coroutine mChildCoroutine;

        /// <summary>
        /// 父亲协程
        /// </summary>
        protected Coroutine mParentCoroutine;

        /// <summary>
        /// 当前状态
        /// </summary>
        protected EState mState = EState.NotInit;
        public EState State
        {
            get { return mState; }
        }

        /// <summary>
        /// 协程的返回值
        /// </summary>
        protected object mResult;
        public object Result
        {
            get { return mResult; }
        }

		/// <summary>
		/// 协程是否有返回值
		/// </summary>
		/// <value>mResult不为null则返回true</value>
		public bool HasResult
		{
			get { return mResult != null; }
		}

        /// <summary>
        /// 是否在运行状态（父亲被暂停也返回true）
        /// </summary>
        public bool IsRunning
        {
            get { return mState == EState.Running; }
        }

        /// <summary>
        /// 是否在stop状态
        /// </summary>
        public bool IsFinish
        {
            get { return mState == EState.Stopped; }
        }

        /// <summary>
        /// 是否在暂停中
        /// 自己被暂停或者父亲被暂停都返回true
        /// </summary>
        public bool IsPause
        {
            get { return mState == EState.Paused || IsParentPaused; }
        }

        /// <summary>
        /// 是否自己被暂停
        /// </summary>
        public bool IsSelfPaused
        {
            get { return mState == EState.Paused; }
        }

        /// <summary>
        /// 父亲是否在暂停中
        /// </summary>
        protected bool IsParentPaused
        {
            get
            {
                if (mParentCoroutine == null)
                    return false;

                return mParentCoroutine.IsPause;
            }
        }

        public Coroutine(IEnumerator itr)
        {
            mIterator = itr;

            if (mIterator != null)
            {
                mState = EState.Running;
                mIterator.MoveNext();
            }
            else
            {
                mState = EState.Stopped;
            }
        }

        /// <summary>
        /// 协程完成了
        /// </summary>
        /// <returns>只返回true</returns>
        private bool finish()
        {
            mState = EState.Stopped;

			if (mParentCoroutine != null)
			{
				mParentCoroutine = null;
			}

            return true;
        }

        /// <summary>
        /// 暂停协程
        /// </summary>
        public void Pause()
        {
            if (mState == EState.Running)
            {
                mState = EState.Paused;
            }
            else
            {
                logStateError("Pause");
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="function_name"></param>
        protected void logStateError(string function_name)
        {
            Debug.LogWarning("Coroutine." + function_name + " error! state = " + mState);
        }

        /// <summary>
        /// 恢复协程
        /// </summary>
        public void Resume()
        {
            if (mState == EState.Paused)
            {
                mState = EState.Running;
            }
            else
            {
                logStateError("Resume");
            }
        }

        /// <summary>
        /// 停止协程
        /// 会把孩子协程也停止了
        /// </summary>
        public void Stop()
        {
            mIterator = null;
            mState = EState.Stopped;

            if (mChildCoroutine != null)
            {
                mChildCoroutine.Stop();
				mChildCoroutine = null;
			}
			else if (mParentCoroutine != null)
			{
				mParentCoroutine = null;
			}
        }

        /// <summary>
        /// 每帧调用
        /// </summary>
        /// <param name="delta_time"></param>
        /// <returns>完成了返回true</returns>
        public bool Update(float delta_time)
        {
            if (mIterator == null)
                return finish();

            if (IsPause)
                return false;

            if (mIterator.Current == null)
            {
                if (!mIterator.MoveNext())
                    return finish();
            }
            else if (mIterator.Current is Coroutine)
            {
                // 当前执行的是子协程
                // 子协程不需要在这里更新，它会在CoroutineManager里更新
                if (mChildCoroutine == null)
                {
                    // 第一次执行，设置父子关系
                    mChildCoroutine = mIterator.Current as Coroutine;
                    mChildCoroutine.mParentCoroutine = this;
                }
                else if (mChildCoroutine.IsFinish)
                {
                    // 如果已经完成了，执行下一步
					var child_result = mChildCoroutine.Result;
                    mChildCoroutine = null;

                    if (!mIterator.MoveNext())
					{
						mResult = child_result;
						return finish();
					}
				}
            }
            else if (mIterator.Current is IYieldInstruction)
            {
                // 当前执行的是普通的yield指令
                var yieldBase = mIterator.Current as IYieldInstruction;

                // 更新指令
                bool result = yieldBase.Update(delta_time);
                if (result && !mIterator.MoveNext())
                    return finish();
            }
            else if (mIterator.Current is UnityEngine.WWW)
            {
                var www = mIterator.Current as UnityEngine.WWW;
                if (www.isDone && !mIterator.MoveNext())
                {
                    return finish();
                }
            }
            else if (mIterator.Current is UnityEngine.ResourceRequest)
            {
                var request = mIterator.Current as UnityEngine.ResourceRequest;
                if (request.isDone && !mIterator.MoveNext())
                {
                    return finish();
                }
            }
            else if (mIterator.Current is UnityEngine.WaitForEndOfFrame)
            {
                Debug.LogError("SafeCoroutine 不支持 UnityEngine.WaitForEndOfFrame!");
                
                if (!mIterator.MoveNext())
                {
                    return finish();
                }
            }
            else if (mIterator.Current is UnityEngine.WaitForFixedUpdate)
            {
                Debug.LogError("SafeCoroutine 不支持 UnityEngine.WaitForFixedUpdate!");

                if (!mIterator.MoveNext())
                {
                    return finish();
                }
            }
            else if (mIterator.Current is UnityEngine.WaitForSeconds)
            {
                Debug.LogError("SafeCoroutine 不支持 UnityEngine.WaitForSeconds! 请使用 SafeCoroutine.SafeWaitForSeconds!");

                if (!mIterator.MoveNext())
                {
                    return finish();
                }
            }
            else
            {
                if (!mIterator.MoveNext())
                {
                    // 已经没有下一步了，设置完成状态
                    mResult = mIterator.Current;
                    return finish();
                }
            }

            return false;
        }
    }
}
