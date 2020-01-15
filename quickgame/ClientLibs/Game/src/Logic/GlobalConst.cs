using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace xc
{
    [wxb.Hotfix]
    public class GlobalConst
    {
        public const float UnitScale = 0.01f; // 厘米转化为米
        public const float FrameLength = 1.0f / 30.0f;// 每帧的时长
        public const float MilliToSecond = 0.001f;// 毫秒转化为秒
        public const float MonsterDestroyDelay = 5.0f;// 怪物死亡后销毁的延迟时间
        public const float AttrConvert = 0.0001f; //属性的比例缩放数值，整形转浮点
        public const float AttrConvertInv = 10000.0f; //属性的比例缩放数值，浮点转整形
        public const string BuffIconFolder = "Assets/Res/UI/Textures/Buffs";
        public const string ReliveEffectLink = "Bip001 Spine1";// 复活特效的挂点
        public const string DefaultTestScene = "ZL_yucun_002"; // 默认的测试场景
        public const string LoginScene = "ZL_denglu_001"; // 登录场景
        public const float StandardRadius = 0.5f; // 标准角色的半径
        public const string DeathAnimation = "dir";// 死亡动画的名字
        public const bool IsBanshuVersion = false; //是否是版署版本
        public const string ResPath = "Assets/Res/";
        public const int MountSysId = 9; // 坐骑系统的id
        public const int MinPlayerCount = 1; // 可设置的同屏显示其他玩家的最小数量
        public static uint VoiceEngineType = 0; // 0为腾讯语音

#if UNITY_IPHONE
        public static string CreateActorScene
        {
            get
            {
                if (AuditManager.Instance.AuditAndIOS() && SDKHelper.GetSwitchModel())
                    return "ZL_chuangjue_003";

                else
                    return "ZL_chuangjue_001";
            }
        }

        public static string SelectActorScene
        {
            get
            {
                if (AuditManager.Instance.AuditAndIOS() && SDKHelper.GetSwitchModel())
                    return "ZL_chuangjue_004";

                else
                    return "ZL_chuangjue_002";
            }
        }        
#else
        public const string CreateActorScene = "ZL_chuangjue_001"; //创角场景
        public const string SelectActorScene = "ZL_chuangjue_002"; //选角场景
#endif

    }
}
