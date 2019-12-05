//************************************
//  ResourceUtil.cs
//  define some method to operate the resource-sensitive objcet
//  Created by leon @INCEPTION .
//  Last modify 14-12-19 : refactor
//************************************
using UnityEngine;
using System.Collections;
using System.Collections.Generic;

namespace SGameEngine
{

    public class ResourceUtilEx : MonoBehaviour
	{

        public static ResourceUtilEx Instance;

        private void Awake()
        {
            if (Instance != null)
            {
                Debug.LogError("you inited ResourceUtilEx twice!");
                Destroy(this);
                return;
            }
            Instance = this;
        }

		private class HostResInfo
		{
			public GameObject game_obj_;
			public AssetResource res_;
		}

		private List<HostResInfo> lst_host_res_inf_ = new List<HostResInfo>();


        //--------------------------------------------
        // 外部接口
        //--------------------------------------------

        /// <summary>
        /// 将某个资源托管到某个gameobject上，当这个gameobject没有了，自动释放托管在上面的这个资源
        /// </summary>
		public void host_res_to_gameobj(GameObject _go, AssetResource _res)
		{
			HostResInfo hri = new HostResInfo();
			hri.game_obj_ = _go;
			hri.res_ = _res;
			lst_host_res_inf_.Add(hri);
		}

		////////////////////////////////////////mono inhreit interfaces/////////////////////////////////////////


	    // ************************************
        // internal interfaces
        // ************************************

        /// <summary>
        /// 清除已销毁GameObject上对应的AssetResource
        /// </summary>
		public void gc(float _delta_time)
		{
			foreach(HostResInfo hgi in lst_host_res_inf_)
			{
				if(hgi.game_obj_==null)
				{
					hgi.res_.destroy();
				}
			}
			lst_host_res_inf_.RemoveAll(item => item.game_obj_ == null);
		}

#if UNITY_EDITOR
		public void dump()
		{
			Debug.Log("resource util dump");
			foreach(HostResInfo hgi in lst_host_res_inf_)
			{
				Debug.Log(string.Format("game obj {0} host ar {1}", hgi.game_obj_, hgi.res_.asset_.name));
			}
		}
#endif

	}
}
