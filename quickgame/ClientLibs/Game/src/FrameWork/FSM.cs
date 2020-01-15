using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;

namespace xc
{
    public class Machine
    {
        public class State
        {
            public delegate void StateFunction(State s);

            protected State mParent;
            protected State mChild;
            protected State mOwner;
            protected uint mStateID;
            protected Machine mMachine;
            protected Dictionary<uint, State> mTransition;
            protected StateFunction mFuncEnter;
            protected StateFunction mFuncUpdate;
            protected StateFunction mFuncExit;

            public string Name
            {
                get
                {
                    return mStateID.ToString();
                }
            }
            
            public State(uint id, Machine machine)
            {
                _init(id, machine, null);
            }
            
            public void Reset(uint id, Machine machine, State owner)
            {
                _init(id, machine, owner);
            }

            public State(uint id, Machine machine, State owner)
            {
                _init(id, machine, owner);
            }
                
            protected void _init(uint id, Machine machine, State owner)
            {
                mStateID = id;
                mMachine = machine;
                mParent = null;
                mChild = null;
                mOwner = owner;
                mFuncEnter = null;
                mFuncUpdate = null;
                mFuncExit = null;

                if (mTransition == null)
                    mTransition = new Dictionary<uint, State>();
                else
                    mTransition.Clear();

                machine.AddState(this);
            }
            
            public uint GetID()
            {
                return mStateID;
            }
            
            public State GetOwner()
            {
                return mOwner;
            }
            
            public State GetChild()
            {
                return mChild;
            }
            
            public State GetParent()
            {
                return mParent;
            }
            
            public void SetChild(State s)
            {
                s.mParent = this;
                mChild = s;
            }
            
            public void AddTransition(uint e, State s)
            {
                if (!mTransition.ContainsKey(e))
                {
                    mTransition.Add(e, s);
                }
            }
            
            public State React(uint e)
            {
                State newState;
                if (!mTransition.TryGetValue(e, out newState))
                    return null;
                
                return newState;
            }
            
            public void SetEnterFunction(StateFunction func)
            {
                mFuncEnter = func;
            }
            
            public void SetUpdateFunction(StateFunction func)
            {
                mFuncUpdate = func;
            }
            
            public void SetExitFunction(StateFunction func)
            {
                mFuncExit = func;
            }
            
			protected void _enter( params object[] param )
            {
                if (mFuncEnter != null)
                    mFuncEnter(this);
                
                if (mChild != null)
					mChild.Enter(param);
            }
            
            public virtual void Enter( params object[] param )
            {
                _enter( param );
            }
            
            public virtual void Exit()
            {
                _exit();    
            }
            
            protected void _exit()
            {
                if (mFuncExit != null)
                    mFuncExit(this);
            }
            
            public virtual void Update()
            {
                _update();
            }
            
            protected void _update()
            {       
                if (mFuncUpdate != null)
                    mFuncUpdate(this);

                if (mChild != null)
                    mChild.Update();
            }

            public void Release()
            {
                if (mMachine != null)
                {
                    //mMachine.RemoveState(this);
                    mMachine = null;
                }
                   
                mParent = null;
                mChild = null;
                mOwner = null;
                mFuncEnter = null;
                mFuncUpdate = null;
                mFuncExit = null;
                mTransition.Clear();
            }

            public void Destroy()
            {
                mMachine = null;

                mParent = null;
                mChild = null;
                mOwner = null;
                mFuncEnter = null;
                mFuncUpdate = null;
                mFuncExit = null;
                mTransition.Clear();
            }
        }
        
        List<State> m_StateList;

        /// <summary>
        /// 将状态保存在状态机中，以免被gc销毁
        /// </summary>
        void AddState(State kState)
        {
            if(!m_StateList.Contains(kState))
                m_StateList.Add(kState);
        }

        /// <summary>
        /// 将状态移除
        /// </summary>
        void RemoveState(State kState)
        {
            if(m_StateList.Contains(kState))
                m_StateList.Remove(kState);
        }

        /// <summary>
        ///  获取所有的状态列表
        /// </summary>
        public List<State> StateList
        {
            get
            {
                return m_StateList;
            }
        }

        bool mIsDestroy = false;

        /// <summary>
        /// 取消对所有状态的Cache
        /// </summary>
        public void Destroy()
        {
            if (mIsDestroy)
                return;

            mIsDestroy = true;

            foreach (var state in m_StateList)
            {
                if (state != null)
                    state.Destroy();
            }

            m_StateList.Clear();
            mCurState = null;
        }

        /// <summary>
        /// 重置
        /// </summary>
        public void Reset()
        {
            foreach (var state in m_StateList)
            {
                if (state != null)
                    state.Destroy();
            }

            m_StateList.Clear();
            mCurState = null;

            mIsDestroy = false;
        }
        
        protected State mCurState = null;
        protected bool mDebug = false;
        
        public bool bIsDebug
        {
            get { return mDebug; }
            set { mDebug = value; }
        }
        
        public Machine()
        {
            mCurState = null;
            m_StateList = new List<State>();
        }

        ~ Machine()
        {
            Destroy();
        }
        
        // 此函数在状态机初始化时调用
        // 一旦设置好初始状态后，以后不能随意设置当前状态
        // 状态的切换只与事件相关
        public void SetCurState(State s)
        {
            if (mCurState != null)
            {
                Debug.LogError("[FSM] Error! 除了设置状态机初始状态外，不允许再强制设置状态。");
                return;
            }
            
            mCurState = s;
            s.Enter();

//          for (; s != null; s = s.GetChild())
//          {
//              s.Enter();
//          }
        }
        
        public State GetCurState()
        {
            return mCurState;
        }
        
        public void Update()
        {
            if (mCurState == null)
                return;
            
            mCurState.Update();
//          State cur = null;
//          for (cur = mCurState; cur != null; cur = cur.GetChild())
//          {
//              cur.Update();
//          }
        }
        
        // 响应事件，切换状态
        public virtual bool React(uint fsmEvent, params object[] param)
        {
            if (mCurState == null)
                return false;
            
            State lastNewState = _React_Inner(mCurState, fsmEvent, param);
            
            return lastNewState != null;
        }
        
        protected State _React_Inner(State cur, uint fsmEvent, params object[] param)
        {
            State topNewState = null;
            State lastNewState = null;
        
            for (; cur != null; cur = cur.GetChild())
            {
                State parentState = cur.GetParent();
                State newState = cur.React(fsmEvent);
                if (newState != null)
                {
                    if (newState.GetOwner() == cur.GetOwner())
                    {
                        // 状态转换
                        if (parentState != null)
                            parentState.SetChild(newState);
                        else
                            mCurState = newState;
                        
                        if (topNewState == null)
                            topNewState = newState;
                        
                        if (mDebug)
                        {
                            string curName = cur.Name;
                            string newName = newState.Name;
                            Debug.Log("[FSM] " + curName + "-->" + newName + " Event:" + fsmEvent.ToString());
                        }
                        
                        cur.Exit();
                        newState.Enter(param);
                        lastNewState = newState;
                    }
                }
            }
            
            // 新的状态应该继续响应事件，以确定他的子状态行为
            if (topNewState != null)
            {
                State st = _React_Inner(topNewState.GetChild(), fsmEvent);
                if (st != null)
                    lastNewState = st;
            }
            return lastNewState;
        }
        
        // 该函数用于判断当前状态机是否能够切换成功
        public virtual bool CanReact(uint fsmEvent)
        {
            if (mCurState == null)
                return false;
            
            State cur = mCurState;
        
            for (; cur != null; cur = cur.GetChild())
            {
                State newState = cur.React(fsmEvent);
                if (newState != null)
                {
                    if (newState.GetOwner() == cur.GetOwner())
                    {
                        return true;
                    }
                }
            }
            
            return false;
        }
    }

    public class ActMachine : Machine
    {
        public override bool CanReact(uint fsmEvent)
        {
            if (mCurState == null)
                return false;
            
            State cur = mCurState;

            bool topCanReact = false;// 第一次状态机转换成功后，其子状态也必须转换成功
            for (; cur != null; cur = cur.GetChild())
            {
                State newState = cur.React(fsmEvent);
                if (newState != null)
                {
                    if (newState.GetOwner() == cur.GetOwner())
                    {
                        if (topCanReact == false)
                            topCanReact = true; 
                    }
                    else if (topCanReact)
                        return false;

                }
                else if (topCanReact)
                    return false;
            }
            
            return topCanReact;
        }

        public override bool React(uint fsmEvent, params object[] param)
        {
            if (mCurState == null)
                return false;

            if (!CanReact(fsmEvent))
                return false;

            State lastNewState = _React_Inner(mCurState, fsmEvent, param);
            
            return lastNewState != null;
        }
    }
}


