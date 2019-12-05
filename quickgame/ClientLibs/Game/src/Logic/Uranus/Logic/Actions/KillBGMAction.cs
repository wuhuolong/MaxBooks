using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Uranus.Runtime
{
    /// <summary>
    /// 清除背景音乐，不再恢复，一般用于条副本前的剧情播放
    /// </summary>
    [Serializable]
    class KillBGMAction : IAction
    {
        public override NodeStatus Execute()
        {
            xc.AudioManager.Instance.KillMusic();
            return NodeStatus.SUCCESS;
        }
    }
}
