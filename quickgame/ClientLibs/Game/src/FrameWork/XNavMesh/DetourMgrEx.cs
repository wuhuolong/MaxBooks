using System;
using System.Runtime.InteropServices;
#if NUNITY
using Vector3 = org.critterai.Vector3;
#else
using Vector3 = UnityEngine.Vector3;
#endif

namespace xc
{
    internal static class DetourMgrEx
    {
        /*
         * Design note: In order to stay compatible with Unity iOS, all
         * extern methods must be unique and match DLL entry point.
         * (Can't use EntryPoint.)
         */
#if UNITY_IPHONE && !UNITY_EDITOR
        private const string PLATFORM_DLL = "__Internal";
#else
        private const string PLATFORM_DLL = "cai-nav-rcn";
#endif

        [DllImport(PLATFORM_DLL)]
        public static extern bool detourMgrLoadFile(string file_path);

        [DllImport(PLATFORM_DLL)]
        public static extern bool detourMgrLoadBuffer([In] byte[] data);

        [DllImport(PLATFORM_DLL)]
        public static extern void detourMgrUnLoad();

        [DllImport(PLATFORM_DLL)]
        public static extern XNavMeshPathStatus detourMgrFindPath([In] ref Vector3 start, [In] ref Vector3 end, [In, Out] Vector3[] points, ushort exclude);

        [DllImport(PLATFORM_DLL)]
        public static extern bool detourMgrRayCast([In] ref Vector3 start, [In] ref Vector3 end, ref XNavMeshHit hit, ushort exclude);

        [DllImport(PLATFORM_DLL)]
        public static extern bool detourMgrSamplePosition([In] ref Vector3 pos, ref XNavMeshHit hit, float maxDistance, ushort exclude);
    }
}
