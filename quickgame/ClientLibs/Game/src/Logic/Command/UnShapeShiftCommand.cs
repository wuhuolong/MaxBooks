//------------------------------------------
// File: UnShapeShiftCommand.cs
// Desc: 角色变身恢复的命令
// Author: raorui
// Date: 2017.11.4
//------------------------------------------
using System;
using System.Collections;
using System.Collections.Generic;

namespace xc
{
    public class UnShapeShiftCommand : ShapeShiftCommand
    {

        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="receiver">命令的实际执行对象</param>
        /// <param name="type_id">变身的角色id</param>
        public UnShapeShiftCommand(AvatarCtrl receiver, uint type_id, byte shift_state):base(receiver, type_id, shift_state)
        {

        }

        /// <summary>
        /// 执行命令
        /// </summary>
        public override void Execute()
        {
            m_Status = CommandStatus.START;
            MainGame.HeartBehavior.StartCoroutine(UnShift());
        }

        IEnumerator UnShift()
        {
            yield return MainGame.HeartBehavior.StartCoroutine(Receiver.UnShapeShifeImpl(mTypeId, mShiftState));
            if (m_Status == CommandStatus.INTERRUPT)
            {
                // DO NOTHING
            }
            else
                m_Status = CommandStatus.FINISH;
        }
    }
}
