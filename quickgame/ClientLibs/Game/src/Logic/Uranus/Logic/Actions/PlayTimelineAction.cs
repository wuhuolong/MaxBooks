

using System;
using UnityEngine;

namespace Uranus.Runtime
{
    /// <summary>
    /// 播放Timeline剧情动画
    /// </summary>
    [Serializable]
    public class PlayTimelineAction : IAction
    {
        /// <summary>
        /// 剧情id
        /// </summary>
        public uint TimelineId;

        /// <summary>
        /// 剧情播放完毕后要跳转的副本，填0则不跳转
        /// </summary>
        public uint EnterInstanceIdWhenFinished;

        /// <summary>
        /// 剧情播放前玩家瞬移的位置，填Vector3.zero则不瞬移
        /// </summary>
        public Vector3 LocalPlayerPosWhenFinished = Vector3.zero;

        public override NodeStatus Execute()
        {
            bool canPlay = false;

            // 如果是新手剧情则不能重复播放
            if (TimelineId == xc.GameConstHelper.GetUint("GAME_OPENING_TIMELINE_ID"))
            {
                if (xc.TimelineManager.Instance.ShouldPlayOpenningTimeline() == true)
                {
                    canPlay = true;
                }
                else
                {
                    GameDebug.LogError("Error!!! Opening timeline have played!!!");
                    PlayFinishCallback();
                }
            }
            else
            {
                canPlay = true;
            }

            if (canPlay == true)
            {
                if (LocalPlayerPosWhenFinished.Equals(Vector3.zero) == false)
                {
                    //xc.TargetPathManager.Instance.StopPlayerAndReset();

                    Actor localPlayer = xc.Game.Instance.GetLocalPlayer();
                    if (localPlayer != null)
                    {
                        localPlayer.Stop();
                        localPlayer.MoveCtrl.TryWalkAlongStop();
                        localPlayer.MoveCtrl.SendFly(LocalPlayerPosWhenFinished);
                        //localPlayer.SetPosition(LocalPlayerPosWhenFinished);
                    }
                }

                xc.TimelineManager.Instance.Play(TimelineId, () =>
                {
                    PlayFinishCallback();
                });
            }
            return NodeStatus.SUCCESS;
        }

        void PlayFinishCallback()
        {
            if (LocalPlayerPosWhenFinished.Equals(Vector3.zero) == false)
            {
                Actor localPlayer = xc.Game.Instance.GetLocalPlayer();
                if (localPlayer != null)
                {
                    localPlayer.Stop();
                    localPlayer.MoveCtrl.TryWalkAlongStop();
                    localPlayer.MoveCtrl.SendFly(LocalPlayerPosWhenFinished);
                    localPlayer.SetPosition(LocalPlayerPosWhenFinished);
                }
            }

            if (EnterInstanceIdWhenFinished > 0)
            {
                xc.TargetPathManager.Instance.StopPlayerAndReset();
                xc.SceneHelp.JumpToScene(EnterInstanceIdWhenFinished);
            }
        }
    }
}
