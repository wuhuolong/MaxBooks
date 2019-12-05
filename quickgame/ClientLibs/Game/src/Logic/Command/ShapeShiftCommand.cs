//------------------------------------------
// File: ShapeShiftCommand.cs
// Desc: 角色变身命令
// Author: raorui
// Date: 2017.11.4
//------------------------------------------
using System;
using System.Collections;
using System.Collections.Generic;

namespace xc
{
    public class ShapeShiftCommand : ICommand
    {
        WeakReference m_Receiver;

        /// <summary>
        /// 获取命令的Reciver
        /// </summary>
        public AvatarCtrl Receiver
        {
            get
            {
                if (m_Receiver != null && m_Receiver.IsAlive)
                {
                    return (AvatarCtrl)m_Receiver.Target;
                }
                else
                    return null;
            }

            set
            {
                if (m_Receiver == null || !m_Receiver.IsAlive)
                {
                    m_Receiver = new WeakReference(value);
                }
                else
                    m_Receiver.Target = value;
            }
        }

        /// <summary>
        /// 变身对象在角色表中的id
        /// </summary>
        protected uint mTypeId;

        /// <summary>
        /// 变身状态
        /// </summary>
        protected byte mShiftState;

        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="receiver">命令的实际执行对象</param>
        /// <param name="type_id">变身的角色id</param>
        public ShapeShiftCommand(AvatarCtrl receiver, uint type_id, byte shift_state)
        {
            Receiver = receiver;
            mTypeId = type_id;
            mShiftState = shift_state;
            m_Status = CommandStatus.NONE;
        }

        /// <summary>
        /// 执行命令
        /// </summary>
        public override void Execute()
        {
            m_Status = CommandStatus.START;
            MainGame.HeartBehavior.StartCoroutine(Shift());
        }

        /// <summary>
        /// 打断命令
        /// </summary>
        public override bool Interrupt()
        {
            if (m_Status == CommandStatus.NONE || m_Status == CommandStatus.FINISH)
            {
                // DO NOTHING
                return true;
            }
            else if(m_Status == CommandStatus.START)
            {
                m_Status = CommandStatus.INTERRUPT;
                return false;
            }

            return true;
        }

        IEnumerator Shift()
        {
            yield return MainGame.HeartBehavior.StartCoroutine(Receiver.ShapeShiftImpl(mTypeId, mShiftState));
            if(m_Status == CommandStatus.INTERRUPT)
            {
                // DO NOTHING
            }
            else
                m_Status = CommandStatus.FINISH;
        }
    }
}
