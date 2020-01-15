using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
namespace xc
{
    [wxb.Hotfix]
    public class ActorAttribute : Dictionary<uint, IActorAttribute>
    {
        /// <summary>
        /// 属性集的总评分
        /// </summary>
        public uint Score { get; private set; }
        public ActorAttribute()
        {
            Score = 0;
        }

        /// <summary>
        /// 设置/获取对应的属性字段
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        public new IActorAttribute this[uint key]
        {
            get
            {
                IActorAttribute result;
                if (TryGetValue(key, out result))
                    return result;

                result = new DefaultActorAttribute(key, 0);
                base[key] = result;
                return result;
            }
            set
            {
                base[key] = value;
            }
        }

        /// <summary>
        /// 获取一个属性的对象
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        public IActorAttribute GetAttr(uint key)
        {
            IActorAttribute result;
            if (TryGetValue(key, out result))
                return result;
            return null;
        }

        /// <summary>
        /// 添加一个属性
        /// </summary>
        /// <param name="id"></param>
        /// <param name="value"></param>
        /// <param name="bMerge"> 相同id的属性是否合并 </param>
        public void Add(uint id, long value, bool bMerge = true)
        {
            IActorAttribute attr;
            if (TryGetValue(id, out attr) == false || bMerge == false)
            {
                attr = new DefaultActorAttribute(id, value);
                DefaultActorAttribute default_attr = attr as DefaultActorAttribute;
                Score += default_attr.Score;

                base.Add(id, attr);
            }
            else
            {
                DefaultActorAttribute default_attr = attr as DefaultActorAttribute;
                var score = default_attr.Score;
                default_attr.Value = default_attr.Value + value;
                Score += default_attr.Score - score;
            }
        }

        /// <summary>
        /// 移除一个属性
        /// </summary>
        /// <param name="id"></param>
        public new void Remove(uint id)
        {
            IActorAttribute attr;
            if (TryGetValue(id, out attr))
            {
                DefaultActorAttribute default_attr = attr as DefaultActorAttribute;
                if (Score < default_attr.Score)
                    Score = 0;
                else
                    Score -= default_attr.Score;

                base.Remove(id);
            }
        }

        public new void Clear()
        {
            Score = 0;
            base.Clear();
        }

        public ulong GetBattlePower()
        {
            return DBBattlePower.CalBattlePowerByAttrs(this);
        }

        public ActorAttribute Clone()
        {
            ActorAttribute attr = new ActorAttribute();

            foreach(var id in base.Keys)
            {
                attr.Add(id,this[id].Value);
            }
            
            return attr;
        }


        /// <summary>
        /// 根据PkgKvMin列表生成ActorAttribute
        /// </summary>
        /// <param name="pkgKvMins"></param>
        /// <returns></returns>
        public static ActorAttribute ParseByPkgKvMins(List<Net.PkgKvMin> pkgKvMins)
        {
            ActorAttribute actorAttribute = new ActorAttribute();

            foreach (var attr in pkgKvMins)
            {
                actorAttribute.Add(attr.k, attr.v);
            }

            return actorAttribute;
        }
    }
}


