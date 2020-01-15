using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace xc
{
    [wxb.Hotfix]
    class TimelinePlayableEmployee : ITimelinePlayableEmployee
    {
        /// <summary>
        /// 本地玩家瞬移
        /// </summary>
        /// <param name="pos"></param>
        public void SetLocalPlayerPosition(Vector3 pos)
        {
            Actor localPlayer = Game.Instance.GetLocalPlayer();
            if (localPlayer != null)
            {
                localPlayer.Stop();
                localPlayer.MoveCtrl.TryWalkAlongStop();
                localPlayer.MoveCtrl.SendFly(pos);
                localPlayer.SetPosition(pos);
            }
        }

        /// <summary>
        /// 设置本地玩家旋转
        /// </summary>
        /// <param name="rotation"></param>
        public void SetLocalPlayerRotation(Quaternion rotation)
        {
            Actor localPlayer = Game.Instance.GetLocalPlayer();
            if (localPlayer != null)
            {
                localPlayer.TurnDir(rotation.eulerAngles);
            }
        }

        /// <summary>
        /// 本地玩家显示和隐藏
        /// </summary>
        /// <param name="pos"></param>
        public void SetLocalPlayerVisible(bool visible)
        {
            Actor localPlayer = Game.Instance.GetLocalPlayer();
            if (localPlayer != null)
            {
                localPlayer.mVisibleCtrl.SetActorVisible(visible, VisiblePriority.NORMAL);
            }
        }
    }
}