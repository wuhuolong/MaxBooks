using System;
using System.Collections.Generic;
using UnityEngine;

namespace SGameEngine
{
    public class ObjectPool
    {
        private List<IPoolable> objs;

        private int maxCap;

        private Func<IPoolable> factory;

        public ObjectPool(Func<IPoolable> factory, int maxCap = 100)
        {
            if (factory == null)
            {
                Debug.LogError("factory is null");
                return;
            }

            objs = new List<IPoolable>();
            this.factory = factory;
            this.maxCap = maxCap;
        }

        public void SetFactoryFunction(Func<IPoolable> factory)
        {
            this.factory = factory;
        }


        public void Free(IPoolable obj)
        {
            if (obj == null)
            {
                Debug.LogError("poolable object is nil");
                return;
            }

            if (objs.Count >= maxCap)
            {
                return;
            }

            obj.OnFreeToPool();

            objs.Add(obj);
        }

        public IPoolable Get()
        {
            if (objs.Count == 0)
            {
                return factory();
            }
            else
            {
                var obj = objs[objs.Count - 1];
                objs.RemoveAt(objs.Count - 1);

                obj.OnGetFromPool();

                return obj;
            }
        }

        public void ClearAll()
        {
            objs.Clear();
        }
    }
}