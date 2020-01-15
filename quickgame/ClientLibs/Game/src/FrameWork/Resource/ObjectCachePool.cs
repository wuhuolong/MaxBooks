namespace SGameEngine
{
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Runtime.CompilerServices;
    using System.Runtime.InteropServices;
    using UnityEngine;

    public class ObjectCachePool
    {
        public static bool keep_cache_when_rent_ = true;
        private int block_limit_count_;
        private int cache_block_max_count_;
        private float last_update_time_;
        private CacheReleaser releaser_;
        private List<CachedObjectInfo> pool_ = new List<CachedObjectInfo>();
     
		public const float update_frequency_ = 5f;
        private  float worn_time_ ;
		public GameObject root_node_;


		public ObjectCachePool(CacheReleaser _releaser, int _max_cache_count = 64, int _cache_limit_count = 128, float _worn_time = 60f, GameObject _root_node = null)
        {
            cache_block_max_count_ = _max_cache_count;
            block_limit_count_ = _cache_limit_count;
			worn_time_ = _worn_time;
			root_node_ = _root_node;
            releaser_ = _releaser;
            last_update_time_ = Time.time;
            init_pool();
        }

        public bool add_cache(object _key, object _value)
        {
            if ((_key == null) || (_value == null))
            {
                return false;
            }
            CachedObjectInfo cache_info = get_cache_info(_key);
            if (cache_info == null)
            {
                cache_info = add_cache_info(_key);
                if (cache_info == null)
                {
                    return false;
                }
            }
            if (cache_info.cached_obj(_value.GetHashCode()))
            {
                cache_info.add_to_cache(_value);
                return true;
            }
            if (get_cache_count() >= cache_block_max_count_)
            {
                try_fix_pool();
            }
            if (get_cache_count() > cache_block_max_count_)
            {
                return false;
            }
            cache_info.add_to_cache(_value);
            return true;
        }

		public void remove_from_cache(string _key, object _value)
		{
			if ((_key == null) || (_value == null))
			{
				return ;
			}
			CachedObjectInfo cache_info = get_cache_info(_key);
			if (cache_info == null)
			{
				return;
			}
			cache_info.remove_from_cache(_value.GetHashCode());
		}

        private CachedObjectInfo add_cache_info(object _key)
        {
            if (_key == null)
            {
                return null;
            }
            if (is_contain_cache_info(_key))
            {
                return get_cache_info(_key);
            }
            CachedObjectInfo item = new CachedObjectInfo();
            item.init_cache(_key, releaser_);
            pool_.Add(item);
            return item;
        }

        public void clear_all_cache()
        {
            for (int i = 0; i < pool_.Count; i++)
            {
                if (pool_[i] != null)
                {
                    pool_[i].shrink(pool_[i].get_free_cache_count());
                }
            }
        }

        public void clear_cache(object _key)
        {
            CachedObjectInfo cache_info = get_cache_info(_key);
            if (cache_info != null)
            {
                cache_info.shrink(cache_info.get_free_cache_count());
            }
        }

        public int get_cache_count()
        {
            int num = 0;
            for (int i = 0; i < pool_.Count; i++)
            {
                num += pool_[i].get_total_cache_count();
            }
            return num;
        }

        public int get_cache_count(object _key)
        {
            CachedObjectInfo cache_info = get_cache_info(_key);
            if (cache_info == null)
            {
                return 0;
            }
            return cache_info.get_total_cache_count();
        }

        private CachedObjectInfo get_cache_info(object _key)
        {
            for (int i = 0; i < pool_.Count; i++)
            {
                if (pool_[i].equals_key(_key))
                {
                    return pool_[i];
                }
            }
            return null;
        }

        public int get_free_cache_count()
        {
            int num = 0;
            for (int i = 0; i < pool_.Count; i++)
            {
                num += pool_[i].get_free_cache_count();
            }
            return num;
        }

        public int get_free_cache_count(object _key)
        {
            CachedObjectInfo cache_info = get_cache_info(_key);
            if (cache_info == null)
            {
                return 0;
            }
            return cache_info.get_free_cache_count();
        }

        public void init_pool()
        {
            if (pool_ == null)
            {
                pool_ = new List<CachedObjectInfo>();
            }
        }

        private bool is_contain_cache_info(object _key)
        {
            for (int i = 0; i < pool_.Count; i++)
            {
                if (pool_[i].equals_key(_key))
                {
                    return true;
                }
            }
            return false;
        }

        public int shrink_cache(object _key, int _max_shrink_count)
        {
            CachedObjectInfo cache_info = get_cache_info(_key);
            if ((cache_info != null) && (_max_shrink_count > 0))
            {
                return cache_info.shrink(_max_shrink_count);
            }
            return 0;
        }

        private void try_fix_pool()
        {
            int free_cache_count = get_free_cache_count();
            int cache_count = get_cache_count();
            if ((((float) cache_count) / ((float) cache_block_max_count_)) >= 0.9f)
            {
                if ((((float) free_cache_count) / ((float) cache_count)) < 0.2f)
                {
                    cache_block_max_count_ += 32;
                    if (cache_block_max_count_ > block_limit_count_)
                    {
                        cache_block_max_count_ = block_limit_count_;
                    }
                }
                else
                {
                    for (int i = 0; i < pool_.Count; i++)
                    {
                        CachedObjectInfo info = pool_[i];
                        int num = info.get_free_cache_count();
                        info.shrink(num / 2);
                    }
                }
            }
        }

        public object try_hit_cache(object _key)
        {
            if (_key == null)
            {
                return null;
            }
            CachedObjectInfo cache_info = get_cache_info(_key);
            if (cache_info == null)
            {
                return null;
            }
            object obj = cache_info.try_hit_cache();
            if (obj != null)
            {
                cache_info.update_weight(Time.time);
            }
            return obj;
        }

        public void update()
        {
            float time = Time.time;
            if ((time - last_update_time_) >= update_frequency_)
            {
                last_update_time_ = time;
                if (pool_ != null)
                {
                    int index = UnityEngine.Random.Range(0, pool_.Count);
                    if ((index >= 0) && (index < pool_.Count))
                    {
                        CachedObjectInfo info = pool_[index];
                        if (info == null)
                        {
                            pool_.RemoveAt(index);
                        }
                        else
                        {
                            float num = Time.time - info.get_weight();
                            int max_shrink_count = (int) (num / worn_time_);
                            if (max_shrink_count > 0)
                            {
                                int free_cache_count = info.get_free_cache_count();
                                if (free_cache_count <= 0)
                                {
                                    pool_.RemoveAt(index);
                                }
                                else
                                {
                                    max_shrink_count = (max_shrink_count <= free_cache_count) ? max_shrink_count : free_cache_count;
                                    info.shrink(max_shrink_count);
                                }
                            }
                        }
                    }
                }
            }
        }

		public Transform get_root_node()
		{
			//when app exit, the root_node may release first, at this time we return null;
			return root_node_!=null ? root_node_.transform : null;
		}

        public class CachedObjectInfo
        {
            private object key_;
            private Hashtable hash_table_objects_ = new Hashtable();
            private Hashtable hash_table_status_ = new Hashtable();
            private ArrayList key_array_ = new ArrayList();
            private ObjectCachePool.CacheReleaser releaser_;
            private float weight_ = 0f;

            public void add_to_cache(object _value)
            {
                int hash_code = _value.GetHashCode();
                if (ObjectCachePool.keep_cache_when_rent_)
                {
                    if (key_array_.Contains(hash_code))
                    {
                        hash_table_status_[hash_code] = true;
                    }
                    else
                    {
                        key_array_.Add(hash_code);
                        hash_table_objects_.Add(hash_code, _value);
                        hash_table_status_.Add(hash_code, true);
                    }
                }
                else if (!key_array_.Contains(hash_code))
                {
                    key_array_.Add(hash_code);
                    hash_table_objects_.Add(hash_code, _value);
                }
				update_weight(Time.time);
            }

            public bool cached_obj(int _hash_code)
            {
                return key_array_.Contains(_hash_code);
            }

            private void destroy_one_cache(object _key_object, bool _ignore_status = false)
            {
                if (((_key_object != null) && key_array_.Contains(_key_object)) && (_ignore_status || (is_com_free_obj(_key_object))))
                {
					object obj = hash_table_objects_[_key_object];
					remove_from_cache(_key_object);
                    if (releaser_ != null)
                    {
                        releaser_.release(obj);
                    }
                }
            }

			public void remove_from_cache(object _key_object)
			{
				if ((_key_object != null) && key_array_.Contains(_key_object) )
				{
					object obj = hash_table_objects_[_key_object];
					key_array_.Remove(_key_object);
					hash_table_objects_.Remove(_key_object);
					hash_table_status_.Remove(_key_object);
				}
			}

            public bool equals_key(object _key)
            {
                return (key_ != null) && (_key != null) && key_.Equals(_key);
            }

            public int get_free_cache_count()
            {
                int num = 0;
                if (ObjectCachePool.keep_cache_when_rent_)
                {
                    for (int i = 0; i < key_array_.Count; i++)
                    {
                        if (is_com_free_obj(key_array_[i]))
                        {
                            num++;
                        }
                    }
                    return num;
                }
                return key_array_.Count;
            }

            public int get_total_cache_count()
            {
                return key_array_.Count;
            }

            public float get_weight()
            {
                return weight_;
            }

            public bool init_cache(object _key, ObjectCachePool.CacheReleaser _releaser)
            {
                if (_key == null)
                {
                    weight_ = -1f;
                    return false;
                }
                key_ = _key;
                releaser_ = _releaser;
                return true;
            }

            public void reset()
            {
                key_ = null;
                hash_table_objects_.Clear();
                hash_table_status_.Clear();
                key_array_.Clear();
                weight_ = 0f;
            }

            public bool is_com_free_obj(object _object)
            {
                if (!(bool)hash_table_status_[_object])
                {
                    return false;
                }
                return true;
            }

            public int shrink(int _max_shrink_count)
            {
                List<object> list = new List<object>();
                for (int i = 0; i < key_array_.Count; i++)
                {
                    if (ObjectCachePool.keep_cache_when_rent_)
                    {
                        if (is_com_free_obj(key_array_[i]))
                        {
                            list.Add(key_array_[i]);
                        }
                    }
                    else
                    {
                        list.Add(key_array_[i]);
                    }
                }
                for (int j = 0; (j < list.Count) && (j < _max_shrink_count); j++)
                {
                    destroy_one_cache(list[j], true);
                }
                return list.Count;
            }

            public object try_hit_cache()
            {
                object obj = null;
                if (ObjectCachePool.keep_cache_when_rent_)
                {
                    for (int i = 0; i < key_array_.Count; i++)
                    {
                        int num = (int) key_array_[i];
                        if ((bool) hash_table_status_[num])
                        {
                            hash_table_status_[num] = false;
                            obj = hash_table_objects_[num];
							return obj;
                        }
                    }
					return obj;
                }
                if (key_array_.Count > 0)
                {
                    int key = (int) key_array_[0];
                    obj = hash_table_objects_[key];
                    key_array_.RemoveAt(0);
                    hash_table_objects_.Remove(key);
                }
                return obj;
            }

            public void update_weight(float _weight)
            {
                weight_ = _weight;
            }
        }

        public class CacheReleaser
        {
            private ReleaseCacheHandle release_handle_;

            public void register_release(ReleaseCacheHandle _handle)
            {
                if (_handle != null)
                {
                    release_handle_ = (ReleaseCacheHandle) Delegate.Combine(release_handle_, _handle);
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
                    release_handle_ = (ReleaseCacheHandle) Delegate.Remove(release_handle_, _handle);
                }
            }

            public delegate void ReleaseCacheHandle(object _obj);
        }
    }
}