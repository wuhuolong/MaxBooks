/*----------------------------------------------------------------
// 文件名： ChannelHelper.cs
// 文件功能描述： 渠道相关工具类
//----------------------------------------------------------------*/
using System;
using System.Collections.Generic;

namespace xc
{
    public class ChannelHelper
    {
        /// <summary>
        /// 根据渠道id获取渠道名字
        /// </summary>
        /// <param name="channel"></param>
        /// <returns></returns>
        public static string GetChannelName(string channel)
        {
            return ControlServerLogHelper.Instance.GetChannelName(channel);
        }
    }
}
