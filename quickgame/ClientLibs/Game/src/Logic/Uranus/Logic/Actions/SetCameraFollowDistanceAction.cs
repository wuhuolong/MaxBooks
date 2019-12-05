using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace Uranus.Runtime
{
    [Serializable]
    public class SetCameraFollowDistanceAction : IAction
    {
        public float followDistance;

        public override NodeStatus Execute()
        {
            if (xc.Game.Instance.CameraControl != null)
            {
                xc.Game.Instance.CameraControl.FollowDistance = followDistance;
            }
            return NodeStatus.SUCCESS;
        }
    }
}
