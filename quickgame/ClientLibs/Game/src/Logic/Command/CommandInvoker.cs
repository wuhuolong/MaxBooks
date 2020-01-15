//------------------------------------------
// File: CommandInvoker.cs
// Desc: 命令队列
// Author: raorui
// Date: 2017.11.4
//------------------------------------------
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace xc
{
    public class CommandInvoker
    {
        /// <summary>
        /// 等待执行的命令队列
        /// </summary>
        private Queue<ICommand> m_WaitQueue = new Queue<ICommand>();

        /// <summary>
        /// 当命令不能够被回收的时候，需要放入此队列中
        /// </summary>
        //private List<ICommand> m_RemoveCommands = new List<ICommand>();

        /// <summary>
        /// 正在执行的协程
        /// </summary>
        private Coroutine m_Coroutine;

        /// <summary>
        /// 添加一个命令到队列中
        /// </summary>
        /// <param name="command"></param>
        public void PushCommand(ICommand command)
        {
            m_WaitQueue.Enqueue(command);
        }

        /// <summary>
        /// 清除队列中的所有队列，并对已执行但是未完成的命令执行Interrupte操作
        /// </summary>
        void ClearCommand()
        {
            if(m_WaitQueue.Count > 0)
            {
                foreach(var command in m_WaitQueue)
                {
                    bool succ = command.Interrupt();
                    if(!succ)// 如果打断失败，需要将Command移动到m_RemoveCommands中等待其中的协程完毕在进行Clean操作
                    {
                        //m_RemoveCommands.Add(command);
                    }
                }
                m_WaitQueue.Clear();
            }
        }

        /// <summary>
        /// 从队列中取出命令进行执行
        /// </summary>
        public IEnumerator Execute()
        {
            while (m_WaitQueue.Count <= 0)
            {
                yield return null;
            }

            var command = m_WaitQueue.Dequeue();
            command.Execute();

            // 等待上一次的命令执行完毕
            while (command.IsFinish == false && command.IsInterrupted == false)
            {
                yield return null;
            }

            if (m_Coroutine != null)
            {
                MainGame.HeartBehavior.StopCoroutine(m_Coroutine);
            }
            m_Coroutine = MainGame.HeartBehavior.StartCoroutine(Execute());
        }

        /// <summary>
        /// 开始命令的调用
        /// </summary>
        public void Start()
        {
            m_Coroutine = MainGame.HeartBehavior.StartCoroutine(Execute());
        }

        /// <summary>
        /// 停止命令的调用
        /// </summary>
        public void Stop()
        {
            if(m_Coroutine != null)
            {
                MainGame.HeartBehavior.StopCoroutine(m_Coroutine);
                m_Coroutine = null;
            }
            ClearCommand();
        }
    }
}
