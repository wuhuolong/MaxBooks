using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;

namespace xc
{
    public class CacheReleaser
    {
        private ReleaseCacheHandle release_handle_;

        public void register_release(ReleaseCacheHandle _handle)
        {
            if (_handle != null)
            {
                release_handle_ = (ReleaseCacheHandle)Delegate.Combine(release_handle_, _handle);
            }
        }

        public void release(List<object> _objects)
        {
            for (int i = 0; i < _objects.Count; i++)
            {
                release(_objects[i]);
            }
        }

        public void release(object _obj)
        {
            if (release_handle_ != null)
            {
                release_handle_(_obj);
            }
        }

        public void un_register_release(ReleaseCacheHandle _handle)
        {
            if (_handle != null)
            {
                release_handle_ = (ReleaseCacheHandle)Delegate.Remove(release_handle_, _handle);
            }
        }

        public delegate void ReleaseCacheHandle(object _obj);
    }
}
