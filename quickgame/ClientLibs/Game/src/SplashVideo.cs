//-----------------------------------
// File: SplashVideo.cs
// Desc: ios送审的时候 需要插入闪屏视频
// Author: luozhuocheng
// Date: 2018/8/15 12:38:44
//-----------------------------------
using System;
using UnityEngine.Video;
using UnityEngine;

namespace xc
{
    public class SplashVideo : MonoBehaviour
    {
        private VideoPlayer player;
        private Camera cameraVideo;
        void Start ()
        {
            Debug.Log (" VideoPlayer Start"+ Time.realtimeSinceStartup);

            cameraVideo = gameObject.AddComponent<Camera> ();
            cameraVideo.clearFlags = CameraClearFlags.Depth;
            cameraVideo.depth = 10;

            player = gameObject.AddComponent<VideoPlayer>();
            player.playOnAwake = false;
            player.url = "file://" + Application.streamingAssetsPath + "/video.mp4";
            player.prepareCompleted += prepareCompleted;
            player.Prepare ();
            player.targetCamera = cameraVideo;



        }
        private void prepareCompleted (VideoPlayer source)
        {
            Debug.Log (" VideoPlayer prepareCompleted"+ Time.realtimeSinceStartup);
            player.Play ();
        }


    }
}
