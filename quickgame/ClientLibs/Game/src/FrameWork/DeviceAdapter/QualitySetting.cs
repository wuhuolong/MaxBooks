//------------------------------------------------------------------------------
// 配置显示人数等
//------------------------------------------------------------------------------
using System;
using UnityEngine;

using Utils;

namespace xc
{
    /// <summary>
    /// 图像等级的枚举
    /// </summary>
    public enum EGraphLevel
    {
        INVALID = -1,
        HIGH = 0,
        MIDDLE = 1,
        LOW = 2,
    }

    [wxb.Hotfix]
    public class QualitySetting : xc.Singleton<QualitySetting>
    {
        public delegate void OnGraphicLevelChange(int level);
        public OnGraphicLevelChange OnGLChanged = null;

        // 同屏显示模型的最大数量
        public static uint MaxPlayerLow = 3;
        public static uint MaxPlayerMid = 15;
        public static uint MaxPlayerHigh = 20;

        // 同屏处理玩家的最大数量
        public static uint MaxPlayerProcessLow = 10;
        public static uint MaxPlayerProcessMid = 30;
        public static uint MaxPlayerProcessHigh = 50;

        public QualitySetting()
        {
            MaxPlayerLow = GameConstHelper.GetUint("GAME_MAX_PLAYER_LOW");
            MaxPlayerMid = GameConstHelper.GetUint("GAME_MAX_PLAYER_MID");
            MaxPlayerHigh = GameConstHelper.GetUint("GAME_MAX_PLAYER_HIGH");

            // 同屏处理玩家的最大数量
            MaxPlayerProcessLow = GameConstHelper.GetUint("GAME_MAX_PLAYER_PROCESS_LOW");
            MaxPlayerProcessMid = GameConstHelper.GetUint("GAME_MAX_PLAYER_PROCESS_MID");
            MaxPlayerProcessHigh = GameConstHelper.GetUint("GAME_MAX_PLAYER_PROCESS_HIGH");
        }

        /// <summary>
        /// 获取当前场景中推荐同屏显示的最大人数
        /// </summary>
        public static uint AdviceMaxPlayerCount
        {
            get
            {
                int level = QualitySetting.GraphicLevel;
                if (0 == level)
                    return QualitySetting.MaxPlayerHigh;
                else if (1 == level)
                    return QualitySetting.MaxPlayerMid;
                else
                {
                    // 对于性能很差的ios设备，需要特殊处理
                    if(IsVeryLowIPhone())
                    {
                        return GlobalConst.MinPlayerCount;
                    }
                    else
                        return QualitySetting.MaxPlayerLow;
                }
            }
        }

        /// <summary>
        /// 获取高配下的最大玩家数量
        /// </summary>
        public static uint HighMaxPlayerCount
        {
            get
            {
                return QualitySetting.MaxPlayerHigh;
            }
        }

        /// <summary>
        /// 获取最大玩家的数量
        /// </summary>
        /// <returns></returns>
        public static uint MaxPlayerCount
        {
            get
            {
                var advice_player_count = AdviceMaxPlayerCount;

                // 如果当前设置的玩家数量大于推荐的数量
                if (GlobalSettings.Instance.MaxPlayerCount > advice_player_count)
                {
                    return advice_player_count;
                }
                else
                    return (uint)GlobalSettings.Instance.MaxPlayerCount;
            }
            
            set
            {
                var advice_player_count = AdviceMaxPlayerCount;

                // 如果当前设置的玩家数量大于推荐的数量
                uint max_player = 0;
                if (value > advice_player_count)
                {
                    max_player = advice_player_count;
                }
                else
                    max_player = value;

                GlobalSettings.Instance.MaxPlayerCount = (int)max_player;
            }
        }

        /// <summary>
        /// 获取当前场景中同屏处理的最大人数
        /// </summary>
        public static uint GetMaxPlayerProcessCount()
        {
            int level = QualitySetting.GraphicLevel;
            if (0 == level)
                return QualitySetting.MaxPlayerProcessHigh;
            else if (1 == level)
                return QualitySetting.MaxPlayerProcessMid;
            else
                return QualitySetting.MaxPlayerProcessLow;
        }

        /// <summary>
        /// 设备自适应
        /// </summary>
        public static void DeviceAdaptation()
        {
            GlobalSettings.GetInstance();

            // 获取当前设备推荐的画面等级
            int level = GetAdviceGraphicLevel();

            // 获取已经设置的画面等级
            if (UserPlayerPrefs.Instance.Contain("GraphicLevel"))
            {
                // 当前设置的比推荐画质高时，使用推荐画质
                var local_setting = GlobalSettings.Instance.GraphicLevel;
                if (local_setting >= level)
                    level = local_setting;
            }
            else
            {
                // ios提审默认使用低配置画质
                if (AuditManager.Instance.AuditAndIOS())
                    level = 2;
            }

            // 设置默认同屏玩家数量
            if (UserPlayerPrefs.Instance.Contain("MaxPlayerCount") == false)
            {
                GlobalSettings.Instance.MaxPlayerCount = (int)AdviceMaxPlayerCount;
            }

            QualitySetting.GraphicLevel = level;
            GlobalSettings.GetInstance().Save();
        }

        /// <summary>
        /// 获得各平台下的推荐画面等级
        /// </summary>
        /// <returns></returns>
        public static int GetAdviceGraphicLevel()
        {
            float score = GetDeviceScore();

#if UNITY_ANDROID || UNITY_MOBILE_LOCAL
            // 先根据机型表进行适配(列表中包含华为的高端机型)
            var device_model = SystemInfo.deviceModel;
            int gl_level = DBDeviceList.Instance.GetGLLevelByDevice(device_model);
            if (gl_level != -1)
                return gl_level;

            string gpu_device = SystemInfo.graphicsDeviceName;

            // 再根据gpu芯片表进行适配
            gl_level = DBDeviceList.Instance.GetGLLevelByChip(gpu_device);
            if (gl_level != -1)
                return gl_level;

            bool accord_require = true; //是否满足中,高端最低配置要求

            // cpu双核及以下，设置为低画质
            if (SystemInfo.processorCount <= 2)
                accord_require = false;

            // 1G内存及以下，设置为低画质
            if(SystemInfo.systemMemorySize <= 1024)
                accord_require = false;

            if(!accord_require)
                return 2;
            else
            {
                // 对于Mali芯片，去掉MP参数再进行查找
                if(gpu_device.Contains("Mali"))
                {
                    var index = gpu_device.IndexOf("MP");
                    if(index != -1)
                        gpu_device = gpu_device.Substring(0, index).Trim();
                }

                if (score >= 8.0f)// 评分为高配
                {
                    // 获取GPU芯片的最高画面设置
                    var max_gl_level = DBDeviceList.Instance.GetGLMaxLevelByChip(gpu_device);
                    if (max_gl_level > 0)
                        return max_gl_level;
                    else
                    {
                        return 0;
                    }
                }
                else if (score >= 5.5f)// 评分为中配
                {
                    var max_gl_level = DBDeviceList.Instance.GetGLMaxLevelByChip(gpu_device);
                    if (max_gl_level > 1)
                        return max_gl_level;
                    else
                    {
                        return 1;
                    }

                }
                else// 评分为低配
                    return 2;
            }
#elif UNITY_IPHONE
            uint quality = DBIOSDevice.Instance.GetDeviceQuality(UnityEngine.iOS.Device.generation);
            return (int)quality;
#else
            return 0;
#endif
        }

        /// <summary>
        /// 计算设备评分
        /// </summary>
        /// <returns></returns>
        static float GetDeviceScore()
        {
            float score = 0;
            
            // cpu核数
            float cpu = 0;
            if (SystemInfo.processorCount <= 2)
                cpu = 2.0f;
            else if (SystemInfo.processorCount <= 4)
                cpu = 6.0f;
            else
                cpu = 10.0f;

            // cpu主频(ios获取不到processorFrequency)
            // 1GHz = 1000MHz
            float frequency = 0;
            if (SystemInfo.processorFrequency == 0)
                frequency = 6.0f;
            else if (SystemInfo.processorFrequency <= 1000) // 1.0GHZ 及以下
                frequency = 2.0f;
            else if (SystemInfo.processorFrequency <= 2000) // 1.0GHZ-2.0GHZ
                frequency = 6.0f;
            else
                frequency = 10.0f;
            
            // 显存
            float vram = 0;
            int g_mem = SystemInfo.graphicsMemorySize;
            if (g_mem <= 512)// 低: x<=512
                vram = 2.0f * (float)g_mem / 512.0f;
            else if (g_mem <= 1024) // 中:512< x <= 1024
                vram = 2.0f + 4.0f * (float)(g_mem-512) / 512.0f;
            else // 高:x > 1024
                vram = 6.0f + 4.0f * Mathf.Clamp01((float)(g_mem-1024) / 1024.0f);
            
            score = cpu * 0.2f + frequency * 0.3f + vram * 0.5f;

            /*float ram = 0;
            int sys_mem = SystemInfo.systemMemorySize;
            if (sys_mem <= 512)
                ram = 2.0f * (float)sys_mem / 512.0f;
            else if (sys_mem <= 1024)
                ram = 3.0f + 3.0f * (float)sys_mem / 1024.0f;
            else
                ram = 6.0f + 4.0f * Mathf.Clamp01((float)sys_mem / 2048.0f);*/

            Debug.Log("-----------------------------------------------------");
            Debug.Log("device score:" + (int)score);
            Debug.Log("processorCount:" + SystemInfo.processorCount + ", get score:" + cpu);
            Debug.Log("processorFrequency:" + SystemInfo.processorFrequency + ", get score:" + frequency);
            Debug.Log("graphicsMemorySize:" + SystemInfo.graphicsMemorySize + ", get score:" + vram);
            Debug.Log("deviceModel:" + SystemInfo.deviceModel);
            Debug.Log("graphicsDeviceName:" + SystemInfo.graphicsDeviceName);
            Debug.Log("-----------------------------------------------------");

            return score;
        }

        /// <summary>
        /// 设置场景显示等级的切换
        /// </summary>
        /// <param name="level"></param>
        public static void SetSceneGL(EGraphLevel level)
        {
            // 暂时屏蔽，通过四叉树加载的场景节点下没有实际的物体
            // 场景细节, 现在暂时没有场景细节物体
            /*GameObject highModeRoot = GameObject.Find("HighMode");
            if (highModeRoot != null)
            {
                Transform transRoot = highModeRoot.transform;
                Transform sceneTrans = transRoot.Find("scene");
                if (sceneTrans != null)
                {
                    sceneTrans.gameObject.SetActive(level == EGraphLevel.HIGH);
                }

                Transform audioTrans = transRoot.Find("audio");
                if (audioTrans != null)
                {
                    audioTrans.gameObject.SetActive(level == EGraphLevel.HIGH && GlobalSettings.GetInstance().MusicVolume != 0);
                }
            }*/
        }

        /// <summary>
        /// 图形显示的等级 0->2 : 高->低
        /// </summary>
        public static int GraphicLevel
        {
            get { return GlobalSettings.GetInstance().GraphicLevel; }
            set
            {
                GlobalSettings.GetInstance().GraphicLevel = value;
                QualitySetting.SetSceneGL((EGraphLevel)value);
                QualitySettings.SetQualityLevel(2 - value, true);

                bool isBornMap = false;
                DBMap.MapInfo mapInfp = SceneHelp.Instance.MapInfo;
                if (mapInfp != null)
                {
                    isBornMap = mapInfp.IsBornMap;
                }

                if (value <= 0)
                {
                    // 如果配置不用高配配置使用中配配置
                    if (isBornMap == true || Const.HAVE_HIGH_GRAPHIC_LEVEL == true)
                    {
                        Shader.globalMaximumLOD = 600;
                        Graphics.activeTier = UnityEngine.Rendering.GraphicsTier.Tier3;
                    }
                    else
                    {
                        Shader.globalMaximumLOD = 400;
                        Graphics.activeTier = UnityEngine.Rendering.GraphicsTier.Tier2;
                    }
                }
                else if (value <= 1) // 高、中画质
                {
                    Shader.globalMaximumLOD = 400;
                    Graphics.activeTier = UnityEngine.Rendering.GraphicsTier.Tier2;
                }
                else// 低画质下使用较差的角色Shader
                {
                    Shader.globalMaximumLOD = 300;
                    Graphics.activeTier = UnityEngine.Rendering.GraphicsTier.Tier1;
                }
                if (null != QualitySetting.Instance.OnGLChanged)
                {
                    QualitySetting.instance.OnGLChanged(value);
                }
            }
        }

        /// <summary>
        /// 进行画面的重置(设置界面开关一些参数没有实时生效)
        /// </summary>
        public void SetDirty()
        {
            CullManager.Instance.SetDirty();
        }

        /// <summary>
        /// 检查能否进行部件的更换
        /// </summary>
        /// <param name="actor"></param>
        /// <param name="body_part"></param>
        /// <param name="equip_id"></param>
        /// <returns></returns>
        public static uint CheckAvatarCapacity(Actor actor, DBAvatarPart.BODY_PART body_part, uint equip_id)
        {
            if (actor == null)
                return 0;

            if(actor.IsLocalPlayer || actor.IsClientModel())// 本地和预览的角色可换装
                return equip_id;
            else
            {
                if(body_part == DBAvatarPart.BODY_PART.WING)
                {
                    if (0 == GraphicLevel)
                        return equip_id;
                    else if (1 == GraphicLevel)
                        return equip_id;
                    else
                        return 0;
                }
                else
                    return equip_id;
            }
        }

        /// <summary>
        /// 是否跳过剧情
        /// </summary>
        public static bool SkipTimeline(uint minMemory)
        {
            if (minMemory > 0)
            {
                return SystemInfo.systemMemorySize <= minMemory;
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// 是否是低配的Iphone设备
        /// </summary>
        /// <returns></returns>
        public static bool IsVeryLowIPhone()
        {
            bool isLowIphone = false;
#if UNITY_IPHONE
            if (SystemInfo.systemMemorySize <= 1024)
                isLowIphone = true;
#endif
            return isLowIphone;
        }
    }
}

