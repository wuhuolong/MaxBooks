using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace Uranus.Runtime
{
    [Serializable]
    public class TransferAction : IAction
    {
        public uint InstanceId;
        public uint PosId;

        public override NodeStatus Execute()
        {
            xc.SceneHelp.JumpToScene(InstanceId, 0, PosId);
            return NodeStatus.SUCCESS;
        }
    }
}
