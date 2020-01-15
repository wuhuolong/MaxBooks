//------------------------------------------------------------------------------
// File : ScenePostProcess.cs
// Desc : 场景加载完毕后的处理逻辑
// Author : raorui
// Date : 2016.9.13
//------------------------------------------------------------------------------
using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;

using xc;
using SGameEngine;
using Utils;

[wxb.Hotfix]
public class ScenePostProcess : xc.Singleton<ScenePostProcess>
{
    //init the current loaded scene
    public void Do()
    {
        if(SceneHelp.loadedLevelName != "MapLoading")
        {
            if(GlobalConst.IsBanshuVersion)
            {
                PlayCoreAudio();
            }
            else
                InitAudio();

            InitLight();
            InitLightMap();

            if (ActorManager.Instance != null)
            {
                ActorManager.Instance.OnEnterScene();
            }
        }
    }

    void InitAudio()
    {
        GameObject core_object = xc.MainGame.CoreObject;
        if (core_object == null)
        {
            return;
        }

        // 处理背景音乐
        AudioSource scene_audio = null;
        if(Game.Instance.MainCamera != null)
            scene_audio = Game.Instance.MainCamera.GetComponent<AudioSource>();

        AudioSource core_audio = core_object.GetComponent<AudioSource>();
        if (scene_audio != null)
        {
            scene_audio.playOnAwake = false;
            scene_audio.Pause();
            //if (core_audio.clip != scene_audio.clip)
            //{
            //    //core_audio.clip = scene_audio.clip;
                
            //}
            AudioManager.GetInstance().SetClip(scene_audio.clip, BackGroundType.Main);
            //core_audio.volume = xc.GlobalSettings.GetInstance().MusicVolume;
            AudioManager.GetInstance().SetMusicVolume(xc.GlobalSettings.GetInstance().MusicVolume);

            Object.Destroy(scene_audio);
        }
        else
        {
            //core_audio.clip = null;
            AudioManager.GetInstance().KillMusic();
        }

        //core_audio.enabled = true ;
        //if (!GlobalSettings.GetInstance().MusicMute)
        //    core_audio.Play();
        //else
        //    core_audio.Pause();
        AudioManager.GetInstance().PauseMusic(GlobalSettings.GetInstance().MusicMute);


        /*GameObject bkAudio = GameObject.Find("yinxiao");
        if(bkAudio != null)
        {
            AudioSource[]  backgroudAudios = bkAudio.GetComponentsInChildren<AudioSource>();

            for (int i = 0; i < backgroudAudios.Length; ++i)
            {
                if (backgroudAudios[i] != null)
                    backgroudAudios[i].volume = xc.GlobalSettings.GetInstance().MusicVolume;
            }
        }*/
    }

    /// <summary>
    /// 针对版署版本进行特殊处理，使用同一个音乐
    /// </summary>
    void PlayCoreAudio()
    {
        GameObject core_object = xc.MainGame.CoreObject;
        if (core_object == null)
            return;

        // 处理背景音乐
        AudioSource core_audio = core_object.GetComponent<AudioSource>();
        if (core_audio != null)
        {
            if (core_audio.clip == null)
            {
                core_audio.clip = Resources.Load("Core/Sound") as AudioClip;
            }

            core_audio.volume = xc.GlobalSettings.GetInstance().MusicVolume;

            core_audio.enabled = Game.Instance.Connected;
            if (!GlobalSettings.GetInstance().MusicMute)
                core_audio.Play();
            else
                core_audio.Pause();
        }
    }

    /// <summary>
    /// 初始化灯光的设置
    /// </summary>
    void InitLight()
    {
        // 在场景的mixed灯光层级上添加InterObject
        var open_scene = SceneManager.GetActiveScene();
        if(open_scene != null)
        {
            var default_layer_mask = 1 << LayerMask.NameToLayer("Default");
            var root_game_objects = open_scene.GetRootGameObjects();
            foreach (var root_object in root_game_objects)
            {
                var light_trans = root_object.transform.Find("light");
                if (light_trans != null)
                {
                    for (int i = 0; i < light_trans.childCount; ++i)
                    {
                        var child_light = light_trans.GetChild(i).GetComponent<Light>();
                        if(child_light != null && child_light.cullingMask == default_layer_mask)
                        {
                            child_light.cullingMask = child_light.cullingMask | (1 << LayerMask.NameToLayer("InterObject"));
                            break;
                        }
                    }
                    break;
                }
            }
        }
    }

    void InitLightMap()
    {
        // 保险起见，只在Iphone上进行处理
#if UNITY_IPHONE
        // 低配机型,为了节省内存删除lightmapDir贴图
        if (QualitySetting.GetAdviceGraphicLevel() == 2)
        {
            LightmapSettings.lightmapsMode = LightmapsMode.NonDirectional;

            var lightMaps = LightmapSettings.lightmaps;//当前场景中已经存在的lightmap数据
            if (lightMaps == null)
                return;

            for (int i = 0; i < lightMaps.Length; i++)
            {
                var lightmapData = lightMaps[i];
                var lightmapDir = lightmapData.lightmapDir;
                if (lightmapDir != null)
                {
                    GameObject.DestroyImmediate(lightmapDir, true);
                    lightmapData.lightmapDir = null;
                }
            };
        }
#endif
    }
}