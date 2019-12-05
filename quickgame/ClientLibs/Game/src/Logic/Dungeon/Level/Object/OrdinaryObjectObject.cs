using UnityEngine;
using System.Collections.Generic;
using Neptune;
using Neptune.External;

namespace xc.Dungeon
{
    /// <summary>
    /// 不带有任何功能的普通节点
    /// </summary>
    public class OrdinaryObjectObject : ILevelObject
    {
        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="data"></param>
        public OrdinaryObjectObject(Neptune.OrdinaryObject data)
        : base(data)
        {
            mLoadPrefabCoroutine = LevelObjectHelper.SetObjectPrefab(gameObject, data.PrefabInfo);

            // 头顶名字
            if (string.IsNullOrEmpty(data.HeadName) == false)
            {
                UI3DText textComponent = gameObject.AddComponent<UI3DText>();
                UI3DText.StyleInfo styleInfo = new UI3DText.StyleInfo();
                styleInfo.Offset = data.HeadNamePosOffset;
                textComponent.ResetStyleInfo(styleInfo);
                var str = xc.TextHelper.GetTranslateText(data.HeadName);
                textComponent.Text = str;
            }
        }
    }
}
