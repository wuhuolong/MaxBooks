//------------------------------------------------------------------------------
// 物理计算辅助模块
//------------------------------------------------------------------------------
using System;
using UnityEngine;
using UnityEngine.AI;
namespace xc
{
    public class PhysicsHelp
    {
        public const float ILLEGAL_HEIGHT = -20.0f;
        public PhysicsHelp()
        {
        }

        static Vector3 originPosInGetHeight = new Vector3(0.0f, 200.0f, 0.0f);
        static float nearestYPos = -100.0f;
        public static float GetHeight(float x, float z)
        {
            // 游戏的Y区域必须位于-20 ~ 20之间
            // 避免new在这里函数降低了7%左右的开销
            originPosInGetHeight.x = x;
            originPosInGetHeight.z = z;

            RaycastHit hit;
            if (Physics.Raycast(originPosInGetHeight, Vector3.down, out hit, 500.0f, 1 << LayerMask.NameToLayer("Collision")))
                return hit.point.y;
            return ILLEGAL_HEIGHT;

            /*if(nearestYPos == -100.0f)
            {
                XNavMeshHit nesrestHit;
                if (XNavMesh.SamplePosition(originPosInGetHeight, out nesrestHit, 1000.0f , -1))
                {
                    nearestYPos = nesrestHit.position.y;
                    originPosInGetHeight.y = nearestYPos;
                }
            }

            XNavMeshHit hit;
            if (XNavMesh.SamplePosition(originPosInGetHeight, out hit, 10.0f , -1))
                return hit.position.y;
            return ILLEGAL_HEIGHT;*/
        }

        public static Vector3 GetPosition(float x, float z)
        {
            return new Vector3(x, GetHeight(x, z), z);
        }

        /// <summary>
        /// 在碰撞检测时的Radius位置
        /// </summary>
        /// <param name="src_pos"></param>
        /// <param name="hit_pos"></param>
        public static Vector3 BoundaryHitPos(Vector3 src_pos, Vector3 hit_pos)
        {
            float dis = Vector3.Distance(src_pos, hit_pos);
            if (dis < 0.1)
                return src_pos;

            Vector3 target_pos = src_pos + (hit_pos - src_pos) * ((dis - 0.1f) / dis);
            return target_pos;
        }
    }
}

