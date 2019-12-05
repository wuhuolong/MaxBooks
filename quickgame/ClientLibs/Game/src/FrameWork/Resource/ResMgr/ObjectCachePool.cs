//------------------------------------
// File:ObjectCachePool.cs
// Desc:保存所有缓存对象的内存池
// Author: raorui
// Date: 2017.10.7
//------------------------------------
using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using UnityEngine;
namespace xc
{
    /// <summary>
    /// 保存所有缓存对象的内存池
    /// </summary>
    public class ObjectCachePool
    {
        /// <summary>
        /// 对象从内存池中取出时，是否仍在cache中保存
        /// </summary>
        public static bool KeepCacheWhenRent = true;

        /// <summary>
        /// 一级缓存的数量
        /// </summary>
        private int mCacheBlockMaxCount;

        /// <summary>
        /// 二级缓存的数量
        /// </summary>
        private int mBlockLimitCount;

        /// <summary>
        /// 上次更新的时间
        /// </summary>
        private float mLastUpdateTime;

        /// <summary>
        /// 缓存对象销毁时使用的方法
        /// </summary>
        private CacheReleaser mReleaser_;

        /// <summary>
        /// 保存所有的缓存对象
        /// </summary>
        private List<CachedObjectInfo> mPool = new List<CachedObjectInfo>();
     
        /// <summary>
        /// 更新的频率
        /// </summary>
		const float mUpdateFrequency = 5f;

        /// <summary>
        /// 缓存对象标记为可销毁的时间间隔
        /// </summary>
        private float mWornTime ;

        /// <summary>
        /// 缓存对象绑定的父节点
        /// </summary>
		public GameObject mRootNode;

		// 默认数值：(_releaser, 64, 128, 60, null);
		public ObjectCachePool(CacheReleaser _releaser, int _max_cache_count, int _cache_limit_count, float _worn_time, GameObject _root_node)
        {
            mCacheBlockMaxCount = _max_cache_count;
            mBlockLimitCount = _cache_limit_count;
			mWornTime = _worn_time;
			mRootNode = _root_node;
            mReleaser_ = _releaser;
            mLastUpdateTime = Time.time;
            init_pool();
        }

        /// <summary>
        /// 将对象添加到内存池中
        /// </summary>
        /// <param name="_key"></param>
        /// <param name="_value"></param>
        /// <returns></returns>
        public bool add_cache(string _key, object _value)
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

            // 如果对象已经在缓存中，则重新添加即可
            if (cache_info.cached_obj(_value.GetHashCode()))
            {
                cache_info.add_to_cache(_value);
                return true;
            }

            // 检查是否超出一级缓存的数量
            if (get_cache_count() >= mCacheBlockMaxCount)
            {
                try_fix_pool();
            }

            // 扩容后再次检查
            if (get_cache_count() > mCacheBlockMaxCount)
            {
                return false;
            }

            // 将对象放入缓存中
            cache_info.add_to_cache(_value);
            return true;
        }

        /// <summary>
        /// 将指定对象从内存池中移除（不销毁）
        /// </summary>
        /// <param name="_key"></param>
        /// <param name="_value"></param>
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

        /// <summary>
        /// 创建新的CachedObjectInfo对象并添加到内存池列表中
        /// </summary>
        /// <param name="_key"></param>
        /// <returns></returns>
        private CachedObjectInfo add_cache_info(string _key)
        {
            if (_key == null)
            {
                return null;
            }

            CachedObjectInfo item = new CachedObjectInfo();
            item.init_cache(_key, mReleaser_);
            mPool.Add(item);
            return item;
        }

        /// <summary>
        /// 销毁所有的缓存对象
        /// </summary>
        /// <param name="includeRent">是否包括当前正在使用的对象</param>
		public void clear_all_cache(bool includeRent)
        {
			if (includeRent) 
			{
				for (int i = 0; i < mPool.Count; i++) 
				{
					if (mPool [i] != null) {
						mPool [i].destroy_all_cache (includeRent);
					}	
				}
			} 
			else {
				for (int i = 0; i < mPool.Count; i++) {
					if (mPool [i] != null) {
						mPool [i].shrink (mPool [i].get_free_cache_count ());
					}
				}
			}
        }

        /// <summary>
        /// 获取内存池中所有对象的数量（包括已取出使用的对象）
        /// </summary>
        /// <returns></returns>
        public int get_cache_count()
        {
            int num = 0;
            for (int i = 0; i < mPool.Count; i++)
            {
                num += mPool[i].get_total_cache_count();
            }
            return num;
        }

        /// <summary>
        /// 通过key来获取CachedObjectInfo对象
        /// </summary>
        /// <param name="_key"></param>
        /// <returns></returns>
        private CachedObjectInfo get_cache_info(string _key)
        {
            for (int i = 0; i < mPool.Count; i++)
            {
                if (mPool[i].equals_key(_key))
                {
                    return mPool[i];
                }
            }
            return null;
        }

        /// <summary>
        /// 获取内存池中所有未使用对象的数量
        /// </summary>
        /// <returns></returns>
        public int get_free_cache_count()
        {
            int num = 0;
            for (int i = 0; i < mPool.Count; i++)
            {
                num += mPool[i].get_free_cache_count();
            }
            return num;
        }

        /// <summary>
        /// 初始化内存池
        /// </summary>
        public void init_pool()
        {
            if (mPool == null)
            {
                mPool = new List<CachedObjectInfo>();
            }
        }

        /// <summary>
        /// 缓存对象数量快超出一级缓存时，对其进行扩容
        /// </summary>
        private void try_fix_pool()
        {
            int free_cache_count = get_free_cache_count();
            int cache_count = get_cache_count();
            // 数量超过一级缓存的90%时
            if ((((float) cache_count) / ((float) mCacheBlockMaxCount)) >= 0.9f)
            {
                // 当前内存池中可用对象的比例少于20%时，需要进行扩容
                if ((((float) free_cache_count) / ((float) cache_count)) < 0.2f)
                {
                    mCacheBlockMaxCount += 32;
                    if (mCacheBlockMaxCount > mBlockLimitCount)
                    {
                        mCacheBlockMaxCount = mBlockLimitCount;
                    }
                }
                else
                {
                    // 销毁当前内存池中未被使用的对象，销毁数量为50%
                    for (int i = 0; i < mPool.Count; i++)
                    {
                        CachedObjectInfo info = mPool[i];
                        int num = info.get_free_cache_count();
                        info.shrink(num / 2);
                    }
                }
            }
        }

        /// <summary>
        /// 从内存池中获取对象
        /// </summary>
        /// <param name="_key"></param>
        /// <returns></returns>
        public object try_hit_cache(string _key)
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

        /// <summary>
        /// 定时检查标记为可销毁的对象
        /// </summary>
        public void update()
        {
            float time = Time.time;
            if ((time - mLastUpdateTime) >= mUpdateFrequency)
            {
                mLastUpdateTime = time;
                if (mPool != null)
                {
                    // 每次随机获取一个CacheObjectInfo
                    int index = UnityEngine.Random.Range(0, mPool.Count);
                    if ((index >= 0) && (index < mPool.Count))
                    {
                        CachedObjectInfo info = mPool[index];
                        if (info == null)
                        {
                            mPool.RemoveAt(index);
                        }
                        else
                        {
                            // 根据标记可销毁的时间间隔来计算需要销毁的对象数量
                            float num = Time.time - info.get_weight();
                            int max_shrink_count = (int) (num / mWornTime);
                            if (max_shrink_count > 0)
                            {
                                int free_cache_count = info.get_free_cache_count();
                                if (free_cache_count <= 0)// 无可用缓存对象时，移除CacheObjectInfo
                                {
                                    mPool.RemoveAt(index);
                                }
                                else
                                {
                                    // 移除的数量不能超出当前可用缓存对象
                                    max_shrink_count = (max_shrink_count <= free_cache_count) ? max_shrink_count : free_cache_count;
                                    info.shrink(max_shrink_count);
                                }
                            }
                        }
                    }
                }
            }
        }

        /// <summary>
        /// 获取缓存对象的根节点
        /// </summary>
        /// <returns></returns>
		public Transform get_root_node()
		{
			//when app exit, the root_node may release first, at this time we return null;
			return mRootNode!=null ? mRootNode.transform : null;
		}
    }
}