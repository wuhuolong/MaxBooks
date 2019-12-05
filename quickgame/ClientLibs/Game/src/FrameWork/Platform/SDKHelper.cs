//-----------------------------------
// File: SDKHelper.cs
// Desc: SDK辅助类
// Author: lijiayong
// Date: 2018.6.7
//-----------------------------------
using System;
using System.Collections.Generic;

namespace xc
{
    /// <summary>
    /// SDK配置信息
    /// </summary>
    public class SDKConfig
    {
        public string SDKNamePrefix = string.Empty; // sdk名字前缀
        public string LogoName = string.Empty;      // logo图片名字
        public string VersionInfo = string.Empty;   // 版号信息

        //C#
        public string LoginPrefab = string.Empty;   // 登录界面的prefab
        public string UIServerListWindow = string.Empty;     //选服界面   不还原  UIServerListWindow
        public string UICreateActorWindow = string.Empty;    //创角界面   还原    UICreateActorWindow
        //public string UISelectActorWindow = string.Empty;    //选角界面   还原    UISelectActorWindow
        public string UIChargeWindow = string.Empty;         //充值界面   不还原  UIChargeWindow
        //lua
        public string UIMapWindow = string.Empty;            //地图界面   还原    UIMapWindow
        public string UIBagWindow = string.Empty;            //背包界面   不还原  UIBagWindow
        public string UIPlayerPropertyWindow = string.Empty; //角色界面   还原    UIPlayerPropertyWindow
        public string UIWelfareWindow = string.Empty;        //福利界面   还原    UIWelfareWindow

        public string UIOpenServerActWindow = string.Empty;  //开服界面   还原    UIOpenServerActWindow
        public string UIForecastWindow = string.Empty;      //预告界面    还原    UIForecastWindow
        public string UINpcDialogWindow = string.Empty;     //对话界面    还原    UINpcDialogWindow
        public string UISkillWindow = string.Empty;         //技能界面    还原    UISkillWindow
        public string UISettingMainWindow = string.Empty;   //设置界面    还原    UISettingMainWindow
        public string UIGoodsComposeWindow = string.Empty;  //合成界面    还原    UIGoodsComposeWindow

        public string UIDialogWindow = string.Empty;        //对白界面    还原    UIDialogWindow
        public string UISurfaceWindow = string.Empty;       //外观界面    还原    UISurfaceWindow

        public string UIPayWindow = string.Empty;           //充值底板    还原    UIPayWindow
        public string UIMainmapWindow = string.Empty;           //充值底板    还原    UIMainmapWindow

        //public string born_scene = string.Empty;//送审的时候的场景

        public string is_copy_bag = string.Empty; // 是否马甲包
        public uint copy_bag_id = 0;//马甲包id

        public List<uint> role_list = null;  //角色模型

        public uint fashion_id = 0;//时装id

        public uint switch_model_scene = 0;//是否切换模型背景
    }

    public class SDKHelper
    {
        private static SDKConfig sSDKConfig = null;

        /// <summary>
        /// 根据SDKName获取SDK配置信息
        /// </summary>
        /// <returns></returns>
        public static SDKConfig GetSDKConfig()
        {

//test code
//#if UNITY_EDITOR
//            GlobalConfig.GetInstance().SDKName = "lemon_239";
//#endif


            if (sSDKConfig != null)
            {
                return sSDKConfig;
            }

            List<Dictionary<string, string>> dbs = DBManager.Instance.QuerySqliteTable<string>(GlobalConfig.DBFile, "data_sdk");
            string sdkName = GlobalConfig.GetInstance().SDKName;
            if (dbs.Count > 0)
            {
                Dictionary<string, string> retDb = null;
                foreach (Dictionary<string, string> db in dbs)
                {
                    string sdkNamePrefix = string.Empty;
                    db.TryGetValue("sdk_name_prefix", out sdkNamePrefix);

#if UNITY_IPHONE
                    if (sdkName == sdkNamePrefix)
                    {
                        retDb = db;

                        break;
                    }
#else
                    if (sdkName.StartsWith(sdkNamePrefix) == true)
                    {
                        retDb = db;

                        break;
                    }
#endif
                }

                if (retDb != null)
                {
                    SDKConfig config = new SDKConfig();

                    // sdk名字前缀
                    string rawStr = string.Empty;
                    retDb.TryGetValue("sdk_name_prefix", out rawStr);
                    config.SDKNamePrefix = rawStr;

                    // logo图片名字
                    rawStr = string.Empty;
                    retDb.TryGetValue("logo_name", out rawStr);
                    config.LogoName = rawStr;
                    
                    // 版号信息
                    rawStr = string.Empty;
                    retDb.TryGetValue("version_info", out rawStr);
                    config.VersionInfo = rawStr;




                    // 登录界面的资源
                    rawStr = string.Empty;
                    retDb.TryGetValue("login_prefab", out rawStr);
                    config.LoginPrefab = rawStr;
                    mWinList.Add(rawStr);

                    // 选服界面
                    rawStr = string.Empty;
                    retDb.TryGetValue("UIServerListWindow", out rawStr);
                    config.UIServerListWindow = rawStr;
                    mWinList.Add(rawStr);

                    // 创角界面
                    rawStr = string.Empty;
                    retDb.TryGetValue("UICreateActorWindow", out rawStr);
                    config.UICreateActorWindow = rawStr;
                    mWinList.Add(rawStr);

                    // 选角界面
                    //rawStr = string.Empty;
                    //retDb.TryGetValue("UISelectActorWindow", out rawStr);
                    //config.UISelectActorWindow = rawStr;
                    //mWinList.Add(rawStr);

                    // 充值界面
                    rawStr = string.Empty;
                    retDb.TryGetValue("UIChargeWindow", out rawStr);
                    config.UIChargeWindow = rawStr;
                    mWinList.Add(rawStr);

                    // 地图界面
                    rawStr = string.Empty;
                    retDb.TryGetValue("UIMapWindow", out rawStr);
                    config.UIMapWindow = rawStr;
                    mWinList.Add(rawStr);

                    // 背包界面
                    rawStr = string.Empty;
                    retDb.TryGetValue("UIBagWindow", out rawStr);
                    config.UIBagWindow = rawStr;
                    mWinList.Add(rawStr);

                    // 角色界面
                    rawStr = string.Empty;
                    retDb.TryGetValue("UIPlayerPropertyWindow", out rawStr);
                    config.UIPlayerPropertyWindow = rawStr;
                    mWinList.Add(rawStr);

                    // 福利界面
                    rawStr = string.Empty;
                    retDb.TryGetValue("UIWelfareWindow", out rawStr);
                    config.UIWelfareWindow = rawStr;
                    mWinList.Add(rawStr);

                    // 开服界面
                    rawStr = string.Empty;
                    retDb.TryGetValue("UIOpenServerActWindow", out rawStr);
                    config.UIOpenServerActWindow = rawStr;
                    mWinList.Add(rawStr);

                    // 预告界面
                    rawStr = string.Empty;
                    retDb.TryGetValue("UIForecastWindow", out rawStr);
                    config.UIForecastWindow = rawStr;
                    mWinList.Add(rawStr);

                    // 对话界面
                    rawStr = string.Empty;
                    retDb.TryGetValue("UINpcDialogWindow", out rawStr);
                    config.UINpcDialogWindow = rawStr;
                    mWinList.Add(rawStr);

                    // 对白界面
                    rawStr = string.Empty;
                    retDb.TryGetValue("UIDialogWindow", out rawStr);
                    config.UIDialogWindow = rawStr;
                    mWinList.Add(rawStr);


                    // 技能界面
                    rawStr = string.Empty;
                    retDb.TryGetValue("UISkillWindow", out rawStr);
                    config.UISkillWindow = rawStr;
                    mWinList.Add(rawStr);


                    // 设置界面
                    rawStr = string.Empty;
                    retDb.TryGetValue("UISettingMainWindow", out rawStr);
                    config.UISettingMainWindow = rawStr;
                    mWinList.Add(rawStr);


                    // 合成界面
                    rawStr = string.Empty;
                    retDb.TryGetValue("UIGoodsComposeWindow", out rawStr);
                    config.UIGoodsComposeWindow = rawStr;
                    mWinList.Add(rawStr);

                    // 外观界面
                    rawStr = string.Empty;
                    retDb.TryGetValue("UISurfaceWindow", out rawStr);
                    config.UISurfaceWindow = rawStr;
                    mWinList.Add(rawStr);

                    // 充值底板
                    rawStr = string.Empty;
                    retDb.TryGetValue("UIPayWindow", out rawStr);
                    config.UIPayWindow = rawStr;
                    mWinList.Add(rawStr);

                    // 主界面 
                    rawStr = string.Empty;
                    retDb.TryGetValue("UIMainmapWindow", out rawStr);
                    config.UIMainmapWindow = rawStr;
                    mWinList.Add(rawStr);

                    // 场景
                    //rawStr = string.Empty;
                    //retDb.TryGetValue("born_scene", out rawStr);
                    //config.born_scene = rawStr;


                    rawStr = string.Empty;
                    retDb.TryGetValue("is_copy_bag", out rawStr);
                    config.is_copy_bag = rawStr;


                    rawStr = string.Empty;
                    retDb.TryGetValue("copy_bag_id", out rawStr);
                    //config.copy_bag_id = Convert.ToUInt32(rawStr);
                    uint.TryParse(rawStr, out config.copy_bag_id);

                    rawStr = string.Empty;
                    retDb.TryGetValue("fashion_id", out rawStr);
                    //config.fashion_id = Convert.ToUInt32(rawStr);
                    uint.TryParse(rawStr, out config.fashion_id);


                    rawStr = string.Empty;
                    retDb.TryGetValue("switch_model_scene", out rawStr);
                    uint.TryParse(rawStr, out config.switch_model_scene);


                    rawStr = string.Empty;
                    retDb.TryGetValue("role_list", out rawStr);
                    if (rawStr != null)
                    {
                        config.role_list = new List<uint>();
                        var raw = rawStr.Replace("[", "").Replace("]", "");
                        string[] results = raw.Split(',');
                        for (int i = 0; i < results.Length; i++)
                        {
                            if (results[i].CompareTo(string.Empty) != 0)
                            {
                                uint role = 0;
                                uint.TryParse(results[i], out role);
                                config.role_list.Add(role);
                                //config.role_list.Add(Convert.ToUInt32(results[i]));
                            }
                        }
                    }


                    rawStr = string.Empty;
                    retDb.TryGetValue("is_show_customer_service", out rawStr);
                    SetAuditInfo("is_show_customer_service", rawStr);

                    rawStr = string.Empty;
                    retDb.TryGetValue("is_show_login_kv", out rawStr);
                    SetAuditInfo("is_show_login_kv", rawStr);


                    sSDKConfig = config;
                    return sSDKConfig;
                }
            }

            return null;
        }

        private static List<string> mWinList = new List<string>();
        public static List<string> GetSDKWinList()
        {
            SDKConfig config = GetSDKConfig();
            return mWinList;
        }



        /// <summary>
        /// 是否马甲包
        /// </summary>
        /// <returns></returns>
        public static bool IsCopyBag()
        {
            //SDKConfig config = GetSDKConfig();
            //if (config == null)
            //    return false;
            //return !string.IsNullOrEmpty(config.is_copy_bag);
            //废弃
            return false;
        }


        /// <summary>
        /// 获取sdk的名字
        /// </summary>
        /// <returns></returns>
        public static string GetSDKName()
        {
            SDKConfig config = GetSDKConfig();
            if (config == null)
                return null;
            return config.SDKNamePrefix;
        }

        public static List<uint> GetRoleList()
        {
            SDKConfig config = GetSDKConfig();
            if (config == null)
                return null;
            return config.role_list;

        }

        public static uint GetFashion()
        {
            SDKConfig config = GetSDKConfig();
            if (config == null)
                return 0;
            return config.fashion_id;
        }

        public static bool GetSwitchModel()
        {
            SDKConfig config = GetSDKConfig();
            if (config == null)
                return false;
            if (config.switch_model_scene == 0)
                return false;
            else
                return true;
        }



        /// <summary>
        /// 根据windowname获取prefab
        /// </summary>
        /// <param name="name">window的名字</param>
        /// <param name="needReset">needReset为true 的时候送审完会还原</param>
        /// <returns></returns>
        public static string GetPrefabName(string name, bool needReset)
        {


            SDKConfig config = GetSDKConfig();
            if (config == null)
                return name;

            if (string.IsNullOrEmpty(config.is_copy_bag))
                return name;


            //送审后还原 needReset为true的时候
            //if (AuditManager.Instance.AuditAndIOS() == false && needReset)

            //送审后统一还原
            if (AuditManager.Instance.AuditAndIOS() == false)
            {
                return name;
            }

            var src_name = name;

            switch (name)
            {
                case "UIQuickLoginWindow": name = sSDKConfig.LoginPrefab; break;
                case "UIServerListWindow": name = sSDKConfig.UIServerListWindow; break;
                case "UICreateActorWindow": name = sSDKConfig.UICreateActorWindow; break;
                //case "UISelectActorWindow": name = sSDKConfig.UISelectActorWindow; break;
                case "UIChargeWindow": name = sSDKConfig.UIChargeWindow; break;
                case "UIMapWindow": name = sSDKConfig.UIMapWindow; break;
                case "UIBagWindow": name = sSDKConfig.UIBagWindow; break;
                case "UIPlayerPropertyWindow": name = sSDKConfig.UIPlayerPropertyWindow; break;
                case "UIWelfareWindow": name = sSDKConfig.UIWelfareWindow; break;
                case "UIOpenServerActWindow": name = sSDKConfig.UIOpenServerActWindow; break;

                case "UIForecastWindow": name = sSDKConfig.UIForecastWindow; break;
                case "UINpcDialogWindow": name = sSDKConfig.UINpcDialogWindow; break;
                case "UISkillWindow": name = sSDKConfig.UISkillWindow; break;
                case "UISettingMainWindow": name = sSDKConfig.UISettingMainWindow; break;
                case "UIGoodsComposeWindow": name = sSDKConfig.UIGoodsComposeWindow; break;
                case "UISurfaceWindow": name = sSDKConfig.UISurfaceWindow; break;
                case "UIDialogWindow":name = sSDKConfig.UIDialogWindow;break;
                case "UIPayWindow":name = sSDKConfig.UIPayWindow;break;
                case "UIMainmapWindow": name = sSDKConfig.UIMainmapWindow; break;
            }

            if (string.IsNullOrEmpty(name))
                name = src_name;

            return name;
        }

        private static Dictionary<string, AuditInfo> mAuditInfoDic = new Dictionary<string, AuditInfo>();
        public static void SetAuditInfo(string key, string value)
        {
            AuditInfo info = new AuditInfo();
            info.key = key;
            if (string.IsNullOrEmpty(value) == false)
            {
                string[] splitStr = value.Split('_');
                if (splitStr.Length >= 2)
                {
                    info.whenAuditOpen = splitStr[0] == "0" ? false : true;
                    info.whenAuditClose = splitStr[1] == "0" ? false : true;
                }
            }
            mAuditInfoDic.Add(key, info);
        }


        //iphone 才调用该方法
        public static bool GetAuditInfo(string key)
        {
            AuditInfo info = null;
            if (mAuditInfoDic.TryGetValue(key, out info ))
            {
                if (AuditManager.Instance.Open)
                    return info.whenAuditOpen;
                else
                    return info.whenAuditClose;
            }
            return false;
        }

    }





    public class AuditInfo
    {
        public string key = null;
        public bool whenAuditOpen = false;
        public bool whenAuditClose = false;
    }




}