using UnityEngine;
using System.Collections.Generic;
using Neptune;
using Neptune.External;

namespace xc.Dungeon
{
    /// <summary>
    /// 互动物体/机关
    /// </summary>
    public class InteractionObject : ILevelObject
    {
        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="data"></param>
        public InteractionObject(Neptune.Interaction data)
        : base(data)
        {
            mLoadPrefabCoroutine = LevelObjectHelper.SetObjectPrefab(gameObject, data.PrefabInfo);
        }
    }
}
