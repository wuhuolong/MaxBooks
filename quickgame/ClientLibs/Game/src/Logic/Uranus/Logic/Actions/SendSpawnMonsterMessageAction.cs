using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace Uranus.Runtime
{
    [Serializable]
    public class SendSpawnMonsterMessageAction : IAction
    {
        public uint id;

        public override NodeStatus Execute()
        {
            Net.C2SNwarClientSpawnMon msg = new Net.C2SNwarClientSpawnMon();
            msg.id = id;
            Net.NetClient.CrossClient.SendData<Net.C2SNwarClientSpawnMon>(xc.protocol.NetMsg.MSG_NWAR_CLIENT_SPAWN_MON, msg);

            return NodeStatus.SUCCESS;
        }
    }
}
