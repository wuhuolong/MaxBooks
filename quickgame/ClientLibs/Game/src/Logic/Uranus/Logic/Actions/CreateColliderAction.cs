

using System;

namespace Uranus.Runtime
{
    /// <summary>
    /// 创建Collider
    /// </summary>
    [Serializable]
    public class CreateColliderAction : IAction
    {
        public int Id;

        public override NodeStatus Execute()
        {
            xc.Dungeon.ColliderObjectManager.Instance.CreateColliderObject(Id);
            return NodeStatus.SUCCESS;
        }
    }
}
