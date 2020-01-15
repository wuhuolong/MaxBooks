//------------------------------------------------------------------------------
// FileName ： DBMainmapAnimation.cs
// Desc   ： 提供主城界面动画的配置
// Author : raorui
// Date : 2016.12.12
//------------------------------------------------------------------------------
using System;
using System.Collections;
using System.Collections.Generic;
using Mono.Data.Sqlite;
using UnityEngine;
using xc;

namespace xc
{
    public class DBMainmapAnimation : DBSqliteTableResource
    {
        public class AnimationInfo
        {
            public string Anchor; // 动画在ui上对齐点的名字
            public string[] AnimationName; // 主UI播放的动画名字
        }

        public Dictionary<string, AnimationInfo> m_AnimationInfos = new Dictionary<string, AnimationInfo>();

        static DBMainmapAnimation m_Instance;

        public DBMainmapAnimation(string strName, string strPath) :
        base(strName, strPath)
        {
            m_Instance = this;
        }

        public static DBMainmapAnimation Instance
        {
            get
            {
                return m_Instance;
            }
        }

        /// <summary>
        /// 获取所有的动画配置
        /// </summary>
        public Dictionary<string, AnimationInfo> AnimationInfos
        {
            get
            {
                return m_AnimationInfos;
            }
        }

        protected override void ParseData(SqliteDataReader reader)
        {
            if (reader == null || !reader.HasRows)
            {
                return;
            }

            m_AnimationInfos.Clear();
            AnimationInfo info;
            while (reader.Read())
            {
                info = new AnimationInfo();
                info.Anchor = GetReaderString(reader, "anchor");

                uint ani_count = DBTextResource.ParseUI(GetReaderString(reader, "ani_count"));
                info.AnimationName = new string[ani_count];

                for(int i = 0; i < ani_count; ++i)
                {
                    info.AnimationName[i] = GetReaderString(reader, "ani_"+i);
                }

                m_AnimationInfos[info.Anchor] = info;
            }
        }

        public AnimationInfo GetAnimationInfo(string anchor)
        {
            AnimationInfo info = null;
            m_AnimationInfos.TryGetValue(anchor, out info);
            return info;
        }

        /// <summary>
        /// 通过动画对应UI节点和展开状态来获取对应的动画名字
        /// </summary>
        /// <param name="anchor"></param>
        /// <param name="state"></param>
        /// <returns></returns>
        public string GetAnimationName(string anchor, uint state)
        {
            AnimationInfo info = null;
            m_AnimationInfos.TryGetValue(anchor, out info);
            if(info != null)
            {
                if (state < info.AnimationName.Length)
                    return info.AnimationName[state];
            }

            return "";
        }
    }
}
