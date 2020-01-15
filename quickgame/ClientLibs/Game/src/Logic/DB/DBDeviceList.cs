//-----------------------------------
// File: DBDeviceList.cs
// Desc: 设备信息列表
// Author: raorui
// Date: 2018.1.6
//-----------------------------------
using System;
using System.Collections.Generic;
using Utils;

namespace xc
{
    class DBDeviceList : xc.Singleton<DBDeviceList>
    {
        /// <summary>
        /// 获取表格中指定设备的画面等级
        /// </summary>
        /// <returns></returns>
        public int GetGLLevelByDevice(string device)
        {
            if (string.IsNullOrEmpty(device))
                return -1;

            var device_infos = DBManager.Instance.QuerySqliteRow<string>(GlobalConfig.DBFile, "device_list", "device", device);
            if(device_infos.Count <= 0)
                return -1;

            var info = device_infos[0];
            string gl_level_info = "";
            if(info.TryGetValue("gl_level", out gl_level_info))
            {
                int gl_level = -1;
                int.TryParse(gl_level_info, out gl_level);
                return gl_level;
            }

            return -1;
        }

        /// <summary>
        /// 根据芯片型号和芯片厂商来获取画面等级
        /// </summary>
        /// <param name="chip_id"></param>
        /// <param name="chip_type"></param>
        /// <returns></returns>
        public int GetGLLevelByChip(string chip_type)
        {
            if (string.IsNullOrEmpty(chip_type))
                return -1;

            var device_infos = DBManager.Instance.QuerySqliteRow<string>(GlobalConfig.DBFile, "chip_list", "chip_type", chip_type);
            if (device_infos.Count <= 0)
                return -1;

            var info = device_infos[0];
            string gl_level_info = "";
            if (info.TryGetValue("gl_level", out gl_level_info))
            {
                int gl_level = -1;
                int.TryParse(gl_level_info, out gl_level);
                return gl_level;
            }

            return -1;
        }

        /// <summary>
        /// 根据GPU型号获取可以设置的最大画面等级
        /// </summary>
        /// <param name="chip_type"></param>
        /// <returns></returns>
        public int GetGLMaxLevelByChip(string chip_type)
        {
            if (string.IsNullOrEmpty(chip_type))
                return 0;

            var device_infos = DBManager.Instance.QuerySqliteRow<string>(GlobalConfig.DBFile, "chip_limit_list", "chip_type", chip_type);
            if (device_infos.Count <= 0)
                return 0;

            var info = device_infos[0];
            string gl_level_info = "";
            if (info.TryGetValue("gl_max_level", out gl_level_info))
            {
                int gl_level = 0;
                int.TryParse(gl_level_info, out gl_level);
                return gl_level;
            }

            return 0;
        }
    }
}
