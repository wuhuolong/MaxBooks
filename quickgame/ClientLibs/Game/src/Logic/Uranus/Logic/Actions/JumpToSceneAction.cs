

using System;

namespace Uranus.Runtime
{
    /// <summary>
    /// 跳转场景
    /// </summary>
    [Serializable]
    public class JumpToSceneAction : IAction
    {
        public uint SceneId;
        public override NodeStatus Execute()
        {
            xc.SceneHelp.JumpToScene(SceneId);
            return NodeStatus.SUCCESS;
        }
    }
}
