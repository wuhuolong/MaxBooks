using UnityEngine;
using Neptune;
using Neptune.External;

namespace xc.Dungeon
{
    /// <summary>
    /// 碰撞体
    /// </summary>
    public class ColliderObject : ILevelObject
    {
        private float m_initRadius = 0;
        SphereCollider m_collider;

        /// <summary>
        /// 需要作为导航节点
        /// </summary>
        public bool NeedNavigate = false;

        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="data"></param>
        public ColliderObject(Neptune.Collider data)
        : base(data)
        {
            LevelObjectHelper.SetObjectShapeCollider(gameObject, data.Shape);
            mLoadPrefabCoroutine = LevelObjectHelper.SetObjectPrefab(gameObject, data.PrefabInfo);

            var behaivour = gameObject.AddComponent<ColliderObjectBehaviour>();
            behaivour.Id = data.Id;
            m_collider = gameObject.GetComponent<SphereCollider>();
            if (m_collider != null)
                m_initRadius = m_collider.radius;
            DummyEventCollider info = data.EventInfo as DummyEventCollider;
            if (info != null)
            {
                behaivour.EnterId = (uint)info.EnterEventId;
                behaivour.ExitId = (uint)info.ExitEventId;
                behaivour.LifeTime = data.LifeTime;
            }

            NeedNavigate = data.NeedNavigate;
        }

        public void SetLocalPlayerRadius(float radius)
        {
            if (m_collider == null)
                return;
            m_collider.radius = m_initRadius - radius;
        }
    }
}
