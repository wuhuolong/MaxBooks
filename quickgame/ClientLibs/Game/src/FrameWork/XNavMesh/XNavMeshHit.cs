using UnityEngine;

namespace xc
{
    /// <summary>
    /// Result information for NavMesh queries.
    /// </summary>
    public struct XNavMeshHit
    {
        /// <summary>
        /// Position of hit.
        /// </summary>
        public Vector3 position { get; set; }

        /// <summary>
        /// Normal at the point of hit.
        /// </summary>
        public Vector3 normal { get; set; }

//         /// <summary>
//         /// Distance to the point of hit.
//         /// </summary>
//         public float distance { get; set; }
// 
//         /// <summary>
//         /// Mask specifying NavMesh area at point of hit.
//         /// </summary>
//         public int mask { get; set; }
// 
//         /// <summary>
//         /// Flag set when hit.
//         /// </summary>
//         public bool hit { get; set; }
    }
}
