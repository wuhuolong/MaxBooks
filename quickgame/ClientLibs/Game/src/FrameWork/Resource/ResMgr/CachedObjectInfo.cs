//------------------------------------
// File:CachedObjectInfo.cs
// Desc:记录缓存对象的信息
// Author: raorui
// Date: 2017.10.7
//------------------------------------
using UnityEngine;
using System.Collections;
using System.Collections.Generic;

namespace xc
{
    /// <summary>
    /// 记录缓存对象的信息
    /// </summary>
    public class CachedObjectInfo
    {
        /// <summary>
        /// 缓存对象的key
        /// </summary>
        private string mKey;

        /// <summary>
        /// 保存缓存的对象，使用对象的hashcode作为key
        /// </summary>
        private Hashtable hash_table_objects_ = new Hashtable();

        /// <summary>
        /// 保存缓存对象的状态，在内存池中value为true，否则为false
        /// </summary>
        private Dictionary<int, bool> hash_table_status_ = new Dictionary<int, bool>();

        /// <summary>
        /// 记录缓存Object的hashcode
        /// </summary>
        private List<int> key_array_ = new List<int>();

        private CacheReleaser releaser_;

        /// <summary>
        /// 记录从内存池中取出的时间
        /// </summary>
        private float weight_ = 0f;

        /// <summary>
        /// 将对象添加到内存池中
        /// </summary>
        /// <param name="_value"></param>
        public void add_to_cache(object _value)
        {
            int hash_code = _value.GetHashCode();
            if (ObjectCachePool.KeepCacheWhenRent)
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

        /// <summary>
        /// _hash_code 对应的对象是否在缓存中
        /// </summary>
        /// <param name="_hash_code"></param>
        /// <returns></returns>
        public bool cached_obj(int _hash_code)
        {
            return key_array_.Contains(_hash_code);
        }

        /// <summary>
        /// 销毁所有的缓存对象
        /// </summary>
        /// <param name="_ignore_status"></param>
        public void destroy_all_cache(bool _ignore_status)
        {
            var tmp_key_arrey = new List<int>(key_array_);
            foreach (var key in tmp_key_arrey)
            {
                destroy_one_cache(key, _ignore_status);
            }
        }

        /// <summary>
        /// 从缓存池中移除缓存对象并销毁
        /// </summary>
        /// <param name="key"></param>
        /// <param name="_ignore_status">不管对象是否正在使用中</param>
        private void destroy_one_cache(int key, bool _ignore_status)
        {
            if ((key_array_.Contains(key)) && (_ignore_status || (is_com_free_obj(key))))
            {
                object obj = hash_table_objects_[key];
                remove_from_cache(key);
                if (releaser_ != null)
                {
                    releaser_.release(obj);
                }
            }
        }

        /// <summary>
        /// 从hashtable中移除key对应的缓存对象
        /// </summary>
        /// <param name="key"></param>
        public void remove_from_cache(int key)
        {
            if (key_array_.Contains(key))
            {
                key_array_.Remove(key);
                hash_table_objects_.Remove(key);
                hash_table_status_.Remove(key);
            }
        }

        /// <summary>
        /// key是否与缓存对象一致
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        public bool equals_key(string key)
        {
            return mKey == key;
        }

        /// <summary>
        /// 获取在内存池中未被使用的对象数量
        /// </summary>
        /// <returns></returns>
        public int get_free_cache_count()
        {
            int num = 0;
            if (ObjectCachePool.KeepCacheWhenRent)
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

        /// <summary>
        /// 获取缓存中对象的数量（不忽略已取出使用的对象）
        /// </summary>
        /// <returns></returns>
        public int get_total_cache_count()
        {
            return key_array_.Count;
        }

        /// <summary>
        /// 获取缓存对象放入或者取出的最新时间
        /// </summary>
        /// <returns></returns>
        public float get_weight()
        {
            return weight_;
        }

        /// <summary>
        /// 初始化
        /// </summary>
        /// <param name="key"></param>
        /// <param name="_releaser"></param>
        /// <returns></returns>
        public bool init_cache(string key, CacheReleaser _releaser)
        {
            if (key == null)
            {
                weight_ = -1f;
                return false;
            }
            mKey = key;
            releaser_ = _releaser;
            return true;
        }

        /// <summary>
        /// key对应的缓存对象是否在内存池中且未被使用
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        public bool is_com_free_obj(int key)
        {
            return hash_table_status_[key];
        }

        /// <summary>
        /// 缩减缓存对象的数量(只缩减当前未被使用的对象)
        /// </summary>
        /// <param name="_max_shrink_count">需要减少的数量</param>
        /// <returns></returns>
        public int shrink(int _max_shrink_count)
        {
            List<int> list = new List<int>();
            for (int i = 0; i < key_array_.Count; i++)
            {
                if (ObjectCachePool.KeepCacheWhenRent)
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

        /// <summary>
        /// 从内存池中获取一个对象
        /// </summary>
        /// <returns></returns>
        public object try_hit_cache()
        {
            object obj = null;
            if (ObjectCachePool.KeepCacheWhenRent)
            {
                for (int i = 0; i < key_array_.Count; i++)
                {
                    int k = key_array_[i];
                    if (hash_table_status_[k])
                    {
                        hash_table_status_[k] = false;
                        obj = hash_table_objects_[k];
                        return obj;
                    }
                }
                return obj;
            }

            if (key_array_.Count > 0)
            {
                int key = key_array_[0];
                obj = hash_table_objects_[key];
                key_array_.RemoveAt(0);
                hash_table_objects_.Remove(key);
            }

            return obj;
        }

        /// <summary>
        /// 更新使用缓存对象的时间
        /// </summary>
        /// <param name="_weight"></param>
        public void update_weight(float _weight)
        {
            weight_ = _weight;
        }
    }
}