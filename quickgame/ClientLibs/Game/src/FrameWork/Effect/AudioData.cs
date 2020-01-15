//------------------------------------------------------------------------------
// FileName ： AudioData.cs
// Desc   ： 声音的信息
// Author : raorui
// Date : 2016.9.2
//------------------------------------------------------------------------------

using System;
using UnityEngine;

namespace xc
{
    public class AudioData
    {
        /// <summary>
        /// 声音挂载的父节点
        /// </summary>
        public Transform BindNode;

        /// <summary>
        /// 声音的资源路径
        /// </summary>
        public string AudioPath;

        /// <summary>
        /// 声音是否循环播放
        /// </summary>
        public bool IsLoop;

        
        public AudioData(Transform bind_node, string audio_path, bool is_loop)
        {
            BindNode = bind_node;
            AudioPath = audio_path;
            IsLoop = is_loop;
        }
    }
}

