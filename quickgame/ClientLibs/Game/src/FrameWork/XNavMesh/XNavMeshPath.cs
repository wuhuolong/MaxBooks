using System.Collections.Generic;
using UnityEngine;

namespace xc
{
    public class XNavMeshPath
    {
        /// <summary>
        /// XNavMeshPath constructor.
        /// </summary>
        public XNavMeshPath()
        {
            mCorners = new List<Vector3>();
        }

        /// <summary>
        /// Corner points of the path.
        /// </summary>
        public Vector3[] corners
        {
            get
            {
                return mCorners.ToArray();
            }
        }
        protected List<Vector3> mCorners;

        /// <summary>
        /// Status of the path.
        /// </summary>
        public XNavMeshPathStatus status { get; set; }

        /// <summary>
        /// Erase all corner points from path.
        /// </summary>
        public void ClearCorners()
        {
            mCorners.Clear();
        }

        /// <summary>
        /// Calculate the corners for the path.
        /// </summary>
        /// <param name="results">
        /// Array to store path corners.
        /// </param>
        /// <returns>
        /// The number of corners along the path - including start and end points.
        /// </returns>
        public int GetCornersNonAlloc(Vector3[] results)
        {
            return 0;
        }

        public void AddCorner(Vector3 pos)
        {
            mCorners.Add(pos);
        }
    }
}
