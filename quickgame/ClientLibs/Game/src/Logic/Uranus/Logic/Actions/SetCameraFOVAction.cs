using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace Uranus.Runtime
{
    [Serializable]
    public class SetCameraFOVAction : IAction
    {
        public float FOV;

        public override NodeStatus Execute()
        {
            if (xc.Game.Instance.CameraControl != null)
            {
                xc.Game.Instance.CameraControl.FOV = FOV;
            }
            return NodeStatus.SUCCESS;
        }
    }
}
