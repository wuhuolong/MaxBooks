

using System;

namespace Uranus.Runtime
{
    /// <summary>
    /// 激活场景里面下雨特效
    /// </summary>
    [Serializable]
    public class SceneActiveRainAction : IAction
    {
        public bool IsActive;

        public override NodeStatus Execute()
        {
            xc.XSceneManager.Instance.ActiveRain(IsActive);
            return NodeStatus.SUCCESS;
        }
    }
}
