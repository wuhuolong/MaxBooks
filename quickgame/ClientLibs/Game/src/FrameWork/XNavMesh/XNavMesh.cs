using System.IO;
using UnityEngine;

namespace xc
{
    public class XNavMesh
    {
        protected const int MAX_CORNER = 50;

        public static bool LoadFile(string file_path)
        {
            if (File.Exists(file_path))
                return DetourMgrEx.detourMgrLoadFile(file_path);
            return false;
        }

        public static bool LoadBuffer(byte[] buffer)
        {
            return DetourMgrEx.detourMgrLoadBuffer(buffer);
        }

        public static void UnLoad()
        {
            DetourMgrEx.detourMgrUnLoad();
        }

        /// <summary>
        /// Calculate a path between two points and store the resulting path.
        /// </summary>
        /// <param name="sourcePosition">
        /// The initial position of the path requested.
        /// </param>
        /// <param name="targetPosition">
        /// The final position of the path requested.
        /// </param>
        /// <param name="exclude">
        /// 
        /// </param>
        /// <param name="path">
        /// The resulting path.
        /// </param>
        /// <returns>
        /// True if a either a complete or partial path is found and false otherwise.
        /// </returns>
        public static bool CalculatePath(Vector3 sourcePosition, Vector3 targetPosition, ushort exclude, XNavMeshPath path)
        {
            Vector3[] temp_corners = new Vector3[MAX_CORNER];
            path.status = DetourMgrEx.detourMgrFindPath(ref sourcePosition, ref targetPosition, temp_corners, exclude);
            if (path.status == XNavMeshPathStatus.PathComplete)
            {
                int len = temp_corners.Length;
                for (int i = 0; i < len; i++)
                {
                    if (temp_corners[i] != Vector3.zero)
                        path.AddCorner(temp_corners[i]);
                    else
                        break;
                }
                return true;
            }
            return false;
        }

        public static bool Raycast(Vector3 sourcePosition, Vector3 targetPosition, out XNavMeshHit hit, ushort exclude)
        {
            hit = new XNavMeshHit();
            return DetourMgrEx.detourMgrRayCast(ref sourcePosition, ref targetPosition, ref hit, exclude);
        }

        public static bool SamplePosition(Vector3 sourcePosition, out XNavMeshHit hit, float maxDistance, ushort exclude)
        {
            hit = new XNavMeshHit();
            return DetourMgrEx.detourMgrSamplePosition(ref sourcePosition, ref hit, maxDistance, exclude);
        }
    }
}
