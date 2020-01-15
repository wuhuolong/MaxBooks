using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace xc
{
    [wxb.Hotfix]
    public class BuriedPointConst
    {
        public const string firstStart = "ESA_FIRST_START_GAME";                            // 新启动游戏_首次
        public const string firstLaunchBegin = "ESA_FIRST_LAUNCH_BEGIN";          // 为首次运行准备数据开始
        public const string firstLaunchEnd = "ESA_FIRST_LAUNCH_END";                // 为首次运行准备数据结束
        public const string first37WanUjoy = "ESA_FIRST_37WAN_UJOY";               // 首次登录_37wan渠道

        public const string koreaFirstCreateCharacter = "KOREA_FIRST_CREATE_CHARACTER";         // 创建角色 
    }

    [wxb.Hotfix]
    public class BuriedPointHelper
    {
        public static void ReportAppsflyerEvnet(string value)
        {
            if (Const.Region != RegionType.KOREA || string.IsNullOrEmpty(value))
            {
                return;
            }

            var bridge = DBOSManager.getDBOSManager().getBridge();
            Hashtable extmap = new Hashtable();
            extmap.Add("event", value);

            Hashtable parameter = new Hashtable();
            parameter.Add("action", "appsflyer");
            parameter.Add("extmap", extmap);

            Hashtable hashtable = new Hashtable();
            hashtable.Add("action", "reportEvent");
            hashtable.Add("parameter", parameter);
            
            string str = MiniJSON.JsonEncode(hashtable);
            bridge.doAction2SDK(str);
            GameDebug.LogError(str);
        }

        public static void ReportTapjoyEvnet(string value, string category = "")
        {
            if (Const.Region != RegionType.KOREA || string.IsNullOrEmpty(value))
            {
                return;
            }

            var bridge = DBOSManager.getDBOSManager().getBridge();
            Hashtable extmap = new Hashtable();
            extmap.Add("event", value);
            extmap.Add("category", category);

            Hashtable parameter = new Hashtable();
            parameter.Add("action", "tapjoy");
            parameter.Add("extmap", extmap);

            Hashtable hashtable = new Hashtable();
            hashtable.Add("action", "reportEvent");
            hashtable.Add("parameter", parameter);

            string str = MiniJSON.JsonEncode(hashtable);
            bridge.doAction2SDK(str);
            //GameDebug.LogError(str);
        }

        public static void ReportTjPlacementEvnet(string value, string category = "")
        {
            if (Const.Region != RegionType.KOREA || string.IsNullOrEmpty(value))
            {
                return;
            }

            var bridge = DBOSManager.getDBOSManager().getBridge();
            Hashtable extmap = new Hashtable();
            extmap.Add("event", value);
            extmap.Add("category", category);

            Hashtable parameter = new Hashtable();
            parameter.Add("action", "tj_placement");
            parameter.Add("extmap", extmap);

            Hashtable hashtable = new Hashtable();
            hashtable.Add("action", "reportEvent");
            hashtable.Add("parameter", parameter);

            string str = MiniJSON.JsonEncode(hashtable);
            bridge.doAction2SDK(str);
            //GameDebug.LogError(str);
        }

        public static void GoogleShowAchievements()
        {
            if (Const.Region != RegionType.KOREA)
            {
                return;
            }

            var bridge = DBOSManager.getDBOSManager().getBridge();
            Hashtable extmap = new Hashtable();

            Hashtable parameter = new Hashtable();
            parameter.Add("action", "GoogleShowAchievements");
            parameter.Add("extmap", extmap);

            Hashtable hashtable = new Hashtable();
            hashtable.Add("action", "sdkInvoke");
            hashtable.Add("parameter", parameter);

            string str = MiniJSON.JsonEncode(hashtable);
            bridge.doAction2SDK(str);
            //GameDebug.LogError(str);
        }

        public static void GoogleSubmitAchievements(string value)
        {
            if (Const.Region != RegionType.KOREA || string.IsNullOrEmpty(value))
            {
                return;
            }

            var bridge = DBOSManager.getDBOSManager().getBridge();
            Hashtable extmap = new Hashtable();
            extmap.Add("achievementsId", value);

            Hashtable parameter = new Hashtable();
            parameter.Add("action", "GoogleSubmitAchievements");
            parameter.Add("extmap", extmap);

            Hashtable hashtable = new Hashtable();
            hashtable.Add("action", "sdkInvoke");
            hashtable.Add("parameter", parameter);

            string str = MiniJSON.JsonEncode(hashtable);
            bridge.doAction2SDK(str);
            //GameDebug.LogError(str);
        }

        public static void ReportEsaAppsflyerEvnet(string eventName, string argKey, int argValue)
        {
            if (Const.Region != RegionType.SEASIA)
            {
                return;
            }

            var bridge = DBOSManager.getDBOSManager().getBridge();
            Hashtable extmap = new Hashtable();
            extmap.Add(argKey, argValue);

            Hashtable parameter = new Hashtable();
            parameter.Add("action", eventName);
            parameter.Add("extmap", extmap);

            Hashtable hashtable = new Hashtable();
            hashtable.Add("action", "reportEvent");
            hashtable.Add("parameter", parameter);

            string str = MiniJSON.JsonEncode(hashtable);
            bridge.doAction2SDK(str);
            //GameDebug.LogError(string.Format("ReportEsaAppsflyerEvnet ==> {0}", str));
        }

        public static void DoFacebookShare(string value)
        {
            if (Const.Region != RegionType.KOREA || string.IsNullOrEmpty(value))
            {
                return;
            }

            var bridge = DBOSManager.getDBOSManager().getBridge();
            Hashtable extmap = new Hashtable();

            GlobalConfig globalConfig = GlobalConfig.GetInstance();

            extmap.Add("roleID", globalConfig.LoginInfo.RId);
            extmap.Add("roleName", globalConfig.LoginInfo.Name);
            extmap.Add("serverID", globalConfig.LoginInfo.ServerInfo.ServerId);
            extmap.Add("shareEvent", "forevershare");
            extmap.Add("shareDetail", value);
            extmap.Add("screenShotFile", "");

            Hashtable parameter = new Hashtable();
            parameter.Add("action", "doFacebookShare");
            parameter.Add("extmap", extmap);

            Hashtable hashtable = new Hashtable();
            hashtable.Add("action", "sdkInvoke");
            hashtable.Add("parameter", parameter);

            string str = MiniJSON.JsonEncode(hashtable);
            bridge.doAction2SDK(str);
            //GameDebug.LogError(str);
        }
    }
}
