//--------------------------------------------------
// File: VersionInfoManager.cs
// Desc: 保存所有版本信息的管理类
// Author: raorui
// Date: 2018.10.23
//--------------------------------------------------
using System;
using System.Collections.Generic;
using Utils;

namespace xc
{
    class VersionInfoManager : xc.Singleton<VersionInfoManager>
    {
        public string LocalVersion = "0.0.0";
        public string RemoteVersion = "0.0.0";
        public Dictionary<int, int> LocalVersionInfo = new Dictionary<int, int>();

        public string GameVersion = "";
    }
}
