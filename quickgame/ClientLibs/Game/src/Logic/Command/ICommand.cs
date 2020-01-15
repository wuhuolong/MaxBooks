//------------------------------------------
// File: ICommand.cs
// Desc: 命令的接口
// Author: raorui
// Date: 2017.11.4
//------------------------------------------
using System;
using System.Collections;
using System.Collections.Generic;

namespace xc
{
    /// <summary>
    /// 命令执行的状态
    /// </summary>
    public enum CommandStatus
    {
        NONE,// 未开始
        START,// 已开始
        FINISH,// 已完成
        INTERRUPT// 被打断
    }

    public class ICommand
    {
        protected CommandStatus m_Status;

        public bool IsFinish
        {
            get
            {
                return m_Status == CommandStatus.FINISH;
            }
        }

        public bool IsInterrupted
        {
            get
            {
                return m_Status == CommandStatus.INTERRUPT;
            }
        }

        /// <summary>
        /// 执行命令
        /// </summary>
        public virtual void Execute() { }

        /// <summary>
        /// 打断命令
        /// </summary>
        public virtual bool Interrupt() { return true; }
    }
}
