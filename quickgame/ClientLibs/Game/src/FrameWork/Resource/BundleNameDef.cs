using UnityEngine;
using System.Collections;

namespace SGameEngine
{
	public abstract class BundleNameDef  
	{
		public static readonly string MAIN = "1"; // version 和 bundleinfo 等assetbundle中的mainasset
		public static readonly string FBX_INF = "fbx_inf";
		public static readonly string FORCED_MEMBER_PREFIX = "forced_mem";
		public static readonly string FIRST_BUNDLE_MEMBER_PREFIX = "first_bundle_mem";
		public static readonly string LOADABLE_MEM_PREFIX = "loadable_men";
	}
}
