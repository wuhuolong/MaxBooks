
using System;
using UnityEngine;
namespace xc
{
    public class PoolGameObject : MonoBehaviour
    {
        public ObjCachePoolType poolType;
        public string key;
        public bool DeleteByPool = false;


        private bool DestroyFromApplicationQuit = false;

        private void OnApplicationQuit()
        {
            DestroyFromApplicationQuit = true;
        }

        public void OnDestroy()
        {
            if(DeleteByPool)
            {
                return;
            }

            if (!DestroyFromApplicationQuit)
            {
                GameDebug.Log(string.Format("you should recycle this object from objcache pool {0}", gameObject.name));
            }
            
            ObjCachePoolMgr.Instance.RemoveFromCachePool(poolType, key, gameObject);
        }
    }
}

